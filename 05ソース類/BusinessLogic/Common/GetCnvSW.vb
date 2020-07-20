Public Class GetCnvSW

    ''' <summary>
    ''' 西暦年を和暦年に変換します    ''' </summary>
    ''' <param name="val">YYYY/MM/DD形式で与える｛X.Tostring("yyyy/MM/dd")｝</param>
    ''' <returns>元号+和暦年.Tostring()例外など正常以外は全て空文字を返す</returns>
    ''' <remarks></remarks>
    Public Shared Function SfncYearSW(ByVal val As String, Optional ByVal ZeroPadding As Boolean = False, Optional ByVal YearOnly As Boolean = False) As String
        Dim day As Date
        Dim SelectRow As BLL.Common.dsM_GENGO.M_GENGORow = Nothing

        If Not DateTime.TryParse(val, day) Then Return ""

        '元号のデータを取得します
        SelectRow = GetGengoData(day)

        If SelectRow Is Nothing Then
            Return ""
        End If

        Dim dName = SelectRow.GENGONAME
        Dim dSNen = (Int32.Parse(day.ToString("yyyy")) - Int32.Parse(SelectRow.KAISISEIREKI.ToString("yyyy"))) + 1
        If ZeroPadding = False Then
            If YearOnly Then
                Return dName + dSNen.ToString + "年"
            Else
                Return dName + dSNen.ToString + "年" + Int32.Parse(day.ToString("MM")).ToString + "月" + Int32.Parse(day.ToString("dd")).ToString + "日"
            End If
        Else
            If YearOnly Then
                Return dName + dSNen.ToString.PadLeft(2, "0"c) + "年"
            Else
                Return dName + dSNen.ToString.PadLeft(2, "0"c) + "年" + day.ToString("MM") + "月" + day.ToString("dd") + "日"
            End If
        End If
    End Function

    ''' <summary>
    ''' 元号を取得します    ''' </summary>
    ''' <param name="val">YYYY/MM/DD形式で与える｛X.Tostring("yyyy/MM/dd")｝</param>
    Public Shared Function GetGengo(ByVal val As String) As String
        Dim day As Date

        If Not DateTime.TryParse(val, day) Then Return ""

        Return GetGengoData(day).GENGONAME
    End Function

    ''' <summary>
    ''' 元号のデータを取得します    ''' </summary>
    ''' <param name="val">YYYY/MM/DD形式で与える｛X.Tostring("yyyy/MM/dd")｝</param>
    Private Shared Function GetGengoData(ByVal day As Date) As dsM_GENGO.M_GENGORow
        Dim SelectRow As BLL.Common.dsM_GENGO.M_GENGORow = Nothing
        Static ResultDataSet As BLL.Common.dsM_GENGO

        If ResultDataSet Is Nothing Then
            ResultDataSet = New BLL.Common.dsM_GENGO

            Using adp As New dsM_GENGOTableAdapters.M_GENGOTableAdapter,
                connection As New System.Data.SqlClient.SqlConnection(CommonUtility.DBUtility.GetConnectionString)
                adp.Connection = connection : CommonUtility.DBUtility.SetCommandTimeout(adp)
                adp.Fill(ResultDataSet.M_GENGO)
            End Using
        End If

        For Each r As BLL.Common.dsM_GENGO.M_GENGORow In ResultDataSet.M_GENGO
            If r.KAISISEIREKI <= CType(day.ToString("yyyy/MM/dd"), Date) Then
                SelectRow = r
                Exit For
            End If
        Next

        Return SelectRow
    End Function

End Class
