Public Class Form1
    Dim LCDButtons As Button()
    Dim CurrentLabels As Label()
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LCDButtons = {btnChangeColour, btnChangeColour2, btnZero, btnOne, btnTwo, btnThree, btnFour, btnFive, btnSix, btnSeven, btnEight, btnNine}
        ResetLCD()
        SwitchButtons()
    End Sub
    Private Sub ChangeNumber(labelChanged As Label(), color As Color)
        ResetLCD()
        CurrentLabels = labelChanged
        For Each lbl In labelChanged
            lbl.BackColor = color
        Next
    End Sub
    Private Sub ResetLCD()
        lblBotLeft.BackColor = Color.Transparent
        lblBotRight.BackColor = Color.Transparent
        lblBotMid.BackColor = Color.Transparent
        lblMidMid.BackColor = Color.Transparent
        lblTopLeft.BackColor = Color.Transparent
        lblTopRight.BackColor = Color.Transparent
        lblTopMid.BackColor = Color.Transparent
    End Sub
    Private Sub btnOne_Click(sender As Object, e As EventArgs) Handles btnOne.Click
        ChangeNumber({lblTopRight, lblBotRight}, Color.Black)
    End Sub

    Private Sub btnTwo_Click(sender As Object, e As EventArgs) Handles btnTwo.Click
        ChangeNumber({lblTopMid, lblTopRight, lblMidMid, lblBotLeft, lblBotMid}, Color.Purple)
    End Sub

    Private Sub btnThree_Click(sender As Object, e As EventArgs) Handles btnThree.Click
        ChangeNumber({lblTopMid, lblTopRight, lblMidMid, lblBotRight, lblBotMid}, Color.Blue)
    End Sub

    Private Sub btnFour_Click(sender As Object, e As EventArgs) Handles btnFour.Click
        ChangeNumber({lblTopLeft, lblTopRight, lblMidMid, lblBotRight}, Color.Cyan)
    End Sub

    Private Sub btnFive_Click(sender As Object, e As EventArgs) Handles btnFive.Click
        ChangeNumber({lblTopMid, lblTopLeft, lblMidMid, lblBotRight, lblBotMid}, Color.Green)
    End Sub

    Private Sub btnSix_Click(sender As Object, e As EventArgs) Handles btnSix.Click
        ChangeNumber({lblTopLeft, lblTopMid, lblMidMid, lblBotRight, lblBotLeft, lblBotMid}, Color.Yellow)
    End Sub

    Private Sub btnSeven_Click(sender As Object, e As EventArgs) Handles btnSeven.Click
        ChangeNumber({lblTopMid, lblTopRight, lblBotRight}, Color.Orange)
    End Sub

    Private Sub btnEight_Click(sender As Object, e As EventArgs) Handles btnEight.Click
        ChangeNumber({lblTopMid, lblTopRight, lblTopLeft, lblMidMid, lblBotRight, lblBotLeft, lblBotMid}, Color.Red)
    End Sub

    Private Sub btnNine_Click(sender As Object, e As EventArgs) Handles btnNine.Click
        ChangeNumber({lblTopLeft, lblTopMid, lblTopRight, lblMidMid, lblBotRight}, Color.Black)
    End Sub

    Private Sub SwitchButtons()
        For Each btn In LCDButtons
            If (btn.Enabled = True) Then
                btn.Enabled = False
                btnSwitch.Text = "Turn On"
            Else
                btn.Enabled = True
                btnSwitch.Text = "Turn Off"
            End If
        Next
    End Sub
    Private Sub btnSwitch_Click(sender As Object, e As EventArgs) Handles btnSwitch.Click
        ResetLCD()
        SwitchButtons()
    End Sub

    Private Sub btnZero_Click(sender As Object, e As EventArgs) Handles btnZero.Click
        ChangeNumber({lblTopLeft, lblTopMid, lblTopRight, lblBotLeft, lblBotMid, lblBotRight}, Color.Purple)
    End Sub

    Function RandomColourValue() As Integer
        Return CInt(Int(255 * Rnd()))
    End Function
    Private Sub btnChangeColour_Click(sender As Object, e As EventArgs) Handles btnChangeColour.Click
        Try
            For Each lbl In CurrentLabels
                lbl.BackColor = Color.FromArgb(RandomColourValue(), RandomColourValue(), RandomColourValue())
            Next
        Catch
        End Try
    End Sub

    Private Sub btnQuit_Click(sender As Object, e As EventArgs) Handles btnQuit.Click
        End
    End Sub

    Private Sub btnChangeColour2_Click(sender As Object, e As EventArgs) Handles btnChangeColour2.Click
        Dim colourTemp As Color = Color.FromArgb(RandomColourValue(), RandomColourValue(), RandomColourValue())
        Try
            For Each lbl In CurrentLabels
                lbl.BackColor = colourTemp
            Next
        Catch
        End Try
    End Sub
End Class
