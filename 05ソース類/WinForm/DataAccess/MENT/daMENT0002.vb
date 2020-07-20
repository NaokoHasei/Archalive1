Imports System.Data.SqlClient
Imports CommonUtility.Utility
Imports BLL.Common

Public Class daMENT0002
    Inherits BLL.Common.DAL.DALBase

    ''' <summary>
    ''' 明細データの取得
    ''' </summary>
    Public Function GetMeisai(
              ByVal kamokuType As frmMENT0002.enumKamokuType _
            , ByVal code As String _
            , ByVal codeJyoui As String _
            , ByVal kamokuHinmoku As String
            ) As dsMENT0002.M_KAMOKUDataTable

        Dim logic As New ExecuteQuery
        Dim strSQL As String = vbNullString

        strSQL += " select"
        strSQL += "     KAMOKU_TYPE"
        strSQL += "   , KAMOKU"
        strSQL += "   , CODE"
        strSQL += "   , isnull(NAME, '')            as NAME"
        strSQL += "   , isnull(NAME2, '')           as NAME2"
        strSQL += "   , isnull(TANI, '')            as TANI"
        strSQL += "   , isnull(GENTANKA, '')        as GENTANKA"
        strSQL += "   , isnull(MIT_JYU_TANAKA, '')  as MIT_JYU_TANAKA"
        strSQL += "   , isnull(JYOUI_CODE, '')      as JYOUI_CODE"
        strSQL += "   , isnull(JYOUI_NAME, '')      as JYOUI_NAME"
        strSQL += " from ("
        strSQL += "   select"
        strSQL += "        " + CStr(frmMENT0002.enumKamokuType.DKAMOKU) + " as KAMOKU_TYPE"
        strSQL += "     , '" + CStr(frmMENT0002.CONST_DKAMOKU) + "'     as KAMOKU"
        strSQL += "     , DAI.DAIKAMOKUCODE                             as CODE"
        strSQL += "     , DAI.DAIKAMOKUNAME                             as NAME"
        strSQL += "     , DAI.DAIKAMOKUNAME2                            as NAME2"
        strSQL += "     , DAI.TANI                                      as TANI"
        strSQL += "     , DAI.GENTANKA                                  as GENTANKA"
        strSQL += "     , DAI.MIT_JYU_TANAKA                            as MIT_JYU_TANAKA"
        strSQL += "     , ''                                            as JYOUI_CODE"
        strSQL += "     , ''                                            as JYOUI_NAME"
        strSQL += "   from M_DAIKAMOKU            as DAI"
        strSQL += "   union"
        strSQL += "   select"
        strSQL += "        " + CStr(frmMENT0002.enumKamokuType.CKAMOKU) + " as KAMOKU_TYPE"
        strSQL += "     , '" + CStr(frmMENT0002.CONST_CKAMOKU) + "'     as KAMOKU"
        strSQL += "     , CYU.CYUKAMOKUCODE                             as CODE"
        strSQL += "     , CYU.CYUKAMOKUNAME                             as NAME"
        strSQL += "     , CYU.CYUKAMOKUNAME2                            as NAME2"
        strSQL += "     , CYU.TANI                                      as TANI"
        strSQL += "     , CYU.GENTANKA                                  as GENTANKA"
        strSQL += "     , CYU.MIT_JYU_TANAKA                            as MIT_JYU_TANAKA"
        strSQL += "     , CYU.DAIKAMOKUCODE                             as JYOUI_CODE"
        strSQL += "     , DAI.DAIKAMOKUNAME                             as JYOUI_NAME"
        strSQL += "   from M_CYUKAMOKU            as CYU"
        strSQL += "   left outer join M_DAIKAMOKU as DAI"
        strSQL += "     on DAI.DAIKAMOKUCODE = CYU.DAIKAMOKUCODE"
        strSQL += "   union"
        strSQL += "   select"
        strSQL += "        " + CStr(frmMENT0002.enumKamokuType.SKAMOKU) + " as KAMOKU_TYPE"
        strSQL += "     , '" + CStr(frmMENT0002.CONST_SKAMOKU) + "'     as KAMOKU"
        strSQL += "     , SYO.SYOKAMOKUCODE                             as CODE"
        strSQL += "     , SYO.SYOKAMOKUNAME                             as NAME"
        strSQL += "     , SYO.SYOKAMOKUNAME2                            as NAME2"
        strSQL += "     , SYO.TANI                                      as TANI"
        strSQL += "     , SYO.GENTANKA                                  as GENTANKA"
        strSQL += "     , SYO.MIT_JYU_TANAKA                            as MIT_JYU_TANAKA"
        strSQL += "     , SYO.CYUKAMOKUCODE                             as JYOUI_CODE"
        strSQL += "     , CYU.CYUKAMOKUNAME                             as JYOUI_NAME"
        strSQL += "   from M_SYOKAMOKU            as SYO"
        strSQL += "   left outer join M_CYUKAMOKU as CYU"
        strSQL += "     on CYU.CYUKAMOKUCODE = SYO.CYUKAMOKUCODE"
        strSQL += "   ) SUB"
        strSQL += " where 1 = 1"
        '科目の検索
        If kamokuType <> frmMENT0002.enumKamokuType.SEARCH Then
            strSQL += " and KAMOKU_TYPE = " + CStr(kamokuType)
        End If
        'コードの検索
        If Not NUCheck(code) Then
            strSQL += " and CODE        = @CODE"
        End If
        '上位コードの検索
        If Not NUCheck(codeJyoui) Then
            strSQL += " and JYOUI_CODE  = @JYOUI_CODE"
        End If
        '科目・品目の検索
        If Not NUCheck(kamokuHinmoku) Then
            strSQL += " and NAME        like @NAME"
        End If
        strSQL += " order by KAMOKU_TYPE, CODE"

        Dim param() = New SqlParameter() {
            New SqlParameter("@CODE", code),
            New SqlParameter("@JYOUI_CODE", codeJyoui),
            New SqlParameter("@NAME", "%" + kamokuHinmoku + "%")
            }

        'SQLの実行
        Dim ds = logic.ExecuteDataset(connectionString, CommandType.Text, strSQL, param)

        '返却データの生成
        Dim dt As New dsMENT0002.M_KAMOKUDataTable
        Dim dr As dsMENT0002.M_KAMOKURow

        For Each row As Data.DataRow In ds.Tables(0).Rows
            dr = dt.NewRow

            dr.KAMOKU_TYPE = row.Item("KAMOKU_TYPE")
            dr.KAMOKU = row.Item("KAMOKU")
            dr.CODE = row.Item("CODE")
            dr.NAME = row.Item("NAME")
            dr.NAME2 = row.Item("NAME2")
            dr.TANI = row.Item("TANI")
            dr.GENTANKA = row.Item("GENTANKA")
            dr.MIT_JYU_TANAKA = row.Item("MIT_JYU_TANAKA")
            dr.JYOUI_CODE = row.Item("JYOUI_CODE")
            dr.JYOUI_NAME = row.Item("JYOUI_NAME")

            dt.Rows.Add(dr)
        Next

        Return dt
    End Function

    Public Sub DeleteKAMOKU(ByVal kamoku As frmMENT0002.enumKamokuType, ByVal strCODE As String)
        Dim logic As New ExecuteQuery
        Dim strSQL As String

        Select Case kamoku
            Case frmMENT0002.enumKamokuType.DKAMOKU
                strSQL = "delete from M_DAIKAMOKU where DAIKAMOKUCODE=@KAMOKUCODE"
            Case frmMENT0002.enumKamokuType.CKAMOKU
                strSQL = "delete from M_CYUKAMOKU where CYUKAMOKUCODE=@KAMOKUCODE"
            Case Else
                strSQL = "delete from M_SYOKAMOKU where SYOKAMOKUCODE=@KAMOKUCODE"
        End Select

        logic.ExecuteNonQuery(connectionString, CommandType.Text, strSQL, New SqlClient.SqlParameter() {New SqlClient.SqlParameter("@KAMOKUCODE", strCODE)})
    End Sub

    Public Sub UpdateM_KAMOKU(
              ByVal kamoku As frmMENT0002.enumKamokuType _
            , ByVal strCODE As String _
            , ByVal strNAME As String _
            , ByVal strNAME2 As String _
            , ByVal strTANI As String _
            , ByVal strGENTANKA As String _
            , ByVal strMIT_JYU_TANAKA As String _
            , ByVal strCODE_JYOUI As String _
            , ByVal strPGID As String _
            , ByVal strUSER As String)

        Dim logic As New BLL.Common.ExecuteQuery
        Dim strSQL As String = vbNullString
        Dim decGENTANKA As Decimal
        Dim decMIT_JYU_TANAKA As Decimal

        If Decimal.TryParse(strGENTANKA, decGENTANKA) = False Then decGENTANKA = 0
        If Decimal.TryParse(strMIT_JYU_TANAKA, decMIT_JYU_TANAKA) = False Then decMIT_JYU_TANAKA = 0

        If GetMeisai(kamoku, strCODE, "", "").Count = 0 Then
            '新規登録
            Select Case kamoku
                Case frmMENT0002.enumKamokuType.DKAMOKU
                    strSQL += "insert into M_DAIKAMOKU (DAIKAMOKUCODE,DAIKAMOKUNAME,DAIKAMOKUNAME2,TANI,GENTANKA,MIT_JYU_TANAKA,UPDATEPGID,UPDATEUSERCODE) values "

                Case frmMENT0002.enumKamokuType.CKAMOKU
                    strSQL += "insert into M_CYUKAMOKU (CYUKAMOKUCODE,CYUKAMOKUNAME,CYUKAMOKUNAME2,TANI,GENTANKA,MIT_JYU_TANAKA,DAIKAMOKUCODE,UPDATEPGID,UPDATEUSERCODE) values "

                Case frmMENT0002.enumKamokuType.SKAMOKU
                    strSQL += "insert into M_SYOKAMOKU (SYOKAMOKUCODE,SYOKAMOKUNAME,SYOKAMOKUNAME2,TANI,GENTANKA,MIT_JYU_TANAKA,CYUKAMOKUCODE,UPDATEPGID,UPDATEUSERCODE) values "
            End Select

            strSQL += "('" & strCODE & "','" & strNAME & "','" & strNAME2 & "','" & strTANI & "'," & CStr(decGENTANKA) & "," & CStr(decMIT_JYU_TANAKA)

            If kamoku <> frmMENT0002.enumKamokuType.DKAMOKU Then
                strSQL += ",'" & strCODE_JYOUI + "'"
            End If

            strSQL += ",'" & strPGID & "','" & strUSER & "')"

        Else
            '更新
            Select Case kamoku
                Case frmMENT0002.enumKamokuType.DKAMOKU
                    strSQL += "update M_DAIKAMOKU set "
                    strSQL += "DAIKAMOKUNAME = '" & strNAME & "',"
                    strSQL += "DAIKAMOKUNAME2 = '" & strNAME2 & "',"
                    strSQL += "TANI = '" & strTANI & "',"
                    strSQL += "GENTANKA = " & CStr(decGENTANKA) & ","
                    strSQL += "MIT_JYU_TANAKA = " & CStr(decMIT_JYU_TANAKA) & ","
                    strSQL += "UPDATEPGID = '" & strPGID & "',"
                    strSQL += "UPDATEUSERCODE = '" & strUSER & "' "
                    strSQL += "where DAIKAMOKUCODE = '" & strCODE & "'"

                Case frmMENT0002.enumKamokuType.CKAMOKU
                    strSQL += "update M_CYUKAMOKU set "
                    strSQL += "CYUKAMOKUNAME = '" & strNAME & "',"
                    strSQL += "CYUKAMOKUNAME2 = '" & strNAME2 & "',"
                    strSQL += "TANI = '" & strTANI & "',"
                    strSQL += "GENTANKA = " & CStr(decGENTANKA) & ","
                    strSQL += "MIT_JYU_TANAKA = " & CStr(decMIT_JYU_TANAKA) & ","
                    strSQL += "DAIKAMOKUCODE = '" & strCODE_JYOUI & "',"
                    strSQL += "UPDATEPGID = '" & strPGID & "',"
                    strSQL += "UPDATEUSERCODE = '" & strUSER & "' "
                    strSQL += "where CYUKAMOKUCODE = '" & strCODE & "'"

                Case frmMENT0002.enumKamokuType.SKAMOKU
                    strSQL = "update M_SYOKAMOKU set "
                    strSQL += "SYOKAMOKUNAME = '" & strNAME & "',"
                    strSQL += "SYOKAMOKUNAME2 = '" & strNAME2 & "',"
                    strSQL += "TANI = '" & strTANI & "',"
                    strSQL += "GENTANKA = " & CStr(decGENTANKA) & ","
                    strSQL += "MIT_JYU_TANAKA = " & CStr(decMIT_JYU_TANAKA) & ","
                    strSQL += "CYUKAMOKUCODE = '" & strCODE_JYOUI & "',"
                    strSQL += "UPDATEPGID = '" & strPGID & "',"
                    strSQL += "UPDATEUSERCODE = '" & strUSER & "' "
                    strSQL += "where SYOKAMOKUCODE = '" & strCODE & "'"
            End Select
        End If

        logic.ExecuteNonQuery(connectionString, CommandType.Text, strSQL)
    End Sub
End Class
