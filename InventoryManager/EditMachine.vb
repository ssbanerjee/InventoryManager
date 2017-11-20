Imports System.Data.SqlClient
Imports System.Text.RegularExpressions

Public Class EditMachine
    Private connectionString As String = "Server=localhost\INVENTORYSQL;Database=master;Trusted_Connection=True;"
    Private myConn As SqlConnection
    Private myCmd As SqlCommand
    Private myReader As SqlDataReader
    Private results As String

    Private employee As String
    Private machineName As String
    Private assetTag As String
    Private serialNumber As String
    Private SIM As String
    Private IMEI As String
    Private category As String
    Private model As String
    Private location As String

    Private received As String
    Private acquisition As String

    Public machineID As String

    Private Sub EditMachine_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        myConn = New SqlConnection(connectionString)
        myConn.Open()
        myCmd = myConn.CreateCommand
        btnBack.Visible = False
        myCmd.CommandText = "SELECT m.machine_name, m.asset_tag, m.serial_number, c.category_name, d.model_name, m.SIM, m.IMEI, t.center_number, e.employee_username, m.machine_id, m.received_date, m.acquisition_date " +
                        "FROM Machine m JOIN Employee e ON m.employee_ID = e.employee_ID " +
                        "JOIN Model d ON m.model_ID = d.model_ID " +
                        "JOIN Category c ON d.category_id = c.category_ID " +
                        "JOIN Center t ON m.machine_center_number = t.center_number " +
                        "WHERE m.machine_id = " + machineID + ";"
        Try
            myReader = myCmd.ExecuteReader()
            Dim results As String = ""
            Dim count As Integer = 0
            Do While myReader.Read()
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
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        loadInformation()
    End Sub

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
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If (checkUsername(txtUsername.Text)) Then
            Try
                Dim command As String = "UPDATE Machine SET employee_id = (SELECT employee_id FROM Employee WHERE employee_username = '" + txtUsername.Text + "'), " +
                            "machine_name = '" + txtMachineName.Text + "', " +
                            "asset_tag = " + txtAssetTag.Text + ", " +
                            "serial_number = '" + txtSerialNumber.Text + "', " +
                            "SIM = '" + txtSIM.Text + "', " +
                            "IMEI = '" + txtIMEI.Text + "', " +
                            "center_number = " + location + " " +
                            "WHERE machine_id = " + machineID + ";"
                MsgBox(command)
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

    Private Function checkUsername(ByVal employee As String) As Boolean
        If employee = "null" Then
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

    Private Sub EditMachine_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar.Equals(Keys.F12) Then
            MsgBox("success")
        End If
    End Sub
End Class