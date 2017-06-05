Public Class BrowserWrapPanel
    Inherits WrapPanel
    Protected Overrides Function MeasureOverride(availableSize As Size) As Size
        Dim maxChildWidth As Double = 0
        If (Children.Count > 0) Then
            For Each el In Children
                If (el.DesiredSize.Width > maxChildWidth) Then
                    maxChildWidth = el.DesiredSize.Width
                End If
            Next
        End If
        MinWidth = maxChildWidth
        Return MyBase.MeasureOverride(availableSize)
    End Function
End Class
