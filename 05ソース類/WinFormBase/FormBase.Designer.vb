<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormBase
    Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormBase))
        Me.FunctionKey = New CommonUtility.WinFormControls.FunctionKey()
        Me.TitleBar = New CommonUtility.WinFormControls.TitleBar()
        Me.SuspendLayout()
        '
        'FunctionKey
        '
        Me.FunctionKey.BackColor = System.Drawing.Color.DarkSlateBlue
        Me.FunctionKey.CausesValidation = False
        Me.FunctionKey.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.FunctionKey.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FunctionKey.Location = New System.Drawing.Point(0, 628)
        Me.FunctionKey.Name = "FunctionKey"
        Me.FunctionKey.Size = New System.Drawing.Size(1018, 64)
        Me.FunctionKey.TabIndex = 1
        Me.FunctionKey.TabStop = False
        '
        'TitleBar
        '
        Me.TitleBar.AutoSize = True
        Me.TitleBar.BackColor = System.Drawing.Color.DarkSlateBlue
        Me.TitleBar.Dock = System.Windows.Forms.DockStyle.Top
        Me.TitleBar.Font = New System.Drawing.Font("ＭＳ 明朝", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TitleBar.Location = New System.Drawing.Point(0, 0)
        Me.TitleBar.Margin = New System.Windows.Forms.Padding(0)
        Me.TitleBar.MaximumSize = New System.Drawing.Size(2000, 40)
        Me.TitleBar.MinimumSize = New System.Drawing.Size(100, 40)
        Me.TitleBar.Name = "TitleBar"
        Me.TitleBar.Padding = New System.Windows.Forms.Padding(32, 16, 48, 16)
        Me.TitleBar.Size = New System.Drawing.Size(1018, 40)
        Me.TitleBar.TabIndex = 0
        Me.TitleBar.TabStop = False
        '
        'FormBase
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoValidate = System.Windows.Forms.AutoValidate.Disable
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1018, 692)
        Me.Controls.Add(Me.FunctionKey)
        Me.Controls.Add(Me.TitleBar)
        Me.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FormBase"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "タイトル"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Protected WithEvents TitleBar As CommonUtility.WinFormControls.TitleBar
    Protected WithEvents FunctionKey As CommonUtility.WinFormControls.FunctionKey
End Class
