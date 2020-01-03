Public Class NewMenuP2
    Private Sub NetworkTeamMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        resetTimer()

        'Update Exit Button
        btnExit.BackColor = Color.FromArgb(0, 129, 195)
    End Sub

    Private Sub pbSwitch_Click(sender As Object, e As EventArgs) Handles pbSwitch.Click
        AddNetworkItem.category_name = "Switch"
        AddNetworkItem.ShowDialog()
    End Sub

    Private Sub pbSwitch_MouseDown(sender As Object, e As MouseEventArgs) Handles pbSwitch.MouseDown
        pbSwitch.Image = My.Resources.Switch_pressed
    End Sub

    Private Sub pbSwitch_MouseUp(sender As Object, e As MouseEventArgs) Handles pbSwitch.MouseUp
        pbSwitch.Image = My.Resources.Switch
    End Sub

    Private Sub pbMojo_Click(sender As Object, e As EventArgs) Handles pbMojo.Click
        AddNetworkItem.category_name = "Access Point"
        AddNetworkItem.ShowDialog()
    End Sub

    Private Sub pbMojo_MouseDown(sender As Object, e As MouseEventArgs) Handles pbMojo.MouseDown
        pbMojo.Image = My.Resources.MOJO_pressed
    End Sub

    Private Sub pbMojo_MouseUp(sender As Object, e As MouseEventArgs) Handles pbMojo.MouseUp
        pbMojo.Image = My.Resources.MOJO
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub

    Private Sub pbPhone_Click(sender As Object, e As EventArgs) Handles pbPhone.Click
        AddNetworkItem.category_name = "Phone"
        AddPhone.ShowDialog()
    End Sub

    Private Sub pbPhone_MouseDown(sender As Object, e As MouseEventArgs) Handles pbPhone.MouseDown
        pbPhone.Image = My.Resources.Phone_pressed
    End Sub

    Private Sub pbPhone_MouseUp(sender As Object, e As MouseEventArgs) Handles pbPhone.MouseUp
        pbPhone.Image = My.Resources.Phone
    End Sub

    Private Sub BtnPrinter_Click(sender As Object, e As EventArgs) Handles btnPrinter.Click
        AddPrinter.ShowDialog()
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