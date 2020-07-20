Public Class daMSE0010

    Inherits BLL.Common.DAL.DALBase

    Public Shared Function ReadPCNAMEList() As dsMSE0010.PCNAMEInfoDataTable

        Dim resultDataSet As New dsMSE0010.PCNAMEInfoDataTable

        Using adp As New dsMSE0010TableAdapters.PCNAMEInfoTableAdapter,
            connection As New System.Data.SqlClient.SqlConnection(CommonUtility.DBUtility.GetConnectionString)
            adp.Connection = connection : CommonUtility.DBUtility.SetCommandTimeout(adp)
            adp.Fill(resultDataSet)
        End Using

        Return resultDataSet

    End Function

    Public Shared Function ReadS_SYSTEMList(ByVal strPCNAME As String) As dsMSE0010.S_SYSTEMDataTable

        Dim resultDataSet As New dsMSE0010.S_SYSTEMDataTable

        Using adp As New dsMSE0010TableAdapters.S_SYSTEMTableAdapter,
            connection As New System.Data.SqlClient.SqlConnection(CommonUtility.DBUtility.GetConnectionString)
            adp.Connection = connection : CommonUtility.DBUtility.SetCommandTimeout(adp)

            adp.FillByPCNAME(resultDataSet, strPCNAME)
            If resultDataSet.Rows.Count = 0 Then
                adp.FillByPCNAME(resultDataSet, "default")
            End If

        End Using

        Return resultDataSet

    End Function

    Private Shared Function ReadExistsS_SYSTEM(ByVal strPCNAME As String) As Boolean

        Dim ds As System.Data.DataSet = BLL.Common.GetDbValue.Execute("S_SYSTEM", "top 1 *", "PCNAME='" + strPCNAME + "'")
        Return (ds.Tables(0).Rows.Count <> 0)

    End Function

    'マスタ削除
    Friend Sub Delete(ByVal strPCNAME As String)

        Dim logic As New BLL.Common.ExecuteQuery
        Dim strSQL As String = ""
        strSQL += "delete from S_SYSTEM where PCNAME=@PCNAME;"

        logic.ExecuteNonQuery(connectionString, CommandType.Text, strSQL, New SqlClient.SqlParameter() {New SqlClient.SqlParameter("@PCNAME", strPCNAME)})

    End Sub

    Friend Sub DefaultCreate(ByVal strPCNAME As String, ByVal UpdateDataTable As dsMSE0010.UpdateListDataTable)

        Dim logic As New BLL.Common.ExecuteQuery
        Dim strSQL As String = ""
        strSQL += "delete from S_SYSTEM where PCNAME=@PCNAME;"

        Using ts As System.Transactions.TransactionScope = New System.Transactions.TransactionScope
            Dim conn As System.Data.SqlClient.SqlConnection = New System.Data.SqlClient.SqlConnection(connectionString)
            logic.ExecuteNonQuery(conn, CommandType.Text, strSQL, New SqlClient.SqlParameter() {New SqlClient.SqlParameter("@PCNAME", strPCNAME)})
            Insert(UpdateDataTable)
            ts.Complete()
        End Using

    End Sub

    '追加・更新処理
    Friend Sub Entry(ByVal strPCNAME As String, ByVal UpdateDataTable As dsMSE0010.UpdateListDataTable)

        'Dim logic As New BLL.Common.ExecuteQuery

        Delete(strPCNAME)
        Insert(UpdateDataTable)

        'If ReadExistsS_SYSTEM(strPCNAME) Then
        '    Update(UpdateDataTable)
        'Else
        '    Insert(UpdateDataTable)
        'End If

    End Sub

    '追加クエリ
    Private Sub Insert(ByVal dt As dsMSE0010.UpdateListDataTable)

        Dim strSQL As String
        Dim logic As New BLL.Common.ExecuteQuery

        strSQL = "insert into S_SYSTEM"
        'strSQL += "( USERCODE, PROGRAMCODE, PROGRAMNAME, JIKOUKBN, SYUTURYOKUKBN, DISPNO,CDATE,     UDATE)"
        strSQL += " values "
        strSQL += "(@PCNAME,@SYSTEMFILE,@SYSTEMFILEINFO,@SECTIONNAME,@SECTIONNAMEINFO,@PROPERTYNAME,@PROPERTYNAMEINFO,@VALUE,@UPDATEPGID,@UPDATEUSERCODE,getdate(), getdate())"

        For Each r As dsMSE0010.UpdateListRow In dt
            logic.ExecuteNonQuery(connectionString, CommandType.Text, strSQL, New SqlClient.SqlParameter() {New SqlClient.SqlParameter("@PCNAME", r.PCNAME),
                                                                                                            New SqlClient.SqlParameter("@SYSTEMFILE", r.SYSTEMFILE),
                                                                                                            New SqlClient.SqlParameter("@SYSTEMFILEINFO", r.SYSTEMFILEINFO),
                                                                                                            New SqlClient.SqlParameter("@SECTIONNAME", r.SECTIONNAME),
                                                                                                            New SqlClient.SqlParameter("@SECTIONNAMEINFO", r.SECTIONNAMEINFO),
                                                                                                            New SqlClient.SqlParameter("@PROPERTYNAME", r.PROPERTYNAME),
                                                                                                            New SqlClient.SqlParameter("@PROPERTYNAMEINFO", r.PROPERTYNAMEINFO),
                                                                                                            New SqlClient.SqlParameter("@VALUE", r.VALUE),
                                                                                                            New SqlClient.SqlParameter("@UPDATEPGID", r.UPDATEPGID),
                                                                                                            New SqlClient.SqlParameter("@UPDATEUSERCODE", r.UPDATEUSERCODE)})
        Next

    End Sub

    '更新クエリ
    Private Sub Update(ByVal dt As dsMSE0010.UpdateListDataTable)

        'Dim strSQL As String

        'Dim logic As New BLL.Common.ExecuteQuery

        'strSQL = "update M_PROGRAMCONDISION set"
        'strSQL += " JIKOUKBN     =@JIKOUKBN"
        'strSQL += ",SYUTURYOKUKBN=@SYUTURYOKUKBN"
        'strSQL += " where USERCODE   =@USERCODE"
        'strSQL += "   and PROGRAMCODE=@PROGRAMCODE"

        'For Each r As DataSet.UpdateListRow In dt
        '    logic.ExecuteNonQuery(connectionString, CommandType.Text, strSQL, New SqlClient.SqlParameter() {New SqlClient.SqlParameter("@USERCODE", r.USERCODE), _
        '                                                                                                    New SqlClient.SqlParameter("@PROGRAMCODE", r.PROGRAMCODE), _
        '                                                                                                    New SqlClient.SqlParameter("@JIKOUKBN", r.JIKOUKBN), _
        '                                                                                                    New SqlClient.SqlParameter("@SYUTURYOKUKBN", r.SYUTURYOKUKBN)})
        'Next

    End Sub

End Class
