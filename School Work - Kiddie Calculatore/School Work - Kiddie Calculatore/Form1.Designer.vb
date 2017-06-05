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
        Me.bPlus = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtValue1 = New System.Windows.Forms.TextBox()
        Me.bDivded = New System.Windows.Forms.Button()
        Me.bTimes = New System.Windows.Forms.Button()
        Me.b = New System.Windows.Forms.Button()
        Me.txtValue2 = New System.Windows.Forms.TextBox()
        Me.lblAnswer = New System.Windows.Forms.Label()
        Me.bQuit = New System.Windows.Forms.Button()
        Me.bClear = New System.Windows.Forms.Button()
        Me.bQuestion = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'bPlus
        '
        Me.bPlus.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bPlus.Location = New System.Drawing.Point(138, 39)
        Me.bPlus.Name = "bPlus"
        Me.bPlus.Size = New System.Drawing.Size(48, 39)
        Me.bPlus.TabIndex = 2
        Me.bPlus.Text = "+"
        Me.bPlus.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(133, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(194, 26)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Kiddie Calculator"
        '
        'txtValue1
        '
        Me.txtValue1.Location = New System.Drawing.Point(32, 129)
        Me.txtValue1.Name = "txtValue1"
        Me.txtValue1.Size = New System.Drawing.Size(100, 20)
        Me.txtValue1.TabIndex = 5
        '
        'bDivded
        '
        Me.bDivded.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bDivded.Location = New System.Drawing.Point(138, 174)
        Me.bDivded.Name = "bDivded"
        Me.bDivded.Size = New System.Drawing.Size(48, 39)
        Me.bDivded.TabIndex = 6
        Me.bDivded.Text = "/"
        Me.bDivded.UseVisualStyleBackColor = True
        '
        'bTimes
        '
        Me.bTimes.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bTimes.Location = New System.Drawing.Point(138, 129)
        Me.bTimes.Name = "bTimes"
        Me.bTimes.Size = New System.Drawing.Size(48, 39)
        Me.bTimes.TabIndex = 7
        Me.bTimes.Text = "x"
        Me.bTimes.UseVisualStyleBackColor = True
        '
        'b
        '
        Me.b.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.b.Location = New System.Drawing.Point(138, 84)
        Me.b.Name = "b"
        Me.b.Size = New System.Drawing.Size(48, 39)
        Me.b.TabIndex = 8
        Me.b.Text = "-"
        Me.b.UseVisualStyleBackColor = True
        '
        'txtValue2
        '
        Me.txtValue2.Location = New System.Drawing.Point(192, 129)
        Me.txtValue2.Name = "txtValue2"
        Me.txtValue2.Size = New System.Drawing.Size(100, 20)
        Me.txtValue2.TabIndex = 9
        '
        'lblAnswer
        '
        Me.lblAnswer.AutoSize = True
        Me.lblAnswer.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAnswer.Location = New System.Drawing.Point(298, 123)
        Me.lblAnswer.Name = "lblAnswer"
        Me.lblAnswer.Size = New System.Drawing.Size(104, 26)
        Me.lblAnswer.TabIndex = 10
        Me.lblAnswer.Text = "= Answer"
        '
        'bQuit
        '
        Me.bQuit.Location = New System.Drawing.Point(344, 187)
        Me.bQuit.Name = "bQuit"
        Me.bQuit.Size = New System.Drawing.Size(103, 28)
        Me.bQuit.TabIndex = 12
        Me.bQuit.Text = "Quit"
        Me.bQuit.UseVisualStyleBackColor = True
        '
        'bClear
        '
        Me.bClear.Location = New System.Drawing.Point(344, 152)
        Me.bClear.Name = "bClear"
        Me.bClear.Size = New System.Drawing.Size(103, 28)
        Me.bClear.TabIndex = 13
        Me.bClear.Text = "Clear"
        Me.bClear.UseVisualStyleBackColor = True
        '
        'bQuestion
        '
        Me.bQuestion.Location = New System.Drawing.Point(415, 13)
        Me.bQuestion.Name = "bQuestion"
        Me.bQuestion.Size = New System.Drawing.Size(32, 24)
        Me.bQuestion.TabIndex = 14
        Me.bQuestion.Text = "?"
        Me.bQuestion.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(461, 227)
        Me.Controls.Add(Me.bQuestion)
        Me.Controls.Add(Me.bClear)
        Me.Controls.Add(Me.bQuit)
        Me.Controls.Add(Me.lblAnswer)
        Me.Controls.Add(Me.txtValue2)
        Me.Controls.Add(Me.b)
        Me.Controls.Add(Me.bTimes)
        Me.Controls.Add(Me.bDivded)
        Me.Controls.Add(Me.txtValue1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.bPlus)
        Me.Name = "Form1"
        Me.Text = "Kiddie Calculator"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents bPlus As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtValue1 As System.Windows.Forms.TextBox
    Friend WithEvents bDivded As System.Windows.Forms.Button
    Friend WithEvents bTimes As System.Windows.Forms.Button
    Friend WithEvents b As System.Windows.Forms.Button
    Friend WithEvents txtValue2 As System.Windows.Forms.TextBox
    Friend WithEvents lblAnswer As System.Windows.Forms.Label
    Friend WithEvents bQuit As System.Windows.Forms.Button
    Friend WithEvents bClear As System.Windows.Forms.Button
    Friend WithEvents bQuestion As System.Windows.Forms.Button

End Class
