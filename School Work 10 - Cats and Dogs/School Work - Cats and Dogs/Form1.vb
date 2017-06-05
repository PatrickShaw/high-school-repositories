Imports System.IO
Public Class Game
    Dim turn As Player = Player.One
    Dim boxArray As PictureBox(,)
    Dim CheckTypeArray As Player(,)
    Dim turnsTaken As Integer = 0
    Enum Player
        One
        Two
        None
    End Enum
    Private Sub Game_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        boxArray = New PictureBox(2, 2) {{PictureBox1, PictureBox4, PictureBox7}, {PictureBox2, PictureBox5, PictureBox8}, {PictureBox3, PictureBox6, PictureBox9}}
        CheckTypeArray = New Player(2, 2) {{Player.None, Player.None, Player.None}, {Player.None, Player.None, Player.None}, {Player.None, Player.None, Player.None}}
        lblName1.Text = Config.Player1Name
        lblName2.Text = Config.Player2Name
        Dim myAssembly As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly()
        Dim stream As Stream
        If (Config.isCharacter1Default = True) Then
            Config.isCharacter1Default = False
            stream = myAssembly.GetManifestResourceStream("School_Work___Cats_and_Dogs.cat.PNG")
            Config.Character1 = New Bitmap(stream)
        End If
        If (Config.isCharacter2Default = True) Then
            Config.isCharacter2Default = False
            stream = myAssembly.GetManifestResourceStream("School_Work___Cats_and_Dogs.dog.PNG")
            Config.Character2 = New Bitmap(stream)
        End If
        picAvatar1.Image = Config.Character1
        picAvatar2.Image = Config.Character2
        picTurn.Image = Config.Character1
    End Sub
    Private Sub PickBox(ByRef box As PictureBox, ByRef checkType As Player)
        If (checkType <> Player.None) Then
            Return
        End If
        turnsTaken += 1
        Select Case (turn)
            Case Player.One
                box.Image = Config.Character1
                checkType = Player.One
                picTurn.Image = Config.Character2
                turn = Player.Two
            Case Player.Two
                box.Image = Config.Character2
                checkType = Player.Two
                picTurn.Image = Config.Character1
                turn = Player.One
        End Select
        CheckWinner()
        If (turnsTaken >= 9) Then
            MsgBox("Draw!")
            Reset()
        End If
    End Sub
    Private Sub CheckWinner()
        For i As Integer = 0 To 2
            Dim hInARow As Integer = 0
            Dim hCheckingFor As Player = CheckTypeArray(0, i)
            'MsgBox("(0, " & i & ")" & hCheckingFor)
            Dim vInARow As Integer = 0
            Dim vCheckingFor As Player = CheckTypeArray(i, 0)

            For o As Integer = 0 To 2
                'Horizontal Check'
                If (hCheckingFor.Equals(CheckTypeArray(o, i)) And hCheckingFor <> Player.None) Then
                    hInARow += 1
                End If
                'Vertical Check'
                If (vCheckingFor.Equals(CheckTypeArray(i, o)) And vCheckingFor <> Player.None) Then
                    vInARow += 1
                End If
            Next
            'If there are 3 in a row horizontally, someone has won'
            If (hInARow >= 3) Then
                DecideWinner(hCheckingFor)
                'MsgBox("H")
                Return
            End If
            If (vInARow >= 3) Then
                DecideWinner(vCheckingFor)
                Return
            End If
        Next


        Dim dCheckingFor1 As Player = CheckTypeArray(0, 0)
        Dim dInARow1 As Integer = 1
        If (dCheckingFor1 = CheckTypeArray(1, 1)) Then
            dInARow1 += 1
        End If
        If (dCheckingFor1 = CheckTypeArray(2, 2)) Then
            dInARow1 += 1
        End If
        Dim dCheckingFor2 As Player = CheckTypeArray(2, 0)
        Dim dInARow2 As Integer = 1
        If (dCheckingFor2 = CheckTypeArray(1, 1)) Then
            dInARow2 += 1
        End If
        If (dCheckingFor2 = CheckTypeArray(0, 2)) Then
            dInARow2 += 1
        End If
        If (dInARow1 >= 3) Then
            DecideWinner(dCheckingFor1)
            'MsgBox("D1")
            Return
        End If
        If (dInARow2 >= 3) Then
            'MsgBox("D2")
            DecideWinner(dCheckingFor2)
            Return
        End If
    End Sub
    Public Sub LoadNewSettings()
        picAvatar1.Image = Config.Character1
        picAvatar2.Image = Config.Character2
        lblName1.Text = Config.Player1Name
        lblName2.Text = Config.Player2Name
        Select Case (turn)
            Case Player.One
                picTurn.Image = Config.Character1
            Case Player.Two
                picTurn.Image = Config.Character2
        End Select
    End Sub
    Private Sub DecideWinner(winner As Player)
        Select Case winner
            Case Player.One
                MsgBox(Config.Player1Name + " wins!")
                lblPlayerScore1.Text = Val(lblPlayerScore1.Text) + 1
                Reset()
            Case Player.Two
                MsgBox(Config.Player2Name + " wins!")
                lblPlayerScore2.Text = Val(lblPlayerScore2.Text) + 1
                Reset()
        End Select
    End Sub
    Private Sub Reset()
        CheckTypeArray = New Player(2, 2) {{Player.None, Player.None, Player.None}, {Player.None, Player.None, Player.None}, {Player.None, Player.None, Player.None}}
        For i As Integer = 0 To 2
            For o As Integer = 0 To 2
                boxArray(i, o).Image = Nothing
            Next
        Next
        turn = Player.One
        picTurn.Image = Config.Character1
        turnsTaken = 0
    End Sub
    Private Sub FullReset()
        lblPlayerScore1.Text = "0"
        lblPlayerScore2.Text = "0"
        Reset()
    End Sub
    Private Sub PictureBox9_Click(sender As Object, e As EventArgs) Handles PictureBox9.Click
        PickBox(PictureBox9, CheckTypeArray(2, 2))
    End Sub
    Private Sub PictureBox8_Click(sender As Object, e As EventArgs) Handles PictureBox8.Click
        PickBox(PictureBox8, CheckTypeArray(1, 2))
    End Sub
    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click
        PickBox(PictureBox7, CheckTypeArray(0, 2))
    End Sub
    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        PickBox(PictureBox6, CheckTypeArray(2, 1))
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        PickBox(PictureBox5, CheckTypeArray(1, 1))
    End Sub
    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        PickBox(PictureBox4, CheckTypeArray(0, 1))
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        PickBox(PictureBox3, CheckTypeArray(2, 0))
    End Sub
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        PickBox(PictureBox2, CheckTypeArray(1, 0))
    End Sub
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        PickBox(PictureBox1, CheckTypeArray(0, 0))
    End Sub

    Private Sub btnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
        Me.Hide()
        frmSettings.Show()
    End Sub

    Private Sub btnRestartGame_Click(sender As Object, e As EventArgs) Handles btnRestartGame.Click
        Reset()
    End Sub

    Private Sub btnResetScores_Click(sender As Object, e As EventArgs) Handles btnResetScores.Click
        FullReset()
    End Sub

    Private Sub btnQuit_Click(sender As Object, e As EventArgs) Handles btnQuit.Click
        End
    End Sub
End Class
