<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AdminMenu
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
        Me.btniTellers = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'btniTellers
        '
        Me.btniTellers.Location = New System.Drawing.Point(213, 154)
        Me.btniTellers.Name = "btniTellers"
        Me.btniTellers.Size = New System.Drawing.Size(75, 23)
        Me.btniTellers.TabIndex = 0
        Me.btniTellers.Text = "iTellers"
        Me.btniTellers.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 10
        '
        'AdminMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(511, 365)
        Me.Controls.Add(Me.btniTellers)
        Me.Name = "AdminMenu"
        Me.Text = "AdminMenu"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btniTellers As Button
    Friend WithEvents Timer1 As Timer
End Class
