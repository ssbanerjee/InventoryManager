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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Login))
        Me.txtPIN = New System.Windows.Forms.TextBox()
        Me.tmrInactive = New System.Windows.Forms.Timer(Me.components)
        Me.bgwUpdate = New System.ComponentModel.BackgroundWorker()
        Me.lblUpdate = New System.Windows.Forms.Label()
        Me.tmrUpdateLabel = New System.Windows.Forms.Timer(Me.components)
        Me.bgwShipping = New System.ComponentModel.BackgroundWorker()
        Me.btnLog = New System.Windows.Forms.Button()
        Me.progressBar = New System.Windows.Forms.ProgressBar()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.btnExit = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtPIN
        '
        Me.txtPIN.BackColor = System.Drawing.SystemColors.Control
        Me.txtPIN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtPIN.Font = New System.Drawing.Font("Calibri", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPIN.Location = New System.Drawing.Point(25, 101)
        Me.txtPIN.Name = "txtPIN"
        Me.txtPIN.PasswordChar = Global.Microsoft.VisualBasic.ChrW(8226)
        Me.txtPIN.Size = New System.Drawing.Size(372, 59)
        Me.txtPIN.TabIndex = 0
        Me.txtPIN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tmrInactive
        '
        Me.tmrInactive.Interval = 300000
        '
        'bgwUpdate
        '
        '
        'lblUpdate
        '
        Me.lblUpdate.AutoSize = True
        Me.lblUpdate.BackColor = System.Drawing.Color.Transparent
        Me.lblUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUpdate.Location = New System.Drawing.Point(-3, 583)
        Me.lblUpdate.Name = "lblUpdate"
        Me.lblUpdate.Size = New System.Drawing.Size(150, 16)
        Me.lblUpdate.TabIndex = 1
        Me.lblUpdate.Text = "Updating Inventory..."
        '
        'tmrUpdateLabel
        '
        Me.tmrUpdateLabel.Enabled = True
        '
        'bgwShipping
        '
        '
        'btnLog
        '
        Me.btnLog.Location = New System.Drawing.Point(346, 576)
        Me.btnLog.Name = "btnLog"
        Me.btnLog.Size = New System.Drawing.Size(75, 23)
        Me.btnLog.TabIndex = 2
        Me.btnLog.Text = "Change Log"
        Me.btnLog.UseVisualStyleBackColor = True
        '
        'progressBar
        '
        Me.progressBar.Location = New System.Drawing.Point(0, 602)
        Me.progressBar.Name = "progressBar"
        Me.progressBar.Size = New System.Drawing.Size(437, 23)
        Me.progressBar.TabIndex = 3
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(428, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(572, 625)
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'lblVersion
        '
        Me.lblVersion.AutoSize = True
        Me.lblVersion.BackColor = System.Drawing.Color.Transparent
        Me.lblVersion.Location = New System.Drawing.Point(949, 602)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(42, 13)
        Me.lblVersion.TabIndex = 5
        Me.lblVersion.Text = "Version"
        '
        'btnExit
        '
        Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExit.Location = New System.Drawing.Point(952, 13)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(38, 23)
        Me.btnExit.TabIndex = 6
        Me.btnExit.Text = "X"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'Login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.InventoryManager.My.Resources.Resources.boards
        Me.ClientSize = New System.Drawing.Size(1000, 625)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.lblVersion)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.progressBar)
        Me.Controls.Add(Me.btnLog)
        Me.Controls.Add(Me.lblUpdate)
        Me.Controls.Add(Me.txtPIN)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Login"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Inventory Manager v3.01.1"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtPIN As TextBox
    Friend WithEvents tmrInactive As Timer
    Friend WithEvents bgwUpdate As System.ComponentModel.BackgroundWorker
    Friend WithEvents lblUpdate As Label
    Friend WithEvents tmrUpdateLabel As Timer
    Friend WithEvents bgwShipping As System.ComponentModel.BackgroundWorker
    Friend WithEvents btnLog As Button
    Friend WithEvents progressBar As ProgressBar
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lblVersion As Label
    Friend WithEvents btnExit As Button
End Class
