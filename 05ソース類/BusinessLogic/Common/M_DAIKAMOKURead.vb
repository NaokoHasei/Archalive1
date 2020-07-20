Imports CommonUtility

''' <summary>
''' 大科目マスタのアクセスクラスです
''' </summary>
''' <remarks></remarks>
Public Class M_DAIKAMOKURead

    Private M_DAIKAMOKUValue As dsM_DAIKAMOKU

    ''' <summary>
    ''' M_DAIKAMOKU型として大科目マスタを返します。
    ''' </summary>
    ''' <returns>大科目マスタ</returns>
    ''' <remarks></remarks>
    Public Function GetM_DAIKAMOKU() As dsM_DAIKAMOKU
        Return M_DAIKAMOKUValue
    End Function

    ''' <summary>
    ''' M_DAIKAMOKU型として大科目マスタを返します。
    ''' </summary>
    ''' <returns>大科目マスタ</returns>
    ''' <remarks></remarks>
    Public Function Item() As dsM_DAIKAMOKU
        Return GetM_DAIKAMOKU()
    End Function

    Public Sub New()
        M_DAIKAMOKUValue = Nothing

        Dim resultDataSets As New dsM_DAIKAMOKU

        'DAC作成
        Using masterAdapter As New dsM_DAIKAMOKUTableAdapters.M_DAIKAMOKUTableAdapter,
             connection As New System.Data.SqlClient.SqlConnection(CommonUtility.DBUtility.GetConnectionString)

            masterAdapter.Connection = connection : DBUtility.SetCommandTimeout(masterAdapter)

            masterAdapter.Fill(resultDataSets.M_DAIKAMOKU)
        End Using

        M_DAIKAMOKUValue = resultDataSets
    End Sub

    Public Sub New(ByVal kamokuCode As String)
        M_DAIKAMOKUValue = Nothing

        Dim resultDataSets As New dsM_DAIKAMOKU

        'DAC作成
        Using masterAdapter As New dsM_DAIKAMOKUTableAdapters.M_DAIKAMOKUTableAdapter,
             connection As New System.Data.SqlClient.SqlConnection(CommonUtility.DBUtility.GetConnectionString)

            masterAdapter.Connection = connection : DBUtility.SetCommandTimeout(masterAdapter)

            masterAdapter.FillByPK(resultDataSets.M_DAIKAMOKU, kamokuCode)
        End Using

        M_DAIKAMOKUValue = resultDataSets
    End Sub

End Class
