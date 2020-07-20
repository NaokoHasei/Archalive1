Public Class SEN0010

    Private connectionString As String

    ''' <summary>
    ''' クラス初期化    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        connectionString = CommonUtility.DBUtility.GetConnectionString
    End Sub

    Public Function GetList() As Model.SEN0010List.DataListDataTable

        Dim resultDataSets As New Model.SEN0010List.DataListDataTable

        Dim op As New System.Transactions.TransactionOptions
        op.IsolationLevel = Transactions.IsolationLevel.Serializable

        'DAC作成
        Using masterAdapter As New Model.SEN0010ListTableAdapters.DataListTableAdapter, _
            connection As New System.Data.SqlClient.SqlConnection(connectionString), _
            ts As System.Transactions.TransactionScope = New System.Transactions.TransactionScope(Transactions.TransactionScopeOption.Required, op)

            masterAdapter.Connection = connection : CommonUtility.DBUtility.SetCommandTimeout(masterAdapter)
            masterAdapter.Fill(resultDataSets)

            ts.Complete()

        End Using

        Return resultDataSets


    End Function

End Class
