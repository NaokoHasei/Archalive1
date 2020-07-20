Imports System.Data.SqlClient
Imports BLL.Common

Public Class daMENT0005
    Inherits BLL.Common.DAL.DALBase

    Public Sub UpdateTable(ByRef UpdateData As dtMENT0005.MENT0005)
        Dim logic As New BLL.Common.ExecuteQuery
        Dim M_TOKUI As New M_TOKUIread
        Dim connection As SqlConnection = New SqlConnection(connectionString)
        Dim strSQL As String

        Using ts As System.Transactions.TransactionScope = New System.Transactions.TransactionScope

            With UpdateData

                '得意先コードが空の場合は得意先コードを発番する
                If .TOKUICODE = "" Then

                    Dim dsTOKUICODE As System.Data.DataSet = logic.ExecuteDataset(connection.ConnectionString, CommandType.Text, "select right('00000000'+convert(varchar,convert(decimal,isnull(max(TOKUICODE),'0'))+1),8) from M_TOKUI")
                    If dsTOKUICODE.Tables(0).Rows.Count = 0 OrElse dsTOKUICODE.Tables(0).Rows(0)(0).ToString = "00000000" Then
                        Throw New ApplicationException("顧客コードの空き番が存在しません。" & vbCrLf & "コード取得に失敗しました。")
                    Else
                        .TOKUICODE = dsTOKUICODE.Tables(0).Rows(0)(0).ToString
                    End If

                End If

                'マスタ存在確認
                If Not M_TOKUI.ReadM_TOKUI(.TOKUICODE).Rows.Count > 0 Then
                    strSQL = "insert into M_TOKUI (TOKUICODE,CDATE) " & vbCrLf
                    strSQL += "values (@TOKUICODE,getdate()) " & vbCrLf
                    'マスタ更新
                    logic.ExecuteNonQuery(connection, CommandType.Text, strSQL, New SqlParameter() {New SqlParameter("@TOKUICODE", .TOKUICODE)})
                End If

                strSQL = "update M_TOKUI set " & vbCrLf
                strSQL += " TOKUINAME          = @TOKUINAME" & vbCrLf
                strSQL += ",RYAKUNAME          = @RYAKUNAME" & vbCrLf
                strSQL += ",MENUKEY            = @MENUKEY" & vbCrLf
                strSQL += ",POSTNO             = @POSTNO" & vbCrLf
                strSQL += ",ADDRESS            = @ADDRESS" & vbCrLf
                strSQL += ",ADDRESS1           = @ADDRESS1" & vbCrLf
                strSQL += ",ADDRESS2           = @ADDRESS2" & vbCrLf
                strSQL += ",TELNO              = @TELNO" & vbCrLf
                strSQL += ",FAXNO              = @FAXNO" & vbCrLf
                strSQL += ",TANTOCODE          = @TANTOCODE" & vbCrLf
                strSQL += ",ZEIROUND           = @ZEIROUND" & vbCrLf
                strSQL += ",ZEIKBN             = @ZEIKBN" & vbCrLf
                strSQL += ",AITE_BUSYONAME = @AITE_BUSYONAME" & vbCrLf
                strSQL += ",AITE_TANTONAME = @AITE_TANTONAME" & vbCrLf
                strSQL += ",SIHARAIBI          = @SIHARAIBI" & vbCrLf
                strSQL += ",SIHARAI_GENKINRITU = @SIHARAI_GENKINRITU" & vbCrLf
                strSQL += ",SIHARAI_TEGATARITU = @SIHARAI_TEGATARITU" & vbCrLf
                strSQL += ",SITE               = @SITE" & vbCrLf
                strSQL += ",KEISYOUCODE               = @KEISYOUCODE" & vbCrLf
                strSQL += "where TOKUICODE = @TOKUICODE" & vbCrLf

                'マスタ更新
                logic.ExecuteNonQuery(connection, CommandType.Text, strSQL, New SqlParameter() {
                    New SqlParameter("@TOKUICODE", .TOKUICODE), New SqlParameter("@TOKUINAME", .TOKUINAME),
                    New SqlParameter("@RYAKUNAME", .RYAKUNAME), New SqlParameter("@MENUKEY", .MENUKEY),
                    New SqlParameter("@POSTNO", .POSTNO), New SqlParameter("@ADDRESS", .ADDRESS),
                    New SqlParameter("@ADDRESS1", .ADDRESS1), New SqlParameter("@ADDRESS2", .ADDRESS2),
                    New SqlParameter("@TELNO", .TELNO), New SqlParameter("@FAXNO", .FAXNO),
                    New SqlParameter("@TANTOCODE", .TANTOCODE),
                    New SqlParameter("@ZEIROUND", .ZEIROUND),
                    New SqlParameter("@ZEIKBN", .ZEIKBN),
                    New SqlParameter("@AITE_BUSYONAME", .AITE_BUSYONAME),
                    New SqlParameter("@AITE_TANTONAME", .AITE_TANTONAME),
                    New SqlParameter("@SIHARAIBI", .SIHARAIBI),
                    New SqlParameter("@SIHARAI_GENKINRITU", .SIHARAI_GENKINRITU),
                    New SqlParameter("@SIHARAI_TEGATARITU", .SIHARAI_TEGATARITU),
                    New SqlParameter("@SITE", .SITE),
                    New SqlParameter("@KEISYOUCODE", .KEISYOUCODE)
                })

                ts.Complete()

            End With

        End Using
    End Sub

    ''' <summary>
    ''' マスタ削除
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub DeleteTable(ByVal strPrimaryKey As String)
        Dim logic As New BLL.Common.ExecuteQuery
        Dim connection As SqlConnection = New SqlConnection(connectionString)
        Dim strSQL As String

        Using ts As System.Transactions.TransactionScope = New System.Transactions.TransactionScope

            strSQL = "delete from M_TOKUI where TOKUICODE = @TOKUICODE"
            logic.ExecuteNonQuery(connectionString, CommandType.Text, strSQL, New SqlClient.SqlParameter() {New SqlClient.SqlParameter("@TOKUICODE", strPrimaryKey)})

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
        Dim logic As New BLL.Common.ExecuteQuery
        Dim dt As System.Data.DataTable = Nothing

        Dim TABLENAME As String = "M_TOKUI"
        Dim INDEXFIELD As String = "TOKUICODE"
        Dim strWhere As String

        'Where文の作成
        strWhere = "where (1 = 1) "
        RecordMove = ""
        Select Case MoveCommand
            Case "先頭へ"
                dt = logic.ExecuteDataset(connectionString, CommandType.Text, "select * from " & TABLENAME & " B, " &
                                                                              "( " &
                                                                              "select IsNull(min(" & INDEXFIELD & "),'') as TARGET_INDEX from " & TABLENAME & " " &
                                                                              ") A " &
                                                                              "where A.TARGET_INDEX = B." & INDEXFIELD & " ").Tables(0)
            Case "前へ"
                dt = logic.ExecuteDataset(connectionString, CommandType.Text, "select IsNull(max(" & INDEXFIELD & "),'') from " & TABLENAME & " B, " &
                                                                              "( " &
                                                                              "select IsNull(max(" & INDEXFIELD & "),'') as TARGET_INDEX from " & TABLENAME & " " & strWhere & " " &
                                                                              "and " & INDEXFIELD & " < '" & strPrimaryKey & "' " &
                                                                              ") A " &
                                                                              "where A.TARGET_INDEX = B." & INDEXFIELD & "").Tables(0)
            Case "次へ"
                dt = logic.ExecuteDataset(connectionString, CommandType.Text, "select IsNull(min(" & INDEXFIELD & "),'') from " & TABLENAME & " B, " &
                                                                              "( " &
                                                                              "select IsNull(min(" & INDEXFIELD & "),'') as TARGET_INDEX from " & TABLENAME & " " & strWhere & " " &
                                                                              "and " & INDEXFIELD & " > '" & strPrimaryKey & "' " &
                                                                              ") A " &
                                                                              "where A.TARGET_INDEX = B." & INDEXFIELD & "").Tables(0)
            Case "最後へ"
                dt = logic.ExecuteDataset(connectionString, CommandType.Text, "select * from " & TABLENAME & " B, " &
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
