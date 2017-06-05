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
        Me.bLoadImage = New System.Windows.Forms.Button()
        Me.picDisplay = New System.Windows.Forms.PictureBox()
        Me.txtPath = New System.Windows.Forms.TextBox()
        Me.hsZooom = New System.Windows.Forms.HScrollBar()
        Me.dlgOpenFile = New System.Windows.Forms.OpenFileDialog()
        Me.vsZoom = New System.Windows.Forms.VScrollBar()
        CType(Me.picDisplay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'bLoadImage
        '
        Me.bLoadImage.Location = New System.Drawing.Point(490, 433)
        Me.bLoadImage.Name = "bLoadImage"
        Me.bLoadImage.Size = New System.Drawing.Size(79, 22)
        Me.bLoadImage.TabIndex = 2
        Me.bLoadImage.Text = "Load Image"
        Me.bLoadImage.UseVisualStyleBackColor = True
        '
        'picDisplay
        '
        Me.picDisplay.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picDisplay.Location = New System.Drawing.Point(32, 12)
        Me.picDisplay.Name = "picDisplay"
        Me.picDisplay.Size = New System.Drawing.Size(537, 399)
        Me.picDisplay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picDisplay.TabIndex = 3
        Me.picDisplay.TabStop = False
        '
        'txtPath
        '
        Me.txtPath.Location = New System.Drawing.Point(12, 436)
        Me.txtPath.Name = "txtPath"
        Me.txtPath.ReadOnly = True
        Me.txtPath.Size = New System.Drawing.Size(472, 20)
        Me.txtPath.TabIndex = 6
        '
        'hsZooom
        '
        Me.hsZooom.Location = New System.Drawing.Point(13, 414)
        Me.hsZooom.Name = "hsZooom"
        Me.hsZooom.Size = New System.Drawing.Size(556, 16)
        Me.hsZooom.TabIndex = 7
        '
        'dlgOpenFile
        '
        Me.dlgOpenFile.Filter = "files|*.jpg;*.gif,*.bmp,*.png"
        '
        'vsZoom
        '
        Me.vsZoom.Location = New System.Drawing.Point(9, 12)
        Me.vsZoom.Name = "vsZoom"
        Me.vsZoom.Size = New System.Drawing.Size(20, 399)
        Me.vsZoom.TabIndex = 8
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(581, 468)
        Me.Controls.Add(Me.vsZoom)
        Me.Controls.Add(Me.hsZooom)
        Me.Controls.Add(Me.txtPath)
        Me.Controls.Add(Me.picDisplay)
        Me.Controls.Add(Me.bLoadImage)
        Me.Name = "Form1"
        Me.Text = "Image Browser"
        CType(Me.picDisplay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents bLoadImage As System.Windows.Forms.Button
    Friend WithEvents picDisplay As System.Windows.Forms.PictureBox
    Friend WithEvents txtPath As System.Windows.Forms.TextBox
    Friend WithEvents hsZooom As System.Windows.Forms.HScrollBar
    Friend WithEvents dlgOpenFile As System.Windows.Forms.OpenFileDialog
    Friend WithEvents vsZoom As System.Windows.Forms.VScrollBar

End Class
