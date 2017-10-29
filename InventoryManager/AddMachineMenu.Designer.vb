<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddMachineMenu
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
        Me.btnBack = New System.Windows.Forms.Button()
        Me.btnLaptop = New System.Windows.Forms.Button()
        Me.btnWorkstation = New System.Windows.Forms.Button()
        Me.btnEMV = New System.Windows.Forms.Button()
        Me.btnOther = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnBack
        '
        Me.btnBack.Location = New System.Drawing.Point(12, 1045)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(75, 23)
        Me.btnBack.TabIndex = 0
        Me.btnBack.Text = "Back"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'btnLaptop
        '
        Me.btnLaptop.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLaptop.Image = Global.InventoryManager.My.Resources.Resources.laptop
        Me.btnLaptop.Location = New System.Drawing.Point(0, 0)
        Me.btnLaptop.Name = "btnLaptop"
        Me.btnLaptop.Size = New System.Drawing.Size(960, 540)
        Me.btnLaptop.TabIndex = 1
        Me.btnLaptop.UseVisualStyleBackColor = True
        '
        'btnWorkstation
        '
        Me.btnWorkstation.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnWorkstation.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnWorkstation.Image = Global.InventoryManager.My.Resources.Resources.workstation
        Me.btnWorkstation.Location = New System.Drawing.Point(960, 0)
        Me.btnWorkstation.Name = "btnWorkstation"
        Me.btnWorkstation.Size = New System.Drawing.Size(960, 540)
        Me.btnWorkstation.TabIndex = 2
        Me.btnWorkstation.UseVisualStyleBackColor = True
        '
        'btnEMV
        '
        Me.btnEMV.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnEMV.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEMV.Image = Global.InventoryManager.My.Resources.Resources.EMV
        Me.btnEMV.Location = New System.Drawing.Point(0, 540)
        Me.btnEMV.Name = "btnEMV"
        Me.btnEMV.Size = New System.Drawing.Size(960, 540)
        Me.btnEMV.TabIndex = 3
        Me.btnEMV.UseVisualStyleBackColor = True
        '
        'btnOther
        '
        Me.btnOther.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOther.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOther.Image = Global.InventoryManager.My.Resources.Resources.other
        Me.btnOther.Location = New System.Drawing.Point(960, 540)
        Me.btnOther.Name = "btnOther"
        Me.btnOther.Size = New System.Drawing.Size(960, 540)
        Me.btnOther.TabIndex = 4
        Me.btnOther.UseVisualStyleBackColor = True
        '
        'AddMachineMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1920, 1080)
        Me.Controls.Add(Me.btnOther)
        Me.Controls.Add(Me.btnWorkstation)
        Me.Controls.Add(Me.btnLaptop)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.btnEMV)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "AddMachineMenu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AddMachine"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnBack As Button
    Friend WithEvents btnLaptop As Button
    Friend WithEvents btnWorkstation As Button
    Friend WithEvents btnEMV As Button
    Friend WithEvents btnOther As Button
End Class
