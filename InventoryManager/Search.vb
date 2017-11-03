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

        command = "SELECT machine_name from Machine WHERE " + query + " = " + search + ";"
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


End Class