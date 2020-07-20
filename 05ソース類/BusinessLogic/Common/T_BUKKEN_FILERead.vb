Imports System.Data.SqlClient

Public Class T_BUKKEN_FILERead
    Inherits DAL.DALBase

    ''' <summary>
    ''' 物件単位の検索
    ''' </summary>
    ''' <param name="bukkenNo">物件No</param>
    ''' <returns>物件資料トランのデータテーブル</returns>
    Public Function GetDataWhereBukkenNo(ByVal bukkenNo As Decimal) As dsT_BUKKEN_FILE.T_BUKKEN_FILEDataTable
        Dim logic As New ExecuteQuery

        Dim strSQL As String = vbNullString
        strSQL += vbCrLf & "select"
        strSQL += vbCrLf & "    BUK.BUKKENNO"
        strSQL += vbCrLf & "  , BUK.FILENO"
        strSQL += vbCrLf & "  , BUK.FILEPATH"
        strSQL += vbCrLf & "  , BUK.FILENNAME"
        strSQL += vbCrLf & "  , BUK.UPDATEUSERCODE"
        strSQL += vbCrLf & "  , TAN.TANTONAME"
        strSQL += vbCrLf & "  , convert(VARCHAR, BUK.UPDATEMENT, 111) + ' ' + convert(VARCHAR, BUK.UPDATEMENT, 108) as UPDATEMENT"
        strSQL += vbCrLf & "from T_BUKKEN_FILE BUK"
        strSQL += vbCrLf & "left outer join M_TANTO TAN"
        strSQL += vbCrLf & "  on TAN.TANTOCODE = BUK.UPDATEUSERCODE"
        strSQL += vbCrLf & "where BUKKENNO = @BUKKENNO"
        strSQL += vbCrLf & "order by"
        strSQL += vbCrLf & "    convert(VARCHAR, BUK.UPDATEMENT, 111) + ' ' + convert(VARCHAR, BUK.UPDATEMENT, 108) desc"
        strSQL += vbCrLf & "  , FILENNAME"

        Dim param() As SqlParameter = New SqlParameter() {
            New SqlParameter("@BUKKENNO", bukkenNo)
        }

        Dim ds As DataSet = logic.ExecuteDataset(connectionString, CommandType.Text, strSQL, param)

        Dim dt As dsT_BUKKEN_FILE.T_BUKKEN_FILEDataTable = New dsT_BUKKEN_FILE.T_BUKKEN_FILEDataTable
        Dim dr As dsT_BUKKEN_FILE.T_BUKKEN_FILERow

        For Each row As DataRow In ds.Tables(0).Rows
            dr = DirectCast(dt.NewRow, dsT_BUKKEN_FILE.T_BUKKEN_FILERow)
            dr.BUKKENNO = CType(row.Item("BUKKENNO"), Decimal)
            dr.FILENO = CType(row.Item("FILENO"), Decimal)
            dr.FILEPATH = row.Item("FILEPATH").ToString
            dr.FILENNAME = row.Item("FILENNAME").ToString
            dr.UPDATEUSERCODE = row.Item("UPDATEUSERCODE").ToString
            dr.TANTONAME = row.Item("TANTONAME").ToString
            dr.UPDATEMENT = row.Item("UPDATEMENT").ToString

            dt.Rows.Add(dr)
        Next

        Return dt
    End Function

    ''' <summary>
    ''' ファイルNoの最大値の取得
    ''' </summary>
    ''' <param name="bukkenNo">物件No</param>
    ''' <returns>物件資料トランのデータテーブル</returns>
    Public Function GetDataMaxFILENO(ByVal bukkenNo As Decimal) As Decimal
        Dim logic As New ExecuteQuery

        Dim strSQL As String = "select isnull(max(FILENO), 0) FILENO from T_BUKKEN_FILE where BUKKENNO = @BUKKENNO"

        Dim param() As SqlParameter = New SqlParameter() {
            New SqlParameter("@BUKKENNO", bukkenNo)
        }

        Dim ds As DataSet = logic.ExecuteDataset(connectionString, CommandType.Text, strSQL, param)

        Return CType(ds.Tables(0).Rows(0).Item("FILENO"), Decimal)
    End Function

    ''' <summary>
    ''' 新規登録
    ''' </summary>
    Public Sub insertT_BUKKEN_FILE(ByVal dr As dsT_BUKKEN_FILE.T_BUKKEN_FILERow)
        Dim logic As New ExecuteQuery

        Dim strSQL As String = vbNullString
        strSQL += vbCrLf & "insert into T_BUKKEN_FILE values ("
        strSQL += vbCrLf & "    @BUKKENNO"
        strSQL += vbCrLf & "  , @FILENO"
        strSQL += vbCrLf & "  , @FILEPATH"
        strSQL += vbCrLf & "  , @FILENNAME"
        strSQL += vbCrLf & "  , @UPDATEMENT"
        strSQL += vbCrLf & "  , @UPDATEPGID"
        strSQL += vbCrLf & "  , @UPDATEUSERCODE"
        strSQL += vbCrLf & "  , getdate()"
        strSQL += vbCrLf & "  , getdate()"
        strSQL += vbCrLf & ")"

        Dim param() As SqlParameter = New SqlParameter() {
            New SqlParameter("@BUKKENNO", dr.BUKKENNO),
            New SqlParameter("@FILENO", dr.FILENO),
            New SqlParameter("@FILEPATH", dr.FILEPATH),
            New SqlParameter("@FILENNAME", dr.FILENNAME),
            New SqlParameter("@UPDATEPGID", dr.UPDATEPGID),
            New SqlParameter("@UPDATEUSERCODE", dr.UPDATEUSERCODE),
            New SqlParameter("@UPDATEMENT", dr.UPDATEMENT)
        }

        '登録の実行
        logic.ExecuteNonQuery(connectionString, CommandType.Text, strSQL, param)
    End Sub

    ''' <summary>
    ''' 更新（更新プログラムID、ユーザID、更新日時）
    ''' </summary>
    Public Sub updateT_BUKKEN_FILE_UPDATEPGID_UPDATEUSERCODE(ByVal dr As dsT_BUKKEN_FILE.T_BUKKEN_FILERow)
        Dim logic As New ExecuteQuery

        Dim strSQL As String = vbNullString
        strSQL += vbCrLf & "update T_BUKKEN_FILE"
        strSQL += vbCrLf & "set UPDATEPGID     = @UPDATEPGID"
        strSQL += vbCrLf & "  , UPDATEUSERCODE = @UPDATEUSERCODE"
        strSQL += vbCrLf & "  , UPDATEMENT     = @UPDATEMENT"
        strSQL += vbCrLf & "where BUKKENNO = @BUKKENNO"
        strSQL += vbCrLf & "and   FILENO   = @FILENO"

        Dim param() As SqlParameter = New SqlParameter() {
            New SqlParameter("@BUKKENNO", dr.BUKKENNO),
            New SqlParameter("@FILENO", dr.FILENO),
            New SqlParameter("@UPDATEPGID", dr.UPDATEPGID),
            New SqlParameter("@UPDATEUSERCODE", dr.UPDATEUSERCODE),
            New SqlParameter("@UPDATEMENT", dr.UPDATEMENT)
        }

        '更新の実行
        logic.ExecuteNonQuery(connectionString, CommandType.Text, strSQL, param)
    End Sub

    ''' <summary>
    ''' 削除
    ''' </summary>
    Public Sub deleteT_BUKKEN_FILE(ByVal bukkenNo As Decimal, ByVal fileNo As Decimal)
        Dim logic As New ExecuteQuery

        Dim strSQL As String = "delete from T_BUKKEN_FILE where BUKKENNO = @BUKKENNO and FILENO = @FILENO"

        Dim param() As SqlParameter = New SqlParameter() {
            New SqlParameter("@BUKKENNO", bukkenNo),
            New SqlParameter("@FILENO", fileNo)
        }

        '削除の実行
        logic.ExecuteNonQuery(connectionString, CommandType.Text, strSQL, param)
    End Sub
End Class
