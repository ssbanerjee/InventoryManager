Imports System.Data.SqlClient
Imports System.ComponentModel

Public Class AddLaptop
    Private connectionString As String = "Server=localhost\INVENTORYSQL;Database=master;Trusted_Connection=True;"
    Private myConn As SqlConnection
    Private myCmd As SqlCommand
    Private myReader As SqlDataReader

    Private Sub AddLaptop_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        resetTimer()
        myConn = New SqlConnection(connectionString)
        myConn.Open()
        myCmd = myConn.CreateCommand
        clearLists()
        loadModels()
        loadCenters()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim employee As String = txtUsername.Text
        Dim machineName As String = txtMachineName.Text
        Dim assetTag As String = txtAssetTag.Text
        Dim serialNumber As String = txtSerialNumber.Text
        Dim SIM As String = txtSIM.Text
        Dim IMEI As String = txtIMEI.Text
        Dim model As String = cbModel.Text
        Dim centerNumber As String = cbCenter.Text
        Dim acquisition As String = dteAcquisition.Value
        Dim MESD As String = txtMESD.Text

        If centerNumber <> "" Then
            centerNumber = centerNumber.Substring(1, 3)
        Else
            centerNumber = "0"
        End If

        Dim costCenter As String = txtCostCenter.Text

        'checkNulls checks to see if any of the textboxes are empty.
        checkNulls(employee, machineName, assetTag, SIM, IMEI, serialNumber)


        If (serialNumber <> "") Then
            Dim command As String = ""
            command = "INSERT INTO Machine VALUES (" + employee + ", " + machineName + ", " + assetTag + ", " +
                serialNumber + ", " + SIM + ", " + IMEI + ", (SELECT model_id FROM Model WHERE model_name = '" + model + "'), " + centerNumber + ", '" + costCenter +
                "', SYSDATETIME(), '" + acquisition + "', SYSDATETIME(), 2, 1, " + MESD + ", '" + getInitials() + "');"
            myCmd.CommandText = command
            Try
                myReader = myCmd.ExecuteReader
                MsgBox("Success!")
                LogMachineAdd("Laptop", machineName)
                myReader.Close()
                Me.Close()
            Catch ex As Exception
                LogError(ex.ToString)
                MsgBox("Error, check logs")
            End Try
        End If
    End Sub

    Private Sub checkNulls(ByRef employee As String, ByRef machineName As String, ByRef assetTag As String, ByRef SIM As String, ByRef IMEI As String, ByRef serialNumber As String)
        If employee <> "" Then
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

    Private Sub loadModels()
        Dim models As New List(Of String)

        cbModel.Items.Clear()
        models = LoadModelsFromSQL("Laptop")

        For Each model As String In models
            cbModel.Items.Add(model)
        Next
    End Sub

    Private Sub loadCenters()
        Dim centers As New List(Of String)

        cbCenter.Items.Clear()
        centers = LoadCentersFromSQL()

        For Each center As String In centers
            cbCenter.Items.Add(center)
        Next
    End Sub

    Private Sub clearLists()
        txtUsername.Clear()
        txtMachineName.Clear()
        txtAssetTag.Clear()
        txtSerialNumber.Clear()
        txtSIM.Clear()
        txtIMEI.Clear()
        txtMESD.Clear()
        cbModel.SelectedIndex = -1
        cbCenter.SelectedIndex = -1
        txtCostCenter.Clear()
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

    Private Sub AddLaptop_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        myConn.Close()
    End Sub

    Private Sub cbModel_TextChanged(sender As Object, e As EventArgs) Handles cbModel.TextChanged
        checkSQLInjection(cbModel.Text)
        cbModel.SelectionStart = cbModel.Text.Length
    End Sub

    Private Sub txtUsername_Leave(sender As Object, e As EventArgs) Handles txtUsername.Leave
        txtMachineName.Text = txtUsername.Text + "-L"
        txtMachineName.SelectionStart = txtMachineName.TextLength
    End Sub
End Class