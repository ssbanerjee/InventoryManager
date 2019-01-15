Imports System.Data.SqlClient
Imports System.Text

Public Class ShippingMenu
    Private myConn As SqlConnection
    Private myCmd As SqlCommand
    Private myReader As SqlDataReader

    Private machines As New ArrayList()
    Private shipping As New ArrayList()

    Public exportSelection As String

    Private Sub ShippingMenu_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Connect to SQL DB and reset activity timer
        resetTimer()
        myConn = New SqlConnection(connectionString)
        myConn.Open()
        myCmd = myConn.CreateCommand

        'Load machine and shipping data
        loadMachines()
        loadShipping()
    End Sub

    Private Sub loadMachines()
        lstMachines.Items.Clear()
        machines.Clear()
        machines = getShippingReport()
        For Each m In machines
            m = m.Replace(",", vbTab)
            lstMachines.Items.Add(m)
        Next
    End Sub

    Private Sub loadShipping()
        lstShipping.Items.Clear()
        shipping.Clear()
        shipping = getNonInventoriedReport()
        For Each s In shipping
            s = s.Replace(",", vbTab)
            lstShipping.Items.Add(s)
        Next
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        ExportDate.ShowDialog()

        Dim selectedMachines As ArrayList = getShippingReportByDate(exportSelection)
        Dim selectedItems As ArrayList = getNonInventoriedReportByDate(exportSelection)

        exportShippingReport(selectedMachines, selectedItems)

    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        AddShipping.ShowDialog()
        loadShipping()
        Login.bgwShipping.RunWorkerAsync()
    End Sub

    '======================================
    ' CUSTOM MOVE FORM 
    '======================================

    Private MoveForm As Boolean
    Private MoveForm_MousePosition As Point

    Private Sub MoveForm_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        If e.Button = MouseButtons.Left Then
            MoveForm = True
            Me.Cursor = Cursors.NoMove2D
            MoveForm_MousePosition = e.Location
        End If
    End Sub

    Private Sub MoveForm_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        If MoveForm Then
            Me.Location = Me.Location + (e.Location - MoveForm_MousePosition)
        End If
    End Sub

    Private Sub MoveForm_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
        If e.Button = MouseButtons.Left Then
            MoveForm = False
            Me.Cursor = Cursors.Default
        End If
    End Sub
    'END
End Class