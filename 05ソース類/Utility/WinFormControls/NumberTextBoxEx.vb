Imports System.ComponentModel

Public Class NumberTextBoxEx

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)

        'カスタム描画コードをここに追加します。
    End Sub
    Private _MinValue As Decimal
    Private _MaxValue As Decimal
    Private numberFormatValue As String

    <DefaultValue(0)> _
    <Description("入力可能な最小値を示します。")> _
    Public Property MinValue() As Decimal
        Get
            Return _MinValue
        End Get
        Set(ByVal value As Decimal)
            _MinValue = value
        End Set
    End Property

    <DefaultValue(0)> _
    <Description("入力可能な最大値を示します。")> _
    Public Property MaxValue() As Decimal
        Get
            Return _MaxValue
        End Get
        Set(ByVal value As Decimal)
            _MaxValue = value
        End Set
    End Property

    <Description("値を示します。")> _
    <Browsable(False)> _
    Public Property Value() As Decimal
        Get
            If Utility.NUCheck(Text) = True Then
                Return 0
            End If
            Return CType(Text.Replace(",", ""), Decimal)
        End Get
        Set(ByVal value As Decimal)
            Text = Format(value, NumberFormat)
        End Set
    End Property

    <DefaultValue("#,##0")> _
    <Description("書式を示します。")> _
    Public Property NumberFormat() As String
        Get
            Return numberFormatValue
        End Get
        Set(ByVal value As String)
            numberFormatValue = value
        End Set
    End Property

    Protected Function ValidateType() As Boolean
        Try
            Dim v As Decimal = CType(Text, Decimal)
            Return True
        Catch ex As InvalidCastException
            Return False
        End Try
    End Function


    Protected Overrides Sub OnLeave(ByVal e As System.EventArgs)
        MyBase.OnLeave(e)
        If ValidateType() = True Then
            Text = Format(Value, NumberFormat)
        Else
            Text = "0"
        End If
    End Sub

    Protected Overrides Sub OnEnter(ByVal e As System.EventArgs)
        Text = Text.Replace(",", "")
        MyBase.OnEnter(e)
    End Sub

    Protected Overrides Sub OnValidating(ByVal e As System.ComponentModel.CancelEventArgs)
        MyBase.OnValidating(e)
        If e.Cancel = True Then
            Return
        End If

        Try
            Dim val As Decimal = CType(Text, Decimal)

            If val < MinValue OrElse val > MaxValue Then
                e.Cancel = True

                If PopupErrorDialog Then
                    ShowErrorMessageBox(ValidateErrorType.InvalidValue)
                End If
                OnValidateError(New ValidateErrorEventArgs(ValidateErrorType.InvalidValue, CommonUtility.WinForm.MessageBoxEx.GetMessage(MessageCode_Arg1.M017を確認して下さい, DisplayName)))

            End If

        Catch ex As InvalidCastException

            e.Cancel = True

            If PopupErrorDialog Then
                ShowErrorMessageBox(ValidateErrorType.InvalidValue)
            End If
            OnValidateError(New ValidateErrorEventArgs(ValidateErrorType.InvalidValue, CommonUtility.WinForm.MessageBoxEx.GetMessage(MessageCode_Arg1.M017を確認して下さい, DisplayName)))

        End Try


    End Sub

    Protected Overrides Sub OnKeyPress(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        MyBase.OnKeyPress(e)

        If e.Handled = False Then
            If Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Or e.KeyChar = "+"c Or e.KeyChar = "-"c Or e.KeyChar = "."c Then
            Else
                e.Handled = True
            End If

        End If

    End Sub

    <DefaultValue("0")> _
    Public Overrides Property Text() As String
        Get
            Return MyBase.Text
        End Get
        Set(ByVal value As String)
            MyBase.Text = value
        End Set
    End Property

    Public Overrides Function ShouldSerializeText() As Boolean
        If Text <> "0" Then
            Return True
        End If
        Return False
    End Function

    <DefaultValue(False)> _
    <Browsable(False)> _
    Public Overrides Property DigitOnly() As Boolean
        Get
            Return False
        End Get
        Set(ByVal value As Boolean)
            MyBase.DigitOnly = False
        End Set
    End Property

    <DefaultValue(False)> _
    <Browsable(False)> _
    Public Overrides Property UseProhibitValidator() As Boolean
        Get
            Return False
        End Get
        Set(ByVal value As Boolean)
            MyBase.UseProhibitValidator = False
        End Set
    End Property

    <DefaultValue(False)> _
    <Browsable(False)> _
    Public Overrides Property UseMasterCheckValidator() As Boolean
        Get
            Return False
        End Get
        Set(ByVal value As Boolean)
            MyBase.UseMasterCheckValidator = False
        End Set
    End Property


    <DefaultValue(False)> _
    <Browsable(False)> _
    Public Overrides Property UseZeroPadding() As Boolean
        Get
            Return False
        End Get
        Set(ByVal value As Boolean)
            MyBase.UseZeroPadding = False
        End Set
    End Property


    <DefaultValue(False)> _
    <Browsable(False)> _
    Public Overrides Property UseUpdateLinkedTextByCodeChange() As Boolean
        Get
            Return False
        End Get
        Set(ByVal value As Boolean)
            MyBase.UseUpdateLinkedTextByCodeChange = False
        End Set
    End Property

    <DefaultValue("0"c)> _
    <Browsable(False)> _
    Public Overrides Property ZeroPaddingChar() As Char
        Get
            Return "0"c
        End Get
        Set(ByVal value As Char)
            MyBase.ZeroPaddingChar = "0"c
        End Set
    End Property

    <DefaultValue(0)> _
    <Browsable(False)> _
    Public Overrides Property ZeroPaddingLength() As Integer
        Get
            Return 0
        End Get
        Set(ByVal value As Integer)
            MyBase.ZeroPaddingLength = 0
        End Set
    End Property

    <Browsable(False)> _
    Public Overrides Property LinkedTextBox() As TextBox
        Get
            Return Nothing
        End Get
        Set(ByVal value As TextBox)
            MyBase.LinkedTextBox = value
        End Set
    End Property

    <Browsable(False)> _
    Public Shadows Property ImeMode() As ImeMode
        Get
            Return Windows.Forms.ImeMode.Disable
        End Get
        Set(ByVal value As ImeMode)
            MyBase.ImeMode = Windows.Forms.ImeMode.Disable
        End Set
    End Property


    Public Sub New()
        _MinValue = 0
        _MaxValue = 0
        NumberFormat = "#,##0"
        Text = "0"
        UseProhibitValidator = False
        UseMasterCheckValidator = False
        UseZeroPadding = False
        UseUpdateLinkedTextByCodeChange = False
        ImeMode = Windows.Forms.ImeMode.Disable

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。

    End Sub

End Class
