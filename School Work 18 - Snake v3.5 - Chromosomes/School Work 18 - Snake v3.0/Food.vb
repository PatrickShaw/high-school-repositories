Class FattyFood
    Inherits SpecialFood
    Sub New()
        MyBase.New()
        colour = Brushes.Cyan
    End Sub
    Public Overrides Sub Interact(ByRef snake As Snake)
        rect.Fill = Brushes.Black
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
    Public initializeMe As Boolean = True
    Public distructMe As Boolean = False
    Public rect As Rectangle = New Rectangle()
    Public colour As Brush
    Sub New()
        GameCanvasPublic.Children.Add(rect)
        rect.Width = boxSize
        rect.Height = boxSize
    End Sub
    Public Sub Destruct()
        distructMe = True
        rect.Fill = Brushes.Black
        rect.Stroke = Brushes.Black
    End Sub
    Protected coord As Coord
    Public Property Coordinate As Coord
        Get
            Return coord
        End Get
        Set(value As Coord)
            rect.Fill = Brushes.Black
            coord = value
            rect.Stroke = Brushes.Black
            rect.StrokeThickness = 1
            rect.Fill = colour
        End Set
    End Property
    Public MustOverride Sub Interact(ByRef snake As Snake)
    Public Overridable Sub Update()

    End Sub

End Class
Public MustInherit Class SpecialFood
    Inherits Food
    Sub New()

        MyBase.New()
    End Sub
    Public Overrides Sub Update()
        duration -= 1
    End Sub

    Public Overrides Sub Interact(ByRef snake As Snake)
        If snake.usingNN And snake.stagnant Then Return
    End Sub
End Class
Public Class EdibleSnake
    Inherits SpecialFood
    Sub New(blockColour As Brush)
        MyBase.New()
        colour = blockColour
    End Sub
    Public Overrides Sub Interact(ByRef snake As Snake)
        MyBase.Interact(snake)
        snake.IncreaseScore()
        snake.IncreaseScore()
        snake.growthQueue += 1
        snake.invicibilityTime += 10
    End Sub
End Class
Public Class ShortenFood
    Inherits SpecialFood
    Sub New()
        MyBase.New()
        colour = Brushes.Magenta
    End Sub
    Public Overrides Sub Interact(ByRef snake As Snake)
        MyBase.Interact(snake)
        snake.IncreaseScore()
        snake.IncreaseScore()
        snake.growthQueue -= 1
    End Sub
End Class
Public Class FastFood
    Inherits SpecialFood
    Sub New()
        MyBase.New()
        colour = Brushes.Red
    End Sub
    Public Overrides Sub Interact(ByRef snake As Snake)
        MyBase.Interact(snake)
        snake.speedBonusTime += (gridWidth + gridHeight) / 2.35
        snake.speedBonus = 1
        snake.growthQueue += 1
        snake.invicibilityTime += (gridWidth + gridHeight) / 2.35
        snake.IncreaseScore()
        snake.IncreaseScore()
    End Sub
End Class
Public Class RandomFood
    Inherits SpecialFood
    Sub New()

        MyBase.New()
    End Sub
    Dim x As Long = 0
    Public Overrides Sub Update()
        MyBase.Update()
        x += 1
        rect.Fill = New SolidColorBrush(Snake.ColourValue(x, 0, SnakePattern.rainbow))
    End Sub
    Public Overrides Sub Interact(ByRef snake As Snake)
        MyBase.Interact(snake)
        Dim SpecialFoodTemp As SpecialFood = ChooseRandomSpecialFood()
        SpecialFoodTemp.Interact(snake)
    End Sub
End Class
Public Class InvicibilityFood
    Inherits SpecialFood
    Sub New()
        colour = Brushes.LightYellow
    End Sub
    Public Overrides Sub Interact(ByRef snake As Snake)
        MyBase.Interact(snake)
        snake.invicibilityTime += (gridWidth + gridHeight) / 2
        snake.growthQueue += 1
        snake.IncreaseScore()
        snake.IncreaseScore()
    End Sub
End Class
Public Class NormalFood
    Inherits Food
    Sub New()
        MyBase.New()
        colour = Brushes.Green
    End Sub
    Public Overrides Sub Interact(ByRef snake As Snake)
        If snake.usingNN And snake.stagnant Then Return
        snake.IncreaseScore()
        snake.growthQueue += 1
        globalSpeed += 0.09
        SpawnFood(New NormalFood())
    End Sub
    Public Overrides Sub Update()
        rect.Fill = colour
        duration += 1
    End Sub
End Class