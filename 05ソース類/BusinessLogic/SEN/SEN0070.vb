Public Class SEN0070

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
    Public Function GetList(ByVal SearchKeys As Model.DTO.RequestSEN0070GetList) As Model.SEN0070List

        Dim resultDataSet As New Model.SEN0070List

        Dim op As New System.Transactions.TransactionOptions
        op.IsolationLevel = Transactions.IsolationLevel.ReadUncommitted

        Using ts As System.Transactions.TransactionScope = New System.Transactions.TransactionScope(Transactions.TransactionScopeOption.Required, op)

            If CommonUtility.Utility.NUCheck(SearchKeys.KUMIAIINCODE) Then
                resultDataSet = GetDataList(SearchKeys.HIKIDASHIBI(0), SearchKeys.HIKIDASHIBI(1))
            Else
                resultDataSet = GetDataList(SearchKeys.HIKIDASHIBI(0), SearchKeys.HIKIDASHIBI(1), SearchKeys.KUMIAIINCODE)
            End If

            ts.Complete()

        End Using

        Return resultDataSet

    End Function

    ''' <summary>
    ''' データ取得（組合員コードなし）
    ''' </summary>
    ''' <param name="dtmHIKIDASHIBIST"></param>
    ''' <param name="dtmHIKIDASHIBIED"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetDataList(ByVal dtmHIKIDASHIBIST As Date, ByVal dtmHIKIDASHIBIED As Date) As Model.SEN0070List

        Dim resultDataSet As New Model.SEN0070List
        Using masterAdapter As New Model.SEN0070ListTableAdapters.DataListTableAdapter, _
            connection As New System.Data.SqlClient.SqlConnection(connectionString)
            masterAdapter.Connection = connection : CommonUtility.DBUtility.SetCommandTimeout(masterAdapter)
            masterAdapter.Fill(resultDataSet.DataList, dtmHIKIDASHIBIST, dtmHIKIDASHIBIED)
        End Using
        Return resultDataSet

    End Function

    ''' <summary>
    ''' データ取得（組合員コードあり）
    ''' </summary>
    ''' <param name="dtmHIKIDASHIBIST"></param>
    ''' <param name="dtmHIKIDASHIBIED"></param>
    ''' <param name="strKUMIAIINCODE"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetDataList(ByVal dtmHIKIDASHIBIST As Date, ByVal dtmHIKIDASHIBIED As Date, ByVal strKUMIAIINCODE As String) As Model.SEN0070List

        Dim resultDataSet As New Model.SEN0070List
        Using masterAdapter As New Model.SEN0070ListTableAdapters.DataListTableAdapter, _
            connection As New System.Data.SqlClient.SqlConnection(connectionString)
            masterAdapter.Connection = connection : CommonUtility.DBUtility.SetCommandTimeout(masterAdapter)
            masterAdapter.FillByKUMIAIINCODE(resultDataSet.DataList, dtmHIKIDASHIBIST, dtmHIKIDASHIBIED, strKUMIAIINCODE)
        End Using
        Return resultDataSet

    End Function

End Class
