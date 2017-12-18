Imports System.Data.SqlClient
Imports System.ComponentModel

Public Class AddEmployee
    'The following lines are to be substituted in for the MYSQL version
    Private connectionString As String = "Server=localhost\INVENTORYSQL;Database=master;Trusted_Connection=True;"
    Private myConn As SqlConnection
    Private myCmd As SqlCommand
    Private myReader As SqlDataReader

    Public username As String

    Private Sub AddEmployee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        myConn = New SqlConnection(connectionString)
        myConn.Open()
        myCmd = myConn.CreateCommand
        loadCenters()
        lblUsername.Text = "Username: " + username
    End Sub

    Private Sub loadCenters()
        cbCenter.Items.Clear()
        Dim centerNumberInt As Integer
        Dim centerNumber As String = ""
        Dim centerName As String = ""

        myCmd.CommandText = "SELECT center_number, name FROM Center WHERE center_number > 0 ORDER BY center_number ASC;"
        myReader = myCmd.ExecuteReader
        While myReader.Read()
            centerNumberInt = myReader.GetInt32(0)
            centerName = myReader.GetString(1)

            If centerNumberInt < 100 Then
                centerNumber = "0" + centerNumberInt.ToString
            Else
                centerNumber = centerNumberInt.ToString
            End If

            cbCenter.Items.Add("#" + centerNumber + ", " + centerName)
        End While

        myReader.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If cbCenter.Text <> "" And txtFirstName.Text <> "" And txtLastName.Text <> "" Then
            myCmd.CommandText = "INSERT INTO Employee VALUES ('" + txtFirstName.Text + "', '" + txtLastName.Text + "', " + username + ", 'USER', " +
                            cbCenter.Text.Substring(1, 3) + ");"
            Try
                myReader = myCmd.ExecuteReader
                If myReader.Read() Then
                    MsgBox("Success!")
                End If
                myReader.Close()
                Me.Close()
            Catch ex As Exception
                MsgBox(ex.ToString)
                myReader.Close()
            End Try
        Else
            MsgBox("Please fill out all fields.")
        End If

        myReader.Close()
    End Sub

    Private Sub cbCenter_TextChanged(sender As Object, e As EventArgs) Handles cbCenter.TextChanged
        checkSQLInjection(cbCenter.Text)
        cbCenter.SelectionStart = cbCenter.Text.Length

        Dim currentString As String = cbCenter.Text
        Dim firstIndex As String = "null"
        If Not cbCenter.Text.Length = 0 Then
            firstIndex = currentString.Substring(0, 1)
        End If

        Dim num As Integer
        If Int32.TryParse(firstIndex, num) Then
            If Not cbCenter.Text.Length = 0 And Not currentString.Substring(0, 1) = "#" Then
                cbCenter.Text = "#" + currentString
                cbCenter.SelectionStart = cbCenter.Text.Length
            End If
        End If
    End Sub

    Private Sub AddEmployee_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        myConn.Close()
    End Sub

    'This function does a simple check against SQL Injection by removing all single quotes, double quotes, and semicolons from input
    Private Sub checkSQLInjection(ByRef input As String)
        input = input.Replace("""", "")
        input = input.Replace("'", "")
        input = input.Replace(";", "")
    End Sub

    Private Sub txtFirstName_TextChanged(sender As Object, e As EventArgs) Handles txtFirstName.TextChanged
        checkSQLInjection(txtFirstName.Text)
        txtFirstName.SelectionStart = txtFirstName.TextLength
    End Sub

    Private Sub txtLastName_TextChanged(sender As Object, e As EventArgs) Handles txtLastName.TextChanged
        checkSQLInjection(txtLastName.Text)
        txtLastName.SelectionStart = txtLastName.TextLength
    End Sub
End Class