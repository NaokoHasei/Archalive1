<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMSE0090
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
        Dim label38 As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMSE0090))
        Me.txtStatus = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtURL = New CommonUtility.WinFormControls.TextBoxEx()
        Me.RdDownLoad = New System.Windows.Forms.RadioButton()
        Me.RdManual = New System.Windows.Forms.RadioButton()
        Me.ProgressCreate = New System.Windows.Forms.ProgressBar()
        Me.txtPath = New CommonUtility.WinFormControls.TextBoxEx()
        label38 = New System.Windows.Forms.Label()
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
        'label38
        '
        label38.AutoSize = True
        label38.BackColor = System.Drawing.Color.Transparent
        label38.Cursor = System.Windows.Forms.Cursors.Default
        label38.Font = New System.Drawing.Font("メイリオ", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        label38.ForeColor = System.Drawing.SystemColors.ControlText
        label38.Location = New System.Drawing.Point(137, 149)
        label38.Name = "label38"
        label38.RightToLeft = System.Windows.Forms.RightToLeft.No
        label38.Size = New System.Drawing.Size(231, 36)
        label38.TabIndex = 12
        label38.Text = "郵便番号データ場所"
        '
        'txtStatus
        '
        Me.txtStatus.AutoSize = True
        Me.txtStatus.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtStatus.Location = New System.Drawing.Point(196, 451)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.Size = New System.Drawing.Size(266, 31)
        Me.txtStatus.TabIndex = 18
        Me.txtStatus.Text = "郵便番号データ作成開始..."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(141, 322)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(759, 62)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "上記サイトよりファイルをダウンロードしてください。" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "ken_all.zip がダウンロードされますので上記固定場所にコピーしてください。"
        '
        'txtURL
        '
        Me.txtURL.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.txtURL.DisplayName = "メモ"
        Me.txtURL.Enabled = False
        Me.txtURL.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtURL.Location = New System.Drawing.Point(141, 265)
        Me.txtURL.Multiline = True
        Me.txtURL.Name = "txtURL"
        Me.txtURL.ReadOnly = True
        Me.txtURL.Size = New System.Drawing.Size(782, 51)
        Me.txtURL.TabIndex = 13
        Me.txtURL.TabStop = False
        Me.txtURL.Text = "http://www"
        '
        'RdDownLoad
        '
        Me.RdDownLoad.AutoSize = True
        Me.RdDownLoad.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.RdDownLoad.Location = New System.Drawing.Point(95, 394)
        Me.RdDownLoad.Name = "RdDownLoad"
        Me.RdDownLoad.Size = New System.Drawing.Size(144, 32)
        Me.RdDownLoad.TabIndex = 16
        Me.RdDownLoad.Text = "ダウンロード"
        Me.RdDownLoad.UseVisualStyleBackColor = True
        '
        'RdManual
        '
        Me.RdManual.AutoSize = True
        Me.RdManual.Checked = True
        Me.RdManual.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.RdManual.Location = New System.Drawing.Point(95, 236)
        Me.RdManual.Name = "RdManual"
        Me.RdManual.Size = New System.Drawing.Size(68, 32)
        Me.RdManual.TabIndex = 15
        Me.RdManual.TabStop = True
        Me.RdManual.Text = "手動"
        Me.RdManual.UseVisualStyleBackColor = True
        '
        'ProgressCreate
        '
        Me.ProgressCreate.BackColor = System.Drawing.SystemColors.Control
        Me.ProgressCreate.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.ProgressCreate.Location = New System.Drawing.Point(186, 487)
        Me.ProgressCreate.Name = "ProgressCreate"
        Me.ProgressCreate.Size = New System.Drawing.Size(639, 34)
        Me.ProgressCreate.Step = 1
        Me.ProgressCreate.TabIndex = 14
        '
        'txtPath
        '
        Me.txtPath.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.txtPath.DisplayName = "メモ"
        Me.txtPath.Enabled = False
        Me.txtPath.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtPath.Location = New System.Drawing.Point(407, 149)
        Me.txtPath.Name = "txtPath"
        Me.txtPath.ReadOnly = True
        Me.txtPath.Size = New System.Drawing.Size(382, 36)
        Me.txtPath.TabIndex = 11
        Me.txtPath.Text = "C:\typ"
        '
        'frmMSE0090
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 670)
        Me.Controls.Add(Me.txtStatus)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtURL)
        Me.Controls.Add(Me.RdDownLoad)
        Me.Controls.Add(Me.RdManual)
        Me.Controls.Add(Me.ProgressCreate)
        Me.Controls.Add(Me.txtPath)
        Me.Controls.Add(label38)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMSE0090"
        Me.Text = ""
        Me.Controls.SetChildIndex(Me.TitleBar, 0)
        Me.Controls.SetChildIndex(Me.FunctionKey, 0)
        Me.Controls.SetChildIndex(label38, 0)
        Me.Controls.SetChildIndex(Me.txtPath, 0)
        Me.Controls.SetChildIndex(Me.ProgressCreate, 0)
        Me.Controls.SetChildIndex(Me.RdManual, 0)
        Me.Controls.SetChildIndex(Me.RdDownLoad, 0)
        Me.Controls.SetChildIndex(Me.txtURL, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.txtStatus, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtStatus As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtURL As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents RdDownLoad As System.Windows.Forms.RadioButton
    Friend WithEvents RdManual As System.Windows.Forms.RadioButton
    Friend WithEvents ProgressCreate As System.Windows.Forms.ProgressBar
    Friend WithEvents txtPath As CommonUtility.WinFormControls.TextBoxEx
End Class
