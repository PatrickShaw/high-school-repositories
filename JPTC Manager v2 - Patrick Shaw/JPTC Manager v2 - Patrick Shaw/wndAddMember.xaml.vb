Public Class wndAddMember
    Dim mode As Mode = JPTC_Manager_v2___Patrick_Shaw.Mode.create
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        txtFirstName.Focus()
    End Sub
    Dim IDT As Long = -1
    Sub New(member As Student)

        ' This call is required by the designer.
        InitializeComponent()
        Title = "Edit student"
        ' Add any initialization after the InitializeComponent() call.
        lblTitle.Content = "Edit student form"
        txtFirstName.Text = member.firstName
        txtMiddleName.Text = member.middleName
        txtLastName.Text = member.lastName
        txtContact.Text = member.contact
        txtContactAlt.Text = member.contactAlt
        txtParentName.Text = member.parentName
        txtPostCode.Text = member.postCode
        txtSuburb.Text = member.suburb
        txtStreet.Text = member.street
        dtbDOB.DisplayDate = member.DOB
        dtbDOB.SelectedDate = member.DOB
        IDT = member.ID
        mode = mode.edit
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
        If txtFirstName.Text = "" Then
            lblError.Content = "A first name is required to register a student"
            Return
        End If
        If txtLastName.Text = "" Then
            lblError.Content = "A last name is required to register a student"
            Return
        End If
        If txtContact.Text = "" Then
            lblError.Content = "A contact is required to register a student"
            Return
        End If
        If txtParentName.Text = "" Then
            lblError.Content = "A parent name is required to register a student"
            Return
        End If
        If txtStreet.Text = "" Then
            lblError.Content = "A street name is required to register a student"
            Return
        End If
        If txtPostCode.Text = "" Then
            lblError.Content = "A post code is required to register a student"
            Return
        End If
        If txtSuburb.Text = "" Then
            lblError.Content = "A suburb is required to register a student"
            Return
        End If
        If dtbDOB.DisplayDate = Nothing Then
            lblError.Content = "A date of birth is required to register a student"
            Return
        End If
        Dim member As Student = New Student()
           member.firstName = txtFirstName.Text
            member.middleName = txtMiddleName.Text
            member.lastName = txtLastName.Text
            member.ID = lowestMemberIDAvailable
            member.DOB = dtbDOB.DisplayDate
            member.street = txtStreet.Text
            member.suburb = txtSuburb.Text
            member.postCode = txtPostCode.Text
            member.parentName = txtParentName.Text
            member.contact = txtContact.Text
            member.contactAlt = txtContactAlt.Text
        If mode = JPTC_Manager_v2___Patrick_Shaw.Mode.create Then
            AddStudent(member)
        Else
            For i As Long = 0 To studentList.Count - 1
                If studentList(i).ID = IDT Then
                    studentList(i) = member
                    studentList(i).ID = IDT
                    Close()
                    Return
                End If
            Next
        End If
        Close()
    End Sub
End Class
