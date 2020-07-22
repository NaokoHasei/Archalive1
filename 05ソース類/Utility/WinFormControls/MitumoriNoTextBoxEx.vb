Imports System.ComponentModel

Public Class MitumoriNoTextBoxEx

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)

        'カスタム描画コードをここに追加します。
    End Sub

    Private LinkedComboBoxValue As MitumoriNoComboBox

    <Description("リンクするコンボボックスを指定します。")>
    Public Property LinkedComboBox() As MitumoriNoComboBox
        Get
            Return LinkedComboBoxValue
        End Get
        Set(ByVal value As MitumoriNoComboBox)
            LinkedComboBoxValue = value
        End Set
    End Property


    Public Sub New()
        MyBase.New

        LinkedComboBoxValue = Nothing

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。

    End Sub

    Private Sub TextBoxControl_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles Me.PreviewKeyDown
        '下キーでコンボボックスを開く
        If e.KeyCode = Keys.Down Then
            If LinkedComboBoxValue Is Nothing Then Return

            'リンクするコンボボックスを選択
            LinkedComboBoxValue.Focus()
            'TypComboBoxのコンボボックスをフォーカスする為に下キーを発生させる
            SendKeys.Send("{DOWN}")
            'Alt＋下キーでコンボボックスを開く
            SendKeys.Send("%{DOWN}")
        End If
    End Sub

End Class
