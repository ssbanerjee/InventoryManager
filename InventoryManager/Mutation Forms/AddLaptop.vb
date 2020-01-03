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
        Dim machine_id As String = ""
        Dim employee As String = txtMachineName.Text
        Dim machineName As String = txtMachineName.Text
        Dim assetTag As String = txtAssetTag.Text
        Dim serialNumber As String = txtSerialNumber.Text
        Dim SIM As String = txtSIM.Text
        Dim IMEI As String = txtIMEI.Text
        Dim model As String = cbModel.Text
        Dim centerNumber As String = cbCenter.Text
        Dim MESD As String = txtMESD.Text
        Dim NewOrUsed As String = cbCondition.Text
        Dim costCenter As String = txtCostCenter.Text

        If centerNumber <> "" Then
            If centerNumber.Equals("Bell Creek, Mechanicsville") Then
                centerNumber = "0"
            Else
                'ex: '#115, AMF Sunset Lanes' -> 115
                centerNumber = centerNumber.Substring(0, 3)
            End If
        Else
            centerNumber = "0"
        End If

        'checkAT checks to see if this machine already exists via its Asset Tag
        If Not (checkAT(assetTag)) Then
            'checkNulls checks to see if any of the textboxes are empty.
            checkNulls(employee, machineName, assetTag, SIM, IMEI, serialNumber, MESD)

            If (serialNumber <> "") Then
                Dim command As String = ""
                command = "INSERT INTO Machine VALUES ('" + employee.Substring(0, getIndexOfNum(employee) - 1) + "', " + machineName.ToUpper() + ", " + assetTag + ", " +
                    serialNumber + ", " + SIM + ", " + IMEI + ", (SELECT modelID FROM Model WHERE name = '" + model + "'), " + centerNumber + ", '" + costCenter +
                    "', null, '" + dteAcquisition.Value + "', SYSDATETIME(), 2, (SELECT conditionID FROM Condition WHERE name = '" + NewOrUsed + "'), " + MESD + ", '" + getInitials() + "');"
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
        End If
    End Sub

    Private Sub checkNulls(ByRef employee As String, ByRef machineName As String, ByRef assetTag As String, ByRef SIM As String, ByRef IMEI As String, ByRef serialNumber As String, ByRef MESD As String)
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

        If MESD = "" Then
            MESD = "NULL"
        End If

        If serialNumber <> "" Then
            serialNumber = "'" + serialNumber + "'"
        Else
            MsgBox("You MUST enter a Serial Number.")
        End If
    End Sub

    Private Function checkAT(ByVal assetTag) As Boolean
        Dim command As String = "SELECT machine_name, machine_ID FROM Machine WHERE asset_tag = " + assetTag + ";"
        myCmd.CommandText = command
        Try
            myReader = myCmd.ExecuteReader
            If myReader.Read() Then
                Dim result As MsgBoxResult = MsgBox("Machine " + myReader.GetString(0) + " with asset tag " + assetTag + " found." + vbNewLine +
                                                    "Would you like to edit this machine?", MsgBoxStyle.YesNo) 'Asks user if they want to edit the machine found
                If result = MsgBoxResult.Yes Then
                    resetTimer() 'Code to turn off and back on the timer, found in InactivityTimer.vb
                    EditMachine.machineID = myReader.GetInt32(1)
                    myReader.Close()
                    EditMachine.ShowDialog()
                Else
                    myReader.Close()
                    Return False
                End If
                myReader.Close()
                Return True
            Else
                myReader.Close()
                Return False
            End If
        Catch ex As Exception
            LogError(ex.ToString, "AddLaptop", getInitials())
            myReader.Close()
            Return False
        End Try
    End Function

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
        '        cbCenter.Text = "#" + currentString
        '        cbCenter.SelectionStart = cbCenter.Text.Length
        '    End If
        'End If
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
        myCmd.CommandText = "SELECT DISTINCT name FROM Condition ORDER BY name ASC;"
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