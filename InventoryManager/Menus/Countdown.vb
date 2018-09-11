Public Class Countdown
    Private PICKUP_TIME As DateTime = DateTime.Parse("16:00:00")
    Private PICKUP_TIME_NIGHT As DateTime = DateTime.Parse("19:30:00")
    Private currentTime As DateTime
    Private timeLeft As TimeSpan

    Private Sub tmrCountdown_Tick(sender As Object, e As EventArgs) Handles tmrCountdown.Tick
        currentTime = System.DateTime.Now
        timeLeft = PICKUP_TIME.Subtract(currentTime)

        If timeLeft.Seconds < 0 Then
            lblTime.Location = New Point(3, 81)
            lblTime.Text = "SHIPPED"
            lblTime.ForeColor = Color.Red
        Else
            lblTime.Location = New Point(9, 81)
            lblTime.Text = String.Format("{0:00}:{1:00}:{2:00}",
               CType(timeLeft.TotalHours, Int64),
                    timeLeft.Minutes,
                    timeLeft.Seconds)
            If timeLeft.Minutes <= 5 And timeLeft.Hours < 1 Then

                If lblTime.ForeColor = Color.Black Then
                    lblTime.ForeColor = Color.Red
                Else
                    lblTime.ForeColor = Color.Black
                End If
            End If
        End If


    End Sub

    Private Sub Countdown_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblText.Text = "Time Left To" + vbNewLine + "UPS Pickup"
    End Sub
End Class