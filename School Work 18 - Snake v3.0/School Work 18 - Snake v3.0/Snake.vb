
Public Class SnakeStyle
    Public name As String = "Lel"
    Public fillBrush As Brush
    Public snakePattern As SnakePattern = snakePattern.stripe
    Public borderBrush As Brush
    Public borderThickness As Long = 0
    Sub New(fillT As Brush, borderBrushT As Brush, Optional snakePatternT As SnakePattern = snakePattern.rainbow, Optional borderThicknessT As Long = 0)
        fillBrush = fillT
        snakePattern = snakePatternT
        borderBrush = borderBrushT
        borderThickness = borderThicknessT
    End Sub
End Class
Public NotInheritable Class SnakeBlock
    Public colour As Color
    Public coord As Coord
    Sub New(colourT As Color, x As Long, y As Long)
        coord = New Coord(x, y)
        snakeOccupied(x)(y) = CollisionType.snake
        colour = colourT
    End Sub
End Class
Public Enum CollisionType
    none
    snake
    food
End Enum
Public Enum SnakePattern
    rainbow
    stripe
End Enum
Public NotInheritable Class Snake
    Public Class KeyV2
        Public key As Key
        Public downNow As Boolean = False
        Public downPrev As Boolean = False
        Sub New(keyT As Key)
            key = keyT
        End Sub
    End Class
    Public teamNo As Long = 1
    Public speedBonus As Single = 0
    Public speedBonusTime As Long = 0
    Const moveSpeed As Single = 150
    Dim LastUpdateWasForceMove As Boolean = False
    Dim beenUpdated As Boolean = False
    Dim movesTravelledInSameDirection As Long = 0
    Public score As Single = 0
    Public snakeNumber As Long
    Dim scoreMultiplier As Single = 1
    Public growthQueue As Long = 0
    Public isAI As Boolean = False
    Public speedFactor As Single = 1
    Public dNew As Direction = Direction.right
    Public dOld As Direction = dNew
    Public kUp As KeyV2 = New KeyV2(Key.W)
    Public kLeft As KeyV2 = New KeyV2(Key.A)
    Public kDown As KeyV2 = New KeyV2(Key.S)
    Public kRight As KeyV2 = New KeyV2(Key.D)
    Public dead As Boolean = False
    Public invicibilityTime As Long = 100
    Public snakeStyle As SnakeStyle = New SnakeStyle(Brushes.White, Brushes.White)
    Public snakePolygon As Polygon = New Polygon()
    Public snakeBlocks As List(Of SnakeBlock) = New List(Of SnakeBlock)
    Dim moveStopWatch As Stopwatch = New Stopwatch()
    Public otherSnakes As List(Of Snake) = New List(Of Snake)
    Dim delta As Coord = New Coord(0, 0)
#Region "AIFunctions"
    Public Function CalcSpace(passes As Long, starterCoord As Coord, Optional debug As Boolean = False)
        Dim coordsToBePassed As List(Of Coord) = New List(Of Coord)
        Dim coordsCheckedAlready As Boolean()() = New Boolean(gridXCount)() {}
        For x = 0 To gridXCount
            coordsCheckedAlready(x) = New Boolean(gridYCount) {}
        Next
        Dim points As Single = 0
        Dim space As Single = 0
        coordsToBePassed.Add(starterCoord)
        Dim futureCoordsToBePassed As List(Of Coord) = New List(Of Coord)
        coordsCheckedAlready(starterCoord.x)(starterCoord.y) = True
        Dim foundFood As Boolean = False
        For currentPass As Long = 1 To passes
            For i As Long = 0 To coordsToBePassed.Count - 1
                Select Case CheckCoordinatesFilled(coordsToBePassed(i))
                    Case CollisionType.snake
                        Continue For
                    Case CollisionType.none
                        space += 1
                        If debug Then
                            snakeGrid(coordsToBePassed(i).x)(coordsToBePassed(i).y).Fill = New SolidColorBrush(ColourValue(currentPass * 2, 2, SnakePattern.rainbow))
                        End If
                    Case CollisionType.food
                        If foundFood = False Then
                            points -= 0.0001 / currentPass '1.0 - (currentPass * (1.0 / CSng(passes)))
                            foundFood = True
                        End If
                        space += 1
                End Select
                For o As Long = 0 To 3
                    dNew = o
                    DetermineDelta()
                    Dim cTemp As Coord = coordsToBePassed(i) + delta
                    If coordsCheckedAlready(cTemp.x)(cTemp.y) <> True Then
                        coordsCheckedAlready(cTemp.x)(cTemp.y) = True
                        futureCoordsToBePassed.Add(cTemp)
                    End If
                Next
            Next
            coordsToBePassed = New List(Of Coord)
            coordsToBePassed.AddRange(futureCoordsToBePassed)
            futureCoordsToBePassed = New List(Of Coord)
        Next
        ' Incase I forget: the lower the value below, the more preferable the direction is
        points += (CSng(totalSpace) - space) / CSng(totalSpace)
        Return points
    End Function

    Public Sub AI()
        Dim options As List(Of Direction) = DirectionOptions() 'DirectionOptions() ' New List(Of Direction) 
        'options.AddRange({Direction.up, Direction.left, Direction.down, Direction.right})

        dNew = FindBestDOption(options)
    End Sub
    Private Function DirectionOptions() As List(Of Direction)
        ' Up, Left, Down, Right
        Dim directions As List(Of Direction) = New List(Of Direction)
        directions.AddRange({Direction.up, Direction.left, Direction.down, Direction.right})
        Dim optionsToRemove As List(Of Direction) = New List(Of Direction)
        For i = 0 To directions.Count - 1
            dNew = directions(i)
            If dNew = dOld And movesTravelledInSameDirection >= gridHeight Then
                optionsToRemove.Add(dNew)
                Continue For
            End If
            If CheckCoordinatesFilled(PlusDelta(snakeBlocks(0).coord)) = CollisionType.snake Then optionsToRemove.Add(dNew)
        Next
        If optionsToRemove.Count = 0 Then Return directions
        For i = 0 To optionsToRemove.Count - 1
            directions.Remove(optionsToRemove(i))
        Next
        Return directions
    End Function
    ' Check if there is a way to get to the food if you go in this direction
    Private Function FindBestDOption(options As List(Of Direction)) As Direction
        Dim lowestCount As Single = 99999999
        Dim chosenOption As Direction = dOld ' By default
        For i = 0 To options.Count - 1
            Dim count As Single = 0.0
            'If dNew = dOld Then count -= 0.2
            dNew = options(i)
            Dim cTemp As Coord = snakeBlocks(0).coord + delta + delta
            If snakeOccupied(cTemp.x)(cTemp.y) = CollisionType.snake Then
                count -= 0.1
            Else
                cTemp += delta
                If snakeOccupied(cTemp.x)(cTemp.y) = CollisionType.snake Then count -= 0.01
            End If
            'If i = 0 And snakeNumber = 2 And Keyboard.IsKeyDown(Key.C) Then CalcSpace(300, snakeBlocks.First.coord + delta, True)
            dNew = options(i)
            DetermineDelta()
            count += CalcSpace(300, snakeBlocks.First.coord + delta)
            If count < lowestCount Then
                lowestCount = count
                chosenOption = options(i)
            End If
        Next
        Return chosenOption
    End Function
#End Region
    Private Function PlusDelta(oCoord As Coord) As Coord
        DetermineDelta()
        Return oCoord + delta
    End Function
    Public Function CheckCoordinatesFilled(coordinates As Coord) As CollisionType
        Return snakeOccupied(coordinates.x)(coordinates.y)
    End Function
    Public Sub SetOtherSnake(ByRef snakeList As List(Of Snake))
        otherSnakes.AddRange(snakeList.ToArray)
        otherSnakes.RemoveAt(snakeNumber - 1)
    End Sub
    Private Sub InitializeSnake(coordinates As Coord, snakeNoT As Long)
        moveStopWatch.Start()
        snakeNumber = snakeNoT
        Dim temp As Long = Rnd()
        If temp = 1 Then
            For i As Long = 0 To snakeStartingLength - 1
                snakeBlocks.Add(New SnakeBlock(ColourValue(snakeBlocks.Count - 1, snakeNumber, snakeStyle.snakePattern), coordinates.x + i, coordinates.y))
            Next
        Else
            dNew = Direction.left
            For i As Long = 0 To snakeStartingLength - 1
                snakeBlocks.Add(New SnakeBlock(ColourValue(snakeBlocks.Count - 1, snakeNumber, snakeStyle.snakePattern), coordinates.x + i, coordinates.y))
            Next
End If
    End Sub
    Public Sub Reset(coordinates As Coord)
        score = 0
        speedFactor = 1
        growthQueue = 0
        movesTravelledInSameDirection = 0
        snakeBlocks.Clear()
        dead = False
        moveStopWatch.Restart()
        invicibilityTime = 100
        InitializeSnake(coordinates, snakeNumber)
    End Sub
    Sub New(snakeStyleT As SnakeStyle, coordinates As Coord, snakeNoT As Long)
        isAI = True
        snakeStyle = snakeStyleT
        InitializeSnake(coordinates, snakeNoT)
    End Sub
    Sub New(snakeStyleT As SnakeStyle, coordinates As Coord, snakeNoT As Long, ByRef keys As Key())
        InitializeSnake(coordinates, snakeNoT)
        snakeStyle = snakeStyleT
        kUp.key = keys(0)
        kLeft.key = keys(1)
        kDown.key = keys(2)
        kRight.key = keys(3)
    End Sub
    Public Sub IncreaseScore()
        score += scoreMultiplier * 10 * snakeBlocks.Count
        SetScore()
    End Sub
    Public name As String

    Public Sub SetScore()
        gameScores(snakeNumber - 1).Text = name + ": " & score
    End Sub

    Private Sub SetDirection(d As Direction)
        If d = OppositeDirection(dOld) Then Return
        dNew = d
        If isAI Then Return
        If (dOld = dNew) Then Return
        If LastUpdateWasForceMove Then Return
        moveStopWatch.Restart()
        LastUpdateWasForceMove = True
        beenUpdated = True
        DetermineDelta()
        Move()
    End Sub
    Public Sub GoLeft()
        SetDirection(Direction.left)
    End Sub
    Public Sub GoRight()
        SetDirection(Direction.right)
    End Sub
    Public Sub GoUp()
        SetDirection(Direction.up)
    End Sub
    Public Sub GoDown()
        SetDirection(Direction.down)
    End Sub
    Public Sub Update()
        If dead Then Return
        If invicibilityTime > 0 Then invicibilityTime -= 1 Else invicibilityTime = 0
        If speedBonusTime > 0 Then
            speedBonusTime -= 1
        Else
            speedBonus = 0
            speedBonusTime = 0
        End If
        If isAI = False Then
            kUp.downNow = Keyboard.IsKeyDown(kUp.key)
            kLeft.downNow = Keyboard.IsKeyDown(kLeft.key)
            kDown.downNow = Keyboard.IsKeyDown(kDown.key)
            kRight.downNow = Keyboard.IsKeyDown(kRight.key)
            If kUp.downNow And kUp.downPrev = False Then
                GoUp()
            End If

            If kLeft.downNow And kLeft.downPrev = False Then
                GoLeft()
            End If

            If kDown.downNow And kDown.downPrev = False Then
                GoDown()
            End If

            If kRight.downNow And kRight.downPrev = False Then
                GoRight()
            End If

            kUp.downPrev = kUp.downNow
            kLeft.downPrev = kLeft.downNow
            kDown.downPrev = kDown.downNow
            kRight.downPrev = kRight.downNow
        End If
        If (moveStopWatch.ElapsedMilliseconds < (moveSpeed / (speedFactor + speedBonus)) / globalSpeed) Then Return
        beenUpdated = True
        If isAI Then AI()
        If dNew = dOld Then
            movesTravelledInSameDirection += 1
        Else
            movesTravelledInSameDirection = 0
        End If
        Dim nextCoord = PlusDelta(snakeBlocks(0).coord)
        snakeOccupied(nextCoord.x)(nextCoord.y) = CollisionType.snake
        LastUpdateWasForceMove = False
    End Sub

    Public Sub Grow(coordLastOld As Coord)
        snakeBlocks.Add(New SnakeBlock(ColourValue(snakeBlocks.Count - 1, snakeNumber, snakeStyle.snakePattern), coordLastOld.x, coordLastOld.y))
    End Sub
    Public Sub Move()

        If dead Then Return
        If beenUpdated = False Then Return
        DetermineDelta()
        Dim coordLastOld As Coord = snakeBlocks.Last.coord
        Dim coordFirstOld As Coord = snakeBlocks.First.coord
        snakeOccupied(snakeBlocks.Last.coord.x)(snakeBlocks.Last.coord.y) = CollisionType.none
        snakeGrid(snakeBlocks.Last.coord.x)(snakeBlocks.Last.coord.y).Fill = Brushes.Black
        snakeGrid(snakeBlocks.Last.coord.x)(snakeBlocks.Last.coord.y).Stroke = Brushes.Black
        snakeGrid(snakeBlocks.Last.coord.x)(snakeBlocks.Last.coord.y).StrokeThickness = 1
        'graph.FillRectangle(New SolidBrush(Color.Black), snakeBlocks.Last.coord.x * boxSize, snakeBlocks.Last.coord.y * boxSize, boxSize, boxSize)
        For i = snakeBlocks.Count - 1 To 1 Step -1
            snakeBlocks(i).coord = snakeBlocks(i - 1).coord
        Next
        snakeBlocks.First.coord += delta
        If growthQueue > 0 Then
            snakeOccupied(snakeBlocks.Last.coord.x)(snakeBlocks.Last.coord.y) = CollisionType.snake
            Grow(coordLastOld)
            growthQueue -= 1
        End If
        If growthQueue < 0 Then
            If snakeBlocks.Count() >= 2 Then
                SpawnFood(New EdibleSnake(New SolidColorBrush(snakeBlocks.Last.colour)), snakeBlocks.Last.coord)
                snakeOccupied(snakeBlocks.Last.coord.x)(snakeBlocks.Last.coord.y) = CollisionType.food
                snakeBlocks.RemoveAt(snakeBlocks.Count - 1)
                growthQueue += 1
            End If
        End If

        If snakeBlocks.First.coord.x < 0 Then snakeBlocks.First.coord.x = gridXCount
        If snakeBlocks.First.coord.y < 0 Then snakeBlocks.First.coord.y = gridYCount
        If snakeBlocks.First.coord.x > gridXCount Then snakeBlocks.First.coord.x = 0
        If snakeBlocks.First.coord.y > gridYCount Then snakeBlocks.First.coord.y = 0

        For i = 0 To foodList.Count - 1
            If snakeBlocks.First.coord = foodList(i).Coordinate Then
                foodList(i).Interact(Me)
                foodToRemove.Add(i)
                Debug.WriteLine("Worked")
            End If
        Next


            moveStopWatch.Restart()
            dOld = dNew
            beenUpdated = False
    End Sub
    Public Function GetBorderThickness() As Double
        If invicibilityTime > 0 Then Return 0.9
        If isTeamsEnabled Then Return 1
        Return 0
    End Function
    Public Function GetBorderBrush() As Brush
        If speedBonus > 0 And invicibilityTime > 0 Then

            Dim fiveColorLGB As LinearGradientBrush = New LinearGradientBrush()
            fiveColorLGB.StartPoint = New Point(0, 0)
            fiveColorLGB.EndPoint = New Point(1, 1)

            Dim blueGS As GradientStop = New GradientStop()
            blueGS.Color = Colors.Gray
            blueGS.Offset = 0.0
            fiveColorLGB.GradientStops.Add(blueGS)

            Dim orangeGS As GradientStop = New GradientStop()

            Dim redGS As GradientStop = New GradientStop()
            redGS.Color = Colors.Red
            redGS.Offset = 1.0
            fiveColorLGB.GradientStops.Add(redGS)
            Return fiveColorLGB
        End If
        If speedBonus > 0 Then
            Dim fiveColorLGB As LinearGradientBrush = New LinearGradientBrush()
            fiveColorLGB.StartPoint = New Point(0, 0)
            fiveColorLGB.EndPoint = New Point(1, 1)

            Dim blueGS As GradientStop = New GradientStop()
            blueGS.Color = Colors.Orange
            blueGS.Offset = 0.0
            fiveColorLGB.GradientStops.Add(blueGS)

            Dim orangeGS As GradientStop = New GradientStop()

            Dim redGS As GradientStop = New GradientStop()
            redGS.Color = Colors.Red
            redGS.Offset = 1.0
            fiveColorLGB.GradientStops.Add(redGS)
            Return fiveColorLGB
        End If

        If invicibilityTime > 0 Then Return Brushes.Gray
        If isTeamsEnabled Then Return New SolidColorBrush(ColourValue(teamNo * 30, 0, SnakePattern.rainbow))
        Return Brushes.Gainsboro
    End Function
    Public Function GetColour(index As Long) As Color
        If invicibilityTime > 0 Then Return HighlightColour(snakeBlocks(index).colour)
        Return snakeBlocks(index).colour
    End Function
    Public Function HighlightColour(colourDefault As Color) As Color
        Return Color.FromRgb(calcHighVal(colourDefault.R), calcHighVal(colourDefault.G), calcHighVal(colourDefault.B))
    End Function
    Public Function calcHighVal(val As Long) As Long
        val /= 1.75
        Dim valTemp As Long = 255 - val
        valTemp /= 2
        val += valTemp
        Return val
    End Function
    Public Shared Function ColourValue(input As Long, snakeNo As Long, snakePatternT As SnakePattern) As Color
        Dim R As Long = 255
        Dim G As Long = 255
        Dim B As Long = 255


        'RAIIIIIIIIIIIIIIINBBBBBBBBBBBBBBOOOOOOOOOOOOOWWWWWWWWWWSSSSSSS!

        Select Case snakePatternT
            Case SnakePattern.rainbow
                Dim rainbowOption As Long = snakeNo Mod 8
                Select Case rainbowOption
                    Case 0
                        CalcRainbowColour(input + snakeNo, G, B, R)
                    Case 1
                        CalcRainbowColour(input + snakeNo, R, G, B)
                    Case 2
                        CalcRainbowColour(input + snakeNo, B, G, R)
                    Case 3
                        CalcRainbowColour(input + snakeNo, G, B, R)
                    Case 4
                        CalcRainbowColour(input + snakeNo, R, B, G)
                    Case 5
                        CalcRainbowColour(input + snakeNo, G, R, B)
                    Case 6
                        CalcRainbowColour(input + snakeNo, B, R, G)
                    Case 7
                        CalcRainbowColour(input + snakeNo, R, G, B)
                    Case 8
                        CalcRainbowColour(input + snakeNo, B, R, G)
                End Select
            Case SnakePattern.stripe
                CalcRainbowColour(25.5 + snakeNo * 10, R, G, B)
                CalcStripeColour(input, R, G, B)
        End Select
        Return Color.FromRgb(R, G, B)
    End Function
    Private Shared Sub CalcStripeColour(ByVal input As Single, ByRef R As Long, ByRef G As Long, ByRef B As Long)
        Dim sineTemp As Single = Math.Sin(input / 0.8) * 100.0

        R += sineTemp
        If R > 255 Then R = 255
        If R < 0 Then R = 0
        G += sineTemp
        If G > 255 Then G = 255
        If G < 0 Then G = 0
        B += sineTemp
        If B > 255 Then B = 255
        If B < 0 Then B = 0
    End Sub
    Private Shared Sub CalcRainbowColour(ByVal input As Long, ByRef R As Long, ByRef G As Long, ByRef B As Long)
        Const Rate = 20
        input *= Rate
Begin:

        If input >= 1785 Then
            input -= 1530
            GoTo Begin
        End If
        Select Case input
            Case 0 To 255
                'White to Yellow'
                CCDown(B, input)
            Case 256 To 510
                'Yellow to Red'
                input -= 255
                B = 0
                CCDown(G, input)
            Case 511 To 765
                'Red to Purple'
                G = 0
                B = 0
                input -= 510
                CCUp(B, input)
            Case 766 To 1020
                'Purple to Blue'
                input -= 765
                G = 0
                CCDown(R, input)
            Case 1021 To 1275
                'Blue to Cyan'
                input -= 1020
                R = 0
                G = 0
                CCUp(G, input)
            Case 1276 To 1530
                'Cyan to Green'
                input -= 1275
                R = 0
                CCDown(B, input)
            Case 1531 To 1785
                'Green to Yellow'
                B = 0
                R = 0
                input -= 1530
                CCUp(R, input)
        End Select
    End Sub
    Private Shared Sub CCDown(ByRef colour As Long, ByRef input As Long)
        If input >= 255 Then
            colour = 0
            input -= 255
        Else
            colour -= input
            input = 0
        End If
    End Sub
    Private Shared Sub CCUp(ByRef colour As Long, ByRef input As Long)
        If input >= 255 Then
            colour = 255
            input -= 255
        Else
            colour += input
            input = 0
        End If
    End Sub
    Private Function OppositeDirection(d As Direction) As Direction
        Select Case d
            Case Direction.up
                Return Direction.down
            Case Direction.left
                Return Direction.right
            Case Direction.down
                Return Direction.up
            Case Direction.right
                Return Direction.left
        End Select
        Return -1
    End Function
    Public Sub DetermineDelta()
        Select Case dNew
            Case Direction.right
                delta.x = 1
                delta.y = 0
            Case Direction.left
                delta.x = -1
                delta.y = 0
            Case Direction.up
                delta.x = 0
                delta.y = -1
            Case Direction.down
                delta.x = 0
                delta.y = 1
        End Select
    End Sub
    Public Sub Kill()
        If dead = True Then Return
        dead = True
        numberDead += 1
        If singlePlayer Then Return
        For Each block In snakeBlocks
            block.colour = Colors.Gray
        Next
    End Sub
End Class
Public Enum Direction
    up = 0
    left = 1
    down = 2
    right = 3
End Enum