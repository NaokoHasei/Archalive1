Imports System.Data.SqlClient
Imports System.Data
Imports CommonUtility.Utility

Public Class SEN0020

    Private connectionString As String

    ''' <summary>
    ''' クラス初期化    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        connectionString = CommonUtility.DBUtility.GetConnectionString
    End Sub

    ''' <summary>
    ''' 表示データ作成（コード・名称取得用）
    ''' </summary>
    ''' <param name="key"></param>
    ''' <param name="strDate"></param>
    ''' <param name="strPCNAME"></param>
    ''' <param name="strPGID"></param>
    ''' <param name="origin"></param>
    ''' <param name="ReturnCode"></param>
    ''' <param name="ReturnName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetList(ByVal key As Model.M_KUMIAIIN_PrimaryKey, ByVal strDate As String, ByVal strPCNAME As String, ByVal strPGID As String, ByVal origin As Model.SeekOrigin.SeekOriginEnum, ByRef ReturnCode As String, ByRef ReturnName As String) As Model.SEN0020List.DataListDataTable

        key = Seek(key, origin)

        ReturnCode = key.KUMIAIINCODE
        ReturnName = GetName(key)

        Dim op As New System.Transactions.TransactionOptions
        op.IsolationLevel = Transactions.IsolationLevel.ReadUncommitted

        Using ts As System.Transactions.TransactionScope = New System.Transactions.TransactionScope(Transactions.TransactionScopeOption.Required, op)

            Call CreateWorkTable(key, strDate, strPCNAME, strPGID)

            Return GetDataSet(key, strPCNAME)

            ts.Complete()

        End Using

    End Function

    ''' <summary>
    ''' 組合員名称取得
    ''' </summary>
    ''' <param name="current"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetName(ByVal current As Model.M_KUMIAIIN_PrimaryKey) As String
        Dim logic As New BLL.Common.ExecuteQuery
        Return NS(logic.ExecuteScalar(connectionString, CommandType.Text, "SELECT KUM_MEI FROM M_KUMIAIIN where KUMIAIINCODE=@KUMIAIINCODE", New SqlParameter() {New SqlParameter("@KUMIAIINCODE", current.KUMIAIINCODE)}))
    End Function

    ''' <summary>
    ''' 組合員コード取得
    ''' </summary>
    ''' <param name="current"></param>
    ''' <param name="origin"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function Seek(ByVal current As Model.M_KUMIAIIN_PrimaryKey, ByVal origin As Model.SeekOrigin.SeekOriginEnum) As Model.M_KUMIAIIN_PrimaryKey
        Dim param() As SqlParameter = New SqlParameter() {New SqlParameter("@KUMIAIINCODE", current.KUMIAIINCODE)}
        Dim logic As New BLL.Common.ExecuteQuery

        If origin = Model.SeekOrigin.SeekOriginEnum.First Then
            Return New Model.M_KUMIAIIN_PrimaryKey(NS(logic.ExecuteScalar(connectionString, CommandType.Text, _
                "SELECT MIN(KUMIAIINCODE) FROM M_KUMIAIIN")))
        ElseIf origin = Model.SeekOrigin.SeekOriginEnum.Backword Then
            Return New Model.M_KUMIAIIN_PrimaryKey(NS(logic.ExecuteScalar(connectionString, CommandType.Text, _
                "SELECT MAX(KUMIAIINCODE) FROM M_KUMIAIIN WHERE KUMIAIINCODE < @KUMIAIINCODE ", param)))
        ElseIf origin = Model.SeekOrigin.SeekOriginEnum.Forward Then
            Return New Model.M_KUMIAIIN_PrimaryKey(NS(logic.ExecuteScalar(connectionString, CommandType.Text, _
                "SELECT MIN(KUMIAIINCODE) FROM M_KUMIAIIN WHERE KUMIAIINCODE > @KUMIAIINCODE ", param)))
        ElseIf origin = Model.SeekOrigin.SeekOriginEnum.Last Then
            Return New Model.M_KUMIAIIN_PrimaryKey(NS(logic.ExecuteScalar(connectionString, CommandType.Text, _
                "SELECT MAX(KUMIAIINCODE) FROM M_KUMIAIIN ")))
        Else
            Return current
        End If

    End Function

    ''' <summary>
    ''' ワークテーブル削除
    ''' </summary>
    ''' <param name="strPCNAME"></param>
    ''' <param name="strPGID"></param>
    ''' <remarks></remarks>
    Private Sub DeleteWorkTable(ByVal strPCNAME As String, ByVal strPGID As String)

        Dim logicCommon As New BLL.Common.MonthBase
        Call logicCommon.DeleteWT_MONTHBASE(strPCNAME, strPGID)

        Dim logic As New BLL.Common.ExecuteQuery
        logic.ExecuteNonQuery(connectionString, CommandType.Text, "delete from WT_SEN0020 where PCNAME=@PCNAME", New SqlParameter() {New SqlParameter("@PCNAME", strPCNAME)})

    End Sub

    ''' <summary>
    ''' 表示用データ取得
    ''' </summary>
    ''' <param name="key"></param>
    ''' <param name="strPCNAME"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetDataSet(ByVal key As Model.M_KUMIAIIN_PrimaryKey, ByVal strPCNAME As String) As Model.SEN0020List.DataListDataTable

        Dim resultDataSet = New Model.SEN0020List.DataListDataTable

        'DAC作成
        Using masterAdapter As New Model.SEN0020ListTableAdapters.DataListTableAdapter, _
                 connection As New System.Data.SqlClient.SqlConnection(connectionString)
            masterAdapter.Connection = connection : CommonUtility.DBUtility.SetCommandTimeout(masterAdapter)
            masterAdapter.Fill(resultDataSet, strPCNAME)
        End Using


        Dim decSiiregaku As Decimal = 0
        Dim decSiharaigaku As Decimal = 0
        Dim decKijitunai As Decimal = 0
        Dim decHosyokin As Decimal = 0

        Dim decSiireZan As Decimal = 0
        Dim decHosyoZan As Decimal = 0

        For Each row As Model.SEN0020List.DataListRow In resultDataSet.Rows

            If row.GYONO = 0 Then
                row.SIIREGAKU = ""
                row.SIHARAIGAKU = ""
                row.KIJITUNAISIHARAI = ""
                row.HOSYOKIN = ""

            Else

                decSiiregaku = NZ(row.SIIREGAKU)
                decSiharaigaku = NZ(row.SIHARAIGAKU)
                decKijitunai = NZ(row.KIJITUNAISIHARAI)
                decHosyokin = NZ(row.HOSYOKIN)

                row.SIIREZAN = decSiireZan + (decSiiregaku - decSiharaigaku)

                row.HOSYOZAN = decHosyoZan + decHosyokin

                row.SIIREGAKU = decSiiregaku.ToString("#,0")
                row.SIHARAIGAKU = decSiharaigaku.ToString("#,0")
                row.KIJITUNAISIHARAI = decKijitunai.ToString("#,0")
                row.HOSYOKIN = decHosyokin.ToString("#,0")

            End If
            decSiireZan = NZ(row.SIIREZAN)
            decHosyoZan = NZ(row.HOSYOZAN)

        Next

        Return resultDataSet

    End Function
    ''' <summary>
    ''' 表示用データ作成
    ''' </summary>
    ''' <param name="key"></param>
    ''' <param name="strDate"></param>
    ''' <remarks></remarks>
    Public Sub CreateWorkTable(ByVal key As Model.M_KUMIAIIN_PrimaryKey, ByVal strDate As String, ByVal strPCNAME As String, ByVal strPGID As String)

        Dim strSQL As String
        Dim resultWork As New Model.WT_MONTHBASE.WT_MONTHBASEViewDataTable

        Dim strKiyu As String = CType((New BLL.Common.Kihoninfo()).Record.KISYU_MONTH, String)
        strKiyu = ZeroFormat(strKiyu, 2)
        strDate = LeftBSA(strDate, 4) & "/" & strKiyu & "/01"

        'ワークテーブル削除
        Call DeleteWorkTable(strPCNAME, strPGID)

        'ワークテーブル作成
        Dim logicCommon As New BLL.Common.MonthBase
        Call logicCommon.CreateWT_MONTHBASE(strPCNAME, strPGID, strDate, Common.MonthBase.作成ヶ月._15ヶ月)

        'DAC作成
        Using masterAdapter As New Model.WT_MONTHBASETableAdapters.WT_MONTHBASEViewTableAdapter, _
                 connection As New System.Data.SqlClient.SqlConnection(connectionString)
            masterAdapter.Connection = connection : CommonUtility.DBUtility.SetCommandTimeout(masterAdapter)
            masterAdapter.Fill(resultWork, strPCNAME, strPGID)
        End Using

        'ワークテーブル作成

        '繰越レコード作成
        strSQL = "insert into WT_SEN0020(PCNAME, JSKDATE_MON, JSKDATE_MON_Label,SIIREZAN,HOSYOZAN)"
        strSQL += "              select @PCNAME,@JSKDATE_MON,@JSKDATE_MON_Label"
        strSQL += "              ,isnull(GESSYOSIIREZAN,0)"
        strSQL += "              ,isnull(GESSYOHOSYOZAN,0)"
        strSQL += " from (select @KUMIAIINCODE as KUMIAIINCODE) main left join F_StartZaikoGet(@date_in) StartJsk on 1=1"
        strSQL += "                                                                                              and StartJsk.KUMIAIINCODE=main.KUMIAIINCODE"
        strSQL += " where main.KUMIAIINCODE=@KUMIAIINCODE"

        Dim logic As New BLL.Common.ExecuteQuery
        logic.ExecuteNonQuery(connectionString, CommandType.Text, strSQL, _
                              New SqlParameter() {New SqlParameter("@PCNAME", strPCNAME), _
                                                  New SqlParameter("@JSKDATE_MON", DateAdd(DateInterval.Month, -1, CDate(strDate))), _
                                                  New SqlParameter("@JSKDATE_MON_Label", "繰越"), _
                                                  New SqlParameter("@date_in", strDate), _
                                                  New SqlParameter("@KUMIAIINCODE", key.KUMIAIINCODE)})

        For Each row As Model.WT_MONTHBASE.WT_MONTHBASEViewRow In resultWork.Rows

            strDate = RightBSA(CType(row._DATE.Year, String), 2)
            strDate += "/"
            strDate += ZeroFormat(CType(row._DATE.Month, String), 2)

            strSQL = "insert into WT_SEN0020(PCNAME, JSKDATE_MON, JSKDATE_MON_Label, GYONO"
            strSQL += "                    ,SIIREGAKU"
            strSQL += "                    ,SIHARAIGAKU"
            strSQL += "                    ,KIJITUNAISIHARAI"
            strSQL += "                    ,HOSYOKIN)"
            strSQL += "              select @PCNAME,@JSKDATE_MON,@JSKDATE_MON_Label,@GYONO"
            strSQL += "                    ,isnull(SIIREKINGAKU,0)"
            strSQL += "                    ,isnull(SIHARAIKINGAKU,0)"
            strSQL += "                    ,isnull(KIJITUNAISIHARAIKN,0)"
            strSQL += "                    ,isnull(HOSYOKIN_AZUKARIKIN,0)"
            strSQL += "                    -isnull(HOSYOKIN_HARAIDASHIKIN,0)"
            strSQL += " from (select @KUMIAIINCODE as KUMIAIINCODE) main left join F_TukiJskGet(@date_in,@date_in) TukiJsk on 1=1"
            strSQL += "                                                                                                   and TukiJsk.KUMIAIINCODE=main.KUMIAIINCODE"
            strSQL += " where main.KUMIAIINCODE=@KUMIAIINCODE"

            logic.ExecuteNonQuery(connectionString, CommandType.Text, strSQL, _
                                  New SqlParameter() {New SqlParameter("@PCNAME", row.PCNAME), _
                                                      New SqlParameter("@JSKDATE_MON", row._DATE), _
                                                      New SqlParameter("@JSKDATE_MON_Label", strDate), _
                                                      New SqlParameter("@date_in", row._DATE), _
                                                      New SqlParameter("@GYONO", row.GYONO), _
                                                      New SqlParameter("@KUMIAIINCODE", key.KUMIAIINCODE)})
        Next

    End Sub

End Class
