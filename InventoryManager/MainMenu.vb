Imports System.Data.SqlClient

Public Class MainMenu
    'Private connectionString As String = "Server=INVSUXS-D; Database=INVENTORYSQL; User Id=SQLadmin; Password=1NV3nt0ry5uXX5"
    Private connectionString As String = "Server=localhost\INVENTORYSQL;Database=master;Trusted_Connection=True;"
    Private myConn As SqlConnection
    Private myCmd As SqlCommand
    Private myReader As SqlDataReader
    Private results As String

    Private Sub MainMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
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
