Imports System.Data.SqlClient
Imports System.Text

Module ShippingReport
    Private connectionString As String = "Server=localhost\INVENTORYSQL;Database=master;Trusted_Connection=True;"
    Private myConn As SqlConnection
    Private myCmd As SqlCommand
    Private myReader As SqlDataReader

    Dim machines As New ArrayList()

    Public Function getShippingReport() As ArrayList
        myConn = New SqlConnection(connectionString)
        myConn.Open()
        myCmd = myConn.CreateCommand

        machines.Clear()
        machines.Add("Model,Asset #,Serial #,Machine Name,Issued To,Cond.,Cost Center,Ticket Number,IMEI,SIM,Technician")

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
        Dim machineCenterNumber As String = ""
        Dim machineTicketNumber As String = ""
        Dim technician As String = ""

        'name 0, model 1, location 2, asset tag 3, serial 4, condition 5, cost center 6, sim 7, imei 8, aqc 9, rec 10, m center 11
        myCmd.CommandText = "SELECT m.machine_name, d.model_name, m.machine_center_number, m.asset_tag, m.serial_number, a.asset_state_name, m.machine_cost_center, " +
        "m.SIM, m.IMEI, m.acquisition_date, m.received_date, m.machine_center_number, m.machine_ticket_number, m.technician " +
        "FROM Machine m JOIN Model d ON m.model_ID = d.model_ID " +
        "JOIN AssetState a ON m.asset_state_id = a.asset_state_id " +
        "WHERE m.last_modified = CONVERT (date, SYSDATETIME());"
        Try
            myReader = myCmd.ExecuteReader
            While myReader.Read()
                'Checks every index of the query (machine_name, asset_tag, etc) for null values.
                'If it finds a null, it replaces it with "null", otherwise it stores it into the corresponding variables.
                For i As Integer = 0 To 13
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
                        Case 11
                            If myReader.IsDBNull(i) Then
                                machineCenterNumber = "null"
                            Else
                                machineCenterNumber = myReader.GetInt32(i).ToString
                            End If
                        Case 12
                            If myReader.IsDBNull(i) Then
                                machineTicketNumber = "null"
                            Else
                                machineTicketNumber = myReader.GetInt32(i).ToString
                            End If
                        Case 13
                            If myReader.IsDBNull(i) Then
                                technician = "null"
                            Else
                                technician = myReader.GetString(i)
                            End If
                    End Select
                Next
                Dim m As String = model + "," + assetTag + "," + serialNumber + "," + machineName + "," +
                                          machineCenterNumber + "," + assetState + "," + costCenter + "," +
                                          machineTicketNumber + "," + IMEI + "," + SIM + "," + technician
                machines.Add(m)
            End While
        Catch ex As Exception
            LogError(ex.ToString)
            MsgBox("Failed to get Machine info, check logs")
        End Try
        myReader.Close()

        Return machines
    End Function

    Public Sub printShippingReport(ByVal machinelist As ArrayList)
        Dim path As String = "C:\\Users\\Inventory\\Desktop\\ShippingReports"
        Dim str As New StringBuilder
        For Each m As String In machinelist
            str.Append(m + vbNewLine)
        Next

        Try
            My.Computer.FileSystem.WriteAllText(path + "\ShippingReport_" + DateTime.Now.ToString("MM-dd-yyy") + ".csv", str.ToString, False)
        Catch ex As Exception
            LogError(ex.ToString)
            MsgBox("Failed to update Shipping Report. Check Logs")
        End Try
    End Sub

End Module
