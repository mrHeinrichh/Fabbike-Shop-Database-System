Imports MySql.Data.MySqlClient
Public Class CRUDcustomer
    Dim mydatarecords As DataTable = New DataTable
    Dim sqlString As String = ""
    Dim connClass As ConnectToDb = New ConnectToDb
    Dim dbcomm As New MySqlCommand
    Dim dbread As MySqlDataReader
    Private Sub Insert_Click(sender As Object, e As EventArgs) Handles Insert.Click
        Try
            connClass.OpenConnection()
            Dim sqlString1 As String = "INSERT INTO customerz(customer_id,custName,ContactNum,Email) VALUES (@customers_id,@custName,@contactNum,@Email)"
            With dbcomm
                .Connection = connClass.dbconn
                .CommandText = sqlString1

                .Parameters.AddWithValue("@customers_id", customID.Text)
                .Parameters.AddWithValue("@custName", customName.Text)
                .Parameters.AddWithValue("@contactNum", ContactNum.Text)
                .Parameters.AddWithValue("@Email", eMail.Text)
            End With
            Dim r As Integer
            r = dbcomm.ExecuteNonQuery()

            connClass.closeCOn()
            Output.Text = Val(sqlString1)
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Sub CRUDcustomer_Load(sender As Object, e As EventArgs) Handles MyBase.Load, Refresh.Click
        dbcomm.Parameters.Clear()
        mydatarecords.Clear()
        connClass.OpenConnection()
        sqlString = "SELECT * FROM customerz"
        mydatarecords = connClass.selectFrom(sqlString)
        Dgrid1.DataSource = mydatarecords
    End Sub

    Private Sub Update_Click(sender As Object, e As EventArgs) Handles Update.Click
        connClass.OpenConnection()
        sqlString = "UPDATE customerz Set custName = '" & customName.Text & "', ContactNum= '" & ContactNum.Text & "', Email= '" & eMail.Text & "' WHERE customer_id =" & customID.Text & ""
        connClass.updateFrom(sqlString)
        Dgrid1.DataSource = mydatarecords

        'Try
        '    dbcomm.Connection = connClass.dbconn
        '    connClass.OpenConnection()
        '    Dim sqlString1 As String = "UPDATE customers SET name = '" & customName.Text & "', contactNum= '" & ContactNum.Text & "' WHERE customers_id =" & customID.Text & ""

        '    With dbcomm
        '        .Connection = connClass.dbconn
        '        .CommandText = sqlString1

        '        ' .Parameters.AddWithValue("@name", customName.Text)
        '        '  .Parameters.AddWithValue("@contactNum", contactNum.Text)
        '    End With
        '    Dim r As Integer
        '    r = dbcomm.ExecuteNonQuery()
        '    connClass.closeCOn()
        '    Output.Text = Val(sqlString1)
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message.ToString)
        'End Try
    End Sub

    Private Sub Delete_Click(sender As Object, e As EventArgs) Handles Delete.Click
        dbcomm.Connection = connClass.dbconn
        connClass.OpenConnection()
        sqlString = "DELETE FROM Customerz WHERE customer_Id = '" & Val(customID.Text) & "'"
        connClass.deleteFrom(sqlString)
        sqlString = "SELECT * FROM customerz"
        mydatarecords = connClass.selectFrom(sqlString)
        Dgrid1.DataSource = mydatarecords
    End Sub

    Private Sub Check_Click(sender As Object, e As EventArgs) Handles Check.Click
        Try
            mydatarecords = connClass.selectFrom("SELECT * FROM Customerz WHERE customer_ID ='" & Val(customID.Text) & "'")
            If (mydatarecords.Rows.Count > 0) Then
                Dgrid1.DataSource = mydatarecords
            Else
                MessageBox.Show("Not Found!")
            End If
        Catch ex As Exception
            MsgBox("Error in collecting data from Database. Error is :" & ex.Message)
        End Try
    End Sub
    'Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Refresh.Click, MyBase.Load
    '    conn.Open()
    '    cmb.Clear()
    '    DataAdapter1 = New MySqlDataAdapter("Select customers_Id FROM customers", conn)
    '    DataAdapter1.Fill(cmb, "customers")

    '    sql = "Select* FROM customers"
    '    DataAdapter1 = New MySqlDataAdapter(sql, conn)
    '    DataAdapter1.Fill(cmb, "cus")
    '    Dgrid1.DataSource = cmb
    '    Dgrid1.DataMember = "cus"

    '    conn.Close()
    'End Sub

    'Private Sub BunifuButton1_Click(sender As Object, e As EventArgs) Handles Insert.Click
    '    conn.Open()
    '    Try
    '        Dim ans = MessageBox.Show("Do you want To save this record?", "Save record", MessageBoxButtons.YesNo, MessageBoxIcon.Information)

    '        If ans = DialogResult.Yes Then
    '            sql = "INSERT INTO Customers(Name, contactNum) VALUES( '" & customName.Text & "', '" & ContactNum.Text & "')"
    '            Output.Text = sql

    '            If (db(sql, conn) = True) Then
    '                MessageBox.Show("Customer was Added!", "Fabs Bike Shop", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            End If

    '        End If

    '    Catch ex As Exception
    '        MsgBox("Error in collecting data from Database. Error is: " & ex.Message)
    '    End Try
    '    conn.Close()
    'End Sub

    'Private Sub BunifuButton2_Click(sender As Object, e As EventArgs) Handles Update.Click
    '    conn.Open()
    '    Try

    '        Dim ans = MessageBox.Show("Do you want to update this record?", "Update record", MessageBoxButtons.YesNo)

    '        If ans = DialogResult.Yes Then

    '            sql = "UPDATE customers SET customers_ID = '" & customID.Text & "' , name = '" & customName.Text & "', contactNum = '" & Val(ContactNum.Text) & ""
    '            Output.Text = sql

    '            If (db(sql, conn) = True) Then
    '                MessageBox.Show("Customer was Updated!", "Fabs Bike Shop", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            End If

    '        End If

    '    Catch ex As Exception
    '        MsgBox("Error in collecting data from Database. Error is: " & ex.Message)
    '    End Try
    '    conn.Close()
    'End Sub

    'Private Sub BunifuButton4_Click(sender As Object, e As EventArgs) Handles Delete.Click
    '    conn.Open()
    '    Try
    '        If MessageBox.Show("Are you sure in deleting this data?", "GabGab's Bike Shop", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

    '            sql = "DELETE FROM Customers WHERE Customers_Id = " & Val(customName.Text) & " "
    '            Output.Text = sql

    '            If (db(sql, conn) = True) Then
    '                MessageBox.Show("Customers_Id was Deleted!", "GabGab's Bike Shop", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            End If
    '        Else
    '            MsgBox("Deleting this data is cancelled", MessageBoxIcon.Information)
    '        End If

    '    Catch ex As Exception
    '        MsgBox("Error in collecting data from Database. Error is: " & ex.Message)
    '    End Try
    '    conn.Close()
    'End Sub

    'Private Sub Check_Click(sender As Object, e As EventArgs) Handles Check.Click
    '    conn.Open()

    '    Dim Id As Integer
    '    Id = Val(customID.Text)
    '    Try
    '        sql = "SELECT* FROM customers WHERE customers_Id = " & Id

    '        dbcomm = New MySqlCommand(sql, conn)
    '        dbread = dbcomm.ExecuteReader()
    '        If dbread.HasRows Then
    '            While dbread.Read
    '                customID.Text = dbread("customers_Id")
    '                customName.Text = dbread("name")
    '                ContactNum.Text = dbread("contactNum")
    '            End While
    '        End If
    '    Catch ex As Exception
    '        MsgBox("Error in collecting data from Database. Error is :" & ex.Message)
    '    End Try

    '    dbread.Close()
    '    conn.Close()
    'End Sub
End Class
