Class ShortenFood
    Inherits SpecialFood
    Sub New()
        colour = Color.Cyan
    End Sub
    Public Overrides Sub Interact(ByRef snake As Snake)
        snakeGrid(coord.x)(coord.y).BackColor = Color.Black
        snake.IncreaseScore()
        snake.IncreaseScore()
        snake.snakeBlocks.RemoveAt(snake.snakeBlocks.Count - 1)
    End Sub
End Class
Public MustInherit Class Food
    Public duration As Long = 5 * 60
    Public colour As Color
    Public coord As Coord
    Public MustOverride Sub Interact(ByRef snake As Snake)
    Public MustOverride Sub Update()
End Class
Public MustInherit Class SpecialFood
    Inherits Food
    Public Overrides Sub Update()
        snakeGrid(coord.x)(coord.y).BackColor = colour
        duration -= 1
    End Sub
End Class
Public Class SlowFood
    Inherits SpecialFood
    Sub New()
        colour = Color.Magenta
    End Sub
    Public Overrides Sub Interact(ByRef snake As Snake)
        snake.speedFactor /= 2.0
        snake.IncreaseScore()
        snake.IncreaseScore()
        snakeGrid(coord.x)(coord.y).BackColor = Color.Black
    End Sub
End Class
Public Class FastFood
    Inherits SpecialFood
    Sub New()
        colour = Color.Red
    End Sub
    Public Overrides Sub Interact(ByRef snake As Snake)
        snake.speedFactor *= 2.0
        snake.IncreaseScore()
        snake.IncreaseScore()
        snakeGrid(coord.x)(coord.y).BackColor = Color.Black
    End Sub
End Class
Public Class NormalFood
    Inherits Food
    Sub New()
        colour = color.Green
    End Sub
    Public Overrides Sub Interact(ByRef snake As Snake)
        snake.IncreaseScore()
        snake.justAte = True
        snakeGrid(coord.x)(coord.y).BackColor = Color.Black
        SpawnFood(New NormalFood())
    End Sub
    Public Overrides Sub Update()
        snakeGrid(coord.x)(coord.y).BackColor = colour
    End Sub
End Class