Imports System.IO
Public Class ctrBlacklistManager
    ' Writes back to the blacklist file
    ' NOTE: You need to be an admin to execute this task
    ' Another Note: You techincally don't need the IsAdmin function here but it prevents the HDD from having to do pointless work
    Private Sub btnOkay_Click(ByVal sender As Object, ByVal e As RoutedEventArgs) Handles btnOkay.Click
        If IsAdmin() Then
            blackListStudents.Clear()
            File.WriteAllText(".\Blacklist.dtb", "")
            Dim newBlacklist As New List(Of Person)
            For Each item In lstBlacklisted.Items
                For Each member In memberList
                    If item = member.FullName() Then
                        AddToBlacklist(member)
                    End If
                Next
            Next
        End If
        TryCast(TryCast(Parent, ModuleTabItem).Parent, ModuleTabControl).Items.Remove(Parent)
    End Sub
    Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        ' Puts blacklsited students into lstBlacklisted
        For Each student In blackListStudents
            lstBlacklisted.Items.Add(student.FullName())
        Next
        ' Puts non-blacklisted students into lstNotBlacklisted
        For Each member In memberList
            If member.memberType <> MemberType.student Then Continue For
            Dim isBlacklist As Boolean = False
            For Each blacklistStudent In blackListStudents
                If member.ID = blacklistStudent.ID Then
                    isBlacklist = True
                End If
            Next
            ' Now add the students to the listbox
            If isBlacklist = False Then
                lstNotBlacklisted.Items.Add(member.FullName)
            End If
        Next
    End Sub
    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As RoutedEventArgs) Handles btnCancel.Click
        TryCast(TryCast(Parent, ModuleTabItem).Parent, ModuleTabControl).Items.Remove(Parent)
    End Sub
    Private Sub btnAdd_Click(ByVal sender As Object, ByVal e As RoutedEventArgs) Handles btnAdd.Click
        ' Won't do anything if you aren't an admin
        If IsAdmin() = False Then
            MsgBox("You need to be an administrator to execute this task.")
            Return
        End If
        ' This does the moving-magic :)
        For i As Long = lstNotBlacklisted.SelectedItems.Count - 1 To 0 Step -1
            lstBlacklisted.Items.Add(lstNotBlacklisted.SelectedItems(i))
            lstNotBlacklisted.Items.Remove(lstNotBlacklisted.SelectedItems(i))
        Next
    End Sub
    Private Sub btnRemove_Click(ByVal sender As Object, ByVal e As RoutedEventArgs) Handles btnRemove.Click
        If IsAdmin() = False Then
            MsgBox("You need to be an administrator to execute this task.")
            Return
        End If
        ' This does the moving-magic :)
        For i As Long = lstBlacklisted.SelectedItems.Count - 1 To 0 Step -1
            lstNotBlacklisted.Items.Add(lstBlacklisted.SelectedItems(i))
            lstBlacklisted.Items.Remove(lstBlacklisted.SelectedItems(i))
        Next
    End Sub
End Class
