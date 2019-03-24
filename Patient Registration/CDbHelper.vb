Imports System.Data.OleDb

Public Class CDbHelper
    Protected mDbConn As OleDbConnection
    Protected objAdapter As OleDbDataAdapter

    Protected objDataSet As DataSet
    Protected Sub New(ByRef dbconn As OleDbConnection, ByVal selectstmt As String, ByVal tablenm As String)
        Initialize(dbconn, selectstmt, tablenm, "ID")

    End Sub

    Protected Sub New(ByRef dbconn As OleDbConnection, ByVal selectstmt As String, ByVal tablenm As String, ByVal strKey As String)
        Initialize(dbconn, selectstmt, tablenm, strKey)
    End Sub

    Protected Sub Initialize(ByRef dbconn As OleDbConnection, ByVal selectstmt As String, ByVal tablenm As String, ByVal strKey As String)
        mDbConn = dbconn
        objDataSet = New DataSet()
        Try
            objAdapter = New OleDbDataAdapter(selectstmt, mDbConn)
            objAdapter.Fill(objDataSet, tablenm)
            With objDataSet.Tables(tablenm)
                .PrimaryKey = New DataColumn() {.Columns(strKey)}

            End With

        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="tablename"></param>
    ''' <param name="selectstmt"></param>
    ''' <param name="key"></param>
    ''' <remarks></remarks>
    Protected Sub Delete(ByVal tablename As String, ByVal selectstmt As String, ByVal key As String)
        Dim objAdapter As OleDb.OleDbDataAdapter
        Dim objBuild As OleDb.OleDbCommandBuilder
        Dim objDR As DataRow

        Try
            ' Find rows to update
            objDR = objDataSet.Tables(tablename).Rows.Find(key)
            ' Mark Data Row for deletion
            objDR.Delete()
            ' Build SQL string
            ' Create new data adapter
            objAdapter = New OleDb.OleDbDataAdapter(selectstmt, mDbConn)
            ' Create Command Build from Adapter
            objBuild = New OleDb.OleDbCommandBuilder(objAdapter)
            ' Get DELETE command object
            objAdapter.DeleteCommand = objBuild.GetDeleteCommand
            ' submit DELETE statement through Adapter
            objAdapter.Update(objDataSet, tablename)
            ' Tell DataSet changes are complete
            objDataSet.AcceptChanges()
            ' Close the connection
            objAdapter.DeleteCommand.Connection.Close()

        Catch ex As Exception
        Finally

        End Try
    End Sub

End Class
