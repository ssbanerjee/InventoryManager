Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Data.SqlClient

Module Scripts
    Private logFilePath As String = "C:\Users\inventory\Desktop\Logs\" + DateTime.Now.ToString("MM-dd-yyy") + ".txt"
    Private errorLogFilePath As String = "C:\\Users\\Inventory\\Desktop\\Error Logs\\"
    Private connectionString As String = "Server=localhost\INVENTORYSQL;Database=master;Trusted_Connection=True;"
    Private myConn As SqlConnection
    Private myCmd As SqlCommand
    Private myReader As SqlDataReader

    'This function does a simple check against SQL Injection by removing all single quotes, double quotes, and semicolons from input
    Public Sub checkSQLInjection(ByRef input As String)
        input = input.Replace("""", "")
        input = input.Replace("'", "")
        input = input.Replace(";", "")
    End Sub

    Public Sub checkNum(ByRef input As String)
        'Enforces only numerical input
        Dim digitsOnly As Regex = New Regex("[^\d]")
        input = digitsOnly.Replace(input, "")
    End Sub

    Public Sub LogMachineAdd(ByVal machine, ByVal machineName)
        File.AppendAllText(logFilePath, machine + " Added; MachineName: " + machineName + ". By " + currentUser + " on " + DateTime.Now + vbNewLine)
    End Sub

    Public Sub LogMachineEdit(ByVal machineName)
        File.AppendAllText(logFilePath, "Machine Edited; MachineName: " + machineName + ". By " + currentUser + " on " + DateTime.Now + vbNewLine)
    End Sub

    Public Sub LogShippingAdd(ByVal item, ByVal quantity)
        File.AppendAllText(logFilePath, "Shipping Updated; Item: " + item + ", Quantity: " + quantity + "By " + currentUser + " on " + DateTime.Now + vbNewLine)
    End Sub
    Public Sub LogSignIn()
        File.AppendAllText(logFilePath, "User Sign In: " + currentUser + " on " + DateTime.Now + vbNewLine)
    End Sub

    Public Sub LogError(ByVal errorMessage)
        File.AppendAllText(errorLogFilePath + DateTime.Now.ToString("MM-dd-yyy") + "_" + DateTime.Now.ToString("HH-mm") + ".txt", errorMessage)
    End Sub

    Public Function LoadCentersFromSQL() As List(Of String)
        myConn = New SqlConnection(connectionString)
        myConn.Open()
        myCmd = myConn.CreateCommand

        Dim centers As New List(Of String)
        Dim centerNumberInt As Integer
        Dim centerNumber As String = ""
        Dim centerName As String = ""

        myCmd.CommandText = "SELECT center_number, name FROM Center WHERE center_number > 0 ORDER BY center_number ASC;"
        myReader = myCmd.ExecuteReader
        While myReader.Read()
            centerNumberInt = myReader.GetInt32(0)
            centerName = myReader.GetString(1)

            If centerNumberInt < 100 Then
                centerNumber = "0" + centerNumberInt.ToString
            Else
                centerNumber = centerNumberInt.ToString
            End If
            centers.Add("#" + centerNumber + ", " + centerName)
        End While

        myReader.Close()
        Return centers
    End Function

    Public Function LoadModelsFromSQL(ByVal category) As List(Of String)
        myConn = New SqlConnection(connectionString)
        myConn.Open()
        myCmd = myConn.CreateCommand

        Dim models As New List(Of String)
        myCmd.CommandText = "SELECT DISTINCT model_name FROM Model WHERE category_id = " +
                            "(SELECT category_id FROM Category WHERE category_name = '" + category + "') " +
                            "ORDER BY model_name ASC;"
        myReader = myCmd.ExecuteReader
        While myReader.Read()
            models.Add(myReader.GetString(0))
        End While
        myReader.Close()

        Return models
    End Function

    Public Function LoadItemsFromSQL() As List(Of String)
        myConn = New SqlConnection(connectionString)
        myConn.Open()
        myCmd = myConn.CreateCommand

        Dim items As New List(Of String)
        myCmd.CommandText = "SELECT DISTINCT noninventoried_name FROM NonInventoried " +
                            "ORDER BY noninventoried_name ASC;"
        myReader = myCmd.ExecuteReader
        While myReader.Read()
            items.Add(myReader.GetString(0))
        End While
        myReader.Close()

        Return items
    End Function

    Public Function getInitials() As String
        Dim str() As String = Split(currentUser, ",")
        Dim newUserStr As String = ""

        newUserStr += str(1).Substring(1, 1)
        newUserStr += str(0).Substring(0, 1)

        Return newUserStr
    End Function
End Module
