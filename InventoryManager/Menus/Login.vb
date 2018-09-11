﻿'-----------------------'
'APP STARTS ON THIS FORM'
'-----------------------'

'Imports for SQL libraries
Imports System.ComponentModel
Imports System.Data.SqlClient

Public Class Login
    'Connection variables for SQL Server
    Private myConn As SqlConnection
    Private myCmd As SqlCommand
    Private myReader As SqlDataReader

    'Placeholder variable to check if it is the first time a user has logged into the system
    Private firstLogin As Boolean

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Runs background worker to update center info while user is logging in
        bgwUpdate.RunWorkerAsync()

        'No user logged in, deactivate timer
        tmrInactive.Enabled = False

        'Connect to SQL DB
        myConn = New SqlConnection(connectionString)
        myConn.Open()
        myCmd = myConn.CreateCommand

        'Update Version Text
        Dim lines() As String = IO.File.ReadAllLines("C:\Users\sbanerjee\Desktop\ChangeLog.txt")
        lblVersion.Text = lines(0)
        lblVersion.BackColor = Color.FromArgb(0, 129, 195)

        'Display countdown to UPS pickup
        Countdown.Show()
    End Sub

    'The following is hands down the ugliest piece of shit code you will ever read so please ignore it.
    'You shouldn't need to change anything here
    Private Sub txtPIN_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPIN.KeyDown
        'If the Enter key is pressed
        If e.KeyCode = Keys.Enter Then
            'If the PIN textbox is not blank
            If txtPIN.Text IsNot "" Then
                Dim PIN As String = txtPIN.Text
                'Following Query gets the user (written as lastName, firstName), and two booleans that check if it is their first time logging in, or first time since last update
                myCmd.CommandText = "SELECT (last_name + ', ' + first_name), employee_firstLogin, employee_update FROM Employee WHERE employee_pin = " + PIN + ";"
                txtPIN.Clear() 'Clears PIN field
                Try
                    myReader = myCmd.ExecuteReader() 'Executes the Query. Placed inside a Try-Catch in the event that something breaks
                    If myReader.Read() Then 'Normally keeps running while Query still has rows to return. In this case, it's a single-row Query, so only need to check it once
                        currentUser = myReader.GetString(0) 'Index increments by one, starting from 0
                        Dim result As MsgBoxResult = MsgBox("Login as " + currentUser + "?", MsgBoxStyle.YesNo) 'Asks if user wants to Login
                        If result = MsgBoxResult.Yes Then
                            If myReader.GetInt32(1) = 1 Then 'If it is their first login, run updatePIN
                                updatePIN(PIN)
                                checkUpdate(PIN, myReader.GetInt32(2)) 'Check if user has logged in since last update (in this case this will be false)
                                login() 'Check below for login function
                            Else
                                checkUpdate(PIN, myReader.GetInt32(2)) 'Check if user has logged in since last update
                                login() 'Check below for login function
                            End If
                        End If
                    Else 'If nothing was read, then the Employee was not found.
                        myReader.Close()
                        MsgBox("Employee not found.")
                    End If
                Catch ex As Exception
                    LogError(ex.ToString, "Login", getInitials())
                End Try
            Else 'This runs if nothing is in the PIN textbox
                MsgBox("Please enter a PIN.")
            End If
            myReader.Close() 'Always close the reader after a query, even if you're going to make another one
        End If
    End Sub

    Private Sub updatePIN(ByVal oldPIN As String)
        Dim newPIN As String
        Dim success As Boolean = False
        myReader.Close() 'Closes the reader prior to establishing a new one

        Do 'Keep looping while PIN has not been succesfully updated
            Do 'Keep looping if not numerical.
                newPIN = InputBox("Please enter a numerical PIN: ", "Enter New PIN", "")
            Loop While Not IsNumeric(newPIN)
            'Following query updates the Employee table and sets the PIN equal to what the user put in, and then sets their firstLogin to false
            myCmd.CommandText = "UPDATE Employee SET employee_pin = " + newPIN + ", employee_firstLogin = 0 WHERE employee_pin = " + oldPIN + ";"
            Try
                myReader = myCmd.ExecuteReader
                MsgBox("PIN Updated")
                success = True 'Flag to stop the loop
            Catch ex As Exception
                LogError(ex.ToString, "Login", getInitials())
                success = False 'Redundant, but meant to keep looping
            End Try
        Loop While success = False

        myReader.Close()
    End Sub

    'Gets the PIN and update status (0 or 1) and checks to see if it needs to display the changelog or not
    Private Sub checkUpdate(ByVal PIN As String, ByVal update As Integer)
        myReader.Close()
        If update = 0 Then
            MsgBox("There has been an update!")
            btnLog.PerformClick()
            myReader.Close()
            myCmd.CommandText = "UPDATE Employee SET employee_update = 1 WHERE employee_pin = " + PIN + ";"
            Try
                myReader = myCmd.ExecuteReader()
            Catch ex2 As Exception
                LogError(ex2.ToString, "Login", getInitials())
            End Try
            myReader.Close()
        Else
            Return
        End If
    End Sub

    'This is the inactivity timer that keeps active through the whole application
    'Every "tick", the following code will run
    Private Sub tmrInactive_Tick(sender As Object, e As EventArgs) Handles tmrInactive.Tick
        tmrInactive.Enabled = False 'Turns off the timer so multiple messages don't spawn from long periods of inactivity
        Dim result As MsgBoxResult = MsgBox("Would you like to continue your session as " + currentUser + "?", MsgBoxStyle.YesNo) 'Asks user if they want to continue their session
        If result = MsgBoxResult.Yes Then
            resetTimer() 'Code to turn off and back on the timer, found in InactivityTimer.vb
        Else
            MsgBox("Closing due to inactivity.", MsgBoxStyle.Question, "")
            For i = Application.OpenForms.Count - 1 To 1 Step -1 'Closes all open forms except for the first one (this form)
                Dim form As Form = Application.OpenForms(i)
                form.Close()
            Next i
            Countdown.Show()
        End If
    End Sub

    'The following two Subs are background workers. These apply multiprogramming to allow you to run two (or more) segments of code at once
    Private Sub bgwUpdate_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgwUpdate.DoWork
        UpdateCenters() 'UpdateCenterInfo.vb module
    End Sub

    Public Sub bgwShipping_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgwShipping.DoWork
        Dim machines As ArrayList = getShippingReport()  'ShippingReport.vb module
        Dim shipping As ArrayList = getNonInventoriedReport() 'ShippingReport.vb module
        printShippingReport(machines, shipping) 'ShippingReport.vb module
    End Sub

    'Flavor text to just show that the center update is working
    Private Sub tmrUpdateLabel_Tick(sender As Object, e As EventArgs) Handles tmrUpdateLabel.Tick
        If (count = max) Then
            lblUpdate.Text = " Update Complete!"
            progressBar.Value = 0
        Else
            lblUpdate.Text = " Updating Inventory... (" + count.ToString + "/" + max.ToString + ") Complete."
            progressBar.Value = ((count * 100) / max)
        End If
        lblUpdate.Refresh()
    End Sub

    'LOGIN FUNCTION
    Private Sub login()
        LogSignIn() 'Updates activity log
        tmrInactive.Enabled = True 'Starts inactivity timer
        Hide() 'Hides current form
        bgwShipping.RunWorkerAsync() 'Updates shipping report using another background worker
        NewMenu.ShowDialog() 'Shows the menu
        Show() 'Once the menu is closed, reveal this form again
        myReader.Close() 'Another measure to close the reader
    End Sub

    'Change log buttons displays the text from the ChangeLog.txt
    Private Sub btnLog_Click(sender As Object, e As EventArgs) Handles btnLog.Click
        Dim fileReader As String
        fileReader = My.Computer.FileSystem.ReadAllText("C:\Users\sbanerjee\Desktop\ChangeLog.txt")
        MsgBox(fileReader)
    End Sub
End Class