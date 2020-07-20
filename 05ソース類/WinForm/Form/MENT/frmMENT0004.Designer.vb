<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMENT0004
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

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMENT0004))
        Me.txtTANTOCODE = New CommonUtility.WinFormControls.TypComboBox()
        Me.dbgMeisai = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.fraName = New System.Windows.Forms.Panel()
        Me.txtKengenName = New CommonUtility.WinFormControls.TextBoxEx()
        Me.txtKengenCode = New CommonUtility.WinFormControls.TypComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtPassword = New CommonUtility.WinFormControls.TextBoxEx()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtBUKANAME = New CommonUtility.WinFormControls.TextBoxEx()
        Me.txtBUKACODE = New CommonUtility.WinFormControls.TypComboBox()
        Me.txtTANTOKANA = New CommonUtility.WinFormControls.TextBoxEx()
        Me.txtTANTONAME = New CommonUtility.WinFormControls.TextBoxEx()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.dbgMeisai, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fraName.SuspendLayout()
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
        'txtTANTOCODE
        '
        Me.txtTANTOCODE.AutoValidate = System.Windows.Forms.AutoValidate.Disable
        Me.txtTANTOCODE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTANTOCODE.DisplayName = "担当者コード"
        Me.txtTANTOCODE.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtTANTOCODE.Location = New System.Drawing.Point(443, 63)
        Me.txtTANTOCODE.MaxLength = 4
        Me.txtTANTOCODE.Name = "txtTANTOCODE"
        Me.txtTANTOCODE.Size = New System.Drawing.Size(58, 18)
        Me.txtTANTOCODE.TabIndex = 0
        Me.txtTANTOCODE.UseUpdateLinkedTextByCodeChange = True
        Me.txtTANTOCODE.UseZeroPadding = True
        Me.txtTANTOCODE.ZeroPaddingLength = 4
        '
        'dbgMeisai
        '
        Me.dbgMeisai.AllowUpdate = False
        Me.dbgMeisai.BackColor = System.Drawing.Color.Thistle
        Me.dbgMeisai.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.dbgMeisai.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dbgMeisai.CaptionHeight = 16
        Me.dbgMeisai.GroupByCaption = "列でグループ化するには、ここに列ヘッダをドラッグします。"
        Me.dbgMeisai.Images.Add(CType(resources.GetObject("dbgMeisai.Images"), System.Drawing.Image))
        Me.dbgMeisai.Location = New System.Drawing.Point(179, 249)
        Me.dbgMeisai.Name = "dbgMeisai"
        Me.dbgMeisai.PreviewInfo.Caption = "印刷プレビューウィンドウ"
        Me.dbgMeisai.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.dbgMeisai.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.dbgMeisai.PreviewInfo.ZoomFactor = 75.0R
        Me.dbgMeisai.PrintInfo.PageSettings = CType(resources.GetObject("dbgMeisai.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.dbgMeisai.RowHeight = 14
        Me.dbgMeisai.Size = New System.Drawing.Size(663, 345)
        Me.dbgMeisai.TabIndex = 4
        Me.dbgMeisai.Text = "C1TrueDBGrid1"
        Me.dbgMeisai.UseCompatibleTextRendering = False
        Me.dbgMeisai.PropBag = resources.GetString("dbgMeisai.PropBag")
        '
        'fraName
        '
        Me.fraName.Controls.Add(Me.txtKengenName)
        Me.fraName.Controls.Add(Me.txtKengenCode)
        Me.fraName.Controls.Add(Me.Label7)
        Me.fraName.Controls.Add(Me.txtPassword)
        Me.fraName.Controls.Add(Me.Label6)
        Me.fraName.Controls.Add(Me.txtBUKANAME)
        Me.fraName.Controls.Add(Me.txtBUKACODE)
        Me.fraName.Controls.Add(Me.txtTANTOKANA)
        Me.fraName.Controls.Add(Me.txtTANTONAME)
        Me.fraName.Controls.Add(Me.Label4)
        Me.fraName.Controls.Add(Me.Label3)
        Me.fraName.Controls.Add(Me.Label2)
        Me.fraName.Location = New System.Drawing.Point(180, 87)
        Me.fraName.Name = "fraName"
        Me.fraName.Size = New System.Drawing.Size(658, 156)
        Me.fraName.TabIndex = 5
        '
        'txtKengenName
        '
        Me.txtKengenName.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.txtKengenName.DisplayName = "得意先名"
        Me.txtKengenName.Enabled = False
        Me.txtKengenName.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtKengenName.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtKengenName.Location = New System.Drawing.Point(327, 120)
        Me.txtKengenName.MaxLength = 40
        Me.txtKengenName.Name = "txtKengenName"
        Me.txtKengenName.ReadOnly = True
        Me.txtKengenName.Size = New System.Drawing.Size(230, 25)
        Me.txtKengenName.TabIndex = 49
        Me.txtKengenName.Text = "１２３４５６７８９０"
        '
        'txtKengenCode
        '
        Me.txtKengenCode.AutoValidate = System.Windows.Forms.AutoValidate.Disable
        Me.txtKengenCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtKengenCode.DisplayName = "使用機能の権限"
        Me.txtKengenCode.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtKengenCode.LinkedTextBox = Me.txtKengenName
        Me.txtKengenCode.Location = New System.Drawing.Point(263, 123)
        Me.txtKengenCode.MaxLength = 4
        Me.txtKengenCode.Name = "txtKengenCode"
        Me.txtKengenCode.Size = New System.Drawing.Size(58, 18)
        Me.txtKengenCode.TabIndex = 4
        Me.txtKengenCode.UseMasterCheckValidator = True
        Me.txtKengenCode.UseNullValidator = True
        Me.txtKengenCode.UseUpdateLinkedTextByCodeChange = True
        Me.txtKengenCode.UseZeroPadding = True
        Me.txtKengenCode.ZeroPaddingLength = 4
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(168, 124)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(85, 17)
        Me.Label7.TabIndex = 47
        Me.Label7.Text = "使用機能の権限"
        '
        'txtPassword
        '
        Me.txtPassword.BackColor = System.Drawing.Color.White
        Me.txtPassword.DisplayName = "パスワード"
        Me.txtPassword.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtPassword.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtPassword.Location = New System.Drawing.Point(263, 92)
        Me.txtPassword.MaxLength = 30
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(222, 25)
        Me.txtPassword.TabIndex = 3
        Me.txtPassword.Text = "123456789012345678901234567890"
        Me.txtPassword.UseSystemPasswordChar = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(168, 96)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(63, 17)
        Me.Label6.TabIndex = 45
        Me.Label6.Text = "パスワード"
        '
        'txtBUKANAME
        '
        Me.txtBUKANAME.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.txtBUKANAME.DisplayName = "得意先名"
        Me.txtBUKANAME.Enabled = False
        Me.txtBUKANAME.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtBUKANAME.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtBUKANAME.Location = New System.Drawing.Point(327, 61)
        Me.txtBUKANAME.MaxLength = 40
        Me.txtBUKANAME.Name = "txtBUKANAME"
        Me.txtBUKANAME.ReadOnly = True
        Me.txtBUKANAME.Size = New System.Drawing.Size(230, 25)
        Me.txtBUKANAME.TabIndex = 43
        Me.txtBUKANAME.Text = "１２３４５６７８９０"
        '
        'txtBUKACODE
        '
        Me.txtBUKACODE.AutoValidate = System.Windows.Forms.AutoValidate.Disable
        Me.txtBUKACODE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBUKACODE.DisplayName = "部課コード"
        Me.txtBUKACODE.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtBUKACODE.LinkedTextBox = Me.txtBUKANAME
        Me.txtBUKACODE.Location = New System.Drawing.Point(263, 64)
        Me.txtBUKACODE.MaxLength = 4
        Me.txtBUKACODE.Name = "txtBUKACODE"
        Me.txtBUKACODE.Size = New System.Drawing.Size(58, 18)
        Me.txtBUKACODE.TabIndex = 2
        Me.txtBUKACODE.UseMasterCheckValidator = True
        Me.txtBUKACODE.UseNullValidator = True
        Me.txtBUKACODE.UseUpdateLinkedTextByCodeChange = True
        Me.txtBUKACODE.UseZeroPadding = True
        Me.txtBUKACODE.ZeroPaddingLength = 4
        '
        'txtTANTOKANA
        '
        Me.txtTANTOKANA.BackColor = System.Drawing.Color.White
        Me.txtTANTOKANA.DisplayName = "担当者カナ"
        Me.txtTANTOKANA.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtTANTOKANA.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.txtTANTOKANA.Location = New System.Drawing.Point(263, 33)
        Me.txtTANTOKANA.MaxLength = 20
        Me.txtTANTOKANA.Name = "txtTANTOKANA"
        Me.txtTANTOKANA.Size = New System.Drawing.Size(174, 25)
        Me.txtTANTOKANA.TabIndex = 1
        Me.txtTANTOKANA.Text = "12345678901234567890"
        '
        'txtTANTONAME
        '
        Me.txtTANTONAME.BackColor = System.Drawing.Color.White
        Me.txtTANTONAME.DisplayName = "担当者名"
        Me.txtTANTONAME.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtTANTONAME.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtTANTONAME.Location = New System.Drawing.Point(263, 3)
        Me.txtTANTONAME.MaxLength = 20
        Me.txtTANTONAME.Name = "txtTANTONAME"
        Me.txtTANTONAME.Size = New System.Drawing.Size(174, 25)
        Me.txtTANTONAME.TabIndex = 0
        Me.txtTANTONAME.Text = "12345678901234567890"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(168, 65)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 17)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "部課コード"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(168, 37)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 17)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "担当者カナ"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(168, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 17)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "担当者名"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(348, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 17)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "担当者コード"
        '
        'frmMENT0004
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 670)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.fraName)
        Me.Controls.Add(Me.dbgMeisai)
        Me.Controls.Add(Me.txtTANTOCODE)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMENT0004"
        Me.Text = ""
        Me.Controls.SetChildIndex(Me.txtTANTOCODE, 0)
        Me.Controls.SetChildIndex(Me.TitleBar, 0)
        Me.Controls.SetChildIndex(Me.FunctionKey, 0)
        Me.Controls.SetChildIndex(Me.dbgMeisai, 0)
        Me.Controls.SetChildIndex(Me.fraName, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        CType(Me.dbgMeisai, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fraName.ResumeLayout(False)
        Me.fraName.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtTANTOCODE As CommonUtility.WinFormControls.TypComboBox
    Friend WithEvents dbgMeisai As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents fraName As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtBUKACODE As CommonUtility.WinFormControls.TypComboBox
    Friend WithEvents txtTANTOKANA As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents txtTANTONAME As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents txtBUKANAME As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents txtPassword As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txtKengenCode As CommonUtility.WinFormControls.TypComboBox
    Friend WithEvents txtKengenName As CommonUtility.WinFormControls.TextBoxEx
End Class
