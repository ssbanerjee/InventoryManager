Public Class MainMenu
    Private Sub btnInvMenu_Click(sender As Object, e As EventArgs) Handles btnInvMenu.Click
        Me.Hide()
        InventoryMenu.ShowDialog()
        Me.Close()
    End Sub

    Private Sub btnCntMenu_Click(sender As Object, e As EventArgs) Handles btnCntMenu.Click
        Me.Hide()
        CenterInfoMenu.ShowDialog()
        Me.Close()
    End Sub

    Private Sub btnInvMenu_MouseHover(sender As Object, e As EventArgs) Handles btnInvMenu.MouseHover
        btnInvMenu.Image = My.Resources.InventoryManager_selected
    End Sub

    Private Sub btnInvMenu_MouseLeave(sender As Object, e As EventArgs) Handles btnInvMenu.MouseLeave
        btnInvMenu.Image = My.Resources.InventoryManager
    End Sub

    Private Sub btnCntMenu_MouseHover(sender As Object, e As EventArgs) Handles btnCntMenu.MouseHover
        btnCntMenu.Image = My.Resources.CenterDirectory_selected
    End Sub

    Private Sub btnCntMenu_MouseLeave(sender As Object, e As EventArgs) Handles btnCntMenu.MouseLeave
        btnCntMenu.Image = My.Resources.CenterDirectory
    End Sub

    Private Sub MainMenu_Load(sender As Object, e As EventArgs) Handles Me.Load
        resetTimer()
    End Sub
End Class