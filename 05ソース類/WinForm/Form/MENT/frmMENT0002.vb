Imports BLL.Common
Imports C1.Win.C1TrueDBGrid
Imports CommonUtility.WinForm
Imports CommonUtility.Utility

Public Class frmMENT0002

    Public Overrides Function PROGRAM_ID() As String
        Return "MENT0002"
    End Function

    Public Overrides Function PROGRAM_NAME() As String
        Return praProgramName
    End Function

    Private Enum COL
        KAMOKU_TYPE
        KAMOKU
        CODE
        NAME
        NAME2
        TANI
        MIT_JYU_TANAKA
        GENTANKA
        JYOUI_CODE
        JYOUI_NAME
    End Enum

    Public Enum enumDispMode
        REGIST
        SELECT_KAMOKU_HINMOKU
        SELECT_KAMOKU_HINMOKU_MULTI
    End Enum

    Private Enum enumFormStatus
        SEARCH
        REGIST
    End Enum

    Private Enum enumRegistMode
        INSERT
        UPDATE
    End Enum

    Public Enum enumKamokuType
        DKAMOKU
        CKAMOKU
        SKAMOKU
        SEARCH
    End Enum

    Public Const CONST_DKAMOKU = "大科目"
    Public Const CONST_CKAMOKU = "中科目"
    Public Const CONST_SKAMOKU = "小科目"

    Public outKamokuType As New List(Of Integer)
    Public outKamokuCode As New List(Of String)

    Private blnDbgKeyCtrlFlg As Boolean     'KeyDown()で判定、KeyPress()でTrueの場合キーを無効に
    Private praDipsMode As Integer
    Private praKamokuTypeSelect As Integer
    Private praKamokuTypeRegist As Integer
    Private praKamokuCode As String
    Private praFormStatus As Integer
    Private praRegistMode As Integer
    Private praProgramName As String
    Private keybordShift As Boolean
    Private keybordContorl As Boolean
    Private selectedRowsDbgMeisai As New List(Of Integer)
    Private selectedRowsLast As Integer

    Private daMENT0002 As New daMENT0002
    Private CodeNumbering As New CodeNumbering

    Public Sub New(
            Optional ByVal dispMode As enumDispMode = enumDispMode.REGIST _
          , Optional ByVal kamokuType As enumKamokuType = enumKamokuType.SEARCH _
          , Optional ByVal code As String = "")

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。
        praDipsMode = dispMode
        praKamokuTypeSelect = kamokuType
        praKamokuCode = code

        '画面名の設定
        If praDipsMode = enumDispMode.REGIST Then
            praProgramName = "科目・品目マスタ登録"
        Else
            praProgramName = "科目・品目マスタ選択"
        End If
    End Sub

    Protected Overrides Sub Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)

        MyBase.Form_Load(sender, e)

        'イベントの初期化
        initEvent()

        '画面の初期化
        initDisp()

        'グリッドの初期化
        initGrid()

        '複数選択のメッセージ
        If praDipsMode = enumDispMode.SELECT_KAMOKU_HINMOKU_MULTI Then
            lblMessage1.Visible = True
        Else
            lblMessage1.Visible = False
        End If

        If praKamokuTypeSelect = enumKamokuType.SEARCH Then
            '初期表示の場合

            'グリッドのクリア
            dbgMeisai.SetDataBinding(New dsMENT0002.M_KAMOKUDataTable, "", True)
            dbgInput.SetDataBinding(New dsMENT0002.M_KAMOKUDataTable, "", True)

        Else
            '選択済で初期表示の場合

            'グリッドにデータを表示
            DoSearch()
            dbgInput.SetDataBinding(New dsMENT0002.M_KAMOKUDataTable, "", True)
        End If

        'フォームの状態変更
        ChangeFormMode(enumFormStatus.SEARCH)
    End Sub

    Private Sub DoSearch()
        dbgMeisai.SetDataBinding(daMENT0002.GetMeisai(praKamokuTypeSelect, "", cmbJyouiCode.Text, txtKamokuHinmoku.Text), "", True)
        dbgMeisai.SelectedRows.Add(0)
        selectedRowsLast = 0
        selectedRowsDbgMeisai = New List(Of Integer)
        selectedRowsDbgMeisai.Add(0)
    End Sub

    Private Sub initDisp()
        Select Case praKamokuTypeSelect
            Case enumKamokuType.DKAMOKU
                rdoDKAMOKU.Checked = True
                rdoDKAMOKU_NEW.Checked = True
            Case enumKamokuType.CKAMOKU
                rdoCKAMOKU.Checked = True
                rdoCKAMOKU_NEW.Checked = True
            Case enumKamokuType.SKAMOKU
                rdoSKAMOKU.Checked = True
                rdoSKAMOKU_NEW.Checked = True
            Case Else
                rdoALL.Checked = True
                rdoDKAMOKU_NEW.Checked = True
        End Select

        '上位コードのコンボボックスの設定
        initComboBoxJyouiCode(cmbJyouiCode, rdoALL, rdoDKAMOKU, rdoCKAMOKU)
        initComboBoxJyouiCode(cmbJyouiCodeNew, Nothing, rdoDKAMOKU_NEW, rdoCKAMOKU_NEW)

        lblJyouiKamokuHinmoku.Text = ""
        lblJyouiKamokuHinmokuNew.Text = ""
        cmbJyouiCode.Text = praKamokuCode
        cmbJyouiCodeNew.Text = praKamokuCode
        txtKamokuHinmoku.Text = ""
    End Sub

    Private Sub ChangeFormMode(ByVal FormStatus As enumFormStatus)
        Dim enabledSearch = False
        Dim enabledRegist = False
        Dim focusControl As Control

        praFormStatus = FormStatus

        Select Case praFormStatus
            Case enumFormStatus.SEARCH
                'タイトルバーのモード
                TitleBar.EditMode = CommonUtility.WinFormControls.EditMode.None

                '活性・非活性の設定
                enabledSearch = True

                'ラベル名称の変更
                lblInput.Text = ""

                'フォーカスの設定
                If rdoDKAMOKU.Checked Then
                    focusControl = rdoDKAMOKU
                ElseIf rdoCKAMOKU.Checked Then
                    focusControl = rdoCKAMOKU
                ElseIf rdoSKAMOKU.Checked Then
                    focusControl = rdoSKAMOKU
                Else
                    focusControl = rdoALL
                End If

            Case Else
                'タイトルバーのモード
                If praRegistMode = enumRegistMode.INSERT Then
                    TitleBar.EditMode = CommonUtility.WinFormControls.EditMode.Create
                Else
                    TitleBar.EditMode = CommonUtility.WinFormControls.EditMode.Edit
                End If

                '活性・非活性の設定
                enabledRegist = True

                'ラベル名称の変更
                Select Case praKamokuTypeRegist
                    Case enumKamokuType.DKAMOKU
                        lblInput.Text = "大科目入力"
                    Case enumKamokuType.CKAMOKU
                        lblInput.Text = "中科目入力"
                    Case enumKamokuType.SKAMOKU
                        lblInput.Text = "小科目入力"
                End Select

                'グリッドの状態変更
                ChangeGridStutas()

                'フォーカスの設定
                focusControl = dbgInput
        End Select

        '活性・非活性、フォーカス先の制御
        rdoALL.Enabled = enabledSearch
        rdoDKAMOKU.Enabled = enabledSearch
        rdoCKAMOKU.Enabled = enabledSearch
        rdoSKAMOKU.Enabled = enabledSearch
        rdoDKAMOKU_NEW.Enabled = enabledSearch
        rdoCKAMOKU_NEW.Enabled = enabledSearch
        rdoSKAMOKU_NEW.Enabled = enabledSearch
        If enabledSearch Then
            ChangeRdoEnabled()
            ChangeRdoEnabledNew()
        Else
            cmbJyouiCode.Enabled = enabledSearch
            cmbJyouiCodeNew.Enabled = enabledSearch
        End If
        txtKamokuHinmoku.Enabled = enabledSearch
        btnSearch.Enabled = enabledSearch
        btnNew.Enabled = enabledSearch
        dbgMeisai.Enabled = enabledSearch

        dbgInput.Enabled = enabledRegist

        focusControl.Focus()

        Dim a = Me.ActiveControl

        'ファンクションキー設定
        Call initFunctionKey()

    End Sub

    Private Sub ChangeRdoEnabled()
        If rdoDKAMOKU.Checked OrElse rdoALL.Checked Then
            cmbJyouiCode.Enabled = False
        Else
            cmbJyouiCode.Enabled = True
        End If
    End Sub

    Private Sub ChangeRdoEnabledNew()
        If rdoDKAMOKU_NEW.Checked Then
            cmbJyouiCodeNew.Enabled = False
        Else
            cmbJyouiCodeNew.Enabled = True
        End If
    End Sub

    Private Sub initFunctionKey()

        FunctionKey.ClearAll()

        Select Case praFormStatus
            Case enumFormStatus.SEARCH
                FunctionKey.SetItem(1, "終了", "終了", True)

                Dim blnDbgMeisaiRowExists = (CType(dbgMeisai.DataSource, DataTable).Rows.Count <> 0)
                If blnDbgMeisaiRowExists Then
                    FunctionKey.SetItem(12, "選択", "選択", True)
                Else
                    FunctionKey.SetItem(12, "選択", "選択", False)
                End If

                If praDipsMode <> enumDispMode.REGIST Then
                    '選択画面の場合
                    If blnDbgMeisaiRowExists Then
                        FunctionKey.SetItem(10, "修正", "修正", True)
                    Else
                        FunctionKey.SetItem(10, "修正", "修正", False)
                    End If
                End If

                FunctionKey.SetItem(7, "検索", "検索", True)
                FunctionKey.SetItem(8, "新規", "新規", True)

            Case enumFormStatus.REGIST
                FunctionKey.SetItem(1, "取消", "取消", True)

                If praRegistMode = enumRegistMode.UPDATE Then
                    '更新モードの場合
                    FunctionKey.SetItem(3, "削除", "削除", True)
                End If

                If praDipsMode = enumDispMode.REGIST Then
                    '登録画面の場合
                    FunctionKey.SetItem(12, "登録", "登録", True)
                Else
                    '選択画面の場合
                    FunctionKey.SetItem(12, "登録/反映", "登録/反映", True, FunctionKey.FONT_SMALL)
                End If

                FunctionKey.SetItem(7, "検索", "検索", False)
                FunctionKey.SetItem(8, "新規", "新規", False)

        End Select

    End Sub

    Private Sub initGrid()
        initGrid(dbgMeisai)
        initGrid(dbgInput)
    End Sub

    Private Sub initGrid(ByRef gird As C1TrueDBGrid)

        With gird
            With .Columns
                .Add(New C1DataColumn("", "KAMOKU_TYPE", Type.GetType("System.String")))
                .Add(New C1DataColumn("", "KAMOKU", Type.GetType("System.String")))
                .Add(New C1DataColumn("", "CODE", Type.GetType("System.String")))
                .Add(New C1DataColumn("", "NAME", Type.GetType("System.String")))
                .Add(New C1DataColumn("", "NAME2", Type.GetType("System.String")))
                .Add(New C1DataColumn("", "TANI", Type.GetType("System.String")))
                .Add(New C1DataColumn("", "MIT_JYU_TANAKA", Type.GetType("System.Decimal")))
                .Add(New C1DataColumn("", "GENTANKA", Type.GetType("System.Decimal")))
                .Add(New C1DataColumn("", "JYOUI_CODE", Type.GetType("System.String")))
                .Add(New C1DataColumn("", "JYOUI_NAME", Type.GetType("System.String")))
            End With

            With .Splits(0)
                .DisplayColumns(COL.KAMOKU_TYPE).Width = 0
                .DisplayColumns(COL.KAMOKU).Width = (6) * 8
                .DisplayColumns(COL.CODE).Width = (6) * 8
                .DisplayColumns(COL.NAME).Width = (23) * 8
                .DisplayColumns(COL.NAME2).Width = (23) * 8
                .DisplayColumns(COL.TANI).Width = (6) * 8
                .DisplayColumns(COL.GENTANKA).Width = (13) * 8
                .DisplayColumns(COL.MIT_JYU_TANAKA).Width = (13) * 8
                .DisplayColumns(COL.JYOUI_CODE).Width = (10) * 8
                .DisplayColumns(COL.JYOUI_NAME).Width = (23) * 8 + 4
            End With

            For i As Integer = 0 To .Columns.Count - 1
                .Splits(0).DisplayColumns(i).Visible = True
            Next

            .Columns(COL.KAMOKU).Caption = "科目"
            .Columns(COL.CODE).Caption = "コード"
            .Columns(COL.NAME).Caption = "科目・品目"
            .Columns(COL.NAME2).Caption = "品質・規格・仕様"
            .Columns(COL.TANI).Caption = "単位"
            .Columns(COL.MIT_JYU_TANAKA).Caption = "見積/受注単価"
            .Columns(COL.GENTANKA).Caption = "原単価"
            .Columns(COL.JYOUI_CODE).Caption = "上位コード"
            .Columns(COL.JYOUI_NAME).Caption = "上位　科目・品目"

            For i As Integer = 0 To .Columns.Count - 1
                .Splits(0).DisplayColumns(i).AllowFocus = True
            Next

            .Columns(COL.KAMOKU).DataWidth = 6
            .Columns(COL.CODE).DataWidth = 6
            .Columns(COL.NAME).DataWidth = 30
            .Columns(COL.NAME2).DataWidth = 30
            .Columns(COL.TANI).DataWidth = 30
            .Columns(COL.MIT_JYU_TANAKA).DataWidth = 9
            .Columns(COL.GENTANKA).DataWidth = 9
            .Columns(COL.JYOUI_CODE).DataWidth = 3
            .Columns(COL.JYOUI_NAME).DataWidth = 30

            'グリッドの初期化
            If .Name = "dbgInput" Then
                GridSetup(gird, GridSetupAllows.AllowAll, False, False, False)
            Else
                GridSetup(dbgMeisai, GridSetupAllows.AllowReadOnly, False, False, False)
            End If

            .RecordSelectors = False                        'レコードセレクタ非表示（グリッド左側）
            .Font = New Font("ＭＳ ゴシック", 9, FontStyle.Regular, GraphicsUnit.Point, 128)

            '*** TrueDBGrid FetchStyle プロパティ設定 ***
            For intI As Integer = 0 To .Columns.Count - 1
                .Splits(0).DisplayColumns(intI).FetchStyle = True
            Next intI

            '*** TrueDBGrid NumberFormat プロパティ設定 ***
            .Columns(COL.GENTANKA).NumberFormat = "FormatText Event"
            .Columns(COL.MIT_JYU_TANAKA).NumberFormat = "FormatText Event"

            If .Name = "dbgInput" Then
                .AllowAddNew = False

                '*** TrueDBGrid Presentation プロパティ設定 ***
                .Columns(COL.TANI).ValueItems.Presentation = PresentationEnum.ComboBox

                '*** TrueDBGrid NumberFormat プロパティ設定 ***
                .Columns(COL.CODE).NumberFormat = "FormatText Event"

                With .Splits(0)
                    '*** TrueDBGrid AllowFocus プロパティ設定 ***
                    .DisplayColumns(COL.KAMOKU).AllowFocus = False
                    .DisplayColumns(COL.CODE).AllowFocus = False
                    .DisplayColumns(COL.NAME).AllowFocus = True
                    .DisplayColumns(COL.NAME2).AllowFocus = True
                    .DisplayColumns(COL.TANI).AllowFocus = True
                    .DisplayColumns(COL.MIT_JYU_TANAKA).AllowFocus = True
                    .DisplayColumns(COL.GENTANKA).AllowFocus = True
                    .DisplayColumns(COL.JYOUI_CODE).AllowFocus = False
                    .DisplayColumns(COL.JYOUI_NAME).AllowFocus = False
                End With

                'コンボボックスを設定します
                '単位のデータを取得
                Dim logic As New M_KBNRead("06")

                '単位
                Dim dr As dsM_KBN.M_KBNRow
                With .Columns(COL.TANI).ValueItems
                    .Values.Clear()
                    .Values.Add(New ValueItem("", ""))

                    For Each row In logic.GetM_KBN.M_KBN
                        dr = CType(row, dsM_KBN.M_KBNRow)
                        .Values.Add(New ValueItem(dr.KBNNAME, dr.KBNNAME))
                    Next

                    .Presentation = PresentationEnum.ComboBox
                    .Translate = True
                    .MaxComboItems = 10
                End With

                .Splits(0).DisplayColumns(COL.TANI).Button = CType(IIf(.Splits(0).DisplayColumns(COL.TANI).Locked = True, False, True), Boolean)
            End If
        End With
    End Sub

    Private Sub dbgMEISAI_FormatText(ByVal sender As Object, ByVal e As FormatTextEventArgs) Handles dbgMeisai.FormatText
        Dim dec As Decimal

        If Decimal.TryParse(e.Value, dec) = False Then Exit Sub

        e.Value = dec.ToString("#,##0")
    End Sub

    Private Sub dbgInput_FormatText(ByVal sender As Object, ByVal e As FormatTextEventArgs) Handles dbgInput.FormatText
        Dim dec As Decimal

        With dbgMeisai
            Select Case e.ColIndex
                Case COL.CODE

                    If Decimal.TryParse(e.Value, dec) = False Then Exit Sub

                    If praKamokuTypeRegist = enumKamokuType.SKAMOKU Then
                        e.Value = ZeroFormat(dec, 6)
                    Else
                        e.Value = ZeroFormat(dec, 3)
                    End If

                Case COL.GENTANKA, COL.MIT_JYU_TANAKA

                    If Decimal.TryParse(e.Value, dec) = False Then dec = 0

                    e.Value = dec.ToString("#,##0")
            End Select
        End With
    End Sub

    Private Sub dbgInput_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles dbgInput.KeyDown
        '数値以外の入力を無効にする
        Select Case dbgInput.Col
            Case COL.CODE, COL.GENTANKA, COL.MIT_JYU_TANAKA
                blnDbgKeyCtrlFlg = False
                If e.KeyCode >= Keys.LButton And e.KeyCode <= Keys.Help Then            '=== 色々キーコード
                ElseIf e.KeyCode >= Keys.D0 And e.KeyCode <= Keys.D9 Then               '=== ０～９キー
                ElseIf e.KeyCode >= Keys.NumPad0 And e.KeyCode <= Keys.NumPad9 Then     '=== テンキー
                ElseIf e.KeyCode = Keys.NumLock Then                                    '=== NumLockキー
                ElseIf e.KeyCode = Keys.Subtract Then                                   '=== マイナスキー
                Else
                    blnDbgKeyCtrlFlg = True
                End If
        End Select
    End Sub

    Private Sub dbgInput_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles dbgInput.KeyPress
        '*** キー入力無効制御 ***
        Select Case dbgInput.Col
            Case COL.CODE, COL.GENTANKA, COL.MIT_JYU_TANAKA
                'KeyDown()で数値以外のキーが押された場合
                If blnDbgKeyCtrlFlg = True Then
                    e.KeyChar = CChar("")
                    blnDbgKeyCtrlFlg = False
                End If
        End Select
    End Sub

    Private Sub dbgInput_RowColChange(ByVal sender As Object, ByVal e As RowColChangeEventArgs) Handles dbgInput.RowColChange

        If Me.ActiveControl Is Nothing Then Exit Sub

        '*** IMEモード設定 ***
        With dbgInput
            Select Case .Col
                Case COL.CODE, COL.GENTANKA, COL.MIT_JYU_TANAKA
                    '---ImeMode Off---
                    .ImeMode = Windows.Forms.ImeMode.Disable
                    For Each ctrl As Control In .Controls
                        If TypeOf ctrl Is TextBox Then
                            ctrl.ImeMode = Windows.Forms.ImeMode.Disable
                        End If
                    Next
                Case Else
                    '---ImeMode Hiragana---
                    .ImeMode = Windows.Forms.ImeMode.Hiragana
                    For Each ctrl As Control In .Controls
                        If TypeOf ctrl Is TextBox Then
                            ctrl.ImeMode = Windows.Forms.ImeMode.Hiragana
                        End If
                    Next
            End Select
        End With
    End Sub

    Private Sub dbgInput_FetchCellStyle(ByVal sender As Object, ByVal e As FetchCellStyleEventArgs) Handles dbgInput.FetchCellStyle
        '背景色の変更
        e.CellStyle.BackColor = Color.White
        e.CellStyle.ForeColor = Color.Black

        Select Case e.Col
            Case COL.KAMOKU, COL.JYOUI_CODE, COL.JYOUI_NAME
                e.CellStyle.BackColor = Color.FromArgb(236, 233, 216)

            Case COL.CODE
                If praRegistMode = enumRegistMode.UPDATE Then
                    e.CellStyle.BackColor = Color.FromArgb(236, 233, 216)
                End If
        End Select
    End Sub

    Private Sub ChangeGridStutas()
        With dbgInput
            If praRegistMode = enumRegistMode.UPDATE Then
                .Splits(0).DisplayColumns(COL.CODE).AllowFocus = False
            Else
                .Splits(0).DisplayColumns(COL.CODE).AllowFocus = True
            End If
        End With
    End Sub

    Private Sub initEvent()
        AddHandler rdoALL.KeyDown, AddressOf rdoKAMOKU_KeyDown
        AddHandler rdoDKAMOKU.KeyDown, AddressOf rdoKAMOKU_KeyDown
        AddHandler rdoCKAMOKU.KeyDown, AddressOf rdoKAMOKU_KeyDown
        AddHandler rdoSKAMOKU.KeyDown, AddressOf rdoKAMOKU_KeyDown

        AddHandler rdoALL.CheckedChanged, AddressOf rdoKAMOKU_CheckedChanged
        AddHandler rdoDKAMOKU.CheckedChanged, AddressOf rdoKAMOKU_CheckedChanged
        AddHandler rdoCKAMOKU.CheckedChanged, AddressOf rdoKAMOKU_CheckedChanged
        AddHandler rdoSKAMOKU.CheckedChanged, AddressOf rdoKAMOKU_CheckedChanged

        AddHandler rdoDKAMOKU_NEW.KeyDown, AddressOf rdoKAMOKU_NEW_KeyDown
        AddHandler rdoCKAMOKU_NEW.KeyDown, AddressOf rdoKAMOKU_NEW_KeyDown
        AddHandler rdoSKAMOKU_NEW.KeyDown, AddressOf rdoKAMOKU_NEW_KeyDown

        AddHandler rdoDKAMOKU_NEW.CheckedChanged, AddressOf rdoKAMOKU_NEW_CheckedChanged
        AddHandler rdoCKAMOKU_NEW.CheckedChanged, AddressOf rdoKAMOKU_NEW_CheckedChanged
        AddHandler rdoSKAMOKU_NEW.CheckedChanged, AddressOf rdoKAMOKU_NEW_CheckedChanged
    End Sub

    Private Sub initComboBoxJyouiCode(
              ByVal comboBox As CommonUtility.WinFormControls.TypComboBox _
            , ByVal radioALL As RadioButton _
            , ByVal radioDKAMOKU As RadioButton _
            , ByVal radioCKAMOKU As RadioButton)

        Dim logic As New TypComboBox
        Dim recieveParam As Model.DTO.ResponseGetComboBoxContents

        '全件の場合、処理しない
        If radioALL IsNot Nothing AndAlso radioALL.Checked Then Return

        '大科目の場合、処理しない
        If radioDKAMOKU.Checked Then Return

        '取得するテーブルの設定
        Dim tableName As String
        If radioCKAMOKU.Checked Then
            tableName = Model.ComboBoxTableName.M_DAIKAMOKU
        Else
            tableName = Model.ComboBoxTableName.M_CYUKAMOKU
        End If

        'コンボボックスの設定
        Dim plCODE As New List(Of Model.DTO.RequestGetComboBoxContentsElement)
        plCODE.Add(New Model.DTO.RequestGetComboBoxContentsElement(
                         tableName _
                       , Model.DTO.GetComboBoxContentsResultFieldType.MultipleField _
                       , True _
                       , ""))

        Dim rPCODE As New Model.DTO.RequestGetComboBoxContents(plCODE)

        recieveParam = logic.CreateComboBox(rPCODE)

        comboBox.AttachDataSource(tableName, recieveParam)
    End Sub

    Private Sub dbgMeisai_HeadClick(ByVal sender As Object, ByVal e As ColEventArgs) Handles dbgMeisai.HeadClick
        Static intCol As Integer
        Static strSort As String

        Using wcursor As New WaitCursor

            If (intCol <> e.ColIndex) Then strSort = ""
            intCol = e.ColIndex
            Select Case strSort
                Case "asc" : strSort = "desc"
                Case "desc" : strSort = "asc"
                Case Else : strSort = "asc"
            End Select

            Select Case intCol
                Case COL.CODE : CType(dbgMeisai.DataSource, DataTable).DefaultView.Sort = "CODE " & strSort
                Case COL.NAME : CType(dbgMeisai.DataSource, DataTable).DefaultView.Sort = "NAME " & strSort & ", CODE"
                Case COL.NAME2 : CType(dbgMeisai.DataSource, DataTable).DefaultView.Sort = "NAME2 " & strSort & ", CODE"
            End Select

        End Using
    End Sub

    Private Sub btnKAMOKU_NEW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim dt As New dsMENT0002.M_KAMOKUDataTable

    End Sub

    Private Sub dbgMeisai_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dbgMeisai.DoubleClick
        'クリック位置のチェック
        If WinFormUtility.GridPointAtCell(dbgMeisai) = False Then Exit Sub

        ExecuteSentaku()
    End Sub

    Private Sub ShowGridDataInput()
        Dim dt As New dsMENT0002.M_KAMOKUDataTable

        '明細（入力）のデータの取得
        If praRegistMode = enumRegistMode.UPDATE Then
            '更新モードの場合
            dt = daMENT0002.GetMeisai(dbgMeisai(dbgMeisai.Row, COL.KAMOKU_TYPE).ToString, dbgMeisai(dbgMeisai.Row, COL.CODE).ToString, "", "")

        Else
            '新規モードの場合
            Dim dr = CType(dt.NewRow, dsMENT0002.M_KAMOKURow)

            dr.KAMOKU_TYPE = praKamokuTypeRegist

            Select Case praKamokuTypeRegist
                Case enumKamokuType.DKAMOKU
                    dr.KAMOKU = CONST_DKAMOKU
                Case enumKamokuType.CKAMOKU
                    dr.KAMOKU = CONST_CKAMOKU
                Case Else
                    dr.KAMOKU = CONST_SKAMOKU
            End Select

            dr.CODE = GetNewCode()
            dr.JYOUI_CODE = cmbJyouiCodeNew.Text
            dr.JYOUI_NAME = lblJyouiKamokuHinmokuNew.Text

            dt.Rows.Add(dr)
        End If

        dbgInput.SetDataBinding(dt, "", True)
    End Sub

    Private Function GetNewCode() As Decimal
        Select Case praKamokuTypeRegist
            Case enumKamokuType.DKAMOKU
                Return CodeNumbering.GetNumer(CodeNumbering.enumKbn.M_DAIKAMOKU)
            Case enumKamokuType.CKAMOKU
                Return CodeNumbering.GetNumer(CodeNumbering.enumKbn.M_CYUKAMOKU)
            Case Else
                Return CodeNumbering.GetNumer(CodeNumbering.enumKbn.M_SYOKAMOKU)
        End Select
    End Function

    Protected Overrides Sub FunctionKeyAction(ByVal sender As System.Object, ByVal e As CommonUtility.WinFormControls.FunctionKeyEventArgs)

        Select Case e.Name

            Case "終了"
                Me.Close()

            Case "取消"
                If MessageBoxEx.Show(CommonUtility.MessageCode_Arg0.M003取消してもよろしいですか, PROGRAM_NAME) = System.Windows.Forms.DialogResult.No Then Return

                ExecuteTorikesi(False)

            Case "削除"
                If Not ExecuteDelete() Then Return

                ExecuteTorikesi(True)

            Case "検索"
                Call btnSearchClick()

            Case "新規"
                Call btnNewClick()

            Case "修正"
                ExecuteSentaku(True)

            Case "選択"
                ExecuteSentaku()

            Case "登録"
                If Not ExecuteRegist() Then Return

                ExecuteTorikesi(True)

            Case "登録/反映"
                If Not ExecuteRegist() Then Return

                outKamokuType.Add(dbgInput.Columns(COL.KAMOKU_TYPE).Value)
                outKamokuCode.Add(dbgInput.Columns(COL.CODE).Value)

                Me.Close()
        End Select
    End Sub

    Private Sub ExecuteTorikesi(ByVal meisaiReLoad As Boolean)
        'グリッドのクリア
        If meisaiReLoad Then
            If praRegistMode = enumRegistMode.UPDATE Then
                DoSearch()
            End If
        End If

        dbgInput.SetDataBinding(New dsMENT0002.M_KAMOKUDataTable, "", True)

        'フォームの状態変更
        ChangeFormMode(enumFormStatus.SEARCH)
    End Sub

    Private Sub ExecuteSentaku(Optional ByVal bntShuusei As Boolean = False)
        If praDipsMode = enumDispMode.REGIST OrElse bntShuusei Then
            '登録画面、または、修正ボタンの場合

            '科目（登録）モードの変更
            praKamokuTypeRegist = dbgMeisai(dbgMeisai.Row, COL.KAMOKU_TYPE)

            '登録モードの変更
            praRegistMode = enumRegistMode.UPDATE

            'グリッドのデータ表示
            ShowGridDataInput()

            'フォームの状態変更
            ChangeFormMode(enumFormStatus.REGIST)

        Else
            '上記以外の場合、選択処理
            If praDipsMode <> enumDispMode.SELECT_KAMOKU_HINMOKU_MULTI Then
                '単一選択の場合
                outKamokuType.Add(dbgMeisai(dbgMeisai.Row, COL.KAMOKU_TYPE))
                outKamokuCode.Add(dbgMeisai(dbgMeisai.Row, COL.CODE))
            Else
                '複数選択の場合
                selectedRowsDbgMeisai.Sort()

                For Each idx As Integer In selectedRowsDbgMeisai
                    outKamokuType.Add(dbgMeisai(idx, COL.KAMOKU_TYPE))
                    outKamokuCode.Add(dbgMeisai(idx, COL.CODE))
                Next
            End If

            Me.Close()
        End If
    End Sub

    Private Function ExecuteDelete() As Boolean
        If MessageBoxEx.Show(CommonUtility.MessageCode_Arg0.M002削除してもよろしいですか, PROGRAM_NAME) = System.Windows.Forms.DialogResult.No Then Return False

        '削除処理
        daMENT0002.DeleteKAMOKU(praKamokuTypeRegist, dbgMeisai(dbgMeisai.Row, COL.CODE).ToString)

        Return True
    End Function

    Private Function ExecuteRegist() As Boolean

        '入力チェック
        If Not InputErrorCheck(Nothing, 9999999) Then
            dbgInput.Focus()
            Return False
        End If

        If MessageBoxEx.Show(CommonUtility.MessageCode_Arg0.M001登録してもよろしいですか, PROGRAM_NAME) = System.Windows.Forms.DialogResult.No Then Return False

        '登録処理
        daMENT0002.UpdateM_KAMOKU(
                  praKamokuTypeRegist _
                , dbgInput.Columns(COL.CODE).Value.ToString _
                , dbgInput.Columns(COL.NAME).Value.ToString _
                , dbgInput.Columns(COL.NAME2).Value.ToString _
                , dbgInput.Columns(COL.TANI).Value.ToString _
                , dbgInput.Columns(COL.GENTANKA).Value.ToString _
                , dbgInput.Columns(COL.MIT_JYU_TANAKA).Value.ToString _
                , dbgInput.Columns(COL.JYOUI_CODE).Value.ToString _
                , PROGRAM_ID _
                , TANTO_CODE)

        Return True
    End Function

    Private Function InputErrorCheck(ByVal sender As Control, ByVal tabOrder As Integer) As Boolean

        'コード
        '必須チェック
        If NUCheck(dbgInput.Columns(COL.CODE).Value.ToString) Then
            '未入力の場合、採番する
            dbgInput.Columns(COL.CODE).Value = GetNewCode()
        End If

        '0埋め
        If praKamokuTypeRegist = enumKamokuType.SKAMOKU Then
            dbgInput.Columns(COL.CODE).Value = ZeroFormat(dbgInput.Columns(COL.CODE).Value, 6)
        Else
            dbgInput.Columns(COL.CODE).Value = ZeroFormat(dbgInput.Columns(COL.CODE).Value, 3)
        End If

        '存在チェック
        If praRegistMode = enumRegistMode.INSERT Then
            If daMENT0002.GetMeisai(praKamokuTypeRegist, dbgInput.Columns(COL.CODE).Value.ToString, "", "").Rows.Count <> 0 Then
                MessageBoxEx.Show(CommonUtility.MessageCode_Arg1.M026が重複しています, "コード", PROGRAM_NAME)
                dbgInput.Col = COL.CODE
                Return False
            End If
        End If

        Return True
    End Function

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Call btnSearchClick()
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Call btnNewClick()
    End Sub

    Private Sub rdoKAMOKU_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode <> Keys.Enter Then Return

        txtKamokuHinmoku.Focus()
    End Sub

    Private Sub rdoKAMOKU_CheckedChanged(sender As Object, e As EventArgs)
        cmbJyouiCode.Text = ""
        lblJyouiKamokuHinmoku.Text = ""

        ChangeRdoEnabled()

        '上位コードのコンボボックスの設定
        initComboBoxJyouiCode(cmbJyouiCode, rdoALL, rdoDKAMOKU, rdoCKAMOKU)
    End Sub

    Private Sub rdoKAMOKU_NEW_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode <> Keys.Enter Then Return

        If cmbJyouiCodeNew.Enabled Then
            cmbJyouiCodeNew.Focus()
        Else

            Select Case True
                Case rdoDKAMOKU.Checked
                    rdoDKAMOKU.Focus()
                Case rdoCKAMOKU.Checked
                    rdoCKAMOKU.Focus()
                Case rdoSKAMOKU.Checked
                    rdoSKAMOKU.Focus()
                Case Else
                    rdoALL.Focus()
            End Select

        End If
    End Sub

    Private Sub rdoKAMOKU_NEW_CheckedChanged(sender As Object, e As EventArgs)
        cmbJyouiCodeNew.Text = ""
        lblJyouiKamokuHinmokuNew.Text = ""

        ChangeRdoEnabledNew()

        '上位コードのコンボボックスの設定
        initComboBoxJyouiCode(cmbJyouiCodeNew, Nothing, rdoDKAMOKU_NEW, rdoCKAMOKU_NEW)
    End Sub

    Private Sub btnSearchClick()
        '入力チェック
        '上位科目
        If InputErrorCheck_Control(cmbJyouiCode, 9999).HasValue Then Return

        '検索する科目の設定を変更
        Select Case True
            Case rdoDKAMOKU.Checked
                praKamokuTypeSelect = enumKamokuType.DKAMOKU
            Case rdoCKAMOKU.Checked
                praKamokuTypeSelect = enumKamokuType.CKAMOKU
            Case rdoSKAMOKU.Checked
                praKamokuTypeSelect = enumKamokuType.SKAMOKU
            Case Else
                praKamokuTypeSelect = enumKamokuType.SEARCH
        End Select

        'グリッドのデータ表示
        DoSearch()

        '存在チェック
        If CType(dbgMeisai.DataSource, DataTable).Rows.Count = 0 Then
            MessageBoxEx.Show(CommonUtility.MessageCode_Arg0.M009該当データがありません, PROGRAM_NAME)
            Return
        End If

        'フォームの状態変更
        initFunctionKey()
    End Sub

    Private Sub btnNewClick()
        '入力チェック
        '上位科目
        If Not rdoDKAMOKU_NEW.Checked Then
            '大科目以外を選択
            If InputErrorCheck_Control(cmbJyouiCodeNew, 9999).HasValue Then Return
        End If

        '登録する科目の設定を変更
        Select Case True
            Case rdoDKAMOKU_NEW.Checked
                praKamokuTypeRegist = enumKamokuType.DKAMOKU
            Case rdoCKAMOKU_NEW.Checked
                praKamokuTypeRegist = enumKamokuType.CKAMOKU
            Case Else
                praKamokuTypeRegist = enumKamokuType.SKAMOKU
        End Select

        '登録モードの変更
        praRegistMode = enumRegistMode.INSERT

        'グリッドのデータ表示
        ShowGridDataInput()

        'フォームの状態変更
        ChangeFormMode(enumFormStatus.REGIST)
    End Sub

    Private Sub dbgMeisai_MouseClick(sender As Object, e As Windows.Forms.MouseEventArgs) Handles dbgMeisai.MouseClick
        MultiSelect(True)
    End Sub

    Private Sub MultiSelect(ByVal mouseClick As Boolean)
        Dim idxSt As Integer
        Dim idxEd As Integer

        If praDipsMode <> enumDispMode.SELECT_KAMOKU_HINMOKU_MULTI Then Return

        If keybordShift Then
            'シフト押下時の場合
            If selectedRowsLast < dbgMeisai.Row Then
                idxSt = selectedRowsLast
                idxEd = dbgMeisai.Row
            Else
                idxSt = dbgMeisai.Row
                idxEd = selectedRowsLast
            End If

            '範囲を選択
            For idx = idxSt To idxEd
                dbgMeisai.SelectedRows.Add(idx)
            Next

        ElseIf keybordContorl And mouseClick Then
            'コントロール押下時の場合
            Dim onFLg As Boolean = True
            selectedRowsLast = dbgMeisai.Row

            '複数選択する
            For Each idx As Integer In selectedRowsDbgMeisai
                If idx = dbgMeisai.Row Then
                    onFLg = False
                    Continue For
                End If

                dbgMeisai.SelectedRows.Add(idx)
            Next

            '未選択行、または、選択したが行が無くなる場合、選択した行を選択する
            If onFLg OrElse dbgMeisai.SelectedRows.Count = 0 Then
                dbgMeisai.SelectedRows.Add(dbgMeisai.Row)
            Else
                dbgMeisai.Row = dbgMeisai.SelectedRows(dbgMeisai.SelectedRows.Count - 1)
            End If

        Else
            '上記以外の場合
            dbgMeisai.SelectedRows.Add(dbgMeisai.Row)
            selectedRowsLast = dbgMeisai.Row
        End If

        selectedRowsDbgMeisai = New List(Of Integer)
        For Each idx As Integer In dbgMeisai.SelectedRows
            selectedRowsDbgMeisai.Add(idx)
        Next
    End Sub

    Private Sub frmMENT0002_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.ControlKey Then
            keybordContorl = True
        End If

        If e.KeyCode = Keys.ShiftKey Then
            keybordShift = True
        End If
    End Sub

    Private Sub frmMENT0002_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyCode = Keys.ControlKey Then
            keybordContorl = False
        End If

        If e.KeyCode = Keys.ShiftKey Then
            keybordShift = False
        End If
    End Sub

    Private Sub dbgMeisai_KeyUp(sender As Object, e As KeyEventArgs) Handles dbgMeisai.KeyUp
        If e.KeyCode = Keys.Down OrElse e.KeyCode = Keys.Up Then
            MultiSelect(False)
        End If
    End Sub
End Class