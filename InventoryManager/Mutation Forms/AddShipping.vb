Imports System.Data.SqlClient
Imports System.ComponentModel

Public Class AddShipping
    Private connectionString As String = "Server=localhost\INVENTORYSQL;Database=master;Trusted_Connection=True;"
    Private myConn As SqlConnection
    Private myCmd As SqlCommand
    Private myReader As SqlDataReader

    Private Sub AddShipping_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        resetTimer()
        myConn = New SqlConnection(connectionString)
        myConn.Open()
        myCmd = myConn.CreateCommand
        clearLists()
        loadItems()
        loadCenters()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        checkNulls()

        Dim item As String = cbItems.Text
        Dim quantity As String = txtQuantity.Text
        Dim centerNumber As String = cbCenter.Text
        Dim MESD As String = txtMESD.Text

        If centerNumber <> "" Then
            centerNumber = centerNumber.Substring(1, 3)
        Else
            centerNumber = "0"
        End If

        Dim command As String = ""
        command = "INSERT INTO Shipping VALUES ((SELECT noninventoried_ID l_id FROM NonInventoried WHERE noninventoried_name = '" + item + "'), " +
            quantity + ", " + centerNumber + ", " + MESD + ", SYSDATETIME(), '" + getInitials() + "');"
        myCmd.CommandText = command
        Try
            myReader = myCmd.ExecuteReader
            MsgBox("Success!")
            LogShippingAdd(item, quantity)
            myReader.Close()
            Me.Close()
        Catch ex As Exception
            LogError(ex.ToString)
            MsgBox("Error, check logs")
        End Try
    End Sub

    Private Sub checkNulls()
        'TODO
    End Sub

    Private Sub loadItems()
        Dim items As New List(Of String)

        cbItems.Items.Clear()
        items = LoadItemsFromSQL()

        For Each item As String In items
            cbItems.Items.Add(item)
        Next
    End Sub

    Private Sub loadCenters()
        Dim centers As New List(Of String)

        cbCenter.Items.Clear()
        centers = LoadCentersFromSQL()

        For Each center As String In centers
            cbCenter.Items.Add(center)
        Next
    End Sub

    Private Sub clearLists()
        txtQuantity.Clear()
        txtMESD.Clear()
        cbItems.SelectedIndex = -1
        cbCenter.SelectedIndex = -1
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
End Class