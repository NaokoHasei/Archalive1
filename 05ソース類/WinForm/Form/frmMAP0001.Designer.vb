<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMAP0001
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMAP0001))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.chkLatLng = New System.Windows.Forms.CheckBox()
        Me.chkAddress = New System.Windows.Forms.CheckBox()
        Me.chkPostNo = New System.Windows.Forms.CheckBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnSANSYO = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'TitleBar
        '
        Me.TitleBar.AppearanceType = CommonUtility.WinFormControls.AppearanceType.Normal
        Me.TitleBar.EditMode = CommonUtility.WinFormControls.EditMode.None
        Me.TitleBar.Title = ""
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.WebBrowser1)
        Me.Panel1.Location = New System.Drawing.Point(12, 81)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(994, 531)
        Me.Panel1.TabIndex = 81
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WebBrowser1.Location = New System.Drawing.Point(0, 0)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.ScrollBarsEnabled = False
        Me.WebBrowser1.Size = New System.Drawing.Size(992, 529)
        Me.WebBrowser1.TabIndex = 3
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.chkLatLng)
        Me.Panel2.Controls.Add(Me.chkAddress)
        Me.Panel2.Controls.Add(Me.chkPostNo)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Location = New System.Drawing.Point(13, 50)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(351, 25)
        Me.Panel2.TabIndex = 86
        '
        'chkLatLng
        '
        Me.chkLatLng.AutoSize = True
        Me.chkLatLng.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.chkLatLng.Location = New System.Drawing.Point(247, 1)
        Me.chkLatLng.Name = "chkLatLng"
        Me.chkLatLng.Size = New System.Drawing.Size(82, 21)
        Me.chkLatLng.TabIndex = 89
        Me.chkLatLng.Text = "経度・緯度"
        Me.chkLatLng.UseVisualStyleBackColor = True
        '
        'chkAddress
        '
        Me.chkAddress.AutoSize = True
        Me.chkAddress.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.chkAddress.Location = New System.Drawing.Point(192, 1)
        Me.chkAddress.Name = "chkAddress"
        Me.chkAddress.Size = New System.Drawing.Size(49, 21)
        Me.chkAddress.TabIndex = 88
        Me.chkAddress.Text = "住所"
        Me.chkAddress.UseVisualStyleBackColor = True
        '
        'chkPostNo
        '
        Me.chkPostNo.AutoSize = True
        Me.chkPostNo.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.chkPostNo.Location = New System.Drawing.Point(115, 1)
        Me.chkPostNo.Name = "chkPostNo"
        Me.chkPostNo.Size = New System.Drawing.Size(71, 21)
        Me.chkPostNo.TabIndex = 87
        Me.chkPostNo.Text = "郵便番号"
        Me.chkPostNo.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.Location = New System.Drawing.Point(0, 2)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(96, 17)
        Me.Label9.TabIndex = 86
        Me.Label9.Text = "工事場所の反映先"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.btnSANSYO)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Location = New System.Drawing.Point(370, 49)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(351, 26)
        Me.Panel3.TabIndex = 87
        '
        'btnSANSYO
        '
        Me.btnSANSYO.BackColor = System.Drawing.Color.Transparent
        Me.btnSANSYO.FlatAppearance.BorderSize = 0
        Me.btnSANSYO.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.btnSANSYO.ForeColor = System.Drawing.Color.Black
        Me.btnSANSYO.Location = New System.Drawing.Point(267, -1)
        Me.btnSANSYO.Name = "btnSANSYO"
        Me.btnSANSYO.Size = New System.Drawing.Size(55, 22)
        Me.btnSANSYO.TabIndex = 87
        Me.btnSANSYO.TabStop = False
        Me.btnSANSYO.Text = "参照"
        Me.btnSANSYO.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(0, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(261, 17)
        Me.Label1.TabIndex = 86
        Me.Label1.Text = "経度・緯度が登録されていない物件が存在します。"
        '
        'frmMAP0001
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 692)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMAP0001"
        Me.Text = ""
        Me.Controls.SetChildIndex(Me.TitleBar, 0)
        Me.Controls.SetChildIndex(Me.FunctionKey, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.Panel2, 0)
        Me.Controls.SetChildIndex(Me.Panel3, 0)
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As Panel
    Friend WithEvents WebBrowser1 As WebBrowser
    Friend WithEvents Panel2 As Panel
    Friend WithEvents chkLatLng As CheckBox
    Friend WithEvents chkAddress As CheckBox
    Friend WithEvents chkPostNo As CheckBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents btnSANSYO As Button
End Class
