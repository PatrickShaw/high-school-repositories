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
        Me.btnClearAll = New System.Windows.Forms.Button()
        Me.btnQuit = New System.Windows.Forms.Button()
        Me.lstPattern01 = New System.Windows.Forms.ListBox()
        Me.lstPattern02 = New System.Windows.Forms.ListBox()
        Me.btnGo01 = New System.Windows.Forms.Button()
        Me.btnGo02 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblStarCount01 = New System.Windows.Forms.Label()
        Me.lblStarCount02 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnClearAll
        '
        Me.btnClearAll.Location = New System.Drawing.Point(401, 13)
        Me.btnClearAll.Name = "btnClearAll"
        Me.btnClearAll.Size = New System.Drawing.Size(75, 23)
        Me.btnClearAll.TabIndex = 0
        Me.btnClearAll.Text = "Clear All"
        Me.btnClearAll.UseVisualStyleBackColor = True
        '
        'btnQuit
        '
        Me.btnQuit.Location = New System.Drawing.Point(484, 12)
        Me.btnQuit.Name = "btnQuit"
        Me.btnQuit.Size = New System.Drawing.Size(75, 23)
        Me.btnQuit.TabIndex = 1
        Me.btnQuit.Text = "Quit"
        Me.btnQuit.UseVisualStyleBackColor = True
        '
        'lstPattern01
        '
        Me.lstPattern01.FormattingEnabled = True
        Me.lstPattern01.Location = New System.Drawing.Point(21, 60)
        Me.lstPattern01.Name = "lstPattern01"
        Me.lstPattern01.Size = New System.Drawing.Size(256, 173)
        Me.lstPattern01.TabIndex = 2
        '
        'lstPattern02
        '
        Me.lstPattern02.FormattingEnabled = True
        Me.lstPattern02.Location = New System.Drawing.Point(283, 60)
        Me.lstPattern02.Name = "lstPattern02"
        Me.lstPattern02.Size = New System.Drawing.Size(256, 173)
        Me.lstPattern02.TabIndex = 3
        '
        'btnGo01
        '
        Me.btnGo01.Location = New System.Drawing.Point(21, 239)
        Me.btnGo01.Name = "btnGo01"
        Me.btnGo01.Size = New System.Drawing.Size(256, 40)
        Me.btnGo01.TabIndex = 4
        Me.btnGo01.Text = "Go"
        Me.btnGo01.UseVisualStyleBackColor = True
        '
        'btnGo02
        '
        Me.btnGo02.Location = New System.Drawing.Point(283, 239)
        Me.btnGo02.Name = "btnGo02"
        Me.btnGo02.Size = New System.Drawing.Size(256, 40)
        Me.btnGo02.TabIndex = 5
        Me.btnGo02.Text = "Go"
        Me.btnGo02.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(58, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(290, 37)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Pattern Generator"
        '
        'lblStarCount01
        '
        Me.lblStarCount01.AutoSize = True
        Me.lblStarCount01.Location = New System.Drawing.Point(21, 286)
        Me.lblStarCount01.Name = "lblStarCount01"
        Me.lblStarCount01.Size = New System.Drawing.Size(63, 13)
        Me.lblStarCount01.TabIndex = 7
        Me.lblStarCount01.Text = "Star Count: "
        '
        'lblStarCount02
        '
        Me.lblStarCount02.AutoSize = True
        Me.lblStarCount02.Location = New System.Drawing.Point(280, 286)
        Me.lblStarCount02.Name = "lblStarCount02"
        Me.lblStarCount02.Size = New System.Drawing.Size(63, 13)
        Me.lblStarCount02.TabIndex = 8
        Me.lblStarCount02.Text = "Star Count: "
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(571, 310)
        Me.Controls.Add(Me.lblStarCount02)
        Me.Controls.Add(Me.lblStarCount01)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnGo02)
        Me.Controls.Add(Me.btnGo01)
        Me.Controls.Add(Me.lstPattern02)
        Me.Controls.Add(Me.lstPattern01)
        Me.Controls.Add(Me.btnQuit)
        Me.Controls.Add(Me.btnClearAll)
        Me.Name = "Form1"
        Me.Text = "Pattern Generator"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnClearAll As System.Windows.Forms.Button
    Friend WithEvents btnQuit As System.Windows.Forms.Button
    Friend WithEvents lstPattern01 As System.Windows.Forms.ListBox
    Friend WithEvents lstPattern02 As System.Windows.Forms.ListBox
    Friend WithEvents btnGo01 As System.Windows.Forms.Button
    Friend WithEvents btnGo02 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblStarCount01 As System.Windows.Forms.Label
    Friend WithEvents lblStarCount02 As System.Windows.Forms.Label

End Class
