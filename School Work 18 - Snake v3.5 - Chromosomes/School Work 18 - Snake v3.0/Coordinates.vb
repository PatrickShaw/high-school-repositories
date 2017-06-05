Public Enum Decision
    forward
    right
    left
End Enum
Public NotInheritable Class SnakeBlock
    Public colour As Color
    Public dNew As Direction
    Public coord As Coord
    Dim Condition As Boolean
    Public Sub Rawr()
        If Condition Then
            Action1()
            Action2()
        Else
            Action1()
            Action2()
        End If
    End Sub
    Public Sub Action2()

    End Sub
    Public Sub Action1()

    End Sub
    Public Function GetFrontPoints() As Point()
        ' Left Perspectively is Outside, Right Perspectively is Inside
        ' Outside is first, inside is second
        Select Case dNew
            Case Direction.up
                Return New Point(1) {New Point(boxSize * coord.x, boxSize * coord.y), New Point(boxSize * (coord.x + 1), boxSize * coord.y)}
            Case Direction.left
                Return New Point(1) {New Point(boxSize * coord.x, boxSize * (coord.y + 1)), New Point(boxSize * coord.x, boxSize * coord.y)}
            Case Direction.down
                Return New Point(1) {New Point(boxSize * (coord.x + 1), boxSize * (coord.y + 1)), New Point(boxSize * (coord.x), boxSize * (coord.y + 1))}
            Case Direction.right
                Return New Point(1) {New Point(boxSize * (coord.x + 1), boxSize * (coord.y)), New Point(boxSize * (coord.x + 1), boxSize * (coord.y + 1))}
        End Select
        'Return New Point(1) {New Point(boxSize * (coord.x + 1), boxSize * coord.y), New Point(boxSize * (coord.x + 1), boxSize * (coord.y) + 1)}
    End Function
    Public Function GetPoints(blockAhead As Direction) As Point()()
        Dim points As Point() = GetFrontPoints()
        If dNew = blockAhead Or (dNew = Direction.right And blockAhead = Direction.up) Or (dNew = Direction.up And blockAhead = Direction.right) Then
            Return New Point(1)() {New Point(0) {points(0)}, New Point(0) {points(1)}}
        Else
            If (dNew = Direction.down And blockAhead = Direction.right) Or (dNew = Direction.left And blockAhead = Direction.down) Then
                Return New Point(1)() {New Point(1) {points(1), points(0)}, New Point() {}}
            End If
            If (dNew = Direction.right And blockAhead = Direction.up) Or (dNew = Direction.up And blockAhead = Direction.right) Then
                Return New Point(1)() {New Point() {}, New Point(1) {points(1), points(0)}}
            End If

            If dNew = Direction.down Or dNew = Direction.left Then Return New Point(1)() {New Point(1) {points(0), points(1)}, New Point() {}}
            If dNew = Direction.up Or dNew = Direction.right Then Return New Point(1)() {New Point() {}, New Point(1) {points(0), points(1)}}
        End If
    End Function
    Public Function GetBackPoints() As Point()
        Select Case dNew
            Case Direction.down
                Return New Point(1) {New Point(boxSize * coord.x, boxSize * coord.y), New Point(boxSize * (coord.x + 1), boxSize * coord.y)}
            Case Direction.right
                Return New Point(1) {New Point(boxSize * coord.x, boxSize * (coord.y + 1)), New Point(boxSize * coord.x, boxSize * coord.y)}
            Case Direction.up
                Return New Point(1) {New Point(boxSize * (coord.x + 1), boxSize * (coord.y + 1)), New Point(boxSize * (coord.x), boxSize * (coord.y + 1))}
            Case Direction.left
                Return New Point(1) {New Point(boxSize * (coord.x + 1), boxSize * (coord.y)), New Point(boxSize * (coord.x + 1), boxSize * (coord.y + 1))}
        End Select
        'Return New Point(1) {New Point(boxSize * (coord.x + 1), boxSize * coord.y), New Point(boxSize * (coord.x + 1), boxSize * (coord.y) + 1)}
    End Function
    Sub New(colourT As Color, x As Long, y As Long, directionT As Direction)
        dNew = directionT
        coord = New Coord(x, y)
        snakeOccupied(x)(y) = CollisionType.snake
        colour = colourT
    End Sub
End Class
Public Class SnakeSegment
    Public blocks As New List(Of SnakeBlock)
    Public pointsInside As New List(Of Point)
    Public pointsOutside As New List(Of Point)
    Public polygon As New Polygon
    Public Sub New()
        polygon.FillRule = FillRule.Nonzero
        GameCanvasPublic.Children.Add(polygon)
    End Sub
    Public Sub FullSegRecalc()
        pointsInside.Clear()
        pointsOutside.Clear()
        Dim blockBackPoints As Point() = blocks.Last.GetBackPoints()
        pointsInside.Add(blockBackPoints(0))
        pointsOutside.Add(blockBackPoints(1))
        For i As Long = blocks.Count - 1 To 1 Step -1

            If blocks(i).dNew <> blocks(i - 1).dNew Then
                Dim pointFront As Point() = blocks(i).GetFrontPoints()
                Dim pointBack As Point() = blocks(i).GetBackPoints()
                If IsClockWise(blocks(i).dNew, blocks(i - 1).dNew) Then
                    pointsOutside.Add(pointFront(0))
                    pointsInside.Add(pointBack(0))
                Else
                    pointsOutside.Add(pointBack(1))
                    pointsInside.Add(pointFront(1))
                End If
            End If
        Next
        Dim pointFirstFront As Point() = blocks.First.GetFrontPoints()
        pointsInside.Add(pointFirstFront(1))
        pointsOutside.Add(pointFirstFront(0))
        UpdateGeometry()
    End Sub
    Public Sub FirstSegRecalc()
        Dim segStart As Point() = blocks.First.GetFrontPoints()
        pointsOutside.Add(segStart(1))
        pointsInside.Add(segStart(0))
        UpdateGeometry()
    End Sub
    Public Sub LastSegRecalc()
        pointsInside.RemoveAt(0)
        pointsOutside.RemoveAt(0)
        UpdateGeometry()
    End Sub
    Public Sub UpdateGeometry()
        Dim pointCollection As New PointCollection
        Dim pointInsideCopy As List(Of Point) = pointsInside

        For i = 0 To pointsOutside.Count() - 1
            pointCollection.Add(pointsOutside(i))
        Next
        pointInsideCopy.Reverse()
        For i = 0 To pointInsideCopy.Count() - 1
            pointCollection.Add(pointInsideCopy(i))
        Next
        polygon.Points = pointCollection
    End Sub
    Public Sub Add(ByVal block As SnakeBlock)
        blocks.Add(block)
    End Sub
End Class
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
        TotalDistance += Math.Abs(y - oCoord.y)
        TotalDistance += Math.Abs(x - oCoord.x)
        Return TotalDistance
    End Function
    Public Function GridDistanceFASTESTPATH(oCoord As Coord) As Long
        Dim TotalDistance As Long

        GridDistance1DFASTESTPATH(TotalDistance, y, oCoord.y)
        GridDistance1DFASTESTPATH(TotalDistance, x, oCoord.x)
        Return TotalDistance
    End Function
    Private Sub GridDistance1DFASTESTPATH(ByRef totalDistance As Long, point1 As Long, point2 As Long)
        Dim distance1 As Long
        Dim distance2 As Long
        If (point1 <> point2) Then
            If (x < point2) Then
                distance1 = point2 - point1
                distance2 = x + (gridWidth - point2)
            Else
                distance1 = point1 - point2
                distance2 = point2 + (gridWidth - point1)
            End If
            If distance1 < distance2 Then totalDistance += distance1 Else totalDistance += distance2
        End If
    End Sub
End Structure

Public Module DirectionalFunctions
    Public Function IsClockWise(d1 As Direction, d2 As Direction) As Boolean
        Select Case True
            Case d1 = Direction.up And d2 = Direction.right : Return True
            Case d1 = Direction.right And d2 = Direction.down : Return True
            Case d1 = Direction.down And d2 = Direction.left : Return True
            Case d1 = Direction.left And d2 = Direction.up : Return True
        End Select
        Return False
    End Function
    Public Function Difference(x1 As Long, x2 As Long) As Long
        Return Math.Abs((x1 - x2))
    End Function
End Module