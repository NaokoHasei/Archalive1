Public Class SEN0080

    Private connectionString As String

    ''' <summary>
    ''' クラス初期化    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        connectionString = CommonUtility.DBUtility.GetConnectionString
    End Sub

    ''' <summary>
    ''' データ取得
    ''' </summary>
    ''' <param name="intSYORIKBNST">処理区分（開始）</param>
    ''' <param name="intSYORIKBNED">処理区分（終了）</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetList(ByVal intSYORIKBNST As Integer, ByVal intSYORIKBNED As Integer) As Model.SEN0080List.DataListDataTable

        Dim resultDataSet As New Model.SEN0080List.DataListDataTable

        Dim op As New System.Transactions.TransactionOptions
        op.IsolationLevel = Transactions.IsolationLevel.ReadUncommitted

        'DAC作成
        Using masterAdapter As New Model.SEN0080ListTableAdapters.DataListTableAdapter, _
            connection As New System.Data.SqlClient.SqlConnection(connectionString), _
            ts As System.Transactions.TransactionScope = New System.Transactions.TransactionScope(Transactions.TransactionScopeOption.Required, op)

            masterAdapter.Connection = connection : CommonUtility.DBUtility.SetCommandTimeout(masterAdapter)

            masterAdapter.Fill(resultDataSet, CDec(intSYORIKBNST), CDec(intSYORIKBNED))

            ts.Complete()

        End Using

        Return resultDataSet

    End Function

End Class
