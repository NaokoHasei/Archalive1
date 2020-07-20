<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
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
        Me.txtPostCode = New CommonUtility.WinFormControls.TextBoxEx()
        Me.txtName = New CommonUtility.WinFormControls.TextBoxEx()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnHanei = New System.Windows.Forms.Button()
        Me.txtAddress1 = New CommonUtility.WinFormControls.TextBoxEx()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtLat = New CommonUtility.WinFormControls.TextBoxEx()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtLng = New CommonUtility.WinFormControls.TextBoxEx()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnChangeIoction = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.txtAddress3 = New CommonUtility.WinFormControls.TextBoxEx()
        Me.txtAddress2 = New CommonUtility.WinFormControls.TextBoxEx()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TitleBar
        '
        Me.TitleBar.AppearanceType = CommonUtility.WinFormControls.AppearanceType.Normal
        Me.TitleBar.EditMode = CommonUtility.WinFormControls.EditMode.None
        '
        'txtPostCode
        '
        Me.txtPostCode.BackColor = System.Drawing.Color.White
        Me.txtPostCode.DisplayName = "担当者名"
        Me.txtPostCode.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtPostCode.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtPostCode.Location = New System.Drawing.Point(106, 531)
        Me.txtPostCode.MaxLength = 100
        Me.txtPostCode.Name = "txtPostCode"
        Me.txtPostCode.Size = New System.Drawing.Size(134, 25)
        Me.txtPostCode.TabIndex = 3
        Me.txtPostCode.Text = ""
        '
        'txtName
        '
        Me.txtName.BackColor = System.Drawing.Color.White
        Me.txtName.DisplayName = "担当者名"
        Me.txtName.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtName.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtName.Location = New System.Drawing.Point(106, 500)
        Me.txtName.MaxLength = 100
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(478, 25)
        Me.txtName.TabIndex = 4
        Me.txtName.Text = ""
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(32, 504)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 17)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "名称"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(32, 535)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 17)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "郵便番号"
        '
        'btnHanei
        '
        Me.btnHanei.BackColor = System.Drawing.Color.Transparent
        Me.btnHanei.FlatAppearance.BorderSize = 0
        Me.btnHanei.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.btnHanei.ForeColor = System.Drawing.Color.Black
        Me.btnHanei.Location = New System.Drawing.Point(657, 532)
        Me.btnHanei.Name = "btnHanei"
        Me.btnHanei.Size = New System.Drawing.Size(52, 22)
        Me.btnHanei.TabIndex = 79
        Me.btnHanei.TabStop = False
        Me.btnHanei.Text = "反映"
        Me.btnHanei.UseVisualStyleBackColor = False
        '
        'txtAddress1
        '
        Me.txtAddress1.BackColor = System.Drawing.Color.White
        Me.txtAddress1.DisplayName = "担当者名"
        Me.txtAddress1.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtAddress1.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtAddress1.Location = New System.Drawing.Point(106, 562)
        Me.txtAddress1.MaxLength = 100
        Me.txtAddress1.Name = "txtAddress1"
        Me.txtAddress1.Size = New System.Drawing.Size(94, 25)
        Me.txtAddress1.TabIndex = 3
        Me.txtAddress1.Text = ""
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(32, 566)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(30, 17)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "住所"
        '
        'txtLat
        '
        Me.txtLat.BackColor = System.Drawing.Color.White
        Me.txtLat.DisplayName = "担当者名"
        Me.txtLat.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtLat.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtLat.Location = New System.Drawing.Point(106, 597)
        Me.txtLat.MaxLength = 100
        Me.txtLat.Name = "txtLat"
        Me.txtLat.Size = New System.Drawing.Size(214, 25)
        Me.txtLat.TabIndex = 3
        Me.txtLat.Text = ""
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(32, 601)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 17)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "経度"
        '
        'txtLng
        '
        Me.txtLng.BackColor = System.Drawing.Color.White
        Me.txtLng.DisplayName = "担当者名"
        Me.txtLng.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtLng.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtLng.Location = New System.Drawing.Point(414, 597)
        Me.txtLng.MaxLength = 100
        Me.txtLng.Name = "txtLng"
        Me.txtLng.Size = New System.Drawing.Size(214, 25)
        Me.txtLng.TabIndex = 3
        Me.txtLng.Text = ""
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(340, 601)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(30, 17)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "緯度"
        '
        'btnChangeIoction
        '
        Me.btnChangeIoction.BackColor = System.Drawing.Color.Transparent
        Me.btnChangeIoction.FlatAppearance.BorderSize = 0
        Me.btnChangeIoction.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.btnChangeIoction.ForeColor = System.Drawing.Color.Black
        Me.btnChangeIoction.Location = New System.Drawing.Point(657, 598)
        Me.btnChangeIoction.Name = "btnChangeIoction"
        Me.btnChangeIoction.Size = New System.Drawing.Size(98, 22)
        Me.btnChangeIoction.TabIndex = 80
        Me.btnChangeIoction.TabStop = False
        Me.btnChangeIoction.Text = "緯度・経度取得"
        Me.btnChangeIoction.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.WebBrowser1)
        Me.Panel1.Location = New System.Drawing.Point(21, 55)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(981, 439)
        Me.Panel1.TabIndex = 81
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WebBrowser1.Location = New System.Drawing.Point(0, 0)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.ScrollBarsEnabled = False
        Me.WebBrowser1.Size = New System.Drawing.Size(979, 437)
        Me.WebBrowser1.TabIndex = 3
        '
        'txtAddress3
        '
        Me.txtAddress3.BackColor = System.Drawing.Color.White
        Me.txtAddress3.DisplayName = "担当者名"
        Me.txtAddress3.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtAddress3.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtAddress3.Location = New System.Drawing.Point(506, 562)
        Me.txtAddress3.MaxLength = 100
        Me.txtAddress3.Name = "txtAddress3"
        Me.txtAddress3.Size = New System.Drawing.Size(278, 25)
        Me.txtAddress3.TabIndex = 82
        Me.txtAddress3.Text = ""
        '
        'txtAddress2
        '
        Me.txtAddress2.BackColor = System.Drawing.Color.White
        Me.txtAddress2.DisplayName = "担当者名"
        Me.txtAddress2.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtAddress2.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtAddress2.Location = New System.Drawing.Point(206, 562)
        Me.txtAddress2.MaxLength = 100
        Me.txtAddress2.Name = "txtAddress2"
        Me.txtAddress2.Size = New System.Drawing.Size(294, 25)
        Me.txtAddress2.TabIndex = 83
        Me.txtAddress2.Text = ""
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 692)
        Me.Controls.Add(Me.txtAddress2)
        Me.Controls.Add(Me.txtAddress3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnChangeIoction)
        Me.Controls.Add(Me.btnHanei)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.txtLng)
        Me.Controls.Add(Me.txtLat)
        Me.Controls.Add(Me.txtAddress1)
        Me.Controls.Add(Me.txtPostCode)
        Me.Name = "Main"
        Me.Text = "Main"
        Me.Controls.SetChildIndex(Me.TitleBar, 0)
        Me.Controls.SetChildIndex(Me.FunctionKey, 0)
        Me.Controls.SetChildIndex(Me.txtPostCode, 0)
        Me.Controls.SetChildIndex(Me.txtAddress1, 0)
        Me.Controls.SetChildIndex(Me.txtLat, 0)
        Me.Controls.SetChildIndex(Me.txtLng, 0)
        Me.Controls.SetChildIndex(Me.txtName, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.btnHanei, 0)
        Me.Controls.SetChildIndex(Me.btnChangeIoction, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.txtAddress3, 0)
        Me.Controls.SetChildIndex(Me.txtAddress2, 0)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtPostCode As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents txtName As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btnHanei As Button
    Friend WithEvents txtAddress1 As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents Label3 As Label
    Friend WithEvents txtLat As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents Label4 As Label
    Friend WithEvents txtLng As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents Label5 As Label
    Friend WithEvents btnChangeIoction As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents WebBrowser1 As WebBrowser
    Friend WithEvents txtAddress3 As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents txtAddress2 As CommonUtility.WinFormControls.TextBoxEx
End Class
