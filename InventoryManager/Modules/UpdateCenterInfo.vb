Imports System.Data.SqlClient
Imports Excel = Microsoft.Office.Interop.Excel

Module UpdateCenterInfo
    Private myConn As SqlConnection
    Private myCmd As SqlCommand
    Private myReader As SqlDataReader

    'Number of centers
    Public COUNT As Integer = 1
    Public MAX As Integer = 305

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

        'Local variables
        Dim center_number As String = ""
        Dim name As String = ""
        Dim address As String = ""
        Dim city As String = ""
        Dim state As String = ""
        Dim zipCode As String = ""
        Dim phoneNumber = ""
        Dim circuitProvider As String = ""
        Dim circuitID As String = ""
        Dim WAN As String = ""

        'Dim row As Integer = xlWorkSheet.Rows.Count $$$ Didn't work
        Dim row As Integer = MAX 'Temporary static setting
        Dim col As Integer = xlWorkSheet.Columns.Count

        Dim centers As New List(Of String)
        Dim command As String = ""
        Dim line As String = ""

        For i As Integer = 2 To row
            For j As Integer = 1 To col
                'Iterates through every cell, one row at a time
                Select Case j
                    Case 1
                        center_number = xlWorkSheet.Cells(i, j).Value
                    Case 2
                        name = xlWorkSheet.Cells(i, j).Value
                        name = name.Replace("'", "")
                    Case 6
                        address = xlWorkSheet.Cells(i, j).Value
                        If Not (address = Nothing) Then
                            address = address.Replace("'", "")
                        End If
                    Case 7
                        city = xlWorkSheet.Cells(i, j).Value
                    Case 8
                        state = xlWorkSheet.Cells(i, j).Value
                    Case 9
                        zipCode = xlWorkSheet.Cells(i, j).Value
                    Case 10
                        phoneNumber = xlWorkSheet.Cells(i, j).Value
                    Case 12
                        circuitProvider = xlWorkSheet.Cells(i, j).Value
                    Case 14
                        WAN = xlWorkSheet.Cells(i, j).value
                    Case 23
                        circuitID = xlWorkSheet.Cells(i, j).Value
                    Case 28
                        Dim secondID As String = xlWorkSheet.Cells(i, j).Value
                        If Not (secondID = Nothing) Then
                            circuitID += vbNewLine + secondID
                        End If
                End Select
            Next
            command += String.Format("UPDATE Center SET name = '{0}', address = '{1}', city = '{2}', state = '{3}', zip_code = '{4}', phone_number = '{5}', circuit_provider = '{6}', circuit_id = '{7}', wan = '{8}' WHERE center_number = {9}; ",
                                    name, address, city, state, zipCode, phoneNumber, circuitProvider, circuitID, WAN, center_number)
            command += vbNewLine

            count += 1

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
        Dim mastersheet As String = "\\10.12.40.143\C$\Users\Inventory\Desktop\tablets.xls"

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
        Dim center_number As String = ""
        Dim MESD As String = ""
        Dim serialNumber As String = ""
        Dim assetTag As String = ""
        Dim time As String = ""


        'Dim row As Integer = xlWorkSheet.Rows.Count $$$ Didn't work
        Dim row As Integer = 64
        Dim col As Integer = xlWorkSheet.Columns.Count

        Dim centers As New List(Of String)
        Dim command As String = ""
        Dim line As String = ""

        For i As Integer = 2 To row
            For j As Integer = 1 To col
                'Iterates through every cell, one row at a time
                Select Case j
                    Case 1
                        center_number = xlWorkSheet.Cells(i, j).Value
                    Case 2
                        MESD = xlWorkSheet.Cells(i, j).Value
                    Case 3
                        serialNumber = xlWorkSheet.Cells(i, j).Value
                    Case 4
                        assetTag = xlWorkSheet.Cells(i, j).Value
                    Case 5
                        time = xlWorkSheet.Cells(i, j).Value
                End Select
            Next

            command += "INSERT INTO Machine VALUES (NULL, '" + serialNumber.ToUpper + "', " + assetTag + ", '" + serialNumber.ToUpper + "', NULL, NULL, 14, " + center_number + ", 'FD', '" + time + "', '" + time + "', SYSDATETIME(), 2, 1, " + MESD + ", 'JR', 0); "
        Next
        aCmd.CommandText = command

        Try
            aReader = aCmd.ExecuteReader
            aReader.Close()
            MsgBox("success")
        Catch ex As Exception
            LogError(ex.ToString, "AddFDProject", "Program")
        End Try

        xlWorkBook.Close()
        xlApp.Quit()
    End Sub
    'Removes single quotation marks to prevent SQL query from failing
    Private Sub alterName(ByRef name As String)
        name.Replace("'", "")
    End Sub
End Module
