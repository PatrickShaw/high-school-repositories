Public Class Form1
    Dim isFilled01 As Boolean = False
    Dim isFilled02 As Boolean = False
    Dim starCount02 As Integer = 0
    Private Sub btnGo01_Click(sender As Object, e As EventArgs) Handles btnGo01.Click
        If (isFilled01 = True) Then
            Return
        End If
        lstPattern01.Items.Add("*")
        lstPattern01.Items.Add("**")
        lstPattern01.Items.Add("***")
        lstPattern01.Items.Add("****")
        lstPattern01.Items.Add("*****")
        lblStarCount01.Text = "Star Count: 15"
        isFilled01 = True

    End Sub
    Private Sub btnGo02_Click(sender As Object, e As EventArgs) Handles btnGo02.Click
        If (isFilled02 = True) Then
            Return
        End If
        Dim stringTemp As String = ""
        For i As Integer = 1 To 5
            stringTemp += "*"
            starCount02 += i
            lstPattern02.Items.Add(stringTemp)
        Next

        lblStarCount02.Text = "Star Count: " & starCount02.ToString
        isFilled02 = True
    End Sub

    Private Sub btnClearAll_Click(sender As Object, e As EventArgs) Handles btnClearAll.Click
        lstPattern01.Items.Clear()
        lstPattern02.Items.Clear()
        starCount02 = 0
        isFilled01 = False
        isFilled02 = False
        lblStarCount02.Text = "Star Count: " & starCount02.ToString
        lblStarCount01.Text = "Star Count: 0"
    End Sub

    Private Sub btnQuit_Click(sender As Object, e As EventArgs) Handles btnQuit.Click
        End
    End Sub
End Class
