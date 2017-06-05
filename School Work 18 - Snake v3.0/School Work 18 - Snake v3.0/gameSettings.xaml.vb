Public Class gameSettings
    Dim pregameSnakeList As List(Of SnakeSettingControl) = New List(Of SnakeSettingControl)
    Private Sub btnPlay_Click(sender As Object, e As RoutedEventArgs) Handles btnPlay.Click
        'If isTeamsEnabled = True And Val(txtNoTeams.Text) <= 1 Then
        '    MessageBox.Show("You must have more than 1 team.")
        '    Return
        'End If
        'If Val(txtNoUsers.Text) < 0 Then
        '    MessageBox.Show("You cannot have a negative number of players.")
        '    Return
        'End If
        'If Val(txtNoComps.Text) < 0 Then
        '    MessageBox.Show("You cannot have a negative number of computers.")
        '    Return
        'End If
        'If numberOfComputers = 0 And numberOfUsers = 0 Then
        '    MessageBox.Show("You need at least 1 player or computer to start the game.")
        'End If

        ChangeDimensions()
        Dim snakes As List(Of Snake) = New List(Of Snake)
        For Each preSnake In pregameSnakeList
            If String.IsNullOrEmpty(preSnake.txtPlayerName.Text) Then
                MessageBox.Show("Snake " & preSnake.snakeNo & "is missing a name")
                Return
            End If
            numberOfPlayers += 1
            If preSnake.chkComputer.IsChecked Then
                numberOfComputers += 1
                snakes.Add(New Snake(preSnake.snakeStyle, New Coord(gridWidth / 2, gridHeight / 2), preSnake.snakeNo))
            Else
                numberOfUsers += 1
                snakes.Add(New Snake(preSnake.snakeStyle, New Coord(gridWidth / 2, gridHeight / 2), preSnake.snakeNo, keyForPlayer(numberOfUsers - 1)))
            End If
            snakes.Last.name = preSnake.txtPlayerName.Text
            snakes.Last.teamNo = Val(preSnake.txtTeamNo.Text)
        Next
        snakeList = snakes
        Dim frmGame As frmSnake = New frmSnake()
        frmGame.Show()
        Me.Close()
    End Sub

    Private Sub rdbTeams_Checked(sender As Object, e As RoutedEventArgs) Handles rdbTeams.Checked
        isTeamsEnabled = True
        'txtNoTeams.IsReadOnly = False
        'vScrollTeams.IsEnabled = True
        For Each preSnake In pregameSnakeList
            preSnake.ChangeRectPreview()
        Next
    End Sub
    Private Sub rdbFFA_Checked(sender As Object, e As RoutedEventArgs) Handles rdbFFA.Checked
        isTeamsEnabled = False
        'txtNoTeams.IsReadOnly = True
        'vScrollTeams.IsEnabled = False
        For Each preSnake In pregameSnakeList
            preSnake.ChangeRectPreview()
        Next
    End Sub
    Private Sub CheckIsNumeric(sender As TextBox, e As TextCompositionEventArgs)
        Dim result As Decimal
        If ((Decimal.TryParse(e.Text, result) = False)) Then
            e.Handled = True
        End If
    End Sub
    Private Sub txtNoUsers_PreviewTextInput(sender As Object, e As TextCompositionEventArgs) Handles txtNoUsers.PreviewTextInput, txtNoTeams.PreviewTextInput, txtWidth.PreviewTextInput, txtHeight.PreviewTextInput
        CheckIsNumeric(sender, e)
    End Sub

    Private Sub txtNoUsers_TextChanged(sender As Object, e As TextChangedEventArgs) Handles txtNoUsers.TextChanged
        Try
            numberOfUsers = Val(txtNoUsers.Text)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtNoComps_TextChanged(sender As Object, e As TextChangedEventArgs) Handles txtNoComps.TextChanged
        Try
            numberOfComputers = Val(txtNoComps.Text)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtNoTeams_TextChanged(sender As Object, e As TextChangedEventArgs) Handles txtNoTeams.TextChanged
        Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnAddSnake_Click(sender As Object, e As RoutedEventArgs) Handles btnAddSnake.Click
        pregameSnakeList.Add(New SnakeSettingControl(pregameSnakeList.Count() + 1))
        snakeStack.Children.Add(pregameSnakeList.Last)
    End Sub

    Private Sub txtWidth_TextChanged(sender As Object, e As TextChangedEventArgs) Handles txtWidth.TextChanged
        gridWidth = Val(txtWidth.Text)
        ChangeDimensions()
    End Sub
    Private Sub ChangeDimensions()
        Try
            gridXCount = gridWidth - 1
            gridYCount = gridHeight - 1
            totalSpace = gridXCount * gridYCount
            snakeOccupied = New CollisionType(gridXCount)() {}
            For x As Long = 0 To snakeOccupied.Length - 1
                snakeOccupied(x) = New CollisionType(gridYCount) {}
                For y As Long = 0 To snakeOccupied(x).Length - 1
                    snakeOccupied(x)(y) = CollisionType.none
                Next
            Next
        Catch
        End Try
    End Sub
    Private Sub txtHeight_TextChanged(sender As Object, e As TextChangedEventArgs) Handles txtHeight.TextChanged
        gridHeight = Val(txtHeight.Text)
        ChangeDimensions()
    End Sub

    Private Sub txtSnakeLength_TextChanged(sender As Object, e As TextChangedEventArgs) Handles txtSnakeLength.TextChanged
        Try
            snakeStartingLength = Math.Abs(Val(txtSnakeLength.Text))
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtSnakeLength_PreviewTextInput(sender As Object, e As TextCompositionEventArgs) Handles txtSnakeLength.PreviewTextInput
        CheckIsNumeric(sender, e)
    End Sub

    Private Sub txtSnakeLength_Copy_PreviewTextInput(sender As Object, e As TextCompositionEventArgs) Handles txtFoodPieces.PreviewTextInput
        CheckIsNumeric(sender, e)
    End Sub

    Private Sub txtFoodPieces_TextChanged(sender As Object, e As TextChangedEventArgs) Handles txtFoodPieces.TextChanged
        Try
            numberOfFoodz = Math.Abs(Val(txtFoodPieces.Text))
        Catch ex As Exception

        End Try
    End Sub
End Class
