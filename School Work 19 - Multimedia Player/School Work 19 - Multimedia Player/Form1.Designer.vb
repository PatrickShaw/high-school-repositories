<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.dlgOpenFile = New System.Windows.Forms.OpenFileDialog()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.mnuPlay = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuStop = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPause = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOption = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuQuit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPrevious = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuNext = New System.Windows.Forms.ToolStripMenuItem()
        Me.wmpPlayer = New AxWMPLib.AxWindowsMediaPlayer()
        Me.lstPlaylist = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.txtPath = New System.Windows.Forms.TextBox()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.wmpPlayer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dlgOpenFile
        '
        Me.dlgOpenFile.FileName = "Open Media File"
        Me.dlgOpenFile.Filter = "Audio Files (*.wav, *.mp3, *.mid) | *.wav; *.mp3;*.mid | Video Files (*.avi) | *." & _
    "avi"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuPlay, Me.mnuStop, Me.mnuPause, Me.mnuOption, Me.mnuQuit, Me.mnuPrevious, Me.mnuNext})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(438, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "Menu"
        '
        'mnuPlay
        '
        Me.mnuPlay.Name = "mnuPlay"
        Me.mnuPlay.Size = New System.Drawing.Size(41, 20)
        Me.mnuPlay.Text = "Play"
        '
        'mnuStop
        '
        Me.mnuStop.Name = "mnuStop"
        Me.mnuStop.Size = New System.Drawing.Size(43, 20)
        Me.mnuStop.Text = "Stop"
        '
        'mnuPause
        '
        Me.mnuPause.Name = "mnuPause"
        Me.mnuPause.Size = New System.Drawing.Size(50, 20)
        Me.mnuPause.Text = "Pause"
        '
        'mnuOption
        '
        Me.mnuOption.Name = "mnuOption"
        Me.mnuOption.Size = New System.Drawing.Size(56, 20)
        Me.mnuOption.Text = "Option"
        '
        'mnuQuit
        '
        Me.mnuQuit.Name = "mnuQuit"
        Me.mnuQuit.Size = New System.Drawing.Size(42, 20)
        Me.mnuQuit.Text = "Quit"
        '
        'mnuPrevious
        '
        Me.mnuPrevious.Name = "mnuPrevious"
        Me.mnuPrevious.Size = New System.Drawing.Size(64, 20)
        Me.mnuPrevious.Text = "Previous"
        '
        'mnuNext
        '
        Me.mnuNext.Name = "mnuNext"
        Me.mnuNext.Size = New System.Drawing.Size(43, 20)
        Me.mnuNext.Text = "Next"
        '
        'wmpPlayer
        '
        Me.wmpPlayer.Enabled = True
        Me.wmpPlayer.Location = New System.Drawing.Point(-28, 145)
        Me.wmpPlayer.Name = "wmpPlayer"
        Me.wmpPlayer.OcxState = CType(resources.GetObject("wmpPlayer.OcxState"), System.Windows.Forms.AxHost.State)
        Me.wmpPlayer.Size = New System.Drawing.Size(42, 113)
        Me.wmpPlayer.TabIndex = 1
        '
        'lstPlaylist
        '
        Me.lstPlaylist.FormattingEnabled = True
        Me.lstPlaylist.Location = New System.Drawing.Point(12, 53)
        Me.lstPlaylist.Name = "lstPlaylist"
        Me.lstPlaylist.Size = New System.Drawing.Size(411, 264)
        Me.lstPlaylist.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(411, 23)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Playlist"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(348, 323)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(75, 23)
        Me.btnBrowse.TabIndex = 4
        Me.btnBrowse.Text = "Browse"
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'txtPath
        '
        Me.txtPath.Location = New System.Drawing.Point(12, 323)
        Me.txtPath.Name = "txtPath"
        Me.txtPath.Size = New System.Drawing.Size(330, 20)
        Me.txtPath.TabIndex = 5
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(438, 354)
        Me.Controls.Add(Me.txtPath)
        Me.Controls.Add(Me.btnBrowse)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lstPlaylist)
        Me.Controls.Add(Me.wmpPlayer)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "Multimedia Player"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.wmpPlayer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dlgOpenFile As System.Windows.Forms.OpenFileDialog
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents mnuQuit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents wmpPlayer As AxWMPLib.AxWindowsMediaPlayer
    Friend WithEvents lstPlaylist As System.Windows.Forms.ListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents txtPath As System.Windows.Forms.TextBox
    Friend WithEvents mnuPlay As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuStop As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPause As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuOption As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPrevious As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuNext As System.Windows.Forms.ToolStripMenuItem

End Class
