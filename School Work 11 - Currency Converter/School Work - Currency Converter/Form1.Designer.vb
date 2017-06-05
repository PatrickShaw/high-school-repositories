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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbEuros = New System.Windows.Forms.RadioButton()
        Me.rbUKPounds = New System.Windows.Forms.RadioButton()
        Me.rbUSDollars = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.label = New System.Windows.Forms.Label()
        Me.txtInput = New System.Windows.Forms.TextBox()
        Me.btnQuit = New System.Windows.Forms.Button()
        Me.lblOutput = New System.Windows.Forms.Label()
        Me.lblCovertedCurrency = New System.Windows.Forms.Label()
        Me.btnConvert = New System.Windows.Forms.Button()
        Me.txtInputReverse = New System.Windows.Forms.TextBox()
        Me.lblEReverseCurrency = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblOutputAUS = New System.Windows.Forms.Label()
        Me.lblOutputConverted = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtEditCurrency = New System.Windows.Forms.TextBox()
        Me.btnApply = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbEuros)
        Me.GroupBox1.Controls.Add(Me.rbUKPounds)
        Me.GroupBox1.Controls.Add(Me.rbUSDollars)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 56)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(264, 100)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Currency Type"
        '
        'rbEuros
        '
        Me.rbEuros.AutoSize = True
        Me.rbEuros.Location = New System.Drawing.Point(7, 66)
        Me.rbEuros.Name = "rbEuros"
        Me.rbEuros.Size = New System.Drawing.Size(96, 17)
        Me.rbEuros.TabIndex = 2
        Me.rbEuros.TabStop = True
        Me.rbEuros.Text = "European Euro"
        Me.rbEuros.UseVisualStyleBackColor = True
        '
        'rbUKPounds
        '
        Me.rbUKPounds.AutoSize = True
        Me.rbUKPounds.Location = New System.Drawing.Point(7, 43)
        Me.rbUKPounds.Name = "rbUKPounds"
        Me.rbUKPounds.Size = New System.Drawing.Size(79, 17)
        Me.rbUKPounds.TabIndex = 1
        Me.rbUKPounds.TabStop = True
        Me.rbUKPounds.Text = "UK Pounds"
        Me.rbUKPounds.UseVisualStyleBackColor = True
        '
        'rbUSDollars
        '
        Me.rbUSDollars.AutoSize = True
        Me.rbUSDollars.Location = New System.Drawing.Point(7, 20)
        Me.rbUSDollars.Name = "rbUSDollars"
        Me.rbUSDollars.Size = New System.Drawing.Size(75, 17)
        Me.rbUSDollars.TabIndex = 0
        Me.rbUSDollars.TabStop = True
        Me.rbUSDollars.Text = "US Dollars"
        Me.rbUSDollars.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(125, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(270, 31)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Currency Converter"
        '
        'label
        '
        Me.label.AutoSize = True
        Me.label.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label.Location = New System.Drawing.Point(12, 159)
        Me.label.Name = "label"
        Me.label.Size = New System.Drawing.Size(70, 15)
        Me.label.TabIndex = 2
        Me.label.Text = "Enter $AUS"
        '
        'txtInput
        '
        Me.txtInput.Location = New System.Drawing.Point(15, 177)
        Me.txtInput.Name = "txtInput"
        Me.txtInput.Size = New System.Drawing.Size(86, 20)
        Me.txtInput.TabIndex = 3
        Me.txtInput.Text = "1"
        '
        'btnQuit
        '
        Me.btnQuit.Location = New System.Drawing.Point(417, 217)
        Me.btnQuit.Name = "btnQuit"
        Me.btnQuit.Size = New System.Drawing.Size(75, 23)
        Me.btnQuit.TabIndex = 5
        Me.btnQuit.Text = "Quit"
        Me.btnQuit.UseVisualStyleBackColor = True
        '
        'lblOutput
        '
        Me.lblOutput.AutoSize = True
        Me.lblOutput.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOutput.Location = New System.Drawing.Point(107, 181)
        Me.lblOutput.Name = "lblOutput"
        Me.lblOutput.Size = New System.Drawing.Size(43, 15)
        Me.lblOutput.TabIndex = 6
        Me.lblOutput.Text = "Output"
        '
        'lblCovertedCurrency
        '
        Me.lblCovertedCurrency.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCovertedCurrency.Location = New System.Drawing.Point(107, 159)
        Me.lblCovertedCurrency.Name = "lblCovertedCurrency"
        Me.lblCovertedCurrency.Size = New System.Drawing.Size(140, 37)
        Me.lblCovertedCurrency.TabIndex = 7
        Me.lblCovertedCurrency.Text = "Coverted to $US"
        '
        'btnConvert
        '
        Me.btnConvert.Location = New System.Drawing.Point(12, 217)
        Me.btnConvert.Name = "btnConvert"
        Me.btnConvert.Size = New System.Drawing.Size(75, 23)
        Me.btnConvert.TabIndex = 8
        Me.btnConvert.Text = "Clear"
        Me.btnConvert.UseVisualStyleBackColor = True
        '
        'txtInputReverse
        '
        Me.txtInputReverse.Location = New System.Drawing.Point(232, 181)
        Me.txtInputReverse.Name = "txtInputReverse"
        Me.txtInputReverse.Size = New System.Drawing.Size(85, 20)
        Me.txtInputReverse.TabIndex = 10
        Me.txtInputReverse.Text = "1"
        '
        'lblEReverseCurrency
        '
        Me.lblEReverseCurrency.AutoSize = True
        Me.lblEReverseCurrency.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEReverseCurrency.Location = New System.Drawing.Point(229, 159)
        Me.lblEReverseCurrency.Name = "lblEReverseCurrency"
        Me.lblEReverseCurrency.Size = New System.Drawing.Size(63, 15)
        Me.lblEReverseCurrency.TabIndex = 9
        Me.lblEReverseCurrency.Text = "Enter $US"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(323, 159)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(109, 15)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Converted to $AUS"
        '
        'lblOutputAUS
        '
        Me.lblOutputAUS.AutoSize = True
        Me.lblOutputAUS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOutputAUS.Location = New System.Drawing.Point(323, 186)
        Me.lblOutputAUS.Name = "lblOutputAUS"
        Me.lblOutputAUS.Size = New System.Drawing.Size(0, 15)
        Me.lblOutputAUS.TabIndex = 12
        '
        'lblOutputConverted
        '
        Me.lblOutputConverted.AutoSize = True
        Me.lblOutputConverted.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOutputConverted.Location = New System.Drawing.Point(107, 181)
        Me.lblOutputConverted.Name = "lblOutputConverted"
        Me.lblOutputConverted.Size = New System.Drawing.Size(0, 15)
        Me.lblOutputConverted.TabIndex = 13
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(285, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(140, 14)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Edit Currency Rate"
        '
        'txtEditCurrency
        '
        Me.txtEditCurrency.Location = New System.Drawing.Point(285, 73)
        Me.txtEditCurrency.Name = "txtEditCurrency"
        Me.txtEditCurrency.Size = New System.Drawing.Size(126, 20)
        Me.txtEditCurrency.TabIndex = 15
        '
        'btnApply
        '
        Me.btnApply.Location = New System.Drawing.Point(417, 70)
        Me.btnApply.Name = "btnApply"
        Me.btnApply.Size = New System.Drawing.Size(75, 23)
        Me.btnApply.TabIndex = 16
        Me.btnApply.Text = "Apply"
        Me.btnApply.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(504, 252)
        Me.Controls.Add(Me.btnApply)
        Me.Controls.Add(Me.txtEditCurrency)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblOutputConverted)
        Me.Controls.Add(Me.lblOutputAUS)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtInputReverse)
        Me.Controls.Add(Me.lblEReverseCurrency)
        Me.Controls.Add(Me.btnConvert)
        Me.Controls.Add(Me.lblCovertedCurrency)
        Me.Controls.Add(Me.lblOutput)
        Me.Controls.Add(Me.btnQuit)
        Me.Controls.Add(Me.txtInput)
        Me.Controls.Add(Me.label)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Form1"
        Me.Text = "Currency Converter"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbEuros As System.Windows.Forms.RadioButton
    Friend WithEvents rbUKPounds As System.Windows.Forms.RadioButton
    Friend WithEvents rbUSDollars As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents label As System.Windows.Forms.Label
    Friend WithEvents txtInput As System.Windows.Forms.TextBox
    Friend WithEvents btnQuit As System.Windows.Forms.Button
    Friend WithEvents lblOutput As System.Windows.Forms.Label
    Friend WithEvents lblCovertedCurrency As System.Windows.Forms.Label
    Friend WithEvents btnConvert As System.Windows.Forms.Button
    Friend WithEvents txtInputReverse As System.Windows.Forms.TextBox
    Friend WithEvents lblEReverseCurrency As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblOutputAUS As System.Windows.Forms.Label
    Friend WithEvents lblOutputConverted As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtEditCurrency As System.Windows.Forms.TextBox
    Friend WithEvents btnApply As System.Windows.Forms.Button

End Class
