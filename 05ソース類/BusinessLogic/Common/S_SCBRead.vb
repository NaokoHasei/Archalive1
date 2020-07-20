Imports CommonUtility
Imports System.Data.SqlClient

''' <summary>
''' 基本設定マスタのアクセスクラスです
''' </summary>
''' <remarks></remarks>
Public Class S_SCBRead

    Private S_SCBValue As dsS_SCB

    ''' <summary>
    ''' S_SCB型として基本設定マスタを返します。
    ''' </summary>
    ''' <returns>基本設定マスタ</returns>
    ''' <remarks></remarks>
    Public Function GetS_SCB() As dsS_SCB
        Return S_SCBValue
    End Function

    ''' <summary>
    ''' S_SCB型として基本設定マスタを返します。
    ''' </summary>
    ''' <returns>基本設定マスタ</returns>
    ''' <remarks></remarks>
    Public Function Item() As dsS_SCB
        Return GetS_SCB()
    End Function

    Public Sub New()
        S_SCBValue = Nothing

        Dim resultDataSets As New dsS_SCB

        'DAC作成
        Using masterAdapter As New dsS_SCBTableAdapters.S_SCBTableAdapter,
             connection As New SqlConnection(DBUtility.GetConnectionString)

            masterAdapter.Connection = connection : DBUtility.SetCommandTimeout(masterAdapter)

            masterAdapter.Fill(resultDataSets.S_SCB)
        End Using

        S_SCBValue = resultDataSets
    End Sub

    Public Sub New(ByVal strCATEGORYID As String)
        S_SCBValue = Nothing
        Dim resultDataSets As New dsS_SCB
        'DAC作成
        Using masterAdapter As New dsS_SCBTableAdapters.S_SCBTableAdapter,
             connection As New SqlConnection(DBUtility.GetConnectionString)
            masterAdapter.Connection = connection : DBUtility.SetCommandTimeout(masterAdapter)
            masterAdapter.FillByCATEGORYID(resultDataSets.S_SCB, strCATEGORYID)
        End Using
        S_SCBValue = resultDataSets
    End Sub

    Public Sub New(ByVal strCATEGORYID As String, ByVal strDATAKEY As String)
        S_SCBValue = Nothing
        Dim resultDataSets As New dsS_SCB
        'DAC作成
        Using masterAdapter As New dsS_SCBTableAdapters.S_SCBTableAdapter,
             connection As New SqlConnection(DBUtility.GetConnectionString)
            masterAdapter.Connection = connection : DBUtility.SetCommandTimeout(masterAdapter)

            If Utility.NUCheck(strDATAKEY) Then
                masterAdapter.FillByCATEGORYID(resultDataSets.S_SCB, strCATEGORYID)
            Else
                masterAdapter.FillByCATEGORYID_DATAKEY(resultDataSets.S_SCB, strCATEGORYID, strDATAKEY)
            End If
        End Using
        S_SCBValue = resultDataSets
    End Sub

    Public Sub New(ByVal strCATEGORYID As String, ByVal strDATAKEY As String, ByVal strDATA As String)
        S_SCBValue = Nothing
        Dim resultDataSets As New dsS_SCB
        'DAC作成
        Using masterAdapter As New dsS_SCBTableAdapters.S_SCBTableAdapter,
             connection As New SqlConnection(DBUtility.GetConnectionString)
            masterAdapter.Connection = connection : DBUtility.SetCommandTimeout(masterAdapter)

            masterAdapter.FillByCATEGORYID_DATAKEY_DATA(resultDataSets.S_SCB, strCATEGORYID, strDATAKEY, strDATA)
        End Using
        S_SCBValue = resultDataSets
    End Sub

    Public Sub updateDATA(ByVal categoryId As String, ByVal dataKey As String, ByVal data As String)
        Dim logic As New ExecuteQuery

        Dim strSQL As String = vbNullString
        strSQL += vbCrLf & "update S_SCB"
        strSQL += vbCrLf & "set  DATA = @DATA"
        strSQL += vbCrLf & "where CATEGORYID = @CATEGORYID"
        strSQL += vbCrLf & "and   DATAKEY    = @DATAKEY"

        Dim sqlParameter = New SqlParameter() {
            New SqlParameter("@CATEGORYID", categoryId),
            New SqlParameter("@DATAKEY", dataKey),
            New SqlParameter("@DATA", data)
        }

        logic.ExecuteNonQuery(DBUtility.GetConnectionString, CommandType.Text, strSQL, sqlParameter)
    End Sub

    Public Function getRecodeWhereDataKey(ByVal categoryId As String, ByVal dataKey As String) As dsS_SCB.S_SCBDataTable
        Dim dt As dsS_SCB.S_SCBDataTable = New dsS_SCB.S_SCBDataTable

        Using masterAdapter As New dsS_SCBTableAdapters.S_SCBTableAdapter,
            connection As New SqlConnection(DBUtility.GetConnectionString)
            masterAdapter.Connection = connection : DBUtility.SetCommandTimeout(masterAdapter)

            masterAdapter.FillByCATEGORYID_DATAKEY(dt, categoryId, dataKey)
        End Using

        Return dt
    End Function

End Class
