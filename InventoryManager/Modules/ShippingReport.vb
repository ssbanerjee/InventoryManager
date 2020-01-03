Imports System.Data.SqlClient
Imports System.Text

Module ShippingReport
    Private myConn As SqlConnection
    Private myCmd As SqlCommand
    Private myReader As SqlDataReader

    Private machines As New ArrayList()
    Private shipping As New ArrayList()

    Public Function getShippingReport() As ArrayList
        'Connect to SQL DB
        myConn = New SqlConnection(connectionString)
        myConn.Open()
        myCmd = myConn.CreateCommand

        'Clear Machine list and add header line
        machines.Clear()
        machines.Add("Model,Asset #,Serial #,Machine Name,Issued To,Cond.,Cost Center,Ticket Number,IMEI,SIM,Technician")

        'Local variables
        Dim result As String = ""
        Dim machineName As String = ""
        Dim model As String = ""
        Dim location As String = ""
        Dim assetTag As String = ""
        Dim serialNumber As String = ""
        Dim condition As String = ""
        Dim costCenter As String = ""
        Dim SIM As String = ""
        Dim IMEI As String = ""
        Dim acquisitionDate As String = ""
        Dim receivedDate As String = ""
        Dim machineCenterNumber As String = ""
        Dim machineTicketNumber As String = ""
        Dim technician As String = ""

        'name 0, model 1, location 2, asset tag 3, serial 4, condition 5, cost center 6, sim 7, imei 8, aqc 9, rec 10, center 11, mesd 12, technician 13
        myCmd.CommandText = "SELECT m.machine_name, d.name, m.center_number, m.asset_tag, m.serial_number, c.name, m.cost_center, " +
        "m.SIM, m.IMEI, m.acquisition_date, m.received_date, m.center_number, m.ticket_number, m.technician " +
        "FROM Machine m JOIN Model d ON m.modelID = d.modelID " +
        "JOIN Condition c ON m.conditionID = c.conditionID " +
        "WHERE m.last_modified = CONVERT (date, SYSDATETIME());"
        Try
            myReader = myCmd.ExecuteReader
            While myReader.Read()
                'Checks every index of the query (machine_name, asset_tag, etc) for null values.
                'If it finds a null, it replaces it with "null", otherwise it stores it into the corresponding variables.
                For i As Integer = 0 To 14
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
                                condition = "null"
                            Else
                                condition = myReader.GetString(i)
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
                                          machineCenterNumber + "," + condition + "," + costCenter + "," +
                                          machineTicketNumber + "," + IMEI + "," + SIM + "," + technician
                machines.Add(m)
            End While
        Catch ex As Exception
            LogError(ex.ToString, "ShippingReport", getInitials())
        End Try
        myReader.Close()

        Return machines
    End Function

    Public Function getShippingReportByDate(ByVal exportDate As String) As ArrayList
        'Connect to SQL DB
        myConn = New SqlConnection(connectionString)
        myConn.Open()
        myCmd = myConn.CreateCommand

        'Clear Machine list and add header line
        machines.Clear()
        machines.Add("Model,Asset #,Serial #,Machine Name,Issued To,Cond.,Cost Center,Ticket Number,IMEI,SIM,Technician,Date")

        'Local variables
        Dim result As String = ""
        Dim machineName As String = ""
        Dim model As String = ""
        Dim location As String = ""
        Dim assetTag As String = ""
        Dim serialNumber As String = ""
        Dim condition As String = ""
        Dim costCenter As String = ""
        Dim SIM As String = ""
        Dim IMEI As String = ""
        Dim acquisitionDate As String = ""
        Dim receivedDate As String = ""
        Dim machineCenterNumber As String = ""
        Dim machineTicketNumber As String = ""
        Dim technician As String = ""
        Dim lastModified As String = ""

        'name 0, model 1, location 2, asset tag 3, serial 4, condition 5, cost center 6, sim 7, imei 8, aqc 9, rec 10, center 11, mesd 12, technician 13
        myCmd.CommandText = "SELECT m.machine_name, d.name, m.center_number, m.asset_tag, m.serial_number, c.name, m.cost_center, " +
        "m.SIM, m.IMEI, m.acquisition_date, m.received_date, m.center_number, m.ticket_number, m.technician, m.last_modified " +
        "FROM Machine m JOIN Model d ON m.modelID = d.modelID " +
        "JOIN Condition c ON m.conditionID = c.conditionID " +
        "WHERE m.last_modified = '" + exportDate + "';"
        Try
            myReader = myCmd.ExecuteReader
            While myReader.Read()
                'Checks every index of the query (machine_name, asset_tag, etc) for null values.
                'If it finds a null, it replaces it with "null", otherwise it stores it into the corresponding variables.
                For i As Integer = 0 To 15
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
                                condition = "null"
                            Else
                                condition = myReader.GetString(i)
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
                        Case 14
                            If myReader.IsDBNull(i) Then
                                lastModified = "null"
                            Else
                                lastModified = myReader.GetDateTime(i).ToString("MM/dd/yyy")
                            End If
                    End Select
                Next
                Dim m As String = model + "," + assetTag + "," + serialNumber + "," + machineName + "," +
                                          machineCenterNumber + "," + condition + "," + costCenter + "," +
                                          machineTicketNumber + "," + IMEI + "," + SIM + "," + technician + "," + lastModified
                machines.Add(m)
            End While
        Catch ex As Exception
            LogError(ex.ToString, "ShippingReport", getInitials())
        End Try
        myReader.Close()

        Return machines
    End Function

    Public Function getNonInventoriedReport() As ArrayList
        'Connect to SQL DB
        myConn = New SqlConnection(connectionString)
        myConn.Open()
        myCmd = myConn.CreateCommand

        'Clearing Shipping list and add header
        shipping.Clear()
        shipping.Add("Item,Quantity,Center Number,MESD,Technician")

        'Local variables
        Dim item As String = ""
        Dim quantity As String = ""
        Dim center As String = ""
        Dim MESD As String = ""
        Dim technician As String = ""

        myCmd.CommandText = "SELECT n.name, s.quantity, s.center, s.MESD, s.technician " +
                            "FROM NonInventoried n LEFT JOIN Shipping s ON s.noninventoriedID = n.noninventoriedID " +
                            "WHERE s.last_modified = CONVERT (date, SYSDATETIME());"
        Try
            myReader = myCmd.ExecuteReader
            While myReader.Read()
                'Checks every index of the query (machine_name, asset_tag, etc) for null values.
                'If it finds a null, it replaces it with "null", otherwise it stores it into the corresponding variables.
                For i As Integer = 0 To 4
                    Select Case i
                        Case 0
                            If myReader.IsDBNull(i) Then
                                item = "null"
                            Else
                                item = myReader.GetString(i)
                            End If
                        Case 1
                            If myReader.IsDBNull(i) Then
                                quantity = "null"
                            Else
                                quantity = myReader.GetInt32(i).ToString
                            End If
                        Case 2
                            If myReader.IsDBNull(i) Then
                                center = "null"
                            Else
                                center = myReader.GetInt32(i).ToString
                            End If
                        Case 3
                            If myReader.IsDBNull(i) Then
                                MESD = "null"
                            Else
                                MESD = myReader.GetInt32(i).ToString
                            End If
                        Case 4
                            If myReader.IsDBNull(i) Then
                                technician = "null"
                            Else
                                technician = myReader.GetString(i)
                            End If
                    End Select
                Next
                Dim s As String = item + "," + quantity + "," + center + "," + MESD + "," +
                                          technician
                shipping.Add(s)
            End While
        Catch ex As Exception
            LogError(ex.ToString, "ShippingReport", getInitials())
        End Try
        myReader.Close()

        Return shipping
    End Function

    Public Function getNonInventoriedReportByDate(ByVal exportDate As String) As ArrayList
        'Connect to SQL DB
        myConn = New SqlConnection(connectionString)
        myConn.Open()
        myCmd = myConn.CreateCommand

        'Clearing Shipping list and add header
        shipping.Clear()
        shipping.Add("Item,Quantity,Center Number,MESD,Technician,Date")

        'Local variables
        Dim item As String = ""
        Dim quantity As String = ""
        Dim center As String = ""
        Dim MESD As String = ""
        Dim technician As String = ""
        Dim lastModified As String = ""

        myCmd.CommandText = "SELECT n.name, s.quantity, s.center, s.MESD, s.technician, s.last_modified " +
                            "FROM NonInventoried n LEFT JOIN Shipping s ON s.noninventoriedID = n.noninventoriedID " +
                            "WHERE s.last_modified = '" + exportDate + "';"
        Try
            myReader = myCmd.ExecuteReader
            While myReader.Read()
                'Checks every index of the query (machine_name, asset_tag, etc) for null values.
                'If it finds a null, it replaces it with "null", otherwise it stores it into the corresponding variables.
                For i As Integer = 0 To 5
                    Select Case i
                        Case 0
                            If myReader.IsDBNull(i) Then
                                item = "null"
                            Else
                                item = myReader.GetString(i)
                            End If
                        Case 1
                            If myReader.IsDBNull(i) Then
                                quantity = "null"
                            Else
                                quantity = myReader.GetInt32(i).ToString
                            End If
                        Case 2
                            If myReader.IsDBNull(i) Then
                                center = "null"
                            Else
                                center = myReader.GetInt32(i).ToString
                            End If
                        Case 3
                            If myReader.IsDBNull(i) Then
                                MESD = "null"
                            Else
                                MESD = myReader.GetInt32(i).ToString
                            End If
                        Case 4
                            If myReader.IsDBNull(i) Then
                                technician = "null"
                            Else
                                technician = myReader.GetString(i)
                            End If
                        Case 5
                            If myReader.IsDBNull(i) Then
                                lastModified = "null"
                            Else
                                lastModified = myReader.GetDateTime(i).ToString("MM/dd/yyy")
                            End If
                    End Select
                Next
                Dim s As String = item + "," + quantity + "," + center + "," + MESD + "," +
                                          technician + "," + lastModified
                shipping.Add(s)
            End While
        Catch ex As Exception
            LogError(ex.ToString, "ShippingReport", getInitials())
        End Try
        myReader.Close()

        Return shipping
    End Function

    Public Sub printShippingReport(ByVal machinelist As ArrayList, ByVal shippinglist As ArrayList)
        Dim path As String = "\\10.12.40.143\C$\Users\Inventory\Desktop\Logs\Shipping Reports\ShippingReport_" + DateTime.Now.ToString("MM-dd-yyy") + ".csv"

        'Build string based on all strings in machineList and shippingList and appends them together
        Dim str As New StringBuilder
        For Each m As String In machinelist
            str.Append(m + vbNewLine)
        Next

        For Each s As String In shippinglist
            str.Append(s + vbNewLine)
        Next

        'Write to file path
        Try
            My.Computer.FileSystem.WriteAllText(path, str.ToString, False)
        Catch ex As Exception
            LogError(ex.ToString, "ShippingReport", getInitials())
        End Try
    End Sub

    Public Sub exportShippingReport(ByVal machineList As ArrayList, ByVal shippingList As ArrayList)
        Dim str As New StringBuilder
        For Each m As String In machineList
            str.Append(m + vbNewLine)
        Next

        For Each s As String In shippingList
            str.Append(s + vbNewLine)
        Next

        Try
            My.Computer.FileSystem.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\ShippingReport_CustomDate.csv", Str.ToString, False)
            MsgBox("Success!")
        Catch ex As Exception
            LogError(ex.ToString, "ShippingReport", getInitials())
        End Try
    End Sub
End Module
