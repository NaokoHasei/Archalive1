Imports System.ComponentModel

Public Class DataGridViewEx
    Private vsBar As VScrollBar
    Private hsBar As HScrollBar

    Private _AnyTimeVisibleVScrollbar As Boolean
    Private _AnyTimeVisibleHScrollbar As Boolean

    <Category("制御")> _
    <DefaultValue(True)> _
    <Description("常に縦スクロールバーを出力するかどうかを示します。")> _
    Public Overridable Property AnyTimeVisibleVScrollbar() As Boolean
        Get
            Return _AnyTimeVisibleVScrollbar
        End Get
        Set(ByVal value As Boolean)
            _AnyTimeVisibleVScrollbar = value
        End Set
    End Property

    <Category("制御")> _
    <DefaultValue(True)> _
    <Description("常に横スクロールバーを出力するかどうかを示します。")> _
    Public Overridable Property AnyTimeVisibleHScrollbar() As Boolean
        Get
            Return _AnyTimeVisibleHScrollbar
        End Get
        Set(ByVal value As Boolean)
            _AnyTimeVisibleHScrollbar = value
        End Set
    End Property

    Public Sub New()

        InitializeComponent()

        For Each c As Control In Me.Controls
            If TypeOf c Is VScrollBar Then
                vsBar = DirectCast(c, VScrollBar)
                AddHandler vsBar.VisibleChanged, AddressOf vsBar_VisibleChanged
            ElseIf TypeOf c Is HScrollBar Then
                hsBar = DirectCast(c, HScrollBar)
                AddHandler hsBar.VisibleChanged, AddressOf hsBar_VisibleChanged
            End If
        Next

        'If AnyTimeVisibleVScrollbar Then vsBar.Show()
        'If AnyTimeVisibleHScrollbar Then hsBar.Show()

        vsBar.Show()
        'If AnyTimeVisibleHScrollbar Then hsBar.Show()
        'hsBar.Show()

    End Sub

    Private Sub vsBar_VisibleChanged(ByVal sender As Object, ByVal e As EventArgs)
        With vsBar
            If Not .Visible AndAlso AnyTimeVisibleVScrollbar Then
                Dim BorderWidth As Integer = 2
                .Location = New Point(Me.ClientRectangle.Width - .Width, 0)
                .Size = New Size(.Width, Me.ClientRectangle.Height - BorderWidth + 2)
                .Show()
            End If
        End With
    End Sub
    Private Sub hsBar_VisibleChanged(ByVal sender As Object, ByVal e As EventArgs)
        With hsBar
            'If Not .Visible Then
            '    Dim BorderHeight As Integer = 16
            '    .Location = New Point(0, Me.ClientRectangle.Height - BorderHeight)
            '    .Size = New Size(Me.ClientRectangle.Width - BorderHeight, .Height)
            '    .Show()
            'End If
        End With
    End Sub

End Class
