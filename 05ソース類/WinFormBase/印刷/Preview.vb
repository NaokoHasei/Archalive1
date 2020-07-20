Public Class Preview

    Public previewMode As Boolean = False

    Private PDFFolderNameValue As String
    Public Property PDFFolderName() As String
        Get
            Return PDFFolderNameValue
        End Get
        Set(ByVal value As String)
            PDFFolderNameValue = value
        End Set
    End Property

    Private Sub savePdf_Click(sender As Object, e As EventArgs)
        Using pdfExport1 As New GrapeCity.ActiveReports.Export.Pdf.Section.PdfExport
            'ﾌｧｲﾙﾀｲﾄﾙの編集
            Dim strFileTitle As String = Me.Text
            Dim strTimeStamp As String = Format(Now(), "yyyyMMdd_HHmmss")
            Dim strFolderName As String = PDFFolderName
            Dim strFileName As String = strFolderName & "\" & strFileTitle & "_" & strTimeStamp & ".PDF"

            Dim saveDialog As New Windows.Forms.SaveFileDialog()
            saveDialog.Title = Me.Text
            saveDialog.Filter = "PDF files (*.pdf)|*.pdf"
            saveDialog.InitialDirectory = strFolderName
            saveDialog.FileName = strFileName

            If saveDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
                strFileName = saveDialog.FileName
                pdfExport1.Export(Viewer1.Document, strFileName)
            End If
        End Using
    End Sub

    Private Sub endPreview_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub zoomInOut_Click(sender As Object, e As EventArgs)
        Dim frmopt As New frmZoomOption(Viewer1.Document)
        frmopt.StartPosition = FormStartPosition.CenterParent
        frmopt.ShowDialog(Me)
    End Sub

    Public Sub New()

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。
    End Sub

    Private Sub Preview_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If previewMode Then
            '印刷ボタンを非表示
            Viewer1.Toolbar.ToolStrip.Items.RemoveAt(2)
            Viewer1.Toolbar.ToolStrip.Items.RemoveAt(3)

        Else
            ' カスタムボタンを作成します。
            Dim btn1 As New ToolStripButton("PDF保存(&S)")
            btn1.ToolTipText = "PDFファイル保存"
            btn1.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText
            Viewer1.Toolbar.ToolStrip.Items.Add(btn1)
            AddHandler btn1.Click, AddressOf savePdf_Click
        End If

        Dim btn As New ToolStripButton("拡大／縮小...")
        btn.ToolTipText = "拡大／縮小"
        btn.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText
        Viewer1.Toolbar.ToolStrip.Items.Add(btn)
        AddHandler btn.Click, AddressOf zoomInOut_Click

        Dim btn2 As New ToolStripButton("閉じる(&E)")
        btn2.ToolTipText = "プレビュー終了"
        btn2.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText
        Viewer1.Toolbar.ToolStrip.Items.Add(btn2)
        AddHandler btn2.Click, AddressOf endPreview_Click

        Viewer1.ReportViewer.Zoom = 0.9 '90%

        Me.WindowState = FormWindowState.Maximized  '最大表示
    End Sub

    Private Sub Preview_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        With Viewer1
            .Height = Me.Height - 8
            .Width = Me.Width - 34
        End With
    End Sub
End Class