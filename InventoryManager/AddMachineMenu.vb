Imports System.Data.SqlClient

Public Class AddMachineMenu
    'Private connectionString As String = "Server=INVSUXS-D; Database=INVENTORYSQL; User Id=SQLadmin; Password=1NV3nt0ry5uXX5"
    Private connectionString As String = "Server=localhost\INVENTORYSQL;Database=master;Trusted_Connection=True;"
    Private myConn As SqlConnection
    Private myCmd As SqlCommand
    Private myReader As SqlDataReader
    Private results As String

    Private Sub AddMachine_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Close()
    End Sub

    Private Sub btnLaptop_Click(sender As Object, e As EventArgs) Handles btnLaptop.Click
        myConn = New SqlConnection(connectionString)
        myConn.Open()
        myCmd = myConn.CreateCommand
        myCmd.CommandText = "SELECT first_name, last_name FROM Employee"
        myReader = myCmd.ExecuteReader()
        Dim results As String = ""
        Do While myReader.Read()
            results += myReader.GetString(0) + " " + myReader.GetString(1) + vbCrLf
        Loop
        MsgBox(results)
    End Sub
End Class