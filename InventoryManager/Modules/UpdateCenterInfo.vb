Imports System.Data.SqlClient
Imports Excel = Microsoft.Office.Interop.Excel

Module UpdateCenterInfo
    Private myConn As SqlConnection
    Private myCmd As SqlCommand
    Private myReader As SqlDataReader

    'Number of centers
    Public count As Integer = 1
    Public max As Integer = 303

    Public Sub UpdateCenters()
        'Network file
        Dim mastersheet As String = "C:\\Users\\sbanerjee\\Desktop\\SD_Wan_Master_ Support.xls"

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
        Dim row As Integer = 303 'Temporary static setting
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
                    Case 22
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

    'Removes single quotation marks to prevent SQL query from failing
    Private Sub alterName(ByRef name As String)
        name.Replace("'", "")
    End Sub
End Module
