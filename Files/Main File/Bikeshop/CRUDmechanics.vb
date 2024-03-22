Imports MySql.Data.MySqlClient
Imports System.IO
Public Class CRUDmechanics
    Dim mydatarecords As DataTable = New DataTable
    Dim sqlString As String = ""
    Dim connClass As New ConnectToDb
    Dim dbcomm As New MySqlCommand
    Dim dbread As MySqlDataReader
    Dim image_path As String
    Dim path As String
    Dim OpenFileDialog1 As New OpenFileDialog
    Private Sub CRUDmechanics_Load(sender As Object, e As EventArgs) Handles MyBase.Load, Refresh.Click
        connClass.OpenConnection()
        sqlString = "SELECT * FROM Users"
        '"SELECT Name,Email,ContactNum,Photo,Description FROM Users"
        mydatarecords = connClass.selectFrom(sqlString)
        Dgrid1.DataSource = mydatarecords
    End Sub

    'Private Sub Insert_Click(sender As Object, e As EventArgs)
    '    Dim arrImage() As Byte
    '    Dim mstream As New System.IO.MemoryStream()
    '    photo.Image.Save(mstream, System.Drawing.Imaging.ImageFormat.Jpeg)
    '    arrImage = mstream.GetBuffer()
    '    Dim FileSize As UInt32
    '    FileSize = mstream.Length
    '    mstream.Close()
    '    Try
    '        connClass.OpenConnection()
    '        Dim sqlString1 As String = "INSERT INTO Users(Name,Email,ContactNum,Photo) VALUES (@Name,@Email,@ContactNum,@Photo)"
    '        With dbcomm
    '            .Connection = connClass.dbconn
    '            .CommandText = sqlString1
    '            .Parameters.AddWithValue("@Name", mechName.Text)
    '            .Parameters.AddWithValue("@Email", eMail.Text)
    '            .Parameters.AddWithValue("@ContactNum", contactNum.Text)
    '            .Parameters.AddWithValue("@Photo", arrImage)
    '        End With
    '        Dim r As Integer
    '        r = dbcomm.ExecuteNonQuery()

    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message.ToString)
    '    End Try
    '    connClass.closeCOn()

    'End Sub

    Private Sub BunifuButton2_Click(sender As Object, e As EventArgs) Handles BunifuButton2.Click
        Dim result As DialogResult = OpenFileDialog1.ShowDialog()
        If result = DialogResult.OK Then
            path = OpenFileDialog1.FileName
            Dim destination = OpenFileDialog1.SafeFileName
            image_path = "D:\Photo\" & destination
            photo.ImageLocation = path
        End If
    End Sub

    Private Sub BunifuButton1_Click(sender As Object, e As EventArgs) Handles BunifuButton1.Click
        photo.Image = Nothing
    End Sub

    Private Sub Update_Click(sender As Object, e As EventArgs) Handles Update.Click

        Dim ms As New MemoryStream
        Dim bm As Bitmap = New Bitmap(photo.Image)
        bm.Save(ms, photo.Image.RawFormat)
        Dim arrPic() As Byte = ms.GetBuffer()
        Try
            connClass.OpenConnection()
            Dim sqlString1 As String = "UPDATE Users Set uszrName=@uszrName,pssWrdz=@pssWrdz,Name=@Name,Email=@Email,ContactNum=@ContactNum,Photo=@Photo WHERE users_ID=@users_ID"
            With dbcomm
                .Connection = connClass.dbconn
                .CommandText = sqlString1
                .Parameters.AddWithValue("@users_ID", userID.Text)
                .Parameters.AddWithValue("@Username", userNames.Text)
                .Parameters.AddWithValue("@Password", passWrd.Text)
                .Parameters.AddWithValue("@Name", oMnames.Text)
                .Parameters.AddWithValue("@Email", eMail.Text)
                .Parameters.AddWithValue("@ContactNum", contactNum.Text)
                .Parameters.AddWithValue("@Photo", arrPic)
            End With
            Dim r As Integer
            r = dbcomm.ExecuteNonQuery()
            sqlString = "SELECT Name,Email,ContactNum,Photo,Description FROM Users"
            mydatarecords = connClass.selectFrom(sqlString)
            Dgrid1.DataSource = mydatarecords
            connClass.closeCOn()


        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try
    End Sub

    Private Sub BunifuButton3_Click(sender As Object, e As EventArgs) Handles BunifuButton3.Click

        Try
            Dim arrImage() As Byte
            Dim mstream As New System.IO.MemoryStream()
            photo.Image.Save(mstream, System.Drawing.Imaging.ImageFormat.Jpeg)
            arrImage = mstream.GetBuffer()
            Dim FileSize As UInt32
            FileSize = mstream.Length
            mstream.Close()
            connClass.OpenConnection()
            Dim sqlString1 As String = "INSERT INTO Users(users_ID,uszrName,pssWrdz,Name,Email,ContactNum,Photo,Description) VALUES (@users_ID,@uszrName,@pssWrdz,@Name,@Email,@ContactNum,@Photo,@Description)"
            With dbcomm
                .Connection = connClass.dbconn
                .CommandText = sqlString1
                .Parameters.AddWithValue("@users_ID", userID.Text)
                .Parameters.AddWithValue("@uszrName", userNames.Text)
                .Parameters.AddWithValue("@pssWrdz", passWrd.Text)
                .Parameters.AddWithValue("@Name", oMnames.Text)
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
        dbcomm.Parameters.Clear()
        connClass.closeCOn()
    End Sub

    Private Sub BunifuButton4_Click(sender As Object, e As EventArgs) Handles BunifuButton4.Click
        connClass.OpenConnection()
        sqlString = "DELETE FROM Users WHERE users_ID = '" & Val(userID.Text) & "'"
        connClass.deleteFrom(sqlString)
        sqlString = "SELECT * FROM Users"
        mydatarecords = connClass.selectFrom(sqlString)
        Dgrid1.DataSource = mydatarecords
    End Sub

    Private Sub BunifuButton5_Click(sender As Object, e As EventArgs) Handles BunifuButton5.Click
        Try
            mydatarecords = connClass.selectFrom("SELECT * FROM Users WHERE users_ID ='" & Val(userID.Text) & "'")
            If (mydatarecords.Rows.Count > 0) Then
                Dgrid1.DataSource = mydatarecords
            Else
                MessageBox.Show("Not Found!")
            End If
        Catch ex As Exception
            MsgBox("Error in collecting data from Database. Error is :" & ex.Message)
        End Try
    End Sub
End Class