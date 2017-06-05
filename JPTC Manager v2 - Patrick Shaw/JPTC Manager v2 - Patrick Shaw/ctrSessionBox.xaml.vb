Public Enum SessionType
    weekly
    makeup
    none
    canceled
End Enum
Public Enum SSSelectionMode
    NotSelected
    LeftClick
    RightClick
End Enum
Public Class ctrSessionBox
    Inherits UserControl
    Public marked As Boolean = False
    Public session As Session
    Public sessionType As SessionType
    ' The colour of the session box when the mouse is not over the session box
    Public colourDefault As Color
    Public selected As SSSelectionMode = SSSelectionMode.NotSelected
    Public Sub New(ByRef SessionT As Session, ByVal sessionTypeT As SessionType)
        InitializeComponent()
        session = SessionT
        sessionType = sessionTypeT
        ' Obtains the text that is displayed in the session box
        Dim quickInfoT As String = AMPMFrom24Hour(SessionT.startHours, SessionT.startMinutes) + " - " + SessionT.instructor.SummaryLastName() + " - " + AMPMFrom24Hour(SessionT.startHours + SessionT.lengthHours, SessionT.startMinutes + SessionT.lengthMinutes)
        txbInfo.Text = quickInfoT
        ' Determines the colour of the session box
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
    ' Animates the session box (when you hover over it it will get brighter)
    Private Sub grdMain_MouseLeave(ByVal sender As Object, ByVal e As MouseEventArgs) Handles grdMain.MouseLeave
        Select Case selected
            Case SSSelectionMode.NotSelected
                ResetColour()
            Case SSSelectionMode.LeftClick
                SelectionHighlight()
            Case SSSelectionMode.RightClick
                RightHandSelectionColour()
        End Select
    End Sub
    ' The equivelant of a double click
    Private Sub grdMain_PreviewRightMouseDown(ByVal sender As Object, ByVal e As MouseButtonEventArgs) Handles grdMain.PreviewMouseRightButtonDown
        If selected = SSSelectionMode.LeftClick Then Return
        If selected = SSSelectionMode.NotSelected Then selected = SSSelectionMode.RightClick Else selected = SSSelectionMode.NotSelected
    End Sub
    ' The equivelant of a double click
    Private Sub grdMain_PreviewLeftMouseDown(ByVal sender As Object, ByVal e As MouseButtonEventArgs) Handles grdMain.PreviewMouseLeftButtonDown
        If selected = SSSelectionMode.RightClick Then Return
        If selected = SSSelectionMode.NotSelected Then selected = SSSelectionMode.LeftClick Else selected = SSSelectionMode.NotSelected
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
        rctMain.Fill = New SolidColorBrush(colourDefault)
        txbInfo.Foreground = New SolidColorBrush(DarkenColour(colourDefault, 5D))
        rctMain.StrokeThickness = 4
        rctMain.Stroke = New SolidColorBrush(DarkenColour(colourDefault, 2D))
    End Sub
    ' When the user holds their mouse (or finger) on top of the sessionBox
    Public Sub PreSelectionHighlight() Handles grdMain.PreviewMouseLeftButtonDown
        If selected = SSSelectionMode.RightClick Then Return
        rctMain.Fill = New SolidColorBrush(DarkenColour(colourDefault, 3.25D))
        txbInfo.Foreground = New SolidColorBrush(Color.FromRgb(200, 200, 200))
    End Sub
    ' When the mouse hovers over the sessionbox (even though this program uses touch :P)
    Public Sub SelectionHighlight() Handles grdMain.MouseLeftButtonUp
        If selected = SSSelectionMode.RightClick Then Return
        rctMain.Fill = New SolidColorBrush(DarkenColour(colourDefault, 2.5D))
    End Sub
    ' When the mouse has finally selected the sessionBox
    Public Sub HighlightColour() Handles grdMain.MouseEnter
        If selected = SSSelectionMode.LeftClick Or SSSelectionMode.RightClick Then Return
        rctMain.Fill = New SolidColorBrush(Color.FromRgb(CalcHighlightVal(colourDefault.R), CalcHighlightVal(colourDefault.G), CalcHighlightVal(colourDefault.B)))
    End Sub
    Public Sub RightHandSelectionColour() Handles grdMain.MouseRightButtonUp
        If selected = SSSelectionMode.LeftClick Then Return
        rctMain.Fill = Brushes.Magenta
    End Sub
    Protected Function CalcHighlightVal(ByVal Val As Byte) As Byte
        Dim valTemp As Byte = 255 - Val
        valTemp /= 3.0
        Val += valTemp
        Return Val
    End Function

    Private Sub txbInfo_MouseEnter(sender As Object, e As MouseEventArgs)

    End Sub
End Class
