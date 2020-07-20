Imports GrapeCity.ActiveReports
Public Class frmZoomOption

    Private ardoc As GrapeCity.ActiveReports.Document.SectionDocument ' ActiveReports�̃��|�[�g�h�L�������g
    Private prDocPages As Integer ' PrintDocument�y�[�W�J�E���g�p�ϐ�
    Private arPages As Integer    ' ActiveReports�h�L�������g�̃y�[�W�J�E���g�p�ϐ�
    Private arPagesPerprDocPage As Integer  ' PrintDocument�P�y�[�W�������ActiveReports�̃y�[�W���i�{�T���v���̏ꍇ 1 or 2�j

    Public Sub New(ByVal rpt As GrapeCity.ActiveReports.Document.SectionDocument)

        ' ���̌Ăяo���́AWindows �t�H�[�� �f�U�C�i�ŕK�v�ł��B
        InitializeComponent()

        ' InitializeComponent() �Ăяo���̌�ŏ�������ǉ����܂��B
        Me.ardoc = rpt

    End Sub

    Private Sub frmZoomOption_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' �y�[�W���C�A�E�g�̏����l�́u�P�y�[�W�^���v��ݒ肵�܂��B
        Me.cmbLayout.SelectedIndex = 0

        ' ���|�[�g�쐬���̗p���T�C�Y��\�����܂��B
        Me.txtPaparSize.Text = ardoc.Printer.PaperKind.ToString()

        ' �h�L�������g�����Z�b�g���܂��B
        prDoc.DocumentName = ardoc.Name

        ' �R���s���[�^�ɃC���X�g�[������Ă���v�����^��񋓂��܂��B
        cmbPrinter.BeginUpdate()
        cmbPrinter.Items.Clear()
        Dim i As Integer = 0
        For Each s As String In System.Drawing.Printing.PrinterSettings.InstalledPrinters
            cmbPrinter.Items.Insert(i, s)
            If s = prDoc.PrinterSettings.PrinterName Then
                cmbPrinter.SelectedIndex = i ' �����̓f�t�H���g�v�����^�Ƃ���B
            End If
            i = i + 1
        Next
        cmbPrinter.EndUpdate()

        ' ���݂̃v�����^�Ŏg�p�\�ȗp���T�C�Y��񋓂��܂��B
        cmbPaperSize.BeginUpdate()
        cmbPaperSize.Items.Clear()
        i = 0
        For Each ps As System.Drawing.Printing.PaperSize In prDoc.PrinterSettings.PaperSizes
            cmbPaperSize.Items.Insert(i, ps.Kind.ToString())
            If ps.Kind = prDoc.PrinterSettings.DefaultPageSettings.PaperSize.Kind Then
                cmbPaperSize.SelectedIndex = i ' �����l�̓v�����^�K��̗p���T�C�Y�Ƃ���B
            End If
            i = i + 1
        Next
        cmbPaperSize.EndUpdate()

        ' �f�t�H���g�̗p���������Z�b�g���܂��B
        If prDoc.DefaultPageSettings.Landscape Then
            btnLandscape.Checked = True
        Else
            btnPortrait.Checked = True
        End If

    End Sub

    Private Sub btnPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreview.Click

        ' �v���r���[����
        ' �p���T�C�Y���Z�b�g���܂��B
        For Each ps As System.Drawing.Printing.PaperSize In prDoc.PrinterSettings.PaperSizes
            If ps.Kind.ToString() = CType(Me.cmbPaperSize.SelectedItem, String) Then
                prDoc.DefaultPageSettings.PaperSize = ps
            End If
        Next

        ' �p���������Z�b�g���܂��B
        prDoc.DefaultPageSettings.Landscape = btnLandscape.Checked
        prViewdlg.Document = prDoc
        prViewdlg.ShowDialog(Me)

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Me.Close()

    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click

        ' �������
        ' �p���T�C�Y���Z�b�g���܂��B
        For Each ps As System.Drawing.Printing.PaperSize In prDoc.PrinterSettings.PaperSizes
            If ps.Kind.ToString() = CType(Me.cmbPaperSize.SelectedItem, String) Then
                prDoc.DefaultPageSettings.PaperSize = ps
            End If
        Next

        ' �p���������Z�b�g���܂��B
        prDoc.DefaultPageSettings.Landscape = btnLandscape.Checked
        prDoc.Print()

    End Sub

    Private Sub cmbPrinter_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPrinter.SelectedIndexChanged

        ' �v�����^�̕ύX����
        ' �R���{�{�b�N�X����v�����^���ύX���ꂽ�ꍇ
        Try
            ' PrintDocumet�̃f�t�H���g�v�����^���R���{�{�b�N�X�Ŏw�肳�ꂽ�l�ɃZ�b�g���܂��B
            prDoc.PrinterSettings.PrinterName = CType(Me.cmbPrinter.SelectedItem, String)

            ' ���݂̃v�����^�Ŏg�p�\�ȗp���T�C�Y��񋓂��܂��B
            cmbPaperSize.BeginUpdate()
            cmbPaperSize.Items.Clear()
            Dim i As Integer = 0
            For Each ps As System.Drawing.Printing.PaperSize In prDoc.PrinterSettings.PaperSizes
                cmbPaperSize.Items.Insert(i, ps.Kind.ToString())
                If ps.Kind = prDoc.PrinterSettings.DefaultPageSettings.PaperSize.Kind Then
                    cmbPaperSize.SelectedIndex = i ' �����l�̓v�����^�K��̗p���T�C�Y�Ƃ���B
                End If
                i = i + 1
            Next
            cmbPaperSize.EndUpdate()

        Catch ex As Exception
            ' �����ȃv�����^���ݒ肳�ꂽ�ꍇ
            MessageBox.Show("�����ȃv�����^���ݒ肳��܂����B������x�v�����^��I�����Ă��������B" _
                    , "�����ȃv�����^", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub prDoc_BeginPrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles prDoc.BeginPrint

        ' �y�[�W�J�E���g�����Z�b�g���܂��B
        prDocPages = 0
        arPages = 0

    End Sub

    Private Sub prDoc_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles prDoc.PrintPage

        ' �y�[�W�̕`��

        ' �`��̈�(����̈�S��)�̕��ƍ����ł��B
        ' PrintDocumet�̍��W�P�ʂ�1/100�C���`�Ȃ̂ŁA�ȍ~�A�C���`�ň������߂ɂ����ŕϊ����܂��B
        Dim width As Single = e.PageBounds.Width / 100.0F
        Dim height As Single = e.PageBounds.Height / 100.0F

        ' Page.Draw()�̌Ăяo���ɕK�v��RectangleF()�ł��B
        If arPagesPerprDocPage = 2 Then
            ' �u�Q�y�[�W�^���v���́A�p���̒��ӂ𔼕��̒����ɃJ�b�g���܂��B
            If width > height Then
                width = width / 2
            Else
                height = height / 2
            End If
        End If
        Dim boundsInch As System.Drawing.RectangleF = New System.Drawing.RectangleF(0, 0, width, height)

        Dim i As Integer
        For i = 1 To arPagesPerprDocPage Step i + 1

            ' PrintDocument�ɕ`�悷��ActiveReports�y�[�W���擾���܂��B
            If arPages >= ardoc.Pages.Count Then Exit For
            Dim page As GrapeCity.ActiveReports.Document.Section.Page = ardoc.Pages(prDocPages)

            ' �g��k����̌v�Z
            Dim scaleX As Single = boundsInch.Width / page.Width
            Dim scaleY As Single = boundsInch.Height / page.Height

            ' ���|�[�g�̃A�X�y�N�g����ێ����邽�߂ɁAscaleX��scaleY��
            ' �����l�ɃZ�b�g���܂��B
            ' �����̃A�X�y�N�g�䂪�ێ�����Ȃ��ꍇ�A������Ƀt�H���g�������ȂǕ��Q���������܂��B
            If scaleX > scaleY Then
                scaleX = scaleY
            Else
                scaleY = scaleX
            End If

            ' �y�[�W��`�悵�܂��B
            page.Draw(e.Graphics, boundsInch, scaleX, scaleY, True)

            ' �y�[�W�`��ʒu�����炵�܂��B
            If (boundsInch.Width > boundsInch.Height) Then
                boundsInch.Y += boundsInch.Height
            Else
                boundsInch.X += boundsInch.Width
            End If
            arPages += 1
        Next

        ' �S�y�[�W���������I�����܂��B
        If arPages < ardoc.Pages.Count Then
            e.HasMorePages = True
        Else
            e.HasMorePages = False
        End If
        prDocPages += 1 ' PrintDocument�̃y�[�W�����C���N�������g

    End Sub

    Private Sub cmbLayout_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbLayout.SelectedIndexChanged

        ' PrintDocument�P�y�[�W�������ActiveReports�̃y�[�W���i�{�T���v���̏ꍇ 1 or 2�j
        ' ���Z�b�g���܂��B
        arPagesPerprDocPage = Me.cmbLayout.SelectedIndex + 1

    End Sub
End Class