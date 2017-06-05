Public Class frmPassword
    Dim Tries As Integer
    Private Sub btnOkay_Click(sender As Object, e As EventArgs) Handles btnOkay.Click
        If (txtPassword.Text = "Password") Then
            MsgBox("Welcome!")
            Me.Hide()
            frmAcessed.Show()
        Else
            Tries += 1
            If (Tries >= 3) Then
                MsgBox("You failed. Goodbye")
                End
            End If
            MsgBox("Try again.")
        End If
    End Sub
End Class
