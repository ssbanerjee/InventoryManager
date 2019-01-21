Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Data.SqlClient

Module Scripts
    'Public connectionString As String = "Server=\\TEST-HDINV.NA.AMFBowl.NET\INVENTORYSQL;Database=master;Trusted_Connection=True;"
    Public connectionString As String = "Data Source=10.12.40.143,1433;Network Library=DBMSSOCN;Initial Catalog=master;Trusted_Connection=True;"

    Private machineLogFilePath As String = "\\10.12.40.143\C$\Users\Inventory\Desktop\Logs\Activity Logs\" + DateTime.Now.ToString("MM-dd-yyy") + ".txt"
    Private errorLogFilePath As String = "\\10.12.40.143\C$\Users\Inventory\Desktop\Logs\Error Logs\" + DateTime.Now.ToString("MM-dd-yyy") + "_" + DateTime.Now.ToString("HH-mm") + ".txt"
    Private transactionLogFilePath As String = "\\10.12.40.143\C$\Users\Inventory\Desktop\Logs\Transaction Logs\" + DateTime.Now.ToString("MM-dd-yyy") + ".txt"

    Private myConn As SqlConnection
    Private myCmd As SqlCommand
    Private myReader As SqlDataReader

    Public currentUser As String = ""

    'This function does a simple check against SQL Injection by removing all single quotes, double quotes, and semicolons from input
    Public Sub checkSQLInjection(ByRef input As String)
        input = input.Replace("""", "")
        input = input.Replace("'", "")
        input = input.Replace(";", "")
    End Sub

    'This function is only used in the MachineName for AddLaptop.vb. Its purpose is to remove dashes from the Serial Number per Josh's request
    Public Sub checkDashes(ByRef input As String)
        input = input.Replace("-", "")
    End Sub

    'Enforces numerical-only input
    Public Sub checkNum(ByRef input As String)
        Dim digitsOnly As Regex = New Regex("[^\d]")
        input = digitsOnly.Replace(input, "")
    End Sub

    'Creates a log for adding a machine
    '[Machine Type] Added; MachineName: [Machine Name]. By: [Technician Initials] on [DateTime]
    Public Sub LogMachineAdd(ByVal machine, ByVal machineName, ByVal transaction)
        File.AppendAllText(machineLogFilePath, machine + " Added; MachineName: " + machineName + ". By " + currentUser + " on " + DateTime.Now + vbNewLine)
        LogTransaction(transaction)
    End Sub

    'Creates a log for editing a machine
    'Machine Edited; MachineName: [Machine Name]. By: [Technician Initials] on [DateTime]
    Public Sub LogMachineEdit(ByVal machineName, ByVal transaction)
        File.AppendAllText(machineLogFilePath, "Machine Edited; MachineName: " + machineName + ". By " + currentUser + " on " + DateTime.Now + vbNewLine)
        LogTransaction(transaction)
    End Sub

    'Creates a log for adding an item to Shipping
    'Shipping Updated; Item: [Item], Quantity: [Quantity]. By: [Technician Initials] on [DateTime]
    Public Sub LogShippingAdd(ByVal item, ByVal quantity, ByVal transaction)
        File.AppendAllText(machineLogFilePath, "Shipping Updated; Item: " + item + ", Quantity: " + quantity + ". By " + currentUser + " on " + DateTime.Now + vbNewLine)
        LogTransaction(transaction)
    End Sub

    'Creates a log for signing in
    'User Sign In: [Technician Initials] on [DateTime]
    Public Sub LogSignIn()
        File.AppendAllText(machineLogFilePath, "User Sign In: " + currentUser + " on " + DateTime.Now + vbNewLine)
    End Sub

    'Creates a log for caught errors
    'Displays first line of error and then the log file path for more details.
    Public Sub LogError(ByVal errorMessage As String, ByVal form As String, ByVal tech As String)
        File.AppendAllText(errorLogFilePath, "Error on form " + form + " by " + tech + vbNewLine + vbNewLine + errorMessage)
        Dim lines() As String = errorMessage.Split(Environment.NewLine)
        Dim stars As String = "*********************************************************************************"
        Dim err As String = stars + vbNewLine + lines(0) + vbNewLine + stars

        MsgBox("Error!" + vbNewLine + vbNewLine + err + vbNewLine + vbNewLine + "Check " + errorLogFilePath + " for more details.")
    End Sub

    'Creates a log for each transaction made on the server
    Private Sub LogTransaction(ByVal transaction)
        File.AppendAllText(transactionLogFilePath, transaction + vbNewLine)
    End Sub

    'Gets all Center information from SQL DB and returns it as a List
    Public Function LoadCentersFromSQL() As List(Of String)
        myConn = New SqlConnection(connectionString)
        myConn.Open()
        myCmd = myConn.CreateCommand

        Dim centers As New List(Of String)
        Dim centerNumberInt As Integer
        Dim centerNumber As String = ""
        Dim centerName As String = ""

        myCmd.CommandText = "SELECT center_number, name FROM Center ORDER BY center_number ASC;"
        myReader = myCmd.ExecuteReader
        While myReader.Read()
            centerNumberInt = myReader.GetInt32(0)
            centerName = myReader.GetString(1)

            If centerNumberInt = 0 Then
                centerNumber = "In Store"
            ElseIf centerNumberInt < 100 Then
                centerNumber = "0" + centerNumberInt.ToString
            Else
                centerNumber = centerNumberInt.ToString
            End If
            centers.Add("#" + centerNumber + ", " + centerName)
        End While

        myReader.Close()
        Return centers
    End Function

    'Gets all Model types from SQL DB and returns it as a List
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

    'Gets all NonInventoried shipping items from SQL DB and returns it as a List
    Public Function LoadItemsFromSQL(ByVal category) As List(Of String)
        myConn = New SqlConnection(connectionString)
        myConn.Open()
        myCmd = myConn.CreateCommand

        Dim items As New List(Of String)
        Dim command As String
        command = "SELECT DISTINCT i.noninventoried_name FROM NonInventoried i " +
                  "JOIN ShippingCategory c ON i.shipcat_id = c.shipcat_id"
        If category <> "" Then
            command += " WHERE c.shipcat_name = '" + category + "'"
        End If
        myCmd.CommandText = command + ";"

        myReader = myCmd.ExecuteReader
        While myReader.Read()
            items.Add(myReader.GetString(0))
        End While
        myReader.Close()

        Return items
    End Function

    'Gets currentUser and returns the initials of the technician
    Public Function getInitials() As String
        Dim str() As String = Split(currentUser, ",")
        Dim newUserStr As String = ""

        newUserStr += str(1).Substring(1, 1)
        newUserStr += str(0).Substring(0, 1)

        Return newUserStr
    End Function

    'Inactivity timer
    Public Sub resetTimer()
        Login.tmrInactive.Enabled = False
        Login.tmrInactive.Enabled = True
    End Sub
End Module
