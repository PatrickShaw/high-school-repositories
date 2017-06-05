Public Class Form1
    Structure Coord
        Dim X As Integer
        Dim Y As Integer
    End Structure
    Dim r As New Random
    Dim p1 As Coord
    Dim p2 As Coord
    Dim GraphDemo As Graphics
    Dim GraphPen As New Pen(Color.Black, 1)
    Private Sub bLines1_Click(sender As Object, e As EventArgs) Handles bLines1.Click
        p1.X = picDisplay.Width - 50
        p1.Y = 20
        GraphPen.Width = 1
        GraphPen.Color = Color.Black
        For Number = 1 To 10
            GraphDemo.DrawLine(GraphPen, 50, p1.Y, p1.X, p1.Y)
            GraphPen.Width = Number
            p1.Y += 20
        Next
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Randomize()
        GraphDemo = picDisplay.CreateGraphics
    End Sub

    Private Sub bClear_Click(sender As Object, e As EventArgs) Handles bClear.Click
        picDisplay.Image = Nothing
    End Sub

    Private Sub bLines2_Click(sender As Object, e As EventArgs) Handles bLines2.Click
        For i = 1 To 10
            RandomizeCoordinates()
            GraphPen.Width = r.Next(6)
            GraphPen.Color = Color.FromArgb(r.Next(256), r.Next(256), r.Next(256), r.Next(256))
            GraphDemo.DrawLine(GraphPen, p1.X, p1.Y, p2.X, p2.Y)
        Next
    End Sub
    Private Sub RandomizeCoordinates()
        p1.X = Rnd() * picDisplay.Width
        p1.Y = Rnd() * picDisplay.Height
        p2.X = Rnd() * picDisplay.Width
        p2.Y = Rnd() * picDisplay.Height
    End Sub

    Private Sub bQuit_Click(sender As Object, e As EventArgs) Handles bQuit.Click
        End
    End Sub

    Private Sub bElipses1_Click(sender As Object, e As EventArgs) Handles bElipses1.Click
        p1.X = (picDisplay.Width / 2) - 50
        p1.Y = (picDisplay.Height / 2) - 50
        GraphPen.Width = 10
        GraphPen.Color = Color.Black
        GraphDemo.DrawEllipse(GraphPen, p1.X, p1.Y, 100, 100)
        GraphPen.Width = 5
        GraphPen.Color = Color.Red
        GraphDemo.DrawEllipse(GraphPen, p1.X - 50, p1.Y - 50, 100, 100)
        GraphDemo.DrawEllipse(GraphPen, p1.X - 50, p1.Y + 50, 100, 100)
        GraphDemo.DrawEllipse(GraphPen, p1.X + 50, p1.Y - 50, 100, 100)
        GraphDemo.DrawEllipse(GraphPen, p1.X + 50, p1.Y + 50, 100, 100)
    End Sub

    Private Sub bElipses2_Click(sender As Object, e As EventArgs) Handles bElipses2.Click
        For i = 1 To 10
            RandomizeCoordinates()
            p2.X = r.Next(51)
            p2.Y = p2.X
            GraphPen.Width = r.Next(5)
            GraphPen.Color = Color.FromArgb(r.Next(256), r.Next(256), r.Next(256), r.Next(256))
            GraphDemo.DrawEllipse(GraphPen, p1.X, p1.Y, p2.X, p2.Y)
        Next
    End Sub

    Private Sub bRectangles1_Click(sender As Object, e As EventArgs) Handles bRectangles1.Click
        p1.X = (picDisplay.Width / 2) - 50
        p1.Y = (picDisplay.Height / 2) - 50
        GraphPen.Width = 10
        GraphPen.Color = Color.Black
        GraphDemo.DrawEllipse(GraphPen, p1.X, p1.Y, 100, 100)
        GraphPen.Width = 5
        GraphPen.Color = Color.Red
        GraphDemo.DrawRectangle(GraphPen, p1.X - 50, p1.Y - 50, 100, 100)
        GraphDemo.DrawRectangle(GraphPen, p1.X - 50, p1.Y + 50, 100, 100)
        GraphDemo.DrawRectangle(GraphPen, p1.X + 50, p1.Y - 50, 100, 100)
        GraphDemo.DrawRectangle(GraphPen, p1.X + 50, p1.Y + 50, 100, 100)
    End Sub

    Private Sub bRectangles2_Click(sender As Object, e As EventArgs) Handles bRectangles2.Click
        For i = 1 To 10
            RandomizeCoordinates()
            p2.X = r.Next(51)
            p2.Y = p2.X
            GraphPen.Width = r.Next(5)
            GraphPen.Color = Color.FromArgb(r.Next(256), r.Next(256), r.Next(256), r.Next(256))
            GraphDemo.DrawRectangle(GraphPen, p1.X, p1.Y, p2.X, p2.Y)
        Next
    End Sub
    Private Sub goSpaz()
        For i = 0 To 100
            Dim value As Integer = r.Next(3)
            Select Case value
                Case 0
                    bLines2.PerformClick()
                Case 1
                    bRectangles2.PerformClick()
                Case 2
                    bElipses2.PerformClick()
            End Select
        Next
    End Sub

    Private Sub bGoCrazy_Click(sender As Object, e As EventArgs) Handles bGoCrazy.Click
        goSpaz()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        p1.X = (picDisplay.Width / 2)
        p1.Y = (picDisplay.Height / 2)
        Const size As Integer = 100
        Const cent As Integer = size / 2
        GraphPen.Width = 7

        GraphPen.Color = Color.Yellow
        GraphDemo.DrawEllipse(GraphPen, p1.X - cent - 40, p1.Y - cent + 45, size, size)
        GraphPen.Color = Color.Green
        GraphDemo.DrawEllipse(GraphPen, p1.X - cent + 40, p1.Y - cent + 45, size, size)
        GraphPen.Color = Color.Red
        GraphDemo.DrawEllipse(GraphPen, p1.X - cent + 75, p1.Y - 80 - cent + 45, size, size)

        GraphPen.Color = Color.Blue
        GraphDemo.DrawEllipse(GraphPen, p1.X - cent - 75, p1.Y - 80 - cent + 45, size, size)
        GraphPen.Color = Color.Black
        GraphDemo.DrawEllipse(GraphPen, p1.X - cent, p1.Y - 80 - cent + 45, size, size)
    End Sub
End Class
