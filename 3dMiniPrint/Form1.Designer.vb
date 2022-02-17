<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TextBox9 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Button24 = New System.Windows.Forms.Button()
        Me.TextBox8 = New System.Windows.Forms.TextBox()
        Me.Button22 = New System.Windows.Forms.Button()
        Me.Button23 = New System.Windows.Forms.Button()
        Me.TextBox7 = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button17 = New System.Windows.Forms.Button()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button15 = New System.Windows.Forms.Button()
        Me.Button12 = New System.Windows.Forms.Button()
        Me.Button16 = New System.Windows.Forms.Button()
        Me.Button11 = New System.Windows.Forms.Button()
        Me.Button13 = New System.Windows.Forms.Button()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.Button14 = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(318, 353)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Send"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox1.Location = New System.Drawing.Point(0, 0)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.PlaceholderText = "Insert GCODE here to send"
        Me.TextBox1.Size = New System.Drawing.Size(398, 278)
        Me.TextBox1.TabIndex = 1
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(318, 12)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "Disconnect"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(12, 12)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(84, 23)
        Me.Button3.TabIndex = 6
        Me.Button3.Text = "Refresh ports"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'TextBox2
        '
        Me.TextBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox2.Location = New System.Drawing.Point(420, 41)
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox2.Size = New System.Drawing.Size(360, 306)
        Me.TextBox2.TabIndex = 5
        '
        'CheckBox1
        '
        Me.CheckBox1.BackColor = System.Drawing.Color.Red
        Me.CheckBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CheckBox1.ForeColor = System.Drawing.Color.White
        Me.CheckBox1.Location = New System.Drawing.Point(399, 352)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(104, 24)
        Me.CheckBox1.TabIndex = 7
        Me.CheckBox1.Text = "PAUSE"
        Me.CheckBox1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CheckBox1.UseVisualStyleBackColor = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(12, 41)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(406, 306)
        Me.TabControl1.TabIndex = 8
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.TextBox1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 24)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(398, 278)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Send GCODE"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Label9)
        Me.TabPage2.Controls.Add(Me.TextBox9)
        Me.TabPage2.Controls.Add(Me.Label8)
        Me.TabPage2.Controls.Add(Me.GroupBox3)
        Me.TabPage2.Controls.Add(Me.GroupBox1)
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Controls.Add(Me.TextBox6)
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.TextBox5)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Controls.Add(Me.TextBox4)
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Controls.Add(Me.TextBox3)
        Me.TabPage2.Controls.Add(Me.Label1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 24)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(398, 278)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Manual Control"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(266, 24)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(55, 15)
        Me.Label9.TabIndex = 28
        Me.Label9.Text = "mm/min"
        '
        'TextBox9
        '
        Me.TextBox9.Location = New System.Drawing.Point(221, 21)
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.Size = New System.Drawing.Size(39, 23)
        Me.TextBox9.TabIndex = 5
        Me.TextBox9.Text = "90"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(221, 3)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(52, 15)
        Me.Label8.TabIndex = 27
        Me.Label8.Text = "Feedrate"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Button24)
        Me.GroupBox3.Controls.Add(Me.TextBox8)
        Me.GroupBox3.Controls.Add(Me.Button22)
        Me.GroupBox3.Controls.Add(Me.Button23)
        Me.GroupBox3.Controls.Add(Me.TextBox7)
        Me.GroupBox3.Location = New System.Drawing.Point(247, 62)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(144, 114)
        Me.GroupBox3.TabIndex = 30
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Temperature"
        '
        'Button24
        '
        Me.Button24.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button24.Location = New System.Drawing.Point(51, 51)
        Me.Button24.Name = "Button24"
        Me.Button24.Size = New System.Drawing.Size(39, 23)
        Me.Button24.TabIndex = 21
        Me.Button24.Text = "Get"
        Me.Button24.UseVisualStyleBackColor = True
        '
        'TextBox8
        '
        Me.TextBox8.Location = New System.Drawing.Point(6, 51)
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Size = New System.Drawing.Size(39, 23)
        Me.TextBox8.TabIndex = 20
        Me.TextBox8.Text = "0"
        '
        'Button22
        '
        Me.Button22.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button22.Location = New System.Drawing.Point(97, 22)
        Me.Button22.Name = "Button22"
        Me.Button22.Size = New System.Drawing.Size(39, 23)
        Me.Button22.TabIndex = 19
        Me.Button22.Text = "Wait"
        Me.Button22.UseVisualStyleBackColor = True
        '
        'Button23
        '
        Me.Button23.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button23.Location = New System.Drawing.Point(51, 22)
        Me.Button23.Name = "Button23"
        Me.Button23.Size = New System.Drawing.Size(39, 23)
        Me.Button23.TabIndex = 18
        Me.Button23.Text = "Set"
        Me.Button23.UseVisualStyleBackColor = True
        '
        'TextBox7
        '
        Me.TextBox7.Location = New System.Drawing.Point(6, 22)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New System.Drawing.Size(39, 23)
        Me.TextBox7.TabIndex = 17
        Me.TextBox7.Text = "0"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CheckBox2)
        Me.GroupBox1.Controls.Add(Me.Button4)
        Me.GroupBox1.Controls.Add(Me.Button5)
        Me.GroupBox1.Controls.Add(Me.Button6)
        Me.GroupBox1.Controls.Add(Me.Button17)
        Me.GroupBox1.Controls.Add(Me.Button9)
        Me.GroupBox1.Controls.Add(Me.Button8)
        Me.GroupBox1.Controls.Add(Me.Button7)
        Me.GroupBox1.Controls.Add(Me.Button15)
        Me.GroupBox1.Controls.Add(Me.Button12)
        Me.GroupBox1.Controls.Add(Me.Button16)
        Me.GroupBox1.Controls.Add(Me.Button11)
        Me.GroupBox1.Controls.Add(Me.Button13)
        Me.GroupBox1.Controls.Add(Me.Button10)
        Me.GroupBox1.Controls.Add(Me.Button14)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 62)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(235, 166)
        Me.GroupBox1.TabIndex = 29
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Move"
        '
        'CheckBox2
        '
        Me.CheckBox2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CheckBox2.Location = New System.Drawing.Point(141, 80)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(85, 24)
        Me.CheckBox2.TabIndex = 15
        Me.CheckBox2.Text = "Extrude while move"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button4.Location = New System.Drawing.Point(6, 22)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(39, 23)
        Me.Button4.TabIndex = 6
        Me.Button4.Text = "XY"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button5.Location = New System.Drawing.Point(51, 22)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(39, 23)
        Me.Button5.TabIndex = 7
        Me.Button5.Text = "Y"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button6.Location = New System.Drawing.Point(96, 22)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(39, 23)
        Me.Button6.TabIndex = 8
        Me.Button6.Text = "XY"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button17
        '
        Me.Button17.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button17.Location = New System.Drawing.Point(6, 109)
        Me.Button17.Name = "Button17"
        Me.Button17.Size = New System.Drawing.Size(85, 23)
        Me.Button17.TabIndex = 16
        Me.Button17.Text = "Set home"
        Me.Button17.UseVisualStyleBackColor = True
        '
        'Button9
        '
        Me.Button9.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button9.Location = New System.Drawing.Point(6, 51)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(39, 23)
        Me.Button9.TabIndex = 9
        Me.Button9.Text = "X"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button8.Location = New System.Drawing.Point(51, 51)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(39, 23)
        Me.Button8.TabIndex = 10
        Me.Button8.Text = "Home"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button7.Location = New System.Drawing.Point(96, 51)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(39, 23)
        Me.Button7.TabIndex = 11
        Me.Button7.Text = "X"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button15
        '
        Me.Button15.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button15.Location = New System.Drawing.Point(187, 51)
        Me.Button15.Name = "Button15"
        Me.Button15.Size = New System.Drawing.Size(39, 23)
        Me.Button15.TabIndex = 21
        Me.Button15.Text = "E-"
        Me.Button15.UseVisualStyleBackColor = True
        '
        'Button12
        '
        Me.Button12.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button12.Location = New System.Drawing.Point(6, 80)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(39, 23)
        Me.Button12.TabIndex = 12
        Me.Button12.Text = "XY"
        Me.Button12.UseVisualStyleBackColor = True
        '
        'Button16
        '
        Me.Button16.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button16.Location = New System.Drawing.Point(187, 22)
        Me.Button16.Name = "Button16"
        Me.Button16.Size = New System.Drawing.Size(39, 23)
        Me.Button16.TabIndex = 20
        Me.Button16.Text = "E+"
        Me.Button16.UseVisualStyleBackColor = True
        '
        'Button11
        '
        Me.Button11.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button11.Location = New System.Drawing.Point(51, 80)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(39, 23)
        Me.Button11.TabIndex = 13
        Me.Button11.Text = "Y"
        Me.Button11.UseVisualStyleBackColor = True
        '
        'Button13
        '
        Me.Button13.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button13.Location = New System.Drawing.Point(141, 51)
        Me.Button13.Name = "Button13"
        Me.Button13.Size = New System.Drawing.Size(39, 23)
        Me.Button13.TabIndex = 19
        Me.Button13.Text = "Z-"
        Me.Button13.UseVisualStyleBackColor = True
        '
        'Button10
        '
        Me.Button10.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button10.Location = New System.Drawing.Point(96, 80)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(39, 23)
        Me.Button10.TabIndex = 14
        Me.Button10.Text = "XY"
        Me.Button10.UseVisualStyleBackColor = True
        '
        'Button14
        '
        Me.Button14.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button14.Location = New System.Drawing.Point(141, 22)
        Me.Button14.Name = "Button14"
        Me.Button14.Size = New System.Drawing.Size(39, 23)
        Me.Button14.TabIndex = 18
        Me.Button14.Text = "Z+"
        Me.Button14.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(186, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 15)
        Me.Label5.TabIndex = 26
        Me.Label5.Text = "mm"
        '
        'TextBox6
        '
        Me.TextBox6.Location = New System.Drawing.Point(141, 21)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(39, 23)
        Me.TextBox6.TabIndex = 4
        Me.TextBox6.Text = "0"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(141, 3)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 15)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "E step"
        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(96, 21)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(39, 23)
        Me.TextBox5.TabIndex = 3
        Me.TextBox5.Text = "0"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(96, 3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 15)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "Z step"
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(51, 21)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(39, 23)
        Me.TextBox4.TabIndex = 2
        Me.TextBox4.Text = "0"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(51, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 15)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "Y step"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(6, 21)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(39, 23)
        Me.TextBox3.TabIndex = 1
        Me.TextBox3.Text = "0"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 15)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "X step"
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(102, 13)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(210, 23)
        Me.ComboBox1.TabIndex = 9
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(803, 382)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.MaximumSize = New System.Drawing.Size(819, 421)
        Me.MinimumSize = New System.Drawing.Size(819, 421)
        Me.Name = "Form1"
        Me.Text = "Mini3DPrinter"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Button4 As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents TextBox6 As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Button10 As Button
    Friend WithEvents Button11 As Button
    Friend WithEvents Button12 As Button
    Friend WithEvents Button7 As Button
    Friend WithEvents Button8 As Button
    Friend WithEvents Button9 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Button13 As Button
    Friend WithEvents Button14 As Button
    Friend WithEvents Button17 As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Button15 As Button
    Friend WithEvents Button16 As Button
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Button22 As Button
    Friend WithEvents Button23 As Button
    Friend WithEvents TextBox7 As TextBox
    Friend WithEvents Button24 As Button
    Friend WithEvents TextBox8 As TextBox
    Friend WithEvents TextBox9 As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents CheckBox2 As CheckBox
    Friend WithEvents ComboBox1 As ComboBox
End Class
