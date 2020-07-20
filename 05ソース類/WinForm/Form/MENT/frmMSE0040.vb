Imports CommonUtility
Imports CommonUtility.WinFormControls
Imports CommonUtility.WinForm
Imports System.Drawing

Public Class frmMSE0040

    Enum COL
        KBN = 0
        KBNNAME = 1
        BIKO = 2
        ATAI1 = 3
        ATAI2 = 4
        SYOKIHYOUJIKBN = 5
    End Enum

    Enum 削除区分

        行削除
        全削除
    End Enum

    Private formStatusValue As FormStatus

    Private Enum FormStatus
        Header1Input
        Detail1Input
        Detail2Input
    End Enum

    Public Overrides Function PROGRAM_ID() As String
        Return "MSE0040"
    End Function

    Public Overrides Function PROGRAM_NAME() As String
        Return "区分マスタ登録"
    End Function

    Protected Overrides Sub Form_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        MyBase.Form_Load(sender, e)

        Using wcur As New WaitCursor

            '画面初期化

            Call subInitDisp()

            'グリッド初期化

            Call subInitGrid()

            'コンボボックス初期設定

            Call subInitCombo()

            'イベント指定

            AddHandler txtSIYOUKBN.Enter, AddressOf EnterEventHandler
            AddHandler txtKBNNAME1.Enter, AddressOf EnterEventHandler
            AddHandler txtKBNNAME2.Enter, AddressOf EnterEventHandler
            AddHandler txtBIKO.Enter, AddressOf EnterEventHandler
            AddHandler txtATAI1.Enter, AddressOf EnterEventHandler
            AddHandler txtATAI2.Enter, AddressOf EnterEventHandler
            AddHandler chkSYOKIHYOJIKBN.Enter, AddressOf EnterEventHandler

        End Using

    End Sub

    Private Sub subInitCombo()

        Dim logic As New BLL.Common.TypComboBox

        'コンボボックスデータ取得

        Dim paramlist As New List(Of Model.DTO.RequestGetComboBoxContentsElement)
        paramlist.Add(New Model.DTO.RequestGetComboBoxContentsElement(Model.ComboBoxTableName.M_KBN, Model.DTO.GetComboBoxContentsResultFieldType.MultipleField, False, "00"))

        Dim requestParam As New Model.DTO.RequestGetComboBoxContents(paramlist)
        Dim recieveParam As Model.DTO.ResponseGetComboBoxContents

        recieveParam = logic.CreateComboBox(requestParam)

        txtSIYOUKBN.AttachDataSource(Model.ComboBoxTableName.M_KBN, recieveParam)

    End Sub

    Private Sub subInitGrid()

        GridSetup(New DataGridViewTextBoxColumn, gridData, True, "KBN", "KBN", "区分", ColumnValueType.String_)
        GridSetup(New DataGridViewTextBoxColumn, gridData, True, "KBNNAME", "KBNNAME", "名　称", ColumnValueType.String_)
        GridSetup(New DataGridViewTextBoxColumn, gridData, True, "BIKO", "BIKO", "備　考", ColumnValueType.String_)
        GridSetup(New DataGridViewTextBoxColumn, gridData, True, "ATAI1", "ATAI1", "値１", ColumnValueType.String_)
        GridSetup(New DataGridViewTextBoxColumn, gridData, True, "ATAI2", "ATAI2", "値２", ColumnValueType.String_)
        GridSetup(New DataGridViewCheckBoxColumn, gridData, True, "SYOKIHYOUJIKBN", "SYOKIHYOUJIKBN", "初期表示")

        With gridData

            '自動的に列追加なし

            .AutoGenerateColumns = False

            .Columns(COL.KBN).Width = ((4 + 1) * 8) + 5
            .Columns(COL.KBNNAME).Width = ((20 + 1) * 8) + 5
            .Columns(COL.BIKO).Width = (27 * 8) + 5 + 3
            .Columns(COL.SYOKIHYOUJIKBN).Width = ((8 + 1) * 8) + 5

            .Columns(COL.ATAI1).Visible = False
            .Columns(COL.ATAI2).Visible = False

        End With

        Call GridSetup(gridData, GridSetupAllows.AllowReadOnly)

    End Sub


    ''' <summary>
    ''' カレントレコード表示
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub subDisplayCurrentData()
        With gridData.CurrentRow
            txtKBN.Text = CType(.Cells(COL.KBN).Value, String)
            txtKBNNAME2.Text = CType(.Cells(COL.KBNNAME).Value, String)
            txtBIKO.Text = CType(.Cells(COL.BIKO).Value, String)
            txtATAI1.Text = CType(.Cells(COL.ATAI1).Value, String)
            txtATAI2.Text = CType(.Cells(COL.ATAI2).Value, String)
            chkSYOKIHYOJIKBN.Checked = CType(IIf(CType(.Cells(COL.SYOKIHYOUJIKBN).Value, Integer) = 1, True, False), Boolean)
        End With
    End Sub

    Private Sub subInitDisp()
        formStatusValue = FormStatus.Header1Input
        Call FormControl(formStatusValue)
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="formStatus"></param>
    ''' <remarks></remarks>
    Private Sub FormControl(ByVal formStatus As FormStatus)

        FunctionKey.ClearAll()

        If formStatus = frmMSE0040.FormStatus.Header1Input Then
            txtSIYOUKBN.Text = ""
            lblBIKO.Text = ""
            txtKBN.Text = ""
            txtKBNNAME1.Text = ""
            txtKBNNAME2.Text = ""
            txtBIKO.Text = ""
            txtATAI1.Text = ""
            txtATAI2.Text = ""
            txtKBNNAME1.ReadOnly = True
            chkSYOKIHYOJIKBN.Checked = False

            PanelHeader1.Enabled = True
            PanelHeader2.Enabled = False
            PanelDetail1.Enabled = False
            PanelDetail2.Enabled = False

            FunctionKey.SetItem(1, "終了", "終了", True)

            gridData.DataSource = New Data.DataTable

            txtSIYOUKBN.Focus()

        Else
            If formStatus = frmMSE0040.FormStatus.Detail1Input Then
                TitleBar.EditMode = EditMode.None

                txtKBNNAME2.Text = ""
                txtBIKO.Text = ""
                txtATAI1.Text = ""
                txtATAI2.Text = ""
                txtKBNNAME1.ReadOnly = False
                chkSYOKIHYOJIKBN.Checked = False

                PanelHeader1.Enabled = False
                PanelHeader2.Enabled = True
                PanelDetail1.Enabled = True
                PanelDetail2.Enabled = False

                FunctionKey.SetItem(5, "全削除", "全削除", True)

                txtKBNNAME1.Focus()
            End If

            If formStatus = frmMSE0040.FormStatus.Detail2Input Then
                PanelHeader1.Enabled = False
                PanelHeader2.Enabled = False
                PanelDetail1.Enabled = False
                PanelDetail2.Enabled = True
                txtKBNNAME1.ReadOnly = False

                FunctionKey.SetItem(5, "行削除", "行削除", True)
                FunctionKey.SetItem(12, "登録", "登録", True)

                txtKBNNAME2.Focus()
            End If

            FunctionKey.SetItem(1, "取消", "取消", True)
        End If
    End Sub

    Private Sub EnterEventHandler(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If CType(sender, Control).CausesValidation = False Then
            Return
        End If

        If InputErrorCheck(CType(sender, Control), GetTabOrder(CType(sender, Control))) = False Then
            Return
        End If

    End Sub

    ''' <summary>
    ''' 入力検査
    ''' </summary>
    ''' <remarks></remarks>
    Private Function InputErrorCheck(ByVal sender As Control, ByVal tabOrder As Integer) As Boolean

        Dim CheckResult As Nullable(Of Boolean)

        'コード

        CheckResult = InputErrorCheck_Control(txtSIYOUKBN, tabOrder)
        If CheckResult.HasValue Then Return CheckResult.Value

        With txtSIYOUKBN
            If .Text = Utility.ZeroPadding("0", .MaxLength) Then
                MessageBoxEx.Show(MessageCode_Arg0.M107このコードは使用できません, PROGRAM_NAME)
                Return False
            End If
        End With

        Return True

    End Function

    ''' <summary>
    ''' 全項目検査
    ''' </summary>
    ''' <remarks></remarks>
    Public Function AllInputValidate() As Boolean
        Return InputErrorCheck(Nothing, 9999999)
    End Function

    Protected Overrides Sub FunctionKeyAction(ByVal sender As System.Object, ByVal e As CommonUtility.WinFormControls.FunctionKeyEventArgs)

        Select Case e.Name

            Case "終了"
                Me.Close()

            Case "取消"

                Select Case formStatusValue
                    Case FormStatus.Detail1Input
                        formStatusValue = FormStatus.Header1Input
                        Call FormControl(formStatusValue)
                        Call subInitCombo()
                        txtSIYOUKBN.Focus()
                    Case FormStatus.Detail2Input
                        formStatusValue = FormStatus.Detail1Input
                        Call FormControl(formStatusValue)
                        txtKBN.Focus()
                    Case Else
                End Select

            Case "全削除"

                If MessageBoxEx.Show(MessageCode_Arg0.M105全削除してもよろしいですか, PROGRAM_NAME) <> Windows.Forms.DialogResult.Yes Then Exit Select

                Call masterDelete(削除区分.全削除)

                Call subInitDisp()

                Call subInitCombo()

                txtSIYOUKBN.Focus()

            Case "行削除"

                If MessageBoxEx.Show(MessageCode_Arg0.M106行削除してもよろしいですか, PROGRAM_NAME) <> Windows.Forms.DialogResult.Yes Then Exit Select

                Call masterDelete(削除区分.行削除)

                formStatusValue = FormStatus.Detail1Input
                Call FormControl(formStatusValue)

                Call MasterRead(txtSIYOUKBN.Text)

                txtKBNNAME1.Focus()

            Case "登録"

                '入力チェック
                If AllInputValidate() = False Then Return

                If MessageBoxEx.Show(MessageCode_Arg0.M001登録してもよろしいですか, PROGRAM_NAME) <> Windows.Forms.DialogResult.Yes Then Exit Select

                'マスタ更新
                Call masterUpdate()

                formStatusValue = FormStatus.Detail1Input
                Call FormControl(formStatusValue)

                Call MasterRead(txtSIYOUKBN.Text)

                txtKBN.Focus()

                txtKBN.Text = ""
                txtKBNNAME2.Text = ""

            Case Else

        End Select

    End Sub

    ''' <summary>
    ''' マスタ更新
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub masterUpdate()

        Using wcur As New WaitCursor

            Dim updateData As New dsMSE0040
            updateData.M_KBNUpdate.AddM_KBNUpdateRow(txtSIYOUKBN.Text, txtKBN.Text, txtKBNNAME1.Text, txtKBNNAME2.Text, txtBIKO.Text, txtATAI1.Text, txtATAI2.Text, CType(IIf(chkSYOKIHYOJIKBN.Checked, 1, 0), Byte), PROGRAM_ID, TANTO_CODE)
            Dim logic As New daMSE0040
            Call logic.UpdateData(updateData)

        End Using

    End Sub

    Private Sub masterDelete(ByVal 区分 As 削除区分)

        Using wcur As New WaitCursor

            Dim logic As New daMSE0040
            If 区分 = 削除区分.行削除 Then
                logic.DeleteData(txtSIYOUKBN.Text, txtKBN.Text)
            ElseIf 区分 = 削除区分.全削除 Then
                logic.DeleteData(txtSIYOUKBN.Text)
            End If

        End Using

    End Sub

    Private Sub MasterRead(ByVal strSIYOUKBN As String)

        Using wcur As New WaitCursor

            Dim logic As New daMSE0040
            Dim DataTable As dsMSE0040.M_KBNDataTable = logic.GetDataTable(strSIYOUKBN)

            gridData.DataSource = Nothing
            If gridData.Rows.Count <> 0 Then gridData.Rows.Clear()
            For Each row As dsMSE0040.M_KBNRow In DataTable.Rows
                gridData.Rows.Add(row.KBN, row.KBNNAME, row.BIKO, row.ATAI1, row.ATAI2, row.SYOKIHYOJIKBN)
            Next

            If DataTable.Rows.Count = 0 Then
                txtKBNNAME1.Text = ""
            End If

        End Using

    End Sub

    Private Sub MasterRead(ByVal strSIYOUKBN As String, ByVal strKBN As String)

        Using wcur As New WaitCursor

            Dim logic As New daMSE0040
            Dim DataTable As dsMSE0040.M_KBNDataTable = logic.GetDataTable(strSIYOUKBN, strKBN)

            If DataTable.Rows.Count = 0 Then
                TitleBar.EditMode = EditMode.Create
            Else
                TitleBar.EditMode = EditMode.Edit
                txtKBNNAME2.Text = DataTable(0).KBNNAME
                txtBIKO.Text = DataTable(0).BIKO
                txtATAI1.Text = DataTable(0).ATAI1
                txtATAI2.Text = DataTable(0).ATAI2
                chkSYOKIHYOJIKBN.Checked = CType(IIf(DataTable(0).SYOKIHYOJIKBN = 0, False, True), Boolean)
            End If

        End Using

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub gridData_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridData.CellDoubleClick

        If e.RowIndex < 0 Then Exit Sub

        Call subDisplayCurrentData()

        TitleBar.EditMode = EditMode.Edit

        formStatusValue = FormStatus.Detail2Input
        Call FormControl(formStatusValue)

    End Sub

    Private Sub txtSIYOUKBN_PressEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSIYOUKBN.PressEnter

        '使用区分チェック（標準）

        If Not txtSIYOUKBN.ValidateMe Then
            txtSIYOUKBN.Focus()
            Return
        End If

        '使用区分チェック
        If InputErrorCheck(CType(sender, Control), GetTabOrder(CType(sender, Control)) + 1) = False Then
            Return
        End If

        Call MasterRead(txtSIYOUKBN.Text)
        Dim logic As New daMSE0040
        Dim DataTable As dsMSE0040.M_KBNDataTable = logic.GetDataTable("00", txtSIYOUKBN.Text)
        If DataTable.Rows.Count <> 0 Then
            lblBIKO.Text = DataTable(0).BIKO
        End If

        formStatusValue = FormStatus.Detail1Input
        Call FormControl(formStatusValue)

    End Sub

    Private Sub txtKBN_PressEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtKBN.PressEnter
        '使用区分チェック（標準）

        If Not txtKBN.ValidateMe Then
            txtKBN.Focus()
            Return
        End If

        Call MasterRead(txtSIYOUKBN.Text, txtKBN.Text)

        formStatusValue = FormStatus.Detail2Input
        Call FormControl(formStatusValue)
    End Sub

End Class
