<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class QueryBuilder
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
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.lblTabel = New System.Windows.Forms.Label()
        Me.lnkTable = New System.Windows.Forms.LinkLabel()
        Me.lblColumns = New System.Windows.Forms.Label()
        Me.lnkColumns = New System.Windows.Forms.LinkLabel()
        Me.lblWhere = New System.Windows.Forms.Label()
        Me.lnkWhereSubject = New System.Windows.Forms.LinkLabel()
        Me.lblEquals = New System.Windows.Forms.Label()
        Me.txtEquals = New System.Windows.Forms.TextBox()
        Me.lstItems = New System.Windows.Forms.ListBox()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(15, 170)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(207, 33)
        Me.btnSearch.TabIndex = 1
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'lblTabel
        '
        Me.lblTabel.AutoSize = True
        Me.lblTabel.Location = New System.Drawing.Point(12, 22)
        Me.lblTabel.Name = "lblTabel"
        Me.lblTabel.Size = New System.Drawing.Size(123, 13)
        Me.lblTabel.TabIndex = 3
        Me.lblTabel.Text = "Table to search through:"
        '
        'lnkTable
        '
        Me.lnkTable.AutoSize = True
        Me.lnkTable.Location = New System.Drawing.Point(142, 22)
        Me.lnkTable.Name = "lnkTable"
        Me.lnkTable.Size = New System.Drawing.Size(67, 13)
        Me.lnkTable.TabIndex = 4
        Me.lnkTable.TabStop = True
        Me.lnkTable.Text = "Select Table"
        '
        'lblColumns
        '
        Me.lblColumns.AutoSize = True
        Me.lblColumns.Location = New System.Drawing.Point(13, 48)
        Me.lblColumns.Name = "lblColumns"
        Me.lblColumns.Size = New System.Drawing.Size(82, 13)
        Me.lblColumns.TabIndex = 5
        Me.lblColumns.Text = "Select columns:"
        '
        'lnkColumns
        '
        Me.lnkColumns.AutoSize = True
        Me.lnkColumns.Location = New System.Drawing.Point(142, 48)
        Me.lnkColumns.Name = "lnkColumns"
        Me.lnkColumns.Size = New System.Drawing.Size(80, 13)
        Me.lnkColumns.TabIndex = 6
        Me.lnkColumns.TabStop = True
        Me.lnkColumns.Text = "Select Columns"
        '
        'lblWhere
        '
        Me.lblWhere.AutoSize = True
        Me.lblWhere.Location = New System.Drawing.Point(13, 77)
        Me.lblWhere.Name = "lblWhere"
        Me.lblWhere.Size = New System.Drawing.Size(48, 13)
        Me.lblWhere.TabIndex = 7
        Me.lblWhere.Text = "WHERE"
        '
        'lnkWhereSubject
        '
        Me.lnkWhereSubject.AutoSize = True
        Me.lnkWhereSubject.Location = New System.Drawing.Point(67, 77)
        Me.lnkWhereSubject.Name = "lnkWhereSubject"
        Me.lnkWhereSubject.Size = New System.Drawing.Size(60, 13)
        Me.lnkWhereSubject.TabIndex = 8
        Me.lnkWhereSubject.TabStop = True
        Me.lnkWhereSubject.Text = "Select Item"
        '
        'lblEquals
        '
        Me.lblEquals.AutoSize = True
        Me.lblEquals.Location = New System.Drawing.Point(52, 96)
        Me.lblEquals.Name = "lblEquals"
        Me.lblEquals.Size = New System.Drawing.Size(13, 13)
        Me.lblEquals.TabIndex = 9
        Me.lblEquals.Text = "="
        '
        'txtEquals
        '
        Me.txtEquals.Location = New System.Drawing.Point(70, 93)
        Me.txtEquals.Name = "txtEquals"
        Me.txtEquals.Size = New System.Drawing.Size(100, 20)
        Me.txtEquals.TabIndex = 10
        '
        'lstItems
        '
        Me.lstItems.FormattingEnabled = True
        Me.lstItems.Location = New System.Drawing.Point(282, 17)
        Me.lstItems.Name = "lstItems"
        Me.lstItems.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.lstItems.Size = New System.Drawing.Size(149, 186)
        Me.lstItems.TabIndex = 11
        '
        'btnRefresh
        '
        Me.btnRefresh.BackgroundImage = Global.InventoryManager.My.Resources.Resources.refresh
        Me.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnRefresh.Location = New System.Drawing.Point(235, 170)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(33, 33)
        Me.btnRefresh.TabIndex = 12
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'QueryBuilder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(448, 219)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.lstItems)
        Me.Controls.Add(Me.txtEquals)
        Me.Controls.Add(Me.lblEquals)
        Me.Controls.Add(Me.lnkWhereSubject)
        Me.Controls.Add(Me.lblWhere)
        Me.Controls.Add(Me.lnkColumns)
        Me.Controls.Add(Me.lblColumns)
        Me.Controls.Add(Me.lnkTable)
        Me.Controls.Add(Me.lblTabel)
        Me.Controls.Add(Me.btnSearch)
        Me.Name = "QueryBuilder"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "QueryBuilder"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSearch As Button
    Friend WithEvents lblTabel As Label
    Friend WithEvents lnkTable As LinkLabel
    Friend WithEvents lblColumns As Label
    Friend WithEvents lnkColumns As LinkLabel
    Friend WithEvents lblWhere As Label
    Friend WithEvents lnkWhereSubject As LinkLabel
    Friend WithEvents lblEquals As Label
    Friend WithEvents txtEquals As TextBox
    Friend WithEvents lstItems As ListBox
    Friend WithEvents btnRefresh As Button
End Class
