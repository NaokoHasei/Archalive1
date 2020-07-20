Public Class GetKisyuKimatubi

    Public Function GetKisyuKimatubi(ByVal dtmTaisyouDate As Date, ByRef dtmKisyubi As Date, ByRef dtmKimatubi As Date) As Boolean

        Dim intMstKisyu As Integer
        Dim strYear As String
        Dim strMon As String

        GetKisyuKimatubi = False

        '基本情報マスタ.期首月取得
        Dim ds As New BLL.Common.Kihoninfo
        intMstKisyu = CType(ds.Item.S_KIHONINFOView(0).KISYU_MONTH, Integer)

        '*** 期首年月日の取得 ***
        If (intMstKisyu <= CType(Month(dtmTaisyouDate), Short)) Then
            'マスタの期首月 <= 対象月  --> 対象年の期首年月日
            strYear = CType(Year(dtmTaisyouDate), String)
        Else
            '対象年前年の期首年月日
            strYear = CType(Year(DateAdd(DateInterval.Year, -1, dtmTaisyouDate)), String)
        End If
        strMon = Format(intMstKisyu, "00")
        dtmKisyubi = CDate(strYear & "/" & strMon & "/01")

        '*** 期末年月日の取得(期首年月日より+1年-1日) ***
        dtmKimatubi = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Year, 1, dtmKisyubi))

        GetKisyuKimatubi = True

    End Function

End Class
