Imports System.ComponentModel

Public Class TextBoxEx

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

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)

        'カスタム描画コードをここに追加します。

        Dim sf As New StringFormat

        Select Case Me.TextAlign
            Case HorizontalAlignment.Center
                sf.Alignment = StringAlignment.Center
            Case HorizontalAlignment.Left
                sf.Alignment = StringAlignment.Near
            Case HorizontalAlignment.Right
                sf.Alignment = StringAlignment.Far
        End Select

        Dim tf As New TextFormatFlags
        Dim rect As Rectangle
        Select Case Me.TextAlign
            Case HorizontalAlignment.Center
                tf = TextFormatFlags.HorizontalCenter
                rect = New Rectangle(-1, 1, Me.Width, Me.Height)
            Case HorizontalAlignment.Left
                tf = TextFormatFlags.Left
                rect = New Rectangle(-2, 1, Me.Width, Me.Height)
            Case HorizontalAlignment.Right
                tf = TextFormatFlags.Right
                rect = New Rectangle(-1, 1, Me.Width, Me.Height)
        End Select
        tf = tf Or TextFormatFlags.NoPrefix
        '黒色で描画します
        Dim b As New System.Drawing.SolidBrush(Me.ForeColor)
        '文字列を描画する
        System.Windows.Forms.TextRenderer.DrawText(e.Graphics, Me.Text, Me.Font, rect, Me.ForeColor, Me.BackColor, tf)
        'e.Graphics.DrawString(Me.Text, Me.Font, b, New Rectangle(-1, 2, Me.Width, Me.Height), sf)
        b.Dispose()
    End Sub

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

                            For i As Integer = 0 To 20
                                Dim activeControl = FindForm.ActiveControl
                                'ボタン以外の場合、処理終了
                                If Not (TypeOf activeControl Is Button) Or e.KeyChar = ControlChars.Tab Then Exit For
                                '次のコントロールをフォーカス
                                FindForm().SelectNextControl(activeControl, True, True, True, True)
                            Next

                        End If
                    End If
                    '            e.Handled = True
                Else
                    OnTextUpdated(New EventArgs())
                    TextUpdatedInEnterKey = True

                    'Enterキー処理
                    If MoveFocusAfterEnter = True Then
                        FindForm().SelectNextControl(Me, True, True, True, True)

                        For i As Integer = 0 To 20
                            Dim activeControl = FindForm.ActiveControl
                            'ボタン以外の場合、処理終了
                            If Not (TypeOf activeControl Is Button) Or e.KeyChar = ControlChars.Tab Then Exit For
                            '次のコントロールをフォーカス
                            FindForm().SelectNextControl(activeControl, True, True, True, True)
                        Next

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

            'ディレクトリパス検証
            If UseDirectoryPathValidator = True And CommonUtility.Utility.NUCheck(Text) = False Then
                If CommonUtility.InputCheck.PathKinMojiCheck(Me.Text) = False Then
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
            If TypeOf (Me) Is NumberTextBoxEx Then
                If IsNumeric(s) = False Then
                    e.Cancel = True
                    If PopupErrorDialog Then
                        ShowErrorMessageBox(ValidateErrorType.IncludeNonDigit)
                    End If
                    OnValidateError(New ValidateErrorEventArgs(ValidateErrorType.IncludeNonDigit, CommonUtility.WinForm.MessageBoxEx.GetMessage(MessageCode_Arg1.M019には数字を入力して下さい, DisplayName)))
                    Return
                End If
                Dim d As Decimal = CDec(Text)
                Dim c As New NumberTextBoxEx
                c = CType(Me, NumberTextBoxEx)
                If d < c.MinValue OrElse d > c.MaxValue Then
                    e.Cancel = True
                    If PopupErrorDialog Then
                        ShowErrorMessageBox(ValidateErrorType.OverMaxLength)
                    End If
                    OnValidateError(New ValidateErrorEventArgs(ValidateErrorType.OverMaxLength, CommonUtility.WinForm.MessageBoxEx.GetMessage(MessageCode_Arg1.M020の桁数が大きすぎます, DisplayName)))
                    Return
                End If
            Else
                If Utility.LenBSA(s) > MaxLength Then
                    e.Cancel = True
                    If PopupErrorDialog Then
                        ShowErrorMessageBox(ValidateErrorType.OverMaxLength)
                    End If
                    OnValidateError(New ValidateErrorEventArgs(ValidateErrorType.OverMaxLength, CommonUtility.WinForm.MessageBoxEx.GetMessage(MessageCode_Arg1.M020の桁数が大きすぎます, DisplayName)))
                    Return
                End If
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

    Public Function GetMaxCode() As String
        Return Utility.ZeroPadding("9", MaxLength, CChar("9"))
    End Function
    Public Function GetMinCode() As String
        Return Utility.ZeroPadding("0", MaxLength, CChar("0"))
    End Function

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

    Private BeforeUpdateText As String

    Private LastText_LinkedTextUpdate As String = Nothing

    ''' <summary>
    ''' 名称テキストボックス更新イベント発火
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub OnLinkedTextUpdate(ByVal e As LinkedTextUpdateEventArgs)
        If LastText_LinkedTextUpdate Is Nothing Then
            RaiseEvent LinkedTextUpdate(Me, e)
        Else
            If Me.Text <> LastText_LinkedTextUpdate Then
                RaiseEvent LinkedTextUpdate(Me, e)
            End If
        End If
        LastText_LinkedTextUpdate = Me.Text
    End Sub

    Public Sub OnValidateError(ByVal e As ValidateErrorEventArgs)
        RaiseEvent ValidateError(Me, e)
    End Sub

    Public Sub OnPressEnter(ByVal e As EventArgs)
        RaiseEvent PressEnter(Me, e)
    End Sub

    Protected Sub OnMasterCheckValidate(ByVal e As MasterCheckValidatorEventArgs)
        If DesignMode = False Then
            RaiseEvent MasterCheckValidate(Me, e)
        End If
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
            Me.SelectAll()
        End If
        clickOnAfterEnter = True
    End Sub

    <DefaultValue("1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890")> _
    Public Overrides Property Text() As String
        Get
            Return MyBase.Text
        End Get
        Set(ByVal value As String)
            MyBase.Text = value
            If UseUpdateLinkedTextByCodeChange Then
                OnLinkedTextUpdate(New LinkedTextUpdateEventArgs())
            End If
            OnTextUpdated(New EventArgs())
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

    Private UseProhibitValidatorValue As Boolean

    Private UseDirectoryPathValidatorValue As Boolean

    Private DigitOnlyValue As Boolean

    Private FixedForeColorValue As Boolean


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

    <Description("コード変更時に名称を表示するコントロールを指定します。")> _
        Public Overridable Property LinkedTextBox() As TextBox
        Get
            Return LinkedTextBoxValue
        End Get
        Set(ByVal value As TextBox)
            LinkedTextBoxValue = value
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
    <Category("検証")> _
    <Description("入力禁止文字の検証するかどうかを示します。(ディレクトリパス)")> _
    Public Overridable Property UseDirectoryPathValidator() As Boolean
        Get
            Return UseDirectoryPathValidatorValue
        End Get
        Set(ByVal value As Boolean)
            UseDirectoryPathValidatorValue = value
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

    Public Sub New()

        UseMasterCheckValidatorValue = False
        LinkedTextBox = Nothing
        UseUpdateLinkedTextByCodeChange = False

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

        UseDirectoryPathValidatorValue = False

        DigitOnlyValue = False

        FixedForeColorValue = True

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。
        Text = "1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890"

    End Sub


    Private Sub TextBoxEx_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        '横幅を8ピクセル単位に制限する
        Width = CType(Int(Width / 8), Integer) * 8 + 6
    End Sub

    Protected Overrides Sub OnEnabledChanged(ByVal e As System.EventArgs)
        MyBase.OnEnabledChanged(e)
        If BackColor = Color.White Or BackColor = Color.FromArgb(236, 233, 216) Or BackColor = System.Drawing.SystemColors.Control Or BackColor = System.Drawing.SystemColors.Window Then
            If Me.Enabled = True And Me.ReadOnly = False Then
                BackColor = Color.White
            Else
                BackColor = Color.FromArgb(236, 233, 216)
            End If
        End If

        'EnabledがFalseでFixedForeColorがtrueの時だけ自分で描画する
        If DesignMode = False Then
            'If Me.Enabled = False And Me.ReadOnly = True And Me.Parent.Enabled = True Then
            If Me.Enabled = False And FixedForeColor = True Then
                Me.SetStyle(ControlStyles.UserPaint, True)
                RecreateHandle()
            Else
                Me.SetStyle(ControlStyles.UserPaint, False)
                RecreateHandle()
            End If
            '再描画
            Me.Invalidate()
        End If

    End Sub

    Protected Overrides Sub OnReadOnlyChanged(ByVal e As System.EventArgs)
        MyBase.OnReadOnlyChanged(e)
        If BackColor = Color.White Or BackColor = Color.FromArgb(236, 233, 216) Or BackColor = System.Drawing.SystemColors.Control Or BackColor = System.Drawing.SystemColors.Window Then
            If Me.Enabled = True And Me.ReadOnly = False Then
                BackColor = Color.White
            Else
                BackColor = Color.FromArgb(236, 233, 216)
            End If
        End If

    End Sub

    Protected Overrides Function IsInputChar(ByVal charCode As Char) As Boolean
        'MAXLENGTHチェック(ProcessDialogCharを常に発生させる)
        MyBase.IsInputChar(charCode)
        Return False
    End Function

    Protected Overrides Function ProcessDialogChar(ByVal charCode As Char) As Boolean

        'MAXLENGTHチェック

        Dim inputLength As Integer = Utility.LenBSA(charCode.ToString)
        Dim textLength As Integer = Utility.LenBSA(Text)

        If Char.IsControl(charCode) Then
            Return MyBase.ProcessDialogChar(charCode)
        End If

        If textLength + inputLength - Utility.LenBSA(SelectedText) > MaxLength Then
            Return True
        End If
        Return MyBase.ProcessDialogChar(charCode)

    End Function

    Protected Overrides Sub OnPreviewKeyDown(ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs)
        If (e.KeyCode = Keys.Tab) AndAlso (Not e.Shift) Then e.IsInputKey = True
        MyBase.OnPreviewKeyDown(e)
    End Sub

End Class

Public Enum ValidateErrorType
    UserDefine
    IsNull
    InvalidValue
    NotFound
    ProhibitionInput
    IncludeNonDigit
    OverMaxLength
End Enum

Public Class CompositionEventArgs
    Inherits EventArgs

    Public ImeString As String

End Class

Public Class LinkedTextUpdateEventArgs
    Inherits EventArgs

    Private handledValue As Boolean

    ''' <summary>
    ''' イベントが処理されたかどうかを示す値を取得または設定します。
    ''' </summary>
    ''' <value></value>
    ''' <returns>イベントが処理された場合は true。それ以外の場合は false。</returns>
    ''' <remarks></remarks>
    Public Property Handled() As Boolean
        Get
            Return handledValue
        End Get
        Set(ByVal value As Boolean)
            handledValue = value
        End Set
    End Property


    Public Sub New()
        Handled = False
    End Sub

End Class

Public Class MasterCheckValidatorEventArgs
    Inherits EventArgs

    Private handledValue As Boolean
    Private notFoundValue As Boolean

    ''' <summary>
    ''' イベントが処理されたかどうかを示す値を取得または設定します。
    ''' </summary>
    ''' <value></value>
    ''' <returns>イベントが処理された場合は true。それ以外の場合は false。</returns>
    ''' <remarks></remarks>
    Public Property Handled() As Boolean
        Get
            Return handledValue
        End Get
        Set(ByVal value As Boolean)
            handledValue = value
        End Set
    End Property

    ''' <summary>
    ''' データが存在するかどうかを示す値を取得または設定します。
    ''' </summary>
    ''' <value></value>
    ''' <returns>データが存在しなかった場合は true。それ以外の場合は false。</returns>
    ''' <remarks></remarks>
    Public Property NotFound() As Boolean
        Get
            Return notFoundValue
        End Get
        Set(ByVal value As Boolean)
            notFoundValue = value
        End Set
    End Property

    Public Sub New()
        Handled = False
        NotFound = False
    End Sub

End Class
Public Class ValidateErrorEventArgs
    Inherits EventArgs

    Private ValidateErrorTypeValue As ValidateErrorType
    Private ErrorMessageValue As String

    Public Property ValidateErrorType() As ValidateErrorType
        Get
            Return ValidateErrorTypeValue
        End Get
        Set(ByVal value As ValidateErrorType)
            ValidateErrorTypeValue = value
        End Set
    End Property

    Public Property ErrorMessage() As String
        Get
            Return ErrorMessageValue
        End Get
        Set(ByVal value As String)
            ErrorMessageValue = value
        End Set
    End Property

    Public Sub New(ByVal validateErrorType As ValidateErrorType, ByVal errorMessage As String)
        ValidateErrorTypeValue = validateErrorType
        ErrorMessageValue = errorMessage
    End Sub
    Public Sub New(ByVal validateErrorType As ValidateErrorType)
        ValidateErrorTypeValue = validateErrorType
    End Sub
    Public Sub New()
        ValidateErrorTypeValue = WinFormControls.ValidateErrorType.UserDefine
    End Sub

End Class