Imports System.Data.SqlClient
Imports System.Data
Imports CommonUtility

Public Class SEARCH_TOKUI

    Private connectionString As String = String.Empty

    ''' <summary>
    ''' クラス初期化

    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        connectionString = CommonUtility.DBUtility.GetConnectionString
    End Sub

    Public Function GetTOKUIData(ByVal where As String) As DataTable

        Dim logic As New BLL.Common.ExecuteQuery
        Dim ds As New Data.DataSet
        Dim strSQL As String = ""

        strSQL = "select TOKUICODE as ｺｰﾄﾞ, MENUKEY as ﾒﾆｭｰｷｰ, TOKUINAME as 名称 "
        strSQL = strSQL & " from M_TOKUI "
        strSQL = strSQL & where

        ds = logic.ExecuteDataset(connectionString, Data.CommandType.Text, strSQL)

        Return ds.Tables(0)

    End Function

    Public Function fncMakeSQL(ByVal intNODE As Integer, ByVal intKANA As Integer, ByVal strKANA As String, ByVal strINPUTWORD As String) As DataTable
        Dim strSQL As String
        Dim strOrder As String
        Dim logic As New BLL.Common.ExecuteQuery
        Dim ds As New Data.DataSet

        strSQL = "select "
        strSQL = strSQL & "  TOKUICODE AS ｺｰﾄﾞ"
        strSQL = strSQL & ", Isnull(MENUKEY,'') AS ﾒﾆｭｰｷｰ"
        strSQL = strSQL & ", Isnull(TOKUINAME,'') AS 名称"

        strSQL = strSQL & " from ( SELECT"
        strSQL = strSQL & "        TOKUICODE"
        strSQL = strSQL & "       ,Isnull(MENUKEY,'') as MENUKEY "
        strSQL = strSQL & "       ,Isnull(TOKUINAME,'') as TOKUINAME "
        strSQL = strSQL & "        FROM M_TOKUI ) A "
        strSQL = strSQL & "where (1=1) "
        Select Case intNODE
            Case 0
                Select Case intKANA
                    Case 0
                        strSQL = strSQL & "AND (MENUKEY >= 'ｱ') and (MENUKEY < 'ｶ') "
                    Case 1
                        strSQL = strSQL & "AND (MENUKEY >= 'ｶ') and (MENUKEY < 'ｻ') "
                    Case 2
                        strSQL = strSQL & "AND (MENUKEY >= 'ｻ') and (MENUKEY < 'ﾀ') "
                    Case 3
                        strSQL = strSQL & "AND (MENUKEY >= 'ﾀ') and (MENUKEY < 'ﾅ') "
                    Case 4
                        strSQL = strSQL & "AND (MENUKEY >= 'ﾅ') and (MENUKEY < 'ﾊ') "
                    Case 5
                        strSQL = strSQL & "AND (MENUKEY >= 'ﾊ') and (MENUKEY < 'ﾏ') "
                    Case 6
                        strSQL = strSQL & "AND (MENUKEY >= 'ﾏ') and (MENUKEY < 'ﾔ') "
                    Case 7
                        strSQL = strSQL & "AND (MENUKEY >= 'ﾔ') and (MENUKEY < 'ﾗ') "
                    Case 8
                        strSQL = strSQL & "AND (MENUKEY >= 'ﾗ') and (MENUKEY < 'ﾜ') "
                    Case 9
                        strSQL = strSQL & "AND (MENUKEY >= 'ﾜ') and (MENUKEY < 'ﾝ') "
                    Case 10
                        strSQL = strSQL & "AND ((MENUKEY < 'ｱ') or (MENUKEY >= 'ﾝ')) "
                End Select
            Case 1
                strSQL = strSQL & "AND (MENUKEY like '" & strKANA & "%') "
        End Select
        '*** 手入力あり ***
        If strINPUTWORD <> "" Then
            strSQL = strSQL & "AND ((TOKUINAME like '%" & strINPUTWORD & "%') OR (MENUKEY like '%" & strINPUTWORD & "%'))"
        End If

        '表示順
        strOrder = "ORDER BY MENUKEY, TOKUICODE "

        ds = logic.ExecuteDataset(connectionString, Data.CommandType.Text, strSQL)

        Return ds.Tables(0)

    End Function

End Class