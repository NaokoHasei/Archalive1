Imports CommonUtility

''' <summary>
''' 区分マスタのアクセスクラスです
''' </summary>
''' <remarks></remarks>
Public Class M_KBNRead

    Private M_KBNValue As dsM_KBN

    ''' <summary>
    ''' M_KBN型として区分マスタを返します。
    ''' </summary>
    ''' <returns>区分マスタ</returns>
    ''' <remarks></remarks>
    Public Function GetM_KBN() As dsM_KBN
        Return M_KBNValue
    End Function

    ''' <summary>
    ''' M_KBN型として区分マスタを返します。
    ''' </summary>
    ''' <returns>区分マスタ</returns>
    ''' <remarks></remarks>
    Public Function Item() As dsM_KBN
        Return GetM_KBN()
    End Function

    Public Sub New()

    End Sub

    Public Sub New(ByVal strSIYOUKBN As String)
        M_KBNValue = Nothing
        Dim resultDataSets As New dsM_KBN
        'DAC作成
        Using masterAdapter As New dsM_KBNTableAdapters.M_KBNTableAdapter, _
             connection As New System.Data.SqlClient.SqlConnection(CommonUtility.DBUtility.GetConnectionString)
            masterAdapter.Connection = connection : DBUtility.SetCommandTimeout(masterAdapter)
            masterAdapter.FillBySIYOUKBN(resultDataSets.M_KBN, strSIYOUKBN)
        End Using
        M_KBNValue = resultDataSets
    End Sub

    Public Sub New(ByVal strSIYOUKBN As String, ByVal strKBN As String)
        M_KBNValue = Nothing
        Dim resultDataSets As New dsM_KBN
        'DAC作成
        Using masterAdapter As New dsM_KBNTableAdapters.M_KBNTableAdapter, _
             connection As New System.Data.SqlClient.SqlConnection(CommonUtility.DBUtility.GetConnectionString)
            masterAdapter.Connection = connection : DBUtility.SetCommandTimeout(masterAdapter)
            If Utility.NUCheck(strKBN) Then
                masterAdapter.FillBySIYOUKBN(resultDataSets.M_KBN, strSIYOUKBN)
            Else
                masterAdapter.FillBySIYOUKBN_KBN(resultDataSets.M_KBN, strSIYOUKBN, strKBN)
            End If
        End Using
        M_KBNValue = resultDataSets
    End Sub

    Public Sub New(ByVal strSIYOUKBN As String, ByVal strKBN As String, ByVal strKBNNAME As String)
        M_KBNValue = Nothing
        Dim resultDataSets As New dsM_KBN
        'DAC作成
        Using masterAdapter As New dsM_KBNTableAdapters.M_KBNTableAdapter,
             connection As New System.Data.SqlClient.SqlConnection(CommonUtility.DBUtility.GetConnectionString)
            masterAdapter.Connection = connection : DBUtility.SetCommandTimeout(masterAdapter)
            masterAdapter.FillBySIYOUKBN_KBNNAME(resultDataSets.M_KBN, strSIYOUKBN, strKBNNAME)
        End Using
        M_KBNValue = resultDataSets
    End Sub

    ''' <summary>
    ''' 消費税率取得
    ''' </summary>
    ''' <remarks></remarks>
    Public Function fncSelect_SyohiZeiritu(ByVal datDate As Date) As String

        Dim logic As New BLL.Common.ExecuteQuery
        Dim strSQL As String
        Dim ds As System.Data.DataSet

        '初期化
        fncSelect_SyohiZeiritu = Nothing

        strSQL = vbNullString
        strSQL += " SELECT"
        strSQL += " KBNNAME" & vbCrLf
        strSQL += " FROM M_KBN" & vbCrLf
        strSQL += " WHERE SIYOUKBN = '80'" & vbCrLf
        strSQL += " AND   ATAI1 <= '" & datDate & "'" & vbCrLf
        strSQL += " AND   ATAI2 >= '" & datDate & "'" & vbCrLf

        ds = logic.ExecuteDataset(DBUtility.GetConnectionString, CommandType.Text, strSQL)
        If Utility.NUCheck(ds.Tables(0).Rows(0).Item("KBNNAME").ToString) Then
            Return vbNullString
        End If

        Return ds.Tables(0).Rows(0).Item("KBNNAME").ToString

    End Function

End Class
