Imports System.Windows.Threading
Imports System.Threading.Tasks
Imports System.ComponentModel

Public Class Student_Manager
    Dim students As New List(Of Student)
    Dim studentBoxes As New List(Of StudentBox)
    Dim studentDictionary As New Dictionary(Of String, StudentBox)
    Dim letters As New List(Of TextBlock)
    Public Enum OrderMode
        firstname
        lastname
    End Enum
    Dim orderBy As OrderMode = Student_Manager.OrderMode.firstname
    Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' f,l,dob,street,sub,po,parn,contact,contactalt,noat
        ' Add any initialization after the InitializeComponent() call.

        Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Render, New Action(AddressOf OrderByFirstName))

    End Sub
    Public Sub CreateStudentBoxes()
        If orderBy = OrderMode.firstname Then
            OrderByFirstName()
        Else
            OrderByLastName()
        End If
    End Sub
    Public Sub ResetBoxes(sender As Object, e As RoutedEventArgs)
        If (Keyboard.IsKeyDown(Key.LeftCtrl) Or Keyboard.IsKeyDown(Key.LeftCtrl)) = False Then
            For Each box In studentBoxes
                box.selected = False
                box.ctrBox_MouseLeave(Nothing, Nothing)
            Next
        End If
    End Sub
    Dim oldSearchText As String = ""

    Public Sub OrderByFirstName()
        students.Clear()
        studentBoxes.Clear()
        wrpStudents.Children.Clear()

        For Each student In studentList
            If student.memberType = MemberType.student Then students.Add(student)
        Next
        students.Sort(Function(x, y) x.FullName().CompareTo(y.FullName()))
        Dim letter As Char = "a"
        For Each Student In students
            Dim sk As VirtualizingStackPanel = New VirtualizingStackPanel()

            If (letter <> Student.FullName()(0)) Then
                letter = Student.FullName()(0)
                Dim label As New TextBlock
                Dim label2 As New TextBlock
                label.Text = Environment.NewLine + " " + letter
                'wrpStudents.Children.Add(label)
                label.FontSize = 22
                label.FontWeight = FontWeights.Bold
                label.Foreground = New SolidColorBrush(Color.FromRgb(212, 255, 208))
                sk.Children.Add(label)
                letters.Add(label)
            End If
            Dim studentBox As StudentBox = New StudentBox(Student)
            sk.Children.Add(studentBox)
            studentBoxes.Add(studentBox)
            wrpStudents.Children.Add(sk)
            AddHandler studentBox.PreviewMouseLeftButtonUp, AddressOf ResetBoxes
        Next
    End Sub
    Public Sub OrderByLastName()
        students.Clear()
        studentBoxes.Clear()
        wrpStudents.Children.Clear()
        For Each student In studentList
            If student.memberType = MemberType.student Then students.Add(student)
        Next
        students.Sort(Function(x, y) x.lastName.CompareTo(y.lastName))
        Dim letter As Char = "a"
        For Each Student In students
            Dim sk As VirtualizingStackPanel = New VirtualizingStackPanel()
            If (letter <> Student.lastName(0)) Then
                letter = Student.lastName(0)
                Dim label As New TextBlock
                Dim label2 As New TextBlock
                label.Text = Environment.NewLine + " " + letter
                'wrpStudents.Children.Add(label)
                label.FontSize = 22
                label.FontWeight = FontWeights.Bold
                label.Foreground = New SolidColorBrush(Color.FromRgb(212, 255, 208))

                sk.Children.Add(label)
                letters.Add(label)
            End If
            Dim studentBox As StudentBox = New StudentBox(Student)
            sk.Children.Add(studentBox)
            studentBoxes.Add(studentBox)
            wrpStudents.Children.Add(sk)
            AddHandler studentBox.PreviewMouseLeftButtonUp, AddressOf ResetBoxes
        Next
    End Sub
    Public Sub CheckLetters(ByRef letter As TextBlock)
        Dim studentBoxExists As Boolean = False
        Dim letterT As Char = letter.Text(3)
        For Each StudentBox In studentBoxes
            If orderBy = OrderMode.firstname Then
                If StudentBox.lblFullName.Text(0) > letterT Then Exit For
                If StudentBox.lblFullName.Text(0) = letterT And StudentBox.Visibility = Windows.Visibility.Visible Then studentBoxExists = True
            Else
                If StudentBox.student.lastName(0) > letterT Then Exit For
                If StudentBox.student.lastName(0) = letterT And StudentBox.Visibility = Windows.Visibility.Visible Then studentBoxExists = True
            End If
        Next
        If studentBoxExists Then
            letter.Visibility = Windows.Visibility.Visible
        Else
            letter.Visibility = Windows.Visibility.Collapsed
        End If
    End Sub
    Public Sub CheckStudentBoxes(ByRef StudentBox As StudentBox)
        
        If (StudentBox.lblFullName.Text.Contains(txtSearch.Text) Or StudentBox.lblDOB.Text.Contains(txtSearch.Text) Or StudentBox.lblParentName.Text.Contains(txtSearch.Text)) Then
            StudentBox.Visibility = Windows.Visibility.Visible
        Else
            StudentBox.Visibility = Windows.Visibility.Collapsed
        End If
    End Sub
    Public Sub InitiateSearch()
        Dim search As String = ""

        If txtSearch.Text.Contains(oldSearchText) Then
            ' FOR TYPING =============================
            For Each StudentBox In studentBoxes
                If StudentBox.Visibility = Windows.Visibility.Collapsed Then Continue For
                CheckStudentBoxes(StudentBox)
            Next
            For Each letter In letters
                If letter.Visibility = Windows.Visibility.Collapsed Then Continue For
                CheckLetters(letter)
            Next
        Else
            ' WHEN YOUR CHANGING LOTS IN THE SEARCH BOX
            For Each StudentBox In studentBoxes
                CheckStudentBoxes(StudentBox)
            Next
            For Each letter In letters
                CheckLetters(letter)
            Next
        End If
        oldSearchText = txtSearch.Text
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As TextChangedEventArgs) Handles txtSearch.TextChanged
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, New Action(AddressOf InitiateSearch))
    End Sub

    Private Sub btnAddStudent_Click(sender As Object, e As RoutedEventArgs) Handles btnAddStudent.Click
        Dim studentForm As wndAddMember = New wndAddMember()
        studentForm.ShowDialog()
        RecalcBoxes()
    End Sub
    Public Sub RecalcBoxes()
        If orderBy = OrderMode.firstname Then
            OrderByFirstName()
        Else
            OrderByLastName()
        End If
    End Sub
    Private Sub btnEditStudents_Click(sender As Object, e As RoutedEventArgs) Handles btnEditStudents.Click
        Dim noSelected As Long = 0
        For Each StudentBox In studentBoxes
            If StudentBox.selected Then
                Dim studentForm As wndAddMember = New wndAddMember(StudentBox.student)
                studentForm.ShowDialog()
                noSelected += 1
            End If
        Next
        RecalcBoxes()
        If noSelected = 0 Then MessageBox.Show("You need to select a student box (Hold CTR and left click on students)")
    End Sub

    Private Sub lstOrder_Click(sender As Object, e As RoutedEventArgs) Handles lstOrder.Click
        If orderBy = OrderMode.firstname Then
            orderBy = OrderMode.lastname

OrderByLastName()
            lstOrder.Content = "Order by first name"
        Else
            orderBy = OrderMode.firstname 
            lstOrder.Content = "Order by last name"
            OrderByFirstName()
        End If
        txtSearch.Text = ""
    End Sub

    Private Sub scrollViewer_MouseWheel(sender As Object, e As MouseWheelEventArgs) Handles scrollViewer.MouseWheel
        scrollViewer.ScrollToHorizontalOffset(scrollViewer.HorizontalOffset - e.Delta)
    End Sub

    Private Sub btnDeleteStudents_Click(sender As Object, e As RoutedEventArgs) Handles btnDeleteStudents.Click
        Dim noSelected As Long = 0
        If MessageBox.Show("Are you sure you want to remove the students selected?", "Remove Students", MessageBoxButton.YesNo) = MessageBoxResult.No Then Return
        For Each box In studentBoxes
            If box.selected = True Then
                noSelected += 1
                studentList.Remove(box.student)
                students.Remove(box.student)
                wrpStudents.Children.Remove(box)
                studentBoxes.Remove(box)
            End If
        Next
        RecalcBoxes()
        If noSelected = 0 Then MessageBox.Show("You need to select a studentbox to delete a student. (Hold CTR)")
    End Sub

    Private Sub btnClose_Click(sender As Object, e As RoutedEventArgs) Handles btnClose.Click
        TryCast(TryCast(Parent, ModuleTabItem).Parent, ModuleTabControl).Items.Remove(Parent)
    End Sub
End Class
