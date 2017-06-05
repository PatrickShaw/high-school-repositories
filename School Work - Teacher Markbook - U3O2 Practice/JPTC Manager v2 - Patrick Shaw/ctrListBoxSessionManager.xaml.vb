Public Class ctrListBoxSessionManager
    Dim lstBoxes As List(Of ListBox)
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        For i As Long = 0 To weeklySessions.Count - 1
            Dim lstBoxTemp As ListBox = New ListBox()
            lstBoxTemp.Width = 300
            lstBoxTemp.Height = 600
            For o As Long = 0 To weeklySessions(i).students.Count - 1
                Dim studentListItem As ListBoxItem = New ListBoxItem()
                studentListItem.Content = weeklySessions(i).students(o).FullName()
                lstBoxTemp.Items.Add(studentListItem)
                AddHandler studentListItem.PreviewMouseLeftButtonUp, AddressOf ListBoxItem_PreviewMouseLeftButtonDown
            Next
            lstBoxTemp.SelectionMode = SelectionMode.Multiple
            AddHandler lstBoxTemp.Drop, AddressOf ListBox_Drop
            lstBoxTemp.AllowDrop = True
            wrpMain.Children.Add(lstBoxTemp)
        Next
        ' Add any initialization after the InitializeComponent() call.
    End Sub
    ' Adds tab items to the tab control
    Private Sub ListBox_Drop(ByVal sender As Object, ByVal e As DragEventArgs)
        MessageBox.Show("Rawr!")
        Dim listItem As ListBoxItem = TryCast(e.Data.GetData(GetType(ListBoxItem)), ListBoxItem)
        TryCast(sender, ListBox).Items.Add(listItem)
    End Sub
    Private Sub ListBoxItem_PreviewMouseLeftButtonDown(ByVal sender As Object, ByVal e As MouseButtonEventArgs)
        Dim dataObj As DataObject = New DataObject(Me)
        DragDrop.DoDragDrop(TryCast(TryCast(sender, ListBoxItem).Parent, ListBox), dataObj, DragDropEffects.Move)
    End Sub
    Private Sub btnOkay_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles btnOkay.Click

    End Sub
End Class
