<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NetworkTeamMenu
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
        Me.btnExit = New System.Windows.Forms.Button()
        Me.pbMojo = New System.Windows.Forms.PictureBox()
        Me.pbSwitch = New System.Windows.Forms.PictureBox()
        Me.pbPhone = New System.Windows.Forms.PictureBox()
        CType(Me.pbMojo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbSwitch, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbPhone, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnExit
        '
        Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExit.Location = New System.Drawing.Point(950, 12)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(38, 23)
        Me.btnExit.TabIndex = 10
        Me.btnExit.Text = "X"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'pbMojo
        '
        Me.pbMojo.BackColor = System.Drawing.Color.Transparent
        Me.pbMojo.Image = Global.InventoryManager.My.Resources.Resources.MOJO
        Me.pbMojo.Location = New System.Drawing.Point(47, 232)
        Me.pbMojo.Name = "pbMojo"
        Me.pbMojo.Size = New System.Drawing.Size(418, 82)
        Me.pbMojo.TabIndex = 9
        Me.pbMojo.TabStop = False
        '
        'pbSwitch
        '
        Me.pbSwitch.BackColor = System.Drawing.Color.Transparent
        Me.pbSwitch.Image = Global.InventoryManager.My.Resources.Resources.Switch
        Me.pbSwitch.Location = New System.Drawing.Point(47, 88)
        Me.pbSwitch.Name = "pbSwitch"
        Me.pbSwitch.Size = New System.Drawing.Size(418, 82)
        Me.pbSwitch.TabIndex = 8
        Me.pbSwitch.TabStop = False
        '
        'pbPhone
        '
        Me.pbPhone.BackColor = System.Drawing.Color.Transparent
        Me.pbPhone.Image = Global.InventoryManager.My.Resources.Resources.Phone
        Me.pbPhone.Location = New System.Drawing.Point(47, 376)
        Me.pbPhone.Name = "pbPhone"
        Me.pbPhone.Size = New System.Drawing.Size(418, 82)
        Me.pbPhone.TabIndex = 11
        Me.pbPhone.TabStop = False
        '
        'NetworkTeamMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.InventoryManager.My.Resources.Resources.NewMenu_empty
        Me.ClientSize = New System.Drawing.Size(1000, 625)
        Me.Controls.Add(Me.pbPhone)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.pbMojo)
        Me.Controls.Add(Me.pbSwitch)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "NetworkTeamMenu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "NetworkTeamMenu"
        CType(Me.pbMojo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbSwitch, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbPhone, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnExit As Button
    Friend WithEvents pbMojo As PictureBox
    Friend WithEvents pbSwitch As PictureBox
    Friend WithEvents pbPhone As PictureBox
End Class
