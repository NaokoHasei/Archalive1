<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SubForm1
    Inherits WinFormBase.ChildFormBase

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
        Me.txtBUKACODE = New CommonUtility.WinFormControls.TypComboBox
        Me.txtBUKANAME = New CommonUtility.WinFormControls.TextBoxEx
        Me.txtTANTOCODE = New CommonUtility.WinFormControls.TypComboBox
        Me.txtTANTONAME = New CommonUtility.WinFormControls.TextBoxEx
        Me.SuspendLayout()
        '
        'FunctionKey
        '
        Me.FunctionKey.Location = New System.Drawing.Point(0, 620)
        '
        'txtBUKACODE
        '
        Me.txtBUKACODE.AutoValidate = System.Windows.Forms.AutoValidate.Disable
        Me.txtBUKACODE.DisplayName = "部課コード"
        Me.txtBUKACODE.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtBUKACODE.LinkedTextBox = Me.txtBUKANAME
        Me.txtBUKACODE.Location = New System.Drawing.Point(134, 111)
        Me.txtBUKACODE.MaxLength = 4
        Me.txtBUKACODE.Name = "txtBUKACODE"
        Me.txtBUKACODE.Size = New System.Drawing.Size(74, 18)
        Me.txtBUKACODE.TabIndex = 3
        Me.txtBUKACODE.UseZeroPadding = True
        Me.txtBUKACODE.ZeroPaddingLength = 4
        '
        'txtBUKANAME
        '
        Me.txtBUKANAME.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.txtBUKANAME.DisplayName = "部課名称"
        Me.txtBUKANAME.Enabled = False
        Me.txtBUKANAME.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtBUKANAME.Location = New System.Drawing.Point(214, 111)
        Me.txtBUKANAME.Name = "txtBUKANAME"
        Me.txtBUKANAME.ReadOnly = True
        Me.txtBUKANAME.Size = New System.Drawing.Size(190, 22)
        Me.txtBUKANAME.TabIndex = 5
        Me.txtBUKANAME.Text = ""
        '
        'txtTANTOCODE
        '
        Me.txtTANTOCODE.AutoValidate = System.Windows.Forms.AutoValidate.Disable
        Me.txtTANTOCODE.DisplayName = "担当者コード"
        Me.txtTANTOCODE.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtTANTOCODE.LinkedTextBox = Me.txtTANTONAME
        Me.txtTANTOCODE.Location = New System.Drawing.Point(134, 135)
        Me.txtTANTOCODE.MaxLength = 4
        Me.txtTANTOCODE.Name = "txtTANTOCODE"
        Me.txtTANTOCODE.Size = New System.Drawing.Size(74, 18)
        Me.txtTANTOCODE.TabIndex = 4
        Me.txtTANTOCODE.UseZeroPadding = True
        Me.txtTANTOCODE.ZeroPaddingLength = 4
        '
        'txtTANTONAME
        '
        Me.txtTANTONAME.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.txtTANTONAME.DisplayName = "担当者名称"
        Me.txtTANTONAME.Enabled = False
        Me.txtTANTONAME.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtTANTONAME.Location = New System.Drawing.Point(214, 139)
        Me.txtTANTONAME.Name = "txtTANTONAME"
        Me.txtTANTONAME.ReadOnly = True
        Me.txtTANTONAME.Size = New System.Drawing.Size(190, 22)
        Me.txtTANTONAME.TabIndex = 6
        Me.txtTANTONAME.Text = ""
        '
        'SubForm1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 23.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 684)
        Me.Controls.Add(Me.txtTANTONAME)
        Me.Controls.Add(Me.txtBUKANAME)
        Me.Controls.Add(Me.txtTANTOCODE)
        Me.Controls.Add(Me.txtBUKACODE)
        Me.Name = "SubForm1"
        Me.Text = "SubForm1"
        Me.Controls.SetChildIndex(Me.TitleBar, 0)
        Me.Controls.SetChildIndex(Me.FunctionKey, 0)
        Me.Controls.SetChildIndex(Me.txtBUKACODE, 0)
        Me.Controls.SetChildIndex(Me.txtTANTOCODE, 0)
        Me.Controls.SetChildIndex(Me.txtBUKANAME, 0)
        Me.Controls.SetChildIndex(Me.txtTANTONAME, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtBUKACODE As CommonUtility.WinFormControls.TypComboBox
    Friend WithEvents txtTANTOCODE As CommonUtility.WinFormControls.TypComboBox
    Friend WithEvents txtBUKANAME As CommonUtility.WinFormControls.TextBoxEx
    Friend WithEvents txtTANTONAME As CommonUtility.WinFormControls.TextBoxEx
End Class
