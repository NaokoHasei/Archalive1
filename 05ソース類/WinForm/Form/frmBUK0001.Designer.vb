<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBUK0001
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBUK0001))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtKoushu = New CommonUtility.WinFormControls.TextBoxEx()
        Me.txtAddress = New CommonUtility.WinFormControls.TextBoxEx()
        Me.txtAddress2 = New CommonUtility.WinFormControls.TextBoxEx()
        Me.Label68 = New System.Windows.Forms.Label()
        Me.txtAddress1 = New CommonUtility.WinFormControls.TextBoxEx()
        Me.Label69 = New System.Windows.Forms.Label()
        Me.txtPostNo = New CommonUtility.WinFormControls.TextBoxEx()
        Me.txtMotoukeName = New CommonUtility.WinFormControls.TextBoxEx()
        Me.txtMotoukeCode = New CommonUtility.WinFormControls.TypComboBox()
        Me.Label70 = New System.Windows.Forms.Label()
        Me.txtTantoName = New CommonUtility.WinFormControls.TextBoxEx()
        Me.txtTantoCode = New CommonUtility.WinFormControls.TypComboBox()
        Me.Label71 = New System.Windows.Forms.Label()
        Me.txtChakkouDate = New CommonUtility.WinFormControls.DateTextBoxEx()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtLng = New CommonUtility.WinFormControls.TextBoxEx()
        Me.txtLat = New CommonUtility.WinFormControls.TextBoxEx()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnMAP0001 = New System.Windows.Forms.Button()
        Me.btnMAP0001_2 = New System.Windows.Forms.Button()
        Me.txtKankouDate = New CommonUtility.WinFormControls.DateTextBoxEx()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtBukkenName = New CommonUtility.WinFormControls.TextBoxEx()
        Me.lblMessage1 = New System.Windows.Forms.Label()
        Me.lblMessage2 = New System.Windows.Forms.Label()
        Me.lblMessage3 = New System.Windows.Forms.Label()
        Me.btnMAP0001_3 = New System.Windows.Forms.Button()
        Me.btnMENT0005 = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtBukkenNo = New CommonUtility.WinFormControls.TextBoxEx()
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(274, 187)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 17)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "工種"
        '
        'txtKoushu
        '
        Me.txtKoushu.BackColor = System.Drawing.Color.White
        Me.txtKoushu.DisplayName = "工種"
        Me.txtKoushu.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtKoushu.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtKoushu.Location = New System.Drawing.Point(363, 183)
        Me.txtKoushu.MaxLength = 50
        Me.txtKoushu.Name = "txtKoushu"
        Me.txtKoushu.Size = New System.Drawing.Size(390, 25)
        Me.txtKoushu.TabIndex = 2
        Me.txtKoushu.Text = "ＸＸＸＸＸＸＸＸＸ１ＸＸＸＸＸＸＸＸＸ２"
        '
        'txtAddress
        '
        Me.txtAddress.BackColor = System.Drawing.Color.White
        Me.txtAddress.DisplayName = "住所"
        Me.txtAddress.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtAddress.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtAddress.Location = New System.Drawing.Point(363, 274)
        Me.txtAddress.MaxLength = 10
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(86, 25)
        Me.txtAddress.TabIndex = 5
        Me.txtAddress.Text = ""
        '
        'txtAddress2
        '
        Me.txtAddress2.BackColor = System.Drawing.Color.White
        Me.txtAddress2.DisplayName = "住所"
        Me.txtAddress2.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtAddress2.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtAddress2.Location = New System.Drawing.Point(363, 331)
        Me.txtAddress2.MaxLength = 60
        Me.txtAddress2.Name = "txtAddress2"
        Me.txtAddress2.Size = New System.Drawing.Size(390, 25)
        Me.txtAddress2.TabIndex = 7
        Me.txtAddress2.Text = ""
        '
        'Label68
        '
        Me.Label68.AutoSize = True
        Me.Label68.Location = New System.Drawing.Point(305, 278)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(30, 17)
        Me.Label68.TabIndex = 19
        Me.Label68.Text = "住所"
        '
        'txtAddress1
        '
        Me.txtAddress1.BackColor = System.Drawing.Color.White
        Me.txtAddress1.DisplayName = "住所"
        Me.txtAddress1.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtAddress1.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtAddress1.Location = New System.Drawing.Point(363, 303)
        Me.txtAddress1.MaxLength = 60
        Me.txtAddress1.Name = "txtAddress1"
        Me.txtAddress1.Size = New System.Drawing.Size(390, 25)
        Me.txtAddress1.TabIndex = 6
        Me.txtAddress1.Text = "123456789012345678901234567890123456789012345678901234567890"
        '
        'Label69
        '
        Me.Label69.AutoSize = True
        Me.Label69.Location = New System.Drawing.Point(305, 247)
        Me.Label69.Name = "Label69"
        Me.Label69.Size = New System.Drawing.Size(52, 17)
        Me.Label69.TabIndex = 18
        Me.Label69.Text = "郵便番号"
        '
        'txtPostNo
        '
        Me.txtPostNo.BackColor = System.Drawing.Color.White
        Me.txtPostNo.DisplayName = "郵便番号"
        Me.txtPostNo.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtPostNo.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtPostNo.Location = New System.Drawing.Point(363, 243)
        Me.txtPostNo.MaxLength = 10
        Me.txtPostNo.Name = "txtPostNo"
        Me.txtPostNo.Size = New System.Drawing.Size(86, 25)
        Me.txtPostNo.TabIndex = 4
        Me.txtPostNo.Text = ""
        '
        'txtMotoukeName
        '
        Me.txtMotoukeName.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.txtMotoukeName.DisplayName = "得意先名"
        Me.txtMotoukeName.Enabled = False
        Me.txtMotoukeName.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtMotoukeName.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtMotoukeName.Location = New System.Drawing.Point(451, 452)
        Me.txtMotoukeName.MaxLength = 40
        Me.txtMotoukeName.Name = "txtMotoukeName"
        Me.txtMotoukeName.ReadOnly = True
        Me.txtMotoukeName.Size = New System.Drawing.Size(302, 25)
        Me.txtMotoukeName.TabIndex = 45
        Me.txtMotoukeName.Text = "１２３４５６７８９０"
        '
        'txtMotoukeCode
        '
        Me.txtMotoukeCode.AutoValidate = System.Windows.Forms.AutoValidate.Disable
        Me.txtMotoukeCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMotoukeCode.DisplayName = "元請"
        Me.txtMotoukeCode.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtMotoukeCode.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtMotoukeCode.LinkedTextBox = Me.txtMotoukeName
        Me.txtMotoukeCode.Location = New System.Drawing.Point(363, 455)
        Me.txtMotoukeCode.MaxLength = 8
        Me.txtMotoukeCode.Name = "txtMotoukeCode"
        Me.txtMotoukeCode.Size = New System.Drawing.Size(82, 18)
        Me.txtMotoukeCode.TabIndex = 9
        Me.txtMotoukeCode.UseMasterCheckValidator = True
        Me.txtMotoukeCode.UseUpdateLinkedTextByCodeChange = True
        Me.txtMotoukeCode.UseZeroPadding = True
        Me.txtMotoukeCode.ZeroPaddingLength = 8
        '
        'Label70
        '
        Me.Label70.AutoSize = True
        Me.Label70.Location = New System.Drawing.Point(274, 456)
        Me.Label70.Name = "Label70"
        Me.Label70.Size = New System.Drawing.Size(30, 17)
        Me.Label70.TabIndex = 44
        Me.Label70.Text = "元請"
        '
        'txtTantoName
        '
        Me.txtTantoName.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.txtTantoName.DisplayName = "得意先名"
        Me.txtTantoName.Enabled = False
        Me.txtTantoName.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtTantoName.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtTantoName.Location = New System.Drawing.Point(451, 483)
        Me.txtTantoName.MaxLength = 40
        Me.txtTantoName.Name = "txtTantoName"
        Me.txtTantoName.ReadOnly = True
        Me.txtTantoName.Size = New System.Drawing.Size(302, 25)
        Me.txtTantoName.TabIndex = 48
        Me.txtTantoName.Text = "１２３４５６７８９０"
        '
        'txtTantoCode
        '
        Me.txtTantoCode.AutoValidate = System.Windows.Forms.AutoValidate.Disable
        Me.txtTantoCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTantoCode.DisplayName = "担当者"
        Me.txtTantoCode.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtTantoCode.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtTantoCode.LinkedTextBox = Me.txtTantoName
        Me.txtTantoCode.Location = New System.Drawing.Point(363, 486)
        Me.txtTantoCode.MaxLength = 4
        Me.txtTantoCode.Name = "txtTantoCode"
        Me.txtTantoCode.Size = New System.Drawing.Size(82, 18)
        Me.txtTantoCode.TabIndex = 11
        Me.txtTantoCode.UseMasterCheckValidator = True
        Me.txtTantoCode.UseUpdateLinkedTextByCodeChange = True
        Me.txtTantoCode.UseZeroPadding = True
        Me.txtTantoCode.ZeroPaddingLength = 4
        '
        'Label71
        '
        Me.Label71.AutoSize = True
        Me.Label71.Location = New System.Drawing.Point(274, 487)
        Me.Label71.Name = "Label71"
        Me.Label71.Size = New System.Drawing.Size(41, 17)
        Me.Label71.TabIndex = 47
        Me.Label71.Text = "担当者"
        '
        'txtChakkouDate
        '
        Me.txtChakkouDate.DisplayName = "着工日"
        Me.txtChakkouDate.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtChakkouDate.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtChakkouDate.LinkedDateTextBox = Nothing
        Me.txtChakkouDate.Location = New System.Drawing.Point(363, 514)
        Me.txtChakkouDate.Mask = "0000/00/00"
        Me.txtChakkouDate.Name = "txtChakkouDate"
        Me.txtChakkouDate.Size = New System.Drawing.Size(78, 25)
        Me.txtChakkouDate.TabIndex = 12
        Me.txtChakkouDate.Text = "20150210"
        Me.txtChakkouDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtChakkouDate.ValidatingType = GetType(Date)
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.Label15.Location = New System.Drawing.Point(276, 518)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(41, 17)
        Me.Label15.TabIndex = 51
        Me.Label15.Text = "着工日"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(274, 218)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 17)
        Me.Label2.TabIndex = 52
        Me.Label2.Text = "工事場所"
        '
        'txtLng
        '
        Me.txtLng.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.txtLng.DisplayName = "住所"
        Me.txtLng.Enabled = False
        Me.txtLng.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtLng.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtLng.Location = New System.Drawing.Point(363, 421)
        Me.txtLng.MaxLength = 60
        Me.txtLng.Name = "txtLng"
        Me.txtLng.Size = New System.Drawing.Size(102, 25)
        Me.txtLng.TabIndex = 53
        Me.txtLng.Text = "999.9999999"
        '
        'txtLat
        '
        Me.txtLat.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.txtLat.DisplayName = "住所"
        Me.txtLat.Enabled = False
        Me.txtLat.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtLat.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtLat.Location = New System.Drawing.Point(363, 390)
        Me.txtLat.MaxLength = 60
        Me.txtLat.Name = "txtLat"
        Me.txtLat.Size = New System.Drawing.Size(102, 25)
        Me.txtLat.TabIndex = 54
        Me.txtLat.Text = "99.9999999"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(305, 425)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(30, 17)
        Me.Label3.TabIndex = 55
        Me.Label3.Text = "経度"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(305, 394)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 17)
        Me.Label4.TabIndex = 56
        Me.Label4.Text = "緯度"
        '
        'btnMAP0001
        '
        Me.btnMAP0001.BackColor = System.Drawing.Color.Transparent
        Me.btnMAP0001.FlatAppearance.BorderSize = 0
        Me.btnMAP0001.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.btnMAP0001.ForeColor = System.Drawing.Color.Black
        Me.btnMAP0001.Location = New System.Drawing.Point(363, 215)
        Me.btnMAP0001.Name = "btnMAP0001"
        Me.btnMAP0001.Size = New System.Drawing.Size(194, 22)
        Me.btnMAP0001.TabIndex = 3
        Me.btnMAP0001.Text = "プロット"
        Me.btnMAP0001.UseVisualStyleBackColor = False
        '
        'btnMAP0001_2
        '
        Me.btnMAP0001_2.BackColor = System.Drawing.Color.Transparent
        Me.btnMAP0001_2.FlatAppearance.BorderSize = 0
        Me.btnMAP0001_2.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.btnMAP0001_2.ForeColor = System.Drawing.Color.Black
        Me.btnMAP0001_2.Location = New System.Drawing.Point(363, 362)
        Me.btnMAP0001_2.Name = "btnMAP0001_2"
        Me.btnMAP0001_2.Size = New System.Drawing.Size(194, 22)
        Me.btnMAP0001_2.TabIndex = 8
        Me.btnMAP0001_2.Text = "住所から緯度・経度を取得"
        Me.btnMAP0001_2.UseVisualStyleBackColor = False
        '
        'txtKankouDate
        '
        Me.txtKankouDate.DisplayName = "完工日"
        Me.txtKankouDate.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtKankouDate.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtKankouDate.LinkedDateTextBox = Nothing
        Me.txtKankouDate.Location = New System.Drawing.Point(363, 545)
        Me.txtKankouDate.Mask = "0000/00/00"
        Me.txtKankouDate.Name = "txtKankouDate"
        Me.txtKankouDate.Size = New System.Drawing.Size(78, 25)
        Me.txtKankouDate.TabIndex = 13
        Me.txtKankouDate.Text = "20160210"
        Me.txtKankouDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtKankouDate.ValidatingType = GetType(Date)
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.Label7.Location = New System.Drawing.Point(276, 549)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(41, 17)
        Me.Label7.TabIndex = 83
        Me.Label7.Text = "完工日"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(274, 156)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 17)
        Me.Label5.TabIndex = 85
        Me.Label5.Text = "物件名"
        '
        'txtBukkenName
        '
        Me.txtBukkenName.BackColor = System.Drawing.Color.White
        Me.txtBukkenName.DisplayName = "物件名"
        Me.txtBukkenName.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtBukkenName.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtBukkenName.Location = New System.Drawing.Point(363, 152)
        Me.txtBukkenName.MaxLength = 50
        Me.txtBukkenName.Name = "txtBukkenName"
        Me.txtBukkenName.Size = New System.Drawing.Size(390, 25)
        Me.txtBukkenName.TabIndex = 1
        Me.txtBukkenName.Text = "ＸＸＸＸＸＸＸＸＸ１ＸＸＸＸＸＸＸＸＸ２"
        Me.txtBukkenName.UseNullValidator = True
        '
        'lblMessage1
        '
        Me.lblMessage1.Font = New System.Drawing.Font("メイリオ", 9.0!)
        Me.lblMessage1.ForeColor = System.Drawing.Color.Red
        Me.lblMessage1.Location = New System.Drawing.Point(272, 55)
        Me.lblMessage1.Name = "lblMessage1"
        Me.lblMessage1.Size = New System.Drawing.Size(643, 21)
        Me.lblMessage1.TabIndex = 86
        Me.lblMessage1.Text = "【請求確認】工期完了から最初の支払日が過ぎています。"
        '
        'lblMessage2
        '
        Me.lblMessage2.Font = New System.Drawing.Font("メイリオ", 9.0!)
        Me.lblMessage2.ForeColor = System.Drawing.Color.Blue
        Me.lblMessage2.Location = New System.Drawing.Point(272, 76)
        Me.lblMessage2.Name = "lblMessage2"
        Me.lblMessage2.Size = New System.Drawing.Size(643, 21)
        Me.lblMessage2.TabIndex = 87
        Me.lblMessage2.Text = "受注が承認されました。承認済みの受注情報を変更する場合は、承認解除が必要です。"
        '
        'lblMessage3
        '
        Me.lblMessage3.Font = New System.Drawing.Font("メイリオ", 9.0!)
        Me.lblMessage3.ForeColor = System.Drawing.Color.Blue
        Me.lblMessage3.Location = New System.Drawing.Point(272, 97)
        Me.lblMessage3.Name = "lblMessage3"
        Me.lblMessage3.Size = New System.Drawing.Size(643, 21)
        Me.lblMessage3.TabIndex = 88
        Me.lblMessage3.Text = "承認された発注情報があります。承認済みの発注情報を変更する場合は、承認解除が必要です。"
        '
        'btnMAP0001_3
        '
        Me.btnMAP0001_3.BackColor = System.Drawing.Color.Transparent
        Me.btnMAP0001_3.FlatAppearance.BorderSize = 0
        Me.btnMAP0001_3.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.btnMAP0001_3.ForeColor = System.Drawing.Color.Black
        Me.btnMAP0001_3.Location = New System.Drawing.Point(563, 362)
        Me.btnMAP0001_3.Name = "btnMAP0001_3"
        Me.btnMAP0001_3.Size = New System.Drawing.Size(194, 22)
        Me.btnMAP0001_3.TabIndex = 9
        Me.btnMAP0001_3.Text = "緯度・経度をクリア"
        Me.btnMAP0001_3.UseVisualStyleBackColor = False
        '
        'btnMENT0005
        '
        Me.btnMENT0005.BackColor = System.Drawing.Color.Transparent
        Me.btnMENT0005.FlatAppearance.BorderSize = 0
        Me.btnMENT0005.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.btnMENT0005.ForeColor = System.Drawing.Color.Black
        Me.btnMENT0005.Location = New System.Drawing.Point(759, 453)
        Me.btnMENT0005.Name = "btnMENT0005"
        Me.btnMENT0005.Size = New System.Drawing.Size(158, 22)
        Me.btnMENT0005.TabIndex = 10
        Me.btnMENT0005.Text = "元請マスタ登録"
        Me.btnMENT0005.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(276, 125)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(45, 17)
        Me.Label6.TabIndex = 92
        Me.Label6.Text = "物件No"
        '
        'txtBukkenNo
        '
        Me.txtBukkenNo.BackColor = System.Drawing.Color.White
        Me.txtBukkenNo.DigitOnly = True
        Me.txtBukkenNo.DisplayName = "物件No"
        Me.txtBukkenNo.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtBukkenNo.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtBukkenNo.Location = New System.Drawing.Point(363, 121)
        Me.txtBukkenNo.MaxLength = 10
        Me.txtBukkenNo.Name = "txtBukkenNo"
        Me.txtBukkenNo.Size = New System.Drawing.Size(94, 25)
        Me.txtBukkenNo.TabIndex = 1
        Me.txtBukkenNo.Text = "99999999999"
        Me.txtBukkenNo.UseZeroPadding = True
        Me.txtBukkenNo.ZeroPaddingLength = 10
        '
        'frmBUK0001
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 670)
        Me.Controls.Add(Me.txtBukkenNo)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.btnMENT0005)
        Me.Controls.Add(Me.btnMAP0001_3)
        Me.Controls.Add(Me.lblMessage3)
        Me.Controls.Add(Me.lblMessage2)
        Me.Controls.Add(Me.lblMessage1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtBukkenName)
        Me.Controls.Add(Me.txtKankouDate)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.btnMAP0001_2)
        Me.Controls.Add(Me.btnMAP0001)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtLat)
        Me.Controls.Add(Me.txtLng)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtChakkouDate)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtTantoName)
        Me.Controls.Add(Me.txtTantoCode)
        Me.Controls.Add(Me.Label71)
        Me.Controls.Add(Me.txtMotoukeName)
        Me.Controls.Add(Me.txtMotoukeCode)
        Me.Controls.Add(Me.Label70)
        Me.Controls.Add(Me.txtAddress)
        Me.Controls.Add(Me.txtAddress2)
        Me.Controls.Add(Me.Label68)
        Me.Controls.Add(Me.txtAddress1)
        Me.Controls.Add(Me.Label69)
        Me.Controls.Add(Me.txtPostNo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtKoushu)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmBUK0001"
        Me.Text = ""
        Me.Controls.SetChildIndex(Me.txtKoushu, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.txtPostNo, 0)
        Me.Controls.SetChildIndex(Me.Label69, 0)
        Me.Controls.SetChildIndex(Me.txtAddress1, 0)
        Me.Controls.SetChildIndex(Me.Label68, 0)
        Me.Controls.SetChildIndex(Me.txtAddress2, 0)
        Me.Controls.SetChildIndex(Me.txtAddress, 0)
        Me.Controls.SetChildIndex(Me.Label70, 0)
        Me.Controls.SetChildIndex(Me.txtMotoukeCode, 0)
        Me.Controls.SetChildIndex(Me.txtMotoukeName, 0)
        Me.Controls.SetChildIndex(Me.Label71, 0)
        Me.Controls.SetChildIndex(Me.txtTantoCode, 0)
        Me.Controls.SetChildIndex(Me.txtTantoName, 0)
        Me.Controls.SetChildIndex(Me.Label15, 0)
        Me.Controls.SetChildIndex(Me.txtChakkouDate, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.txtLng, 0)
        Me.Controls.SetChildIndex(Me.txtLat, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.TitleBar, 0)
        Me.Controls.SetChildIndex(Me.FunctionKey, 0)
        Me.Controls.SetChildIndex(Me.btnMAP0001, 0)
        Me.Controls.SetChildIndex(Me.btnMAP0001_2, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.txtKankouDate, 0)
        Me.Controls.SetChildIndex(Me.txtBukkenName, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.lblMessage1, 0)
        Me.Controls.SetChildIndex(Me.lblMessage2, 0)
        Me.Controls.SetChildIndex(Me.lblMessage3, 0)
        Me.Controls.SetChildIndex(Me.btnMAP0001_3, 0)
        Me.Controls.SetChildIndex(Me.btnMENT0005, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.txtBukkenNo, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtKoushu As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents txtAddress As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents txtAddress2 As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents Label68 As Label
    Friend WithEvents txtAddress1 As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents Label69 As Label
    Friend WithEvents txtPostNo As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents txtMotoukeName As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents txtMotoukeCode As CommonUtility.WinFormControls.TypComboBox
    Friend WithEvents Label70 As Label
    Friend WithEvents txtTantoName As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents txtTantoCode As CommonUtility.WinFormControls.TypComboBox
    Friend WithEvents Label71 As Label
    Friend WithEvents txtChakkouDate As CommonUtility.WinFormControls.DateTextBoxEx
    Friend WithEvents Label15 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtLng As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents txtLat As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents btnMAP0001 As Button
    Friend WithEvents btnMAP0001_2 As Button
    Friend WithEvents txtKankouDate As CommonUtility.WinFormControls.DateTextBoxEx
    Friend WithEvents Label7 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtBukkenName As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents lblMessage1 As Label
    Friend WithEvents lblMessage2 As Label
    Friend WithEvents lblMessage3 As Label
    Friend WithEvents btnMAP0001_3 As Button
    Friend WithEvents btnMENT0005 As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents txtBukkenNo As CommonUtility.WinFormControls.TextBoxEx
End Class
