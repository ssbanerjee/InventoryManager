<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditMachine
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
        Me.lblIMEI = New System.Windows.Forms.Label()
        Me.lblSIM = New System.Windows.Forms.Label()
        Me.lblSerialNumber = New System.Windows.Forms.Label()
        Me.lblAssetTag = New System.Windows.Forms.Label()
        Me.lblMachineName = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.txtIMEI = New System.Windows.Forms.TextBox()
        Me.txtSIM = New System.Windows.Forms.TextBox()
        Me.txtSerialNumber = New System.Windows.Forms.TextBox()
        Me.txtAssetTag = New System.Windows.Forms.TextBox()
        Me.txtMachineName = New System.Windows.Forms.TextBox()
        Me.lblReceived = New System.Windows.Forms.Label()
        Me.dteReceived = New System.Windows.Forms.DateTimePicker()
        Me.lblAcquisition = New System.Windows.Forms.Label()
        Me.dteAcquisition = New System.Windows.Forms.DateTimePicker()
        Me.lblAssetState = New System.Windows.Forms.Label()
        Me.cbAssetState = New System.Windows.Forms.ComboBox()
        Me.cbCenter = New System.Windows.Forms.ComboBox()
        Me.lblCenter = New System.Windows.Forms.Label()
        Me.txtCostCenter = New System.Windows.Forms.TextBox()
        Me.lblCostCenter = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblCondition = New System.Windows.Forms.Label()
        Me.cbCondition = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtMESD = New System.Windows.Forms.TextBox()
        Me.lblError = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblIMEI
        '
        Me.lblIMEI.AutoSize = True
        Me.lblIMEI.Location = New System.Drawing.Point(328, 117)
        Me.lblIMEI.Name = "lblIMEI"
        Me.lblIMEI.Size = New System.Drawing.Size(29, 13)
        Me.lblIMEI.TabIndex = 27
        Me.lblIMEI.Text = "IMEI"
        '
        'lblSIM
        '
        Me.lblSIM.AutoSize = True
        Me.lblSIM.Location = New System.Drawing.Point(328, 56)
        Me.lblSIM.Name = "lblSIM"
        Me.lblSIM.Size = New System.Drawing.Size(26, 13)
        Me.lblSIM.TabIndex = 26
        Me.lblSIM.Text = "SIM"
        '
        'lblSerialNumber
        '
        Me.lblSerialNumber.AutoSize = True
        Me.lblSerialNumber.Location = New System.Drawing.Point(148, 119)
        Me.lblSerialNumber.Name = "lblSerialNumber"
        Me.lblSerialNumber.Size = New System.Drawing.Size(73, 13)
        Me.lblSerialNumber.TabIndex = 25
        Me.lblSerialNumber.Text = "Serial Number"
        '
        'lblAssetTag
        '
        Me.lblAssetTag.AutoSize = True
        Me.lblAssetTag.Location = New System.Drawing.Point(12, 119)
        Me.lblAssetTag.Name = "lblAssetTag"
        Me.lblAssetTag.Size = New System.Drawing.Size(117, 13)
        Me.lblAssetTag.TabIndex = 24
        Me.lblAssetTag.Text = "Asset Tag (ex: 123456)"
        '
        'lblMachineName
        '
        Me.lblMachineName.AutoSize = True
        Me.lblMachineName.Location = New System.Drawing.Point(12, 56)
        Me.lblMachineName.Name = "lblMachineName"
        Me.lblMachineName.Size = New System.Drawing.Size(139, 13)
        Me.lblMachineName.TabIndex = 23
        Me.lblMachineName.Text = "Machine Name (ex: JDoe-L)"
        '
        'btnSave
        '
        Me.btnSave.Enabled = False
        Me.btnSave.Location = New System.Drawing.Point(12, 308)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(593, 45)
        Me.btnSave.TabIndex = 13
        Me.btnSave.Text = "Save Changes"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'txtIMEI
        '
        Me.txtIMEI.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIMEI.Location = New System.Drawing.Point(328, 136)
        Me.txtIMEI.Multiline = True
        Me.txtIMEI.Name = "txtIMEI"
        Me.txtIMEI.Size = New System.Drawing.Size(277, 28)
        Me.txtIMEI.TabIndex = 9
        '
        'txtSIM
        '
        Me.txtSIM.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSIM.Location = New System.Drawing.Point(328, 75)
        Me.txtSIM.Name = "txtSIM"
        Me.txtSIM.Size = New System.Drawing.Size(277, 26)
        Me.txtSIM.TabIndex = 8
        '
        'txtSerialNumber
        '
        Me.txtSerialNumber.Enabled = False
        Me.txtSerialNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSerialNumber.Location = New System.Drawing.Point(148, 138)
        Me.txtSerialNumber.Name = "txtSerialNumber"
        Me.txtSerialNumber.Size = New System.Drawing.Size(141, 26)
        Me.txtSerialNumber.TabIndex = 3
        Me.txtSerialNumber.TabStop = False
        '
        'txtAssetTag
        '
        Me.txtAssetTag.Enabled = False
        Me.txtAssetTag.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAssetTag.Location = New System.Drawing.Point(12, 138)
        Me.txtAssetTag.Name = "txtAssetTag"
        Me.txtAssetTag.Size = New System.Drawing.Size(117, 26)
        Me.txtAssetTag.TabIndex = 2
        Me.txtAssetTag.TabStop = False
        '
        'txtMachineName
        '
        Me.txtMachineName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMachineName.Location = New System.Drawing.Point(12, 75)
        Me.txtMachineName.Name = "txtMachineName"
        Me.txtMachineName.Size = New System.Drawing.Size(277, 26)
        Me.txtMachineName.TabIndex = 1
        '
        'lblReceived
        '
        Me.lblReceived.AutoSize = True
        Me.lblReceived.Location = New System.Drawing.Point(328, 190)
        Me.lblReceived.Name = "lblReceived"
        Me.lblReceived.Size = New System.Drawing.Size(56, 13)
        Me.lblReceived.TabIndex = 28
        Me.lblReceived.Text = "Received:"
        '
        'dteReceived
        '
        Me.dteReceived.Location = New System.Drawing.Point(405, 184)
        Me.dteReceived.MinDate = New Date(2000, 1, 1, 0, 0, 0, 0)
        Me.dteReceived.Name = "dteReceived"
        Me.dteReceived.Size = New System.Drawing.Size(200, 20)
        Me.dteReceived.TabIndex = 10
        Me.dteReceived.TabStop = False
        '
        'lblAcquisition
        '
        Me.lblAcquisition.AutoSize = True
        Me.lblAcquisition.Location = New System.Drawing.Point(328, 228)
        Me.lblAcquisition.Name = "lblAcquisition"
        Me.lblAcquisition.Size = New System.Drawing.Size(61, 13)
        Me.lblAcquisition.TabIndex = 30
        Me.lblAcquisition.Text = "Acquisition:"
        '
        'dteAcquisition
        '
        Me.dteAcquisition.Location = New System.Drawing.Point(405, 228)
        Me.dteAcquisition.MinDate = New Date(2017, 1, 1, 0, 0, 0, 0)
        Me.dteAcquisition.Name = "dteAcquisition"
        Me.dteAcquisition.Size = New System.Drawing.Size(200, 20)
        Me.dteAcquisition.TabIndex = 11
        '
        'lblAssetState
        '
        Me.lblAssetState.AutoSize = True
        Me.lblAssetState.Location = New System.Drawing.Point(12, 191)
        Me.lblAssetState.Name = "lblAssetState"
        Me.lblAssetState.Size = New System.Drawing.Size(64, 13)
        Me.lblAssetState.TabIndex = 32
        Me.lblAssetState.Text = "Asset State:"
        '
        'cbAssetState
        '
        Me.cbAssetState.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbAssetState.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbAssetState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbAssetState.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbAssetState.FormattingEnabled = True
        Me.cbAssetState.Location = New System.Drawing.Point(99, 188)
        Me.cbAssetState.Name = "cbAssetState"
        Me.cbAssetState.Size = New System.Drawing.Size(190, 26)
        Me.cbAssetState.TabIndex = 4
        '
        'cbCenter
        '
        Me.cbCenter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbCenter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbCenter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCenter.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCenter.FormattingEnabled = True
        Me.cbCenter.Location = New System.Drawing.Point(99, 220)
        Me.cbCenter.Name = "cbCenter"
        Me.cbCenter.Size = New System.Drawing.Size(190, 26)
        Me.cbCenter.TabIndex = 5
        '
        'lblCenter
        '
        Me.lblCenter.AutoSize = True
        Me.lblCenter.Location = New System.Drawing.Point(12, 227)
        Me.lblCenter.Name = "lblCenter"
        Me.lblCenter.Size = New System.Drawing.Size(81, 13)
        Me.lblCenter.TabIndex = 39
        Me.lblCenter.Text = "Center Number:"
        '
        'txtCostCenter
        '
        Me.txtCostCenter.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCostCenter.Location = New System.Drawing.Point(405, 261)
        Me.txtCostCenter.Name = "txtCostCenter"
        Me.txtCostCenter.Size = New System.Drawing.Size(200, 26)
        Me.txtCostCenter.TabIndex = 12
        '
        'lblCostCenter
        '
        Me.lblCostCenter.AutoSize = True
        Me.lblCostCenter.Location = New System.Drawing.Point(328, 261)
        Me.lblCostCenter.Name = "lblCostCenter"
        Me.lblCostCenter.Size = New System.Drawing.Size(70, 26)
        Me.lblCostCenter.TabIndex = 40
        Me.lblCostCenter.Text = "Cost Center /" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "PAR"
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(15, 13)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(69, 23)
        Me.lblTitle.TabIndex = 43
        Me.lblTitle.Text = "MODEL"
        '
        'lblCondition
        '
        Me.lblCondition.AutoSize = True
        Me.lblCondition.Location = New System.Drawing.Point(13, 271)
        Me.lblCondition.Name = "lblCondition"
        Me.lblCondition.Size = New System.Drawing.Size(54, 13)
        Me.lblCondition.TabIndex = 44
        Me.lblCondition.Text = "Condition:"
        '
        'cbCondition
        '
        Me.cbCondition.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbCondition.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbCondition.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCondition.FormattingEnabled = True
        Me.cbCondition.Location = New System.Drawing.Point(73, 261)
        Me.cbCondition.Name = "cbCondition"
        Me.cbCondition.Size = New System.Drawing.Size(78, 28)
        Me.cbCondition.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(157, 271)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 46
        Me.Label1.Text = "Ticket #"
        '
        'txtMESD
        '
        Me.txtMESD.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMESD.Location = New System.Drawing.Point(203, 261)
        Me.txtMESD.Name = "txtMESD"
        Me.txtMESD.Size = New System.Drawing.Size(86, 26)
        Me.txtMESD.TabIndex = 7
        '
        'lblError
        '
        Me.lblError.AutoSize = True
        Me.lblError.ForeColor = System.Drawing.Color.Red
        Me.lblError.Location = New System.Drawing.Point(157, 56)
        Me.lblError.Name = "lblError"
        Me.lblError.Size = New System.Drawing.Size(29, 13)
        Me.lblError.TabIndex = 47
        Me.lblError.Text = "Error"
        Me.lblError.Visible = False
        '
        'EditMachine
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(617, 365)
        Me.Controls.Add(Me.lblError)
        Me.Controls.Add(Me.txtMESD)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbCondition)
        Me.Controls.Add(Me.lblCondition)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.txtCostCenter)
        Me.Controls.Add(Me.lblCostCenter)
        Me.Controls.Add(Me.cbCenter)
        Me.Controls.Add(Me.lblCenter)
        Me.Controls.Add(Me.cbAssetState)
        Me.Controls.Add(Me.lblAssetState)
        Me.Controls.Add(Me.dteAcquisition)
        Me.Controls.Add(Me.lblAcquisition)
        Me.Controls.Add(Me.dteReceived)
        Me.Controls.Add(Me.lblReceived)
        Me.Controls.Add(Me.lblIMEI)
        Me.Controls.Add(Me.lblSIM)
        Me.Controls.Add(Me.lblSerialNumber)
        Me.Controls.Add(Me.lblAssetTag)
        Me.Controls.Add(Me.lblMachineName)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.txtIMEI)
        Me.Controls.Add(Me.txtSIM)
        Me.Controls.Add(Me.txtSerialNumber)
        Me.Controls.Add(Me.txtAssetTag)
        Me.Controls.Add(Me.txtMachineName)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "EditMachine"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "EditMachine"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblIMEI As Label
    Friend WithEvents lblSIM As Label
    Friend WithEvents lblSerialNumber As Label
    Friend WithEvents lblAssetTag As Label
    Friend WithEvents lblMachineName As Label
    Friend WithEvents btnSave As Button
    Friend WithEvents txtIMEI As TextBox
    Friend WithEvents txtSIM As TextBox
    Friend WithEvents txtSerialNumber As TextBox
    Friend WithEvents txtAssetTag As TextBox
    Friend WithEvents txtMachineName As TextBox
    Friend WithEvents lblReceived As Label
    Friend WithEvents dteReceived As DateTimePicker
    Friend WithEvents lblAcquisition As Label
    Friend WithEvents dteAcquisition As DateTimePicker
    Friend WithEvents lblAssetState As Label
    Friend WithEvents cbAssetState As ComboBox
    Friend WithEvents cbCenter As ComboBox
    Friend WithEvents lblCenter As Label
    Friend WithEvents txtCostCenter As TextBox
    Friend WithEvents lblCostCenter As Label
    Friend WithEvents lblTitle As Label
    Friend WithEvents lblCondition As Label
    Friend WithEvents cbCondition As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtMESD As TextBox
    Friend WithEvents lblError As Label
End Class
