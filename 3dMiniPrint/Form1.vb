Imports System.Threading

Imports System.IO

Imports System.Text

Imports System.IO.Ports
Public Class Form1

    Public lineToSend As Integer = -1
    Public sendLine As Boolean = False

    Public Event SerialDataRecieved(ByVal dataStr As String)
    WithEvents comPort As SerialPort = New SerialPort()

    Delegate Sub AddText(ByVal Text As String)
    Private Sub comPort_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles comPort.DataReceived
        RaiseEvent SerialDataRecieved(comPort.ReadLine())
    End Sub

    Private Sub HandleData(ByVal dataStr As String) Handles Me.SerialDataRecieved
        TextBox2.Invoke(New AddText(AddressOf TextBox2.AppendText), dataStr + vbCrLf)

        If (dataStr.Contains(">") And TextBox1.Lines.Length - 1 > lineToSend And sendLine) Then
            lineToSend += 1
            comPort.Write(TextBox1.Lines(lineToSend) + vbCrLf)
        ElseIf (TextBox1.Lines.Length - 1 = lineToSend) Then
            sendLine = False
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
        'For Each strLine As String In TextBox1.Text.Split(vbNewLine)
        lineToSend = 0
        sendLine = True
        comPort.Write(TextBox1.Lines(lineToSend) + vbCrLf)
        'Next
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        comPort.PortName = ComboBox1.SelectedItem   'Assign the port name to the MyCOMPort object
        comPort.BaudRate = 9600      'Assign the Baudrate to the MyCOMPort object
        comPort.Parity = Parity.None   'Parity bits = none  
        comPort.DataBits = 8             'No of Data bits = 8
        comPort.StopBits = StopBits.One  'No of Stop bits = 1
        comPort.Open()
        comPort.Write(vbCrLf)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If (comPort.IsOpen) Then comPort.Close()
    End Sub
End Class
