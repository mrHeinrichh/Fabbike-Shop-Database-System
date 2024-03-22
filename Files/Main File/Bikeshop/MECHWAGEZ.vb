Imports MySql.Data.MySqlClient
Imports System.IO
Public Class MECHWAGEZ
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
    Private Sub MECHWAGEZ_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connClass.OpenConnection()
        sqlString = "SELECT distinct Name, Salary,Salary_Date FROM Mechanic INNER JOIN Users INNER JOIN Wagez"
        mydatarecords = connClass.selectFrom(sqlString)
        Dgrid1.DataSource = mydatarecords
    End Sub

    Private Sub Check_Click(sender As Object, e As EventArgs) Handles Check.Click
        Try
            mydatarecords = connClass.selectFrom("SELECT distinct Name, Salary,Salary_Date FROM Mechanic INNER JOIN Users INNER JOIN Wagez WHERE Users.users_ID ='" & Val(suppID.Text) & "'")
            If (mydatarecords.Rows.Count > 0) Then
                Dgrid1.DataSource = mydatarecords
            Else
                MessageBox.Show("Not Found!")
            End If
        Catch ex As Exception
            MsgBox("Error in collecting data from Database. Error is :" & ex.Message)
        End Try
    End Sub
End Class