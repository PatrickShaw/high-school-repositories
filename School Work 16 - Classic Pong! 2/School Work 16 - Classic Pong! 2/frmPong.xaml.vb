Imports System.Windows.Threading

Class frmPong
    Public Shared GameCanvasProp As Canvas = GameCanvasProp
    Public Shared lblScoreProp As Label = lblScoreProp

    Dim tmrGameTick As DispatcherTimer = New DispatcherTimer()
    Public Shared ballList As List(Of Ball) = New List(Of Ball)
    Public Shared leftPong As PongPanel
    Public Shared rightPong As PongPanel
    Dim AHeld As Boolean
    Dim DHeld As Boolean
    Dim LeftHeld As Boolean
    Dim RightHeld As Boolean
    Const newBallTime As Integer = 1000
    Dim newBall As Integer = newBallTime
    Sub New()

        tmrGameTick.Interval = TimeSpan.FromMilliseconds(0.5)
        AddHandler tmrGameTick.Tick, AddressOf tmrGameTick_Tick
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Public Sub Start()
        For i As Integer = 0 To noBalls - 1
            ballList.Add(New Ball(New Rectangle(), (Rnd() * 8) + 12))
        Next
        score = 0

        tmrGameTick.Start()

    End Sub
    Private Sub tmrGameTick_Tick()
        Me.Focus()
        IncreaseScore()
        newBall -= 1
        If (newBall <= 0) Then
            ballList.Add(New Ball(New Rectangle(), (Rnd() Mod 8) + 12))
            noBalls += 1
            newBall = newBallTime
        End If
        speedFactor += 0.001
        If AHeld = True Then leftPong.vel.y = 12
        If DHeld = True Then leftPong.vel.y = -12
        If AHeld = False And DHeld = False Then leftPong.vel.y = 0
        If LeftHeld = True Then rightPong.vel.y = 12
        If RightHeld = True Then rightPong.vel.y = -12
        If LeftHeld = False And RightHeld = False Then rightPong.vel.y = 0
        leftPong.UpdatePos()
        rightPong.UpdatePos()
        Try
            For Each ball In ballList
                ball.UpdatePos()
                If (ball.rect.Right() < Canvas.GetLeft(GameCanvasProp)) Then
                    Winner(2)
                End If
                If (ball.rect.pos.x > GameCanvasProp.ActualWidth) Then
                    Winner(1)
                End If
            Next
        Catch

        End Try
    End Sub
    Private Sub Winner(playerNo As Integer)
        tmrGameTick.Stop()
        Select Case playerNo
            Case 1
                P1Score += 1
                lblName01.Content = name1 + " " & P1Score
                MsgBox(name1 + " wins!")
            Case 2
                P2Score += 1
                lblName02.Content = P2Score & " " + name2
                MsgBox(name2 + " wins!")
        End Select
        ResetGame()
    End Sub
    Public Sub ResetGame()
        score = 0
        speedFactor = 1
        noBalls = 1
        For Each Ball In ballList
            gameCanvas.Children.Remove(Ball.panel)
        Next
        ballList.Clear()
        Start()
    End Sub
    Private Sub frmPong_Load(sender As Object, e As EventArgs) Handles MyBase.Loaded
        GameCanvasProp = gameCanvas
        lblScoreProp = lblScore
        leftPong = New PongPanel(pnlPongLeft)
        rightPong = New PongPanel(pnlPongRight)
        GameCanvasProp.Visibility = Windows.Visibility.Visible
        lblName01.Content = name1 + " " & P1Score
        lblName02.Content = P2Score & " " + name2
        Start()
    End Sub

    Private Sub frmPong_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.Key = Key.A Then AHeld = True
        If e.Key = Key.D Then DHeld = True

        If e.Key = Key.Left Then LeftHeld = True
        If e.Key = Key.Right Then RightHeld = True
    End Sub

    Private Sub frmPong_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
        If e.Key = Key.A Then AHeld = False
        If e.Key = Key.D Then DHeld = False

        If e.Key = Key.Left Then LeftHeld = False
        If e.Key = Key.Right Then RightHeld = False
    End Sub
End Class
