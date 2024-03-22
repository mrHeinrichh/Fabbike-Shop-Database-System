Imports MySql.Data.MySqlClient
Public Class CRUDoperationsexp
    Dim mydatarecords As DataTable = New DataTable
    Dim sqlString As String = ""
    Dim connClass As ConnectToDb = New ConnectToDb
    Dim dbcomm As New MySqlCommand
    Dim dbread As MySqlDataReader
    Private Sub CRUDoperationsexp_Load(sender As Object, e As EventArgs) Handles MyBase.Load, Refresh.Click
        dbcomm.Connection = connClass.dbconn
        connClass.OpenConnection()
        sqlString = "SELECT * FROM Operating_Expenses"
        mydatarecords = connClass.selectFrom(sqlString)
        Dgrid1.DataSource = mydatarecords
    End Sub

    Private Sub Insert_Click(sender As Object, e As EventArgs) Handles Insert.Click
        Try
            dbcomm.Connection = connClass.dbconn
            connClass.OpenConnection()
            Dim sqlString1 As String = "INSERT INTO Operating_Expenses(Operating_Expenses_ID,Description,Price,dueDate) VALUES (@Operating_Expenses_ID,@Description,@Price,@dueDate)"
            With dbcomm
                .Connection = connClass.dbconn
                .CommandText = sqlString1

                .Parameters.AddWithValue("@Operating_Expenses_ID", expId.Text)
                .Parameters.AddWithValue("@Description", desc.Text)
                .Parameters.AddWithValue("@Price", price.Text)
                .Parameters.AddWithValue("@dueDate", dDate.Text)
            End With
            Dim r As Integer
            r = dbcomm.ExecuteNonQuery()
            dbcomm.Parameters.Clear()
            connClass.closeCOn()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Sub Update_Click(sender As Object, e As EventArgs) Handles Update.Click
        dbcomm.Connection = connClass.dbconn
        connClass.OpenConnection()
        sqlString = "UPDATE Operating_Expenses Set Description= '" & desc.Text & "', Price= '" & price.Text & "',dueDate= '" & dDate.Text & "' WHERE Operating_Expenses_ID =" & expId.Text & ""
        connClass.updateFrom(sqlString)
        Dgrid1.DataSource = mydatarecords
    End Sub

    Private Sub Delete_Click(sender As Object, e As EventArgs) Handles Delete.Click
        dbcomm.Connection = connClass.dbconn
        connClass.OpenConnection()
        sqlString = "DELETE FROM Operating_Expenses WHERE Operating_Expenses_ID = '" & Val(expId.Text) & "'"
        connClass.deleteFrom(sqlString)
        sqlString = "SELECT * FROM Operating_Expenses"
        mydatarecords = connClass.selectFrom(sqlString)
        Dgrid1.DataSource = mydatarecords
    End Sub

    Private Sub Check_Click(sender As Object, e As EventArgs) Handles Check.Click
        Try
            mydatarecords = connClass.selectFrom("SELECT * FROM Operating_Expenses WHERE Operating_Expenses_ID ='" & Val(expId.Text) & "'")
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
        dDate.Text = Format(DateTimePicker1.Value, "yyyy/MM/dd")
    End Sub
End Class