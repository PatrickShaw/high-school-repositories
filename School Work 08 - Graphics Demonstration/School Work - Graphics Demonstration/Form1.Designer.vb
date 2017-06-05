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
        Me.picDisplay = New System.Windows.Forms.PictureBox()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.bLines1 = New System.Windows.Forms.Button()
        Me.bLines2 = New System.Windows.Forms.Button()
        Me.bQuit = New System.Windows.Forms.Button()
        Me.bClear = New System.Windows.Forms.Button()
        Me.bRectangles2 = New System.Windows.Forms.Button()
        Me.bRectangles1 = New System.Windows.Forms.Button()
        Me.bElipses2 = New System.Windows.Forms.Button()
        Me.bElipses1 = New System.Windows.Forms.Button()
        Me.bGoCrazy = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.picDisplay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'picDisplay
        '
        Me.picDisplay.Location = New System.Drawing.Point(13, 13)
        Me.picDisplay.Name = "picDisplay"
        Me.picDisplay.Size = New System.Drawing.Size(449, 404)
        Me.picDisplay.TabIndex = 0
        Me.picDisplay.TabStop = False
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 25.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(468, 13)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(266, 39)
        Me.lblTitle.TabIndex = 1
        Me.lblTitle.Text = "Graphics Demo"
        '
        'bLines1
        '
        Me.bLines1.Location = New System.Drawing.Point(475, 56)
        Me.bLines1.Name = "bLines1"
        Me.bLines1.Size = New System.Drawing.Size(124, 49)
        Me.bLines1.TabIndex = 2
        Me.bLines1.Text = "Lines 1"
        Me.bLines1.UseVisualStyleBackColor = True
        '
        'bLines2
        '
        Me.bLines2.Location = New System.Drawing.Point(606, 56)
        Me.bLines2.Name = "bLines2"
        Me.bLines2.Size = New System.Drawing.Size(139, 49)
        Me.bLines2.TabIndex = 3
        Me.bLines2.Text = "Lines 2"
        Me.bLines2.UseVisualStyleBackColor = True
        '
        'bQuit
        '
        Me.bQuit.Location = New System.Drawing.Point(606, 368)
        Me.bQuit.Name = "bQuit"
        Me.bQuit.Size = New System.Drawing.Size(139, 49)
        Me.bQuit.TabIndex = 5
        Me.bQuit.Text = "Quit"
        Me.bQuit.UseVisualStyleBackColor = True
        '
        'bClear
        '
        Me.bClear.Location = New System.Drawing.Point(475, 368)
        Me.bClear.Name = "bClear"
        Me.bClear.Size = New System.Drawing.Size(124, 49)
        Me.bClear.TabIndex = 4
        Me.bClear.Text = "Clear"
        Me.bClear.UseVisualStyleBackColor = True
        '
        'bRectangles2
        '
        Me.bRectangles2.Location = New System.Drawing.Point(606, 166)
        Me.bRectangles2.Name = "bRectangles2"
        Me.bRectangles2.Size = New System.Drawing.Size(139, 49)
        Me.bRectangles2.TabIndex = 7
        Me.bRectangles2.Text = "Rectangles 2"
        Me.bRectangles2.UseVisualStyleBackColor = True
        '
        'bRectangles1
        '
        Me.bRectangles1.Location = New System.Drawing.Point(475, 166)
        Me.bRectangles1.Name = "bRectangles1"
        Me.bRectangles1.Size = New System.Drawing.Size(124, 49)
        Me.bRectangles1.TabIndex = 6
        Me.bRectangles1.Text = "Rectangles 1"
        Me.bRectangles1.UseVisualStyleBackColor = True
        '
        'bElipses2
        '
        Me.bElipses2.Location = New System.Drawing.Point(606, 111)
        Me.bElipses2.Name = "bElipses2"
        Me.bElipses2.Size = New System.Drawing.Size(139, 49)
        Me.bElipses2.TabIndex = 9
        Me.bElipses2.Text = "Elipses 2"
        Me.bElipses2.UseVisualStyleBackColor = True
        '
        'bElipses1
        '
        Me.bElipses1.Location = New System.Drawing.Point(475, 111)
        Me.bElipses1.Name = "bElipses1"
        Me.bElipses1.Size = New System.Drawing.Size(124, 49)
        Me.bElipses1.TabIndex = 8
        Me.bElipses1.Text = "Elipses 1"
        Me.bElipses1.UseVisualStyleBackColor = True
        '
        'bGoCrazy
        '
        Me.bGoCrazy.Font = New System.Drawing.Font("Microsoft Sans Serif", 40.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bGoCrazy.Location = New System.Drawing.Point(475, 222)
        Me.bGoCrazy.Name = "bGoCrazy"
        Me.bGoCrazy.Size = New System.Drawing.Size(270, 80)
        Me.bGoCrazy.TabIndex = 10
        Me.bGoCrazy.Text = "Go Crazy"
        Me.bGoCrazy.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(475, 313)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(270, 49)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = "Olympic Rings"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(757, 429)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.bGoCrazy)
        Me.Controls.Add(Me.bElipses2)
        Me.Controls.Add(Me.bElipses1)
        Me.Controls.Add(Me.bRectangles2)
        Me.Controls.Add(Me.bRectangles1)
        Me.Controls.Add(Me.bQuit)
        Me.Controls.Add(Me.bClear)
        Me.Controls.Add(Me.bLines2)
        Me.Controls.Add(Me.bLines1)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.picDisplay)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.picDisplay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents picDisplay As System.Windows.Forms.PictureBox
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents bLines1 As System.Windows.Forms.Button
    Friend WithEvents bLines2 As System.Windows.Forms.Button
    Friend WithEvents bQuit As System.Windows.Forms.Button
    Friend WithEvents bClear As System.Windows.Forms.Button
    Friend WithEvents bRectangles2 As System.Windows.Forms.Button
    Friend WithEvents bRectangles1 As System.Windows.Forms.Button
    Friend WithEvents bElipses2 As System.Windows.Forms.Button
    Friend WithEvents bElipses1 As System.Windows.Forms.Button
    Friend WithEvents bGoCrazy As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button

End Class
