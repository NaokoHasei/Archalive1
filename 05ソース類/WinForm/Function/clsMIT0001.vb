Imports CommonUtility.Utility

Public Class clsMIT0001

    '与えられたDataTableより一番下の階層レコードを取得して返す
    Public Shared Function GetLastKaiso(ByVal dt As DataTable) As String

        If dt.Rows.Count = 0 Then Return ""

        Dim dv As DataView = dt.DefaultView

        dv.Sort = "KAISOCODE"

        Dim ret As String = ""

        Try
            ret = dv.Table.Rows(dv.Table.Rows.Count - 1)("KAISOCODE").ToString
        Catch ex As Exception
            ret = "001"
        End Try

        Return ret

    End Function

    Public Enum enumDigit As Integer
        Zero = 0
        One = 1
        Two = 2
        Three = 3
    End Enum
    Public Enum enumDivide As Integer
        Floor = 0
        Round = 1
        Ceiling = 2
    End Enum
    Public Shared Function CnvToDecimalPoint(ByVal obj As String, ByVal syosu As String, ByVal roundValue As String) As Decimal
        Dim dec As Decimal = 0

        'グローバル変数を直接参照する(内部より)
        Select Case roundValue
            Case "0", "1", "2"
            Case Else
                'ありえないが、０１２以外の場合は強制的に0とする
                roundValue = "0"
        End Select
        Select Case syosu
            Case "0", "1", "2", "3"
            Case Else
                syosu = "0"
        End Select

        If Decimal.TryParse(obj, dec) = False Then Return 0

        Return Round(dec, CType(CDec(syosu), clsMIT0001.enumDigit), CType(CDec(roundValue), clsMIT0001.enumDivide))

    End Function
End Class
