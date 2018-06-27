<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Login
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
        Me.txtPIN = New System.Windows.Forms.TextBox()
        Me.tmrInactive = New System.Windows.Forms.Timer(Me.components)
        Me.bgwUpdate = New System.ComponentModel.BackgroundWorker()
        Me.lblUpdate = New System.Windows.Forms.Label()
        Me.tmrUpdateLabel = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'txtPIN
        '
        Me.txtPIN.BackColor = System.Drawing.SystemColors.Control
        Me.txtPIN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtPIN.Font = New System.Drawing.Font("Calibri", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPIN.Location = New System.Drawing.Point(83, 83)
        Me.txtPIN.Name = "txtPIN"
        Me.txtPIN.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9786)
        Me.txtPIN.Size = New System.Drawing.Size(306, 59)
        Me.txtPIN.TabIndex = 0
        Me.txtPIN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tmrInactive
        '
        Me.tmrInactive.Interval = 150000
        '
        'bgwUpdate
        '
        '
        'lblUpdate
        '
        Me.lblUpdate.AutoSize = True
        Me.lblUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUpdate.Location = New System.Drawing.Point(12, 224)
        Me.lblUpdate.Name = "lblUpdate"
        Me.lblUpdate.Size = New System.Drawing.Size(150, 16)
        Me.lblUpdate.TabIndex = 1
        Me.lblUpdate.Text = "Updating Inventory..."
        '
        'tmrUpdateLabel
        '
        Me.tmrUpdateLabel.Enabled = True
        '
        'Login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(488, 249)
        Me.Controls.Add(Me.lblUpdate)
        Me.Controls.Add(Me.txtPIN)
        Me.Name = "Login"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Login"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtPIN As TextBox
    Friend WithEvents tmrInactive As Timer
    Friend WithEvents bgwUpdate As System.ComponentModel.BackgroundWorker
    Friend WithEvents lblUpdate As Label
    Friend WithEvents tmrUpdateLabel As Timer
End Class
