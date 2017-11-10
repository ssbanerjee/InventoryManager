<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddLaptop
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
        Me.txtMachineName = New System.Windows.Forms.TextBox()
        Me.txtAssetTag = New System.Windows.Forms.TextBox()
        Me.txtSerialNumber = New System.Windows.Forms.TextBox()
        Me.txtSIM = New System.Windows.Forms.TextBox()
        Me.txtIMEI = New System.Windows.Forms.TextBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.lblUsername = New System.Windows.Forms.Label()
        Me.lblMachineName = New System.Windows.Forms.Label()
        Me.lblAssetTag = New System.Windows.Forms.Label()
        Me.lblSerialNumber = New System.Windows.Forms.Label()
        Me.lblSIM = New System.Windows.Forms.Label()
        Me.lblIMEI = New System.Windows.Forms.Label()
        Me.lblModel = New System.Windows.Forms.Label()
        Me.cbModel = New System.Windows.Forms.ComboBox()
        Me.chCostCenter = New System.Windows.Forms.CheckBox()
        Me.txtCostCenter = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbCenter = New System.Windows.Forms.ComboBox()
        Me.lblCenter = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtMachineName
        '
        Me.txtMachineName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMachineName.Location = New System.Drawing.Point(12, 111)
        Me.txtMachineName.Name = "txtMachineName"
        Me.txtMachineName.Size = New System.Drawing.Size(139, 26)
        Me.txtMachineName.TabIndex = 1
        '
        'txtAssetTag
        '
        Me.txtAssetTag.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAssetTag.Location = New System.Drawing.Point(12, 168)
        Me.txtAssetTag.Name = "txtAssetTag"
        Me.txtAssetTag.Size = New System.Drawing.Size(117, 26)
        Me.txtAssetTag.TabIndex = 3
        '
        'txtSerialNumber
        '
        Me.txtSerialNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSerialNumber.Location = New System.Drawing.Point(148, 168)
        Me.txtSerialNumber.Name = "txtSerialNumber"
        Me.txtSerialNumber.Size = New System.Drawing.Size(141, 26)
        Me.txtSerialNumber.TabIndex = 4
        '
        'txtSIM
        '
        Me.txtSIM.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSIM.Location = New System.Drawing.Point(12, 225)
        Me.txtSIM.Name = "txtSIM"
        Me.txtSIM.Size = New System.Drawing.Size(277, 26)
        Me.txtSIM.TabIndex = 5
        '
        'txtIMEI
        '
        Me.txtIMEI.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIMEI.Location = New System.Drawing.Point(12, 286)
        Me.txtIMEI.Name = "txtIMEI"
        Me.txtIMEI.Size = New System.Drawing.Size(277, 26)
        Me.txtIMEI.TabIndex = 6
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(156, 440)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(133, 35)
        Me.btnAdd.TabIndex = 7
        Me.btnAdd.Text = "Add Machine"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'txtUsername
        '
        Me.txtUsername.BackColor = System.Drawing.SystemColors.Window
        Me.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUsername.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsername.Location = New System.Drawing.Point(12, 49)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(277, 26)
        Me.txtUsername.TabIndex = 0
        '
        'btnBack
        '
        Me.btnBack.Location = New System.Drawing.Point(12, 452)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(75, 23)
        Me.btnBack.TabIndex = 8
        Me.btnBack.TabStop = False
        Me.btnBack.Text = "Back"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'lblUsername
        '
        Me.lblUsername.AutoSize = True
        Me.lblUsername.Location = New System.Drawing.Point(12, 30)
        Me.lblUsername.Name = "lblUsername"
        Me.lblUsername.Size = New System.Drawing.Size(106, 13)
        Me.lblUsername.TabIndex = 8
        Me.lblUsername.Text = "Username (ex: JDoe)"
        '
        'lblMachineName
        '
        Me.lblMachineName.AutoSize = True
        Me.lblMachineName.Location = New System.Drawing.Point(12, 92)
        Me.lblMachineName.Name = "lblMachineName"
        Me.lblMachineName.Size = New System.Drawing.Size(139, 13)
        Me.lblMachineName.TabIndex = 9
        Me.lblMachineName.Text = "Machine Name (ex: JDoe-L)"
        '
        'lblAssetTag
        '
        Me.lblAssetTag.AutoSize = True
        Me.lblAssetTag.Location = New System.Drawing.Point(12, 149)
        Me.lblAssetTag.Name = "lblAssetTag"
        Me.lblAssetTag.Size = New System.Drawing.Size(117, 13)
        Me.lblAssetTag.TabIndex = 10
        Me.lblAssetTag.Text = "Asset Tag (ex: 123456)"
        '
        'lblSerialNumber
        '
        Me.lblSerialNumber.AutoSize = True
        Me.lblSerialNumber.Location = New System.Drawing.Point(148, 149)
        Me.lblSerialNumber.Name = "lblSerialNumber"
        Me.lblSerialNumber.Size = New System.Drawing.Size(73, 13)
        Me.lblSerialNumber.TabIndex = 11
        Me.lblSerialNumber.Text = "Serial Number"
        '
        'lblSIM
        '
        Me.lblSIM.AutoSize = True
        Me.lblSIM.Location = New System.Drawing.Point(12, 206)
        Me.lblSIM.Name = "lblSIM"
        Me.lblSIM.Size = New System.Drawing.Size(26, 13)
        Me.lblSIM.TabIndex = 12
        Me.lblSIM.Text = "SIM"
        '
        'lblIMEI
        '
        Me.lblIMEI.AutoSize = True
        Me.lblIMEI.Location = New System.Drawing.Point(12, 267)
        Me.lblIMEI.Name = "lblIMEI"
        Me.lblIMEI.Size = New System.Drawing.Size(29, 13)
        Me.lblIMEI.TabIndex = 13
        Me.lblIMEI.Text = "IMEI"
        '
        'lblModel
        '
        Me.lblModel.AutoSize = True
        Me.lblModel.Location = New System.Drawing.Point(157, 92)
        Me.lblModel.Name = "lblModel"
        Me.lblModel.Size = New System.Drawing.Size(36, 13)
        Me.lblModel.TabIndex = 14
        Me.lblModel.Text = "Model"
        '
        'cbModel
        '
        Me.cbModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbModel.FormattingEnabled = True
        Me.cbModel.Location = New System.Drawing.Point(157, 111)
        Me.cbModel.Name = "cbModel"
        Me.cbModel.Size = New System.Drawing.Size(132, 26)
        Me.cbModel.TabIndex = 2
        '
        'chCostCenter
        '
        Me.chCostCenter.AutoSize = True
        Me.chCostCenter.Location = New System.Drawing.Point(148, 403)
        Me.chCostCenter.Name = "chCostCenter"
        Me.chCostCenter.Size = New System.Drawing.Size(141, 17)
        Me.chCostCenter.TabIndex = 35
        Me.chCostCenter.Text = "Charge different location"
        Me.chCostCenter.UseVisualStyleBackColor = True
        '
        'txtCostCenter
        '
        Me.txtCostCenter.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCostCenter.Location = New System.Drawing.Point(15, 396)
        Me.txtCostCenter.Name = "txtCostCenter"
        Me.txtCostCenter.ReadOnly = True
        Me.txtCostCenter.Size = New System.Drawing.Size(114, 26)
        Me.txtCostCenter.TabIndex = 34
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 380)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 33
        Me.Label1.Text = "Cost Center"
        '
        'cbCenter
        '
        Me.cbCenter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbCenter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbCenter.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCenter.FormattingEnabled = True
        Me.cbCenter.Location = New System.Drawing.Point(15, 341)
        Me.cbCenter.Name = "cbCenter"
        Me.cbCenter.Size = New System.Drawing.Size(277, 26)
        Me.cbCenter.TabIndex = 36
        '
        'lblCenter
        '
        Me.lblCenter.AutoSize = True
        Me.lblCenter.Location = New System.Drawing.Point(12, 325)
        Me.lblCenter.Name = "lblCenter"
        Me.lblCenter.Size = New System.Drawing.Size(81, 13)
        Me.lblCenter.TabIndex = 37
        Me.lblCenter.Text = "Center Number:"
        '
        'AddLaptop
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(301, 487)
        Me.Controls.Add(Me.cbCenter)
        Me.Controls.Add(Me.lblCenter)
        Me.Controls.Add(Me.chCostCenter)
        Me.Controls.Add(Me.txtCostCenter)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbModel)
        Me.Controls.Add(Me.lblModel)
        Me.Controls.Add(Me.lblIMEI)
        Me.Controls.Add(Me.lblSIM)
        Me.Controls.Add(Me.lblSerialNumber)
        Me.Controls.Add(Me.lblAssetTag)
        Me.Controls.Add(Me.lblMachineName)
        Me.Controls.Add(Me.lblUsername)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.txtUsername)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.txtIMEI)
        Me.Controls.Add(Me.txtSIM)
        Me.Controls.Add(Me.txtSerialNumber)
        Me.Controls.Add(Me.txtAssetTag)
        Me.Controls.Add(Me.txtMachineName)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "AddLaptop"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add Laptop"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtMachineName As TextBox
    Friend WithEvents txtAssetTag As TextBox
    Friend WithEvents txtSerialNumber As TextBox
    Friend WithEvents txtSIM As TextBox
    Friend WithEvents txtIMEI As TextBox
    Friend WithEvents btnAdd As Button
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents btnBack As Button
    Friend WithEvents lblUsername As Label
    Friend WithEvents lblMachineName As Label
    Friend WithEvents lblAssetTag As Label
    Friend WithEvents lblSerialNumber As Label
    Friend WithEvents lblSIM As Label
    Friend WithEvents lblIMEI As Label
    Friend WithEvents lblModel As Label
    Friend WithEvents cbModel As ComboBox
    Friend WithEvents chCostCenter As CheckBox
    Friend WithEvents txtCostCenter As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cbCenter As ComboBox
    Friend WithEvents lblCenter As Label
End Class
