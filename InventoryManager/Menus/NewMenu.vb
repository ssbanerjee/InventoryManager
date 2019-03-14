Public Class NewMenu

    Private Sub NewMenu_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Update Exit Button
        btnExit.BackColor = Color.FromArgb(0, 129, 195)
    End Sub

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
    Private Sub pbCenterInfo_Click(sender As Object, e As EventArgs) Handles pbCenterInfo.Click, PictureBox1.Click
        CenterInfoMenu.ShowDialog()
        Show()
    End Sub

    Private Sub pbCenterInfo_MouseDown(sender As Object, e As MouseEventArgs) Handles pbCenterInfo.MouseDown, PictureBox1.MouseDown
        pbCenterInfo.Image = My.Resources.CenterInfo_pressed
    End Sub

    Private Sub pbCenterInfo_MouseUp(sender As Object, e As MouseEventArgs) Handles pbCenterInfo.MouseUp, PictureBox1.MouseUp
        pbCenterInfo.Image = My.Resources.CenterInfo
    End Sub

    'Query Builder
    Private Sub pbShipItem_Click(sender As Object, e As EventArgs) Handles pbShipItem.Click
        'Hide()
        AddShipping.ShowDialog()
        Show()
    End Sub

    Private Sub pbShipItem_MouseDown(sender As Object, e As MouseEventArgs) Handles pbShipItem.MouseDown
        pbShipItem.Image = My.Resources.ShipItem_pressed
    End Sub

    Private Sub ppbShipItem_MouseUp(sender As Object, e As MouseEventArgs) Handles pbShipItem.MouseUp
        pbShipItem.Image = My.Resources.ShipItem
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        enterTablets()
    End Sub
    'END
End Class