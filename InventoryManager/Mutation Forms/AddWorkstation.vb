Imports System.Data.SqlClient
Imports System.ComponentModel

Public Class AddWorkstation
    Private myConn As SqlConnection
    Private myCmd As SqlCommand
    Private myReader As SqlDataReader

    Private Sub AddWorkstation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        resetTimer()
        myConn = New SqlConnection(connectionString)
        myConn.Open()
        myCmd = myConn.CreateCommand
        clearLists()
        loadCenters()
        loadModels()
        loadConditions()
    End Sub

    Private Sub clearLists()
        txtMachineName.Clear()
        txtAssetTag.Clear()
        txtSerialNumber.Clear()
        cbModel.SelectedIndex = -1
        cbCenter.SelectedIndex = -1
        txtCostCenter.Clear()
        txtMESD.Clear()
        cbCondition.SelectedIndex = -1
    End Sub

    Private Sub loadCenters()
        Dim centers As New List(Of String)

        cbCenter.Items.Clear()
        centers = LoadCentersFromSQL()

        For Each center As String In centers
            cbCenter.Items.Add(center)
        Next
    End Sub

    Private Sub loadModels()
        Dim models As New List(Of String)

        cbModel.Items.Clear()
        models = LoadModelsFromSQL("Workstation")

        For Each model As String In models
            cbModel.Items.Add(model)
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

    Private Sub cbCenter_TextChanged(sender As Object, e As EventArgs) Handles cbCenter.TextChanged
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

    Private Sub txtMESD_TextChanged(sender As Object, e As EventArgs) Handles txtMESD.TextChanged
        checkNum(txtMESD.Text)
        txtMESD.SelectionStart = txtMESD.TextLength
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim centerNumber As String = ""

        'Checks if a center number and a model type has been selected
        If cbCenter.Text <> "" And cbModel.Text <> "" Then
            If cbCenter.Text.Equals("Bell Creek, Mechanicsville") Then
                centerNumber = "0"
            Else
                centerNumber = cbCenter.Text.Substring(0, 3)
            End If

            Dim machineName As String = txtMachineName.Text
            Dim model As String = cbModel.Text
            Dim assetTag As String = txtAssetTag.Text
            Dim serialNumber As String = txtSerialNumber.Text
            Dim costCenter As String = txtCostCenter.Text
            Dim MESD As String = txtMESD.Text
            Dim NewOrUsed As String = cbCondition.Text

            If Not (checkAT(assetTag)) Then
                'checkNulls checks to see if any of the textboxes are empty.
                checkNulls(machineName, assetTag, serialNumber)

                If serialNumber <> "" Then
                    myCmd.CommandText = "INSERT INTO Machine VALUES ('AMF" + centerNumber + "NODE', " + machineName.ToUpper() + ", " + assetTag + ", " + serialNumber.ToUpper() + ", null, null, " +
                     "(SELECT modelID FROM Model WHERE name = '" + model + "'), " + centerNumber + ", '" + costCenter + "', null, '" + dteAcquisition.Value + "', SYSDATETIME(), 2, (SELECT conditionID FROM Condition WHERE name = '" + NewOrUsed + "'), " + MESD + ", '" + getInitials() + "');"
                    Try
                        myReader = myCmd.ExecuteReader
                        MsgBox("Success!")
                        LogMachineAdd("Workstation", machineName, myCmd.CommandText)
                        myReader.Close()
                        Close()
                    Catch ex As Exception
                        myReader.Close()
                        LogError(ex.ToString, "AddWorkstation", getInitials())
                    End Try
                End If
            End If
        Else
            MsgBox("Some fields are empty.")
        End If
    End Sub

    Private Sub checkNulls(ByRef machineName As String, ByRef assetTag As String, ByRef serialNumber As String)
        If machineName = "" Then
            machineName = "null"
        Else
            machineName = "'" + machineName + "'"
        End If

        If assetTag = "" Then
            assetTag = "null"
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

    Private Sub txtAssetTag_TextChanged(sender As Object, e As EventArgs) Handles txtAssetTag.TextChanged
        'Enforces only numerical input
        checkNum(txtAssetTag.Text)

        If txtAssetTag.TextLength > 6 Then
            Dim character As String = txtAssetTag.Text(6)
            txtAssetTag.Text = character
        End If
        txtAssetTag.SelectionStart = txtAssetTag.TextLength
    End Sub

    Private Sub txtMachineName_TextChanged(sender As Object, e As EventArgs) Handles txtMachineName.TextChanged
        checkSQLInjection(txtMachineName.Text)
        txtMachineName.SelectionStart = txtMachineName.TextLength
    End Sub

    Private Sub txtSerialNumber_TextChanged(sender As Object, e As EventArgs) Handles txtSerialNumber.TextChanged
        checkSQLInjection(txtSerialNumber.Text)
        txtSerialNumber.SelectionStart = txtSerialNumber.TextLength
    End Sub

    Private Sub AddWorkstation_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        myConn.Close()
    End Sub
End Class