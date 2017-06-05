Class FattyFood
    Inherits SpecialFood
    Sub New()
        colour = Color.Cyan
    End Sub
    Public Overrides Sub Interact(ByRef snake As Snake)
        graphPen.Color = Color.Black
        graph.FillRectangle(graphPen, coord.x * boxSize, coord.y * boxSize, boxSize, boxSize)
        snake.IncreaseScore()
        snake.IncreaseScore()
        snake.IncreaseScore()
        snake.IncreaseScore()
        snake.growthQueue += 4
    End Sub
End Class
Public MustInherit Class Food
    Public duration As Long = 250
    Public colour As Color
    Public coord As Coord
    Public MustOverride Sub Interact(ByRef snake As Snake)
    Public MustOverride Sub Update()
End Class
Public MustInherit Class SpecialFood
    Inherits Food
    Public Overrides Sub Update()
        graphPen.Color = colour
        graph.FillRectangle(graphPen, coord.x * boxSize, coord.y * boxSize, boxSize, boxSize)
        duration -= 1
    End Sub
End Class
Public Class EdibleSnake
    Inherits SpecialFood
    Sub New(blockColour As Color)
        colour = blockColour
    End Sub
    Public Overrides Sub Interact(ByRef snake As Snake)
        snake.IncreaseScore()
        snake.IncreaseScore()
        snake.growthQueue += 1
    End Sub
End Class
Public Class ShortenFood
    Inherits SpecialFood
    Sub New()
        colour = Color.Magenta
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
        colour = Color.Red
    End Sub
    Public Overrides Sub Interact(ByRef snake As Snake)
        snake.speedFactor += 0.1
        snake.IncreaseScore()
        snake.IncreaseScore()
    End Sub
End Class
Public Class InvicibilityFood
    Inherits SpecialFood
    Sub New()
        colour = Color.LightYellow
    End Sub
    Public Overrides Sub Interact(ByRef snake As Snake)
        snake.invicibilityTime += 350
        snake.IncreaseScore()
        snake.IncreaseScore()
    End Sub
End Class
Public Class NormalFood
    Inherits Food
    Sub New()
        colour = color.Green
    End Sub
    Public Overrides Sub Interact(ByRef snake As Snake)
        snake.IncreaseScore()
        snake.growthQueue += 1
        globalSpeed += 0.1
        SpawnFood(New NormalFood())
    End Sub
    Public Overrides Sub Update()
        graphPen.Color = colour
        graph.FillRectangle(graphPen, coord.x * boxSize, coord.y * boxSize, boxSize, boxSize)
    End Sub
End Class