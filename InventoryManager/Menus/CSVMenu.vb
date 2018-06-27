Imports System.Data.SqlClient
Imports System.Text

Public Class CSVMenu
    Private connectionString As String = "Server=localhost\INVENTORYSQL;Database=master;Trusted_Connection=True;"
    Private myConn As SqlConnection
    Private myCmd As SqlCommand
    Private myReader As SqlDataReader

    Dim machines As New ArrayList()

    Private Sub CSVMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        resetTimer()
        myConn = New SqlConnection(connectionString)
        myConn.Open()
        myCmd = myConn.CreateCommand
        loadMachines()
    End Sub

    Private Sub loadMachines()
        lstMachines.Items.Clear()
        machines.Clear()
        Dim str As String = "machineName,model,location,assetTag,serialNumber,assetState,costCenter,SIM,IMEI,acquisitionDate,receivedDate"
        machines.Add(str)

        Dim result As String = ""
        Dim machineName As String = ""
        Dim model As String = ""
        Dim location As String = ""
        Dim assetTag As String = ""
        Dim serialNumber As String = ""
        Dim assetState As String = ""
        Dim costCenter As String = ""
        Dim SIM As String = ""
        Dim IMEI As String = ""
        Dim acquisitionDate As String = ""
        Dim receivedDate As String = ""
        'name 0, model 1, location 2, asset tag 3, serial 4, condition 5, cost center 6, sim 7, imei 8, aqc 9, rec 10
        myCmd.CommandText = "SELECT m.machine_name, d.model_name, m.machine_center_number, m.asset_tag, m.serial_number, a.asset_state_name, m.machine_cost_center, " +
        "m.SIM, m.IMEI, m.acquisition_date, m.received_date " +
        "FROM Machine m JOIN Model d ON m.model_ID = d.model_ID " +
        "JOIN AssetState a ON m.asset_state_id = a.asset_state_id " +
        "WHERE m.last_modified = CONVERT (date, SYSDATETIME());"
        Try
            myReader = myCmd.ExecuteReader
            While myReader.Read()
                'Checks every index of the query (machine_name, asset_tag, etc) for null values.
                'If it finds a null, it replaces it with "null", otherwise it stores it into the corresponding variables.
                For i As Integer = 0 To 10
                    Select Case i
                        Case 0
                            If myReader.IsDBNull(i) Then
                                machineName = "null"
                            Else
                                machineName = myReader.GetString(i)
                            End If
                        Case 1
                            If myReader.IsDBNull(i) Then
                                model = "null"
                            Else
                                model = myReader.GetString(i)
                            End If
                        Case 2
                            If myReader.IsDBNull(i) Then
                                location = "null"
                            Else
                                location = myReader.GetInt32(i).ToString
                            End If
                        Case 3
                            If myReader.IsDBNull(i) Then
                                assetTag = "null"
                            Else
                                assetTag = myReader.GetInt32(i).ToString
                            End If
                        Case 4
                            If myReader.IsDBNull(i) Then
                                serialNumber = "null"
                            Else
                                serialNumber = myReader.GetString(i)
                            End If
                        Case 5
                            If myReader.IsDBNull(i) Then
                                assetState = "null"
                            Else
                                assetState = myReader.GetString(i)
                            End If
                        Case 6
                            If myReader.IsDBNull(i) Then
                                costCenter = "null"
                            Else
                                costCenter = myReader.GetString(i)
                            End If
                        Case 7
                            If myReader.IsDBNull(i) Then
                                SIM = "null"
                            Else
                                SIM = myReader.GetString(i)
                            End If
                        Case 8
                            If myReader.IsDBNull(i) Then
                                IMEI = "null"
                            Else
                                IMEI = myReader.GetString(i)
                            End If
                        Case 9
                            If myReader.IsDBNull(i) Then
                                acquisitionDate = "null"
                            Else
                                acquisitionDate = myReader.GetDateTime(i).ToString("MM/dd/yyy")
                            End If
                        Case 10
                            If myReader.IsDBNull(i) Then
                                receivedDate = "null"
                            Else
                                receivedDate = myReader.GetDateTime(i).ToString("MM/dd/yyy")
                            End If
                    End Select
                Next
                Dim m As String = machineName + "," + model + "," + location + "," + assetTag + "," + serialNumber + "," +
                                          assetState + "," + costCenter + "," + SIM + "," + IMEI + "," + acquisitionDate + "," + receivedDate
                machines.Add(m)
                m = m.Replace(",", vbTab)
                lstMachines.Items.Add(m)
            End While
        Catch ex As Exception
            LogError(ex.ToString)
            MsgBox("Error, check logs")
        End Try
        myReader.Close()
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
                My.Computer.FileSystem.WriteAllText(path + "\TEST.csv", str.ToString, False)
                MsgBox("Success!")
            Catch ex As Exception
                LogError(ex.ToString)
                MsgBox("Error, check logs")
            End Try
        End If
    End Sub

    Private Sub btnImport_Click(sender As Object, e As EventArgs) Handles btnImport.Click
        Dim result As String = ""
        Dim machineName As String = ""
        Dim model As String = ""
        Dim location As String = ""
        Dim assetTag As String = ""
        Dim serialNumber As String = ""
        Dim assetState As String = ""
        Dim costCenter As String = ""
        Dim SIM As String = ""
        Dim IMEI As String = ""
        Dim acquisitionDate As String = ""
        Dim receivedDate As String = ""

        Dim path As String = ""
        Dim dialog As New OpenFileDialog
        dialog.InitialDirectory = "C:\"
        dialog.Title = "Choose file location"
        dialog.Filter = "csv files (*.csv)|*.csv"
        If dialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            path = dialog.FileName
            Using csvReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(path)
                csvReader.TextFieldType = FileIO.FieldType.Delimited
                csvReader.SetDelimiters(",")
                Dim currentRow As String()
                currentRow = csvReader.ReadFields
                Do
                    Try
                        currentRow = csvReader.ReadFields
                        Dim currentField As String
                        Dim i As Integer = 0
                        For Each currentField In currentRow
                            Select Case i
                                Case 0
                                    machineName = currentField
                                Case 1
                                    model = currentField
                                Case 2
                                    location = currentField
                                Case 3
                                    assetTag = currentField
                                Case 4
                                    serialNumber = currentField
                                Case 5
                                    assetState = currentField
                                Case 6
                                    costCenter = currentField
                                Case 7
                                    SIM = currentField
                                Case 8
                                    IMEI = currentField
                                Case 9
                                    acquisitionDate = currentField
                                Case 10
                                    receivedDate = currentField
                            End Select
                            i += 1
                            If i > 10 Then
                                i = 0
                            End If
                        Next
                        myCmd.CommandText = "INSERT INTO Machine VALUES (null, '" + machineName + "', " + assetTag + ", '" + serialNumber + "', null, null, " +
                 "(SELECT model_id FROM Model WHERE model_name = '" + model + "'), " + location + ", '" + costCenter + "', SYSDATETIME(), null, SYSDATETIME(), " +
                 "(SELECT asset_state_id FROM AssetState WHERE asset_state_name = '" + assetState + "'), 1);"
                        Try
                            myReader = myCmd.ExecuteReader
                            MsgBox("Success!")
                            myReader.Close()
                            loadMachines()
                        Catch ex As Exception
                            LogError(ex.ToString)
                            MsgBox("Error, check logs")
                            myReader.Close()
                        End Try
                    Catch ex As Exception
                        LogError(ex.ToString)
                        MsgBox("Error, check logs")
                    End Try
                Loop While Not csvReader.EndOfData
            End Using

        End If
    End Sub
End Class