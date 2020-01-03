<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Search
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Search))
        Me.gbSearchOptions = New System.Windows.Forms.GroupBox()
        Me.lblFModel = New System.Windows.Forms.Label()
        Me.lblFCategory = New System.Windows.Forms.Label()
        Me.cbModel = New System.Windows.Forms.ComboBox()
        Me.cbCategory = New System.Windows.Forms.ComboBox()
        Me.txtAssetTag = New System.Windows.Forms.TextBox()
        Me.lstMachines = New System.Windows.Forms.ListBox()
        Me.txtFilter = New System.Windows.Forms.TextBox()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.gbListOptions = New System.Windows.Forms.GroupBox()
        Me.rdListSerialNumbers = New System.Windows.Forms.RadioButton()
        Me.rdListMachineNames = New System.Windows.Forms.RadioButton()
        Me.gbMachine = New System.Windows.Forms.GroupBox()
        Me.btnShip = New System.Windows.Forms.Button()
        Me.lblMESD = New System.Windows.Forms.Label()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.lblIMEI = New System.Windows.Forms.Label()
        Me.lblSim = New System.Windows.Forms.Label()
        Me.lblAcquisition = New System.Windows.Forms.Label()
        Me.lblReceived = New System.Windows.Forms.Label()
        Me.lblSiteUser = New System.Windows.Forms.Label()
        Me.lblCatModel = New System.Windows.Forms.Label()
        Me.lblSerialNumber = New System.Windows.Forms.Label()
        Me.lblAssetTag = New System.Windows.Forms.Label()
        Me.lblMachineName = New System.Windows.Forms.Label()
        Me.lblFAssetTag = New System.Windows.Forms.Label()
        Me.btnNote = New System.Windows.Forms.Button()
        Me.btnCompletion = New System.Windows.Forms.Button()
        Me.gbSearchOptions.SuspendLayout()
        Me.gbListOptions.SuspendLayout()
        Me.gbMachine.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbSearchOptions
        '
        Me.gbSearchOptions.Controls.Add(Me.lblFModel)
        Me.gbSearchOptions.Controls.Add(Me.lblFCategory)
        Me.gbSearchOptions.Controls.Add(Me.cbModel)
        Me.gbSearchOptions.Controls.Add(Me.cbCategory)
        Me.gbSearchOptions.Location = New System.Drawing.Point(26, 25)
        Me.gbSearchOptions.Name = "gbSearchOptions"
        Me.gbSearchOptions.Size = New System.Drawing.Size(373, 77)
        Me.gbSearchOptions.TabIndex = 3
        Me.gbSearchOptions.TabStop = False
        Me.gbSearchOptions.Text = "Filters"
        '
        'lblFModel
        '
        Me.lblFModel.AutoSize = True
        Me.lblFModel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFModel.Location = New System.Drawing.Point(149, 22)
        Me.lblFModel.Name = "lblFModel"
        Me.lblFModel.Size = New System.Drawing.Size(42, 15)
        Me.lblFModel.TabIndex = 3
        Me.lblFModel.Text = "Model"
        '
        'lblFCategory
        '
        Me.lblFCategory.AutoSize = True
        Me.lblFCategory.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFCategory.Location = New System.Drawing.Point(6, 22)
        Me.lblFCategory.Name = "lblFCategory"
        Me.lblFCategory.Size = New System.Drawing.Size(55, 15)
        Me.lblFCategory.TabIndex = 2
        Me.lblFCategory.Text = "Category"
        '
        'cbModel
        '
        Me.cbModel.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbModel.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbModel.Enabled = False
        Me.cbModel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbModel.FormattingEnabled = True
        Me.cbModel.Location = New System.Drawing.Point(149, 38)
        Me.cbModel.Name = "cbModel"
        Me.cbModel.Size = New System.Drawing.Size(121, 23)
        Me.cbModel.TabIndex = 1
        '
        'cbCategory
        '
        Me.cbCategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbCategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCategory.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCategory.FormattingEnabled = True
        Me.cbCategory.Location = New System.Drawing.Point(9, 38)
        Me.cbCategory.Name = "cbCategory"
        Me.cbCategory.Size = New System.Drawing.Size(121, 23)
        Me.cbCategory.TabIndex = 0
        '
        'txtAssetTag
        '
        Me.txtAssetTag.Location = New System.Drawing.Point(151, 133)
        Me.txtAssetTag.Name = "txtAssetTag"
        Me.txtAssetTag.Size = New System.Drawing.Size(117, 20)
        Me.txtAssetTag.TabIndex = 4
        '
        'lstMachines
        '
        Me.lstMachines.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstMachines.FormattingEnabled = True
        Me.lstMachines.ItemHeight = 25
        Me.lstMachines.Location = New System.Drawing.Point(432, 51)
        Me.lstMachines.Name = "lstMachines"
        Me.lstMachines.Size = New System.Drawing.Size(285, 304)
        Me.lstMachines.TabIndex = 6
        '
        'txtFilter
        '
        Me.txtFilter.Location = New System.Drawing.Point(432, 25)
        Me.txtFilter.Name = "txtFilter"
        Me.txtFilter.Size = New System.Drawing.Size(285, 20)
        Me.txtFilter.TabIndex = 7
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(432, 431)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(75, 23)
        Me.btnRefresh.TabIndex = 8
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'gbListOptions
        '
        Me.gbListOptions.Controls.Add(Me.rdListSerialNumbers)
        Me.gbListOptions.Controls.Add(Me.rdListMachineNames)
        Me.gbListOptions.Location = New System.Drawing.Point(432, 376)
        Me.gbListOptions.Name = "gbListOptions"
        Me.gbListOptions.Size = New System.Drawing.Size(285, 45)
        Me.gbListOptions.TabIndex = 11
        Me.gbListOptions.TabStop = False
        Me.gbListOptions.Text = "Show By:"
        '
        'rdListSerialNumbers
        '
        Me.rdListSerialNumbers.AutoSize = True
        Me.rdListSerialNumbers.Location = New System.Drawing.Point(151, 19)
        Me.rdListSerialNumbers.Name = "rdListSerialNumbers"
        Me.rdListSerialNumbers.Size = New System.Drawing.Size(91, 17)
        Me.rdListSerialNumbers.TabIndex = 1
        Me.rdListSerialNumbers.TabStop = True
        Me.rdListSerialNumbers.Text = "Serial Number"
        Me.rdListSerialNumbers.UseVisualStyleBackColor = True
        '
        'rdListMachineNames
        '
        Me.rdListMachineNames.AutoSize = True
        Me.rdListMachineNames.Checked = True
        Me.rdListMachineNames.Location = New System.Drawing.Point(48, 19)
        Me.rdListMachineNames.Name = "rdListMachineNames"
        Me.rdListMachineNames.Size = New System.Drawing.Size(97, 17)
        Me.rdListMachineNames.TabIndex = 0
        Me.rdListMachineNames.TabStop = True
        Me.rdListMachineNames.Text = "Machine Name"
        Me.rdListMachineNames.UseVisualStyleBackColor = True
        '
        'gbMachine
        '
        Me.gbMachine.Controls.Add(Me.btnShip)
        Me.gbMachine.Controls.Add(Me.lblMESD)
        Me.gbMachine.Controls.Add(Me.btnEdit)
        Me.gbMachine.Controls.Add(Me.lblIMEI)
        Me.gbMachine.Controls.Add(Me.lblSim)
        Me.gbMachine.Controls.Add(Me.lblAcquisition)
        Me.gbMachine.Controls.Add(Me.lblReceived)
        Me.gbMachine.Controls.Add(Me.lblSiteUser)
        Me.gbMachine.Controls.Add(Me.lblCatModel)
        Me.gbMachine.Controls.Add(Me.lblSerialNumber)
        Me.gbMachine.Controls.Add(Me.lblAssetTag)
        Me.gbMachine.Controls.Add(Me.lblMachineName)
        Me.gbMachine.Location = New System.Drawing.Point(27, 181)
        Me.gbMachine.Name = "gbMachine"
        Me.gbMachine.Size = New System.Drawing.Size(373, 279)
        Me.gbMachine.TabIndex = 12
        Me.gbMachine.TabStop = False
        Me.gbMachine.Text = resources.GetString("gbMachine.Text")
        '
        'btnShip
        '
        Me.btnShip.Enabled = False
        Me.btnShip.Location = New System.Drawing.Point(270, 221)
        Me.btnShip.Name = "btnShip"
        Me.btnShip.Size = New System.Drawing.Size(97, 23)
        Me.btnShip.TabIndex = 11
        Me.btnShip.Text = "Ship Machine"
        Me.btnShip.UseVisualStyleBackColor = True
        '
        'lblMESD
        '
        Me.lblMESD.AutoSize = True
        Me.lblMESD.Location = New System.Drawing.Point(9, 250)
        Me.lblMESD.Name = "lblMESD"
        Me.lblMESD.Size = New System.Drawing.Size(41, 13)
        Me.lblMESD.TabIndex = 10
        Me.lblMESD.Text = "MESD:"
        '
        'btnEdit
        '
        Me.btnEdit.Enabled = False
        Me.btnEdit.Location = New System.Drawing.Point(269, 250)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(98, 23)
        Me.btnEdit.TabIndex = 9
        Me.btnEdit.Text = "Edit Information"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'lblIMEI
        '
        Me.lblIMEI.AutoSize = True
        Me.lblIMEI.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIMEI.Location = New System.Drawing.Point(9, 141)
        Me.lblIMEI.Name = "lblIMEI"
        Me.lblIMEI.Size = New System.Drawing.Size(35, 15)
        Me.lblIMEI.TabIndex = 8
        Me.lblIMEI.Text = "IMEI:"
        '
        'lblSim
        '
        Me.lblSim.AutoSize = True
        Me.lblSim.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSim.Location = New System.Drawing.Point(9, 120)
        Me.lblSim.Name = "lblSim"
        Me.lblSim.Size = New System.Drawing.Size(31, 15)
        Me.lblSim.TabIndex = 7
        Me.lblSim.Text = "SIM:"
        '
        'lblAcquisition
        '
        Me.lblAcquisition.AutoSize = True
        Me.lblAcquisition.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAcquisition.Location = New System.Drawing.Point(9, 215)
        Me.lblAcquisition.Name = "lblAcquisition"
        Me.lblAcquisition.Size = New System.Drawing.Size(100, 15)
        Me.lblAcquisition.TabIndex = 6
        Me.lblAcquisition.Text = "Acquisition Date:"
        '
        'lblReceived
        '
        Me.lblReceived.AutoSize = True
        Me.lblReceived.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReceived.Location = New System.Drawing.Point(9, 196)
        Me.lblReceived.Name = "lblReceived"
        Me.lblReceived.Size = New System.Drawing.Size(86, 15)
        Me.lblReceived.TabIndex = 5
        Me.lblReceived.Text = "Received Date:"
        '
        'lblSiteUser
        '
        Me.lblSiteUser.AutoSize = True
        Me.lblSiteUser.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSiteUser.Location = New System.Drawing.Point(9, 176)
        Me.lblSiteUser.Name = "lblSiteUser"
        Me.lblSiteUser.Size = New System.Drawing.Size(60, 15)
        Me.lblSiteUser.TabIndex = 4
        Me.lblSiteUser.Text = "Site/User:"
        '
        'lblCatModel
        '
        Me.lblCatModel.AutoSize = True
        Me.lblCatModel.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCatModel.Location = New System.Drawing.Point(6, 77)
        Me.lblCatModel.Name = "lblCatModel"
        Me.lblCatModel.Size = New System.Drawing.Size(119, 18)
        Me.lblCatModel.TabIndex = 3
        Me.lblCatModel.Text = "Category -- Model"
        '
        'lblSerialNumber
        '
        Me.lblSerialNumber.AutoSize = True
        Me.lblSerialNumber.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSerialNumber.Location = New System.Drawing.Point(7, 45)
        Me.lblSerialNumber.Name = "lblSerialNumber"
        Me.lblSerialNumber.Size = New System.Drawing.Size(104, 19)
        Me.lblSerialNumber.TabIndex = 2
        Me.lblSerialNumber.Text = "Serial Number:"
        '
        'lblAssetTag
        '
        Me.lblAssetTag.AutoSize = True
        Me.lblAssetTag.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAssetTag.Location = New System.Drawing.Point(234, 24)
        Me.lblAssetTag.Name = "lblAssetTag"
        Me.lblAssetTag.Size = New System.Drawing.Size(76, 19)
        Me.lblAssetTag.TabIndex = 1
        Me.lblAssetTag.Text = "Asset Tag:"
        '
        'lblMachineName
        '
        Me.lblMachineName.AutoSize = True
        Me.lblMachineName.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMachineName.Location = New System.Drawing.Point(6, 16)
        Me.lblMachineName.Name = "lblMachineName"
        Me.lblMachineName.Size = New System.Drawing.Size(165, 29)
        Me.lblMachineName.TabIndex = 0
        Me.lblMachineName.Text = "Machine Name"
        '
        'lblFAssetTag
        '
        Me.lblFAssetTag.AutoSize = True
        Me.lblFAssetTag.Location = New System.Drawing.Point(36, 140)
        Me.lblFAssetTag.Name = "lblFAssetTag"
        Me.lblFAssetTag.Size = New System.Drawing.Size(109, 13)
        Me.lblFAssetTag.TabIndex = 13
        Me.lblFAssetTag.Text = "Search by Asset Tag:"
        '
        'btnNote
        '
        Me.btnNote.Location = New System.Drawing.Point(514, 430)
        Me.btnNote.Name = "btnNote"
        Me.btnNote.Size = New System.Drawing.Size(75, 23)
        Me.btnNote.TabIndex = 14
        Me.btnNote.Text = "Copy MESD"
        Me.btnNote.UseVisualStyleBackColor = True
        '
        'btnCompletion
        '
        Me.btnCompletion.Location = New System.Drawing.Point(595, 430)
        Me.btnCompletion.Name = "btnCompletion"
        Me.btnCompletion.Size = New System.Drawing.Size(96, 23)
        Me.btnCompletion.TabIndex = 15
        Me.btnCompletion.Text = "Copy Completion"
        Me.btnCompletion.UseVisualStyleBackColor = True
        '
        'Search
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(736, 478)
        Me.Controls.Add(Me.btnCompletion)
        Me.Controls.Add(Me.btnNote)
        Me.Controls.Add(Me.lblFAssetTag)
        Me.Controls.Add(Me.gbMachine)
        Me.Controls.Add(Me.gbListOptions)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.txtFilter)
        Me.Controls.Add(Me.lstMachines)
        Me.Controls.Add(Me.txtAssetTag)
        Me.Controls.Add(Me.gbSearchOptions)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Search"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Search"
        Me.gbSearchOptions.ResumeLayout(False)
        Me.gbSearchOptions.PerformLayout()
        Me.gbListOptions.ResumeLayout(False)
        Me.gbListOptions.PerformLayout()
        Me.gbMachine.ResumeLayout(False)
        Me.gbMachine.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gbSearchOptions As GroupBox
    Friend WithEvents txtAssetTag As TextBox
    Friend WithEvents lstMachines As ListBox
    Friend WithEvents txtFilter As TextBox
    Friend WithEvents btnRefresh As Button
    Friend WithEvents gbListOptions As GroupBox
    Friend WithEvents rdListSerialNumbers As RadioButton
    Friend WithEvents rdListMachineNames As RadioButton
    Friend WithEvents gbMachine As GroupBox
    Friend WithEvents lblMachineName As Label
    Friend WithEvents lblAcquisition As Label
    Friend WithEvents lblReceived As Label
    Friend WithEvents lblSiteUser As Label
    Friend WithEvents lblCatModel As Label
    Friend WithEvents lblSerialNumber As Label
    Friend WithEvents lblAssetTag As Label
    Friend WithEvents lblIMEI As Label
    Friend WithEvents lblSim As Label
    Friend WithEvents btnEdit As Button
    Friend WithEvents lblFModel As Label
    Friend WithEvents lblFCategory As Label
    Friend WithEvents cbModel As ComboBox
    Friend WithEvents cbCategory As ComboBox
    Friend WithEvents lblFAssetTag As Label
    Friend WithEvents btnNote As Button
    Friend WithEvents btnCompletion As Button
    Friend WithEvents lblMESD As Label
    Friend WithEvents btnShip As Button
End Class
