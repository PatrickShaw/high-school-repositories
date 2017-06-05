Imports System.IO

Public Class frmBunnyCatcher
    Public Shared score As Integer = 0
    Public Shared multiplier As Integer = 1
    Shared multiplierWatch As Stopwatch = New Stopwatch
    Shared stopWatch As Stopwatch = New Stopwatch
    Dim bunny As Bunny = New Bunny
    Dim kirby As Kirby = New Kirby
    Private Sub Reset()
        lblScore.Text = score
        lblMultiplier.Text = multiplier
        lblTimeLeft.Text = "0.00"
        stopWatch.Reset()
        multiplierWatch.Reset()
        tmrGameTick.Enabled = False
        kirby.PauseEntity()
        bunny.PauseEntity()
    End Sub
    Private Sub Start()
        score = 0
        multiplier = 1
        lblScore.Text = score
        lblMultiplier.Text = multiplier
        lblTimeLeft.Text = "40.00"
        stopWatch.Start()
        multiplierWatch.Start()
        tmrGameTick.Enabled = True
        bunny.ResumeEntity()
        kirby.ResumeEntity()
    End Sub
    Private Sub frmBunnyCatcher_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bunny.picture = picCat
        kirby.picture = picKirby
        Dim HiScFile As StreamReader = File.OpenText("HiScores.txt")
        Do While HiScFile.Peek <> -1
            lstHiScores.Items.Add(HiScFile.ReadLine())
        Loop
        bunny.PauseEntity()
        kirby.PauseEntity()
        HiScFile.Close()
        Reset()
    End Sub

    Private Sub frmBunnyCatcher_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim HiScFile2 As StreamWriter = File.CreateText("HiScores.txt")
        For Each Name As Object In lstHiScores.Items
            HiScFile2.WriteLine(Name)
        Next
        HiScFile2.Close()
    End Sub

    Private Sub tmrGameTick_Tick(sender As Object, e As EventArgs) Handles tmrGameTick.Tick
        If (multiplierWatch.ElapsedMilliseconds >= 10000) Then
            multiplier += 2
            bunny.IncreaseSpeed(1)
            kirby.IncreaseSpeed(3)
            multiplierWatch.Restart()
        End If
        Dim stringTemp As String = score
        If (stopWatch.ElapsedMilliseconds >= 40000) Then
            Select Case (score)
                Case 1 To 9
                    stringTemp = "00" & score
                Case 11 To 99
                    stringTemp = "00" & score
                Case 101 To 999
                    stringTemp = "0" & score
                Case 1001 To 9999
                    stringTemp = score
            End Select
            stringTemp = stringTemp + " , " + txtName.Text
            lstHiScores.Items.Add(stringTemp)
            If (lstHiScores.Items.Count > 50) Then
                lstHiScores.Items.RemoveAt(0)
            End If
            Reset()
        End If
        lblTimeLeft.Text = Math.Round((40000.0 - stopWatch.ElapsedMilliseconds) / 1000.0, 2)
        lblMultiplier.Text = multiplier
        lblScore.Text = score

        'Change Position'
        bunny.picture.Left += bunny.velocity.x
        bunny.picture.Top += bunny.velocity.y
        kirby.picture.Left += kirby.velocity.x
        kirby.picture.Top += kirby.velocity.y

        bunny.CollisionCheck()
        kirby.CollisionCheck()
    End Sub

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        If (txtName.Text.Length = 0) Then
            MsgBox("Please enter a name.")
            Return
        End If
        Start()
    End Sub

    Private Sub picCat_Click(sender As Object, e As EventArgs) Handles picCat.Click
        bunny.Clicked()
    End Sub

    Private Sub picKirby_Click(sender As Object, e As EventArgs) Handles picKirby.Click
        kirby.Clicked()
        kirby.IncreaseSpeed(1)
    End Sub
End Class
