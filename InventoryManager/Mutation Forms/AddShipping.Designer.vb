<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddShipping
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
        Me.cbItems = New System.Windows.Forms.ComboBox()
        Me.txtQuantity = New System.Windows.Forms.TextBox()
        Me.cbCenter = New System.Windows.Forms.ComboBox()
        Me.txtMESD = New System.Windows.Forms.TextBox()
        Me.lblItem = New System.Windows.Forms.Label()
        Me.lblQuantity = New System.Windows.Forms.Label()
        Me.lblCenter = New System.Windows.Forms.Label()
        Me.lblMESD = New System.Windows.Forms.Label()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cbItems
        '
        Me.cbItems.FormattingEnabled = True
        Me.cbItems.Location = New System.Drawing.Point(12, 28)
        Me.cbItems.Name = "cbItems"
        Me.cbItems.Size = New System.Drawing.Size(121, 21)
        Me.cbItems.TabIndex = 0
        '
        'txtQuantity
        '
        Me.txtQuantity.Location = New System.Drawing.Point(139, 28)
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.Size = New System.Drawing.Size(46, 20)
        Me.txtQuantity.TabIndex = 1
        '
        'cbCenter
        '
        Me.cbCenter.FormattingEnabled = True
        Me.cbCenter.Location = New System.Drawing.Point(12, 79)
        Me.cbCenter.Name = "cbCenter"
        Me.cbCenter.Size = New System.Drawing.Size(173, 21)
        Me.cbCenter.TabIndex = 2
        '
        'txtMESD
        '
        Me.txtMESD.Location = New System.Drawing.Point(12, 134)
        Me.txtMESD.Name = "txtMESD"
        Me.txtMESD.Size = New System.Drawing.Size(100, 20)
        Me.txtMESD.TabIndex = 3
        '
        'lblItem
        '
        Me.lblItem.AutoSize = True
        Me.lblItem.Location = New System.Drawing.Point(12, 9)
        Me.lblItem.Name = "lblItem"
        Me.lblItem.Size = New System.Drawing.Size(27, 13)
        Me.lblItem.TabIndex = 4
        Me.lblItem.Text = "Item"
        '
        'lblQuantity
        '
        Me.lblQuantity.AutoSize = True
        Me.lblQuantity.Location = New System.Drawing.Point(139, 9)
        Me.lblQuantity.Name = "lblQuantity"
        Me.lblQuantity.Size = New System.Drawing.Size(46, 13)
        Me.lblQuantity.TabIndex = 5
        Me.lblQuantity.Text = "Quantity"
        '
        'lblCenter
        '
        Me.lblCenter.AutoSize = True
        Me.lblCenter.Location = New System.Drawing.Point(12, 63)
        Me.lblCenter.Name = "lblCenter"
        Me.lblCenter.Size = New System.Drawing.Size(38, 13)
        Me.lblCenter.TabIndex = 6
        Me.lblCenter.Text = "Center"
        '
        'lblMESD
        '
        Me.lblMESD.AutoSize = True
        Me.lblMESD.Location = New System.Drawing.Point(9, 118)
        Me.lblMESD.Name = "lblMESD"
        Me.lblMESD.Size = New System.Drawing.Size(38, 13)
        Me.lblMESD.TabIndex = 7
        Me.lblMESD.Text = "MESD"
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(132, 131)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(53, 23)
        Me.btnOK.TabIndex = 8
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'AddShipping
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(208, 173)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.lblMESD)
        Me.Controls.Add(Me.lblCenter)
        Me.Controls.Add(Me.lblQuantity)
        Me.Controls.Add(Me.lblItem)
        Me.Controls.Add(Me.txtMESD)
        Me.Controls.Add(Me.cbCenter)
        Me.Controls.Add(Me.txtQuantity)
        Me.Controls.Add(Me.cbItems)
        Me.Name = "AddShipping"
        Me.Text = "AddShipping"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cbItems As ComboBox
    Friend WithEvents txtQuantity As TextBox
    Friend WithEvents cbCenter As ComboBox
    Friend WithEvents txtMESD As TextBox
    Friend WithEvents lblItem As Label
    Friend WithEvents lblQuantity As Label
    Friend WithEvents lblCenter As Label
    Friend WithEvents lblMESD As Label
    Friend WithEvents btnOK As Button
End Class
