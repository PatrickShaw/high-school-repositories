' Translated to VB.NET from MyChem (Another program I made)
' Modified version of a TabControl to undock and dock user controls
Public Class ModuleTabControl
    Inherits TabControl
    Public tracked As Boolean = True
    Public startPoint As Point
    ' Adds a tab item to this tab control
    Public Sub AddTab(ByVal control As Object, ByVal title As String, Optional ByVal duplcatesAllowed As Boolean = True)
        ' Finds the number of tracked copies of the user control being added to the tab control
        Dim copies As Long = Cache.NoOpened(control.GetType())
        If copies >= 1 And duplcatesAllowed = False Then Return
        ' Create a tab item for the user control to go into
        Dim tabItemT As ModuleTabItem = New ModuleTabItem(title, NoOpened(control.GetType()))
        tabItemT.Content = control
        Items.Add(tabItemT)
        ' Automatically go to the newly created tab
        SelectedIndex = Items.Count - 1
        tabItemT.IsSelected = True
    End Sub
    ' Does exactly the same thing but with different parametres
    Public Sub AddTab(control As Object, title As String, copyNo As Long, Optional duplciatesAllowed As Boolean = True)
        Dim tabItemT As ModuleTabItem = New ModuleTabItem(title, copyNo)
        tabItemT.Content = control
        Items.Add(tabItemT)
        ' Automatically go to the newly created tab
        SelectedIndex = Items.Count - 1
        SelectedItem = tabItemT
        tabItemT.IsSelected = True
    End Sub
    ' This code is executed when a tab is closed
    Public Sub TabItem_Unloaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
        ' If the tab item is being tracked then remove the tracking
        If tracked Then
            Cache.userControlsOpen.Remove(DirectCast(sender, ModuleTabItem).Content.GetType())
        End If
        ' Remove the tab item from the tab control
        Items.Remove(sender)
        If Items.Count <= 1 Then
            For Each tabT As ModuleTabItem In Items
                tabT.Visibility = Windows.Visibility.Collapsed
            Next
        Else
            For Each tabT As ModuleTabItem In Items
                tabT.Visibility = Windows.Visibility.Visible
            Next
        End If
        ' If the tab control is attached to an Undocked Window Module
        ' AND there are no tab items in the tab control THEN
        ' Close the window
        If Items.Count = 0 Then
            Dim undockedModule As UndockedModule = TryCast(Parent, UndockedModule)
            If undockedModule IsNot Nothing Then undockedModule.Close()
        End If
    End Sub
    ' This prevents accidentally changing tabs
    Private Sub TabControl_PReviewKeyDown(sender As Object, e As KeyEventArgs)
        Select Case e.Key
            Case Key.Left Or Key.Right Or Key.Up Or Key.Down
                e.Handled = True
        End Select
    End Sub
    ' Used for dragging
    Private Sub TabControl_PreviewMouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs)
        startPoint = e.GetPosition(Nothing)
    End Sub
    ' Adds tab items to the tab control
    Private Sub TabControl_Drop(sender As Object, e As DragEventArgs)
        Dim tabItemT As ModuleTabItem = TryCast(e.Data.GetData(GetType(ModuleTabItem)), ModuleTabItem)
        Dim oldControl As ModuleTabControl = TryCast(tabItemT.Parent, ModuleTabControl)
        oldControl.Items.Remove(tabItemT)
        Items.Add(tabItemT)
    End Sub
    ' This code makes sure you arn't dragging a tab item onto the tab control that it's already in
    Private Sub TabControl_PreviewDrop(sender As Object, e As DragEventArgs)
        Try
            Dim tabItemT As ModuleTabItem = TryCast(e.Data.GetData(GetType(ModuleTabItem)), ModuleTabItem)
            Dim oldControl As ModuleTabControl = TryCast(tabItemT.Parent, ModuleTabControl)
            If oldControl.Equals(Me) Then
                e.Handled = True
            End If
        Catch
            e.Handled = True
        End Try
    End Sub
End Class
