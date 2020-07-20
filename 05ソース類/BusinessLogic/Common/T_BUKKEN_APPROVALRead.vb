Imports System.Data.SqlClient

Public Class T_BUKKEN_APPROVALRead
    Inherits DAL.DALBase

    Public Enum enumGyomuKbn
        Mitsumori = 1
        Jyuchu = 2
        Hacchu = 3
        Seikyu = 4
    End Enum

    Public Enum enumApprovalKbn
        SYONIN_MI = 1
        SYONIN_ZUMI = 2
    End Enum

    ''' <summary>
    ''' 業務区分単位の検索
    ''' </summary>
    ''' <param name="bukkenNo">物件No</param>
    ''' <param name="gyomuKbn">業務区分</param>
    ''' <returns>物件業務リンクトランのデータテーブル</returns>
    Public Function GetDataWhereGyomuKbn(ByVal bukkenNo As Decimal, ByVal gyomuKbn As enumGyomuKbn) As dsT_BUKKEN_APPROVAL.T_BUKKEN_APPROVALDataTable
        Dim logic As New ExecuteQuery

        Dim strSQL As String = vbNullString
        strSQL += " select *"
        strSQL += " from T_BUKKEN_APPROVAL"
        strSQL += " where BUKKENNO = @BUKKENNO"
        strSQL += " and   GYOMUKBN = @GYOMUKBN"

        Dim param() As SqlParameter = New SqlParameter() {
            New SqlParameter("@BUKKENNO", bukkenNo),
            New SqlParameter("@GYOMUKBN", gyomuKbn)
        }

        Dim ds As DataSet = logic.ExecuteDataset(connectionString, CommandType.Text, strSQL, param)

        Dim dt As dsT_BUKKEN_APPROVAL.T_BUKKEN_APPROVALDataTable = New dsT_BUKKEN_APPROVAL.T_BUKKEN_APPROVALDataTable
        Dim dr As dsT_BUKKEN_APPROVAL.T_BUKKEN_APPROVALRow

        For Each row As DataRow In ds.Tables(0).Rows
            dr = DirectCast(dt.NewRow, dsT_BUKKEN_APPROVAL.T_BUKKEN_APPROVALRow)
            dr.BUKKENNO = CType(row.Item("BUKKENNO"), Decimal)
            dr.GYOMUKBN = CType(row.Item("GYOMUKBN"), Decimal)
            dr.EDABAN = CType(row.Item("EDABAN"), Decimal)
            dr.APPROVALKBN = CType(row.Item("APPROVALKBN"), Decimal)

            dt.Rows.Add(dr)
        Next

        Return dt
    End Function

    ''' <summary>
    ''' 最大の枝番のレコードの取得
    ''' </summary>
    ''' <param name="bukkenNo">物件No</param>
    ''' <param name="gyomuKbn">業務区分</param>
    ''' <returns>物件業務リンクトランのデータテーブル</returns>
    Public Function GetDataMaxEdaban(ByVal bukkenNo As Decimal, ByVal gyomuKbn As enumGyomuKbn) As dsT_BUKKEN_APPROVAL.T_BUKKEN_APPROVALDataTable
        Dim logic As New ExecuteQuery

        Dim strSQL As String = vbNullString
        strSQL += " select *"
        strSQL += " from T_BUKKEN_APPROVAL"
        strSQL += " where BUKKENNO = @BUKKENNO"
        strSQL += " and   GYOMUKBN = @GYOMUKBN"
        strSQL += " and   EDABAN   = ("
        strSQL += "   select max(EDABAN)"
        strSQL += "   from T_BUKKEN_APPROVAL"
        strSQL += "   where BUKKENNO = @BUKKENNO"
        strSQL += "   and   GYOMUKBN = @GYOMUKBN)"

        Dim param() As SqlParameter = New SqlParameter() {
            New SqlParameter("@BUKKENNO", bukkenNo),
            New SqlParameter("@GYOMUKBN", gyomuKbn)
        }

        Dim ds As DataSet = logic.ExecuteDataset(connectionString, CommandType.Text, strSQL, param)

        Dim dt As dsT_BUKKEN_APPROVAL.T_BUKKEN_APPROVALDataTable = New dsT_BUKKEN_APPROVAL.T_BUKKEN_APPROVALDataTable
        Dim dr As dsT_BUKKEN_APPROVAL.T_BUKKEN_APPROVALRow

        For Each row As DataRow In ds.Tables(0).Rows
            dr = DirectCast(dt.NewRow, dsT_BUKKEN_APPROVAL.T_BUKKEN_APPROVALRow)
            dr.BUKKENNO = CType(row.Item("BUKKENNO"), Decimal)
            dr.GYOMUKBN = CType(row.Item("GYOMUKBN"), Decimal)
            dr.EDABAN = CType(row.Item("EDABAN"), Decimal)
            dr.APPROVALKBN = CType(row.Item("APPROVALKBN"), Decimal)

            dt.Rows.Add(dr)
        Next

        Return dt
    End Function

    ''' <summary>
    ''' 承認済の取得
    ''' </summary>
    ''' <param name="bukkenNo">物件No</param>
    ''' <param name="gyomuKbn">業務区分</param>
    ''' <returns>物件業務リンクトランのデータテーブル</returns>
    Public Function GetDataSyoniZumi(ByVal bukkenNo As Decimal, ByVal gyomuKbn As enumGyomuKbn) As dsT_BUKKEN_APPROVAL.T_BUKKEN_APPROVALDataTable
        Dim logic As New ExecuteQuery

        Dim strSQL As String = vbNullString
        strSQL += " select *"
        strSQL += " from T_BUKKEN_APPROVAL"
        strSQL += " where BUKKENNO    = @BUKKENNO"
        strSQL += " and   GYOMUKBN    = @GYOMUKBN"
        strSQL += " and   APPROVALKBN = " + CStr(enumApprovalKbn.SYONIN_ZUMI)

        Dim param() As SqlParameter = New SqlParameter() {
            New SqlParameter("@BUKKENNO", bukkenNo),
            New SqlParameter("@GYOMUKBN", gyomuKbn)
        }

        Dim ds As DataSet = logic.ExecuteDataset(connectionString, CommandType.Text, strSQL, param)

        Dim dt As dsT_BUKKEN_APPROVAL.T_BUKKEN_APPROVALDataTable = New dsT_BUKKEN_APPROVAL.T_BUKKEN_APPROVALDataTable
        Dim dr As dsT_BUKKEN_APPROVAL.T_BUKKEN_APPROVALRow

        For Each row As DataRow In ds.Tables(0).Rows
            dr = DirectCast(dt.NewRow, dsT_BUKKEN_APPROVAL.T_BUKKEN_APPROVALRow)
            dr.BUKKENNO = CType(row.Item("BUKKENNO"), Decimal)
            dr.GYOMUKBN = CType(row.Item("GYOMUKBN"), Decimal)
            dr.EDABAN = CType(row.Item("EDABAN"), Decimal)
            dr.APPROVALKBN = CType(row.Item("APPROVALKBN"), Decimal)

            dt.Rows.Add(dr)
        Next

        Return dt
    End Function

    ''' <summary>
    ''' PKの検索
    ''' </summary>
    ''' <param name="bukkenNo">物件No</param>
    ''' <param name="gyomuKbn">業務区分</param>
    ''' <returns>物件業務リンクトランのデータテーブル</returns>
    Public Function GetDataWherePK(ByVal bukkenNo As Decimal, ByVal gyomuKbn As enumGyomuKbn, ByVal edaban As Decimal) As dsT_BUKKEN_APPROVAL.T_BUKKEN_APPROVALDataTable
        Dim logic As New ExecuteQuery

        Dim strSQL As String = vbNullString
        strSQL += " select *"
        strSQL += " from T_BUKKEN_APPROVAL"
        strSQL += " where BUKKENNO = @BUKKENNO"
        strSQL += " and   GYOMUKBN = @GYOMUKBN"
        strSQL += " and   EDABAN   = @EDABAN"

        Dim param() As SqlParameter = New SqlParameter() {
            New SqlParameter("@BUKKENNO", bukkenNo),
            New SqlParameter("@GYOMUKBN", gyomuKbn),
            New SqlParameter("@EDABAN", edaban)
        }

        Dim ds As DataSet = logic.ExecuteDataset(connectionString, CommandType.Text, strSQL, param)

        Dim dt As dsT_BUKKEN_APPROVAL.T_BUKKEN_APPROVALDataTable = New dsT_BUKKEN_APPROVAL.T_BUKKEN_APPROVALDataTable
        Dim dr As dsT_BUKKEN_APPROVAL.T_BUKKEN_APPROVALRow

        For Each row As DataRow In ds.Tables(0).Rows
            dr = DirectCast(dt.NewRow, dsT_BUKKEN_APPROVAL.T_BUKKEN_APPROVALRow)
            dr.BUKKENNO = CType(row.Item("BUKKENNO"), Decimal)
            dr.GYOMUKBN = CType(row.Item("GYOMUKBN"), Decimal)
            dr.EDABAN = CType(row.Item("EDABAN"), Decimal)
            dr.APPROVALKBN = CType(row.Item("APPROVALKBN"), Decimal)

            dt.Rows.Add(dr)
        Next

        Return dt
    End Function

    ''' <summary>
    ''' 新規登録
    ''' </summary>
    Public Sub insertT_BUKKEN_APPROVAL(ByVal dr As dsT_BUKKEN_APPROVAL.T_BUKKEN_APPROVALRow)
        Dim logic As New ExecuteQuery

        Dim strSQL As String = vbNullString
        strSQL += " insert into T_BUKKEN_APPROVAL values ("
        strSQL += "     @BUKKENNO"
        strSQL += "   , @GYOMUKBN"
        strSQL += "   , @EDABAN"
        strSQL += "   , @APPROVALKBN"
        strSQL += "   , getdate()"
        strSQL += "   , @UPDATEPGID"
        strSQL += "   , @UPDATEUSERCODE"
        strSQL += "   , getdate()"
        strSQL += "   , getdate()"
        strSQL += " )"

        Dim param = New SqlParameter() {
                New SqlParameter("@BUKKENNO", dr.BUKKENNO),
                New SqlParameter("@GYOMUKBN", dr.GYOMUKBN),
                New SqlParameter("@EDABAN", dr.EDABAN),
                New SqlParameter("@APPROVALKBN", dr.APPROVALKBN),
                New SqlParameter("@UPDATEPGID", dr.UPDATEPGID),
                New SqlParameter("@UPDATEUSERCODE", dr.UPDATEUSERCODE)
            }

        '登録の実行
        logic.ExecuteNonQuery(connectionString, CommandType.Text, strSQL, param)
    End Sub

    ''' <summary>
    ''' 削除（物件Noで削除）
    ''' </summary>
    Public Sub deleteT_BUKKEN_APPROVAL(ByVal bukkenNo As String)
        Dim logic As New ExecuteQuery

        Dim strSQL As String = vbNullString
        strSQL += vbCrLf & "delete from T_BUKKEN_APPROVAL"
        strSQL += vbCrLf & "where BUKKENNO = @BUKKENNO"

        '削除の実行
        logic.ExecuteNonQuery(connectionString, CommandType.Text, strSQL, New SqlParameter("@BUKKENNO", bukkenNo))
    End Sub

    ''' <summary>
    ''' 削除（PKで削除）
    ''' </summary>
    Public Sub deleteT_BUKKEN_APPROVAL_PK(ByVal bukkenNo As Decimal, ByVal gyomuKbn As enumGyomuKbn, ByVal edaban As Decimal)
        Dim logic As New ExecuteQuery

        Dim strSQL As String = vbNullString
        strSQL += " delete from T_BUKKEN_APPROVAL"
        strSQL += " where BUKKENNO = @BUKKENNO"
        strSQL += " and   GYOMUKBN = @GYOMUKBN"
        strSQL += " and   EDABAN   = @EDABAN"

        Dim param() As SqlParameter = New SqlParameter() {
            New SqlParameter("@BUKKENNO", bukkenNo),
            New SqlParameter("@GYOMUKBN", gyomuKbn),
            New SqlParameter("@EDABAN", edaban)
        }

        '削除の実行
        logic.ExecuteNonQuery(connectionString, CommandType.Text, strSQL, param)
    End Sub

    ''' <summary>
    ''' 承認区分の更新
    ''' </summary>
    Public Sub UpdateSyoninKbn(
              ByVal bukkenNo As String _
            , ByVal gyomuKbn As enumGyomuKbn _
            , ByVal edaban As Decimal _
            , ByVal approvalKbn As enumApprovalKbn)

        Dim logic As New ExecuteQuery
        Dim strSQL As String = vbNullString

        strSQL += " update T_BUKKEN_APPROVAL"
        strSQL += " set APPROVALKBN = @APPROVALKBN"
        strSQL += " where BUKKENNO = @BUKKENNO"
        strSQL += " and   GYOMUKBN = @GYOMUKBN"
        strSQL += " and   EDABAN   = @EDABAN"

        Dim param = New SqlParameter() {
            New SqlParameter("@BUKKENNO", bukkenNo),
            New SqlParameter("@GYOMUKBN", gyomuKbn),
            New SqlParameter("@EDABAN", edaban),
            New SqlParameter("@APPROVALKBN", approvalKbn)
        }

        logic.ExecuteNonQuery(connectionString, CommandType.Text, strSQL, param)
    End Sub
End Class
