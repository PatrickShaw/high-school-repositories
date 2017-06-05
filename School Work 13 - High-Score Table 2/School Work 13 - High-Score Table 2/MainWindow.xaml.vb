Imports System.IO
Class MainWindow
    Dim Score As String
    Dim Entry As String
    Private Sub btnQuit_Click(sender As Object, e As EventArgs) Handles btnQuit.Click
        Dim HiScFile2 As StreamWriter = File.CreateText("HiScores.txt")
        For Each Name As Object In lstScores.Items
            HiScFile2.WriteLine(Name)
        Next
        HiScFile2.Close()
        End
    End Sub
    Private Sub AddEntry()
        If (txtName.Text.Length = 0) Then
            MsgBox("Please enter a name.")
            Return
        End If
        If Val(txtScore.Text) < 0 Then
            MsgBox("Scores must be positive.")
            Return
        End If
        If Val(txtScore.Text) = 0 Then
            MsgBox("Scores of 0 are not allowed.")
            Return
        End If
        Try
            Dim scoreTemp As Integer = Val(txtScore.Text)
            Select Case (scoreTemp)
                Case 1 To 9
                    txtScore.Text = "000000" & scoreTemp
                Case 11 To 99
                    txtScore.Text = "00000" & scoreTemp
                Case 101 To 999
                    txtScore.Text = "0000" & scoreTemp
                Case 1001 To 9999
                    txtScore.Text = "000" & scoreTemp
                Case 10001 To 99999
                    txtScore.Text = "00" & scoreTemp
                Case 100001 To 999999
                    txtScore.Text = "0" & scoreTemp
                Case Else
                    txtScore.Text = scoreTemp
            End Select
            Entry = txtScore.Text + " , " + txtName.Text
            lstScores.Items.Add(Entry)
        Catch
        End Try
    End Sub
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        AddEntry()
        SortList()
    End Sub

    Private Sub frmHiScores_Load(sender As Object, e As EventArgs) Handles MyBase.Loaded
        If File.Exists("HiScores.txt") = False Then
            File.WriteAllText("HiScores.txt", "")
        End If
        Dim HiScFile As StreamReader = File.OpenText("HiScores.txt")

        Do While HiScFile.Peek <> -1
            lstScores.Items.Add(HiScFile.ReadLine())
        Loop
        HiScFile.Close()
    End Sub
    Private Sub btnRemoveItem_Click(sender As Object, e As EventArgs) Handles btnRemoveItem.Click
        Try
            lstScores.Items.RemoveAt(lstScores.SelectedIndex)
        Catch
        End Try
        SortList()
    End Sub
    Private Sub SortList()
        Dim stringTempArray As List(Of String) = New List(Of String)
        For Each thingy In lstScores.Items
            stringTempArray.Add(thingy)
        Next
        stringTempArray.Sort()
        stringTempArray.Reverse()
        lstScores.Items.Clear()
        For Each stringT In stringTempArray
            lstScores.Items.Add(stringT)
        Next
        lstScores.Items.Refresh()
    End Sub
    Private Sub AddToLog(stringT As String)

            string[] dtbElementNotes = File.ReadAllLines(@".\ElementNotes.txt");
            int eleNo = 0;
             for(int i = 0 ; i < dtbElementNotes.Count()-1; i++)
             {
Begin:
                 if (dtbElementNotes[i] == "_") { eleNo += 1; i += 1; goto Begin; } 
             elements[eleNo].notes += dtbElementNotes[i]; 
             }
    End Sub
    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If (txtName.Text.Length = 0) Then
            MsgBox("Please enter a name.")
            Return
        End If
        If Val(txtScore.Text) < 0 Then
            MsgBox("Scores must be positive.")
            Return
        End If
        If Val(txtScore.Text) = 0 Then
            MsgBox("Scores of 0 are not allowed.")
            Return
        End If
        Try
            lstScores.Items.RemoveAt(lstScores.SelectedIndex)
            AddEntry()
        Catch
            MsgBox("Please select a score entry to replace.")
        End Try
        SortList()
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
                    If (File.Exists(@".\ElementNotes.txt")=True) 
Then
            Using writer As StreamWriter = New StreamWriter("myfile.txt")
                writer.WriteLine("New text file created...")
                writer.WriteLine("_")
                    }
            End Using

        End If
        ' Add any initialization after the InitializeComponent() call.

    End Sub
End Class
