Imports System.IO

Enum GameDifficulty
    easy = 0.75
    medium = 1
    hard = 1.5
End Enum
Public Module GameFunctions
    Public speedFactor As Double = 1
    Public sizeFactor As Double = 1
    Public meteorRate As Integer = 20
    Public gameMode = GameDifficulty.medium
    Public score As Double = 0
    Public stopWatch As Stopwatch = New Stopwatch
    Public meteorwatch As Stopwatch = New Stopwatch
    Public Entities As List(Of Entity) = New List(Of Entity)
    Public shipTexture As Bitmap
    Public meteorTexture As Bitmap
    Const levelUpWaitMax = 1000
    Public WHeld = False
    Public AHeld = False
    Public SHeld = False
    Public DHeld = False
    Public Sub IncreaseSize()
        sizeFactor += 0.0005
        If sizeFactor = 2.5 Then sizeFactor = 2.5
    End Sub
    Public Sub LoadTextures()
        Dim myAssembly As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly()
        Dim myStream As Stream = myAssembly.GetManifestResourceStream("School_Work_17___Meteor_Dodge.ship.png")
        shipTexture = New Bitmap(myStream)

        myStream = myAssembly.GetManifestResourceStream("School_Work_17___Meteor_Dodge.Meteor.png")
        meteorTexture = New Bitmap(myStream)

    End Sub
    Public Sub GameUpdate()
        IncreaseSpeed()
        IncreaseSize()
        IncreaseScore()
        Dim xNoPressed As Boolean = True
        Dim yNoPressed As Boolean = True
        If AHeld Then
            xNoPressed = False
            Entities(0).vel.x = -6
        End If
        If DHeld Then
            Entities(0).vel.x = 6
            xNoPressed = False
        End If
        If WHeld Then
            Entities(0).vel.y = -6
            yNoPressed = False
        End If
        If SHeld Then
            Entities(0).vel.y = 6
            yNoPressed = False
        End If
        If xNoPressed = True Then Entities(0).vel.x = 0
        If yNoPressed = True Then Entities(0).vel.y = 0
        If (stopWatch.ElapsedMilliseconds >= levelUpWaitMax * gameMode) Then
            IncreaseMeteorRate()
            stopWatch.Restart()
        End If

        If (Rnd() * 1000.0) <= meteorRate Then Entities.Add(New Meteor())

        For i As Integer = 0 To (Entities.Count - 1)
            Try
                Entities(i).Update()
                If Entities(i).rect.pos.y >= frmGame.pnlGameRoom.Bottom Then
                    Entities(i).texture.Dispose()
                    Entities.RemoveAt(i)
                End If
            Catch
            End Try
        Next
    End Sub
    Public Sub IncreaseMeteorRate()
        If meteorRate <= 800 Then meteorRate += 1
    End Sub
    Public Sub IncreaseSpeed()
        speedFactor += gameMode / 1000.0
        If speedFactor >= 10 Then speedFactor = 10
    End Sub
    Public Sub IncreaseScore()
        score += Math.Pow(meteorRate / 10.0, 1.05) * Math.Pow(speedFactor, 1.01) * gameMode * sizeFactor
        frmGame.lblScore.Text = Math.Round(score, 0)
    End Sub
    Public Function RandomPos() As Vector2
        Return New Vector2(Rnd() * frmGame.pnlGameRoom.Width + frmGame.pnlGameRoom.Left, frmGame.pnlGameRoom.Top)
    End Function
    Public Sub GameOver()
        speedFactor = 1
        meteorRate = 20
        sizeFactor = 1
        For Each ent In Entities
            ent.texture.Dispose()
        Next
        Entities.Clear()
        frmGame.tmrGame.Enabled = False
        frmGame.btnStart.Enabled = True
        frmGame.txtName.ReadOnly = False
        frmGame.txtName.Enabled = True
        frmGame.rdbEasy.Enabled = True
        frmGame.rdbMedium.Enabled = True
        frmGame.rdbHard.Enabled = True
        frmGame.pnlGameRoom.Enabled = True
        frmGame.lstHiScores.Enabled = True
        AddHiScore()
    End Sub
    Public Sub AddHiScore()
        Dim entry As String
        Dim rScore = Math.Round(score, 0)
        entry = Math.Round(score, 0) & " , " + frmGame.txtName.Text
        Select Case (rScore)
            Case 1 To 9
                entry = "0000000" & rScore & " , " + frmGame.txtName.Text
            Case 10 To 99
                entry = "000000" & rScore & " , " + frmGame.txtName.Text
            Case 100 To 999
                entry = "00000" & rScore & " , " + frmGame.txtName.Text
            Case 1000 To 9999
                entry = "0000" & rScore & " , " + frmGame.txtName.Text
            Case 10000 To 99999
                entry = "000" & rScore & " , " + frmGame.txtName.Text
            Case 100000 To 999999
                entry = "00" & rScore & " , " + frmGame.txtName.Text
            Case 1000000 To 9999999
                entry = "0" & rScore & " , " + frmGame.txtName.Text
        End Select
        frmGame.lstHiScores.Items.Add(entry)
        If (frmGame.lstHiScores.Items.Count > 50) Then
            frmGame.lstHiScores.Items.RemoveAt(0)
        End If
    End Sub
    Public Sub GameStart()
        If (frmGame.txtName.Text.Length = 0) Then
            MsgBox("Please enter a name.")
            Return
        End If
        Entities.Add(New Ship())
        frmGame.tmrGame.Enabled = True
        frmGame.btnStart.Enabled = False
        frmGame.txtName.ReadOnly = True
        frmGame.txtName.Enabled = False
        frmGame.rdbEasy.Enabled = False
        frmGame.rdbMedium.Enabled = False
        frmGame.rdbHard.Enabled = False
        frmGame.pnlGameRoom.Enabled = False
        frmGame.lstHiScores.Enabled = False
        score = 0
    End Sub
End Module
