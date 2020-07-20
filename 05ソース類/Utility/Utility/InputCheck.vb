Imports System.Text.RegularExpressions

Public Class InputCheck

    ''' <summary>
    ''' 0から9までの文字のみで構成されているかどうかを調べます
    ''' </summary>
    ''' <param name="Value">入力値</param>
    ''' <returns>nullまたは 0から9までの文字のみで構成されている場合はtrue。それ以外の場合はfalse</returns>
    ''' <remarks></remarks>
    Public Shared Function DigitCheck(ByVal Value As String) As Boolean
        If Utility.NUCheck(Value) = True Then
            Return True
        End If

        Dim pattern As String

        pattern = "^[0-9]*$"

        Return RegularExpressionCheck(Value, pattern)


    End Function

    Public Shared Function PositiveIntegerCheck(ByVal Value As String) As Boolean
        If Utility.NUCheck(Value) = True Then
            Return True
        End If

        Dim pattern As String

        pattern = "^([1-9][0-9]*|0)$"

        Return RegularExpressionCheck(Value, pattern)

    End Function

    Public Shared Function SignedIntegerCheck(ByVal Value As String) As Boolean
        Return NumericCheck(Value)
        'If Utility.NUCheck(Value) = True Then
        '    Return True
        'End If

        'Dim pattern As String

        'pattern = "^(?:\+|\-)?(?:[1-9][0-9]*|0)$"

        'Return RegularExpressionCheck(Value, pattern)

    End Function

    Public Shared Function RealValueCheck(ByVal Value As String) As Boolean
        Dim work As Decimal
        If Utility.NUCheck(Value) = True Then
            Return True
        End If

        Return Decimal.TryParse(Value, work)

    End Function

    ''' <summary>
    ''' 数値チェック
    ''' </summary>
    ''' <param name="Value">入力値</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function NumericCheck(ByVal Value As String) As Boolean
        If Utility.NUCheck(Value) = True Then
            Return True
        End If

        Dim pattern As String

        pattern = "^\-?(?:([1-9][0-9]*)|0)$"

        Return RegularExpressionCheck(Value, pattern)

    End Function

    ''' <summary>
    ''' 数値チェック（カンマあり）
    ''' </summary>
    ''' <param name="Value">入力値</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function NumericCheck_Comma(ByVal Value As String) As Boolean
        If Utility.NUCheck(Value) = True Then
            Return True
        End If

        Dim pattern As String

        pattern = "^\-?(?:([1-9][0-9]{0,2}(?:\,[0-9]{3})*)|([1-9][0-9]*)|0)$"

        Return RegularExpressionCheck(Value, pattern)

    End Function

    ''' <summary>
    ''' 数値範囲チェック
    ''' </summary>
    ''' <param name="Value">入力値</param>
    ''' <param name="MaximumValue">最大値</param>
    ''' <param name="MinimumValue">最小値</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function NumericRangeCheck(ByVal Value As String, ByVal MaximumValue As String, ByVal MinimumValue As String) As Boolean
        If Utility.NUCheck(Value) = True Then
            Return True
        End If

        Dim val As Decimal, maxval As Decimal, minval As Decimal
        val = Decimal.Parse(Value)
        maxval = Decimal.Parse(MaximumValue)
        minval = Decimal.Parse(MinimumValue)

        Return (minval <= val And val <= maxval)
    End Function

    ''' <summary>
    ''' 正規表現パターンチェック
    ''' </summary>
    ''' <param name="Value">入力値</param>
    ''' <param name="Pattern">正規表現パターン</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function RegularExpressionCheck(ByVal Value As String, ByVal Pattern As String) As Boolean
        Return Regex.IsMatch(Value, Pattern)
    End Function

    ''' <summary>
    ''' 入力禁止文字が入っているかをチェックします。
    ''' </summary>
    ''' <param name="strMoji">検索対象文字列</param>
    ''' <returns>入力禁止文字が入っていない場合true。それ以外の場合はfalse</returns>
    ''' <remarks></remarks>
    Public Shared Function KinMojiCheck(ByVal strMoji As String) As Boolean
        If Utility.NUCheck(strMoji) = True Then
            Return True
        End If

        If InStr(strMoji, "'") > 0 Then Return False
        If InStr(strMoji, ",") > 0 Then Return False

        Return True
    End Function

    ''' <summary>
    ''' IsDateの代わり
    ''' </summary>
    ''' <param name="Value">日付</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function DateCheck(ByVal Value As String) As Boolean
        Dim dateResult As DateTime

        If Not (Date.TryParseExact(Value, New String() {"yyyy/M/d", "yyyy/MM/d", "yyyy/MM/dd", "yyyy/M/dd"}, New System.Globalization. _
        CultureInfo("ja-JP", True), Globalization.DateTimeStyles.None, dateResult)) Then
            Return False
        End If

        '日に"."が入力されているとIsDateメソッドが通るため(例:".1"や"1.")

        'If Not IsDate(dateResult) Then
        '    Return False
        'End If
        If Year(CType(dateResult, Date)) < 2000 OrElse Year(CType(dateResult, Date)) > 2099 Then
            Return False
        End If

        Return True
    End Function

    ''' <summary>
    ''' 入力禁止文字が入っているかをチェックします。(ディレクトリパス用)
    ''' </summary>
    ''' <param name="Value">検索対象文字列</param>
    ''' <returns>入力禁止文字が入っていない場合true。それ以外の場合はfalse</returns>
    ''' <remarks></remarks>
    Public Shared Function PathKinMojiCheck(ByVal Value As String) As Boolean
        Return Not RegularExpressionCheck(Value, "/+|\*+|\?+|\" + CChar("""") + "+|<+|>+|\|+")
    End Function

End Class
