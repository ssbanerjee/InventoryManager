<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CheckScanner
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
        Me.btnTinyInOne = New System.Windows.Forms.Button()
        Me.btnScanner = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnTinyInOne
        '
        Me.btnTinyInOne.Location = New System.Drawing.Point(116, 13)
        Me.btnTinyInOne.Name = "btnTinyInOne"
        Me.btnTinyInOne.Size = New System.Drawing.Size(75, 23)
        Me.btnTinyInOne.TabIndex = 3
        Me.btnTinyInOne.Text = "Tiny-in-One"
        Me.btnTinyInOne.UseVisualStyleBackColor = True
        '
        'btnScanner
        '
        Me.btnScanner.Location = New System.Drawing.Point(12, 13)
        Me.btnScanner.Name = "btnScanner"
        Me.btnScanner.Size = New System.Drawing.Size(75, 23)
        Me.btnScanner.TabIndex = 2
        Me.btnScanner.Text = "Scanner"
        Me.btnScanner.UseVisualStyleBackColor = True
        '
        'CheckScanner
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(203, 49)
        Me.Controls.Add(Me.btnTinyInOne)
        Me.Controls.Add(Me.btnScanner)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "CheckScanner"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "CheckScanner"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnTinyInOne As Button
    Friend WithEvents btnScanner As Button
End Class
