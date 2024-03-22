Imports System.IO
Imports MySql.Data.MySqlClient
Public Class USER_REGISTER
    Dim mydatarecords As DataTable = New DataTable
    Dim sqlString As String = ""
    Dim connClass As New ConnectToDb
    Dim dbcomm As New MySqlCommand
    Dim dbread As MySqlDataReader
    Dim image_path As String
    Dim path As String
    Dim OpenFileDialog1 As New OpenFileDialog
    Public Function Hashing(ByVal Laman As String) As String
        Dim pagod As New Security.Cryptography.SHA512CryptoServiceProvider
        Dim bytes() As Byte = System.Text.Encoding.ASCII.GetBytes(Laman)
        bytes = pagod.ComputeHash(bytes)

        Dim final As String = Nothing

        For Each bt As Byte In bytes
            final &= bt.ToString("x2")
        Next

        Return final

    End Function
    Private Sub Insert_Click(sender As Object, e As EventArgs) Handles Insert.Click
        Dim arrImage() As Byte
        Dim mstream As New System.IO.MemoryStream()
        photo.Image.Save(mstream, System.Drawing.Imaging.ImageFormat.Jpeg)
        arrImage = mstream.GetBuffer()
        Dim FileSize As UInt32
        FileSize = mstream.Length
        mstream.Close()
        Try
            connClass.OpenConnection()
            Dim sqlString1 As String = "INSERT INTO Users(users_ID,uszrName,pssWrdz,Name,Email,ContactNum,Photo,Description) VALUES (@users_ID,@uszrName,@pssWrdz,@Name,@Email,@ContactNum,@Photo,@Description)"
            With dbcomm
                .Connection = connClass.dbconn
                .CommandText = sqlString1
                .Parameters.AddWithValue("@users_ID", users_ID.Text)
                .Parameters.AddWithValue("@uszrName", userName.Text)
                .Parameters.AddWithValue("@pssWrdz", Hashing(passWord.Text))
                .Parameters.AddWithValue("@Name", fullName.Text)
                .Parameters.AddWithValue("@Email", eMail.Text)
                .Parameters.AddWithValue("@ContactNum", contactNum.Text)
                .Parameters.AddWithValue("@Photo", arrImage)
                .Parameters.AddWithValue("@Description", desc.Text)
            End With

            Dim r As Integer
            r = dbcomm.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
        connClass.closeCOn()
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub USER_REGISTER_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub BunifuButton1_Click(sender As Object, e As EventArgs) Handles BunifuButton1.Click
        Dim result As DialogResult = OpenFileDialog1.ShowDialog()
        If result = DialogResult.OK Then
            path = OpenFileDialog1.FileName
            Dim destination = OpenFileDialog1.SafeFileName
            image_path = "D:\Photo\" & destination
            photo.ImageLocation = path
        End If
    End Sub

    Private Sub BunifuButton2_Click(sender As Object, e As EventArgs) Handles BunifuButton2.Click
        photo.Image = Nothing
    End Sub
End Class