Imports BLL.Common
Imports CommonUtility.Utility

Public Class frmMENT0001

    Public Overrides Function PROGRAM_ID() As String
        Return "MENT0001"
    End Function

    Public Overrides Function PROGRAM_NAME() As String
        Return "部課マスタ登録"
    End Function

    Private Enum COL
        BUKACODE = 0
        BUKANAME = 1
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

    Protected Overrides Sub Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MyBase.Form_Load(sender, e)

        Call 画面設定(enumFormStatus.キー入力)

        Call コンボボックス初期化()

        Call グリッド初期化()

        Call 明細表示()

        Call イベント設定()

    End Sub

    Private Sub 画面設定(ByVal FormStatus As enumFormStatus)

        Select Case FormStatus
            Case enumFormStatus.キー入力
                txtBUKACODE.Text = ""
                txtBUKANAME.Text = ""

                txtBUKACODE.Enabled = True
                txtBUKANAME.Enabled = False

                txtBUKACODE.Focus()

                TitleBar.EditMode = CommonUtility.WinFormControls.EditMode.None

            Case enumFormStatus.明細入力

                txtBUKACODE.Enabled = False
                txtBUKANAME.Enabled = True

                txtBUKANAME.Focus()
        End Select

        Call ファンクションキー設定(FormStatus)

    End Sub

    Private Sub コンボボックス初期化()

        Dim logic As New BLL.Common.TypComboBox

        Dim paramlist As New List(Of Model.DTO.RequestGetComboBoxContentsElement)
        paramlist.Add(New Model.DTO.RequestGetComboBoxContentsElement(Model.ComboBoxTableName.M_BUKA, Model.DTO.GetComboBoxContentsResultFieldType.MultipleField, False, Nothing))
        Dim requestParam As New Model.DTO.RequestGetComboBoxContents(paramlist)
        Dim recieveParam As Model.DTO.ResponseGetComboBoxContents

        recieveParam = logic.CreateComboBox(requestParam)

        txtBUKACODE.AttachDataSource(Model.ComboBoxTableName.M_BUKA, recieveParam)

    End Sub

    Private Sub ファンクションキー設定(ByVal FormStatus As enumFormStatus)

        FunctionKey.ClearAll()

        Select Case FormStatus
            Case enumFormStatus.キー入力
                FunctionKey.SetItem(1, "終了", "終了", True)
            Case enumFormStatus.明細入力
                FunctionKey.SetItem(1, "取消", "取消", True)
                FunctionKey.SetItem(3, "削除", "削除", True)
                FunctionKey.SetItem(12, "登録", "登録", True)
        End Select

    End Sub

    Private Sub グリッド初期化()

        With dbgMeisai

            With .Columns
                .Add(New C1.Win.C1TrueDBGrid.C1DataColumn("", "BUKACODE", Type.GetType("System.String")))
                .Add(New C1.Win.C1TrueDBGrid.C1DataColumn("", "BUKANAME", Type.GetType("System.String")))
            End With

            With .Splits(0)
                .DisplayColumns(COL.BUKACODE).Width = (6) * 8
                .DisplayColumns(COL.BUKANAME).Width = (31) * 8
            End With

            For i As Integer = 0 To .Columns.Count - 1
                .Splits(0).DisplayColumns(i).Visible = True
            Next

            .Columns(COL.BUKACODE).Caption = "コード"
            .Columns(COL.BUKANAME).Caption = "名称"

            For i As Integer = 0 To .Columns.Count - 1
                .Splits(0).DisplayColumns(i).AllowFocus = True
            Next

            .Columns(COL.BUKACODE).DataWidth = 4
            .Columns(COL.BUKANAME).DataWidth = 30

        End With

        GridSetup(dbgMeisai, GridSetupAllows.AllowReadOnly, False, False, False)

    End Sub

    Private Sub 明細表示()

        Dim logic As New daMENT0001

        Dim dt As dsMENT0001.M_BUKADataTable = logic.Read()

        dbgMeisai.SetDataBinding(dt, "", True)

    End Sub

    Private Sub イベント設定()

        AddHandler txtBUKACODE.PressEnter, AddressOf CodeSelectByTextBox
        AddHandler txtBUKACODE.SelectionChangeCommitted, AddressOf CodeSelectByTextBox

        AddHandler dbgMeisai.DoubleClick, AddressOf CodeSelectByGrid
        AddHandler dbgMeisai.HeadClick, AddressOf HeadClick

    End Sub

    Private Sub CodeSelectByTextBox(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If txtBUKACODE.ValidateMe = False Then
            txtBUKACODE.Focus()
            Return
        End If

        Call MasterReadByKeyInput()

        SelectRow(txtBUKACODE.Text)

    End Sub

    Private Sub CodeSelectByGrid(ByVal sender As Object, ByVal e As System.EventArgs) Handles dbgMeisai.DoubleClick

        'クリック位置のチェック
        If CommonUtility.WinForm.WinFormUtility.GridPointAtCell(dbgMeisai) = False Then Exit Sub

        txtBUKACODE.Text = dbgMeisai.Columns(COL.BUKACODE).Value.ToString

        Call MasterReadByKeyInput()

    End Sub

    Private Sub HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs)
        Static intCol As Integer
        Static strSort As String

        Using wcursor As New CommonUtility.WinForm.WaitCursor

            If (intCol <> e.ColIndex) Then strSort = ""
            intCol = e.ColIndex
            Select Case strSort
                Case "asc" : strSort = "desc"
                Case "desc" : strSort = "asc"
                Case Else : strSort = "asc"
            End Select

            Select Case intCol
                Case COL.BUKACODE : CType(dbgMeisai.DataSource, DataTable).DefaultView.Sort = "BUKACODE " & strSort
                Case COL.BUKANAME : CType(dbgMeisai.DataSource, DataTable).DefaultView.Sort = "BUKANAME " & strSort & ", BUKACODE"
            End Select

            SelectRow(txtBUKACODE.Text)

        End Using

    End Sub

    Private Sub SelectRow(ByVal strBUKACODE As String)

        Dim intRow As Integer = 0
        With dbgMeisai
            For intRow = 0 To .Splits(0).Rows.Count - 1
                Dim s As String = dbgMeisai(intRow, COL.BUKACODE).ToString
                If s.ToUpper = strBUKACODE.ToUpper Then
                    .Row = intRow
                    Exit For
                End If
            Next

            If intRow > (.Splits(0).Rows.Count - 1) Then .Row = 0
        End With

    End Sub

    Private Sub MasterReadByKeyInput()

        Dim logic As New daMENT0001

        Dim r As dsMENT0001.M_BUKARow = logic.Read(txtBUKACODE.Text)

        If r Is Nothing Then
            TitleBar.EditMode = CommonUtility.WinFormControls.EditMode.Create
        Else
            TitleBar.EditMode = CommonUtility.WinFormControls.EditMode.Edit
            txtBUKANAME.Text = r.BUKANAME
        End If

        Call 画面設定(enumFormStatus.明細入力)

    End Sub

    Protected Overrides Sub FunctionKeyAction(ByVal sender As System.Object, ByVal e As CommonUtility.WinFormControls.FunctionKeyEventArgs)

        Select Case e.Name

            Case "終了"

                Me.Close()

                Exit Sub

            Case "取消"

                If CommonUtility.WinForm.MessageBoxEx.Show(CommonUtility.MessageCode_Arg0.M003取消してもよろしいですか, PROGRAM_NAME) = Windows.Forms.DialogResult.No Then Return

                Call 画面設定(enumFormStatus.キー入力)

            Case "削除"

                If CommonUtility.WinForm.MessageBoxEx.Show(CommonUtility.MessageCode_Arg0.M002削除してもよろしいですか, PROGRAM_NAME) = Windows.Forms.DialogResult.No Then Return

                ExecuteMain(enum更新種別.削除)

            Case "登録"

                If CommonUtility.WinForm.MessageBoxEx.Show(CommonUtility.MessageCode_Arg0.M001登録してもよろしいですか, PROGRAM_NAME) = Windows.Forms.DialogResult.No Then Return

                ExecuteMain(enum更新種別.新規編集)

        End Select

        LastFocusedControl.Focus()

    End Sub

    Private Sub ExecuteMain(ByVal 更新 As enum更新種別)

        Dim logic As New daMENT0001

        If 更新 = enum更新種別.削除 Then
            logic.Delete(txtBUKACODE.Text)

        Else
            'コードの採番
            If NUCheck(txtBUKACODE.Text) Then
                txtBUKACODE.Text = ZeroFormat(CodeNumbering.GetNumer(CodeNumbering.enumKbn.M_BUKA), txtBUKACODE.MaxLength)
            End If

            Dim UpdateRow As New dsMENT0001.M_BUKADataTable
                UpdateRow.AddM_BUKARow(txtBUKACODE.Text, txtBUKANAME.Text, PROGRAM_ID, TANTO_CODE)
                logic.Entry(UpdateRow.Item(0))
            End If

            Call 画面設定(enumFormStatus.キー入力)

            Call 明細表示()

    End Sub

    Public Function AllInputValidate() As Boolean
        Return InputErrorCheck(Nothing, 9999999)
    End Function

    Private Sub EnterEventHandler(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If CType(sender, System.Windows.Forms.Control).CausesValidation = False Then
            Return
        End If

        If InputErrorCheck(CType(sender, System.Windows.Forms.Control), GetTabOrder(CType(sender, System.Windows.Forms.Control))) = False Then
            Return
        End If

    End Sub
    Private Function InputErrorCheck(ByVal sender As System.Windows.Forms.Control, ByVal tabOrder As Integer) As Boolean
        Dim CheckResult As Nullable(Of Boolean)

        '部課コード
        CheckResult = InputErrorCheck_Control(txtBUKACODE, tabOrder)
        If CheckResult.HasValue Then Return CheckResult.Value

        Return True

    End Function


End Class