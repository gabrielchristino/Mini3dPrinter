import serial
import time

from pynput import keyboard

from pynput.keyboard import Key

index = 0
linhas = [
'M104 S200;',
'M109 S200;',
'G1 E10;',
'G1 F90;',
'G1 X30 E30;',
'G1 X20 E20;',
'G1 Y-20 E20;',
'G1 X-5 E5;',
'G1 Y-10 E10;',
'G1 X-10 E10;',
'G1 Y10 E10;',
'G1 X-5 E5;',
'G1 Y20 E20;',
'G1 Z0.8;',
'G1 X20 E20;',
'G1 Y-20 E20;',
'G1 X-5 E5;',
'G1 Y-10 E10;',
'G1 X-10 E10;',
'G1 Y10 E10;',
'G1 X-5 E5;',
'G1 Y20 E20;',
'G1 Z0.8;',
'G1 X20 E20;',
'G1 Y-20 E20;',
'G1 X-5 E5;',
'G1 Y-10 E10;',
'G1 X-10 E10;',
'G1 Y10 E10;',
'G1 X-5 E5;',
'G1 Y20 E20;',
'G1 Z0.8;',
'G1 X20 E20;',
'G1 Y-20 E20;',
'G1 X-5 E5;',
'G1 Y-10 E10;',
'G1 X-10 E10;',
'G1 Y10 E10;',
'G1 X-5 E5;',
'G1 Y20 E20;',
'G1 Z0.8;',
'G1 X20 E20;',
'G1 Y-20 E20;',
'G1 X-5 E5;',
'G1 Y-10 E10;',
'G1 X-10 E10;',
'G1 Y10 E10;',
'G1 X-5 E5;',
'G1 Y20 E20;',
'G1 Z0.8;',
'G1 X20 E20;',
'G1 Y-20 E20;',
'G1 X-5 E5;',
'G1 Y-10 E10;',
'G1 X-10 E10;',
'G1 Y10 E10;',
'G1 X-5 E5;',
'G1 Y20 E20;',
'G1 Z0.8;',
'G1 X20 E20;',
'G1 Y-20 E20;',
'G1 X-5 E5;',
'G1 Y-10 E10;',
'G1 X-10 E10;',
'G1 Y10 E10;',
'G1 X-5 E5;',
'G1 Y20 E20;',
'G1 Z0.8;',
'G1 X20 E20;',
'G1 Y-20 E20;',
'G1 X-5 E5;',
'G1 Y-10 E10;',
'G1 X-10 E10;',
'G1 Y10 E10;',
'G1 X-5 E5;',
'G1 Y20 E20;',
'G1 Z0.8;',
'G1 X20 E20;',
'G1 Y-20 E20;',
'G1 X-5 E5;',
'G1 Y-10 E10;',
'G1 X-10 E10;',
'G1 Y10 E10;',
'G1 X-5 E5;',
'G1 Y20 E20;',
'G1 Z0.8;',
'G1 X20 E20;',
'G1 Y-20 E20;',
'G1 X-5 E5;',
'G1 Y-10 E10;',
'G1 X-10 E10;',
'G1 Y10 E10;',
'G1 X-5 E5;',
'G1 Y20 E20;',
'G1 Z0.8;',
'G1 X20 E20;',
'G1 Y-20 E20;',
'G1 X-5 E5;',
'G1 Y-10 E10;',
'G1 X-10 E10;',
'G1 Y10 E10;',
'G1 X-5 E5;',
'G1 Y20 E20;',
'G1 Z0.8;',
'G1 X20 E20;',
'G1 Y-20 E20;',
'G1 X-5 E5;',
'G1 Y-10 E10;',
'G1 X-10 E10;',
'G1 Y10 E10;',
'G1 X-5 E5;',
'G1 Y20 E20;',
'G1 Z0.8;',
'G1 X20 E20;',
'G1 Y-20 E20;',
'G1 X-5 E5;',
'G1 Y-10 E10;',
'G1 X-10 E10;',
'G1 Y10 E10;',
'G1 X-5 E5;',
'G1 Y20 E20;',
'G1 Z0.8;',
'G1 X20 E20;',
'G1 Y-20 E20;',
'G1 X-5 E5;',
'G1 Y-10 E10;',
'G1 X-10 E10;',
'G1 Y10 E10;',
'G1 X-5 E5;',
'G1 Y20 E20;',
'G1 Z0.8;',
'G1 X20 E20;',
'G1 Y-20 E20;',
'G1 X-5 E5;',
'G1 Y-10 E10;',
'G1 X-10 E10;',
'G1 Y10 E10;',
'G1 X-5 E5;',
'G1 Y20 E20;',
'G1 Z0.8;',
'G1 X20 E20;',
'G1 Y-20 E20;',
'G1 X-5 E5;',
'G1 Y-10 E10;',
'G1 X-10 E10;',
'G1 Y10 E10;',
'G1 X-5 E5;',
'G1 Y20 E20;',
'G1 Z0.8;',
'G1 X20 E20;',
'G1 Y-20 E20;',
'G1 X-5 E5;',
'G1 Y-10 E10;',
'G1 X-10 E10;',
'G1 Y10 E10;',
'G1 X-5 E5;',
'G1 Y20 E20;',
'G1 Z0.8;',
'G1 X20 E20;',
'G1 Y-20 E20;',
'G1 X-5 E5;',
'G1 Y-10 E10;',
'G1 X-10 E10;',
'G1 Y10 E10;',
'G1 X-5 E5;',
'G1 Y20 E20;',
'G1 Z0.8;',
'G1 X20 E20;',
'G1 Y-20 E20;',
'G1 X-5 E5;',
'G1 Y-10 E10;',
'G1 X-10 E10;',
'G1 Y10 E10;',
'G1 X-5 E5;',
'G1 Y20 E20;',
'G1 Z0.8;',
'G1 X20 E20;',
'G1 Y-20 E20;',
'G1 X-5 E5;',
'G1 Y-10 E10;',
'G1 X-10 E10;',
'G1 Y10 E10;',
'G1 X-5 E5;',
'G1 Y20 E20;',
'G1 Z0.8;',
'G1 X20 E20;',
'G1 Y-20 E20;',
'G1 X-5 E5;',
'G1 Y-10 E10;',
'G1 X-10 E10;',
'G1 Y10 E10;',
'G1 X-5 E5;',
'G1 Y20 E20;',
'G1 Z0.8;',
'G1 X20 E20;',
'G1 Y-20 E20;',
'G1 X-5 E5;',
'G1 Y-10 E10;',
'G1 X-10 E10;',
'G1 Y10 E10;',
'G1 X-5 E5;',
'G1 Y20 E20;',
'G1 Z0.8;',
'G1 X20 E20;',
'G1 Y-20 E20;',
'G1 X-5 E5;',
'G1 Y-10 E10;',
'G1 X-10 E10;',
'G1 Y10 E10;',
'G1 X-5 E5;',
'G1 Y20 E20;',
'G1 Z0.8;',
'G1 X20 E20;',
'G1 Y-20 E20;',
'G1 X-5 E5;',
'G1 Y-10 E10;',
'G1 X-10 E10;',
'G1 Y10 E10;',
'G1 X-5 E5;',
'G1 Y20 E20;',
'G1 Z0.8;',
'G1 X20 E20;',
'G1 Y-20 E20;',
'G1 X-5 E5;',
'G1 Y-10 E10;',
'G1 X-10 E10;',
'G1 Y10 E10;',
'G1 X-5 E5;',
'G1 Y20 E20;',
'G1 Z0.8;',
'G1 X20 E20;',
'G1 Y-20 E20;',
'G1 X-5 E5;',
'G1 Y-10 E10;',
'G1 X-10 E10;',
'G1 Y10 E10;',
'G1 X-5 E5;',
'G1 Y20 E20;',
'G1 Z0.8;',
'G1 X20 E20;',
'G1 Y-20 E20;',
'G1 X-5 E5;',
'G1 Y-10 E10;',
'G1 X-10 E10;',
'G1 Y10 E10;',
'G1 X-5 E5;',
'G1 Y20 E20;',
'G1 Z0.8;',
'G1 X20 E20;',
'G1 Y-20 E20;',
'G1 X-5 E5;',
'G1 Y-10 E10;',
'G1 X-10 E10;',
'G1 Y10 E10;',
'G1 X-5 E5;',
'G1 Y20 E20;',
'G1 Z0.8;',
'G1 X20 E20;',
'G1 Y-20 E20;',
'G1 X-5 E5;',
'G1 Y-10 E10;',
'G1 X-10 E10;',
'G1 Y10 E10;',
'G1 X-5 E5;',
'G1 Y20 E20;',
'G1 Z0.8;',
'G1 X20 E20;',
'G1 Y-20 E20;',
'G1 X-5 E5;',
'G1 Y-10 E10;',
'G1 X-10 E10;',
'G1 Y10 E10;',
'G1 X-5 E5;',
'G1 Y20 E20;',
'G1 Z0.8;',
'G1 X-30'
]


arduino = serial.Serial(port='/dev/ttyUSB0', baudrate=9600, timeout=.1)
arduino.write(bytes('G91;\n', 'utf-8'))
temperature = 0

def writePrinter(x):
    arduino.write(bytes(x + '\n', 'utf-8'))
    time.sleep(0.1)

def StartPrint():
   while True:
    global index
    global linhas
    data = arduino.readline()
    data = data.decode()
    #print(data)
    if (data.find(">") > -1) :
        writePrinter(linhas[index])
        index+=1
        if(index == len(linhas)) :
            break
    elif (len(data) > 1) :
        print(data)

def Move(movimento):
    comando = 'G1 ' + movimento
    print(comando)
    arduino.write(bytes('G91;\n', 'utf-8'))
    arduino.write(bytes(comando + '\n', 'utf-8'))
    time.sleep(0.1)

def SetTemp(temp = 0):
    global temperature
    # print(temperature)
    temperature += temp*10
    comando = 'M104 S' + str(temperature)
    print(comando)
    arduino.write(bytes(comando + '\n', 'utf-8'))
    time.sleep(0.1)


def on_press(key):
    tecla = ''
    try:
        tecla = key.char
    except:
        tecla = key

    # print(tecla)
    
    match tecla:
        case Key.enter:
            StartPrint()
        case Key.left:
            Move('X-0.1')
        case Key.right:
            Move('X0.1')
        case Key.up:
            Move('Y0.1')
        case Key.down:
            Move('Y-0.1')
        case 'z':
            Move('Z-0.1')
        case 'a':
            Move('Z0.1')
        case 'e':
            Move('E0.1')
        case 'r':
            Move('E-0.1')
        case '-':
            SetTemp(-1)
        case '+':
            SetTemp(1)

def on_release(key):
    # print('{0} aqui'.format(key))
    if key == keyboard.Key.esc:
        # Stop listener
        return False

# Collect events until released123
with keyboard.Listener(
        on_press=on_press,
        on_release=on_release) as listener:
    listener.join()

