Imports MySql.Data.MySqlClient
Public Class CRUDbikeservices
    Dim mydatarecords As DataTable = New DataTable
    Dim sqlString As String = ""
    Dim connClass As ConnectToDb = New ConnectToDb
    Dim dbcomm As New MySqlCommand
    Dim dbread As MySqlDataReader
    Private Sub CRUDbikeservices_Load(sender As Object, e As EventArgs) Handles MyBase.Load, Refresh.Click
        connClass.OpenConnection()
        sqlString = "SELECT * FROM Bike_Service"
        mydatarecords = connClass.selectFrom(sqlString)
        Dgrid1.DataSource = mydatarecords
    End Sub

    Private Sub Insert_Click(sender As Object, e As EventArgs) Handles Insert.Click
        Try
            connClass.OpenConnection()
            Dim sqlString1 As String = "INSERT INTO Bike_Service(Service_ID,Service_Info,Service_Date,Service_Cost) VALUES (@Service_ID,@Service_Info,@Service_Date,@Service_Cost)"
            With dbcomm
                .Connection = connClass.dbconn
                .CommandText = sqlString1

                .Parameters.AddWithValue("@Service_ID", serviceID.Text)
                .Parameters.AddWithValue("@Service_Info", serviceInfo.Text)
                .Parameters.AddWithValue("@Service_Date", serviceDate.Text)
                .Parameters.AddWithValue("@Service_Cost", serviceCost.Text)
            End With
            Dim r As Integer
            r = dbcomm.ExecuteNonQuery()
            dbcomm.Parameters.Clear()
            connClass.closeCOn()
            Output.Text = Val(sqlString1)
            CRUDbikeservices_Load(sender, e)
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Sub Update_Click(sender As Object, e As EventArgs) Handles Update.Click
        mydatarecords.Clear()
        connClass.OpenConnection()
        sqlString = "UPDATE Bike_Service Set Service_Info = '" & serviceInfo.Text & "', Service_Date = '" & serviceDate.Text & "', Service_Cost = '" & serviceCost.Text & "' WHERE Service_ID =" & serviceID.Text & ""
        connClass.updateFrom(sqlString)
        Dgrid1.DataSource = mydatarecords
    End Sub

    Private Sub Delete_Click(sender As Object, e As EventArgs) Handles Delete.Click
        connClass.OpenConnection()
        sqlString = "DELETE FROM Bike_Service WHERE Service_ID = '" & Val(serviceID.Text) & "'"
        connClass.deleteFrom(sqlString)
        sqlString = "SELECT * FROM Bike_Service"
        mydatarecords = connClass.selectFrom(sqlString)
        Dgrid1.DataSource = mydatarecords
    End Sub

    Private Sub Check_Click(sender As Object, e As EventArgs) Handles Check.Click
        Try
            mydatarecords = connClass.selectFrom("SELECT * FROM Bike_Service WHERE Service_ID ='" & Val(serviceID.Text) & "'")
            If (mydatarecords.Rows.Count > 0) Then
                Dgrid1.DataSource = mydatarecords
            Else
                MessageBox.Show("Not Found!")
            End If
        Catch ex As Exception
            MsgBox("Error in collecting data from Database. Error is :" & ex.Message)
        End Try
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        serviceDate.Text = Format(DateTimePicker1.Value, "yyyy/MM/dd")
    End Sub
End Class