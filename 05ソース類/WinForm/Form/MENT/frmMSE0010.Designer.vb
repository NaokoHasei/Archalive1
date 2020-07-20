<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMSE0010
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMSE0010))
        Me.GrpHeader = New System.Windows.Forms.GroupBox()
        Me.txtPCNAME = New CommonUtility.WinFormControls.TextBoxEx()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GrpDetail = New System.Windows.Forms.GroupBox()
        Me.dbgPc = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.dbgSystem = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.GrpHeader.SuspendLayout()
        Me.GrpDetail.SuspendLayout()
        CType(Me.dbgPc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dbgSystem, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'GrpHeader
        '
        Me.GrpHeader.Controls.Add(Me.txtPCNAME)
        Me.GrpHeader.Controls.Add(Me.Label1)
        Me.GrpHeader.Location = New System.Drawing.Point(12, 66)
        Me.GrpHeader.Name = "GrpHeader"
        Me.GrpHeader.Size = New System.Drawing.Size(994, 57)
        Me.GrpHeader.TabIndex = 12
        Me.GrpHeader.TabStop = False
        '
        'txtPCNAME
        '
        Me.txtPCNAME.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtPCNAME.Location = New System.Drawing.Point(67, 23)
        Me.txtPCNAME.MaxLength = 20
        Me.txtPCNAME.Name = "txtPCNAME"
        Me.txtPCNAME.Size = New System.Drawing.Size(166, 25)
        Me.txtPCNAME.TabIndex = 1
        Me.txtPCNAME.UseNullValidator = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "端末名"
        '
        'GrpDetail
        '
        Me.GrpDetail.Controls.Add(Me.dbgPc)
        Me.GrpDetail.Controls.Add(Me.dbgSystem)
        Me.GrpDetail.Location = New System.Drawing.Point(12, 129)
        Me.GrpDetail.Name = "GrpDetail"
        Me.GrpDetail.Size = New System.Drawing.Size(994, 471)
        Me.GrpDetail.TabIndex = 13
        Me.GrpDetail.TabStop = False
        '
        'dbgPc
        '
        Me.dbgPc.BackColor = System.Drawing.Color.Gainsboro
        Me.dbgPc.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.dbgPc.CaptionHeight = 16
        Me.dbgPc.GroupByCaption = "列でグループ化するには、ここに列ヘッダをドラッグします。"
        Me.dbgPc.Images.Add(CType(resources.GetObject("dbgPc.Images"), System.Drawing.Image))
        Me.dbgPc.Location = New System.Drawing.Point(10, 29)
        Me.dbgPc.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow
        Me.dbgPc.Name = "dbgPc"
        Me.dbgPc.PreviewInfo.Caption = "印刷プレビューウィンドウ"
        Me.dbgPc.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.dbgPc.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.dbgPc.PreviewInfo.ZoomFactor = 75.0R
        Me.dbgPc.PrintInfo.PageSettings = CType(resources.GetObject("dbgPc.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.dbgPc.RowHeight = 14
        Me.dbgPc.Size = New System.Drawing.Size(273, 422)
        Me.dbgPc.TabIndex = 5
        Me.dbgPc.Text = "C1TrueDBGrid1"
        Me.dbgPc.UseCompatibleTextRendering = False
        Me.dbgPc.PropBag = resources.GetString("dbgPc.PropBag")
        '
        'dbgSystem
        '
        Me.dbgSystem.BackColor = System.Drawing.Color.Gainsboro
        Me.dbgSystem.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.dbgSystem.CaptionHeight = 16
        Me.dbgSystem.GroupByCaption = "列でグループ化するには、ここに列ヘッダをドラッグします。"
        Me.dbgSystem.Images.Add(CType(resources.GetObject("dbgSystem.Images"), System.Drawing.Image))
        Me.dbgSystem.Location = New System.Drawing.Point(289, 29)
        Me.dbgSystem.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow
        Me.dbgSystem.Name = "dbgSystem"
        Me.dbgSystem.PreviewInfo.Caption = "印刷プレビューウィンドウ"
        Me.dbgSystem.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.dbgSystem.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.dbgSystem.PreviewInfo.ZoomFactor = 75.0R
        Me.dbgSystem.PrintInfo.PageSettings = CType(resources.GetObject("dbgSystem.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.dbgSystem.RowHeight = 14
        Me.dbgSystem.Size = New System.Drawing.Size(699, 439)
        Me.dbgSystem.TabIndex = 6
        Me.dbgSystem.Text = "C1TrueDBGrid1"
        Me.dbgSystem.UseCompatibleTextRendering = False
        Me.dbgSystem.PropBag = resources.GetString("dbgSystem.PropBag")
        '
        'frmMSE0010
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 670)
        Me.Controls.Add(Me.GrpHeader)
        Me.Controls.Add(Me.GrpDetail)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMSE0010"
        Me.Text = ""
        Me.Controls.SetChildIndex(Me.TitleBar, 0)
        Me.Controls.SetChildIndex(Me.FunctionKey, 0)
        Me.Controls.SetChildIndex(Me.GrpDetail, 0)
        Me.Controls.SetChildIndex(Me.GrpHeader, 0)
        Me.GrpHeader.ResumeLayout(False)
        Me.GrpHeader.PerformLayout()
        Me.GrpDetail.ResumeLayout(False)
        CType(Me.dbgPc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dbgSystem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GrpHeader As System.Windows.Forms.GroupBox
    Friend WithEvents txtPCNAME As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GrpDetail As System.Windows.Forms.GroupBox
    Protected WithEvents dbgPc As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Protected WithEvents dbgSystem As C1.Win.C1TrueDBGrid.C1TrueDBGrid

End Class
