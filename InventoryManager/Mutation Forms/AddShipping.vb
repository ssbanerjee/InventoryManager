Imports System.Data.SqlClient
Imports System.ComponentModel

Public Class AddShipping
    Private myConn As SqlConnection
    Private myCmd As SqlCommand
    Private myReader As SqlDataReader

    Private category As String

    Private Sub AddShipping_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        resetTimer()
        myConn = New SqlConnection(connectionString)
        myConn.Open()
        myCmd = myConn.CreateCommand
        clearLists()
        loadItems()
        loadCenters()
        loadCategories()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        'Checks for empty values
        If txtQuantity.Text = "" Or cbCenter.Text = "" Or txtMESD.Text = "" Then
            MsgBox("Please fill in ALL boxes." + vbNewLine + "(Does not include Category box)")
            Return
        End If

        'Local variables
        Dim item As String = lstItems.SelectedItem
        Dim quantity As String = txtQuantity.Text
        Dim centerNumber As String = cbCenter.Text
        Dim MESD As String = txtMESD.Text

        'Get center number
        If centerNumber.Substring(1, 8).Equals("In Store") Then
            centerNumber = "0"
        Else
            'ex: '#115, AMF Sunset Lanes' -> 115
            centerNumber = centerNumber.Substring(1, 3)
        End If

        If item = "" Then
            item = txtFilter.Text
        End If

        Dim command As String = ""
        command = "INSERT INTO Shipping VALUES ((SELECT noninventoried_ID FROM NonInventoried WHERE noninventoried_name = '" + item + "'), " +
            quantity + ", " + centerNumber + ", " + MESD + ", SYSDATETIME(), '" + getInitials() + "');"
        myCmd.CommandText = command
        Try
            myReader = myCmd.ExecuteReader
            MsgBox("Success!")
            LogShippingAdd(item, quantity, myCmd.CommandText)
            myReader.Close()
            Me.Close()
        Catch ex As Exception
            LogError(ex.ToString, "AddShipping", getInitials())
        End Try
    End Sub

    Private Sub loadItems()
        Dim items As New List(Of String)

        lstItems.Items.Clear()
        items = LoadItemsFromSQL(category)

        For Each item As String In items
            lstItems.Items.Add(item)
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

    Private Sub loadCategories()
        cbCategory.Items.Clear()
        myCmd.CommandText = "SELECT DISTINCT shipcat_name FROM ShippingCategory;"
        cbCategory.Items.Add("")
        Try
            myReader = myCmd.ExecuteReader
            Do While myReader.Read
                cbCategory.Items.Add(myReader.GetString(0))
            Loop
        Catch ex As Exception
            LogError(ex.ToString, "AddShipping", getInitials())
        End Try
        myReader.Close()
    End Sub

    Private Sub clearLists()
        txtQuantity.Clear()
        txtMESD.Clear()
        cbCenter.SelectedIndex = -1
        lstItems.SelectedIndex = -1
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

    Private Sub cbCategory_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbCategory.SelectedValueChanged
        category = cbCategory.SelectedItem
        loadItems()
    End Sub

    'Whenever the textbox above the list changes, it checks to see if it can find the string and highlight the value for the user
    Private Sub txtFilter_TextChanged(sender As Object, e As EventArgs) Handles txtFilter.TextChanged
        checkSQLInjection(txtFilter.Text)
        txtFilter.SelectionStart = txtFilter.TextLength
        Dim i As Integer = lstItems.FindString(txtFilter.Text)
        lstItems.SelectedIndex = i
        If txtFilter.Text = "" Then
            lstItems.SelectedIndex = -1
        End If
    End Sub

    Private Sub txtMESD_TextChanged(sender As Object, e As EventArgs) Handles txtMESD.TextChanged
        checkNum(txtMESD.Text)
        txtMESD.SelectionStart = txtMESD.TextLength
    End Sub
End Class