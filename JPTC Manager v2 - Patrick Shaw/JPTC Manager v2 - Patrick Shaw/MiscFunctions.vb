Public Module MiscFunctions
    Public Function AMPMFrom24Hour(ByVal hourT As Long, ByVal minuteT As Long) As String
        Dim AMPM As String = "AM"
        If hourT >= 12 Then
            AMPM = "PM"
            hourT -= 12
        End If
        If minuteT = 60 Then
            minuteT = 0
            hourT += 1
        End If
        If hourT = 0 Then hourT = 12
        If minuteT = 0 Then Return hourT.ToString() + ":" + minuteT.ToString + "0 " + AMPM
        Return hourT.ToString() + ":" + minuteT.ToString + " " + AMPM
    End Function
    Public Function DarkenColour(ByVal colour As Color, Optional ByVal darkeningFactor As Decimal = 2D)
        Dim R As Decimal = colour.R
        Dim G As Decimal = colour.G
        Dim B As Decimal = colour.B
        R /= darkeningFactor
        G /= darkeningFactor
        B /= darkeningFactor
        Return Color.FromRgb(R, G, B)
    End Function
End Module
