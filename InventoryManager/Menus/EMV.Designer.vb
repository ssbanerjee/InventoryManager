<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EMV
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
        Me.btnVeriFone = New System.Windows.Forms.Button()
        Me.btnIngenico = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnVeriFone
        '
        Me.btnVeriFone.Location = New System.Drawing.Point(12, 12)
        Me.btnVeriFone.Name = "btnVeriFone"
        Me.btnVeriFone.Size = New System.Drawing.Size(75, 23)
        Me.btnVeriFone.TabIndex = 0
        Me.btnVeriFone.Text = "VeriFone"
        Me.btnVeriFone.UseVisualStyleBackColor = True
        '
        'btnIngenico
        '
        Me.btnIngenico.Location = New System.Drawing.Point(116, 12)
        Me.btnIngenico.Name = "btnIngenico"
        Me.btnIngenico.Size = New System.Drawing.Size(75, 23)
        Me.btnIngenico.TabIndex = 1
        Me.btnIngenico.Text = "Ingenico"
        Me.btnIngenico.UseVisualStyleBackColor = True
        '
        'EMV
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(203, 49)
        Me.Controls.Add(Me.btnIngenico)
        Me.Controls.Add(Me.btnVeriFone)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "EMV"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "EMV Model"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnVeriFone As Button
    Friend WithEvents btnIngenico As Button
End Class
