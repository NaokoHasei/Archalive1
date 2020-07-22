Imports CommonUtility.WinForm
Imports CommonUtility.Utility
Imports CommonUtility.WinFormControls
Imports C1.Win.C1TrueDBGrid
Imports CommonUtility
Imports BLL.Common

Public Class frmSEI0001

    Private dalogic As New daSEI0001
    Private M_TOKUI As New M_TOKUIread
    Private T_BUKKEN As New T_BUKKENRead
    Private T_BUKKEN_APPROVAL As New T_BUKKEN_APPROVALRead
    Private T_JYUTYU As New T_JYUTYURead
    Private T_SEIKYU As New T_SEIKYURead

    Public requestBUK0001 As New requestBUK0001

    Public MainData As dsSEI0001.MainDataDataTable
    Public 訂正前請求ヘッダ As dsT_SEIKYU.T_SEIKYUHEDRow
    Public dtT_SEIKYU_MEISAI As dsSEI0001.T_SEIKYU_MEISAIDataTable

    Private 請求率丸め区分 As Decimal = 0
    Private 出来高率丸め区分 As Decimal = 0
    Private 税率 As Nullable(Of Decimal) = Nothing
    Private m_変更前請求日付 As Nullable(Of Date) = Nothing
    Private scb As ReportData

    Private SeikyuMethod0_dekidaka As Decimal = 0
    Private SeikyuMethod0_seikyugaku As Decimal = 0
    Private SeikyuMethod0_miseikyugaku As Decimal = 0
    Private SeikyuMethod0_seikyuritu As Decimal = 0
    Private SeikyuMethod1_dekidaka As Decimal = 0
    Private SeikyuMethod1_seikyugaku As Decimal = 0
    Private SeikyuMethod1_miseikyugaku As Decimal = 0
    Private SeikyuMethod1_seikyuritu As Decimal = 0

    Private strSyohiZeiritu As String
    Public strS_SCB_ROUND_ZEIKBN As String
    Private strS_SCB_ROUND_TAX As String

    Public Class ReportData
        Public Const TEL固定値 As String = "TEL   ："
        Public Const FAX固定値 As String = "FAX   ："
        Public Const EMAIL固定値 As String = "E-Mail："
        Public Const URL固定値 As String = "URL   ："

        '画面情報
        Public 請求Ｎｏ As String
        Public 請求日付 As String
        Public 元請名 As String
        Public 今回請求額 As Decimal
        Public 工事名称 As String
        Public 請負金額 As Decimal
        Public 今回迄受領額 As Decimal
        Public 今回迄請求額 As Decimal
        Public 今回請求金額 As Decimal
        Public 伝票備考 As String

        '自社情報
        Public ISO資格 As String
        Public 自社名称 As String
        Public コメント１ As String
        Public 郵便番号 As String
        Public 住所１ As String
        Public 住所２ As String
        Public 電話番号 As String
        Public ＦＡＸ番号 As String
        Public メールアドレス As String
        Public Webサイト As String
        Public 銀行口座１ As String
        Public 銀行口座２ As String
        Public 銀行口座３ As String
        Public 口座名義 As String
        Public 口座名義カナ As String

        '得意先情報
        Public 得意先_名 As String
        Public 得意先_敬称 As String
        Public 得意先_住所県名 As String
        Public 得意先_住所１ As String
        Public 得意先_住所２ As String
        Public 得意先_電話番号 As String
        Public 得意先_FAX番号 As String
        Public 得意先_相手部署名 As String
        Public 得意先_相手担当者名 As String
        Public 得意先_郵便番号 As String
        Public 得意先_税区分 As String

        Public 税率 As Decimal
    End Class

    'メインフォーム明細グリッド列名
    Public Const FLD_請負受注金額 As String = "GKJYUTYUGAKU"
    Public Const FLD_今回迄請求額 As String = "MADESEIKYUGAKU"
    Public Const FLD_出来高 As String = "DEKIDAKA"
    Public Const FLD_今回請求額 As String = "SEIKYUGAKU"
    Public Const FLD_未請求額 As String = "MISEIKYUGAKU"
    Public Const FLD_請求率 As String = "SEIKYURITU"

    '明細部列番号
    Public Enum COL
        請負受注金額
        今回迄請求額
        出来高
        今回請求額
        未請求額
        請求率
    End Enum

    Public Overrides Function PROGRAM_ID() As String
        Return "SEI0001"
    End Function

    Public Overrides Function PROGRAM_NAME() As String
        Return "請求登録"
    End Function

    Private Enum enumFormStatus
        KeyInput
        DetailInput
        KeyInput_AfterEntry
        Reference
    End Enum

    Public Sub New()

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。

        requestBUK0001.BUKKEN_NO = 0
    End Sub

    Protected Overrides Sub Form_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        MyBase.Form_Load(sender, e)

        Using wcur As New WaitCursor

            '物件Noの設定
            txtSeikyuNo.Text = ZeroPadding(requestBUK0001.BUKKEN_NO, txtSeikyuNo.MaxLength)

            TitleBar.EditMode = EditMode.None

            'イベントの定義
            EnterEventAddressOfErrorCheck()

            'グリッドの初期化
            subInitGrid()

            'SCBの取得
            ReadSCB()

            '自社情報の取得
            subReadJisyaInfo(scb)

            'フォームの初期化
            FormSwitch(enumFormStatus.KeyInput)
        End Using

        txtSeikyuEdaban.Focus()
    End Sub

    Private Sub AllControlInitialize(Optional ByVal KeyClear As Boolean = True)

        'コンボボックスの初期化
        subInitCombo()

        '基本情報(左)
        If KeyClear Then
            txtSeikyuEdaban.Text = ""
            cmbSeikyuNo.Text = ""
            lblSEIKYUNO.Text = ""
        End If

        '物件情報の取得
        Dim drT_BUKKEN As dsT_BUKKEN.T_BUKKENRow = DirectCast(T_BUKKEN.GetDataWherePk(CDec(txtSeikyuNo.Text)).Rows(0), dsT_BUKKEN.T_BUKKENRow)

        txtKokyakuCode.Text = drT_BUKKEN.MOTOUKECODE
        txtKokyakuName.Text = drT_BUKKEN.TOKUINAME

        '得意先情報の取得
        Dim drM_TOKUI As dsM_TOKUI.M_TOKUIRow = CType(M_TOKUI.ReadM_TOKUI(txtKokyakuCode.Text).Rows(0), dsM_TOKUI.M_TOKUIRow)

        lblYubin.Text = NS(drM_TOKUI.POSTNO)
        lblJyusyo.Text = NS(drM_TOKUI.ADDRESS) + NS(drM_TOKUI.ADDRESS1) + NS(drM_TOKUI.ADDRESS2)
        lblDenwa.Text = NS(drM_TOKUI.TELNO)
        lblFAX.Text = NS(drM_TOKUI.FAXNO)
        txtKeisyo.Text = NS(drM_TOKUI.KEISYOUCODE)

        '最大の受注枝番の取得
        txtJyutyuEdaban.Text = T_JYUTYU.fncSelectMAX_JYUTYUEDABAN(txtSeikyuNo.Text).Rows(0).Item("JYUTYUEDABAN")

        txtSeikyuDate.Text = ServerDate.ToString("yyyyMMdd")
        txtSeikyuDateDisp.Text = GetCnvSW.SfncYearSW(txtSeikyuDate.Text, True, True)

        lblTANTOCODE.Text = ""
        lblTANTONAME.Text = ""

        '請求方法
        Dim S_SCB = New S_SCBRead("請求登録画面", "請求方法の初期値")
        Dim ds = S_SCB.GetS_SCB
        If ds.Tables(0).Rows.Count = 0 OrElse ds.Tables(0).Rows(0).Item("DATA").ToString = "1" Then
            rdoSeikyuHouhou_0.Checked = True
        Else
            rdoSeikyuHouhou_1.Checked = True
        End If
        '今回迄受領額
        txtKonMadeJyuryoGaku.Text = 0
        '備考
        txtBiko.Text = ""

        '受注情報の表示
        subSetKouziInfo()

        '明細データ(トラン)の初期化
        MainData = Nothing
        dbgMEISAI.SetDataBinding(MainData, "", True)
    End Sub

    Private Sub ReadSCB()

        Dim ret_Seikyu As Nullable(Of Decimal) = dalogic.ReadS_SCB_ROUNDKBN("SYSTEM", "ROUND_SEIKYURITU")
        If ret_Seikyu Is Nothing Then
            Throw New ApplicationException("請求率丸め区分が取得できません")
        Else
            請求率丸め区分 = ret_Seikyu
        End If

        Dim ret_Dekidaka As Nullable(Of Decimal) = dalogic.ReadS_SCB_ROUNDKBN("SYSTEM", "ROUND_DEKIDAKA")
        If ret_Dekidaka Is Nothing Then
            Throw New ApplicationException("出来高丸め区分が取得できません")
        Else
            出来高率丸め区分 = ret_Dekidaka
        End If

        '税区分
        Dim S_SCB = New S_SCBRead("SYSTEM", "ZEIKBN")
        Dim dsS_SCB = S_SCB.GetS_SCB
        strS_SCB_ROUND_ZEIKBN = Decimal.Parse(dsS_SCB.S_SCB(0).DATA)

        '消費税の丸め
        S_SCB = New S_SCBRead("SYSTEM", "ROUND_TAX")
        dsS_SCB = S_SCB.GetS_SCB
        strS_SCB_ROUND_TAX = Decimal.Parse(dsS_SCB.S_SCB(0).DATA)

        '区分マスタ取得（消費税）
        Dim logic As New M_KBNRead()
        strSyohiZeiritu = logic.fncSelect_SyohiZeiritu(System.DateTime.Today)
    End Sub

    Private Sub EnterEventAddressOfErrorCheck()
        'イベント指定
        AddHandler txtSeikyuEdaban.Enter, AddressOf EnterEventHandler
        AddHandler txtSeikyuDate.Enter, AddressOf EnterEventHandler
        AddHandler txtKeisyo.Enter, AddressOf EnterEventHandler
        AddHandler dbgMEISAI.Enter, AddressOf EnterEventHandler
        AddHandler txtKonMadeJyuryoGaku.Enter, AddressOf EnterEventHandler
        AddHandler txtBiko.Enter, AddressOf EnterEventHandler
        AddHandler btnMeisaiInput.Enter, AddressOf EnterEventHandler

        AddHandler rdoSeikyuHouhou_0.CheckedChanged, AddressOf rdoSeikyuHouhou_CheckedChanged
        AddHandler rdoSeikyuHouhou_1.CheckedChanged, AddressOf rdoSeikyuHouhou_CheckedChanged
    End Sub

    ''' <summary>
    ''' コンボボックス設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub subInitCombo()
        Dim logic As New BLL.Common.TypComboBox
        Dim pl As New List(Of Model.DTO.RequestGetComboBoxContentsElement)

        pl.Add(New Model.DTO.RequestGetComboBoxContentsElement(Model.ComboBoxTableName.T_SEIKYUHED_SEIKYUNO, Model.DTO.GetComboBoxContentsResultFieldType.MultipleField, False, txtSeikyuNo.Text))
        pl.Add(New Model.DTO.RequestGetComboBoxContentsElement(Model.ComboBoxTableName.M_KBN, Model.DTO.GetComboBoxContentsResultFieldType.MultipleField, False, "04"))

        Dim r As New Model.DTO.RequestGetComboBoxContents(pl)
        Dim recieveParam = logic.CreateComboBox(r)

        '請求Ｎｏ
        cmbSeikyuNo.AttachDataSource(Model.ComboBoxTableName.T_SEIKYUHED_SEIKYUNO, recieveParam)

        '敬称
        txtKeisyo.AttachDataSource(Model.ComboBoxTableName.M_KBN, recieveParam)
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
    ''' 入力制御切替
    ''' </summary>
    ''' <param name="FormStatus"></param>
    ''' <remarks></remarks>
    Private Sub FormSwitch(ByVal FormStatus As enumFormStatus)

        Dim enabled As Boolean
        If FormStatus = enumFormStatus.DetailInput Then
            enabled = True
        Else
            enabled = False
        End If

        txtSeikyuDate.Enabled = enabled
        txtKeisyo.Enabled = enabled
        rdoSeikyuHouhou_0.Enabled = enabled
        rdoSeikyuHouhou_1.Enabled = enabled
        btnMeisaiInput.Enabled = enabled
        dbgMEISAI.Enabled = enabled
        txtKonMadeJyuryoGaku.Enabled = enabled
        txtBiko.Enabled = enabled

        If FormStatus = enumFormStatus.Reference Then
            txtSeikyuEdaban.Enabled = False
            cmbSeikyuNo.Enabled = False
        Else
            txtSeikyuDate.Focus()                               'txtSeikyuEdabanが非活性で入力チェックが行われるため、フォーカスを移動しておく
            txtSeikyuEdaban.Enabled = Not enabled
            cmbSeikyuNo.Enabled = Not enabled
        End If

        If FormStatus <> enumFormStatus.KeyInput AndAlso FormStatus <> enumFormStatus.KeyInput_AfterEntry Then
            btnMeisaiInput.Enabled = IIf(rdoSeikyuHouhou_0.Checked, False, True)
        End If

        If enabled Then
            '請求枝番の取得
            Dim seikyuEdaban = T_SEIKYU.fncSelectMAX_SEIKYUEDABAN(txtSeikyuNo.Text).Rows(0).Item("SEIKYUEDABAN")

            If (NUCheck(txtSeikyuEdaban.Text) AndAlso NUCheck(seikyuEdaban)) _
                    OrElse (Not NUCheck(txtSeikyuEdaban.Text) AndAlso CDec(txtSeikyuEdaban.Text) = 0) Then
                '1件目の請求の場合
                rdoSeikyuHouhou_CheckedChanged(Nothing, Nothing)
            Else
                '上記以外の場合
                rdoSeikyuHouhou_0.Enabled = False
                rdoSeikyuHouhou_1.Enabled = False
            End If
        End If

        If FormStatus = enumFormStatus.KeyInput Then
            RemoveHandler txtSeikyuDate.TextChanged, AddressOf txtSeikyuDate_TextUpdated
            AllControlInitialize()
        ElseIf FormStatus = enumFormStatus.DetailInput Then
            AddHandler txtSeikyuDate.TextChanged, AddressOf txtSeikyuDate_TextUpdated
        ElseIf FormStatus = enumFormStatus.KeyInput_AfterEntry Then
            RemoveHandler txtSeikyuDate.TextChanged, AddressOf txtSeikyuDate_TextUpdated
            AllControlInitialize(False)
        End If

        subFunctionKeySettings(FormStatus)
    End Sub

    ''' <summary>
    ''' ファンクションキー設定
    ''' </summary>
    ''' <param name="FormStatus"></param>
    ''' <remarks></remarks>
    Private Sub subFunctionKeySettings(ByVal FormStatus As enumFormStatus)

        FunctionKey.ClearAll()

        Select Case FormStatus
            Case enumFormStatus.KeyInput, enumFormStatus.KeyInput_AfterEntry
                FunctionKey.SetItem(1, "終了", "終了", True)

            Case enumFormStatus.DetailInput
                FunctionKey.SetItem(1, "取消", "取消", True)
                FunctionKey.SetItem(11, "プレビュー", "プレビュー", True, FunctionKey.FONT_SMALL)
                FunctionKey.SetItem(12, "登録/印刷", "登録/印刷", True, FunctionKey.FONT_SMALL)

                If NUCheck(txtSeikyuEdaban.Text) = False Then FunctionKey.SetItem(3, "削除", "削除", True)

            Case enumFormStatus.Reference
                FunctionKey.SetItem(1, "取消", "取消", True)
                FunctionKey.SetItem(11, "プレビュー", "プレビュー", True, FunctionKey.FONT_SMALL)
        End Select
    End Sub

    ''' <summary>
    ''' 入力チェック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="tabOrder"></param>
    ''' <remarks></remarks>
    Private Function fncInputErrorCheck(ByVal sender As System.Windows.Forms.Control, ByVal tabOrder As Integer) As Boolean
        Dim CheckResult As Nullable(Of Boolean)

        If txtSeikyuEdaban.Enabled Then
            'header

            '請求No
            CheckResult = InputErrorCheck_Control(txtSeikyuEdaban, tabOrder)
            If CheckResult.HasValue Then Return CheckResult.Value

        Else
            'detail

            '請求日付
            CheckResult = InputErrorCheck_Control(txtSeikyuDate, tabOrder)
            If CheckResult.HasValue Then Return CheckResult.Value

            '1つ前の請求情報を取得
            Dim seikyuEdaban = -1
            If Not NUCheck(txtSeikyuEdaban.Text) Then
                seikyuEdaban = CDec(txtSeikyuEdaban.Text) - 1
            Else
                Dim seikyuEdabanMax = T_SEIKYU.fncSelectMAX_SEIKYUEDABAN(txtSeikyuNo.Text).Rows(0).Item("SEIKYUEDABAN")
                If Not NUCheck(seikyuEdabanMax) Then
                    seikyuEdaban = seikyuEdabanMax
                End If
            End If

            If seikyuEdaban <> -1 Then
                Dim dt = T_SEIKYU.fncSelectT_SEIKYUHED(txtSeikyuNo.Text, seikyuEdaban)

                If txtSeikyuDate.Text <= CType(dt.Rows(0), dsT_SEIKYU.T_SEIKYUHEDRow).SEIKYUDATE Then
                    MessageBoxEx.Show(MessageCode_Arg1.M235, "請求日", PROGRAM_NAME)
                    txtSeikyuDate.Focus()
                    Return False
                End If
            End If

            '敬称
            CheckResult = InputErrorCheck_Control(txtKeisyo, tabOrder)
            If CheckResult.HasValue Then Return CheckResult.Value
        End If

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
    ''' ファンクションキー押下時イベント
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub FunctionKeyAction(ByVal sender As System.Object, ByVal e As CommonUtility.WinFormControls.FunctionKeyEventArgs)

        Select Case e.Name

            Case "終了"
                '呼び出し元の再表示
                CType(ownerForm, frmBUK0001).ShowReDisp()

                Me.Close()

            Case "取消"
                If Not MessageBoxEx.Show(CommonUtility.MessageCode_Arg0.M003取消してもよろしいですか, PROGRAM_NAME) = Windows.Forms.DialogResult.Yes Then Return

                FunctionKey_Cancel()

            Case "削除"
                FunctionKey_Delete()

            Case "プレビュー"
                ReportPrint(True)

            Case "登録/印刷"
                FunctionKey_EntryPrint()
        End Select
    End Sub

    '取消
    Private Sub FunctionKey_Cancel(Optional ByVal CheckMsgOn As Boolean = True)

        If CheckMsgOn Then
            FormSwitch(enumFormStatus.KeyInput)
        Else
            FormSwitch(enumFormStatus.KeyInput_AfterEntry)
        End If

        txtSeikyuEdaban.Focus()

        TitleBar.EditMode = EditMode.None
    End Sub

    '削除
    Private Sub FunctionKey_Delete()

        If Not MessageBoxEx.Show(CommonUtility.MessageCode_Arg0.M002削除してもよろしいですか, PROGRAM_NAME) = Windows.Forms.DialogResult.Yes Then Return

        dalogic.Delete(訂正前請求ヘッダ.SEIKYUNO, 訂正前請求ヘッダ.SEIKYUEDABAN, 訂正前請求ヘッダ.SEIKYUDATE)

        'コンボ再作成
        subInitCombo()

        '画面クリア(取消動作)
        FunctionKey_Cancel()
    End Sub

    '登録/印刷
    Private Sub FunctionKey_EntryPrint()

        '入力チェック
        If fncAllInputValidate() = False Then Exit Sub

        'グリッド確定
        dbgMEISAI.UpdateData()

        'グリッドチェック
        If GridChecker() = False Then Exit Sub

        Me.LastFocusedControl.Focus()

        If Not MessageBoxEx.Show(CommonUtility.MessageCode_Arg0.M001登録してもよろしいですか, PROGRAM_NAME) = Windows.Forms.DialogResult.Yes Then Return

        '請求枝番の採番
        If Me.TitleBar.EditMode = EditMode.Create Then
            Dim seikyuEdaban = T_SEIKYU.fncSelectMAX_SEIKYUEDABAN(txtSeikyuNo.Text).Rows(0).Item("SEIKYUEDABAN")
            If NUCheck(seikyuEdaban) Then
                txtSeikyuEdaban.Text = "00"
            Else
                txtSeikyuEdaban.Text = ZeroPadding(seikyuEdaban + 1, txtSeikyuEdaban.MaxLength)
            End If
        End If

        '登録処理
        If dalogic.Entry(Me, Me.TitleBar.EditMode = EditMode.Edit) Then
            '印刷
            If MessageBoxEx.Show(MessageCode_Arg0.M162引き続き印刷してもよろしいですか, PROGRAM_NAME) = Windows.Forms.DialogResult.Yes Then
                ReportPrint(False)
            End If

            'コンボ再作成
            subInitCombo()

            '画面クリア(取消動作)
            FunctionKey_Cancel(False)
        End If
    End Sub

    Private Sub subGetParameter()
        '税率取得
        税率 = dalogic.ReadM_KBN_ZEIRITU(Decimal.Parse(txtSeikyuDate.Text.Replace("/", "")))
        If 税率 Is Nothing Then Throw New ApplicationException("税率が取得できません")
    End Sub

    'レポート印刷
    Private Sub ReportPrint(ByVal previewMode As Boolean)
        Dim dt As New dsSEI0001.ReportDataDataTable
        Dim dr As dsSEI0001.ReportDataRow = dt.NewReportDataRow

        'パラメータ取得
        subGetParameter()

        dr.SeikyuNo = ZeroPadding(txtSeikyuNo.Text, txtSeikyuNo.MaxLength) & "-" & ZeroPadding(txtSeikyuEdaban.Text, txtSeikyuEdaban.MaxLength)
        dr.SeikyuDate = GetCnvSW.SfncYearSW(txtSeikyuDate.Text, True, False)
        dr.TokuiName = txtKokyakuName.Text
        dr.SeikyuGaku = ReplaceCalcString(MainData.Rows(0)(FLD_今回請求額))
        dr.KoujiName = Utility.NS(lblInfo_KouziName.Text)
        dr.UkeoiGaku = ReplaceCalcString(MainData.Rows(0)(FLD_請負受注金額))
        dr.MadeJyuryoGaku = NZ(txtKonMadeJyuryoGaku.Value)
        dr.MadeSeikyuGaku = ReplaceCalcString(MainData.Rows(0)(FLD_今回迄請求額))
        dr.Biko = txtBiko.Text

        'scb
        dr.Isoqer = scb.ISO資格
        dr.JisyaName = scb.自社名称
        dr.Comment1 = scb.コメント１
        dr.YubinNo = scb.郵便番号
        dr.Address1 = scb.住所１ + scb.住所２     'アドレス１に出力するデータ全てセット
        dr.Address2 = scb.住所２
        dr.TelNo = scb.電話番号
        dr.FaxNo = scb.ＦＡＸ番号
        dr.Email = scb.メールアドレス
        dr.Web = scb.Webサイト
        dr.Kouza1 = scb.銀行口座１
        dr.Kouza2 = scb.銀行口座２
        dr.Kouza3 = scb.銀行口座３
        dr.KouzaMeigi = scb.口座名義
        dr.KouzaMeigiKana = scb.口座名義カナ

        dt.AddReportDataRow(dr)

        '明細の合計の計算
        Dim dtGoukei = CalcMeisaiGoueki(dtT_SEIKYU_MEISAI)

        Using rpt As New rptSEI0001(dt, txtKeisyoName.Text),
                rptMeisai As New rptSEI0001_1(rptMain0_1_DataCreate_MEISAI),
                rptDekidakaChosyo As New rptSEI0001_DekidakaTyousho(dtT_SEIKYU_MEISAI, txtSURYO_SYOSUIKAKETA.Text, dt, dtGoukei, strS_SCB_ROUND_ZEIKBN)
            'プレビュー
            If rdoSeikyuHouhou_0.Checked Then
                PrintReport(PrintReportMode.Preview, {rpt, rptMeisai}, previewMode)
            Else
                PrintReport(PrintReportMode.Preview, {rpt, rptMeisai, rptDekidakaChosyo}, previewMode)
            End If
        End Using
    End Sub

    Private Function fncCnvDecimal(ByVal val As Decimal) As String
        Return IIf(val < 0, "▲" + (val * -1).ToString, val.ToString)
    End Function

#Region "三煌産業明細表"
    Private Function rptMain0_1_DataCreate_MEISAI() As dsSEI0001.ReportData0_1DataTable
        '1頁20行
        Const MAXLINE As Short = 20
        Dim dt As New dsSEI0001.ReportData0_1DataTable
        Dim readRow As Integer = 0
        Dim page As Decimal = 1
        Dim dr As dsSEI0001.ReportData0_1Row
        Dim dt_Jyutyu As dsSEI0001.T_JYUTYUDataTable = Nothing
        Dim dt_JyutyuHed As dsSEI0001.T_JYUTYUHEDDataTable = Nothing

        Do
            For i As Integer = 1 To MAXLINE
                If Not readRow > MainData.Rows.Count - 1 Then
                    '受注トラン、ヘッダよりデータ抽出
                    dt_Jyutyu = dalogic.ReadT_JYUTYU(txtSeikyuNo.Text, txtJyutyuEdaban.Text).Copy
                    dt_JyutyuHed = dalogic.ReadT_JYUTYUHED(txtSeikyuNo.Text, txtJyutyuEdaban.Text).Copy

                    Dim PrintCount As Integer = 1   '帳票Ｎｏ印字用

                    For j As Integer = 0 To dt_Jyutyu.Rows.Count - 1

                        'ここで画面受注Ｎｏに対する受注トランデータの処理を行い、追加した行数分　ループカウンタiを加算する
                        If i = 1 Then
                            '１行目は項自明をセット
                            dr = dt.NewReportData0_1Row
                            dr.Page = page
                            dr.Gyo = ""
                            dr.Kousyu = ""
                            dr.Naiyo = "<" + lblInfo_KouziName.Text + ">"
                            dr.Suryo = ""
                            dr.Tani = ""
                            dr.Tanka = ""
                            dr.Kingaku = ""
                            dr.Tekiyou = ""
                            dr.Visible = True
                            dr.LineNumber = i.ToString

                            dt.AddReportData0_1Row(dr)
                            i += 1
                        End If

                        '２行目以降セット
                        dr = dt.NewReportData0_1Row
                        dr.Page = page
                        dr.Gyo = PrintCount.ToString
                        dr.Kousyu = NS(dt_Jyutyu.Rows(j)("KAMOKU_HINMOKU"))
                        dr.Naiyo = NS(dt_Jyutyu.Rows(j)("HINSITU_KIKAKU_SIYO"))
                        dr.Suryo = Format(NZ(dt_Jyutyu.Rows(j)("SUU")), "##0.###")
                        dr.Tani = NS(dt_Jyutyu.Rows(j)("TANI"))
                        dr.Tanka = IIf(NZ(dt_Jyutyu.Rows(j)("JYUTYUTANKA")) = 0, "", Format(NZ(dt_Jyutyu.Rows(j)("JYUTYUTANKA")), "###.###"))
                        dr.Kingaku = fncCnvDecimal(NZ(dt_Jyutyu.Rows(j)("JYUTYUGAKU")))
                        dr.Tekiyou = NS(dt_Jyutyu.Rows(j)("G_BIKO"))
                        dr.Visible = True
                        dr.LineNumber = i.ToString

                        dt.AddReportData0_1Row(dr)
                        i += 1
                        PrintCount += 1

                        If i > MAXLINE Then
                            i = 1
                            page += 1
                        End If
                    Next

                    'ヘッダデータ印字
                    For k As Integer = 0 To 2
                        If i = 1 Then
                            '１行目は項自明をセット
                            dr = dt.NewReportData0_1Row
                            dr.Page = page
                            dr.Gyo = ""
                            dr.Kousyu = ""
                            dr.Naiyo = "<" + lblInfo_KouziName.Text + ">"
                            dr.Suryo = ""
                            dr.Tani = ""
                            dr.Tanka = ""
                            dr.Kingaku = ""
                            dr.Tekiyou = ""
                            dr.Visible = True
                            dr.LineNumber = i.ToString

                            dt.AddReportData0_1Row(dr)
                            i += 1
                        End If

                        dr = dt.NewReportData0_1Row
                        dr.Page = page
                        dr.Gyo = PrintCount.ToString
                        dr.Naiyo = ""
                        dr.Suryo = ""
                        dr.Tani = ""
                        dr.Tanka = ""
                        dr.Tekiyou = ""
                        dr.Visible = True
                        dr.LineNumber = i.ToString

                        If k = 0 Then
                            '小計行
                            dr.Kousyu = "小計"
                            dr.Kingaku = fncCnvDecimal(NZ(dt_JyutyuHed.Rows(0)("GKJYUTYUGAKU_NUKI")))

                        ElseIf k = 1 Then
                            '消費税行

                            '基本設定マスタの取得
                            Dim S_SCB = New S_SCBRead("SYSTEM", "ZEIKBN")
                            Dim ds = S_SCB.GetS_SCB

                            If ds.Tables(0).Rows.Count <> 0 AndAlso ds.Tables(0).Rows(0).Item("DATA").ToString = "1" Then
                                '内税の場合
                                dr.Kousyu = "内消費税  " + 税率.ToString + "％"
                            Else
                                dr.Kousyu = "消費税  " + 税率.ToString + "％"
                                '上記以外の場合
                            End If
                            dr.Kingaku = fncCnvDecimal(NZ(dt_JyutyuHed.Rows(0)("GKTAX")))

                        ElseIf k = 2 Then
                            '合計行
                            dr.Kousyu = "合計"
                            dr.Kingaku = fncCnvDecimal(NZ(dt_JyutyuHed.Rows(0)("GKJYUTYUGAKU")))

                        End If

                        dt.AddReportData0_1Row(dr)

                        i += 1
                        PrintCount += 1

                        If i > MAXLINE AndAlso k <> 2 Then
                            i = 1
                            page += 1
                        End If
                    Next

                    'ヘッダ印字後は次頁まで空行挿入
                    For l As Integer = i To MAXLINE
                        dr = dt.NewReportData0_1Row
                        dr.Page = page
                        dr.Gyo = ""
                        dr.Kousyu = ""
                        dr.Naiyo = ""
                        dr.Suryo = ""
                        dr.Tani = ""
                        dr.Tanka = ""
                        dr.Kingaku = ""
                        dr.Tekiyou = ""
                        dr.Visible = False
                        dr.LineNumber = i.ToString

                        dt.AddReportData0_1Row(dr)
                        i += 1
                    Next

                    readRow += 1

                Else
                    dr = dt.NewReportData0_1Row
                    dr.Page = page
                    dr.Gyo = ""
                    dr.Kousyu = ""
                    dr.Naiyo = ""
                    dr.Suryo = ""
                    dr.Tani = ""
                    dr.Tanka = ""
                    dr.Kingaku = ""
                    dr.Tekiyou = ""
                    dr.Visible = False
                    dr.LineNumber = i.ToString

                    dt.AddReportData0_1Row(dr)
                    i += 1
                End If

                i -= 1 'For文での自動インクリメントはマイナス
            Next

            If readRow > MainData.Rows.Count - 1 Then Exit Do

            page += 1
        Loop While True

        Return dt
    End Function

#End Region

    '登録前にグリッド内容のチェックを行う
    Private Function GridChecker() As Boolean
        '未請求額0以下が存在(注意メッセージのみ表示 グリッドチェックはOK)
        If MainData.Select("MISEIKYUGAKU<0").Length > 0 Then
            MessageBoxEx.Show(MessageCode_Arg0.M173未請求額0以下のデータが存在します, PROGRAM_NAME)
        End If

        Return True
    End Function

    Public Function ReplaceCalcString(ByVal val As String) As Decimal
        Dim wk As String = val.Replace("円", "").Replace("％", "").Trim
        If IsNumeric(wk) = False Then Return 0
        Return Decimal.Parse(wk.Replace(",", ""))
    End Function


    ''' <summary>
    ''' グリッド設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub subInitGrid()

        With dbgMEISAI

            '***** 共通 *****
            With .Columns
                .Add(New C1DataColumn("請負(受注)金額", FLD_請負受注金額, Type.GetType("System.Decimal")))
                .Add(New C1DataColumn("今回迄請求額", FLD_今回迄請求額, Type.GetType("System.Decimal")))
                .Add(New C1DataColumn("出来高％", FLD_出来高, Type.GetType("System.Decimal")))
                .Add(New C1DataColumn("今回請求額", FLD_今回請求額, Type.GetType("System.Decimal")))
                .Add(New C1DataColumn("未請求額", FLD_未請求額, Type.GetType("System.Decimal")))
                .Add(New C1DataColumn("請求率", FLD_請求率, Type.GetType("System.Decimal")))
            End With

            '*** TrueDBGrid DataWidth プロパティ設定 ***
            .Columns(COL.出来高).DataWidth = 6
            .Columns(COL.今回請求額).DataWidth = 11

            .Columns(COL.請負受注金額).NumberFormat = "#,##0"
            .Columns(COL.今回迄請求額).NumberFormat = "#,##0"
            .Columns(COL.出来高).NumberFormat = "#,##0.00"
            .Columns(COL.今回請求額).NumberFormat = "#,##0"
            .Columns(COL.未請求額).NumberFormat = "#,##0"
            .Columns(COL.請求率).NumberFormat = "##0%"

            .RecordSelectors = False 'レコードセレクタ非表示（グリッド左側）

            With .Splits(0)
                '*** TrueDBGrid Width プロパティ設定 ***
                .DisplayColumns(COL.請負受注金額).Width = 12 * 8
                .DisplayColumns(COL.今回迄請求額).Width = 12 * 8
                .DisplayColumns(COL.出来高).Width = 8 * 8
                .DisplayColumns(COL.今回請求額).Width = 12 * 8
                .DisplayColumns(COL.未請求額).Width = 12 * 8
                .DisplayColumns(COL.請求率).Width = 8 * 8

                '*** TrueDBGrid AllowFocus プロパティ設定 ***
                .DisplayColumns(COL.請負受注金額).AllowFocus = False
                .DisplayColumns(COL.今回迄請求額).AllowFocus = False
                .DisplayColumns(COL.出来高).AllowFocus = True
                .DisplayColumns(COL.今回請求額).AllowFocus = True
                .DisplayColumns(COL.未請求額).AllowFocus = False
                .DisplayColumns(COL.請求率).AllowFocus = False

                For i As Integer = 0 To dbgMEISAI.Columns.Count - 1
                    .DisplayColumns(i).Visible = True
                Next
            End With

            '*** 共通設定 ***
            GridSetup(dbgMEISAI, GridSetupAllows.AllowAll, False, False, False)

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

            .ContextMenuStrip = New ContextMenuStrip

            'Splits 単位
            .Splits(0).HScrollBar.Style = ScrollBarStyleEnum.None
            .Splits(0).VScrollBar.Style = ScrollBarStyleEnum.None
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
                .Splits(0).DisplayColumns(intIndex).Style.HorizontalAlignment = AlignHorzEnum.General
            Next
            .Splits(0).DisplayColumns(COL.請負受注金額).Style.HorizontalAlignment = AlignHorzEnum.Far
            .Splits(0).DisplayColumns(COL.今回迄請求額).Style.HorizontalAlignment = AlignHorzEnum.Far
            .Splits(0).DisplayColumns(COL.出来高).Style.HorizontalAlignment = AlignHorzEnum.Far
            .Splits(0).DisplayColumns(COL.今回請求額).Style.HorizontalAlignment = AlignHorzEnum.Far
            .Splits(0).DisplayColumns(COL.未請求額).Style.HorizontalAlignment = AlignHorzEnum.Far
            .Splits(0).DisplayColumns(COL.請求率).Style.HorizontalAlignment = AlignHorzEnum.Far
        End With
    End Sub

    Private Sub dbgMEISAI_FetchCellStyle(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchCellStyleEventArgs) Handles dbgMEISAI.FetchCellStyle

        '背景色の変更
        e.CellStyle.BackColor = Color.White

        Select Case e.Col
            Case COL.請負受注金額, COL.今回迄請求額, COL.未請求額, COL.請求率
                e.CellStyle.BackColor = Color.FromArgb(236, 233, 216)
            Case COL.出来高, COL.今回請求額
                If rdoSeikyuHouhou_1.Checked Then
                    e.CellStyle.BackColor = Color.FromArgb(236, 233, 216)
                End If
        End Select
    End Sub

    Private Sub cmbSeikyuNo_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSeikyuNo.SelectionChangeCommitted
        txtSeikyuEdaban.Text = RightBSA(lblSEIKYUNO.Text, 2)

        Me.txtSeikyuEdaban_KeyDown(txtSeikyuEdaban, New KeyEventArgs(Keys.Enter))
    End Sub

    Private Sub txtSeikyuEdaban_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtSeikyuEdaban.KeyDown

        'エンターキー以外は処理しない
        If e.KeyCode <> Keys.Enter Then Return

        '入力チェック
        If fncAllInputValidate() = False Then Return

        '物件承認情報の取得
        Dim drApprovalJyuchu As dsT_BUKKEN_APPROVAL.T_BUKKEN_APPROVALRow = T_BUKKEN_APPROVAL.GetDataWhereGyomuKbn(txtSeikyuNo.Text, T_BUKKEN_APPROVALRead.enumGyomuKbn.Jyuchu).Rows(0)

        Dim formStatus = enumFormStatus.DetailInput

        If Not NUCheck(txtSeikyuEdaban.Text) Then
            'ヘッダ読み込み
            If Not ReadSeikyuHeaderSettingDisplay() Then
                MessageBoxEx.Show(CommonUtility.MessageCode_Arg0.M009該当データがありません, Me.Text)
                txtSeikyuEdaban.Focus()
                Return
            End If

            '参照モードの判定
            If CDec(txtSeikyuEdaban.Text) <> T_SEIKYU.fncSelectMAX_SEIKYUEDABAN(txtSeikyuNo.Text).Rows(0).Item("SEIKYUEDABAN") Then
                '最後の請求ではない場合
                formStatus = enumFormStatus.Reference
                Me.TitleBar.EditMode = EditMode.EditNoneSeikyu
            ElseIf drApprovalJyuchu.APPROVALKBN = T_BUKKEN_APPROVALRead.enumApprovalKbn.SYONIN_MI Then
                '受注未承認の場合
                formStatus = enumFormStatus.Reference
                Me.TitleBar.EditMode = EditMode.EditNoneJyutyuMisyonin
            Else
                formStatus = enumFormStatus.DetailInput
                Me.TitleBar.EditMode = EditMode.Edit
            End If

            txtSeikyuEdaban.Text = ZeroPadding(txtSeikyuEdaban.Text, txtSeikyuEdaban.MaxLength)

        Else
            '受注承認済のチェック
            If drApprovalJyuchu.APPROVALKBN = T_BUKKEN_APPROVALRead.enumApprovalKbn.SYONIN_MI Then
                MessageBoxEx.Show(CommonUtility.MessageCode_Arg0.M236, Me.Text)
                Return
            End If

            '請求情報の取得
            Dim seikyuEdaban = T_SEIKYU.fncSelectMAX_SEIKYUEDABAN(txtSeikyuNo.Text).Rows(0).Item("SEIKYUEDABAN")

            If Not NUCheck(seikyuEdaban) Then
                Dim dt = T_SEIKYU.fncSelectT_SEIKYUHED(txtSeikyuNo.Text, seikyuEdaban)
                Dim dr = CType(dt.Rows(0), dsT_SEIKYU.T_SEIKYUHEDRow)
                If dr.SEIKYUMETHOD = "1" Then
                    rdoSeikyuHouhou_0.Checked = True
                Else
                    rdoSeikyuHouhou_1.Checked = True
                End If
            End If

            '最大の受注枝番の取得
            txtJyutyuEdaban.Text = T_JYUTYU.fncSelectMAX_JYUTYUEDABAN(txtSeikyuNo.Text).Rows(0).Item("JYUTYUEDABAN")

            '受注情報の表示
            subSetKouziInfo()

            Me.TitleBar.EditMode = EditMode.Create
        End If

        'フォームステータス変更
        FormSwitch(formStatus)

        '請求トランの読み込み
        ReadSeikyuData()

        '請求明細トランの読み込み
        ReadSeikyuMeisaiData()

        'カーソルを請求日付
        txtSeikyuDate.Focus()

        '前回請求日付として保存
        m_変更前請求日付 = Date.Parse(txtSeikyuDate.Text)
    End Sub

    '請求トラン、受注ヘッダトランよりデータ取得
    Private Sub ReadSeikyuData()
        '明細データの読み込み
        '新規の場合、請求NOは0を引数に渡す
        MainData = dalogic.ReadMainData(
              txtSeikyuNo.Text _
            , IIf(NUCheck(txtJyutyuEdaban.Text), 0, txtJyutyuEdaban.Text) _
            , IIf(NUCheck(txtSeikyuEdaban.Text), 0, txtSeikyuNo.Text) _
            , IIf(NUCheck(txtSeikyuEdaban.Text), 0, txtSeikyuEdaban.Text) _
            , CDate(txtSeikyuDate.Text))

        Dim dr = CType(MainData.Rows(0), dsSEI0001.MainDataRow)

        If rdoSeikyuHouhou_0.Checked Then
            If Me.TitleBar.EditMode = EditMode.Create Then
                dr.SEIKYUGAKU = dr.MISEIKYUGAKU
                dr.MISEIKYUGAKU = 0
            End If
        End If

        If dr.GKJYUTYUGAKU = 0 Then
            dr.SEIKYURITU = 1
        Else
            dr.SEIKYURITU = Round(
                              ((dr.MADESEIKYUGAKU + dr.SEIKYUGAKU) / dr.GKJYUTYUGAKU) _
                            , 3 _
                            , 請求率丸め区分)
        End If

        dbgMEISAI.SetDataBinding(MainData, "", True)
        dbgMEISAI.Refresh()
    End Sub

    Private Sub ReadSeikyuMeisaiData()

        '前回の請求で請求方法に「出来高％、今回請求額を指定」を選択した場合、取得しない
        If rdoSeikyuHouhou_0.Enabled = False And rdoSeikyuHouhou_0.Checked Then Return

        '請求明細トランの読み込み
        If TitleBar.EditMode = EditMode.Create _
                OrElse rdoSeikyuHouhou_0.Enabled = True And rdoSeikyuHouhou_0.Checked Then
            '新規モード、もしくは、「１件目の請求かつ、請求方法に「出来高％、今回請求額を指定」を選択した場合

            '１つ前の請求枝番、受注枝番の取得
            Dim seikyuEdabanMax = T_SEIKYU.fncSelectMAX_SEIKYUEDABAN(txtSeikyuNo.Text).Rows(0).Item("SEIKYUEDABAN")

            Dim seikyuEdaban = -1
            Dim jyutyuEdaban = -1
            If Not NUCheck(seikyuEdabanMax) Then
                seikyuEdaban = CDec(seikyuEdabanMax)

                '請求情報の受注枝番の取得
                Dim dtSeikyu = T_SEIKYU.fncSelectT_SEIKYUHED(txtSeikyuNo.Text, seikyuEdaban)
                Dim drSeikyu = CType(dtSeikyu.Rows(0), dsT_SEIKYU.T_SEIKYUHEDRow)
                jyutyuEdaban = drSeikyu.JYUTYUEDABAN
            End If

            dtT_SEIKYU_MEISAI = dalogic.ReadT_SEIKYU_MEISAI_JYUTYU(
                  txtSeikyuNo.Text _
                , seikyuEdaban _
                , txtJyutyuEdaban.Text _
                , jyutyuEdaban)

            If rdoSeikyuHouhou_1.Checked Then
                '該当データなしのエラーの後だと、グリッドの編集でEnterイベントが発生し、請求日付のチェック処理が走るので、イベントを削除する。
                RemoveHandler dbgMEISAI.Enter, AddressOf EnterEventHandler

                '請求額の設定（削除した受注明細は請求額がマイナスで設定されている）
                Dim dr = CType(dbgMEISAI.DataSource(0), dsSEI0001.MainDataRow)
                dr.SEIKYUGAKU = dtT_SEIKYU_MEISAI.Compute("SUM(SEIKYUGAKU_KONKAI)", "")
                dr.MISEIKYUGAKU = dr.GKJYUTYUGAKU - dr.SEIKYUGAKU
                If dr.GKJYUTYUGAKU = 0 Then
                    dr.SEIKYURITU = 1
                Else
                    dr.SEIKYURITU = Round(
                                      ((dr.MADESEIKYUGAKU + dr.SEIKYUGAKU) / dr.GKJYUTYUGAKU) _
                                    , 3 _
                                    , 請求率丸め区分)
                End If

                AddHandler dbgMEISAI.Enter, AddressOf EnterEventHandler
            End If

        Else
            '更新モードの場合
            dtT_SEIKYU_MEISAI = dalogic.ReadT_SEIKYU_MEISAI(
                  txtSeikyuNo.Text _
                , txtSeikyuEdaban.Text)
        End If
    End Sub

    '請求ヘッダ情報を画面に表示
    Private Function ReadSeikyuHeaderSettingDisplay() As Boolean
        Dim dt = T_SEIKYU.fncSelectT_SEIKYUHED(txtSeikyuNo.Text, txtSeikyuEdaban.Text)

        If dt.Rows.Count = 0 Then Return False

        Dim dr = CType(dt.Rows(0), dsT_SEIKYU.T_SEIKYUHEDRow)

        txtJyutyuEdaban.Text = dr.JYUTYUEDABAN
        txtSURYO_SYOSUIKAKETA.Text = dr.SURYO_SYOSUIKAKETA
        txtSeikyuDate.Text = dr.SEIKYUDATE
        txtSeikyuDateDisp.Text = fncCnvJapaneseDate(txtSeikyuDate.Text)
        txtKeisyo.Text = dr.KEISYOUCODE
        txtBiko.Text = dr.D_BIKO
        txtKonMadeJyuryoGaku.Value = NZ(dr.KONJYURYOKINGAKU)
        lblTANTOCODE.Text = NS(dr.INP_TANTOCODE)
        lblTANTONAME.Text = BLL.Common.GetDbValue.ExecuteGetValue("M_TANTO", "TANTONAME", "TANTOCODE='" + NS(dt.Rows(0)("INP_TANTOCODE")) + "'")
        rdoSeikyuHouhou_0.Checked = False
        rdoSeikyuHouhou_1.Checked = False
        If dr.SEIKYUMETHOD = "1" Then
            rdoSeikyuHouhou_0.Checked = True
        Else
            rdoSeikyuHouhou_1.Checked = True
        End If

        '請求ヘッダ読み込み時にデータを訂正前データを保持
        訂正前請求ヘッダ = dt.Copy.Rows(0)

        '受注情報の表示
        subSetKouziInfo()

        Return True
    End Function

    Private Sub subReadJisyaInfo(ByRef p As ReportData)
        Dim data As ReportData = New ReportData

        p = New ReportData

        Const category As String = "INFO_JISYA"

        With p
            .ISO資格 = dalogic.ReadS_SCB(category, "ISOQAR")
            .自社名称 = dalogic.ReadS_SCB(category, "JISYANAME")
            .コメント１ = dalogic.ReadS_SCB(category, "COMMENT1")
            .郵便番号 = dalogic.ReadS_SCB(category, "POSTNO")
            .住所１ = dalogic.ReadS_SCB(category, "ADDRESS1")
            .住所２ = dalogic.ReadS_SCB(category, "ADDRESS2")
            .電話番号 = dalogic.ReadS_SCB(category, "TELNO")
            .ＦＡＸ番号 = dalogic.ReadS_SCB(category, "FAXNO")
            .メールアドレス = dalogic.ReadS_SCB(category, "EMAIL")
            .Webサイト = dalogic.ReadS_SCB(category, "WEB")
            .銀行口座１ = dalogic.ReadS_SCB(category, "BANKKOZANO1")
            .銀行口座２ = dalogic.ReadS_SCB(category, "BANKKOZANO2")
            .銀行口座３ = dalogic.ReadS_SCB(category, "BANKKOZANO3")
            .口座名義 = dalogic.ReadS_SCB(category, "BANKKOZAMEIGI")
            .口座名義カナ = dalogic.ReadS_SCB(category, "BANKKOZAKANA")
        End With
    End Sub

    Private Sub dbgMEISAI_Leave(sender As Object, e As EventArgs) Handles dbgMEISAI.Leave
        dbgMEISAI_BeforeColUpdate(Nothing, Nothing)
    End Sub

    Private Sub dbgMEISAI_BeforeColUpdate(ByVal sender As Object, ByVal e As BeforeColUpdateEventArgs) Handles dbgMEISAI.BeforeColUpdate
        If dbgMEISAI.DataSource Is Nothing Then Return

        With dbgMEISAI

            Select Case .Col

                Case COL.出来高

                    If IsNumeric(.Columns(.Col).Value) = False Then
                        .Columns(.Col).Value = 0
                    End If

                    '1000%以上はＮＧ
                    If .Columns(.Col).Value >= 1000 Then
                        MessageBoxEx.Show(MessageCode_Arg1.M016の入力範囲を確認して下さい, "出来高％", PROGRAM_NAME)
                        e.Cancel = True
                        Return
                    End If

                    If .Columns(.Col).Value = 0 Then
                        .Columns(COL.今回請求額).Value = 0
                    Else
                        .Columns(COL.今回請求額).Value = Round(.Columns(COL.請負受注金額).Value * (.Columns(.Col).Value / 100), 1, 出来高率丸め区分)
                    End If

                    .Columns(COL.未請求額).Value = .Columns(COL.請負受注金額).Value - (.Columns(COL.今回迄請求額).Value + .Columns(COL.今回請求額).Value)

                    .Columns(COL.請求率).Value = Round(
                          ((.Columns(COL.今回迄請求額).Value + .Columns(COL.今回請求額).Value) / .Columns(COL.請負受注金額).Value) _
                        , 3 _
                        , 請求率丸め区分)

                Case COL.今回請求額

                    If IsNumeric(.Columns(.Col).Value) = False Then
                        .Columns(.Col).Value = 0
                    End If

                    .Columns(COL.未請求額).Value = .Columns(COL.請負受注金額).Value - (.Columns(COL.今回迄請求額).Value + .Columns(.Col).Value)

                    .Columns(COL.請求率).Value = Round(
                          ((.Columns(COL.今回迄請求額).Value + .Columns(COL.今回請求額).Value) / .Columns(COL.請負受注金額).Value) _
                        , 3 _
                        , 請求率丸め区分)

                    '請求率＝100％なのに未請求額がある場合、100％にしな。
                    If .Columns(COL.請求率).Value = 1 Then
                        If .Columns(COL.未請求額).Value > 0 Then .Columns(COL.請求率).Value = 0.99
                    End If
            End Select
        End With
    End Sub

    Private Function fncCnvJapaneseDate(ByVal str As String, Optional ByVal Kakko As Boolean = True) As String

        If IsDate(str) = False Then Return ""

        Return BLL.Common.GetCnvSW.SfncYearSW(str, True)
    End Function

    Private Sub dbgMEISAI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dbgMEISAI.KeyDown
        If (e.Shift = False AndAlso e.KeyCode = Keys.Tab) OrElse e.KeyCode = Keys.Enter Then
            If dbgMEISAI.Col = COL.今回請求額 Then
                txtKonMadeJyuryoGaku.Focus()
            End If
        End If

        If e.Shift = True AndAlso (e.KeyCode = Keys.Tab OrElse e.KeyCode = Keys.Enter) Then
            If dbgMEISAI.Col = COL.出来高 Then
                txtKeisyo.Focus()
            End If
        End If
    End Sub

    Private Sub dbgMEISAI_RowColChange(ByVal sender As Object, ByVal e As RowColChangeEventArgs) Handles dbgMEISAI.RowColChange
        With dbgMEISAI
            Select Case .Col
                Case COL.今回請求額
                    .ImeMode = Windows.Forms.ImeMode.Disable
            End Select

            For Each ctrl As Control In .Controls
                If TypeOf ctrl Is TextBox Then
                    ctrl.ImeMode = .ImeMode
                End If
            Next
        End With
    End Sub

    Private Sub subSetKouziInfo()
        '受注情報の取得
        Dim drJyutyu = CType(T_JYUTYU.fncSelectT_JYUTYUHED(txtSeikyuNo.Text, txtJyutyuEdaban.Text).Rows(0), dsT_JYUTYU.T_JYUTYUHEDRow)

        txtSURYO_SYOSUIKAKETA.Text = drJyutyu.SURYO_SYOSUIKAKETA
        lblInfo_JyutyuNo.Text = drJyutyu.JYUTYUNO_EDABAN
        lblInfo_JyutyuDate.Text = drJyutyu.JYUTYUDATE
        lblInfo_MitumoriNo.Text = drJyutyu.MITUMORINO_EDABAN
        lblInfo_Tanto.Text = drJyutyu.TANTONAME
        lblInfo_Kokyaku.Text = drJyutyu.TOKUINAME
        lblInfo_KouziName.Text = drJyutyu.KOUJINAME
        lblInfo_KouziNumber.Text = drJyutyu.KOUJINO
        lblInfo_KouziBasyo.Text = drJyutyu.KOUJIBASYO
        lblInfo_Nouki1.Text = drJyutyu.NOUKI_STA + " (" + GetCnvSW.SfncYearSW(drJyutyu.NOUKI_STA, True, True) + ") ～" _
                            + drJyutyu.NOUKI_END + " (" + GetCnvSW.SfncYearSW(drJyutyu.NOUKI_END, True, True) + ")"
        lblInfo_Syokei.Text = NZ(drJyutyu.GKJYUTYUGAKU_NUKI).ToString("#,0") + " 円"
        lblInfo_Syohizei.Text = NZ(drJyutyu.GKTAX).ToString("#,0") + " 円"
        lblInfo_JyutyuKingaku.Text = NZ(drJyutyu.GKJYUTYUGAKU).ToString("#,0") + " 円"
    End Sub

    Private Sub subReGetMadeSeikyuGaku(ByVal SeikyuDate As Date)
        If MainData Is Nothing OrElse MainData.Rows.Count = 0 Then Exit Sub

        Dim dt As dsSEI0001.GetMadeSeikyuGakuDataTable = dalogic.ReadMadeSeikyuGaku(CDec(txtSeikyuNo.Text), SeikyuDate)

        If dt.Rows.Count = 0 OrElse NUCheck(dt.Rows(0)("MADESEIKYUGAKU")) Then
            '今回迄請求額なし
            MainData.Rows(0)(FLD_今回迄請求額) = Decimal.Parse("0")
        Else
            MainData.Rows(0)(FLD_今回迄請求額) = Decimal.Parse(dt.Rows(0)("MADESEIKYUGAKU").ToString)
        End If

        MainData.Rows(0)(FLD_未請求額) = MainData.Rows(0)(FLD_請負受注金額) - (MainData.Rows(0)(FLD_今回迄請求額) + MainData.Rows(0)(FLD_今回請求額))

        With dbgMEISAI
            .Columns(COL.請求率).Value = Round(
                  ((.Columns(COL.今回迄請求額).Value + .Columns(COL.今回請求額).Value) / .Columns(COL.請負受注金額).Value) _
                , 3 _
                , 請求率丸め区分)
        End With

        '再バインド
        dbgMEISAI.SetDataBinding(MainData, "", True)
    End Sub

    Private Sub txtSeikyuDate_TextUpdated(ByVal sender As Object, ByVal e As System.EventArgs)
        'TextUpdatedはイベントが発生しないタイミングがあるため、TextChangedで代用(ステップ数多くなりますが、気にならない程度)
        txtSeikyuDateDisp.Text = GetCnvSW.SfncYearSW(txtSeikyuDate.Text, True, True)

        If m_変更前請求日付 Is Nothing Then Exit Sub

        If IsDate(txtSeikyuDate.Text) = False Then Exit Sub

        If Not m_変更前請求日付 = Date.Parse(txtSeikyuDate.Text) Then
            dbgMEISAI.UpdateData()

            subReGetMadeSeikyuGaku(Date.Parse(txtSeikyuDate.Text))

            m_変更前請求日付 = Date.Parse(txtSeikyuDate.Text)
        End If
    End Sub

    Public Function GetServerDate() As Date
        Return ServerDate
    End Function

    Public Function GetLoginTantoCode() As String
        Return lblTANTOCODE.Text
    End Function

    Private Sub txtBiko_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBiko.KeyDown
        'キーコードチェック
        If Not (e.KeyCode = Keys.Enter OrElse e.KeyCode = Keys.Tab) Then Exit Sub

        txtSeikyuDate.Focus()
    End Sub

    Private Sub rdoSeikyuHouhou_CheckedChanged(sender As Object, e As EventArgs)

        btnMeisaiInput.Enabled = IIf(rdoSeikyuHouhou_0.Checked, False, True)
        dbgMEISAI.Enabled = IIf(rdoSeikyuHouhou_0.Checked, True, False)
        '背景色の変更（FetchCellStyleイベント）の呼び出し
        dbgMEISAI.Refresh()

        'チェックされない場合、明細の表示は不要（イベントではチェックOFFも呼び出されるので、ON時のみの処理する）
        If sender Is Nothing OrElse CType(sender, RadioButton).Checked = False Then Return

        If dbgMEISAI.DataSource Is Nothing Then Return

        '入力した値を保持
        If rdoSeikyuHouhou_1.Checked Then
            dbgMEISAI.Update()
            Dim dr As dsSEI0001.MainDataRow = CType(dbgMEISAI.DataSource, DataTable).Rows(0)
            SeikyuMethod0_dekidaka = dr.DEKIDAKA
            SeikyuMethod0_seikyugaku = dr.SEIKYUGAKU
            SeikyuMethod0_miseikyugaku = dr.MISEIKYUGAKU
            SeikyuMethod0_seikyuritu = dr.SEIKYURITU

            dr.DEKIDAKA = SeikyuMethod1_dekidaka
            dr.SEIKYUGAKU = SeikyuMethod1_seikyugaku
            dr.MISEIKYUGAKU = SeikyuMethod1_miseikyugaku
            dr.SEIKYURITU = SeikyuMethod1_seikyuritu
        Else
            dbgMEISAI.Update()
            Dim dr As dsSEI0001.MainDataRow = CType(dbgMEISAI.DataSource, DataTable).Rows(0)
            SeikyuMethod1_dekidaka = dr.DEKIDAKA
            SeikyuMethod1_seikyugaku = dr.SEIKYUGAKU
            SeikyuMethod1_miseikyugaku = dr.MISEIKYUGAKU
            SeikyuMethod1_seikyuritu = dr.SEIKYURITU

            dr.DEKIDAKA = SeikyuMethod0_dekidaka
            dr.SEIKYUGAKU = SeikyuMethod0_seikyugaku
            dr.MISEIKYUGAKU = SeikyuMethod0_miseikyugaku
            dr.SEIKYURITU = SeikyuMethod0_seikyuritu
        End If
    End Sub

    Private Sub btnMeisaiInput_Click(sender As Object, e As EventArgs) Handles btnMeisaiInput.Click
        Dim f As New frmSEI0001_Meisai(TitleBar.EditMode, Me, dtT_SEIKYU_MEISAI)
        f.Owner = Me
        f.ShowDispDialog(Me)
    End Sub

    Public Sub SEI0001_Meisai_return(ByVal MeisaiInputResult As String)
        '戻り値による編集処理
        Dim dr = CType(MainData.Rows(0), dsSEI0001.MainDataRow)
        dr.SEIKYUGAKU = CDec(MeisaiInputResult)
        dr.MISEIKYUGAKU = dr.GKJYUTYUGAKU - dr.SEIKYUGAKU - dr.MADESEIKYUGAKU
        If dr.GKJYUTYUGAKU = 0 Then
            dr.SEIKYURITU = 1
        Else
            dr.SEIKYURITU = Round(
                              ((dr.MADESEIKYUGAKU + dr.SEIKYUGAKU) / dr.GKJYUTYUGAKU) _
                            , 3 _
                            , 請求率丸め区分)
        End If
    End Sub

    Public Function CalcMeisaiGoueki(dt As dsSEI0001.T_SEIKYU_MEISAIDataTable) As dsSEI0001.T_SEIKYU_MEISAIDataTable
        Dim dtResult As New dsSEI0001.T_SEIKYU_MEISAIDataTable
        Dim syokei As Decimal = 0
        Dim syokeiZenaki As Decimal = 0
        Dim syokeiKonkai As Decimal = 0
        Dim syokeiRuikei As Decimal = 0

        If dt Is Nothing Then Return dtResult

        '小計の算出
        For Each row In dt
            '調整額は今回請求額、累計請求額のみ加算
            If row.KAISOCODE = "0" Then
                syokeiKonkai += row.SEIKYUGAKU_KONKAI
                syokeiRuikei += row.SEIKYUGAKU_RUIKEI
                Continue For
            End If

            syokei += row.JYUTYUGAKU
            syokeiZenaki += row.SEIKYUGAKU_ZENKAI
            syokeiKonkai += row.SEIKYUGAKU_KONKAI
            syokeiRuikei += row.SEIKYUGAKU_RUIKEI
        Next

        Dim dr As dsSEI0001.T_SEIKYU_MEISAIRow = dtResult.NewRow
        dr.JYUTYUGAKU = syokei
        dr.SEIKYUGAKU_ZENKAI = syokeiZenaki
        dr.SEIKYUGAKU_KONKAI = syokeiKonkai
        dr.SEIKYUGAKU_RUIKEI = syokeiRuikei
        dtResult.Rows.Add(dr)

        '外税以外の場合、消費税、合計は返却しない
        If strS_SCB_ROUND_ZEIKBN <> "0" Then Return dtResult

        '消費税の算出
        Dim syohizei As Decimal = CalcSyohizei(syokei)
        Dim syohizeiZenaki As Decimal = CalcSyohizei(syokeiZenaki)
        Dim syohizeiKonkai As Decimal = CalcSyohizei(syokeiKonkai)
        Dim syohizeiRuikei As Decimal = CalcSyohizei(syokeiRuikei)

        '合計の算出
        Dim goukei As Decimal = syokei + syohizei
        Dim goukeiZenaki As Decimal = syokeiZenaki + syohizeiZenaki
        Dim goukeiKonkai As Decimal = syokeiKonkai + syohizeiKonkai
        Dim goukeiRuikei As Decimal = syokeiRuikei + syohizeiRuikei

        dr = dtResult.NewRow
        dr.JYUTYUGAKU = syohizei
        dr.SEIKYUGAKU_ZENKAI = syohizeiZenaki
        dr.SEIKYUGAKU_KONKAI = syohizeiKonkai
        dr.SEIKYUGAKU_RUIKEI = syohizeiRuikei
        dtResult.Rows.Add(dr)

        dr = dtResult.NewRow
        dr.JYUTYUGAKU = goukei
        dr.SEIKYUGAKU_ZENKAI = goukeiZenaki
        dr.SEIKYUGAKU_KONKAI = goukeiKonkai
        dr.SEIKYUGAKU_RUIKEI = goukeiRuikei
        dtResult.Rows.Add(dr)

        Return dtResult
    End Function

    Private Function CalcSyohizei(ByVal value As Decimal) As Decimal
        If value = 0 Then Return 0

        Return Utility.Round(CDec(value * (CDbl(strSyohiZeiritu) / 100)), 0, CInt(strS_SCB_ROUND_TAX))
    End Function
End Class
