<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmZoomOption
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
    'Windows フォーム デザイナを使用して変更できます。  
    'コード エディタを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmZoomOption))
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnLandscape = New System.Windows.Forms.RadioButton()
        Me.btnPortrait = New System.Windows.Forms.RadioButton()
        Me.cmbPrinter = New System.Windows.Forms.ComboBox()
        Me.label1 = New System.Windows.Forms.Label()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnPreview = New System.Windows.Forms.Button()
        Me.txtPaparSize = New System.Windows.Forms.TextBox()
        Me.label3 = New System.Windows.Forms.Label()
        Me.cmbPaperSize = New System.Windows.Forms.ComboBox()
        Me.label2 = New System.Windows.Forms.Label()
        Me.prViewdlg = New System.Windows.Forms.PrintPreviewDialog()
        Me.prDoc = New System.Drawing.Printing.PrintDocument()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmbLayout = New System.Windows.Forms.ComboBox()
        Me.label4 = New System.Windows.Forms.Label()
        Me.groupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.btnLandscape)
        Me.groupBox1.Controls.Add(Me.btnPortrait)
        Me.groupBox1.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.groupBox1.Location = New System.Drawing.Point(134, 149)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(198, 85)
        Me.groupBox1.TabIndex = 33
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "用紙方向"
        '
        'btnLandscape
        '
        Me.btnLandscape.AutoSize = True
        Me.btnLandscape.Location = New System.Drawing.Point(21, 52)
        Me.btnLandscape.Name = "btnLandscape"
        Me.btnLandscape.Size = New System.Drawing.Size(38, 22)
        Me.btnLandscape.TabIndex = 2
        Me.btnLandscape.Text = "横"
        Me.btnLandscape.UseVisualStyleBackColor = True
        '
        'btnPortrait
        '
        Me.btnPortrait.AutoSize = True
        Me.btnPortrait.Location = New System.Drawing.Point(21, 24)
        Me.btnPortrait.Name = "btnPortrait"
        Me.btnPortrait.Size = New System.Drawing.Size(38, 22)
        Me.btnPortrait.TabIndex = 1
        Me.btnPortrait.Text = "縦"
        Me.btnPortrait.UseVisualStyleBackColor = True
        '
        'cmbPrinter
        '
        Me.cmbPrinter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPrinter.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbPrinter.Location = New System.Drawing.Point(133, 22)
        Me.cmbPrinter.Name = "cmbPrinter"
        Me.cmbPrinter.Size = New System.Drawing.Size(200, 26)
        Me.cmbPrinter.TabIndex = 32
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.label1.Location = New System.Drawing.Point(35, 25)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(92, 18)
        Me.label1.TabIndex = 31
        Me.label1.Text = "プリンタの選択"
        Me.ToolTip1.SetToolTip(Me.label1, "出力するプリンタを選択します")
        '
        'btnPrint
        '
        Me.btnPrint.BackColor = System.Drawing.Color.Transparent
        Me.btnPrint.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnPrint.Location = New System.Drawing.Point(12, 251)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(103, 29)
        Me.btnPrint.TabIndex = 30
        Me.btnPrint.Text = "印刷"
        Me.ToolTip1.SetToolTip(Me.btnPrint, "プレビューせずに印刷します")
        Me.btnPrint.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.Transparent
        Me.btnCancel.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(230, 251)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(103, 29)
        Me.btnCancel.TabIndex = 29
        Me.btnCancel.Text = "キャンセル"
        Me.ToolTip1.SetToolTip(Me.btnCancel, "キャンセル")
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnPreview
        '
        Me.btnPreview.BackColor = System.Drawing.Color.Transparent
        Me.btnPreview.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnPreview.Location = New System.Drawing.Point(121, 251)
        Me.btnPreview.Name = "btnPreview"
        Me.btnPreview.Size = New System.Drawing.Size(103, 29)
        Me.btnPreview.TabIndex = 28
        Me.btnPreview.Text = "プレビュー"
        Me.ToolTip1.SetToolTip(Me.btnPreview, "PrintPreviewDialogでプレビューします")
        Me.btnPreview.UseVisualStyleBackColor = False
        '
        'txtPaparSize
        '
        Me.txtPaparSize.BackColor = System.Drawing.SystemColors.Control
        Me.txtPaparSize.Enabled = False
        Me.txtPaparSize.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtPaparSize.Location = New System.Drawing.Point(134, 86)
        Me.txtPaparSize.Name = "txtPaparSize"
        Me.txtPaparSize.ReadOnly = True
        Me.txtPaparSize.Size = New System.Drawing.Size(121, 25)
        Me.txtPaparSize.TabIndex = 27
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.label3.Location = New System.Drawing.Point(23, 89)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(104, 18)
        Me.label3.TabIndex = 26
        Me.label3.Text = "原稿の用紙サイズ"
        Me.ToolTip1.SetToolTip(Me.label3, "元のレポートの用紙サイズです")
        '
        'cmbPaperSize
        '
        Me.cmbPaperSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPaperSize.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbPaperSize.FormattingEnabled = True
        Me.cmbPaperSize.Location = New System.Drawing.Point(133, 117)
        Me.cmbPaperSize.Name = "cmbPaperSize"
        Me.cmbPaperSize.Size = New System.Drawing.Size(200, 26)
        Me.cmbPaperSize.TabIndex = 25
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.label2.Location = New System.Drawing.Point(11, 120)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(116, 18)
        Me.label2.TabIndex = 24
        Me.label2.Text = "出力する用紙サイズ"
        Me.ToolTip1.SetToolTip(Me.label2, "出力する用紙サイズを選択します。ここで選択されたページにフィットするよう自動的に拡大／縮小されます")
        '
        'prViewdlg
        '
        Me.prViewdlg.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.prViewdlg.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.prViewdlg.ClientSize = New System.Drawing.Size(400, 300)
        Me.prViewdlg.Enabled = True
        Me.prViewdlg.Icon = CType(resources.GetObject("prViewdlg.Icon"), System.Drawing.Icon)
        Me.prViewdlg.Name = "prViewdlg"
        Me.prViewdlg.Visible = False
        '
        'prDoc
        '
        '
        'cmbLayout
        '
        Me.cmbLayout.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLayout.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbLayout.FormattingEnabled = True
        Me.cmbLayout.Items.AddRange(New Object() {"１ページ／枚", "２ページ／枚"})
        Me.cmbLayout.Location = New System.Drawing.Point(133, 54)
        Me.cmbLayout.Name = "cmbLayout"
        Me.cmbLayout.Size = New System.Drawing.Size(121, 26)
        Me.cmbLayout.TabIndex = 35
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.label4.Location = New System.Drawing.Point(24, 57)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(104, 18)
        Me.label4.TabIndex = 34
        Me.label4.Text = "ページレイアウト"
        '
        'frmZoomOption
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(349, 292)
        Me.Controls.Add(Me.cmbLayout)
        Me.Controls.Add(Me.label4)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.cmbPrinter)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnPreview)
        Me.Controls.Add(Me.txtPaparSize)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.cmbPaperSize)
        Me.Controls.Add(Me.label2)
        Me.Name = "frmZoomOption"
        Me.Text = "拡大／縮小オプション"
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents btnLandscape As System.Windows.Forms.RadioButton
    Private WithEvents btnPortrait As System.Windows.Forms.RadioButton
    Private WithEvents cmbPrinter As System.Windows.Forms.ComboBox
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents btnPrint As System.Windows.Forms.Button
    Private WithEvents btnCancel As System.Windows.Forms.Button
    Private WithEvents btnPreview As System.Windows.Forms.Button
    Private WithEvents txtPaparSize As System.Windows.Forms.TextBox
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents cmbPaperSize As System.Windows.Forms.ComboBox
    Private WithEvents label2 As System.Windows.Forms.Label
    Friend WithEvents prViewdlg As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents prDoc As System.Drawing.Printing.PrintDocument
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Private WithEvents cmbLayout As System.Windows.Forms.ComboBox
    Private WithEvents label4 As System.Windows.Forms.Label
End Class
