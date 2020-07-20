<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SEARCH_TANTO
    'Inherits System.Windows.Forms.Form
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SEARCH_TANTO))
        Me.fraMain = New System.Windows.Forms.GroupBox()
        Me.lblPosition = New System.Windows.Forms.Label()
        Me.gridData = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.pnlKey = New System.Windows.Forms.Panel()
        Me.ButtonSub5 = New System.Windows.Forms.Button()
        Me.ButtonSub4 = New System.Windows.Forms.Button()
        Me.ButtonSub3 = New System.Windows.Forms.Button()
        Me.ButtonSub2 = New System.Windows.Forms.Button()
        Me.ButtonSub1 = New System.Windows.Forms.Button()
        Me.Button12 = New System.Windows.Forms.Button()
        Me.Button11 = New System.Windows.Forms.Button()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtINPUTWORD = New CommonUtility.WinFormControls.TextBoxEx()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.btnManual1 = New System.Windows.Forms.LinkLabel()
        Me.fraMain.SuspendLayout()
        CType(Me.gridData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlKey.SuspendLayout()
        Me.SuspendLayout()
        '
        'TitleBar
        '
        Me.TitleBar.AppearanceType = CommonUtility.WinFormControls.AppearanceType.Normal
        Me.TitleBar.EditMode = CommonUtility.WinFormControls.EditMode.None
        Me.TitleBar.Size = New System.Drawing.Size(483, 40)
        Me.TitleBar.Title = "ＸＸ　検索メニュー"
        Me.TitleBar.Visible = False
        '
        'FunctionKey
        '
        Me.FunctionKey.ButtonHeight = 34
        Me.FunctionKey.ButtonWidth01 = 60
        Me.FunctionKey.ButtonWidth02 = 30
        Me.FunctionKey.ButtonWidth03 = 30
        Me.FunctionKey.ButtonWidth04 = 30
        Me.FunctionKey.ButtonWidth05 = 60
        Me.FunctionKey.ButtonWidth06 = 30
        Me.FunctionKey.ButtonWidth07 = 30
        Me.FunctionKey.ButtonWidth08 = 30
        Me.FunctionKey.ButtonWidth09 = 30
        Me.FunctionKey.ButtonWidth10 = 30
        Me.FunctionKey.ButtonWidth11 = 30
        Me.FunctionKey.ButtonWidth12 = 60
        Me.FunctionKey.Dock = System.Windows.Forms.DockStyle.None
        Me.FunctionKey.Location = New System.Drawing.Point(1, 252)
        Me.FunctionKey.Size = New System.Drawing.Size(477, 50)
        '
        'fraMain
        '
        Me.fraMain.Controls.Add(Me.btnManual1)
        Me.fraMain.Controls.Add(Me.lblPosition)
        Me.fraMain.Controls.Add(Me.gridData)
        Me.fraMain.Controls.Add(Me.pnlKey)
        Me.fraMain.Controls.Add(Me.lblTitle)
        Me.fraMain.Location = New System.Drawing.Point(0, -10)
        Me.fraMain.Name = "fraMain"
        Me.fraMain.Size = New System.Drawing.Size(483, 316)
        Me.fraMain.TabIndex = 57
        Me.fraMain.TabStop = False
        '
        'lblPosition
        '
        Me.lblPosition.AutoSize = True
        Me.lblPosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPosition.Location = New System.Drawing.Point(18, 232)
        Me.lblPosition.Name = "lblPosition"
        Me.lblPosition.Size = New System.Drawing.Size(66, 19)
        Me.lblPosition.TabIndex = 62
        Me.lblPosition.Text = "lblPosition"
        Me.lblPosition.Visible = False
        '
        'gridData
        '
        Me.gridData.AllowUpdate = False
        Me.gridData.BackColor = System.Drawing.Color.Gainsboro
        Me.gridData.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.gridData.CaptionHeight = 16
        Me.gridData.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.gridData.GroupByCaption = "列でグループ化するには、ここに列ヘッダをドラッグします。"
        Me.gridData.Images.Add(CType(resources.GetObject("gridData.Images"), System.Drawing.Image))
        Me.gridData.Location = New System.Drawing.Point(8, 109)
        Me.gridData.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow
        Me.gridData.Name = "gridData"
        Me.gridData.PreviewInfo.Caption = "印刷プレビューウィンドウ"
        Me.gridData.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.gridData.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.gridData.PreviewInfo.ZoomFactor = 75.0R
        Me.gridData.PrintInfo.PageSettings = CType(resources.GetObject("gridData.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.gridData.RowHeight = 14
        Me.gridData.Size = New System.Drawing.Size(465, 148)
        Me.gridData.TabIndex = 60
        Me.gridData.TabStop = False
        Me.gridData.UseCompatibleTextRendering = False
        Me.gridData.PropBag = resources.GetString("gridData.PropBag")
        '
        'pnlKey
        '
        Me.pnlKey.Controls.Add(Me.ButtonSub5)
        Me.pnlKey.Controls.Add(Me.ButtonSub4)
        Me.pnlKey.Controls.Add(Me.ButtonSub3)
        Me.pnlKey.Controls.Add(Me.ButtonSub2)
        Me.pnlKey.Controls.Add(Me.ButtonSub1)
        Me.pnlKey.Controls.Add(Me.Button12)
        Me.pnlKey.Controls.Add(Me.Button11)
        Me.pnlKey.Controls.Add(Me.Button10)
        Me.pnlKey.Controls.Add(Me.Button9)
        Me.pnlKey.Controls.Add(Me.Button8)
        Me.pnlKey.Controls.Add(Me.Button7)
        Me.pnlKey.Controls.Add(Me.Button6)
        Me.pnlKey.Controls.Add(Me.Button5)
        Me.pnlKey.Controls.Add(Me.Button4)
        Me.pnlKey.Controls.Add(Me.Button3)
        Me.pnlKey.Controls.Add(Me.Button2)
        Me.pnlKey.Controls.Add(Me.Button1)
        Me.pnlKey.Controls.Add(Me.txtINPUTWORD)
        Me.pnlKey.Location = New System.Drawing.Point(6, 42)
        Me.pnlKey.Name = "pnlKey"
        Me.pnlKey.Size = New System.Drawing.Size(467, 74)
        Me.pnlKey.TabIndex = 59
        '
        'ButtonSub5
        '
        Me.ButtonSub5.BackColor = System.Drawing.Color.Transparent
        Me.ButtonSub5.ForeColor = System.Drawing.Color.Black
        Me.ButtonSub5.Location = New System.Drawing.Point(146, 34)
        Me.ButtonSub5.Name = "ButtonSub5"
        Me.ButtonSub5.Size = New System.Drawing.Size(32, 30)
        Me.ButtonSub5.TabIndex = 31
        Me.ButtonSub5.Text = "オ"
        Me.ButtonSub5.UseVisualStyleBackColor = False
        '
        'ButtonSub4
        '
        Me.ButtonSub4.BackColor = System.Drawing.Color.Transparent
        Me.ButtonSub4.ForeColor = System.Drawing.Color.Black
        Me.ButtonSub4.Location = New System.Drawing.Point(115, 34)
        Me.ButtonSub4.Name = "ButtonSub4"
        Me.ButtonSub4.Size = New System.Drawing.Size(32, 30)
        Me.ButtonSub4.TabIndex = 30
        Me.ButtonSub4.Text = "エ"
        Me.ButtonSub4.UseVisualStyleBackColor = False
        '
        'ButtonSub3
        '
        Me.ButtonSub3.BackColor = System.Drawing.Color.Transparent
        Me.ButtonSub3.ForeColor = System.Drawing.Color.Black
        Me.ButtonSub3.Location = New System.Drawing.Point(84, 34)
        Me.ButtonSub3.Name = "ButtonSub3"
        Me.ButtonSub3.Size = New System.Drawing.Size(32, 30)
        Me.ButtonSub3.TabIndex = 29
        Me.ButtonSub3.Text = "ウ"
        Me.ButtonSub3.UseVisualStyleBackColor = False
        '
        'ButtonSub2
        '
        Me.ButtonSub2.BackColor = System.Drawing.Color.Transparent
        Me.ButtonSub2.ForeColor = System.Drawing.Color.Black
        Me.ButtonSub2.Location = New System.Drawing.Point(53, 34)
        Me.ButtonSub2.Name = "ButtonSub2"
        Me.ButtonSub2.Size = New System.Drawing.Size(32, 30)
        Me.ButtonSub2.TabIndex = 28
        Me.ButtonSub2.Text = "イ"
        Me.ButtonSub2.UseVisualStyleBackColor = False
        '
        'ButtonSub1
        '
        Me.ButtonSub1.BackColor = System.Drawing.Color.Transparent
        Me.ButtonSub1.ForeColor = System.Drawing.Color.Black
        Me.ButtonSub1.Location = New System.Drawing.Point(22, 34)
        Me.ButtonSub1.Name = "ButtonSub1"
        Me.ButtonSub1.Size = New System.Drawing.Size(32, 30)
        Me.ButtonSub1.TabIndex = 27
        Me.ButtonSub1.Text = "ア"
        Me.ButtonSub1.UseVisualStyleBackColor = False
        '
        'Button12
        '
        Me.Button12.BackColor = System.Drawing.Color.Transparent
        Me.Button12.ForeColor = System.Drawing.Color.Black
        Me.Button12.Location = New System.Drawing.Point(369, 3)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(60, 30)
        Me.Button12.TabIndex = 26
        Me.Button12.Text = "全件"
        Me.Button12.UseVisualStyleBackColor = False
        '
        'Button11
        '
        Me.Button11.BackColor = System.Drawing.Color.Transparent
        Me.Button11.ForeColor = System.Drawing.Color.Black
        Me.Button11.Location = New System.Drawing.Point(335, 3)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(32, 30)
        Me.Button11.TabIndex = 25
        Me.Button11.Text = "他"
        Me.Button11.UseVisualStyleBackColor = False
        '
        'Button10
        '
        Me.Button10.BackColor = System.Drawing.Color.Transparent
        Me.Button10.ForeColor = System.Drawing.Color.Black
        Me.Button10.Location = New System.Drawing.Point(304, 3)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(32, 30)
        Me.Button10.TabIndex = 24
        Me.Button10.Text = "ワ"
        Me.Button10.UseVisualStyleBackColor = False
        '
        'Button9
        '
        Me.Button9.BackColor = System.Drawing.Color.Transparent
        Me.Button9.ForeColor = System.Drawing.Color.Black
        Me.Button9.Location = New System.Drawing.Point(273, 3)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(32, 30)
        Me.Button9.TabIndex = 23
        Me.Button9.Text = "ラ"
        Me.Button9.UseVisualStyleBackColor = False
        '
        'Button8
        '
        Me.Button8.BackColor = System.Drawing.Color.Transparent
        Me.Button8.ForeColor = System.Drawing.Color.Black
        Me.Button8.Location = New System.Drawing.Point(242, 3)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(32, 30)
        Me.Button8.TabIndex = 22
        Me.Button8.Text = "ヤ"
        Me.Button8.UseVisualStyleBackColor = False
        '
        'Button7
        '
        Me.Button7.BackColor = System.Drawing.Color.Transparent
        Me.Button7.ForeColor = System.Drawing.Color.Black
        Me.Button7.Location = New System.Drawing.Point(211, 3)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(32, 30)
        Me.Button7.TabIndex = 21
        Me.Button7.Text = "マ"
        Me.Button7.UseVisualStyleBackColor = False
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.Color.Transparent
        Me.Button6.ForeColor = System.Drawing.Color.Black
        Me.Button6.Location = New System.Drawing.Point(180, 3)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(32, 30)
        Me.Button6.TabIndex = 20
        Me.Button6.Text = "ハ"
        Me.Button6.UseVisualStyleBackColor = False
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.Transparent
        Me.Button5.ForeColor = System.Drawing.Color.Black
        Me.Button5.Location = New System.Drawing.Point(146, 3)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(32, 30)
        Me.Button5.TabIndex = 19
        Me.Button5.Text = "ナ"
        Me.Button5.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.Transparent
        Me.Button4.ForeColor = System.Drawing.Color.Black
        Me.Button4.Location = New System.Drawing.Point(115, 3)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(32, 30)
        Me.Button4.TabIndex = 18
        Me.Button4.Text = "タ"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Transparent
        Me.Button3.ForeColor = System.Drawing.Color.Black
        Me.Button3.Location = New System.Drawing.Point(84, 3)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(32, 30)
        Me.Button3.TabIndex = 17
        Me.Button3.Text = "サ"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Transparent
        Me.Button2.ForeColor = System.Drawing.Color.Black
        Me.Button2.Location = New System.Drawing.Point(53, 3)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(32, 30)
        Me.Button2.TabIndex = 16
        Me.Button2.Text = "カ"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.ForeColor = System.Drawing.Color.Black
        Me.Button1.Location = New System.Drawing.Point(22, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(32, 30)
        Me.Button1.TabIndex = 15
        Me.Button1.Text = "ア"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'txtINPUTWORD
        '
        Me.txtINPUTWORD.DisplayName = "手入力"
        Me.txtINPUTWORD.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtINPUTWORD.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.txtINPUTWORD.Location = New System.Drawing.Point(180, 38)
        Me.txtINPUTWORD.MaxLength = 30
        Me.txtINPUTWORD.Name = "txtINPUTWORD"
        Me.txtINPUTWORD.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtINPUTWORD.Size = New System.Drawing.Size(246, 22)
        Me.txtINPUTWORD.TabIndex = 2
        Me.txtINPUTWORD.UseDirectoryPathValidator = True
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.Color.DarkSlateBlue
        Me.lblTitle.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblTitle.ForeColor = System.Drawing.SystemColors.Window
        Me.lblTitle.Location = New System.Drawing.Point(-3, 10)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(486, 28)
        Me.lblTitle.TabIndex = 58
        Me.lblTitle.Text = "担当者　検索メニュー"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnManual1
        '
        Me.btnManual1.ActiveLinkColor = System.Drawing.Color.White
        Me.btnManual1.AutoSize = True
        Me.btnManual1.BackColor = System.Drawing.Color.DarkSlateBlue
        Me.btnManual1.Font = New System.Drawing.Font("メイリオ", 9.0!)
        Me.btnManual1.LinkColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(179, Byte), Integer))
        Me.btnManual1.Location = New System.Drawing.Point(417, 15)
        Me.btnManual1.Name = "btnManual1"
        Me.btnManual1.Size = New System.Drawing.Size(56, 18)
        Me.btnManual1.TabIndex = 97
        Me.btnManual1.TabStop = True
        Me.btnManual1.Text = "操作説明"
        '
        'SEARCH_TANTO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(483, 306)
        Me.Controls.Add(Me.fraMain)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "SEARCH_TANTO"
        Me.Text = ""
        Me.Controls.SetChildIndex(Me.TitleBar, 0)
        Me.Controls.SetChildIndex(Me.fraMain, 0)
        Me.Controls.SetChildIndex(Me.FunctionKey, 0)
        Me.fraMain.ResumeLayout(False)
        Me.fraMain.PerformLayout()
        CType(Me.gridData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlKey.ResumeLayout(False)
        Me.pnlKey.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents fraMain As System.Windows.Forms.GroupBox
    Protected WithEvents gridData As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents pnlKey As System.Windows.Forms.Panel
    Friend WithEvents ButtonSub5 As System.Windows.Forms.Button
    Friend WithEvents ButtonSub4 As System.Windows.Forms.Button
    Friend WithEvents ButtonSub3 As System.Windows.Forms.Button
    Friend WithEvents ButtonSub2 As System.Windows.Forms.Button
    Friend WithEvents ButtonSub1 As System.Windows.Forms.Button
    Friend WithEvents Button12 As System.Windows.Forms.Button
    Friend WithEvents Button11 As System.Windows.Forms.Button
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtINPUTWORD As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents lblTitle As System.Windows.Forms.Label

    Public Sub New()
        MyBase.New()

        ' この呼び出しは Windows フォーム デザイナで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後に初期化を追加します。

    End Sub

    Public Sub New(ByVal pPosition As Integer)
        Me.New()
        Me.lblPosition.Text = pPosition.ToString
    End Sub
    Friend WithEvents lblPosition As System.Windows.Forms.Label
    Friend WithEvents btnManual1 As LinkLabel
End Class
