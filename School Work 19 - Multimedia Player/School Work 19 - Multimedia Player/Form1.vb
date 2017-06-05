Imports WMPLib

Public Class Form1
    Dim selectedNo As Integer = 0
    Private Sub mnuQuit_Click(sender As Object, e As EventArgs) Handles mnuQuit.Click
        End
    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        dlgOpenFile.ShowDialog()
        If dlgOpenFile.FileName <> "" Then
            txtPath.Text = dlgOpenFile.FileName
            lstPlaylist.Items.Add(txtPath.Text)
            wmpPlayer.URL = txtPath.Text
            lstPlaylist.SetSelected(lstPlaylist.Items.Count - 1, False)
        End If
    End Sub

    Private Sub mnuOption_Click(sender As Object, e As EventArgs) Handles mnuOption.Click
        wmpPlayer.ShowPropertyPages()
    End Sub

    Private Sub mnuPause_Click(sender As Object, e As EventArgs) Handles mnuPause.Click
        wmpPlayer.Ctlcontrols.pause()
    End Sub

    Private Sub mnuStop_Click(sender As Object, e As EventArgs) Handles mnuStop.Click
        wmpPlayer.Ctlcontrols.stop()
    End Sub

    Private Sub mnuPlay_Click(sender As Object, e As EventArgs) Handles mnuPlay.Click
        Play()
    End Sub

    Private Sub wmpPlayer_PlayStateChange(sender As Object, e As AxWMPLib._WMPOCXEvents_PlayStateChangeEvent) Handles wmpPlayer.PlayStateChange
        If e.newState = WMPPlayState.wmppsMediaEnded Then

        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        wmpPlayer.Visible = False
    End Sub
    Private Sub Play()
        wmpPlayer.URL = lstPlaylist.SelectedItem
        wmpPlayer.Ctlcontrols.play()
    End Sub
    Private Sub mnuNext_Click(sender As Object, e As EventArgs) Handles mnuNext.Click
        If lstPlaylist.SelectedIndex + 1 >= lstPlaylist.Items.Count Then
            lstPlaylist.SetSelected(0, True)
        Else
            lstPlaylist.SetSelected(lstPlaylist.SelectedIndex + 1, True)
        End If
        Play()
    End Sub

    Private Sub mnuPrevious_Click(sender As Object, e As EventArgs) Handles mnuPrevious.Click
        If (0 > lstPlaylist.SelectedIndex) Then
            lstPlaylist.SetSelected(lstPlaylist.Items.Count - 1, True)
        Else
            lstPlaylist.SetSelected(lstPlaylist.SelectedIndex - 1, True)
        End If
        Play()
    End Sub
End Class
