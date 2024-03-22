Imports System.Data.OleDb
Imports System.Runtime.InteropServices
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Threading

Module ModMySQLDB

    Friend myOledAdapter As New OleDbDataAdapter
    Friend mydataRecordSet As New Recordset
    Friend sqlCommand As New OleDbCommand
    Friend mySqlConnect As New Connection
    '  Friend sqlStatus As Boolean
    Friend connString As String
    Friend Sub sqlConnect()

        Try
            'works with odbc driver Microsoft access driver(*mdb. *acccdb) 64bit 
            If mySqlConnect.State = 0 Then mySqlConnect.Open("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" &
                                                             My.Settings.myServer.ToString & ";Jet OLEDB:Database Password=" &
                                                             My.Settings.myPassword.ToString & ";")
            mySqlConnect.CommandTimeout = (60 * 3)
            ' sqlStatus = True
            If mydataRecordSet.State = 1 Then mydataRecordSet.Close()
        Catch ex As COMException
            ' sqlStatus = False
            Dim el As New Receipt_Management_System.ErrorLogger
            el.WriteToErrorLog(ex.Message, ex.StackTrace, "Database Opening Error")
        End Try
    End Sub


    Friend Function getData(sqlCommand As String, MydatasetTable As DataTable)
        Try
            sqlConnect()
            mydataRecordSet.Open(sqlCommand, mySqlConnect, 3, 3)
            myOledAdapter.Fill(MydatasetTable, mydataRecordSet)
        Catch ex As System.Exception
            closecon()
        End Try
        Return MydatasetTable
    End Function

    Friend Sub closecon()
        If mySqlConnect.State = 1 Then mySqlConnect.Close()
    End Sub
End Module
