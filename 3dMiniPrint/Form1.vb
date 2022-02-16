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

    Private Sub sendNextLine(ByVal dataStr As String)
        If (TextBox1.Lines.Length - 1 = lineToSend) Then
            sendLine = False
        End If

        If (dataStr.Contains(">") And TextBox1.Lines.Length - 1 > lineToSend And sendLine And Not CheckBox1.Checked) Then
            lineToSend += 1
            comPort.Write(TextBox1.Lines(lineToSend) + vbCrLf)
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
        comPort.Write(TextBox1.Lines(lineToSend) + vbCrLf)
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
            comPort.Write(vbCrLf)
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
    End Sub
End Class
