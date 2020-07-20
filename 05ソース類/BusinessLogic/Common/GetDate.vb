Public Class GetDate

    Private connectionString As String

    ''' <summary>
    ''' クラス初期化    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        connectionString = CommonUtility.DBUtility.GetConnectionString
    End Sub

    Public Function GetServerDate() As Date

        Dim ds As New Data.DataSet
        Dim logic As New ExecuteQuery
        ds = logic.ExecuteDataset(connectionString, Data.CommandType.Text, "select getdate()")

        If ds.Tables(0).Rows.Count = 0 Then
            Return Now
        Else
            Return CType(ds.Tables(0).Rows(0)(0), Date)
        End If

    End Function
    Public Shared Function GetDate() As Date

        Dim ds As New Data.DataSet
        Dim logic As New ExecuteQuery
        ds = logic.ExecuteDataset(CommonUtility.DBUtility.GetConnectionString, Data.CommandType.Text, "select getdate()")

        If ds.Tables(0).Rows.Count = 0 Then
            Return Now
        Else
            Return CType(ds.Tables(0).Rows(0)(0), Date)
        End If

    End Function
End Class
