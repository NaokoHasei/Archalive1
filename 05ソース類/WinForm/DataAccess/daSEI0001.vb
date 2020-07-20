Imports System.Data.SqlClient
Imports CommonUtility
Imports BLL.Common

Public Class daSEI0001
    Private connectionString As String

    ''' <summary>
    ''' クラス初期化
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        connectionString = CommonUtility.DBUtility.GetConnectionString
    End Sub

    Public Function ReadS_SCB(ByVal CATEGORYID As String, ByVal DATAKEY As String) As String
        Dim S_SCB As S_SCBRead = New S_SCBRead(CATEGORYID, DATAKEY)
        Dim dt As dsS_SCB.S_SCBDataTable = S_SCB.GetS_SCB.S_SCB

        If dt.Rows.Count = 0 Then
            Return ""
        End If
        Return dt.Rows(0)("DATA").ToString
    End Function

    Public Function ReadS_SCB_ROUNDKBN(ByVal CATEGORYID As String, ByVal DATAKEY As String) As Nullable(Of Decimal)
        Dim S_SCB As S_SCBRead = New S_SCBRead(CATEGORYID, DATAKEY)
        Dim dt As dsS_SCB.S_SCBDataTable = S_SCB.GetS_SCB.S_SCB

        If dt.Rows.Count = 0 OrElse IsNumeric(dt.Rows(0)("DATA").ToString) = False Then
            Return Nothing
        End If
        Return Decimal.Parse(dt.Rows(0)("DATA").ToString)
    End Function

    Public Function ReadT_JYUTYUHED(ByVal Key_JyutyuNo As Decimal, ByVal Key_JyutyuEdaban As Decimal) As dsSEI0001.T_JYUTYUHEDDataTable
        Dim resultDataSet As New dsSEI0001.T_JYUTYUHEDDataTable
        Using adp As New dsSEI0001TableAdapters.T_JYUTYUHEDTableAdapter,
            connection As New SqlConnection(connectionString)
            adp.Connection = connection : CommonUtility.DBUtility.SetCommandTimeout(adp)
            adp.Fill(resultDataSet, Key_JyutyuNo, Key_JyutyuEdaban)
        End Using
        Return resultDataSet
    End Function

    Public Function ReadT_JYUTYU(ByVal Key_JyutyuNo As Decimal, ByVal Key_JyutyuEdaban As Decimal) As dsSEI0001.T_JYUTYUDataTable
        Dim resultDataSet As New dsSEI0001.T_JYUTYUDataTable
        Using adp As New dsSEI0001TableAdapters.T_JYUTYUTableAdapter,
            connection As New SqlConnection(connectionString)
            adp.Connection = connection : CommonUtility.DBUtility.SetCommandTimeout(adp)
            adp.Fill(resultDataSet, Key_JyutyuNo, Key_JyutyuEdaban)
        End Using
        Return resultDataSet
    End Function

    Public Function ReadM_KBN_ZEIRITU(ByVal SeikyuDate As Decimal) As Nullable(Of Decimal)
        Dim resultDataSet As New dsSEI0001.M_KBN_GETZEIRITUDataTable
        Using adp As New dsSEI0001TableAdapters.M_KBN_GETZEIRITUTableAdapter,
            connection As New SqlConnection(connectionString)
            adp.Connection = connection : CommonUtility.DBUtility.SetCommandTimeout(adp)
            adp.Fill(resultDataSet, SeikyuDate)
        End Using
        If resultDataSet.Rows.Count = 0 Then Return Nothing
        If IsNumeric(resultDataSet.Rows(0)("KBNNAME").ToString) = False Then Return Nothing
        Return Decimal.Parse(resultDataSet.Rows(0)("KBNNAME").ToString)
    End Function

    Public Function ReadMainData(ByVal Key_JyuchuNo As Decimal, ByVal Key_JyuchuEdaban As Decimal, ByVal Key_SeikyuNo As Decimal, ByVal Key_SeikyuEdaban As Decimal, ByVal Key_SeikyuDate As DateTime) As dsSEI0001.MainDataDataTable
        Dim resultDataSet As New dsSEI0001.MainDataDataTable
        Using adp As New dsSEI0001TableAdapters.MainDataTableAdapter,
            connection As New SqlConnection(connectionString)
            adp.Connection = connection : CommonUtility.DBUtility.SetCommandTimeout(adp)
            adp.Fill(resultDataSet, Key_JyuchuNo, Key_JyuchuEdaban, Key_SeikyuNo, Key_SeikyuEdaban, Key_SeikyuDate)
        End Using
        Return resultDataSet
    End Function

    Public Function ReadMadeSeikyuGaku(ByVal jyutyuNo As Decimal, ByVal Key_SeikyuDate As Date) As dsSEI0001.GetMadeSeikyuGakuDataTable
        Dim resultDataSet As New dsSEI0001.GetMadeSeikyuGakuDataTable
        Using adp As New dsSEI0001TableAdapters.GetMadeSeikyuGakuTableAdapter,
            connection As New System.Data.SqlClient.SqlConnection(connectionString)
            adp.Connection = connection : CommonUtility.DBUtility.SetCommandTimeout(adp)
            adp.Fill(resultDataSet, jyutyuNo, Key_SeikyuDate)
        End Using
        Return resultDataSet
    End Function

    ''' <summary>
    ''' 請求明細トランの取得
    ''' </summary>
    ''' <param name="seikyuNo">請求Ｎｏ</param>
    ''' <param name="seikyuEdaban">請求枝番</param>
    ''' <remarks></remarks>
    Public Function ReadT_SEIKYU_MEISAI(ByVal seikyuNo As Decimal, ByVal seikyuEdaban As Decimal) As dsSEI0001.T_SEIKYU_MEISAIDataTable
        Dim logic As New BLL.Common.ExecuteQuery
        Dim strSQL As String

        strSQL = vbNullString
        strSQL += " select"
        strSQL += "    KAMOKU_HINMOKU"
        strSQL += "  , HINSITU_KIKAKU_SIYO"
        strSQL += "  , TANI"
        strSQL += "  , JYUTYUSUU"
        strSQL += "  , JYUTYUSUU_HENKO"
        strSQL += "  , JYUTYUTANKA"
        strSQL += "  , JYUTYUGAKU"
        strSQL += "  , JYUTYUGAKU_HENKO"
        strSQL += "  , SEIKYUSUU_ZENKAI"
        strSQL += "  , SEIKYUGAKU_ZENKAI"
        strSQL += "  , SEIKYUSUU_KONKAI"
        strSQL += "  , SEIKYUGAKU_KONKAI"
        strSQL += "  , SEIKYUSUU_RUIKEI"
        strSQL += "  , SEIKYUGAKU_RUIKEI"
        strSQL += "  , KAISOCODE"
        strSQL += "  , KAISOCODE_ZENKAI"
        strSQL += "  , DELETE_FLG"
        strSQL += "  , JYUTYUEDABAN"
        strSQL += "  , JYUTYUEDABAN_DAIKAMOKU"
        strSQL += "  , KAISOCODE_DAIKAMOKU"
        strSQL += "  , KAMOKU_HINMOKU_DAIKAMOKU"
        strSQL += "  , str(JYUTYUEDABAN_DAIKAMOKU) + ' ' + KAISOCODE_DAIKAMOKU as GROUP_HEADER"
        strSQL += " from T_SEIKYU_MEISAI"
        strSQL += " where SEIKYUNO     = @SEIKYUNO"
        strSQL += " and   SEIKYUEDABAN = @SEIKYUEDABAN"
        strSQL += " order by KAISOCODE"

        Dim param = New SqlParameter() {
            New SqlParameter("@SEIKYUNO", seikyuNo),
            New SqlParameter("@SEIKYUEDABAN", seikyuEdaban)
            }

        Dim dt = logic.ExecuteDataset(connectionString, CommandType.Text, strSQL, param).Tables(0)

        '調整額の編集
        Dim dtResult = ConvertDataTableToT_SEIKYU_MEISAI(dt)
        Dim dr As dsSEI0001.T_SEIKYU_MEISAIRow = dtResult.Select("KAISOCODE = '0'")(0)
        dr.SEIKYU_FLG = False
        dr.JYUTYUSUU = ""
        dr.JYUTYUTANKA = ""
        dr.JYUTYUGAKU = ""
        dr.JYUTYUSUU_HENKO = ""
        dr.JYUTYUGAKU_HENKO = ""
        dr.SEIKYUSUU_ZENKAI = ""
        dr.SEIKYUGAKU_ZENKAI = ""
        dr.SEIKYUSUU_KONKAI = ""
        dr.SEIKYUSUU_RUIKEI = ""
        dr.GROUP_HEADER = ""

        Return dtResult
    End Function

    ''' <summary>
    ''' 請求明細トランの取得（受注トランから取得）
    ''' </summary>
    ''' <param name="seikyuNo">請求Ｎｏ</param>
    ''' <param name="seikyuEdaban">請求枝番</param>
    ''' <param name="jyutyuEdaban">受注枝番</param>
    ''' <param name="jyutyuEdaban_seikyu">受注枝番（請求情報）</param>
    ''' <remarks></remarks>
    Public Function ReadT_SEIKYU_MEISAI_JYUTYU(ByVal seikyuNo As Decimal, ByVal seikyuEdaban As Decimal, ByVal jyutyuEdaban As Decimal, ByVal jyutyuEdaban_seikyu As Decimal) As dsSEI0001.T_SEIKYU_MEISAIDataTable
        Dim logic As New BLL.Common.ExecuteQuery
        Dim strSQL = ""
        Dim strSQL_select = ""

        '今の受注と階層を紐づける（以下は生成後のSQLの例）
        '請求情報の階層コードから最新の受注情報の階層コードを紐づける
        '例えば、階層コードを「001→002→003」と変更した場合、請求情報の階層コードを「001→003」に変換する。
        'Select
        '    isnull(KAI.JYUTYUEDABAN        , JYU.KAI_JYUTYUEDABAN) JYUTYUEDABAN
        '  , isnull(KAI.KAI_KAISOCODE       , JYU.KAISOCODE       ) KAI_KAISOCODE
        '  , isnull(KAI.KAI_KAISOCODE_ZENKAI, JYU.KAISOCODE_ZENKAI) KAI_KAISOCODE_ZENKAI
        '  , JYU.KAISOCODE
        '  , JYU.KAISOCODE_ZENKAI
        'From T_JYUTYU JYU
        'Left outer join (
        '  Select Case
        '      isnull(KAI.JYUTYUEDABAN        , JYU.KAI_JYUTYUEDABAN) JYUTYUEDABAN
        '    , isnull(KAI.KAI_KAISOCODE       , JYU.KAISOCODE       ) KAI_KAISOCODE
        '    , isnull(KAI.KAI_KAISOCODE_ZENKAI, JYU.KAISOCODE_ZENKAI) KAI_KAISOCODE_ZENKAI
        '    , JYU.KAISOCODE
        '    , JYU.KAISOCODE_ZENKAI
        '  From T_JYUTYU JYU
        '  Left outer join (
        '    Select Case
        '        isnull(KAI.JYUTYUEDABAN        , KAI_JYU.JYUTYUEDABAN) JYUTYUEDABAN
        '      , isnull(KAI.KAI_KAISOCODE       , JYU.KAISOCODE       ) KAI_KAISOCODE
        '      , isnull(KAI.KAI_KAISOCODE_ZENKAI, JYU.KAISOCODE_ZENKAI) KAI_KAISOCODE_ZENKAI
        '      , JYU.KAISOCODE
        '      , JYU.KAISOCODE_ZENKAI
        '    From T_JYUTYU JYU
        '    Left outer join (Select null As JYUTYUEDABAN, null As KAI_KAISOCODE, null As KAI_KAISOCODE_ZENKAI, null As KAISOCODE, null as KAISOCODE_ZENKAI) KAI
        '      On JYU.KAISOCODE = KAI.KAISOCODE_ZENKAI
        '    where JYU.JYUTYUNO     = 300
        '    And   JYU.JYUTYUEDABAN = 2
        '    And   JYU.DELETE_FLG   = 0
        '    ) KAI
        '    On JYU.KAISOCODE = KAI.KAISOCODE_ZENKAI
        '  where JYU.JYUTYUNO         = 300
        '  And   JYU.JYUTYUEDABAN     = 1
        '  And   JYU.DELETE_FLG       = 0
        '  ) KAI
        '  On JYU.KAISOCODE = KAI.KAISOCODE_ZENKAI
        'where JYU.JYUTYUNO         = 300
        'And   JYU.JYUTYUEDABAN     = 0
        'And   JYU.DELETE_FLG       = 0

        'select句、from句の定義
        strSQL_select += "     select"
        strSQL_select += "         isnull(KAI.KAI_JYUTYUEDABAN    , JYU.JYUTYUEDABAN    ) KAI_JYUTYUEDABAN"
        strSQL_select += "       , isnull(KAI.KAI_KAISOCODE       , JYU.KAISOCODE       ) KAI_KAISOCODE"
        strSQL_select += "       , isnull(KAI.KAI_KAISOCODE_ZENKAI, JYU.KAISOCODE_ZENKAI) KAI_KAISOCODE_ZENKAI"
        strSQL_select += "       , JYU.KAISOCODE"
        strSQL_select += "       , JYU.KAISOCODE_ZENKAI"
        strSQL_select += "     from T_JYUTYU JYU"

        'where句の定義
        Dim strSQL_where = ""
        strSQL_where += "     where JYU.JYUTYUNO         = @SEIKYUNO"
        strSQL_where += "     and   JYU.DELETE_FLG       = 0"
        strSQL_where += "     and   JYU.JYUTYUEDABAN     = "

        strSQL += " with KAI as ("
        strSQL += strSQL_select

        '受注情報の受注枝番から請求情報の受注枝番＋１分の繰り返し
        For edaban = jyutyuEdaban To jyutyuEdaban_seikyu + 1 Step -1
            strSQL += "  left outer join ("
            strSQL += strSQL_select
        Next

        strSQL += "     left outer join (select null as KAI_JYUTYUEDABAN, null as KAI_KAISOCODE, null as KAI_KAISOCODE_ZENKAI, null as KAISOCODE, null as KAISOCODE_ZENKAI) KAI"

        '受注情報の受注枝番から請求情報の受注枝番＋１分の繰り返し
        For edaban = jyutyuEdaban To jyutyuEdaban_seikyu + 1 Step -1
            '受注情報の前後を紐づける
            strSQL += "  on JYU.KAISOCODE = KAI.KAISOCODE_ZENKAI"
            '条件の追加（取得する受注情報の枝番を付加する）
            strSQL += strSQL_where + CStr(edaban)
            strSQL += "  ) KAI"
        Next

        '受注情報の前後を紐づける
        strSQL += "       on JYU.KAISOCODE = KAI.KAISOCODE_ZENKAI"
        '条件の追加（取得する受注情報の枝番を付加する）
        strSQL += strSQL_where + CStr(jyutyuEdaban_seikyu)

        strSQL += " )"
        strSQL += " , SEI as ("
        strSQL += "     select"
        strSQL += "         SEI.SEIKYUNO"
        strSQL += "       , KAI_DAIKAMOKU.KAI_JYUTYUEDABAN     as JYUTYUEDABAN_DAIKAMOKU"
        strSQL += "       , KAI_DAIKAMOKU.KAI_KAISOCODE        as KAISOCODE_DAIKAMOKU"
        strSQL += "       , KAI.KAI_JYUTYUEDABAN "
        strSQL += "       , KAI.KAI_KAISOCODE"
        strSQL += "       , KAI.KAI_KAISOCODE_ZENKAI"
        strSQL += "       , SEI.KAMOKU_HINMOKU"
        strSQL += "       , SEI.HINSITU_KIKAKU_SIYO"
        strSQL += "       , SEI.TANI"
        strSQL += "       , SEI.JYUTYUSUU"
        strSQL += "       , SEI.JYUTYUTANKA"
        strSQL += "       , SEI.JYUTYUGAKU"
        strSQL += "       , SEI.SEIKYUSUU_RUIKEI"
        strSQL += "       , SEI.SEIKYUGAKU_RUIKEI"
        strSQL += "     from T_SEIKYU_MEISAI SEI"

        '請求情報から最新の受注情報を階層コード、階層コード（前回）で紐づけする。
        strSQL += "     inner join KAI"
        strSQL += "       on KAI.KAISOCODE     = SEI.KAISOCODE"

        '請求情報から最新の受注情報を階層コード、階層コード（前回）で紐づけする。（１階層目の情報を取得）
        strSQL += "     inner join KAI KAI_DAIKAMOKU"
        strSQL += "       on KAI_DAIKAMOKU.KAISOCODE = left(SEI.KAISOCODE, 3)"

        strSQL += "     where SEI.SEIKYUNO     =  @SEIKYUNO"
        strSQL += "     and   SEI.SEIKYUEDABAN =  @SEIKYUEDABAN"
        strSQL += "     and   SEI.KAISOCODE    <> 0"                  '調整額は対象外
        strSQL += "     and   SEI.DELETE_FLG   =  0"
        strSQL += " )"

        'メインのＳＱＬ
        strSQL += " select"
        strSQL += "     MAIN.*"
        strSQL += "   , str(MAIN.JYUTYUEDABAN_DAIKAMOKU) + ' ' + MAIN.KAISOCODE_DAIKAMOKU as GROUP_HEADER"
        strSQL += "   , JYU.KAMOKU_HINMOKU                                                as KAMOKU_HINMOKU_DAIKAMOKU"
        strSQL += " from ("
        strSQL += "   select"
        strSQL += "       isnull(JYU.JYUTYUEDABAN       , SEI.JYUTYUEDABAN_DAIKAMOKU)                                                                      as JYUTYUEDABAN_DAIKAMOKU"
        strSQL += "     , isnull(JYU.KAISOCODE_DAIKAMOKU, SEI.KAISOCODE_DAIKAMOKU)                                                                         as KAISOCODE_DAIKAMOKU"
        strSQL += "     , isnull(JYU.JYUTYUEDABAN       , SEI.KAI_JYUTYUEDABAN)                                                                            as JYUTYUEDABAN"
        strSQL += "     , isnull(JYU.KAISOCODE          , SEI.KAI_KAISOCODE)                                                                               as KAISOCODE"
        strSQL += "     , isnull(JYU.KAISOCODE_ZENKAI   , SEI.KAI_KAISOCODE_ZENKAI)                                                                        as KAISOCODE_ZENKAI"
        strSQL += "     , isnull(JYU.KAMOKU_HINMOKU     , SEI.KAMOKU_HINMOKU)                                                                              as KAMOKU_HINMOKU"
        strSQL += "     , isnull(JYU.HINSITU_KIKAKU_SIYO, SEI.HINSITU_KIKAKU_SIYO)                                                                         as HINSITU_KIKAKU_SIYO"
        strSQL += "     , isnull(JYU.TANI               , SEI.TANI)                                                                                        as TANI"
        strSQL += "     , isnull(JYU.SUU                , 0)                                                                                               as JYUTYUSUU"
        strSQL += "     , isnull(JYU.JYUTYUTANKA        , SEI.JYUTYUTANKA)                                                                                 as JYUTYUTANKA"
        strSQL += "     , isnull(JYU.JYUTYUGAKU         , 0)                                                                                               as JYUTYUGAKU"
        strSQL += "     , isnull(SEI.SEIKYUSUU_RUIKEI   , 0)                                                                                               as SEIKYUSUU_ZENKAI"
        strSQL += "     , isnull(SEI.SEIKYUGAKU_RUIKEI  , 0)                                                                                               as SEIKYUGAKU_ZENKAI"
        strSQL += "     , case when SEI2.SEIKYUNO is null then 0                            else isnull(JYU.SUU       , 0) - isnull(SEI.JYUTYUSUU , 0) end as JYUTYUSUU_HENKO"
        strSQL += "     , case when SEI2.SEIKYUNO is null then 0                            else isnull(JYU.JYUTYUGAKU, 0) - isnull(SEI.JYUTYUGAKU, 0) end as JYUTYUGAKU_HENKO"
        strSQL += "     , case when JYU.JYUTYUNO is null  then SEI.SEIKYUSUU_RUIKEI  * (-1) else 0                                                     end as SEIKYUSUU_KONKAI"
        strSQL += "     , case when JYU.JYUTYUNO is null  then SEI.SEIKYUGAKU_RUIKEI * (-1) else 0                                                     end as SEIKYUGAKU_KONKAI"
        strSQL += "     , case when JYU.JYUTYUNO is null  then 0                            else isnull(SEI.SEIKYUSUU_RUIKEI , 0)                      end as SEIKYUSUU_RUIKEI"
        strSQL += "     , case when JYU.JYUTYUNO is null  then 0                            else isnull(SEI.SEIKYUGAKU_RUIKEI, 0)                      end as SEIKYUGAKU_RUIKEI"
        strSQL += "     , case when JYU.JYUTYUNO is null  then 1                            else 0                                                     end as DELETE_FLG"
        strSQL += "   from ("
        '受注情報の取得
        strSQL += "     select"
        strSQL += "         left(JYU.KAISOCODE, 3) as KAISOCODE_DAIKAMOKU"
        strSQL += "       , JYU.*"
        strSQL += "     from T_JYUTYU JYU"
        strSQL += "     where JYU.JYUTYUNO     = @SEIKYUNO"
        strSQL += "     and   JYU.JYUTYUEDABAN = @JYUTYUEDABAN"
        strSQL += "     and   JYU.DELETE_FLG   = 0"
        strSQL += "     and   not exists ("
        strSQL += "       select *"
        strSQL += "       from T_JYUTYU KAI"
        strSQL += "       where KAI.JYUTYUNO                            = JYU.JYUTYUNO"
        strSQL += "       and   KAI.JYUTYUEDABAN                        = JYU.JYUTYUEDABAN"
        strSQL += "       and   left(KAI.KAISOCODE, len(JYU.KAISOCODE)) = JYU.KAISOCODE"
        strSQL += "       and   len(KAI.KAISOCODE)                      > len(JYU.KAISOCODE)"
        strSQL += "       )"
        strSQL += "     ) JYU"
        '請求情報と結合（単価が異なる場合、結合しない）
        strSQL += "   full outer join SEI"
        strSQL += "     on  SEI.KAI_JYUTYUEDABAN = JYU.JYUTYUEDABAN"
        strSQL += "     and SEI.KAI_KAISOCODE    = JYU.KAISOCODE"
        strSQL += "     and SEI.JYUTYUTANKA      = JYU.JYUTYUTANKA"
        '請求情報と結合（単価が異なる場合、結合する）
        strSQL += "   left outer join SEI SEI2"
        strSQL += "     on  ( SEI2.KAI_JYUTYUEDABAN = JYU.JYUTYUEDABAN"
        strSQL += "       and SEI2.KAI_KAISOCODE    = JYU.KAISOCODE)"
        strSQL += "     or  ( SEI2.KAI_JYUTYUEDABAN = SEI.KAI_JYUTYUEDABAN"
        strSQL += "       and SEI2.KAI_KAISOCODE    = SEI.KAI_KAISOCODE)"
        strSQL += "   ) MAIN"
        strSQL += " inner join T_JYUTYU JYU"
        strSQL += "   on  JYU.JYUTYUNO     = @SEIKYUNO"
        strSQL += "   and JYU.JYUTYUEDABAN = MAIN.JYUTYUEDABAN_DAIKAMOKU"
        strSQL += "   and JYU.KAISOCODE    = MAIN.KAISOCODE_DAIKAMOKU"
        strSQL += " order by"
        strSQL += "     MAIN.KAISOCODE_DAIKAMOKU"
        strSQL += "   , MAIN.JYUTYUEDABAN_DAIKAMOKU"
        strSQL += "   , MAIN.KAISOCODE"
        strSQL += "   , MAIN.DELETE_FLG desc"

        Dim param = New SqlParameter() {
            New SqlParameter("@SEIKYUNO", seikyuNo),
            New SqlParameter("@SEIKYUEDABAN", seikyuEdaban),
            New SqlParameter("@JYUTYUEDABAN", jyutyuEdaban)
            }

        Dim dt = logic.ExecuteDataset(connectionString, CommandType.Text, strSQL, param).Tables(0)

        '調整額の追加

        Dim S_SCB = New S_SCBRead("請求登録画面", "調整額の初期値")
        Dim ds = S_SCB.GetS_SCB

        Dim tyouseigakuName = "調整額"
        If ds.Tables(0).Rows.Count <> 0 Then
            tyouseigakuName = ds.Tables(0).Rows(0).Item("DATA").ToString
        End If

        Dim dtResult = ConvertDataTableToT_SEIKYU_MEISAI(dt)
        Dim dr = CType(dtResult.NewRow, dsSEI0001.T_SEIKYU_MEISAIRow)
        dr.SEIKYU_FLG = False
        dr.KAMOKU_HINMOKU = tyouseigakuName
        dr.HINSITU_KIKAKU_SIYO = ""
        dr.TANI = ""
        dr.JYUTYUSUU = ""
        dr.JYUTYUTANKA = ""
        dr.JYUTYUGAKU = ""
        dr.JYUTYUSUU_HENKO = ""
        dr.JYUTYUGAKU_HENKO = ""
        dr.SEIKYUSUU_ZENKAI = ""
        dr.SEIKYUGAKU_ZENKAI = ""
        dr.SEIKYUSUU_KONKAI = ""
        dr.SEIKYUGAKU_KONKAI = "0"
        dr.SEIKYUSUU_RUIKEI = ""
        dr.SEIKYUGAKU_RUIKEI = "0"
        dr.KAISOCODE = "0"
        dr.KAISOCODE_ZENKAI = "0"
        dr.DELETE_FLG = "0"
        dr.JYUTYUEDABAN = jyutyuEdaban
        dr.JYUTYUEDABAN_DAIKAMOKU = jyutyuEdaban
        dr.KAISOCODE_DAIKAMOKU = "0"
        dr.KAMOKU_HINMOKU_DAIKAMOKU = ""
        dr.GROUP_HEADER = ""
        dtResult.Rows.InsertAt(dr, 0)

        Return dtResult
    End Function

    Private Function ConvertDataTableToT_SEIKYU_MEISAI(ByVal dt As DataTable) As dsSEI0001.T_SEIKYU_MEISAIDataTable

        Dim dtResult As New dsSEI0001.T_SEIKYU_MEISAIDataTable

        For Each row As DataRow In dt.Rows
            Dim dr = CType(dtResult.NewRow, dsSEI0001.T_SEIKYU_MEISAIRow)
            dr.JYUTYUEDABAN = row.Item("JYUTYUEDABAN").ToString
            dr.KAMOKU_HINMOKU = row.Item("KAMOKU_HINMOKU").ToString
            dr.HINSITU_KIKAKU_SIYO = row.Item("HINSITU_KIKAKU_SIYO").ToString
            dr.TANI = row.Item("TANI").ToString
            dr.JYUTYUSUU = row.Item("JYUTYUSUU").ToString
            dr.JYUTYUSUU_HENKO = row.Item("JYUTYUSUU_HENKO").ToString
            dr.JYUTYUTANKA = row.Item("JYUTYUTANKA").ToString
            dr.JYUTYUGAKU = row.Item("JYUTYUGAKU").ToString
            dr.JYUTYUGAKU_HENKO = row.Item("JYUTYUGAKU_HENKO").ToString
            dr.SEIKYUSUU_ZENKAI = row.Item("SEIKYUSUU_ZENKAI").ToString
            dr.SEIKYUGAKU_ZENKAI = row.Item("SEIKYUGAKU_ZENKAI").ToString
            dr.SEIKYUSUU_KONKAI = row.Item("SEIKYUSUU_KONKAI").ToString
            dr.SEIKYUGAKU_KONKAI = row.Item("SEIKYUGAKU_KONKAI").ToString
            dr.SEIKYUSUU_RUIKEI = row.Item("SEIKYUSUU_RUIKEI").ToString
            dr.SEIKYUGAKU_RUIKEI = row.Item("SEIKYUGAKU_RUIKEI").ToString
            dr.KAISOCODE = row.Item("KAISOCODE").ToString
            dr.KAISOCODE_ZENKAI = row.Item("KAISOCODE_ZENKAI").ToString
            dr.DELETE_FLG = row.Item("DELETE_FLG").ToString
            dr.JYUTYUEDABAN = row.Item("JYUTYUEDABAN").ToString
            dr.JYUTYUEDABAN_DAIKAMOKU = row.Item("JYUTYUEDABAN_DAIKAMOKU").ToString
            dr.KAISOCODE_DAIKAMOKU = row.Item("KAISOCODE_DAIKAMOKU").ToString
            dr.KAMOKU_HINMOKU_DAIKAMOKU = row.Item("KAMOKU_HINMOKU_DAIKAMOKU").ToString
            dr.GROUP_HEADER = row.Item("GROUP_HEADER").ToString
            dr.SEIKYU_FLG = IIf(dr.DELETE_FLG = "1", False, IIf(CDec(dr.JYUTYUGAKU) <= CDec(dr.SEIKYUGAKU_RUIKEI), True, False))
            dtResult.Rows.Add(dr)
        Next

        Return dtResult
    End Function

    '請求伝票削除
    Public Sub Delete(ByVal Key_SeikyuNo As Decimal, ByVal Key_SeikyuEdaban As Decimal, ByVal Key_SeikyuDate As Date)
        Dim connection As SqlConnection = New SqlConnection(connectionString)
        Dim logic As New BLL.Common.ExecuteQuery
        Dim strSQL As String = ""

        Using ts As System.Transactions.TransactionScope = New System.Transactions.TransactionScope

            Delete(connection, Key_SeikyuNo, Key_SeikyuEdaban, Key_SeikyuDate)

            ts.Complete()

        End Using

    End Sub

    'トランザクション済みコネクションを渡す
    Private Sub Delete(ByRef conn As SqlConnection, ByVal Key_SeikyuNo As Decimal, ByVal Key_SeikyuEdaban As Decimal, ByVal Key_SeikyuDate As Date)
        Dim logic As New BLL.Common.ExecuteQuery
        Dim strSQL As String = ""

        '受注ヘッダトラン更新
        strSQL = " update T_JYUTYUHED set " + Environment.NewLine
        strSQL += " LAST_SEIKYUNO = (case when convert(varchar,LAST_SEIKYUDATE,112) >= convert(varchar,@SEIKYUDATE, 112) then LAST_SEIKYUNO else @SEIKYUNO end),"
        strSQL += " LAST_SEIKYUDATE = (case when convert(varchar,LAST_SEIKYUDATE,112) >= convert(varchar,@SEIKYUDATE, 112) then LAST_SEIKYUDATE else @SEIKYUDATE end), "
        strSQL += " SUMI_SEIKYUGAKU = (SUMI_SEIKYUGAKU - STRN.SEIKYUGAKU), " + Environment.NewLine
        strSQL += " STATUS_SEIKYU = (case when (SUMI_SEIKYUGAKU - STRN.SEIKYUGAKU) = 0 then 0 " + Environment.NewLine
        strSQL += " 		  when (GKJYUTYUGAKU > (SUMI_SEIKYUGAKU - STRN.SEIKYUGAKU)) then 1 " + Environment.NewLine
        strSQL += " 		  else 2 end) " + Environment.NewLine
        strSQL += " from T_JYUTYUHED JHED " + Environment.NewLine
        strSQL += " inner join (select * from T_SEIKYU where SEIKYUNO = @SEIKYUNO) STRN on JHED.JYUTYUNO = STRN.JYUTYUNO "

        logic.ExecuteNonQuery(
                  conn _
                , CommandType.Text _
                , strSQL _
                , New SqlClient.SqlParameter() {
                    New SqlClient.SqlParameter("@SEIKYUNO", Key_SeikyuNo),
                    New SqlClient.SqlParameter("@SEIKYUEDABAN", Key_SeikyuEdaban),
                    New SqlClient.SqlParameter("@SEIKYUDATE", Key_SeikyuDate)})

        '請求トラン削除
        strSQL = "  delete from T_SEIKYUHED     where SEIKYUNO=@SEIKYUNO and SEIKYUEDABAN = @SEIKYUEDABAN " + Environment.NewLine
        strSQL += " delete from T_SEIKYU        where SEIKYUNO=@SEIKYUNO and SEIKYUEDABAN = @SEIKYUEDABAN " + Environment.NewLine
        strSQL += " delete from T_SEIKYU_MEISAI where SEIKYUNO=@SEIKYUNO and SEIKYUEDABAN = @SEIKYUEDABAN "

        logic.ExecuteNonQuery(
                  conn _
                , CommandType.Text _
                , strSQL _
                , New SqlClient.SqlParameter() {
                    New SqlClient.SqlParameter("@SEIKYUNO", Key_SeikyuNo),
                    New SqlClient.SqlParameter("@SEIKYUEDABAN", Key_SeikyuEdaban)})

    End Sub

    '登録処理
    Public Function Entry(ByRef f As frmSEI0001, ByVal updateFlg As Boolean) As Boolean
        Dim connection As SqlConnection = New SqlConnection(connectionString)
        Dim logic As New BLL.Common.ExecuteQuery

        Using ts As System.Transactions.TransactionScope = New System.Transactions.TransactionScope

            If updateFlg Then
                '訂正処理の場合、削除処理実施後に登録を行う
                Delete(connection, f.訂正前請求ヘッダ.SEIKYUNO, f.訂正前請求ヘッダ.SEIKYUEDABAN, f.訂正前請求ヘッダ.SEIKYUDATE)
            End If

            '請求ヘッダトラン更新
            UpdateSeikyuHeader(connection, f)

            '請求トラン更新
            UpdateSeikyuTran(connection, f)

            If f.rdoSeikyuHouhou_1.Checked Then
                '請求明細トラン更新
                UpdateSeikyuMeisaiTran(connection, f)
            End If

            '受注ヘッダトラン更新
            UpdateJyutyuHeader(connection, f.txtSeikyuNo.Text, Date.Parse(f.txtSeikyuDate.Text))

            ts.Complete()
        End Using

        Return True

    End Function

    '請求ヘッダ更新
    Private Sub UpdateSeikyuHeader(ByRef conn As SqlConnection, ByVal f As frmSEI0001)

        Dim logic As New BLL.Common.ExecuteQuery
        Dim strSQL As String = ""

        strSQL = " insert into T_SEIKYUHED ( "
        strSQL += " SEIKYUNO, "
        strSQL += " SEIKYUEDABAN, "
        strSQL += " JYUTYUEDABAN, "
        strSQL += " SURYO_SYOSUIKAKETA, "
        strSQL += " SEIKYUDATE, "
        strSQL += " SEIKYUMETHOD, "
        strSQL += " TOKUICODE, "
        strSQL += " INP_TANTOCODE, "
        strSQL += " KEISYOUCODE, "
        strSQL += " GKSEIKYUGAKU, "
        strSQL += " KONJYURYOKINGAKU, "
        strSQL += " D_BIKO, "
        strSQL += " KIGYOKBN, "
        strSQL += " SYORIKBN, "
        strSQL += " SYORISTDATE, "
        strSQL += " UPDATEPGID, "
        strSQL += " UPDATEUSERCODE "
        strSQL += " ) values ( "
        strSQL += " @SEIKYUNO, "
        strSQL += " @SEIKYUEDABAN, "
        strSQL += " @JYUTYUEDABAN, "
        strSQL += " @SURYO_SYOSUIKAKETA, "
        strSQL += " @SEIKYUDATE, "
        strSQL += " @SEIKYUMETHOD, "
        strSQL += " @TOKUICODE, "
        strSQL += " @INP_TANTOCODE, "
        strSQL += " @KEISYOUCODE, "
        strSQL += " @GKSEIKYUGAKU, "
        strSQL += " @KONJYURYOKINGAKU, "
        strSQL += " @D_BIKO, "
        strSQL += " @KIGYOKBN, "
        strSQL += " @SYORIKBN, "
        strSQL += " getdate(), "
        strSQL += " @UPDATEPGID, "
        strSQL += " @UPDATEUSERCODE ) "

        logic.ExecuteNonQuery(
              conn _
            , CommandType.Text _
            , strSQL _
            , New SqlClient.SqlParameter() {
                New SqlClient.SqlParameter("@SEIKYUNO", f.txtSeikyuNo.Text),
                New SqlClient.SqlParameter("@SEIKYUEDABAN", f.txtSeikyuEdaban.Text),
                New SqlClient.SqlParameter("@JYUTYUEDABAN", f.txtJyutyuEdaban.Text),
                New SqlClient.SqlParameter("@SURYO_SYOSUIKAKETA", f.txtSURYO_SYOSUIKAKETA.Text),
                New SqlClient.SqlParameter("@SEIKYUDATE", Date.Parse(f.txtSeikyuDate.Text)),
                New SqlClient.SqlParameter("@SEIKYUMETHOD", IIf(f.rdoSeikyuHouhou_0.Checked, 1, 2)),
                New SqlClient.SqlParameter("@TOKUICODE", f.txtKokyakuCode.Text),
                New SqlClient.SqlParameter("@INP_TANTOCODE", f.GetLoginTantoCode),
                New SqlClient.SqlParameter("@KEISYOUCODE", f.txtKeisyo.Text),
                New SqlClient.SqlParameter("@GKSEIKYUGAKU", f.ReplaceCalcString(f.MainData.Rows(0)(frmSEI0001.FLD_今回請求額))),
                New SqlClient.SqlParameter("@KONJYURYOKINGAKU", Decimal.Parse(f.txtKonMadeJyuryoGaku.Value)),
                New SqlClient.SqlParameter("@D_BIKO", Utility.LeftBSA(f.txtBiko.Text, 200)),
                New SqlClient.SqlParameter("@KIGYOKBN", Decimal.Parse(0)),
                New SqlClient.SqlParameter("@SYORIKBN", 0),
                New SqlClient.SqlParameter("@UPDATEPGID", f.PROGRAM_ID),
                New SqlClient.SqlParameter("@UPDATEUSERCODE", f.TANTO_CODE)})

    End Sub

    '請求トラン更新
    Private Sub UpdateSeikyuTran(ByRef conn As SqlConnection, ByVal f As frmSEI0001)

        Dim dt As New dsSEI0001.T_SEIKYUDataTable
        Dim dr As dsSEI0001.T_SEIKYURow

        dr = dt.NewRow

        dr.SEIKYUNO = f.txtSeikyuNo.Text
        dr.SEIKYUEDABAN = f.txtSeikyuEdaban.Text
        dr.GYONO = 1
        dr.SEIKYUDATE = Date.Parse(f.txtSeikyuDate.Text)
        dr.JYUTYUNO = f.txtSeikyuNo.Text
        dr.SEIKYUGAKU = Utility.NZ(f.MainData.Rows(0)(frmSEI0001.FLD_今回請求額))
        dr.DEKIDAKARITU = Utility.NZ(f.MainData.Rows(0)(frmSEI0001.FLD_出来高))
        dr.G_BIKO = ""
        dr.UPDATEMENT = Now
        dr.UPDATEPGID = f.PROGRAM_ID
        dr.UPDATEUSERCODE = f.TANTO_CODE
        dr("CDATE") = f.GetServerDate
        dr.UDATE = f.GetServerDate

        dt.Rows.Add(dr)

        conn.Open()

        'バルクコピー
        Using bc As New SqlBulkCopy(conn)
            With bc
                ''コピー先テーブル名を指定
                .DestinationTableName = "T_SEIKYU"
                ''データテーブルをコピー先へ書き込み
                .WriteToServer(dt)
            End With
        End Using

        conn.Close()

    End Sub

    '請求トラン更新
    Private Sub UpdateSeikyuMeisaiTran(ByRef conn As SqlConnection, ByVal f As frmSEI0001)
        Dim strSQL As String
        Dim executeLogic As New BLL.Common.ExecuteQuery
        Dim param As SqlParameter()

        conn.Open()

        For Each row As dsSEI0001.T_SEIKYU_MEISAIRow In f.dtT_SEIKYU_MEISAI.Rows
            '調整額は数値に空白を保持しているので、「0」に書き換える
            If row.JYUTYUSUU = "" Then row.JYUTYUSUU = 0
            If row.JYUTYUTANKA = "" Then row.JYUTYUTANKA = 0
            If row.JYUTYUGAKU = "" Then row.JYUTYUGAKU = 0
            If row.JYUTYUSUU_HENKO = "" Then row.JYUTYUSUU_HENKO = 0
            If row.JYUTYUGAKU_HENKO = "" Then row.JYUTYUGAKU_HENKO = 0
            If row.SEIKYUSUU_ZENKAI = "" Then row.SEIKYUSUU_ZENKAI = 0
            If row.SEIKYUGAKU_ZENKAI = "" Then row.SEIKYUGAKU_ZENKAI = 0
            If row.SEIKYUSUU_KONKAI = "" Then row.SEIKYUSUU_KONKAI = 0
            If row.SEIKYUSUU_RUIKEI = "" Then row.SEIKYUSUU_RUIKEI = 0

            param = New SqlParameter() {
                New SqlParameter("@SEIKYUNO", f.txtSeikyuNo.Text),
                New SqlParameter("@SEIKYUEDABAN", f.txtSeikyuEdaban.Text),
                New SqlParameter("@JYUTYUEDABAN", row.JYUTYUEDABAN),
                New SqlParameter("@KAISOCODE", row.KAISOCODE),
                New SqlParameter("@DELETE_FLG", row.DELETE_FLG),
                New SqlParameter("@KAISOCODE_ZENKAI", row.KAISOCODE_ZENKAI),
                New SqlParameter("@JYUTYUEDABAN_DAIKAMOKU", row.JYUTYUEDABAN_DAIKAMOKU),
                New SqlParameter("@KAISOCODE_DAIKAMOKU", row.KAISOCODE_DAIKAMOKU),
                New SqlParameter("@KAMOKU_HINMOKU_DAIKAMOKU", row.KAMOKU_HINMOKU_DAIKAMOKU),
                New SqlParameter("@KAMOKU_HINMOKU", row.KAMOKU_HINMOKU),
                New SqlParameter("@HINSITU_KIKAKU_SIYO", row.HINSITU_KIKAKU_SIYO),
                New SqlParameter("@TANI", row.TANI),
                New SqlParameter("@JYUTYUSUU", row.JYUTYUSUU),
                New SqlParameter("@JYUTYUTANKA", row.JYUTYUTANKA),
                New SqlParameter("@JYUTYUGAKU", row.JYUTYUGAKU),
                New SqlParameter("@JYUTYUSUU_HENKO", row.JYUTYUSUU_HENKO),
                New SqlParameter("@JYUTYUGAKU_HENKO", row.JYUTYUGAKU_HENKO),
                New SqlParameter("@SEIKYUSUU_ZENKAI", row.SEIKYUSUU_ZENKAI),
                New SqlParameter("@SEIKYUGAKU_ZENKAI", row.SEIKYUGAKU_ZENKAI),
                New SqlParameter("@SEIKYUSUU_KONKAI", row.SEIKYUSUU_KONKAI),
                New SqlParameter("@SEIKYUGAKU_KONKAI", row.SEIKYUGAKU_KONKAI),
                New SqlParameter("@SEIKYUSUU_RUIKEI", row.SEIKYUSUU_RUIKEI),
                New SqlParameter("@SEIKYUGAKU_RUIKEI", row.SEIKYUGAKU_RUIKEI),
                New SqlParameter("@UPDATEPGID", f.PROGRAM_ID),
                New SqlParameter("@UPDATEUSERCODE", f.TANTO_CODE)}

            strSQL = ""
            strSQL += "insert into T_SEIKYU_MEISAI values ("
            strSQL += "    @SEIKYUNO"
            strSQL += "  , @SEIKYUEDABAN"
            strSQL += "  , @JYUTYUEDABAN"
            strSQL += "  , @KAISOCODE"
            strSQL += "  , @DELETE_FLG"
            strSQL += "  , @KAISOCODE_ZENKAI"
            strSQL += "  , @JYUTYUEDABAN_DAIKAMOKU"
            strSQL += "  , @KAISOCODE_DAIKAMOKU"
            strSQL += "  , @KAMOKU_HINMOKU_DAIKAMOKU"
            strSQL += "  , @KAMOKU_HINMOKU"
            strSQL += "  , @HINSITU_KIKAKU_SIYO"
            strSQL += "  , @TANI"
            strSQL += "  , @JYUTYUSUU"
            strSQL += "  , @JYUTYUTANKA"
            strSQL += "  , @JYUTYUGAKU"
            strSQL += "  , @JYUTYUSUU_HENKO"
            strSQL += "  , @JYUTYUGAKU_HENKO"
            strSQL += "  , @SEIKYUSUU_ZENKAI"
            strSQL += "  , @SEIKYUGAKU_ZENKAI"
            strSQL += "  , @SEIKYUSUU_KONKAI"
            strSQL += "  , @SEIKYUGAKU_KONKAI"
            strSQL += "  , @SEIKYUSUU_RUIKEI"
            strSQL += "  , @SEIKYUGAKU_RUIKEI"
            strSQL += "  , getdate()"
            strSQL += "  , @UPDATEPGID"
            strSQL += "  , @UPDATEUSERCODE"
            strSQL += "  , getdate()"
            strSQL += "  , getdate()"
            strSQL += "  )"

            executeLogic.ExecuteNonQuery(conn, Data.CommandType.Text, strSQL, param)
        Next

        conn.Close()
    End Sub

    'トランザクション済みコネクションを渡す
    Private Sub UpdateJyutyuHeader(ByRef conn As SqlConnection, ByVal Key_SeikyuNo As Decimal, ByVal Key_SeikyuDate As Date)
        Dim logic As New BLL.Common.ExecuteQuery
        Dim strSQL As String = ""

        '受注ヘッダトラン更新
        strSQL = " update T_JYUTYUHED set " + Environment.NewLine
        strSQL += " LAST_SEIKYUNO = (case when convert(varchar,LAST_SEIKYUDATE,112) >= convert(varchar,@SEIKYUDATE, 112) then LAST_SEIKYUNO else @SEIKYUNO end),"
        strSQL += " LAST_SEIKYUDATE = (case when convert(varchar,LAST_SEIKYUDATE,112) >= convert(varchar,@SEIKYUDATE, 112) then LAST_SEIKYUDATE else @SEIKYUDATE end), "
        strSQL += " SUMI_SEIKYUGAKU = (SUMI_SEIKYUGAKU + STRN.SEIKYUGAKU), " + Environment.NewLine
        strSQL += " STATUS_SEIKYU = (case when (SUMI_SEIKYUGAKU + STRN.SEIKYUGAKU) = 0 then 0 " + Environment.NewLine
        strSQL += " 		  when (GKJYUTYUGAKU > (SUMI_SEIKYUGAKU + STRN.SEIKYUGAKU)) then 1 " + Environment.NewLine
        strSQL += " 		  else 2 end) " + Environment.NewLine
        strSQL += " from T_JYUTYUHED JHED " + Environment.NewLine
        strSQL += " inner join (select * from T_SEIKYU where SEIKYUNO = @SEIKYUNO) STRN on JHED.JYUTYUNO = STRN.JYUTYUNO "
        logic.ExecuteNonQuery(conn, CommandType.Text, strSQL, New SqlClient.SqlParameter() {New SqlClient.SqlParameter("@SEIKYUNO", Key_SeikyuNo), _
                                                                                                  New SqlClient.SqlParameter("@SEIKYUDATE", Key_SeikyuDate)})
    End Sub


End Class
