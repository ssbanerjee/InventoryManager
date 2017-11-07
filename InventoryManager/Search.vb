Imports System.Data.SqlClient

Public Class Search
    'Private connectionString As String = "Server=INVSUXS-D; Database=INVENTORYSQL; User Id=SQLadmin; Password=1NV3nt0ry5uXX5"
    Private connectionString As String = "Server=localhost\INVENTORYSQL;Database=master;Trusted_Connection=True;"
    Private myConn As SqlConnection
    Private myCmd As SqlCommand
    Private myReader As SqlDataReader

    Private Sub Search_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        myConn = New SqlConnection(connectionString)
        myConn.Open()
        myCmd = myConn.CreateCommand
        loadInformation()
    End Sub

    Private Sub loadInformation()
        lstMachines.Items.Clear()

        Dim searchOption As String = ""
        If rdListMachineNames.Checked Then
            searchOption = "machine_name"
        ElseIf rdListSerialNumbers.Checked Then
            searchOption = "serial_number"
        End If
        myCmd.CommandText = "SELECT " + searchOption + " FROM Machine;"
        myReader = myCmd.ExecuteReader()
        Do While myReader.Read()
            If myReader.IsDBNull(0) Then
                Dim result As String = "No Machine Name Set"
                lstMachines.Items.Add(result + myReader.GetString(1))
            Else
                lstMachines.Items.Add(myReader.GetString(0))
            End If
        Loop
        myReader.Close()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim search As String = txtSearch.Text
        Dim query As String = ""
        Dim command As String = ""

        If rdAssetTag.Checked Then
            query = "asset_tag"
        ElseIf rdMachineName.Checked Then
            query = "machine_name"
            search = "'" + search + "'"
        ElseIf rdSerialNumber.Checked Then
            query = "serial_number"
            search = "'" + search + "'"
        End If

        command = "SELECT machine_name FROM Machine WHERE " + query + " = " + search + ";"
        myCmd.CommandText = command
        myReader = myCmd.ExecuteReader()
        Dim results As String = ""
        Dim count As Integer = 0
        Do While myReader.Read()
            count += 1
            If myReader.IsDBNull(0) Then
                results += count.ToString + ". " + "null" + vbCrLf
            Else
                results += count.ToString + ". " + myReader.GetString(0) + vbCrLf
            End If
        Loop
        results = count.ToString + " result(s): " + vbCrLf + vbCrLf + results
        myReader.Close()
        MsgBox(results)
    End Sub

    Private Sub txtFilter_TextChanged(sender As Object, e As EventArgs) Handles txtFilter.TextChanged
        Dim i As Integer = lstMachines.FindString(txtFilter.Text)
        lstMachines.SelectedIndex = i
        If txtFilter.Text = "" Then
            lstMachines.SelectedIndex = -1
        End If
        'For counter As Integer = 0 To lstMachines.Items.Count - 1
        '    Dim item = lstMachines.Items(counter).ToString()
        '    Dim i As Integer = item.IndexOf(lstMachines.Text, StringComparison.CurrentCultureIgnoreCase)
        '    If i >= 0 Then
        '        lstMachines.SelectedIndex = i
        '    Else
        '        lstMachines.SelectedIndex = -1
        '    End If
        'Next
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        loadInformation()
    End Sub

    Private Sub rdListMachineNames_Click(sender As Object, e As EventArgs) Handles rdListMachineNames.Click
        loadInformation()
    End Sub

    Private Sub rdListSerialNumbers_Click(sender As Object, e As EventArgs) Handles rdListSerialNumbers.Click
        loadInformation()
    End Sub
End Class