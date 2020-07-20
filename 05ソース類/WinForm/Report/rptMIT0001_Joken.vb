Public Class rptMIT0001_Joken
    Inherits GrapeCity.ActiveReports.SectionReport

    Public Sub New()

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。

    End Sub

    Public Sub New(ByVal dt As DataTable)

        ' この呼び出しは、Windows フォーム デザイナで必要です。

        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。

        '余白設定
        Me.PageSettings.Margins.Top = CmToInch(1)
        Me.PageSettings.Margins.Bottom = CmToInch(1)
        Me.PageSettings.Margins.Left = CmToInch(3)
        Me.PageSettings.Margins.Right = CmToInch(0.5)

        Me.PageSettings.PaperKind = Drawing.Printing.PaperKind.A4
        Me.PageSettings.Orientation = GrapeCity.ActiveReports.Document.Section.PageOrientation.Landscape

        Me.DataSource = dt

    End Sub

    Private Sub ActiveReport_Initialize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DataInitialize
        '見積条件
        txtMitsumoriJoken.DataField = "MITUMORI_JOUKEN"
    End Sub
End Class
