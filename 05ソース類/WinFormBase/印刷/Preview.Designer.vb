<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Preview
    Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Preview))
        Me.Viewer1 = New GrapeCity.ActiveReports.Viewer.Win.Viewer()
        Me.SuspendLayout()
        '
        'Viewer1
        '
        Me.Viewer1.BackColor = System.Drawing.SystemColors.Control
        Me.Viewer1.CurrentPage = 0
        Me.Viewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Viewer1.Location = New System.Drawing.Point(0, 0)
        Me.Viewer1.Name = "Viewer1"
        Me.Viewer1.PreviewPages = 0
        '
        '
        '
        '
        '
        '
        Me.Viewer1.Sidebar.ParametersPanel.ContextMenu = Nothing
        Me.Viewer1.Sidebar.ParametersPanel.Width = 200
        '
        '
        '
        Me.Viewer1.Sidebar.SearchPanel.ContextMenu = Nothing
        Me.Viewer1.Sidebar.SearchPanel.Width = 200
        '
        '
        '
        Me.Viewer1.Sidebar.ThumbnailsPanel.ContextMenu = Nothing
        Me.Viewer1.Sidebar.ThumbnailsPanel.Width = 200
        Me.Viewer1.Sidebar.ThumbnailsPanel.Zoom = 0.1R
        '
        '
        '
        Me.Viewer1.Sidebar.TocPanel.ContextMenu = Nothing
        Me.Viewer1.Sidebar.TocPanel.Expanded = True
        Me.Viewer1.Sidebar.TocPanel.Text = "Table Of Contents"
        Me.Viewer1.Sidebar.TocPanel.Width = 200
        Me.Viewer1.Sidebar.Width = 200
        Me.Viewer1.Size = New System.Drawing.Size(1016, 704)
        Me.Viewer1.TabIndex = 2
        '
        'Preview
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1016, 704)
        Me.Controls.Add(Me.Viewer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Preview"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Preview"
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents Viewer1 As GrapeCity.ActiveReports.Viewer.Win.Viewer
End Class
