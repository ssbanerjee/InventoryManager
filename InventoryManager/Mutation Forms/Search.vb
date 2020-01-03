Imports System.Data.SqlClient
Imports System.ComponentModel

Public Class Search
    Private myConn As SqlConnection
    Private myCmd As SqlCommand
    Private myReader As SqlDataReader

    Private machine As New Machine("", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "")

    Private machineID As String

    Private Sub Search_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        resetTimer()
        myConn = New SqlConnection(connectionString)
        myConn.Open()
        myCmd = myConn.CreateCommand
        txtFilter.Clear()
        loadCategories()
        loadInformation()
        clearMachineInfo()
    End Sub

    Private Sub loadInformation()
        lstMachines.Items.Clear()

        'Checks to see which filter option has been selected, and then changes the serach query based on that result
        Dim searchOption As String = ""
        If rdListMachineNames.Checked Then
            searchOption = "machine_name"
        ElseIf rdListSerialNumbers.Checked Then
            searchOption = "serial_number"
        End If

        Dim command As String = "SELECT m." + searchOption + " FROM Machine m JOIN Model d ON m.modelID = d.modelID " +
                    "LEFT JOIN Category c ON d.categoryID = c.categoryID " +
                    "LEFT JOIN Center t ON m.center_number = t.center_number"
        Dim fCategory As String = cbCategory.SelectedItem
        Dim fModel As String = cbModel.SelectedItem

        'If a category and/or model has been selected, it updates the query to further narrow down the search
        If fCategory <> "" Then
            command += " WHERE c.name = '" + fCategory + "'"
            If fModel <> "" Then
                command += " AND d.name = '" + fModel + "'"
            End If
            If txtFilter.Text <> "" Then
                command += " AND m." + searchOption + " LIKE '%" + txtFilter.Text + "%'"
            End If
        Else
            If txtFilter.Text <> "" Then
                command += " WHERE m." + searchOption + " LIKE '%" + txtFilter.Text + "%'"
            End If
        End If

        myCmd.CommandText = command + " ORDER BY m." + searchOption + " ASC;"
        myReader = myCmd.ExecuteReader()
        Do While myReader.Read()
            'If it finds a machine, but the name is null (only checks machine_name as serial_number is NOT NULL by default
            If myReader.IsDBNull(0) Then
                'lstMachines.Items.Add("No Machine Name Set")
            Else
                lstMachines.Items.Add(myReader.GetString(0))
            End If
        Loop
        myReader.Close()
    End Sub

    Private Sub loadMachineInfo()
        lblMachineName.Text = machine.machineName
        lblAssetTag.Text = "Asset Tag: " + machine.assetTag
        lblSerialNumber.Text = "Serial Number: " + machine.serialNumber
        lblCatModel.Text = machine.category + " -- " + machine.model
        lblSim.Text = "SIM: " + machine.SIM
        lblIMEI.Text = "IMEI: " + machine.IMEI
        lblSiteUser.Text = "#" + machine.centerNumber + " -- " + machine.employee
        lblReceived.Text = "Received Date: " + machine.received
        lblAcquisition.Text = "Acquisition Date: " + machine.acquisition
        lblMESD.Text = "MESD: " + machine.MESD
    End Sub

    Private Sub clearMachineInfo()
        lblMachineName.Text = "Machine Name"
        lblAssetTag.Text = "Asset Tag:"
        lblSerialNumber.Text = "Serial Number:"
        lblCatModel.Text = "Category -- Model"
        lblSim.Text = "SIM:"
        lblIMEI.Text = "IMEI:"
        lblSiteUser.Text = "Site/User:"
        lblReceived.Text = "Received Date:"
        lblAcquisition.Text = "Acquisition Date:"
        lblMESD.Text = "MESD:"
    End Sub

    Private Sub loadCategories()
        cbCategory.Items.Clear()
        myCmd.CommandText = "SELECT DISTINCT name FROM Category WHERE categoryID != 3;"
        cbCategory.Items.Add("")
        Try
            myReader = myCmd.ExecuteReader
            Do While myReader.Read
                cbCategory.Items.Add(myReader.GetString(0))
            Loop
        Catch ex As Exception
            LogError(ex.ToString, "Search", getInitials())
        End Try
        myReader.Close()
        cbCategory.SelectedItem = "Laptop"
    End Sub

    Private Sub lstMachines_SelectedValueChanged(sender As Object, e As EventArgs) Handles lstMachines.SelectedValueChanged
        importMachinedata()
    End Sub

    Private Sub cbCategory_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbCategory.SelectedValueChanged
        Dim category As String = cbCategory.SelectedItem
        cbModel.Items.Clear()

        'The Model combobox is disabled by default. If a Category has been selected, then it enables the Model combobox.
        If category <> "" Then
            cbModel.Enabled = True
            cbModel.Items.Add("")
        Else
            cbModel.Text = ""
            cbModel.Enabled = False
        End If

        'Grabs the category ID and then populates the Model combobox based on the category selected.
        myCmd.CommandText = "SELECT DISTINCT name FROM Model WHERE categoryID = " +
            "(SELECT categoryID FROM Category WHERE name = '" + category + "');"
        Try
            myReader = myCmd.ExecuteReader
            Do While myReader.Read
                cbModel.Items.Add(myReader.GetString(0))
            Loop
        Catch ex As Exception
            LogError(ex.ToString, "Search", getInitials())
        End Try

        myReader.Close()
        loadInformation()
    End Sub

    Private Sub cbModel_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbModel.SelectedValueChanged
        'Simply reloads the information. loadInformation() is already made to check these values, no changes need to be made.
        loadInformation()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        'Passes the machineId to EditMachine and opens it
        EditMachine.machineID = machineID
        EditMachine.ShowDialog()
        loadInformation()
        importMachinedata()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        loadInformation()
    End Sub

    Private Sub rdListMachineNames_Click(sender As Object, e As EventArgs) Handles rdListMachineNames.Click
        loadInformation()
    End Sub

    Private Sub rdListSerialNumbers_Click(sender As Object, e As EventArgs) Handles rdListSerialNumbers.Click
        loadInformation()
    End Sub

    Private Sub txtAssetTag_Click(sender As Object, e As EventArgs) Handles txtAssetTag.Click
        txtAssetTag.SelectAll()
    End Sub

    Private Sub txtAssetTag_TextChanged(sender As Object, e As EventArgs) Handles txtAssetTag.TextChanged
        'Enforces only numerical input
        checkNum(txtAssetTag.Text)

        If txtAssetTag.TextLength > 6 Then
            Dim character As String = txtAssetTag.Text(6)
            txtAssetTag.Text = character
        End If
        txtAssetTag.SelectionStart = txtAssetTag.TextLength

        If txtAssetTag.Text <> "" Then
            checkAT(txtAssetTag.Text)
        End If

    End Sub

    'Whenever the textbox above the list changes, it checks to see if it can find the string and highlight the value for the user
    Private Sub txtFilter_TextChanged(sender As Object, e As EventArgs) Handles txtFilter.TextChanged
        checkSQLInjection(txtFilter.Text)
        txtFilter.SelectionStart = txtFilter.TextLength
        'Dim i As Integer = lstMachines.FindString(txtFilter.Text)
        'lstMachines.SelectedIndex = i
        'If txtFilter.Text = "" Then
        '    lstMachines.SelectedIndex = -1
        'End If
        lstMachines.Items.Clear()
        loadInformation()
    End Sub

    Private Sub Search_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        myConn.Close()
    End Sub

    Private Sub cbCategory_TextChanged(sender As Object, e As EventArgs) Handles cbCategory.TextChanged
        checkSQLInjection(cbCategory.Text)
        cbCategory.SelectionStart = cbCategory.Text.Length
    End Sub

    Private Sub cbModel_TextChanged(sender As Object, e As EventArgs) Handles cbModel.TextChanged
        checkSQLInjection(cbModel.Text)
        cbModel.SelectionStart = cbModel.Text.Length
    End Sub

    Private Sub btnNote_Click(sender As Object, e As EventArgs) Handles btnNote.Click
        Dim note As String = machine.machineName + vbNewLine +
               "CC: " + machine.costCenter + vbNewLine +
               "AT: " + machine.assetTag + vbNewLine +
               "S/N: " + machine.serialNumber + vbNewLine +
               "SIM: " + machine.SIM + vbNewLine +
               "IMEI: " + machine.IMEI + vbNewLine +
               "Model: " + machine.model
        Clipboard.SetText(note)
        MsgBox(machine.machineName + " info copied to clipboard.")
    End Sub

    Private Sub btnCompletion_Click(sender As Object, e As EventArgs) Handles btnCompletion.Click
        Dim str As String = System.DateTime.Now.ToString("MM/dd/yy") + vbTab +
            machine.model + vbTab + machine.condition + vbTab + machine.assetTag + vbTab + machine.serialNumber +
            vbTab + machine.employee + vbTab + "Verified" + vbTab + vbTab + machine.costCenter + vbTab + getInitials() +
            vbTab + machine.MESD
        Clipboard.SetText(str)
        MsgBox(machine.machineName + " info copied to clipboard.")
    End Sub

    Private Sub checkAT(ByVal input As String)
        myCmd.CommandText = "SELECT m.machine_name, m.asset_tag, m.serial_number, c.name, d.name, m.SIM, m.IMEI, t.center_number, m.username, m.machine_id, m.received_date, m.acquisition_date, k.name, m.cost_center, m.ticket_number " +
                        "FROM Machine m LEFT JOIN Model d ON m.modelID = d.modelID " +
                        "LEFT JOIN Category c ON d.categoryID = c.categoryID " +
                        "LEFT JOIN Center t ON m.center_number = t.center_number " +
                        "LEFT JOIN Condition k ON m.conditionID = k.conditionID " +
                        "WHERE m.asset_tag = " + input + ";"
        Try
            myReader = myCmd.ExecuteReader()
            Dim results As String = ""
            Dim count As Integer = 0
            If myReader.Read() Then
                'Checks every index of the query (machine_name, asset_tag, etc) for null values.
                'If it finds a null, it replaces it with "null", otherwise it stores it into the corresponding variables.
                For i As Integer = 0 To 14
                    Select Case i
                        Case 0
                            If myReader.IsDBNull(i) Then
                                machine.machineName = "null"
                            Else
                                machine.machineName = myReader.GetString(i)
                            End If
                        Case 1
                            If myReader.IsDBNull(i) Then
                                machine.assetTag = "null"
                            Else
                                machine.assetTag = myReader.GetInt32(i).ToString
                            End If
                        Case 2
                            If myReader.IsDBNull(i) Then
                                machine.serialNumber = "null"
                            Else
                                machine.serialNumber = myReader.GetString(i)
                            End If
                        Case 3
                            If myReader.IsDBNull(i) Then
                                machine.category = "null"
                            Else
                                machine.category = myReader.GetString(i)
                            End If
                        Case 4
                            If myReader.IsDBNull(i) Then
                                machine.model = "null"
                            Else
                                machine.model = myReader.GetString(i)
                            End If
                        Case 5
                            If myReader.IsDBNull(i) Then
                                machine.SIM = "null"
                            Else
                                machine.SIM = myReader.GetString(i)
                            End If
                        Case 6
                            If myReader.IsDBNull(i) Then
                                machine.IMEI = "null"
                            Else
                                machine.IMEI = myReader.GetString(i)
                            End If
                        Case 7
                            If myReader.IsDBNull(i) Then
                                machine.centerNumber = "null"
                            Else
                                machine.centerNumber = myReader.GetInt32(i).ToString
                            End If
                        Case 8
                            If myReader.IsDBNull(i) Then
                                machine.employee = "null"
                            Else
                                machine.employee = myReader.GetString(i)
                            End If
                        Case 9
                            machineID = myReader.GetInt32(i).ToString
                        Case 10
                            If myReader.IsDBNull(i) Then
                                machine.received = "null"
                            Else
                                machine.received = myReader.GetDateTime(i).ToString("MM/dd/yyy")
                            End If
                        Case 11
                            If myReader.IsDBNull(i) Then
                                machine.acquisition = "null"
                            Else
                                machine.acquisition = myReader.GetDateTime(i).ToString("MM/dd/yyy")
                            End If
                        Case 12
                            If myReader.IsDBNull(i) Then
                                machine.condition = "null"
                            Else
                                machine.condition = myReader.GetString(i)
                            End If
                        Case 13
                            If myReader.IsDBNull(i) Then
                                machine.costCenter = "null"
                            Else
                                machine.costCenter = myReader.GetString(i)
                            End If
                        Case 14
                            If myReader.IsDBNull(i) Then
                                machine.MESD = "null"
                            Else
                                machine.MESD = myReader.GetInt32(i).ToString
                            End If
                    End Select
                Next
                btnEdit.Enabled = True
                btnShip.Enabled = True
            Else
                If txtAssetTag.TextLength = 6 Then
                    MsgBox("No Machine Found.")
                End If
            End If
        Catch ex As Exception
            LogError(ex.ToString, "Search", getInitials())
        End Try
        lstMachines.SelectedIndex = -1
        myReader.Close()
        loadMachineInfo()
    End Sub

    Private Sub importMachinedata()
        btnEdit.Enabled = True
        btnShip.Enabled = True

        'Checks if index is -1 so it doesn't try to run a null query
        If lstMachines.SelectedIndex <> -1 Then
            Dim search As String = lstMachines.SelectedItem.ToString
            Dim query As String = ""
            Dim command As String = ""

            'Edits the query based on what is being displayed on the screen
            If rdListMachineNames.Checked Then
                query = "machine_name"
            ElseIf rdListSerialNumbers.Checked Then
                query = "serial_number"
            End If

            myCmd.CommandText = "SELECT m.machine_name, m.asset_tag, m.serial_number, c.name, d.name, m.SIM, m.IMEI, t.center_number, m.username, m.machine_id, m.received_date, m.acquisition_date, k.name, m.cost_center, m.ticket_number " +
                        "FROM Machine m LEFT JOIN Model d ON m.modelID = d.modelID " +
                        "LEFT JOIN Category c ON d.categoryID = c.categoryID " +
                        "LEFT JOIN Center t ON m.center_number = t.center_number " +
                        "LEFT JOIN Condition k ON m.conditionID = k.conditionID " +
                        "WHERE " + query + " = '" + search + "';"
            Try
                myReader = myCmd.ExecuteReader()
                Dim results As String = ""
                Dim count As Integer = 0
                Do While myReader.Read()
                    'Checks every index of the query (machine_name, asset_tag, etc) for null values.
                    'If it finds a null, it replaces it with "null", otherwise it stores it into the corresponding variables.
                    For i As Integer = 0 To 14
                        Select Case i
                            Case 0
                                If myReader.IsDBNull(i) Then
                                    machine.machineName = "null"
                                Else
                                    machine.machineName = myReader.GetString(i)
                                End If
                            Case 1
                                If myReader.IsDBNull(i) Then
                                    machine.assetTag = "null"
                                Else
                                    machine.assetTag = myReader.GetInt32(i).ToString
                                End If
                            Case 2
                                If myReader.IsDBNull(i) Then
                                    machine.serialNumber = "null"
                                Else
                                    machine.serialNumber = myReader.GetString(i)
                                End If
                            Case 3
                                If myReader.IsDBNull(i) Then
                                    machine.category = "null"
                                Else
                                    machine.category = myReader.GetString(i)
                                End If
                            Case 4
                                If myReader.IsDBNull(i) Then
                                    machine.model = "null"
                                Else
                                    machine.model = myReader.GetString(i)
                                End If
                            Case 5
                                If myReader.IsDBNull(i) Then
                                    machine.SIM = "null"
                                Else
                                    machine.SIM = myReader.GetString(i)
                                End If
                            Case 6
                                If myReader.IsDBNull(i) Then
                                    machine.IMEI = "null"
                                Else
                                    machine.IMEI = myReader.GetString(i)
                                End If
                            Case 7
                                If myReader.IsDBNull(i) Then
                                    machine.centerNumber = "null"
                                Else
                                    machine.centerNumber = myReader.GetInt32(i).ToString
                                End If
                            Case 8
                                If myReader.IsDBNull(i) Then
                                    machine.employee = "null"
                                Else
                                    machine.employee = myReader.GetString(i)
                                End If
                            Case 9
                                machineID = myReader.GetInt32(i).ToString
                            Case 10
                                If myReader.IsDBNull(i) Then
                                    machine.received = "null"
                                Else
                                    machine.received = myReader.GetDateTime(i).ToString("MM/dd/yyy")
                                End If
                            Case 11
                                If myReader.IsDBNull(i) Then
                                    machine.acquisition = "null"
                                Else
                                    machine.acquisition = myReader.GetDateTime(i).ToString("MM/dd/yyy")
                                End If
                            Case 12
                                If myReader.IsDBNull(i) Then
                                    machine.condition = "null"
                                Else
                                    machine.condition = myReader.GetString(i)
                                End If
                            Case 13
                                If myReader.IsDBNull(i) Then
                                    machine.costCenter = "null"
                                Else
                                    machine.costCenter = myReader.GetString(i)
                                End If
                            Case 14
                                If myReader.IsDBNull(i) Then
                                    machine.MESD = "null"
                                Else
                                    machine.MESD = myReader.GetInt32(i).ToString
                                End If
                        End Select
                    Next
                Loop
            Catch ex As Exception
                LogError(ex.ToString, "Search", getInitials())
            End Try
            txtAssetTag.Clear()
            myReader.Close()
            loadMachineInfo()
        End If
    End Sub

    Private Sub BtnShip_Click(sender As Object, e As EventArgs) Handles btnShip.Click
        Dim result As MsgBoxResult = MsgBox("Verify the data below:" + vbNewLine + vbNewLine +
                                        "Machine name: " + machine.machineName + vbNewLine +
                                        "Asset Tag: " + machine.assetTag + vbNewLine +
                                        "Serial Number: " + machine.serialNumber + vbNewLine +
                                        "Model: " + machine.model + vbNewLine +
                                        "Shipping to: " + machine.centerNumber + vbNewLine +
                                        "Cost Center: " + machine.costCenter + vbNewLine +
                                        "Condition: " + machine.condition + vbNewLine +
                                        "Ticket Number: " + machine.MESD,
                                    MsgBoxStyle.YesNo)
        If result = MsgBoxResult.Yes Then
            myCmd.CommandText = "INSERT INTO MachinesShipped VALUES ('" + machine.machineName + "', " + machine.assetTag + ", '" +
                            machine.serialNumber + "', " + machine.SIM + ", " + machine.IMEI + ", '" + machine.model + "', " +
                            machine.centerNumber + ", '" + machine.costCenter + "', SYSDATETIME(), '" + machine.condition + "', " +
                            machine.MESD + ", '" + getInitials() + "');"
            Try
                myReader = myCmd.ExecuteReader()
                MsgBox("Successfully recorded machine for shipment")
                myReader.Close()
            Catch ex As Exception
                LogError(ex.ToString, "mShipping", getInitials())
                myReader.Close()
            End Try
        End If

    End Sub
End Class