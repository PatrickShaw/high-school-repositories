Imports System.IO
Public Class ctrSession_Viewer
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    ' Order: ID->memberType->firstName-middleName->lastName->marks
    ' Mark Order: name -> mark
    Public Sub ReadEverythingz()
        Dim markLines As String() = File.ReadAllLines(".\Marks.dtb")
        For i As Long = 0 To markLines.Count - 1
            Dim studentT As Person = New Person()
            Dim words As String() = markLines(i).Split(",")
            studentT.ID = Convert.ToInt64(words(0))
            studentT.memberType = Convert.ToInt64(words(1))
            studentT.firstName = words(2)
            studentT.middleName = words(3)
            studentT.lastName = words(4)
            Dim moreWords As String() = words(5).Split("|")
            For p As Long = 0 To moreWords.Count - 1
                Dim markT As Mark = New Mark()
                Dim evenMoreWords As String() = moreWords(p).Split("`")
                markT.name = evenMoreWords(0)
                markT.mark = Convert.ToInt64(evenMoreWords(1))
                studentT.marks.Add(markT)
            Next

        Next
    End Sub

End Class
Public Module StudentManager
    Public students As New List(Of Person)
End Module
Public Class Mark
    Public mark As Double = 0
    Public name As String = ""
    Public Function GetSerial() As String
        Return name + "`" & mark
    End Function
End Class
