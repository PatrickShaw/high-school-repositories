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
        If coord.x < 0 Then coord.x = gridXCount Else If coord.x > gridXCount Then coord.x = 0
        If coord.y < 0 Then coord.y = gridYCount Else If coord.y > gridYCount Then coord.y = 0
        Return coord
    End Operator
    Public Shared Operator -(coord As Coord, oCoord As Coord)
        Return GridifyCoords(New Coord(coord.x - oCoord.x, coord.y - oCoord.y))
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
    Public Function GridDistance(oCoord As Coord) As Long
        Dim TotalDistance As Long
        Dim distance1 As Long
        Dim distance2 As Long
        If (y <> oCoord.y) Then
            If (y < oCoord.y) Then
                distance1 = oCoord.y - y
                distance2 = y + (gridWidth - oCoord.y)
            Else
                distance1 = y - oCoord.y
                distance2 = oCoord.y + (gridWidth - y)
            End If
            If distance1 < distance2 Then TotalDistance += distance1 Else TotalDistance += distance2
        End If
        If (x <> oCoord.x) Then
            If (x < oCoord.x) Then
                distance1 = oCoord.x - x
                distance2 = x + (gridWidth - oCoord.x)
            Else
                distance1 = x - oCoord.x
                distance2 = oCoord.x + (gridWidth - x)
            End If
            If distance1 < distance2 Then TotalDistance += distance1 Else TotalDistance += distance2
        End If
        Return TotalDistance
    End Function
End Structure