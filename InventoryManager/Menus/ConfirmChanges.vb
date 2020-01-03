Public Class ConfirmChanges
    Private Sub ConfirmChanges_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblOldMachine.Text =
            "OLD MACHINE INFO:" + vbNewLine + vbNewLine +
            "Machine name: " + EditMachine.oldMachine.machineName + vbNewLine +
            "Asset Tag: " + EditMachine.oldMachine.assetTag + vbNewLine +
            "Serial Number: " + EditMachine.oldMachine.serialNumber + vbNewLine +
            "Model: " + EditMachine.oldMachine.model + vbNewLine +
            "Shipping to: " + EditMachine.oldMachine.centerNumber + vbNewLine +
            "Cost Center: " + EditMachine.oldMachine.costCenter + vbNewLine +
            "Condition: " + EditMachine.oldMachine.condition + vbNewLine +
            "Ticket Number: " + EditMachine.oldMachine.MESD

        lblNewMachine.Text =
            "NEW MACHINE INFO:" + vbNewLine + vbNewLine +
            "Machine name: " + EditMachine.newMachine.machineName + vbNewLine +
            "Asset Tag: " + EditMachine.newMachine.assetTag + vbNewLine +
            "Serial Number: " + EditMachine.newMachine.serialNumber + vbNewLine +
            "Model: " + EditMachine.newMachine.model + vbNewLine +
            "Shipping to: " + EditMachine.newMachine.centerNumber + vbNewLine +
            "Cost Center: " + EditMachine.newMachine.costCenter + vbNewLine +
            "Condition: " + EditMachine.newMachine.condition + vbNewLine +
            "Ticket Number: " + EditMachine.newMachine.MESD
    End Sub

    Private Sub BtnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        EditMachine.confirm = True
        Close()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        EditMachine.confirm = False
        Close()
    End Sub
End Class