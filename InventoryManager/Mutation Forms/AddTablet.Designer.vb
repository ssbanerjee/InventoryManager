<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AddTablet
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
        Me.lblAssetTag = New System.Windows.Forms.Label()
        Me.txtAssetTag = New System.Windows.Forms.TextBox()
        Me.cbCenter = New System.Windows.Forms.ComboBox()
        Me.lblCenter = New System.Windows.Forms.Label()
        Me.txtMESD = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCostCenter = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblMachineName = New System.Windows.Forms.Label()
        Me.txtMachineName = New System.Windows.Forms.TextBox()
        Me.lblSerialNumber = New System.Windows.Forms.Label()
        Me.txtSerialNumber = New System.Windows.Forms.TextBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.cbCondition = New System.Windows.Forms.ComboBox()
        Me.lblCondition = New System.Windows.Forms.Label()
        Me.chInventoried = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'lblAssetTag
        '
        Me.lblAssetTag.AutoSize = True
        Me.lblAssetTag.Location = New System.Drawing.Point(12, 66)
        Me.lblAssetTag.Name = "lblAssetTag"
        Me.lblAssetTag.Size = New System.Drawing.Size(117, 13)
        Me.lblAssetTag.TabIndex = 12
        Me.lblAssetTag.Text = "Asset Tag (ex: 123456)"
        '
        'txtAssetTag
        '
        Me.txtAssetTag.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAssetTag.Location = New System.Drawing.Point(15, 85)
        Me.txtAssetTag.Name = "txtAssetTag"
        Me.txtAssetTag.Size = New System.Drawing.Size(117, 26)
        Me.txtAssetTag.TabIndex = 1
        '
        'cbCenter
        '
        Me.cbCenter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbCenter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbCenter.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCenter.FormattingEnabled = True
        Me.cbCenter.Location = New System.Drawing.Point(15, 130)
        Me.cbCenter.Name = "cbCenter"
        Me.cbCenter.Size = New System.Drawing.Size(286, 26)
        Me.cbCenter.TabIndex = 3
        '
        'lblCenter
        '
        Me.lblCenter.AutoSize = True
        Me.lblCenter.Location = New System.Drawing.Point(12, 114)
        Me.lblCenter.Name = "lblCenter"
        Me.lblCenter.Size = New System.Drawing.Size(81, 13)
        Me.lblCenter.TabIndex = 39
        Me.lblCenter.Text = "Center Number:"
        '
        'txtMESD
        '
        Me.txtMESD.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMESD.Location = New System.Drawing.Point(162, 177)
        Me.txtMESD.Name = "txtMESD"
        Me.txtMESD.Size = New System.Drawing.Size(139, 26)
        Me.txtMESD.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(159, 161)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 52
        Me.Label2.Text = "MESD:"
        '
        'txtCostCenter
        '
        Me.txtCostCenter.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCostCenter.Location = New System.Drawing.Point(15, 177)
        Me.txtCostCenter.Name = "txtCostCenter"
        Me.txtCostCenter.Size = New System.Drawing.Size(114, 26)
        Me.txtCostCenter.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 161)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 13)
        Me.Label1.TabIndex = 50
        Me.Label1.Text = "Cost Center / PAR"
        '
        'lblMachineName
        '
        Me.lblMachineName.AutoSize = True
        Me.lblMachineName.Location = New System.Drawing.Point(159, 66)
        Me.lblMachineName.Name = "lblMachineName"
        Me.lblMachineName.Size = New System.Drawing.Size(139, 13)
        Me.lblMachineName.TabIndex = 54
        Me.lblMachineName.Text = "Machine Name (ex: JDoe-L)"
        '
        'txtMachineName
        '
        Me.txtMachineName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMachineName.Location = New System.Drawing.Point(162, 85)
        Me.txtMachineName.Name = "txtMachineName"
        Me.txtMachineName.Size = New System.Drawing.Size(139, 26)
        Me.txtMachineName.TabIndex = 2
        '
        'lblSerialNumber
        '
        Me.lblSerialNumber.AutoSize = True
        Me.lblSerialNumber.Location = New System.Drawing.Point(12, 18)
        Me.lblSerialNumber.Name = "lblSerialNumber"
        Me.lblSerialNumber.Size = New System.Drawing.Size(73, 13)
        Me.lblSerialNumber.TabIndex = 56
        Me.lblSerialNumber.Text = "Serial Number"
        '
        'txtSerialNumber
        '
        Me.txtSerialNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSerialNumber.Location = New System.Drawing.Point(15, 37)
        Me.txtSerialNumber.Name = "txtSerialNumber"
        Me.txtSerialNumber.Size = New System.Drawing.Size(286, 26)
        Me.txtSerialNumber.TabIndex = 0
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(12, 245)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(289, 38)
        Me.btnAdd.TabIndex = 7
        Me.btnAdd.Text = "Add Tablet"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'cbCondition
        '
        Me.cbCondition.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbCondition.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbCondition.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCondition.FormattingEnabled = True
        Me.cbCondition.Location = New System.Drawing.Point(91, 211)
        Me.cbCondition.Name = "cbCondition"
        Me.cbCondition.Size = New System.Drawing.Size(111, 28)
        Me.cbCondition.TabIndex = 6
        '
        'lblCondition
        '
        Me.lblCondition.AutoSize = True
        Me.lblCondition.Location = New System.Drawing.Point(13, 219)
        Me.lblCondition.Name = "lblCondition"
        Me.lblCondition.Size = New System.Drawing.Size(72, 13)
        Me.lblCondition.TabIndex = 58
        Me.lblCondition.Text = "New or Used:"
        '
        'chInventoried
        '
        Me.chInventoried.AutoSize = True
        Me.chInventoried.Checked = True
        Me.chInventoried.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chInventoried.Location = New System.Drawing.Point(208, 215)
        Me.chInventoried.Name = "chInventoried"
        Me.chInventoried.Size = New System.Drawing.Size(82, 17)
        Me.chInventoried.TabIndex = 59
        Me.chInventoried.Text = "In Inventory"
        Me.chInventoried.UseVisualStyleBackColor = True
        '
        'AddTablet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(313, 294)
        Me.Controls.Add(Me.chInventoried)
        Me.Controls.Add(Me.cbCondition)
        Me.Controls.Add(Me.lblCondition)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.lblSerialNumber)
        Me.Controls.Add(Me.txtSerialNumber)
        Me.Controls.Add(Me.lblMachineName)
        Me.Controls.Add(Me.txtMachineName)
        Me.Controls.Add(Me.txtMESD)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtCostCenter)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbCenter)
        Me.Controls.Add(Me.lblCenter)
        Me.Controls.Add(Me.lblAssetTag)
        Me.Controls.Add(Me.txtAssetTag)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "AddTablet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "AddTablet"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblAssetTag As Label
    Friend WithEvents txtAssetTag As TextBox
    Friend WithEvents cbCenter As ComboBox
    Friend WithEvents lblCenter As Label
    Friend WithEvents txtMESD As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtCostCenter As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents lblMachineName As Label
    Friend WithEvents txtMachineName As TextBox
    Friend WithEvents lblSerialNumber As Label
    Friend WithEvents txtSerialNumber As TextBox
    Friend WithEvents btnAdd As Button
    Friend WithEvents cbCondition As ComboBox
    Friend WithEvents lblCondition As Label
    Friend WithEvents chInventoried As CheckBox
End Class
