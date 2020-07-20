Public Class RangeValidator

    Private Enum ControlTypeEnum
        TextBox
        ComboBox
        MaskedTextBox
        DateTimePicker
    End Enum

    Private controlType As ControlTypeEnum

    Dim leftControl As Control
    Dim rightControl As Control
    Dim displayNameValue As String

    Public Property DisplayName() As String
        Get
            Return displayNameValue
        End Get
        Set(ByVal value As String)
            displayNameValue = value
        End Set
    End Property

    Public Sub New(ByVal name As String, ByVal left As DateTextBoxEx, ByVal right As DateTextBoxEx)
        controlType = ControlTypeEnum.MaskedTextBox

        leftControl = left
        rightControl = right
        DisplayName = name

    End Sub

    Public Sub New(ByVal name As String, ByVal left As TextBoxEx, ByVal right As TextBoxEx)
        controlType = ControlTypeEnum.TextBox

        leftControl = left
        rightControl = right
        DisplayName = name

    End Sub
    Public Sub New(ByVal name As String, ByVal left As TypComboBox, ByVal right As TypComboBox)
        controlType = ControlTypeEnum.ComboBox

        leftControl = left
        rightControl = right
        DisplayName = name

    End Sub

    Public Function ValidateMe() As Boolean
        Dim validateSuccess As Boolean = False

        Select Case controlType
            Case ControlTypeEnum.ComboBox
                If IsNumeric(CType(leftControl, TypComboBox).Text) AndAlso IsNumeric(CType(rightControl, TypComboBox).Text) Then
                    validateSuccess = CDec(CType(leftControl, TypComboBox).Text) <= CDec(CType(rightControl, TypComboBox).Text)
                Else
                    validateSuccess = CType(leftControl, TypComboBox).Text <= CType(rightControl, TypComboBox).Text
                End If
                'validateSuccess = CType(leftControl, TypComboBox).Text <= CType(rightControl, TypComboBox).Text
            Case ControlTypeEnum.MaskedTextBox
                validateSuccess = CType(leftControl, DateTextBoxEx).Text <= CType(rightControl, DateTextBoxEx).Text
            Case ControlTypeEnum.TextBox
                If IsNumeric(CType(leftControl, TextBoxEx).Text) AndAlso IsNumeric(CType(rightControl, TextBoxEx).Text) Then
                    validateSuccess = CDec(CType(leftControl, TextBoxEx).Text) <= CDec(CType(rightControl, TextBoxEx).Text)
                Else
                    validateSuccess = CType(leftControl, TextBoxEx).Text <= CType(rightControl, TextBoxEx).Text
                End If
                'validateSuccess = CType(leftControl, TextBoxEx).Text <= CType(rightControl, TextBoxEx).Text
        End Select

        If validateSuccess = False Then
            CommonUtility.WinForm.MessageBoxEx.Show(CommonUtility.MessageCode_Arg1.M016の入力範囲を確認して下さい, DisplayName, leftControl.FindForm.Text)
            Return False
        End If
        Return True
    End Function

    Public Shared Function ValidateMe(ByVal name As String, ByVal left As DateTextBoxEx, ByVal right As DateTextBoxEx) As Boolean
        Dim validator As New RangeValidator(name, left, right)
        Return validator.ValidateMe()
    End Function
    Public Shared Function ValidateMe(ByVal name As String, ByVal left As TextBoxEx, ByVal right As TextBoxEx) As Boolean
        Dim validator As New RangeValidator(name, left, right)
        Return validator.ValidateMe()
    End Function
    Public Shared Function ValidateMe(ByVal name As String, ByVal left As TypComboBox, ByVal right As TypComboBox) As Boolean
        Dim validator As New RangeValidator(name, left, right)
        Return validator.ValidateMe()
    End Function

End Class
