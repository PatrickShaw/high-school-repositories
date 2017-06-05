Imports System.IO
Public Class Student
    Public firstName As String = ""
    Public middleNAme As String = ""
    Public lastName As String = ""
    Public marks As New List(Of Double)
    Public Function FullName() As String
        If middleNAme = "" Then Return firstName + " " + lastName
        Return firstName + " " + middleNAme + " " + lastName
    End Function
End Class
Module Manager
    Public Sub Initialise()
        If File.Exists(".\marks.dtb") = False Then
            Using fs As FileStream = File.Create(".\marks.dtb")
            End Using
        End If
        Dim stringLines As String() = File.ReadAllLines(".\marks.dtb")
        If stringLines(0) = "" Then Return
        For i As Long = 0 To stringLines.Count - 1
            Dim studentT As Student = New Student()
            Dim stringWords As String() = stringLines(i).Split(",")
            studentT.firstName = stringWords(0)
            studentT.middleNAme = stringWords(1)
            studentT.lastName = stringWords(2)
            Dim marks As String() = stringWords(3).Split("|")
            For o As Long = 0 To marks.Count - 1
                studentT.marks.Add(Convert.ToDouble(marks(o)))
            Next
        Next
    End Sub
    Public Sub Rewrite()
        If File.Exists(".\marks.dtb") Then
            File.Delete(".\marks.dtb")
        End If
        Using fs As FileStream = File.Create(".\marks.dtb")
        End Using
        For i As Long = 0 To students.Count - 1
            Dim sTemp As String = students(i).firstName + "," + students(i).middleNAme + "," + students(i).lastName + ","
            For o As Long = 0 To students(i).marks.Count - 1
                If o = students(i).marks.Count - 1 Then
                    sTemp += students(i).marks(o)
                Else
                    sTemp += students(i).marks(o) + "|"
                End If
            Next
            sTemp += Environment.NewLine
            File.AppendText(sTemp)
        Next
    End Sub
    Public students As List(Of Student)
End Module
