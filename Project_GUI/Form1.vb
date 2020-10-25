Imports System.Threading

Public Class Form1
    Dim isPlaying As Boolean = False
    Dim SongPlaying As String = ""

    Delegate Sub ListBoxDelegate(ByVal command As Integer, ByVal myStr As String)
    Dim ListBoxDel As New ListBoxDelegate(AddressOf ListBoxDelMethod)

    Dim PC_Comm As New Thread(AddressOf PC_Comm_method)
    Dim ShowFiles As Integer = 1
    Dim StartFileList As Integer = 2
    Dim EndFileList As Integer = 3

    Dim ShowFilesStr As String = "1"
    Dim StartFileListStr As String = "2"
    Dim EndFileListStr As String = "3"

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Play_Pause_btn.Click

        If isPlaying = False Then
            Play_Pause_btn.Text = "Pause"
            TextBox1.Text = "Playing " + SongPlaying
            isPlaying = True
            Try
                SerialPort1.Open()
            Catch
                Console.WriteLine("Failed to open serial port")
            End Try

            If SerialPort1.IsOpen Then
                SerialPort1.Write("5", 0, 1)
            End If

        ElseIf isPlaying = True Then
            Play_Pause_btn.Text = "Play"
            TextBox1.Text = "Paused " + SongPlaying
            isPlaying = False

            Try
                SerialPort1.Open()
            Catch
                Console.WriteLine("Failed to open serial port")
            End Try

            If SerialPort1.IsOpen Then
                SerialPort1.Write("6", 0, 1)
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Stop_File_btn.Click
        TextBox1.Text = "Song Stoped"
        Play_Pause_btn.Text = "Play"
        'ListBox1.ClearSelected()
        ' SongPlaying = ""
        isPlaying = False

        Try
            SerialPort1.Open()
        Catch
            Console.WriteLine("Failed to open serial port")
        End Try

        If SerialPort1.IsOpen Then
            SerialPort1.Write("7", 0, 1)
        End If
    End Sub



    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Try to open the seial port 
        Try
            SerialPort1.Open()
        Catch
            Debug.WriteLine("Failed to open serial port")
        End Try

        ' Make this a background thread so it automatically
        ' aborts when the main program stops.
        PC_Comm.IsBackground = True
        ' Set the thread priority to lowest
        PC_Comm.Priority = ThreadPriority.Lowest
        ' Start the thread
        PC_Comm.Start()

        '=================old code ======================================
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



    Private Sub ListBox1_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles File_List.SelectedIndexChanged
        ' Try
        TextBox1.Text = File_List.SelectedItem.ToString() + " Selected"
        SongPlaying = File_List.SelectedItem.ToString()
        isPlaying = False
        Play_Pause_btn.Text = "Play"
        ' Catch
        'SongPlaying = "No Song Selected"
        ' End Try

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles USB_btn.Click
        If SerialPort1.IsOpen Then
            SerialPort1.Write("1", 0, 1)
        End If
    End Sub

    Private Sub Send_File_Click(sender As Object, e As EventArgs) Handles Send_File.Click
        Dim b(1) As Byte
        b(0) = 0
        ' A value of negative one (-1) is returned if no item is selected
        If Not (File_List.SelectedIndex = -1) Then
            SerialPort1.Write("4", 0, 1)
            SerialPort1.Write(File_List.SelectedItem)
            SerialPort1.Write(b, 0, 1) ' New Line character at the end of the string
        End If

    End Sub

    ' ============new code=============================================
    ' Delegate function that accesses the ListBox object
    ' command = 2 - clear the contents of the ListBox
    ' command = 3 - add the string to the ListBox
    Public Sub ListBoxDelMethod(ByVal command As Integer, ByVal myStr As String)

        If command = StartFileList Then
            File_List.Items.Clear()
        ElseIf command = EndFileList Then
            File_List.Items.Add(myStr)
        End If
    End Sub
    ' Thread that monitors the receive items on the serial port
    Private Sub PC_Comm_method()
        Dim str As String
        While 1
            If SerialPort1.IsOpen Then
                Try
                    str = SerialPort1.ReadLine() ' Wait for start string
                Catch ex As Exception
                End Try

                'String.Compare return values:
                ' Less than zero: strA precedes strB in the sort order.
                'Zero" strA occurs in the same position as strB in the sort order.
                'Greater than zero: strA follows strB in the sort order.
                If Not String.Compare(str, StartFileListStr) Then
                    ' Received a StartFileList response
                    ' clear the list
                    ' Use the delegate to access the ListBox
                    File_List.Invoke(ListBoxDel, StartFileList, "")
                    ' get next string
                    Try
                        str = SerialPort1.ReadLine() ' read file name
                    Catch ex As Exception
                    End Try
                    While String.Compare(str, EndFileListStr)
                        ' The read string is a file name and not the EndFileList
                        File_List.Invoke(ListBoxDel, EndFileList, str)
                        Try
                            str = SerialPort1.ReadLine() ' read file name
                        Catch ex As Exception
                        End Try
                    End While
                    ' While loop ends when a 3 is received
                End If
            Else
                Threading.Thread.Sleep(500)
            End If
        End While
    End Sub
End Class
