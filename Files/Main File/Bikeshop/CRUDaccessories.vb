Imports System.IO
Imports MySql.Data.MySqlClient
Public Class CRUDaccessories
    Dim mydatarecords As DataTable = New DataTable
    Dim sqlString As String = ""
    Dim connClass As New ConnectToDb
    Dim dbcomm As New MySqlCommand
    Dim dbread As MySqlDataReader
    Dim image_path As String
    Dim path As String
    Dim OpenFileDialog1 As New OpenFileDialog
    Private Sub CRUDaccessories_Load(sender As Object, e As EventArgs) Handles MyBase.Load, Refresh.Click
        connClass.OpenConnection()
        sqlString = "SELECT photo, cost_Price, Descz, brand_Name FROM accessoriez
INNER JOIN brandz;"
        mydatarecords = connClass.selectFrom(sqlString)
        Dgrid1.DataSource = mydatarecords
    End Sub

    Private Sub Update_Click(sender As Object, e As EventArgs) Handles Update.Click
        Dim ms As New MemoryStream
        Dim bm As Bitmap = New Bitmap(photo.Image)
        bm.Save(ms, photo.Image.RawFormat)
        Dim arrPic() As Byte = ms.GetBuffer()

        connClass.OpenConnection()
        Dim sqlString1 As String = "UPDATE Accessoriez Set Photo=@Photo, Cost_Price=@Cost_Price, Descz=@Descz WHERE Accessories_ID=@Accessories_ID"
        With dbcomm
            .Connection = connClass.dbconn
            .CommandText = sqlString1
            .Parameters.AddWithValue("@Accessories_ID", prodID.Text)
            .Parameters.AddWithValue("@Photo", arrPic)
            .Parameters.AddWithValue("@Cost_Price", costPrice.Text)
            .Parameters.AddWithValue("@Descz", desc.Text)
        End With
        Dim r As Integer
        r = dbcomm.ExecuteNonQuery()
    End Sub

    Private Sub BunifuButton1_Click(sender As Object, e As EventArgs) Handles BunifuButton1.Click
        photo.Image = Nothing
    End Sub

    Private Sub BunifuButton4_Click(sender As Object, e As EventArgs) Handles BunifuButton4.Click
        dbcomm.Connection = connClass.dbconn
        connClass.OpenConnection()
        sqlString = "DELETE FROM Accessoriez WHERE Accessories_ID = '" & Val(prodID.Text) & "'"
        connClass.deleteFrom(sqlString)
        sqlString = "SELECT photo, cost_Price, Descz, brand_Name FROM accessoriez
INNER JOIN brandz"
        mydatarecords = connClass.selectFrom(sqlString)
        Dgrid1.DataSource = mydatarecords
    End Sub

    Private Sub BunifuButton5_Click(sender As Object, e As EventArgs) Handles BunifuButton5.Click
        Try
            mydatarecords = connClass.selectFrom("SELECT * FROM Accessoriez WHERE Accessories_ID ='" & Val(prodID.Text) & "'")
            If (mydatarecords.Rows.Count > 0) Then
                Dgrid1.DataSource = mydatarecords
            Else
                MessageBox.Show("Not Found!")
            End If
        Catch ex As Exception
            MsgBox("Error in collecting data from Database. Error is :" & ex.Message)
        End Try
    End Sub

    Private Sub BunifuButton2_Click(sender As Object, e As EventArgs) Handles BunifuButton2.Click
        Dim result As DialogResult = OpenFileDialog1.ShowDialog()
        If result = DialogResult.OK Then
            path = OpenFileDialog1.FileName
            Dim destination = OpenFileDialog1.SafeFileName
            image_path = "D:\Photo\" & destination
            photo.ImageLocation = path
        End If
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
            Dim sqlString1 As String = "INSERT INTO Accessoriez(Accessories_ID,Photo,Cost_Price,Descz) VALUES (@Accessories_ID,@Photo,@Cost_Price,@Descz)"
            With dbcomm
                .Connection = connClass.dbconn
                .CommandText = sqlString1

                .Parameters.AddWithValue("@Accessories_ID", prodID.Text)
                .Parameters.AddWithValue("@Photo", arrImage)
                .Parameters.AddWithValue("@Cost_price", costPrice.Text)
                .Parameters.AddWithValue("@Descz", desc.Text)
            End With

            Dim r As Integer
            r = dbcomm.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
        dbcomm.Parameters.Clear()
        connClass.closeCOn()
    End Sub
End Class