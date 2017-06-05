Imports System.IO
Imports System.Text
' A person is a member of JPTC, use this when you need to do something with a memeber of JPTc
Public Class Person
    Public firstName As String = "Enter first name..."
    Public middleName As String = ""
    Public lastName As String = "Enter last name..."
    Public memberType As MemberType = memberType.none
    Public ID As Integer = 0
    ' Eg. My name would return "Patrick Leong Shaw"
    Public Function FullName() As String
        If middleName = "" Then Return firstName + " " + lastName
        Return firstName + " " + middleName + " " + lastName
    End Function
    ' This is important to writing back to the Members.dtb
    Public Overridable Function GetSerial() As String
        Return ID.ToString() + "," + memberType.ToString() + "," + firstName + "," + middleName + "," + lastName
    End Function
    ' Returns the first 3 letters in a person's last name
    ' Eg. My name would return "SHA"
    Public Function SummaryLastName() As String
        Dim stringTemp As String = ""
        For i As Long = 0 To lastName.Count - 1
            If i = 3 Then Return stringTemp
            stringTemp += UCase(lastName(i))
        Next
        Return stringTemp
    End Function
End Class
Public Class Student
    Inherits Person
    Public street As String
    Public postCode As String = ""
    Public suburb As String
    Public contact As String
    Public contactAlt As String
    Public parentName As String
    Public DOB As DateTime
    Public classesAttended As Long = 0
    ' ID, firstName, middleName, lastName, DOB, Street, Suburb, postcode, contact, contact alt, classesAttended 
    Public Overrides Function GetSerial() As String
        Return ID & "," + firstName + "," + middleName + "," + lastName + "," & DOB.Day & "," & DOB.Month & "," & DOB.Year & "," + street + "," + suburb + "," + postCode + "," + parentName + "," + contact + "," + contactAlt + "," + classesAttended.ToString()
    End Function
    Public Function GetInvoice() As String
        Const dollarsPerHour = 45
        Return parentName + "," + street + "," + suburb + "," + postCode + "," + FullName() & (classesAttended * dollarsPerHour)
    End Function
End Class
Public Class Session
    ' Name of session -> Used for makeup sessions
    Public name As String = ""
    ' Session ID
    Public ID As Integer
    ' SessionType
    Public sessType As SessionType = SessionType.none
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
    ' The instructor that will be subbing in (if Nothing then the actual instructor is assumed to be teaching) -. Currently an arbitrary variable (not implemented)
    Public substitionInstructor As Person
    ' Constructor just incase...
    Public Sub New(sessTypeT As SessionType)
        sessType = sessTypeT
    End Sub
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
    ' MAKEUP SESSION WRITE ORDER: startHours, startMinutes, lengthHours, lengthMinutes, instructor, students
    Public Function ToStringMakeupSess() As String
        Dim sTemp As String = startHours.ToString() + "," + startMinutes.ToString() + "," + lengthHours.ToString() + "," + lengthMinutes.ToString() + "," + instructor.ID.ToString() + ","
        For i As Long = 0 To students.Count - 1
            sTemp += students(i).ID.ToString()
            If (i = students.Count - 1) Then Continue For
            sTemp += "|"
        Next
        Return sTemp
    End Function
    ' Getting hours after midnight
    ' Start of session
    Public Function StartTimeIn24Hours() As Double
        Return startHours + CDbl(startMinutes) / 60.0
    End Function
    ' End of session
    Public Function EndTimeIn24Hours() As Double
        Return StartTimeIn24Hours() + lengthHours + CDbl(lengthMinutes) / 60.0
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
            If stringLines(i) = "" Then Continue For
            stringWords(i) = stringLines(i).Split(",")
            Dim sessTemp As New Session(SessionType.weekly)
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
            For p As Long = 0 To instructorList.Count - 1
                If instructorList(p).ID = Convert.ToInt16(stringWords(i)(6)) Then
                    sessTemp.instructor = instructorList(p)
                End If
            Next
            ' Students in session
            Dim stringStudents As String() = stringWords(i)(7).Split("|")
            For o As Long = 0 To stringStudents.Count - 1
                For p As Long = 0 To studentList.Count - 1
                    If studentList(p).ID = Convert.ToInt16(stringStudents(o)) Then
                        sessTemp.students.Add(studentList(p))
                    End If
                Next
            Next
            weeklySessions.Add(sessTemp)
        Next
        lowestSessionIDAvailable = stringLines.Count
    End Sub
    ' Adds a weekly session, it's important that you use this to add a weekly session
    Public Sub AddWeeklySession(ByVal permaSession As Session)
        File.AppendAllText(".\Weekly Sessions.dtb", permaSession.ToStringPermaSess() + Environment.NewLine)
        lowestSessionIDAvailable += 1
        weeklySessions.Add(permaSession)
    End Sub
    Public Sub EditMakeupSession(ByRef makeupSession As Session, oldSessionSerial As String)
        Dim sessDate As String = makeupSession.startDate.Date
        sessDate = sessDate.Replace("/", "-")
        Dim fileName = ".\Makeup Sessions\" + sessDate + ".dtb"
        If File.Exists(fileName) Then
            Dim stringLines As String() = File.ReadAllLines(fileName)
            For i As Long = 0 To stringLines.Count - 1
                If stringLines(i) <> oldSessionSerial Then Continue For
                MsgBox("Tries")
                stringLines(i) = makeupSession.ToStringMakeupSess()
            Next
            File.WriteAllText(fileName, "")
            File.AppendAllLines(fileName, stringLines)
        End If
    End Sub
    ' Add a makeup session
    Public Sub AddMakeupSession(ByVal makeupSession As Session)
        Dim sessDate As String = makeupSession.startDate.Date
        sessDate = sessDate.Replace("/", "-")
        Dim fileName = ".\Makeup Sessions\" + sessDate + ".dtb"
        If File.Exists(fileName) = False Then
            ' Create or overwrite the file. 
            Using fs As StreamWriter = File.CreateText(fileName)
            End Using
        End If
        File.AppendAllText(fileName, makeupSession.ToStringMakeupSess() + Environment.NewLine)
    End Sub
    Public Function ReadMakeupSessions(dateT As Date) As Session()
        Dim convertedDate As String = dateT
        convertedDate = convertedDate.Replace("/", "-")
        Dim fileName = ".\Makeup Sessions\" + convertedDate + ".dtb"
        If File.Exists(fileName) = False Then Return New Session() {}
        Dim stringLines As String() = File.ReadAllLines(".\Makeup Sessions\" + convertedDate + ".dtb")
        Dim sessionsForDay As Session() = New Session(stringLines.Count - 1) {}
        For i As Long = 0 To stringLines.Count - 1
            Dim stringWords As String() = stringLines(i).Split(",")
            sessionsForDay(i) = New Session(SessionType.makeup)
            sessionsForDay(i).startHours = Convert.ToInt16(stringWords(0))
            sessionsForDay(i).startMinutes = Convert.ToInt16(stringWords(1))
            sessionsForDay(i).lengthHours = Convert.ToInt16(stringWords(2))
            sessionsForDay(i).lengthMinutes = Convert.ToInt16(stringWords(3))
            sessionsForDay(i).startDate = dateT
            sessionsForDay(i).day = dateT.DayOfWeek
            For p As Long = 0 To instructorList.Count - 1
                If instructorList(p).ID = Convert.ToInt16(stringWords(4)) Then
                    sessionsForDay(i).instructor = instructorList(p)
                End If
            Next
            ' Students in session
            Dim stringStudents As String() = stringWords(5).Split("|")
            For o As Long = 0 To stringStudents.Count - 1
                For p As Long = 0 To studentList.Count - 1
                    If studentList(p).ID = Convert.ToInt16(stringStudents(o)) Then
                        sessionsForDay(i).students.Add(studentList(p))
                    End If
                Next
            Next
        Next
        Return sessionsForDay
    End Function
    Public Sub RewriteWeeklySessions()
        File.WriteAllText(".\Weekly Sessions.dtb", "")
        For i As Long = 0 To weeklySessions.Count - 1
            File.AppendAllText(".\Weekly Sessions.dtb", weeklySessions(i).ToStringPermaSess() + Environment.NewLine)
        Next
    End Sub
End Module
' Manages members of JPTC (Instructors AND students)
Public Module MemberManager
    Public studentList As New List(Of Student)
    Public instructorList As New List(Of Person)
    Public Sub Initialise()
    End Sub
    ' BLACKLIST ORDER: memberID -> memberType -> firstName -> middleName -> lastName
    Sub New()
        ' INSTRUCTORS ===================================
        If File.Exists(".\Instructors.dtb") = False Then File.Create(".\Instructors.dtb")
        Dim instructorLines As String() = File.ReadAllLines(".\Instructors.dtb")
        Dim instructorWords As String()() = New String(instructorLines.Count() - 1)() {}
        ' Iterate through all the lines
        For i As Long = 0 To instructorLines.Count - 1
            If instructorLines(i) = "" Then Continue For
            ' Split the lines up into individual words (or at least just seperate them everytime there is a comma)
            instructorWords(i) = instructorLines(i).Split(",")
            ' create a new member (person)
            Dim memberTemp As Student = New Student()
            ' Now fill the member with the information from the database file thing
            memberTemp.ID = Convert.ToInt16(instructorWords(i)(0))
            memberTemp.firstName = instructorWords(i)(2)
            memberTemp.middleName = instructorWords(i)(3)
            memberTemp.lastName = instructorWords(i)(4)
            memberTemp.memberType = MemberType.instructor

            instructorList.Add(memberTemp)
        Next 
        ' STUDENTS ======================================
        ' Create Members.dtb if it doesn't exist
        If File.Exists(".\Students.dtb") = False Then
            File.Create(".\Students.dtb")
            Return
        End If
        ' Create an array for all the lines in the Members.dtb
        Dim stringLines As String() = File.ReadAllLines(".\Students.dtb")
        Dim stringWords As String()() = New String(stringLines.Count() - 1)() {}
        ' Iterate through all the lines
        ' First name, last name, DOB, adress, suburb, postcode, parent name, contact detail, alternative contact details, class attended
        For i As Long = 0 To stringLines.Count - 1
            If stringLines(i) = "" Then Continue For
            ' Split the lines up into individual words (or at least just seperate them everytime there is a comma)
            stringWords(i) = stringLines(i).Split(",")
            ' create a new member (person)
            Dim memberTemp As Student = New Student()
            ' Now fill the member with the information from the database file thing
            memberTemp.ID = Convert.ToInt16(stringWords(i)(0))
            memberTemp.firstName = stringWords(i)(1)
            memberTemp.middleName = stringWords(i)(2)
            memberTemp.lastName = stringWords(i)(3)
            Dim dateT As DateTime = New DateTime(Convert.ToInt32(stringWords(i)(6)), Convert.ToInt32(stringWords(i)(5)), Convert.ToInt32(stringWords(i)(4)))
            memberTemp.DOB = dateT
            memberTemp.street = stringWords(i)(7)
            memberTemp.suburb = stringWords(i)(8)
            memberTemp.postCode = stringWords(i)(9)
            memberTemp.parentName = stringWords(i)(10)
            memberTemp.contact = stringWords(i)(11)
            memberTemp.contactAlt = stringWords(i)(12)
            memberTemp.classesAttended = stringWords(i)(11)

            memberTemp.memberType = MemberType.student
            studentList.Add(memberTemp)
        Next
        lowestMemberIDAvailable = stringLines.Count + instructorLines.Count
    End Sub
    ' This adds a new member, use this everytime you need to add a new member to the program (which you shouldn't be because the SAC says not to)
    Public Sub AddMember(ByVal memberT As Person)
        lowestMemberIDAvailable += 1
        If memberT.memberType = MemberType.student Then
            studentList.Add(memberT)
            File.AppendAllText(".\Students.dtb", memberT.GetSerial() + Environment.NewLine)
        ElseIf memberT.memberType = MemberType.instructor Then
            instructorList.Add(memberT)
            File.AppendAllText(".\Instructors.dtb", memberT.GetSerial() + Environment.NewLine)
        End If
    End Sub
    Public Sub AddStudent(ByVal memberT As Student)
        lowestMemberIDAvailable += 1
            studentList.Add(memberT)
            File.AppendAllText(".\Students.dtb", memberT.GetSerial() + Environment.NewLine)
    End Sub
    Public Sub RewriteAllStudents()
        File.Delete(".\Students.dtb")
        File.Create(".\Students.dtb")
        For Each Student In studentList
            File.AppendAllText(".\Students.dtb", Student.GetSerial() + Environment.NewLine)
        Next
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
            For o As Long = 0 To studentList.Count - 1
                If Convert.ToInt16(stringLines(i)) = studentList(o).ID Then
                    blackListStudents.Add(studentList(o))
                End If
            Next
        Next
    End Sub
    ' Only the student IDs are stored in the file
    ' NOTE: You need to use the administrator account to do anything to the black list
    Public Sub AddToBlacklist(ByVal student As Person)
        If IsAdmin() = False Then
            Return
        End If
        File.AppendAllText(".\Blacklist.dtb", student.ID.ToString() + Environment.NewLine)
        blackListStudents.Add(student)
    End Sub
End Module
' Manages the blacklist
Public Module AbsenceManager
    Public absenceList As New List(Of Person)
    Public Sub Initialise()
    End Sub
    Sub New()
        ' Gets the lines in the blacklist
        Dim stringLines As String() = File.ReadAllLines(".\Absence List.dtb")
        For i As Long = 0 To stringLines.Count - 1
            For o As Long = 0 To studentList.Count - 1
                If Convert.ToInt16(stringLines(i)) = studentList(o).ID Then
                    absenceList.Add(studentList(o))
                End If
            Next
        Next
    End Sub
    ' Only student IDs are stored in the file
    Public Sub AddToAbsentList(ByVal student As Person)
        File.AppendAllText(".\Absence List.dtb", student.ID.ToString() + Environment.NewLine)
        absenceList.Add(student)
    End Sub
End Module