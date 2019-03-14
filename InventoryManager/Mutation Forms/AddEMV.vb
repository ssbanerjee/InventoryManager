Imports System.Data.SqlClient
Imports System.ComponentModel

Public Class AddEMV
    Private myConn As SqlConnection
    Private myCmd As SqlCommand
    Private myReader As SqlDataReader

    Public emvType As String

    Private Sub AddEMV_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        resetTimer()
        myConn = New SqlConnection(connectionString)
        myConn.Open()
        myCmd = myConn.CreateCommand
        clearLists()
        loadCenters()
        loadConditions()
        txtSerialNumber.Select()
    End Sub

    Private Sub clearLists()
        txtAssetTag.Clear()
        txtSerialNumber.Clear()
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

    Private Sub loadConditions()
        cbCondition.Items.Clear()
        myCmd.CommandText = "SELECT DISTINCT condition_name FROM Condition ORDER BY condition_name ASC;"
        myReader = myCmd.ExecuteReader
        While myReader.Read()
            cbCondition.Items.Add(myReader.GetString(0))
        End While
        myReader.Close()
    End Sub

    Private Sub cbCenter_TextChanged(sender As Object, e As EventArgs) Handles cbCenter.TextChanged
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

    Private Sub cbCenter_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbCenter.SelectedValueChanged
        'This grabs the center number from the combobox and puts it into the CostCenter textbox
        If cbCenter.Text <> "" Then
            If cbCenter.Text.Substring(1, 8).Equals("In Store") Then
                txtCostCenter.Text = ""
            Else
                txtCostCenter.Text = cbCenter.Text.Substring(1, 3)
            End If
        End If
    End Sub

    Private Sub txtName_MouseHover(sender As Object, e As EventArgs)
        pbEMV.Image = My.Resources.EMV_Name
    End Sub

    Private Sub txtName_MouseLeave(sender As Object, e As EventArgs)
        pbEMV.Image = My.Resources.EMV_Base
    End Sub

    Private Sub txtSerialNumber_MouseHover(sender As Object, e As EventArgs) Handles txtSerialNumber.MouseHover
        pbEMV.Image = My.Resources.EMV_SerialNumber
    End Sub

    Private Sub txtSerialNumber_MouseLeave(sender As Object, e As EventArgs) Handles txtSerialNumber.MouseLeave
        pbEMV.Image = My.Resources.EMV_Base
    End Sub

    Private Sub lblName_MouseHover(sender As Object, e As EventArgs)
        pbEMV.Image = My.Resources.EMV_Name
    End Sub

    Private Sub lblName_MouseLeave(sender As Object, e As EventArgs)
        pbEMV.Image = My.Resources.EMV_Base
    End Sub

    Private Sub lblSerialNumber_MouseHover(sender As Object, e As EventArgs) Handles lblSerialNumber.MouseHover
        pbEMV.Image = My.Resources.EMV_SerialNumber
    End Sub

    Private Sub lblSerialNumber_MouseLeave(sender As Object, e As EventArgs) Handles lblSerialNumber.MouseLeave
        pbEMV.Image = My.Resources.EMV_Base
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        'Local variables
        Dim assetTag As String = txtAssetTag.Text
        Dim serialNumber As String = txtSerialNumber.Text
        Dim MESD As String = txtMESD.Text
        Dim costCenter As String = txtCostCenter.Text
        Dim NewOrUsed As String = cbCondition.Text

        'Get center number if cbCenter.Text is not empty
        Dim centerNumber As String = cbCenter.Text
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

        If Not (checkAT(assetTag)) Then
            myCmd.CommandText = "INSERT INTO Machine VALUES (null, '" + serialNumber.ToUpper() + "', " + assetTag + ", '" + serialNumber.ToUpper() + "', null, null, " +
                           "(SELECT model_id FROM Model WHERE model_name = '" + emvType + "'), " + centerNumber + ", '" + costCenter +
                           "', null, '" + dteAcquisition.Value + "', SYSDATETIME(), 2, (SELECT condition_id FROM Condition WHERE condition_name = '" + NewOrUsed + "'), " + MESD + ", '" + getInitials() + "');"
            Try
                myReader = myCmd.ExecuteReader
                MsgBox("Success!")
                LogMachineAdd("EMV", serialNumber, myCmd.CommandText)
                myReader.Close()
                Close()
            Catch ex As Exception
                myReader.Close()
                LogError(ex.ToString, "AddEMV", getInitials())
            End Try
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
            LogError(ex.ToString, "AddLaptop", getInitials())
            myReader.Close()
            Return False
        End Try
    End Function

    Private Sub txtAssetTag_TextChanged(sender As Object, e As EventArgs) Handles txtAssetTag.TextChanged
        'Enforces only numerical input
        checkNum(txtAssetTag.Text)

        'Checks length of AT. If greater than 6, clear text and input last character
        'If txtAssetTag.TextLength > 6 Then
        '    Dim character As String = txtAssetTag.Text(6)
        '    txtAssetTag.Text = character
        'End If
        If txtAssetTag.TextLength > 5 Then
            cbCenter.Select()
        End If
        txtAssetTag.SelectionStart = txtAssetTag.TextLength
    End Sub

    Private Sub txtSerialNumber_TextChanged(sender As Object, e As EventArgs) Handles txtSerialNumber.TextChanged
        checkSQLInjection(txtSerialNumber.Text)
        txtSerialNumber.SelectionStart = txtSerialNumber.TextLength

        'If (txtSerialNumber.TextLength > 10) Then
        '    txtAssetTag.Select()
        'End If
    End Sub

    Private Sub txtCostCenter_TextChanged(sender As Object, e As EventArgs) Handles txtCostCenter.TextChanged
        checkSQLInjection(txtCostCenter.Text)
        txtCostCenter.SelectionStart = txtCostCenter.TextLength
    End Sub

    Private Sub AddEMV_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        myConn.Close()
    End Sub

    Private Sub txtMESD_TextChanged(sender As Object, e As EventArgs) Handles txtMESD.TextChanged
        checkNum(txtMESD.Text)
        txtMESD.SelectionStart = txtMESD.TextLength
    End Sub
End Class