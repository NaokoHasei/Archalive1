
Imports C1.Win.C1TrueDBGrid
Imports CommonUtility.Utility
Imports CommonUtility.WinForm
Imports CommonUtility.WinFormControls
Imports BLL.Common

Public Class frmBUK0004

    Public Overrides Function PROGRAM_ID() As String
        Return "BUK0004"
    End Function

    Public Overrides Function PROGRAM_NAME() As String
        Return "関連資料一覧"
    End Function

    '--- COLUMNS DATAVALUE
    Private Const FLD_SAKUJO As String = "SAKUJO"           '削除ボタン
    Private Const FLD_FILE_NAME As String = "FILE_NAME"     'ファイル名
    Private Const FLD_SAVE_DATE As String = "SAVE_DATE"     '保存日時
    Private Const FLD_UPLOAD_USER As String = "UPLOAD_USER" '保存ユーザ
    Private Const FLD_FILE_NO As String = "FILENO"          'ファイルNo

    '--- COLUMNS INDEX
    Private Const COL_SAKUJO As Integer = 0                 '削除ボタン
    Private Const COL_FILE_NAME As Integer = 1              'ファイル名
    Private Const COL_SAVE_DATE As Integer = 2              '保存日時
    Private Const COL_UPLOAD_USER As Integer = 3            '保存ユーザ
    Private Const COL_FILE_NO As Integer = 4                'ファイルNo

    Private Const COL_COUNT As Integer = 4                  '最大列数

    Public dt As dsBUK0004.dbgMeisaiDataTable

    Public S_SCB_UploadFilePath As String
    Public S_SCB_UploadFileSize As Decimal

    Private T_BUKKEN_FILE As T_BUKKEN_FILERead
    Public requestBUK0001 As New requestBUK0001

    Public Sub New()

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。

        requestBUK0001.BUKKEN_NO = 0
    End Sub

    ''' <summary>
    ''' フォームロード
    ''' </summary>
    Protected Overrides Sub Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MyBase.Form_Load(sender, e)

        Using wcur As New WaitCursor

            PictureBox1.Image = New Bitmap(System.Environment.CurrentDirectory & "\Upload.jpeg")
            PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage

            '物件Noの設定
            txtBukkenNo.Text = requestBUK0001.BUKKEN_NO

            'S_SCBの読み込み
            ReadS_SCB()

            'インスタンスの設定
            T_BUKKEN_FILE = New T_BUKKEN_FILERead

            'グリッドの初期化
            InitGrid()

            '画面の初期化
            InitDisp()

        End Using
    End Sub

    ''' <summary>
    ''' S_SCBの読み込み
    ''' </summary>
    Private Sub ReadS_SCB()
        '関連資料一覧のアップロード先
        Dim S_SCB As New S_SCBRead("関連資料一覧のアップロード先", "")
        Dim dsS_SCB As dsS_SCB = S_SCB.GetS_SCB

        '存在チェック
        If dsS_SCB.S_SCB.Count = 0 Then
            MsgBox("基本設定マスタの関連資料一覧のアップロード先が登録されていません。")
            Me.Close()
        End If
        S_SCB_UploadFilePath = dsS_SCB.S_SCB(0).DATA

        '￥マーク付与
        If S_SCB_UploadFilePath.Substring(S_SCB_UploadFilePath.Length - 1) <> "\" Then
            S_SCB_UploadFilePath += "\"
        End If

        'パスの存在チェック
        If Not System.IO.Directory.Exists(S_SCB_UploadFilePath) Then
            MsgBox("基本設定マスタの関連資料一覧のパスが参照できません。")
            Me.Close()
        End If

        '物件Noのパス付与
        S_SCB_UploadFilePath += ZeroPadding(txtBukkenNo.Text, 10) + "\"

        '物件Noのフォルダ作成
        If Not System.IO.Directory.Exists(S_SCB_UploadFilePath) Then
            System.IO.Directory.CreateDirectory(S_SCB_UploadFilePath)
        End If


        '関連資料一覧のファイルサイズ
        S_SCB = New S_SCBRead("関連資料一覧のファイルサイズ", "")
        dsS_SCB = S_SCB.GetS_SCB

        If Not Decimal.TryParse(dsS_SCB.S_SCB(0).DATA, S_SCB_UploadFileSize) Then
            S_SCB_UploadFileSize = 0
        End If

    End Sub

    ''' <summary>
    ''' 画面の初期化
    ''' </summary>
    Private Sub InitDisp()

        chkAll.Checked = False

        '物件資料トランの取得
        Dim dtT_BUKKEN_FILE = T_BUKKEN_FILE.GetDataWhereBukkenNo(txtBukkenNo.Text)

        Dim dt = New dsBUK0004.dbgMeisaiDataTable
        Dim dr As dsBUK0004.dbgMeisaiRow

        '明細の表示
        For Each row In dtT_BUKKEN_FILE
            dr = dt.NewRow

            dr.SAKUJO = False
            dr.FILE_NAME = row.FILENNAME
            dr.SAVE_DATE = row.UPDATEMENT
            dr.UPLOAD_USER = row.TANTONAME
            dr.FILENO = row.FILENO

            dt.Rows.Add(dr)
        Next

        dbgMEISAI.SetDataBinding(dt, "", True)

        'ファンクションキー設定
        FunctionKey.ClearAll()

        Dim enabled = IIf(dt.Rows.Count = 0, False, True)

        FunctionKey.SetItem(1, "終了", "終了", True)
        FunctionKey.SetItem(3, "削除", "削除", enabled)
        FunctionKey.SetItem(12, "ファイル参照", "ファイル" & vbCrLf & "参照", enabled, New System.Drawing.Font("メイリオ", 9))
    End Sub

    ''' <summary>
    ''' ファンクションキー　イベント
    ''' </summary>
    Protected Overrides Sub FunctionKeyAction(ByVal sender As System.Object, ByVal e As CommonUtility.WinFormControls.FunctionKeyEventArgs)

        Select Case e.Name

            Case "終了"

                '呼び出し元の再表示
                CType(ownerForm, frmBUK0001).ShowReDisp()

                Me.Close()

            Case "ファイル参照"

                System.Diagnostics.Process.Start(S_SCB_UploadFilePath)

            Case "削除"

                ExecuteDelete()

        End Select

    End Sub

    ''' <summary>
    ''' 入力チェック
    ''' </summary>
    Private Function InputErrorCheck() As Boolean

        '全てチェック無しの場合、エラー
        For Each row In CType(dbgMEISAI.DataSource, dsBUK0004.dbgMeisaiDataTable)
            If row.SAKUJO = True Then Return True
        Next

        MessageBoxEx.Show(CommonUtility.MessageCode_Arg1.M218, "削除対象", PROGRAM_NAME)

        Return False

    End Function

    ''' <summary>
    ''' 削除ボタン　クリック
    ''' </summary>
    Private Sub ExecuteDelete()

        '入力チェック
        If Not InputErrorCheck() Then Return

        '確認メッセージ
        If MessageBoxEx.Show(CommonUtility.MessageCode_Arg0.M002削除してもよろしいですか, PROGRAM_NAME) = Windows.Forms.DialogResult.No Then
            Return
        End If

        Try
            For Each row In CType(dbgMEISAI.DataSource, dsBUK0004.dbgMeisaiDataTable)
                'ファイルの削除
                System.IO.File.Delete(S_SCB_UploadFilePath + row.FILE_NAME)

                If row.SAKUJO Then
                    '物件資料トランの削除
                    T_BUKKEN_FILE.deleteT_BUKKEN_FILE(txtBukkenNo.Text, row.FILENO)
                End If
            Next

        Catch e As Exception
            MessageBoxEx.Show(CommonUtility.MessageCode_Arg2.M215, "ファイルの削除", vbCrLf + vbCrLf + e.Message, PROGRAM_NAME)

            '画面の初期化
            InitDisp()

            Return
        End Try

        MessageBoxEx.Show(CommonUtility.MessageCode_Arg1.M214, "ファイルの削除", PROGRAM_NAME)

        '画面の初期化
        InitDisp()
    End Sub

    ''' <summary>
    ''' グリッドの初期化
    ''' </summary>
    Private Sub InitGrid()

        With dbgMEISAI
            .DataView = DataViewEnum.Normal
            .LinesPerRow = 0

            Dim co As New C1DataColumn("", FLD_SAKUJO, Type.GetType("System.Boolean"))
            co.ValueItems.Presentation = PresentationEnum.CheckBox

            If .Columns.Count = 0 Then
                '***** 共通 *****
                With .Columns
                    .Add(co)
                    .Add(New C1DataColumn("", FLD_FILE_NAME, Type.GetType("System.String")))
                    .Add(New C1DataColumn("", FLD_SAVE_DATE, Type.GetType("System.String")))
                    .Add(New C1DataColumn("", FLD_UPLOAD_USER, Type.GetType("System.String")))
                    .Add(New C1DataColumn("", FLD_FILE_NO, Type.GetType("System.String")))
                End With
            End If

            '*** TrueDBGrid NumberFormat プロパティ設定 ***
            '.Columns(COL_TANTONAME).NumberFormat = "#,##0円"

            '*** TrueDBGrid Caption プロパティ設定 ***
            .Columns(COL_SAKUJO).Caption = "削除"
            .Columns(COL_FILE_NAME).Caption = "ファイル名"
            .Columns(COL_SAVE_DATE).Caption = "保存日時"
            .Columns(COL_UPLOAD_USER).Caption = "保存ユーザ"

            .RecordSelectors = False 'レコードセレクタ非表示（グリッド左側）

            With .Splits(0)
                For intIndex As Integer = 0 To dbgMEISAI.Columns.Count - 1
                    .DisplayColumns(intIndex).Visible = CType(IIf(intIndex < COL_COUNT, True, False), Boolean)
                Next
            End With

            '*** 共通設定 ***
            GridSetup(dbgMEISAI, GridSetupAllows.AllowReadOnly, False, False, False)

            With .Splits(0)
                '*** TrueDBGrid Width プロパティ設定 ***
                .DisplayColumns(COL_SAKUJO).Width = 50
                .DisplayColumns(COL_FILE_NAME).Width = 300
                .DisplayColumns(COL_SAVE_DATE).Width = 150
                .DisplayColumns(COL_UPLOAD_USER).Width = 127
            End With

            '個別の設定はGridSetupの後

            '全般
            .AllowUpdate = True                     'レコード更新可能　　(True:可，False:不可)
            .EditDropDown = False                   '編集にドロップダウンウインドウを使用するか？

            .Enabled = True

            .AllowColMove = False
            .AllowColSelect = False
            .AllowRowSizing = RowSizingEnum.None
            .AllowRowSelect = False

            '表示
            .ColumnHeaders = True                                               '列タイトルの表示
            .MarqueeStyle = MarqueeEnum.HighlightRow        '行選択・ハイライト表示
            .BorderStyle = BorderStyle.Fixed3D                                  'タイトルとレコードセレクタの３Ｄ表示
            .RowDivider.Style = LineStyleEnum.None          '行の境界線スタイル
            .FetchRowStyles = True                                              'FetchRowStyleイベントを発生させるかどうかを設定

            .Font = New System.Drawing.Font("メイリオ", 8.25!, FontStyle.Regular, GraphicsUnit.Point, 128)

            'Splits 単位
            .Splits(0).HScrollBar.Style = ScrollBarStyleEnum.None
            .Splits(0).VScrollBar.Style = ScrollBarStyleEnum.Always
            .Splits(0).AllowFocus = True

            '*** ヘッダー ***
            '仕切り線

            .HeadingStyle.Borders.BorderType = BorderTypeEnum.None
            .HeadingStyle.Font = New System.Drawing.Font("メイリオ", 8.25!, FontStyle.Regular, GraphicsUnit.Point, 128)

            '*** TrueDBGrid HeadingStyle.HorizontalAlignment プロパティ設定 ***
            For intIndex As Integer = 0 To dbgMEISAI.Columns.Count - 1
                .Splits(0).DisplayColumns(intIndex).HeadingStyle.HorizontalAlignment = AlignHorzEnum.Near
            Next
            .Splits(0).DisplayColumns(COL_SAKUJO).HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center

            '*** TrueDBGrid ColumnDivider.Style プロパティ設定 ***
            For intIndex As Integer = 0 To dbgMEISAI.Columns.Count - 1
                .Splits(0).DisplayColumns(intIndex).ColumnDivider.Style = LineStyleEnum.None
            Next

            For intIndex As Integer = 0 To dbgMEISAI.Columns.Count - 1
                .Splits(0).DisplayColumns(intIndex).Style.HorizontalAlignment = AlignHorzEnum.Near
            Next
            .Splits(0).DisplayColumns(COL_SAKUJO).Style.HorizontalAlignment = AlignHorzEnum.Center

            '*** TrueDBGrid AllowSizing プロパティ設定 ***
            For intI As Integer = 0 To dbgMEISAI.Columns.Count - 1
                .Splits(0).DisplayColumns(intI).AllowSizing = True
            Next intI

            .Splits(0).DisplayColumns(COL_SAKUJO).FetchStyle = True
            .Splits(0).DisplayColumns(COL_FILE_NAME).FetchStyle = True
            .Splits(0).DisplayColumns(COL_SAVE_DATE).FetchStyle = True
            .Splits(0).DisplayColumns(COL_UPLOAD_USER).FetchStyle = True
        End With
    End Sub

    ''' <summary>
    ''' 明細　イベント
    ''' </summary>
    Private Sub dbgMEISAI_FetchCellStyle(ByVal sender As Object, ByVal e As FetchCellStyleEventArgs) Handles dbgMEISAI.FetchCellStyle
        Select Case e.Col
            Case COL_SAKUJO
                e.CellStyle.ForeColor = Color.Black
                e.CellStyle.Locked = False

            Case COL_FILE_NAME, COL_SAVE_DATE, COL_UPLOAD_USER
                e.CellStyle.Locked = True
        End Select
    End Sub

    ''' <summary>
    ''' ドラッグ中のオブジェクトがファイルであるか確認する
    ''' </summary>
    Private Sub Panel1_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Panel1.DragEnter

        'データ形式の確認
        If e.Data.GetDataPresent(DataFormats.FileDrop) = False Then
            Return
        End If

        'ドラッグしているファイル／フォルダの取得
        Dim FilePath() As String = CType(e.Data.GetData(DataFormats.FileDrop), String())

        For idx As Integer = 0 To FilePath.Length - 1
            If Not System.IO.File.Exists(FilePath(idx)) Then
                Return
            End If
        Next idx

        'ドロップ可能な場合は、エフェクトを変える
        e.Effect = DragDropEffects.Copy
    End Sub

    ''' <summary>
    ''' ファイルドラッグ＆ドロップ　イベント
    ''' </summary>
    Private Sub Panel1_DragDrop(ByVal sender As Object, ByVal e As DragEventArgs) Handles Panel1.DragDrop
        '選択したファイルの登録
        RegistFile(CType(e.Data.GetData(DataFormats.FileDrop), String()))
    End Sub

    ''' <summary>
    ''' ファイル選択ボタン　イベント
    ''' </summary>
    Private Sub btnFileSelect_Click(sender As Object, e As EventArgs) Handles btnFileSelect.Click
        'OpenFileDialogクラスのインスタンスを作成
        Dim ofd As New OpenFileDialog()

        ofd.Title = "ファイル選択（複数ファイル選択可）" 'タイトル
        ofd.Multiselect = True                          '複数のファイルを選択できるようにする

        'ダイアログを表示する
        If ofd.ShowDialog() = DialogResult.OK Then
            '選択したファイルの登録
            RegistFile(ofd.FileNames)
        End If
    End Sub

    ''' <summary>
    ''' 選択したファイルの登録
    ''' </summary>
    Private Sub RegistFile(ByVal FilePath() As String)
        Dim drT_BUKKEN_FILE() As dsT_BUKKEN_FILE.T_BUKKEN_FILERow
        Dim fileName As String
        Dim notExistsFileName As String = ""

        Try
            'ファイルサイズが大きい場合、確認メッセージを表示
            For idx As Integer = 0 To FilePath.Length - 1
                Dim fi As New System.IO.FileInfo(FilePath(idx))

                If fi.Length > S_SCB_UploadFileSize * 1000000 Then
                    If MessageBoxEx.Show(CommonUtility.MessageCode_Arg1.M221, S_SCB_UploadFileSize, PROGRAM_NAME) = DialogResult.No Then
                        Return
                    Else
                        Exit For
                    End If
                End If
            Next

            '物件資料トランの取得
            Dim dtT_BUKKEN_FILE = T_BUKKEN_FILE.GetDataWhereBukkenNo(txtBukkenNo.Text)

            '同一のファイル名が既に登録されている場合、確認メッセージを表示
            For idx As Integer = 0 To FilePath.Length - 1

                drT_BUKKEN_FILE = dtT_BUKKEN_FILE.Select("FILENNAME = '" + System.IO.Path.GetFileName(FilePath(idx)) + "'")

                If drT_BUKKEN_FILE.Count <> 0 Then
                    If MessageBoxEx.Show(CommonUtility.MessageCode_Arg0.M222, PROGRAM_NAME) = DialogResult.No Then
                        Return
                    Else
                        Exit For
                    End If
                End If
            Next

            'ファイル番号の取得
            Dim fileNo = T_BUKKEN_FILE.GetDataMaxFILENO(txtBukkenNo.Text)

            Dim nowDateTime = DateTime.Now

            For idx As Integer = 0 To FilePath.Length - 1
                fileName = System.IO.Path.GetFileName(FilePath(idx))

                drT_BUKKEN_FILE = dtT_BUKKEN_FILE.Select("FILENNAME = '" + fileName + "'")

                'ファイルのアップロード
                System.IO.File.Copy(FilePath(idx), S_SCB_UploadFilePath + fileName, True)

                Dim dt = New dsT_BUKKEN_FILE.T_BUKKEN_FILEDataTable
                Dim dr = CType(dt.NewRow, dsT_BUKKEN_FILE.T_BUKKEN_FILERow)

                If drT_BUKKEN_FILE.Count = 0 Then
                    '新規の場合
                    fileNo += 1

                    dr.BUKKENNO = txtBukkenNo.Text
                    dr.FILENO = fileNo
                    dr.FILEPATH = S_SCB_UploadFilePath
                    dr.FILENNAME = fileName
                    dr.UPDATEPGID = PROGRAM_ID()
                    dr.UPDATEUSERCODE = TANTO_CODE
                    dr.UPDATEMENT = nowDateTime

                    T_BUKKEN_FILE.insertT_BUKKEN_FILE(dr)

                Else
                    '更新の場合
                    dr.BUKKENNO = txtBukkenNo.Text
                    dr.FILENO = drT_BUKKEN_FILE(0).FILENO
                    dr.UPDATEPGID = PROGRAM_ID()
                    dr.UPDATEUSERCODE = TANTO_CODE
                    dr.UPDATEMENT = nowDateTime

                    T_BUKKEN_FILE.updateT_BUKKEN_FILE_UPDATEPGID_UPDATEUSERCODE(dr)
                End If
            Next idx

        Catch e As Exception
            MessageBoxEx.Show(CommonUtility.MessageCode_Arg2.M215, "ファイルのアップロード", vbCrLf + vbCrLf + e.Message, PROGRAM_NAME)

            '画面の初期化
            InitDisp()

            Return
        End Try

        MessageBoxEx.Show(CommonUtility.MessageCode_Arg1.M214, "ファイルのアップロード", PROGRAM_NAME)

        '画面の初期化
        InitDisp()
    End Sub

    ''' <summary>
    ''' 全て選択チェックボックス　イベント
    ''' </summary>
    Private Sub chkAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkAll.CheckedChanged

        Dim value = chkAll.Checked

        For Each row In CType(dbgMEISAI.DataSource, dsBUK0004.dbgMeisaiDataTable)
            row.SAKUJO = value
        Next

        dbgMEISAI.Refresh()
    End Sub
End Class
