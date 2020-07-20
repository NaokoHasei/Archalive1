Imports CommonUtility

''' <summary>
''' 中科目マスタのアクセスクラスです
''' </summary>
''' <remarks></remarks>
Public Class M_CYUKAMOKURead

    Private M_CYUKAMOKUValue As dsM_CYUKAMOKU

    ''' <summary>
    ''' M_CYUKAMOKU型として中科目マスタを返します。
    ''' </summary>
    ''' <returns>中科目マスタ</returns>
    ''' <remarks></remarks>
    Public Function GetM_CYUKAMOKU() As dsM_CYUKAMOKU
        Return M_CYUKAMOKUValue
    End Function

    ''' <summary>
    ''' M_CYUKAMOKU型として中科目マスタを返します。
    ''' </summary>
    ''' <returns>中科目マスタ</returns>
    ''' <remarks></remarks>
    Public Function Item() As dsM_CYUKAMOKU
        Return GetM_CYUKAMOKU()
    End Function

    Public Sub New()
        M_CYUKAMOKUValue = Nothing

        Dim resultDataSets As New dsM_CYUKAMOKU

        'DAC作成
        Using masterAdapter As New dsM_CYUKAMOKUTableAdapters.M_CYUKAMOKUTableAdapter,
             connection As New System.Data.SqlClient.SqlConnection(CommonUtility.DBUtility.GetConnectionString)

            masterAdapter.Connection = connection : DBUtility.SetCommandTimeout(masterAdapter)

            masterAdapter.Fill(resultDataSets.M_CYUKAMOKU)
        End Using

        M_CYUKAMOKUValue = resultDataSets
    End Sub

    Public Sub New(ByVal kamokuCode As String)
        M_CYUKAMOKUValue = Nothing

        Dim resultDataSets As New dsM_CYUKAMOKU

        'DAC作成
        Using masterAdapter As New dsM_CYUKAMOKUTableAdapters.M_CYUKAMOKUTableAdapter,
             connection As New System.Data.SqlClient.SqlConnection(CommonUtility.DBUtility.GetConnectionString)

            masterAdapter.Connection = connection : DBUtility.SetCommandTimeout(masterAdapter)

            masterAdapter.FillByPK(resultDataSets.M_CYUKAMOKU, kamokuCode)
        End Using

        M_CYUKAMOKUValue = resultDataSets
    End Sub

End Class
