<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmBUK0002
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBUK0002))
        Me.Label8 = New System.Windows.Forms.Label()
        Me.fraKeyInput = New System.Windows.Forms.Panel()
        Me.txtBukkenNo2 = New CommonUtility.WinFormControls.TextBoxEx()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.rdoSyoninHatSumi = New System.Windows.Forms.RadioButton()
        Me.rdoSyoninHatAll = New System.Windows.Forms.RadioButton()
        Me.rdoSyoninHatMi = New System.Windows.Forms.RadioButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.rdoSyoninJyuSumi = New System.Windows.Forms.RadioButton()
        Me.rdoSyoninJyuAll = New System.Windows.Forms.RadioButton()
        Me.rdoSyoninJyuMi = New System.Windows.Forms.RadioButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.rdoList = New System.Windows.Forms.RadioButton()
        Me.rdoMap = New System.Windows.Forms.RadioButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmdKMENU = New CommonUtility.WinFormControls.KobetuSentakuButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtChakkouDateED = New CommonUtility.WinFormControls.TextBoxEx()
        Me.txtChakkouDateST = New CommonUtility.WinFormControls.TextBoxEx()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.lblHyojiKbn = New System.Windows.Forms.Label()
        Me.txtJyotai = New CommonUtility.WinFormControls.TextBoxEx()
        Me.txtMotoukeName = New CommonUtility.WinFormControls.TextBoxEx()
        Me.cmbJyotai = New CommonUtility.WinFormControls.TypComboBox()
        Me.cmbMotoukeCode = New CommonUtility.WinFormControls.TypComboBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtKoujiBasyo = New CommonUtility.WinFormControls.TextBoxEx()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtBukkenName = New CommonUtility.WinFormControls.TextBoxEx()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cmdTMENU = New CommonUtility.WinFormControls.KobetuSentakuButton()
        Me.txtTanatoName = New CommonUtility.WinFormControls.TextBoxEx()
        Me.cmbTanatoCode = New CommonUtility.WinFormControls.TypComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dbgMEISAI = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.fraKeyInput.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dbgMEISAI, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.DarkSlateBlue
        Me.Label8.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.Window
        Me.Label8.Location = New System.Drawing.Point(0, 54)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(1018, 18)
        Me.Label8.TabIndex = 41
        Me.Label8.Text = "抽出条件"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'fraKeyInput
        '
        Me.fraKeyInput.BackColor = System.Drawing.Color.Thistle
        Me.fraKeyInput.Controls.Add(Me.txtBukkenNo2)
        Me.fraKeyInput.Controls.Add(Me.Label6)
        Me.fraKeyInput.Controls.Add(Me.Panel3)
        Me.fraKeyInput.Controls.Add(Me.Panel2)
        Me.fraKeyInput.Controls.Add(Me.Panel1)
        Me.fraKeyInput.Controls.Add(Me.Label3)
        Me.fraKeyInput.Controls.Add(Me.Label5)
        Me.fraKeyInput.Controls.Add(Me.cmdKMENU)
        Me.fraKeyInput.Controls.Add(Me.Label2)
        Me.fraKeyInput.Controls.Add(Me.txtChakkouDateED)
        Me.fraKeyInput.Controls.Add(Me.txtChakkouDateST)
        Me.fraKeyInput.Controls.Add(Me.Label4)
        Me.fraKeyInput.Controls.Add(Me.Label23)
        Me.fraKeyInput.Controls.Add(Me.lblHyojiKbn)
        Me.fraKeyInput.Controls.Add(Me.txtJyotai)
        Me.fraKeyInput.Controls.Add(Me.txtMotoukeName)
        Me.fraKeyInput.Controls.Add(Me.cmbJyotai)
        Me.fraKeyInput.Controls.Add(Me.cmbMotoukeCode)
        Me.fraKeyInput.Controls.Add(Me.Label21)
        Me.fraKeyInput.Controls.Add(Me.Label20)
        Me.fraKeyInput.Controls.Add(Me.txtKoujiBasyo)
        Me.fraKeyInput.Controls.Add(Me.Label19)
        Me.fraKeyInput.Controls.Add(Me.txtBukkenName)
        Me.fraKeyInput.Controls.Add(Me.Label18)
        Me.fraKeyInput.Controls.Add(Me.cmdTMENU)
        Me.fraKeyInput.Controls.Add(Me.txtTanatoName)
        Me.fraKeyInput.Controls.Add(Me.cmbTanatoCode)
        Me.fraKeyInput.Controls.Add(Me.Label1)
        Me.fraKeyInput.Location = New System.Drawing.Point(0, 54)
        Me.fraKeyInput.Name = "fraKeyInput"
        Me.fraKeyInput.Size = New System.Drawing.Size(1018, 149)
        Me.fraKeyInput.TabIndex = 42
        '
        'txtBukkenNo2
        '
        Me.txtBukkenNo2.BackColor = System.Drawing.Color.White
        Me.txtBukkenNo2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtBukkenNo2.DigitOnly = True
        Me.txtBukkenNo2.DisplayName = "物件No"
        Me.txtBukkenNo2.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtBukkenNo2.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtBukkenNo2.Location = New System.Drawing.Point(97, 29)
        Me.txtBukkenNo2.MaxLength = 10
        Me.txtBukkenNo2.Name = "txtBukkenNo2"
        Me.txtBukkenNo2.Size = New System.Drawing.Size(78, 17)
        Me.txtBukkenNo2.TabIndex = 70
        Me.txtBukkenNo2.Text = "9999999999"
        Me.txtBukkenNo2.UseZeroPadding = True
        Me.txtBukkenNo2.ZeroPaddingLength = 10
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.Location = New System.Drawing.Point(13, 29)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(45, 17)
        Me.Label6.TabIndex = 69
        Me.Label6.Text = "物件No"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.rdoSyoninHatSumi)
        Me.Panel3.Controls.Add(Me.rdoSyoninHatAll)
        Me.Panel3.Controls.Add(Me.rdoSyoninHatMi)
        Me.Panel3.Location = New System.Drawing.Point(97, 122)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(179, 21)
        Me.Panel3.TabIndex = 5
        '
        'rdoSyoninHatSumi
        '
        Me.rdoSyoninHatSumi.AutoSize = True
        Me.rdoSyoninHatSumi.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.rdoSyoninHatSumi.Location = New System.Drawing.Point(97, 0)
        Me.rdoSyoninHatSumi.Name = "rdoSyoninHatSumi"
        Me.rdoSyoninHatSumi.Size = New System.Drawing.Size(37, 21)
        Me.rdoSyoninHatSumi.TabIndex = 3
        Me.rdoSyoninHatSumi.TabStop = True
        Me.rdoSyoninHatSumi.Text = "済"
        Me.rdoSyoninHatSumi.UseVisualStyleBackColor = True
        '
        'rdoSyoninHatAll
        '
        Me.rdoSyoninHatAll.AutoSize = True
        Me.rdoSyoninHatAll.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.rdoSyoninHatAll.Location = New System.Drawing.Point(0, 0)
        Me.rdoSyoninHatAll.Name = "rdoSyoninHatAll"
        Me.rdoSyoninHatAll.Size = New System.Drawing.Size(48, 21)
        Me.rdoSyoninHatAll.TabIndex = 1
        Me.rdoSyoninHatAll.TabStop = True
        Me.rdoSyoninHatAll.Text = "全て"
        Me.rdoSyoninHatAll.UseVisualStyleBackColor = True
        '
        'rdoSyoninHatMi
        '
        Me.rdoSyoninHatMi.AutoSize = True
        Me.rdoSyoninHatMi.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.rdoSyoninHatMi.Location = New System.Drawing.Point(54, 0)
        Me.rdoSyoninHatMi.Name = "rdoSyoninHatMi"
        Me.rdoSyoninHatMi.Size = New System.Drawing.Size(37, 21)
        Me.rdoSyoninHatMi.TabIndex = 2
        Me.rdoSyoninHatMi.TabStop = True
        Me.rdoSyoninHatMi.Text = "未"
        Me.rdoSyoninHatMi.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.rdoSyoninJyuSumi)
        Me.Panel2.Controls.Add(Me.rdoSyoninJyuAll)
        Me.Panel2.Controls.Add(Me.rdoSyoninJyuMi)
        Me.Panel2.Location = New System.Drawing.Point(97, 99)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(179, 21)
        Me.Panel2.TabIndex = 4
        '
        'rdoSyoninJyuSumi
        '
        Me.rdoSyoninJyuSumi.AutoSize = True
        Me.rdoSyoninJyuSumi.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.rdoSyoninJyuSumi.Location = New System.Drawing.Point(97, -1)
        Me.rdoSyoninJyuSumi.Name = "rdoSyoninJyuSumi"
        Me.rdoSyoninJyuSumi.Size = New System.Drawing.Size(37, 21)
        Me.rdoSyoninJyuSumi.TabIndex = 3
        Me.rdoSyoninJyuSumi.TabStop = True
        Me.rdoSyoninJyuSumi.Text = "済"
        Me.rdoSyoninJyuSumi.UseVisualStyleBackColor = True
        '
        'rdoSyoninJyuAll
        '
        Me.rdoSyoninJyuAll.AutoSize = True
        Me.rdoSyoninJyuAll.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.rdoSyoninJyuAll.Location = New System.Drawing.Point(0, 0)
        Me.rdoSyoninJyuAll.Name = "rdoSyoninJyuAll"
        Me.rdoSyoninJyuAll.Size = New System.Drawing.Size(48, 21)
        Me.rdoSyoninJyuAll.TabIndex = 1
        Me.rdoSyoninJyuAll.TabStop = True
        Me.rdoSyoninJyuAll.Text = "全て"
        Me.rdoSyoninJyuAll.UseVisualStyleBackColor = True
        '
        'rdoSyoninJyuMi
        '
        Me.rdoSyoninJyuMi.AutoSize = True
        Me.rdoSyoninJyuMi.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.rdoSyoninJyuMi.Location = New System.Drawing.Point(54, 0)
        Me.rdoSyoninJyuMi.Name = "rdoSyoninJyuMi"
        Me.rdoSyoninJyuMi.Size = New System.Drawing.Size(37, 21)
        Me.rdoSyoninJyuMi.TabIndex = 2
        Me.rdoSyoninJyuMi.TabStop = True
        Me.rdoSyoninJyuMi.Text = "未"
        Me.rdoSyoninJyuMi.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.rdoList)
        Me.Panel1.Controls.Add(Me.rdoMap)
        Me.Panel1.Location = New System.Drawing.Point(97, 49)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(179, 21)
        Me.Panel1.TabIndex = 1
        '
        'rdoList
        '
        Me.rdoList.AutoSize = True
        Me.rdoList.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.rdoList.Location = New System.Drawing.Point(0, 0)
        Me.rdoList.Name = "rdoList"
        Me.rdoList.Size = New System.Drawing.Size(48, 21)
        Me.rdoList.TabIndex = 1
        Me.rdoList.TabStop = True
        Me.rdoList.Text = "一覧"
        Me.rdoList.UseVisualStyleBackColor = True
        '
        'rdoMap
        '
        Me.rdoMap.AutoSize = True
        Me.rdoMap.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.rdoMap.Location = New System.Drawing.Point(54, 0)
        Me.rdoMap.Name = "rdoMap"
        Me.rdoMap.Size = New System.Drawing.Size(48, 21)
        Me.rdoMap.TabIndex = 2
        Me.rdoMap.TabStop = True
        Me.rdoMap.Text = "地図"
        Me.rdoMap.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 76)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(30, 17)
        Me.Label3.TabIndex = 66
        Me.Label3.Text = "状態"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(13, 127)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 17)
        Me.Label5.TabIndex = 68
        Me.Label5.Text = "発注承認"
        '
        'cmdKMENU
        '
        Me.cmdKMENU.BackColor = System.Drawing.Color.Transparent
        Me.cmdKMENU.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdKMENU.Location = New System.Drawing.Point(726, 73)
        Me.cmdKMENU.Name = "cmdKMENU"
        Me.cmdKMENU.Size = New System.Drawing.Size(60, 22)
        Me.cmdKMENU.TabIndex = 65
        Me.cmdKMENU.TabStop = False
        Me.cmdKMENU.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(454, 123)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(19, 17)
        Me.Label2.TabIndex = 64
        Me.Label2.Text = "～"
        '
        'txtChakkouDateED
        '
        Me.txtChakkouDateED.BackColor = System.Drawing.Color.White
        Me.txtChakkouDateED.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtChakkouDateED.DigitOnly = True
        Me.txtChakkouDateED.DisplayName = "着工日"
        Me.txtChakkouDateED.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtChakkouDateED.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtChakkouDateED.Location = New System.Drawing.Point(479, 123)
        Me.txtChakkouDateED.MaxLength = 4
        Me.txtChakkouDateED.Name = "txtChakkouDateED"
        Me.txtChakkouDateED.Size = New System.Drawing.Size(46, 17)
        Me.txtChakkouDateED.TabIndex = 11
        Me.txtChakkouDateED.Text = "1234"
        '
        'txtChakkouDateST
        '
        Me.txtChakkouDateST.BackColor = System.Drawing.Color.White
        Me.txtChakkouDateST.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtChakkouDateST.DigitOnly = True
        Me.txtChakkouDateST.DisplayName = "着工日"
        Me.txtChakkouDateST.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtChakkouDateST.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtChakkouDateST.Location = New System.Drawing.Point(402, 123)
        Me.txtChakkouDateST.MaxLength = 4
        Me.txtChakkouDateST.Name = "txtChakkouDateST"
        Me.txtChakkouDateST.Size = New System.Drawing.Size(46, 17)
        Me.txtChakkouDateST.TabIndex = 10
        Me.txtChakkouDateST.Text = "1234"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 101)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 17)
        Me.Label4.TabIndex = 67
        Me.Label4.Text = "受注承認"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label23.Location = New System.Drawing.Point(317, 123)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(74, 17)
        Me.Label23.TabIndex = 61
        Me.Label23.Text = "着工日（年）"
        '
        'lblHyojiKbn
        '
        Me.lblHyojiKbn.AutoSize = True
        Me.lblHyojiKbn.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblHyojiKbn.Location = New System.Drawing.Point(12, 52)
        Me.lblHyojiKbn.Name = "lblHyojiKbn"
        Me.lblHyojiKbn.Size = New System.Drawing.Size(52, 17)
        Me.lblHyojiKbn.TabIndex = 58
        Me.lblHyojiKbn.Text = "表示区分"
        '
        'txtJyotai
        '
        Me.txtJyotai.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.txtJyotai.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtJyotai.DisplayName = "担当者名称"
        Me.txtJyotai.Enabled = False
        Me.txtJyotai.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtJyotai.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtJyotai.Location = New System.Drawing.Point(147, 76)
        Me.txtJyotai.MaxLength = 40
        Me.txtJyotai.Name = "txtJyotai"
        Me.txtJyotai.ReadOnly = True
        Me.txtJyotai.Size = New System.Drawing.Size(38, 17)
        Me.txtJyotai.TabIndex = 57
        Me.txtJyotai.Text = "受注"
        '
        'txtMotoukeName
        '
        Me.txtMotoukeName.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.txtMotoukeName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtMotoukeName.DisplayName = "担当者名称"
        Me.txtMotoukeName.Enabled = False
        Me.txtMotoukeName.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtMotoukeName.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtMotoukeName.Location = New System.Drawing.Point(490, 76)
        Me.txtMotoukeName.MaxLength = 40
        Me.txtMotoukeName.Name = "txtMotoukeName"
        Me.txtMotoukeName.ReadOnly = True
        Me.txtMotoukeName.Size = New System.Drawing.Size(230, 17)
        Me.txtMotoukeName.TabIndex = 57
        Me.txtMotoukeName.Text = "１２３４５６７８９０１２３４５６７８９０"
        '
        'cmbJyotai
        '
        Me.cmbJyotai.AutoValidate = System.Windows.Forms.AutoValidate.Disable
        Me.cmbJyotai.DisplayName = "状態"
        Me.cmbJyotai.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbJyotai.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.cmbJyotai.LinkedTextBox = Me.txtJyotai
        Me.cmbJyotai.Location = New System.Drawing.Point(97, 75)
        Me.cmbJyotai.MaxLength = 1
        Me.cmbJyotai.Name = "cmbJyotai"
        Me.cmbJyotai.Size = New System.Drawing.Size(42, 18)
        Me.cmbJyotai.TabIndex = 3
        Me.cmbJyotai.UseMasterCheckValidator = True
        Me.cmbJyotai.UseUpdateLinkedTextByCodeChange = True
        '
        'cmbMotoukeCode
        '
        Me.cmbMotoukeCode.AutoValidate = System.Windows.Forms.AutoValidate.Disable
        Me.cmbMotoukeCode.DisplayName = "元請"
        Me.cmbMotoukeCode.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbMotoukeCode.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.cmbMotoukeCode.LinkedTextBox = Me.txtMotoukeName
        Me.cmbMotoukeCode.Location = New System.Drawing.Point(402, 77)
        Me.cmbMotoukeCode.MaxLength = 8
        Me.cmbMotoukeCode.Name = "cmbMotoukeCode"
        Me.cmbMotoukeCode.Size = New System.Drawing.Size(82, 18)
        Me.cmbMotoukeCode.TabIndex = 8
        Me.cmbMotoukeCode.UseMasterCheckValidator = True
        Me.cmbMotoukeCode.UseUpdateLinkedTextByCodeChange = True
        Me.cmbMotoukeCode.UseZeroPadding = True
        Me.cmbMotoukeCode.ZeroPaddingLength = 8
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label21.Location = New System.Drawing.Point(318, 77)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(30, 17)
        Me.Label21.TabIndex = 56
        Me.Label21.Text = "元請"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label20.Location = New System.Drawing.Point(831, 52)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(162, 17)
        Me.Label20.TabIndex = 54
        Me.Label20.Text = "※スペース区切りで複数指定可"
        '
        'txtKoujiBasyo
        '
        Me.txtKoujiBasyo.BackColor = System.Drawing.Color.White
        Me.txtKoujiBasyo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtKoujiBasyo.DisplayName = "工事場所"
        Me.txtKoujiBasyo.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtKoujiBasyo.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtKoujiBasyo.Location = New System.Drawing.Point(403, 52)
        Me.txtKoujiBasyo.MaxLength = 100
        Me.txtKoujiBasyo.Name = "txtKoujiBasyo"
        Me.txtKoujiBasyo.Size = New System.Drawing.Size(422, 17)
        Me.txtKoujiBasyo.TabIndex = 7
        Me.txtKoujiBasyo.Text = "１２３４５６７８９０１２３４５６７８９０１２３４５６７８９０"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label19.Location = New System.Drawing.Point(318, 52)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(52, 17)
        Me.Label19.TabIndex = 53
        Me.Label19.Text = "工事場所"
        '
        'txtBukkenName
        '
        Me.txtBukkenName.BackColor = System.Drawing.Color.White
        Me.txtBukkenName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtBukkenName.DisplayName = "物件名"
        Me.txtBukkenName.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtBukkenName.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtBukkenName.Location = New System.Drawing.Point(403, 29)
        Me.txtBukkenName.MaxLength = 100
        Me.txtBukkenName.Name = "txtBukkenName"
        Me.txtBukkenName.Size = New System.Drawing.Size(422, 17)
        Me.txtBukkenName.TabIndex = 6
        Me.txtBukkenName.Text = "１２３４５６７８９０１２３４５６７８９０１２３４５６７８９０"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label18.Location = New System.Drawing.Point(318, 29)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(41, 17)
        Me.Label18.TabIndex = 51
        Me.Label18.Text = "物件名"
        '
        'cmdTMENU
        '
        Me.cmdTMENU.BackColor = System.Drawing.Color.Transparent
        Me.cmdTMENU.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdTMENU.Location = New System.Drawing.Point(726, 96)
        Me.cmdTMENU.Name = "cmdTMENU"
        Me.cmdTMENU.Size = New System.Drawing.Size(60, 22)
        Me.cmdTMENU.TabIndex = 10
        Me.cmdTMENU.TabStop = False
        Me.cmdTMENU.UseVisualStyleBackColor = False
        '
        'txtTanatoName
        '
        Me.txtTanatoName.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.txtTanatoName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTanatoName.DisplayName = "担当者名称"
        Me.txtTanatoName.Enabled = False
        Me.txtTanatoName.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtTanatoName.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtTanatoName.Location = New System.Drawing.Point(490, 99)
        Me.txtTanatoName.MaxLength = 40
        Me.txtTanatoName.Name = "txtTanatoName"
        Me.txtTanatoName.ReadOnly = True
        Me.txtTanatoName.Size = New System.Drawing.Size(230, 17)
        Me.txtTanatoName.TabIndex = 9
        Me.txtTanatoName.Text = "１２３４５６７８９０１２３４５６７８９０"
        '
        'cmbTanatoCode
        '
        Me.cmbTanatoCode.AutoValidate = System.Windows.Forms.AutoValidate.Disable
        Me.cmbTanatoCode.DisplayName = "担当者"
        Me.cmbTanatoCode.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbTanatoCode.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.cmbTanatoCode.LinkedTextBox = Me.txtTanatoName
        Me.cmbTanatoCode.Location = New System.Drawing.Point(402, 100)
        Me.cmbTanatoCode.MaxLength = 4
        Me.cmbTanatoCode.Name = "cmbTanatoCode"
        Me.cmbTanatoCode.Size = New System.Drawing.Size(82, 18)
        Me.cmbTanatoCode.TabIndex = 9
        Me.cmbTanatoCode.UseMasterCheckValidator = True
        Me.cmbTanatoCode.UseUpdateLinkedTextByCodeChange = True
        Me.cmbTanatoCode.UseZeroPadding = True
        Me.cmbTanatoCode.ZeroPaddingLength = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(318, 100)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 17)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "担当者"
        '
        'dbgMEISAI
        '
        Me.dbgMEISAI.AllowUpdate = False
        Me.dbgMEISAI.BackColor = System.Drawing.Color.Thistle
        Me.dbgMEISAI.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.dbgMEISAI.CaptionHeight = 16
        Me.dbgMEISAI.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.MultipleLines
        Me.dbgMEISAI.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.dbgMEISAI.GroupByCaption = "列でグループ化するには、ここに列ヘッダをドラッグします。"
        Me.dbgMEISAI.Images.Add(CType(resources.GetObject("dbgMEISAI.Images"), System.Drawing.Image))
        Me.dbgMEISAI.Location = New System.Drawing.Point(0, 209)
        Me.dbgMEISAI.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow
        Me.dbgMEISAI.Name = "dbgMEISAI"
        Me.dbgMEISAI.PreviewInfo.Caption = "印刷プレビューウィンドウ"
        Me.dbgMEISAI.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.dbgMEISAI.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.dbgMEISAI.PreviewInfo.ZoomFactor = 75.0R
        Me.dbgMEISAI.PrintInfo.PageSettings = CType(resources.GetObject("dbgMEISAI.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.dbgMEISAI.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.dbgMEISAI.RowDivider.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.None
        Me.dbgMEISAI.RowHeight = 14
        Me.dbgMEISAI.Size = New System.Drawing.Size(1018, 391)
        Me.dbgMEISAI.TabIndex = 43
        Me.dbgMEISAI.TabStop = False
        Me.dbgMEISAI.UseCompatibleTextRendering = False
        Me.dbgMEISAI.PropBag = resources.GetString("dbgMEISAI.PropBag")
        '
        'frmBUK0002
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 670)
        Me.Controls.Add(Me.dbgMEISAI)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.fraKeyInput)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmBUK0002"
        Me.Text = ""
        Me.Controls.SetChildIndex(Me.fraKeyInput, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.dbgMEISAI, 0)
        Me.Controls.SetChildIndex(Me.TitleBar, 0)
        Me.Controls.SetChildIndex(Me.FunctionKey, 0)
        Me.fraKeyInput.ResumeLayout(False)
        Me.fraKeyInput.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dbgMEISAI, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label8 As Label
    Friend WithEvents fraKeyInput As Panel
    Friend WithEvents cmdTMENU As CommonUtility.WinFormControls.KobetuSentakuButton
    Friend WithEvents txtTanatoName As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents cmbTanatoCode As CommonUtility.WinFormControls.TypComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtMotoukeName As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents cmbMotoukeCode As CommonUtility.WinFormControls.TypComboBox
    Friend WithEvents Label21 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents txtKoujiBasyo As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents Label19 As Label
    Friend WithEvents txtBukkenName As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents Label18 As Label
    Friend WithEvents txtChakkouDateST As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents Label23 As Label
    Friend WithEvents rdoMap As RadioButton
    Friend WithEvents rdoList As RadioButton
    Friend WithEvents lblHyojiKbn As Label
    Protected WithEvents dbgMEISAI As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents Label2 As Label
    Friend WithEvents txtChakkouDateED As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents cmdKMENU As CommonUtility.WinFormControls.KobetuSentakuButton
    Friend WithEvents Label3 As Label
    Friend WithEvents txtJyotai As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents cmbJyotai As CommonUtility.WinFormControls.TypComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents rdoSyoninHatSumi As RadioButton
    Friend WithEvents rdoSyoninHatAll As RadioButton
    Friend WithEvents rdoSyoninHatMi As RadioButton
    Friend WithEvents Panel2 As Panel
    Friend WithEvents rdoSyoninJyuSumi As RadioButton
    Friend WithEvents rdoSyoninJyuAll As RadioButton
    Friend WithEvents rdoSyoninJyuMi As RadioButton
    Friend WithEvents txtBukkenNo2 As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents Label6 As Label
End Class
