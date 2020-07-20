Imports System.ComponentModel

Public Class ComboBoxEx

    Implements IValidatable


    Private Const WM_PASTE As Integer = &H302

    Private Const WM_IME_COMPOSITION As Integer = &H10F
    Private Const GCS_RESULTREADSTR As Integer = &H200

    Private Declare Function ImmGetContext Lib "imm32.dll" Alias "ImmGetContext" (ByVal hwnd As IntPtr) As IntPtr
    Private Declare Function ImmGetCompositionString Lib "imm32.dll" Alias "ImmGetCompositionStringA" (ByVal hIMC As IntPtr, ByVal dwIndex As Integer, ByVal lpBuf As System.Text.StringBuilder, ByVal dwBufLen As Integer) As Integer
    Private Declare Function ImmReleaseContext Lib "imm32.dll" Alias "ImmReleaseContext" (ByVal hwnd As IntPtr, ByVal himc As IntPtr) As Integer

    <Category("Key")> _
    <Description("IMEの入力が確定したときに発生します。")> _
    Public Event CompositionEventHandler As EventHandler(Of CompositionEventArgs)

    
Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        
        If m.Msg = WM_IME_COMPOSITION Then
            If (CType(m.LParam, Integer) And GCS_RESULTREADSTR) > 0 Then
                Dim Imc As IntPtr = ImmGetContext(Me.Handle)
                Dim sz As Integer = ImmGetCompositionString(Imc, GCS_RESULTREADSTR, Nothing, 0)
                Dim str As New System.Text.StringBuilder(sz)

                ImmGetCompositionString(Imc, GCS_RESULTREADSTR, str, str.Capacity)
                ImmReleaseContext(Me.Handle, Imc)

                Dim by() As Byte = System.Text.Encoding.Default.GetBytes(str.ToString())

                Dim e As New CompositionEventArgs
                e.ImeString = System.Text.Encoding.Default.GetString(by, 0, sz)
                RaiseEvent CompositionEventHandler(Me, e)

            End If
        End If

        If m.Msg = WM_PASTE Then

            Dim textLength As Integer = Utility.LenBSA(Text)
            Dim clipString As String = ""
            Dim clipLength As Integer = 0

            Dim iData As IDataObject = Clipboard.GetDataObject()
            If iData.GetDataPresent(DataFormats.Text) Then

                clipString = CType(iData.GetData(DataFormats.Text), String)
                clipLength = Utility.LenBSA(clipString)

                If textLength - Utility.LenBSA(SelectedText) + clipLength <= MaxLength Then

                Else
                    clipString = Utility.LeftBSA(clipString, MaxLength - textLength)

                    Clipboard.SetDataObject(clipString, True)
                End If

            End If

        End If

        MyBase.WndProc(m)
    End Sub

    <Category("Focus")> _
    <Description("コントロールの検証が失敗したときに発生します。")> _
    Public Event ValidateError As EventHandler(Of ValidateErrorEventArgs)

    <Category("Key")> _
    <Description("Enterキーが押されたときに発生します。")> _
    Public Event PressEnter As EventHandler(Of EventArgs)

    <Category("プロパティ変更")> _
    <Description("Textが変更されたときに発生します。")> _
    Public Event TextUpdated As EventHandler(Of EventArgs)

    <Category("検証")> _
    <Description("マスタ存在チェックの検証時に発生します。")> _
    Public Event MasterCheckValidate As EventHandler(Of MasterCheckValidatorEventArgs)

    <Category("Focus")> _
    <Description("リンクテキストの値を変更する必要があるときに発生します。")> _
    Public Event LinkedTextUpdate As EventHandler(Of LinkedTextUpdateEventArgs)

    Protected Sub OnLinkedTextUpdate(ByVal e As LinkedTextUpdateEventArgs)
        'If LastText_LinkedTextUpdate Is Nothing Then
        '    RaiseEvent LinkedTextUpdate(Me, e)
        'Else
        '    If Me.Text <> LastText_LinkedTextUpdate Then
        '        RaiseEvent LinkedTextUpdate(Me, e)
        '    End If
        'End If
        'LastText_LinkedTextUpdate = Me.Text
        RaiseEvent LinkedTextUpdate(Me, e)
    End Sub

    Protected Sub OnMasterCheckValidate(ByVal e As MasterCheckValidatorEventArgs)
        If DesignMode = False Then
            RaiseEvent MasterCheckValidate(Me, e)
        End If
    End Sub

    Private BeforeUpdateText As String

    Private LastText_LinkedTextUpdate As String = Nothing

    Private Sub ZeroPadding()
        If ZeroPaddingLength <> 0 Then
            If Utility.NUCheck(Text) = False Then
                Text = CommonUtility.Utility.ZeroPadding(Text, ZeroPaddingLength, ZeroPaddingChar)
            End If
        End If
    End Sub

    Private ShifKeyValue As Boolean
    Protected Overrides Sub OnKeyDown(ByVal e As System.Windows.Forms.KeyEventArgs)
        MyBase.OnKeyDown(e)
        ShifKeyValue = e.Shift
    End Sub

    Protected Overrides Sub OnKeyPress(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.Handled = False Then
            '↓2009.01.20 Upd Shift+vbCrの場合はエンターイベント発生しない
            'If e.KeyChar = vbCr Then
            If (e.KeyChar = vbCr And ShifKeyValue = False) OrElse (e.KeyChar = ControlChars.Tab And ShifKeyValue = False) Then
                '↑2009.01.20 Upd
                e.Handled = True

                'ゼロ詰め
                If UseZeroPadding Then
                    ZeroPadding()
                End If

                If FindForm.AutoValidate <> AutoValidate.Disable Then
                    'AutoValidateする場合
                    If ValidateMe() Then
                        ValidatedInEnterKey = True
                        OnTextUpdated(New EventArgs())
                        TextUpdatedInEnterKey = True

                        'Enterキー処理
                        If MoveFocusAfterEnter = True Then
                            FindForm().SelectNextControl(Me, True, True, True, True)
                        End If
                    End If
                    '            e.Handled = True
                Else
                    OnTextUpdated(New EventArgs())
                    TextUpdatedInEnterKey = True

                    'Enterキー処理
                    If MoveFocusAfterEnter = True Then
                        FindForm().SelectNextControl(Me, True, True, True, True)
                    End If
                End If

                '名称テキストボックス更新
                If UseUpdateLinkedTextByCodeChange Then
                    OnLinkedTextUpdate(New LinkedTextUpdateEventArgs())
                End If

                If (e.KeyChar = vbCr And ShifKeyValue = False) Then
                    'PressEnterイベント発火
                    OnPressEnter(New EventArgs())
                End If
            End If

            '数字のみ入力チェック
            If DigitOnly = True Then
                If Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Then
                Else
                    e.Handled = True
                End If
            End If
        End If
        MyBase.OnKeyPress(e)
    End Sub

    Protected Overrides Sub OnLeave(ByVal e As System.EventArgs)
        MyBase.OnLeave(e)

        'ゼロ詰め
        If UseZeroPadding Then
            ZeroPadding()
        End If

        '名称テキストボックス更新
        If UseUpdateLinkedTextByCodeChange Then
            OnLinkedTextUpdate(New LinkedTextUpdateEventArgs())
            fncLinkedTextUpdate()
        End If
        OnTextUpdated(New EventArgs())
    End Sub

    Protected Overrides Sub OnValidated(ByVal e As System.EventArgs)
        If ValidatedInEnterKey = True Then
            ValidatedInEnterKey = False
            Return
        End If
        MyBase.OnValidated(e)
    End Sub

    Protected Sub ShowErrorMessageBox(ByVal type As ValidateErrorType)
        Select Case type
            Case ValidateErrorType.InvalidValue
                CommonUtility.WinForm.MessageBoxEx.Show(MessageCode_Arg1.M017を確認して下さい, DisplayName, FindForm.Text)
            Case ValidateErrorType.IsNull
                CommonUtility.WinForm.MessageBoxEx.Show(MessageCode_Arg1.M015は必ず入力して下さい, DisplayName, FindForm.Text)
            Case ValidateErrorType.NotFound
                CommonUtility.WinForm.MessageBoxEx.Show(MessageCode_Arg1.M014が存在しません, DisplayName, FindForm.Text)
            Case ValidateErrorType.ProhibitionInput
                CommonUtility.WinForm.MessageBoxEx.Show(MessageCode_Arg1.M075入力禁止文字が含まれています, DisplayName, FindForm.Text)
            Case ValidateErrorType.IncludeNonDigit
                CommonUtility.WinForm.MessageBoxEx.Show(MessageCode_Arg1.M019には数字を入力して下さい, DisplayName, FindForm.Text)
            Case ValidateErrorType.OverMaxLength
                CommonUtility.WinForm.MessageBoxEx.Show(MessageCode_Arg1.M020の桁数が大きすぎます, DisplayName, FindForm.Text)
            Case Else
                Throw New ApplicationException("ShowErrorMessageBoxエラー")
        End Select
    End Sub

    Protected Overrides Sub OnValidating(ByVal e As System.ComponentModel.CancelEventArgs)
        If DesignMode = False Then
            If ValidatedInEnterKey = True Then
                Return
            End If

            'Null検証
            If UseNullValidator = True Then
                If Utility.NUCheck(Text) = True Then
                    e.Cancel = True
                    If PopupErrorDialog Then
                        ShowErrorMessageBox(ValidateErrorType.IsNull)
                    End If
                    OnValidateError(New ValidateErrorEventArgs(ValidateErrorType.IsNull, CommonUtility.WinForm.MessageBoxEx.GetMessage(MessageCode_Arg1.M015は必ず入力して下さい, DisplayName)))
                    Return
                End If
            End If

            '入力不可文字検証
            If UseProhibitValidator = True And CommonUtility.Utility.NUCheck(Text) = False Then
                If CommonUtility.InputCheck.KinMojiCheck(Me.Text) = False Then
                    e.Cancel = True
                    If PopupErrorDialog Then
                        ShowErrorMessageBox(ValidateErrorType.ProhibitionInput)
                    End If
                    OnValidateError(New ValidateErrorEventArgs(ValidateErrorType.ProhibitionInput, CommonUtility.WinForm.MessageBoxEx.GetMessage(MessageCode_Arg1.M075入力禁止文字が含まれています, DisplayName)))
                    Return
                End If
            End If

            '桁数チェック
            Dim s As String = Text
            If Utility.LenBSA(s) > MaxLength Then
                e.Cancel = True
                If PopupErrorDialog Then
                    ShowErrorMessageBox(ValidateErrorType.OverMaxLength)
                End If
                OnValidateError(New ValidateErrorEventArgs(ValidateErrorType.OverMaxLength, CommonUtility.WinForm.MessageBoxEx.GetMessage(MessageCode_Arg1.M020の桁数が大きすぎます, DisplayName)))
                Return
            End If

            '数字のみ検証
            If DigitOnly And CommonUtility.Utility.NUCheck(Text) = False Then
                If CommonUtility.InputCheck.DigitCheck(Text) = False Then
                    e.Cancel = True
                    If PopupErrorDialog Then
                        ShowErrorMessageBox(ValidateErrorType.IncludeNonDigit)
                    End If
                    OnValidateError(New ValidateErrorEventArgs(ValidateErrorType.IncludeNonDigit, CommonUtility.WinForm.MessageBoxEx.GetMessage(MessageCode_Arg1.M019には数字を入力して下さい, DisplayName)))
                    Return
                End If
            End If

            'マスタ存在チェック検証
            If UseMasterCheckValidator = True And CommonUtility.Utility.NUCheck(Text) = False Then
                Dim eventArgs As New MasterCheckValidatorEventArgs
                OnMasterCheckValidate(eventArgs)
                If eventArgs.Handled = True Then
                    If eventArgs.NotFound = True Then
                        e.Cancel = True
                        If PopupErrorDialog Then
                            ShowErrorMessageBox(ValidateErrorType.NotFound)
                        End If
                        OnValidateError(New ValidateErrorEventArgs(ValidateErrorType.NotFound, CommonUtility.WinForm.MessageBoxEx.GetMessage(MessageCode_Arg1.M014が存在しません, DisplayName)))
                        Return
                    End If
                End If
            End If

        End If

        MyBase.OnValidating(e)
    End Sub

    ''' <summary>
    ''' 自動検証が有効かどうかに応じて、フォーカスを失ったコントロールの値を検証します。
    ''' </summary>
    ''' <returns>検証が成功した場合は true。それ以外の場合は false。</returns>
    ''' <remarks></remarks>
    Public Function ValidateMe() As Boolean Implements IValidatable.ValidateMe
        Dim e As New CancelEventArgs
        OnValidating(e)
        If e.Cancel = False Then
            OnValidated(New EventArgs())
            Return True
        End If
        Return False
    End Function

    Private Sub ComboBoxEx_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DropDownClosed
        'fncLinkedTextUpdate()
    End Sub

    Private Sub ComboBoxEx_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SelectedValueChanged
        fncLinkedTextUpdate()
    End Sub

    Private Sub ComboBoxEx_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SelectedIndexChanged
        If LinkedComboBox IsNot Nothing Then
            LinkedComboBox.Text = Me.Text
            LinkedComboBox.LinkedTextBox.Text = Me.LinkedTextBox.Text
        End If
        'If DesignMode = False Then MyBase.OnPreviewKeyDown(New System.Windows.Forms.PreviewKeyDownEventArgs(Keys.Return)) '2014.07 Ins Kosaka
    End Sub

    Private Sub TextBoxControl_MasterCheckValidate(ByVal sender As Object, ByVal e As MasterCheckValidatorEventArgs) Handles Me.MasterCheckValidate
        'OnMasterCheckValidate(e)
        If e.Handled = True Then
            Return
        End If

        e.Handled = True
        If UseZeroPadding Then Me.Text = CommonUtility.Utility.ZeroFormat(Me.Text, ZeroPaddingLength)
        Dim dataRow As Data.DataRow() = CType(Me.DataSource, Data.DataTable).Select(Me.DisplayMember & " = '" & Me.Text & "'")
        If dataRow.Length = 0 Then
            e.NotFound = True
            Return
        End If

    End Sub

    Public Sub OnValidateError(ByVal e As ValidateErrorEventArgs)
        RaiseEvent ValidateError(Me, e)
    End Sub

    Public Sub OnPressEnter(ByVal e As EventArgs)
        RaiseEvent PressEnter(Me, e)
    End Sub

    Private clickOnAfterEnter As Boolean

    Protected Overrides Sub OnClick(ByVal e As System.EventArgs)
        MyBase.OnClick(e)

        'ハイライト処理
        If clickOnAfterEnter = True Then
            clickOnAfterEnter = False
            If UseHighlightText Then
                Me.SelectAll()
            End If
        End If
    End Sub

    Protected Overrides Sub OnEnter(ByVal e As System.EventArgs)
        MyBase.OnEnter(e)

        'ハイライト処理
        If UseHighlightText Then
            'Me.SelectAll() 'エラーチェックでフォーカスが一瞬移るとハイライトしっぱなしになるため
        End If
        clickOnAfterEnter = True
    End Sub

    Private Sub fncLinkedTextUpdate()
        If UseUpdateLinkedTextByCodeChange And LinkedTextBox IsNot Nothing And Not Utility.NUCheck(ValueMember) And Not Utility.NUCheck(DisplayMember) Then
            LinkedTextBox.Text = GetDisplayMember()
        End If
    End Sub

    Public Function GetDisplayMember() As String

        If Me.Text.IndexOf("'"c) <> -1 Then
            Return ""
        End If
        Dim dataRow As Data.DataRow() = CType(Me.DataSource, Data.DataTable).Select(Me.DisplayMember & " = '" & Me.Text & "'")
        If dataRow.Length = 0 Then
            Return ""
        Else
            Return CType(CommonUtility.Utility.NS(dataRow(0)(Me.ValueMember)), String)
        End If

    End Function

    <Browsable(True)> _
    <Bindable(True)> _
    <DefaultValue("1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890")> _
    Public Overrides Property Text() As String
        Get
            Return MyBase.Text
        End Get
        Set(ByVal value As String)
            MyBase.Text = value
            'If UseUpdateLinkedTextByCodeChange Then
            '    OnLinkedTextUpdate(New LinkedTextUpdateEventArgs())
            'End If
            'OnTextUpdated(New EventArgs())
            If LinkedTextBoxValue IsNot Nothing Then fncLinkedTextUpdate()
        End Set
    End Property

    Public Overridable Function ShouldSerializeText() As Boolean
        If Text <> "1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890" Then
            Return True
        End If
        Return False
    End Function

    ''' <summary>
    ''' TextUpdatedイベント発火
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Sub OnTextUpdated(ByVal e As EventArgs)
        If DesignMode = False Then
            If TextUpdatedInEnterKey = True Then
                TextUpdatedInEnterKey = False
                Return
            End If

            If BeforeUpdateText <> Text Then
                BeforeUpdateText = Text
                RaiseEvent TextUpdated(Me, e)
            End If
        End If
        If DesignMode = False Then
            RaiseEvent TextUpdated(Me, e)
        End If

    End Sub

    Private UseZeroPaddingValue As Boolean

    Private UseNullValidatorValue As Boolean

    Private PopupErrorDialogValue As Boolean

    Private DisplayNameValue As String

    Private ValidatedInEnterKey As Boolean
    Private TextUpdatedInEnterKey As Boolean

    Private ZeroPaddingLengthValue As Integer

    Private MoveFocusAfterEnterValue As Boolean
    Private ZeroPaddingCharValue As Char
    Private UseHighlightTextValue As Boolean

    Private UseMasterCheckValidatorValue As Boolean
    Private UseUpdateLinkedTextByCodeChangeValue As Boolean

    Private LinkedTextBoxValue As TextBox
    Private LinkedComboBoxValue As ComboBoxEx

    Private UseProhibitValidatorValue As Boolean

    Private DigitOnlyValue As Boolean

    Private FixedForeColorValue As Boolean

    'Private Const COLUMN_MARGIN As Integer = 2
    'Private Const ITEM_COUNT As Integer = 10
    Private Column_MarginValue As Integer
    Private Item_CountValue As Integer

    <DefaultValue(2)> _
    <Description("カラムのマージン")> _
    Public Overridable Property Column_Margin() As Integer
        Get
            Return Column_MarginValue
        End Get
        Set(ByVal value As Integer)
            Column_MarginValue = value
        End Set
    End Property

    <DefaultValue(10)> _
    <Description("行数")> _
    Public Overridable Property Item_Count() As Integer
        Get
            Return Item_CountValue
        End Get
        Set(ByVal value As Integer)
            Item_CountValue = value
        End Set
    End Property

    'Private haba(Item_Count - 1) As SizeF
    Private Col_WidthValue() As SizeF

    <DefaultValue(8)> _
    <Description("各列幅")> _
    Public Overridable Property Col_Width(ByVal i As Integer) As SizeF
        Get
            Return Col_WidthValue(i)
        End Get
        Set(ByVal value As SizeF)
            Col_WidthValue(i) = value
        End Set
    End Property


    <DefaultValue(True)> _
    <Description("Enabledプロパティにかかわらず黒色で表示するかどうかを示します。")> _
    Public Property FixedForeColor() As Boolean
        Get
            Return FixedForeColorValue
        End Get
        Set(ByVal value As Boolean)
            FixedForeColorValue = value
            If DesignMode = False Then
                'If Me.Enabled = False And Me.ReadOnly = True And Me.Parent.Enabled = True Then
                If Me.Enabled = False And FixedForeColorValue = True Then
                    Me.SetStyle(ControlStyles.UserPaint, True)
                    RecreateHandle()
                Else
                    Me.SetStyle(ControlStyles.UserPaint, False)
                    RecreateHandle()
                End If
                '再描画
                Me.Invalidate()
            End If

        End Set
    End Property

    '<Browsable(False)> _
    'Public ReadOnly Property TextControl() As TextBoxEx
    '    Get
    '        Return TextBoxControl
    '    End Get
    'End Property

    <Description("コード変更時に名称を表示するコントロールを指定します。")> _
    Public Overridable Property LinkedTextBox() As TextBox
        Get
            Return LinkedTextBoxValue
        End Get
        Set(ByVal value As TextBox)
            LinkedTextBoxValue = value
        End Set
    End Property

    <Description("コード変更時に名称を表示するコントロールを指定します。")> _
    Public Overridable Property LinkedComboBox() As ComboBoxEx
        Get
            Return LinkedComboBoxValue
        End Get
        Set(ByVal value As ComboBoxEx)
            LinkedComboBoxValue = value
        End Set
    End Property

    'Public Sub ResetLinkedTextBox()
    '    LinkedTextBox = Nothing
    'End Sub

    'Public Function ShouldSerializeLinkedTextBox() As Boolean
    '    If LinkedTextBox Is Nothing Then
    '        Return False
    '    Else
    '        Return True
    '    End If
    'End Function

    <DefaultValue(False)> _
    <Description("値が変更されたときに名称を更新するかどうかを示します。")> _
    Public Overridable Property UseUpdateLinkedTextByCodeChange() As Boolean
        Get
            Return UseUpdateLinkedTextByCodeChangeValue
        End Get
        Set(ByVal value As Boolean)
            UseUpdateLinkedTextByCodeChangeValue = value
        End Set
    End Property

    <DefaultValue(False)> _
        <Category("検証")> _
        <Description("値がマスタに存在するかどうかの検証をするかどうかを示します。")> _
        Public Overridable Property UseMasterCheckValidator() As Boolean
        Get
            Return UseMasterCheckValidatorValue
        End Get
        Set(ByVal value As Boolean)
            UseMasterCheckValidatorValue = value
        End Set
    End Property

    <DefaultValue(True)> _
    <Description("Enter押下時にフォーカスを次のコントロールに移動させるかどうかを示します。")> _
    Public Property MoveFocusAfterEnter() As Boolean
        Get
            Return MoveFocusAfterEnterValue
        End Get
        Set(ByVal value As Boolean)
            MoveFocusAfterEnterValue = value
        End Set
    End Property

    <DefaultValue("0"c)> _
    <Description("ゼロ詰めするときの文字を示します。")> _
    Public Overridable Property ZeroPaddingChar() As Char
        Get
            Return ZeroPaddingCharValue
        End Get
        Set(ByVal value As Char)
            ZeroPaddingCharValue = value
        End Set
    End Property

    <DefaultValue(True)> _
    <Description("コントロールがフォームのアクティブコントロールになったときにテキストをハイライトするかどうかを示します。")> _
    Public Property UseHighlightText() As Boolean
        Get
            Return UseHighlightTextValue
        End Get
        Set(ByVal value As Boolean)
            UseHighlightTextValue = value
        End Set
    End Property

    <DefaultValue(False)> _
    <Description("コントロールがフォームのアクティブコントロールでなくなったときにゼロ詰めするかどうかを示します。")> _
    Public Overridable Property UseZeroPadding() As Boolean
        Get
            Return UseZeroPaddingValue
        End Get
        Set(ByVal value As Boolean)
            UseZeroPaddingValue = value
        End Set
    End Property

    <DefaultValue(False)> _
    <Category("検証")> _
    <Description("Nullチェックの検証するかどうかを示します。")> _
    Public Property UseNullValidator() As Boolean
        Get
            Return UseNullValidatorValue
        End Get
        Set(ByVal value As Boolean)
            UseNullValidatorValue = value
        End Set
    End Property

    <DefaultValue("")> _
    <Description("コントロールの表示名を示します。")> _
    Public Property DisplayName() As String
        Get
            Return DisplayNameValue
        End Get
        Set(ByVal value As String)
            DisplayNameValue = value
        End Set
    End Property

    <DefaultValue(0)> _
    <Description("ゼロ詰めの桁数を示します。")> _
    Public Overridable Property ZeroPaddingLength() As Integer
        Get
            Return ZeroPaddingLengthValue
        End Get
        Set(ByVal value As Integer)
            ZeroPaddingLengthValue = value
        End Set
    End Property

    <DefaultValue(True)> _
    <Category("検証")> _
    <Description("検証失敗時に規定のメッセージを表示するかどうかを示します。")> _
    Public Property PopupErrorDialog() As Boolean
        Get
            Return PopupErrorDialogValue
        End Get
        Set(ByVal value As Boolean)
            PopupErrorDialogValue = value
        End Set
    End Property

    <DefaultValue(True)> _
    <Category("検証")> _
    <Description("入力禁止文字の検証するかどうかを示します。")> _
    Public Overridable Property UseProhibitValidator() As Boolean
        Get
            Return UseProhibitValidatorValue
        End Get
        Set(ByVal value As Boolean)
            UseProhibitValidatorValue = value
        End Set
    End Property

    <DefaultValue(False)> _
        <Category("Behavior")> _
    <Description("数字のみが有効な入力として受け付けられるかどうかを示します。")> _
    Public Overridable Property DigitOnly() As Boolean
        Get
            Return DigitOnlyValue
        End Get
        Set(ByVal value As Boolean)
            DigitOnlyValue = value
            If DigitOnlyValue = True Then
                ImeMode = Windows.Forms.ImeMode.Disable
            End If
        End Set
    End Property

    Private haba(Item_Count - 1) As SizeF
    '表示幅の算出
    Private Function upGetHabaTotal() As Integer
        Dim intDropDownWidth As Integer = 0
        For intCol As Integer = 0 To Item_Count - 1
            intDropDownWidth += CType(haba(intCol).Width, Integer)
        Next
        Return intDropDownWidth
    End Function

    Protected Overrides Sub OnDrawItem(ByVal e As System.Windows.Forms.DrawItemEventArgs)
        'このプログラムはコンボボックスが開かれない限りは実行されない
        'このプログラムはコンボボックスのリストを１行ずつ表示する際にその都度実行される

        '境界線の位置
        Dim asngSP(Item_Count - 1) As Single
        For intCol As Integer = 0 To Item_Count - 1
            If intCol = 0 Then asngSP(intCol) = 0 Else asngSP(intCol) = asngSP(intCol - 1)
            If Col_Width(intCol).Width <> 0 Then asngSP(intCol) += Col_Width(intCol).Width
        Next
        'コンボボックスリストの生成
        'リスト１行分の位置データを構造体へ格納する
        Dim inthaba As Integer = upGetHabaTotal()
        Dim rec As New Rectangle(e.Bounds.X, e.Bounds.Y, inthaba, e.Bounds.Height)

        'リストの背景色を描画
        If Me.Enabled Then
            'コンボボックスの使用可能がオンの場合
            If CBool(e.State And DrawItemState.Selected) Then
                'カーソルがある行はハイライト
                e.Graphics.FillRectangle(New SolidBrush(System.Drawing.SystemColors.Highlight), rec)
            Else
                'それ以外は白
                e.Graphics.FillRectangle(New SolidBrush(System.Drawing.SystemColors.Window), rec)
            End If
        Else
            'コンボボックスの使用可能がオフの場合、列をグレーアウトする
            e.Graphics.FillRectangle(New SolidBrush(System.Drawing.SystemColors.Control), rec)
        End If
        'リストの内容を描画
        '（セルのコンボボックスのDetaSourceより、各項目名を書き込む）
        If e.Index > -1 Then
            Dim recColumn As Rectangle, strItemValue As String
            'Dim obj As Object = sender.Items(e.Index)
            Dim obj As Object = Me.Items(e.Index)
            For intCol As Integer = 0 To Item_Count - 1
                If Col_Width(intCol).Width <> 0 Then
                    '各項目の位置情報を設定
                    If intCol = 0 Then
                        recColumn = New Rectangle(Column_Margin, e.Bounds.Y, CType(Col_Width(intCol).Width, Integer), e.Bounds.Height)
                    Else
                        recColumn = New Rectangle(CType(asngSP(intCol - 1) + Column_Margin, Integer), e.Bounds.Y, CType(Col_Width(intCol).Width, Integer), e.Bounds.Height)
                    End If
                    '文字描画
                    strItemValue = obj(intCol).ToString
                    If CBool(e.State And DrawItemState.Selected) Then
                        If strItemValue = "12345678901234567890" Then
                            'Stop
                        End If
                        'カーソルがある行はハイライト
                        e.Graphics.DrawString(strItemValue, e.Font, New SolidBrush(System.Drawing.SystemColors.HighlightText), recColumn)
                    Else
                        'それ以外は標準（黒）
                        e.Graphics.DrawString(strItemValue, e.Font, New SolidBrush(System.Drawing.SystemColors.ControlText), recColumn)
                    End If
                    '境界線描画
                    e.Graphics.DrawLine(New Pen(System.Drawing.SystemColors.ControlDark), asngSP(intCol), e.Bounds.Top, asngSP(intCol), e.Bounds.Bottom)
                End If
            Next
        Else
            'データが無い場合
            e.Graphics.DrawString("", e.Font, New SolidBrush(System.Drawing.SystemColors.ControlText), rec)
        End If
        MyBase.OnDrawItem(e)

    End Sub

    Public Sub New()

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        'データの作成
        Dim ds As Data.DataSet = New Data.DataSet
        Dim dt As Data.DataTable
        dt = ds.Tables.Add("Dummy")
        'dt.Columns.Add("colA", Type.GetType("System.String"))
        dt.Columns.Add("1")

        dt.Rows.Add(New Object() {""})
        Me.DataSource = dt
        Me.DisplayMember = "Dummy"

        UseMasterCheckValidatorValue = False
        'LinkedTextBox = Nothing
        'UseUpdateLinkedTextByCodeChange = False
        'LinkedTextBoxValue = Nothing

        ValidatedInEnterKey = False

        UseZeroPaddingValue = False

        UseNullValidatorValue = False

        DisplayNameValue = ""

        ZeroPaddingLengthValue = 0

        PopupErrorDialogValue = True

        BeforeUpdateText = vbNullString

        MoveFocusAfterEnterValue = True
        ZeroPaddingCharValue = "0"c
        UseHighlightTextValue = True

        UseProhibitValidatorValue = True

        DigitOnlyValue = False

        FixedForeColorValue = True

        Item_CountValue = 2
        Column_MarginValue = 2
        ReDim haba(Item_CountValue - 1)
        For intIndex As Integer = 0 To Item_Count - 1
            ReDim Preserve haba(intIndex)
            haba(intIndex) = Me.CreateGraphics.MeasureString(StrDup(10, "#"), Me.Font)
        Next

        Me.DrawMode = DrawMode.OwnerDrawFixed       'オーナードローモードを指定
        Me.DropDownStyle = ComboBoxStyle.DropDown   '表示スタイル指定

        For intIndex As Integer = 0 To Item_Count - 1
            If haba(intIndex).Width <> 0 Then haba(intIndex).Width += Column_Margin * 2
        Next
        'ドロップダウンリスト幅の指定
        'Me.DropDownWidth = upGetHabaTotal()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。
        Text = "1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890"
        Me.Text = "1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890"

    End Sub

    Private Sub TextBoxEx_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        '横幅を8ピクセル単位に制限する
        'Width = CType(Int(Width / 8), Integer) * 8 + 6
        Width = CType(Int(Width / 8), Integer) * 8 + 7

    End Sub

    Public Sub AttachDataSource(ByVal tableName As Model.ComboBoxTableName, ByVal dataValueSource As Model.DTO.ResponseGetComboBoxContents)

        '※コンボボックスの種類によって分岐ロジックを追加してください。

        Me.DisplayMember = ""

        Dim dt As New Data.DataTable
        dt = dataValueSource.Contents(tableName).ResultDataSet.Tables(0)

        'Me.DataSource = dataValueSource.Contents(tableName).ResultDataSet.Tables(0)
        Me.DataSource = dt.Copy
        Me.DisplayMember = dataValueSource.Contents(tableName).DataValueField
        Me.ValueMember = dataValueSource.Contents(tableName).DataTextFields(0)

        Me.Item_CountValue = 2

        Dim i As Integer = CulcHeight()
        'Me.ItemHeight = 0
        'Me.MaxDropDownItems = CType(i / Me.ItemHeight, Integer) - 10
        MaxDropDownItems = 15    '15個固定にする

        SetWidth(tableName)

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

    Public Sub SetWidth(ByVal tableName As Model.ComboBoxTableName)

        'Item_CountValue = 2
        'Column_MarginValue = 2
        'ReDim haba(Item_CountValue - 1)
        'For intIndex As Integer = 0 To Item_Count - 1
        '    ReDim Preserve haba(intIndex)
        '    haba(intIndex) = Me.CreateGraphics.MeasureString(StrDup(10, "#"), Me.Font)
        'Next

        'If tableName = Model.ComboBoxTableName.M_SENDMAIL Then
        '    Item_CountValue = 3
        '    ReDim haba(Item_CountValue - 1)

        '    ReDim Col_WidthValue(2)

        'Else
        '    ReDim Col_WidthValue(1)
        'End If
        ReDim Col_WidthValue(1)

        Dim MeWidth As Integer = 0
        Dim linkedwidth As Integer = 0

        With Me
            Select Case tableName

                Case Model.ComboBoxTableName.M_KBN
                    MeWidth = 39
                    Col_Width(0) = Me.CreateGraphics.MeasureString(StrDup((4 + 1), "#"), Me.Font)
                    Col_Width(1) = Me.CreateGraphics.MeasureString(StrDup((24 + 1), "#"), Me.Font)
                Case Model.ComboBoxTableName.M_BUKA
                    MeWidth = 47
                    linkedwidth = 326
                    Col_Width(0) = Me.CreateGraphics.MeasureString(StrDup((3 + 1), "#"), Me.Font)
                    Col_Width(1) = Me.CreateGraphics.MeasureString(StrDup((40 + 1), "#"), Me.Font)
                Case Model.ComboBoxTableName.M_TOKUI
                    MeWidth = 127
                    Col_Width(0) = Me.CreateGraphics.MeasureString(StrDup((13 + 1), "#"), Me.Font)
                    Col_Width(1) = Me.CreateGraphics.MeasureString(StrDup((60 + 1), "#"), Me.Font)
                Case Model.ComboBoxTableName.M_TTNAME
                    MeWidth = 127
                    Col_Width(0) = Me.CreateGraphics.MeasureString(StrDup((13 + 1), "#"), Me.Font)
                    Col_Width(1) = Me.CreateGraphics.MeasureString(StrDup((60 + 1), "#"), Me.Font)
                Case Model.ComboBoxTableName.M_TANTO
                    MeWidth = 55
                    Col_Width(0) = Me.CreateGraphics.MeasureString(StrDup((4 + 1), "#"), Me.Font)
                    Col_Width(1) = Me.CreateGraphics.MeasureString(StrDup((20 + 1), "#"), Me.Font)
                Case Else
#If DEBUG Then
                    MsgBox("不正な引数です")
#End If
            End Select

#If DEBUG Then

            'If MeWidth <> Me.Width Then
            '    MsgBox("桁数に合っていない幅です。修正して下さい。 " + vbCrLf + Me.Name + vbCrLf + "ComboBoxEx.SetWidthにMeWidthが設定されていない場合があります。" + vbCrLf + "ない場合はMeWidthを追記して下さい")
            'End If

            If Me.FlatStyle <> Windows.Forms.FlatStyle.Standard Then
                MsgBox("FlatStyleがStandardになっていません。設定をリセットして下さい。コントロール＝" + Me.Name)
            End If

            If linkedwidth <> 0 Then
                If Me.LinkedTextBox IsNot Nothing Then
                    If LinkedTextBox.Width <> linkedwidth Then
                        MsgBox("コンボボックス右側の名称の幅がテーブルの列幅と一致していません。変更して下さい。" + vbCrLf + "コントロール：" + LinkedTextBox.Name + vbCrLf + "幅：" + linkedwidth.ToString)
                    End If
                End If
            End If
#End If

            Dim intWidth As Integer = 0
            For intCol As Integer = 0 To UBound(Col_WidthValue)
                intWidth += CType(Col_Width(intCol).Width, Integer)
                haba(intCol).Width += Col_Width(intCol).Width
            Next
            .DropDownWidth = intWidth

            .Text = ""
            If not .LinkedTextBox Is Nothing Then
                .LinkedTextBox.Text = ""
            End If

            Me.SelectedIndex = -1

        End With
    End Sub
    'Protected Overrides Sub OnReadOnlyChanged(ByVal e As System.EventArgs)
    '    MyBase.OnReadOnlyChanged(e)
    '    If BackColor = Color.White Or BackColor = Color.FromArgb(236, 233, 216) Or BackColor = System.Drawing.SystemColors.Control Or BackColor = System.Drawing.SystemColors.Window Then
    '        If Me.Enabled = True And Me.ReadOnly = False Then
    '            BackColor = Color.White
    '        Else
    '            BackColor = Color.FromArgb(236, 233, 216)
    '        End If
    '    End If

    'End Sub

    Protected Overrides Function IsInputChar(ByVal charCode As Char) As Boolean
        'MAXLENGTHチェック(ProcessDialogCharを常に発生させる)
        MyBase.IsInputChar(charCode)
        Return False
    End Function

    Protected Overrides Sub OnEnabledChanged(ByVal e As System.EventArgs)
        MyBase.OnEnabledChanged(e)

        'If Me.Enabled = True Then
        '    Me.BackColor = Color.White
        'Else
        '    Me.BackColor = Color.FromArgb(236, 233, 216)
        'End If
        If BackColor = Color.White Or BackColor = Color.FromArgb(236, 233, 216) Or BackColor = System.Drawing.SystemColors.Control Or BackColor = System.Drawing.SystemColors.Window Then
            If Me.Enabled = True Then
                BackColor = Color.White
            Else
                BackColor = Color.FromArgb(236, 233, 216)
            End If
        End If

        ''EnabledがFalseでFixedForeColorがtrueの時だけ自分で描画する
        'If DesignMode = False Then
        '    'If Me.Enabled = False And Me.ReadOnly = True And Me.Parent.Enabled = True Then
        '    If Me.Enabled = False And FixedForeColor = True Then
        '        Me.SetStyle(ControlStyles.UserPaint, True)
        '        RecreateHandle()
        '    Else
        '        Me.SetStyle(ControlStyles.UserPaint, False)
        '        RecreateHandle()
        '    End If
        '    '再描画
        '    Me.Invalidate()
        'End If

    End Sub

    Protected Overrides Sub OnPreviewKeyDown(ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs)
        If (e.KeyCode = Keys.Tab) AndAlso (Not e.Shift) Then e.IsInputKey = True
        MyBase.OnPreviewKeyDown(e)
    End Sub

    Private Sub ComboBoxEx_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Down Then
            Me.DroppedDown = True
        End If
    End Sub

End Class
