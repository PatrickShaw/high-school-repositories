Public Structure Vector2
    Public x As Double
    Public y As Double
End Structure
Public MustInherit Class Entity
    Public picture As PictureBox
    Public speed As Double 'Pixel/interval'
    Public speedDefault As Double
    Public velocity As Vector2
    Public MustOverride Sub Clicked()
    Public Sub ResumeEntity()
        picture.Visible = True
        picture.Left = frmBunnyCatcher.pnlGameRoom.Left + (Rnd() Mod frmBunnyCatcher.pnlGameRoom.Size.Width)
        picture.Top = frmBunnyCatcher.pnlGameRoom.Top + (Rnd() Mod frmBunnyCatcher.pnlGameRoom.Size.Height)
        'Determine horizontal direction'
        Dim xDirection As Integer = Rnd() Mod 1
        If (xDirection = 1) Then
            velocity.x = speed + ((Rnd() Mod 100.0) - 50.0) / 50.0
        Else
            velocity.x = -speed + ((Rnd() Mod 100.0) - 50.0) / 50.0
        End If
        'Determine vertical direction'
        Dim yDirection As Integer = Rnd() Mod 1
        If (yDirection = 1) Then
            velocity.y = speed + ((Rnd() Mod 100.0) - 50.0) / 50.0
        Else
            velocity.y = -speed + ((Rnd() Mod 100.0) - 50.0) / 50.0
        End If
    End Sub
    Public Sub PauseEntity()
        picture.Visible = False
        speed = speedDefault
    End Sub
    Public Sub IncreaseSpeed(value As Integer)
        speed += value
        If (velocity.x < 0) Then
            velocity.x = -speed
        Else
            velocity.x = speed
        End If

        If (velocity.y < 0) Then
            velocity.y = -speed
        Else
            velocity.y = speed
        End If
    End Sub
    Public Sub CollisionCheck()
        If (picture.Left <= frmBunnyCatcher.pnlGameRoom.Left Or picture.Right >= frmBunnyCatcher.pnlGameRoom.Right) Then
            velocity.x *= -1
            velocity.x += Rnd() * 0.05 - 0.025
        End If
        If (picture.Top <= frmBunnyCatcher.pnlGameRoom.Top Or picture.Bottom >= frmBunnyCatcher.pnlGameRoom.Bottom) Then
            velocity.y *= -1
            velocity.y += Rnd() * 0.05 - 0.025
        End If
    End Sub
End Class
Public Class Bunny
    Inherits Entity
    Sub New()
        speedDefault = 2
        speed = speedDefault
    End Sub
    Public Overrides Sub Clicked()
        frmBunnyCatcher.score += 1 * frmBunnyCatcher.multiplier
    End Sub
End Class
Public Class Kirby
    Inherits Entity
    Sub New()
        speedDefault = 3
        speed = speedDefault
    End Sub
    Public Overrides Sub Clicked()
        frmBunnyCatcher.multiplier += 1
        IncreaseSpeed(1)
    End Sub
End Class