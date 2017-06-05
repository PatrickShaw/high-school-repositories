Imports System.Windows.Threading

Public Class frmSnake

    Dim temp As Polygon = New Polygon()
    Private Sub tmrGame_Tick()
        Dim r As Long = Rnd() * 100
        For i As Long = 0 To snakeList.Count - 1
            snakeList(i).PreUpdate()
        Next
        If r = 1 Then
            SpawnSpecial()
        End If

        For i = 0 To foodList.Count - 1
            If foodList(i).initializeMe Then
                foodList(i).initializeMe = False
                Canvas.SetLeft(foodList(i).rect, foodList(i).Coordinate.x * boxSize)
                Canvas.SetTop(foodList(i).rect, foodList(i).Coordinate.y * boxSize)
            End If
        Next
        For i = 0 To foodList.Count - 1
            foodList(i).Update()
            If foodList(i).duration <= 0 Then foodList(i).Destruct()
            If foodList(i).distructMe Then
                foodToRemove.Add(i)
            End If
        Next
        foodToRemove.Sort()
        foodToRemove.Reverse()
        For i As Long = foodToRemove.Count() - 1 To 0 Step -1
            Try
                gameCanvas.Children.Remove(foodList(foodToRemove(i)).rect)
                foodList.RemoveAt(foodToRemove(i))
            Catch
            End Try
        Next
        foodToRemove.Clear()
        For i = 0 To snakeList.Count - 1
            snakeList(i).Update()
        Next

        For i = 0 To snakeList.Count - 1
            snakeList(i).Move()
        Next

        For i As Long = 0 To snakeList.Count - 1
            If snakeList(i).invicibilityTime > 0 Then Continue For
            If i >= snakeList.Count Then Continue For
            If snakeList(i).dead Then Continue For
            For q As Long = 3 To snakeList(i).snakeBlocks.Count - 1
                If snakeList(i).snakeBlocks.First.coord = snakeList(i).snakeBlocks(q).coord Then
                    snakeList(i).Kill()
                End If
            Next
            For o As Long = 0 To snakeList.Count - 1
                If (snakeList(i).teamNo = snakeList(o).teamNo) Then Continue For
                If i = o Then Continue For
                Dim done As Boolean = False
                For q As Long = 0 To snakeList(o).snakeBlocks.Count - 1
                    If done = True Then Continue For
                    If snakeList(i).snakeBlocks.First.coord = snakeList(o).snakeBlocks.First.coord And snakeList(i).dead = False And snakeList(o).dead = False Then
                        snakeList(i).Kill()
                        snakeList(o).Kill()
                        done = True
                        Continue For
                    End If
                    If snakeList(i).snakeBlocks.First.coord = snakeList(o).snakeBlocks(q).coord Then
                        If snakeList(o).dead = False Then snakeList(o).IncreaseScore(10000)
                        snakeList(i).Kill()
                    End If
                Next
            Next
        Next
        For i = 0 To snakeList.Count - 1
            snakeList(i).ReUpdate()
            For q = snakeList(i).snakeBlocks.Count - 1 To 0 Step -1
                snakeOccupied(snakeList(i).snakeBlocks(q).coord.x)(snakeList(i).snakeBlocks(q).coord.y) = CollisionType.snake
            Next
        Next
        If singlePlayer Then
            If snakeList.Count <= numberDead Then GameEnd()
        Else
            If numberDead = snakeList.Count Then GameEnd(True)
            If numberDead = snakeList.Count - 1 Then GameEnd()
        End If
    End Sub

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        lstScores.Items.Clear()
        gameCanvas.Children.Clear()
        GameStart()

        gameCanvas.Width = gridWidth * boxSize
        gameCanvas.Height = gridHeight * boxSize

        For i = 0 To numberOfFoodz - 1
            SpawnFood(New NormalFood())
        Next
        For i As Long = 0 To gameScores.Count() - 1
            lstScores.Items.Add(gameScores(i))
        Next
        If lstMatchesWon.Items.Count() = 0 Then
            For i As Long = 0 To matchesWon.Count - 1

            Next
        End If
        tmrGame.Start()
    End Sub
    Private Sub frmSnake_Load(sender As Object, e As EventArgs) Handles MyBase.Loaded
        gameWindowOpened = True
        temp.Fill = Brushes.AliceBlue
        gameCanvas.Children.Add(temp)
        gameCanvas.Background = Brushes.Black
        GameCanvasPublic = gameCanvas
        tmrGame.IsEnabled = False
        AddHandler tmrGame.Tick, AddressOf tmrGame_Tick
        tmrGame.Interval = TimeSpan.FromMilliseconds(1)
        gameCanvas.Width = gridWidth * boxSize
        gameCanvas.Height = gridHeight * boxSize
        matchesWon = New TextBlock(snakeList.Count - 1) {}
        For i As Long = 0 To snakeList.Count() - 1
            matchesWon(i) = New TextBlock()
            matchesWon(i).Text = snakeList(i).name + ", " + snakeList(i).matchesWon.ToString()
            lstMatchesWon.Items.Add(matchesWon(i))
        Next
        Randomize(1)
    End Sub

    Private Sub gameCanvas_MouseUp(sender As Object, e As MouseButtonEventArgs) Handles gameCanvas.MouseUp
        Dim p As Point = Mouse.GetPosition(gameCanvas)
        temp.Points.Add(p)
    End Sub

    Private Sub Window_Closed(sender As Object, e As EventArgs)
        gameWindowOpened = False
    End Sub

    Private Sub btnClose_Click(sender As Object, e As RoutedEventArgs) Handles btnClose.Click
        Close()
    End Sub

    Private Sub btnResetScores_Click(sender As Object, e As RoutedEventArgs) Handles btnResetScores.Click
        For i As Long = 0 To snakeList.Count() - 1
            snakeList(i).matchesWon = 1
        Next
        lstScores.Items.Clear()
        gameCanvas.Children.Clear()
    End Sub
End Class
