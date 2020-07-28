Imports CommonUtility
Imports CommonUtility.WinForm
Imports CommonUtility.WinFormControls
Imports CommonUtility.Utility
Imports BLL.Common
Imports C1.Win.C1TrueDBGrid

Public Class frmMIT0001
    '***** フォーム定数宣言 *****

    '--- TDBG MAX VALUE
    Private Const COL_COUNT As Integer = 13                                 '表示列数
    Private Const ROW_COUNT As Integer = 100                                '最大行数

    '--- COLUMNS INDEX
    '--- 明細用
    Private Const COL_KAMOKU_HINMOKU As Integer = 0                         '科目・品目
    Private Const COL_HINSITU_KIKAKU_SIYO As Integer = 1                    '品質・規格・仕様
    Private Const COL_SUU As Integer = 2                                    '数量
    Private Const COL_TANI As Integer = 3                                   '単位
    Private Const COL_TANKA As Integer = 4                                  '見積単価
    Private Const COL_GAKU As Integer = 5                                   '見積金額
    Private Const COL_GAKU_NUKI As Integer = 6                              '見積金額税抜
    Private Const COL_GENTANKA As Integer = 7                               '原単価
    Private Const COL_GENKAGAKU As Integer = 8                              '原価金額
    Private Const COL_KAKERITU As Integer = 9                               '掛率（％）
    Private Const COL_G_BIKO As Integer = 10                                '行備考
    Private Const COL_SIIRECODE As Integer = 11                             '仕入先コード（担当下請コード）
    Private Const COL_SIIRENAME As Integer = 12                             '仕入先名称（担当下請名称）
    Private Const COL_KAISOCODE As Integer = 13                             '階層コード
    Private Const COL_ARARIGAKU As Integer = 14                             '粗利金額
    Private Const COL_IKATU_KAKERITU As Integer = 15                        '一括掛率
    Private Const COL_DAIKAMOKUCODE As Integer = 16                         '大科目コード
    Private Const COL_CYUKAMOKUCODE As Integer = 17                         '中科目コード
    Private Const COL_SYOKAMOKUCODE As Integer = 18                         '小科目コード

    'ﾌｧﾝｸｼｮﾝ・ｷｰ
    Private Const SYSFC_SYURYO As String = "終了"
    Private Const SYSFC_CANCEL As String = "取消"
    Private Const SYSFC_DELETE As String = "削除"
    Private Const SYSFC_ROW_DELETE As String = "行削除"
    Private Const SYSFC_ROW_UP As String = "行移動（上）"
    Private Const SYSFC_ROW_DOWN As String = "行移動（下）"
    Private Const SYSFC_KAMOKU_HINMOKU As String = "科目/品目"
    Private Const SYSFC_SEARCH As String = "検索"
    Private Const SYSFC_PREVIEW As String = "プレビュー"
    Private Const SYSFC_EXECUT As String = "登録/印刷"

    'ﾌｧﾝｸｼｮﾝｷｰ機能
    Private Const FUNC_SYURYO As Integer = 1
    Private Const FUNC_CANCEL As Integer = 1
    Private Const FUNC_DELETE As Integer = 3
    Private Const FUNC_KAMOKU_HINMOKU As Integer = 5
    Private Const FUNC_ROW_DELETE As Integer = 6
    Private Const FUNC_ROW_UP As Integer = 7
    Private Const FUNC_ROW_DOWN As Integer = 8
    Private Const FUNC_SEARCH As Integer = 9
    Private Const FUNC_PREVIEW As Integer = 11
    Private Const FUNC_EXECUT As Integer = 12

    Private Const intKaisoKeta As Integer = 3                               '階層を形成するコードのバイト数
    Private Const intKaisoSuu As Integer = 10                               '階層の最大数（上位３階層除く）

    Private KAKERITU_COLOR As System.Drawing.Color = Color.LightCoral     '一括掛率

    '*** 変数宣言 *******************************************************************
    Private daMIT0001 As New daMIT0001
    Private daMENT0002 As New daMENT0002
    Private dbM_KBNValue As New dsM_KBN
    Private dbM_KBN_SIYOU06 As New dsM_KBN
    Private T_BUKKEN As New T_BUKKENRead
    Private T_MITUMORI As New T_MITUMORIRead

    Private strSyohiZeiritu As String

    Private dbS_SCBValue As dsS_SCB
    Private strS_SCB_NO00_MITUMORINO As String
    Private strS_SCB_DEFAULT_01 As String
    Private strS_SCB_DEFAULT_02 As String
    Private strS_SCB_DEFAULT_03 As String
    Private strS_SCB_DEFAULT_04 As String
    Private strS_SCB_ROUND_ARARIRITU As String
    Private strS_SCB_ROUND_GENKAKIN As String
    Private strS_SCB_ROUND_GENTANKA As String
    Private strS_SCB_ROUND_MITKAKIN As String
    Private strS_SCB_ROUND_MITTANKA As String
    Private strS_SCB_ROUND_SYOKARITU As String
    Private strS_SCB_ROUND_TAX As String
    Private strS_SCB_ROUND_MITSUURYO As String
    Public strS_SCB_ZEIKBN As String
    Private strS_SCB_ADDRESS1 As String
    Private strS_SCB_ADDRESS2 As String
    Private strS_SCB_COMMENT1 As String
    Private strS_SCB_EMAIL As String
    Private strS_SCB_FAXNO As String
    Private strS_SCB_ISOQAR As String
    Private strS_SCB_JISYANAME As String
    Private strS_SCB_POSTNO As String
    Private strS_SCB_TELNO As String
    Private strS_SCB_WEB As String
    Private blnComboboxEnter As Boolean

    '検索ﾒﾆｭｰ用
    Private strFormStatus As String

    Private intMoveRowValue As Integer = 0

    'DBGrid関連
    Private blnDbgKeyCtrlFlg As Boolean     'KeyDown()で判定、KeyPress()でTrueの場合キーを無効に

    Private blnSai_MitumoriNoChg As Boolean
    Private blnSan_MitumoriNoChg As Boolean

    ' 非連結列の値を保持するHashtable
    Dim _hash As New Hashtable()

    '*** 配列定義用定数宣言 *********************************************************
    Public txtNOUKIDATE As New List(Of DateTextBoxEx)
    Public lblNOUKIGENGO As New List(Of Label)

    Private Event TreeNodeAddInsertDelete(ByVal sender As TreeView)

    Public Overrides Function PROGRAM_ID() As String
        Return "MIT0001"
    End Function

    Public Overrides Function PROGRAM_NAME() As String
        Return "見積登録"
    End Function

    Private mitsumoriJyouken As New MitsumoriJyouken

    Private Enum enumFormStatus
        KeyInput
        DetailInput
    End Enum

    Public requestBUK0001 As New requestBUK0001

    Public Sub New()

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。

        requestBUK0001.BUKKEN_NO = 0
    End Sub

    Protected Overrides Sub Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim strDate As Date = System.DateTime.Today

        MyBase.Form_Load(sender, e)

        Using wcur As New WaitCursor

            OutPutDebugLogInit()

            '物件Noの設定
            txtMITUMORINO.Text = ZeroFormat(requestBUK0001.BUKKEN_NO, txtMITUMORINO.MaxLength)
            txtSAI_MITUMORINO.Text = ZeroFormat(requestBUK0001.BUKKEN_NO, txtSAI_MITUMORINO.MaxLength)

            '基本設定マスタ取得
            fncRead_S_SCB("DISP_CTRL")
            fncRead_S_SCB("SYSTEM")
            fncRead_S_SCB("INFO_JISYA")

            '区分マスタ取得（単位）
            fncRead_M_KBN("06")

            '区分マスタ取得（消費税）
            Dim logic As New M_KBNRead()
            strSyohiZeiritu = logic.fncSelect_SyohiZeiritu(strDate)

            'コントロール配列化
            subControlSet()

            'コンボボックス
            subInitCombo()

            'ボタンの表示設定
            VisibleButton()

            'イベント指定
            subEventHandler()

            '--- TrueDBGrid初期設定 ---
            Call subInitGrid()

            '画面初期化
            subInitDisp()

        End Using
    End Sub

    ''' <summary>
    ''' コントロール配列化
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub subControlSet()
        '配列に格納
        Me.txtNOUKIDATE.Add(Me.txtNOUKIDATE0)
        Me.txtNOUKIDATE.Add(Me.txtNOUKIDATE1)
        Me.lblNOUKIGENGO.Add(Me.lblNOUKIGengo0)
        Me.lblNOUKIGENGO.Add(Me.lblNOUKIGengo1)
    End Sub

    Private Sub VisibleButton()
        '使用機能権限クラスの定義
        Dim siyoKinouAuthority = New SiyoKinouAuthority(TANTO_CODE)

        btnMENT0006.Visible = siyoKinouAuthority.CheckUseKinou(SiyoKinouAuthority.CONST_業者マスタ登録)
        btnMENT0002.Visible = siyoKinouAuthority.CheckUseKinou(SiyoKinouAuthority.CONST_科目マスタ登録)
    End Sub

    ''' <summary>
    ''' コンボボックス設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub subInitCombo()
        Dim lgcTypCombo As New BLL.Common.TypComboBox

        'コンボボックスデータ取得
        Dim paramlist As New List(Of Model.DTO.RequestGetComboBoxContentsElement)

        paramlist.Add(New Model.DTO.RequestGetComboBoxContentsElement(Model.ComboBoxTableName.T_MITUMORIHED_MITUMORINO, Model.DTO.GetComboBoxContentsResultFieldType.MultipleField, False, Nothing))
        paramlist.Add(New Model.DTO.RequestGetComboBoxContentsElement(Model.ComboBoxTableName.M_TANTO, Model.DTO.GetComboBoxContentsResultFieldType.MultipleField, False, Nothing))
        paramlist.Add(New Model.DTO.RequestGetComboBoxContentsElement(Model.ComboBoxTableName.M_KBN, Model.DTO.GetComboBoxContentsResultFieldType.MultipleField, False, "04"))

        Dim requestParam As New Model.DTO.RequestGetComboBoxContents(paramlist)

        Dim recieveParam As Model.DTO.ResponseGetComboBoxContents
        recieveParam = lgcTypCombo.CreateComboBox(requestParam)

        '参照見積Ｎｏ
        cmbSAN_MITUMORINO.AttachDataSource(Model.ComboBoxTableName.T_MITUMORIHED_MITUMORINO, recieveParam)
        '担当者
        cmbTantoCode.AttachDataSource(Model.ComboBoxTableName.M_TANTO, recieveParam)
        '敬称
        cmbKEISYOUCODE.AttachDataSource(Model.ComboBoxTableName.M_KBN, recieveParam)

        'コンボボックスデータ取得
        paramlist = New List(Of Model.DTO.RequestGetComboBoxContentsElement)

        '物件Noに該当する見積情報を取得
        paramlist.Add(New Model.DTO.RequestGetComboBoxContentsElement(Model.ComboBoxTableName.T_MITUMORIHED_MITUMORINO, Model.DTO.GetComboBoxContentsResultFieldType.MultipleField, False, txtMITUMORINO.Text))

        requestParam = New Model.DTO.RequestGetComboBoxContents(paramlist)

        recieveParam = lgcTypCombo.CreateComboBox(requestParam)

        '見積Ｎｏ
        cmbMITUMORINO.AttachDataSource(Model.ComboBoxTableName.T_MITUMORIHED_MITUMORINO, recieveParam)
        '再見積Ｎｏ
        cmbSAI_MITUMORINO.AttachDataSource(Model.ComboBoxTableName.T_MITUMORIHED_MITUMORINO, recieveParam)

        '見積条件のリストの作成
        mitsumoriJyouken.SetCmbMitsumoriJyouken(cmbMitumoriJouken)

        If Not NUCheck(mitsumoriJyouken.errMessage) Then
            '見積条件の読み込みでエラーの場合
            MsgBox(mitsumoriJyouken.errMessage)
            Me.Close()
            Return
        End If
    End Sub

    Private Sub subInitDisp(Optional ByVal KeyClear As Boolean = True)
        Dim strDate As Date = Me.ServerDate
        Dim M_TOKUI As M_TOKUIread = New M_TOKUIread

        OutPutDebugLog(System.Reflection.MethodBase.GetCurrentMethod.Name)

        '物件情報の取得
        Dim drT_BUKKEN As dsT_BUKKEN.T_BUKKENRow = DirectCast(T_BUKKEN.GetDataWherePk(CDec(txtMITUMORINO.Text)).Rows(0), dsT_BUKKEN.T_BUKKENRow)

        '得意先マスタの取得
        Dim dtTOKUI As dsM_TOKUI.M_TOKUIDataTable = M_TOKUI.ReadM_TOKUI(drT_BUKKEN.MOTOUKECODE)

        'モードの設定
        TitleBar.EditMode = EditMode.None

        '画面の初期化
        If KeyClear Then
            txtMITUMORIEDABAN.Text = vbNullString
            cmbMITUMORINO.Text = vbNullString
            lblMITUMORINO.Text = vbNullString
        End If
        txtTEISYUTUDATE.Text = strDate.ToString
        lblTeisyutuGengo.Text = "(" & GetCnvSW.SfncYearSW(CDate(txtTEISYUTUDATE.Text).ToString("yyyy/MM/dd"), True, True) & ")"
        txtTantoName.Text = vbNullString
        cmbTantoCode.Text = Utility.ZeroPadding(Me.NowUserInfo.TANTOCODE, 4)
        txtKokyakuCode.Text = drT_BUKKEN.MOTOUKECODE
        txtKokyakuName.Text = drT_BUKKEN.TOKUINAME
        txtNOUKIDATE(0).Text = strDate.ToString
        lblNOUKIGENGO(0).Text = "(" & GetCnvSW.SfncYearSW(CDate(txtNOUKIDATE(0).Text).ToString("yyyy/MM/dd"), True, True) & ")"
        txtNOUKIDATE(1).Text = strDate.ToString
        lblNOUKIGENGO(1).Text = "(" & GetCnvSW.SfncYearSW(CDate(txtNOUKIDATE(1).Text).ToString("yyyy/MM/dd"), True, True) & ")"
        txtSAI_MITUMORIEDABAN.Text = vbNullString
        cmbSAI_MITUMORINO.Text = vbNullString
        cmbSAI_MITUMORINO.Refresh()
        lblSAI_MITUMORINO.Text = vbNullString
        txtSAN_MITUMORINO.Text = vbNullString
        txtSAN_MITUMORIEDABAN.Text = vbNullString
        cmbSAN_MITUMORINO.Text = vbNullString
        cmbSAN_MITUMORINO.Refresh()
        lblSAN_MITUMORINO.Text = vbNullString
        cmbKEISYOUCODE.Text = vbNullString
        txtKEISYOUNAME.Text = vbNullString
        If dtTOKUI.Rows.Count <> 0 Then
            cmbKEISYOUCODE.Text = DirectCast(dtTOKUI.Rows(0), dsM_TOKUI.M_TOKUIRow).KEISYOUCODE
        End If
        txtKoujiName.Text = drT_BUKKEN.BUKKENNAME
        txtKoujiNo.Text = vbNullString
        txtKoujiBasyo.Text = drT_BUKKEN.ADDRESS1
        txtKigen.Text = strS_SCB_DEFAULT_01
        txtShiharaiJoken.Text = strS_SCB_DEFAULT_02
        txtMitsumoriJoken.Text = ""

        With trvWorkInfo
            'TreeView1へのドラッグを受け入れる
            .AllowDrop = True
            'TreeView設定
            .LabelEdit = False
            .HideSelection = False
            .Tag = ""
            'ﾂﾘｰ初期化
            .Nodes.Clear()
        End With

        lblSyosu.Text = "0"
        lblSyosuName.Text = "数量小数点以下桁数：" & StrConv(lblSyosu.Text, VbStrConv.Wide) & "位"

        txtD_BIKO.Text = vbNullString
        mitsumoriJyouken.SetTxtMitsumoriJoken(txtMitsumoriJoken, cmbMitumoriJouken)
        If cmbMitumoriJouken.Items.Count <> 0 Then cmbMitumoriJouken.SelectedIndex = 0

        tabDetail.SelectedIndex = 0

        '明細計
        txtMKGENKAGAKU.Text = "0"
        txtMKGAKU_NUKI.Text = "0"
        txtMKARARIRITU.Text = "（粗利率：  0.00％）"
        '総合計
        txtGKGENKAGAKU.Text = "0"
        txtGKGAKU_NUKI.Text = "0"
        txtGKARARIRITU.Text = "（粗利率：  0.00％）"
        txtGKTAX.Text = "0"
        txtGKGAKU.Text = "0"

        Select Case strS_SCB_ZEIKBN
            Case "0"
                lblGKTAX.Text = "消費税:"
                lblGKTAX.Visible = True
                txtGKTAX.Visible = True
                lblGKMITUMORIGAKU.Visible = True
                txtGKGAKU.Visible = True
            Case "1"
                lblGKTAX.Text = "内消費税:"
                lblGKTAX.Visible = True
                txtGKTAX.Visible = True
                lblGKMITUMORIGAKU.Visible = False
                txtGKGAKU.Visible = False
            Case "2"
                lblGKTAX.Visible = False
                txtGKTAX.Visible = False
                lblGKMITUMORIGAKU.Visible = False
                txtGKGAKU.Visible = False
        End Select

        blnSai_MitumoriNoChg = False
        blnSan_MitumoriNoChg = False

        dbgMEISAI.SetDataBinding(New dsMIT0001.T_MITUMORISelectDataTable, "", True)

        '入力制御切替
        subFormSwitch(enumFormStatus.KeyInput)

        '工事名称変更処理（ツリービューの作成）
        ChangeTxtKoujiName()

        txtMITUMORIEDABAN.Focus()
    End Sub

    ''' <summary>
    ''' ファンクションキー設定
    ''' </summary>
    ''' <param name="FormStatus"></param>
    ''' <remarks></remarks>
    Private Sub subFunctionKeySettings(ByVal FormStatus As enumFormStatus)

        OutPutDebugLog(System.Reflection.MethodBase.GetCurrentMethod.Name)

        FunctionKey.ClearAll()

        Select Case FormStatus
            Case enumFormStatus.KeyInput
                FunctionKey.SetItem(FUNC_SYURYO, SYSFC_SYURYO, SYSFC_SYURYO, True)
            Case enumFormStatus.DetailInput
                FunctionKey.SetItem(FUNC_CANCEL, SYSFC_CANCEL, SYSFC_CANCEL, True)
                If Not NUCheck(txtMITUMORIEDABAN.Text) Then
                    FunctionKey.SetItem(FUNC_DELETE, SYSFC_DELETE, SYSFC_DELETE, True)
                End If
                FunctionKey.SetItem(FUNC_KAMOKU_HINMOKU, SYSFC_KAMOKU_HINMOKU, SYSFC_KAMOKU_HINMOKU, True, FunctionKey.FONT_SMALL)
                FunctionKey.SetItem(FUNC_ROW_DELETE, SYSFC_ROW_DELETE, SYSFC_ROW_DELETE, True)
                FunctionKey.SetItem(FUNC_ROW_UP, SYSFC_ROW_UP, "行移動" & vbCrLf & "（上）", True, FunctionKey.FONT_SMALL)
                FunctionKey.SetItem(FUNC_ROW_DOWN, SYSFC_ROW_DOWN, "行移動" & vbCrLf & "（下）", True, FunctionKey.FONT_SMALL)
                FunctionKey.SetItem(FUNC_SEARCH, SYSFC_SEARCH, SYSFC_SEARCH, True)
                FunctionKey.SetItem(FUNC_PREVIEW, SYSFC_PREVIEW, SYSFC_PREVIEW, True, FunctionKey.FONT_SMALL)
                FunctionKey.SetItem(FUNC_EXECUT, SYSFC_EXECUT, SYSFC_EXECUT, True, FunctionKey.FONT_SMALL)
        End Select
    End Sub

    ''' <summary>
    ''' 入力チェック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="tabOrder"></param>
    ''' <remarks></remarks>
    Private Function fncInputErrorCheck(ByVal sender As Control, ByVal tabOrder As Integer) As Boolean
        Dim CheckResult As Nullable(Of Boolean)
        Dim datTeisyutuDate As Date
        Dim datNouki As Date

        OutPutDebugLog(System.Reflection.MethodBase.GetCurrentMethod.Name)

        If fraKeyInput.Enabled = True Then

            '見積枝番
            CheckResult = InputErrorCheck_Control(txtMITUMORIEDABAN, tabOrder)
            If CheckResult.HasValue Then Return CheckResult.Value

            '提出日付
            CheckResult = InputErrorCheck_Control(txtTEISYUTUDATE, tabOrder)
            If CheckResult.HasValue Then Return CheckResult.Value
            If txtTEISYUTUDATE.Text <> "    /  /" Then
                datTeisyutuDate = CDate(txtTEISYUTUDATE.Text)
                lblTeisyutuGengo.Text = "(" & GetCnvSW.SfncYearSW(datTeisyutuDate.ToString("yyyy/MM/dd"), True, True) & ")"
            Else
                lblTeisyutuGengo.Text = vbNullString
            End If

            '納期
            If GetTabOrder(txtNOUKIDATE(0)) >= tabOrder Then
                Return True
            Else
                CheckResult = InputErrorCheck_Control(txtNOUKIDATE(0), tabOrder)
                If CheckResult.HasValue Then Return CheckResult.Value
                If txtNOUKIDATE(0).Text <> "    /  /" Then
                    datNouki = CDate(txtNOUKIDATE(0).Text)
                    lblNOUKIGENGO(0).Text = "(" & GetCnvSW.SfncYearSW(datNouki.ToString("yyyy/MM/dd"), True, True) & ")"
                Else
                    lblNOUKIGENGO(0).Text = vbNullString
                End If
            End If

            If GetTabOrder(txtNOUKIDATE(1)) >= tabOrder Then
                Return True
            Else
                CheckResult = InputErrorCheck_Control(txtNOUKIDATE(1), tabOrder)
                If CheckResult.HasValue Then Return CheckResult.Value
                If txtNOUKIDATE(1).Text <> "    /  /" Then
                    datNouki = CDate(txtNOUKIDATE(1).Text)
                    lblNOUKIGENGO(1).Text = "(" & GetCnvSW.SfncYearSW(datNouki.ToString("yyyy/MM/dd"), True, True) & ")"
                Else
                    lblNOUKIGENGO(1).Text = vbNullString
                End If
                If txtNOUKIDATE(0).Text <> "    /  /" And txtNOUKIDATE(1).Text <> "    /  /" Then
                    '範囲チェック
                    If RangeValidator.ValidateMe(txtNOUKIDATE(0).DisplayName, txtNOUKIDATE(0), txtNOUKIDATE(1)) = False Then
                        txtNOUKIDATE(0).Focus()
                        Return False
                    End If
                End If
            End If

            '再見積枝番
            CheckResult = InputErrorCheck_Control(txtSAI_MITUMORIEDABAN, tabOrder)
            If CheckResult.HasValue Then Return CheckResult.Value
            '参照見積Ｎｏ
            CheckResult = InputErrorCheck_Control(txtSAN_MITUMORINO, tabOrder)
            If CheckResult.HasValue Then Return CheckResult.Value
            '参照見積枝番
            CheckResult = InputErrorCheck_Control(txtSAN_MITUMORIEDABAN, tabOrder)
            If CheckResult.HasValue Then Return CheckResult.Value
            '担当者
            CheckResult = InputErrorCheck_Control(cmbTantoCode, tabOrder)
            If CheckResult.HasValue Then Return CheckResult.Value
            '敬称
            CheckResult = InputErrorCheck_Control(cmbKEISYOUCODE, tabOrder)
            If CheckResult.HasValue Then Return CheckResult.Value
            '工事名称
            CheckResult = InputErrorCheck_Control(txtKoujiName, tabOrder)
            If CheckResult.HasValue Then Return CheckResult.Value
            '工事番号
            CheckResult = InputErrorCheck_Control(txtKoujiNo, tabOrder)
            If CheckResult.HasValue Then Return CheckResult.Value
            '工事場所
            CheckResult = InputErrorCheck_Control(txtKoujiBasyo, tabOrder)
            If CheckResult.HasValue Then Return CheckResult.Value
            '有効期限
            CheckResult = InputErrorCheck_Control(txtKigen, tabOrder)
            If CheckResult.HasValue Then Return CheckResult.Value
            '支払条件
            CheckResult = InputErrorCheck_Control(txtShiharaiJoken, tabOrder)
            If CheckResult.HasValue Then Return CheckResult.Value
        End If

        '伝票備考
        CheckResult = InputErrorCheck_Control(txtD_BIKO, tabOrder)
        If CheckResult.HasValue Then Return CheckResult.Value

        '見積条件
        CheckResult = InputErrorCheck_Control(txtMitsumoriJoken, tabOrder)
        If CheckResult.HasValue Then Return CheckResult.Value

        Return True

    End Function

    ''' <summary>
    ''' 全項目入力エラーチェック
    ''' </summary>
    ''' <remarks></remarks>
    Public Function fncAllInputValidate() As Boolean
        Return fncInputErrorCheck(Nothing, 9999999)
    End Function

    ''' <summary>
    ''' エンターキー押下時イベント
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

    Private Sub subEventHandler()
        'イベントハンドラを追加する
        AddHandler txtMITUMORIEDABAN.GotFocus, AddressOf ChangeFunctionKeyDisabled
        AddHandler txtTEISYUTUDATE.GotFocus, AddressOf ChangeFunctionKeyDisabled
        AddHandler txtNOUKIDATE0.GotFocus, AddressOf ChangeFunctionKeyDisabled
        AddHandler txtNOUKIDATE1.GotFocus, AddressOf ChangeFunctionKeyDisabled
        AddHandler txtSAI_MITUMORIEDABAN.GotFocus, AddressOf ChangeFunctionKeyDisabled
        AddHandler txtSAN_MITUMORINO.GotFocus, AddressOf ChangeFunctionKeyDisabled
        AddHandler txtSAN_MITUMORIEDABAN.GotFocus, AddressOf ChangeFunctionKeyDisabled
        AddHandler txtKoujiName.GotFocus, AddressOf ChangeFunctionKeyDisabled
        AddHandler txtKoujiNo.GotFocus, AddressOf ChangeFunctionKeyDisabled
        AddHandler txtKoujiBasyo.GotFocus, AddressOf ChangeFunctionKeyDisabled
        AddHandler txtKigen.GotFocus, AddressOf ChangeFunctionKeyDisabled
        AddHandler txtShiharaiJoken.GotFocus, AddressOf ChangeFunctionKeyDisabled
        AddHandler txtD_BIKO.GotFocus, AddressOf ChangeFunctionKeyDisabled
        AddHandler txtMitsumoriJoken.GotFocus, AddressOf ChangeFunctionKeyDisabled

        AddHandler cmbMITUMORINO.GotFocus, AddressOf ChangeFunctionKeyDisabled
        AddHandler cmbSAI_MITUMORINO.GotFocus, AddressOf ChangeFunctionKeyDisabled
        AddHandler cmbSAN_MITUMORINO.GotFocus, AddressOf ChangeFunctionKeyDisabled
        AddHandler cmbKEISYOUCODE.GotFocus, AddressOf ChangeFunctionKeyDisabled

        AddHandler trvWorkInfo.Enter, AddressOf ChangeFunctionKeyDisabled
        AddHandler txtTEISYUTUDATE.Enter, AddressOf ChangeFunctionKeyDisabled
        AddHandler txtMITUMORIEDABAN.Enter, AddressOf ChangeFunctionKeyDisabled
        AddHandler cmbSAI_MITUMORINO.Enter, AddressOf ChangeFunctionKeyDisabled
        AddHandler cmbSAN_MITUMORINO.Enter, AddressOf ChangeFunctionKeyDisabled
        AddHandler cmbKEISYOUCODE.Enter, AddressOf ChangeFunctionKeyDisabled

        AddHandler cmbTantoCode.GotFocus, AddressOf EventHandlerComboBox
        AddHandler cmbTantoCode.Enter, AddressOf EventHandlerComboBox

        AddHandler dbgMEISAI.Enter, AddressOf setFunctionKeyChangeDbgMEISAI

        AddHandler txtMITUMORIEDABAN.Enter, AddressOf EnterEventHandler
        AddHandler cmbMITUMORINO.Enter, AddressOf EnterEventHandler
        AddHandler txtTEISYUTUDATE.Enter, AddressOf EnterEventHandler
        AddHandler cmbTantoCode.Enter, AddressOf EnterEventHandler
        AddHandler txtNOUKIDATE(0).Enter, AddressOf EnterEventHandler
        AddHandler txtNOUKIDATE(1).Enter, AddressOf EnterEventHandler
        AddHandler txtSAI_MITUMORIEDABAN.Enter, AddressOf EnterEventHandler
        AddHandler cmbSAI_MITUMORINO.Enter, AddressOf EnterEventHandler
        AddHandler txtSAN_MITUMORINO.Enter, AddressOf EnterEventHandler
        AddHandler txtSAN_MITUMORIEDABAN.Enter, AddressOf EnterEventHandler
        AddHandler cmbSAN_MITUMORINO.Enter, AddressOf EnterEventHandler
        AddHandler cmbKEISYOUCODE.Enter, AddressOf EnterEventHandler
        AddHandler txtKoujiName.Enter, AddressOf EnterEventHandler
        AddHandler txtKoujiNo.Enter, AddressOf EnterEventHandler
        AddHandler txtKoujiBasyo.Enter, AddressOf EnterEventHandler
        AddHandler txtKigen.Enter, AddressOf EnterEventHandler
        AddHandler txtShiharaiJoken.Enter, AddressOf EnterEventHandler
        AddHandler txtD_BIKO.Enter, AddressOf EnterEventHandler
        AddHandler txtMitsumoriJoken.Enter, AddressOf EnterEventHandler

        AddHandler trvWorkInfo.AfterSelect, AddressOf trvWorkInfo_AfterSelect

        AddHandler trvWorkInfo_Reference.AfterSelect, AddressOf trvWorkInfo_Reference_AfterSelect

        AddHandler btnMENT0002.Click, AddressOf PopUpProgram_Click
        AddHandler btnMENT0006.Click, AddressOf PopUpProgram_Click
    End Sub

    ''' <summary>
    ''' 入力制御切替
    ''' </summary>
    ''' <param name="FormStatus"></param>
    ''' <remarks></remarks>
    Private Sub subFormSwitch(ByVal FormStatus As enumFormStatus)

        OutPutDebugLog(System.Reflection.MethodBase.GetCurrentMethod.Name)

        Select Case FormStatus
            Case enumFormStatus.KeyInput

                strFormStatus = "KeyInput"

                'コントロール使用可・不可
                fraMITUMORINO.Enabled = True
                fraKeyInput.Enabled = False
                trvWorkInfo.Enabled = False
                tabDetail.Enabled = False
                dbgMEISAI.Enabled = False

                trvWorkInfo.Refresh()
                trvWorkInfo.Nodes.Clear()

                trvWorkInfo_Reference.Refresh()
                trvWorkInfo_Reference.Nodes.Clear()

            Case enumFormStatus.DetailInput

                strFormStatus = "DetailInput"

                'コントロール使用可・不可
                fraMITUMORINO.Enabled = False
                trvWorkInfo.Enabled = True
                tabDetail.Enabled = True
                fraKeyInput.Enabled = True
                dbgMEISAI.Enabled = True
                txtD_BIKO.Enabled = True
                txtMitsumoriJoken.Enabled = True
        End Select

        subFunctionKeySettings(FormStatus)
    End Sub

    Protected Overrides Sub FunctionKeyAction(ByVal sender As System.Object, ByVal e As CommonUtility.WinFormControls.FunctionKeyEventArgs)

        OutPutDebugLog(System.Reflection.MethodBase.GetCurrentMethod.Name)

        Select Case e.Name

            Case SYSFC_SYURYO
                '終了

                '呼び出し元の再表示
                CType(ownerForm, frmBUK0001).ShowReDisp()

                Me.Close()

                Exit Sub

            Case SYSFC_CANCEL
                '取消

                '確認メッセージ
                If MessageBoxEx.Show(MessageCode_Arg0.M003取消してもよろしいですか, PROGRAM_NAME) = Windows.Forms.DialogResult.No Then Exit Sub

                '画面初期化
                Call subInitDisp()

            Case SYSFC_DELETE
                '削除

                '確認メッセージ
                If MessageBoxEx.Show(MessageCode_Arg0.M002削除してもよろしいですか, PROGRAM_NAME) = Windows.Forms.DialogResult.No Then Exit Sub

                Using ts As System.Transactions.TransactionScope = New System.Transactions.TransactionScope()
                    '見積ヘッダトラン全削除
                    Call daMIT0001.DeleteData_T_MITUMORIHED(txtMITUMORINO.Text, txtMITUMORIEDABAN.Text)

                    '見積トラン全削除
                    Call daMIT0001.DeleteData_T_MITUMORI(txtMITUMORINO.Text, txtMITUMORIEDABAN.Text)

                    ts.Complete()
                End Using

                'コンボボックス
                Call subInitCombo()

                '画面初期化
                Call subInitDisp()

            Case SYSFC_ROW_DELETE
                '行削除
                DbgMeisaiRowDelete()

            Case SYSFC_ROW_UP
                '行移動（上）
                DbgMeisaiRowMove("UP")

            Case SYSFC_ROW_DOWN
                '行移動（下）
                DbgMeisaiRowMove("DOWN")

            Case SYSFC_KAMOKU_HINMOKU
                '科目/品目
                ClickKamokuHinmokuButton()

            Case SYSFC_SEARCH
                '検索

                Select Case LastFocusedControl.TabIndex

                    Case cmbTantoCode.TabIndex

                        '*** 検索画面表示 ***
                        Using f As New WinFormBase.SEARCH_TANTO(0)
                            f.Owner = Me
                            If f.ShowDialog() = Windows.Forms.DialogResult.OK Then
                                If f.SelectItem IsNot Nothing Then
                                    '担当者コードセット
                                    LastFocusedControl.Text = f.SelectItem.Code

                                    txtNOUKIDATE0.Focus()
                                    Return
                                Else
                                    cmbTantoCode.Focus()
                                End If
                            End If
                        End Using

                    Case dbgMEISAI.TabIndex
                        If dbgMEISAI.Col = COL_SIIRECODE Then
                            '*** 検索画面表示 ***
                            Using f As New WinFormBase.SEARCH_SIIRE(0)
                                f.Owner = Me
                                If f.ShowDialog() = Windows.Forms.DialogResult.OK Then
                                    If f.SelectItem IsNot Nothing Then
                                        '担当者コードセット
                                        dbgMEISAI.Columns(COL_SIIRECODE).Value = f.SelectItem.Code
                                        dbgMEISAI.Focus()
                                        dbgMEISAI.Col = COL_SUU
                                        Return
                                    End If
                                End If
                            End Using

                            dbgMEISAI.Focus()
                            dbgMEISAI.UpdateData()
                        End If
                End Select

            Case SYSFC_PREVIEW
                'プレビュー

                Try
                    FunctionKey.ItemEnabled(SYSFC_PREVIEW) = False
                    Call subRep_Prnt(True)
                Finally
                    FunctionKey.ItemEnabled(SYSFC_PREVIEW) = True
                End Try

            Case SYSFC_EXECUT
                '登録

                '基本情報全項目入力エラーチェック
                If Not fncAllInputValidate() Then Exit Sub

                '確認メッセージ
                If MessageBoxEx.Show(MessageCode_Arg0.M001登録してもよろしいですか, PROGRAM_NAME) = Windows.Forms.DialogResult.No Then Exit Sub

                Using ts As System.Transactions.TransactionScope = New System.Transactions.TransactionScope()

                    '新規の場合、見積枝番を採番
                    If NUCheck(txtMITUMORIEDABAN.Text) = True Then
                        txtMITUMORIEDABAN.Text = ZeroPadding(daMIT0001.GetMITUMORIRENBAN(txtMITUMORINO.Text), txtMITUMORIEDABAN.MaxLength)
                    End If

                    '見積トラン全削除
                    Call daMIT0001.DeleteData_T_MITUMORI(txtMITUMORINO.Text, txtMITUMORIEDABAN.Text)

                    'トラン更新
                    Call subTranUpdate()

                    ts.Complete()
                End Using

                '確認メッセージ
                If MessageBoxEx.Show(MessageCode_Arg0.M162引き続き印刷してもよろしいですか, PROGRAM_NAME) = Windows.Forms.DialogResult.Yes Then
                    Call subRep_Prnt(False)
                End If

                'コンボボックス
                Call subInitCombo()

                '画面初期化
                Call subInitDisp(False)
        End Select
    End Sub

    ''' <summary>
    ''' トラン追加・更新
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub subTranUpdate()
        Dim UpdateData As New dsMIT0001
        Dim decMITUMORIEDABAN As Decimal
        Dim decOYA_MITUMORINO As Decimal
        Dim decOYA_MITUMORIEDABAN As Decimal
        Dim decSAI_MITUMORINO As Decimal
        Dim decSAI_MITUMORIEDABAN As Decimal
        Dim decSAN_MITUMORINO As Decimal
        Dim decSAN_MITUMORIEDABAN As Decimal
        Dim strKeisyouCode As String
        Dim decKigyoKbn As Decimal
        Dim dtmNoukiSt As Date
        Dim dtmNoukiEd As Date

        Using wcur As New WaitCursor

            If NUCheck(txtMITUMORIEDABAN.Text) Then
                decMITUMORIEDABAN = 0
            Else
                decMITUMORIEDABAN = CDec(txtMITUMORIEDABAN.Text)
            End If

            If NUCheck(txtSAI_MITUMORIEDABAN.Text) Then
                decSAI_MITUMORINO = 0
            Else
                decSAI_MITUMORINO = CDec(txtSAI_MITUMORINO.Text)
            End If

            If NUCheck(txtSAI_MITUMORIEDABAN.Text) Then
                decSAI_MITUMORIEDABAN = 0
            Else
                decSAI_MITUMORIEDABAN = CDec(txtSAI_MITUMORIEDABAN.Text)
            End If

            If NUCheck(txtSAN_MITUMORIEDABAN.Text) Then
                decSAN_MITUMORINO = 0
            Else
                decSAN_MITUMORINO = CDec(txtSAN_MITUMORINO.Text)
            End If

            If NUCheck(txtSAN_MITUMORIEDABAN.Text) Then
                decSAN_MITUMORIEDABAN = 0
            Else
                decSAN_MITUMORIEDABAN = CDec(txtSAN_MITUMORIEDABAN.Text)
            End If

            If NUCheck(cmbKEISYOUCODE.Text) Then
                strKeisyouCode = vbNullString
            Else
                strKeisyouCode = cmbKEISYOUCODE.Text
            End If

            decKigyoKbn = 0

            If IsDate(txtNOUKIDATE(0).Text) Then
                dtmNoukiSt = CDate(txtNOUKIDATE(0).Text)
            End If

            If IsDate(txtNOUKIDATE(1).Text) Then
                dtmNoukiEd = CDate(txtNOUKIDATE(1).Text)
            End If

            '見積ヘッダトラン追加・更新
            UpdateData.T_MITUMORIHEDUpdate.AddT_MITUMORIHEDUpdateRow(CDec(txtMITUMORINO.Text),
                                                                     decMITUMORIEDABAN,
                                                                     CDate(txtTEISYUTUDATE.Text),
                                                                     txtKokyakuCode.Text,
                                                                     cmbTantoCode.Text,
                                                                     strKeisyouCode,
                                                                     txtKoujiNo.Text,
                                                                     txtKoujiName.Text,
                                                                     txtKoujiBasyo.Text,
                                                                     dtmNoukiSt,
                                                                     dtmNoukiEd,
                                                                     txtKigen.Text,
                                                                     txtShiharaiJoken.Text,
                                                                     decOYA_MITUMORINO,
                                                                     decOYA_MITUMORIEDABAN,
                                                                     decSAI_MITUMORINO,
                                                                     decSAI_MITUMORIEDABAN,
                                                                     decSAN_MITUMORINO,
                                                                     decSAN_MITUMORIEDABAN,
                                                                     txtGKGENKAGAKU.Value,
                                                                     txtGKGAKU_NUKI.Value,
                                                                     txtGKTAX.Value,
                                                                     txtGKGAKU.Value,
                                                                     txtGKGAKU_NUKI.Value - txtGKGENKAGAKU.Value,
                                                                     txtD_BIKO.Text,
                                                                     txtMitsumoriJoken.Text,
                                                                     cmbMitumoriJouken.Text,
                                                                     0,
                                                                     1,
                                                                     CDec(lblSyosu.Text),
                                                                     PROGRAM_ID,
                                                                     TANTO_CODE)

            daMIT0001.UpdateData_T_MITUMORIHED(UpdateData)

            '見積トラン追加・更新
            Dim dt = CType(dbgMEISAI.DataSource, dsMIT0001.T_MITUMORISelectDataTable)
            For Each dr In dt
                '階層コード未設定（上位３階層）データは集計値表示用なので登録しない
                If NUCheck(dr.SUU) Then Continue For
                UpdateData.T_MITUMORIUpdate.AddT_MITUMORIUpdateRow(CDec(txtMITUMORINO.Text),
                                                                   decMITUMORIEDABAN,
                                                                   dr.KAISOCODE,
                                                                   dr.DAIKAMOKUCODE,
                                                                   dr.CYUKAMOKUCODE,
                                                                   dr.SYOKAMOKUCODE,
                                                                   dr.KAMOKU_HINMOKU,
                                                                   dr.HINSITU_KIKAKU_SIYO,
                                                                   dr.SIIRECODE,
                                                                   dr.TANI,
                                                                   dr.SUU,
                                                                   dr.KAKERITU,
                                                                   dr.GENTANKA,
                                                                   dr.TANKA,
                                                                   dr.GENKAGAKU,
                                                                   dr.GAKU,
                                                                   dr.GAKU_NUKI,
                                                                   dr.ARARIGAKU,
                                                                   dr.IKATU_KAKERITU,
                                                                   dr.G_BIKO,
                                                                   0,
                                                                   PROGRAM_ID,
                                                                   TANTO_CODE)
            Next

            Call daMIT0001.UpdateData_T_MITUMORI(UpdateData)
        End Using
    End Sub

    ''' <summary>
    ''' グリッド　行移動（上）
    ''' </summary>
    Private Sub DbgMeisaiRowMove(ByVal mode As String)

        Dim choiceRow = dbgMEISAI.Row

        '先頭行の場合
        If choiceRow = 0 Then Exit Sub

        '未入力行の場合
        If choiceRow = dbgMEISAI.RowCount Then Exit Sub

        If mode = "UP" Then
            '入力最初の行の場合
            If choiceRow = 1 Then Exit Sub
        Else
            '入力最終行の場合
            If choiceRow = dbgMEISAI.RowCount - 1 Then Exit Sub
        End If

        '選択している階層
        Dim choiceKaisoCode = dbgMEISAI(choiceRow, COL_KAISOCODE).ToString()
        '移動先の階層
        Dim kaiso1 = Utility.LeftBSA(choiceKaisoCode, Utility.LenBSA(choiceKaisoCode) - intKaisoKeta)
        Dim kaiso2 = Utility.RightBSA(choiceKaisoCode, intKaisoKeta)
        Dim moveValue As Integer
        If mode = "UP" Then
            moveValue = -1
        Else
            moveValue = 1
        End If
        Dim moveKaisoCode = kaiso1 + Utility.ZeroPadding(CStr(CDec(kaiso2) + moveValue), intKaisoKeta)

        '選択行と移動先の階層コードを入れ替え
        Dim rowKaisoCode1 As String
        Dim rowKaisoCode2 As String
        Dim dt = CType(dbgMEISAI.DataSource, dsMIT0001.T_MITUMORISelectDataTable)
        For Each dr In dt

            '上位の階層の場合、処理しない
            If Utility.LenBSA(dr.KAISOCODE) - Utility.LenBSA(choiceKaisoCode) < 0 Then Continue For

            rowKaisoCode1 = Utility.LeftBSA(dr.KAISOCODE, Utility.LenBSA(choiceKaisoCode))
            rowKaisoCode2 = Utility.RightBSA(dr.KAISOCODE, Utility.LenBSA(dr.KAISOCODE) - Utility.LenBSA(choiceKaisoCode))

            If rowKaisoCode1 = choiceKaisoCode Then
                dr.KAISOCODE = moveKaisoCode & rowKaisoCode2
                Continue For
            End If

            If rowKaisoCode1 = moveKaisoCode Then
                dr.KAISOCODE = choiceKaisoCode & rowKaisoCode2
                Continue For
            End If
        Next

        'ツリービューを入れ替え
        Dim moveNodeIndex As Integer
        For Each node As TreeNode In GetAllNodes(trvWorkInfo.Nodes)

            If NUCheck(node.Tag.ToString) Then Continue For

            '上位の階層の場合、処理しない
            If Utility.LenBSA(node.Tag.ToString) - Utility.LenBSA(choiceKaisoCode) < 0 Then Continue For

            rowKaisoCode1 = Utility.LeftBSA(node.Tag.ToString, Utility.LenBSA(choiceKaisoCode))
            rowKaisoCode2 = Utility.RightBSA(node.Tag.ToString, Utility.LenBSA(node.Tag.ToString) - Utility.LenBSA(choiceKaisoCode))

            '移動対象のノートの位置を保持
            If node.Tag.ToString = choiceKaisoCode Then
                moveNodeIndex = node.Index
            End If

            '選択行の入れ替え
            If rowKaisoCode1 = choiceKaisoCode Then
                node.Tag = moveKaisoCode & rowKaisoCode2
                Continue For
            End If

            '移動行の入れ替え
            If rowKaisoCode1 = moveKaisoCode Then
                node.Tag = choiceKaisoCode & rowKaisoCode2
                Continue For
            End If
        Next

        'グリッドにデータテーブルをソートしてセット
        DbgMeisaiSetBinding(dt, True)

        'ツリービューの移動
        Dim nodes = trvWorkInfo.SelectedNode.Nodes
        Dim moveNode = nodes(moveNodeIndex)
        nodes(moveNodeIndex).Remove()
        nodes.Insert(moveNodeIndex + moveValue, moveNode)

        '選択されたノードの明細情報を抽出
        Call subSelectedNodeDataPickUp()

        RaiseEvent TreeNodeAddInsertDelete(trvWorkInfo)

        dbgMEISAI.Row = choiceRow + moveValue
        dbgMEISAI.Col = COL_KAMOKU_HINMOKU
        dbgMEISAI.Focus()

        intMoveRowValue = dbgMEISAI.Row
    End Sub

    Private Sub ClickKamokuHinmokuButton()
        Dim kamokuType As frmMENT0002.enumKamokuType
        Dim kamokuCode As String
        Dim row = dbgMEISAI.Row

        '1行目の場合、処理しない
        If dbgMEISAI.Row = 0 Then Return

        'パラメータの設定
        Dim rows() = CType(dbgMEISAI.DataSource, dsMIT0001.T_MITUMORISelectDataTable).Select("KAISOCODE = '" & trvWorkInfo.SelectedNode.Tag.ToString & "'")

        If trvWorkInfo.SelectedNode.Level = 1 Then
            kamokuType = frmMENT0002.enumKamokuType.DKAMOKU
            kamokuCode = ""
        ElseIf Not NUCheck(rows(0).Item("DAIKAMOKUCODE").ToString) Then
            kamokuType = frmMENT0002.enumKamokuType.CKAMOKU
            kamokuCode = rows(0).Item("DAIKAMOKUCODE").ToString
        ElseIf Not NUCheck(rows(0).Item("CYUKAMOKUCODE").ToString) Then
            kamokuType = frmMENT0002.enumKamokuType.SKAMOKU
            kamokuCode = rows(0).Item("CYUKAMOKUCODE").ToString
        Else
            kamokuType = frmMENT0002.enumKamokuType.SEARCH
            kamokuCode = ""
        End If

        '*** 検索画面表示 ***
        Using f As New frmMENT0002(frmMENT0002.enumDispMode.SELECT_KAMOKU_HINMOKU, kamokuType, kamokuCode)
            f.Owner = Me
            f.ShowDialog()

            If f.outKamokuCode Is Nothing Then Return

            '新規行以外の場合、確認メッセージ表示
            If dbgMEISAI.Row <> dbgMEISAI.RowCount Then
                If MessageBoxEx.Show(MessageCode_Arg0.M178科目品目を変更しますか下位の階層との紐付けが外れる可能性がございます, PROGRAM_NAME) = Windows.Forms.DialogResult.No Then
                    Exit Sub
                End If
            End If

            '科目のデータの取得
            Dim dr = CType(daMENT0002.GetMeisai(f.outKamokuType, f.outKamokuCode, "", "").Rows(0), dsMENT0002.M_KAMOKURow)

            'データのセット
            Dim col As Integer
            If f.outKamokuType = frmMENT0002.enumKamokuType.DKAMOKU Then
                col = COL_DAIKAMOKUCODE
            ElseIf f.outKamokuType = frmMENT0002.enumKamokuType.CKAMOKU Then
                col = COL_CYUKAMOKUCODE
            Else
                col = COL_SYOKAMOKUCODE
            End If

            dbgMEISAI.Columns(col).Value = f.outKamokuCode
            dbgMEISAI.Columns(COL_KAMOKU_HINMOKU).Value = dr.NAME
            dbgMEISAI.Columns(COL_HINSITU_KIKAKU_SIYO).Value = dr.NAME2

            '合計行以外の場合
            If Not CheckGokeiLine(dbgMEISAI.Row) Then
                dbgMEISAI.Columns(COL_TANI).Value = dr.TANI
                dbgMEISAI.Columns(COL_GENTANKA).Value = dr.GENTANKA

                '金額の計算
                subDbgCalcKingaku("ONE")

                '見積/受注単価の反映
                If dr.MIT_JYU_TANAKA <> 0 Then
                    dbgMEISAI.Columns(COL_TANKA).Value = dr.MIT_JYU_TANAKA

                    '受注単価に変更が加わった場合、見積金額再計算
                    '受注金額（数量 * 見積単価）
                    dbgMEISAI.Columns(COL_GAKU).Value = Utility.Round(GetRoundValue(NZ(dbgMEISAI.Columns(COL_SUU).Value).ToString) * NZ(dbgMEISAI.Columns(COL_TANKA).Value), 0, CInt(strS_SCB_ROUND_MITKAKIN))
                    '受注金額税抜（数量 * 見積単価）
                    dbgMEISAI.Columns(COL_GAKU_NUKI).Value = Utility.Round(GetRoundValue(NZ(dbgMEISAI.Columns(COL_SUU).Value).ToString) * NZ(dbgMEISAI.Columns(COL_TANKA).Value), 0, CInt(strS_SCB_ROUND_MITKAKIN))
                    '計算結果桁数チェック
                    If CDec(dbgMEISAI.Columns(COL_GAKU).Value) > 999999999999 Then dbgMEISAI.Columns(COL_GAKU).Value = 999999999999
                    If CDec(dbgMEISAI.Columns(COL_GAKU_NUKI).Value) > 999999999999 Then dbgMEISAI.Columns(COL_GAKU_NUKI).Value = 999999999999
                End If

                'グリッドの確定
                DbgMeisaiSetBinding(dbgMEISAI.DataSource, True)
            End If
        End Using

        'ツリービューの更新
        TrvWorkInfoUpdate()

        'フォーカス移動
        dbgMEISAI.Row = row
        dbgMEISAI.Col = COL_KAMOKU_HINMOKU
        dbgMEISAI.Focus()

        intMoveRowValue = dbgMEISAI.Row
    End Sub

    ''' <summary>
    ''' キー情報検索処理
    ''' </summary>
    ''' <param name="intSearchMode">検索区分 1:見積Ｎｏ 3:再見積Ｎｏ 4:参照見積Ｎｏ</param>
    ''' <param name="decMitumoriNo">見積Ｎｏ</param>
    ''' <param name="decMitumoriEdaban">見積枝番</param>
    ''' <remarks></remarks>
    Private Function fncRead_KeyInfo(ByVal intSearchMode As Integer, ByVal decMitumoriNo As Decimal, ByVal decMitumoriEdaban As Decimal) As Boolean

        OutPutDebugLog(System.Reflection.MethodBase.GetCurrentMethod.Name)

        Dim dt = T_MITUMORI.fncSelectT_MITUMORIHED(decMitumoriNo, decMitumoriEdaban)

        If dt.Rows.Count = 0 Then
            MessageBoxEx.Show(CommonUtility.MessageCode_Arg0.M009該当データがありません, Me.Text)
            Return False
        End If

        If NUCheck(txtMITUMORIEDABAN.Text) Then
            TitleBar.EditMode = EditMode.Create
        Else
            TitleBar.EditMode = EditMode.Edit
        End If

        Dim dr = dt.Rows(0)

        '処理区分名、見積Ｎｏ、見積枝番
        '基本情報を親・再・参照見積Ｎｏよりコピーする場合、入力中の見積Ｎｏは上書きせず残す
        If intSearchMode = 1 Then
            txtMITUMORIEDABAN.Text = dr.Item("MITUMORIEDABAN").ToString.PadLeft(txtMITUMORIEDABAN.MaxLength, "0"c)
            lblMITUMORINO.Text = txtMITUMORINO.Text + "-" + txtMITUMORIEDABAN.Text
            cmbMITUMORINO.Text = lblMITUMORINO.Text
        End If
        '提出日付
        txtTEISYUTUDATE.Text = CDate(dr.Item("TEISYUTUDATE").ToString).ToString
        If txtTEISYUTUDATE.Text <> "    /  /" Then
            lblTeisyutuGengo.Text = "(" & GetCnvSW.SfncYearSW(CDate(txtTEISYUTUDATE.Text).ToString("yyyy/MM/dd"), True, True) & ")"
        Else
            lblTeisyutuGengo.Text = vbNullString
        End If
        '担当者
        cmbTantoCode.Text = dr.Item("TANTOCODE").ToString
        txtTantoName.Text = dr.Item("TANTONAME").ToString

        '納期
        If dr.Item("NOUKI_STA").Equals(DBNull.Value) Then
            txtNOUKIDATE(0).Text = ""
            lblNOUKIGENGO(0).Text = vbNullString
        Else
            txtNOUKIDATE(0).Text = CDate(dr.Item("NOUKI_STA").ToString).ToString
            If txtNOUKIDATE(0).Text <> "    /  /" Then
                lblNOUKIGENGO(0).Text = "(" & GetCnvSW.SfncYearSW(CDate(txtNOUKIDATE(0).Text).ToString("yyyy/MM/dd"), True, True) & ")"
            Else
                lblNOUKIGENGO(0).Text = vbNullString
            End If
        End If

        If dr.Item("NOUKI_END").Equals(DBNull.Value) Then
            txtNOUKIDATE(1).Text = ""
            lblNOUKIGENGO(1).Text = vbNullString
        Else
            txtNOUKIDATE(1).Text = CDate(dr.Item("NOUKI_END").ToString).ToString
            If txtNOUKIDATE(1).Text <> "    /  /" Then
                lblNOUKIGENGO(1).Text = "(" & GetCnvSW.SfncYearSW(CDate(txtNOUKIDATE(1).Text).ToString("yyyy/MM/dd"), True, True) & ")"
            Else
                lblNOUKIGENGO(1).Text = vbNullString
            End If
        End If

        If intSearchMode = 1 Then

            '再見積Ｎｏ、再見積枝番
            If dr.Item("SAI_MITUMORINO").ToString <> "0" Then
                cmbSAI_MITUMORINO.Text = vbNullString
                txtSAI_MITUMORIEDABAN.Text = dr.Item("SAI_MITUMORIEDABAN").ToString.PadLeft(txtSAI_MITUMORIEDABAN.MaxLength, "0"c)
                lblSAI_MITUMORINO.Text = txtSAI_MITUMORINO.Text + "-" + txtSAI_MITUMORIEDABAN.Text
                cmbSAI_MITUMORINO.Text = lblSAI_MITUMORINO.Text
            End If

            '参照見積Ｎｏ、参照見積枝番
            If dr.Item("SAN_MITUMORINO").ToString <> "0" Then
                cmbSAN_MITUMORINO.Text = vbNullString
                txtSAN_MITUMORINO.Text = dr.Item("SAN_MITUMORINO").ToString.PadLeft(txtSAN_MITUMORINO.MaxLength, "0"c)
                txtSAN_MITUMORIEDABAN.Text = dr.Item("SAN_MITUMORIEDABAN").ToString.PadLeft(txtSAN_MITUMORIEDABAN.MaxLength, "0"c)
                lblSAN_MITUMORINO.Text = txtSAN_MITUMORINO.Text + "-" + txtSAN_MITUMORIEDABAN.Text
                cmbSAN_MITUMORINO.Text = lblSAN_MITUMORINO.Text
            End If
        End If

        '敬称
        cmbKEISYOUCODE.Text = dr.Item("KEISYOUCODE").ToString
        txtKEISYOUNAME.Text = dr.Item("KEISYOUNAME").ToString
        '工事名称
        txtKoujiName.Text = dr.Item("KOUJINAME").ToString
        '工事番号
        txtKoujiNo.Text = dr.Item("KOUJINO").ToString
        '工事場所
        txtKoujiBasyo.Text = dr.Item("KOUJIBASYO").ToString
        '有効期限
        txtKigen.Text = dr.Item("YUKOKIGEN").ToString
        '支払条件
        txtShiharaiJoken.Text = dr.Item("SIHARAIJYOKEN").ToString
        '伝票備考
        txtD_BIKO.Text = dr.Item("D_BIKO").ToString
        '見積条件
        cmbMitumoriJouken.Text = dr.Item("MITUMORI_JOUKEN_FILE_NAME").ToString
        txtMitsumoriJoken.Text = dr.Item("MITUMORI_JOUKEN").ToString

        '数量小数点以下桁数
        lblSyosu.Text = dr.Item("SURYO_SYOSUIKAKETA").ToString
        lblSyosuName.Text = "数量小数点以下桁数：" & StrConv(lblSyosu.Text, VbStrConv.Wide) & "位"

        dbgMEISAI.Columns(COL_SUU).NumberFormat = "FormatText Event"

        blnSai_MitumoriNoChg = False
        blnSan_MitumoriNoChg = False

        Return True
    End Function

    ''' <summary>
    ''' 明細情報検索処理
    ''' </summary>
    ''' <param name="intSearchMode">チェック項目 1:見積Ｎｏ 2:親見積Ｎｏ 3:再見積Ｎｏ 4:参照見積Ｎｏ</param>
    ''' <param name="UpdateInsertAnswer">更新追加区分</param>
    ''' <remarks></remarks>
    Private Sub fncRead_MeisaiInfo(ByVal intSearchMode As Integer,
                                        ByVal UpdateInsertAnswer As Windows.Forms.DialogResult,
                                        ByVal dt As DataTable)

        '全体データ保存データセットに値を反映させる
        If dbgMEISAI.DataChanged Then dbgMEISAI.UpdateData()

        '明細の取得データをデータテーブルに変換する
        Dim dtSelect = ModifiDataTableToT_JYUTYUSelectDataTable(dt)

        '追加の場合
        Dim dtMeisai = CType(dbgMEISAI.DataSource, dsMIT0001.T_MITUMORISelectDataTable)

        If UpdateInsertAnswer = Windows.Forms.DialogResult.No And dtMeisai IsNot Nothing Then
            '表示済みデータに取得した追加用データを追加
            For Each dr In dtSelect.Rows

                '階層入力済みであれば先頭3桁に対して予め取得しておいた最終階層コードを加算する 最終階層 006　前 001 後 (6 + 1) = 007
                If NUCheck(dr.KAISOCODE) = False Then
                    '最終階層取得
                    Dim strLastKaiso = LeftBSA(GetLastKaiso(dtMeisai), intKaisoKeta)
                    Dim wkKaiso = dr.KAISOCODE.ToString

                    dr.KAISOCODE = ZeroPadding((NZ(LeftBSA(wkKaiso, intKaisoKeta)) + NZ(strLastKaiso)).ToString, intKaisoKeta) + Mid$(wkKaiso, intKaisoKeta + 1)
                End If

                dtMeisai.ImportRow(dr)
            Next

        Else
            '編集用の複製データ作成
            dtMeisai = dtSelect
        End If

        'グリッドにデータテーブルをソートしてセット
        DbgMeisaiSetBinding(dtMeisai)

        'ﾂﾘｰにｾｯﾄ
        fncTreeWorkInfoSet()
    End Sub

    Private Function ModifiDataTableToT_JYUTYUSelectDataTable(ByVal dt As DataTable) As dsMIT0001.T_MITUMORISelectDataTable
        Dim dtSelect As New dsMIT0001.T_MITUMORISelectDataTable

        For Each row As DataRow In dt.Rows
            Dim dr = CType(dtSelect.NewRow, dsMIT0001.T_MITUMORISelectRow)
            dr.KAMOKU_HINMOKU = row.Item("KAMOKU_HINMOKU").ToString
            dr.HINSITU_KIKAKU_SIYO = row.Item("HINSITU_KIKAKU_SIYO").ToString
            dr.SUU = row.Item("SUU").ToString
            dr.TANI = row.Item("TANI").ToString
            dr.TANKA = row.Item("TANKA").ToString
            dr.GAKU = row.Item("GAKU").ToString
            dr.GAKU_NUKI = row.Item("GAKU_NUKI").ToString
            dr.GENTANKA = row.Item("GENTANKA").ToString
            dr.GENKAGAKU = row.Item("GENKAGAKU").ToString
            dr.KAKERITU = row.Item("KAKERITU").ToString
            dr.G_BIKO = row.Item("G_BIKO").ToString
            dr.SIIRECODE = row.Item("SIIRECODE").ToString
            dr.SIIRENAME = row.Item("SIIRENAME").ToString
            dr.KAISOCODE = row.Item("KAISOCODE").ToString
            dr.ARARIGAKU = row.Item("ARARIGAKU").ToString
            dr.IKATU_KAKERITU = row.Item("IKATU_KAKERITU").ToString
            dr.DAIKAMOKUCODE = row.Item("DAIKAMOKUCODE").ToString
            dr.CYUKAMOKUCODE = row.Item("CYUKAMOKUCODE").ToString
            dr.SYOKAMOKUCODE = row.Item("SYOKAMOKUCODE").ToString
            dtSelect.Rows.Add(dr)
        Next

        Return dtSelect
    End Function

    ''' <summary>
    ''' 区分マスタデータ抽出
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub fncRead_M_KBN(ByVal strSiyouKbn As String, Optional ByVal strKbn As String = "")
        Dim logic As New M_KBNRead(strSiyouKbn, strKbn)

        dbM_KBNValue = logic.GetM_KBN
        If dbM_KBNValue.HasValue = True Then
            For intI As Integer = 0 To dbM_KBNValue.M_KBN.Count - 1
                Select Case strSiyouKbn
                    Case "06" : dbM_KBN_SIYOU06 = dbM_KBNValue
                End Select
            Next intI
        End If
    End Sub

    ''' <summary>
    ''' 基本設定マスタデータ抽出
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub fncRead_S_SCB(ByVal strCATEGORYID As String, Optional ByVal strDATAKEY As String = "")
        Dim logic As New S_SCBRead(strCATEGORYID, strDATAKEY)

        OutPutDebugLog(System.Reflection.MethodBase.GetCurrentMethod.Name)
        dbS_SCBValue = logic.GetS_SCB
        If dbS_SCBValue.HasValue = True Then
            For intI As Integer = 0 To dbS_SCBValue.S_SCB.Count - 1
                Select Case dbS_SCBValue.S_SCB(intI).CATEGORYID

                    Case "DISP_CTRL"
                        Select Case dbS_SCBValue.S_SCB(intI).DATAKEY
                            Case "DEFAULT_01" : strS_SCB_DEFAULT_01 = dbS_SCBValue.S_SCB(intI).DATA
                            Case "DEFAULT_02" : strS_SCB_DEFAULT_02 = dbS_SCBValue.S_SCB(intI).DATA
                            Case "DEFAULT_03" : strS_SCB_DEFAULT_03 = dbS_SCBValue.S_SCB(intI).DATA
                            Case "DEFAULT_04" : strS_SCB_DEFAULT_04 = dbS_SCBValue.S_SCB(intI).DATA
                        End Select

                    Case "INFO_JISYA"
                        Select Case dbS_SCBValue.S_SCB(intI).DATAKEY
                            Case "ADDRESS1" : strS_SCB_ADDRESS1 = dbS_SCBValue.S_SCB(intI).DATA
                            Case "ADDRESS2" : strS_SCB_ADDRESS2 = dbS_SCBValue.S_SCB(intI).DATA
                            Case "COMMENT1" : strS_SCB_COMMENT1 = dbS_SCBValue.S_SCB(intI).DATA
                            Case "EMAIL" : strS_SCB_EMAIL = dbS_SCBValue.S_SCB(intI).DATA
                            Case "FAXNO" : strS_SCB_FAXNO = dbS_SCBValue.S_SCB(intI).DATA
                            Case "ISOQAR" : strS_SCB_ISOQAR = dbS_SCBValue.S_SCB(intI).DATA
                            Case "JISYANAME" : strS_SCB_JISYANAME = dbS_SCBValue.S_SCB(intI).DATA
                            Case "POSTNO" : strS_SCB_POSTNO = dbS_SCBValue.S_SCB(intI).DATA
                            Case "TELNO" : strS_SCB_TELNO = dbS_SCBValue.S_SCB(intI).DATA
                            Case "WEB" : strS_SCB_WEB = dbS_SCBValue.S_SCB(intI).DATA
                        End Select

                    Case "SYSTEM"
                        Select Case dbS_SCBValue.S_SCB(intI).DATAKEY
                            Case "ROUND_ARARIRITU" : strS_SCB_ROUND_ARARIRITU = dbS_SCBValue.S_SCB(intI).DATA
                            Case "ROUND_GENKAKIN" : strS_SCB_ROUND_GENKAKIN = dbS_SCBValue.S_SCB(intI).DATA
                            Case "ROUND_GENTANKA" : strS_SCB_ROUND_GENTANKA = dbS_SCBValue.S_SCB(intI).DATA
                            Case "ROUND_MITKAKIN" : strS_SCB_ROUND_MITKAKIN = dbS_SCBValue.S_SCB(intI).DATA
                            Case "ROUND_MITTANKA" : strS_SCB_ROUND_MITTANKA = dbS_SCBValue.S_SCB(intI).DATA
                            Case "ROUND_SYOKARITU" : strS_SCB_ROUND_SYOKARITU = dbS_SCBValue.S_SCB(intI).DATA
                            Case "ROUND_TAX" : strS_SCB_ROUND_TAX = dbS_SCBValue.S_SCB(intI).DATA
                            Case "ROUND_MITSUURYO" : strS_SCB_ROUND_MITSUURYO = dbS_SCBValue.S_SCB(intI).DATA
                            Case "ZEIKBN" : strS_SCB_ZEIKBN = dbS_SCBValue.S_SCB(intI).DATA
                        End Select
                End Select
            Next intI
        End If
    End Sub

    ''' <summary>
    ''' グリッド設定
    ''' </summary>
    Private Sub subInitGrid()

        OutPutDebugLog(System.Reflection.MethodBase.GetCurrentMethod.Name)

        '行移動の背景色をクリアする
        intMoveRowValue = 0

        With dbgMEISAI

            .DataView = DataViewEnum.Normal
            .LinesPerRow = 0

            If .Columns.Count = 0 Then
                '***** 共通 *****
                With .Columns
                    .Add(New C1DataColumn("", "KAMOKU_HINMOKU", Type.GetType("System.String")))
                    .Add(New C1DataColumn("", "HINSITU_KIKAKU_SIYO", Type.GetType("System.String")))
                    .Add(New C1DataColumn("", "SUU", Type.GetType("System.Decimal")))
                    .Add(New C1DataColumn("", "TANI", Type.GetType("System.String")))
                    .Add(New C1DataColumn("", "TANKA", Type.GetType("System.Decimal")))
                    .Add(New C1DataColumn("", "GAKU", Type.GetType("System.Decimal")))
                    .Add(New C1DataColumn("", "GAKU_NUKI", Type.GetType("System.Decimal")))
                    .Add(New C1DataColumn("", "GENTANKA", Type.GetType("System.Decimal")))
                    .Add(New C1DataColumn("", "GENKAGAKU", Type.GetType("System.Decimal")))
                    .Add(New C1DataColumn("", "KAKERITU", Type.GetType("System.Decimal")))
                    .Add(New C1DataColumn("", "G_BIKO", Type.GetType("System.String")))
                    .Add(New C1DataColumn("", "SIIRECODE", Type.GetType("System.String")))
                    .Add(New C1DataColumn("", "SIIRENAME", Type.GetType("System.String")))
                    .Add(New C1DataColumn("", "KAISOCODE", Type.GetType("System.String")))
                    .Add(New C1DataColumn("", "ARARIGAKU", Type.GetType("System.Decimal")))
                    .Add(New C1DataColumn("", "IKATU_KAKERITU", Type.GetType("System.Decimal")))
                    .Add(New C1DataColumn("", "DAIKAMOKUCODE", Type.GetType("System.String")))
                    .Add(New C1DataColumn("", "CYUKAMOKUCODE", Type.GetType("System.String")))
                    .Add(New C1DataColumn("", "SYOKAMOKUCODE", Type.GetType("System.String")))
                End With
            Else
                .Columns(COL_KAMOKU_HINMOKU).ValueItems.Presentation = PresentationEnum.Normal
                .Columns(COL_HINSITU_KIKAKU_SIYO).ValueItems.Presentation = PresentationEnum.Normal
                .Columns(COL_SIIRECODE).ValueItems.Presentation = PresentationEnum.Normal
                .Columns(COL_SIIRENAME).ValueItems.Presentation = PresentationEnum.ComboBox
                .Columns(COL_SUU).ValueItems.Presentation = PresentationEnum.Normal
                .Columns(COL_TANI).ValueItems.Presentation = PresentationEnum.ComboBox
                .Columns(COL_TANKA).ValueItems.Presentation = PresentationEnum.Normal
                .Columns(COL_GAKU).ValueItems.Presentation = PresentationEnum.Normal
                .Columns(COL_GAKU_NUKI).ValueItems.Presentation = PresentationEnum.Normal
                .Columns(COL_GENTANKA).ValueItems.Presentation = PresentationEnum.Normal
                .Columns(COL_GENKAGAKU).ValueItems.Presentation = PresentationEnum.Normal
                .Columns(COL_KAKERITU).ValueItems.Presentation = PresentationEnum.Normal
                .Columns(COL_G_BIKO).ValueItems.Presentation = PresentationEnum.Normal
                .Columns(COL_KAISOCODE).ValueItems.Presentation = PresentationEnum.Normal
                .Columns(COL_IKATU_KAKERITU).ValueItems.Presentation = PresentationEnum.Normal
                .Columns(COL_ARARIGAKU).ValueItems.Presentation = PresentationEnum.Normal
                .Columns(COL_DAIKAMOKUCODE).ValueItems.Presentation = PresentationEnum.Normal
                .Columns(COL_CYUKAMOKUCODE).ValueItems.Presentation = PresentationEnum.Normal
                .Columns(COL_SYOKAMOKUCODE).ValueItems.Presentation = PresentationEnum.Normal
            End If

            '*** TrueDBGrid Caption プロパティ設定 ***
            .Columns(COL_KAMOKU_HINMOKU).Caption = "科目・品目"
            .Columns(COL_HINSITU_KIKAKU_SIYO).Caption = "品質・規格・仕様"
            .Columns(COL_SUU).Caption = "数量"
            .Columns(COL_TANI).Caption = "単位"
            .Columns(COL_TANKA).Caption = "見積単価"
            .Columns(COL_GAKU_NUKI).Caption = "見積金額"
            .Columns(COL_GENTANKA).Caption = "原単価"
            .Columns(COL_GENKAGAKU).Caption = "原価金額"
            .Columns(COL_KAKERITU).Caption = "掛率(%)"
            .Columns(COL_G_BIKO).Caption = "備考"
            .Columns(COL_SIIRECODE).Caption = "担当下請"

            '*** TrueDBGrid DataWidth プロパティ設定 ***
            .Columns(COL_KAMOKU_HINMOKU).DataWidth = 40
            .Columns(COL_HINSITU_KIKAKU_SIYO).DataWidth = 40
            .Columns(COL_SUU).DataWidth = 11
            .Columns(COL_TANI).DataWidth = 10
            .Columns(COL_TANKA).DataWidth = 12
            .Columns(COL_GAKU_NUKI).DataWidth = 12
            .Columns(COL_GENTANKA).DataWidth = 12
            .Columns(COL_GENKAGAKU).DataWidth = 12
            .Columns(COL_KAKERITU).DataWidth = 8
            .Columns(COL_G_BIKO).DataWidth = 40
            .Columns(COL_SIIRECODE).DataWidth = 8

            '*** TrueDBGrid Width プロパティ設定 ***
            .Splits(0).DisplayColumns(COL_KAMOKU_HINMOKU).Width = (9 + 5) * 8
            .Splits(0).DisplayColumns(COL_HINSITU_KIKAKU_SIYO).Width = (9 + 5) * 8
            .Splits(0).DisplayColumns(COL_SUU).Width = (2 + 4) * 8
            .Splits(0).DisplayColumns(COL_TANI).Width = (2 + 4) * 8
            .Splits(0).DisplayColumns(COL_TANKA).Width = (5 + 4) * 8
            .Splits(0).DisplayColumns(COL_GAKU_NUKI).Width = (5 + 4) * 8
            .Splits(0).DisplayColumns(COL_GENTANKA).Width = (5 + 4) * 8
            .Splits(0).DisplayColumns(COL_GENKAGAKU).Width = (5 + 4) * 8
            .Splits(0).DisplayColumns(COL_KAKERITU).Width = (3 + 4) * 8
            .Splits(0).DisplayColumns(COL_G_BIKO).Width = (6 + 4) * 8
            .Splits(0).DisplayColumns(COL_SIIRECODE).Width = (7 + 4) * 8

            .RecordSelectors = False 'レコードセレクタ非表示（グリッド左側）

            With .Splits(0)
                For intIndex As Integer = 0 To dbgMEISAI.Columns.Count - 1
                    .DisplayColumns(intIndex).Visible = CType(IIf(intIndex < COL_COUNT, True, False), Boolean)
                Next
                .DisplayColumns(COL_SIIRENAME).Visible = False
                .DisplayColumns(COL_GAKU).Visible = False
                .DisplayColumns(COL_KAISOCODE).Visible = False
                .DisplayColumns(COL_ARARIGAKU).Visible = False
                .DisplayColumns(COL_IKATU_KAKERITU).Visible = False
                .DisplayColumns(COL_DAIKAMOKUCODE).Visible = False
                .DisplayColumns(COL_CYUKAMOKUCODE).Visible = False
                .DisplayColumns(COL_SYOKAMOKUCODE).Visible = False
            End With

            '*** TrueDBGrid Locked プロパティ設定 ***
            For intIndex As Integer = 0 To dbgMEISAI.Columns.Count - 1
                .Splits(0).DisplayColumns(intIndex).Locked = False
            Next

            '*** 共通設定 ***
            GridSetup(dbgMEISAI, GridSetupAllows.AllowAll, False, False, False)

            '個別の設定はGridSetupの後
            '全般
            .EditDropDown = False                                                   '編集にドロップダウンウインドウを使用するか？
            .AllowDrop = False                                                      'ドロップ可能
            .Enabled = True
            .AllowColMove = False
            .AllowColSelect = False
            .AllowRowSizing = RowSizingEnum.None
            .AllowRowSelect = True

            '表示
            .ColumnHeaders = True                                                   '列タイトルの表示
            .MarqueeStyle = MarqueeEnum.FloatingEditor                              '行選択・ハイライト表示
            .BorderStyle = BorderStyle.FixedSingle                                  'グリッドの境界線スタイル
            .RowDivider.Style = LineStyleEnum.Single                                '行の境界線スタイル
            .RowDivider.Color = Color.FromArgb(224, 224, 224)
            .FetchRowStyles = True                                                  'FetchRowStyleイベントを発生させるかどうかを設定
            .Font = New Font("ＭＳ ゴシック", 9, FontStyle.Regular, GraphicsUnit.Point, 128)
            .ExtendRightColumn = True                                               'デッドエリア（隙間）を埋める
            .AlternatingRows = False

            .ContextMenuStrip = New ContextMenuStrip

            'Splits 単位
            .Splits(0).HScrollBar.Style = ScrollBarStyleEnum.Always
            .Splits(0).VScrollBar.Style = ScrollBarStyleEnum.Always
            .Splits(0).AllowFocus = True
            .Splits(0).Locked = False
            .Splits(0).MarqueeStyle = MarqueeEnum.FloatingEditor                    'スプリットのﾏｰｷｰｽﾀｲﾙ(選択行・セルの設定)

            '*** ヘッダー ***
            '仕切り線
            .HeadingStyle.Borders.Color = Color.FromArgb(224, 224, 224)
            .HeadingStyle.Font = New Font("メイリオ", 8, FontStyle.Regular, GraphicsUnit.Point, 128)

            '*** TrueDBGrid HeadingStyle.HorizontalAlignment プロパティ設定 ***
            For intIndex As Integer = 0 To dbgMEISAI.Columns.Count - 1
                .Splits(0).DisplayColumns(intIndex).HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            Next

            '*** TrueDBGrid ColumnDivider.Style プロパティ設定 ***
            For intIndex As Integer = 0 To dbgMEISAI.Columns.Count - 1
                .Splits(0).DisplayColumns(intIndex).ColumnDivider.Color = Color.FromArgb(224, 224, 224)
            Next

            '*** TrueDBGrid Style.HorizontalAlignment プロパティ設定 ***
            '科目　品種　仕入　備考は左揃え
            .Splits(0).DisplayColumns(COL_KAMOKU_HINMOKU).Style.HorizontalAlignment = AlignHorzEnum.Near
            .Splits(0).DisplayColumns(COL_HINSITU_KIKAKU_SIYO).Style.HorizontalAlignment = AlignHorzEnum.Near
            .Splits(0).DisplayColumns(COL_TANI).Style.HorizontalAlignment = AlignHorzEnum.Near
            .Splits(0).DisplayColumns(COL_SUU).Style.HorizontalAlignment = AlignHorzEnum.Far
            .Splits(0).DisplayColumns(COL_GENTANKA).Style.HorizontalAlignment = AlignHorzEnum.Far
            .Splits(0).DisplayColumns(COL_GENKAGAKU).Style.HorizontalAlignment = AlignHorzEnum.Far
            .Splits(0).DisplayColumns(COL_KAKERITU).Style.HorizontalAlignment = AlignHorzEnum.Far
            .Splits(0).DisplayColumns(COL_TANKA).Style.HorizontalAlignment = AlignHorzEnum.Far
            .Splits(0).DisplayColumns(COL_GAKU_NUKI).Style.HorizontalAlignment = AlignHorzEnum.Far
            .Splits(0).DisplayColumns(COL_G_BIKO).Style.HorizontalAlignment = AlignHorzEnum.Near
            .Splits(0).DisplayColumns(COL_SIIRECODE).Style.HorizontalAlignment = AlignHorzEnum.Near

            '*** TrueDBGrid NumberFormat プロパティ設定 ***
            .Columns(COL_SUU).NumberFormat = "FormatText Event"
            .Columns(COL_GENTANKA).NumberFormat = "FormatText Event"
            .Columns(COL_GENKAGAKU).NumberFormat = "FormatText Event"
            .Columns(COL_KAKERITU).NumberFormat = "FormatText Event"
            .Columns(COL_TANKA).NumberFormat = "FormatText Event"
            .Columns(COL_GAKU_NUKI).NumberFormat = "FormatText Event"

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

            '担当下請
            ' コンボボックスを設定します
            subRefreshComboSiire()

            '単位
            ' コンボボックスを設定します
            Dim co1 = .Columns(COL_TANI)
            With co1.ValueItems
                .Values.Clear()
                .Values.Add(New ValueItem("", ""))
                For intI As Integer = 0 To dbM_KBN_SIYOU06.M_KBN.Count - 1
                    .Values.Add(New ValueItem(dbM_KBN_SIYOU06.M_KBN(intI).KBNNAME, dbM_KBN_SIYOU06.M_KBN(intI).KBNNAME))
                Next intI
                .Presentation = PresentationEnum.ComboBox
                .Translate = True
                .MaxComboItems = 10
            End With

            .Splits(0).DisplayColumns(COL_TANI).Button = CType(IIf(.Splits(0).DisplayColumns(COL_TANI).Locked = True, False, True), Boolean)

        End With

    End Sub

    ''' <summary>
    ''' 工事内訳情報表示
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub fncTreeWorkInfoSet()
        Dim intKAISO As Integer = 0     '第３階層以下計算用
        Dim intKaisoCnt(0 To (1 + intKaisoSuu)) As Integer      '階層追加用インデックス（上位２階層固定 + 下位１０階層）
        Dim strKAISOCODE As String = ""

        OutPutDebugLog(System.Reflection.MethodBase.GetCurrentMethod.Name)

        '階層数初期化
        For intI As Integer = 0 To UBound(intKaisoCnt)
            intKaisoCnt(intI) = -1
        Next intI

        'ﾂﾘｰ初期化
        trvWorkInfo.Nodes.Clear()

        '第１階層．元請名
        trvWorkInfo.Nodes.Add(txtKokyakuName.Text)
        intKaisoCnt(0) += 1
        trvWorkInfo.Nodes(intKaisoCnt(0)).Name = txtKokyakuName.Text
        trvWorkInfo.Nodes(intKaisoCnt(0)).Tag = ""
        '工事件数（第２階層）初期化
        intKaisoCnt(1) = -1

        '第２階層．工事名
        trvWorkInfo.Nodes(intKaisoCnt(0)).Nodes.Add(txtKoujiName.Text)
        intKaisoCnt(1) += 1
        trvWorkInfo.Nodes(intKaisoCnt(0)).Nodes(intKaisoCnt(1)).Name = txtKoujiName.Text
        trvWorkInfo.Nodes(intKaisoCnt(0)).Nodes(intKaisoCnt(1)).Tag = ""

        '大科目件数（第３階層）初期化
        intKaisoCnt(2) = -1

        'ノードを追加する
        Dim dt = CType(dbgMEISAI.DataSource, dsMIT0001.T_MITUMORISelectDataTable)
        For Each dr In dt

            '明細の1行目は処理しない
            If dr.SUU = "" Then Continue For

            '明細行の階層を取得する
            intKAISO = CInt(Utility.LenBSA(dr.KAISOCODE) / intKaisoKeta)

            '第３階層～第１２階層の処理
            If 1 <= intKAISO And intKAISO <= 10 Then
                Dim idx As Integer
                Dim node As TreeNode
                Dim nodeCollection As TreeNodeCollection

                '第３階層～第１２階層のノードコレクションの取得
                node = trvWorkInfo.Nodes(intKaisoCnt(0)).Nodes(intKaisoCnt(1))
                For idx = 2 To intKAISO
                    node = node.Nodes(intKaisoCnt(idx))
                Next idx
                nodeCollection = node.Nodes

                nodeCollection.Add(dr.KAMOKU_HINMOKU)

                intKaisoCnt(intKAISO + 1) += 1

                '第３階層～第１２階層のノードの取得、階層コードの取得
                node = trvWorkInfo.Nodes(intKaisoCnt(0)).Nodes(intKaisoCnt(1)).Nodes(intKaisoCnt(2))
                strKAISOCODE = (intKaisoCnt(2) + 1).ToString.PadLeft(intKaisoKeta, "0"c)
                For idx = 3 To intKAISO + 1
                    node = node.Nodes(intKaisoCnt(idx))
                    strKAISOCODE = strKAISOCODE & (intKaisoCnt(idx) + 1).ToString.PadLeft(intKaisoKeta, "0"c)
                Next idx

                node.Name = dr.KAMOKU_HINMOKU

                '追加分を考慮し表示内容に沿った階層コードに再設定
                node.Tag = strKAISOCODE
                dr.KAISOCODE = strKAISOCODE

                '中科目件数　初期化
                intKaisoCnt(intKAISO + 2) = -1
            End If
        Next

        '作成後にツリーを開く
        trvWorkInfo.ExpandAll()

        RaiseEvent TreeNodeAddInsertDelete(trvWorkInfo)
    End Sub

    ''' <summary>
    ''' 選択されたノードの明細情報を抽出
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub subSelectedNodeDataPickUp()

        OutPutDebugLog(System.Reflection.MethodBase.GetCurrentMethod.Name)

        '１階層名の場合、グリッドクリア
        If trvWorkInfo.SelectedNode.Level = 0 Then
            'グリッドにデータテーブルをソートしてセット
            DbgMeisaiSetBinding(dbgMEISAI.DataSource)
            Return
        End If

        'データを複製
        Dim dtCopy = dbgMEISAI.DataSource

        '1行目のデータを削除
        For i As Integer = 0 To dtCopy.Rows.Count - 1
            Dim dr = CType(dtCopy.Rows(i), dsMIT0001.T_MITUMORISelectRow)
            If dr.SUU = "" Then
                dr.Delete()
                Exit For
            End If
        Next

        '削除後のコミット
        dtCopy.AcceptChanges()

        '1行目のデータを追加
        Dim drCopy = CType(dtCopy.NewRow(), dsMIT0001.T_MITUMORISelectRow)
        drCopy.KAMOKU_HINMOKU = ""
        drCopy.HINSITU_KIKAKU_SIYO = ""
        drCopy.SIIRECODE = ""
        drCopy.SIIRENAME = ""
        drCopy.SUU = ""
        drCopy.TANI = ""
        drCopy.GENTANKA = ""
        drCopy.GENKAGAKU = ""
        drCopy.KAKERITU = strS_SCB_DEFAULT_03
        drCopy.TANKA = ""
        drCopy.GAKU = ""
        drCopy.GAKU_NUKI = ""
        drCopy.ARARIGAKU = ""
        drCopy.IKATU_KAKERITU = strS_SCB_DEFAULT_03
        drCopy.G_BIKO = ""
        drCopy.KAISOCODE = trvWorkInfo.SelectedNode.Tag.ToString + "000"
        drCopy.DAIKAMOKUCODE = ""
        drCopy.CYUKAMOKUCODE = ""
        drCopy.SYOKAMOKUCODE = ""
        dtCopy.Rows.Add(drCopy)

        'グリッドにデータテーブルをソートしてセット
        DbgMeisaiSetBinding(dtCopy)

        '明細行が存在すれば一括掛率を一つ目のレコードより取得してセットしなおす
        If dbgMEISAI.RowCount > 1 Then
            dbgMEISAI(0, COL_KAKERITU) = dbgMEISAI(1, COL_IKATU_KAKERITU)
        End If

        '表示中の階層コードを保持
        trvWorkInfo.Tag = trvWorkInfo.SelectedNode.Level
    End Sub

    ''' <summary>
    ''' グリッドの合計行の計算
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DbgGridUpdateData(ByVal dtMeisai As dsMIT0001.T_MITUMORISelectDataTable)
        Dim intKaiso As Integer     '階層
        Dim strKaisoCode As String  '階層コード
        Dim dt As New dsMIT0001.T_MITUMORISelectDataTable

        'ツリービューのタグの階層が上位１階層なら処理終了
        If NUCheck(trvWorkInfo.Tag) Then Exit Sub
        If CDec(trvWorkInfo.Tag) < 1 Then Exit Sub

        strKaisoCode = ""

        Dim dr As dsMIT0001.T_MITUMORISelectRow
        For intI = dtMeisai.Rows.Count - 1 To 0 Step -1
            dr = dtMeisai.Rows(intI)

            '1行目は対象外
            If NUCheck(dr.SUU) Then Continue For

            '最初の１件目
            If strKaisoCode = vbNullString Then
                '階層保存
                intKaiso = CInt(Utility.LenBSA(dr.KAISOCODE) / intKaisoKeta)
                '階層コード保存
                strKaisoCode = dr.KAISOCODE
            End If

            '階層が変わらない
            If intKaiso = CInt(Utility.LenBSA(dr.KAISOCODE) / intKaisoKeta) Then Continue For

            '上の階層に上がった
            If intKaiso > CInt(Utility.LenBSA(dr.KAISOCODE) / intKaisoKeta) Then
                Dim decMKGENKAGAKU = 0
                Dim decMKGAKU = 0
                Dim decMKGaku_Nuki = 0
                Dim decMKARARIGAKU = 0

                '上の階層にあがった段階で自階層を含まない１階層下の合計値を取得　なんとかうまいこと処理を組み替えたい・・・
                For Each dr2 In dtMeisai
                    If dr.KAISOCODE = LeftBSA(dr2.KAISOCODE, LenBSA(dr.KAISOCODE)) _
                            AndAlso Not dr.KAISOCODE = dr2.KAISOCODE _
                            AndAlso ((LenBSA(dr.KAISOCODE) + intKaisoKeta) = LenBSA(dr2.KAISOCODE)) Then
                        decMKGENKAGAKU += NZ(dr2.GENKAGAKU)
                        decMKGAKU += NZ(dr2.GAKU)
                        decMKGaku_Nuki += NZ(dr2.GAKU_NUKI)
                        decMKARARIGAKU += NZ(dr2.ARARIGAKU)
                    End If
                Next

                dr.SIIRECODE = ""                           '担当下請
                dr.SIIRENAME = ""                           '担当下請
                dr.SUU = "1"                                '数量
                dr.TANI = "式"                              '単位
                dr.GENTANKA = "0"                           '原単価
                dr.GENKAGAKU = decMKGENKAGAKU               '原価金額
                dr.KAKERITU = "0.00"                        '掛率
                dr.TANKA = "0"                              '受注単価
                dr.GAKU = decMKGAKU                         '受注金額
                dr.GAKU_NUKI = decMKGaku_Nuki               '見積金額税抜
                dr.ARARIGAKU = decMKARARIGAKU               '粗利金額
            End If

            '階層保存
            intKaiso = CInt(Utility.LenBSA(dr.KAISOCODE) / intKaisoKeta)
            '階層コード保存
            strKaisoCode = dr.KAISOCODE
        Next
    End Sub

    ''' <summary>
    ''' 見積情報をコピーする
    ''' </summary>
    ''' <param name="intSearchMode">検索区分 1:見積Ｎｏ 3:再見積Ｎｏ 4:参照見積Ｎｏ</param>
    ''' <param name="decMitumoriNo">見積Ｎｏ</param>
    ''' <param name="decMitumoriEdaban">見積枝番</param>
    ''' <remarks></remarks>
    Private Function fncKeyInfoCopy(ByVal intSearchMode As Integer, ByVal decMitumoriNo As Decimal, ByVal decMitumoriEdaban As Decimal) As Boolean

        Dim UpdateInsertAnswer As Windows.Forms.DialogResult

        OutPutDebugLog(System.Reflection.MethodBase.GetCurrentMethod.Name)

        '該当データの存在チェック
        Dim dt = T_MITUMORI.fncSelectT_MITUMORIHED(decMitumoriNo, decMitumoriEdaban, 1)

        If dt.Rows.Count = 0 Then
            MessageBoxEx.Show(CommonUtility.MessageCode_Arg0.M009該当データがありません, Me.Text)
            Return False
        End If

        '見積情報の取得
        Dim dtMeisai = T_MITUMORI.fncSelectT_MITUMORI(decMitumoriNo, decMitumoriEdaban)

        If intSearchMode = 1 Then
            '上書き
            UpdateInsertAnswer = Windows.Forms.DialogResult.Yes

        Else
            Select Case intSearchMode
                Case 3 : blnSai_MitumoriNoChg = False
                Case 4 : blnSan_MitumoriNoChg = False
            End Select

            '確認メッセージ
            If MessageBoxEx.Show(MessageCode_Arg0.M158指定した見積情報をコピーしますか, PROGRAM_NAME) = Windows.Forms.DialogResult.No Then
                Return True
            End If

            'この時点でツリーがまだ何もセットされていない状態(データ読み込みしていない)であればメッセージは表示せずに上書きとする
            If trvWorkInfo.Nodes.Count > 0 Then
                UpdateInsertAnswer = MessageBoxEx.Show(MessageCode_Arg0.M159コピーする場合は上書きにしますか_はい上書き_いいえ追加, PROGRAM_NAME)
                If UpdateInsertAnswer = Windows.Forms.DialogResult.Cancel Then
                    Return True
                End If
            Else
                '強制的に上書きセット
                UpdateInsertAnswer = Windows.Forms.DialogResult.Yes
            End If
        End If

        Try
            RemoveHandler trvWorkInfo.AfterSelect, AddressOf trvWorkInfo_AfterSelect

            'ヘッダ部キー情報の書換は上書き時のみ
            If UpdateInsertAnswer = Windows.Forms.DialogResult.Yes Then
                '----- キー情報検索処理 -----
                If Not fncRead_KeyInfo(intSearchMode, decMitumoriNo, decMitumoriEdaban) Then
                    Return False
                End If
            End If

            '----- 明細情報検索 -----
            fncRead_MeisaiInfo(intSearchMode, UpdateInsertAnswer, dtMeisai)

        Finally
            AddHandler trvWorkInfo.AfterSelect, AddressOf trvWorkInfo_AfterSelect
        End Try

        'データ抽出後は2階層を選択した状態とする
        trvWorkInfo.SelectedNode = trvWorkInfo.Nodes(0).Nodes(0)

        '一番上にスクロールバーがくるように調整
        If trvWorkInfo.Nodes.Count <> 0 Then
            trvWorkInfo.Nodes(0).EnsureVisible()
        End If

        Return True

    End Function

    ''' <summary>
    ''' グリッドの確定
    ''' </summary>
    Private Sub DbgMeisaiSetBinding(ByVal dtMeisai As dsMIT0001.T_MITUMORISelectDataTable, Optional ByVal rowReSelect As Boolean = False)
        Dim dt As New dsMIT0001.T_MITUMORISelectDataTable
        Dim row = dbgMEISAI.Row

        dbgMEISAI.UpdateData()

        'データテーブルをソート
        For Each drMeisai In dtMeisai.Select("", "KAISOCODE ASC")
            dt.ImportRow(drMeisai)
        Next

        'グリッドの合計行の計算
        DbgGridUpdateData(dt)

        'グリッドにデータテーブルをセット
        dbgMEISAI.SetDataBinding(dt, "", True)

        '選択している階層のデータを表示
        If trvWorkInfo.SelectedNode Is Nothing Then Return

        '階層コードの取得
        Dim strKaisoCode = trvWorkInfo.SelectedNode.Tag.ToString
        '1階層目の場合、取得できない文字を設定
        If trvWorkInfo.SelectedNode.Level = 0 Then strKaisoCode = "x"

        '対象の階層のデータをグリッドに表示
        Dim cm As CurrencyManager = Me.BindingContext(dbgMEISAI.DataSource)
        Dim dv As DataView = cm.List
        dv.RowFilter = "KAISOCODE Like '" & strKaisoCode & "%' AND LEN(KAISOCODE) = " & Utility.LenBSA(strKaisoCode) + intKaisoKeta
        dv.Sort = "KAISOCODE"

        If rowReSelect Then dbgMEISAI.Row = row

        '合計計算
        subDbgSumMeisai()
        subDbgSumGokei()
    End Sub

    Private Sub subDbgSumMeisai()
        Dim decMKGenkagaku As Decimal = 0
        Dim decMKGaku_Nuki As Decimal = 0
        Dim decMKARARIRITU As Decimal = 0

        Dim dt = CType(dbgMEISAI.DataSource, dsMIT0001.T_MITUMORISelectDataTable)
        For Each dr In dt
            '選択中の階層の明細以外の場合
            If Utility.LenBSA(dr.KAISOCODE) <> Utility.LenBSA(trvWorkInfo.SelectedNode.Tag) + intKaisoKeta Then Continue For
            If Utility.LeftBSA(dr.KAISOCODE, Utility.LenBSA(trvWorkInfo.SelectedNode.Tag)) <> trvWorkInfo.SelectedNode.Tag Then Continue For
            '1行目のデータの場合
            If NUCheck(dr.SUU) Then Continue For

            decMKGenkagaku += dr.GENKAGAKU
            decMKGaku_Nuki += dr.GAKU_NUKI
        Next

        '【明細計】原価額
        If decMKGenkagaku > 999999999999 Then decMKGenkagaku = 999999999999 '原価金額計
        txtMKGENKAGAKU.Text = Format(decMKGenkagaku, "#,##0")
        '【明細計】受注額税抜
        If decMKGaku_Nuki > 999999999999 Then decMKGaku_Nuki = 999999999999 '受注金額計
        txtMKGAKU_NUKI.Text = Format(decMKGaku_Nuki, "#,##0")
        '【明細計】粗利率
        If Not decMKGaku_Nuki = 0 Then
            decMKARARIRITU = (decMKGaku_Nuki - decMKGenkagaku) / decMKGaku_Nuki * 100
            decMKARARIRITU = Utility.Round(decMKARARIRITU, 3, CInt(strS_SCB_ROUND_ARARIRITU))
        End If
        txtMKARARIRITU.Text = "（粗利率：" & Format(decMKARARIRITU, "#,##0.00").PadLeft(6) & "%）"

    End Sub

    Private Sub subDbgSumGokei()
        Dim decGKGENKAGAKU As Decimal = 0
        Dim decGKGAKU_NUKI As Decimal = 0
        Dim decGKARARIRITU As Decimal = 0
        Dim decGKTAX As Decimal = 0

        Dim dt = CType(dbgMEISAI.DataSource, dsMIT0001.T_MITUMORISelectDataTable)
        For Each dr In dt
            '1階層目以外の場合
            If Utility.LenBSA(dr.KAISOCODE) <> intKaisoKeta Then Continue For
            '1行目のデータの場合
            If NUCheck(dr.SUU) Then Continue For

            decGKGENKAGAKU += dr.GENKAGAKU
            decGKGAKU_NUKI += dr.GAKU_NUKI
        Next

        '【総合計】原価額
        If decGKGENKAGAKU > 999999999999 Then decGKGENKAGAKU = 999999999999 '原価金額計
        txtGKGENKAGAKU.Text = Format(decGKGENKAGAKU, "#,##0")

        '【総合計】見積額税抜
        If decGKGAKU_NUKI > 999999999999 Then decGKGAKU_NUKI = 999999999999 '見積金額計
        txtGKGAKU_NUKI.Text = Format(decGKGAKU_NUKI, "#,##0")

        '【総合計】粗利率
        If Not decGKGAKU_NUKI = 0 Then
            decGKARARIRITU = (decGKGAKU_NUKI - decGKGENKAGAKU) / decGKGAKU_NUKI * 100
            decGKARARIRITU = Utility.Round(decGKARARIRITU, 3, CInt(strS_SCB_ROUND_ARARIRITU))
        End If

        txtGKARARIRITU.Text = "（粗利率：" & Format(decGKARARIRITU, "#,##0.00").PadLeft(6) & "%）"

        '【総合計】消費税
        Select Case strS_SCB_ZEIKBN
            Case "0"
                decGKTAX = CDec(decGKGAKU_NUKI * (CDbl(strSyohiZeiritu) / 100))
                decGKTAX = Utility.Round(decGKTAX, 1, CInt(strS_SCB_ROUND_TAX))
                If decGKTAX > 999999999999 Then decGKTAX = 999999999999
                txtGKTAX.Text = Format(decGKTAX, "#,##0")
                '【総合計】合計
                If (decGKGAKU_NUKI + decGKTAX) > 999999999999 Then
                    txtGKGAKU.Text = Format(999999999999, "#,##0")
                Else
                    txtGKGAKU.Text = Format(decGKGAKU_NUKI + decGKTAX, "#,##0")
                End If

            Case "1"
                decGKTAX = CDec(decGKGAKU_NUKI * CDbl(strSyohiZeiritu) / (100 + CDbl(strSyohiZeiritu)))
                decGKTAX = Utility.Round(decGKTAX, 1, CInt(strS_SCB_ROUND_TAX))
                If decGKTAX > 999999999999 Then decGKTAX = 999999999999
                txtGKTAX.Text = Format(decGKTAX, "#,##0")
                txtGKGAKU.Text = txtGKGAKU_NUKI.Text

            Case "2"
                txtGKTAX.Text = "0"
                txtGKGAKU.Text = txtGKGAKU_NUKI.Text
        End Select

    End Sub

    Private Sub subDbgAddNewSet()
        '入力明細が最大行を超えた場合は、新規行追加は不可
        If dbgMEISAI.RowCount + 1 >= ROW_COUNT Then
            dbgMEISAI.AllowAddNew = False
        Else
            dbgMEISAI.AllowAddNew = True
        End If
    End Sub

    ''' <summary>
    ''' 金額計算
    ''' </summary>
    ''' <param name="strKBN"></param>
    Private Sub subDbgCalcKingaku(ByVal strKBN As String)

        With dbgMEISAI
            If strKBN = "ONE" Then
                '原単価
                If Not NUCheck(.Columns(COL_GENTANKA).Value) Then
                    .Columns(COL_GENTANKA).Value = Utility.Round(CDec(.Columns(COL_GENTANKA).Value), 0, CInt(strS_SCB_ROUND_GENTANKA))
                    If CDec(.Columns(COL_GENTANKA).Value) > 999999999 Then .Columns(COL_GENTANKA).Value = 999999999
                End If

                '原価金額（数量 * 原単価）
                If Not NUCheck(.Columns(COL_SUU).Value) And Not NUCheck(.Columns(COL_GENTANKA).Value) Then
                    .Columns(COL_GENKAGAKU).Value = Utility.Round(GetRoundValue(.Columns(COL_SUU).Value.ToString) * CDec(.Columns(COL_GENTANKA).Value), 0, CInt(strS_SCB_ROUND_GENKAKIN))
                    If CDec(.Columns(COL_GENKAGAKU).Value) > 999999999999 Then .Columns(COL_GENKAGAKU).Value = 999999999999
                End If

                '受注単価
                If Not NUCheck(.Columns(COL_KAKERITU).Value) AndAlso Not NUCheck(.Columns(COL_GENTANKA).Value) Then
                    If .Columns(COL_GENTANKA).Value <> 0 Then
                        .Columns(COL_TANKA).Value = Utility.Round(CDec(.Columns(COL_KAKERITU).Value) * CDec(.Columns(COL_GENTANKA).Value), 0, CInt(strS_SCB_ROUND_MITTANKA))
                        If CDec(.Columns(COL_TANKA).Value) > 999999999 Then .Columns(COL_TANKA).Value = 999999999
                    End If
                End If

                '受注金額、受注金額税抜（数量 * 受注単価）
                If Not NUCheck(.Columns(COL_SUU).Value) And Not NUCheck(.Columns(COL_TANKA).Value) Then
                    .Columns(COL_GAKU).Value = Utility.Round(GetRoundValue(.Columns(COL_SUU).Value.ToString) * CDec(.Columns(COL_TANKA).Value), 0, CInt(strS_SCB_ROUND_MITKAKIN))
                    .Columns(COL_GAKU_NUKI).Value = Utility.Round(GetRoundValue(.Columns(COL_SUU).Value.ToString) * CDec(.Columns(COL_TANKA).Value), 0, CInt(strS_SCB_ROUND_MITKAKIN))
                    If CDec(.Columns(COL_GAKU).Value) > 999999999999 Then .Columns(COL_GAKU).Value = 999999999999
                    If CDec(.Columns(COL_GAKU_NUKI).Value) > 999999999999 Then .Columns(COL_GAKU_NUKI).Value = 999999999999
                End If

            ElseIf strKBN = "ALL" Then
                '先にデータを確定させる(新規行をデータソース側に確定させるため)
                .UpdateData()

                '画面上のデータのみに対して再度金額の書換を行う

                '一行目は掛率行なのでとばす
                For i As Integer = 1 To dbgMEISAI.RowCount - 1

                    '合計行はとばす
                    If CheckGokeiLine(i) Then Continue For

                    '原単価
                    If Not NUCheck(NZ(dbgMEISAI(i, COL_GENTANKA))) Then
                        dbgMEISAI(i, COL_GENTANKA) = Utility.Round(NZ(dbgMEISAI(i, COL_GENTANKA)), 0, CInt(strS_SCB_ROUND_GENTANKA))
                        If CDec(dbgMEISAI(i, COL_GENTANKA)) > 999999999 Then dbgMEISAI(i, COL_GENTANKA) = 999999999
                    End If

                    '原価金額（数量 * 原単価）
                    If Not NUCheck(dbgMEISAI(i, COL_SUU)) And Not NUCheck(dbgMEISAI(i, COL_GENTANKA)) Then
                        dbgMEISAI(i, COL_GENKAGAKU) = Utility.Round(GetRoundValue(NZ(dbgMEISAI(i, COL_SUU)).ToString) * NZ(dbgMEISAI(i, COL_GENTANKA)), 0, CInt(strS_SCB_ROUND_GENKAKIN))
                        If NZ(dbgMEISAI(i, COL_GENKAGAKU)) > 999999999999 Then dbgMEISAI(i, COL_GENKAGAKU) = 999999999999
                    End If

                    '見積単価
                    If Not NUCheck(dbgMEISAI(i, COL_KAKERITU)) AndAlso Not NUCheck(dbgMEISAI(i, COL_GENTANKA)) Then
                        If dbgMEISAI(i, COL_GENTANKA) <> 0 Then
                            dbgMEISAI(i, COL_TANKA) = Utility.Round(NZ(dbgMEISAI(i, COL_KAKERITU)) * NZ(dbgMEISAI(i, COL_GENTANKA)), 0, CInt(strS_SCB_ROUND_MITTANKA))
                            If CDec(dbgMEISAI(i, COL_TANKA)) > 999999999 Then dbgMEISAI(i, COL_TANKA) = 999999999
                        End If
                    End If

                    '受注金額、受注金額税抜（数量 * 受注単価）
                    If Not NUCheck(dbgMEISAI(i, COL_SUU)) And Not NUCheck(dbgMEISAI(i, COL_TANKA)) Then
                        dbgMEISAI(i, COL_GAKU) = Utility.Round(GetRoundValue(NZ(dbgMEISAI(i, COL_SUU)).ToString) * NZ(dbgMEISAI(i, COL_TANKA)), 0, CInt(strS_SCB_ROUND_MITKAKIN))
                        dbgMEISAI(i, COL_GAKU_NUKI) = Utility.Round(GetRoundValue(NZ(dbgMEISAI(i, COL_SUU)).ToString) * NZ(dbgMEISAI(i, COL_TANKA)), 0, CInt(strS_SCB_ROUND_MITKAKIN))
                        If NZ(dbgMEISAI(i, COL_GAKU)) > 999999999999 Then dbgMEISAI(i, COL_GAKU) = 999999999999
                        If NZ(dbgMEISAI(i, COL_GAKU_NUKI)) > 999999999999 Then dbgMEISAI(i, COL_GAKU_NUKI) = 999999999999
                    End If
                Next
            End If
        End With
    End Sub

    '■GetAllNodes
    '''  <summary>子ノードも含んだすべてのノードを取得する</summary>
    '''  <param name="Nodes">トップレベルのNodes。例：TreeView1.Nodes</param>
    '''  <returns>すべてのNodeを含んだコレクション</returns>
    Private Function fncGetAllNodes(ByVal Nodes As TreeNodeCollection) As ArrayList
        Dim Ar As New ArrayList
        Dim Node As TreeNode

        For Each Node In Nodes
            Ar.Add(Node)
            If Node.GetNodeCount(True) > 0 Then
                Ar.AddRange(fncGetAllNodes(Node.Nodes))
            End If
        Next

        Return Ar
    End Function

    '全てのノードを取得する
    Private Function GetAllNodes(ByVal Nodes As TreeNodeCollection) As ArrayList
        Dim Ar As New ArrayList
        Dim Node As TreeNode

        For Each Node In Nodes
            Ar.Add(Node)
            If Node.GetNodeCount(False) > 0 Then
                Ar.AddRange(GetAllNodes(Node.Nodes))
            End If
        Next

        Return Ar
    End Function

    Public Sub subRep_Prnt(ByVal previewMode As Boolean)
        Dim rpt1 As rptMIT0001_Kagami0
        Dim rpt2 As rptMIT0001_Meisai
        Dim rpt3 As rptMIT0001_Joken

        On Error GoTo OptimisticRepError

        '画面の情報をセット
        Dim dtPRWork1 = subPrintDataSet()
        Dim dtPRWork2 = subPrintDataSet_Meisai()
        Dim dtPRWork3 As New DataTable

        dtPRWork3.Columns.Add("MITUMORI_JOUKEN", Type.GetType("System.String"))
        Dim dtRow = dtPRWork3.NewRow
        dtRow("MITUMORI_JOUKEN") = txtMitsumoriJoken.Text
        dtPRWork3.Rows.Add(dtRow)

        '印刷実行
        rpt1 = New rptMIT0001_Kagami0(dtPRWork1, CInt(lblSyosu.Text))
        rpt2 = New rptMIT0001_Meisai(dtPRWork2, CInt(lblSyosu.Text))
        rpt3 = New rptMIT0001_Joken(dtPRWork3)

        PrintReport(PrintReportMode.Preview, {rpt1, rpt2, rpt3}, previewMode)

        rpt1.Dispose()
        rpt2.Dispose()
        rpt3.Dispose()
        dtPRWork1 = Nothing
        dtPRWork2 = Nothing
        dtPRWork3 = Nothing

        Exit Sub

OptimisticRepError:
        rpt1.Dispose()
        rpt2.Dispose()
        rpt3.Dispose()
        dtPRWork1 = Nothing
        dtPRWork2 = Nothing
        dtPRWork3 = Nothing

        Select Case Err.Number
            Case 482        '印刷ｷｬﾝｾﾙ
                Resume Next
            Case Else
                Beep()
                MessageBox.Show(Err.Number & "：" & Err.Description, "VisualBasic Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Select
    End Sub

    Private Function subPrintDataSet()
        Dim dt As New DataTable
        Dim dtRow As DataRow
        Dim datTeisyutuDate As Date
        Dim decGAKU_NUKI As Decimal
        Dim decTAX As Decimal

        dt.Columns.Add("MITUMORINO", Type.GetType("System.String"))
        dt.Columns.Add("TEISYUTUDATE", Type.GetType("System.String"))
        dt.Columns.Add("TOKUINAME", Type.GetType("System.String"))
        dt.Columns.Add("KEISYOUNAME", Type.GetType("System.String"))
        dt.Columns.Add("GKMITUMORIGAKU_NUKI", Type.GetType("System.Decimal"))
        dt.Columns.Add("GKMITUMORIGAKU", Type.GetType("System.Decimal"))
        dt.Columns.Add("GKTAX", Type.GetType("System.Decimal"))
        dt.Columns.Add("ISOQAR", Type.GetType("System.String"))
        dt.Columns.Add("JISYANAME", Type.GetType("System.String"))
        dt.Columns.Add("COMMENT1", Type.GetType("System.String"))
        dt.Columns.Add("POSTNO", Type.GetType("System.String"))
        dt.Columns.Add("ADDRESS", Type.GetType("System.String"))
        dt.Columns.Add("TELNO", Type.GetType("System.String"))
        dt.Columns.Add("FAXNO", Type.GetType("System.String"))
        dt.Columns.Add("EMAIL", Type.GetType("System.String"))
        dt.Columns.Add("WEB", Type.GetType("System.String"))
        dt.Columns.Add("KOUJINAME", Type.GetType("System.String"))
        dt.Columns.Add("KOUJINO", Type.GetType("System.String"))
        dt.Columns.Add("KOUJIBASYO", Type.GetType("System.String"))
        dt.Columns.Add("NOUKI", Type.GetType("System.String"))
        dt.Columns.Add("YUKOKIGEN", Type.GetType("System.String"))
        dt.Columns.Add("SIHARAIJYOKEN", Type.GetType("System.String"))
        dt.Columns.Add("KAMOKU_HINMOKU1", Type.GetType("System.String"))
        dt.Columns.Add("KAMOKU_HINMOKU2", Type.GetType("System.String"))
        dt.Columns.Add("KAMOKU_HINMOKU3", Type.GetType("System.String"))
        dt.Columns.Add("KAMOKU_HINMOKU4", Type.GetType("System.String"))
        dt.Columns.Add("KAMOKU_HINMOKU5", Type.GetType("System.String"))
        dt.Columns.Add("KAMOKU_HINMOKU6", Type.GetType("System.String"))
        dt.Columns.Add("KAMOKU_HINMOKU7", Type.GetType("System.String"))
        dt.Columns.Add("KAMOKU_HINMOKU8", Type.GetType("System.String"))
        dt.Columns.Add("KAMOKU_HINMOKU9", Type.GetType("System.String"))
        dt.Columns.Add("KAMOKU_HINMOKU10", Type.GetType("System.String"))
        dt.Columns.Add("KAMOKU_HINMOKU11", Type.GetType("System.String"))
        dt.Columns.Add("SUU1", Type.GetType("System.String"))
        dt.Columns.Add("SUU2", Type.GetType("System.String"))
        dt.Columns.Add("SUU3", Type.GetType("System.String"))
        dt.Columns.Add("SUU4", Type.GetType("System.String"))
        dt.Columns.Add("SUU5", Type.GetType("System.String"))
        dt.Columns.Add("SUU6", Type.GetType("System.String"))
        dt.Columns.Add("SUU7", Type.GetType("System.String"))
        dt.Columns.Add("SUU8", Type.GetType("System.String"))
        dt.Columns.Add("SUU9", Type.GetType("System.String"))
        dt.Columns.Add("SUU10", Type.GetType("System.String"))
        dt.Columns.Add("SUU11", Type.GetType("System.String"))
        dt.Columns.Add("TANI1", Type.GetType("System.String"))
        dt.Columns.Add("TANI2", Type.GetType("System.String"))
        dt.Columns.Add("TANI3", Type.GetType("System.String"))
        dt.Columns.Add("TANI4", Type.GetType("System.String"))
        dt.Columns.Add("TANI5", Type.GetType("System.String"))
        dt.Columns.Add("TANI6", Type.GetType("System.String"))
        dt.Columns.Add("TANI7", Type.GetType("System.String"))
        dt.Columns.Add("TANI8", Type.GetType("System.String"))
        dt.Columns.Add("TANI9", Type.GetType("System.String"))
        dt.Columns.Add("TANI10", Type.GetType("System.String"))
        dt.Columns.Add("TANI11", Type.GetType("System.String"))
        dt.Columns.Add("MITUMORITANKA1", Type.GetType("System.String"))
        dt.Columns.Add("MITUMORITANKA2", Type.GetType("System.String"))
        dt.Columns.Add("MITUMORITANKA3", Type.GetType("System.String"))
        dt.Columns.Add("MITUMORITANKA4", Type.GetType("System.String"))
        dt.Columns.Add("MITUMORITANKA5", Type.GetType("System.String"))
        dt.Columns.Add("MITUMORITANKA6", Type.GetType("System.String"))
        dt.Columns.Add("MITUMORITANKA7", Type.GetType("System.String"))
        dt.Columns.Add("MITUMORITANKA8", Type.GetType("System.String"))
        dt.Columns.Add("MITUMORITANKA9", Type.GetType("System.String"))
        dt.Columns.Add("MITUMORITANKA10", Type.GetType("System.String"))
        dt.Columns.Add("MITUMORITANKA11", Type.GetType("System.String"))
        dt.Columns.Add("MITUMORIGAKU1", Type.GetType("System.String"))
        dt.Columns.Add("MITUMORIGAKU2", Type.GetType("System.String"))
        dt.Columns.Add("MITUMORIGAKU3", Type.GetType("System.String"))
        dt.Columns.Add("MITUMORIGAKU4", Type.GetType("System.String"))
        dt.Columns.Add("MITUMORIGAKU5", Type.GetType("System.String"))
        dt.Columns.Add("MITUMORIGAKU6", Type.GetType("System.String"))
        dt.Columns.Add("MITUMORIGAKU7", Type.GetType("System.String"))
        dt.Columns.Add("MITUMORIGAKU8", Type.GetType("System.String"))
        dt.Columns.Add("MITUMORIGAKU9", Type.GetType("System.String"))
        dt.Columns.Add("MITUMORIGAKU10", Type.GetType("System.String"))
        dt.Columns.Add("MITUMORIGAKU11", Type.GetType("System.String"))
        dt.Columns.Add("G_BIKO1", Type.GetType("System.String"))
        dt.Columns.Add("G_BIKO2", Type.GetType("System.String"))
        dt.Columns.Add("G_BIKO3", Type.GetType("System.String"))
        dt.Columns.Add("G_BIKO4", Type.GetType("System.String"))
        dt.Columns.Add("G_BIKO5", Type.GetType("System.String"))
        dt.Columns.Add("G_BIKO6", Type.GetType("System.String"))
        dt.Columns.Add("G_BIKO7", Type.GetType("System.String"))
        dt.Columns.Add("G_BIKO8", Type.GetType("System.String"))
        dt.Columns.Add("G_BIKO9", Type.GetType("System.String"))
        dt.Columns.Add("G_BIKO10", Type.GetType("System.String"))
        dt.Columns.Add("G_BIKO11", Type.GetType("System.String"))

        dt.Columns.Add("D_BIKO", Type.GetType("System.String"))

        dtRow = dt.NewRow
        dtRow("MITUMORINO") = txtMITUMORINO.Text.PadLeft(txtMITUMORINO.MaxLength, "0"c) & "-" & txtMITUMORIEDABAN.Text.PadLeft(txtMITUMORIEDABAN.MaxLength, "0"c)
        datTeisyutuDate = CDate(txtTEISYUTUDATE.Text)
        dtRow("TEISYUTUDATE") = GetCnvSW.SfncYearSW(datTeisyutuDate.ToString("yyyy/MM/dd"), True)
        dtRow("TOKUINAME") = txtKokyakuName.Text
        dtRow("KEISYOUNAME") = txtKEISYOUNAME.Text
        dtRow("ISOQAR") = strS_SCB_ISOQAR
        dtRow("JISYANAME") = strS_SCB_JISYANAME
        dtRow("COMMENT1") = strS_SCB_COMMENT1
        dtRow("POSTNO") = strS_SCB_POSTNO
        dtRow("ADDRESS") = strS_SCB_ADDRESS1 & strS_SCB_ADDRESS2
        dtRow("TELNO") = strS_SCB_TELNO
        dtRow("FAXNO") = strS_SCB_FAXNO
        dtRow("EMAIL") = strS_SCB_EMAIL
        dtRow("WEB") = strS_SCB_WEB
        dtRow("KOUJINAME") = txtKoujiName.Text
        dtRow("KOUJINO") = txtKoujiNo.Text
        dtRow("KOUJIBASYO") = txtKoujiBasyo.Text
        dtRow("NOUKI") = txtNOUKIDATE(0).Text & lblNOUKIGENGO(0).Text & "～" & txtNOUKIDATE(1).Text & lblNOUKIGENGO(0).Text
        dtRow("YUKOKIGEN") = txtKigen.Text
        dtRow("SIHARAIJYOKEN") = txtShiharaiJoken.Text

        '明細の作成
        Dim dtMeisai = CType(dbgMEISAI.DataSource, dsMIT0001.T_MITUMORISelectDataTable)
        Dim idx = 1

        For Each dr In dtMeisai
            '1階層目、または、1行目の場合、処理しない
            If Utility.LenBSA(dr.KAISOCODE) <> intKaisoKeta Then Continue For
            If NUCheck(dr.SUU) Then Continue For

            dtRow("KAMOKU_HINMOKU" & CStr(idx)) = dr.KAMOKU_HINMOKU
            dtRow("SUU" & CStr(idx)) = dr.SUU
            dtRow("TANI" & CStr(idx)) = dr.TANI
            dtRow("MITUMORITANKA" & CStr(idx)) = dr.TANKA
            dtRow("MITUMORIGAKU" & CStr(idx)) = dr.GAKU_NUKI
            dtRow("G_BIKO" & CStr(idx)) = dr.G_BIKO

            idx = idx + 1
            '8階層目まで印字
            If idx > 8 Then Exit For
        Next

        '空白行がある場合、最終行であることを明記
        If idx < 9 Then
            dtRow("KAMOKU_HINMOKU" & CStr(idx)) = "　以上"
        End If

        '小計、消費税、合計の作成
        For Each dr In dtMeisai
            '1階層目、または、1行目の場合、処理しない
            If Utility.LenBSA(dr.KAISOCODE) <> intKaisoKeta Then Continue For
            If NUCheck(dr.SUU) Then Continue For

            decGAKU_NUKI += CDec(dr.GAKU_NUKI)
        Next

        Dim wkMitumoriGakuNuki As Decimal = decGAKU_NUKI
        Dim wkMitumoriGaku As Decimal = decGAKU_NUKI

        '消費税算出
        Dim syohizeiLable = "消費税"
        Select Case strS_SCB_ZEIKBN
            Case "0"
                decTAX = CDec(decGAKU_NUKI * (CDbl(strSyohiZeiritu) / 100))
                decTAX = Utility.Round(decTAX, 0, CInt(strS_SCB_ROUND_TAX))
                wkMitumoriGaku += decTAX
            Case "1"
                decTAX = CDec(decGAKU_NUKI * CDbl(strSyohiZeiritu) / (100 + CDbl(strSyohiZeiritu)))
                decTAX = Utility.Round(decTAX, 0, CInt(strS_SCB_ROUND_TAX))
                syohizeiLable = "内消費税"
            Case "2"
                decTAX = 0
        End Select

        dtRow("KAMOKU_HINMOKU9") = "小計"
        dtRow("SUU9") = ""
        dtRow("TANI9") = ""
        dtRow("MITUMORITANKA9") = ""
        dtRow("MITUMORIGAKU9") = wkMitumoriGakuNuki
        dtRow("G_BIKO9") = ""
        dtRow("KAMOKU_HINMOKU10") = syohizeiLable
        dtRow("SUU10") = strSyohiZeiritu
        dtRow("TANI10") = "％"
        dtRow("MITUMORITANKA10") = ""
        dtRow("MITUMORIGAKU10") = decTAX
        dtRow("G_BIKO10") = ""
        dtRow("KAMOKU_HINMOKU11") = "合計"
        dtRow("SUU11") = ""
        dtRow("TANI11") = ""
        dtRow("MITUMORITANKA11") = ""
        dtRow("MITUMORIGAKU11") = wkMitumoriGaku
        dtRow("G_BIKO11") = ""
        dtRow("GKMITUMORIGAKU_NUKI") = decGAKU_NUKI
        dtRow("GKMITUMORIGAKU") = wkMitumoriGaku
        dtRow("GKTAX") = decTAX
        dtRow("D_BIKO") = txtD_BIKO.Text

        dt.Rows.Add(dtRow)

        Return dt
    End Function

    Private Function subPrintDataSet_Meisai() As DataTable
        Dim intKaiso As Integer
        Dim intNumber As Integer
        Dim intMeisaiGyo As Integer = 30    '１ページに出力する明細行数
        Dim TreeNumber As Integer = 0
        Dim strKaisoCode As String
        Dim dt As New DataTable
        Dim dtRow As DataRow

        Try
            If Not trvWorkInfo.SelectedNode Is Nothing Then
                Dim selectedNode = trvWorkInfo.SelectedNode

                dt.Columns.Add("NUMBER", Type.GetType("System.String"))
                dt.Columns.Add("KAMOKU_HINMOKU", Type.GetType("System.String"))
                dt.Columns.Add("HINSITU_KIKAKU_SIYO", Type.GetType("System.String"))
                dt.Columns.Add("SUU", Type.GetType("System.String"))
                dt.Columns.Add("TANI", Type.GetType("System.String"))
                dt.Columns.Add("MITUMORITANKA", Type.GetType("System.String"))
                dt.Columns.Add("MITUMORIGAKU", Type.GetType("System.String"))
                dt.Columns.Add("G_BIKO", Type.GetType("System.String"))
                dt.Columns.Add("PAGE", Type.GetType("System.String"))

                '選択ノードを切換ながら処理を行うため、いったんイベントを解除
                RemoveHandler trvWorkInfo.AfterSelect, AddressOf trvWorkInfo_AfterSelect

                For Each Node As TreeNode In GetAllNodes(trvWorkInfo.Nodes)

                    trvWorkInfo.SelectedNode = Node

                    '階層取得
                    intKaiso = trvWorkInfo.SelectedNode.Level + 1
                    '階層範囲設定
                    Select Case intKaiso
                        Case Is <= 2
                            strKaisoCode = ""
                        Case Else
                            strKaisoCode = trvWorkInfo.SelectedNode.Tag.ToString
                    End Select
                    If intKaiso <= 1 Then Continue For

                    '子ノードが存在しないツリーは印字しない
                    If trvWorkInfo.SelectedNode.GetNodeCount(False) <= 0 Then Continue For

                    intNumber = 0

                    '１行目の作成
                    dtRow = dt.NewRow
                    dtRow("NUMBER") = "A"
                    dtRow("KAMOKU_HINMOKU") = trvWorkInfo.SelectedNode.Text
                    dtRow("PAGE") = TreeNumber
                    dt.Rows.Add(dtRow)

                    '明細の作成
                    Dim dtMeisai = CType(dbgMEISAI.DataSource, dsMIT0001.T_MITUMORISelectDataTable)
                    For Each dr In dtMeisai
                        '1行目、または、対象の階層以外の場合、処理しない
                        If NUCheck(dr.SUU) Then Continue For
                        If Utility.LeftBSA(dr.KAISOCODE, Utility.LenBSA(strKaisoCode)) <> strKaisoCode Then Continue For
                        If Utility.LenBSA(dr.KAISOCODE) <> Utility.LenBSA(strKaisoCode) + intKaisoKeta Then Continue For

                        '偶数行へ出力
                        dtRow = dt.NewRow
                        intNumber += 1
                        dtRow("NUMBER") = CStr(intNumber)
                        dtRow("KAMOKU_HINMOKU") = dr.KAMOKU_HINMOKU
                        dtRow("HINSITU_KIKAKU_SIYO") = dr.HINSITU_KIKAKU_SIYO
                        dtRow("SUU") = dr.SUU
                        dtRow("TANI") = dr.TANI
                        dtRow("MITUMORITANKA") = dr.TANKA
                        dtRow("MITUMORIGAKU") = dr.GAKU_NUKI
                        dtRow("G_BIKO") = dr.G_BIKO
                        dtRow("PAGE") = TreeNumber
                        dt.Rows.Add(dtRow)
                    Next

                    '空白行の作成
                    If Not (intNumber Mod intMeisaiGyo) = 0 Then
                        Do Until (intNumber Mod intMeisaiGyo) = 0
                            dtRow = dt.NewRow
                            dtRow("PAGE") = TreeNumber
                            dt.Rows.Add(dtRow)
                            intNumber += 1
                        Loop
                    End If

                    TreeNumber += 1
                Next

                trvWorkInfo.SelectedNode = selectedNode
            End If

        Finally
            AddHandler trvWorkInfo.AfterSelect, AddressOf trvWorkInfo_AfterSelect
        End Try

        Return dt
    End Function

    ''' <summary>
    ''' あるTreeNodeが別のTreeNodeの子ノードか調べる
    ''' </summary>
    ''' <param name="parentNode">親ノードか調べるTreeNode</param>
    ''' <param name="childNode">子ノードか調べるTreeNode</param>
    ''' <returns>子ノードの時はTrue</returns>
    Private Shared Function IsChildNode(
            ByVal parentNode As TreeNode,
            ByVal childNode As TreeNode) As Boolean
        If childNode.Parent Is parentNode Then
            Return True
        ElseIf Not childNode.Parent Is Nothing Then
            Return IsChildNode(parentNode, childNode.Parent)
        Else
            Return False
        End If
    End Function

    ''' <summary>
    ''' 行削除ボタン押下
    ''' </summary>
    Private Sub DbgMeisaiRowDelete()

        '最初の行の場合
        If dbgMEISAI.Row = 0 Then Return

        '新規の行の場合
        If dbgMEISAI.Row = dbgMEISAI.RowCount Then Return

        '選択ノードがない場合処理しない
        If trvWorkInfo.SelectedNode Is Nothing Then Return

        '確認メッセージ
        If MessageBoxEx.Show(MessageCode_Arg0.M160この階層を削除してもよろしいですか元には戻せません, PROGRAM_NAME) = Windows.Forms.DialogResult.No Then Return

        '確認メッセージ
        If CheckGokeiLine(dbgMEISAI.Row) Then
            If MessageBoxEx.Show(MessageCode_Arg0.M161この階層以降の階層も削除されますが本当に削除してもよろしいですか, PROGRAM_NAME) = Windows.Forms.DialogResult.No Then Return
        End If

        '行を確定
        dbgMEISAI.UpdateData()

        Dim tnp = trvWorkInfo.SelectedNode
        Dim row = dbgMEISAI.Row

        Try
            RemoveHandler trvWorkInfo.AfterSelect, AddressOf trvWorkInfo_AfterSelect
            RemoveHandler dbgMEISAI.Leave, AddressOf dbgMEISAI_Leave

            '削除するノードを選択
            trvWorkInfo.SelectedNode = trvWorkInfo.SelectedNode.Nodes(dbgMEISAI.Row - 1)
            trvWorkInfo.Tag = trvWorkInfo.SelectedNode.Level

            '選択ノード取得
            Dim tn = trvWorkInfo.SelectedNode
            Dim strKaisoCode = tn.Tag.ToString

            '選択ノードを削除
            trvWorkInfo.Nodes.Remove(tn)

            '明細データ削除
            Dim dt = CType(dbgMEISAI.DataSource, dsMIT0001.T_MITUMORISelectDataTable)
            Dim rowCnt = dt.Rows.Count - 1
            Dim lineCnt = 0
            For i As Integer = 0 To rowCnt
                '自身と子ノードのデータを削除
                Dim dr = CType(dt.Rows(i - lineCnt), dsMIT0001.T_MITUMORISelectRow)

                '削除対象の階層以外の場合、処理しない
                If Utility.LeftBSA(dr.KAISOCODE, Utility.LenBSA(strKaisoCode)) <> strKaisoCode Then Continue For

                dr.Delete()

                If rowCnt <> dt.Rows.Count - 1 Then
                    '削除が即時コミットされた場合、ループの件数、処理中の行を変更する。
                    lineCnt += 1
                End If
            Next

            '削除後のコミット
            dt.AcceptChanges()

            '削除した階層以降のデータ階層を繰り上げる
            For Each dr In dt
                '削除階層より大きい階層かつ桁数が削除階層以上なものかつ親階層が同一なもの
                If Utility.LeftBSA(dr.KAISOCODE, LenBSA(strKaisoCode)) > strKaisoCode AndAlso
                    LenBSA(Utility.LeftBSA(dr.KAISOCODE, LenBSA(strKaisoCode))) >= LenBSA(strKaisoCode) AndAlso
                    Utility.LeftBSA(dr.KAISOCODE, LenBSA(strKaisoCode) - intKaisoKeta) = LeftBSA(strKaisoCode, LenBSA(strKaisoCode) - intKaisoKeta) Then
                    '001002を削除した場合　001003を001002に変換するため右３桁を取得してマイナス１する
                    dr.KAISOCODE = fncWriteKaiso(dr.KAISOCODE, strKaisoCode)
                End If
            Next

            '同様にツリーの階層コードも繰り上げる
            Dim node As TreeNode
            '親ノードの子ノード全検索して、階層を書き換える
            For Each node In tnp.Nodes
                If node.Tag.ToString > strKaisoCode Then
                    fncCnvNodeKaiso(node, fncWriteKaiso(node.Tag.ToString, strKaisoCode))
                End If
            Next

            '表示中の階層コードを保持
            trvWorkInfo.Tag = trvWorkInfo.SelectedNode.Level

            RaiseEvent TreeNodeAddInsertDelete(trvWorkInfo)

        Finally
            AddHandler trvWorkInfo.AfterSelect, AddressOf trvWorkInfo_AfterSelect
            AddHandler dbgMEISAI.Leave, AddressOf dbgMEISAI_Leave
        End Try

        ''ノートの選択とグリッドの再表示
        trvWorkInfo.SelectedNode = tnp

        dbgMEISAI.Row = row
        dbgMEISAI.Col = COL_KAMOKU_HINMOKU
        dbgMEISAI.Focus()

        intMoveRowValue = dbgMEISAI.Row
    End Sub

    '階層をひとつ繰り上げる　MotoKaiso=変更する階層  Kaiso=削除した階層
    Private Function fncWriteKaiso(ByVal MotoKaiso As String, ByVal Kaiso As String) As String
        Dim wkKaiso As String
        wkKaiso = RightBSA(LeftBSA(MotoKaiso, LenBSA(Kaiso)), intKaisoKeta)
        wkKaiso = ZeroPadding((CDec(wkKaiso) - 1).ToString, 3)
        wkKaiso = LeftBSA(MotoKaiso, LenBSA(Kaiso) - intKaisoKeta) + wkKaiso
        wkKaiso = wkKaiso + Mid$(MotoKaiso, LenBSA(wkKaiso) + 1)
        Return wkKaiso
    End Function

    ''' <summary>
    ''' 支払条件Enterキー押下
    ''' </summary>
    ''' <remarks></remarks>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub txtShiharaiJoken_KeyDown(ByVal sender As System.Object, ByVal e As KeyEventArgs) Handles txtShiharaiJoken.KeyDown
        'キーコードチェック
        If Not (e.KeyCode = Keys.Enter OrElse e.KeyCode = Keys.Tab) Then Exit Sub

        OutPutDebugLog(System.Reflection.MethodBase.GetCurrentMethod.Name)

        dbgMEISAI.Focus()

    End Sub

    ''' <summary>
    ''' 工事内訳参照タブの更新
    ''' </summary>
    Private Sub trvWorkInfo_NodeUpdate(ByVal sender As Object) Handles Me.TreeNodeAddInsertDelete

        OutPutDebugLog(System.Reflection.MethodBase.GetCurrentMethod.Name)

        trvWorkInfo_Reference.BeginUpdate()
        trvWorkInfo_Reference.Nodes.Clear()

        For Each tre As TreeNode In trvWorkInfo.Nodes
            trvWorkInfo_Reference.Nodes.Add(CType(tre.Clone, TreeNode))
        Next

        trvWorkInfo_Reference.ExpandAll()
        trvWorkInfo_Reference.EndUpdate()

        '再作成後にメインノードと同一のノードを選択させる
        If trvWorkInfo.SelectedNode IsNot Nothing Then
            Try
                RemoveHandler trvWorkInfo_Reference.AfterSelect, AddressOf trvWorkInfo_Reference_AfterSelect
                Dim t As New TreeNode
                For Each tre As TreeNode In trvWorkInfo_Reference.Nodes
                    If fncSearchNode(tre, trvWorkInfo.SelectedNode, t) Then
                        If t Is Nothing Then Exit Sub 'もしも戻り値TreeNodeが格納されていない場合はそこで終了
                        trvWorkInfo_Reference.SelectedNode = t
                        Exit For
                    End If
                Next
            Finally
                AddHandler trvWorkInfo_Reference.AfterSelect, AddressOf trvWorkInfo_Reference_AfterSelect
            End Try
        End If
    End Sub

    ''' <summary>
    ''' 工事内訳情報ツリー選択時
    ''' </summary>
    Private Sub trvWorkInfo_AfterSelect(ByVal sender As System.Object, ByVal e As TreeViewEventArgs)

        If NUCheck(trvWorkInfo.SelectedNode) Then Exit Sub

        OutPutDebugLog(System.Reflection.MethodBase.GetCurrentMethod.Name)

        'グリッド行が編集中であれば確定させる
        If dbgMEISAI.DataChanged Then dbgMEISAI.UpdateData()

        '選択されたノードの明細情報を抽出
        Call subSelectedNodeDataPickUp()

        'グリッドの設定の変更処理
        ChangeModeDbgMEISAI()

        If e IsNot Nothing Then
            Try
                RemoveHandler trvWorkInfo_Reference.AfterSelect, AddressOf trvWorkInfo_Reference_AfterSelect
                Dim t As New TreeNode
                For Each tre As TreeNode In trvWorkInfo_Reference.Nodes
                    If fncSearchNode(tre, e.Node, t) Then
                        If t Is Nothing Then Exit Sub 'もしも戻り値TreeNodeが格納されていない場合はそこで終了
                        trvWorkInfo_Reference.SelectedNode = t
                        Exit For
                    End If
                Next
                If trvWorkInfo_Reference.SelectedNode IsNot Nothing Then trvWorkInfo_Reference.SelectedNode.ExpandAll()
            Finally
                AddHandler trvWorkInfo_Reference.AfterSelect, AddressOf trvWorkInfo_Reference_AfterSelect
            End Try
        End If
    End Sub

    Private Sub ChangeModeDbgMEISAI()

        If NUCheck(trvWorkInfo.SelectedNode) Then Return

        OutPutDebugLog(System.Reflection.MethodBase.GetCurrentMethod.Name)

        If trvWorkInfo.SelectedNode.Level < 1 OrElse trvWorkInfo.Enabled = False Then
            dbgMEISAI.AllowAddNew = False
            dbgMEISAI.Enabled = False
            lblSyosuName.Enabled = False
        Else
            lblSyosuName.Enabled = True
            dbgMEISAI.AllowAddNew = True
            dbgMEISAI.Enabled = True
        End If
    End Sub

    Private Sub trvWorkInfo_BeforeSelect(ByVal sender As Object, ByVal e As TreeViewCancelEventArgs) Handles trvWorkInfo.BeforeSelect, trvWorkInfo_Reference.BeforeSelect

        OutPutDebugLog(System.Reflection.MethodBase.GetCurrentMethod.Name)

        '最終階層(10階層目)は選択させない
        If e.Node.Level >= intKaisoSuu + 2 Then e.Cancel = True
    End Sub

    Private Sub lblSyosuName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblSyosuName.Click

        OutPutDebugLog(System.Reflection.MethodBase.GetCurrentMethod.Name)

        'データが編集中なら確定させる
        If dbgMEISAI.DataChanged Then dbgMEISAI.UpdateData()

        If CInt(lblSyosu.Text) < 3 Then
            lblSyosu.Text = CStr(CInt(lblSyosu.Text) + 1)
        Else
            lblSyosu.Text = "0"
        End If
        lblSyosuName.Text = "数量小数点以下桁数：  " & StrConv(lblSyosu.Text, VbStrConv.Wide) & "位"

        'Refreshメソッド実行でFormatTextEvent発生
        dbgMEISAI.Refresh()

        Using cur As New WaitCursor

            '全体の値を基底データより再計算する
            Dim dt = CType(dbgMEISAI.DataSource, dsMIT0001.T_MITUMORISelectDataTable)
            For Each dr In dt

                '1行目のデータは再計算不要
                If NUCheck(dr.SUU) Then Continue For

                If dr.GENTANKA <> 0 Then
                    '原価金額（数量 * 原単価）
                    dr.GENKAGAKU = Utility.Round(GetRoundValue(dr.SUU) * CDec(dr.GENTANKA), 0, CInt(strS_SCB_ROUND_GENKAKIN))
                    '計算結果桁数チェック
                    If CDec(dr.GENKAGAKU) > 999999999999 Then dr.GENKAGAKU = 999999999999
                End If

                If dr.TANKA <> 0 Then
                    '見積金額（数量 * 見積単価）
                    dr.GAKU = Utility.Round(GetRoundValue(dr.SUU) * CDec(dr.TANKA), 0, CInt(strS_SCB_ROUND_MITKAKIN))
                    '見積金額税抜（数量 * 見積単価）
                    dr.GAKU_NUKI = Utility.Round(GetRoundValue(dr.SUU) * CDec(dr.TANKA), 0, CInt(strS_SCB_ROUND_MITKAKIN))
                    '計算結果桁数チェック
                    If CDec(dr.GAKU) > 999999999999 Then dr.GAKU = 999999999999
                    If CDec(dr.GAKU_NUKI) > 999999999999 Then dr.GAKU_NUKI = 999999999999
                End If
            Next

            'グリッドにデータテーブルをソートしてセット
            DbgMeisaiSetBinding(dt, True)

            '選択階層が上位階層の場合を考慮して、再度ノードを選択しなおす
            Dim node As TreeNode

            Try
                RemoveHandler trvWorkInfo.AfterSelect, AddressOf trvWorkInfo_AfterSelect

                node = trvWorkInfo.SelectedNode

                trvWorkInfo.SelectedNode = Nothing

            Finally
                AddHandler trvWorkInfo.AfterSelect, AddressOf trvWorkInfo_AfterSelect
            End Try

            trvWorkInfo.SelectedNode = node
        End Using
    End Sub

    Private Sub lblMITUMORINO_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblMITUMORINO.TextChanged
        Dim intHyphen As Integer

        intHyphen = CInt(IIf(lblMITUMORINO.Text.IndexOf("-") > 0, lblMITUMORINO.Text.IndexOf("-"), 0))
        If intHyphen <> 0 Then
            txtMITUMORIEDABAN.Text = Utility.RightBSA(lblMITUMORINO.Text, Utility.LenBSA(lblMITUMORINO.Text) - (intHyphen + 1))
        Else
            txtMITUMORIEDABAN.Text = vbNullString
        End If
    End Sub

    Private Sub cmbMITUMORINO_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbMITUMORINO.SelectionChangeCommitted
        Call Me.txtMITUMORIEDABAN_KeyDown(txtMITUMORIEDABAN, New KeyEventArgs(Keys.Enter))
    End Sub

    Private Sub txtMITUMORIEDABAN_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtMITUMORIEDABAN.KeyDown
        Dim blnRet As Boolean
        Dim decMitumoriEdaban As Decimal = 0

        'エンターキー以外は処理しない
        If e.KeyCode <> Keys.Enter Then Return

        OutPutDebugLog(System.Reflection.MethodBase.GetCurrentMethod.Name)

        If NUCheck(txtMITUMORIEDABAN.Text) Then
            '新規の場合
            TitleBar.EditMode = EditMode.Create

            txtMITUMORIEDABAN.Text = vbNullString

            trvWorkInfo_AfterSelect(Nothing, Nothing)

        Else
            '更新の場合

            '見積枝番チェック（標準）
            If Not txtMITUMORIEDABAN.ValidateMe Then
                txtMITUMORIEDABAN.Focus()
                Return
            End If

            'エラーチェック
            If fncInputErrorCheck(CType(sender, Control), GetTabOrder(CType(sender, Control)) + 1) = False Then
                Return
            End If

            If Not NUCheck(txtMITUMORIEDABAN.Text) Then
                decMitumoriEdaban = CDec(txtMITUMORIEDABAN.Text)
            End If

            '基本情報検索
            blnRet = fncKeyInfoCopy(1, CDec(txtMITUMORINO.Text), decMitumoriEdaban)
            If blnRet = False Then
                txtMITUMORIEDABAN.Focus()
                Return
            End If

            TitleBar.EditMode = EditMode.Edit
        End If

        '画面操作環境制御：条件部を入力不可状態に
        Call subFormSwitch(enumFormStatus.DetailInput)

        'グリッドの設定の変更処理
        ChangeModeDbgMEISAI()

        txtTEISYUTUDATE.Focus()
    End Sub

    Private Sub ChangeFunctionKeyDisabled(ByVal sender As Object, ByVal e As System.EventArgs)

        If strFormStatus = "KeyInput" Then Return

        OutPutDebugLog(System.Reflection.MethodBase.GetCurrentMethod.Name)

        '*** 検索ボタン使用不可 ***
        FunctionKey.ItemEnabled(FUNC_KAMOKU_HINMOKU) = False
        FunctionKey.ItemEnabled(FUNC_ROW_DELETE) = False
        FunctionKey.ItemEnabled(FUNC_ROW_UP) = False
        FunctionKey.ItemEnabled(FUNC_ROW_DOWN) = False
        FunctionKey.ItemEnabled(FUNC_SEARCH) = False
    End Sub

    Private Sub EventHandlerComboBox(ByVal sender As Object, ByVal e As System.EventArgs)

        If strFormStatus = "KeyInput" Then Exit Sub

        OutPutDebugLog(System.Reflection.MethodBase.GetCurrentMethod.Name)

        Dim enabled = False
        If CType(sender, CommonUtility.WinFormControls.TypComboBox).Name = "cmbTantoCode" Then
            enabled = True
        End If

        '*** 検索ボタン使用不可 ***
        FunctionKey.ItemEnabled(FUNC_KAMOKU_HINMOKU) = False
        FunctionKey.ItemEnabled(FUNC_ROW_DELETE) = False
        FunctionKey.ItemEnabled(FUNC_ROW_UP) = False
        FunctionKey.ItemEnabled(FUNC_ROW_DOWN) = False
        FunctionKey.ItemEnabled(FUNC_SEARCH) = enabled
    End Sub

    Private Sub txtSAI_MITUMORIEDABAN_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSAI_MITUMORIEDABAN.TextChanged
        blnSai_MitumoriNoChg = True
    End Sub

    Private Sub cmbSAI_MITUMORINO_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSAI_MITUMORINO.SelectionChangeCommitted
        Dim blnRet As Boolean
        Dim intHyphen As Integer

        OutPutDebugLog(System.Reflection.MethodBase.GetCurrentMethod.Name)

        intHyphen = CInt(IIf(lblSAI_MITUMORINO.Text.IndexOf("-") > 0, lblSAI_MITUMORINO.Text.IndexOf("-"), 0))
        If intHyphen <> 0 Then
            txtSAI_MITUMORIEDABAN.Text = Utility.RightBSA(lblSAI_MITUMORINO.Text, Utility.LenBSA(lblSAI_MITUMORINO.Text) - (intHyphen + 1))
        Else
            txtSAI_MITUMORIEDABAN.Text = vbNullString
        End If

        '基本情報検索
        blnRet = fncKeyInfoCopy(3, CDec(txtSAI_MITUMORINO.Text), CDec(txtSAI_MITUMORIEDABAN.Text))
        If blnRet = False Then
            SendKeys.Send("+{TAB 2}")
            Exit Sub
        End If
        SendKeys.Send("{TAB}")
    End Sub

    Private Sub txtSAN_MITUMORINO_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSAN_MITUMORINO.TextChanged
        blnSan_MitumoriNoChg = True
    End Sub

    Private Sub txtSAN_MITUMORIEDABAN_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSAN_MITUMORIEDABAN.TextChanged
        blnSan_MitumoriNoChg = True
    End Sub

    Private Sub cmbSAN_MITUMORINO_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSAN_MITUMORINO.SelectionChangeCommitted
        Dim blnRet As Boolean
        Dim intHyphen As Integer

        OutPutDebugLog(System.Reflection.MethodBase.GetCurrentMethod.Name)

        intHyphen = CInt(IIf(lblSAN_MITUMORINO.Text.IndexOf("-") > 0, lblSAN_MITUMORINO.Text.IndexOf("-"), 0))
        If intHyphen <> 0 Then
            txtSAN_MITUMORINO.Text = Utility.LeftBSA(lblSAN_MITUMORINO.Text, intHyphen)
            txtSAN_MITUMORIEDABAN.Text = Utility.RightBSA(lblSAN_MITUMORINO.Text, Utility.LenBSA(lblSAN_MITUMORINO.Text) - (intHyphen + 1))
        Else
            txtSAN_MITUMORINO.Text = lblSAN_MITUMORINO.Text
            txtSAN_MITUMORIEDABAN.Text = vbNullString
        End If

        '基本情報検索
        blnRet = fncKeyInfoCopy(4, CDec(txtSAN_MITUMORINO.Text), CDec(txtSAN_MITUMORIEDABAN.Text))
        If blnRet = False Then
            SendKeys.Send("+{TAB 2}")
            Exit Sub
        End If
        SendKeys.Send("{TAB}")
    End Sub

    Private Sub txtKoujiName_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtKoujiName.Leave
        '工事名称変更処理
        ChangeTxtKoujiName()
    End Sub

    Private Sub ChangeTxtKoujiName()

        '工事名称に変更がない場合、処理しない
        If trvWorkInfo.Nodes.Count <> 0 Then
            If trvWorkInfo.Nodes(0).Nodes(0).Text = txtKoujiName.Text Then Return
        End If

        'ﾂﾘｰにｾｯﾄ
        fncTreeWorkInfoSet()

        trvWorkInfo.SelectedNode = trvWorkInfo.Nodes(0).Nodes(0)
    End Sub

    Private Sub txtSAI_MITUMORIEDABAN_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtSAI_MITUMORIEDABAN.KeyDown
        Dim blnRet As Boolean

        If e.KeyCode <> Keys.Enter Then Exit Sub

        If NUCheck(txtSAI_MITUMORIEDABAN.Text) Then Exit Sub

        If blnSai_MitumoriNoChg = False Then Exit Sub

        OutPutDebugLog(System.Reflection.MethodBase.GetCurrentMethod.Name)

        'エラーチェック
        If fncInputErrorCheck(CType(sender, Control), GetTabOrder(CType(sender, Control)) + 1) = False Then
            Return
        End If

        '基本情報検索
        blnRet = fncKeyInfoCopy(3, CDec(txtSAI_MITUMORINO.Text), CDec(txtSAI_MITUMORIEDABAN.Text))
        If blnRet = False Then
            txtSAI_MITUMORIEDABAN.Focus()
            Exit Sub
        End If

        txtSAN_MITUMORINO.Focus()
    End Sub

    Private Sub txtSAN_MITUMORIEDABAN_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtSAN_MITUMORIEDABAN.KeyDown
        Dim blnRet As Boolean

        If e.KeyCode <> Keys.Enter Then Exit Sub

        If NUCheck(txtSAN_MITUMORINO.Text) Then Exit Sub

        If NUCheck(txtSAN_MITUMORIEDABAN.Text) Then Exit Sub

        If blnSan_MitumoriNoChg = False Then Exit Sub

        OutPutDebugLog(System.Reflection.MethodBase.GetCurrentMethod.Name)

        '参照見積枝番チェック（標準）
        If Not txtSAN_MITUMORINO.ValidateMe Then
            txtSAN_MITUMORINO.Focus()
            Return
        End If

        'エラーチェック
        If fncInputErrorCheck(CType(sender, Control), GetTabOrder(CType(sender, Control)) + 1) = False Then
            Return
        End If

        '基本情報検索
        blnRet = fncKeyInfoCopy(4, CDec(txtSAN_MITUMORINO.Text), CDec(txtSAN_MITUMORIEDABAN.Text))
        If blnRet = False Then
            txtSAN_MITUMORINO.Focus()
            Exit Sub
        End If

        cmbKEISYOUCODE.Focus()
    End Sub

    Private Sub dbgMEISAI_AfterColUpdate(ByVal sender As Object, ByVal e As ColEventArgs) Handles dbgMEISAI.AfterColUpdate

        OutPutDebugLog(System.Reflection.MethodBase.GetCurrentMethod.Name)

        Select Case dbgMEISAI.Col
            Case COL_KAKERITU
                '掛率
                If dbgMEISAI.Row <> 0 Then
                    '1行目以外の場合

                    '金額計算
                    subDbgCalcKingaku("ONE")

                Else
                    '1行目の場合
                    Dim decIkatuKakeritu = CDec(dbgMEISAI(0, COL_KAKERITU).ToString)

                    '全明細の掛率の変更
                    For intI = 1 To dbgMEISAI.RowCount - 1
                        Dim decKakeritu = CDec(dbgMEISAI(intI, COL_IKATU_KAKERITU).ToString)

                        '一括掛率
                        dbgMEISAI(intI, COL_IKATU_KAKERITU) = CStr(decIkatuKakeritu)

                        '合計行の場合、変更しない
                        If CheckGokeiLine(dbgMEISAI.Row) Then Continue For

                        '掛率が変更されている場合、変更しない
                        If decKakeritu <> dbgMEISAI(intI, COL_KAKERITU) Then Continue For

                        '掛率
                        dbgMEISAI(intI, COL_KAKERITU) = CStr(decIkatuKakeritu)
                    Next

                    '金額計算
                    subDbgCalcKingaku("ALL")
                End If

            Case COL_SUU, COL_GENTANKA
                '数量、原単価

                '金額計算
                subDbgCalcKingaku("ONE")

            Case COL_GAKU_NUKI
                '受注金額
                dbgMEISAI.Columns(COL_GAKU).Value = dbgMEISAI.Columns(COL_GAKU_NUKI).Value
        End Select

        'グリッドの確定
        DbgMeisaiSetBinding(dbgMEISAI.DataSource, True)

        'ツリービューの更新
        TrvWorkInfoUpdate()
    End Sub

    ''' <summary>
    ''' ツリーの科目・品目名の表示を更新
    ''' </summary>
    Private Sub TrvWorkInfoUpdate()
        If trvWorkInfo.SelectedNode.Level = CInt(trvWorkInfo.Tag) Then
            If trvWorkInfo.SelectedNode.GetNodeCount(False) < dbgMEISAI.Row Then
                trvWorkInfo.SelectedNode.Nodes.Add(dbgMEISAI.Columns(COL_KAMOKU_HINMOKU).Value)
                trvWorkInfo.SelectedNode.Expand()
            Else
                If (dbgMEISAI.Row - 1) >= 0 Then
                    trvWorkInfo.SelectedNode.Nodes(dbgMEISAI.Row - 1).Text = dbgMEISAI.Columns(COL_KAMOKU_HINMOKU).Value
                End If
            End If

            If (dbgMEISAI.Row - 1) >= 0 Then
                trvWorkInfo.SelectedNode.Nodes(dbgMEISAI.Row - 1).Name = dbgMEISAI.Columns(COL_KAMOKU_HINMOKU).Value
                trvWorkInfo.SelectedNode.Nodes(dbgMEISAI.Row - 1).Tag = dbgMEISAI.Columns(COL_KAISOCODE).Value
            End If
        End If

        RaiseEvent TreeNodeAddInsertDelete(trvWorkInfo)
    End Sub

    Private Sub dbgMEISAI_AfterDelete(ByVal sender As Object, ByVal e As System.EventArgs) Handles dbgMEISAI.AfterDelete

        OutPutDebugLog(System.Reflection.MethodBase.GetCurrentMethod.Name)

        '新規行追加設定
        subDbgAddNewSet()
    End Sub

    Private Sub dbgMEISAI_AfterUpdate(ByVal sender As Object, ByVal e As System.EventArgs) Handles dbgMEISAI.AfterUpdate

        OutPutDebugLog(System.Reflection.MethodBase.GetCurrentMethod.Name)

        '新規行追加設定
        subDbgAddNewSet()
    End Sub

    ''' <summary>
    ''' セル入力エラーチェック・マスタデータ取得・数値計算・文字列整形
    ''' </summary>
    Private Sub dbgMEISAI_BeforeColUpdate(ByVal sender As Object, ByVal e As BeforeColUpdateEventArgs) Handles dbgMEISAI.BeforeColUpdate
        Dim strCtrlName As String
        Dim intI As Integer

        OutPutDebugLog(System.Reflection.MethodBase.GetCurrentMethod.Name)

        With dbgMEISAI

            Select Case e.ColIndex

                '科目・品目
                Case COL_KAMOKU_HINMOKU

                    strCtrlName = "科目・品目"

                    '必須チェック
                    If NUCheck(.Columns(e.ColIndex).Text) Then
                        .Columns(COL_KAMOKU_HINMOKU).Text = strS_SCB_DEFAULT_04
                    End If

                    '桁数チェック40byte
                    If LenBSA(.Columns(e.ColIndex).Text) > 40 Then
                        MessageBoxEx.Show(MessageCode_Arg1.M020の桁数が大きすぎます, strCtrlName, Me.Text)
                        GoTo CheckError
                    End If

                    '品質・規格・仕様
                Case COL_HINSITU_KIKAKU_SIYO

                    strCtrlName = "品質・規格・仕様"

                    '桁数チェック40byte
                    If LenBSA(.Columns(e.ColIndex).Text) > 40 Then
                        MessageBoxEx.Show(MessageCode_Arg1.M020の桁数が大きすぎます, strCtrlName, Me.Text)
                        GoTo CheckError
                    End If

                    '担当下請
                Case COL_SIIRECODE

                    strCtrlName = "担当下請"
                    If Not NUCheck(.Columns(e.ColIndex).Text) Then

                        '存在チェック
                        Dim logic As New M_SIIRERead()
                        Dim dbM_SIIREValue = logic.GetM_SIIRE

                        For intI = 0 To dbM_SIIREValue.Tables(0).Rows.Count - 1
                            If CStr(.Columns(e.ColIndex).Text) = dbM_SIIREValue.Tables(0).Rows(intI).Item("SIIRENAME").ToString Then
                                Exit For
                            End If
                        Next
                        If intI > dbM_SIIREValue.Tables(0).Rows.Count - 1 Then
                            MessageBoxEx.Show(MessageCode_Arg1.M014が存在しません, strCtrlName, Me.Text)
                            GoTo CheckError
                        End If
                    End If

                    '数量
                Case COL_SUU

                    strCtrlName = "数量"
                    '空白チェック
                    If NUCheck(.Columns(e.ColIndex).Text) = True Then
                        .Columns(COL_SUU).Text = "0"
                    End If
                    '数値チェック
                    If Not IsNumeric(.Columns(e.ColIndex).Text) Then
                        MessageBoxEx.Show(MessageCode_Arg1.M019には数字を入力して下さい, strCtrlName, Me.Text)
                        GoTo CheckError
                    End If
                    '桁数チェック
                    If CDec(.Columns(e.ColIndex).Text) > 99999999.999 Then
                        MessageBoxEx.Show(MessageCode_Arg1.M020の桁数が大きすぎます, strCtrlName, Me.Text)
                        GoTo CheckError
                    End If
                    '後マイナスチェック
                    .Columns(e.ColIndex).Text = CStr(CDec(.Columns(e.ColIndex).Text))

                    '丸め後の値を保持
                    .Columns(e.ColIndex).Text = GetRoundValue(.Columns(e.ColIndex).Text).ToString

                    '合計計算
                    Call subDbgSumMeisai()

                    '単位
                Case COL_TANI
                    strCtrlName = "単位"

                    '桁数チェック10byte
                    If LenBSA(.Columns(e.ColIndex).Text) > 10 Then
                        MessageBoxEx.Show(MessageCode_Arg1.M020の桁数が大きすぎます, strCtrlName, Me.Text)
                        GoTo CheckError
                    End If

                    '原単価
                Case COL_GENTANKA

                    strCtrlName = "原単価"
                    '空白チェック
                    If NUCheck(.Columns(e.ColIndex).Text) = True Then
                        .Columns(COL_GENTANKA).Text = "0"
                    End If
                    '数値チェック
                    If Not IsNumeric(.Columns(e.ColIndex).Text) Then
                        MessageBoxEx.Show(MessageCode_Arg1.M019には数字を入力して下さい, strCtrlName, Me.Text)
                        GoTo CheckError
                    End If
                    '桁数チェック
                    If CDec(.Columns(e.ColIndex).Text) > 999999999.999 Then
                        MessageBoxEx.Show(MessageCode_Arg1.M020の桁数が大きすぎます, strCtrlName, Me.Text)
                        GoTo CheckError
                    End If
                    '後マイナスチェック
                    .Columns(e.ColIndex).Text = CStr(CDec(.Columns(e.ColIndex).Text))

                    '合計計算
                    Call subDbgSumMeisai()

                    '原価金額
                Case COL_GENKAGAKU

                    strCtrlName = "原価金額"
                    '空白チェック
                    If NUCheck(.Columns(e.ColIndex).Text) = True Then
                        .Columns(e.ColIndex).Text = "0"
                    End If
                    '数値チェック
                    If Not IsNumeric(.Columns(e.ColIndex).Text) Then
                        MessageBoxEx.Show(MessageCode_Arg1.M019には数字を入力して下さい, strCtrlName, Me.Text)
                        GoTo CheckError
                    End If
                    '桁数チェック
                    If CDec(.Columns(e.ColIndex).Text) > 999999999999 Then
                        MessageBoxEx.Show(MessageCode_Arg1.M020の桁数が大きすぎます, strCtrlName, Me.Text)
                        GoTo CheckError
                    End If
                    '後マイナスチェック
                    .Columns(e.ColIndex).Text = CStr(CDec(.Columns(e.ColIndex).Text))

                    '合計計算
                    Call subDbgSumMeisai()

                    '掛率(%)
                Case COL_KAKERITU

                    strCtrlName = "掛率"
                    '空白チェック
                    If NUCheck(.Columns(e.ColIndex).Text) = True Then
                        If dbgMEISAI.RowCount > 1 Then
                            .Columns(e.ColIndex).Value = dbgMEISAI(0, COL_KAKERITU)
                        Else
                            .Columns(e.ColIndex).Value = strS_SCB_DEFAULT_03
                        End If
                    End If
                    '数値チェック
                    If Not IsNumeric(.Columns(e.ColIndex).Text) Then
                        MessageBoxEx.Show(MessageCode_Arg1.M019には数字を入力して下さい, strCtrlName, Me.Text)
                        GoTo CheckError
                    End If
                    '桁数チェック
                    If CDec(.Columns(e.ColIndex).Text) > 99999.999 Then
                        MessageBoxEx.Show(MessageCode_Arg1.M020の桁数が大きすぎます, strCtrlName, Me.Text)
                        GoTo CheckError
                    End If
                    '後マイナスチェック
                    .Columns(e.ColIndex).Text = CStr(CDec(.Columns(e.ColIndex).Text))

                    '合計計算
                    Call subDbgSumMeisai()

                    '見積単価
                Case COL_TANKA

                    strCtrlName = "見積単価"
                    '空白チェック
                    If NUCheck(.Columns(e.ColIndex).Text) = True Then
                        .Columns(e.ColIndex).Text = "0"
                    End If
                    '数値チェック
                    If Not IsNumeric(.Columns(e.ColIndex).Text) Then
                        MessageBoxEx.Show(MessageCode_Arg1.M019には数字を入力して下さい, strCtrlName, Me.Text)
                        GoTo CheckError
                    End If
                    '桁数チェック
                    If CDec(.Columns(e.ColIndex).Text) > 999999999.999 Then
                        MessageBoxEx.Show(MessageCode_Arg1.M020の桁数が大きすぎます, strCtrlName, Me.Text)
                        GoTo CheckError
                    End If
                    '後マイナスチェック
                    .Columns(e.ColIndex).Text = Str(CDec(.Columns(e.ColIndex).Text))
                    '見積単価に変更が加わった場合、見積金額再計算
                    '見積金額（数量 * 見積単価）
                    .Columns(COL_GAKU).Value = Utility.Round(GetRoundValue(NZ(dbgMEISAI.Columns(COL_SUU).Value).ToString) * NZ(dbgMEISAI.Columns(COL_TANKA).Value), 0, CInt(strS_SCB_ROUND_MITKAKIN))
                    '見積金額税抜（数量 * 見積単価）
                    .Columns(COL_GAKU_NUKI).Value = Utility.Round(GetRoundValue(NZ(dbgMEISAI.Columns(COL_SUU).Value).ToString) * NZ(dbgMEISAI.Columns(COL_TANKA).Value), 0, CInt(strS_SCB_ROUND_MITKAKIN))
                    '計算結果桁数チェック
                    If CDec(dbgMEISAI.Columns(COL_GAKU).Value) > 999999999999 Then dbgMEISAI.Columns(COL_GAKU).Value = 999999999999
                    If CDec(dbgMEISAI.Columns(COL_GAKU_NUKI).Value) > 999999999999 Then dbgMEISAI.Columns(COL_GAKU_NUKI).Value = 999999999999
                    '合計計算
                    Call subDbgSumMeisai()

                    '見積金額
                Case COL_GAKU

                    strCtrlName = "見積金額"
                    '空白チェック
                    If NUCheck(.Columns(e.ColIndex).Text) = True Then
                        .Columns(e.ColIndex).Text = "0"
                    End If
                    '数値チェック
                    If Not IsNumeric(.Columns(e.ColIndex).Text) Then
                        MessageBoxEx.Show(MessageCode_Arg1.M019には数字を入力して下さい, strCtrlName, Me.Text)
                        GoTo CheckError
                    End If
                    '桁数チェック
                    If CDec(.Columns(e.ColIndex).Text) > 999999999999 Then
                        MessageBoxEx.Show(MessageCode_Arg1.M020の桁数が大きすぎます, strCtrlName, Me.Text)
                        GoTo CheckError
                    End If
                    '後マイナスチェック
                    .Columns(e.ColIndex).Text = CStr(CDec(.Columns(e.ColIndex).Text))

                    '合計計算
                    Call subDbgSumMeisai()

                    '見積金額税抜
                Case COL_GAKU_NUKI

                    strCtrlName = "見積金額"
                    '空白チェック
                    If NUCheck(.Columns(e.ColIndex).Text) = True Then
                        .Columns(e.ColIndex).Text = "0"
                    End If
                    '数値チェック
                    If Not IsNumeric(.Columns(e.ColIndex).Text) Then
                        MessageBoxEx.Show(MessageCode_Arg1.M019には数字を入力して下さい, strCtrlName, Me.Text)
                        GoTo CheckError
                    End If
                    '桁数チェック
                    If CDec(.Columns(e.ColIndex).Text) > 999999999999 Then
                        MessageBoxEx.Show(MessageCode_Arg1.M020の桁数が大きすぎます, strCtrlName, Me.Text)
                        GoTo CheckError
                    End If
                    '後マイナスチェック
                    .Columns(e.ColIndex).Text = CStr(CDec(.Columns(e.ColIndex).Text))

                    '合計計算
                    Call subDbgSumMeisai()

                    '備考
                Case COL_G_BIKO

                    strCtrlName = "備考"
                    '入力禁止文字チェック
                    If CommonUtility.InputCheck.KinMojiCheck(.Columns(e.ColIndex).Text) = False Then
                        Me.Focus()
                        MessageBoxEx.Show(MessageCode_Arg1.M075入力禁止文字が含まれています, strCtrlName, Me.Text)
                        GoTo CheckError
                    End If

                    '桁数チェック40byte
                    If LenBSA(.Columns(e.ColIndex).Text) > 40 Then
                        MessageBoxEx.Show(MessageCode_Arg1.M020の桁数が大きすぎます, strCtrlName, Me.Text)
                        GoTo CheckError
                    End If
            End Select
        End With

        Exit Sub

CheckError:
        e.Cancel = True
    End Sub

    '与えられたノードに対する全ての階層コードを引数２で書き換える
    '親ノード001001 引数001003
    '子ノードも001001001 001001002 001001001001 のように割り当てられているので、全てのノードを検索して、ノードタグを引数の桁まで値をかきかえる
    '上記例だと　子ノード001001001　⇒　001003001とする
    Private Sub fncCnvNodeKaiso(ByRef tr As TreeNode, ByVal KaisoCode As String)

        tr.Tag = (KaisoCode + NS(tr.Tag).Substring(LenBSA(KaisoCode))).ToString

        For Each t As TreeNode In tr.Nodes
            fncCnvNodeKaiso(t, KaisoCode)
        Next
    End Sub

    Private Sub dbgMEISAI_Error(ByVal sender As Object, ByVal e As ErrorEventArgs) Handles dbgMEISAI.Error

        OutPutDebugLog(System.Reflection.MethodBase.GetCurrentMethod.Name)

        Console.WriteLine(e.Exception.Message)
        e.Handled = True
    End Sub

    Private Sub dbgMEISAI_FormatText(ByVal sender As Object, ByVal e As FormatTextEventArgs) Handles dbgMEISAI.FormatText

        If Decimal.TryParse(e.Value, 0) = False Then Exit Sub

        OutPutDebugLog(System.Reflection.MethodBase.GetCurrentMethod.Name)

        Dim dec As Decimal = Decimal.Parse(e.Value)

        With CType(sender, C1TrueDBGrid)
            Select Case e.ColIndex
                Case COL_SUU
                    dec = GetRoundValue(dec.ToString)
                    Select Case CInt(lblSyosu.Text)
                        Case 0 : e.Value = dec.ToString("#,##0")
                        Case Else : e.Value = dec.ToString("#,##0." & StrDup(CInt(lblSyosu.Text), "0"))
                    End Select
                Case COL_KAKERITU
                    e.Value = dec.ToString("#,##0.000")
                Case Else
                    e.Value = dec.ToString("#,##0")
            End Select
        End With
    End Sub

    Private Sub dbgMEISAI_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles dbgMEISAI.KeyDown
        OutPutDebugLog(System.Reflection.MethodBase.GetCurrentMethod.Name)

        blnComboboxEnter = False

        Select Case dbgMEISAI.Col

            '単位
            Case COL_TANI
                '1行目以外かつ、Enterキーの場合
                If dbgMEISAI.Row <> 0 AndAlso e.KeyCode = Keys.Enter Then
                    blnComboboxEnter = True
                End If

            '仕入先
            Case COL_SIIRECODE
                '1行目以外かつ、Enterキーの場合
                If dbgMEISAI.Row <> 0 AndAlso e.KeyCode = Keys.Enter Then
                    blnComboboxEnter = True
                End If

            '原単価
            Case COL_GENTANKA
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

                '原価金額
            Case COL_GENKAGAKU
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

                '掛率(%)
            Case COL_KAKERITU
                '数値以外の入力を無効にする
                blnDbgKeyCtrlFlg = False
                If e.KeyCode >= Keys.LButton And e.KeyCode <= Keys.Help Then            '=== 色々キーコード
                ElseIf e.KeyCode >= Keys.D0 And e.KeyCode <= Keys.D9 Then               '=== ０～９キー
                ElseIf e.KeyCode >= Keys.NumPad0 And e.KeyCode <= Keys.NumPad9 Then     '=== テンキー
                ElseIf e.KeyCode = Keys.Decimal Then                                  '=== 小数点
                ElseIf e.KeyCode = Keys.NumLock Then                                  '=== NumLockキー
                ElseIf e.KeyCode = Keys.Subtract Then                                 '=== マイナスキー
                Else
                    blnDbgKeyCtrlFlg = True
                End If

                '数量
            Case COL_SUU
                '数値以外の入力を無効にする
                blnDbgKeyCtrlFlg = False
                If e.KeyCode >= Keys.LButton And e.KeyCode <= Keys.Help Then            '=== 色々キーコード
                ElseIf e.KeyCode >= Keys.D0 And e.KeyCode <= Keys.D9 Then               '=== ０～９キー
                ElseIf e.KeyCode >= Keys.NumPad0 And e.KeyCode <= Keys.NumPad9 Then     '=== テンキー
                ElseIf e.KeyCode = Keys.Decimal Then                                  '=== 小数点
                ElseIf e.KeyCode = Keys.NumLock Then                                  '=== NumLockキー
                ElseIf e.KeyCode = Keys.Subtract Then                                 '=== マイナスキー
                ElseIf e.KeyCode = 189 Then
                ElseIf e.KeyCode = 190 Then
                Else
                    blnDbgKeyCtrlFlg = True
                End If

                '受注単価
            Case COL_TANKA
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

                '受注金額
            Case COL_GAKU, COL_GAKU_NUKI
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

    Private Sub dbgMEISAI_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles dbgMEISAI.KeyPress

        OutPutDebugLog(System.Reflection.MethodBase.GetCurrentMethod.Name)

        Select Case dbgMEISAI.Col
            Case COL_SUU, COL_GENTANKA, COL_GENKAGAKU, COL_KAKERITU, COL_TANKA, COL_GAKU, COL_GAKU_NUKI
                '*** キー入力無効制御 ***
                'KeyDown()で数値以外のキーが押された場合
                If blnDbgKeyCtrlFlg = True Then
                    e.KeyChar = CChar("")
                    blnDbgKeyCtrlFlg = False
                End If
        End Select
    End Sub

    Private Sub dbgMEISAI_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim control = Me.ActiveControl

        OutPutDebugLog(System.Reflection.MethodBase.GetCurrentMethod.Name)

        Try
            RemoveHandler dbgMEISAI.Leave, AddressOf dbgMEISAI_Leave

            '行移動の背景色をクリアする
            subInitGrid()

            'グリッドの初期化で新規行を表示する設定のため、グリッドの再設定を行う。
            ChangeModeDbgMEISAI()

            'DBGridの更新を済ませてからフォーカス移動
            If (dbgMEISAI.DataChanged = True) Then
                dbgMEISAI.UpdateData()
            End If

            '「行移動の背景色をクリアする」にてグリッドにフォーカス移動されるので、フォーカス位置を移動する
            '移動するとフォーカスアウト処理が動作するので、一時的に無効にする
            control.Focus()
        Finally
            AddHandler dbgMEISAI.Leave, AddressOf dbgMEISAI_Leave
        End Try
    End Sub

    Private Sub dbgMEISAI_OnAddNew(ByVal sender As Object, ByVal e As System.EventArgs) Handles dbgMEISAI.OnAddNew

        '大科目の9階層目を追加する場合
        If Not NUCheck(trvWorkInfo.SelectedNode) _
                AndAlso trvWorkInfo.SelectedNode.Level = 1 _
                AndAlso dbgMEISAI.Row = 9 Then
            If MessageBoxEx.Show(CommonUtility.MessageCode_Arg0.M223, PROGRAM_NAME) = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If
        End If

        OutPutDebugLog(System.Reflection.MethodBase.GetCurrentMethod.Name)

        With dbgMEISAI
            .Columns(COL_KAMOKU_HINMOKU).Value = strS_SCB_DEFAULT_04
            .Columns(COL_HINSITU_KIKAKU_SIYO).Value = ""
            .Columns(COL_SIIRECODE).Value = ""
            .Columns(COL_SIIRENAME).Value = ""
            .Columns(COL_SUU).Value = 0
            .Columns(COL_TANI).Value = ""
            .Columns(COL_GENTANKA).Value = 0
            .Columns(COL_GENKAGAKU).Value = 0
            .Columns(COL_KAKERITU).Value = dbgMEISAI(0, COL_KAKERITU)
            .Columns(COL_TANKA).Value = 0
            .Columns(COL_GAKU).Value = 0
            .Columns(COL_GAKU_NUKI).Value = 0
            .Columns(COL_G_BIKO).Value = ""
            .Columns(COL_KAISOCODE).Value = trvWorkInfo.SelectedNode.Tag.ToString & dbgMEISAI.Row.ToString.PadLeft(intKaisoKeta, "0"c)
            .Columns(COL_IKATU_KAKERITU).Value = dbgMEISAI(0, COL_KAKERITU)
            .Columns(COL_ARARIGAKU).Value = 0
            .Columns(COL_DAIKAMOKUCODE).Value = ""
            .Columns(COL_CYUKAMOKUCODE).Value = ""
            .Columns(COL_SYOKAMOKUCODE).Value = ""
        End With

        dbgMEISAI.Refresh()
    End Sub

    Private Function CheckGokeiLine(ByVal NowNodeNumber As Integer) As Boolean

        If Not NowNodeNumber > 0 Then Return False
        If trvWorkInfo.SelectedNode Is Nothing Then Return False
        If Not trvWorkInfo.SelectedNode.Nodes.Count > NowNodeNumber - 1 Then Return False

        Try
            'NowNodeNumberに選択中ノードの子インデックス番号が格納されている
            '子に対する孫が存在した場合は合計行と判断する
            If trvWorkInfo.SelectedNode.Nodes(NowNodeNumber - 1).GetNodeCount(False) > 0 Then
                Return True
            Else
                Return False
            End If

        Catch e As Exception
            e = Nothing
            '例外発生時は合計行とみなさない(存在しないインデックス位置を参照した場合等) 
            Return False
        End Try
    End Function

    Private Sub dbgMEISAI_SelChange(sender As Object, e As CancelEventArgs) Handles dbgMEISAI.SelChange
        'ファンクションキーの設定
        setFunctionKeyChangeDbgMEISAI()
    End Sub

    Private Sub dbgMEISAI_RowColChange(ByVal sender As Object, ByVal e As RowColChangeEventArgs) Handles dbgMEISAI.RowColChange
        '行移動の背景色をクリアする
        intMoveRowValue = 0

        If Me.ActiveControl Is Nothing Then Exit Sub

        OutPutDebugLog(System.Reflection.MethodBase.GetCurrentMethod.Name)

        '*** IMEモード設定 ***
        With dbgMEISAI
            Select Case .Col
                Case COL_SUU, COL_GENTANKA, COL_GENKAGAKU, COL_KAKERITU, COL_TANKA, COL_GAKU, COL_GAKU_NUKI
                    '---ImeMode Off---
                    .ImeMode = Windows.Forms.ImeMode.Disable
                    For Each ctrl As Control In .Controls
                        If TypeOf ctrl Is TextBox Then
                            ctrl.ImeMode = Windows.Forms.ImeMode.Disable
                        End If
                    Next
                Case COL_KAMOKU_HINMOKU, COL_HINSITU_KIKAKU_SIYO, COL_TANI, COL_G_BIKO
                    '---ImeMode Hiragana---
                    .ImeMode = Windows.Forms.ImeMode.Hiragana
                    For Each ctrl As Control In .Controls
                        If TypeOf ctrl Is TextBox Then
                            ctrl.ImeMode = Windows.Forms.ImeMode.Hiragana
                        End If
                    Next
            End Select
        End With

        'ファンクションキーの設定
        setFunctionKeyChangeDbgMEISAI()
    End Sub

    Private Sub dbgMEISAI_BeforeColEdit(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColEditEventArgs) Handles dbgMEISAI.BeforeColEdit
        If dbgMEISAI.Row = 0 Then
            '1行目の場合、掛率が入力可
            If dbgMEISAI.Col = COL_KAKERITU Then Return

        ElseIf CheckGokeiLine(dbgMEISAI.Row) Then
            '合計行（下層が存在）の場合、「科目・品目」「品質・規格・仕様」「備考」が入力可
            If dbgMEISAI.Col = COL_KAMOKU_HINMOKU Then Return
            If dbgMEISAI.Col = COL_HINSITU_KIKAKU_SIYO Then Return
            If dbgMEISAI.Col = COL_G_BIKO Then Return

        Else
            '上記以外の場合、全て入力可
            Return
        End If

        e.Cancel = True
    End Sub

    Private Sub setFunctionKeyChangeDbgMEISAI()
        'ファンクションキーの設定

        '選択したセルごとにボタンの活性にしたかったが、最終項目でタブ移動して次行に移動した際、選択後のセルでイベントが発生しなかった。
        'なので、グリッドフォーカスで使用可能なボタンを活性とし、ボタン押下で処理できない項目の場合、未処理としている。

        If strFormStatus = "KeyInput" Then Exit Sub

        OutPutDebugLog(System.Reflection.MethodBase.GetCurrentMethod.Name)

        '初期化
        FunctionKey.ItemEnabled(FUNC_KAMOKU_HINMOKU) = False
        FunctionKey.ItemEnabled(FUNC_SEARCH) = False
        FunctionKey.ItemEnabled(FUNC_ROW_DELETE) = False
        FunctionKey.ItemEnabled(FUNC_ROW_UP) = False
        FunctionKey.ItemEnabled(FUNC_ROW_DOWN) = False

        If NUCheck(trvWorkInfo.SelectedNode) Then Exit Sub

        'コンボボックスを選択後にEnterキーの場合、dbgMEISAI.Rowが0になるので、KeyDownイベントで判定結果で制御する
        If blnComboboxEnter Then
            FunctionKey.ItemEnabled(FUNC_KAMOKU_HINMOKU) = True
            FunctionKey.ItemEnabled(FUNC_ROW_DELETE) = True
            FunctionKey.ItemEnabled(FUNC_ROW_UP) = True
            FunctionKey.ItemEnabled(FUNC_ROW_DOWN) = True
        End If

        If trvWorkInfo.SelectedNode.Level > 0 AndAlso dbgMEISAI.Row <> 0 Then
            FunctionKey.ItemEnabled(FUNC_KAMOKU_HINMOKU) = True
            FunctionKey.ItemEnabled(FUNC_ROW_DELETE) = True
            FunctionKey.ItemEnabled(FUNC_ROW_UP) = True
            FunctionKey.ItemEnabled(FUNC_ROW_DOWN) = True

            If Not CheckGokeiLine(dbgMEISAI.Row) AndAlso (dbgMEISAI.Col = COL_SIIRECODE OrElse dbgMEISAI.Col = COL_SIIRENAME) Then
                FunctionKey.ItemEnabled(FUNC_SEARCH) = True
            End If
        End If
    End Sub

    'タブ描画
    Private Sub tabDetail_DrawItem(ByVal sender As Object, ByVal e As DrawItemEventArgs) Handles tabDetail.DrawItem

        OutPutDebugLog(System.Reflection.MethodBase.GetCurrentMethod.Name)

        '対象のTabControlを取得
        Dim tab As TabControl = CType(sender, TabControl)
        'タブページのテキストを取得
        Dim txt As String = tab.TabPages(e.Index).Text

        'タブのテキストと背景を描画するためのブラシを決定する
        Dim foreBrush, backBrush As Brush
        Dim rec As Rectangle
        'StringFormatを作成
        Dim sf As New StringFormat
        If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
            '選択されているタブのテキストを赤、背景を青とする
            foreBrush = Brushes.Black
            backBrush = New SolidBrush(Color.Transparent)
            rec = e.Bounds
            '中央に表示する
            sf.Alignment = StringAlignment.Center
            sf.LineAlignment = StringAlignment.Center
        Else
            '選択されていないタブのテキストは灰色、背景を白とする
            foreBrush = Brushes.Black
            backBrush = New SolidBrush(Color.Transparent)
            rec = New Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height + 4)
            '中央に表示する
            sf.Alignment = StringAlignment.Center
            sf.LineAlignment = StringAlignment.Center
        End If

        '背景の描画
        e.Graphics.FillRectangle(backBrush, rec)

        If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
            rec = New Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height + 2)
        Else
            rec = New Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height + 6)
        End If

        'Textの描画
        e.Graphics.DrawString(txt, e.Font, foreBrush, RectangleF.op_Implicit(rec), sf)
    End Sub

    Private Sub tabDetail_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabDetail.SelectedIndexChanged

        OutPutDebugLog(System.Reflection.MethodBase.GetCurrentMethod.Name)

        Select Case Me.tabDetail.SelectedTab.Tag.ToString
            Case "5"
                trvWorkInfo_Reference.Focus()
        End Select
    End Sub

    Private Sub dbgMEISAI_UnboundColumnFetch(ByVal sender As Object, ByVal e As UnboundColumnFetchEventArgs) Handles dbgMEISAI.UnboundColumnFetch
        If e.Column.Caption = "Unbound" Then
            e.Value = CStr(_hash(e.Row))
        End If
    End Sub

    Private Sub dbgMEISAI_UnboundColumnUpdated(ByVal sender As Object, ByVal e As UnboundColumnFetchEventArgs) Handles dbgMEISAI.UnboundColumnUpdated
        If e.Column.Caption = "Unbound" Then
            _hash(e.Row) = e.Value
        End If
    End Sub

    Private Sub dbgMEISAI_FetchCellStyle(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchCellStyleEventArgs) Handles dbgMEISAI.FetchCellStyle

        If NUCheck(trvWorkInfo.SelectedNode) OrElse trvWorkInfo.SelectedNode.Level = 0 Then Exit Sub

        'OutPutDebugLog(System.Reflection.MethodBase.GetCurrentMethod.Name)

        e.CellStyle.BackColor = Color.White

        ' 1行目で一括掛率以外の場合、入力不可の設定
        If (e.Row = 0) And (e.Col <> COL_KAKERITU) Then
            e.CellStyle.BackColor = Color.FromArgb(236, 233, 216)
        End If

        '合計行の入力不可の設定
        If CheckGokeiLine(e.Row) Then
            '合計行の場合
            Select Case e.Col
                Case COL_SUU, COL_TANI, COL_GENTANKA, COL_GENKAGAKU, COL_KAKERITU, COL_TANKA, COL_GAKU_NUKI, COL_SIIRECODE, COL_SIIRENAME
                    '数量、単位、原単価、原価金額、掛率、単価、受注金額、仕入先の場合
                    '科目・品目をフォーカス
                    e.CellStyle.BackColor = Color.FromArgb(236, 233, 216)
            End Select
        End If

        '行移動時にセルをフォーカスしても背景色が変わらないので、ここで背景色を変える
        If e.Row <> 0 AndAlso e.Row = intMoveRowValue AndAlso e.Col = COL_KAMOKU_HINMOKU Then
            e.CellStyle.BackColor = SystemColors.MenuHighlight
        End If

        '掛率を変更した背景色の設定
        If Not Utility.NUCheck(dbgMEISAI(e.Row, COL_KAKERITU)) And (e.Col = COL_KAKERITU) Then
            '合計行は変更しない
            If CheckGokeiLine(e.Row) Then Return

            '1行目と値が同じ場合、変更しない
            If NZ(dbgMEISAI(e.Row, COL_KAKERITU)) = NZ(dbgMEISAI(0, COL_KAKERITU)) Then Return

            e.CellStyle.BackColor = KAKERITU_COLOR
        End If
    End Sub

    Private Function GetRoundValue(ByVal obj As String) As Decimal
        Return clsMIT0001.CnvToDecimalPoint(obj, lblSyosu.Text, strS_SCB_ROUND_MITSUURYO)
    End Function

    Private Sub trvWorkInfo_Reference_AfterSelect(ByVal sender As System.Object, ByVal e As TreeViewEventArgs)
        Dim t As New TreeNode

        OutPutDebugLog(System.Reflection.MethodBase.GetCurrentMethod.Name)

        For Each tre As TreeNode In trvWorkInfo.Nodes
            If fncSearchNode(tre, e.Node, t) Then
                If t Is Nothing Then Exit Sub 'もしも戻り値TreeNodeが格納されていない場合はそこで終了
                trvWorkInfo.SelectedNode = t
                Exit For
            End If
        Next
        trvWorkInfo.SelectedNode.ExpandAll()
    End Sub

    '同一のノードを検索
    Private Function fncSearchNode(ByVal node As TreeNode, ByVal sNode As TreeNode, ByRef t As TreeNode) As Boolean

        If node.Parent Is Nothing AndAlso sNode.Parent Is Nothing Then
            'どちらも親ツリーがない場合は最上位階層とみなす
            t = node
            Return True
        End If

        If node.Parent IsNot Nothing AndAlso sNode.Parent IsNot Nothing Then
            If node.Level = sNode.Level AndAlso node.Index = sNode.Index AndAlso node.Parent.Index = sNode.Parent.Index Then
                t = node
                Return True
            End If
        End If

        For Each n As TreeNode In node.Nodes
            If fncSearchNode(n, sNode, t) Then Return True
        Next

        Return False
    End Function

    '与えられたDataTableより一番下の階層レコードを取得して返す
    Public Shared Function GetLastKaiso(ByVal dt As DataTable) As String

        If dt.Rows.Count = 0 Then Return ""

        Dim dv As DataView = dt.DefaultView

        dv.Sort = "KAISOCODE"

        Dim ret As String = ""

        Try
            ret = dv.Table.Rows(dv.Table.Rows.Count - 1)("KAISOCODE").ToString
        Catch ex As Exception
            ret = "001"
        End Try

        Return ret

    End Function

    Public Enum enumDigit As Integer
        Zero = 0
        One = 1
        Two = 2
        Three = 3
    End Enum

    Public Enum enumDivide As Integer
        Floor = 0
        Round = 1
        Ceiling = 2
    End Enum

    Private Sub PopUpProgram_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Select Case CType(sender, Control).Name
            Case btnMENT0002.Name
                '科目・品目マスタ登録
                Dim f = New frmMENT0002
                f.ShowDialog()

            Case btnMENT0006.Name
                '下請マスタ登録
                Dim f = New frmMENT0006
                f.ShowDialog()

                '担当下請
                ' コンボボックスを設定します
                subRefreshComboSiire()
        End Select
    End Sub

    Private Sub subRefreshComboSiire()
        Dim logic As New M_SIIRERead()
        Dim dbM_SIIREValue = logic.GetM_SIIRE

        With dbgMEISAI
            '外観をコンボボックスに設定
            Dim co1 As C1DataColumn

            '担当下請
            ' コンボボックスを設定します
            co1 = .Columns(COL_SIIRECODE)
            With co1.ValueItems
                .Values.Clear()
                .Values.Add(New ValueItem("", ""))
                For intI As Integer = 0 To dbM_SIIREValue.M_SIIRE.Count - 1
                    .Values.Add(New ValueItem(dbM_SIIREValue.M_SIIRE(intI).SIIRECODE, dbM_SIIREValue.M_SIIRE(intI).SIIRENAME))
                Next intI
                .Presentation = PresentationEnum.ComboBox
                .Translate = True
                .MaxComboItems = 10

            End With

            .Splits(0).DisplayColumns(COL_SIIRECODE).Button = CType(IIf(.Splits(0).DisplayColumns(COL_SIIRECODE).Locked = True, False, True), Boolean)
            .Splits(0).DisplayColumns(COL_SIIRECODE).DropDownList = True
        End With
    End Sub

    Private log As OperationLog.OutPutLog

    '''<summary>
    '''デバッグログ（様々イベントが動作するため、ログ出力）
    ''' </summary>
    Private Sub OutPutDebugLogInit()

        '#If DEBUG Then
        '        Dim dsSystem As DataSet

        '        Dim pcname As String = Environment.MachineName
        '        Dim pgid As String = System.Diagnostics.Process.GetCurrentProcess().ProcessName
        '        Dim usercode As String = ""

        '        'M_NOWUSERよりユーザー取得
        '        dsSystem = GetDbValue.Execute("M_NOWUSER", "TANTOCODE", "PCNAME='" + pcname + "'")
        '        If dsSystem.Tables(0).Rows.Count > 0 Then usercode = dsSystem.Tables(0).Rows(0)(0).ToString

        '        'ログ出力のデフォルトはカレントディレクトリにする
        '        Dim strPath As String = System.IO.Directory.GetCurrentDirectory()
        '        If strPath.EndsWith("\") = False Then strPath += "\"

        '        Dim intDelDay As Integer = 30

        '        log = New OperationLog.OutPutLog(strPath, intDelDay, pcname, usercode, pgid)
        '#End If

    End Sub

    Private Sub OutPutDebugLog(ByVal str As String)
        '#If DEBUG Then
        '        log.Write("0", str, OperationLog.OutPutLog.LogKind.Info)
        '#End If
    End Sub

    Private Sub cmbMitumoriJouken_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMitumoriJouken.SelectedIndexChanged
        'テキストの見積条件の変更
        mitsumoriJyouken.SetTxtMitsumoriJoken(txtMitsumoriJoken, cmbMitumoriJouken)

        If Not NUCheck(mitsumoriJyouken.errMessage) Then
            '見積条件の読み込みでエラーの場合
            MsgBox(mitsumoriJyouken.errMessage)
        End If
    End Sub

    Private Sub btnMitumoriEdit_Click(sender As Object, e As EventArgs) Handles btnMitumoriEdit.Click
        '見積条件のフォルダを開く
        mitsumoriJyouken.OpenMitumoriJoukenFolder()

        If Not NUCheck(mitsumoriJyouken.errMessage) Then
            '見積条件の読み込みでエラーの場合
            MsgBox(mitsumoriJyouken.errMessage)
        End If
    End Sub

    Private Sub cmbMitumoriJouken_Click(sender As Object, e As EventArgs) Handles cmbMitumoriJouken.Click
        '見積条件のリストの作成
        mitsumoriJyouken.SetCmbMitsumoriJyouken(cmbMitumoriJouken)

        If Not NUCheck(mitsumoriJyouken.errMessage) Then
            '見積条件の読み込みでエラーの場合
            MsgBox(mitsumoriJyouken.errMessage)
        End If
    End Sub
End Class
