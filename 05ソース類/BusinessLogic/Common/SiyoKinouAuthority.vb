Imports System.Data.SqlClient

Public Class SiyoKinouAuthority
    Inherits DAL.DALBase

    Public Const CONST_物件登録 = "物件登録"
    Public Const CONST_物件検索 = "物件検索"
    Public Const CONST_物件一覧 = "物件一覧"
    Public Const CONST_メンテナンス = "メンテナンス"
    Public Const CONST_部課マスタ登録 = "部課マスタ登録"
    Public Const CONST_科目マスタ登録 = "科目マスタ登録"
    Public Const CONST_担当者マスタ登録 = "担当者マスタ登録"
    Public Const CONST_顧客マスタ登録 = "顧客マスタ登録"
    Public Const CONST_業者マスタ登録 = "業者マスタ登録"
    Public Const CONST_基本設定マスタ登録 = "基本設定マスタ登録"
    Public Const CONST_区分マスタ登録 = "区分マスタ登録"
    Public Const CONST_郵便番号辞書データ作成 = "郵便番号辞書データ作成"
    Public Const CONST_受注承認 = "受注承認"
    Public Const CONST_発注承認 = "発注承認"

    Dim dt As DataTable

    Public Sub New(ByVal tantoCode As String)
        Dim logic As New ExecuteQuery

        Dim connectionString = CommonUtility.DBUtility.GetConnectionString

        Dim strSQL As String = vbNullString

        strSQL += " select S_2.DATA"
        strSQL += " from M_TANTO TAN"
        strSQL += " inner join S_SCB S_1"
        strSQL += "   on  S_1.CATEGORYID = '使用機能の権限の種類'"
        strSQL += "   and S_1.DATAKEY    = TAN.SIYOKINOU_AUTHORITY"
        strSQL += " inner join S_SCB S_2"
        strSQL += "   on  S_2.CATEGORYID = '使用機能の不可設定'"
        strSQL += "   and S_2.DATAKEY    = S_1.DATA"
        strSQL += " where TAN.TANTOCODE = @TANTOCODE"

        Dim param() As SqlParameter = New SqlParameter() {
            New SqlParameter("@TANTOCODE", tantoCode)
        }

        Dim ds As DataSet = logic.ExecuteDataset(connectionString, CommandType.Text, strSQL, param)

        dt = ds.Tables(0)
    End Sub

    ''' <summary>
    ''' 機能の使用可否を取得
    ''' </summary>
    ''' <param name="kinouName">機能名（同クラス内の定数を使用）</param>
    ''' <returns>チェック結果（true:使用可、false:使用不可）</returns>
    Public Function CheckUseKinou(ByVal kinouName As String) As Boolean
        Dim dr = dt.Select("DATA = '" + kinouName + "'")

        If dr.Length = 0 Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
