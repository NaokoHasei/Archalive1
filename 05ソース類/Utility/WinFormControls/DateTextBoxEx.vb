Imports System.ComponentModel

Public Class DateTextBoxEx

    Implements IValidatable

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
        'System.Diagnostics.Trace.WriteLine(Me.Name + Me.Font.ToString())
    End Sub

    Protected Overrides Sub OnKeyPress(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = vbCr Then
            e.Handled = True
            'If UseZeroPadding Then
            '    ZeroPadding()
            'End If
            If FindForm.AutoValidate <> AutoValidate.Disable Then
                If ValidateMe() Then
                    ValidatedInEnterKey = True
                    OnTextUpdated(New EventArgs())
                    TextUpdatedInEnterKey = True
                    If MoveFocusAfterEnter = True Then
                        FindForm().SelectNextControl(Me, True, True, True, True)
                    End If
                End If
                '            e.Handled = True
            Else
                OnTextUpdated(New EventArgs())
                TextUpdatedInEnterKey = True
                If MoveFocusAfterEnter = True Then
                    FindForm().SelectNextControl(Me, True, True, True, True)
                End If
            End If
            OnPressEnter(New EventArgs())
        End If
        MyBase.OnKeyPress(e)
    End Sub

    'Protected Overrides Sub OnKeyPress(ByVal e As System.Windows.Forms.KeyPressEventArgs)
    '    If e.KeyChar = vbCr Then
    '        'If UseZeroPadding Then
    '        '    ZeroPadding()
    '        'End If
    '        If FindForm.AutoValidate <> AutoValidate.Disable Then
    '            If ValidateMe() Then
    '                ValidatedInEnterKey = True
    '                FindForm().SelectNextControl(Me, True, True, True, True)
    '            End If
    '            '            e.Handled = True
    '        Else
    '            FindForm().SelectNextControl(Me, True, True, True, True)
    '        End If
    '    End If
    '    MyBase.OnKeyPress(e)
    'End Sub

    Protected Overrides Sub OnLeave(ByVal e As System.EventArgs)
        MyBase.OnLeave(e)
        'If UseZeroPadding Then
        '    ZeroPadding()
        'End If
        OnTextUpdated(New EventArgs())
    End Sub

    Protected Overrides Sub OnValidated(ByVal e As System.EventArgs)
        If ValidatedInEnterKey = True Then
            ValidatedInEnterKey = False
            Return
        End If
        MyBase.OnValidated(e)
    End Sub

    Private Sub ShowErrorMessageBox(ByVal type As ValidateErrorType)
        Select Case type
            Case ValidateErrorType.InvalidValue
                CommonUtility.WinForm.MessageBoxEx.Show(MessageCode_Arg1.M017を確認して下さい, DisplayName, FindForm.Text)
            Case ValidateErrorType.IsNull
                CommonUtility.WinForm.MessageBoxEx.Show(MessageCode_Arg1.M015は必ず入力して下さい, DisplayName, FindForm.Text)
            Case Else
                Throw New ApplicationException("ShowErrorMessageBoxエラー")
        End Select
    End Sub

    Protected Overrides Sub OnValidating(ByVal e As System.ComponentModel.CancelEventArgs)
        If ValidatedInEnterKey = True Then
            Return
        End If

        If UseNullValidator = True Then
            'If Text = Replace(Mask, "0", "_") Then
            If Text = Mask.Replace("0", "_") Then
                e.Cancel = True
                If PopupErrorDialog Then
                    ShowErrorMessageBox(ValidateErrorType.IsNull)
                End If
                OnValidateError(New ValidateErrorEventArgs(ValidateErrorType.IsNull, CommonUtility.WinForm.MessageBoxEx.GetMessage(MessageCode_Arg1.M015は必ず入力して下さい, DisplayName)))
                Return
            End If
            If Text = "    /  /" Then
                e.Cancel = True
                If PopupErrorDialog Then
                    ShowErrorMessageBox(ValidateErrorType.IsNull)
                End If
                OnValidateError(New ValidateErrorEventArgs(ValidateErrorType.IsNull, CommonUtility.WinForm.MessageBoxEx.GetMessage(MessageCode_Arg1.M015は必ず入力して下さい, DisplayName)))
                Return
            End If
        End If

        'If Text <> Replace(Mask, "0", "_") Then
        If Text <> Replace(Mask, "0", "_") AndAlso (Text.Replace(" ", "").Replace("/", "") <> Mask.Replace("0", "").Replace("/", "")) Then
            If ValidateText() Is Nothing Then
                e.Cancel = True
                If PopupErrorDialog Then
                    ShowErrorMessageBox(ValidateErrorType.InvalidValue)
                End If
                OnValidateError(New ValidateErrorEventArgs(ValidateErrorType.IsNull, CommonUtility.WinForm.MessageBoxEx.GetMessage(MessageCode_Arg1.M017を確認して下さい, DisplayName)))
                Return
            End If

            If Me.Text < Utility.MIN_DATE Or Me.Text > Utility.MAX_DATE Then
                e.Cancel = True
                If PopupErrorDialog Then
                    ShowErrorMessageBox(ValidateErrorType.InvalidValue)
                End If
                OnValidateError(New ValidateErrorEventArgs(ValidateErrorType.IsNull, CommonUtility.WinForm.MessageBoxEx.GetMessage(MessageCode_Arg1.M017を確認して下さい, DisplayName)))
                Return
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

    <Category("Focus")> _
    <Description("コントロールの検証が失敗したときに発生します。")> _
    Public Event ValidateError As EventHandler(Of ValidateErrorEventArgs)

    <Category("Key")> _
    <Description("Enterキーが押されたときに発生します。")> _
    Public Event PressEnter As EventHandler(Of EventArgs)

    <Category("プロパティ変更")> _
    <Description("Textが変更されたときに発生します。")> _
    Public Event TextUpdated As EventHandler(Of EventArgs)

    Private BeforeUpdateText As String

    Public Sub OnValidateError(ByVal e As ValidateErrorEventArgs)
        RaiseEvent ValidateError(Me, e)
    End Sub

    Public Sub OnPressEnter(ByVal e As EventArgs)
        RaiseEvent PressEnter(Me, e)
    End Sub

    Protected Overrides Sub OnClick(ByVal e As System.EventArgs)
        MyBase.OnClick(e)
        If clickOnAfterEnter = True Then
            clickOnAfterEnter = False
            If UseHighlightText Then
                Me.SelectAll()
            End If
        End If
    End Sub

    Protected Overrides Sub OnGotFocus(ByVal e As System.EventArgs)
        MyBase.OnGotFocus(e)
        If UseHighlightText Then
            Me.SelectAll()
        End If
    End Sub

    Protected Overrides Sub OnEnter(ByVal e As System.EventArgs)
        MyBase.OnEnter(e)
        clickOnAfterEnter = True
    End Sub

    Public Sub OnTextUpdated(ByVal e As EventArgs)
        If TextUpdatedInEnterKey = True Then
            TextUpdatedInEnterKey = False
            Return
        End If

        If BeforeUpdateText <> Text Then
            BeforeUpdateText = Text
            RaiseEvent TextUpdated(Me, e)
        End If

    End Sub

    'Private UseZeroPaddingValue As Boolean

    Private UseNullValidatorValue As Boolean

    Private PopupErrorDialogValue As Boolean

    Private DisplayNameValue As String

    Private ValidatedInEnterKey As Boolean

    Private TextUpdatedInEnterKey As Boolean

    Private MoveFocusAfterEnterValue As Boolean
    Private UseHighlightTextValue As Boolean

    Private clickOnAfterEnter As Boolean

    Private FixedForeColorValue As Boolean

    Private LinkedDateTextBoxValue As DateTextBoxEx

    <Description("コード変更時に名称を表示するコントロールを指定します。")> _
    Public Overridable Property LinkedDateTextBox() As DateTextBoxEx
        Get
            Return LinkedDateTextBoxValue
        End Get
        Set(ByVal value As DateTextBoxEx)
            LinkedDateTextBoxValue = value
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

    Public Sub New()

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。

        ValidatedInEnterKey = False

        'UseZeroPaddingValue = False

        UseNullValidatorValue = False

        DisplayNameValue = ""

        'ZeroPaddingLengthValue = 0

        PopupErrorDialogValue = True

        BeforeUpdateText = vbNullString

        MoveFocusAfterEnterValue = True
        UseHighlightTextValue = True

        ValidatingType = GetType(Date)

        FixedForeColorValue = True

    End Sub

    Private Sub MaskedTextBoxEx_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Width = CType(Int(Width / 8), Integer) * 8 + 6
    End Sub

    Protected Overrides Sub OnEnabledChanged(ByVal e As System.EventArgs)
        MyBase.OnEnabledChanged(e)
        If Me.Enabled = True And Me.ReadOnly = False Then
            BackColor = Color.White
        Else
            BackColor = Color.FromArgb(236, 233, 216)
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

    Private Sub DateTextBoxEx_TextUpdated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.TextUpdated
        If LinkedDateTextBox IsNot Nothing Then
            LinkedDateTextBox.Text = Me.Text
        End If
    End Sub

End Class
