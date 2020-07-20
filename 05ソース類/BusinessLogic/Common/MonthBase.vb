Imports System.Data.SqlClient
Imports System.Data
Imports CommonUtility
Imports Model

Public Class MonthBase

    Private connectionString As String

    ''' <summary>
    ''' クラス初期化
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        connectionString = CommonUtility.DBUtility.GetConnectionString
    End Sub

    Enum 作成ヶ月
        _12ヶ月 = 12
        _15ヶ月 = 15
    End Enum

    ''' <summary>
    ''' １５ヶ月データ作成
    ''' </summary>
    ''' <param name="strPCNAME">端末名</param>
    ''' <param name="strPGID">プログラムＩＤ</param>
    ''' <param name="strDate">日付（yyyy/mm/01指定）</param>
    ''' <remarks></remarks>
    Public Sub CreateWT_MONTHBASE(ByVal strPCNAME As String, ByVal strPGID As String, ByVal strDate As String, ByVal intMonth As 作成ヶ月)

        Dim logic As New BLL.Common.ExecuteQuery
        Dim dtmCurrent_mon As Date = CDate(strDate)

        strDate = Format(strDate, "yyyy/MM/01")

        For intGyo As Integer = 1 To intMonth
            logic.ExecuteNonQuery(connectionString, CommandType.Text, "insert into WT_MONTHBASE values(@PCNAME,@PGID,@DATE,@GYONO)", _
                                  New SqlParameter() {New SqlParameter("@PCNAME", strPCNAME), _
                                                      New SqlParameter("@PGID", strPGID), _
                                                      New SqlParameter("@DATE", dtmCurrent_mon), _
                                                      New SqlParameter("@GYONO", intGyo)})
            dtmCurrent_mon = DateAdd(DateInterval.Month, 1, dtmCurrent_mon)
        Next

    End Sub

    ''' <summary>
    ''' ワークテーブル削除
    ''' </summary>
    ''' <param name="strPCNAME"></param>
    ''' <param name="strPGID"></param>
    ''' <remarks></remarks>
    Public Sub DeleteWT_MONTHBASE(ByVal strPCNAME As String, ByVal strPGID As String)
        Dim logic As New BLL.Common.ExecuteQuery
        logic.ExecuteNonQuery(connectionString, CommandType.Text, "delete from WT_MONTHBASE where PCNAME=@PCNAME and PGID=@PGID", _
                              New SqlParameter() {New SqlParameter("@PCNAME", strPCNAME), _
                                                  New SqlParameter("@PGID", strPGID)})
    End Sub


End Class
