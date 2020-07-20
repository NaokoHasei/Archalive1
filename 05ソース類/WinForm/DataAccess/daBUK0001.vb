Imports System.Data.SqlClient
Imports BLL.Common

Public Class daBUK0001
    Inherits DAL.DALBase

    ''' <summary>
    ''' 全額請求済の判定結果の取得（true：請求済、false：未請求）
    ''' </summary>
    ''' <param name="bukkenNo">物件No</param>
    ''' <returns>出来高率の合計</returns>
    Public Function GetSeikyuZumi(ByVal bukkenNo As Decimal) As Decimal
        Dim logic As New ExecuteQuery

        Dim param() As SqlParameter = New SqlParameter() {
            New SqlParameter("@BUKKENNO", bukkenNo)
        }

        Dim strSQL As String = vbNullString
        strSQL += vbCrLf & "select isnull(GKJYUTYUGAKU, 0) as GKJYUTYUGAKU"
        strSQL += vbCrLf & "from T_JYUTYUHED"
        strSQL += vbCrLf & "where JYUTYUNO = @bukkenNo"

        Dim ds As DataSet = logic.ExecuteDataset(connectionString, CommandType.Text, strSQL, param)

        Dim jyuchuGaku As Decimal = 0
        If ds.Tables(0).Rows.Count <> 0 Then
            jyuchuGaku = Decimal.Parse(ds.Tables(0).Rows(0).Item("GKJYUTYUGAKU"))
        End If

        strSQL = vbNullString
        strSQL += vbCrLf & "select isnull(sum(GKSEIKYUGAKU), 0) as GKSEIKYUGAKU"
        strSQL += vbCrLf & "from T_SEIKYUHED"
        strSQL += vbCrLf & "where SEIKYUNO = @bukkenNo"

        ds = logic.ExecuteDataset(connectionString, CommandType.Text, strSQL, param)

        Dim seikyuGaku As Decimal = 0
        If ds.Tables(0).Rows.Count <> 0 Then
            seikyuGaku = Decimal.Parse(ds.Tables(0).Rows(0).Item("GKSEIKYUGAKU"))
        End If

        Return jyuchuGaku <= seikyuGaku
    End Function

End Class
