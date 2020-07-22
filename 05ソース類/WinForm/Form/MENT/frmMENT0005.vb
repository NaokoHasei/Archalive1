Imports CommonUtility.WinForm
Imports CommonUtility.Utility
Imports BLL.Common

Public Class frmMENT0005

    Public Overrides Function PROGRAM_ID() As String
        Return "MENT0005"
    End Function

    Public Overrides Function PROGRAM_NAME() As String
        Return "元請マスタ登録"
    End Function

    Private Enum enumFormStatus
        キー入力
        明細入力
    End Enum

    Friend Enum enum更新種別
        新規編集
        削除
    End Enum

    Private blnUpdateFlg As Boolean                 '更新フラグ
    Private blnUpdateFlg_TTNAME As Boolean          '更新フラグ(得意先単価名称マスタ)
    Private blnUpdateFlg_TANKACODE As Boolean       '更新フラグ(単価コード) 
    Private blnPostChkFlg As Boolean                '郵便番号マスタチェック済フラグ
    Private blnTellChkFlg As Boolean                '電話番号マスタチェック済フラグ
    Private blnFAXChkFlg As Boolean                 'FAX番号マスタチェック済フラグ
    Private strCmdL As String                       '得意先コードコマンドライン引数  
    Private blnCopy As Boolean                      'コピーフラグ

    Private dtCopy As New dsMENT0005.M_TOKUI_COPYDataTable  'コピー用

    Public Enum 起動種別
        通常起動 = 0
        入力系呼び出し起動 = 1
    End Enum
    Private _起動パラメーター As 起動種別
    Private _ReturnTOKUICODE As String
    Private _ReturnTOKUINAME As String

    Public Property 起動パラメーター() As 起動種別
        Get
            Return _起動パラメーター
        End Get
        Set(ByVal value As 起動種別)
            _起動パラメーター = value
        End Set
    End Property
    Public ReadOnly Property ReturnTOKUICODE() As String
        Get
            Return _ReturnTOKUICODE
        End Get
    End Property
    Public ReadOnly Property ReturnTOKUINAME() As String
        Get
            Return _ReturnTOKUINAME
        End Get
    End Property

    Private CodeNumbering As New CodeNumbering

    Protected Overrides Sub Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MyBase.Form_Load(sender, e)

        Using wcur As New WaitCursor

            コンボボックス初期化()

            画面設定(enumFormStatus.キー入力)

            txtTokuiCode.Text = ""

            blnCopy = False

            strCmdL = Trim(Command())

            イベント設定()

            If _起動パラメーター = 起動種別.入力系呼び出し起動 Then
                txtTokuiCode_PressEnter(txtTokuiCode, Nothing)
            End If

        End Using

    End Sub

    Private Sub 画面設定(ByVal FormStatus As enumFormStatus)
        FormSwitch(FormStatus)

        ファンクションキー設定(FormStatus)
    End Sub

    ''' <summary>
    ''' フォーム切替
    ''' </summary>
    ''' <param name="FormStatus"></param>
    ''' <remarks></remarks>
    Private Sub FormSwitch(ByVal FormStatus As enumFormStatus, Optional ByVal dsTOKUI As dsM_TOKUI.M_TOKUIDataTable = Nothing)

        Select Case FormStatus
            Case enumFormStatus.キー入力
                '入力項目初期化
                FormInputItem(enumFormStatus.キー入力)

                'コントロール使用可・不可
                txtTokuiCode.Enabled = True
                fraMeisai.Enabled = False

                blnUpdateFlg = True
                blnUpdateFlg_TTNAME = True  '得意先単価名称マスタ
                blnUpdateFlg_TANKACODE = True

                lblKakeInfo.Visible = False

                txtTokuiCode.Focus()

            Case enumFormStatus.明細入力

                '入力項目初期化
                FormInputItem(enumFormStatus.明細入力, dsTOKUI)

                'コントロール使用可・不可
                txtTokuiCode.Enabled = False
                fraMeisai.Enabled = True

                '修正フラグ
                blnUpdateFlg = False
                blnUpdateFlg_TTNAME = False
                blnUpdateFlg_TANKACODE = False
                'マスタチェック済フラグ
                blnPostChkFlg = True
                blnTellChkFlg = True
                blnFAXChkFlg = True

                If TitleBar.EditMode = CommonUtility.WinFormControls.EditMode.Create Then
                    '新規登録
                    '削除キー使用不可
                    FunctionKey.SetItem(3, "削除", "削除", False)
                Else
                    '編集/削除
                    FunctionKey.SetItem(3, "削除", "削除", True)
                End If
                FunctionKey.SetItem(1, "取消", "取消", True)
                FunctionKey.SetItem(10, "コピー", "コピー", True)
                If blnCopy = True Then
                    FunctionKey.SetItem(11, "貼付", "貼付", True)
                Else
                    FunctionKey.SetItem(11, "貼付", "貼付", False)
                End If
                FunctionKey.SetItem(12, "登録", "登録", True)

                txtTokuiName.Focus()
        End Select

        '更新フラグ
        blnUpdateFlg = False

    End Sub

    ''' <summary>
    ''' 入力項目初期化
    ''' </summary>
    ''' <param name="FormStatus">フォーム状態</param>
    ''' <param name="dsTOKUI">得意先マスタデータセット</param>
    ''' <remarks></remarks>
    Private Sub FormInputItem(ByVal FormStatus As enumFormStatus, Optional ByVal dsTOKUI As dsM_TOKUI.M_TOKUIDataTable = Nothing)
        Dim strTOKUICODE As String
        Dim i As Integer

        strTOKUICODE = txtTokuiCode.Text

        Select Case FormStatus
            Case enumFormStatus.キー入力

                TitleBar.EditMode = CommonUtility.WinFormControls.EditMode.None

                '初期値セット
                txtTokuiName.Text = ""
                txtRYAKUNAME.Text = ""
                txtMENUKEY.Text = ""
                txtPostNo.Text = ""
                txtADDRESS.Text = ""
                txtADDRESS1.Text = ""
                txtADDRESS2.Text = ""
                txtTELNO.Text = ""
                txtFAXNO.Text = ""
                txtGINKOU.Text = ""
                txtKOUZA.Text = ""
                txtTANKACODE.Text = ""
                txtTANKANAME.Text = ""
                txtSeikyuCode.Text = ""
                txtSeikyuName.Text = ""
                txtOROSIKBN.Text = "0"
                txtTANTOCODE.Text = CommonUtility.Utility.ZeroPadding(Me.NowUserInfo.TANTOCODE, 4)
                For i = 0 To 2
                    txtSIMEBI(i).Text = "0"
                    txtNyukinKbn(i).Text = "0"
                    txtSyuuKin(i).Text = "0"
                Next i
                txtZEIROUND.Text = "0"
                txtSUROUND.Text = "0"
                txtKINROUND.Text = "0"
                txtSYOHIZEIKBN.Text = "0"
                txtKEISYOUCODE.Text = ""
                txtKEISYOUNAME.Text = ""
                txtZANKANRIKBN.Text = "1"
                txtTankaKakikaeKbn.Text = "1"
                txtZEIKBN.Text = "0"
                txtZANINJIKBN.Text = "0"
                txtDenpyoSyuKbn.Text = "0"
                txtDenpyoSyuKbnName.Text = ""
                txtSeikyuKbn.Text = "0"
                txtSeikyuKbnName.Text = ""
                txtENDURIDATE.Text = dtMENT0005.MENT0005.DEFAULTDATE
                txtAITE_BUSYONAME.Text = ""
                txtAITE_TANTONAME.Text = ""
                txtSIHARAIBI.Text = "0"
                txtSIHARAI_GENKINRITU.Text = "0"
                txtSIHARAI_TEGATARITU.Text = "0"
                txtSITE.Text = "0"

                '非表示項目
                For i = 0 To 11
                    txtYOSAN(i).Text = "0"
                Next i

            Case enumFormStatus.明細入力

                Select Case dsTOKUI Is Nothing
                    Case True
                        '新規登録
                        TitleBar.EditMode = CommonUtility.WinFormControls.EditMode.Create

                        '請求先コード(得意先コードセット)
                        txtSeikyuCode.Text = txtTokuiCode.Text

                        '単価コード(得意先コードセット)
                        txtTANKACODE.Text = txtTokuiCode.Text    '残高印字区分

                    Case False
                        '編集/削除
                        TitleBar.EditMode = CommonUtility.WinFormControls.EditMode.Edit

                        With dsTOKUI.Rows(0)
                            'ヘッダー
                            txtTokuiName.Text = .Item("TOKUINAME").ToString
                            txtRYAKUNAME.Text = .Item("RYAKUNAME").ToString
                            txtMENUKEY.Text = .Item("MENUKEY").ToString
                            txtPostNo.Text = .Item("POSTNO").ToString
                            txtADDRESS.Text = .Item("ADDRESS").ToString
                            txtADDRESS1.Text = .Item("ADDRESS1").ToString
                            txtADDRESS2.Text = .Item("ADDRESS2").ToString
                            txtTELNO.Text = .Item("TELNO").ToString
                            txtFAXNO.Text = .Item("FAXNO").ToString
                            txtGINKOU.Text = .Item("GINKOU").ToString
                            txtKOUZA.Text = .Item("KOUZA").ToString
                            txtTANKACODE.Text = .Item("TANKACODE").ToString
                            txtSeikyuCode.Text = .Item("SEIKYUCODE").ToString
                            txtOROSIKBN.Text = .Item("YOSAN01").ToString
                            txtTANTOCODE.Text = .Item("TANTOCODE").ToString
                            txtSIMEBI(0).Text = .Item("SIMEBI1").ToString
                            txtSIMEBI(1).Text = .Item("SIMEBI2").ToString
                            txtSIMEBI(2).Text = .Item("SIMEBI3").ToString
                            txtNyukinKbn(0).Text = .Item("NYUKINKBN1").ToString
                            txtNyukinKbn(1).Text = .Item("NYUKINKBN2").ToString
                            txtNyukinKbn(2).Text = .Item("NYUKINKBN3").ToString
                            txtSyuuKin(0).Text = .Item("SYUUKIN1").ToString
                            txtSyuuKin(1).Text = .Item("SYUUKIN2").ToString
                            txtSyuuKin(2).Text = .Item("SYUUKIN3").ToString
                            txtZEIROUND.Text = .Item("ZEIROUND").ToString
                            txtSUROUND.Text = .Item("SUROUND").ToString
                            txtKINROUND.Text = .Item("KINROUND").ToString
                            txtSYOHIZEIKBN.Text = .Item("SYOHIZEIKBN").ToString
                            txtZANKANRIKBN.Text = .Item("ZANKANRIKBN").ToString
                            txtTankaKakikaeKbn.Text = .Item("TANKAKAKIKAEKBN").ToString
                            txtZEIKBN.Text = .Item("ZEIKBN").ToString
                            txtZANINJIKBN.Text = .Item("ZANINJIKBN").ToString
                            txtDenpyoSyuKbn.Text = .Item("DENPYOSYUKBN").ToString
                            txtSeikyuKbn.Text = .Item("SEIKYUKBN").ToString
                            txtENDURIDATE.Text = .Item("ENDURIDATE").ToString
                            txtAITE_BUSYONAME.Text = .Item("AITE_BUSYONAME").ToString
                            txtAITE_TANTONAME.Text = .Item("AITE_TANTONAME").ToString
                            txtKEISYOUCODE.Text = .Item("KEISYOUCODE").ToString
                            txtSIHARAIBI.Text = .Item("SIHARAIBI").ToString
                            txtSIHARAI_GENKINRITU.Text = .Item("SIHARAI_GENKINRITU").ToString
                            txtSIHARAI_TEGATARITU.Text = .Item("SIHARAI_TEGATARITU").ToString
                            txtSITE.Text = .Item("SITE").ToString

                            '非表示項目
                            txtYOSAN(0).Text = .Item("YOSAN01").ToString
                            txtYOSAN(1).Text = .Item("YOSAN02").ToString
                            txtYOSAN(2).Text = .Item("YOSAN03").ToString
                            txtYOSAN(3).Text = .Item("YOSAN04").ToString
                            txtYOSAN(4).Text = .Item("YOSAN05").ToString
                            txtYOSAN(5).Text = .Item("YOSAN06").ToString
                            txtYOSAN(6).Text = .Item("YOSAN07").ToString
                            txtYOSAN(7).Text = .Item("YOSAN08").ToString
                            txtYOSAN(8).Text = .Item("YOSAN09").ToString
                            txtYOSAN(9).Text = .Item("YOSAN10").ToString
                            txtYOSAN(10).Text = .Item("YOSAN11").ToString
                            txtYOSAN(11).Text = .Item("YOSAN12").ToString
                        End With
                End Select
        End Select
    End Sub

    Private Sub コンボボックス初期化()

        Dim logic As New BLL.Common.TypComboBox

        Dim paramlist As New List(Of Model.DTO.RequestGetComboBoxContentsElement)
        paramlist.Add(New Model.DTO.RequestGetComboBoxContentsElement(Model.ComboBoxTableName.M_TOKUI, Model.DTO.GetComboBoxContentsResultFieldType.MultipleField, False, Nothing))
        paramlist.Add(New Model.DTO.RequestGetComboBoxContentsElement(Model.ComboBoxTableName.M_TANTO, Model.DTO.GetComboBoxContentsResultFieldType.MultipleField, False, Nothing))
        paramlist.Add(New Model.DTO.RequestGetComboBoxContentsElement(Model.ComboBoxTableName.M_KBN, Model.DTO.GetComboBoxContentsResultFieldType.MultipleField, False, "04"))

        Dim requestParam As New Model.DTO.RequestGetComboBoxContents(paramlist)
        Dim recieveParam As Model.DTO.ResponseGetComboBoxContents

        recieveParam = logic.CreateComboBox(requestParam)

        txtTokuiCode.AttachDataSource(Model.ComboBoxTableName.M_TOKUI, recieveParam)
        txtTANTOCODE.AttachDataSource(Model.ComboBoxTableName.M_TANTO, recieveParam)
        txtKEISYOUCODE.AttachDataSource(Model.ComboBoxTableName.M_KBN, recieveParam)

        paramlist.Add(New Model.DTO.RequestGetComboBoxContentsElement(Model.ComboBoxTableName.M_TOKUI, Model.DTO.GetComboBoxContentsResultFieldType.MultipleField, False, "SEIKYU"))
        recieveParam = logic.CreateComboBox(requestParam)

    End Sub

    Private Sub ファンクションキー設定(ByVal FormStatus As enumFormStatus)

        FunctionKey.ClearAll()

        FunctionKey.SetItem(1, "終了", "終了", True)
        FunctionKey.SetItem(3, "削除", "削除", False)
        FunctionKey.SetItem(5, "先頭へ", "先頭へ", True)
        FunctionKey.SetItem(6, "前へ", "前へ", True)
        FunctionKey.SetItem(7, "次へ", "次へ", True)
        FunctionKey.SetItem(8, "最後へ", "最後へ", True)
        FunctionKey.SetItem(9, "検索", "検索", True)
        FunctionKey.SetItem(10, "コピー", "コピー", False)
        FunctionKey.SetItem(11, "貼付", "貼付", False)
        FunctionKey.SetItem(12, "登録", "登録", False)

        'functionキーon,off処理
        EnableFunctionKey(txtTokuiCode, "検索")

    End Sub

    Private Sub イベント設定()

        AddHandlerControl(Me)

        'フォーカス取得時（入力チェック）
        AddHandler txtTokuiCode.Enter, AddressOf ErrorCheckEventHandler
        AddHandler txtTokuiName.Enter, AddressOf ErrorCheckEventHandler
        AddHandler txtRYAKUNAME.Enter, AddressOf ErrorCheckEventHandler
        AddHandler txtMENUKEY.Enter, AddressOf ErrorCheckEventHandler
        AddHandler txtPostNo.Enter, AddressOf ErrorCheckEventHandler
        AddHandler txtADDRESS.Enter, AddressOf ErrorCheckEventHandler
        AddHandler txtADDRESS1.Enter, AddressOf ErrorCheckEventHandler
        AddHandler txtADDRESS2.Enter, AddressOf ErrorCheckEventHandler
        AddHandler txtTELNO.Enter, AddressOf ErrorCheckEventHandler
        AddHandler txtFAXNO.Enter, AddressOf ErrorCheckEventHandler
        AddHandler txtGINKOU.Enter, AddressOf ErrorCheckEventHandler
        AddHandler txtKOUZA.Enter, AddressOf ErrorCheckEventHandler
        AddHandler txtTANKACODE.Enter, AddressOf ErrorCheckEventHandler
        AddHandler txtSeikyuCode.Enter, AddressOf ErrorCheckEventHandler
        AddHandler txtTANTOCODE.Enter, AddressOf ErrorCheckEventHandler
        AddHandler txtDenpyoSyuKbn.Enter, AddressOf ErrorCheckEventHandler
        AddHandler txtOROSIKBN.Enter, AddressOf ErrorCheckEventHandler
        AddHandler txtSIMEBI0.Enter, AddressOf ErrorCheckEventHandler
        AddHandler txtSIMEBI1.Enter, AddressOf ErrorCheckEventHandler
        AddHandler txtSIMEBI2.Enter, AddressOf ErrorCheckEventHandler
        AddHandler txtZEIROUND.Enter, AddressOf ErrorCheckEventHandler
        AddHandler txtSUROUND.Enter, AddressOf ErrorCheckEventHandler
        AddHandler txtKINROUND.Enter, AddressOf ErrorCheckEventHandler
        AddHandler txtSYOHIZEIKBN.Enter, AddressOf ErrorCheckEventHandler
        AddHandler txtZANKANRIKBN.Enter, AddressOf ErrorCheckEventHandler
        AddHandler txtTankaKakikaeKbn.Enter, AddressOf ErrorCheckEventHandler
        AddHandler txtZEIKBN.Enter, AddressOf ErrorCheckEventHandler
        AddHandler txtZANINJIKBN.Enter, AddressOf ErrorCheckEventHandler
        AddHandler txtAITE_BUSYONAME.Enter, AddressOf ErrorCheckEventHandler
        AddHandler txtAITE_TANTONAME.Enter, AddressOf ErrorCheckEventHandler
        AddHandler txtKEISYOUCODE.Enter, AddressOf ErrorCheckEventHandler
        AddHandler txtSIHARAIBI.Enter, AddressOf ErrorCheckEventHandler
        AddHandler txtSIHARAI_GENKINRITU.Enter, AddressOf ErrorCheckEventHandler
        AddHandler txtSIHARAI_TEGATARITU.Enter, AddressOf ErrorCheckEventHandler
        AddHandler txtSITE.Enter, AddressOf ErrorCheckEventHandler

        'フォーカス取得時イベント(ImeMode = Hiragana)
        AddHandler txtGINKOU.Enter, AddressOf EnterEventHandlerImeHiragana
        AddHandler txtRYAKUNAME.Enter, AddressOf EnterEventHandlerImeHiragana
        AddHandler txtTokuiCode.Enter, AddressOf EnterEventHandlerImeHiragana
        AddHandler txtADDRESS.Enter, AddressOf EnterEventHandlerImeHiragana
        AddHandler txtADDRESS1.Enter, AddressOf EnterEventHandlerImeHiragana
        AddHandler txtADDRESS2.Enter, AddressOf EnterEventHandlerImeHiragana
        AddHandler txtTANKANAME.Enter, AddressOf EnterEventHandlerImeHiragana
        AddHandler txtAITE_BUSYONAME.Enter, AddressOf EnterEventHandlerImeHiragana
        AddHandler txtAITE_TANTONAME.Enter, AddressOf EnterEventHandlerImeHiragana

        'フォーカス取得時イベント(ImeMode = Off)
        AddHandler txtKOUZA.Enter, AddressOf EnterEventHandlerImeOff
        AddHandler txtTELNO.Enter, AddressOf EnterEventHandlerImeOff
        AddHandler txtFAXNO.Enter, AddressOf EnterEventHandlerImeOff

        'フォーカス取得時イベント(ImeMode = kanaHalf)
        AddHandler txtMENUKEY.Enter, AddressOf EnterEventHandlerImekanaHalf

        '検索ボタン切替
        AddHandler txtTokuiCode.Enter, AddressOf txt_Enter
        AddHandler txtTokuiName.Enter, AddressOf txt_Leave
        AddHandler txtRYAKUNAME.Enter, AddressOf txt_Leave
        AddHandler txtMENUKEY.Enter, AddressOf txt_Leave
        AddHandler txtPostNo.Enter, AddressOf txt_Enter
        AddHandler txtADDRESS.Enter, AddressOf txt_Leave
        AddHandler txtADDRESS1.Enter, AddressOf txt_Leave
        AddHandler txtADDRESS2.Enter, AddressOf txt_Leave
        AddHandler txtTELNO.Enter, AddressOf txt_Leave
        AddHandler txtFAXNO.Enter, AddressOf txt_Leave
        AddHandler txtGINKOU.Enter, AddressOf txt_Leave
        AddHandler txtKOUZA.Enter, AddressOf txt_Leave
        AddHandler txtTANKACODE.Enter, AddressOf txt_Leave
        AddHandler txtSeikyuCode.Enter, AddressOf txt_Enter
        AddHandler txtTANTOCODE.Enter, AddressOf txt_Leave
        AddHandler txtDenpyoSyuKbn.Enter, AddressOf txt_Leave
        AddHandler txtOROSIKBN.Enter, AddressOf txt_Leave
        AddHandler txtSIMEBI0.Enter, AddressOf txt_Leave
        AddHandler txtSIMEBI1.Enter, AddressOf txt_Leave
        AddHandler txtSIMEBI2.Enter, AddressOf txt_Leave
        AddHandler txtZEIROUND.Enter, AddressOf txt_Leave
        AddHandler txtSUROUND.Enter, AddressOf txt_Leave
        AddHandler txtKINROUND.Enter, AddressOf txt_Leave
        AddHandler txtSYOHIZEIKBN.Enter, AddressOf txt_Leave
        AddHandler txtZANKANRIKBN.Enter, AddressOf txt_Leave
        AddHandler txtTankaKakikaeKbn.Enter, AddressOf txt_Leave
        AddHandler txtZEIKBN.Enter, AddressOf txt_Leave
        AddHandler txtZANINJIKBN.Enter, AddressOf txt_Leave
        AddHandler txtAITE_BUSYONAME.Enter, AddressOf txt_Leave
        AddHandler txtAITE_TANTONAME.Enter, AddressOf txt_Leave
        AddHandler txtKEISYOUCODE.Enter, AddressOf txt_Leave
        AddHandler txtSIHARAIBI.Enter, AddressOf txt_Leave
        AddHandler txtSIHARAI_GENKINRITU.Enter, AddressOf txt_Leave
        AddHandler txtSIHARAI_TEGATARITU.Enter, AddressOf txt_Leave
        AddHandler txtSITE.Enter, AddressOf txt_Leave

    End Sub

    ''' <summary>
    ''' フォーム上のコントロールにイベントを設定
    ''' </summary>
    ''' <param name="hParent"></param>
    ''' <remarks></remarks>
    Private Sub AddHandlerControl(ByVal hParent As Control)
        ' hParent 内のすべてのコントロールを列挙する
        For Each cControl As Control In hParent.Controls
            ' 列挙したコントロールにコントロールが含まれている場合は再帰呼び出しする
            If cControl.HasChildren Then
                AddHandlerControl(cControl)
            End If

            ' コントロールの型が TextBoxBase からの派生型の場合
            If TypeOf cControl Is TextBoxBase Then
                AddHandler cControl.TextChanged, AddressOf ChangeEventHandler
            End If

        Next cControl
    End Sub

    Protected Overrides Sub FunctionKeyAction(ByVal sender As System.Object, ByVal e As CommonUtility.WinFormControls.FunctionKeyEventArgs)

        Select Case e.Name

            Case "終了"

                Me.Close()

                Exit Sub

            Case "取消"

                If fraMeisai.Enabled = True And blnUpdateFlg = True Then
                    If MessageBoxEx.Show(CommonUtility.MessageCode_Arg0.M003取消してもよろしいですか, PROGRAM_NAME) = Windows.Forms.DialogResult.No Then Return
                End If

                画面設定(enumFormStatus.キー入力)

                txtTokuiCode.Focus()

            Case "削除"

                If MessageBoxEx.Show(CommonUtility.MessageCode_Arg0.M002削除してもよろしいですか, PROGRAM_NAME) = Windows.Forms.DialogResult.No Then Return

                ExecuteMain(enum更新種別.削除)

                Using wcur As New WaitCursor
                    '画面切り替え
                    画面設定(enumFormStatus.キー入力)
                End Using

                コンボボックス初期化()

            Case "先頭へ", "前へ", "次へ", "最後へ"

                If fraMeisai.Enabled = True And (blnUpdateFlg = True Or blnUpdateFlg_TTNAME = True) Then

                    If AllInputValidate() = False Then Exit Sub

                    If MessageBoxEx.Show(CommonUtility.MessageCode_Arg0.M001登録してもよろしいですか, PROGRAM_NAME) = Windows.Forms.DialogResult.Yes Then
                        Using wcur As New WaitCursor
                            '更新処理
                            subUpdate()

                            コンボボックス初期化()

                            If _起動パラメーター = 起動種別.入力系呼び出し起動 Then
                                DialogResult = Windows.Forms.DialogResult.OK
                                Return
                            End If

                        End Using
                    End If
                End If

                Using wcur As New WaitCursor
                    RecordMove(e.Name)
                End Using

                txtTokuiCode.Focus()

                Exit Sub

            Case "コピー"

                If Not fncCopy() Then
                    MessageBox.Show("コピーに失敗しました", PROGRAM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If

            Case "貼付"

                If blnCopy = True Then
                    If Not fncPaste() Then
                        MessageBox.Show("貼付に失敗しました", PROGRAM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                End If

            Case "検索"
                PopupSearchForm()

            Case "登録"

                If fraMeisai.Enabled = True And (blnUpdateFlg = True Or blnUpdateFlg_TTNAME = True) Then
                    If AllInputValidate() = False Then Exit Sub

                    If MessageBoxEx.Show(CommonUtility.MessageCode_Arg0.M001登録してもよろしいですか, PROGRAM_NAME) = Windows.Forms.DialogResult.No Then Return

                    ExecuteMain(enum更新種別.新規編集)

                    コンボボックス初期化()

                End If
                Using wcur As New WaitCursor
                    '画面切り替え
                    画面設定(enumFormStatus.キー入力)
                End Using

                If _起動パラメーター = 起動種別.入力系呼び出し起動 Then
                    DialogResult = Windows.Forms.DialogResult.OK
                    Return
                End If

        End Select

        LastFocusedControl.Focus()

    End Sub

    ''' <summary>
    ''' レコード移動
    ''' </summary>
    ''' <param name="MoveCommand"></param>
    ''' <remarks></remarks>
    Private Sub RecordMove(ByVal MoveCommand As String)
        Dim logic As New daMENT0005

        Dim strPrimaryKey As String         'キーコード

        '空値チェック
        If CommonUtility.Utility.NUCheck(txtTokuiCode.Text) Then
            '先頭・最後ボタン以外不可
            If MoveCommand <> "先頭へ" And MoveCommand <> "最後へ" Then Exit Sub
        End If

        strPrimaryKey = logic.RecordMove(MoveCommand, txtTokuiCode.Text, PCNAME, PROGRAM_ID)
        If CommonUtility.Utility.NUCheck(strPrimaryKey) Then
            '初期化
            画面設定(enumFormStatus.キー入力)
        Else
            txtTokuiCode.Text = strPrimaryKey

            TrntxtTokuiCodeKeyDown()
        End If

    End Sub

    ''' <summary>
    ''' 検索画面起動
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub PopupSearchForm()

        '未実装（検索画面を作成していないため）

        Select Case LastFocusedControl.Name
            Case txtTokuiCode.Name
                '得意先コード
                '*** 検索画面表示 ***
                Using f As New WinFormBase.SEARCH_TOKUI(0)
                    f.Owner = Me
                    If f.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        If f.SelectItem IsNot Nothing Then
                            '得意先コードセット
                            LastFocusedControl.Text = f.SelectItem.Code

                            txtTokuiCode.Focus()
                            Return
                        Else
                            txtTokuiCode.Focus()
                        End If
                    End If
                End Using

            Case txtPostNo.Name
                '郵便番号
                Using f As New WinFormBase.SEN0040
                    If f.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        If f.ItemSelected = True Then
                            '郵便番号セット
                            LastFocusedControl.Text = f.SelectedItem.POSTCODE
                            '住所１値チェック
                            If CommonUtility.Utility.NS(txtADDRESS.Text) = vbNullString And
                               CommonUtility.Utility.NS(txtADDRESS1.Text) = vbNullString Then
                                txtADDRESS.Text = f.SelectedItem.TODOUFUKEN
                                txtADDRESS1.Text = f.SelectedItem.SIKUTYOUSON & f.SelectedItem.TYOUIKI
                                txtADDRESS2.Text = ""
                            Else
                                If MessageBoxEx.Show(CommonUtility.MessageCode_Arg0.M007書き換えてもよろしいですか, PROGRAM_NAME) = Windows.Forms.DialogResult.Yes Then
                                    txtADDRESS.Text = f.SelectedItem.TODOUFUKEN
                                    txtADDRESS1.Text = f.SelectedItem.SIKUTYOUSON & f.SelectedItem.TYOUIKI
                                    txtADDRESS2.Text = ""
                                End If
                            End If

                            '郵便番号チェックしない
                            blnPostChkFlg = True

                            txtADDRESS1.Focus()
                            SendKeys.Send("{END}")
                            Return
                        Else
                            '郵便番号チェックしない
                            blnPostChkFlg = True
                        End If
                    End If
                End Using

        End Select

        LastFocusedControl.Focus()

    End Sub

    Private Sub ExecuteMain(ByVal 更新 As enum更新種別)

        Dim logic As New daMENT0005

        If 更新 = enum更新種別.削除 Then
            logic.DeleteTable(txtTokuiCode.Text)
        Else
            'コードの採番
            If NUCheck(txtTokuiCode.Text) Then
                txtTokuiCode.Text = ZeroFormat(CodeNumbering.GetNumer(CodeNumbering.enumKbn.M_TOKUI), txtTokuiCode.MaxLength)
            End If

            subUpdate()
        End If

    End Sub

    ''' <summary>
    ''' 更新処理
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub subUpdate()

        Using wcur As New WaitCursor

            Dim logic As New daMENT0005
            Dim updateData As dtMENT0005.MENT0005 = getUpdateValue()
            logic.UpdateTable(updateData)

            If _起動パラメーター = 起動種別.入力系呼び出し起動 Then
                _ReturnTOKUICODE = updateData.TOKUICODE
                _ReturnTOKUINAME = updateData.TOKUINAME
            End If
        End Using

    End Sub

    ''' <summary>
    ''' 更新用データ格納
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function getUpdateValue() As dtMENT0005.MENT0005

        Dim updateData As New dtMENT0005.MENT0005

        With updateData

            If _起動パラメーター = 起動種別.通常起動 Then
                .TOKUICODE = txtTokuiCode.Text
            Else
                If CommonUtility.Utility.NUCheck(txtTokuiCode.Text) Then
                    .TOKUICODE = ""
                Else
                    .TOKUICODE = txtTokuiCode.Text
                End If
            End If

            .TOKUINAME = txtTokuiName.Text
            .RYAKUNAME = txtRYAKUNAME.Text
            .MENUKEY = txtMENUKEY.Text
            .POSTNO = txtPostNo.Text
            .ADDRESS = txtADDRESS.Text
            .ADDRESS1 = txtADDRESS1.Text
            .ADDRESS2 = txtADDRESS2.Text
            .TELNO = txtTELNO.Text
            .FAXNO = txtFAXNO.Text
            .GINKOU = txtGINKOU.Text
            .KOUZA = txtKOUZA.Text
            .TANKACODE = txtTANKACODE.Text
            .TANKANAME = txtTANKANAME.Text
            .SEIKYUCODE = txtSeikyuCode.Text
            .TANTOCODE = txtTANTOCODE.Text
            .SIMEBI1 = txtSIMEBI(0).Text
            .SIMEBI2 = txtSIMEBI(1).Text
            .SIMEBI3 = txtSIMEBI(2).Text
            .NYUKINKBN1 = txtNyukinKbn(0).Text
            .NYUKINKBN2 = txtNyukinKbn(1).Text
            .NYUKINKBN3 = txtNyukinKbn(2).Text
            .SYUUKIN1 = txtSyuuKin(0).Text
            .SYUUKIN2 = txtSyuuKin(1).Text
            .SYUUKIN3 = txtSyuuKin(2).Text
            .ZEIROUND = txtZEIROUND.Text
            .SUROUND = txtSUROUND.Text
            .KINROUND = txtKINROUND.Text
            .SYOHIZEIKBN = txtSYOHIZEIKBN.Text
            .ZANKANRIKBN = txtZANKANRIKBN.Text
            .TANKAKAKIKAEKBN = txtTankaKakikaeKbn.Text
            .ZEIKBN = txtZEIKBN.Text
            .ZANINJIKBN = txtZANINJIKBN.Text
            .DENPYOSYUKBN = txtDenpyoSyuKbn.Text
            .SEIKYUKBN = txtSeikyuKbn.Text
            .YOSAN01 = txtYOSAN(0).Text
            .YOSAN02 = txtYOSAN(1).Text
            .YOSAN03 = txtYOSAN(2).Text
            .YOSAN04 = txtYOSAN(3).Text
            .YOSAN05 = txtYOSAN(4).Text
            .YOSAN06 = txtYOSAN(5).Text
            .YOSAN07 = txtYOSAN(6).Text
            .YOSAN08 = txtYOSAN(7).Text
            .YOSAN09 = txtYOSAN(8).Text
            .YOSAN10 = txtYOSAN(9).Text
            .YOSAN11 = txtYOSAN(10).Text
            .YOSAN12 = txtYOSAN(11).Text
            .ENDURIDATE = txtENDURIDATE.Text
            .AITE_BUSYONAME = txtAITE_BUSYONAME.Text
            .AITE_TANTONAME = txtAITE_TANTONAME.Text
            .KEISYOUCODE = txtKEISYOUCODE.Text
            .SIHARAIBI = txtSIHARAIBI.Text
            .SIHARAI_GENKINRITU = txtSIHARAI_GENKINRITU.Text
            .SIHARAI_TEGATARITU = txtSIHARAI_TEGATARITU.Text
            .SITE = txtSITE.Text
        End With

        Return updateData

    End Function

    ''' <summary>
    ''' 得意先コードEnterキー押下時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtTokuiCode_PressEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTokuiCode.PressEnter

        TrntxtTokuiCodeKeyDown()

    End Sub

    ''' <summary>
    ''' 得意先コードEnterキー押下時の処理本体
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub TrntxtTokuiCodeKeyDown()
        Dim M_TOKUI As New M_TOKUIread

        Using wcur As New WaitCursor
            Dim response As dsM_TOKUI.M_TOKUIDataTable = M_TOKUI.ReadM_TOKUI(txtTokuiCode.Text)

            If response.Rows.Count > 0 Then
                'フォーム切替
                FormSwitch(enumFormStatus.明細入力, response)
            Else
                'フォーム切替
                FormSwitch(enumFormStatus.明細入力)
            End If
        End Using

        'フォーカス移動
        txtTokuiName.Focus()

    End Sub

    ''' <summary>
    ''' フォーカス取得時イベント(ImeMode = Hiragana)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub EnterEventHandlerImeHiragana(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.ActiveControl.ImeMode = Windows.Forms.ImeMode.Hiragana
    End Sub

    ''' <summary>
    ''' フォーカス取得時イベント(ImeMode = Off)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub EnterEventHandlerImeOff(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.ActiveControl.ImeMode = Windows.Forms.ImeMode.Off
    End Sub

    ''' <summary>
    ''' フォーカス取得時イベント(ImeMode = KatakanaHalf)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub EnterEventHandlerImekanaHalf(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.ActiveControl.ImeMode = Windows.Forms.ImeMode.KatakanaHalf
    End Sub

    ''' <summary>
    ''' フォーカス取得時イベント（検索ボタン切替）
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txt_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FunctionKey.SetItem(9, "検索", "検索", True)
    End Sub

    ''' <summary>
    ''' フォーカス喪失時イベント（検索ボタン切替）
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txt_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FunctionKey.SetItem(9, "検索", "検索", False)
    End Sub

    ''' <summary>
    ''' テキスト変更時イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ChangeEventHandler(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '更新フラグ
        blnUpdateFlg = True
        With Me.ActiveControl
            If .Name = txtPostNo.Name Then
                blnPostChkFlg = False
            End If
            If .Name = txtTELNO.Name Then
                blnTellChkFlg = False
            End If
            If .Name = txtFAXNO.Name Then
                blnFAXChkFlg = False
            End If
            If .Name = txtTANKACODE.Name Or .Name = txtTANKANAME.Name Then
                blnUpdateFlg_TANKACODE = True
            End If
        End With
    End Sub

    Public Function AllInputValidate() As Boolean
        Return InputErrorCheck(Nothing, 9999999)
    End Function

    Private Sub ErrorCheckEventHandler(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If CType(sender, System.Windows.Forms.Control).CausesValidation = False Then
            Return
        End If

        If InputErrorCheck(CType(sender, System.Windows.Forms.Control), GetTabOrder(CType(sender, System.Windows.Forms.Control))) = False Then
            Return
        End If

    End Sub

    Private Function InputErrorCheck(ByVal sender As System.Windows.Forms.Control, ByVal tabOrder As Integer) As Boolean
        Dim CheckResult As Nullable(Of Boolean)

        'サイト（空白で0に置き変える処理が項目タブ移動で動作しないので、最初にやる）
        With txtSITE
            'Nullチェック
            If CommonUtility.Utility.NUCheck(.Text) = True Then
                .Text = "0"
            End If
        End With

        '得意先名
        CheckResult = InputErrorCheck_Control(txtTokuiName, tabOrder)
        If CheckResult.HasValue Then Return CheckResult.Value

        '敬称コード
        CheckResult = InputErrorCheck_Control(txtKEISYOUCODE, tabOrder)
        If CheckResult.HasValue Then Return CheckResult.Value

        '郵便番号
        If blnPostChkFlg = False Then
            If GetTabOrder(txtPostNo) >= tabOrder Then
                Return True
            Else
                If CommonUtility.Utility.PostNoCheck(txtPostNo.Text) = False Then
                    MessageBoxEx.Show(CommonUtility.MessageCode_Arg1.M017を確認して下さい, txtPostNo.DisplayName, PROGRAM_NAME)
                    txtPostNo.Focus()
                    Return False
                End If
                blnPostChkFlg = True
                If fncPost_Read() = False Then
                    Return False
                Else
                    blnPostChkFlg = True
                End If
            End If
        End If

        '住所1
        If GetTabOrder(txtADDRESS1) >= tabOrder Then
            Return True
        Else
            If LenB(txtADDRESS1.Text) > 60 Then
                MessageBoxEx.Show(CommonUtility.MessageCode_Arg1.M020の桁数が大きすぎます, txtADDRESS1.DisplayName, PROGRAM_NAME)
                txtADDRESS1.Focus()
                Return False
            End If
        End If

        '住所2
        If GetTabOrder(txtADDRESS2) >= tabOrder Then
            Return True
        Else
            If LenB(txtADDRESS2.Text) > 60 Then
                MessageBoxEx.Show(CommonUtility.MessageCode_Arg1.M020の桁数が大きすぎます, txtADDRESS2.DisplayName, PROGRAM_NAME)
                txtADDRESS2.Focus()
                Return False
            End If
        End If

        '電話番号
        If blnTellChkFlg = False Then
            If GetTabOrder(txtTELNO) >= tabOrder Then
                Return True
            Else
                If CommonUtility.Utility.TelNoCheck(txtTELNO.Text) = False Then
                    MessageBoxEx.Show(CommonUtility.MessageCode_Arg1.M017を確認して下さい, txtTELNO.DisplayName, PROGRAM_NAME)
                    txtTELNO.Focus()
                    Return False
                End If
                blnTellChkFlg = True
            End If
        End If

        'FAX番号
        If blnFAXChkFlg = False Then
            If GetTabOrder(txtFAXNO) >= tabOrder Then
                Return True
            Else
                If CommonUtility.Utility.TelNoCheck(txtFAXNO.Text) = False Then
                    MessageBoxEx.Show(CommonUtility.MessageCode_Arg1.M017を確認して下さい, txtFAXNO.DisplayName, PROGRAM_NAME)
                    txtFAXNO.Focus()
                    Return False
                End If
                blnFAXChkFlg = True
            End If
        End If

        '担当者ｺｰﾄﾞ
        CheckResult = InputErrorCheck_Control(txtTANTOCODE, tabOrder)
        If CheckResult.HasValue Then Return CheckResult.Value

        '税丸め区分
        If GetTabOrder(txtZEIROUND) >= tabOrder Then
            Return True
        Else
            With txtZEIROUND
                'Nullチェック
                If CommonUtility.Utility.NUCheck(.Text) = True Then
                    .Text = "0"
                End If
                '範囲チェック
                If (CType(.Text, Integer) < 0) Or (CType(.Text, Integer) > 2) Then
                    MessageBoxEx.Show(CommonUtility.MessageCode_Arg1.M014が存在しません, .DisplayName, PROGRAM_NAME)
                    .Focus()
                    Return False
                End If
            End With
        End If

        '税区分
        If GetTabOrder(txtZEIKBN) >= tabOrder Then
            Return True
        Else
            With txtZEIKBN
                'Nullチェック
                If CommonUtility.Utility.NUCheck(.Text) = True Then
                    .Text = "0"
                End If
                '範囲チェック
                If (CType(.Text, Integer) < 0) Or (CType(.Text, Integer) > 2) Then
                    MessageBoxEx.Show(CommonUtility.MessageCode_Arg1.M014が存在しません, .DisplayName, PROGRAM_NAME)
                    .Focus()
                    Return False
                End If
            End With
        End If

        '支払日
        If GetTabOrder(txtSIHARAIBI) >= tabOrder Then
            Return True
        Else
            With txtSIHARAIBI
                'Nullチェック
                If CommonUtility.Utility.NUCheck(.Text) = True Then
                    .Text = "0"
                End If
            End With
        End If

        '支払現金率
        If GetTabOrder(txtSIHARAI_GENKINRITU) >= tabOrder Then
            Return True
        Else
            With txtSIHARAI_GENKINRITU
                'Nullチェック
                If CommonUtility.Utility.NUCheck(.Text) = True Then
                    .Text = "0"
                End If
            End With
        End If

        '支払手形率
        If GetTabOrder(txtSIHARAI_TEGATARITU) >= tabOrder Then
            Return True
        Else
            With txtSIHARAI_TEGATARITU
                'Nullチェック
                If CommonUtility.Utility.NUCheck(.Text) = True Then
                    .Text = "0"
                End If
                '支払現金率、支払手形率の合計が100以外の場合、エラー
                If CInt(txtSIHARAI_GENKINRITU.Text) + CInt(txtSIHARAI_TEGATARITU.Text) <> 100 Then
                    MessageBoxEx.Show(CommonUtility.MessageCode_Arg0.M207, PROGRAM_NAME)
                    .Focus()
                    Return False
                End If
            End With
        End If

        Return True

    End Function

    ''' <summary>
    ''' ファンクション（コピー）
    ''' </summary>
    ''' <remarks></remarks>
    Private Function fncCopy() As Boolean

        '戻り値
        fncCopy = False

        Using wcur As New WaitCursor
            '初期化
            dtCopy.Clear()

            '情報セット
            subSetM_TOKUI(dtCopy)

            blnCopy = True
            FunctionKey.SetItem(11, "貼付", "貼付", True)

        End Using

        '戻り値
        fncCopy = True

    End Function

    ''' <summary>
    ''' ファンクション（貼付）
    ''' </summary>
    ''' <remarks></remarks>
    Private Function fncPaste() As Boolean

        '初期値
        fncPaste = False

        Using wcur As New WaitCursor

            With dtCopy.Rows(0)

                '貼付ﾃﾞｰﾀ確認
                If (.Item("TOKUICODE").ToString = vbNullString) Then Exit Function

                'データセット
                txtTokuiName.Text = .Item("TOKUINAME").ToString                     '得意先名
                txtRYAKUNAME.Text = .Item("RYAKUNAME").ToString                     '略称名
                txtMENUKEY.Text = .Item("MENUKEY").ToString                         'メニューキー
                txtPostNo.Text = .Item("POSTNO").ToString                           '郵便番号
                txtADDRESS.Text = .Item("ADDRESS").ToString                         '都道府県
                txtADDRESS1.Text = .Item("ADDRESS1").ToString                       '住所１
                txtADDRESS2.Text = .Item("ADDRESS2").ToString                       '住所２
                txtTELNO.Text = .Item("TELNO").ToString                             '電話番号
                txtFAXNO.Text = .Item("FAXNO").ToString                             'FAX番号
                txtGINKOU.Text = .Item("GINKOU").ToString                           '銀行名称
                txtKOUZA.Text = .Item("KOUZA").ToString                             '口座番号
                txtTANKACODE.Text = .Item("TANKACODE").ToString                     '単価コード
                txtSeikyuCode.Text = .Item("SEIKYUCODE").ToString                   '請求先コード
                txtTANTOCODE.Text = .Item("TANTOCODE").ToString                     '担当者コード
                txtSIMEBI(0).Text = .Item("SIMEBI1").ToString                       '締日１
                txtSIMEBI(1).Text = .Item("SIMEBI2").ToString                       '締日２
                txtSIMEBI(2).Text = .Item("SIMEBI3").ToString                       '締日３
                txtNyukinKbn(0).Text = .Item("NYUKINKBN1").ToString                 '入金区分１(サイクル)
                txtNyukinKbn(1).Text = .Item("NYUKINKBN2").ToString                 '入金区分２(サイクル)
                txtNyukinKbn(2).Text = .Item("NYUKINKBN3").ToString                 '入金区分３(サイクル)
                txtSyuuKin(0).Text = .Item("SYUUKIN1").ToString                     '集金日１
                txtSyuuKin(1).Text = .Item("SYUUKIN2").ToString                     '集金日２
                txtSyuuKin(2).Text = .Item("SYUUKIN3").ToString                     '集金日３
                txtZEIROUND.Text = .Item("ZEIROUND").ToString                       '税丸め区分
                txtSUROUND.Text = .Item("SUROUND").ToString                         '数量丸め区分
                txtKINROUND.Text = .Item("KINROUND").ToString                       '金額丸め区分
                txtSYOHIZEIKBN.Text = .Item("SYOHIZEIKBN").ToString                 '消費税区分
                txtZANKANRIKBN.Text = .Item("ZANKANRIKBN").ToString                 '残管理区分
                txtTankaKakikaeKbn.Text = .Item("TANKAKAKIKAEKBN").ToString         '単価書換区分
                txtZEIKBN.Text = .Item("ZEIKBN").ToString                           '税区分
                txtZANINJIKBN.Text = .Item("ZANINJIKBN").ToString                   '残高印字区分
                txtDenpyoSyuKbn.Text = .Item("DENPYOSYUKBN").ToString               '伝票種区分
                txtSeikyuKbn.Text = .Item("SEIKYUKBN").ToString                     '請求書区分
                txtOROSIKBN.Text = .Item("YOSAN01").ToString                        '卸区分  
                txtAITE_BUSYONAME.Text = .Item("AITE_BUSYONAME").ToString           '相手部署名
                txtAITE_TANTONAME.Text = .Item("AITE_TANTONAME").ToString           '相手担当者名  
                txtKEISYOUCODE.Text = .Item("KEISYOUCODE").ToString                 '敬称コード
                txtSIHARAIBI.Text = .Item("SIHARAIBI").ToString                     '支払日  
                txtSIHARAI_GENKINRITU.Text = .Item("SIHARAI_GENKINRITU").ToString   '支払現金率  
                txtSIHARAI_TEGATARITU.Text = .Item("SIHARAI_TEGATARITU").ToString   '支払手形率  
                txtSITE.Text = .Item("SITE").ToString                               'サイト  

            End With

        End Using

        '戻り値
        fncPaste = True

    End Function

    ''' <summary>
    ''' コピーデータ格納
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub subSetM_TOKUI(ByRef dt As dsMENT0005.M_TOKUI_COPYDataTable)

        Dim dr As dsMENT0005.M_TOKUI_COPYRow

        dr = dt.NewM_TOKUI_COPYRow

        dr("TOKUICODE") = txtTokuiCode.Text                     '得意先コード
        dr("TOKUINAME") = txtTokuiName.Text                     '得意先名
        dr("RYAKUNAME") = txtRYAKUNAME.Text                     '略称名
        dr("MENUKEY") = txtMENUKEY.Text                         'メニューキー
        dr("POSTNO") = txtPostNo.Text                           '郵便番号
        dr("ADDRESS") = txtADDRESS.Text                         '都道府県
        dr("ADDRESS1") = txtADDRESS1.Text                       '住所１
        dr("ADDRESS2") = txtADDRESS2.Text                       '住所２
        dr("TELNO") = txtTELNO.Text                             '電話番号
        dr("FAXNO") = txtFAXNO.Text                             'FAX番号
        dr("GINKOU") = txtGINKOU.Text                           '銀行名称
        dr("KOUZA") = txtKOUZA.Text                             '口座番号
        dr("TANKACODE") = txtTANKACODE.Text                     '単価コード
        dr("SEIKYUCODE") = txtSeikyuCode.Text                   '請求先コード
        dr("TANTOCODE") = txtTANTOCODE.Text                     '担当者コード
        dr("SIMEBI1") = txtSIMEBI(0).Text                       '締日１
        dr("SIMEBI2") = txtSIMEBI(1).Text                       '締日２
        dr("SIMEBI3") = txtSIMEBI(2).Text                       '締日３
        dr("NYUKINKBN1") = txtNyukinKbn(0).Text                 '入金区分１(サイクル)
        dr("NYUKINKBN2") = txtNyukinKbn(1).Text                 '入金区分２(サイクル)
        dr("NYUKINKBN3") = txtNyukinKbn(2).Text                 '入金区分３(サイクル)
        dr("SYUUKIN1") = txtSyuuKin(0).Text                     '集金日１
        dr("SYUUKIN2") = txtSyuuKin(1).Text                     '集金日２
        dr("SYUUKIN3") = txtSyuuKin(2).Text                     '集金日３
        dr("ZEIROUND") = txtZEIROUND.Text                       '税丸め区分
        dr("SUROUND") = txtSUROUND.Text                         '数量丸め区分
        dr("KINROUND") = txtKINROUND.Text                       '金額丸め区分
        dr("SYOHIZEIKBN") = txtSYOHIZEIKBN.Text                 '消費税区分
        dr("ZANKANRIKBN") = txtZANKANRIKBN.Text                 '残管理区分
        dr("TANKAKAKIKAEKBN") = txtTankaKakikaeKbn.Text         '単価書換区分
        dr("ZEIKBN") = txtZEIKBN.Text                           '税区分
        dr("ZANINJIKBN") = txtZANINJIKBN.Text                   '残高印字区分
        dr("DENPYOSYUKBN") = txtDenpyoSyuKbn.Text               '伝票種区分
        dr("SEIKYUKBN") = txtSeikyuKbn.Text                     '請求書区分
        dr("YOSAN01") = txtOROSIKBN.Text                        '卸区分  
        dr("AITE_BUSYONAME") = txtAITE_BUSYONAME.Text           '相手部署名
        dr("AITE_TANTONAME") = txtAITE_TANTONAME.Text           '相手担当者名  
        dr("KEISYOUCODE") = txtKEISYOUCODE.Text                 '敬称コード
        dr("SIHARAIBI") = txtSIHARAIBI.Text                     '支払日
        dr("SIHARAI_GENKINRITU") = txtSIHARAI_GENKINRITU.Text   '支払現金率
        dr("SIHARAI_TEGATARITU") = txtSIHARAI_TEGATARITU.Text   '支払手形率
        dr("SITE") = txtSITE.Text                               'サイト

        dt.AddM_TOKUI_COPYRow(dr)

    End Sub

    ''' <summary>
    ''' 住所マスタ読込
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function fncPost_Read() As Boolean

        '--変数宣言--
        Dim strPost As String       '郵便番号
        Dim strAddress1 As String   '住所１
        Dim strAddress2 As String   '住所２

        '戻り値
        fncPost_Read = False

        '入力チェック
        strPost = CommonUtility.Utility.TelNo_cnv(txtPostNo.Text)

        If strPost = vbNullString Then
            '戻り値
            fncPost_Read = True
            Exit Function
        End If

        Dim logic As New WinFormBase.daSEN0040
        Dim response As BLL.SEN.dsSEN0040.M_KENDataTable = logic.ReadM_KENbyPrimarykey(strPost)

        'データなし
        If Not response.Rows.Count > 0 Then
            MessageBoxEx.Show(CommonUtility.MessageCode_Arg1.M014が存在しません, txtPostNo.DisplayName, PROGRAM_NAME)
            Exit Function
        End If

        strAddress1 = CommonUtility.Utility.NS(response.Item(0).TODOUFUKEN)
        strAddress2 = CommonUtility.Utility.NS(response.Item(0).SIKUTYOUSON & response.Item(0).TYOUIKI)

        '1件あり
        If response.Rows.Count = 1 Then

            If CommonUtility.Utility.NS(txtADDRESS.Text) = vbNullString And
                   CommonUtility.Utility.NS(txtADDRESS1.Text) = vbNullString Then
                txtADDRESS.Text = strAddress1
                txtADDRESS1.Text = strAddress2
                txtADDRESS2.Text = ""
            Else
                If MessageBoxEx.Show(CommonUtility.MessageCode_Arg0.M007書き換えてもよろしいですか, PROGRAM_NAME) = Windows.Forms.DialogResult.Yes Then
                    txtADDRESS.Text = strAddress1
                    txtADDRESS1.Text = strAddress2
                    txtADDRESS2.Text = ""
                End If
            End If

            txtADDRESS2.Focus()
            SendKeys.Send("{End}")
        Else
            '複数あり
            Using frmPostCode As New WinFormBase.SEN0040
                frmPostCode.SelectedItem = New WinFormBase.SEN0040_M_KEN_Data("", "", "", strPost)
                '検索画面表示
                frmPostCode.ShowDialog()

                If frmPostCode.ItemSelected = False Then
                    '郵便番号チェックしない
                    blnPostChkFlg = True
                    Exit Function
                End If

                If Not frmPostCode.SelectedItem.POSTCODE = vbNullString Then

                    If CommonUtility.Utility.NS(txtADDRESS.Text) = vbNullString And
                           CommonUtility.Utility.NS(txtADDRESS1.Text) = vbNullString Then
                        txtADDRESS.Text = frmPostCode.SelectedItem.TODOUFUKEN
                        txtADDRESS1.Text = frmPostCode.SelectedItem.SIKUTYOUSON & frmPostCode.SelectedItem.TYOUIKI
                        txtADDRESS2.Text = ""
                    Else
                        If MessageBoxEx.Show(CommonUtility.MessageCode_Arg0.M007書き換えてもよろしいですか, PROGRAM_NAME) = Windows.Forms.DialogResult.Yes Then
                            txtADDRESS.Text = frmPostCode.SelectedItem.TODOUFUKEN
                            txtADDRESS1.Text = frmPostCode.SelectedItem.SIKUTYOUSON & frmPostCode.SelectedItem.TYOUIKI
                            txtADDRESS2.Text = ""
                        End If
                    End If

                    txtADDRESS2.Focus()
                End If
            End Using

        End If

        '戻り値
        fncPost_Read = True

    End Function

    Public Shared Function LenB(ByVal stTarget As String) As Integer
        Return System.Text.Encoding.GetEncoding("Shift_JIS").GetByteCount(stTarget)
    End Function

    'テキストボックス
    Private Function txtSIMEBI(ByVal index As Integer) As TextBox
        Dim c As Control() = Me.Controls.Find("txtSIMEBI" + index.ToString, True)
        Return CType(c(0), TextBox)
    End Function
    Private Function txtNyukinKbn(ByVal index As Integer) As TextBox
        Dim c As Control() = Me.Controls.Find("txtNyukinkbn" + index.ToString, True)
        Return CType(c(0), TextBox)
    End Function
    Private Function txtSyuuKin(ByVal index As Integer) As TextBox
        Dim c As Control() = Me.Controls.Find("txtSyuuKin" + index.ToString, True)
        Return CType(c(0), TextBox)
    End Function
    Private Function txtYOSAN(ByVal index As Integer) As TextBox
        Dim c As Control() = Me.Controls.Find("txtYOSAN" + index.ToString, True)
        Return CType(c(0), TextBox)
    End Function

    Private Sub txtTokuiName_CompositionEventHandler(ByVal sender As Object, ByVal e As CommonUtility.WinFormControls.CompositionEventArgs) Handles txtTokuiName.CompositionEventHandler
        Dim i As Integer = 0
        i = txtMENUKEY.MaxLength - txtMENUKEY.Text.Length
        txtMENUKEY.Text += e.ImeString.Substring(0, CType(IIf(i > e.ImeString.Length, e.ImeString.Length, i), Integer))
    End Sub
End Class
