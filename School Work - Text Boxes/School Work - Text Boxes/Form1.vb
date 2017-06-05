Public Class Form1

    Private Sub btnCalculate_Click(sender As Object, e As EventArgs) Handles btnCalculate.Click
        If (Val(txtTest1.Text) < 0 Or Val(txtTest2.Text) > 100) Then
            MsgBox("Please enter a number between 0 and 100.")
            Return
        End If
        If IsNumeric(txtTest1.Text) = False And IsNumeric(txtTest2.Text) = False Then
            MsgBox("Please enter valid numbers for the test scores.")
            Return
        End If
        If cmbName.Text = "" Then
            MsgBox("Please enter a name.")
        End If
        Dim mark As Double
        mark = Format(Val(txtTest1.Text) + Val(txtTest2.Text), "Fixed")
        lblTotal.Text = mark
        If mark < 40 Then
            lblTotal.ForeColor = Color.Red
            lblAverage.ForeColor = Color.Red
        Else
            lblTotal.ForeColor = Color.Black
            lblAverage.ForeColor = Color.Black
        End If
        lblAverage.Text = Format((Val(txtTest1.Text) + Val(txtTest2.Text)) / 2, "Fixed")
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        cmbName.Text = ""
        txtTest1.Text = ""
    End Sub

    Private Sub btnQuit_Click(sender As Object, e As EventArgs) Handles btnQuit.Click
        End
    End Sub

End Class
