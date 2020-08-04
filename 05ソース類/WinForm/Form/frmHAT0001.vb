Imports BLL.Common
Imports CommonUtility
Imports CommonUtility.WinForm
Imports CommonUtility.WinFormControls
Imports CommonUtility.Utility
Imports C1.Win.C1TrueDBGrid

Public Class frmHAT0001

    Public Overrides Function PROGRAM_ID() As String
        Return "HAT0001"
    End Function

    Public Overrides Function PROGRAM_NAME() As String
        Return "発注登録"
    End Function

    Private Enum COLMeisai
        KAMOKU_HINMOKU = 0
        HINSITU_KIKAKU_SIYO = 1
        SUU = 2
        TANI = 3
        GENTANKA = 4
        GENKAGAKU = 5
        G_BIKO = 6
        JYUTYUEDABAN = 7
        KAISOCODE = 8
        JYUTYUEDABAN_DAIKAMOKU = 9
        KAISOCODE_DAIKAMOKU = 10
        DAIKAMOKUCODE = 11
        CYUKAMOKUCODE = 12
        SYOKAMOKUCODE = 13
        KAKERITU = 14
        IKATU_KAKERITU = 15
    End Enum

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

    Public Shared Function 登録済() As String
        Return "登録済"
    End Function

    Public Shared Function 下請未選択() As String
        Return "(下請未選択)"
    End Function

    Public Shared Function NumberFormat(ByVal strSURYO_SYOSUIKAKETA As String) As String
        Select Case strSURYO_SYOSUIKAKETA
            Case "0"
                Return "#,##0"
            Case "1"
                Return "#,##0.0"
            Case "2"
                Return "#,##0.00"
            Case "3"
                Return "#,##0.000"
            Case Else
                Return "#,##0.00"
        End Select
    End Function

    '発注コメントトラン保存用データセット
    'Mainフォームとコメント登録画面を行き来します
    Public DataSetCommentValue As dsHAT0001.コメント情報DataTable

    Private Const ROW_COUNT As Integer = 100                            '最大行数

    Private dbM_KBNValue As New dsM_KBN
    Private dbM_KBN_SIYOU06 As New dsM_KBN
    Private daMENT0002 As New daMENT0002
    Private T_BUKKEN_APPROVAL As New T_BUKKEN_APPROVALRead
    Private T_JYUTYU As New T_JYUTYURead
    Private T_HATYU As New T_HATYURead

    Private blnDbgKeyCtrlFlg As Boolean                                 'KeyDown()で判定、KeyPress()でTrueの場合キーを無効に
    Private strSyohiZeiritu As String

    Private dbS_SCBValue As dsS_SCB
    Private strS_SCB_ROUND_MITSUURYO As String
    Private strS_SCB_ROUND_GENTANKA As String
    Private strS_SCB_ROUND_GENKAKIN As String
    Private strS_SCB_ROUND_TAX As String

    Public requestBUK0001 As New requestBUK0001
    Public pubHatyuEdaban As String
    Public pubHatyuEdaban2 As String
    Public paramBoferHatyuFlg As Boolean

    Public Sub New()

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。

        requestBUK0001.BUKKEN_NO = 0
        pubHatyuEdaban = ""
        pubHatyuEdaban2 = ""
        paramBoferHatyuFlg = False
    End Sub
    Protected Overrides Sub Form_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        MyBase.Form_Load(sender, e)

        Dim strDate As Date = System.DateTime.Today

        '物件Noの設定
        txtHATYUNO.Text = ZeroPadding(requestBUK0001.BUKKEN_NO, txtHATYUNO.MaxLength)
        txtJYUTYUNO.Text = ZeroPadding(requestBUK0001.BUKKEN_NO, txtJYUTYUNO.MaxLength)

        '基本設定マスタの読み込み
        Call fncRead_S_SCB()

        '区分マスタ取得（単位）
        If fncRead_M_KBN("06") = False Then Exit Sub

        '区分マスタ取得（消費税）
        Dim logic As New M_KBNRead()
        strSyohiZeiritu = logic.fncSelect_SyohiZeiritu(strDate)

        Call InitDbGridMeisai()

        '画面の初期化
        txtHATYUEDABAN.Text = ""
        txtHATYUEDABAN2.Text = ""

        If NUCheck(pubHatyuEdaban) Then

            '画面の初期化
            Call InitDisp(True)

            'イベントの設定
            Call InitEvent()
        Else
            txtHATYUEDABAN.Text = pubHatyuEdaban
            txtHATYUEDABAN2.Text = pubHatyuEdaban2

            '画面の初期化
            Call InitDisp()

            'イベントの設定
            Call InitEvent()

            '発注枝番２のEnterイベントの実行
            Call ChangeHATYUEDABAN()
        End If

        txtHATYUEDABAN.Focus()
    End Sub

    Private Sub InitEvent()
        AddHandler txtHATYUDATE.Enter, AddressOf EnterEventHandler
        AddHandler txtKEISYOUCODE.Enter, AddressOf EnterEventHandler
        AddHandler txtKEISYOUNAME.Enter, AddressOf EnterEventHandler
        AddHandler txtSIHARAI_COMMENT_01.Enter, AddressOf EnterEventHandler
        AddHandler txtSIHARAI_COMMENT_02.Enter, AddressOf EnterEventHandler
        AddHandler txtSIHARAI_COMMENT_03.Enter, AddressOf EnterEventHandler
        AddHandler txtSIHARAI_COMMENT_04.Enter, AddressOf EnterEventHandler
        AddHandler txtSIHARAI_COMMENT_05.Enter, AddressOf EnterEventHandler
        AddHandler txtSIHARAI_COMMENT_06.Enter, AddressOf EnterEventHandler
        AddHandler txtAITE_MITUMORINO.Enter, AddressOf EnterEventHandler
        AddHandler txtKEIYAKUNO.Enter, AddressOf EnterEventHandler
        AddHandler txtNOUKI_START.Enter, AddressOf EnterEventHandler
        AddHandler txtNOUKI_END.Enter, AddressOf EnterEventHandler

        AddHandler dbgMeisai.Enter, AddressOf EventHandlerDbgMeisai
        AddHandler dbgMeisai.Leave, AddressOf dbgMEISAI_Leave
    End Sub

    Private Sub InitDisp(Optional ByVal keyClearFlg As Boolean = False)
        TitleBar.EditMode = EditMode.None

        'コンボボックスの初期化
        Call InitComboBox()

        If keyClearFlg Then
            txtHATYUEDABAN.Text = ""
            txtHATYUEDABAN2.Text = ""
            txtSIIRECODE.Text = ""
            txtSIIRENAME.Text = ""
        End If

        chkHATYUDATE.Checked = True
        txtHATYUDATE.Text = ServerDate.ToString("yyyy/MM/dd")
        txtKEISYOUCODE.Text = ""
        txtKEISYOUNAME.Text = ""
        txtSIHARAI_COMMENT_01.Text = ""
        txtSIHARAI_COMMENT_02.Text = ""
        txtSIHARAI_COMMENT_03.Text = ""
        txtSIHARAI_COMMENT_04.Text = ""
        txtSIHARAI_COMMENT_05.Text = ""
        txtSIHARAI_COMMENT_06.Text = ""
        txtAITE_MITUMORINO.Text = ""
        txtKEIYAKUNO.Text = ""
        txtNOUKI_START.Text = "____/__/__"
        txtNOUKI_END.Text = "____/__/__"
        lblGKGENKAGAKU_NUKI.Text = "0"
        lblGKTAX.Text = "0"
        lblGKGENKAGAKU.Text = "0"
        lblGKGENKAGAKU_NUKIBefore.Text = "0"
        lblTANTONAME.Text = ""
        lblKOUJINAME.Text = ""
        lblKOUJINO.Text = ""
        lblKOUJIBASYO.Text = ""
        lblSURYO_SYOSUIKAKETA.Text = ""

        '受注枝番の設定
        txtJYUTYUEDABAN.Text = ZeroPadding(T_JYUTYU.fncSelectMAX_JYUTYUEDABAN(txtJYUTYUNO.Text).Rows(0).Item("JYUTYUEDABAN"), txtJYUTYUEDABAN.MaxLength)

        '受注情報の表示
        Call DispJyutyuInfo()

        dbgMeisai.SetDataBinding(New dsHAT0001.明細情報DataTable, "", True)

        'コントール活性制御
        Call InitEnabledControl()

        'ファンクションキーの初期化
        Call InitFunctionKey()
    End Sub

    Private Sub InitFunctionKey()
        '使用機能権限クラスの定義
        Dim siyoKinouAuthority = New SiyoKinouAuthority(TANTO_CODE)

        FunctionKey.ClearAll()

        Select Case TitleBar.EditMode
            Case EditMode.None
                FunctionKey.SetItem(1, "終了", "終了", True)

            Case EditMode.Create
                FunctionKey.SetItem(1, "取消", "取消", True)
                FunctionKey.SetItem(5, "科目品目", "科目/品目", False, FunctionKey.FONT_SMALL)
                FunctionKey.SetItem(6, "行削除", "行削除", False)
                FunctionKey.SetItem(8, "コメント", "コメント", True, FunctionKey.FONT_SMALL)
                FunctionKey.SetItem(12, "登録", "登録", True)

                If Not NUCheck(txtHATYUEDABAN2.Text) AndAlso CDec(txtHATYUEDABAN2.Text) <> 0 Then
                    FunctionKey.SetItem(10, "前回発注", "前回発注", True, FunctionKey.FONT_SMALL)
                End If

            Case EditMode.Edit
                FunctionKey.SetItem(1, "取消", "取消", True)
                FunctionKey.SetItem(3, "削除", "削除", True)
                FunctionKey.SetItem(5, "科目品目", "科目/品目", False, FunctionKey.FONT_SMALL)
                FunctionKey.SetItem(6, "行削除", "行削除", False)
                FunctionKey.SetItem(8, "コメント", "コメント", True, FunctionKey.FONT_SMALL)
                FunctionKey.SetItem(12, "登録", "登録", True)

                If siyoKinouAuthority.CheckUseKinou(SiyoKinouAuthority.CONST_発注承認) Then
                    FunctionKey.SetItem(4, "承認", "承認", True)
                End If

                If CDec(txtHATYUEDABAN2.Text) <> 0 Then
                    FunctionKey.SetItem(10, "前回発注", "前回発注", True, FunctionKey.FONT_SMALL)
                End If

            Case EditMode.EditNoneJyutyuMisyonin
                FunctionKey.SetItem(1, "取消", "取消", True)

                If CDec(txtHATYUEDABAN2.Text) <> 0 Then
                    FunctionKey.SetItem(10, "前回発注", "前回発注", True, FunctionKey.FONT_SMALL)
                End If

            Case EditMode.EditNoneHatyuZenaki
                FunctionKey.SetItem(1, "終了", "終了", True)

                If CDec(txtHATYUEDABAN2.Text) <> 0 Then
                    FunctionKey.SetItem(10, "前回発注", "前回発注", True, FunctionKey.FONT_SMALL)
                End If

            Case EditMode.EditNone
                FunctionKey.SetItem(1, "取消", "取消", True)
                FunctionKey.SetItem(12, "印刷", "印刷", True)

                If CDec(txtHATYUEDABAN2.Text) <> 0 Then
                    FunctionKey.SetItem(10, "前回発注", "前回発注", True, FunctionKey.FONT_SMALL)
                End If

                Dim dt = T_HATYU.fncSelectMaxHattyuEdaban2(txtHATYUNO.Text, txtHATYUEDABAN.Text)
                Dim edaban2 = CDec(dt.Rows(0).Item("HATYUEDABAN2"))
                If CDec(txtHATYUEDABAN2.Text) = edaban2 Then
                    '発注No、発注枝番の内、発注枝番２がMAXの場合
                    If siyoKinouAuthority.CheckUseKinou(SiyoKinouAuthority.CONST_発注承認) Then
                        FunctionKey.SetItem(4, "承認解除", "承認解除", True, FunctionKey.FONT_SMALL)
                    End If

                    FunctionKey.SetItem(11, "発注変更", "発注変更", True, FunctionKey.FONT_SMALL)
                End If
        End Select
    End Sub

    Private Sub InitEnabledControl()
        Dim enabledHattyuNo = False
        Dim enabledInputColumn = False
        Dim enabledHattyuDateInji = False

        Select Case TitleBar.EditMode
            Case EditMode.None
                enabledHattyuNo = True

            Case EditMode.Create
                enabledInputColumn = True

            Case EditMode.Edit
                enabledInputColumn = True

            Case EditMode.EditNone
                enabledHattyuDateInji = True
        End Select

        txtHATYUEDABAN.Enabled = enabledHattyuNo
        txtHATYUEDABAN2.Enabled = enabledHattyuNo
        cmbHATTYUNO.Enabled = enabledHattyuNo

        txtSIIRECODE.Enabled = enabledHattyuNo

        txtHATYUDATE.Enabled = enabledInputColumn
        txtAITE_MITUMORINO.Enabled = enabledInputColumn
        txtKEIYAKUNO.Enabled = enabledInputColumn
        txtKEISYOUCODE.Enabled = enabledInputColumn
        txtNOUKI_START.Enabled = enabledInputColumn
        txtNOUKI_END.Enabled = enabledInputColumn
        txtSIHARAI_COMMENT_01.Enabled = enabledInputColumn
        txtSIHARAI_COMMENT_02.Enabled = enabledInputColumn
        txtSIHARAI_COMMENT_03.Enabled = enabledInputColumn
        txtSIHARAI_COMMENT_04.Enabled = enabledInputColumn
        txtSIHARAI_COMMENT_05.Enabled = enabledInputColumn
        txtSIHARAI_COMMENT_06.Enabled = enabledInputColumn

        chkHATYUDATE.Enabled = enabledHattyuDateInji

        If TitleBar.EditMode = EditMode.Create OrElse TitleBar.EditMode = EditMode.Edit Then
            dbgMeisai.AllowAddNew = True
            dbgMeisai.AllowUpdate = True
        Else
            dbgMeisai.AllowAddNew = False
            dbgMeisai.AllowUpdate = False
        End If
    End Sub

    Private Sub InitComboBox()
        Dim logic As New BLL.Common.TypComboBox
        Dim recieveParam As Model.DTO.ResponseGetComboBoxContents

        Dim paramlist As New List(Of Model.DTO.RequestGetComboBoxContentsElement)
        paramlist.Add(New Model.DTO.RequestGetComboBoxContentsElement(Model.ComboBoxTableName.M_KBN, Model.DTO.GetComboBoxContentsResultFieldType.MultipleField, False, "04"))
        paramlist.Add(New Model.DTO.RequestGetComboBoxContentsElement(Model.ComboBoxTableName.M_SIIRE, Model.DTO.GetComboBoxContentsResultFieldType.MultipleField, False, Nothing))
        paramlist.Add(New Model.DTO.RequestGetComboBoxContentsElement(Model.ComboBoxTableName.T_HATYUHED_HATYUNO, Model.DTO.GetComboBoxContentsResultFieldType.MultipleField, False, txtHATYUNO.Text))

        Dim requestParam As New Model.DTO.RequestGetComboBoxContents(paramlist)

        recieveParam = logic.CreateComboBox(requestParam)

        txtKEISYOUCODE.AttachDataSource(Model.ComboBoxTableName.M_KBN, recieveParam)
        txtSIIRECODE.AttachDataSource(Model.ComboBoxTableName.M_SIIRE, recieveParam)
        cmbHATTYUNO.AttachDataSource(Model.ComboBoxTableName.T_HATYUHED_HATYUNO, recieveParam)
    End Sub

    Protected Overrides Sub FunctionKeyAction(ByVal sender As System.Object, ByVal e As FunctionKeyEventArgs)

        Select Case e.Name
            Case "終了"
                If TitleBar.EditMode <> EditMode.EditNoneHatyuZenaki Then
                    '呼び出し元の再表示
                    CType(ownerForm, frmBUK0001).ShowReDisp()
                End If

                Me.Close()

            Case "取消"
                If MessageBoxEx.Show(CommonUtility.MessageCode_Arg0.M003取消してもよろしいですか, PROGRAM_NAME) = Windows.Forms.DialogResult.No Then Return

                '画面の初期化
                Call InitDisp(True)

                txtHATYUEDABAN.Focus()

            Case "削除"
                Call ExecDelete()

            Case "承認", "承認解除"
                Dim messageCode As Integer
                Dim approvalKbn As Integer

                If e.Name = "承認" Then
                    '受注の承認区分の取得
                    Dim approvalKbnJyutyu = CType(T_BUKKEN_APPROVAL.GetDataWhereGyomuKbn(
                              txtHATYUNO.Text _
                            , T_BUKKEN_APPROVALRead.enumGyomuKbn.Jyuchu
                            ).Rows(0), dsT_BUKKEN_APPROVAL.T_BUKKEN_APPROVALRow).APPROVALKBN

                    '受注未承認の場合、エラー
                    If approvalKbnJyutyu = T_BUKKEN_APPROVALRead.enumApprovalKbn.SYONIN_MI Then
                        MessageBoxEx.Show(CommonUtility.MessageCode_Arg0.M242, PROGRAM_NAME)
                        Return
                    End If

                    messageCode = CommonUtility.MessageCode_Arg0.M155承認してもよろしいですか
                    approvalKbn = T_BUKKEN_APPROVALRead.enumApprovalKbn.SYONIN_ZUMI

                Else
                    messageCode = CommonUtility.MessageCode_Arg0.M156解除してもよろしいですか
                    approvalKbn = T_BUKKEN_APPROVALRead.enumApprovalKbn.SYONIN_MI
                End If

                If MessageBoxEx.Show(messageCode, PROGRAM_NAME) = Windows.Forms.DialogResult.No Then Return

                T_BUKKEN_APPROVAL.UpdateSyoninKbn(txtHATYUNO.Text, T_BUKKEN_APPROVALRead.enumGyomuKbn.Hacchu, txtHATYUEDABAN.Text, approvalKbn)

                '画面の再表示
                Call ChangeHATYUEDABAN()

                txtHATYUEDABAN.Focus()

            Case "科目品目"
                Call ClickKamokuHinmokuButton()

            Case "行削除"
                Call DbgMeisaiRowDelete()

            Case "コメント"
                Call PopUpComment()

            Case "検索"
                Call PopUpSearchMenu()

            Case "前回発注"
                Dim f = New frmHAT0001()
                f.requestBUK0001.BUKKEN_NO = txtHATYUNO.Text
                f.pubHatyuEdaban = txtHATYUEDABAN.Text
                f.pubHatyuEdaban2 = ZeroFormat(CStr(CDec(txtHATYUEDABAN2.Text) - 1), txtHATYUEDABAN2.MaxLength)
                f.paramBoferHatyuFlg = True
                f.ShowDisp(Me)

            Case "発注変更"
                Call ExecHatyuHenko()

            Case "登録"
                Call ExecRegist()

            Case "印刷"
                Call ExecPrint()

        End Select
    End Sub

    Private Sub ExecHatyuHenko()
        '最大の受注枝番の取得
        Dim jyutyuEdaban = T_JYUTYU.fncSelectMAX_JYUTYUEDABAN(txtHATYUNO.Text).Rows(0).Item("JYUTYUEDABAN")

        '受注の承認の状態を取得
        Dim jyutyuApprovalKbn = CType(
            T_BUKKEN_APPROVAL.GetDataWhereGyomuKbn(txtHATYUNO.Text, T_BUKKEN_APPROVALRead.enumGyomuKbn.Jyuchu).Rows(0) _
            , dsT_BUKKEN_APPROVAL.T_BUKKEN_APPROVALRow
            ).APPROVALKBN

        '受注が未承認の場合、エラー
        If jyutyuApprovalKbn = T_BUKKEN_APPROVALRead.enumApprovalKbn.SYONIN_MI Then
            MessageBoxEx.Show(CommonUtility.MessageCode_Arg1.M238, txtHATYUNO.Text + "-" + ZeroPadding(jyutyuEdaban, 2), PROGRAM_NAME)
            Return
        End If

        '確認メッセージ
        If MessageBoxEx.Show(MessageCode_Arg1.M230, "発注変更", PROGRAM_NAME) = Windows.Forms.DialogResult.No Then Exit Sub

        TitleBar.EditMode = EditMode.Create

        'コントール活性制御
        Call InitEnabledControl()

        '発注情報の表示
        DispHatyuInfo()

        '発注枝番２をカウントアップ
        txtHATYUEDABAN2.Text = ZeroPadding(CDec(txtHATYUEDABAN2.Text) + 1, txtHATYUEDABAN2.MaxLength)

        txtJYUTYUEDABAN.Text = ZeroPadding(jyutyuEdaban, txtJYUTYUEDABAN.MaxLength)

        '発注日付
        txtHATYUDATE.Text = ServerDate.ToString("yyyy/MM/dd")

        'ファンクションキーの初期化
        Call InitFunctionKey()

        '受注情報の表示
        Call DispJyutyuInfo()

        '受注明細情報の表示
        Call DispJyutyuMeisaiInfo()

        txtHATYUDATE.Focus()
    End Sub

    Private Sub ExecDelete()
        Dim writingDataSet As New dsHAT0001_Update

        If MessageBoxEx.Show(CommonUtility.MessageCode_Arg0.M002削除してもよろしいですか, PROGRAM_NAME) = Windows.Forms.DialogResult.No Then Return

        Call Set受注ヘッダートラン削除データ(writingDataSet)

        Dim logic As New HAT0001DataAccess.Update(PROGRAM_ID, TANTO_CODE, writingDataSet)

        logic.削除(txtHATYUNO.Text, txtHATYUEDABAN.Text, txtHATYUEDABAN2.Text)

        '画面の初期化
        txtHATYUEDABAN.Text = ""
        txtHATYUEDABAN2.Text = ""

        Call InitDisp()

        txtHATYUEDABAN.Focus()
    End Sub

    Private Sub ExecRegist()
        Dim writingDataSet As New dsHAT0001_Update

        If AllInputValidate() = False Then Return

        '発注ヘッダートランに既にPKの情報が登録されている場合、エラー
        '　※発注変更ボタン押下後に発注枝番が確定し、登録ボタン押下までに複数ユーザが同一操作した時に重複エラーになる考慮
        If TitleBar.EditMode = EditMode.Create AndAlso Not NUCheck(txtHATYUEDABAN.Text) Then
            Dim dtHATYU = T_HATYU.fncSelectT_HATYUHED_PK(txtHATYUNO.Text, txtHATYUEDABAN.Text, txtHATYUEDABAN2.Text)
            If dtHATYU.Rows.Count <> 0 Then
                MessageBoxEx.Show(CommonUtility.MessageCode_Arg1.M241, "発注No", PROGRAM_NAME)
                Return
            End If
        End If

        If MessageBoxEx.Show(CommonUtility.MessageCode_Arg0.M001登録してもよろしいですか, PROGRAM_NAME) = Windows.Forms.DialogResult.No Then Return

        'DBGridの確定
        If dbgMeisai.DataChanged Then dbgMeisai.UpdateData()

        '発注枝番の採番
        If NUCheck(txtHATYUEDABAN.Text) Then
            Dim dt = T_HATYU.fncSelectMaxHattyuEdaban(txtHATYUNO.Text)
            If dt.Rows.Count = 0 OrElse NUCheck(dt.Rows(0).Item("HATYUEDABAN")) Then
                txtHATYUEDABAN.Text = ZeroPadding(0, txtHATYUEDABAN.MaxLength)
            Else
                txtHATYUEDABAN.Text = ZeroPadding(CStr(CDec(dt.Rows(0).Item("HATYUEDABAN")) + 1), txtHATYUEDABAN.MaxLength)
            End If
        End If

        '発注枝番２の採番
        If NUCheck(txtHATYUEDABAN2.Text) Then
            txtHATYUEDABAN2.Text = ZeroPadding(0, txtHATYUEDABAN.MaxLength)
        End If

        Call Set発注ヘッダートラン(writingDataSet)

        Call Set発注トラン(writingDataSet)

        Call Set発注コメントトラン(writingDataSet)

        Call Set受注ヘッダートラン(writingDataSet)

        Dim 処理区分 As HAT0001DataAccess.Update.enum処理区分
        If TitleBar.EditMode = EditMode.Create Then
            処理区分 = HAT0001DataAccess.Update.enum処理区分.新規
        Else
            処理区分 = HAT0001DataAccess.Update.enum処理区分.編集
        End If

        '更新処理
        Dim logic As New HAT0001DataAccess.Update(PROGRAM_ID, TANTO_CODE, writingDataSet, 処理区分)
        logic.登録()

        '画面の初期化
        Call InitDisp()

        txtHATYUEDABAN.Focus()
    End Sub

    Private Sub Set発注ヘッダートラン(ByRef writingDataSet As dsHAT0001_Update)

        Dim row As dsHAT0001_Update.T_HATYUHEDRow = writingDataSet.T_HATYUHED.NewT_HATYUHEDRow

        With row
            .HATYUNO = txtHATYUNO.Text
            .HATYUEDABAN = txtHATYUEDABAN.Text
            .HATYUEDABAN2 = txtHATYUEDABAN2.Text
            .JYUTYUEDABAN = txtJYUTYUEDABAN.Text
            .HATYUDATE = CType(txtHATYUDATE.Text, Date)
            .JYUTYUNO = CType(txtHATYUNO.Text, Decimal)
            .SIIRECODE = txtSIIRECODE.Text
            .TANTOCODE = ""
            .INP_TANTOCODE = ""
            .KEISYOUCODE = txtKEISYOUCODE.Text
            .SIHARAI_COMMENT_01 = txtSIHARAI_COMMENT_01.Text
            .SIHARAI_COMMENT_02 = txtSIHARAI_COMMENT_02.Text
            .SIHARAI_COMMENT_03 = txtSIHARAI_COMMENT_03.Text
            .SIHARAI_COMMENT_04 = txtSIHARAI_COMMENT_04.Text
            .SIHARAI_COMMENT_05 = txtSIHARAI_COMMENT_05.Text
            .SIHARAI_COMMENT_06 = txtSIHARAI_COMMENT_06.Text
            .AITE_MITUMORINO = txtAITE_MITUMORINO.Text
            .KEIYAKUNO = txtKEIYAKUNO.Text
            .NOUKI_START = ""
            If IsDate(txtNOUKI_START.Text) Then
                .NOUKI_START = txtNOUKI_START.Text
            End If
            .NOUKI_END = ""
            If IsDate(txtNOUKI_END.Text) Then
                .NOUKI_END = txtNOUKI_END.Text
            End If
            .AITEDENPYONO = "" '規定値
            .GKGENKAGAKU_NUKI = CType(lblGKGENKAGAKU_NUKI.Text, Decimal)
            .GKTAX = CType(lblGKTAX.Text, Decimal)
            .GKGENKAGAKU = CType(lblGKGENKAGAKU.Text, Decimal)
            .D_BIKO = ""    '規定値
            .SYORIKBN = 0

        End With

        writingDataSet.T_HATYUHED.Rows.Add(row)
    End Sub

    Private Sub Set発注トラン(ByRef writingDataSet As dsHAT0001_Update)
        Dim hatyuCommentLogic As New HAT0001DataAccess.Read
        Dim kaisoCode As String = ""
        Dim kaisoCodeNumbering As String = ""
        Dim kaisoCodeDaikamoku As String = ""

        For Each MeisaiRow As dsHAT0001.明細情報Row In CType(dbgMeisai.DataSource, dsHAT0001.明細情報DataTable)

            If MeisaiRow.RowState = DataRowState.Deleted Then Continue For

            '階層コードの発番
            If Not NUCheck(MeisaiRow.KAISOCODE) Then
                '受注情報の場合
                kaisoCode = MeisaiRow.KAISOCODE
                kaisoCodeDaikamoku = MeisaiRow.KAISOCODE_DAIKAMOKU

            Else
                '新規行の場合
                If kaisoCodeNumbering = "" Then
                    If NUCheck(txtHATYUEDABAN.Text) Then
                        kaisoCodeNumbering = "9" + New String("0"c, 29)
                    Else
                        kaisoCodeNumbering = hatyuCommentLogic.GetMaxKaisoCodeNewRow(txtHATYUNO.Text, txtHATYUEDABAN.Text)
                    End If
                End If
                'カウントアップ処理
                kaisoCodeNumbering = "9" & ZeroFormat((CDec(kaisoCodeNumbering.Substring(1, 29)) + 1).ToString, 29)
                kaisoCode = kaisoCodeNumbering

                kaisoCodeDaikamoku = 999
            End If

            Dim row As dsHAT0001_Update.T_HATYURow = writingDataSet.T_HATYU.NewT_HATYURow

            row.HATYUNO = txtHATYUNO.Text
            row.HATYUEDABAN = txtHATYUEDABAN.Text
            row.HATYUEDABAN2 = txtHATYUEDABAN2.Text
            row.JYUTYUEDABAN = MeisaiRow.JYUTYUEDABAN
            row.KAISOCODE = kaisoCode
            row.JYUTYUEDABAN_DAIKAMOKU = MeisaiRow.JYUTYUEDABAN_DAIKAMOKU
            row.KAISOCODE_DAIKAMOKU = kaisoCodeDaikamoku
            row.HATYUDATE = CType(txtHATYUDATE.Text, Date)
            row.JYUTYUNO = CType(txtHATYUNO.Text, Decimal)
            row.DAIKAMOKUCODE = MeisaiRow.DAIKAMOKUCODE
            row.CYUKAMOKUCODE = MeisaiRow.CYUKAMOKUCODE
            row.SYOKAMOKUCODE = MeisaiRow.SYOKAMOKUCODE
            row.KAMOKU_HINMOKU = MeisaiRow.KAMOKU_HINMOKU
            row.HINSITU_KIKAKU_SIYO = MeisaiRow.HINSITU_KIKAKU_SIYO
            row.TANI = MeisaiRow.TANI
            row.SUU = MeisaiRow.SUU
            row.KAKERITU = MeisaiRow.KAKERITU
            row.GENTANKA = MeisaiRow.GENTANKA
            row.GENKAGAKU = MeisaiRow.GENKAGAKU
            row.IKATU_KAKERITU = MeisaiRow.IKATU_KAKERITU
            row.G_BIKO = MeisaiRow.G_BIKO

            writingDataSet.T_HATYU.Rows.Add(row)
        Next
    End Sub

    Private Sub Set発注コメントトラン(ByRef writingDataSet As dsHAT0001_Update)
        For Each MeisaiRow As dsHAT0001.コメント情報Row In DataSetCommentValue
            Dim row As dsHAT0001_Update.T_HATYU_COMMENTRow = writingDataSet.T_HATYU_COMMENT.NewT_HATYU_COMMENTRow

            row.HATYUNO = txtHATYUNO.Text
            row.HATYUEDABAN = txtHATYUEDABAN.Text
            row.HATYUEDABAN2 = txtHATYUEDABAN2.Text
            row.CATEGORYID = MeisaiRow.CATEGORYID
            row.DATAKEY = MeisaiRow.DATAKEY
            row.DATA = MeisaiRow.DATA

            writingDataSet.T_HATYU_COMMENT.Rows.Add(row)
        Next
    End Sub

    Private Sub Set受注ヘッダートラン(ByRef writingDataSet As dsHAT0001_Update)
        Dim row As dsHAT0001_Update.T_JYUTYUHEDRow = writingDataSet.T_JYUTYUHED.NewT_JYUTYUHEDRow

        With row
            .JYUTYUNO = CType(txtHATYUNO.Text, Decimal)
            .LAST_HATYUDATE = CType(txtHATYUDATE.Text, Date)
            If NUCheck(txtHATYUEDABAN.Text) Then
                .SUMI_HATYUGAKU = CType(lblGKGENKAGAKU_NUKI.Text, Decimal)
            Else
                .SUMI_HATYUGAKU = CType(lblGKGENKAGAKU_NUKI.Text, Decimal) - CType(lblGKGENKAGAKU_NUKIBefore.Text, Decimal)
            End If

        End With

        writingDataSet.T_JYUTYUHED.Rows.Add(row)
    End Sub

    Private Sub Set受注ヘッダートラン削除データ(ByRef writingDataSet As dsHAT0001_Update)
        Dim row As dsHAT0001_Update.T_JYUTYUHEDRow = writingDataSet.T_JYUTYUHED.NewT_JYUTYUHEDRow

        With row
            .JYUTYUNO = CType(txtHATYUNO.Text, Decimal)
            .SUMI_HATYUGAKU = CType(lblGKGENKAGAKU_NUKIBefore.Text, Decimal)
        End With

        writingDataSet.T_JYUTYUHED.Rows.Add(row)
    End Sub

    Private Sub ClickKamokuHinmokuButton()
        Dim row = dbgMeisai.Row

        Dim mode As frmMENT0002.enumDispMode
        If dbgMeisai.RowCount <= dbgMeisai.Row Then
            mode = frmMENT0002.enumDispMode.SELECT_KAMOKU_HINMOKU_MULTI
        Else
            mode = frmMENT0002.enumDispMode.SELECT_KAMOKU_HINMOKU
        End If

        ''*** 検索画面表示 ***
        Using f As New frmMENT0002(mode, frmMENT0002.enumKamokuType.SEARCH, "")
            f.Owner = Me
            f.ShowDialog()

            If f.outKamokuCode.Count = 0 Then Return

            '戻り値の処理
            For idx = 0 To f.outKamokuCode.Count - 1

                If idx <> 0 Then
                    dbgMeisai.Row = dbgMeisai.Row + 1
                End If

                Dim outKamokuCode = f.outKamokuCode(idx)
                Dim outKamokuType = f.outKamokuType(idx)

                '科目のデータの取得
                Dim dr = CType(daMENT0002.GetMeisai(outKamokuType, outKamokuCode, "", "").Rows(0), dsMENT0002.M_KAMOKURow)

                'データのセット
                Dim col As Integer
                If outKamokuType = frmMENT0002.enumKamokuType.DKAMOKU Then
                    col = COLMeisai.DAIKAMOKUCODE
                ElseIf outKamokuType = frmMENT0002.enumKamokuType.CKAMOKU Then
                    col = COLMeisai.CYUKAMOKUCODE
                Else
                    col = COLMeisai.SYOKAMOKUCODE
                End If

                dbgMeisai.Columns(col).Value = outKamokuCode
                dbgMeisai.Columns(COLMeisai.KAMOKU_HINMOKU).Value = dr.NAME
                dbgMeisai.Columns(COLMeisai.HINSITU_KIKAKU_SIYO).Value = dr.NAME2
                dbgMeisai.Columns(COLMeisai.TANI).Value = dr.TANI
                dbgMeisai.Columns(COLMeisai.GENTANKA).Value = dr.GENTANKA
            Next

            '金額の計算
            subDbgCalcKingaku()

            '合計計算
            subDbgSumMeisai()

            'フォーカス移動
            dbgMeisai.Focus()
            dbgMeisai.Col = COLMeisai.HINSITU_KIKAKU_SIYO
        End Using

        dbgMeisai.Row = row
    End Sub

    ''' <summary>
    ''' 行削除ボタン押下
    ''' </summary>
    Private Sub DbgMeisaiRowDelete()

        '新規の行の場合
        If dbgMeisai.Row = dbgMeisai.RowCount Then Exit Sub

        Try
            RemoveHandler dbgMeisai.Leave, AddressOf dbgMEISAI_Leave

            dbgMeisai.Delete()

            '合計計算
            subDbgSumMeisai()

        Finally
            AddHandler dbgMeisai.Leave, AddressOf dbgMEISAI_Leave
        End Try

        dbgMeisai.Refresh()
    End Sub

    Private Sub ExecPrint()
        If MessageBoxEx.Show(CommonUtility.MessageCode_Arg0.M005印刷してもよろしいですか, PROGRAM_NAME) = Windows.Forms.DialogResult.No Then Return

        Dim report As New HAT0001DataAccess.Report(PCNAME, txtHATYUNO.Text, txtHATYUEDABAN.Text, txtHATYUEDABAN2.Text)
        Dim ReportDataSets As dsHAT0001_Report = report.GetList(txtZeiKbn.Text)

        '受注ヘッダートラン．数量小数点以下桁数より数量のフォーマットを指定
        Dim OutputFormat As String = NumberFormat(lblSURYO_SYOSUIKAKETA.Text)

        Dim hattyuNo = ZeroPadding(txtHATYUNO.Text, txtHATYUNO.MaxLength) + "-" + ZeroPadding(txtHATYUEDABAN.Text, txtHATYUEDABAN.MaxLength)
        Dim utiwakePrintFlg = IIf(ReportDataSets.内訳明細.Rows.Count > 0, True, False)

        Using rpt As New rptHAT0001(ReportDataSets, OutputFormat, chkHATYUDATE.Checked, hattyuNo, utiwakePrintFlg),
                rptUke As New rptHAT0001Uke(ReportDataSets, OutputFormat, hattyuNo, utiwakePrintFlg)

            If Not utiwakePrintFlg Then
                PrintReport(PrintReportMode.Preview, {rpt, rptUke})

            Else
                '内訳
                Using rptUchiwake As New rptHAT0001Uchiwake(ReportDataSets, OutputFormat, chkHATYUDATE.Checked, hattyuNo)
                    PrintReport(PrintReportMode.Preview, {rpt, rptUke, rptUchiwake})
                End Using
            End If
        End Using
    End Sub

    Private Sub PopUpComment()
        Dim f As New frmHAT0001_COMMENT(DataSetCommentValue)
        f.Owner = Me
        f.ShowDispDialog(Me)
    End Sub

    '各種検索画面起動
    Private Sub PopUpSearchMenu()
        Using f As New WinFormBase.SEARCH_SIIRE(0)
            f.Owner = Me

            If f.ShowDialog <> Windows.Forms.DialogResult.OK Then
                Me.Visible = True
                Return
            End If
            Me.Visible = True

            If f.SelectItem Is Nothing Then Return

            txtSIIRECODE.Text = f.SelectItem.Code

            '下請変更処理
            ChangeSIIRECODE()
        End Using
    End Sub

    Private Sub txtHATYUEDABAN2_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtHATYUEDABAN2.KeyDown

        'エンターキー以外は処理しない
        If e.KeyCode <> Keys.Enter Then Return

        ChangeHATYUEDABAN()
    End Sub

    Private Sub cmbHATTYUNO_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbHATTYUNO.SelectionChangeCommitted
        If Not NUCheck(lblHATYUNO.Text) Then
            txtHATYUEDABAN.Text = lblHATYUNO.Text.Substring(11, 2)
            txtHATYUEDABAN2.Text = lblHATYUNO.Text.Substring(14, 2)
        Else
            txtHATYUEDABAN.Text = vbNullString
            txtHATYUEDABAN2.Text = vbNullString
        End If

        '発注枝番２のEnterイベントの実行
        Call ChangeHATYUEDABAN()
    End Sub

    Private Sub ChangeHATYUEDABAN()
        '空白の場合、エラー
        If NUCheck(txtHATYUEDABAN.Text) AndAlso NUCheck(txtHATYUEDABAN2.Text) Then
            MessageBoxEx.Show(CommonUtility.MessageCode_Arg0.M240, PROGRAM_NAME)
            txtHATYUEDABAN.Focus()
            Return
        End If

        '片方だけ入力している場合、エラー
        If NUCheck(txtHATYUEDABAN.Text) OrElse NUCheck(txtHATYUEDABAN2.Text) Then
            MessageBoxEx.Show(CommonUtility.MessageCode_Arg1.M239, "発注No", PROGRAM_NAME)
            txtHATYUEDABAN.Focus()
            Return
        End If

        '発注情報の取得
        Dim dtHATYU = T_HATYU.fncSelectT_HATYUHED_PK(txtHATYUNO.Text, txtHATYUEDABAN.Text, txtHATYUEDABAN2.Text)

        If dtHATYU.Rows.Count = 0 Then
            MessageBoxEx.Show(CommonUtility.MessageCode_Arg0.M009該当データがありません, Me.Text)
            txtHATYUEDABAN.Focus()
            Return
        End If

        '発注情報の表示
        DispHatyuInfo()

        '発注明細情報の表示
        Dim read As New HAT0001DataAccess.Read
        Dim responseParams As dsHAT0001 = read.Read発注明細情報取得(txtHATYUNO.Text, txtHATYUEDABAN.Text, txtHATYUEDABAN2.Text)

        dbgMeisai.SetDataBinding(responseParams.明細情報, "", True) '明細情報

        '合計計算
        subDbgSumMeisai()

        lblGKGENKAGAKU_NUKIBefore.Text = lblGKGENKAGAKU_NUKI.Text

        '受注情報の表示
        Call DispJyutyuInfo()

        '受注の承認区分の取得
        Dim approvalKbnJyutyu = CType(T_BUKKEN_APPROVAL.GetDataWhereGyomuKbn(
                  txtHATYUNO.Text _
                , T_BUKKEN_APPROVALRead.enumGyomuKbn.Jyuchu
                ).Rows(0), dsT_BUKKEN_APPROVAL.T_BUKKEN_APPROVALRow).APPROVALKBN

        '発注の承認区分の取得
        Dim approvalKbnHatyu = CType(T_BUKKEN_APPROVAL.GetDataWherePK(
                  txtHATYUNO.Text _
                , T_BUKKEN_APPROVALRead.enumGyomuKbn.Hacchu _
                , txtHATYUEDABAN.Text
                ).Rows(0), dsT_BUKKEN_APPROVAL.T_BUKKEN_APPROVALRow).APPROVALKBN

        '最大の発注Noの取得
        Dim hatyuEdaban = CDec(T_HATYU.fncSelectMaxHattyuEdaban2(txtHATYUNO.Text, txtHATYUEDABAN.Text).Rows(0).Item("HATYUEDABAN2"))

        'モードの設定
        If paramBoferHatyuFlg Then
            '前回発注の場合
            TitleBar.EditMode = EditMode.EditNoneHatyuZenaki

        ElseIf approvalKbnHatyu = T_BUKKEN_APPROVALRead.enumApprovalKbn.SYONIN_ZUMI OrElse CDec(txtHATYUEDABAN2.Text) <> hatyuEdaban Then
            '発注承認済、または、最大の発注枝番２以外の場合
            TitleBar.EditMode = EditMode.EditNone

        Else
            '上記以外の場合
            TitleBar.EditMode = EditMode.Edit
        End If

        'コントール活性制御
        Call InitEnabledControl()

        'ファンクションキーの初期化
        Call InitFunctionKey()

        'コメント情報の取得
        Dim hatyuCommentLogic As New HAT0001DataAccess.Read(txtHATYUNO.Text, txtHATYUEDABAN.Text, txtHATYUEDABAN2.Text)
        DataSetCommentValue = hatyuCommentLogic.Readコメント情報取得.コメント情報

        If TitleBar.EditMode = EditMode.EditNone Then
            chkHATYUDATE.Focus()
        Else
            txtHATYUDATE.Focus()
        End If
    End Sub

    Private Sub DispHatyuInfo()
        '発注情報の取得
        Dim drHATYU = CType(T_HATYU.fncSelectT_HATYUHED_PK(txtHATYUNO.Text, txtHATYUEDABAN.Text, txtHATYUEDABAN2.Text).Rows(0), dsT_HATYU.T_HATYUHEDRow)

        txtHATYUDATE.Text = drHATYU.HATYUDATE
        lblHATYUDATE.Text = fncCnvJapaneseDate(txtHATYUDATE.Text)
        txtSIIRECODE.Text = drHATYU.SIIRECODE
        txtSIHARAI_COMMENT_01.Text = drHATYU.SIHARAI_COMMENT_01
        txtSIHARAI_COMMENT_02.Text = drHATYU.SIHARAI_COMMENT_02
        txtSIHARAI_COMMENT_03.Text = drHATYU.SIHARAI_COMMENT_03
        txtSIHARAI_COMMENT_04.Text = drHATYU.SIHARAI_COMMENT_04
        txtSIHARAI_COMMENT_05.Text = drHATYU.SIHARAI_COMMENT_05
        txtSIHARAI_COMMENT_06.Text = drHATYU.SIHARAI_COMMENT_06
        txtKEISYOUCODE.Text = drHATYU.KEISYOUCODE
        txtAITE_MITUMORINO.Text = drHATYU.AITE_MITUMORINO
        txtNOUKI_START.Text = drHATYU.NOUKI_START
        txtNOUKI_END.Text = drHATYU.NOUKI_END
        txtKEIYAKUNO.Text = drHATYU.KEIYAKUNO
        txtJYUTYUEDABAN.Text = ZeroPadding(drHATYU.JYUTYUEDABAN, txtJYUTYUEDABAN.MaxLength)

        '仕入マスタ情報の取得
        Dim logic As New M_SIIRERead(txtSIIRECODE.Text)
        Dim ds = logic.GetM_SIIRE
        Dim dr = DirectCast(ds.Tables(0).Rows(0), dsM_SIIRE.M_SIIRERow)

        txtZeiKbn.Text = dr.ZEIKBN.ToString
        Select Case txtZeiKbn.Text
            Case "0"
                lblTAX.Text = "消費税："
                lblTAX.Visible = True
                lblGKTAX.Visible = True
                lblGKGENKA.Visible = True
                lblGKGENKAGAKU.Visible = True
            Case "1"
                lblTAX.Text = "内消費税："
                lblTAX.Visible = True
                lblGKTAX.Visible = True
                lblGKGENKA.Visible = False
                lblGKGENKAGAKU.Visible = False
            Case Else
                lblTAX.Visible = False
                lblGKTAX.Visible = False
                lblGKGENKA.Visible = False
                lblGKGENKAGAKU.Visible = False
        End Select
    End Sub

    Private Sub txtSIIRECODE_PressEnter(ByVal sender As Object, ByVal e As EventArgs) Handles txtSIIRECODE.PressEnter
        ChangeSIIRECODE()
    End Sub

    Private Sub txtSIIRECODE_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles txtSIIRECODE.SelectionChangeCommitted
        ChangeSIIRECODE()
    End Sub

    Private Sub ChangeSIIRECODE()

        '空白の場合、エラー
        If NUCheck(txtSIIRECODE.Text) Then
            MessageBoxEx.Show(CommonUtility.MessageCode_Arg1.M015は必ず入力して下さい, "下請コード", PROGRAM_NAME)
            txtSIIRECODE.Focus()
            Return
        End If

        'コンボボックスのデータ無の場合、エラー
        Dim row = DirectCast(txtSIIRECODE.DataSource, Data.DataTable).Select("コード='" & txtSIIRECODE.Text & "'")
        If row.Length = 0 Then
            MessageBoxEx.Show(CommonUtility.MessageCode_Arg1.M014が存在しません, txtSIIRECODE.DisplayName, Me.Text)
            txtSIIRECODE.Focus()
            Return
        End If

        '仕入先の直近データを取得
        Dim dtHATYU = T_HATYU.fncSelectT_HATYUHED_SIIRE(txtHATYUNO.Text, txtSIIRECODE.Text)

        If dtHATYU.Rows.Count = 0 Then

            '受注の承認区分の取得
            Dim approvalKbnJyutyu = CType(T_BUKKEN_APPROVAL.GetDataWhereGyomuKbn(
                  txtHATYUNO.Text _
                , T_BUKKEN_APPROVALRead.enumGyomuKbn.Jyuchu
                ).Rows(0), dsT_BUKKEN_APPROVAL.T_BUKKEN_APPROVALRow).APPROVALKBN

            '受注未承認の場合、エラー
            If approvalKbnJyutyu = T_BUKKEN_APPROVALRead.enumApprovalKbn.SYONIN_MI Then
                MessageBoxEx.Show(CommonUtility.MessageCode_Arg0.M236, Me.Text)
                txtSIIRECODE.Focus()
                Return
            End If

            '画面の初期化（発注枝番のクリアと受注枝番の最新化の為）
            txtHATYUEDABAN.Text = ""
            txtHATYUEDABAN2.Text = ""
            InitDisp()

            '発注情報が存在しない場合
            TitleBar.EditMode = EditMode.Create

            'ファンクションキーの初期化
            Call InitFunctionKey()

            'コントール活性制御
            Call InitEnabledControl()

            '仕入先情報を表示
            DispSiireInfo()

            '受注明細情報の表示
            Call DispJyutyuMeisaiInfo()

            'コメント情報の取得
            Dim hatyuCommentLogic As New HAT0001DataAccess.Read(txtHATYUNO.Text, txtHATYUEDABAN.Text, txtHATYUEDABAN2.Text)
            DataSetCommentValue = hatyuCommentLogic.Readコメント情報取得.コメント情報

            txtHATYUDATE.Focus()

        Else
            '発注情報が存在する場合
            Dim drHATYU = CType(dtHATYU.Rows(0), dsT_HATYU.T_HATYUHEDRow)

            '発注枝番に最新の発注をセット
            txtHATYUEDABAN.Text = ZeroPadding(drHATYU.HATYUEDABAN, txtHATYUEDABAN.MaxLength)
            txtHATYUEDABAN2.Text = ZeroPadding(drHATYU.HATYUEDABAN2, txtHATYUEDABAN2.MaxLength)

            '発注NoのEnterイベントの実行
            ChangeHATYUEDABAN()
        End If
    End Sub

    Private Sub DispSiireInfo()
        '仕入マスタ情報の取得
        Dim logic As New M_SIIRERead(txtSIIRECODE.Text)
        Dim ds = logic.GetM_SIIRE
        Dim dr = DirectCast(ds.Tables(0).Rows(0), dsM_SIIRE.M_SIIRERow)

        '仕入先の直近データを取得
        Dim dtHATYU = T_HATYU.fncSelectT_HATYUHED_SIIRE(txtHATYUNO.Text, txtSIIRECODE.Text)

        If dtHATYU.Rows.Count = 0 Then
            txtKEISYOUCODE.Text = dr.KEISYOUCODE
            txtSIHARAI_COMMENT_01.Text = "毎月" + NS(dr.SIMEBI1) + "日締切　翌月" + NS(dr.SIHARAIBI1) + "日支払"
            txtSIHARAI_COMMENT_02.Text = "検収出来高    " + NS(dr.KENSYU_DEKIDAKA) + "        ％"
            txtSIHARAI_COMMENT_03.Text = ""
            txtSIHARAI_COMMENT_04.Text = "現金  " + NS(dr.SIHARAI_GENKINRITU) + "  ％"
            txtSIHARAI_COMMENT_05.Text = "手形  " + NS(dr.SIHARAI_TEGATARITU) + "  ％"

        Else
            Dim drHATYU = CType(dtHATYU.Rows(0), dsT_HATYU.T_HATYUHEDRow)

            txtJYUTYUEDABAN.Text = ZeroPadding(drHATYU.JYUTYUEDABAN, txtJYUTYUEDABAN.MaxLength)

            txtKEISYOUCODE.Text = drHATYU.KEISYOUCODE
            txtSIHARAI_COMMENT_01.Text = drHATYU.SIHARAI_COMMENT_01
            txtSIHARAI_COMMENT_02.Text = drHATYU.SIHARAI_COMMENT_02
            txtSIHARAI_COMMENT_03.Text = drHATYU.SIHARAI_COMMENT_03
            txtSIHARAI_COMMENT_04.Text = drHATYU.SIHARAI_COMMENT_04
            txtSIHARAI_COMMENT_05.Text = drHATYU.SIHARAI_COMMENT_05
            txtSIHARAI_COMMENT_06.Text = drHATYU.SIHARAI_COMMENT_06
        End If

        txtZeiKbn.Text = dr.ZEIKBN.ToString
        Select Case txtZeiKbn.Text
            Case "0"
                lblTAX.Text = "消費税："
                lblTAX.Visible = True
                lblGKTAX.Visible = True
                lblGKGENKA.Visible = True
                lblGKGENKAGAKU.Visible = True
            Case "1"
                lblTAX.Text = "内消費税："
                lblTAX.Visible = True
                lblGKTAX.Visible = True
                lblGKGENKA.Visible = False
                lblGKGENKAGAKU.Visible = False
            Case Else
                lblTAX.Visible = False
                lblGKTAX.Visible = False
                lblGKGENKA.Visible = False
                lblGKGENKAGAKU.Visible = False
        End Select
    End Sub

    Private Sub DispJyutyuInfo()
        Dim drJyutyu = CType(T_JYUTYU.fncSelectT_JYUTYUHED(txtHATYUNO.Text, txtJYUTYUEDABAN.Text).Rows(0), dsT_JYUTYU.T_JYUTYUHEDRow)

        lblTANTONAME.Text = drJyutyu.TANTONAME
        lblKOUJINAME.Text = drJyutyu.KOUJINAME
        lblKOUJINO.Text = drJyutyu.KOUJINO
        lblKOUJIBASYO.Text = drJyutyu.KOUJIBASYO
        lblSURYO_SYOSUIKAKETA.Text = drJyutyu.SURYO_SYOSUIKAKETA
        dbgMeisai.Columns(COLMeisai.SUU).NumberFormat = NumberFormat(drJyutyu.SURYO_SYOSUIKAKETA)
    End Sub

    Private Sub DispJyutyuMeisaiInfo()
        '仕入先の直近データを取得
        Dim dtHATYU = T_HATYU.fncSelectT_HATYUHED_SIIRE(txtHATYUNO.Text, txtSIIRECODE.Text)

        '前の発注の受注枝番を取得
        Dim jyutyuEdabanBef = 100               '存在しない場合、取得しないように100をセット
        If dtHATYU.Rows.Count <> 0 Then
            jyutyuEdabanBef = CType(dtHATYU.Rows(0), dsT_HATYU.T_HATYUHEDRow).JYUTYUEDABAN
        End If

        Dim read As New HAT0001DataAccess.Read
        Dim responseParams As dsHAT0001 = read.Read受注明細情報取得(txtHATYUNO.Text, txtJYUTYUEDABAN.Text, jyutyuEdabanBef, txtSIIRECODE.Text)

        dbgMeisai.SetDataBinding(responseParams.明細情報, "", True) '明細情報

        '合計計算
        subDbgSumMeisai()

        lblGKGENKAGAKU_NUKIBefore.Text = lblGKGENKAGAKU_NUKI.Text
    End Sub

    Private Sub InitDbGridMeisai()

        With dbgMeisai
            With .Columns
                .Add(New C1DataColumn("", "KAMOKU_HINMOKU", Type.GetType("System.String")))
                .Add(New C1DataColumn("", "HINSITU_KIKAKU_SIYO", Type.GetType("System.String")))
                .Add(New C1DataColumn("", "SUU", Type.GetType("System.Decimal")))
                .Add(New C1DataColumn("", "TANI", Type.GetType("System.Decimal")))
                .Add(New C1DataColumn("", "GENTANKA", Type.GetType("System.Decimal")))
                .Add(New C1DataColumn("", "GENKAGAKU", Type.GetType("System.Decimal")))
                .Add(New C1DataColumn("", "G_BIKO", Type.GetType("System.String")))
                .Add(New C1DataColumn("", "JYUTYUEDABAN", Type.GetType("System.String")))
                .Add(New C1DataColumn("", "KAISOCODE", Type.GetType("System.String")))
                .Add(New C1DataColumn("", "JYUTYUEDABAN_DAIKAMOKU", Type.GetType("System.String")))
                .Add(New C1DataColumn("", "KAISOCODE_DAIKAMOKU", Type.GetType("System.String")))
                .Add(New C1DataColumn("", "DAIKAMOKUCODE", Type.GetType("System.String")))
                .Add(New C1DataColumn("", "CYUKAMOKUCODE", Type.GetType("System.String")))
                .Add(New C1DataColumn("", "SYOKAMOKUCODE", Type.GetType("System.String")))
                .Add(New C1DataColumn("", "KAKERITU", Type.GetType("System.String")))
                .Add(New C1DataColumn("", "IKATU_KAKERITU", Type.GetType("System.String")))
            End With

            For i As Integer = 0 To .Columns.Count - 1
                .Splits(0).DisplayColumns(i).Visible = False
            Next

            .Columns(COLMeisai.KAMOKU_HINMOKU).Caption = "科目・品目"
            .Columns(COLMeisai.HINSITU_KIKAKU_SIYO).Caption = "品質・規格・仕様"
            .Columns(COLMeisai.SUU).Caption = "数量"
            .Columns(COLMeisai.TANI).Caption = "単位"
            .Columns(COLMeisai.GENTANKA).Caption = "原単価"
            .Columns(COLMeisai.GENKAGAKU).Caption = "原価金額"
            .Columns(COLMeisai.G_BIKO).Caption = "備考"

            .RecordSelectors = False 'レコードセレクタ非表示（グリッド左側）

            GridSetup(dbgMeisai, GridSetupAllows.AllowAll, False, False, False)

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
            .Font = New Font("メイリオ", 8.25!, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 128)
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
            .HeadingStyle.Font = New System.Drawing.Font("メイリオ", 8.25!, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 128)

            '*** TrueDBGrid HeadingStyle.HorizontalAlignment プロパティ設定 ***
            For intIndex As Integer = 0 To dbgMeisai.Columns.Count - 1
                .Splits(0).DisplayColumns(intIndex).HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            Next

            '*** TrueDBGrid ColumnDivider.Style プロパティ設定 ***
            For intIndex As Integer = 0 To dbgMeisai.Columns.Count - 1
                .Splits(0).DisplayColumns(intIndex).ColumnDivider.Color = Color.FromArgb(224, 224, 224)
            Next

            ''*** TrueDBGrid Style.HorizontalAlignment プロパティ設定 ***
            For intIndex As Integer = 0 To dbgMeisai.Columns.Count - 1
                .Splits(0).DisplayColumns(intIndex).Style.HorizontalAlignment = AlignHorzEnum.General
            Next

            With .Splits(0)
                .DisplayColumns(COLMeisai.KAMOKU_HINMOKU).Style.HorizontalAlignment = AlignHorzEnum.Near
                .DisplayColumns(COLMeisai.HINSITU_KIKAKU_SIYO).Style.HorizontalAlignment = AlignHorzEnum.Near
                .DisplayColumns(COLMeisai.SUU).Style.HorizontalAlignment = AlignHorzEnum.Far
                .DisplayColumns(COLMeisai.TANI).Style.HorizontalAlignment = AlignHorzEnum.Near
                .DisplayColumns(COLMeisai.GENTANKA).Style.HorizontalAlignment = AlignHorzEnum.Far
                .DisplayColumns(COLMeisai.GENKAGAKU).Style.HorizontalAlignment = AlignHorzEnum.Far
                .DisplayColumns(COLMeisai.G_BIKO).Style.HorizontalAlignment = AlignHorzEnum.Near

                .DisplayColumns(COLMeisai.KAMOKU_HINMOKU).Width = 210
                .DisplayColumns(COLMeisai.HINSITU_KIKAKU_SIYO).Width = 210
                .DisplayColumns(COLMeisai.SUU).Width = 80
                .DisplayColumns(COLMeisai.TANI).Width = 60
                .DisplayColumns(COLMeisai.GENTANKA).Width = 100
                .DisplayColumns(COLMeisai.GENKAGAKU).Width = 100
                .DisplayColumns(COLMeisai.G_BIKO).Width = 131

                .DisplayColumns(COLMeisai.KAMOKU_HINMOKU).Visible = True
                .DisplayColumns(COLMeisai.HINSITU_KIKAKU_SIYO).Visible = True
                .DisplayColumns(COLMeisai.SUU).Visible = True
                .DisplayColumns(COLMeisai.TANI).Visible = True
                .DisplayColumns(COLMeisai.GENTANKA).Visible = True
                .DisplayColumns(COLMeisai.GENKAGAKU).Visible = True
                .DisplayColumns(COLMeisai.G_BIKO).Visible = True
            End With

            '*** TrueDBGrid Locked プロパティ設定 ***
            For intIndex As Integer = 0 To dbgMeisai.Columns.Count - 1
                .Splits(0).DisplayColumns(intIndex).Locked = False
            Next

            '*** TrueDBGrid AllowSizing プロパティ設定 ***
            For intI As Integer = 0 To dbgMeisai.Columns.Count - 1
                .Splits(0).DisplayColumns(intI).AllowSizing = True
            Next intI

            '*** TrueDBGrid WrapText プロパティ設定 ***
            For intI As Integer = 0 To dbgMeisai.Columns.Count - 1
                .Splits(0).DisplayColumns(intI).Style.WrapText = True
            Next intI

            .Columns(COLMeisai.GENTANKA).NumberFormat = "#,##0"
            .Columns(COLMeisai.GENKAGAKU).NumberFormat = "#,##0"

            '外観をコンボボックスに設定
            Dim co1 As C1DataColumn

            '単位
            ' コンボボックスを設定します
            co1 = .Columns(COLMeisai.TANI)
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

            .Splits(0).DisplayColumns(COLMeisai.TANI).Button = CType(IIf(.Splits(0).DisplayColumns(COLMeisai.TANI).Locked = True, False, True), Boolean)
        End With
    End Sub

    ''' <summary>
    ''' 区分マスタデータ抽出
    ''' </summary>
    ''' <remarks></remarks>
    Private Function fncRead_M_KBN(ByVal strSiyouKbn As String, Optional ByVal strKbn As String = "") As Boolean
        Dim blnRet As Boolean
        Dim ds As M_KBNRead
        Dim logic As New M_KBNRead(strSiyouKbn, strKbn)

        On Error GoTo fncRead_M_KBN_Err

        fncRead_M_KBN = False '戻り値初期化

        'ﾌﾗｸﾞ初期化
        blnRet = False

        dbM_KBNValue = logic.GetM_KBN
        If dbM_KBNValue.HasValue = True Then
            For intI As Integer = 0 To dbM_KBNValue.M_KBN.Count - 1
                Select Case strSiyouKbn
                    Case "06" : dbM_KBN_SIYOU06 = dbM_KBNValue
                End Select
            Next intI
        End If

        fncRead_M_KBN = True

fncRead_M_KBN_Exit:

        Exit Function

fncRead_M_KBN_Err:

        MessageBox.Show(Err.Number & "：" & Err.Description, PROGRAM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Stop)

        GoTo fncRead_M_KBN_Exit
    End Function

    ''' <summary>
    ''' 基本設定マスタデータ抽出
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub fncRead_S_SCB()
        Dim blnRet As Boolean
        Dim logic As New S_SCBRead()

        'ﾌﾗｸﾞ初期化
        blnRet = False

        dbS_SCBValue = logic.GetS_SCB
        If dbS_SCBValue.HasValue = True Then
            For intI As Integer = 0 To dbS_SCBValue.S_SCB.Count - 1
                Select Case dbS_SCBValue.S_SCB(intI).CATEGORYID
                    Case "SYSTEM"
                        Select Case dbS_SCBValue.S_SCB(intI).DATAKEY
                            Case "ROUND_MITSUURYO" : strS_SCB_ROUND_MITSUURYO = dbS_SCBValue.S_SCB(intI).DATA
                            Case "ROUND_GENKAKIN" : strS_SCB_ROUND_GENKAKIN = dbS_SCBValue.S_SCB(intI).DATA
                            Case "ROUND_GENTANKA" : strS_SCB_ROUND_GENTANKA = dbS_SCBValue.S_SCB(intI).DATA
                            Case "ROUND_TAX" : strS_SCB_ROUND_TAX = dbS_SCBValue.S_SCB(intI).DATA
                        End Select
                End Select
            Next intI
        End If
    End Sub

    Private Sub dbgMEISAI_OnAddNew(ByVal sender As Object, ByVal e As System.EventArgs) Handles dbgMeisai.OnAddNew
        With dbgMeisai
            .Columns(COLMeisai.KAMOKU_HINMOKU).Value = "新しい科目"
            .Columns(COLMeisai.SUU).Value = 0
            .Columns(COLMeisai.GENTANKA).Value = 0
            .Columns(COLMeisai.GENKAGAKU).Value = 0
            .Columns(COLMeisai.JYUTYUEDABAN).Value = txtJYUTYUEDABAN.Text
            .Columns(COLMeisai.JYUTYUEDABAN_DAIKAMOKU).Value = txtJYUTYUEDABAN.Text
            .Columns(COLMeisai.KAISOCODE_DAIKAMOKU).Value = "999"
            .Columns(COLMeisai.KAKERITU).Value = "0"
            .Columns(COLMeisai.IKATU_KAKERITU).Value = "0"
            '登録時に階層コードを採番
            .Columns(COLMeisai.KAISOCODE).Value = ""
        End With

        dbgMeisai.Refresh()
    End Sub

    Private Sub dbgMEISAI_BeforeColUpdate(ByVal sender As Object, ByVal e As BeforeColUpdateEventArgs) Handles dbgMeisai.BeforeColUpdate
        Dim blnWork As Boolean
        Dim strCtrlName As String
        Dim intI As Integer

        On Error GoTo ErrorHandler

        With dbgMeisai

            Select Case e.ColIndex

                '科目・品目
                Case COLMeisai.KAMOKU_HINMOKU

                    strCtrlName = "科目・品目"

                    '桁数チェック40byte
                    If LenBSA(.Columns(e.ColIndex).Text) > 40 Then
                        MessageBoxEx.Show(MessageCode_Arg1.M020の桁数が大きすぎます, strCtrlName, Me.Text)
                        GoTo CheckError
                    End If

                    '品質・規格・仕様
                Case COLMeisai.HINSITU_KIKAKU_SIYO

                    strCtrlName = "品質・規格・仕様"

                    '桁数チェック40byte
                    If LenBSA(.Columns(e.ColIndex).Text) > 40 Then
                        MessageBoxEx.Show(MessageCode_Arg1.M020の桁数が大きすぎます, strCtrlName, Me.Text)
                        GoTo CheckError
                    End If

                    '数量
                Case COLMeisai.SUU

                    strCtrlName = "数量"
                    '空白チェック
                    If NUCheck(.Columns(e.ColIndex).Text) = True Then
                        .Columns(COLMeisai.SUU).Text = "0"
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

                    '単位
                Case COLMeisai.TANI
                    strCtrlName = "単位"

                    '桁数チェック10byte
                    If LenBSA(.Columns(e.ColIndex).Text) > 10 Then
                        MessageBoxEx.Show(MessageCode_Arg1.M020の桁数が大きすぎます, strCtrlName, Me.Text)
                        GoTo CheckError
                    End If

                    '原単価
                Case COLMeisai.GENTANKA

                    strCtrlName = "原単価"
                    '空白チェック
                    If NUCheck(.Columns(e.ColIndex).Text) = True Then
                        .Columns(COLMeisai.GENTANKA).Text = "0"
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

                    '原価金額
                Case COLMeisai.GENKAGAKU

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

                    '備考
                Case COLMeisai.G_BIKO

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
        Exit Sub

ErrorHandler:
        MessageBox.Show(Err.Number & "：" & Err.Description, PROGRAM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Stop)

        GoTo CheckError
    End Sub

    Private Sub dbgMEISAI_RowColChange(ByVal sender As Object, ByVal e As RowColChangeEventArgs) Handles dbgMeisai.RowColChange

        '*** IMEモード設定 ***
        With dbgMeisai
            Select Case .Col
                Case COLMeisai.SUU, COLMeisai.GENTANKA, COLMeisai.GENKAGAKU
                    '---ImeMode Off---
                    .ImeMode = Windows.Forms.ImeMode.Disable
                    For Each ctrl As Control In .Controls
                        If TypeOf ctrl Is TextBox Then
                            ctrl.ImeMode = Windows.Forms.ImeMode.Disable
                        End If
                    Next
                Case COLMeisai.KAMOKU_HINMOKU, COLMeisai.HINSITU_KIKAKU_SIYO, COLMeisai.TANI, COLMeisai.G_BIKO
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

    Private Function GetRoundValue(ByVal obj As String) As Decimal
        'グローバル変数を直接参照する(内部より)
        Select Case strS_SCB_ROUND_MITSUURYO
            Case "0", "1", "2"
            Case Else
                'ありえないが、０１２以外の場合は強制的に0とする
                strS_SCB_ROUND_MITSUURYO = "0"
        End Select
        Select Case lblSURYO_SYOSUIKAKETA.Text
            Case "0", "1", "2", "3"
            Case Else
                lblSURYO_SYOSUIKAKETA.Text = "0"
        End Select

        Return CnvToDecimalPoint(
              obj _
            , CType(Int32.Parse(lblSURYO_SYOSUIKAKETA.Text), enumDigit) _
            , CType(Int32.Parse(strS_SCB_ROUND_MITSUURYO), enumDivide))
    End Function

    Public Function CnvToDecimalPoint(ByVal obj As String, ByVal Digit As enumDigit, ByVal Round_divide As enumDivide) As Decimal
        Dim dec As Decimal = 0

        If Decimal.TryParse(obj, dec) = False Then Return 0

        Return Round(dec, Digit, Round_divide)

    End Function

    Private Sub dbgMEISAI_AfterColUpdate(ByVal sender As Object, ByVal e As ColEventArgs) Handles dbgMeisai.AfterColUpdate
        If dbgMeisai.Col = COLMeisai.SUU OrElse dbgMeisai.Col = COLMeisai.GENTANKA Then
            '金額計算
            subDbgCalcKingaku()

            '合計計算
            subDbgSumMeisai()
        End If
    End Sub

    Private Sub dbgMEISAI_AfterUpdate(ByVal sender As Object, ByVal e As System.EventArgs) Handles dbgMeisai.AfterUpdate
        '合計計算
        subDbgSumMeisai()

        '新規行追加設定
        subDbgAddNewSet()
    End Sub

    Private Sub dbgMEISAI_AfterDelete(ByVal sender As Object, ByVal e As System.EventArgs) Handles dbgMeisai.AfterDelete
        '合計計算
        subDbgSumMeisai()

        '新規行追加設定
        subDbgAddNewSet()
    End Sub

    Private Sub dbgMEISAI_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles dbgMeisai.KeyDown
        Select Case dbgMeisai.Col

            '原単価
            Case COLMeisai.GENTANKA
                '数値以外の入力を無効にする
                blnDbgKeyCtrlFlg = False
                If e.KeyCode >= Keys.LButton And e.KeyCode <= Keys.Help Then            '=== 色々キーコード
                ElseIf e.KeyCode >= Keys.D0 And e.KeyCode <= Keys.D9 Then               '=== ０～９キー
                ElseIf e.KeyCode >= Keys.NumPad0 And e.KeyCode <= Keys.NumPad9 Then     '=== テンキー
                ElseIf e.KeyCode = Keys.NumLock Then                                    '=== NumLockキー
                ElseIf e.KeyCode = Keys.Subtract Then                                   '=== マイナスキー
                Else
                    blnDbgKeyCtrlFlg = True
                End If

                '原価金額
            Case COLMeisai.GENKAGAKU
                '数値以外の入力を無効にする
                blnDbgKeyCtrlFlg = False
                If e.KeyCode >= Keys.LButton And e.KeyCode <= Keys.Help Then            '=== 色々キーコード
                ElseIf e.KeyCode >= Keys.D0 And e.KeyCode <= Keys.D9 Then               '=== ０～９キー
                ElseIf e.KeyCode >= Keys.NumPad0 And e.KeyCode <= Keys.NumPad9 Then     '=== テンキー
                ElseIf e.KeyCode = Keys.NumLock Then                                    '=== NumLockキー
                ElseIf e.KeyCode = Keys.Subtract Then                                   '=== マイナスキー
                Else
                    blnDbgKeyCtrlFlg = True
                End If

                '数量
            Case COLMeisai.SUU
                '数値以外の入力を無効にする
                blnDbgKeyCtrlFlg = False
                If e.KeyCode >= Keys.LButton And e.KeyCode <= Keys.Help Then            '=== 色々キーコード
                ElseIf e.KeyCode >= Keys.D0 And e.KeyCode <= Keys.D9 Then               '=== ０～９キー
                ElseIf e.KeyCode >= Keys.NumPad0 And e.KeyCode <= Keys.NumPad9 Then     '=== テンキー
                ElseIf e.KeyCode = Keys.Decimal Then                                    '=== 小数点
                ElseIf e.KeyCode = Keys.NumLock Then                                    '=== NumLockキー
                ElseIf e.KeyCode = Keys.Subtract Then                                   '=== マイナスキー
                ElseIf e.KeyCode = 189 Then
                ElseIf e.KeyCode = 190 Then
                Else
                    blnDbgKeyCtrlFlg = True
                End If
        End Select
    End Sub

    Private Sub dbgMEISAI_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles dbgMeisai.KeyPress
        Select Case dbgMeisai.Col
            Case COLMeisai.SUU, COLMeisai.GENTANKA, COLMeisai.GENKAGAKU
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

        Try
            RemoveHandler dbgMeisai.Leave, AddressOf dbgMEISAI_Leave

            'DBGridの更新を済ませてからフォーカス移動
            With dbgMeisai
                If (.DataChanged = True) Then
                    .UpdateData()
                End If

                '入力チェック
                For intI As Integer = .RowCount - 1 To 0 Step -1
                    If NUCheck(dbgMeisai(intI, COLMeisai.KAMOKU_HINMOKU).ToString) Then
                        MessageBoxEx.Show(MessageCode_Arg1.M015は必ず入力して下さい, "科目・品目", PROGRAM_NAME)
                        .Col = COLMeisai.KAMOKU_HINMOKU
                        .Row = intI
                        .Focus()
                        Exit Sub
                    End If
                Next
            End With

        Finally
            AddHandler dbgMeisai.Leave, AddressOf dbgMEISAI_Leave
        End Try
    End Sub

    Private Sub subDbgCalcKingaku()
        With dbgMeisai
            '原単価
            If Not NUCheck(dbgMeisai.Columns(COLMeisai.GENTANKA).Value) Then
                dbgMeisai.Columns(COLMeisai.GENTANKA).Value = Utility.Round(CDec(dbgMeisai.Columns(COLMeisai.GENTANKA).Value), 0, CInt(strS_SCB_ROUND_GENTANKA))
                If CDec(dbgMeisai.Columns(COLMeisai.GENTANKA).Value) > 999999999 Then dbgMeisai.Columns(COLMeisai.GENTANKA).Value = 999999999
            End If

            If Not NUCheck(dbgMeisai.Columns(COLMeisai.SUU).Value) And Not NUCheck(dbgMeisai.Columns(COLMeisai.GENTANKA).Value) Then
                '原価金額（数量 * 原単価）
                dbgMeisai.Columns(COLMeisai.GENKAGAKU).Value = Utility.Round(GetRoundValue(dbgMeisai.Columns(COLMeisai.SUU).Value.ToString) * CDec(dbgMeisai.Columns(COLMeisai.GENTANKA).Value), 0, CInt(strS_SCB_ROUND_GENKAKIN))
                '計算結果桁数チェック
                If CDec(dbgMeisai.Columns(COLMeisai.GENKAGAKU).Value) > 999999999999 Then dbgMeisai.Columns(COLMeisai.GENKAGAKU).Value = 999999999999
            End If
        End With
    End Sub

    Private Sub subDbgSumMeisai()
        Dim decMKGenkagaku As Decimal = 0
        Dim decGKTAX As Decimal = 0
        Dim decGKGAKU_NUKI As Decimal = 0

        For intI As Integer = 0 To dbgMeisai.RowCount - 1
            decMKGenkagaku = decMKGenkagaku + NZ(dbgMeisai(intI, COLMeisai.GENKAGAKU).ToString)
        Next

        '【明細計】原価額
        If decMKGenkagaku > 999999999999 Then decMKGenkagaku = 999999999999
        lblGKGENKAGAKU_NUKI.Text = Format(decMKGenkagaku, "#,##0")

        '【明細計】消費税、合計
        decGKGAKU_NUKI = CDec(lblGKGENKAGAKU_NUKI.Text)
        Select Case txtZeiKbn.Text
            Case "0"
                decGKTAX = CDec(decGKGAKU_NUKI * (CDbl(strSyohiZeiritu) / 100))
                decGKTAX = Utility.Round(decGKTAX, 1, CInt(strS_SCB_ROUND_TAX))
                If decGKTAX > 999999999999 Then decGKTAX = 999999999999
                lblGKTAX.Text = Format(decGKTAX, "#,##0")
                '【総合計】合計
                If (decGKGAKU_NUKI + decGKTAX) > 999999999999 Then
                    lblGKGENKAGAKU.Text = Format(999999999999, "#,##0")
                Else
                    lblGKGENKAGAKU.Text = Format(decGKGAKU_NUKI + decGKTAX, "#,##0")
                End If

            Case "1"
                decGKTAX = CDec(decGKGAKU_NUKI * CDbl(strSyohiZeiritu) / (100 + CDbl(strSyohiZeiritu)))
                decGKTAX = Utility.Round(decGKTAX, 1, CInt(strS_SCB_ROUND_TAX))
                If decGKTAX > 999999999999 Then decGKTAX = 999999999999
                lblGKTAX.Text = Format(decGKTAX, "#,##0")
                lblGKGENKAGAKU.Text = Format(decGKGAKU_NUKI, "#,##0")

            Case "2"
                lblGKTAX.Text = "0"
                lblGKGENKAGAKU.Text = Format(decGKGAKU_NUKI, "#,##0")
        End Select
    End Sub

    Private Sub subDbgAddNewSet()
        '入力明細が最大行を超えた場合は、新規行追加は不可
        If dbgMeisai.RowCount + 1 >= ROW_COUNT Then
            dbgMeisai.AllowAddNew = False
        Else
            dbgMeisai.AllowAddNew = True
        End If
    End Sub

    Public Function AllInputValidate() As Boolean
        Return InputErrorCheck(Nothing, 9999999)
    End Function

    Private Sub EnterEventHandler(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If CType(sender, System.Windows.Forms.Control).CausesValidation = False Then
            Return
        End If

        '編集状態以外は処理しない
        If Not (TitleBar.EditMode = EditMode.Create OrElse TitleBar.EditMode = EditMode.Edit) Then Return

        FunctionKey.SetItem(5, "科目品目", "科目/品目", False)
        FunctionKey.SetItem(6, "行削除", "行削除", False)

        If InputErrorCheck(CType(sender, System.Windows.Forms.Control), GetTabOrder(CType(sender, System.Windows.Forms.Control))) = False Then
            Return
        End If
    End Sub

    Private Function InputErrorCheck(ByVal sender As System.Windows.Forms.Control, ByVal tabOrder As Integer) As Boolean
        Dim CheckResult As Nullable(Of Boolean)

        CheckResult = InputErrorCheck_Control(txtSIIRECODE, tabOrder)
        If CheckResult.HasValue Then Return CheckResult.Value

        CheckResult = InputErrorCheck_Control(txtHATYUDATE, tabOrder)
        If CheckResult.HasValue Then Return CheckResult.Value

        '前回の発注より未来日以外の場合、エラー
        If Not NUCheck(txtHATYUEDABAN.Text) Then
            '前の発注の取得
            Dim dtHATYU_ZENKAI = T_HATYU.fncSelectT_HATYUHED_PK(txtHATYUNO.Text, txtHATYUEDABAN.Text, CDec(txtHATYUEDABAN2.Text) - 1)

            If dtHATYU_ZENKAI.Rows.Count <> 0 Then
                Dim dr = CType(dtHATYU_ZENKAI.Rows(0), dsT_HATYU.T_HATYUHEDRow)

                If txtHATYUDATE.Text <= dr.HATYUDATE Then
                    MessageBoxEx.Show(MessageCode_Arg1.M235, "発注日", PROGRAM_NAME)
                    txtHATYUDATE.Focus()
                    Return False
                End If
            End If
        End If

        CheckResult = InputErrorCheck_Control(txtKEISYOUCODE, tabOrder)
        If CheckResult.HasValue Then Return CheckResult.Value

        CheckResult = InputErrorCheck_Control(txtNOUKI_START, tabOrder)
        If CheckResult.HasValue Then Return CheckResult.Value

        CheckResult = InputErrorCheck_Control(txtNOUKI_END, tabOrder)
        If CheckResult.HasValue Then Return CheckResult.Value

        If RangeValidator.ValidateMe(txtNOUKI_START.DisplayName, txtNOUKI_START, txtNOUKI_END) = False Then
            txtNOUKI_START.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub txtHATYUDATE_TextChanged(sender As Object, e As EventArgs) Handles txtHATYUDATE.TextChanged
        lblHATYUDATE.Text = fncCnvJapaneseDate(txtHATYUDATE.Text)
    End Sub

    Private Sub EventHandlerDbgMeisai(ByVal sender As Object, ByVal e As System.EventArgs)

        '編集状態以外は処理しない
        If Not (TitleBar.EditMode = EditMode.Create OrElse TitleBar.EditMode = EditMode.Edit) Then Return

        FunctionKey.SetItem(6, "行削除", "行削除", True)

        'ファンクションキーの設定
        setFunctionKeyChangeDbgMEISAI()
    End Sub

    Private Sub setFunctionKeyChangeDbgMEISAI()
        'ファンクションキーの設定

        '編集状態以外は処理しない
        If Not (TitleBar.EditMode = EditMode.Create OrElse TitleBar.EditMode = EditMode.Edit) Then Return

        '初期化
        FunctionKey.SetItem(5, "科目品目", "科目/品目", True)
    End Sub

    '和暦換算
    Private Function fncCnvJapaneseDate(ByVal str As String) As String

        If IsDate(str) = False Then Return ""

        ' カルチャの「言語-国/地域」を「日本語-日本」に設定します。
        Dim ci As New System.Globalization.CultureInfo("ja-JP")
        ' 和暦を表すクラスです。
        Dim jp As New System.Globalization.JapaneseCalendar
        Dim dt As System.DateTime

        ' 現在のカルチャで使用する暦を、和暦に設定します。
        ci.DateTimeFormat.Calendar = jp

        ' TextBoxのデータを、DateTime型に変換します。
        dt = DateTime.Parse(str)

        ' 「書式」「カルチャの書式情報」を使用し、文字列に変換します。
        Return dt.ToString("(ggyy年)", ci)
    End Function

    ''' <summary>
    ''' 支払条件Enterキー押下
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtSIHARAI_COMMENT_06_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSIHARAI_COMMENT_06.KeyDown
        'キーコードチェック
        If Not (e.KeyCode = Keys.Enter OrElse e.KeyCode = Keys.Tab) Then Exit Sub

        dbgMeisai.Focus()

    End Sub

End Class