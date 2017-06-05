Public Class frmSnake
    Private Sub tmrGame_Tick(sender As Object, e As EventArgs) Handles tmrGame.Tick

        Dim r As Long = Rnd() * 1000
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
            foodList.RemoveAt(foodToRemove(i))
        Next
        foodToRemove.Clear()
        For i As Long = 0 To snakeList.Count - 1
            If i >= snakeList.Count Then Continue For
            If snakeList(i).dead Then Continue For
            For q As Long = 3 To snakeList(i).snakeBlocks.Count - 1
                If snakeList(i).snakeBlocks.First.coord = snakeList(i).snakeBlocks(q).coord Then
                    snakeList(i).Kill()
                    Debug.WriteLine("Block: " & q)
                End If
            Next
            For o As Long = 0 To snakeList.Count - 1
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
                snakeGrid(snakeList(i).snakeBlocks(q).coord.x)(snakeList(i).snakeBlocks(q).coord.y).BackColor = snakeList(i).snakeBlocks(q).colour
                snakeOccupied(snakeList(i).snakeBlocks(q).coord.x)(snakeList(i).snakeBlocks(q).coord.y) = CollisionType.snake
            Next
        Next
        If singlePlayer Then
            If snakeList.Count <= 0 Then GameEnd()
        Else
            If numberDead = snakeList.Count Then GameEnd(True)
            If numberDead = snakeList.Count - 1 Then GameEnd()
        End If
    End Sub

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        GameStart()
        SpawnFood(New NormalFood())
    End Sub

    Private Sub frmSnake_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Randomize()
        lblScore02.Text = "0"
        lblScore01.Text = "0"
    End Sub

End Class
