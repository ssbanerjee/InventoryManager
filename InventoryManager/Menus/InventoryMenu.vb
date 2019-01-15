Public Class InventoryMenu
    Private Sub MainMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        resetTimer()
    End Sub

    Private Sub btnAddMachine_Click(sender As Object, e As EventArgs) Handles btnAddMachine.Click
        AddMachineMenu.ShowDialog()
    End Sub

    Private Sub btnAddMachine_MouseHover(sender As Object, e As EventArgs) Handles btnAddMachine.MouseHover
        'btnAddMachine.Image = My.Resources.addMachine_selected
    End Sub

    Private Sub btnAddMachine_MouseLeave(sender As Object, e As EventArgs) Handles btnAddMachine.MouseLeave
        'btnAddMachine.Image = My.Resources.addMachine
    End Sub

    Private Sub btnEditMachine_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Search.ShowDialog()
    End Sub

    Private Sub btnEdit_MouseHover(sender As Object, e As EventArgs) Handles btnEdit.MouseHover
        'btnEdit.Image = My.Resources.editInfo_selected
    End Sub

    Private Sub btnEdit_MouseLeave(sender As Object, e As EventArgs) Handles btnEdit.MouseLeave
        'btnEdit.Image = My.Resources.editInfo
    End Sub

    Private Sub btnTransfer_Click(sender As Object, e As EventArgs) Handles btnTransfer.Click
        ShippingMenu.ShowDialog()
    End Sub

    Private Sub btnTransfer_MouseHover(sender As Object, e As EventArgs) Handles btnTransfer.MouseHover
        'btnTransfer.Image = My.Resources.shippingMenu_selected
    End Sub

    Private Sub btnTransfer_MouseLeave(sender As Object, e As EventArgs) Handles btnTransfer.MouseLeave
        'btnTransfer.Image = My.Resources.shippingMenu
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
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
