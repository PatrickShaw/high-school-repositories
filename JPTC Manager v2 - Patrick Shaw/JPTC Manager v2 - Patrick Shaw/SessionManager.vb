Imports System.IO
' A person is a member of JPTC, use this when you need to do something with a memeber of JPTc
Public Class Person
    Public firstName As String = "Enter first name..."
    Public middleName As String = ""
    Public lastName As String = "Enter last name..."
    Public memberType As MemberType = memberType.none

    Public ID As Integer = 0
    Public Function FullName() As String
        If middleName = "" Then Return firstName + " " + lastName
        Return firstName + " " + middleName + " " + lastName
    End Function
    ' This is important to writing back to the Members.dtb
    Public Function GetSerial()
        Return ID.ToString() + "," + memberType.ToString() + "," + firstName + "," + middleName + "," + lastName
    End Function
    ' Returns the first 3 letters in a person's last name
    Public Function SummaryLastName() As String
        Dim stringTemp As String = ""
        For i As Long = 0 To lastName.Count - 1
            If i = 3 Then Return stringTemp
            stringTemp += UCase(lastName(i))
        Next
        Return stringTemp
    End Function
End Class
Public Class Session
    ' Session ID
    Public ID As Integer
    ' Day that session is held
    Public day As Days = Days.DAYNOTSET
    ' Start time (in 24 hour time)
    Public startHours As Long = 0
    Public startMinutes As Long = 0
    ' If makeup session use this:
    Public startDate As Date
    ' Time that session goes for
    Public lengthMinutes As Long = 0
    Public lengthHours As Long = 0
    ' The students that are attending the session
    Public students As New List(Of Person)
    ' The instructor that is attending the session
    Public instructor As Person
    ' The instructor that will be subbing in (if Nothing then the actual instructor is assumed to be teaching
    Public substitionInstructor As Person
    ' Constructor just incase...
    Public Sub New()
    End Sub
    ' Return day. Used just incase a change in code is made.
    Public Property GetDay As Days
        Get
            Return day
        End Get
        Set(value As Days)
            day = value
        End Set
    End Property
    ''' <summary>
    ''' Order: Session ID, Day, startingHours, startingMinutes, lengthHours, lengthMinutes, Instructor ID, Student IDs
    ''' Student IDs are split up by a |
    ''' </summary>
    Public Function ToStringPermaSess() As String
        Dim sTemp As String = ID.ToString() + "," + CInt(day).ToString() + "," + startHours.ToString() + "," + startMinutes.ToString() + "," + lengthMinutes.ToString() + "," + lengthHours.ToString() + "," + instructor.ID.ToString() + ","
        For i As Long = 0 To students.Count - 1
            sTemp += students(i).ID.ToString()
            If (i = students.Count - 1) Then Continue For
            sTemp += "|"
        Next
        Return sTemp
    End Function
End Class
' Manages sessions
Public Module SessionManager
    Public weeklySessions As New List(Of Session)
    Public Sub Initialise()

    End Sub
    ''' <summary>
    ''' Order: Session ID, Day, startingHours, startingMinutes, lengthHours, lengthMinutes, Instructor ID, Student IDs
    ''' Student IDs are split up by a |
    ''' </summary>
    Sub New()
        If File.Exists(".\Weekly Sessions.dtb") = False Then File.Create(".\Weekly Sessions.dtb")
        Dim stringLines As String() = File.ReadAllLines(".\Weekly Sessions.dtb")
        Dim stringWords As String()() = New String(stringLines.Count() - 1)() {}
        For i As Long = 0 To stringLines.Count - 1
            stringWords(i) = stringLines(i).Split(",")
            Dim sessTemp As New Session
            ' Set ID
            sessTemp.ID = Convert.ToInt16(stringWords(i)(0))
            ' Set day
            sessTemp.day = Convert.ToInt16(stringWords(i)(1))
            ' Set startHours
            sessTemp.startHours = Convert.ToInt16(stringWords(i)(2))
            ' Set startMinutes
            sessTemp.startMinutes = Convert.ToInt16(stringWords(i)(3))
            ' Set lengthMinutes
            sessTemp.lengthMinutes = Convert.ToInt16(stringWords(i)(4))
            ' Set lengthHours
            sessTemp.lengthHours = Convert.ToInt16(stringWords(i)(5))
            ' Set Instructor
            For p As Long = 0 To memberList.Count - 1
                If memberList(p).ID = Convert.ToInt16(stringWords(i)(6)) Then
                    sessTemp.instructor = memberList(p)
                End If
            Next
            ' Students in session
            Dim stringStudents As String() = stringWords(i)(7).Split("|")
            For o As Long = 0 To stringStudents.Count - 1
                For p As Long = 0 To memberList.Count - 1
                    If memberList(p).ID = Convert.ToInt16(stringStudents(o)) Then
                        sessTemp.students.Add(memberList(p))
                    End If
                Next
            Next
            weeklySessions.Add(sessTemp)
        Next
        lowestSessionIDAvailable = stringLines.Count - 1
    End Sub
    ' Adds a weekly session, it's important that you use this to add a weekly session
    Public Sub AddWeeklySession(ByVal permaSession As Session)
        File.AppendAllText(".\Weekly Sessions.dtb", permaSession.ToStringPermaSess() + Environment.NewLine)
        lowestSessionIDAvailable += 1
        weeklySessions.Add(permaSession)
    End Sub
End Module
' Manages members of JPTC (Instructors AND students)
Public Module MemberManager
    Public memberList As New List(Of Person)
    Public Sub Initialise()

    End Sub
    ' BLACKLIST ORDER: memberID -> memberType -> firstName -> middleName -> lastName
    Sub New()
        ' Create Members.dtb if it doesn't exist
        If File.Exists(".\Members.dtb") = False Then File.Create(".\Members.dtb")
        ' Create an array for all the lines in the Members.dtb
        Dim stringLines As String() = File.ReadAllLines(".\Members.dtb")
        Dim stringWords As String()() = New String(stringLines.Count() - 1)() {}
        ' Iterate through all the lines
        For i As Long = 0 To stringLines.Count - 1
            ' Split the lines up into individual words (or at least just seperate them everytime there is a comma)
            stringWords(i) = stringLines(i).Split(",")
            ' create a new member (person)
            Dim memberTemp As Person = New Person()
            ' Now fill the member with the information from the database file thing
            memberTemp.ID = Convert.ToInt16(stringWords(i)(0))
            Select Case stringWords(i)(1)
                Case MemberType.student.ToString()
                    memberTemp.memberType = MemberType.student
                Case MemberType.instructor.ToString()
                    memberTemp.memberType = MemberType.instructor
            End Select
            memberTemp.firstName = stringWords(i)(2)
            memberTemp.middleName = stringWords(i)(3)
            memberTemp.lastName = stringWords(i)(4)
            memberList.Add(memberTemp)
        Next
        lowestMemberIDAvailable = stringLines.Count - 1
    End Sub
    ' This adds a new member, use this everytime you need to add a new member to the program (which you shouldn't be because the SAC says not to)
    Public Sub AddMember(ByVal memberT As Person)
        File.AppendAllText(".\Members.dtb", memberT.GetSerial() + Environment.NewLine)
        lowestMemberIDAvailable += 1
        memberList.Add(memberT)
    End Sub
End Module
' Manages the blacklist
Public Module BlacklistManager
    Public blackListStudents As New List(Of Person)
    Public Sub Initialise()

    End Sub

    Sub New()
        ' Gets the lines in the blacklist
        Dim stringLines As String() = File.ReadAllLines(".\Blacklist.dtb")
        For i As Long = 0 To stringLines.Count - 1
            For o As Long = 0 To memberList.Count - 1
                If Convert.ToInt16(stringLines(i)) = memberList(o).ID Then
                    blackListStudents.Add(memberList(o))
                End If
            Next
        Next
    End Sub
    Public Sub AddToBlacklist(ByVal student As Person)
        If IsAdmin() = False Then Return
        File.AppendAllText(".\Blacklist.dtb", student.ID.ToString() + Environment.NewLine)
        blackListStudents.Add(student)
    End Sub
End Module
