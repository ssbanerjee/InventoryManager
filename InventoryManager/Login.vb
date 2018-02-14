Imports System.Data.SqlClient
Imports System.IO

Public Class Login
    Private connectionString As String = "Server=localhost\INVENTORYSQL;Database=master;Trusted_Connection=True;"
    Private myConn As SqlConnection
    Private myCmd As SqlCommand
    Private myReader As SqlDataReader

    Public currentUser As String

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        myConn = New SqlConnection(connectionString)
        myConn.Open()
        myCmd = myConn.CreateCommand
    End Sub

    Private Sub txtPIN_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPIN.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtPIN.Text IsNot "" Then
                currentUser = txtPIN.Text
                myCmd.CommandText = "SELECT (last_name + ', ' + first_name), employee_pin, employee_firstLogin FROM Employee WHERE employee_pin = " + currentUser.ToString + ";"
                txtPIN.Clear()
                Try
                    myReader = myCmd.ExecuteReader()
                    If myReader.Read() Then
                        currentUser = myReader.GetString(0)
                        Dim result As MsgBoxResult = MsgBox("Login as " + currentUser + "?", MsgBoxStyle.YesNo)
                        If result = MsgBoxResult.Yes Then
                            Dim PIN As String = myReader.GetInt32(1).ToString
                            If myReader.GetInt32(2) = 1 Then
                                myReader.Close()
                                updatePIN(PIN)
                                Log("User Sign In: ")
                                Me.Hide()
                                MainMenu.ShowDialog()
                                Me.Show()
                            Else
                                myReader.Close()
                                Log("User Sign In: ")
                                Me.Hide()
                                MainMenu.ShowDialog()
                                Me.Show()
                            End If
                        End If
                    Else
                        myReader.Close()
                        MsgBox("Employee not found.")
                    End If
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            Else
                MsgBox("Please enter a PIN.")
            End If
            myReader.Close()
        End If
    End Sub

    Private Sub updatePIN(ByVal oldPIN As String)
        Dim newPIN As String
        Dim success As Boolean = False

        Do
            Do
                newPIN = InputBox("Please enter a numerical PIN: ", "Enter New PIN", "")
            Loop While Not IsNumeric(newPIN)
            myCmd.CommandText = "UPDATE Employee SET employee_pin = " + newPIN + ", employee_firstLogin = 0 WHERE employee_pin = " + oldPIN + ";"
            Try
                myReader = myCmd.ExecuteReader
                MsgBox("PIN Updated")
                success = True
            Catch ex As Exception
                MsgBox(ex.ToString)
                success = False
            End Try
        Loop While success = False

        myReader.Close()
    End Sub

    Private Sub Log(ByVal logMessage)
        Dim filePath As String = "C:\Users\sbanerjee\Desktop\Logs\" + DateTime.Now.ToString("MM-dd-yyy") + ".txt"
        File.AppendAllText(filePath, logMessage + currentUser + " on " + DateTime.Now + vbNewLine)
    End Sub
End Class