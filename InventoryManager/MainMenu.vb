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
End Class