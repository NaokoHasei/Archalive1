Imports System.Data.SqlClient

Public Class T_JYUTYURead

    Private connectionString As String

    ''' <summary>
    ''' クラス初期化
    ''' </summary>
    Public Sub New()
        connectionString = CommonUtility.DBUtility.GetConnectionString
    End Sub

    ''' <summary>
    ''' 受注枝番の最大取得
    ''' </summary>
    ''' <param name="jyutyuNo">受注Ｎｏ</param>
    ''' <remarks></remarks>
    Public Function fncSelectMAX_JYUTYUEDABAN(ByVal jyutyuNo As Decimal) As DataTable
        Dim logic As New BLL.Common.ExecuteQuery

        Return logic.ExecuteDataset(
              connectionString _
            , CommandType.Text _
            , "SELECT MAX(JYUTYUEDABAN) as JYUTYUEDABAN FROM T_JYUTYUHED WHERE JYUTYUNO = @JYUTYUNO" _
            , New SqlParameter("@JYUTYUNO", jyutyuNo)
            ).Tables(0)
    End Function

    ''' <summary>
    ''' 受注入力ヘッダデータオープン
    ''' </summary>
    ''' <param name="jyutyuNo">受注Ｎｏ</param>
    ''' <param name="jyutyuEdaban">受注枝番</param>
    ''' <param name="SerchKbn">1：PKで検索、2：受注Noで検索</param>
    ''' <remarks></remarks>
    Public Function fncSelectT_JYUTYUHED(ByVal jyutyuNo As Decimal) As DataTable
        Return fncSelectT_JYUTYUHED(jyutyuNo, 0, 2)
    End Function

    ''' <summary>
    ''' 受注入力ヘッダデータオープン
    ''' </summary>
    ''' <param name="jyutyuNo">受注Ｎｏ</param>
    ''' <param name="jyutyuEdaban">受注枝番</param>
    ''' <param name="SerchKbn">1：PKで検索、2：受注Noで検索</param>
    ''' <remarks></remarks>
    Public Function fncSelectT_JYUTYUHED(ByVal jyutyuNo As Decimal, ByVal jyutyuEdaban As Decimal, Optional ByVal SerchKbn As Integer = 1) As dsT_JYUTYU.T_JYUTYUHEDDataTable
        Dim logic As New BLL.Common.ExecuteQuery
        Dim strSQL As String

        strSQL = vbNullString
        strSQL += " SELECT"
        strSQL += "     convert(varchar,HED.SYORISTDATE,111)                                    AS SYORISTDATE"
        strSQL += "   , CAST(HED.JYUTYUNO AS VARCHAR)                                           AS JYUTYUNO"
        strSQL += "   , CAST(HED.JYUTYUEDABAN AS VARCHAR)                                       AS JYUTYUEDABAN"
        strSQL += "   , right(replicate('0',10) + convert(varchar,JYUTYUNO),10)"
        strSQL += "     + '-' + right(replicate('0', 2) + convert(varchar,JYUTYUEDABAN),2)      AS JYUTYUNO_EDABAN"
        strSQL += "   , convert(varchar,HED.JYUTYUDATE,111)                                     AS JYUTYUDATE"
        strSQL += "   , HED.TANTOCODE"
        strSQL += "   , MTA.TANTONAME"
        strSQL += "   , HED.TOKUICODE"
        strSQL += "   , MTO.TOKUINAME"
        strSQL += "   , convert(varchar,HED.NOUKI_START,111)                                    AS NOUKI_STA"
        strSQL += "   , convert(varchar,HED.NOUKI_END,111)                                      AS NOUKI_END"
        strSQL += "   , CAST(HED.MITUMORINO AS VARCHAR)                                         AS MITUMORINO"
        strSQL += "   , CAST(HED.MITUMORIEDABAN AS VARCHAR)                                     AS MITUMORIEDABAN"
        strSQL += "   , right(replicate('0',10) + convert(varchar,MITUMORINO),10)"
        strSQL += "     + '-' + right(replicate('0', 2) + convert(varchar,MITUMORIEDABAN),2)    AS MITUMORINO_EDABAN"
        strSQL += "   , CAST(HED.SAN_MITUMORINO AS VARCHAR)                                     AS SAN_MITUMORINO"
        strSQL += "   , CAST(HED.SAN_MITUMORIEDABAN AS VARCHAR)                                 AS SAN_MITUMORIEDABAN"
        strSQL += "   , HED.KEISYOUCODE"
        strSQL += "   , K04.KBNNAME                                                             AS KEISYOUNAME"
        strSQL += "   , HED.KOUJINAME"
        strSQL += "   , HED.KOUJINO"
        strSQL += "   , HED.KOUJIBASYO"
        strSQL += "   , HED.AITE_ORDERNO"
        strSQL += "   , HED.JIKKOYOSAN"
        strSQL += "   , HED.D_BIKO"
        strSQL += "   , HED.SURYO_SYOSUIKAKETA"
        strSQL += "   , HED.GKJYUTYUGAKU"
        strSQL += "   , HED.GKJYUTYUGAKU_NUKI"
        strSQL += "   , HED.GKTAX"
        strSQL += " FROM T_JYUTYUHED HED"
        strSQL += " LEFT JOIN M_TANTO MTA ON HED.TANTOCODE = MTA.TANTOCODE"
        strSQL += " LEFT JOIN M_TOKUI MTO ON HED.TOKUICODE = MTO.TOKUICODE"
        strSQL += " LEFT JOIN M_KBN K04 ON K04.SIYOUKBN = '04' AND HED.KEISYOUCODE = K04.KBN"
        strSQL += " WHERE HED.JYUTYUNO     = @JYUTYUNO"
        If SerchKbn <> 2 Then
            strSQL += " AND   HED.JYUTYUEDABAN = @JYUTYUEDABAN"
        End If
        strSQL += " ORDER BY HED.JYUTYUNO, HED.TOKUICODE"

        Dim param = New SqlParameter() {
            New SqlParameter("@JYUTYUNO", jyutyuNo),
            New SqlParameter("@JYUTYUEDABAN", jyutyuEdaban)
            }

        Dim dt = logic.ExecuteDataset(connectionString, CommandType.Text, strSQL, param).Tables(0)

        Dim dtResult As New dsT_JYUTYU.T_JYUTYUHEDDataTable

        For Each row As DataRow In dt.Rows
            Dim dr = CType(dtResult.NewRow, dsT_JYUTYU.T_JYUTYUHEDRow)
            dr.SYORISTDATE = row.Item("SYORISTDATE").ToString
            dr.JYUTYUNO = row.Item("JYUTYUNO").ToString
            dr.JYUTYUEDABAN = row.Item("JYUTYUEDABAN").ToString
            dr.JYUTYUNO_EDABAN = row.Item("JYUTYUNO_EDABAN").ToString
            dr.JYUTYUDATE = row.Item("JYUTYUDATE").ToString
            dr.TANTOCODE = row.Item("TANTOCODE").ToString
            dr.TANTONAME = row.Item("TANTONAME").ToString
            dr.TOKUICODE = row.Item("TOKUICODE").ToString
            dr.TOKUINAME = row.Item("TOKUINAME").ToString
            dr.NOUKI_STA = row.Item("NOUKI_STA").ToString
            dr.NOUKI_END = row.Item("NOUKI_END").ToString
            dr.MITUMORINO = row.Item("MITUMORINO").ToString
            dr.MITUMORIEDABAN = row.Item("MITUMORIEDABAN").ToString
            dr.MITUMORINO_EDABAN = row.Item("MITUMORINO_EDABAN").ToString
            dr.SAN_MITUMORINO = row.Item("SAN_MITUMORINO").ToString
            dr.SAN_MITUMORIEDABAN = row.Item("SAN_MITUMORIEDABAN").ToString
            dr.KEISYOUCODE = row.Item("KEISYOUCODE").ToString
            dr.KEISYOUNAME = row.Item("KEISYOUNAME").ToString
            dr.KOUJINAME = row.Item("KOUJINAME").ToString
            dr.KOUJINO = row.Item("KOUJINO").ToString
            dr.KOUJIBASYO = row.Item("KOUJIBASYO").ToString
            dr.AITE_ORDERNO = row.Item("AITE_ORDERNO").ToString
            dr.JIKKOYOSAN = row.Item("JIKKOYOSAN").ToString
            dr.D_BIKO = row.Item("D_BIKO").ToString
            dr.SURYO_SYOSUIKAKETA = row.Item("SURYO_SYOSUIKAKETA").ToString
            dr.GKJYUTYUGAKU = row.Item("GKJYUTYUGAKU").ToString
            dr.GKJYUTYUGAKU_NUKI = row.Item("GKJYUTYUGAKU_NUKI").ToString
            dr.GKTAX = row.Item("GKTAX").ToString
            dtResult.Rows.Add(dr)
        Next

        Return dtResult
    End Function

    ''' <summary>
    ''' 受注入力明細データオープン
    ''' </summary>
    ''' <param name="jyutyuNo">受注Ｎｏ</param>
    ''' <param name="jyutyuEdaban">受注枝番</param>
    ''' <remarks></remarks>
    Public Function fncSelectT_JYUTYU(ByVal jyutyuNo As Decimal, ByVal jyutyuEdaban As Decimal) As DataTable
        Dim logic As New BLL.Common.ExecuteQuery
        Dim strSQL As String

        strSQL = vbNullString
        strSQL += " SELECT"
        strSQL += "     MEI.KAISOCODE_ZENKAI"
        strSQL += "   , MEI.DELETE_FLG"
        strSQL += "   , MEI.KAMOKU_HINMOKU"
        strSQL += "   , MEI.HINSITU_KIKAKU_SIYO"
        strSQL += "   , MEI.SUU"
        strSQL += "   , ISNULL(MEI.TANI,'')         as TANI"
        strSQL += "   , MEI.JYUTYUTANKA             as TANKA"
        strSQL += "   , MEI.JYUTYUGAKU              as GAKU"
        strSQL += "   , MEI.JYUTYUGAKU_NUKI         as GAKU_NUKI"
        strSQL += "   , MEI.GENTANKA"
        strSQL += "   , MEI.GENKAGAKU"
        strSQL += "   , MEI.KAKERITU"
        strSQL += "   , MEI.G_BIKO"
        strSQL += "   , MEI.SIIRECODE"
        strSQL += "   , MSI.SIIRENAME"
        strSQL += "   , MEI.KAISOCODE"
        strSQL += "   , MEI.ARARIGAKU"
        strSQL += "   , MEI.IKATU_KAKERITU"
        strSQL += "   , MEI.DAIKAMOKUCODE"
        strSQL += "   , MEI.CYUKAMOKUCODE"
        strSQL += "   , MEI.SYOKAMOKUCODE"
        strSQL += " FROM T_JYUTYU MEI"
        strSQL += " LEFT JOIN M_SIIRE MSI ON MEI.SIIRECODE = MSI.SIIRECODE"
        strSQL += " WHERE MEI.JYUTYUNO     = @JYUTYUNO"
        strSQL += " AND   MEI.JYUTYUEDABAN = @JYUTYUEDABAN"
        strSQL += " ORDER BY MEI.KAISOCODE"

        Dim param = New SqlParameter() {
            New SqlParameter("@JYUTYUNO", jyutyuNo),
            New SqlParameter("@JYUTYUEDABAN", jyutyuEdaban)
            }

        Return logic.ExecuteDataset(connectionString, CommandType.Text, strSQL, param).Tables(0)
    End Function

End Class
