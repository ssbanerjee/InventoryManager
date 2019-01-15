<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Countdown
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
        Me.components = New System.ComponentModel.Container()
        Me.lblTime = New System.Windows.Forms.Label()
        Me.tmrCountdown = New System.Windows.Forms.Timer(Me.components)
        Me.lblText = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblTime
        '
        Me.lblTime.AutoSize = True
        Me.lblTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTime.Location = New System.Drawing.Point(9, 81)
        Me.lblTime.Name = "lblTime"
        Me.lblTime.Size = New System.Drawing.Size(159, 39)
        Me.lblTime.TabIndex = 0
        Me.lblTime.Text = "00:00:00"
        '
        'tmrCountdown
        '
        Me.tmrCountdown.Enabled = True
        Me.tmrCountdown.Interval = 1000
        '
        'lblText
        '
        Me.lblText.AutoSize = True
        Me.lblText.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblText.Location = New System.Drawing.Point(16, 9)
        Me.lblText.Name = "lblText"
        Me.lblText.Size = New System.Drawing.Size(33, 25)
        Me.lblText.TabIndex = 1
        Me.lblText.Text = "..."
        Me.lblText.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Countdown
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(176, 129)
        Me.Controls.Add(Me.lblText)
        Me.Controls.Add(Me.lblTime)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Countdown"
        Me.Text = "Countdown"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblTime As Label
    Friend WithEvents tmrCountdown As Timer
    Friend WithEvents lblText As Label
End Class
