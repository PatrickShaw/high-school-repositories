Public Class StudentBox
    Public student As Student
    Public selected As Boolean = False
    Sub New(studentT As Student)
        ' This call is required by the designer.
        InitializeComponent()
        lblDOB.Text = studentT.DOB
        lblFullName.Text = studentT.FullName()
        lblParentName.Text = studentT.parentName
        student = studentT
        ' Add any initialization after the InitializeComponent() call.
    End Sub
     
    Private Sub ctrBox_MouseEnter(sender As Object, e As MouseEventArgs)
        If selected = True Then Return
        ctrBox.Background = New SolidColorBrush(Color.FromRgb(31, 61, 51))
    End Sub

    Public Sub ctrBox_MouseLeave(sender As Object, e As MouseEventArgs)
        If selected = True Then Return
        ctrBox.Background = Nothing
    End Sub
    Private Sub ctrBox_MouseLeftButtonUp(sender As Object, e As MouseButtonEventArgs)
        If Keyboard.IsKeyDown(Key.LeftCtrl) Or Keyboard.IsKeyDown(Key.LeftCtrl) Then
            If selected = False Then
                selected = True
                ctrBox.Background = New SolidColorBrush(Color.FromRgb(50, 50, 50))
            Else
                selected = False
                ctrBox_MouseEnter(Nothing, Nothing)
            End If
        Else 
                ctrBox_MouseLeave(Nothing, Nothing)
                Dim editForm As wndAddMember = New wndAddMember(student)
                editForm.ShowDialog() 
            selected = False
        End If
        
    End Sub

    Private Sub ctrBox_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs)
        ctrBox.Background = New SolidColorBrush(Color.FromRgb(32, 40, 32))
    End Sub
End Class
