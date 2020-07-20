Imports CommonUtility

Public Class S_SYSTEMRead

    Private S_SYSTEMValue As dsS_SYSTEM

    ''' <summary>
    ''' S_SYSTEM型としてシステム設定マスタを返します。
    ''' </summary>
    ''' <returns>システム設定マスタ</returns>
    ''' <remarks></remarks>
    Public Function GetS_SYSTEM() As dsS_SYSTEM
        Return S_SYSTEMValue
    End Function

    ''' <summary>
    ''' S_SYSTEM型としてシステム設定マスタを返します。
    ''' </summary>
    ''' <returns>システム設定マスタ</returns>
    ''' <remarks></remarks>
    Public Function Item() As dsS_SYSTEM
        Return GetS_SYSTEM()
    End Function

    Public Sub New(ByVal strPCNAME As String)
        S_SYSTEMValue = Nothing
        Dim resultDataSets As New dsS_SYSTEM
        'DAC作成
        Using masterAdapter As New dsS_SYSTEMTableAdapters.S_SYSTEMViewTableAdapter, _
             connection As New System.Data.SqlClient.SqlConnection(CommonUtility.DBUtility.GetConnectionString)
            masterAdapter.Connection = connection : DBUtility.SetCommandTimeout(masterAdapter)
            masterAdapter.Fill(resultDataSets.S_SYSTEMView, strPCNAME)
        End Using
        S_SYSTEMValue = resultDataSets
    End Sub

    '''' <summary>
    '''' システム設定マスタのレコードを返します
    '''' </summary>
    '''' <returns>システム設定マスタの1レコード目</returns>
    '''' <remarks></remarks>
    'Public Function Record() As S_SYSTEM.S_SYSTEMViewRow
    '    If S_SYSTEMValue Is Nothing Then
    '        Throw New ApplicationException("S_SYSTEMが読み込まれていません")
    '    End If
    '    Return S_SYSTEMValue.S_SYSTEMView(0)
    'End Function

End Class
