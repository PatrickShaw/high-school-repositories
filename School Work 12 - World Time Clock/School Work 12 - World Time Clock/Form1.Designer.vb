<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmWorldTimeConvertor
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
        Me.btnQuit = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblLocalTime = New System.Windows.Forms.Label()
        Me.cmbLocation = New System.Windows.Forms.ComboBox()
        Me.cmbDestination = New System.Windows.Forms.ComboBox()
        Me.lblDestTime = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tmrTimer = New System.Windows.Forms.Timer(Me.components)
        Me.lblLocTimeDiff = New System.Windows.Forms.Label()
        Me.lblDestTimeDiff = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnQuit
        '
        Me.btnQuit.Location = New System.Drawing.Point(128, 156)
        Me.btnQuit.Name = "btnQuit"
        Me.btnQuit.Size = New System.Drawing.Size(119, 23)
        Me.btnQuit.TabIndex = 0
        Me.btnQuit.Text = "Quit"
        Me.btnQuit.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(244, 26)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "World Time Convertor"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(11, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 20)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Location"
        '
        'lblLocalTime
        '
        Me.lblLocalTime.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblLocalTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLocalTime.Location = New System.Drawing.Point(15, 60)
        Me.lblLocalTime.Name = "lblLocalTime"
        Me.lblLocalTime.Size = New System.Drawing.Size(99, 45)
        Me.lblLocalTime.TabIndex = 3
        '
        'cmbLocation
        '
        Me.cmbLocation.FormattingEnabled = True
        Me.cmbLocation.Location = New System.Drawing.Point(126, 60)
        Me.cmbLocation.Name = "cmbLocation"
        Me.cmbLocation.Size = New System.Drawing.Size(121, 21)
        Me.cmbLocation.TabIndex = 5
        '
        'cmbDestination
        '
        Me.cmbDestination.FormattingEnabled = True
        Me.cmbDestination.Location = New System.Drawing.Point(128, 129)
        Me.cmbDestination.Name = "cmbDestination"
        Me.cmbDestination.Size = New System.Drawing.Size(121, 21)
        Me.cmbDestination.TabIndex = 8
        '
        'lblDestTime
        '
        Me.lblDestTime.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblDestTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDestTime.Location = New System.Drawing.Point(17, 129)
        Me.lblDestTime.Name = "lblDestTime"
        Me.lblDestTime.Size = New System.Drawing.Size(99, 45)
        Me.lblDestTime.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(13, 109)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(101, 20)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Destination"
        '
        'tmrTimer
        '
        Me.tmrTimer.Enabled = True
        Me.tmrTimer.Interval = 1000
        '
        'lblLocTimeDiff
        '
        Me.lblLocTimeDiff.AutoSize = True
        Me.lblLocTimeDiff.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLocTimeDiff.Location = New System.Drawing.Point(124, 40)
        Me.lblLocTimeDiff.Name = "lblLocTimeDiff"
        Me.lblLocTimeDiff.Size = New System.Drawing.Size(0, 20)
        Me.lblLocTimeDiff.TabIndex = 9
        '
        'lblDestTimeDiff
        '
        Me.lblDestTimeDiff.AutoSize = True
        Me.lblDestTimeDiff.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDestTimeDiff.Location = New System.Drawing.Point(124, 109)
        Me.lblDestTimeDiff.Name = "lblDestTimeDiff"
        Me.lblDestTimeDiff.Size = New System.Drawing.Size(0, 20)
        Me.lblDestTimeDiff.TabIndex = 10
        '
        'frmWorldTimeConvertor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(268, 192)
        Me.Controls.Add(Me.lblDestTimeDiff)
        Me.Controls.Add(Me.lblLocTimeDiff)
        Me.Controls.Add(Me.cmbDestination)
        Me.Controls.Add(Me.lblDestTime)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmbLocation)
        Me.Controls.Add(Me.lblLocalTime)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnQuit)
        Me.Name = "frmWorldTimeConvertor"
        Me.Text = "World Time Convertor"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnQuit As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblLocalTime As System.Windows.Forms.Label
    Friend WithEvents cmbLocation As System.Windows.Forms.ComboBox
    Friend WithEvents cmbDestination As System.Windows.Forms.ComboBox
    Friend WithEvents lblDestTime As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tmrTimer As System.Windows.Forms.Timer
    Friend WithEvents lblLocTimeDiff As System.Windows.Forms.Label
    Friend WithEvents lblDestTimeDiff As System.Windows.Forms.Label

End Class
