Imports MySql.Data.MySqlClient
Public Class mechanicFORM
    Dim mydatarecords As DataTable = New DataTable
    Public sqlString1 As String = ""
    Dim connClass As ConnectToDb = New ConnectToDb
    Dim dbcomm As New MySqlCommand
    Dim dbread As MySqlDataReader
    Dim da As New MySqlDataAdapter
    Private Sub BunifuImageButton1_Click(sender As Object, e As EventArgs) Handles BunifuImageButton1.Click
        Me.Close()
    End Sub

    Private Sub proFIle_Click(sender As Object, e As EventArgs) Handles proFIle.Click
        mechPROFILE.MdiParent = Me
        mechPROFILE.Dock = DockStyle.Fill
        mechPROFILE.Show()
    End Sub

    Private Sub mechanicFORM_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            Dim arrImage() As Byte
            mydatarecords = connClass.selectFrom(sqlString1)
            arrImage = mydatarecords.Rows(0).Item("Photo")
            Dim mstream As New System.IO.MemoryStream(arrImage)
            PictureBox1.Image = Image.FromStream(mstream)
            'Label1.Text = mydatarecords.Rows(0).Item("Name").ToString()
            mechPROFILE.MdiParent = Me
            mechPROFILE.Dock = DockStyle.Fill
            mechPROFILE.Show()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BunifuButton1_Click(sender As Object, e As EventArgs) Handles BunifuButton1.Click
        MECHWAGEZ.MdiParent = Me
        MECHWAGEZ.Dock = DockStyle.Fill
        MECHWAGEZ.Show()
    End Sub

    Private Sub BunifuButton2_Click(sender As Object, e As EventArgs) Handles BunifuButton2.Click
        mechserv.MdiParent = Me
        mechserv.Dock = DockStyle.Fill
        mechserv.Show()
    End Sub
End Class