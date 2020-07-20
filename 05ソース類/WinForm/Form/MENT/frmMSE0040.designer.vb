<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMSE0040
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

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim Label1 As System.Windows.Forms.Label
        Dim Label2 As System.Windows.Forms.Label
        Dim Label3 As System.Windows.Forms.Label
        Dim Label5 As System.Windows.Forms.Label
        Dim Label6 As System.Windows.Forms.Label
        Dim Label4 As System.Windows.Forms.Label
        Dim Label7 As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMSE0040))
        Me.PanelHeader1 = New System.Windows.Forms.Panel()
        Me.txtSIYOUKBN = New CommonUtility.WinFormControls.TypComboBox()
        Me.txtKBNNAME1 = New CommonUtility.WinFormControls.TextBoxEx()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.PanelDetail1 = New System.Windows.Forms.Panel()
        Me.txtKBN = New CommonUtility.WinFormControls.TextBoxEx()
        Me.PanelDetail2 = New System.Windows.Forms.Panel()
        Me.txtATAI2 = New CommonUtility.WinFormControls.TextBoxEx()
        Me.txtATAI1 = New CommonUtility.WinFormControls.TextBoxEx()
        Me.chkSYOKIHYOJIKBN = New System.Windows.Forms.CheckBox()
        Me.txtKBNNAME2 = New CommonUtility.WinFormControls.TextBoxEx()
        Me.txtBIKO = New CommonUtility.WinFormControls.TextBoxEx()
        Me.PanelHeader2 = New System.Windows.Forms.Panel()
        Me.gridData = New CommonUtility.WinFormControls.DataGridViewEx(Me.components)
        Me.lblBIKO = New System.Windows.Forms.Label()
        Label1 = New System.Windows.Forms.Label()
        Label2 = New System.Windows.Forms.Label()
        Label3 = New System.Windows.Forms.Label()
        Label5 = New System.Windows.Forms.Label()
        Label6 = New System.Windows.Forms.Label()
        Label4 = New System.Windows.Forms.Label()
        Label7 = New System.Windows.Forms.Label()
        Me.PanelHeader1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.PanelDetail1.SuspendLayout()
        Me.PanelDetail2.SuspendLayout()
        Me.PanelHeader2.SuspendLayout()
        CType(Me.gridData, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'Label1
        '
        Label1.AutoSize = True
        Label1.BackColor = System.Drawing.Color.Transparent
        Label1.Cursor = System.Windows.Forms.Cursors.Default
        Label1.Font = New System.Drawing.Font("メイリオ", 8.25!)
        Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Label1.Location = New System.Drawing.Point(9, 27)
        Label1.Name = "Label1"
        Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Label1.Size = New System.Drawing.Size(30, 17)
        Label1.TabIndex = 25
        Label1.Text = "区分"
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.BackColor = System.Drawing.Color.Transparent
        Label2.Cursor = System.Windows.Forms.Cursors.Default
        Label2.Font = New System.Drawing.Font("メイリオ", 8.25!)
        Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Label2.Location = New System.Drawing.Point(9, 99)
        Label2.Name = "Label2"
        Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Label2.Size = New System.Drawing.Size(30, 17)
        Label2.TabIndex = 26
        Label2.Text = "備考"
        '
        'Label3
        '
        Label3.AutoSize = True
        Label3.BackColor = System.Drawing.Color.Transparent
        Label3.Cursor = System.Windows.Forms.Cursors.Default
        Label3.Font = New System.Drawing.Font("メイリオ", 8.25!)
        Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Label3.Location = New System.Drawing.Point(9, 207)
        Label3.Name = "Label3"
        Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Label3.Size = New System.Drawing.Size(52, 17)
        Label3.TabIndex = 28
        Label3.Text = "初期表示"
        '
        'Label5
        '
        Label5.AutoSize = True
        Label5.BackColor = System.Drawing.Color.Transparent
        Label5.Cursor = System.Windows.Forms.Cursors.Default
        Label5.Font = New System.Drawing.Font("メイリオ", 8.25!)
        Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Label5.Location = New System.Drawing.Point(9, 63)
        Label5.Name = "Label5"
        Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Label5.Size = New System.Drawing.Size(30, 17)
        Label5.TabIndex = 27
        Label5.Text = "名称"
        '
        'Label6
        '
        Label6.AutoSize = True
        Label6.BackColor = System.Drawing.Color.Transparent
        Label6.Cursor = System.Windows.Forms.Cursors.Default
        Label6.Font = New System.Drawing.Font("メイリオ", 8.25!)
        Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Label6.Location = New System.Drawing.Point(13, 108)
        Label6.Name = "Label6"
        Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Label6.Size = New System.Drawing.Size(52, 17)
        Label6.TabIndex = 27
        Label6.Text = "使用区分"
        '
        'Label4
        '
        Label4.AutoSize = True
        Label4.BackColor = System.Drawing.Color.Transparent
        Label4.Cursor = System.Windows.Forms.Cursors.Default
        Label4.Font = New System.Drawing.Font("メイリオ", 8.25!)
        Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Label4.Location = New System.Drawing.Point(9, 135)
        Label4.Name = "Label4"
        Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Label4.Size = New System.Drawing.Size(30, 17)
        Label4.TabIndex = 29
        Label4.Text = "値１"
        '
        'Label7
        '
        Label7.AutoSize = True
        Label7.BackColor = System.Drawing.Color.Transparent
        Label7.Cursor = System.Windows.Forms.Cursors.Default
        Label7.Font = New System.Drawing.Font("メイリオ", 8.25!)
        Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Label7.Location = New System.Drawing.Point(9, 171)
        Label7.Name = "Label7"
        Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Label7.Size = New System.Drawing.Size(30, 17)
        Label7.TabIndex = 30
        Label7.Text = "値２"
        '
        'PanelHeader1
        '
        Me.PanelHeader1.Controls.Add(Me.txtSIYOUKBN)
        Me.PanelHeader1.Location = New System.Drawing.Point(90, 97)
        Me.PanelHeader1.Name = "PanelHeader1"
        Me.PanelHeader1.Size = New System.Drawing.Size(253, 37)
        Me.PanelHeader1.TabIndex = 0
        '
        'txtSIYOUKBN
        '
        Me.txtSIYOUKBN.AutoValidate = System.Windows.Forms.AutoValidate.Disable
        Me.txtSIYOUKBN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSIYOUKBN.DisplayName = "使用区分"
        Me.txtSIYOUKBN.Font = New System.Drawing.Font("メイリオ", 9.0!)
        Me.txtSIYOUKBN.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtSIYOUKBN.LinkedTextBox = Me.txtKBNNAME1
        Me.txtSIYOUKBN.Location = New System.Drawing.Point(0, 10)
        Me.txtSIYOUKBN.MaxLength = 2
        Me.txtSIYOUKBN.Name = "txtSIYOUKBN"
        Me.txtSIYOUKBN.Size = New System.Drawing.Size(42, 18)
        Me.txtSIYOUKBN.TabIndex = 1
        Me.txtSIYOUKBN.UseNullValidator = True
        Me.txtSIYOUKBN.UseUpdateLinkedTextByCodeChange = True
        '
        'txtKBNNAME1
        '
        Me.txtKBNNAME1.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.txtKBNNAME1.DisplayName = "使用区分名"
        Me.txtKBNNAME1.Font = New System.Drawing.Font("メイリオ", 9.0!)
        Me.txtKBNNAME1.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtKBNNAME1.Location = New System.Drawing.Point(3, 8)
        Me.txtKBNNAME1.MaxLength = 20
        Me.txtKBNNAME1.Name = "txtKBNNAME1"
        Me.txtKBNNAME1.ReadOnly = True
        Me.txtKBNNAME1.Size = New System.Drawing.Size(166, 25)
        Me.txtKBNNAME1.TabIndex = 0
        Me.txtKBNNAME1.Text = "12345678901234567890"
        Me.txtKBNNAME1.UseNullValidator = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Label7)
        Me.GroupBox1.Controls.Add(Label4)
        Me.GroupBox1.Controls.Add(Me.PanelDetail1)
        Me.GroupBox1.Controls.Add(Label1)
        Me.GroupBox1.Controls.Add(Label2)
        Me.GroupBox1.Controls.Add(Me.PanelDetail2)
        Me.GroupBox1.Controls.Add(Label5)
        Me.GroupBox1.Controls.Add(Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(580, 140)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(426, 459)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        '
        'PanelDetail1
        '
        Me.PanelDetail1.Controls.Add(Me.txtKBN)
        Me.PanelDetail1.Location = New System.Drawing.Point(86, 21)
        Me.PanelDetail1.Name = "PanelDetail1"
        Me.PanelDetail1.Size = New System.Drawing.Size(57, 30)
        Me.PanelDetail1.TabIndex = 0
        '
        'txtKBN
        '
        Me.txtKBN.DigitOnly = True
        Me.txtKBN.DisplayName = "区分"
        Me.txtKBN.Font = New System.Drawing.Font("メイリオ", 9.0!)
        Me.txtKBN.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtKBN.Location = New System.Drawing.Point(3, 3)
        Me.txtKBN.MaxLength = 4
        Me.txtKBN.Name = "txtKBN"
        Me.txtKBN.Size = New System.Drawing.Size(46, 25)
        Me.txtKBN.TabIndex = 0
        Me.txtKBN.Text = "1234"
        Me.txtKBN.UseNullValidator = True
        Me.txtKBN.ZeroPaddingLength = 4
        '
        'PanelDetail2
        '
        Me.PanelDetail2.Controls.Add(Me.txtATAI2)
        Me.PanelDetail2.Controls.Add(Me.txtATAI1)
        Me.PanelDetail2.Controls.Add(Me.chkSYOKIHYOJIKBN)
        Me.PanelDetail2.Controls.Add(Me.txtKBNNAME2)
        Me.PanelDetail2.Controls.Add(Me.txtBIKO)
        Me.PanelDetail2.Location = New System.Drawing.Point(86, 57)
        Me.PanelDetail2.Name = "PanelDetail2"
        Me.PanelDetail2.Size = New System.Drawing.Size(334, 201)
        Me.PanelDetail2.TabIndex = 1
        '
        'txtATAI2
        '
        Me.txtATAI2.DisplayName = "値２"
        Me.txtATAI2.Font = New System.Drawing.Font("メイリオ", 9.0!)
        Me.txtATAI2.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtATAI2.Location = New System.Drawing.Point(3, 111)
        Me.txtATAI2.MaxLength = 20
        Me.txtATAI2.Name = "txtATAI2"
        Me.txtATAI2.Size = New System.Drawing.Size(150, 25)
        Me.txtATAI2.TabIndex = 3
        Me.txtATAI2.Text = "12345678901234567890"
        Me.txtATAI2.UseNullValidator = True
        '
        'txtATAI1
        '
        Me.txtATAI1.DisplayName = "値１"
        Me.txtATAI1.Font = New System.Drawing.Font("メイリオ", 9.0!)
        Me.txtATAI1.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtATAI1.Location = New System.Drawing.Point(3, 75)
        Me.txtATAI1.MaxLength = 20
        Me.txtATAI1.Name = "txtATAI1"
        Me.txtATAI1.Size = New System.Drawing.Size(150, 25)
        Me.txtATAI1.TabIndex = 2
        Me.txtATAI1.Text = "12345678901234567890"
        Me.txtATAI1.UseNullValidator = True
        '
        'chkSYOKIHYOJIKBN
        '
        Me.chkSYOKIHYOJIKBN.AutoSize = True
        Me.chkSYOKIHYOJIKBN.Font = New System.Drawing.Font("メイリオ", 8.25!)
        Me.chkSYOKIHYOJIKBN.Location = New System.Drawing.Point(3, 147)
        Me.chkSYOKIHYOJIKBN.Name = "chkSYOKIHYOJIKBN"
        Me.chkSYOKIHYOJIKBN.Size = New System.Drawing.Size(203, 21)
        Me.chkSYOKIHYOJIKBN.TabIndex = 4
        Me.chkSYOKIHYOJIKBN.Text = "複数データへチェックは出来ません"
        Me.chkSYOKIHYOJIKBN.UseVisualStyleBackColor = True
        '
        'txtKBNNAME2
        '
        Me.txtKBNNAME2.DisplayName = "名称"
        Me.txtKBNNAME2.Font = New System.Drawing.Font("メイリオ", 9.0!)
        Me.txtKBNNAME2.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtKBNNAME2.Location = New System.Drawing.Point(3, 3)
        Me.txtKBNNAME2.MaxLength = 20
        Me.txtKBNNAME2.Name = "txtKBNNAME2"
        Me.txtKBNNAME2.Size = New System.Drawing.Size(166, 25)
        Me.txtKBNNAME2.TabIndex = 0
        Me.txtKBNNAME2.Text = "12345678901234567890"
        Me.txtKBNNAME2.UseNullValidator = True
        '
        'txtBIKO
        '
        Me.txtBIKO.DisplayName = "備考"
        Me.txtBIKO.Font = New System.Drawing.Font("メイリオ", 9.0!)
        Me.txtBIKO.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtBIKO.Location = New System.Drawing.Point(3, 39)
        Me.txtBIKO.MaxLength = 80
        Me.txtBIKO.Name = "txtBIKO"
        Me.txtBIKO.Size = New System.Drawing.Size(326, 25)
        Me.txtBIKO.TabIndex = 1
        Me.txtBIKO.Text = "12345678901234567890123456789012345678901234567890123456789012345678901234567890"
        Me.txtBIKO.UseNullValidator = True
        '
        'PanelHeader2
        '
        Me.PanelHeader2.Controls.Add(Me.txtKBNNAME1)
        Me.PanelHeader2.Location = New System.Drawing.Point(133, 97)
        Me.PanelHeader2.Name = "PanelHeader2"
        Me.PanelHeader2.Size = New System.Drawing.Size(210, 37)
        Me.PanelHeader2.TabIndex = 2
        '
        'gridData
        '
        Me.gridData.BackgroundColor = System.Drawing.Color.Thistle
        Me.gridData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridData.Location = New System.Drawing.Point(12, 140)
        Me.gridData.Name = "gridData"
        Me.gridData.RowTemplate.Height = 21
        Me.gridData.Size = New System.Drawing.Size(562, 459)
        Me.gridData.TabIndex = 28
        '
        'lblBIKO
        '
        Me.lblBIKO.BackColor = System.Drawing.Color.RoyalBlue
        Me.lblBIKO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBIKO.Font = New System.Drawing.Font("メイリオ", 8.25!)
        Me.lblBIKO.ForeColor = System.Drawing.SystemColors.Window
        Me.lblBIKO.Location = New System.Drawing.Point(589, 86)
        Me.lblBIKO.Name = "lblBIKO"
        Me.lblBIKO.Size = New System.Drawing.Size(411, 48)
        Me.lblBIKO.TabIndex = 42
        Me.lblBIKO.Text = "12345678901234567890123456789012345678901234567890123456789012345678901234567890"
        '
        'frmMSE0040
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 670)
        Me.Controls.Add(Me.lblBIKO)
        Me.Controls.Add(Me.gridData)
        Me.Controls.Add(Me.PanelHeader2)
        Me.Controls.Add(Label6)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.PanelHeader1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMSE0040"
        Me.Text = ""
        Me.Controls.SetChildIndex(Me.PanelHeader1, 0)
        Me.Controls.SetChildIndex(Me.TitleBar, 0)
        Me.Controls.SetChildIndex(Me.FunctionKey, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Label6, 0)
        Me.Controls.SetChildIndex(Me.PanelHeader2, 0)
        Me.Controls.SetChildIndex(Me.gridData, 0)
        Me.Controls.SetChildIndex(Me.lblBIKO, 0)
        Me.PanelHeader1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.PanelDetail1.ResumeLayout(False)
        Me.PanelDetail1.PerformLayout()
        Me.PanelDetail2.ResumeLayout(False)
        Me.PanelDetail2.PerformLayout()
        Me.PanelHeader2.ResumeLayout(False)
        Me.PanelHeader2.PerformLayout()
        CType(Me.gridData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PanelHeader1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtKBNNAME2 As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents txtBIKO As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents txtKBN As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents txtKBNNAME1 As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents PanelDetail2 As System.Windows.Forms.Panel
    Friend WithEvents chkSYOKIHYOJIKBN As System.Windows.Forms.CheckBox
    Friend WithEvents PanelDetail1 As System.Windows.Forms.Panel
    Friend WithEvents PanelHeader2 As System.Windows.Forms.Panel
    Friend WithEvents txtSIYOUKBN As CommonUtility.WinFormControls.TypComboBox
    Friend WithEvents txtATAI1 As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents txtATAI2 As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents gridData As CommonUtility.WinFormControls.DataGridViewEx
    Friend WithEvents lblBIKO As System.Windows.Forms.Label

End Class
