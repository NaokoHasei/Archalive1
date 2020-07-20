<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMENT0001
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMENT0001))
        Me.txtBUKACODE = New CommonUtility.WinFormControls.TypComboBox()
        Me.txtBUKANAME = New CommonUtility.WinFormControls.TextBoxEx()
        Me.dbgMeisai = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        CType(Me.dbgMeisai, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TitleBar
        '
        Me.TitleBar.AppearanceType = CommonUtility.WinFormControls.AppearanceType.Normal
        Me.TitleBar.EditMode = CommonUtility.WinFormControls.EditMode.None
        Me.TitleBar.MaximumSize = New System.Drawing.Size(2000, 42)
        Me.TitleBar.MinimumSize = New System.Drawing.Size(100, 42)
        Me.TitleBar.Padding = New System.Windows.Forms.Padding(32, 17, 48, 17)
        Me.TitleBar.Size = New System.Drawing.Size(1018, 42)
        Me.TitleBar.Title = ""
        '
        'FunctionKey
        '
        Me.FunctionKey.Location = New System.Drawing.Point(0, 641)
        Me.FunctionKey.Size = New System.Drawing.Size(1018, 68)
        '
        'txtBUKACODE
        '
        Me.txtBUKACODE.AutoValidate = System.Windows.Forms.AutoValidate.Disable
        Me.txtBUKACODE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBUKACODE.DisplayName = "部課コード"
        Me.txtBUKACODE.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtBUKACODE.Location = New System.Drawing.Point(358, 105)
        Me.txtBUKACODE.MaxLength = 4
        Me.txtBUKACODE.Name = "txtBUKACODE"
        Me.txtBUKACODE.Size = New System.Drawing.Size(58, 18)
        Me.txtBUKACODE.TabIndex = 2
        Me.txtBUKACODE.UseUpdateLinkedTextByCodeChange = True
        Me.txtBUKACODE.UseZeroPadding = True
        Me.txtBUKACODE.ZeroPaddingLength = 4
        '
        'txtBUKANAME
        '
        Me.txtBUKANAME.BackColor = System.Drawing.Color.White
        Me.txtBUKANAME.DisplayName = "部課名称"
        Me.txtBUKANAME.Font = New System.Drawing.Font("メイリオ", 9.0!)
        Me.txtBUKANAME.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtBUKANAME.Location = New System.Drawing.Point(422, 101)
        Me.txtBUKANAME.MaxLength = 30
        Me.txtBUKANAME.Name = "txtBUKANAME"
        Me.txtBUKANAME.Size = New System.Drawing.Size(246, 25)
        Me.txtBUKANAME.TabIndex = 3
        '
        'dbgMeisai
        '
        Me.dbgMeisai.AllowUpdate = False
        Me.dbgMeisai.BackColor = System.Drawing.Color.Thistle
        Me.dbgMeisai.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.dbgMeisai.CaptionHeight = 16
        Me.dbgMeisai.GroupByCaption = "列でグループ化するには、ここに列ヘッダをドラッグします。"
        Me.dbgMeisai.Images.Add(CType(resources.GetObject("dbgMeisai.Images"), System.Drawing.Image))
        Me.dbgMeisai.Location = New System.Drawing.Point(346, 134)
        Me.dbgMeisai.Name = "dbgMeisai"
        Me.dbgMeisai.PreviewInfo.Caption = "印刷プレビューウィンドウ"
        Me.dbgMeisai.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.dbgMeisai.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.dbgMeisai.PreviewInfo.ZoomFactor = 75.0R
        Me.dbgMeisai.PrintInfo.PageSettings = CType(resources.GetObject("dbgMeisai.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.dbgMeisai.RowHeight = 14
        Me.dbgMeisai.Size = New System.Drawing.Size(334, 501)
        Me.dbgMeisai.TabIndex = 4
        Me.dbgMeisai.Text = "C1TrueDBGrid1"
        Me.dbgMeisai.UseCompatibleTextRendering = False
        Me.dbgMeisai.PropBag = resources.GetString("dbgMeisai.PropBag")
        '
        'frmMENT0001
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 709)
        Me.Controls.Add(Me.dbgMeisai)
        Me.Controls.Add(Me.txtBUKACODE)
        Me.Controls.Add(Me.txtBUKANAME)
        Me.Font = New System.Drawing.Font("メイリオ", 9.0!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMENT0001"
        Me.Text = ""
        Me.Controls.SetChildIndex(Me.txtBUKANAME, 0)
        Me.Controls.SetChildIndex(Me.txtBUKACODE, 0)
        Me.Controls.SetChildIndex(Me.TitleBar, 0)
        Me.Controls.SetChildIndex(Me.FunctionKey, 0)
        Me.Controls.SetChildIndex(Me.dbgMeisai, 0)
        CType(Me.dbgMeisai, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtBUKACODE As CommonUtility.WinFormControls.TypComboBox
    Friend WithEvents txtBUKANAME As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents dbgMeisai As C1.Win.C1TrueDBGrid.C1TrueDBGrid
End Class
