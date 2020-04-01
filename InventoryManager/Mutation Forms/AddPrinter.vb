Imports System.Data.SqlClient
Imports System.ComponentModel

Public Class AddPrinter

    Private myConn As SqlConnection
    Private myCmd As SqlCommand
    Private myReader As SqlDataReader

    Private machineType As String = "T88VI-061"

    Private Sub AddPrinter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        resetTimer()
        myConn = New SqlConnection(connectionString)
        myConn.Open()
        myCmd = myConn.CreateCommand
        clearLists()
        loadCenters()
        loadConditions()
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
        txtAssetTag.Clear()
        txtSerialNumber.Clear()
        txtMESD.Clear()
        cbCenter.SelectedIndex = -1
        txtCostCenter.Clear()
        cbCondition.SelectedIndex = -1
    End Sub

    Private Sub cbCenter_TextChanged(sender As Object, e As EventArgs) Handles cbCenter.TextChanged
        checkSQLInjection(cbCenter.Text)
        cbCenter.SelectionStart = cbCenter.Text.Length
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

    Private Sub txtSerialNumber_TextChanged(sender As Object, e As EventArgs) Handles txtSerialNumber.TextChanged
        checkSQLInjection(txtSerialNumber.Text)
        txtSerialNumber.SelectionStart = txtSerialNumber.TextLength
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim serialNumber As String = txtSerialNumber.Text
        Dim assetTag As String = txtAssetTag.Text
        Dim centerNumber As String = cbCenter.Text
        Dim MESD As String = txtMESD.Text
        Dim NewOrUsed As String = cbCondition.Text
        Dim costCenter As String = txtCostCenter.Text

        If centerNumber <> "" Then
            If centerNumber.Equals("Bell Creek, Mechanicsville") Then
                centerNumber = "0"
            Else
                centerNumber = centerNumber.Substring(0, 3)
            End If
        Else
            centerNumber = "0"
        End If

        If Not (checkAT(assetTag)) Then
            If (serialNumber <> "") Then
                Dim command As String = ""
                command = "INSERT INTO Machine VALUES (NULL, '" + serialNumber + "', " + assetTag + ", '" +
                    serialNumber + "', NULL, NULL, (SELECT modelID FROM Model WHERE name = '" + machineType + "'), " + centerNumber + ", '" + costCenter +
                    "', null, '" + dteAcquisition.Value + "', SYSDATETIME(), 2, (SELECT conditionID FROM Condition WHERE name = '" + NewOrUsed + "'), " + MESD + ", '" + currentUser + "');"
                myCmd.CommandText = command
                Try
                    myReader = myCmd.ExecuteReader
                    MsgBox("Success!")
                    LogMachineAdd("CheckScanner", serialNumber, myCmd.CommandText)
                    myReader.Close()
                    Close()
                Catch ex As Exception
                    myReader.Close()
                    LogError(ex.ToString, "AddCheckScanner", getInitials)
                End Try
            End If
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
                    Return True
                Else
                    myReader.Close()
                    Return False
                End If
            Else
                myReader.Close()
                Return False
            End If
        Catch ex As Exception
            LogError(ex.ToString, "AddCheckScanner", currentUser)
            myReader.Close()
            Return False
        End Try
    End Function

    Private Sub txtMESD_TextChanged(sender As Object, e As EventArgs) Handles txtMESD.TextChanged
        checkNum(txtMESD.Text)
        txtMESD.SelectionStart = txtMESD.TextLength
    End Sub
End Class