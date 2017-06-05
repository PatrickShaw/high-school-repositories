Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim lstArray() As ListBox = New ListBox(11) {lst1, lst2, lst3, lst4, lst5, lst6, lst7, lst8, lst9, lst10, lst11, lst12}
        For i As Integer = 0 To 143
            lstArray(i Mod 12).Items.Add(((i Mod 12) + 1) * (lstArray(i Mod 12).Items.Count + 1))
        Next
    End Sub
End Class
