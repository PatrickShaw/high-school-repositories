Class FattyFood
    Inherits SpecialFood
    Sub New()
        colour = Brushes.Cyan
    End Sub
    Public Overrides Sub Interact(ByRef snake As Snake)
        snakeGrid(coord.x)(coord.y).Fill = Brushes.Black
        'graph.FillRectangle(graphPen, coord.x * boxSize, coord.y * boxSize, boxSize, boxSize)
        snake.IncreaseScore()
        snake.IncreaseScore()
        snake.IncreaseScore()
        snake.IncreaseScore()
        snake.growthQueue += 4
    End Sub

End Class
Public MustInherit Class Food
    Public duration As Long = 400
    Public colour As Brush
    Public Sub Destruct()
        snakeGrid(coord.x)(coord.y).Fill = Brushes.Black
    End Sub
    Protected coord As Coord
    Public Property Coordinate As Coord
        Get
            Return Coord
        End Get
        Set(value As Coord)
            snakeGrid(Coord.x)(Coord.y).Fill = Brushes.Black
            Coord = value
            snakeGrid(Coord.x)(Coord.y).Fill = colour
        End Set
    End Property
    Public MustOverride Sub Interact(ByRef snake As Snake)
    Public Overridable Sub Update()

    End Sub

End Class
Public Class RandomFood
    Inherits SpecialFood
    Dim x As Long = 0
    Public Overrides Sub Update()
        MyBase.Update()
        x += 1
        snakeGrid(coord.x)(coord.y).Fill = New SolidColorBrush(Snake.ColourValue(x, 0, SnakePattern.rainbow))
    End Sub
    Public Overrides Sub Interact(ByRef snake As Snake)

    End Sub
End Class
Public MustInherit Class SpecialFood
    Inherits Food
    Public Overrides Sub Update()
        duration -= 1
    End Sub
End Class
Public Class EdibleSnake
    Inherits SpecialFood
    Sub New(blockColour As Brush)
        colour = blockColour
    End Sub
    Public Overrides Sub Interact(ByRef snake As Snake)
        snake.IncreaseScore()
        snake.IncreaseScore()
        snake.invicibilityTime += 150
    End Sub
End Class
Public Class ShortenFood
    Inherits SpecialFood
    Sub New()
        colour = Brushes.Magenta
    End Sub
    Public Overrides Sub Interact(ByRef snake As Snake)
        snake.IncreaseScore()
        snake.IncreaseScore()
        snake.growthQueue -= 1
    End Sub
End Class
Public Class FastFood
    Inherits SpecialFood
    Sub New()
        colour = Brushes.Red
    End Sub
    Public Overrides Sub Interact(ByRef snake As Snake)
        snake.speedBonusTime += 100
        snake.speedBonus = 1
        snake.invicibilityTime += 100
        snake.IncreaseScore()
        snake.IncreaseScore()
    End Sub
End Class
Public Class InvicibilityFood
    Inherits SpecialFood
    Sub New()
        colour = Brushes.LightYellow
    End Sub
    Public Overrides Sub Interact(ByRef snake As Snake)
        snake.invicibilityTime += 300
        snake.IncreaseScore()
        snake.IncreaseScore()
    End Sub
End Class
Public Class NormalFood
    Inherits Food
    Sub New()
        colour = Brushes.Green
    End Sub
    Public Overrides Sub Interact(ByRef snake As Snake)
        snake.IncreaseScore()
        snake.growthQueue += 1
        globalSpeed += 0.09
        SpawnFood(New NormalFood())
    End Sub
    Public Overrides Sub Update()

        snakeGrid(coord.x)(coord.y).Fill = colour
    End Sub
End Class