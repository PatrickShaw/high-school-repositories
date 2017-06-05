<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSettings
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
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnBrowse1 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtPlayer1Name = New System.Windows.Forms.TextBox()
        Me.txtCharacter1Directory = New System.Windows.Forms.TextBox()
        Me.txtCharacter2Directory = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnBrowse2 = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtPlayer2Name = New System.Windows.Forms.TextBox()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.btnApply = New System.Windows.Forms.Button()
        Me.dlgOpenImage = New System.Windows.Forms.OpenFileDialog()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(15, 80)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(179, 17)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "Character Avatar Image"
        '
        'btnBrowse1
        '
        Me.btnBrowse1.Location = New System.Drawing.Point(404, 98)
        Me.btnBrowse1.Name = "btnBrowse1"
        Me.btnBrowse1.Size = New System.Drawing.Size(67, 23)
        Me.btnBrowse1.TabIndex = 24
        Me.btnBrowse1.Text = "Browse"
        Me.btnBrowse1.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(15, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 17)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 20)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "Player 1"
        '
        'txtPlayer1Name
        '
        Me.txtPlayer1Name.Location = New System.Drawing.Point(18, 57)
        Me.txtPlayer1Name.Name = "txtPlayer1Name"
        Me.txtPlayer1Name.Size = New System.Drawing.Size(274, 20)
        Me.txtPlayer1Name.TabIndex = 21
        Me.txtPlayer1Name.Text = "Player 1"
        '
        'txtCharacter1Directory
        '
        Me.txtCharacter1Directory.Location = New System.Drawing.Point(18, 101)
        Me.txtCharacter1Directory.Name = "txtCharacter1Directory"
        Me.txtCharacter1Directory.ReadOnly = True
        Me.txtCharacter1Directory.Size = New System.Drawing.Size(380, 20)
        Me.txtCharacter1Directory.TabIndex = 26
        '
        'txtCharacter2Directory
        '
        Me.txtCharacter2Directory.Location = New System.Drawing.Point(18, 216)
        Me.txtCharacter2Directory.Name = "txtCharacter2Directory"
        Me.txtCharacter2Directory.ReadOnly = True
        Me.txtCharacter2Directory.Size = New System.Drawing.Size(380, 20)
        Me.txtCharacter2Directory.TabIndex = 32
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(15, 195)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(179, 17)
        Me.Label1.TabIndex = 31
        Me.Label1.Text = "Character Avatar Image"
        '
        'btnBrowse2
        '
        Me.btnBrowse2.Location = New System.Drawing.Point(404, 213)
        Me.btnBrowse2.Name = "btnBrowse2"
        Me.btnBrowse2.Size = New System.Drawing.Size(67, 23)
        Me.btnBrowse2.TabIndex = 30
        Me.btnBrowse2.Text = "Browse"
        Me.btnBrowse2.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(15, 152)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 17)
        Me.Label5.TabIndex = 29
        Me.Label5.Text = "Name"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 124)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(73, 20)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "Player 2"
        '
        'txtPlayer2Name
        '
        Me.txtPlayer2Name.Location = New System.Drawing.Point(18, 172)
        Me.txtPlayer2Name.Name = "txtPlayer2Name"
        Me.txtPlayer2Name.Size = New System.Drawing.Size(274, 20)
        Me.txtPlayer2Name.TabIndex = 27
        Me.txtPlayer2Name.Text = "Player 2"
        '
        'btnBack
        '
        Me.btnBack.Location = New System.Drawing.Point(404, 248)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(67, 23)
        Me.btnBack.TabIndex = 33
        Me.btnBack.Text = "Back"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'btnApply
        '
        Me.btnApply.Location = New System.Drawing.Point(331, 248)
        Me.btnApply.Name = "btnApply"
        Me.btnApply.Size = New System.Drawing.Size(67, 23)
        Me.btnApply.TabIndex = 34
        Me.btnApply.Text = "Apply"
        Me.btnApply.UseVisualStyleBackColor = True
        '
        'dlgOpenImage
        '
        Me.dlgOpenImage.FileName = "dlgOpenImage"
        Me.dlgOpenImage.Filter = "files|*.jpg;*.gif,*.bmp,*.png"
        Me.dlgOpenImage.Title = "Open Image"
        '
        'frmSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(490, 283)
        Me.Controls.Add(Me.btnApply)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.txtCharacter2Directory)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnBrowse2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtPlayer2Name)
        Me.Controls.Add(Me.txtCharacter1Directory)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnBrowse1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtPlayer1Name)
        Me.Name = "frmSettings"
        Me.Text = "Settings"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnBrowse1 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPlayer1Name As System.Windows.Forms.TextBox
    Friend WithEvents txtCharacter1Directory As System.Windows.Forms.TextBox
    Friend WithEvents txtCharacter2Directory As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnBrowse2 As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtPlayer2Name As System.Windows.Forms.TextBox
    Friend WithEvents btnBack As System.Windows.Forms.Button
    Friend WithEvents btnApply As System.Windows.Forms.Button
    Friend WithEvents dlgOpenImage As System.Windows.Forms.OpenFileDialog
End Class
