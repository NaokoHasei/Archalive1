﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SENTEN
    Inherits KobetuSentakuForm2

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SENTEN))
        CType(Me.dbgMaster, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dbgMaster
        '
        Me.dbgMaster.Images.Add(CType(resources.GetObject("dbgMaster.Images"), System.Drawing.Image))
        Me.dbgMaster.PreviewInfo.Caption = "印刷プレビューウィンドウ"
        Me.dbgMaster.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.dbgMaster.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.dbgMaster.PreviewInfo.ZoomFactor = 75.0R
        Me.dbgMaster.PrintInfo.PageSettings = CType(resources.GetObject("dbgMaster.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.dbgMaster.PropBag = resources.GetString("dbgMaster.PropBag")
        '
        'TitleBar
        '
        Me.TitleBar.AppearanceType = CommonUtility.WinFormControls.AppearanceType.Normal
        Me.TitleBar.EditMode = CommonUtility.WinFormControls.EditMode.None
        Me.TitleBar.Size = New System.Drawing.Size(365, 40)
        '
        'FunctionKey
        '
        Me.FunctionKey.Location = New System.Drawing.Point(0, 530)
        Me.FunctionKey.Size = New System.Drawing.Size(365, 64)
        '
        'SENTEN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(365, 594)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "SENTEN"
        CType(Me.dbgMaster, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
End Class
