Imports MySql.Data.MySqlClient
Public Class CRUDprctBikeservice
    Dim mydatarecords As DataTable = New DataTable
    Dim sqlString As String = ""
    Dim sqlString1 As String = ""
    Dim sqlString2 As String = ""
    Dim connClass As ConnectToDb = New ConnectToDb
    Dim dbcomm As New MySqlCommand
    Dim dbread As MySqlDataReader
    Dim cmb As New DataSet
    Dim data1 As New DataTable
    Dim data2 As New DataTable
    'Dim DataAdapter1 As MySqlDataAdapter

    Private Sub BUTTONbikeshopservice_Load(sender As Object, e As EventArgs) Handles MyBase.Load, Refresh.Click
        dbcomm.Connection = connClass.dbconn
        connClass.OpenConnection()

        sqlString = "SELECT Wagez_ID,Salary FROM Wagez"
        mydatarecords = connClass.selectFrom(sqlString)
        dgrid1.DataSource = mydatarecords
        sqlString1 = "SELECT * FROM Bike_Service"
        mydatarecords = connClass.selectFrom(sqlString1)
        dgrid2.DataSource = mydatarecords

        getdata()
        getthedata()
    End Sub

    Private Sub getdata()
        sqlString1 = "SELECT * FROM Bike_Service"
        data1 = connClass.selectFrom(sqlString1)
        cmb1.DataSource = data1
        cmb1.ValueMember = "service_id"
        cmb1.DisplayMember = "service_id"
    End Sub
    Private Sub getthedata()

        sqlString2 = "SELECT * FROM Wagez"
        data2 = connClass.selectFrom(sqlString2)
        cmb2.DataSource = data2
        cmb2.ValueMember = "Wagez_ID"
        cmb2.DisplayMember = "Wagez_ID"
    End Sub

    Private Sub Delete_Click(sender As Object, e As EventArgs) Handles Concat.Click
        total.Text = Val(percentage.Text) / serrvCost.Text
        salaries.Text = Val(total.Text) + Val(salaries.Text)
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb1.SelectedIndexChanged
        serviceInfo.Text = data1.Rows(cmb1.SelectedIndex).Item("Service_info").ToString()
        serviceDate.Text = data1.Rows(cmb1.SelectedIndex).Item("Service_Date").ToString()
        serrvCost.Text = data1.Rows(cmb1.SelectedIndex).Item("Service_Cost").ToString()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cmb2.SelectedIndexChanged

        salaries.Text = data2.Rows(cmb2.SelectedIndex).Item("Salary").ToString()

    End Sub

    Private Sub Insert_Click(sender As Object, e As EventArgs) Handles Insert.Click
        connClass.OpenConnection()
        Dim sqlString1 As String = "UPDATE Wagez Set Salary=@Salary WHERE Wagez_ID=@Wagez_ID"
        With dbcomm
            .Connection = connClass.dbconn
            .CommandText = sqlString1
            .Parameters.AddWithValue("@Wagez_ID", cmb2.Text)
            .Parameters.AddWithValue("@Salary", salaries.Text)
        End With
        Dim r As Integer
        r = dbcomm.ExecuteNonQuery()
        dbcomm.Parameters.Clear()
    End Sub
End Class