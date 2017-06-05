Public Module Cache
    Public passwordEntered As String = ""
    Public usernameEntered As String = ""
    Const adminUsername As String = "Theresa"
    Const adminPassword As String = "password"
    Const userUsername As String = "Mahanama"
    Const userPassword As String = "password"
    ' This function should be called everytime you use an admin privillaged function to prevent hacking
    Public Function IsUser() As Boolean
        If passwordEntered = userPassword And usernameEntered = userUsername Then Return True
        Return False
    End Function
    Public Function IsAdmin() As Boolean
        If passwordEntered = adminPassword And usernameEntered = adminUsername Then Return True
        Return False
    End Function
    Public dateViewed As Date = Now
    Public lowestMemberIDAvailable As Long = 0
    Public lowestSessionIDAvailable As Long = 0
    ' ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    ' C# -> VB.NET MyChem (By Patrick Shaw): Module Cacher
    Public Const MainWindowTitle As String = "JPTC Manager"
    ' Screen dimensions
    Public sWidth As Double = SystemParameters.PrimaryScreenWidth
    Public sHeight As Double = SystemParameters.PrimaryScreenHeight
    ' List of tracked user controls for managing tab header naming
    Public userControlsOpen As New List(Of Type)
    Public draggedTabs As New List(Of ModuleTabItem)
    ' Calculate the number of a particular usercontrol currently opened
    Public Function NoOpened(userControlType As Type)
        Dim count As Long = 0
        For i As Long = 0 To userControlsOpen.Count - 1
            If userControlsOpen(i) = userControlType Then count += 1
        Next
        Return count
    End Function
End Module
