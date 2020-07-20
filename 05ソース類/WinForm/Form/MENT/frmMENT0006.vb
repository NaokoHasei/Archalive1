Imports CommonUtility.WinForm
Imports CommonUtility.Utility
Imports BLL.Common

Public Class frmMENT0006

    Public Overrides Function PROGRAM_ID() As String
        Return "MENT0006"
    End Function

    Public Overrides Function PROGRAM_NAME() As String
        Return "業者マスタ登録"
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
    Private blnUpdateFlg_STNAME As Boolean          '更新フラグ(仕入先単価名称マスタ)
    Private blnUpdateFlg_TANKACODE As Boolean       '更新フラグ(単価コード) 
    Private blnPostChkFlg As Boolean                '郵便番号マスタチェック済フラグ
    Private blnNameUpdateFlg As Boolean             '仕入先名称更新フラグ
    Private strBankMeigiKana As String              '名義カナ
    Private strTENCODE As String                    '自店舗コード
    Private strHONBUCODE As String                  '本部店舗コード
    Private blnTellChkFlg As Boolean                '電話番号マスタチェック済フラグ
    Private blnFAXChkFlg As Boolean                 'FAX番号マスタチェック済フラグ
    Private blnCopy As Boolean                      'コピーフラグ

    Private DTO As New dtBUK0004.dtMENT0006

    Private dtCopy As New dsMENT0006.M_SIIRE_COPYDataTable  'コピー用

    Private CodeNumbering As New CodeNumbering

    Protected Overrides Sub Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MyBase.Form_Load(sender, e)

        Using wcur As New WaitCursor

            コンボボックス初期化()

            画面設定(enumFormStatus.キー入力)

            txtSIIRECODE.Text = ""

            DTO.pblnSiiBunUpdFlg = False

            blnCopy = False

            イベント設定()

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
    Private Sub FormSwitch(ByVal FormStatus As enumFormStatus, Optional ByVal dsSIIRE As dsM_SIIRE.M_SIIREDataTable = Nothing)

        Select Case FormStatus
            Case enumFormStatus.キー入力
                '入力項目初期化
                FormInputItem(enumFormStatus.キー入力)

                'コントロール使用可・不可
                txtSIIRECODE.Enabled = True
                fraMeisai.Enabled = False

                '修正フラグ
                blnUpdateFlg = True

                txtSYOHIZEIKBN.Enabled = True
                txtZEIKBN.Enabled = True

                txtSIIRECODE.Focus()

            Case enumFormStatus.明細入力

                '入力項目初期化
                FormInputItem(enumFormStatus.明細入力, dsSIIRE)

                'コントロール使用可・不可
                txtSIIRECODE.Enabled = False
                fraMeisai.Enabled = True

                '修正フラグ
                blnUpdateFlg = False

                'マスタチェック済フラグ
                blnPostChkFlg = True

                blnNameUpdateFlg = False

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

                'プロパティに仕入先コード格納
                DTO.siirecode_label = txtSIIRECODE.Text

                txtSIIRENAME.Focus()
        End Select

        '更新フラグ
        blnUpdateFlg = False

    End Sub

    ''' <summary>
    ''' 入力項目初期化
    ''' </summary>
    ''' <param name="FormStatus">フォーム状態</param>
    ''' <param name="dsSIIRE">得意先マスタデータセット</param>
    ''' <remarks></remarks>
    Private Sub FormInputItem(ByVal FormStatus As enumFormStatus, Optional ByVal dsSIIRE As dsM_SIIRE.M_SIIREDataTable = Nothing)
        Dim strSIIRECODE As String
        Dim i As Integer

        strSIIRECODE = txtSIIRECODE.Text

        Select Case FormStatus
            Case enumFormStatus.キー入力

                TitleBar.EditMode = CommonUtility.WinFormControls.EditMode.None

                '初期値セット
                txtSIIRENAME.Text = ""
                txtRYAKUNAME.Text = ""
                txtMENUKEY.Text = ""
                txtPostNo.Text = ""
                txtADDRESS.Text = ""
                txtADDRESS1.Text = ""
                txtADDRESS2.Text = ""
                txtItakuCode.Text = ""
                lblItakuCode.Text = ""
                txtTELNO.Text = ""
                txtFAXNO.Text = ""
                txtGINKOU.Text = ""
                txtKOUZA.Text = ""
                txtTANKACODE.Text = ""
                txtTANKANAME.Text = ""
                txtSOSINCODE.Text = ""
                txtSOSINNAME.Text = ""
                txtLOCALCODE.Text = ""
                txtLOCALNAME.Text = ""
                txtTELNO_K.Text = ""
                txtBANKCODE.Text = ""
                txtGINKONAME.Text = ""
                txtBANKSUBCODE.Text = ""
                txtSITENNAME.Text = ""
                txtBANKKOUZAKBN.Text = ""
                txtBANKKOUZAKBNNAME.Text = ""
                txtBANKMEIGI.Text = ""
                txtBANKMEIGIKANA.Text = ""
                For i = 0 To 1
                    txtMAILADDRESS(i).Text = ""
                    txtMAILACCOUNT(i).Text = ""
                    chkMAILSENDFLG(i).Checked = False
                Next
                txtMAILDOMAINNAME0.Text = ""
                txtMAILDOMAINNAME1.Text = ""
                chkMAILTANKADISPFLG.Checked = False
                chkMAILDISPFLG.Checked = False
                chkMAILSENDOBJECTKBN(0).Checked = False
                chkMAILSENDOBJECTKBN(1).Checked = False
                chkMAILSENDOBJECTKBN(2).Checked = False
                chkPRICEPRIKBN.Checked = False
                txtLABEL_NAME.Text = ""
                txtLABEL_TELNO.Text = ""
                txtSEISANTINAME.Text = ""
                txtTESURITU1.Text = "0"
                txtTESURITU2.Text = "0"
                txtKEIYAKUDATE.Text = vbNullString

                txtTANTOCODE.Text = CommonUtility.Utility.ZeroPadding(NowUserInfo.TANTOCODE, 4)
                For i = 0 To 2
                    txtSIMEBI(i).Text = "0"
                    txtSIHARAIKBN(i).Text = "0"
                    txtSIHARAIBI(i).Text = "0"
                Next i

                txtZEIROUND.Text = "0"
                txtSUROUND.Text = "0"
                txtKINROUND.Text = "0"
                txtSYOHIZEIKBN.Text = "0"
                txtZANKANRIKBN.Text = "1"    '1:各店支払固定

                txtKENSYU_DEKIDAKA.Text = "0"
                txtSIHARAI_GENKINRITU.Text = "0"
                txtSIHARAI_TEGATARITU.Text = "0"
                txtSITE.Text = "0"
                txtDAIHYONAME.Text = ""
                txtKEISYOUCODE.Text = ""
                txtKEISYOUNAME.Text = ""

                txtZEIKBN.Text = "0"
                txtSOSINFLG.Text = "1"
                txtENDSIIDATE.Text = "1900/01/01"
                '非表示項目
                txtSIHARAICODE.Text = ""
                For i = 0 To 11
                    txtYOSAN(i).Text = "0"
                Next i

            Case enumFormStatus.明細入力

                Select Case dsSIIRE Is Nothing
                    Case True
                        '新規登録
                        TitleBar.EditMode = CommonUtility.WinFormControls.EditMode.Create

                        txtSOSINCODE.Text = txtSIIRECODE.Text
                        txtSOSINNAME.Text = vbNullString
                        txtTANKACODE.Text = txtSIIRECODE.Text

                        '全仕入先をチェックし、Max + 1 をラベルに表示する
                        subGet_M_SiireMax()

                    Case False
                        '編集/削除
                        TitleBar.EditMode = CommonUtility.WinFormControls.EditMode.Edit

                        With dsSIIRE.Rows(0)
                            txtSIIRENAME.Text = .Item("SIIRENAME").ToString
                            txtRYAKUNAME.Text = .Item("RYAKUNAME").ToString
                            txtMENUKEY.Text = .Item("MENUKEY").ToString
                            txtPostNo.Text = .Item("POSTNO").ToString
                            txtADDRESS.Text = .Item("ADDRESS").ToString
                            txtADDRESS1.Text = .Item("ADDRESS1").ToString
                            txtADDRESS2.Text = .Item("ADDRESS2").ToString
                            txtItakuCode.Text = .Item("ITAKUCODE").ToString
                            txtMAILADDRESS(0).Text = .Item("MAILADDRESS").ToString
                            txtMAILACCOUNT(0).Text = .Item("MAILACCOUNT").ToString
                            txtMAILDOMAINNAME0.Text = .Item("MAILDOMAINNAME").ToString
                            chkMAILSENDFLG(0).Checked = CType(.Item("MAILSENDFLG"), Boolean)
                            txtMAILADDRESS(1).Text = .Item("MAILADDRESS1").ToString
                            txtMAILACCOUNT(1).Text = .Item("MAILACCOUNT1").ToString
                            txtMAILDOMAINNAME1.Text = .Item("MAILDOMAINNAME1").ToString
                            chkMAILSENDFLG(1).Checked = CType(.Item("MAILSENDFLG1"), Boolean)
                            chkMAILDISPFLG.Checked = CType(.Item("MAILDISPFLG"), Boolean)
                            chkMAILTANKADISPFLG.Checked = CType(.Item("MAILTANKADISPFLG"), Boolean)
                            chkMAILSENDOBJECTKBN(0).Checked = False
                            chkMAILSENDOBJECTKBN(1).Checked = False
                            chkMAILSENDOBJECTKBN(2).Checked = False
                            chkMAILSENDOBJECTKBN(CType(.Item("MAILSENDOBJECTKBN"), Integer)).Checked = True
                            chkPRICEPRIKBN.Checked = CType(.Item("PRICEPRIKBN"), Boolean)
                            txtLABEL_NAME.Text = .Item("LABEL_NAME").ToString
                            txtLABEL_TELNO.Text = .Item("LABEL_TELNO").ToString
                            txtTELNO.Text = .Item("TELNO").ToString
                            txtFAXNO.Text = .Item("FAXNO").ToString
                            txtTELNO_K.Text = .Item("TELNO_K").ToString
                            txtGINKOU.Text = .Item("GINKOU").ToString
                            txtBANKCODE.Text = .Item("BANKCODE").ToString
                            txtBANKSUBCODE.Text = .Item("BANKSUBCODE").ToString

                            '口座区分をマスタ化
                            txtBANKKOUZAKBN.Text = .Item("BANKKOUZAKBN").ToString
                            txtKOUZA.Text = .Item("KOUZA").ToString
                            txtBANKMEIGI.Text = .Item("BANKMEIGI").ToString
                            txtBANKMEIGIKANA.Text = .Item("BANKMEIGIKANA").ToString
                            txtLOCALCODE.Text = .Item("LOCALCODE").ToString
                            txtTANKACODE.Text = .Item("TANKACODE").ToString
                            txtSOSINCODE.Text = .Item("SOSINCODE").ToString
                            txtTANTOCODE.Text = .Item("TANTOCODE").ToString
                            txtSIMEBI(0).Text = .Item("SIMEBI1").ToString
                            txtSIMEBI(1).Text = .Item("SIMEBI2").ToString
                            txtSIMEBI(2).Text = .Item("SIMEBI3").ToString
                            txtSIHARAIKBN(0).Text = .Item("SIHARAIKBN1").ToString
                            txtSIHARAIKBN(1).Text = .Item("SIHARAIKBN2").ToString
                            txtSIHARAIKBN(2).Text = .Item("SIHARAIKBN3").ToString
                            txtSIHARAIBI(0).Text = .Item("SIHARAIBI1").ToString
                            txtSIHARAIBI(1).Text = .Item("SIHARAIBI2").ToString
                            txtSIHARAIBI(2).Text = .Item("SIHARAIBI3").ToString
                            txtSEISANTINAME.Text = .Item("SEISANTINAME").ToString
                            txtZEIROUND.Text = .Item("ZEIROUND").ToString
                            txtSUROUND.Text = .Item("SUROUND").ToString
                            txtKINROUND.Text = .Item("KINROUND").ToString
                            txtSYOHIZEIKBN.Text = .Item("SYOHIZEIKBN").ToString
                            txtZANKANRIKBN.Text = .Item("ZANKANRIKBN").ToString
                            txtGENKAKAKIKAEKBN.Text = .Item("GENKAKAKIKAEKBN").ToString
                            txtZEIKBN.Text = .Item("ZEIKBN").ToString
                            txtSOSINFLG.Text = .Item("SOSINFLG").ToString
                            txtTESURITU1.Text = .Item("TESURITU_1").ToString
                            txtTESURITU2.Text = .Item("TESURITU_2").ToString
                            txtENDSIIDATE.Text = .Item("ENDSIIDATE").ToString
                            txtKEIYAKUDATE.Text = .Item("KEIYAKUDATE").ToString
                            txtKENSYU_DEKIDAKA.Text = .Item("KENSYU_DEKIDAKA").ToString
                            txtSIHARAI_GENKINRITU.Text = .Item("SIHARAI_GENKINRITU").ToString
                            txtSIHARAI_TEGATARITU.Text = .Item("SIHARAI_TEGATARITU").ToString
                            txtSITE.Text = .Item("SITE").ToString
                            txtDAIHYONAME.Text = .Item("DAIHYONAME").ToString
                            txtKEISYOUCODE.Text = .Item("KEISYOUCODE").ToString

                            '非表示項目
                            txtSIHARAICODE.Text = .Item("SIHARAICODE").ToString
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

        Dim logic As New TypComboBox

        Dim paramlist As New List(Of Model.DTO.RequestGetComboBoxContentsElement)
        paramlist.Add(New Model.DTO.RequestGetComboBoxContentsElement(Model.ComboBoxTableName.M_SIIRE, Model.DTO.GetComboBoxContentsResultFieldType.MultipleField, False, Nothing))
        paramlist.Add(New Model.DTO.RequestGetComboBoxContentsElement(Model.ComboBoxTableName.M_TANTO, Model.DTO.GetComboBoxContentsResultFieldType.MultipleField, False, Nothing))
        paramlist.Add(New Model.DTO.RequestGetComboBoxContentsElement(Model.ComboBoxTableName.M_KBN, Model.DTO.GetComboBoxContentsResultFieldType.MultipleField, False, "04"))

        Dim requestParam As New Model.DTO.RequestGetComboBoxContents(paramlist)
        Dim recieveParam As Model.DTO.ResponseGetComboBoxContents

        recieveParam = logic.CreateComboBox(requestParam)

        txtSIIRECODE.AttachDataSource(Model.ComboBoxTableName.M_SIIRE, recieveParam)
        txtTANTOCODE.AttachDataSource(Model.ComboBoxTableName.M_TANTO, recieveParam)
        txtKEISYOUCODE.AttachDataSource(Model.ComboBoxTableName.M_KBN, recieveParam)
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
    End Sub

    Private Sub イベント設定()

        AddHandlerControl(Me)

        'フォーカス取得時（入力チェック）
        AddHandler txtSIIRECODE.Enter, AddressOf ErrorCheckEventHandler
        AddHandler txtSIIRENAME.Enter, AddressOf ErrorCheckEventHandler
        AddHandler txtRYAKUNAME.Enter, AddressOf ErrorCheckEventHandler
        AddHandler txtMENUKEY.Enter, AddressOf ErrorCheckEventHandler
        AddHandler txtPostNo.Enter, AddressOf ErrorCheckEventHandler
        AddHandler txtADDRESS.Enter, AddressOf ErrorCheckEventHandler
        AddHandler txtADDRESS1.Enter, AddressOf ErrorCheckEventHandler
        AddHandler txtADDRESS2.Enter, AddressOf ErrorCheckEventHandler
        AddHandler txtItakuCode.Enter, AddressOf ErrorCheckEventHandler
        AddHandler txtLOCALCODE.Enter, AddressOf ErrorCheckEventHandler
        AddHandler txtTELNO.Enter, AddressOf ErrorCheckEventHandler
        AddHandler txtFAXNO.Enter, AddressOf ErrorCheckEventHandler
        AddHandler txtTELNO_K.Enter, AddressOf ErrorCheckEventHandler
        AddHandler txtBANKCODE.Enter, AddressOf ErrorCheckEventHandler
        AddHandler txtBANKSUBCODE.Enter, AddressOf ErrorCheckEventHandler
        AddHandler txtBANKKOUZAKBN.Enter, AddressOf ErrorCheckEventHandler
        AddHandler txtKOUZA.Enter, AddressOf ErrorCheckEventHandler
        AddHandler txtBANKMEIGI.Enter, AddressOf ErrorCheckEventHandler
        AddHandler txtBANKMEIGIKANA.Enter, AddressOf ErrorCheckEventHandler
        AddHandler txtTANKACODE.Enter, AddressOf ErrorCheckEventHandler
        AddHandler txtSOSINCODE.Enter, AddressOf ErrorCheckEventHandler
        AddHandler txtTANTOCODE.Enter, AddressOf ErrorCheckEventHandler
        AddHandler txtMAILACCOUNT0.Enter, AddressOf ErrorCheckEventHandler
        AddHandler txtMAILACCOUNT1.Enter, AddressOf ErrorCheckEventHandler
        AddHandler txtMAILDOMAINNAME0.Enter, AddressOf ErrorCheckEventHandler
        AddHandler txtMAILDOMAINNAME1.Enter, AddressOf ErrorCheckEventHandler
        AddHandler txtZEIROUND.Enter, AddressOf ErrorCheckEventHandler
        AddHandler txtSUROUND.Enter, AddressOf ErrorCheckEventHandler
        AddHandler txtKINROUND.Enter, AddressOf ErrorCheckEventHandler
        AddHandler txtSYOHIZEIKBN.Enter, AddressOf ErrorCheckEventHandler
        AddHandler txtZANKANRIKBN.Enter, AddressOf ErrorCheckEventHandler
        AddHandler txtGENKAKAKIKAEKBN.Enter, AddressOf ErrorCheckEventHandler
        AddHandler txtZEIKBN.Enter, AddressOf ErrorCheckEventHandler
        AddHandler txtSOSINFLG.Enter, AddressOf ErrorCheckEventHandler
        AddHandler txtSIMEBI0.Enter, AddressOf ErrorCheckEventHandler
        AddHandler txtSIMEBI1.Enter, AddressOf ErrorCheckEventHandler
        AddHandler txtSIMEBI2.Enter, AddressOf ErrorCheckEventHandler
        AddHandler txtLABEL_NAME.Enter, AddressOf ErrorCheckEventHandler
        AddHandler txtLABEL_TELNO.Enter, AddressOf ErrorCheckEventHandler
        AddHandler txtSEISANTINAME.Enter, AddressOf ErrorCheckEventHandler
        AddHandler txtTESURITU1.Enter, AddressOf ErrorCheckEventHandler
        AddHandler txtTESURITU2.Enter, AddressOf ErrorCheckEventHandler
        AddHandler txtKENSYU_DEKIDAKA.Enter, AddressOf ErrorCheckEventHandler
        AddHandler txtSIHARAI_GENKINRITU.Enter, AddressOf ErrorCheckEventHandler
        AddHandler txtSIHARAI_TEGATARITU.Enter, AddressOf ErrorCheckEventHandler
        AddHandler txtSITE.Enter, AddressOf ErrorCheckEventHandler
        AddHandler txtDAIHYONAME.Enter, AddressOf ErrorCheckEventHandler
        AddHandler txtKEISYOUCODE.Enter, AddressOf ErrorCheckEventHandler
        AddHandler txtSIHARAIBI0.Enter, AddressOf ErrorCheckEventHandler
        AddHandler txtSIHARAIKBN0.Enter, AddressOf ErrorCheckEventHandler

        'フォーカス取得時イベント(ImeMode = Hiragana)
        AddHandler txtGINKOU.Enter, AddressOf EnterEventHandlerImeHiragana
        AddHandler txtRYAKUNAME.Enter, AddressOf EnterEventHandlerImeHiragana
        AddHandler txtSIIRECODE.Enter, AddressOf EnterEventHandlerImeHiragana
        AddHandler txtSIIRENAME.Enter, AddressOf EnterEventHandlerImeHiragana
        AddHandler txtADDRESS.Enter, AddressOf EnterEventHandlerImeHiragana
        AddHandler txtADDRESS1.Enter, AddressOf EnterEventHandlerImeHiragana
        AddHandler txtADDRESS2.Enter, AddressOf EnterEventHandlerImeHiragana
        AddHandler txtTANKANAME.Enter, AddressOf EnterEventHandlerImeHiragana
        AddHandler txtBANKMEIGI.Enter, AddressOf EnterEventHandlerImeHiragana
        AddHandler txtLABEL_NAME.Enter, AddressOf EnterEventHandlerImeHiragana
        AddHandler txtSEISANTINAME.Enter, AddressOf EnterEventHandlerImeHiragana
        AddHandler txtDAIHYONAME.Enter, AddressOf EnterEventHandlerImeHiragana

        'フォーカス取得時イベント(ImeMode = Off)
        AddHandler txtItakuCode.Enter, AddressOf EnterEventHandlerImeOff
        AddHandler txtKOUZA.Enter, AddressOf EnterEventHandlerImeOff
        AddHandler txtTELNO.Enter, AddressOf EnterEventHandlerImeOff
        AddHandler txtFAXNO.Enter, AddressOf EnterEventHandlerImeOff
        AddHandler txtTELNO_K.Enter, AddressOf EnterEventHandlerImeOff
        AddHandler txtLABEL_TELNO.Enter, AddressOf EnterEventHandlerImeOff

        'フォーカス取得時イベント(ImeMode = kanaHalf)
        AddHandler txtMENUKEY.Enter, AddressOf EnterEventHandlerImekanaHalf
        AddHandler txtBANKMEIGIKANA.Enter, AddressOf EnterEventHandlerImekanaHalf

        'テキストボックスEnterキー押下時
        AddHandler txtSIIRECODE.PressEnter, AddressOf TrntxtSIIRECODEKeyDown

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
                AddHandler cControl.Enter, AddressOf txt_Enter
            End If

            ' コントロールの型が CheckBox からの派生型の場合
            If TypeOf cControl Is CheckBox Then
                AddHandler cControl.Enter, AddressOf ErrorCheckEventHandler
                AddHandler cControl.TextChanged, AddressOf ChangeEventHandler
                AddHandler cControl.KeyDown, AddressOf CheckBox_KeyDown
                AddHandler cControl.Enter, AddressOf txt_Enter
            End If

        Next cControl
    End Sub

    Protected Overrides Sub FunctionKeyAction(ByVal sender As System.Object, ByVal e As CommonUtility.WinFormControls.FunctionKeyEventArgs)

        Select Case e.Name

            Case "終了"

                Me.Close()

                Exit Sub

            Case "取消"

                If fraMeisai.Enabled = True And (blnUpdateFlg = True Or DTO.slabelUpdate_bln = True) Then
                    If MessageBoxEx.Show(CommonUtility.MessageCode_Arg0.M003取消してもよろしいですか, PROGRAM_NAME) = System.Windows.Forms.DialogResult.No Then Return
                End If

                画面設定(enumFormStatus.キー入力)

                DTO.sstrMenuValue(10) = ""

                DTO.slabelUpdate_bln = False

                '仕入先プロパティ初期化
                DTO.siirecode_label = ""

                txtSIIRECODE.Focus()

            Case "削除"

                If MessageBoxEx.Show(CommonUtility.MessageCode_Arg0.M002削除してもよろしいですか, PROGRAM_NAME) = System.Windows.Forms.DialogResult.No Then Return

                ExecuteMain(enum更新種別.削除)

                Using wcur As New WaitCursor
                    '画面切り替え
                    画面設定(enumFormStatus.キー入力)
                End Using

                コンボボックス初期化()

            Case "先頭へ", "前へ", "次へ", "最後へ"

                If fraMeisai.Enabled = True And (blnUpdateFlg = True Or blnUpdateFlg_STNAME = True Or DTO.slabelUpdate_bln = True) Then

                    If AllInputValidate() = False Then Exit Sub

                    If MessageBoxEx.Show(CommonUtility.MessageCode_Arg0.M001登録してもよろしいですか, PROGRAM_NAME) = System.Windows.Forms.DialogResult.Yes Then
                        Using wcur As New WaitCursor
                            '更新処理
                            subUpdate()

                            コンボボックス初期化()
                        End Using
                    End If
                End If

                '新規の時だけ表示
                lblItakuCode.Text = vbNullString

                Using wcur As New WaitCursor
                    RecordMove(e.Name)
                End Using

                txtSIIRECODE.Focus()

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

                If fraMeisai.Enabled = True And (blnUpdateFlg = True Or blnUpdateFlg_STNAME = True Or DTO.slabelUpdate_bln = True) Then
                    If AllInputValidate() = False Then Exit Sub

                    If MessageBoxEx.Show(CommonUtility.MessageCode_Arg0.M001登録してもよろしいですか, PROGRAM_NAME) = System.Windows.Forms.DialogResult.No Then Return

                    ExecuteMain(enum更新種別.新規編集)

                    コンボボックス初期化()

                End If

                '新規の時だけ表示
                lblItakuCode.Text = vbNullString

                Using wcur As New WaitCursor
                    '画面切り替え
                    画面設定(enumFormStatus.キー入力)
                End Using
        End Select

        LastFocusedControl.Focus()

    End Sub

    ''' <summary>
    ''' レコード移動
    ''' </summary>
    ''' <param name="MoveCommand"></param>
    ''' <remarks></remarks>
    Private Sub RecordMove(ByVal MoveCommand As String)
        Dim logic As New daMENT0006

        Dim strPrimaryKey As String         'キーコード

        '空値チェック
        If CommonUtility.Utility.NUCheck(txtSIIRECODE.Text) Then
            '先頭・最後ボタン以外不可
            If MoveCommand <> "先頭へ" And MoveCommand <> "最後へ" Then Exit Sub
        End If

        strPrimaryKey = logic.RecordMove(MoveCommand, txtSIIRECODE.Text, PCNAME, PROGRAM_ID)
        If CommonUtility.Utility.NUCheck(strPrimaryKey) Then
            '初期化
            画面設定(enumFormStatus.キー入力)
        Else
            txtSIIRECODE.Text = strPrimaryKey

            TrntxtSIIRECODEKeyDown()
        End If

    End Sub

    ''' <summary>
    ''' 検索画面起動
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub PopupSearchForm()

        '未実装（検索画面を作成していないため）

        Select Case LastFocusedControl.Name
            Case txtSIIRECODE.Name
                '仕入先コード
                '*** 検索画面表示 ***
                Using f As New WinFormBase.SEARCH_SIIRE(0)
                    f.Owner = Me
                    If f.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                        If f.SelectItem IsNot Nothing Then
                            '仕入先コードセット
                            LastFocusedControl.Text = f.SelectItem.Code

                            txtSIIRECODE.Focus()
                            Return
                        Else
                            txtSIIRECODE.Focus()
                        End If
                    End If
                End Using

            Case txtPostNo.Name
                '郵便番号
                Using f As New WinFormBase.SEN0040
                    If f.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                        If f.ItemSelected = True Then
                            '郵便番号セット
                            LastFocusedControl.Text = f.SelectedItem.POSTCODE
                            '住所１値チェック
                            If CommonUtility.Utility.NS(txtADDRESS1.Text) = vbNullString And
                               CommonUtility.Utility.NS(txtADDRESS2.Text) = vbNullString Then
                                txtADDRESS.Text = f.SelectedItem.TODOUFUKEN
                                txtADDRESS1.Text = f.SelectedItem.SIKUTYOUSON & f.SelectedItem.TYOUIKI
                                txtADDRESS2.Text = ""
                            Else
                                If MessageBoxEx.Show(CommonUtility.MessageCode_Arg0.M007書き換えてもよろしいですか, PROGRAM_NAME) = System.Windows.Forms.DialogResult.Yes Then
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
        Dim logic As New daMENT0006

        If 更新 = enum更新種別.削除 Then
            logic.DeleteTable(txtSIIRECODE.Text)
        Else
            'コードの採番
            If NUCheck(txtSIIRECODE.Text) Then
                txtSIIRECODE.Text = ZeroFormat(CodeNumbering.GetNumer(CodeNumbering.enumKbn.M_SIIRE), txtSIIRECODE.MaxLength)
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
            Dim logic As New daMENT0006
            Dim updateData As dtBUK0004.dtMENT0006 = getUpdateValue()
            logic.UpdateTable(updateData)
        End Using
    End Sub

    ''' <summary>
    ''' 更新用データ格納
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function getUpdateValue() As dtBUK0004.dtMENT0006

        Dim updateData As New dtBUK0004.dtMENT0006

        With updateData
            '更新用データ
            .SIIRECODE = txtSIIRECODE.Text
            .SIIRENAME = txtSIIRENAME.Text
            .RYAKUNAME = txtRYAKUNAME.Text
            .MENUKEY = txtMENUKEY.Text
            .POSTNO = txtPostNo.Text
            .ADDRESS = txtADDRESS.Text
            .ADDRESS1 = txtADDRESS1.Text
            .ADDRESS2 = txtADDRESS2.Text
            .ITAKUCODE = txtItakuCode.Text
            .MAILADDRESS = txtMAILADDRESS(0).Text
            .MAILACCOUNT = txtMAILACCOUNT(0).Text
            .MAILDOMAINNAME = txtMAILDOMAINNAME0.Text
            .MAILSENDFLG = IIf(chkMAILSENDFLG(0).Checked, 1, 0).ToString
            .MAILADDRESS1 = txtMAILADDRESS(1).Text
            .MAILACCOUNT1 = txtMAILACCOUNT(1).Text
            .MAILDOMAINNAME1 = txtMAILDOMAINNAME1.Text
            .MAILSENDFLG1 = IIf(chkMAILSENDFLG(1).Checked, 1, 0).ToString
            .MAILDISPFLG = IIf(chkMAILDISPFLG.Checked, 1, 0).ToString
            .MAILTANKADISPFLG = IIf(chkMAILTANKADISPFLG.Checked, 1, 0).ToString
            If chkMAILSENDOBJECTKBN(0).Checked = True Then
                .MAILSENDOBJECTKBN = "0"
            ElseIf chkMAILSENDOBJECTKBN(1).Checked = True Then
                .MAILSENDOBJECTKBN = "1"
            ElseIf chkMAILSENDOBJECTKBN(2).Checked = True Then
                .MAILSENDOBJECTKBN = "2"
            End If
            .PRICEPRIKBN = IIf(chkPRICEPRIKBN.Checked, 1, 0).ToString
            .LABEL_NAME = txtLABEL_NAME.Text
            .LABEL_TELNO = txtLABEL_TELNO.Text
            .TELNO = txtTELNO.Text
            .FAXNO = txtFAXNO.Text
            .TELNO_K = txtTELNO_K.Text
            .GINKOU = txtGINKOU.Text
            .BANKCODE = txtBANKCODE.Text
            .BANKSUBCODE = txtBANKSUBCODE.Text
            .BANKKOUZAKBN = txtBANKKOUZAKBN.Text
            .KOUZA = txtKOUZA.Text
            .BANKMEIGI = txtBANKMEIGI.Text
            .BANKMEIGIKANA = txtBANKMEIGIKANA.Text
            .LOCALCODE = txtLOCALCODE.Text
            .TANKACODE = txtTANKACODE.Text
            .TANKANAME = txtTANKANAME.Text
            .SIHARAICODE = txtSIIRECODE.Text
            .SOSINCODE = txtSOSINCODE.Text
            .TANTOCODE = txtTANTOCODE.Text
            .SIMEBI1 = txtSIMEBI(0).Text
            .SIMEBI2 = txtSIMEBI(1).Text
            .SIMEBI3 = txtSIMEBI(2).Text
            .SIHARAIKBN1 = txtSIHARAIKBN(0).Text
            .SIHARAIKBN2 = txtSIHARAIKBN(1).Text
            .SIHARAIKBN3 = txtSIHARAIKBN(2).Text
            .SIHARAIBI1 = txtSIHARAIBI(0).Text
            .SIHARAIBI2 = txtSIHARAIBI(1).Text
            .SIHARAIBI3 = txtSIHARAIBI(2).Text
            .SEISANTINAME = txtSEISANTINAME.Text
            .ZEIROUND = txtZEIROUND.Text
            .SUROUND = txtSUROUND.Text
            .KINROUND = txtKINROUND.Text
            .SYOHIZEIKBN = txtSYOHIZEIKBN.Text
            .ZANKANRIKBN = txtZANKANRIKBN.Text
            .GENKAKAKIKAEKBN = txtGENKAKAKIKAEKBN.Text
            .ZEIKBN = txtZEIKBN.Text
            .SOSINFLG = txtSOSINFLG.Text
            .TESURITU_1 = txtTESURITU1.Text
            .TESURITU_2 = txtTESURITU2.Text
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
            .ENDSIIDATE = txtENDSIIDATE.Text
            .KEIYAKUDATE = txtKEIYAKUDATE.Text
            .KENSYU_DEKIDAKA = txtKENSYU_DEKIDAKA.Text
            .SIHARAI_GENKINRITU = txtSIHARAI_GENKINRITU.Text
            .SIHARAI_TEGATARITU = txtSIHARAI_TEGATARITU.Text
            .SITE = txtSITE.Text
            .DAIHYONAME = txtDAIHYONAME.Text
            .KEISYOUCODE = txtKEISYOUCODE.Text
        End With

        Return updateData

    End Function

    ''' <summary>
    ''' 仕入先コードEnterキー押下時の処理本体
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub TrntxtSIIRECODEKeyDown()

        Using wcur As New WaitCursor
            If NUCheck(txtSIIRECODE.Text) Then
                'フォーム切替
                FormSwitch(enumFormStatus.明細入力)

            Else
                '仕入先マスタの取得
                Dim M_SIIRE As New M_SIIRERead(txtSIIRECODE.Text)
                Dim dt As dsM_SIIRE.M_SIIREDataTable = M_SIIRE.GetM_SIIRE.M_SIIRE

                If dt.Rows.Count > 0 Then
                    'フォーム切替
                    FormSwitch(enumFormStatus.明細入力, dt)
                Else
                    'フォーム切替
                    FormSwitch(enumFormStatus.明細入力)
                End If
            End If
        End Using

        'フォーカス移動
        txtSIIRENAME.Focus()

    End Sub

    ''' <summary>
    ''' フォーカス取得時イベント(ImeMode = Hiragana)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub EnterEventHandlerImeHiragana(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.ActiveControl.ImeMode = System.Windows.Forms.ImeMode.Hiragana
    End Sub

    ''' <summary>
    ''' フォーカス取得時イベント(ImeMode = Off)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub EnterEventHandlerImeOff(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.ActiveControl.ImeMode = System.Windows.Forms.ImeMode.Off
    End Sub

    ''' <summary>
    ''' フォーカス取得時イベント(ImeMode = KatakanaHalf)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub EnterEventHandlerImekanaHalf(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.ActiveControl.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
    End Sub

    ''' <summary>
    ''' フォーカス取得時イベント（F9ボタン切替）
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txt_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Me.ActiveControl.Name = txtSIIRECODE.Name Or Me.ActiveControl.Name = txtPostNo.Name Then
            FunctionKey.SetItem(9, "検索", "検索", True)
        Else
            FunctionKey.SetItem(9, "検索", "検索", False)
        End If
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
            '仕入先名
            If .Name = txtSIIRENAME.Name Then
                blnNameUpdateFlg = True
            End If
            '郵便番号
            If .Name = txtPostNo.Name Then
                blnPostChkFlg = False
            End If
            If .Name = txtTELNO.Name Then
                blnTellChkFlg = False
            End If
            If .Name = txtFAXNO.Name Then
                blnFAXChkFlg = False
            End If

        End With
    End Sub

    ''' <summary>
    ''' チェックボックスEnterキー押下時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CheckBox_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        'キーコード確認
        If Not e.KeyCode = Keys.Enter Then Exit Sub

        With Me.ActiveControl
            If .Name = chkMAILDISPFLG.Name Then
                txtZEIROUND.Focus()
            Else
                SendKeys.Send("{TAB}")
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

        '最終項目の0変換
        If CommonUtility.Utility.NUCheck(txtZEIKBN.Text) = True Then
            txtZEIKBN.Text = "0"
        End If

        If txtSIIRECODE.Enabled = True Then
            '仕入先コード
            CheckResult = InputErrorCheck_Control(txtSIIRECODE, tabOrder)
            If CheckResult.HasValue Then Return CheckResult.Value
        End If

        '仕入先名
        With txtSIIRENAME
            If GetTabOrder(txtSIIRENAME) >= tabOrder Then
                Return True
            Else
                '未入力チェック
                If CommonUtility.Utility.NUCheck(.Text) Then
                    MessageBoxEx.Show(CommonUtility.MessageCode_Arg1.M017を確認して下さい, .DisplayName, PROGRAM_NAME)
                    .Focus()
                    Return False
                End If

                blnNameUpdateFlg = False
                strBankMeigiKana = ""
            End If
        End With

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

        '代表者名
        CheckResult = InputErrorCheck_Control(txtDAIHYONAME, tabOrder)
        If CheckResult.HasValue Then Return CheckResult.Value

        '締日
        CheckResult = InputErrorCheck_Control(txtSIMEBI0, tabOrder)
        If CheckResult.HasValue Then Return CheckResult.Value
        If CommonUtility.Utility.NUCheck(txtSIMEBI0.Text) = True Then
            txtSIMEBI0.Text = "0"
        End If

        '支払日
        CheckResult = InputErrorCheck_Control(txtSIHARAIBI0, tabOrder)
        If CheckResult.HasValue Then Return CheckResult.Value
        If CommonUtility.Utility.NUCheck(txtSIHARAIBI0.Text) = True Then
            txtSIHARAIBI0.Text = "0"
        End If

        '検収出来高
        CheckResult = InputErrorCheck_Control(txtKENSYU_DEKIDAKA, tabOrder)
        If CheckResult.HasValue Then Return CheckResult.Value
        If CommonUtility.Utility.NUCheck(txtKENSYU_DEKIDAKA.Text) = True Then
            txtKENSYU_DEKIDAKA.Text = "0"
        End If

        '支払現金率
        CheckResult = InputErrorCheck_Control(txtSIHARAI_GENKINRITU, tabOrder)
        If CheckResult.HasValue Then Return CheckResult.Value
        If CommonUtility.Utility.NUCheck(txtSIHARAI_GENKINRITU.Text) = True Then
            txtSIHARAI_GENKINRITU.Text = "0"
        End If

        '支払手形率
        CheckResult = InputErrorCheck_Control(txtSIHARAI_TEGATARITU, tabOrder)
        If CheckResult.HasValue Then Return CheckResult.Value
        If CommonUtility.Utility.NUCheck(txtSIHARAI_TEGATARITU.Text) = True Then
            txtSIHARAI_TEGATARITU.Text = "0"
        End If

        'サイト
        CheckResult = InputErrorCheck_Control(txtSITE, tabOrder)
        If CheckResult.HasValue Then Return CheckResult.Value
        If CommonUtility.Utility.NUCheck(txtSITE.Text) = True Then
            txtSITE.Text = "0"
        End If

        '支払区分
        If GetTabOrder(txtSIHARAIKBN0) >= tabOrder Then
            Return True
        Else
            With txtSIHARAIKBN0
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

        '数量丸め区分
        If GetTabOrder(txtSUROUND) >= tabOrder Then
            Return True
        Else
            With txtSUROUND
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

        '金額丸め区分
        If GetTabOrder(txtKINROUND) >= tabOrder Then
            Return True
        Else
            With txtKINROUND
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
            ''初期化
            dtCopy.Clear()

            ''情報セット
            subSetM_SIIRE(dtCopy)

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
                If (.Item("SIIRECODE").ToString = vbNullString) Then Exit Function

                'データセット
                txtSIIRENAME.Text = .Item("SIIRENAME").ToString                                     '仕入先名
                txtRYAKUNAME.Text = .Item("RYAKUNAME").ToString                                     '略称名
                txtMENUKEY.Text = .Item("MENUKEY").ToString                                         'メニューキー
                txtPostNo.Text = .Item("POSTNO").ToString                                           '郵便番号
                txtADDRESS.Text = .Item("ADDRESS").ToString                                         '都道府県
                txtADDRESS1.Text = .Item("ADDRESS1").ToString                                       '住所１
                txtADDRESS2.Text = .Item("ADDRESS2").ToString                                       '住所２
                txtItakuCode.Text = vbNullString                                                    '委託コード
                txtMAILADDRESS0.Text = .Item("MAILADDRESS").ToString                                'メールアドレス
                txtMAILACCOUNT(0).Text = .Item("MAILACCOUNT").ToString                              'メールアカウント
                txtMAILDOMAINNAME0.Text = .Item("MAILDOMAINNAME").ToString                          'メールドメイン名
                chkMAILSENDFLG(0).Checked = CType(.Item("MAILSENDFLG").ToString, Boolean)           'メール送信フラグ
                txtMAILADDRESS(1).Text = .Item("MAILADDRESS1").ToString                             'メールアドレス１
                txtMAILACCOUNT(1).Text = .Item("MAILACCOUNT1").ToString                             'メールアカウント１
                txtMAILDOMAINNAME1.Text = .Item("MAILDOMAINNAME1").ToString                         'メールドメイン名１
                chkMAILSENDFLG(1).Checked = CType(.Item("MAILSENDFLG1").ToString, Boolean)          'メール送信フラグ１
                chkMAILDISPFLG.Checked = CType(.Item("MAILDISPFLG").ToString, Boolean)              'メール金額表示区分
                chkMAILTANKADISPFLG.Checked = CType(.Item("MAILTANKADISPFLG").ToString, Boolean)    'メール単価表示区分
                chkMAILSENDOBJECTKBN(0).Checked = False                                             'メール送信対象区分
                chkMAILSENDOBJECTKBN(1).Checked = False                                             'メール送信対象区分
                chkMAILSENDOBJECTKBN(2).Checked = False                                             'メール送信対象区分
                If Not CommonUtility.Utility.NUCheck(.Item("MAILSENDOBJECTKBN")) Then
                    chkMAILSENDOBJECTKBN(CType(.Item("MAILSENDOBJECTKBN"), Integer)).Checked = True 'メール送信対象区分
                End If
                chkPRICEPRIKBN.Checked = CType(.Item("PRICEPRIKBN").ToString, Boolean)              '価格印字区分
                txtLABEL_NAME.Text = .Item("LABEL_NAME").ToString                                   'ラベル用自社名
                txtLABEL_TELNO.Text = .Item("LABEL_TELNO").ToString                                 'ラベル用電話番号
                txtTELNO.Text = .Item("TELNO").ToString                                             '電話番号
                txtFAXNO.Text = .Item("FAXNO").ToString                                             'FAX番号
                txtTELNO_K.Text = .Item("TELNO_K").ToString                                         '携帯番号   
                txtGINKOU.Text = .Item("GINKOU").ToString                                           '銀行名称
                txtBANKCODE.Text = .Item("BANKCODE").ToString                                       '銀行コード
                txtBANKSUBCODE.Text = .Item("BANKSUBCODE").ToString                                 '支店コード
                txtBANKKOUZAKBN.Text = .Item("BANKKOUZAKBN").ToString
                txtBANKKOUZAKBNNAME.Text = ""
                txtKOUZA.Text = .Item("KOUZA").ToString                                             '口座番号
                txtBANKMEIGI.Text = .Item("BANKMEIGI").ToString                                     '名義漢字
                txtBANKMEIGIKANA.Text = .Item("BANKMEIGIKANA").ToString                             '名義カナ
                txtLOCALCODE.Text = .Item("LOCALCODE").ToString                                     '地区コード
                txtTANKACODE.Text = .Item("TANKACODE").ToString                                     '単価コード
                txtSOSINCODE.Text = .Item("SOSINCODE").ToString                                     '送信先コード
                txtTANTOCODE.Text = .Item("TANTOCODE").ToString                                     '担当者コード
                txtSIMEBI(0).Text = .Item("SIMEBI1").ToString                                       '締日１
                txtSIMEBI(1).Text = .Item("SIMEBI2").ToString                                       '締日２
                txtSIMEBI(2).Text = .Item("SIMEBI3").ToString                                       '締日３
                txtSIHARAIKBN(0).Text = .Item("SIHARAIKBN1").ToString                               '支払区分１(サイクル)
                txtSIHARAIKBN(1).Text = .Item("SIHARAIKBN2").ToString                               '支払区分２(サイクル)
                txtSIHARAIKBN(2).Text = .Item("SIHARAIKBN3").ToString                               '支払区分３(サイクル)
                txtSIHARAIBI(0).Text = .Item("SIHARAIBI1").ToString                                 '支払日１
                txtSIHARAIBI(1).Text = .Item("SIHARAIBI2").ToString                                 '支払日２
                txtSIHARAIBI(2).Text = .Item("SIHARAIBI3").ToString                                 '支払日３
                txtSEISANTINAME.Text = .Item("SEISANTINAME").ToString                               '生産地名  
                txtZEIROUND.Text = .Item("ZEIROUND").ToString                                       '税丸め区分
                txtSUROUND.Text = .Item("SUROUND").ToString                                         '数量丸め区分
                txtKINROUND.Text = .Item("KINROUND").ToString                                       '金額丸め区分
                txtSYOHIZEIKBN.Text = .Item("SYOHIZEIKBN").ToString                                 '消費税区分
                txtZANKANRIKBN.Text = .Item("ZANKANRIKBN").ToString                                 '残管理区分
                txtGENKAKAKIKAEKBN.Text = .Item("GENKAKAKIKAEKBN").ToString                         '原価書換区分
                txtZEIKBN.Text = .Item("ZEIKBN").ToString                                           '税区分
                txtSOSINFLG.Text = .Item("SOSINFLG").ToString                                       '送信フラグ
                txtTESURITU1.Text = .Item("TESURITU_1").ToString                                    '手数料率１
                txtTESURITU2.Text = .Item("TESURITU_2").ToString                                    '手数料率２
                If .Item("KEIYAKUDATE").ToString <> "0" Then
                    txtKEIYAKUDATE.Text = .Item("KEIYAKUDATE").ToString                             '契約日付
                Else
                    txtKEIYAKUDATE.Text = vbNullString                                              '契約日付
                End If
                txtKENSYU_DEKIDAKA.Text = .Item("KENSYU_DEKIDAKA").ToString                         '検収出来高
                txtSIHARAI_GENKINRITU.Text = .Item("SIHARAI_GENKINRITU").ToString                   '支払現金率
                txtSIHARAI_TEGATARITU.Text = .Item("SIHARAI_TEGATARITU").ToString                   '支払手形率
                txtSITE.Text = .Item("SITE").ToString                                               'サイト
                txtDAIHYONAME.Text = .Item("DAIHYONAME").ToString                                   '代表者名
                txtKEISYOUCODE.Text = .Item("KEISYOUCODE").ToString                                 '敬称コード

            End With

        End Using

        '戻り値
        fncPaste = True

    End Function

    ''' <summary>
    ''' コピーデータ格納
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub subSetM_SIIRE(ByRef dt As dsMENT0006.M_SIIRE_COPYDataTable)

        Dim dr As dsMENT0006.M_SIIRE_COPYRow

        dr = dt.NewM_SIIRE_COPYRow

        dr("SIIRECODE") = txtSIIRECODE.Text                                 '仕入先コード
        dr("SIIRENAME") = txtSIIRENAME.Text                                 '仕入先名
        dr("RYAKUNAME") = txtRYAKUNAME.Text                                 '略称名
        dr("MENUKEY") = txtMENUKEY.Text                                     'メニューキー
        dr("POSTNO") = txtPostNo.Text                                       '郵便番号
        dr("ADDRESS") = txtADDRESS.Text                                     '都道府県
        dr("ADDRESS1") = txtADDRESS1.Text                                   '住所１
        dr("ADDRESS2") = txtADDRESS2.Text                                   '住所２
        dr("ITAKUCODE") = txtItakuCode.Text                                 '委託コード
        dr("MAILADDRESS") = txtMAILADDRESS(0).Text                          'メールアドレス
        dr("MAILACCOUNT") = txtMAILACCOUNT(0).Text                          'メールアカウント
        dr("MAILDOMAINNAME") = txtMAILDOMAINNAME0.Text                      'メールドメイン名
        dr("MAILSENDFLG") = IIf(chkMAILSENDFLG(0).Checked, "1", "0")        'メール送信フラグ
        dr("MAILADDRESS1") = txtMAILADDRESS(1).Text                         'メールアドレス１
        dr("MAILACCOUNT1") = txtMAILACCOUNT(1).Text                         'メールアカウント１
        dr("MAILDOMAINNAME1") = txtMAILDOMAINNAME1.Text                     'メールドメイン名１
        dr("MAILSENDFLG1") = IIf(chkMAILSENDFLG(1).Checked, "1", "0")       'メール送信フラグ１
        dr("MAILDISPFLG") = IIf(chkMAILDISPFLG.Checked, "1", "0")           'メール金額表示区分
        dr("MAILTANKADISPFLG") = IIf(chkMAILTANKADISPFLG.Checked, "1", "0") 'メール単価表示区分
        If chkMAILSENDOBJECTKBN(0).Checked = True Then
            dr("MAILSENDOBJECTKBN") = "0"                                   'メール送信対象区分
        ElseIf chkMAILSENDOBJECTKBN(1).Checked = True Then
            dr("MAILSENDOBJECTKBN") = "1"                                   'メール送信対象区分
        ElseIf chkMAILSENDOBJECTKBN(2).Checked = True Then
            dr("MAILSENDOBJECTKBN") = "2"                                   'メール送信対象区分
        End If
        dr("PRICEPRIKBN") = IIf(chkPRICEPRIKBN.Checked, "1", "0")           '価格印字区分
        dr("LABEL_NAME") = txtLABEL_NAME.Text                               'ラベル用自社名
        dr("LABEL_TELNO") = txtLABEL_TELNO.Text                             'ラベル用電話番号
        dr("TELNO") = txtTELNO.Text                                         '電話番号
        dr("FAXNO") = txtFAXNO.Text                                         'FAX番号
        dr("TELNO_K") = txtTELNO_K.Text                                     '携帯番号
        dr("GINKOU") = txtGINKOU.Text                                       '銀行名称
        dr("BANKCODE") = txtBANKCODE.Text                                   '銀行コード
        dr("BANKSUBCODE") = txtBANKSUBCODE.Text                             '支店コード
        dr("BANKKOUZAKBN") = txtBANKKOUZAKBN.Text                           '口座区分
        dr("KOUZA") = txtKOUZA.Text                                         '口座番号
        dr("BANKMEIGI") = txtBANKMEIGI.Text                                 '名義漢字
        dr("BANKMEIGIKANA") = txtBANKMEIGIKANA.Text                         '名義カナ
        dr("LOCALCODE") = txtLOCALCODE.Text                                 '地区コード
        dr("TANKACODE") = txtTANKACODE.Text                                 '単価コード
        dr("SOSINCODE") = txtSOSINCODE.Text                                 '送信先コード
        dr("TANTOCODE") = txtTANTOCODE.Text                                 '担当者コード
        dr("SIMEBI1") = txtSIMEBI(0).Text                                   '締日１
        dr("SIMEBI2") = txtSIMEBI(1).Text                                   '締日２
        dr("SIMEBI3") = txtSIMEBI(2).Text                                   '締日３
        dr("SIHARAIKBN1") = txtSIHARAIKBN(0).Text                           '支払区分１(サイクル)
        dr("SIHARAIKBN2") = txtSIHARAIKBN(1).Text                           '支払区分２(サイクル)
        dr("SIHARAIKBN3") = txtSIHARAIKBN(2).Text                           '支払区分３(サイクル)
        dr("SIHARAIBI1") = txtSIHARAIBI(0).Text                             '支払日１
        dr("SIHARAIBI2") = txtSIHARAIBI(1).Text                             '支払日２
        dr("SIHARAIBI3") = txtSIHARAIBI(2).Text                             '支払日３
        dr("SEISANTINAME") = txtSEISANTINAME.Text                           '生産地名
        dr("ZEIROUND") = txtZEIROUND.Text                                   '税丸め区分
        dr("SUROUND") = txtSUROUND.Text                                     '数量丸め区分
        dr("KINROUND") = txtKINROUND.Text                                   '金額丸め区分
        dr("SYOHIZEIKBN") = txtSYOHIZEIKBN.Text                             '消費税区分
        dr("ZANKANRIKBN") = txtZANKANRIKBN.Text                             '残管理区分
        dr("GENKAKAKIKAEKBN") = txtGENKAKAKIKAEKBN.Text                     '原価書換区分
        dr("ZEIKBN") = txtZEIKBN.Text                                       '税区分
        dr("SOSINFLG") = txtSOSINFLG.Text                                   '送信フラグ
        dr("TESURITU_1") = txtTESURITU1.Text                                '手数料率１
        dr("TESURITU_2") = txtTESURITU2.Text                                '手数料率２
        dr("KEIYAKUDATE") = txtKEIYAKUDATE.Text                             '契約日付
        dr("KENSYU_DEKIDAKA") = txtKENSYU_DEKIDAKA.Text                     '検収出来高
        dr("SIHARAI_GENKINRITU") = txtSIHARAI_GENKINRITU.Text               '支払現金率
        dr("SIHARAI_TEGATARITU") = txtSIHARAI_TEGATARITU.Text               '支払手形率
        dr("SITE") = txtSITE.Text                                           'サイト
        dr("DAIHYONAME") = txtDAIHYONAME.Text                               '代表者名
        dr("KEISYOUCODE") = txtKEISYOUCODE.Text                             '敬称コード

        dt.AddM_SIIRE_COPYRow(dr)

        blnCopy = True
        FunctionKey.SetItem(11, "貼付", "貼付", True)

    End Sub

    '未実装（M_KEN未作成、検索画面未作成）
    ''' <summary>
    ''' 住所マスタ読込
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function fncPost_Read() As Boolean
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
                If MessageBoxEx.Show(CommonUtility.MessageCode_Arg0.M007書き換えてもよろしいですか, PROGRAM_NAME) = System.Windows.Forms.DialogResult.Yes Then
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
                        If MessageBoxEx.Show(CommonUtility.MessageCode_Arg0.M007書き換えてもよろしいですか, PROGRAM_NAME) = System.Windows.Forms.DialogResult.Yes Then
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

    ''' <summary>
    ''' 仕入先マスタから最大仕入先コード取得 + 1
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub subGet_M_SiireMax()

        Dim strITAKUCODE As String
        Dim logic As New daMENT0006

        Dim dtSiireMax As dsMENT0006.M_SIIREMAXDataTable = logic.ReadM_SIIREMAX()

        With dtSiireMax
            If .Rows.Count > 0 Then
                If Not CommonUtility.Utility.NUCheck(.Rows(0)("ITAKUCODE").ToString) Then
                    strITAKUCODE = CommonUtility.Utility.NZ(.Rows(0)("ITAKUCODE")).ToString
                    If strITAKUCODE = "99999" Then
                        '最小空き番取得
                        Dim dtItakuMin As dsMENT0006.ITAKUCODEMINDataTable = logic.ReadITAKUCODEMIN()

                        strITAKUCODE = CommonUtility.Utility.NZ(dtItakuMin.Rows(0)("ITAKUCODE")).ToString
                        If strITAKUCODE = "100000" Then
                            lblItakuCode.Text = "(99999)"
                        Else
                            lblItakuCode.Text = "(" & CommonUtility.Utility.ZeroPadding(strITAKUCODE, 5) & ")"
                        End If
                    Else
                        lblItakuCode.Text = "(" & CommonUtility.Utility.ZeroPadding((CType(strITAKUCODE, Integer) + 1).ToString, 5) & ")"
                    End If
                End If
            End If
        End With

    End Sub

    ''' <summary>
    ''' 促音(ｯ→ﾂ)・拗音文字(ｬ→ﾔ)を変換する
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function pfncKanaConv(ByVal strdata As String) As String

        '促音・拗音を変換
        strdata = Replace(strdata, "ｧ", "ｱ")
        strdata = Replace(strdata, "ｨ", "ｲ")
        strdata = Replace(strdata, "ｩ", "ｳ")
        strdata = Replace(strdata, "ｪ", "ｴ")
        strdata = Replace(strdata, "ｫ", "ｵ")
        strdata = Replace(strdata, "ｬ", "ﾔ")
        strdata = Replace(strdata, "ｭ", "ﾕ")
        strdata = Replace(strdata, "ｮ", "ﾖ")
        strdata = Replace(strdata, "ｯ", "ﾂ")

        '文字を返す
        pfncKanaConv = strdata

    End Function

    '文字列のﾊﾞｲﾄ数を取得
    Public Shared Function LenB(ByVal stTarget As String) As Integer
        Return System.Text.Encoding.GetEncoding("Shift_JIS").GetByteCount(stTarget)
    End Function

    'テキストボックス
    Private Function txtSIMEBI(ByVal index As Integer) As TextBox
        Dim c As Control() = Me.Controls.Find("txtSIMEBI" + index.ToString, True)
        Return CType(c(0), TextBox)
    End Function
    Private Function txtSIHARAIKBN(ByVal index As Integer) As TextBox
        Dim c As Control() = Me.Controls.Find("txtSIHARAIKBN" + index.ToString, True)
        Return CType(c(0), TextBox)
    End Function
    Private Function txtSIHARAIBI(ByVal index As Integer) As TextBox
        Dim c As Control() = Me.Controls.Find("txtSIHARAIBI" + index.ToString, True)
        Return CType(c(0), TextBox)
    End Function
    Private Function txtYOSAN(ByVal index As Integer) As TextBox
        Dim c As Control() = Me.Controls.Find("txtYOSAN" + index.ToString, True)
        Return CType(c(0), TextBox)
    End Function
    Private Function txtMAILADDRESS(ByVal index As Integer) As TextBox
        Dim c As Control() = Me.Controls.Find("txtMAILADDRESS" + index.ToString, True)
        Return CType(c(0), TextBox)
    End Function
    Private Function txtMAILACCOUNT(ByVal index As Integer) As TextBox
        Dim c As Control() = Me.Controls.Find("txtMAILACCOUNT" + index.ToString, True)
        Return CType(c(0), TextBox)
    End Function

    'チェックボックス
    Private Function chkMAILSENDFLG(ByVal index As Integer) As CheckBox
        Dim c As Control() = Me.Controls.Find("chkMAILSENDFLG" + index.ToString, True)
        Return CType(c(0), CheckBox)
    End Function
    Private Function chkMAILSENDOBJECTKBN(ByVal index As Integer) As CheckBox
        Dim c As Control() = Me.Controls.Find("chkMAILSENDOBJECTKBN" + index.ToString, True)
        Return CType(c(0), CheckBox)
    End Function

    Private Sub txtLOCALCODE_PressEnter(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txtSIIRENAME_CompositionEventHandler(ByVal sender As Object, ByVal e As CommonUtility.WinFormControls.CompositionEventArgs) Handles txtSIIRENAME.CompositionEventHandler
        Dim i As Integer = 0
        i = txtMENUKEY.MaxLength - txtMENUKEY.Text.Length
        txtMENUKEY.Text += e.ImeString.Substring(0, CType(IIf(i > e.ImeString.Length, e.ImeString.Length, i), Integer))
    End Sub
End Class
