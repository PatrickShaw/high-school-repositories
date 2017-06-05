Public Class Form1
    Dim stopWatch As New Stopwatch
    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        stopWatch.Start()
        timTimer.Enabled = True
    End Sub

    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
        stopWatch.Stop()
        timTimer.Stop()
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        stopWatch.Reset()
    End Sub

    Private Sub btnQuit_Click(sender As Object, e As EventArgs) Handles btnQuit.Click
        End
    End Sub

    Private Sub timTimer_Tick(sender As Object, e As EventArgs) Handles timTimer.Tick
        lblStopWatch.Text = Format(stopWatch.ElapsedMilliseconds / 1000, "Fixed")
    End Sub
End Class
