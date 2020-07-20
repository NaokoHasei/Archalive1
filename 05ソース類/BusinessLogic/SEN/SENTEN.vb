Public Class SENTEN

    Implements BLL.Common.IBusinessLogic



    Private connectionString As String

    ''' <summary>
    ''' クラス初期化    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        connectionString = CommonUtility.DBUtility.GetConnectionString
    End Sub

    Public Function Execute(ByVal requestParam As Common.DTO.RequestSentakuKey) As System.Data.DataSet Implements Common.IBusinessLogic.Execute
        Dim resultDataSets As New BLL.Common.dsSENTAKU.WT_SENTENDataTable

        Dim op As New System.Transactions.TransactionOptions
        op.IsolationLevel = Transactions.IsolationLevel.Serializable

        'DAC作成
        Using masterAdapter As New BLL.Common.dsSENTAKUTableAdapters.WT_SENTENTableAdapter, _
            connection As New System.Data.SqlClient.SqlConnection(connectionString), _
            ts As System.Transactions.TransactionScope = New System.Transactions.TransactionScope(Transactions.TransactionScopeOption.Required, op)

            masterAdapter.Connection = connection : CommonUtility.DBUtility.SetCommandTimeout(masterAdapter)
            masterAdapter.Fill(resultDataSets, requestParam.PCNAMEKey, requestParam.PGCODEKey, requestParam.FULINOKey)

            ts.Complete()

        End Using

        Return resultDataSets.DataSet
    End Function
End Class
