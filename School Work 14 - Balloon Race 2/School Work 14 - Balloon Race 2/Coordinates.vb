Public Structure Coord
    Public x As Long
    Public y As Long
    Public Shared Operator =(coord As Coord, oCoord As Coord) As Boolean
        If coord.x = oCoord.x And coord.y = oCoord.y Then Return True Else Return False
    End Operator
    Public Shared Operator <>(coord As Coord, oCoord As Coord) As Boolean
        If coord.x <> oCoord.x Or coord.y <> oCoord.y Then Return True Else Return False
    End Operator
    Public Shared Operator +(coord As Coord, oCoord As Coord)
        coord.x += oCoord.x
        coord.y += oCoord.y
        Return coord
    End Operator
    Public Shared Operator -(coord As Coord, oCoord As Coord)
        Return New Coord(coord.x - oCoord.x, coord.y - oCoord.y)
    End Operator
    Public Sub New(xT As Long, yT As Long)
        x = xT
        y = yT
    End Sub
    Public Function Intersect(oCoord As Coord) As Boolean
        If (oCoord.x = x) Then
            If (oCoord.y = y) Then Return True
        End If
        Return False
    End Function
End Structure