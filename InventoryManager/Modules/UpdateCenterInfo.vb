Imports System.Data.SqlClient
Imports Excel = Microsoft.Office.Interop.Excel

Module UpdateCenterInfo
    Private myConn As SqlConnection
    Private myCmd As SqlCommand
    Private myReader As SqlDataReader

    'Number of centers
    Public COUNT As Integer = 1
    Public MAX As Integer = 300

    Public Sub UpdateCenters()
        'Network file
        Dim mastersheet As String = "\\10.12.40.143\C$\Users\Inventory\Desktop\SD_Wan_Master_ Support.xls"

        'Connect to SQL DB
        myConn = New SqlConnection(connectionString)
        myConn.Open()
        myCmd = myConn.CreateCommand

        'Local Excel variables
        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim xlWorkSheet As Excel.Worksheet

        'Open Excel workbook 
        xlApp = New Excel.Application
        xlWorkBook = xlApp.Workbooks.Open(mastersheet)
        xlWorkSheet = xlWorkBook.Worksheets("Master Sheet")

        'Class variable
        Dim center As New Center("", "", "", "", "", "", "", "", "", "", "", "")

        'Dim row As Integer = xlWorkSheet.Rows.Count $$$ Didn't work
        Dim row As Integer = MAX 'Temporary static setting
        Dim col As Integer = xlWorkSheet.Columns.Count

        Dim command As String = ""
        Dim line As String = ""

        For i As Integer = 2 To 300
            For j As Integer = 1 To col
                'Iterates through every cell, one row at a time
                Select Case j
                    Case 1
                        center.centerNumber = xlWorkSheet.Cells(i, j).Value
                    Case 2
                        center.name = xlWorkSheet.Cells(i, j).Value
                        center.name = center.name.Replace("'", "")
                    Case 6
                        center.address = xlWorkSheet.Cells(i, j).Value
                        If Not (center.address = Nothing) Then
                            center.address = center.address.Replace("'", "")
                        End If
                    Case 7
                        center.city = xlWorkSheet.Cells(i, j).Value
                    Case 8
                        center.state = xlWorkSheet.Cells(i, j).Value
                    Case 9
                        center.zipCode = xlWorkSheet.Cells(i, j).Value
                    Case 10
                        center.phoneNumber = xlWorkSheet.Cells(i, j).Value
                    Case 12
                        center.circuitProvider = xlWorkSheet.Cells(i, j).Value
                    Case 14
                        center.WAN = xlWorkSheet.Cells(i, j).value
                    Case 27
                        center.circuitID = xlWorkSheet.Cells(i, j).Value
                    Case 32
                        Dim secondID As String = xlWorkSheet.Cells(i, j).Value
                        If Not (secondID = Nothing) Then
                            center.circuitID += ", " + secondID
                        End If
                End Select
            Next
            command += String.Format("UPDATE Center SET name = '{0}', address = '{1}', city = '{2}', state = '{3}', zip_code = '{4}', phone_number = '{5}', circuit_provider = '{6}', circuit_id = '{7}', wan = '{8}' WHERE center_number = {9}; ",
                                    center.name, center.address, center.city, center.state, center.zipCode, center.phoneNumber, center.circuitProvider, center.circuitID, center.WAN, center.centerNumber)
            command += vbNewLine

            COUNT += 1
        Next
        myCmd.CommandText = command

        Try
            myReader = myCmd.ExecuteReader
            'MsgBox("Update Complete!")
            myReader.Close()
        Catch ex As Exception
            LogError(ex.ToString, "UpdateCenterInfo", "Program")
        End Try

        xlWorkBook.Close()
        xlApp.Quit()
    End Sub

    Public Sub enterTablets()
        Dim aConn As SqlConnection
        Dim aCmd As SqlCommand
        Dim aReader As SqlDataReader

        'Network file
        Dim mastersheet As String = "C:\Users\sbanerjee\Desktop\import.xls"

        'Connect to SQL DB
        aConn = New SqlConnection(connectionString)
        aConn.Open()
        aCmd = aConn.CreateCommand

        'Local Excel variables
        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim xlWorkSheet As Excel.Worksheet

        'Open Excel workbook 
        xlApp = New Excel.Application
        xlWorkBook = xlApp.Workbooks.Open(mastersheet)
        xlWorkSheet = xlWorkBook.Worksheets("Sheet1")

        'Local variables
        Dim model As String = ""
        Dim serialNumber As String = ""
        Dim assetTag As String = ""
        Dim received As String = ""


        'Dim row As Integer = xlWorkSheet.Rows.Count $$$ Didn't work
        Dim row As Integer = 74
        Dim col As Integer = xlWorkSheet.Columns.Count

        'Dim centers As New List(Of String)
        Dim command As String = ""
        Dim line As String = ""

        For i As Integer = 1 To row
            For j As Integer = 1 To col
                'Iterates through every cell, one row at a time
                Select Case j
                    Case 1
                        serialNumber = xlWorkSheet.Cells(i, j).Value
                    Case 2
                        model = xlWorkSheet.Cells(i, j).Value
                    Case 5
                        received = xlWorkSheet.Cells(i, j).Value
                End Select
            Next

            'user, name, tag, sn, sim, imei, modelid, center, cc, recei, acq, last, 1, 1, mesd, tech        'user, name, tag, sn, sim, imei, modelid, center, cc, recei, acq, last, 1, 1, mesd, tech        'user, name, tag, sn, sim, imei, modelid, center, cc, recei, acq, last, 1, 1, mesd, tech
            command += "INSERT INTO Machine VALUES (NULL, '" + serialNumber.ToUpper + "', null, '" + serialNumber.ToUpper + "', NULL, NULL, (SELECT modelid FROM Model WHERE name ='" + model + "'), 0, null, SYSDATETIME(), null, SYSDATETIME(), 1, 1, null, 'SB'); "
            'MsgBox(command)
        Next
        aCmd.CommandText = command

        Try
            aReader = aCmd.ExecuteReader
            aReader.Close()
            MsgBox("success")
        Catch ex As Exception
            LogError(ex.ToString, "Import", "Program")
        End Try

        xlWorkBook.Close()
        xlApp.Quit()
    End Sub

    'Removes single quotation marks to prevent SQL query from failing
    Private Sub alterName(ByRef name As String)
        name.Replace("'", "")
    End Sub
End Module
