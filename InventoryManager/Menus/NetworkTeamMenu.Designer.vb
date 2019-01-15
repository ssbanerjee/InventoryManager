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
        Me.pbAdtran = New System.Windows.Forms.PictureBox()
        Me.pbMojo = New System.Windows.Forms.PictureBox()
        Me.btnExit = New System.Windows.Forms.Button()
        CType(Me.pbAdtran, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbMojo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pbAdtran
        '
        Me.pbAdtran.BackColor = System.Drawing.Color.Transparent
        Me.pbAdtran.Image = Global.InventoryManager.My.Resources.Resources.Adtran
        Me.pbAdtran.Location = New System.Drawing.Point(48, 188)
        Me.pbAdtran.Name = "pbAdtran"
        Me.pbAdtran.Size = New System.Drawing.Size(418, 83)
        Me.pbAdtran.TabIndex = 8
        Me.pbAdtran.TabStop = False
        '
        'pbMojo
        '
        Me.pbMojo.BackColor = System.Drawing.Color.Transparent
        Me.pbMojo.Image = Global.InventoryManager.My.Resources.Resources.MOJO
        Me.pbMojo.Location = New System.Drawing.Point(48, 310)
        Me.pbMojo.Name = "pbMojo"
        Me.pbMojo.Size = New System.Drawing.Size(418, 83)
        Me.pbMojo.TabIndex = 9
        Me.pbMojo.TabStop = False
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
        'NetworkTeamMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.InventoryManager.My.Resources.Resources.NewMenu_empty
        Me.ClientSize = New System.Drawing.Size(1000, 625)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.pbMojo)
        Me.Controls.Add(Me.pbAdtran)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "NetworkTeamMenu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "NetworkTeamMenu"
        CType(Me.pbAdtran, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbMojo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pbAdtran As PictureBox
    Friend WithEvents pbMojo As PictureBox
    Friend WithEvents btnExit As Button
End Class
