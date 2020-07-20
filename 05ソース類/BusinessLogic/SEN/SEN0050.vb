Imports System.Data.SqlClient
Imports System.Data
Imports CommonUtility.Utility

Public Class SEN0050

    Enum 表示方法
        問屋_組合員
        問屋別
        組合員別
    End Enum

    Private connectionString As String

    ''' <summary>
    ''' クラス初期化    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        connectionString = CommonUtility.DBUtility.GetConnectionString
    End Sub

    Public Function GetList(ByVal SearchKeys As Model.DTO.RequestSEN0050GetList, ByVal 表示 As 表示方法) As Model.SEN0050List

        Dim strSQL As String = ""
        Dim strWhere As String

        Dim resultDataSet As New Model.SEN0050List

        strWhere = " where T_SIIRE.SIIREDATE between @SIIREDATEST and @SIIREDATEED"
        If Not NUCheck(SearchKeys.TONYACODE) Then
            strWhere += " and T_SIIRE.TONYACODE = @TONYACODE"
        End If
        If Not NUCheck(SearchKeys.KUMIAIINCODE) Then
            strWhere += " and T_SIIRE.KUMIAIINCODE = @KUMIAIINCODE"
        End If

        If 表示 = 表示方法.問屋_組合員 Then
            strSQL = "select "
            strSQL += " T_SIIRE.SIIREDATE"
            strSQL += ",T_SIIRE.KIJITUNAISIHARAIBI"
            strSQL += ",T_SIIRE.TONYACODE"
            strSQL += ",M_TONYA.TNY_MEI"
            strSQL += ",T_SIIRE.KUMIAIINCODE"
            strSQL += ",M_KUMIAIIN.KUM_MEI"
            strSQL += ",sum(T_SIIRE.SIIREGAKU) as SIIREGAKU"
            strSQL += " from " + fncGetT_SIIRE() + " left join M_TONYA    on T_SIIRE.TONYACODE    = M_TONYA.TONYACODE"
            strSQL += "              left join M_KUMIAIIN on T_SIIRE.KUMIAIINCODE = M_KUMIAIIN.KUMIAIINCODE"
            strSQL += strWhere
            strSQL += " group by T_SIIRE.SIIREDATE"
            strSQL += "         ,T_SIIRE.KIJITUNAISIHARAIBI"
            strSQL += "         ,T_SIIRE.TONYACODE"
            strSQL += "         ,M_TONYA.TNY_MEI"
            strSQL += "         ,T_SIIRE.KUMIAIINCODE"
            strSQL += "         ,M_KUMIAIIN.KUM_MEI"
            strSQL += " order by T_SIIRE.SIIREDATE"
            strSQL += "         ,T_SIIRE.KIJITUNAISIHARAIBI"
            strSQL += "         ,T_SIIRE.TONYACODE"
            strSQL += "         ,T_SIIRE.KUMIAIINCODE"

        ElseIf 表示 = 表示方法.問屋別 Then
            strSQL = "select "
            strSQL += " T_SIIRE.SIIREDATE"
            strSQL += ",T_SIIRE.KIJITUNAISIHARAIBI"
            strSQL += ",T_SIIRE.TONYACODE"
            strSQL += ",M_TONYA.TNY_MEI"
            strSQL += ",'' as KUMIAIINCODE"
            strSQL += ",'' as KUM_MEI"
            strSQL += ",sum(T_SIIRE.SIIREGAKU) as SIIREGAKU"
            strSQL += " from " + fncGetT_SIIRE() + " left join M_TONYA    on T_SIIRE.TONYACODE    = M_TONYA.TONYACODE"
            strSQL += strWhere
            strSQL += " group by T_SIIRE.SIIREDATE"
            strSQL += "         ,T_SIIRE.KIJITUNAISIHARAIBI"
            strSQL += "         ,T_SIIRE.TONYACODE"
            strSQL += "         ,M_TONYA.TNY_MEI"
            strSQL += " order by T_SIIRE.SIIREDATE"
            strSQL += "         ,T_SIIRE.KIJITUNAISIHARAIBI"
            strSQL += "         ,T_SIIRE.TONYACODE"

        ElseIf 表示 = 表示方法.組合員別 Then
            strSQL = "select "
            strSQL += " T_SIIRE.SIIREDATE"
            strSQL += ",T_SIIRE.KIJITUNAISIHARAIBI"
            strSQL += ",'' as TONYACODE"
            strSQL += ",'' as TNY_MEI"
            strSQL += ",T_SIIRE.KUMIAIINCODE"
            strSQL += ",M_KUMIAIIN.KUM_MEI"
            strSQL += ",sum(T_SIIRE.SIIREGAKU) as SIIREGAKU"
            strSQL += " from " + fncGetT_SIIRE() + " left join M_KUMIAIIN on T_SIIRE.KUMIAIINCODE = M_KUMIAIIN.KUMIAIINCODE"
            strSQL += strWhere
            strSQL += " group by T_SIIRE.SIIREDATE"
            strSQL += "         ,T_SIIRE.KIJITUNAISIHARAIBI"
            strSQL += "         ,T_SIIRE.KUMIAIINCODE"
            strSQL += "         ,M_KUMIAIIN.KUM_MEI"
            strSQL += " order by T_SIIRE.SIIREDATE"
            strSQL += "         ,T_SIIRE.KIJITUNAISIHARAIBI"
            strSQL += "         ,T_SIIRE.KUMIAIINCODE"
        Else
            MsgBox("引数不正")
        End If

        Dim op As New System.Transactions.TransactionOptions
        op.IsolationLevel = Transactions.IsolationLevel.ReadUncommitted

        Using ts As System.Transactions.TransactionScope = New System.Transactions.TransactionScope(Transactions.TransactionScopeOption.Required, op)

            Dim logic As New BLL.Common.ExecuteQuery
            logic.FillDataset(connectionString, Data.CommandType.Text, strSQL, resultDataSet, New String() {"DataList"}, _
                                                                                              New SqlParameter() {New SqlParameter("@SIIREDATEST", SearchKeys.SIIREDATE(0)), _
                                                                                                                  New SqlParameter("@SIIREDATEED", SearchKeys.SIIREDATE(1)), _
                                                                                                                  New SqlParameter("@TONYACODE", SearchKeys.TONYACODE), _
                                                                                                                  New SqlParameter("@KUMIAIINCODE", SearchKeys.KUMIAIINCODE)})
            ts.Complete()

        End Using

        Return resultDataSet

    End Function

    Private Function fncGetT_SIIRE() As String

        Dim strSQL As String

        strSQL = "(select"
        strSQL += " case DATAKBN when 0 then T_SIIRE.SIIREDATE else T_SIIRE.CYOSEIBI end SIIREDATE"
        strSQL += ",T_SIIRE.KIJITUNAISIHARAIBI"
        strSQL += ",T_SIIRE.TONYACODE"
        strSQL += ",T_SIIRE.KUMIAIINCODE"
        strSQL += ",case DATAKBN when 0 then T_SIIRE.SIIREGAKU else T_SIIRE.SIIREGAKU * (-1) end SIIREGAKU"
        strSQL += " from T_SIIRE"
        strSQL += ") T_SIIRE"

        Return strSQL

    End Function

End Class
