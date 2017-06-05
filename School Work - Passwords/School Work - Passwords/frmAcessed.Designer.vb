<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAcessed
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAcessed))
        Me.btnBack = New System.Windows.Forms.Button()
        Me.picDisplay = New System.Windows.Forms.PictureBox()
        CType(Me.picDisplay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnBack
        '
        Me.btnBack.Location = New System.Drawing.Point(13, 226)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(259, 23)
        Me.btnBack.TabIndex = 0
        Me.btnBack.Text = "Back"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'picDisplay
        '
        Me.picDisplay.Image = CType(resources.GetObject("picDisplay.Image"), System.Drawing.Image)
        Me.picDisplay.InitialImage = CType(resources.GetObject("picDisplay.InitialImage"), System.Drawing.Image)
        Me.picDisplay.Location = New System.Drawing.Point(13, 13)
        Me.picDisplay.Name = "picDisplay"
        Me.picDisplay.Size = New System.Drawing.Size(259, 207)
        Me.picDisplay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picDisplay.TabIndex = 1
        Me.picDisplay.TabStop = False
        '
        'frmAcessed
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.picDisplay)
        Me.Controls.Add(Me.btnBack)
        Me.Name = "frmAcessed"
        Me.Text = "The Secret Picture"
        CType(Me.picDisplay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnBack As System.Windows.Forms.Button
    Friend WithEvents picDisplay As System.Windows.Forms.PictureBox
End Class
