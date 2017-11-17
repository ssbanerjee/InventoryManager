<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Search
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
        Me.rdAssetTag = New System.Windows.Forms.RadioButton()
        Me.rdMachineName = New System.Windows.Forms.RadioButton()
        Me.rdSerialNumber = New System.Windows.Forms.RadioButton()
        Me.gbSearchOptions = New System.Windows.Forms.GroupBox()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.lstMachines = New System.Windows.Forms.ListBox()
        Me.txtFilter = New System.Windows.Forms.TextBox()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.Splitter2 = New System.Windows.Forms.Splitter()
        Me.gbListOptions = New System.Windows.Forms.GroupBox()
        Me.rdListSerialNumbers = New System.Windows.Forms.RadioButton()
        Me.rdListMachineNames = New System.Windows.Forms.RadioButton()
        Me.gbMachine = New System.Windows.Forms.GroupBox()
        Me.lblTechnician = New System.Windows.Forms.Label()
        Me.lblLastModified = New System.Windows.Forms.Label()
        Me.lblSiteUser = New System.Windows.Forms.Label()
        Me.lblCatModel = New System.Windows.Forms.Label()
        Me.lblSerialNumber = New System.Windows.Forms.Label()
        Me.lblAssetTag = New System.Windows.Forms.Label()
        Me.lblMachineName = New System.Windows.Forms.Label()
        Me.lblSim = New System.Windows.Forms.Label()
        Me.lblIMEI = New System.Windows.Forms.Label()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.gbSearchOptions.SuspendLayout()
        Me.gbListOptions.SuspendLayout()
        Me.gbMachine.SuspendLayout()
        Me.SuspendLayout()
        '
        'rdAssetTag
        '
        Me.rdAssetTag.AutoSize = True
        Me.rdAssetTag.Location = New System.Drawing.Point(8, 35)
        Me.rdAssetTag.Name = "rdAssetTag"
        Me.rdAssetTag.Size = New System.Drawing.Size(73, 17)
        Me.rdAssetTag.TabIndex = 0
        Me.rdAssetTag.TabStop = True
        Me.rdAssetTag.Text = "Asset Tag"
        Me.rdAssetTag.UseVisualStyleBackColor = True
        '
        'rdMachineName
        '
        Me.rdMachineName.AutoSize = True
        Me.rdMachineName.Location = New System.Drawing.Point(87, 35)
        Me.rdMachineName.Name = "rdMachineName"
        Me.rdMachineName.Size = New System.Drawing.Size(97, 17)
        Me.rdMachineName.TabIndex = 1
        Me.rdMachineName.TabStop = True
        Me.rdMachineName.Text = "Machine Name"
        Me.rdMachineName.UseVisualStyleBackColor = True
        '
        'rdSerialNumber
        '
        Me.rdSerialNumber.AutoSize = True
        Me.rdSerialNumber.Location = New System.Drawing.Point(190, 35)
        Me.rdSerialNumber.Name = "rdSerialNumber"
        Me.rdSerialNumber.Size = New System.Drawing.Size(91, 17)
        Me.rdSerialNumber.TabIndex = 2
        Me.rdSerialNumber.TabStop = True
        Me.rdSerialNumber.Text = "Serial Number"
        Me.rdSerialNumber.UseVisualStyleBackColor = True
        '
        'gbSearchOptions
        '
        Me.gbSearchOptions.Controls.Add(Me.rdAssetTag)
        Me.gbSearchOptions.Controls.Add(Me.rdSerialNumber)
        Me.gbSearchOptions.Controls.Add(Me.rdMachineName)
        Me.gbSearchOptions.Location = New System.Drawing.Point(27, 29)
        Me.gbSearchOptions.Name = "gbSearchOptions"
        Me.gbSearchOptions.Size = New System.Drawing.Size(286, 72)
        Me.gbSearchOptions.TabIndex = 3
        Me.gbSearchOptions.TabStop = False
        Me.gbSearchOptions.Text = "Search By:"
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(27, 116)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(100, 20)
        Me.txtSearch.TabIndex = 4
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(26, 151)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 23)
        Me.btnSearch.TabIndex = 5
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
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
        Me.btnRefresh.Location = New System.Drawing.Point(432, 437)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(75, 23)
        Me.btnRefresh.TabIndex = 8
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'Splitter1
        '
        Me.Splitter1.Location = New System.Drawing.Point(0, 0)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(3, 478)
        Me.Splitter1.TabIndex = 9
        Me.Splitter1.TabStop = False
        '
        'Splitter2
        '
        Me.Splitter2.Location = New System.Drawing.Point(3, 0)
        Me.Splitter2.Name = "Splitter2"
        Me.Splitter2.Size = New System.Drawing.Size(3, 478)
        Me.Splitter2.TabIndex = 10
        Me.Splitter2.TabStop = False
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
        Me.gbMachine.Controls.Add(Me.btnEdit)
        Me.gbMachine.Controls.Add(Me.lblIMEI)
        Me.gbMachine.Controls.Add(Me.lblSim)
        Me.gbMachine.Controls.Add(Me.lblTechnician)
        Me.gbMachine.Controls.Add(Me.lblLastModified)
        Me.gbMachine.Controls.Add(Me.lblSiteUser)
        Me.gbMachine.Controls.Add(Me.lblCatModel)
        Me.gbMachine.Controls.Add(Me.lblSerialNumber)
        Me.gbMachine.Controls.Add(Me.lblAssetTag)
        Me.gbMachine.Controls.Add(Me.lblMachineName)
        Me.gbMachine.Location = New System.Drawing.Point(27, 200)
        Me.gbMachine.Name = "gbMachine"
        Me.gbMachine.Size = New System.Drawing.Size(373, 260)
        Me.gbMachine.TabIndex = 12
        Me.gbMachine.TabStop = False
        '
        'lblTechnician
        '
        Me.lblTechnician.AutoSize = True
        Me.lblTechnician.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTechnician.Location = New System.Drawing.Point(9, 215)
        Me.lblTechnician.Name = "lblTechnician"
        Me.lblTechnician.Size = New System.Drawing.Size(189, 15)
        Me.lblTechnician.TabIndex = 6
        Me.lblTechnician.Text = "Technician who created machine:"
        '
        'lblLastModified
        '
        Me.lblLastModified.AutoSize = True
        Me.lblLastModified.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLastModified.Location = New System.Drawing.Point(9, 196)
        Me.lblLastModified.Name = "lblLastModified"
        Me.lblLastModified.Size = New System.Drawing.Size(84, 15)
        Me.lblLastModified.TabIndex = 5
        Me.lblLastModified.Text = "Last Modified:"
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
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(269, 231)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(98, 23)
        Me.btnEdit.TabIndex = 9
        Me.btnEdit.Text = "Edit Information"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'Search
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(736, 478)
        Me.Controls.Add(Me.gbMachine)
        Me.Controls.Add(Me.gbListOptions)
        Me.Controls.Add(Me.Splitter2)
        Me.Controls.Add(Me.Splitter1)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.txtFilter)
        Me.Controls.Add(Me.lstMachines)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.gbSearchOptions)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "Search"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
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

    Friend WithEvents rdAssetTag As RadioButton
    Friend WithEvents rdMachineName As RadioButton
    Friend WithEvents rdSerialNumber As RadioButton
    Friend WithEvents gbSearchOptions As GroupBox
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents btnSearch As Button
    Friend WithEvents lstMachines As ListBox
    Friend WithEvents txtFilter As TextBox
    Friend WithEvents btnRefresh As Button
    Friend WithEvents Splitter1 As Splitter
    Friend WithEvents Splitter2 As Splitter
    Friend WithEvents gbListOptions As GroupBox
    Friend WithEvents rdListSerialNumbers As RadioButton
    Friend WithEvents rdListMachineNames As RadioButton
    Friend WithEvents gbMachine As GroupBox
    Friend WithEvents lblMachineName As Label
    Friend WithEvents lblTechnician As Label
    Friend WithEvents lblLastModified As Label
    Friend WithEvents lblSiteUser As Label
    Friend WithEvents lblCatModel As Label
    Friend WithEvents lblSerialNumber As Label
    Friend WithEvents lblAssetTag As Label
    Friend WithEvents lblIMEI As Label
    Friend WithEvents lblSim As Label
    Friend WithEvents btnEdit As Button
End Class
