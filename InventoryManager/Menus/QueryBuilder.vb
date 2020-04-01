Imports System.Data.SqlClient
Imports System.ComponentModel

Public Class QueryBuilder
    Private myConn As SqlConnection
    Private myCmd As SqlCommand
    Private myReader As SqlDataReader

    Private index As Integer = 0
    Private machineColumns() As String = {"machine_ID", "username", "machine_name", "asset_tag", "serial_number", "SIM", "IMEI", "modelID", "center_number", "received_date", "acquisition_date", "last_modified", "asset_stateID", "condition", "ticket_number", "technician"}
    Private shippingColumns() As String = {"shipping_ID", "noninventoriedID", "quantity", "center", "MESD", "last_modified", "technician"}
    Private firstItem As Boolean = True
    Private where As Boolean = False
    Private itemCount As Integer = 0

    Private Sub QueryBuilder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        resetTimer()
        myConn = New SqlConnection(connectionString)
        myConn.Open()
        myCmd = myConn.CreateCommand
        where = False
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        If lnkTable.Text = "Select Table" Or lnkColumns.Text = "Select Columns" Then
            MsgBox("Need to select a table and at least one column")
            Return
        End If

        Dim query As String = "SELECT " + lnkColumns.Text + " FROM " + lnkTable.Text
        If where Then
            query += " WHERE " + lnkWhereSubject.Text + " = " + txtEquals.Text
        End If
        myCmd.CommandText = query + ";"
        MsgBox(query)

        Dim result As String = ""
        Try
            myReader = myCmd.ExecuteReader()
            Do While myReader.Read()
                Dim line As String = ""
                For i As Integer = 0 To (itemCount - 1)
                    If myReader.IsDBNull(i) Then
                        line += "null"
                    Else
                        Select Case myReader.GetFieldType(i).ToString
                            Case "System.String"
                                line += myReader.GetString(i)
                            Case "System.Int32"
                                line += myReader.GetInt32(i).ToString
                            Case "System.DateTime"
                                line += myReader.GetDateTime(i).ToString("MM/dd/yyy")
                        End Select
                    End If
                    If Not i = (itemCount - 1) Then
                        line += ", "
                    End If
                Next
                result += line + vbNewLine
            Loop
            If result = "" Then
                MsgBox("No Results")
            Else
                MsgBox(result)
            End If
            myReader.Close()
        Catch ex As Exception
            LogError(ex.ToString, "QueryBuilder", currentUser)
        End Try
    End Sub

    Private Sub lnkTable_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkTable.LinkClicked
        index = 1
        lnkTable.LinkColor = Color.Crimson
        lnkColumns.LinkColor = Color.Blue
        lnkWhereSubject.LinkColor = Color.Blue
        lstItems.Items.Clear()
        lstItems.Items.Add("Machine")
        lstItems.Items.Add("Shipping")
        lstItems.SelectionMode = SelectionMode.One
    End Sub

    Private Sub lnkColumns_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkColumns.LinkClicked
        index = 2
        lnkTable.LinkColor = Color.Blue
        lnkColumns.LinkColor = Color.Crimson
        lnkWhereSubject.LinkColor = Color.Blue
        loadItems()
        lstItems.SelectionMode = SelectionMode.MultiSimple
    End Sub

    Private Sub lnkWhereSubject_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkWhereSubject.LinkClicked
        index = 3
        lnkTable.LinkColor = Color.Blue
        lnkColumns.LinkColor = Color.Blue
        lnkWhereSubject.LinkColor = Color.Crimson
        loadItems()
        firstItem = True
        lstItems.SelectionMode = SelectionMode.One
    End Sub

    Private Sub loadItems()
        lstItems.Items.Clear()

        If lnkTable.Text.Equals("Machine") Then
            For Each column In machineColumns
                lstItems.Items.Add(column)

            Next
        Else
            For Each column In shippingColumns
                lstItems.Items.Add(column)
            Next
        End If
    End Sub

    Private Sub lstItems_SelectedValueChanged(sender As Object, e As EventArgs) Handles lstItems.SelectedValueChanged
        itemCount = lstItems.SelectedItems.Count

        If itemCount = 0 Then
            lnkColumns.Text = "Select Columns"
            Return
        ElseIf itemCount < 2 Then
            firstItem = True
        End If

        If index = 1 Then
            lnkTable.Text = lstItems.SelectedItem.ToString
            lstItems.Items.Clear()
            lnkColumns.Text = "Select Columns"
            lnkWhereSubject.Text = "Select Item"
            Return
        ElseIf index = 2 Then
            lnkWhereSubject.Text = "Select Item"
        ElseIf index = 3 Then
            lnkWhereSubject.Text = lstItems.SelectedItem.ToString
            lstItems.Items.Clear()
            'lblEquals.Location = New Point(lnkWhereSubject.Location.X + lnkWhereSubject.Size.Width + 1, lblEquals.Location.Y)
            where = True
            Return
        End If

        Dim items As String = ""
        Dim check As Integer = 0
        For Each selectedItem In lstItems.SelectedItems
            If firstItem Then
                items += selectedItem.ToString
                firstItem = False
            Else
                If check = 0 Then
                    items += selectedItem.ToString
                    check += 1
                Else
                    items += ", " + selectedItem.ToString
                End If

            End If
        Next

        Select Case index
            Case 1
                lnkTable.Text = items
            Case 2
                lnkColumns.Text = items
            Case 3
                lnkWhereSubject.Text = items
        End Select
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        firstItem = True
        where = False
        itemCount = 0
        lnkTable.LinkColor = Color.Blue
        lnkTable.Text = "Select Table"
        lnkColumns.LinkColor = Color.Blue
        lnkColumns.Text = "Select Columns"
        lnkWhereSubject.LinkColor = Color.Blue
        lnkWhereSubject.Text = "Select Item"
        lstItems.Items.Clear()
        txtEquals.Clear()
        resetTimer()
    End Sub
End Class