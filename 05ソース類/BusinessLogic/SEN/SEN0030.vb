Public Class SEN0030

    Private connectionString As String

    ''' <summary>
    ''' クラス初期化    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        connectionString = CommonUtility.DBUtility.GetConnectionString
    End Sub

    Public Function GetList() As Model.SEN0030List

        Dim resultDataSets As New Model.SEN0030List

        'Dim op As New System.Transactions.TransactionOptions
        'op.IsolationLevel = Transactions.IsolationLevel.Serializable

        'DAC作成
        Using masterAdapter As New Model.SEN0030ListTableAdapters.DataListTableAdapter, _
            connection As New System.Data.SqlClient.SqlConnection(connectionString)

            masterAdapter.Connection = connection
            CommonUtility.DBUtility.SetCommandTimeout(masterAdapter)

            masterAdapter.Fill(resultDataSets.DataList)

            'ts.Complete()

        End Using

        Return resultDataSets

    End Function

End Class
