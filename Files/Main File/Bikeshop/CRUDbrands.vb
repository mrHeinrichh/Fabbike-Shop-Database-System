Imports MySql.Data.MySqlClient
Public Class CRUDbrands
    Dim mydatarecords As DataTable = New DataTable
    Dim sqlString As String = ""
    Dim connClass As ConnectToDb = New ConnectToDb
    Dim dbcomm As New MySqlCommand
    Dim dbread As MySqlDataReader
    Private Sub CRUDbrands_Load(sender As Object, e As EventArgs) Handles MyBase.Load, Refresh.Click
        dbcomm.Connection = connClass.dbconn
        connClass.OpenConnection()
        sqlString = "SELECT * FROM Brandz"
        mydatarecords = connClass.selectFrom(sqlString)
        Dgrid1.DataSource = mydatarecords
    End Sub

    Private Sub Insert_Click(sender As Object, e As EventArgs) Handles Insert.Click
        Try
            dbcomm.Connection = connClass.dbconn
            connClass.OpenConnection()
            Dim sqlString1 As String = "INSERT INTO Brandz(Brand_ID,brand_Name) VALUES (@Brand_ID,@brand_Name)"
            With dbcomm
                .Connection = connClass.dbconn
                .CommandText = sqlString1

                .Parameters.AddWithValue("@Brand_ID", brandID.Text)
                .Parameters.AddWithValue("@brand_Name", brandName.Text)
            End With
            Dim r As Integer
            r = dbcomm.ExecuteNonQuery()
            dbcomm.Parameters.Clear()
            connClass.closeCOn()
            Output.Text = Val(sqlString1)
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Sub Update_Click(sender As Object, e As EventArgs) Handles Update.Click
        dbcomm.Connection = connClass.dbconn
        connClass.OpenConnection()
        sqlString = "UPDATE Brandz Set brand_Name = '" & brandName.Text & "' WHERE Brand_ID =" & brandID.Text & ""
        connClass.updateFrom(sqlString)
        Dgrid1.DataSource = mydatarecords
    End Sub

    Private Sub Delete_Click(sender As Object, e As EventArgs) Handles Delete.Click
        dbcomm.Connection = connClass.dbconn
        connClass.OpenConnection()
        sqlString = "DELETE FROM Brandz WHERE Brand_ID = '" & Val(brandID.Text) & "'"
        connClass.deleteFrom(sqlString)
        sqlString = "SELECT * FROM Brandz"
        mydatarecords = connClass.selectFrom(sqlString)
        Dgrid1.DataSource = mydatarecords
    End Sub

    Private Sub Check_Click(sender As Object, e As EventArgs) Handles Check.Click
        Try
            mydatarecords = connClass.selectFrom("SELECT * FROM Brandz WHERE Brand_ID ='" & Val(brandID.Text) & "'")
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