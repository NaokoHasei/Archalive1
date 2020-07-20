Imports CommonUtility

''' <summary>
''' 小科目マスタのアクセスクラスです
''' </summary>
''' <remarks></remarks>
Public Class M_SYOKAMOKURead

    Private M_SYOKAMOKUValue As dsM_SYOKAMOKU

    ''' <summary>
    ''' M_SYOKAMOKU型として小科目マスタを返します。
    ''' </summary>
    ''' <returns>小科目マスタ</returns>
    ''' <remarks></remarks>
    Public Function GetM_SYOKAMOKU() As dsM_SYOKAMOKU
        Return M_SYOKAMOKUValue
    End Function

    ''' <summary>
    ''' M_SYOKAMOKU型として小科目マスタを返します。
    ''' </summary>
    ''' <returns>小科目マスタ</returns>
    ''' <remarks></remarks>
    Public Function Item() As dsM_SYOKAMOKU
        Return GetM_SYOKAMOKU()
    End Function

    Public Sub New()
        M_SYOKAMOKUValue = Nothing

        Dim resultDataSets As New dsM_SYOKAMOKU

        'DAC作成
        Using masterAdapter As New dsM_SYOKAMOKUTableAdapters.M_SYOKAMOKUTableAdapter,
             connection As New System.Data.SqlClient.SqlConnection(CommonUtility.DBUtility.GetConnectionString)

            masterAdapter.Connection = connection : DBUtility.SetCommandTimeout(masterAdapter)

            masterAdapter.Fill(resultDataSets.M_SYOKAMOKU)
        End Using

        M_SYOKAMOKUValue = resultDataSets
    End Sub

    Public Sub New(ByVal kamokuCode As String)
        M_SYOKAMOKUValue = Nothing

        Dim resultDataSets As New dsM_SYOKAMOKU

        'DAC作成
        Using masterAdapter As New dsM_SYOKAMOKUTableAdapters.M_SYOKAMOKUTableAdapter,
             connection As New System.Data.SqlClient.SqlConnection(CommonUtility.DBUtility.GetConnectionString)

            masterAdapter.Connection = connection : DBUtility.SetCommandTimeout(masterAdapter)

            masterAdapter.FillByPK(resultDataSets.M_SYOKAMOKU, kamokuCode)
        End Using

        M_SYOKAMOKUValue = resultDataSets
    End Sub

End Class
