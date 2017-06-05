Public Class PongPanel
    Public vel As Vector2
    Public rect As Rect
    Public oldPos As Vector2
    Public panel As Rectangle
    Sub New(ByRef panelT As Rectangle)
        panel = panelT
        rect.pos.x = Canvas.GetLeft(panel)
        rect.pos.y = Canvas.GetTop(panel)
        rect.width = panel.ActualWidth
        rect.height = panel.ActualHeight
    End Sub
    Public Sub ResetPanel()
        rect.pos.y = (frmPong.GameCanvasProp.Height / 2.0) + (panel.Height / 2.0)
        Canvas.SetTop(panel, rect.pos.y)
    End Sub
    Public Sub UpdatePos()
        oldPos.x = rect.pos.x
        oldPos.y = rect.pos.y
        rect.pos.y += vel.y
        rect.pos.x += vel.x
        rect.height = panel.ActualHeight
        If (rect.pos.y < Canvas.GetTop(frmPong.GameCanvasProp) Or rect.Bottom() > frmPong.GameCanvasProp.ActualHeight) Then
            rect.pos.y = oldPos.y
        End If
        Canvas.SetTop(panel, rect.pos.y)
        Canvas.SetLeft(panel, rect.pos.x)
        CollisionCheck()
    End Sub
    Public Sub CollisionCheck()
        For Each Ball In frmPong.ballList
            If (rect.Intersects(Ball.rect) = True) Then
                Ball.vel.x *= -1
                Ball.vel.y += vel.y * 0.05
            End If
        Next
    End Sub
End Class

Public Class Ball
    Public vel As Vector2
    Public rect As Rect
    Public panel As Rectangle
    Dim ballSpeed As Double = 2
    Sub New(ByRef panelT As Rectangle, lengthT As Integer)
        panel = panelT
        panel.IsEnabled = True
        rect.pos.x = frmPong.GameCanvasProp.Width / 2.0
        rect.pos.y = frmPong.GameCanvasProp.Height / 2.0
        rect.width = lengthT
        rect.height = lengthT
        panel.Width = lengthT
        panel.Height = lengthT
        Canvas.SetLeft(panel, rect.pos.x)
        Canvas.SetTop(panel, rect.pos.y)
        panel.Visibility = Visibility.Visible
        panel.Fill = New SolidColorBrush(Color.FromRgb(255, 255, 255))
        vel.x = ballSpeed
        vel.y = Rnd() Mod ballSpeed
        Dim xDirection As Integer = Rnd() Mod 1
        If (xDirection = 1) Then
            vel.x *= -1.0
        End If
        Dim yDirection As Integer = Rnd() Mod 1
        If (yDirection = 1) Then
            yDirection *= -1.0
        End If
        frmPong.GameCanvasProp.Children.Add(panel)
    End Sub
    Public Sub UpdatePos()
        If (rect.pos.y < Canvas.GetTop(frmPong.GameCanvasProp) Or rect.Bottom() > frmPong.GameCanvasProp.ActualHeight) Then
            vel.y *= -1
        End If
        vel.y *= 0.99999
        rect.pos.x += vel.x * speedFactor
        rect.pos.y += vel.y * speedFactor
        Canvas.SetLeft(panel, rect.pos.x)
        Canvas.SetTop(panel, rect.pos.y)
    End Sub
End Class
Enum GameType
    PVP
    Coop
End Enum
Public Module Properties
    Public noBalls As Integer = 1
    Public speedFactor As Double = 1
    Dim gameType As GameType
    Public score As Double = 0
    Public name1 As String = "Player 1"
    Public name2 As String = "Player 2"
    Public P1Score As Integer = 0
    Public P2Score As Integer = 0
    Public HiScores As List(Of String) = New List(Of String)
    Public Sub AddHiScore()
        Dim entry As String
        entry = score
        Select Case (score)
            Case 1 To 9
                entry = "000000" & score & " , " + name1 + " & " + name2
            Case 10 To 99
                entry = "00000" & score & " , " + name1 + " & " + name2
            Case 100 To 999
                entry = "0000" & score & " , " + name1 + " & " + name2
            Case 1000 To 9999
                entry = "000" & score & " , " + name1 + " & " + name2
            Case 10000 To 99999
                entry = "00" & score & " , " + name1 + " & " + name2
            Case 100000 To 999999
                entry = "0" & score & " , " + name1 + " & " + name2
        End Select
        HiScores.Add(entry)
        HiScores.Sort()
        If (HiScores.Count > 50) Then
            HiScores.RemoveAt(0)
        End If
    End Sub
    Public Sub ResetScores()
        HiScores.Clear()
    End Sub
    Public Sub IncreaseScore()
        score += (Math.Pow(speedFactor, 1.02) * noBalls) * 0.1
        frmPong.lblScoreProp.Content = Math.Round(score, 0).ToString()
    End Sub
End Module