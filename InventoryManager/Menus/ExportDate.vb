Public Class ExportDate
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        ShippingMenu.exportSelection = Calendar.SelectionRange.Start.ToShortDateString()
        Close()
    End Sub

    Private Sub ExportDate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Calendar.MaxDate = Now
    End Sub
End Class