Imports System.Windows.Controls.Primitives
Public Enum Mode
    create
    edit
    nomodeselected
End Enum
Public Class ctrWeeklySession
    ' Variable for the day the session is held weekly
    Public day As Days = Days.DAYNOTSET
    ' Gets the mode that the user control is in (Edit mode is for editing sessions, Create mode is for creating new weekly sessions)
    Public mode As Mode = mode.nomodeselected
    ' An array to keep all the buttons with days of the week in them
    Public dayButtons As ToggleButton()
    Sub New(ByVal modeT As Mode)
        mode = modeT
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ' Put the day buttosn into the array
        dayButtons = New ToggleButton() {tbtnMonday, tbtnTuesday, tbtnWednesday, tbtnThursday, tbtnFriday, tbtnSaturday, tbtnSunday}
        ' Making it so the verticle scroll bar changes the hours, not the minutes
        tbtnHoursStarting_Click(Nothing, Nothing)
        ' Set the default time that a session starts to 5:30 PM
        tbtnHoursStarting.Content = 17
        tbtnMinutesStarting.Content = 30
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
    Sub New(ByVal sessionBeingEdited As Session)
        InitializeComponent()
        dayButtons = New ToggleButton() {tbtnMonday, tbtnTuesday, tbtnWednesday, tbtnThursday, tbtnFriday, tbtnSaturday, tbtnSunday}
        tbtnMonday.IsChecked = False
        mode = mode.edit
        hsbHoursLength.Value = sessionBeingEdited.lengthHours
        hsbMinutesLength.Value = sessionBeingEdited.lengthMinutes
        day = sessionBeingEdited.day
        Select Case sessionBeingEdited.day
            Case Days.monday
                tbtnMonday.IsChecked = True
            Case Days.tuesday
                tbtnTuesday.IsChecked = True
            Case Days.wednesday
                tbtnWednesday.IsChecked = True
            Case Days.thursday
                tbtnThursday.IsChecked = True
            Case Days.friday
                tbtnFriday.IsChecked = True
            Case Days.saturday
                tbtnSaturday.IsChecked = True
            Case Days.sunday
                tbtnSunday.IsChecked = True
        End Select
        vsbChangeStartingValue.Value = sessionBeingEdited.startHours
        tbtnMinutesStarting.Content = sessionBeingEdited.startMinutes
        tbtnHoursStarting.Content = sessionBeingEdited.startHours
    End Sub
    ' Unchecks all day buttons
    Private Sub UncheckDayButtons(ByRef exception As ToggleButton)
        For Each dayButton In dayButtons
            If dayButton.Content = exception.Content Then Continue For
            dayButton.IsChecked = False
        Next
    End Sub
    ' Sets the day the session will be held on relative to the button that was just clicked
    Private Sub dayButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs) Handles tbtnMonday.Click, tbtnTuesday.Click, tbtnWednesday.Click, tbtnThursday.Click, tbtnFriday.Click, tbtnSaturday.Click, tbtnSunday.Click
        Dim dayButton As ToggleButton = TryCast(sender, ToggleButton)
        UncheckDayButtons(dayButton)
        Select Case dayButton.Content
            Case "Mon"
                day = Days.monday
            Case "Tues"
                day = Days.tuesday
            Case "Wed"
                day = Days.wednesday
            Case "Thurs"
                day = Days.thursday
            Case "Fri"
                day = Days.friday
            Case "Sat"
                day = Days.saturday
            Case "Sun"
                day = Days.sunday
        End Select
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
        ' Check if a day button is checked
        Dim dayButtonChecked As Boolean = False
        For i As Long = 0 To dayButtons.Count - 1
            If dayButtons(i).IsChecked Then dayButtonChecked = True
        Next
        If dayButtonChecked = False Then
            lblError.Content = "A day needs to be chosen in order to " + mode.ToString() + " a weekly session."
            Return
        End If
        ' Check if an instructor has been assigned to the session
        If lstInstructor.SelectedItem = Nothing Then
            lblError.Content = "An instructor needs to be selected to " + mode.ToString() + " a weekly session."
            Return
        End If
        ' Check if at least 1 student is in the session
        If lstStudents.SelectedItems.Count = 0 Then
            lblError.Content = "At least 1 student needs to be selected to " + mode.ToString() + " a weekly session."
            Return
        End If
        If lstStudents.SelectedItems.Count > 8 Then
            lblError.Content = "You can only have 8 students in a session"
            Return
        End If
        ' Make a temporary session variable and fill it with the info given by the user
        Dim sessTemp As New Session(SessionType.weekly)
        sessTemp.day = day
        sessTemp.lengthHours = Convert.ToInt16(txtHours.Text)
        sessTemp.lengthMinutes = Convert.ToInt16(txtMinutes.Text)
        sessTemp.startMinutes = Convert.ToInt16(tbtnMinutesStarting.Content)
        sessTemp.startHours = Convert.ToInt16(tbtnHoursStarting.Content)
        sessTemp.ID = lowestSessionIDAvailable
        For i As Long = 0 To memberList.Count - 1
            If memberList(i).FullName = lstInstructor.SelectedItem Then sessTemp.instructor = memberList(i)
            For o As Long = 0 To lstStudents.SelectedItems.Count - 1
                If memberList(i).FullName = lstStudents.SelectedItems(o) Then sessTemp.students.Add(memberList(i))
            Next
        Next
        Select Case mode
            ' If in create mode then append the new session to Weekly Sessions.dtb
            Case mode.create
                AddWeeklySession(sessTemp)
                ' If in edit mode then write back all sessions to Weekly Sessions.dtb
            Case mode.edit
        End Select
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
