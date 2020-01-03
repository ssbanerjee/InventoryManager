'NOT IMPLEMENTED YET
Imports System.Data.SqlClient
Imports System.ComponentModel

Public Class AdminMenu

    Private sqlCon As SqlConnection
    Private sqlCmd As SqlCommand
    Private sqlReader As SqlDataReader

    Private Sub AdminMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        sqlCon = New SqlConnection("Data Source=dev-sqlbi01;Initial Catalog=MesdTest;Integrated Security=True")
        sqlCon.Open()
        sqlCmd = sqlCon.CreateCommand()
    End Sub

    Private Sub run()
        Dim centers As New List(Of String)
        Dim siteIDs As New List(Of String)
        Dim orgID As String = ""
        Dim orgIDCenter As String = ""

        txtResults.Text = "Starting process..." + vbNewLine
        centers = LoadCenters()

        For Each center As String In centers
            orgID = getOrgID(center)
            sqlReader.Close()
            If Not orgID = "0" Then
                'txtResults.Text += "OrgID = " + orgID + vbNewLine

                siteIDs = getLikeSiteIDs(center)
                sqlReader.Close()
                'txtResults.Text += "SiteIDs:" + vbNewLine
                For Each siteID In siteIDs
                    'txtResults.Text += siteID + vbNewLine
                    sqlCmd.CommandText = "UPDATE ResourceLocation SET SITEID = '" + orgID + "' WHERE SITEID = '" + siteID + "';"
                    'txtResults.Text += sqlcmd.CommandText + vbNewLine
                    sqlReader = sqlCmd.ExecuteReader
                    sqlReader.Close()
                Next

                orgIDCenter = getOrgIDCenter(center)
                sqlReader.Close()
                If Not orgIDCenter = "0" Then
                    'txtResults.Text += "OrgID = " + orgIDCenter + vbNewLine
                    sqlCmd.CommandText = "UPDATE ResourceLocation SET SITEID = '" + orgID + "' WHERE SITEID = '" + orgIDCenter + "';"
                    'txtResults.Text += sqlCmd.CommandText + vbNewLine
                    sqlReader = sqlCmd.ExecuteReader
                    sqlReader.Close()
                End If
            End If
        Next
        txtResults.Text = "Done."
    End Sub

    Private Function getOrgID(ByVal center As String) As String
        sqlCmd.CommandText = "SELECT ORG_ID FROM SDOrganization WHERE NAME = '" + center + "';"
        'sqlCmd.CommandText = "SELECT @@SERVERNAME AS 'Server Name'"
        sqlReader = sqlCmd.ExecuteReader
        If sqlReader.Read() Then
            Return sqlReader.GetInt64(0).ToString
            ' Return sqlReader.GetDateTime(0).ToString("MM/dd/yyy")
        Else
            Return "0"
        End If
    End Function

    Private Function getLikeSiteIDs(ByVal orgID) As List(Of String)
        Dim likeIDs As New List(Of String)
        sqlCmd.CommandText = "SELECT ORG_ID FROM SDOrganization WHERE NAME like '" + orgID + "%' OR name like '%" + orgID + "';"
        sqlReader = sqlCmd.ExecuteReader
        While sqlReader.Read()
            likeIDs.Add(sqlReader.GetInt64(0).ToString)
        End While

        Return likeIDs
    End Function

    Private Function getOrgIDCenter(ByVal center As String) As String
        sqlCmd.CommandText = "SELECT a.ORG_ID FROM SDOrganization a INNER JOIN [rich-dw01].amfdw.dbo.dimbowlingCenter b ON a.name = b.name WHERE b.centernumber = " + center + ";"
        'sqlCmd.CommandText = "SELECT @@SERVERNAME AS 'Server Name'"
        sqlReader = sqlCmd.ExecuteReader
        If sqlReader.Read() Then
            Return sqlReader.GetInt64(0).ToString
            ' Return sqlReader.GetDateTime(0).ToString("MM/dd/yyy")
        Else
            Return "0"
        End If
    End Function

    Public Function LoadCenters() As List(Of String)
        Dim myCon As SqlConnection
        Dim myCmd As SqlCommand
        Dim myReader As SqlDataReader
        myCon = New SqlConnection(connectionString)
        myCon.Open()
        myCmd = myCon.CreateCommand

        Dim centers As New List(Of String)
        Dim centerNumberInt As Integer
        Dim centerNumber As String = ""

        myCmd.CommandText = "SELECT center_number FROM Center WHERE center_number > 0 AND center_number < 900 ORDER BY center_number ASC;"
        myReader = myCmd.ExecuteReader
        While myReader.Read()
            centerNumberInt = myReader.GetInt32(0)

            If centerNumberInt < 100 Then
                centerNumber = "0" + centerNumberInt.ToString
            Else
                centerNumber = centerNumberInt.ToString
            End If
            centers.Add(centerNumber)
        End While

        myReader.Close()
        Return centers
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        run()
    End Sub
End Class