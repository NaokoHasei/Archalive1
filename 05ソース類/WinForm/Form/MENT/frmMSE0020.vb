Imports CommonUtility.WinForm
Imports CommonUtility.WinFormControls
Imports BLL.Common
Imports System.Globalization

Public Class frmMSE0020
    '***** フォーム定数宣言 *****
    Private culture As CultureInfo = New CultureInfo("ja-JP", True)
    Private daMSE0020 As New daMSE0020

    '--- TDBG MAX VALUE
    Private Const COL_COUNT As Integer = 3                     '最大列数

    '--- COLUMNS INDEX
    Private Const COL_CATEGORYID As Integer = 0                 'カテゴリID
    Private Const COL_DATAKEY As Integer = 1                    'データキー
    Private Const COL_DATA As Integer = 2                       'データ
    Private Const COL_COMMENT As Integer = 3                    'コメント

    '--- COLUMNS DATAVALUE
    Private Const FLD_CATEGORYID As String = "CATEGORYID"       'カテゴリ
    Private Const FLD_DATAKEY As String = "DATAKEY"             'データキー
    Private Const FLD_DATA As String = "DATA"                   'データ
    Private Const FLD_COMMENT As String = "COMMENT"             'コメント

    Private blnGridHeadFlg As Boolean                           'グリッドヘッダー部動作制御用フラグ

    '*** 変数宣言 *******************************************************************
    '検索ﾒﾆｭｰ用
    Private intMenuTabIndex As Integer

    Private SortMode As String = "ASC"            '並び替え

    Private blnDataUpdateFLG As Boolean

    Public Overrides Function PROGRAM_ID() As String
        Return "MSE0020"
    End Function

    Public Overrides Function PROGRAM_NAME() As String
        Return "基本設定マスタ登録"
    End Function

    Private ItemSelectedValue As Boolean

    Private Enum enumFormStatus
        KeyInput
        ModeNew
        ModeUpdate
    End Enum

    Public Sub New()
        ' この呼び出しは Windows フォーム デザイナで必要です。 
        InitializeComponent()

        'コマンドライン引数を配列で取得する


    End Sub

    'コンストラクタを用いて、値を受け取る 
    Public Sub New(ByVal Value As String)
        ' この呼び出しは Windows フォーム デザイナで必要です。 
        InitializeComponent()

    End Sub

    Protected Overrides Sub Form_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        MyBase.Form_Load(sender, e)

        culture.DateTimeFormat.Calendar = New JapaneseCalendar()

        Using wcur As New WaitCursor

            'イベント指定
            AddHandler txtCATEGORYID.Enter, AddressOf EnterEventHandler
            AddHandler txtDATAKEY.Enter, AddressOf EnterEventHandler
            AddHandler txtDATA.Enter, AddressOf EnterEventHandler
            AddHandler txtCOMMENT.Enter, AddressOf EnterEventHandler

            'TrueDBGrid初期設定
            Call subInitGrid()

            '画面初期化
            Call subInitDisp()
        End Using

    End Sub

    Private Sub subInitDisp()
        TitleBar.EditMode = EditMode.None

        txtCATEGORYID.Text = ""
        txtDATAKEY.Text = ""
        txtDATA.Text = ""
        txtCOMMENT.Text = ""

        'ファンクションキーの設定
        Call subFunctionKeySettings(enumFormStatus.KeyInput)

        '画面の活性・非活性制御
        subChageColumnEnabled(enumFormStatus.KeyInput)

        'grid読み込み
        fncRead_Main()
    End Sub

    Private Sub EnterEventHandler(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If CType(sender, Control).CausesValidation = False Then
            Return
        End If

        If fncInputErrorCheck(CType(sender, Control), GetTabOrder(CType(sender, Control))) = False Then
            Return
        End If
    End Sub

    Private Sub subFunctionKeySettings(ByVal FormStatus As enumFormStatus)
        FunctionKey.ClearAll()

        If FormStatus = enumFormStatus.KeyInput Then
            Me.FunctionKey.SetItem(1, "終了", "終了", True)
            Me.FunctionKey.SetItem(11, "コピー新規", "コピー" & vbCrLf & "新規", True, New System.Drawing.Font("メイリオ", 9))
            Me.FunctionKey.SetItem(12, "新規", "新規", True)
        ElseIf FormStatus = enumFormStatus.ModeNew Then
            Me.FunctionKey.SetItem(1, "取消", "取消", True)
            Me.FunctionKey.SetItem(3, "削除", "削除", False)
            Me.FunctionKey.SetItem(12, "登録", "登録", True)
        Else
            Me.FunctionKey.SetItem(1, "取消", "取消", True)
            Me.FunctionKey.SetItem(3, "削除", "削除", True)
            Me.FunctionKey.SetItem(12, "登録", "登録", True)
        End If
    End Sub

    Private Sub subChageColumnEnabled(ByVal FormStatus As enumFormStatus)
        If FormStatus = enumFormStatus.KeyInput Then
            dbgMEISAI.Enabled = True

            txtCATEGORYID.Enabled = False
            txtDATAKEY.Enabled = False
            txtDATA.Enabled = False
            txtCOMMENT.Enabled = False
        Else
            dbgMEISAI.Enabled = False

            txtCATEGORYID.Enabled = True
            txtDATAKEY.Enabled = True
            txtDATA.Enabled = True
            txtCOMMENT.Enabled = True
        End If
    End Sub

    ''' <summary>
    ''' 入力チェック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="tabOrder"></param>
    ''' <remarks></remarks>
    Private Function fncInputErrorCheck(ByVal sender As System.Windows.Forms.Control, ByVal tabOrder As Integer) As Boolean
        Dim CheckResult As Nullable(Of Boolean)

        'カテゴリID
        CheckResult = InputErrorCheck_Control(txtCATEGORYID, tabOrder)
        If CheckResult.HasValue Then Return CheckResult.Value

        'データキー
        CheckResult = InputErrorCheck_Control(txtDATAKEY, tabOrder)
        If CheckResult.HasValue Then Return CheckResult.Value

        'データ
        CheckResult = InputErrorCheck_Control(txtDATA, tabOrder)
        If CheckResult.HasValue Then Return CheckResult.Value

        'コメント
        CheckResult = InputErrorCheck_Control(txtCOMMENT, tabOrder)
        If CheckResult.HasValue Then Return CheckResult.Value

        Return True

    End Function

    Protected Overrides Sub FunctionKeyAction(ByVal sender As System.Object, ByVal e As FunctionKeyEventArgs)

        Select Case e.Name

            Case "終了"

                Me.Close()

            Case "コピー新規"

                Call ExeuteCopyNew()

            Case "新規"

                Call ExeuteNew()

            Case "取消"

                If MessageBoxEx.Show(CommonUtility.MessageCode_Arg0.M003取消してもよろしいですか, PROGRAM_NAME) = Windows.Forms.DialogResult.No Then Return

                '画面初期化
                Call subInitDisp()

            Case "削除"

                Call ExeuteDelete()

            Case "登録"

                Call ExeuteRegist()

        End Select
    End Sub

    ''' <summary>
    ''' コピー新規ボタン押下処理
    ''' </summary>
    Private Sub ExeuteCopyNew()
        'グリッドの情報を入力項目に反映
        subDisplayCurrentData()

        '新規モードを表示
        changeModeNew()

        txtCATEGORYID.Focus()
    End Sub

    ''' <summary>
    ''' 新規ボタン押下処理
    ''' </summary>
    Private Sub ExeuteNew()
        txtCATEGORYID.Text = ""
        txtDATAKEY.Text = ""
        txtDATA.Text = ""
        txtCOMMENT.Text = ""

        '新規モードを表示
        changeModeNew()

        txtCATEGORYID.Focus()
    End Sub

    ''' <summary>
    ''' 削除ボタン押下処理
    ''' </summary>
    Private Sub ExeuteDelete()

        If MessageBoxEx.Show(CommonUtility.MessageCode_Arg0.M002削除してもよろしいですか, PROGRAM_NAME) = Windows.Forms.DialogResult.No Then Return

        'グリッドの情報を取得
        Dim strCATEGORYID As String = dbgMEISAI.Columns(COL_CATEGORYID).Value.ToString
        Dim strDATAKEY As String = dbgMEISAI.Columns(COL_DATAKEY).Value.ToString
        Dim strDATA As String = dbgMEISAI.Columns(COL_DATA).Value.ToString

        '削除処理
        Dim logicMSE0020 As New daMSE0020
        logicMSE0020.DeleteData(strCATEGORYID, strDATAKEY, strDATA)

        '画面初期化
        Call subInitDisp()
    End Sub

    ''' <summary>
    ''' 登録ボタン押下処理
    ''' </summary>
    Private Sub ExeuteRegist()
        Dim logicMSE0020 As New daMSE0020

        '入力チェック
        If Not fncInputErrorCheck(Nothing, 9999999) Then Return

        'キー重複チェック
        If TitleBar.EditMode = EditMode.Create Then
            Dim S_SCB As S_SCBRead = New S_SCBRead(txtCATEGORYID.Text, txtDATAKEY.Text, txtDATA.Text)
            Dim dt As dsS_SCB.S_SCBDataTable = S_SCB.GetS_SCB.S_SCB

            If dt.Rows.Count <> 0 Then
                MessageBoxEx.Show(CommonUtility.MessageCode_Arg1.M023既に登録されています, "「カテゴリID、データキー、データ」が重複するデータが", PROGRAM_NAME)
                Return
            End If
        End If

        If MessageBoxEx.Show(CommonUtility.MessageCode_Arg0.M001登録してもよろしいですか, PROGRAM_NAME) = Windows.Forms.DialogResult.No Then Return

        Select Case TitleBar.EditMode
            Case EditMode.Create
                '追加
                logicMSE0020.InsertData(
                      txtCATEGORYID.Text _
                    , txtDATAKEY.Text _
                    , txtDATA.Text _
                    , txtCOMMENT.Text _
                    , PROGRAM_ID _
                    , TANTO_CODE)

            Case EditMode.Edit
                '更新

                'グリッドの情報を取得
                Dim gyoNo As Integer = dbgMEISAI.Row
                Dim strCATEGORYID As String = dbgMEISAI(gyoNo, COL_CATEGORYID).ToString
                Dim strDATAKEY As String = dbgMEISAI(gyoNo, COL_DATAKEY).ToString
                Dim strDATA As String = dbgMEISAI(gyoNo, COL_DATA).ToString

                logicMSE0020.UpdateData(
                      txtCATEGORYID.Text _
                    , txtDATAKEY.Text _
                    , txtDATA.Text _
                    , txtCOMMENT.Text _
                    , PROGRAM_ID _
                    , TANTO_CODE _
                    , strCATEGORYID _
                    , strDATAKEY _
                    , strDATA)
        End Select

        '画面初期化
        Call subInitDisp()
    End Sub

    Private Sub changeModeNew()
        TitleBar.EditMode = EditMode.Create

        'ファンクションキーの設定
        Call subFunctionKeySettings(enumFormStatus.ModeNew)

        '画面の活性・非活性制御
        subChageColumnEnabled(enumFormStatus.ModeNew)
    End Sub

    ''' <summary>
    ''' grid読み込み
    ''' </summary>
    ''' <remarks></remarks>
    Private Function fncRead_Main() As Boolean
        Dim blnRet As Boolean
        Dim ds As DataSet

        On Error GoTo fncRead_Main_Err

        fncRead_Main = False '戻り値初期化


        'ﾌﾗｸﾞ初期化
        blnRet = False

        ds = daMSE0020.fncReadS_SCB()

        If ds.Tables(0).Rows.Count = 0 Then
            GoTo fncRead_Main_Exit
        End If

        'ｸﾞﾘｯﾄﾞ再読み込み
        If Not fncGridSet(ds) Then
            GoTo fncRead_Main_Exit
        End If

        dbgMEISAI.Enabled = True

        fncRead_Main = True

fncRead_Main_Exit:

        Exit Function

fncRead_Main_Err:

        MessageBox.Show(Err.Number & "：" & Err.Description, PROGRAM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Stop)

        GoTo fncRead_Main_Exit

    End Function

    ''' <summary>
    ''' グリッド表示
    ''' </summary>
    ''' <remarks></remarks>
    Private Function fncGridSet(ByVal ds As DataSet) As Boolean

        On Error GoTo fncGridSet_Err

        fncGridSet = False

        If ds.Tables(0).Rows.Count <> 0 Then

            dbgMEISAI.SetDataBinding(Nothing, "", True)

            Dim dt As DataTable = CType(ds.Tables(0), DataTable)

            dbgMEISAI.SetDataBinding(dt, "", True)

            ds = Nothing

            dbgMEISAI.MoveFirst()
        End If

        fncGridSet = True

        Exit Function

fncGridSet_Err:
        MessageBox.Show(Err.Number & "：" & Err.Description, PROGRAM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

    End Function

    ''' <summary>
    ''' カレントレコード表示
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub subDisplayCurrentData()
        Dim gyoNo As Integer = dbgMEISAI.Row

        txtCATEGORYID.Text = dbgMEISAI(gyoNo, COL_CATEGORYID).ToString
        txtDATAKEY.Text = dbgMEISAI(gyoNo, COL_DATAKEY).ToString
        txtDATA.Text = dbgMEISAI(gyoNo, COL_DATA).ToString
        txtCOMMENT.Text = dbgMEISAI(gyoNo, COL_COMMENT).ToString
    End Sub

    Private Sub dbgMEISAI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dbgMEISAI.Click
        blnGridHeadFlg = False
    End Sub

    Private Sub dbgMEISAI_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dbgMEISAI.DoubleClick
        If blnGridHeadFlg = False Then
            Call subDisplayCurrentData()

            TitleBar.EditMode = EditMode.Edit

            'ファンクションキーの設定
            Call subFunctionKeySettings(enumFormStatus.ModeUpdate)

            '画面の活性・非活性制御
            subChageColumnEnabled(enumFormStatus.ModeUpdate)
        End If
    End Sub

    Private Sub dbgMEISAI_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles dbgMEISAI.HeadClick

        If dbgMEISAI.RowCount = 0 Then Exit Sub

        blnGridHeadFlg = True

        '*** マウスポインタ砂時計 ***
        Using wcur As New WaitCursor

            Dim view As DataView = CType(dbgMEISAI.DataSource, DataTable).DefaultView

            Select Case e.ColIndex
                Case COL_CATEGORYID
                    view.Sort = FLD_CATEGORYID & " " & SortMode
                Case COL_DATAKEY
                    view.Sort = FLD_DATAKEY & " " & SortMode
                Case COL_DATA
                    view.Sort = FLD_DATA & " " & SortMode
                Case COL_COMMENT
                    view.Sort = FLD_COMMENT & " " & SortMode
            End Select

            dbgMEISAI.Update()
            dbgMEISAI.Refresh()

            If SortMode = "DESC" Then
                SortMode = "ASC"
            Else
                SortMode = "DESC"
            End If

        End Using

    End Sub

    Private Sub subInitGrid()

        With dbgMEISAI
            .DataView = C1.Win.C1TrueDBGrid.DataViewEnum.Normal
            .LinesPerRow = 0

            If .Columns.Count = 0 Then
                '***** 共通 *****
                With .Columns
                    .Add(New C1.Win.C1TrueDBGrid.C1DataColumn("", FLD_CATEGORYID, Type.GetType("System.String")))
                    .Add(New C1.Win.C1TrueDBGrid.C1DataColumn("", FLD_DATAKEY, Type.GetType("System.String")))
                    .Add(New C1.Win.C1TrueDBGrid.C1DataColumn("", FLD_DATA, Type.GetType("System.String")))
                    .Add(New C1.Win.C1TrueDBGrid.C1DataColumn("", FLD_COMMENT, Type.GetType("System.String")))
                End With
            End If

            '*** TrueDBGrid Caption プロパティ設定 ***
            .Columns(COL_CATEGORYID).Caption = "カテゴリＩＤ"
            .Columns(COL_DATAKEY).Caption = "データキー"
            .Columns(COL_DATA).Caption = "データ"
            .Columns(COL_COMMENT).Caption = "コメント"

            .Columns(COL_CATEGORYID).DataWidth = 16
            .Columns(COL_DATAKEY).DataWidth = 16
            .Columns(COL_DATA).DataWidth = 64
            .Columns(COL_COMMENT).DataWidth = 256

            .RecordSelectors = False 'レコードセレクタ非表示（グリッド左側）


            With .Splits(0)
                For intIndex As Integer = 0 To dbgMEISAI.Columns.Count - 1
                    .DisplayColumns(intIndex).Visible = CType(IIf(intIndex < COL_COUNT + 1, True, False), Boolean)
                Next
            End With

            '*** 共通設定 ***
            GridSetup(dbgMEISAI, GridSetupAllows.AllowReadOnly, False, False, False)

            With .Splits(0)
                '*** TrueDBGrid Width プロパティ設定 ***
                '１段目
                .DisplayColumns(COL_CATEGORYID).Width = (20 + 4) * 8
                .DisplayColumns(COL_DATAKEY).Width = (10 + 4) * 8
                .DisplayColumns(COL_DATA).Width = (30 + 4) * 8
                .DisplayColumns(COL_COMMENT).Width = (32 + 4) * 8

            End With

            '個別の設定はGridSetupの後

            '全般
            .EditDropDown = False                   '編集にドロップダウンウインドウを使用するか？
            .AllowColMove = False
            .AllowColSelect = False
            .AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
            .AllowRowSelect = False

            '表示
            .ColumnHeaders = True                                               '列タイトルの表示
            .MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow        '行選択・ハイライト表示
            .BorderStyle = BorderStyle.Fixed3D                                  'タイトルとレコードセレクタの３Ｄ表示
            .RowDivider.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.None          '行の境界線スタイル
            .FetchRowStyles = True                                              'FetchRowStyleイベントを発生させるかどうかを設定
            .Font = New System.Drawing.Font("メイリオ", 8.25!, FontStyle.Regular, GraphicsUnit.Point, 128)
            .ExtendRightColumn = True

            'Splits 単位
            .Splits(0).HScrollBar.Style = C1.Win.C1TrueDBGrid.ScrollBarStyleEnum.None
            .Splits(0).VScrollBar.Style = C1.Win.C1TrueDBGrid.ScrollBarStyleEnum.Always
            .Splits(0).AllowFocus = True

            '*** ヘッダー ***
            '仕切り線

            .HeadingStyle.Borders.BorderType = C1.Win.C1TrueDBGrid.BorderTypeEnum.None
            .HeadingStyle.Font = New System.Drawing.Font("メイリオ", 8.25!, FontStyle.Regular, GraphicsUnit.Point, 128)

            '*** TrueDBGrid HeadingStyle.HorizontalAlignment プロパティ設定 ***
            For intIndex As Integer = 0 To dbgMEISAI.Columns.Count - 1
                .Splits(0).DisplayColumns(intIndex).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
            Next
            .Splits(0).DisplayColumns(COL_CATEGORYID).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
            .Splits(0).DisplayColumns(COL_DATAKEY).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
            .Splits(0).DisplayColumns(COL_DATA).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
            .Splits(0).DisplayColumns(COL_COMMENT).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near

            '*** TrueDBGrid Style.HorizontalAlignment プロパティ設定 ***
            For intIndex As Integer = 0 To dbgMEISAI.Columns.Count - 1
                .Splits(0).DisplayColumns(intIndex).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
            Next
            .Splits(0).DisplayColumns(COL_CATEGORYID).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
            .Splits(0).DisplayColumns(COL_DATAKEY).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
            .Splits(0).DisplayColumns(COL_DATA).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
            .Splits(0).DisplayColumns(COL_COMMENT).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near

        End With

    End Sub
End Class