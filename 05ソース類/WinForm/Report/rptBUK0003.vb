Imports CommonUtility.Utility

Public Class rptBUK0003

    Private _DataSetHeader As dsBUK0003_report.HEADDataTable
    Private _DataSetDetail As dsBUK0003_report.DETAILDataTable
    Private _PrintDatetime As Date

    Public jyokenBukkenName As String
    Public jyokenChakkouDateFrom As String
    Public jyokenChakkouDateTo As String
    Public jyokenKankouDateFrom As String
    Public jyokenKankouDateTo As String

    Public Sub New(ByVal dtHEAD As dsBUK0003_report.HEADDataTable, ByVal dtDETAIL As dsBUK0003_report.DETAILDataTable, ByVal printDatetime As Date)

        ' InitializeComponent() 呼び出しの後で初期化を追加します。
        InitializeComponent()

        '余白設定
        Me.PageSettings.Margins.Top = CmToInch(1)
        Me.PageSettings.Margins.Bottom = CmToInch(1)
        Me.PageSettings.Margins.Left = CmToInch(0.5)
        Me.PageSettings.Margins.Right = CmToInch(0.5)

        Me.PageSettings.PaperKind = Drawing.Printing.PaperKind.A4
        Me.PageSettings.Orientation = GrapeCity.ActiveReports.Document.Section.PageOrientation.Landscape

        _DataSetHeader = dtHEAD
        _DataSetDetail = dtDETAIL
        _PrintDatetime = printDatetime

        Me.DataSource = _DataSetDetail
    End Sub

    Private Sub ActiveReport_Initialize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DataInitialize
        Dim dateNone = "    /  /"
        txtPrintDatetime.Text = _PrintDatetime.ToString("yyyy/MM/dd HH:mm")
        '条件部
        If NUCheck(jyokenBukkenName) Then
            txtJyokenBukkenName.Text = "指定なし"
        Else
            txtJyokenBukkenName.Text = jyokenBukkenName
        End If

        If jyokenChakkouDateFrom = dateNone AndAlso jyokenChakkouDateTo = dateNone Then
            txtJyokenChakkouDate.Text = "指定なし"
        Else
            txtJyokenChakkouDate.Text = Replace(jyokenChakkouDateFrom, dateNone, "") + " ～ " + Replace(jyokenChakkouDateTo, dateNone, "")
        End If

        If jyokenKankouDateFrom = dateNone AndAlso jyokenKankouDateTo = dateNone Then
            txtJyokenKankoDate.Text = "指定なし"
        Else
            txtJyokenKankoDate.Text = Replace(jyokenKankouDateFrom, dateNone, "") + " ～ " + Replace(jyokenKankouDateTo, dateNone, "")
        End If

        '明細部
        Fields.Add("BUKKENNO")
        Fields.Add("KOUSHU")
        Fields.Add("BUKKENNAME")
        Fields.Add("ADDRESS")
        Fields.Add("MOTOUKENAME")
        Fields.Add("SHITAUKEGYOSHA")
        Fields.Add("JYUCHUKINGAKU")
        Fields.Add("SHIHARAIGENKA")
        Fields.Add("ARARIGAKU")
        Fields.Add("ARARIRITU")
        Fields.Add("CHAKKOUDATE")
        Fields.Add("KANKOUDATE")

        txtBUKKENNO.DataField = "BUKKENNO"
        txtKOUSHU.DataField = "KOUSHU"
        txtBUKKENNAME.DataField = "BUKKENNAME"
        txtADDRESS.DataField = "ADDRESS"
        txtMOTOUKENAME.DataField = "MOTOUKENAME"
        txtSHITAUKEGYOSHA.DataField = "SHITAUKEGYOSHA"
        txtJYUCHUKINGAKU.DataField = "JYUCHUKINGAKU"
        txtSHIHARAIGENKA.DataField = "SHIHARAIGENKA"
        txtARARIGAKU.DataField = "ARARIGAKU"
        txtARARIRITU.DataField = "ARARIRITU"
        txtCHAKKOUDATE.DataField = "CHAKKOUDATE"
        txtKANKOUDATE.DataField = "KANKOUDATE"

        txtJYUCHUKINGAKU.OutputFormat = "#,##0"
        txtSHIHARAIGENKA.OutputFormat = "#,##0"
        txtARARIGAKU.OutputFormat = "#,##0"
        txtARARIRITU.OutputFormat = "#0.00%"
    End Sub

    Private Sub PageHeader_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageHeader.Format

        lblPage.Text = "P．" + PageNumber.ToString

        With CType(_DataSetHeader.Rows(0), dsBUK0003_report.HEADRow)
            txtJYUCHUKINGAKU_SUM.Text = .JYUCHUKINGAKU_SUM.ToString("#,0")
            txtSHIHARAIGENKA_SUM.Text = .SHIHARAIGENKA_SUM.ToString("#,0")
            txtARARIGAKU_SUM.Text = .ARARIGAKU_SUM.ToString("#,0")
            txtARARIRITU_SUM.Text = .ARARIRITU_SUM.ToString("0.00") + "%"
        End With
    End Sub
End Class
