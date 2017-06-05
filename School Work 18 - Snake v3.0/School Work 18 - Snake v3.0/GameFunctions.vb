Imports System.Windows.Threading

Public Module GameFunctions
    Public tmrGame As DispatcherTimer = New DispatcherTimer()
    Public Sub SetDifficulty()

    End Sub
    Public Function GridifyCoords(coordinate As Coord) As Coord
        If coordinate.x >= 0 Then
            coordinate.x = coordinate.x Mod (gridWidth)
        Else
            coordinate.x = (gridWidth) + (coordinate.x Mod gridWidth)
        End If
        If coordinate.y >= 0 Then
            coordinate.y = coordinate.y Mod (gridWidth)
        Else
            coordinate.y = (gridWidth) + (coordinate.y Mod (gridWidth))
        End If
        Return coordinate
    End Function
    Public Sub GameStart()
        tmrGame.IsEnabled = True
        numberDead = 0
        globalSpeed = 1
        snakeOccupied = New CollisionType(gridXCount)() {}
        For x As Long = 0 To snakeOccupied.Length - 1
            snakeOccupied(x) = New CollisionType(gridYCount) {}
            For y As Long = 0 To snakeOccupied(x).Length - 1
                snakeGrid(x)(y).Fill = Brushes.Black
                snakeGrid(x)(y).StrokeThickness = 1
                snakeGrid(x)(y).Stroke = Brushes.Black
                snakeOccupied(x)(y) = CollisionType.none
            Next
        Next
        foodList.Clear()
        For i = 0 To snakeList.Count() - 1
            snakeList(i).Reset(New Coord(gridWidth / 2 - 1, gridHeight / 2 - 10 + i * 4))
            If snakeList(i).isAI Then numberOfComputers += 1 Else numberOfUsers += 1
        Next
        gameScores = New TextBlock(numberOfPlayers - 1) {}
        For i = 0 To numberOfPlayers - 1
            gameScores(i) = New TextBlock()
            snakeList(i).SetOtherSnake(snakeList)
            snakeList(i).SetScore()
        Next
        If numberOfPlayers = 1 Then singlePlayer = True Else singlePlayer = False
        tmrGame.Start()
    End Sub
    Public Sub GameEnd(Optional draw As Boolean = False)

        tmrGame.Stop()
        tmrGame.IsEnabled = False
        Dim snakeHiScoreIndex As Long = 0
        If singlePlayer Then
            MsgBox("Game Over")
        Else
            If draw Then
                MsgBox("Draw! No wins the title of Survivor!")
            End If
            Dim highestScore As Single = 0
            For i = 0 To snakeList.Count - 1
                With snakeList(i)
                    If .score > highestScore Then
                        highestScore = .score
                        snakeHiScoreIndex = i
                    End If
                End With
            Next
            For Each snake In snakeList
                If snake.dead = False Then MsgBox(snake.name + " wins for surviving the longest!")
            Next
            Try
                MsgBox(snakeList(snakeHiScoreIndex).name + " wins for having the highest points: " & snakeList(snakeHiScoreIndex).score)
            Catch
            End Try
        End If
        firstGame = False
        foodList.Clear()
        foodToRemove.Clear()
    End Sub
    Public Sub SpawnSpecial()
        Dim r As Long = Rnd() * 4
        Select Case r
            Case 0
                SpawnFood(New FattyFood)
            Case 1
                SpawnFood(New ShortenFood)
            Case 2
                SpawnFood(New FastFood)
            Case 3
                SpawnFood(New InvicibilityFood)
            Case 4
                SpawnFood(New RandomFood)
        End Select
    End Sub
    Public Sub SpawnFood(ByRef food As Food)
Begin:
        Dim x As Long = Rnd() * gridXCount
        Dim y As Long = Rnd() * gridYCount
        If snakeOccupied(x)(y) <> CollisionType.none Then GoTo Begin
        food.Coordinate = New Coord(x, y)
        snakeOccupied(x)(y) = CollisionType.food
        foodList.Add(food)
    End Sub
    Public Sub SpawnFood(ByRef food As Food, c As Coord)
        food.Coordinate = New Coord(c.x, c.y)
        snakeOccupied(c.x)(c.y) = CollisionType.food
        foodList.Add(food)
    End Sub
End Module
