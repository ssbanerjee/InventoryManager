Imports System.Data.SqlClient
Imports System.Text.RegularExpressions

Public Class Search
    'Private connectionString As String = "Server=INVSUXS-D; Database=INVENTORYSQL; User Id=SQLadmin; Password=1NV3nt0ry5uXX5"
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
    Private location As String

    Private received As String
    Private acquisition As String

    Private machineID As String

    Private Sub Search_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        myConn = New SqlConnection(connectionString)
        myConn.Open()
        myCmd = myConn.CreateCommand
        loadInformation()
        loadCategories()
    End Sub

    Private Sub loadInformation()
        lstMachines.Items.Clear()

        Dim searchOption As String = ""
        If rdListMachineNames.Checked Then
            searchOption = "machine_name"
        ElseIf rdListSerialNumbers.Checked Then
            searchOption = "serial_number"
        End If

        Dim command As String = "SELECT " + searchOption + " FROM Machine m JOIN Employee e ON m.employee_ID = e.employee_ID " +
                    "JOIN Model d ON m.model_ID = d.model_ID " +
                    "JOIN Category c ON d.category_id = c.category_ID " +
                    "JOIN Center t ON m.machine_center_number = t.center_number"
        Dim fCategory As String = cbCategory.SelectedItem
        Dim fModel As String = cbModel.SelectedItem

        If fCategory <> "" Then
            command += " WHERE c.category_name = '" + fCategory + "'"
            If fModel <> "" Then
                command += " AND d.model_name = '" + fModel + "'"
            End If
        End If

        myCmd.CommandText = command + ";"
        myReader = myCmd.ExecuteReader()
        Do While myReader.Read()
            If myReader.IsDBNull(0) Then
                lstMachines.Items.Add("No Machine Name Set")
            Else
                lstMachines.Items.Add(myReader.GetString(0))
            End If
        Loop
        myReader.Close()
    End Sub

    Private Sub loadMachineInfo()
        lblMachineName.Text = machineName
        lblAssetTag.Text = "Asset Tag: " + assetTag
        lblSerialNumber.Text = "Serial Number: " + serialNumber
        lblCatModel.Text = category + " -- " + model
        lblSim.Text = "SIM: " + SIM
        lblIMEI.Text = "IMEI: " + IMEI
        lblSiteUser.Text = "#" + location + " -- " + employee
        lblReceived.Text = "Received Date: " + received
        lblAcquisition.Text = "Acquisition Date: " + acquisition
    End Sub

    Private Sub loadCategories()
        myCmd.CommandText = "SELECT DISTINCT category_name FROM Category;"
        cbCategory.Items.Add("")
        Try
            myReader = myCmd.ExecuteReader
            Do While myReader.Read
                cbCategory.Items.Add(myReader.GetString(0))
            Loop
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        myReader.Close()
    End Sub

    Private Sub txtFilter_TextChanged(sender As Object, e As EventArgs) Handles txtFilter.TextChanged
        Dim i As Integer = lstMachines.FindString(txtFilter.Text)
        lstMachines.SelectedIndex = i
        If txtFilter.Text = "" Then
            lstMachines.SelectedIndex = -1
        End If
        'For counter As Integer = 0 To lstMachines.Items.Count - 1
        '    Dim item = lstMachines.Items(counter).ToString()
        '    Dim i As Integer = item.IndexOf(lstMachines.Text, StringComparison.CurrentCultureIgnoreCase)
        '    If i >= 0 Then
        '        lstMachines.SelectedIndex = i
        '    Else
        '        lstMachines.SelectedIndex = -1
        '    End If
        'Next
    End Sub

    Private Sub lstMachines_SelectedValueChanged(sender As Object, e As EventArgs) Handles lstMachines.SelectedValueChanged
        If lstMachines.SelectedIndex <> -1 Then
            Dim search As String = lstMachines.SelectedItem.ToString
            Dim query As String = ""
            Dim command As String = ""

            If rdListMachineNames.Checked Then
                query = "machine_name"
            ElseIf rdListSerialNumbers.Checked Then
                query = "serial_number"
            End If

            myCmd.CommandText = "SELECT m.machine_name, m.asset_tag, m.serial_number, c.category_name, d.model_name, m.SIM, m.IMEI, t.center_number, e.employee_username, m.machine_id, m.received_date, m.acquisition_date " +
                        "FROM Machine m JOIN Employee e ON m.employee_ID = e.employee_ID " +
                        "JOIN Model d ON m.model_ID = d.model_ID " +
                        "JOIN Category c ON d.category_id = c.category_ID " +
                        "JOIN Center t ON m.machine_center_number = t.center_number " +
                        "WHERE " + query + " = '" + search + "';"
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
            txtAssetTag.Clear()
            myReader.Close()
            loadMachineInfo()
        End If
    End Sub

    Private Sub cbCategory_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbCategory.SelectedValueChanged
        Dim category As String = cbCategory.SelectedItem
        cbModel.Items.Clear()

        If category <> "" Then
            cbModel.Enabled = True
        Else
            cbModel.Text = ""
            cbModel.Enabled = False
        End If

        myCmd.CommandText = "SELECT DISTINCT model_name FROM Model WHERE category_id = " +
            "(SELECT category_id FROM Category WHERE category_name = '" + category + "');"
        Try
            myReader = myCmd.ExecuteReader
            Do While myReader.Read
                cbModel.Items.Add(myReader.GetString(0))
            Loop
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        myReader.Close()
        loadInformation()
    End Sub

    Private Sub cbModel_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbModel.SelectedValueChanged
        loadInformation()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        EditMachine.machineID = machineID
        EditMachine.ShowDialog()
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

    Private Sub btnSearch_Click(sender As Object, e As EventArgs)
        'Dim search As String = txtSearch.Text
        'Dim query As String = ""
        'Dim command As String = ""

        'If rdAssetTag.Checked Then
        '    query = "asset_tag"
        'ElseIf rdMachineName.Checked Then
        '    query = "machine_name"
        '    search = "'" + search + "'"
        'ElseIf rdSerialNumber.Checked Then
        '    query = "serial_number"
        '    search = "'" + search + "'"
        'End If

        'command = "SELECT machine_name FROM Machine WHERE " + query + " = " + search + ";"
        'myCmd.CommandText = command
        'myReader = myCmd.ExecuteReader()
        'Dim results As String = ""
        'Dim count As Integer = 0
        'Do While myReader.Read()
        '    For i As Integer = 0 To 7
        '        If myReader.IsDBNull(i) Then
        '            Select Case i
        '                Case 0
        '                    machineName = "null"
        '                Case 1
        '                    assetTag = "null"
        '                Case 2
        '                    serialNumber = "null"
        '                Case 5
        '                    SIM = "null"
        '                Case 6
        '                    IMEI = "null"
        '                Case 8
        '                    employee = "null"
        '            End Select
        '        Else
        '            machineName = myReader.GetString(0)
        '            assetTag = myReader.GetInt32(1).ToString
        '            serialNumber = myReader.GetString(2)
        '            category = myReader.GetString(3)
        '            model = myReader.GetInt32(4).ToString
        '            SIM = myReader.GetString(5)
        '            IMEI = myReader.GetString(6)
        '            location = myReader.GetInt32(7).ToString
        '            employee = myReader.GetString(8)
        '        End If
        '    Next
        'Loop
        'myReader.Close()
        'loadMachineInfo()
    End Sub

    Private Sub txtAssetTag_TextChanged(sender As Object, e As EventArgs) Handles txtAssetTag.TextChanged
        Dim digitsOnly As Regex = New Regex("[^\d]")
        txtAssetTag.Text = digitsOnly.Replace(txtAssetTag.Text, "")

        If txtAssetTag.TextLength = 6 Then
            checkAT(txtAssetTag.Text)
        ElseIf txtAssetTag.TextLength > 6 Then
            Dim character As String = txtAssetTag.Text(6)
            txtAssetTag.Text = character
            txtAssetTag.SelectionStart = txtAssetTag.TextLength
        End If
    End Sub

    Private Sub checkAT(ByVal assetTag As String)
        myCmd.CommandText = "SELECT m.machine_name, m.asset_tag, m.serial_number, c.category_name, d.model_name, m.SIM, m.IMEI, t.center_number, e.employee_username, m.machine_id " +
                    "FROM Machine m JOIN Employee e ON m.employee_ID = e.employee_ID " +
                    "JOIN Model d ON m.model_ID = d.model_ID " +
                    "JOIN Category c ON d.category_id = c.category_ID " +
                    "JOIN Center t ON m.machine_center_number = t.center_number " +
                    "WHERE m.asset_tag = " + assetTag + ";"
        Try
            myReader = myCmd.ExecuteReader()
            Dim results As String = ""
            Dim count As Integer = 0
            If myReader.Read() Then

                For i As Integer = 0 To 7
                    If myReader.IsDBNull(i) Then
                        Select Case i
                            Case 0
                                machineName = "null"
                            Case 1
                                assetTag = "null"
                            Case 2
                                serialNumber = "null"
                            Case 5
                                SIM = "null"
                            Case 6
                                IMEI = "null"
                            Case 8
                                employee = "null"
                        End Select
                    Else
                        machineName = myReader.GetString(0)
                        assetTag = myReader.GetInt32(1).ToString
                        serialNumber = myReader.GetString(2)
                        category = myReader.GetString(3)
                        model = myReader.GetString(4)
                        SIM = myReader.GetString(5)
                        IMEI = myReader.GetString(6)
                        location = myReader.GetInt32(7).ToString
                        employee = myReader.GetString(8)
                        machineID = myReader.GetInt32(9).ToString
                    End If
                Next
            Else
                MsgBox("Machine not found")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        lstMachines.SelectedIndex = -1
        myReader.Close()
        loadMachineInfo()
    End Sub

    Private Sub txtAssetTag_Click(sender As Object, e As EventArgs) Handles txtAssetTag.Click
        txtAssetTag.SelectAll()
    End Sub
End Class