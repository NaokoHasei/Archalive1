Imports System.Data.SqlClient
Imports CommonUtility.Utility
Imports BLL.Common

Public Class daBUK0002
    Inherits BLL.Common.DAL.DALBase

    Public Enum SearchKbnLatLng
        NONE = 0
        VALUE_EXIST = 1
        VALUE_NONE = 2
    End Enum

    Public Const CONST_SYONIN_KBN_NAME_SYONIN = "済"
    Public Const CONST_SYONIN_KBN_NAME_MI_SYONIN = "未"

    ''' <summary>
    ''' 明細データの取得
    ''' </summary>
    Public Function GetMeisai(
              ByVal form As frmBUK0002 _
            , ByVal SENCOL_ON As System.Drawing.Color _
            , ByVal PCNAME As String _
            , ByVal PROGRAM_ID As String _
            , ByVal searchKbnLatLng As SearchKbnLatLng
            ) As dsBUK0002.dbgMeisaiDataTable

        Dim logic As New ExecuteQuery
        Dim key As String
        Dim dic As New Dictionary(Of String, String)
        Dim strSQL As String = vbNullString

        '工事場所をスペース区切りのリストに変換
        Dim koujiBasyo As New List(Of String)

        If Not NUCheck(form.txtKoujiBasyo.Text) Then
            Dim koujiBasyo_tmp1 = form.txtKoujiBasyo.Text.Split(" ")
            Dim koujiBasyo_tmp2() As String

            For Each str1 As String In koujiBasyo_tmp1
                koujiBasyo_tmp2 = str1.Split("　")

                For Each str2 As String In koujiBasyo_tmp2
                    If Not NUCheck(str2) Then
                        koujiBasyo.Add(str2)
                    End If
                Next
            Next
        End If

        'メインのSQL
        strSQL += " select"
        strSQL += "     right('0000000000' + CONVERT(NVARCHAR, BUK.BUKKENNO), 10)   as BUKKENNO"
        strSQL += "   , BUK.BUKKENNAME"
        strSQL += "   , BUK.ADDRESS + BUK.ADDRESS1 + BUK.ADDRESS2                   as KOUJIBASYO"
        strSQL += "   , TOK.RYAKUNAME                                               as MOTOUKE"
        strSQL += "   , BUK.CHAKKOUDATE "
        strSQL += "   , BUK.KANKOUDATE"
        strSQL += "   , TAN.TANTONAME"
        strSQL += "   , KBN.KBNNAME                                                 as JYOTAI"
        strSQL += "   , BUK.SYONIN_JYUTYU"
        strSQL += "   , BUK.SYONIN_HATTYU"
        strSQL += "   , BUK.POSTNO"
        strSQL += "   , BUK.LAT"
        strSQL += "   , BUK.LNG"
        strSQL += " from ("
        strSQL += "   select"
        strSQL += "       BUK.*"
        '状態
        strSQL += "     , case"
        strSQL += "         when SEI.SEIKYUNO   is not null then '5'"
        strSQL += "         when HAT.HATYUNO    is not null then '4'"
        strSQL += "         when JYU.JYUTYUNO   is not null then '3'"
        strSQL += "         when MIT.MITUMORINO is not null then '2'"
        strSQL += "                                         else '1'"
        strSQL += "       end                                                       as JYOTAI_CODE"
        '受注承認
        strSQL += "     , case"
        strSQL += "         when APP_JYU.BUKKENNO is not null and  APP_JYU.APPROVALKBN = 2 then '" + CONST_SYONIN_KBN_NAME_SYONIN + "'"
        strSQL += "                                                                        else '" + CONST_SYONIN_KBN_NAME_MI_SYONIN + "'"
        strSQL += "       end                                                       as SYONIN_JYUTYU"
        '発注承認
        strSQL += "     , case"
        strSQL += "         when APP_HAT.BUKKENNO is null                                  then '" + CONST_SYONIN_KBN_NAME_SYONIN + "'"
        strSQL += "                                                                        else '" + CONST_SYONIN_KBN_NAME_MI_SYONIN + "'"
        strSQL += "       end                                                       as SYONIN_HATTYU"
        strSQL += "   from T_BUKKEN BUK"
        strSQL += "   left outer join (select distinct(MITUMORINO) from T_MITUMORIHED) MIT     on MIT.MITUMORINO   = BUK.BUKKENNO"
        strSQL += "   left outer join (select distinct(JYUTYUNO)   from T_JYUTYUHED  ) JYU     on JYU.JYUTYUNO     = BUK.BUKKENNO"
        strSQL += "   left outer join (select distinct(HATYUNO)    from T_HATYUHED   ) HAT     on HAT.HATYUNO      = BUK.BUKKENNO"
        strSQL += "   left outer join (select distinct(SEIKYUNO)   from T_SEIKYUHED  ) SEI     on SEI.SEIKYUNO     = BUK.BUKKENNO"
        strSQL += "   left outer join T_BUKKEN_APPROVAL APP_JYU"
        strSQL += "     on  APP_JYU.BUKKENNO = BUK.BUKKENNO"
        strSQL += "     and APP_JYU.GYOMUKBN = 2"
        strSQL += "     and APP_JYU.EDABAN   = 0"
        strSQL += "   left outer join ("
        strSQL += "     select BUKKENNO"
        strSQL += "     from T_BUKKEN_APPROVAL"
        strSQL += "     where GYOMUKBN    = 3"
        strSQL += "     and   APPROVALKBN = 1"
        strSQL += "     group by BUKKENNO"
        strSQL += "     ) APP_HAT"
        strSQL += "     on  APP_HAT.BUKKENNO = BUK.BUKKENNO"
        strSQL += "   where 1 = 1"

        '検索条件

        'パラメータの生成
        Dim param(dic.Count + 5) As SqlParameter
        Dim idx = 0

        If Not NUCheck(form.txtBukkenNo2.Text) Then
            '物件No
            strSQL += "    and   BUK.BUKKENNO = @BUKKENNO "

            'パラメータの生成
            ReDim param(0)
            param(0) = New SqlParameter("@BUKKENNO", CDec(form.txtBukkenNo2.Text))

        Else
            '物件名
            If Not NUCheck(form.txtBukkenName.Text) Then
                strSQL += "    and   BUK.BUKKENNAME like @BUKKENNAME"
            End If
            '工事場所
            Dim koujiBasyoWhere As String = ""
            For Each str As String In koujiBasyo
                key = "@ADDRESS_" + CommonUtility.Utility.ZeroPadding(idx, 5)

                If koujiBasyoWhere <> "" Then
                    koujiBasyoWhere += "    or    "
                End If
                koujiBasyoWhere += "BUK.ADDRESS + BUK.ADDRESS1 + BUK.ADDRESS2 like " + key

                dic.Add(key, "%" + str + "%")

                idx += 1
            Next
            If koujiBasyo.Count <> 0 Then
                strSQL += "    and   (" + koujiBasyoWhere + ")"
            End If
            '元請
            If form.cmdKMENU.ForeColor = SENCOL_ON Then
                strSQL += "    and   BUK.MOTOUKECODE in ("
                strSQL += "            select TOKUICODE"
                strSQL += "            from WT_SENTOK"
                strSQL += "            where PCNAME = '" & PCNAME & "'"
                strSQL += "            and   PGCODE = '" & PROGRAM_ID & "'"
                strSQL += "            and   FULINO =  0"
                strSQL += "            and   SENKBN =  1)"
            ElseIf Not NUCheck(form.cmbMotoukeCode.Text) Then
                strSQL += "    and   BUK.MOTOUKECODE = @MOTOUKECODE"
            End If
            '担当者
            If form.cmdTMENU.ForeColor = SENCOL_ON Then
                strSQL += "    and   BUK.TANTOCODE in ("
                strSQL += "            select TANTOCODE"
                strSQL += "            from WT_SENTAN"
                strSQL += "            where PCNAME = '" & PCNAME & "'"
                strSQL += "            and   PGCODE = '" & PROGRAM_ID & "'"
                strSQL += "            and   FULINO =  0"
                strSQL += "            and   SENKBN =  1)"
            ElseIf Not NUCheck(form.cmbTanatoCode.Text) Then
                strSQL += "    and   BUK.TANTOCODE = @TANTOCODE"
            End If
            '着工日
            If Not NUCheck(form.txtChakkouDateST.Text) Then
                strSQL += "    and   BUK.CHAKKOUDATE >= @CHAKKOUDATE_ST"
            End If
            If Not NUCheck(form.txtChakkouDateED.Text) Then
                strSQL += "    and   BUK.CHAKKOUDATE <= @CHAKKOUDATE_ED"
            End If
            '緯度・経度
            If searchKbnLatLng = SearchKbnLatLng.VALUE_EXIST Then
                strSQL += "    and   (BUK.LAT is not null and BUK.LAT <> '')"
                strSQL += "    and   (BUK.LNG is not null and BUK.LNG <> '')"
            ElseIf searchKbnLatLng = SearchKbnLatLng.VALUE_NONE Then
                strSQL += "    and   ( (BUK.LAT is null or BUK.LAT = '')"
                strSQL += "      or    (BUK.LNG is null or BUK.LNG = ''))"
            End If
        End If

        strSQL += "   ) BUK"
        strSQL += " left outer join M_TOKUI TOK"
        strSQL += "   on TOK.TOKUICODE = BUK.MOTOUKECODE"
        strSQL += " left outer join M_TANTO TAN"
        strSQL += "   on TAN.TANTOCODE = BUK.TANTOCODE"
        strSQL += " left outer join M_KBN KBN"
        strSQL += "   on  KBN.SIYOUKBN = 07"
        strSQL += "   and KBN.KBN      = BUK.JYOTAI_CODE"
        strSQL += " where 1 = 1"

        If NUCheck(form.txtBukkenNo2.Text) Then
            '状態
            If Not NUCheck(form.cmbJyotai.Text) Then
                strSQL += " and BUK.JYOTAI_CODE = @JYOTAI"
            End If
            '受注承認
            If form.rdoSyoninJyuMi.Checked Then
                strSQL += " and BUK.SYONIN_JYUTYU = '" + CONST_SYONIN_KBN_NAME_MI_SYONIN + "'"
            ElseIf form.rdoSyoninJyuSumi.Checked Then
                strSQL += " and BUK.SYONIN_JYUTYU = '" + CONST_SYONIN_KBN_NAME_SYONIN + "'"
            End If
            '発注承認
            If form.rdoSyoninHatMi.Checked Then
                strSQL += " and BUK.SYONIN_HATTYU = '" + CONST_SYONIN_KBN_NAME_MI_SYONIN + "'"
            ElseIf form.rdoSyoninHatSumi.Checked Then
                strSQL += " and BUK.SYONIN_HATTYU = '" + CONST_SYONIN_KBN_NAME_SYONIN + "'"
            End If

            'パラメータの生成
            ReDim param(dic.Count + 5)
            param(0) = New SqlParameter("@BUKKENNAME", "%" + form.txtBukkenName.Text + "%")
            param(1) = New SqlParameter("@MOTOUKECODE", form.cmbMotoukeCode.Text)
            param(2) = New SqlParameter("@TANTOCODE", form.cmbTanatoCode.Text)
            param(3) = New SqlParameter("@CHAKKOUDATE_ST", form.txtChakkouDateST.Text + "/01/01")
            param(4) = New SqlParameter("@CHAKKOUDATE_ED", form.txtChakkouDateED.Text + "/12/31")
            param(5) = New SqlParameter("@JYOTAI", form.cmbJyotai.Text)

            'パラメータの生成（工事場所）
            idx = 1
            For Each kvp As KeyValuePair(Of String, String) In dic
                param(idx + 5) = New SqlParameter(kvp.Key, kvp.Value)
                idx += 1
            Next
        End If
        strSQL += " order by"
        strSQL += "     BUK.CHAKKOUDATE desc"
        strSQL += "   , BUK.KANKOUDATE desc"
        strSQL += "   , BUK.BUKKENNO desc"

        'SQLの実行
        Dim ds = logic.ExecuteDataset(connectionString, CommandType.Text, strSQL, param)

        '取得するレコードの上限を設定
        Dim jyogen = 0
        If form.rdoList.Checked AndAlso Not NUCheck(form.S_SCB_SeachCountList) Then
            Integer.TryParse(form.S_SCB_SeachCountList, jyogen)
        ElseIf form.rdoMap.Checked AndAlso Not NUCheck(form.S_SCB_SeachCountMap) Then
            Integer.TryParse(form.S_SCB_SeachCountMap, jyogen)
        End If

        '返却データの生成
        Dim dt As New dsBUK0002.dbgMeisaiDataTable
        Dim dr As dsBUK0002.dbgMeisaiRow

        idx = 1
        For Each row As Data.DataRow In ds.Tables(0).Rows
            '上限を超えた場合、セットしない
            If jyogen <> 0 AndAlso jyogen < idx Then Exit For

            dr = dt.NewRow

            dr.SENTAKU = "選択"
            dr.SYONIN_JYUTYU = row.Item("SYONIN_JYUTYU")
            dr.SYONIN_HATTYU = row.Item("SYONIN_HATTYU")
            dr.JYOTAI = row.Item("JYOTAI")
            dr.BUKKENNAME = row.Item("BUKKENNAME")
            dr.KOUJIBASYO = NS(row.Item("KOUJIBASYO"))
            dr.MOTOUKE = NS(row.Item("MOTOUKE"))
            dr.CHAKKOUDATE = NS(row.Item("CHAKKOUDATE"))
            dr.KANKOUDATE = NS(row.Item("KANKOUDATE"))
            dr.TANTONAME = NS(row.Item("TANTONAME"))
            dr.BUKKENNO = NS(row.Item("BUKKENNO"))
            dr.POSTNO = NS(row.Item("POSTNO"))
            dr.LAT = NS(row.Item("LAT"))
            dr.LNG = NS(row.Item("LNG"))
            dr.RECODE_COUNT_JYOGEN = jyogen
            dr.RECODE_COUNT = ds.Tables(0).Rows.Count

            dt.Rows.Add(dr)

            idx += 1
        Next

        Return dt
    End Function

End Class
