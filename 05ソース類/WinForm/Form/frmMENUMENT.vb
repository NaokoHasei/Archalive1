Imports BLL.Common
Imports CommonUtility.WinFormControls

Public Class frmMENUMENT

    Private showSingleFormLogic As New ShowSingleFormLogic

    Public Overrides Function PROGRAM_ID() As String
        Return "MENTMENU"
    End Function

    Public Overrides Function PROGRAM_NAME() As String
        Return "メンテメニュー"
    End Function

    Protected Overrides Sub Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MyBase.Form_Load(sender, e)

        Me.TitleBar.Text = ""
        Me.Text = "Archalive1"

        'ボタンの表示設定
        VisibleButton()

        InitializeFunctionKeys()

        AddHandler btnMENT0001.Click, AddressOf btnMENT_Click
        AddHandler btnMENT0002.Click, AddressOf btnMENT_Click
        AddHandler btnMENT0004.Click, AddressOf btnMENT_Click
        AddHandler btnMENT0005.Click, AddressOf btnMENT_Click
        AddHandler btnMENT0006.Click, AddressOf btnMENT_Click
        AddHandler btnMSE0020.Click, AddressOf btnMENT_Click
        AddHandler btnMSE0040.Click, AddressOf btnMENT_Click
        AddHandler btnMSE0090.Click, AddressOf btnMENT_Click

    End Sub

    Private Sub VisibleButton()
        '使用機能権限クラスの定義
        Dim siyoKinouAuthority = New SiyoKinouAuthority(TANTO_CODE)

        btnMENT0001.Visible = siyoKinouAuthority.CheckUseKinou(SiyoKinouAuthority.CONST_部課マスタ登録)
        btnMENT0004.Visible = siyoKinouAuthority.CheckUseKinou(SiyoKinouAuthority.CONST_担当者マスタ登録)
        btnMENT0005.Visible = siyoKinouAuthority.CheckUseKinou(SiyoKinouAuthority.CONST_顧客マスタ登録)
        btnMENT0006.Visible = siyoKinouAuthority.CheckUseKinou(SiyoKinouAuthority.CONST_業者マスタ登録)
        btnMENT0002.Visible = siyoKinouAuthority.CheckUseKinou(SiyoKinouAuthority.CONST_科目マスタ登録)
        btnMSE0020.Visible = siyoKinouAuthority.CheckUseKinou(SiyoKinouAuthority.CONST_基本設定マスタ登録)
        btnMSE0040.Visible = siyoKinouAuthority.CheckUseKinou(SiyoKinouAuthority.CONST_区分マスタ登録)
        btnMSE0090.Visible = siyoKinouAuthority.CheckUseKinou(SiyoKinouAuthority.CONST_郵便番号辞書データ作成)
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

    Private Sub btnMENT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Select Case True

            Case btnMENT0001.Focused
                showSingleFormLogic.ShowDisp(ShowSingleFormLogic.enumShowDispKbn.MENT0001, Me)

            Case btnMENT0002.Focused
                showSingleFormLogic.ShowDisp(ShowSingleFormLogic.enumShowDispKbn.MENT0002, Me)

            Case btnMENT0004.Focused
                showSingleFormLogic.ShowDisp(ShowSingleFormLogic.enumShowDispKbn.MENT0004, Me)

            Case btnMENT0005.Focused
                showSingleFormLogic.ShowDisp(ShowSingleFormLogic.enumShowDispKbn.MENT0005, Me)

            Case btnMENT0006.Focused
                showSingleFormLogic.ShowDisp(ShowSingleFormLogic.enumShowDispKbn.MENT0006, Me)

            Case btnMSE0020.Focused
                showSingleFormLogic.ShowDisp(ShowSingleFormLogic.enumShowDispKbn.MSE0020, Me)

            Case btnMSE0040.Focused
                showSingleFormLogic.ShowDisp(ShowSingleFormLogic.enumShowDispKbn.MSE0040, Me)

            Case btnMSE0090.Focused
                showSingleFormLogic.ShowDisp(ShowSingleFormLogic.enumShowDispKbn.MSE0090, Me)

        End Select
    End Sub
End Class
