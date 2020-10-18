Imports System.Threading

Public Class Form1
    Dim isPlaying As Boolean = False
    Dim SongPlaying As String = ""

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Play_Pause_btn.Click

        If isPlaying = False Then
            Play_Pause_btn.Text = "Pause"
            TextBox1.Text = "Playing " + SongPlaying
            isPlaying = True

        ElseIf isPlaying = True Then
            Play_Pause_btn.Text = "Play"
            TextBox1.Text = "Paused " + SongPlaying
            isPlaying = False
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Stop_File_btn.Click
        TextBox1.Text = "Song Stoped"
        Play_Pause_btn.Text = "Play"
        'ListBox1.ClearSelected()
        ' SongPlaying = ""
        isPlaying = False
    End Sub



    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ListBox1.Items.Add("Song_1")
        ListBox1.Items.Add("Song_2")
        ListBox1.Items.Add("Song_3")
        ListBox1.Items.Add("Song_4")
        ListBox1.Items.Add("Song_5")
        ListBox1.Items.Add("Song_6")
        ListBox1.Items.Add("Song_7")
        ListBox1.Items.Add("Song_8")
        ListBox1.Items.Add("Song_9")
        ListBox1.Items.Add("Song_10")

        ' Get the list of available com ports and put them in the list box
        ComResultTextBox.Text = "Com port closed"
        For Each sp As String In My.Computer.Ports.SerialPortNames
            ComListBox.Items.Add(sp)
        Next
    End Sub

    Private Sub Connect_Click(sender As Object, e As EventArgs) Handles Connect.Click

        ' Connect to a selected serial port
        If SerialPort1.IsOpen = False Then
            ' a serial port in not already open
            If ComListBox.SelectedItem <> Nothing Then
                ' an item in the listbox has been selected
                SerialPort1.PortName = ComListBox.SelectedItem

                Try
                    'try to open the selected serial port
                    SerialPort1.Open()
                Catch
                    Debug.WriteLine("Failed to open serial port")
                End Try
                If SerialPort1.IsOpen Then
                    ' The serial port was opened
                    ComResultTextBox.Text = "Com port " + SerialPort1.PortName + " connected"
                Else
                    ' The serial port open failed
                    ComResultTextBox.Text = "Com port " + SerialPort1.PortName + " not connected"
                End If
            Else
                ComResultTextBox.Text = "Nothing selected"
            End If
        Else
            ' A com port is already open
            ComResultTextBox.Text = "Com port " + SerialPort1.PortName + " already connected"
        End If

    End Sub

    Private Sub Disconnect_Click(sender As Object, e As EventArgs) Handles Disconnect.Click
        ' Close the serial port if it is open
        If SerialPort1.IsOpen Then
            SerialPort1.Close()
            ComResultTextBox.Text = "Com port closed"
        End If
    End Sub

    'Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs)
    '    TextBox1.Text = ListBox1.SelectedItem.ToString()
    '    SongPlaying = ListBox1.SelectedItem.ToString()
    'End Sub



    Private Sub ListBox1_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        ' Try
        TextBox1.Text = ListBox1.SelectedItem.ToString() + " Selected"
        SongPlaying = ListBox1.SelectedItem.ToString()
        isPlaying = False
        Play_Pause_btn.Text = "Play"
        ' Catch
        'SongPlaying = "No Song Selected"
        ' End Try

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles USB_btn.Click

    End Sub
End Class
