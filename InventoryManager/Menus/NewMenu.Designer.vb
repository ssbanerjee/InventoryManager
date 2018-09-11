<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class NewMenu
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
        Me.pbAddMachine = New System.Windows.Forms.PictureBox()
        Me.pbEditInfo = New System.Windows.Forms.PictureBox()
        Me.pbCenterInfo = New System.Windows.Forms.PictureBox()
        Me.pbShippingReport = New System.Windows.Forms.PictureBox()
        Me.pbQueryBuilder = New System.Windows.Forms.PictureBox()
        CType(Me.pbAddMachine, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbEditInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbCenterInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbShippingReport, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbQueryBuilder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pbAddMachine
        '
        Me.pbAddMachine.BackColor = System.Drawing.Color.Transparent
        Me.pbAddMachine.Image = Global.InventoryManager.My.Resources.Resources.AddMachine_2
        Me.pbAddMachine.Location = New System.Drawing.Point(32, 18)
        Me.pbAddMachine.Name = "pbAddMachine"
        Me.pbAddMachine.Size = New System.Drawing.Size(419, 86)
        Me.pbAddMachine.TabIndex = 0
        Me.pbAddMachine.TabStop = False
        '
        'pbEditInfo
        '
        Me.pbEditInfo.BackColor = System.Drawing.Color.Transparent
        Me.pbEditInfo.Image = Global.InventoryManager.My.Resources.Resources.EditInformation
        Me.pbEditInfo.Location = New System.Drawing.Point(32, 137)
        Me.pbEditInfo.Name = "pbEditInfo"
        Me.pbEditInfo.Size = New System.Drawing.Size(419, 86)
        Me.pbEditInfo.TabIndex = 1
        Me.pbEditInfo.TabStop = False
        '
        'pbCenterInfo
        '
        Me.pbCenterInfo.BackColor = System.Drawing.Color.Transparent
        Me.pbCenterInfo.Image = Global.InventoryManager.My.Resources.Resources.CenterInfo
        Me.pbCenterInfo.Location = New System.Drawing.Point(34, 397)
        Me.pbCenterInfo.Name = "pbCenterInfo"
        Me.pbCenterInfo.Size = New System.Drawing.Size(419, 86)
        Me.pbCenterInfo.TabIndex = 3
        Me.pbCenterInfo.TabStop = False
        '
        'pbShippingReport
        '
        Me.pbShippingReport.BackColor = System.Drawing.Color.Transparent
        Me.pbShippingReport.Image = Global.InventoryManager.My.Resources.Resources.ShippingReport
        Me.pbShippingReport.Location = New System.Drawing.Point(34, 267)
        Me.pbShippingReport.Name = "pbShippingReport"
        Me.pbShippingReport.Size = New System.Drawing.Size(419, 86)
        Me.pbShippingReport.TabIndex = 4
        Me.pbShippingReport.TabStop = False
        '
        'pbQueryBuilder
        '
        Me.pbQueryBuilder.BackColor = System.Drawing.Color.Transparent
        Me.pbQueryBuilder.Image = Global.InventoryManager.My.Resources.Resources.QueryBuilder_2
        Me.pbQueryBuilder.Location = New System.Drawing.Point(32, 527)
        Me.pbQueryBuilder.Name = "pbQueryBuilder"
        Me.pbQueryBuilder.Size = New System.Drawing.Size(419, 86)
        Me.pbQueryBuilder.TabIndex = 5
        Me.pbQueryBuilder.TabStop = False
        '
        'NewMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.InventoryManager.My.Resources.Resources.NewMenu
        Me.ClientSize = New System.Drawing.Size(1000, 625)
        Me.Controls.Add(Me.pbQueryBuilder)
        Me.Controls.Add(Me.pbShippingReport)
        Me.Controls.Add(Me.pbCenterInfo)
        Me.Controls.Add(Me.pbEditInfo)
        Me.Controls.Add(Me.pbAddMachine)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "NewMenu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Inventory Manager"
        CType(Me.pbAddMachine, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbEditInfo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbCenterInfo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbShippingReport, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbQueryBuilder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pbAddMachine As PictureBox
    Friend WithEvents pbEditInfo As PictureBox
    Friend WithEvents pbCenterInfo As PictureBox
    Friend WithEvents pbShippingReport As PictureBox
    Friend WithEvents pbQueryBuilder As PictureBox
End Class
