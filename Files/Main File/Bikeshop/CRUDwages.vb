Imports MySql.Data.MySqlClient
Public Class CRUDwages
    Dim mydatarecords As DataTable = New DataTable
    Dim sqlString As String = ""
    Dim connClass As ConnectToDb = New ConnectToDb
    Dim dbcomm As New MySqlCommand
    Dim dbread As MySqlDataReader
    Private Sub CRUDwages_Load(sender As Object, e As EventArgs) Handles MyBase.Load, Refresh.Click
        dbcomm.Connection = connClass.dbconn
        connClass.OpenConnection()
        sqlString = "SELECT * FROM Wagez"
        mydatarecords = connClass.selectFrom(sqlString)
        Dgrid1.DataSource = mydatarecords
    End Sub

    Private Sub Insert_Click(sender As Object, e As EventArgs) Handles Insert.Click
        'You cant have Mechanics unless you register In Users as Mechanic
        Try
            dbcomm.Connection = connClass.dbconn
            connClass.OpenConnection()
            Dim sqlString1 As String = "INSERT INTO Wagez(Wagez_ID,Salary,Salary_Date) VALUES (@Wagez_ID,@Salary,@Salary_Date)"
            With dbcomm
                .Connection = connClass.dbconn
                .CommandText = sqlString1
                .Parameters.AddWithValue("@Wagez_ID", wages_ID.Text)
                .Parameters.AddWithValue("@Salary", Salary.Text)
                .Parameters.AddWithValue("@Salary_Date", SalaryDate.Text)
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
        sqlString = "UPDATE Wagez Set Salary = '" & Salary.Text & "', Salary_Date= '" & SalaryDate.Text & "' WHERE Wagez_ID =" & wages_ID.Text & ""
        connClass.updateFrom(sqlString)
        Dgrid1.DataSource = mydatarecords
    End Sub

    Private Sub Delete_Click(sender As Object, e As EventArgs) Handles Delete.Click
        dbcomm.Connection = connClass.dbconn
        connClass.OpenConnection()
        sqlString = "DELETE FROM Wagez WHERE Wagez_ID = '" & Val(wages_ID.Text) & "'"
        connClass.deleteFrom(sqlString)
    End Sub

    Private Sub Check_Click(sender As Object, e As EventArgs) Handles Check.Click
        Try
            mydatarecords = connClass.selectFrom("SELECT * FROM Wagez WHERE Wagez_ID ='" & Val(wages_ID.Text) & "'")
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
        SalaryDate.Text = Format(DateTimePicker1.Value, "yyyy/MM/dd")

    End Sub
End Class