Imports GrapeCity.ActiveReports.SectionReportModel
Imports BLL.Common
Imports GrapeCity.ActiveReports.Document.Section

Public Class rptHAT0001

    Private _DataSetHeader As dsHAT0001_Report.鏡_注文書DataTable
    Private _DataSetDetail As dsHAT0001_Report.明細DataTable
    Private _HattyuDate As Boolean
    Private _HattyuNo As String

    Private natsuin1 As String
    Private natsuin2 As String
    Private natsuin3 As String


    Public Sub New(
              ByVal ReportDataSets As dsHAT0001_Report _
            , ByVal OutputFormat As String _
            , ByVal blnHatyuDate As Boolean _
            , ByVal hattyuNo As String _
            , ByVal utiwakePrintFlg As Boolean)

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。

        Init(Me)

        _DataSetHeader = ReportDataSets.鏡_注文書
        _DataSetDetail = ReportDataSets.明細

        Dim strIndex As String = ""
        For i As Integer = 1 To 11
            strIndex = CommonUtility.Utility.ZeroFormat(i.ToString, 2)
            CType(Detail.Controls("txtSURYO" + strIndex), TextBox).OutputFormat = OutputFormat
        Next

        _HattyuDate = blnHatyuDate
        _HattyuNo = hattyuNo

        '捺印欄の取得
        natsuin1 = ""
        natsuin2 = ""
        natsuin3 = ""

        Dim S_SCB = New S_SCBRead("捺印欄", "1")
        Dim dsS_SCB = S_SCB.GetS_SCB
        If dsS_SCB.Tables(0).Rows.Count <> 0 Then
            natsuin1 = DirectCast(dsS_SCB.Tables(0).Rows(0), dsS_SCB.S_SCBRow).DATA
        End If

        S_SCB = New S_SCBRead("捺印欄", "2")
        dsS_SCB = S_SCB.GetS_SCB
        If dsS_SCB.Tables(0).Rows.Count <> 0 Then
            natsuin2 = DirectCast(dsS_SCB.Tables(0).Rows(0), dsS_SCB.S_SCBRow).DATA
        End If

        S_SCB = New S_SCBRead("捺印欄", "3")
        dsS_SCB = S_SCB.GetS_SCB
        If dsS_SCB.Tables(0).Rows.Count <> 0 Then
            natsuin3 = DirectCast(dsS_SCB.Tables(0).Rows(0), dsS_SCB.S_SCBRow).DATA
        End If

        '内訳書が印字される場合、名称を中央寄せにする
        If utiwakePrintFlg Then
            txtNAME01.Alignment = TextAlignment.Center
            txtNAME02.Alignment = TextAlignment.Center
        End If
    End Sub

    Private Sub Detail_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail.Format

        ClearControl()

        txtHattyuNo.Text = _HattyuNo

        'ヘッダー
        With _DataSetHeader.Item(0)

            lblTitle.Text = .TITLE
            txtLABEL_01.Text = .LABEL_01
            If _HattyuDate Then
                txtHATYUDATE.Text = GetCnvSW.SfncYearSW(.HATYUDATE.ToString("yyyy/MM/dd"), True)
            Else
                txtHATYUDATE.Text = GetCnvSW.GetGengo(.HATYUDATE.ToString("yyyy/MM/dd")) + "    年    月    日"
            End If
            txtKEIYAKUNO.Text = .KEIYAKUNO
            txtSIIRENAME.Text = .SIIRENAME

            txtJISYANAME.Text = .JISYANAME
            txtADDRESS1.Text = .ADDRESS1 + .ADDRESS2
            txtTELNO.Text = .TELNO
            txtFAXNO.Text = .FAXNO

            txtLABEL_02.Text = .LABEL_02
            txtKOUJINAME.Text = .KOUJINAME
            txtKOUJIBASYO.Text = .KOUJIBASYO

            txtNOUKI_START.Text = ""
            txtNOUKI_END.Text = ""
            If Not CommonUtility.Utility.NUCheck(.NOUKI_START) Then txtNOUKI_START.Text = GetCnvSW.SfncYearSW(CType(.NOUKI_START, DateTime).ToString("yyyy/MM/dd"), True)
            If Not CommonUtility.Utility.NUCheck(.NOUKI_END) Then txtNOUKI_END.Text = GetCnvSW.SfncYearSW(CType(.NOUKI_END, DateTime).ToString("yyyy/MM/dd"), True)

            txtGKGENKAGAKU.Value = .GKGENKAGAKU

            txtSIHARAI_COMMENT_01.Text = .SIHARAI_COMMENT_01
            txtSIHARAI_COMMENT_02.Text = .SIHARAI_COMMENT_02
            txtSIHARAI_COMMENT_03.Text = .SIHARAI_COMMENT_03
            txtSIHARAI_COMMENT_04.Text = .SIHARAI_COMMENT_04
            txtSIHARAI_COMMENT_05.Text = .SIHARAI_COMMENT_05
            txtSIHARAI_COMMENT_06.Text = .SIHARAI_COMMENT_06

            txtCOMMENT_01.Text = .COMMENT_01
            txtCOMMENT_02.Text = .COMMENT_02
            txtCOMMENT_03.Text = .COMMENT_03
            txtCOMMENT_04.Text = .COMMENT_04
            txtCOMMENT_05.Text = .COMMENT_05
            txtCOMMENT_06.Text = .COMMENT_06
            txtCOMMENT_07.Text = .COMMENT_07
            txtCOMMENT_08.Text = .COMMENT_08
            txtCOMMENT_09.Text = .COMMENT_09

        End With

        For Each Row As dsHAT0001_Report.明細Row In _DataSetDetail.Rows
            Dim strIndex As String = CommonUtility.Utility.ZeroFormat(Row.GYONO.ToString, 2)
            CType(Detail.Controls("txtNAME" + strIndex), TextBox).Value = Row.NAME
            CType(Detail.Controls("txtSURYO" + strIndex), TextBox).Value = Row.SURYO
            CType(Detail.Controls("txtTANI" + strIndex), TextBox).Value = Row.TANI
            CType(Detail.Controls("txtTANKA" + strIndex), TextBox).Value = Row.TANKA
            CType(Detail.Controls("txtKINGAKU" + strIndex), TextBox).Value = Row.KINGAKU
        Next

        lblNatsuin1.Text = natsuin1
        lblNatsuin2.Text = natsuin2
        lblNatsuin3.Text = natsuin3

    End Sub

    Private Sub ClearControl()

        Dim strIndex As String = ""
        For i As Integer = 1 To 12
            strIndex = CommonUtility.Utility.ZeroFormat(i.ToString, 2)
            CType(Detail.Controls("txtNAME" + strIndex), TextBox).Text = ""
            CType(Detail.Controls("txtSURYO" + strIndex), TextBox).Text = ""
            CType(Detail.Controls("txtTANI" + strIndex), TextBox).Text = ""
            CType(Detail.Controls("txtTANKA" + strIndex), TextBox).Text = ""
            CType(Detail.Controls("txtKINGAKU" + strIndex), TextBox).Text = ""
        Next

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

    Private Sub rptHAT0001_ReportStart(sender As Object, e As EventArgs) Handles MyBase.ReportStart

    End Sub
End Class
