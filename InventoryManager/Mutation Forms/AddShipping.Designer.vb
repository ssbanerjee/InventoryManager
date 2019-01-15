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
        Me.txtQuantity = New System.Windows.Forms.TextBox()
        Me.txtMESD = New System.Windows.Forms.TextBox()
        Me.lblQuantity = New System.Windows.Forms.Label()
        Me.lblCenter = New System.Windows.Forms.Label()
        Me.lblMESD = New System.Windows.Forms.Label()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.cbCenter = New System.Windows.Forms.ComboBox()
        Me.lstItems = New System.Windows.Forms.ListBox()
        Me.lblFCategory = New System.Windows.Forms.Label()
        Me.cbCategory = New System.Windows.Forms.ComboBox()
        Me.txtFilter = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'txtQuantity
        '
        Me.txtQuantity.Location = New System.Drawing.Point(150, 154)
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.Size = New System.Drawing.Size(60, 20)
        Me.txtQuantity.TabIndex = 5
        '
        'txtMESD
        '
        Me.txtMESD.Location = New System.Drawing.Point(23, 154)
        Me.txtMESD.Name = "txtMESD"
        Me.txtMESD.Size = New System.Drawing.Size(100, 20)
        Me.txtMESD.TabIndex = 4
        '
        'lblQuantity
        '
        Me.lblQuantity.AutoSize = True
        Me.lblQuantity.Location = New System.Drawing.Point(150, 138)
        Me.lblQuantity.Name = "lblQuantity"
        Me.lblQuantity.Size = New System.Drawing.Size(46, 13)
        Me.lblQuantity.TabIndex = 5
        Me.lblQuantity.Text = "Quantity"
        '
        'lblCenter
        '
        Me.lblCenter.AutoSize = True
        Me.lblCenter.Location = New System.Drawing.Point(23, 83)
        Me.lblCenter.Name = "lblCenter"
        Me.lblCenter.Size = New System.Drawing.Size(38, 13)
        Me.lblCenter.TabIndex = 6
        Me.lblCenter.Text = "Center"
        '
        'lblMESD
        '
        Me.lblMESD.AutoSize = True
        Me.lblMESD.Location = New System.Drawing.Point(20, 138)
        Me.lblMESD.Name = "lblMESD"
        Me.lblMESD.Size = New System.Drawing.Size(38, 13)
        Me.lblMESD.TabIndex = 7
        Me.lblMESD.Text = "MESD"
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(23, 195)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(187, 42)
        Me.btnOK.TabIndex = 6
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'cbCenter
        '
        Me.cbCenter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbCenter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbCenter.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCenter.FormattingEnabled = True
        Me.cbCenter.Location = New System.Drawing.Point(23, 99)
        Me.cbCenter.Name = "cbCenter"
        Me.cbCenter.Size = New System.Drawing.Size(187, 21)
        Me.cbCenter.TabIndex = 3
        '
        'lstItems
        '
        Me.lstItems.FormattingEnabled = True
        Me.lstItems.Location = New System.Drawing.Point(245, 64)
        Me.lstItems.Name = "lstItems"
        Me.lstItems.Size = New System.Drawing.Size(158, 173)
        Me.lstItems.TabIndex = 2
        '
        'lblFCategory
        '
        Me.lblFCategory.AutoSize = True
        Me.lblFCategory.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFCategory.Location = New System.Drawing.Point(23, 28)
        Me.lblFCategory.Name = "lblFCategory"
        Me.lblFCategory.Size = New System.Drawing.Size(55, 15)
        Me.lblFCategory.TabIndex = 10
        Me.lblFCategory.Text = "Category"
        '
        'cbCategory
        '
        Me.cbCategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbCategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbCategory.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCategory.FormattingEnabled = True
        Me.cbCategory.Location = New System.Drawing.Point(26, 44)
        Me.cbCategory.Name = "cbCategory"
        Me.cbCategory.Size = New System.Drawing.Size(184, 23)
        Me.cbCategory.TabIndex = 1
        '
        'txtFilter
        '
        Me.txtFilter.Location = New System.Drawing.Point(245, 28)
        Me.txtFilter.Name = "txtFilter"
        Me.txtFilter.Size = New System.Drawing.Size(158, 20)
        Me.txtFilter.TabIndex = 11
        Me.txtFilter.TabStop = False
        '
        'AddShipping
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(426, 256)
        Me.Controls.Add(Me.txtFilter)
        Me.Controls.Add(Me.lblFCategory)
        Me.Controls.Add(Me.cbCategory)
        Me.Controls.Add(Me.lstItems)
        Me.Controls.Add(Me.cbCenter)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.lblMESD)
        Me.Controls.Add(Me.lblCenter)
        Me.Controls.Add(Me.lblQuantity)
        Me.Controls.Add(Me.txtMESD)
        Me.Controls.Add(Me.txtQuantity)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "AddShipping"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "AddShipping"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtQuantity As TextBox
    Friend WithEvents txtMESD As TextBox
    Friend WithEvents lblQuantity As Label
    Friend WithEvents lblCenter As Label
    Friend WithEvents lblMESD As Label
    Friend WithEvents btnOK As Button
    Friend WithEvents cbCenter As ComboBox
    Friend WithEvents lstItems As ListBox
    Friend WithEvents lblFCategory As Label
    Friend WithEvents cbCategory As ComboBox
    Friend WithEvents txtFilter As TextBox
End Class
