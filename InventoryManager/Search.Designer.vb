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
        Me.gbSearchOptions.SuspendLayout()
        Me.gbListOptions.SuspendLayout()
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
        Me.gbSearchOptions.Location = New System.Drawing.Point(41, 42)
        Me.gbSearchOptions.Name = "gbSearchOptions"
        Me.gbSearchOptions.Size = New System.Drawing.Size(286, 72)
        Me.gbSearchOptions.TabIndex = 3
        Me.gbSearchOptions.TabStop = False
        Me.gbSearchOptions.Text = "Search By:"
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(41, 152)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(100, 20)
        Me.txtSearch.TabIndex = 4
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(41, 210)
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
        Me.lstMachines.Location = New System.Drawing.Point(555, 68)
        Me.lstMachines.Name = "lstMachines"
        Me.lstMachines.Size = New System.Drawing.Size(285, 354)
        Me.lstMachines.TabIndex = 6
        '
        'txtFilter
        '
        Me.txtFilter.Location = New System.Drawing.Point(555, 42)
        Me.txtFilter.Name = "txtFilter"
        Me.txtFilter.Size = New System.Drawing.Size(285, 20)
        Me.txtFilter.TabIndex = 7
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(555, 489)
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
        Me.Splitter1.Size = New System.Drawing.Size(3, 563)
        Me.Splitter1.TabIndex = 9
        Me.Splitter1.TabStop = False
        '
        'Splitter2
        '
        Me.Splitter2.Location = New System.Drawing.Point(3, 0)
        Me.Splitter2.Name = "Splitter2"
        Me.Splitter2.Size = New System.Drawing.Size(3, 563)
        Me.Splitter2.TabIndex = 10
        Me.Splitter2.TabStop = False
        '
        'gbListOptions
        '
        Me.gbListOptions.Controls.Add(Me.rdListSerialNumbers)
        Me.gbListOptions.Controls.Add(Me.rdListMachineNames)
        Me.gbListOptions.Location = New System.Drawing.Point(555, 428)
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
        'Search
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(869, 563)
        Me.Controls.Add(Me.gbListOptions)
        Me.Controls.Add(Me.Splitter2)
        Me.Controls.Add(Me.Splitter1)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.txtFilter)
        Me.Controls.Add(Me.lstMachines)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.gbSearchOptions)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Search"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Search"
        Me.gbSearchOptions.ResumeLayout(False)
        Me.gbSearchOptions.PerformLayout()
        Me.gbListOptions.ResumeLayout(False)
        Me.gbListOptions.PerformLayout()
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
End Class
