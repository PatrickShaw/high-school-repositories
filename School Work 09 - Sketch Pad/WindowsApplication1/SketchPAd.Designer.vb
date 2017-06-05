<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSketchPad
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.picSketchPad = New System.Windows.Forms.PictureBox()
        Me.picColourPreview = New System.Windows.Forms.PictureBox()
        Me.txtRed = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.hScrollRed = New System.Windows.Forms.HScrollBar()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.hScrollBlue = New System.Windows.Forms.HScrollBar()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtBlue = New System.Windows.Forms.TextBox()
        Me.hScrollGreen = New System.Windows.Forms.HScrollBar()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtGreen = New System.Windows.Forms.TextBox()
        Me.btnQuit = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.hScrollWidth = New System.Windows.Forms.HScrollBar()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtWidth = New System.Windows.Forms.TextBox()
        Me.picLinePreview = New System.Windows.Forms.PictureBox()
        Me.btnFillBackground = New System.Windows.Forms.Button()
        Me.hScrollAlpha = New System.Windows.Forms.HScrollBar()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtAlpha = New System.Windows.Forms.TextBox()
        CType(Me.picSketchPad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picColourPreview, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picLinePreview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(440, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(190, 37)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Sketch Pad"
        '
        'picSketchPad
        '
        Me.picSketchPad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picSketchPad.Location = New System.Drawing.Point(13, 12)
        Me.picSketchPad.Name = "picSketchPad"
        Me.picSketchPad.Size = New System.Drawing.Size(392, 375)
        Me.picSketchPad.TabIndex = 1
        Me.picSketchPad.TabStop = False
        '
        'picColourPreview
        '
        Me.picColourPreview.Location = New System.Drawing.Point(415, 91)
        Me.picColourPreview.Name = "picColourPreview"
        Me.picColourPreview.Size = New System.Drawing.Size(114, 79)
        Me.picColourPreview.TabIndex = 2
        Me.picColourPreview.TabStop = False
        '
        'txtRed
        '
        Me.txtRed.Location = New System.Drawing.Point(475, 175)
        Me.txtRed.Name = "txtRed"
        Me.txtRed.Size = New System.Drawing.Size(54, 20)
        Me.txtRed.TabIndex = 3
        Me.txtRed.Text = "0"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(412, 175)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 17)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Red"
        '
        'hScrollRed
        '
        Me.hScrollRed.Location = New System.Drawing.Point(416, 198)
        Me.hScrollRed.Maximum = 270
        Me.hScrollRed.Name = "hScrollRed"
        Me.hScrollRed.Size = New System.Drawing.Size(113, 20)
        Me.hScrollRed.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(411, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 20)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Colour"
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(414, 399)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(114, 34)
        Me.btnClear.TabIndex = 7
        Me.btnClear.Text = "Clear All"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'hScrollBlue
        '
        Me.hScrollBlue.Location = New System.Drawing.Point(417, 293)
        Me.hScrollBlue.Maximum = 270
        Me.hScrollBlue.Name = "hScrollBlue"
        Me.hScrollBlue.Size = New System.Drawing.Size(113, 20)
        Me.hScrollBlue.TabIndex = 12
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(413, 270)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 17)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Blue"
        '
        'txtBlue
        '
        Me.txtBlue.Location = New System.Drawing.Point(476, 270)
        Me.txtBlue.Name = "txtBlue"
        Me.txtBlue.Size = New System.Drawing.Size(54, 20)
        Me.txtBlue.TabIndex = 10
        Me.txtBlue.Text = "0"
        '
        'hScrollGreen
        '
        Me.hScrollGreen.Location = New System.Drawing.Point(416, 247)
        Me.hScrollGreen.Maximum = 270
        Me.hScrollGreen.Name = "hScrollGreen"
        Me.hScrollGreen.Size = New System.Drawing.Size(113, 20)
        Me.hScrollGreen.TabIndex = 15
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(412, 224)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 17)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Green"
        '
        'txtGreen
        '
        Me.txtGreen.Location = New System.Drawing.Point(475, 224)
        Me.txtGreen.Name = "txtGreen"
        Me.txtGreen.Size = New System.Drawing.Size(54, 20)
        Me.txtGreen.TabIndex = 13
        Me.txtGreen.Text = "0"
        '
        'btnQuit
        '
        Me.btnQuit.Location = New System.Drawing.Point(543, 399)
        Me.btnQuit.Name = "btnQuit"
        Me.btnQuit.Size = New System.Drawing.Size(114, 34)
        Me.btnQuit.TabIndex = 16
        Me.btnQuit.Text = "Quit"
        Me.btnQuit.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(413, 71)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(64, 17)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "Preview"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(540, 71)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 17)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "Preview"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(538, 48)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(88, 20)
        Me.Label8.TabIndex = 23
        Me.Label8.Text = "Line Style"
        '
        'hScrollWidth
        '
        Me.hScrollWidth.Location = New System.Drawing.Point(543, 198)
        Me.hScrollWidth.Maximum = 300
        Me.hScrollWidth.Minimum = 1
        Me.hScrollWidth.Name = "hScrollWidth"
        Me.hScrollWidth.Size = New System.Drawing.Size(113, 20)
        Me.hScrollWidth.TabIndex = 22
        Me.hScrollWidth.Value = 1
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(539, 175)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(49, 17)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "Width"
        '
        'txtWidth
        '
        Me.txtWidth.Location = New System.Drawing.Point(602, 175)
        Me.txtWidth.Name = "txtWidth"
        Me.txtWidth.Size = New System.Drawing.Size(54, 20)
        Me.txtWidth.TabIndex = 20
        Me.txtWidth.Text = "1"
        '
        'picLinePreview
        '
        Me.picLinePreview.Location = New System.Drawing.Point(542, 91)
        Me.picLinePreview.Name = "picLinePreview"
        Me.picLinePreview.Size = New System.Drawing.Size(114, 79)
        Me.picLinePreview.TabIndex = 19
        Me.picLinePreview.TabStop = False
        '
        'btnFillBackground
        '
        Me.btnFillBackground.Location = New System.Drawing.Point(416, 359)
        Me.btnFillBackground.Name = "btnFillBackground"
        Me.btnFillBackground.Size = New System.Drawing.Size(114, 34)
        Me.btnFillBackground.TabIndex = 25
        Me.btnFillBackground.Text = "Set Background"
        Me.btnFillBackground.UseVisualStyleBackColor = True
        '
        'hScrollAlpha
        '
        Me.hScrollAlpha.Location = New System.Drawing.Point(417, 336)
        Me.hScrollAlpha.Maximum = 270
        Me.hScrollAlpha.Name = "hScrollAlpha"
        Me.hScrollAlpha.Size = New System.Drawing.Size(113, 20)
        Me.hScrollAlpha.TabIndex = 30
        Me.hScrollAlpha.Value = 255
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(413, 313)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(49, 17)
        Me.Label10.TabIndex = 29
        Me.Label10.Text = "Alpha"
        '
        'txtAlpha
        '
        Me.txtAlpha.Location = New System.Drawing.Point(476, 313)
        Me.txtAlpha.Name = "txtAlpha"
        Me.txtAlpha.Size = New System.Drawing.Size(54, 20)
        Me.txtAlpha.TabIndex = 28
        Me.txtAlpha.Text = "255"
        '
        'frmSketchPad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(665, 444)
        Me.Controls.Add(Me.hScrollAlpha)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtAlpha)
        Me.Controls.Add(Me.btnFillBackground)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.hScrollWidth)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtWidth)
        Me.Controls.Add(Me.picLinePreview)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.btnQuit)
        Me.Controls.Add(Me.hScrollGreen)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtGreen)
        Me.Controls.Add(Me.hScrollBlue)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtBlue)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.hScrollRed)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtRed)
        Me.Controls.Add(Me.picColourPreview)
        Me.Controls.Add(Me.picSketchPad)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmSketchPad"
        Me.Text = "Sketch Pad"
        CType(Me.picSketchPad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picColourPreview, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picLinePreview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents picSketchPad As System.Windows.Forms.PictureBox
    Friend WithEvents picColourPreview As System.Windows.Forms.PictureBox
    Friend WithEvents txtRed As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents hScrollRed As System.Windows.Forms.HScrollBar
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents hScrollBlue As System.Windows.Forms.HScrollBar
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtBlue As System.Windows.Forms.TextBox
    Friend WithEvents hScrollGreen As System.Windows.Forms.HScrollBar
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtGreen As System.Windows.Forms.TextBox
    Friend WithEvents btnQuit As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents hScrollWidth As System.Windows.Forms.HScrollBar
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtWidth As System.Windows.Forms.TextBox
    Friend WithEvents picLinePreview As System.Windows.Forms.PictureBox
    Friend WithEvents btnFillBackground As System.Windows.Forms.Button
    Friend WithEvents hScrollAlpha As System.Windows.Forms.HScrollBar
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtAlpha As System.Windows.Forms.TextBox

End Class
