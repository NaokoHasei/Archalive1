<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMSE0020
    Inherits winformbase.FormBase

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMSE0020))
        Me.fraKeyInput = New System.Windows.Forms.Panel()
        Me.txtCOMMENT = New CommonUtility.WinFormControls.TextBoxEx()
        Me.txtDATA = New CommonUtility.WinFormControls.TextBoxEx()
        Me.txtDATAKEY = New CommonUtility.WinFormControls.TextBoxEx()
        Me.txtCATEGORYID = New CommonUtility.WinFormControls.TextBoxEx()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dbgMEISAI = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.fraKeyInput.SuspendLayout()
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
        Me.FunctionKey.Location = New System.Drawing.Point(0, 606)
        Me.FunctionKey.TabIndex = 39
        '
        'fraKeyInput
        '
        Me.fraKeyInput.BackColor = System.Drawing.Color.Thistle
        Me.fraKeyInput.Controls.Add(Me.txtCOMMENT)
        Me.fraKeyInput.Controls.Add(Me.txtDATA)
        Me.fraKeyInput.Controls.Add(Me.txtDATAKEY)
        Me.fraKeyInput.Controls.Add(Me.txtCATEGORYID)
        Me.fraKeyInput.Controls.Add(Me.Label4)
        Me.fraKeyInput.Controls.Add(Me.Label5)
        Me.fraKeyInput.Controls.Add(Me.Label3)
        Me.fraKeyInput.Controls.Add(Me.Label2)
        Me.fraKeyInput.Controls.Add(Me.dbgMEISAI)
        Me.fraKeyInput.Location = New System.Drawing.Point(12, 60)
        Me.fraKeyInput.Name = "fraKeyInput"
        Me.fraKeyInput.Size = New System.Drawing.Size(995, 544)
        Me.fraKeyInput.TabIndex = 2
        '
        'txtCOMMENT
        '
        Me.txtCOMMENT.BackColor = System.Drawing.Color.White
        Me.txtCOMMENT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCOMMENT.DisplayName = "コメント"
        Me.txtCOMMENT.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtCOMMENT.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtCOMMENT.Location = New System.Drawing.Point(101, 511)
        Me.txtCOMMENT.MaxLength = 256
        Me.txtCOMMENT.Name = "txtCOMMENT"
        Me.txtCOMMENT.Size = New System.Drawing.Size(870, 17)
        Me.txtCOMMENT.TabIndex = 3
        '
        'txtDATA
        '
        Me.txtDATA.BackColor = System.Drawing.Color.White
        Me.txtDATA.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtDATA.DisplayName = "データ"
        Me.txtDATA.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtDATA.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtDATA.Location = New System.Drawing.Point(101, 482)
        Me.txtDATA.MaxLength = 100
        Me.txtDATA.Name = "txtDATA"
        Me.txtDATA.Size = New System.Drawing.Size(870, 17)
        Me.txtDATA.TabIndex = 2
        Me.txtDATA.Text = "1234567890123456789012345678901234567890123456789012345678901234"
        '
        'txtDATAKEY
        '
        Me.txtDATAKEY.BackColor = System.Drawing.Color.White
        Me.txtDATAKEY.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtDATAKEY.DisplayName = "データキー"
        Me.txtDATAKEY.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtDATAKEY.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtDATAKEY.Location = New System.Drawing.Point(101, 453)
        Me.txtDATAKEY.MaxLength = 50
        Me.txtDATAKEY.Name = "txtDATAKEY"
        Me.txtDATAKEY.Size = New System.Drawing.Size(870, 17)
        Me.txtDATAKEY.TabIndex = 1
        Me.txtDATAKEY.Text = "1234567890123456"
        '
        'txtCATEGORYID
        '
        Me.txtCATEGORYID.BackColor = System.Drawing.Color.White
        Me.txtCATEGORYID.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCATEGORYID.DisplayName = "カテゴリID"
        Me.txtCATEGORYID.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtCATEGORYID.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtCATEGORYID.Location = New System.Drawing.Point(101, 421)
        Me.txtCATEGORYID.MaxLength = 50
        Me.txtCATEGORYID.Name = "txtCATEGORYID"
        Me.txtCATEGORYID.Size = New System.Drawing.Size(870, 17)
        Me.txtCATEGORYID.TabIndex = 0
        Me.txtCATEGORYID.Text = "1234567890123456"
        Me.txtCATEGORYID.UseNullValidator = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 510)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 18)
        Me.Label4.TabIndex = 47
        Me.Label4.Text = "コメント"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 481)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 18)
        Me.Label5.TabIndex = 45
        Me.Label5.Text = "データ"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 452)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 18)
        Me.Label3.TabIndex = 43
        Me.Label3.Text = "データキー"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 420)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 18)
        Me.Label2.TabIndex = 42
        Me.Label2.Text = "カテゴリID"
        '
        'dbgMEISAI
        '
        Me.dbgMEISAI.AllowUpdate = False
        Me.dbgMEISAI.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.dbgMEISAI.CaptionHeight = 16
        Me.dbgMEISAI.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.MultipleLines
        Me.dbgMEISAI.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.dbgMEISAI.GroupByCaption = "列でグループ化するには、ここに列ヘッダをドラッグします。"
        Me.dbgMEISAI.Images.Add(CType(resources.GetObject("dbgMEISAI.Images"), System.Drawing.Image))
        Me.dbgMEISAI.Location = New System.Drawing.Point(15, 36)
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
        Me.dbgMEISAI.Size = New System.Drawing.Size(954, 365)
        Me.dbgMEISAI.TabIndex = 40
        Me.dbgMEISAI.TabStop = False
        Me.dbgMEISAI.UseCompatibleTextRendering = False
        Me.dbgMEISAI.PropBag = resources.GetString("dbgMEISAI.PropBag")
        '
        'frmMSE0020
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 670)
        Me.Controls.Add(Me.fraKeyInput)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMSE0020"
        Me.Text = ""
        Me.Controls.SetChildIndex(Me.fraKeyInput, 0)
        Me.Controls.SetChildIndex(Me.TitleBar, 0)
        Me.Controls.SetChildIndex(Me.FunctionKey, 0)
        Me.fraKeyInput.ResumeLayout(False)
        Me.fraKeyInput.PerformLayout()
        CType(Me.dbgMEISAI, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents fraKeyInput As System.Windows.Forms.Panel
    Protected WithEvents dbgMEISAI As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCATEGORYID As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents txtCOMMENT As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents txtDATA As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents txtDATAKEY As CommonUtility.WinFormControls.TextBoxEx

End Class
