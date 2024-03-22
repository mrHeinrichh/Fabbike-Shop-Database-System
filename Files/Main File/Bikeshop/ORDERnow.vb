Imports MySql.Data.MySqlClient
Imports System.IO
Public Class ORDERnow
    Dim mydatarecords As DataTable = New DataTable
    Dim sqlString As String = ""
    Dim sqlString1 As String = ""
    Dim sqlString26 As String = ""
    Dim connClass As ConnectToDb = New ConnectToDb
    Dim dbcomm As New MySqlCommand
    Dim dbread As MySqlDataReader
    Dim cmb As New DataSet
    Dim data1 As New DataTable

    Dim fab(10) As String
    Private Sub ORDERnow_Load(sender As Object, e As EventArgs) Handles MyBase.Load, Refresh.Click
        getdata()
        getthatdata()
    End Sub
    Private Sub getdata()
        dbcomm.Connection = connClass.dbconn
        connClass.OpenConnection()
        sqlString1 = "SELECT * FROM Productz"
        data1 = connClass.selectFrom(sqlString1)
        cmb1.DataSource = data1
        cmb1.ValueMember = "Product_ID"
        cmb1.DisplayMember = "Product_ID"
    End Sub
    Private Sub getthatdata()

        dbcomm.Connection = connClass.dbconn
        connClass.OpenConnection()
        sqlString26 = "SELECT * FROM Accessoriez"
        data1 = connClass.selectFrom(sqlString26)
        cmb2.DataSource = data1
        cmb2.ValueMember = "Accessories_ID"
        cmb2.DisplayMember = "Accessories_ID"
    End Sub

    Private Sub cmb1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb1.SelectedIndexChanged
        Dim data As Byte() = CType(data1.Rows(cmb1.SelectedIndex)("Photo"), Byte())
        Dim ms As MemoryStream = New MemoryStream(data)
        photo.Image = Image.FromStream(ms)
        cp1.Text = data1.Rows(cmb1.SelectedIndex).Item("cost_Price").ToString()
        dc1.Text = data1.Rows(cmb1.SelectedIndex).Item("Descz").ToString()
    End Sub

    Private Sub cmb2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb2.SelectedIndexChanged
        Dim datas As Byte() = CType(data1.Rows(cmb2.SelectedIndex)("Photo"), Byte())
        Dim msg As MemoryStream = New MemoryStream(datas)
        photo1.Image = Image.FromStream(msg)
        cp2.Text = data1.Rows(cmb2.SelectedIndex).Item("cost_Price").ToString()
        dc2.Text = data1.Rows(cmb2.SelectedIndex).Item("Descz").ToString()
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        orDate.Text = Format(DateTimePicker1.Value, "yyyy/MM/dd")
    End Sub

    Private Sub BunifuButton18_Click(sender As Object, e As EventArgs) Handles BunifuButton18.Click
        orderTrans()
        customs()
        carts()
    End Sub
    Private Sub del1()
        dbcomm.Connection = connClass.dbconn
        connClass.OpenConnection()
        sqlString = "DELETE FROM Order_Transactionz WHERE Order_ID = '" & Val(customID.Text) & "'"
        connClass.deleteFrom(sqlString)
    End Sub
    Private Sub del2()
        dbcomm.Connection = connClass.dbconn
        connClass.OpenConnection()
        sqlString = "DELETE FROM theCart WHERE Cart_ID = '" & Val(customID.Text) & "'"
        connClass.deleteFrom(sqlString)
    End Sub
    Private Sub del3()
        dbcomm.Connection = connClass.dbconn
        connClass.OpenConnection()
        sqlString = "DELETE FROM Supplier_Products WHERE Supplier_Product_ID = '" & Val(customID.Text) & "'"
        connClass.deleteFrom(sqlString)
    End Sub
    Private Sub del4()
        dbcomm.Connection = connClass.dbconn
        connClass.OpenConnection()
        sqlString = "DELETE FROM Supplier_Accessoriez WHERE Supplier_Accessories_ID = '" & Val(customID.Text) & "'"
        connClass.deleteFrom(sqlString)
    End Sub
    Private Sub customs()
        connClass.OpenConnection()
        Dim sqlString11 As String = "INSERT INTO Customerz(customer_ID,custName,ContactNum,Email) VALUES (@customer_ID,@custName,@ContactNum,@Email)"
        With dbcomm
            .Connection = connClass.dbconn
            .CommandText = sqlString11

            .Parameters.AddWithValue("@customer_ID", customID.Text)
            .Parameters.AddWithValue("@custName", customName.Text)
            .Parameters.AddWithValue("@ContactNum", customEmail.Text)
            .Parameters.AddWithValue("@Email", contactNum.Text)
        End With
        Dim r As Integer
        r = dbcomm.ExecuteNonQuery()

        connClass.closeCOn()

    End Sub
    Private Sub orderTrans()

        connClass.OpenConnection()
        Dim sqlString22 As String = "INSERT INTO Order_Transactionz(Order_ID,order_Date,Shipping_Fee) VALUES (@Order_ID,@order_Date,@Shipping_Fee)"
        With dbcomm
            .Connection = connClass.dbconn
            .CommandText = sqlString22
            .Parameters.AddWithValue("@Order_ID", customID.Text)
            .Parameters.AddWithValue("@order_Date", orDate.Text)
            .Parameters.AddWithValue("@Shipping_Fee", ShpFee.Text)
        End With
        Dim m As Integer
        m = dbcomm.ExecuteNonQuery()

        connClass.closeCOn()

    End Sub

    Private Sub carts()

        connClass.OpenConnection()
        Dim sqlString22 As String = "INSERT INTO theCart(Cart_ID,Prod_Description,prodPrice,AcceDescription,accePrice,quantity) VALUES (@Cart_ID,@Prod_Description,@prodPrice,@AcceDescription,@accePrice,@quantity)"
        With dbcomm
            .Connection = connClass.dbconn
            .CommandText = sqlString22
            .Parameters.AddWithValue("@Cart_ID", customID.Text)
            .Parameters.AddWithValue("@Prod_Description", dc1.Text)
            .Parameters.AddWithValue("@prodPrice", Val(cp1.Text))
            .Parameters.AddWithValue("@AcceDescription", dc2.Text)
            .Parameters.AddWithValue("@accePrice", Val(cp2.Text))
            .Parameters.AddWithValue("@quantity", Val(qty.Text))
        End With
        Dim z As Integer
        z = dbcomm.ExecuteNonQuery()
        connClass.closeCOn()

    End Sub

    Private Sub BunifuButton1_Click(sender As Object, e As EventArgs) Handles BunifuButton1.Click
        del1()
        del2()
        del3()
        del4()
    End Sub

    Private Sub BunifuButton2_Click(sender As Object, e As EventArgs) Handles BunifuButton2.Click
        Dim dt As New DataTable
        With dt
            .Columns.Add("custom_ID")
            .Columns.Add("custom_Name")
            .Columns.Add("custom_Email")
            .Columns.Add("contact_Num")
            .Columns.Add("q_ty")
            .Columns.Add("or_Date")
            .Columns.Add("Shp_Fee")
            .Columns.Add("dc_1")
            .Columns.Add("cp_1")
            .Columns.Add("dc_2")
            .Columns.Add("cp_3")

        End With

        For Each dr As DataGridViewRow In Me.Dgrid3.Rows
            dt.Rows.Add(dr.Cells("custom_ID").Value, dr.Cells("custom_Name").Value, dr.Cells("custom_Email").Value, dr.Cells("contact_Num").Value, dr.Cells("q_ty").Value, dr.Cells("or_Date").Value, dr.Cells("Shp_Fee").Value, dr.Cells("dc_1").Value, dr.Cells("cp_1").Value, dr.Cells("dc_2").Value, dr.Cells("cp_3").Value)
        Next

        Dim rptDoc As CrystalDecisions.CrystalReports.Engine.ReportDocument
        rptDoc = New CrystalReport2
        rptDoc.SetDataSource(dt)

        recieptcustomer.CrystalReportViewer1.ReportSource = rptDoc
        recieptcustomer.ShowDialog()
        recieptcustomer.Dispose()
    End Sub

    Private Sub Refresh_Click(sender As Object, e As EventArgs) Handles Refresh.Click

    End Sub

    Private Sub BunifuButton7_Click(sender As Object, e As EventArgs) Handles BunifuButton7.Click
        fab(0) = customID.Text
        fab(1) = customName.Text
        fab(2) = customEmail.Text
        fab(3) = contactNum.Text
        fab(4) = qty.Text
        fab(5) = orDate.Text
        fab(6) = ShpFee.Text
        fab(7) = dc1.Text
        fab(8) = cp1.Text
        fab(9) = dc2.Text
        fab(10) = cp2.Text
        Dim nR As Integer
        nR = Dgrid3.Rows.Add

        Dgrid3.Item("custom_ID", nR).Value = fab(0)
        Dgrid3.Item("custom_Name", nR).Value = fab(1)
        Dgrid3.Item("custom_Email", nR).Value = fab(2)
        Dgrid3.Item("contact_Num", nR).Value = fab(3)
        Dgrid3.Item("q_ty", nR).Value = fab(4)
        Dgrid3.Item("or_Date", nR).Value = fab(5)
        Dgrid3.Item("Shp_Fee", nR).Value = fab(6)
        Dgrid3.Item("dc_1", nR).Value = fab(7)
        Dgrid3.Item("cp_1", nR).Value = fab(8)
        Dgrid3.Item("dc_2", nR).Value = fab(9)
        Dgrid3.Item("cp_3", nR).Value = fab(10)
    End Sub
End Class