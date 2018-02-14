<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InventoryMenu
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
        Me.btnTransfer = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnAddMachine = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnTransfer
        '
        Me.btnTransfer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTransfer.Image = Global.InventoryManager.My.Resources.Resources.transferData
        Me.btnTransfer.Location = New System.Drawing.Point(0, 720)
        Me.btnTransfer.Name = "btnTransfer"
        Me.btnTransfer.Size = New System.Drawing.Size(1920, 360)
        Me.btnTransfer.TabIndex = 2
        Me.btnTransfer.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEdit.Image = Global.InventoryManager.My.Resources.Resources.editInfo
        Me.btnEdit.Location = New System.Drawing.Point(0, 360)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(1920, 360)
        Me.btnEdit.TabIndex = 1
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnAddMachine
        '
        Me.btnAddMachine.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddMachine.Image = Global.InventoryManager.My.Resources.Resources.addMachine
        Me.btnAddMachine.Location = New System.Drawing.Point(0, 0)
        Me.btnAddMachine.Name = "btnAddMachine"
        Me.btnAddMachine.Size = New System.Drawing.Size(1920, 360)
        Me.btnAddMachine.TabIndex = 0
        Me.btnAddMachine.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.BackColor = System.Drawing.SystemColors.Control
        Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExit.Location = New System.Drawing.Point(12, 1045)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 23)
        Me.btnExit.TabIndex = 3
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'MainMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1920, 1080)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnTransfer)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnAddMachine)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "MainMenu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Main Menu"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnAddMachine As Button
    Friend WithEvents btnEdit As Button
    Friend WithEvents btnTransfer As Button
    Friend WithEvents btnExit As Button
End Class
