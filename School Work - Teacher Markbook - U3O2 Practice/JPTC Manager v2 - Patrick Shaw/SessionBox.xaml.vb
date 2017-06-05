Public Enum SessionType
    weekly
    makeup
    none
    canceled
End Enum
Public Class SessionBox
    Inherits UserControl
    Public marked As Boolean = False
    Public session As Session
    Public sessionType As SessionType
    Public colourDefault As Color
    Public selected As Boolean = False
    Public Sub New(ByRef SessionT As Session, ByVal sessionTypeT As SessionType)
        InitializeComponent()
        session = SessionT
        sessionType = sessionTypeT
        Dim quickInfoT As String = AMPMFrom24Hour(SessionT.startHours, SessionT.startMinutes) + " - " + SessionT.instructor.SummaryLastName() + " - " + AMPMFrom24Hour(SessionT.startHours + SessionT.lengthHours, SessionT.startMinutes + SessionT.lengthMinutes)
        txbInfo.Text = quickInfoT
        Select Case sessionTypeT
            Case sessionType.canceled
                colourDefault = Color.FromRgb(225, 123, 117)
                txbInfo.TextDecorations = TextDecorations.Strikethrough
            Case sessionType.makeup
                colourDefault = Color.FromRgb(117, 225, 119)
            Case sessionType.weekly
                colourDefault = Color.FromRgb(117, 167, 225)
        End Select
        ResetColour()
    End Sub
    Private Sub grdMain_MouseLeave(ByVal sender As Object, ByVal e As MouseEventArgs) Handles grdMain.MouseLeave
        If selected Then
            SelectionHighlight()
        Else
            ResetColour()
        End If
    End Sub
    ' The equivelant of a double click
    Private Sub grdMain_PreviewMouseDown(ByVal sender As Object, ByVal e As MouseButtonEventArgs) Handles grdMain.PreviewMouseDown
        If selected = True Then selected = False Else selected = True
        'If e.ChangedButton = MouseButton.Left And e.ClickCount = 2 Then
        '    CreateSessionEditor()
        'selected = False
        'End If
    End Sub
    ' Create session editor
    Private Sub CreateSessionEditor()
        Dim editSessionControl As ctrWeeklySession = New ctrWeeklySession(session)
        Dim wndEditSession As Window = New Window()
        wndEditSession.Content = editSessionControl
        wndEditSession.WindowStyle = WindowStyle.ToolWindow
        wndEditSession.ShowDialog()
    End Sub
    ' ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ COLOURS ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    ' Colours functions and sub routines/methods were taken from MyChem and translated from C# -> VB.NET
    Public Sub ResetColour()
        Dim gradientStops As GradientStopCollection = New GradientStopCollection()
        ' Warning: This creates the weirdest optical illusion, looks like the border is what has is gradiented
        'gradientStops.Add(New GradientStop(DarkenColour(colourDefault, 2D), 0))
        'gradientStops.Add(New GradientStop(colourDefault, 1D))
        Dim gradient As SolidColorBrush = New SolidColorBrush(colourDefault)
        rctMain.Fill = gradient
        txbInfo.Foreground = New SolidColorBrush(DarkenColour(colourDefault, 5D))
        rctMain.StrokeThickness = 4
        rctMain.Stroke = New SolidColorBrush(DarkenColour(colourDefault, 2D))
    End Sub
    ' When the user holds their mouse (or finger) on top of the sessionBox
    Public Sub PreSelectionHighlight() Handles grdMain.PreviewMouseLeftButtonDown
        rctMain.Fill = New SolidColorBrush(DarkenColour(colourDefault, 3.25D))
        txbInfo.Foreground = New SolidColorBrush(Color.FromRgb(200, 200, 200))
    End Sub
    ' When the mouse hovers over the sessionbox (even though this program uses touch :P)
    Public Sub SelectionHighlight() Handles grdMain.MouseLeftButtonUp
        rctMain.Fill = New SolidColorBrush(DarkenColour(colourDefault, 2.5D))
    End Sub
    ' When the mouse has finally selected the sessionBox
    Public Sub HighlightColour() Handles grdMain.MouseEnter
        If selected Then Return
        rctMain.Fill = New SolidColorBrush(Color.FromRgb(CalcHighlightVal(colourDefault.R), CalcHighlightVal(colourDefault.G), CalcHighlightVal(colourDefault.B)))
    End Sub
    Protected Function CalcHighlightVal(ByVal Val As Byte) As Byte
        Dim valTemp As Byte = 255 - Val
        valTemp /= 3.0
        Val += valTemp
        Return Val
    End Function
End Class
