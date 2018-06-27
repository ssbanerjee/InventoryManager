Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Text.RegularExpressions
Imports System.IO

Public Class AddEMV
    Private connectionString As String = "Server=localhost\INVENTORYSQL;Database=master;Trusted_Connection=True;"
    Private myConn As SqlConnection
    Private myCmd As SqlCommand
    Private myReader As SqlDataReader

    Private Sub AddEMV_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        resetTimer()
        myConn = New SqlConnection(connectionString)
        myConn.Open()
        myCmd = myConn.CreateCommand
        clearLists()
        loadCenters()
    End Sub

    Private Sub clearLists()
        txtAssetTag.Clear()
        txtSerialNumber.Clear()
        cbCenter.SelectedIndex = -1
        txtCostCenter.Clear()
    End Sub

    Private Sub loadCenters()
        Dim centers As New List(Of String)

        cbCenter.Items.Clear()
        centers = LoadCentersFromSQL()

        For Each center As String In centers
            cbCenter.Items.Add(center)
        Next
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
        If cbCenter.Text <> "" Then
            txtCostCenter.Text = cbCenter.Text.Substring(1, 3)
        End If
    End Sub

    Private Sub chCostCenter_CheckedChanged(sender As Object, e As EventArgs) Handles chCostCenter.CheckedChanged
        If chCostCenter.Checked Then
            txtCostCenter.ReadOnly = False
        Else
            txtCostCenter.ReadOnly = True
            If cbCenter.Text <> "" Then
                txtCostCenter.Text = cbCenter.Text.Substring(1, 3)
            End If
        End If
    End Sub

    Private Sub txtName_MouseHover(sender As Object, e As EventArgs) Handles txtName.MouseHover
        pbEMV.Image = My.Resources.EMV_Name
    End Sub

    Private Sub txtName_MouseLeave(sender As Object, e As EventArgs) Handles txtName.MouseLeave
        pbEMV.Image = My.Resources.EMV_Base
    End Sub

    Private Sub txtSerialNumber_MouseHover(sender As Object, e As EventArgs) Handles txtSerialNumber.MouseHover
        pbEMV.Image = My.Resources.EMV_SerialNumber
    End Sub

    Private Sub txtSerialNumber_MouseLeave(sender As Object, e As EventArgs) Handles txtSerialNumber.MouseLeave
        pbEMV.Image = My.Resources.EMV_Base
    End Sub

    Private Sub lblName_MouseHover(sender As Object, e As EventArgs) Handles lblName.MouseHover
        pbEMV.Image = My.Resources.EMV_Name
    End Sub

    Private Sub lblName_MouseLeave(sender As Object, e As EventArgs) Handles lblName.MouseLeave
        pbEMV.Image = My.Resources.EMV_Base
    End Sub

    Private Sub lblSerialNumber_MouseHover(sender As Object, e As EventArgs) Handles lblSerialNumber.MouseHover
        pbEMV.Image = My.Resources.EMV_SerialNumber
    End Sub

    Private Sub lblSerialNumber_MouseLeave(sender As Object, e As EventArgs) Handles lblSerialNumber.MouseLeave
        pbEMV.Image = My.Resources.EMV_Base
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim machineName As String = txtName.Text
        Dim assetTag As String = txtAssetTag.Text
        Dim serialNumber As String = txtSerialNumber.Text
        Dim MESD As String = txtMESD.Text
        Dim costCenter As String = txtCostCenter.Text

        Dim centerNumber As String = cbCenter.Text
        If centerNumber <> "" Then
            centerNumber = centerNumber.Substring(1, 3)
        Else
            centerNumber = "0"
        End If

        myCmd.CommandText = "INSERT INTO Machine VALUES (null, '" + machineName + "', " + assetTag + ", '" + serialNumber + "', null, null, " +
                            "(SELECT model_id FROM Model WHERE model_name = 'VeriFone EMV'), " + centerNumber + ", '" + costCenter + "', SYSDATETIME(), null, SYSDATETIME(), 2, 1, " + MESD + ", '" + getInitials() + "');"
        Try
            myReader = myCmd.ExecuteReader
            MsgBox("Success!")
            LogMachineAdd("EMV", machineName)
            myReader.Close()
            Me.Close()
        Catch ex As Exception
            LogError(ex.ToString)
            MsgBox("Error, check logs")
        End Try
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

    Private Sub txtCostCenter_TextChanged(sender As Object, e As EventArgs) Handles txtCostCenter.TextChanged
        checkSQLInjection(txtCostCenter.Text)
        txtCostCenter.SelectionStart = txtCostCenter.TextLength
    End Sub

    Private Sub txtName_TextChanged(sender As Object, e As EventArgs) Handles txtName.TextChanged
        checkSQLInjection(txtName.Text)
        txtName.SelectionStart = txtName.TextLength
    End Sub

    Private Sub AddEMV_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        myConn.Close()
    End Sub

End Class