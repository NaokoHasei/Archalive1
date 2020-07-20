Imports GrapeCity.ActiveReports.Document
Imports GrapeCity.ActiveReports.Document.Section
Imports GrapeCity.ActiveReports.SectionReportModel
Imports GrapeCity.ActiveReports.Controls
Imports GrapeCity.ActiveReports


Imports CommonUtility

Public Class rptMIT0001_Meisai

    Private syosu As Integer

    Public Sub New()

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。

    End Sub

    Public Sub New(ByVal dt As DataTable, ByVal syosuValue As Integer)

        ' この呼び出しは、Windows フォーム デザイナで必要です。

        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。

        With Me
            '.Document.Printer.PrinterName = ""
            With .PageSettings
                .PaperKind = Drawing.Printing.PaperKind.A4
                .Orientation = GrapeCity.ActiveReports.Document.Section.PageOrientation.Landscape

                With .Margins
                    .Top = GrapeCity.ActiveReports.SectionReport.CmToInch(1.5)
                    .Bottom = GrapeCity.ActiveReports.SectionReport.CmToInch(0.0)
                    .Left = GrapeCity.ActiveReports.SectionReport.CmToInch(1.5)
                    .Right = GrapeCity.ActiveReports.SectionReport.CmToInch(0.0)
                End With
            End With
        End With

        syosu = syosuValue

        Me.DataSource = dt

    End Sub

    Private Sub ActiveReport_Initialize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DataInitialize

        'No.
        txtNumber.DataField = "NUMBER"
        '科目・品目
        txtKAMOKU_HINMOKU.DataField = "KAMOKU_HINMOKU"
        '品質・規格・仕様
        txtHINSITU_KIKAKU_SIYO.DataField = "HINSITU_KIKAKU_SIYO"
        '数量
        txtSUU.DataField = "SUU"
        Select Case CInt(syosu)
            Case 0 : txtSUU.OutputFormat = "#,##0"
            Case Else : txtSUU.OutputFormat = "#,##0." & StrDup(CInt(syosu), "0")
        End Select

        '単位
        txtTANI.DataField = "TANI"
        '単価
        txtMITUMORITANKA.DataField = "MITUMORITANKA"
        txtMITUMORITANKA.OutputFormat = "#,###"
        '金額
        txtMITUMORIGAKU.DataField = "MITUMORIGAKU"
        txtMITUMORIGAKU.OutputFormat = "#,##0"
        '備考
        txtG_BIKO.DataField = "G_BIKO"

        '合計見積金額
        txtGKMITUMORIGAKU.DataField = "MITUMORIGAKU"
        txtGKMITUMORIGAKU.OutputFormat = "#,##0"
        txtGKMITUMORIGAKU.SummaryFunc = SummaryFunc.Sum
        txtGKMITUMORIGAKU.SummaryGroup = "GroupHeader1"
        txtGKMITUMORIGAKU.SummaryRunning = SummaryRunning.None
        txtGKMITUMORIGAKU.SummaryType = SummaryType.SubTotal

        GroupHeader1.DataField = "PAGE"    '2015.07.14 Ins yamada

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

    '￣￣￣￣￣￣￣
    '　 明  細
    '＿＿＿＿＿＿＿

    Private Sub Detail_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail.Format
    End Sub

    '￣￣￣￣￣￣￣￣￣￣￣￣
    '　 ページフッター
    '＿＿＿＿＿＿＿＿＿＿＿＿

    Private Sub PageFooter_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles PageFooter.Format

    End Sub

End Class
