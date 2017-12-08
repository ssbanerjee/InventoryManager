'Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Text.RegularExpressions
Imports Oracle.ManagedDataAccess.Client

Public Class AddWorkstation
    'The following lines are to be substituted in for the ORACLE version
    Private connectionString As String = "DATA SOURCE=jasmine.cs.vcu.edu:20037/XE;PASSWORD=V00673996;PERSIST SECURITY INFO=True;USER ID=BANERJEES2"
    Private myConn As New OracleConnection(connectionString)
    Private myCmd As New OracleCommand
    Private myReader As OracleDataReader
    'command.CommandText = cmd
    'command.CommandType = CommandType.Text


    'The following lines are to be substituted in for the MYSQL version
    'Private connectionString As String = "Server=localhost\INVENTORYSQL;Database=master;Trusted_Connection=True;"
    'Private myConn As SqlConnection
    'Private myCmd As SqlCommand
    'Private myReader As SqlDataReader

    Private Sub AddWorkstation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'myConn = New SqlConnection(connectionString)
        myCmd.Connection = myConn
        myConn.Open()
        myCmd.CommandType = CommandType.Text
        myCmd = myConn.CreateCommand
        clearLists()
        loadCenters()
        loadModels()
    End Sub

    Private Sub clearLists()
        txtMachineName.Clear()
        txtAssetTag.Clear()
        txtSerialNumber.Clear()
        cbModel.SelectedIndex = -1
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

    Private Sub loadModels()
        cbModel.Items.Clear()
        myCmd.CommandText = "SELECT DISTINCT model_name FROM Model WHERE category_id = 2 ORDER BY model_name ASC"
        myReader = myCmd.ExecuteReader
        While myReader.Read()
            cbModel.Items.Add(myReader.GetString(0))
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

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim centerNumber As String = ""

        'Checks if a center number and a model type has been selected
        If cbCenter.Text <> "" And cbModel.Text <> "" Then
            centerNumber = cbCenter.Text.Substring(1, 3)
            Dim machineName As String = txtMachineName.Text
            Dim model As String = cbModel.Text
            Dim assetTag As String = txtAssetTag.Text
            Dim serialNumber As String = txtSerialNumber.Text
            Dim costCenter As String = txtCostCenter.Text

            'checkNulls checks to see if any of the textboxes are empty.
            checkNulls(machineName, assetTag, serialNumber)

            If serialNumber <> "" Then
                myCmd.CommandText = "INSERT INTO Machine VALUES (0, null, " + machineName + ", " + assetTag + ", " + serialNumber + ", null, null, " +
                 "(SELECT model_id FROM Model WHERE model_name = '" + model + "'), " + centerNumber + ", '" + costCenter + "', SYSDATE, null);"
                Try
                    myReader = myCmd.ExecuteReader
                    MsgBox("Success!")
                    myReader.Close()
                    Me.Close()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            End If

        Else
            MsgBox("Enter both a Center Number and select a Model")
        End If

    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Close()
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

    'This function does a simple check against SQL Injection by removing all single quotes, double quotes, and semicolons from input
    Private Sub checkSQLInjection(ByRef input As String)
        input = input.Replace("""", "")
        input = input.Replace("'", "")
        input = input.Replace(";", "")
    End Sub

    Private Sub txtAssetTag_TextChanged(sender As Object, e As EventArgs) Handles txtAssetTag.TextChanged
        'Enforces only numerical input
        Dim digitsOnly As Regex = New Regex("[^\d]")
        txtAssetTag.Text = digitsOnly.Replace(txtAssetTag.Text, "")

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