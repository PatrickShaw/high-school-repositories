Imports System.IO
Public Class ModuleTabItem
    Inherits TabItem
    ' Copy refers is a the number of tabs containing
    ' a similiar usercontrol when the tab was first created
    Public copy As Long = 0
    Public title As String = "Name required"
    Public Sub New(ByVal titleT As String, ByVal copyNoT As Long)
        title = titleT
        copy = copyNoT
        If copy = 0 Then
            Header = titleT
        Else
            Header = titleT + " " + copy.ToString()
        End If
        InitializeComponent()
    End Sub
    ' Closes the tab
    Public Sub mnuClose_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        TryCast(Parent, ModuleTabControl).Items.Remove(Me)
    End Sub
    ' Renames the tab
    Private Sub mnuRename_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim newDock As RenameBox = New RenameBox(CStr(Header))
        newDock.ShowDialog()
        Header = newDock.txtInput.Text
    End Sub
    ' Undocks the tab
    Private Sub mnuUndock_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Undock()
    End Sub
    ' The undock subroutine, undocks a tab (needs to be public so that Main Window can undock without the user doing it themselves)
    Public Sub Undock(Optional ByVal windowStyle As WindowStyle = WindowStyle.SingleBorderWindow)
        TryCast(Parent, ModuleTabControl).Items.Remove(Me)
        ' Creates a new window dock
        Dim newDock As UndockedModule = New UndockedModule(DirectCast(Me.Content, UserControl), title, copy)
        newDock.Width = Width
        newDock.Height = Height
        newDock.Show()
    End Sub
    Private Sub Panel_PreviewMouseLeftButtonDown(ByVal sender As Object, ByVal e As MouseButtonEventArgs)
        Dim dataObj As DataObject = New DataObject(Me)
        DragDrop.DoDragDrop(TryCast(Parent, ModuleTabControl), dataObj, DragDropEffects.Move)
    End Sub
    Private Sub TabITem_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Cache.userControlsOpen.Add(Me.Content.GetType())
        AddHandler Me.Unloaded, AddressOf TryCast(Parent, ModuleTabControl).TabItem_Unloaded
    End Sub

    Private Sub Panel_PreviewMouseDown(sender As Object, e As MouseButtonEventArgs)
        If e.ChangedButton = MouseButton.Left And e.ClickCount = 2 Then mnuUndock_Click(Nothing, Nothing)
    End Sub
End Class
