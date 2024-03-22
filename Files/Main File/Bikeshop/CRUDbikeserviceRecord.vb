Imports MySql.Data.MySqlClient
Public Class CRUDbikeserviceRecord
    Dim mydatarecords As DataTable = New DataTable
    Dim sqlString As String = ""
    Dim connClass As ConnectToDb = New ConnectToDb
    Dim dbcomm As New MySqlCommand
    Dim dbread As MySqlDataReader
    Private Sub CRUDbikeserviceRecord_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connClass.OpenConnection()
        sqlString = "SELECT * FROM Bike_Service"
        mydatarecords = connClass.selectFrom(sqlString)
        Dgrid1.DataSource = mydatarecords
    End Sub

    Private Sub Check_Click(sender As Object, e As EventArgs) Handles Check.Click
        Try
            mydatarecords = connClass.selectFrom("SELECT * FROM Bike_Service WHERE Service_ID ='" & Val(suppID.Text) & "'")
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