Imports System.IO
Class MainWindow
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub btnCancel(sender As Object, e As RoutedEventArgs)
        End
    End Sub

    Private Sub btnOkay_Click(sender As Object, e As RoutedEventArgs) Handles btnOkay.Click
        If False = (txtPhone.Text.Count = 8 Or txtPhone.Text.Count = 10) Then
            MsgBox("Phone numbers are 8 or 10 numbers long. Please enter 8 or 10 numbers.")
            Return
        End If
        If txtName.Text = "" Then
            MsgBox("Name missing.")
            Return
        End If
        If dtpDOB.SelectedDate Is Nothing Then
            MsgBox("DOB missing.")
            Return
        End If
        If File.Exists(".\details.dtb") = False Then
            Using fs As FileStream = File.Create(".\details.dtb")
            End Using
        End If
        File.AppendAllText(".\details.dtb", txtName.Text + "," + txtPhone.Text + "," + dtpDOB.SelectedDate.ToString() + Environment.NewLine)
        End
    End Sub

    Private Sub txtPhone_PreviewTextInput(sender As Object, e As TextCompositionEventArgs) Handles txtPhone.PreviewTextInput
        If IsNumeric(e.Text) = False Then e.Handled = True
        For Each l In e.Text
            If Char.IsWhiteSpace(l) Then e.Handled = True
        Next
    End Sub

    Private Sub txtName_PreviewTextInput(sender As Object, e As TextCompositionEventArgs) Handles txtName.PreviewTextInput
        If IsNumeric(e.Text) Then e.Handled = True
    End Sub

    Private Sub dtpDOB_SelectedDateChanged(sender As Object, e As SelectionChangedEventArgs) Handles dtpDOB.SelectedDateChanged

    End Sub
End Class
