Imports CommonUtility

''' <summary>
''' 仕入先マスタのアクセスクラスです
''' </summary>
''' <remarks></remarks>
Public Class M_SIIRERead

    Private M_SIIREValue As dsM_SIIRE

    ''' <summary>
    ''' M_SIIRE型として仕入先マスタを返します。
    ''' </summary>
    ''' <returns>仕入先マスタ</returns>
    ''' <remarks></remarks>
    Public Function GetM_SIIRE() As dsM_SIIRE
        Return M_SIIREValue
    End Function

    ''' <summary>
    ''' M_SIIRE型として仕入先マスタを返します。
    ''' </summary>
    ''' <returns>仕入先マスタ</returns>
    ''' <remarks></remarks>
    Public Function Item() As dsM_SIIRE
        Return GetM_SIIRE()
    End Function

    Public Sub New()
        M_SIIREValue = Nothing

        Dim resultDataSets As New dsM_SIIRE

        'DAC作成
        Using masterAdapter As New dsM_SIIRETableAdapters.M_SIIRETableAdapter, _
             connection As New System.Data.SqlClient.SqlConnection(CommonUtility.DBUtility.GetConnectionString)

            masterAdapter.Connection = connection : DBUtility.SetCommandTimeout(masterAdapter)

            masterAdapter.Fill(resultDataSets.M_SIIRE)
        End Using

        M_SIIREValue = resultDataSets
    End Sub

    Public Sub New(ByVal strSIIRECODE As String)
        M_SIIREValue = Nothing

        Dim resultDataSets As New dsM_SIIRE

        'DAC作成
        Using masterAdapter As New dsM_SIIRETableAdapters.M_SIIRETableAdapter, _
             connection As New System.Data.SqlClient.SqlConnection(CommonUtility.DBUtility.GetConnectionString)

            masterAdapter.Connection = connection : DBUtility.SetCommandTimeout(masterAdapter)

            If Utility.NUCheck(strSIIRECODE) Then
                masterAdapter.Fill(resultDataSets.M_SIIRE)
            Else
                masterAdapter.FillBySIIRECODE(resultDataSets.M_SIIRE, strSIIRECODE)
            End If
        End Using

        M_SIIREValue = resultDataSets
    End Sub

End Class
