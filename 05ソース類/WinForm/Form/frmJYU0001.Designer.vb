<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmJYU0001
    Inherits WinFormBase.FormBase

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmJYU0001))
        Me.trvWorkInfo = New System.Windows.Forms.TreeView()
        Me.fraKeyInput = New System.Windows.Forms.Panel()
        Me.pnlJyutyuNo = New System.Windows.Forms.Panel()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblJYUTYUNO = New CommonUtility.WinFormControls.TextBoxEx()
        Me.txtJYUTYUEDABAN = New CommonUtility.WinFormControls.TextBoxEx()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbJYUTYUNO = New CommonUtility.WinFormControls.MitumoriNoComboBox()
        Me.txtJYUTYUNO = New CommonUtility.WinFormControls.TextBoxEx()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtKokyakuCode = New CommonUtility.WinFormControls.TextBoxEx()
        Me.txtJIKKOYOSAN = New CommonUtility.WinFormControls.NumberTextBoxEx()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.txtMITUMORIEDABAN = New CommonUtility.WinFormControls.TextBoxEx()
        Me.lblMITUMORINO = New CommonUtility.WinFormControls.TextBoxEx()
        Me.txtMITUMORINO = New CommonUtility.WinFormControls.TextBoxEx()
        Me.cmbMITUMORINO = New CommonUtility.WinFormControls.MitumoriNoComboBox()
        Me.txtKEISYOUNAME = New CommonUtility.WinFormControls.TextBoxEx()
        Me.txtKokyakuName = New CommonUtility.WinFormControls.TextBoxEx()
        Me.lblNOUKIGengo1 = New System.Windows.Forms.Label()
        Me.lblNOUKIGengo0 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtNOUKIDATE1 = New CommonUtility.WinFormControls.DateTextBoxEx()
        Me.txtNOUKIDATE0 = New CommonUtility.WinFormControls.DateTextBoxEx()
        Me.txtTantoName = New CommonUtility.WinFormControls.TextBoxEx()
        Me.lblJYUTYUGengo = New System.Windows.Forms.Label()
        Me.txtJYUTYUDATE = New CommonUtility.WinFormControls.DateTextBoxEx()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.cmbKEISYOUCODE = New CommonUtility.WinFormControls.TypComboBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtKoujiNo = New CommonUtility.WinFormControls.TextBoxEx()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtKoujiName = New CommonUtility.WinFormControls.TextBoxEx()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.cmbTantoCode = New CommonUtility.WinFormControls.TypComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.txtAITE_ORDERNO = New CommonUtility.WinFormControls.TextBoxEx()
        Me.txtKoujiBasyo = New CommonUtility.WinFormControls.TextBoxEx()
        Me.fraMeisaikei = New System.Windows.Forms.Panel()
        Me.txtMKARARIRITU = New CommonUtility.WinFormControls.TextBoxEx()
        Me.txtMKGENKAGAKU = New CommonUtility.WinFormControls.NumberTextBoxEx()
        Me.txtMKGAKU_NUKI = New CommonUtility.WinFormControls.NumberTextBoxEx()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.fraSogokei = New System.Windows.Forms.Panel()
        Me.txtGKARARIRITU = New CommonUtility.WinFormControls.TextBoxEx()
        Me.txtGKGENKAGAKU = New CommonUtility.WinFormControls.NumberTextBoxEx()
        Me.txtGKGAKU_NUKI = New CommonUtility.WinFormControls.NumberTextBoxEx()
        Me.txtGKGAKU = New CommonUtility.WinFormControls.NumberTextBoxEx()
        Me.lblGKJYUTYUGAKU = New System.Windows.Forms.Label()
        Me.txtGKTAX = New CommonUtility.WinFormControls.NumberTextBoxEx()
        Me.lblGKTAX = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.fraKoujiUchiwake = New System.Windows.Forms.GroupBox()
        Me.tabDetail = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.dbgMEISAI = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtD_BIKO = New CommonUtility.WinFormControls.TextBoxEx()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.trvWorkInfo_Reference = New System.Windows.Forms.TreeView()
        Me.lblSYORISTDATE = New System.Windows.Forms.Label()
        Me.lblSyosu = New System.Windows.Forms.Label()
        Me.lblSyosuName = New System.Windows.Forms.Button()
        Me.txtAPPROVALKBN = New CommonUtility.WinFormControls.TextBoxEx()
        Me.fraKeyInput.SuspendLayout()
        Me.pnlJyutyuNo.SuspendLayout()
        Me.fraMeisaikei.SuspendLayout()
        Me.fraSogokei.SuspendLayout()
        Me.tabDetail.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dbgMEISAI, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage4.SuspendLayout()
        Me.TabPage2.SuspendLayout()
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
        Me.FunctionKey.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FunctionKey.Location = New System.Drawing.Point(0, 606)
        '
        'trvWorkInfo
        '
        Me.trvWorkInfo.BackColor = System.Drawing.Color.Thistle
        Me.trvWorkInfo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.trvWorkInfo.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.trvWorkInfo.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.trvWorkInfo.Location = New System.Drawing.Point(6, 200)
        Me.trvWorkInfo.Name = "trvWorkInfo"
        Me.trvWorkInfo.Size = New System.Drawing.Size(198, 394)
        Me.trvWorkInfo.TabIndex = 22
        Me.trvWorkInfo.TabStop = False
        '
        'fraKeyInput
        '
        Me.fraKeyInput.BackColor = System.Drawing.Color.Thistle
        Me.fraKeyInput.Controls.Add(Me.pnlJyutyuNo)
        Me.fraKeyInput.Controls.Add(Me.Label13)
        Me.fraKeyInput.Controls.Add(Me.txtKokyakuCode)
        Me.fraKeyInput.Controls.Add(Me.txtJIKKOYOSAN)
        Me.fraKeyInput.Controls.Add(Me.Label7)
        Me.fraKeyInput.Controls.Add(Me.Label33)
        Me.fraKeyInput.Controls.Add(Me.txtMITUMORIEDABAN)
        Me.fraKeyInput.Controls.Add(Me.lblMITUMORINO)
        Me.fraKeyInput.Controls.Add(Me.txtMITUMORINO)
        Me.fraKeyInput.Controls.Add(Me.cmbMITUMORINO)
        Me.fraKeyInput.Controls.Add(Me.txtKEISYOUNAME)
        Me.fraKeyInput.Controls.Add(Me.txtKokyakuName)
        Me.fraKeyInput.Controls.Add(Me.lblNOUKIGengo1)
        Me.fraKeyInput.Controls.Add(Me.lblNOUKIGengo0)
        Me.fraKeyInput.Controls.Add(Me.Label29)
        Me.fraKeyInput.Controls.Add(Me.txtNOUKIDATE1)
        Me.fraKeyInput.Controls.Add(Me.txtNOUKIDATE0)
        Me.fraKeyInput.Controls.Add(Me.txtTantoName)
        Me.fraKeyInput.Controls.Add(Me.lblJYUTYUGengo)
        Me.fraKeyInput.Controls.Add(Me.txtJYUTYUDATE)
        Me.fraKeyInput.Controls.Add(Me.Label28)
        Me.fraKeyInput.Controls.Add(Me.cmbKEISYOUCODE)
        Me.fraKeyInput.Controls.Add(Me.Label26)
        Me.fraKeyInput.Controls.Add(Me.Label25)
        Me.fraKeyInput.Controls.Add(Me.Label24)
        Me.fraKeyInput.Controls.Add(Me.Label23)
        Me.fraKeyInput.Controls.Add(Me.Label22)
        Me.fraKeyInput.Controls.Add(Me.Label21)
        Me.fraKeyInput.Controls.Add(Me.txtKoujiNo)
        Me.fraKeyInput.Controls.Add(Me.Label20)
        Me.fraKeyInput.Controls.Add(Me.txtKoujiName)
        Me.fraKeyInput.Controls.Add(Me.Label19)
        Me.fraKeyInput.Controls.Add(Me.cmbTantoCode)
        Me.fraKeyInput.Controls.Add(Me.Label17)
        Me.fraKeyInput.Controls.Add(Me.Label16)
        Me.fraKeyInput.Controls.Add(Me.Label34)
        Me.fraKeyInput.Controls.Add(Me.txtAITE_ORDERNO)
        Me.fraKeyInput.Controls.Add(Me.txtKoujiBasyo)
        Me.fraKeyInput.Location = New System.Drawing.Point(0, 72)
        Me.fraKeyInput.Name = "fraKeyInput"
        Me.fraKeyInput.Size = New System.Drawing.Size(1018, 106)
        Me.fraKeyInput.TabIndex = 1
        '
        'pnlJyutyuNo
        '
        Me.pnlJyutyuNo.Controls.Add(Me.Label12)
        Me.pnlJyutyuNo.Controls.Add(Me.lblJYUTYUNO)
        Me.pnlJyutyuNo.Controls.Add(Me.txtJYUTYUEDABAN)
        Me.pnlJyutyuNo.Controls.Add(Me.Label2)
        Me.pnlJyutyuNo.Controls.Add(Me.cmbJYUTYUNO)
        Me.pnlJyutyuNo.Controls.Add(Me.txtJYUTYUNO)
        Me.pnlJyutyuNo.Location = New System.Drawing.Point(7, 0)
        Me.pnlJyutyuNo.Name = "pnlJyutyuNo"
        Me.pnlJyutyuNo.Size = New System.Drawing.Size(322, 22)
        Me.pnlJyutyuNo.TabIndex = 1
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.Label12.Location = New System.Drawing.Point(151, 3)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(13, 17)
        Me.Label12.TabIndex = 100
        Me.Label12.Text = "-"
        '
        'lblJYUTYUNO
        '
        Me.lblJYUTYUNO.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.lblJYUTYUNO.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lblJYUTYUNO.DisplayName = "受注Ｎｏ"
        Me.lblJYUTYUNO.Enabled = False
        Me.lblJYUTYUNO.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.lblJYUTYUNO.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.lblJYUTYUNO.Location = New System.Drawing.Point(219, 5)
        Me.lblJYUTYUNO.MaxLength = 10
        Me.lblJYUTYUNO.Name = "lblJYUTYUNO"
        Me.lblJYUTYUNO.ReadOnly = True
        Me.lblJYUTYUNO.Size = New System.Drawing.Size(94, 16)
        Me.lblJYUTYUNO.TabIndex = 98
        Me.lblJYUTYUNO.Text = "1234567890-01"
        Me.lblJYUTYUNO.Visible = False
        '
        'txtJYUTYUEDABAN
        '
        Me.txtJYUTYUEDABAN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtJYUTYUEDABAN.DigitOnly = True
        Me.txtJYUTYUEDABAN.DisplayName = "受注枝番"
        Me.txtJYUTYUEDABAN.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.txtJYUTYUEDABAN.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtJYUTYUEDABAN.Location = New System.Drawing.Point(165, 3)
        Me.txtJYUTYUEDABAN.MaxLength = 2
        Me.txtJYUTYUEDABAN.Name = "txtJYUTYUEDABAN"
        Me.txtJYUTYUEDABAN.Size = New System.Drawing.Size(22, 16)
        Me.txtJYUTYUEDABAN.TabIndex = 1
        Me.txtJYUTYUEDABAN.Text = "1234567890123456789012345678901234567890"
        Me.txtJYUTYUEDABAN.UseZeroPadding = True
        Me.txtJYUTYUEDABAN.ZeroPaddingLength = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.Label2.Location = New System.Drawing.Point(5, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 17)
        Me.Label2.TabIndex = 94
        Me.Label2.Text = "受注Ｎｏ"
        '
        'cmbJYUTYUNO
        '
        Me.cmbJYUTYUNO.DisplayName = "受注Ｎｏ"
        Me.cmbJYUTYUNO.LinkedTextBox = Me.lblJYUTYUNO
        Me.cmbJYUTYUNO.Location = New System.Drawing.Point(193, 3)
        Me.cmbJYUTYUNO.Margin = New System.Windows.Forms.Padding(3, 8, 3, 8)
        Me.cmbJYUTYUNO.MaxLength = 32767
        Me.cmbJYUTYUNO.Name = "cmbJYUTYUNO"
        Me.cmbJYUTYUNO.PopupErrorDialog = False
        Me.cmbJYUTYUNO.Size = New System.Drawing.Size(20, 18)
        Me.cmbJYUTYUNO.TabIndex = 97
        Me.cmbJYUTYUNO.TabStop = False
        Me.cmbJYUTYUNO.UseUpdateLinkedTextByCodeChange = True
        '
        'txtJYUTYUNO
        '
        Me.txtJYUTYUNO.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.txtJYUTYUNO.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtJYUTYUNO.DigitOnly = True
        Me.txtJYUTYUNO.DisplayName = "受注Ｎｏ"
        Me.txtJYUTYUNO.Enabled = False
        Me.txtJYUTYUNO.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.txtJYUTYUNO.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtJYUTYUNO.Location = New System.Drawing.Point(72, 3)
        Me.txtJYUTYUNO.MaxLength = 10
        Me.txtJYUTYUNO.Name = "txtJYUTYUNO"
        Me.txtJYUTYUNO.ReadOnly = True
        Me.txtJYUTYUNO.Size = New System.Drawing.Size(78, 16)
        Me.txtJYUTYUNO.TabIndex = 93
        Me.txtJYUTYUNO.TabStop = False
        Me.txtJYUTYUNO.Text = "1234567890"
        Me.txtJYUTYUNO.UseZeroPadding = True
        Me.txtJYUTYUNO.ZeroPaddingLength = 10
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.Label13.Location = New System.Drawing.Point(157, 3)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(13, 17)
        Me.Label13.TabIndex = 95
        Me.Label13.Text = "-"
        '
        'txtKokyakuCode
        '
        Me.txtKokyakuCode.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.txtKokyakuCode.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtKokyakuCode.DigitOnly = True
        Me.txtKokyakuCode.DisplayName = "親見積Ｎｏ"
        Me.txtKokyakuCode.Enabled = False
        Me.txtKokyakuCode.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.txtKokyakuCode.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtKokyakuCode.Location = New System.Drawing.Point(78, 63)
        Me.txtKokyakuCode.MaxLength = 10
        Me.txtKokyakuCode.Name = "txtKokyakuCode"
        Me.txtKokyakuCode.Size = New System.Drawing.Size(78, 16)
        Me.txtKokyakuCode.TabIndex = 92
        Me.txtKokyakuCode.Text = "1234567890123456789012345678901234567890"
        Me.txtKokyakuCode.UseZeroPadding = True
        Me.txtKokyakuCode.ZeroPaddingLength = 8
        '
        'txtJIKKOYOSAN
        '
        Me.txtJIKKOYOSAN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtJIKKOYOSAN.DisplayName = "実行予算"
        Me.txtJIKKOYOSAN.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtJIKKOYOSAN.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtJIKKOYOSAN.Location = New System.Drawing.Point(728, 84)
        Me.txtJIKKOYOSAN.MaxLength = 12
        Me.txtJIKKOYOSAN.MaxValue = New Decimal(New Integer() {-727379969, 232, 0, 0})
        Me.txtJIKKOYOSAN.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtJIKKOYOSAN.MoveFocusAfterEnter = False
        Me.txtJIKKOYOSAN.Name = "txtJIKKOYOSAN"
        Me.txtJIKKOYOSAN.Size = New System.Drawing.Size(102, 17)
        Me.txtJIKKOYOSAN.TabIndex = 21
        Me.txtJIKKOYOSAN.Text = "999,999,999,999"
        Me.txtJIKKOYOSAN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtJIKKOYOSAN.UseNullValidator = True
        Me.txtJIKKOYOSAN.Value = New Decimal(New Integer() {-727379969, 232, 0, 0})
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.Label7.Location = New System.Drawing.Point(836, 84)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(19, 17)
        Me.Label7.TabIndex = 91
        Me.Label7.Text = "円"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.Label33.Location = New System.Drawing.Point(562, 4)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(13, 17)
        Me.Label33.TabIndex = 90
        Me.Label33.Text = "-"
        '
        'txtMITUMORIEDABAN
        '
        Me.txtMITUMORIEDABAN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtMITUMORIEDABAN.DigitOnly = True
        Me.txtMITUMORIEDABAN.DisplayName = "親見積枝番"
        Me.txtMITUMORIEDABAN.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.txtMITUMORIEDABAN.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtMITUMORIEDABAN.Location = New System.Drawing.Point(576, 4)
        Me.txtMITUMORIEDABAN.MaxLength = 2
        Me.txtMITUMORIEDABAN.Name = "txtMITUMORIEDABAN"
        Me.txtMITUMORIEDABAN.Size = New System.Drawing.Size(22, 16)
        Me.txtMITUMORIEDABAN.TabIndex = 10
        Me.txtMITUMORIEDABAN.Text = "1234567890123456789012345678901234567890"
        Me.txtMITUMORIEDABAN.UseZeroPadding = True
        Me.txtMITUMORIEDABAN.ZeroPaddingLength = 2
        '
        'lblMITUMORINO
        '
        Me.lblMITUMORINO.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.lblMITUMORINO.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lblMITUMORINO.DisplayName = "親見積Ｎｏ"
        Me.lblMITUMORINO.Enabled = False
        Me.lblMITUMORINO.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.lblMITUMORINO.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.lblMITUMORINO.Location = New System.Drawing.Point(625, 4)
        Me.lblMITUMORINO.MaxLength = 10
        Me.lblMITUMORINO.Name = "lblMITUMORINO"
        Me.lblMITUMORINO.ReadOnly = True
        Me.lblMITUMORINO.Size = New System.Drawing.Size(14, 16)
        Me.lblMITUMORINO.TabIndex = 88
        Me.lblMITUMORINO.TabStop = False
        Me.lblMITUMORINO.Text = "1234567890-01"
        Me.lblMITUMORINO.Visible = False
        '
        'txtMITUMORINO
        '
        Me.txtMITUMORINO.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.txtMITUMORINO.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtMITUMORINO.DigitOnly = True
        Me.txtMITUMORINO.DisplayName = "親見積Ｎｏ"
        Me.txtMITUMORINO.Enabled = False
        Me.txtMITUMORINO.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.txtMITUMORINO.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtMITUMORINO.Location = New System.Drawing.Point(484, 4)
        Me.txtMITUMORINO.MaxLength = 10
        Me.txtMITUMORINO.Name = "txtMITUMORINO"
        Me.txtMITUMORINO.Size = New System.Drawing.Size(78, 16)
        Me.txtMITUMORINO.TabIndex = 9
        Me.txtMITUMORINO.Text = "1234567890123456789012345678901234567890"
        Me.txtMITUMORINO.UseZeroPadding = True
        Me.txtMITUMORINO.ZeroPaddingLength = 10
        '
        'cmbMITUMORINO
        '
        Me.cmbMITUMORINO.DisplayName = "親見積Ｎｏ"
        Me.cmbMITUMORINO.LinkedTextBox = Me.lblMITUMORINO
        Me.cmbMITUMORINO.Location = New System.Drawing.Point(602, 4)
        Me.cmbMITUMORINO.Margin = New System.Windows.Forms.Padding(3, 8, 3, 8)
        Me.cmbMITUMORINO.MaxLength = 32767
        Me.cmbMITUMORINO.Name = "cmbMITUMORINO"
        Me.cmbMITUMORINO.PopupErrorDialog = False
        Me.cmbMITUMORINO.Size = New System.Drawing.Size(18, 18)
        Me.cmbMITUMORINO.TabIndex = 10
        Me.cmbMITUMORINO.TabStop = False
        Me.cmbMITUMORINO.UseUpdateLinkedTextByCodeChange = True
        '
        'txtKEISYOUNAME
        '
        Me.txtKEISYOUNAME.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.txtKEISYOUNAME.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtKEISYOUNAME.DisplayName = "敬称名称"
        Me.txtKEISYOUNAME.Enabled = False
        Me.txtKEISYOUNAME.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtKEISYOUNAME.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtKEISYOUNAME.Location = New System.Drawing.Point(535, 26)
        Me.txtKEISYOUNAME.MaxLength = 20
        Me.txtKEISYOUNAME.Name = "txtKEISYOUNAME"
        Me.txtKEISYOUNAME.ReadOnly = True
        Me.txtKEISYOUNAME.Size = New System.Drawing.Size(86, 17)
        Me.txtKEISYOUNAME.TabIndex = 15
        Me.txtKEISYOUNAME.Text = "12345678901234567890"
        '
        'txtKokyakuName
        '
        Me.txtKokyakuName.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.txtKokyakuName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtKokyakuName.DisplayName = "顧客名称"
        Me.txtKokyakuName.Enabled = False
        Me.txtKokyakuName.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtKokyakuName.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtKokyakuName.Location = New System.Drawing.Point(162, 63)
        Me.txtKokyakuName.MaxLength = 40
        Me.txtKokyakuName.Name = "txtKokyakuName"
        Me.txtKokyakuName.ReadOnly = True
        Me.txtKokyakuName.Size = New System.Drawing.Size(230, 17)
        Me.txtKokyakuName.TabIndex = 63
        Me.txtKokyakuName.Text = "１２３４５６７８９０１２３４５６７８９０"
        '
        'lblNOUKIGengo1
        '
        Me.lblNOUKIGengo1.AutoSize = True
        Me.lblNOUKIGengo1.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.lblNOUKIGengo1.Location = New System.Drawing.Point(296, 83)
        Me.lblNOUKIGengo1.Name = "lblNOUKIGengo1"
        Me.lblNOUKIGengo1.Size = New System.Drawing.Size(54, 17)
        Me.lblNOUKIGengo1.TabIndex = 62
        Me.lblNOUKIGengo1.Text = "(平成28)"
        '
        'lblNOUKIGengo0
        '
        Me.lblNOUKIGengo0.AutoSize = True
        Me.lblNOUKIGengo0.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.lblNOUKIGengo0.Location = New System.Drawing.Point(151, 83)
        Me.lblNOUKIGengo0.Name = "lblNOUKIGengo0"
        Me.lblNOUKIGengo0.Size = New System.Drawing.Size(54, 17)
        Me.lblNOUKIGengo0.TabIndex = 61
        Me.lblNOUKIGengo0.Text = "(平成27)"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label29.Location = New System.Drawing.Point(203, 83)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(19, 17)
        Me.Label29.TabIndex = 59
        Me.Label29.Text = "～"
        '
        'txtNOUKIDATE1
        '
        Me.txtNOUKIDATE1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtNOUKIDATE1.DisplayName = "納期"
        Me.txtNOUKIDATE1.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtNOUKIDATE1.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtNOUKIDATE1.LinkedDateTextBox = Nothing
        Me.txtNOUKIDATE1.Location = New System.Drawing.Point(225, 83)
        Me.txtNOUKIDATE1.Mask = "0000/00/00"
        Me.txtNOUKIDATE1.Name = "txtNOUKIDATE1"
        Me.txtNOUKIDATE1.Size = New System.Drawing.Size(70, 17)
        Me.txtNOUKIDATE1.TabIndex = 8
        Me.txtNOUKIDATE1.Text = "20160131"
        Me.txtNOUKIDATE1.ValidatingType = GetType(Date)
        '
        'txtNOUKIDATE0
        '
        Me.txtNOUKIDATE0.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtNOUKIDATE0.DisplayName = "納期"
        Me.txtNOUKIDATE0.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtNOUKIDATE0.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtNOUKIDATE0.LinkedDateTextBox = Nothing
        Me.txtNOUKIDATE0.Location = New System.Drawing.Point(80, 83)
        Me.txtNOUKIDATE0.Mask = "0000/00/00"
        Me.txtNOUKIDATE0.Name = "txtNOUKIDATE0"
        Me.txtNOUKIDATE0.Size = New System.Drawing.Size(70, 17)
        Me.txtNOUKIDATE0.TabIndex = 7
        Me.txtNOUKIDATE0.Text = "20150601"
        Me.txtNOUKIDATE0.ValidatingType = GetType(Date)
        '
        'txtTantoName
        '
        Me.txtTantoName.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.txtTantoName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTantoName.DisplayName = "担当者名称"
        Me.txtTantoName.Enabled = False
        Me.txtTantoName.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtTantoName.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtTantoName.Location = New System.Drawing.Point(162, 43)
        Me.txtTantoName.MaxLength = 40
        Me.txtTantoName.Name = "txtTantoName"
        Me.txtTantoName.ReadOnly = True
        Me.txtTantoName.Size = New System.Drawing.Size(230, 17)
        Me.txtTantoName.TabIndex = 56
        Me.txtTantoName.Text = "１２３４５６７８９０１２３４５６７８９０"
        '
        'lblJYUTYUGengo
        '
        Me.lblJYUTYUGengo.AutoSize = True
        Me.lblJYUTYUGengo.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.lblJYUTYUGengo.Location = New System.Drawing.Point(151, 23)
        Me.lblJYUTYUGengo.Name = "lblJYUTYUGengo"
        Me.lblJYUTYUGengo.Size = New System.Drawing.Size(54, 17)
        Me.lblJYUTYUGengo.TabIndex = 1
        Me.lblJYUTYUGengo.Text = "(平成27)"
        '
        'txtJYUTYUDATE
        '
        Me.txtJYUTYUDATE.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtJYUTYUDATE.DisplayName = "受注日付"
        Me.txtJYUTYUDATE.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtJYUTYUDATE.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtJYUTYUDATE.LinkedDateTextBox = Nothing
        Me.txtJYUTYUDATE.Location = New System.Drawing.Point(79, 23)
        Me.txtJYUTYUDATE.Mask = "0000/00/00"
        Me.txtJYUTYUDATE.Name = "txtJYUTYUDATE"
        Me.txtJYUTYUDATE.Size = New System.Drawing.Size(70, 17)
        Me.txtJYUTYUDATE.TabIndex = 4
        Me.txtJYUTYUDATE.Text = "20150410"
        Me.txtJYUTYUDATE.UseNullValidator = True
        Me.txtJYUTYUDATE.ValidatingType = GetType(Date)
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.Label28.Location = New System.Drawing.Point(400, 26)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(52, 17)
        Me.Label28.TabIndex = 53
        Me.Label28.Text = "敬　称　"
        '
        'cmbKEISYOUCODE
        '
        Me.cmbKEISYOUCODE.AutoValidate = System.Windows.Forms.AutoValidate.Disable
        Me.cmbKEISYOUCODE.DisplayName = "敬称"
        Me.cmbKEISYOUCODE.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.cmbKEISYOUCODE.LinkedTextBox = Me.txtKEISYOUNAME
        Me.cmbKEISYOUCODE.Location = New System.Drawing.Point(484, 26)
        Me.cmbKEISYOUCODE.MaxLength = 4
        Me.cmbKEISYOUCODE.Name = "cmbKEISYOUCODE"
        Me.cmbKEISYOUCODE.Size = New System.Drawing.Size(50, 18)
        Me.cmbKEISYOUCODE.TabIndex = 15
        Me.cmbKEISYOUCODE.UseMasterCheckValidator = True
        Me.cmbKEISYOUCODE.UseNullValidator = True
        Me.cmbKEISYOUCODE.UseUpdateLinkedTextByCodeChange = True
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.Label26.Location = New System.Drawing.Point(400, 3)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(45, 17)
        Me.Label26.TabIndex = 49
        Me.Label26.Text = "見積No"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.Label25.Location = New System.Drawing.Point(650, 84)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(52, 17)
        Me.Label25.TabIndex = 33
        Me.Label25.Text = "実行予算"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.Label24.Location = New System.Drawing.Point(650, 64)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(67, 17)
        Me.Label24.TabIndex = 31
        Me.Label24.Text = "相手注文No"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.Label23.Location = New System.Drawing.Point(11, 84)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(30, 17)
        Me.Label23.TabIndex = 27
        Me.Label23.Text = "工期"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.Label22.Location = New System.Drawing.Point(650, 44)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(52, 17)
        Me.Label22.TabIndex = 26
        Me.Label22.Text = "工事場所"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.Label21.Location = New System.Drawing.Point(650, 24)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(52, 17)
        Me.Label21.TabIndex = 24
        Me.Label21.Text = "工事番号"
        '
        'txtKoujiNo
        '
        Me.txtKoujiNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtKoujiNo.DisplayName = "工事番号"
        Me.txtKoujiNo.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.txtKoujiNo.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtKoujiNo.Location = New System.Drawing.Point(728, 24)
        Me.txtKoujiNo.MaxLength = 20
        Me.txtKoujiNo.Name = "txtKoujiNo"
        Me.txtKoujiNo.Size = New System.Drawing.Size(142, 16)
        Me.txtKoujiNo.TabIndex = 18
        Me.txtKoujiNo.Text = "12345678901234567890"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.Label20.Location = New System.Drawing.Point(650, 4)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(52, 17)
        Me.Label20.TabIndex = 22
        Me.Label20.Text = "工事名称"
        '
        'txtKoujiName
        '
        Me.txtKoujiName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtKoujiName.DisplayName = "工事名称"
        Me.txtKoujiName.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.txtKoujiName.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtKoujiName.Location = New System.Drawing.Point(728, 4)
        Me.txtKoujiName.MaxLength = 40
        Me.txtKoujiName.Name = "txtKoujiName"
        Me.txtKoujiName.Size = New System.Drawing.Size(286, 16)
        Me.txtKoujiName.TabIndex = 17
        Me.txtKoujiName.Text = "1234567890123456789012345678901234567890"
        Me.txtKoujiName.UseNullValidator = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.Label19.Location = New System.Drawing.Point(11, 44)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(49, 17)
        Me.Label19.TabIndex = 20
        Me.Label19.Text = "担 当 者"
        '
        'cmbTantoCode
        '
        Me.cmbTantoCode.AutoValidate = System.Windows.Forms.AutoValidate.Disable
        Me.cmbTantoCode.DisplayName = "担当者コード"
        Me.cmbTantoCode.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.cmbTantoCode.LinkedTextBox = Me.txtTantoName
        Me.cmbTantoCode.Location = New System.Drawing.Point(79, 43)
        Me.cmbTantoCode.MaxLength = 4
        Me.cmbTantoCode.Name = "cmbTantoCode"
        Me.cmbTantoCode.Size = New System.Drawing.Size(82, 18)
        Me.cmbTantoCode.TabIndex = 5
        Me.cmbTantoCode.UseMasterCheckValidator = True
        Me.cmbTantoCode.UseNullValidator = True
        Me.cmbTantoCode.UseUpdateLinkedTextByCodeChange = True
        Me.cmbTantoCode.UseZeroPadding = True
        Me.cmbTantoCode.ZeroPaddingLength = 4
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.Label17.Location = New System.Drawing.Point(11, 24)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(52, 17)
        Me.Label17.TabIndex = 2
        Me.Label17.Text = "受注日付"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.Label16.Location = New System.Drawing.Point(11, 64)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(49, 17)
        Me.Label16.TabIndex = 14
        Me.Label16.Text = "顧 客 名"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label34.Location = New System.Drawing.Point(76, 46)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(75, 18)
        Me.Label34.TabIndex = 41
        Me.Label34.Text = "＿＿_＿＿＿"
        '
        'txtAITE_ORDERNO
        '
        Me.txtAITE_ORDERNO.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtAITE_ORDERNO.DisplayName = "相手注文No"
        Me.txtAITE_ORDERNO.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.txtAITE_ORDERNO.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtAITE_ORDERNO.Location = New System.Drawing.Point(728, 64)
        Me.txtAITE_ORDERNO.MaxLength = 20
        Me.txtAITE_ORDERNO.Name = "txtAITE_ORDERNO"
        Me.txtAITE_ORDERNO.Size = New System.Drawing.Size(142, 16)
        Me.txtAITE_ORDERNO.TabIndex = 20
        Me.txtAITE_ORDERNO.Text = "1234567890123456789012345678901234567890"
        '
        'txtKoujiBasyo
        '
        Me.txtKoujiBasyo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtKoujiBasyo.DisplayName = "工事場所"
        Me.txtKoujiBasyo.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.txtKoujiBasyo.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtKoujiBasyo.Location = New System.Drawing.Point(728, 44)
        Me.txtKoujiBasyo.MaxLength = 40
        Me.txtKoujiBasyo.Name = "txtKoujiBasyo"
        Me.txtKoujiBasyo.Size = New System.Drawing.Size(286, 16)
        Me.txtKoujiBasyo.TabIndex = 19
        Me.txtKoujiBasyo.Text = "1234567890123456789012345678901234567890"
        '
        'fraMeisaikei
        '
        Me.fraMeisaikei.BackColor = System.Drawing.Color.DarkSlateBlue
        Me.fraMeisaikei.Controls.Add(Me.txtMKARARIRITU)
        Me.fraMeisaikei.Controls.Add(Me.txtMKGENKAGAKU)
        Me.fraMeisaikei.Controls.Add(Me.txtMKGAKU_NUKI)
        Me.fraMeisaikei.Controls.Add(Me.Label5)
        Me.fraMeisaikei.Controls.Add(Me.Label4)
        Me.fraMeisaikei.Controls.Add(Me.Label3)
        Me.fraMeisaikei.Location = New System.Drawing.Point(212, 570)
        Me.fraMeisaikei.Name = "fraMeisaikei"
        Me.fraMeisaikei.Size = New System.Drawing.Size(791, 17)
        Me.fraMeisaikei.TabIndex = 11
        '
        'txtMKARARIRITU
        '
        Me.txtMKARARIRITU.BackColor = System.Drawing.Color.DarkSlateBlue
        Me.txtMKARARIRITU.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtMKARARIRITU.DisplayName = "粗利率"
        Me.txtMKARARIRITU.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtMKARARIRITU.ForeColor = System.Drawing.Color.White
        Me.txtMKARARIRITU.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtMKARARIRITU.Location = New System.Drawing.Point(327, 1)
        Me.txtMKARARIRITU.MaxLength = 40
        Me.txtMKARARIRITU.Name = "txtMKARARIRITU"
        Me.txtMKARARIRITU.ReadOnly = True
        Me.txtMKARARIRITU.Size = New System.Drawing.Size(118, 17)
        Me.txtMKARARIRITU.TabIndex = 21
        Me.txtMKARARIRITU.TabStop = False
        Me.txtMKARARIRITU.Text = "（粗利率：999.99％）"
        '
        'txtMKGENKAGAKU
        '
        Me.txtMKGENKAGAKU.BackColor = System.Drawing.Color.DarkSlateBlue
        Me.txtMKGENKAGAKU.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtMKGENKAGAKU.Enabled = False
        Me.txtMKGENKAGAKU.Font = New System.Drawing.Font("メイリオ", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtMKGENKAGAKU.ForeColor = System.Drawing.Color.White
        Me.txtMKGENKAGAKU.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtMKGENKAGAKU.Location = New System.Drawing.Point(107, 1)
        Me.txtMKGENKAGAKU.MaxValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtMKGENKAGAKU.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtMKGENKAGAKU.Name = "txtMKGENKAGAKU"
        Me.txtMKGENKAGAKU.ReadOnly = True
        Me.txtMKGENKAGAKU.Size = New System.Drawing.Size(86, 14)
        Me.txtMKGENKAGAKU.TabIndex = 12
        Me.txtMKGENKAGAKU.TabStop = False
        Me.txtMKGENKAGAKU.Text = "1,100,000,000"
        Me.txtMKGENKAGAKU.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtMKGENKAGAKU.Value = New Decimal(New Integer() {1100000000, 0, 0, 0})
        '
        'txtMKGAKU_NUKI
        '
        Me.txtMKGAKU_NUKI.BackColor = System.Drawing.Color.DarkSlateBlue
        Me.txtMKGAKU_NUKI.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtMKGAKU_NUKI.Enabled = False
        Me.txtMKGAKU_NUKI.Font = New System.Drawing.Font("メイリオ", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtMKGAKU_NUKI.ForeColor = System.Drawing.Color.White
        Me.txtMKGAKU_NUKI.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtMKGAKU_NUKI.Location = New System.Drawing.Point(245, 1)
        Me.txtMKGAKU_NUKI.MaxValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtMKGAKU_NUKI.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtMKGAKU_NUKI.Name = "txtMKGAKU_NUKI"
        Me.txtMKGAKU_NUKI.ReadOnly = True
        Me.txtMKGAKU_NUKI.Size = New System.Drawing.Size(86, 14)
        Me.txtMKGAKU_NUKI.TabIndex = 14
        Me.txtMKGAKU_NUKI.TabStop = False
        Me.txtMKGAKU_NUKI.Text = "1,100,000,000"
        Me.txtMKGAKU_NUKI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtMKGAKU_NUKI.Value = New Decimal(New Integer() {1100000000, 0, 0, 0})
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(192, 1)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 17)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "受注金額："
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(54, 1)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 17)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "原価金額："
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(-5, 1)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 17)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "【明細計】"
        '
        'fraSogokei
        '
        Me.fraSogokei.BackColor = System.Drawing.Color.DarkSlateBlue
        Me.fraSogokei.Controls.Add(Me.txtGKARARIRITU)
        Me.fraSogokei.Controls.Add(Me.txtGKGENKAGAKU)
        Me.fraSogokei.Controls.Add(Me.txtGKGAKU_NUKI)
        Me.fraSogokei.Controls.Add(Me.txtGKGAKU)
        Me.fraSogokei.Controls.Add(Me.lblGKJYUTYUGAKU)
        Me.fraSogokei.Controls.Add(Me.txtGKTAX)
        Me.fraSogokei.Controls.Add(Me.lblGKTAX)
        Me.fraSogokei.Controls.Add(Me.Label8)
        Me.fraSogokei.Controls.Add(Me.Label9)
        Me.fraSogokei.Controls.Add(Me.Label10)
        Me.fraSogokei.Location = New System.Drawing.Point(212, 589)
        Me.fraSogokei.Name = "fraSogokei"
        Me.fraSogokei.Size = New System.Drawing.Size(791, 17)
        Me.fraSogokei.TabIndex = 16
        '
        'txtGKARARIRITU
        '
        Me.txtGKARARIRITU.BackColor = System.Drawing.Color.DarkSlateBlue
        Me.txtGKARARIRITU.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtGKARARIRITU.DisplayName = "粗利率"
        Me.txtGKARARIRITU.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtGKARARIRITU.ForeColor = System.Drawing.Color.White
        Me.txtGKARARIRITU.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtGKARARIRITU.Location = New System.Drawing.Point(327, 1)
        Me.txtGKARARIRITU.MaxLength = 40
        Me.txtGKARARIRITU.Name = "txtGKARARIRITU"
        Me.txtGKARARIRITU.ReadOnly = True
        Me.txtGKARARIRITU.Size = New System.Drawing.Size(222, 17)
        Me.txtGKARARIRITU.TabIndex = 22
        Me.txtGKARARIRITU.TabStop = False
        Me.txtGKARARIRITU.Text = "（粗利率：999.99％　消化率：999.99％）"
        '
        'txtGKGENKAGAKU
        '
        Me.txtGKGENKAGAKU.BackColor = System.Drawing.Color.DarkSlateBlue
        Me.txtGKGENKAGAKU.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtGKGENKAGAKU.Enabled = False
        Me.txtGKGENKAGAKU.Font = New System.Drawing.Font("メイリオ", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtGKGENKAGAKU.ForeColor = System.Drawing.Color.White
        Me.txtGKGENKAGAKU.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtGKGENKAGAKU.Location = New System.Drawing.Point(107, 1)
        Me.txtGKGENKAGAKU.MaxValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtGKGENKAGAKU.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtGKGENKAGAKU.Name = "txtGKGENKAGAKU"
        Me.txtGKGENKAGAKU.ReadOnly = True
        Me.txtGKGENKAGAKU.Size = New System.Drawing.Size(86, 14)
        Me.txtGKGENKAGAKU.TabIndex = 12
        Me.txtGKGENKAGAKU.TabStop = False
        Me.txtGKGENKAGAKU.Text = "1,100,000,000"
        Me.txtGKGENKAGAKU.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtGKGENKAGAKU.Value = New Decimal(New Integer() {1100000000, 0, 0, 0})
        '
        'txtGKGAKU_NUKI
        '
        Me.txtGKGAKU_NUKI.BackColor = System.Drawing.Color.DarkSlateBlue
        Me.txtGKGAKU_NUKI.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtGKGAKU_NUKI.Enabled = False
        Me.txtGKGAKU_NUKI.Font = New System.Drawing.Font("メイリオ", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtGKGAKU_NUKI.ForeColor = System.Drawing.Color.White
        Me.txtGKGAKU_NUKI.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtGKGAKU_NUKI.Location = New System.Drawing.Point(245, 1)
        Me.txtGKGAKU_NUKI.MaxValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtGKGAKU_NUKI.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtGKGAKU_NUKI.Name = "txtGKGAKU_NUKI"
        Me.txtGKGAKU_NUKI.ReadOnly = True
        Me.txtGKGAKU_NUKI.Size = New System.Drawing.Size(86, 14)
        Me.txtGKGAKU_NUKI.TabIndex = 14
        Me.txtGKGAKU_NUKI.TabStop = False
        Me.txtGKGAKU_NUKI.Text = "1,100,000,000"
        Me.txtGKGAKU_NUKI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtGKGAKU_NUKI.Value = New Decimal(New Integer() {1100000000, 0, 0, 0})
        '
        'txtGKGAKU
        '
        Me.txtGKGAKU.BackColor = System.Drawing.Color.DarkSlateBlue
        Me.txtGKGAKU.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtGKGAKU.Enabled = False
        Me.txtGKGAKU.Font = New System.Drawing.Font("メイリオ", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtGKGAKU.ForeColor = System.Drawing.Color.White
        Me.txtGKGAKU.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtGKGAKU.Location = New System.Drawing.Point(709, 1)
        Me.txtGKGAKU.MaxValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtGKGAKU.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtGKGAKU.Name = "txtGKGAKU"
        Me.txtGKGAKU.ReadOnly = True
        Me.txtGKGAKU.Size = New System.Drawing.Size(78, 14)
        Me.txtGKGAKU.TabIndex = 19
        Me.txtGKGAKU.TabStop = False
        Me.txtGKGAKU.Text = "1,100,000,000"
        Me.txtGKGAKU.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtGKGAKU.Value = New Decimal(New Integer() {1100000000, 0, 0, 0})
        '
        'lblGKJYUTYUGAKU
        '
        Me.lblGKJYUTYUGAKU.AutoSize = True
        Me.lblGKJYUTYUGAKU.BackColor = System.Drawing.Color.DarkSlateBlue
        Me.lblGKJYUTYUGAKU.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblGKJYUTYUGAKU.ForeColor = System.Drawing.Color.White
        Me.lblGKJYUTYUGAKU.Location = New System.Drawing.Point(673, 1)
        Me.lblGKJYUTYUGAKU.Name = "lblGKJYUTYUGAKU"
        Me.lblGKJYUTYUGAKU.Size = New System.Drawing.Size(41, 17)
        Me.lblGKJYUTYUGAKU.TabIndex = 18
        Me.lblGKJYUTYUGAKU.Text = "合計："
        '
        'txtGKTAX
        '
        Me.txtGKTAX.BackColor = System.Drawing.Color.DarkSlateBlue
        Me.txtGKTAX.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtGKTAX.Enabled = False
        Me.txtGKTAX.Font = New System.Drawing.Font("メイリオ", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtGKTAX.ForeColor = System.Drawing.Color.White
        Me.txtGKTAX.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtGKTAX.Location = New System.Drawing.Point(600, 3)
        Me.txtGKTAX.MaxValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtGKTAX.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtGKTAX.Name = "txtGKTAX"
        Me.txtGKTAX.ReadOnly = True
        Me.txtGKTAX.Size = New System.Drawing.Size(70, 14)
        Me.txtGKTAX.TabIndex = 17
        Me.txtGKTAX.TabStop = False
        Me.txtGKTAX.Text = "1,100,000,000"
        Me.txtGKTAX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtGKTAX.Value = New Decimal(New Integer() {1100000000, 0, 0, 0})
        '
        'lblGKTAX
        '
        Me.lblGKTAX.AutoSize = True
        Me.lblGKTAX.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblGKTAX.ForeColor = System.Drawing.Color.White
        Me.lblGKTAX.Location = New System.Drawing.Point(545, 1)
        Me.lblGKTAX.Name = "lblGKTAX"
        Me.lblGKTAX.Size = New System.Drawing.Size(57, 17)
        Me.lblGKTAX.TabIndex = 16
        Me.lblGKTAX.Text = "内消費税:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(192, 1)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(63, 17)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "受注金額："
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(54, 1)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(63, 17)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "原価金額："
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(-5, 1)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(63, 17)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "【総合計】"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.DarkSlateBlue
        Me.Label18.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.Label18.ForeColor = System.Drawing.Color.White
        Me.Label18.Location = New System.Drawing.Point(0, 54)
        Me.Label18.MinimumSize = New System.Drawing.Size(1018, 18)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(1018, 18)
        Me.Label18.TabIndex = 0
        Me.Label18.Text = "基本情報"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.DarkSlateBlue
        Me.Label1.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(4, 185)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(202, 17)
        Me.Label1.TabIndex = 51
        Me.Label1.Text = "工事内訳情報"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'fraKoujiUchiwake
        '
        Me.fraKoujiUchiwake.Location = New System.Drawing.Point(4, 185)
        Me.fraKoujiUchiwake.Name = "fraKoujiUchiwake"
        Me.fraKoujiUchiwake.Size = New System.Drawing.Size(202, 415)
        Me.fraKoujiUchiwake.TabIndex = 52
        Me.fraKoujiUchiwake.TabStop = False
        '
        'tabDetail
        '
        Me.tabDetail.Controls.Add(Me.TabPage1)
        Me.tabDetail.Controls.Add(Me.TabPage4)
        Me.tabDetail.Controls.Add(Me.TabPage2)
        Me.tabDetail.Font = New System.Drawing.Font("メイリオ", 9.0!)
        Me.tabDetail.ItemSize = New System.Drawing.Size(130, 17)
        Me.tabDetail.Location = New System.Drawing.Point(212, 184)
        Me.tabDetail.Name = "tabDetail"
        Me.tabDetail.SelectedIndex = 0
        Me.tabDetail.Size = New System.Drawing.Size(806, 384)
        Me.tabDetail.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.tabDetail.TabIndex = 59
        Me.tabDetail.TabStop = False
        Me.tabDetail.Tag = ""
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dbgMEISAI)
        Me.TabPage1.Location = New System.Drawing.Point(4, 21)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(798, 359)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Tag = "1"
        Me.TabPage1.Text = "明細入力"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'dbgMEISAI
        '
        Me.dbgMEISAI.BackColor = System.Drawing.Color.Thistle
        Me.dbgMEISAI.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.dbgMEISAI.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dbgMEISAI.CaptionHeight = 16
        Me.dbgMEISAI.Cursor = System.Windows.Forms.Cursors.Default
        Me.dbgMEISAI.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dbgMEISAI.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.dbgMEISAI.GroupByCaption = "列でグループ化するには、ここに列ヘッダをドラッグします。"
        Me.dbgMEISAI.Images.Add(CType(resources.GetObject("dbgMEISAI.Images"), System.Drawing.Image))
        Me.dbgMEISAI.Location = New System.Drawing.Point(0, 0)
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
        Me.dbgMEISAI.Size = New System.Drawing.Size(798, 359)
        Me.dbgMEISAI.TabIndex = 27
        Me.dbgMEISAI.TabStop = False
        Me.dbgMEISAI.UseCompatibleTextRendering = False
        Me.dbgMEISAI.PropBag = resources.GetString("dbgMEISAI.PropBag")
        '
        'TabPage4
        '
        Me.TabPage4.BackColor = System.Drawing.Color.Thistle
        Me.TabPage4.Controls.Add(Me.Label11)
        Me.TabPage4.Controls.Add(Me.Label6)
        Me.TabPage4.Controls.Add(Me.txtD_BIKO)
        Me.TabPage4.Location = New System.Drawing.Point(4, 21)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(798, 359)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Tag = "4"
        Me.TabPage4.Text = "伝票備考"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.Label11.Location = New System.Drawing.Point(80, 58)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(115, 17)
        Me.Label11.TabIndex = 28
        Me.Label11.Text = "※Shift+Enterで改行"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.Label6.Location = New System.Drawing.Point(12, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(63, 17)
        Me.Label6.TabIndex = 24
        Me.Label6.Text = "伝票備考："
        '
        'txtD_BIKO
        '
        Me.txtD_BIKO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtD_BIKO.DisplayName = "伝票備考"
        Me.txtD_BIKO.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.txtD_BIKO.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtD_BIKO.Location = New System.Drawing.Point(81, 15)
        Me.txtD_BIKO.MaxLength = 200
        Me.txtD_BIKO.Multiline = True
        Me.txtD_BIKO.Name = "txtD_BIKO"
        Me.txtD_BIKO.Size = New System.Drawing.Size(710, 40)
        Me.txtD_BIKO.TabIndex = 23
        Me.txtD_BIKO.Text = "123456789012345678901234567890123456789012345678901234567890123456789012345678901" &
    "23456789012345678901234567890123456789012345678901234567890123456789012345678901" &
    "234567890123456789012345678901234567890"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.trvWorkInfo_Reference)
        Me.TabPage2.Location = New System.Drawing.Point(4, 21)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(798, 359)
        Me.TabPage2.TabIndex = 4
        Me.TabPage2.Tag = "5"
        Me.TabPage2.Text = "工事内訳参照"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'trvWorkInfo_Reference
        '
        Me.trvWorkInfo_Reference.BackColor = System.Drawing.Color.Thistle
        Me.trvWorkInfo_Reference.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.trvWorkInfo_Reference.Dock = System.Windows.Forms.DockStyle.Fill
        Me.trvWorkInfo_Reference.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.trvWorkInfo_Reference.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.trvWorkInfo_Reference.Location = New System.Drawing.Point(0, 0)
        Me.trvWorkInfo_Reference.Name = "trvWorkInfo_Reference"
        Me.trvWorkInfo_Reference.Size = New System.Drawing.Size(798, 359)
        Me.trvWorkInfo_Reference.TabIndex = 26
        Me.trvWorkInfo_Reference.TabStop = False
        '
        'lblSYORISTDATE
        '
        Me.lblSYORISTDATE.BackColor = System.Drawing.Color.Red
        Me.lblSYORISTDATE.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblSYORISTDATE.ForeColor = System.Drawing.Color.White
        Me.lblSYORISTDATE.Location = New System.Drawing.Point(578, 6)
        Me.lblSYORISTDATE.Name = "lblSYORISTDATE"
        Me.lblSYORISTDATE.Size = New System.Drawing.Size(197, 28)
        Me.lblSYORISTDATE.TabIndex = 78
        Me.lblSYORISTDATE.Text = "ＮＮＮＮＮＮＮＮＮＮ"
        Me.lblSYORISTDATE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblSYORISTDATE.Visible = False
        '
        'lblSyosu
        '
        Me.lblSyosu.BackColor = System.Drawing.Color.DarkSlateBlue
        Me.lblSyosu.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.lblSyosu.ForeColor = System.Drawing.Color.White
        Me.lblSyosu.Location = New System.Drawing.Point(831, 186)
        Me.lblSyosu.Name = "lblSyosu"
        Me.lblSyosu.Size = New System.Drawing.Size(15, 17)
        Me.lblSyosu.TabIndex = 79
        Me.lblSyosu.Text = "0"
        Me.lblSyosu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblSyosu.Visible = False
        '
        'lblSyosuName
        '
        Me.lblSyosuName.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.lblSyosuName.Location = New System.Drawing.Point(852, 179)
        Me.lblSyosuName.Name = "lblSyosuName"
        Me.lblSyosuName.Size = New System.Drawing.Size(162, 24)
        Me.lblSyosuName.TabIndex = 87
        Me.lblSyosuName.TabStop = False
        Me.lblSyosuName.Text = "数量小数点以下桁数：０位"
        Me.lblSyosuName.UseVisualStyleBackColor = True
        '
        'txtAPPROVALKBN
        '
        Me.txtAPPROVALKBN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtAPPROVALKBN.DigitOnly = True
        Me.txtAPPROVALKBN.DisplayName = "見積Ｎｏ"
        Me.txtAPPROVALKBN.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.txtAPPROVALKBN.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtAPPROVALKBN.Location = New System.Drawing.Point(900, 13)
        Me.txtAPPROVALKBN.MaxLength = 10
        Me.txtAPPROVALKBN.Name = "txtAPPROVALKBN"
        Me.txtAPPROVALKBN.Size = New System.Drawing.Size(78, 16)
        Me.txtAPPROVALKBN.TabIndex = 88
        Me.txtAPPROVALKBN.Text = "APPROVALKBN_HIDDEN"
        Me.txtAPPROVALKBN.UseZeroPadding = True
        Me.txtAPPROVALKBN.Visible = False
        Me.txtAPPROVALKBN.ZeroPaddingLength = 10
        '
        'frmJYU0001
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 670)
        Me.Controls.Add(Me.txtAPPROVALKBN)
        Me.Controls.Add(Me.lblSyosuName)
        Me.Controls.Add(Me.lblSYORISTDATE)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.fraMeisaikei)
        Me.Controls.Add(Me.fraSogokei)
        Me.Controls.Add(Me.fraKeyInput)
        Me.Controls.Add(Me.lblSyosu)
        Me.Controls.Add(Me.tabDetail)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.trvWorkInfo)
        Me.Controls.Add(Me.fraKoujiUchiwake)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmJYU0001"
        Me.Text = ""
        Me.Controls.SetChildIndex(Me.TitleBar, 0)
        Me.Controls.SetChildIndex(Me.fraKoujiUchiwake, 0)
        Me.Controls.SetChildIndex(Me.trvWorkInfo, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.tabDetail, 0)
        Me.Controls.SetChildIndex(Me.lblSyosu, 0)
        Me.Controls.SetChildIndex(Me.fraKeyInput, 0)
        Me.Controls.SetChildIndex(Me.fraSogokei, 0)
        Me.Controls.SetChildIndex(Me.fraMeisaikei, 0)
        Me.Controls.SetChildIndex(Me.Label18, 0)
        Me.Controls.SetChildIndex(Me.lblSYORISTDATE, 0)
        Me.Controls.SetChildIndex(Me.FunctionKey, 0)
        Me.Controls.SetChildIndex(Me.lblSyosuName, 0)
        Me.Controls.SetChildIndex(Me.txtAPPROVALKBN, 0)
        Me.fraKeyInput.ResumeLayout(False)
        Me.fraKeyInput.PerformLayout()
        Me.pnlJyutyuNo.ResumeLayout(False)
        Me.pnlJyutyuNo.PerformLayout()
        Me.fraMeisaikei.ResumeLayout(False)
        Me.fraMeisaikei.PerformLayout()
        Me.fraSogokei.ResumeLayout(False)
        Me.fraSogokei.PerformLayout()
        Me.tabDetail.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dbgMEISAI, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents trvWorkInfo As System.Windows.Forms.TreeView
    Friend WithEvents fraKeyInput As System.Windows.Forms.Panel
    Friend WithEvents fraMeisaikei As System.Windows.Forms.Panel
    Friend WithEvents txtMKGENKAGAKU As CommonUtility.WinFormControls.NumberTextBoxEx
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtMKGAKU_NUKI As CommonUtility.WinFormControls.NumberTextBoxEx
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents fraSogokei As System.Windows.Forms.Panel
    Friend WithEvents txtGKGAKU_NUKI As CommonUtility.WinFormControls.NumberTextBoxEx
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtGKGENKAGAKU As CommonUtility.WinFormControls.NumberTextBoxEx
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtGKGAKU As CommonUtility.WinFormControls.NumberTextBoxEx
    Friend WithEvents lblGKJYUTYUGAKU As System.Windows.Forms.Label
    Friend WithEvents txtGKTAX As CommonUtility.WinFormControls.NumberTextBoxEx
    Friend WithEvents lblGKTAX As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtKoujiBasyo As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtKoujiNo As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtKoujiName As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents cmbTantoCode As CommonUtility.WinFormControls.TypComboBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtAITE_ORDERNO As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents cmbKEISYOUCODE As CommonUtility.WinFormControls.TypComboBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtJYUTYUDATE As CommonUtility.WinFormControls.DateTextBoxEx
    Friend WithEvents lblJYUTYUGengo As System.Windows.Forms.Label
    Friend WithEvents txtTantoName As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents lblNOUKIGengo1 As System.Windows.Forms.Label
    Friend WithEvents lblNOUKIGengo0 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents txtNOUKIDATE1 As CommonUtility.WinFormControls.DateTextBoxEx
    Friend WithEvents txtNOUKIDATE0 As CommonUtility.WinFormControls.DateTextBoxEx
    Friend WithEvents txtKokyakuName As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents fraKoujiUchiwake As System.Windows.Forms.GroupBox
    Friend WithEvents tabDetail As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents txtKEISYOUNAME As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents lblMITUMORINO As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents txtMITUMORINO As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents cmbMITUMORINO As CommonUtility.WinFormControls.MitumoriNoComboBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents txtMITUMORIEDABAN As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents txtMKARARIRITU As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents txtGKARARIRITU As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtD_BIKO As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblSYORISTDATE As System.Windows.Forms.Label
    Friend WithEvents lblSyosu As System.Windows.Forms.Label
    Protected WithEvents dbgMEISAI As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Private WithEvents txtJIKKOYOSAN As CommonUtility.WinFormControls.NumberTextBoxEx
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents trvWorkInfo_Reference As System.Windows.Forms.TreeView
    Friend WithEvents txtKokyakuCode As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents txtJYUTYUNO As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents Label2 As Label
    Friend WithEvents lblSyosuName As Button
    Friend WithEvents txtAPPROVALKBN As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents Label11 As Label
    Friend WithEvents lblJYUTYUNO As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents Label13 As Label
    Friend WithEvents txtJYUTYUEDABAN As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents cmbJYUTYUNO As CommonUtility.WinFormControls.MitumoriNoComboBox
    Friend WithEvents pnlJyutyuNo As Panel
    Friend WithEvents Label12 As Label
End Class
