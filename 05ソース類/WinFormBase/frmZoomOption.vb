Imports GrapeCity.ActiveReports
Public Class frmZoomOption

    Private ardoc As GrapeCity.ActiveReports.Document.SectionDocument ' ActiveReportsのレポートドキュメント
    Private prDocPages As Integer ' PrintDocumentページカウント用変数
    Private arPages As Integer    ' ActiveReportsドキュメントのページカウント用変数
    Private arPagesPerprDocPage As Integer  ' PrintDocument１ページあたりのActiveReportsのページ数（本サンプルの場合 1 or 2）

    Public Sub New(ByVal rpt As GrapeCity.ActiveReports.Document.SectionDocument)

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。
        Me.ardoc = rpt

    End Sub

    Private Sub frmZoomOption_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' ページレイアウトの初期値は「１ページ／枚」を設定します。
        Me.cmbLayout.SelectedIndex = 0

        ' レポート作成時の用紙サイズを表示します。
        Me.txtPaparSize.Text = ardoc.Printer.PaperKind.ToString()

        ' ドキュメント名をセットします。
        prDoc.DocumentName = ardoc.Name

        ' コンピュータにインストールされているプリンタを列挙します。
        cmbPrinter.BeginUpdate()
        cmbPrinter.Items.Clear()
        Dim i As Integer = 0
        For Each s As String In System.Drawing.Printing.PrinterSettings.InstalledPrinters
            cmbPrinter.Items.Insert(i, s)
            If s = prDoc.PrinterSettings.PrinterName Then
                cmbPrinter.SelectedIndex = i ' 初期はデフォルトプリンタとする。
            End If
            i = i + 1
        Next
        cmbPrinter.EndUpdate()

        ' 現在のプリンタで使用可能な用紙サイズを列挙します。
        cmbPaperSize.BeginUpdate()
        cmbPaperSize.Items.Clear()
        i = 0
        For Each ps As System.Drawing.Printing.PaperSize In prDoc.PrinterSettings.PaperSizes
            cmbPaperSize.Items.Insert(i, ps.Kind.ToString())
            If ps.Kind = prDoc.PrinterSettings.DefaultPageSettings.PaperSize.Kind Then
                cmbPaperSize.SelectedIndex = i ' 初期値はプリンタ規定の用紙サイズとする。
            End If
            i = i + 1
        Next
        cmbPaperSize.EndUpdate()

        ' デフォルトの用紙方向をセットします。
        If prDoc.DefaultPageSettings.Landscape Then
            btnLandscape.Checked = True
        Else
            btnPortrait.Checked = True
        End If

    End Sub

    Private Sub btnPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreview.Click

        ' プレビュー処理
        ' 用紙サイズをセットします。
        For Each ps As System.Drawing.Printing.PaperSize In prDoc.PrinterSettings.PaperSizes
            If ps.Kind.ToString() = CType(Me.cmbPaperSize.SelectedItem, String) Then
                prDoc.DefaultPageSettings.PaperSize = ps
            End If
        Next

        ' 用紙方向をセットします。
        prDoc.DefaultPageSettings.Landscape = btnLandscape.Checked
        prViewdlg.Document = prDoc
        prViewdlg.ShowDialog(Me)

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Me.Close()

    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click

        ' 印刷処理
        ' 用紙サイズをセットします。
        For Each ps As System.Drawing.Printing.PaperSize In prDoc.PrinterSettings.PaperSizes
            If ps.Kind.ToString() = CType(Me.cmbPaperSize.SelectedItem, String) Then
                prDoc.DefaultPageSettings.PaperSize = ps
            End If
        Next

        ' 用紙方向をセットします。
        prDoc.DefaultPageSettings.Landscape = btnLandscape.Checked
        prDoc.Print()

    End Sub

    Private Sub cmbPrinter_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPrinter.SelectedIndexChanged

        ' プリンタの変更処理
        ' コンボボックスからプリンタが変更された場合
        Try
            ' PrintDocumetのデフォルトプリンタをコンボボックスで指定された値にセットします。
            prDoc.PrinterSettings.PrinterName = CType(Me.cmbPrinter.SelectedItem, String)

            ' 現在のプリンタで使用可能な用紙サイズを列挙します。
            cmbPaperSize.BeginUpdate()
            cmbPaperSize.Items.Clear()
            Dim i As Integer = 0
            For Each ps As System.Drawing.Printing.PaperSize In prDoc.PrinterSettings.PaperSizes
                cmbPaperSize.Items.Insert(i, ps.Kind.ToString())
                If ps.Kind = prDoc.PrinterSettings.DefaultPageSettings.PaperSize.Kind Then
                    cmbPaperSize.SelectedIndex = i ' 初期値はプリンタ規定の用紙サイズとする。
                End If
                i = i + 1
            Next
            cmbPaperSize.EndUpdate()

        Catch ex As Exception
            ' 無効なプリンタが設定された場合
            MessageBox.Show("無効なプリンタが設定されました。もう一度プリンタを選択してください。" _
                    , "無効なプリンタ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub prDoc_BeginPrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles prDoc.BeginPrint

        ' ページカウントをリセットします。
        prDocPages = 0
        arPages = 0

    End Sub

    Private Sub prDoc_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles prDoc.PrintPage

        ' ページの描画

        ' 描画領域(印刷領域全部)の幅と高さです。
        ' PrintDocumetの座標単位は1/100インチなので、以降、インチで扱うためにここで変換します。
        Dim width As Single = e.PageBounds.Width / 100.0F
        Dim height As Single = e.PageBounds.Height / 100.0F

        ' Page.Draw()の呼び出しに必要なRectangleF()です。
        If arPagesPerprDocPage = 2 Then
            ' 「２ページ／枚」時は、用紙の長辺を半分の長さにカットします。
            If width > height Then
                width = width / 2
            Else
                height = height / 2
            End If
        End If
        Dim boundsInch As System.Drawing.RectangleF = New System.Drawing.RectangleF(0, 0, width, height)

        Dim i As Integer
        For i = 1 To arPagesPerprDocPage Step i + 1

            ' PrintDocumentに描画するActiveReportsページを取得します。
            If arPages >= ardoc.Pages.Count Then Exit For
            Dim page As GrapeCity.ActiveReports.Document.Section.Page = ardoc.Pages(prDocPages)

            ' 拡大縮小比の計算
            Dim scaleX As Single = boundsInch.Width / page.Width
            Dim scaleY As Single = boundsInch.Height / page.Height

            ' レポートのアスペクト比を維持するために、scaleXとscaleYを
            ' 同じ値にセットします。
            ' ※元のアスペクト比が維持されない場合、印刷時にフォントが崩れるなど弊害が発生します。
            If scaleX > scaleY Then
                scaleX = scaleY
            Else
                scaleY = scaleX
            End If

            ' ページを描画します。
            page.Draw(e.Graphics, boundsInch, scaleX, scaleY, True)

            ' ページ描画位置をずらします。
            If (boundsInch.Width > boundsInch.Height) Then
                boundsInch.Y += boundsInch.Height
            Else
                boundsInch.X += boundsInch.Width
            End If
            arPages += 1
        Next

        ' 全ページ印刷したら終了します。
        If arPages < ardoc.Pages.Count Then
            e.HasMorePages = True
        Else
            e.HasMorePages = False
        End If
        prDocPages += 1 ' PrintDocumentのページ数をインクリメント

    End Sub

    Private Sub cmbLayout_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbLayout.SelectedIndexChanged

        ' PrintDocument１ページあたりのActiveReportsのページ数（本サンプルの場合 1 or 2）
        ' をセットします。
        arPagesPerprDocPage = Me.cmbLayout.SelectedIndex + 1

    End Sub
End Class