Imports System.IO
Public Class Session_Viewer
    Public startTime As Double = 0
    Public finishTime As Double = 0
    Public sessionsForWeek As New List(Of Session)
    Public sessionBoxList As New List(Of SessionBox)
    Dim sessionSelected As Session = Nothing
    Dim mondayDate As DateTime = Now
    Public IDSelected As Long = -9999999999999
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
    Private Sub UnselectAllBoxes(ByVal Exception As SessionBox)
        For i As Long = 0 To sessionBoxList.Count - 1
            With sessionBoxList(i)
                If .session.ID = Exception.session.ID Then Continue For
                .ResetColour()
                .selected = False
            End With
        Next
    End Sub
    Private Sub LoadSessions()
        sessionsForWeek.Clear()
        For i As Long = 0 To weeklySessions.Count - 1
            sessionsForWeek.Add(weeklySessions(i))
        Next
        ' Find the start of the week (from monday)
        dtpSessionDate.SelectedDateFormat = DatePickerFormat.Short
        Dim startDate As Date = dtpSessionDate.DisplayDate
        'MsgBox(startDate)
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

        Debug.WriteLine("Lel")
    End Sub
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
    Public Sub FillQuickEdit(ByVal sessionBoxT As SessionBox)
        lstStudentsInSession.Items.Clear()
        lstStudentsOutofSession.Items.Clear()
        Dim listIDsAdded As New List(Of Long)
        With sessionBoxT.session
            For i As Long = 0 To .students.Count - 1
                lstStudentsInSession.Items.Add(.students(i).FullName())
            Next
            For i As Long = 0 To memberList.Count - 1
                Dim notAddedInSession As Boolean = False
                For o As Long = 0 To .students.Count - 1
                    If .students(o).ID = memberList(i).ID Or memberList(i).memberType = MemberType.instructor Then
                        notAddedInSession = False
                        Exit For
                    End If
                    notAddedInSession = True
                Next
                If notAddedInSession Then lstStudentsOutofSession.Items.Add(memberList(i).FullName())
            Next
        End With
    End Sub
    Public Sub CheckOverlap(sessBox As SessionBox)
        Dim sessionsBehind As Double = 0
        Dim sessionsInfront As Double = 0
        Dim iIsInfront As Boolean = False
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
        'MsgBox(sessionsBehind + sessionsInfront)
        sessBox.Width /= (sessionsBehind + sessionsInfront + 1)
        Canvas.SetLeft(sessBox, Canvas.GetLeft(sessBox) + sessionsBehind * sessBox.Width)
    End Sub
    Public Sub FillCanvas()
        sessionBoxList.Clear()
        cvsSessions.Children.Clear()
        cvsSessions.Width = cvsCellWidth()
        cvsSessions.Height = cvsCellHeight()
        For Each sess In sessionsForWeek
            Dim sessionBox As SessionBox = Nothing
            If File.Exists(GetCanceledFileName(sess)) Then
                sessionBox = New SessionBox(sess, SessionType.canceled)
            Else
                sessionBox = New SessionBox(sess, sess.sessType)
            End If
            cvsSessions.Children.Add(sessionBox)
            Dim startInHours As Double = sess.StartTimeIn24Hours()
            Dim endInHours As Double = startInHours + (sess.lengthHours + CDbl(sess.lengthMinutes) / 60.0)
            Dim percentageStart As Double = (sess.StartTimeIn24Hours() - startTime) / (finishTime - startTime)
            Dim percentageEnd As Double = (endInHours - startTime) / (finishTime - startTime)
            'MsgBox(sess.StartTimeIn24Hours())
            sessionBox.Width = (cvsCellWidth() / 7.0)
            sessionBox.Height = (percentageEnd - percentageStart) * cvsCellHeight()
            'MsgBox(cvsSessions.Height)
            Canvas.SetTop(sessionBox, percentageStart * cvsCellHeight())
            Canvas.SetLeft(sessionBox, (sess.day - 1) * (cvsCellWidth() / 7.0))
            'MsgBox(Canvas.GetLeft(sessionBox))
            sessionBoxList.Add(sessionBox)
            AddHandler sessionBox.grdMain.MouseLeftButtonUp, AddressOf SessionBox_MouseLeftButtonUp
            If sessionBox.session.ID = IDSelected Then
                'MsgBox("Worked")
                SessionBox_MouseLeftButtonUp(sessionBox.grdMain, Nothing)
            End If
            Debug.WriteLine(cvsCellHeight)
        Next
        For i As Long = 0 To sessionBoxList.Count - 1
            CheckOverlap(sessionBoxList(i))
        Next
    End Sub
    Public Function cvsCellWidth() As Double

        Return grdWork.ColumnDefinitions(0).Width.Value
    End Function
    Public Function cvsCellHeight() As Double
        Return grdWork.RowDefinitions(1).Height.Value + grdWork.RowDefinitions(2).Height.Value + grdWork.RowDefinitions(3).Height.Value + grdWork.RowDefinitions(4).Height.Value
    End Function


    Private Sub SessionBox_MouseLeftButtonUp(ByVal sender As System.Object, ByVal e As System.Windows.Input.MouseButtonEventArgs) Handles btnRemoveStudents.MouseLeftButtonUp
        Dim sessBox As SessionBox = TryCast(TryCast(sender, Grid).Parent, SessionBox)
        UnselectAllBoxes(sessBox)
        If sessBox.selected = True Then
            IDSelected = sessBox.session.ID
            sessionSelected = sessBox.session
            sessBox.SelectionHighlight()
            FillQuickEdit(sessBox)
        Else
            IDSelected = -99999999
        End If
    End Sub

    Private Sub dtpSessionDate_SelectedDateChanged(sender As Object, e As SelectionChangedEventArgs) Handles dtpSessionDate.SelectedDateChanged
        dtpSessionDate.DisplayDate = dtpSessionDate.SelectedDate
        Reload()
    End Sub

    Private Sub btnRemoveStudents_Click(sender As Object, e As RoutedEventArgs) Handles btnRemoveStudents.Click
        For i As Long = lstStudentsInSession.SelectedItems.Count - 1 To 0 Step -1
            lstStudentsOutofSession.Items.Add(lstStudentsInSession.SelectedItems(i))
            lstStudentsInSession.Items.Remove(lstStudentsInSession.SelectedItems(i))
        Next
    End Sub

    Private Sub btnAddStudents_Click(sender As Object, e As RoutedEventArgs) Handles btnAddStudents.Click
        If lstStudentsInSession.Items.Count + lstStudentsOutofSession.SelectedItems.Count > 8 Then
            MsgBox("You can't have more than 8 students in a session.")
            Return
        End If
        For i As Long = lstStudentsOutofSession.SelectedItems.Count - 1 To 0 Step -1
            lstStudentsInSession.Items.Add(lstStudentsOutofSession.SelectedItems(i))
            lstStudentsOutofSession.Items.Remove(lstStudentsOutofSession.SelectedItems(i))
        Next
    End Sub

    Private Sub btnSave_Click(sender As Object, e As RoutedEventArgs) Handles btnSave.Click
        If sessionSelected Is Nothing Then Return
        If sessionSelected.sessType = SessionType.weekly Then
            Dim sessionTemp As Session = Nothing
            For i As Long = 0 To cvsSessions.Children.Count - 1
                Dim sessBoxT As SessionBox = TryCast(cvsSessions.Children(i), SessionBox)
                If sessBoxT Is Nothing Then Continue For
                If sessBoxT.selected = True Then sessionTemp = sessBoxT.session Else Continue For
                sessionTemp.students.Clear()
                For o As Long = 0 To lstStudentsInSession.Items.Count - 1
                    For p As Long = 0 To memberList.Count - 1
                        If memberList(p).FullName = lstStudentsInSession.Items(o) Then sessionTemp.students.Add(memberList(p))
                    Next
                Next
            Next
            If sessionTemp Is Nothing Then Return
            For i As Long = 0 To weeklySessions.Count - 1
                If weeklySessions(i).ID <> sessionTemp.ID Then Continue For
                weeklySessions(i) = sessionTemp
            Next
            RewriteWeeklySessions()
        ElseIf sessionSelected.sessType = SessionType.makeup Then
            Dim oldSess As String = sessionSelected.ToStringMakeupSess()
            sessionSelected.students.Clear()
            For i As Long = 0 To cvsSessions.Children.Count - 1
                Dim sessBoxT As SessionBox = TryCast(cvsSessions.Children(i), SessionBox)
                If sessBoxT Is Nothing Then Continue For
                If sessBoxT.selected = True Then sessionSelected = sessBoxT.session Else Continue For
                sessionSelected.students.Clear()
                For o As Long = 0 To lstStudentsInSession.Items.Count - 1
                    For p As Long = 0 To memberList.Count - 1
                        If memberList(p).FullName = lstStudentsInSession.Items(o) Then sessionSelected.students.Add(memberList(p))
                    Next
                Next
            Next
            EditMakeupSession(sessionSelected, oldSess)
        End If
        Reload()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As RoutedEventArgs) Handles btnRefresh.Click
        Reload()
    End Sub
    Public Function GetCanceledFileName(ByRef sessionT As Session) As String
        Dim fileName As String = ""
        Dim convertedName As String = ""
        Select Case sessionT.sessType
            Case SessionType.weekly
                fileName = (".\Canceled Sessions\" + sessionT.ID.ToString() + " - " + dtpSessionDate.DisplayDate.AddDays(sessionT.day - 1).ToString() + ".dtb")
            Case SessionType.makeup
                fileName = ".\Canceled Sessions\" + sessionT.startDate.AddDays(sessionT.day - 1).ToString() + " - " + sessionT.instructor.SummaryLastName() + " - " + Format(sessionT.StartTimeIn24Hours(), "Fixed") + " - " + Format(sessionT.EndTimeIn24Hours(), "Fixed") + ".dtb"
        End Select
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
    Private Sub btnCancelSession_Click(sender As Object, e As RoutedEventArgs) Handles btnCancelSession.Click
        If sessionSelected Is Nothing Then Return
        Dim fileName As String = GetCanceledFileName(sessionSelected)
        If fileName = "" Then Return
        If File.Exists(fileName) = False Then
            File.CreateText(fileName)
        Else
            Return
        End If
    End Sub
End Class
