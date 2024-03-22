Imports MySql.Data.MySqlClient
Public Class oS
    Dim mydatarecords As DataTable = New DataTable
    Dim sqlString As String = ""
    Dim sqlString1 As String = ""
    Dim sqlString2 As String = ""
    Dim sqlString3 As String = ""
    Dim connClass As New ConnectToDb
    Dim dbcomm As New MySqlCommand
    Dim dbread As MySqlDataReader
    Dim image_path As String
    Dim path As String
    Dim OpenFileDialog1 As New OpenFileDialog
    Dim DataAdapter1 As New MySqlDataAdapter
    Dim ds As New DataSet
    Private Sub EXPENSESREPORT_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim table As New DataTable()
        Dim table2 As New DataTable()
        Dim table3 As New DataTable()
        dbcomm.Connection = connClass.dbconn
        connClass.OpenConnection()
        If ComboBox1.Text = "All" Then
            dbcomm.Connection = connClass.dbconn
            connClass.OpenConnection()
            sqlString = "SELECT * FROM Wagez"
            mydatarecords = connClass.selectFrom(sqlString)
            DataGridView1.DataSource = mydatarecords

            dbcomm.Connection = connClass.dbconn
            connClass.OpenConnection()
            sqlString1 = "SELECT Supplier_Name,Date_Ordered, Payment FROM Supplierz INNER JOIN Supplier_Order"
            mydatarecords = connClass.selectFrom(sqlString1)
            DataGridView2.DataSource = mydatarecords

            dbcomm.Connection = connClass.dbconn
            connClass.OpenConnection()
            sqlString2 = "SELECT * FROM Operating_Expenses"
            mydatarecords = connClass.selectFrom(sqlString2)
            DataGridView3.DataSource = mydatarecords

            Dim sum As Decimal = 0

            For i = 0 To DataGridView1.Rows.Count - 1
                sum += DataGridView1.Rows(i).Cells(1).Value
            Next

            sR.Text = sum

            Dim sum1 As Decimal = 0
            For i = 0 To DataGridView2.Rows.Count - 1
                sum1 += DataGridView2.Rows(i).Cells(2).Value
            Next

            oSSS.Text = sum1

            Dim sum2 As Decimal = 0
            For i = 0 To DataGridView3.Rows.Count - 1
                sum1 += DataGridView3.Rows(i).Cells(0).Value
            Next

            MeeE.Text = sum1

        ElseIf ComboBox1.Text = "Daily" Then

            Dim command As New MySqlCommand("SELECT * FROM Wagez WHERE Salary_Date BETWEEN @d1 AND @d2", connClass.dbconn)

            command.Parameters.Add("@d1", MySqlDbType.Date).Value = DateTimePicker2.Value
            command.Parameters.Add("@d2", MySqlDbType.Date).Value = DateTimePicker3.Value
            Dim adapter As New MySqlDataAdapter(command)
            adapter.Fill(table)
            DataGridView1.DataSource = table

            Dim command1 As New MySqlCommand("SELECT Supplier_Name,Date_Ordered, Payment FROM Supplierz INNER JOIN Supplier_Order WHERE Supplier_Order.Date_Ordered BETWEEN @d1 AND @d2", connClass.dbconn)

            command1.Parameters.Add("@d1", MySqlDbType.Date).Value = DateTimePicker2.Value
            command1.Parameters.Add("@d2", MySqlDbType.Date).Value = DateTimePicker3.Value
            Dim adapter1 As New MySqlDataAdapter(command1)
            adapter1.Fill(table2)
            DataGridView2.DataSource = table2

            Dim command3 As New MySqlCommand("SELECT * FROM Operating_Expenses", connClass.dbconn)

            command3.Parameters.Add("@d1", MySqlDbType.Date).Value = DateTimePicker2.Value
            command3.Parameters.Add("@d2", MySqlDbType.Date).Value = DateTimePicker3.Value
            Dim adapter2 As New MySqlDataAdapter(command3)
            adapter2.Fill(table3)
            DataGridView3.DataSource = table3

            Dim sum3 As Decimal = 0
            For i = 0 To DataGridView1.Rows.Count - 1
                sum3 += DataGridView1.Rows(i).Cells(1).Value
            Next

            sR.Text = sum3

            Dim sum4 As Decimal = 0
            For i = 0 To DataGridView2.Rows.Count - 1
                sum4 += DataGridView2.Rows(i).Cells(2).Value
            Next

            oSSS.Text = sum4

            Dim sum5 As Decimal = 0
            For i = 0 To DataGridView3.Rows.Count - 1
                sum5 += DataGridView3.Rows(i).Cells(2).Value
            Next

            MeeE.Text = sum5
        ElseIf ComboBox1.Text = "Monthly" Then

            Dim command As New MySqlCommand("SELECT * FROM Wagez WHERE Salary_Date BETWEEN @d1 AND @d2", connClass.dbconn)

            command.Parameters.Add("@d1", MySqlDbType.Date).Value = DateTimePicker2.Value
            command.Parameters.Add("@d2", MySqlDbType.Date).Value = DateTimePicker3.Value
            Dim adapter As New MySqlDataAdapter(command)
            adapter.Fill(table)
            DataGridView1.DataSource = table

            Dim command1 As New MySqlCommand("SELECT Supplier_Name,Date_Ordered, Payment FROM Supplierz INNER JOIN Supplier_Order WHERE Supplier_Order.Date_Ordered BETWEEN @d1 AND @d2", connClass.dbconn)

            command1.Parameters.Add("@d1", MySqlDbType.Date).Value = DateTimePicker2.Value
            command1.Parameters.Add("@d2", MySqlDbType.Date).Value = DateTimePicker3.Value
            Dim adapter1 As New MySqlDataAdapter(command1)
            adapter1.Fill(table2)
            DataGridView2.DataSource = table2

            Dim command3 As New MySqlCommand("SELECT * FROM Operating_Expenses", connClass.dbconn)

            command3.Parameters.Add("@d1", MySqlDbType.Date).Value = DateTimePicker2.Value
            command3.Parameters.Add("@d2", MySqlDbType.Date).Value = DateTimePicker3.Value
            Dim adapter2 As New MySqlDataAdapter(command3)
            adapter2.Fill(table3)
            DataGridView3.DataSource = table3

            Dim sum3 As Decimal = 0
            For i = 0 To DataGridView1.Rows.Count - 1
                sum3 += DataGridView1.Rows(i).Cells(1).Value
            Next

            sR.Text = sum3

            Dim sum4 As Decimal = 0
            For i = 0 To DataGridView2.Rows.Count - 1
                sum4 += DataGridView2.Rows(i).Cells(2).Value
            Next

            oSSS.Text = sum4

            Dim sum5 As Decimal = 0
            For i = 0 To DataGridView3.Rows.Count - 1
                sum5 += DataGridView3.Rows(i).Cells(2).Value
            Next

            MeeE.Text = sum5

        ElseIf ComboBox1.Text = "Yearly" Then

            Dim command As New MySqlCommand("SELECT * FROM Wagez WHERE Salary_Date BETWEEN @d1 AND @d2", connClass.dbconn)

            command.Parameters.Add("@d1", MySqlDbType.Date).Value = DateTimePicker2.Value
            command.Parameters.Add("@d2", MySqlDbType.Date).Value = DateTimePicker3.Value
            Dim adapter As New MySqlDataAdapter(command)
            adapter.Fill(table)
            DataGridView1.DataSource = table

            Dim command1 As New MySqlCommand("SELECT Supplier_Name,Date_Ordered, Payment FROM Supplierz INNER JOIN Supplier_Order WHERE Supplier_Order.Date_Ordered BETWEEN @d1 AND @d2", connClass.dbconn)

            command1.Parameters.Add("@d1", MySqlDbType.Date).Value = DateTimePicker2.Value
            command1.Parameters.Add("@d2", MySqlDbType.Date).Value = DateTimePicker3.Value
            Dim adapter1 As New MySqlDataAdapter(command1)
            adapter1.Fill(table2)
            DataGridView2.DataSource = table2

            Dim command3 As New MySqlCommand("SELECT * FROM Operating_Expenses", connClass.dbconn)

            command3.Parameters.Add("@d1", MySqlDbType.Date).Value = DateTimePicker2.Value
            command3.Parameters.Add("@d2", MySqlDbType.Date).Value = DateTimePicker3.Value
            Dim adapter2 As New MySqlDataAdapter(command3)
            adapter2.Fill(table3)
            DataGridView3.DataSource = table3

            Dim sum3 As Decimal = 0
            For i = 0 To DataGridView1.Rows.Count - 1
                sum3 += DataGridView1.Rows(i).Cells(1).Value
            Next

            sR.Text = sum3

            Dim sum4 As Decimal = 0
            For i = 0 To DataGridView2.Rows.Count - 1
                sum4 += DataGridView2.Rows(i).Cells(2).Value
            Next

            oSSS.Text = sum4

            Dim sum5 As Decimal = 0
            For i = 0 To DataGridView3.Rows.Count - 1
                sum5 += DataGridView3.Rows(i).Cells(2).Value
            Next

            MeeE.Text = sum5
        End If
        Dim toals As Double
        toals = Val(oSSS.Text) + Val(MeeE.Text) + Val(sR.Text)
        TextBox6.Text = toals
    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker2.ValueChanged
        DateTimePicker2.Text = Format(DateTimePicker2.Value, "yyyy/MM/dd")
    End Sub

    Private Sub DateTimePicker3_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker3.ValueChanged
        DateTimePicker3.Text = Format(DateTimePicker3.Value, "yyyy/MM/dd")
    End Sub

    Private Sub BunifuButton1_Click(sender As Object, e As EventArgs) Handles BunifuButton1.Click
        dbcomm.Connection = connClass.dbconn
        connClass.OpenConnection()
        Dim dt As New DataTable

        With dt
            .Columns.Add("Operating_Expenses")
            .Columns.Add("Description")
            .Columns.Add("Price")
            .Columns.Add("dueDate")
        End With

        For Each dgr As DataGridViewRow In Me.DataGridView1.Rows
            dt.Rows.Add(dgr.Cells(0).Value, dgr.Cells(1).Value, dgr.Cells(2).Value)
        Next

        Dim reportDocument As CrystalDecisions.CrystalReports.Engine.ReportDocument
        reportDocument = New CrystalReport5
        reportDocument.Database.Tables("misC").SetDataSource(dt)
        reportDocument.SetParameterValue("MeEEE", TextBox6.Text)
        MiscFee.CrystalReportViewer1.ReportSource = reportDocument
        MiscFee.ShowDialog()
        MiscFee.Dispose()
    End Sub

    Private Sub BunifuButton3_Click(sender As Object, e As EventArgs) Handles BunifuButton3.Click
        dbcomm.Connection = connClass.dbconn
        connClass.OpenConnection()
        Dim dt As New DataTable

        With dt
            .Columns.Add("Wagez_ID")
            .Columns.Add("Salary")
            .Columns.Add("Salary_Date")
        End With

        For Each dgr As DataGridViewRow In Me.DataGridView1.Rows
            dt.Rows.Add(dgr.Cells(0).Value, dgr.Cells(1).Value, dgr.Cells(2).Value)
        Next



        Dim reportDocument As CrystalDecisions.CrystalReports.Engine.ReportDocument
        reportDocument = New salaryRecordCrystal
        reportDocument.Database.Tables("sR").SetDataSource(dt)
        reportDocument.SetParameterValue("textbox6", TextBox6.Text)
        SALARAYRECORDZ.CrystalReportViewer1.ReportSource = reportDocument
        SALARAYRECORDZ.ShowDialog()
        SALARAYRECORDZ.Dispose()
    End Sub

    Private Sub BunifuButton2_Click(sender As Object, e As EventArgs) Handles BunifuButton2.Click
        dbcomm.Connection = connClass.dbconn
        connClass.OpenConnection()
        Dim dt As New DataTable

        With dt
            .Columns.Add("Supplier_Name")
            .Columns.Add("Date_Ordered")
            .Columns.Add("Payment")
        End With

        For Each dgr As DataGridViewRow In Me.DataGridView1.Rows
            dt.Rows.Add(dgr.Cells(0).Value, dgr.Cells(1).Value, dgr.Cells(2).Value)
        Next



        Dim reportDocument As CrystalDecisions.CrystalReports.Engine.ReportDocument
        reportDocument = New CrystalReport4
        reportDocument.Database.Tables("suppOrd").SetDataSource(dt)
        reportDocument.SetParameterValue("oSSS", oSSS.Text)
        suppOrd.CrystalReportViewer1.ReportSource = reportDocument
        suppOrd.ShowDialog()
        suppOrd.Dispose()
    End Sub
End Class