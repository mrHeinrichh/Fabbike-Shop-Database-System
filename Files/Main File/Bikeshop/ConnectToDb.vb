Imports MySql.Data.MySqlClient
Imports System.IO
Public Class ConnectToDb
    Dim conn As String = "Data Source=localhost;Database=fabbike_new;User=root;Password=;"
    Public dbconn As New MySqlConnection
    Dim dbcomm As New MySqlCommand
    Dim dbread As MySqlDataReader
    Dim DataAdapter1 As New MySqlDataAdapter
    Dim ds As DataSet
    Dim dt As DataTable
    Dim id As Integer
    Dim user_id As Integer

    'OPEN CONNECTION
    Public Sub OpenConnection()
        Try
            If dbconn.State = ConnectionState.Open Then
                dbconn.Close()
                dbconn.Open()
            Else
                dbconn.ConnectionString = conn
                dbconn.Open()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Function selectFrom(sqlString As String) As DataTable
        'Select Function
        With dbcomm
            .CommandText = sqlString
            .Connection = dbconn
        End With

        dt = New DataTable
        DataAdapter1.SelectCommand = dbcomm
        DataAdapter1.Fill(dt)
        closeCOn()
        Return dt
    End Function
    'INSERT FUNCTION
    Public Sub insertTo(sqlString As String)
        Dim sqlCommand As New MySqlCommand(sqlString, dbconn)
        sqlCommand.ExecuteNonQuery()
        closeCOn()
    End Sub
    'delete function
    Public Sub deleteFrom(sqlString As String)
        Dim sqlCommand As New MySqlCommand(sqlString, dbconn)
        sqlCommand.ExecuteNonQuery()
        closeCOn()
    End Sub
    'update function
    Public Sub updateFrom(sqlString As String)
        Dim sqlCommand As New MySqlCommand(sqlString, dbconn)
        sqlCommand.ExecuteNonQuery()
        closeCOn()
    End Sub

    'CLOSE CONNECTION
    Public Sub closeCOn()

        dbconn.Close()

    End Sub
End Class
