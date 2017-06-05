Imports System.IO
Public Class ctrAbsenceList
    ' Writes back to the file
    Private Sub btnOkay_Click(ByVal sender As Object, ByVal e As RoutedEventArgs) Handles btnOkay.Click
        absenceList.Clear()
        File.WriteAllText(".\Absence List.dtb", "")
        Dim newabsentList As New List(Of Person)
        For Each item In lstAbsent.Items
            For Each member In memberList
                If item = member.FullName() Then
                    AddToAbsentList(member)
                End If
            Next
        Next
        TryCast(TryCast(Parent, ModuleTabItem).Parent, ModuleTabControl).Items.Remove(Parent)
    End Sub
    Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        For Each student In absenceList
            lstAbsent.Items.Add(student.FullName())
        Next
        For Each member In memberList
            If member.memberType <> MemberType.student Then Continue For
            Dim isabsentList As Boolean = False
            For Each absentListStudent In absenceList
                If member.ID = absentListStudent.ID Then
                    isabsentList = True
                End If
            Next
            If isabsentList = False Then
                lstNotAbsent.Items.Add(member.FullName)
            End If
        Next
    End Sub
    ' Won't write back to the absence list file
    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As RoutedEventArgs) Handles btnCancel.Click
        TryCast(TryCast(Parent, ModuleTabItem).Parent, ModuleTabControl).Items.Remove(Parent)
    End Sub
    ' Moves items from lstNotAbsent to lstAbsent
    Private Sub btnAdd_Click(ByVal sender As Object, ByVal e As RoutedEventArgs) Handles btnAdd.Click
        For i As Long = lstNotAbsent.SelectedItems.Count - 1 To 0 Step -1
            lstAbsent.Items.Add(lstNotAbsent.SelectedItems(i))
            lstNotAbsent.Items.Remove(lstNotAbsent.SelectedItems(i))
        Next
    End Sub
    ' Moves items from lstAbsent to lstNotAbsent
    Private Sub btnRemove_Click(ByVal sender As Object, ByVal e As RoutedEventArgs) Handles btnRemove.Click
        For i As Long = lstAbsent.SelectedItems.Count - 1 To 0 Step -1
            lstNotAbsent.Items.Add(lstAbsent.SelectedItems(i))
            lstAbsent.Items.Remove(lstAbsent.SelectedItems(i))
        Next
    End Sub
End Class
