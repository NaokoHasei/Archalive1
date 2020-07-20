Imports Microsoft.ApplicationBlocks.Data
Imports CommonUtility
Imports Model
Imports Model.DTO

Public Class TypComboBox

    Private connectionString As String

    Public Sub New()
        connectionString = CommonUtility.DBUtility.GetConnectionString
    End Sub

    Public Function CreateComboBox(ByVal requestParams As RequestGetComboBoxContents) As ResponseGetComboBoxContents

        Dim resultDataSets As New Dictionary(Of Model.ComboBoxTableName, Model.DTO.ResponseGetComboBoxContentsElement)

        Dim requestTableParam As RequestGetComboBoxContentsElement
        For Each requestTableParam In requestParams.TableList
            resultDataSets(requestTableParam.TableName) = Create(requestTableParam)
        Next

        Return New ResponseGetComboBoxContents(resultDataSets)

    End Function

    Public Function Create(ByVal requestParam As RequestGetComboBoxContentsElement) As ResponseGetComboBoxContentsElement

        Dim sqlList As New Dictionary(Of Model.ComboBoxTableName, String)
        Dim SingleField As String = vbNullString
        Dim MultipleField As String = vbNullString
        Dim FieldName As String = vbNullString
        Dim Field As String = vbNullString
        Dim BlankSql As String = vbNullString
        Dim Where As String = ""

        If (requestParam.InsertBlank = True) Then BlankSql = "UNION SELECT '','' "

        Select Case requestParam.TableName

            Case ComboBoxTableName.M_BUKA
                FieldName = "部課名称"
                SingleField = "BUKACODE AS コード, BUKACODE + ' ' + ISNULL(BUKANAME,'') AS 名称 "
                MultipleField = "BUKACODE AS コード, BUKANAME AS " & FieldName & " "

            Case ComboBoxTableName.M_KBN
                Select Case Utility.LeftBSA(requestParam.ConditionCode, 2)
                    Case "04" : FieldName = "敬称"
                    Case Else : FieldName = "区分名"
                End Select
                SingleField = "ISNULL(KBNNAME,'') AS 名称 "
                MultipleField = "KBN AS コード, KBNNAME AS " & FieldName & " "
                Where = "WHERE SIYOUKBN='" + requestParam.ConditionCode + "' "

            Case ComboBoxTableName.M_TANTO
                FieldName = "担当者名"
                SingleField = "TANTOCODE AS コード, TANTOCODE + ' ' + ISNULL(TANTONAME,'') AS 名称 "
                MultipleField = "TANTOCODE AS コード, TANTONAME AS " & FieldName & " "

            Case ComboBoxTableName.M_TOKUI
                FieldName = "顧客名"
                SingleField = "TOKUICODE AS コード, TOKUICODE + ' ' + ISNULL(TOKUINAME,'') AS 名称 "
                MultipleField = "TOKUICODE AS コード, TOKUINAME AS " & FieldName & " "
                If Utility.NUCheck(requestParam.ConditionCode) = False Then
                    Where += "WHERE TOKUICODE = SEIKYUCODE "
                Else
                    Where += "WHERE 1=1 "
                End If

            Case ComboBoxTableName.M_SIIRE
                FieldName = "業者名"
                SingleField = "SIIRECODE AS コード, SIIRECODE + ' ' + ISNULL(SIIRENAME,'') AS 名称 "
                MultipleField = "SIIRECODE AS コード, SIIRENAME AS " & FieldName & " "

            Case ComboBoxTableName.T_MITUMORIHED_MITUMORINO
                FieldName = "見積Ｎｏ"
                SingleField = "RIGHT('0000000000' + convert(varchar,HED.MITUMORINO), 10) AS 見積Ｎｏ, RIGHT('0000000000' + convert(varchar,HED.MITUMORINO), 10) + ' ' + ISNULL(RIGHT('00' + convert(varchar,HED.MITUMORIEDABAN), 2),'') AS 名称 "
                MultipleField = "   RIGHT('0000000000' + convert(varchar,HED.MITUMORINO), 10) + '-' + RIGHT('00' + convert(varchar,HED.MITUMORIEDABAN), 2) AS 見積Ｎｏ "
                MultipleField += ", CONVERT(NVARCHAR, HED.MITUMORIDATE, 111) 提出日付 "
                MultipleField += ", TOK.TOKUINAME AS 顧客名 "
                MultipleField += ", HED.KOUJINAME AS 工事名 "
                MultipleField += ", HED.KOUJINO AS 工事番号 "
                MultipleField += ", HED.KOUJIBASYO AS 工事場所 "
                If Utility.NUCheck(requestParam.ConditionCode) = False Then
                    Where += "WHERE HED.MITUMORINO = " & requestParam.ConditionCode
                Else
                    Where += "WHERE 1=1 "
                End If

            Case ComboBoxTableName.T_JYUTYUHED_JYUTYUNO
                FieldName = "受注Ｎｏ"
                SingleField = "RIGHT('0000000000' + convert(varchar,HED.JYUTYUNO), 10) AS 受注Ｎｏ, RIGHT('0000000000' + convert(varchar,HED.JYUTYUNO), 10) + ' ' + ISNULL(RIGHT('00' + convert(varchar,HED.JYUTYUEDABAN), 2),'') AS 名称 "
                MultipleField = "   RIGHT('0000000000' + convert(varchar,HED.JYUTYUNO), 10) + '-' + RIGHT('00' + convert(varchar,HED.JYUTYUEDABAN), 2) AS 受注Ｎｏ "
                MultipleField += ", CONVERT(NVARCHAR, HED.JYUTYUDATE, 111) 受注日付 "
                Where += "WHERE HED.JYUTYUNO = " & requestParam.ConditionCode

            Case ComboBoxTableName.T_HATYUHED_HATYUNO
                FieldName = "発注Ｎｏ"
                SingleField = "RIGHT('0000000000' + convert(varchar,HED.HATYUNO), 10) AS 受注Ｎｏ, RIGHT('0000000000' + convert(varchar,HED.HATYUNO), 10) + ' ' + ISNULL(RIGHT('00' + convert(varchar,HED.HATYUEDABAN), 2),'') AS 名称 "
                MultipleField = "   RIGHT('0000000000' + convert(varchar,HED.HATYUNO), 10) + '-' + RIGHT('00' + convert(varchar,HED.HATYUEDABAN), 2) + '-' + RIGHT('00' + convert(varchar,HED.HATYUEDABAN2), 2) AS 発注Ｎｏ "
                MultipleField += ", CASE WHEN SUB.HATYUNO IS NULL THEN '済' WHEN APP.APPROVALKBN = 2 THEN '済' ELSE '' END                             AS 承認"
                MultipleField += ", ISNULL(SII.SIIRENAME, '')                                                                                          AS 業者名 "
                MultipleField += ", CONVERT(NVARCHAR, HED.HATYUDATE, 111)                                                                              AS 発注日付 "
                MultipleField += ",  RIGHT('0000000000' + convert(varchar,HED.HATYUNO), 10) + '-' + RIGHT('00' + convert(varchar,HED.JYUTYUEDABAN), 2) AS 受注Ｎｏ "
                MultipleField += ", REPLACE(CONVERT(nvarchar,CONVERT(money, HED.GKGENKAGAKU_NUKI), 1), '.00', '')                                      AS 発注金額 "
                Where += "WHERE HED.HATYUNO = " & requestParam.ConditionCode

            Case ComboBoxTableName.T_SEIKYUHED_SEIKYUNO
                FieldName = "請求Ｎｏ"
                SingleField = "RIGHT('0000000000' + convert(varchar,HED.SEIKYUNO), 10) AS 請求Ｎｏ, RIGHT('0000000000' + convert(varchar,HED.SEIKYUNO), 10) AS 名称 "
                MultipleField = "   RIGHT('0000000000' + convert(varchar,HED.SEIKYUNO), 10) + '-' + RIGHT('00' + convert(varchar,HED.SEIKYUEDABAN), 2)  AS 請求Ｎｏ "
                MultipleField += ", CONVERT(NVARCHAR, HED.SEIKYUDATE, 111)                                                                              AS 請求日付 "
                MultipleField += ", RIGHT('0000000000' + convert(varchar,HED.SEIKYUNO), 10) + '-' + RIGHT('00' + convert(varchar,HED.JYUTYUEDABAN), 2)  AS 受注Ｎｏ "
                MultipleField += ", CONVERT(NVARCHAR, JYU.JYUTYUDATE, 111)                                                                              AS 受注日付 "
                MultipleField += ", REPLACE(CONVERT(nvarchar,CONVERT(money, JYU.GKJYUTYUGAKU), 1), '.00', '')                                           AS 受注金額 "
                MultipleField += ", REPLACE(CONVERT(nvarchar,CONVERT(money, "
                MultipleField += "    (SELECT SUM(SUB.GKSEIKYUGAKU) FROM T_SEIKYUHED SUB WHERE SUB.SEIKYUNO = " & requestParam.ConditionCode & " AND SUB.SEIKYUEDABAN <= HED.SEIKYUEDABAN)"
                MultipleField += "    ), 1), '.00', '')                                                                                                 AS 今回迄請求額 "
                MultipleField += ", REPLACE(CONVERT(nvarchar,CONVERT(money, HED.GKSEIKYUGAKU), 1), '.00', '')                                           AS 今回請求額 "

                Where += " WHERE HED.SEIKYUNO = " & requestParam.ConditionCode

            Case ComboBoxTableName.M_DAIKAMOKU
                FieldName = "大科目名"
                SingleField = "DAIKAMOKUCODE AS コード, DAIKAMOKUCODE + ' ' + ISNULL(DAIKAMOKUNAME,'') AS 名称 "
                MultipleField = "DAIKAMOKUCODE AS コード, DAIKAMOKUNAME AS " & FieldName & " "

            Case ComboBoxTableName.M_CYUKAMOKU
                FieldName = "中科目名"
                SingleField = "CYUKAMOKUCODE AS コード, CYUKAMOKUCODE + ' ' + ISNULL(CYUKAMOKUNAME,'') AS 名称 "
                MultipleField = "CYUKAMOKUCODE AS コード, CYUKAMOKUNAME AS " & FieldName & " "

            Case ComboBoxTableName.M_KEN_TODOUFUKEN
                Field = "TODOUFUKEN"

            Case ComboBoxTableName.M_KEN_SIKUTYOUSON
                Field = "SIKUTYOUSON"
                If Utility.NUCheck(requestParam.ConditionCode) = False Then
                    Where += "WHERE TODOUFUKEN like '" & Utility.EscapeLikeExpressionSQL(requestParam.ConditionCode) & "%'"
                Else
                    Where += "WHERE 1=0 "
                End If

            Case ComboBoxTableName.M_KEN_TYOUIKI
                Field = "TYOUIKI"
                If Utility.NUCheck(requestParam.ConditionCode) = False AndAlso requestParam.ConditionCode.Replace(",", "").Trim() <> "" Then
                    Dim s() As String = requestParam.ConditionCode.Split(","c)
                    Where += "WHERE TODOUFUKEN like '" & Utility.EscapeLikeExpressionSQL(s(0)) & "%'"
                    If s.Length > 1 Then
                        Where += "AND SIKUTYOUSON like '" & Utility.EscapeLikeExpressionSQL(s(1)) & "%'"
                    End If
                Else
                    Where += "WHERE 1=0 "
                End If

            Case ComboBoxTableName.S_SCB
                FieldName = "名称"
                If Utility.NUCheck(requestParam.ConditionCode) = False AndAlso requestParam.ConditionCode.Replace(",", "").Trim() <> "" Then
                    Dim s() As String = requestParam.ConditionCode.Split(","c)
                    Where += "WHERE CATEGORYID = '" & Utility.EscapeLikeExpressionSQL(s(0)) & "'"
                Else
                    Where += "WHERE 1=0 "
                End If

        End Select

        If (requestParam.ResultFieldType = GetComboBoxContentsResultFieldType.SingleField) Then
            Field = SingleField
        Else
            Field = MultipleField
        End If

        sqlList.Add(ComboBoxTableName.M_BUKA, "SELECT " & Field & "FROM M_BUKA " & BlankSql & "ORDER BY BUKACODE")
        sqlList.Add(ComboBoxTableName.M_KBN, "SELECT " & Field & "FROM M_KBN " & Where & BlankSql & "ORDER BY KBN")
        sqlList.Add(ComboBoxTableName.M_TANTO, "SELECT " & Field & "FROM M_TANTO " & BlankSql & "ORDER BY TANTOCODE")
        sqlList.Add(ComboBoxTableName.M_TOKUI, "SELECT " & Field & "FROM M_TOKUI " & Where & "ORDER BY TOKUICODE")
        sqlList.Add(ComboBoxTableName.M_SIIRE, "SELECT " & Field & "FROM M_SIIRE ORDER BY SIIRECODE")
        sqlList.Add(ComboBoxTableName.T_MITUMORIHED_MITUMORINO, "SELECT " & Field & "FROM T_MITUMORIHED HED LEFT JOIN M_TOKUI TOK ON HED.TOKUICODE=TOK.TOKUICODE " & Where & "ORDER BY MITUMORINO desc, MITUMORIEDABAN desc")
        sqlList.Add(ComboBoxTableName.T_JYUTYUHED_JYUTYUNO, "SELECT " & Field & "FROM T_JYUTYUHED HED " & Where & "ORDER BY JYUTYUEDABAN desc")

        Dim strSQL = ""
        strSQL += " SELECT " & Field
        strSQL += " FROM T_HATYUHED HED"
        strSQL += " LEFT OUTER JOIN M_SIIRE SII"
        strSQL += "   ON SII.SIIRECODE = HED.SIIRECODE"
        strSQL += " LEFT OUTER JOIN ("
        strSQL += "   SELECT"
        strSQL += "       HATYUNO"
        strSQL += "     , HATYUEDABAN"
        strSQL += "     , MAX(HATYUEDABAN2) AS HATYUEDABAN2"
        strSQL += "   FROM T_HATYUHED"
        strSQL += " " + Replace(Where, "HED.", "")
        strSQL += "   GROUP BY"
        strSQL += "       HATYUNO"
        strSQL += "     , HATYUEDABAN"
        strSQL += "   ) SUB"
        strSQL += "   ON  SUB.HATYUNO      = HED.HATYUNO"
        strSQL += "   AND SUB.HATYUEDABAN  = HED.HATYUEDABAN"
        strSQL += "   AND SUB.HATYUEDABAN2 = HED.HATYUEDABAN2"
        strSQL += " LEFT OUTER JOIN T_BUKKEN_APPROVAL APP"
        strSQL += "   ON  APP.BUKKENNO = HED.HATYUNO"
        strSQL += "   AND APP.GYOMUKBN = 3"
        strSQL += "   AND APP.EDABAN   = HED.HATYUEDABAN"
        strSQL += " " + Where
        strSQL += " ORDER BY"
        strSQL += "     HED.HATYUEDABAN DESC"
        strSQL += "   , HED.HATYUEDABAN2 DESC"
        sqlList.Add(ComboBoxTableName.T_HATYUHED_HATYUNO, strSQL)

        sqlList.Add(ComboBoxTableName.T_SEIKYUHED_SEIKYUNO, "SELECT " & Field & "FROM T_SEIKYUHED HED LEFT JOIN T_JYUTYUHED JYU ON JYU.JYUTYUNO=HED.SEIKYUNO AND JYU.JYUTYUEDABAN = HED.JYUTYUEDABAN " + Where + " ORDER BY SEIKYUNO desc, SEIKYUEDABAN desc")
        sqlList.Add(ComboBoxTableName.M_DAIKAMOKU, "SELECT " & Field & "FROM M_DAIKAMOKU ORDER BY DAIKAMOKUCODE")
        sqlList.Add(ComboBoxTableName.M_CYUKAMOKU, "SELECT " & Field & "FROM M_CYUKAMOKU ORDER BY CYUKAMOKUCODE")
        sqlList.Add(ComboBoxTableName.M_KEN_TODOUFUKEN, "SELECT TODOUFUKEN as CODE FROM M_KEN GROUP BY TODOUFUKEN,TODOUFUKEN_KANA ORDER BY TODOUFUKEN_KANA")
        sqlList.Add(ComboBoxTableName.M_KEN_SIKUTYOUSON, "SELECT SIKUTYOUSON as CODE FROM M_KEN " + Where + " GROUP BY SIKUTYOUSON,SIKUTYOUSON_KANA ORDER BY SIKUTYOUSON_KANA")
        sqlList.Add(ComboBoxTableName.M_KEN_TYOUIKI, "SELECT TYOUIKI as CODE FROM M_KEN " + Where + " GROUP BY TYOUIKI,TYOUIKI_KANA ORDER BY TYOUIKI_KANA")
        sqlList.Add(ComboBoxTableName.S_SCB, "SELECT DATAKEY as コード, DATA as 名称 FROM S_SCB " + Where + " ORDER BY DATAKEY")

        If requestParam.TableName = ComboBoxTableName.T_MITUMORIHED_MITUMORINO Then
            If (requestParam.ResultFieldType = GetComboBoxContentsResultFieldType.SingleField) Then
                Return New ResponseGetComboBoxContentsElement("見積Ｎｏ", New String() {"名称"}, SqlHelper.ExecuteDataset(connectionString, CommandType.Text, sqlList(requestParam.TableName)))
            Else
                Return New ResponseGetComboBoxContentsElement("見積Ｎｏ", New String() {"見積Ｎｏ", FieldName}, SqlHelper.ExecuteDataset(connectionString, CommandType.Text, sqlList(requestParam.TableName)))
            End If
        End If

        If requestParam.TableName = ComboBoxTableName.T_JYUTYUHED_JYUTYUNO Then
            If (requestParam.ResultFieldType = GetComboBoxContentsResultFieldType.SingleField) Then
                Return New ResponseGetComboBoxContentsElement("受注Ｎｏ", New String() {"名称"}, SqlHelper.ExecuteDataset(connectionString, CommandType.Text, sqlList(requestParam.TableName)))
            Else
                Return New ResponseGetComboBoxContentsElement("受注Ｎｏ", New String() {"受注Ｎｏ", FieldName}, SqlHelper.ExecuteDataset(connectionString, CommandType.Text, sqlList(requestParam.TableName)))
            End If
        End If

        If requestParam.TableName = ComboBoxTableName.T_HATYUHED_HATYUNO Then
            If (requestParam.ResultFieldType = GetComboBoxContentsResultFieldType.SingleField) Then
                Return New ResponseGetComboBoxContentsElement("発注Ｎｏ", New String() {"名称"}, SqlHelper.ExecuteDataset(connectionString, CommandType.Text, sqlList(requestParam.TableName)))
            Else
                Return New ResponseGetComboBoxContentsElement("発注Ｎｏ", New String() {"発注Ｎｏ", FieldName}, SqlHelper.ExecuteDataset(connectionString, CommandType.Text, sqlList(requestParam.TableName)))
            End If
        End If

        If requestParam.TableName = ComboBoxTableName.M_KEN_TODOUFUKEN Then
            Return New ResponseGetComboBoxContentsElement("CODE", New String() {"CODE"}, SqlHelper.ExecuteDataset(connectionString, CommandType.Text, sqlList(requestParam.TableName)))
        ElseIf requestParam.TableName = ComboBoxTableName.M_KEN_SIKUTYOUSON Then
            Return New ResponseGetComboBoxContentsElement("CODE", New String() {"CODE"}, SqlHelper.ExecuteDataset(connectionString, CommandType.Text, sqlList(requestParam.TableName)))
        ElseIf requestParam.TableName = ComboBoxTableName.M_KEN_TYOUIKI Then
            Return New ResponseGetComboBoxContentsElement("CODE", New String() {"CODE"}, SqlHelper.ExecuteDataset(connectionString, CommandType.Text, sqlList(requestParam.TableName)))
        End If

        If requestParam.TableName = ComboBoxTableName.T_SEIKYUHED_SEIKYUNO Then
            If (requestParam.ResultFieldType = GetComboBoxContentsResultFieldType.SingleField) Then
                Return New ResponseGetComboBoxContentsElement("請求Ｎｏ", New String() {"名称"}, SqlHelper.ExecuteDataset(connectionString, CommandType.Text, sqlList(requestParam.TableName)))
            Else
                Return New ResponseGetComboBoxContentsElement("請求Ｎｏ", New String() {"請求Ｎｏ", FieldName}, SqlHelper.ExecuteDataset(connectionString, CommandType.Text, sqlList(requestParam.TableName)))
            End If
        End If

        If (requestParam.ResultFieldType = GetComboBoxContentsResultFieldType.SingleField) Then
            Return New ResponseGetComboBoxContentsElement("名称", New String() {"名称"}, SqlHelper.ExecuteDataset(connectionString, CommandType.Text, sqlList(requestParam.TableName)))
        Else
            Return New ResponseGetComboBoxContentsElement("コード", New String() {"コード", FieldName}, SqlHelper.ExecuteDataset(connectionString, CommandType.Text, sqlList(requestParam.TableName)))
        End If

    End Function

End Class


