Imports System.Data.SqlClient
Imports System.Text

Public Class ShippingMenu
    Private connectionString As String = "Server=localhost\INVENTORYSQL;Database=master;Trusted_Connection=True;"
    Private myConn As SqlConnection
    Private myCmd As SqlCommand
    Private myReader As SqlDataReader

    Private machines As New ArrayList()

    Private Sub ShippingMenu_Load(sender As Object, e As EventArgs) Handles Me.Load
        resetTimer()
        myConn = New SqlConnection(connectionString)
        myConn.Open()
        myCmd = myConn.CreateCommand
        loadMachines()
    End Sub

    Private Sub loadMachines()
        lstMachines.Items.Clear()
        machines.Clear()
        machines = getShippingReport()
        For Each m In machines
            m = m.Replace(",", vbTab)
            lstMachines.Items.Add(m)
        Next
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Dim path As String = ""
        Dim dialog As New FolderBrowserDialog()
        Dim str As New StringBuilder
        For Each m As String In machines
            str.Append(m + vbNewLine)
        Next

        dialog.RootFolder = Environment.SpecialFolder.Desktop
        dialog.SelectedPath = "C:\"
        dialog.Description = "Choose where to save the file"
        If dialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            path = dialog.SelectedPath
            Try
                My.Computer.FileSystem.WriteAllText(path + "\" + DateTime.Now.ToString("MM-dd-yyy") + ".csv", str.ToString, False)
                MsgBox("Success!")
            Catch ex As Exception
                LogError(ex.ToString)
                MsgBox("Error, check logs")
            End Try
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        AddShipping.ShowDialog()
    End Sub
End Class