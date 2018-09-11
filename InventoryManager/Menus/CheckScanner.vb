Public Class CheckScanner
    Private Sub btnTinyInOne_Click(sender As Object, e As EventArgs) Handles btnTinyInOne.Click
        AddCheckScanner.machineType = "ThinkCentre Tiny-in-One"
        Close()
    End Sub

    Private Sub btnScanner_Click(sender As Object, e As EventArgs) Handles btnScanner.Click
        AddCheckScanner.machineType = "Check Scanner"
        Close()
    End Sub
End Class