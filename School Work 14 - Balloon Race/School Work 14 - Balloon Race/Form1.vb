Public Class frmBalloonRace
    Dim isPaused As Boolean = True
    Public Class KeysV2
        Public key As Keys
        Public previouslyPressed As Boolean = False
    End Class
    Public Class Player
        Public balloon As PictureBox
        Public key1 As KeysV2
        Public key2 As KeysV2
        Public currentKey As KeysV2
        Public streak As Integer = 0
        Public score As Label
        Public name As String
        Public btn1 As Button
        Public btn2 As Button
        Public Sub New(balloonT As PictureBox, keyT1 As Keys, keyT2 As Keys, scoreT As Label, nameT As String, btn1T As Button, btn2T As Button)
            balloon = balloonT
            key1 = New KeysV2
            key2 = New KeysV2
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
                btn1.Enabled = False
                btn2.Enabled = True
            Else
                currentKey = key1
                btn1.Enabled = True
                btn2.Enabled = False
            End If
        End Sub
        Public Sub ResumePlayer()
            If (currentKey.key = key1.key) Then
                btn1.Enabled = True
            Else
                btn2.Enabled = True
            End If
        End Sub
        Public Sub PausePlayer()
            btn1.Enabled = False
            btn2.Enabled = False
        End Sub
    End Class
    Dim playerArray As Player()
    Private Sub frmBalloonRace_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        playerArray = New Player(2) {New Player(picBalloon1, Keys.Q, Keys.W, lblScore1, "Player 1", btnQ, btnW), New Player(picBalloon2, Keys.V, Keys.B, lblScore2, "Player 2", btnV, btnB), New Player(picBalloon3, Keys.O, Keys.P, lblScore3, "Player 3", btnO, btnP)}
        ResetGame()
    End Sub
    Private Sub frmBalloonRace_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

    End Sub

    Private Declare Function GetAsyncKeyState Lib "user32.dll" (ByVal vkey As Integer) As Integer
    Private Sub tmrGameTime_Tick(sender As Object, e As EventArgs) Handles tmrGameTime.Tick
        Me.Focus()
        Me.Activate()
        If (isPaused = True) Then
            Return
        End If
        For i As Integer = 0 To playerArray.Count - 1
            If GetAsyncKeyState(playerArray(i).currentKey.key) And playerArray(i).currentKey.previouslyPressed = False Then
                playerArray(i).streak += 1
                playerArray(i).balloon.Left += playerArray(i).streak
                playerArray(i).SwitchKey()
            Else
                playerArray(i).streak = 0
            End If
            playerArray(i).key1.previouslyPressed = False
            playerArray(i).key2.previouslyPressed = False
            If GetAsyncKeyState(playerArray(i).key1.key) Then
                playerArray(i).key1.previouslyPressed = True
            End If
            If GetAsyncKeyState(playerArray(i).key2.key) Then
                playerArray(i).key2.previouslyPressed = True
            End If
        Next
        For i As Integer = 0 To (playerArray.Count - 1)
            If (playerArray(i).balloon.Left >= pnlFinish.Left) Then
                ResetGame()
                MsgBox(playerArray(i).name + " wins!")
                playerArray(i).score.Text = Val(playerArray(i).score.Text) + 1
            End If
        Next
    End Sub
    Private Sub ResetGame()
        For i As Integer = 0 To (playerArray.Count - 1)
            playerArray(i).balloon.Left = 23
            playerArray(i).streak = 0
            playerArray(i).currentKey = playerArray(i).key1
            playerArray(i).btn1.Enabled = False
            playerArray(i).btn2.Enabled = False
        Next
        isPaused = True
        mnuPause.Enabled = False
        mnuPause.Text = "Pause"
        tmrGameTime.Enabled = False
    End Sub

    Private Sub mnuPause_Click(sender As Object, e As EventArgs) Handles mnuPause.Click
        If (isPaused = False) Then
            For i As Integer = 0 To (playerArray.Count - 1)
                playerArray(i).PausePlayer()
            Next
            tmrGameTime.Enabled = False
            isPaused = True
            mnuPause.Text = "Resume"
        Else
            For i As Integer = 0 To (playerArray.Count - 1)
                playerArray(i).ResumePlayer()
            Next
            tmrGameTime.Enabled = True
            isPaused = False
            mnuPause.Text = "Pause"
        End If
    End Sub

    Private Sub mnuStart_Click(sender As Object, e As EventArgs) Handles mnuStart.Click
        For i As Integer = 0 To playerArray.Count - 1
            playerArray(i).ResumePlayer()
        Next
        isPaused = False
        tmrGameTime.Enabled = True
        mnuPause.Enabled = True
    End Sub

    Private Sub mnuQuit_Click(sender As Object, e As EventArgs) Handles mnuQuit.Click
        End
    End Sub
End Class
