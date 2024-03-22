Imports MySql.Data.MySqlClient
Public Class salesReport
    Dim mydatarecords As DataTable = New DataTable
    Dim sqlString As String = ""
    Dim sqlString1 As String = ""
    Dim connClass As New ConnectToDb
    Dim dbcomm As New MySqlCommand
    Dim dbread As MySqlDataReader
    Dim image_path As String
    Dim path As String
    Dim OpenFileDialog1 As New OpenFileDialog
    Dim DataAdapter1 As New MySqlDataAdapter
    Dim ds As New DataSet
    Private Sub salesReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load, Refresh.Click
        'dbcomm.Connection = connClass.dbconn
        'connClass.OpenConnection()
        'sqlString = "SELECT order_Date,Prod_Description,prodPrice,brand_Name FROM Order_Transactionz INNER JOIN theCart INNER JOIN Brandz"
        'mydatarecords = connClass.selectFrom(sqlString)
        'Datagrid1.DataSource = mydatarecords

        'dbcomm.Connection = connClass.dbconn
        'connClass.OpenConnection()
        'sqlString = "SELECT * FROM Bike_Service"
        'mydatarecords = connClass.selectFrom(sqlString)
        'DataGridView1.DataSource = mydatarecords
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim table As New DataTable()
        Dim table2 As New DataTable()
        dbcomm.Connection = connClass.dbconn
        connClass.OpenConnection()
        If ComboBox1.Text = "All" Then
            dbcomm.Connection = connClass.dbconn
            connClass.OpenConnection()
            sqlString = "SELECT order_Date,Prod_Description,prodPrice,brand_Name FROM Order_Transactionz INNER JOIN theCart INNER JOIN Brandz"
            mydatarecords = connClass.selectFrom(sqlString)
            Datagrid1.DataSource = mydatarecords

            dbcomm.Connection = connClass.dbconn
            connClass.OpenConnection()
            sqlString = "SELECT Service_Info,Service_Date,Service_Cost FROM Bike_Service"
            mydatarecords = connClass.selectFrom(sqlString)
            DataGridView1.DataSource = mydatarecords

            Dim sum As Decimal = 0
            For i = 0 To Datagrid1.Rows.Count - 1
                sum += Datagrid1.Rows(i).Cells(2).Value
            Next

            proDSalesBike.Text = sum

            Dim sum1 As Decimal = 0
            For i = 0 To DataGridView1.Rows.Count - 1
                sum1 += DataGridView1.Rows(i).Cells(2).Value
            Next

            totSalesBike.Text = sum1

        ElseIf ComboBox1.Text = "Daily" Then
            Dim command As New MySqlCommand("SELECT order_Date,Prod_Description,prodPrice,brand_Name FROM Order_Transactionz INNER JOIN theCart INNER JOIN Brandz WHERE Order_Transactionz.order_Date BETWEEN @d1 AND @d2", connClass.dbconn)

            command.Parameters.Add("@d1", MySqlDbType.Date).Value = DateTimePicker1.Value
            command.Parameters.Add("@d2", MySqlDbType.Date).Value = DateTimePicker2.Value
            Dim adapter As New MySqlDataAdapter(command)
            adapter.Fill(table)
            Datagrid1.DataSource = table

            Dim command1 As New MySqlCommand("SELECT * FROM Bike_Service WHERE Service_Date BETWEEN @d1 AND @d2", connClass.dbconn)

            command1.Parameters.Add("@d1", MySqlDbType.Date).Value = DateTimePicker1.Value
            command1.Parameters.Add("@d2", MySqlDbType.Date).Value = DateTimePicker2.Value
            Dim adapter1 As New MySqlDataAdapter(command1)
            adapter1.Fill(table2)
            DataGridView1.DataSource = table2

            Dim sum As Decimal = 0
            For i = 0 To Datagrid1.Rows.Count - 1
                sum += Datagrid1.Rows(i).Cells(2).Value
            Next

            proDSalesBike.Text = sum

            Dim sum1 As Decimal = 0
            For i = 0 To DataGridView1.Rows.Count - 1
                sum1 += DataGridView1.Rows(i).Cells(3).Value
            Next

            totSalesBike.Text = sum1
        ElseIf ComboBox1.Text = "Monthly" Then
            Dim command3 As New MySqlCommand("SELECT order_Date,Prod_Description,prodPrice,brand_Name FROM Order_Transactionz INNER JOIN theCart INNER JOIN Brandz WHERE Order_Transactionz.order_Date BETWEEN @d1 AND @d2", connClass.dbconn)

            command3.Parameters.Add("@d1", MySqlDbType.Date).Value = DateTimePicker1.Value
            command3.Parameters.Add("@d2", MySqlDbType.Date).Value = DateTimePicker2.Value
            Dim adapter3 As New MySqlDataAdapter(command3)
            adapter3.Fill(table)
            Datagrid1.DataSource = table

            Dim command4 As New MySqlCommand("SELECT Service_Info,Service_Date,Service_Cost FROM Bike_Service WHERE Service_Date BETWEEN @d1 AND @d2", connClass.dbconn)

            command4.Parameters.Add("@d1", MySqlDbType.Date).Value = DateTimePicker1.Value
            command4.Parameters.Add("@d2", MySqlDbType.Date).Value = DateTimePicker2.Value
            Dim adapter4 As New MySqlDataAdapter(command4)
            adapter4.Fill(table2)
            DataGridView1.DataSource = table2

            Dim sum As Decimal = 0
            For i = 0 To Datagrid1.Rows.Count - 1
                sum += Datagrid1.Rows(i).Cells(2).Value
            Next

            proDSalesBike.Text = sum

            Dim sum1 As Decimal = 0
            For i = 0 To DataGridView1.Rows.Count - 1
                sum1 += DataGridView1.Rows(i).Cells(2).Value
            Next

            totSalesBike.Text = sum1
        ElseIf ComboBox1.Text = "Yearly" Then
            Dim command5 As New MySqlCommand("SELECT order_Date,Prod_Description,prodPrice,brand_Name FROM Order_Transactionz INNER JOIN theCart INNER JOIN Brandz WHERE Order_Transactionz.order_Date BETWEEN @d1 AND @d2", connClass.dbconn)

            command5.Parameters.Add("@d1", MySqlDbType.Date).Value = DateTimePicker1.Value
            command5.Parameters.Add("@d2", MySqlDbType.Date).Value = DateTimePicker2.Value
            Dim adapter5 As New MySqlDataAdapter(command5)
            adapter5.Fill(table)
            Datagrid1.DataSource = table

            Dim command6 As New MySqlCommand("SELECT Service_Info,Service_Date,Service_Cost FROM Bike_Service WHERE Service_Date BETWEEN @d1 AND @d2", connClass.dbconn)

            command6.Parameters.Add("@d1", MySqlDbType.Date).Value = DateTimePicker1.Value
            command6.Parameters.Add("@d2", MySqlDbType.Date).Value = DateTimePicker2.Value
            Dim adapter6 As New MySqlDataAdapter(command6)
            adapter6.Fill(table2)
            DataGridView1.DataSource = table2

            Dim sum As Decimal = 0
            For i = 0 To Datagrid1.Rows.Count - 1
                sum += Datagrid1.Rows(i).Cells(2).Value
            Next

            proDSalesBike.Text = sum

            Dim sum1 As Decimal = 0
            For i = 0 To DataGridView1.Rows.Count - 1
                sum1 += DataGridView1.Rows(i).Cells(2).Value
            Next

            totSalesBike.Text = sum1
            'dbcomm.Connection = connClass.dbconn
            'connClass.OpenConnection()
            'sqlString = "SELECT order_Date, prodPrice FROM Order_Transactionz INNER JOIN theCart WHERE Order_Transactionz.order_Date BETWEEN @d1 AND @d2"

            'mydatarecords = connClass.selectFrom(sqlString)
            'Datagrid1.DataSource = mydatarecords

            'dbcomm.Parameters.Add("@d1", MySqlDbType.Date).Value = DateTimePicker1.Value
            'dbcomm.Parameters.Add("@d2", MySqlDbType.Date).Value = DateTimePicker2.Value
            'Dim adapter As New MySqlDataAdapter(dbcomm)
            'adapter.Fill(table)
            'Datagrid1.Datas

            '    DataGridView1.DataSource = Nothing
            '    DataGridView1.Refresh()
            '    sqlString = "select i.item_name, c.category, t.description, b.brand_name, o.quantity, o.cost_price, o.date_order FROM item i INNER JOIN category c INNER JOIN types t INNER JOIN brand b INNER JOIN orderline o ON i.item_id = o.item_id AND c.category_id = i.category_id AND t.type_id = i.type_id AND b.id_brand = i.id_brand where o.date_order = '" & Convert.ToDateTime(DateTimePicker1.Value).ToString("yyyy-MM-dd") & "' "
            '    DataAdapter1 = New MySqlDataAdapter(sqlString, connClass.dbconn)
            '    ds = New DataSet()
            '    DataAdapter1.Fill(ds, "sales")
            '    DataGridView1.DataSource = ds
            '    DataGridView1.DataMember = "sales"

            'ElseIf ComboBox1.Text = "Monthly" Then

            '    DataGridView1.DataSource = Nothing
            '    DataGridView1.Refresh()
            '    Dim datee As String
            '    datee = Convert.ToDateTime(DateTimePicker1.Value).ToString("yyyy-MM")
            '    sqlString = "select i.item_name, c.category, t.description, b.brand_name, o.quantity, o.cost_price, o.date_order FROM item i INNER JOIN category c INNER JOIN types t INNER JOIN brand b INNER JOIN orderline o ON i.item_id = o.item_id AND c.category_id = i.category_id AND t.type_id = i.type_id AND b.id_brand = i.id_brand where o.date_order like '%" & datee & "%' "
            '    DataAdapter1 = New MySqlDataAdapter(sqlString, connClass.dbconn)
            '    ds = New DataSet()
            '    DataAdapter1.Fill(ds, "sales")
            '    DataGridView1.DataSource = ds
            '    DataGridView1.DataMember = "sales"


            'ElseIf ComboBox1.Text = "Yearly" Then

            '    DataGridView1.DataSource = Nothing
            '    DataGridView1.Refresh()
            '    Dim datee As String
            '    datee = Convert.ToDateTime(DateTimePicker1.Value).ToString("yyyy")
            '    sqlString = "select i.item_name, c.category, t.description, b.brand_name, o.quantity, o.cost_price, o.date_order FROM item i INNER JOIN category c INNER JOIN types t INNER JOIN brand b INNER JOIN orderline o ON i.item_id = o.item_id AND c.category_id = i.category_id AND t.type_id = i.type_id AND b.id_brand = i.id_brand where o.date_order like '%" & datee & "%' "
            '    DataAdapter1 = New MySqlDataAdapter(sqlString, connClass.dbconn)
            '    ds = New DataSet()
            '    DataAdapter1.Fill(ds, "sales")
            '    DataGridView1.DataSource = ds
            '    DataGridView1.DataMember = "sales"

        End If
        Dim overa As Double

        overa = Val(proDSalesBike.Text) + Val(totSalesBike.Text)
        overAllSales.Text = overa
        'Dim cost, total As Double
        'For i As Integer = 0 To DataGridView1.Rows.Count - 1
        '    cost = Convert.ToDouble(DataGridView1.Rows(i).Cells(3).Value)
        '    total = total + cost
        'Next i
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        Date1.Text = Format(DateTimePicker1.Value, "yyyy/MM/dd")
    End Sub

    Private Sub BunifuButton1_Click(sender As Object, e As EventArgs) Handles BunifuButton2.Click
        dbcomm.Connection = connClass.dbconn
        connClass.OpenConnection()
        Dim dt As New DataTable
        Dim dx As New DataTable

        With dt
            .Columns.Add("order_Date")
            .Columns.Add("Prod_Description")
            .Columns.Add("prodPrice")
            .Columns.Add("brand_Name")

        End With

        With dx
            .Columns.Add("Service_ID")
            .Columns.Add("Service_Info")
            .Columns.Add("Service_Date")
            .Columns.Add("Service_Cost")

        End With
        For Each dgr As DataGridViewRow In Me.Datagrid1.Rows
            dt.Rows.Add(dgr.Cells(0).Value, dgr.Cells(1).Value, dgr.Cells(2).Value, dgr.Cells(3).Value)
        Next
        For Each dgr1 As DataGridViewRow In Me.Datagrid1.Rows
            dx.Rows.Add(dgr1.Cells(0).Value, dgr1.Cells(1).Value, dgr1.Cells(2).Value, dgr1.Cells(3).Value)
        Next


        Dim reportDocument As CrystalDecisions.CrystalReports.Engine.ReportDocument
        reportDocument = New CrystalReport3
        reportDocument.Database.Tables("cathy").SetDataSource(dt)
        reportDocument.Database.Tables("cathskie").SetDataSource(dx)
        reportDocument.SetParameterValue("overAllSales", overAllSales.Text)
        salesReportCrystal.CrystalReportViewer1.ReportSource = reportDocument
        salesReportCrystal.ShowDialog()
        salesReportCrystal.Dispose()





        'Dim table As New DataTable
        'Dim rptDoc As CrystalDecisions.CrystalReports.Engine.ReportDocument
        'rptDoc = New CrystalReport3
        'rptDoc.SetDataSource(table)

        'salesReportCrystal.CrystalReportViewer1.ReportSource = rptDoc
        'salesReportCrystal.ShowDialog()
        'salesReportCrystal.Dispose()

    End Sub
End Class