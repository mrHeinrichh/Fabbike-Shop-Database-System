Imports MySql.Data.MySqlClient
Public Class CRUDsupplier
    Dim mydatarecords As DataTable = New DataTable
    Dim sqlString As String = ""
    Dim connClass As ConnectToDb = New ConnectToDb
    Dim dbcomm As New MySqlCommand
    Dim dbread As MySqlDataReader
    Private Sub CRUDsupplier_Load(sender As Object, e As EventArgs) Handles MyBase.Load, Refresh.Click
        def()
    End Sub
    Private Sub def()
        dbcomm.Connection = connClass.dbconn
        connClass.OpenConnection()
        sqlString = "SELECT * FROM Supplierz"
        mydatarecords = connClass.selectFrom(sqlString)
        Dgrid1.DataSource = mydatarecords

    End Sub
    'Private Sub ords()
    '    dbcomm.Connection = connClass.dbconn
    '    connClass.OpenConnection()
    '    sqlString = "SELECT * FROM Supplier_Order"
    '    mydatarecords = connClass.selectFrom(sqlString)
    '    Dgrid1.DataSource = mydatarecords

    'End Sub
    'Private Sub supps()
    '    dbcomm.Connection = connClass.dbconn
    '    connClass.OpenConnection()
    '    sqlString = "SELECT * FROM Supplier_Accessories"
    '    mydatarecords = connClass.selectFrom(sqlString)
    '    Dgrid1.DataSource = mydatarecords
    'End Sub
    'Private Sub prods()
    '    dbcomm.Connection = connClass.dbconn
    '    connClass.OpenConnection()
    '    sqlString = "SELECT * FROM Supplier_Products"
    '    mydatarecords = connClass.selectFrom(sqlString)
    '    Dgrid1.DataSource = mydatarecords
    'End Sub
    Private Sub Insert_Click(sender As Object, e As EventArgs) Handles Insert.Click
        Try
            dbcomm.Connection = connClass.dbconn
            connClass.OpenConnection()
            Dim sqlString1 As String = "INSERT INTO Supplierz(Supplier_ID,Supplier_Name) VALUES (@Supplier_ID,@Supplier_Name)"
            With dbcomm
                .Connection = connClass.dbconn
                .CommandText = sqlString1

                .Parameters.AddWithValue("@Supplier_ID", suppID.Text)
                .Parameters.AddWithValue("@Supplier_Name", customName.Text)

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
        Dim sqlString99 As String = ""
        dbcomm.Connection = connClass.dbconn
        connClass.OpenConnection()
        sqlString99 = "UPDATE Supplierz Set Supplier_Name = '" & customName.Text & "' WHERE Supplier_ID =" & suppID.Text & ""
        connClass.updateFrom(sqlString99)
        Dgrid1.DataSource = mydatarecords
    End Sub

    Private Sub Delete_Click(sender As Object, e As EventArgs) Handles Delete.Click
        Dim sqlString88 As String = ""
        dbcomm.Connection = connClass.dbconn

        connClass.OpenConnection()
        sqlString88 = "DELETE FROM Supplierz WHERE Supplier_ID = '" & Val(suppID.Text) & "'"
        connClass.deleteFrom(sqlString)

    End Sub

    Private Sub Check_Click(sender As Object, e As EventArgs) Handles Check.Click
        Try
            mydatarecords = connClass.selectFrom("SELECT * FROM Supplierz WHERE Supplier_ID ='" & Val(suppID.Text) & "'")
            If (mydatarecords.Rows.Count > 0) Then
                Dgrid1.DataSource = mydatarecords
            Else


                MessageBox.Show("Not Found!")
            End If
        Catch ex As Exception
            MsgBox("Error in collecting data from Database. Error is :" & ex.Message)
        End Try
    End Sub

    'Private Sub BunifuButton4_Click(sender As Object, e As EventArgs)
    '    Try
    '        dbcomm.Connection = connClass.dbconn
    '        connClass.OpenConnection()
    '        Dim sqlString19 As String = "INSERT INTO Supplier_Products(Supplier_Product_ID,Cost_Price,Stock,Product_ID,Supplier_Order_ID) VALUES (@Supplier_Product_ID,@Cost_Price,@Stock,@Product_ID,@Supplier_Order_ID)"
    '        With dbcomm
    '            .Connection = connClass.dbconn
    '            .CommandText = sqlString19

    '            .Parameters.AddWithValue("@Supplier_Product_ID", prodID.Text)
    '            .Parameters.AddWithValue("@Cost_Price", costPrice1.Text)
    '            .Parameters.AddWithValue("@Stock", stock1.Text)
    '            .Parameters.AddWithValue("@Product_ID", SuppProdID.Text)
    '            .Parameters.AddWithValue("@Supplier_Order_ID", SuppProdID.Text)
    '        End With
    '        Dim r As Integer
    '        r = dbcomm.ExecuteNonQuery()
    '        dbcomm.Parameters.Clear()
    '        connClass.closeCOn()
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message.ToString)
    '    End Try
    'End Sub

    'Private Sub BunifuButton8_Click(sender As Object, e As EventArgs)
    '    Try
    '        dbcomm.Connection = connClass.dbconn
    '        connClass.OpenConnection()
    '        Dim sqlString15 As String = "INSERT INTO Supplier_Accessories(Supplier_Accessories_ID,Cost_Price,Stock,Accessories_ID,Supplier_Order_ID) VALUES (@Supplier_Accessories_ID,@Cost_Price,@Stock,@Accessories_ID,@Supplier_Order_ID)"
    '        With dbcomm
    '            .Connection = connClass.dbconn
    '            .CommandText = sqlString15

    '            .Parameters.AddWithValue("@Supplier_Accessories_ID", accID.Text)
    '            .Parameters.AddWithValue("@Cost_Price", costPrice2.Text)
    '            .Parameters.AddWithValue("@Stock", stock2.Text)
    '            .Parameters.AddWithValue("@Accessories_ID", supAACCID.Text)
    '            .Parameters.AddWithValue("@Supplier_Order_ID", supAACCID.Text)
    '        End With
    '        Dim r As Integer
    '        r = dbcomm.ExecuteNonQuery()

    '        dbcomm.Parameters.Clear()
    '        connClass.closeCOn()

    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message.ToString)
    '    End Try
    'End Sub

    'Private Sub BunifuButton3_Click(sender As Object, e As EventArgs)
    '    Dim sqlString87 As String = ""
    '    dbcomm.Connection = connClass.dbconn
    '    connClass.OpenConnection()
    '    sqlString87 = "UPDATE Supplier_Products Set Cost_Price = '" & costPrice1.Text & "', Stock = '" & stock1.Text & "' WHERE Service_Product_ID =" & accID.Text & ""
    '    connClass.updateFrom(sqlString87)
    '    Dgrid1.DataSource = mydatarecords
    'End Sub

    'Private Sub BunifuButton7_Click(sender As Object, e As EventArgs)
    '    Dim sqlString86 As String = ""
    '    dbcomm.Connection = connClass.dbconn

    '    connClass.OpenConnection()
    '    sqlString86 = "UPDATE Supplier_Accessories Set Cost_Price = '" & costPrice2.Text & "', Stock = '" & stock2.Text & "' WHERE Supplier_Accessories_ID =" & accID.Text & ""
    '    connClass.updateFrom(sqlString86)
    '    Dgrid1.DataSource = mydatarecords
    'End Sub

    'Private Sub BunifuButton2_Click(sender As Object, e As EventArgs)
    '    Dim sqlString48 As String = ""
    '    dbcomm.Connection = connClass.dbconn

    '    connClass.OpenConnection()
    '    sqlString48 = "DELETE FROM Supplierz WHERE Supplier_ID = '" & Val(suppID.Text) & "'"
    '    connClass.deleteFrom(sqlString48)
    'End Sub

    'Private Sub BunifuButton6_Click(sender As Object, e As EventArgs)
    '    Dim sqlString38 As String = ""
    '    dbcomm.Connection = connClass.dbconn

    '    connClass.OpenConnection()
    '    sqlString38 = "DELETE FROM Supplierz WHERE Supplier_ID = '" & Val(suppID.Text) & "'"
    '    connClass.deleteFrom(sqlString38)
    'End Sub

    'Private Sub BunifuButton1_Click(sender As Object, e As EventArgs)
    '    Try
    '        mydatarecords = connClass.selectFrom("SELECT * FROM Supplier_Products WHERE Service_Product_ID ='" & Val(prodID.Text) & "'")
    '        If (mydatarecords.Rows.Count > 0) Then
    '            Dgrid1.DataSource = mydatarecords
    '        Else
    '            MessageBox.Show("Not Found!")
    '        End If
    '    Catch ex As Exception
    '        MsgBox("Error in collecting data from Database. Error is :" & ex.Message)
    '    End Try
    'End Sub

    'Private Sub BunifuButton5_Click(sender As Object, e As EventArgs)
    '    Try
    '        mydatarecords = connClass.selectFrom("SELECT * FROM Supplier_Accessories WHERE Supplier_Accessories_ID ='" & Val(accID.Text) & "'")
    '        If (mydatarecords.Rows.Count > 0) Then
    '            Dgrid1.DataSource = mydatarecords
    '        Else
    '            MessageBox.Show("Not Found!")
    '        End If
    '    Catch ex As Exception
    '        MsgBox("Error in collecting data from Database. Error is :" & ex.Message)
    '    End Try
    'End Sub

    'Private Sub BunifuButton9_Click(sender As Object, e As EventArgs) Handles BunifuButton9.Click
    '    def()

    'End Sub

    'Private Sub BunifuButton11_Click(sender As Object, e As EventArgs)

    '    prods()
    'End Sub

    'Private Sub BunifuButton10_Click(sender As Object, e As EventArgs)
    '    supps()

    'End Sub

    'Private Sub BunifuButton16_Click(sender As Object, e As EventArgs)
    '    Try
    '        dbcomm.Connection = connClass.dbconn
    '        connClass.OpenConnection()
    '        Dim sqlString23 As String = "INSERT INTO Supplier_Order(Supplier_Order_ID,Date_Ordered,Payment,Supplier_Accessories_ID,Supplier_Products_ID) VALUES (@Supplier_Order_ID,@Date_Ordered,@Payment,@Supplier_Accessories_ID,@Supplier_Products_ID)"
    '        With dbcomm
    '            .Connection = connClass.dbconn
    '            .CommandText = sqlString23

    '            .Parameters.AddWithValue("@Supplier_Order_ID", suppIDS.Text)
    '            .Parameters.AddWithValue("@Date_Ordered", orDates.Text)
    '            .Parameters.AddWithValue("@Payment", paymetz.Text)

    '            .Parameters.AddWithValue("@Supplier_Accessories_ID", supsupp1.Text)
    '            .Parameters.AddWithValue("@Supplier_Products_ID", supsupp1.Text)
    '        End With
    '        Dim r As Integer
    '        r = dbcomm.ExecuteNonQuery()

    '        dbcomm.Parameters.Clear()
    '        connClass.closeCOn()

    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message.ToString)
    '    End Try
    'End Sub

    'Private Sub BunifuButton15_Click(sender As Object, e As EventArgs)

    '    Dim sqlString106 As String = ""
    '    dbcomm.Connection = connClass.dbconn

    '    connClass.OpenConnection()
    '    sqlString106 = "UPDATE Supplier_Order Set Date_Ordered = '" & orDates.Text & "', Payment = '" & paymetz.Text & "' WHERE Supplier_Order_ID =" & suppIDS.Text & ""
    '    connClass.updateFrom(sqlString106)
    '    Dgrid1.DataSource = mydatarecords
    'End Sub

    'Private Sub BunifuButton12_Click(sender As Object, e As EventArgs)
    '    ords()
    'End Sub

    'Private Sub BunifuButton14_Click(sender As Object, e As EventArgs)
    '    Dim sqlString18 As String = ""
    '    dbcomm.Connection = connClass.dbconn

    '    connClass.OpenConnection()
    '    sqlString18 = "DELETE FROM Supplier_Order WHERE Supplier_Order_ID = '" & Val(suppIDS.Text) & "'"
    '    connClass.deleteFrom(sqlString18)
    'End Sub

    'Private Sub SuppProdID_TextChanged(sender As Object, e As EventArgs)

    'End Sub
End Class