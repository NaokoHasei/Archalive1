Imports BLL.Common
Imports CommonUtility.WinForm
Imports CommonUtility.Utility

Public Class frmMENT0004

    Public Overrides Function PROGRAM_ID() As String
        Return "MENT0004"
    End Function

    Public Overrides Function PROGRAM_NAME() As String
        Return "担当者マスタ登録"
    End Function

    Private blnUpdateFlg As Boolean                 '更新フラグ

    Private Enum COL
        TANTOCODE = 0
        TANTONAME = 1
        TANTOKANA = 2
        BUKACODE = 3
        BUKANAME = 4
    End Enum

    Private Enum enumFormStatus
        キー入力

        明細入力

    End Enum

    Friend Enum enum更新種別
        新規編集
        削除
    End Enum

    Private CodeNumbering As New CodeNumbering

    Protected Overrides Sub Form_Load(ByVal sender As Object, ByVal e As EventArgs)
        MyBase.Form_Load(sender, e)

        Call コンボボックス初期化()

        Call 画面設定(enumFormStatus.キー入力)

        Call グリッド初期化()

        Call 明細表示()

        Call イベント設定()

    End Sub

    Private Sub 画面設定(ByVal FormStatus As enumFormStatus)

        Select Case FormStatus
            Case enumFormStatus.キー入力

                Dim S_SCB As New S_SCBRead("使用機能の担当者マスタの初期値", "")
                Dim dsS_SCB As dsS_SCB = S_SCB.GetS_SCB

                txtTANTOCODE.Text = ""
                txtTANTONAME.Text = ""
                txtTANTOKANA.Text = ""
                txtBUKACODE.Text = ""
                txtBUKANAME.Text = ""
                txtPassword.Text = ""
                If dsS_SCB.S_SCB.Rows.Count = 0 Then
                    txtKengenCode.Text = ""
                Else
                    txtKengenCode.Text = dsS_SCB.S_SCB(0).DATA
                End If

                txtTANTOCODE.Enabled = True
                fraName.Enabled = False

                txtTANTOCODE.Focus()

                TitleBar.EditMode = CommonUtility.WinFormControls.EditMode.None

            Case enumFormStatus.明細入力

                txtTANTOCODE.Enabled = False
                fraName.Enabled = True

                txtBUKANAME.Focus()
        End Select

        Call ファンクションキー設定(FormStatus)

    End Sub

    Private Sub コンボボックス初期化()

        Dim logic As New BLL.Common.TypComboBox

        Dim paramlist As New List(Of Model.DTO.RequestGetComboBoxContentsElement)
        paramlist.Add(New Model.DTO.RequestGetComboBoxContentsElement(Model.ComboBoxTableName.M_TANTO, Model.DTO.GetComboBoxContentsResultFieldType.MultipleField, False, Nothing))
        paramlist.Add(New Model.DTO.RequestGetComboBoxContentsElement(Model.ComboBoxTableName.M_BUKA, Model.DTO.GetComboBoxContentsResultFieldType.MultipleField, False, Nothing))
        paramlist.Add(New Model.DTO.RequestGetComboBoxContentsElement(Model.ComboBoxTableName.S_SCB, Model.DTO.GetComboBoxContentsResultFieldType.MultipleField, False, "使用機能の権限の種類"))
        Dim requestParam As New Model.DTO.RequestGetComboBoxContents(paramlist)
        Dim recieveParam As Model.DTO.ResponseGetComboBoxContents

        recieveParam = logic.CreateComboBox(requestParam)

        txtTANTOCODE.AttachDataSource(Model.ComboBoxTableName.M_TANTO, recieveParam)
        txtBUKACODE.AttachDataSource(Model.ComboBoxTableName.M_BUKA, recieveParam)
        txtKengenCode.AttachDataSource(Model.ComboBoxTableName.S_SCB, recieveParam)

    End Sub

    Private Sub ファンクションキー設定(ByVal FormStatus As enumFormStatus)

        FunctionKey.ClearAll()

        Select Case FormStatus
            Case enumFormStatus.キー入力

                FunctionKey.SetItem(1, "終了", "終了", True)
            Case enumFormStatus.明細入力

                FunctionKey.SetItem(1, "取消", "取消", True)
                If TitleBar.EditMode = CommonUtility.WinFormControls.EditMode.Edit Then
                    FunctionKey.SetItem(3, "削除", "削除", True)
                End If
                FunctionKey.SetItem(12, "登録", "登録", True)
        End Select

        FunctionKey.SetItem(5, "先頭へ", "先頭へ", True)
        FunctionKey.SetItem(6, "前へ", "前へ", True)
        FunctionKey.SetItem(7, "次へ", "次へ", True)
        FunctionKey.SetItem(8, "最後へ", "最後へ", True)

    End Sub

    Private Sub グリッド初期化()

        With dbgMeisai

            With .Columns
                .Add(New C1.Win.C1TrueDBGrid.C1DataColumn("", "TANTOCODE", Type.GetType("System.String")))
                .Add(New C1.Win.C1TrueDBGrid.C1DataColumn("", "TANTONAME", Type.GetType("System.String")))
                .Add(New C1.Win.C1TrueDBGrid.C1DataColumn("", "TANTOKANA", Type.GetType("System.String")))
                .Add(New C1.Win.C1TrueDBGrid.C1DataColumn("", "BUKACODE", Type.GetType("System.String")))
            End With

            With .Splits(0)
                .DisplayColumns(COL.TANTOCODE).Width = (10) * 8
                .DisplayColumns(COL.TANTONAME).Width = (30) * 8
                .DisplayColumns(COL.TANTOKANA).Width = (30) * 8
                .DisplayColumns(COL.BUKACODE).Width = (10) * 8
            End With

            For i As Integer = 0 To .Columns.Count - 1
                .Splits(0).DisplayColumns(i).Visible = True
            Next

            .Columns(COL.TANTOCODE).Caption = "担当者コード"
            .Columns(COL.TANTONAME).Caption = "担当者名"
            .Columns(COL.TANTOKANA).Caption = "担当者カナ"
            .Columns(COL.BUKACODE).Caption = "部課コード"

            For i As Integer = 0 To .Columns.Count - 1
                .Splits(0).DisplayColumns(i).AllowFocus = True
            Next

            .Columns(COL.TANTOCODE).DataWidth = 4
            .Columns(COL.TANTONAME).DataWidth = 30
            .Columns(COL.TANTOKANA).DataWidth = 30
            .Columns(COL.BUKACODE).DataWidth = 4

            .RecordSelectors = False 'レコードセレクタ非表示（グリッド左側）

            .Splits(0).DisplayColumns(COL.TANTOCODE).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            .Splits(0).DisplayColumns(COL.BUKACODE).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        End With

        GridSetup(dbgMeisai, GridSetupAllows.AllowReadOnly, False, False, False)

    End Sub

    Private Sub 明細表示()

        Dim logic As New daMENT0004

        dbgMeisai.SetDataBinding(Nothing, "", True)

        Dim dt As dsMENT0004.M_TANTODataTable = logic.ReadTANTO()

        dbgMeisai.SetDataBinding(dt, "", True)

    End Sub

    Private Sub イベント設定()

        AddHandler txtTANTOCODE.PressEnter, AddressOf CodeSelectByTextBoxTA
        AddHandler txtTANTOCODE.SelectionChangeCommitted, AddressOf CodeSelectByTextBoxTA

        AddHandler dbgMeisai.DoubleClick, AddressOf CodeSelectByGrid
        AddHandler dbgMeisai.HeadClick, AddressOf HeadClick

        AddHandler txtTANTONAME.TextChanged, AddressOf ChangeEventHandler
        AddHandler txtTANTOKANA.TextChanged, AddressOf ChangeEventHandler
        AddHandler txtBUKACODE.TextChanged, AddressOf ChangeEventHandler
        AddHandler txtTANTOCODE.Enter, AddressOf EnterEventHandler
        AddHandler txtTANTONAME.Enter, AddressOf EnterEventHandler
        AddHandler txtTANTOKANA.Enter, AddressOf EnterEventHandler
        AddHandler txtBUKACODE.Enter, AddressOf EnterEventHandler
        AddHandler txtPassword.Enter, AddressOf EnterEventHandler
        AddHandler txtKengenCode.Enter, AddressOf EnterEventHandler
    End Sub

    Private Sub CodeSelectByTextBoxTA(ByVal sender As Object, ByVal e As EventArgs)

        If txtTANTOCODE.ValidateMe = False Then
            txtTANTOCODE.Focus()
            Return
        End If

        Call MasterReadByKeyInput()

        SelectRow(txtTANTOCODE.Text)

    End Sub

    Private Sub CodeSelectByTextBoxBU(ByVal sender As Object, ByVal e As EventArgs)

        If txtBUKACODE.ValidateMe = False Then
            txtBUKACODE.Focus()
            Return
        End If

        txtPassword.Focus()

    End Sub

    Private Sub CodeSelectByGrid(ByVal sender As Object, ByVal e As EventArgs) Handles dbgMeisai.DoubleClick

        'クリック位置のチェック
        If WinFormUtility.GridPointAtCell(dbgMeisai) = False Then Exit Sub

        If txtTANTOCODE.Text <> dbgMeisai.Columns(COL.TANTOCODE).Value.ToString Or blnUpdateFlg = True Then
            txtTANTOCODE.Text = dbgMeisai.Columns(COL.TANTOCODE).Value.ToString

            Call MasterReadByKeyInput()
        End If

    End Sub

    Private Sub HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs)
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
                Case COL.TANTOCODE : CType(dbgMeisai.DataSource, DataTable).DefaultView.Sort = "TANTOCODE " & strSort
                Case COL.TANTONAME : CType(dbgMeisai.DataSource, DataTable).DefaultView.Sort = "TANTONAME " & strSort
                Case COL.TANTOKANA : CType(dbgMeisai.DataSource, DataTable).DefaultView.Sort = "TANTOKANA " & strSort
                Case COL.BUKACODE : CType(dbgMeisai.DataSource, DataTable).DefaultView.Sort = "BUKACODE " & strSort
            End Select

            SelectRow(txtTANTOCODE.Text)

        End Using

    End Sub

    Private Sub SelectRow(ByVal strTANTOCODE As String)

        Dim intRow As Integer = 0
        With dbgMeisai
            For intRow = 0 To .Splits(0).Rows.Count - 1
                Dim s As String = dbgMeisai(intRow, COL.TANTOCODE).ToString
                If s.ToUpper = strTANTOCODE.ToUpper Then
                    .Row = intRow
                    Exit For
                End If
            Next

            If intRow > (.Splits(0).Rows.Count - 1) Then .Row = 0
        End With

    End Sub

    Private Sub MasterReadByKeyInput()

        Dim logic As New daMENT0004

        Dim r As dsMENT0004.M_TANTODataTable = logic.ReadTANTO(txtTANTOCODE.Text)

        If r.Count = 0 Then
            TitleBar.EditMode = CommonUtility.WinFormControls.EditMode.Create
        Else
            TitleBar.EditMode = CommonUtility.WinFormControls.EditMode.Edit
            txtTANTONAME.Text = r.Item(0).TANTONAME
            txtTANTOKANA.Text = r.Item(0).TANTOKANA
            txtBUKACODE.Text = r.Item(0).BUKACODE
            txtPassword.Text = r.Item(0).PASSWORD
            txtKengenCode.Text = r.Item(0).SIYOKINOU_AUTHORITY
        End If

        blnUpdateFlg = False

        Call 画面設定(enumFormStatus.明細入力)

        txtTANTONAME.Focus()

    End Sub

    Protected Overrides Sub FunctionKeyAction(ByVal sender As Object, ByVal e As CommonUtility.WinFormControls.FunctionKeyEventArgs)

        Select Case e.Name

            Case "終了"

                Me.Close()

                Exit Sub

            Case "先頭へ", "前へ", "次へ", "最後へ"

                If fraName.Enabled = True And blnUpdateFlg = True Then

                    If AllInputValidate() = False Then Exit Sub

                    If MessageBoxEx.Show(CommonUtility.MessageCode_Arg0.M001登録してもよろしいですか, PROGRAM_NAME) = Windows.Forms.DialogResult.Yes Then
                        Using wcur As New WaitCursor
                            '更新処理

                            ExecuteMain(enum更新種別.新規編集)

                            コンボボックス初期化()
                        End Using
                    End If
                End If

                Using wcur As New WaitCursor
                    RecordMove(e.Name)
                End Using

                blnUpdateFlg = False

                txtTANTOCODE.Focus()

                Exit Sub

            Case "取消"

                If MessageBoxEx.Show(CommonUtility.MessageCode_Arg0.M003取消してもよろしいですか, PROGRAM_NAME) = Windows.Forms.DialogResult.No Then Return

                Call 画面設定(enumFormStatus.キー入力)

            Case "削除"

                If MessageBoxEx.Show(CommonUtility.MessageCode_Arg0.M002削除してもよろしいですか, PROGRAM_NAME) = Windows.Forms.DialogResult.No Then Return

                ExecuteMain(enum更新種別.削除)

            Case "登録"

                If AllInputValidate() = False Then Exit Sub

                If MessageBoxEx.Show(CommonUtility.MessageCode_Arg0.M001登録してもよろしいですか, PROGRAM_NAME) = Windows.Forms.DialogResult.No Then Return

                ExecuteMain(enum更新種別.新規編集)

        End Select

        LastFocusedControl.Focus()

    End Sub

    Private Sub ExecuteMain(ByVal 更新 As enum更新種別)

        Dim logic As New daMENT0004

        If 更新 = enum更新種別.削除 Then
            logic.Delete(txtTANTOCODE.Text)

        Else
            'コードの採番
            If NUCheck(txtTANTOCODE.Text) Then
                txtTANTOCODE.Text = ZeroFormat(CodeNumbering.GetNumer(CodeNumbering.enumKbn.M_TANTO), txtTANTOCODE.MaxLength)
            End If

            logic.Insert(Me)
        End If

        Call 画面設定(enumFormStatus.キー入力)

        Call 明細表示()

    End Sub

    Public Function AllInputValidate() As Boolean
        Return InputErrorCheck(Nothing, 9999999)
    End Function

    Private Sub EnterEventHandler(ByVal sender As Object, ByVal e As EventArgs)

        If CType(sender, Control).CausesValidation = False Then
            Return
        End If

        If InputErrorCheck(CType(sender, Control), GetTabOrder(CType(sender, Control))) = False Then
            Return
        End If

    End Sub

    Private Function InputErrorCheck(ByVal sender As Control, ByVal tabOrder As Integer) As Boolean
        Dim CheckResult As Nullable(Of Boolean)

        Select Case True
            Case txtTANTOCODE.Enabled
                '担当者コード
                CheckResult = InputErrorCheck_Control(txtTANTOCODE, tabOrder)
                If CheckResult.HasValue Then Return CheckResult.Value

            Case fraName.Enabled
                '担当者名
                CheckResult = InputErrorCheck_Control(txtTANTONAME, tabOrder)
                If CheckResult.HasValue Then Return CheckResult.Value

                '担当者カナ
                CheckResult = InputErrorCheck_Control(txtTANTOKANA, tabOrder)
                If CheckResult.HasValue Then Return CheckResult.Value

                '部課コード
                CheckResult = InputErrorCheck_Control(txtBUKACODE, tabOrder)
                If CheckResult.HasValue Then Return CheckResult.Value

                '使用機能の権限
                CheckResult = InputErrorCheck_Control(txtKengenCode, tabOrder)
                If CheckResult.HasValue Then Return CheckResult.Value
        End Select

        Return True

    End Function

    Private Sub RecordMove(ByVal MoveCommand As String)
        Dim logic As New daMENT0004
        Dim strPrimaryKey As String         'キーコード

        '空値チェック
        If CommonUtility.Utility.NUCheck(txtTANTOCODE.Text) Then
            '先頭・最後ボタン以外不可
            If MoveCommand <> "先頭へ" And MoveCommand <> "最後へ" Then Exit Sub
        End If

        strPrimaryKey = logic.RecordMove(MoveCommand, txtTANTOCODE.Text, PCNAME, PROGRAM_ID)
        If CommonUtility.Utility.NUCheck(strPrimaryKey) Then
            '初期化

            画面設定(enumFormStatus.キー入力)
        Else
            txtTANTOCODE.Text = strPrimaryKey

            CodeSelectByTextBoxTA(Nothing, Nothing)
        End If

    End Sub

    Private Sub ChangeEventHandler(ByVal sender As Object, ByVal e As EventArgs)
        '更新フラグ
        blnUpdateFlg = True
    End Sub

    Private Sub txtTANTONAME_CompositionEventHandler(ByVal sender As Object, ByVal e As CommonUtility.WinFormControls.CompositionEventArgs) Handles txtTANTONAME.CompositionEventHandler
        Dim i As Integer = 0
        i = txtTANTOKANA.MaxLength - txtTANTOKANA.Text.Length
        txtTANTOKANA.Text += e.ImeString.Substring(0, CType(IIf(i > e.ImeString.Length, e.ImeString.Length, i), Integer))
    End Sub
End Class