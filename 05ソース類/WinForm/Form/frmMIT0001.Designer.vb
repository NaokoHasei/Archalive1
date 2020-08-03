<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMIT0001
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMIT0001))
        Me.trvWorkInfo = New System.Windows.Forms.TreeView()
        Me.fraKeyInput = New System.Windows.Forms.Panel()
        Me.txtSAI_MITUMORIEDABAN = New CommonUtility.WinFormControls.MitumoriNoTextBoxEx()
        Me.cmbMITUMORINO = New CommonUtility.WinFormControls.MitumoriNoComboBox()
        Me.lblMITUMORINO = New CommonUtility.WinFormControls.TextBoxEx()
        Me.txtKokyakuCode = New CommonUtility.WinFormControls.TextBoxEx()
        Me.lblSAN_MITUMORINO = New CommonUtility.WinFormControls.TextBoxEx()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.txtSAN_MITUMORINO = New CommonUtility.WinFormControls.TextBoxEx()
        Me.cmbSAN_MITUMORINO = New CommonUtility.WinFormControls.MitumoriNoComboBox()
        Me.lblSAI_MITUMORINO = New CommonUtility.WinFormControls.TextBoxEx()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.txtSAI_MITUMORINO = New CommonUtility.WinFormControls.TextBoxEx()
        Me.cmbSAI_MITUMORINO = New CommonUtility.WinFormControls.MitumoriNoComboBox()
        Me.txtKEISYOUNAME = New CommonUtility.WinFormControls.TextBoxEx()
        Me.txtKokyakuName = New CommonUtility.WinFormControls.TextBoxEx()
        Me.lblNOUKIGengo1 = New System.Windows.Forms.Label()
        Me.lblNOUKIGengo0 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtNOUKIDATE1 = New CommonUtility.WinFormControls.DateTextBoxEx()
        Me.txtNOUKIDATE0 = New CommonUtility.WinFormControls.DateTextBoxEx()
        Me.txtTantoName = New CommonUtility.WinFormControls.TextBoxEx()
        Me.lblTeisyutuGengo = New System.Windows.Forms.Label()
        Me.txtTEISYUTUDATE = New CommonUtility.WinFormControls.DateTextBoxEx()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.cmbKEISYOUCODE = New CommonUtility.WinFormControls.TypComboBox()
        Me.Label27 = New System.Windows.Forms.Label()
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
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.txtKigen = New CommonUtility.WinFormControls.TextBoxEx()
        Me.txtShiharaiJoken = New CommonUtility.WinFormControls.TextBoxEx()
        Me.txtKoujiBasyo = New CommonUtility.WinFormControls.TextBoxEx()
        Me.fraMeisaikei = New System.Windows.Forms.Panel()
        Me.txtMKGENKAGAKU = New CommonUtility.WinFormControls.NumberTextBoxEx()
        Me.txtMKGAKU_NUKI = New CommonUtility.WinFormControls.NumberTextBoxEx()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtMKARARIRITU = New CommonUtility.WinFormControls.TextBoxEx()
        Me.fraSogokei = New System.Windows.Forms.Panel()
        Me.lblGKMITUMORIGAKU = New System.Windows.Forms.Label()
        Me.txtGKTAX = New CommonUtility.WinFormControls.NumberTextBoxEx()
        Me.lblGKTAX = New System.Windows.Forms.Label()
        Me.txtGKGENKAGAKU = New CommonUtility.WinFormControls.NumberTextBoxEx()
        Me.txtGKGAKU_NUKI = New CommonUtility.WinFormControls.NumberTextBoxEx()
        Me.txtGKGAKU = New CommonUtility.WinFormControls.NumberTextBoxEx()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtGKARARIRITU = New CommonUtility.WinFormControls.TextBoxEx()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.fraKoujiUchiwake = New System.Windows.Forms.GroupBox()
        Me.tabDetail = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.dbgMEISAI = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.btnMitumoriEdit = New System.Windows.Forms.Button()
        Me.cmbMitumoriJouken = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtMitsumoriJoken = New CommonUtility.WinFormControls.TextBoxEx()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtD_BIKO = New CommonUtility.WinFormControls.TextBoxEx()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.trvWorkInfo_Reference = New System.Windows.Forms.TreeView()
        Me.lblSyosu = New System.Windows.Forms.Label()
        Me.fraMITUMORINO = New System.Windows.Forms.Panel()
        Me.txtMITUMORIEDABAN = New CommonUtility.WinFormControls.MitumoriNoTextBoxEx()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtMITUMORINO = New CommonUtility.WinFormControls.TextBoxEx()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnMENT0002 = New System.Windows.Forms.Button()
        Me.btnMENT0006 = New System.Windows.Forms.Button()
        Me.lblSyosuName = New System.Windows.Forms.Button()
        Me.txtSAN_MITUMORIEDABAN = New CommonUtility.WinFormControls.MitumoriNoTextBoxEx()
        Me.fraKeyInput.SuspendLayout()
        Me.fraMeisaikei.SuspendLayout()
        Me.fraSogokei.SuspendLayout()
        Me.tabDetail.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dbgMEISAI, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage4.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        Me.fraMITUMORINO.SuspendLayout()
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
        Me.fraKeyInput.Controls.Add(Me.txtSAN_MITUMORIEDABAN)
        Me.fraKeyInput.Controls.Add(Me.txtSAI_MITUMORIEDABAN)
        Me.fraKeyInput.Controls.Add(Me.txtKokyakuCode)
        Me.fraKeyInput.Controls.Add(Me.lblSAN_MITUMORINO)
        Me.fraKeyInput.Controls.Add(Me.Label32)
        Me.fraKeyInput.Controls.Add(Me.txtSAN_MITUMORINO)
        Me.fraKeyInput.Controls.Add(Me.cmbSAN_MITUMORINO)
        Me.fraKeyInput.Controls.Add(Me.lblSAI_MITUMORINO)
        Me.fraKeyInput.Controls.Add(Me.Label30)
        Me.fraKeyInput.Controls.Add(Me.txtSAI_MITUMORINO)
        Me.fraKeyInput.Controls.Add(Me.cmbSAI_MITUMORINO)
        Me.fraKeyInput.Controls.Add(Me.txtKEISYOUNAME)
        Me.fraKeyInput.Controls.Add(Me.txtKokyakuName)
        Me.fraKeyInput.Controls.Add(Me.lblNOUKIGengo1)
        Me.fraKeyInput.Controls.Add(Me.lblNOUKIGengo0)
        Me.fraKeyInput.Controls.Add(Me.Label29)
        Me.fraKeyInput.Controls.Add(Me.txtNOUKIDATE1)
        Me.fraKeyInput.Controls.Add(Me.txtNOUKIDATE0)
        Me.fraKeyInput.Controls.Add(Me.txtTantoName)
        Me.fraKeyInput.Controls.Add(Me.lblTeisyutuGengo)
        Me.fraKeyInput.Controls.Add(Me.txtTEISYUTUDATE)
        Me.fraKeyInput.Controls.Add(Me.Label28)
        Me.fraKeyInput.Controls.Add(Me.cmbKEISYOUCODE)
        Me.fraKeyInput.Controls.Add(Me.Label27)
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
        Me.fraKeyInput.Controls.Add(Me.Label15)
        Me.fraKeyInput.Controls.Add(Me.Label34)
        Me.fraKeyInput.Controls.Add(Me.txtKigen)
        Me.fraKeyInput.Controls.Add(Me.txtShiharaiJoken)
        Me.fraKeyInput.Controls.Add(Me.txtKoujiBasyo)
        Me.fraKeyInput.Location = New System.Drawing.Point(0, 72)
        Me.fraKeyInput.Name = "fraKeyInput"
        Me.fraKeyInput.Size = New System.Drawing.Size(1018, 106)
        Me.fraKeyInput.TabIndex = 1
        '
        'txtSAI_MITUMORIEDABAN
        '
        Me.txtSAI_MITUMORIEDABAN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSAI_MITUMORIEDABAN.DigitOnly = True
        Me.txtSAI_MITUMORIEDABAN.DisplayName = "再見積枝番"
        Me.txtSAI_MITUMORIEDABAN.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.txtSAI_MITUMORIEDABAN.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtSAI_MITUMORIEDABAN.LinkedComboBox = Me.cmbSAI_MITUMORINO
        Me.txtSAI_MITUMORIEDABAN.Location = New System.Drawing.Point(576, 4)
        Me.txtSAI_MITUMORIEDABAN.MaxLength = 2
        Me.txtSAI_MITUMORIEDABAN.Name = "txtSAI_MITUMORIEDABAN"
        Me.txtSAI_MITUMORIEDABAN.Size = New System.Drawing.Size(22, 16)
        Me.txtSAI_MITUMORIEDABAN.TabIndex = 12
        Me.txtSAI_MITUMORIEDABAN.Text = "1234567890123456789012345678901234567890"
        Me.txtSAI_MITUMORIEDABAN.UseZeroPadding = True
        Me.txtSAI_MITUMORIEDABAN.ZeroPaddingLength = 2
        '
        'cmbMITUMORINO
        '
        Me.cmbMITUMORINO.DisplayName = "見積Ｎｏ"
        Me.cmbMITUMORINO.LinkedTextBox = Me.lblMITUMORINO
        Me.cmbMITUMORINO.Location = New System.Drawing.Point(192, 1)
        Me.cmbMITUMORINO.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.cmbMITUMORINO.MaxLength = 32767
        Me.cmbMITUMORINO.Name = "cmbMITUMORINO"
        Me.cmbMITUMORINO.PopupErrorDialog = False
        Me.cmbMITUMORINO.Size = New System.Drawing.Size(17, 18)
        Me.cmbMITUMORINO.TabIndex = 3
        Me.cmbMITUMORINO.TabStop = False
        Me.cmbMITUMORINO.UseUpdateLinkedTextByCodeChange = True
        '
        'lblMITUMORINO
        '
        Me.lblMITUMORINO.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.lblMITUMORINO.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lblMITUMORINO.DisplayName = "見積Ｎｏ"
        Me.lblMITUMORINO.Enabled = False
        Me.lblMITUMORINO.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.lblMITUMORINO.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.lblMITUMORINO.Location = New System.Drawing.Point(217, 2)
        Me.lblMITUMORINO.MaxLength = 10
        Me.lblMITUMORINO.Name = "lblMITUMORINO"
        Me.lblMITUMORINO.ReadOnly = True
        Me.lblMITUMORINO.Size = New System.Drawing.Size(94, 16)
        Me.lblMITUMORINO.TabIndex = 81
        Me.lblMITUMORINO.Text = "1234567890-01"
        Me.lblMITUMORINO.Visible = False
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
        Me.txtKokyakuCode.Location = New System.Drawing.Point(78, 64)
        Me.txtKokyakuCode.MaxLength = 10
        Me.txtKokyakuCode.Name = "txtKokyakuCode"
        Me.txtKokyakuCode.ReadOnly = True
        Me.txtKokyakuCode.Size = New System.Drawing.Size(78, 16)
        Me.txtKokyakuCode.TabIndex = 91
        Me.txtKokyakuCode.TabStop = False
        Me.txtKokyakuCode.Text = "1234567890123456789012345678901234567890"
        Me.txtKokyakuCode.UseZeroPadding = True
        Me.txtKokyakuCode.ZeroPaddingLength = 8
        '
        'lblSAN_MITUMORINO
        '
        Me.lblSAN_MITUMORINO.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.lblSAN_MITUMORINO.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lblSAN_MITUMORINO.DisplayName = "参照見積Ｎｏ"
        Me.lblSAN_MITUMORINO.Enabled = False
        Me.lblSAN_MITUMORINO.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.lblSAN_MITUMORINO.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.lblSAN_MITUMORINO.Location = New System.Drawing.Point(625, 23)
        Me.lblSAN_MITUMORINO.MaxLength = 10
        Me.lblSAN_MITUMORINO.Name = "lblSAN_MITUMORINO"
        Me.lblSAN_MITUMORINO.ReadOnly = True
        Me.lblSAN_MITUMORINO.Size = New System.Drawing.Size(14, 16)
        Me.lblSAN_MITUMORINO.TabIndex = 85
        Me.lblSAN_MITUMORINO.TabStop = False
        Me.lblSAN_MITUMORINO.Text = "1234567890-01"
        Me.lblSAN_MITUMORINO.Visible = False
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.Label32.Location = New System.Drawing.Point(562, 23)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(13, 17)
        Me.Label32.TabIndex = 15
        Me.Label32.Text = "-"
        '
        'txtSAN_MITUMORINO
        '
        Me.txtSAN_MITUMORINO.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSAN_MITUMORINO.DigitOnly = True
        Me.txtSAN_MITUMORINO.DisplayName = "参照見積Ｎｏ"
        Me.txtSAN_MITUMORINO.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.txtSAN_MITUMORINO.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtSAN_MITUMORINO.Location = New System.Drawing.Point(484, 23)
        Me.txtSAN_MITUMORINO.MaxLength = 10
        Me.txtSAN_MITUMORINO.Name = "txtSAN_MITUMORINO"
        Me.txtSAN_MITUMORINO.Size = New System.Drawing.Size(78, 16)
        Me.txtSAN_MITUMORINO.TabIndex = 13
        Me.txtSAN_MITUMORINO.Text = "1234567890123456789012345678901234567890"
        Me.txtSAN_MITUMORINO.UseZeroPadding = True
        Me.txtSAN_MITUMORINO.ZeroPaddingLength = 10
        '
        'cmbSAN_MITUMORINO
        '
        Me.cmbSAN_MITUMORINO.DisplayName = "参照見積Ｎｏ"
        Me.cmbSAN_MITUMORINO.LinkedTextBox = Me.lblSAN_MITUMORINO
        Me.cmbSAN_MITUMORINO.Location = New System.Drawing.Point(602, 22)
        Me.cmbSAN_MITUMORINO.Margin = New System.Windows.Forms.Padding(3, 8, 3, 8)
        Me.cmbSAN_MITUMORINO.MaxLength = 32767
        Me.cmbSAN_MITUMORINO.Name = "cmbSAN_MITUMORINO"
        Me.cmbSAN_MITUMORINO.PopupErrorDialog = False
        Me.cmbSAN_MITUMORINO.Size = New System.Drawing.Size(17, 18)
        Me.cmbSAN_MITUMORINO.TabIndex = 14
        Me.cmbSAN_MITUMORINO.TabStop = False
        Me.cmbSAN_MITUMORINO.UseUpdateLinkedTextByCodeChange = True
        '
        'lblSAI_MITUMORINO
        '
        Me.lblSAI_MITUMORINO.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.lblSAI_MITUMORINO.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lblSAI_MITUMORINO.DisplayName = "再見積Ｎｏ"
        Me.lblSAI_MITUMORINO.Enabled = False
        Me.lblSAI_MITUMORINO.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.lblSAI_MITUMORINO.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.lblSAI_MITUMORINO.Location = New System.Drawing.Point(625, 4)
        Me.lblSAI_MITUMORINO.MaxLength = 10
        Me.lblSAI_MITUMORINO.Name = "lblSAI_MITUMORINO"
        Me.lblSAI_MITUMORINO.ReadOnly = True
        Me.lblSAI_MITUMORINO.Size = New System.Drawing.Size(14, 16)
        Me.lblSAI_MITUMORINO.TabIndex = 80
        Me.lblSAI_MITUMORINO.TabStop = False
        Me.lblSAI_MITUMORINO.Text = "1234567890-01"
        Me.lblSAI_MITUMORINO.Visible = False
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.Label30.Location = New System.Drawing.Point(562, 4)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(13, 17)
        Me.Label30.TabIndex = 79
        Me.Label30.Text = "-"
        '
        'txtSAI_MITUMORINO
        '
        Me.txtSAI_MITUMORINO.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.txtSAI_MITUMORINO.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSAI_MITUMORINO.DigitOnly = True
        Me.txtSAI_MITUMORINO.DisplayName = "再見積Ｎｏ"
        Me.txtSAI_MITUMORINO.Enabled = False
        Me.txtSAI_MITUMORINO.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.txtSAI_MITUMORINO.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtSAI_MITUMORINO.Location = New System.Drawing.Point(484, 4)
        Me.txtSAI_MITUMORINO.MaxLength = 10
        Me.txtSAI_MITUMORINO.Name = "txtSAI_MITUMORINO"
        Me.txtSAI_MITUMORINO.Size = New System.Drawing.Size(78, 16)
        Me.txtSAI_MITUMORINO.TabIndex = 11
        Me.txtSAI_MITUMORINO.Text = "1234567890123456789012345678901234567890"
        Me.txtSAI_MITUMORINO.UseZeroPadding = True
        Me.txtSAI_MITUMORINO.ZeroPaddingLength = 10
        '
        'cmbSAI_MITUMORINO
        '
        Me.cmbSAI_MITUMORINO.DisplayName = "再見積Ｎｏ"
        Me.cmbSAI_MITUMORINO.LinkedTextBox = Me.lblSAI_MITUMORINO
        Me.cmbSAI_MITUMORINO.Location = New System.Drawing.Point(602, 4)
        Me.cmbSAI_MITUMORINO.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.cmbSAI_MITUMORINO.MaxLength = 32767
        Me.cmbSAI_MITUMORINO.Name = "cmbSAI_MITUMORINO"
        Me.cmbSAI_MITUMORINO.PopupErrorDialog = False
        Me.cmbSAI_MITUMORINO.Size = New System.Drawing.Size(17, 18)
        Me.cmbSAI_MITUMORINO.TabIndex = 12
        Me.cmbSAI_MITUMORINO.TabStop = False
        Me.cmbSAI_MITUMORINO.UseUpdateLinkedTextByCodeChange = True
        '
        'txtKEISYOUNAME
        '
        Me.txtKEISYOUNAME.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.txtKEISYOUNAME.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtKEISYOUNAME.DisplayName = "敬称名称"
        Me.txtKEISYOUNAME.Enabled = False
        Me.txtKEISYOUNAME.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtKEISYOUNAME.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtKEISYOUNAME.Location = New System.Drawing.Point(535, 43)
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
        Me.txtKokyakuName.DisplayName = "元請名称"
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
        Me.lblNOUKIGengo1.Location = New System.Drawing.Point(316, 83)
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
        Me.Label29.Location = New System.Drawing.Point(218, 83)
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
        Me.txtNOUKIDATE1.Location = New System.Drawing.Point(245, 83)
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
        'lblTeisyutuGengo
        '
        Me.lblTeisyutuGengo.AutoSize = True
        Me.lblTeisyutuGengo.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.lblTeisyutuGengo.Location = New System.Drawing.Point(151, 23)
        Me.lblTeisyutuGengo.Name = "lblTeisyutuGengo"
        Me.lblTeisyutuGengo.Size = New System.Drawing.Size(54, 17)
        Me.lblTeisyutuGengo.TabIndex = 1
        Me.lblTeisyutuGengo.Text = "(平成27)"
        '
        'txtTEISYUTUDATE
        '
        Me.txtTEISYUTUDATE.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTEISYUTUDATE.DisplayName = "提出日付"
        Me.txtTEISYUTUDATE.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtTEISYUTUDATE.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtTEISYUTUDATE.LinkedDateTextBox = Nothing
        Me.txtTEISYUTUDATE.Location = New System.Drawing.Point(79, 23)
        Me.txtTEISYUTUDATE.Mask = "0000/00/00"
        Me.txtTEISYUTUDATE.Name = "txtTEISYUTUDATE"
        Me.txtTEISYUTUDATE.Size = New System.Drawing.Size(70, 17)
        Me.txtTEISYUTUDATE.TabIndex = 4
        Me.txtTEISYUTUDATE.Text = "20150410"
        Me.txtTEISYUTUDATE.UseNullValidator = True
        Me.txtTEISYUTUDATE.ValidatingType = GetType(Date)
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.Label28.Location = New System.Drawing.Point(400, 43)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(41, 17)
        Me.Label28.TabIndex = 53
        Me.Label28.Text = "敬　称"
        '
        'cmbKEISYOUCODE
        '
        Me.cmbKEISYOUCODE.AutoValidate = System.Windows.Forms.AutoValidate.Disable
        Me.cmbKEISYOUCODE.DisplayName = "敬称"
        Me.cmbKEISYOUCODE.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.cmbKEISYOUCODE.LinkedTextBox = Me.txtKEISYOUNAME
        Me.cmbKEISYOUCODE.Location = New System.Drawing.Point(484, 43)
        Me.cmbKEISYOUCODE.MaxLength = 4
        Me.cmbKEISYOUCODE.Name = "cmbKEISYOUCODE"
        Me.cmbKEISYOUCODE.Size = New System.Drawing.Size(50, 18)
        Me.cmbKEISYOUCODE.TabIndex = 15
        Me.cmbKEISYOUCODE.UseMasterCheckValidator = True
        Me.cmbKEISYOUCODE.UseNullValidator = True
        Me.cmbKEISYOUCODE.UseUpdateLinkedTextByCodeChange = True
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.Label27.Location = New System.Drawing.Point(400, 3)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(56, 17)
        Me.Label27.TabIndex = 51
        Me.Label27.Text = "再見積No"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.Label25.Location = New System.Drawing.Point(650, 84)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(52, 17)
        Me.Label25.TabIndex = 33
        Me.Label25.Text = "支払条件"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.Label24.Location = New System.Drawing.Point(650, 64)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(52, 17)
        Me.Label24.TabIndex = 31
        Me.Label24.Text = "有効期限"
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
        Me.txtKoujiNo.Location = New System.Drawing.Point(719, 24)
        Me.txtKoujiNo.MaxLength = 20
        Me.txtKoujiNo.Name = "txtKoujiNo"
        Me.txtKoujiNo.Size = New System.Drawing.Size(166, 16)
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
        Me.txtKoujiName.Location = New System.Drawing.Point(719, 4)
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
        Me.Label19.Size = New System.Drawing.Size(53, 17)
        Me.Label19.TabIndex = 20
        Me.Label19.Text = "担 当 者 "
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
        Me.Label17.Text = "提出日付"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.Label16.Location = New System.Drawing.Point(11, 64)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(53, 17)
        Me.Label16.TabIndex = 14
        Me.Label16.Text = "元 請 名 "
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.Label15.Location = New System.Drawing.Point(400, 23)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(67, 17)
        Me.Label15.TabIndex = 12
        Me.Label15.Text = "参照見積No"
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
        'txtKigen
        '
        Me.txtKigen.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtKigen.DisplayName = "有効期限"
        Me.txtKigen.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.txtKigen.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtKigen.Location = New System.Drawing.Point(719, 64)
        Me.txtKigen.MaxLength = 40
        Me.txtKigen.Name = "txtKigen"
        Me.txtKigen.Size = New System.Drawing.Size(286, 16)
        Me.txtKigen.TabIndex = 20
        Me.txtKigen.Text = "1234567890123456789012345678901234567890"
        '
        'txtShiharaiJoken
        '
        Me.txtShiharaiJoken.BackColor = System.Drawing.SystemColors.Window
        Me.txtShiharaiJoken.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtShiharaiJoken.DisplayName = "支払条件"
        Me.txtShiharaiJoken.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.txtShiharaiJoken.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtShiharaiJoken.Location = New System.Drawing.Point(719, 84)
        Me.txtShiharaiJoken.MaxLength = 40
        Me.txtShiharaiJoken.MoveFocusAfterEnter = False
        Me.txtShiharaiJoken.Name = "txtShiharaiJoken"
        Me.txtShiharaiJoken.Size = New System.Drawing.Size(286, 16)
        Me.txtShiharaiJoken.TabIndex = 21
        Me.txtShiharaiJoken.Text = "1234567890123456789012345678901234567890"
        '
        'txtKoujiBasyo
        '
        Me.txtKoujiBasyo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtKoujiBasyo.DisplayName = "工事場所"
        Me.txtKoujiBasyo.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.txtKoujiBasyo.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtKoujiBasyo.Location = New System.Drawing.Point(719, 44)
        Me.txtKoujiBasyo.MaxLength = 40
        Me.txtKoujiBasyo.Name = "txtKoujiBasyo"
        Me.txtKoujiBasyo.Size = New System.Drawing.Size(286, 16)
        Me.txtKoujiBasyo.TabIndex = 19
        Me.txtKoujiBasyo.Text = "1234567890123456789012345678901234567890"
        '
        'fraMeisaikei
        '
        Me.fraMeisaikei.BackColor = System.Drawing.Color.DarkSlateBlue
        Me.fraMeisaikei.Controls.Add(Me.txtMKGENKAGAKU)
        Me.fraMeisaikei.Controls.Add(Me.txtMKGAKU_NUKI)
        Me.fraMeisaikei.Controls.Add(Me.Label5)
        Me.fraMeisaikei.Controls.Add(Me.Label4)
        Me.fraMeisaikei.Controls.Add(Me.Label3)
        Me.fraMeisaikei.Controls.Add(Me.txtMKARARIRITU)
        Me.fraMeisaikei.Location = New System.Drawing.Point(212, 570)
        Me.fraMeisaikei.Name = "fraMeisaikei"
        Me.fraMeisaikei.Size = New System.Drawing.Size(791, 17)
        Me.fraMeisaikei.TabIndex = 11
        '
        'txtMKGENKAGAKU
        '
        Me.txtMKGENKAGAKU.BackColor = System.Drawing.Color.DarkSlateBlue
        Me.txtMKGENKAGAKU.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtMKGENKAGAKU.Enabled = False
        Me.txtMKGENKAGAKU.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.txtMKGENKAGAKU.ForeColor = System.Drawing.Color.White
        Me.txtMKGENKAGAKU.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtMKGENKAGAKU.Location = New System.Drawing.Point(123, 1)
        Me.txtMKGENKAGAKU.MaxValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtMKGENKAGAKU.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtMKGENKAGAKU.Name = "txtMKGENKAGAKU"
        Me.txtMKGENKAGAKU.Size = New System.Drawing.Size(102, 16)
        Me.txtMKGENKAGAKU.TabIndex = 12
        Me.txtMKGENKAGAKU.Text = "123,100,000,000"
        Me.txtMKGENKAGAKU.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtMKGENKAGAKU.Value = New Decimal(New Integer() {-1454051584, 28, 0, 0})
        '
        'txtMKGAKU_NUKI
        '
        Me.txtMKGAKU_NUKI.BackColor = System.Drawing.Color.DarkSlateBlue
        Me.txtMKGAKU_NUKI.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtMKGAKU_NUKI.Enabled = False
        Me.txtMKGAKU_NUKI.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.txtMKGAKU_NUKI.ForeColor = System.Drawing.Color.White
        Me.txtMKGAKU_NUKI.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtMKGAKU_NUKI.Location = New System.Drawing.Point(294, 1)
        Me.txtMKGAKU_NUKI.MaxValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtMKGAKU_NUKI.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtMKGAKU_NUKI.Name = "txtMKGAKU_NUKI"
        Me.txtMKGAKU_NUKI.Size = New System.Drawing.Size(102, 16)
        Me.txtMKGAKU_NUKI.TabIndex = 14
        Me.txtMKGAKU_NUKI.Text = "123,100,000,000"
        Me.txtMKGAKU_NUKI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtMKGAKU_NUKI.Value = New Decimal(New Integer() {-1454051584, 28, 0, 0})
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(230, 1)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(68, 17)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "見積金額計:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(60, 1)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 17)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "原価金額計:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(-5, 1)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 17)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "【 明細計 】"
        '
        'txtMKARARIRITU
        '
        Me.txtMKARARIRITU.BackColor = System.Drawing.Color.DarkSlateBlue
        Me.txtMKARARIRITU.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtMKARARIRITU.DisplayName = "粗利率"
        Me.txtMKARARIRITU.Enabled = False
        Me.txtMKARARIRITU.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.txtMKARARIRITU.ForeColor = System.Drawing.Color.White
        Me.txtMKARARIRITU.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtMKARARIRITU.Location = New System.Drawing.Point(395, 1)
        Me.txtMKARARIRITU.MaxLength = 40
        Me.txtMKARARIRITU.Name = "txtMKARARIRITU"
        Me.txtMKARARIRITU.Size = New System.Drawing.Size(118, 16)
        Me.txtMKARARIRITU.TabIndex = 21
        Me.txtMKARARIRITU.Text = "（粗利率：999.99％）"
        '
        'fraSogokei
        '
        Me.fraSogokei.BackColor = System.Drawing.Color.DarkSlateBlue
        Me.fraSogokei.Controls.Add(Me.lblGKMITUMORIGAKU)
        Me.fraSogokei.Controls.Add(Me.txtGKTAX)
        Me.fraSogokei.Controls.Add(Me.lblGKTAX)
        Me.fraSogokei.Controls.Add(Me.txtGKGENKAGAKU)
        Me.fraSogokei.Controls.Add(Me.txtGKGAKU_NUKI)
        Me.fraSogokei.Controls.Add(Me.txtGKGAKU)
        Me.fraSogokei.Controls.Add(Me.Label8)
        Me.fraSogokei.Controls.Add(Me.Label9)
        Me.fraSogokei.Controls.Add(Me.Label10)
        Me.fraSogokei.Controls.Add(Me.txtGKARARIRITU)
        Me.fraSogokei.Location = New System.Drawing.Point(212, 589)
        Me.fraSogokei.Name = "fraSogokei"
        Me.fraSogokei.Size = New System.Drawing.Size(791, 17)
        Me.fraSogokei.TabIndex = 16
        '
        'lblGKMITUMORIGAKU
        '
        Me.lblGKMITUMORIGAKU.AutoSize = True
        Me.lblGKMITUMORIGAKU.BackColor = System.Drawing.Color.DarkSlateBlue
        Me.lblGKMITUMORIGAKU.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.lblGKMITUMORIGAKU.ForeColor = System.Drawing.Color.White
        Me.lblGKMITUMORIGAKU.Location = New System.Drawing.Point(653, 1)
        Me.lblGKMITUMORIGAKU.Name = "lblGKMITUMORIGAKU"
        Me.lblGKMITUMORIGAKU.Size = New System.Drawing.Size(35, 17)
        Me.lblGKMITUMORIGAKU.TabIndex = 18
        Me.lblGKMITUMORIGAKU.Text = "合計:"
        '
        'txtGKTAX
        '
        Me.txtGKTAX.BackColor = System.Drawing.Color.DarkSlateBlue
        Me.txtGKTAX.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtGKTAX.Enabled = False
        Me.txtGKTAX.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.txtGKTAX.ForeColor = System.Drawing.Color.White
        Me.txtGKTAX.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtGKTAX.Location = New System.Drawing.Point(563, 1)
        Me.txtGKTAX.MaxValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtGKTAX.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtGKTAX.Name = "txtGKTAX"
        Me.txtGKTAX.Size = New System.Drawing.Size(86, 16)
        Me.txtGKTAX.TabIndex = 17
        Me.txtGKTAX.Text = "1,100,000,000"
        Me.txtGKTAX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtGKTAX.Value = New Decimal(New Integer() {1100000000, 0, 0, 0})
        '
        'lblGKTAX
        '
        Me.lblGKTAX.AutoSize = True
        Me.lblGKTAX.BackColor = System.Drawing.Color.DarkSlateBlue
        Me.lblGKTAX.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.lblGKTAX.ForeColor = System.Drawing.Color.White
        Me.lblGKTAX.Location = New System.Drawing.Point(508, 1)
        Me.lblGKTAX.Name = "lblGKTAX"
        Me.lblGKTAX.Size = New System.Drawing.Size(57, 17)
        Me.lblGKTAX.TabIndex = 16
        Me.lblGKTAX.Text = "内消費税:"
        '
        'txtGKGENKAGAKU
        '
        Me.txtGKGENKAGAKU.BackColor = System.Drawing.Color.DarkSlateBlue
        Me.txtGKGENKAGAKU.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtGKGENKAGAKU.Enabled = False
        Me.txtGKGENKAGAKU.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.txtGKGENKAGAKU.ForeColor = System.Drawing.Color.White
        Me.txtGKGENKAGAKU.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtGKGENKAGAKU.Location = New System.Drawing.Point(123, 1)
        Me.txtGKGENKAGAKU.MaxValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtGKGENKAGAKU.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtGKGENKAGAKU.Name = "txtGKGENKAGAKU"
        Me.txtGKGENKAGAKU.Size = New System.Drawing.Size(102, 16)
        Me.txtGKGENKAGAKU.TabIndex = 12
        Me.txtGKGENKAGAKU.Text = "123,100,000,000"
        Me.txtGKGENKAGAKU.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtGKGENKAGAKU.Value = New Decimal(New Integer() {-1454051584, 28, 0, 0})
        '
        'txtGKGAKU_NUKI
        '
        Me.txtGKGAKU_NUKI.BackColor = System.Drawing.Color.DarkSlateBlue
        Me.txtGKGAKU_NUKI.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtGKGAKU_NUKI.Enabled = False
        Me.txtGKGAKU_NUKI.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.txtGKGAKU_NUKI.ForeColor = System.Drawing.Color.White
        Me.txtGKGAKU_NUKI.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtGKGAKU_NUKI.Location = New System.Drawing.Point(294, 1)
        Me.txtGKGAKU_NUKI.MaxValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtGKGAKU_NUKI.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtGKGAKU_NUKI.Name = "txtGKGAKU_NUKI"
        Me.txtGKGAKU_NUKI.Size = New System.Drawing.Size(102, 16)
        Me.txtGKGAKU_NUKI.TabIndex = 14
        Me.txtGKGAKU_NUKI.Text = "123,100,000,000"
        Me.txtGKGAKU_NUKI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtGKGAKU_NUKI.Value = New Decimal(New Integer() {-1454051584, 28, 0, 0})
        '
        'txtGKGAKU
        '
        Me.txtGKGAKU.BackColor = System.Drawing.Color.DarkSlateBlue
        Me.txtGKGAKU.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtGKGAKU.Enabled = False
        Me.txtGKGAKU.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.txtGKGAKU.ForeColor = System.Drawing.Color.White
        Me.txtGKGAKU.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtGKGAKU.Location = New System.Drawing.Point(681, 1)
        Me.txtGKGAKU.MaxValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtGKGAKU.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtGKGAKU.Name = "txtGKGAKU"
        Me.txtGKGAKU.Size = New System.Drawing.Size(102, 16)
        Me.txtGKGAKU.TabIndex = 19
        Me.txtGKGAKU.Text = "123,100,000,000"
        Me.txtGKGAKU.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtGKGAKU.Value = New Decimal(New Integer() {-1454051584, 28, 0, 0})
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.DarkSlateBlue
        Me.Label8.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(230, 1)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(68, 17)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "見積金額計:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.DarkSlateBlue
        Me.Label9.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(60, 1)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(68, 17)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "原価金額計:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.DarkSlateBlue
        Me.Label10.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(-5, 1)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(71, 17)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "【 総合計 】"
        '
        'txtGKARARIRITU
        '
        Me.txtGKARARIRITU.BackColor = System.Drawing.Color.DarkSlateBlue
        Me.txtGKARARIRITU.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtGKARARIRITU.DisplayName = "粗利率"
        Me.txtGKARARIRITU.Enabled = False
        Me.txtGKARARIRITU.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.txtGKARARIRITU.ForeColor = System.Drawing.Color.White
        Me.txtGKARARIRITU.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtGKARARIRITU.Location = New System.Drawing.Point(395, 1)
        Me.txtGKARARIRITU.MaxLength = 40
        Me.txtGKARARIRITU.Name = "txtGKARARIRITU"
        Me.txtGKARARIRITU.Size = New System.Drawing.Size(118, 16)
        Me.txtGKARARIRITU.TabIndex = 22
        Me.txtGKARARIRITU.Text = "（粗利率：999.99％）"
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
        Me.tabDetail.Controls.Add(Me.TabPage5)
        Me.tabDetail.Font = New System.Drawing.Font("メイリオ", 9.0!)
        Me.tabDetail.ItemSize = New System.Drawing.Size(120, 17)
        Me.tabDetail.Location = New System.Drawing.Point(212, 184)
        Me.tabDetail.Name = "tabDetail"
        Me.tabDetail.SelectedIndex = 0
        Me.tabDetail.Size = New System.Drawing.Size(806, 384)
        Me.tabDetail.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.tabDetail.TabIndex = 59
        Me.tabDetail.TabStop = False
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.Transparent
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
        Me.dbgMEISAI.AllowDrag = True
        Me.dbgMEISAI.AllowDrop = True
        Me.dbgMEISAI.BackColor = System.Drawing.Color.Thistle
        Me.dbgMEISAI.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.dbgMEISAI.CaptionHeight = 16
        Me.dbgMEISAI.Cursor = System.Windows.Forms.Cursors.Default
        Me.dbgMEISAI.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dbgMEISAI.FetchRowStyles = True
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
        Me.dbgMEISAI.TabIndex = 86
        Me.dbgMEISAI.TabStop = False
        Me.dbgMEISAI.UseCompatibleTextRendering = False
        Me.dbgMEISAI.PropBag = resources.GetString("dbgMEISAI.PropBag")
        '
        'TabPage4
        '
        Me.TabPage4.BackColor = System.Drawing.Color.Thistle
        Me.TabPage4.Controls.Add(Me.btnMitumoriEdit)
        Me.TabPage4.Controls.Add(Me.cmbMitumoriJouken)
        Me.TabPage4.Controls.Add(Me.Label12)
        Me.TabPage4.Controls.Add(Me.Label11)
        Me.TabPage4.Controls.Add(Me.txtMitsumoriJoken)
        Me.TabPage4.Controls.Add(Me.Label7)
        Me.TabPage4.Controls.Add(Me.Label6)
        Me.TabPage4.Controls.Add(Me.txtD_BIKO)
        Me.TabPage4.Location = New System.Drawing.Point(4, 21)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(798, 359)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Tag = "4"
        Me.TabPage4.Text = "伝票備考"
        '
        'btnMitumoriEdit
        '
        Me.btnMitumoriEdit.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.btnMitumoriEdit.Location = New System.Drawing.Point(325, 77)
        Me.btnMitumoriEdit.Name = "btnMitumoriEdit"
        Me.btnMitumoriEdit.Size = New System.Drawing.Size(162, 24)
        Me.btnMitumoriEdit.TabIndex = 84
        Me.btnMitumoriEdit.Text = "見積条件の編集"
        Me.btnMitumoriEdit.UseVisualStyleBackColor = True
        '
        'cmbMitumoriJouken
        '
        Me.cmbMitumoriJouken.BackColor = System.Drawing.SystemColors.Window
        Me.cmbMitumoriJouken.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbMitumoriJouken.FormattingEnabled = True
        Me.cmbMitumoriJouken.Location = New System.Drawing.Point(77, 77)
        Me.cmbMitumoriJouken.Name = "cmbMitumoriJouken"
        Me.cmbMitumoriJouken.Size = New System.Drawing.Size(242, 26)
        Me.cmbMitumoriJouken.TabIndex = 29
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.Label12.Location = New System.Drawing.Point(74, 335)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(115, 17)
        Me.Label12.TabIndex = 28
        Me.Label12.Text = "※Shift+Enterで改行"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.Label11.Location = New System.Drawing.Point(74, 57)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(115, 17)
        Me.Label11.TabIndex = 27
        Me.Label11.Text = "※Shift+Enterで改行"
        '
        'txtMitsumoriJoken
        '
        Me.txtMitsumoriJoken.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMitsumoriJoken.DisplayName = "伝票備考"
        Me.txtMitsumoriJoken.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.txtMitsumoriJoken.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtMitsumoriJoken.Location = New System.Drawing.Point(77, 109)
        Me.txtMitsumoriJoken.MaxLength = 5000
        Me.txtMitsumoriJoken.Multiline = True
        Me.txtMitsumoriJoken.Name = "txtMitsumoriJoken"
        Me.txtMitsumoriJoken.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
        Me.txtMitsumoriJoken.Size = New System.Drawing.Size(710, 223)
        Me.txtMitsumoriJoken.TabIndex = 27
        Me.txtMitsumoriJoken.Text = resources.GetString("txtMitsumoriJoken.Text")
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.Label7.Location = New System.Drawing.Point(10, 77)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(52, 17)
        Me.Label7.TabIndex = 25
        Me.Label7.Text = "見積条件"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.Label6.Location = New System.Drawing.Point(9, 12)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 17)
        Me.Label6.TabIndex = 24
        Me.Label6.Text = "伝票備考"
        '
        'txtD_BIKO
        '
        Me.txtD_BIKO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtD_BIKO.DisplayName = "伝票備考"
        Me.txtD_BIKO.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.txtD_BIKO.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtD_BIKO.Location = New System.Drawing.Point(77, 12)
        Me.txtD_BIKO.MaxLength = 200
        Me.txtD_BIKO.Multiline = True
        Me.txtD_BIKO.Name = "txtD_BIKO"
        Me.txtD_BIKO.Size = New System.Drawing.Size(710, 42)
        Me.txtD_BIKO.TabIndex = 23
        Me.txtD_BIKO.Text = "123456789012345678901234567890123456789012345678901234567890123456789012345678901" &
    "23456789012345678901234567890123456789012345678901234567890123456789012345678901" &
    "234567890123456789012345678901234567890"
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.trvWorkInfo_Reference)
        Me.TabPage5.Location = New System.Drawing.Point(4, 21)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Size = New System.Drawing.Size(798, 359)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Tag = "5"
        Me.TabPage5.Text = "工事内訳参照"
        Me.TabPage5.UseVisualStyleBackColor = True
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
        Me.trvWorkInfo_Reference.TabIndex = 25
        Me.trvWorkInfo_Reference.TabStop = False
        '
        'lblSyosu
        '
        Me.lblSyosu.BackColor = System.Drawing.Color.DarkSlateBlue
        Me.lblSyosu.Enabled = False
        Me.lblSyosu.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.lblSyosu.ForeColor = System.Drawing.Color.White
        Me.lblSyosu.Location = New System.Drawing.Point(831, 186)
        Me.lblSyosu.Name = "lblSyosu"
        Me.lblSyosu.Size = New System.Drawing.Size(15, 17)
        Me.lblSyosu.TabIndex = 65
        Me.lblSyosu.Text = "0"
        Me.lblSyosu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblSyosu.Visible = False
        '
        'fraMITUMORINO
        '
        Me.fraMITUMORINO.BackColor = System.Drawing.Color.Thistle
        Me.fraMITUMORINO.Controls.Add(Me.txtMITUMORIEDABAN)
        Me.fraMITUMORINO.Controls.Add(Me.lblMITUMORINO)
        Me.fraMITUMORINO.Controls.Add(Me.Label13)
        Me.fraMITUMORINO.Controls.Add(Me.txtMITUMORINO)
        Me.fraMITUMORINO.Controls.Add(Me.cmbMITUMORINO)
        Me.fraMITUMORINO.Controls.Add(Me.Label2)
        Me.fraMITUMORINO.Location = New System.Drawing.Point(5, 73)
        Me.fraMITUMORINO.Name = "fraMITUMORINO"
        Me.fraMITUMORINO.Size = New System.Drawing.Size(318, 22)
        Me.fraMITUMORINO.TabIndex = 1
        '
        'txtMITUMORIEDABAN
        '
        Me.txtMITUMORIEDABAN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtMITUMORIEDABAN.DigitOnly = True
        Me.txtMITUMORIEDABAN.DisplayName = "見積枝番"
        Me.txtMITUMORIEDABAN.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.txtMITUMORIEDABAN.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtMITUMORIEDABAN.LinkedComboBox = Me.cmbMITUMORINO
        Me.txtMITUMORIEDABAN.Location = New System.Drawing.Point(167, 2)
        Me.txtMITUMORIEDABAN.MaxLength = 2
        Me.txtMITUMORIEDABAN.Name = "txtMITUMORIEDABAN"
        Me.txtMITUMORIEDABAN.Size = New System.Drawing.Size(22, 16)
        Me.txtMITUMORIEDABAN.TabIndex = 3
        Me.txtMITUMORIEDABAN.Text = "1234567890123456789012345678901234567890"
        Me.txtMITUMORIEDABAN.UseZeroPadding = True
        Me.txtMITUMORIEDABAN.ZeroPaddingLength = 2
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.Label13.Location = New System.Drawing.Point(153, 2)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(13, 17)
        Me.Label13.TabIndex = 2
        Me.Label13.Text = "-"
        '
        'txtMITUMORINO
        '
        Me.txtMITUMORINO.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.txtMITUMORINO.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtMITUMORINO.DigitOnly = True
        Me.txtMITUMORINO.DisplayName = "見積Ｎｏ"
        Me.txtMITUMORINO.Enabled = False
        Me.txtMITUMORINO.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.txtMITUMORINO.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtMITUMORINO.Location = New System.Drawing.Point(75, 2)
        Me.txtMITUMORINO.MaxLength = 10
        Me.txtMITUMORINO.Name = "txtMITUMORINO"
        Me.txtMITUMORINO.Size = New System.Drawing.Size(78, 16)
        Me.txtMITUMORINO.TabIndex = 1
        Me.txtMITUMORINO.Text = "1234567890"
        Me.txtMITUMORINO.UseZeroPadding = True
        Me.txtMITUMORINO.ZeroPaddingLength = 10
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.Label2.Location = New System.Drawing.Point(7, 2)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 17)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "見積Ｎｏ"
        '
        'btnMENT0002
        '
        Me.btnMENT0002.BackColor = System.Drawing.Color.Transparent
        Me.btnMENT0002.FlatAppearance.BorderSize = 0
        Me.btnMENT0002.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.btnMENT0002.ForeColor = System.Drawing.Color.Black
        Me.btnMENT0002.Location = New System.Drawing.Point(0, 36)
        Me.btnMENT0002.Name = "btnMENT0002"
        Me.btnMENT0002.Size = New System.Drawing.Size(126, 22)
        Me.btnMENT0002.TabIndex = 79
        Me.btnMENT0002.TabStop = False
        Me.btnMENT0002.Text = "科目・品目登録"
        Me.btnMENT0002.UseVisualStyleBackColor = False
        '
        'btnMENT0006
        '
        Me.btnMENT0006.BackColor = System.Drawing.Color.Transparent
        Me.btnMENT0006.FlatAppearance.BorderSize = 0
        Me.btnMENT0006.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.btnMENT0006.ForeColor = System.Drawing.Color.Black
        Me.btnMENT0006.Location = New System.Drawing.Point(132, 36)
        Me.btnMENT0006.Name = "btnMENT0006"
        Me.btnMENT0006.Size = New System.Drawing.Size(126, 22)
        Me.btnMENT0006.TabIndex = 80
        Me.btnMENT0006.TabStop = False
        Me.btnMENT0006.Text = "下請登録"
        Me.btnMENT0006.UseVisualStyleBackColor = False
        '
        'lblSyosuName
        '
        Me.lblSyosuName.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.lblSyosuName.Location = New System.Drawing.Point(852, 179)
        Me.lblSyosuName.Name = "lblSyosuName"
        Me.lblSyosuName.Size = New System.Drawing.Size(162, 24)
        Me.lblSyosuName.TabIndex = 83
        Me.lblSyosuName.TabStop = False
        Me.lblSyosuName.Text = "数量小数点以下桁数：０位"
        Me.lblSyosuName.UseVisualStyleBackColor = True
        '
        'txtSAN_MITUMORIEDABAN
        '
        Me.txtSAN_MITUMORIEDABAN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSAN_MITUMORIEDABAN.DigitOnly = True
        Me.txtSAN_MITUMORIEDABAN.DisplayName = "参照見積枝番"
        Me.txtSAN_MITUMORIEDABAN.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.txtSAN_MITUMORIEDABAN.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtSAN_MITUMORIEDABAN.LinkedComboBox = Me.cmbSAN_MITUMORINO
        Me.txtSAN_MITUMORIEDABAN.Location = New System.Drawing.Point(576, 23)
        Me.txtSAN_MITUMORIEDABAN.MaxLength = 2
        Me.txtSAN_MITUMORIEDABAN.Name = "txtSAN_MITUMORIEDABAN"
        Me.txtSAN_MITUMORIEDABAN.Size = New System.Drawing.Size(22, 16)
        Me.txtSAN_MITUMORIEDABAN.TabIndex = 14
        Me.txtSAN_MITUMORIEDABAN.Text = "1234567890123456789012345678901234567890"
        Me.txtSAN_MITUMORIEDABAN.UseZeroPadding = True
        Me.txtSAN_MITUMORIEDABAN.ZeroPaddingLength = 2
        '
        'frmMIT0001
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 670)
        Me.Controls.Add(Me.lblSyosuName)
        Me.Controls.Add(Me.fraMITUMORINO)
        Me.Controls.Add(Me.lblSyosu)
        Me.Controls.Add(Me.tabDetail)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.fraMeisaikei)
        Me.Controls.Add(Me.fraSogokei)
        Me.Controls.Add(Me.fraKeyInput)
        Me.Controls.Add(Me.trvWorkInfo)
        Me.Controls.Add(Me.fraKoujiUchiwake)
        Me.Controls.Add(Me.btnMENT0002)
        Me.Controls.Add(Me.btnMENT0006)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMIT0001"
        Me.Text = ""
        Me.Controls.SetChildIndex(Me.btnMENT0006, 0)
        Me.Controls.SetChildIndex(Me.btnMENT0002, 0)
        Me.Controls.SetChildIndex(Me.fraKoujiUchiwake, 0)
        Me.Controls.SetChildIndex(Me.trvWorkInfo, 0)
        Me.Controls.SetChildIndex(Me.fraKeyInput, 0)
        Me.Controls.SetChildIndex(Me.fraSogokei, 0)
        Me.Controls.SetChildIndex(Me.fraMeisaikei, 0)
        Me.Controls.SetChildIndex(Me.Label18, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.tabDetail, 0)
        Me.Controls.SetChildIndex(Me.lblSyosu, 0)
        Me.Controls.SetChildIndex(Me.fraMITUMORINO, 0)
        Me.Controls.SetChildIndex(Me.lblSyosuName, 0)
        Me.Controls.SetChildIndex(Me.TitleBar, 0)
        Me.Controls.SetChildIndex(Me.FunctionKey, 0)
        Me.fraKeyInput.ResumeLayout(False)
        Me.fraKeyInput.PerformLayout()
        Me.fraMeisaikei.ResumeLayout(False)
        Me.fraMeisaikei.PerformLayout()
        Me.fraSogokei.ResumeLayout(False)
        Me.fraSogokei.PerformLayout()
        Me.tabDetail.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dbgMEISAI, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.TabPage5.ResumeLayout(False)
        Me.fraMITUMORINO.ResumeLayout(False)
        Me.fraMITUMORINO.PerformLayout()
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
    Friend WithEvents lblGKMITUMORIGAKU As System.Windows.Forms.Label
    Friend WithEvents txtGKTAX As CommonUtility.WinFormControls.NumberTextBoxEx
    Friend WithEvents lblGKTAX As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
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
    Friend WithEvents txtShiharaiJoken As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtKigen As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents cmbKEISYOUCODE As CommonUtility.WinFormControls.TypComboBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txtTEISYUTUDATE As CommonUtility.WinFormControls.DateTextBoxEx
    Friend WithEvents lblTeisyutuGengo As System.Windows.Forms.Label
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
    Friend WithEvents lblSyosu As System.Windows.Forms.Label
    Friend WithEvents lblSAI_MITUMORINO As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents txtSAI_MITUMORINO As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents cmbSAI_MITUMORINO As CommonUtility.WinFormControls.MitumoriNoComboBox
    Friend WithEvents lblSAN_MITUMORINO As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents txtSAN_MITUMORINO As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents cmbSAN_MITUMORINO As CommonUtility.WinFormControls.MitumoriNoComboBox
    Friend WithEvents fraMITUMORINO As System.Windows.Forms.Panel
    Friend WithEvents lblMITUMORINO As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtMITUMORINO As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents cmbMITUMORINO As CommonUtility.WinFormControls.MitumoriNoComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtMKARARIRITU As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents txtGKARARIRITU As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtD_BIKO As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents trvWorkInfo_Reference As System.Windows.Forms.TreeView
    Friend WithEvents btnMENT0002 As System.Windows.Forms.Button
    Friend WithEvents btnMENT0006 As System.Windows.Forms.Button
    Friend WithEvents txtKokyakuCode As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents lblSyosuName As Button
    Friend WithEvents Label11 As Label
    Friend WithEvents txtMitsumoriJoken As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents Label7 As Label
    Friend WithEvents Label12 As Label
    Protected WithEvents dbgMEISAI As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents cmbMitumoriJouken As ComboBox
    Friend WithEvents btnMitumoriEdit As Button
    Friend WithEvents txtMITUMORIEDABAN As CommonUtility.WinFormControls.MitumoriNoTextBoxEx
    Friend WithEvents txtSAI_MITUMORIEDABAN As CommonUtility.WinFormControls.MitumoriNoTextBoxEx
    Friend WithEvents txtSAN_MITUMORIEDABAN As CommonUtility.WinFormControls.MitumoriNoTextBoxEx
End Class
