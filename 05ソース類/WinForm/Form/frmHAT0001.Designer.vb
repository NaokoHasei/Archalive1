<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHAT0001
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmHAT0001))
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtHATYUEDABAN = New CommonUtility.WinFormControls.TextBoxEx()
        Me.txtHATYUNO = New CommonUtility.WinFormControls.TextBoxEx()
        Me.lblHATYUDATE = New System.Windows.Forms.Label()
        Me.txtHATYUDATE = New CommonUtility.WinFormControls.DateTextBoxEx()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.pnl対象下請情報 = New System.Windows.Forms.Panel()
        Me.cmbHATTYUNO = New CommonUtility.WinFormControls.MitumoriNoComboBox()
        Me.lblHATYUNO = New CommonUtility.WinFormControls.TextBoxEx()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtHATYUEDABAN2 = New CommonUtility.WinFormControls.TextBoxEx()
        Me.txtSIIRECODE = New CommonUtility.WinFormControls.TypComboBox()
        Me.txtSIIRENAME = New CommonUtility.WinFormControls.TextBoxEx()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtSIHARAI_COMMENT_01 = New CommonUtility.WinFormControls.TextBoxEx()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.lblKOUJIBASYO = New System.Windows.Forms.Label()
        Me.txtSIHARAI_COMMENT_03 = New CommonUtility.WinFormControls.TextBoxEx()
        Me.txtAITE_MITUMORINO = New CommonUtility.WinFormControls.TextBoxEx()
        Me.lblKOUJINO = New System.Windows.Forms.Label()
        Me.lblKOUJINAME = New System.Windows.Forms.Label()
        Me.txtSIHARAI_COMMENT_05 = New CommonUtility.WinFormControls.TextBoxEx()
        Me.txtKEIYAKUNO = New CommonUtility.WinFormControls.TextBoxEx()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtSIHARAI_COMMENT_02 = New CommonUtility.WinFormControls.TextBoxEx()
        Me.txtSIHARAI_COMMENT_04 = New CommonUtility.WinFormControls.TextBoxEx()
        Me.txtJYUTYUEDABAN = New CommonUtility.WinFormControls.TextBoxEx()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtSIHARAI_COMMENT_06 = New CommonUtility.WinFormControls.TextBoxEx()
        Me.chkHATYUDATE = New System.Windows.Forms.CheckBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.txtJYUTYUNO = New CommonUtility.WinFormControls.TextBoxEx()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.lblTANTONAME = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.txtNOUKI_END = New CommonUtility.WinFormControls.DateTextBoxEx()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtNOUKI_START = New CommonUtility.WinFormControls.DateTextBoxEx()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtKEISYOUNAME = New CommonUtility.WinFormControls.TextBoxEx()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtKEISYOUCODE = New CommonUtility.WinFormControls.TypComboBox()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.lblJYUTYUNO = New CommonUtility.WinFormControls.TextBoxEx()
        Me.txtZeiKbn = New CommonUtility.WinFormControls.NumberTextBoxEx()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.dbgMeisai = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lblSURYO_SYOSUIKAKETA = New System.Windows.Forms.Label()
        Me.fraMeisaikei = New System.Windows.Forms.Panel()
        Me.lblGKGENKAGAKU_NUKIBefore = New System.Windows.Forms.Label()
        Me.lblGKGENKAGAKU = New System.Windows.Forms.Label()
        Me.lblGKTAX = New System.Windows.Forms.Label()
        Me.lblGKGENKAGAKU_NUKI = New System.Windows.Forms.Label()
        Me.lblGKGENKA = New System.Windows.Forms.Label()
        Me.lblTAX = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.pnl対象下請情報.SuspendLayout()
        CType(Me.dbgMeisai, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fraMeisaikei.SuspendLayout()
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
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.Label13.Location = New System.Drawing.Point(171, 9)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(13, 17)
        Me.Label13.TabIndex = 45
        Me.Label13.Text = "-"
        '
        'txtHATYUEDABAN
        '
        Me.txtHATYUEDABAN.BackColor = System.Drawing.Color.White
        Me.txtHATYUEDABAN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtHATYUEDABAN.DigitOnly = True
        Me.txtHATYUEDABAN.DisplayName = "発注枝番"
        Me.txtHATYUEDABAN.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.txtHATYUEDABAN.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtHATYUEDABAN.Location = New System.Drawing.Point(187, 9)
        Me.txtHATYUEDABAN.MaxLength = 2
        Me.txtHATYUEDABAN.Name = "txtHATYUEDABAN"
        Me.txtHATYUEDABAN.Size = New System.Drawing.Size(22, 16)
        Me.txtHATYUEDABAN.TabIndex = 1
        Me.txtHATYUEDABAN.Text = "1234567890123456789012345678901234567890"
        Me.txtHATYUEDABAN.UseZeroPadding = True
        Me.txtHATYUEDABAN.ZeroPaddingLength = 2
        '
        'txtHATYUNO
        '
        Me.txtHATYUNO.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.txtHATYUNO.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtHATYUNO.DisplayName = "郵便番号"
        Me.txtHATYUNO.Enabled = False
        Me.txtHATYUNO.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtHATYUNO.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtHATYUNO.Location = New System.Drawing.Point(91, 9)
        Me.txtHATYUNO.MaxLength = 10
        Me.txtHATYUNO.Name = "txtHATYUNO"
        Me.txtHATYUNO.ReadOnly = True
        Me.txtHATYUNO.Size = New System.Drawing.Size(78, 17)
        Me.txtHATYUNO.TabIndex = 44
        Me.txtHATYUNO.TabStop = False
        Me.txtHATYUNO.Text = "1234567890"
        '
        'lblHATYUDATE
        '
        Me.lblHATYUDATE.AutoSize = True
        Me.lblHATYUDATE.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.lblHATYUDATE.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblHATYUDATE.Location = New System.Drawing.Point(170, 31)
        Me.lblHATYUDATE.Name = "lblHATYUDATE"
        Me.lblHATYUDATE.Size = New System.Drawing.Size(77, 17)
        Me.lblHATYUDATE.TabIndex = 43
        Me.lblHATYUDATE.Text = "（令和02年）"
        '
        'txtHATYUDATE
        '
        Me.txtHATYUDATE.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtHATYUDATE.DisplayName = "発注日付"
        Me.txtHATYUDATE.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.txtHATYUDATE.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtHATYUDATE.LinkedDateTextBox = Nothing
        Me.txtHATYUDATE.Location = New System.Drawing.Point(91, 31)
        Me.txtHATYUDATE.Mask = "0000/00/00"
        Me.txtHATYUDATE.Name = "txtHATYUDATE"
        Me.txtHATYUDATE.Size = New System.Drawing.Size(70, 16)
        Me.txtHATYUDATE.TabIndex = 11
        Me.txtHATYUDATE.UseNullValidator = True
        Me.txtHATYUDATE.ValidatingType = GetType(Date)
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label33.Location = New System.Drawing.Point(12, 31)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(52, 17)
        Me.Label33.TabIndex = 18
        Me.Label33.Text = "発注日付"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label37.Location = New System.Drawing.Point(12, 10)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(52, 17)
        Me.Label37.TabIndex = 3
        Me.Label37.Text = "発注Ｎｏ"
        '
        'pnl対象下請情報
        '
        Me.pnl対象下請情報.BackColor = System.Drawing.Color.Thistle
        Me.pnl対象下請情報.Controls.Add(Me.cmbHATTYUNO)
        Me.pnl対象下請情報.Controls.Add(Me.Label14)
        Me.pnl対象下請情報.Controls.Add(Me.txtHATYUEDABAN2)
        Me.pnl対象下請情報.Controls.Add(Me.txtSIIRECODE)
        Me.pnl対象下請情報.Controls.Add(Me.Label12)
        Me.pnl対象下請情報.Controls.Add(Me.Label17)
        Me.pnl対象下請情報.Controls.Add(Me.txtSIHARAI_COMMENT_01)
        Me.pnl対象下請情報.Controls.Add(Me.Label27)
        Me.pnl対象下請情報.Controls.Add(Me.lblKOUJIBASYO)
        Me.pnl対象下請情報.Controls.Add(Me.txtSIHARAI_COMMENT_03)
        Me.pnl対象下請情報.Controls.Add(Me.lblHATYUDATE)
        Me.pnl対象下請情報.Controls.Add(Me.txtAITE_MITUMORINO)
        Me.pnl対象下請情報.Controls.Add(Me.lblKOUJINO)
        Me.pnl対象下請情報.Controls.Add(Me.lblKOUJINAME)
        Me.pnl対象下請情報.Controls.Add(Me.txtSIHARAI_COMMENT_05)
        Me.pnl対象下請情報.Controls.Add(Me.txtKEIYAKUNO)
        Me.pnl対象下請情報.Controls.Add(Me.Label11)
        Me.pnl対象下請情報.Controls.Add(Me.txtSIHARAI_COMMENT_02)
        Me.pnl対象下請情報.Controls.Add(Me.Label13)
        Me.pnl対象下請情報.Controls.Add(Me.txtSIHARAI_COMMENT_04)
        Me.pnl対象下請情報.Controls.Add(Me.txtJYUTYUEDABAN)
        Me.pnl対象下請情報.Controls.Add(Me.Label9)
        Me.pnl対象下請情報.Controls.Add(Me.txtSIHARAI_COMMENT_06)
        Me.pnl対象下請情報.Controls.Add(Me.chkHATYUDATE)
        Me.pnl対象下請情報.Controls.Add(Me.Label32)
        Me.pnl対象下請情報.Controls.Add(Me.txtJYUTYUNO)
        Me.pnl対象下請情報.Controls.Add(Me.Label10)
        Me.pnl対象下請情報.Controls.Add(Me.Label26)
        Me.pnl対象下請情報.Controls.Add(Me.lblTANTONAME)
        Me.pnl対象下請情報.Controls.Add(Me.Label7)
        Me.pnl対象下請情報.Controls.Add(Me.txtHATYUEDABAN)
        Me.pnl対象下請情報.Controls.Add(Me.Label31)
        Me.pnl対象下請情報.Controls.Add(Me.txtNOUKI_END)
        Me.pnl対象下請情報.Controls.Add(Me.Label6)
        Me.pnl対象下請情報.Controls.Add(Me.Label1)
        Me.pnl対象下請情報.Controls.Add(Me.txtNOUKI_START)
        Me.pnl対象下請情報.Controls.Add(Me.txtHATYUNO)
        Me.pnl対象下請情報.Controls.Add(Me.txtHATYUDATE)
        Me.pnl対象下請情報.Controls.Add(Me.Label33)
        Me.pnl対象下請情報.Controls.Add(Me.Label4)
        Me.pnl対象下請情報.Controls.Add(Me.txtKEISYOUNAME)
        Me.pnl対象下請情報.Controls.Add(Me.Label37)
        Me.pnl対象下請情報.Controls.Add(Me.Label2)
        Me.pnl対象下請情報.Controls.Add(Me.txtSIIRENAME)
        Me.pnl対象下請情報.Controls.Add(Me.txtKEISYOUCODE)
        Me.pnl対象下請情報.Controls.Add(Me.Label56)
        Me.pnl対象下請情報.Location = New System.Drawing.Point(0, 62)
        Me.pnl対象下請情報.Name = "pnl対象下請情報"
        Me.pnl対象下請情報.Size = New System.Drawing.Size(1018, 167)
        Me.pnl対象下請情報.TabIndex = 0
        '
        'cmbHATTYUNO
        '
        Me.cmbHATTYUNO.DisplayName = "発注Ｎｏ"
        Me.cmbHATTYUNO.LinkedTextBox = Me.lblHATYUNO
        Me.cmbHATTYUNO.Location = New System.Drawing.Point(252, 9)
        Me.cmbHATTYUNO.Margin = New System.Windows.Forms.Padding(3, 23, 3, 23)
        Me.cmbHATTYUNO.MaxLength = 32767
        Me.cmbHATTYUNO.Name = "cmbHATTYUNO"
        Me.cmbHATTYUNO.PopupErrorDialog = False
        Me.cmbHATTYUNO.Size = New System.Drawing.Size(18, 18)
        Me.cmbHATTYUNO.TabIndex = 109
        Me.cmbHATTYUNO.TabStop = False
        Me.cmbHATTYUNO.UseUpdateLinkedTextByCodeChange = True
        '
        'lblHATYUNO
        '
        Me.lblHATYUNO.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.lblHATYUNO.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lblHATYUNO.DisplayName = "受注Ｎｏ"
        Me.lblHATYUNO.Enabled = False
        Me.lblHATYUNO.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.lblHATYUNO.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.lblHATYUNO.Location = New System.Drawing.Point(790, 12)
        Me.lblHATYUNO.MaxLength = 10
        Me.lblHATYUNO.Name = "lblHATYUNO"
        Me.lblHATYUNO.ReadOnly = True
        Me.lblHATYUNO.Size = New System.Drawing.Size(110, 16)
        Me.lblHATYUNO.TabIndex = 202
        Me.lblHATYUNO.Text = "1234567890-01-01"
        Me.lblHATYUNO.Visible = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.Label14.Location = New System.Drawing.Point(213, 9)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(13, 17)
        Me.Label14.TabIndex = 108
        Me.Label14.Text = "-"
        '
        'txtHATYUEDABAN2
        '
        Me.txtHATYUEDABAN2.BackColor = System.Drawing.Color.White
        Me.txtHATYUEDABAN2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtHATYUEDABAN2.DigitOnly = True
        Me.txtHATYUEDABAN2.DisplayName = "発注枝番"
        Me.txtHATYUEDABAN2.Enabled = False
        Me.txtHATYUEDABAN2.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.txtHATYUEDABAN2.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtHATYUEDABAN2.Location = New System.Drawing.Point(230, 9)
        Me.txtHATYUEDABAN2.MaxLength = 2
        Me.txtHATYUEDABAN2.Name = "txtHATYUEDABAN2"
        Me.txtHATYUEDABAN2.Size = New System.Drawing.Size(22, 16)
        Me.txtHATYUEDABAN2.TabIndex = 2
        Me.txtHATYUEDABAN2.Text = "1234567890123456789012345678901234567890"
        Me.txtHATYUEDABAN2.UseZeroPadding = True
        Me.txtHATYUEDABAN2.ZeroPaddingLength = 2
        '
        'txtSIIRECODE
        '
        Me.txtSIIRECODE.AutoValidate = System.Windows.Forms.AutoValidate.Disable
        Me.txtSIIRECODE.DisplayName = "下請コード"
        Me.txtSIIRECODE.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.txtSIIRECODE.LinkedTextBox = Me.txtSIIRENAME
        Me.txtSIIRECODE.Location = New System.Drawing.Point(374, 9)
        Me.txtSIIRECODE.MaxLength = 8
        Me.txtSIIRECODE.Name = "txtSIIRECODE"
        Me.txtSIIRECODE.Size = New System.Drawing.Size(82, 18)
        Me.txtSIIRECODE.TabIndex = 3
        Me.txtSIIRECODE.UseMasterCheckValidator = True
        Me.txtSIIRECODE.UseNullValidator = True
        Me.txtSIIRECODE.UseUpdateLinkedTextByCodeChange = True
        Me.txtSIIRECODE.UseZeroPadding = True
        Me.txtSIIRECODE.ZeroPaddingLength = 8
        '
        'txtSIIRENAME
        '
        Me.txtSIIRENAME.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.txtSIIRENAME.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSIIRENAME.DisplayName = "下請名"
        Me.txtSIIRENAME.Enabled = False
        Me.txtSIIRENAME.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtSIIRENAME.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtSIIRENAME.Location = New System.Drawing.Point(374, 31)
        Me.txtSIIRENAME.MaxLength = 40
        Me.txtSIIRENAME.Name = "txtSIIRENAME"
        Me.txtSIIRENAME.Size = New System.Drawing.Size(214, 17)
        Me.txtSIIRENAME.TabIndex = 12
        Me.txtSIIRENAME.Text = "123456789012345678901234567890"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.Location = New System.Drawing.Point(12, 119)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(63, 17)
        Me.Label12.TabIndex = 106
        Me.Label12.Text = "発注日印字"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label17.Location = New System.Drawing.Point(282, 31)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(41, 17)
        Me.Label17.TabIndex = 91
        Me.Label17.Text = "下請名"
        '
        'txtSIHARAI_COMMENT_01
        '
        Me.txtSIHARAI_COMMENT_01.BackColor = System.Drawing.Color.White
        Me.txtSIHARAI_COMMENT_01.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSIHARAI_COMMENT_01.DisplayName = "支払条件"
        Me.txtSIHARAI_COMMENT_01.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtSIHARAI_COMMENT_01.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtSIHARAI_COMMENT_01.Location = New System.Drawing.Point(285, 92)
        Me.txtSIHARAI_COMMENT_01.MaxLength = 30
        Me.txtSIHARAI_COMMENT_01.Name = "txtSIHARAI_COMMENT_01"
        Me.txtSIHARAI_COMMENT_01.Size = New System.Drawing.Size(214, 24)
        Me.txtSIHARAI_COMMENT_01.TabIndex = 22
        Me.txtSIHARAI_COMMENT_01.Text = "123456789012345678901234567890"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.Color.Thistle
        Me.Label27.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label27.Location = New System.Drawing.Point(282, 9)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(63, 17)
        Me.Label27.TabIndex = 93
        Me.Label27.Text = "下請コード"
        '
        'lblKOUJIBASYO
        '
        Me.lblKOUJIBASYO.AutoSize = True
        Me.lblKOUJIBASYO.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.lblKOUJIBASYO.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblKOUJIBASYO.Location = New System.Drawing.Point(709, 97)
        Me.lblKOUJIBASYO.MinimumSize = New System.Drawing.Size(197, 17)
        Me.lblKOUJIBASYO.Name = "lblKOUJIBASYO"
        Me.lblKOUJIBASYO.Size = New System.Drawing.Size(197, 17)
        Me.lblKOUJIBASYO.TabIndex = 52
        Me.lblKOUJIBASYO.Text = "123456798012345679801234567"
        '
        'txtSIHARAI_COMMENT_03
        '
        Me.txtSIHARAI_COMMENT_03.BackColor = System.Drawing.Color.White
        Me.txtSIHARAI_COMMENT_03.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSIHARAI_COMMENT_03.DisplayName = "支払条件"
        Me.txtSIHARAI_COMMENT_03.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtSIHARAI_COMMENT_03.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtSIHARAI_COMMENT_03.Location = New System.Drawing.Point(285, 138)
        Me.txtSIHARAI_COMMENT_03.MaxLength = 30
        Me.txtSIHARAI_COMMENT_03.Name = "txtSIHARAI_COMMENT_03"
        Me.txtSIHARAI_COMMENT_03.Size = New System.Drawing.Size(214, 24)
        Me.txtSIHARAI_COMMENT_03.TabIndex = 24
        Me.txtSIHARAI_COMMENT_03.Text = "123456789012345678901234567890"
        '
        'txtAITE_MITUMORINO
        '
        Me.txtAITE_MITUMORINO.BackColor = System.Drawing.Color.White
        Me.txtAITE_MITUMORINO.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtAITE_MITUMORINO.DisplayName = "相手見積Ｎｏ"
        Me.txtAITE_MITUMORINO.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtAITE_MITUMORINO.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtAITE_MITUMORINO.Location = New System.Drawing.Point(91, 75)
        Me.txtAITE_MITUMORINO.MaxLength = 15
        Me.txtAITE_MITUMORINO.Name = "txtAITE_MITUMORINO"
        Me.txtAITE_MITUMORINO.Size = New System.Drawing.Size(110, 17)
        Me.txtAITE_MITUMORINO.TabIndex = 14
        '
        'lblKOUJINO
        '
        Me.lblKOUJINO.AutoSize = True
        Me.lblKOUJINO.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.lblKOUJINO.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblKOUJINO.Location = New System.Drawing.Point(709, 75)
        Me.lblKOUJINO.MinimumSize = New System.Drawing.Size(197, 17)
        Me.lblKOUJINO.Name = "lblKOUJINO"
        Me.lblKOUJINO.Size = New System.Drawing.Size(197, 17)
        Me.lblKOUJINO.TabIndex = 52
        Me.lblKOUJINO.Text = "123456798012345679801234567"
        '
        'lblKOUJINAME
        '
        Me.lblKOUJINAME.AutoSize = True
        Me.lblKOUJINAME.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.lblKOUJINAME.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblKOUJINAME.Location = New System.Drawing.Point(709, 53)
        Me.lblKOUJINAME.MinimumSize = New System.Drawing.Size(197, 17)
        Me.lblKOUJINAME.Name = "lblKOUJINAME"
        Me.lblKOUJINAME.Size = New System.Drawing.Size(197, 17)
        Me.lblKOUJINAME.TabIndex = 51
        Me.lblKOUJINAME.Text = "123456798012345679801234567"
        '
        'txtSIHARAI_COMMENT_05
        '
        Me.txtSIHARAI_COMMENT_05.BackColor = System.Drawing.Color.White
        Me.txtSIHARAI_COMMENT_05.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSIHARAI_COMMENT_05.DisplayName = "支払条件"
        Me.txtSIHARAI_COMMENT_05.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtSIHARAI_COMMENT_05.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtSIHARAI_COMMENT_05.Location = New System.Drawing.Point(498, 115)
        Me.txtSIHARAI_COMMENT_05.MaxLength = 30
        Me.txtSIHARAI_COMMENT_05.Name = "txtSIHARAI_COMMENT_05"
        Me.txtSIHARAI_COMMENT_05.Size = New System.Drawing.Size(142, 24)
        Me.txtSIHARAI_COMMENT_05.TabIndex = 26
        Me.txtSIHARAI_COMMENT_05.Text = "123456789012345678901234567890"
        '
        'txtKEIYAKUNO
        '
        Me.txtKEIYAKUNO.BackColor = System.Drawing.Color.White
        Me.txtKEIYAKUNO.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtKEIYAKUNO.DisplayName = "契約Ｎｏ"
        Me.txtKEIYAKUNO.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtKEIYAKUNO.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtKEIYAKUNO.Location = New System.Drawing.Point(91, 97)
        Me.txtKEIYAKUNO.MaxLength = 15
        Me.txtKEIYAKUNO.Name = "txtKEIYAKUNO"
        Me.txtKEIYAKUNO.Size = New System.Drawing.Size(110, 17)
        Me.txtKEIYAKUNO.TabIndex = 15
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.Label11.Location = New System.Drawing.Point(789, 9)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(13, 17)
        Me.Label11.TabIndex = 105
        Me.Label11.Text = "-"
        '
        'txtSIHARAI_COMMENT_02
        '
        Me.txtSIHARAI_COMMENT_02.BackColor = System.Drawing.Color.White
        Me.txtSIHARAI_COMMENT_02.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSIHARAI_COMMENT_02.DisplayName = "支払条件"
        Me.txtSIHARAI_COMMENT_02.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtSIHARAI_COMMENT_02.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtSIHARAI_COMMENT_02.Location = New System.Drawing.Point(285, 115)
        Me.txtSIHARAI_COMMENT_02.MaxLength = 30
        Me.txtSIHARAI_COMMENT_02.Name = "txtSIHARAI_COMMENT_02"
        Me.txtSIHARAI_COMMENT_02.Size = New System.Drawing.Size(214, 24)
        Me.txtSIHARAI_COMMENT_02.TabIndex = 23
        Me.txtSIHARAI_COMMENT_02.Text = "123456789012345678901234567890"
        '
        'txtSIHARAI_COMMENT_04
        '
        Me.txtSIHARAI_COMMENT_04.BackColor = System.Drawing.Color.White
        Me.txtSIHARAI_COMMENT_04.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSIHARAI_COMMENT_04.DisplayName = "支払条件"
        Me.txtSIHARAI_COMMENT_04.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtSIHARAI_COMMENT_04.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtSIHARAI_COMMENT_04.Location = New System.Drawing.Point(498, 92)
        Me.txtSIHARAI_COMMENT_04.MaxLength = 30
        Me.txtSIHARAI_COMMENT_04.Name = "txtSIHARAI_COMMENT_04"
        Me.txtSIHARAI_COMMENT_04.Size = New System.Drawing.Size(142, 24)
        Me.txtSIHARAI_COMMENT_04.TabIndex = 25
        Me.txtSIHARAI_COMMENT_04.Text = "123456789012345678901234567890"
        '
        'txtJYUTYUEDABAN
        '
        Me.txtJYUTYUEDABAN.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.txtJYUTYUEDABAN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtJYUTYUEDABAN.DigitOnly = True
        Me.txtJYUTYUEDABAN.DisplayName = "受注枝番"
        Me.txtJYUTYUEDABAN.Enabled = False
        Me.txtJYUTYUEDABAN.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.txtJYUTYUEDABAN.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtJYUTYUEDABAN.Location = New System.Drawing.Point(802, 9)
        Me.txtJYUTYUEDABAN.MaxLength = 2
        Me.txtJYUTYUEDABAN.Name = "txtJYUTYUEDABAN"
        Me.txtJYUTYUEDABAN.Size = New System.Drawing.Size(22, 16)
        Me.txtJYUTYUEDABAN.TabIndex = 4
        Me.txtJYUTYUEDABAN.Text = "1234567890123456789012345678901234567890"
        Me.txtJYUTYUEDABAN.UseNullValidator = True
        Me.txtJYUTYUEDABAN.UseZeroPadding = True
        Me.txtJYUTYUEDABAN.ZeroPaddingLength = 2
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.Location = New System.Drawing.Point(167, 53)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(19, 17)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "～"
        '
        'txtSIHARAI_COMMENT_06
        '
        Me.txtSIHARAI_COMMENT_06.BackColor = System.Drawing.Color.White
        Me.txtSIHARAI_COMMENT_06.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSIHARAI_COMMENT_06.DisplayName = "支払条件"
        Me.txtSIHARAI_COMMENT_06.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtSIHARAI_COMMENT_06.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtSIHARAI_COMMENT_06.Location = New System.Drawing.Point(498, 138)
        Me.txtSIHARAI_COMMENT_06.MaxLength = 30
        Me.txtSIHARAI_COMMENT_06.Name = "txtSIHARAI_COMMENT_06"
        Me.txtSIHARAI_COMMENT_06.Size = New System.Drawing.Size(142, 24)
        Me.txtSIHARAI_COMMENT_06.TabIndex = 27
        Me.txtSIHARAI_COMMENT_06.Text = "123456789012345678901234567890"
        '
        'chkHATYUDATE
        '
        Me.chkHATYUDATE.AutoSize = True
        Me.chkHATYUDATE.Location = New System.Drawing.Point(90, 119)
        Me.chkHATYUDATE.Name = "chkHATYUDATE"
        Me.chkHATYUDATE.Size = New System.Drawing.Size(71, 21)
        Me.chkHATYUDATE.TabIndex = 16
        Me.chkHATYUDATE.Text = "印字有り"
        Me.chkHATYUDATE.UseVisualStyleBackColor = True
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label32.Location = New System.Drawing.Point(12, 75)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(74, 17)
        Me.Label32.TabIndex = 3
        Me.Label32.Text = "相手見積Ｎｏ"
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
        Me.txtJYUTYUNO.Location = New System.Drawing.Point(709, 9)
        Me.txtJYUTYUNO.MaxLength = 10
        Me.txtJYUTYUNO.Name = "txtJYUTYUNO"
        Me.txtJYUTYUNO.ReadOnly = True
        Me.txtJYUTYUNO.Size = New System.Drawing.Size(78, 16)
        Me.txtJYUTYUNO.TabIndex = 101
        Me.txtJYUTYUNO.TabStop = False
        Me.txtJYUTYUNO.Text = "1234567890"
        Me.txtJYUTYUNO.UseZeroPadding = True
        Me.txtJYUTYUNO.ZeroPaddingLength = 10
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label10.Location = New System.Drawing.Point(650, 9)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(45, 17)
        Me.Label10.TabIndex = 58
        Me.Label10.Text = "受注No"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label26.Location = New System.Drawing.Point(282, 75)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(52, 17)
        Me.Label26.TabIndex = 18
        Me.Label26.Text = "支払条件"
        '
        'lblTANTONAME
        '
        Me.lblTANTONAME.AutoSize = True
        Me.lblTANTONAME.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.lblTANTONAME.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblTANTONAME.Location = New System.Drawing.Point(709, 31)
        Me.lblTANTONAME.MinimumSize = New System.Drawing.Size(148, 17)
        Me.lblTANTONAME.Name = "lblTANTONAME"
        Me.lblTANTONAME.Size = New System.Drawing.Size(148, 17)
        Me.lblTANTONAME.TabIndex = 51
        Me.lblTANTONAME.Text = "12345678901234567890"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.Location = New System.Drawing.Point(650, 75)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(52, 17)
        Me.Label7.TabIndex = 25
        Me.Label7.Text = "工事番号"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label31.Location = New System.Drawing.Point(12, 97)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(52, 17)
        Me.Label31.TabIndex = 18
        Me.Label31.Text = "契約Ｎｏ"
        '
        'txtNOUKI_END
        '
        Me.txtNOUKI_END.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtNOUKI_END.DisplayName = "工期"
        Me.txtNOUKI_END.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtNOUKI_END.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtNOUKI_END.LinkedDateTextBox = Nothing
        Me.txtNOUKI_END.Location = New System.Drawing.Point(192, 53)
        Me.txtNOUKI_END.Mask = "0000/00/00"
        Me.txtNOUKI_END.Name = "txtNOUKI_END"
        Me.txtNOUKI_END.Size = New System.Drawing.Size(70, 17)
        Me.txtNOUKI_END.TabIndex = 13
        Me.txtNOUKI_END.ValidatingType = GetType(Date)
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.Location = New System.Drawing.Point(650, 97)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 17)
        Me.Label6.TabIndex = 24
        Me.Label6.Text = "工事場所"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 17)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "工期"
        '
        'txtNOUKI_START
        '
        Me.txtNOUKI_START.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtNOUKI_START.DisplayName = "工期"
        Me.txtNOUKI_START.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtNOUKI_START.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtNOUKI_START.LinkedDateTextBox = Nothing
        Me.txtNOUKI_START.Location = New System.Drawing.Point(91, 53)
        Me.txtNOUKI_START.Mask = "0000/00/00"
        Me.txtNOUKI_START.Name = "txtNOUKI_START"
        Me.txtNOUKI_START.Size = New System.Drawing.Size(70, 17)
        Me.txtNOUKI_START.TabIndex = 12
        Me.txtNOUKI_START.ValidatingType = GetType(Date)
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.Location = New System.Drawing.Point(650, 31)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 17)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "担当者"
        '
        'txtKEISYOUNAME
        '
        Me.txtKEISYOUNAME.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.txtKEISYOUNAME.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtKEISYOUNAME.Enabled = False
        Me.txtKEISYOUNAME.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.txtKEISYOUNAME.Location = New System.Drawing.Point(414, 53)
        Me.txtKEISYOUNAME.MaxLength = 6
        Me.txtKEISYOUNAME.Name = "txtKEISYOUNAME"
        Me.txtKEISYOUNAME.ReadOnly = True
        Me.txtKEISYOUNAME.Size = New System.Drawing.Size(78, 16)
        Me.txtKEISYOUNAME.TabIndex = 89
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(650, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 17)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "工事名称"
        '
        'txtKEISYOUCODE
        '
        Me.txtKEISYOUCODE.AutoValidate = System.Windows.Forms.AutoValidate.Disable
        Me.txtKEISYOUCODE.DisplayName = "敬称"
        Me.txtKEISYOUCODE.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.txtKEISYOUCODE.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtKEISYOUCODE.LinkedTextBox = Me.txtKEISYOUNAME
        Me.txtKEISYOUCODE.Location = New System.Drawing.Point(374, 53)
        Me.txtKEISYOUCODE.MaxLength = 1
        Me.txtKEISYOUCODE.Name = "txtKEISYOUCODE"
        Me.txtKEISYOUCODE.Size = New System.Drawing.Size(34, 18)
        Me.txtKEISYOUCODE.TabIndex = 21
        Me.txtKEISYOUCODE.UseMasterCheckValidator = True
        Me.txtKEISYOUCODE.UseUpdateLinkedTextByCodeChange = True
        '
        'Label56
        '
        Me.Label56.AutoSize = True
        Me.Label56.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label56.Location = New System.Drawing.Point(282, 53)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(30, 17)
        Me.Label56.TabIndex = 74
        Me.Label56.Text = "敬称"
        '
        'lblJYUTYUNO
        '
        Me.lblJYUTYUNO.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.lblJYUTYUNO.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lblJYUTYUNO.DisplayName = "受注Ｎｏ"
        Me.lblJYUTYUNO.Enabled = False
        Me.lblJYUTYUNO.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.lblJYUTYUNO.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.lblJYUTYUNO.Location = New System.Drawing.Point(905, 12)
        Me.lblJYUTYUNO.MaxLength = 10
        Me.lblJYUTYUNO.Name = "lblJYUTYUNO"
        Me.lblJYUTYUNO.ReadOnly = True
        Me.lblJYUTYUNO.Size = New System.Drawing.Size(94, 16)
        Me.lblJYUTYUNO.TabIndex = 104
        Me.lblJYUTYUNO.Text = "1234567890-01"
        Me.lblJYUTYUNO.Visible = False
        '
        'txtZeiKbn
        '
        Me.txtZeiKbn.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtZeiKbn.DisplayName = "締日"
        Me.txtZeiKbn.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.txtZeiKbn.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtZeiKbn.Location = New System.Drawing.Point(740, 12)
        Me.txtZeiKbn.MaxLength = 2
        Me.txtZeiKbn.MaxValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtZeiKbn.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtZeiKbn.Name = "txtZeiKbn"
        Me.txtZeiKbn.NumberFormat = ""
        Me.txtZeiKbn.Size = New System.Drawing.Size(30, 16)
        Me.txtZeiKbn.TabIndex = 92
        Me.txtZeiKbn.Text = "99"
        Me.txtZeiKbn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtZeiKbn.Value = New Decimal(New Integer() {99, 0, 0, 0})
        Me.txtZeiKbn.Visible = False
        '
        'Label25
        '
        Me.Label25.BackColor = System.Drawing.Color.DarkSlateBlue
        Me.Label25.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label25.ForeColor = System.Drawing.SystemColors.Window
        Me.Label25.Location = New System.Drawing.Point(0, 44)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(1018, 18)
        Me.Label25.TabIndex = 93
        Me.Label25.Text = "基本情報"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dbgMeisai
        '
        Me.dbgMeisai.BackColor = System.Drawing.Color.Thistle
        Me.dbgMeisai.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.dbgMeisai.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dbgMeisai.CaptionHeight = 16
        Me.dbgMeisai.Cursor = System.Windows.Forms.Cursors.Default
        Me.dbgMeisai.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.dbgMeisai.GroupByCaption = "列でグループ化するには、ここに列ヘッダをドラッグします。"
        Me.dbgMeisai.Images.Add(CType(resources.GetObject("dbgMeisai.Images"), System.Drawing.Image))
        Me.dbgMeisai.Location = New System.Drawing.Point(0, 235)
        Me.dbgMeisai.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow
        Me.dbgMeisai.Name = "dbgMeisai"
        Me.dbgMeisai.PreviewInfo.Caption = "印刷プレビューウィンドウ"
        Me.dbgMeisai.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.dbgMeisai.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.dbgMeisai.PreviewInfo.ZoomFactor = 75.0R
        Me.dbgMeisai.PrintInfo.PageSettings = CType(resources.GetObject("dbgMeisai.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.dbgMeisai.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.dbgMeisai.RowDivider.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.None
        Me.dbgMeisai.RowHeight = 14
        Me.dbgMeisai.Size = New System.Drawing.Size(1018, 365)
        Me.dbgMeisai.TabIndex = 200
        Me.dbgMeisai.TabStop = False
        Me.dbgMeisai.UseCompatibleTextRendering = False
        Me.dbgMeisai.PropBag = resources.GetString("dbgMeisai.PropBag")
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("メイリオ", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label15.Location = New System.Drawing.Point(619, 13)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(85, 12)
        Me.Label15.TabIndex = 56
        Me.Label15.Text = "数量小数点以下桁数："
        Me.Label15.Visible = False
        '
        'lblSURYO_SYOSUIKAKETA
        '
        Me.lblSURYO_SYOSUIKAKETA.BackColor = System.Drawing.Color.Yellow
        Me.lblSURYO_SYOSUIKAKETA.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblSURYO_SYOSUIKAKETA.ForeColor = System.Drawing.Color.Black
        Me.lblSURYO_SYOSUIKAKETA.Location = New System.Drawing.Point(699, 11)
        Me.lblSURYO_SYOSUIKAKETA.Name = "lblSURYO_SYOSUIKAKETA"
        Me.lblSURYO_SYOSUIKAKETA.Size = New System.Drawing.Size(23, 17)
        Me.lblSURYO_SYOSUIKAKETA.TabIndex = 57
        Me.lblSURYO_SYOSUIKAKETA.Text = "0"
        Me.lblSURYO_SYOSUIKAKETA.Visible = False
        '
        'fraMeisaikei
        '
        Me.fraMeisaikei.BackColor = System.Drawing.Color.DarkSlateBlue
        Me.fraMeisaikei.Controls.Add(Me.lblGKGENKAGAKU_NUKIBefore)
        Me.fraMeisaikei.Controls.Add(Me.lblGKGENKAGAKU)
        Me.fraMeisaikei.Controls.Add(Me.lblGKTAX)
        Me.fraMeisaikei.Controls.Add(Me.lblGKGENKAGAKU_NUKI)
        Me.fraMeisaikei.Controls.Add(Me.lblGKGENKA)
        Me.fraMeisaikei.Controls.Add(Me.lblTAX)
        Me.fraMeisaikei.Controls.Add(Me.Label16)
        Me.fraMeisaikei.Controls.Add(Me.Label18)
        Me.fraMeisaikei.Location = New System.Drawing.Point(1, 583)
        Me.fraMeisaikei.Name = "fraMeisaikei"
        Me.fraMeisaikei.Size = New System.Drawing.Size(1017, 17)
        Me.fraMeisaikei.TabIndex = 201
        '
        'lblGKGENKAGAKU_NUKIBefore
        '
        Me.lblGKGENKAGAKU_NUKIBefore.BackColor = System.Drawing.Color.Yellow
        Me.lblGKGENKAGAKU_NUKIBefore.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblGKGENKAGAKU_NUKIBefore.ForeColor = System.Drawing.Color.Black
        Me.lblGKGENKAGAKU_NUKIBefore.Location = New System.Drawing.Point(192, 0)
        Me.lblGKGENKAGAKU_NUKIBefore.Name = "lblGKGENKAGAKU_NUKIBefore"
        Me.lblGKGENKAGAKU_NUKIBefore.Size = New System.Drawing.Size(78, 16)
        Me.lblGKGENKAGAKU_NUKIBefore.TabIndex = 54
        Me.lblGKGENKAGAKU_NUKIBefore.Text = "100,000,000"
        Me.lblGKGENKAGAKU_NUKIBefore.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblGKGENKAGAKU_NUKIBefore.Visible = False
        '
        'lblGKGENKAGAKU
        '
        Me.lblGKGENKAGAKU.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblGKGENKAGAKU.ForeColor = System.Drawing.Color.White
        Me.lblGKGENKAGAKU.Location = New System.Drawing.Point(640, 0)
        Me.lblGKGENKAGAKU.Name = "lblGKGENKAGAKU"
        Me.lblGKGENKAGAKU.Size = New System.Drawing.Size(78, 16)
        Me.lblGKGENKAGAKU.TabIndex = 53
        Me.lblGKGENKAGAKU.Text = "100,000,000"
        Me.lblGKGENKAGAKU.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblGKTAX
        '
        Me.lblGKTAX.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblGKTAX.ForeColor = System.Drawing.Color.White
        Me.lblGKTAX.Location = New System.Drawing.Point(465, 2)
        Me.lblGKTAX.Name = "lblGKTAX"
        Me.lblGKTAX.Size = New System.Drawing.Size(78, 16)
        Me.lblGKTAX.TabIndex = 52
        Me.lblGKTAX.Text = "100,000,000"
        Me.lblGKTAX.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblGKGENKAGAKU_NUKI
        '
        Me.lblGKGENKAGAKU_NUKI.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblGKGENKAGAKU_NUKI.ForeColor = System.Drawing.Color.White
        Me.lblGKGENKAGAKU_NUKI.Location = New System.Drawing.Point(323, 0)
        Me.lblGKGENKAGAKU_NUKI.Name = "lblGKGENKAGAKU_NUKI"
        Me.lblGKGENKAGAKU_NUKI.Size = New System.Drawing.Size(78, 16)
        Me.lblGKGENKAGAKU_NUKI.TabIndex = 51
        Me.lblGKGENKAGAKU_NUKI.Text = "100,000,000"
        Me.lblGKGENKAGAKU_NUKI.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblGKGENKA
        '
        Me.lblGKGENKA.AutoSize = True
        Me.lblGKGENKA.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.lblGKGENKA.ForeColor = System.Drawing.Color.White
        Me.lblGKGENKA.Location = New System.Drawing.Point(549, 1)
        Me.lblGKGENKA.Name = "lblGKGENKA"
        Me.lblGKGENKA.Size = New System.Drawing.Size(85, 17)
        Me.lblGKGENKA.TabIndex = 13
        Me.lblGKGENKA.Text = "原価金額合計："
        '
        'lblTAX
        '
        Me.lblTAX.AutoSize = True
        Me.lblTAX.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.lblTAX.ForeColor = System.Drawing.Color.White
        Me.lblTAX.Location = New System.Drawing.Point(407, 1)
        Me.lblTAX.Name = "lblTAX"
        Me.lblTAX.Size = New System.Drawing.Size(63, 17)
        Me.lblTAX.TabIndex = 13
        Me.lblTAX.Text = "内消費税："
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(276, 1)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(41, 17)
        Me.Label16.TabIndex = 1
        Me.Label16.Text = "小計："
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.White
        Me.Label18.Location = New System.Drawing.Point(123, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(63, 17)
        Me.Label18.TabIndex = 18
        Me.Label18.Text = "変更前小計"
        Me.Label18.Visible = False
        '
        'frmHAT0001
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 670)
        Me.Controls.Add(Me.lblSURYO_SYOSUIKAKETA)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.lblHATYUNO)
        Me.Controls.Add(Me.fraMeisaikei)
        Me.Controls.Add(Me.lblJYUTYUNO)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.txtZeiKbn)
        Me.Controls.Add(Me.dbgMeisai)
        Me.Controls.Add(Me.pnl対象下請情報)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmHAT0001"
        Me.Text = ""
        Me.Controls.SetChildIndex(Me.pnl対象下請情報, 0)
        Me.Controls.SetChildIndex(Me.TitleBar, 0)
        Me.Controls.SetChildIndex(Me.dbgMeisai, 0)
        Me.Controls.SetChildIndex(Me.txtZeiKbn, 0)
        Me.Controls.SetChildIndex(Me.Label25, 0)
        Me.Controls.SetChildIndex(Me.lblJYUTYUNO, 0)
        Me.Controls.SetChildIndex(Me.FunctionKey, 0)
        Me.Controls.SetChildIndex(Me.fraMeisaikei, 0)
        Me.Controls.SetChildIndex(Me.lblHATYUNO, 0)
        Me.Controls.SetChildIndex(Me.Label15, 0)
        Me.Controls.SetChildIndex(Me.lblSURYO_SYOSUIKAKETA, 0)
        Me.pnl対象下請情報.ResumeLayout(False)
        Me.pnl対象下請情報.PerformLayout()
        CType(Me.dbgMeisai, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fraMeisaikei.ResumeLayout(False)
        Me.fraMeisaikei.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtHATYUDATE As CommonUtility.WinFormControls.DateTextBoxEx
    Friend WithEvents pnl対象下請情報 As System.Windows.Forms.Panel
    Friend WithEvents txtSIIRENAME As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents lblHATYUDATE As System.Windows.Forms.Label
    Friend WithEvents txtKEISYOUNAME As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents txtKEISYOUCODE As CommonUtility.WinFormControls.TypComboBox
    Private WithEvents Label33 As System.Windows.Forms.Label
    Private WithEvents Label37 As System.Windows.Forms.Label
    Private WithEvents Label26 As System.Windows.Forms.Label
    Private WithEvents Label56 As System.Windows.Forms.Label
    Friend WithEvents txtSIHARAI_COMMENT_01 As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents txtSIHARAI_COMMENT_03 As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents txtSIHARAI_COMMENT_05 As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents txtSIHARAI_COMMENT_02 As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents txtSIHARAI_COMMENT_04 As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents txtSIHARAI_COMMENT_06 As CommonUtility.WinFormControls.TextBoxEx
    Private WithEvents Label17 As Windows.Forms.Label
    Friend WithEvents txtHATYUNO As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents txtSIIRECODE As CommonUtility.WinFormControls.TypComboBox
    Private WithEvents Label27 As Windows.Forms.Label
    Friend WithEvents txtZeiKbn As CommonUtility.WinFormControls.NumberTextBoxEx
    Friend WithEvents Label25 As Windows.Forms.Label
    Friend WithEvents Label13 As Label
    Friend WithEvents txtHATYUEDABAN As CommonUtility.WinFormControls.TextBoxEx
    Private WithEvents Label6 As Label
    Private WithEvents Label4 As Label
    Private WithEvents Label7 As Label
    Private WithEvents Label2 As Label
    Protected WithEvents dbgMeisai As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Private WithEvents Label32 As Label
    Friend WithEvents lblTANTONAME As Label
    Private WithEvents Label31 As Label
    Friend WithEvents lblKOUJINAME As Label
    Friend WithEvents lblKOUJINO As Label
    Friend WithEvents txtNOUKI_START As CommonUtility.WinFormControls.DateTextBoxEx
    Friend WithEvents lblKOUJIBASYO As Label
    Private WithEvents Label1 As Label
    Private WithEvents Label15 As Label
    Friend WithEvents txtNOUKI_END As CommonUtility.WinFormControls.DateTextBoxEx
    Private WithEvents lblSURYO_SYOSUIKAKETA As Label
    Friend WithEvents txtAITE_MITUMORINO As CommonUtility.WinFormControls.TextBoxEx
    Private WithEvents Label10 As Label
    Friend WithEvents txtKEIYAKUNO As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents txtJYUTYUNO As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents Label9 As Label
    Friend WithEvents lblJYUTYUNO As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents txtJYUTYUEDABAN As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents chkHATYUDATE As CheckBox
    Friend WithEvents Label11 As Label
    Private WithEvents Label12 As Label
    Friend WithEvents cmbHATTYUNO As CommonUtility.WinFormControls.MitumoriNoComboBox
    Friend WithEvents Label14 As Label
    Friend WithEvents txtHATYUEDABAN2 As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents fraMeisaikei As Panel
    Friend WithEvents lblGKGENKAGAKU_NUKIBefore As Label
    Friend WithEvents lblGKGENKAGAKU As Label
    Friend WithEvents lblGKTAX As Label
    Friend WithEvents lblGKGENKAGAKU_NUKI As Label
    Friend WithEvents lblGKGENKA As Label
    Friend WithEvents lblTAX As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents lblHATYUNO As CommonUtility.WinFormControls.TextBoxEx
End Class
