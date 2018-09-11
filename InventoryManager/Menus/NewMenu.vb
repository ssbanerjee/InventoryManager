Public Class NewMenu
    'Add Machine
    Private Sub pbAddMachine_Click(sender As Object, e As EventArgs) Handles pbAddMachine.Click
        Hide()
        AddMachineMenu.ShowDialog()
        Show()
    End Sub

    Private Sub pbAddMachine_MouseDown(sender As Object, e As MouseEventArgs) Handles pbAddMachine.MouseDown
        pbAddMachine.Image = My.Resources.AddMachine_pressed
    End Sub

    Private Sub pbAddMachine_MouseUp(sender As Object, e As MouseEventArgs) Handles pbAddMachine.MouseUp
        pbAddMachine.Image = My.Resources.AddMachine_2
    End Sub

    'Edit Information
    Private Sub pbEditInfo_Click(sender As Object, e As EventArgs) Handles pbEditInfo.Click
        Hide()
        Search.ShowDialog()
        Show()
    End Sub

    Private Sub pbEditInfo_MouseDown(sender As Object, e As MouseEventArgs) Handles pbEditInfo.MouseDown
        pbEditInfo.Image = My.Resources.EditInformation_pressed
    End Sub

    Private Sub pbEditInfo_MouseUp(sender As Object, e As MouseEventArgs) Handles pbEditInfo.MouseUp
        pbEditInfo.Image = My.Resources.EditInformation
    End Sub

    'Shipping Report
    Private Sub pbShippingReport_Click(sender As Object, e As EventArgs) Handles pbShippingReport.Click
        Hide()
        ShippingMenu.ShowDialog()
        Show()
    End Sub

    Private Sub pbShippingReport_MouseDown(sender As Object, e As MouseEventArgs) Handles pbShippingReport.MouseDown
        pbShippingReport.Image = My.Resources.ShippingReport_pressed
    End Sub

    Private Sub pbShippingReport_MouseUp(sender As Object, e As MouseEventArgs) Handles pbShippingReport.MouseUp
        pbShippingReport.Image = My.Resources.ShippingReport
    End Sub

    'Center Information
    Private Sub pbCenterInfo_Click(sender As Object, e As EventArgs) Handles pbCenterInfo.Click
        Hide()
        CenterInfoMenu.ShowDialog()
        Show()
    End Sub

    Private Sub pbCenterInfo_MouseDown(sender As Object, e As MouseEventArgs) Handles pbCenterInfo.MouseDown
        pbCenterInfo.Image = My.Resources.CenterInfo_pressed
    End Sub

    Private Sub pbCenterInfo_MouseUp(sender As Object, e As MouseEventArgs) Handles pbCenterInfo.MouseUp
        pbCenterInfo.Image = My.Resources.CenterInfo
    End Sub

    'Query Builder
    Private Sub pbQueryBuilder_Click(sender As Object, e As EventArgs) Handles pbQueryBuilder.Click
        Hide()
        QueryBuilder.ShowDialog()
        Show()
    End Sub

    Private Sub pbQueryBuilder_MouseDown(sender As Object, e As MouseEventArgs) Handles pbQueryBuilder.MouseDown
        pbQueryBuilder.Image = My.Resources.QueryBuilder_pressed
    End Sub

    Private Sub pbQueryBuilder_MouseUp(sender As Object, e As MouseEventArgs) Handles pbQueryBuilder.MouseUp
        pbQueryBuilder.Image = My.Resources.QueryBuilder_2
    End Sub

End Class