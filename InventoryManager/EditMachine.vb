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

    Public machineID As String

    Private Sub EditMachine_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        myConn = New SqlConnection(connectionString)
        myConn.Open()
        myCmd = myConn.CreateCommand
        btnBack.Visible = False
        myCmd.CommandText = "SELECT e.employee_username, m.machine_name, m.asset_tag, m.serial_number, m.SIM, m.IMEI, m.model_id, m.machine_center_number " +
                            "FROM Employee e JOIN Machine m ON m.employee_id = e.employee_id " +
                            "WHERE m.machine_id = " + machineID + ";"
        myReader = myCmd.ExecuteReader
        If myReader.Read() Then
            For i As Integer = 0 To 7
                If myReader.IsDBNull(i) Then
                    Select Case i
                        Case 0
                            employee = "null"
                        Case 1
                            machineName = "null"
                        Case 2
                            assetTag = "null"
                        Case 3
                            serialNumber = "null"
                        Case 4
                            SIM = "null"
                        Case 5
                            IMEI = "null"
                    End Select
                Else
                    employee = myReader.GetString(0)
                    machineName = myReader.GetString(1)
                    assetTag = myReader.GetInt32(2).ToString
                    serialNumber = myReader.GetString(3)
                    SIM = myReader.GetString(4)
                    IMEI = myReader.GetString(5)
                    model = myReader.GetInt32(6).ToString
                    location = myReader.GetInt32(7).ToString
                End If
            Next
            myReader.Close()
        Else
            MsgBox("Machine not found")
        End If

        loadInformation()
    End Sub

    Private Sub loadInformation()
        txtUsername.Text = employee
        txtMachineName.Text = machineName
        txtAssetTag.Text = assetTag
        txtSerialNumber.Text = serialNumber
        txtSIM.Text = SIM
        txtIMEI.Text = IMEI
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
End Class