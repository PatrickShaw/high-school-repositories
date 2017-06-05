Public Enum ClickType
    notClicked
    clicked
    possibility
    flagged
End Enum
Public Class Mine
    Public hasMine As Boolean = False
    Public clicked As ClickType = ClickType.notClicked
    Public c As Coord = New Coord(0, 0)
    Sub New(hasMineT As Boolean)
        InitializeComponent()
        hasMine = hasMineT
    End Sub

    Sub New()
        ' TODO: Complete member initialization 
        InitializeComponent()
    End Sub

End Class
