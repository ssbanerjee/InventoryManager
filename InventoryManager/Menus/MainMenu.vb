'Imports for SQL libraries
Imports System.ComponentModel
Imports System.Data.SqlClient

Public Class MainMenu
    'Connection variables for SQL Server
    Private myConn As SqlConnection
    Private myCmd As SqlCommand
    Private myReader As SqlDataReader

    Private machine As New Machine("", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "")

    Private machineFound As Boolean

    Private Sub MainMenu_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Connect to SQL DB
        myConn = New SqlConnection(connectionString)
        myConn.Open()
        myCmd = myConn.CreateCommand

        'Update Exit Button
        btnExit.BackColor = Color.FromArgb(0, 129, 195)
    End Sub

    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub

    Private Sub PbMenu_Click(sender As Object, e As EventArgs) Handles pbMenu.Click
        Hide()
        NewMenu.ShowDialog()
        Show()
    End Sub

    Private Sub pbMenu_MouseDown(sender As Object, e As MouseEventArgs) Handles pbMenu.MouseDown
        pbMenu.Image = My.Resources.Inventory_pressed
    End Sub

    Private Sub pbMenu_MouseUp(sender As Object, e As MouseEventArgs) Handles pbMenu.MouseUp
        pbMenu.Image = My.Resources.Inventory
    End Sub

    Private Sub PbShipping_Click(sender As Object, e As EventArgs) Handles pbShipping.Click
        'myReader.Close()
        Dim input As String

        Do 'Keep looping if not numerical.
            input = InputBox("Please enter the asset tag of the machine you wish to ship: ", "Enter Asset Tag", "")
            If input = "" Then
                Exit Do
            End If
        Loop While Not IsNumeric(input)

        If Not input = "" Then
            loadMachineData(input)
            If machineFound Then
                Dim result As MsgBoxResult = MsgBox("Verify the data below:" + vbNewLine + vbNewLine +
                                                        "Machine name: " + machine.machineName + vbNewLine +
                                                        "Asset Tag: " + machine.assetTag + vbNewLine +
                                                        "Serial Number: " + machine.serialNumber + vbNewLine +
                                                        "Model: " + machine.model + vbNewLine +
                                                        "Shipping to: " + machine.centerNumber + vbNewLine +
                                                        "Cost Center: " + machine.costCenter + vbNewLine +
                                                        "Condition: " + machine.condition + vbNewLine +
                                                        "Ticket Number: " + machine.MESD,
                                                    MsgBoxStyle.YesNo)
                If result = MsgBoxResult.Yes Then
                    myCmd.CommandText = "INSERT INTO MachinesShipped VALUES ('" + machine.machineName + "', " + machine.assetTag + ", '" +
                                    machine.serialNumber + "', " + machine.SIM + ", " + machine.IMEI + ", '" + machine.model + "', " +
                                    machine.centerNumber + ", '" + machine.costCenter + "', SYSDATETIME(), '" + machine.condition + "', " +
                                    machine.MESD + ", '" + getInitials() + "');"
                    Try
                        myReader = myCmd.ExecuteReader()
                        MsgBox("Successfully recorded machine for shipment")
                        myReader.Close()
                    Catch ex As Exception
                        LogError(ex.ToString, "mShipping", getInitials())
                        myReader.Close()
                    End Try
                Else
                    MsgBox("Update the machine data and try again.")
                End If
            Else
                MsgBox("Machine not found in database. Contact either Shoumik or Andrew for assistance." + vbNewLine + "DO NOT SHIP COMPUTER OUT UNTIL RESOLVED!")
            End If
        End If
    End Sub

    Private Sub pbShipping_MouseDown(sender As Object, e As MouseEventArgs) Handles pbShipping.MouseDown
        pbShipping.Image = My.Resources.Shipping_pressed
    End Sub

    Private Sub pbShipping_MouseUp(sender As Object, e As MouseEventArgs) Handles pbShipping.MouseUp
        pbShipping.Image = My.Resources.Shipping
    End Sub

    Private Sub PbReceiving_Click(sender As Object, e As EventArgs) Handles pbReceiving.Click
        Dim input As String

        Do 'Keep looping if not numerical.
            input = InputBox("Please enter the asset tag of the machine you are receiving: ", "Enter Asset Tag", "")
            If input = "" Then
                Exit Do
            End If
        Loop While Not IsNumeric(input)

        If Not input = "" Then
            loadMachineData(input)
            If machineFound Then
                myCmd.CommandText = "INSERT INTO MachinesReceived VALUES ('" + machine.machineName + "', " + machine.assetTag + ", '" +
                                    machine.serialNumber + "', '" + machine.model + "', SYSDATETIME(), " + machine.MESD + ", '" + getInitials() + "');"
                Try
                    myReader = myCmd.ExecuteReader
                    MsgBox("Successfully recorded " + machine.machineName + " as being received for today")
                Catch ex As Exception
                    LogError(ex.ToString, "mReceiving", getInitials())
                End Try
            Else
                MsgBox("Machine not found in database." + vbNewLine + "PLEASE GIVE COMPUTER TO SHOUMIK OR ANDREW BEFORE ANYONE ELSE!")
            End If
            myReader.Close()
        End If
    End Sub

    Private Sub pbReceiving_MouseDown(sender As Object, e As MouseEventArgs) Handles pbReceiving.MouseDown
        pbReceiving.Image = My.Resources.Receiving_pressed
    End Sub

    Private Sub pbReceiving_MouseUp(sender As Object, e As MouseEventArgs) Handles pbReceiving.MouseUp
        pbReceiving.Image = My.Resources.Receiving
    End Sub

    Private Sub loadMachineData(ByVal input)
        Dim ldConn As SqlConnection
        Dim ldCmd As SqlCommand
        Dim ldReader As SqlDataReader

        ldConn = New SqlConnection(connectionString)
        ldConn.Open()
        ldCmd = ldConn.CreateCommand

        machineFound = False
        ldCmd.CommandText = "SELECT m.machine_name, m.asset_tag, m.serial_number, d.name, m.SIM, m.IMEI, t.center_number, k.name, m.cost_center, m.ticket_number " +
                        "FROM Machine m LEFT JOIN Model d ON m.modelID = d.modelID " +
                        "LEFT JOIN Category c ON d.categoryID = c.categoryID " +
                        "LEFT JOIN Center t ON m.center_number = t.center_number " +
                        "LEFT JOIN Condition k ON m.conditionID = k.conditionID " +
                        "WHERE m.asset_tag = " + input + ";"
        Try
            ldReader = ldCmd.ExecuteReader()
            'Checks every index of the query (machine_name, asset_tag, etc) for null values.
            'If it finds a null, it replaces it with "null", otherwise it stores it into the corresponding variables.
            If ldReader.Read() Then
                For i As Integer = 0 To 9
                    Select Case i
                        Case 0
                            If ldReader.IsDBNull(i) Then
                                machine.machineName = "null"
                            Else
                                machine.machineName = ldReader.GetString(i)
                            End If
                        Case 1
                            If ldReader.IsDBNull(i) Then
                                machine.assetTag = "null"
                            Else
                                machine.assetTag = ldReader.GetInt32(i).ToString
                            End If
                        Case 2
                            If ldReader.IsDBNull(i) Then
                                machine.serialNumber = "null"
                            Else
                                machine.serialNumber = ldReader.GetString(i)
                            End If
                        Case 3
                            If ldReader.IsDBNull(i) Then
                                machine.model = "null"
                            Else
                                machine.model = ldReader.GetString(i)
                            End If
                        Case 4
                            If ldReader.IsDBNull(i) Then
                                machine.SIM = "null"
                            Else
                                machine.SIM = "'" + ldReader.GetString(i) + "'"
                            End If
                        Case 5
                            If ldReader.IsDBNull(i) Then
                                machine.IMEI = "null"
                            Else
                                machine.IMEI = "'" + ldReader.GetString(i) + "'"
                            End If
                        Case 6
                            If ldReader.IsDBNull(i) Then
                                machine.centerNumber = "null"
                            Else
                                machine.centerNumber = ldReader.GetInt32(i).ToString
                            End If
                        Case 7
                            If ldReader.IsDBNull(i) Then
                                machine.condition = "null"
                            Else
                                machine.condition = ldReader.GetString(i)
                            End If
                        Case 8
                            If ldReader.IsDBNull(i) Then
                                machine.costCenter = "null"
                            Else
                                machine.costCenter = ldReader.GetString(i)
                            End If
                        Case 9
                            If ldReader.IsDBNull(i) Then
                                machine.MESD = "null"
                            Else
                                machine.MESD = ldReader.GetInt32(i).ToString
                            End If
                    End Select
                Next
                machineFound = True
            Else
                machineFound = False
            End If
            ldReader.Close()
        Catch ex As Exception
            LogError(ex.ToString, "Search", getInitials())
        End Try
    End Sub

    '======================================
    ' CUSTOM MOVE FORM 
    '======================================

    Private MoveForm As Boolean
    Private MoveForm_MousePosition As Point

    Private Sub MoveForm_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        If e.Button = MouseButtons.Left Then
            MoveForm = True
            Me.Cursor = Cursors.NoMove2D
            MoveForm_MousePosition = e.Location
        End If
    End Sub

    Private Sub MoveForm_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        If MoveForm Then
            Me.Location = Me.Location + (e.Location - MoveForm_MousePosition)
        End If
    End Sub

    Private Sub MoveForm_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
        If e.Button = MouseButtons.Left Then
            MoveForm = False
            Me.Cursor = Cursors.Default
        End If
    End Sub
    'END
End Class