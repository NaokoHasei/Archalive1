Imports C1.Win.C1TrueDBGrid
Imports System.ComponentModel
Imports Model

Public Class MitumoriNoComboBox

    Implements IValidatable

    Public Function ValidateMe() As Boolean Implements IValidatable.ValidateMe
        Dim e As New System.ComponentModel.CancelEventArgs
        OnValidating(e)
        If e.Cancel = False Then
            OnValidated(New EventArgs())
            Return True
        End If
        Return False
    End Function

    Private valueSelected As Boolean

    Private selectedDataRow As DataRow

    Private NoValueOpen As Boolean

    Public Overrides Property BackColor() As System.Drawing.Color
        Get
            Return MyBase.BackColor
        End Get
        Set(ByVal value As System.Drawing.Color)
            MyBase.BackColor = value
            TextControl.BackColor = value
        End Set
    End Property

    Public ReadOnly Property SelectedValue() As DataRow
        Get
            Return selectedDataRow
        End Get
    End Property

    Public ReadOnly Property GridControl() As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Get
            Return DropDownIcon
        End Get
    End Property

    <Browsable(False)> _
    Public Overrides Property AutoValidate() As System.Windows.Forms.AutoValidate
        Get
            Return Windows.Forms.AutoValidate.Disable
        End Get
        Set(ByVal value As System.Windows.Forms.AutoValidate)
            MyBase.AutoValidate = value
        End Set
    End Property

    Private Sub TypComboBox_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        If Width > 20 Then
            Dim w As Integer = Width
            '            w -= 20
            w = CType(Int(w / 8), Integer) * 8
            '            w += 21
            Width = w + 2
        End If
        Height = TextBoxControl.Height + 2
        '        TextBoxControl.Location = New System.Drawing.Point(0, 0)
        '        TextBoxControl.Size = New System.Drawing.Size(Me.Size.Width - 20, Me.Size.Height)
        TextBoxControl.Left = 0
        TextBoxControl.Top = 0
        'TextBoxControl.Width = Width - 20
        TextBoxControl.Width = 0

        'DropDownIcon.Left = Width - 20
        DropDownIcon.Left = 0
        DropDownIcon.Top = 0
        DropDownIcon.Width = 20
        DropDownIcon.Height = 20
        '        DropDownIcon.Location = New System.Drawing.Point(Me.Size.Width - 20 - 0, 0)
        '        DropDownIcon.Size = New System.Drawing.Size(20, 20)
    End Sub

    Public Sub AttachDataSource(ByVal tableName As ComboBoxTableName, ByVal dataValueSource As DTO.ResponseGetComboBoxContents)
        DropdownControl.DataSource = dataValueSource.Contents(tableName).ResultDataSet.Tables(0)
        DropDown.DataMember = ""

        DisplayMemberValue = dataValueSource.Contents(tableName).DataTextFields(1)

        DropDown.ValueMember = dataValueSource.Contents(tableName).DataValueField

        DropDown.SetWidth(tableName)

        'プロパティ検証
#If DEBUG Then
        'If Me.Width < 6 * GetCodeLength(tableName) Then
        '    'Throw New ApplicationException(Me.Name & ":Widthを確認してください")
        '    MessageBox.Show(Me.Name & ":Widthを確認してください", FindForm.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'End If

        If UseZeroPadding = True Then
            If ZeroPaddingLength <> GetCodeLength(tableName) Then
                Throw New ApplicationException(Me.Name & ":ZeroPaddingLengthは" & GetCodeLength(tableName).ToString & "でなければなりません")
            End If
        End If

        If UseUpdateLinkedTextByCodeChange = True And LinkedTextBox IsNot Nothing Then
            If LinkedTextBox.Width < 8 * GetNameLength(tableName) Then
                'Throw New ApplicationException(LinkedTextBox.Name & ":名称表示用のテキストボックスのWidthを確認してください")
                MessageBox.Show(LinkedTextBox.Name & ":名称表示用のテキストボックスのWidthを確認してください", FindForm.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

            If LinkedTextBox.ReadOnly = False Then
                Throw New ApplicationException(LinkedTextBox.Name & ":名称表示用のテキストボックスはreadonlyでなければなりません")
            End If

            If LinkedTextBox.Enabled = True Then
                Throw New ApplicationException(LinkedTextBox.Name & ":名称表示用のテキストボックスはEnabled = Falseでなければなりません")
            End If
        End If

        If PopupErrorDialog = True Then
            If Utility.NUCheck(Me.DisplayName) = True Then
                Throw New ApplicationException(LinkedTextBox.Name & ":PopupErrorDialog使用時はDisplayNameをかならず指定してください")
            End If
        End If
#End If

        '幅の計算
        Dim x As Integer = 0
        For i As Integer = 0 To DropDown.DisplayColumns.Count - 1
            x += DropDown.DisplayColumns(i).Width + 1
            'セルの境界線なし
            DropDown.DisplayColumns(i).ColumnDivider.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.None
        Next

        DropDown.Width = x + DropdownControl.VScrollBar.Width + 2
        DropDown.Height = CulcHeight()
    End Sub

    Private Function GetCodeLength(ByVal tableName As ComboBoxTableName) As Integer
        Select Case tableName
            Case ComboBoxTableName.T_MITUMORIHED_MITUMORINO
            Case ComboBoxTableName.T_JYUTYUHED_JYUTYUNO
            Case ComboBoxTableName.T_HATYUHED_HATYUNO
            Case ComboBoxTableName.T_SEIKYUHED_SEIKYUNO
                Return 13
            Case Else
                Throw New ApplicationException("対応していないコンボボックス種別です。")

        End Select
    End Function

    Private Function GetNameLength(ByVal tableName As ComboBoxTableName) As Integer
        Select Case tableName
            Case ComboBoxTableName.T_MITUMORIHED_MITUMORINO
            Case ComboBoxTableName.T_JYUTYUHED_JYUTYUNO
            Case ComboBoxTableName.T_HATYUHED_HATYUNO
            Case ComboBoxTableName.T_SEIKYUHED_SEIKYUNO
            Case Else
                Throw New ApplicationException("対応していないコンボボックス種別です。")
        End Select

    End Function

    Private Sub TypComboBox_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With DropDown
            .AllowRowSizing = RowSizingEnum.None    '行サイズの変更
            .FlatStyle = FlatModeEnum.Standard
            .RowDivider.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.None          '行の境界線スタイル
            .DisplayColumns(0).ColumnDivider.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.None
            .HeadingStyle.Borders.BorderType = C1.Win.C1TrueDBGrid.BorderTypeEnum.None
            '.HeadingStyle.BackColor = Color.FromArgb(0, 0, 192)
            .HeadingStyle.BackColor = Color.DarkSlateBlue
            .HeadingStyle.ForeColor = Color.White
            .ColumnCaptionHeight = 20
            .RowHeight = 20
            .AllowSort = False
            If Me.FindForm IsNot Nothing Then
                .Font = Me.FindForm.Font
            End If
            .AllowRowSizing = RowSizingEnum.None 'スプリットのサイズ変更
            .AllowColSelect = False
            .VScrollBar.Style = ScrollBarStyleEnum.Always
            .ExtendRightColumn = True       'デッドエリア（隙間）を埋める
        End With

        With DropDownIcon
            .Splits(0).DisplayColumns(0).OwnerDraw = True
        End With
    End Sub

    <Browsable(False)> _
    Public ReadOnly Property TextControl() As TextBoxEx
        Get
            Return TextBoxControl
        End Get
    End Property

    Private DropDownCLosed As Boolean = False

    Private Sub Dropdown_DropDownClose(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropdownControl.DropDownClose
        '       DropDownIcon.Enabled = False

        If valueSelected = True Then
            RaiseEvent SelectionChangeCommitted(Me, e)
        End If
        '        TextControl.Focus()
        RaiseEvent DropDownClose(Me, e)
        DropDownCLosed = True
        DropDownIcon.Invalidate() 'OwnerDrawイベントを発生させる
    End Sub

    Private Sub DropDownIcon_OwnerDrawCell(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.OwnerDrawCellEventArgs) Handles DropDownIcon.OwnerDrawCell
        If DropDownCLosed = True Then
            DropDownCLosed = False
            TextControl.Focus() 'テキストボックスにフォーカス
            '            DropDownIcon.Enabled = True
        End If
    End Sub

    Private Sub DropDownIcon_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DropDownIcon.KeyDown
        If e.KeyCode = Keys.Enter Then
            If DropDown.Bookmark >= 0 Then
                valueSelected = True
                selectedDataRow = CType(DropDown.DataSource, DataTable).Rows(DropDown.Bookmark)
                Text = CType(DropDown.Columns(DropDown.ValueMember).Text, String)
            End If
        End If
    End Sub

    Private Function CulcHeight() As Integer
        Dim offset As Integer = 0
        Dim form As Control = Me.FindForm

        Dim c As Control = Me
        Do While True
            offset += c.Top
            c = c.Parent
            If c.Name = form.Name Then
                Exit Do
            End If
        Loop

        Dim intNotBottomWorkingArea As Integer = ((System.Windows.Forms.Screen.GetBounds(Me).Height - System.Windows.Forms.Screen.GetWorkingArea(Me).Height) - System.Windows.Forms.Screen.GetWorkingArea(Me).Y)  '画面下の作業領域外
        Return CType((System.Windows.Forms.Screen.GetBounds(Me).Height - intNotBottomWorkingArea) - ((offset + form.Top) + 68), Integer)

    End Function

    Private Sub Dropdown_DropDownOpen(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropdownControl.DropDownOpen

        valueSelected = False
        NoValueOpen = False '2009.02.13 Ins asano V1～V3対応

        Dim dataRow As DataRow() = CType(DropdownControl.DataSource, DataTable).Select(DropdownControl.ValueMember & " = '" & TextBoxControl.Text & "'")
        If dataRow.Length = 1 Then
            DropDown.Bookmark = CType(DropDown.DataSource, DataTable).Rows.IndexOf(dataRow(0))
            DropDown.Row = CType(DropDown.DataSource, DataTable).Rows.IndexOf(dataRow(0))
        Else
            '↓2009.02.13 Ins asano V1～V3対応
            If DropDown.Bookmark <> 0 Then
                NoValueOpen = True
            End If
            DropDown.Bookmark = 0
            DropDown.Row = 0
            '↑2009.02.13 Ins asano V1～V3対応
        End If

        RaiseEvent DropDownOpen(Me, e)
    End Sub

    <Description("ドロップダウンが閉じるときに発生します。")> _
    Public Event DropDownClose As EventHandler(Of EventArgs)

    <Description("ドロップダウンが最初に表示されるときに発生します。")> _
    Public Event DropDownOpen As EventHandler(Of EventArgs)

    <Description("選択した項目が変更され、その変更が TypComboBox に表示されると発生します。")> _
    Public Event SelectionChangeCommitted As EventHandler(Of EventArgs)

    <Category("Key")> _
    <Description("Enterキーが押されたときに発生します。")> _
    Public Event PressEnter As EventHandler(Of EventArgs)

    <Category("検証")> _
    <Description("マスタ存在チェックの検証時に発生します。")> _
    Public Event MasterCheckValidate As EventHandler(Of MasterCheckValidatorEventArgs)

    <Category("Focus")> _
    <Description("リンクテキストの値を変更する必要があるときに発生します。")> _
    Public Event LinkedTextUpdate As EventHandler(Of LinkedTextUpdateEventArgs)

    Public Sub OnLinkedTextUpdate(ByVal e As LinkedTextUpdateEventArgs)
        RaiseEvent LinkedTextUpdate(Me, e)
    End Sub

    Public Sub OnMasterCheckValidate(ByVal e As MasterCheckValidatorEventArgs)
        RaiseEvent MasterCheckValidate(Me, e)
    End Sub

    '    Public Shadows Event KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    Public Shadows Event KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

    <DefaultValue(32768)> _
    <Description("エディットコントロールに入力できる最大文字数を指定します。")> _
    Public Property MaxLength() As Integer
        Get
            Return TextBoxControl.MaxLength
        End Get
        Set(ByVal value As Integer)
            TextBoxControl.MaxLength = value
        End Set
    End Property

    <DefaultValue(True)> _
    <Description("Enter押下時にフォーカスを次のコントロールに移動させるかどうかを示します。")> _
    Public Property MoveFocusAfterEnter() As Boolean
        Get
            Return TextBoxControl.MoveFocusAfterEnter
        End Get
        Set(ByVal value As Boolean)
            TextBoxControl.MoveFocusAfterEnter = value
        End Set
    End Property

    <DefaultValue("0"c)> _
    <Description("ゼロ詰めするときの文字を示します。")> _
    Public Property ZeroPaddingChar() As Char
        Get
            Return TextBoxControl.ZeroPaddingChar
        End Get
        Set(ByVal value As Char)
            TextBoxControl.ZeroPaddingChar = value
        End Set
    End Property

    <DefaultValue(True)> _
    <Description("コントロールがフォームのアクティブコントロールになったときにテキストをハイライトするかどうかを示します。")> _
    Public Property UseHighlightText() As Boolean
        Get
            Return TextBoxControl.UseHighlightText
        End Get
        Set(ByVal value As Boolean)
            TextBoxControl.UseHighlightText = value
        End Set
    End Property

    <Description("データ ソースを取得します。")> _
    <Browsable(False)> _
    Public ReadOnly Property DataSource() As Object
        Get
            Return DropdownControl.DataSource
        End Get
    End Property

    <Browsable(False)> _
    Public ReadOnly Property DropDown() As DropdownEx
        Get
            Return DropdownControl
        End Get
    End Property

    <Description("グリッドが連結するマルチメンバデータソースで特定のデータメンバを取得します。")> _
    Public ReadOnly Property DataMember() As String
        Get
            Return DropDown.DataMember
        End Get
    End Property

    Private DisplayMemberValue As String

    <DefaultValue("")> _
    <Description("名称の更新に使用するフィールドを取得します。")> _
    Public ReadOnly Property DisplayMember() As String
        Get
            Return DisplayMemberValue
        End Get
    End Property

    'Public Property Value() As String
    '    Get
    '        Return TextBoxControl.Text
    '    End Get
    '    Set(ByVal value As String)
    '        TextBoxControl.Text = value
    '    End Set
    'End Property

    Public Function GetDisplayMember() As String
        If TextBoxControl.Text.IndexOf("'"c) <> -1 Then
            Return ""
        End If
        Dim dataRow As DataRow() = CType(DropdownControl.DataSource, DataTable).Select(DropdownControl.ValueMember & " = '" & TextBoxControl.Text & "'")
        If dataRow.Length = 0 Then
            Return ""
        Else
            Return CType(dataRow(0)(DisplayMember), String)
        End If

    End Function

    Public Function GetFirstCode() As String
        If CType(DropdownControl.DataSource, DataTable).Rows.Count = 0 Then
            Return ""
        End If
        Return CType(CType(DropdownControl.DataSource, DataTable).Rows(0)(DropdownControl.ValueMember), String)
    End Function

    Public Function GetMaxCode() As String
        Return Utility.ZeroPadding("9", MaxLength, CChar("9"))
    End Function
    Public Function GetMinCode() As String
        Return Utility.ZeroPadding("0", MaxLength, CChar("0"))
    End Function

    Private Sub fncLinkedTextUpdate()
        If UseUpdateLinkedTextByCodeChange And LinkedTextBox IsNot Nothing And Utility.NUCheck(DisplayMember) = False Then
            LinkedTextBox.Text = GetDisplayMember()
            'Dim dataRow As DataRow() = CType(DropdownControl.DataSource, DataTable).Select(DropdownControl.ValueMember & " = '" & TextBoxControl.Text & "'")
            'If dataRow.Length = 0 Then
            '    LinkedTextBox.Text = ""
            'Else
            '    LinkedTextBox.Text = CType(dataRow(0)(DisplayMember), String)
            'End If
        End If
    End Sub

    <Browsable(True)> _
    <Bindable(True)> _
        <DefaultValue("1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890")> _
            Public Overrides Property Text() As String
        Get
            Return TextBoxControl.Text
        End Get
        Set(ByVal value As String)
            TextBoxControl.Text = value
            'fncLinkedTextUpdate()
        End Set
    End Property

    Private Sub DropdownControl_RowChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DropdownControl.RowChange
        If DropDown.Bookmark <> -1 Then
            '↓2009.02.13 Ins asano V1～V3対応
            'If NoValueOpen = False Then
            valueSelected = True
            selectedDataRow = CType(DropDown.DataSource, DataTable).Rows(DropDown.Bookmark)
            Text = CType(DropDown.Columns(DropDown.ValueMember).Text, String)
            'End If
            NoValueOpen = False
            '↑2009.02.13 Ins asano V1～V3対応
        End If
    End Sub

    'Public Overrides Property Font() As System.Drawing.Font
    '    Get
    '        Return MyBase.Font
    '    End Get
    '    Set(ByVal value As System.Drawing.Font)
    '        TextBoxControl.Font = value
    '        MyBase.Font = value
    '    End Set
    'End Property

    <Category("Focus")> _
    <Description("コントロールの検証が失敗したときに発生します。")> _
    Public Event ValidateError As EventHandler(Of ValidateErrorEventArgs)

    <Category("Focus")> _
    <Description("Textが変更されるかフォーカスを失ったときに発生します。")> _
    Public Event TextUpdated As EventHandler(Of EventArgs)

    Public Sub OnValidateError(ByVal e As ValidateErrorEventArgs)
        RaiseEvent ValidateError(Me, e)
    End Sub


    <DefaultValue(False)> _
    <Description("コントロールがフォームのアクティブコントロールでなくなったときにゼロ詰めするかどうかを示します。")> _
    Public Property UseZeroPadding() As Boolean
        Get
            Return TextBoxControl.UseZeroPadding
        End Get
        Set(ByVal value As Boolean)
            TextBoxControl.UseZeroPadding = value
        End Set
    End Property

    <DefaultValue(False)> _
    <Category("検証")> _
    <Description("値がNullかどうかの検証をするかどうかを示します。")> _
    Public Property UseNullValidator() As Boolean
        Get
            Return TextBoxControl.UseNullValidator
        End Get
        Set(ByVal value As Boolean)
            TextBoxControl.UseNullValidator = value
        End Set
    End Property

    'Private UseMasterCheckValidatorValue As Boolean
    'Private UseUpdateLinkedTextByCodeChangeValue As Boolean

    <DefaultValue(False)> _
    <Description("値が変更されたときに名称を更新するかどうかを示します。")> _
    Public Property UseUpdateLinkedTextByCodeChange() As Boolean
        Get
            Return TextControl.UseUpdateLinkedTextByCodeChange
        End Get
        Set(ByVal value As Boolean)
            TextControl.UseUpdateLinkedTextByCodeChange = value
        End Set
    End Property

    <DefaultValue(False)> _
        <Category("検証")> _
        <Description("値がマスタに存在するかどうかの検証をするかどうかを示します。")> _
        Public Property UseMasterCheckValidator() As Boolean
        Get
            Return TextControl.UseMasterCheckValidator
        End Get
        Set(ByVal value As Boolean)
            TextControl.UseMasterCheckValidator = value
        End Set
    End Property

    <DefaultValue("")> _
    <Description("コントロールの表示名を示します。")> _
    Public Property DisplayName() As String
        Get
            Return TextBoxControl.DisplayName
        End Get
        Set(ByVal value As String)
            TextBoxControl.DisplayName = value
        End Set
    End Property

    <DefaultValue(0)> _
    <Description("ゼロ詰めの桁数を示します。")> _
    Public Property ZeroPaddingLength() As Integer
        Get
            Return TextBoxControl.ZeroPaddingLength
        End Get
        Set(ByVal value As Integer)
            TextBoxControl.ZeroPaddingLength = value
        End Set
    End Property

    <DefaultValue(True)> _
    <Category("検証")> _
    <Description("検証失敗時に規定のメッセージを表示するかどうかを示します。")> _
    Public Property PopupErrorDialog() As Boolean
        Get
            Return TextBoxControl.PopupErrorDialog
        End Get
        Set(ByVal value As Boolean)
            TextBoxControl.PopupErrorDialog = value
        End Set
    End Property

    Private Sub TextBoxControl_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles TextBoxControl.PreviewKeyDown
        If e.KeyCode = Keys.Down Then
            DropDownIcon.Focus()
            SendKeys.Send("%{DOWN}")
        End If
    End Sub

    <Description("コード変更時に名称を表示するコントロールを指定します。")> _
    Public Property LinkedTextBox() As TextBox
        Get
            Return TextControl.LinkedTextBox
        End Get
        Set(ByVal value As TextBox)
            TextControl.LinkedTextBox = value
        End Set
    End Property

    Public Sub ResetLinkedTextBox()
        LinkedTextBox = Nothing
    End Sub

    Public Function ShouldSerializeLinkedTextBox() As Boolean
        If LinkedTextBox Is Nothing Then
            Return False
        Else
            Return True
        End If
    End Function

    Public Sub New()
        DisplayMemberValue = ""

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。

        TextBoxControl.DigitOnly = True

        'データの作成
        Dim ds As DataSet = New DataSet
        Dim dt As DataTable
        dt = ds.Tables.Add("Dummy")
        dt.Columns.Add("ColumnA", Type.GetType("System.String"))

        dt.Rows.Add(New Object() {""})


        'グリッドの設定
        DropDownIcon.Columns.Add(New C1DataColumn("", "ColumnA", Type.GetType("System.String")))

        DropDownIcon.Splits(0).DisplayColumns(0).Width = 17
        DropDownIcon.Splits(0).DisplayColumns(0).HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
        DropDownIcon.Splits(0).DisplayColumns(0).Style.HorizontalAlignment = AlignHorzEnum.Center
        DropDownIcon.Splits(0).DisplayColumns(0).Visible = True

        'データ連結
        DropdownControl.DataSource = dt
        DropdownControl.DataMember = "Dummy"

        DropDownIcon.SetDataBinding(dt, "", True)
        DropDownIcon.Columns(0).DropDown = DropdownControl

        DropDownIcon.ColumnHeaders = False
        DropDownIcon.RecordSelectors = False


    End Sub

    Private Sub ShowErrorMessageBox(ByVal type As ValidateErrorType)
        Select Case type
            Case ValidateErrorType.IsNull
                CommonUtility.WinForm.MessageBoxEx.Show(MessageCode_Arg1.M015は必ず入力して下さい, DisplayName, FindForm.Text)

            Case ValidateErrorType.NotFound
                CommonUtility.WinForm.MessageBoxEx.Show(MessageCode_Arg1.M014が存在しません, DisplayName, FindForm.Text)
            Case Else
                Throw New ApplicationException("ShowErrorMessageBoxエラー")
        End Select
    End Sub

    Protected Overrides Sub OnValidating(ByVal e As System.ComponentModel.CancelEventArgs)

        If TextBoxControl.ValidateMe() = False Then
            'Text = CType(DropDown.Columns(DropDown.ValueMember).Text, String)
            DropDown.Bookmark = Nothing
            e.Cancel = True
            If Me.FindForm.AutoValidate = Windows.Forms.AutoValidate.EnablePreventFocusChange Then
                TextBoxControl.Focus()
            End If
            Return
        End If

        MyBase.OnValidating(e)

    End Sub

    Private Sub TextBoxControl_LinkedTextUpdate(ByVal sender As Object, ByVal e As LinkedTextUpdateEventArgs) Handles TextBoxControl.LinkedTextUpdate
        OnLinkedTextUpdate(e)
        If e.Handled = False Then
            fncLinkedTextUpdate()
        End If
    End Sub

    Private Sub TextBoxControl_MasterCheckValidate(ByVal sender As Object, ByVal e As MasterCheckValidatorEventArgs) Handles TextBoxControl.MasterCheckValidate

    End Sub

    Private Sub TextBoxControl_PressEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxControl.PressEnter
        OnPressEnter(e)
    End Sub

    Private Sub TextBoxControl_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxControl.TextChanged
        OnTextChanged(e)
    End Sub

    Private Sub TextBoxControl_TextUpdated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxControl.TextUpdated
        If DesignMode = False Then
            OnTextUpdated(e)
        End If
    End Sub

    Private Sub TextBoxControl_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxControl.Validated
        MyBase.OnValidated(e)
    End Sub

    Private Sub TextBoxControl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TextBoxControl.Validating
        MyBase.OnValidating(e)
    End Sub


    Public Sub OnTextUpdated(ByVal e As EventArgs)
        If DesignMode = False Then
            RaiseEvent TextUpdated(Me, e)
        End If
    End Sub

    Public Sub OnPressEnter(ByVal e As EventArgs)
        RaiseEvent PressEnter(Me, e)
    End Sub

    Protected Overrides Sub OnEnabledChanged(ByVal e As System.EventArgs)
        MyBase.OnEnabledChanged(e)

        If Me.Enabled = True Then
            TextControl.BackColor = Color.White
        Else
            TextControl.BackColor = Color.FromArgb(236, 233, 216)
        End If
    End Sub

End Class
