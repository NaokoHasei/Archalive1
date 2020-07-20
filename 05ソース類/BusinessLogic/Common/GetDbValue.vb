Imports System.Data.SqlClient
Imports System.Data
Imports CommonUtility
Imports Microsoft.ApplicationBlocks.Data

Public Class GetDbValue

    Private connectionString As String

    Public Function Execute(ByVal params As List(Of Model.DTO.GetDbValueElement)) As DataSet

        Dim resultDataSet As DataSet = New DataSet
        Dim i As Integer = 0

        For Each requestParam As Model.DTO.GetDbValueElement In params
            With requestParam
                Dim strSQL As String = ""
                strSQL += "SELECT " & .FieldName
                If Utility.NUCheck(.TableName) = False Then
                    strSQL += " FROM " & .TableName
                End If
                If Utility.NUCheck(.Filter) = False Then
                    strSQL += " WHERE " & .Filter
                End If

                SqlHelper.FillDataset(connectionString, CommandType.Text, strSQL, resultDataSet, New String() {"Table" & i})
            End With
            i += 1
        Next

        Return resultDataSet
    End Function

    Public Shared Function Execute(ByVal table As String, ByVal field As String, ByVal filter As String) As DataSet
        Dim strSQL As String = "select " + field + " from " + table + " where " + filter
        Return SqlHelper.ExecuteDataset(CommonUtility.DBUtility.GetConnectionString, CommandType.Text, strSQL)
    End Function

    Public Shared Function ExecuteGetValue(ByVal table As String, ByVal field As String, ByVal filter As String) As Object

        Dim strSQL As String = "select " + field + " from " + table + " where " + filter
        Dim resultDataSet As DataSet = SqlHelper.ExecuteDataset(CommonUtility.DBUtility.GetConnectionString, CommandType.Text, strSQL)

        If resultDataSet.Tables(0).Rows.Count = 0 Then
            Return Nothing
        Else
            Return resultDataSet.Tables(0).Rows(0).Item(0)

        End If
    End Function

    Public Sub New(ByVal connectionString As String)
        Me.connectionString = connectionString
    End Sub
    Public Sub New()
        connectionString = CommonUtility.DBUtility.GetConnectionString
    End Sub

End Class
