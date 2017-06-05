Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub bPlus_Click(sender As Object, e As EventArgs) Handles bPlus.Click
        lblAnswer.Text = "= " & Val(txtValue1.Text) + Val(txtValue2.Text)
    End Sub

    Private Sub b_Click(sender As Object, e As EventArgs) Handles b.Click

        lblAnswer.Text = "= " & Val(txtValue1.Text) - Val(txtValue2.Text)
    End Sub

    Private Sub bTimes_Click(sender As Object, e As EventArgs) Handles bTimes.Click

        lblAnswer.Text = "= " & Val(txtValue1.Text) * Val(txtValue2.Text)
    End Sub

    Private Sub bDivded_Click(sender As Object, e As EventArgs) Handles bDivded.Click

        lblAnswer.Text = "= " & Val(txtValue1.Text) / Val(txtValue2.Text)
    End Sub

    Private Sub bClear_Click(sender As Object, e As EventArgs) Handles bClear.Click
        lblAnswer.Text = "= "
        txtValue1.Text = ""
        txtValue2.Text = ""
    End Sub

    Private Sub bQuit_Click(sender As Object, e As EventArgs) Handles bQuit.Click
        End
    End Sub

    Private Sub bQuestion_Click(sender As Object, e As EventArgs) Handles bQuestion.Click
        MsgBox("Instructions" & Chr(10) & "1. Type in values in the text box" & Chr(10) & "2. Click one of the opperators")
    End Sub
End Class
