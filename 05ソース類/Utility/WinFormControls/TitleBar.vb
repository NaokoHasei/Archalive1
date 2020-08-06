Imports BLL.Common

Public Class TitleBar

    Private Const GUIDE_NEW As String = "新規"
    Private Const GUIDE_EDIT As String = "修正/削除"
    Private Const GUIDE_DELETE_RESERVE As String = "削除予約"
    Private Const GUIDE_EDIT_NON As String = "変更不可（承認済）"
    Private Const GUIDE_EDIT_NON_SEIKYU As String = "変更不可（次請求あり）"
    Private Const GUIDE_EDIT_NON_JYUTYU_MISYONIN As String = "変更不可（受注未承認）"
    Private Const GUIDE_EDIT_NON_JYUTYU_ZENKAI As String = "変更不可（前回受注）"
    Private Const GUIDE_EDIT_NON_HATYU_ZENKAI As String = "変更不可（前回発注）"
    Private Const GUIDE_NEW_COLOR As Integer = &HFFFFC0C0
    Private Const GUIDE_EDIT_COLOR As Integer = &HFFC0C0FF
    Private Const GUIDE_DELETE_RESERVE_COLOR As Integer = &HFFFF8080

    Private Const GUIDE_NEW_FRCOLOR As Integer = &HFFC00000
    Private Const GUIDE_EDIT_FRCOLOR As Integer = &HFF000080
    Private Const GUIDE_DELETE_RESERVE_FRCOLOR As Integer = &HFF000000

    Private editModeValue As EditMode
    Private appearanceTypeValue As AppearanceType
    Private strS_SCB_KURIKOSHIZAN As String
    Private GUIDE_SEIKYU_KURIKOSHIZAN_SAISEIKYU As String

    Private Sub ChangeEditMode()
        If AppearanceType = WinFormControls.AppearanceType.Normal Or AppearanceType = WinFormControls.AppearanceType.MainMenu Then

            If editModeValue = WinFormControls.EditMode.None Then
                lblMODE.Visible = False
            Else
                lblMODE.Visible = True
            End If

            Select Case editModeValue
                Case WinFormControls.EditMode.Edit
                    lblMODE.Text = GUIDE_EDIT

                Case WinFormControls.EditMode.Create
                    lblMODE.Text = GUIDE_NEW

                Case WinFormControls.EditMode.DeleteReserve
                    lblMODE.Text = GUIDE_DELETE_RESERVE

                Case WinFormControls.EditMode.EditNone
                    lblMODE.Text = GUIDE_EDIT_NON

                Case WinFormControls.EditMode.EditNoneSeikyu
                    lblMODE.Text = GUIDE_EDIT_NON_SEIKYU

                Case WinFormControls.EditMode.EditNoneJyutyuMisyonin
                    lblMODE.Text = GUIDE_EDIT_NON_JYUTYU_MISYONIN

                Case WinFormControls.EditMode.EditNoneJyutyuZenaki
                    lblMODE.Text = GUIDE_EDIT_NON_JYUTYU_ZENKAI

                Case WinFormControls.EditMode.EditNoneHatyuZenaki
                    lblMODE.Text = GUIDE_EDIT_NON_HATYU_ZENKAI

                Case WinFormControls.EditMode.SeikyuKurikoshizanSaiseikyu
                    lblMODE.Text = GUIDE_SEIKYU_KURIKOSHIZAN_SAISEIKYU
            End Select
        Else
            lblMODE.Visible = False
        End If
    End Sub

    Private Sub ChangeAppearance()
        If AppearanceType = WinFormControls.AppearanceType.Normal Or AppearanceType = WinFormControls.AppearanceType.MainMenu Then
            Me.MaximumSize = New Size(2000, 40)
            Me.MinimumSize = New Size(100, 40)
            Me.Size = New Size(Me.Size.Width, 40)
            lblTitle.Font = New Font("メイリオ", 22)
        Else
            Me.MaximumSize = New Size(2000, 50)
            Me.MinimumSize = New Size(100, 50)
            Me.Size = New Size(Me.Size.Width, 50)
            lblTitle.Font = New Font("メイリオ", 21.75)

        End If

        ChangeEditMode()
    End Sub

    <Category("Appearance")>
    <DefaultValue("タイトル")>
    <Description("タイトルを指定します。")>
    Public Property Title() As String
        Get
            Return lblTitle.Text
        End Get
        Set(ByVal value As String)
            lblTitle.Text = value
        End Set
    End Property

    <DefaultValue(WinFormControls.EditMode.None)>
    <Category("Appearance")>
    <Description("編集モードラベルを指定します。")>
    Public Property EditMode() As EditMode
        Get
            Return editModeValue
        End Get
        Set(ByVal value As EditMode)
            editModeValue = value

            ChangeEditMode()
        End Set
    End Property

    <DefaultValue(AppearanceType.Normal)>
    <Category("Appearance")>
    <Description("タイトルバーの種類を指定します。")>
    Public Property AppearanceType() As AppearanceType
        Get
            Return appearanceTypeValue
        End Get
        Set(ByVal value As AppearanceType)
            appearanceTypeValue = value

            ChangeAppearance()

        End Set
    End Property

    Public Sub New()

        editModeValue = WinFormControls.EditMode.None
        appearanceTypeValue = WinFormControls.AppearanceType.Normal

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。

        '繰越残の初期値
        Dim S_SCB = New S_SCBRead("請求登録画面", "繰越残の初期値")
        Dim dsS_SCB = S_SCB.GetS_SCB
        strS_SCB_KURIKOSHIZAN = dsS_SCB.S_SCB(0).DATA

        GUIDE_SEIKYU_KURIKOSHIZAN_SAISEIKYU = strS_SCB_KURIKOSHIZAN & "再請求"
    End Sub

    Private Manual As Manual

    Public Sub ReadManualData(ByVal programId As String)
        Manual = New Manual(btnManual, programId)

        Select Case programId
            Case "USERPASS"
                btnManual.Left = 276

            Case "SENTAKU_TANTO", "SENTAKU_TOKUI"
                btnManual.Left = 509

            Case "SEN0040"
                btnManual.Left = 541
        End Select
    End Sub

    Private Sub btnManual_Click(sender As Object, e As EventArgs) Handles btnManual.Click
        Manual.OpenManual()
    End Sub
End Class

Public Enum EditMode
    None
    Create
    Edit
    DeleteReserve
    EditNone
    EditNoneSeikyu
    EditNoneJyutyuMisyonin
    EditNoneJyutyuZenaki
    EditNoneHatyuZenaki
    SeikyuKurikoshizanSaiseikyu
End Enum

Public Enum AppearanceType
    Normal
    Small
    MainMenu
End Enum
