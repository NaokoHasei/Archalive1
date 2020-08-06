<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSEI0001
    Inherits winformbase.Formbase

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSEI0001))
        Me.Label18 = New System.Windows.Forms.Label()
        Me.fraHeader = New System.Windows.Forms.Panel()
        Me.txtSeikyuEdaban = New CommonUtility.WinFormControls.MitumoriNoTextBoxEx()
        Me.cmbSeikyuNo = New CommonUtility.WinFormControls.MitumoriNoComboBox()
        Me.lblSEIKYUNO = New CommonUtility.WinFormControls.TextBoxEx()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtSeikyuNo = New CommonUtility.WinFormControls.TextBoxEx()
        Me.txtKokyakuCode = New CommonUtility.WinFormControls.TextBoxEx()
        Me.lblTANTOCODE = New System.Windows.Forms.Label()
        Me.lblTANTONAME = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtKeisyoName = New CommonUtility.WinFormControls.TextBoxEx()
        Me.txtKeisyo = New CommonUtility.WinFormControls.TypComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtKokyakuName = New CommonUtility.WinFormControls.TextBoxEx()
        Me.txtSeikyuDateDisp = New CommonUtility.WinFormControls.DateTextBoxEx()
        Me.txtSeikyuDate = New CommonUtility.WinFormControls.DateTextBoxEx()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblFAX = New System.Windows.Forms.Label()
        Me.lblDenwa = New System.Windows.Forms.Label()
        Me.lblJyusyo = New System.Windows.Forms.Label()
        Me.lblYubin = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.tpnlKouziInfo = New System.Windows.Forms.TableLayoutPanel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblInfo_JyutyuKingaku = New System.Windows.Forms.Label()
        Me.lblInfo_Syohizei = New System.Windows.Forms.Label()
        Me.Label59 = New System.Windows.Forms.Label()
        Me.lblInfo_Syokei = New System.Windows.Forms.Label()
        Me.Label57 = New System.Windows.Forms.Label()
        Me.lblInfo_Nouki1 = New System.Windows.Forms.Label()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.lblInfo_KouziBasyo = New System.Windows.Forms.Label()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.lblInfo_KouziNumber = New System.Windows.Forms.Label()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.lblInfo_KouziName = New System.Windows.Forms.Label()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.lblInfo_Kokyaku = New System.Windows.Forms.Label()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.lblInfo_Tanto = New System.Windows.Forms.Label()
        Me.lblInfo_MitumoriNo = New System.Windows.Forms.Label()
        Me.lblInfo_JyutyuDate = New System.Windows.Forms.Label()
        Me.lblInfo_JyutyuNo = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.tpnlGokeiKin = New System.Windows.Forms.TableLayoutPanel()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtKonMadeJyuryoGaku = New CommonUtility.WinFormControls.NumberTextBoxEx()
        Me.txtBiko = New CommonUtility.WinFormControls.TextBoxEx()
        Me.dbgMEISAI = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnlSeikyu = New System.Windows.Forms.Panel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtHoryukinKonkai = New CommonUtility.WinFormControls.NumberTextBoxEx()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtHoryukin = New CommonUtility.WinFormControls.NumberTextBoxEx()
        Me.lblKurikoshiZan = New System.Windows.Forms.Label()
        Me.txtKurikoshiZan = New CommonUtility.WinFormControls.NumberTextBoxEx()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnMeisaiInput = New CommonUtility.WinFormControls.KobetuSentakuButton()
        Me.rdoSeikyuHouhou_0 = New System.Windows.Forms.RadioButton()
        Me.rdoSeikyuHouhou_1 = New System.Windows.Forms.RadioButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtJyutyuEdaban = New CommonUtility.WinFormControls.TextBoxEx()
        Me.lblSyosu = New System.Windows.Forms.Label()
        Me.fraHeader.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.tpnlKouziInfo.SuspendLayout()
        Me.tpnlGokeiKin.SuspendLayout()
        CType(Me.dbgMEISAI, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlSeikyu.SuspendLayout()
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
        Me.FunctionKey.Location = New System.Drawing.Point(0, 609)
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.DarkSlateBlue
        Me.Label18.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.White
        Me.Label18.Location = New System.Drawing.Point(4, 46)
        Me.Label18.MinimumSize = New System.Drawing.Size(1009, 17)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(1009, 17)
        Me.Label18.TabIndex = 23
        Me.Label18.Text = "基本情報"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'fraHeader
        '
        Me.fraHeader.BackColor = System.Drawing.Color.Thistle
        Me.fraHeader.Controls.Add(Me.txtSeikyuEdaban)
        Me.fraHeader.Controls.Add(Me.Label13)
        Me.fraHeader.Controls.Add(Me.txtSeikyuNo)
        Me.fraHeader.Controls.Add(Me.cmbSeikyuNo)
        Me.fraHeader.Controls.Add(Me.txtKokyakuCode)
        Me.fraHeader.Controls.Add(Me.lblTANTOCODE)
        Me.fraHeader.Controls.Add(Me.lblTANTONAME)
        Me.fraHeader.Controls.Add(Me.Label4)
        Me.fraHeader.Controls.Add(Me.txtKeisyoName)
        Me.fraHeader.Controls.Add(Me.txtKeisyo)
        Me.fraHeader.Controls.Add(Me.Label11)
        Me.fraHeader.Controls.Add(Me.txtKokyakuName)
        Me.fraHeader.Controls.Add(Me.txtSeikyuDateDisp)
        Me.fraHeader.Controls.Add(Me.txtSeikyuDate)
        Me.fraHeader.Controls.Add(Me.Panel1)
        Me.fraHeader.Controls.Add(Me.Label17)
        Me.fraHeader.Controls.Add(Me.Label15)
        Me.fraHeader.Controls.Add(Me.Label2)
        Me.fraHeader.Location = New System.Drawing.Point(4, 62)
        Me.fraHeader.Name = "fraHeader"
        Me.fraHeader.Size = New System.Drawing.Size(505, 84)
        Me.fraHeader.TabIndex = 0
        '
        'txtSeikyuEdaban
        '
        Me.txtSeikyuEdaban.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSeikyuEdaban.DigitOnly = True
        Me.txtSeikyuEdaban.DisplayName = "請求枝番"
        Me.txtSeikyuEdaban.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.txtSeikyuEdaban.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtSeikyuEdaban.LinkedComboBox = Me.cmbSeikyuNo
        Me.txtSeikyuEdaban.Location = New System.Drawing.Point(162, 8)
        Me.txtSeikyuEdaban.MaxLength = 2
        Me.txtSeikyuEdaban.Name = "txtSeikyuEdaban"
        Me.txtSeikyuEdaban.Size = New System.Drawing.Size(22, 16)
        Me.txtSeikyuEdaban.TabIndex = 1
        Me.txtSeikyuEdaban.Text = "1234567890123456789012345678901234567890"
        Me.txtSeikyuEdaban.UseZeroPadding = True
        Me.txtSeikyuEdaban.ZeroPaddingLength = 2
        '
        'cmbSeikyuNo
        '
        Me.cmbSeikyuNo.DisplayName = "請求Ｎｏ"
        Me.cmbSeikyuNo.LinkedTextBox = Me.lblSEIKYUNO
        Me.cmbSeikyuNo.Location = New System.Drawing.Point(184, 8)
        Me.cmbSeikyuNo.Margin = New System.Windows.Forms.Padding(3, 8, 3, 8)
        Me.cmbSeikyuNo.MaxLength = 32767
        Me.cmbSeikyuNo.Name = "cmbSeikyuNo"
        Me.cmbSeikyuNo.PopupErrorDialog = False
        Me.cmbSeikyuNo.Size = New System.Drawing.Size(20, 18)
        Me.cmbSeikyuNo.TabIndex = 96
        Me.cmbSeikyuNo.TabStop = False
        Me.cmbSeikyuNo.UseUpdateLinkedTextByCodeChange = True
        '
        'lblSEIKYUNO
        '
        Me.lblSEIKYUNO.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.lblSEIKYUNO.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lblSEIKYUNO.DisplayName = "見積Ｎｏ"
        Me.lblSEIKYUNO.Enabled = False
        Me.lblSEIKYUNO.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.lblSEIKYUNO.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.lblSEIKYUNO.Location = New System.Drawing.Point(166, 47)
        Me.lblSEIKYUNO.MaxLength = 10
        Me.lblSEIKYUNO.Name = "lblSEIKYUNO"
        Me.lblSEIKYUNO.ReadOnly = True
        Me.lblSEIKYUNO.Size = New System.Drawing.Size(94, 16)
        Me.lblSEIKYUNO.TabIndex = 97
        Me.lblSEIKYUNO.Text = "1234567890-01"
        Me.lblSEIKYUNO.Visible = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.Label13.Location = New System.Drawing.Point(148, 8)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(13, 17)
        Me.Label13.TabIndex = 94
        Me.Label13.Text = "-"
        '
        'txtSeikyuNo
        '
        Me.txtSeikyuNo.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.txtSeikyuNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSeikyuNo.DigitOnly = True
        Me.txtSeikyuNo.DisplayName = "見積Ｎｏ"
        Me.txtSeikyuNo.Enabled = False
        Me.txtSeikyuNo.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.txtSeikyuNo.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtSeikyuNo.Location = New System.Drawing.Point(70, 8)
        Me.txtSeikyuNo.MaxLength = 10
        Me.txtSeikyuNo.Name = "txtSeikyuNo"
        Me.txtSeikyuNo.Size = New System.Drawing.Size(78, 16)
        Me.txtSeikyuNo.TabIndex = 93
        Me.txtSeikyuNo.Text = "1234567890"
        Me.txtSeikyuNo.UseZeroPadding = True
        Me.txtSeikyuNo.ZeroPaddingLength = 10
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
        Me.txtKokyakuCode.Location = New System.Drawing.Point(70, 58)
        Me.txtKokyakuCode.MaxLength = 10
        Me.txtKokyakuCode.Name = "txtKokyakuCode"
        Me.txtKokyakuCode.ReadOnly = True
        Me.txtKokyakuCode.Size = New System.Drawing.Size(78, 16)
        Me.txtKokyakuCode.TabIndex = 92
        Me.txtKokyakuCode.TabStop = False
        Me.txtKokyakuCode.Text = "1234567890123456789012345678901234567890"
        Me.txtKokyakuCode.UseZeroPadding = True
        Me.txtKokyakuCode.ZeroPaddingLength = 8
        '
        'lblTANTOCODE
        '
        Me.lblTANTOCODE.AutoSize = True
        Me.lblTANTOCODE.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblTANTOCODE.Location = New System.Drawing.Point(259, 8)
        Me.lblTANTOCODE.Name = "lblTANTOCODE"
        Me.lblTANTOCODE.Size = New System.Drawing.Size(36, 17)
        Me.lblTANTOCODE.TabIndex = 61
        Me.lblTANTOCODE.Text = "9999"
        '
        'lblTANTONAME
        '
        Me.lblTANTONAME.AutoSize = True
        Me.lblTANTONAME.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblTANTONAME.Location = New System.Drawing.Point(301, 8)
        Me.lblTANTONAME.Name = "lblTANTONAME"
        Me.lblTANTONAME.Size = New System.Drawing.Size(197, 17)
        Me.lblTANTONAME.TabIndex = 60
        Me.lblTANTONAME.Text = "123456798012345679801234567"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.Location = New System.Drawing.Point(214, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 17)
        Me.Label4.TabIndex = 59
        Me.Label4.Text = "担当者："
        '
        'txtKeisyoName
        '
        Me.txtKeisyoName.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.txtKeisyoName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtKeisyoName.Enabled = False
        Me.txtKeisyoName.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.txtKeisyoName.Location = New System.Drawing.Point(454, 59)
        Me.txtKeisyoName.Margin = New System.Windows.Forms.Padding(0, 3, 3, 3)
        Me.txtKeisyoName.MaxLength = 6
        Me.txtKeisyoName.Name = "txtKeisyoName"
        Me.txtKeisyoName.ReadOnly = True
        Me.txtKeisyoName.Size = New System.Drawing.Size(46, 16)
        Me.txtKeisyoName.TabIndex = 58
        '
        'txtKeisyo
        '
        Me.txtKeisyo.AutoValidate = System.Windows.Forms.AutoValidate.Disable
        Me.txtKeisyo.DisplayName = "敬称"
        Me.txtKeisyo.Font = New System.Drawing.Font("メイリオ", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtKeisyo.LinkedTextBox = Me.txtKeisyoName
        Me.txtKeisyo.Location = New System.Drawing.Point(420, 59)
        Me.txtKeisyo.MaxLength = 1
        Me.txtKeisyo.Name = "txtKeisyo"
        Me.txtKeisyo.Size = New System.Drawing.Size(34, 18)
        Me.txtKeisyo.TabIndex = 3
        Me.txtKeisyo.UseMasterCheckValidator = True
        Me.txtKeisyo.UseUpdateLinkedTextByCodeChange = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.Label11.Location = New System.Drawing.Point(381, 59)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(30, 17)
        Me.Label11.TabIndex = 52
        Me.Label11.Text = "敬称"
        '
        'txtKokyakuName
        '
        Me.txtKokyakuName.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.txtKokyakuName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtKokyakuName.Enabled = False
        Me.txtKokyakuName.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.txtKokyakuName.Location = New System.Drawing.Point(153, 58)
        Me.txtKokyakuName.Margin = New System.Windows.Forms.Padding(0, 3, 3, 3)
        Me.txtKokyakuName.MaxLength = 40
        Me.txtKokyakuName.Name = "txtKokyakuName"
        Me.txtKokyakuName.ReadOnly = True
        Me.txtKokyakuName.Size = New System.Drawing.Size(222, 16)
        Me.txtKokyakuName.TabIndex = 51
        '
        'txtSeikyuDateDisp
        '
        Me.txtSeikyuDateDisp.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.txtSeikyuDateDisp.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSeikyuDateDisp.Enabled = False
        Me.txtSeikyuDateDisp.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.txtSeikyuDateDisp.LinkedDateTextBox = Nothing
        Me.txtSeikyuDateDisp.Location = New System.Drawing.Point(143, 33)
        Me.txtSeikyuDateDisp.Margin = New System.Windows.Forms.Padding(0, 3, 3, 3)
        Me.txtSeikyuDateDisp.Mask = "(AA90年)"
        Me.txtSeikyuDateDisp.Name = "txtSeikyuDateDisp"
        Me.txtSeikyuDateDisp.PopupErrorDialog = False
        Me.txtSeikyuDateDisp.ReadOnly = True
        Me.txtSeikyuDateDisp.Size = New System.Drawing.Size(70, 16)
        Me.txtSeikyuDateDisp.TabIndex = 4
        Me.txtSeikyuDateDisp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtSeikyuDateDisp.ValidatingType = GetType(Date)
        '
        'txtSeikyuDate
        '
        Me.txtSeikyuDate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSeikyuDate.DisplayName = "請求日付"
        Me.txtSeikyuDate.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.txtSeikyuDate.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtSeikyuDate.LinkedDateTextBox = Nothing
        Me.txtSeikyuDate.Location = New System.Drawing.Point(70, 33)
        Me.txtSeikyuDate.Mask = "0000/00/00"
        Me.txtSeikyuDate.Name = "txtSeikyuDate"
        Me.txtSeikyuDate.Size = New System.Drawing.Size(70, 16)
        Me.txtSeikyuDate.TabIndex = 2
        Me.txtSeikyuDate.Text = "20150210"
        Me.txtSeikyuDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtSeikyuDate.UseNullValidator = True
        Me.txtSeikyuDate.ValidatingType = GetType(Date)
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Location = New System.Drawing.Point(504, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(505, 84)
        Me.Panel1.TabIndex = 45
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.Label17.Location = New System.Drawing.Point(7, 59)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(52, 17)
        Me.Label17.TabIndex = 15
        Me.Label17.Text = "元　　請"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.Label15.Location = New System.Drawing.Point(7, 33)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(52, 17)
        Me.Label15.TabIndex = 12
        Me.Label15.Text = "請求日付"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.Label2.Location = New System.Drawing.Point(7, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 17)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "請求Ｎｏ"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Thistle
        Me.Panel2.Controls.Add(Me.lblFAX)
        Me.Panel2.Controls.Add(Me.lblDenwa)
        Me.Panel2.Controls.Add(Me.lblJyusyo)
        Me.Panel2.Controls.Add(Me.lblYubin)
        Me.Panel2.Controls.Add(Me.Label22)
        Me.Panel2.Controls.Add(Me.Label23)
        Me.Panel2.Controls.Add(Me.Label24)
        Me.Panel2.Controls.Add(Me.Label25)
        Me.Panel2.Location = New System.Drawing.Point(508, 63)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(505, 83)
        Me.Panel2.TabIndex = 24
        '
        'lblFAX
        '
        Me.lblFAX.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblFAX.Location = New System.Drawing.Point(272, 59)
        Me.lblFAX.Name = "lblFAX"
        Me.lblFAX.Size = New System.Drawing.Size(130, 17)
        Me.lblFAX.TabIndex = 19
        Me.lblFAX.Text = "XXXXXXXXXXXXXXX"
        Me.lblFAX.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDenwa
        '
        Me.lblDenwa.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblDenwa.Location = New System.Drawing.Point(71, 60)
        Me.lblDenwa.Name = "lblDenwa"
        Me.lblDenwa.Size = New System.Drawing.Size(130, 17)
        Me.lblDenwa.TabIndex = 18
        Me.lblDenwa.Text = "XXXXXXXXXXXXXXX"
        Me.lblDenwa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblJyusyo
        '
        Me.lblJyusyo.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblJyusyo.Location = New System.Drawing.Point(71, 34)
        Me.lblJyusyo.Name = "lblJyusyo"
        Me.lblJyusyo.Size = New System.Drawing.Size(426, 17)
        Me.lblJyusyo.TabIndex = 17
        Me.lblJyusyo.Text = "ＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸＸ"
        Me.lblJyusyo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblYubin
        '
        Me.lblYubin.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblYubin.Location = New System.Drawing.Point(71, 10)
        Me.lblYubin.Name = "lblYubin"
        Me.lblYubin.Size = New System.Drawing.Size(63, 17)
        Me.lblYubin.TabIndex = 16
        Me.lblYubin.Text = "999-9999"
        Me.lblYubin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.Label22.Location = New System.Drawing.Point(7, 59)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(63, 17)
        Me.Label22.TabIndex = 15
        Me.Label22.Text = "電話番号："
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.Label23.Location = New System.Drawing.Point(203, 59)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(67, 17)
        Me.Label23.TabIndex = 14
        Me.Label23.Text = " 　ＦＡＸ："
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.Label24.Location = New System.Drawing.Point(7, 33)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(63, 17)
        Me.Label24.TabIndex = 12
        Me.Label24.Text = "住　　所："
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.Label25.Location = New System.Drawing.Point(7, 9)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(63, 17)
        Me.Label25.TabIndex = 1
        Me.Label25.Text = "郵便番号："
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.DarkSlateBlue
        Me.Label12.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(4, 157)
        Me.Label12.MinimumSize = New System.Drawing.Size(411, 17)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(411, 17)
        Me.Label12.TabIndex = 40
        Me.Label12.Text = "受注情報"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Thistle
        Me.Panel3.Controls.Add(Me.tpnlKouziInfo)
        Me.Panel3.Location = New System.Drawing.Point(4, 174)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel3.Size = New System.Drawing.Size(411, 299)
        Me.Panel3.TabIndex = 41
        '
        'tpnlKouziInfo
        '
        Me.tpnlKouziInfo.BackColor = System.Drawing.Color.Thistle
        Me.tpnlKouziInfo.ColumnCount = 2
        Me.tpnlKouziInfo.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.00079!))
        Me.tpnlKouziInfo.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 79.99921!))
        Me.tpnlKouziInfo.Controls.Add(Me.Label7, 0, 11)
        Me.tpnlKouziInfo.Controls.Add(Me.lblInfo_JyutyuKingaku, 0, 11)
        Me.tpnlKouziInfo.Controls.Add(Me.lblInfo_Syohizei, 1, 10)
        Me.tpnlKouziInfo.Controls.Add(Me.Label59, 0, 10)
        Me.tpnlKouziInfo.Controls.Add(Me.lblInfo_Syokei, 1, 9)
        Me.tpnlKouziInfo.Controls.Add(Me.Label57, 0, 9)
        Me.tpnlKouziInfo.Controls.Add(Me.lblInfo_Nouki1, 1, 8)
        Me.tpnlKouziInfo.Controls.Add(Me.Label53, 0, 8)
        Me.tpnlKouziInfo.Controls.Add(Me.lblInfo_KouziBasyo, 1, 7)
        Me.tpnlKouziInfo.Controls.Add(Me.Label51, 0, 7)
        Me.tpnlKouziInfo.Controls.Add(Me.lblInfo_KouziNumber, 1, 6)
        Me.tpnlKouziInfo.Controls.Add(Me.Label49, 0, 6)
        Me.tpnlKouziInfo.Controls.Add(Me.lblInfo_KouziName, 1, 5)
        Me.tpnlKouziInfo.Controls.Add(Me.Label47, 0, 5)
        Me.tpnlKouziInfo.Controls.Add(Me.lblInfo_Kokyaku, 1, 4)
        Me.tpnlKouziInfo.Controls.Add(Me.Label45, 0, 4)
        Me.tpnlKouziInfo.Controls.Add(Me.lblInfo_Tanto, 1, 3)
        Me.tpnlKouziInfo.Controls.Add(Me.lblInfo_MitumoriNo, 1, 2)
        Me.tpnlKouziInfo.Controls.Add(Me.lblInfo_JyutyuDate, 1, 1)
        Me.tpnlKouziInfo.Controls.Add(Me.lblInfo_JyutyuNo, 1, 0)
        Me.tpnlKouziInfo.Controls.Add(Me.Label37, 0, 0)
        Me.tpnlKouziInfo.Controls.Add(Me.Label38, 0, 1)
        Me.tpnlKouziInfo.Controls.Add(Me.Label39, 0, 2)
        Me.tpnlKouziInfo.Controls.Add(Me.Label40, 0, 3)
        Me.tpnlKouziInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tpnlKouziInfo.Location = New System.Drawing.Point(3, 4)
        Me.tpnlKouziInfo.Name = "tpnlKouziInfo"
        Me.tpnlKouziInfo.RowCount = 12
        Me.tpnlKouziInfo.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307!))
        Me.tpnlKouziInfo.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307!))
        Me.tpnlKouziInfo.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307!))
        Me.tpnlKouziInfo.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307!))
        Me.tpnlKouziInfo.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307!))
        Me.tpnlKouziInfo.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307!))
        Me.tpnlKouziInfo.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307!))
        Me.tpnlKouziInfo.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307!))
        Me.tpnlKouziInfo.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307!))
        Me.tpnlKouziInfo.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307!))
        Me.tpnlKouziInfo.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307!))
        Me.tpnlKouziInfo.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307!))
        Me.tpnlKouziInfo.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307!))
        Me.tpnlKouziInfo.Size = New System.Drawing.Size(405, 291)
        Me.tpnlKouziInfo.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Thistle
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label7.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.Label7.Location = New System.Drawing.Point(3, 267)
        Me.Label7.Margin = New System.Windows.Forms.Padding(3)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(75, 21)
        Me.Label7.TabIndex = 71
        Me.Label7.Text = "受注金額："
        '
        'lblInfo_JyutyuKingaku
        '
        Me.lblInfo_JyutyuKingaku.AutoSize = True
        Me.lblInfo_JyutyuKingaku.BackColor = System.Drawing.Color.Thistle
        Me.lblInfo_JyutyuKingaku.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblInfo_JyutyuKingaku.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblInfo_JyutyuKingaku.Location = New System.Drawing.Point(84, 267)
        Me.lblInfo_JyutyuKingaku.Margin = New System.Windows.Forms.Padding(3)
        Me.lblInfo_JyutyuKingaku.Name = "lblInfo_JyutyuKingaku"
        Me.lblInfo_JyutyuKingaku.Size = New System.Drawing.Size(318, 21)
        Me.lblInfo_JyutyuKingaku.TabIndex = 70
        Me.lblInfo_JyutyuKingaku.Text = "99,999,999,999 円"
        Me.lblInfo_JyutyuKingaku.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblInfo_Syohizei
        '
        Me.lblInfo_Syohizei.AutoSize = True
        Me.lblInfo_Syohizei.BackColor = System.Drawing.Color.Thistle
        Me.lblInfo_Syohizei.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblInfo_Syohizei.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblInfo_Syohizei.Location = New System.Drawing.Point(84, 243)
        Me.lblInfo_Syohizei.Margin = New System.Windows.Forms.Padding(3)
        Me.lblInfo_Syohizei.Name = "lblInfo_Syohizei"
        Me.lblInfo_Syohizei.Size = New System.Drawing.Size(318, 18)
        Me.lblInfo_Syohizei.TabIndex = 69
        Me.lblInfo_Syohizei.Text = "99,999,999,999 円"
        Me.lblInfo_Syohizei.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label59
        '
        Me.Label59.AutoSize = True
        Me.Label59.BackColor = System.Drawing.Color.Thistle
        Me.Label59.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label59.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.Label59.Location = New System.Drawing.Point(3, 243)
        Me.Label59.Margin = New System.Windows.Forms.Padding(3)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(75, 18)
        Me.Label59.TabIndex = 68
        Me.Label59.Text = "消費税　："
        '
        'lblInfo_Syokei
        '
        Me.lblInfo_Syokei.AutoSize = True
        Me.lblInfo_Syokei.BackColor = System.Drawing.Color.Thistle
        Me.lblInfo_Syokei.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblInfo_Syokei.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblInfo_Syokei.Location = New System.Drawing.Point(84, 219)
        Me.lblInfo_Syokei.Margin = New System.Windows.Forms.Padding(3)
        Me.lblInfo_Syokei.Name = "lblInfo_Syokei"
        Me.lblInfo_Syokei.Size = New System.Drawing.Size(318, 18)
        Me.lblInfo_Syokei.TabIndex = 67
        Me.lblInfo_Syokei.Text = "99,999,999,999 円"
        Me.lblInfo_Syokei.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label57
        '
        Me.Label57.AutoSize = True
        Me.Label57.BackColor = System.Drawing.Color.Thistle
        Me.Label57.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label57.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.Label57.Location = New System.Drawing.Point(3, 219)
        Me.Label57.Margin = New System.Windows.Forms.Padding(3)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(75, 18)
        Me.Label57.TabIndex = 66
        Me.Label57.Text = "小計　　："
        '
        'lblInfo_Nouki1
        '
        Me.lblInfo_Nouki1.AutoSize = True
        Me.lblInfo_Nouki1.BackColor = System.Drawing.Color.Thistle
        Me.lblInfo_Nouki1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblInfo_Nouki1.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblInfo_Nouki1.Location = New System.Drawing.Point(84, 195)
        Me.lblInfo_Nouki1.Margin = New System.Windows.Forms.Padding(3)
        Me.lblInfo_Nouki1.Name = "lblInfo_Nouki1"
        Me.lblInfo_Nouki1.Size = New System.Drawing.Size(318, 18)
        Me.lblInfo_Nouki1.TabIndex = 63
        Me.lblInfo_Nouki1.Text = "9999/99/99 (平成99年) ～"
        Me.lblInfo_Nouki1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.BackColor = System.Drawing.Color.Thistle
        Me.Label53.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label53.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.Label53.Location = New System.Drawing.Point(3, 195)
        Me.Label53.Margin = New System.Windows.Forms.Padding(3)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(75, 18)
        Me.Label53.TabIndex = 62
        Me.Label53.Text = "工期　　："
        '
        'lblInfo_KouziBasyo
        '
        Me.lblInfo_KouziBasyo.AutoSize = True
        Me.lblInfo_KouziBasyo.BackColor = System.Drawing.Color.Thistle
        Me.lblInfo_KouziBasyo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblInfo_KouziBasyo.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblInfo_KouziBasyo.Location = New System.Drawing.Point(84, 171)
        Me.lblInfo_KouziBasyo.Margin = New System.Windows.Forms.Padding(3)
        Me.lblInfo_KouziBasyo.Name = "lblInfo_KouziBasyo"
        Me.lblInfo_KouziBasyo.Size = New System.Drawing.Size(318, 18)
        Me.lblInfo_KouziBasyo.TabIndex = 61
        Me.lblInfo_KouziBasyo.Text = "ＸＸＸＸＸＸＸＸＸＸＸＸＸ"
        Me.lblInfo_KouziBasyo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.BackColor = System.Drawing.Color.Thistle
        Me.Label51.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label51.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.Label51.Location = New System.Drawing.Point(3, 171)
        Me.Label51.Margin = New System.Windows.Forms.Padding(3)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(75, 18)
        Me.Label51.TabIndex = 60
        Me.Label51.Text = "工事場所："
        '
        'lblInfo_KouziNumber
        '
        Me.lblInfo_KouziNumber.AutoSize = True
        Me.lblInfo_KouziNumber.BackColor = System.Drawing.Color.Thistle
        Me.lblInfo_KouziNumber.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblInfo_KouziNumber.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblInfo_KouziNumber.Location = New System.Drawing.Point(84, 147)
        Me.lblInfo_KouziNumber.Margin = New System.Windows.Forms.Padding(3)
        Me.lblInfo_KouziNumber.Name = "lblInfo_KouziNumber"
        Me.lblInfo_KouziNumber.Size = New System.Drawing.Size(318, 18)
        Me.lblInfo_KouziNumber.TabIndex = 59
        Me.lblInfo_KouziNumber.Text = "9999999999"
        Me.lblInfo_KouziNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.BackColor = System.Drawing.Color.Thistle
        Me.Label49.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label49.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.Label49.Location = New System.Drawing.Point(3, 147)
        Me.Label49.Margin = New System.Windows.Forms.Padding(3)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(75, 18)
        Me.Label49.TabIndex = 58
        Me.Label49.Text = "工事番号："
        '
        'lblInfo_KouziName
        '
        Me.lblInfo_KouziName.AutoSize = True
        Me.lblInfo_KouziName.BackColor = System.Drawing.Color.Thistle
        Me.lblInfo_KouziName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblInfo_KouziName.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblInfo_KouziName.Location = New System.Drawing.Point(84, 123)
        Me.lblInfo_KouziName.Margin = New System.Windows.Forms.Padding(3)
        Me.lblInfo_KouziName.Name = "lblInfo_KouziName"
        Me.lblInfo_KouziName.Size = New System.Drawing.Size(318, 18)
        Me.lblInfo_KouziName.TabIndex = 57
        Me.lblInfo_KouziName.Text = "１２３４５６７８９０１２３４５６７８９０１２３４５"
        Me.lblInfo_KouziName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.BackColor = System.Drawing.Color.Thistle
        Me.Label47.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label47.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.Label47.Location = New System.Drawing.Point(3, 123)
        Me.Label47.Margin = New System.Windows.Forms.Padding(3)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(75, 18)
        Me.Label47.TabIndex = 56
        Me.Label47.Text = "工事名称："
        '
        'lblInfo_Kokyaku
        '
        Me.lblInfo_Kokyaku.AutoSize = True
        Me.lblInfo_Kokyaku.BackColor = System.Drawing.Color.Thistle
        Me.lblInfo_Kokyaku.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblInfo_Kokyaku.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblInfo_Kokyaku.Location = New System.Drawing.Point(84, 99)
        Me.lblInfo_Kokyaku.Margin = New System.Windows.Forms.Padding(3)
        Me.lblInfo_Kokyaku.Name = "lblInfo_Kokyaku"
        Me.lblInfo_Kokyaku.Size = New System.Drawing.Size(318, 18)
        Me.lblInfo_Kokyaku.TabIndex = 55
        Me.lblInfo_Kokyaku.Text = "１２３４５６７８９０１２３４５６７８９０"
        Me.lblInfo_Kokyaku.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.BackColor = System.Drawing.Color.Thistle
        Me.Label45.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label45.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.Label45.Location = New System.Drawing.Point(3, 99)
        Me.Label45.Margin = New System.Windows.Forms.Padding(3)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(75, 18)
        Me.Label45.TabIndex = 54
        Me.Label45.Text = "元請名　："
        '
        'lblInfo_Tanto
        '
        Me.lblInfo_Tanto.AutoSize = True
        Me.lblInfo_Tanto.BackColor = System.Drawing.Color.Thistle
        Me.lblInfo_Tanto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblInfo_Tanto.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblInfo_Tanto.Location = New System.Drawing.Point(84, 75)
        Me.lblInfo_Tanto.Margin = New System.Windows.Forms.Padding(3)
        Me.lblInfo_Tanto.Name = "lblInfo_Tanto"
        Me.lblInfo_Tanto.Size = New System.Drawing.Size(318, 18)
        Me.lblInfo_Tanto.TabIndex = 53
        Me.lblInfo_Tanto.Text = "ＸＸ　ＸＸ"
        Me.lblInfo_Tanto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblInfo_MitumoriNo
        '
        Me.lblInfo_MitumoriNo.AutoSize = True
        Me.lblInfo_MitumoriNo.BackColor = System.Drawing.Color.Thistle
        Me.lblInfo_MitumoriNo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblInfo_MitumoriNo.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblInfo_MitumoriNo.Location = New System.Drawing.Point(84, 51)
        Me.lblInfo_MitumoriNo.Margin = New System.Windows.Forms.Padding(3)
        Me.lblInfo_MitumoriNo.Name = "lblInfo_MitumoriNo"
        Me.lblInfo_MitumoriNo.Size = New System.Drawing.Size(318, 18)
        Me.lblInfo_MitumoriNo.TabIndex = 52
        Me.lblInfo_MitumoriNo.Text = "1234567890-00"
        Me.lblInfo_MitumoriNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblInfo_JyutyuDate
        '
        Me.lblInfo_JyutyuDate.AutoSize = True
        Me.lblInfo_JyutyuDate.BackColor = System.Drawing.Color.Thistle
        Me.lblInfo_JyutyuDate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblInfo_JyutyuDate.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblInfo_JyutyuDate.Location = New System.Drawing.Point(84, 27)
        Me.lblInfo_JyutyuDate.Margin = New System.Windows.Forms.Padding(3)
        Me.lblInfo_JyutyuDate.Name = "lblInfo_JyutyuDate"
        Me.lblInfo_JyutyuDate.Size = New System.Drawing.Size(318, 18)
        Me.lblInfo_JyutyuDate.TabIndex = 51
        Me.lblInfo_JyutyuDate.Text = "9999/99/99 (平成99年99月99日)"
        Me.lblInfo_JyutyuDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblInfo_JyutyuNo
        '
        Me.lblInfo_JyutyuNo.AutoSize = True
        Me.lblInfo_JyutyuNo.BackColor = System.Drawing.Color.Thistle
        Me.lblInfo_JyutyuNo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblInfo_JyutyuNo.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblInfo_JyutyuNo.Location = New System.Drawing.Point(84, 3)
        Me.lblInfo_JyutyuNo.Margin = New System.Windows.Forms.Padding(3)
        Me.lblInfo_JyutyuNo.Name = "lblInfo_JyutyuNo"
        Me.lblInfo_JyutyuNo.Size = New System.Drawing.Size(318, 18)
        Me.lblInfo_JyutyuNo.TabIndex = 50
        Me.lblInfo_JyutyuNo.Text = "1234567890-00"
        Me.lblInfo_JyutyuNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.BackColor = System.Drawing.Color.Thistle
        Me.Label37.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label37.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.Label37.Location = New System.Drawing.Point(3, 3)
        Me.Label37.Margin = New System.Windows.Forms.Padding(3)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(75, 18)
        Me.Label37.TabIndex = 46
        Me.Label37.Text = "受注Ｎｏ："
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.BackColor = System.Drawing.Color.Thistle
        Me.Label38.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label38.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.Label38.Location = New System.Drawing.Point(3, 27)
        Me.Label38.Margin = New System.Windows.Forms.Padding(3)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(75, 18)
        Me.Label38.TabIndex = 47
        Me.Label38.Text = "受注日付："
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.BackColor = System.Drawing.Color.Thistle
        Me.Label39.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label39.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.Label39.Location = New System.Drawing.Point(3, 51)
        Me.Label39.Margin = New System.Windows.Forms.Padding(3)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(75, 18)
        Me.Label39.TabIndex = 48
        Me.Label39.Text = "見積Ｎｏ："
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.BackColor = System.Drawing.Color.Thistle
        Me.Label40.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label40.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.Label40.Location = New System.Drawing.Point(3, 75)
        Me.Label40.Margin = New System.Windows.Forms.Padding(3)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(75, 18)
        Me.Label40.TabIndex = 49
        Me.Label40.Text = "担当者　："
        '
        'tpnlGokeiKin
        '
        Me.tpnlGokeiKin.BackColor = System.Drawing.Color.White
        Me.tpnlGokeiKin.ColumnCount = 1
        Me.tpnlGokeiKin.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tpnlGokeiKin.Controls.Add(Me.Label14, 0, 5)
        Me.tpnlGokeiKin.Controls.Add(Me.Label16, 0, 4)
        Me.tpnlGokeiKin.Location = New System.Drawing.Point(0, 0)
        Me.tpnlGokeiKin.Name = "tpnlGokeiKin"
        Me.tpnlGokeiKin.RowCount = 6
        Me.tpnlGokeiKin.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tpnlGokeiKin.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tpnlGokeiKin.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tpnlGokeiKin.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tpnlGokeiKin.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tpnlGokeiKin.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tpnlGokeiKin.Size = New System.Drawing.Size(200, 100)
        Me.tpnlGokeiKin.TabIndex = 0
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label14.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(3, 103)
        Me.Label14.Margin = New System.Windows.Forms.Padding(3)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(194, 14)
        Me.Label14.TabIndex = 20
        Me.Label14.Text = " 999,999,999,999  円"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label16.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(3, 83)
        Me.Label16.Margin = New System.Windows.Forms.Padding(3)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(194, 14)
        Me.Label16.TabIndex = 20
        Me.Label16.Text = " 999,999,999,999  円"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label19.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(6, 87)
        Me.Label19.Margin = New System.Windows.Forms.Padding(3)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(190, 22)
        Me.Label19.TabIndex = 20
        Me.Label19.Text = " 999,999,999,999  円"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtKonMadeJyuryoGaku
        '
        Me.txtKonMadeJyuryoGaku.BackColor = System.Drawing.Color.White
        Me.txtKonMadeJyuryoGaku.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtKonMadeJyuryoGaku.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtKonMadeJyuryoGaku.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtKonMadeJyuryoGaku.Location = New System.Drawing.Point(97, 103)
        Me.txtKonMadeJyuryoGaku.MaxLength = 12
        Me.txtKonMadeJyuryoGaku.MaxValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtKonMadeJyuryoGaku.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtKonMadeJyuryoGaku.Multiline = True
        Me.txtKonMadeJyuryoGaku.Name = "txtKonMadeJyuryoGaku"
        Me.txtKonMadeJyuryoGaku.Size = New System.Drawing.Size(118, 25)
        Me.txtKonMadeJyuryoGaku.TabIndex = 7
        Me.txtKonMadeJyuryoGaku.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtKonMadeJyuryoGaku.UseNullValidator = True
        Me.txtKonMadeJyuryoGaku.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'txtBiko
        '
        Me.txtBiko.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBiko.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtBiko.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtBiko.Location = New System.Drawing.Point(97, 165)
        Me.txtBiko.MaxLength = 200
        Me.txtBiko.Multiline = True
        Me.txtBiko.Name = "txtBiko"
        Me.txtBiko.Size = New System.Drawing.Size(358, 107)
        Me.txtBiko.TabIndex = 9
        Me.txtBiko.Text = "123456789012345678901234567890123456789012345678901234567890123456789012345678901" &
    "23456789012345678901234567890123456789012345678901234567890123456789012345678901" &
    "234567890123456789012345678901234567890"
        '
        'dbgMEISAI
        '
        Me.dbgMEISAI.BackColor = System.Drawing.Color.Thistle
        Me.dbgMEISAI.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.dbgMEISAI.CaptionHeight = 16
        Me.dbgMEISAI.Cursor = System.Windows.Forms.Cursors.Default
        Me.dbgMEISAI.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.dbgMEISAI.GroupByCaption = "列でグループ化するには、ここに列ヘッダをドラッグします。"
        Me.dbgMEISAI.Images.Add(CType(resources.GetObject("dbgMEISAI.Images"), System.Drawing.Image))
        Me.dbgMEISAI.Location = New System.Drawing.Point(18, 38)
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
        Me.dbgMEISAI.Size = New System.Drawing.Size(520, 59)
        Me.dbgMEISAI.TabIndex = 6
        Me.dbgMEISAI.UseCompatibleTextRendering = False
        Me.dbgMEISAI.PropBag = resources.GetString("dbgMEISAI.PropBag")
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.DarkSlateBlue
        Me.Label3.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(421, 157)
        Me.Label3.MinimumSize = New System.Drawing.Size(592, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(592, 17)
        Me.Label3.TabIndex = 98
        Me.Label3.Text = "請求情報"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlSeikyu
        '
        Me.pnlSeikyu.BackColor = System.Drawing.Color.Thistle
        Me.pnlSeikyu.Controls.Add(Me.Label10)
        Me.pnlSeikyu.Controls.Add(Me.txtHoryukinKonkai)
        Me.pnlSeikyu.Controls.Add(Me.Label9)
        Me.pnlSeikyu.Controls.Add(Me.txtHoryukin)
        Me.pnlSeikyu.Controls.Add(Me.lblKurikoshiZan)
        Me.pnlSeikyu.Controls.Add(Me.txtKurikoshiZan)
        Me.pnlSeikyu.Controls.Add(Me.Label8)
        Me.pnlSeikyu.Controls.Add(Me.Label6)
        Me.pnlSeikyu.Controls.Add(Me.btnMeisaiInput)
        Me.pnlSeikyu.Controls.Add(Me.rdoSeikyuHouhou_0)
        Me.pnlSeikyu.Controls.Add(Me.rdoSeikyuHouhou_1)
        Me.pnlSeikyu.Controls.Add(Me.Label5)
        Me.pnlSeikyu.Controls.Add(Me.txtKonMadeJyuryoGaku)
        Me.pnlSeikyu.Controls.Add(Me.txtBiko)
        Me.pnlSeikyu.Controls.Add(Me.dbgMEISAI)
        Me.pnlSeikyu.Location = New System.Drawing.Point(421, 174)
        Me.pnlSeikyu.Name = "pnlSeikyu"
        Me.pnlSeikyu.Size = New System.Drawing.Size(592, 299)
        Me.pnlSeikyu.TabIndex = 99
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.Label10.Location = New System.Drawing.Point(256, 136)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(74, 17)
        Me.Label10.TabIndex = 108
        Me.Label10.Text = "今回迄保留金"
        '
        'txtHoryukinKonkai
        '
        Me.txtHoryukinKonkai.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.txtHoryukinKonkai.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtHoryukinKonkai.Enabled = False
        Me.txtHoryukinKonkai.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtHoryukinKonkai.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtHoryukinKonkai.Location = New System.Drawing.Point(338, 134)
        Me.txtHoryukinKonkai.MaxLength = 12
        Me.txtHoryukinKonkai.MaxValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtHoryukinKonkai.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtHoryukinKonkai.Multiline = True
        Me.txtHoryukinKonkai.Name = "txtHoryukinKonkai"
        Me.txtHoryukinKonkai.Size = New System.Drawing.Size(118, 25)
        Me.txtHoryukinKonkai.TabIndex = 107
        Me.txtHoryukinKonkai.TabStop = False
        Me.txtHoryukinKonkai.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtHoryukinKonkai.UseNullValidator = True
        Me.txtHoryukinKonkai.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.Label9.Location = New System.Drawing.Point(15, 136)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(41, 17)
        Me.Label9.TabIndex = 106
        Me.Label9.Text = "保留金"
        '
        'txtHoryukin
        '
        Me.txtHoryukin.BackColor = System.Drawing.Color.White
        Me.txtHoryukin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtHoryukin.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtHoryukin.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtHoryukin.Location = New System.Drawing.Point(97, 134)
        Me.txtHoryukin.MaxLength = 12
        Me.txtHoryukin.MaxValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtHoryukin.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtHoryukin.Multiline = True
        Me.txtHoryukin.Name = "txtHoryukin"
        Me.txtHoryukin.Size = New System.Drawing.Size(118, 25)
        Me.txtHoryukin.TabIndex = 8
        Me.txtHoryukin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtHoryukin.UseNullValidator = True
        Me.txtHoryukin.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'lblKurikoshiZan
        '
        Me.lblKurikoshiZan.AutoSize = True
        Me.lblKurikoshiZan.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.lblKurikoshiZan.Location = New System.Drawing.Point(256, 105)
        Me.lblKurikoshiZan.Name = "lblKurikoshiZan"
        Me.lblKurikoshiZan.Size = New System.Drawing.Size(41, 17)
        Me.lblKurikoshiZan.TabIndex = 104
        Me.lblKurikoshiZan.Text = "繰越残"
        '
        'txtKurikoshiZan
        '
        Me.txtKurikoshiZan.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.txtKurikoshiZan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtKurikoshiZan.Enabled = False
        Me.txtKurikoshiZan.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtKurikoshiZan.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtKurikoshiZan.Location = New System.Drawing.Point(338, 103)
        Me.txtKurikoshiZan.MaxLength = 12
        Me.txtKurikoshiZan.MaxValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtKurikoshiZan.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtKurikoshiZan.Multiline = True
        Me.txtKurikoshiZan.Name = "txtKurikoshiZan"
        Me.txtKurikoshiZan.Size = New System.Drawing.Size(118, 25)
        Me.txtKurikoshiZan.TabIndex = 103
        Me.txtKurikoshiZan.TabStop = False
        Me.txtKurikoshiZan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtKurikoshiZan.UseNullValidator = True
        Me.txtKurikoshiZan.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.Label8.Location = New System.Drawing.Point(15, 167)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(30, 17)
        Me.Label8.TabIndex = 102
        Me.Label8.Text = "備考"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.Label6.Location = New System.Drawing.Point(15, 105)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(74, 17)
        Me.Label6.TabIndex = 101
        Me.Label6.Text = "今回迄受領額"
        '
        'btnMeisaiInput
        '
        Me.btnMeisaiInput.BackColor = System.Drawing.Color.Transparent
        Me.btnMeisaiInput.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnMeisaiInput.Location = New System.Drawing.Point(492, 5)
        Me.btnMeisaiInput.Name = "btnMeisaiInput"
        Me.btnMeisaiInput.Size = New System.Drawing.Size(86, 22)
        Me.btnMeisaiInput.TabIndex = 5
        Me.btnMeisaiInput.TabStop = False
        Me.btnMeisaiInput.Text = "明細入力" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnMeisaiInput.UseVisualStyleBackColor = False
        '
        'rdoSeikyuHouhou_0
        '
        Me.rdoSeikyuHouhou_0.AutoSize = True
        Me.rdoSeikyuHouhou_0.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.rdoSeikyuHouhou_0.Location = New System.Drawing.Point(97, 5)
        Me.rdoSeikyuHouhou_0.Name = "rdoSeikyuHouhou_0"
        Me.rdoSeikyuHouhou_0.Size = New System.Drawing.Size(169, 21)
        Me.rdoSeikyuHouhou_0.TabIndex = 4
        Me.rdoSeikyuHouhou_0.TabStop = True
        Me.rdoSeikyuHouhou_0.Text = "出来高％、今回請求額を指定"
        Me.rdoSeikyuHouhou_0.UseVisualStyleBackColor = True
        '
        'rdoSeikyuHouhou_1
        '
        Me.rdoSeikyuHouhou_1.AutoSize = True
        Me.rdoSeikyuHouhou_1.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.rdoSeikyuHouhou_1.Location = New System.Drawing.Point(275, 6)
        Me.rdoSeikyuHouhou_1.Name = "rdoSeikyuHouhou_1"
        Me.rdoSeikyuHouhou_1.Size = New System.Drawing.Size(213, 21)
        Me.rdoSeikyuHouhou_1.TabIndex = 4
        Me.rdoSeikyuHouhou_1.TabStop = True
        Me.rdoSeikyuHouhou_1.Text = "明細単位に請求する数量、金額を指定"
        Me.rdoSeikyuHouhou_1.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.Label5.Location = New System.Drawing.Point(15, 8)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 17)
        Me.Label5.TabIndex = 97
        Me.Label5.Text = "請求方法"
        '
        'txtJyutyuEdaban
        '
        Me.txtJyutyuEdaban.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.txtJyutyuEdaban.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtJyutyuEdaban.DisplayName = "見積Ｎｏ"
        Me.txtJyutyuEdaban.Enabled = False
        Me.txtJyutyuEdaban.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.txtJyutyuEdaban.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtJyutyuEdaban.Location = New System.Drawing.Point(266, 47)
        Me.txtJyutyuEdaban.MaxLength = 10
        Me.txtJyutyuEdaban.Name = "txtJyutyuEdaban"
        Me.txtJyutyuEdaban.ReadOnly = True
        Me.txtJyutyuEdaban.Size = New System.Drawing.Size(22, 16)
        Me.txtJyutyuEdaban.TabIndex = 100
        Me.txtJyutyuEdaban.Text = "1"
        Me.txtJyutyuEdaban.Visible = False
        '
        'lblSyosu
        '
        Me.lblSyosu.BackColor = System.Drawing.Color.Yellow
        Me.lblSyosu.Enabled = False
        Me.lblSyosu.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.lblSyosu.ForeColor = System.Drawing.Color.Black
        Me.lblSyosu.Location = New System.Drawing.Point(935, 9)
        Me.lblSyosu.Name = "lblSyosu"
        Me.lblSyosu.Size = New System.Drawing.Size(15, 17)
        Me.lblSyosu.TabIndex = 109
        Me.lblSyosu.Text = "0"
        Me.lblSyosu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblSyosu.Visible = False
        '
        'frmSEI0001
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 673)
        Me.Controls.Add(Me.lblSyosu)
        Me.Controls.Add(Me.txtJyutyuEdaban)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblSEIKYUNO)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.fraHeader)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.pnlSeikyu)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSEI0001"
        Me.Text = ""
        Me.Controls.SetChildIndex(Me.pnlSeikyu, 0)
        Me.Controls.SetChildIndex(Me.Label12, 0)
        Me.Controls.SetChildIndex(Me.Panel3, 0)
        Me.Controls.SetChildIndex(Me.fraHeader, 0)
        Me.Controls.SetChildIndex(Me.Label18, 0)
        Me.Controls.SetChildIndex(Me.Panel2, 0)
        Me.Controls.SetChildIndex(Me.lblSEIKYUNO, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.FunctionKey, 0)
        Me.Controls.SetChildIndex(Me.TitleBar, 0)
        Me.Controls.SetChildIndex(Me.txtJyutyuEdaban, 0)
        Me.Controls.SetChildIndex(Me.lblSyosu, 0)
        Me.fraHeader.ResumeLayout(False)
        Me.fraHeader.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.tpnlKouziInfo.ResumeLayout(False)
        Me.tpnlKouziInfo.PerformLayout()
        Me.tpnlGokeiKin.ResumeLayout(False)
        Me.tpnlGokeiKin.PerformLayout()
        CType(Me.dbgMEISAI, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlSeikyu.ResumeLayout(False)
        Me.pnlSeikyu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents fraHeader As System.Windows.Forms.Panel
    Friend WithEvents txtSeikyuDateDisp As CommonUtility.WinFormControls.DateTextBoxEx
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txtSeikyuDate As CommonUtility.WinFormControls.DateTextBoxEx
    Friend WithEvents lblFAX As System.Windows.Forms.Label
    Friend WithEvents lblDenwa As System.Windows.Forms.Label
    Friend WithEvents lblJyusyo As System.Windows.Forms.Label
    Friend WithEvents lblYubin As System.Windows.Forms.Label
    Friend WithEvents txtKeisyo As CommonUtility.WinFormControls.TypComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtKokyakuName As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents tpnlGokeiKin As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents tpnlKouziInfo As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblInfo_KouziName As System.Windows.Forms.Label
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents lblInfo_Kokyaku As System.Windows.Forms.Label
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents lblInfo_Tanto As System.Windows.Forms.Label
    Friend WithEvents lblInfo_MitumoriNo As System.Windows.Forms.Label
    Friend WithEvents lblInfo_JyutyuDate As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents lblInfo_Syohizei As System.Windows.Forms.Label
    Friend WithEvents Label59 As System.Windows.Forms.Label
    Friend WithEvents lblInfo_Syokei As System.Windows.Forms.Label
    Friend WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents lblInfo_Nouki1 As System.Windows.Forms.Label
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents lblInfo_KouziBasyo As System.Windows.Forms.Label
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents lblInfo_KouziNumber As System.Windows.Forms.Label
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents txtKeisyoName As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents lblTANTONAME As System.Windows.Forms.Label
    Private WithEvents Label4 As System.Windows.Forms.Label
    Private WithEvents lblTANTOCODE As System.Windows.Forms.Label
    Friend WithEvents txtKonMadeJyuryoGaku As CommonUtility.WinFormControls.NumberTextBoxEx
    Friend WithEvents txtBiko As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents txtKokyakuCode As CommonUtility.WinFormControls.TextBoxEx
    Protected WithEvents dbgMEISAI As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents Label13 As Label
    Friend WithEvents txtSeikyuNo As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents cmbSeikyuNo As CommonUtility.WinFormControls.MitumoriNoComboBox
    Friend WithEvents lblInfo_JyutyuNo As Label
    Friend WithEvents Label37 As Label
    Friend WithEvents lblSEIKYUNO As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents Label3 As Label
    Friend WithEvents pnlSeikyu As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents rdoSeikyuHouhou_0 As RadioButton
    Friend WithEvents rdoSeikyuHouhou_1 As RadioButton
    Friend WithEvents btnMeisaiInput As CommonUtility.WinFormControls.KobetuSentakuButton
    Friend WithEvents Label7 As Label
    Friend WithEvents lblInfo_JyutyuKingaku As Label
    Friend WithEvents txtJyutyuEdaban As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents Label8 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtSeikyuEdaban As CommonUtility.WinFormControls.MitumoriNoTextBoxEx
    Friend WithEvents Label10 As Label
    Friend WithEvents txtHoryukinKonkai As CommonUtility.WinFormControls.NumberTextBoxEx
    Friend WithEvents Label9 As Label
    Friend WithEvents txtHoryukin As CommonUtility.WinFormControls.NumberTextBoxEx
    Friend WithEvents lblKurikoshiZan As Label
    Friend WithEvents txtKurikoshiZan As CommonUtility.WinFormControls.NumberTextBoxEx
    Friend WithEvents lblSyosu As Label
End Class
