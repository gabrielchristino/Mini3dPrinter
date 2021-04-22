//#define VERBOSE              (1)  // add to get a lot more serial output.

#define VERSION              (2)  // firmware version
#define BAUD                 (9600)  // How fast is the Arduino talking?
#define MAX_BUF              (64)  // What is the longest message Arduino can store?
#define MAX_FEEDRATE         (8000)
#define MIN_FEEDRATE         (1000)
#define NUM_AXIES            (4)

// for arc directions
#define ARC_CW          (1)
#define ARC_CCW         (-1)
// Arcs are split into many line segments.  How long are the segments?
#define MM_PER_SEGMENT  (10)

// TEMPERATURE
// which analog pin to connect
#define THERMISTORPIN A5
// resistance at 25 degrees C
#define THERMISTORNOMINAL 100000
// temp. for nominal resistance (almost always 25 C)
#define TEMPERATURENOMINAL 25
// how many samples to take and average, more takes longer
// but is more 'smooth'
#define NUMSAMPLES 50
// The beta coefficient of the thermistor (usually 3000-4000)
#define BCOEFFICIENT 3950
// the value of the 'other' resistor
#define SERIESRESISTOR 10000
// HotEnd Pin
#define HOTENDPIN A4


//------------------------------------------------------------------------------
// INCLUDES
//------------------------------------------------------------------------------
#include <Wire.h>
#include <Stepper.h>
//------------------------------------------------------------------------------
// STRUCTS
//------------------------------------------------------------------------------

//------------------------------------------------------------------------------
// GLOBALS
//------------------------------------------------------------------------------
int mx[] = {2, 3, 4, 5};
int my[] = {A3, A2, A1, A0};
int mz[] = {6, 7, 8, 9};
int me[] = {10, 11, 12, 13};
int mv[] = {A4};

int hotendOn = 0;

float a[4][4];  // for line()
int passosA[5][4] = {
  {1,1,0,0},
  {0,1,1,0},
  {0,0,1,1},
  {1,0,0,1},
  {0,0,0,0}
};

char serialBuffer[MAX_BUF];  // where we store the message until we get a ';'
int sofar;  // how much is in the buffer

float px, py, pz, pe;  // location

// speeds
float fr = 0; // human version
long STEP_DELAY = 3;  // machine version

// settings
char mode_abs = 1; // absolute mode?
char mode_abs_e = 1; // absolute mode?

int STEPS_PER_TURN_X = 34;
int STEPS_PER_TURN_Y = 34;
int STEPS_PER_TURN_Z = 40;
int STEPS_PER_TURN_E = 34;

//int MIN_STEP_DELAY = 3;

long line_number = 0;

int samples[NUMSAMPLES];
float tempGet, te;
  unsigned long time_nowx, time_nowy, time_nowz, time_nowe = 0;

//------------------------------------------------------------------------------
// METHODS
//------------------------------------------------------------------------------


/*
   delay for the appropriate number of microseconds
   @input ms how many milliseconds to wait
*/
void pause(long ms) {
  delay(ms / 1000);
  delayMicroseconds(ms % 1000); // delayMicroseconds doesn't work for values > ~16k.
}


/*
   Set the feedrate (speed motors will move)
   @input nfr the new speed in steps/second
*/
void feedrate(float nfr) {
  //if (fr == nfr) return; // same as last time?  Quit now.
  if (nfr > MAX_FEEDRATE || nfr < MIN_FEEDRATE) { // don't allow crazy feed rates
    Serial.print(F("New feedrate must be greater than "));
    Serial.print(MIN_FEEDRATE);
    Serial.print(F("steps/s and less than "));
    Serial.print(MAX_FEEDRATE);
    Serial.println(F("steps/s."));
    return;
  }
  fr = -0.0045*nfr+38.1;
}


/*
   Set the logical position
   @input npx new position x
   @input npy new position y
*/
void position(float npx, float npy, float npz, float npe) {
  // here is a good place to add sanity tests
  px = npx;
  py = npy;
  pz = npz;
  pe = npe;
}


/*
   Supports movement with both styles of Motor Shield
   @input newx the destination x position
   @input newy the destination y position
*/

void noStep(byte STEPPER_PIN_1, byte STEPPER_PIN_2, byte STEPPER_PIN_3, byte STEPPER_PIN_4) {
  digitalWrite(STEPPER_PIN_1, LOW);
  digitalWrite(STEPPER_PIN_2, LOW);
  digitalWrite(STEPPER_PIN_3, LOW);
  digitalWrite(STEPPER_PIN_4, LOW);
}

void release() {
  noStep(mx[0], mx[1], mx[2], mx[3]);
  noStep(my[0], my[1], my[2], my[3]);
  noStep(mz[0], mz[1], mz[2], mz[3]);
  noStep(me[0], me[1], me[2], me[3]);
}


/*
   Uses bresenham's line algorithm to move both motors
   @input newx the destination x position
   @input newy the destination y position
*/
void line(float newx, float newy, float newz, float newe) {
  a[0][0] = (newx - px) * STEPS_PER_TURN_X; // delta
  a[1][0] = (newy - py) * STEPS_PER_TURN_Y; // delta
  a[2][0] = (newz - pz) * STEPS_PER_TURN_Z; // delta
  a[3][0] = (newe - pe) * STEPS_PER_TURN_E; // delta

  long maxsteps = 0;
  int tempox, tempoy, tempoz, tempoe = 0;

  for (long i = 0; i < NUM_AXIES; ++i) {
    a[i][1] = abs(a[i][0]); // passos total
    a[i][3] = a[i][0] > 0 ? 1 : -1; // direcao
    a[i][2] = a[i][3] > 0 ? 0 : 4; // passo atual
  }

  int controle = 0;
  if(a[0][1] > a[1][1]){
    maxsteps = a[0][1];
    controle = 0;
  } else {
    maxsteps = a[1][1];
    controle = 1;
  }
  if(maxsteps < a[2][1]){
    maxsteps = a[2][1];
    controle = 2;
  }
  if(maxsteps < a[3][1]){
    maxsteps = a[3][1];
    controle = 3;
  }
  tempox = (maxsteps/a[0][1])*fr;
  tempoy = (maxsteps/a[1][1])*fr;
  tempoz = (maxsteps/a[2][1])*fr;
  tempoe = (maxsteps/a[3][1])*fr;
  
  int pnx, pny, pnz, pne, qntopassos = 0;
  unsigned long tempo = millis();
  
  time_nowx = millis();
  time_nowy = time_nowx;
  time_nowz = time_nowx;
  time_nowe = time_nowx;
  while(qntopassos<maxsteps){
    tempo = millis();
    if(tempo >= time_nowx + tempox && a[0][0] != 0){
      time_nowx += tempox;
      
      if(a[0][3]>0){
        a[0][2]++;
      }else{
        a[0][2]--;
      }
      
      if(a[0][3]>0){
        if(a[0][2] == 4) {a[0][2] = 0;}
      }else{
        if(a[0][2] == -1) {a[0][2] = 3;}
      }
      
      pnx = a[0][2];
      if(controle == 0) {qntopassos++;}
    }
    if(tempo >= time_nowy + tempoy && a[1][0] != 0){
      time_nowy += tempoy;
      
      if(a[1][3]>0){
        a[1][2]++;
      }else{
        a[1][2]--;
      }
      
      if(a[1][3]>0){
        if(a[1][2] == 4) {a[1][2] = 0;}
      }else{
        if(a[1][2] == -1) {a[1][2] = 3;}
      }
      pny = a[1][2];
      if(controle == 1) {qntopassos++;}
    }
    if(tempo >= time_nowz + tempoz && a[2][0] != 0){
      time_nowz += tempoz;
      
      if(a[2][3]>0){
        a[2][2]++;
      }else{
        a[2][2]--;
      }
      
      if(a[2][3]>0){
        if(a[2][2] == 4) {a[2][2] = 0;}
      }else{
        if(a[2][2] == -1) {a[2][2] = 3;}
      }
      pnz = a[2][2];
      if(controle == 2) {qntopassos++;}
    }
    if(tempo >= time_nowe + tempoe && a[3][0] != 0){
      time_nowe += tempoe;
      
      if(a[3][3]>0){
        a[3][2]++;
      }else{
        a[3][2]--;
      }
      
      if(a[3][3]>0){
        if(a[3][2] == 4) {a[3][2] = 0;}
      }else{
        if(a[3][2] == -1) {a[3][2] = 3;}
      }
      pne = a[3][2];
      if(controle == 3) {qntopassos++;}
    }
    if(a[0][0] == 0){pnx=4;}
    if(a[1][0] == 0){pny=4;}
    if(a[2][0] == 0){pnz=4;}
    if(a[3][0] == 0){pne=4;}
    
    PORTB = 128+64+passosA[pne][0]*32+passosA[pne][1]*16+passosA[pne][2]*8+passosA[pne][3]*4+passosA[pnz][3]*2+passosA[pnz][2];
    PORTD = passosA[pnz][1]*128+passosA[pnz][0]*64+passosA[pnx][3]*32+passosA[pnx][2]*16+passosA[pnx][1]*8+passosA[pnx][0]*4;
    PORTC = 128+64+hotendOn*16+passosA[pny][0]*8+passosA[pny][1]*4+passosA[pny][2]*2+passosA[pny][3];
    
    /*digitalWrite(mx[0], passosA[pnx][0]);
    digitalWrite(mx[1], passosA[pnx][1]);
    digitalWrite(mx[2], passosA[pnx][2]);
    digitalWrite(mx[3], passosA[pnx][3]);
  
    digitalWrite(my[0], passosA[pny][0]);
    digitalWrite(my[1], passosA[pny][1]);
    digitalWrite(my[2], passosA[pny][2]);
    digitalWrite(my[3], passosA[pny][3]);
  
    digitalWrite(mz[0], passosA[pnz][0]);
    digitalWrite(mz[1], passosA[pnz][1]);
    digitalWrite(mz[2], passosA[pnz][2]);
    digitalWrite(mz[3], passosA[pnz][3]);
  
    digitalWrite(me[0], passosA[pne][0]);
    digitalWrite(me[1], passosA[pne][1]);
    digitalWrite(me[2], passosA[pne][2]);
    digitalWrite(me[3], passosA[pne][3]);*/
  }

  delay(STEP_DELAY);
  release();

  position(newx, newy, newz, newe);
}


// returns angle of dy/dx as a value from 0...2PI
static float atan3(float dy, float dx) {
  float a = atan2(dy, dx);
  if (a < 0) a = (PI * 2.0) + a;
  return a;
}


// This method assumes the limits have already been checked.
// This method assumes the start and end radius match.
// This method assumes arcs are not >180 degrees (PI radians)
// cx/cy - center of circle
// x/y - end position
// dir - ARC_CW or ARC_CCW to control direction of arc
static void arc(float cx, float cy, float x, float y, float dir) {
  // get radius
  float dx = px - cx;
  float dy = py - cy;
  float radius = sqrt(dx * dx + dy * dy);

  // find angle of arc (sweep)
  float angle1 = atan3(dy, dx);
  float angle2 = atan3(y - cy, x - cx);
  float theta = angle2 - angle1;

  if (dir > 0 && theta < 0) angle2 += 2 * PI;
  else if (dir < 0 && theta > 0) angle1 += 2 * PI;

  theta = angle2 - angle1;

  // get length of arc
  // float circ=PI*2.0*radius;
  // float len=theta*circ/(PI*2.0);
  // simplifies to
  float len = abs(theta) * radius;

  int i, segments = ceil( len * MM_PER_SEGMENT );

  float nx, ny, angle3, scale;

  for (i = 0; i < segments; ++i) {
    // interpolate around the arc
    scale = ((float)i) / ((float)segments);

    angle3 = ( theta * scale ) + angle1;
    nx = cx + cos(angle3) * radius;
    ny = cy + sin(angle3) * radius;
    // send it to the planner
    line(nx, ny, pz, pe);
  }

  line(x, y, pz, pe);
}


/*
   Look for character /code/ in the buffer and read the float that immediately follows it.
   @return the value found.  If nothing is found, /val/ is returned.
   @input code the character to look for.
   @input val the return value if /code/ is not found.
*/
float parseNumber(char code, float val) {
  char *ptr = serialBuffer; // start at the beginning of buffer
  while ((long)ptr > 1 && (*ptr) && (long)ptr < (long)serialBuffer + sofar) { // walk to the end
    if (*ptr == code) { // if you find code on your walk,
      return atof(ptr + 1); // convert the digits that follow into a float and return it
    }
    ptr = strchr(ptr, ' ') + 1; // take a step from here to the letter after the next space
  }
  return val;  // end reached, nothing found, return default val.
}

char parseNumber2(char code) {
  char *ptr = serialBuffer; // start at the beginning of buffer
  while ((long)ptr > 1 && (*ptr) && (long)ptr < (long)serialBuffer + sofar) { // walk to the end
    if (*ptr == code) { // if you find code on your walk,
      return *(ptr + 1);
    }
    ptr = strchr(ptr, ' ') + 1; // take a step from here to the letter after the next space
  }
  return ' ';
}
float parseNumber3(char code, float val) {
  char *ptr = serialBuffer; // start at the beginning of buffer
  //if(*ptr.indexOf(code) > 0) {
  ptr = strchr(ptr, '=') + 1; // take a step from here to the letter after the next space
  if (*ptr) {
    return atof(ptr); // convert the digits that follow into a float and return it
  }
  return val;
}

/*
   write a string followed by a float to the serial line.  Convenient for debugging.
   @input code the string.
   @input val the float.
*/
void output(char *code, float val) {
  Serial.print(code);
  Serial.println(val);
}


/*
   print the current position, feedrate, and absolute mode.
*/
void where() {
  output("X", px);
  output("Y", py);
  output("Z", pz);
  output("E", pe);
  output("F", (fr-38.1)/(-0.0045));
  Serial.println(mode_abs ? "ABS" : "REL");
}


/*
   display helpful information
*/
void help() {
  Serial.print(F("GcodeCNCDemo4AxisV2 "));
  Serial.println(VERSION);
  Serial.println(F("Commands:"));
  Serial.println(F("G00 [X(steps)] [Y(steps)] [Z(steps)] [E(steps)] [F(feedrate)]; - line"));
  Serial.println(F("G01 [X(steps)] [Y(steps)] [Z(steps)] [E(steps)] [F(feedrate)]; - line"));
  Serial.println(F("G02 [X(steps)] [Y(steps)] [I(steps)] [J(steps)] [F(feedrate)]; - clockwise arc"));
  Serial.println(F("G03 [X(steps)] [Y(steps)] [I(steps)] [J(steps)] [F(feedrate)]; - counter-clockwise arc"));
  Serial.println(F("G04 P[seconds]; - delay"));
  Serial.println(F("G21; - millimeters"));
  Serial.println(F("G28; - go home"));
  Serial.println(F("G71; - millimeters"));
  Serial.println(F("G90; - absolute mode"));
  Serial.println(F("G91; - relative mode"));
  Serial.println(F("G92 [X(steps)] [Y(steps)] [Z(steps)] [E(steps)]; - change logical position"));
  Serial.println(F("M18; - disable motors"));
  Serial.println(F("M82; - absolute mode extruder"));
  Serial.println(F("M83; - relative mode extruder"));
  Serial.println(F("M100; - this help message"));
  Serial.println(F("M104 [S(temperature)]; - set hotend temperature"));
  Serial.println(F("M105; - get hotend temperature"));
  Serial.println(F("M106 [S(speed)]; - set fan speed, from 0 to 255"));
  Serial.println(F("M107; - set fan off"));
  Serial.println(F("M109 [S(temperature)]; - wait for hotend temperature"));
  Serial.println(F("M114; - report position and feedrate"));
  Serial.println(F("M117 [string]; - display message on printer"));
  Serial.println(F("M140 [S(temperature)]; - set bed temperature"));
  Serial.println(F("M190 [S(temperature)]; - wait for bed temperature"));
  Serial.println(F("All commands must end with a newline."));
}

void parameters() {
  //Serial.print(F("$0="));
  //Serial.println(MIN_STEP_DELAY);
  Serial.print(F("$1="));
  Serial.println(STEP_DELAY);
  Serial.print(F("$100="));
  Serial.println(STEPS_PER_TURN_X);
  Serial.print(F("$101="));
  Serial.println(STEPS_PER_TURN_Y);
  Serial.print(F("$102="));
  Serial.println(STEPS_PER_TURN_Z);
  Serial.print(F("$103="));
  Serial.println(STEPS_PER_TURN_E);
  Serial.println(F("$130=200.000"));
  Serial.println(F("$131=200.000"));
  Serial.println(F("$132=200.000"));
}

void parameters2() {
  Serial.print(mode_abs ? "G90 " : "G91 ");
  Serial.print(mode_abs_e ? "M82 " : "M83 ");
  Serial.print(F("G17 G21 "));
  Serial.print(F("F"));
  Serial.print((fr-38.1)/(-0.0045));
  Serial.println();
}

void turnCooler(int option) {
  //analogWrite(mv[0], option);
}

void tempControl(float temp) {

  uint8_t i;
  float average;
  // take N samples in a row, with a slight delay
  for (i = 0; i < NUMSAMPLES; i++) {
    samples[i] = analogRead(THERMISTORPIN);
  }
  // average all the samples out
  average = 0;
  for (i = 0; i < NUMSAMPLES; i++) {
    average += samples[i];
  }
  average /= NUMSAMPLES;
  // convert the value to resistance
  average = 1023 / average - 1;
  average = SERIESRESISTOR / average;

  float steinhart;
  steinhart = average / THERMISTORNOMINAL;     // (R/Ro)
  steinhart = log(steinhart);                  // ln(R/Ro)
  steinhart /= BCOEFFICIENT;                   // 1/B * ln(R/Ro)
  steinhart += 1.0 / (TEMPERATURENOMINAL + 273.15); // + (1/To)
  steinhart = 1.0 / steinhart;                 // Invert
  steinhart -= 273.15;                         // convert to C
  tempGet = steinhart;

  if (temp != te) {
    te = temp;
  }
  /*Serial.print(tempGet);
  Serial.print(" ");
  Serial.print(te);
  Serial.print(" ");
  Serial.print(hotendOn);
  Serial.println("");*/
  if ((tempGet < te) && te != 0) {
    digitalWrite(HOTENDPIN, HIGH);
    hotendOn = 1;
  } else {
    digitalWrite(HOTENDPIN, LOW);
    hotendOn = 0;
  }
}

void tempWait(float temp) {
  if (tempGet < temp || tempGet > temp + 1) {
    while (true) {
      tempControl(temp);
      if (tempGet > te - 1 && tempGet < te + 1) {
        break;
      }
    }
  }
}

/*
   Read the input buffer and find any recognized commands.  One G or M command per line.
*/
void processCommand() {
  // blank lines
  if (serialBuffer[0] == ';') return;

  long cmd;
  char *cmd2;
  int getParam = -1;

  // is there a line number?
  cmd = parseNumber('N', -1);
  if (cmd != -1 && serialBuffer[0] == 'N') { // line number must appear first on the line
    if (cmd != line_number) {
      // wrong line number error
      Serial.print(F("BADLINENUM "));
      Serial.println(line_number);
      return;
    }

    // is there a checksum?
    if (strchr(serialBuffer, '*') != 0) {
      // yes.  is it valid?
      char checksum = 0;
      int c = 0;
      while (serialBuffer[c] != '*') checksum ^= serialBuffer[c++];
      c++; // skip *
      int against = strtod(serialBuffer + c, NULL);
      if (checksum != against) {
        Serial.print(F("BADCHECKSUM "));
        Serial.println(line_number);
        return;
      }
    } else {
      Serial.print(F("NOCHECKSUM "));
      Serial.println(line_number);
      return;
    }

    line_number++;
  }

  cmd = parseNumber('G', -1);
  switch (cmd) {
    case  0:
    case  1: { // line
        feedrate(parseNumber('F', (fr-38.1)/(-0.0045)));
        line( parseNumber('X', (mode_abs ? px : 0)) + (mode_abs ? 0 : px),
              parseNumber('Y', (mode_abs ? py : 0)) + (mode_abs ? 0 : py),
              parseNumber('Z', (mode_abs ? pz : 0)) + (mode_abs ? 0 : pz),
              parseNumber('E', (mode_abs_e ? pe : 0)) + (mode_abs_e ? 0 : pe) );
        break;
      }
    case 2:
    case 3: {  // arc
        feedrate(parseNumber('F', (fr-38.1)/(-0.0045)));
        arc(parseNumber('I', (mode_abs ? px : 0)) + (mode_abs ? 0 : px),
            parseNumber('J', (mode_abs ? py : 0)) + (mode_abs ? 0 : py),
            parseNumber('X', (mode_abs ? px : 0)) + (mode_abs ? 0 : px),
            parseNumber('Y', (mode_abs ? py : 0)) + (mode_abs ? 0 : py),
            (cmd == 2) ? -1 : 1);
        break;
      }
    case  4:  pause(parseNumber('P', 0) * 1000);  break; // dwell
    case 28:  line(0, 0, 0, 0); break;
    case 90:  mode_abs = 1;  break; // absolute mode
    case 91:  mode_abs = 0;  break; // relative mode
    case 92:  // set logical position
      position( parseNumber('X', (mode_abs ? px : 0)) + (mode_abs ? 0 : px),
                parseNumber('Y', (mode_abs ? py : 0)) + (mode_abs ? 0 : py),
                parseNumber('Z', (mode_abs ? pz : 0)) + (mode_abs ? 0 : pz),
                parseNumber('E', (mode_abs_e ? pe : 0)) + (mode_abs_e ? 0 : pe) );
      break;
    default:  break;
  }

  cmd = parseNumber('M', -1);
  switch (cmd) {
    case 18:  // disable motors
      release();
      break;
    case 82:  mode_abs_e = 1;  break; // absolute mode
    case 83:  mode_abs_e = 0;  break; // relative mode
    case 100:  help();  break;
    case 104:  tempControl(parseNumber('S', te)); break;
    case 105:  Serial.println(tempGet); break;
    case 106:  turnCooler(parseNumber('S', 0)); break;
    case 107:  turnCooler(0); break;
    case 109:  tempWait(parseNumber('S', te)); break;
    case 114:  where();  break;
    default:   break;
  }

  switch (parseNumber2('$')) {
    case '$': parameters(); getParam = -1; break;
    case 'G': parameters2(); getParam = -1; break;
    default:  getParam = 0; break;
  }

  cmd = parseNumber('$', -1);
  switch (cmd + getParam) {
    //case 0: MIN_STEP_DELAY = parseNumber3('=', 3); break;
    case 1: STEP_DELAY = parseNumber3('=', 3); break;
    case 100: STEPS_PER_TURN_X = parseNumber3('=', 34); break;
    case 101: STEPS_PER_TURN_Y = parseNumber3('=', 34); break;
    case 102: STEPS_PER_TURN_Z = parseNumber3('=', 40); break;
    case 103: STEPS_PER_TURN_E = parseNumber3('=', 34); break;
    default:  break;
  }
}


/*
   prepares the input buffer to receive a new message and tells the serial connected device it is ready for more.
*/
void readyPrint() {
  sofar = 0; // clear input buffer
  Serial.print(F(">"));  // signal ready to receive input
}


/*
   First thing this machine does on startup.  Runs only once.
*/
void setup() {
  pinMode(mx[0], OUTPUT); pinMode(mx[1], OUTPUT); pinMode(mx[2], OUTPUT); pinMode(mx[3], OUTPUT);
  pinMode(my[0], OUTPUT); pinMode(my[1], OUTPUT); pinMode(my[2], OUTPUT); pinMode(my[3], OUTPUT);
  pinMode(mz[0], OUTPUT); pinMode(mz[1], OUTPUT); pinMode(mz[2], OUTPUT); pinMode(mz[3], OUTPUT);
  pinMode(me[0], OUTPUT); pinMode(me[1], OUTPUT); pinMode(me[2], OUTPUT); pinMode(me[3], OUTPUT);
  pinMode(mv[0], OUTPUT);
  Serial.begin(BAUD);  // open coms
  help();  // say hello
  position(0, 0, 0, 0); // set staring position
  feedrate(6500);  // set default speed
  readyPrint();
}


/*
   After setup() this machine will repeat loop() forever.
*/
void loop() {
  // listen for serial commands
  while (Serial.available() > 0) { // if something is available
    char c = Serial.read(); // get it
    Serial.print(c);  // repeat it back so I know you got the message
    if (sofar < MAX_BUF - 1) serialBuffer[sofar++] = c; // store it
    if (c == '\n') {
      // entire message received
      serialBuffer[sofar] = 0; // end the buffer so string functions work right
      // Serial.print(F("\r\n"));  // echo a return character for humans
      processCommand();  // do something with the command
      readyPrint();
    }
  }
  tempControl(te);
}
