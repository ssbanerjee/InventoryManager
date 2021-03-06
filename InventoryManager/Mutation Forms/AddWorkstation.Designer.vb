﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AddWorkstation
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
        Me.cbModel = New System.Windows.Forms.ComboBox()
        Me.lblModel = New System.Windows.Forms.Label()
        Me.lblSerialNumber = New System.Windows.Forms.Label()
        Me.lblAssetTag = New System.Windows.Forms.Label()
        Me.lblMachineName = New System.Windows.Forms.Label()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.txtSerialNumber = New System.Windows.Forms.TextBox()
        Me.txtAssetTag = New System.Windows.Forms.TextBox()
        Me.txtMachineName = New System.Windows.Forms.TextBox()
        Me.lblCenter = New System.Windows.Forms.Label()
        Me.cbCenter = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCostCenter = New System.Windows.Forms.TextBox()
        Me.txtMESD = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbCondition = New System.Windows.Forms.ComboBox()
        Me.lblCondition = New System.Windows.Forms.Label()
        Me.dteAcquisition = New System.Windows.Forms.DateTimePicker()
        Me.lblAcquisition = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cbModel
        '
        Me.cbModel.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbModel.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbModel.FormattingEnabled = True
        Me.cbModel.Location = New System.Drawing.Point(154, 100)
        Me.cbModel.Name = "cbModel"
        Me.cbModel.Size = New System.Drawing.Size(132, 26)
        Me.cbModel.TabIndex = 2
        '
        'lblModel
        '
        Me.lblModel.AutoSize = True
        Me.lblModel.Location = New System.Drawing.Point(151, 81)
        Me.lblModel.Name = "lblModel"
        Me.lblModel.Size = New System.Drawing.Size(36, 13)
        Me.lblModel.TabIndex = 28
        Me.lblModel.Text = "Model"
        '
        'lblSerialNumber
        '
        Me.lblSerialNumber.AutoSize = True
        Me.lblSerialNumber.Location = New System.Drawing.Point(142, 138)
        Me.lblSerialNumber.Name = "lblSerialNumber"
        Me.lblSerialNumber.Size = New System.Drawing.Size(147, 13)
        Me.lblSerialNumber.TabIndex = 25
        Me.lblSerialNumber.Text = "Serial Number (ex. PFXXXXX)"
        '
        'lblAssetTag
        '
        Me.lblAssetTag.AutoSize = True
        Me.lblAssetTag.Location = New System.Drawing.Point(6, 138)
        Me.lblAssetTag.Name = "lblAssetTag"
        Me.lblAssetTag.Size = New System.Drawing.Size(117, 13)
        Me.lblAssetTag.TabIndex = 24
        Me.lblAssetTag.Text = "Asset Tag (ex: 123456)"
        '
        'lblMachineName
        '
        Me.lblMachineName.AutoSize = True
        Me.lblMachineName.Location = New System.Drawing.Point(6, 81)
        Me.lblMachineName.Name = "lblMachineName"
        Me.lblMachineName.Size = New System.Drawing.Size(139, 13)
        Me.lblMachineName.TabIndex = 23
        Me.lblMachineName.Text = "Machine Name (ex: JDoe-L)"
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(9, 324)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(277, 35)
        Me.btnAdd.TabIndex = 8
        Me.btnAdd.Text = "Add Machine"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'txtSerialNumber
        '
        Me.txtSerialNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSerialNumber.Location = New System.Drawing.Point(145, 157)
        Me.txtSerialNumber.Name = "txtSerialNumber"
        Me.txtSerialNumber.Size = New System.Drawing.Size(141, 26)
        Me.txtSerialNumber.TabIndex = 4
        '
        'txtAssetTag
        '
        Me.txtAssetTag.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAssetTag.Location = New System.Drawing.Point(9, 157)
        Me.txtAssetTag.Name = "txtAssetTag"
        Me.txtAssetTag.Size = New System.Drawing.Size(117, 26)
        Me.txtAssetTag.TabIndex = 3
        '
        'txtMachineName
        '
        Me.txtMachineName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMachineName.Location = New System.Drawing.Point(9, 100)
        Me.txtMachineName.Name = "txtMachineName"
        Me.txtMachineName.Size = New System.Drawing.Size(139, 26)
        Me.txtMachineName.TabIndex = 1
        '
        'lblCenter
        '
        Me.lblCenter.AutoSize = True
        Me.lblCenter.Location = New System.Drawing.Point(6, 25)
        Me.lblCenter.Name = "lblCenter"
        Me.lblCenter.Size = New System.Drawing.Size(81, 13)
        Me.lblCenter.TabIndex = 29
        Me.lblCenter.Text = "Center Number:"
        '
        'cbCenter
        '
        Me.cbCenter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbCenter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbCenter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCenter.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCenter.FormattingEnabled = True
        Me.cbCenter.Location = New System.Drawing.Point(9, 41)
        Me.cbCenter.Name = "cbCenter"
        Me.cbCenter.Size = New System.Drawing.Size(277, 26)
        Me.cbCenter.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 196)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 13)
        Me.Label1.TabIndex = 30
        Me.Label1.Text = "Cost Center / PAR"
        '
        'txtCostCenter
        '
        Me.txtCostCenter.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCostCenter.Location = New System.Drawing.Point(9, 212)
        Me.txtCostCenter.Name = "txtCostCenter"
        Me.txtCostCenter.Size = New System.Drawing.Size(114, 26)
        Me.txtCostCenter.TabIndex = 5
        '
        'txtMESD
        '
        Me.txtMESD.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMESD.Location = New System.Drawing.Point(145, 212)
        Me.txtMESD.Name = "txtMESD"
        Me.txtMESD.Size = New System.Drawing.Size(141, 26)
        Me.txtMESD.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(142, 196)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 50
        Me.Label2.Text = "MESD:"
        '
        'cbCondition
        '
        Me.cbCondition.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbCondition.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCondition.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCondition.FormattingEnabled = True
        Me.cbCondition.Location = New System.Drawing.Point(90, 253)
        Me.cbCondition.Name = "cbCondition"
        Me.cbCondition.Size = New System.Drawing.Size(196, 28)
        Me.cbCondition.TabIndex = 7
        '
        'lblCondition
        '
        Me.lblCondition.AutoSize = True
        Me.lblCondition.Location = New System.Drawing.Point(12, 261)
        Me.lblCondition.Name = "lblCondition"
        Me.lblCondition.Size = New System.Drawing.Size(72, 13)
        Me.lblCondition.TabIndex = 52
        Me.lblCondition.Text = "New or Used:"
        '
        'dteAcquisition
        '
        Me.dteAcquisition.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dteAcquisition.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dteAcquisition.Location = New System.Drawing.Point(90, 294)
        Me.dteAcquisition.MinDate = New Date(2017, 1, 1, 0, 0, 0, 0)
        Me.dteAcquisition.Name = "dteAcquisition"
        Me.dteAcquisition.Size = New System.Drawing.Size(196, 20)
        Me.dteAcquisition.TabIndex = 54
        '
        'lblAcquisition
        '
        Me.lblAcquisition.AutoSize = True
        Me.lblAcquisition.Location = New System.Drawing.Point(12, 301)
        Me.lblAcquisition.Name = "lblAcquisition"
        Me.lblAcquisition.Size = New System.Drawing.Size(61, 13)
        Me.lblAcquisition.TabIndex = 53
        Me.lblAcquisition.Text = "Acquisition:"
        '
        'AddWorkstation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(298, 371)
        Me.Controls.Add(Me.dteAcquisition)
        Me.Controls.Add(Me.lblAcquisition)
        Me.Controls.Add(Me.cbCondition)
        Me.Controls.Add(Me.lblCondition)
        Me.Controls.Add(Me.txtMESD)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtCostCenter)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbCenter)
        Me.Controls.Add(Me.lblCenter)
        Me.Controls.Add(Me.cbModel)
        Me.Controls.Add(Me.lblModel)
        Me.Controls.Add(Me.lblSerialNumber)
        Me.Controls.Add(Me.lblAssetTag)
        Me.Controls.Add(Me.lblMachineName)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.txtSerialNumber)
        Me.Controls.Add(Me.txtAssetTag)
        Me.Controls.Add(Me.txtMachineName)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "AddWorkstation"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Add Workstation"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cbModel As ComboBox
    Friend WithEvents lblModel As Label
    Friend WithEvents lblSerialNumber As Label
    Friend WithEvents lblAssetTag As Label
    Friend WithEvents lblMachineName As Label
    Friend WithEvents btnAdd As Button
    Friend WithEvents txtSerialNumber As TextBox
    Friend WithEvents txtAssetTag As TextBox
    Friend WithEvents txtMachineName As TextBox
    Friend WithEvents lblCenter As Label
    Friend WithEvents cbCenter As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtCostCenter As TextBox
    Friend WithEvents txtMESD As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cbCondition As ComboBox
    Friend WithEvents lblCondition As Label
    Friend WithEvents dteAcquisition As DateTimePicker
    Friend WithEvents lblAcquisition As Label
End Class
