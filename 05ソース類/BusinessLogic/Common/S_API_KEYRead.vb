Imports System.Data.SqlClient

Public Class S_API_KEYRead
    Inherits DAL.DALBase

    ''' <summary>
    ''' APIキーの取得
    ''' </summary>
    Public Function GetData() As String
        Dim logic As New ExecuteQuery

        Dim ds As DataSet = logic.ExecuteDataset(connectionString, CommandType.Text, "select API_KEY from S_API_KEY")

        If ds.Tables(0).Rows.Count = 0 Then
            Return ""
        End If

        Return ds.Tables(0).Rows(0).Item("API_KEY").ToString
    End Function
End Class
