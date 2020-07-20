Imports System.Xml

Public Class Utility

    Private Shared MIN_DATEValue As String
    Private Shared MAX_DATEValue As String

    Public Shared Function MIN_DATE() As String
        If MIN_DATEValue Is Nothing Then
            Return "1900/01/01"
        Else
            'Return MIN_DATEValue
            Return "1900/01/01"
        End If
    End Function

    Public Shared Function MAX_DATE() As String
        If MAX_DATEValue Is Nothing Then
            Return "2099/12/31"
        Else
            'Return MAX_DATEValue
            Return "2099/12/31"
        End If
    End Function

    '個別指定ボタン 表示色
    Private Const SENCOL_ON As Integer = &HFF0000&

    ''' <summary>
    ''' 個別選択のボタンのテキストの色を取得します。
    ''' </summary>
    ''' <param name="isUsing">個別選択中の場合はTrue。それ以外の場合はFalseを指定します。</param>
    ''' <returns>ボタンに設定する色</returns>
    ''' <remarks></remarks>
    Public Shared Function GetSentakuButtonColor(ByVal isUsing As Boolean) As System.Drawing.Color
        If isUsing = True Then
            Return System.Drawing.Color.FromArgb(SENCOL_ON)
        Else
            Return System.Drawing.SystemColors.ControlText 'System.Drawing.Color.Black
        End If

    End Function
    Public Shared Function SpacePadding(ByVal str As String, ByVal length As Integer) As String
        Return ZeroPadding(str, length, " "c)
    End Function

    Public Shared Function ZeroPadding(ByVal code As String, ByVal length As Integer) As String
        Return ZeroPadding(code, length, "0"c)
    End Function

    Public Shared Function ZeroPadding(ByVal code As String, ByVal length As Integer, ByVal padChar As Char) As String
        Return Microsoft.VisualBasic.Right(New String(padChar, length) & code, length)
    End Function

    Public Shared Function NUCheck(ByVal value As Object) As Boolean
        'Nothing判定
        If IsDBNull(value) = True Then
            Return True
        End If
        'Nothing判定
        If IsNothing(value) = True Then
            Return True
        End If
        '空文字判定
        If TypeOf (value) Is String Then
            If String.IsNullOrEmpty(CType(value, String)) Then
                Return True
            End If
        End If
        Return False
    End Function

    Public Shared Function NS(ByVal value As Object) As String
        'Nothing判定
        If IsDBNull(value) = True Then
            Return ""
        End If
        'Nothing判定
        If IsNothing(value) = True Then
            Return ""
        End If
        '空文字判定
        If TypeOf (value) Is String Then
            If String.IsNullOrEmpty(CType(value, String)) Then
                Return ""
            End If
        End If
        Return CType(value, String)
    End Function

    Public Shared Function NZ(ByVal value As Object) As Decimal
        'Nothing判定
        If IsDBNull(value) = True Then
            Return CDec(0)
        End If
        'Nothing判定
        If IsNothing(value) = True Then
            Return CDec(0)
        End If
        '空文字判定
        If TypeOf (value) Is String Then
            If String.IsNullOrEmpty(CType(value, String)) Then
                Return CDec(0)
            End If
        End If

        Return CDec(value)
    End Function

    Public Shared Function DC(ByVal value As Object) As Object
        'Nothing判定
        If IsDBNull(value) = True Then
            Return Nothing
        End If
        'Nothing判定
        If IsNothing(value) = True Then
            Return Nothing
        End If
        '日付判定
        If IsDate(value) = False Then
            Return Nothing
        End If

        Return CDate(value)
    End Function

    Public Shared Function GetAppSettings(ByVal key As String) As String
        Dim str As String = System.Configuration.ConfigurationManager.AppSettings(key)
        Return str
    End Function

    Public Shared Function GetMachineName() As String
        Return Environment.MachineName
    End Function

    '実行ディレクトリパスを返す
    Public Shared Function GetAppPath() As String
        Return System.IO.Path.GetDirectoryName( _
               System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)
    End Function

    'ZeroFormat val = 1~9 Prerequisite  .NetVer
    Public Shared Function ZeroFormat(ByVal val As String, ByVal Length As Integer) As String
        If NS(val) = "" Then
            Return ""
        End If
        If InputCheck.DigitCheck(val) = False Then
            Return val
        End If
        val = String.Format("{0}", val)
        val = Int32.Parse(val).ToString(New String(CType("0", Char), Length))
        Return val
    End Function

    '右から指定のバイト数分返す
    Public Shared Function RightBSA(ByVal str As String, ByVal length As Integer) As String
        Dim i As Integer = length
        Dim j As Integer = LenBSA(str)
        If i > j Then i = CType(j, Short)
        Dim hEncoding As System.Text.Encoding = System.Text.Encoding.GetEncoding(932)
        Dim btBytes As Byte() = hEncoding.GetBytes(str)
        Return hEncoding.GetString(btBytes, btBytes.Length - i, i)
    End Function


    ''' <summary>
    ''' 文字列のバイト数を取得する
    ''' </summary>
    ''' <param name="str">対象文字列</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function LenBSA(ByVal str As String) As Integer
        Dim l As Integer = System.Text.Encoding.GetEncoding(932).GetBytes(str).Length
        Return l
    End Function

    ''' <summary>
    ''' 文字列SJISで指定文字数分取得する
    ''' </summary>
    ''' <param name="str">対象文字列</param>
    ''' <param name="length">バイト数</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function LeftBSA(ByVal str As String, ByVal length As Integer) As String
        Dim l As Integer = LenBSA(str)
        If l > length Then
            l = length
        End If
        Dim buf() As Byte = System.Text.Encoding.GetEncoding(932).GetBytes(str)
        Dim s As String = System.Text.Encoding.GetEncoding(932).GetChars(buf, 0, l)
        If LenBSA(s) > length Then
            Return Left(s, s.Length - 1)
        Else
            Return s
        End If

    End Function

    Public Shared Function GetConfigValue(ByVal file As String, ByVal key As String) As String

        Dim Doc As System.Xml.XmlDocument = New System.Xml.XmlDocument()
        Dim Node As System.Xml.XmlNode

        Doc.Load(file)
        Node = Doc.DocumentElement

        'VBLOG_DIRがない場合規定値セット
        Node = findAttributeKeyValue(Node.SelectSingleNode("//appSettings/add"), "key", "ConnectionString")

        If Node Is Nothing Then
            'error
        Else
            Dim s As String = Doc.DocumentElement.GetElementsByTagName("ConnectionString").Item(0).Name
        End If

        Dim strReturn As String = ""
        Dim reader As System.Xml.XmlReader = System.Xml.XmlReader.Create(file)

        While reader.Read
            If reader.NodeType = Xml.XmlNodeType.Element And reader.LocalName = key Then
                strReturn = reader.ReadString()
                Exit While
            End If
        End While

        reader.Close()

        Return strReturn

    End Function

    Public Shared Function findAttributeKeyValue(ByVal node As System.Xml.XmlNode, ByVal attributeName As String, ByVal attributeValue As String) As System.Xml.XmlNode
        Dim find As Boolean = False
        Dim n As System.Xml.XmlNode = node
        While n IsNot Nothing
            If n.Attributes(attributeName).Value = attributeValue Then
                Return n
            End If
            n = n.NextSibling
        End While

        Return Nothing
    End Function

    ''' <summary>
    ''' 数値丸め処理
    ''' </summary>
    ''' <param name="decIN">丸める数値</param>
    ''' <param name="intKETA">少数以下桁数+1を指定　1の場合整数に丸め。2の場合少数2位で丸め。</param>
    ''' <param name="intKBN"> 0:切捨て 1:四捨五入 2:切上げ</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Round(ByVal decIN As Decimal, ByVal intKETA As Integer, ByVal intKBN As Integer) As Decimal

        Dim decPlus As Decimal
        Dim decWrk As Decimal
        Dim intWrkKETA As Integer
        Select Case intKBN
            Case 0  '切り捨て
                decPlus = 0
            Case 1  '四捨五入
                decPlus = 0.5@
            Case 2  '切り上げ
                decPlus = 0.9999999@   '通貨型は有効数字小数第４位まで
        End Select
        intWrkKETA = intKETA
        decWrk = CType(decIN * (10 ^ intWrkKETA), Decimal)
        decWrk = decWrk + Math.Sign(decWrk) * decPlus
        decWrk = Fix(decWrk)
        Round = CType(decWrk / (10 ^ intWrkKETA), Decimal)
    End Function

    ''' <summary>
    ''' DataViewのRowFilterプロパティに指定する文字列内の特殊文字(%等)をエスケープします。
    ''' エスケープ対象はlike句に指定するワイルドカードのみです。
    ''' </summary>
    ''' <param name="str">フィルタ文字列</param>
    ''' <returns>エスケープされたフィルタ文字列</returns>
    ''' <remarks></remarks>
    Public Shared Function EscapeLikeExpressionDS(ByVal str As String) As String
        Dim strWork As String = StrConv(str, VbStrConv.Wide)
        Return strWork
    End Function

    ''' <summary>
    ''' SQLのlike句に指定する文字列内の特殊文字(%等)をエスケープします。
    ''' </summary>
    ''' <param name="str">フィルタ文字列</param>
    ''' <returns>エスケープされたフィルタ文字列</returns>
    ''' <remarks></remarks>
    Public Shared Function EscapeLikeExpressionSQL(ByVal str As String) As String
        Dim strWork As String = StrConv(str, VbStrConv.Wide)
        Return strWork
    End Function

    Public Shared Function GetCorrectPath(ByVal strValue As String) As String
        Do Until Utility.RightBSA(strValue, 1) <> "\"
            strValue = Utility.LeftBSA(strValue, Len(strValue) - 1)
        Loop
        Return strValue
    End Function

    ''' <summary>
    ''' 年齢取得（生年月日から現在までの経過年数の計算）
    ''' </summary>
    ''' <param name="strBirthDate"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetAge(ByVal strBirthDate As String) As String
        Dim varAge As String
        Dim dt As DateTime

        '与えられた生年月日がDate型に変換できない場合、Nullを返す
        If DateTime.TryParse(strBirthDate, dt) = False Then Return vbNullString

        '初期化
        GetAge = ""

        If CommonUtility.Utility.NUCheck(strBirthDate) = True Then Exit Function

        '0010が2010と判断されるため
        If strBirthDate.Substring(0, 2) = "00" Then Exit Function

        varAge = DateDiff(DateInterval.Year, CDate(strBirthDate), Now).ToString
        If Now < DateSerial(Year(Now), Month(CDate(strBirthDate)), CDate(strBirthDate).Day) Then
            varAge = (CInt(varAge) - 1).ToString
        End If

        '戻値
        GetAge = varAge

    End Function

    ''' <summary>
    ''' 電話番号変換
    ''' </summary>
    ''' <param name="strValue"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function TelNo_cnv(ByVal strValue As String) As String

        '--変数--
        Dim strTelNo As String       '戻り値
        Dim intTelNo As Integer      'カウンタ

        '戻り値
        TelNo_cnv = strValue

        '初期化
        strTelNo = vbNullString

        '電話番号は数値以外を除く("-","(",")" etc)
        For intTelNo = 1 To Len(strValue)
            If IsNumeric(Mid(strValue, intTelNo, 1)) Then
                strTelNo = strTelNo & Mid(strValue, intTelNo, 1)
            End If
        Next

        TelNo_cnv = strTelNo

    End Function

    ''' <summary>
    ''' テーブル更新用文字列置き換え
    ''' </summary>
    ''' <param name="strValue"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function TblValue(ByVal strValue As String) As String

        If NS(strValue) = vbNullString Then
            TblValue = vbNullString
            Exit Function
        End If

        'ｼﾝｸﾞﾙｺｰﾃｰｼｮﾝを２つに。
        TblValue = Replace(strValue.ToString, "'", "''")

        Exit Function

    End Function

    ''' <summary>
    ''' 郵便番号、郵便番号以下の住所よりカスタマバーコードのコードを生成
    ''' </summary>
    ''' <param name="postalCode"></param>
    ''' <param name="address"></param>
    ''' <param name="representation"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CreateCustomerBarcode(ByVal postalCode As String, ByVal address As String, ByVal representation As Boolean) As String
        Dim addrACode As String
        Dim addrBCode As String

        '郵便番号部分
        addrACode = ConvertPostalCode(postalCode)

        '郵便番号で表現される住所より後の住所
        If (Not representation) And (address.Length > 0) Then
            addrBCode = ConvertAddress(address)
        Else
            '代表番号の場合、コードは郵便番号のみ
            addrBCode = ""
        End If

        '連結
        CreateCustomerBarcode = addrACode & addrBCode
        Exit Function
    End Function

    Private Shared Function ConvertPostalCode(ByVal postalCode As String) As String
        'ハイフンを取り除く
        ConvertPostalCode = Replace(postalCode, "-", "")
    End Function

    Private Shared Function ConvertAddress(ByVal address As String) As String
        '2バイト文字を1バイトに変換
        ConvertAddress = StrConv(address, vbNarrow)

        'アルファベットの小文字を大文字に変換
        ConvertAddress = UCase(ConvertAddress)

        '指定文字列（アンパサンド等）を取り除いてつめる
        ConvertAddress = System.Text.RegularExpressions.Regex.Replace(ConvertAddress, "[&/･・\.]", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase)

        '漢数字のうち、有効な数字として扱うものを変換
        ConvertAddress = ReplaceKansuji(ConvertAddress)

        '英数字とハイフンを抽出
        ConvertAddress = SelectAlphabetAndNumber(ConvertAddress)

        '一文字だけの'F'をハイフンに変換
        ConvertAddress = System.Text.RegularExpressions.Regex.Replace(ConvertAddress, "[F]{1,1}", "-", System.Text.RegularExpressions.RegexOptions.IgnoreCase)

        '連続するアルファベットをハイフンに置換
        ConvertAddress = System.Text.RegularExpressions.Regex.Replace(ConvertAddress, "[A-Z]{2,}", "-", System.Text.RegularExpressions.RegexOptions.IgnoreCase)

        '連続するハイフンをひとつのハイフンにまとめる
        ConvertAddress = System.Text.RegularExpressions.Regex.Replace(ConvertAddress, "[\-]{2,}", "-", System.Text.RegularExpressions.RegexOptions.IgnoreCase)

        'アルファベットの前後のハイフンを削除
        ConvertAddress = RemoveHyphenBesideAlphabet(ConvertAddress)

        'コードの先頭と末尾にあるハイフンを削除
        If NUCheck(ConvertAddress) = False AndAlso ConvertAddress.Substring(0, 1) = "-" Then
            ConvertAddress = Mid(ConvertAddress, 2, ConvertAddress.Length - 1)
        End If

        If NUCheck(ConvertAddress) = False AndAlso ConvertAddress.Substring(ConvertAddress.Length - 1, 1) = "-" Then
            ConvertAddress = Mid(ConvertAddress, 1, ConvertAddress.Length - 1)
        End If
    End Function

    Private Shared Function RemoveHyphenBesideAlphabet(ByVal str As String) As String
        Dim matches As System.Text.RegularExpressions.MatchCollection
        Dim mtch As System.Text.RegularExpressions.Match

        'パターンマッチング： 前後にハイフンのあるアルファベット
        matches = System.Text.RegularExpressions.Regex.Matches(str, "(\-{1,1}[A-Z]\-{1,1})|(\-{1,1}[A-Z])|([A-Z]\-{1,1})")
        For Each mtch In matches
            '前後のハイフンを取り除く
            str = Replace(str, mtch.Value, Replace(mtch.Value, "-", ""))
        Next mtch

        RemoveHyphenBesideAlphabet = str
    End Function

    Private Shared Function SelectAlphabetAndNumber(ByVal str As String) As String
        Dim matches As System.Text.RegularExpressions.MatchCollection
        Dim alphNum As System.Text.RegularExpressions.Match

        '何も入らないままだとエラー（警告）が出るので、空白を入れておく
        SelectAlphabetAndNumber = ""

        'パターンマッチング： 英数字かハイフン
        matches = System.Text.RegularExpressions.Regex.Matches(str, "[A-Z0-9]{1,}|\-")
        For Each alphNum In matches
            'マッチした文字列をハイフンで区切りながら連結
            SelectAlphabetAndNumber = SelectAlphabetAndNumber & alphNum.Value & "-"
        Next alphNum
        If SelectAlphabetAndNumber.Length > 0 Then
            '最後のハイフンを取り除く
            SelectAlphabetAndNumber = Mid(SelectAlphabetAndNumber, 1, SelectAlphabetAndNumber.Length - 1)
        End If
    End Function

    Private Shared Function ReplaceKansuji(ByVal address As String) As String
        Dim matches As System.Text.RegularExpressions.MatchCollection
        Dim kansuji As System.Text.RegularExpressions.Match

        'パターンマッチング： 9種の特殊文字の前にある漢数字
        matches = System.Text.RegularExpressions.Regex.Matches(address, "[〇一二三四五六七八九十百千万億兆]{1,}[丁目|丁|番地|番|号|地割|線|の|ノ]")
        For Each kansuji In matches
            'マッチした文字列を、アラビア数字とハイフンに変換した文字列で置換
            address = Replace(address, kansuji.Value, ConvertKansuji(CStr(kansuji.Value)))
        Next kansuji

        ReplaceKansuji = address
    End Function

    Private Shared Function ConvertKansuji(ByVal kansuji As String) As String
        Dim matches As System.Text.RegularExpressions.MatchCollection
        Dim mtch As System.Text.RegularExpressions.Match
        Dim strKansuji As String

        Dim srcChar As String
        Dim i As Integer
        Dim aNum As Integer
        Dim buf As String = ""
        Dim bufNum As Decimal

        Dim total As Decimal
        Dim subTotal As Decimal

        total = 0@
        subTotal = 0@

        matches = System.Text.RegularExpressions.Regex.Matches(kansuji, "[〇一二三四五六七八九十百千万億兆]*")
        If matches.Count <> 0 Then
            mtch = matches(0)
            strKansuji = mtch.Value
            For i = 1 To Len(strKansuji)
                srcChar = Mid(strKansuji, i, 1)
                aNum = KansujiToArabic(srcChar)
                If aNum <> -1 Then
                    buf = buf & aNum.ToString
                    bufNum = CDec(buf)
                Else
                    Select Case srcChar
                        Case "兆"
                            total = total + (subTotal + bufNum) * 1000000000000@

                        Case "億"
                            total = total + (subTotal + bufNum) * 100000000@

                        Case "万"
                            total = total + (subTotal + bufNum) * 10000@

                        Case "千"
                            subTotal = subTotal + CDec(IIf(bufNum = 0, 1, bufNum)) * 1000@

                        Case "百"
                            subTotal = subTotal + CDec(IIf(bufNum = 0, 1, bufNum)) * 100@

                        Case "十"
                            subTotal = subTotal + CDec(IIf(bufNum = 0, 1, bufNum)) * 10@

                    End Select

                    buf = ""
                    bufNum = 0@
                End If
            Next i
        Else
        End If

        If bufNum <> 0 Then
            total = total + bufNum
        End If
        If subTotal <> 0 Then
            total = total + subTotal
        End If
        ConvertKansuji = CStr(total) & "-"
    End Function

    Private Shared Function KansujiToArabic(ByVal kansuji As String) As Integer
        If kansuji = "〇" Then
            KansujiToArabic = 0
        ElseIf kansuji = "一" Then
            KansujiToArabic = 1
        ElseIf kansuji = "二" Then
            KansujiToArabic = 2
        ElseIf kansuji = "三" Then
            KansujiToArabic = 3
        ElseIf kansuji = "四" Then
            KansujiToArabic = 4
        ElseIf kansuji = "五" Then
            KansujiToArabic = 5
        ElseIf kansuji = "六" Then
            KansujiToArabic = 6
        ElseIf kansuji = "七" Then
            KansujiToArabic = 7
        ElseIf kansuji = "八" Then
            KansujiToArabic = 8
        ElseIf kansuji = "九" Then
            KansujiToArabic = 9
        Else
            KansujiToArabic = -1
        End If
    End Function

    Public Sub New(ByVal MinDate As String, ByVal MaxDate As String)
        MIN_DATEValue = MinDate
        MAX_DATEValue = MaxDate
    End Sub

    '
    ' 機　能：文字列を区切り文字で区切る
    '
    ' 戻り値：分割数
    '
    ' 引　数：strSource   文字列
    ' 　　　　strSepa     区切文字
    ' 　　　　strResult() 結果格納配列(動的)
    ' 　　　　intResult   格納数
    '
    Public Shared Function pfncApart(ByVal strSource As String, _
                                     ByVal strSepa As String, _
                                     ByRef strResult() As String, _
                                     ByRef intResult As Integer) As Integer

        '*** 変数宣言 ***
        Dim strSrc As String       '検索される文字列
        Dim intSepa As Integer      '区切文字の位置
        Dim strWork As String       '区切られた項目

        '*** 戻り値 ***
        pfncApart = 0

        '*** 初期チェック ***
        If strSource = vbNullString Then Exit Function

        '*** 初期化 ***
        ReDim strResult(0)
        strSrc = strSource
        intResult = 0

        '*** 文字検索 ***
        intSepa = InStr(1, strSrc, strSepa)
        Do While intSepa > 0
            strWork = Trim(Left(strSrc, intSepa - 1))
            '*** 前後ﾀﾞﾌﾞﾙｺｰﾃｰｼｮﾝを除く ***
            If Left(strWork, 1) = Chr(34) Then strWork = Mid(strWork, 2)
            If Right(strWork, 1) = Chr(34) Then strWork = Left(strWork, Len(strWork) - 1)
            '*** 戻り値格納 ***
            ReDim Preserve strResult(intResult)
            strResult(intResult) = strWork
            intResult = intResult + 1
            strSrc = Mid(strSrc, intSepa + Len(strSepa))
            '*** 文字検索 ***
            intSepa = InStr(1, strSrc, strSepa)
        Loop
        strWork = Trim(strSrc)
        '*** 前後ﾀﾞﾌﾞﾙｺｰﾃｰｼｮﾝを除く ***
        If Left(strWork, 1) = Chr(34) Then strWork = Mid(strWork, 2)
        If Right(strWork, 1) = Chr(34) Then strWork = Left(strWork, Len(strWork) - 1)
        '*** 戻り値格納 ***
        ReDim Preserve strResult(intResult)
        strResult(intResult) = strWork

        '*** 戻り値 ***
        pfncApart = intResult + 1

    End Function

    ''' <summary>
    ''' 郵便番号として正しい文字列か調べる
    ''' </summary>
    ''' <param name="strPostNo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function PostNoCheck(ByVal strPostNo As String) As Boolean

        If NUCheck(strPostNo) = True Then Return True

        '000-0000（数字3文字‐数字4文字）の形であればTrue
        If System.Text.RegularExpressions.Regex.IsMatch(strPostNo, "^\d\d\d-\d\d\d\d$", System.Text.RegularExpressions.RegexOptions.ECMAScript) Then Return True
        '数字7文字であればTrue
        If System.Text.RegularExpressions.Regex.IsMatch(strPostNo, "^\d\d\d\d\d\d\d$", System.Text.RegularExpressions.RegexOptions.ECMAScript) Then Return True

        Return False

    End Function

    ''' <summary>
    ''' 電話番号として正しい文字列か調べる
    ''' </summary>
    ''' <param name="strTelNo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function TelNoCheck(ByVal strTelNo As String) As Boolean

        If NUCheck(strTelNo) = True Then Return True

        '半角数字のみであればTrue
        If System.Text.RegularExpressions.Regex.IsMatch(strTelNo, "^[0-9]+$", System.Text.RegularExpressions.RegexOptions.ECMAScript) Then Return True
        '電話番号のパターンとして正しければTrue
        If System.Text.RegularExpressions.Regex.IsMatch(strTelNo, "^0\d{1,5}-\d{1,4}-\d{4}$", System.Text.RegularExpressions.RegexOptions.ECMAScript) Then Return True
        If System.Text.RegularExpressions.Regex.IsMatch(strTelNo, "^0\d{4}-\d{3}-\d{3}$", System.Text.RegularExpressions.RegexOptions.ECMAScript) Then Return True

        Return False

    End Function

    ''' <summary>
    ''' ディレクトリ作成
    ''' </summary>
    ''' <param name="strFileName"></param>
    ''' <remarks></remarks>
    Public Shared Sub pMakeDirectory(ByVal strFileName As String)

        '変数宣言
        Dim intWrk As Integer      'ワーク
        Dim strWrk As String       'ワーク

        'ファイル名編集
        If strFileName.Substring(strFileName.Length - 4).Substring(0, 1) = "." Then
            'ファイル名
        Else
            'フォルダ名
            If strFileName.Substring(strFileName.Length - 1) <> "\" Then
                strFileName = strFileName & "\"
            End If
        End If

        '初期値
        intWrk = 3   '(strFileName = "C:\XXX\XXX\XXX")

        Do
            '「\」検索
            intWrk = InStr(intWrk + 1, strFileName, "\")
            If intWrk = 0 Then Exit Do

            'フォルダ名取得
            strWrk = strFileName.Substring(0, intWrk)

            If System.IO.Directory.Exists(strWrk) = False Then
                'フォルダ作成
                System.IO.Directory.CreateDirectory(strWrk)
            End If

        Loop

    End Sub

    ''' <summary>
    ''' 数字のみを返す
    ''' </summary>
    ''' <param name="strAny"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function pfncNumericOnly(ByVal strAny As String) As String

        '--- 変数宣言 ---
        Dim strWork As String       'ワーク
        Dim intCnt As Integer      'カウンタ

        '--- 初期値 ---
        pfncNumericOnly = vbNullString

        '--- 数字チェック ---
        For intCnt = 1 To Len(strAny)
            strWork = Mid(strAny, intCnt, 1)
            If (strWork >= "0") And (strWork <= "9") Then
                pfncNumericOnly = pfncNumericOnly & strWork
            End If
        Next intCnt

    End Function

    ''' <summary>
    ''' バイト数の主塔
    ''' </summary>
    Public Shared Function LenB(ByVal stTarget As String) As Integer
        Return Text.Encoding.GetEncoding("Shift_JIS").GetByteCount(stTarget)
    End Function

End Class
