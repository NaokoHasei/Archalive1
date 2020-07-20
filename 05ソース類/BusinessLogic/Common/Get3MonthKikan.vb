Public Class Get3MonthKikan

    ''' <summary>
    ''' 基本情報マスタ．最終３ヶ月処理日より今回３ヶ月処理開始日と今回３ヶ月処理終了日を求める
    ''' </summary>
    ''' <param name="DateSt"></param>
    ''' <param name="DateEd"></param>
    ''' <remarks></remarks>
    Public Shared Sub GetKikan(ByRef DateSt As Date, ByRef DateEd As Date)

        Dim kihon As New BLL.Common.Kihoninfo

        Dim dtmSt As Date = kihon.Record.FIN_UPD_3RD.AddDays(1)
        Dim dtmEd As Date = dtmSt.AddMonths(3).AddDays(-1)

        DateSt = dtmSt
        DateEd = dtmEd

    End Sub

End Class
