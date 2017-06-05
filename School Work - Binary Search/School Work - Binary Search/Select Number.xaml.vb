Public Class Select_Number
    Public canceled As Boolean = True
    Public amount As ULong = 0
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        txtValue.Focus()
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub btnCancel_Click(sender As Object, e As RoutedEventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub btnOkay_Click(sender As Object, e As RoutedEventArgs) Handles btnOkay.Click
        If txtValue.Text = "" Then
            MsgBox("Please enter a number")
            Return
        End If
        canceled = False
        amount = Convert.ToInt64(txtValue.Text)
        Close()
    End Sub
    Private Sub txtValue_PreviewTextInput(sender As Object, e As TextCompositionEventArgs) Handles txtValue.PreviewTextInput
        If txtValue.Text = "" Then Return
        Try
            If Convert.ToInt64(txtValue.Text).ToString() <> txtValue.Text Then e.Handled = True
        Catch
            e.Handled = True
        End Try
    End Sub
End Class
