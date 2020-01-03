Public Class ChangeLog
    Private Sub ChangeLog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim fileReader As String
        fileReader = My.Computer.FileSystem.ReadAllText("Text Files\changeLog.txt")
        lblChangeLog.Text = fileReader
    End Sub

    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Close()
    End Sub
End Class