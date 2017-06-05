

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
Public NotInheritable Class Snake
    Const moveSpeed As Single = 10.0
    Dim movesTravelledInSameDirection As Long = 0
    Public score As Single = 0
    Public snakeNumber As Long
    Dim scoreMultiplier As Single = 1
    Public isAI As Boolean = False
    Public speedFactor As Single = 1
    Public dNew As Direction = Direction.right
    Public dOld As Direction = dNew
    Public kUp As Keys = Keys.W
    Public kLeft As Keys = Keys.A
    Public kDown As Keys = Keys.S
    Public kRight As Keys = Keys.D
    Public dead As Boolean = False
    Public snakeBlocks As List(Of SnakeBlock) = New List(Of SnakeBlock)
    Dim moveStopWatch As Stopwatch = New Stopwatch
    Public justAte As Boolean = False
    Dim lblScore As Label
    Public otherSnakes As List(Of Snake) = New List(Of Snake)
    Dim delta As Coord = New Coord(0, 0)
    Public Function CalcSpace(passes As Long, starterCoord As Coord)
        Dim coordsToBePassed As List(Of Coord) = New List(Of Coord)
        Dim coordsCheckedAlready As Boolean()() = New Boolean(gridXCount)() {}
        For x = 0 To gridYCount
            coordsCheckedAlready(x) = New Boolean(gridYCount) {}
        Next
        Dim points As Single = 0
        Dim space As Single = 0
        coordsToBePassed.Add(starterCoord)
        Dim futureCoordsToBePassed As List(Of Coord) = New List(Of Coord)
        coordsCheckedAlready(starterCoord.x)(starterCoord.y) = True
        For currentPass As Long = 1 To passes
            For i As Long = 0 To coordsToBePassed.Count - 1
                Select Case CheckCoordinatesFilled(coordsToBePassed(i))
                    Case CollisionType.snake
                        Continue For
                    Case CollisionType.none
                        'snakeGrid(coordsToBePassed(i).x)(coordsToBePassed(i).y).BackColor = ColourValue(currentPass * 2, 1)
                        space += 1
                    Case CollisionType.food
                        points -= 1.0 - (currentPass * (1.0 / CSng(passes)))
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
        For i = 0 To options.Count - 1
            Debug.WriteLine("")
            Debug.WriteLine(options(i))
        Next
        dNew = FindBestDOption(options)
    End Sub
    Private Function PlusDelta(oCoord As Coord) As Coord
        DetermineDelta()
        Return oCoord + delta
    End Function
    Private Function DirectionOptions() As List(Of Direction)
        ' Up, Left, Down, Right
        Dim directions As List(Of Direction) = New List(Of Direction)
        ' Directions in which future 
        Dim futureCollide As List(Of Direction) = New List(Of Direction)
        ' Directions in which the snake is compeletely surrounded
        Dim futureSurrounded As List(Of Direction) = New List(Of Direction)
        directions.AddRange({Direction.up, Direction.left, Direction.down, Direction.right})
        Dim optionsToRemove As List(Of Long) = New List(Of Long)
        For i = 0 To directions.Count - 1
            dNew = directions(i)
            If dNew = dOld And movesTravelledInSameDirection >= gridHeight Then
                optionsToRemove.Add(i)
                Continue For
            End If
            If CheckCoordinatesFilled(PlusDelta(snakeBlocks(0).coord)) = CollisionType.snake Then optionsToRemove.Add(i)
        Next
        If optionsToRemove.Count = 0 Then Return directions
        For i = optionsToRemove.Count - 1 To 0 Step -1
            directions.RemoveAt(optionsToRemove(i))
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
            DetermineDelta()
            count += CalcSpace(300, snakeBlocks.First.coord + delta)
            If count < lowestCount Then
                lowestCount = count
                chosenOption = options(i)
            End If
        Next
        Return chosenOption
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
        speedFactor += Rnd() * 0.05
        If temp = 1 Then
            snakeBlocks.Add(New SnakeBlock(ColourValue(snakeBlocks.Count - 1, snakeNumber), coordinates.x, coordinates.y))
            snakeBlocks.Add(New SnakeBlock(ColourValue(snakeBlocks.Count - 1, snakeNumber), coordinates.x - 1, coordinates.y))
            snakeBlocks.Add(New SnakeBlock(ColourValue(snakeBlocks.Count - 1, snakeNumber), coordinates.x - 2, coordinates.y))
        Else
            dNew = Direction.left
            snakeBlocks.Add(New SnakeBlock(ColourValue(snakeBlocks.Count - 1, snakeNumber), coordinates.x - 2, coordinates.y))
            snakeBlocks.Add(New SnakeBlock(ColourValue(snakeBlocks.Count - 1, snakeNumber), coordinates.x - 1, coordinates.y))
            snakeBlocks.Add(New SnakeBlock(ColourValue(snakeBlocks.Count - 1, snakeNumber), coordinates.x, coordinates.y))
        End If
        If isAI Then
            name = "Computer " & snakeNumber
        Else
            name = "Player " & snakeNumber
        End If
    End Sub
    Sub New(coordinates As Coord, snakeNoT As Long)
        isAI = True

        InitializeSnake(coordinates, snakeNoT)
    End Sub
    Sub New(coordinates As Coord, snakeNoT As Long, ByRef keys As Keys())
        InitializeSnake(coordinates, snakeNoT)
        kUp = keys.First
        kLeft = keys(1)
        kDown = keys(2)
        kRight = keys(3)
    End Sub
    Public Sub IncreaseScore()
        score += scoreMultiplier * 10 * snakeBlocks.Count
        SetScore()
    End Sub
    Public name As String

    Public Sub SetScore()
        frmSnake.lstScores.Items.Item(snakeNumber - 1) = name + ": " & score
    End Sub

    Private Sub SetDirection(d As Direction)
        If d = OppositeDirection(dOld) Then Return
        dNew = d
        If isAI Then Return
        If (dOld = dNew) Then Return
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
    Private Declare Function GetAsyncKeyState Lib "user32.dll" (ByVal vkey As Keys) As Keys
    Private Shared Function IsKeyDown(ByVal Key As Keys) As Boolean
        Return GetAsyncKeyState(Key)
    End Function
    Public Sub Update()
        If dead Then Return
        If isAI = False Then
            If (GetAsyncKeyState(kUp)) Then
                GoUp()
            End If

            If (GetAsyncKeyState(kLeft)) Then
                GoLeft()
            End If

            If (GetAsyncKeyState(kDown)) Then
                GoDown()
            End If

            If (GetAsyncKeyState(kRight)) Then
                GoRight()
            End If
        End If
        If (moveStopWatch.ElapsedMilliseconds < (moveSpeed / speedFactor)) Then Return

        If (snakeGrid.Last.Count <> gridWidth) Then Return
        If isAI Then AI()
        If dNew = dOld Then
            movesTravelledInSameDirection += 1
        Else
            movesTravelledInSameDirection = 0
        End If
        Dim nextCoord = PlusDelta(snakeBlocks(0).coord)
        snakeOccupied(nextCoord.x)(nextCoord.y) = CollisionType.snake
    End Sub


    Public Sub Move()

        If dead Then Return
        DetermineDelta()
        Dim coordLastOld As Coord = snakeBlocks.Last.coord
        Dim coordFirstOld As Coord = snakeBlocks.First.coord
        snakeOccupied(snakeBlocks.Last.coord.x)(snakeBlocks.Last.coord.y) = CollisionType.none
        snakeGrid(snakeBlocks.Last.coord.x)(snakeBlocks.Last.coord.y).BackColor = Color.Black
        For i = snakeBlocks.Count - 1 To 1 Step -1
            snakeBlocks(i).coord = snakeBlocks(i - 1).coord
        Next
        snakeBlocks.First.coord += delta
        If justAte = True Then
            snakeOccupied(snakeBlocks.Last.coord.x)(snakeBlocks.Last.coord.y) = CollisionType.snake
            snakeBlocks.Add(New SnakeBlock(ColourValue(snakeBlocks.Count - 1, snakeNumber), coordLastOld.x, coordLastOld.y))
            justAte = False
        End If
        If snakeBlocks.First.coord.x < 0 Then snakeBlocks.First.coord.x = gridXCount
        If snakeBlocks.First.coord.y < 0 Then snakeBlocks.First.coord.y = gridYCount
        If snakeBlocks.First.coord.x > gridXCount Then snakeBlocks.First.coord.x = 0
        If snakeBlocks.First.coord.y > gridYCount Then snakeBlocks.First.coord.y = 0
        For i = 0 To foodList.Count - 1
            If snakeBlocks.First.coord = foodList(i).coord Then
                foodList(i).Interact(Me)
                foodToRemove.Add(i)
            End If
        Next
        moveStopWatch.Restart()
        dOld = dNew
    End Sub
    Public Function ColourValue(input As Long, snakeNo As Long) As Color
        Dim R As Long = 255
        Dim G As Long = 255
        Dim B As Long = 255
        Const Rate = 20
        input *= Rate
Begin:
        If input > 1785 Then
            input -= 1530
            GoTo Begin
        End If
        'RAIIIIIIIIIIIIIIINBBBBBBBBBBBBBBOOOOOOOOOOOOOWWWWWWWWWWSSSSSSS!
        Select Case snakeNo
            Case 1
                CalculateColour(input + 130, R, G, B)
            Case 2
                CalculateColour(input + 130, B, G, R)
            Case 3
                CalculateColour(input + 130, G, B, R)
            Case 4
                CalculateColour(input + 50, R, B, G)
            Case 5
                CalculateColour(input + 50, G, R, B)
            Case 6
                CalculateColour(input + 50, B, R, G)
            Case 7
                CalculateColour(input + 512, R, G, B)
            Case 8
                CalculateColour(input + 512, B, R, G)
            Case 9
                CalculateColour(input + 512, G, B, R)
        End Select
        Return Color.FromArgb(R, G, B)
    End Function
    Private Sub CalculateColour(ByVal input As Long, ByRef R As Long, ByRef G As Long, ByRef B As Long)
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
            block.colour = Color.Gray
        Next
    End Sub
End Class
Public Enum Direction
    up = 0
    left = 1
    down = 2
    right = 3
End Enum