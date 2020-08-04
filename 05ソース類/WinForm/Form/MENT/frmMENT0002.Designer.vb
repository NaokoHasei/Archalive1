<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMENT0002
    Inherits WinFormBase.FormBase

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。

    <System.Diagnostics.DebuggerNonUserCode()>
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

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMENT0002))
        Me.dbgMeisai = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtKamokuHinmoku = New CommonUtility.WinFormControls.TextBoxEx()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.lblInput = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbJyouiCode = New CommonUtility.WinFormControls.TypComboBox()
        Me.lblJyouiKamokuHinmoku = New CommonUtility.WinFormControls.TextBoxEx()
        Me.dbgInput = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.rdoALL = New System.Windows.Forms.RadioButton()
        Me.rdoSKAMOKU = New System.Windows.Forms.RadioButton()
        Me.rdoDKAMOKU = New System.Windows.Forms.RadioButton()
        Me.rdoCKAMOKU = New System.Windows.Forms.RadioButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.rdoSKAMOKU_NEW = New System.Windows.Forms.RadioButton()
        Me.rdoDKAMOKU_NEW = New System.Windows.Forms.RadioButton()
        Me.lblJyouiKamokuHinmokuNew = New CommonUtility.WinFormControls.TextBoxEx()
        Me.rdoCKAMOKU_NEW = New System.Windows.Forms.RadioButton()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbJyouiCodeNew = New CommonUtility.WinFormControls.TypComboBox()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.lblMessage1 = New System.Windows.Forms.Label()
        CType(Me.dbgMeisai, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dbgInput, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TitleBar
        '
        Me.TitleBar.AppearanceType = CommonUtility.WinFormControls.AppearanceType.Normal
        Me.TitleBar.EditMode = CommonUtility.WinFormControls.EditMode.None
        Me.TitleBar.Title = ""
        '
        'FunctionKey
        '
        Me.FunctionKey.Location = New System.Drawing.Point(0, 606)
        '
        'dbgMeisai
        '
        Me.dbgMeisai.AllowUpdate = False
        Me.dbgMeisai.BackColor = System.Drawing.Color.Thistle
        Me.dbgMeisai.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.dbgMeisai.CaptionHeight = 16
        Me.dbgMeisai.GroupByCaption = "列でグループ化するには、ここに列ヘッダをドラッグします。"
        Me.dbgMeisai.Images.Add(CType(resources.GetObject("dbgMeisai.Images"), System.Drawing.Image))
        Me.dbgMeisai.Location = New System.Drawing.Point(0, 135)
        Me.dbgMeisai.Name = "dbgMeisai"
        Me.dbgMeisai.PreviewInfo.Caption = "印刷プレビューウィンドウ"
        Me.dbgMeisai.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.dbgMeisai.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.dbgMeisai.PreviewInfo.ZoomFactor = 75.0R
        Me.dbgMeisai.PrintInfo.PageSettings = CType(resources.GetObject("dbgMeisai.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.dbgMeisai.RowHeight = 14
        Me.dbgMeisai.Size = New System.Drawing.Size(1018, 325)
        Me.dbgMeisai.TabIndex = 5
        Me.dbgMeisai.TabStop = False
        Me.dbgMeisai.Text = "C1TrueDBGrid1"
        Me.dbgMeisai.UseCompatibleTextRendering = False
        Me.dbgMeisai.PropBag = resources.GetString("dbgMeisai.PropBag")
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.DarkSlateBlue
        Me.Label18.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.Label18.ForeColor = System.Drawing.Color.White
        Me.Label18.Location = New System.Drawing.Point(0, 50)
        Me.Label18.MinimumSize = New System.Drawing.Size(1018, 18)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(1018, 18)
        Me.Label18.TabIndex = 93
        Me.Label18.Text = "科目選択/科目・品目検索"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtKamokuHinmoku
        '
        Me.txtKamokuHinmoku.BackColor = System.Drawing.Color.White
        Me.txtKamokuHinmoku.DisplayName = "科目・品目"
        Me.txtKamokuHinmoku.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtKamokuHinmoku.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtKamokuHinmoku.Location = New System.Drawing.Point(114, 104)
        Me.txtKamokuHinmoku.Margin = New System.Windows.Forms.Padding(1, 3, 0, 3)
        Me.txtKamokuHinmoku.MaxLength = 30
        Me.txtKamokuHinmoku.Name = "txtKamokuHinmoku"
        Me.txtKamokuHinmoku.Size = New System.Drawing.Size(190, 25)
        Me.txtKamokuHinmoku.TabIndex = 5
        Me.txtKamokuHinmoku.Text = "１２３４５６７８９０１２３４５６７８９０１２３４５６７８９０"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.Label15.Location = New System.Drawing.Point(12, 108)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(85, 17)
        Me.Label15.TabIndex = 95
        Me.Label15.Text = "科目・品目検索"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.Label1.Location = New System.Drawing.Point(9, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 17)
        Me.Label1.TabIndex = 96
        Me.Label1.Text = "科目選択"
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.Color.Transparent
        Me.btnSearch.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.btnSearch.ForeColor = System.Drawing.Color.Black
        Me.btnSearch.Location = New System.Drawing.Point(920, 104)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(86, 21)
        Me.btnSearch.TabIndex = 7
        Me.btnSearch.Text = "検索"
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'lblInput
        '
        Me.lblInput.AutoSize = True
        Me.lblInput.BackColor = System.Drawing.Color.DarkSlateBlue
        Me.lblInput.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.lblInput.ForeColor = System.Drawing.Color.White
        Me.lblInput.Location = New System.Drawing.Point(0, 484)
        Me.lblInput.MinimumSize = New System.Drawing.Size(1018, 18)
        Me.lblInput.Name = "lblInput"
        Me.lblInput.Size = New System.Drawing.Size(1018, 18)
        Me.lblInput.TabIndex = 99
        Me.lblInput.Text = "大科目入力"
        Me.lblInput.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.Label3.Location = New System.Drawing.Point(321, 108)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(107, 17)
        Me.Label3.TabIndex = 105
        Me.Label3.Text = "上位科目で絞り込む"
        '
        'cmbJyouiCode
        '
        Me.cmbJyouiCode.AutoValidate = System.Windows.Forms.AutoValidate.Disable
        Me.cmbJyouiCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.cmbJyouiCode.DisplayName = "上位コード"
        Me.cmbJyouiCode.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbJyouiCode.LinkedTextBox = Me.lblJyouiKamokuHinmoku
        Me.cmbJyouiCode.Location = New System.Drawing.Point(434, 107)
        Me.cmbJyouiCode.MaxLength = 3
        Me.cmbJyouiCode.Name = "cmbJyouiCode"
        Me.cmbJyouiCode.Size = New System.Drawing.Size(50, 18)
        Me.cmbJyouiCode.TabIndex = 6
        Me.cmbJyouiCode.UseMasterCheckValidator = True
        Me.cmbJyouiCode.UseUpdateLinkedTextByCodeChange = True
        Me.cmbJyouiCode.UseZeroPadding = True
        Me.cmbJyouiCode.ZeroPaddingLength = 3
        '
        'lblJyouiKamokuHinmoku
        '
        Me.lblJyouiKamokuHinmoku.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.lblJyouiKamokuHinmoku.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lblJyouiKamokuHinmoku.DisplayName = "担当者名称"
        Me.lblJyouiKamokuHinmoku.Enabled = False
        Me.lblJyouiKamokuHinmoku.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblJyouiKamokuHinmoku.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.lblJyouiKamokuHinmoku.Location = New System.Drawing.Point(490, 108)
        Me.lblJyouiKamokuHinmoku.MaxLength = 40
        Me.lblJyouiKamokuHinmoku.Name = "lblJyouiKamokuHinmoku"
        Me.lblJyouiKamokuHinmoku.ReadOnly = True
        Me.lblJyouiKamokuHinmoku.Size = New System.Drawing.Size(174, 17)
        Me.lblJyouiKamokuHinmoku.TabIndex = 107
        Me.lblJyouiKamokuHinmoku.Text = "１２３４５６７８９０１２３４５６７８９０"
        '
        'dbgInput
        '
        Me.dbgInput.AllowDrag = True
        Me.dbgInput.AllowDrop = True
        Me.dbgInput.BackColor = System.Drawing.Color.Thistle
        Me.dbgInput.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.dbgInput.CaptionHeight = 16
        Me.dbgInput.Cursor = System.Windows.Forms.Cursors.Default
        Me.dbgInput.FetchRowStyles = True
        Me.dbgInput.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.dbgInput.GroupByCaption = "列でグループ化するには、ここに列ヘッダをドラッグします。"
        Me.dbgInput.Images.Add(CType(resources.GetObject("dbgInput.Images"), System.Drawing.Image))
        Me.dbgInput.Location = New System.Drawing.Point(0, 542)
        Me.dbgInput.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow
        Me.dbgInput.Name = "dbgInput"
        Me.dbgInput.PreviewInfo.Caption = "印刷プレビューウィンドウ"
        Me.dbgInput.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.dbgInput.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.dbgInput.PreviewInfo.ZoomFactor = 75.0R
        Me.dbgInput.PrintInfo.PageSettings = CType(resources.GetObject("dbgInput.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.dbgInput.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.dbgInput.RowDivider.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.None
        Me.dbgInput.RowHeight = 14
        Me.dbgInput.Size = New System.Drawing.Size(1018, 58)
        Me.dbgInput.TabIndex = 108
        Me.dbgInput.TabStop = False
        Me.dbgInput.UseCompatibleTextRendering = False
        Me.dbgInput.PropBag = resources.GetString("dbgInput.PropBag")
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.rdoALL)
        Me.Panel1.Controls.Add(Me.rdoSKAMOKU)
        Me.Panel1.Controls.Add(Me.rdoDKAMOKU)
        Me.Panel1.Controls.Add(Me.rdoCKAMOKU)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(3, 69)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(891, 31)
        Me.Panel1.TabIndex = 1
        '
        'rdoALL
        '
        Me.rdoALL.AutoSize = True
        Me.rdoALL.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.rdoALL.Location = New System.Drawing.Point(111, 8)
        Me.rdoALL.Name = "rdoALL"
        Me.rdoALL.Size = New System.Drawing.Size(48, 21)
        Me.rdoALL.TabIndex = 1
        Me.rdoALL.TabStop = True
        Me.rdoALL.Text = "全件"
        Me.rdoALL.UseVisualStyleBackColor = True
        '
        'rdoSKAMOKU
        '
        Me.rdoSKAMOKU.AutoSize = True
        Me.rdoSKAMOKU.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.rdoSKAMOKU.Location = New System.Drawing.Point(295, 8)
        Me.rdoSKAMOKU.Name = "rdoSKAMOKU"
        Me.rdoSKAMOKU.Size = New System.Drawing.Size(59, 21)
        Me.rdoSKAMOKU.TabIndex = 4
        Me.rdoSKAMOKU.TabStop = True
        Me.rdoSKAMOKU.Text = "小科目"
        Me.rdoSKAMOKU.UseVisualStyleBackColor = True
        '
        'rdoDKAMOKU
        '
        Me.rdoDKAMOKU.AutoSize = True
        Me.rdoDKAMOKU.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.rdoDKAMOKU.Location = New System.Drawing.Point(165, 8)
        Me.rdoDKAMOKU.Name = "rdoDKAMOKU"
        Me.rdoDKAMOKU.Size = New System.Drawing.Size(59, 21)
        Me.rdoDKAMOKU.TabIndex = 2
        Me.rdoDKAMOKU.TabStop = True
        Me.rdoDKAMOKU.Text = "大科目"
        Me.rdoDKAMOKU.UseVisualStyleBackColor = True
        '
        'rdoCKAMOKU
        '
        Me.rdoCKAMOKU.AutoSize = True
        Me.rdoCKAMOKU.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.rdoCKAMOKU.Location = New System.Drawing.Point(230, 8)
        Me.rdoCKAMOKU.Name = "rdoCKAMOKU"
        Me.rdoCKAMOKU.Size = New System.Drawing.Size(59, 21)
        Me.rdoCKAMOKU.TabIndex = 3
        Me.rdoCKAMOKU.TabStop = True
        Me.rdoCKAMOKU.Text = "中科目"
        Me.rdoCKAMOKU.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.rdoSKAMOKU_NEW)
        Me.Panel2.Controls.Add(Me.rdoDKAMOKU_NEW)
        Me.Panel2.Controls.Add(Me.lblJyouiKamokuHinmokuNew)
        Me.Panel2.Controls.Add(Me.rdoCKAMOKU_NEW)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.cmbJyouiCodeNew)
        Me.Panel2.Location = New System.Drawing.Point(3, 505)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(891, 31)
        Me.Panel2.TabIndex = 8
        '
        'rdoSKAMOKU_NEW
        '
        Me.rdoSKAMOKU_NEW.AutoSize = True
        Me.rdoSKAMOKU_NEW.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.rdoSKAMOKU_NEW.Location = New System.Drawing.Point(241, 8)
        Me.rdoSKAMOKU_NEW.Name = "rdoSKAMOKU_NEW"
        Me.rdoSKAMOKU_NEW.Size = New System.Drawing.Size(59, 21)
        Me.rdoSKAMOKU_NEW.TabIndex = 10
        Me.rdoSKAMOKU_NEW.TabStop = True
        Me.rdoSKAMOKU_NEW.Text = "小科目"
        Me.rdoSKAMOKU_NEW.UseVisualStyleBackColor = True
        '
        'rdoDKAMOKU_NEW
        '
        Me.rdoDKAMOKU_NEW.AutoSize = True
        Me.rdoDKAMOKU_NEW.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.rdoDKAMOKU_NEW.Location = New System.Drawing.Point(111, 8)
        Me.rdoDKAMOKU_NEW.Name = "rdoDKAMOKU_NEW"
        Me.rdoDKAMOKU_NEW.Size = New System.Drawing.Size(59, 21)
        Me.rdoDKAMOKU_NEW.TabIndex = 8
        Me.rdoDKAMOKU_NEW.TabStop = True
        Me.rdoDKAMOKU_NEW.Text = "大科目"
        Me.rdoDKAMOKU_NEW.UseVisualStyleBackColor = True
        '
        'lblJyouiKamokuHinmokuNew
        '
        Me.lblJyouiKamokuHinmokuNew.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.lblJyouiKamokuHinmokuNew.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lblJyouiKamokuHinmokuNew.DisplayName = "担当者名称"
        Me.lblJyouiKamokuHinmokuNew.Enabled = False
        Me.lblJyouiKamokuHinmokuNew.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblJyouiKamokuHinmokuNew.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.lblJyouiKamokuHinmokuNew.Location = New System.Drawing.Point(487, 10)
        Me.lblJyouiKamokuHinmokuNew.MaxLength = 40
        Me.lblJyouiKamokuHinmokuNew.Name = "lblJyouiKamokuHinmokuNew"
        Me.lblJyouiKamokuHinmokuNew.ReadOnly = True
        Me.lblJyouiKamokuHinmokuNew.Size = New System.Drawing.Size(222, 17)
        Me.lblJyouiKamokuHinmokuNew.TabIndex = 107
        Me.lblJyouiKamokuHinmokuNew.Text = "１２３４５６７８９０１２３４５６７８９０"
        '
        'rdoCKAMOKU_NEW
        '
        Me.rdoCKAMOKU_NEW.AutoSize = True
        Me.rdoCKAMOKU_NEW.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.rdoCKAMOKU_NEW.Location = New System.Drawing.Point(176, 8)
        Me.rdoCKAMOKU_NEW.Name = "rdoCKAMOKU_NEW"
        Me.rdoCKAMOKU_NEW.Size = New System.Drawing.Size(59, 21)
        Me.rdoCKAMOKU_NEW.TabIndex = 9
        Me.rdoCKAMOKU_NEW.TabStop = True
        Me.rdoCKAMOKU_NEW.Text = "中科目"
        Me.rdoCKAMOKU_NEW.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.Label6.Location = New System.Drawing.Point(9, 10)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 17)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "新規追加"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.Label7.Location = New System.Drawing.Point(318, 10)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(85, 17)
        Me.Label7.TabIndex = 105
        Me.Label7.Text = "上位科目を指定"
        '
        'cmbJyouiCodeNew
        '
        Me.cmbJyouiCodeNew.AutoValidate = System.Windows.Forms.AutoValidate.Disable
        Me.cmbJyouiCodeNew.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.cmbJyouiCodeNew.DisplayName = "上位コード"
        Me.cmbJyouiCodeNew.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbJyouiCodeNew.LinkedTextBox = Me.lblJyouiKamokuHinmokuNew
        Me.cmbJyouiCodeNew.Location = New System.Drawing.Point(431, 9)
        Me.cmbJyouiCodeNew.MaxLength = 3
        Me.cmbJyouiCodeNew.Name = "cmbJyouiCodeNew"
        Me.cmbJyouiCodeNew.Size = New System.Drawing.Size(50, 18)
        Me.cmbJyouiCodeNew.TabIndex = 11
        Me.cmbJyouiCodeNew.UseMasterCheckValidator = True
        Me.cmbJyouiCodeNew.UseNullValidator = True
        Me.cmbJyouiCodeNew.UseUpdateLinkedTextByCodeChange = True
        Me.cmbJyouiCodeNew.UseZeroPadding = True
        Me.cmbJyouiCodeNew.ZeroPaddingLength = 3
        '
        'btnNew
        '
        Me.btnNew.BackColor = System.Drawing.Color.Transparent
        Me.btnNew.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.btnNew.ForeColor = System.Drawing.Color.Black
        Me.btnNew.Location = New System.Drawing.Point(920, 513)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(86, 21)
        Me.btnNew.TabIndex = 12
        Me.btnNew.Text = "新規"
        Me.btnNew.UseVisualStyleBackColor = False
        '
        'lblMessage1
        '
        Me.lblMessage1.AutoSize = True
        Me.lblMessage1.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.lblMessage1.ForeColor = System.Drawing.Color.Red
        Me.lblMessage1.Location = New System.Drawing.Point(0, 463)
        Me.lblMessage1.Name = "lblMessage1"
        Me.lblMessage1.Size = New System.Drawing.Size(356, 17)
        Me.lblMessage1.TabIndex = 109
        Me.lblMessage1.Text = "※「Shiftキー or Ctrlキー」＋「クリック or 矢印キー」で複数選択可"
        '
        'frmMENT0002
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 670)
        Me.Controls.Add(Me.lblMessage1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.dbgInput)
        Me.Controls.Add(Me.lblJyouiKamokuHinmoku)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.lblInput)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmbJyouiCode)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.txtKamokuHinmoku)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.dbgMeisai)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMENT0002"
        Me.Text = ""
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.dbgMeisai, 0)
        Me.Controls.SetChildIndex(Me.TitleBar, 0)
        Me.Controls.SetChildIndex(Me.FunctionKey, 0)
        Me.Controls.SetChildIndex(Me.Label18, 0)
        Me.Controls.SetChildIndex(Me.txtKamokuHinmoku, 0)
        Me.Controls.SetChildIndex(Me.btnNew, 0)
        Me.Controls.SetChildIndex(Me.cmbJyouiCode, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.btnSearch, 0)
        Me.Controls.SetChildIndex(Me.lblInput, 0)
        Me.Controls.SetChildIndex(Me.Label15, 0)
        Me.Controls.SetChildIndex(Me.lblJyouiKamokuHinmoku, 0)
        Me.Controls.SetChildIndex(Me.dbgInput, 0)
        Me.Controls.SetChildIndex(Me.Panel2, 0)
        Me.Controls.SetChildIndex(Me.lblMessage1, 0)
        CType(Me.dbgMeisai, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dbgInput, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dbgMeisai As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents Label18 As Label
    Friend WithEvents txtKamokuHinmoku As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents Label15 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btnSearch As Button
    Friend WithEvents lblInput As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbJyouiCode As CommonUtility.WinFormControls.TypComboBox
    Friend WithEvents lblJyouiKamokuHinmoku As CommonUtility.WinFormControls.TextBoxEx
    Protected WithEvents dbgInput As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents Panel1 As Panel
    Friend WithEvents rdoDKAMOKU As RadioButton
    Friend WithEvents rdoCKAMOKU As RadioButton
    Friend WithEvents rdoSKAMOKU As RadioButton
    Friend WithEvents Panel2 As Panel
    Friend WithEvents rdoSKAMOKU_NEW As RadioButton
    Friend WithEvents rdoDKAMOKU_NEW As RadioButton
    Friend WithEvents lblJyouiKamokuHinmokuNew As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents rdoCKAMOKU_NEW As RadioButton
    Friend WithEvents Label6 As Label
    Friend WithEvents btnNew As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents cmbJyouiCodeNew As CommonUtility.WinFormControls.TypComboBox
    Friend WithEvents rdoALL As RadioButton
    Friend WithEvents lblMessage1 As Label
End Class
