Imports System.Windows.Controls.Primitives

Public Class ctrOneOffSession
    Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Making it so the verticle scroll bar changes the hours, not the minutes
        tbtnHoursStarting_Click(Nothing, Nothing)
        ' Set the default time that a session starts to 5:30 PM
        tbtnHoursStarting.Content = 17
        tbtnMinutesStarting.Content = 30
        '

        ' Add members of JPTC to the student listbox and the instructor listbox respectively
        For Each member In memberList
            Select Case member.memberType
                Case MemberType.student
                    lstStudents.Items.Add(member.FullName())
                Case MemberType.instructor
                    lstInstructor.Items.Add(member.FullName())
            End Select
        Next
    End Sub
    ' If tbtnHoursStarting is clicked then make it so that vsbChangeStartingValue will change the hours that the session starts
    Private Sub tbtnHoursStarting_Click(ByVal sender As Object, ByVal e As RoutedEventArgs) Handles tbtnHoursStarting.Click
        Dim value As Long = Convert.ToInt16(tbtnHoursStarting.Content)
        tbtnHoursStarting.IsChecked = True
        tbtnMinutesStarting.IsChecked = False
        vsbChangeStartingValue.Maximum = 23
        vsbChangeStartingValue.Minimum = 0
        vsbChangeStartingValue.Value = value
        tbtnHoursStarting.Content = value
    End Sub

    ' If tbtnMinutesStarting is clicked then make it so that vsbChangeStartingValue will change the minutes that the session starts
    Private Sub tbtnMinutesStarting_Click(ByVal sender As Object, ByVal e As RoutedEventArgs) Handles tbtnMinutesStarting.Click
        Dim value As Long = Convert.ToInt16(tbtnMinutesStarting.Content)
        tbtnHoursStarting.IsChecked = False
        tbtnMinutesStarting.IsChecked = True
        vsbChangeStartingValue.Maximum = 59
        vsbChangeStartingValue.Minimum = 0
        vsbChangeStartingValue.Value = value
        tbtnMinutesStarting.Content = value
    End Sub
    ' Changes the value of tbtnMinutesStarting/tbtnHoursStarting to whatever the vsbChangeStartingValue's value is (in whole numbers)
    Private Sub vsbChangeStartingValue_ValueChanged(ByVal sender As Object, ByVal e As RoutedPropertyChangedEventArgs(Of Double)) Handles vsbChangeStartingValue.ValueChanged
        If tbtnHoursStarting.IsChecked Then
            tbtnHoursStarting.Content = CInt(e.NewValue)
        Else
            tbtnMinutesStarting.Content = CInt(e.NewValue)
        End If
    End Sub
    ' Sets txtHours to whatever value of hsbHoursLength is
    Private Sub hsbHoursLength_ValueChanged(ByVal sender As Object, ByVal e As RoutedPropertyChangedEventArgs(Of Double)) Handles hsbHoursLength.ValueChanged
        txtHours.Text = CInt(hsbHoursLength.Value)
    End Sub

    ' Sets txtMinutes to whatever value of hsbMinutesLength is
    Private Sub hsbMinutesLength_ValueChanged(ByVal sender As Object, ByVal e As RoutedPropertyChangedEventArgs(Of Double)) Handles hsbMinutesLength.ValueChanged
        txtMinutes.Text = CInt(hsbMinutesLength.Value)
    End Sub

    ' Makes sure only numbers can be entered into the textbox
    Private Sub txtHours_PreviewTextInput(ByVal sender As Object, ByVal e As TextCompositionEventArgs) Handles txtHours.PreviewTextInput
        If IsNumeric(txtHours.Text) = False Then
            e.Handled = True
        End If
    End Sub
    Private Sub txtMinutes_PreviewTextInput(ByVal sender As Object, ByVal e As TextCompositionEventArgs) Handles txtMinutes.PreviewTextInput
        If IsNumeric(txtMinutes.Text) = False Then
            e.Handled = True
        End If
    End Sub

    ' Writes the edited/new session back to Weekly Sessions.dtb 
    Private Sub btnOkay_Click(ByVal sender As Object, ByVal e As RoutedEventArgs) Handles btnOkay.Click
        If dtpSessionDate.SelectedDate < Now Or dtpSessionDate.SelectedDate Is Nothing Then
            lblError.Content = "You cannot schedule a makeup session in the past."
            Return
        End If
        ' Check if an instructor has been assigned to the session
        If lstInstructor.SelectedItem = Nothing Then
            lblError.Content = "An instructor needs to be selected to create a makeup session."
            Return
        End If
        ' Check if at least 1 student is in the session
        If lstStudents.SelectedItems.Count = 0 Then
            lblError.Content = "At least 1 student needs to be selected to create a makeup session."
            Return
        End If
        If lstStudents.SelectedItems.Count > 8 Then
            lblError.Content = "You can only have 8 students in a session"
            Return
        End If
        ' Make a temporary session variable and fill it with the info given by the user
        Dim sessTemp As New Session(SessionType.makeup)
        sessTemp.lengthHours = Convert.ToInt16(txtHours.Text)
        sessTemp.lengthMinutes = Convert.ToInt16(txtMinutes.Text)
        sessTemp.startMinutes = Convert.ToInt16(tbtnMinutesStarting.Content)
        sessTemp.startHours = Convert.ToInt16(tbtnHoursStarting.Content)
        sessTemp.startDate = dtpSessionDate.SelectedDate
        For i As Long = 0 To memberList.Count - 1
            If memberList(i).FullName = lstInstructor.SelectedItem Then sessTemp.instructor = memberList(i)
            For o As Long = 0 To lstStudents.SelectedItems.Count - 1
                If memberList(i).FullName = lstStudents.SelectedItems(o) Then sessTemp.students.Add(memberList(i))
            Next
        Next
        AddMakeupSession(sessTemp)
        TryCast(Parent, ModuleTabItem).mnuClose_Click(Nothing, Nothing)
    End Sub
    ' This won't write the user's input back to the Weekly Sessions.dtb
    ' Instead the tab will just close
    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As RoutedEventArgs) Handles btnCancel.Click
        TryCast(TryCast(Parent, ModuleTabItem).Parent, ModuleTabControl).Items.Remove(Parent)
    End Sub

    Private Sub lstStudents_SelectionChanged(ByVal sender As System.Object, ByVal e As System.Windows.Controls.SelectionChangedEventArgs)

    End Sub
End Class
