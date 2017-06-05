Class MainWindow
    Public w As Long = 40
    Public h As Long = 20
    Public noMines As Long = 100
    Public gameEnded As Boolean = False
    Public mineGrid As Mine()()
    Dim random As Random = New Random()
    Public firstClick As Boolean = True
    Dim possibilitiesList As New List(Of Coord)
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        btnRestart_Click(Nothing, Nothing)
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As RoutedEventArgs) Handles btnCancel.Click
        End
    End Sub

    Private Sub btnRestart_Click(sender As Object, e As RoutedEventArgs) Handles btnRestart.Click
        gameEnded = False
        possibilitiesList.Clear()
        firstClick = True
        mineGrid = New Mine(w)() {}
        mineCanvas.Width = (w + 1) * 60
        mineCanvas.Height = (h + 1) * 60
        For x As Long = 0 To w
            mineGrid(x) = New Mine(h) {}
            For y As Long = 0 To h
                Dim mineT As Mine = New Mine()
                mineT.c.x = x
                mineT.c.y = y
                mineT.hasMine = False
                mineCanvas.Children.Add(mineT)
                mineGrid(x)(y) = mineT
                Canvas.SetLeft(mineGrid(x)(y), x * 60)
                Canvas.SetTop(mineGrid(x)(y), y * 60)
                AddHandler mineGrid(x)(y).MouseLeftButtonUp, AddressOf FREAKING_SLPOSIONS
                AddHandler mineGrid(x)(y).MouseRightButtonUp, AddressOf btnRightClick
                possibilitiesList.Add(New Coord(x, y))
            Next
        Next
    End Sub
    Public Enum Direction
        up = 0
        left = 1
        down = 2
        right = 3
    End Enum
    Public Function DetermineDelta(directionT As Direction)
        Dim delta As Coord
        Select Case directionT
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
        Return delta
    End Function
    Public Function PlusDelta(coord As Coord, directionT As Direction)
        Return coord + DetermineDelta(directionT)
    End Function
    Private Sub btnRightClick(sender As Object, e As RoutedEventArgs)
        Dim mineT As Mine = TryCast(sender, Mine)
        If mineT.clicked = ClickType.clicked Then Return
        Select Case mineT.clicked
            Case ClickType.notClicked
                mineT.clicked = ClickType.possibility
                mineT.txbNo.Text = "?"
                mineT.txbNo.Foreground = Brushes.DarkBlue
            Case ClickType.possibility
                mineT.clicked = ClickType.flagged
                mineT.txbNo.Text = "+"
                mineT.txbNo.Foreground = Brushes.DarkRed
            Case ClickType.flagged
                mineT.clicked = ClickType.notClicked
                mineT.txbNo.Text = ""
        End Select
        mineGrid(mineT.c.x)(mineT.c.y) = mineT
    End Sub
    Private Sub FREAKING_SLPOSIONS(sender As Object, e As RoutedEventArgs)
        If gameEnded Then Return
        Dim mineT As Mine = DirectCast(sender, Mine)
        If mineT.clicked = ClickType.flagged Or mineT.clicked = ClickType.possibility Then Return
        If firstClick Then
Begin:
            For i As Long = 0 To noMines - 1
                Dim n As Long = random.Next(0, possibilitiesList.Count)
                Dim x As Long = possibilitiesList(n).x
                Dim y As Long = possibilitiesList(n).y
                possibilitiesList.RemoveAt(n)
                If New Coord(x, y) = mineT.c Then GoTo Begin
                mineGrid(x)(y).hasMine = True
                firstClick = False
            Next
        End If

        Reveal(mineT.c)
        If mineT.hasMine Then
            MsgBox("SPLOSIONS. GAMEOVER")
            GameOver()
            Return
        Else
            ChainReveal(mineT.c, True)
            CheckWon()
        End If
    End Sub
    Private Sub ChainReveal(c As Coord, Optional firstShot As Boolean = False)
        Reveal(c)
        If NoMinesAdjacent(c.x, c.y) <> 0 Then Return
        SubChainReveal(c, New Coord(-1, -1))
        SubChainReveal(c, New Coord(0, -1))
        SubChainReveal(c, New Coord(1, -1))
        SubChainReveal(c, New Coord(-1, 0))
        SubChainReveal(c, New Coord(1, 0))
        SubChainReveal(c, New Coord(-1, 1))
        SubChainReveal(c, New Coord(0, 1))
        SubChainReveal(c, New Coord(1, 1))
    End Sub
    Private Sub SubChainReveal(c As Coord, d As Coord)
        Dim dc As Coord = c + d
        If (0 <= dc.x And dc.x <= w And 0 <= dc.y And dc.y <= h) = False Then Return
        If mineGrid(dc.x)(dc.y).hasMine = False And mineGrid(dc.x)(dc.y).clicked = ClickType.notClicked Then
            ChainReveal(dc)
        End If
    End Sub
    Public Function NoMinesAdjacent(x As Long, y As Long) As Long
        Dim numT As Long = 0
        If TryHasMine(x - 1, y - 1) Then numT += 1
        If TryHasMine(x, y - 1) Then numT += 1
        If TryHasMine(x + 1, y - 1) Then numT += 1
        If TryHasMine(x - 1, y) Then numT += 1
        If TryHasMine(x + 1, y) Then numT += 1
        If TryHasMine(x - 1, y + 1) Then numT += 1
        If TryHasMine(x, y + 1) Then numT += 1
        If TryHasMine(x + 1, y + 1) Then numT += 1
        Return numT
    End Function
    Public Function TryHasMine(x As Long, y As Long) As Boolean
        If x < 0 Or y < 0 Or x > w Or y > h Then Return False
        If mineGrid(x)(y).hasMine Then Return True
        Return False
    End Function
    Public Sub Reveal(c As Coord)
        If mineGrid(c.x)(c.y).clicked <> ClickType.notClicked Then Return
        Dim mineT As Mine = mineGrid(c.x)(c.y)
        mineT.clicked = ClickType.clicked
        If mineT.hasMine Then
            mineT.rctMine.Fill = Brushes.Black
        Else
            mineT.rctMine.Fill = Brushes.White
            If NoMinesAdjacent(c.x, c.y) <> 0 Then
                mineT.txbNo.Text = NoMinesAdjacent(c.x, c.y)
                Select Case mineT.txbNo.Text
                    Case "1"
                        mineT.txbNo.Foreground = Brushes.Aqua
                    Case "2"
                        mineT.txbNo.Foreground = Brushes.Green
                    Case "3"
                        mineT.txbNo.Foreground = Brushes.Red
                    Case "4"
                        mineT.txbNo.Foreground = Brushes.DarkBlue
                    Case "5"
                        mineT.txbNo.Foreground = Brushes.Orange
                    Case "6"
                        mineT.txbNo.Foreground = Brushes.Cyan
                    Case "7"
                        mineT.txbNo.Foreground = Brushes.DarkOrange
                    Case "8"
                        mineT.txbNo.Foreground = Brushes.Violet
                End Select
            End If
        End If
        mineGrid(c.x)(c.y) = mineT
    End Sub
    Public Sub GameOver()
        gameEnded = True
        For x As Long = 0 To w
            For y As Long = 0 To h
                Reveal(New Coord(x, y))
            Next
        Next
    End Sub
    Public Sub CheckWon()
        For x As Long = 0 To w
            For y As Long = 0 To h
                If (mineGrid(x)(y).hasMine = False And (mineGrid(x)(y).clicked <> ClickType.clicked)) Then Return
            Next
        Next
        MsgBox("YOU WIN!")
        GameOver()
    End Sub
End Class
