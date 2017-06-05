Public Class Form1
    Private Sub btnQuit_Click(sender As Object, e As EventArgs) Handles btnQuit.Click
        End
    End Sub

 

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearAll()
    End Sub
    Private Sub ClearAll()
        lstM3No.Items.Clear()
        lstEvenNo.Items.Clear()
        lstSqrNo.Items.Clear()
    End Sub

    Private Sub txtTimesTable_TextChanged(sender As Object, e As EventArgs) Handles txtTimesTable.TextChanged
        Try
            ClearAll()
            Dim numberTemp As Integer = 1
            For i As Integer = 0 To 11
Begin:
                'Check multiple of 3'
                If ((numberTemp Mod Val(txtTimesTable.Text)) <> 0) Then
                    numberTemp += 1
                    GoTo Begin
                End If
                lstM3No.Items.Add(numberTemp.ToString())


                'Check Even numbers'
                If (CInt((numberTemp / 2)) = (CDbl(numberTemp) / 2.0F)) Then
                    lstEvenNo.Items.Add(numberTemp.ToString())
                End If

                'Check if Square Number'
                If (CInt(Math.Sqrt(numberTemp)) = Math.Sqrt(CDbl(numberTemp))) Then
                    lstSqrNo.Items.Add(numberTemp.ToString())
                End If
                numberTemp += 1
            Next
        Catch
        End Try
    End Sub
    'Make This in the least number of lines'
End Class
