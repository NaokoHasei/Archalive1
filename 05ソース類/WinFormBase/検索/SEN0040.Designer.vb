<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SEN0040
    'Inherits System.Windows.Forms.Form
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
        Me.components = New System.ComponentModel.Container()
        Dim Label1 As System.Windows.Forms.Label
        Dim Label2 As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SEN0040))
        Me.tabSelect = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.cmdSearch1 = New System.Windows.Forms.Button()
        Me.txtTYOUIKI = New CommonUtility.WinFormControls.TextBoxEx()
        Me.txtSIKUTYOUSON = New CommonUtility.WinFormControls.TextBoxEx()
        Me.txtTODOUFUKEN = New CommonUtility.WinFormControls.TextBoxEx()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.txtTYOUIKI_SELECT = New CommonUtility.WinFormControls.TypComboBox()
        Me.txtSIKUTYOUSON_SELECT = New CommonUtility.WinFormControls.TypComboBox()
        Me.txtTODOUFUKEN_SELECT = New CommonUtility.WinFormControls.TypComboBox()
        Me.cmdSearch2 = New System.Windows.Forms.Button()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.txtTYOUIKI_KANA = New CommonUtility.WinFormControls.TextBoxEx()
        Me.txtSIKUTYOUSON_KANA = New CommonUtility.WinFormControls.TextBoxEx()
        Me.txtTODOUFUKEN_KANA = New CommonUtility.WinFormControls.TextBoxEx()
        Me.cmdSearch3 = New System.Windows.Forms.Button()
        Me.gridData = New CommonUtility.WinFormControls.DataGridViewEx(Me.components)
        Me.cmdSearch4 = New System.Windows.Forms.Button()
        Me.cmdSearch5 = New System.Windows.Forms.Button()
        Me.txtOLDPOSTCODE = New CommonUtility.WinFormControls.TextBoxEx()
        Me.txtPOSTCODE = New CommonUtility.WinFormControls.TextBoxEx()
        Label1 = New System.Windows.Forms.Label()
        Label2 = New System.Windows.Forms.Label()
        Me.tabSelect.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        CType(Me.gridData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TitleBar
        '
        Me.TitleBar.AppearanceType = CommonUtility.WinFormControls.AppearanceType.Normal
        Me.TitleBar.EditMode = CommonUtility.WinFormControls.EditMode.None
        Me.TitleBar.Size = New System.Drawing.Size(609, 40)
        Me.TitleBar.Title = ""
        '
        'FunctionKey
        '
        Me.FunctionKey.ButtonWidth02 = 40
        Me.FunctionKey.ButtonWidth03 = 40
        Me.FunctionKey.ButtonWidth04 = 40
        Me.FunctionKey.ButtonWidth05 = 40
        Me.FunctionKey.ButtonWidth06 = 40
        Me.FunctionKey.ButtonWidth07 = 40
        Me.FunctionKey.ButtonWidth08 = 40
        Me.FunctionKey.ButtonWidth09 = 40
        Me.FunctionKey.ButtonWidth10 = 40
        Me.FunctionKey.ButtonWidth11 = 40
        Me.FunctionKey.Location = New System.Drawing.Point(0, 607)
        Me.FunctionKey.Size = New System.Drawing.Size(609, 64)
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(361, 585)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(63, 17)
        Label1.TabIndex = 22
        Label1.Text = "旧郵便番号"
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Location = New System.Drawing.Point(16, 585)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(52, 17)
        Label2.TabIndex = 21
        Label2.Text = "郵便番号"
        '
        'tabSelect
        '
        Me.tabSelect.Controls.Add(Me.TabPage1)
        Me.tabSelect.Controls.Add(Me.TabPage2)
        Me.tabSelect.Controls.Add(Me.TabPage3)
        Me.tabSelect.ItemSize = New System.Drawing.Size(194, 20)
        Me.tabSelect.Location = New System.Drawing.Point(12, 51)
        Me.tabSelect.Name = "tabSelect"
        Me.tabSelect.SelectedIndex = 0
        Me.tabSelect.Size = New System.Drawing.Size(585, 61)
        Me.tabSelect.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.tabSelect.TabIndex = 2
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.cmdSearch1)
        Me.TabPage1.Controls.Add(Me.txtTYOUIKI)
        Me.TabPage1.Controls.Add(Me.txtSIKUTYOUSON)
        Me.TabPage1.Controls.Add(Me.txtTODOUFUKEN)
        Me.TabPage1.Location = New System.Drawing.Point(4, 24)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(577, 33)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "入力"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'cmdSearch1
        '
        Me.cmdSearch1.BackColor = System.Drawing.Color.Transparent
        Me.cmdSearch1.Location = New System.Drawing.Point(520, 4)
        Me.cmdSearch1.Name = "cmdSearch1"
        Me.cmdSearch1.Size = New System.Drawing.Size(49, 25)
        Me.cmdSearch1.TabIndex = 3
        Me.cmdSearch1.Text = "検索"
        Me.cmdSearch1.UseVisualStyleBackColor = False
        '
        'txtTYOUIKI
        '
        Me.txtTYOUIKI.DisplayName = "町域"
        Me.txtTYOUIKI.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtTYOUIKI.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtTYOUIKI.Location = New System.Drawing.Point(278, 6)
        Me.txtTYOUIKI.MaxLength = 128
        Me.txtTYOUIKI.Name = "txtTYOUIKI"
        Me.txtTYOUIKI.Size = New System.Drawing.Size(230, 22)
        Me.txtTYOUIKI.TabIndex = 2
        '
        'txtSIKUTYOUSON
        '
        Me.txtSIKUTYOUSON.DisplayName = "市区町村"
        Me.txtSIKUTYOUSON.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtSIKUTYOUSON.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtSIKUTYOUSON.Location = New System.Drawing.Point(102, 6)
        Me.txtSIKUTYOUSON.MaxLength = 32
        Me.txtSIKUTYOUSON.Name = "txtSIKUTYOUSON"
        Me.txtSIKUTYOUSON.Size = New System.Drawing.Size(166, 22)
        Me.txtSIKUTYOUSON.TabIndex = 1
        '
        'txtTODOUFUKEN
        '
        Me.txtTODOUFUKEN.DisplayName = "都道府県"
        Me.txtTODOUFUKEN.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtTODOUFUKEN.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtTODOUFUKEN.Location = New System.Drawing.Point(6, 6)
        Me.txtTODOUFUKEN.MaxLength = 8
        Me.txtTODOUFUKEN.Name = "txtTODOUFUKEN"
        Me.txtTODOUFUKEN.Size = New System.Drawing.Size(86, 22)
        Me.txtTODOUFUKEN.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.txtTYOUIKI_SELECT)
        Me.TabPage2.Controls.Add(Me.txtSIKUTYOUSON_SELECT)
        Me.TabPage2.Controls.Add(Me.txtTODOUFUKEN_SELECT)
        Me.TabPage2.Controls.Add(Me.cmdSearch2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 24)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(577, 33)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "選択"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'txtTYOUIKI_SELECT
        '
        Me.txtTYOUIKI_SELECT.AutoValidate = System.Windows.Forms.AutoValidate.Disable
        Me.txtTYOUIKI_SELECT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTYOUIKI_SELECT.DisplayName = "町域"
        Me.txtTYOUIKI_SELECT.Font = New System.Drawing.Font("メイリオ", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtTYOUIKI_SELECT.Location = New System.Drawing.Point(280, 8)
        Me.txtTYOUIKI_SELECT.MaxLength = 39
        Me.txtTYOUIKI_SELECT.Name = "txtTYOUIKI_SELECT"
        Me.txtTYOUIKI_SELECT.Size = New System.Drawing.Size(234, 18)
        Me.txtTYOUIKI_SELECT.TabIndex = 6
        '
        'txtSIKUTYOUSON_SELECT
        '
        Me.txtSIKUTYOUSON_SELECT.AutoValidate = System.Windows.Forms.AutoValidate.Disable
        Me.txtSIKUTYOUSON_SELECT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSIKUTYOUSON_SELECT.DisplayName = "市区町村"
        Me.txtSIKUTYOUSON_SELECT.Font = New System.Drawing.Font("メイリオ", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtSIKUTYOUSON_SELECT.Location = New System.Drawing.Point(102, 8)
        Me.txtSIKUTYOUSON_SELECT.MaxLength = 27
        Me.txtSIKUTYOUSON_SELECT.Name = "txtSIKUTYOUSON_SELECT"
        Me.txtSIKUTYOUSON_SELECT.Size = New System.Drawing.Size(162, 18)
        Me.txtSIKUTYOUSON_SELECT.TabIndex = 5
        '
        'txtTODOUFUKEN_SELECT
        '
        Me.txtTODOUFUKEN_SELECT.AutoValidate = System.Windows.Forms.AutoValidate.Disable
        Me.txtTODOUFUKEN_SELECT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTODOUFUKEN_SELECT.DisplayName = "都道府県"
        Me.txtTODOUFUKEN_SELECT.Font = New System.Drawing.Font("メイリオ", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtTODOUFUKEN_SELECT.Location = New System.Drawing.Point(6, 8)
        Me.txtTODOUFUKEN_SELECT.MaxLength = 10
        Me.txtTODOUFUKEN_SELECT.Name = "txtTODOUFUKEN_SELECT"
        Me.txtTODOUFUKEN_SELECT.Size = New System.Drawing.Size(82, 18)
        Me.txtTODOUFUKEN_SELECT.TabIndex = 4
        '
        'cmdSearch2
        '
        Me.cmdSearch2.Location = New System.Drawing.Point(514, 4)
        Me.cmdSearch2.Name = "cmdSearch2"
        Me.cmdSearch2.Size = New System.Drawing.Size(49, 25)
        Me.cmdSearch2.TabIndex = 3
        Me.cmdSearch2.Text = "検索"
        Me.cmdSearch2.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.txtTYOUIKI_KANA)
        Me.TabPage3.Controls.Add(Me.txtSIKUTYOUSON_KANA)
        Me.TabPage3.Controls.Add(Me.txtTODOUFUKEN_KANA)
        Me.TabPage3.Controls.Add(Me.cmdSearch3)
        Me.TabPage3.Location = New System.Drawing.Point(4, 24)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(577, 33)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "カナ"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'txtTYOUIKI_KANA
        '
        Me.txtTYOUIKI_KANA.DisplayName = "町域"
        Me.txtTYOUIKI_KANA.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtTYOUIKI_KANA.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.txtTYOUIKI_KANA.Location = New System.Drawing.Point(278, 6)
        Me.txtTYOUIKI_KANA.MaxLength = 128
        Me.txtTYOUIKI_KANA.Name = "txtTYOUIKI_KANA"
        Me.txtTYOUIKI_KANA.Size = New System.Drawing.Size(230, 22)
        Me.txtTYOUIKI_KANA.TabIndex = 2
        '
        'txtSIKUTYOUSON_KANA
        '
        Me.txtSIKUTYOUSON_KANA.DisplayName = "市区町村"
        Me.txtSIKUTYOUSON_KANA.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtSIKUTYOUSON_KANA.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.txtSIKUTYOUSON_KANA.Location = New System.Drawing.Point(102, 6)
        Me.txtSIKUTYOUSON_KANA.MaxLength = 32
        Me.txtSIKUTYOUSON_KANA.Name = "txtSIKUTYOUSON_KANA"
        Me.txtSIKUTYOUSON_KANA.Size = New System.Drawing.Size(166, 22)
        Me.txtSIKUTYOUSON_KANA.TabIndex = 1
        '
        'txtTODOUFUKEN_KANA
        '
        Me.txtTODOUFUKEN_KANA.DisplayName = "都道府県"
        Me.txtTODOUFUKEN_KANA.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtTODOUFUKEN_KANA.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.txtTODOUFUKEN_KANA.Location = New System.Drawing.Point(6, 6)
        Me.txtTODOUFUKEN_KANA.MaxLength = 8
        Me.txtTODOUFUKEN_KANA.Name = "txtTODOUFUKEN_KANA"
        Me.txtTODOUFUKEN_KANA.Size = New System.Drawing.Size(86, 22)
        Me.txtTODOUFUKEN_KANA.TabIndex = 0
        '
        'cmdSearch3
        '
        Me.cmdSearch3.Location = New System.Drawing.Point(514, 4)
        Me.cmdSearch3.Name = "cmdSearch3"
        Me.cmdSearch3.Size = New System.Drawing.Size(49, 25)
        Me.cmdSearch3.TabIndex = 3
        Me.cmdSearch3.Text = "検索"
        Me.cmdSearch3.UseVisualStyleBackColor = True
        '
        'gridData
        '
        Me.gridData.AnyTimeVisibleHScrollbar = False
        Me.gridData.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.gridData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridData.Location = New System.Drawing.Point(16, 123)
        Me.gridData.Name = "gridData"
        Me.gridData.RowTemplate.Height = 21
        Me.gridData.Size = New System.Drawing.Size(576, 441)
        Me.gridData.TabIndex = 16
        '
        'cmdSearch4
        '
        Me.cmdSearch4.BackColor = System.Drawing.Color.Transparent
        Me.cmdSearch4.Location = New System.Drawing.Point(185, 580)
        Me.cmdSearch4.Name = "cmdSearch4"
        Me.cmdSearch4.Size = New System.Drawing.Size(49, 25)
        Me.cmdSearch4.TabIndex = 18
        Me.cmdSearch4.Text = "検索"
        Me.cmdSearch4.UseVisualStyleBackColor = False
        '
        'cmdSearch5
        '
        Me.cmdSearch5.BackColor = System.Drawing.Color.Transparent
        Me.cmdSearch5.Location = New System.Drawing.Point(546, 580)
        Me.cmdSearch5.Name = "cmdSearch5"
        Me.cmdSearch5.Size = New System.Drawing.Size(49, 25)
        Me.cmdSearch5.TabIndex = 20
        Me.cmdSearch5.Text = "検索"
        Me.cmdSearch5.UseVisualStyleBackColor = False
        '
        'txtOLDPOSTCODE
        '
        Me.txtOLDPOSTCODE.DisplayName = "旧郵便番号"
        Me.txtOLDPOSTCODE.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtOLDPOSTCODE.Location = New System.Drawing.Point(454, 582)
        Me.txtOLDPOSTCODE.MaxLength = 8
        Me.txtOLDPOSTCODE.Name = "txtOLDPOSTCODE"
        Me.txtOLDPOSTCODE.Size = New System.Drawing.Size(86, 22)
        Me.txtOLDPOSTCODE.TabIndex = 19
        '
        'txtPOSTCODE
        '
        Me.txtPOSTCODE.DisplayName = "郵便番号"
        Me.txtPOSTCODE.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtPOSTCODE.Location = New System.Drawing.Point(93, 582)
        Me.txtPOSTCODE.MaxLength = 8
        Me.txtPOSTCODE.Name = "txtPOSTCODE"
        Me.txtPOSTCODE.Size = New System.Drawing.Size(86, 22)
        Me.txtPOSTCODE.TabIndex = 17
        '
        'SEN0040
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(609, 671)
        Me.Controls.Add(Me.cmdSearch4)
        Me.Controls.Add(Label1)
        Me.Controls.Add(Label2)
        Me.Controls.Add(Me.cmdSearch5)
        Me.Controls.Add(Me.txtOLDPOSTCODE)
        Me.Controls.Add(Me.txtPOSTCODE)
        Me.Controls.Add(Me.gridData)
        Me.Controls.Add(Me.tabSelect)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "SEN0040"
        Me.Text = ""
        Me.Controls.SetChildIndex(Me.TitleBar, 0)
        Me.Controls.SetChildIndex(Me.FunctionKey, 0)
        Me.Controls.SetChildIndex(Me.tabSelect, 0)
        Me.Controls.SetChildIndex(Me.gridData, 0)
        Me.Controls.SetChildIndex(Me.txtPOSTCODE, 0)
        Me.Controls.SetChildIndex(Me.txtOLDPOSTCODE, 0)
        Me.Controls.SetChildIndex(Me.cmdSearch5, 0)
        Me.Controls.SetChildIndex(Label2, 0)
        Me.Controls.SetChildIndex(Label1, 0)
        Me.Controls.SetChildIndex(Me.cmdSearch4, 0)
        Me.tabSelect.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        CType(Me.gridData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tabSelect As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents cmdSearch1 As System.Windows.Forms.Button
    Friend WithEvents txtTYOUIKI As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents txtSIKUTYOUSON As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents txtTODOUFUKEN As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents cmdSearch2 As System.Windows.Forms.Button
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents txtTYOUIKI_KANA As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents txtSIKUTYOUSON_KANA As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents txtTODOUFUKEN_KANA As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents cmdSearch3 As System.Windows.Forms.Button
    Friend WithEvents gridData As CommonUtility.WinFormControls.DataGridViewEx
    Friend WithEvents txtTYOUIKI_SELECT As CommonUtility.WinFormControls.TypComboBox
    Friend WithEvents txtSIKUTYOUSON_SELECT As CommonUtility.WinFormControls.TypComboBox
    Friend WithEvents txtTODOUFUKEN_SELECT As CommonUtility.WinFormControls.TypComboBox
    Friend WithEvents cmdSearch4 As System.Windows.Forms.Button
    Friend WithEvents cmdSearch5 As System.Windows.Forms.Button
    Friend WithEvents txtOLDPOSTCODE As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents txtPOSTCODE As CommonUtility.WinFormControls.TextBoxEx
End Class
