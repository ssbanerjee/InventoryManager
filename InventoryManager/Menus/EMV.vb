Public Class EMV
    Private Sub btnVeriFone_Click(sender As Object, e As EventArgs) Handles btnVeriFone.Click
        AddEMV.emvType = "VeriFone EMV"
        Close()
    End Sub

    Private Sub btnIngenico_Click(sender As Object, e As EventArgs) Handles btnIngenico.Click
        AddEMV.emvType = "Ingenico EMV"
        Close()
    End Sub
End Class