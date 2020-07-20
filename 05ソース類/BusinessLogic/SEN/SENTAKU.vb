Imports Model
Imports BLL.Common
Imports System.Data.SqlClient
Imports System.Data

Public Class SENTAKU
    Inherits DAL.DALBase

    Implements BLL.Common.IBusinessLogic

    Private _key As KobetuTableName

    Public Property TableName() As KobetuTableName
        Get
            Return _key
        End Get
        Set(ByVal value As KobetuTableName)
            _key = value
        End Set
    End Property

    Public Sub New(ByVal key As KobetuTableName)
        TableName = key
    End Sub
    Public Sub New()
    End Sub

    Public Function GetList(ByVal requestParam As Common.DTO.RequestSentakuKey) As System.Data.DataTable Implements Common.IBusinessLogic.GetList

        Dim resultDataSets As New dsSENTAKU
        Dim op As New System.Transactions.TransactionOptions
        op.IsolationLevel = Transactions.IsolationLevel.Serializable

        Select Case TableName

            Case KobetuTableName.M_TENPO
                Using masterAdapter As New BLL.Common.dsSENTAKUTableAdapters.WT_SENTENTableAdapter, connection As New System.Data.SqlClient.SqlConnection(connectionString), _
                    ts As System.Transactions.TransactionScope = New System.Transactions.TransactionScope(Transactions.TransactionScopeOption.Required, op)

                    masterAdapter.Connection = connection : CommonUtility.DBUtility.SetCommandTimeout(masterAdapter)
                    masterAdapter.Fill(resultDataSets.WT_SENTEN, requestParam.PCNAMEKey, requestParam.PGCODEKey, requestParam.FULINOKey)

                    ts.Complete()

                    Return resultDataSets.WT_SENTEN
                End Using

            Case KobetuTableName.M_BUMON
                Using masterAdapter As New BLL.Common.dsSENTAKUTableAdapters.WT_SENBUMTableAdapter, connection As New System.Data.SqlClient.SqlConnection(connectionString), _
                    ts As System.Transactions.TransactionScope = New System.Transactions.TransactionScope(Transactions.TransactionScopeOption.Required, op)

                    masterAdapter.Connection = connection : CommonUtility.DBUtility.SetCommandTimeout(masterAdapter)
                    masterAdapter.Fill(resultDataSets.WT_SENBUM, requestParam.PCNAMEKey, requestParam.PGCODEKey, requestParam.FULINOKey)

                    ts.Complete()

                    Return resultDataSets.WT_SENBUM
                End Using

            Case KobetuTableName.M_TOKUI
                Using masterAdapter As New BLL.Common.dsSENTAKUTableAdapters.WT_SENTOKTableAdapter, connection As New System.Data.SqlClient.SqlConnection(connectionString), _
                    ts As System.Transactions.TransactionScope = New System.Transactions.TransactionScope(Transactions.TransactionScopeOption.Required, op)

                    masterAdapter.Connection = connection : CommonUtility.DBUtility.SetCommandTimeout(masterAdapter)
                    masterAdapter.Fill(resultDataSets.WT_SENTOK, requestParam.PCNAMEKey, requestParam.PGCODEKey, requestParam.FULINOKey)

                    ts.Complete()

                    Return resultDataSets.WT_SENTOK
                End Using

            Case KobetuTableName.M_TANTO
                Using masterAdapter As New BLL.Common.dsSENTAKUTableAdapters.WT_SENTANTableAdapter, connection As New System.Data.SqlClient.SqlConnection(connectionString), _
                    ts As System.Transactions.TransactionScope = New System.Transactions.TransactionScope(Transactions.TransactionScopeOption.Required, op)

                    masterAdapter.Connection = connection : CommonUtility.DBUtility.SetCommandTimeout(masterAdapter)
                    masterAdapter.Fill(resultDataSets.WT_SENTAN, requestParam.PCNAMEKey, requestParam.PGCODEKey, requestParam.FULINOKey)

                    ts.Complete()

                    Return resultDataSets.WT_SENTAN
                End Using

            Case KobetuTableName.M_SIIRE
                Using masterAdapter As New BLL.Common.dsSENTAKUTableAdapters.WT_SENSIITableAdapter, connection As New System.Data.SqlClient.SqlConnection(connectionString), _
                    ts As System.Transactions.TransactionScope = New System.Transactions.TransactionScope(Transactions.TransactionScopeOption.Required, op)

                    masterAdapter.Connection = connection : CommonUtility.DBUtility.SetCommandTimeout(masterAdapter)
                    masterAdapter.Fill(resultDataSets.WT_SENSII, requestParam.PCNAMEKey, requestParam.PGCODEKey, requestParam.FULINOKey)

                    ts.Complete()

                    Return resultDataSets.WT_SENSII
                End Using


        End Select

        Return Nothing
    End Function

    Public Function Init(ByVal params As Model.DTO.RequestGetKobetuSentakuContents) As Boolean

        Dim TableParam As Model.DTO.RequestGetKobetuSENTAKUElement
        For Each TableParam In params.TableList
            Select Case TableParam.TABLEKey

                Case KobetuTableName.M_TOKUI, KobetuTableName.M_TANTO, KobetuTableName.M_SIIRE

                    Delete(TableParam.TABLEKey, TableParam.PCNAMEKey, TableParam.PGCODEKey, TableParam.FULINOKey)
                    Insert(TableParam.TABLEKey, TableParam.PCNAMEKey, TableParam.PGCODEKey, TableParam.FULINOKey)
                    If TableParam.InitialKindValue = InitializeKind.初期化_過去データ取得 Then
                        Update(TableParam.TABLEKey, TableParam.PCNAMEKey, TableParam.PGCODEKey, TableParam.FULINOKey)
                    End If
                    Return Selected(TableParam.TABLEKey, TableParam.PCNAMEKey, TableParam.PGCODEKey, TableParam.FULINOKey)

                Case KobetuTableName.M_SYOHIN
                    Delete(TableParam.TABLEKey, TableParam.PCNAMEKey, TableParam.PGCODEKey, TableParam.FULINOKey)
                    If TableParam.InitialKindValue = InitializeKind.初期化_過去データ取得 Then
                        Insert(TableParam.TABLEKey, TableParam.PCNAMEKey, TableParam.PGCODEKey, TableParam.FULINOKey)
                    End If
                    Return Selected(TableParam.TABLEKey, TableParam.PCNAMEKey, TableParam.PGCODEKey, TableParam.FULINOKey)

            End Select
        Next

    End Function

    Public Sub Unload(ByVal UnloadKind As Model.FinalizeKind, ByVal TableKey As Model.KobetuTableName, ByVal strPCNAME As String, ByVal strPGCODE As String, ByVal intFULINO As Integer, ByVal USERCODE As String)

        Dim logic As New BLL.Common.ExecuteQuery
        Dim param() As SqlParameter = New SqlParameter() {New SqlParameter("@PCNAME", strPCNAME), New SqlParameter("@PGCODE", strPGCODE), New SqlParameter("@FULINO", intFULINO)}

        DeleteReg(TableKey, strPCNAME, strPGCODE, intFULINO)

        Select Case UnloadKind
            Case FinalizeKind.削除_過去データ登録
                InsertReg(TableKey, strPCNAME, strPGCODE, intFULINO, USERCODE)
                Delete(TableKey, strPCNAME, strPGCODE, intFULINO)
            Case FinalizeKind.削除_完全削除
                Delete(TableKey, strPCNAME, strPGCODE, intFULINO)

            Case FinalizeKind.選択区分更新
        End Select

    End Sub

    Private Function Selected(ByVal TableKey As Model.KobetuTableName, ByVal strPCNAME As String, ByVal strPGCODE As String, ByVal intFULINO As Integer) As Boolean

        Dim logic As New BLL.Common.ExecuteQuery
        Dim param() As SqlParameter = New SqlParameter() {New SqlParameter("@PCNAME", strPCNAME), New SqlParameter("@PGCODE", strPGCODE), New SqlParameter("@FULINO", intFULINO)}

        Select Case TableKey
            Case KobetuTableName.M_BUMON
                Return (logic.ExecuteDataset(connectionString, CommandType.Text, "select * from WT_SENBUM where PCNAME=@PCNAME and PGCODE=@PGCODE and FULINO=@FULINO and (CHKARIA = -1 Or CHKARIA = 1)", param).Tables(0).Rows.Count <> 0)
            Case KobetuTableName.M_TANTO
                Return (logic.ExecuteDataset(connectionString, CommandType.Text, "select * from WT_SENTAN where PCNAME=@PCNAME and PGCODE=@PGCODE and FULINO=@FULINO and (CHKARIA = -1 Or CHKARIA = 1)", param).Tables(0).Rows.Count <> 0)
            Case KobetuTableName.M_TENPO
                Return (logic.ExecuteDataset(connectionString, CommandType.Text, "select * from WT_SENTEN where PCNAME=@PCNAME and PGCODE=@PGCODE and FULINO=@FULINO and (CHKARIA = -1 Or CHKARIA = 1)", param).Tables(0).Rows.Count <> 0)
            Case KobetuTableName.M_TOKUI
                Return (logic.ExecuteDataset(connectionString, CommandType.Text, "select * from WT_SENTOK where PCNAME=@PCNAME and PGCODE=@PGCODE and FULINO=@FULINO and (CHKARIA = -1 Or CHKARIA = 1)", param).Tables(0).Rows.Count <> 0)
            Case KobetuTableName.M_TANTO
                Return (logic.ExecuteDataset(connectionString, CommandType.Text, "select * from WT_SENTAN where PCNAME=@PCNAME and PGCODE=@PGCODE and FULINO=@FULINO and (CHKARIA = -1 Or CHKARIA = 1)", param).Tables(0).Rows.Count <> 0)
            Case KobetuTableName.M_SIIRE
                Return (logic.ExecuteDataset(connectionString, CommandType.Text, "select * from WT_SENSII where PCNAME=@PCNAME and PGCODE=@PGCODE and FULINO=@FULINO and (CHKARIA = -1 Or CHKARIA = 1)", param).Tables(0).Rows.Count <> 0)
        End Select

    End Function

    Public Sub Delete(ByVal TableKey As Model.KobetuTableName, ByVal strPCNAME As String, ByVal strPGCODE As String, ByVal intFULINO As Integer) Implements Common.IBusinessLogic.Delete
        Dim logic As New BLL.Common.ExecuteQuery
        Dim param() As SqlParameter = New SqlParameter() {New SqlParameter("@PCNAME", strPCNAME), New SqlParameter("@PGCODE", strPGCODE), New SqlParameter("@FULINO", intFULINO)}

        Select Case TableKey
            Case KobetuTableName.M_BUMON
                logic.ExecuteNonQuery(connectionString, CommandType.Text, "DELETE FROM WT_SENBUM WHERE PCNAME = @PCNAME AND PGCODE = @PGCODE AND FULINO = @FULINO ", param)
            Case KobetuTableName.M_TANTO
                logic.ExecuteNonQuery(connectionString, CommandType.Text, "DELETE FROM WT_SENTAN WHERE PCNAME = @PCNAME AND PGCODE = @PGCODE AND FULINO = @FULINO ", param)
            Case KobetuTableName.M_TENPO
                logic.ExecuteNonQuery(connectionString, CommandType.Text, "DELETE FROM WT_SENTEN WHERE PCNAME = @PCNAME AND PGCODE = @PGCODE AND FULINO = @FULINO ", param)
            Case KobetuTableName.M_TOKUI
                logic.ExecuteNonQuery(connectionString, CommandType.Text, "DELETE FROM WT_SENTOK WHERE PCNAME = @PCNAME AND PGCODE = @PGCODE AND FULINO = @FULINO ", param)
            Case KobetuTableName.M_TANTO
                logic.ExecuteNonQuery(connectionString, CommandType.Text, "DELETE FROM WT_SENTAN WHERE PCNAME = @PCNAME AND PGCODE = @PGCODE AND FULINO = @FULINO ", param)
            Case KobetuTableName.M_SIIRE
                logic.ExecuteNonQuery(connectionString, CommandType.Text, "DELETE FROM WT_SENSII WHERE PCNAME = @PCNAME AND PGCODE = @PGCODE AND FULINO = @FULINO ", param)
        End Select

    End Sub

    Private Sub DeleteReg(ByVal TableKey As Model.KobetuTableName, ByVal strPCNAME As String, ByVal strPGCODE As String, ByVal intFULINO As Integer)
        Dim logic As New BLL.Common.ExecuteQuery
        Dim param() As SqlParameter = New SqlParameter() {New SqlParameter("@PCNAME", strPCNAME), New SqlParameter("@PGCODE", strPGCODE), New SqlParameter("@FULINO", intFULINO)}

        Select Case TableKey
            Case KobetuTableName.M_BUMON
                logic.ExecuteNonQuery(connectionString, CommandType.Text, "DELETE FROM M_SENBUMREG WHERE PCNAME = @PCNAME AND PGCODE = @PGCODE AND FULINO = @FULINO ", param)
            Case KobetuTableName.M_TENPO
                logic.ExecuteNonQuery(connectionString, CommandType.Text, "DELETE FROM M_SENTENREG WHERE PCNAME = @PCNAME AND PGCODE = @PGCODE AND FULINO = @FULINO ", param)
            Case KobetuTableName.M_TOKUI
                logic.ExecuteNonQuery(connectionString, CommandType.Text, "DELETE FROM M_SENTOKREG WHERE PCNAME = @PCNAME AND PGCODE = @PGCODE AND FULINO = @FULINO ", param)
            Case KobetuTableName.M_TANTO
                logic.ExecuteNonQuery(connectionString, CommandType.Text, "DELETE FROM M_SENTANREG WHERE PCNAME = @PCNAME AND PGCODE = @PGCODE AND FULINO = @FULINO ", param)
            Case KobetuTableName.M_SIIRE
                logic.ExecuteNonQuery(connectionString, CommandType.Text, "DELETE FROM M_SENSIIREG WHERE PCNAME = @PCNAME AND PGCODE = @PGCODE AND FULINO = @FULINO ", param)
        End Select

    End Sub

    Public Sub Insert(ByVal TableKey As Model.KobetuTableName, ByVal strPCNAME As String, ByVal strPGCODE As String, ByVal intFULINO As Integer) Implements Common.IBusinessLogic.Insert

        Dim logic As New BLL.Common.ExecuteQuery
        Dim param() As SqlParameter = New SqlParameter() {New SqlParameter("@PCNAME", strPCNAME), New SqlParameter("@PGCODE", strPGCODE), New SqlParameter("@FULINO", intFULINO)}

        Select Case TableKey
            Case KobetuTableName.M_BUMON
                logic.ExecuteNonQuery(connectionString, CommandType.Text, "INSERT INTO WT_SENBUM SELECT @PCNAME, @PGCODE, @FULINO, BUMONCODE, BUMONNAME, 0, 0 FROM M_BUMON", param)
            Case KobetuTableName.M_TENPO
                logic.ExecuteNonQuery(connectionString, CommandType.Text, "INSERT INTO WT_SENTEN SELECT @PCNAME, @PGCODE, @FULINO, TENCODE, TENNAME, 0, 0 FROM M_TENPO", param)
            Case KobetuTableName.M_TOKUI
                logic.ExecuteNonQuery(connectionString, CommandType.Text, "INSERT INTO WT_SENTOK SELECT @PCNAME, @PGCODE, @FULINO, TOKUICODE, MENUKEY, TOKUINAME, 0, 0 FROM M_TOKUI", param)
            Case KobetuTableName.M_TANTO
                logic.ExecuteNonQuery(connectionString, CommandType.Text, "INSERT INTO WT_SENTAN SELECT @PCNAME, @PGCODE, @FULINO, TANTOCODE, TANTOKANA, TANTONAME, 0, 0 FROM M_TANTO", param)
            Case KobetuTableName.M_SIIRE
                logic.ExecuteNonQuery(connectionString, CommandType.Text, "INSERT INTO WT_SENSII SELECT @PCNAME, @PGCODE, @FULINO, SIIRECODE, MENUKEY, SIIRENAME, 0, 0 FROM M_SIIRE", param)
        End Select

    End Sub

    Public Sub InsertReg(ByVal TableKey As Model.KobetuTableName, ByVal strPCNAME As String, ByVal strPGCODE As String, ByVal intFULINO As Integer, ByVal USERCODE As String)

        Dim logic As New BLL.Common.ExecuteQuery
        Dim param() As SqlParameter = New SqlParameter() {New SqlParameter("@PCNAME", strPCNAME), New SqlParameter("@PGCODE", strPGCODE), New SqlParameter("@FULINO", intFULINO), New SqlParameter("@UPDATEUSERCODE", USERCODE)}

        Select Case TableKey
            Case KobetuTableName.M_TOKUI
                logic.ExecuteNonQuery(connectionString, CommandType.Text, "INSERT INTO M_SENTOKREG SELECT @PCNAME, @PGCODE, FULINO, TOKUICODE , getdate(), @PGCODE, @UPDATEUSERCODE, getdate(), getdate() FROM WT_SENTOK where PCNAME=@PCNAME and PGCODE=@PGCODE and FULINO=@FULINO and (CHKARIA = -1 OR CHKARIA = 1)", param)
            Case KobetuTableName.M_TANTO
                logic.ExecuteNonQuery(connectionString, CommandType.Text, "INSERT INTO M_SENTANREG SELECT @PCNAME, @PGCODE, FULINO, TANTOCODE , getdate(), @PGCODE, @UPDATEUSERCODE, getdate(), getdate() FROM WT_SENTAN where PCNAME=@PCNAME and PGCODE=@PGCODE and FULINO=@FULINO and (CHKARIA = -1 OR CHKARIA = 1)", param)
            Case KobetuTableName.M_SIIRE
                logic.ExecuteNonQuery(connectionString, CommandType.Text, "INSERT INTO M_SENSIIREG SELECT @PCNAME, @PGCODE, FULINO, SIIRECODE , getdate(), @PGCODE, @UPDATEUSERCODE, getdate(), getdate() FROM WT_SENSII where PCNAME=@PCNAME and PGCODE=@PGCODE and FULINO=@FULINO and (CHKARIA = -1 OR CHKARIA = 1)", param)
        End Select

    End Sub

    Private Sub Update(ByVal TableKey As Model.KobetuTableName, ByVal strPCNAME As String, ByVal strPGCODE As String, ByVal intFULINO As Integer)

        Dim strSQL As String
        Dim logic As New BLL.Common.ExecuteQuery
        Dim param() As SqlParameter = New SqlParameter() {New SqlParameter("@PCNAME", strPCNAME), New SqlParameter("@PGCODE", strPGCODE), New SqlParameter("@FULINO", intFULINO)}

        Select Case TableKey

            Case KobetuTableName.M_BUMON

                strSQL = "UPDATE WT_SENBUM SET CHKARIA = -1, SENKBN = 1"
                strSQL = strSQL & " FROM (select * from M_SENBUMREG where PCNAME=@PCNAME and PGCODE=@PGCODE and FULINO=@FULINO) upd"
                strSQL = strSQL & " WHERE WT_SENBUM.PCNAME   = @PCNAME"
                strSQL = strSQL & "   AND WT_SENBUM.PGCODE   = @PGCODE"
                strSQL = strSQL & "   AND WT_SENBUM.FULINO   = @FULINO"
                strSQL = strSQL & "   AND WT_SENBUM.BUMONCODE=upd.BUMONCODE"
                logic.ExecuteNonQuery(connectionString, CommandType.Text, strSQL, param)

            Case KobetuTableName.M_TENPO

                strSQL = "UPDATE WT_SENTEN SET CHKARIA = -1, SENKBN = 1"
                strSQL = strSQL & " FROM (select * from M_SENTENREG where PCNAME=@PCNAME and PGCODE=@PGCODE and FULINO=@FULINO) upd"
                strSQL = strSQL & " WHERE WT_SENTEN.PCNAME = @PCNAME"
                strSQL = strSQL & "   AND WT_SENTEN.PGCODE = @PGCODE"
                strSQL = strSQL & "   AND WT_SENTEN.FULINO = @FULINO"
                strSQL = strSQL & "   AND WT_SENTEN.TENCODE=upd.TENCODE"
                logic.ExecuteNonQuery(connectionString, CommandType.Text, strSQL, param)

            Case KobetuTableName.M_TOKUI

                strSQL = "UPDATE WT_SENTOK SET CHKARIA = -1, SENKBN = 1"
                strSQL = strSQL & " FROM (select * from M_SENTOKREG where PCNAME=@PCNAME and PGCODE=@PGCODE and FULINO=@FULINO) upd"
                strSQL = strSQL & " WHERE WT_SENTOK.PCNAME = @PCNAME"
                strSQL = strSQL & "   AND WT_SENTOK.PGCODE = @PGCODE"
                strSQL = strSQL & "   AND WT_SENTOK.FULINO = @FULINO"
                strSQL = strSQL & "   AND WT_SENTOK.TOKUICODE=upd.TOKUICODE"
                logic.ExecuteNonQuery(connectionString, CommandType.Text, strSQL, param)

            Case KobetuTableName.M_TANTO

                strSQL = "UPDATE WT_SENTAN SET CHKARIA = -1, SENKBN = 1"
                strSQL = strSQL & " FROM (select * from M_SENTANREG where PCNAME=@PCNAME and PGCODE=@PGCODE and FULINO=@FULINO) upd"
                strSQL = strSQL & " WHERE WT_SENTAN.PCNAME = @PCNAME"
                strSQL = strSQL & "   AND WT_SENTAN.PGCODE = @PGCODE"
                strSQL = strSQL & "   AND WT_SENTAN.FULINO = @FULINO"
                strSQL = strSQL & "   AND WT_SENTAN.TANTOCODE=upd.TANTOCODE"
                logic.ExecuteNonQuery(connectionString, CommandType.Text, strSQL, param)

            Case KobetuTableName.M_SIIRE

                strSQL = "UPDATE WT_SENSII SET CHKARIA = -1, SENKBN = 1"
                strSQL = strSQL & " FROM (select * from M_SENSIIREG where PCNAME=@PCNAME and PGCODE=@PGCODE and FULINO=@FULINO) upd"
                strSQL = strSQL & " WHERE WT_SENSII.PCNAME = @PCNAME"
                strSQL = strSQL & "   AND WT_SENSII.PGCODE = @PGCODE"
                strSQL = strSQL & "   AND WT_SENSII.FULINO = @FULINO"
                strSQL = strSQL & "   AND WT_SENSII.SIIRECODE=upd.SIIRECODE"
                logic.ExecuteNonQuery(connectionString, CommandType.Text, strSQL, param)

        End Select
    End Sub

    '画面にてチェックしたレコードをワークテーブルに反映
    Public Sub Update(ByVal params As Model.DTO.RequestSentakuUpdate) Implements Common.IBusinessLogic.Update

        Dim strSQL As String
        Dim logic As New BLL.Common.ExecuteQuery
        Dim param() As SqlParameter = New SqlParameter() {New SqlParameter("@PCNAME", params.PCNAMEKey), New SqlParameter("@PGCODE", params.PGCODEKey), New SqlParameter("@FULINO", params.FULINOKey)}

        Using ts As System.Transactions.TransactionScope = New System.Transactions.TransactionScope

            Select Case TableName
                Case KobetuTableName.M_TENPO
                Case KobetuTableName.M_BUMON
                Case KobetuTableName.M_SYOHIN
                    Delete(KobetuTableName.M_SYOHIN, params.PCNAMEKey, params.PGCODEKey, params.FULINOKey)
            End Select

            For Each dr As DataRow In params.Datatable.Rows

                Select Case TableName
                    Case KobetuTableName.M_BUMON
                        strSQL = "UPDATE WT_SENBUM SET CHKARIA = " & CType(dr.Item("chkaria"), Integer)
                        strSQL = strSQL & "           ,SENKBN  = " & CType(dr.Item("chkaria"), Integer) * -1
                        strSQL = strSQL & " WHERE PCNAME    = @PCNAME"
                        strSQL = strSQL & "   AND   PGCODE  = @PGCODE"
                        strSQL = strSQL & "   AND   FULINO  = @FULINO"
                        strSQL = strSQL & "   AND   BUMONCODE = '" & CType(dr.Item("BUMONCODE"), String) & "'"
                        logic.ExecuteNonQuery(connectionString, CommandType.Text, strSQL, param)

                    Case KobetuTableName.M_TOKUI
                        strSQL = "UPDATE WT_SENTOK SET CHKARIA = " & CType(dr.Item("chkaria"), Integer)
                        strSQL = strSQL & "           ,SENKBN  = " & CType(dr.Item("chkaria"), Integer) * -1
                        strSQL = strSQL & " WHERE PCNAME    = @PCNAME"
                        strSQL = strSQL & "   AND   PGCODE  = @PGCODE"
                        strSQL = strSQL & "   AND   FULINO  = @FULINO"
                        strSQL = strSQL & "   AND   TOKUICODE = '" & CType(dr.Item("TOKUICODE"), String) & "'"
                        logic.ExecuteNonQuery(connectionString, CommandType.Text, strSQL, param)

                    Case KobetuTableName.M_TANTO
                        strSQL = "UPDATE WT_SENTAN SET CHKARIA = " & CType(dr.Item("chkaria"), Integer)
                        strSQL = strSQL & "           ,SENKBN  = " & CType(dr.Item("chkaria"), Integer) * -1
                        strSQL = strSQL & " WHERE PCNAME    = @PCNAME"
                        strSQL = strSQL & "   AND   PGCODE  = @PGCODE"
                        strSQL = strSQL & "   AND   FULINO  = @FULINO"
                        strSQL = strSQL & "   AND   TANTOCODE = '" & CType(dr.Item("TANTOCODE"), String) & "'"
                        logic.ExecuteNonQuery(connectionString, CommandType.Text, strSQL, param)

                    Case KobetuTableName.M_SIIRE
                        strSQL = "UPDATE WT_SENSII SET CHKARIA = " & CType(dr.Item("chkaria"), Integer)
                        strSQL = strSQL & "           ,SENKBN  = " & CType(dr.Item("chkaria"), Integer) * -1
                        strSQL = strSQL & " WHERE PCNAME    = @PCNAME"
                        strSQL = strSQL & "   AND   PGCODE  = @PGCODE"
                        strSQL = strSQL & "   AND   FULINO  = @FULINO"
                        strSQL = strSQL & "   AND   SIIRECODE = '" & CType(dr.Item("SIIRECODE"), String) & "'"
                        logic.ExecuteNonQuery(connectionString, CommandType.Text, strSQL, param)

                    Case KobetuTableName.M_SYOHIN

                        If CType(dr.Item("chkaria"), Integer) = -1 Then
                            strSQL = "INSERT INTO WT_SENSYO"
                            strSQL = strSQL & " SELECT"
                            strSQL = strSQL & " @PCNAME"
                            strSQL = strSQL & ",@PGCODE"
                            strSQL = strSQL & ",@FULINO"
                            strSQL = strSQL & ",SYOHINCODE"
                            strSQL = strSQL & ",MENUKEY"
                            strSQL = strSQL & ",SYOHINNAME"
                            strSQL = strSQL & ",-1"
                            strSQL = strSQL & ", 1"
                            strSQL = strSQL & " FROM M_SYOHIN "
                            strSQL = strSQL & " where SYOHINCODE = '" & CType(dr.Item("SYOHINCODE"), String) & "'"
                            logic.ExecuteNonQuery(connectionString, CommandType.Text, strSQL, param)
                        End If

                    Case KobetuTableName.M_TENPO
                        strSQL = "UPDATE WT_SENTEN SET CHKARIA = " & CType(dr.Item("chkaria"), Integer)
                        strSQL = strSQL & "           ,SENKBN  = " & CType(dr.Item("chkaria"), Integer) * -1
                        strSQL = strSQL & " WHERE PCNAME    = @PCNAME"
                        strSQL = strSQL & "   AND   PGCODE  = @PGCODE"
                        strSQL = strSQL & "   AND   FULINO  = @FULINO"
                        strSQL = strSQL & "   AND   TENCODE = '" & CType(dr.Item("TENCODE"), String) & "'"
                        logic.ExecuteNonQuery(connectionString, CommandType.Text, strSQL, param)

                End Select

            Next
            ts.Complete()
        End Using

    End Sub

    Public Function GetLeftList(ByVal requestParam As Common.DTO.RequestSentakuKey) As System.Data.DataTable Implements Common.IBusinessLogic.GetLeftList

        Dim resultDataSets As New dsSENTAKU
        Dim op As New System.Transactions.TransactionOptions
        op.IsolationLevel = Transactions.IsolationLevel.Serializable

        Select Case TableName

            Case KobetuTableName.M_SYOHIN
                Using masterAdapter As New BLL.Common.dsSENTAKUTableAdapters.SENSYOLeftListTableAdapter, connection As New System.Data.SqlClient.SqlConnection(connectionString), _
                    ts As System.Transactions.TransactionScope = New System.Transactions.TransactionScope(Transactions.TransactionScopeOption.Required, op)

                    masterAdapter.Connection = connection : CommonUtility.DBUtility.SetCommandTimeout(masterAdapter)
                    masterAdapter.Fill(resultDataSets.SENSYOLeftList, requestParam.PCNAMEKey, requestParam.PGCODEKey, requestParam.FULINOKey)

                    ts.Complete()

                    Return resultDataSets.SENSYOLeftList
                End Using

        End Select

        Return Nothing
    End Function

    Public Function GetRightList(ByVal requestParam As Common.DTO.RequestSentakuKey) As System.Data.DataTable Implements Common.IBusinessLogic.GetRightList

        Dim resultDataSets As New dsSENTAKU
        Dim op As New System.Transactions.TransactionOptions
        op.IsolationLevel = Transactions.IsolationLevel.Serializable

        Select Case TableName

            Case KobetuTableName.M_SYOHIN
                Using masterAdapter As New BLL.Common.dsSENTAKUTableAdapters.SENSYORightListTableAdapter, connection As New System.Data.SqlClient.SqlConnection(connectionString), _
                    ts As System.Transactions.TransactionScope = New System.Transactions.TransactionScope(Transactions.TransactionScopeOption.Required, op)

                    masterAdapter.Connection = connection : CommonUtility.DBUtility.SetCommandTimeout(masterAdapter)
                    masterAdapter.Fill(resultDataSets.SENSYORightList)

                    ts.Complete()

                    Return resultDataSets.SENSYORightList
                End Using

        End Select

        Return Nothing
    End Function

End Class
