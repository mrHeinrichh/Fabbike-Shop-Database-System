Imports MySql.Data.MySqlClient
Imports System.IO
Public Class mechPROFILE
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
    Private Sub mechPROFILE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        getdata()
        dbcomm.Connection = connClass.dbconn
        connClass.OpenConnection()
        sqlString = "Select Name,Email,ContactNum From Users"
        mydatarecords = connClass.selectFrom(sqlString)
        DataGridView1.DataSource = mydatarecords
    End Sub
    Private Sub getdata()
        dbcomm.Connection = connClass.dbconn
        connClass.OpenConnection()
        sqlString1 = "Select * From Users"
        data1 = connClass.selectFrom(sqlString1)
        ComboBox1.DataSource = data1
        ComboBox1.ValueMember = "users_ID"
        ComboBox1.DisplayMember = "users_ID"
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        TextBox1.Text = data1.Rows(ComboBox1.SelectedIndex).Item("Name").ToString()
        TextBox2.Text = data1.Rows(ComboBox1.SelectedIndex).Item("Email").ToString()
        TextBox3.Text = data1.Rows(ComboBox1.SelectedIndex).Item("ContactNum").ToString()
    End Sub
End Class