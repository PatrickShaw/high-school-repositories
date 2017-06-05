Public Class SnakeSettingControl
    Public snakeNo As Long = 0
    Public snakeStyle As SnakeStyle = New SnakeStyle(Brushes.Black, Brushes.Turquoise)
    Dim snakeTemp As Snake
    Sub New(snakeNoT As Long)
        snakeNo = snakeNoT
        snakeTemp = New Snake(snakeStyle, New Coord(gridWidth / 2, gridHeight / 2), snakeNo)
        snakeStyle.snakePattern = SnakePattern.rainbow
        snakeTemp.invicibilityTime = 0
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        ChangeRectPreview()
        txtTeamNo.Text = snakeNoT.ToString()
        txtPlayerName.Text = "Snake " & snakeNo
    End Sub
    Public Sub ChangeRectPreview()
        snakeTemp.Grow(New Coord(5, 5))
        snakeTemp.Grow(New Coord(5, 5))
        snakeTemp.Grow(New Coord(5, 5))
        snakeTemp.Grow(New Coord(5, 5))
        snakeTemp.Grow(New Coord(5, 5))
        snakeTemp.Grow(New Coord(5, 5))
        snakeTemp.Grow(New Coord(5, 5))
        snakeTemp.Grow(New Coord(5, 5))
        snakeTemp.Grow(New Coord(5, 5))
        snakeTemp.Grow(New Coord(5, 5))
        snakeTemp.Grow(New Coord(5, 5))
        snakeTemp.Grow(New Coord(5, 5))
        snakeTemp.Grow(New Coord(5, 5))
        rectSnakePreview.Fill = New SolidColorBrush(snakeTemp.GetColour(9))
        rectSnakePreview.StrokeThickness = snakeTemp.GetBorderThickness()
        rectSnakePreview.Stroke = snakeTemp.GetBorderBrush()
    End Sub
    Private Sub CheckIsNumeric(sender As TextBox, e As TextCompositionEventArgs)
        Dim result As Decimal
        If ((Decimal.TryParse(e.Text, result) = False)) Then
            e.Handled = True
        End If
    End Sub
    Private Sub txtTeamNo_PreviewTextInput(sender As Object, e As TextCompositionEventArgs) Handles txtTeamNo.PreviewTextInput
        CheckIsNumeric(sender, e)
    End Sub

    Private Sub cmbStyle_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles cmbStyle.SelectionChanged
        Debug.WriteLine(CStr(CType(cmbStyle.SelectedItem, ComboBoxItem).Content))
        Debug.WriteLine(CStr(CType(cmbStyle.SelectedItem, ComboBoxItem).Content))
        Debug.WriteLine(CStr(CType(cmbStyle.SelectedItem, ComboBoxItem).Content))
        Debug.WriteLine(CStr(CType(cmbStyle.SelectedItem, ComboBoxItem).Content))
        Debug.WriteLine(CStr(CType(cmbStyle.SelectedItem, ComboBoxItem).Content))

        Select Case CStr(CType(cmbStyle.SelectedItem, ComboBoxItem).Content)
            Case SnakePattern.rainbow.ToString()
                snakeStyle.snakePattern = SnakePattern.rainbow
            Case SnakePattern.stripe.ToString()
                snakeStyle.snakePattern = SnakePattern.stripe
        End Select
        ChangeRectPreview()
    End Sub

    Private Sub CheckBox_Checked(sender As Object, e As RoutedEventArgs)

    End Sub

    Private Sub txtTeamNo_TextChanged(sender As Object, e As TextChangedEventArgs) Handles txtTeamNo.TextChanged
        snakeTemp.teamNo = Val(txtTeamNo.Text)
        ChangeRectPreview()
    End Sub

    Private Sub chkComputer_Click(sender As Object, e As RoutedEventArgs) Handles chkComputer.Click
        If chkComputer.IsChecked Then
            lblPlayerNo.Content = "Snake " & snakeNo & ": (Computer)"
            If txtPlayerName.Text = "Snake " & snakeNo Or txtPlayerName.Text = "Player " & snakeNo Then txtPlayerName.Text = "Computer " & snakeNo
        Else
            lblPlayerNo.Content = "Snake " & snakeNo & ": (Player)"
            If txtPlayerName.Text = "Snake " & snakeNo Or txtPlayerName.Text = "Computer " & snakeNo Then txtPlayerName.Text = "Player " & snakeNo
        End If
    End Sub
End Class
