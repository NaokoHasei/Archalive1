Imports CommonUtility.WinForm
Imports C1.Win.C1TrueDBGrid

Public Class frmMAP0001_SUB1

    Public Overrides Function PROGRAM_ID() As String
        Return "BUK0002"
    End Function

    Public Overrides Function PROGRAM_NAME() As String
        Return "物件検索（緯度・経度未登録一覧）"
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


    Public requestMAP0001 As New requestMAP0001

    Protected Overrides Sub Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MyBase.Form_Load(sender, e)

        Using wcur As New WaitCursor

            'ファンクションキーの設定
            FunctionKey.ClearAll()

            FunctionKey.SetItem(1, "戻る", "戻る", True)

            'グリッドの初期化
            InitGrid(Me, dbgMEISAI)

            'グリッドの設定
            dbgMEISAI.SetDataBinding(requestMAP0001.BUKKEN_NONE_LAT_LNG_LIST, "", True)
        End Using

    End Sub

    Protected Overrides Sub FunctionKeyAction(ByVal sender As System.Object, ByVal e As CommonUtility.WinFormControls.FunctionKeyEventArgs)

        Select Case e.Name
            Case "戻る"
                Me.Close()

        End Select
    End Sub

    ''' <summary>
    ''' グリッド初期化
    ''' </summary>
    Private Sub InitGrid(ByVal form As WinFormBase.FormBase, ByVal dbgMEISAI As C1TrueDBGrid)

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

    Private Sub dbgMEISAI_ButtonClick(ByVal sender As Object, ByVal e As ColEventArgs) Handles dbgMEISAI.ButtonClick
        Select Case e.ColIndex
            Case COL_SENTAKU
                '選択ボタン
                Dim f = New frmBUK0001()
                f.requestBUK0001.BUKKEN_NO = dbgMEISAI.Columns(COL_BUKKENNO).Value
                f.ShowDisp(Me)
        End Select
    End Sub

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
End Class
