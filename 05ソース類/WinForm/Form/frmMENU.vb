Imports BLL.Common
Imports CommonUtility.WinFormControls

Public Class frmMENU

    Private showSingleFormLogic As New ShowSingleFormLogic

    Public Overrides Function PROGRAM_ID() As String
        Return "MAINMENU"
    End Function

    Public Overrides Function PROGRAM_NAME() As String
        Return "メインメニュー"
    End Function

    Private Manual1 As Manual
    Private Manual2 As Manual

    Protected Overrides Sub Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MyBase.Form_Load(sender, e)

        Me.TitleBar.Text = ""
        Me.Text = "Archalive1"

        'ボタンの表示設定
        VisibleButton()

        InitializeFunctionKeys()

        AddHandler btnBUK0001.Click, AddressOf btnMENU_Click
        AddHandler btnBUK0002.Click, AddressOf btnMENU_Click
        AddHandler btnBUK0003.Click, AddressOf btnMENU_Click
        AddHandler btnMENTMENU.Click, AddressOf btnMENU_Click

        'マニュアルのボタンの設定
        Manual1 = New Manual(btnManual1, "機能一覧・画面遷移")
        Manual2 = New Manual(btnManual2, "機能共通の設定")
    End Sub

    Private Sub VisibleButton()
        '使用機能権限クラスの定義
        Dim siyoKinouAuthority = New SiyoKinouAuthority(TANTO_CODE)

        btnBUK0001.Visible = siyoKinouAuthority.CheckUseKinou(SiyoKinouAuthority.CONST_物件登録)
        btnBUK0002.Visible = siyoKinouAuthority.CheckUseKinou(SiyoKinouAuthority.CONST_物件検索)
        btnBUK0003.Visible = siyoKinouAuthority.CheckUseKinou(siyoKinouAuthority.CONST_物件一覧)
        btnMENTMENU.Visible = siyoKinouAuthority.CheckUseKinou(SiyoKinouAuthority.CONST_メンテナンス)
    End Sub

    Protected Overrides Sub FunctionKeyAction(ByVal sender As System.Object, ByVal e As CommonUtility.WinFormControls.FunctionKeyEventArgs)
        Select Case e.Name
            Case "終了"
                Me.Close()
        End Select
    End Sub

    Private Sub InitializeFunctionKeys()
        FunctionKey.ClearAll()

        FunctionKey.SetItem(1, "終了", "終了", True)
    End Sub

    Public aa As Form

    Private Sub btnMENU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Select Case True

            Case btnBUK0001.Focused
                '選択ボタン
                Dim f = New frmBUK0001()
                f.ShowDisp(Me)

            Case btnBUK0002.Focused
                showSingleFormLogic.ShowDisp(ShowSingleFormLogic.enumShowDispKbn.BUK0002, Me)

            Case btnBUK0003.Focused
                showSingleFormLogic.ShowDisp(ShowSingleFormLogic.enumShowDispKbn.BUK0003, Me)

            Case btnMENTMENU.Focused
                showSingleFormLogic.ShowDisp(ShowSingleFormLogic.enumShowDispKbn.MENTMENU, Me)

        End Select
    End Sub

    Private Sub btnManual1_Click(sender As Object, e As EventArgs) Handles btnManual1.Click
        Manual1.OpenManual()
    End Sub

    Private Sub btnManual2_Click(sender As Object, e As EventArgs) Handles btnManual2.Click
        Manual2.OpenManual()
    End Sub

    Private Sub frmMENU_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
