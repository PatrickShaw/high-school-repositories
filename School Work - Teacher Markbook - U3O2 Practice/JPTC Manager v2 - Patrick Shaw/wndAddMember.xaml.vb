Public Class wndAddMember
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        txtFirstName.Focus()
    End Sub
    Private Sub IsLetter(sender As Object, e As TextCompositionEventArgs) Handles txtFirstName.PreviewTextInput, txtMiddleName.PreviewTextInput, txtLastName.PreviewTextInput
        For Each letter In e.Text
            If Char.IsLetter(letter) = False And letter <> "'" Then e.Handled = True
        Next
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As RoutedEventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub btnOkay_Click(ByVal sender As Object, ByVal e As RoutedEventArgs) Handles btnOkay.Click
        MessageBox.Show("Adding and removing students have been disabled in this version.")
        Return
        If txtFirstName.Text = "" Then
            lblError.Content = "A first name is required to register a " + cmbMemberType.Text
            Return
        End If
        If txtLastName.Text = "" Then
            lblError.Content = "A last name is required to register a " + cmbMemberType.Text
            Return
        End If
        Dim member As Person = New Person()
        Select Case cmbMemberType.Text
            Case "Student"
                member.memberType = MemberType.student
            Case "Instructor"
                member.memberType = MemberType.instructor
        End Select
        member.firstName = txtFirstName.Text
        member.middleName = txtMiddleName.Text
        member.lastName = txtLastName.Text
        member.ID = lowestMemberIDAvailable
        AddMember(member)
        Close()
    End Sub
End Class
