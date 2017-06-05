Public Class Form1
    Dim isRainbows As Boolean = False
    Dim r As Double = 0
    Dim g As Double = 1
    Dim b As Double = 2
    Dim rn As Boolean = False
    Dim gn As Boolean = False
    Dim bn As Boolean = False
    Private Sub bRainbow_Click(sender As Object, e As EventArgs) Handles bRainbow.Click
        If isRainbows = False Then
            isRainbows = True
            lblColour.Text = "RAINBOWS!!!!"
        Else
            isRainbows = False
        End If
    End Sub

    Private Sub timer_Tick(sender As Object, e As EventArgs) Handles timer.Tick
        If isRainbows = True Then
            CheckValue(rn, r, 0.92)
            CheckValue(gn, g, 0.465)
            CheckValue(bn, b, 1.542)
            lblColour.ForeColor = Color.FromArgb(0, Math.Floor(r), Math.Floor(g), Math.Floor(b))
            End If
    End Sub
    Private Sub CheckValue(ByRef colourn As Boolean, ByRef colourv As Double, ByRef delta As Double)
Check:
        If (colourv >= 254) Then
            colourn = True
            colourv -= delta
            GoTo Check
        ElseIf (colourv <= 1) Then
            colourn = False
            colourv += delta
            GoTo Check
        End If
        If (colourn = False) Then
            colourv += delta
        Else
            colourv -= delta
        End If
    End Sub

    Private Sub bYellow_Click(sender As Object, e As EventArgs) Handles bYellow.Click
        lblColour.ForeColor = Color.Yellow
        lblColour.Text = "YELLOW!"
    End Sub

    Private Sub bRed_Click(sender As Object, e As EventArgs) Handles bRed.Click
        lblColour.ForeColor = Color.Red
        lblColour.Text = "REDNESS!"
    End Sub

    Private Sub bGreen_Click(sender As Object, e As EventArgs) Handles bGreen.Click
        lblColour.ForeColor = Color.Green
        lblColour.Text = "GREENESS!"
    End Sub

    Private Sub bBlue_Click(sender As Object, e As EventArgs) Handles bBlue.Click
        lblColour.ForeColor = Color.Blue
        lblColour.Text = "BLUENESS!"
    End Sub

    Private Sub bPurple_Click(sender As Object, e As EventArgs) Handles bPurple.Click
        lblColour.ForeColor = Color.Purple
        lblColour.Text = "PURPLE!"
    End Sub
End Class
