Imports MySql.Data.MySqlClient
Imports System.IO
Public Class TRANSACTIONsupplier
    Dim mydatarecords As DataTable = New DataTable
    Dim sqlString As String = ""
    Dim connClass As New ConnectToDb
    Dim dbcomm As New MySqlCommand
    Dim dbread As MySqlDataReader
    Dim image_path As String
    Dim path As String
    Dim OpenFileDialog1 As New OpenFileDialog
    Dim fab(8) As String
    Private Sub TRANSACTIONsupplier_Load(sender As Object, e As EventArgs) Handles MyBase.Load, Refresh.Click
        '        connClass.OpenConnection()
        '        sqlString = "SELECT S.Supplier_Name, SO.Date_Ordered, SO.Payment, A.Cost_Price, A.Description
        'FROM Supplierz S INNER JOIN Supplier_Order SO 
        'INNER JOIN Supplier_Accessoriez SA 
        'INNER JOIN Accessoriez A 
        'UNION
        'SELECT S.Supplier_Name, SO.Date_Ordered, SO.Payment, P.Cost_Price, P.Description
        'FROM Supplierz S INNER JOIN Supplier_Order SO 
        'INNER JOIN Supplier_Products SP 
        'INNER JOIN Productz P "
        '        mydatarecords = connClass.selectFrom(sqlString)
        '        Dgrid3.DataSource = mydatarecords
    End Sub

    Private Sub BunifuButton3_Click(sender As Object, e As EventArgs) Handles BunifuButton3.Click
        Dim result As DialogResult = OpenFileDialog1.ShowDialog()
        If result = DialogResult.OK Then
            path = OpenFileDialog1.FileName
            Dim destination = OpenFileDialog1.SafeFileName
            image_path = "D:\Photo\" & destination
            photo.ImageLocation = path
        End If

    End Sub

    Private Sub BunifuButton4_Click(sender As Object, e As EventArgs) Handles BunifuButton4.Click
        photo.Image = Nothing
    End Sub

    Private Sub BunifuButton6_Click(sender As Object, e As EventArgs) Handles BunifuButton6.Click
        Dim result1 As DialogResult = OpenFileDialog1.ShowDialog()
        If result1 = DialogResult.OK Then
            path = OpenFileDialog1.FileName
            Dim destination = OpenFileDialog1.SafeFileName
            image_path = "D:\Photo\" & destination
            photo1.ImageLocation = path
        End If
    End Sub

    Private Sub BunifuButton5_Click(sender As Object, e As EventArgs) Handles BunifuButton5.Click
        photo1.Image = Nothing
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        orDate.Text = Format(DateTimePicker1.Value, "yyyy/MM/dd")
    End Sub

    Private Sub box1()
        connClass.OpenConnection()
        Dim sqlString11 As String = "INSERT INTO Supplierz(Supplier_ID,Supplier_Name) VALUES (@Supplier_ID,@Supplier_Name)"
        With dbcomm
            .Connection = connClass.dbconn
            .CommandText = sqlString11

            .Parameters.AddWithValue("@Supplier_ID", suppID.Text)
            .Parameters.AddWithValue("@Supplier_Name", suPPname.Text)
        End With
        Dim r As Integer
        r = dbcomm.ExecuteNonQuery()

        connClass.closeCOn()

    End Sub
    Private Sub box2()
        connClass.OpenConnection()
        Dim sqlString12 As String = "INSERT INTO Supplier_Order(Supplier_Order_ID,Date_Ordered,Payment) VALUES (@Supplier_Order_ID,@Date_Ordered,@Payment)"
        With dbcomm
            .Connection = connClass.dbconn
            .CommandText = sqlString12

            .Parameters.AddWithValue("@Supplier_Order_ID", suppID.Text)
            .Parameters.AddWithValue("@Date_Ordered", orDate.Text)
            .Parameters.AddWithValue("@Payment", payMents.Text)
        End With
        Dim b As Integer
        b = dbcomm.ExecuteNonQuery()

        connClass.closeCOn()

    End Sub
    Private Sub box3()
        connClass.OpenConnection()
        Dim sqlString13 As String = "INSERT INTO Supplier_Products(Supplier_Product_ID,Stock) VALUES (@Supplier_Product_ID,@Stockz)"
        With dbcomm
            .Connection = connClass.dbconn
            .CommandText = sqlString13

            .Parameters.AddWithValue("@Supplier_Product_ID", suppID.Text)
            .Parameters.AddWithValue("@Stockz", Pstock.Text)

        End With
        Dim c As Integer
        c = dbcomm.ExecuteNonQuery()

        connClass.closeCOn()

    End Sub

    Private Sub box4()
        connClass.OpenConnection()
        Dim sqlString14 As String = "INSERT INTO Supplier_Accessoriez(Supplier_Accessories_ID,Stock) VALUES (@Supplier_Accessories_ID,@Stock)"
        With dbcomm
            .Connection = connClass.dbconn
            .CommandText = sqlString14

            .Parameters.AddWithValue("@Supplier_Accessories_ID", suppID.Text)
            .Parameters.AddWithValue("@Stock", Astock.Text)
        End With
        Dim d As Integer
        d = dbcomm.ExecuteNonQuery()

        connClass.closeCOn()

    End Sub
    Private Sub box5()

        Try
            Dim arrImage() As Byte
            Dim mstream As New System.IO.MemoryStream()
            photo.Image.Save(mstream, System.Drawing.Imaging.ImageFormat.Jpeg)
            arrImage = mstream.GetBuffer()
            Dim FileSize As UInt32
            FileSize = mstream.Length
            mstream.Close()
            connClass.OpenConnection()
            Dim sqlString1 As String = "INSERT INTO Accessoriez(Accessories_ID,Photo,Cost_Price,Descz) VALUES (@Product_ID,@Photo,@Cost_price,@Descz)"
            With dbcomm
                .Connection = connClass.dbconn
                .CommandText = sqlString1

                .Parameters.AddWithValue("@Product_ID", suppID.Text)
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
    Private Sub Box6()
        Try
            Dim arrImages() As Byte
            Dim mstream As New System.IO.MemoryStream()
            photo1.Image.Save(mstream, System.Drawing.Imaging.ImageFormat.Jpeg)
            arrImages = mstream.GetBuffer()
            Dim FileSizez As UInt32
            FileSizez = mstream.Length
            mstream.Close()
            connClass.OpenConnection()
            Dim sqlString1 As String = "INSERT INTO Productz(Product_ID,Photo,Cost_Price,Descz) VALUES (@Product_ID,@Photo,@Cost_price,@Descz)"
            With dbcomm
                .Connection = connClass.dbconn
                .CommandText = sqlString1

                .Parameters.AddWithValue("@Product_ID", suppID.Text)
                .Parameters.AddWithValue("@Photo", arrImages)
                .Parameters.AddWithValue("@Cost_price", costP1.Text)
                .Parameters.AddWithValue("@Descz", desc1.Text)
            End With

            Dim r As Integer
            r = dbcomm.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
        dbcomm.Parameters.Clear()
        connClass.closeCOn()

    End Sub

    Private Sub BunifuButton18_Click(sender As Object, e As EventArgs) Handles BunifuButton18.Click
        Box6()
        box5()
        box4()
        box3()
        box2()
        box1()
    End Sub

    Private Sub BunifuButton2_Click(sender As Object, e As EventArgs) Handles BunifuButton2.Click
        Dim dt As New DataTable
        With dt
            .Columns.Add("supp_Name")
            .Columns.Add("orderDatez")
            .Columns.Add("pymntz")
            .Columns.Add("pStocks")
            .Columns.Add("Astockz")
            .Columns.Add("proDesc")
            .Columns.Add("costPricez")
            .Columns.Add("AccDesc")
            .Columns.Add("cost_Pricez")
        End With

        For Each dr As DataGridViewRow In Me.Dgrid3.Rows
            dt.Rows.Add(dr.Cells("supp_Name").Value, dr.Cells("orderDatez").Value, dr.Cells("pymntz").Value, dr.Cells("pStocks").Value, dr.Cells("Astockz").Value, dr.Cells("proDesc").Value, dr.Cells("costPricez").Value, dr.Cells("AccDesc").Value, dr.Cells("cost_Pricez").Value)
        Next

        Dim rptDoc As CrystalDecisions.CrystalReports.Engine.ReportDocument
        rptDoc = New CrystalReport1
        rptDoc.SetDataSource(dt)

        suppReciept.CrystalReportViewer1.ReportSource = rptDoc
        suppReciept.ShowDialog()
        suppReciept.Dispose()
    End Sub

    Private Sub BunifuButton7_Click(sender As Object, e As EventArgs) Handles BunifuButton7.Click
        'Array and insert into Database
        fab(0) = suPPname.Text
        fab(1) = orDate.Text
        fab(2) = payMents.Text
        fab(3) = Pstock.Text
        fab(4) = Astock.Text
        fab(5) = desc.Text
        fab(6) = costPrice.Text
        fab(7) = desc1.Text
        fab(8) = costP1.Text
        Dim nR As Integer
        nR = Dgrid3.Rows.Add

        Dgrid3.Item("supp_Name", nR).Value = fab(0)
        Dgrid3.Item("orderDatez", nR).Value = fab(1)
        Dgrid3.Item("pymntz", nR).Value = fab(2)
        Dgrid3.Item("pStocks", nR).Value = fab(3)
        Dgrid3.Item("Astockz", nR).Value = fab(4)
        Dgrid3.Item("proDesc", nR).Value = fab(5)
        Dgrid3.Item("costPricez", nR).Value = fab(6)
        Dgrid3.Item("AccDesc", nR).Value = fab(7)
        Dgrid3.Item("cost_Pricez", nR).Value = fab(8)
        'MessageBox.Show("Order Attached")
    End Sub

    Private Sub BunifuButton8_Click(sender As Object, e As EventArgs)
        dbcomm.Connection = connClass.dbconn
        connClass.OpenConnection()
        sqlString = "SELECT * FROM customerz INNER JOIN order_transactionz INNER JOIN theCart"
        '"SELECT Name,Email,ContactNum,Photo,Description FROM Users"
        mydatarecords = connClass.selectFrom(sqlString)
        'DataGridView1.DataSource = mydatarecords
    End Sub
End Class