Imports MySql.Data.MySqlClient
Public Class LogIn_Form
    Dim mydatarecords As DataTable = New DataTable
    Public sqlString As String = ""
    Public sqlString1 As String = ""
    Dim connClass As ConnectToDb = New ConnectToDb
    Dim dbcomm As New MySqlCommand
    Dim dbread As MySqlDataReader
    Dim da As New MySqlDataAdapter
    Private Sub BunifuButton1_Click(sender As Object, e As EventArgs) Handles BunifuButton1.Click
        Try
            dbcomm.Connection = connClass.dbconn
            connClass.OpenConnection()
            mydatarecords = connClass.selectFrom("Select uszrName,pssWrdz from Users where uszrName='" & userName.Text & "'AND pssWrdz='" & passWRD.Text & "'")
            If mydatarecords.Rows.Count = Nothing Then

            Else
                MessageBox.Show("Welcome!")
            End If
        Catch ex As Exception
            MsgBox("Error in collecting data from Database. Error is :" & ex.Message)
        End Try

        If TextBox1.Text = "Ad" Then
            MAINform.Show()
            Me.Hide()
        ElseIf TextBox1.Text = "Mec" Then
            '   mechanicFORM.sqlString1 = "SELECT Name FROM Users WHERE uszrName = '" & userName.Text & "'"
            mechanicFORM.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub BunifuRadioButton1_Click(sender As Object, e As EventArgs) Handles BunifuRadioButton1.Click
        TextBox1.Text = "Mec"
    End Sub

    Private Sub BunifuRadioButton2_Click(sender As Object, e As EventArgs) Handles BunifuRadioButton2.Click
        TextBox1.Text = "Ad"
    End Sub

    Private Sub passWRD_TextChanged(sender As Object, e As EventArgs) Handles passWRD.TextChanged

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        USER_REGISTER.Show()
    End Sub

    Private Sub LogIn_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub BunifuButton2_Click(sender As Object, e As EventArgs) Handles BunifuButton2.Click
        ORDERnow.Show()
    End Sub
End Class