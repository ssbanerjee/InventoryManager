Imports System.Data.SqlClient
Imports System.ComponentModel

Public Class AddLaptop
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
        loadConditions()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        'Local variables
        Dim employee As String = txtUsername.Text
        Dim machineName As String = txtMachineName.Text
        Dim assetTag As String = txtAssetTag.Text
        Dim serialNumber As String = txtSerialNumber.Text
        Dim SIM As String = txtSIM.Text
        Dim IMEI As String = txtIMEI.Text
        Dim model As String = cbModel.Text
        Dim centerNumber As String = cbCenter.Text
        Dim MESD As String = txtMESD.Text
        Dim NewOrUsed As String = cbCondition.Text

        If centerNumber <> "" Then
            If centerNumber.Substring(1, 8).Equals("In Store") Then
                centerNumber = "0"
            Else
                'ex: '#115, AMF Sunset Lanes' -> 115
                centerNumber = centerNumber.Substring(1, 3)
            End If
        Else
            centerNumber = "0"
        End If

        Dim costCenter As String = txtCostCenter.Text

        'checkNulls checks to see if any of the textboxes are empty.
        checkNulls(employee, machineName, assetTag, SIM, IMEI, serialNumber)


        If (serialNumber <> "") Then
            Dim command As String = ""
            command = "INSERT INTO Machine VALUES (" + employee.ToUpper() + ", " + machineName.ToUpper() + ", " + assetTag + ", " +
                serialNumber + ", " + SIM + ", " + IMEI + ", (SELECT model_id FROM Model WHERE model_name = '" + model + "'), " + centerNumber + ", '" + costCenter +
                "', SYSDATETIME(), SYSDATETIME(), SYSDATETIME(), 2, (SELECT condition_id FROM Condition WHERE condition_name = '" + NewOrUsed + "'), " + MESD + ", '" + getInitials() + "');"
            myCmd.CommandText = command
            Try
                myReader = myCmd.ExecuteReader
                MsgBox("Success!")
                LogMachineAdd("Laptop", machineName, myCmd.CommandText)
                myReader.Close()
                Close()
            Catch ex As Exception
                myReader.Close()
                LogError(ex.ToString, "AddLaptop", getInitials())
            End Try
        End If
        Login.bgwShipping.RunWorkerAsync()
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

    Private Sub loadConditions()
        cbCondition.Items.Clear()
        myCmd.CommandText = "SELECT DISTINCT condition_name FROM Condition ORDER BY condition_name ASC;"
        myReader = myCmd.ExecuteReader
        While myReader.Read()
            cbCondition.Items.Add(myReader.GetString(0))
        End While
        myReader.Close()
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
        cbCondition.SelectedIndex = -1
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
        checkSQLInjection(txtMachineName.Text)
        txtMachineName.SelectionStart = txtMachineName.TextLength
    End Sub

    Private Sub txtSerialNumber_TextChanged(sender As Object, e As EventArgs) Handles txtSerialNumber.TextChanged
        checkSQLInjection(txtSerialNumber.Text)
        checkDashes(txtSerialNumber.Text)
        txtSerialNumber.SelectionStart = txtSerialNumber.TextLength
    End Sub

    Private Sub txtSIM_TextChanged(sender As Object, e As EventArgs) Handles txtSIM.TextChanged
        'Enforces only numerical input
        checkNum(txtSIM.Text)
        txtSIM.SelectionStart = txtSIM.TextLength
    End Sub

    Private Sub txtUsername_TextChanged(sender As Object, e As EventArgs) Handles txtUsername.TextChanged
        checkSQLInjection(txtUsername.Text)
        txtUsername.SelectionStart = txtUsername.TextLength
    End Sub

    Private Sub txtMESD_TextChanged(sender As Object, e As EventArgs) Handles txtMESD.TextChanged
        checkNum(txtMESD.Text)
        txtMESD.SelectionStart = txtMESD.TextLength
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