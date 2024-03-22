Imports CrystalDecisions.CrystalReports.Engine.ReportDocument
Imports CrystalDecisions.Shared
Imports MySql.Data.MySqlClient
Public Class recieptcustomer
    ' Dim report As New CrystalReport2
    Dim mydatarecords As DataTable = New DataTable
    Dim sqlString As String = ""
    Dim connClass As ConnectToDb = New ConnectToDb
    Dim dbcomm As New MySqlCommand
    Dim dbread As MySqlDataReader
    Dim dt2 As New DataTable
    Dim sql As String
    Dim dbconn As New MySqlConnection
    Private Sub recieptcustomer_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        dbcomm.Connection = connClass.dbconn
        connClass.OpenConnection()

        dt2 = Resiboz(sql, connClass.dbconn)

        'report.SetDataSource(dt2)

        'CrystalReportViewer1.ReportSource = report
        CrystalReportViewer1.Refresh()
    End Sub
    Public Function Resiboz(ByVal sql As String, ByVal dbconn As MySqlConnection) As DataTable
        dbcomm.Connection = connClass.dbconn
        connClass.OpenConnection()

        sql = "SELECT customerz.custName,Order_Transactionz.order_Date,Order_Transactionz.shipping_fee,theCart.Prod_Description,theCart.AcceDescription,theCart.quantity  FROM fabbike_new.customerz INNER JOIN fabbike_new.order_Transactionz INNER JOIN fabbike_new.theCart;"
        dbcomm = New MySqlCommand(sql, connClass.dbconn)
        dbread = dbcomm.ExecuteReader
        dt2.Load(dbread)
        dbread.Close()
        Return dt2
    End Function
End Class