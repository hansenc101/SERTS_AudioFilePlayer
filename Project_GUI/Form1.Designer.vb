<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Play_Pause_btn = New System.Windows.Forms.Button()
        Me.Stop_File_btn = New System.Windows.Forms.Button()
        Me.File_List = New System.Windows.Forms.ListBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.USB_btn = New System.Windows.Forms.Button()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.ComResultTextBox = New System.Windows.Forms.TextBox()
        Me.Disconnect = New System.Windows.Forms.Button()
        Me.Connect = New System.Windows.Forms.Button()
        Me.ComListBox = New System.Windows.Forms.ListBox()
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.Send_File = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Play_Pause_btn
        '
        Me.Play_Pause_btn.Location = New System.Drawing.Point(315, 298)
        Me.Play_Pause_btn.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Play_Pause_btn.Name = "Play_Pause_btn"
        Me.Play_Pause_btn.Size = New System.Drawing.Size(100, 28)
        Me.Play_Pause_btn.TabIndex = 0
        Me.Play_Pause_btn.Text = "Play"
        Me.Play_Pause_btn.UseVisualStyleBackColor = True
        '
        'Stop_File_btn
        '
        Me.Stop_File_btn.Location = New System.Drawing.Point(460, 298)
        Me.Stop_File_btn.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Stop_File_btn.Name = "Stop_File_btn"
        Me.Stop_File_btn.Size = New System.Drawing.Size(100, 28)
        Me.Stop_File_btn.TabIndex = 1
        Me.Stop_File_btn.Text = "Stop"
        Me.Stop_File_btn.UseVisualStyleBackColor = True
        '
        'File_List
        '
        Me.File_List.FormattingEnabled = True
        Me.File_List.ItemHeight = 16
        Me.File_List.Location = New System.Drawing.Point(356, 82)
        Me.File_List.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.File_List.Name = "File_List"
        Me.File_List.Size = New System.Drawing.Size(159, 116)
        Me.File_List.TabIndex = 3
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(315, 224)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(244, 22)
        Me.TextBox1.TabIndex = 4
        Me.TextBox1.Text = "Select a Song"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(315, 14)
        Me.TextBox2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(244, 22)
        Me.TextBox2.TabIndex = 5
        Me.TextBox2.Text = "WAV Player"
        Me.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'USB_btn
        '
        Me.USB_btn.Location = New System.Drawing.Point(381, 46)
        Me.USB_btn.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.USB_btn.Name = "USB_btn"
        Me.USB_btn.Size = New System.Drawing.Size(100, 28)
        Me.USB_btn.TabIndex = 6
        Me.USB_btn.Text = "Load USB"
        Me.USB_btn.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(315, 347)
        Me.ProgressBar1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(245, 28)
        Me.ProgressBar1.TabIndex = 7
        '
        'ComResultTextBox
        '
        Me.ComResultTextBox.Location = New System.Drawing.Point(11, 130)
        Me.ComResultTextBox.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ComResultTextBox.Name = "ComResultTextBox"
        Me.ComResultTextBox.Size = New System.Drawing.Size(221, 22)
        Me.ComResultTextBox.TabIndex = 11
        Me.ComResultTextBox.Text = "ComResultTextBox"
        '
        'Disconnect
        '
        Me.Disconnect.Location = New System.Drawing.Point(93, 102)
        Me.Disconnect.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Disconnect.Name = "Disconnect"
        Me.Disconnect.Size = New System.Drawing.Size(93, 23)
        Me.Disconnect.TabIndex = 10
        Me.Disconnect.Text = "Disconnect"
        Me.Disconnect.UseVisualStyleBackColor = True
        '
        'Connect
        '
        Me.Connect.Location = New System.Drawing.Point(12, 102)
        Me.Connect.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Connect.Name = "Connect"
        Me.Connect.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Connect.Size = New System.Drawing.Size(75, 23)
        Me.Connect.TabIndex = 9
        Me.Connect.Text = "Connect"
        Me.Connect.UseVisualStyleBackColor = True
        '
        'ComListBox
        '
        Me.ComListBox.FormattingEnabled = True
        Me.ComListBox.ItemHeight = 16
        Me.ComListBox.Location = New System.Drawing.Point(12, 12)
        Me.ComListBox.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ComListBox.Name = "ComListBox"
        Me.ComListBox.Size = New System.Drawing.Size(120, 84)
        Me.ComListBox.TabIndex = 8
        '
        'SerialPort1
        '
        Me.SerialPort1.PortName = "COM10"
        '
        'Send_File
        '
        Me.Send_File.Location = New System.Drawing.Point(356, 252)
        Me.Send_File.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Send_File.Name = "Send_File"
        Me.Send_File.Size = New System.Drawing.Size(177, 31)
        Me.Send_File.TabIndex = 12
        Me.Send_File.Text = "Select Song"
        Me.Send_File.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(613, 407)
        Me.Controls.Add(Me.Send_File)
        Me.Controls.Add(Me.ComResultTextBox)
        Me.Controls.Add(Me.Disconnect)
        Me.Controls.Add(Me.Connect)
        Me.Controls.Add(Me.ComListBox)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.USB_btn)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.File_List)
        Me.Controls.Add(Me.Stop_File_btn)
        Me.Controls.Add(Me.Play_Pause_btn)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Play_Pause_btn As Button
    Friend WithEvents Stop_File_btn As Button
    Friend WithEvents File_List As ListBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents USB_btn As Button
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents ComResultTextBox As TextBox
    Friend WithEvents Disconnect As Button
    Friend WithEvents Connect As Button
    Friend WithEvents ComListBox As ListBox
    Friend WithEvents SerialPort1 As IO.Ports.SerialPort
    Friend WithEvents Send_File As Button
End Class
