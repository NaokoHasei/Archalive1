Imports System.Data.SqlClient
Imports CommonUtility.Utility
Imports BLL.Common

Public Class daBUK0003
    Inherits BLL.Common.DAL.DALBase

    ''' <summary>
    ''' 明細データの取得
    ''' </summary>
    Public Function GetMeisai(ByVal form As frmBUK0003) As dsBUK0003.dbgMeisaiDataTable

        Dim logic As New ExecuteQuery
        Dim idx As Integer = 0
        Dim dic As New Dictionary(Of String, String)
        Dim strSQL As String = vbNullString

        'SQLの生成

        '物件トランの取得
        strSQL += " with BUK as ("
        strSQL += " select"
        '検索結果の上限
        If NUCheck(form.S_SCB_SeachCount) Then
            strSQL += "     top " + form.S_SCB_SeachCount
        End If
        strSQL += "     * "
        strSQL += " from T_BUKKEN"
        '抽出条件
        strSQL += " where 1 = 1"
        '物件名
        If Not NUCheck(form.txtBukkenName.Text) Then
            strSQL += " And   BUKKENNAME like @BUKKENNAME"
        End If
        '着工日
        If Not NUCheck(form.txtChakkouDateST.Text) AndAlso form.txtChakkouDateST.Text <> "    /  /" Then
            strSQL += " And   CHAKKOUDATE >= @CHAKKOUDATE_ST"
        End If
        If Not NUCheck(form.txtChakkouDateED.Text) AndAlso form.txtChakkouDateED.Text <> "    /  /" Then
            strSQL += " And   CHAKKOUDATE <= @CHAKKOUDATE_ED"
        End If
        '完工日
        If Not NUCheck(form.txtKankouDateST.Text) AndAlso form.txtKankouDateST.Text <> "    /  /" Then
            strSQL += " And   KANKOUDATE >= @KANKOUDATE_ST"
        End If
        If Not NUCheck(form.txtKankouDateED.Text) AndAlso form.txtKankouDateED.Text <> "    /  /" Then
            strSQL += " And   KANKOUDATE <= @KANKOUDATE_ED"
        End If
        '検索結果の上限がある場合ソート順を指定
        If NUCheck(form.S_SCB_SeachCount) Then
            strSQL += " order by"
        strSQL += "     CHAKKOUDATE desc"
        strSQL += "   , KANKOUDATE desc"
            strSQL += "   , BUKKENNO desc"
        End If
        strSQL += " ) "
        '仕入先マスタの取得
        strSQL += " , SIIRE as ("
        strSQL += "   select"
        strSQL += "       SUB.HATYUNO"
        strSQL += "     , SUB.NUM"
        strSQL += "     , SII.RYAKUNAME"
        strSQL += "   from ("
        strSQL += "     select"
        strSQL += "         HAT.HATYUNO"
        strSQL += "       , HAT.SIIRECODE"
        strSQL += "       , row_number() over(partition by HAT.HATYUNO order by HAT.GKGENKAGAKU_NUKI desc) NUM"
        strSQL += "     from BUK"
        strSQL += "     inner join T_HATYUHED HAT"
        strSQL += "       on  HAT.HATYUNO = BUK.BUKKENNO"
        strSQL += "     ) SUB"
        strSQL += "   inner join M_SIIRE SII"
        strSQL += "     on SII.SIIRECODE = SUB.SIIRECODE"
        strSQL += " )"
        'メインのSQL
        strSQL += " select"
        strSQL += "     right('0000000000' + CONVERT(NVARCHAR, BUK.BUKKENNO), 10)                               as BUKKENNO"
        strSQL += "   , BUK.BUKKENNAME"
        strSQL += "   , BUK.KOUSHU"
        strSQL += "   , BUK.ADDRESS1"
        strSQL += "   , TOK.RYAKUNAME                                                                           as MOTOUKENAME"
        strSQL += "   , isnull(SII_1.RYAKUNAME, '') "
        strSQL += "      + case when SII_2.RYAKUNAME is not null then '／' else '' end"
        strSQL += "      + isnull(SII_2.RYAKUNAME, '')                                                          as SHITAUKEGYOSHA"
        strSQL += "   , JYU.GKJYUTYUGAKU_NUKI"
        strSQL += "   , HAT.GKGENKAGAKU_NUKI"
        strSQL += "   , JYU.GKJYUTYUGAKU_NUKI - HAT.GKGENKAGAKU_NUKI                                            as ARARI_GAKU"
        strSQL += "   , case when JYU.GKJYUTYUGAKU_NUKI = 0 then 0 "
        strSQL += "                                         else Round((JYU.GKJYUTYUGAKU_NUKI - HAT.GKGENKAGAKU_NUKI) / JYU.GKJYUTYUGAKU_NUKI * 100, 2)"
        strSQL += "       end                                                                                   as ARARI_RITU"
        strSQL += "   , BUK.CHAKKOUDATE"
        strSQL += "   , BUK.KANKOUDATE"
        strSQL += " from BUK"
        strSQL += " left outer join ("
        strSQL += "   select JYUTYUNO, GKJYUTYUGAKU_NUKI"
        strSQL += "   from T_JYUTYUHED JYU"
        strSQL += "   where JYUTYUEDABAN = ("
        strSQL += "     select max(SUB.JYUTYUEDABAN)"
        strSQL += "     from T_JYUTYUHED SUB"
        strSQL += "     where SUB.JYUTYUNO = JYU.JYUTYUNO"
        strSQL += "     )"
        strSQL += "   ) JYU"
        strSQL += "   on JYU.JYUTYUNO = BUK.BUKKENNO"
        strSQL += " left outer join (select HATYUNO , sum(GKGENKAGAKU_NUKI)  as GKGENKAGAKU_NUKI  from T_HATYUHED  group by HATYUNO ) HAT"
        strSQL += "   on HAT.HATYUNO = BUK.BUKKENNO"
        strSQL += " left outer join M_TOKUI TOK"
        strSQL += "   on  TOK.TOKUICODE  = BUK.MOTOUKECODE"
        '仕入マスタの略称（１つ目）の取得
        strSQL += " left outer join SIIRE   SII_1"
        strSQL += "   on  SII_1.HATYUNO = BUK.BUKKENNO"
        strSQL += "   and SII_1.NUM     = 1"
        '仕入マスタの略称（２つ目）の取得
        strSQL += " left outer join SIIRE   SII_2"
        strSQL += "   on  SII_2.HATYUNO = BUK.BUKKENNO"
        strSQL += "   and SII_2.NUM     = 2"
        strSQL += " order by"
        strSQL += "     BUK.CHAKKOUDATE desc"
        strSQL += "   , BUK.KANKOUDATE desc"
        strSQL += "   , BUK.BUKKENNO desc"

        'パラメータの生成
        Dim param() As SqlParameter = {
            New SqlParameter("@BUKKENNAME", "%" + form.txtBukkenName.Text + "%"),
            New SqlParameter("@CHAKKOUDATE_ST", form.txtChakkouDateST.Text),
            New SqlParameter("@CHAKKOUDATE_ED", form.txtChakkouDateED.Text),
            New SqlParameter("@KANKOUDATE_ST", form.txtKankouDateST.Text),
            New SqlParameter("@KANKOUDATE_ED", form.txtKankouDateED.Text)
        }

        'SQLの実行
        Dim ds = logic.ExecuteDataset(connectionString, CommandType.Text, strSQL, param)

        '取得するレコードの上限を設定
        Dim jyogen = 0
        If Not NUCheck(form.S_SCB_SeachCount) Then
            Integer.TryParse(form.S_SCB_SeachCount, jyogen)
        End If

        '返却データの生成
        Dim dt As New dsBUK0003.dbgMeisaiDataTable
        Dim dr As dsBUK0003.dbgMeisaiRow

        idx = 1
        For Each row As Data.DataRow In ds.Tables(0).Rows
            '上限を超えた場合、セットしない
            If jyogen <> 0 AndAlso jyogen < idx Then Exit For

            dr = dt.NewRow

            dr.SENTAKU = "選択"
            dr.BUKKENNO = row.Item("BUKKENNO")
            dr.BUKKENNAME = row.Item("BUKKENNAME")
            dr.KOUSHU = row.Item("KOUSHU")
            dr.ADDRESS = row.Item("ADDRESS1")
            dr.MOTOUKENAME = NS(row.Item("MOTOUKENAME"))
            dr.SHITAUKEGYOSHA = NS(row.Item("SHITAUKEGYOSHA"))
            dr.JYUCHUKINGAKU = NS(row.Item("GKJYUTYUGAKU_NUKI"))
            dr.SHIHARAIGENKA = NS(row.Item("GKGENKAGAKU_NUKI"))
            dr.ARARIGAKU = NS(row.Item("ARARI_GAKU"))
            dr.ARARIRITU = NS(row.Item("ARARI_RITU"))
            If Not NUCheck(dr.ARARIRITU) Then
                dr.ARARIRITU = CDec(dr.ARARIRITU).ToString("0.00") + "%"
            End If
            dr.CHAKKOUDATE = NS(row.Item("CHAKKOUDATE"))
            dr.KANKOUDATE = NS(row.Item("KANKOUDATE"))
            dr.RECODE_COUNT = ds.Tables(0).Rows.Count

            dt.Rows.Add(dr)

            idx += 1
        Next

        Return dt
    End Function

End Class
