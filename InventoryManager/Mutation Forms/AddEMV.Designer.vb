<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AddEMV
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
        Me.components = New System.ComponentModel.Container()
        Me.lblSerialNumber = New System.Windows.Forms.Label()
        Me.lblAssetTag = New System.Windows.Forms.Label()
        Me.txtSerialNumber = New System.Windows.Forms.TextBox()
        Me.txtAssetTag = New System.Windows.Forms.TextBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cbCenter = New System.Windows.Forms.ComboBox()
        Me.lblCenter = New System.Windows.Forms.Label()
        Me.txtCostCenter = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.pbEMV = New System.Windows.Forms.PictureBox()
        Me.txtMESD = New System.Windows.Forms.TextBox()
        Me.lblMESD = New System.Windows.Forms.Label()
        Me.cbCondition = New System.Windows.Forms.ComboBox()
        Me.lblCondition = New System.Windows.Forms.Label()
        CType(Me.pbEMV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblSerialNumber
        '
        Me.lblSerialNumber.AutoSize = True
        Me.lblSerialNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSerialNumber.Location = New System.Drawing.Point(23, 12)
        Me.lblSerialNumber.Name = "lblSerialNumber"
        Me.lblSerialNumber.Size = New System.Drawing.Size(109, 20)
        Me.lblSerialNumber.TabIndex = 2
        Me.lblSerialNumber.Text = "Serial Number"
        '
        'lblAssetTag
        '
        Me.lblAssetTag.AutoSize = True
        Me.lblAssetTag.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAssetTag.Location = New System.Drawing.Point(24, 83)
        Me.lblAssetTag.Name = "lblAssetTag"
        Me.lblAssetTag.Size = New System.Drawing.Size(81, 20)
        Me.lblAssetTag.TabIndex = 3
        Me.lblAssetTag.Text = "Asset Tag"
        '
        'txtSerialNumber
        '
        Me.txtSerialNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSerialNumber.Location = New System.Drawing.Point(27, 35)
        Me.txtSerialNumber.Name = "txtSerialNumber"
        Me.txtSerialNumber.Size = New System.Drawing.Size(147, 26)
        Me.txtSerialNumber.TabIndex = 0
        '
        'txtAssetTag
        '
        Me.txtAssetTag.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAssetTag.Location = New System.Drawing.Point(27, 106)
        Me.txtAssetTag.Name = "txtAssetTag"
        Me.txtAssetTag.Size = New System.Drawing.Size(147, 26)
        Me.txtAssetTag.TabIndex = 1
        '
        'cbCenter
        '
        Me.cbCenter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbCenter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbCenter.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCenter.FormattingEnabled = True
        Me.cbCenter.Location = New System.Drawing.Point(27, 182)
        Me.cbCenter.Name = "cbCenter"
        Me.cbCenter.Size = New System.Drawing.Size(147, 26)
        Me.cbCenter.TabIndex = 2
        '
        'lblCenter
        '
        Me.lblCenter.AutoSize = True
        Me.lblCenter.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCenter.Location = New System.Drawing.Point(24, 159)
        Me.lblCenter.Name = "lblCenter"
        Me.lblCenter.Size = New System.Drawing.Size(121, 20)
        Me.lblCenter.TabIndex = 31
        Me.lblCenter.Text = "Center Number:"
        '
        'txtCostCenter
        '
        Me.txtCostCenter.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCostCenter.Location = New System.Drawing.Point(26, 250)
        Me.txtCostCenter.Name = "txtCostCenter"
        Me.txtCostCenter.Size = New System.Drawing.Size(145, 26)
        Me.txtCostCenter.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(22, 227)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 20)
        Me.Label1.TabIndex = 33
        Me.Label1.Text = "Cost Center"
        '
        'btnAdd
        '
        Me.btnAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Location = New System.Drawing.Point(12, 427)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(693, 51)
        Me.btnAdd.TabIndex = 6
        Me.btnAdd.Text = "Save"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'pbEMV
        '
        Me.pbEMV.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pbEMV.Image = Global.InventoryManager.My.Resources.Resources.EMV_Base
        Me.pbEMV.Location = New System.Drawing.Point(210, 12)
        Me.pbEMV.Name = "pbEMV"
        Me.pbEMV.Size = New System.Drawing.Size(495, 400)
        Me.pbEMV.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbEMV.TabIndex = 0
        Me.pbEMV.TabStop = False
        '
        'txtMESD
        '
        Me.txtMESD.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMESD.Location = New System.Drawing.Point(27, 320)
        Me.txtMESD.Name = "txtMESD"
        Me.txtMESD.Size = New System.Drawing.Size(147, 26)
        Me.txtMESD.TabIndex = 4
        '
        'lblMESD
        '
        Me.lblMESD.AutoSize = True
        Me.lblMESD.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMESD.Location = New System.Drawing.Point(24, 297)
        Me.lblMESD.Name = "lblMESD"
        Me.lblMESD.Size = New System.Drawing.Size(56, 20)
        Me.lblMESD.TabIndex = 37
        Me.lblMESD.Text = "MESD"
        '
        'cbCondition
        '
        Me.cbCondition.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbCondition.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbCondition.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCondition.FormattingEnabled = True
        Me.cbCondition.Location = New System.Drawing.Point(26, 384)
        Me.cbCondition.Name = "cbCondition"
        Me.cbCondition.Size = New System.Drawing.Size(145, 28)
        Me.cbCondition.TabIndex = 5
        '
        'lblCondition
        '
        Me.lblCondition.AutoSize = True
        Me.lblCondition.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCondition.Location = New System.Drawing.Point(24, 361)
        Me.lblCondition.Name = "lblCondition"
        Me.lblCondition.Size = New System.Drawing.Size(104, 20)
        Me.lblCondition.TabIndex = 52
        Me.lblCondition.Text = "New or Used:"
        '
        'AddEMV
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(717, 490)
        Me.Controls.Add(Me.cbCondition)
        Me.Controls.Add(Me.lblCondition)
        Me.Controls.Add(Me.txtMESD)
        Me.Controls.Add(Me.lblMESD)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.txtCostCenter)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbCenter)
        Me.Controls.Add(Me.lblCenter)
        Me.Controls.Add(Me.txtAssetTag)
        Me.Controls.Add(Me.txtSerialNumber)
        Me.Controls.Add(Me.lblAssetTag)
        Me.Controls.Add(Me.lblSerialNumber)
        Me.Controls.Add(Me.pbEMV)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "AddEMV"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AddEMV"
        CType(Me.pbEMV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pbEMV As PictureBox
    Friend WithEvents lblSerialNumber As Label
    Friend WithEvents lblAssetTag As Label
    Friend WithEvents txtSerialNumber As TextBox
    Friend WithEvents txtAssetTag As TextBox
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents cbCenter As ComboBox
    Friend WithEvents lblCenter As Label
    Friend WithEvents txtCostCenter As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnAdd As Button
    Friend WithEvents txtMESD As TextBox
    Friend WithEvents lblMESD As Label
    Friend WithEvents cbCondition As ComboBox
    Friend WithEvents lblCondition As Label
End Class
