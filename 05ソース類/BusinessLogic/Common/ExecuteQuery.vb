Imports Microsoft.ApplicationBlocks.Data
Imports System.Data.SqlClient
Imports System.Data

Public Class ExecuteQuery

    Private log As OperationLog.OutPutLog
    Private SQL_LOG_LEVEL As Integer

    Public Sub New()

        Dim dsSystem As DataSet

        Dim pcname As String = Environment.MachineName
        Dim pgid As String = System.Diagnostics.Process.GetCurrentProcess().ProcessName
        Dim usercode As String = ""

        'M_NOWUSERよりユーザー取得
        dsSystem = GetDbValue.Execute("M_NOWUSER", "TANTOCODE", "PCNAME='" + pcname + "'")
        If dsSystem.Tables(0).Rows.Count > 0 Then usercode = dsSystem.Tables(0).Rows(0)(0).ToString

        'ログ出力のデフォルトはカレントディレクトリにする
        Dim strPath As String = System.IO.Directory.GetCurrentDirectory()
        If strPath.EndsWith("\") = False Then strPath += "\Log\"

        'ログフォルダの作成
        If Not System.IO.Directory.Exists(strPath) Then
            System.IO.Directory.CreateDirectory(strPath)
        End If

        Dim intDelDay As Integer = 180
        SQL_LOG_LEVEL = 2

        log = New OperationLog.OutPutLog(strPath, intDelDay, pcname, usercode, pgid)

    End Sub

    Public Shared Function CreateParameter(ByVal ParameterName As String, ByVal SqlDbType As System.Data.SqlDbType, ByVal Size As Integer, ByVal Direction As System.Data.ParameterDirection, ByVal value As Object) As SqlParameter
        Dim p As New SqlParameter
        With p
            .ParameterName = ParameterName
            .SqlDbType = SqlDbType
            .Size = Size
            .Direction = Direction
            .Value = value
        End With
        Return p
    End Function

    Public Shared Function CreateParameter(ByVal ParameterName As String, ByVal SqlDbType As System.Data.SqlDbType, ByVal Size As Integer, ByVal Direction As System.Data.ParameterDirection) As SqlParameter
        Dim p As New SqlParameter
        With p
            .ParameterName = ParameterName
            .SqlDbType = SqlDbType
            .Size = Size
            .Direction = Direction
        End With
        Return p
    End Function

    Public Overloads Function ExecuteDataset(ByVal connectionString As String,
                                             ByVal commandType As CommandType,
                                             ByVal commandText As String) As DataSet
        If SQL_LOG_LEVEL > 1 Then log.Write("0", BuildQuery.Replace(commandText), OperationLog.OutPutLog.LogKind.Info)
        Return SqlHelper.ExecuteDataset(connectionString, commandType, commandText)
    End Function

    Public Overloads Function ExecuteDataset(ByVal connectionString As String,
                                             ByVal commandType As CommandType,
                                             ByVal commandText As String,
                                             ByVal ParamArray commandParameters() As SqlParameter) As DataSet
        If SQL_LOG_LEVEL > 1 Then log.Write("0", BuildQuery.Replace(commandText, commandParameters), OperationLog.OutPutLog.LogKind.Info)
        Return SqlHelper.ExecuteDataset(connectionString, commandType, commandText, commandParameters)
    End Function

    Public Overloads Function ExecuteNonQuery(ByVal connectionString As String, _
                                              ByVal commandType As CommandType, _
                                              ByVal commandText As String, _
                                              ByVal ParamArray commandParameters() As SqlParameter) As Integer
        Using ts As System.Transactions.TransactionScope = New System.Transactions.TransactionScope
            If SQL_LOG_LEVEL > 0 Then log.Write("0", BuildQuery.Replace(commandText, commandParameters), OperationLog.OutPutLog.LogKind.Info)
            SqlHelper.ExecuteNonQuery(connectionString, commandType, commandText, commandParameters)
            ts.Complete()
        End Using
    End Function

    Public Overloads Function ExecuteNonQuery(ByVal connection As SqlConnection,
                                              ByVal commandType As CommandType,
                                              ByVal commandText As String,
                                              ByVal ParamArray commandParameters() As SqlParameter) As Integer
        If SQL_LOG_LEVEL > 0 Then log.Write("0", BuildQuery.Replace(commandText, commandParameters), OperationLog.OutPutLog.LogKind.Info)
        Return SqlHelper.ExecuteNonQuery(connection, commandType, commandText, commandParameters)
    End Function

    Public Overloads Function ExecuteNonQuery(ByVal connectionString As String, _
                                              ByVal commandType As CommandType, _
                                              ByVal commandText As String) As Integer
        Using ts As System.Transactions.TransactionScope = New System.Transactions.TransactionScope
            If SQL_LOG_LEVEL > 0 Then log.Write("0", BuildQuery.Replace(commandText), OperationLog.OutPutLog.LogKind.Info)
            SqlHelper.ExecuteNonQuery(connectionString, commandType, commandText)
            ts.Complete()
        End Using
    End Function

    Public Overloads Function ExecuteNonQuery(ByVal connection As SqlConnection,
                                              ByVal commandType As CommandType,
                                              ByVal commandText As String) As Integer
        If SQL_LOG_LEVEL > 0 Then log.Write("0", BuildQuery.Replace(commandText), OperationLog.OutPutLog.LogKind.Info)
        Return SqlHelper.ExecuteNonQuery(connection, commandType, commandText)
    End Function

    Public Overloads Sub FillDataset(ByVal connectionString As String, ByVal commandType As CommandType, ByVal commandText As String, ByVal dataSet As DataSet,
                                     ByVal tableNames() As String, ByVal ParamArray commandParameters() As SqlParameter)
        If SQL_LOG_LEVEL > 1 Then log.Write("0", BuildQuery.Replace(commandText, commandParameters), OperationLog.OutPutLog.LogKind.Info)
        SqlHelper.FillDataset(connectionString, commandType, commandText, dataSet, tableNames, commandParameters)
    End Sub

End Class
Public Class BuildQuery

    Public Shared Function Replace(ByVal commandtext As String) As String
        Return commandtext.Replace(vbCrLf, "\n")
    End Function

    Public Shared Function Replace(ByVal commandtext As String, ByVal ParamArray commandParameters() As SqlParameter) As String

        Dim strRet As String = commandtext.Replace(vbCrLf, "\n")

        For Each param As SqlParameter In commandParameters
            Select Case param.SqlDbType
                Case SqlDbType.VarChar, SqlDbType.NVarChar, SqlDbType.DateTime, SqlDbType.Date, SqlDbType.DateTime2
                    strRet = strRet.Replace(param.ParameterName, "'" + CType(param.Value, String) + "'")
                Case SqlDbType.Decimal, SqlDbType.TinyInt, SqlDbType.Int, SqlDbType.SmallInt
                    strRet = strRet.Replace(param.ParameterName, CType(param.Value, String))
                Case Else
                    strRet = strRet.Replace(param.ParameterName, CType(param.Value, String))
            End Select
        Next

        Return strRet

    End Function

End Class
Public Class StackFrameHistory

    Public Shared Function GetHistory() As String

        Dim Proc As System.Diagnostics.StackFrame
        Dim History As New System.Diagnostics.StackTrace(True)
        Dim K As Integer

        Dim ClassName As String '呼び出し履歴上のクラス名
        Dim ProcName As String '呼び出し履歴上のプロシージャ名
        Dim SourceFileName As String
        Dim LineNumber As Integer

        Dim strRetHistory As String = ""

        For K = History.FrameCount - 1 To 0 Step -1

            'スタックフレームを取得
            Proc = History.GetFrame(K)

            'この履歴のクラス名、プロシージャ名等を取得
            ClassName = Proc.GetMethod.ReflectedType.Name
            ProcName = Proc.GetMethod.Name
            SourceFileName = Proc.GetFileName
            LineNumber = Proc.GetFileLineNumber

            'リストボックスに表示
            'ListBox1.Items.Add("■" & ClassName & "." & ProcName)
            strRetHistory += "【" + ClassName + "." + ProcName + "】" + vbCrLf

            If Not (SourceFileName Is Nothing) Then
                'ListBox1.Items.Add(SourceFileName)
                'ListBox1.Items.Add(LineNumber)
                strRetHistory += "【SourceFileName】" + SourceFileName
                strRetHistory += "【LineNumber】" + LineNumber.ToString

            End If

        Next K

        Return strRetHistory

    End Function

End Class