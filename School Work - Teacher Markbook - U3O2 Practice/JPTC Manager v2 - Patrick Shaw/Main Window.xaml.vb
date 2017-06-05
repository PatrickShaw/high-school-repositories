' ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
' ~ TITLE:                               JPTC Editor
' ~ AUTHOR:                              Patrick Shaw
' ~ DATE MODIFIED:                       28/05/2014
' ~ DATE CREATED:                        20/05/2014
' ~ DESCRIPTION
' ~ Modifies and manages student & instructor attendance 
' ~ at JPTC as well as payments and invoices.
' ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
Imports System.IO
Public Class Main_Window
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        MemberManager.Initialise()
        SessionManager.Initialise()
        BlacklistManager.Initialise()
        btnSessionViewer_Click(Nothing, Nothing)
    End Sub
    ' This adds an undocked weekly session tab in create mode
    Private Sub btnAddWeeklySession_Click(sender As Object, e As RoutedEventArgs) Handles btnAddWeeklySession.Click
        Dim ctrAddWeeklySession As ctrWeeklySession = New ctrWeeklySession(Mode.create)
        tbcModules.AddTab(ctrAddWeeklySession, "Add Weekly Session")
        TryCast(tbcModules.Items(tbcModules.Items.Count - 1), ModuleTabItem).Undock(Windows.WindowStyle.ToolWindow)
    End Sub
    ' This creates a window for registering more JPTC Members
    Private Sub btnAddJPTCMember_Click(sender As Object, e As RoutedEventArgs) Handles btnAddJPTCMember.Click
        Dim wndAddMember As New wndAddMember()
        wndAddMember.ShowDialog()
    End Sub
    ' This allows you to view sessions much like compass views what subject you have during which period
    Private Sub btnSessionViewer_Click(sender As Object, e As RoutedEventArgs) Handles btnSessionViewer.Click
        Dim sessionViewer As New ctrSession_Viewer()
        tbcModules.AddTab(sessionViewer, "Session Viewer")
    End Sub
    ' This allows you to edit the blacklist (if you're an admin)
    Private Sub btnBlacklistk_Click(sender As Object, e As RoutedEventArgs) Handles btnBlacklist.Click
        Dim blacklistWindow As ctrBlacklistManager = New ctrBlacklistManager()
        tbcModules.AddTab(blacklistWindow, "Blacklist Manager", False)
    End Sub
    ' Allows you to add makeup sessions (which are green)
    Private Sub btnMakeupSession_Click(sender As Object, e As RoutedEventArgs) Handles btnMakeupSession.Click
        Dim ctrAddMakeupSession As ctrOneOffSession = New ctrOneOffSession()
        tbcModules.AddTab(ctrAddMakeupSession, "Add Weekly Session")
        TryCast(tbcModules.Items(tbcModules.Items.Count - 1), ModuleTabItem).Undock(Windows.WindowStyle.ToolWindow)
    End Sub
    ' This allows you to edit the absence list
    Private Sub btnAbsenceList_Click(sender As Object, e As RoutedEventArgs) Handles btnAbsenceList.Click
        Dim absentWindow As ctrAbsenceList = New ctrAbsenceList()
        tbcModules.AddTab(absentWindow, "Absence Manager", False)
    End Sub
End Class


Public Enum Days
    DAYNOTSET = 0
    monday = 1
    tuesday = 2
    wednesday = 3
    thursday = 4
    friday = 5
    saturday = 6
    sunday = 7
End Enum
Public Enum MemberType
    student
    instructor
    none
End Enum