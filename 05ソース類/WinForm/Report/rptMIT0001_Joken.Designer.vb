<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rptMIT0001_Joken
    Inherits GrapeCity.ActiveReports.SectionReport

    'ActiveReport がコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
        End If
        MyBase.Dispose(disposing)
    End Sub

    'メモ: 以下のプロシージャは ActiveReport デザイナで必要です。
    'ActiveReport デザイナを使用して変更できます。
    'コード エディタを使って変更しないでください。
    Private WithEvents PageHeader As GrapeCity.ActiveReports.SectionReportModel.PageHeader
    Private WithEvents Detail As GrapeCity.ActiveReports.SectionReportModel.Detail
    Private WithEvents PageFooter As GrapeCity.ActiveReports.SectionReportModel.PageFooter
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptMIT0001_Joken))
        Me.PageHeader = New GrapeCity.ActiveReports.SectionReportModel.PageHeader()
        Me.Line31 = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.Detail = New GrapeCity.ActiveReports.SectionReportModel.Detail()
        Me.Shape1 = New GrapeCity.ActiveReports.SectionReportModel.Shape()
        Me.Label1 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.txtMitsumoriJoken = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.PageFooter = New GrapeCity.ActiveReports.SectionReportModel.PageFooter()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMitsumoriJoken, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.Line31})
        Me.PageHeader.Height = 0!
        Me.PageHeader.Name = "PageHeader"
        Me.PageHeader.Visible = False
        '
        'Line31
        '
        Me.Line31.Height = 0!
        Me.Line31.Left = 0!
        Me.Line31.LineWeight = 1.0!
        Me.Line31.Name = "Line31"
        Me.Line31.Top = 0!
        Me.Line31.Width = 9.779137!
        Me.Line31.X1 = 0!
        Me.Line31.X2 = 9.779137!
        Me.Line31.Y1 = 0!
        Me.Line31.Y2 = 0!
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.Shape1, Me.Label1, Me.txtMitsumoriJoken})
        Me.Detail.Height = 7.165847!
        Me.Detail.Name = "Detail"
        '
        'Shape1
        '
        Me.Shape1.Height = 6.822917!
        Me.Shape1.Left = 0.1875!
        Me.Shape1.Name = "Shape1"
        Me.Shape1.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(10.0!, Nothing, Nothing, Nothing, Nothing)
        Me.Shape1.Top = 0.1354167!
        Me.Shape1.Width = 9.3125!
        '
        'Label1
        '
        Me.Label1.Height = 0.1979167!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 3.927559!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "font-family: ＭＳ 明朝; font-size: 9.75pt; text-align: center; ddo-char-set: 0"
        Me.Label1.Text = "御　見　積　条　件"
        Me.Label1.Top = 0.2811024!
        Me.Label1.Width = 1.843701!
        '
        'txtMitsumoriJoken
        '
        Me.txtMitsumoriJoken.Height = 5.770866!
        Me.txtMitsumoriJoken.Left = 0.9480315!
        Me.txtMitsumoriJoken.Name = "txtMitsumoriJoken"
        Me.txtMitsumoriJoken.Style = "font-family: ＭＳ 明朝; font-size: 9.75pt; ddo-char-set: 1"
        Me.txtMitsumoriJoken.Text = resources.GetString("txtMitsumoriJoken.Text")
        Me.txtMitsumoriJoken.Top = 0.7188977!
        Me.txtMitsumoriJoken.Width = 8.020866!
        '
        'PageFooter
        '
        Me.PageFooter.Height = 0!
        Me.PageFooter.Name = "PageFooter"
        '
        'rptMIT0001_Joken
        '
        Me.MasterReport = False
        Me.PageSettings.DefaultPaperSize = False
        Me.PageSettings.Margins.Bottom = 0.6062992!
        Me.PageSettings.Orientation = GrapeCity.ActiveReports.Document.Section.PageOrientation.Landscape
        Me.PageSettings.PaperHeight = 11.69291!
        Me.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4
        Me.PageSettings.PaperWidth = 8.267716!
        Me.PrintWidth = 9.812798!
        Me.Sections.Add(Me.PageHeader)
        Me.Sections.Add(Me.Detail)
        Me.Sections.Add(Me.PageFooter)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-style: normal; text-decoration: none; font-weight: normal; font-size: 10pt; " &
            "color: Black; font-family: MS UI Gothic; ddo-char-set: 128", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ddo-char-set: 128", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 14pt; font-weight: bold; ddo-char-set: 128", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ddo-char-set: 128", "Heading3", "Normal"))
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMitsumoriJoken, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Private WithEvents Line31 As GrapeCity.ActiveReports.SectionReportModel.Line
    Private WithEvents Shape1 As GrapeCity.ActiveReports.SectionReportModel.Shape
    Private WithEvents Label1 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents txtMitsumoriJoken As GrapeCity.ActiveReports.SectionReportModel.TextBox
End Class
