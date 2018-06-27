Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Text.RegularExpressions
Imports System.IO

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
    Private assetState As String
    Private costCenter As String
    Private condition As String
    Private MESD As String

    Private received As String
    Private acquisition As String

    Public machineID As String 'This is the primary key value that is passed to it from the previous Form

    'When loading the form, it runs a query using machineID as the primary key
    Private Sub EditMachine_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        resetTimer()
        myConn = New SqlConnection(connectionString)
        myConn.Open()
        myCmd = myConn.CreateCommand
        myCmd.CommandText = "SELECT m.machine_name, m.asset_tag, m.serial_number, c.category_name, d.model_name, m.SIM, m.IMEI, t.center_number, m.employee_username, m.machine_id, m.received_date, m.acquisition_date, a.asset_state_name, m.machine_cost_center, s.condition_name, m.machine_ticket_number " +
                        "FROM Machine m LEFT JOIN Model d ON m.model_ID = d.model_ID " +
                        "LEFT JOIN Category c ON d.category_id = c.category_ID " +
                        "LEFT JOIN Center t ON m.machine_center_number = t.center_number " +
                        "LEFT JOIN AssetState a ON m.asset_state_id = a.asset_state_id " +
                        "LEFT JOIN Condition s ON m.condition = s.condition_id " +
                        "WHERE m.machine_id = " + machineID + ";"
        Try
            myReader = myCmd.ExecuteReader()
            Dim results As String = ""
            Dim count As Integer = 0
            Do While myReader.Read()
                'Checks every index of the query (machine_name, asset_tag, etc) for null values.
                'If it finds a null, it replaces the value with "null", otherwise it stores value into the corresponding variables.
                For i As Integer = 0 To 15
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
                        Case 3
                            If myReader.IsDBNull(i) Then
                                category = "null"
                            Else
                                category = myReader.GetString(i)
                            End If
                        Case 4
                            If myReader.IsDBNull(i) Then
                                model = "null"
                            Else
                                model = myReader.GetString(i)
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
                                received = myReader.GetDateTime(i).ToString("MM/dd/yyy")
                            End If
                        Case 11
                            If myReader.IsDBNull(i) Then
                                acquisition = "null"
                            Else
                                acquisition = myReader.GetDateTime(i).ToString("MM/dd/yyy")
                            End If
                        Case 12
                            If myReader.IsDBNull(i) Then
                                assetState = "null"
                            Else
                                assetState = myReader.GetString(i)
                            End If
                        Case 13
                            If myReader.IsDBNull(i) Then
                                costCenter = "null"
                            Else
                                costCenter = myReader.GetString(i)
                            End If
                        Case 14
                            If myReader.IsDBNull(i) Then
                                condition = "null"
                            Else
                                condition = myReader.GetString(i)
                            End If
                        Case 15
                            If myReader.IsDBNull(i) Then
                                MESD = "null"
                            Else
                                MESD = myReader.GetInt32(i).ToString
                            End If
                    End Select
                Next
            Loop
            myReader.Close()
        Catch ex As Exception
            LogError(ex.ToString)
            MsgBox("Error, check logs")
        End Try

        loadInformation()
        loadAssetState()
        loadConditions()
        loadCenters()
    End Sub

    'After getting the information from the query, it then displays the information via text boxes and such on the Form
    Private Sub loadInformation()
        lblTitle.Text = category + " -- " + model
        txtUsername.Text = employee
        txtMachineName.Text = machineName
        txtAssetTag.Text = assetTag
        txtSerialNumber.Text = serialNumber
        txtSIM.Text = SIM
        txtIMEI.Text = IMEI
        cbAssetState.Text = assetState
        cbCenter.Text = center_number.ToString
        txtCostCenter.Text = costCenter
        cbCondition.Text = condition
        txtMESD.Text = MESD

        If received <> "null" And received <> "" Then
            dteReceived.Value = received
        End If
        If acquisition <> "null" And acquisition <> "" Then
            dteAcquisition.Value = acquisition
        End If

    End Sub

    Private Sub loadAssetState()
        cbAssetState.Items.Clear()
        myCmd.CommandText = "SELECT DISTINCT asset_state_name FROM AssetState ORDER BY asset_state_name ASC;"
        myReader = myCmd.ExecuteReader
        While myReader.Read()
            cbAssetState.Items.Add(myReader.GetString(0))
        End While
        myReader.Close()
    End Sub

    Private Sub loadConditions()
        cbCondition.Items.Clear()
        myCmd.CommandText = "SELECT DISTINCT condition_name FROM Condition ORDER BY condition_name ASC;"
        myReader = myCmd.ExecuteReader
        While myReader.Read()
            cbCondition.Items.Add(myReader.GetString(0))
        End While
        myReader.Close()
    End Sub

    Private Sub loadCenters()
        Dim centers As New List(Of String)

        cbCenter.Items.Clear()
        centers = LoadCentersFromSQL()

        For Each center As String In centers
            cbCenter.Items.Add(center)
        Next
    End Sub

    'Updates the machine with the current values shown in the Form
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            Dim command As String = "UPDATE Machine SET employee_username = '" + txtUsername.Text + "', " +
                "machine_name = '" + txtMachineName.Text + "', " +
                "asset_tag = " + txtAssetTag.Text + ", " +
                "serial_number = '" + txtSerialNumber.Text + "', " +
                "SIM = '" + txtSIM.Text + "', " +
                "IMEI = '" + txtIMEI.Text + "', " +
                "machine_center_number = " + center_number + ", " +
                "asset_state_id = (SELECT asset_state_id FROM AssetState WHERE asset_state_name = '" + cbAssetState.Text + "'), " +
                "condition = (SELECT condition_id FROM Condition WHERE condition_name = '" + cbCondition.Text + "'), " +
                "acquisition_date = '" + dteAcquisition.Value + "', " +
                "received_date = '" + dteReceived.Value + "', " +
                "last_modified = SYSDATETIME(), " +
                "machine_ticket_number = " + txtMESD.Text + " " +
                "WHERE machine_id = " + machineID + ";"
            myCmd.CommandText = command
            myReader = myCmd.ExecuteReader
            myReader.Close()
            MsgBox("Success!")
            LogMachineEdit(machineName)
            Me.Close()
        Catch ex As Exception
            LogError(ex.ToString)
            MsgBox("Error, check logs")
        End Try
    End Sub

    Private Sub cbCenter_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbCenter.SelectedValueChanged
        'This grabs the center number from the combobox and puts it into the CostCenter textbox
        If cbCenter.Text <> "" Then
            txtCostCenter.Text = cbCenter.Text.Substring(1, 3)
        End If
    End Sub

    Private Sub chCostCenter_CheckedChanged(sender As Object, e As EventArgs) Handles chCostCenter.CheckedChanged
        'By default, the CostCenter textbox is disabled.
        'The user can enable it by cheking the checkbox next to it.
        'If the user de-selects it once more, it grabs the center number from the combobox and fills it in.
        If chCostCenter.Checked Then
            txtCostCenter.ReadOnly = False
        Else
            txtCostCenter.ReadOnly = True
            If cbCenter.Text <> "" Then
                txtCostCenter.Text = cbCenter.Text.Substring(1, 3)
            End If
        End If
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

    'This function is testing to see if I can get it to listen for a keypress. At the moment it is not working.
    Private Sub EditMachine_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar.Equals(Keys.F12) Then
            MsgBox("success")
        End If
    End Sub

    Private Sub txtAssetTag_TextChanged(sender As Object, e As EventArgs) Handles txtAssetTag.TextChanged
        'Enforces only numerical input
        checkNum(txtAssetTag.Text)

        If txtAssetTag.TextLength > 6 Then
            Dim character As String = txtAssetTag.Text(6)
            txtAssetTag.Text = character
        End If
        txtAssetTag.SelectionStart = txtAssetTag.TextLength
    End Sub

    Private Sub txtIMEI_TextChanged(sender As Object, e As EventArgs) Handles txtIMEI.TextChanged
        'Enforces only numerical input
        checkNum(txtAssetTag.Text)
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
        checkNum(txtAssetTag.Text)
        txtSIM.SelectionStart = txtSIM.TextLength
    End Sub

    Private Sub txtUsername_TextChanged(sender As Object, e As EventArgs) Handles txtUsername.TextChanged
        checkSQLInjection(txtUsername.Text)
        txtUsername.SelectionStart = txtUsername.TextLength
    End Sub

    Private Sub EditMachine_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        myConn.Close()
    End Sub

    Private Sub cbCondition_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbAssetState.SelectedValueChanged
        If cbAssetState.SelectedItem = "IN STORE" Then
            cbCenter.Text = "#000"
            txtCostCenter.Text = ""
        End If
    End Sub
End Class