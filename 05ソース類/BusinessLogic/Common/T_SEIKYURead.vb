Imports System.Data.SqlClient

Public Class T_SEIKYURead

    Private connectionString As String

    ''' <summary>
    ''' クラス初期化
    ''' </summary>
    Public Sub New()
        connectionString = CommonUtility.DBUtility.GetConnectionString
    End Sub

    ''' <summary>
    ''' 請求枝番の最大取得
    ''' </summary>
    ''' <param name="seikyuNo">請求Ｎｏ</param>
    ''' <remarks></remarks>
    Public Function fncSelectMAX_SEIKYUEDABAN(ByVal seikyuNo As Decimal) As DataTable
        Dim logic As New BLL.Common.ExecuteQuery

        Return logic.ExecuteDataset(
              connectionString _
            , CommandType.Text _
            , "SELECT MAX(SEIKYUEDABAN) as SEIKYUEDABAN FROM T_SEIKYUHED WHERE SEIKYUNO = @SEIKYUNO" _
            , New SqlParameter("@SEIKYUNO", seikyuNo)
            ).Tables(0)
    End Function

    ''' <summary>
    ''' 請求ヘッダデータオープン
    ''' </summary>
    ''' <param name="decSeikyuNo">請求Ｎｏ</param>
    ''' <remarks></remarks>
    Public Function fncSelectT_SEIKYUHED(ByVal decSeikyuNo As Decimal) As DataTable
        Dim logic As New BLL.Common.ExecuteQuery

        Return logic.ExecuteDataset(
              connectionString _
            , CommandType.Text _
            , "SELECT * FROM T_SEIKYUHED WHERE SEIKYUNO = @SEIKYUNO" _
            , New SqlParameter("@SEIKYUNO", decSeikyuNo)
            ).Tables(0)
    End Function

    ''' <summary>
    ''' 請求ヘッダの取得（受注枝番に該当するデータ）
    ''' </summary>
    ''' <param name="decSeikyuNo">請求Ｎｏ</param>
    ''' <param name="decJyutyuEdaban">受注枝番</param>
    ''' <remarks></remarks>
    Public Function fncSelectT_SEIKYUHED_JYUTYUEDABAN(ByVal decSeikyuNo As Decimal, ByVal decJyutyuEdaban As Decimal) As DataTable
        Dim logic As New BLL.Common.ExecuteQuery

        Return logic.ExecuteDataset(
              connectionString _
            , CommandType.Text _
            , "SELECT * FROM T_SEIKYUHED WHERE SEIKYUNO = @SEIKYUNO and JYUTYUEDABAN = @JYUTYUEDABAN" _
            , New SqlParameter() {New SqlParameter("@SEIKYUNO", decSeikyuNo), New SqlParameter("@JYUTYUEDABAN", decJyutyuEdaban)}
            ).Tables(0)
    End Function

    ''' <summary>
    ''' 請求ヘッダの取得
    ''' </summary>
    ''' <param name="decSeikyuNo">請求Ｎｏ</param>
    ''' <param name="decSeikyuEdaban">請求枝番</param>
    ''' <remarks></remarks>
    Public Function fncSelectT_SEIKYUHED(ByVal decSeikyuNo As Decimal, ByVal decSeikyuEdaban As Decimal) As dsT_SEIKYU.T_SEIKYUHEDDataTable
        Dim logic As New BLL.Common.ExecuteQuery

        Dim dt = logic.ExecuteDataset(
              connectionString _
            , CommandType.Text _
            , "SELECT * FROM T_SEIKYUHED WHERE SEIKYUNO = @SEIKYUNO and SEIKYUEDABAN = @SEIKYUEDABAN" _
            , New SqlParameter() {New SqlParameter("@SEIKYUNO", decSeikyuNo), New SqlParameter("@SEIKYUEDABAN", decSeikyuEdaban)}
            ).Tables(0)

        Dim dtResult As New dsT_SEIKYU.T_SEIKYUHEDDataTable

        For Each row As DataRow In dt.Rows
            Dim dr = CType(dtResult.NewRow, dsT_SEIKYU.T_SEIKYUHEDRow)
            dr.SEIKYUNO = CDec(row.Item("SEIKYUNO"))
            dr.SEIKYUEDABAN = row.Item("SEIKYUEDABAN").ToString
            dr.JYUTYUNO = CDec(row.Item("JYUTYUNO"))
            dr.JYUTYUEDABAN = row.Item("JYUTYUEDABAN").ToString
            dr.SEIKYUDATE = CDate(row.Item("SEIKYUDATE"))
            dr.SEIKYUMETHOD = row.Item("SEIKYUMETHOD").ToString
            dr.TOKUICODE = row.Item("TOKUICODE").ToString
            dr.TANTOCODE = row.Item("TANTOCODE").ToString
            dr.INP_TANTOCODE = row.Item("INP_TANTOCODE").ToString
            dr.KEISYOUCODE = row.Item("KEISYOUCODE").ToString
            dr.SAN_JYUTYUNO = CDec(row.Item("SAN_JYUTYUNO"))
            dr.AITEDENPYONO = row.Item("AITEDENPYONO").ToString
            dr.GKGENKAGAKU = CDec(row.Item("GKGENKAGAKU"))
            dr.GKSEIKYUGAKU_NUKI = CDec(row.Item("GKSEIKYUGAKU_NUKI"))
            dr.GKTAX = CDec(row.Item("GKTAX"))
            dr.GKSEIKYUGAKU = CDec(row.Item("GKSEIKYUGAKU"))
            dr.GKARARIGAKU = CDec(row.Item("GKARARIGAKU"))
            dr.KONJYURYOKINGAKU = row.Item("KONJYURYOKINGAKU").ToString
            dr.KURIKOSIZAN = row.Item("KURIKOSIZAN").ToString
            dr.HORYUKIN = row.Item("HORYUKIN").ToString
            dr.KONHORYUKIN = row.Item("KONHORYUKIN").ToString
            dr.D_BIKO = row.Item("D_BIKO").ToString
            dr.KIGYOKBN = CDec(row.Item("KIGYOKBN"))
            dr.SYORIKBN = CDec(row.Item("SYORIKBN"))
            dr.SYORISTDATE = CDate(row.Item("SYORISTDATE"))
            dr.SURYO_SYOSUIKAKETA = row.Item("SURYO_SYOSUIKAKETA").ToString
            dtResult.Rows.Add(dr)
        Next

        Return dtResult
    End Function

End Class
