Imports System.Data.SqlClient

Public Class GetNowUserInfo

    Inherits Common.DAL.DALBase

    Private M_NOWUSERValue As dsM_NOWUSER

    Public Function GetM_NOWUSER() As dsM_NOWUSER
        Return M_NOWUSERValue
    End Function

    Public Function Item() As dsM_NOWUSER
        Return GetM_NOWUSER()
    End Function



    Public Sub New(ByVal strPCNAME As String)

        M_NOWUSERValue = Nothing
        Dim resultDataSets As New dsM_NOWUSER

        'DAC作成
        Using masterAdapter As New dsM_NOWUSERTableAdapters.M_NOWUSERTableAdapter, _
             connection As New System.Data.SqlClient.SqlConnection(CommonUtility.DBUtility.GetConnectionString)

            masterAdapter.Connection = connection : CommonUtility.DBUtility.SetCommandTimeout(masterAdapter)
            masterAdapter.FillByPCNAME(resultDataSets.M_NOWUSER, strPCNAME)

        End Using

        M_NOWUSERValue = resultDataSets
    End Sub

    ''' <summary>
    ''' 基本情報マスタのレコードを返します
    ''' </summary>
    ''' <returns>基本情報マスタの1レコード目</returns>
    ''' <remarks></remarks>
    Public Function Record() As dsM_NOWUSER.M_NOWUSERRow
        If M_NOWUSERValue Is Nothing Then
            Throw New ApplicationException("S_INITIALINFOが読み込まれていません")
        End If
        Return M_NOWUSERValue.M_NOWUSER(0)
    End Function

    ''' <summary>
    ''' M_NOWUSERから削除
    ''' </summary>
    ''' <returns>boolean</returns>
    ''' <remarks></remarks>
    Public Function fncM_NOWUSER_Delete(ByVal strPCNAME As String) As Boolean

        Dim strSQL As String           'SQL String

        'エラートラップの設定
        On Error GoTo ErrorHandler

        '初期設定
        fncM_NOWUSER_Delete = False

        Dim logic As New BLL.Common.ExecuteQuery
        Using ts As System.Transactions.TransactionScope = New System.Transactions.TransactionScope

            '端末名称でM_NOWUSER 読込
            strSQL = ""
            strSQL = strSQL & "select * from M_NOWUSER "
            strSQL = strSQL & "where "
            strSQL = strSQL & "PCNAME = '" & strPCNAME & "' "

            'データ検索
            Dim ds As DataSet
            ds = logic.ExecuteDataset(connectionString, CommandType.Text, strSQL)

            '存在した場合削除
            If ds.Tables(0).Rows.Count > 0 Then
                strSQL = ""
                strSQL = "delete from M_NOWUSER where PCNAME = @PCNAME"
                Dim common As New BLL.Common.ExecuteQuery
                common.ExecuteNonQuery(connectionString, CommandType.Text, strSQL, New SqlParameter() {New SqlParameter("@PCNAME", strPCNAME)})

            End If
            ts.Complete()

            'Recordsetの解放
            ds = Nothing

        End Using

        '戻値
        fncM_NOWUSER_Delete = True

        Exit Function

ErrorHandler:
        Err.Raise(Err.Number, Err.Source, Err.Description, Err.HelpFile, Err.HelpContext)
    End Function

    '**************************************************************************************************
    '機能 ：M_NOWUSERよりログインユーザーを取得
    '引数 ：strUserCode : ユーザーコード（戻り値）
    '戻値 ：True  : 正常終了
    ' 　　　False : 異常終了
    '**************************************************************************************************
    Public Function pfncGetNowUser(ByVal strPCNAME As String, ByRef strUserCode As String) As Boolean

        '変数宣言
        Dim strSQL As String

        'エラートラップ
        On Error GoTo pfncGetNowUser_Exit

        '初期化
        pfncGetNowUser = False
        strUserCode = ""

        Dim logic As New BLL.Common.ExecuteQuery
        Using ts As System.Transactions.TransactionScope = New System.Transactions.TransactionScope
            '端末名称でM_NOWUSER 読込
            strSQL = ""
            strSQL = strSQL & "select * from M_NOWUSER "
            strSQL = strSQL & "where "
            strSQL = strSQL & "PCNAME = '" & strPCNAME & "' "
            Dim ds As DataSet = logic.ExecuteDataset(connectionString, CommandType.Text, strSQL)
            If ds.Tables(0).Rows.Count <> 0 Then
                strUserCode = ds.Tables(0).Rows(0).Item("USERCODE").ToString
            End If

        End Using

        '戻値
        pfncGetNowUser = True

pfncGetNowUser_Exit:
    End Function

    '**************************************************************************************************
    '機能 ：M_PROGRAMCONDISIONより実行区分を取得
    '引数 ：strUserCode : ユーザーコード（戻り値）
    '戻値 ：True  : 正常終了
    ' 　　　False : 異常終了
    '**************************************************************************************************
    Public Function pfncGetJIKOUKBN(ByVal strUSER_CODE As String, ByRef strPGID As String) As Boolean

        '変数宣言
        Dim strSQL As String

        'エラートラップ
        On Error GoTo pfncGetNowUser_Exit

        '初期化
        pfncGetJIKOUKBN = False

        Dim logic As New BLL.Common.ExecuteQuery
        Using ts As System.Transactions.TransactionScope = New System.Transactions.TransactionScope
            '端末名称でM_PROGRAMCONDISION 読込
            strSQL = ""
            strSQL = strSQL & "select * from M_PROGRAMCONDISION "
            strSQL = strSQL & "where "
            strSQL = strSQL & "USERCODE = '" & strUSER_CODE & "' "
            strSQL = strSQL & "and PROGRAMCODE = '" & strPGID & "' "
            strSQL = strSQL & "and JIKOUKBN = 1 "
            Dim ds As DataSet = logic.ExecuteDataset(connectionString, CommandType.Text, strSQL)
            If ds.Tables(0).Rows.Count <> 0 Then
                '戻値
                pfncGetJIKOUKBN = True
            End If

        End Using


pfncGetNowUser_Exit:
    End Function


End Class
