Public Class RenameBox
    Inherits Window
    ' This is for renaming tab items
    Dim originalName As String
    Public Sub New(ByVal originalNameT As String)
        InitializeComponent()
        ' Fill the textbox with the original name
        originalName = originalNameT
        txtInput.Text = originalNameT
        Title = "Rename: " + originalNameT
    End Sub
    ' If you press okay the tab will change it's header to whatever is in the textbox
    Private Sub btnOkay_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        If (txtInput.Text = "") Then txtInput.Text = originalName
        Close()
    End Sub
    ' If you press cancel nothing will change
    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        txtInput.Text = originalName
        Close()
    End Sub
End Class
