Public Class NetworkTeamMenu
    Private Sub NetworkTeamMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        resetTimer()

        'Update Exit Button
        btnExit.BackColor = Color.FromArgb(0, 129, 195)
    End Sub

    Private Sub pbAdtran_Click(sender As Object, e As EventArgs) Handles pbAdtran.Click
        AddNetworkItem.model_id = "18"
        AddNetworkItem.ShowDialog()
    End Sub

    Private Sub pbAdtran_MouseDown(sender As Object, e As MouseEventArgs) Handles pbAdtran.MouseDown
        pbAdtran.Image = My.Resources.Adtran_pressed
    End Sub

    Private Sub pbAdtran_MouseUp(sender As Object, e As MouseEventArgs) Handles pbAdtran.MouseUp
        pbAdtran.Image = My.Resources.Adtran
    End Sub

    Private Sub pbMojo_Click(sender As Object, e As EventArgs) Handles pbMojo.Click
        AddNetworkItem.model_id = "26"
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
End Class