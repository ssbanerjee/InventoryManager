Public Class ChangeLog
    Private Sub ChangeLog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblChangeLog.Text = My.Resources.changeLog
    End Sub

    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Close()
    End Sub
End Class