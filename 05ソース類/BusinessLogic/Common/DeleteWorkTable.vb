Imports System.Data.SqlClient
Imports System.Data

Public Class DeleteWorkTable

    Private connectionString As String

    ''' <summary>
    ''' クラス初期化
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        connectionString = CommonUtility.DBUtility.GetConnectionString
    End Sub

    ''' <summary>
    ''' ワークテーブル削除（WT_SIIRETRAN）
    ''' </summary>
    ''' <param name="strPCNAME"></param>
    ''' <remarks></remarks>
    Public Sub DeleteWT_SIIRETRAN(ByVal strPCNAME As String)
        Dim del As New BLL.Common.ExecuteQuery
        del.ExecuteNonQuery(connectionString, CommandType.Text, "delete from WT_SIIRETRAN where PCNAME=@PCNAME", New SqlParameter() {New SqlParameter("@PCNAME", strPCNAME)})
    End Sub

    ''' <summary>
    ''' ワークテーブル削除（WT_SIIRETRAN）
    ''' </summary>
    ''' <param name="strPCNAME"></param>
    ''' <remarks></remarks>
    Public Sub DeleteWT_SIIRETRAN(ByVal connection As SqlConnection, ByVal strPCNAME As String)
        Dim del As New BLL.Common.ExecuteQuery
        del.ExecuteNonQuery(connection, CommandType.Text, "delete from WT_SIIRETRAN where PCNAME=@PCNAME", New SqlParameter() {New SqlParameter("@PCNAME", strPCNAME)})
    End Sub

    ''' <summary>
    ''' ワークテーブル削除（WT_SIHARAITRAN）
    ''' </summary>
    ''' <param name="strPCNAME"></param>
    ''' <remarks></remarks>
    Public Sub DeleteWT_SIHARAITRAN(ByVal strPCNAME As String)
        Dim del As New BLL.Common.ExecuteQuery
        del.ExecuteNonQuery(connectionString, CommandType.Text, "delete from WT_SIHARAITRAN where PCNAME=@PCNAME", New SqlParameter() {New SqlParameter("@PCNAME", strPCNAME)})
    End Sub

    ''' <summary>
    ''' ワークテーブル削除（WT_SIHARAITRAN）
    ''' </summary>
    ''' <param name="strPCNAME"></param>
    ''' <remarks></remarks>
    Public Sub DeleteWT_SIHARAITRAN(ByVal connection As SqlConnection, ByVal strPCNAME As String)
        Dim del As New BLL.Common.ExecuteQuery
        del.ExecuteNonQuery(connection, CommandType.Text, "delete from WT_SIHARAITRAN where PCNAME=@PCNAME", New SqlParameter() {New SqlParameter("@PCNAME", strPCNAME)})
    End Sub

    ''' <summary>
    ''' ワークテーブル削除（WT_SEISANAZUKARITRN）
    ''' </summary>
    ''' <param name="strPCNAME"></param>
    ''' <remarks></remarks>
    Public Sub DeleteWT_SEISANAZUKARITRN(ByVal strPCNAME As String)
        Dim del As New BLL.Common.ExecuteQuery
        del.ExecuteNonQuery(connectionString, CommandType.Text, "delete from WT_SEISANAZUKARITRN where PCNAME=@PCNAME", New SqlParameter() {New SqlParameter("@PCNAME", strPCNAME)})
    End Sub

    ''' <summary>
    ''' ワークテーブル削除（WT_SEISANAZUKARITRN）
    ''' </summary>
    ''' <param name="strPCNAME"></param>
    ''' <remarks></remarks>
    Public Sub DeleteWT_SEISANAZUKARITRN(ByVal connection As SqlConnection, ByVal strPCNAME As String)
        Dim del As New BLL.Common.ExecuteQuery
        del.ExecuteNonQuery(connection, CommandType.Text, "delete from WT_SEISANAZUKARITRN where PCNAME=@PCNAME", New SqlParameter() {New SqlParameter("@PCNAME", strPCNAME)})
    End Sub

    ''' <summary>
    ''' ワークテーブル削除（WT_HOSYOKINTRAN）
    ''' </summary>
    ''' <param name="strPCNAME"></param>
    ''' <remarks></remarks>
    Public Sub DeleteWT_HOSYOKINTRAN(ByVal strPCNAME As String)
        Dim del As New BLL.Common.ExecuteQuery
        del.ExecuteNonQuery(connectionString, CommandType.Text, "delete from WT_HOSYOKINTRAN where PCNAME=@PCNAME", New SqlParameter() {New SqlParameter("@PCNAME", strPCNAME)})
    End Sub

    ''' <summary>
    ''' ワークテーブル削除（WT_HOSYOKINTRAN）
    ''' </summary>
    ''' <param name="strPCNAME"></param>
    ''' <remarks></remarks>
    Public Sub DeleteWT_HOSYOKINTRAN(ByVal connection As SqlConnection, ByVal strPCNAME As String)
        Dim del As New BLL.Common.ExecuteQuery
        del.ExecuteNonQuery(connection, CommandType.Text, "delete from WT_HOSYOKINTRAN where PCNAME=@PCNAME", New SqlParameter() {New SqlParameter("@PCNAME", strPCNAME)})
    End Sub

    ''' <summary>
    ''' ワークテーブル削除（WT_DAY0080）
    ''' </summary>
    ''' <param name="strPCNAME"></param>
    ''' <remarks></remarks>
    Public Sub DeleteWT_DAY0080(ByVal strPCNAME As String)
        Dim del As New BLL.Common.ExecuteQuery
        del.ExecuteNonQuery(connectionString, CommandType.Text, "delete from WT_DAY0080 where PCNAME=@PCNAME", New SqlParameter() {New SqlParameter("@PCNAME", strPCNAME)})
    End Sub

    ''' <summary>
    ''' ワークテーブル削除（WT_DAY0080）
    ''' </summary>
    ''' <param name="strPCNAME"></param>
    ''' <remarks></remarks>
    Public Sub DeleteWT_DAY0080(ByVal connection As SqlConnection, ByVal strPCNAME As String)
        Dim del As New BLL.Common.ExecuteQuery
        del.ExecuteNonQuery(connection, CommandType.Text, "delete from WT_DAY0080 where PCNAME=@PCNAME", New SqlParameter() {New SqlParameter("@PCNAME", strPCNAME)})
    End Sub

End Class
