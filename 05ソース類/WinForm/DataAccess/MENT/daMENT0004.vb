Public Class daMENT0004

    Inherits BLL.Common.DAL.DALBase

    Public Function ReadTANTO() As dsMENT0004.M_TANTODataTable

        Dim resultDataSet As New dsMENT0004.M_TANTODataTable

        Using adp As New dsMENT0004TableAdapters.M_TANTOTableAdapter,
            connection As New SqlClient.SqlConnection(connectionString)
            adp.Connection = connection : CommonUtility.DBUtility.SetCommandTimeout(adp)
            adp.Fill(resultDataSet)
        End Using

        Return resultDataSet

    End Function

    Public Function ReadTANTO(ByVal strTANTOCODE As String) As dsMENT0004.M_TANTODataTable

        Dim resultDataSet As New dsMENT0004.M_TANTODataTable

        Using adp As New dsMENT0004TableAdapters.M_TANTOTableAdapter,
            connection As New SqlClient.SqlConnection(connectionString)
            adp.Connection = connection : CommonUtility.DBUtility.SetCommandTimeout(adp)
            adp.FillBy(resultDataSet, strTANTOCODE)
        End Using

        Return resultDataSet

    End Function

    Public Function ReadBUKA(ByVal strBUKACODE As String) As dsMENT0004.M_BUKADataTable

        Dim resultDataSet As New dsMENT0004.M_BUKADataTable

        Using adp As New dsMENT0004TableAdapters.M_BUKATableAdapter,
            connection As New SqlClient.SqlConnection(connectionString)
            adp.Connection = connection : CommonUtility.DBUtility.SetCommandTimeout(adp)
            adp.Fill(resultDataSet, strBUKACODE)
        End Using

        Return resultDataSet

    End Function

    Public Function RecordMove(ByVal MoveCommand As String, ByVal strPrimaryKey As String, ByVal strPCNAME As String, ByVal PROGRAM_ID As String) As String
        Dim logic As New BLL.Common.ExecuteQuery
        Dim dt As DataTable = Nothing

        Dim TABLENAME As String = "M_TANTO"
        Dim INDEXFIELD As String = "TANTOCODE"
        Dim strWhere As String

        'Where文の作成
        strWhere = "where (1 = 1) "
        RecordMove = ""
        Select Case MoveCommand
            Case "先頭へ"
                dt = logic.ExecuteDataset(connectionString, CommandType.Text, "select * from " & TABLENAME & " B, " & _
                                                                              "( " & _
                                                                              "select IsNull(min(" & INDEXFIELD & "),'') as TARGET_INDEX from " & TABLENAME & " " & _
                                                                              ") A " & _
                                                                              "where A.TARGET_INDEX = B." & INDEXFIELD & " ").Tables(0)
            Case "前へ"
                dt = logic.ExecuteDataset(connectionString, CommandType.Text, "select IsNull(max(" & INDEXFIELD & "),'') from " & TABLENAME & " B, " & _
                                                                              "( " & _
                                                                              "select IsNull(max(" & INDEXFIELD & "),'') as TARGET_INDEX from " & TABLENAME & " " & strWhere & " " & _
                                                                              "and " & INDEXFIELD & " < '" & strPrimaryKey & "' " & _
                                                                              ") A " & _
                                                                              "where A.TARGET_INDEX = B." & INDEXFIELD & "").Tables(0)
            Case "次へ"
                dt = logic.ExecuteDataset(connectionString, CommandType.Text, "select IsNull(min(" & INDEXFIELD & "),'') from " & TABLENAME & " B, " & _
                                                                              "( " & _
                                                                              "select IsNull(min(" & INDEXFIELD & "),'') as TARGET_INDEX from " & TABLENAME & " " & strWhere & " " & _
                                                                              "and " & INDEXFIELD & " > '" & strPrimaryKey & "' " & _
                                                                              ") A " & _
                                                                              "where A.TARGET_INDEX = B." & INDEXFIELD & "").Tables(0)
            Case "最後へ"
                dt = logic.ExecuteDataset(connectionString, CommandType.Text, "select * from " & TABLENAME & " B, " & _
                                                                              "( " & _
                                                                              "select IsNull(max(" & INDEXFIELD & "),'') as TARGET_INDEX from " & TABLENAME & " " & _
                                                                              ") A " & _
                                                                              "where A.TARGET_INDEX = B." & INDEXFIELD & " ").Tables(0)
        End Select

        If dt.Rows.Count > 0 Then
            RecordMove = dt.Rows(0)(0).ToString
        Else
            RecordMove = vbNullString
        End If

        Return RecordMove
    End Function


    Friend Sub Delete(ByVal strTANTOCODE As String)

        Dim logic As New BLL.Common.ExecuteQuery
        Dim strSQL As String = "delete from M_TANTO where TANTOCODE=@TANTOCODE"
        logic.ExecuteNonQuery(connectionString, CommandType.Text, strSQL, New SqlClient.SqlParameter() {New SqlClient.SqlParameter("@TANTOCODE", strTANTOCODE)})

    End Sub

    Friend Sub Insert(ByVal form As frmMENT0004)

        Dim strSQL As String
        Dim logic As New BLL.Common.ExecuteQuery

        'マスタ存在確認

        If Not ReadTANTO(form.txtTANTOCODE.Text).Rows.Count > 0 Then
            strSQL = "insert into M_TANTO (TANTOCODE,SIYOKINOU_AUTHORITY,UPDATEPGID,UPDATEUSERCODE,CDATE) " & vbCrLf
            strSQL += "values (@TANTOCODE,@SIYOKINOU_AUTHORITY,@UPDATEPGID,@UPDATEUSERCODE,getdate()) " & vbCrLf
            'マスタ更新
            logic.ExecuteNonQuery(connectionString, CommandType.Text, strSQL, New SqlClient.SqlParameter() {
                New SqlClient.SqlParameter("@TANTOCODE", form.txtTANTOCODE.Text),
                New SqlClient.SqlParameter("@SIYOKINOU_AUTHORITY", form.txtKengenCode.Text),
                New SqlClient.SqlParameter("@UPDATEPGID", form.PROGRAM_ID),
                New SqlClient.SqlParameter("@UPDATEUSERCODE", form.TANTO_CODE)
             })
        End If

        strSQL = "update M_TANTO set " & vbCrLf
        strSQL += " TANTONAME           = @TANTONAME" & vbCrLf
        strSQL += ",TANTOKANA           = @TANTOKANA" & vbCrLf
        strSQL += ",BUKACODE            = @BUKACODE" & vbCrLf
        strSQL += ",PASSWORD            = @PASSWORD" & vbCrLf
        strSQL += ",SIYOKINOU_AUTHORITY = @SIYOKINOU_AUTHORITY" & vbCrLf
        strSQL += ",UPDATEPGID          = @UPDATEPGID" & vbCrLf
        strSQL += ",UPDATEUSERCODE      = @UPDATEUSERCODE " & vbCrLf
        strSQL += "where TANTOCODE      = @TANTOCODE" & vbCrLf
        logic.ExecuteNonQuery(connectionString, CommandType.Text, strSQL, New SqlClient.SqlParameter() {
            New SqlClient.SqlParameter("@TANTOCODE", form.txtTANTOCODE.Text),
            New SqlClient.SqlParameter("@TANTONAME", form.txtTANTONAME.Text),
            New SqlClient.SqlParameter("@TANTOKANA", form.txtTANTOKANA.Text),
            New SqlClient.SqlParameter("@BUKACODE", form.txtBUKACODE.Text),
            New SqlClient.SqlParameter("@PASSWORD", form.txtPassword.Text),
            New SqlClient.SqlParameter("@SIYOKINOU_AUTHORITY", form.txtKengenCode.Text),
            New SqlClient.SqlParameter("@UPDATEPGID", form.PROGRAM_ID),
            New SqlClient.SqlParameter("@UPDATEUSERCODE", form.TANTO_CODE)
        })
    End Sub

End Class
