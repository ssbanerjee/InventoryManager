<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Search
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
        Me.rdAssetTag = New System.Windows.Forms.RadioButton()
        Me.rdMachineName = New System.Windows.Forms.RadioButton()
        Me.rdSerialNumber = New System.Windows.Forms.RadioButton()
        Me.gbSearchOptions = New System.Windows.Forms.GroupBox()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.gbSearchOptions.SuspendLayout()
        Me.SuspendLayout()
        '
        'rdAssetTag
        '
        Me.rdAssetTag.AutoSize = True
        Me.rdAssetTag.Location = New System.Drawing.Point(8, 35)
        Me.rdAssetTag.Name = "rdAssetTag"
        Me.rdAssetTag.Size = New System.Drawing.Size(73, 17)
        Me.rdAssetTag.TabIndex = 0
        Me.rdAssetTag.TabStop = True
        Me.rdAssetTag.Text = "Asset Tag"
        Me.rdAssetTag.UseVisualStyleBackColor = True
        '
        'rdMachineName
        '
        Me.rdMachineName.AutoSize = True
        Me.rdMachineName.Location = New System.Drawing.Point(87, 35)
        Me.rdMachineName.Name = "rdMachineName"
        Me.rdMachineName.Size = New System.Drawing.Size(97, 17)
        Me.rdMachineName.TabIndex = 1
        Me.rdMachineName.TabStop = True
        Me.rdMachineName.Text = "Machine Name"
        Me.rdMachineName.UseVisualStyleBackColor = True
        '
        'rdSerialNumber
        '
        Me.rdSerialNumber.AutoSize = True
        Me.rdSerialNumber.Location = New System.Drawing.Point(190, 35)
        Me.rdSerialNumber.Name = "rdSerialNumber"
        Me.rdSerialNumber.Size = New System.Drawing.Size(91, 17)
        Me.rdSerialNumber.TabIndex = 2
        Me.rdSerialNumber.TabStop = True
        Me.rdSerialNumber.Text = "Serial Number"
        Me.rdSerialNumber.UseVisualStyleBackColor = True
        '
        'gbSearchOptions
        '
        Me.gbSearchOptions.Controls.Add(Me.rdAssetTag)
        Me.gbSearchOptions.Controls.Add(Me.rdSerialNumber)
        Me.gbSearchOptions.Controls.Add(Me.rdMachineName)
        Me.gbSearchOptions.Location = New System.Drawing.Point(41, 42)
        Me.gbSearchOptions.Name = "gbSearchOptions"
        Me.gbSearchOptions.Size = New System.Drawing.Size(286, 72)
        Me.gbSearchOptions.TabIndex = 3
        Me.gbSearchOptions.TabStop = False
        Me.gbSearchOptions.Text = "Search By:"
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(41, 152)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(100, 20)
        Me.txtSearch.TabIndex = 4
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(41, 210)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 23)
        Me.btnSearch.TabIndex = 5
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'Search
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1920, 1080)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.gbSearchOptions)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Search"
        Me.Text = "Search"
        Me.gbSearchOptions.ResumeLayout(False)
        Me.gbSearchOptions.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents rdAssetTag As RadioButton
    Friend WithEvents rdMachineName As RadioButton
    Friend WithEvents rdSerialNumber As RadioButton
    Friend WithEvents gbSearchOptions As GroupBox
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents btnSearch As Button
End Class
