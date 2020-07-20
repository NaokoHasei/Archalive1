Imports System.Data.SqlClient
Imports BLL.Common

Public Class daMENT0006
    Inherits DAL.DALBase

    ''' <summary>
    ''' 仕入先マスタから最大仕入先コード取得
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ReadM_SIIREMAX() As dsMENT0006.M_SIIREMAXDataTable

        Dim resultDataSet As New dsMENT0006.M_SIIREMAXDataTable
        Using ItemAdapter As New dsMENT0006TableAdapters.M_SIIREMAXTableAdapter,
            connection As New SqlConnection(connectionString)
            ItemAdapter.Connection = connection : CommonUtility.DBUtility.SetCommandTimeout(ItemAdapter)
            ItemAdapter.Fill(resultDataSet)
        End Using
        Return resultDataSet

    End Function

    ''' <summary>
    ''' 仕入先マスタから委託コードの最小空き番取得
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ReadITAKUCODEMIN() As dsMENT0006.ITAKUCODEMINDataTable

        Dim resultDataSet As New dsMENT0006.ITAKUCODEMINDataTable
        Using ItemAdapter As New dsMENT0006TableAdapters.ITAKUCODEMINTableAdapter,
            connection As New SqlConnection(connectionString)
            ItemAdapter.Connection = connection : CommonUtility.DBUtility.SetCommandTimeout(ItemAdapter)
            ItemAdapter.Fill(resultDataSet)
        End Using
        Return resultDataSet

    End Function

    ''' <summary>
    ''' テーブルにデータが存在するか確認
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ExistM_SIIREbyItakuCode(ByVal strItakuCode As String, ByVal strSiireCode As String) As Boolean
        Dim logic As New ExecuteQuery
        Dim strSQL As String
        Dim ds As System.Data.DataSet

        '初期化
        ExistM_SIIREbyItakuCode = False

        strSQL = vbNullString
        strSQL = strSQL & "SELECT * " & vbCrLf
        strSQL = strSQL & "FROM M_SIIRE " & vbCrLf
        strSQL = strSQL & "WHERE ITAKUCODE = @ITAKUCODE " & vbCrLf
        strSQL = strSQL & "  AND SIIRECODE <> @SIIRECODE " & vbCrLf

        ds = logic.ExecuteDataset(connectionString, CommandType.Text, strSQL, New SqlParameter() {New SqlParameter("@ITAKUOCDE", strItakuCode), New SqlParameter("@SIIRECODE", strSiireCode)})

        If ds.Tables(0).Rows.Count > 0 Then Return True

    End Function

    Public Sub UpdateTable(ByVal UpdateData As dtBUK0004.dtMENT0006)
        Dim logic As New ExecuteQuery
        Dim connection As SqlConnection = New SqlConnection(connectionString)
        Dim strSQL As String

        Using ts As System.Transactions.TransactionScope = New System.Transactions.TransactionScope

            With UpdateData

                'マスタ存在確認
                Dim M_SIIRE As New M_SIIRERead(.SIIRECODE)
                Dim dt As dsM_SIIRE.M_SIIREDataTable = M_SIIRE.GetM_SIIRE.M_SIIRE
                If Not dt.Rows.Count > 0 Then
                    strSQL = "insert into M_SIIRE (SIIRECODE,CDATE) " & vbCrLf
                    strSQL += "values (@SIIRECODE,getdate()) " & vbCrLf
                    'マスタ更新
                    logic.ExecuteNonQuery(connection, CommandType.Text, strSQL, New SqlParameter() {New SqlParameter("@SIIRECODE", .SIIRECODE)})
                End If

                strSQL = "update M_SIIRE set " & vbCrLf
                strSQL += " SIIRENAME = @SIIRENAME" & vbCrLf
                strSQL += ",RYAKUNAME = @RYAKUNAME" & vbCrLf
                strSQL += ",MENUKEY = @MENUKEY" & vbCrLf
                strSQL += ",POSTNO = @POSTNO" & vbCrLf
                strSQL += ",ADDRESS = @ADDRESS" & vbCrLf
                strSQL += ",ADDRESS1 = @ADDRESS1" & vbCrLf
                strSQL += ",ADDRESS2 = @ADDRESS2" & vbCrLf
                strSQL += ",TELNO = @TELNO" & vbCrLf
                strSQL += ",FAXNO = @FAXNO" & vbCrLf
                strSQL += ",TANTOCODE = @TANTOCODE" & vbCrLf
                strSQL += ",SIMEBI1 = @SIMEBI1" & vbCrLf
                strSQL += ",SIHARAIKBN1 = @SIHARAIKBN1" & vbCrLf
                strSQL += ",SIHARAIBI1 = @SIHARAIBI1" & vbCrLf
                strSQL += ",ZEIROUND = @ZEIROUND" & vbCrLf
                strSQL += ",SUROUND = @SUROUND" & vbCrLf
                strSQL += ",KINROUND = @KINROUND" & vbCrLf
                strSQL += ",ZEIKBN = @ZEIKBN" & vbCrLf
                strSQL += ",KENSYU_DEKIDAKA = @KENSYU_DEKIDAKA" & vbCrLf
                strSQL += ",SIHARAI_GENKINRITU = @SIHARAI_GENKINRITU" & vbCrLf
                strSQL += ",SIHARAI_TEGATARITU = @SIHARAI_TEGATARITU" & vbCrLf
                strSQL += ",SITE = @SITE" & vbCrLf
                strSQL += ",DAIHYONAME = @DAIHYONAME" & vbCrLf
                strSQL += ",KEISYOUCODE = @KEISYOUCODE" & vbCrLf
                strSQL += "where SIIRECODE = @SIIRECODE" & vbCrLf
                'マスタ更新
                logic.ExecuteNonQuery(connection, CommandType.Text, strSQL, New SqlParameter() {
                    New SqlParameter("@SIIRECODE", .SIIRECODE), New SqlParameter("@SIIRENAME", .SIIRENAME),
                    New SqlParameter("@RYAKUNAME", .RYAKUNAME), New SqlParameter("@MENUKEY", .MENUKEY),
                    New SqlParameter("@POSTNO", .POSTNO), New SqlParameter("@ADDRESS", .ADDRESS),
                    New SqlParameter("@ADDRESS1", .ADDRESS1), New SqlParameter("@ADDRESS2", .ADDRESS2),
                    New SqlParameter("@ITAKUCODE", .ITAKUCODE), New SqlParameter("@MAILADDRESS", .MAILADDRESS),
                    New SqlParameter("@MAILACCOUNT", .MAILACCOUNT), New SqlParameter("@MAILDOMAINNAME", .MAILDOMAINNAME),
                    New SqlParameter("@MAILSENDFLG", CType(.MAILSENDFLG, Integer)), New SqlParameter("@MAILADDRESS1", .MAILADDRESS1),
                    New SqlParameter("@MAILACCOUNT1", .MAILACCOUNT1), New SqlParameter("@MAILDOMAINNAME1", .MAILDOMAINNAME1),
                    New SqlParameter("@MAILSENDFLG1", CType(.MAILSENDFLG1, Integer)), New SqlParameter("@MAILDISPFLG", CType(.MAILDISPFLG, Integer)),
                    New SqlParameter("@MAILTANKADISPFLG", CType((.MAILTANKADISPFLG), Integer)), New SqlParameter("@MAILSENDOBJECTKBN", CType(.MAILSENDOBJECTKBN, Integer)),
                    New SqlParameter("@PRICEPRIKBN", CType(.PRICEPRIKBN, Integer)), New SqlParameter("@LABEL_NAME", .LABEL_NAME),
                    New SqlParameter("@LABEL_TELNO", .LABEL_TELNO), New SqlParameter("@TELNO", .TELNO),
                    New SqlParameter("@FAXNO", .FAXNO), New SqlParameter("@TELNO_K", .TELNO_K),
                    New SqlParameter("@GINKOU", .GINKOU), New SqlParameter("@BANKCODE", .BANKCODE),
                    New SqlParameter("@BANKSUBCODE", .BANKSUBCODE), New SqlParameter("@BANKKOUZAKBN", .BANKKOUZAKBN),
                    New SqlParameter("@KOUZA", .KOUZA), New SqlParameter("@BANKMEIGI", .BANKMEIGI),
                    New SqlParameter("@BANKMEIGIKANA", .BANKMEIGIKANA), New SqlParameter("@LOCALCODE", .LOCALCODE),
                    New SqlParameter("@TANKACODE", .TANKACODE), New SqlParameter("@SIHARAICODE", .SIHARAICODE),
                    New SqlParameter("@SOSINCODE", .SOSINCODE), New SqlParameter("@TANTOCODE", .TANTOCODE),
                    New SqlParameter("@SIMEBI1", .SIMEBI1), New SqlParameter("@SIMEBI2", .SIMEBI2),
                    New SqlParameter("@SIMEBI3", .SIMEBI3), New SqlParameter("@SIHARAIKBN1", .SIHARAIKBN1),
                    New SqlParameter("@SIHARAIKBN2", .SIHARAIKBN2), New SqlParameter("@SIHARAIKBN3", .SIHARAIKBN3),
                    New SqlParameter("@SIHARAIBI1", .SIHARAIBI1), New SqlParameter("@SIHARAIBI2", .SIHARAIBI2),
                    New SqlParameter("@SIHARAIBI3", .SIHARAIBI3), New SqlParameter("@SEISANTINAME", .SEISANTINAME),
                    New SqlParameter("@ZEIROUND", .ZEIROUND), New SqlParameter("@SUROUND", .SUROUND),
                    New SqlParameter("@KINROUND", .KINROUND), New SqlParameter("@SYOHIZEIKBN", .SYOHIZEIKBN),
                    New SqlParameter("@ZANKANRIKBN", .ZANKANRIKBN), New SqlParameter("@GENKAKAKIKAEKBN", .GENKAKAKIKAEKBN),
                    New SqlParameter("@ZEIKBN", .ZEIKBN), New SqlParameter("@SOSINFLG", .SOSINFLG),
                    New SqlParameter("@TESURITU_1", .TESURITU_1), New SqlParameter("@TESURITU_2", .TESURITU_2),
                    New SqlParameter("@YOSAN01", .YOSAN01), New SqlParameter("@YOSAN02", .YOSAN02),
                    New SqlParameter("@YOSAN03", .YOSAN03), New SqlParameter("@YOSAN04", .YOSAN04),
                    New SqlParameter("@YOSAN05", .YOSAN05), New SqlParameter("@YOSAN06", .YOSAN06),
                    New SqlParameter("@YOSAN07", .YOSAN07), New SqlParameter("@YOSAN08", .YOSAN08),
                    New SqlParameter("@YOSAN09", .YOSAN09), New SqlParameter("@YOSAN10", .YOSAN10),
                    New SqlParameter("@YOSAN11", .YOSAN11), New SqlParameter("@YOSAN12", .YOSAN12),
                    New SqlParameter("@ENDSIIDATE", .ENDSIIDATE), New SqlParameter("@KEIYAKUDATE", .KEIYAKUDATE),
                    New SqlParameter("@KENSYU_DEKIDAKA", .KENSYU_DEKIDAKA), New SqlParameter("@SIHARAI_GENKINRITU", .SIHARAI_GENKINRITU),
                    New SqlParameter("@SIHARAI_TEGATARITU", .SIHARAI_TEGATARITU), New SqlParameter("@DAIHYONAME", .DAIHYONAME),
                    New SqlParameter("@SITE", .SITE),
                    New SqlParameter("@KEISYOUCODE", .KEISYOUCODE)})

                Dim strTANKANAME As String = ""

                ts.Complete()

            End With

        End Using
    End Sub

    ''' <summary>
    ''' マスタ削除
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub DeleteTable(ByVal strPrimaryKey As String)
        Dim logic As New ExecuteQuery
        Dim connection As SqlConnection = New SqlConnection(connectionString)
        Dim strSQL As String

        Using ts As System.Transactions.TransactionScope = New System.Transactions.TransactionScope

            strSQL = "delete from M_SIIRE where SIIRECODE = @SIIRECODE"
            logic.ExecuteNonQuery(connectionString, CommandType.Text, strSQL, New SqlClient.SqlParameter() {New SqlClient.SqlParameter("@SIIRECODE", strPrimaryKey)})

            ts.Complete()

        End Using
    End Sub

    ''' <summary>
    ''' レコード移動
    ''' </summary>
    ''' <param name="MoveCommand">移動コマンド</param>
    ''' <param name="strPrimaryKey">検索キー</param>
    ''' <param name="strPCNAME">PC名</param>
    ''' <param name="PROGRAM_ID">プログラムID</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function RecordMove(ByVal MoveCommand As String, ByVal strPrimaryKey As String, ByVal strPCNAME As String, ByVal PROGRAM_ID As String) As String
        Dim logic As New ExecuteQuery
        Dim dt As System.Data.DataTable = Nothing

        Dim TABLENAME As String = "M_SIIRE"
        Dim INDEXFIELD As String = "SIIRECODE"
        Dim strWhere As String

        'Where文の作成
        strWhere = "where (1 = 1) "
        RecordMove = ""
        Select Case MoveCommand
            Case "先頭へ"
                dt = logic.ExecuteDataset(
                      connectionString _
                    , CommandType.Text _
                    , "select * from " & TABLENAME & " B, " &
                      "( " &
                      "select IsNull(min(" & INDEXFIELD & "),'') as TARGET_INDEX from " & TABLENAME & " " &
                      ") A " &
                      "where A.TARGET_INDEX = B." & INDEXFIELD & " ").Tables(0)

            Case "前へ"
                dt = logic.ExecuteDataset(
                      connectionString _
                    , CommandType.Text _
                    , "select IsNull(max(" & INDEXFIELD & "),'') from " & TABLENAME & " B, " &
                      "( " &
                      "select IsNull(max(" & INDEXFIELD & "),'') as TARGET_INDEX from " & TABLENAME & " " & strWhere & " " &
                      "and " & INDEXFIELD & " < '" & strPrimaryKey & "' " &
                      ") A " &
                      "where A.TARGET_INDEX = B." & INDEXFIELD & "").Tables(0)

            Case "次へ"
                dt = logic.ExecuteDataset(
                      connectionString _
                    , CommandType.Text _
                    , "select IsNull(min(" & INDEXFIELD & "),'') from " & TABLENAME & " B, " &
                      "( " &
                      "select IsNull(min(" & INDEXFIELD & "),'') as TARGET_INDEX from " & TABLENAME & " " & strWhere & " " &
                      "and " & INDEXFIELD & " > '" & strPrimaryKey & "' " &
                      ") A " &
                      "where A.TARGET_INDEX = B." & INDEXFIELD & "").Tables(0)

            Case "最後へ"
                dt = logic.ExecuteDataset(
                      connectionString _
                    , CommandType.Text _
                    , "select * from " & TABLENAME & " B, " &
                      "( " &
                      "select IsNull(max(" & INDEXFIELD & "),'') as TARGET_INDEX from " & TABLENAME & " " &
                      ") A " &
                      "where A.TARGET_INDEX = B." & INDEXFIELD & " ").Tables(0)
        End Select

        If dt.Rows.Count > 0 Then
            RecordMove = dt.Rows(0)(0).ToString
        Else
            RecordMove = vbNullString
        End If

        Return RecordMove
    End Function

End Class
