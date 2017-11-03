Imports System.Data.SqlClient
Imports System.Text.RegularExpressions

Public Class AddLaptop
    'Private connectionString As String = "Server=INVSUXS-D; Database=INVENTORYSQL; User Id=SQLadmin; Password=1NV3nt0ry5uXX5"
    Private connectionString As String = "Server=localhost\INVENTORYSQL;Database=master;Trusted_Connection=True;"
    Private myConn As SqlConnection
    Private myCmd As SqlCommand
    Private myReader As SqlDataReader
    Private results As String
    Private Sub AddLaptop_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        myConn = New SqlConnection(connectionString)
        myConn.Open()
        myCmd = myConn.CreateCommand
        btnBack.Visible = False
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim employee As String = txtUsername.Text
        Dim machineName As String = txtMachineName.Text
        Dim assetTag As String = txtAssetTag.Text
        Dim serialNumber As String = txtSerialNumber.Text
        Dim SIM As String = txtSIM.Text
        Dim IMEI As String = txtIMEI.Text
        Dim category As String = "1"
        Dim model As String = "1"
        Dim location As String = "0"

        checkNulls(employee, machineName, assetTag, SIM, IMEI, serialNumber)

        If (checkUsername(employee)) And (serialNumber <> "") Then
            Dim command As String = ""
            Dim subCommand As String = "(SELECT employee_id FROM Employee WHERE employee_username = " + employee + ")"
            command = "INSERT INTO Machine VALUES (" + subCommand + ", " + machineName + ", " + assetTag + ", " +
                serialNumber + ", " + SIM + ", " + IMEI + ", " + category + ", " + model + ", " + location + ");"
            myCmd.CommandText = command
            Try
                myReader = myCmd.ExecuteReader
                MsgBox("Success!")
                myReader.Close()
                Me.Close()
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If

        'Dim results As String = ""
        'Do While myReader.Read()
        '    results += myReader.GetString(0) + " " + myReader.GetString(1) + vbCrLf
        'Loop
        'MsgBox(results)
    End Sub

    Private Sub checkNulls(ByRef employee As String, ByRef machineName As String, ByRef assetTag As String, ByRef SIM As String, ByRef IMEI As String, ByRef serialNumber As String)
        If employee = "" Then
            employee = "null"
        Else
            employee = "'" + employee + "'"
        End If

        If machineName = "" Then
            machineName = "null"
        Else
            machineName = "'" + machineName + "'"
        End If

        If assetTag = "" Then
            assetTag = "null"
        End If

        If SIM = "" Then
            SIM = "null"
        Else
            SIM = "'" + SIM + "'"
        End If

        If IMEI = "" Then
            IMEI = "null"
        Else
            IMEI = "'" + IMEI + "'"
        End If

        If serialNumber <> "" Then
            serialNumber = "'" + serialNumber + "'"
        Else
            MsgBox("You MUST enter a Serial Number.")
        End If
    End Sub

    Private Function checkUsername(ByVal employee As String) As Boolean
        If employee = "null" Then
            Return True
        End If
        Dim dataReader As SqlDataReader
        Dim SQLCommand As SqlCommand
        SQLCommand = myConn.CreateCommand
        Dim command As String = "SELECT employee_id FROM Employee WHERE employee_username = " + employee + ";"
        SQLCommand.CommandText = command
        Try
            dataReader = SQLCommand.ExecuteReader
            If (dataReader.Read()) Then
                dataReader.Close()
                Return True
            Else
                dataReader.Close()
                MsgBox("Username not found")
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            MsgBox("Username not found")
            Return False
        End Try
    End Function

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Close()
    End Sub

    Private Sub txtAssetTag_TextChanged(sender As Object, e As EventArgs) Handles txtAssetTag.TextChanged
        Dim digitsOnly As Regex = New Regex("[^\d]")
        txtAssetTag.Text = digitsOnly.Replace(txtAssetTag.Text, "")

        If txtAssetTag.TextLength > 6 Then
            Dim character As String = txtAssetTag.Text(6)
            txtAssetTag.Text = character
            txtAssetTag.SelectionStart = txtAssetTag.TextLength
        End If
    End Sub
End Class