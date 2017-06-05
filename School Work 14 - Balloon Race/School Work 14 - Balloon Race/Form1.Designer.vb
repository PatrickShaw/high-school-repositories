<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBalloonRace
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
        Me.Label = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuStart = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuQuit = New System.Windows.Forms.ToolStripMenuItem()
        Me.pnlFinish = New System.Windows.Forms.Panel()
        Me.btnW = New System.Windows.Forms.Button()
        Me.btnQ = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.mnuPause = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblScore1 = New System.Windows.Forms.Label()
        Me.lblScore2 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnB = New System.Windows.Forms.Button()
        Me.btnV = New System.Windows.Forms.Button()
        Me.lblScore3 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnP = New System.Windows.Forms.Button()
        Me.btnO = New System.Windows.Forms.Button()
        Me.picBalloon3 = New System.Windows.Forms.PictureBox()
        Me.picBalloon2 = New System.Windows.Forms.PictureBox()
        Me.picBalloon1 = New System.Windows.Forms.PictureBox()
        Me.tmrGameTime = New System.Windows.Forms.Timer(Me.components)
        Me.MenuStrip1.SuspendLayout()
        CType(Me.picBalloon3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picBalloon2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picBalloon1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label
        '
        Me.Label.AutoSize = True
        Me.Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label.Location = New System.Drawing.Point(209, 35)
        Me.Label.Name = "Label"
        Me.Label.Size = New System.Drawing.Size(187, 31)
        Me.Label.TabIndex = 0
        Me.Label.Text = "Balloon Race"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.mnuStart, Me.mnuPause, Me.mnuQuit})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(610, 24)
        Me.MenuStrip1.TabIndex = 2
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(12, 20)
        '
        'mnuStart
        '
        Me.mnuStart.Name = "mnuStart"
        Me.mnuStart.Size = New System.Drawing.Size(43, 20)
        Me.mnuStart.Text = "Start"
        '
        'mnuQuit
        '
        Me.mnuQuit.Name = "mnuQuit"
        Me.mnuQuit.Size = New System.Drawing.Size(42, 20)
        Me.mnuQuit.Text = "Quit"
        '
        'pnlFinish
        '
        Me.pnlFinish.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.pnlFinish.Location = New System.Drawing.Point(577, 76)
        Me.pnlFinish.Name = "pnlFinish"
        Me.pnlFinish.Size = New System.Drawing.Size(21, 177)
        Me.pnlFinish.TabIndex = 3
        Me.pnlFinish.TabStop = True
        '
        'btnW
        '
        Me.btnW.Location = New System.Drawing.Point(60, 279)
        Me.btnW.Name = "btnW"
        Me.btnW.Size = New System.Drawing.Size(42, 43)
        Me.btnW.TabIndex = 6
        Me.btnW.Text = "W"
        Me.btnW.UseVisualStyleBackColor = True
        '
        'btnQ
        '
        Me.btnQ.Location = New System.Drawing.Point(12, 279)
        Me.btnQ.Name = "btnQ"
        Me.btnQ.Size = New System.Drawing.Size(42, 43)
        Me.btnQ.TabIndex = 1
        Me.btnQ.Text = "Q"
        Me.btnQ.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 256)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 20)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Player 1:"
        '
        'mnuPause
        '
        Me.mnuPause.Name = "mnuPause"
        Me.mnuPause.Size = New System.Drawing.Size(50, 20)
        Me.mnuPause.Text = "Pause"
        '
        'lblScore1
        '
        Me.lblScore1.AutoSize = True
        Me.lblScore1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblScore1.Location = New System.Drawing.Point(84, 256)
        Me.lblScore1.Name = "lblScore1"
        Me.lblScore1.Size = New System.Drawing.Size(18, 20)
        Me.lblScore1.TabIndex = 12
        Me.lblScore1.Text = "0"
        '
        'lblScore2
        '
        Me.lblScore2.AutoSize = True
        Me.lblScore2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblScore2.Location = New System.Drawing.Point(331, 256)
        Me.lblScore2.Name = "lblScore2"
        Me.lblScore2.Size = New System.Drawing.Size(18, 20)
        Me.lblScore2.TabIndex = 16
        Me.lblScore2.Text = "0"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(259, 256)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(78, 20)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Player 2:"
        '
        'btnB
        '
        Me.btnB.Location = New System.Drawing.Point(307, 279)
        Me.btnB.Name = "btnB"
        Me.btnB.Size = New System.Drawing.Size(42, 43)
        Me.btnB.TabIndex = 14
        Me.btnB.Text = "B"
        Me.btnB.UseVisualStyleBackColor = True
        '
        'btnV
        '
        Me.btnV.Location = New System.Drawing.Point(259, 279)
        Me.btnV.Name = "btnV"
        Me.btnV.Size = New System.Drawing.Size(42, 43)
        Me.btnV.TabIndex = 13
        Me.btnV.Text = "V"
        Me.btnV.UseVisualStyleBackColor = True
        '
        'lblScore3
        '
        Me.lblScore3.AutoSize = True
        Me.lblScore3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblScore3.Location = New System.Drawing.Point(580, 256)
        Me.lblScore3.Name = "lblScore3"
        Me.lblScore3.Size = New System.Drawing.Size(18, 20)
        Me.lblScore3.TabIndex = 20
        Me.lblScore3.Text = "0"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(508, 256)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(78, 20)
        Me.Label7.TabIndex = 19
        Me.Label7.Text = "Player 3:"
        '
        'btnP
        '
        Me.btnP.Location = New System.Drawing.Point(556, 279)
        Me.btnP.Name = "btnP"
        Me.btnP.Size = New System.Drawing.Size(42, 43)
        Me.btnP.TabIndex = 18
        Me.btnP.Text = "P"
        Me.btnP.UseVisualStyleBackColor = True
        '
        'btnO
        '
        Me.btnO.Location = New System.Drawing.Point(508, 279)
        Me.btnO.Name = "btnO"
        Me.btnO.Size = New System.Drawing.Size(42, 43)
        Me.btnO.TabIndex = 17
        Me.btnO.Text = "O"
        Me.btnO.UseVisualStyleBackColor = True
        '
        'picBalloon3
        '
        Me.picBalloon3.Image = Global.School_Work_14___Balloon_Race.My.Resources.Resources.Balloon_3
        Me.picBalloon3.Location = New System.Drawing.Point(23, 193)
        Me.picBalloon3.Name = "picBalloon3"
        Me.picBalloon3.Size = New System.Drawing.Size(50, 50)
        Me.picBalloon3.TabIndex = 21
        Me.picBalloon3.TabStop = False
        '
        'picBalloon2
        '
        Me.picBalloon2.Image = Global.School_Work_14___Balloon_Race.My.Resources.Resources.Balloon_2
        Me.picBalloon2.Location = New System.Drawing.Point(23, 137)
        Me.picBalloon2.Name = "picBalloon2"
        Me.picBalloon2.Size = New System.Drawing.Size(50, 50)
        Me.picBalloon2.TabIndex = 8
        Me.picBalloon2.TabStop = False
        '
        'picBalloon1
        '
        Me.picBalloon1.Image = Global.School_Work_14___Balloon_Race.My.Resources.Resources.Balloon_1
        Me.picBalloon1.Location = New System.Drawing.Point(23, 81)
        Me.picBalloon1.Name = "picBalloon1"
        Me.picBalloon1.Size = New System.Drawing.Size(50, 50)
        Me.picBalloon1.TabIndex = 7
        Me.picBalloon1.TabStop = False
        '
        'tmrGameTime
        '
        Me.tmrGameTime.Enabled = True
        '
        'frmBalloonRace
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(610, 331)
        Me.Controls.Add(Me.picBalloon3)
        Me.Controls.Add(Me.lblScore3)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.btnP)
        Me.Controls.Add(Me.btnO)
        Me.Controls.Add(Me.lblScore2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.btnB)
        Me.Controls.Add(Me.btnV)
        Me.Controls.Add(Me.lblScore1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.picBalloon2)
        Me.Controls.Add(Me.picBalloon1)
        Me.Controls.Add(Me.btnW)
        Me.Controls.Add(Me.btnQ)
        Me.Controls.Add(Me.pnlFinish)
        Me.Controls.Add(Me.Label)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmBalloonRace"
        Me.Text = "Balloon Race"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.picBalloon3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picBalloon2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picBalloon1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuStart As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuQuit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pnlFinish As System.Windows.Forms.Panel
    Friend WithEvents btnW As System.Windows.Forms.Button
    Friend WithEvents btnQ As System.Windows.Forms.Button
    Friend WithEvents mnuPause As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents picBalloon1 As System.Windows.Forms.PictureBox
    Friend WithEvents picBalloon2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblScore1 As System.Windows.Forms.Label
    Friend WithEvents lblScore2 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnB As System.Windows.Forms.Button
    Friend WithEvents btnV As System.Windows.Forms.Button
    Friend WithEvents lblScore3 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnP As System.Windows.Forms.Button
    Friend WithEvents btnO As System.Windows.Forms.Button
    Friend WithEvents picBalloon3 As System.Windows.Forms.PictureBox
    Friend WithEvents tmrGameTime As System.Windows.Forms.Timer

End Class
