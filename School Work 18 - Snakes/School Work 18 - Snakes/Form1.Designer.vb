<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSnake
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
        Me.tmrGame = New System.Windows.Forms.Timer(Me.components)
        Me.btnStart = New System.Windows.Forms.Button()
        Me.lblScore01 = New System.Windows.Forms.Label()
        Me.lblScore02 = New System.Windows.Forms.Label()
        Me.lstScores = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'tmrGame
        '
        Me.tmrGame.Interval = 17
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(12, 544)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(498, 23)
        Me.btnStart.TabIndex = 0
        Me.btnStart.Text = "Start"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'lblScore01
        '
        Me.lblScore01.AutoSize = True
        Me.lblScore01.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblScore01.Location = New System.Drawing.Point(8, 521)
        Me.lblScore01.Name = "lblScore01"
        Me.lblScore01.Size = New System.Drawing.Size(56, 20)
        Me.lblScore01.TabIndex = 1
        Me.lblScore01.Text = "Score"
        '
        'lblScore02
        '
        Me.lblScore02.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblScore02.Location = New System.Drawing.Point(325, 521)
        Me.lblScore02.Name = "lblScore02"
        Me.lblScore02.Size = New System.Drawing.Size(185, 20)
        Me.lblScore02.TabIndex = 2
        Me.lblScore02.Text = "Score"
        Me.lblScore02.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lstScores
        '
        Me.lstScores.FormattingEnabled = True
        Me.lstScores.Location = New System.Drawing.Point(516, 31)
        Me.lstScores.Name = "lstScores"
        Me.lstScores.Size = New System.Drawing.Size(240, 537)
        Me.lstScores.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(512, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(244, 20)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Score"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmSnake
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(768, 579)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lstScores)
        Me.Controls.Add(Me.lblScore02)
        Me.Controls.Add(Me.lblScore01)
        Me.Controls.Add(Me.btnStart)
        Me.Name = "frmSnake"
        Me.Text = "Snake"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tmrGame As System.Windows.Forms.Timer
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents lblScore01 As System.Windows.Forms.Label
    Friend WithEvents lblScore02 As System.Windows.Forms.Label
    Friend WithEvents lstScores As System.Windows.Forms.ListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
