Public Class rptHAT0001Uchiwake

    Private _DataSetHeader As dsHAT0001_Report.鏡_注文書DataTable
    Private _DataSetDetail As dsHAT0001_Report.内訳明細DataTable
    Private _HattyuDate As Boolean
    Private _HattyuNo As String

    Public Sub New(
              ByVal ReportDataSets As dsHAT0001_Report _
            , ByVal OutputFormat As String _
            , ByVal blnHatyuDate As Boolean _
            , ByVal hattyuNo As String)

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。

        Init(Me)

        _DataSetHeader = ReportDataSets.鏡_注文書
        _DataSetDetail = ReportDataSets.内訳明細

        Me.DataSource = _DataSetDetail

        txtSURYO.OutputFormat = OutputFormat

        _HattyuDate = blnHatyuDate
        _HattyuNo = hattyuNo

    End Sub

    Private Sub rptHAT0001UniUke_FetchData(ByVal sender As Object, ByVal eArgs As GrapeCity.ActiveReports.SectionReport.FetchEventArgs) Handles Me.FetchData

        Fields.Add("NAME")
        Fields.Add("SURYO")
        Fields.Add("TANI")
        Fields.Add("TANKA")
        Fields.Add("KINGAKU")

        txtNAME.DataField = "NAME"
        txtSURYO.DataField = "SURYO"
        txtTANI.DataField = "TANI"
        txtTANKA.DataField = "TANKA"
        txtKINGAKU.DataField = "KINGAKU"

        txtTANKA.OutputFormat = "#,###"
        txtKINGAKU.OutputFormat = "#,##0"

    End Sub

    Private Sub PageHeader_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageHeader.Format

        txtHattyuNo.Text = _HattyuNo

        With _DataSetHeader.Item(0)
            If _HattyuDate Then
                txtHATYUDATE.Text = BLL.Common.GetCnvSW.SfncYearSW(.HATYUDATE.ToString("yyyy/MM/dd"), True)
            Else
                txtHATYUDATE.Text = BLL.Common.GetCnvSW.GetGengo(.HATYUDATE.ToString("yyyy/MM/dd")) + "    年    月    日"
            End If
            txtKEIYAKUNO.Text = .KEIYAKUNO
        End With

    End Sub

    Public Shared Sub Init(ByRef rpt As GrapeCity.ActiveReports.SectionReport)
        With rpt
            With .PageSettings
                .PaperKind = Drawing.Printing.PaperKind.A4
                .Orientation = GrapeCity.ActiveReports.Document.Section.PageOrientation.Portrait

                With .Margins
                    .Top = GrapeCity.ActiveReports.SectionReport.CmToInch(2)
                    .Bottom = GrapeCity.ActiveReports.SectionReport.CmToInch(0.0)
                    .Left = GrapeCity.ActiveReports.SectionReport.CmToInch(1.5)
                    .Right = GrapeCity.ActiveReports.SectionReport.CmToInch(0.0)
                End With
            End With
        End With
    End Sub

End Class
