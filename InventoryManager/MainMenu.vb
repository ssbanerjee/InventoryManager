

Public Class MainMenu


    Private Sub MainMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnAddMachine_Click(sender As Object, e As EventArgs) Handles btnAddMachine.Click
        AddMachineMenu.ShowDialog()
    End Sub

    Private Sub btnEditMachine_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        EditMachine.ShowDialog()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Search.ShowDialog()
    End Sub

End Class
