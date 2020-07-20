
Imports C1.Win.C1TrueDBGrid
Imports CommonUtility
Imports CommonUtility.Utility
Imports CommonUtility.WinForm
Imports CommonUtility.WinFormControls
Imports BLL.Common

Public Class frmBUK0002

    Public Overrides Function PROGRAM_ID() As String
        Return "BUK0002"
    End Function

    Public Overrides Function PROGRAM_NAME() As String
        Return "物件検索"
    End Function

    '--- COLUMNS DATAVALUE
    Public Const FLD_SENTAKU As String = "SENTAKU"                 '選択ボタン
    Public Const FLD_JYOTAI As String = "JYOTAI"                   '状態
    Public Const FLD_SYONIN_JYUTYU As String = "SYONIN_JYUTYU"     '受注承認
    Public Const FLD_SYONIN_HATTYU As String = "SYONIN_HATTYU"     '発注承認
    Public Const FLD_BUKKENNO As String = "BUKKENNO"               '物件No
    Public Const FLD_BUKKENNAME As String = "BUKKENNAME"           '物件名
    Public Const FLD_KOUJIBASYO As String = "KOUJIBASYO"           '工事場所
    Public Const FLD_MOTOUKE As String = "MOTOUKE"                 '元請
    Public Const FLD_CHAKKOUDATE As String = "CHAKKOUDATE"         '着工日
    Public Const FLD_KANKOUDATE As String = "KANKOUDATE"           '完工日
    Public Const FLD_TANTONAME As String = "TANTONAME"             '担当者

    '--- COLUMNS INDEX
    Public Const COL_SENTAKU As Integer = 0                        '選択ボタン
    Public Const COL_JYOTAI As Integer = 1                         '状態
    Public Const COL_SYONIN_JYUTYU As Integer = 2                  '受注承認
    Public Const COL_SYONIN_HATTYU As Integer = 3                  '発注承認
    Public Const COL_BUKKENNO As Integer = 4                       '物件No
    Public Const COL_BUKKENNAME As Integer = 5                     '物件名
    Public Const COL_KOUJIBASYO As Integer = 6                     '工事場所
    Public Const COL_MOTOUKE As Integer = 7                        '元請
    Public Const COL_CHAKKOUDATE As Integer = 8                    '着工日
    Public Const COL_KANKOUDATE As Integer = 9                     '完工日
    Public Const COL_TANTONAME As Integer = 10                     '担当者

    Public Const COL_COUNT As Integer = 10                          '最大列数

    Private WithEvents KOBETU_KOKYAKU As WinFormBase.KobetuControl
    Private WithEvents KOBETU_TANTO As WinFormBase.KobetuControl

    Private SENTAKU As New BLL.SEN.SENTAKU

    Private daBUK0002 As New daBUK0002
    Public requestBUK0001 As New requestBUK0001
    Public requestMAP0001 As New requestMAP0001
    Public responseMAP0001 As New responseMAP0001

    Public S_SCB_SeachCountList As String                           'S_SCB 検索結果の上限（物件検索／一覧） 
    Public S_SCB_SeachCountMap As String                            'S_SCB 検索結果の上限（物件検索／地図） 

    Private strProgramName As String                                'プログラム名

    Public Sub New()

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()
    End Sub

    ''' <summary>
    ''' フォームロード
    ''' </summary>
    Protected Overrides Sub Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MyBase.Form_Load(sender, e)

        Using wcur As New WaitCursor

            Me.TitleBar.Title = PROGRAM_NAME()
            Me.Text = PROGRAM_NAME()

            '検索ボタンの定義
            KOBETU_KOKYAKU = New WinFormBase.KobetuControl(cmdKMENU, Model.KobetuTableName.M_TOKUI, PCNAME, PROGRAM_ID(), 0, TANTO_CODE, Model.InitializeKind.初期化_完全初期化, Model.FinalizeKind.削除_完全削除)
            KOBETU_TANTO = New WinFormBase.KobetuControl(cmdTMENU, Model.KobetuTableName.M_TANTO, PCNAME, PROGRAM_ID(), 0, TANTO_CODE, Model.InitializeKind.初期化_完全初期化, Model.FinalizeKind.削除_完全削除)

            'S_SCBの読み込み
            ReadS_SCB()

            'グリッドの初期化
            InitGrid(Me, dbgMEISAI)

            'コンボボックス初期化
            InitComboBox()

            'ファンクションキー設定
            InitFunctionKey()

            '画面の初期化
            InitDisp()

            'イベント設定
            InitEvent()

            Me.ActiveControl = txtBukkenNo2
        End Using
    End Sub

    ''' <summary>
    ''' S_SCBの読み込み
    ''' </summary>
    Private Sub ReadS_SCB()
        '検索結果の上限（物件検索／一覧）
        Dim S_SCB As New S_SCBRead("検索結果の上限（物件検索／一覧）", "")
        Dim dsS_SCB As dsS_SCB = S_SCB.GetS_SCB

        If dsS_SCB.S_SCB.Count = 0 Then
            S_SCB_SeachCountList = ""
        Else
            S_SCB_SeachCountList = dsS_SCB.S_SCB(0).DATA
        End If

        '検索結果の上限（物件検索／地図）
        S_SCB = New S_SCBRead("検索結果の上限（物件検索／地図）", "")
        dsS_SCB = S_SCB.GetS_SCB

        If dsS_SCB.S_SCB.Count = 0 Then
            S_SCB_SeachCountMap = ""
        Else
            S_SCB_SeachCountMap = dsS_SCB.S_SCB(0).DATA
        End If
    End Sub

    ''' <summary>
    ''' 画面の初期化
    ''' </summary>
    Private Sub InitDisp()
        txtBukkenNo2.Text = ""
        rdoList.Checked = True
        cmbJyotai.Text = ""
        rdoSyoninJyuAll.Checked = True
        rdoSyoninHatAll.Checked = True
        txtBukkenName.Text = ""
        txtKoujiBasyo.Text = ""
        cmbMotoukeCode.Text = ""
        cmbTanatoCode.Text = ""
        txtChakkouDateST.Text = ""
        txtChakkouDateED.Text = ""

        Dim dt As New dsBUK0002.dbgMeisaiDataTable
        dbgMEISAI.SetDataBinding(dt, "", True)
    End Sub

    ''' <summary>
    ''' コンボボックス初期化
    ''' </summary>
    Private Sub InitComboBox()
        Dim logic As New BLL.Common.TypComboBox

        Dim paramlist As New List(Of Model.DTO.RequestGetComboBoxContentsElement)
        paramlist.Add(New Model.DTO.RequestGetComboBoxContentsElement(Model.ComboBoxTableName.M_TOKUI, Model.DTO.GetComboBoxContentsResultFieldType.MultipleField, False, Nothing))
        paramlist.Add(New Model.DTO.RequestGetComboBoxContentsElement(Model.ComboBoxTableName.M_TANTO, Model.DTO.GetComboBoxContentsResultFieldType.MultipleField, False, Nothing))
        paramlist.Add(New Model.DTO.RequestGetComboBoxContentsElement(Model.ComboBoxTableName.M_KBN, Model.DTO.GetComboBoxContentsResultFieldType.MultipleField, False, "07"))

        Dim requestParam As New Model.DTO.RequestGetComboBoxContents(paramlist)
        Dim recieveParam = logic.CreateComboBox(requestParam)

        '元請
        cmbMotoukeCode.AttachDataSource(Model.ComboBoxTableName.M_TOKUI, recieveParam)
        '担当者
        cmbTanatoCode.AttachDataSource(Model.ComboBoxTableName.M_TANTO, recieveParam)
        '状態
        cmbJyotai.AttachDataSource(Model.ComboBoxTableName.M_KBN, recieveParam)
    End Sub

    ''' <summary>
    ''' ファンクションキー設定
    ''' </summary>
    Private Sub InitFunctionKey()

        FunctionKey.ClearAll()

        FunctionKey.SetItem(1, "終了", "終了", True)
        FunctionKey.SetItem(9, "検索", "検索", False)
        FunctionKey.SetItem(12, "照会", "照会", True)
    End Sub

    ''' <summary>
    ''' イベント設定
    ''' </summary>
    Private Sub InitEvent()
        'フォーカス取得時イベント
        AddHandler rdoList.Enter, AddressOf Control_Enter
        AddHandler rdoMap.Enter, AddressOf Control_Enter
        AddHandler cmbJyotai.Enter, AddressOf Control_Enter
        AddHandler txtBukkenName.Enter, AddressOf Control_Enter
        AddHandler txtKoujiBasyo.Enter, AddressOf Control_Enter
        AddHandler cmbMotoukeCode.Enter, AddressOf Control_Enter
        AddHandler cmbTanatoCode.Enter, AddressOf Control_Enter
        AddHandler txtChakkouDateST.Enter, AddressOf Control_Enter
        AddHandler txtChakkouDateED.Enter, AddressOf Control_Enter
        AddHandler dbgMEISAI.Enter, AddressOf Control_Enter

        'Enterキーイベント
        AddHandler rdoList.KeyPress, AddressOf Control_KeyPress
        AddHandler rdoMap.KeyPress, AddressOf Control_KeyPress
        AddHandler rdoSyoninJyuAll.KeyPress, AddressOf Control_KeyPress
        AddHandler rdoSyoninJyuMi.KeyPress, AddressOf Control_KeyPress
        AddHandler rdoSyoninJyuSumi.KeyPress, AddressOf Control_KeyPress
        AddHandler rdoSyoninHatAll.KeyPress, AddressOf Control_KeyPress
        AddHandler rdoSyoninHatMi.KeyPress, AddressOf Control_KeyPress
        AddHandler rdoSyoninHatSumi.KeyPress, AddressOf Control_KeyPress
    End Sub

    ''' <summary>
    ''' ファンクションキー　イベント
    ''' </summary>
    Protected Overrides Sub FunctionKeyAction(ByVal sender As System.Object, ByVal e As CommonUtility.WinFormControls.FunctionKeyEventArgs)

        Select Case e.Name

            Case "終了"
                '*** 個別選択の全ワークテーブル削除(完全削除) ***
                Call SENTAKU.Unload(Model.FinalizeKind.削除_完全削除, Model.KobetuTableName.M_TANTO, PCNAME, PROGRAM_ID(), 0, TANTO_CODE)
                Call SENTAKU.Unload(Model.FinalizeKind.削除_完全削除, Model.KobetuTableName.M_TOKUI, PCNAME, PROGRAM_ID(), 0, TANTO_CODE)

                Me.Close()

                Exit Sub

            Case "検索"
                PopupSearchForm()

            Case "照会"
                SearchMeisai()

        End Select

    End Sub

    ''' <summary>
    ''' 検索画面起動
    ''' </summary>
    Private Sub PopupSearchForm()

        Select Case LastFocusedControl.Name
            Case cmbMotoukeCode.Name
                '元請
                Using f As New WinFormBase.SEARCH_TOKUI(0)
                    f.Owner = Me
                    If f.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        If f.SelectItem IsNot Nothing Then
                            LastFocusedControl.Text = f.SelectItem.Code

                            cmbTanatoCode.Focus()
                            Return
                        Else
                            LastFocusedControl.Focus()
                        End If
                    End If
                End Using

            Case cmbTanatoCode.Name
                '担当者
                Using f As New WinFormBase.SEARCH_TANTO(0)
                    f.Owner = Me
                    If f.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        If f.SelectItem IsNot Nothing Then
                            '担当者コードセット
                            LastFocusedControl.Text = f.SelectItem.Code

                            txtChakkouDateST.Focus()
                            Return
                        Else
                            LastFocusedControl.Focus()
                        End If
                    End If
                End Using
        End Select
    End Sub

    ''' <summary>
    ''' 照会ボタン押下
    ''' </summary>
    Private Sub SearchMeisai()
        '入力チェック
        If Not InputErrorCheck() Then Return

        '明細データの取得
        Dim dt As New dsBUK0002.dbgMeisaiDataTable
        Dim dt2 As New dsBUK0002.dbgMeisaiDataTable

        If rdoList.Checked Then
            '一覧の場合
            dt = daBUK0002.GetMeisai(Me, SENCOL_ON, PCNAME, PROGRAM_ID, daBUK0002.SearchKbnLatLng.NONE)

        Else
            '地図の場合
            dt = daBUK0002.GetMeisai(Me, SENCOL_ON, PCNAME, PROGRAM_ID, daBUK0002.SearchKbnLatLng.VALUE_EXIST)
            dt2 = daBUK0002.GetMeisai(Me, SENCOL_ON, PCNAME, PROGRAM_ID, daBUK0002.SearchKbnLatLng.VALUE_NONE)
        End If

        '存在しない場合、処理終了
        If dt.Rows.Count = 0 AndAlso dt2.Rows.Count = 0 Then
            dbgMEISAI.SetDataBinding(dt, "", True)
            MessageBoxEx.Show(CommonUtility.MessageCode_Arg0.M009該当データがありません, PROGRAM_NAME)
            Exit Sub
        End If

        '検索件数が上限以上のメッセージ
        If dt.Rows.Count <> 0 Then
            Dim row = CType(dt.Rows(0), dsBUK0002.dbgMeisaiRow)
            If row.RECODE_COUNT > row.RECODE_COUNT_JYOGEN Then
                MessageBoxEx.Show(CommonUtility.MessageCode_Arg2.M211, row.RECODE_COUNT.ToString, row.RECODE_COUNT_JYOGEN.ToString, PROGRAM_NAME)
            End If
        End If

        If rdoList.Checked Then
            '一覧の場合
            dbgMEISAI.SetDataBinding(dt, "", True)

        Else
            '地図の場合

            '検索件数が0件のメッセージ
            If dt.Rows.Count = 0 Then
                MessageBoxEx.Show(CommonUtility.MessageCode_Arg0.M233, PROGRAM_NAME)
            End If

            'MAP0001の呼び出し用のパラメータ
            requestMAP0001 = New requestMAP0001

            'マーカー
            Dim idx = 0
            Dim makerList(dt.Rows.Count - 1) As requestMAP0001.Maker

            For Each row As dsBUK0002.dbgMeisaiRow In dt
                makerList(idx) = New requestMAP0001.Maker
                makerList(idx).BUKKEN_NO = row.BUKKENNO
                makerList(idx).BUKKEN_NAME = row.BUKKENNAME
                makerList(idx).POST_NO = row.POSTNO
                makerList(idx).ADDRESS = row.KOUJIBASYO
                makerList(idx).LAT = row.LAT
                makerList(idx).LNG = row.LNG

                idx += 1
            Next
            requestMAP0001.MAKER_LIST = makerList

            '緯度・経度未登録一覧
            idx = 0
            Dim bukkenNoneLatLng(dt2.Rows.Count - 1) As requestMAP0001.BukkenNoneLatLng

            For Each row As dsBUK0002.dbgMeisaiRow In dt2
                bukkenNoneLatLng(idx) = New requestMAP0001.BukkenNoneLatLng
                bukkenNoneLatLng(idx).BUKKEN_NO = row.BUKKENNO
                bukkenNoneLatLng(idx).JYOTAI = row.JYOTAI
                bukkenNoneLatLng(idx).BUKKEN_NAME = row.BUKKENNAME
                bukkenNoneLatLng(idx).KOUJI_BASYO = row.KOUJIBASYO
                bukkenNoneLatLng(idx).MOTOUKE = row.MOTOUKE
                bukkenNoneLatLng(idx).CHAKKOU_DATE = row.CHAKKOUDATE
                bukkenNoneLatLng(idx).KANKOU_DATE = row.KANKOUDATE
                bukkenNoneLatLng(idx).TANTO_NAME = row.TANTONAME
                bukkenNoneLatLng(idx).RECODE_COUNT_JYOGEN = row.RECODE_COUNT_JYOGEN
                bukkenNoneLatLng(idx).RECODE_COUNT = row.RECODE_COUNT

                idx += 1
            Next
            requestMAP0001.BUKKEN_NONE_LAT_LNG_LIST = dt2

            '地図画面の表示
            Dim f As New frmMAP0001(frmMAP0001.emumDispKbn.BUKKEN_KENSAKU)
            f.requestMAP0001 = requestMAP0001
            f.ShowDispDialog(Me)
        End If
    End Sub

    ''' <summary>
    ''' 入力チェック
    ''' </summary>
    Private Function InputErrorCheck() As Boolean
        Dim CheckResult As Nullable(Of Boolean)

        '状態
        CheckResult = InputErrorCheck_Control(cmbJyotai, 99999)
        If CheckResult.HasValue Then Return CheckResult.Value
        '物件名
        CheckResult = InputErrorCheck_Control(txtBukkenName, 99999)
        If CheckResult.HasValue Then Return CheckResult.Value
        '工事場所
        CheckResult = InputErrorCheck_Control(txtKoujiBasyo, 99999)
        If CheckResult.HasValue Then Return CheckResult.Value
        '元請
        CheckResult = InputErrorCheck_Control(cmbMotoukeCode, 99999)
        If CheckResult.HasValue Then Return CheckResult.Value
        '担当者
        CheckResult = InputErrorCheck_Control(cmbTanatoCode, 99999)
        If CheckResult.HasValue Then Return CheckResult.Value
        '着工日
        CheckResult = InputErrorCheck_Control(txtChakkouDateST, 99999)
        If CheckResult.HasValue Then Return CheckResult.Value

        If Not NUCheck(txtChakkouDateST.Text) Then
            '文字数チェック
            If txtChakkouDateST.Text.Length <> 4 Then
                MessageBoxEx.Show(MessageCode_Arg1.M021の桁数が小さすぎます, txtChakkouDateST.DisplayName, FindForm.Text)
                txtChakkouDateST.Focus()
                Return False
            End If
            '形式チェック
            If CDec(txtChakkouDateST.Text) < 1900 OrElse CDec(txtChakkouDateST.Text) > 2099 Then
                MessageBoxEx.Show(MessageCode_Arg1.M017を確認して下さい, txtChakkouDateST.DisplayName, FindForm.Text)
                txtChakkouDateST.Focus()
                Return False
            End If
        End If

        CheckResult = InputErrorCheck_Control(txtChakkouDateED, 99999)
        If CheckResult.HasValue Then Return CheckResult.Value

        If Not NUCheck(txtChakkouDateED.Text) Then
            '文字数チェック
            If txtChakkouDateED.Text.Length <> 4 Then
                MessageBoxEx.Show(MessageCode_Arg1.M021の桁数が小さすぎます, txtChakkouDateED.DisplayName, FindForm.Text)
                txtChakkouDateED.Focus()
                Return False
            End If
            '形式チェック
            If CDec(txtChakkouDateED.Text) < 1900 OrElse CDec(txtChakkouDateED.Text) > 2099 Then
                MessageBoxEx.Show(MessageCode_Arg1.M017を確認して下さい, txtChakkouDateED.DisplayName, FindForm.Text)
                txtChakkouDateED.Focus()
                Return False
            End If
        End If

        '範囲チェック
        If Not NUCheck(txtChakkouDateST.Text) AndAlso Not NUCheck(txtChakkouDateED.Text) Then
            If RangeValidator.ValidateMe(txtChakkouDateST.DisplayName, txtChakkouDateST, txtChakkouDateED) = False Then
                txtChakkouDateST.Focus()
                Return False
            End If
        End If

        Return True
    End Function

    ''' <summary>
    ''' グリッド初期化
    ''' </summary>
    Public Sub InitGrid(ByVal form As WinFormBase.FormBase, ByVal dbgMEISAI As C1TrueDBGrid)

        With dbgMEISAI
            .DataView = DataViewEnum.Normal
            .LinesPerRow = 0

            If .Columns.Count = 0 Then
                '***** 共通 *****
                With .Columns
                    .Add(New C1DataColumn("", FLD_SENTAKU, Type.GetType("System.String")))
                    .Add(New C1DataColumn("", FLD_JYOTAI, Type.GetType("System.String")))
                    .Add(New C1DataColumn("", FLD_SYONIN_JYUTYU, Type.GetType("System.String")))
                    .Add(New C1DataColumn("", FLD_SYONIN_HATTYU, Type.GetType("System.String")))
                    .Add(New C1DataColumn("", FLD_BUKKENNO, Type.GetType("System.Decimal")))
                    .Add(New C1DataColumn("", FLD_BUKKENNAME, Type.GetType("System.String")))
                    .Add(New C1DataColumn("", FLD_KOUJIBASYO, Type.GetType("System.String")))
                    .Add(New C1DataColumn("", FLD_MOTOUKE, Type.GetType("System.String")))
                    .Add(New C1DataColumn("", FLD_CHAKKOUDATE, Type.GetType("System.String")))
                    .Add(New C1DataColumn("", FLD_KANKOUDATE, Type.GetType("System.String")))
                    .Add(New C1DataColumn("", FLD_TANTONAME, Type.GetType("System.Decimal")))
                End With
            End If

            '*** TrueDBGrid NumberFormat プロパティ設定 ***
            '.Columns(COL_TANTONAME).NumberFormat = "#,##0円"

            '*** TrueDBGrid Caption プロパティ設定 ***
            .Columns(COL_SENTAKU).Caption = ""
            .Columns(COL_SYONIN_JYUTYU).Caption = "受注" & vbCrLf & "承認"
            .Columns(COL_SYONIN_HATTYU).Caption = "発注" & vbCrLf & "承認"
            .Columns(COL_JYOTAI).Caption = "状態"
            .Columns(COL_BUKKENNO).Caption = "物件No"
            .Columns(COL_BUKKENNAME).Caption = "物件名"
            .Columns(COL_KOUJIBASYO).Caption = "工事場所"
            .Columns(COL_MOTOUKE).Caption = "元請"
            .Columns(COL_CHAKKOUDATE).Caption = "着工日"
            .Columns(COL_KANKOUDATE).Caption = "完工日"
            .Columns(COL_TANTONAME).Caption = "担当者"

            .RecordSelectors = False 'レコードセレクタ非表示（グリッド左側）

            With .Splits(0)
                For intIndex As Integer = 0 To dbgMEISAI.Columns.Count - 1
                    .DisplayColumns(intIndex).Visible = CType(IIf(intIndex < COL_COUNT + 1, True, False), Boolean)
                Next
            End With

            '*** 共通設定 ***
            GridSetup(dbgMEISAI, GridSetupAllows.AllowReadOnly, False, False, False)

            .Splits(0).HeadingStyle.WrapText = True                                       'ヘッダー項目折り返し
            .Splits(0).ColumnCaptionHeight = .Splits(0).ColumnCaptionHeight + 10          'ヘッダー高さ

            With .Splits(0)
                '*** TrueDBGrid Width プロパティ設定 ***
                .DisplayColumns(COL_SENTAKU).Width = 50
                .DisplayColumns(COL_SYONIN_JYUTYU).Width = 40
                .DisplayColumns(COL_SYONIN_HATTYU).Width = 40
                .DisplayColumns(COL_JYOTAI).Width = 40
                .DisplayColumns(COL_BUKKENNO).Width = 90
                .DisplayColumns(COL_BUKKENNAME).Width = 200
                .DisplayColumns(COL_KOUJIBASYO).Width = 200
                .DisplayColumns(COL_MOTOUKE).Width = 80
                .DisplayColumns(COL_CHAKKOUDATE).Width = 80
                .DisplayColumns(COL_KANKOUDATE).Width = 80
                .DisplayColumns(COL_TANTONAME).Width = 96
            End With

            '個別の設定はGridSetupの後

            '全般
            .EditDropDown = False                                               '編集にドロップダウンウインドウを使用するか？

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
            .HeadingStyle.Font = New Font("メイリオ", 8, FontStyle.Regular, GraphicsUnit.Point, 128)

            '*** TrueDBGrid HeadingStyle.HorizontalAlignment プロパティ設定 ***
            For intIndex As Integer = 0 To dbgMEISAI.Columns.Count - 1
                .Splits(0).DisplayColumns(intIndex).HeadingStyle.HorizontalAlignment = AlignHorzEnum.Near
            Next

            '*** TrueDBGrid ColumnDivider.Style プロパティ設定 ***
            For intIndex As Integer = 0 To dbgMEISAI.Columns.Count - 1
                .Splits(0).DisplayColumns(intIndex).ColumnDivider.Style = LineStyleEnum.None
            Next

            '*** TrueDBGrid Locked プロパティ設定 ***
            For intIndex As Integer = 0 To dbgMEISAI.Columns.Count - 1
                .Splits(0).DisplayColumns(intIndex).Locked = False
            Next

            '*** TrueDBGrid AllowSizing プロパティ設定 ***
            For intI As Integer = 0 To dbgMEISAI.Columns.Count - 1
                .Splits(0).DisplayColumns(intI).AllowSizing = True
            Next intI

            '*** TrueDBGrid FetchStyle プロパティ設定 ***
            For intI As Integer = 0 To dbgMEISAI.Columns.Count - 1
                .Splits(0).DisplayColumns(intI).FetchStyle = True
            Next intI

            '*** TrueDBGrid WrapText プロパティ設定 ***
            For intI As Integer = 0 To dbgMEISAI.Columns.Count - 1
                .Splits(0).DisplayColumns(intI).Style.WrapText = True
            Next intI

            ''*** TrueDBGrid Style.HorizontalAlignment プロパティ設定 ***
            For intIndex As Integer = 0 To dbgMEISAI.Columns.Count - 1
                .Splits(0).DisplayColumns(intIndex).Style.HorizontalAlignment = AlignHorzEnum.Near
            Next
            .Splits(0).DisplayColumns(COL_SENTAKU).Style.HorizontalAlignment = AlignHorzEnum.Center

            .Splits(0).DisplayColumns(COL_SENTAKU).ButtonAlways = True
            .Splits(0).DisplayColumns(COL_SENTAKU).ButtonText = True
            .Splits(0).DisplayColumns(COL_SENTAKU).FetchStyle = True
        End With
    End Sub

    ''' <summary>
    ''' 明細イベント
    ''' </summary>
    Private Sub dbgMEISAI_FetchCellStyle(ByVal sender As Object, ByVal e As FetchCellStyleEventArgs) Handles dbgMEISAI.FetchCellStyle
        Select Case e.Col
            Case COL_SENTAKU
                e.CellStyle.ForeColor = Color.Black
            Case COL_SYONIN_JYUTYU, COL_SYONIN_HATTYU
                If dbgMEISAI(e.Row, e.Col) = "済" Then
                    e.CellStyle.ForeColor = Color.Red
                Else
                    e.CellStyle.ForeColor = Color.Black
                End If
        End Select
    End Sub

    Private Sub dbgMEISAI_ButtonClick(ByVal sender As Object, ByVal e As ColEventArgs) Handles dbgMEISAI.ButtonClick
        Select Case e.ColIndex
            Case COL_SENTAKU
                '選択ボタン
                Dim f = New frmBUK0001()
                f.requestBUK0001.BUKKEN_NO = dbgMEISAI.Columns(COL_BUKKENNO).Value
                f.ShowDisp(Me)
        End Select
    End Sub

    ''' <summary>
    ''' Enterキーイベント
    ''' </summary>
    Private Sub Control_KeyPress(sender As Object, e As KeyPressEventArgs)
        If e.KeyChar <> vbCr Then Return

        Select Case Me.ActiveControl.Name
            Case rdoList.Name, rdoMap.Name
                cmbJyotai.Focus()

            Case rdoSyoninJyuAll.Name, rdoSyoninJyuMi.Name, rdoSyoninJyuSumi.Name
                If rdoSyoninHatAll.Checked Then
                    rdoSyoninHatAll.Focus()
                ElseIf rdoSyoninHatMi.Checked Then
                    rdoSyoninHatMi.Focus()
                Else
                    rdoSyoninHatSumi.Focus()
                End If

            Case rdoSyoninHatAll.Name, rdoSyoninHatMi.Name, rdoSyoninHatSumi.Name
                txtBukkenName.Focus()
        End Select
    End Sub

    ''' <summary>
    ''' コントロール　共通イベント
    ''' </summary>
    Private Sub Control_Enter(sender As Object, e As EventArgs) Handles cmbJyotai.Enter
        Select Case Me.ActiveControl.Name
            Case cmbMotoukeCode.Name, cmbTanatoCode.Name
                FunctionKey.SetItem(9, "検索", "検索", True)

            Case Else
                FunctionKey.SetItem(9, "検索", "検索", False)

        End Select
    End Sub

    Private Sub txtBukkenNo2_TextChanged(sender As Object, e As EventArgs) Handles txtBukkenNo2.TextChanged
        Dim enabled = NUCheck(txtBukkenNo2.Text)

        Panel1.Enabled = enabled
        Panel2.Enabled = enabled
        Panel3.Enabled = enabled
        cmbJyotai.Enabled = enabled
        txtBukkenName.Enabled = enabled
        txtKoujiBasyo.Enabled = enabled
        cmbMotoukeCode.Enabled = enabled
        cmbTanatoCode.Enabled = enabled
        txtChakkouDateST.Enabled = enabled
        txtChakkouDateED.Enabled = enabled
        cmdKMENU.Enabled = enabled
        cmdTMENU.Enabled = enabled
    End Sub
End Class
