Imports Model
Imports CommonUtility

''' <summary>
''' 基本情報マスタのアクセスクラスです
''' </summary>
''' <remarks></remarks>
Public Class MessageInfo

    Private S_MESSAGEValue As dsS_MESSAGE

    ''' <summary>
    ''' S_MESSAGE型として基本情報マスタを返します。
    ''' </summary>
    ''' <returns>基本情報マスタ</returns>
    ''' <remarks></remarks>
    Public Function GetS_MESSAGE() As dsS_MESSAGE
        Return S_MESSAGEValue
    End Function

    ''' <summary>
    ''' S_MESSAGE型として基本情報マスタを返します。
    ''' </summary>
    ''' <returns>基本情報マスタ</returns>
    ''' <remarks></remarks>
    Public Function Item() As dsS_MESSAGE
        Return GetS_MESSAGE()
    End Function

    Public Sub New()
        S_MESSAGEValue = Nothing

        Dim resultDataSets As New dsS_MESSAGE

        'DAC作成
        Using masterAdapter As New dsS_MESSAGETableAdapters.S_MESSAGEViewTableAdapter, _
             connection As New System.Data.SqlClient.SqlConnection(CommonUtility.DBUtility.GetConnectionString)

            masterAdapter.Connection = connection : DBUtility.SetCommandTimeout(masterAdapter)

            masterAdapter.Fill(resultDataSets.S_MESSAGEView)
        End Using

        S_MESSAGEValue = resultDataSets
    End Sub

    ''' <summary>
    ''' 基本情報マスタのレコードを返します
    ''' </summary>
    ''' <returns>基本情報マスタの1レコード目</returns>
    ''' <remarks></remarks>
    Public Function Record() As dsS_MESSAGE.S_MESSAGEViewRow
        If S_MESSAGEValue Is Nothing Then
            Throw New ApplicationException("S_MESSAGEが読み込まれていません")
        End If
        Return S_MESSAGEValue.S_MESSAGEView(0)
    End Function

End Class
