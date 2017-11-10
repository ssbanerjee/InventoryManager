Imports System.Data.SqlClient

Public Class AddMachineMenu


    Private Sub AddMachine_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Close()
    End Sub

    Private Sub btnLaptop_Click(sender As Object, e As EventArgs) Handles btnLaptop.Click
        AddLaptop.ShowDialog()
    End Sub

    Private Sub btnLaptop_MouseHover(sender As Object, e As EventArgs) Handles btnLaptop.MouseHover
        btnLaptop.Image = My.Resources.laptop_selected
    End Sub

    Private Sub btnLaptop_MouseLeave(sender As Object, e As EventArgs) Handles btnLaptop.MouseLeave
        btnLaptop.Image = My.Resources.laptop
    End Sub

    Private Sub btnWorkstation_Click(sender As Object, e As EventArgs) Handles btnWorkstation.Click
        AddWorkstation.ShowDialog()
    End Sub

    Private Sub btnWorkstation_MouseHover(sender As Object, e As EventArgs) Handles btnWorkstation.MouseHover
        btnWorkstation.Image = My.Resources.workstation_selected
    End Sub

    Private Sub btnWorkstation_MouseLeave(sender As Object, e As EventArgs) Handles btnWorkstation.MouseLeave
        btnWorkstation.Image = My.Resources.workstation
    End Sub

    Private Sub btnEMV_Click(sender As Object, e As EventArgs) Handles btnEMV.Click
        'TODO
    End Sub

    Private Sub btnEMV_MouseHover(sender As Object, e As EventArgs) Handles btnEMV.MouseHover
        btnEMV.Image = My.Resources.EMV_selected
    End Sub

    Private Sub btnEMV_MouseLeave(sender As Object, e As EventArgs) Handles btnEMV.MouseLeave
        btnEMV.Image = My.Resources.EMV
    End Sub

    Private Sub btnOther_Click(sender As Object, e As EventArgs) Handles btnOther.Click
        'TODO
    End Sub

    Private Sub btnOther_MouseHover(sender As Object, e As EventArgs) Handles btnOther.MouseHover
        btnOther.Image = My.Resources.other_selected
    End Sub

    Private Sub btnOther_MouseLeave(sender As Object, e As EventArgs) Handles btnOther.MouseLeave
        btnOther.Image = My.Resources.other
    End Sub
End Class