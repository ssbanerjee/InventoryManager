Imports System.Data.SqlClient
Imports System.ComponentModel

Public Class EditMachine
    Private myConn As SqlConnection
    Private myCmd As SqlCommand
    Private myReader As SqlDataReader

    Public oldMachine As Machine
    Public newMachine As Machine

    Private old_machineName As String
    Private assetTag As String
    Private serialNumber As String
    Private SIM As String
    Private IMEI As String
    Private category As String
    Private model As String
    Private old_center_number As String
    Private old_assetState As String
    Private old_costCenter As String
    Private old_condition As String
    Private old_MESD As String
    Private old_received As String
    Private old_acquisition As String

    Public machineID As String 'This is the primary key value that is passed to it from the previous Form
    Public confirm As Boolean

    'When loading the form, it runs a query using machineID as the primary key
    Private Sub EditMachine_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        resetTimer()
        confirm = False
        myConn = New SqlConnection(connectionString)
        myConn.Open()
        myCmd = myConn.CreateCommand
        myCmd.CommandText = "SELECT m.machine_name, m.asset_tag, m.serial_number, c.name, d.name, m.SIM, m.IMEI, t.center_number, m.username, m.machine_id, m.received_date, m.acquisition_date, a.name, m.cost_center, s.name, m.ticket_number " +
                        "FROM Machine m LEFT JOIN Model d ON m.modelID = d.modelID " +
                        "LEFT JOIN Category c ON d.categoryID = c.categoryID " +
                        "LEFT JOIN Center t ON m.center_number = t.center_number " +
                        "LEFT JOIN AssetState a ON m.asset_stateID = a.asset_stateID " +
                        "LEFT JOIN Condition s ON m.conditionID = s.conditionID " +
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
                                old_machineName = "null"
                            Else
                                old_machineName = myReader.GetString(i)
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
                                old_center_number = "null"
                            Else
                                Dim x As Integer = myReader.GetInt32(i)
                                If x = 0 Then
                                    old_center_number = "Bell Creek"
                                ElseIf x < 100 Then
                                    old_center_number = "0" + x.ToString
                                Else
                                    old_center_number = x.ToString
                                End If
                            End If
                        Case 9
                            If myReader.IsDBNull(i) Then
                                machineID = "null"
                            Else
                                machineID = myReader.GetInt32(i).ToString
                            End If
                        Case 10
                            If myReader.IsDBNull(i) Then
                                old_received = "null"
                            Else
                                old_received = myReader.GetDateTime(i).ToString("MM/dd/yyy")
                            End If
                        Case 11
                            If myReader.IsDBNull(i) Then
                                old_acquisition = "null"
                            Else
                                old_acquisition = myReader.GetDateTime(i).ToString("MM/dd/yyy")
                            End If
                        Case 12
                            If myReader.IsDBNull(i) Then
                                old_assetState = "null"
                            Else
                                old_assetState = myReader.GetString(i)
                            End If
                        Case 13
                            If myReader.IsDBNull(i) Then
                                old_costCenter = "null"
                            Else
                                old_costCenter = myReader.GetString(i)
                            End If
                        Case 14
                            If myReader.IsDBNull(i) Then
                                old_condition = "null"
                            Else
                                old_condition = myReader.GetString(i)
                            End If
                        Case 15
                            If myReader.IsDBNull(i) Then
                                old_MESD = "null"
                            Else
                                old_MESD = myReader.GetInt32(i).ToString
                            End If
                    End Select
                Next
            Loop
            myReader.Close()
        Catch ex As Exception
            LogError(ex.ToString, "EditMachine", getInitials())
        End Try

        loadInformation()
        loadAssetState()
        loadConditions()
        loadCenters()
    End Sub

    'After getting the information from the query, it then displays the information via text boxes and such on the Form
    Private Sub loadInformation()

        oldMachine = New Machine(machineID, old_machineName, assetTag, serialNumber, SIM, IMEI, category, model, old_center_number,
                                      old_assetState, old_costCenter, old_condition, old_MESD, old_received, old_acquisition, "")
        newMachine = New Machine(machineID, old_machineName, assetTag, serialNumber, SIM, IMEI, category, model, old_center_number,
                                      old_assetState, old_costCenter, old_condition, old_MESD, old_received, old_acquisition, "")

        lblTitle.Text = oldMachine.category + " -- " + oldMachine.model
        txtMachineName.Text = oldMachine.machineName
        txtAssetTag.Text = oldMachine.assetTag
        txtSerialNumber.Text = oldMachine.serialNumber
        txtSIM.Text = oldMachine.SIM
        txtIMEI.Text = oldMachine.IMEI
        cbAssetState.Text = oldMachine.assetState
        cbCenter.Text = oldMachine.centerNumber.ToString
        txtCostCenter.Text = oldMachine.costCenter
        cbCondition.Text = oldMachine.condition
        txtMESD.Text = oldMachine.MESD

        If old_received <> "null" And old_received <> "" Then
            dteReceived.Value = old_received
        End If
        If old_acquisition <> "null" And old_acquisition <> "" Then
            dteAcquisition.Value = old_acquisition
        End If
    End Sub

    Private Sub getNewValues()
        newMachine.machineName = txtMachineName.Text
        newMachine.assetState = cbAssetState.Text
        newMachine.costCenter = txtCostCenter.Text
        newMachine.condition = cbCondition.Text
        newMachine.MESD = txtMESD.Text
        newMachine.received = dteReceived.Value
        newMachine.acquisition = dteAcquisition.Value

        If cbCenter.Text.Equals("Bell Creek, Mechanicsville") Then
            newMachine.centerNumber = "Bell Creek"
        Else
            newMachine.centerNumber = cbCenter.Text.Substring(0, 3)
        End If

        'If txtUsername.Text = "null" Or txtUsername.Text = "" Then
        '    employee = "NULL"
        'Else
        '    employee = "'" + txtUsername.Text + "'"
        'End If
    End Sub

    Private Sub loadAssetState()
        cbAssetState.Items.Clear()
        myCmd.CommandText = "SELECT name FROM AssetState ORDER BY asset_stateID;"
        myReader = myCmd.ExecuteReader
        While myReader.Read()
            cbAssetState.Items.Add(myReader.GetString(0))
        End While
        myReader.Close()
    End Sub

    Private Sub loadConditions()
        cbCondition.Items.Clear()
        myCmd.CommandText = "SELECT DISTINCT name FROM Condition ORDER BY name ASC;"
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
        getNewValues()
        If newMachine.machineName = oldMachine.machineName Or newMachine.assetState = oldMachine.assetState Or newMachine.costCenter = oldMachine.costCenter _
           Or newMachine.condition = oldMachine.condition Or newMachine.MESD = oldMachine.MESD Or newMachine.received = oldMachine.received Or newMachine.acquisition = oldMachine.acquisition Then
            ConfirmChanges.ShowDialog()
            'Dim result As MsgBoxResult = MsgBox("Some values were not changed." + vbNewLine + "Is this OK?", MsgBoxStyle.YesNo)
            If confirm = True Then
                saveInfo()
            End If
        Else
            saveInfo()
        End If
    End Sub

    Private Sub saveInfo()
        If (newMachine.centerNumber.Equals("Bell Creek")) Then
            newMachine.centerNumber = "0"
        End If
        Try
            Dim command As String = "UPDATE Machine SET machine_name = '" + newMachine.machineName.ToUpper() + "', " +
                "username = '" + txtMachineName.Text.Substring(0, getIndexOfNum(txtMachineName.Text) - 1) + "', " +
                "asset_tag = " + txtAssetTag.Text + ", " +
                "serial_number = '" + txtSerialNumber.Text.ToUpper() + "', " +
                "SIM = " + checkNull(txtSIM.Text) + ", " +
                "IMEI = " + checkNull(txtIMEI.Text) + ", " +
                "center_number = " + newMachine.centerNumber + ", " +
                "cost_center = '" + newMachine.costCenter + "', " +
                "asset_stateID = (SELECT asset_stateID FROM AssetState WHERE name = '" + newMachine.assetState + "'), " +
                "conditionID = (SELECT conditionID FROM Condition WHERE name = '" + newMachine.condition + "'), " +
                "acquisition_date = '" + newMachine.acquisition + "', " +
                "received_date = '" + newMachine.received + "', " +
                "last_modified = SYSDATETIME(), " +
                "ticket_number = " + newMachine.MESD + ", " +
                "technician = '" + getInitials() + "' " +
                "WHERE machine_id = " + machineID + ";"
            myCmd.CommandText = command
            myReader = myCmd.ExecuteReader
            myReader.Close()
            MsgBox("Success!")
            LogMachineEdit(old_machineName, myCmd.CommandText)
            Me.Close()
        Catch ex As Exception
            LogError(ex.ToString, "EditMachine", getInitials())
        End Try
    End Sub
    Private Sub cbCenter_TextChanged(sender As Object, e As EventArgs) Handles cbCenter.TextChanged
        checkSQLInjection(cbCenter.Text)
        cbCenter.SelectionStart = cbCenter.Text.Length

        'Dim currentString As String = cbCenter.Text
        'Dim firstIndex As String = "null"
        'If Not cbCenter.Text.Length = 0 Then
        '    firstIndex = currentString.Substring(0, 1)
        'End If

        'Dim num As Integer
        'If Int32.TryParse(firstIndex, num) Then
        '    If Not cbCenter.Text.Length = 0 And Not currentString.Substring(0, 1) = "#" Then
        '        cbCenter.Text = currentString
        '        cbCenter.SelectionStart = cbCenter.Text.Length
        '    End If
        'End If
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
        checkNum(txtIMEI.Text)
        txtIMEI.SelectionStart = txtIMEI.TextLength
    End Sub

    Private Sub txtMachineName_TextChanged(sender As Object, e As EventArgs) Handles txtMachineName.TextChanged
        Dim index As Integer = txtMachineName.SelectionStart
        checkSQLInjection(txtMachineName.Text)
        txtMachineName.SelectionStart = index
    End Sub

    Private Sub txtSerialNumber_TextChanged(sender As Object, e As EventArgs) Handles txtSerialNumber.TextChanged
        checkSQLInjection(txtSerialNumber.Text)
        txtSerialNumber.SelectionStart = txtSerialNumber.TextLength
    End Sub

    Private Sub txtSIM_TextChanged(sender As Object, e As EventArgs) Handles txtSIM.TextChanged
        'Enforces only numerical input
        checkNum(txtSIM.Text)
        txtSIM.SelectionStart = txtSIM.TextLength
    End Sub

    Private Sub txtUsername_TextChanged(sender As Object, e As EventArgs)
        'checkSQLInjection(txtUsername.Text)
        'txtUsername.SelectionStart = txtUsername.TextLength
    End Sub

    Private Sub txtMESD_TextChanged(sender As Object, e As EventArgs) Handles txtMESD.TextChanged
        checkNum(txtMESD.Text)
        txtMESD.SelectionStart = txtMESD.TextLength
    End Sub

    Private Sub EditMachine_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        myConn.Close()
    End Sub

    Private Sub cbCondition_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbAssetState.SelectedValueChanged
        If cbAssetState.SelectedItem = "IN STORE" Then
            cbCenter.Text = "Bell Creek, Mechanicsville"
            txtCostCenter.Text = ""
        End If
    End Sub

    Private Function checkNull(ByVal str As String)
        If str.Trim().Length() > 0 Then
            Return ("'" + str + "'")
        Else
            Return ("NULL")
        End If
    End Function

    Private Function getIndexOfNum(ByVal input) As Integer
        For i = 1 To Len(input)
            Dim currentCharacter As String
            currentCharacter = Mid(input, i, 1)
            If IsNumeric(currentCharacter) = True Then
                Return i
                Exit Function
            End If
        Next
        Return Len(input) - 1
    End Function
End Class