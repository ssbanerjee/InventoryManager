<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainMenu
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
        Me.btnExit = New System.Windows.Forms.Button()
        Me.pbMenu = New System.Windows.Forms.PictureBox()
        Me.pbShipping = New System.Windows.Forms.PictureBox()
        Me.pbReceiving = New System.Windows.Forms.PictureBox()
        CType(Me.pbMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbShipping, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbReceiving, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnExit
        '
        Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExit.Location = New System.Drawing.Point(950, 12)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(38, 23)
        Me.btnExit.TabIndex = 9
        Me.btnExit.Text = "X"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'pbMenu
        '
        Me.pbMenu.BackColor = System.Drawing.Color.Transparent
        Me.pbMenu.Image = Global.InventoryManager.My.Resources.Resources.Inventory
        Me.pbMenu.Location = New System.Drawing.Point(36, 58)
        Me.pbMenu.Name = "pbMenu"
        Me.pbMenu.Size = New System.Drawing.Size(419, 86)
        Me.pbMenu.TabIndex = 10
        Me.pbMenu.TabStop = False
        '
        'pbShipping
        '
        Me.pbShipping.BackColor = System.Drawing.Color.Transparent
        Me.pbShipping.Image = Global.InventoryManager.My.Resources.Resources.Shipping
        Me.pbShipping.Location = New System.Drawing.Point(36, 227)
        Me.pbShipping.Name = "pbShipping"
        Me.pbShipping.Size = New System.Drawing.Size(419, 86)
        Me.pbShipping.TabIndex = 11
        Me.pbShipping.TabStop = False
        '
        'pbReceiving
        '
        Me.pbReceiving.BackColor = System.Drawing.Color.Transparent
        Me.pbReceiving.Image = Global.InventoryManager.My.Resources.Resources.Receiving
        Me.pbReceiving.Location = New System.Drawing.Point(36, 403)
        Me.pbReceiving.Name = "pbReceiving"
        Me.pbReceiving.Size = New System.Drawing.Size(419, 86)
        Me.pbReceiving.TabIndex = 12
        Me.pbReceiving.TabStop = False
        '
        'MainMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.InventoryManager.My.Resources.Resources.NewMenu_empty
        Me.ClientSize = New System.Drawing.Size(1000, 625)
        Me.Controls.Add(Me.pbReceiving)
        Me.Controls.Add(Me.pbShipping)
        Me.Controls.Add(Me.pbMenu)
        Me.Controls.Add(Me.btnExit)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "MainMenu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MainMenu"
        CType(Me.pbMenu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbShipping, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbReceiving, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnExit As Button
    Friend WithEvents pbMenu As PictureBox
    Friend WithEvents pbShipping As PictureBox
    Friend WithEvents pbReceiving As PictureBox
End Class
