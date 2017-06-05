Imports System.Windows.Threading
Imports System.Windows.Media.Effects

Class frmSnake
    Dim drawingContext As DrawingContext
    Private Sub tmrGame_Tick()
        Dim r As Long = Rnd() * 500
        If r = 1 Then
            SpawnSpecial()
        End If
        For i = 0 To foodList.Count - 1
            foodList(i).Update()
            If foodList(i).duration <= 0 Then foodToRemove.Add(i)
        Next

        For i = 0 To snakeList.Count - 1
            snakeList(i).Update()
        Next

        For i = 0 To snakeList.Count - 1
            snakeList(i).Move()
        Next

        foodToRemove.Sort()
        foodToRemove.Reverse()
        For i = 0 To foodToRemove.Count - 1
            Try
                foodList(foodToRemove(i)).Destruct()
                foodList.RemoveAt(foodToRemove(i))
            Catch
            End Try
        Next
        foodToRemove.Clear()
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
                For q As Long = 0 To snakeList(o).snakeBlocks.Count - 1
                    If snakeList(i).snakeBlocks.First.coord = snakeList(o).snakeBlocks(q).coord Then
                        snakeList(i).Kill()
                    End If
                Next
            Next
        Next
        For i = 0 To snakeList.Count - 1
            For q = snakeList(i).snakeBlocks.Count - 1 To 0 Step -1

                snakeGrid(snakeList(i).snakeBlocks(q).coord.x)(snakeList(i).snakeBlocks(q).coord.y).Fill = New SolidColorBrush(snakeList(i).GetColour(q))
                snakeGrid(snakeList(i).snakeBlocks(q).coord.x)(snakeList(i).snakeBlocks(q).coord.y).Stroke = snakeList(i).GetBorderBrush()
                snakeGrid(snakeList(i).snakeBlocks(q).coord.x)(snakeList(i).snakeBlocks(q).coord.y).StrokeThickness = snakeList(i).GetBorderThickness()
                snakeOccupied(snakeList(i).snakeBlocks(q).coord.x)(snakeList(i).snakeBlocks(q).coord.y) = CollisionType.snake
            Next
        Next



        Dim shapeOutlinePen As New Pen(Brushes.Black, 2)
        shapeOutlinePen.Freeze()

        ' Create a DrawingGroup
        Dim dGroup As New DrawingGroup()

        ' Obtain a DrawingContext from 
        ' the DrawingGroup.
        Using dc As DrawingContext = dGroup.Open()
            For x As Long = 0 To gridXCount - 1
                For y As Long = 0 To gridYCount - 1
                    dc.DrawRectangle(snakeGrid(x)(y).Fill, New Pen(snakeGrid(x)(y).Stroke, snakeGrid(x)(y).StrokeThickness), New Rect(x * boxSize, y * boxSize, boxSize, boxSize))
                Next
            Next

        End Using

        ' Display the drawing using an image control.
        Dim theImage As New Image()
        Dim dImageSource As New DrawingImage(dGroup)
        theImage.Source = dImageSource

        ViewPort.Child = theImage




        If singlePlayer Then
            If snakeList.Count <= numberDead Then GameEnd()
        Else
            If numberDead = snakeList.Count Then GameEnd(True)
            If numberDead = snakeList.Count - 1 Then GameEnd()
        End If
    End Sub

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        Restart()
        lstScores.Items.Clear()

        GameStart()

        gameCanvas.Width = gridWidth * boxSize
        gameCanvas.Height = gridHeight * boxSize

        For i = 0 To numberOfFoodz - 1
            SpawnFood(New NormalFood())
        Next

        For i As Long = 0 To gameScores.Count() - 1
            lstScores.Items.Add(gameScores(i))
        Next

        tmrGame.Start()
    End Sub
    Public Sub Restart()
        For Each RectArray In snakeGrid
            For Each Rect In RectArray
                Rect.Fill = Brushes.Black
            Next
        Next
    End Sub
    Private Sub frmSnake_Load(sender As Object, e As EventArgs) Handles MyBase.Loaded
        tmrGame.IsEnabled = False
        AddHandler tmrGame.Tick, AddressOf tmrGame_Tick
        tmrGame.Interval = TimeSpan.FromMilliseconds(1)
        snakeGrid = New Rectangle(gridXCount)() {}
        For i As Long = 0 To gridXCount
            snakeGrid(i) = New Rectangle(gridYCount) {}
            For o As Long = 0 To gridYCount
                snakeGrid(i)(o) = New Rectangle()
                snakeGrid(i)(o).SnapsToDevicePixels = True
                snakeGrid(i)(o).Fill = Brushes.Black
                snakeGrid(i)(o).StrokeThickness = 0
                snakeGrid(i)(o).Stroke = Brushes.Black
                snakeGrid(i)(o).Width = boxSize
                snakeGrid(i)(o).Height = boxSize
                'gameCanvas.Children.Add(snakeGrid(i)(o))
                'Canvas.SetLeft(snakeGrid(i)(o), i * boxSize)
                'Canvas.SetTop(snakeGrid(i)(o), o * boxSize)
            Next
        Next
        gameCanvas.Width = gridWidth * boxSize
        gameCanvas.Height = gridHeight * boxSize

        Randomize()
    End Sub

End Class
