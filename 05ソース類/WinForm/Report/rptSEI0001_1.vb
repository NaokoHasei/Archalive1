Imports GrapeCity.ActiveReports.Document
Imports GrapeCity.ActiveReports.Document.Section
Imports GrapeCity.ActiveReports.SectionReportModel
Imports GrapeCity.ActiveReports.Controls
Imports GrapeCity.ActiveReports



Public Class rptSEI0001_1
    Public Sub New(ByVal dt As DataTable)

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。

        Me.DataSource = dt

        '余白設定
        Me.PageSettings.Margins.Top = CmToInch(1)
        Me.PageSettings.Margins.Bottom = CmToInch(1)
        Me.PageSettings.Margins.Left = CmToInch(3)
        Me.PageSettings.Margins.Right = CmToInch(0.5)

        Me.PageSettings.PaperKind = Drawing.Printing.PaperKind.A4
        Me.PageSettings.Orientation = GrapeCity.ActiveReports.Document.Section.PageOrientation.Landscape

    End Sub

    Private Sub rptMain0_DataInitialize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DataInitialize

        PageBrakeHeader.DataField = "Page"
        PageBrakeHeader.RepeatStyle = RepeatStyle.OnPageIncludeNoDetail
        PageBrakeHeader.NewPage = NewPage.Before

        txtNo.DataField = "Gyo"
        txtKousyu.DataField = "Kousyu"
        txtNaiyo.DataField = "Naiyo"
        txtSuryo.DataField = "Suryo"
        txtTani.DataField = "Tani"
        txtTanka.DataField = "Tanka"
        txtKingaku.DataField = "Kingaku"
        txtTekiyo.DataField = "Tekiyou"
        txtVisible.DataField = "Visible"
        txtLineNumber.DataField = "LineNumber"

        txtSuryo.OutputFormat = "#,##0"
        txtTanka.OutputFormat = "#,###"
        txtKingaku.OutputFormat = "#,##0"

    End Sub

    Private Sub PageHeader_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles PageHeader.Format

        lblNo.Text = String.Format("(No.{0})", PageNumber.ToString)

    End Sub

    Private Sub Detail_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail.Format

        Dim flg As Boolean = txtVisible.Value

        txtNo.Visible = flg
        txtKousyu.Visible = flg
        txtNaiyo.Visible = flg
        txtSuryo.Visible = flg
        txtTani.Visible = flg
        txtTanka.Visible = flg
        txtKingaku.Visible = flg
        txtTekiyo.Visible = flg

        If Not txtKingaku.Text.IndexOf("▲") = -1 Then
            txtKingaku.Text = "▲" + Decimal.Parse(txtKingaku.Text.Replace("▲", "")).ToString("#,0")
        End If

        '内消費税行の場合は金額右にカッコをつける
        If Not txtKousyu.Text.IndexOf("(内消費税") = -1 Then
            txtKingaku.Text = txtKingaku.Text + ")"
        End If

        If txtLineNumber.Text = "20" Then
            DetailBottomLine.LineWeight = 4
        Else
            DetailBottomLine.LineWeight = 2
        End If

    End Sub
End Class
