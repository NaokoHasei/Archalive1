Imports BLL.Common


Public Class daMSE0090

    Implements IDisposable

    Public Sub Dispose() Implements IDisposable.Dispose
    End Sub

#Region "県マスタ削除"
    ''' <summary>
    ''' 県マスタ削除
    ''' </summary>
    ''' <param name="conn">トランザクション済みコネクション</param>
    ''' <remarks></remarks>
    Public Sub DeleteData(ByRef conn As System.Data.SqlClient.SqlConnection)
        Dim logic As New BLL.Common.ExecuteQuery
        logic.ExecuteNonQuery(conn, CommandType.Text, "delete from M_KEN")
    End Sub
#End Region

    Public Function ReadS_SCB(ByVal CATEGORYID As String, ByVal DATAKEY As String) As String
        Dim S_SCB As S_SCBRead = New S_SCBRead(CATEGORYID, DATAKEY)
        Dim dt As dsS_SCB.S_SCBDataTable = S_SCB.GetS_SCB.S_SCB

        If dt.Rows.Count = 0 Then
            Return ""
        End If
        Return dt.Rows(0)("DATA").ToString
    End Function
End Class
