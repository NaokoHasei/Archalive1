<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMENU
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMENU))
        Me.btnBUK0001 = New System.Windows.Forms.Button()
        Me.btnBUK0002 = New System.Windows.Forms.Button()
        Me.btnBUK0003 = New System.Windows.Forms.Button()
        Me.btnMENTMENU = New System.Windows.Forms.Button()
        Me.btnManual1 = New System.Windows.Forms.LinkLabel()
        Me.btnManual2 = New System.Windows.Forms.LinkLabel()
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
        'btnBUK0001
        '
        Me.btnBUK0001.BackColor = System.Drawing.Color.Transparent
        Me.btnBUK0001.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnBUK0001.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnBUK0001.Location = New System.Drawing.Point(275, 136)
        Me.btnBUK0001.Name = "btnBUK0001"
        Me.btnBUK0001.Size = New System.Drawing.Size(185, 66)
        Me.btnBUK0001.TabIndex = 3
        Me.btnBUK0001.Text = "物件登録"
        Me.btnBUK0001.UseVisualStyleBackColor = False
        '
        'btnBUK0002
        '
        Me.btnBUK0002.BackColor = System.Drawing.Color.Transparent
        Me.btnBUK0002.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnBUK0002.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnBUK0002.Location = New System.Drawing.Point(275, 259)
        Me.btnBUK0002.Name = "btnBUK0002"
        Me.btnBUK0002.Size = New System.Drawing.Size(185, 66)
        Me.btnBUK0002.TabIndex = 4
        Me.btnBUK0002.Text = "物件検索"
        Me.btnBUK0002.UseVisualStyleBackColor = False
        '
        'btnBUK0003
        '
        Me.btnBUK0003.BackColor = System.Drawing.Color.Transparent
        Me.btnBUK0003.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnBUK0003.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnBUK0003.Location = New System.Drawing.Point(275, 392)
        Me.btnBUK0003.Name = "btnBUK0003"
        Me.btnBUK0003.Size = New System.Drawing.Size(185, 66)
        Me.btnBUK0003.TabIndex = 5
        Me.btnBUK0003.Text = "実績一覧"
        Me.btnBUK0003.UseVisualStyleBackColor = False
        '
        'btnMENTMENU
        '
        Me.btnMENTMENU.BackColor = System.Drawing.Color.Transparent
        Me.btnMENTMENU.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnMENTMENU.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnMENTMENU.Location = New System.Drawing.Point(554, 136)
        Me.btnMENTMENU.Name = "btnMENTMENU"
        Me.btnMENTMENU.Size = New System.Drawing.Size(185, 66)
        Me.btnMENTMENU.TabIndex = 7
        Me.btnMENTMENU.Text = "メンテナンス"
        Me.btnMENTMENU.UseVisualStyleBackColor = False
        '
        'btnManual1
        '
        Me.btnManual1.ActiveLinkColor = System.Drawing.Color.White
        Me.btnManual1.AutoSize = True
        Me.btnManual1.BackColor = System.Drawing.Color.DarkSlateBlue
        Me.btnManual1.Font = New System.Drawing.Font("メイリオ", 9.0!)
        Me.btnManual1.LinkColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(179, Byte), Integer))
        Me.btnManual1.Location = New System.Drawing.Point(730, 19)
        Me.btnManual1.Name = "btnManual1"
        Me.btnManual1.Size = New System.Drawing.Size(116, 18)
        Me.btnManual1.TabIndex = 96
        Me.btnManual1.TabStop = True
        Me.btnManual1.Text = "機能一覧・画面遷移"
        '
        'btnManual2
        '
        Me.btnManual2.ActiveLinkColor = System.Drawing.Color.White
        Me.btnManual2.AutoSize = True
        Me.btnManual2.BackColor = System.Drawing.Color.DarkSlateBlue
        Me.btnManual2.Font = New System.Drawing.Font("メイリオ", 9.0!)
        Me.btnManual2.LinkColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(179, Byte), Integer))
        Me.btnManual2.Location = New System.Drawing.Point(852, 19)
        Me.btnManual2.Name = "btnManual2"
        Me.btnManual2.Size = New System.Drawing.Size(92, 18)
        Me.btnManual2.TabIndex = 97
        Me.btnManual2.TabStop = True
        Me.btnManual2.Text = "機能共通の設定"
        '
        'frmMENU
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 670)
        Me.Controls.Add(Me.btnManual2)
        Me.Controls.Add(Me.btnManual1)
        Me.Controls.Add(Me.btnMENTMENU)
        Me.Controls.Add(Me.btnBUK0003)
        Me.Controls.Add(Me.btnBUK0002)
        Me.Controls.Add(Me.btnBUK0001)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMENU"
        Me.Text = ""
        Me.Controls.SetChildIndex(Me.TitleBar, 0)
        Me.Controls.SetChildIndex(Me.FunctionKey, 0)
        Me.Controls.SetChildIndex(Me.btnBUK0001, 0)
        Me.Controls.SetChildIndex(Me.btnBUK0002, 0)
        Me.Controls.SetChildIndex(Me.btnBUK0003, 0)
        Me.Controls.SetChildIndex(Me.btnMENTMENU, 0)
        Me.Controls.SetChildIndex(Me.btnManual1, 0)
        Me.Controls.SetChildIndex(Me.btnManual2, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnBUK0001 As System.Windows.Forms.Button
    Friend WithEvents btnBUK0002 As Button
    Friend WithEvents btnBUK0003 As Button
    Friend WithEvents btnMENTMENU As Button
    Friend WithEvents btnManual1 As LinkLabel
    Friend WithEvents btnManual2 As LinkLabel
End Class
