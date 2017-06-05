Imports System.IO

Public Class Form1
    Dim currentCard As Integer
    Dim eCards(4) As CardType
    Dim random As New Random
    Dim snakeImage As Bitmap
    Dim elephantImage As Bitmap
    Dim starImage As Bitmap
    Dim turtleImage As Bitmap
    Dim questionImage As Bitmap
    Enum CardType As UInteger
        turtle
        snake
        elephant
        star
    End Enum
    Private Sub Reset()
        currentCard = 0
        For i As Integer = 0 To eCards.Count - 1
            Dim rNo As Integer
            rNo = random.Next(5)
            Select Case rNo
                Case 1
                    eCards(i) = CardType.turtle
                Case 2
                    eCards(i) = CardType.star
                Case 3
                    eCards(i) = CardType.elephant
                Case 4
                    eCards(i) = CardType.snake
            End Select
        Next
        Card1.Image = questionImage
        Card2.Image = questionImage
        Card3.Image = questionImage
        Card4.Image = questionImage
        Card5.Image = questionImage
    End Sub
    Private Sub PickCard(ByRef card As PictureBox, cardPicked As CardType)
        Select Case eCards(currentCard)
            Case CardType.elephant
                card.Image = elephantImage
            Case CardType.star
                card.Image = starImage
            Case CardType.turtle
                card.Image = turtleImage
            Case CardType.snake
                card.Image = snakeImage
        End Select
        If eCards(currentCard) = cardPicked Then
            MessageBox.Show("Correct!")
        Else
            MessageBox.Show("Incorrect!")
        End If
        currentCard += 1
        If currentCard >= 5 Then
            Reset()
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim myAssembly As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly()
        Dim myStream As Stream = myAssembly.GetManifestResourceStream("School_Work___Simple_Snap.Elephant.jpg")
        elephantImage = New Bitmap(myStream)

        myStream = myAssembly.GetManifestResourceStream("School_Work___Simple_Snap.QuestionMark.png")
        questionImage = New Bitmap(myStream)

        myStream = myAssembly.GetManifestResourceStream("School_Work___Simple_Snap.Snake.jpg")
        snakeImage = New Bitmap(myStream)

        myStream = myAssembly.GetManifestResourceStream("School_Work___Simple_Snap.Star.PNG")
        starImage = New Bitmap(myStream)

        myStream = myAssembly.GetManifestResourceStream("School_Work___Simple_Snap.Turtle2..jpg")
        turtleImage = New Bitmap(myStream)
        Reset()
    End Sub
    Private Function FindCardNumber() As PictureBox
        Select Case currentCard
            Case 0
                Return Card1
            Case 1
                Return Card2
            Case 2
                Return Card3
            Case 3
                Return Card4
            Case 4
                Return Card5
        End Select
        Return Card1
    End Function

    Private Sub btnElephant_Click(sender As Object, e As EventArgs) Handles btnElephant.Click
        PickCard(FindCardNumber(), CardType.elephant)
    End Sub
    Private Sub btnTurtle_Click(sender As Object, e As EventArgs) Handles btnTurtle.Click
        PickCard(FindCardNumber(), CardType.turtle)
    End Sub

    Private Sub btnStar_Click(sender As Object, e As EventArgs) Handles btnStar.Click
        PickCard(FindCardNumber(), CardType.star)
    End Sub

    Private Sub btnSnake_Click(sender As Object, e As EventArgs) Handles btnSnake.Click
        PickCard(FindCardNumber(), CardType.snake)
    End Sub

    Private Sub btnQuit_Click(sender As Object, e As EventArgs) Handles btnQuit.Click
        End
    End Sub
End Class
