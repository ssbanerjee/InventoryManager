Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Text.RegularExpressions

Public Class EditMachine
    Private connectionString As String = "Server=localhost\INVENTORYSQL;Database=master;Trusted_Connection=True;"
    Private myConn As SqlConnection
    Private myCmd As SqlCommand
    Private myReader As SqlDataReader

    Private employee As String
    Private machineName As String
    Private assetTag As String
    Private serialNumber As String
    Private SIM As String
    Private IMEI As String
    Private category As String
    Private model As String
    Private center_number As String

    Private received As String
    Private acquisition As String

    Public machineID As String 'This is the primary key value that is passed to it from the previous Form

    'When loading the form, it runs a query using machineID as the primary key
    Private Sub EditMachine_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        myConn = New SqlConnection(connectionString)
        myConn.Open()
        myCmd = myConn.CreateCommand
        btnBack.Visible = False
        myCmd.CommandText = "SELECT m.machine_name, m.asset_tag, m.serial_number, c.category_name, d.model_name, m.SIM, m.IMEI, t.center_number, e.employee_username, m.machine_id, m.received_date, m.acquisition_date " +
                        "FROM Machine m LEFT JOIN Employee e ON m.employee_ID = e.employee_ID " +
                        "LEFT JOIN Model d ON m.model_ID = d.model_ID " +
                        "LEFT JOIN Category c ON d.category_id = c.category_ID " +
                        "LEFT JOIN Center t ON m.machine_center_number = t.center_number " +
                        "WHERE m.machine_id = " + machineID + ";"
        Try
            myReader = myCmd.ExecuteReader()
            Dim results As String = ""
            Dim count As Integer = 0
            Do While myReader.Read()
                'Checks every index of the query (machine_name, asset_tag, etc) for null values.
                'If it finds a null, it replaces it with "null", otherwise it stores it into the corresponding variables.
                For i As Integer = 0 To 11
                    Select Case i
                        Case 0
                            If myReader.IsDBNull(i) Then
                                machineName = "null"
                            Else
                                machineName = myReader.GetString(i)
                            End If
                        Case 1
                            If myReader.IsDBNull(i) Then
                                assetTag = "null"
                            Else
                                assetTag = myReader.GetInt32(i).ToString
                            End If
                        Case 2
                            If myReader.IsDBNull(i) Then
                                serialNumber = "null"
                            Else
                                serialNumber = myReader.GetString(i)
                            End If
                        Case 5
                            If myReader.IsDBNull(i) Then
                                SIM = "null"
                            Else
                                SIM = myReader.GetString(i)
                            End If
                        Case 6
                            If myReader.IsDBNull(i) Then
                                IMEI = "null"
                            Else
                                IMEI = myReader.GetString(i)
                            End If
                        Case 7
                            If myReader.IsDBNull(i) Then
                                center_number = "null"
                            Else
                                center_number = myReader.GetInt32(i).ToString
                            End If
                        Case 8
                            If myReader.IsDBNull(i) Then
                                employee = "null"
                            Else
                                employee = myReader.GetString(i)
                            End If
                        Case 9
                            If myReader.IsDBNull(i) Then
                                machineID = "null"
                            Else
                                machineID = myReader.GetInt32(i).ToString
                            End If
                        Case 10
                            If myReader.IsDBNull(i) Then
                                received = "null"
                            Else
                                received = myReader.GetDateTime(i).ToString
                            End If
                        Case 11
                            If myReader.IsDBNull(i) Then
                                acquisition = "null"
                            Else
                                acquisition = myReader.GetDateTime(i).ToString
                            End If
                    End Select
                Next
            Loop
            myReader.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        loadInformation()
    End Sub

    'After getting the information from the query, it then displays the information via text boxes and such on the Form
    Private Sub loadInformation()
        txtUsername.Text = employee
        txtMachineName.Text = machineName
        txtAssetTag.Text = assetTag
        txtSerialNumber.Text = serialNumber
        txtSIM.Text = SIM
        txtIMEI.Text = IMEI
        If received <> "null" And received <> "" Then
            dteReceived.Value = received
        End If
        If acquisition <> "null" And acquisition <> "" Then
            dteAcquisition.Value = acquisition
        End If

    End Sub

    'Updates the machine with the current values shown in the Form
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If (checkUsername(txtUsername.Text)) Then
            Try
                Dim command As String = "UPDATE Machine SET employee_id = (SELECT employee_id FROM Employee WHERE employee_username = '" + txtUsername.Text + "'), " +
                    "machine_name = '" + txtMachineName.Text + "', " +
                    "asset_tag = " + txtAssetTag.Text + ", " +
                    "serial_number = '" + txtSerialNumber.Text + "', " +
                    "SIM = '" + txtSIM.Text + "', " +
                    "IMEI = '" + txtIMEI.Text + "', " +
                    "machine_center_number = " + center_number + ", " +
                    "acquisition_date = '" + dteAcquisition.Value + "', " +
                    "received_date = '" + dteReceived.Value + "' " +
                    "WHERE machine_id = " + machineID + ";"
                myCmd.CommandText = command
                myReader = myCmd.ExecuteReader
                myReader.Close()
                MsgBox("Success!")
                Me.Close()
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        Else
            MsgBox("Username not found")
        End If


    End Sub

    'This function checks to see if the username entered exists.
    'If it does, it continues on. If it doesn't, it then will ask if a new username is to be created.
    'If it finds that the value is empty, is passes true and sets the value to "null"
    Private Function checkUsername(ByVal employee As String) As Boolean
        If employee = "null" Or employee = "" Then
            Return True
        End If
        Dim dataReader As SqlDataReader
        Dim SQLCommand As SqlCommand

        SQLCommand = myConn.CreateCommand
        Dim command As String = "SELECT employee_id FROM Employee WHERE employee_username = '" + employee + "';"
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

    'This function is testing to see if I can get it to listen for a keypress. At the moment it is not working.
    Private Sub EditMachine_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar.Equals(Keys.F12) Then
            MsgBox("success")
        End If
    End Sub

    'This function does a simple check against SQL Injection by removing all single quotes, double quotes, and semicolons from input
    Private Sub checkSQLInjection(ByRef input As String)
        input = input.Replace("""", "")
        input = input.Replace("'", "")
        input = input.Replace(";", "")
    End Sub

    Private Sub txtAssetTag_TextChanged(sender As Object, e As EventArgs) Handles txtAssetTag.TextChanged
        'Enforces only numerical input
        Dim digitsOnly As Regex = New Regex("[^\d]")
        txtAssetTag.Text = digitsOnly.Replace(txtAssetTag.Text, "")

        If txtAssetTag.TextLength > 6 Then
            Dim character As String = txtAssetTag.Text(6)
            txtAssetTag.Text = character
        End If
        txtAssetTag.SelectionStart = txtAssetTag.TextLength
    End Sub

    Private Sub txtIMEI_TextChanged(sender As Object, e As EventArgs) Handles txtIMEI.TextChanged
        'Enforces only numerical input
        Dim digitsOnly As Regex = New Regex("[^\d]")
        txtIMEI.Text = digitsOnly.Replace(txtIMEI.Text, "")
        txtIMEI.SelectionStart = txtIMEI.TextLength
    End Sub

    Private Sub txtMachineName_TextChanged(sender As Object, e As EventArgs) Handles txtMachineName.TextChanged
        checkSQLInjection(txtMachineName.Text)
        txtMachineName.SelectionStart = txtMachineName.TextLength
    End Sub

    Private Sub txtSerialNumber_TextChanged(sender As Object, e As EventArgs) Handles txtSerialNumber.TextChanged
        checkSQLInjection(txtSerialNumber.Text)
        txtSerialNumber.SelectionStart = txtSerialNumber.TextLength
    End Sub

    Private Sub txtSIM_TextChanged(sender As Object, e As EventArgs) Handles txtSIM.TextChanged
        'Enforces only numerical input
        Dim digitsOnly As Regex = New Regex("[^\d]")
        txtSIM.Text = digitsOnly.Replace(txtSIM.Text, "")
        txtSIM.SelectionStart = txtSIM.TextLength
    End Sub

    Private Sub txtUsername_TextChanged(sender As Object, e As EventArgs) Handles txtUsername.TextChanged
        checkSQLInjection(txtUsername.Text)
        txtUsername.SelectionStart = txtUsername.TextLength
    End Sub

    Private Sub EditMachine_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        myConn.Close()
    End Sub
End Class