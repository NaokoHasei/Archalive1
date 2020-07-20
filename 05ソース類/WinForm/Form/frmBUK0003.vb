
Imports C1.Win.C1TrueDBGrid
Imports CommonUtility.Utility
Imports CommonUtility.WinForm
Imports CommonUtility.WinFormControls
Imports BLL.Common

Public Class frmBUK0003

    Public Overrides Function PROGRAM_ID() As String
        Return "BUK0003"
    End Function

    Public Overrides Function PROGRAM_NAME() As String
        Return "実績一覧"
    End Function

    '--- COLUMNS DATAVALUE
    Private Const FLD_SENTAKU As String = "SENTAKU"                 '選択ボタン
    Private Const FLD_BUKKENNO As String = "BUKKENNO"               '物件No
    Private Const FLD_KOUSHU As String = "KOUSHU"                   '工種
    Private Const FLD_BUKKENNAME As String = "BUKKENNAME"           '物件名
    Private Const FLD_ADDRESS As String = "ADDRESS"                 '工事場所
    Private Const FLD_MOTOUKENAME As String = "MOTOUKENAME"         '元請
    Private Const FLD_CHAKKOUDATE As String = "CHAKKOUDATE"         '着工日
    Private Const FLD_KANKOUDATE As String = "KANKOUDATE"           '完工日
    Private Const FLD_BLANK As String = "BLANK"                     '空白のセル
    Private Const FLD_JYUCHUKINGAKU As String = "JYUCHUKINGAKU"     '受注金額
    Private Const FLD_SHIHARAIGENKA As String = "SHIHARAIGENKA"     '支払金額
    Private Const FLD_ARARIGAKU As String = "ARARIGAKU"             '粗利額
    Private Const FLD_ARARIRITU As String = "ARARIRITU"             '粗利率
    Private Const FLD_SHITAUKEGYOSHA As String = "SHITAUKEGYOSHA"   '下請業者

    '--- COLUMNS INDEX
    Private Const COL_SENTAKU As Integer = 0                        '選択ボタン
    Private Const COL_BUKKENNO As Integer = 1                       '物件No
    Private Const COL_KOUSHU As Integer = 2                         '工種
    Private Const COL_BUKKENNAME As Integer = 3                     '物件名
    Private Const COL_ADDRESS As Integer = 4                        '工事場所
    Private Const COL_BLANK As Integer = 5                          '空白のセル
    Private Const COL_BLANK2 As Integer = 6                         '空白のセル
    Private Const COL_BLANK3 As Integer = 7                         '空白のセル
    Private Const COL_BLANK4 As Integer = 8                         '空白のセル
    Private Const COL_BLANK5 As Integer = 9                         '空白のセル
    Private Const COL_BLANK6 As Integer = 10                        '空白のセル
    Private Const COL_MOTOUKENAME As Integer = 11                   '元請
    Private Const COL_CHAKKOUDATE As Integer = 12                   '着工日
    Private Const COL_KANKOUDATE As Integer = 13                    '完工日
    Private Const COL_JYUCHUKINGAKU As Integer = 14                 '受注金額
    Private Const COL_SHIHARAIGENKA As Integer = 15                 '支払金額
    Private Const COL_ARARIGAKU As Integer = 16                     '粗利額
    Private Const COL_ARARIRITU As Integer = 17                     '粗利率
    Private Const COL_SHITAUKEGYOSHA As Integer = 18                '下請業者
    Private Const COL_BLANK7 As Integer = 19                        '空白のセル
    Private Const COL_COUNT As Integer = 20                         '最大列数

    Public S_SCB_SeachCount As Decimal                              'S_SCB 検索結果の上限

    Private daBUK0003 As daBUK0003
    Private SearchValueBukkenName As String
    Private SearchValueChakkouDateST As String
    Private SearchValueChakkouDateED As String
    Private SearchValueKankouDateST As String
    Private SearchValueKankouDateED As String

    ''' <summary>
    ''' フォームロード
    ''' </summary>
    Protected Overrides Sub Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MyBase.Form_Load(sender, e)

        Using wcur As New WaitCursor
            'データアクセスの初期化
            daBUK0003 = New daBUK0003

            'グリッドの初期化
            InitGrid()

            'ファンクションキーの設定
            FunctionKey.ClearAll()

            FunctionKey.SetItem(1, "終了", "終了", True)
            FunctionKey.SetItem(11, "印刷", "印刷", False)
            FunctionKey.SetItem(12, "照会", "照会", True)

            '画面の初期化
            txtBukkenName.Text = ""
            txtChakkouDateST.Text = ""
            txtChakkouDateED.Text = ""
            txtKankouDateST.Text = ""
            txtKankouDateED.Text = ""
            dbgMEISAI.SetDataBinding(New dsBUK0003.dbgMeisaiDataTable, "", True)

            'S_SCBの読み込み
            '検索結果の上限（一覧）
            Dim S_SCB As New S_SCBRead("検索結果の上限（物件一覧）", "")
            Dim dsS_SCB As dsS_SCB = S_SCB.GetS_SCB

            If dsS_SCB.S_SCB.Count = 0 Then
                S_SCB_SeachCount = ""
            Else
                S_SCB_SeachCount = dsS_SCB.S_SCB(0).DATA
            End If
        End Using
    End Sub

    ''' <summary>
    ''' ファンクションキー　イベント
    ''' </summary>
    Protected Overrides Sub FunctionKeyAction(ByVal sender As System.Object, ByVal e As CommonUtility.WinFormControls.FunctionKeyEventArgs)

        Select Case e.Name

            Case "終了"

                Me.Close()

                Exit Sub

            Case "印刷"
                ExecutePrint()

            Case "照会"
                SearchMeisai()

        End Select

        LastFocusedControl.Focus()

    End Sub

    ''' <summary>
    ''' 印刷ボタン押下
    ''' </summary>
    Private Sub ExecutePrint()
        '明細情報の設定
        Dim dtDETAIL As dsBUK0003_report.DETAILDataTable = New dsBUK0003_report.DETAILDataTable
        Dim drDETAIL As dsBUK0003_report.DETAILRow
        Dim jyuchuKingaku As Decimal = 0
        Dim ShiharaiGenka As Decimal = 0
        Dim araruGaku As Decimal = 0

        For Each row In CType(dbgMEISAI.DataSource, dsBUK0003.dbgMeisaiDataTable)
            drDETAIL = dtDETAIL.NewRow

            drDETAIL.BUKKENNO = row.BUKKENNO
            drDETAIL.BUKKENNAME = row.BUKKENNAME
            drDETAIL.KOUSHU = row.KOUSHU
            drDETAIL.ADDRESS = row.ADDRESS
            drDETAIL.MOTOUKENAME = row.MOTOUKENAME
            drDETAIL.SHITAUKEGYOSHA = row.SHITAUKEGYOSHA
            drDETAIL.JYUCHUKINGAKU = row.JYUCHUKINGAKU
            drDETAIL.SHIHARAIGENKA = row.SHIHARAIGENKA
            drDETAIL.ARARIGAKU = row.ARARIGAKU
            drDETAIL.ARARIRITU = row.ARARIRITU
            drDETAIL.CHAKKOUDATE = row.CHAKKOUDATE
            drDETAIL.KANKOUDATE = row.KANKOUDATE

            dtDETAIL.Rows.Add(drDETAIL)

            If Not NUCheck(row.JYUCHUKINGAKU) Then jyuchuKingaku += row.JYUCHUKINGAKU
            If Not NUCheck(row.SHIHARAIGENKA) Then ShiharaiGenka += row.SHIHARAIGENKA
            If Not NUCheck(row.ARARIGAKU) Then araruGaku += row.ARARIGAKU
        Next

        'ヘッダ情報の設定
        Dim dtHEAD As dsBUK0003_report.HEADDataTable = New dsBUK0003_report.HEADDataTable
        Dim drHEAD As dsBUK0003_report.HEADRow = dtHEAD.NewRow

        drHEAD.JYUCHUKINGAKU_SUM = jyuchuKingaku
        drHEAD.SHIHARAIGENKA_SUM = ShiharaiGenka
        drHEAD.ARARIGAKU_SUM = araruGaku
        drHEAD.ARARIRITU_SUM = 0
        If jyuchuKingaku <> 0 Then
            drHEAD.ARARIRITU_SUM = System.Math.Round((araruGaku) / jyuchuKingaku * 100, 2)
        End If

        dtHEAD.Rows.Add(drHEAD)

        '印刷の実行
        Using rpt As rptBUK0003 = New rptBUK0003(dtHEAD, dtDETAIL, Me.ServerDate)
            rpt.jyokenBukkenName = SearchValueBukkenName
            rpt.jyokenChakkouDateFrom = SearchValueChakkouDateST
            rpt.jyokenChakkouDateTo = SearchValueChakkouDateED
            rpt.jyokenKankouDateFrom = SearchValueKankouDateST
            rpt.jyokenKankouDateTo = SearchValueKankouDateED
            PrintReport(PrintReportMode.Preview, {rpt})
        End Using
    End Sub

    ''' <summary>
    ''' 照会ボタン押下
    ''' </summary>
    Private Sub SearchMeisai()
        '入力チェック
        If Not InputErrorCheck() Then Return

        '明細データの取得
        Dim dt = daBUK0003.GetMeisai(Me)

        '存在しない場合、処理終了
        If dt.Rows.Count = 0 Then
            dbgMEISAI.SetDataBinding(dt, "", True)
            FunctionKey.SetItem(11, "印刷", "印刷", False)
            MessageBoxEx.Show(CommonUtility.MessageCode_Arg0.M009該当データがありません, PROGRAM_NAME)
            Exit Sub
        End If

        If dt.Rows.Count <> 0 Then
            Dim row = CType(dt.Rows(0), dsBUK0003.dbgMeisaiRow)
            If row.RECODE_COUNT > S_SCB_SeachCount Then
                MessageBoxEx.Show(CommonUtility.MessageCode_Arg2.M211, row.RECODE_COUNT.ToString, S_SCB_SeachCount.ToString, PROGRAM_NAME)
            End If
        End If

        '検索条件を保持
        SearchValueBukkenName = txtBukkenName.Text
        SearchValueChakkouDateST = txtChakkouDateST.Text
        SearchValueChakkouDateED = txtChakkouDateED.Text
        SearchValueKankouDateST = txtKankouDateST.Text
        SearchValueKankouDateED = txtKankouDateED.Text

        dbgMEISAI.SetDataBinding(dt, "", True)
        FunctionKey.SetItem(11, "印刷", "印刷", True)

    End Sub

    ''' <summary>
    ''' 入力チェック
    ''' </summary>
    Private Function InputErrorCheck() As Boolean
        Dim CheckResult As Nullable(Of Boolean)

        '物件名
        CheckResult = InputErrorCheck_Control(txtBukkenName, 9999)
        If CheckResult.HasValue Then Return CheckResult.Value

        '着工日
        CheckResult = InputErrorCheck_Control(txtChakkouDateST, 9999)
        If CheckResult.HasValue Then Return CheckResult.Value
        CheckResult = InputErrorCheck_Control(txtChakkouDateED, 9999)
        If CheckResult.HasValue Then Return CheckResult.Value
        '範囲チェック
        If txtChakkouDateST.Text <> "    /  /" And txtChakkouDateED.Text <> "    /  /" Then
            If RangeValidator.ValidateMe(txtChakkouDateST.DisplayName, txtChakkouDateST, txtChakkouDateED) = False Then
                txtChakkouDateST.Focus()
                Return False
            End If
        End If

        '完工日
        CheckResult = InputErrorCheck_Control(txtKankouDateST, 9999)
        If CheckResult.HasValue Then Return CheckResult.Value
        CheckResult = InputErrorCheck_Control(txtKankouDateED, 9999)
        If CheckResult.HasValue Then Return CheckResult.Value
        '範囲チェック
        If txtKankouDateST.Text <> "    /  /" And txtKankouDateED.Text <> "    /  /" Then
            If RangeValidator.ValidateMe(txtKankouDateST.DisplayName, txtKankouDateST, txtKankouDateED) = False Then
                txtKankouDateST.Focus()
                Return False
            End If
        End If

        Return True
    End Function

    ''' <summary>
    ''' グリッド初期化
    ''' </summary>
    Private Sub InitGrid()

        With dbgMEISAI
            .DataView = DataViewEnum.Normal
            .LinesPerRow = 0

            If .Columns.Count = 0 Then
                '***** 共通 *****
                With .Columns
                    .Add(New C1DataColumn("", FLD_SENTAKU, Type.GetType("System.String")))
                    .Add(New C1DataColumn("", FLD_BUKKENNO, Type.GetType("System.String")))
                    .Add(New C1DataColumn("", FLD_KOUSHU, Type.GetType("System.String")))
                    .Add(New C1DataColumn("", FLD_BUKKENNAME, Type.GetType("System.String")))
                    .Add(New C1DataColumn("", FLD_ADDRESS, Type.GetType("System.String")))
                    .Add(New C1DataColumn("", FLD_BLANK, Type.GetType("System.String")))
                    .Add(New C1DataColumn("", FLD_BLANK, Type.GetType("System.String")))
                    .Add(New C1DataColumn("", FLD_BLANK, Type.GetType("System.String")))
                    .Add(New C1DataColumn("", FLD_BLANK, Type.GetType("System.String")))
                    .Add(New C1DataColumn("", FLD_BLANK, Type.GetType("System.String")))
                    .Add(New C1DataColumn("", FLD_BLANK, Type.GetType("System.String")))
                    .Add(New C1DataColumn("", FLD_MOTOUKENAME, Type.GetType("System.String")))
                    .Add(New C1DataColumn("", FLD_CHAKKOUDATE, Type.GetType("System.String")))
                    .Add(New C1DataColumn("", FLD_KANKOUDATE, Type.GetType("System.String")))
                    .Add(New C1DataColumn("", FLD_JYUCHUKINGAKU, Type.GetType("System.String")))
                    .Add(New C1DataColumn("", FLD_SHIHARAIGENKA, Type.GetType("System.String")))
                    .Add(New C1DataColumn("", FLD_ARARIGAKU, Type.GetType("System.String")))
                    .Add(New C1DataColumn("", FLD_ARARIRITU, Type.GetType("System.String")))
                    .Add(New C1DataColumn("", FLD_SHITAUKEGYOSHA, Type.GetType("System.String")))
                    .Add(New C1DataColumn("", FLD_BLANK, Type.GetType("System.String")))
                End With
            End If

            '*** TrueDBGrid NumberFormat プロパティ設定 ***
            .Columns(COL_JYUCHUKINGAKU).NumberFormat = "FormatText Event"
            .Columns(COL_SHIHARAIGENKA).NumberFormat = "FormatText Event"
            .Columns(COL_ARARIGAKU).NumberFormat = "FormatText Event"

            '*** TrueDBGrid Caption プロパティ設定 ***
            .Columns(COL_SENTAKU).Caption = ""
            .Columns(COL_BUKKENNO).Caption = "物件No"
            .Columns(COL_KOUSHU).Caption = "工種"
            .Columns(COL_BUKKENNAME).Caption = "物件名"
            .Columns(COL_ADDRESS).Caption = "工事場所"
            .Columns(COL_MOTOUKENAME).Caption = "元請"
            .Columns(COL_CHAKKOUDATE).Caption = "着工日"
            .Columns(COL_KANKOUDATE).Caption = "完工日"
            .Columns(COL_JYUCHUKINGAKU).Caption = "受注金額"
            .Columns(COL_SHIHARAIGENKA).Caption = "支払金額"
            .Columns(COL_ARARIGAKU).Caption = "粗利額"
            .Columns(COL_ARARIRITU).Caption = "粗利率"
            .Columns(COL_SHITAUKEGYOSHA).Caption = "下請業者"

            .RecordSelectors = False 'レコードセレクタ非表示（グリッド左側）

            With .Splits(0)
                For intIndex As Integer = 0 To dbgMEISAI.Columns.Count - 1
                    .DisplayColumns(intIndex).Visible = CType(IIf(intIndex < COL_COUNT, True, False), Boolean)
                Next
            End With

            '*** 共通設定 ***
            GridSetup(dbgMEISAI, GridSetupAllows.AllowReadOnly, False, False, True)

            With .Splits(0)
                '*** TrueDBGrid Width プロパティ設定 ***
                .DisplayColumns(COL_SENTAKU).Width = 50
                .DisplayColumns(COL_BUKKENNO).Width = 100
                .DisplayColumns(COL_KOUSHU).Width = 200
                .DisplayColumns(COL_BUKKENNAME).Width = 200
                .DisplayColumns(COL_ADDRESS).Width = 447
                .DisplayColumns(COL_BLANK).Width = 0
                .DisplayColumns(COL_BLANK2).Width = 0
                .DisplayColumns(COL_BLANK3).Width = 0
                .DisplayColumns(COL_BLANK4).Width = 0
                .DisplayColumns(COL_BLANK5).Width = 0
                .DisplayColumns(COL_BLANK6).Width = 50
                .DisplayColumns(COL_MOTOUKENAME).Width = 100
                .DisplayColumns(COL_CHAKKOUDATE).Width = 100
                .DisplayColumns(COL_KANKOUDATE).Width = 100
                .DisplayColumns(COL_JYUCHUKINGAKU).Width = 100
                .DisplayColumns(COL_SHIHARAIGENKA).Width = 100
                .DisplayColumns(COL_ARARIGAKU).Width = 100
                .DisplayColumns(COL_ARARIRITU).Width = 100
                .DisplayColumns(COL_SHITAUKEGYOSHA).Width = 247
                .DisplayColumns(COL_BLANK7).Width = 0
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
            .MarqueeStyle = MarqueeEnum.HighlightRow                            '行選択・ハイライト表示
            .BorderStyle = BorderStyle.Fixed3D                                  'タイトルとレコードセレクタの３Ｄ表示
            .RowDivider.Style = LineStyleEnum.None                              '行の境界線スタイル
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
            .Splits(0).DisplayColumns(COL_JYUCHUKINGAKU).HeadingStyle.HorizontalAlignment = AlignHorzEnum.Far
            .Splits(0).DisplayColumns(COL_SHIHARAIGENKA).HeadingStyle.HorizontalAlignment = AlignHorzEnum.Far
            .Splits(0).DisplayColumns(COL_ARARIGAKU).HeadingStyle.HorizontalAlignment = AlignHorzEnum.Far
            .Splits(0).DisplayColumns(COL_ARARIRITU).HeadingStyle.HorizontalAlignment = AlignHorzEnum.Far
            .Splits(0).DisplayColumns(COL_SENTAKU).HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center

            '*** TrueDBGrid ColumnDivider.Style プロパティ設定 ***
            For intIndex As Integer = 0 To dbgMEISAI.Columns.Count - 1
                .Splits(0).DisplayColumns(intIndex).ColumnDivider.Style = LineStyleEnum.None
            Next

            For intIndex As Integer = 0 To dbgMEISAI.Columns.Count - 1
                .Splits(0).DisplayColumns(intIndex).Style.HorizontalAlignment = AlignHorzEnum.Near
            Next
            .Splits(0).DisplayColumns(COL_JYUCHUKINGAKU).Style.HorizontalAlignment = AlignHorzEnum.Far
            .Splits(0).DisplayColumns(COL_SHIHARAIGENKA).Style.HorizontalAlignment = AlignHorzEnum.Far
            .Splits(0).DisplayColumns(COL_ARARIGAKU).Style.HorizontalAlignment = AlignHorzEnum.Far
            .Splits(0).DisplayColumns(COL_ARARIRITU).Style.HorizontalAlignment = AlignHorzEnum.Far
            .Splits(0).DisplayColumns(COL_SENTAKU).Style.HorizontalAlignment = AlignHorzEnum.Center

            '*** TrueDBGrid AllowSizing プロパティ設定 ***
            For intI As Integer = 0 To dbgMEISAI.Columns.Count - 1
                .Splits(0).DisplayColumns(intI).AllowSizing = True
            Next intI

            .Splits(0).DisplayColumns(COL_SENTAKU).ButtonAlways = True
            .Splits(0).DisplayColumns(COL_SENTAKU).ButtonText = True
            .Splits(0).DisplayColumns(COL_SENTAKU).Style.ForeColor = Color.Black
            .Splits(0).DisplayColumns(COL_SENTAKU).FetchStyle = True
        End With
    End Sub

    ''' <summary>
    ''' 明細イベント
    ''' </summary>
    Private Sub dbgMEISAI_FormatText(ByVal sender As Object, ByVal e As FormatTextEventArgs) Handles dbgMEISAI.FormatText

        If Decimal.TryParse(e.Value, 0) = False Then Exit Sub

        Dim dec As Decimal = Decimal.Parse(e.Value)

        With CType(sender, C1TrueDBGrid)
            e.Value = dec.ToString("#,##0")
        End With

    End Sub

    Private Sub dbgMEISAI_FetchCellStyle(ByVal sender As Object, ByVal e As FetchCellStyleEventArgs) Handles dbgMEISAI.FetchCellStyle
        Select Case e.Col
            Case COL_SENTAKU
                e.CellStyle.ForeColor = Color.Black
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
End Class
