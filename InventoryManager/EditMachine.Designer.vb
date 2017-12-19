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
        Me.lblUsername = New System.Windows.Forms.Label()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.txtUsername = New System.Windows.Forms.TextBox()
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
        Me.SuspendLayout()
        '
        'lblIMEI
        '
        Me.lblIMEI.AutoSize = True
        Me.lblIMEI.Location = New System.Drawing.Point(12, 267)
        Me.lblIMEI.Name = "lblIMEI"
        Me.lblIMEI.Size = New System.Drawing.Size(29, 13)
        Me.lblIMEI.TabIndex = 27
        Me.lblIMEI.Text = "IMEI"
        '
        'lblSIM
        '
        Me.lblSIM.AutoSize = True
        Me.lblSIM.Location = New System.Drawing.Point(12, 206)
        Me.lblSIM.Name = "lblSIM"
        Me.lblSIM.Size = New System.Drawing.Size(26, 13)
        Me.lblSIM.TabIndex = 26
        Me.lblSIM.Text = "SIM"
        '
        'lblSerialNumber
        '
        Me.lblSerialNumber.AutoSize = True
        Me.lblSerialNumber.Location = New System.Drawing.Point(148, 149)
        Me.lblSerialNumber.Name = "lblSerialNumber"
        Me.lblSerialNumber.Size = New System.Drawing.Size(73, 13)
        Me.lblSerialNumber.TabIndex = 25
        Me.lblSerialNumber.Text = "Serial Number"
        '
        'lblAssetTag
        '
        Me.lblAssetTag.AutoSize = True
        Me.lblAssetTag.Location = New System.Drawing.Point(12, 149)
        Me.lblAssetTag.Name = "lblAssetTag"
        Me.lblAssetTag.Size = New System.Drawing.Size(117, 13)
        Me.lblAssetTag.TabIndex = 24
        Me.lblAssetTag.Text = "Asset Tag (ex: 123456)"
        '
        'lblMachineName
        '
        Me.lblMachineName.AutoSize = True
        Me.lblMachineName.Location = New System.Drawing.Point(12, 92)
        Me.lblMachineName.Name = "lblMachineName"
        Me.lblMachineName.Size = New System.Drawing.Size(139, 13)
        Me.lblMachineName.TabIndex = 23
        Me.lblMachineName.Text = "Machine Name (ex: JDoe-L)"
        '
        'lblUsername
        '
        Me.lblUsername.AutoSize = True
        Me.lblUsername.Location = New System.Drawing.Point(12, 30)
        Me.lblUsername.Name = "lblUsername"
        Me.lblUsername.Size = New System.Drawing.Size(106, 13)
        Me.lblUsername.TabIndex = 22
        Me.lblUsername.Text = "Username (ex: JDoe)"
        '
        'btnBack
        '
        Me.btnBack.Location = New System.Drawing.Point(12, 432)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(75, 23)
        Me.btnBack.TabIndex = 21
        Me.btnBack.Text = "Back"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'txtUsername
        '
        Me.txtUsername.BackColor = System.Drawing.SystemColors.Window
        Me.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUsername.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsername.Location = New System.Drawing.Point(12, 49)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(277, 26)
        Me.txtUsername.TabIndex = 14
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(156, 420)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(133, 35)
        Me.btnSave.TabIndex = 19
        Me.btnSave.Text = "Save Changes"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'txtIMEI
        '
        Me.txtIMEI.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIMEI.Location = New System.Drawing.Point(12, 286)
        Me.txtIMEI.Multiline = True
        Me.txtIMEI.Name = "txtIMEI"
        Me.txtIMEI.Size = New System.Drawing.Size(277, 20)
        Me.txtIMEI.TabIndex = 20
        '
        'txtSIM
        '
        Me.txtSIM.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSIM.Location = New System.Drawing.Point(12, 225)
        Me.txtSIM.Name = "txtSIM"
        Me.txtSIM.Size = New System.Drawing.Size(277, 26)
        Me.txtSIM.TabIndex = 18
        '
        'txtSerialNumber
        '
        Me.txtSerialNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSerialNumber.Location = New System.Drawing.Point(148, 168)
        Me.txtSerialNumber.Name = "txtSerialNumber"
        Me.txtSerialNumber.Size = New System.Drawing.Size(141, 26)
        Me.txtSerialNumber.TabIndex = 17
        '
        'txtAssetTag
        '
        Me.txtAssetTag.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAssetTag.Location = New System.Drawing.Point(12, 168)
        Me.txtAssetTag.Name = "txtAssetTag"
        Me.txtAssetTag.Size = New System.Drawing.Size(117, 26)
        Me.txtAssetTag.TabIndex = 16
        '
        'txtMachineName
        '
        Me.txtMachineName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMachineName.Location = New System.Drawing.Point(12, 111)
        Me.txtMachineName.Name = "txtMachineName"
        Me.txtMachineName.Size = New System.Drawing.Size(277, 26)
        Me.txtMachineName.TabIndex = 15
        '
        'lblReceived
        '
        Me.lblReceived.AutoSize = True
        Me.lblReceived.Location = New System.Drawing.Point(12, 333)
        Me.lblReceived.Name = "lblReceived"
        Me.lblReceived.Size = New System.Drawing.Size(56, 13)
        Me.lblReceived.TabIndex = 28
        Me.lblReceived.Text = "Received:"
        '
        'dteReceived
        '
        Me.dteReceived.Location = New System.Drawing.Point(89, 327)
        Me.dteReceived.MinDate = New Date(2000, 1, 1, 0, 0, 0, 0)
        Me.dteReceived.Name = "dteReceived"
        Me.dteReceived.Size = New System.Drawing.Size(200, 20)
        Me.dteReceived.TabIndex = 29
        '
        'lblAcquisition
        '
        Me.lblAcquisition.AutoSize = True
        Me.lblAcquisition.Location = New System.Drawing.Point(15, 377)
        Me.lblAcquisition.Name = "lblAcquisition"
        Me.lblAcquisition.Size = New System.Drawing.Size(61, 13)
        Me.lblAcquisition.TabIndex = 30
        Me.lblAcquisition.Text = "Acquisition:"
        '
        'dteAcquisition
        '
        Me.dteAcquisition.Location = New System.Drawing.Point(89, 371)
        Me.dteAcquisition.MinDate = New Date(2017, 1, 1, 0, 0, 0, 0)
        Me.dteAcquisition.Name = "dteAcquisition"
        Me.dteAcquisition.Size = New System.Drawing.Size(200, 20)
        Me.dteAcquisition.TabIndex = 31
        '
        'EditMachine
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(301, 467)
        Me.Controls.Add(Me.dteAcquisition)
        Me.Controls.Add(Me.lblAcquisition)
        Me.Controls.Add(Me.dteReceived)
        Me.Controls.Add(Me.lblReceived)
        Me.Controls.Add(Me.lblIMEI)
        Me.Controls.Add(Me.lblSIM)
        Me.Controls.Add(Me.lblSerialNumber)
        Me.Controls.Add(Me.lblAssetTag)
        Me.Controls.Add(Me.lblMachineName)
        Me.Controls.Add(Me.lblUsername)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.txtUsername)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.txtIMEI)
        Me.Controls.Add(Me.txtSIM)
        Me.Controls.Add(Me.txtSerialNumber)
        Me.Controls.Add(Me.txtAssetTag)
        Me.Controls.Add(Me.txtMachineName)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "EditMachine"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "EditMachine"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblIMEI As Label
    Friend WithEvents lblSIM As Label
    Friend WithEvents lblSerialNumber As Label
    Friend WithEvents lblAssetTag As Label
    Friend WithEvents lblMachineName As Label
    Friend WithEvents lblUsername As Label
    Friend WithEvents btnBack As Button
    Friend WithEvents txtUsername As TextBox
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
End Class
