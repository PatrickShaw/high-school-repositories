Imports System.IO
Public Class frmHiScores
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
    End Sub
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        AddEntry()
    End Sub

    Private Sub frmHiScores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim HiScFile As StreamReader = File.OpenText("HiScores.txt")
        Do While HiScFile.Peek <> -1
            lstScores.Items.Add(HiScFile.ReadLine())
        Loop
        HiScFile.Close()
    End Sub
    Private Sub btnRemoveItm_Click(sender As Object, e As EventArgs) Handles btnRemoveItm.Click
        Try
            lstScores.Items.RemoveAt(lstScores.SelectedIndex)
        Catch
        End Try
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Try
            lstScores.Items.RemoveAt(lstScores.SelectedIndex)
            AddEntry()
        Catch
            MsgBox("Please select a score entry to edit.")
        End Try
    End Sub

End Class
