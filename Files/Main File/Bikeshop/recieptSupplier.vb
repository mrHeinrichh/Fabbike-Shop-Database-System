
Imports CrystalDecisions.CrystalReports.Engine.ReportDocument
Imports CrystalDecisions.Shared
Imports MySql.Data.MySqlClient
Public Class recieptSupplier
    Dim report As New CrystalReport1
    Dim mydatarecords As DataTable = New DataTable
    Dim sqlString As String = ""
    Dim connClass As ConnectToDb = New ConnectToDb
    Dim dbcomm As New MySqlCommand
    Dim dbread As MySqlDataReader
    Dim dt1 As New DataTable
    Dim sql As String
    Dim dbconn As New MySqlConnection

    Private Sub recieptSupplier_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        dbcomm.Connection = connClass.dbconn
        connClass.OpenConnection()

        dt1 = Resiboz(sql, connClass.dbconn)

        report.SetDataSource(dt1)

        CrystalReportViewer1.ReportSource = report
        CrystalReportViewer1.Refresh()


    End Sub
    Public Function Resiboz(ByVal sql As String, ByVal dbconn As MySqlConnection) As DataTable
        dbcomm.Connection = connClass.dbconn
        connClass.OpenConnection()

        sql = "SELECT S.Supplier_Name, SO.Date_Ordered, SO.Payment, A.Cost_Price, A.Description
FROM Supplierz S INNER JOIN Supplier_Order SO 
INNER JOIN Supplier_Accessoriez SA 
INNER JOIN Accessoriez A 
UNION
SELECT S.Supplier_Name, SO.Date_Ordered, SO.Payment, P.Cost_Price, P.Description
FROM Supplierz S INNER JOIN Supplier_Order SO 
INNER JOIN Supplier_Products SP 
INNER JOIN Productz P "
        dbcomm = New MySqlCommand(sql, connClass.dbconn)
        dbread = dbcomm.ExecuteReader
        dt1.Load(dbread)
        dbread.Close()
        Return dt1
    End Function

End Class