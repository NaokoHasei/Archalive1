Imports System.Data.SqlClient

Public Class T_MITUMORIRead

    Private connectionString As String

    ''' <summary>
    ''' クラス初期化
    ''' </summary>
    Public Sub New()
        connectionString = CommonUtility.DBUtility.GetConnectionString
    End Sub

    ''' <summary>
    ''' 見積入力ヘッダデータオープン
    ''' </summary>
    ''' <param name="decMitumoriNo">見積Ｎｏ</param>
    ''' <param name="decMitumoriEdaban">見積枝番</param>
    ''' <param name="SerchKbn">1：PKで検索、2：見積Noで検索</param>
    ''' <remarks></remarks>
    Public Function fncSelectT_MITUMORIHED(ByVal decMitumoriNo As Decimal) As DataTable
        Return fncSelectT_MITUMORIHED(decMitumoriNo, 0, 2)
    End Function

    ''' <summary>
    ''' 見積入力ヘッダデータオープン
    ''' </summary>
    ''' <param name="decMitumoriNo">見積Ｎｏ</param>
    ''' <param name="decMitumoriEdaban">見積枝番</param>
    ''' <param name="SerchKbn">1：PKで検索、2：見積Noで検索</param>
    ''' <remarks></remarks>
    Public Function fncSelectT_MITUMORIHED(ByVal decMitumoriNo As Decimal, ByVal decMitumoriEdaban As Decimal, Optional ByVal SerchKbn As Integer = 1) As DataTable
        Dim logic As New ExecuteQuery
        Dim strSQL As String
        Dim ds As DataSet

        strSQL = vbNullString
        strSQL += " SELECT"
        strSQL += "     CAST(HED.MITUMORINO AS VARCHAR)          AS MITUMORINO"
        strSQL += "   , CAST(HED.MITUMORIEDABAN AS VARCHAR)      AS MITUMORIEDABAN"
        strSQL += "   , CAST(HED.MITUMORIDATE AS VARCHAR)        AS TEISYUTUDATE"
        strSQL += "   , HED.TANTOCODE"
        strSQL += "   , MTA.TANTONAME"
        strSQL += "   , HED.TOKUICODE"
        strSQL += "   , MTO.TOKUINAME"
        strSQL += "   , CAST(HED.NOUKI_START AS VARCHAR)         AS NOUKI_STA"
        strSQL += "   , CAST(HED.NOUKI_END AS VARCHAR)           AS NOUKI_END"
        strSQL += "   , CAST(HED.OYA_MITUMORINO AS VARCHAR)      AS OYA_MITUMORINO"
        strSQL += "   , CAST(HED.OYA_MITUMORIEDABAN AS VARCHAR)  AS OYA_MITUMORIEDABAN"
        strSQL += "   , CAST(HED.SAI_MITUMORINO AS VARCHAR)      AS SAI_MITUMORINO"
        strSQL += "   , CAST(HED.SAI_MITUMORIEDABAN AS VARCHAR)  AS SAI_MITUMORIEDABAN"
        strSQL += "   , CAST(HED.SAN_MITUMORINO AS VARCHAR)      AS SAN_MITUMORINO"
        strSQL += "   , CAST(HED.SAN_MITUMORIEDABAN AS VARCHAR)  AS SAN_MITUMORIEDABAN"
        strSQL += "   , HED.KEISYOUCODE"
        strSQL += "   , K04.KBNNAME                              AS KEISYOUNAME"
        strSQL += "   , HED.KOUJINAME"
        strSQL += "   , HED.KOUJINO"
        strSQL += "   , HED.KOUJIBASYO"
        strSQL += "   , HED.YUKOKIGEN"
        strSQL += "   , HED.SIHARAIJYOKEN"
        strSQL += "   , HED.D_BIKO"
        strSQL += "   , HED.MITUMORI_JOUKEN"
        strSQL += "   , HED.MITUMORI_JOUKEN_FILE_NAME"
        strSQL += "   , HED.SURYO_SYOSUIKAKETA"
        strSQL += " FROM T_MITUMORIHED HED"
        strSQL += " LEFT JOIN M_TANTO MTA ON HED.TANTOCODE = MTA.TANTOCODE"
        strSQL += " LEFT JOIN M_TOKUI MTO ON HED.TOKUICODE = MTO.TOKUICODE"
        strSQL += " LEFT JOIN M_KBN K04 ON K04.SIYOUKBN = '04' AND HED.KEISYOUCODE = K04.KBN"
        strSQL += " WHERE HED.MITUMORINO = @MITUMORINO"
        If SerchKbn <> 2 Then
            strSQL += " AND   HED.MITUMORIEDABAN = @MITUMORIEDABAN"
        End If
        strSQL += " ORDER BY HED.MITUMORINO, HED.MITUMORIEDABAN, HED.TOKUICODE"

        ds = logic.ExecuteDataset(
              connectionString _
            , CommandType.Text _
            , strSQL _
            , New SqlParameter() {
                 New SqlParameter("@MITUMORINO", decMitumoriNo) _
                , New SqlParameter("@MITUMORIEDABAN", decMitumoriEdaban)})

        Return ds.Tables(0)

    End Function

    ''' <summary>
    ''' 見積入力明細データオープン
    ''' </summary>
    ''' <param name="decMitumoriNo">見積Ｎｏ</param>
    ''' <param name="decMitumoriEdaban">見積枝番</param>
    ''' <remarks></remarks>
    Public Function fncSelectT_MITUMORI(ByVal decMitumoriNo As Decimal, ByVal decMitumoriEdaban As Decimal) As DataTable
        Dim logic As New ExecuteQuery
        Dim strSQL As String

        strSQL = vbNullString
        strSQL += " SELECT"
        strSQL += "     0                            as KAISOCODE_ZENKAI"
        strSQL += "   , 0                            as DELETE_FLG"
        strSQL += "   , MEI.KAMOKU_HINMOKU"
        strSQL += "   , MEI.HINSITU_KIKAKU_SIYO"
        strSQL += "   , MEI.SUU"
        strSQL += "   , MEI.TANI"
        strSQL += "   , MEI.MITUMORITANKA            as TANKA"
        strSQL += "   , MEI.MITUMORIGAKU             as GAKU"
        strSQL += "   , MEI.MITUMORIGAKU_NUKI        as GAKU_NUKI"
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
        strSQL += " FROM T_MITUMORI MEI"
        strSQL += " LEFT JOIN M_SIIRE MSI ON MEI.SIIRECODE = MSI.SIIRECODE"
        strSQL += " WHERE MEI.MITUMORINO     = @MITUMORINO"
        strSQL += " AND   MEI.MITUMORIEDABAN = @MITUMORIEDABAN"
        strSQL += " ORDER BY MEI.KAISOCODE"

        Return logic.ExecuteDataset(
              connectionString _
            , CommandType.Text _
            , strSQL _
            , New SqlParameter() {
                  New SqlParameter("@MITUMORINO", decMitumoriNo) _
                , New SqlParameter("@MITUMORIEDABAN", decMitumoriEdaban)}
            ).Tables(0)
    End Function

End Class
