<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainMenu
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
        Me.btnInvMenu = New System.Windows.Forms.Button()
        Me.btnCntMenu = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnInvMenu
        '
        Me.btnInvMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnInvMenu.Image = Global.InventoryManager.My.Resources.Resources.InventoryManager
        Me.btnInvMenu.Location = New System.Drawing.Point(0, 0)
        Me.btnInvMenu.Name = "btnInvMenu"
        Me.btnInvMenu.Size = New System.Drawing.Size(320, 400)
        Me.btnInvMenu.TabIndex = 0
        Me.btnInvMenu.UseVisualStyleBackColor = True
        '
        'btnCntMenu
        '
        Me.btnCntMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCntMenu.Image = Global.InventoryManager.My.Resources.Resources.CenterDirectory
        Me.btnCntMenu.Location = New System.Drawing.Point(320, 0)
        Me.btnCntMenu.Name = "btnCntMenu"
        Me.btnCntMenu.Size = New System.Drawing.Size(320, 400)
        Me.btnCntMenu.TabIndex = 1
        Me.btnCntMenu.UseVisualStyleBackColor = True
        '
        'MainMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(638, 398)
        Me.Controls.Add(Me.btnCntMenu)
        Me.Controls.Add(Me.btnInvMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "MainMenu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MainMenu"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnInvMenu As Button
    Friend WithEvents btnCntMenu As Button
End Class
