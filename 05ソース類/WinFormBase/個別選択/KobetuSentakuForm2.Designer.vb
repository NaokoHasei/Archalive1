<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class KobetuSentakuForm2
    'Inherits System.Windows.Forms.Form
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(KobetuSentakuForm2))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dbgMaster = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.btn全件 = New System.Windows.Forms.Button()
        Me.btnヤ = New System.Windows.Forms.Button()
        Me.btnラ = New System.Windows.Forms.Button()
        Me.btnワ = New System.Windows.Forms.Button()
        Me.btn他 = New System.Windows.Forms.Button()
        Me.btnカ = New System.Windows.Forms.Button()
        Me.btnサ = New System.Windows.Forms.Button()
        Me.btnタ = New System.Windows.Forms.Button()
        Me.btnナ = New System.Windows.Forms.Button()
        Me.btnハ = New System.Windows.Forms.Button()
        Me.btnマ = New System.Windows.Forms.Button()
        Me.btnア = New System.Windows.Forms.Button()
        Me.btni = New System.Windows.Forms.Button()
        Me.btnu = New System.Windows.Forms.Button()
        Me.btne = New System.Windows.Forms.Button()
        Me.btno = New System.Windows.Forms.Button()
        Me.btna = New System.Windows.Forms.Button()
        Me.txtMENUKEY = New CommonUtility.WinFormControls.TextBoxEx()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dbgMaster, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TitleBar
        '
        Me.TitleBar.AppearanceType = CommonUtility.WinFormControls.AppearanceType.Normal
        Me.TitleBar.EditMode = CommonUtility.WinFormControls.EditMode.None
        Me.TitleBar.Size = New System.Drawing.Size(577, 40)
        Me.TitleBar.Title = ""
        '
        'FunctionKey
        '
        Me.FunctionKey.ButtonWidth02 = 32
        Me.FunctionKey.ButtonWidth03 = 32
        Me.FunctionKey.ButtonWidth04 = 32
        Me.FunctionKey.ButtonWidth05 = 32
        Me.FunctionKey.ButtonWidth06 = 32
        Me.FunctionKey.ButtonWidth07 = 32
        Me.FunctionKey.ButtonWidth08 = 32
        Me.FunctionKey.ButtonWidth09 = 32
        Me.FunctionKey.ButtonWidth10 = 32
        Me.FunctionKey.Location = New System.Drawing.Point(0, 514)
        Me.FunctionKey.Size = New System.Drawing.Size(577, 64)
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dbgMaster)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 121)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(8, 0, 8, 8)
        Me.GroupBox1.Size = New System.Drawing.Size(559, 387)
        Me.GroupBox1.TabIndex = 18
        Me.GroupBox1.TabStop = False
        '
        'dbgMaster
        '
        Me.dbgMaster.AllowSort = False
        Me.dbgMaster.BackColor = System.Drawing.Color.Gainsboro
        Me.dbgMaster.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.dbgMaster.CaptionHeight = 16
        Me.dbgMaster.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dbgMaster.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.dbgMaster.GroupByCaption = "列でグループ化するには、ここに列ヘッダをドラッグします。"
        Me.dbgMaster.Images.Add(CType(resources.GetObject("dbgMaster.Images"), System.Drawing.Image))
        Me.dbgMaster.Location = New System.Drawing.Point(8, 17)
        Me.dbgMaster.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow
        Me.dbgMaster.Name = "dbgMaster"
        Me.dbgMaster.PreviewInfo.Caption = "印刷プレビューウィンドウ"
        Me.dbgMaster.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.dbgMaster.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.dbgMaster.PreviewInfo.ZoomFactor = 75.0R
        Me.dbgMaster.PrintInfo.PageSettings = CType(resources.GetObject("dbgMaster.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.dbgMaster.RowHeight = 14
        Me.dbgMaster.Size = New System.Drawing.Size(543, 362)
        Me.dbgMaster.TabIndex = 0
        Me.dbgMaster.Text = "C1TrueDBGrid1"
        Me.dbgMaster.UseCompatibleTextRendering = False
        Me.dbgMaster.PropBag = resources.GetString("dbgMaster.PropBag")
        '
        'btn全件
        '
        Me.btn全件.BackColor = System.Drawing.Color.Transparent
        Me.btn全件.ForeColor = System.Drawing.Color.Black
        Me.btn全件.Location = New System.Drawing.Point(456, 51)
        Me.btn全件.Margin = New System.Windows.Forms.Padding(0)
        Me.btn全件.Name = "btn全件"
        Me.btn全件.Size = New System.Drawing.Size(65, 34)
        Me.btn全件.TabIndex = 11
        Me.btn全件.Text = "全件"
        Me.btn全件.UseVisualStyleBackColor = False
        '
        'btnヤ
        '
        Me.btnヤ.BackColor = System.Drawing.Color.Transparent
        Me.btnヤ.ForeColor = System.Drawing.Color.Black
        Me.btnヤ.Location = New System.Drawing.Point(312, 51)
        Me.btnヤ.Margin = New System.Windows.Forms.Padding(0)
        Me.btnヤ.Name = "btnヤ"
        Me.btnヤ.Size = New System.Drawing.Size(36, 34)
        Me.btnヤ.TabIndex = 7
        Me.btnヤ.Text = "ヤ"
        Me.btnヤ.UseVisualStyleBackColor = False
        '
        'btnラ
        '
        Me.btnラ.BackColor = System.Drawing.Color.Transparent
        Me.btnラ.ForeColor = System.Drawing.Color.Black
        Me.btnラ.Location = New System.Drawing.Point(348, 51)
        Me.btnラ.Margin = New System.Windows.Forms.Padding(0)
        Me.btnラ.Name = "btnラ"
        Me.btnラ.Size = New System.Drawing.Size(36, 34)
        Me.btnラ.TabIndex = 8
        Me.btnラ.Text = "ラ"
        Me.btnラ.UseVisualStyleBackColor = False
        '
        'btnワ
        '
        Me.btnワ.BackColor = System.Drawing.Color.Transparent
        Me.btnワ.ForeColor = System.Drawing.Color.Black
        Me.btnワ.Location = New System.Drawing.Point(384, 51)
        Me.btnワ.Margin = New System.Windows.Forms.Padding(0)
        Me.btnワ.Name = "btnワ"
        Me.btnワ.Size = New System.Drawing.Size(36, 34)
        Me.btnワ.TabIndex = 9
        Me.btnワ.Text = "ワ"
        Me.btnワ.UseVisualStyleBackColor = False
        '
        'btn他
        '
        Me.btn他.BackColor = System.Drawing.Color.Transparent
        Me.btn他.ForeColor = System.Drawing.Color.Black
        Me.btn他.Location = New System.Drawing.Point(420, 51)
        Me.btn他.Margin = New System.Windows.Forms.Padding(0)
        Me.btn他.Name = "btn他"
        Me.btn他.Size = New System.Drawing.Size(36, 34)
        Me.btn他.TabIndex = 10
        Me.btn他.Text = "他"
        Me.btn他.UseVisualStyleBackColor = False
        '
        'btnカ
        '
        Me.btnカ.BackColor = System.Drawing.Color.Transparent
        Me.btnカ.ForeColor = System.Drawing.Color.Black
        Me.btnカ.Location = New System.Drawing.Point(96, 51)
        Me.btnカ.Margin = New System.Windows.Forms.Padding(0)
        Me.btnカ.Name = "btnカ"
        Me.btnカ.Size = New System.Drawing.Size(36, 34)
        Me.btnカ.TabIndex = 1
        Me.btnカ.Text = "カ"
        Me.btnカ.UseVisualStyleBackColor = False
        '
        'btnサ
        '
        Me.btnサ.BackColor = System.Drawing.Color.Transparent
        Me.btnサ.ForeColor = System.Drawing.Color.Black
        Me.btnサ.Location = New System.Drawing.Point(132, 51)
        Me.btnサ.Margin = New System.Windows.Forms.Padding(0)
        Me.btnサ.Name = "btnサ"
        Me.btnサ.Size = New System.Drawing.Size(36, 34)
        Me.btnサ.TabIndex = 2
        Me.btnサ.Text = "サ"
        Me.btnサ.UseVisualStyleBackColor = False
        '
        'btnタ
        '
        Me.btnタ.BackColor = System.Drawing.Color.Transparent
        Me.btnタ.ForeColor = System.Drawing.Color.Black
        Me.btnタ.Location = New System.Drawing.Point(168, 51)
        Me.btnタ.Margin = New System.Windows.Forms.Padding(0)
        Me.btnタ.Name = "btnタ"
        Me.btnタ.Size = New System.Drawing.Size(36, 34)
        Me.btnタ.TabIndex = 3
        Me.btnタ.Text = "タ"
        Me.btnタ.UseVisualStyleBackColor = False
        '
        'btnナ
        '
        Me.btnナ.BackColor = System.Drawing.Color.Transparent
        Me.btnナ.ForeColor = System.Drawing.Color.Black
        Me.btnナ.Location = New System.Drawing.Point(204, 51)
        Me.btnナ.Margin = New System.Windows.Forms.Padding(0)
        Me.btnナ.Name = "btnナ"
        Me.btnナ.Size = New System.Drawing.Size(36, 34)
        Me.btnナ.TabIndex = 4
        Me.btnナ.Text = "ナ"
        Me.btnナ.UseVisualStyleBackColor = False
        '
        'btnハ
        '
        Me.btnハ.BackColor = System.Drawing.Color.Transparent
        Me.btnハ.ForeColor = System.Drawing.Color.Black
        Me.btnハ.Location = New System.Drawing.Point(240, 51)
        Me.btnハ.Margin = New System.Windows.Forms.Padding(0)
        Me.btnハ.Name = "btnハ"
        Me.btnハ.Size = New System.Drawing.Size(36, 34)
        Me.btnハ.TabIndex = 5
        Me.btnハ.Text = "ハ"
        Me.btnハ.UseVisualStyleBackColor = False
        '
        'btnマ
        '
        Me.btnマ.BackColor = System.Drawing.Color.Transparent
        Me.btnマ.ForeColor = System.Drawing.Color.Black
        Me.btnマ.Location = New System.Drawing.Point(276, 51)
        Me.btnマ.Margin = New System.Windows.Forms.Padding(0)
        Me.btnマ.Name = "btnマ"
        Me.btnマ.Size = New System.Drawing.Size(36, 34)
        Me.btnマ.TabIndex = 6
        Me.btnマ.Text = "マ"
        Me.btnマ.UseVisualStyleBackColor = False
        '
        'btnア
        '
        Me.btnア.BackColor = System.Drawing.Color.Transparent
        Me.btnア.ForeColor = System.Drawing.Color.Black
        Me.btnア.Location = New System.Drawing.Point(60, 51)
        Me.btnア.Margin = New System.Windows.Forms.Padding(0)
        Me.btnア.Name = "btnア"
        Me.btnア.Size = New System.Drawing.Size(36, 34)
        Me.btnア.TabIndex = 0
        Me.btnア.Text = "ア"
        Me.btnア.UseVisualStyleBackColor = False
        '
        'btni
        '
        Me.btni.BackColor = System.Drawing.Color.Transparent
        Me.btni.ForeColor = System.Drawing.Color.Black
        Me.btni.Location = New System.Drawing.Point(96, 85)
        Me.btni.Margin = New System.Windows.Forms.Padding(0)
        Me.btni.Name = "btni"
        Me.btni.Size = New System.Drawing.Size(36, 34)
        Me.btni.TabIndex = 13
        Me.btni.UseVisualStyleBackColor = False
        '
        'btnu
        '
        Me.btnu.BackColor = System.Drawing.Color.Transparent
        Me.btnu.ForeColor = System.Drawing.Color.Black
        Me.btnu.Location = New System.Drawing.Point(132, 85)
        Me.btnu.Margin = New System.Windows.Forms.Padding(0)
        Me.btnu.Name = "btnu"
        Me.btnu.Size = New System.Drawing.Size(36, 34)
        Me.btnu.TabIndex = 14
        Me.btnu.UseVisualStyleBackColor = False
        '
        'btne
        '
        Me.btne.BackColor = System.Drawing.Color.Transparent
        Me.btne.ForeColor = System.Drawing.Color.Black
        Me.btne.Location = New System.Drawing.Point(168, 85)
        Me.btne.Margin = New System.Windows.Forms.Padding(0)
        Me.btne.Name = "btne"
        Me.btne.Size = New System.Drawing.Size(36, 34)
        Me.btne.TabIndex = 15
        Me.btne.UseVisualStyleBackColor = False
        '
        'btno
        '
        Me.btno.BackColor = System.Drawing.Color.Transparent
        Me.btno.ForeColor = System.Drawing.Color.Black
        Me.btno.Location = New System.Drawing.Point(204, 85)
        Me.btno.Margin = New System.Windows.Forms.Padding(0)
        Me.btno.Name = "btno"
        Me.btno.Size = New System.Drawing.Size(36, 34)
        Me.btno.TabIndex = 16
        Me.btno.UseVisualStyleBackColor = False
        '
        'btna
        '
        Me.btna.BackColor = System.Drawing.Color.Transparent
        Me.btna.ForeColor = System.Drawing.Color.Black
        Me.btna.Location = New System.Drawing.Point(60, 85)
        Me.btna.Margin = New System.Windows.Forms.Padding(0)
        Me.btna.Name = "btna"
        Me.btna.Size = New System.Drawing.Size(36, 34)
        Me.btna.TabIndex = 12
        Me.btna.UseVisualStyleBackColor = False
        '
        'txtMENUKEY
        '
        Me.txtMENUKEY.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.txtMENUKEY.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtMENUKEY.Location = New System.Drawing.Point(243, 91)
        Me.txtMENUKEY.MoveFocusAfterEnter = False
        Me.txtMENUKEY.Name = "txtMENUKEY"
        Me.txtMENUKEY.Size = New System.Drawing.Size(278, 23)
        Me.txtMENUKEY.TabIndex = 0
        Me.txtMENUKEY.Text = ""
        '
        'KobetuSentakuForm2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(577, 578)
        Me.Controls.Add(Me.txtMENUKEY)
        Me.Controls.Add(Me.btni)
        Me.Controls.Add(Me.btnu)
        Me.Controls.Add(Me.btne)
        Me.Controls.Add(Me.btno)
        Me.Controls.Add(Me.btna)
        Me.Controls.Add(Me.btn全件)
        Me.Controls.Add(Me.btnヤ)
        Me.Controls.Add(Me.btnラ)
        Me.Controls.Add(Me.btnワ)
        Me.Controls.Add(Me.btn他)
        Me.Controls.Add(Me.btnカ)
        Me.Controls.Add(Me.btnサ)
        Me.Controls.Add(Me.btnタ)
        Me.Controls.Add(Me.btnナ)
        Me.Controls.Add(Me.btnハ)
        Me.Controls.Add(Me.btnマ)
        Me.Controls.Add(Me.btnア)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "KobetuSentakuForm2"
        Me.Text = ""
        Me.Controls.SetChildIndex(Me.TitleBar, 0)
        Me.Controls.SetChildIndex(Me.FunctionKey, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.btnア, 0)
        Me.Controls.SetChildIndex(Me.btnマ, 0)
        Me.Controls.SetChildIndex(Me.btnハ, 0)
        Me.Controls.SetChildIndex(Me.btnナ, 0)
        Me.Controls.SetChildIndex(Me.btnタ, 0)
        Me.Controls.SetChildIndex(Me.btnサ, 0)
        Me.Controls.SetChildIndex(Me.btnカ, 0)
        Me.Controls.SetChildIndex(Me.btn他, 0)
        Me.Controls.SetChildIndex(Me.btnワ, 0)
        Me.Controls.SetChildIndex(Me.btnラ, 0)
        Me.Controls.SetChildIndex(Me.btnヤ, 0)
        Me.Controls.SetChildIndex(Me.btn全件, 0)
        Me.Controls.SetChildIndex(Me.btna, 0)
        Me.Controls.SetChildIndex(Me.btno, 0)
        Me.Controls.SetChildIndex(Me.btne, 0)
        Me.Controls.SetChildIndex(Me.btnu, 0)
        Me.Controls.SetChildIndex(Me.btni, 0)
        Me.Controls.SetChildIndex(Me.txtMENUKEY, 0)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dbgMaster, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Protected WithEvents dbgMaster As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents btn全件 As System.Windows.Forms.Button
    Friend WithEvents btnヤ As System.Windows.Forms.Button
    Friend WithEvents btnラ As System.Windows.Forms.Button
    Friend WithEvents btnワ As System.Windows.Forms.Button
    Friend WithEvents btn他 As System.Windows.Forms.Button
    Friend WithEvents btnカ As System.Windows.Forms.Button
    Friend WithEvents btnサ As System.Windows.Forms.Button
    Friend WithEvents btnタ As System.Windows.Forms.Button
    Friend WithEvents btnナ As System.Windows.Forms.Button
    Friend WithEvents btnハ As System.Windows.Forms.Button
    Friend WithEvents btnマ As System.Windows.Forms.Button
    Friend WithEvents btnア As System.Windows.Forms.Button
    Friend WithEvents btni As System.Windows.Forms.Button
    Friend WithEvents btnu As System.Windows.Forms.Button
    Friend WithEvents btne As System.Windows.Forms.Button
    Friend WithEvents btno As System.Windows.Forms.Button
    Friend WithEvents btna As System.Windows.Forms.Button
    Friend WithEvents txtMENUKEY As CommonUtility.WinFormControls.TextBoxEx
End Class
