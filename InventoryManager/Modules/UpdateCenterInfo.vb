Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Data.SqlClient
Imports Excel = Microsoft.Office.Interop.Excel

Module UpdateCenterInfo
    Private connectionString As String = "Server=localhost\INVENTORYSQL;Database=master;Trusted_Connection=True;"
    Private myConn As SqlConnection
    Private myCmd As SqlCommand
    Private myReader As SqlDataReader

    Public count As Integer = 1
    Public max As Integer = 303

    'Public LoginForm As New Login

    Public Sub UpdateCenters()
        myConn = New SqlConnection(connectionString)
        myConn.Open()
        myCmd = myConn.CreateCommand

        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim xlWorkSheet As Excel.Worksheet

        xlApp = New Excel.Application
        xlWorkBook = xlApp.Workbooks.Open("C:\\Users\\sbanerjee\\Desktop\\MASTER SITE INVENTORY 4_10_18.xls")
        xlWorkSheet = xlWorkBook.Worksheets("Master Sheet")

        Dim center_number As String = ""
        Dim name As String = ""
        Dim region As String = ""
        Dim district As String = ""
        Dim address As String = ""
        Dim city As String = ""
        Dim state As String = ""
        Dim zipCode As String = ""
        Dim phoneNumber = ""
        Dim circuitProvider As String = ""
        Dim circuitID As String = ""

        'Dim row As Integer = xlWorkSheet.Rows.Count
        Dim row As Integer = 303
        Dim col As Integer = xlWorkSheet.Columns.Count

        Dim centers As New List(Of String)
        Dim command As String = ""
        Dim line As String = ""

        For i As Integer = 2 To row
            For j As Integer = 1 To col
                Select Case j
                    Case 1
                        center_number = xlWorkSheet.Cells(i, j).Value
                    Case 2
                        name = xlWorkSheet.Cells(i, j).Value
                        name = name.Replace("'", "")
                    Case 4
                        region = xlWorkSheet.Cells(i, j).Value
                    Case 5
                        district = xlWorkSheet.Cells(i, j).Value
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
                    Case 13
                        circuitID = xlWorkSheet.Cells(i, j).Value
                End Select
            Next
            command += String.Format("UPDATE Center SET name = '{0}', address = '{1}', city = '{2}', state = '{3}', zip_code = '{4}', phone_number = '{5}', circuit_provider = '{6}', circuit_id = '{7}' WHERE center_number = {8}; ",
                                    name, address, city, state, zipCode, phoneNumber, circuitProvider, circuitID, center_number)
            count += 1

            'MsgBox(Login.lblUpdate.Text)

        Next

        'MsgBox(command)
        myCmd.CommandText = command
        Try
            myReader = myCmd.ExecuteReader
            MsgBox("Update Complete!")
            myReader.Close()
        Catch ex As Exception
            LogError(ex.ToString)
            MsgBox("Error, check logs")
        End Try

        xlWorkBook.Close()
        xlApp.Quit()
    End Sub

    Private Sub alterName(ByRef name As String)
        name.Replace("'", "")
    End Sub
End Module
