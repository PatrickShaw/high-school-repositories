Public Class UndockedModule
    Inherits Window
    Public tracked As Boolean = True
    Public Sub New(userControl As UserControl, title As String, controlCacheTracking As Boolean, Optional beingUndocked As Boolean = True)
        InitializeComponent()
        theTabControl.AddTab(userControl, title)
        theWindow.Width = userControl.Width
        theWindow.Height = userControl.Height
        tracked = controlCacheTracking
        WindowStatusUpdate(Nothing, Nothing)
    End Sub
    Public Sub New(userControl As UserControl, title As String, copyNo As Long)
        InitializeComponent()
        If (tracked) Then theTabControl.AddTab(userControl, title, copyNo) Else theTabControl.AddTab(userControl, title, 0)
        theWindow.Width = userControl.Width
        theWindow.Height = userControl.Height
        tracked = True
        WindowStatusUpdate(Nothing, Nothing)
    End Sub
    Private Sub WindowStatusUpdate(sender As Object, e As RoutedEventArgs)
        Dim count As Long = theTabControl.Items.Count
        If count = 1 Then
            Title = DirectCast(DirectCast(theTabControl.Items(0), TabItem).Header, String)
        Else
            Title = Cache.MainWindowTitle
        End If
    End Sub
    Private Sub AddTab(control As Object, title As String, Optional duplicatesAllowed As Boolean = True)
        theTabControl.AddTab(control, title, duplicatesAllowed)
        WindowStatusUpdate(Nothing, Nothing)
        AddHandler DirectCast(theTabControl.Items(theTabControl.Items.Count - 1), ModuleTabItem).Unloaded, AddressOf WindowStatusUpdate
    End Sub
    Private Sub theWindow_Closed(sender As Object, e As EventArgs)
        If tracked = False Then Return
        For i As Long = 0 To theTabControl.Items.Count - 1
            Cache.userControlsOpen.Remove(DirectCast(theTabControl.Items(i), ModuleTabItem).Content.GetType())
        Next
    End Sub
End Class
