Imports System.IO
Public Class ctrSession_Viewer
    Public startTime As Double = 0
    Public finishTime As Double = 0
    Public sessionsForWeek As New List(Of Session)
    Public sessionBoxList As New List(Of ctrSessionBox)
    Dim sessionSelected1 As Session = Nothing
    Dim sessionSelected2 As Session = Nothing
    Dim mondayDate As DateTime = Now
    Public IDSelected1 As Long = -9999999999999
    Public IDSelected2 As Long = -9999999999999
    Public Sub Reload()
        LoadSessions()
        RecalcScale()
        FillCanvas()
    End Sub
    Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        dtpSessionDate.SelectedDate = Now
        ' Add any initialization after the InitializeComponent() call.
        Reload()
    End Sub
    ' Prevents multiple session boxes from being selected (because if you did the quick edit bar would be very confusing)
    Private Sub UnselectAllBoxes(ByVal Exception As ctrSessionBox, ByVal selectionTypeException As SSSelectionMode)
        For i As Long = 0 To sessionBoxList.Count - 1
            With sessionBoxList(i)
                If .selected = selectionTypeException Then Continue For
                If .session.ID = Exception.session.ID Then Continue For
                .ResetColour()
                .selected = False
            End With
        Next
    End Sub
    ' Imports makeup sessions and weekly sessions
    Private Sub LoadSessions()
        sessionsForWeek.Clear()
        For i As Long = 0 To weeklySessions.Count - 1
            sessionsForWeek.Add(weeklySessions(i))
        Next
        ' Find the start of the week (from monday)
        dtpSessionDate.SelectedDateFormat = DatePickerFormat.Short
        Dim startDate As Date = dtpSessionDate.DisplayDate
        For i = 0 To 6
            If startDate.DayOfWeek <> DayOfWeek.Monday Then
                startDate = startDate.Subtract(TimeSpan.FromDays(1))
            Else
                mondayDate = startDate
                Exit For
            End If
        Next
        For i = 0 To 6
            Dim sessionArray As Session() = ReadMakeupSessions(startDate)
            For o As Long = 0 To sessionArray.Count - 1
                sessionsForWeek.Add(sessionArray(o))
            Next
            startDate = startDate.AddDays(1)
        Next
    End Sub
    ' This is required to determine where abouts sessionBoxes should go in the canvas
    Private Sub RecalcScale()
        Dim earliestStart As Double = 99999999999
        Dim latestEnd As Double = -99999999999
        For Each sess In sessionsForWeek
            Dim startInHours As Double = sess.startHours + CDbl(sess.startMinutes) / 60.0
            If startInHours < earliestStart Then
                earliestStart = startInHours
            End If
            Dim endInHours As Double = startInHours + (sess.lengthHours + CDbl(sess.lengthMinutes) / 60.0)
            If endInHours > latestEnd Then
                latestEnd = endInHours
            End If
        Next
        startTime = Math.Floor(earliestStart)
        finishTime = Math.Ceiling(latestEnd)
    End Sub
    ' Fills the Quick Edit bar with the details of the session that you selected
    Public Sub FillQuickEdit(ByVal sessionBoxT As ctrSessionBox)
        lstStudentsInSession.Items.Clear()
        lstStudentsOutofSession.Items.Clear()
        Dim listIDsAdded As New List(Of Long)
        With sessionBoxT.session
            For i As Long = 0 To .students.Count - 1
                lstStudentsInSession.Items.Add(.students(i).FullName())
            Next
            For i As Long = 0 To studentList.Count - 1
                Dim notAddedInSession As Boolean = False
                For o As Long = 0 To .students.Count - 1
                    If .students(o).ID = studentList(i).ID Then
                        notAddedInSession = False
                        Exit For
                    End If
                    notAddedInSession = True
                Next
                If notAddedInSession Then lstStudentsOutofSession.Items.Add(studentList(i).FullName())
            Next
        End With
    End Sub
    ' Checks if session boxes are overlaping each other, if they are this will halve their width so you can see both of them
    Public Sub CheckOverlap(ByVal sessBox As ctrSessionBox)
        Dim sessionsBehind As Double = 0
        Dim sessionsInfront As Double = 0
        Dim iIsInfront As Boolean = False
        ' Determines how many are overlaping the current sessionBox
        For i As Long = 0 To sessionBoxList.Count - 1
            If sessionBoxList(i).Equals(sessBox) Then
                iIsInfront = True
                Continue For
            End If
            If (sessBox.session.EndTimeIn24Hours() <= sessionBoxList(i).session.StartTimeIn24Hours() Or sessionBoxList(i).session.EndTimeIn24Hours() <= sessBox.session.StartTimeIn24Hours()) = False And sessionBoxList(i).session.day = sessBox.session.day Then
                If iIsInfront Then
                    sessionsInfront += 1
                Else
                    sessionsBehind += 1
                End If
            End If
        Next
        ' Sets the new width and position of the session box
        sessBox.Width /= (sessionsBehind + sessionsInfront + 1)
        Canvas.SetLeft(sessBox, Canvas.GetLeft(sessBox) + sessionsBehind * sessBox.Width)
    End Sub
    ' Fill canvas adds session boxes to the canvas. Like compass
    Public Sub FillCanvas()
        ' Get rid of all the old session boxes
        sessionBoxList.Clear()
        cvsSessions.Children.Clear()
        ' Scales the session boxes to the size of your window
        cvsSessions.Width = cvsCellWidth()
        cvsSessions.Height = cvsCellHeight()
        For Each sess In sessionsForWeek
            Dim sessionBox As ctrSessionBox = Nothing
            If File.Exists(GetCanceledFileName(sess)) Then
                sessionBox = New ctrSessionBox(sess, SessionType.canceled)
            Else
                sessionBox = New ctrSessionBox(sess, sess.sessType)
            End If
            cvsSessions.Children.Add(sessionBox)
            Dim startInHours As Double = sess.StartTimeIn24Hours()
            Dim endInHours As Double = startInHours + (sess.lengthHours + CDbl(sess.lengthMinutes) / 60.0)
            Dim percentageStart As Double = (sess.StartTimeIn24Hours() - startTime) / (finishTime - startTime)
            Dim percentageEnd As Double = (endInHours - startTime) / (finishTime - startTime)
            sessionBox.Width = (cvsCellWidth() / 7.0)
            sessionBox.Height = (percentageEnd - percentageStart) * cvsCellHeight()
            Canvas.SetTop(sessionBox, percentageStart * cvsCellHeight())
            Canvas.SetLeft(sessionBox, (sess.day - 1) * (cvsCellWidth() / 7.0))
            sessionBoxList.Add(sessionBox)
            AddHandler sessionBox.grdMain.MouseLeftButtonUp, AddressOf SessionBox_MouseLeftButtonUp
            AddHandler sessionBox.grdMain.MouseRightButtonUp, AddressOf SessionBox_MouseRightButtonUp
            If sessionBox.session.ID = IDSelected1 Then
                SessionBox_MouseLeftButtonUp(sessionBox.grdMain, Nothing)
            End If
            Debug.WriteLine(cvsCellHeight)
        Next
        For i As Long = 0 To sessionBoxList.Count - 1
            CheckOverlap(sessionBoxList(i))
        Next
    End Sub
    ' Determines the scaling of the canvas width dimension
    Public Function cvsCellWidth() As Double
        Return grdWork.ColumnDefinitions(0).Width.Value + grdWork.ColumnDefinitions(1).Width.Value + grdWork.ColumnDefinitions(2).Width.Value
    End Function
    ' Determines the scaling of the canvas height dimension
    Public Function cvsCellHeight() As Double
        Return grdWork.RowDefinitions(1).Height.Value + grdWork.RowDefinitions(2).Height.Value + grdWork.RowDefinitions(3).Height.Value + grdWork.RowDefinitions(4).Height.Value
    End Function
    ' This is the code that triggers when you left click on a sessionbox
    Private Sub SessionBox_MouseLeftButtonUp(ByVal sender As System.Object, ByVal e As System.Windows.Input.MouseButtonEventArgs)
        Dim sessBox As ctrSessionBox = TryCast(TryCast(sender, Grid).Parent, ctrSessionBox)
        If sessBox.selected = SSSelectionMode.RightClick Then Return
        UnselectAllBoxes(sessBox, SSSelectionMode.RightClick)
        If sessBox.selected = SSSelectionMode.LeftClick Then
            IDSelected1 = sessBox.session.ID
            sessionSelected1 = sessBox.session
            sessBox.SelectionHighlight()
            FillQuickEdit(sessBox)
        Else
            sessionSelected1 = Nothing
            IDSelected1 = -99999999
            lstStudentsInSession.Items.Clear()
            lstStudentsOutofSession.Items.Clear()
        End If
    End Sub
    ' This is the code that triggers when you right click on a sessionbox
    Private Sub SessionBox_MouseRightButtonUp(ByVal sender As System.Object, ByVal e As System.Windows.Input.MouseButtonEventArgs)
        Dim sessBox As ctrSessionBox = TryCast(TryCast(sender, Grid).Parent, ctrSessionBox)
        If sessBox.selected = SSSelectionMode.LeftClick Then Return
        UnselectAllBoxes(sessBox, SSSelectionMode.LeftClick)
        If sessBox.selected = SSSelectionMode.RightClick Then
            IDSelected2 = sessBox.session.ID
            sessionSelected2 = sessBox.session
        Else
            sessBox.HighlightColour()
            sessionSelected2 = Nothing
            IDSelected2 = -99999999
        End If
    End Sub
    ' Reloads the whole session viewer
    Private Sub dtpSessionDate_SelectedDateChanged(ByVal sender As Object, ByVal e As SelectionChangedEventArgs) Handles dtpSessionDate.SelectedDateChanged
        dtpSessionDate.DisplayDate = dtpSessionDate.SelectedDate
        Reload()
    End Sub
    ' Removes students from the session
    Private Sub btnRemoveStudents_Click(ByVal sender As Object, ByVal e As RoutedEventArgs) Handles btnRemoveStudents.Click
        For i As Long = lstStudentsInSession.SelectedItems.Count - 1 To 0 Step -1
            lstStudentsOutofSession.Items.Add(lstStudentsInSession.SelectedItems(i))
            lstStudentsInSession.Items.Remove(lstStudentsInSession.SelectedItems(i))
        Next
    End Sub
    ' Adds students back into the session
    Private Sub btnAddStudents_Click(ByVal sender As Object, ByVal e As RoutedEventArgs) Handles btnAddStudents.Click
        If lstStudentsInSession.Items.Count + lstStudentsOutofSession.SelectedItems.Count > 8 Then
            MsgBox("You can't have more than 8 students in a session.")
            Return
        End If
        For i As Long = lstStudentsOutofSession.SelectedItems.Count - 1 To 0 Step -1
            lstStudentsInSession.Items.Add(lstStudentsOutofSession.SelectedItems(i))
            lstStudentsOutofSession.Items.Remove(lstStudentsOutofSession.SelectedItems(i))
        Next
    End Sub
    ' Writes session data back to the file
    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As RoutedEventArgs) Handles btnSave.Click
        If sessionSelected1 Is Nothing Then Return
        If sessionSelected1.sessType = SessionType.weekly Then
            ' CODE FOR WEEKLY SESSIONS (session that reoccur every week)
            Dim sessionTemp As Session = Nothing
            For i As Long = 0 To cvsSessions.Children.Count - 1
                Dim sessBoxT As ctrSessionBox = TryCast(cvsSessions.Children(i), ctrSessionBox)
                If sessBoxT Is Nothing Then Continue For
                If sessBoxT.selected = True Then sessionTemp = sessBoxT.session Else Continue For
                ' Wipe the current students in the session
                sessionTemp.students.Clear()
                For o As Long = 0 To lstStudentsInSession.Items.Count - 1
                    For p As Long = 0 To studentList.Count - 1
                        ' Now readd them back into the session
                        If studentList(p).FullName = lstStudentsInSession.Items(o) Then sessionTemp.students.Add(studentList(p))
                    Next
                Next
            Next
            If sessionTemp Is Nothing Then Return
            For i As Long = 0 To weeklySessions.Count - 1
                If weeklySessions(i).ID <> sessionTemp.ID Then Continue For
                weeklySessions(i) = sessionTemp
            Next
            RewriteWeeklySessions()
        ElseIf sessionSelected1.sessType = SessionType.makeup Then
            ' CODE FOR MAKEUP SESSIONS (session that reoccur every week)
            Dim oldSess As String = sessionSelected1.ToStringMakeupSess()
            sessionSelected1.students.Clear()
            For i As Long = 0 To cvsSessions.Children.Count - 1
                Dim sessBoxT As ctrSessionBox = TryCast(cvsSessions.Children(i), ctrSessionBox)
                If sessBoxT Is Nothing Then Continue For
                If sessBoxT.selected = True Then sessionSelected1 = sessBoxT.session Else Continue For
                sessionSelected1.students.Clear()
                For o As Long = 0 To lstStudentsInSession.Items.Count - 1
                    For p As Long = 0 To studentList.Count - 1
                        If studentList(p).FullName = lstStudentsInSession.Items(o) Then sessionSelected1.students.Add(studentList(p))
                    Next
                Next
            Next
            EditMakeupSession(sessionSelected1, oldSess)
        End If
        MessageBox.Show("Session changes were saved!")
        Reload()
    End Sub
#Region "CancelFeatures"
    ' This just cancels a session (cross out the text and changes the session box colour to red
    Private Sub btnCancelSession_Click(ByVal sender As Object, ByVal e As RoutedEventArgs) Handles btnCancelSession.Click
        If sessionSelected1 Is Nothing Then
            MessageBox.Show("Please select a session.")
            Return
        End If
        Dim fileName As String = GetCanceledFileName(sessionSelected1)
        If fileName = "" Then Return
        If File.Exists(fileName) = False Then
            File.CreateText(fileName)
        Else
            MessageBox.Show("The session is already canceled" + Environment.NewLine + "You cannot cancel sessions twice.")
            Return
        End If
        Reload()
    End Sub
    ' Does the opposite of what the cancel button does
    Private Sub btnUncancelSession_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles btnUncancelSession.Click
        If sessionSelected1 Is Nothing Then
            MessageBox.Show("Please select a session.")
            Return
        End If
        Dim fileName As String = GetCanceledFileName(sessionSelected1)
        If fileName = "" Then Return
        ' This prevents errors from occuring (they barely happen if they do they might crash the program)
        Try
            If File.Exists(fileName) = True Then
                ' This effectively cancels the session
                File.Delete(fileName)
            Else
                MessageBox.Show("The session wasn't canceled in the first place." + Environment.NewLine + "You have to cancel a session to uncancel it.")
                Return
            End If
        Catch
        End Try
        Reload()
    End Sub
    ' Gets the filename of a canceled session (use this when you need to check if the session is canceled
    Public Function GetCanceledFileName(ByRef sessionT As Session) As String
        ' The file name (with character's that arn't actually allowed in a filename
        Dim fileName As String = ""
        ' The file name but with the characters that arn't allowed replaced with hyphons
        Dim convertedName As String = ""
        Select Case sessionT.sessType
            Case SessionType.weekly
                fileName = (".\Canceled Sessions\" + sessionT.ID.ToString() + " - " + dtpSessionDate.DisplayDate.AddDays(sessionT.day - 1).ToString() + ".dtb")
            Case SessionType.makeup
                fileName = ".\Canceled Sessions\" + sessionT.startDate.AddDays(sessionT.day - 1).ToString() + " - " + sessionT.instructor.SummaryLastName() + " - " + Format(sessionT.StartTimeIn24Hours(), "Fixed") + " - " + Format(sessionT.EndTimeIn24Hours(), "Fixed") + ".dtb"
        End Select
        ' Removes symbols that arn't allowed in a file and changes them to '-'
        For Each letter In fileName
            Select Case letter
                Case ":"
                    convertedName += "-"
                Case "/"
                    convertedName += "-"
                Case Else
                    convertedName += letter
            End Select
        Next
        Return convertedName
    End Function
#End Region
    ' A button that tells the user what the different colours mean
    Private Sub btnHelp_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles btnHelp.Click
        MessageBox.Show("Blue = A weekly session (Session that is held every week)" + Environment.NewLine + "Green = A makeup session (A 'one off' session)" + Environment.NewLine + "Red = A session that is canceled.")
    End Sub
    ' This is required to load up sessions that you added while the session viewer was opened
    Private Sub btnRefresh_Click(ByVal sender As Object, ByVal e As RoutedEventArgs) Handles btnRefresh.Click
        Reload()
    End Sub

    Private Sub btnMoveStudents_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles btnMoveStudents.Click
        If lstStudentsInSession.SelectedItems.Count = 0 Then
            MessageBox.Show("Please selected some students.")
            Return
        End If
        If sessionSelected1 Is Nothing Then
            MessageBox.Show("Please select a session box using the left click.")
            Return
        End If
        If sessionSelected2 Is Nothing Then
            MessageBox.Show("You need to right click on another session box to move students to another class.")
            Return
        End If
        Dim studentsToMove As List(Of Person) = New List(Of Person)
        For i As Long = sessionSelected1.students.Count - 1 To 0 Step -1
            For o As Long = lstStudentsInSession.SelectedItems.Count - 1 To 0 Step -1
                If sessionSelected1.students(i).FullName() = lstStudentsInSession.SelectedItems(o) Then
                    studentsToMove.Add(sessionSelected1.students(i))
                    sessionSelected1.students.Remove(studentsToMove.Last)
                    lstStudentsInSession.Items.Remove(lstStudentsInSession.SelectedItems(o))
                    Exit For
                End If
            Next
        Next
        For i As Long = 0 To studentsToMove.Count - 1
            Dim studentAlreadyInSession As Boolean = False
            For o As Long = 0 To sessionSelected2.students.Count - 1
                If studentsToMove(i).ID = sessionSelected2.students(o).ID Then
                    studentAlreadyInSession = True
                End If
            Next
            If studentAlreadyInSession Then Continue For
            sessionSelected2.students.Add(studentsToMove(i))
        Next
        RewriteWeeklySessions()
        MessageBox.Show("Succesfully moved students!")
    End Sub

End Class
