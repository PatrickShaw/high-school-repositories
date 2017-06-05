Public Class wndLogon
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles btnLogin.Click
        passwordEntered = txtPassword.Password
        usernameEntered = txtUsername.Text
        If IsAdmin() Or IsUser() Then
            Dim mainWindow As New Main_Window()
            mainWindow.Show()
            Close()
        Else
            MessageBox.Show("Incorrect password")
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles btnCancel.Click
        Close()
    End Sub
End Class
