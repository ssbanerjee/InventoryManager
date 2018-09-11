Public Class AddMachineMenu
    'This is the main menu that displays after a user has selected to Add a Machine.
    'Depending on which button they press, it will take them to the corresponding menu to add that type of machine.

    Private Sub AddMachine_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        resetTimer()
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Close()
    End Sub

    Private Sub pbLaptop_Click(sender As Object, e As EventArgs) Handles pbLaptop.Click
        AddLaptop.ShowDialog()
    End Sub
    Private Sub pbLaptop_MouseDown(sender As Object, e As MouseEventArgs) Handles pbLaptop.MouseDown
        pbLaptop.Image = My.Resources.Laptop_pressed
    End Sub

    Private Sub pbLaptop_MouseUp(sender As Object, e As MouseEventArgs) Handles pbLaptop.MouseUp
        pbLaptop.Image = My.Resources.Laptop
    End Sub

    Private Sub pbWorkstation_Click(sender As Object, e As EventArgs) Handles pbWorkstation.Click
        AddWorkstation.ShowDialog()
    End Sub

    Private Sub pbEMV_Click(sender As Object, e As EventArgs) Handles pbEMV.Click
        EMV.ShowDialog()
        AddEMV.ShowDialog()
    End Sub

    Private Sub pbTablet_Click(sender As Object, e As EventArgs) Handles pbTablet.Click
        AddTablet.ShowDialog()
    End Sub

    Private Sub pbCheckScanner_Click(sender As Object, e As EventArgs) Handles pbCheckScanner.Click
        CheckScanner.ShowDialog()
        AddCheckScanner.ShowDialog()
    End Sub

    Private Sub pbWorkstation_MouseDown(sender As Object, e As MouseEventArgs) Handles pbWorkstation.MouseDown
        pbWorkstation.Image = My.Resources.Workstation_pressed
    End Sub

    Private Sub pbWorkstation_MouseUp(sender As Object, e As MouseEventArgs) Handles pbWorkstation.MouseUp
        pbWorkstation.Image = My.Resources.Workstation
    End Sub

    Private Sub pbEMV_MouseDown(sender As Object, e As MouseEventArgs) Handles pbEMV.MouseDown
        pbEMV.Image = My.Resources.EMV_pressed
    End Sub

    Private Sub pbEMV_MouseUp(sender As Object, e As MouseEventArgs) Handles pbEMV.MouseUp
        pbEMV.Image = My.Resources.EMV
    End Sub

    Private Sub pbTablet_MouseDown(sender As Object, e As MouseEventArgs) Handles pbTablet.MouseDown
        pbTablet.Image = My.Resources.Tablet_pressed
    End Sub

    Private Sub pbTablet_MouseUp(sender As Object, e As MouseEventArgs) Handles pbTablet.MouseUp
        pbTablet.Image = My.Resources.Tablet
    End Sub

    Private Sub pbCheckScanner_MouseDown(sender As Object, e As MouseEventArgs) Handles pbCheckScanner.MouseDown
        pbCheckScanner.Image = My.Resources.CheckScanner_pressed
    End Sub

    Private Sub pbCheckScanner_MouseUp(sender As Object, e As MouseEventArgs) Handles pbCheckScanner.MouseUp
        pbCheckScanner.Image = My.Resources.CheckScanner
    End Sub

    Private Sub pbBanner_Click(sender As Object, e As EventArgs) Handles pbBanner.Click
        Close()
    End Sub
End Class