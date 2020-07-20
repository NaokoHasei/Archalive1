Imports System.Data.SqlClient
Imports BLL.Common
Imports CommonUtility.Utility

Namespace HAT0001DataAccess

    Public Class Read
        Inherits BLL.Common.DAL.DALBase

        Public Sub New()
        End Sub

        Private _HATYUNO As String
        Private _HATYUEDABAN As String
        Private _HATYUEDABAN2 As String

        Public Sub New(ByVal strHATYUNO As String, ByVal strHATYUEDABAN As String, ByVal strHATYUEDABAN2 As String)
            _HATYUNO = strHATYUNO
            _HATYUEDABAN = strHATYUEDABAN
            _HATYUEDABAN2 = strHATYUEDABAN2
        End Sub

        Public Function Readコメント情報取得() As dsHAT0001

            Dim logic As New BLL.Common.ExecuteQuery
            Dim resultDataSets As New dsHAT0001

            Dim param() As SqlParameter
            param = New SqlParameter() {
                  New SqlParameter("@HATYUNO", _HATYUNO) _
                , New SqlParameter("@HATYUEDABAN1", IIf(_HATYUEDABAN = "", -1, _HATYUEDABAN)) _
                , New SqlParameter("@HATYUEDABAN2", IIf(_HATYUEDABAN2 = "", -1, _HATYUEDABAN2))}

            logic.FillDataset(connectionString, Data.CommandType.Text, コメント情報取得, resultDataSets, New String() {"コメント情報"}, param)

            Return resultDataSets

        End Function

        Public Function Read発注明細情報取得(ByVal hatyuNo As Decimal, ByVal hatyuEdaban As Decimal, ByVal hatyuEdaban2 As Decimal) As dsHAT0001
            Dim logic As New BLL.Common.ExecuteQuery
            Dim resultDataSets As New dsHAT0001

            logic.FillDataset(
                  connectionString _
                , Data.CommandType.Text _
                , 発注明細情報取得() _
                , resultDataSets _
                , New String() {"明細情報"} _
                , New SqlParameter() {
                    New SqlParameter("@HATYUNO", hatyuNo),
                    New SqlParameter("@HATYUEDABAN1", hatyuEdaban),
                    New SqlParameter("@HATYUEDABAN2", hatyuEdaban2)
                    }
                )

            Return resultDataSets
        End Function

        Private Function 発注明細情報取得() As String
            Dim strSQL As String = ""

            strSQL += " select"
            strSQL += "     isnull(KAMOKU_HINMOKU,'') KAMOKU_HINMOKU"
            strSQL += "   , isnull(HINSITU_KIKAKU_SIYO,'') HINSITU_KIKAKU_SIYO"
            strSQL += "   , SUU"
            strSQL += "   , isnull(TANI,'') TANI"
            strSQL += "   , GENTANKA"
            strSQL += "   , GENKAGAKU"
            strSQL += "   , isnull(G_BIKO,'') G_BIKO"
            '非表示項目     
            strSQL += "   , JYUTYUEDABAN"
            strSQL += "   , KAISOCODE"
            strSQL += "   , JYUTYUEDABAN_DAIKAMOKU"
            strSQL += "   , KAISOCODE_DAIKAMOKU"
            strSQL += "   , DAIKAMOKUCODE"
            strSQL += "   , CYUKAMOKUCODE"
            strSQL += "   , SYOKAMOKUCODE"
            strSQL += "   , KAKERITU"
            strSQL += "   , IKATU_KAKERITU"
            strSQL += " from T_HATYU"
            strSQL += " where HATYUNO      = @HATYUNO"
            strSQL += " and   HATYUEDABAN  = @HATYUEDABAN1"
            strSQL += " and   HATYUEDABAN2 = @HATYUEDABAN2"
            strSQL += " order by KAISOCODE_DAIKAMOKU, JYUTYUEDABAN_DAIKAMOKU, KAISOCODE, SUU"

            Return strSQL
        End Function

        Public Function Read受注明細情報取得(
                  ByVal jyutyuNo As Decimal _
                , ByVal jyutyuEdaban As Decimal _
                , ByVal jyutyuEdabanBef As Decimal _
                , ByVal siireCode As String
                ) As dsHAT0001
            Dim logic As New BLL.Common.ExecuteQuery
            Dim resultDataSets As New dsHAT0001

            logic.FillDataset(
                  connectionString _
                , Data.CommandType.Text _
                , 受注明細情報取得(jyutyuEdaban, jyutyuEdabanBef) _
                , resultDataSets _
                , New String() {"明細情報"} _
                , New SqlParameter() {
                    New SqlParameter("@JYUTYUNO", jyutyuNo),
                    New SqlParameter("@JYUTYUEDABAN", jyutyuEdaban),
                    New SqlParameter("@SIIRECODE", siireCode)
                    }
                )

            Return resultDataSets
        End Function

        Private Function 受注明細情報取得(ByVal jyutyuEdaban As Decimal, ByVal jyutyuEdabanBef As Decimal) As String
            Dim strSQL As String = ""

            '前回の受注を取得（階層コードを最新の受注に変換後の情報）
            strSQL += 最下位層リスト取得_ZENKAI_JYUTYU(jyutyuEdaban, jyutyuEdabanBef)
            '受注情報から取得（登録前の情報）
            strSQL += " select"
            strSQL += "     isnull(KAMOKU_HINMOKU,'') KAMOKU_HINMOKU"
            strSQL += "   , isnull(HINSITU_KIKAKU_SIYO,'') HINSITU_KIKAKU_SIYO"
            strSQL += "   , SUU"
            strSQL += "   , isnull(TANI,'') TANI"
            strSQL += "   , GENTANKA"
            strSQL += "   , GENKAGAKU"
            strSQL += "   , isnull(G_BIKO,'') G_BIKO"
            '非表示項目     
            strSQL += "   , JYUTYUEDABAN"
            strSQL += "   , KAISOCODE"
            strSQL += "   , JYUTYUEDABAN_DAIKAMOKU"
            strSQL += "   , KAISOCODE_DAIKAMOKU"
            strSQL += "   , DAIKAMOKUCODE"
            strSQL += "   , CYUKAMOKUCODE"
            strSQL += "   , SYOKAMOKUCODE"
            strSQL += "   , KAKERITU"
            strSQL += "   , IKATU_KAKERITU"
            strSQL += " from  (" + 最下位層リスト取得() + ") as T_JYUTYU"
            strSQL += " order by KAISOCODE_DAIKAMOKU, JYUTYUEDABAN_DAIKAMOKU, KAISOCODE, SUU"

            Return strSQL
        End Function

        Private Function 最下位層リスト取得() As String
            Dim strSQL As String = ""

            strSQL += " select"
            strSQL += "     isnull(JYU.JYUTYUNO           , JYU_BEF.JYUTYUNO              ) JYUTYUNO"
            strSQL += "   , isnull(JYU.JYUTYUEDABAN       , JYU_BEF.JYUTYUEDABAN          ) JYUTYUEDABAN"
            strSQL += "   , isnull(JYU.KAMOKU_HINMOKU     , JYU_BEF.KAMOKU_HINMOKU        ) KAMOKU_HINMOKU"
            strSQL += "   , isnull(JYU.HINSITU_KIKAKU_SIYO, JYU_BEF.HINSITU_KIKAKU_SIYO   ) HINSITU_KIKAKU_SIYO"
            strSQL += "   , isnull(JYU.TANI               , JYU_BEF.TANI                  ) TANI"
            strSQL += "   , isnull(JYU.GENTANKA           , JYU_BEF.GENTANKA              ) GENTANKA"
            strSQL += "   , isnull(JYU.G_BIKO             , JYU_BEF.G_BIKO                ) G_BIKO"
            strSQL += "   , isnull(JYU.KAISOCODE          , JYU_BEF.KAISOCODE             ) KAISOCODE"
            strSQL += "   , isnull(JYU.DAIKAMOKUCODE      , JYU_BEF.DAIKAMOKUCODE         ) DAIKAMOKUCODE"
            strSQL += "   , isnull(JYU.CYUKAMOKUCODE      , JYU_BEF.CYUKAMOKUCODE         ) CYUKAMOKUCODE"
            strSQL += "   , isnull(JYU.SYOKAMOKUCODE      , JYU_BEF.SYOKAMOKUCODE         ) SYOKAMOKUCODE"
            strSQL += "   , isnull(JYU.KAKERITU           , JYU_BEF.KAKERITU              ) KAKERITU"
            strSQL += "   , isnull(JYU.IKATU_KAKERITU     , JYU_BEF.IKATU_KAKERITU        ) IKATU_KAKERITU"
            strSQL += "   , isnull(JYU.SIIRECODE          , JYU_BEF.SIIRECODE             ) SIIRECODE"
            strSQL += "   , isnull(JYU.KAISOCODE_DAIKAMOKU, JYU_BEF.KAISOCODE_DAIKAMOKU   ) KAISOCODE_DAIKAMOKU"
            strSQL += "   , isnull(JYU.JYUTYUEDABAN       , JYU_BEF.JYUTYUEDABAN_DAIKAMOKU) JYUTYUEDABAN_DAIKAMOKU"
            strSQL += "   , isnull(JYU.SUU      , 0) - isnull(JYU_BEF.SUU      , 0)         SUU"
            strSQL += "   , isnull(JYU.GENKAGAKU, 0) - isnull(JYU_BEF.GENKAGAKU, 0)         GENKAGAKU"
            '受注枝番の階層のデータを取得
            strSQL += " from            (" + 最下位層リスト取得_SUB("@JYUTYUEDABAN") + ") JYU"
            '受注枝番の下階層のデータを取得
            strSQL += " full outer join JYU_BEF"
            strSQL += "   on  JYU_BEF.KAI_JYUTYUEDABAN = JYU.JYUTYUEDABAN"
            strSQL += "   and JYU_BEF.KAI_KAISOCODE    = JYU.KAISOCODE"
            '変更前後で数量が異なる場合、対象とする（前後のいずれかが存在しない時の数量＝0は対象とする）
            strSQL += " where not ("
            strSQL += "       JYU.JYUTYUNO          is not null"
            strSQL += "   and JYU_BEF.JYUTYUNO      is not null"
            strSQL += "   and JYU.SUU - JYU_BEF.SUU = 0)"

            Return strSQL
        End Function

        Private Function 最下位層リスト取得_ZENKAI_JYUTYU(ByVal jyutyuEdaban As Decimal, ByVal jyutyuEdabanBef As Decimal) As String
            Dim strSQL = ""
            Dim strSQL_select = ""

            '今の受注と階層を紐づける（以下は生成後のSQLの例）
            '前の発注の受注情報の階層コードから最新の受注情報の階層コードを紐づける
            '例えば、階層コードを「001→002→003」と変更した場合、請求情報の階層コードを「001→003」に変換する。

            'select句、from句の定義
            strSQL_select += "     select"
            strSQL_select += "         isnull(KAI.KAI_JYUTYUEDABAN    , JYU.JYUTYUEDABAN    ) KAI_JYUTYUEDABAN"
            strSQL_select += "       , isnull(KAI.KAI_KAISOCODE       , JYU.KAISOCODE       ) KAI_KAISOCODE"
            strSQL_select += "       , isnull(KAI.KAI_KAISOCODE_ZENKAI, JYU.KAISOCODE_ZENKAI) KAI_KAISOCODE_ZENKAI"
            strSQL_select += "       , JYU.KAISOCODE"
            strSQL_select += "       , JYU.KAISOCODE_ZENKAI"
            strSQL_select += "     from T_JYUTYU as JYU"

            'where句の定義
            Dim strSQL_where = ""
            strSQL_where += "     where JYU.JYUTYUNO         = @JYUTYUNO"
            strSQL_where += "     and   JYU.DELETE_FLG       = 0"
            strSQL_where += "     and   JYU.JYUTYUEDABAN     = "

            strSQL += " with KAI as ("
            strSQL += strSQL_select

            '受注情報の受注枝番から請求情報の受注枝番＋１分の繰り返し
            For edaban = jyutyuEdaban To jyutyuEdabanBef + 1 Step -1
                strSQL += "  left outer join ("
                strSQL += strSQL_select
            Next

            strSQL += "     left outer join (select null as KAI_JYUTYUEDABAN, null as KAI_KAISOCODE, null as KAI_KAISOCODE_ZENKAI, null as KAISOCODE, null as KAISOCODE_ZENKAI) KAI"

            '受注情報の受注枝番から請求情報の受注枝番＋１分の繰り返し
            For edaban = jyutyuEdaban To jyutyuEdabanBef + 1 Step -1
                '受注情報の前後を紐づける
                strSQL += "  on JYU.KAISOCODE = KAI.KAISOCODE_ZENKAI"
                '条件の追加（取得する受注情報の枝番を付加する）
                strSQL += strSQL_where + CStr(edaban)
                strSQL += "  ) KAI"
            Next

            '受注情報の前後を紐づける
            strSQL += "       on JYU.KAISOCODE = KAI.KAISOCODE_ZENKAI"
            '条件の追加（取得する受注情報の枝番を付加する）
            strSQL += strSQL_where + CStr(jyutyuEdabanBef)

            strSQL += " )"
            strSQL += " , JYU_BEF as ("
            strSQL += " select"
            strSQL += "     JYU.*"
            strSQL += "   , KAI_DAIKAMOKU.KAI_JYUTYUEDABAN     as JYUTYUEDABAN_DAIKAMOKU"
            strSQL += "   , KAI.KAI_JYUTYUEDABAN "
            strSQL += "   , KAI.KAI_KAISOCODE"
            strSQL += "   , KAI.KAI_KAISOCODE_ZENKAI"
            strSQL += " from (" + 最下位層リスト取得_SUB("@JYUTYUEDABAN - " + CStr(jyutyuEdaban - jyutyuEdabanBef)) + ") JYU"
            '請求情報から最新の受注情報を階層コード、階層コード（前回）で紐づけする。
            strSQL += " inner join KAI"
            strSQL += "   on KAI.KAISOCODE = JYU.KAISOCODE"
            '請求情報から最新の受注情報を階層コード、階層コード（前回）で紐づけする。（１階層目の情報を取得）
            strSQL += " inner join KAI KAI_DAIKAMOKU"
            strSQL += "   on KAI_DAIKAMOKU.KAISOCODE = left(JYU.KAISOCODE, 3)"
            strSQL += " )"

            Return strSQL
        End Function

        Private Function 最下位層リスト取得_SUB(ByVal jyutyuEdaban As String) As String
            Dim strSQL As String = ""

            strSQL += " select *, left(MEI.KAISOCODE, 3) as KAISOCODE_DAIKAMOKU"
            strSQL += " from  T_JYUTYU As MEI"
            strSQL += " where JYUTYUNO     = @JYUTYUNO"
            strSQL += " and   JYUTYUEDABAN = " + jyutyuEdaban
            strSQL += " and   SIIRECODE    = @SIIRECODE"
            strSQL += " and   DELETE_FLG   = 0"
            '同じ階層かつ、下階層が存在するレコードを対象外とする
            strSQL += " and not exists ("
            strSQL += "   select *"
            strSQL += "   from T_JYUTYU As Sub"
            strSQL += "   where Sub.JYUTYUNO     = MEI.JYUTYUNO"
            strSQL += "   and   Sub.JYUTYUEDABAN = MEI.JYUTYUEDABAN"
            '同じ階層コードを対象とする
            '　※「001002」の場合、「001002」「001002003」は対象、「001001」は対象外
            strSQL += "   and   left(Sub.KAISOCODE, len(MEI.KAISOCODE)) = MEI.KAISOCODE"
            '下階層を対象とする
            '　※「001002」の場合、「001002003」は対象、「001002」は対象外
            strSQL += "   and   len(Sub.KAISOCODE) > len(MEI.KAISOCODE)"
            strSQL += "   )"

            Return strSQL
        End Function

        Private Function コメント情報取得() As String
            Dim strSQL = ""

            strSQL += " Select"
            strSQL += "  main.CATEGORYID"
            strSQL += " ,Case When trn.HATYUNO Is null Then main.DATAKEY Else trn.DATAKEY End DATAKEY"
            strSQL += " ,Case When trn.HATYUNO Is null Then main.DATA Else trn.DATA End DATA"
            strSQL += " from ("
            strSQL += "   Select CATEGORYID, DATAKEY, DATA"
            strSQL += "   from S_SCB"
            strSQL += "   where ( CATEGORYID =  'HATYU_PRI'"
            strSQL += "     and   DATAKEY   in ('LABEL_02', 'COMMENT_01','COMMENT_02', 'COMMENT_03', 'COMMENT_04', 'COMMENT_05', 'COMMENT_06', 'COMMENT_07', 'COMMENT_08', 'COMMENT_09', 'LABEL_02', 'COMMENT_02'))"
            strSQL += "   or    ( CATEGORYID =  'HATYU_PRI_UKE'"
            strSQL += "     and   DATAKEY   in ('LABEL_02', 'COMMENT_02'))"
            strSQL += "   ) main"
            strSQL += " left join ("
            strSQL += "   select HATYUNO, CATEGORYID, DATAKEY , DATA"
            strSQL += "   from T_HATYU_COMMENT"
            strSQL += "   where HATYUNO      = @HATYUNO"
            strSQL += "   and   HATYUEDABAN  = @HATYUEDABAN1"
            strSQL += "   and   HATYUEDABAN2 = @HATYUEDABAN2"
            strSQL += "   ) trn"
            strSQL += "   on  main.CATEGORYID = trn.CATEGORYID"
            strSQL += "   and main.DATAKEY    = trn.DATAKEY"

            Return strSQL
        End Function

        Public Function GetMaxKaisoCodeNewRow(ByVal HATYUNO As String, ByVal HATYUEDABAN As String) As String
            Dim logic As New BLL.Common.ExecuteQuery
            Dim strSQL As String = ""

            strSQL += " select max(KAISOCODE) as KAISOCODE"
            strSQL += " From T_HATYU"
            strSQL += " where HATYUNO            = @HATYUNO"
            strSQL += " and   HATYUEDABAN        = @HATYUEDABAN1"
            strSQL += " and   left(KAISOCODE, 1) = '9'"
            strSQL += " and   len(KAISOCODE)     = 30"

            '物件Noに該当する新規行の階層コード（MAX）を取得
            Dim ds = logic.ExecuteDataset(
                  connectionString _
                , CommandType.Text _
                , strSQL _
                , New SqlParameter() {New SqlParameter("@HATYUNO", HATYUNO), New SqlParameter("@HATYUEDABAN1", HATYUEDABAN)}
                )

            If ds.Tables(0).Rows.Count = 0 OrElse NUCheck(ds.Tables(0).Rows(0).Item("KAISOCODE").ToString) Then
                '該当レコードがない場合、新規行の階層コードを発番
                Return "9" + New String("0"c, 29)
            End If

            '該当レコードがある場合、階層コード（MAX）を発番
            Return ds.Tables(0).Rows(0).Item("KAISOCODE").ToString

        End Function
    End Class

    Public Class Update

        Public Enum enum処理区分
            新規
            編集
            削除
        End Enum

        Private _UPDATEPGID As String
        Private _UPDATEUSERCODE As String
        Private _処理区分 As enum処理区分
        Private _Connection As SqlConnection
        Private _ExecuteLogic As BLL.Common.ExecuteQuery
        Private _WritingDataSet As dsHAT0001_Update

        '新規・編集の際に使用するインスタンス
        Public Sub New(ByVal strUPDATEPGID As String, ByVal strUPDATEUSERCODE As String, ByVal WritingDataSet As dsHAT0001_Update, ByVal 処理区分 As enum処理区分)
            _UPDATEPGID = strUPDATEPGID
            _UPDATEUSERCODE = strUPDATEUSERCODE
            _処理区分 = 処理区分
            _Connection = New SqlConnection(CommonUtility.DBUtility.GetConnectionString)
            _ExecuteLogic = New BLL.Common.ExecuteQuery
            _WritingDataSet = WritingDataSet
        End Sub

        '削除の際に使用するインスタンス
        Public Sub New(ByVal strUPDATEPGID As String, ByVal strUPDATEUSERCODE As String, ByVal WritingDataSet As dsHAT0001_Update)
            _UPDATEPGID = strUPDATEPGID
            _UPDATEUSERCODE = strUPDATEUSERCODE
            _処理区分 = enum処理区分.削除
            _Connection = New SqlConnection(CommonUtility.DBUtility.GetConnectionString)
            _ExecuteLogic = New BLL.Common.ExecuteQuery
            _WritingDataSet = WritingDataSet
        End Sub

        Public Sub 登録()

            Dim row As dsHAT0001_Update.T_HATYUHEDRow = _WritingDataSet.T_HATYUHED.Item(0)

            Using ts As System.Transactions.TransactionScope = New System.Transactions.TransactionScope()
                Call 発注ヘッダートラン更新()

                Call 発注トラン更新(row.HATYUNO, row.HATYUEDABAN, row.HATYUEDABAN2)

                Call 発注コメントトラン更新(row.HATYUNO, row.HATYUEDABAN, row.HATYUEDABAN2)

                Call 受注ヘッダートラン更新(row.HATYUNO, row.JYUTYUEDABAN)

                '物件承認情報（発注）の登録
                Dim T_BUKKEN_APPROVAL As New T_BUKKEN_APPROVALRead
                If T_BUKKEN_APPROVAL.GetDataWherePK(row.HATYUNO, T_BUKKEN_APPROVALRead.enumGyomuKbn.Hacchu, row.HATYUEDABAN).Rows.Count = 0 Then
                    '発注枝番に紐づく承認情報が存在しない場合

                    Dim dtT_BUKKEN_APPROVAL = New dsT_BUKKEN_APPROVAL.T_BUKKEN_APPROVALDataTable
                    Dim drT_BUKKEN_APPROVAL As dsT_BUKKEN_APPROVAL.T_BUKKEN_APPROVALRow = dtT_BUKKEN_APPROVAL.NewRow
                    drT_BUKKEN_APPROVAL.BUKKENNO = row.HATYUNO
                    drT_BUKKEN_APPROVAL.GYOMUKBN = T_BUKKEN_APPROVALRead.enumGyomuKbn.Hacchu
                    drT_BUKKEN_APPROVAL.EDABAN = row.HATYUEDABAN
                    drT_BUKKEN_APPROVAL.APPROVALKBN = T_BUKKEN_APPROVALRead.enumApprovalKbn.SYONIN_MI
                    drT_BUKKEN_APPROVAL.UPDATEPGID = _UPDATEPGID
                    drT_BUKKEN_APPROVAL.UPDATEUSERCODE = _UPDATEUSERCODE
                    T_BUKKEN_APPROVAL.insertT_BUKKEN_APPROVAL(drT_BUKKEN_APPROVAL)
                End If

                '未承認に更新
                If CDec(row.HATYUEDABAN2) <> 0 Then
                    '前の発注が存在する場合
                    T_BUKKEN_APPROVAL.UpdateSyoninKbn(row.HATYUNO, T_BUKKEN_APPROVALRead.enumGyomuKbn.Hacchu, row.HATYUEDABAN, T_BUKKEN_APPROVALRead.enumApprovalKbn.SYONIN_MI)
                End If

                ts.Complete()
            End Using
        End Sub

        '発注ヘッダートラン作成
        Private Sub 発注ヘッダートラン更新()
            Dim strSQL As String = ""

            Dim row As dsHAT0001_Update.T_HATYUHEDRow = _WritingDataSet.T_HATYUHED.Item(0)

            Dim param = New SqlParameter() {
                New SqlParameter("@HATYUNO", row.HATYUNO),
                New SqlParameter("@HATYUEDABAN1", row.HATYUEDABAN),
                New SqlParameter("@HATYUEDABAN2", row.HATYUEDABAN2),
                New SqlParameter("@JYUTYUEDABAN", row.JYUTYUEDABAN),
                New SqlParameter("@HATYUDATE", row.HATYUDATE),
                New SqlParameter("@JYUTYUNO", row.JYUTYUNO),
                New SqlParameter("@SIIRECODE", row.SIIRECODE),
                New SqlParameter("@TANTOCODE", row.TANTOCODE),
                New SqlParameter("@INP_TANTOCODE", row.INP_TANTOCODE),
                New SqlParameter("@KEISYOUCODE", row.KEISYOUCODE),
                New SqlParameter("@SIHARAI_COMMENT_01", row.SIHARAI_COMMENT_01),
                New SqlParameter("@SIHARAI_COMMENT_02", row.SIHARAI_COMMENT_02),
                New SqlParameter("@SIHARAI_COMMENT_03", row.SIHARAI_COMMENT_03),
                New SqlParameter("@SIHARAI_COMMENT_04", row.SIHARAI_COMMENT_04),
                New SqlParameter("@SIHARAI_COMMENT_05", row.SIHARAI_COMMENT_05),
                New SqlParameter("@SIHARAI_COMMENT_06", row.SIHARAI_COMMENT_06),
                New SqlParameter("@AITE_MITUMORINO", row.AITE_MITUMORINO),
                New SqlParameter("@KEIYAKUNO", row.KEIYAKUNO),
                New SqlParameter("@NOUKI_START", row.NOUKI_START),
                New SqlParameter("@NOUKI_END", row.NOUKI_END),
                New SqlParameter("@AITEDENPYONO", row.AITEDENPYONO),
                New SqlParameter("@GKGENKAGAKU_NUKI", row.GKGENKAGAKU_NUKI),
                New SqlParameter("@GKTAX", row.GKTAX),
                New SqlParameter("@GKGENKAGAKU", row.GKGENKAGAKU),
                New SqlParameter("@D_BIKO", row.D_BIKO),
                New SqlParameter("@SYORIKBN", row.SYORIKBN),
                New SqlParameter("@UPDATEPGID", _UPDATEPGID),
                New SqlParameter("@UPDATEUSERCODE", _UPDATEUSERCODE)}

            If _処理区分 = enum処理区分.新規 Then
                strSQL = "  insert into T_HATYUHED ("
                strSQL += "     HATYUNO"
                strSQL += "   , HATYUEDABAN"
                strSQL += "   , HATYUEDABAN2"
                strSQL += "   , UPDATEPGID"
                strSQL += "   , UPDATEUSERCODE"
                strSQL += " ) values ("
                strSQL += "     @HATYUNO"
                strSQL += "   , @HATYUEDABAN1"
                strSQL += "   , @HATYUEDABAN2"
                strSQL += "   , @UPDATEPGID"
                strSQL += "   , @UPDATEUSERCODE"
                strSQL += " )"
                _ExecuteLogic.ExecuteNonQuery(_Connection, Data.CommandType.Text, strSQL, param)
            End If

            strSQL = " update T_HATYUHED Set"
            strSQL += "     JYUTYUEDABAN      = @JYUTYUEDABAN"
            strSQL += "   , HATYUDATE         = @HATYUDATE"
            strSQL += "   , JYUTYUNO          = @JYUTYUNO"
            strSQL += "   , SIIRECODE         = @SIIRECODE"
            strSQL += "   , TANTOCODE         = @TANTOCODE"
            strSQL += "   , INP_TANTOCODE     = @INP_TANTOCODE"
            strSQL += "   , KEISYOUCODE       = @KEISYOUCODE"
            strSQL += "   , SIHARAI_COMMENT_01= @SIHARAI_COMMENT_01"
            strSQL += "   , SIHARAI_COMMENT_02= @SIHARAI_COMMENT_02"
            strSQL += "   , SIHARAI_COMMENT_03= @SIHARAI_COMMENT_03"
            strSQL += "   , SIHARAI_COMMENT_04= @SIHARAI_COMMENT_04"
            strSQL += "   , SIHARAI_COMMENT_05= @SIHARAI_COMMENT_05"
            strSQL += "   , SIHARAI_COMMENT_06= @SIHARAI_COMMENT_06"
            strSQL += "   , AITE_MITUMORINO   = @AITE_MITUMORINO"
            strSQL += "   , KEIYAKUNO         = @KEIYAKUNO"
            If IsDate(row.NOUKI_START) Then
                strSQL += "   , NOUKI_START   = @NOUKI_START"
            Else
                strSQL += "   , NOUKI_START   = null"
            End If
            If IsDate(row.NOUKI_END) Then
                strSQL += "  , NOUKI_END     = @NOUKI_END"
            Else
                strSQL += "  , NOUKI_END     = null"
            End If
            strSQL += "   , AITEDENPYONO      = @AITEDENPYONO"
            strSQL += "   , GKGENKAGAKU_NUKI  = @GKGENKAGAKU_NUKI"
            strSQL += "   , GKTAX             = @GKTAX"
            strSQL += "   , GKGENKAGAKU       = @GKGENKAGAKU"
            strSQL += "   , D_BIKO            = @D_BIKO"
            strSQL += "   , SYORIKBN          = @SYORIKBN"
            strSQL += "   , SYORISTDATE       = getdate()"
            strSQL += "   , UPDATEMENT        = getdate()"
            strSQL += "   , UPDATEPGID        = @UPDATEPGID"
            strSQL += "   , UPDATEUSERCODE    = @UPDATEUSERCODE"
            strSQL += " where HATYUNO      = @HATYUNO"
            strSQL += " And   HATYUEDABAN  = @HATYUEDABAN1"
            strSQL += " And   HATYUEDABAN2 = @HATYUEDABAN2"

            _ExecuteLogic.ExecuteNonQuery(_Connection, Data.CommandType.Text, strSQL, param)
        End Sub

        Private Sub 発注トラン更新(ByVal decHATYUNO As Decimal, ByVal decHATYUEDABAN As Decimal, ByVal decHATYUEDABAN2 As Decimal)
            Dim strSQL As String = ""
            Dim param() = New SqlParameter() {
                New SqlParameter("@HATYUNO", decHATYUNO),
                New SqlParameter("@HATYUEDABAN1", decHATYUEDABAN),
                New SqlParameter("@HATYUEDABAN2", decHATYUEDABAN2)}
            _ExecuteLogic.ExecuteNonQuery(
                  _Connection _
                , Data.CommandType.Text _
                , "delete from T_HATYU where HATYUNO = @HATYUNO and HATYUEDABAN = @HATYUEDABAN1 and HATYUEDABAN2 = @HATYUEDABAN2" _
                , param)

            For Each row As dsHAT0001_Update.T_HATYURow In _WritingDataSet.T_HATYU

                param = New SqlParameter() {
                    New SqlParameter("@HATYUNO", row.HATYUNO),
                    New SqlParameter("@HATYUEDABAN1", row.HATYUEDABAN),
                    New SqlParameter("@HATYUEDABAN2", row.HATYUEDABAN2),
                    New SqlParameter("@JYUTYUEDABAN", row.JYUTYUEDABAN),
                    New SqlParameter("@KAISOCODE", row.KAISOCODE),
                    New SqlParameter("@JYUTYUEDABAN_DAIKAMOKU", row.JYUTYUEDABAN_DAIKAMOKU),
                    New SqlParameter("@KAISOCODE_DAIKAMOKU", row.KAISOCODE_DAIKAMOKU),
                    New SqlParameter("@HATYUDATE", row.HATYUDATE),
                    New SqlParameter("@JYUTYUNO", row.JYUTYUNO),
                    New SqlParameter("@DAIKAMOKUCODE", row.DAIKAMOKUCODE),
                    New SqlParameter("@CYUKAMOKUCODE", row.CYUKAMOKUCODE),
                    New SqlParameter("@SYOKAMOKUCODE", row.SYOKAMOKUCODE),
                    New SqlParameter("@KAMOKU_HINMOKU", row.KAMOKU_HINMOKU),
                    New SqlParameter("@HINSITU_KIKAKU_SIYO", row.HINSITU_KIKAKU_SIYO),
                    New SqlParameter("@TANI", row.TANI),
                    New SqlParameter("@SUU", row.SUU),
                    New SqlParameter("@KAKERITU", row.KAKERITU),
                    New SqlParameter("@GENTANKA", row.GENTANKA),
                    New SqlParameter("@GENKAGAKU", row.GENKAGAKU),
                    New SqlParameter("@IKATU_KAKERITU", row.IKATU_KAKERITU),
                    New SqlParameter("@G_BIKO", row.G_BIKO),
                    New SqlParameter("@UPDATEPGID", _UPDATEPGID),
                    New SqlParameter("@UPDATEUSERCODE", _UPDATEUSERCODE)}

                strSQL = "  insert into T_HATYU values ("
                strSQL += "     @HATYUNO"
                strSQL += "   , @HATYUEDABAN1"
                strSQL += "   , @HATYUEDABAN2"
                strSQL += "   , @JYUTYUEDABAN"
                strSQL += "   , @KAISOCODE"
                strSQL += "   , @JYUTYUEDABAN_DAIKAMOKU"
                strSQL += "   , @KAISOCODE_DAIKAMOKU"
                strSQL += "   , @HATYUDATE"
                strSQL += "   , @JYUTYUNO"
                strSQL += "   , @DAIKAMOKUCODE"
                strSQL += "   , @CYUKAMOKUCODE"
                strSQL += "   , @SYOKAMOKUCODE"
                strSQL += "   , @KAMOKU_HINMOKU"
                strSQL += "   , @HINSITU_KIKAKU_SIYO"
                strSQL += "   , @TANI"
                strSQL += "   , @SUU"
                strSQL += "   , @KAKERITU"
                strSQL += "   , @GENTANKA"
                strSQL += "   , @GENKAGAKU"
                strSQL += "   , @IKATU_KAKERITU"
                strSQL += "   , @G_BIKO"
                strSQL += "   , getdate()"
                strSQL += "   , @UPDATEPGID"
                strSQL += "   , @UPDATEUSERCODE"
                strSQL += "   , getdate()"
                strSQL += "   , getdate()"
                strSQL += " )"

                _ExecuteLogic.ExecuteNonQuery(_Connection, Data.CommandType.Text, strSQL, param)
            Next
        End Sub

        Private Sub 発注コメントトラン更新(ByVal decHATYUNO As Decimal, ByVal decHATYUEDABAN As Decimal, ByVal decHATYUEDABAN2 As Decimal)
            Dim strSQL As String = ""

            Dim param() = New SqlParameter() {
                    New SqlParameter("@HATYUNO", decHATYUNO),
                    New SqlParameter("@HATYUEDABAN1", decHATYUEDABAN),
                    New SqlParameter("@HATYUEDABAN2", decHATYUEDABAN2),
                    New SqlParameter("@UPDATEPGID", _UPDATEPGID),
                    New SqlParameter("@UPDATEUSERCODE", _UPDATEUSERCODE)}

            strSQL = "delete from T_HATYU_COMMENT where HATYUNO = @HATYUNO and HATYUEDABAN = @HATYUEDABAN1 and HATYUEDABAN2 = @HATYUEDABAN2"
            _ExecuteLogic.ExecuteNonQuery(_Connection, Data.CommandType.Text, strSQL, param)

            For Each row As dsHAT0001_Update.T_HATYU_COMMENTRow In _WritingDataSet.T_HATYU_COMMENT
                param = New SqlParameter() {
                    New SqlParameter("@HATYUNO", row.HATYUNO),
                    New SqlParameter("@HATYUEDABAN1", row.HATYUEDABAN),
                    New SqlParameter("@HATYUEDABAN2", row.HATYUEDABAN2),
                    New SqlParameter("@CATEGORYID", row.CATEGORYID),
                    New SqlParameter("@DATAKEY", row.DATAKEY),
                    New SqlParameter("@DATA", row.DATA),
                    New SqlParameter("@UPDATEPGID", _UPDATEPGID),
                    New SqlParameter("@UPDATEUSERCODE", _UPDATEUSERCODE)}

                strSQL = ""
                strSQL += " insert into T_HATYU_COMMENT values ("
                strSQL += "     @HATYUNO"
                strSQL += "   , @HATYUEDABAN1"
                strSQL += "   , @HATYUEDABAN2"
                strSQL += "   , @CATEGORYID"
                strSQL += "   , @DATAKEY"
                strSQL += "   , @DATA"
                strSQL += "   , getdate()"
                strSQL += "   , @UPDATEPGID"
                strSQL += "   , @UPDATEUSERCODE"
                strSQL += "   , getdate()"
                strSQL += "   , getdate()"
                strSQL += " )"

                _ExecuteLogic.ExecuteNonQuery(_Connection, Data.CommandType.Text, strSQL, param)
            Next
        End Sub

        Private Sub 受注ヘッダートラン更新(ByVal decHATYUNO As Decimal, ByVal decJYUTYUEDABAN As Decimal)

            Dim strSQL As String = ""
            Dim param() As SqlParameter

            Dim row As dsHAT0001_Update.T_JYUTYUHEDRow = _WritingDataSet.T_JYUTYUHED.Item(0)

            param = New SqlParameter() {
                New SqlParameter("@JYUTYUNO", row.JYUTYUNO),
                New SqlParameter("@JYUTYUEDABAN", row.JYUTYUNO),
                New SqlParameter("@LAST_HATYUNO", decHATYUNO),
                New SqlParameter("@LAST_HATYUDATE", row.LAST_HATYUDATE),
                New SqlParameter("@SUMI_HATYUGAKU", row.SUMI_HATYUGAKU),
                New SqlParameter("@UPDATEPGID", _UPDATEPGID),
                New SqlParameter("@UPDATEUSERCODE", _UPDATEUSERCODE)}

            strSQL = "update T_JYUTYUHED set"
            strSQL += " LAST_HATYUNO  =case when (isnull(LAST_HATYUDATE,'1900/01/01')> @LAST_HATYUDATE) then LAST_HATYUNO   else @LAST_HATYUNO   end"
            strSQL += ",LAST_HATYUDATE=case when (isnull(LAST_HATYUDATE,'1900/01/01')>=@LAST_HATYUDATE) then LAST_HATYUDATE else @LAST_HATYUDATE end"
            strSQL += ",SUMI_HATYUGAKU=SUMI_HATYUGAKU+@SUMI_HATYUGAKU"
            strSQL += ",STATUS_HATYU  =case when (SUMI_HATYUGAKU+@SUMI_HATYUGAKU)=0 then 0"
            strSQL += "                     when (GKGENKAGAKU> (SUMI_HATYUGAKU+@SUMI_HATYUGAKU)) then 1"
            strSQL += "                     when (GKGENKAGAKU<=(SUMI_HATYUGAKU+@SUMI_HATYUGAKU)) then 2"
            strSQL += "                end"
            strSQL += " where JYUTYUNO     = @JYUTYUNO"
            strSQL += " and   JYUTYUEDABAN = @JYUTYUEDABAN"

            _ExecuteLogic.ExecuteNonQuery(_Connection, Data.CommandType.Text, strSQL, param)

        End Sub

        Public Sub 削除(ByVal decHATYUNO As Decimal, ByVal decHATYUEDABAN As Decimal, ByVal decHATYUEDABAN2 As Decimal)
            Dim strSQL As String = ""
            Dim row As dsHAT0001_Update.T_JYUTYUHEDRow = _WritingDataSet.T_JYUTYUHED.Item(0)
            Dim param() = New SqlParameter() {
                    New SqlParameter("@HATYUNO", decHATYUNO),
                    New SqlParameter("@JYUTYUEDABAN", row.JYUTYUNO),
                    New SqlParameter("@HATYUEDABAN1", decHATYUEDABAN),
                    New SqlParameter("@HATYUEDABAN2", decHATYUEDABAN2),
                    New SqlParameter("@SUMI_HATYUGAKU", row.SUMI_HATYUGAKU),
                    New SqlParameter("@UPDATEPGID", _UPDATEPGID),
                    New SqlParameter("@UPDATEUSERCODE", _UPDATEUSERCODE)}

            Using ts As System.Transactions.TransactionScope = New System.Transactions.TransactionScope()
                strSQL += " delete from T_HATYUHED      where HATYUNO = @HATYUNO and HATYUEDABAN = @HATYUEDABAN1 and HATYUEDABAN2 = @HATYUEDABAN2;"
                strSQL += " delete from T_HATYU         where HATYUNO = @HATYUNO and HATYUEDABAN = @HATYUEDABAN1 and HATYUEDABAN2 = @HATYUEDABAN2;"
                strSQL += " delete from T_HATYU_COMMENT where HATYUNO = @HATYUNO and HATYUEDABAN = @HATYUEDABAN1 and HATYUEDABAN2 = @HATYUEDABAN2;"
                strSQL += " update T_JYUTYUHED"
                strSQL += " set SUMI_HATYUGAKU = SUMI_HATYUGAKU-@SUMI_HATYUGAKU"
                strSQL += "    ,STATUS_HATYU   = case when SUMI_HATYUGAKU-@SUMI_HATYUGAKU<=0 then 0 else 1 end"  '削除の場合は０：未または１：一部有のみ
                strSQL += " where JYUTYUNO     = @HATYUNO"
                strSQL += " and   JYUTYUEDABAN = @JYUTYUEDABAN;"
                _ExecuteLogic.ExecuteNonQuery(_Connection, Data.CommandType.Text, strSQL, param)

                '物件承認情報（発注）の削除
                Dim T_BUKKEN_APPROVAL As New T_BUKKEN_APPROVALRead
                If decHATYUEDABAN <> 0 AndAlso decHATYUEDABAN2 = 0 Then
                    '前の受注が存在する場合
                    T_BUKKEN_APPROVAL.deleteT_BUKKEN_APPROVAL_PK(decHATYUNO, T_BUKKEN_APPROVALRead.enumGyomuKbn.Hacchu, decHATYUEDABAN)
                End If

                '承認に更新
                If decHATYUEDABAN2 <> 0 Then
                    '前の発注が存在する場合
                    T_BUKKEN_APPROVAL.UpdateSyoninKbn(decHATYUNO, T_BUKKEN_APPROVALRead.enumGyomuKbn.Hacchu, decHATYUEDABAN, T_BUKKEN_APPROVALRead.enumApprovalKbn.SYONIN_ZUMI)
                End If

                ts.Complete()
            End Using
        End Sub
    End Class

    Public Class Report
        Inherits BLL.Common.DAL.DALBase

        Private _PCNAME As String
        Private _HATYUNO As Decimal
        Private _HATYUEDABAN As Decimal
        Private _HATYUEDABAN2 As Decimal
        Private _ExecuteLogic As BLL.Common.ExecuteQuery
        Private _Connectionstring As String

        Private Enum enum帳票種類
            注文書
            請書
        End Enum

        Public Sub New(ByVal strPCNAME As String, ByVal strHATYUNO As String, ByVal strHATYUEDABAN As String, ByVal strHATYUEDABAN2 As String)
            _PCNAME = strPCNAME
            _HATYUNO = CType(strHATYUNO, Decimal)
            _HATYUEDABAN = CType(strHATYUEDABAN, Decimal)
            _HATYUEDABAN2 = CType(strHATYUEDABAN2, Decimal)
            _ExecuteLogic = New BLL.Common.ExecuteQuery
            _Connectionstring = CommonUtility.DBUtility.GetConnectionString
        End Sub

        Public Function GetList(ByVal zeiKbn As String) As dsHAT0001_Report

            Dim ReportDataSets As New dsHAT0001_Report

            Dim param = New SqlParameter() {
                New SqlParameter("@HATYUNO", _HATYUNO),
                New SqlParameter("@HATYUEDABAN1", _HATYUEDABAN),
                New SqlParameter("@HATYUEDABAN2", _HATYUEDABAN2),
                New SqlParameter("@PCNAME", _PCNAME)}

            Call 明細部作成(zeiKbn)

            _ExecuteLogic.FillDataset(connectionString, Data.CommandType.Text, 鏡情報(enum帳票種類.注文書), ReportDataSets, New String() {"鏡_注文書"}, param)
            _ExecuteLogic.FillDataset(connectionString, Data.CommandType.Text, 鏡情報(enum帳票種類.請書), ReportDataSets, New String() {"鏡_請書"}, param)
            _ExecuteLogic.FillDataset(connectionString, Data.CommandType.Text, 明細情報(1), ReportDataSets, New String() {"明細"}, param)
            _ExecuteLogic.FillDataset(connectionString, Data.CommandType.Text, 明細情報(2), ReportDataSets, New String() {"内訳明細"}, param)

            Return ReportDataSets
        End Function

        Private Function 明細情報(ByVal intPAGE As Integer) As String
            Return "select * from WT_HAT0001M where PCNAME=@PCNAME and PAGE=@PAGE order by KBN, GYONO".Replace("@PAGE", intPAGE.ToString)
        End Function

        Private Function 鏡情報(ByVal 帳票種類 As enum帳票種類) As String

            Dim strSQL As String = ""

            Dim param() As SqlParameter
            param = New SqlParameter() {
                New SqlParameter("@HATYUNO", _HATYUNO),
                New SqlParameter("@HATYUEDABAN1", _HATYUEDABAN),
                New SqlParameter("@HATYUEDABAN2", _HATYUEDABAN2)}

            strSQL += " select" + vbCrLf
            If 帳票種類 = enum帳票種類.注文書 Then
                If _HATYUEDABAN2 = 0 Then
                    strSQL += "     '注　　　文　　　書'      TITLE" + vbCrLf                          'タイトル
                Else
                    strSQL += "     '注  文  変  更  書'      TITLE" + vbCrLf                          'タイトル
                End If
            Else
                If _HATYUEDABAN2 = 0 Then
                    strSQL += "     '注　　文　　請　　書'      TITLE" + vbCrLf                          'タイトル
                Else
                    strSQL += "     '注  文  変  更  請  書'      TITLE" + vbCrLf                          'タイトル
                End If
            End If
            strSQL += "   , isnull(S_SCB_LABEL_01.DATA,'')      LABEL_01" + vbCrLf                          'コメントＡ
            strSQL += "   , T_HATYUHED.HATYUDATE" + vbCrLf                                                  '発注日付
            strSQL += "   , T_HATYUHED.KEIYAKUNO" + vbCrLf                                                  '契約Ｎｏ
            If 帳票種類 = enum帳票種類.注文書 Then
                strSQL += ",isnull(M_SIIRE.SIIRENAME,'') SIIRENAME" + vbCrLf                                              '業者名
                '自社情報
                strSQL += "   , isnull(S_SCB_JISYANAME.DATA,'') JISYANAME" + vbCrLf                         '自社名称
                strSQL += "   , isnull(S_SCB_ADDRESS1.DATA,'')  ADDRESS1" + vbCrLf                          '住所１
                strSQL += "   , isnull(S_SCB_ADDRESS2.DATA,'')  ADDRESS2" + vbCrLf                          '住所２
                strSQL += "   , isnull(S_SCB_TELNO.DATA,'')     TELNO" + vbCrLf                             '電話番号
                strSQL += "   , isnull(S_SCB_FAXNO.DATA,'')     FAXNO" + vbCrLf                             'ＦＡＸ番号
            Else
                strSQL += ",isnull(S_SCB_JISYANAME.DATA,'') SIIRENAME" + vbCrLf                         '請書の場合は業者名は自社情報
                '請書の場合は自社情報は業者情報
                strSQL += "   , isnull(M_SIIRE.SIIRENAME,'') JISYANAME" + vbCrLf
                strSQL += "   , isnull(M_SIIRE.ADDRESS1,'')  ADDRESS1" + vbCrLf
                strSQL += "   , isnull(M_SIIRE.ADDRESS2,'')  ADDRESS2" + vbCrLf
                strSQL += "   , isnull(M_SIIRE.TELNO,'')     TELNO" + vbCrLf
                strSQL += "   , isnull(M_SIIRE.FAXNO,'')     FAXNO" + vbCrLf
            End If

            strSQL += "   , isnull(LABEL_02.DATA,'')            LABEL_02" + vbCrLf                          'コメント欄
            strSQL += "   , T_JYUTYUHED.KOUJINAME" + vbCrLf                                                 '工事名称
            strSQL += "   , T_JYUTYUHED.KOUJIBASYO" + vbCrLf                                                '工事場所
            strSQL += "   , isnull(convert(varchar,T_HATYUHED.NOUKI_START,111),'') NOUKI_START" + vbCrLf    '工(納)期（開始）
            strSQL += "   , isnull(convert(varchar,T_HATYUHED.NOUKI_END,  111),'') NOUKI_END" + vbCrLf      '工(納)期（終了）
            strSQL += "   , T_HATYUHED.GKGENKAGAKU" + vbCrLf                                                '契約金額

            '支払条件
            strSQL += "   , M_SIIRE.SIMEBI1" + vbCrLf                                                    '締日
            strSQL += "   , M_SIIRE.SIHARAIBI1" + vbCrLf                                                 '支払日
            strSQL += "   , M_SIIRE.KENSYU_DEKIDAKA" + vbCrLf                                            '検収出来高
            strSQL += "   , M_SIIRE.SIHARAI_GENKINRITU" + vbCrLf                                         '現金
            strSQL += "   , M_SIIRE.SIHARAI_TEGATARITU" + vbCrLf                                         '手形

            For intComment As Integer = 1 To 6
                strSQL += "   , T_HATYUHED.SIHARAI_COMMENT_@COMMENT SIHARAI_COMMENT_@COMMENT"
                strSQL = Replace(strSQL, "@COMMENT", CommonUtility.Utility.ZeroFormat(intComment.ToString, 2))
            Next

            For intComment As Integer = 1 To 9  'コメント01から09
                strSQL += "   , COMMENT_@COMMENT.DATA COMMENT_@COMMENT"
                strSQL = Replace(strSQL, "@COMMENT", CommonUtility.Utility.ZeroFormat(intComment.ToString, 2))
            Next

            strSQL += " from T_HATYUHED" + vbCrLf
            strSQL += " left join T_HATYU_COMMENT LABEL_02 on LABEL_02.HATYUNO      = T_HATYUHED.HATYUNO" + vbCrLf
            strSQL += "                                   and LABEL_02.HATYUEDABAN  = T_HATYUHED.HATYUEDABAN" + vbCrLf
            strSQL += "                                   and LABEL_02.HATYUEDABAN2 = T_HATYUHED.HATYUEDABAN2" + vbCrLf
            strSQL += "                                   and LABEL_02.CATEGORYID   = '@@CATEGORYID'" + vbCrLf
            strSQL += "                                   and LABEL_02.DATAKEY      = 'LABEL_02'" + vbCrLf
            For intComment As Integer = 1 To 9  'コメント01から09
                strSQL += " left join T_HATYU_COMMENT COMMENT_@COMMENT on COMMENT_@COMMENT.HATYUNO      = T_HATYUHED.HATYUNO" + vbCrLf
                strSQL += "                                           and COMMENT_@COMMENT.HATYUEDABAN  = T_HATYUHED.HATYUEDABAN" + vbCrLf
                strSQL += "                                           and COMMENT_@COMMENT.HATYUEDABAN2 = T_HATYUHED.HATYUEDABAN2" + vbCrLf
                strSQL += "                                           and COMMENT_@COMMENT.CATEGORYID   = '@@CATEGORYID'" + vbCrLf
                strSQL += "                                           and COMMENT_@COMMENT.DATAKEY      = 'COMMENT_@COMMENT'" + vbCrLf
                strSQL = Replace(strSQL, "@COMMENT", CommonUtility.Utility.ZeroFormat(intComment.ToString, 2))
            Next

            strSQL += " left join M_SIIRE               on  M_SIIRE.SIIRECODE          = T_HATYUHED.SIIRECODE" + vbCrLf
            strSQL += " left join S_SCB S_SCB_LABEL_01  on  S_SCB_LABEL_01.CATEGORYID  = '@@CATEGORYID'" + vbCrLf
            strSQL += "                                 and S_SCB_LABEL_01.DATAKEY     = 'LABEL_01'" + vbCrLf
            strSQL += " left join S_SCB S_SCB_JISYANAME on  S_SCB_JISYANAME.CATEGORYID = 'INFO_JISYA' and S_SCB_JISYANAME.DATAKEY = 'JISYANAME'" + vbCrLf
            strSQL += " left join S_SCB S_SCB_ADDRESS1  on  S_SCB_ADDRESS1.CATEGORYID  = 'INFO_JISYA' and S_SCB_ADDRESS1.DATAKEY  = 'ADDRESS1'" + vbCrLf
            strSQL += " left join S_SCB S_SCB_ADDRESS2  on  S_SCB_ADDRESS2.CATEGORYID  = 'INFO_JISYA' and S_SCB_ADDRESS2.DATAKEY  = 'ADDRESS2'" + vbCrLf
            strSQL += " left join S_SCB S_SCB_TELNO     on  S_SCB_TELNO.CATEGORYID     = 'INFO_JISYA' and S_SCB_TELNO.DATAKEY     = 'TELNO'" + vbCrLf
            strSQL += " left join S_SCB S_SCB_FAXNO     on  S_SCB_FAXNO.CATEGORYID     = 'INFO_JISYA' and S_SCB_FAXNO.DATAKEY     = 'FAXNO'" + vbCrLf
            strSQL += " left join T_JYUTYUHED on T_HATYUHED.JYUTYUNO = T_JYUTYUHED.JYUTYUNO and T_HATYUHED.JYUTYUEDABAN = T_JYUTYUHED.JYUTYUEDABAN"
            strSQL += " where T_HATYUHED.HATYUNO      = @HATYUNO"
            strSQL += " and   T_HATYUHED.HATYUEDABAN  = @HATYUEDABAN1"
            strSQL += " and   T_HATYUHED.HATYUEDABAN2 = @HATYUEDABAN2"

            If 帳票種類 = enum帳票種類.注文書 Then
                strSQL = Replace(strSQL, "@@CATEGORYID", "HATYU_PRI")
            Else
                strSQL = Replace(strSQL, "@@CATEGORYID", "HATYU_PRI_UKE")
            End If

            Return strSQL
        End Function

        Private Sub 明細部作成(ByVal zeiKbn As String)

            Dim strSQL As String = ""

            Dim param() As SqlParameter
            param = New SqlParameter() {
                New SqlParameter("@PCNAME", _PCNAME),
                New SqlParameter("@HATYUNO", _HATYUNO),
                New SqlParameter("@HATYUEDABAN1", _HATYUEDABAN),
                New SqlParameter("@HATYUEDABAN2", _HATYUEDABAN2)}

            '削除
            _ExecuteLogic.ExecuteNonQuery(_Connectionstring, Data.CommandType.Text, "delete from WT_HAT0001M where PCNAME=@PCNAME", param)

            '明細行数チェック
            Dim meisaiCnt = (_ExecuteLogic.ExecuteDataset(
                  _Connectionstring _
                , Data.CommandType.Text _
                , "select * from T_HATYU where HATYUNO=@HATYUNO and HATYUEDABAN = @HATYUEDABAN1 and HATYUEDABAN2 = @HATYUEDABAN2" _
                , param).Tables(0).Rows.Count)

            '明細が0件の場合、登録しない
            If meisaiCnt = 0 Then Return

            '１行目　（見積書通り）
            strSQL = ""
            strSQL += " insert into WT_HAT0001M"
            strSQL += " select @PCNAME, 1 PAGE, 0 KBN, 1 GYO, DATA NAME, '' SURYO, '' TANI, '' TANKA, '' KINGAKU"
            strSQL += " from S_SCB"
            strSQL += " where CATEGORYID = 'HATYU_PRI'"
            strSQL += " and   DATAKEY    = 'MEISAI_01'"

            _ExecuteLogic.ExecuteNonQuery(_Connectionstring, Data.CommandType.Text, strSQL, param)

            '８行を超える場合は、２行目に特定のコメント。明細を表示
            If meisaiCnt > 8 Then
                '「※詳細は別紙内訳表にて記載※」
                strSQL = ""
                strSQL += " insert into WT_HAT0001M"
                strSQL += " select @PCNAME, 1 PAGE, 1 KBN, 2 GYO, DATA NAME, '' SURYO, '' TANI, '' TANKA, '' KINGAKU"
                strSQL += " from S_SCB"
                strSQL += " where CATEGORYID = 'HATYU_PRI'"
                strSQL += " and   DATAKEY    = 'MEISAI_02'"

                _ExecuteLogic.ExecuteNonQuery(_Connectionstring, Data.CommandType.Text, strSQL, param)
            Else
                '２行目以降トランより印字
                strSQL = ""
                strSQL += " insert into WT_HAT0001M"
                strSQL += " select @PCNAME, 1 PAGE, 1 KBN, row_number() over(order by KAISOCODE)+1, isnull(KAMOKU_HINMOKU,'') + space(1) + isnull(HINSITU_KIKAKU_SIYO,''), SUU, TANI, GENTANKA, GENKAGAKU"
                strSQL += " from T_HATYU"
                strSQL += " where HATYUNO      = @HATYUNO"
                strSQL += " and   HATYUEDABAN  = @HATYUEDABAN1"
                strSQL += " and   HATYUEDABAN2 = @HATYUEDABAN2"
                strSQL += " order by KAISOCODE"
                _ExecuteLogic.ExecuteNonQuery(_Connectionstring, Data.CommandType.Text, strSQL, param)
            End If

            Dim wtPage = "1"

            If meisaiCnt > 8 Then
                '８行を超える場合は注文内訳書用にページ２データを作成
                wtPage = "2"

                '２行目以降トランより印字
                strSQL = ""
                strSQL += " insert into WT_HAT0001M select @PCNAME, 2 PAGE, 1 KBN, row_number() over(order by KAISOCODE)+1, isnull(KAMOKU_HINMOKU,'') + space(1) + isnull(HINSITU_KIKAKU_SIYO,''), SUU, TANI, GENTANKA, GENKAGAKU"
                strSQL += " from T_HATYU"
                strSQL += " where HATYUNO      = @HATYUNO"
                strSQL += " and   HATYUEDABAN  = @HATYUEDABAN1"
                strSQL += " and   HATYUEDABAN2 = @HATYUEDABAN2"
                strSQL += " order by KAISOCODE"
                _ExecuteLogic.ExecuteNonQuery(_Connectionstring, Data.CommandType.Text, strSQL, param)
            End If

            '小計、消費税、合計の登録
            For intGYONO As Integer = 3 To 5
                strSQL = ""
                strSQL += " insert into WT_HAT0001M" + vbCrLf
                strSQL += " select @PCNAME, " + wtPage + " PAGE, 2 KBN, @GYONO+7, DATA, '','', '', @@KINGAKU from T_HATYUHED" + vbCrLf
                strSQL += " left join (select DATA from S_SCB where CATEGORYID='HATYU_PRI' and DATAKEY='" + "MEISAI_" + "@GYONO" + "@ZEI_UCHI') S_SCB on 1=1 " + vbCrLf
                strSQL += " where HATYUNO      = @HATYUNO" + vbCrLf
                strSQL += " and   HATYUEDABAN  = @HATYUEDABAN1" + vbCrLf
                strSQL += " and   HATYUEDABAN2 = @HATYUEDABAN2" + vbCrLf

                strSQL = Replace(strSQL, "@GYONO", ZeroFormat(intGYONO.ToString, 2))

                If intGYONO = 4 AndAlso zeiKbn = "1" Then
                    '内税の場合
                    strSQL = Replace(strSQL, "@ZEI_UCHI", "_UCHI")
                Else
                    '上記以外の場合
                    strSQL = Replace(strSQL, "@ZEI_UCHI", "")
                End If

                Select Case intGYONO
                    Case 3 : strSQL = Replace(strSQL, "@@KINGAKU", "GKGENKAGAKU_NUKI")
                    Case 4 : strSQL = Replace(strSQL, "@@KINGAKU", "GKTAX")
                    Case 5 : strSQL = Replace(strSQL, "@@KINGAKU", "GKGENKAGAKU")
                End Select
                _ExecuteLogic.ExecuteNonQuery(_Connectionstring, Data.CommandType.Text, strSQL, param)
            Next
        End Sub
    End Class
End Namespace
