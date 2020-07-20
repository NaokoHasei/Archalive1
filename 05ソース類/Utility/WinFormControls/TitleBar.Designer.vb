<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TitleBar
    Inherits System.Windows.Forms.UserControl

    'UserControl はコンポーネント一覧をクリーンアップするために dispose をオーバーライドします。
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
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblMODE = New System.Windows.Forms.Label()
        Me.btnManual = New System.Windows.Forms.LinkLabel()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitle.BackColor = System.Drawing.Color.DarkSlateBlue
        Me.lblTitle.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblTitle.Font = New System.Drawing.Font("メイリオ", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(0, 1)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTitle.Size = New System.Drawing.Size(1016, 37)
        Me.lblTitle.TabIndex = 18
        Me.lblTitle.Text = "タイトル"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblMODE
        '
        Me.lblMODE.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblMODE.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblMODE.ForeColor = System.Drawing.Color.Red
        Me.lblMODE.Location = New System.Drawing.Point(26, 6)
        Me.lblMODE.Name = "lblMODE"
        Me.lblMODE.Size = New System.Drawing.Size(233, 28)
        Me.lblMODE.TabIndex = 74
        Me.lblMODE.Text = "変更不可（次請求あり）"
        Me.lblMODE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblMODE.Visible = False
        '
        'btnManual
        '
        Me.btnManual.ActiveLinkColor = System.Drawing.Color.White
        Me.btnManual.AutoSize = True
        Me.btnManual.BackColor = System.Drawing.Color.DarkSlateBlue
        Me.btnManual.Font = New System.Drawing.Font("メイリオ", 9.0!)
        Me.btnManual.LinkColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(179, Byte), Integer))
        Me.btnManual.Location = New System.Drawing.Point(951, 19)
        Me.btnManual.Name = "btnManual"
        Me.btnManual.Size = New System.Drawing.Size(56, 18)
        Me.btnManual.TabIndex = 95
        Me.btnManual.TabStop = True
        Me.btnManual.Text = "操作説明"
        '
        'TitleBar
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.btnManual)
        Me.Controls.Add(Me.lblMODE)
        Me.Controls.Add(Me.lblTitle)
        Me.Font = New System.Drawing.Font("ＭＳ 明朝", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Margin = New System.Windows.Forms.Padding(0)
        Me.MaximumSize = New System.Drawing.Size(2000, 40)
        Me.MinimumSize = New System.Drawing.Size(100, 40)
        Me.Name = "TitleBar"
        Me.Padding = New System.Windows.Forms.Padding(32, 16, 48, 16)
        Me.Size = New System.Drawing.Size(1016, 40)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents lblMODE As System.Windows.Forms.Label
    Friend WithEvents btnManual As LinkLabel
End Class
