Imports System.Data.SqlClient

Public Class T_BUKKENRead
    Inherits DAL.DALBase

    ''' <summary>
    ''' PK検索
    ''' </summary>
    Public Function GetDataWherePk(ByVal bukkenNo As Decimal) As dsT_BUKKEN.T_BUKKENDataTable
        Dim logic As New ExecuteQuery

        Dim strSQL As String = vbNullString
        strSQL += vbCrLf & "select"
        strSQL += vbCrLf & "    BUK.BUKKENNO"
        strSQL += vbCrLf & "  , BUK.BUKKENNAME"
        strSQL += vbCrLf & "  , BUK.KOUSHU"
        strSQL += vbCrLf & "  , BUK.POSTNO"
        strSQL += vbCrLf & "  , BUK.ADDRESS"
        strSQL += vbCrLf & "  , BUK.ADDRESS1"
        strSQL += vbCrLf & "  , BUK.ADDRESS2"
        strSQL += vbCrLf & "  , BUK.LAT"
        strSQL += vbCrLf & "  , BUK.LNG"
        strSQL += vbCrLf & "  , BUK.MOTOUKECODE"
        strSQL += vbCrLf & "  , TOK.TOKUINAME"
        strSQL += vbCrLf & "  , isnull(TOK.SIHARAIBI, 0)   as SIHARAIBI"
        strSQL += vbCrLf & "  , BUK.TANTOCODE"
        strSQL += vbCrLf & "  , TAN.TANTONAME"
        strSQL += vbCrLf & "  , BUK.CHAKKOUDATE"
        strSQL += vbCrLf & "  , BUK.KANKOUDATE"
        strSQL += vbCrLf & "from T_BUKKEN BUK"
        strSQL += vbCrLf & "left outer join M_TOKUI TOK"
        strSQL += vbCrLf & "  on TOK.TOKUICODE = BUK.MOTOUKECODE"
        strSQL += vbCrLf & "left outer join M_TANTO TAN"
        strSQL += vbCrLf & "  on TAN.TANTOCODE = BUK.TANTOCODE"
        strSQL += vbCrLf & "where BUKKENNO = @BUKKENNO"

        Dim param() As SqlParameter = New SqlParameter() {
            New SqlParameter("@BUKKENNO", bukkenNo)
        }

        Dim ds As DataSet = logic.ExecuteDataset(connectionString, CommandType.Text, strSQL, param)

        Dim dt As dsT_BUKKEN.T_BUKKENDataTable = New dsT_BUKKEN.T_BUKKENDataTable
        Dim dr As dsT_BUKKEN.T_BUKKENRow

        For Each row As DataRow In ds.Tables(0).Rows
            dr = DirectCast(dt.NewRow, dsT_BUKKEN.T_BUKKENRow)
            dr.BUKKENNO = CType(row.Item("BUKKENNO"), Decimal)
            dr.BUKKENNAME = row.Item("BUKKENNAME").ToString
            dr.KOUSHU = row.Item("KOUSHU").ToString
            dr.POSTNO = row.Item("POSTNO").ToString
            dr.ADDRESS = row.Item("ADDRESS").ToString
            dr.ADDRESS1 = row.Item("ADDRESS1").ToString
            dr.ADDRESS2 = row.Item("ADDRESS2").ToString
            dr.LAT = row.Item("LAT").ToString
            dr.LNG = row.Item("LNG").ToString
            dr.MOTOUKECODE = row.Item("MOTOUKECODE").ToString
            dr.TOKUINAME = row.Item("TOKUINAME").ToString
            dr.SIHARAIBI = CType(row.Item("SIHARAIBI"), Decimal)
            dr.TANTOCODE = row.Item("TANTOCODE").ToString
            dr.TANTONAME = row.Item("TANTONAME").ToString
            dr.CHAKKOUDATE = row.Item("CHAKKOUDATE").ToString
            dr.KANKOUDATE = row.Item("KANKOUDATE").ToString

            dt.Rows.Add(dr)
        Next

        Return dt
    End Function

    ''' <summary>
    ''' 新規登録
    ''' </summary>
    Public Function insertT_BUKKEN(ByVal dr As dsT_BUKKEN.T_BUKKENRow) As String
        Dim logic As New ExecuteQuery

        Dim strSQL As String = vbNullString
        strSQL += vbCrLf & "insert into T_BUKKEN values ("
        strSQL += vbCrLf & "    @BUKKENNO"
        strSQL += vbCrLf & "  , @BUKKENNAME"
        strSQL += vbCrLf & "  , @KOUSHU"
        strSQL += vbCrLf & "  , @POSTNO"
        strSQL += vbCrLf & "  , @ADDRESS"
        strSQL += vbCrLf & "  , @ADDRESS1"
        strSQL += vbCrLf & "  , @ADDRESS2"
        strSQL += vbCrLf & "  , @LAT"
        strSQL += vbCrLf & "  , @LNG"
        strSQL += vbCrLf & "  , @MOTOUKECODE"
        strSQL += vbCrLf & "  , @TANTOCODE"
        If CommonUtility.Utility.NUCheck(dr.CHAKKOUDATE) Then
            strSQL += vbCrLf & "  , NULL"
        Else
            strSQL += vbCrLf & "  , @CHAKKOUDATE"
        End If
        If CommonUtility.Utility.NUCheck(dr.KANKOUDATE) Then
            strSQL += vbCrLf & "  , NULL"
        Else
            strSQL += vbCrLf & "  , @KANKOUDATE"
        End If
        strSQL += vbCrLf & "  , getdate()"
        strSQL += vbCrLf & "  , @UPDATEPGID"
        strSQL += vbCrLf & "  , @UPDATEUSERCODE"
        strSQL += vbCrLf & "  , getdate()"
        strSQL += vbCrLf & "  , getdate()"
        strSQL += vbCrLf & ")"

        '物件Noの採番
        Dim S_SCB As New S_SCBRead("DENPYONO", "BUKKENNO")
        Dim dsS_SCB As dsS_SCB = S_SCB.GetS_SCB
        dr.BUKKENNO = Decimal.Parse(dsS_SCB.S_SCB(0).DATA)

        'S_SCBの更新
        S_SCB.updateDATA("DENPYONO", "BUKKENNO", (dr.BUKKENNO + 1).ToString)

        '登録の実行
        logic.ExecuteNonQuery(connectionString, CommandType.Text, strSQL, SetParameter(dr))

        Return dr.BUKKENNO.ToString
    End Function

    ''' <summary>
    ''' 更新
    ''' </summary>
    Public Sub updateT_BUKKEN(ByVal dr As dsT_BUKKEN.T_BUKKENRow)
        Dim logic As New ExecuteQuery

        Dim strSQL As String = vbNullString
        strSQL += vbCrLf & "update T_BUKKEN"
        strSQL += vbCrLf & "set"
        strSQL += vbCrLf & "    BUKKENNAME     = @BUKKENNAME"
        strSQL += vbCrLf & "  , KOUSHU         = @KOUSHU"
        strSQL += vbCrLf & "  , POSTNO         = @POSTNO"
        strSQL += vbCrLf & "  , ADDRESS        = @ADDRESS"
        strSQL += vbCrLf & "  , ADDRESS1       = @ADDRESS1"
        strSQL += vbCrLf & "  , ADDRESS2       = @ADDRESS2"
        strSQL += vbCrLf & "  , LAT            = @LAT"
        strSQL += vbCrLf & "  , LNG            = @LNG"
        strSQL += vbCrLf & "  , MOTOUKECODE    = @MOTOUKECODE"
        strSQL += vbCrLf & "  , TANTOCODE      = @TANTOCODE"
        If CommonUtility.Utility.NUCheck(dr.CHAKKOUDATE) Then
            strSQL += vbCrLf & "  , CHAKKOUDATE    = NULL"
        Else
            strSQL += vbCrLf & "  , CHAKKOUDATE    = @CHAKKOUDATE"
        End If
        If CommonUtility.Utility.NUCheck(dr.KANKOUDATE) Then
            strSQL += vbCrLf & "  , KANKOUDATE    = NULL"
        Else
            strSQL += vbCrLf & "  , KANKOUDATE    = @KANKOUDATE"
        End If
        strSQL += vbCrLf & "  , UPDATEMENT     = getdate()"
        strSQL += vbCrLf & "  , UPDATEPGID     = @UPDATEPGID"
        strSQL += vbCrLf & "  , UPDATEUSERCODE = @UPDATEUSERCODE"
        strSQL += vbCrLf & "where BUKKENNO = @BUKKENNO"

        logic.ExecuteNonQuery(connectionString, CommandType.Text, strSQL, SetParameter(dr))
    End Sub

    Private Function SetParameter(ByVal row As dsT_BUKKEN.T_BUKKENRow) As SqlParameter()
        Return New SqlParameter() {
            New SqlParameter("@BUKKENNO", row.BUKKENNO),
            New SqlParameter("@BUKKENNAME", row.BUKKENNAME),
            New SqlParameter("@KOUSHU", row.KOUSHU),
            New SqlParameter("@POSTNO", row.POSTNO),
            New SqlParameter("@ADDRESS", row.ADDRESS),
            New SqlParameter("@ADDRESS1", row.ADDRESS1),
            New SqlParameter("@ADDRESS2", row.ADDRESS2),
            New SqlParameter("@LAT", row.LAT),
            New SqlParameter("@LNG", row.LNG),
            New SqlParameter("@MOTOUKECODE", row.MOTOUKECODE),
            New SqlParameter("@TANTOCODE", row.TANTOCODE),
            New SqlParameter("@CHAKKOUDATE", row.CHAKKOUDATE),
            New SqlParameter("@KANKOUDATE", row.KANKOUDATE),
            New SqlParameter("@UPDATEPGID", row.UPDATEPGID),
            New SqlParameter("@UPDATEUSERCODE", row.UPDATEUSERCODE)
        }
    End Function

    ''' <summary>
    ''' 削除
    ''' </summary>
    Public Sub deleteT_BUKKEN(ByVal bukkenNo As String)
        Dim logic As New ExecuteQuery

        Dim strSQL As String = vbNullString
        strSQL += vbCrLf & "delete from T_BUKKEN where BUKKENNO = @BUKKENNO"

        Dim param() As SqlParameter = New SqlParameter() {
            New SqlParameter("@BUKKENNO", bukkenNo)
        }

        logic.ExecuteNonQuery(connectionString, CommandType.Text, strSQL, param)
    End Sub

End Class
