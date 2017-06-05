Public Module GameFunctions

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
        frmSnake.btnStart.Enabled = False
        frmSnake.lstScores.Enabled = False
        frmSnake.lblScore02.Text = 0
        frmSnake.lblScore01.Text = 0
        numberDead = 0
        If firstGame Then
            snakeGrid = New Panel(gridXCount)() {}
            snakeOccupied = New CollisionType(gridXCount)() {}
            For x As Long = 0 To snakeGrid.Length - 1
                snakeGrid(x) = New Panel(gridYCount) {}
                snakeOccupied(x) = New CollisionType(gridYCount) {}
                For y As Long = 0 To snakeGrid(x).Length - 1
                    snakeOccupied(x)(y) = CollisionType.none
                    snakeGrid(x)(y) = New Panel()
                    snakeGrid(x)(y).BackColor = Color.Black
                    snakeGrid(x)(y).AutoSize = False
                    snakeGrid(x)(y).Left = x * boxSize + 16.0
                    snakeGrid(x)(y).Top = y * boxSize + 16.0
                    snakeGrid(x)(y).Width = boxSize
                    snakeGrid(x)(y).Height = boxSize
                Next
                frmSnake.Controls.AddRange(snakeGrid(x))
            Next
        Else
            For x As Long = 0 To snakeGrid.Length - 1
                For y As Long = 0 To snakeGrid(x).Length - 1
                    snakeGrid(x)(y).BackColor = Color.Black
                Next
            Next
        End If
        Dim currentPlayerNumber = 1
        numberOfPlayers = numberOfComputers + numberOfUsers
        For i = 1 To numberOfUsers
            snakeList.Add(New Snake(New Coord(gridWidth / 2 - 1, gridHeight / 2 - 10 + currentPlayerNumber * 4), currentPlayerNumber, keyForPlayer(i - 1))) ', Keys.W, Keys.A, Keys.S, Keys.D))
            frmSnake.lstScores.Items.Add("")
            currentPlayerNumber += 1
        Next
        For i = 1 To numberOfComputers
            snakeList.Add(New Snake(New Coord(gridWidth / 2 - 1, gridHeight / 2 - 10 + currentPlayerNumber * 4), currentPlayerNumber)) ', Keys.W, Keys.A, Keys.S, Keys.D))
            frmSnake.lstScores.Items.Add("")
            currentPlayerNumber += 1
        Next
        For i = 0 To numberOfPlayers - 1
            snakeList(i).SetOtherSnake(snakeList)
            snakeList(i).SetScore()
        Next
        If numberOfPlayers = 1 Then singlePlayer = True Else singlePlayer = False
        frmSnake.tmrGame.Enabled = True
    End Sub
    Public Sub GameEnd(Optional draw As Boolean = False)
        frmSnake.tmrGame.Enabled = False
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
        frmSnake.lstScores.Enabled = True
        foodList.Clear()
        foodToRemove.Clear()
        snakeList.Clear()
        frmSnake.btnStart.Enabled = True
    End Sub
    Public Sub SpawnSpecial()
        Dim r As Long = Rnd() * 2
        Select Case r
            Case 0
                SpawnFood(New ShortenFood)
            Case 1
                SpawnFood(New SlowFood)
            Case 2
                SpawnFood(New FastFood)
        End Select
    End Sub
    Public Sub SpawnFood(ByRef food As Food)
Begin:
        Dim x As Long = Rnd() * gridXCount
        Dim y As Long = Rnd() * gridYCount
        If snakeOccupied(x)(y) <> CollisionType.none Then GoTo Begin
        food.coord = New Coord(x, y)
        snakeOccupied(x)(y) = CollisionType.food
        foodList.Add(food)
    End Sub
End Module
