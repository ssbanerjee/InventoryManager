Imports System.Data.SqlClient
Imports System.Text.RegularExpressions

Public Class AddEMV
    'Private connectionString As String = "Server=INVSUXS-D; Database=INVENTORYSQL; User Id=SQLadmin; Password=1NV3nt0ry5uXX5"
    Private connectionString As String = "Server=localhost\INVENTORYSQL;Database=master;Trusted_Connection=True;"
    Private myConn As SqlConnection
    Private myCmd As SqlCommand
    Private myReader As SqlDataReader
    Private results As String

    Private Sub AddEMV_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        cbCenter.Items.Clear()
        Dim centerNumberInt As Integer
        Dim centerNumber As String = ""
        Dim centerName As String = ""

        myCmd.CommandText = "SELECT center_number, name FROM Center WHERE center_number > 0 ORDER BY center_number ASC"
        myReader = myCmd.ExecuteReader
        While myReader.Read()
            centerNumberInt = myReader.GetInt32(0)
            centerName = myReader.GetString(1)

            If centerNumberInt < 100 Then
                centerNumber = "0" + centerNumberInt.ToString
            Else
                centerNumber = centerNumberInt.ToString
            End If

            cbCenter.Items.Add("#" + centerNumber + ", " + centerName)
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
        If cbCenter.Text <> "" Then
            txtCostCenter.Text = cbCenter.Text.Substring(1, 3)
        End If
    End Sub

    Private Sub chCostCenter_CheckedChanged(sender As Object, e As EventArgs) Handles chCostCenter.CheckedChanged
        If chCostCenter.Checked Then
            txtCostCenter.ReadOnly = False
        Else
            txtCostCenter.ReadOnly = True
            txtCostCenter.Text = cbCenter.Text.Substring(1, 3)
        End If
    End Sub

    Private Sub txtAssetTag_TextChanged(sender As Object, e As EventArgs) Handles txtAssetTag.TextChanged
        Dim digitsOnly As Regex = New Regex("[^\d]")
        txtAssetTag.Text = digitsOnly.Replace(txtAssetTag.Text, "")

        If txtAssetTag.TextLength > 6 Then
            Dim character As String = txtAssetTag.Text(6)
            txtAssetTag.Text = character
            txtAssetTag.SelectionStart = txtAssetTag.TextLength
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
        Dim centerNumber As String = cbCenter.Text.Substring(1, 3)
        Dim costCenter As String = txtCostCenter.Text

        myCmd.CommandText = "INSERT INTO Machine VALUES (null, '" + machineName + "', " + assetTag + ", '" + serialNumber + "', null, null, " +
                            "(SELECT model_id FROM Model WHERE model_name = 'VeriFone EMV'), " + centerNumber + ", '" + costCenter + "');"
        Try
            myReader = myCmd.ExecuteReader
            MsgBox("Success!")
            myReader.Close()
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Class