<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AddCheckScanner
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lblSerialNumber = New System.Windows.Forms.Label()
        Me.txtSerialNumber = New System.Windows.Forms.TextBox()
        Me.txtMESD = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCostCenter = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbCenter = New System.Windows.Forms.ComboBox()
        Me.lblCenter = New System.Windows.Forms.Label()
        Me.lblAssetTag = New System.Windows.Forms.Label()
        Me.txtAssetTag = New System.Windows.Forms.TextBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.cbCondition = New System.Windows.Forms.ComboBox()
        Me.lblCondition = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblSerialNumber
        '
        Me.lblSerialNumber.AutoSize = True
        Me.lblSerialNumber.Location = New System.Drawing.Point(12, 9)
        Me.lblSerialNumber.Name = "lblSerialNumber"
        Me.lblSerialNumber.Size = New System.Drawing.Size(73, 13)
        Me.lblSerialNumber.TabIndex = 68
        Me.lblSerialNumber.Text = "Serial Number"
        '
        'txtSerialNumber
        '
        Me.txtSerialNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSerialNumber.Location = New System.Drawing.Point(15, 28)
        Me.txtSerialNumber.Name = "txtSerialNumber"
        Me.txtSerialNumber.Size = New System.Drawing.Size(151, 26)
        Me.txtSerialNumber.TabIndex = 0
        '
        'txtMESD
        '
        Me.txtMESD.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMESD.Location = New System.Drawing.Point(162, 137)
        Me.txtMESD.Name = "txtMESD"
        Me.txtMESD.Size = New System.Drawing.Size(136, 26)
        Me.txtMESD.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(159, 121)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 66
        Me.Label2.Text = "MESD:"
        '
        'txtCostCenter
        '
        Me.txtCostCenter.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCostCenter.Location = New System.Drawing.Point(15, 137)
        Me.txtCostCenter.Name = "txtCostCenter"
        Me.txtCostCenter.Size = New System.Drawing.Size(114, 26)
        Me.txtCostCenter.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 121)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 65
        Me.Label1.Text = "Cost Center"
        '
        'cbCenter
        '
        Me.cbCenter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbCenter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbCenter.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCenter.FormattingEnabled = True
        Me.cbCenter.Location = New System.Drawing.Point(15, 82)
        Me.cbCenter.Name = "cbCenter"
        Me.cbCenter.Size = New System.Drawing.Size(283, 26)
        Me.cbCenter.TabIndex = 2
        '
        'lblCenter
        '
        Me.lblCenter.AutoSize = True
        Me.lblCenter.Location = New System.Drawing.Point(12, 66)
        Me.lblCenter.Name = "lblCenter"
        Me.lblCenter.Size = New System.Drawing.Size(81, 13)
        Me.lblCenter.TabIndex = 64
        Me.lblCenter.Text = "Center Number:"
        '
        'lblAssetTag
        '
        Me.lblAssetTag.AutoSize = True
        Me.lblAssetTag.Location = New System.Drawing.Point(181, 9)
        Me.lblAssetTag.Name = "lblAssetTag"
        Me.lblAssetTag.Size = New System.Drawing.Size(117, 13)
        Me.lblAssetTag.TabIndex = 63
        Me.lblAssetTag.Text = "Asset Tag (ex: 123456)"
        '
        'txtAssetTag
        '
        Me.txtAssetTag.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAssetTag.Location = New System.Drawing.Point(184, 28)
        Me.txtAssetTag.Name = "txtAssetTag"
        Me.txtAssetTag.Size = New System.Drawing.Size(114, 26)
        Me.txtAssetTag.TabIndex = 1
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(15, 213)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(283, 38)
        Me.btnAdd.TabIndex = 6
        Me.btnAdd.Text = "Add Check Scanner"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'cbCondition
        '
        Me.cbCondition.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbCondition.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbCondition.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCondition.FormattingEnabled = True
        Me.cbCondition.Location = New System.Drawing.Point(90, 179)
        Me.cbCondition.Name = "cbCondition"
        Me.cbCondition.Size = New System.Drawing.Size(111, 28)
        Me.cbCondition.TabIndex = 5
        '
        'lblCondition
        '
        Me.lblCondition.AutoSize = True
        Me.lblCondition.Location = New System.Drawing.Point(12, 187)
        Me.lblCondition.Name = "lblCondition"
        Me.lblCondition.Size = New System.Drawing.Size(72, 13)
        Me.lblCondition.TabIndex = 71
        Me.lblCondition.Text = "New or Used:"
        '
        'AddCheckScanner
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(312, 264)
        Me.Controls.Add(Me.cbCondition)
        Me.Controls.Add(Me.lblCondition)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.lblSerialNumber)
        Me.Controls.Add(Me.txtSerialNumber)
        Me.Controls.Add(Me.txtMESD)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtCostCenter)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbCenter)
        Me.Controls.Add(Me.lblCenter)
        Me.Controls.Add(Me.lblAssetTag)
        Me.Controls.Add(Me.txtAssetTag)
        Me.Name = "AddCheckScanner"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AddCheckScanner"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblSerialNumber As Label
    Friend WithEvents txtSerialNumber As TextBox
    Friend WithEvents txtMESD As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtCostCenter As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cbCenter As ComboBox
    Friend WithEvents lblCenter As Label
    Friend WithEvents lblAssetTag As Label
    Friend WithEvents txtAssetTag As TextBox
    Friend WithEvents btnAdd As Button
    Friend WithEvents cbCondition As ComboBox
    Friend WithEvents lblCondition As Label
End Class
