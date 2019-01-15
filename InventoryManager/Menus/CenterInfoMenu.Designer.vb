<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CenterInfoMenu
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
        Me.cbCenter = New System.Windows.Forms.ComboBox()
        Me.lblCenter = New System.Windows.Forms.Label()
        Me.lblAddress = New System.Windows.Forms.Label()
        Me.lblRegDist = New System.Windows.Forms.Label()
        Me.lblCircuitInfo = New System.Windows.Forms.Label()
        Me.lblPhoneNumbers = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cbCenter
        '
        Me.cbCenter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbCenter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbCenter.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCenter.FormattingEnabled = True
        Me.cbCenter.Location = New System.Drawing.Point(15, 25)
        Me.cbCenter.Name = "cbCenter"
        Me.cbCenter.Size = New System.Drawing.Size(289, 26)
        Me.cbCenter.TabIndex = 40
        '
        'lblCenter
        '
        Me.lblCenter.AutoSize = True
        Me.lblCenter.Location = New System.Drawing.Point(12, 9)
        Me.lblCenter.Name = "lblCenter"
        Me.lblCenter.Size = New System.Drawing.Size(81, 13)
        Me.lblCenter.TabIndex = 41
        Me.lblCenter.Text = "Center Number:"
        '
        'lblAddress
        '
        Me.lblAddress.AutoSize = True
        Me.lblAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAddress.Location = New System.Drawing.Point(12, 80)
        Me.lblAddress.Name = "lblAddress"
        Me.lblAddress.Size = New System.Drawing.Size(59, 16)
        Me.lblAddress.TabIndex = 42
        Me.lblAddress.Text = "Address"
        '
        'lblRegDist
        '
        Me.lblRegDist.AutoSize = True
        Me.lblRegDist.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegDist.Location = New System.Drawing.Point(12, 125)
        Me.lblRegDist.Name = "lblRegDist"
        Me.lblRegDist.Size = New System.Drawing.Size(102, 16)
        Me.lblRegDist.TabIndex = 43
        Me.lblRegDist.Text = "Region / District"
        '
        'lblCircuitInfo
        '
        Me.lblCircuitInfo.AutoSize = True
        Me.lblCircuitInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCircuitInfo.Location = New System.Drawing.Point(12, 174)
        Me.lblCircuitInfo.Name = "lblCircuitInfo"
        Me.lblCircuitInfo.Size = New System.Drawing.Size(68, 16)
        Me.lblCircuitInfo.TabIndex = 44
        Me.lblCircuitInfo.Text = "Circuit Info"
        '
        'lblPhoneNumbers
        '
        Me.lblPhoneNumbers.AutoSize = True
        Me.lblPhoneNumbers.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPhoneNumbers.Location = New System.Drawing.Point(12, 219)
        Me.lblPhoneNumbers.Name = "lblPhoneNumbers"
        Me.lblPhoneNumbers.Size = New System.Drawing.Size(105, 16)
        Me.lblPhoneNumbers.TabIndex = 45
        Me.lblPhoneNumbers.Text = "Phone Numbers"
        Me.lblPhoneNumbers.Visible = False
        '
        'CenterInfoMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(508, 293)
        Me.Controls.Add(Me.lblPhoneNumbers)
        Me.Controls.Add(Me.lblCircuitInfo)
        Me.Controls.Add(Me.lblRegDist)
        Me.Controls.Add(Me.lblAddress)
        Me.Controls.Add(Me.cbCenter)
        Me.Controls.Add(Me.lblCenter)
        Me.Name = "CenterInfoMenu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "CenterInfoMenu"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cbCenter As ComboBox
    Friend WithEvents lblCenter As Label
    Friend WithEvents lblAddress As Label
    Friend WithEvents lblRegDist As Label
    Friend WithEvents lblCircuitInfo As Label
    Friend WithEvents lblPhoneNumbers As Label
End Class
