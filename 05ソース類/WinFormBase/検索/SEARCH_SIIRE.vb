Imports CommonUtility
Imports CommonUtility.WinForm
Imports System.Drawing

Public Class SEARCH_SIIRE
    '***** フォーム定数宣言 *****
    '--- TDBG MAX VALUE
    Private Const COL_COUNT As Integer = 3              '最大列数

    '--- COLUMNS INDEX
    Private Const COL_CODE As Integer = 0               'コード
    Private Const COL_MENUKEY As Integer = 1            'ﾒﾆｭｰｷｰ
    Private Const COL_NAME As Integer = 2               '名称

    '--- COLUMNS DATAVALUE
    Private Const FLD_CODE As String = "CODE"           'コード
    Private Const FLD_MENUKEY As String = "MENUKEY"     'ﾒﾆｭｰｷｰ
    Private Const FLD_NAME As String = "NAME"           '名称

    '*** 変数宣言 *******************************************************************
    'マウスのクリック位置を記憶
    Private mousePoint As Point

    Private intFormHeight As Integer = 0
    Private intFormWidth As Integer = 0
    Private intLocationX As Integer = 0
    Private intLocationY As Integer = 0
    Private intDifference As Integer = 0

    Private SortMode As String = "ASC"            '並び替え

    '*** 配列定義用定数宣言 ***
    Public btnButtonSub As New List(Of Button)

    Public Overrides Function PROGRAM_ID() As String
        Return "SEARCH_SIIRE"
    End Function

    Public Overrides Function PROGRAM_NAME() As String
        Return "業者検索"
    End Function

    Private ItemSelectedValue As Boolean

    'マニュアルは独自に実装
    Private Manual As WinFormControls.Manual

    Protected Overrides Sub Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MyBase.Form_Load(sender, e)

        Using wcur As New WaitCursor

            Manual = New WinFormControls.Manual(btnManual1, PROGRAM_ID)

            'コントロール配列化
            Call subControlSet()

            '画面初期化
            Call subInitDisp()

            'イベント指定
            AddHandler txtINPUTWORD.Enter, AddressOf EnterEventHandler
            For i As Integer = 1 To 12
                AddHandler Button(i).Click, AddressOf Button_Click
            Next
            For i As Integer = 1 To 5
                AddHandler ButtonSub(i).Click, AddressOf ButtonSub_Click
            Next

            txtINPUTWORD.Focus()
        End Using

    End Sub

    ''' <summary>
    ''' 画面初期化
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub subInitDisp()

        'タイトルバー非表示
        '↓2015.07.16 Upd 282_kobayashi 境界線再設定
        'Me.FormBorderStyle = FormBorderStyle.None
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        '↑2015.07.16 Upd 282_kobayashi 境界線再設定
        intFormHeight = Me.Height
        intFormWidth = Me.Width

        '画面表示位置設定
        Call subPotisionSettings()

        For intI As Integer = 0 To btnButtonSub.Count - 1
            btnButtonSub(intI).Text = vbNullString
        Next intI
        '検索サブボタン表示・非表示
        Call subBottonSub_Contorol()

        txtINPUTWORD.Text = vbNullString

        '--- TrueDBGrid初期設定 ---
        Call subInitGrid()

        '--- ファンクションキー設定 ---
        Call subFunctionKeySettings()

    End Sub

    ''' <summary>
    ''' フォーカス取得時イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub EnterEventHandler(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If CType(sender, Control).CausesValidation = False Then
            Return
        End If

        If fncInputErrorCheck(CType(sender, Control), GetTabOrder(CType(sender, Control))) = False Then
            Return
        End If

    End Sub

    ''' <summary>
    ''' 画面表示位置設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub subPotisionSettings()

        Select Case CInt(lblPosition.Text)
            Case 0 '画面中央
                Me.Location = New Point(CInt(Me.Owner.Location.X + (Me.Owner.Width - Me.Width) / 2), CInt(Me.Owner.Location.Y + (Me.Owner.Height - Me.Height) / 2))
            Case 1 '画面左上
                Me.Location = New Point(CInt(Me.Owner.Location.X + 3), CInt(Me.Owner.Location.Y + 25))
            Case 2 '画面右上
                Me.Location = New Point(CInt(Me.Owner.Location.X + (Me.Owner.Width - Me.Width) - 3), CInt(Me.Owner.Location.Y + 25))
            Case 3 '画面左下
                Me.Location = New Point(CInt(Me.Owner.Location.X + 3), CInt(Me.Owner.Location.Y + (Me.Owner.Height - Me.Height) - 66))
            Case 4 '画面右下
                Me.Location = New Point(CInt(Me.Owner.Location.X + (Me.Owner.Width - Me.Width) - 3), CInt(Me.Owner.Location.Y + (Me.Owner.Height - Me.Height) - 66))
        End Select

    End Sub

    ''' <summary>
    ''' ファンクションキー設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub subFunctionKeySettings()

        FunctionKey.ClearAll()

        FunctionKey.SetItem(1, "終了", "終了", True)
        FunctionKey.SetItem(5, "拡大", "拡大", True)
        FunctionKey.SetItem(12, "選択", "選択", True)

    End Sub

    ''' <summary>
    ''' 全項目入力エラーチェック
    ''' </summary>
    ''' <remarks></remarks>
    Public Function fncAllInputValidate() As Boolean
        Return fncInputErrorCheck(Nothing, 9999999)
    End Function

    ''' <summary>
    ''' 入力検査
    ''' </summary>
    ''' <remarks></remarks>
    Private Function fncInputErrorCheck(ByVal sender As Control, ByVal tabOrder As Integer) As Boolean

        Dim CheckResult As Nullable(Of Boolean)

        '手入力
        CheckResult = InputErrorCheck_Control(txtINPUTWORD, tabOrder)
        If CheckResult.HasValue Then Return CheckResult.Value

        Return True

    End Function

    Private Sub subControlSet()

        '配列に格納
        Me.btnButtonSub.Add(Me.ButtonSub1)
        Me.btnButtonSub.Add(Me.ButtonSub2)
        Me.btnButtonSub.Add(Me.ButtonSub3)
        Me.btnButtonSub.Add(Me.ButtonSub4)
        Me.btnButtonSub.Add(Me.ButtonSub5)

    End Sub

    '引数indexに番号を受け取って、その番号が付いたButtonコントロールを返す
    Private Function Button(ByVal index As Integer) As Button

        Dim cs As Control() = Me.Controls.Find("Button" & index.ToString, True)

        Return DirectCast(cs(0), Button)

    End Function

    Private Sub Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'イベントの送り側の名前を取得

        Dim senderName As String = DirectCast(sender, Button).Name

        'ボタンのベース名　長さの取得に使用
        Dim strBut As String = "Button"

        'Buttonxxのxxを取得して数字に直している
        Dim index As Integer = CInt(senderName.Substring(strBut.Length, senderName.Length - strBut.Length))

        Select Case index
            Case 1 : ButtonSub1.Text = "ア" : ButtonSub2.Text = "イ" : ButtonSub3.Text = "ウ" : ButtonSub4.Text = "エ" : ButtonSub5.Text = "オ"
            Case 2 : ButtonSub1.Text = "カ" : ButtonSub2.Text = "キ" : ButtonSub3.Text = "ク" : ButtonSub4.Text = "ケ" : ButtonSub5.Text = "コ"
            Case 3 : ButtonSub1.Text = "サ" : ButtonSub2.Text = "シ" : ButtonSub3.Text = "ス" : ButtonSub4.Text = "セ" : ButtonSub5.Text = "ソ"
            Case 4 : ButtonSub1.Text = "タ" : ButtonSub2.Text = "チ" : ButtonSub3.Text = "ツ" : ButtonSub4.Text = "テ" : ButtonSub5.Text = "ト"
            Case 5 : ButtonSub1.Text = "ナ" : ButtonSub2.Text = "ニ" : ButtonSub3.Text = "ヌ" : ButtonSub4.Text = "ネ" : ButtonSub5.Text = "ノ"
            Case 6 : ButtonSub1.Text = "ハ" : ButtonSub2.Text = "ヒ" : ButtonSub3.Text = "フ" : ButtonSub4.Text = "ヘ" : ButtonSub5.Text = "ホ"
            Case 7 : ButtonSub1.Text = "マ" : ButtonSub2.Text = "ミ" : ButtonSub3.Text = "ム" : ButtonSub4.Text = "メ" : ButtonSub5.Text = "モ"
            Case 8 : ButtonSub1.Text = "ヤ" : ButtonSub2.Text = "ユ" : ButtonSub3.Text = "ヨ" : ButtonSub4.Text = "" : ButtonSub5.Text = ""
            Case 9 : ButtonSub1.Text = "ラ" : ButtonSub2.Text = "リ" : ButtonSub3.Text = "ル" : ButtonSub4.Text = "レ" : ButtonSub5.Text = "ロ"
            Case 10 : ButtonSub1.Text = "ワ" : ButtonSub2.Text = "ヲ" : ButtonSub3.Text = "ン" : ButtonSub4.Text = "" : ButtonSub5.Text = ""
            Case 11, 12 : ButtonSub1.Text = "" : ButtonSub2.Text = "" : ButtonSub3.Text = "" : ButtonSub4.Text = "" : ButtonSub5.Text = ""
        End Select

        Call subBottonSub_Contorol()

        Dim logic As New BLL.SEN.SEARCH_SIIRE

        gridData.DataSource = logic.fncMakeSQL(0, index - 1, Nothing, txtINPUTWORD.Text)

        'グリッド初期設定
        Call subInitGrid()

    End Sub

    '引数indexに番号を受け取って、その番号が付いたButtonコントロールを返す
    Private Function ButtonSub(ByVal index As Integer) As Button

        Dim cs As Control() = Me.Controls.Find("ButtonSub" & index.ToString, True)

        Return DirectCast(cs(0), Button)

    End Function

    Private Sub ButtonSub_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'イベントの送り側の名前を取得

        Dim senderName As String = DirectCast(sender, Button).Name
        Dim senderText As String = StrConv(DirectCast(sender, Button).Text, Microsoft.VisualBasic.VbStrConv.Narrow, &H411)

        'ボタンのベース名　長さの取得に使用
        Dim strBut As String = "ButtonSub"

        'Buttonxxのxxを取得して数字に直している
        Dim index As Integer = CInt(senderName.Substring(strBut.Length, senderName.Length - strBut.Length))

        Dim logic As New BLL.SEN.SEARCH_SIIRE

        gridData.DataSource = logic.fncMakeSQL(1, index - 1, senderText, txtINPUTWORD.Text)

        'グリッド初期設定
        Call subInitGrid()

    End Sub

    ''' <summary>
    ''' グリッド初期設定
    ''' </summary>
    ''' <remarks></remarks>
    '''Private Sub subInitGrid(ByVal where As String)
    Private Sub subInitGrid()

        'Dim logic As New BLL.SEN.SEARCH_SIIRE
        'gridData.DataSource = logic.GetSIIREData(where)

        With gridData
            .DataView = C1.Win.C1TrueDBGrid.DataViewEnum.Normal
            .LinesPerRow = 0

            If .Columns.Count = 0 Then
                '***** 共通 *****
                With .Columns
                    .Add(New C1.Win.C1TrueDBGrid.C1DataColumn("", FLD_CODE, Type.GetType("System.String")))
                    .Add(New C1.Win.C1TrueDBGrid.C1DataColumn("", FLD_MENUKEY, Type.GetType("System.String")))
                    .Add(New C1.Win.C1TrueDBGrid.C1DataColumn("", FLD_NAME, Type.GetType("System.String")))
                End With
            Else
                .Columns(COL_CODE).ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal
                .Columns(COL_MENUKEY).ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal
                .Columns(COL_NAME).ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal
            End If

            '*** TrueDBGrid Caption プロパティ設定 ***
            .Columns(COL_CODE).Caption = "コード"
            .Columns(COL_MENUKEY).Caption = "カナ"
            .Columns(COL_NAME).Caption = "名称"

            '*** TrueDBGrid DataWidth プロパティ設定 ***
            .Columns(COL_CODE).DataWidth = 8
            .Columns(COL_MENUKEY).DataWidth = 8
            .Columns(COL_NAME).DataWidth = 40

            .RecordSelectors = False 'レコードセレクタ非表示（グリッド左側）

            With .Splits(0)

                For intIndex As Integer = 0 To gridData.Columns.Count - 1
                    .DisplayColumns(intIndex).Visible = CType(IIf(intIndex < COL_COUNT, True, False), Boolean)
                Next

                '*** TrueDBGrid Width プロパティ設定 ***
                .DisplayColumns(COL_CODE).Width = (5 + 4) * 8
                .DisplayColumns(COL_MENUKEY).Width = (5 + 4) * 8
                .DisplayColumns(COL_NAME).Width = (33 + 4) * 8

            End With

            '*** 共通設定 ***
            GridSetup(gridData, GridSetupAllows.AllowReadOnly, False, False, False)

            '個別の設定はGridSetupの後

            '全般
            .EditDropDown = False                   '編集にドロップダウンウインドウを使用するか？
            .Enabled = True

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
            .AlternatingRows = False

            .HeadingStyle.Font = New System.Drawing.Font("メイリオ", 8.25!, FontStyle.Regular, GraphicsUnit.Point, 128)

            'Splits 単位
            .Splits(0).HScrollBar.Style = C1.Win.C1TrueDBGrid.ScrollBarStyleEnum.None
            .Splits(0).VScrollBar.Style = C1.Win.C1TrueDBGrid.ScrollBarStyleEnum.Always
            .Splits(0).AllowFocus = True

            '*** ヘッダー ***
            '仕切り線
            .HeadingStyle.Borders.BorderType = C1.Win.C1TrueDBGrid.BorderTypeEnum.None

            For intIndex As Integer = 0 To gridData.Columns.Count - 1
                .Splits(0).DisplayColumns(intIndex).ColumnDivider.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.None
            Next

            '*** TrueDBGrid HeadingStyle.HorizontalAlignment プロパティ設定 ***
            For intIndex As Integer = 0 To gridData.Columns.Count - 1
                .Splits(0).DisplayColumns(intIndex).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
            Next

            '*** TrueDBGrid Style.HorizontalAlignment プロパティ設定 ***
            For intIndex As Integer = 0 To gridData.Columns.Count - 1
                .Splits(0).DisplayColumns(intIndex).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
            Next
            .Splits(0).DisplayColumns(COL_CODE).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
            .Splits(0).DisplayColumns(COL_MENUKEY).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
            .Splits(0).DisplayColumns(COL_NAME).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near

            '*** TrueDBGrid Locked プロパティ設定 ***
            For intIndex As Integer = 0 To gridData.Columns.Count - 1
                .Splits(0).DisplayColumns(intIndex).Locked = True
            Next

            '*** TrueDBGrid AllowSizing プロパティ設定 ***
            For intI As Integer = 0 To gridData.Columns.Count - 1
                .Splits(0).DisplayColumns(intI).AllowSizing = True
            Next intI

        End With

    End Sub

    ''' <summary>
    ''' ファンクションキー操作
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Overrides Sub FunctionKeyAction(ByVal sender As System.Object, ByVal e As CommonUtility.WinFormControls.FunctionKeyEventArgs)

        Select Case e.Name

            Case "終了"
                DialogResult = Windows.Forms.DialogResult.OK
                _SelectParam = Nothing
                Me.Close()

            Case "拡大"
                Call subPotisionSettings()
                intLocationX = Me.Location.X
                intLocationY = Me.Location.Y
                Me.Location = New Point(intLocationX, CInt(Me.Owner.Location.Y + 25))

                '増えた高さ = 変更後の高さ - 変更前の高さ
                intDifference = (Me.Owner.Height - (66 + 28)) - Me.Height   'ファンクションキー + メニューバー

                Me.Height = Me.Owner.Height - (66 + 28)   '親フォーム - (ファンクションキー + メニューバー)
                fraMain.Height = fraMain.Height + intDifference
                gridData.Height = gridData.Height + intDifference
                FunctionKey.Top = FunctionKey.Top + intDifference
                FunctionKey.SetItem(5, "縮小", "縮小", True)

            Case "縮小"
                Call subPotisionSettings()
                Me.Height = intFormHeight
                Me.Location = New Point(Me.Location.X, intLocationY)
                fraMain.Height = fraMain.Height - intDifference
                gridData.Height = gridData.Height - intDifference
                FunctionKey.Top = FunctionKey.Top - intDifference
                FunctionKey.SetItem(5, "拡大", "拡大", True)

            Case "選択"

                'データ受け渡し用クラスにセット
                If SetParameter() Then Me.Close()

        End Select

    End Sub

    ''' <summary>
    ''' 検索サブボタン表示・非表示
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub subBottonSub_Contorol()
        For intI = 0 To btnButtonSub.Count - 1
            If Utility.NUCheck(btnButtonSub(intI).Text) Then
                btnButtonSub(intI).Visible = False
            Else
                btnButtonSub(intI).Visible = True
            End If
        Next intI
    End Sub

    Private Function SetParameter() As Boolean

        If gridData.RowCount = 0 Then
            _SelectParam = Nothing
            MessageBoxEx.Show(MessageCode_Arg0.M009該当データがありません, PROGRAM_NAME)
            Return False
        End If

        If gridData.Bookmark < 0 Or _
             gridData.Bookmark > (CType(Me.gridData.DataSource, DataTable).Rows.Count - 1) Then
            'Bookmark不正の場合はメッセージ
            MessageBox.Show("データを選択してください", PROGRAM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If

        _SelectParam = New SelectParameter_M_SIIRE
        With _SelectParam
            .Code = gridData.Columns(COL_CODE).Value.ToString
            .Name = gridData.Columns(COL_NAME).Value.ToString
        End With
        DialogResult = Windows.Forms.DialogResult.OK

        Return True

    End Function

    Private Sub txtINPUTWORD_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtINPUTWORD.KeyDown
        Dim logic As New BLL.SEN.SEARCH_SIIRE

        If Not e.KeyCode = Keys.Enter Then Return

        '--- 全項目入力エラーチェック
        If Not fncAllInputValidate() Then Exit Sub

        gridData.DataSource = logic.fncMakeSQL(0, 12, Nothing, txtINPUTWORD.Text)

        'グリッド初期設定
        Call subInitGrid()

    End Sub

    Private Sub gridData_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridData.DoubleClick

        FunctionKeyAction(Me.FunctionKey, New CommonUtility.WinFormControls.FunctionKeyEventArgs(12, "選択", "選択", gridData))
    End Sub

    Private Sub fncSearchGridCilck(ByVal c As Object, ByVal e As System.EventArgs)
        Dim logic As New BLL.SEN.SEARCH_SIIRE

        gridData.DataSource = logic.fncMakeSQL(0, 12, Nothing, txtINPUTWORD.Text)

        'グリッド初期設定
        Call subInitGrid()

    End Sub

    Private _SelectParam As SelectParameter_M_SIIRE

    Public ReadOnly Property SelectItem() As SelectParameter_M_SIIRE
        Get
            Return _SelectParam
        End Get
    End Property

    Private Sub SEARCH_SIIRE_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown, _
                                                                                                                       fraMain.MouseDown, _
                                                                                                                       lblTitle.MouseDown, _
                                                                                                                       pnlKey.MouseDown, _
                                                                                                                       FunctionKey.MouseDown

        If (e.Button And MouseButtons.Left) = MouseButtons.Left Then
            '位置を記憶する
            mousePoint = New Point(e.X, e.Y)
        End If
    End Sub

    Private Sub SEARCH_SIIRE_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove, _
                                                                                                                       fraMain.MouseMove, _
                                                                                                                       lblTitle.MouseMove, _
                                                                                                                       pnlKey.MouseMove, _
                                                                                                                       FunctionKey.MouseMove

        If (e.Button And MouseButtons.Left) = MouseButtons.Left Then
            Me.Left += e.X - mousePoint.X
            Me.Top += e.Y - mousePoint.Y
            'または、つぎのようにする
            'Me.Location = New Point( _
            '    Me.Location.X + e.X - mousePoint.X, _
            '    Me.Location.Y + e.Y - mousePoint.Y)
        End If
    End Sub

    Private Sub gridData_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles gridData.HeadClick

        If gridData.RowCount = 0 Then Exit Sub

        '*** マウスポインタ砂時計 ***
        Using wcur As New WaitCursor

            Dim view As DataView = CType(gridData.DataSource, DataTable).DefaultView

            Select Case e.ColIndex
                Case COL_CODE
                    view.Sort = "ｺｰﾄﾞ " & SortMode
                Case COL_MENUKEY
                    view.Sort = "ﾒﾆｭｰｷｰ " & SortMode
                Case COL_NAME
                    view.Sort = "名称 " & SortMode
            End Select

            gridData.Update()
            gridData.Refresh()

            If SortMode = "DESC" Then
                SortMode = "ASC"
            Else
                SortMode = "DESC"
            End If

        End Using

    End Sub

    Private Sub btnManual1_Click(sender As Object, e As EventArgs) Handles btnManual1.Click
        Manual.OpenManual()
    End Sub
End Class

Public Class SelectParameter_M_SIIRE
    Public CalledForm As String
    Public Position As Integer
    Public Code As String
    Public Name As String
End Class