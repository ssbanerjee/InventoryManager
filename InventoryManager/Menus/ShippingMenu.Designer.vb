<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ShippingMenu
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
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.lstMachines = New System.Windows.Forms.ListBox()
        Me.lstShipping = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(12, 324)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(382, 146)
        Me.btnAdd.TabIndex = 7
        Me.btnAdd.Text = "Add Non-Inventoried Item to Shipping List"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(192, 26)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Changes made today"
        '
        'btnExport
        '
        Me.btnExport.Location = New System.Drawing.Point(407, 324)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(382, 146)
        Me.btnExport.TabIndex = 5
        Me.btnExport.Text = "Export By Date to CSV"
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'lstMachines
        '
        Me.lstMachines.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstMachines.FormattingEnabled = True
        Me.lstMachines.ItemHeight = 19
        Me.lstMachines.Location = New System.Drawing.Point(12, 48)
        Me.lstMachines.Name = "lstMachines"
        Me.lstMachines.Size = New System.Drawing.Size(777, 118)
        Me.lstMachines.TabIndex = 4
        '
        'lstShipping
        '
        Me.lstShipping.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstShipping.FormattingEnabled = True
        Me.lstShipping.ItemHeight = 19
        Me.lstShipping.Location = New System.Drawing.Point(12, 181)
        Me.lstShipping.Name = "lstShipping"
        Me.lstShipping.Size = New System.Drawing.Size(777, 118)
        Me.lstShipping.TabIndex = 8
        '
        'ShippingMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(801, 488)
        Me.Controls.Add(Me.lstShipping)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnExport)
        Me.Controls.Add(Me.lstMachines)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "ShippingMenu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Shipping Menu"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnAdd As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents btnExport As Button
    Friend WithEvents lstMachines As ListBox
    Friend WithEvents lstShipping As ListBox
End Class
