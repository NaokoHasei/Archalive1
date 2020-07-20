Imports System.Data.SqlClient
Imports System.Data
Imports CommonUtility

Public Class SEN0040

    Private connectionString As String

    ''' <summary>
    ''' クラス初期化
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        connectionString = CommonUtility.DBUtility.GetConnectionString
    End Sub
    Public Function GetList() As dsSEN0040.M_KENDataTable

        Dim resultDataSets As New dsSEN0040.M_KENDataTable

        Dim op As New System.Transactions.TransactionOptions
        op.IsolationLevel = Transactions.IsolationLevel.ReadUncommitted

        'DAC作成
        Using masterAdapter As New dsSEN0040TableAdapters.M_KENTableAdapter, _
            connection As New System.Data.SqlClient.SqlConnection(connectionString), _
            ts As System.Transactions.TransactionScope = New System.Transactions.TransactionScope(Transactions.TransactionScopeOption.Required, op)

            masterAdapter.Connection = connection : CommonUtility.DBUtility.SetCommandTimeout(masterAdapter)

            masterAdapter.Fill(resultDataSets)

            ts.Complete()

        End Using

        Return resultDataSets

    End Function

End Class
