<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSEI0001_Meisai
    Inherits winformbase.Formbase

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSEI0001_Meisai))
        Me.tpnlGokeiKin = New System.Windows.Forms.TableLayoutPanel()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.dbgMEISAI = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.chkSeikyuAll = New System.Windows.Forms.CheckBox()
        Me.tpnlGokeiKin.SuspendLayout()
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
        Me.FunctionKey.Location = New System.Drawing.Point(0, 609)
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
        'dbgMEISAI
        '
        Me.dbgMEISAI.BackColor = System.Drawing.Color.Thistle
        Me.dbgMEISAI.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.dbgMEISAI.CaptionHeight = 16
        Me.dbgMEISAI.Cursor = System.Windows.Forms.Cursors.Default
        Me.dbgMEISAI.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.dbgMEISAI.GroupByCaption = "列でグループ化するには、ここに列ヘッダをドラッグします。"
        Me.dbgMEISAI.Images.Add(CType(resources.GetObject("dbgMEISAI.Images"), System.Drawing.Image))
        Me.dbgMEISAI.Location = New System.Drawing.Point(0, 69)
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
        Me.dbgMEISAI.Size = New System.Drawing.Size(1018, 534)
        Me.dbgMEISAI.SplitDividerSize = New System.Drawing.Size(0, 0)
        Me.dbgMEISAI.TabIndex = 10
        Me.dbgMEISAI.UseCompatibleTextRendering = False
        Me.dbgMEISAI.PropBag = resources.GetString("dbgMEISAI.PropBag")
        '
        'chkSeikyuAll
        '
        Me.chkSeikyuAll.AutoSize = True
        Me.chkSeikyuAll.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.chkSeikyuAll.Location = New System.Drawing.Point(10, 46)
        Me.chkSeikyuAll.Name = "chkSeikyuAll"
        Me.chkSeikyuAll.Size = New System.Drawing.Size(71, 21)
        Me.chkSeikyuAll.TabIndex = 1
        Me.chkSeikyuAll.Text = "全て請求"
        Me.chkSeikyuAll.UseVisualStyleBackColor = True
        '
        'frmSEI0001_Meisai
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 673)
        Me.Controls.Add(Me.chkSeikyuAll)
        Me.Controls.Add(Me.dbgMEISAI)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSEI0001_Meisai"
        Me.Text = ""
        Me.Controls.SetChildIndex(Me.dbgMEISAI, 0)
        Me.Controls.SetChildIndex(Me.FunctionKey, 0)
        Me.Controls.SetChildIndex(Me.TitleBar, 0)
        Me.Controls.SetChildIndex(Me.chkSeikyuAll, 0)
        Me.tpnlGokeiKin.ResumeLayout(False)
        Me.tpnlGokeiKin.PerformLayout()
        CType(Me.dbgMEISAI, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tpnlGokeiKin As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Protected WithEvents dbgMEISAI As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents chkSeikyuAll As CheckBox
End Class
