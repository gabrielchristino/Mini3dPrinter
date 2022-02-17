Imports System.Threading

Imports System.IO

Imports System.Text

Imports System.IO.Ports
Public Class Form1

    Public lineToSend As Integer = 0
    Public sendLine As Boolean = False

    Public Event SerialDataRecieved(ByVal dataStr As String)
    WithEvents comPort As SerialPort = New SerialPort()

    Delegate Sub AddText(ByVal Text As String)

    Private Sub comPort_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles comPort.DataReceived
        RaiseEvent SerialDataRecieved(comPort.ReadLine())
    End Sub

    Private Sub HandleData(ByVal dataStr As String) Handles Me.SerialDataRecieved
        returnDataToScreen(dataStr)
        sendNextLine(dataStr)
    End Sub

    Private Sub returnDataToScreen(ByVal dataStr As String)
        TextBox2.Invoke(New AddText(AddressOf TextBox2.AppendText), dataStr + vbCrLf)
    End Sub

    Private Sub SendCommand(ByRef command As String)
        If (comPort.IsOpen And Not CheckBox1.Checked) Then comPort.Write(command + vbCrLf)
    End Sub

    Private Sub sendNextLine(ByVal dataStr As String)
        If (TextBox1.Lines.Length - 1 = lineToSend) Then
            sendLine = False
        End If

        If (dataStr.Contains(">") And TextBox1.Lines.Length - 1 > lineToSend And sendLine And Not CheckBox1.Checked) Then
            lineToSend += 1
            SendCommand(TextBox1.Lines(lineToSend))
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadComPorts()
    End Sub

    Private Sub loadComPorts()
        Dim AvailablePorts() As String = SerialPort.GetPortNames()

        Dim Port As String

        ComboBox1.Items.Clear()

        For Each Port In AvailablePorts
            ComboBox1.Items.Add(Port)
        Next Port
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        startSendData()
    End Sub

    Private Sub startSendData()
        lineToSend = 0
        sendLine = True
        SendCommand(TextBox1.Lines(lineToSend))
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        setComPort()
        validateIsOpen()
    End Sub

    Private Sub setComPort()
        comPort.PortName = ComboBox1.SelectedItem
        comPort.BaudRate = 9600
        comPort.Parity = Parity.None
        comPort.DataBits = 8
        comPort.StopBits = StopBits.One
        comPort.Open()
    End Sub

    Private Sub validateIsOpen()
        If (comPort.IsOpen()) Then
            MsgBox("Connected to " + comPort.PortName, MsgBoxStyle.OkOnly)
            SendCommand("M100;")
        Else
            MsgBox("An error occurred, please try again", MsgBoxStyle.OkOnly)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        disconnectComPort()
    End Sub

    Private Sub disconnectComPort()
        If (comPort.IsOpen) Then comPort.Close()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        CheckBox1.Text = IIf(CheckBox1.Checked, "PAUSED", "PAUSE")
        If (Not CheckBox1.Checked) Then
            sendNextLine(">")
        End If
    End Sub

    Private Sub validateIsNumber(sender As Object, e As KeyPressEventArgs)
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) AndAlso Not e.KeyChar = "." Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        validateIsNumber(sender, e)
    End Sub

    Private Sub TextBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox4.KeyPress
        validateIsNumber(sender, e)
    End Sub

    Private Sub TextBox5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox5.KeyPress
        validateIsNumber(sender, e)
    End Sub

    Private Sub TextBox6_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox6.KeyPress
        validateIsNumber(sender, e)
    End Sub

    Private Sub TextBox7_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox7.KeyPress
        validateIsNumber(sender, e)
    End Sub

    Private Sub TextBox8_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox8.KeyPress
        validateIsNumber(sender, e)
    End Sub

    Private Sub TextBox9_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox9.KeyPress
        validateIsNumber(sender, e)
    End Sub

    Private Sub moveXYZE(Optional x As String = "0", Optional y As String = "0", Optional z As String = "0", Optional e As String = "0", Optional f As String = "90")
        Dim eLength As Double = 0

        If (CheckBox2.Checked) Then
            eLength = Math.Round(Math.Sqrt(CDbl(Val(x)) * CDbl(Val(x)) + CDbl(Val(y)) * CDbl(Val(y))), 2)
        Else
            eLength = IIf(CDbl(Val(e)) <> 0, e, 0)
        End If

        SendCommand("G91;")
        SendCommand("M83;")
        SendCommand(String.Format("G1 X{0} Y{1} Z{2} E{3} F{4};", x, y, z, eLength, f))
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        moveXYZE(-TextBox3.Text, TextBox4.Text,,, TextBox9.Text)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        moveXYZE(, TextBox4.Text,,, TextBox9.Text)
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        moveXYZE(TextBox3.Text, TextBox4.Text,,, TextBox9.Text)
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        moveXYZE(TextBox3.Text,,,, TextBox9.Text)
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        SendCommand("G90;")
        SendCommand("G28;")
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        SendCommand("G90;")
        SendCommand("G92 X0 Y0 Z0;")
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        moveXYZE(-TextBox3.Text,,,, TextBox9.Text)
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        moveXYZE(TextBox3.Text, -TextBox4.Text,,, TextBox9.Text)
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        moveXYZE(, -TextBox4.Text,,, TextBox9.Text)
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        moveXYZE(-TextBox3.Text, -TextBox4.Text,,, TextBox9.Text)
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        moveXYZE(,, -TextBox5.Text,, TextBox9.Text)
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        moveXYZE(,, TextBox5.Text,, TextBox9.Text)
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        moveXYZE(,,, -TextBox6.Text, TextBox9.Text)
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        moveXYZE(,,, TextBox6.Text, TextBox9.Text)
    End Sub

    Private Sub Button22_Click(sender As Object, e As EventArgs) Handles Button22.Click
        SendCommand(String.Format("M109 S{0}", TextBox7.Text))
    End Sub

    Private Sub Button23_Click(sender As Object, e As EventArgs) Handles Button23.Click
        SendCommand(String.Format("M104 S{0}", TextBox7.Text))
    End Sub

    Private Sub Button24_Click(sender As Object, e As EventArgs) Handles Button24.Click
        SendCommand("M105")
    End Sub
End Class
