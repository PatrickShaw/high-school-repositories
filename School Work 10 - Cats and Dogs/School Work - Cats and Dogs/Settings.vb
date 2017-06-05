Public Class frmSettings

    Private Sub frmSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtPlayer1Name.Text = Config.Player1Name
        txtPlayer2Name.Text = Config.Player2Name
        txtCharacter1Directory.Text = Config.Character1Directory
        txtCharacter2Directory.Text = Config.Character2Directory
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Game.Show()
        Me.Close()
    End Sub

    Private Sub txtPlayer1Name_TextChanged(sender As Object, e As EventArgs) Handles txtPlayer1Name.TextChanged

    End Sub

    Private Sub btnApply_Click(sender As Object, e As EventArgs) Handles btnApply.Click
        Config.Player1Name = txtPlayer1Name.Text
        Config.Player2Name = txtPlayer2Name.Text
        Config.Character1Directory = txtCharacter1Directory.Text
        Config.Character2Directory = txtCharacter2Directory.Text
        Game.LoadNewSettings()
    End Sub

    Private Sub btnBrowse1_Click(sender As Object, e As EventArgs) Handles btnBrowse1.Click
        dlgOpenImage.ShowDialog()
        If dlgOpenImage.FileName <> "" Then
            Config.Character1 = Bitmap.FromFile(dlgOpenImage.FileName)
            txtCharacter1Directory.Text = dlgOpenImage.FileName
        End If
    End Sub

    Private Sub btnBrowse2_Click(sender As Object, e As EventArgs) Handles btnBrowse2.Click
        dlgOpenImage.ShowDialog()
        If dlgOpenImage.FileName <> "" Then
            Config.Character2 = Bitmap.FromFile(dlgOpenImage.FileName)
            txtCharacter2Directory.Text = dlgOpenImage.FileName
        End If
    End Sub
End Class