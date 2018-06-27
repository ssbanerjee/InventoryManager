<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CSVMenu
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
        Me.lstMachines = New System.Windows.Forms.ListBox()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnImport = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lstMachines
        '
        Me.lstMachines.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstMachines.FormattingEnabled = True
        Me.lstMachines.ItemHeight = 19
        Me.lstMachines.Location = New System.Drawing.Point(12, 54)
        Me.lstMachines.Name = "lstMachines"
        Me.lstMachines.Size = New System.Drawing.Size(777, 270)
        Me.lstMachines.TabIndex = 0
        '
        'btnExport
        '
        Me.btnExport.Location = New System.Drawing.Point(407, 330)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(382, 146)
        Me.btnExport.TabIndex = 1
        Me.btnExport.Text = "Export to CSV"
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(192, 26)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Changes made today"
        '
        'btnImport
        '
        Me.btnImport.Location = New System.Drawing.Point(12, 330)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(382, 146)
        Me.btnImport.TabIndex = 3
        Me.btnImport.Text = "Import from CSV"
        Me.btnImport.UseVisualStyleBackColor = True
        '
        'CSVMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(801, 488)
        Me.Controls.Add(Me.btnImport)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnExport)
        Me.Controls.Add(Me.lstMachines)
        Me.Name = "CSVMenu"
        Me.Text = "CSVMenu"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lstMachines As ListBox
    Friend WithEvents btnExport As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents btnImport As Button
End Class
