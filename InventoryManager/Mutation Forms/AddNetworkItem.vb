Imports System.Data.SqlClient
Imports System.ComponentModel

Public Class AddNetworkItem
    Private myConn As SqlConnection
    Private myCmd As SqlCommand
    Private myReader As SqlDataReader

    Public category_name As String

    Private Sub AddNetworkItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        resetTimer()
        myConn = New SqlConnection(connectionString)
        myConn.Open()
        myCmd = myConn.CreateCommand
        clearLists()
        loadModels()
        loadCenters()
        txtCategory.Text = category_name
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        'Local variables
        Dim machine_id As String = ""
        Dim assetTag As String = txtAssetTag.Text
        Dim serialNumber As String = txtSerialNumber.Text
        Dim centerNumber As String = cbCenter.Text
        Dim costCenter As String = txtCostCenter.Text
        Dim MESD As String = txtMESD.Text
        Dim model_name As String = cbModel.Text

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
            checkNulls(assetTag, serialNumber)

            If (serialNumber <> "") Then
                Dim command As String = ""
                command = "INSERT INTO Machine VALUES (NULL, '" + serialNumber.ToUpper() + "', " + assetTag + ", '" +
                    serialNumber.ToUpper() + "', NULL, NULL, (SELECT modelId FROM Model WHERE name = '" + model_name + "'), " + centerNumber + ", '" + costCenter +
                    "', null, SYSDATETIME(), SYSDATETIME(), 2, 1, " + MESD + ", '" + getInitials() + "');"
                myCmd.CommandText = command
                Try
                    myReader = myCmd.ExecuteReader
                    MsgBox("Success!")
                    LogMachineAdd("NetworkItem", serialNumber.ToUpper(), myCmd.CommandText)
                    myReader.Close()
                    Close()
                Catch ex As Exception
                    myReader.Close()
                    LogError(ex.ToString, "AddNetworkItem", getInitials())
                End Try
            End If
            Login.bgwShipping.RunWorkerAsync()
        End If
    End Sub

    Private Sub clearLists()
        txtAssetTag.Clear()
        txtSerialNumber.Clear()
        cbCenter.SelectedIndex = -1
        txtCostCenter.Clear()
    End Sub

    Private Sub loadModels()
        Dim models As New List(Of String)

        cbModel.Items.Clear()
        models = LoadModelsFromSQL(category_name)

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

    Private Sub checkNulls(ByRef assetTag As String, ByRef serialNumber As String)
        If assetTag = "" Then
            assetTag = "null"
        End If

        If serialNumber = "" Then
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
            LogError(ex.ToString, "AddNetworkItem", getInitials())
            myReader.Close()
            Return False
        End Try
    End Function

    Private Sub txtAssetTag_TextChanged(sender As Object, e As EventArgs) Handles txtAssetTag.TextChanged
        'Enforces only numerical input
        checkNum(txtAssetTag.Text)

        If txtAssetTag.TextLength > 6 Then
            Dim character As String = txtAssetTag.Text(6)
            txtAssetTag.Text = character
        End If
        txtAssetTag.SelectionStart = txtAssetTag.TextLength
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
        '        cbCenter.Text = "#" + currentString
        '        cbCenter.SelectionStart = cbCenter.Text.Length
        '    End If
        'End If
    End Sub
End Class