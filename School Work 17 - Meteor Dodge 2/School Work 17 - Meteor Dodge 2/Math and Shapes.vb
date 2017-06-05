Public Structure Vector2
    Dim x As Double
    Dim y As Double
    Shared Sub New()

    End Sub
    Sub New(xT As Double, yT As Double)
        x = xT
        y = yT
    End Sub
End Structure
Public Structure Rect
    Dim pos As Vector2
    Dim width As Double
    Dim height As Double
    Public Function Intersects(oRect As Rect) As Boolean
        If (pos.x < oRect.Right() And Right() > oRect.pos.x And pos.y < oRect.Bottom() And Bottom() > oRect.pos.y) Then
            Return True
        End If
        Return False
    End Function
    Public Function Right() As Double
        Return pos.x + width
    End Function
    Public Function Bottom() As Double
        Return pos.y + height
    End Function
End Structure