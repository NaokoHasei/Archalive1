<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmBUK0003
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBUK0003))
        Me.Label8 = New System.Windows.Forms.Label()
        Me.fraKeyInput = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtKankouDateED = New CommonUtility.WinFormControls.DateTextBoxEx()
        Me.txtKankouDateST = New CommonUtility.WinFormControls.DateTextBoxEx()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtChakkouDateED = New CommonUtility.WinFormControls.DateTextBoxEx()
        Me.txtChakkouDateST = New CommonUtility.WinFormControls.DateTextBoxEx()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtBukkenName = New CommonUtility.WinFormControls.TextBoxEx()
        Me.Label18 = New System.Windows.Forms.Label()
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
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.DarkSlateBlue
        Me.Label8.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.Window
        Me.Label8.Location = New System.Drawing.Point(0, 54)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(1018, 18)
        Me.Label8.TabIndex = 41
        Me.Label8.Text = "抽出条件"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'fraKeyInput
        '
        Me.fraKeyInput.BackColor = System.Drawing.Color.Thistle
        Me.fraKeyInput.Controls.Add(Me.Label2)
        Me.fraKeyInput.Controls.Add(Me.txtKankouDateED)
        Me.fraKeyInput.Controls.Add(Me.txtKankouDateST)
        Me.fraKeyInput.Controls.Add(Me.Label4)
        Me.fraKeyInput.Controls.Add(Me.Label3)
        Me.fraKeyInput.Controls.Add(Me.txtChakkouDateED)
        Me.fraKeyInput.Controls.Add(Me.txtChakkouDateST)
        Me.fraKeyInput.Controls.Add(Me.Label1)
        Me.fraKeyInput.Controls.Add(Me.txtBukkenName)
        Me.fraKeyInput.Controls.Add(Me.Label18)
        Me.fraKeyInput.Location = New System.Drawing.Point(0, 54)
        Me.fraKeyInput.Name = "fraKeyInput"
        Me.fraKeyInput.Size = New System.Drawing.Size(1018, 85)
        Me.fraKeyInput.TabIndex = 42
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.Label2.Location = New System.Drawing.Point(596, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(19, 17)
        Me.Label2.TabIndex = 72
        Me.Label2.Text = "～"
        '
        'txtKankouDateED
        '
        Me.txtKankouDateED.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtKankouDateED.DisplayName = "完工日"
        Me.txtKankouDateED.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtKankouDateED.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtKankouDateED.LinkedDateTextBox = Nothing
        Me.txtKankouDateED.Location = New System.Drawing.Point(621, 55)
        Me.txtKankouDateED.Mask = "0000/00/00"
        Me.txtKankouDateED.Name = "txtKankouDateED"
        Me.txtKankouDateED.Size = New System.Drawing.Size(70, 17)
        Me.txtKankouDateED.TabIndex = 5
        Me.txtKankouDateED.Text = "20150601"
        Me.txtKankouDateED.ValidatingType = GetType(Date)
        '
        'txtKankouDateST
        '
        Me.txtKankouDateST.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtKankouDateST.DisplayName = "完工日"
        Me.txtKankouDateST.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtKankouDateST.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtKankouDateST.LinkedDateTextBox = Nothing
        Me.txtKankouDateST.Location = New System.Drawing.Point(520, 55)
        Me.txtKankouDateST.Mask = "0000/00/00"
        Me.txtKankouDateST.Name = "txtKankouDateST"
        Me.txtKankouDateST.Size = New System.Drawing.Size(70, 17)
        Me.txtKankouDateST.TabIndex = 4
        Me.txtKankouDateST.Text = "20150601"
        Me.txtKankouDateST.ValidatingType = GetType(Date)
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.Label4.Location = New System.Drawing.Point(451, 56)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 17)
        Me.Label4.TabIndex = 70
        Me.Label4.Text = "完工日"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.Label3.Location = New System.Drawing.Point(596, 33)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(19, 17)
        Me.Label3.TabIndex = 68
        Me.Label3.Text = "～"
        '
        'txtChakkouDateED
        '
        Me.txtChakkouDateED.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtChakkouDateED.DisplayName = "着工日"
        Me.txtChakkouDateED.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtChakkouDateED.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtChakkouDateED.LinkedDateTextBox = Nothing
        Me.txtChakkouDateED.Location = New System.Drawing.Point(621, 32)
        Me.txtChakkouDateED.Mask = "0000/00/00"
        Me.txtChakkouDateED.Name = "txtChakkouDateED"
        Me.txtChakkouDateED.Size = New System.Drawing.Size(70, 17)
        Me.txtChakkouDateED.TabIndex = 3
        Me.txtChakkouDateED.Text = "20150601"
        Me.txtChakkouDateED.ValidatingType = GetType(Date)
        '
        'txtChakkouDateST
        '
        Me.txtChakkouDateST.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtChakkouDateST.DisplayName = "着工日"
        Me.txtChakkouDateST.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtChakkouDateST.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtChakkouDateST.LinkedDateTextBox = Nothing
        Me.txtChakkouDateST.Location = New System.Drawing.Point(520, 32)
        Me.txtChakkouDateST.Mask = "0000/00/00"
        Me.txtChakkouDateST.Name = "txtChakkouDateST"
        Me.txtChakkouDateST.Size = New System.Drawing.Size(70, 17)
        Me.txtChakkouDateST.TabIndex = 2
        Me.txtChakkouDateST.Text = "20150601"
        Me.txtChakkouDateST.ValidatingType = GetType(Date)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.Label1.Location = New System.Drawing.Point(451, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 17)
        Me.Label1.TabIndex = 66
        Me.Label1.Text = "着工日"
        '
        'txtBukkenName
        '
        Me.txtBukkenName.BackColor = System.Drawing.Color.White
        Me.txtBukkenName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtBukkenName.DisplayName = "物件名"
        Me.txtBukkenName.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtBukkenName.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtBukkenName.Location = New System.Drawing.Point(86, 32)
        Me.txtBukkenName.MaxLength = 100
        Me.txtBukkenName.Name = "txtBukkenName"
        Me.txtBukkenName.Size = New System.Drawing.Size(334, 17)
        Me.txtBukkenName.TabIndex = 1
        Me.txtBukkenName.Text = "１２３４５６７８９０１２３４５６７８９０１２３４５６７８９０"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label18.Location = New System.Drawing.Point(17, 32)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(41, 17)
        Me.Label18.TabIndex = 51
        Me.Label18.Text = "物件名"
        '
        'dbgMEISAI
        '
        Me.dbgMEISAI.AllowUpdate = False
        Me.dbgMEISAI.BackColor = System.Drawing.Color.Thistle
        Me.dbgMEISAI.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.dbgMEISAI.CaptionHeight = 16
        Me.dbgMEISAI.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.MultipleLines
        Me.dbgMEISAI.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.dbgMEISAI.GroupByCaption = "列でグループ化するには、ここに列ヘッダをドラッグします。"
        Me.dbgMEISAI.Images.Add(CType(resources.GetObject("dbgMEISAI.Images"), System.Drawing.Image))
        Me.dbgMEISAI.Location = New System.Drawing.Point(0, 145)
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
        Me.dbgMEISAI.Size = New System.Drawing.Size(1018, 455)
        Me.dbgMEISAI.TabIndex = 43
        Me.dbgMEISAI.TabStop = False
        Me.dbgMEISAI.UseCompatibleTextRendering = False
        Me.dbgMEISAI.PropBag = resources.GetString("dbgMEISAI.PropBag")
        '
        'frmBUK0003
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 670)
        Me.Controls.Add(Me.dbgMEISAI)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.fraKeyInput)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmBUK0003"
        Me.Text = ""
        Me.Controls.SetChildIndex(Me.fraKeyInput, 0)
        Me.Controls.SetChildIndex(Me.TitleBar, 0)
        Me.Controls.SetChildIndex(Me.FunctionKey, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.dbgMEISAI, 0)
        Me.fraKeyInput.ResumeLayout(False)
        Me.fraKeyInput.PerformLayout()
        CType(Me.dbgMEISAI, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label8 As Label
    Friend WithEvents fraKeyInput As Panel
    Friend WithEvents txtBukkenName As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents Label18 As Label
    Protected WithEvents dbgMEISAI As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents Label2 As Label
    Friend WithEvents txtKankouDateED As CommonUtility.WinFormControls.DateTextBoxEx
    Friend WithEvents txtKankouDateST As CommonUtility.WinFormControls.DateTextBoxEx
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtChakkouDateED As CommonUtility.WinFormControls.DateTextBoxEx
    Friend WithEvents txtChakkouDateST As CommonUtility.WinFormControls.DateTextBoxEx
    Friend WithEvents Label1 As Label
End Class
