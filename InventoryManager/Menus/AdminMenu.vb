'NOT IMPLEMENTED YET
Public Class AdminMenu

    Private multiplyerX As Integer = 1
    Private multiplyerY As Integer = 1
    Private int As Integer = 1

    Private Sub AdminMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Timer1.Enabled = True
    End Sub

    'Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
    '    Dim x As Integer = btniTellers.Location.X
    '    Dim y As Integer = btniTellers.Location.Y
    '    If x > 527 Then
    '        x = 0
    '    End If
    '    If y > 404 Then
    '        y = 0
    '    End If
    '    btniTellers.Location = New Point((multiplyerX * x) + 10, (multiplyerY * y) + 10)
    'End Sub

    Private Sub btniTellers_Click(sender As Object, e As EventArgs) Handles btniTellers.Click
        MsgBox("You did it!")
    End Sub
End Class