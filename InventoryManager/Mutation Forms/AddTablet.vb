Imports System.Data.SqlClient
Imports System.ComponentModel

Public Class AddTablet
    Private myConn As SqlConnection
    Private myCmd As SqlCommand
    Private myReader As SqlDataReader

    Private Sub AddTablet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        resetTimer()
        myConn = New SqlConnection(connectionString)
        myConn.Open()
        myCmd = myConn.CreateCommand
        clearLists()
        loadCenters()
        loadConditions()
        txtSerialNumber.Select()
        txtMachineName.TabStop = False
        cbCenter.TabStop = False
        txtCostCenter.TabStop = False
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim serialNumber As String = txtSerialNumber.Text
        Dim assetTag As String = txtAssetTag.Text
        Dim machineName As String = txtMachineName.Text
        Dim centerNumber As String = cbCenter.Text
        Dim MESD As String = txtMESD.Text
        Dim NewOrUsed As String = cbCondition.Text
        Dim costCenter As String = txtCostCenter.Text
        Dim inventoried As String = ""
        If centerNumber <> "" Then
            If centerNumber.Substring(1, 8).Equals("In Store") Then
                centerNumber = "0"
            Else
                centerNumber = centerNumber.Substring(1, 3)
            End If
        Else
            centerNumber = "0"
        End If

        If chInventoried.Checked = True Then
            inventoried = "1"
        Else
            inventoried = "0"
        End If

        If Not (checkAT(assetTag)) Then
            If (serialNumber <> "") Then
                Dim command As String = ""
                command = "INSERT INTO Machine VALUES (NULL, '" + machineName.ToUpper() + "', " + assetTag + ", '" +
                    serialNumber.ToUpper + "', NULL, NULL, 23, " + centerNumber + ", '" + costCenter +
                    "', null, SYSDATETIME(), SYSDATETIME(), 2, (SELECT condition_id FROM Condition WHERE condition_name = '" + NewOrUsed + "'), " + MESD + ", '" + getInitials() + "', " + inventoried + ");"
                myCmd.CommandText = command
                Try
                    myReader = myCmd.ExecuteReader
                    MsgBox("Success!")
                    LogMachineAdd("Tablet", serialNumber, myCmd.CommandText)
                    myReader.Close()
                    Close()
                Catch ex As Exception
                    myReader.Close()
                    LogError(ex.ToString, "AddTablet", getInitials())
                End Try
            End If
            Login.bgwShipping.RunWorkerAsync()
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
            LogError(ex.ToString, "AddTablet", getInitials())
            myReader.Close()
            Return False
        End Try
    End Function

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
        txtMachineName.Clear()
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

    Private Sub txtAssetTag_TextChanged(sender As Object, e As EventArgs) Handles txtAssetTag.TextChanged
        'Enforces only numerical input
        checkNum(txtAssetTag.Text)

        'If txtAssetTag.TextLength > 6 Then
        '    Dim character As String = txtAssetTag.Text(6)
        '    txtAssetTag.Text = character
        'End If
        txtAssetTag.SelectionStart = txtAssetTag.TextLength
        If txtAssetTag.TextLength = 6 Then
            txtMESD.Select()
            txtCostCenter.Text = "1645"
        End If
    End Sub

    Private Sub txtMachineName_TextChanged(sender As Object, e As EventArgs) Handles txtMachineName.TextChanged
        checkSQLInjection(txtMachineName.Text)
        txtMachineName.SelectionStart = txtMachineName.TextLength
    End Sub

    Private Sub txtSerialNumber_TextChanged(sender As Object, e As EventArgs) Handles txtSerialNumber.TextChanged
        checkSQLInjection(txtSerialNumber.Text)
        txtSerialNumber.SelectionStart = txtSerialNumber.TextLength
        If (txtSerialNumber.TextLength = 15) Then
            txtAssetTag.Select()
        End If
    End Sub

    Private Sub txtMESD_TextChanged(sender As Object, e As EventArgs) Handles txtMESD.TextChanged
        checkNum(txtMESD.Text)
        txtMESD.SelectionStart = txtMESD.TextLength
        If (txtMESD.TextLength = 6) Then
            cbCondition.Text = "NEW"
            btnAdd.Select()
        End If
    End Sub

    Private Sub AddTablet_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        myConn.Close()
    End Sub

    Private Sub txtSerialNumber_Leave(sender As Object, e As EventArgs) Handles txtSerialNumber.Leave
        txtMachineName.Text = txtSerialNumber.Text
        cbCenter.Text = "#In Store, Mechanicsville"
    End Sub
End Class