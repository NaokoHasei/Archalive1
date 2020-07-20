<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmUSERPASS
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUSERPASS))
        Me.txtPassword = New CommonUtility.WinFormControls.TextBoxEx()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtTantoCode = New CommonUtility.WinFormControls.TextBoxEx()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'TitleBar
        '
        Me.TitleBar.AppearanceType = CommonUtility.WinFormControls.AppearanceType.Normal
        Me.TitleBar.EditMode = CommonUtility.WinFormControls.EditMode.None
        Me.TitleBar.Size = New System.Drawing.Size(390, 40)
        Me.TitleBar.Title = ""
        '
        'FunctionKey
        '
        Me.FunctionKey.ButtonHeight = 35
        Me.FunctionKey.ButtonWidth01 = 53
        Me.FunctionKey.ButtonWidth02 = 23
        Me.FunctionKey.ButtonWidth03 = 23
        Me.FunctionKey.ButtonWidth04 = 23
        Me.FunctionKey.ButtonWidth05 = 23
        Me.FunctionKey.ButtonWidth06 = 23
        Me.FunctionKey.ButtonWidth07 = 23
        Me.FunctionKey.ButtonWidth08 = 23
        Me.FunctionKey.ButtonWidth09 = 23
        Me.FunctionKey.ButtonWidth10 = 23
        Me.FunctionKey.ButtonWidth11 = 23
        Me.FunctionKey.ButtonWidth12 = 53
        Me.FunctionKey.Location = New System.Drawing.Point(0, 162)
        Me.FunctionKey.Size = New System.Drawing.Size(390, 64)
        '
        'txtPassword
        '
        Me.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtPassword.DisplayName = "パスワード"
        Me.txtPassword.Font = New System.Drawing.Font("メイリオ", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtPassword.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtPassword.Location = New System.Drawing.Point(125, 109)
        Me.txtPassword.MaxLength = 30
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(238, 23)
        Me.txtPassword.TabIndex = 13
        Me.txtPassword.Text = "123456789012345"
        Me.txtPassword.UseSystemPasswordChar = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(45, 113)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 17)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "パスワード"
        '
        'txtTantoCode
        '
        Me.txtTantoCode.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTantoCode.DigitOnly = True
        Me.txtTantoCode.DisplayName = "担当者コード"
        Me.txtTantoCode.Font = New System.Drawing.Font("メイリオ", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtTantoCode.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtTantoCode.Location = New System.Drawing.Point(125, 68)
        Me.txtTantoCode.MaxLength = 4
        Me.txtTantoCode.Name = "txtTantoCode"
        Me.txtTantoCode.Size = New System.Drawing.Size(54, 23)
        Me.txtTantoCode.TabIndex = 10
        Me.txtTantoCode.Text = "1234"
        Me.txtTantoCode.UseNullValidator = True
        Me.txtTantoCode.UseZeroPadding = True
        Me.txtTantoCode.ZeroPaddingLength = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(45, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 17)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "担当者コード"
        '
        'lblVersion
        '
        Me.lblVersion.AutoSize = True
        Me.lblVersion.BackColor = System.Drawing.Color.DarkSlateBlue
        Me.lblVersion.ForeColor = System.Drawing.SystemColors.Window
        Me.lblVersion.Location = New System.Drawing.Point(338, 20)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(48, 17)
        Me.lblVersion.TabIndex = 14
        Me.lblVersion.Text = "1.0.0.0"
        '
        'frmUSERPASS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Thistle
        Me.ClientSize = New System.Drawing.Size(390, 226)
        Me.Controls.Add(Me.lblVersion)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtTantoCode)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmUSERPASS"
        Me.Text = ""
        Me.Controls.SetChildIndex(Me.TitleBar, 0)
        Me.Controls.SetChildIndex(Me.FunctionKey, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.txtTantoCode, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.txtPassword, 0)
        Me.Controls.SetChildIndex(Me.lblVersion, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtPassword As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtTantoCode As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblVersion As Label
End Class
