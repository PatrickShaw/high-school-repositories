Public MustInherit Class Entity
    Public texture As PictureBox
    Public vel As Vector2
    Public rect As Rect
    Public size As Vector2
    Public oldPos As Vector2
    Public MustOverride Sub Update()
    Public Sub CollisionCheck(ByRef oEnt As Entity)
        If (rect.Intersects(oEnt.rect)) Then Interact(oEnt)
    End Sub
    Public MustOverride Sub Interact(ByRef oEnt As Entity)
    Public Sub SetTextureRef(textureT As Bitmap)
        texture = New PictureBox()
        texture.Left = rect.pos.x
        texture.Top = rect.pos.y
        texture.Width = rect.width
        texture.Height = rect.height
        texture.SizeMode = PictureBoxSizeMode.StretchImage
        texture.Image = textureT
        texture.BackColor = Color.Transparent
        frmGame.Controls.Add(texture)
    End Sub
End Class
Public Class Ship
    Inherits Entity
    Sub New()
        rect.pos = New Vector2(frmGame.pnlGameRoom.Left + (frmGame.pnlGameRoom.Width / 2.0) - (rect.width / 2.0), frmGame.pnlGameRoom.Bottom - rect.height - 400)
        rect.width = 32
        rect.height = 32
        SetTextureRef(shipTexture)
    End Sub
    Public Overrides Sub Interact(ByRef oEnt As Entity)
        If oEnt.GetType = GetType(Meteor) Then GameOver()
    End Sub

    Public Overrides Sub Update()
        oldPos.x = rect.pos.x
        oldPos.y = rect.pos.y
        rect.pos.x += vel.x
        rect.pos.y += vel.y
        If (rect.pos.x <= frmGame.pnlGameRoom.Left Or rect.Right() >= frmGame.pnlGameRoom.Right) Then rect.pos.x = oldPos.x
        If (rect.pos.y <= frmGame.pnlGameRoom.Top Or rect.Bottom() >= frmGame.pnlGameRoom.Bottom) Then rect.pos.y = oldPos.y
        For o As Integer = o + 1 To (Entities.Count - 1)
            Try
                If Entities(o).Equals(Me) = False Then CollisionCheck(Entities(o))
            Catch
            End Try
        Next
        texture.Left = rect.pos.x
        texture.Top = rect.pos.y
    End Sub
End Class
Public Class Meteor
    Inherits Entity
    Const speedDefault = 0.9
    Const sizeDefault = 40
    Sub New()
        rect.width = (sizeDefault + ((Rnd() * 10) - 5 + (5 * gameMode))) * sizeFactor
        rect.height = (sizeDefault + ((Rnd() * 10) - 5 + (5 * gameMode))) * sizeFactor
        rect.pos = RandomPos()
        vel.y = (((Rnd() * speedDefault) / 2.0) + (speedDefault / 2.0)) * gameMode
        If GameDifficulty.hard Then
            vel.x = (Rnd() * vel.y) * 0.1
            RndXDirection()
        End If
        SetTextureRef(meteorTexture)
    End Sub
    Public Sub RndXDirection()
        Dim xD As Integer = CInt(Rnd())
        If xD = 1 Then vel.x *= -1
    End Sub
    Public Overrides Sub Update()
        rect.pos.x += vel.x * speedFactor
        rect.pos.y += vel.y * speedFactor
        For o As Integer = o + 1 To (Entities.Count - 1)
            Try
                If Entities(o).Equals(Me) = False Then CollisionCheck(Entities(o))
            Catch
            End Try
        Next
        texture.Left = rect.pos.x
        texture.Top = rect.pos.y

        oldPos.x = rect.pos.x
        oldPos.y = rect.pos.y
    End Sub
    Public Overrides Sub Interact(ByRef oEnt As Entity)
    End Sub
End Class