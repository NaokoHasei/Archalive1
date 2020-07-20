<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class KobetuSentakuForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(KobetuSentakuForm))
        Me.dbgMaster = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.dbgSentaku = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblCount = New CommonUtility.WinFormControls.TextBoxEx()
        CType(Me.dbgMaster, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dbgSentaku, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.FunctionKey.Location = New System.Drawing.Point(0, 642)
        '
        'dbgMaster
        '
        Me.dbgMaster.BackColor = System.Drawing.Color.Gainsboro
        Me.dbgMaster.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.dbgMaster.CaptionHeight = 16
        Me.dbgMaster.GroupByCaption = "列でグループ化するには、ここに列ヘッダをドラッグします。"
        Me.dbgMaster.Images.Add(CType(resources.GetObject("dbgMaster.Images"), System.Drawing.Image))
        Me.dbgMaster.Location = New System.Drawing.Point(513, 101)
        Me.dbgMaster.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow
        Me.dbgMaster.Name = "dbgMaster"
        Me.dbgMaster.PreviewInfo.Caption = "印刷プレビューウィンドウ"
        Me.dbgMaster.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.dbgMaster.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.dbgMaster.PreviewInfo.ZoomFactor = 75.0R
        Me.dbgMaster.PrintInfo.PageSettings = CType(resources.GetObject("dbgMaster.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.dbgMaster.RowHeight = 14
        Me.dbgMaster.Size = New System.Drawing.Size(496, 526)
        Me.dbgMaster.TabIndex = 3
        Me.dbgMaster.Text = "C1TrueDBGrid1"
        Me.dbgMaster.UseCompatibleTextRendering = False
        Me.dbgMaster.PropBag = resources.GetString("dbgMaster.PropBag")
        '
        'dbgSentaku
        '
        Me.dbgSentaku.BackColor = System.Drawing.Color.Gainsboro
        Me.dbgSentaku.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.dbgSentaku.CaptionHeight = 16
        Me.dbgSentaku.GroupByCaption = "列でグループ化するには、ここに列ヘッダをドラッグします。"
        Me.dbgSentaku.Images.Add(CType(resources.GetObject("dbgSentaku.Images"), System.Drawing.Image))
        Me.dbgSentaku.Location = New System.Drawing.Point(9, 227)
        Me.dbgSentaku.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow
        Me.dbgSentaku.Name = "dbgSentaku"
        Me.dbgSentaku.PreviewInfo.Caption = "印刷プレビューウィンドウ"
        Me.dbgSentaku.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.dbgSentaku.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.dbgSentaku.PreviewInfo.ZoomFactor = 75.0R
        Me.dbgSentaku.PrintInfo.PageSettings = CType(resources.GetObject("dbgSentaku.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.dbgSentaku.RowHeight = 14
        Me.dbgSentaku.Size = New System.Drawing.Size(496, 400)
        Me.dbgSentaku.TabIndex = 4
        Me.dbgSentaku.Text = "C1TrueDBGrid1"
        Me.dbgSentaku.UseCompatibleTextRendering = False
        Me.dbgSentaku.PropBag = resources.GetString("dbgSentaku.PropBag")
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(484, 202)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(19, 17)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "件"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 205)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 17)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "＜選択***＞"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(510, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 17)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "＜***一覧＞"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 75)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 17)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "＜***一覧条件＞"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Gainsboro
        Me.GroupBox1.Location = New System.Drawing.Point(9, 93)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(498, 100)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'lblCount
        '
        Me.lblCount.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblCount.Enabled = False
        Me.lblCount.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblCount.Location = New System.Drawing.Point(361, 199)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.ReadOnly = True
        Me.lblCount.Size = New System.Drawing.Size(118, 22)
        Me.lblCount.TabIndex = 26
        Me.lblCount.Text = ""
        Me.lblCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'KobetuSentakuForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange
        Me.ClientSize = New System.Drawing.Size(1018, 706)
        Me.Controls.Add(Me.lblCount)
        Me.Controls.Add(Me.dbgMaster)
        Me.Controls.Add(Me.dbgSentaku)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "KobetuSentakuForm"
        Me.Text = ""
        Me.Controls.SetChildIndex(Me.TitleBar, 0)
        Me.Controls.SetChildIndex(Me.FunctionKey, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.dbgSentaku, 0)
        Me.Controls.SetChildIndex(Me.dbgMaster, 0)
        Me.Controls.SetChildIndex(Me.lblCount, 0)
        CType(Me.dbgMaster, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dbgSentaku, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Protected WithEvents dbgMaster As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Protected WithEvents dbgSentaku As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Protected WithEvents Label4 As System.Windows.Forms.Label
    Protected WithEvents Label3 As System.Windows.Forms.Label
    Protected WithEvents Label2 As System.Windows.Forms.Label
    Protected WithEvents Label1 As System.Windows.Forms.Label
    Protected WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Protected WithEvents lblCount As CommonUtility.WinFormControls.TextBoxEx
End Class
