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
        Me.components = New System.ComponentModel.Container()
        Me.bBlue = New System.Windows.Forms.Button()
        Me.bRainbow = New System.Windows.Forms.Button()
        Me.bYellow = New System.Windows.Forms.Button()
        Me.bGreen = New System.Windows.Forms.Button()
        Me.bRed = New System.Windows.Forms.Button()
        Me.bPurple = New System.Windows.Forms.Button()
        Me.timer = New System.Windows.Forms.Timer(Me.components)
        Me.lblColour = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'bBlue
        '
        Me.bBlue.Location = New System.Drawing.Point(12, 216)
        Me.bBlue.Name = "bBlue"
        Me.bBlue.Size = New System.Drawing.Size(106, 33)
        Me.bBlue.TabIndex = 0
        Me.bBlue.Text = "Blue"
        Me.bBlue.UseVisualStyleBackColor = True
        '
        'bRainbow
        '
        Me.bRainbow.Location = New System.Drawing.Point(12, 177)
        Me.bRainbow.Name = "bRainbow"
        Me.bRainbow.Size = New System.Drawing.Size(106, 33)
        Me.bRainbow.TabIndex = 1
        Me.bRainbow.Text = "RAINBOWS!"
        Me.bRainbow.UseVisualStyleBackColor = True
        '
        'bYellow
        '
        Me.bYellow.Location = New System.Drawing.Point(236, 216)
        Me.bYellow.Name = "bYellow"
        Me.bYellow.Size = New System.Drawing.Size(106, 33)
        Me.bYellow.TabIndex = 3
        Me.bYellow.Text = "Yellow"
        Me.bYellow.UseVisualStyleBackColor = True
        '
        'bGreen
        '
        Me.bGreen.Location = New System.Drawing.Point(236, 177)
        Me.bGreen.Name = "bGreen"
        Me.bGreen.Size = New System.Drawing.Size(106, 33)
        Me.bGreen.TabIndex = 4
        Me.bGreen.Text = "Green"
        Me.bGreen.UseVisualStyleBackColor = True
        '
        'bRed
        '
        Me.bRed.Location = New System.Drawing.Point(124, 177)
        Me.bRed.Name = "bRed"
        Me.bRed.Size = New System.Drawing.Size(106, 33)
        Me.bRed.TabIndex = 5
        Me.bRed.Text = "Red"
        Me.bRed.UseVisualStyleBackColor = True
        '
        'bPurple
        '
        Me.bPurple.Location = New System.Drawing.Point(124, 216)
        Me.bPurple.Name = "bPurple"
        Me.bPurple.Size = New System.Drawing.Size(106, 33)
        Me.bPurple.TabIndex = 6
        Me.bPurple.Text = "Purple"
        Me.bPurple.UseVisualStyleBackColor = True
        '
        'timer
        '
        Me.timer.Enabled = True
        Me.timer.Interval = 1
        '
        'lblColour
        '
        Me.lblColour.AutoSize = True
        Me.lblColour.Font = New System.Drawing.Font("Microsoft Sans Serif", 60.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColour.Location = New System.Drawing.Point(12, 9)
        Me.lblColour.Name = "lblColour"
        Me.lblColour.Size = New System.Drawing.Size(574, 91)
        Me.lblColour.TabIndex = 7
        Me.lblColour.Text = "COLOURS!!!!!!"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(608, 261)
        Me.Controls.Add(Me.lblColour)
        Me.Controls.Add(Me.bPurple)
        Me.Controls.Add(Me.bRed)
        Me.Controls.Add(Me.bGreen)
        Me.Controls.Add(Me.bYellow)
        Me.Controls.Add(Me.bRainbow)
        Me.Controls.Add(Me.bBlue)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents bBlue As System.Windows.Forms.Button
    Friend WithEvents bRainbow As System.Windows.Forms.Button
    Friend WithEvents bYellow As System.Windows.Forms.Button
    Friend WithEvents bGreen As System.Windows.Forms.Button
    Friend WithEvents bRed As System.Windows.Forms.Button
    Friend WithEvents bPurple As System.Windows.Forms.Button
    Friend WithEvents timer As System.Windows.Forms.Timer
    Friend WithEvents lblColour As System.Windows.Forms.Label

End Class
