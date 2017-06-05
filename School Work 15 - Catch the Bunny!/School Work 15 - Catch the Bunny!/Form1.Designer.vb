<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBunnyCatcher
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.pnlGameRoom = New System.Windows.Forms.Panel()
        Me.picKirby = New System.Windows.Forms.PictureBox()
        Me.picCat = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.tmrGameTick = New System.Windows.Forms.Timer(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblTimeLeft = New System.Windows.Forms.Label()
        Me.lblMultiplier = New System.Windows.Forms.Label()
        Me.lblScore = New System.Windows.Forms.Label()
        Me.lstHiScores = New System.Windows.Forms.ListBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.pnlGameRoom.SuspendLayout()
        CType(Me.picKirby, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picCat, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlGameRoom
        '
        Me.pnlGameRoom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlGameRoom.Controls.Add(Me.picKirby)
        Me.pnlGameRoom.Controls.Add(Me.picCat)
        Me.pnlGameRoom.Location = New System.Drawing.Point(12, 43)
        Me.pnlGameRoom.Name = "pnlGameRoom"
        Me.pnlGameRoom.Size = New System.Drawing.Size(436, 473)
        Me.pnlGameRoom.TabIndex = 0
        '
        'picKirby
        '
        Me.picKirby.Image = Global.School_Work_15___Catch_the_Bunny_.My.Resources.Resources.kirby
        Me.picKirby.InitialImage = Global.School_Work_15___Catch_the_Bunny_.My.Resources.Resources.kirby
        Me.picKirby.Location = New System.Drawing.Point(79, 121)
        Me.picKirby.Name = "picKirby"
        Me.picKirby.Size = New System.Drawing.Size(48, 48)
        Me.picKirby.TabIndex = 1
        Me.picKirby.TabStop = False
        '
        'picCat
        '
        Me.picCat.Image = Global.School_Work_15___Catch_the_Bunny_.My.Resources.Resources.cat2
        Me.picCat.InitialImage = Global.School_Work_15___Catch_the_Bunny_.My.Resources.Resources.cat2
        Me.picCat.Location = New System.Drawing.Point(13, 28)
        Me.picCat.Name = "picCat"
        Me.picCat.Size = New System.Drawing.Size(64, 64)
        Me.picCat.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picCat.TabIndex = 0
        Me.picCat.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(241, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(171, 31)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Cat Catcher"
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(454, 466)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(220, 50)
        Me.btnStart.TabIndex = 2
        Me.btnStart.Text = "Start"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'tmrGameTick
        '
        Me.tmrGameTick.Interval = 10
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(454, 374)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 20)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Time Left"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(454, 405)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 20)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Multiplier"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(454, 438)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 20)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Score"
        '
        'lblTimeLeft
        '
        Me.lblTimeLeft.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTimeLeft.Location = New System.Drawing.Point(581, 374)
        Me.lblTimeLeft.Name = "lblTimeLeft"
        Me.lblTimeLeft.Size = New System.Drawing.Size(93, 20)
        Me.lblTimeLeft.TabIndex = 6
        Me.lblTimeLeft.Text = "40.00"
        Me.lblTimeLeft.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblMultiplier
        '
        Me.lblMultiplier.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMultiplier.Location = New System.Drawing.Point(612, 405)
        Me.lblMultiplier.Name = "lblMultiplier"
        Me.lblMultiplier.Size = New System.Drawing.Size(62, 20)
        Me.lblMultiplier.TabIndex = 7
        Me.lblMultiplier.Text = "1"
        Me.lblMultiplier.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblScore
        '
        Me.lblScore.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblScore.Location = New System.Drawing.Point(612, 438)
        Me.lblScore.Name = "lblScore"
        Me.lblScore.Size = New System.Drawing.Size(62, 20)
        Me.lblScore.TabIndex = 8
        Me.lblScore.Text = "1"
        Me.lblScore.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lstHiScores
        '
        Me.lstHiScores.FormattingEnabled = True
        Me.lstHiScores.Location = New System.Drawing.Point(458, 71)
        Me.lstHiScores.Name = "lstHiScores"
        Me.lstHiScores.Size = New System.Drawing.Size(216, 264)
        Me.lstHiScores.Sorted = True
        Me.lstHiScores.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(506, 43)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(128, 20)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Hi-Score Table"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(454, 342)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(55, 20)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Name"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(574, 344)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(100, 20)
        Me.txtName.TabIndex = 12
        '
        'frmBunnyCatcher
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(686, 528)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lstHiScores)
        Me.Controls.Add(Me.lblScore)
        Me.Controls.Add(Me.lblMultiplier)
        Me.Controls.Add(Me.lblTimeLeft)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.pnlGameRoom)
        Me.Name = "frmBunnyCatcher"
        Me.Text = "Cat Catcher"
        Me.pnlGameRoom.ResumeLayout(False)
        CType(Me.picKirby, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picCat, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlGameRoom As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents tmrGameTick As System.Windows.Forms.Timer
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblTimeLeft As System.Windows.Forms.Label
    Friend WithEvents lblMultiplier As System.Windows.Forms.Label
    Friend WithEvents lblScore As System.Windows.Forms.Label
    Friend WithEvents picKirby As System.Windows.Forms.PictureBox
    Friend WithEvents picCat As System.Windows.Forms.PictureBox
    Friend WithEvents lstHiScores As System.Windows.Forms.ListBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox

End Class
