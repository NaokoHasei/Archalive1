Imports GrapeCity.ActiveReports.Document
Imports GrapeCity.ActiveReports.Document.Section
Imports GrapeCity.ActiveReports.SectionReportModel
Imports GrapeCity.ActiveReports.Controls
Imports GrapeCity.ActiveReports


Imports CommonUtility

Public Class rptSEI0001_DekidakaTyousho

    Private syosu As Integer
    Private dtHead As DataTable
    Private dtGoukei As DataTable
    Private strS_SCB_ROUND_ZEIKBN As String

    Public Sub New()

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。

    End Sub

    Public Sub New(
              ByVal dt As dsSEI0001.T_SEIKYU_MEISAIDataTable _
            , ByVal syosuValue As Integer _
            , ByVal dtHead As DataTable _
            , ByVal dtGoukei As dsSEI0001.T_SEIKYU_MEISAIDataTable _
            , ByVal strS_SCB_ROUND_ZEIKBN As String)

        ' この呼び出しは、Windows フォーム デザイナで必要です。

        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。

        With Me
            '.Document.Printer.PrinterName = ""
            With .PageSettings
                .PaperKind = Drawing.Printing.PaperKind.A4
                .Orientation = GrapeCity.ActiveReports.Document.Section.PageOrientation.Landscape

            End With
        End With

        syosu = syosuValue

        Me.DataSource = dt
        Me.dtHead = dtHead
        Me.dtGoukei = dtGoukei
        Me.strS_SCB_ROUND_ZEIKBN = strS_SCB_ROUND_ZEIKBN
    End Sub

    Private Sub ActiveReport_Initialize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DataInitialize

        'ヘッダ
        lblHeadMonth.Text = CDate(dtHead.Rows(0).Item("SeikyuDate")).ToString("M月分")
        lblHeadTokuiName.Text = dtHead.Rows(0).Item("TokuiName")
        lblHeadKoujiName.Text = dtHead.Rows(0).Item("KoujiName")
        lblHeadDekidaka.Text = CDate(dtHead.Rows(0).Item("SeikyuDate")).ToString("M月分出来高")

        'グループヘッダ
        GroupHeader1.DataField = "GROUP_HEADER"

        txtKAMOKU_HINMOKU_DAIKAMOKU.DataField = "KAMOKU_HINMOKU_DAIKAMOKU"

        '明細
        txtKAISOCODE.DataField = "KAISOCODE"
        txtKAMOKU_HINMOKU.DataField = "KAMOKU_HINMOKU"
        txtHINSITU_KIKAKU_SIYO.DataField = "HINSITU_KIKAKU_SIYO"
        txtTANI.DataField = "TANI"
        txtJYUTYUSUU.DataField = "JYUTYUSUU"
        txtJYUTYUTANKA.DataField = "JYUTYUTANKA"
        txtJYUTYUGAKU.DataField = "JYUTYUGAKU"
        txtJYUTYUSUU_HENKO.DataField = "JYUTYUSUU_HENKO"
        txtJYUTYUGAKU_HENKO.DataField = "JYUTYUGAKU_HENKO"
        txtSEIKYUSUU_ZENKAI.DataField = "SEIKYUSUU_ZENKAI"
        txtSEIKYUGAKU_ZENKAI.DataField = "SEIKYUGAKU_ZENKAI"
        txtSEIKYUSUU_KONKAI.DataField = "SEIKYUSUU_KONKAI"
        txtSEIKYUGAKU_KONKAI.DataField = "SEIKYUGAKU_KONKAI"
        txtSEIKYUSUU_RUIKEI.DataField = "SEIKYUSUU_RUIKEI"
        txtSEIKYUGAKU_RUIKEI.DataField = "SEIKYUGAKU_RUIKEI"

        Dim syosuFormat As String
        Select Case CInt(syosu)
            Case 0 : syosuFormat = "#,##0"
            Case Else : syosuFormat = "#,##0." & StrDup(CInt(syosu), "0")
        End Select

        txtJYUTYUTANKA.OutputFormat = "#,###"
        txtJYUTYUGAKU.OutputFormat = "#,##0"
        txtJYUTYUGAKU_HENKO.OutputFormat = "#,###"
        txtSEIKYUGAKU_ZENKAI.OutputFormat = "#,##0"
        txtSEIKYUGAKU_KONKAI.OutputFormat = "#,##0"
        txtSEIKYUGAKU_RUIKEI.OutputFormat = "#,##0"
        txtJYUTYUSUU.OutputFormat = syosuFormat
        txtJYUTYUSUU_HENKO.OutputFormat = syosuFormat
        txtSEIKYUSUU_ZENKAI.OutputFormat = syosuFormat
        txtSEIKYUSUU_KONKAI.OutputFormat = syosuFormat
        txtSEIKYUSUU_RUIKEI.OutputFormat = syosuFormat

        '小計
        txtJYUTYUGAKU_SYOKEI.DataField = "JYUTYUGAKU"
        txtSEIKYUGAKU_ZENKAI_SYOKEI.DataField = "SEIKYUGAKU_ZENKAI"
        txtSEIKYUGAKU_KONKAI_SYOKEI.DataField = "SEIKYUGAKU_KONKAI"
        txtSEIKYUGAKU_RUIKEI_SYOKEI.DataField = "SEIKYUGAKU_RUIKEI"

        txtJYUTYUGAKU_SYOKEI.OutputFormat = "#,##0"
        txtSEIKYUGAKU_ZENKAI_SYOKEI.OutputFormat = "#,##0"
        txtSEIKYUGAKU_KONKAI_SYOKEI.OutputFormat = "#,##0"
        txtSEIKYUGAKU_RUIKEI_SYOKEI.OutputFormat = "#,##0"

        txtJYUTYUGAKU_SYOKEI.SummaryFunc = SummaryFunc.Sum
        txtSEIKYUGAKU_ZENKAI_SYOKEI.SummaryFunc = SummaryFunc.Sum
        txtSEIKYUGAKU_KONKAI_SYOKEI.SummaryFunc = SummaryFunc.Sum
        txtSEIKYUGAKU_RUIKEI_SYOKEI.SummaryFunc = SummaryFunc.Sum

        txtJYUTYUGAKU_SYOKEI.SummaryGroup = "GroupHeader1"
        txtSEIKYUGAKU_ZENKAI_SYOKEI.SummaryGroup = "GroupHeader1"
        txtSEIKYUGAKU_KONKAI_SYOKEI.SummaryGroup = "GroupHeader1"
        txtSEIKYUGAKU_RUIKEI_SYOKEI.SummaryGroup = "GroupHeader1"

        txtJYUTYUGAKU_SYOKEI.SummaryRunning = SummaryRunning.None
        txtSEIKYUGAKU_ZENKAI_SYOKEI.SummaryRunning = SummaryRunning.None
        txtSEIKYUGAKU_KONKAI_SYOKEI.SummaryRunning = SummaryRunning.None
        txtSEIKYUGAKU_RUIKEI_SYOKEI.SummaryRunning = SummaryRunning.None

        txtJYUTYUGAKU_SYOKEI.SummaryType = SummaryType.SubTotal
        txtSEIKYUGAKU_ZENKAI_SYOKEI.SummaryType = SummaryType.SubTotal
        txtSEIKYUGAKU_KONKAI_SYOKEI.SummaryType = SummaryType.SubTotal
        txtSEIKYUGAKU_RUIKEI_SYOKEI.SummaryType = SummaryType.SubTotal

        '合計
        Dim dr As dsSEI0001.T_SEIKYU_MEISAIRow = dtGoukei.Rows(0)
        txtJYUTYUGAKU_GOUKEI.Text = Format(CDec(dr.JYUTYUGAKU), "#,##0")
        txtSEIKYUGAKU_ZENKAI_GOUKEI.Text = Format(CDec(dr.SEIKYUGAKU_ZENKAI), "#,##0")
        txtSEIKYUGAKU_KONKAI_GOUKEI.Text = Format(CDec(dr.SEIKYUGAKU_KONKAI), "#,##0")
        txtSEIKYUGAKU_RUIKEI_GOUKEI.Text = Format(CDec(dr.SEIKYUGAKU_RUIKEI), "#,##0")

        '消費税、総合計
        If strS_SCB_ROUND_ZEIKBN <> "0" Then
            GroupFooter3.Visible = False

        Else
            dr = dtGoukei.Rows(1)
            txtJYUTYUGAKU_SYOHIZEI.Text = Format(CDec(dr.JYUTYUGAKU), "#,##0")
            txtSEIKYUGAKU_ZENKAI_SYOHIZEI.Text = Format(CDec(dr.SEIKYUGAKU_ZENKAI), "#,##0")
            txtSEIKYUGAKU_KONKAI_SYOHIZEI.Text = Format(CDec(dr.SEIKYUGAKU_KONKAI), "#,##0")
            txtSEIKYUGAKU_RUIKEI_SYOHIZEI.Text = Format(CDec(dr.SEIKYUGAKU_RUIKEI), "#,##0")

            dr = dtGoukei.Rows(2)
            txtJYUTYUGAKU_SOUGOUKEI.Text = Format(CDec(dr.JYUTYUGAKU), "#,##0")
            txtSEIKYUGAKU_ZENKAI_SOUGOUKEI.Text = Format(CDec(dr.SEIKYUGAKU_ZENKAI), "#,##0")
            txtSEIKYUGAKU_KONKAI_SOUGOUKEI.Text = Format(CDec(dr.SEIKYUGAKU_KONKAI), "#,##0")
            txtSEIKYUGAKU_RUIKEI_SOUGOUKEI.Text = Format(CDec(dr.SEIKYUGAKU_RUIKEI), "#,##0")
        End If

        '調整額のグループヘッダを非表示
        GroupHeader1.Visible = False
    End Sub

    '￣￣￣￣￣￣￣￣￣￣￣
    '　レポートスタート時
    '＿＿＿＿＿＿＿＿＿＿＿

    Private Sub ActiveReport_ReportStart(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.ReportStart

    End Sub

    '￣￣￣￣￣￣￣￣￣￣￣￣
    '　 ページヘッダー
    '＿＿＿＿＿＿＿＿＿＿＿＿

    Private Sub PageHeader_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageHeader.Format
        lblPage.Text = "P．" + PageNumber.ToString
    End Sub

    '￣￣￣￣￣￣￣￣￣￣￣￣
    '　 グループヘッダー
    '＿＿＿＿＿＿＿＿＿＿＿＿

    Private Sub GroupHeader2_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupHeader1.Format
    End Sub

    '￣￣￣￣￣￣￣
    '　 明  細
    '＿＿＿＿＿＿＿

    Private Sub Detail_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail.Format
        'グループヘッダを表示
        GroupHeader1.Visible = True

        '調整額のグループフッタを非表示
        If txtKAISOCODE.Text = "0" Then
            GroupFooter1.Visible = False
        Else
            GroupFooter1.Visible = True
        End If

        '調整額が0の場合、明細を非表示
        If txtKAISOCODE.Text = "0" AndAlso txtSEIKYUGAKU_KONKAI.Text = "0" Then
            Detail.Visible = False
        Else
            Detail.Visible = True
        End If

        '数量が0の場合、空白に変更
        If Not txtJYUTYUSUU_HENKO.Text = "" AndAlso CDec(txtJYUTYUSUU_HENKO.Text) = 0 Then
            txtJYUTYUSUU_HENKO.Text = ""
        End If
    End Sub

    '￣￣￣￣￣￣￣￣￣￣￣￣
    '　 グループフッター
    '＿＿＿＿＿＿＿＿＿＿＿＿

    Private Sub GroupFooter2_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupFooter1.Format
    End Sub

    '￣￣￣￣￣￣￣￣￣￣￣￣
    '　 ページフッター
    '＿＿＿＿＿＿＿＿＿＿＿＿

    Private Sub PageFooter_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles PageFooter.Format

    End Sub

End Class
