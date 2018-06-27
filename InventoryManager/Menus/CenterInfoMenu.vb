Imports System.Data.SqlClient

Public Class CenterInfoMenu
    Private connectionString As String = "Server=localhost\INVENTORYSQL;Database=master;Trusted_Connection=True;"
    Private myConn As SqlConnection
    Private myCmd As SqlCommand
    Private myReader As SqlDataReader

    Private centerNumber As String
    Private centerName As String
    Private region As String
    Private district As String
    Private address As String
    Private city As String
    Private state As String
    Private zip As String
    Private circuitProvider As String
    Private circuitID As String

    Private Sub CenterInfoMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        resetTimer()
        myConn = New SqlConnection(connectionString)
        myConn.Open()
        myCmd = myConn.CreateCommand
        loadCenters()
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

    Private Sub cbCenter_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbCenter.SelectedValueChanged
        If cbCenter.Text <> "" Then
            centerNumber = cbCenter.Text.Substring(1, 3)
            getInfo(centerNumber)
        End If
    End Sub

    Private Sub getInfo(ByVal centerNumber As String)
        'First, collect center information
        myCmd.CommandText = "SELECT center_number, name, region, district, address, city, state, zip_code, circuit_provider, circuit_id " +
                            "FROM Center " +
                            "WHERE center_number = " + centerNumber + ";"
        Try
            myReader = myCmd.ExecuteReader()
            Do While myReader.Read()
                'Checks every index of the query (machine_name, asset_tag, etc) for null values.
                'If it finds a null, it replaces the value with "null", otherwise it stores value into the corresponding variables.
                For i As Integer = 0 To 9
                    Select Case i
                        Case 1
                            If myReader.IsDBNull(i) Then
                                Name = "null"
                            Else
                                Name = myReader.GetString(i)
                            End If
                        Case 2
                            If myReader.IsDBNull(i) Then
                                region = "null"
                            Else
                                region = myReader.GetString(i)
                            End If
                        Case 3
                            If myReader.IsDBNull(i) Then
                                district = "null"
                            Else
                                district = myReader.GetString(i)
                            End If
                        Case 4
                            If myReader.IsDBNull(i) Then
                                address = "null"
                            Else
                                address = myReader.GetString(i)
                            End If
                        Case 5
                            If myReader.IsDBNull(i) Then
                                city = "null"
                            Else
                                city = myReader.GetString(i)
                            End If
                        Case 6
                            If myReader.IsDBNull(i) Then
                                state = "null"
                            Else
                                state = myReader.GetString(i)
                            End If
                        Case 7
                            If myReader.IsDBNull(i) Then
                                zip = "null"
                            Else
                                zip = myReader.GetString(i)
                            End If
                        Case 8
                            If myReader.IsDBNull(i) Then
                                circuitProvider = "null"
                            Else
                                circuitProvider = myReader.GetString(i)
                            End If
                        Case 9
                            If myReader.IsDBNull(i) Then
                                circuitID = "null"
                            Else
                                circuitID = myReader.GetString(i)
                            End If
                    End Select
                Next
            Loop
            loadInfo()
            myReader.Close()
        Catch ex As Exception
            LogError(ex.ToString)
            MsgBox("Error, check logs")
            myReader.Close()
        End Try

        'Next, collect phone number information and clear the existing list
        lblPhoneNumbers.Text = ""
        myCmd.CommandText = "SELECT role, employee_name, phone_number " +
                            "FROM PhoneNumber " +
                            "WHERE center_number = " + centerNumber + ";"
        Try
            myReader = myCmd.ExecuteReader()
            Do While myReader.Read()
                Dim role As String = ""
                Dim empName As String = ""
                Dim phoneNum As String = ""

                For i As Integer = 0 To 2
                    Select Case i
                        Case 0
                            If myReader.IsDBNull(i) Then
                                role = "null"
                            Else
                                role = myReader.GetString(i)
                            End If
                        Case 1
                            If myReader.IsDBNull(i) Then
                                empName = "null"
                            Else
                                empName = myReader.GetString(i)
                            End If
                        Case 2
                            If myReader.IsDBNull(i) Then
                                phoneNum = "null"
                            Else
                                phoneNum = myReader.GetString(i)
                            End If
                    End Select
                Next
                lblPhoneNumbers.Text += role + ": " + empName + ". Phone Number: " + phoneNum + vbNewLine
            Loop
            myReader.Close()
        Catch ex As Exception
            LogError(ex.ToString)
            MsgBox("Error, check logs")
            myReader.Close()
        End Try
    End Sub

    Private Sub loadInfo()
        lblAddress.Text = address + vbNewLine + city + " " + state + ", " + zip
        lblCircuitInfo.Text = "Circuit Provider: " + circuitProvider + vbNewLine + "CircuitID: " + circuitID
        lblRegDist.Text = "Region: " + region + vbNewLine + "District: " + district
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        updateInfo()
    End Sub

    Private Sub updateInfo()
        Dim fileName As String = "\\rich-srv-pf04\Information Systems\Network Services\Telecom\5_Inventory\MASTER SITE INVENTORY 4_10_18.xlsx"

    End Sub
End Class