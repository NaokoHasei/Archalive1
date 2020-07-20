Imports CommonUtility.Utility
Imports System.IO

Public Class OutPutLog

    '固定
    Private Shared HEDSTRING As String = "LOG_"              'ファイル名接頭語
    Private Shared LOGEXTENSION As String = ".log"           'ログファイル拡張子
    Private Shared _LogEncoding As String = "shift_jis"     'テキストログの出力エンコード

    Private Shared _UserId As String                        'ユーザーID
    Private Shared _ExecuteLocation As String               '実行場所
    Private Shared _PgId As String                          'プログラムID
    Private Shared _PcName As String                        '端末名
    Private Shared _LogSaveDay As Integer                     'ログ保持期間
    Private Shared _LogDir As String                        'ログ出力先

    ''' <summary>
    ''' ログ出力モード
    ''' </summary>
    ''' <remarks></remarks>
    Enum LogKind
        Info = 1
        Err = 2
        Debug = 3
        Warn = 4
        Fatal = 5
    End Enum

    ''' <summary>
    ''' メソッド名取得パラメータ
    ''' </summary>
    ''' <remarks></remarks>
    Protected Friend Enum MethodLocation
        ThisMethod = 1
        CallerMethod = 2
    End Enum

    Public Sub New(ByVal strLOG_DIR As String, ByVal shortLOG_DELDAY As Integer, ByVal pcname As String, ByVal usercode As String, ByVal pgid As String)

        _LogDir = strLOG_DIR
        _LogSaveDay = shortLOG_DELDAY

        _UserId = usercode
        _PcName = pcname
        _PgId = pgid

        'ディレクトリ作成
        CreateLogDir(_LogDir)

        '保存期間外ログファイル削除
        DeleteLog(_LogDir, _LogSaveDay)

    End Sub

    ''' <summary>
    ''' ログ書き込み
    ''' </summary>
    ''' <param name="code"></param>
    ''' <param name="Message"></param>
    ''' <param name="Kind"></param>
    ''' <remarks></remarks>
    Public Sub Write(ByVal code As String, ByVal Message As String, ByVal Kind As OutPutLog.LogKind)
        Dim writeFlg = False

        For idx = 1 To 5
            Try
                _ExecuteLocation = GetMethodName(MethodLocation.CallerMethod)

                Using sw As IO.StreamWriter = New IO.StreamWriter(GetLogFileName(_LogDir), True, System.Text.Encoding.GetEncoding(_LogEncoding))
                    sw.WriteLine(formatString(code, Message, Kind))
                End Using

                writeFlg = True

                Exit For
            Catch ex As IOException
                System.Threading.Thread.Sleep(1000)
            End Try
        Next

        If Not writeFlg Then
            Throw New Exception("ログファイルの書き込みに失敗しました。" + vbCrLf + "時間をあけて再度実行してください。")
        End If
    End Sub

    Public Class ClsIOException
        Inherits ApplicationException

        '========================================================
        ' 機能：コンストラクタ
        ' 引数：エラーメッセージ
        '========================================================
        Public Sub New(ByVal errorMessage As String)
            MyBase.New(errorMessage)
        End Sub

    End Class

    ''' <summary>
    ''' ログ書き込み（固有ファイル）
    ''' </summary>
    ''' <param name="Message"></param>
    ''' <param name="Kind"></param>
    ''' <remarks></remarks>
    Public Sub WriteFile(ByVal file As String, ByVal Message As String, ByVal Kind As OutPutLog.LogKind)

        _ExecuteLocation = GetMethodName(MethodLocation.CallerMethod)
        Using sw As IO.StreamWriter = New IO.StreamWriter(GetLogFileName(_LogDir, file), True, System.Text.Encoding.GetEncoding(_LogEncoding))
            sw.WriteLine(formatString(Message, Kind))
        End Using

    End Sub

    ''' <summary>
    ''' ログ書き込み
    ''' </summary>
    ''' <param name="Message"></param>
    ''' <param name="Kind"></param>
    ''' <remarks></remarks>
    Public Sub Write(ByVal Message As String, ByVal Kind As OutPutLog.LogKind)

        _ExecuteLocation = GetMethodName(MethodLocation.CallerMethod)
        Using sw As IO.StreamWriter = New IO.StreamWriter(GetLogFileName(_LogDir), True, System.Text.Encoding.GetEncoding(_LogEncoding))
            sw.WriteLine(formatString(Message, Kind))
        End Using

    End Sub

    ''' <summary>
    ''' ログ出力先なければ作成
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CreateLogDir(ByVal dir As String)
        If dir <> "" Then System.IO.Directory.CreateDirectory(dir)
    End Sub

    ''' <summary>
    ''' ログファイル名(フルパス)取得
    ''' </summary>
    ''' <param name="Dir"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetLogFileName(ByVal Dir As String) As String
        If Not Dir.EndsWith("\") Then Dir += "\"
        Return Dir & HEDSTRING & _PcName & "_" & System.DateTime.Now.ToString("yyyyMMdd") & LOGEXTENSION
    End Function

    ''' <summary>
    ''' ログファイル名(フルパス)取得
    ''' </summary>
    ''' <param name="Dir"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetLogFileName(ByVal Dir As String, ByVal filename As String) As String
        If Not Dir.EndsWith("\") Then Dir += "\"
        Return Dir & filename
    End Function

    ''' <summary>
    ''' 与えられたパラメータを元に出力文字列整形
    ''' 文字列を整形する。このクラス内からのみアクセス
    ''' </summary>
    ''' <param name="msg"></param>
    ''' <param name="Kind"></param>
    ''' <param name="Code"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function formatString(ByVal Code As String, ByVal msg As String, ByVal Kind As OutPutLog.LogKind) As String
        Dim ret As String = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
        ret += "," + _PgId.PadRight(10)
        ret += "," + retKindString(Kind)
        ret += "," + _PcName
        ret += "," + _UserId
        ret += "," + _ExecuteLocation
        ret += "," + Code
        ret += "," + msg
        Return ret
    End Function

    ''' <summary>
    ''' 与えられたパラメータを元に出力文字列整形
    ''' 文字列を整形する。このクラス内からのみアクセス
    ''' </summary>
    ''' <param name="msg"></param>
    ''' <param name="Kind"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function formatString(ByVal msg As String, ByVal Kind As OutPutLog.LogKind) As String
        Dim ret As String = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
        ret += "," + _PgId.PadRight(10)
        ret += "," + retKindString(Kind)
        ret += "," + _PcName
        ret += "," + _UserId
        ret += "," + _ExecuteLocation
        ret += ","
        ret += "," + msg
        Return ret
    End Function

    ''' <summary>
    ''' ログ出力区分に応じた文字列を返す
    ''' </summary>
    ''' <param name="Kind"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function retKindString(ByVal Kind As LogKind) As String
        Select Case Kind
            Case LogKind.Debug
                Return "D"
            Case LogKind.Info
                Return "I"
            Case LogKind.Err
                Return "E"
            Case LogKind.Warn
                Return "W"
            Case LogKind.Fatal
                Return "F"
            Case Else
                'ありえない
                Return ""
        End Select
    End Function

    ''' <summary>
    ''' 呼び出し元メソッドを取得
    ''' </summary>
    ''' <param name="i"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetMethodName(ByVal i As MethodLocation) As String
        Dim st As New StackTrace
        Dim ClsName As String = st.GetFrame(i).GetMethod.ReflectedType.Name
        Dim MethodName As String = st.GetFrame(i).GetMethod.Name
        Dim Location As String = String.Format("{0},{1}", ClsName, MethodName)
        Return Location
    End Function

    ''' <summary>
    ''' 保存日数を超えたログファイルを削除する
    ''' </summary>
    ''' <param name="Dir"></param>
    ''' <param name="SaveDay"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function DeleteLog(ByVal Dir As String, ByVal SaveDay As Integer) As Boolean

        Dim Folder As New DirectoryInfo(Dir)
        Dim File As FileInfo
        Dim strWork As String
        Dim day As Date = System.DateTime.Now
        Dim day2 = day.AddDays(SaveDay * (-1)).ToString("yyyyMMdd")
        For Each File In Folder.GetFiles("*" & LOGEXTENSION, SearchOption.TopDirectoryOnly)
            strWork = RightBSA(File.Name, CType(8 + LenBSA(LOGEXTENSION), Short))
            strWork = LeftBSA(strWork, 8)
            If IsNumeric(strWork) Then
                If Int32.Parse(strWork) < Int32.Parse(day2) Then
                    'ファイル削除
                    Try
                        File.Delete()
                    Catch e As Exception
                        '例外はスルー
                    End Try
                End If
            End If
        Next
    End Function

End Class
