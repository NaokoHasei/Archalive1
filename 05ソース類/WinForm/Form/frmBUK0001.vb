Imports CommonUtility
Imports CommonUtility.Utility
Imports CommonUtility.WinForm
Imports CommonUtility.WinFormControls
Imports BLL.Common

Public Class frmBUK0001
    Private daBUK0001 As New daBUK0001
    Private T_BUKKEN As New T_BUKKENRead
    Private T_BUKKEN_APPROVAL As New T_BUKKEN_APPROVALRead
    Private T_MITUMORI As New T_MITUMORIRead
    Private T_JYUTYU As New T_JYUTYURead
    Private T_HATYU As New T_HATYURead
    Private T_SEIKYU As New T_SEIKYURead

    Public Overrides Function PROGRAM_ID() As String
        Return "BUK0001"
    End Function

    Public Overrides Function PROGRAM_NAME() As String
        Return "物件登録"
    End Function

    Private blnUpdateFlg As Boolean                 '更新フラグs
    Private postNoBef As String                     '郵便番号（編集前）

    Public requestBUK0001 As New requestBUK0001
    Public requestMAP0001 As New requestMAP0001
    Public responseMAP0001 As New responseMAP0001

    Private enumParentDispValue As enumParentDisp

    Private Enum enumParentDisp
        MENU
        SEARCH
    End Enum

    Public Sub New()
        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。

        requestBUK0001 = New requestBUK0001
        requestBUK0001.BUKKEN_NO = 0
    End Sub

    Protected Overrides Sub Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)

        MyBase.Form_Load(sender, e)

        Using wcur As New WaitCursor

            'コンボボックス初期化
            InitComboBox()

            'イベント設定
            InitEvent()

            '元請登録ボタンの表示制御
            Dim siyoKinouAuthority = New SiyoKinouAuthority(TANTO_CODE)
            btnMENT0005.Visible = siyoKinouAuthority.CheckUseKinou(SiyoKinouAuthority.CONST_顧客マスタ登録)

            '画面初期化
            InitDisp()

            '引数を受け取る
            If requestBUK0001.BUKKEN_NO = 0 Then
                TitleBar.EditMode = EditMode.None
                enumParentDispValue = enumParentDisp.MENU

            Else
                TitleBar.EditMode = EditMode.Edit
                enumParentDispValue = enumParentDisp.SEARCH

                '物件Noの保持
                txtBukkenNo.Text = ZeroPadding(requestBUK0001.BUKKEN_NO.ToString, txtBukkenNo.MaxLength)

                '編集モードの初期表示
                If Not DispEditMode() Then
                    Me.Close()
                    Return
                End If
            End If

            '表示制御
            InitEnabled()

            'ファンクションキー設定
            InitFunctionKey()

            '住所変更イベント
            ChangeAddress(Nothing, Nothing)
        End Using

    End Sub

    ''' <summary>
    ''' 画面初期化
    ''' </summary>
    Private Sub InitDisp()
        txtBukkenNo.Text = vbNullString
        txtBukkenNo.Text = vbNullString
        txtBukkenName.Text = vbNullString
        txtKoushu.Text = vbNullString
        txtPostNo.Text = vbNullString
        txtAddress.Text = vbNullString
        txtAddress1.Text = vbNullString
        txtAddress2.Text = vbNullString
        txtLng.Text = vbNullString
        txtLat.Text = vbNullString
        txtMotoukeCode.Text = vbNullString
        txtMotoukeName.Text = vbNullString
        txtTantoCode.Text = Utility.ZeroPadding(NowUserInfo.TANTOCODE, 4)
        txtChakkouDate.Text = vbNullString
        txtKankouDate.Text = vbNullString

        postNoBef = txtPostNo.Text

        lblMessage1.Visible = False
        lblMessage2.Visible = False
        lblMessage3.Visible = False

        blnUpdateFlg = False
    End Sub

    ''' <summary>
    ''' コンボボックス初期化
    ''' </summary>
    Private Sub InitComboBox()
        Dim logic As New BLL.Common.TypComboBox

        Dim paramlist As New List(Of Model.DTO.RequestGetComboBoxContentsElement)
        paramlist.Add(New Model.DTO.RequestGetComboBoxContentsElement(Model.ComboBoxTableName.M_TOKUI, Model.DTO.GetComboBoxContentsResultFieldType.MultipleField, False, Nothing))
        paramlist.Add(New Model.DTO.RequestGetComboBoxContentsElement(Model.ComboBoxTableName.M_TANTO, Model.DTO.GetComboBoxContentsResultFieldType.MultipleField, False, Nothing))

        Dim requestParam As New Model.DTO.RequestGetComboBoxContents(paramlist)
        Dim recieveParam As Model.DTO.ResponseGetComboBoxContents

        recieveParam = logic.CreateComboBox(requestParam)

        txtMotoukeCode.AttachDataSource(Model.ComboBoxTableName.M_TOKUI, recieveParam)
        txtTantoCode.AttachDataSource(Model.ComboBoxTableName.M_TANTO, recieveParam)
    End Sub

    ''' <summary>
    ''' イベント設定
    ''' </summary>
    Private Sub InitEvent()

        AddHandlerControl(Me)

        'フォーカス取得時イベント(IMEの設定)
        AddHandler txtBukkenName.Enter, AddressOf EnterEventHandlerImeHiragana
        AddHandler txtKoushu.Enter, AddressOf EnterEventHandlerImeHiragana
        AddHandler txtAddress.Enter, AddressOf EnterEventHandlerImeHiragana
        AddHandler txtAddress1.Enter, AddressOf EnterEventHandlerImeHiragana
        AddHandler txtAddress2.Enter, AddressOf EnterEventHandlerImeHiragana
        AddHandler txtPostNo.Enter, AddressOf EnterEventHandlerImeOff

        '検索ボタン切替
        AddHandler txtBukkenName.Enter, AddressOf ChangeEnabledFunctionKey_Kensaku_Disabled
        AddHandler txtKoushu.Enter, AddressOf ChangeEnabledFunctionKey_Kensaku_Disabled
        AddHandler txtPostNo.Enter, AddressOf ChangeEnabledFunctionKey_Kensaku_Enabled
        AddHandler txtAddress.Enter, AddressOf ChangeEnabledFunctionKey_Kensaku_Disabled
        AddHandler txtAddress1.Enter, AddressOf ChangeEnabledFunctionKey_Kensaku_Disabled
        AddHandler txtAddress2.Enter, AddressOf ChangeEnabledFunctionKey_Kensaku_Disabled
        AddHandler txtMotoukeCode.Enter, AddressOf ChangeEnabledFunctionKey_Kensaku_Enabled
        AddHandler txtTantoCode.Enter, AddressOf ChangeEnabledFunctionKey_Kensaku_Enabled
        AddHandler txtChakkouDate.Enter, AddressOf ChangeEnabledFunctionKey_Kensaku_Disabled
        AddHandler txtKankouDate.Enter, AddressOf ChangeEnabledFunctionKey_Kensaku_Disabled

        '郵便番号
        AddHandler txtPostNo.Leave, AddressOf CheckPostNo

        '住所
        AddHandler txtAddress.TextChanged, AddressOf ChangeAddress
        AddHandler txtAddress1.TextChanged, AddressOf ChangeAddress
        AddHandler txtAddress2.TextChanged, AddressOf ChangeAddress
    End Sub

    ''' <summary>
    ''' 表示制御
    ''' </summary>
    Private Sub InitEnabled()
        Dim enabled = True
        If TitleBar.EditMode = EditMode.None Then
            enabled = False
        End If

        txtBukkenNo.Enabled = Not enabled

        txtBukkenName.Enabled = enabled
        txtKoushu.Enabled = enabled
        txtPostNo.Enabled = enabled
        txtAddress.Enabled = enabled
        txtAddress1.Enabled = enabled
        txtAddress2.Enabled = enabled
        txtMotoukeCode.Enabled = enabled
        txtTantoCode.Enabled = enabled
        txtChakkouDate.Enabled = enabled
        txtKankouDate.Enabled = enabled
        btnMAP0001.Enabled = enabled
        btnMAP0001_2.Enabled = enabled
        btnMAP0001_3.Enabled = enabled
        btnMENT0005.Enabled = enabled
    End Sub

    ''' <summary>
    ''' ファンクションキー設定
    ''' </summary>
    Private Sub InitFunctionKey()

        FunctionKey.ClearAll()

        If TitleBar.EditMode = EditMode.None Then
            FunctionKey.SetItem(1, "終了", "終了", True)
            Return
        End If

        If enumParentDispValue = enumParentDisp.SEARCH Then
            FunctionKey.SetItem(1, "終了", "終了", True)
        Else
            FunctionKey.SetItem(1, "取消", "取消", True)
        End If
        FunctionKey.SetItem(3, "削除", "削除", True)
        FunctionKey.SetItem(4, "資料", "資料", True)
        FunctionKey.SetItem(5, "見積", "見積", True)
        FunctionKey.SetItem(6, "受注", "受注", True)
        FunctionKey.SetItem(7, "発注", "発注", True)
        FunctionKey.SetItem(8, "請求", "請求", True)
        FunctionKey.SetItem(9, "検索", "検索", False)
        FunctionKey.SetItem(11, "マップ", "マップ", True)
        FunctionKey.SetItem(12, "登録", "登録", True)


        If Me.TitleBar.EditMode = EditMode.Create Then
            '新規モードの場合
            FunctionKey.SetItem(3, "削除", "削除", False)
            FunctionKey.SetItem(4, "資料", "資料", False)
            FunctionKey.SetItem(5, "見積", "見積", False)
            FunctionKey.SetItem(6, "受注", "受注", False)
            FunctionKey.SetItem(7, "発注", "発注", False)
            FunctionKey.SetItem(8, "請求", "請求", False)

        Else
            '編集モードの場合

            '物件承認情報の取得
            Dim drApprovalJyuchu As dsT_BUKKEN_APPROVAL.T_BUKKEN_APPROVALRow = T_BUKKEN_APPROVAL.GetDataWhereGyomuKbn(txtBukkenNo.Text, T_BUKKEN_APPROVALRead.enumGyomuKbn.Jyuchu).Rows(0)
            '見積情報の取得
            Dim dtMitsumori = T_MITUMORI.fncSelectT_MITUMORIHED(txtBukkenNo.Text)
            '受注情報の取得
            Dim dtJyuchu = T_JYUTYU.fncSelectT_JYUTYUHED(txtBukkenNo.Text)
            '発注情報の取得
            Dim dtHacchu = T_HATYU.fncSelectT_HATYUHED(txtBukkenNo.Text)
            '請求情報の取得
            Dim dtSikyu = T_SEIKYU.fncSelectT_SEIKYUHED(txtBukkenNo.Text)

            '見積が存在しない場合
            If dtMitsumori.Rows.Count = 0 Then
                FunctionKey.SetItem(6, "受注", "受注", False)
            End If

            '受注が存在しない、まはた、（受注が未承認、かつ、発注が存在しない）場合
            If dtJyuchu.Rows.Count = 0 OrElse (drApprovalJyuchu.APPROVALKBN = T_BUKKEN_APPROVALRead.enumApprovalKbn.SYONIN_MI And dtHacchu.Rows.Count = 0) Then
                FunctionKey.SetItem(7, "発注", "発注", False)
            End If

            '受注が存在しない、まはた、（受注が未承認、かつ、発注が存在しない）場合
            If dtJyuchu.Rows.Count = 0 OrElse (drApprovalJyuchu.APPROVALKBN = T_BUKKEN_APPROVALRead.enumApprovalKbn.SYONIN_MI And dtSikyu.Rows.Count = 0) Then
                FunctionKey.SetItem(8, "請求", "請求", False)
            End If

            '見積が存在する場合
            If dtMitsumori.Rows.Count <> 0 Then
                FunctionKey.SetItem(5, "見積", "見積", True, New Font("メイリオ", 12, FontStyle.Underline))
                FunctionKey.SetForeColor(5, Color.DarkMagenta)
            End If

            '受注が存在する場合
            If dtJyuchu.Rows.Count <> 0 Then
                FunctionKey.SetItem(6, "受注", "受注", True, New Font("メイリオ", 12, FontStyle.Underline))
                FunctionKey.SetForeColor(6, Color.DarkMagenta)
            End If

            '発注が存在する場合
            If dtHacchu.Rows.Count <> 0 Then
                FunctionKey.SetItem(7, "発注", "発注", True, New Font("メイリオ", 12, FontStyle.Underline))
                FunctionKey.SetForeColor(7, Color.DarkMagenta)
            End If

            '請求が存在する場合
            If dtSikyu.Rows.Count <> 0 Then
                FunctionKey.SetItem(8, "請求", "請求", True, New Font("メイリオ", 12, FontStyle.Underline))
                FunctionKey.SetForeColor(8, Color.DarkMagenta)
            End If
        End If
    End Sub

    ''' <summary>
    ''' 編集モードの初期表示
    ''' </summary>
    Private Function DispEditMode() As Boolean
        '物件トランの取得
        Dim dt As dsT_BUKKEN.T_BUKKENDataTable = T_BUKKEN.GetDataWherePk(txtBukkenNo.Text)

        If dt.Rows.Count = 0 Then
            MessageBoxEx.Show(CommonUtility.MessageCode_Arg0.M009該当データがありません, PROGRAM_NAME)

            Return False
        End If

        'モードの変更
        Me.TitleBar.EditMode = EditMode.Edit

        '物件トランの表示
        Dim dr As dsT_BUKKEN.T_BUKKENRow = dt.Rows(0)
        txtBukkenName.Text = dr.BUKKENNAME
        txtKoushu.Text = dr.KOUSHU
        txtPostNo.Text = dr.POSTNO
        txtAddress.Text = dr.ADDRESS
        txtAddress1.Text = dr.ADDRESS1
        txtAddress2.Text = dr.ADDRESS2
        txtLat.Text = dr.LAT
        txtLng.Text = dr.LNG
        txtMotoukeCode.Text = dr.MOTOUKECODE
        txtMotoukeName.Text = dr.TOKUINAME
        txtTantoCode.Text = dr.TANTOCODE
        txtTantoName.Text = dr.TANTONAME
        txtChakkouDate.Text = dr.CHAKKOUDATE
        txtKankouDate.Text = dr.KANKOUDATE

        postNoBef = txtPostNo.Text

        'メッセージラベル1の表示制御
        ControlMessageLabel1(dr)

        'メッセージラベル2の表示制
        ControlMessageLabel2_3(lblMessage2, T_BUKKEN_APPROVALRead.enumGyomuKbn.Jyuchu)

        'メッセージラベル3の表示制御
        ControlMessageLabel2_3(lblMessage3, T_BUKKEN_APPROVALRead.enumGyomuKbn.Hacchu)

        blnUpdateFlg = False

        Return True
    End Function

    ''' <summary>
    ''' メッセージラベル1の表示制御
    ''' </summary>
    Private Sub ControlMessageLabel1(dr As dsT_BUKKEN.T_BUKKENRow)
        lblMessage1.Visible = False

        '完工日が未入力、または、元請マスタ．支払日が未入力の場合
        If Utility.NUCheck(txtKankouDate.Text) OrElse txtKankouDate.Text = "    /  /" OrElse dr.SIHARAIBI = 0 Then Exit Sub

        'システム日付
        Dim systemDate As Date = Date.Parse(ServerDate.ToString("yyyy/MM/dd"))
        '完工日
        Dim kankouDate As Date = Date.Parse(txtKankouDate.Text)
        '同月の支払日を算出
        Dim siharaibi As Date
        If Not Date.TryParse(kankouDate.ToString("yyyy/MM/") & dr.SIHARAIBI.ToString, siharaibi) Then
            '支払日が不正（2/31、3/99など）の場合、月末日を算出
            siharaibi = New Date(kankouDate.Year, kankouDate.Month, 1)
            siharaibi = siharaibi.AddMonths(1).AddDays(-1)
        End If
        '完工日＞＝支払日の場合、支払日を翌月とする
        If kankouDate >= siharaibi Then
            siharaibi = siharaibi.AddMonths(1)
        End If

        '支払日＜システム日付、かつ、未請求の場合
        If siharaibi < systemDate And Not daBUK0001.GetSeikyuZumi(txtBukkenNo.Text) Then
            lblMessage1.Visible = True
        End If
    End Sub

    ''' <summary>
    ''' メッセージラベル2,3の表示制御
    ''' </summary>
    Private Sub ControlMessageLabel2_3(ByRef lable As Label, ByVal gyomuKbn As T_BUKKEN_APPROVALRead.enumGyomuKbn)
        lable.Visible = False

        '承認済の取得
        Dim dt = T_BUKKEN_APPROVAL.GetDataSyoniZumi(txtBukkenNo.Text, gyomuKbn)

        '承認済が存在しない場合
        If dt.Rows.Count = 0 Then Exit Sub

        lable.Visible = True
    End Sub

    ''' <summary>
    ''' プロット　クリックイベント
    ''' </summary>
    Private Sub btnMAP0001_Click(sender As Object, e As EventArgs) Handles btnMAP0001.Click
        'MAP0001の呼び出し用のパラメータ
        Dim makerList(0) As requestMAP0001.Maker
        makerList(0) = New requestMAP0001.Maker
        makerList(0).BUKKEN_NO = txtBukkenNo.Text
        makerList(0).BUKKEN_NAME = txtBukkenName.Text
        makerList(0).POST_NO = txtPostNo.Text
        makerList(0).ADDRESS = txtAddress.Text & txtAddress1.Text & txtAddress2.Text
        makerList(0).LAT = txtLat.Text
        makerList(0).LNG = txtLng.Text
        requestMAP0001.MAKER_LIST = makerList

        'プロット画面の表示
        Dim f As New frmMAP0001(frmMAP0001.emumDispKbn.PLOT)
        f.requestMAP0001 = requestMAP0001
        f.ShowDispDialog(Me)
    End Sub

    ''' <summary>
    ''' 住所から緯度・経度を取得　クリックイベント
    ''' </summary>
    Private Sub btnMAP0001_2_Click(sender As Object, e As EventArgs) Handles btnMAP0001_2.Click
        'MAP0001 APIの呼び出し用のパラメータ
        Dim req As apiMAP0001.reqestMAP0001 = New apiMAP0001.reqestMAP0001
        req.ADDRESS = txtAddress.Text & txtAddress1.Text & txtAddress2.Text

        'APIの呼び出し
        Dim api As apiMAP0001 = New apiMAP0001(req)
        api.GetLatLngGeocoder()

        'APIの戻り値
        Dim res As apiMAP0001.responseMAP0001 = api.response

        'APIエラー処理
        If res.MESSAGE_ID = "212" Then
            MessageBoxEx.Show(MessageCode_Arg0.M212, PROGRAM_NAME)
            Return
        End If

        If res.MESSAGE_ID = "213" Then
            MessageBoxEx.Show(MessageCode_Arg1.M213, res.MESSAGE_PARAM, PROGRAM_NAME)
            Return
        End If

        '画面に反映
        txtLat.Text = res.LAT
        txtLng.Text = res.LNG
    End Sub

    ''' <summary>
    ''' 緯度・経度をクリア　クリックイベント
    ''' </summary>
    Private Sub btnMAP0001_3_Click(sender As Object, e As EventArgs) Handles btnMAP0001_3.Click
        txtLat.Text = ""
        txtLng.Text = ""
    End Sub

    ''' <summary>
    ''' ファンクションキー　クリックイベント
    ''' </summary>
    Protected Overrides Sub FunctionKeyAction(ByVal sender As System.Object, ByVal e As FunctionKeyEventArgs)

        Select Case e.Name
            Case "取消"
                '編集中の破棄の確認メッセージ
                If Not ShowHensyuHakiMsg() Then Return

                TitleBar.EditMode = EditMode.None

                '画面の初期化
                InitDisp()

                '表示制御
                InitEnabled()

                'ファンクションキー設定
                InitFunctionKey()

                txtBukkenNo.Focus()

            Case "終了"
                '編集中の破棄の確認メッセージ
                If Not ShowHensyuHakiMsg() Then Return

                Me.Close()

            Case "削除"
                ExecuteDelete()

            Case "資料"
                ExecuteFile()

            Case "見積", "受注", "発注", "請求"
                '入力チェック（見積、受注、発注、請求ボタン用）
                If Not InputErrorCheckM_J_H_S_Button() Then Return

                '入力チェック（請求ボタン用）
                If e.Name = "請求" Then
                    If Not InputErrorCheckSeikyuButton() Then Return
                End If

                ExecuteShowRegistDisp(e.Name)

            Case "検索"
                ExecuteSearchForm()

            Case "マップ"
                ExecuteMap()

            Case "登録"
                ExecuteRegist()

        End Select
    End Sub

    ''' <summary>
    ''' 登録画面の表示
    ''' </summary>
    Private Sub ExecuteShowRegistDisp(ByVal dispName As String)

        Select Case dispName

            Case "見積"
                Dim f = New frmMIT0001
                f.requestBUK0001.BUKKEN_NO = txtBukkenNo.Text
                f.ShowDispDialog(Me)

            Case "受注"
                Dim f = New frmJYU0001
                f.requestBUK0001.BUKKEN_NO = txtBukkenNo.Text
                f.ShowDispDialog(Me)

            Case "発注"
                Dim f = New frmHAT0001
                f.requestBUK0001.BUKKEN_NO = txtBukkenNo.Text
                f.ShowDispDialog(Me)

            Case Else
                Dim f = New frmSEI0001
                f.requestBUK0001.BUKKEN_NO = txtBukkenNo.Text
                f.ShowDispDialog(Me)
        End Select

    End Sub

    Private Sub ExecuteFile()
        '関連資料一覧のアップロード先
        Dim S_SCB As New S_SCBRead("資料のアップロード先", "")
        Dim dsS_SCB As dsS_SCB = S_SCB.GetS_SCB

        '存在チェック
        If dsS_SCB.S_SCB.Count = 0 Then
            MessageBoxEx.Show(MessageCode_Arg1.M209, "基本設定マスタの資料のアップロード先が登録されていません。", PROGRAM_NAME)
            Return
        End If
        Dim S_SCB_UploadFilePath = dsS_SCB.S_SCB(0).DATA

        '￥マーク付与
        If S_SCB_UploadFilePath.Substring(S_SCB_UploadFilePath.Length - 1) <> "\" Then
            S_SCB_UploadFilePath += "\"
        End If

        'パスの存在チェック
        If Not System.IO.Directory.Exists(S_SCB_UploadFilePath) Then
            MessageBoxEx.Show(MessageCode_Arg1.M209, "基本設定マスタの資料のアップロード先のパスが参照できません。", PROGRAM_NAME)
            Return
        End If

        '物件Noのパス付与
        S_SCB_UploadFilePath += ZeroPadding(txtBukkenNo.Text, 10) + "\"

        '物件Noのフォルダ作成
        If Not System.IO.Directory.Exists(S_SCB_UploadFilePath) Then
            System.IO.Directory.CreateDirectory(S_SCB_UploadFilePath)
        End If

        System.Diagnostics.Process.Start(S_SCB_UploadFilePath)
    End Sub

    ''' <summary>
    ''' 編集中の破棄の確認メッセージ
    ''' </summary>
    Private Function ShowHensyuHakiMsg() As Boolean
        '編集されていない場合
        If blnUpdateFlg = False Then Return True

        '確認メッセージ
        Return MessageBoxEx.Show(MessageCode_Arg0.M226, PROGRAM_NAME) = DialogResult.Yes
    End Function

    ''' <summary>
    ''' 登録処理
    ''' </summary>
    Private Sub ExecuteRegist()
        '入力チェック
        If Not InputErrorCheck() Then
            Return
        End If

        '確認メッセージ
        If MessageBoxEx.Show(MessageCode_Arg0.M001登録してもよろしいですか, PROGRAM_NAME) = DialogResult.No Then
            Return
        End If

        Using ts As System.Transactions.TransactionScope = New System.Transactions.TransactionScope()

            '物件情報の登録
            Dim dt = New dsT_BUKKEN.T_BUKKENDataTable
            Dim dr As dsT_BUKKEN.T_BUKKENRow = dt.NewRow
            If Utility.NUCheck(txtBukkenNo.Text) Then
                dr.BUKKENNO = 0
            Else
                dr.BUKKENNO = txtBukkenNo.Text
            End If
            dr.BUKKENNAME = txtBukkenName.Text
            dr.KOUSHU = txtKoushu.Text
            dr.POSTNO = txtPostNo.Text
            dr.ADDRESS = txtAddress.Text
            dr.ADDRESS1 = txtAddress1.Text
            dr.ADDRESS2 = txtAddress2.Text
            dr.LAT = txtLat.Text
            dr.LNG = txtLng.Text
            dr.MOTOUKECODE = txtMotoukeCode.Text
            dr.TANTOCODE = txtTantoCode.Text
            If IsDate(txtChakkouDate.Text) Then
                dr.CHAKKOUDATE = txtChakkouDate.Text
            Else
                dr.CHAKKOUDATE = ""
            End If
            If IsDate(txtKankouDate.Text) Then
                dr.KANKOUDATE = txtKankouDate.Text
            Else
                dr.KANKOUDATE = ""
            End If
            dr.UPDATEPGID = PROGRAM_ID()
            dr.UPDATEUSERCODE = TANTO_CODE

            If Me.TitleBar.EditMode = EditMode.Create Then
                '新規モードの場合
                txtBukkenNo.Text = ZeroPadding(T_BUKKEN.insertT_BUKKEN(dr), txtBukkenNo.MaxLength)

                '物件承認の登録
                Dim dtT_BUKKEN_APPROVAL = New dsT_BUKKEN_APPROVAL.T_BUKKEN_APPROVALDataTable
                Dim drT_BUKKEN_APPROVAL As dsT_BUKKEN_APPROVAL.T_BUKKEN_APPROVALRow = dtT_BUKKEN_APPROVAL.NewRow
                drT_BUKKEN_APPROVAL.BUKKENNO = txtBukkenNo.Text
                drT_BUKKEN_APPROVAL.GYOMUKBN = T_BUKKEN_APPROVALRead.enumGyomuKbn.Jyuchu
                drT_BUKKEN_APPROVAL.EDABAN = 0
                drT_BUKKEN_APPROVAL.APPROVALKBN = T_BUKKEN_APPROVALRead.enumApprovalKbn.SYONIN_MI
                drT_BUKKEN_APPROVAL.UPDATEPGID = PROGRAM_ID()
                drT_BUKKEN_APPROVAL.UPDATEUSERCODE = TANTO_CODE
                T_BUKKEN_APPROVAL.insertT_BUKKEN_APPROVAL(drT_BUKKEN_APPROVAL)

                drT_BUKKEN_APPROVAL.GYOMUKBN = T_BUKKEN_APPROVALRead.enumGyomuKbn.Hacchu
                T_BUKKEN_APPROVAL.insertT_BUKKEN_APPROVAL(drT_BUKKEN_APPROVAL)
            Else
                '編集モードの場合
                T_BUKKEN.updateT_BUKKEN(dr)
            End If

            '編集モードの初期表示
            If Not DispEditMode() Then Return

            'ファンクションキー設定
            InitFunctionKey()

            ts.Complete()
        End Using

        '完了メッセージ
        MessageBoxEx.Show(CommonUtility.MessageCode_Arg1.M214, "登録", PROGRAM_NAME)

        txtBukkenName.Focus()
    End Sub

    ''' <summary>
    ''' 削除処理
    ''' </summary>
    Private Sub ExecuteDelete()
        '見積情報の取得
        Dim dtMitsumori = T_MITUMORI.fncSelectT_MITUMORIHED(txtBukkenNo.Text)
        '受注情報の取得
        Dim dtJyuchu = T_JYUTYU.fncSelectT_JYUTYUHED(txtBukkenNo.Text)

        '見積、または、受注が登録されている場合、削除できない
        If dtMitsumori.Rows.Count + dtJyuchu.Rows.Count <> 0 Then
            MessageBoxEx.Show(CommonUtility.MessageCode_Arg1.M208, "見積、受注のいずれかが登録されている為、", PROGRAM_NAME)
            Return
        End If

        '確認メッセージ
        If MessageBoxEx.Show(CommonUtility.MessageCode_Arg0.M002削除してもよろしいですか, PROGRAM_NAME) = System.Windows.Forms.DialogResult.No Then
            Return
        End If

        '物件情報の削除
        T_BUKKEN.deleteT_BUKKEN(txtBukkenNo.Text)

        '物件承認の削除
        T_BUKKEN_APPROVAL.deleteT_BUKKEN_APPROVAL(txtBukkenNo.Text)

        '完了メッセージ
        MessageBoxEx.Show(CommonUtility.MessageCode_Arg1.M214, "削除", PROGRAM_NAME)

        Me.Close()
    End Sub

    ''' <summary>
    ''' 入力チェック（請求ボタン用）
    ''' </summary>
    Private Function InputErrorCheckSeikyuButton() As Boolean

        Dim drBukken = DirectCast(T_BUKKEN.GetDataWherePk(txtBukkenNo.Text).Rows(0), dsT_BUKKEN.T_BUKKENRow)

        '着工日の必須チェック
        If NUCheck(drBukken.CHAKKOUDATE) Then
            MessageBoxEx.Show(MessageCode_Arg1.M224, txtChakkouDate.DisplayName, PROGRAM_NAME)
            txtChakkouDate.Focus()
            Return False
        End If

        '完工日の必須チェック
        If NUCheck(drBukken.KANKOUDATE) Then
            MessageBoxEx.Show(MessageCode_Arg1.M224, txtKankouDate.DisplayName, PROGRAM_NAME)
            txtKankouDate.Focus()
            Return False
        End If

        Return True
    End Function

    ''' <summary>
    ''' 入力チェック（見積、受注、発注、請求ボタン用）
    ''' </summary>
    Private Function InputErrorCheckM_J_H_S_Button() As Boolean

        Dim drBukken = DirectCast(T_BUKKEN.GetDataWherePk(txtBukkenNo.Text).Rows(0), dsT_BUKKEN.T_BUKKENRow)

        '元請の必須チェック
        If NUCheck(drBukken.MOTOUKECODE) Then
            MessageBoxEx.Show(MessageCode_Arg1.M224, txtMotoukeCode.DisplayName, PROGRAM_NAME)
            txtMotoukeCode.Focus()
            Return False
        End If

        Return True
    End Function

    ''' <summary>
    ''' 入力チェック
    ''' </summary>
    Private Function InputErrorCheck() As Boolean
        Dim CheckResult As Nullable(Of Boolean)
        Dim logic As New daBUK0001

        '物件名
        CheckResult = InputErrorCheck_Control(txtBukkenName, 99999)
        If CheckResult.HasValue Then Return CheckResult.Value

        If CheckInputByte(txtBukkenName, 100) Then Return False

        '工種
        If CheckInputByte(txtKoushu, 100) Then Return False

        '郵便番号
        CheckResult = InputErrorCheck_Control(txtPostNo, 99999)
        If CheckResult.HasValue Then Return CheckResult.Value

        If Utility.PostNoCheck(txtPostNo.Text) = False Then
            MessageBoxEx.Show(MessageCode_Arg1.M017を確認して下さい, txtPostNo.DisplayName, PROGRAM_NAME)
            txtPostNo.Focus()
            Return False
        End If

        '住所
        CheckResult = InputErrorCheck_Control(txtAddress, 99999)
        If CheckResult.HasValue Then Return CheckResult.Value

        If CheckInputByte(txtAddress, 10) Then Return False

        '住所1
        CheckResult = InputErrorCheck_Control(txtAddress1, 99999)
        If CheckResult.HasValue Then Return CheckResult.Value

        If CheckInputByte(txtAddress1, 60) Then Return False

        '住所2
        CheckResult = InputErrorCheck_Control(txtAddress2, 99999)
        If CheckResult.HasValue Then Return CheckResult.Value

        If CheckInputByte(txtAddress2, 60) Then Return False

        '元請
        CheckResult = InputErrorCheck_Control(txtMotoukeCode, 99999)
        If CheckResult.HasValue Then Return CheckResult.Value

        '担当者
        CheckResult = InputErrorCheck_Control(txtTantoCode, 99999)
        If CheckResult.HasValue Then Return CheckResult.Value

        '着工日
        CheckResult = InputErrorCheck_Control(txtChakkouDate, 99999)
        If CheckResult.HasValue Then Return CheckResult.Value

        '完工日
        CheckResult = InputErrorCheck_Control(txtKankouDate, 99999)
        If CheckResult.HasValue Then Return CheckResult.Value

        If txtChakkouDate.Text <> "    /  /" _
                AndAlso txtKankouDate.Text <> "    /  /" _
                AndAlso RangeValidator.ValidateMe(txtChakkouDate.DisplayName, txtChakkouDate, txtKankouDate) = False Then
            txtChakkouDate.Focus()
            Return False
        End If

        Return True

    End Function

    ''' <summary>
    ''' 入力チェック
    ''' </summary>
    Private Function CheckInputByte(ByVal control As TextBoxEx, ByVal byteValue As Integer) As Boolean
        If Utility.LenB(control.Text) > byteValue Then
            MessageBoxEx.Show(MessageCode_Arg1.M020の桁数が大きすぎます, control.DisplayName, PROGRAM_NAME)
            control.Focus()
            Return True
        End If

        Return False
    End Function

    ''' <summary>
    ''' 検索画面起動
    ''' </summary>
    Private Sub ExecuteSearchForm()

        Select Case LastFocusedControl.Name

            Case txtPostNo.Name
                '郵便番号
                Using f As New WinFormBase.SEN0040

                    '検索ダイアログの表示
                    If f.ShowDialog() <> DialogResult.OK Then
                        LastFocusedControl.Focus()
                        Return
                    End If

                    '選択されていない場合
                    If f.ItemSelected = False Then
                        LastFocusedControl.Focus()
                        Return
                    End If

                    '住所が入力済の場合、確認メッセージ
                    If Not NUCheck(txtAddress.Text) OrElse Not NUCheck(txtAddress1.Text) Then
                        If MessageBoxEx.Show(MessageCode_Arg0.M007書き換えてもよろしいですか, PROGRAM_NAME) <> DialogResult.Yes Then
                            Return
                        End If
                    End If

                    '戻り値のセット
                    txtPostNo.Text = f.SelectedItem.POSTCODE
                    txtAddress.Text = f.SelectedItem.TODOUFUKEN
                    txtAddress1.Text = f.SelectedItem.SIKUTYOUSON & f.SelectedItem.TYOUIKI
                    txtAddress2.Text = ""
                    postNoBef = txtPostNo.Text

                    txtAddress1.Focus()
                    SendKeys.Send("{END}")
                End Using

            Case txtMotoukeCode.Name
                '元請
                Using f As New WinFormBase.SEARCH_TOKUI(0)

                    f.Owner = Me

                    '検索ダイアログの表示
                    If f.ShowDialog() <> DialogResult.OK Then
                        LastFocusedControl.Focus()
                        Return
                    End If

                    '選択されていない場合
                    If f.SelectItem Is Nothing Then
                        LastFocusedControl.Focus()
                        Return
                    End If

                    '戻り値のセット
                    LastFocusedControl.Text = f.SelectItem.Code

                    LastFocusedControl.Focus()
                End Using

            Case txtTantoCode.Name
                '担当者
                Using f As New WinFormBase.SEARCH_TANTO(0)

                    f.Owner = Me

                    '検索ダイアログの表示
                    If f.ShowDialog() <> DialogResult.OK Then
                        LastFocusedControl.Focus()
                        Return
                    End If

                    '選択されていない場合
                    If f.SelectItem Is Nothing Then
                        LastFocusedControl.Focus()
                        Return
                    End If

                    '戻り値のセット
                    LastFocusedControl.Text = f.SelectItem.Code

                    LastFocusedControl.Focus()
                End Using
        End Select
    End Sub

    ''' <summary>
    ''' 検索画面起動
    ''' </summary>
    Private Sub ExecuteMap()
        Dim S_SCB As New S_SCBRead("google mapのURL", "")
        Dim dsS_SCB As dsS_SCB = S_SCB.GetS_SCB

        If dsS_SCB.S_SCB.Rows.Count = 0 Then
            MessageBoxEx.Show(MessageCode_Arg1.M209, "基本設定マスタ（google mapのURL）が登録されていません。", PROGRAM_NAME)
        Else
            Process.Start(dsS_SCB.S_SCB(0).DATA)
        End If

    End Sub

    ''' <summary>
    ''' フォーカス取得時イベント(ImeMode = Hiragana)
    ''' </summary>
    Private Sub EnterEventHandlerImeHiragana(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.ActiveControl.ImeMode = System.Windows.Forms.ImeMode.Hiragana
    End Sub

    ''' <summary>
    ''' フォーカス取得時イベント(ImeMode = Off)
    ''' </summary>
    Private Sub EnterEventHandlerImeOff(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.ActiveControl.ImeMode = System.Windows.Forms.ImeMode.Off
    End Sub

    ''' <summary>
    ''' フォーカス取得時イベント（検索ボタン切替）
    ''' </summary>
    Private Sub ChangeEnabledFunctionKey_Kensaku_Enabled(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FunctionKey.SetItem(9, "検索", "検索", True)
    End Sub

    ''' <summary>
    ''' フォーカス喪失時イベント（検索ボタン切替）
    ''' </summary>
    Private Sub ChangeEnabledFunctionKey_Kensaku_Disabled(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FunctionKey.SetItem(9, "検索", "検索", False)
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

        '物件Noはイベントを追加しない
        RemoveHandler txtBukkenNo.TextChanged, AddressOf ChangeEventHandler
    End Sub

    ''' <summary>
    ''' テキスト変更時イベント
    ''' </summary>
    Private Sub ChangeEventHandler(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '更新フラグ
        blnUpdateFlg = True
    End Sub

    ''' <summary>
    ''' 住所変更イベント
    ''' </summary>
    Private Sub ChangeAddress(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If TitleBar.EditMode = EditMode.None Then Return

        If Utility.NUCheck(txtAddress.Text) OrElse Utility.NUCheck(txtAddress1.Text) OrElse Utility.NUCheck(txtAddress2.Text) Then
            btnMAP0001_2.Enabled = False
        Else
            btnMAP0001_2.Enabled = True
        End If
    End Sub

    ''' <summary>
    ''' 郵便番号チェック
    ''' </summary>
    Private Sub CheckPostNo(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '郵便番号が変更されていない場合
        If txtPostNo.Text = postNoBef Then Exit Sub
        postNoBef = txtPostNo.Text

        '郵便番号が未入力の場合
        If Utility.NUCheck(txtPostNo) Then Exit Sub

        If Utility.PostNoCheck(txtPostNo.Text) = False Then
            MessageBoxEx.Show(MessageCode_Arg1.M017を確認して下さい, txtPostNo.DisplayName, PROGRAM_NAME)
            txtPostNo.Focus()
            Return
        End If

        '住所マスタ読込
        fncPost_Read()
    End Sub

    ''' <summary>
    ''' 住所マスタ読込
    ''' </summary>
    Private Function fncPost_Read() As Boolean

        '--変数宣言--
        Dim strPost As String       '郵便番号
        Dim strAddress1 As String   '住所１
        Dim strAddress2 As String   '住所２

        '戻り値
        fncPost_Read = False

        '入力チェック
        strPost = Utility.TelNo_cnv(txtPostNo.Text)

        If strPost = vbNullString Then
            '戻り値
            fncPost_Read = True
            Exit Function
        End If

        Dim logic As New WinFormBase.daSEN0040
        Dim response As BLL.SEN.dsSEN0040.M_KENDataTable = logic.ReadM_KENbyPrimarykey(strPost)

        'データなし
        If Not response.Rows.Count > 0 Then
            MessageBoxEx.Show(MessageCode_Arg1.M014が存在しません, txtPostNo.DisplayName, PROGRAM_NAME)
            Exit Function
        End If

        strAddress1 = Utility.NS(response.Item(0).TODOUFUKEN)
        strAddress2 = Utility.NS(response.Item(0).SIKUTYOUSON & response.Item(0).TYOUIKI)

        '1件あり
        If response.Rows.Count = 1 Then

            If Utility.NS(txtAddress.Text) = vbNullString And
                   Utility.NS(txtAddress1.Text) = vbNullString Then
                txtAddress.Text = strAddress1
                txtAddress1.Text = strAddress2
                txtAddress2.Text = ""
            Else
                If MessageBoxEx.Show(CommonUtility.MessageCode_Arg0.M007書き換えてもよろしいですか, PROGRAM_NAME) = System.Windows.Forms.DialogResult.Yes Then
                    txtAddress.Text = strAddress1
                    txtAddress1.Text = strAddress2
                    txtAddress2.Text = ""
                End If
            End If

            txtAddress2.Focus()
            SendKeys.Send("{End}")
        Else
            '複数あり
            Using frmPostCode As New WinFormBase.SEN0040
                frmPostCode.SelectedItem = New WinFormBase.SEN0040_M_KEN_Data("", "", "", strPost)
                '検索画面表示
                frmPostCode.ShowDialog()

                If frmPostCode.ItemSelected = False Then
                    '郵便番号チェックしない
                    Exit Function
                End If

                If Not frmPostCode.SelectedItem.POSTCODE = vbNullString Then

                    If Utility.NS(txtAddress.Text) = vbNullString And
                           Utility.NS(txtAddress1.Text) = vbNullString Then
                        txtAddress.Text = frmPostCode.SelectedItem.TODOUFUKEN
                        txtAddress1.Text = frmPostCode.SelectedItem.SIKUTYOUSON & frmPostCode.SelectedItem.TYOUIKI
                        txtAddress2.Text = ""
                    Else
                        If MessageBoxEx.Show(CommonUtility.MessageCode_Arg0.M007書き換えてもよろしいですか, PROGRAM_NAME) = System.Windows.Forms.DialogResult.Yes Then
                            txtAddress.Text = frmPostCode.SelectedItem.TODOUFUKEN
                            txtAddress1.Text = frmPostCode.SelectedItem.SIKUTYOUSON & frmPostCode.SelectedItem.TYOUIKI
                            txtAddress2.Text = ""
                        End If
                    End If

                    txtADDRESS2.Focus()
                End If
            End Using

        End If

        '戻り値
        fncPost_Read = True

    End Function

    Public Sub ShowReDisp()
        '編集モードの初期表示
        DispEditMode()
        'ファンクションキー設定
        InitFunctionKey()
    End Sub

    Public Sub ShowReDispMAP0001()  '戻り値をセット
        With responseMAP0001
            If .RESPONSE_FLAG_POST_NO Then
                txtPostNo.Text = .POST_NO
                postNoBef = .POST_NO
            End If

            If .RESPONSE_FLAG_ADDRESS Then
                txtAddress.Text = .ADDRESS
                txtAddress1.Text = .ADDRESS1
                txtAddress2.Text = .ADDRESS2
            End If

            If .RESPONSE_FLAG_LAT_LNG Then
                txtLat.Text = .LAT
                txtLng.Text = .LNG
            End If
        End With
    End Sub

    Private Sub btnMENT0005_Click(sender As Object, e As EventArgs) Handles btnMENT0005.Click
        Dim f = New frmMENT0005
        f.ShowDialog()

        'コンボボックス初期化
        InitComboBox()
    End Sub

    Private Sub txtBukkenNo_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtBukkenNo.KeyDown

        'エンターキー以外は処理しない
        If e.KeyCode <> Keys.Enter Then Return

        If NUCheck(txtBukkenNo.Text) Then
            TitleBar.EditMode = EditMode.Create

        Else
            '編集モードの初期表示
            If Not DispEditMode() Then Return
        End If

        '表示制御
        InitEnabled()

        'ファンクションキー設定
        InitFunctionKey()

        txtBukkenName.Focus()
    End Sub
End Class
