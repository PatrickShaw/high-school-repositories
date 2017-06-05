Public Class Form1

    Private Sub bLoadImage_Click(sender As Object, e As EventArgs) Handles bLoadImage.Click
        dlgOpenFile.ShowDialog()
        If dlgOpenFile.FileName <> "" Then
            picDisplay.Image = Bitmap.FromFile(dlgOpenFile.FileName)
            txtPath.Text = dlgOpenFile.FileName
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        hsZooom.Value = hsZooom.Maximum
        vsZoom.Value = vsZoom.Maximum
    End Sub

    Private Sub hsZooom_Scroll(sender As Object, e As ScrollEventArgs) Handles hsZooom.Scroll
        picDisplay.Width = 566 * hsZooom.Value / hsZooom.Maximum
    End Sub

    Private Sub VScrollBar1_Scroll(sender As Object, e As ScrollEventArgs) Handles vsZoom.Scroll
        picDisplay.Height = 399 * vsZoom.Value / vsZoom.Maximum
    End Sub
End Class
