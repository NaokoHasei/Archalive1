Public Class daMENT0001

    Inherits BLL.Common.DAL.DALBase

    Public Function Read() As dsMENT0001.M_BUKADataTable

        Dim resultDataSet As New dsMENT0001.M_BUKADataTable

        Using adp As New dsMENT0001TableAdapters.M_BUKATableAdapter,
            connection As New System.Data.SqlClient.SqlConnection(connectionString)
            adp.Connection = connection : CommonUtility.DBUtility.SetCommandTimeout(adp)
            adp.Fill(resultDataSet)
        End Using

        Return resultDataSet

    End Function

    Public Function Read(ByVal strBUKACODE As String) As dsMENT0001.M_BUKARow

        Dim resultDataSet As New dsMENT0001.M_BUKADataTable

        Using adp As New dsMENT0001TableAdapters.M_BUKATableAdapter,
            connection As New System.Data.SqlClient.SqlConnection(connectionString)
            adp.Connection = connection : CommonUtility.DBUtility.SetCommandTimeout(adp)
            adp.FillByBUKACODE(resultDataSet, strBUKACODE)
        End Using

        If resultDataSet.Rows.Count = 0 Then
            Return Nothing
        Else
            Return resultDataSet.Item(0)
        End If

    End Function

    Friend Sub Delete(ByVal strBUKACODE As String)

        Dim logic As New BLL.Common.ExecuteQuery
        Dim strSQL As String = "delete from M_BUKA where BUKACODE=@BUKACODE"
        logic.ExecuteNonQuery(connectionString, CommandType.Text, strSQL, New SqlClient.SqlParameter() {New SqlClient.SqlParameter("@BUKACODE", strBUKACODE)})

    End Sub

    Friend Sub Entry(ByVal UpdateRow As dsMENT0001.M_BUKARow)

        Dim logic As New BLL.Common.ExecuteQuery

        Dim r As dsMENT0001.M_BUKARow = Read(UpdateRow.BUKACODE)
        If r Is Nothing Then
            Insert(UpdateRow)
        Else
            Update(UpdateRow)
        End If

    End Sub

    Private Sub Insert(ByVal row As dsMENT0001.M_BUKARow)

        Dim strSQL As String
        Dim logic As New BLL.Common.ExecuteQuery

        strSQL = "insert into M_BUKA values(@BUKACODE, @BUKANAME, getdate(), @UPDATEPGID, @UPDATEUSERCODE, getdate(), getdate())"
        logic.ExecuteNonQuery(connectionString, CommandType.Text, strSQL, New SqlClient.SqlParameter() {New SqlClient.SqlParameter("@BUKACODE", row.BUKACODE),
                                                                                                        New SqlClient.SqlParameter("@BUKANAME", row.BUKANAME),
                                                                                                        New SqlClient.SqlParameter("@UPDATEPGID", row.UPDATEPGID),
                                                                                                        New SqlClient.SqlParameter("@UPDATEUSERCODE", row.UPDATEUSERCODE)})
    End Sub

    Private Sub Update(ByVal row As dsMENT0001.M_BUKARow)

        Dim strSQL As String

        Dim logic As New BLL.Common.ExecuteQuery

        strSQL = "update M_BUKA set"
        strSQL += " BUKANAME=@BUKANAME"
        strSQL += ",UPDATEMENT=getdate()"
        strSQL += ",UPDATEPGID=@UPDATEPGID"
        strSQL += ",UPDATEUSERCODE=@UPDATEUSERCODE"
        strSQL += " where BUKACODE=@BUKACODE"

        logic.ExecuteNonQuery(connectionString, CommandType.Text, strSQL, New SqlClient.SqlParameter() {New SqlClient.SqlParameter("@BUKACODE", row.BUKACODE),
                                                                                                        New SqlClient.SqlParameter("@BUKANAME", row.BUKANAME),
                                                                                                        New SqlClient.SqlParameter("@UPDATEPGID", row.UPDATEPGID),
                                                                                                        New SqlClient.SqlParameter("@UPDATEUSERCODE", row.UPDATEUSERCODE)})

    End Sub

End Class
