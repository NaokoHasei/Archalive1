Imports System.Data.SqlClient

Public Class T_HATYURead

    Private connectionString As String

    ''' <summary>
    ''' クラス初期化
    ''' </summary>
    Public Sub New()
        connectionString = CommonUtility.DBUtility.GetConnectionString
    End Sub

    ''' <summary>
    ''' 発注ヘッダデータオープン
    ''' </summary>
    ''' <param name="decHatyuNo">発注Ｎｏ</param>
    ''' <remarks></remarks>
    Public Function fncSelectT_HATYUHED(ByVal decHatyuNo As Decimal) As dsT_HATYU.T_HATYUHEDDataTable
        Dim logic As New BLL.Common.ExecuteQuery

        Return ConvaertDtToT_HATYUHED(
                logic.ExecuteDataset(
                  connectionString _
                , CommandType.Text _
                , "SELECT * FROM T_HATYUHED WHERE HATYUNO = @HATYUNO" _
                , New SqlParameter("@HATYUNO", decHatyuNo)
                ).Tables(0)
            )
    End Function

    ''' <summary>
    ''' 発注ヘッダの取得（受注枝番に該当するデータ）
    ''' </summary>
    ''' <param name="decHatyuNo">発注Ｎｏ</param>
    ''' <param name="decJyutyuEdaban">受注枝番</param>
    ''' <remarks></remarks>
    Public Function fncSelectT_HATYUHED_JYUTYUEDABAN(ByVal decHatyuNo As Decimal, ByVal decJyutyuEdaban As Decimal) As dsT_HATYU.T_HATYUHEDDataTable
        Dim logic As New BLL.Common.ExecuteQuery

        Return ConvaertDtToT_HATYUHED(
            logic.ExecuteDataset(
                  connectionString _
                , CommandType.Text _
                , "SELECT * FROM T_HATYUHED WHERE HATYUNO = @HATYUNO and JYUTYUEDABAN = @JYUTYUEDABAN" _
                , New SqlParameter() {New SqlParameter("@HATYUNO", decHatyuNo), New SqlParameter("@JYUTYUEDABAN", decJyutyuEdaban)}
                ).Tables(0)
            )
    End Function

    ''' <summary>
    ''' 発注ヘッダの取得（PK）
    ''' </summary>
    ''' <param name="decHatyuNo">発注Ｎｏ</param>
    ''' <param name="decJyutyuEdaban">受注枝番</param>
    ''' <param name="decJyutyuEdaban2">受注枝番2</param>
    ''' <remarks></remarks>
    Public Function fncSelectT_HATYUHED_PK(ByVal decHatyuNo As Decimal, ByVal decHatyuEdaban As Decimal, ByVal decHatyuEdaban2 As Decimal) As dsT_HATYU.T_HATYUHEDDataTable
        Dim logic As New BLL.Common.ExecuteQuery

        Return ConvaertDtToT_HATYUHED(
            logic.ExecuteDataset(
                  connectionString _
                , CommandType.Text _
                , "SELECT * FROM T_HATYUHED WHERE HATYUNO = @HATYUNO and HATYUEDABAN = @HATYUEDABAN1 and HATYUEDABAN2 = @HATYUEDABAN2" _
                , New SqlParameter() {
                      New SqlParameter("@HATYUNO", decHatyuNo) _
                    , New SqlParameter("@HATYUEDABAN1", decHatyuEdaban) _
                    , New SqlParameter("@HATYUEDABAN2", decHatyuEdaban2)}
                ).Tables(0)
            )
    End Function

    ''' <summary>
    ''' 最大の発注枝番の取得
    ''' </summary>
    ''' <param name="decHatyuNo">発注Ｎｏ</param>
    ''' <remarks></remarks>
    Public Function fncSelectMaxHattyuEdaban(ByVal decHatyuNo As Decimal) As DataTable
        Dim logic As New BLL.Common.ExecuteQuery

        Return logic.ExecuteDataset(
              connectionString _
            , CommandType.Text _
            , "SELECT max(HATYUEDABAN) HATYUEDABAN FROM T_HATYUHED WHERE HATYUNO = @HATYUNO" _
            , New SqlParameter("@HATYUNO", decHatyuNo)
            ).Tables(0)
    End Function

    ''' <summary>
    ''' 最大の発注枝番２の取得
    ''' </summary>
    ''' <param name="decHatyuNo">発注Ｎｏ</param>
    ''' <param name="decHatyuEdaban">発注枝番</param>
    ''' <remarks></remarks>
    Public Function fncSelectMaxHattyuEdaban2(ByVal decHatyuNo As Decimal, ByVal decHatyuEdaban As Decimal) As DataTable
        Dim logic As New BLL.Common.ExecuteQuery

        Return logic.ExecuteDataset(
              connectionString _
            , CommandType.Text _
            , "SELECT max(HATYUEDABAN2) HATYUEDABAN2 FROM T_HATYUHED WHERE HATYUNO = @HATYUNO and HATYUEDABAN = @HATYUEDABAN" _
            , New SqlParameter() {New SqlParameter("@HATYUNO", decHatyuNo), New SqlParameter("@HATYUEDABAN", decHatyuEdaban)}
            ).Tables(0)
    End Function

    ''' <summary>
    ''' 仕入先の直近データを取得
    ''' </summary>
    ''' <param name="decHatyuNo">発注Ｎｏ</param>
    ''' <param name="decSiireCode">仕入先コード</param>
    ''' <remarks></remarks>
    Public Function fncSelectT_HATYUHED_SIIRE(ByVal decHatyuNo As Decimal, ByVal decSiireCode As Decimal) As dsT_HATYU.T_HATYUHEDDataTable
        Dim logic As New BLL.Common.ExecuteQuery
        Dim strSQL = ""

        strSQL += " select top 1 *"
        strSQL += " from T_HATYUHED"
        strSQL += " where HATYUNO   = @HATYUNO"
        strSQL += " and   SIIRECODE = @SIIRECODE"
        strSQL += " order by HATYUEDABAN2 desc"

        Return ConvaertDtToT_HATYUHED(
            logic.ExecuteDataset(
                  connectionString _
                , CommandType.Text _
                , strSQL _
                , New SqlParameter() {New SqlParameter("@HATYUNO", decHatyuNo), New SqlParameter("@SIIRECODE", decSiireCode)}
                ).Tables(0)
            )
    End Function

    Private Function ConvaertDtToT_HATYUHED(ByVal dtRead As DataTable) As dsT_HATYU.T_HATYUHEDDataTable
        Dim dt As New dsT_HATYU.T_HATYUHEDDataTable
        Dim dr As dsT_HATYU.T_HATYUHEDRow

        For Each row As DataRow In dtRead.Rows
            dr = CType(dt.NewRow, dsT_HATYU.T_HATYUHEDRow)
            dr.HATYUNO = row.Item("HATYUNO").ToString
            dr.HATYUNO = row.Item("HATYUNO").ToString
            dr.HATYUEDABAN = row.Item("HATYUEDABAN").ToString
            dr.HATYUEDABAN2 = row.Item("HATYUEDABAN2").ToString
            dr.JYUTYUEDABAN = row.Item("JYUTYUEDABAN").ToString
            dr.HATYUDATE = row.Item("HATYUDATE").ToString
            dr.JYUTYUNO = row.Item("JYUTYUNO").ToString
            dr.SIIRECODE = row.Item("SIIRECODE").ToString
            dr.TANTOCODE = row.Item("TANTOCODE").ToString
            dr.INP_TANTOCODE = row.Item("INP_TANTOCODE").ToString
            dr.KEISYOUCODE = row.Item("KEISYOUCODE").ToString
            dr.SIHARAI_COMMENT_01 = row.Item("SIHARAI_COMMENT_01").ToString
            dr.SIHARAI_COMMENT_02 = row.Item("SIHARAI_COMMENT_02").ToString
            dr.SIHARAI_COMMENT_03 = row.Item("SIHARAI_COMMENT_03").ToString
            dr.SIHARAI_COMMENT_04 = row.Item("SIHARAI_COMMENT_04").ToString
            dr.SIHARAI_COMMENT_05 = row.Item("SIHARAI_COMMENT_05").ToString
            dr.SIHARAI_COMMENT_06 = row.Item("SIHARAI_COMMENT_06").ToString
            dr.AITE_MITUMORINO = row.Item("AITE_MITUMORINO").ToString
            dr.KEIYAKUNO = row.Item("KEIYAKUNO").ToString
            dr.NOUKI_START = row.Item("NOUKI_START").ToString
            dr.NOUKI_END = row.Item("NOUKI_END").ToString
            dr.AITEDENPYONO = row.Item("AITEDENPYONO").ToString
            dr.GKGENKAGAKU_NUKI = row.Item("GKGENKAGAKU_NUKI").ToString
            dr.GKTAX = row.Item("GKTAX").ToString
            dr.GKGENKAGAKU = row.Item("GKGENKAGAKU").ToString
            dr.D_BIKO = row.Item("D_BIKO").ToString
            dr.SYORIKBN = row.Item("SYORIKBN").ToString
            dr.SYORISTDATE = row.Item("SYORISTDATE").ToString

            dt.Rows.Add(dr)
        Next

        Return dt
    End Function
End Class
