Imports BLL.Common

Public Class rptSEI0001

    Private strKeisyo As String = ""

    Private natsuin1 As String
    Private natsuin2 As String
    Private natsuin3 As String


    Public Sub New(ByVal dt As DataTable, ByVal KEISYO As String)

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。

        Me.DataSource = dt

        strKeisyo = KEISYO

        '余白設定
        Me.PageSettings.Margins.Top = CmToInch(1.5)
        Me.PageSettings.Margins.Bottom = CmToInch(1)
        Me.PageSettings.Margins.Left = CmToInch(3)
        Me.PageSettings.Margins.Right = CmToInch(0.5)

        Me.PageSettings.PaperKind = Drawing.Printing.PaperKind.A4
        Me.PageSettings.Orientation = GrapeCity.ActiveReports.Document.Section.PageOrientation.Landscape

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

    End Sub

    Private Sub rptMain0_DataInitialize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DataInitialize

        '請求Ｎｏ
        txtNo.DataField = "SeikyuNo"

        '請求日付
        txtSyoriDate.DataField = "SeikyuDate"

        '元請名
        txtKyakuName.DataField = "TokuiName"

        '今回請求額
        txtSeikyuGaku.DataField = "SeikyuGaku"
        txtSeikyuGaku.OutputFormat = "#,##0"

        '請負金額
        txtJyutyuGaku.DataField = "UkeoiGaku"
        txtJyutyuGaku.OutputFormat = "#,##0"

        '今回迄受領額
        txtMadeJyuryogaku.DataField = "MadeJyuryoGaku"
        txtMadeJyuryogaku.OutputFormat = "#,##0"

        '今回迄請求額
        txtMadeSeikyuGaku.DataField = "MadeSeikyuGaku"
        txtMadeSeikyuGaku.OutputFormat = "#,##0"

        '今回請求金額
        txtKonSeikyuGaku.DataField = "SeikyuGaku"
        txtKonSeikyuGaku.OutputFormat = "#,##0"

        '自社情報
        'ISO資格
        txtISO.DataField = "Isoqer"

        '自社名称
        txtJisyaName1.DataField = "JisyaName"

        'コメント１
        txtComment.DataField = "Comment1"

        '郵便番号
        txtYubin.DataField = "YubinNo"

        '住所１
        txtAddress.DataField = "Address1"

        '電話番号
        txtTEL.DataField = "TelNo"

        'ＦＡＸ番号
        txtFAX.DataField = "FaxNo"

        'ﾒｰﾙｱﾄﾞﾚｽ
        txtEmail.DataField = "Email"

        'Webサイト
        txtURL.DataField = "Web"

        '銀行口座１
        txtBank1.DataField = "Kouza1"

        '銀行口座２
        txtBank2.DataField = "Kouza2"

        '銀行口座３
        txtBank3.DataField = "Kouza3"

        '口座名義
        txtKouzaMeigi.DataField = "KouzaMeigi"

    End Sub

    Private Sub Detail_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail.BeforePrint

        lblKeisyo.Text = strKeisyo

        txtTEL.Text = frmSEI0001.ReportData.TEL固定値 + txtTEL.Text

        txtFAX.Text = frmSEI0001.ReportData.FAX固定値 + txtFAX.Text

        txtEmail.Text = frmSEI0001.ReportData.EMAIL固定値 + txtEmail.Text

        txtURL.Text = frmSEI0001.ReportData.URL固定値 + txtURL.Text

        '0データは不可視
        txtMadeJyuryogaku.Visible = (Not txtMadeJyuryogaku.Text = "0")

        txtMadeSeikyuGaku.Visible = (Not txtMadeSeikyuGaku.Text = "0")


        'Style
        txtSeikyuGaku.Text = "￥" + txtSeikyuGaku.Text + "－"

        txtJyutyuGaku.Text = "\" + txtJyutyuGaku.Text

        txtMadeJyuryogaku.Text = "\" + txtMadeJyuryogaku.Text

        txtMadeSeikyuGaku.Text = "\" + txtMadeSeikyuGaku.Text

        txtKonSeikyuGaku.Text = "\" + txtKonSeikyuGaku.Text

        lblNatsuin1.Text = natsuin1
        lblNatsuin2.Text = natsuin2
        lblNatsuin3.Text = natsuin3

    End Sub
End Class
