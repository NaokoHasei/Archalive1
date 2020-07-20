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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.Button3 = New System.Windows.Forms.Button
        Me.TreeView1 = New System.Windows.Forms.TreeView
        Me.TextBoxEx1 = New CommonUtility.WinFormControls.TextBoxEx
        Me.DataGridView2 = New System.Windows.Forms.DataGridView
        Me.CommonDialogEx1 = New CommonUtility.WinFormControls.CommonDialogEx
        Me.TextBoxEx2 = New CommonUtility.WinFormControls.TextBoxEx
        Me.TextBoxEx3 = New CommonUtility.WinFormControls.TextBoxEx
        Me.CommonDialogEx2 = New CommonUtility.WinFormControls.CommonDialogEx
        Me.SENTAKU_TOKUI = New CommonUtility.WinFormControls.KobetuSentakuButton
        Me.SENTAKU_TANTO = New CommonUtility.WinFormControls.KobetuSentakuButton
        Me.SENTAKU_SIIRE = New CommonUtility.WinFormControls.KobetuSentakuButton
        Me.SENTAKU_SIIREREG = New CommonUtility.WinFormControls.KobetuSentakuButton
        Me.SENTAKU_TANTOREG = New CommonUtility.WinFormControls.KobetuSentakuButton
        Me.SENTAKU_TOKUIREG = New CommonUtility.WinFormControls.KobetuSentakuButton
        Me.Button4 = New System.Windows.Forms.Button
        Me.Button5 = New System.Windows.Forms.Button
        Me.txtSIHARAI_COMMENT_01 = New CommonUtility.WinFormControls.TextBoxEx
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Button6 = New System.Windows.Forms.Button
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(12, 94)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowTemplate.Height = 21
        Me.DataGridView1.Size = New System.Drawing.Size(771, 114)
        Me.DataGridView1.TabIndex = 5
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 214)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(65, 46)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "更新"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(14, 266)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(65, 46)
        Me.Button2.TabIndex = 7
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.HorizontalScrollbar = True
        Me.ListBox1.ItemHeight = 17
        Me.ListBox1.Location = New System.Drawing.Point(95, 266)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(256, 225)
        Me.ListBox1.TabIndex = 8
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(14, 560)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(209, 46)
        Me.Button3.TabIndex = 10
        Me.Button3.Text = "コンボボックス生成"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'TreeView1
        '
        Me.TreeView1.Location = New System.Drawing.Point(825, 94)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.Size = New System.Drawing.Size(181, 268)
        Me.TreeView1.TabIndex = 4
        '
        'TextBoxEx1
        '
        Me.TextBoxEx1.AllowDrop = True
        Me.TextBoxEx1.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBoxEx1.Location = New System.Drawing.Point(12, 66)
        Me.TextBoxEx1.Name = "TextBoxEx1"
        Me.TextBoxEx1.Size = New System.Drawing.Size(478, 22)
        Me.TextBoxEx1.TabIndex = 3
        Me.TextBoxEx1.Text = ""
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.AllowUserToDeleteRows = False
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(368, 227)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.ReadOnly = True
        Me.DataGridView2.RowTemplate.Height = 21
        Me.DataGridView2.Size = New System.Drawing.Size(415, 114)
        Me.DataGridView2.TabIndex = 11
        '
        'CommonDialogEx1
        '
        Me.CommonDialogEx1.Cancel = False
        Me.CommonDialogEx1.DialogKind = CommonUtility.WinFormControls.CommonDialogEx.enumDialogKind.Folder
        Me.CommonDialogEx1.LinkedTextBox = Me.TextBoxEx2
        Me.CommonDialogEx1.Location = New System.Drawing.Point(444, 404)
        Me.CommonDialogEx1.Name = "CommonDialogEx1"
        Me.CommonDialogEx1.Size = New System.Drawing.Size(69, 50)
        Me.CommonDialogEx1.TabIndex = 12
        Me.CommonDialogEx1.Text = "参照"
        Me.CommonDialogEx1.UseVisualStyleBackColor = True
        '
        'TextBoxEx2
        '
        Me.TextBoxEx2.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.TextBoxEx2.Location = New System.Drawing.Point(519, 419)
        Me.TextBoxEx2.Name = "TextBoxEx2"
        Me.TextBoxEx2.Size = New System.Drawing.Size(278, 23)
        Me.TextBoxEx2.TabIndex = 13
        Me.TextBoxEx2.Text = ""
        '
        'TextBoxEx3
        '
        Me.TextBoxEx3.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.TextBoxEx3.Location = New System.Drawing.Point(519, 475)
        Me.TextBoxEx3.Name = "TextBoxEx3"
        Me.TextBoxEx3.Size = New System.Drawing.Size(278, 23)
        Me.TextBoxEx3.TabIndex = 15
        Me.TextBoxEx3.Text = ""
        '
        'CommonDialogEx2
        '
        Me.CommonDialogEx2.Cancel = False
        Me.CommonDialogEx2.DialogKind = CommonUtility.WinFormControls.CommonDialogEx.enumDialogKind.File
        Me.CommonDialogEx2.LinkedTextBox = Me.TextBoxEx3
        Me.CommonDialogEx2.Location = New System.Drawing.Point(444, 460)
        Me.CommonDialogEx2.Name = "CommonDialogEx2"
        Me.CommonDialogEx2.Size = New System.Drawing.Size(69, 50)
        Me.CommonDialogEx2.TabIndex = 14
        Me.CommonDialogEx2.Text = "参照"
        Me.CommonDialogEx2.UseVisualStyleBackColor = True
        '
        'SENTAKU_TOKUI
        '
        Me.SENTAKU_TOKUI.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SENTAKU_TOKUI.Location = New System.Drawing.Point(825, 368)
        Me.SENTAKU_TOKUI.Name = "SENTAKU_TOKUI"
        Me.SENTAKU_TOKUI.Size = New System.Drawing.Size(168, 33)
        Me.SENTAKU_TOKUI.TabIndex = 19
        Me.SENTAKU_TOKUI.Text = "顧客個別選択"
        Me.SENTAKU_TOKUI.UseVisualStyleBackColor = True
        '
        'SENTAKU_TANTO
        '
        Me.SENTAKU_TANTO.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SENTAKU_TANTO.Location = New System.Drawing.Point(825, 446)
        Me.SENTAKU_TANTO.Name = "SENTAKU_TANTO"
        Me.SENTAKU_TANTO.Size = New System.Drawing.Size(168, 33)
        Me.SENTAKU_TANTO.TabIndex = 20
        Me.SENTAKU_TANTO.Text = "担当者個別選択"
        Me.SENTAKU_TANTO.UseVisualStyleBackColor = True
        '
        'SENTAKU_SIIRE
        '
        Me.SENTAKU_SIIRE.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SENTAKU_SIIRE.Location = New System.Drawing.Point(825, 407)
        Me.SENTAKU_SIIRE.Name = "SENTAKU_SIIRE"
        Me.SENTAKU_SIIRE.Size = New System.Drawing.Size(168, 33)
        Me.SENTAKU_SIIRE.TabIndex = 21
        Me.SENTAKU_SIIRE.Text = "業者個別選択"
        Me.SENTAKU_SIIRE.UseVisualStyleBackColor = True
        '
        'SENTAKU_SIIREREG
        '
        Me.SENTAKU_SIIREREG.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SENTAKU_SIIREREG.Location = New System.Drawing.Point(825, 524)
        Me.SENTAKU_SIIREREG.Name = "SENTAKU_SIIREREG"
        Me.SENTAKU_SIIREREG.Size = New System.Drawing.Size(168, 33)
        Me.SENTAKU_SIIREREG.TabIndex = 24
        Me.SENTAKU_SIIREREG.Text = "業者個別選択_保存"
        Me.SENTAKU_SIIREREG.UseVisualStyleBackColor = True
        '
        'SENTAKU_TANTOREG
        '
        Me.SENTAKU_TANTOREG.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SENTAKU_TANTOREG.Location = New System.Drawing.Point(825, 563)
        Me.SENTAKU_TANTOREG.Name = "SENTAKU_TANTOREG"
        Me.SENTAKU_TANTOREG.Size = New System.Drawing.Size(168, 33)
        Me.SENTAKU_TANTOREG.TabIndex = 23
        Me.SENTAKU_TANTOREG.Text = "担当者個別選択_保存"
        Me.SENTAKU_TANTOREG.UseVisualStyleBackColor = True
        '
        'SENTAKU_TOKUIREG
        '
        Me.SENTAKU_TOKUIREG.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SENTAKU_TOKUIREG.Location = New System.Drawing.Point(825, 485)
        Me.SENTAKU_TOKUIREG.Name = "SENTAKU_TOKUIREG"
        Me.SENTAKU_TOKUIREG.Size = New System.Drawing.Size(168, 33)
        Me.SENTAKU_TOKUIREG.TabIndex = 22
        Me.SENTAKU_TOKUIREG.Text = "顧客個別選択_保存"
        Me.SENTAKU_TOKUIREG.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(14, 330)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(65, 46)
        Me.Button4.TabIndex = 25
        Me.Button4.Text = "Button4"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(12, 396)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(65, 46)
        Me.Button5.TabIndex = 26
        Me.Button5.Text = "Button5"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'txtSIHARAI_COMMENT_01
        '
        Me.txtSIHARAI_COMMENT_01.BackColor = System.Drawing.Color.White
        Me.txtSIHARAI_COMMENT_01.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSIHARAI_COMMENT_01.DisplayName = "支払条件"
        Me.txtSIHARAI_COMMENT_01.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtSIHARAI_COMMENT_01.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtSIHARAI_COMMENT_01.Location = New System.Drawing.Point(16, 3)
        Me.txtSIHARAI_COMMENT_01.MaxLength = 30
        Me.txtSIHARAI_COMMENT_01.Name = "txtSIHARAI_COMMENT_01"
        Me.txtSIHARAI_COMMENT_01.Size = New System.Drawing.Size(214, 24)
        Me.txtSIHARAI_COMMENT_01.TabIndex = 27
        Me.txtSIHARAI_COMMENT_01.Text = "123456789012345678901234567890"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txtSIHARAI_COMMENT_01)
        Me.Panel1.Location = New System.Drawing.Point(264, 527)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(402, 30)
        Me.Panel1.TabIndex = 29
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(264, 558)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(65, 46)
        Me.Button6.TabIndex = 30
        Me.Button6.Text = "更新"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 692)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.SENTAKU_SIIREREG)
        Me.Controls.Add(Me.SENTAKU_TANTOREG)
        Me.Controls.Add(Me.SENTAKU_TOKUIREG)
        Me.Controls.Add(Me.SENTAKU_SIIRE)
        Me.Controls.Add(Me.SENTAKU_TANTO)
        Me.Controls.Add(Me.SENTAKU_TOKUI)
        Me.Controls.Add(Me.TextBoxEx3)
        Me.Controls.Add(Me.CommonDialogEx2)
        Me.Controls.Add(Me.TextBoxEx2)
        Me.Controls.Add(Me.CommonDialogEx1)
        Me.Controls.Add(Me.DataGridView2)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.TextBoxEx1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.TreeView1)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Main"
        Me.Text = "Main"
        Me.Controls.SetChildIndex(Me.Button1, 0)
        Me.Controls.SetChildIndex(Me.TreeView1, 0)
        Me.Controls.SetChildIndex(Me.Button2, 0)
        Me.Controls.SetChildIndex(Me.DataGridView1, 0)
        Me.Controls.SetChildIndex(Me.Button3, 0)
        Me.Controls.SetChildIndex(Me.TextBoxEx1, 0)
        Me.Controls.SetChildIndex(Me.ListBox1, 0)
        Me.Controls.SetChildIndex(Me.TitleBar, 0)
        Me.Controls.SetChildIndex(Me.FunctionKey, 0)
        Me.Controls.SetChildIndex(Me.DataGridView2, 0)
        Me.Controls.SetChildIndex(Me.CommonDialogEx1, 0)
        Me.Controls.SetChildIndex(Me.TextBoxEx2, 0)
        Me.Controls.SetChildIndex(Me.CommonDialogEx2, 0)
        Me.Controls.SetChildIndex(Me.TextBoxEx3, 0)
        Me.Controls.SetChildIndex(Me.SENTAKU_TOKUI, 0)
        Me.Controls.SetChildIndex(Me.SENTAKU_TANTO, 0)
        Me.Controls.SetChildIndex(Me.SENTAKU_SIIRE, 0)
        Me.Controls.SetChildIndex(Me.SENTAKU_TOKUIREG, 0)
        Me.Controls.SetChildIndex(Me.SENTAKU_TANTOREG, 0)
        Me.Controls.SetChildIndex(Me.SENTAKU_SIIREREG, 0)
        Me.Controls.SetChildIndex(Me.Button4, 0)
        Me.Controls.SetChildIndex(Me.Button5, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.Button6, 0)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
    Friend WithEvents TextBoxEx1 As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents CommonDialogEx1 As CommonUtility.WinFormControls.CommonDialogEx
    Friend WithEvents TextBoxEx2 As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents TextBoxEx3 As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents CommonDialogEx2 As CommonUtility.WinFormControls.CommonDialogEx
    Friend WithEvents SENTAKU_TOKUI As CommonUtility.WinFormControls.KobetuSentakuButton
    Friend WithEvents SENTAKU_TANTO As CommonUtility.WinFormControls.KobetuSentakuButton
    Friend WithEvents SENTAKU_SIIRE As CommonUtility.WinFormControls.KobetuSentakuButton
    Friend WithEvents SENTAKU_SIIREREG As CommonUtility.WinFormControls.KobetuSentakuButton
    Friend WithEvents SENTAKU_TANTOREG As CommonUtility.WinFormControls.KobetuSentakuButton
    Friend WithEvents SENTAKU_TOKUIREG As CommonUtility.WinFormControls.KobetuSentakuButton
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents txtSIHARAI_COMMENT_01 As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Button6 As System.Windows.Forms.Button
End Class
