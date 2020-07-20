Imports BLL.Common

Public Class rptMIT0001_Kagami0
    Inherits GrapeCity.ActiveReports.SectionReport

    Private natsuin1 As String
    Private natsuin2 As String
    Private natsuin3 As String
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

        '余白設定
        Me.PageSettings.Margins.Top = CmToInch(1)
        Me.PageSettings.Margins.Bottom = CmToInch(1)
        Me.PageSettings.Margins.Left = CmToInch(3)
        Me.PageSettings.Margins.Right = CmToInch(0.5)

        Me.PageSettings.PaperKind = Drawing.Printing.PaperKind.A4
        Me.PageSettings.Orientation = GrapeCity.ActiveReports.Document.Section.PageOrientation.Landscape

        Me.DataSource = dt

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

        syosu = syosuValue

    End Sub

    Private Sub ActiveReport_Initialize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DataInitialize

        '見積Ｎｏ
        txtMITUMORINO.DataField = "MITUMORINO"
        '提出日付
        txtTEISYUTUDATE.DataField = "TEISYUTUDATE"
        '顧客名
        txtKYAKUNAME.DataField = "TOKUINAME"
        '敬称
        txtKEISYOUNAME.DataField = "KEISYOUNAME"
        '見積金額
        txtMITUMORIGAKU.DataField = "GKMITUMORIGAKU_NUKI"
        txtMITUMORIGAKU.OutputFormat = "￥#,##0－"

        'ＩＳＯ資格
        txtISOQAR.DataField = "ISOQAR"
        '自社名称
        txtJISYANAME.DataField = "JISYANAME"
        'コメント１
        txtCOMMENT1.DataField = "COMMENT1"
        '郵便番号
        txtPOSTNO.DataField = "POSTNO"
        '住所
        txtADDRESS1.DataField = "ADDRESS"
        '電話番号
        txtTELNO.DataField = "TELNO"
        'ＦＡＸ番号
        txtFAXNO.DataField = "FAXNO"
        'メールアドレス
        txtEMAIL.DataField = "EMAIL"
        'ウェブサイト
        txtWEB.DataField = "WEB"

        '工事名称
        txtKOUJINAME.DataField = "KOUJINAME"
        '工事番号
        txtKOUJINO.DataField = "KOUJINO"
        '工事場所
        txtKOUJIBASYO.DataField = "KOUJIBASYO"
        '納期
        txtNOUKI.DataField = "NOUKI"
        '有効期限
        txtYUKOKIGEN.DataField = "YUKOKIGEN"
        '支払条件
        txtSIHARAIJYOKEN.DataField = "SIHARAIJYOKEN"

        '件名
        txtKAMOKU_HINMOKU1.DataField = "KAMOKU_HINMOKU1"
        txtKAMOKU_HINMOKU2.DataField = "KAMOKU_HINMOKU2"
        txtKAMOKU_HINMOKU3.DataField = "KAMOKU_HINMOKU3"
        txtKAMOKU_HINMOKU4.DataField = "KAMOKU_HINMOKU4"
        txtKAMOKU_HINMOKU5.DataField = "KAMOKU_HINMOKU5"
        txtKAMOKU_HINMOKU6.DataField = "KAMOKU_HINMOKU6"
        txtKAMOKU_HINMOKU7.DataField = "KAMOKU_HINMOKU7"
        txtKAMOKU_HINMOKU8.DataField = "KAMOKU_HINMOKU8"
        txtKAMOKU_HINMOKU9.DataField = "KAMOKU_HINMOKU9"
        txtKAMOKU_HINMOKU10.DataField = "KAMOKU_HINMOKU10"
        txtKAMOKU_HINMOKU11.DataField = "KAMOKU_HINMOKU11"
        '数量
        txtSUU1.DataField = "SUU1"
        txtSUU2.DataField = "SUU2"
        txtSUU3.DataField = "SUU3"
        txtSUU4.DataField = "SUU4"
        txtSUU5.DataField = "SUU5"
        txtSUU6.DataField = "SUU6"
        txtSUU7.DataField = "SUU7"
        txtSUU8.DataField = "SUU8"
        txtSUU9.DataField = "SUU9"
        txtSUU10.DataField = "SUU10"
        txtSUU11.DataField = "SUU11"
        Select Case CInt(syosu)
            Case 0
                txtSUU1.OutputFormat = "#,##0"
                txtSUU2.OutputFormat = "#,##0"
                txtSUU3.OutputFormat = "#,##0"
                txtSUU4.OutputFormat = "#,##0"
                txtSUU5.OutputFormat = "#,##0"
                txtSUU6.OutputFormat = "#,##0"
                txtSUU7.OutputFormat = "#,##0"
                txtSUU8.OutputFormat = "#,##0"
                txtSUU9.OutputFormat = "#,##0"
                txtSUU10.OutputFormat = "#,##0"
                txtSUU11.OutputFormat = "#,##0"
            Case Else
                txtSUU1.OutputFormat = "#,##0." & StrDup(syosu, "0")
                txtSUU2.OutputFormat = "#,##0." & StrDup(syosu, "0")
                txtSUU3.OutputFormat = "#,##0." & StrDup(syosu, "0")
                txtSUU4.OutputFormat = "#,##0." & StrDup(syosu, "0")
                txtSUU5.OutputFormat = "#,##0." & StrDup(syosu, "0")
                txtSUU6.OutputFormat = "#,##0." & StrDup(syosu, "0")
                txtSUU7.OutputFormat = "#,##0." & StrDup(syosu, "0")
                txtSUU8.OutputFormat = "#,##0." & StrDup(syosu, "0")
                txtSUU9.OutputFormat = "#,##0." & StrDup(syosu, "0")
                txtSUU10.OutputFormat = "#,##0." & StrDup(syosu, "0")
                txtSUU11.OutputFormat = "#,##0." & StrDup(syosu, "0")
        End Select

        '単位
        txtTANI1.DataField = "TANI1"
        txtTANI2.DataField = "TANI2"
        txtTANI3.DataField = "TANI3"
        txtTANI4.DataField = "TANI4"
        txtTANI5.DataField = "TANI5"
        txtTANI6.DataField = "TANI6"
        txtTANI7.DataField = "TANI7"
        txtTANI8.DataField = "TANI8"
        txtTANI9.DataField = "TANI9"
        txtTANI10.DataField = "TANI10"
        txtTANI11.DataField = "TANI11"
        '単価
        txtMITUMORITANKA1.DataField = "MITUMORITANKA1"
        txtMITUMORITANKA2.DataField = "MITUMORITANKA2"
        txtMITUMORITANKA3.DataField = "MITUMORITANKA3"
        txtMITUMORITANKA4.DataField = "MITUMORITANKA4"
        txtMITUMORITANKA5.DataField = "MITUMORITANKA5"
        txtMITUMORITANKA6.DataField = "MITUMORITANKA6"
        txtMITUMORITANKA7.DataField = "MITUMORITANKA7"
        txtMITUMORITANKA8.DataField = "MITUMORITANKA8"
        txtMITUMORITANKA9.DataField = "MITUMORITANKA9"
        txtMITUMORITANKA10.DataField = "MITUMORITANKA10"
        txtMITUMORITANKA11.DataField = "MITUMORITANKA11"
        txtMITUMORITANKA1.OutputFormat = "#,###"
        txtMITUMORITANKA2.OutputFormat = "#,###"
        txtMITUMORITANKA3.OutputFormat = "#,###"
        txtMITUMORITANKA4.OutputFormat = "#,###"
        txtMITUMORITANKA5.OutputFormat = "#,###"
        txtMITUMORITANKA6.OutputFormat = "#,###"
        txtMITUMORITANKA7.OutputFormat = "#,###"
        txtMITUMORITANKA8.OutputFormat = "#,###"
        txtMITUMORITANKA9.OutputFormat = "#,###"
        txtMITUMORITANKA10.OutputFormat = "#,###"
        txtMITUMORITANKA11.OutputFormat = "#,###"
        '金額
        txtMITUMORIGAKU1.DataField = "MITUMORIGAKU1"
        txtMITUMORIGAKU2.DataField = "MITUMORIGAKU2"
        txtMITUMORIGAKU3.DataField = "MITUMORIGAKU3"
        txtMITUMORIGAKU4.DataField = "MITUMORIGAKU4"
        txtMITUMORIGAKU5.DataField = "MITUMORIGAKU5"
        txtMITUMORIGAKU6.DataField = "MITUMORIGAKU6"
        txtMITUMORIGAKU7.DataField = "MITUMORIGAKU7"
        txtMITUMORIGAKU8.DataField = "MITUMORIGAKU8"
        txtMITUMORIGAKU9.DataField = "MITUMORIGAKU9"
        txtMITUMORIGAKU10.DataField = "MITUMORIGAKU10"
        txtMITUMORIGAKU11.DataField = "MITUMORIGAKU11"
        txtMITUMORIGAKU1.OutputFormat = "#,##0"
        txtMITUMORIGAKU2.OutputFormat = "#,##0"
        txtMITUMORIGAKU3.OutputFormat = "#,##0"
        txtMITUMORIGAKU4.OutputFormat = "#,##0"
        txtMITUMORIGAKU5.OutputFormat = "#,##0"
        txtMITUMORIGAKU6.OutputFormat = "#,##0"
        txtMITUMORIGAKU7.OutputFormat = "#,##0"
        txtMITUMORIGAKU8.OutputFormat = "#,##0"
        txtMITUMORIGAKU9.OutputFormat = "#,##0"
        txtMITUMORIGAKU10.OutputFormat = "#,##0"
        txtMITUMORIGAKU11.OutputFormat = "#,##0"
        '備考
        txtG_BIKO1.DataField = "G_BIKO1"
        txtG_BIKO2.DataField = "G_BIKO2"
        txtG_BIKO3.DataField = "G_BIKO3"
        txtG_BIKO4.DataField = "G_BIKO4"
        txtG_BIKO5.DataField = "G_BIKO5"
        txtG_BIKO6.DataField = "G_BIKO6"
        txtG_BIKO7.DataField = "G_BIKO7"
        txtG_BIKO8.DataField = "G_BIKO8"
        txtG_BIKO9.DataField = "G_BIKO9"
        txtG_BIKO10.DataField = "G_BIKO10"
        txtG_BIKO11.DataField = "G_BIKO11"

        '伝票備考
        txtD_BIKO.DataField = "D_BIKO"

    End Sub

    '￣￣￣￣￣￣￣￣￣￣￣
    '　レポートスタート時
    '＿＿＿＿＿＿＿＿＿＿＿

    Private Sub ActiveReport_ReportStart(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.ReportStart

    End Sub

    '↓2015.07.02 Ins yamada
    Private Sub PageHeader_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles PageHeader.BeforePrint

        Const TEL As String = "TEL   :"
        Const FAX As String = "FAX   :"
        Const MAI As String = "E-mail:"
        Const WEB As String = "URL   :"

        txtTELNO.Text = TEL + txtTELNO.Text
        txtFAXNO.Text = FAX + txtFAXNO.Text
        txtEMAIL.Text = MAI + txtEMAIL.Text
        txtWEB.Text = WEB + txtWEB.Text

    End Sub
    '↑2015.07.02 Ins yamada

    '￣￣￣￣￣￣￣￣￣￣￣￣
    '　 ページヘッダー
    '＿＿＿＿＿＿＿＿＿＿＿＿

    Private Sub PageHeader_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageHeader.Format
        lblNatsuin1.Text = natsuin1
        lblNatsuin2.Text = natsuin2
        lblNatsuin3.Text = natsuin3
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
