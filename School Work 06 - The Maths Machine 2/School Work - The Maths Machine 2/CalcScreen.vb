Public Class CalcScreen

    Private Sub btnQuit_Click(sender As Object, e As EventArgs) Handles btnQuit.Click
        End
    End Sub

    Private Sub btnDoStuff_Click(sender As Object, e As EventArgs)
        lblResult1.Text = Format(Val(txtInput1.Text) + Val(txtInput2.Text), "Fixed")
        lblResult2.Text = Format(Val(txtInput1.Text) * Val(txtInput2.Text), "Fixed")
        lblResult3.Text = Format(Val(txtInput1.Text) - Val(txtInput2.Text), "Fixed")
        lblResult4.Text = Format(Val(txtInput1.Text) / Val(txtInput2.Text), "Fixed")
    End Sub

    Private Sub CalcScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblResult1.Text = ""
        lblResult2.Text = ""
        lblResult3.Text = ""
        lblResult4.Text = ""
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Hide()
        TitleScreen.Show()
    End Sub

    Private Sub bClear_Click(sender As Object, e As EventArgs) Handles bClear.Click
        lblResult1.Text = ""
        lblResult2.Text = ""
        lblResult3.Text = ""
        lblResult4.Text = ""
        txtInput1.Text = ""
        txtInput2.Text = ""
    End Sub

    Private Sub txtInput1_TextChanged(sender As Object, e As EventArgs) Handles txtInput1.TextChanged
        CalcValues()
    End Sub
    Private Sub CalcValues()
        Try
            lblResult1.Text = Format(Val(txtInput1.Text) + Val(txtInput2.Text), "Fixed")
            lblResult2.Text = Format(Val(txtInput1.Text) * Val(txtInput2.Text), "Fixed")
            lblResult3.Text = Format(Val(txtInput1.Text) - Val(txtInput2.Text), "Fixed")
            lblResult4.Text = Format(Val(txtInput1.Text) / Val(txtInput2.Text), "Fixed")
        Catch
        End Try
    End Sub

    Private Sub txtInput2_TextChanged(sender As Object, e As EventArgs) Handles txtInput2.TextChanged
        CalcValues()
    End Sub
End Class
