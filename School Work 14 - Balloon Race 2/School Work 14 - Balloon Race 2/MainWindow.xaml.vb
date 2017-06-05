Imports System.Windows.Threading

Class MainWindow
    Dim isPaused As Boolean = True

    Public tmrGameTime As DispatcherTimer = New DispatcherTimer()
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        tmrGameTime = New DispatcherTimer
        tmrGameTime.Interval = New TimeSpan(1)
        AddHandler tmrGameTime.Tick, AddressOf tmrGameTime_Tick
        tmrGameTime.Start()
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Public Class KeyV2
        Public key As Key
        Public previouslyDown As Boolean = False
        Public previouslyUp As Boolean = False
    End Class
    Public Class Player
        Public balloon As Image
        Public key1 As KeyV2
        Public key2 As KeyV2
        Public currentKey As KeyV2
        Public streak As Integer = 0
        Public score As Label
        Public name As String
        Public btn1 As Button
        Public btn2 As Button
        Public X As Single
        Public Sub New(balloonT As Image, keyT1 As Key, keyT2 As Key, scoreT As Label, nameT As String, btn1T As Button, btn2T As Button)
            balloon = balloonT
            key1 = New KeyV2
            key2 = New KeyV2
            key1.key = keyT1
            key2.key = keyT2
            currentKey = key1
            score = scoreT
            name = nameT
            btn1 = btn1T
            btn2 = btn2T

        End Sub
        Public Sub SwitchKey()
            If currentKey.key = key1.key Then
                currentKey = key2
                btn1.IsEnabled = False
                btn2.IsEnabled = True
            Else
                currentKey = key1
                btn1.IsEnabled = True
                btn2.IsEnabled = False
            End If
        End Sub
        Public Sub ResumePlayer()
            If (currentKey.key = key1.key) Then
                btn1.IsEnabled = True
            Else
                btn2.IsEnabled = True
            End If
        End Sub
        Public Sub PausePlayer()
            btn1.IsEnabled = False
            btn2.IsEnabled = False
        End Sub
    End Class
    Dim playerArray As Player()
    Private Sub frmBalloonRace_Load(sender As Object, e As EventArgs) Handles MyBase.Loaded
        playerArray = New Player(2) {New Player(picBalloon1, Key.Q, Key.W, lblScore1, "Player 1", btnQ, btnW), New Player(picBalloon2, Key.V, Key.B, lblScore2, "Player 2", btnV, btnB), New Player(picBalloon3, Key.O, Key.P, lblScore3, "Player 3", btnO, btnP)}
        ResetGame()
    End Sub
    Private Sub frmBalloonRace_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

    End Sub
    Private Sub CalcKeyV2State(ByRef keyV2 As KeyV2, i As Integer)
        If Keyboard.IsKeyDown(keyV2.key) Then
            keyV2.previouslyDown = True
            keyV2.previouslyUp = False
            If keyV2.key <> playerArray(i).currentKey.key Then playerArray(i).streak = 0
        Else
            keyV2.previouslyDown = False
            keyV2.previouslyUp = True
        End If
    End Sub
    Private Sub tmrGameTime_Tick()
        Me.Focus()
        Me.Activate()
        If (isPaused = True) Then
            Return
        End If
        For i As Integer = 0 To playerArray.Count - 1

            If Keyboard.IsKeyUp(playerArray(i).currentKey.key) And playerArray(i).currentKey.previouslyDown Then
                playerArray(i).streak += 1
                Canvas.SetLeft(playerArray(i).balloon, Canvas.GetLeft(playerArray(i).balloon) + playerArray(i).streak)
                playerArray(i).SwitchKey()
            End If
            CalcKeyV2State(playerArray(i).key1, i)
            CalcKeyV2State(playerArray(i).key2, i)
        Next

        For i As Integer = 0 To (playerArray.Count - 1)
            If (Canvas.GetLeft(playerArray(i).balloon) >= Canvas.GetLeft(rectFinish)) Then
                ResetGame()
                MsgBox(playerArray(i).name + " wins!")
                playerArray(i).score.Content = (Val(playerArray(i).score.Content.ToString()) + 1).ToString()
            End If
        Next
    End Sub
    Private Sub ResetGame()
        For i As Integer = 0 To (playerArray.Count - 1)
            Canvas.SetLeft(playerArray(i).balloon, 0)
            playerArray(i).streak = 0
            playerArray(i).currentKey = playerArray(i).key1
            playerArray(i).btn1.IsEnabled = False
            playerArray(i).btn2.IsEnabled = False
        Next
        isPaused = True
        mnuPause.IsEnabled = False
        mnuPause.Header = "Pause"
        tmrGameTime.IsEnabled = False
    End Sub

    Private Sub mnuPause_Click(sender As Object, e As EventArgs) Handles mnuPause.Click
        If (isPaused = False) Then
            For i As Integer = 0 To (playerArray.Count - 1)
                playerArray(i).PausePlayer()
            Next
            tmrGameTime.IsEnabled = False
            isPaused = True
            mnuPause.Header = "Resume"
        Else
            For i As Integer = 0 To (playerArray.Count - 1)
                playerArray(i).ResumePlayer()
            Next
            tmrGameTime.IsEnabled = True
            isPaused = False
            mnuPause.Header = "Pause"
        End If
    End Sub

    Private Sub mnuStart_Click(sender As Object, e As EventArgs) Handles mnuStart.Click
        For i As Integer = 0 To playerArray.Count - 1
            playerArray(i).ResumePlayer()
        Next
        isPaused = False
        tmrGameTime.IsEnabled = True
        mnuPause.IsEnabled = True
    End Sub

    Private Sub mnuQuit_Click(sender As Object, e As EventArgs) Handles mnuQuit.Click
        End
    End Sub



    Private Sub theWindow_SizeChanged(sender As Object, e As SizeChangedEventArgs) Handles theWindow.SizeChanged
        Canvas.SetLeft(rectFinish, theCanvas.ActualWidth - rectFinish.ActualWidth)
        rectFinish.Height = theCanvas.ActualHeight
    End Sub
End Class
