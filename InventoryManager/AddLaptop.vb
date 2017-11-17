Imports System.Data.SqlClient
Imports System.Text.RegularExpressions

Public Class AddLaptop
    'Private connectionString As String = "Server=INVSUXS-D; Database=INVENTORYSQL; User Id=SQLadmin; Password=1NV3nt0ry5uXX5"
    Private connectionString As String = "Server=localhost\INVENTORYSQL;Database=master;Trusted_Connection=True;"
    Private myConn As SqlConnection
    Private myCmd As SqlCommand
    Private myReader As SqlDataReader
    Private results As String
    Private Sub AddLaptop_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        myConn = New SqlConnection(connectionString)
        myConn.Open()
        myCmd = myConn.CreateCommand
        btnBack.Visible = False
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
        Dim centerNumber As String = cbCenter.Text.Substring(1, 3)
        Dim costCenter As String = txtCostCenter.Text

        checkNulls(employee, machineName, assetTag, SIM, IMEI, serialNumber)

        If (checkUsername(employee)) And (serialNumber <> "") Then
            Dim command As String = ""
            command = "INSERT INTO Machine VALUES ((SELECT employee_id FROM Employee WHERE employee_username = " + employee + "), " + machineName + ", " + assetTag + ", " +
                serialNumber + ", " + SIM + ", " + IMEI + ", (SELECT model_id FROM Model WHERE model_name = '" + model + "'), " + centerNumber + ", '" + costCenter + "');"
            myCmd.CommandText = command
            Try
                myReader = myCmd.ExecuteReader
                MsgBox("Success!")
                myReader.Close()
                Me.Close()
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If

        'Dim results As String = ""
        'Do While myReader.Read()
        '    results += myReader.GetString(0) + " " + myReader.GetString(1) + vbCrLf
        'Loop
        'MsgBox(results)
    End Sub

    Private Sub checkNulls(ByRef employee As String, ByRef machineName As String, ByRef assetTag As String, ByRef SIM As String, ByRef IMEI As String, ByRef serialNumber As String)
        If employee = "" Then
            employee = "null"
        Else
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

    Private Function checkUsername(ByVal employee As String) As Boolean
        If employee = "null" Then
            Return True
        End If
        Dim dataReader As SqlDataReader
        Dim SQLCommand As SqlCommand
        SQLCommand = myConn.CreateCommand
        Dim command As String = "SELECT employee_id FROM Employee WHERE employee_username = " + employee + ";"
        SQLCommand.CommandText = command
        Try
            dataReader = SQLCommand.ExecuteReader
            If (dataReader.Read()) Then
                dataReader.Close()
                Return True
            Else
                dataReader.Close()
                MsgBox("Username not found")
                txtUsername.Clear()
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try
    End Function

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Close()
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

    Private Sub loadModels()
        cbModel.Items.Clear()
        myCmd.CommandText = "SELECT DISTINCT model_name FROM Model WHERE category_id = 1 ORDER BY model_name ASC;"
        myReader = myCmd.ExecuteReader
        While myReader.Read()
            cbModel.Items.Add(myReader.GetString(0))
        End While
        myReader.Close()
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

    Private Sub clearLists()
        txtUsername.Clear()
        txtMachineName.Clear()
        txtAssetTag.Clear()
        txtSerialNumber.Clear()
        txtSIM.Clear()
        txtIMEI.Clear()
        cbModel.SelectedIndex = -1
        cbCenter.SelectedIndex = -1
        txtCostCenter.Clear()
    End Sub
End Class