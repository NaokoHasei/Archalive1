﻿Partial Class KobetuSentakuButton
    Inherits Button

    '<System.Diagnostics.DebuggerNonUserCode()> _
    'Public Sub New(ByVal container As System.ComponentModel.IContainer)
    '    MyClass.New()

    '    'Windows.Forms クラス作成デザイナのサポートに必要です。
    '    If (container IsNot Nothing) Then
    '        container.Add(Me)
    '    End If

    'End Sub

    '<System.Diagnostics.DebuggerNonUserCode()> _
    'Public Sub New()
    '    MyBase.New()

    '    'この呼び出しは、コンポーネント デザイナで必要です。
    '    InitializeComponent()

    'End Sub

    ''Component は、コンポーネント一覧に後処理を実行するために dispose をオーバーライドします。
    '<System.Diagnostics.DebuggerNonUserCode()> _
    'Protected Overrides Sub Dispose(ByVal disposing As Boolean)
    '    Try
    '        If disposing AndAlso components IsNot Nothing Then
    '            components.Dispose()
    '        End If
    '    Finally
    '        MyBase.Dispose(disposing)
    '    End Try
    'End Sub

    ''コンポーネント デザイナで必要です。
    'Private components As System.ComponentModel.IContainer

    ''メモ: 以下のプロシージャはコンポーネント デザイナで必要です。
    ''コンポーネント デザイナを使って変更できます。
    ''コード エディタを使って変更しないでください。
    '<System.Diagnostics.DebuggerStepThrough()> _
    'Private Sub InitializeComponent()
    '    components = New System.ComponentModel.Container()
    'End Sub

    'Control は、コンポーネント一覧に後処理を実行するために、dispose をオーバーライドします。
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

    'コントロール デザイナで必要です。
    Private components As System.ComponentModel.IContainer

    ' メモ: 以下のプロシージャはコンポーネント デザイナで必要です。
    ' コンポーネント デザイナを使って変更できます。
    ' コード エディタを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.SuspendLayout()
        '
        'KobetuSentakuButton
        '
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Text = "個別選択"
        Me.UseVisualStyleBackColor = False
        Me.ResumeLayout(False)

    End Sub

End Class
