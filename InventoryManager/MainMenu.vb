'Imports System.Data.SqlClient
Imports Oracle.ManagedDataAccess.Client

Public Class MainMenu
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
    Private results As String

    Private Sub MainMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'myConn = New SqlConnection(connectionString)
        myCmd.Connection = myConn
        myConn.Open()
        myCmd.CommandType = CommandType.Text
        myCmd = myConn.CreateCommand
    End Sub

    Private Sub btnAddMachine_Click(sender As Object, e As EventArgs) Handles btnAddMachine.Click
        AddMachineMenu.ShowDialog()
    End Sub

    Private Sub btnAddMachine_MouseHover(sender As Object, e As EventArgs) Handles btnAddMachine.MouseHover
        btnAddMachine.Image = My.Resources.addMachine_selected
    End Sub

    Private Sub btnAddMachine_MouseLeave(sender As Object, e As EventArgs) Handles btnAddMachine.MouseLeave
        btnAddMachine.Image = My.Resources.addMachine
    End Sub

    Private Sub btnEditMachine_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Search.ShowDialog()
    End Sub

    Private Sub btnEdit_MouseHover(sender As Object, e As EventArgs) Handles btnEdit.MouseHover
        btnEdit.Image = My.Resources.editInfo_selected
    End Sub

    Private Sub btnEdit_MouseLeave(sender As Object, e As EventArgs) Handles btnEdit.MouseLeave
        btnEdit.Image = My.Resources.editInfo
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        'TODO
    End Sub

    Private Sub btnSearch_MouseHover(sender As Object, e As EventArgs) Handles btnSearch.MouseHover
        btnSearch.Image = My.Resources.equipmentRequest_selected
    End Sub

    Private Sub btnSearch_MouseLeave(sender As Object, e As EventArgs) Handles btnSearch.MouseLeave
        btnSearch.Image = My.Resources.equipmentRequest
    End Sub
End Class
