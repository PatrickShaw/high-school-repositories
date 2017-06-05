Public Class frmWorldTimeConvertor
    Dim Difference1 As Single = 0
    Dim Difference2 As Single = 0
    Private Sub frmWorldTimeConvertor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbLocation.Items.Add("VIC, ACT, NSW, QLD, TAS")
        cmbLocation.Items.Add("SA, NT")
        cmbLocation.Items.Add("WA")
        cmbDestination.Items.add("USA (California)")
        cmbDestination.items.Add("UK")
        cmbDestination.items.Add("NZ")
        lblLocalTime.Text = Now
        lblDestTime.Text = "** Waiting **"
    End Sub

    Private Sub cmbLocation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbLocation.SelectedIndexChanged
        Select Case cmbLocation.Text
            Case "Vic, ACT, NSW, QLD, TAS" : Difference1 = 10
            Case "SA, NT" : Difference1 = 9.5
            Case "WA" : Difference1 = 8
        End Select
        ChangeTimeDifferences()
    End Sub

    Private Sub cmbDestination_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDestination.SelectedIndexChanged
        Select Case cmbDestination.Text
            Case "USA (California)" : Difference2 = -7
            Case "UK" : Difference2 = 1
            Case "NZ" : Difference2 = 12
        End Select
        ChangeTimeDifferences()
    End Sub
    Private Sub ChangeTimeDifferences()
        Dim sTemp As String = ""
        If Difference2 >= 0 Then sTemp = "+"
        lblDestTimeDiff.Text = sTemp + " " + Difference2.ToString()
        If Difference1 >= 0 Then sTemp = "+"
        lblLocTimeDiff.Text = sTemp + " " + Difference1.ToString()
    End Sub
    Private Sub tmrTimer_Tick(sender As Object, e As EventArgs) Handles tmrTimer.Tick
        lblLocalTime.Text = Now
        If Difference1 <> 0 And Difference2 <> 0 Then
            lblDestTime.Text = Date.Now.AddMinutes(Difference2 * 60 - Difference1 * 60)
        Else
            lblDestTime.Text = "** Waiting **"
        End If
    End Sub

    Private Sub btnQuit_Click(sender As Object, e As EventArgs) Handles btnQuit.Click
        End
    End Sub
End Class
