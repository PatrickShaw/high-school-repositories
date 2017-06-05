Public Class frmSketchPad
    Dim GraphDemo As Graphics
    Dim LinePreview As Graphics
    Dim GraphPen As New Pen(Color.Black, 1)
    Dim X, Y As Integer
    Dim R As Integer = 0
    Dim G As Integer = 0
    Dim B As Integer = 0
    Dim W As Double = 255
    Dim PenWidth As Integer = 1
    Dim Start As Boolean = False
    Private Sub frmSketchPad_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GraphDemo = picSketchPad.CreateGraphics
        LinePreview = picLinePreview.CreateGraphics
        GraphPen.Width = Width
        txtRed.Text = R
        txtGreen.Text = G
        txtBlue.Text = B
        txtAlpha.Text = W
        hScrollAlpha.Value = W
        txtWidth.Text = PenWidth
        hScrollWidth.Value = PenWidth
        GraphPen.StartCap = Drawing2D.LineCap.Round
        GraphPen.EndCap = Drawing2D.LineCap.Round
        SetColourPreview()
    End Sub
    Private Sub SetLinePreview()
        GraphDemo = picSketchPad.CreateGraphics
        LinePreview = picLinePreview.CreateGraphics

        PenWidth = Val(txtWidth.Text)
        GraphPen.Width = PenWidth
        LinePreview.Clear(Color.White)
        LinePreview.DrawLine(GraphPen, 10, CInt(LinePreview.DpiY / 2 - PenWidth / 4), LinePreview.DpiX - 10, CInt(LinePreview.DpiY / 2 - PenWidth / 4))
    End Sub
    Private Sub SetColourPreview()
        W = Val(txtAlpha.Text)
        R = Val(txtRed.Text)
        G = Val(txtGreen.Text)
        B = Val(txtBlue.Text)
        GraphPen.Color = Color.FromArgb(W, R, G, B)
        picColourPreview.BackColor = GraphPen.Color
        SetLinePreview()
    End Sub
    Private Shared Sub hScrollColourValueChange(scrollBar As HScrollBar, textBox As TextBox)
        Dim valTemp As Integer = Val(textBox.Text)
        If (valTemp > 255) Then
            valTemp = 255
        ElseIf (valTemp < 0) Then
            valTemp = 0
        End If
        textBox.Text = valTemp
        scrollBar.Value = valTemp
    End Sub

    Private Sub txtRed_TextChanged(sender As Object, e As EventArgs) Handles txtRed.TextChanged
        hScrollColourValueChange(hScrollRed, txtRed)
        SetColourPreview()
    End Sub

    Private Sub hScrollRed_Scroll(sender As Object, e As ScrollEventArgs) Handles hScrollRed.Scroll
        txtRed.Text = hScrollRed.Value
        SetColourPreview()
    End Sub

    Private Sub txtGreen_TextChanged(sender As Object, e As EventArgs) Handles txtGreen.TextChanged
        hScrollColourValueChange(hScrollGreen, txtGreen)
        SetColourPreview()
    End Sub

    Private Sub hScrollGreen_Scroll(sender As Object, e As ScrollEventArgs) Handles hScrollGreen.Scroll
        txtGreen.Text = hScrollGreen.Value
        SetColourPreview()
    End Sub

    Private Sub txtBlue_TextChanged(sender As Object, e As EventArgs) Handles txtBlue.TextChanged
        hScrollColourValueChange(hScrollBlue, txtBlue)
        SetColourPreview()
    End Sub

    Private Sub hScrollBlue_Scroll(sender As Object, e As ScrollEventArgs) Handles hScrollBlue.Scroll
        txtBlue.Text = hScrollBlue.Value
        SetColourPreview()
    End Sub
    Private Sub txtAlpha_TextChanged(sender As Object, e As EventArgs) Handles txtAlpha.TextChanged
        hScrollColourValueChange(hScrollAlpha, txtAlpha)
        SetColourPreview()
    End Sub

    Private Sub hScrollAlpha_Scroll(sender As Object, e As ScrollEventArgs) Handles hScrollAlpha.Scroll
        txtAlpha.Text = hScrollAlpha.Value
        SetColourPreview()
    End Sub

    Private Sub txtWidth_TextChanged(sender As Object, e As EventArgs) Handles txtWidth.TextChanged
        Dim valTemp As Integer = Val(txtWidth.Text)
        If (valTemp < 1) Then
            valTemp = 1
        End If
        Try
            txtWidth.Text = valTemp
            If (valTemp > hScrollWidth.Maximum) Then
                hScrollWidth.Value = hScrollWidth.Maximum
            Else
                hScrollWidth.Value = valTemp
            End If
        Catch

        End Try
        SetLinePreview()
    End Sub

    Private Sub hScrollWidth_Scroll(sender As Object, e As ScrollEventArgs) Handles hScrollWidth.Scroll
        txtWidth.Text = hScrollWidth.Value
        SetLinePreview()
    End Sub
    Private Sub btnFillBackground_Click(sender As Object, e As EventArgs) Handles btnFillBackground.Click
        picSketchPad.BackColor = Color.FromArgb(R, G, B)
    End Sub
    Private Sub picSketchPad_MouseDown(sender As Object, e As MouseEventArgs) Handles picSketchPad.MouseDown
        Start = True
        If e.Button = Windows.Forms.MouseButtons.Right Then
            GraphPen.Color = picSketchPad.BackColor
        End If
        X = e.X
        Y = e.Y
    End Sub

    Private Sub picSketchPad_MouseMove(sender As Object, e As MouseEventArgs) Handles picSketchPad.MouseMove
        If Start = False Then
            Return
        End If
        GraphDemo.DrawLine(GraphPen, X, Y, e.X, e.Y)
        X = e.X
        Y = e.Y
    End Sub

    Private Sub picSketchPad_MouseUp(sender As Object, e As MouseEventArgs) Handles picSketchPad.MouseUp
        Start = False
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        GraphDemo.Clear(Color.Transparent)
    End Sub

    Private Sub btnQuit_Click(sender As Object, e As EventArgs) Handles btnQuit.Click
        End
    End Sub
End Class
