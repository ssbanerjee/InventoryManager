<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AddMachineMenu
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AddMachineMenu))
        Me.btnBack = New System.Windows.Forms.Button()
        Me.pbLaptop = New System.Windows.Forms.PictureBox()
        Me.pbWorkstation = New System.Windows.Forms.PictureBox()
        Me.pbEMV = New System.Windows.Forms.PictureBox()
        Me.pbTablet = New System.Windows.Forms.PictureBox()
        Me.pbCheckScanner = New System.Windows.Forms.PictureBox()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnNext = New System.Windows.Forms.Button()
        CType(Me.pbLaptop, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbWorkstation, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbEMV, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbTablet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbCheckScanner, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnBack
        '
        Me.btnBack.Location = New System.Drawing.Point(12, 1045)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(75, 23)
        Me.btnBack.TabIndex = 0
        Me.btnBack.Text = "Back"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'pbLaptop
        '
        Me.pbLaptop.BackColor = System.Drawing.Color.Transparent
        Me.pbLaptop.Image = Global.InventoryManager.My.Resources.Resources.Laptop
        Me.pbLaptop.Location = New System.Drawing.Point(30, 17)
        Me.pbLaptop.Name = "pbLaptop"
        Me.pbLaptop.Size = New System.Drawing.Size(418, 83)
        Me.pbLaptop.TabIndex = 1
        Me.pbLaptop.TabStop = False
        '
        'pbWorkstation
        '
        Me.pbWorkstation.BackColor = System.Drawing.Color.Transparent
        Me.pbWorkstation.Image = Global.InventoryManager.My.Resources.Resources.Workstation
        Me.pbWorkstation.Location = New System.Drawing.Point(32, 137)
        Me.pbWorkstation.Name = "pbWorkstation"
        Me.pbWorkstation.Size = New System.Drawing.Size(418, 84)
        Me.pbWorkstation.TabIndex = 2
        Me.pbWorkstation.TabStop = False
        '
        'pbEMV
        '
        Me.pbEMV.BackColor = System.Drawing.Color.Transparent
        Me.pbEMV.Image = CType(resources.GetObject("pbEMV.Image"), System.Drawing.Image)
        Me.pbEMV.Location = New System.Drawing.Point(31, 267)
        Me.pbEMV.Name = "pbEMV"
        Me.pbEMV.Size = New System.Drawing.Size(418, 83)
        Me.pbEMV.TabIndex = 3
        Me.pbEMV.TabStop = False
        '
        'pbTablet
        '
        Me.pbTablet.BackColor = System.Drawing.Color.Transparent
        Me.pbTablet.Image = Global.InventoryManager.My.Resources.Resources.Tablet
        Me.pbTablet.Location = New System.Drawing.Point(31, 397)
        Me.pbTablet.Name = "pbTablet"
        Me.pbTablet.Size = New System.Drawing.Size(418, 83)
        Me.pbTablet.TabIndex = 4
        Me.pbTablet.TabStop = False
        '
        'pbCheckScanner
        '
        Me.pbCheckScanner.BackColor = System.Drawing.Color.Transparent
        Me.pbCheckScanner.Image = Global.InventoryManager.My.Resources.Resources.CheckScanner
        Me.pbCheckScanner.Location = New System.Drawing.Point(30, 527)
        Me.pbCheckScanner.Name = "pbCheckScanner"
        Me.pbCheckScanner.Size = New System.Drawing.Size(418, 83)
        Me.pbCheckScanner.TabIndex = 5
        Me.pbCheckScanner.TabStop = False
        '
        'btnExit
        '
        Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExit.Location = New System.Drawing.Point(950, 12)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(38, 23)
        Me.btnExit.TabIndex = 7
        Me.btnExit.Text = "X"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnNext
        '
        Me.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNext.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNext.Location = New System.Drawing.Point(904, 576)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(84, 37)
        Me.btnNext.TabIndex = 8
        Me.btnNext.Text = "→"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'AddMachineMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.InventoryManager.My.Resources.Resources.NewMenu_empty
        Me.ClientSize = New System.Drawing.Size(1000, 625)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.pbCheckScanner)
        Me.Controls.Add(Me.pbTablet)
        Me.Controls.Add(Me.pbEMV)
        Me.Controls.Add(Me.pbWorkstation)
        Me.Controls.Add(Me.pbLaptop)
        Me.Controls.Add(Me.btnBack)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "AddMachineMenu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "AddMachine"
        CType(Me.pbLaptop, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbWorkstation, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbEMV, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbTablet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbCheckScanner, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnBack As Button
    Friend WithEvents pbLaptop As PictureBox
    Friend WithEvents pbWorkstation As PictureBox
    Friend WithEvents pbEMV As PictureBox
    Friend WithEvents pbTablet As PictureBox
    Friend WithEvents pbCheckScanner As PictureBox
    Friend WithEvents btnExit As Button
    Friend WithEvents btnNext As Button
End Class
