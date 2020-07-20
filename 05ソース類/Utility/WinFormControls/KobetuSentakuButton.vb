Public Class KobetuSentakuButton

    Private _Selected As Boolean

    <Browsable(False)> _
    <DefaultValue(False)> _
    <Category("動作")> _
    <Description("値が変更されたときに文字色を変更します")> _
    Public Overridable Property Selected() As Boolean
        Get
            Return _Selected
        End Get
        Set(ByVal value As Boolean)
            _Selected = value
            If Not DesignMode Then
                Me.ForeColor = CommonUtility.Utility.GetSentakuButtonColor(_Selected)
            End If
        End Set
    End Property

    Public Sub New()

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        Text = "個別選択"
    End Sub

    <DefaultValue("個別選択")> _
    Public Overrides Property Text() As String
        Get
            Return MyBase.Text
        End Get
        Set(ByVal value As String)
            MyBase.Text = value
        End Set
    End Property

End Class
