Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.IO

Public Class Login
    Private connectionString As String = "Server=localhost\INVENTORYSQL;Database=master;Trusted_Connection=True;"
    Private myConn As SqlConnection
    Private myCmd As SqlCommand
    Private myReader As SqlDataReader

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bgwUpdate.RunWorkerAsync()
        tmrInactive.Enabled = False
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
                                LogSignIn()
                                tmrInactive.Enabled = True
                                Me.Hide()
                                MainMenu.ShowDialog()
                                Me.Show()
                            Else
                                myReader.Close()
                                LogSignIn()
                                tmrInactive.Enabled = True
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
                    LogError(ex.ToString)
                    MsgBox("Error, check logs")
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
                LogError(ex.ToString)
                MsgBox("Error, check logs")
                success = False
            End Try
        Loop While success = False

        myReader.Close()
    End Sub

    Private Sub tmrInactive_Tick(sender As Object, e As EventArgs) Handles tmrInactive.Tick
        tmrInactive.Enabled = False
        MsgBox("Closing due to inactivity.", MsgBoxStyle.OkOnly, "")
        For i = Application.OpenForms.Count - 1 To 1 Step -1
            Dim form As Form = Application.OpenForms(i)
            form.Close()
        Next i
    End Sub

    Private Sub bgwUpdate_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgwUpdate.DoWork
        UpdateCenters()
        Dim machines As ArrayList = getShippingReport()
        printShippingReport(machines)
    End Sub

    Private Sub bgwUpdate_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bgwUpdate.RunWorkerCompleted
        lblUpdate.Visible = False
        tmrInactive.Enabled = True
    End Sub

    Private Sub tmrUpdateLabel_Tick(sender As Object, e As EventArgs) Handles tmrUpdateLabel.Tick
        If (count = max) Then
            lblUpdate.Text = "Updating Inventory... Sending Query..."
        Else
            lblUpdate.Text = "Updating Inventory... (" + count.ToString + "/" + max.ToString + ") Complete."
        End If
        lblUpdate.Refresh()
    End Sub
End Class