Imports System.Data.SqlClient

'This menu loads all the information of the centers from SQL and allows the user to search through a combolist to get the necessary information.
Public Class CenterInfoMenu
    Private myConn As SqlConnection
    Private myCmd As SqlCommand
    Private myReader As SqlDataReader

    Private center As New Center("", "", "", "", "", "", "", "", "", "", "", "")

    Private Sub CenterInfoMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Connect to SQL DB
        resetTimer()
        myConn = New SqlConnection(connectionString)
        myConn.Open()
        myCmd = myConn.CreateCommand
        loadCenters()
    End Sub

    Private Sub loadCenters()
        Dim centers As New List(Of String)

        'clears list and gets list of centers from UpdateCenterInfo.vb module
        cbCenter.Items.Clear()
        centers = LoadCentersFromSQL()

        'Adds each center returned to list
        For Each center As String In centers
            cbCenter.Items.Add(center)
        Next
    End Sub

    Private Sub cbCenter_TextChanged(sender As Object, e As EventArgs) Handles cbCenter.TextChanged
        checkSQLInjection(cbCenter.Text)
        cbCenter.SelectionStart = cbCenter.Text.Length
    End Sub

    Private Sub cbCenter_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbCenter.SelectedValueChanged
        'If cbCenter is not empty, grab the center number
        'ex: '115, AMF Sunset Lanes' -> 115
        If cbCenter.Text <> "" Then
            center.centerNumber = cbCenter.Text.Substring(0, 3)
            getInfo(center.centerNumber)
        End If
    End Sub

    Private Sub getInfo(ByVal centerNumber As String)
        'First, collect center information
        myCmd.CommandText = "SELECT center_number, name, region, district, address, city, state, zip_code, circuit_provider, circuit_id, wan " +
                            "FROM Center " +
                            "WHERE center_number = " + center.centerNumber + ";"
        Try
            myReader = myCmd.ExecuteReader()
            Do While myReader.Read()
                'Checks every index of the query (machine_name, asset_tag, etc) for null values.
                'If it finds a null, it replaces the value with "null", otherwise it stores value into the corresponding variables.
                For i As Integer = 0 To 10
                    Select Case i
                        Case 1
                            If myReader.IsDBNull(i) Then
                                center.name = "null"
                            Else
                                center.name = myReader.GetString(i)
                            End If
                        Case 2
                            If myReader.IsDBNull(i) Then
                                center.region = "null"
                            Else
                                center.region = myReader.GetString(i)
                            End If
                        Case 3
                            If myReader.IsDBNull(i) Then
                                center.district = "null"
                            Else
                                center.district = myReader.GetString(i)
                            End If
                        Case 4
                            If myReader.IsDBNull(i) Then
                                center.address = "null"
                            Else
                                center.address = myReader.GetString(i)
                            End If
                        Case 5
                            If myReader.IsDBNull(i) Then
                                center.city = "null"
                            Else
                                center.city = myReader.GetString(i)
                            End If
                        Case 6
                            If myReader.IsDBNull(i) Then
                                center.state = "null"
                            Else
                                center.state = myReader.GetString(i)
                            End If
                        Case 7
                            If myReader.IsDBNull(i) Then
                                center.zipCode = "null"
                            Else
                                center.zipCode = myReader.GetString(i)
                            End If
                        Case 8
                            If myReader.IsDBNull(i) Then
                                center.circuitProvider = "null"
                            Else
                                center.circuitProvider = myReader.GetString(i)
                            End If
                        Case 9
                            If myReader.IsDBNull(i) Then
                                center.circuitID = "null"
                            Else
                                center.circuitID = myReader.GetString(i)
                            End If
                        Case 10
                            If myReader.IsDBNull(i) Then
                                center.WAN = "null"
                            Else
                                center.WAN = myReader.GetString(i)
                            End If
                    End Select
                Next
            Loop
            loadInfo()
            myReader.Close()
        Catch ex As Exception
            LogError(ex.ToString, "CenterInfoMenu", getInitials)
            myReader.Close()
        End Try
    End Sub

    Private Sub loadInfo()
        lblAddress.Text = center.address + vbNewLine + center.city + " " + center.state + ", " + center.zipCode
        lblCircuitInfo.Text = "Circuit Provider: " + center.circuitProvider + vbNewLine + "CircuitID: " + center.circuitID + vbNewLine + "WAN Type: " + center.WAN
        lblRegDist.Text = "Region: " + center.region + vbNewLine + "District: " + center.district
    End Sub
End Class