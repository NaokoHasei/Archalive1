Public Class KobetuButton

    Private SentakuModeValue As SentakuMode

    <DefaultValue(WinFormControls.EditMode.None)> _
    <Category("Appearance")> _
    <Description("編集モードラベルを指定します。")> _
    Public Property SentakuMode() As SentakuMode
        Get
            Return SentakuModeValue
        End Get
        Set(ByVal value As SentakuMode)
            SentakuModeValue = value

            ChangeEditMode()
        End Set
    End Property


    Private Sub ChangeEditMode()

        If SentakuModeValue = SentakuMode.ON_ Then
            Me.ForeColor = Color.Red
        End If
        If SentakuModeValue = SentakuMode.OFF Then
            Me.ForeColor = Color.Black
        End If
    End Sub

    Public Sub New()

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。

        SentakuMode = WinFormControls.SentakuMode.OFF
        Text = ""
 

    End Sub
    Public Overrides Sub ResetText()
        MyBase.ResetText()

    End Sub

End Class

Public Enum SentakuMode
    ON_
    OFF
End Enum
