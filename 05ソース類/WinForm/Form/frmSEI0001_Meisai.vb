Imports CommonUtility.WinForm
Imports CommonUtility.Utility
Imports CommonUtility.WinFormControls
Imports C1.Win.C1TrueDBGrid
Imports CommonUtility
Imports BLL.Common

Public Class frmSEI0001_Meisai

    'メインフォーム明細グリッド列名
    Public Const FLD_SEIKYU_FLG As String = "SEIKYU_FLG"
    Public Const FLD_KAMOKU_HINMOKU As String = "KAMOKU_HINMOKU"
    Public Const FLD_HINSITU_KIKAKU_SIYO As String = "HINSITU_KIKAKU_SIYO"
    Public Const FLD_TANI As String = "TANI"
    Public Const FLD_JYUTYUSUU As String = "JYUTYUSUU"
    Public Const FLD_JYUTYUSUU_HENKO As String = "JYUTYUSUU_HENKO"
    Public Const FLD_JYUTYUTANKA As String = "JYUTYUTANKA"
    Public Const FLD_JYUTYUGAKU As String = "JYUTYUGAKU"
    Public Const FLD_JYUTYUGAKU_HENKO As String = "JYUTYUGAKU_HENKO"
    Public Const FLD_SEIKYUSUU_ZENKAI As String = "SEIKYUSUU_ZENKAI"
    Public Const FLD_SEIKYUGAKU_ZENKAI As String = "SEIKYUGAKU_ZENKAI"
    Public Const FLD_SEIKYUSUU_KONKAI As String = "SEIKYUSUU_KONKAI"
    Public Const FLD_SEIKYUGAKU_KONKAI As String = "SEIKYUGAKU_KONKAI"
    Public Const FLD_SEIKYUSUU_RUIKEI As String = "SEIKYUSUU_RUIKEI"
    Public Const FLD_SEIKYUGAKU_RUIKEI As String = "SEIKYUGAKU_RUIKEI"
    Public Const FLD_KAISOCODE As String = "KAISOCODE"
    Public Const FLD_KAISOCODE_ZENKAI As String = "KAISOCODE_ZENKAI"
    Public Const FLD_DELETE_FLG As String = "DELETE_FLG"

    Public Const COL_SIZE_SEIKYU_FLG As Integer = 4 * 8
    Public Const COL_SIZE_MEISYO As Integer = 14 * 8
    Public Const COL_SIZE_TANI As Integer = 5 * 8
    Public Const COL_SIZE_SUU As Integer = 6 * 8
    Public Const COL_SIZE_TANKA As Integer = 8 * 8 - 2
    Public Const COL_SIZE_KINGAKU As Integer = 9 * 8 + 4
    Public Const COL_SIZE_BORDER As Integer = 2

    Private T_SEIKYU As New T_SEIKYURead

    '明細部列番号
    Public Enum COL
        SEIKYU_FLG
        KAMOKU_HINMOKU
        HINSITU_KIKAKU_SIYO
        TANI
        JYUTYUSUU
        JYUTYUSUU_HENKO
        JYUTYUTANKA
        JYUTYUGAKU
        JYUTYUGAKU_HENKO
        SEIKYUSUU_ZENKAI
        SEIKYUGAKU_ZENKAI
        SEIKYUSUU_KONKAI
        SEIKYUGAKU_KONKAI
        SEIKYUSUU_RUIKEI
        SEIKYUGAKU_RUIKEI
        KAISOCODE
        KAISOCODE_ZENKAI
        DELETE_FLG
    End Enum

    Private editMode As EditMode
    Private parentFormSEI0001 As frmSEI0001
    Private dtT_SEIKYU_MEISAI As dsSEI0001.T_SEIKYU_MEISAIDataTable

    Private strS_SCB_ROUND_MITSUURYO As String
    Private strDialogResult As String
    Private blnDbgKeyCtrlFlg As Boolean     'KeyDown()で判定、KeyPress()でTrueの場合キーを無効に
    Private strFuncBtnTyoseikin As String
    Private strFuncBtnTyoseikinName As String

    Public Overrides Function PROGRAM_ID() As String
        Return "SEI0001"
    End Function

    Public Overrides Function PROGRAM_NAME() As String
        Return "請求登録"
    End Function

    Public Sub New(ByVal editModeParent As EditMode, ByVal parentForm As frmSEI0001, dtT_SEIKYU_MEISAI_Parent As dsSEI0001.T_SEIKYU_MEISAIDataTable)

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。
        parentFormSEI0001 = parentForm
        editMode = editModeParent
        dtT_SEIKYU_MEISAI = dtT_SEIKYU_MEISAI_Parent

        '数量の丸め
        Dim S_SCB = New S_SCBRead("SYSTEM", "ROUND_MITSUURYO")
        Dim dsS_SCB = S_SCB.GetS_SCB
        strS_SCB_ROUND_MITSUURYO = Decimal.Parse(dsS_SCB.S_SCB(0).DATA)
    End Sub

    Protected Overrides Sub Form_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        MyBase.Form_Load(sender, e)

        Using wcur As New WaitCursor

            TitleBar.EditMode = editMode

            'イベントの定義
            AddHandler chkSeikyuAll.CheckedChanged, AddressOf chkSeikyuAll_CheckedChanged

            'グリッドの初期化
            subInitGrid()

            dtT_SEIKYU_MEISAI = parentFormSEI0001.dtT_SEIKYU_MEISAI.Copy

            dbgMEISAI.SetDataBinding(dtT_SEIKYU_MEISAI, "", True)

            '合計の計算
            CalcGoueki()

            '全て請求の初期化
            ChnageChkSeikyuAll()

            '表示制御
            Dim enabeld = IIf(editMode = EditMode.Create OrElse editMode = EditMode.Edit, True, False)
            chkSeikyuAll.Enabled = enabeld

            '調整金のボタン名の設定
            strFuncBtnTyoseikin = parentFormSEI0001.strS_SCB_TYOSEIGAKU + "追加"
            strFuncBtnTyoseikinName = parentFormSEI0001.strS_SCB_TYOSEIGAKU + vbCrLf + "追加"

            'ファンクションキー設定
            subFunctionKeySettings()
        End Using

        chkSeikyuAll.Focus()
    End Sub

    ''' <summary>
    ''' ファンクションキー設定
    ''' </summary>
    Private Sub subFunctionKeySettings()

        FunctionKey.ClearAll()

        FunctionKey.SetItem(1, "戻る", "戻る", True)

        If editMode = EditMode.Create OrElse editMode = EditMode.Edit Then
            '調整金が追加されている場合、非活性にする。
            Dim dr = CType(dbgMEISAI.DataSource, dsSEI0001.T_SEIKYU_MEISAIDataTable).Select("KAISOCODE_DAIKAMOKU = 999")
            If dr.Count = 0 Then
                FunctionKey.SetItem(9, strFuncBtnTyoseikin, strFuncBtnTyoseikinName, True, FunctionKey.FONT_SMALL)
            Else
                FunctionKey.SetItem(9, strFuncBtnTyoseikin, strFuncBtnTyoseikinName, False, FunctionKey.FONT_SMALL)
            End If

            FunctionKey.SetItem(12, "登録", "登録", True)
        End If
    End Sub

    ''' <summary>
    ''' ファンクションキー押下時イベント
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub FunctionKeyAction(ByVal sender As System.Object, ByVal e As CommonUtility.WinFormControls.FunctionKeyEventArgs)

        Select Case e.Name

            Case "戻る"

                Me.Close()

            Case strFuncBtnTyoseikin
                '調整金の追加処理
                Dim dt = CType(dbgMEISAI.DataSource, dsSEI0001.T_SEIKYU_MEISAIDataTable)
                Dim dr = CType(dt.NewRow, dsSEI0001.T_SEIKYU_MEISAIRow)
                dr.SEIKYU_FLG = False
                dr.KAMOKU_HINMOKU = parentFormSEI0001.strS_SCB_TYOSEIGAKU
                dr.HINSITU_KIKAKU_SIYO = ""
                dr.TANI = ""
                dr.JYUTYUSUU = ""
                dr.JYUTYUTANKA = ""
                dr.JYUTYUGAKU = ""
                dr.JYUTYUSUU_HENKO = ""
                dr.JYUTYUGAKU_HENKO = ""
                dr.SEIKYUSUU_ZENKAI = ""
                dr.SEIKYUGAKU_ZENKAI = "0"
                dr.SEIKYUSUU_KONKAI = ""
                dr.SEIKYUGAKU_KONKAI = "0"
                dr.SEIKYUSUU_RUIKEI = ""
                dr.SEIKYUGAKU_RUIKEI = "0"
                dr.KAISOCODE = "999"
                dr.KAISOCODE_ZENKAI = "0"
                dr.DELETE_FLG = "0"
                dr.JYUTYUEDABAN = parentFormSEI0001.txtJyutyuEdaban.Text
                dr.JYUTYUEDABAN_DAIKAMOKU = parentFormSEI0001.txtJyutyuEdaban.Text
                dr.KAISOCODE_DAIKAMOKU = "999"
                dr.KAMOKU_HINMOKU_DAIKAMOKU = ""
                dr.GROUP_HEADER = ""
                dt.Rows.Add(dr)
                dbgMEISAI.SetDataBinding(dt, "", True)
                dbgMEISAI.Refresh()

                'ファンクションキー設定
                subFunctionKeySettings()

            Case "登録"
                If CommonUtility.WinForm.MessageBoxEx.Show(CommonUtility.MessageCode_Arg0.M001登録してもよろしいですか, PROGRAM_NAME) = Windows.Forms.DialogResult.No Then Return

                '呼び出し元に明細情報を返却
                dbgMEISAI.Update()
                dtT_SEIKYU_MEISAI.AcceptChanges()
                parentFormSEI0001.dtT_SEIKYU_MEISAI = dtT_SEIKYU_MEISAI.Copy

                '呼び出し元に保留金を返却
                Dim horyukin = CType(dtT_SEIKYU_MEISAI.Rows(0), dsSEI0001.T_SEIKYU_MEISAIRow).SEIKYUGAKU_KONKAI

                '外税以外の場合、消費税を加算する
                If parentFormSEI0001.strS_SCB_ROUND_ZEIKBN = "0" Then
                    horyukin = horyukin + parentFormSEI0001.CalcSyohizei(horyukin)
                End If

                parentFormSEI0001.txtHoryukin.Value = horyukin * (-1)

                '戻り処理の呼び出し
                parentFormSEI0001.SEI0001_Meisai_return(strDialogResult)

                Me.Close()
        End Select
    End Sub

    ''' <summary>
    ''' グリッド設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub subInitGrid()

        With dbgMEISAI

            Dim co As New C1DataColumn("請求", FLD_SEIKYU_FLG, Type.GetType("System.Boolean"))
            co.ValueItems.Presentation = PresentationEnum.CheckBox

            '***** 共通 *****
            With .Columns
                .Add(co)
                .Add(New C1DataColumn("名称", FLD_KAMOKU_HINMOKU, Type.GetType("System.String")))
                .Add(New C1DataColumn("規格", FLD_HINSITU_KIKAKU_SIYO, Type.GetType("System.String")))
                .Add(New C1DataColumn("単位", FLD_TANI, Type.GetType("System.String")))
                .Add(New C1DataColumn("数量", FLD_JYUTYUSUU, Type.GetType("System.String")))
                .Add(New C1DataColumn("変更数量", FLD_JYUTYUSUU_HENKO, Type.GetType("System.String")))
                .Add(New C1DataColumn("単価", FLD_JYUTYUTANKA, Type.GetType("System.String")))
                .Add(New C1DataColumn("金額", FLD_JYUTYUGAKU, Type.GetType("System.String")))
                .Add(New C1DataColumn("変更金額", FLD_JYUTYUGAKU_HENKO, Type.GetType("System.String")))
                .Add(New C1DataColumn("数量", FLD_SEIKYUSUU_ZENKAI, Type.GetType("System.String")))
                .Add(New C1DataColumn("金額", FLD_SEIKYUGAKU_ZENKAI, Type.GetType("System.String")))
                .Add(New C1DataColumn("数量", FLD_SEIKYUSUU_KONKAI, Type.GetType("System.String")))
                .Add(New C1DataColumn("金額", FLD_SEIKYUGAKU_KONKAI, Type.GetType("System.String")))
                .Add(New C1DataColumn("数量", FLD_SEIKYUSUU_RUIKEI, Type.GetType("System.String")))
                .Add(New C1DataColumn("金額", FLD_SEIKYUGAKU_RUIKEI, Type.GetType("System.String")))
                .Add(New C1DataColumn("", FLD_KAISOCODE, Type.GetType("System.String")))
                .Add(New C1DataColumn("", FLD_KAISOCODE_ZENKAI, Type.GetType("System.String")))
                .Add(New C1DataColumn("", FLD_DELETE_FLG, Type.GetType("System.Decimal")))
            End With

            '*** TrueDBGrid DataWidth プロパティ設定 ***
            .Columns(COL.SEIKYUSUU_KONKAI).DataWidth = 11
            .Columns(COL.SEIKYUGAKU_KONKAI).DataWidth = 12

            .InsertHorizontalSplit(1)
            .InsertHorizontalSplit(2)
            .InsertHorizontalSplit(3)
            .InsertHorizontalSplit(4)

            '*** 共通設定 ***
            GridSetup(dbgMEISAI, GridSetupAllows.AllowAll, False, False, False)

            For intSplitsCount = 0 To .Splits.Count - 1
                With .Splits(intSplitsCount)
                    '*** TrueDBGrid Width プロパティ設定 ***
                    .DisplayColumns(COL.SEIKYU_FLG).Width = COL_SIZE_SEIKYU_FLG
                    .DisplayColumns(COL.KAMOKU_HINMOKU).Width = COL_SIZE_MEISYO
                    .DisplayColumns(COL.HINSITU_KIKAKU_SIYO).Width = COL_SIZE_MEISYO
                    .DisplayColumns(COL.TANI).Width = COL_SIZE_TANI
                    .DisplayColumns(COL.JYUTYUSUU).Width = COL_SIZE_SUU
                    .DisplayColumns(COL.JYUTYUSUU_HENKO).Width = COL_SIZE_SUU
                    .DisplayColumns(COL.JYUTYUTANKA).Width = COL_SIZE_TANKA
                    .DisplayColumns(COL.JYUTYUGAKU).Width = COL_SIZE_KINGAKU
                    .DisplayColumns(COL.JYUTYUGAKU_HENKO).Width = COL_SIZE_KINGAKU
                    .DisplayColumns(COL.SEIKYUSUU_ZENKAI).Width = COL_SIZE_SUU
                    .DisplayColumns(COL.SEIKYUGAKU_ZENKAI).Width = COL_SIZE_KINGAKU
                    .DisplayColumns(COL.SEIKYUSUU_KONKAI).Width = COL_SIZE_SUU
                    .DisplayColumns(COL.SEIKYUGAKU_KONKAI).Width = COL_SIZE_KINGAKU
                    .DisplayColumns(COL.SEIKYUSUU_RUIKEI).Width = COL_SIZE_SUU
                    .DisplayColumns(COL.SEIKYUGAKU_RUIKEI).Width = COL_SIZE_KINGAKU

                    '*** TrueDBGrid AllowFocus プロパティ設定 ***
                    For i As Integer = 0 To dbgMEISAI.Columns.Count - 1
                        .DisplayColumns(i).AllowFocus = False
                    Next
                    '新規もしくは、修正/削除の場合、編集可とする
                    If editMode = EditMode.Create OrElse editMode = EditMode.Edit Then
                        .DisplayColumns(COL.SEIKYU_FLG).AllowFocus = True
                        .DisplayColumns(COL.SEIKYUSUU_KONKAI).AllowFocus = True
                        .DisplayColumns(COL.SEIKYUGAKU_KONKAI).AllowFocus = True
                    End If

                    ''*** TrueDBGrid Style.HorizontalAlignment プロパティ設定 ***
                    For intIndex As Integer = 0 To dbgMEISAI.Columns.Count - 1
                        .DisplayColumns(intIndex).Style.HorizontalAlignment = AlignHorzEnum.Far
                    Next
                    .DisplayColumns(COL.SEIKYU_FLG).Style.HorizontalAlignment = AlignHorzEnum.General
                    .DisplayColumns(COL.KAMOKU_HINMOKU).Style.HorizontalAlignment = AlignHorzEnum.General
                    .DisplayColumns(COL.HINSITU_KIKAKU_SIYO).Style.HorizontalAlignment = AlignHorzEnum.General
                    .DisplayColumns(COL.TANI).Style.HorizontalAlignment = AlignHorzEnum.General

                    '*** TrueDBGrid Visible プロパティ設定 ***
                    For i As Integer = 0 To dbgMEISAI.Columns.Count - 1
                        .DisplayColumns(i).Visible = False
                    Next

                    .VerticalScrollGroup = 0

                    'Splits 単位
                    .HScrollBar.Style = ScrollBarStyleEnum.None
                    .VScrollBar.Style = ScrollBarStyleEnum.Automatic
                    .AllowFocus = True
                    .Locked = False
                    .MarqueeStyle = MarqueeEnum.FloatingEditor                    'スプリットのﾏｰｷｰｽﾀｲﾙ(選択行・セルの設定)

                    .CaptionStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
                    .CaptionStyle.Font = New Font("メイリオ", 9)
                    .CaptionStyle.BackColor = Color.DarkSlateBlue
                    .CaptionStyle.ForeColor = Color.White
                    .CaptionStyle.HorizontalAlignment = AlignHorzEnum.Center
                    .CaptionHeight = 30

                    If parentFormSEI0001.strS_SCB_ROUND_ZEIKBN = "0" Then
                        .ColumnFooterHeight = 60
                    Else
                        .ColumnFooterHeight = 30
                    End If

                    .AllowHorizontalSizing = False
                    .AllowVerticalSizing = False
                    .SpringMode = False
                    .SplitSizeMode = SizeModeEnum.Exact         'SplitSizeをピクセルで指定

                    '*** TrueDBGrid HeadingStyle.HorizontalAlignment プロパティ設定 ***
                    For intIndex As Integer = 0 To dbgMEISAI.Columns.Count - 1
                        .DisplayColumns(intIndex).HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
                    Next

                    '*** TrueDBGrid ColumnDivider.Style プロパティ設定 ***
                    For intIndex As Integer = 0 To dbgMEISAI.Columns.Count - 1
                        .DisplayColumns(intIndex).ColumnDivider.Color = Color.FromArgb(224, 224, 224)
                    Next

                    '*** TrueDBGrid Locked プロパティ設定 ***
                    For intIndex As Integer = 0 To dbgMEISAI.Columns.Count - 1
                        .DisplayColumns(intIndex).Locked = False
                    Next

                    '*** TrueDBGrid AllowSizing プロパティ設定 ***
                    For intI As Integer = 0 To dbgMEISAI.Columns.Count - 1
                        .DisplayColumns(intI).AllowSizing = True
                    Next intI

                    '*** TrueDBGrid FetchStyle プロパティ設定 ***
                    For intI As Integer = 0 To dbgMEISAI.Columns.Count - 1
                        .DisplayColumns(intI).FetchStyle = True
                    Next intI

                    '*** TrueDBGrid WrapText プロパティ設定 ***
                    For intI As Integer = 0 To dbgMEISAI.Columns.Count - 1
                        .DisplayColumns(intI).Style.WrapText = True
                    Next intI

                    .DisplayColumns(COL.JYUTYUGAKU).FooterStyle.HorizontalAlignment = AlignHorzEnum.Far
                    .DisplayColumns(COL.SEIKYUGAKU_ZENKAI).FooterStyle.HorizontalAlignment = AlignHorzEnum.Far
                    .DisplayColumns(COL.SEIKYUGAKU_KONKAI).FooterStyle.HorizontalAlignment = AlignHorzEnum.Far
                    .DisplayColumns(COL.SEIKYUGAKU_RUIKEI).FooterStyle.HorizontalAlignment = AlignHorzEnum.Far
                End With
            Next

            With .Splits(0)
                .Caption = " "
                .SplitSize = COL_SIZE_SEIKYU_FLG + COL_SIZE_MEISYO + COL_SIZE_MEISYO + COL_SIZE_TANI + (COL_SIZE_BORDER * 3)
                .DisplayColumns(COL.SEIKYU_FLG).Visible = True
                .DisplayColumns(COL.KAMOKU_HINMOKU).Visible = True
                .DisplayColumns(COL.HINSITU_KIKAKU_SIYO).Visible = True
                .DisplayColumns(COL.TANI).Visible = True
            End With

            With .Splits(1)
                .Caption = "契約金額"
                .SplitSize = COL_SIZE_SUU + COL_SIZE_SUU + COL_SIZE_TANKA + COL_SIZE_KINGAKU + COL_SIZE_KINGAKU + (COL_SIZE_BORDER * 4)
                .DisplayColumns(COL.JYUTYUSUU).Visible = True
                .DisplayColumns(COL.JYUTYUSUU_HENKO).Visible = True
                .DisplayColumns(COL.JYUTYUTANKA).Visible = True
                .DisplayColumns(COL.JYUTYUGAKU).Visible = True
                .DisplayColumns(COL.JYUTYUGAKU_HENKO).Visible = True
            End With

            With .Splits(2)
                .Caption = "前回累計出来高"
                .SplitSize = COL_SIZE_SUU + COL_SIZE_KINGAKU + (COL_SIZE_BORDER * 1)
                .DisplayColumns(COL.SEIKYUSUU_ZENKAI).Visible = True
                .DisplayColumns(COL.SEIKYUGAKU_ZENKAI).Visible = True
            End With

            With .Splits(3)
                .Caption = "今回出来高"
                .SplitSize = COL_SIZE_SUU + COL_SIZE_KINGAKU + (COL_SIZE_BORDER * 1)
                .DisplayColumns(COL.SEIKYUSUU_KONKAI).Visible = True
                .DisplayColumns(COL.SEIKYUGAKU_KONKAI).Visible = True
            End With

            With .Splits(4)
                .Caption = "今回累計出来高"
                .SplitSize = COL_SIZE_SUU + COL_SIZE_KINGAKU + (COL_SIZE_BORDER * 1) + 18
                .DisplayColumns(COL.SEIKYUSUU_RUIKEI).Visible = True
                .DisplayColumns(COL.SEIKYUGAKU_RUIKEI).Visible = True
            End With

            '個別の設定はGridSetupの後

            '全般
            .AllowAddNew = False                                '新規レコード追加可能(True:可，False:不可)
            .AllowDelete = False                                'レコード削除可能　　(True:可，False:不可)
            .AllowUpdate = True                                 'レコード更新可能　　(True:可，False:不可)
            .EditDropDown = False                               '編集にドロップダウンウインドウを使用するか？
            .Enabled = True

            .AllowColMove = False
            .AllowColSelect = False
            .AllowRowSizing = RowSizingEnum.None
            .AllowRowSelect = False

            '表示
            .ColumnHeaders = True                                                   '列タイトルの表示
            .MarqueeStyle = MarqueeEnum.FloatingEditor                              '行選択・ハイライト表示
            .BorderStyle = BorderStyle.FixedSingle                                  'グリッドの境界線スタイル
            .RowDivider.Style = LineStyleEnum.Single                                '行の境界線スタイル
            .RowDivider.Color = Color.FromArgb(224, 224, 224)
            .FetchRowStyles = True                                                  'FetchRowStyleイベントを発生させるかどうかを設定
            .Font = New Font("ＭＳ ゴシック", 9, FontStyle.Regular, GraphicsUnit.Point, 128)
            .ExtendRightColumn = False                                               'デッドエリア（隙間）を埋める
            .AlternatingRows = False
            .RecordSelectors = False 'レコードセレクタ非表示（グリッド左側）

            .ContextMenuStrip = New ContextMenuStrip

            '*** ヘッダー ***
            '仕切り線
            .HeadingStyle.Borders.Color = Color.FromArgb(224, 224, 224)
            .HeadingStyle.Font = New Font("メイリオ", 8, FontStyle.Regular, GraphicsUnit.Point, 128)

            '*** TrueDBGrid NumberFormat プロパティ設定 ***
            For i As Integer = 0 To dbgMEISAI.Columns.Count - 1
                Select Case i
                    Case COL.JYUTYUSUU, COL.JYUTYUSUU_HENKO, COL.SEIKYUSUU_ZENKAI, COL.SEIKYUSUU_KONKAI, COL.SEIKYUSUU_RUIKEI _
                       , COL.JYUTYUTANKA, COL.JYUTYUGAKU, COL.JYUTYUGAKU_HENKO, COL.SEIKYUGAKU_ZENKAI, COL.SEIKYUGAKU_KONKAI, COL.SEIKYUGAKU_RUIKEI, COL.KAISOCODE_ZENKAI
                        .Columns(i).NumberFormat = "FormatText Event"
                End Select
            Next

            '*** フッター ***
            .ColumnFooters = True                                                   '列タイトルの表示
            .FooterStyle.Borders.Color = Color.FromArgb(224, 224, 224)
            .FooterStyle.Font = New Font("メイリオ", 8, FontStyle.Regular, GraphicsUnit.Point, 128)
            .FooterStyle.BackColor = Color.DarkSlateBlue
            .FooterStyle.ForeColor = Color.White
            If parentFormSEI0001.strS_SCB_ROUND_ZEIKBN = "0" Then
                .Columns(COL.KAMOKU_HINMOKU).FooterText = "小計" & vbCrLf & "消費税" & vbCrLf & "合計"
            Else
                .Columns(COL.KAMOKU_HINMOKU).FooterText = "合計"
            End If

        End With
    End Sub

    Private Sub dbgMEISAI_FormatText(ByVal sender As Object, ByVal e As FormatTextEventArgs) Handles dbgMEISAI.FormatText

        If Decimal.TryParse(e.Value, 0) = False Then Exit Sub

        Dim dec As Decimal = Decimal.Parse(e.Value)

        'フォーマットの設定
        With CType(sender, C1TrueDBGrid)
            Select Case e.ColIndex
                Case COL.JYUTYUSUU, COL.JYUTYUSUU_HENKO, COL.SEIKYUSUU_ZENKAI, COL.SEIKYUSUU_KONKAI, COL.SEIKYUSUU_RUIKEI
                    '数量の場合
                    dec = GetRoundValue(dec.ToString, parentFormSEI0001.lblSyosu.Text)
                    Select Case CInt(parentFormSEI0001.lblSyosu.Text)
                        Case 0 : e.Value = dec.ToString("#,##0")
                        Case Else : e.Value = dec.ToString("#,##0." & StrDup(CInt(parentFormSEI0001.lblSyosu.Text), "0"))
                    End Select

                Case COL.JYUTYUTANKA, COL.JYUTYUGAKU, COL.JYUTYUGAKU_HENKO, COL.SEIKYUGAKU_ZENKAI, COL.SEIKYUGAKU_KONKAI, COL.SEIKYUGAKU_RUIKEI, COL.KAISOCODE_ZENKAI
                    '金額の場合
                    e.Value = dec.ToString("#,##0")
            End Select
        End With
    End Sub

    Private Function GetRoundValue(ByVal obj As String, ByVal syosu As String) As Decimal
        Return clsMIT0001.CnvToDecimalPoint(obj, syosu, strS_SCB_ROUND_MITSUURYO)
    End Function

    Private Sub dbgMEISAI_FetchCellStyle(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchCellStyleEventArgs) Handles dbgMEISAI.FetchCellStyle

        '背景色の変更（入力不可で初期化）
        e.CellStyle.BackColor = Color.FromArgb(236, 233, 216)

        Select Case e.Col
            Case COL.SEIKYU_FLG
                '保証金の場合
                If dbgMEISAI(e.Row, COL.KAISOCODE) = "0" Then Return

                '調整額の場合
                If dbgMEISAI(e.Row, COL.KAISOCODE) = "999" Then Return

                '削除行の場合
                If dbgMEISAI(e.Row, COL.DELETE_FLG) = "1" Then Return

                e.CellStyle.BackColor = Color.White
            Case COL.SEIKYUSUU_KONKAI
                '保証金の場合
                If dbgMEISAI(e.Row, COL.KAISOCODE) = "0" Then Return

                '調整額の場合
                If dbgMEISAI(e.Row, COL.KAISOCODE) = "999" Then Return

                '削除行の場合
                If dbgMEISAI(e.Row, COL.DELETE_FLG) = "1" Then Return

                '請求がチェックされている場合
                If dbgMEISAI(e.Row, COL.SEIKYU_FLG) = True Then Return

                e.CellStyle.BackColor = Color.White

            Case COL.SEIKYUGAKU_KONKAI
                '削除行の場合
                If dbgMEISAI(e.Row, COL.DELETE_FLG) = "1" Then Return

                '請求がチェックされている場合
                If dbgMEISAI(e.Row, COL.SEIKYU_FLG) = True Then Return

                e.CellStyle.BackColor = Color.White
        End Select
    End Sub

    Private Sub dbgMEISAI_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles dbgMEISAI.KeyPress
        '*** キー入力無効制御 ***
        Select Case dbgMEISAI.Col
            Case COL.SEIKYU_FLG
                '保証金の場合
                If dbgMEISAI.Columns(COL.KAISOCODE).Value = "0" Then e.KeyChar = CChar("")

                '調整額の場合
                If dbgMEISAI.Columns(COL.KAISOCODE).Value = "999" Then e.KeyChar = CChar("")

                '削除行の場合
                If dbgMEISAI.Columns(COL.DELETE_FLG).Value = "1" Then e.KeyChar = CChar("")

                '入力不可文字の場合
                If blnDbgKeyCtrlFlg Then
                    e.KeyChar = CChar("")
                    blnDbgKeyCtrlFlg = False
                End If

            Case COL.SEIKYUSUU_KONKAI
                '保証金の場合
                If dbgMEISAI.Columns(COL.KAISOCODE).Value = "0" Then e.KeyChar = CChar("")

                '調整額の場合
                If dbgMEISAI.Columns(COL.KAISOCODE).Value = "999" Then e.KeyChar = CChar("")

                '削除行の場合
                If dbgMEISAI.Columns(COL.DELETE_FLG).Value = "1" Then e.KeyChar = CChar("")

                '請求がチェックされている場合
                If dbgMEISAI.Columns(COL.SEIKYU_FLG).Value = True Then e.KeyChar = CChar("")

                '入力不可文字の場合
                If blnDbgKeyCtrlFlg Then
                    e.KeyChar = CChar("")
                    blnDbgKeyCtrlFlg = False
                End If

            Case COL.SEIKYUGAKU_KONKAI
                '削除行の場合
                If dbgMEISAI.Columns(COL.DELETE_FLG).Value = "1" Then e.KeyChar = CChar("")

                '請求がチェックされている場合
                If dbgMEISAI.Columns(COL.SEIKYU_FLG).Value = True Then e.KeyChar = CChar("")

                '入力不可文字の場合
                If blnDbgKeyCtrlFlg Then
                    e.KeyChar = CChar("")
                    blnDbgKeyCtrlFlg = False
                End If
        End Select
    End Sub

    Private Sub dbgMEISAI_RowColChange(ByVal sender As Object, ByVal e As RowColChangeEventArgs) Handles dbgMEISAI.RowColChange
        With dbgMEISAI
            Select Case .Col
                Case COL.SEIKYUSUU_KONKAI, COL.SEIKYUGAKU_KONKAI
                    .ImeMode = Windows.Forms.ImeMode.Disable
            End Select

            For Each ctrl As Control In .Controls
                If TypeOf ctrl Is TextBox Then
                    ctrl.ImeMode = .ImeMode
                End If
            Next
        End With
    End Sub

    Private Sub dbgMEISAI_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles dbgMEISAI.KeyDown

        Select Case dbgMEISAI.Col

            '数量
            Case COL.SEIKYUSUU_KONKAI
                '数値以外の入力を無効にする
                blnDbgKeyCtrlFlg = False
                If e.KeyCode >= Keys.LButton And e.KeyCode <= Keys.Help Then            '=== 色々キーコード
                ElseIf e.KeyCode >= Keys.D0 And e.KeyCode <= Keys.D9 Then               '=== ０～９キー
                ElseIf e.KeyCode >= Keys.NumPad0 And e.KeyCode <= Keys.NumPad9 Then     '=== テンキー
                ElseIf e.KeyCode = Keys.NumLock Then                                  '=== NumLockキー
                ElseIf e.KeyCode = Keys.Decimal Then                                  '=== 小数点
                ElseIf e.KeyCode = Keys.Subtract Then                                 '=== マイナスキー
                Else
                    blnDbgKeyCtrlFlg = True
                End If

            '金額
            Case COL.SEIKYUGAKU_KONKAI
                '数値以外の入力を無効にする
                blnDbgKeyCtrlFlg = False
                If e.KeyCode >= Keys.LButton And e.KeyCode <= Keys.Help Then            '=== 色々キーコード
                ElseIf e.KeyCode >= Keys.D0 And e.KeyCode <= Keys.D9 Then               '=== ０～９キー
                ElseIf e.KeyCode >= Keys.NumPad0 And e.KeyCode <= Keys.NumPad9 Then     '=== テンキー
                ElseIf e.KeyCode = Keys.NumLock Then                                  '=== NumLockキー
                ElseIf e.KeyCode = Keys.Subtract Then                                 '=== マイナスキー
                Else
                    blnDbgKeyCtrlFlg = True
                End If
        End Select
    End Sub

    Private Sub dbgMEISAI_Leave(sender As Object, e As EventArgs) Handles dbgMEISAI.Leave
        If dbgMEISAI.SplitIndex <> 3 Then Return

        dbgMEISAI_BeforeColUpdate(Nothing, Nothing)
    End Sub

    Private Sub dbgMEISAI_BeforeColUpdate(ByVal sender As Object, ByVal e As BeforeColUpdateEventArgs) Handles dbgMEISAI.BeforeColUpdate
        If dbgMEISAI.DataSource Is Nothing Then Return

        '削除行は処理しない
        If dbgMEISAI.Columns(COL.DELETE_FLG).Value = "1" Then GoTo CheckError

        Select Case dbgMEISAI.Col
            Case COL.SEIKYU_FLG

                '保証金、調整額は処理しない
                If dbgMEISAI.Columns(COL.KAISOCODE).Value = "0" Then GoTo CheckError
                If dbgMEISAI.Columns(COL.KAISOCODE).Value = "999" Then GoTo CheckError

                If dbgMEISAI.Columns(COL.SEIKYU_FLG).Value = True Then
                    dbgMEISAI.Columns(COL.SEIKYUSUU_KONKAI).Value = CDec(dbgMEISAI.Columns(COL.JYUTYUSUU).Value) - CDec(dbgMEISAI.Columns(COL.SEIKYUSUU_ZENKAI).Value)
                    dbgMEISAI.Columns(COL.SEIKYUGAKU_KONKAI).Value = CDec(dbgMEISAI.Columns(COL.JYUTYUGAKU).Value) - CDec(dbgMEISAI.Columns(COL.SEIKYUGAKU_ZENKAI).Value)
                Else
                    dbgMEISAI.Columns(COL.SEIKYUSUU_KONKAI).Value = "0"
                    dbgMEISAI.Columns(COL.SEIKYUGAKU_KONKAI).Value = "0"
                End If

                dbgMEISAI.Columns(COL.SEIKYUSUU_RUIKEI).Value = CDec(dbgMEISAI.Columns(COL.SEIKYUSUU_ZENKAI).Value) + CDec(dbgMEISAI.Columns(COL.SEIKYUSUU_KONKAI).Value)
                dbgMEISAI.Columns(COL.SEIKYUGAKU_RUIKEI).Value = CDec(dbgMEISAI.Columns(COL.SEIKYUGAKU_ZENKAI).Value) + CDec(dbgMEISAI.Columns(COL.SEIKYUGAKU_KONKAI).Value)

            Case COL.SEIKYUSUU_KONKAI
                '空白チェック
                If NUCheck(dbgMEISAI.Columns(dbgMEISAI.Col).Text) = True Then
                    dbgMEISAI.Columns(dbgMEISAI.Col).Text = "0"
                End If
                '数値チェック
                If Not IsNumeric(dbgMEISAI.Columns(dbgMEISAI.Col).Text) Then
                    MessageBoxEx.Show(MessageCode_Arg1.M019には数字を入力して下さい, "数量", Me.Text)
                    GoTo CheckError
                End If
                '桁数チェック
                If CDec(dbgMEISAI.Columns(dbgMEISAI.Col).Text) > 99999999.999 Then
                    MessageBoxEx.Show(MessageCode_Arg1.M020の桁数が大きすぎます, "数量", Me.Text)
                    GoTo CheckError
                End If

                '保証金、調整額は処理しない
                If dbgMEISAI.Columns(COL.KAISOCODE).Value = "0" Then Return
                If dbgMEISAI.Columns(COL.KAISOCODE).Value = "999" Then Return

                If CDec(dbgMEISAI.Columns(COL.JYUTYUTANKA).Value <> "0") Then
                    dbgMEISAI.Columns(COL.SEIKYUGAKU_KONKAI).Value = GetRoundValue(dbgMEISAI.Columns(COL.SEIKYUSUU_KONKAI).Value, parentFormSEI0001.lblSyosu.Text) * CDec(dbgMEISAI.Columns(COL.JYUTYUTANKA).Value)
                End If

                dbgMEISAI.Columns(COL.SEIKYUSUU_RUIKEI).Value = CDec(dbgMEISAI.Columns(COL.SEIKYUSUU_ZENKAI).Value) + CDec(dbgMEISAI.Columns(COL.SEIKYUSUU_KONKAI).Value)
                dbgMEISAI.Columns(COL.SEIKYUGAKU_RUIKEI).Value = CDec(dbgMEISAI.Columns(COL.SEIKYUGAKU_ZENKAI).Value) + CDec(dbgMEISAI.Columns(COL.SEIKYUGAKU_KONKAI).Value)

                If CDec(dbgMEISAI.Columns(COL.SEIKYUGAKU_RUIKEI).Value) >= CDec(dbgMEISAI.Columns(COL.JYUTYUGAKU).Value) Then
                    dbgMEISAI.Columns(COL.SEIKYU_FLG).Value = True
                End If

            Case COL.SEIKYUGAKU_KONKAI
                '空白チェック
                If NUCheck(dbgMEISAI.Columns(dbgMEISAI.Col).Text) = True Then
                    dbgMEISAI.Columns(dbgMEISAI.Col).Text = "0"
                End If
                '数値チェック
                If Not IsNumeric(dbgMEISAI.Columns(dbgMEISAI.Col).Text) Then
                    MessageBoxEx.Show(MessageCode_Arg1.M019には数字を入力して下さい, "金額", Me.Text)
                    GoTo CheckError
                End If
                '桁数チェック
                If CDec(dbgMEISAI.Columns(dbgMEISAI.Col).Text) > 999999999999 Then
                    MessageBoxEx.Show(MessageCode_Arg1.M020の桁数が大きすぎます, "金額", Me.Text)
                    GoTo CheckError
                End If


                dbgMEISAI.Columns(COL.SEIKYUGAKU_RUIKEI).Value = CDec(dbgMEISAI.Columns(COL.SEIKYUGAKU_ZENKAI).Value) + CDec(dbgMEISAI.Columns(COL.SEIKYUGAKU_KONKAI).Value)

                '調整額、保留金
                If dbgMEISAI.Columns(COL.KAISOCODE).Value = "999" OrElse dbgMEISAI.Columns(COL.KAISOCODE).Value = "0" Then
                    If dbgMEISAI.Columns(COL.SEIKYUGAKU_RUIKEI).Value > 999999999999 Then dbgMEISAI.Columns(COL.SEIKYUGAKU_RUIKEI).Value = 999999999999
                    If dbgMEISAI.Columns(COL.SEIKYUGAKU_RUIKEI).Value < -999999999999 Then dbgMEISAI.Columns(COL.SEIKYUGAKU_RUIKEI).Value = -999999999999
                    Return
                End If

                If CDec(dbgMEISAI.Columns(COL.SEIKYUGAKU_RUIKEI).Value) >= CDec(dbgMEISAI.Columns(COL.JYUTYUGAKU).Value) Then
                    dbgMEISAI.Columns(COL.SEIKYU_FLG).Value = True
                End If
        End Select

        If dbgMEISAI.Columns(COL.SEIKYUGAKU_KONKAI).Value > 999999999999 Then dbgMEISAI.Columns(COL.SEIKYUGAKU_KONKAI).Value = 999999999999
        If dbgMEISAI.Columns(COL.SEIKYUGAKU_RUIKEI).Value > 999999999999 Then dbgMEISAI.Columns(COL.SEIKYUGAKU_RUIKEI).Value = 999999999999

        Exit Sub

CheckError:
        If e Is Nothing Then Return

        e.Cancel = True
    End Sub

    Private Sub dbgMEISAI_AfterColUpdate(sender As Object, e As ColEventArgs) Handles dbgMEISAI.AfterColUpdate
        '合計の計算
        CalcGoueki()

        '全て請求の初期化
        ChnageChkSeikyuAll()
    End Sub

    Private Sub chkSeikyuAll_CheckedChanged(sender As Object, e As EventArgs)
        For Each row In CType(dbgMEISAI.DataSource, dsSEI0001.T_SEIKYU_MEISAIDataTable)

            '保証金は処理しない
            If row.KAISOCODE = "0" Then Continue For

            '調整額は処理しない
            If row.KAISOCODE = "999" Then Continue For

            '削除行は処理しない
            If row.DELETE_FLG = "1" Then Continue For

            row.SEIKYU_FLG = IIf(chkSeikyuAll.Checked, True, False)

            If chkSeikyuAll.Checked Then
                row.SEIKYUSUU_KONKAI = CDec(row.JYUTYUSUU) - CDec(row.SEIKYUSUU_ZENKAI)
                row.SEIKYUGAKU_KONKAI = CDec(row.JYUTYUGAKU) - CDec(row.SEIKYUGAKU_ZENKAI)
            Else
                row.SEIKYUSUU_KONKAI = "0"
                row.SEIKYUGAKU_KONKAI = "0"
            End If

            row.SEIKYUSUU_RUIKEI = CDec(row.SEIKYUSUU_ZENKAI) + CDec(row.SEIKYUSUU_KONKAI)
            row.SEIKYUGAKU_RUIKEI = CDec(row.SEIKYUGAKU_ZENKAI) + CDec(row.SEIKYUGAKU_KONKAI)
        Next

        '合計の計算
        CalcGoueki()

        dbgMEISAI.Refresh()
    End Sub

    Private Sub CalcGoueki()

        Dim dt = parentFormSEI0001.CalcMeisaiGoueki(dbgMEISAI.DataSource)
        Dim dr0 As dsSEI0001.T_SEIKYU_MEISAIRow = dt.Rows(0)

        Dim dr1 As dsSEI0001.T_SEIKYU_MEISAIRow
        Dim dr2 As dsSEI0001.T_SEIKYU_MEISAIRow
        If parentFormSEI0001.strS_SCB_ROUND_ZEIKBN = "0" Then
            dr1 = dt.Rows(1)
            dr2 = dt.Rows(2)

            '戻り値の設定
            strDialogResult = CStr(dr2.SEIKYUGAKU_KONKAI)
        Else
            '使用しないが設定しておく
            dr1 = dr0
            dr2 = dr0

            '戻り値の設定
            strDialogResult = CStr(dr0.SEIKYUGAKU_KONKAI)
        End If

        '合計の表示
        dbgMEISAI.Columns(COL.JYUTYUGAKU).FooterText = DispGoukei(dr0.JYUTYUGAKU, dr1.JYUTYUGAKU, dr2.JYUTYUGAKU)
        dbgMEISAI.Columns(COL.SEIKYUGAKU_ZENKAI).FooterText = DispGoukei(dr0.SEIKYUGAKU_ZENKAI, dr1.SEIKYUGAKU_ZENKAI, dr2.SEIKYUGAKU_ZENKAI)
        dbgMEISAI.Columns(COL.SEIKYUGAKU_KONKAI).FooterText = DispGoukei(dr0.SEIKYUGAKU_KONKAI, dr1.SEIKYUGAKU_KONKAI, dr2.SEIKYUGAKU_KONKAI)
        dbgMEISAI.Columns(COL.SEIKYUGAKU_RUIKEI).FooterText = DispGoukei(dr0.SEIKYUGAKU_RUIKEI, dr1.SEIKYUGAKU_RUIKEI, dr2.SEIKYUGAKU_RUIKEI)
    End Sub

    Private Function DispGoukei(ByVal syokei As Decimal, ByVal syohizei As Decimal, ByVal goukei As Decimal) As String
        If parentFormSEI0001.strS_SCB_ROUND_ZEIKBN = "0" Then
            Return Format(syokei, "#,##0") & vbCrLf & Format(syohizei, "#,##0") & vbCrLf & Format(goukei, "#,##0")
        Else
            Return Format(syokei, "#,##0")
        End If
    End Function

    Private Sub ChnageChkSeikyuAll()

        '全て請求を変更するので、全て請求のイベントを一時削除
        RemoveHandler chkSeikyuAll.CheckedChanged, AddressOf chkSeikyuAll_CheckedChanged

        Dim checkValue = True
        For Each row In CType(dbgMEISAI.DataSource, dsSEI0001.T_SEIKYU_MEISAIDataTable)
            '保証金は処理しない
            If row.KAISOCODE = "0" Then Continue For

            '調整額は処理しない
            If row.KAISOCODE = "999" Then Continue For

            '削除行は処理しない
            If row.DELETE_FLG = "1" Then Continue For

            '未請求額が存在する場合
            If row.SEIKYU_FLG = False Then
                checkValue = False
                Exit For
            End If
        Next

        chkSeikyuAll.Checked = checkValue

        AddHandler chkSeikyuAll.CheckedChanged, AddressOf chkSeikyuAll_CheckedChanged
    End Sub

    Private Sub dbgMEISAI_BeforeColEdit(sender As Object, e As BeforeColEditEventArgs) Handles dbgMEISAI.BeforeColEdit
        '保証金の数量は処理しない
        If dbgMEISAI.Columns(COL.KAISOCODE).Value = "0" AndAlso dbgMEISAI.Col = COL.SEIKYUSUU_KONKAI Then
            e.Cancel = True
        End If

        '調整額の数量は処理しない
        If dbgMEISAI.Columns(COL.KAISOCODE).Value = "999" AndAlso dbgMEISAI.Col = COL.SEIKYUSUU_KONKAI Then
            e.Cancel = True
        End If

        '削除行は処理しない
        If dbgMEISAI.Columns(COL.DELETE_FLG).Value = "1" Then
            e.Cancel = True
        End If

        '未請求額が存在しない場合
        If dbgMEISAI.Columns(COL.SEIKYU_FLG).Value = True AndAlso dbgMEISAI.Col <> COL.SEIKYU_FLG Then
            e.Cancel = True
        End If
    End Sub
End Class
