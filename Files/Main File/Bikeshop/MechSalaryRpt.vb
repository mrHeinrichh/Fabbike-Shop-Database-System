Imports MySql.Data.MySqlClient
Imports System.IO
Public Class MechSalaryRpt
    Dim mydatarecords As DataTable = New DataTable
    Dim sqlString As String = ""
    Dim sqlString1 As String = ""
    Dim sqlString26 As String = ""
    Dim connClass As ConnectToDb = New ConnectToDb
    Dim dbcomm As New MySqlCommand
    Dim dbread As MySqlDataReader
    Dim cmb As New DataSet
    Dim data1 As New DataTable
    Private Sub MechSalaryRpt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connClass.OpenConnection()
        sqlString = "SELECT Mechanics_ID Name, Salary,Salary_Date FROM Mechanic INNER JOIN Users INNER JOIN Wagez"
        mydatarecords = connClass.selectFrom(sqlString)
        DataGridView1.DataSource = mydatarecords
    End Sub

    Private Sub BunifuButton2_Click(sender As Object, e As EventArgs) Handles BunifuButton2.Click
        Try
            mydatarecords = connClass.selectFrom("SELECT distinct Name, Salary,Salary_Date FROM Mechanic INNER JOIN Users INNER JOIN Wagez WHERE Mechanic.Mechanics_ID ='" & Val(BunifuTextBox1.Text) & "'")
            If (mydatarecords.Rows.Count > 0) Then
                DataGridView1.DataSource = mydatarecords
            Else
                MessageBox.Show("Not Found!")
            End If
        Catch ex As Exception
            MsgBox("Error in collecting data from Database. Error is :" & ex.Message)
        End Try
    End Sub

    Private Sub BunifuButton1_Click(sender As Object, e As EventArgs) Handles BunifuButton1.Click
        dbcomm.Connection = connClass.dbconn
        connClass.OpenConnection()
        Dim dt As New DataTable

        With dt
            .Columns.Add("Name")
            .Columns.Add("Salary")
            .Columns.Add("Salary_Date")
        End With

        For Each dgr As DataGridViewRow In Me.DataGridView1.Rows
            dt.Rows.Add(dgr.Cells(0).Value, dgr.Cells(1).Value, dgr.Cells(2).Value)
        Next

        Dim reportDocument As CrystalDecisions.CrystalReports.Engine.ReportDocument
        reportDocument = New CrystalReport6
        reportDocument.Database.Tables("mCHZ").SetDataSource(dt)
        MechRprt.CrystalReportViewer1.ReportSource = reportDocument
        MechRprt.ShowDialog()
        MechRprt.Dispose()
    End Sub
End Class