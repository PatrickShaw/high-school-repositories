Public Module CurrencyRate
    Public USDValue As Single = 0.89
    Public UKValue As Single = 0.58
    Public EuroValue As Single = 0.67
End Module
Public Class Form1

    Dim currencySelected As Single = CurrencyRate.USDValue

    Private Function Sign() As Char
        Select Case currencySelected
            Case USDValue
                lblEReverseCurrency.Text = "Enter $US"
                lblCovertedCurrency.Text = "Converted to $US"
                Return "$"
            Case UKValue

                lblEReverseCurrency.Text = "Enter Pounds"
                lblCovertedCurrency.Text = "Converted to Pounds"
                Return "£"
            Case EuroValue

                lblEReverseCurrency.Text = "Enter Euros"
                lblCovertedCurrency.Text = "Converted to Euros"
                Return "€"
        End Select
        Return "ERROR"
    End Function
    Private Sub btnQuit_Click(sender As Object, e As EventArgs) Handles btnQuit.Click
        End
    End Sub

    Private Sub rbUSDollars_CheckedChanged(sender As Object, e As EventArgs) Handles rbUSDollars.CheckedChanged
        currencySelected = USDValue
        ChangeValue()
    End Sub

    Private Sub rbUKPounds_CheckedChanged(sender As Object, e As EventArgs) Handles rbUKPounds.CheckedChanged
        currencySelected = UKValue
        ChangeValue()
    End Sub

    Private Sub rbEuros_CheckedChanged(sender As Object, e As EventArgs) Handles rbEuros.CheckedChanged
        currencySelected = EuroValue
        ChangeValue()
    End Sub

    Private Sub btnConvert_Click(sender As Object, e As EventArgs) Handles btnConvert.Click
        txtInput.Text = ""
        txtInputReverse.Text = ""
        lblOutputAUS.Text = ""
        lblCovertedCurrency.Text = ""
    End Sub
    Private Sub ChangeValue()
        Try
            lblOutputConverted.Text = Sign() + Format((Val(txtInput.Text) * currencySelected), "Fixed")
            lblOutputAUS.Text = "$" & Format(Val(txtInputReverse.Text) / currencySelected, "Fixed")
        Catch
        End Try

    End Sub

    Private Sub txtInput_TextChanged(sender As Object, e As EventArgs) Handles txtInput.TextChanged

        ChangeValue()
    End Sub

    Private Sub txtInputReverse_TextChanged(sender As Object, e As EventArgs) Handles txtInputReverse.TextChanged
        ChangeValue()
    End Sub

    Private Sub btnApply_Click(sender As Object, e As EventArgs) Handles btnApply.Click
        Select Case (currencySelected)
            Case EuroValue
                EuroValue = Val(txtEditCurrency.Text)
                currencySelected = EuroValue
            Case UKValue
                UKValue = Val(txtEditCurrency.Text)
                currencySelected = UKValue
            Case USDValue
                USDValue = Val(txtEditCurrency.Text)
                currencySelected = USDValue
        End Select
        ChangeValue()
    End Sub
End Class