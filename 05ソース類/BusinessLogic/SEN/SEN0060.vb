Public Class SEN0060

    Private connectionString As String

    ''' <summary>
    ''' クラス初期化    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        connectionString = CommonUtility.DBUtility.GetConnectionString
    End Sub

    ''' <summary>
    ''' データ取得（組合員コードなし）
    ''' </summary>
    ''' <param name="SearchKeys"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetList(ByVal SearchKeys As Model.DTO.RequestSEN0060GetList) As Model.SEN0060List

        Dim resultDataSet As New Model.SEN0060List

        Dim op As New System.Transactions.TransactionOptions
        op.IsolationLevel = Transactions.IsolationLevel.ReadUncommitted

        Using ts As System.Transactions.TransactionScope = New System.Transactions.TransactionScope(Transactions.TransactionScopeOption.Required, op)

            If CommonUtility.Utility.NUCheck(SearchKeys.KUMIAIINCODE) Then
                resultDataSet = GetDataList(SearchKeys.SIHARAIDATE(0), SearchKeys.SIHARAIDATE(1))
            Else
                resultDataSet = GetDataList(SearchKeys.SIHARAIDATE(0), SearchKeys.SIHARAIDATE(1), SearchKeys.KUMIAIINCODE)
            End If

            ts.Complete()

        End Using

        Return resultDataSet

    End Function

    ''' <summary>
    ''' データ取得（組合員コードなし）
    ''' </summary>
    ''' <param name="dtmSIHARAIDATEST"></param>
    ''' <param name="dtmSIHARAIDATEED"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetDataList(ByVal dtmSIHARAIDATEST As Date, ByVal dtmSIHARAIDATEED As Date) As Model.SEN0060List

        Dim resultDataSet As New Model.SEN0060List
        Using masterAdapter As New Model.SEN0060ListTableAdapters.DataListTableAdapter, _
            connection As New System.Data.SqlClient.SqlConnection(connectionString)
            masterAdapter.Connection = connection : CommonUtility.DBUtility.SetCommandTimeout(masterAdapter)
            masterAdapter.Fill(resultDataSet.DataList, dtmSIHARAIDATEST, dtmSIHARAIDATEED)
        End Using
        Return resultDataSet

    End Function

    ''' <summary>
    ''' データ取得（組合員コードあり）
    ''' </summary>
    ''' <param name="dtmSIHARAIDATEST"></param>
    ''' <param name="dtmSIHARAIDATEED"></param>
    ''' <param name="strKUMIAIINCODE"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetDataList(ByVal dtmSIHARAIDATEST As Date, ByVal dtmSIHARAIDATEED As Date, ByVal strKUMIAIINCODE As String) As Model.SEN0060List

        Dim resultDataSet As New Model.SEN0060List
        Using masterAdapter As New Model.SEN0060ListTableAdapters.DataListTableAdapter, _
            connection As New System.Data.SqlClient.SqlConnection(connectionString)
            masterAdapter.Connection = connection : CommonUtility.DBUtility.SetCommandTimeout(masterAdapter)
            masterAdapter.FillByKUMIAIINCODE(resultDataSet.DataList, dtmSIHARAIDATEST, dtmSIHARAIDATEED, strKUMIAIINCODE)
        End Using
        Return resultDataSet

    End Function

End Class
