Imports System.IO
Imports System.Text
Imports System.Data.SqlClient

Public Class frmMSE0090

    Private DownloadClient As System.Net.WebClient = Nothing

    Public Overrides Function PROGRAM_ID() As String
        Return "MSE0090"
    End Function

    Public Overrides Function PROGRAM_NAME() As String
        Return "郵便番号辞書データ作成"
    End Function

    Dim strPOST_DIR As String
    Dim strPOST_DLURL As String
    Dim strPOST_COMPRESSNM As String
    Dim strPOST_THAWNAME As String

    Protected Overrides Sub Form_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        MyBase.Form_Load(sender, e)

        Using wcur As New CommonUtility.WinForm.WaitCursor

            Call 基本設定情報取得()

            '保存先フォルダ作成
            If CommonUtility.Utility.NS(strPOST_DIR) <> vbNullString Then
                Call System.IO.Directory.CreateDirectory(strPOST_DIR)
            End If

            '画面初期化
            Call subInitDisp()

        End Using

    End Sub

    Private Sub 基本設定情報取得()

        Using Entity As New daMSE0090
            strPOST_DIR = Entity.ReadS_SCB("SYSTEM", "POST_DIR")
            strPOST_DLURL = Entity.ReadS_SCB("SYSTEM", "POST_DLURL")
            strPOST_COMPRESSNM = Entity.ReadS_SCB("SYSTEM", "POST_COMPRESSNM")
            strPOST_THAWNAME = Entity.ReadS_SCB("SYSTEM", "POST_THAWNAME")
        End Using
    End Sub

    Private Sub subInitDisp()

        txtPath.Text = CommonUtility.Utility.NS(strPOST_DIR)
        txtStatus.Text = ""
        txtURL.Text = CommonUtility.Utility.NS(strPOST_DLURL)
        Label1.Text = "上記サイトよりファイルをダウンロードしてください。" + Environment.NewLine + strPOST_COMPRESSNM + "がダウンロードされますので上記固定場所にコピーしてください。"

        '***** ﾌｧﾝｸｼｮﾝ･ｷｰ設定 *****
        FunctionKey.ClearAll()

        FunctionKey.SetItem(1, "終了", "終了", True)
        FunctionKey.SetItem(12, "実行", "実行", True)
    End Sub

    Private Sub subExecuteMain()

        '継承元よりファイルの保存先、ダウンロードURLを取得
        Dim FileName As String = strPOST_DIR
        Dim url As New Uri(strPOST_DLURL)

        If CommonUtility.Utility.RightBSA(FileName, 1) <> "\" Then FileName = FileName + "\"
        FileName = FileName + strPOST_COMPRESSNM

        'WebClientの作成
        If DownloadClient Is Nothing Then
            DownloadClient = New System.Net.WebClient()
            'イベントハンドラの作成
            AddHandler DownloadClient.DownloadProgressChanged,
                AddressOf downloadClient_DownloadProgressChanged
            AddHandler DownloadClient.DownloadFileCompleted,
                AddressOf downloadClient_DownloadFileCompleted
        End If
        '非同期ダウンロードを開始する
        ProgressCreate.Value = 0
        txtStatus.Text = "ダウンロード中..."
        DownloadClient.DownloadFileAsync(url, FileName)
    End Sub


    Private Sub downloadClient_DownloadProgressChanged(ByVal sender As Object,
        ByVal e As System.Net.DownloadProgressChangedEventArgs)
        ProgressCreate.Value = e.ProgressPercentage
        'Console.WriteLine( _
        '    "{0}% ({1}byte 中 {2}byte) ダウンロードが終了しました。", _
        '    e.ProgressPercentage, e.TotalBytesToReceive, e.BytesReceived)
    End Sub

    Private Sub downloadClient_DownloadFileCompleted(ByVal sender As Object,
            ByVal e As System.ComponentModel.AsyncCompletedEventArgs)
        If Not (e.Error Is Nothing) Then
            'Console.WriteLine("エラー:{0}", e.Error.Message)
            If subSchema() = False Then Exit Sub
        Else
            If e.Cancelled Then
                'Console.WriteLine("キャンセルされました。")
                txtStatus.Text = ""
                subProgressOperate(ProgressCreate.Value, 1)
            Else
                'Console.WriteLine("ダウンロードが完了しました。")
                If subSchema() = False Then Exit Sub
            End If
        End If
        txtStatus.Text = ""
        FunctionKey.Enabled = True
    End Sub

    'コードまとめ
    Private Function subSchema() As Boolean
        Dim Msg As CommonUtility.MessageCode_Arg0
        ProgressCreate.Value = 0
        txtStatus.Text = "郵便番号データ作成開始..."
        If fncCreatePostData(strPOST_DIR, Msg) = False Then
            txtStatus.Text = ""
            FunctionKey.Enabled = True
            CommonUtility.WinForm.MessageBoxEx.Show(Msg, PROGRAM_NAME)
            Return False
        End If
        CommonUtility.WinForm.MessageBoxEx.Show(Msg, PROGRAM_NAME)
        FunctionKey.Enabled = True
        ProgressCreate.Value = 0
        Return True
    End Function

    ''' <summary>
    ''' 郵便番号データを解凍後、データベースに格納
    ''' </summary>
    ''' <returns></returns>
    Private Function fncCreatePostData(ByVal path As String, ByRef Msg As CommonUtility.MessageCode_Arg0) As Boolean
        Dim blnCompress As Boolean = False
        Dim blnThaw As Boolean = False
        Dim Fsize As Integer
        Try
            If CommonUtility.Utility.RightBSA(path, 1) <> "\" Then path = path + "\"
            'ファイル存在チェック
            If fncFileCheck(path + strPOST_COMPRESSNM) = True Then blnCompress = True
            If fncFileCheck(path + strPOST_THAWNAME) = True Then blnThaw = True

            'どちらもファイルがなければ終了
            If blnCompress = False And blnThaw = False Then
                Msg = CommonUtility.MessageCode_Arg0.M301郵便番号データが存在しませんでした
                Return False
            End If

            If blnCompress = True Then
                Fsize = Int32.Parse(FileLen(path + strPOST_COMPRESSNM).ToString)
            End If

            If blnCompress = True And blnThaw = True And Fsize > 0 Then
                System.IO.File.Delete(path + strPOST_THAWNAME)
            End If

            If blnCompress = True And Fsize > 0 Then
                '取得したデータを解凍
                If unZip(path + strPOST_COMPRESSNM, path) = False Then
                    Msg = CommonUtility.MessageCode_Arg0.M302圧縮ファイルの解凍に失敗しました
                    Return False
                End If
            End If
        Catch
            Return False
        End Try

        '再度解凍後ファイルチェック(なければ終了)
        If fncFileCheck(path + strPOST_THAWNAME) = False Then
            Msg = CommonUtility.MessageCode_Arg0.M301郵便番号データが存在しませんでした
            Return False
        End If

        Try
            Using ts As System.Transactions.TransactionScope = New System.Transactions.TransactionScope(Transactions.TransactionScopeOption.Required, TimeSpan.FromMinutes(10.0))
                Using conn As New SqlClient.SqlConnection(CommonUtility.DBUtility.GetConnectionString)
                    conn.Open()
                    '最初にテーブルデータを全件削除
                    Using Entity As New daMSE0090
                        Entity.DeleteData(conn)
                    End Using
                    Dim sw As Stopwatch = Stopwatch.StartNew

                    'バルクコピー
                    Using bc As New SqlBulkCopy(conn),
                        wcur As New CommonUtility.WinForm.WaitCursor
                        With bc
                            ''コピー先テーブル名を指定
                            .DestinationTableName = "M_KEN"
                            ''進捗状況イベント
                            AddHandler .SqlRowsCopied, AddressOf Me.OnSqlRowsCopied
                            ''進捗状況イベント発生間隔の行数
                            .NotifyAfter = 100
                            ''CSVをDataTableで取得
                            Dim dt As DataTable = GetZipCodeDataTable(path + strPOST_THAWNAME)
                            ''プログレスバーの最大値をセット
                            Me.ProgressCreate.Maximum = dt.Rows.Count
                            ''データテーブルをコピー先へ書き込み
                            .WriteToServer(dt)
                        End With

                    End Using
                End Using
                ts.Complete()
            End Using
            Msg = CommonUtility.MessageCode_Arg0.M099正常終了しました

            Return True
        Catch
            Return False
        End Try
    End Function

    ''' <summary>
    ''' 指定行数が処理されるごとに発生するイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub OnSqlRowsCopied(ByVal sender As Object,
                                ByVal e As System.Data.SqlClient.SqlRowsCopiedEventArgs)
        ''プログレスバーにコピーされる行数をセット
        Me.ProgressCreate.Value = CInt(e.RowsCopied)
    End Sub


    ''' <summary>
    ''' 郵便番号データが格納されたDataTableを返します
    ''' </summary>
    ''' <param name="csvFilePath">郵便番号データCSVファイルのパス</param>
    ''' <returns>郵便番号データが格納されたDataTable</returns>
    ''' <remarks></remarks>
    Private Function GetZipCodeDataTable(ByVal csvFilePath As String) As DataTable

        Dim ds As New dsMSE0090
        Dim dt As DataTable
        Dim row As DataRow
        dt = ds.M_KENtype
        Using sr As New StreamReader(csvFilePath, Encoding.GetEncoding(932))
            Dim strLine As String
            Dim strFields() As String
            strLine = sr.ReadLine()
            While (strLine <> "")
                row = dt.NewRow
                strFields = Split(strLine, ",")
                For i As Integer = 0 To 8
                    row.Item(i) = strFields(i).Replace("""", "")
                Next
                dt.Rows.Add(row)
                strLine = sr.ReadLine()
            End While
        End Using

        Return dt

    End Function

    ''' <summary>
    ''' 郵便番号データCSVを格納するDataTableを返します
    ''' </summary>
    ''' <returns>郵便番号データDataTable</returns>
    ''' <remarks></remarks>
    Private Function CreateDataTable() As DataTable

        Dim dt As New DataTable
        With dt
            ''フィールド(列)を追加
            .Columns.Add("DANTAICODE", Type.GetType("System.String"))
            .Columns.Add("OLDPOSTCODE", Type.GetType("System.String"))
            .Columns.Add("POSTCODE", Type.GetType("System.String"))
            .Columns.Add("TODOUFUKEN_KANA", Type.GetType("System.String"))
            .Columns.Add("SIKUTYOUSON_KANA", Type.GetType("System.String"))
            .Columns.Add("TYOUKI_KANA", Type.GetType("System.String"))
            .Columns.Add("TODOUFUKEN", Type.GetType("System.String"))
            .Columns.Add("SIKUTYOUSON", Type.GetType("System.String"))
            .Columns.Add("TYOUIKI", Type.GetType("System.String"))
        End With
        Return dt

    End Function

    ''' <summary>
    ''' ファイル存在チェック
    ''' </summary>
    ''' <param name="path">フルパス</param>
    ''' <returns></returns>
    Private Function fncFileCheck(ByVal path As String) As Boolean
        If System.IO.File.Exists(path) Then Return True
        Return False
    End Function


    ''' <summary>
    ''' プログレスバーの制御を行う
    ''' </summary>
    ''' <param name="param">値の増減値</param>
    ''' <param name="mode">0:増加 1:減少</param>
    ''' <remarks></remarks>
    Private Sub subProgressOperate(ByVal param As Int32, Optional ByVal mode As Int16 = 0)
        If param <= 0 Then Exit Sub
        If mode = 0 Then
            For i = 0 To param
                If ProgressCreate.Value = ProgressCreate.Maximum Then Exit Sub
                ProgressCreate.Value = ProgressCreate.Value + 1
            Next
        Else
            For i = 0 To param
                ProgressCreate.Value = ProgressCreate.Value - 1
            Next
        End If
    End Sub

    'vZipFile: 解凍したいZipファイルのフルパス｡
    'vDestination: 解凍先のディレクトリ｡
    'bFlgDel:解凍後、Zipファイルを残すか。デフォルトflase(残す)。
    '
    '展開先にすでにファイルがある場合は､上書き確認のウインドウが表示されてしまうので注意
    Public Function unZip(ByVal vZipFile As String, ByVal vDestination As String, Optional ByVal bFlgDel As Boolean = False) As Boolean
        Try
            Dim objFileSys As New Scripting.FileSystemObject
            Dim objShell As New Shell32.Shell
            Dim objFile As Shell32.Folder
            Dim objDestination As Shell32.Folder

            If objFileSys.FileExists(vZipFile) = False Then Return True
            If UCase(objFileSys.GetExtensionName(vZipFile)) <> "ZIP" Then Return True

            objFile = objShell.NameSpace(vZipFile)
            objDestination = objShell.NameSpace(vDestination)

            If objFile Is Nothing Then Return False
            If objDestination Is Nothing Then Return False

            objDestination.CopyHere(objFile.Items)

            If bFlgDel Then My.Computer.FileSystem.DeleteFile(vZipFile)

            objFileSys = Nothing
            objShell = Nothing
            objFile = Nothing
            objDestination = Nothing

            Return True
        Catch e As Exception
            Return False
        End Try
    End Function



    ''' <summary>
    ''' ファンクションキー制御
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Overrides Sub FunctionKeyAction(ByVal sender As System.Object, ByVal e As CommonUtility.WinFormControls.FunctionKeyEventArgs)
        Select Case e.Name

            Case "終了"
                Me.Close()

            Case "実行"
                Using wcur As New CommonUtility.WinForm.WaitCursor

                    Try
                        'FunctionKey.Enabled = False
                        ProgressCreate.Maximum = 100

                        If RdManual.Checked = False Then
                            'Configの更新
                            subExecuteMain()
                        Else
                            subSchema()
                        End If
                    Catch
                        'FunctionKey.Enabled = True
                    End Try

                End Using

        End Select

    End Sub

End Class