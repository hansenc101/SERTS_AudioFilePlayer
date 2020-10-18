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
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.USB_btn = New System.Windows.Forms.Button()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.ComResultTextBox = New System.Windows.Forms.TextBox()
        Me.Disconnect = New System.Windows.Forms.Button()
        Me.Connect = New System.Windows.Forms.Button()
        Me.ComListBox = New System.Windows.Forms.ListBox()
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.SuspendLayout()
        '
        'Play_Pause_btn
        '
        Me.Play_Pause_btn.Location = New System.Drawing.Point(314, 285)
        Me.Play_Pause_btn.Margin = New System.Windows.Forms.Padding(4)
        Me.Play_Pause_btn.Name = "Play_Pause_btn"
        Me.Play_Pause_btn.Size = New System.Drawing.Size(100, 28)
        Me.Play_Pause_btn.TabIndex = 0
        Me.Play_Pause_btn.Text = "Play"
        Me.Play_Pause_btn.UseVisualStyleBackColor = True
        '
        'Stop_File_btn
        '
        Me.Stop_File_btn.Location = New System.Drawing.Point(460, 285)
        Me.Stop_File_btn.Margin = New System.Windows.Forms.Padding(4)
        Me.Stop_File_btn.Name = "Stop_File_btn"
        Me.Stop_File_btn.Size = New System.Drawing.Size(100, 28)
        Me.Stop_File_btn.TabIndex = 1
        Me.Stop_File_btn.Text = "Stop"
        Me.Stop_File_btn.UseVisualStyleBackColor = True
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 16
        Me.ListBox1.Location = New System.Drawing.Point(356, 82)
        Me.ListBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(159, 116)
        Me.ListBox1.TabIndex = 3
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(314, 224)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(244, 22)
        Me.TextBox1.TabIndex = 4
        Me.TextBox1.Text = "Select a Song"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(314, 13)
        Me.TextBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(244, 22)
        Me.TextBox2.TabIndex = 5
        Me.TextBox2.Text = "WAV Player"
        Me.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'USB_btn
        '
        Me.USB_btn.Location = New System.Drawing.Point(381, 46)
        Me.USB_btn.Margin = New System.Windows.Forms.Padding(4)
        Me.USB_btn.Name = "USB_btn"
        Me.USB_btn.Size = New System.Drawing.Size(100, 28)
        Me.USB_btn.TabIndex = 6
        Me.USB_btn.Text = "Load USB"
        Me.USB_btn.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(314, 347)
        Me.ProgressBar1.Margin = New System.Windows.Forms.Padding(4)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(245, 28)
        Me.ProgressBar1.TabIndex = 7
        '
        'ComResultTextBox
        '
        Me.ComResultTextBox.Location = New System.Drawing.Point(11, 130)
        Me.ComResultTextBox.Name = "ComResultTextBox"
        Me.ComResultTextBox.Size = New System.Drawing.Size(221, 22)
        Me.ComResultTextBox.TabIndex = 11
        Me.ComResultTextBox.Text = "ComResultTextBox"
        '
        'Disconnect
        '
        Me.Disconnect.Location = New System.Drawing.Point(93, 102)
        Me.Disconnect.Name = "Disconnect"
        Me.Disconnect.Size = New System.Drawing.Size(94, 23)
        Me.Disconnect.TabIndex = 10
        Me.Disconnect.Text = "Disconnect"
        Me.Disconnect.UseVisualStyleBackColor = True
        '
        'Connect
        '
        Me.Connect.Location = New System.Drawing.Point(12, 102)
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
        Me.ComListBox.Name = "ComListBox"
        Me.ComListBox.Size = New System.Drawing.Size(120, 84)
        Me.ComListBox.TabIndex = 8
        '
        'SerialPort1
        '
        Me.SerialPort1.PortName = "COM4"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(613, 407)
        Me.Controls.Add(Me.ComResultTextBox)
        Me.Controls.Add(Me.Disconnect)
        Me.Controls.Add(Me.Connect)
        Me.Controls.Add(Me.ComListBox)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.USB_btn)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.Stop_File_btn)
        Me.Controls.Add(Me.Play_Pause_btn)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Play_Pause_btn As Button
    Friend WithEvents Stop_File_btn As Button
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents USB_btn As Button
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents ComResultTextBox As TextBox
    Friend WithEvents Disconnect As Button
    Friend WithEvents Connect As Button
    Friend WithEvents ComListBox As ListBox
    Friend WithEvents SerialPort1 As IO.Ports.SerialPort
End Class
