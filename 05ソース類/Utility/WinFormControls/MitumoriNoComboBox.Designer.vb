<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MitumoriNoComboBox
    Inherits System.Windows.Forms.UserControl

    'UserControl はコンポーネント一覧をクリーンアップするために dispose をオーバーライドします。
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MitumoriNoComboBox))
        Dim Style1 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style2 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style3 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style4 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style5 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style6 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style7 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style8 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Me.DropDownIcon = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.DropdownControl = New CommonUtility.WinFormControls.DropdownEx
        Me.TextBoxControl = New CommonUtility.WinFormControls.TextBoxEx
        CType(Me.DropDownIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DropdownControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DropDownIcon
        '
        Me.DropDownIcon.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DropDownIcon.CaptionHeight = 16
        Me.DropDownIcon.CollapseColor = System.Drawing.Color.Maroon
        Me.DropDownIcon.ExpandColor = System.Drawing.Color.Red
        Me.DropDownIcon.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Flat
        Me.DropDownIcon.GroupByCaption = "列でグループ化するには、ここに列ヘッダをドラッグします。"
        Me.DropDownIcon.Images.Add(CType(resources.GetObject("DropDownIcon.Images"), System.Drawing.Image))
        Me.DropDownIcon.Location = New System.Drawing.Point(114, 48)
        Me.DropDownIcon.Name = "DropDownIcon"
        Me.DropDownIcon.PreviewInfo.Caption = "印刷プレビューウィンドウ"
        Me.DropDownIcon.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.DropDownIcon.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.DropDownIcon.PreviewInfo.ZoomFactor = 75
        Me.DropDownIcon.PrintInfo.PageSettings = CType(resources.GetObject("DropDownIcon.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.DropDownIcon.RowHeight = 18
        Me.DropDownIcon.RowSubDividerColor = System.Drawing.Color.Red
        Me.DropDownIcon.Size = New System.Drawing.Size(21, 19)
        Me.DropDownIcon.SplitDividerSize = New System.Drawing.Size(0, 0)
        Me.DropDownIcon.TabIndex = 68
        Me.DropDownIcon.TabStop = False
        Me.DropDownIcon.Text = "C1TrueDBGrid1"
        Me.DropDownIcon.PropBag = resources.GetString("DropDownIcon.PropBag")
        '
        'DropdownControl
        '
        Me.DropdownControl.AllowColMove = True
        Me.DropdownControl.AllowColSelect = True
        Me.DropdownControl.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.AllRows
        Me.DropdownControl.AlternatingRows = False
        Me.DropdownControl.CaptionHeight = 16
        Me.DropdownControl.CaptionStyle = Style1
        Me.DropdownControl.ColumnCaptionHeight = 16
        Me.DropdownControl.ColumnFooterHeight = 16
        Me.DropdownControl.EvenRowStyle = Style2
        Me.DropdownControl.FetchRowStyles = False
        Me.DropdownControl.FooterStyle = Style3
        Me.DropdownControl.HeadingStyle = Style4
        Me.DropdownControl.HighLightRowStyle = Style5
        Me.DropdownControl.Images.Add(CType(resources.GetObject("DropdownControl.Images"), System.Drawing.Image))
        Me.DropdownControl.Location = New System.Drawing.Point(25, 73)
        Me.DropdownControl.Name = "DropdownControl"
        Me.DropdownControl.OddRowStyle = Style6
        Me.DropdownControl.RecordSelectorStyle = Style7
        Me.DropdownControl.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.DropdownControl.RowDivider.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.[Single]
        Me.DropdownControl.RowHeight = 20
        Me.DropdownControl.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.DropdownControl.ScrollTips = False
        Me.DropdownControl.Size = New System.Drawing.Size(75, 29)
        Me.DropdownControl.Style = Style8
        Me.DropdownControl.TabIndex = 69
        Me.DropdownControl.TabStop = False
        Me.DropdownControl.Text = "C1TrueDBDropdown1"
        Me.DropdownControl.Visible = False
        Me.DropdownControl.PropBag = resources.GetString("DropdownControl.PropBag")
        '
        'TextBoxControl
        '
        Me.TextBoxControl.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBoxControl.Font = New System.Drawing.Font("メイリオ", 8.0!)
        Me.TextBoxControl.Location = New System.Drawing.Point(27, 21)
        Me.TextBoxControl.Name = "TextBoxControl"
        Me.TextBoxControl.Size = New System.Drawing.Size(78, 16)
        Me.TextBoxControl.TabIndex = 70
        Me.TextBoxControl.Visible = False
        '
        'MitumoriNoComboBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TextBoxControl)
        Me.Controls.Add(Me.DropdownControl)
        Me.Controls.Add(Me.DropDownIcon)
        Me.Name = "MitumoriNoComboBox"
        CType(Me.DropDownIcon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DropdownControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DropDownIcon As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents DropdownControl As CommonUtility.WinFormControls.DropdownEx
    Friend WithEvents TextBoxControl As CommonUtility.WinFormControls.TextBoxEx

End Class
