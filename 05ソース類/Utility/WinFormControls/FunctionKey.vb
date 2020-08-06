Public Class FunctionKey
    '    Protected functionButtons(11) As System.Windows.Forms.Button

    Public Event Action As EventHandler(Of FunctionKeyEventArgs)
    Public Event ItemEnabledChanging As EventHandler(Of ItemEnabledChangingEventArgs)

    Public ReadOnly FONT_SMALL As Font = New System.Drawing.Font("メイリオ", 9)
    Public ReadOnly FONT_DEFULT As Font = New System.Drawing.Font("メイリオ", 12)

    Protected Sub functionButton_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)

        If e.KeyCode >= Keys.F1 And e.KeyCode <= Keys.F12 Then
            Dim i As Integer

            i = e.KeyCode - Keys.F1 + 1
            If ItemEnabled(i) = True Then
                Me.Focus()
                If TypeOf (Me.FindForm) Is ILastFocusedControl Then
                    Dim f As ILastFocusedControl = CType(Me.FindForm, ILastFocusedControl)
                    RaiseEvent Action(Me, New FunctionKeyEventArgs(i, ButtonName(i - 1), ButtonCaption(i - 1), f.GetLastFocusedControl))
                Else
                    RaiseEvent Action(Me, New FunctionKeyEventArgs(i, ButtonName(i - 1), ButtonCaption(i - 1), Nothing))
                End If
            End If

        End If

    End Sub

    Protected Sub functionButton_Click(ByVal sender As Object, ByVal e As EventArgs)

        Dim i As Integer

        i = CType(CType(sender, Control).Tag, Integer)

        Try
            Me.Enabled = False

            If TypeOf (Me.FindForm) Is ILastFocusedControl Then
                Dim f As ILastFocusedControl = CType(Me.FindForm, ILastFocusedControl)
                RaiseEvent Action(Me, New FunctionKeyEventArgs(i, ButtonName(i - 1), ButtonCaption(i - 1), f.GetLastFocusedControl))
            Else
                RaiseEvent Action(Me, New FunctionKeyEventArgs(i, ButtonName(i - 1), ButtonCaption(i - 1), Nothing))
            End If

        Finally
            Me.Enabled = True

        End Try

    End Sub

    Protected ButtonName(12) As String
    Protected ButtonCaption(12) As String

    Public Property ItemName(ByVal index As Integer) As String
        Get
            Return ButtonName(index - 1)
        End Get
        Set(ByVal value As String)
            ButtonName(index - 1) = value
        End Set
    End Property

    Public Property ItemText(ByVal index As Integer) As String
        Get
            Return ButtonCaption(index - 1)
        End Get
        Set(ByVal value As String)
            ButtonCaption(index - 1) = value
            functionButtons(index - 1).Text = value
        End Set
    End Property

    Public Property ItemEnabled(ByVal index As Integer) As Boolean
        Get
            Return functionButtons(index - 1).Enabled
        End Get
        Set(ByVal value As Boolean)
            Dim e As New ItemEnabledChangingEventArgs(index, ButtonName(index - 1), ButtonCaption(index - 1), value)
            RaiseEvent ItemEnabledChanging(Me, e)
            If e.Cancel = False Then
                functionButtons(index - 1).Enabled = e.Value
            End If
        End Set
    End Property

    Public Property ItemFlatStyle(ByVal index As Integer) As FlatStyle
        Get
            Return functionButtons(index - 1).FlatStyle
        End Get
        Set(ByVal value As FlatStyle)
            functionButtons(index - 1).FlatStyle = value
        End Set
    End Property

    Public Property ItemFont(ByVal index As Integer) As Font
        Get
            Return functionButtons(index - 1).Font
        End Get
        Set(ByVal value As Font)
            functionButtons(index - 1).Font = value
        End Set
    End Property

    Public Property ItemEnabled(ByVal name As String) As Boolean
        Get
            Dim s As String
            Dim i As Integer
            i = 1
            For Each s In ButtonName
                If s = name Then
                    Return functionButtons(i - 1).Enabled
                End If
                i += 1
            Next
        End Get
        Set(ByVal value As Boolean)
            Dim index As Integer
            Dim s As String
            Dim i As Integer
            i = 1
            For Each s In ButtonName
                If s = name Then
                    index = i
                End If
                i += 1
            Next
            '対象のボタンがボタン名が見つからないときは無視する
            If index > 0 Then
                Dim e As New ItemEnabledChangingEventArgs(index, ButtonName(index - 1), ButtonCaption(index - 1), value)
                RaiseEvent ItemEnabledChanging(Me, e)
                If e.Cancel = False Then
                    functionButtons(index - 1).Enabled = e.Value
                End If
            End If

        End Set
    End Property

    Public Sub SetItem(ByVal index As Integer, ByVal name As String, ByVal caption As String, ByVal enabled As Boolean)
        ItemName(index) = name
        ItemText(index) = caption
        ItemEnabled(index) = enabled
    End Sub

    Public Sub SetItem(ByVal index As Integer, ByVal name As String, ByVal caption As String, ByVal enabled As Boolean, ByVal Font As Font)
        ItemName(index) = name
        ItemFont(index) = Font
        ItemText(index) = caption
        ItemEnabled(index) = enabled
    End Sub

    Public Sub SetItem(ByVal index As Integer, ByVal name As String, ByVal caption As String)
        ItemName(index) = name
        ItemText(index) = caption
        ItemEnabled(index) = ItemEnabled(index) '変更イベント発火のため値セット
    End Sub

    Public Sub ClearAll()
        For Index As Integer = 1 To 12
            ItemName(Index) = ""
            SetItem(Index, "", "", False, New System.Drawing.Font("メイリオ", 12))
            ItemEnabled(Index) = False
            SetForeColor(Index, Color.Black)
        Next
    End Sub

    Public Sub SetForeColor(ByVal index As Integer, ByVal color As System.Drawing.Color)
        functionButtons(index - 1).ForeColor = color
    End Sub

    Private ReadOnly Property functionButtons(ByVal index As Integer) As Button
        Get
            Dim Buttons() As System.Windows.Forms.Button = {functionButton1, functionButton2, functionButton3, functionButton4, functionButton5, functionButton6, functionButton7, functionButton8, functionButton9, functionButton10, functionButton11, functionButton12}

            Return Buttons(index)
        End Get
    End Property

    Private Sub FunctionKey_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        AddHandler Me.ParentForm.KeyDown, AddressOf functionButton_KeyDown

        AddHandler functionButton1.Click, AddressOf functionButton_Click
        AddHandler functionButton2.Click, AddressOf functionButton_Click
        AddHandler functionButton3.Click, AddressOf functionButton_Click
        AddHandler functionButton4.Click, AddressOf functionButton_Click
        AddHandler functionButton5.Click, AddressOf functionButton_Click
        AddHandler functionButton6.Click, AddressOf functionButton_Click
        AddHandler functionButton7.Click, AddressOf functionButton_Click
        AddHandler functionButton8.Click, AddressOf functionButton_Click
        AddHandler functionButton9.Click, AddressOf functionButton_Click
        AddHandler functionButton10.Click, AddressOf functionButton_Click
        AddHandler functionButton11.Click, AddressOf functionButton_Click
        AddHandler functionButton12.Click, AddressOf functionButton_Click
    End Sub

    Private Sub FunctionKey_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        CenterButtons()
    End Sub

    Private Sub LayoutButtons()
        For i As Integer = 0 To 11
            functionButtons(i).Size = New Size(ButtonWidth(i), ButtonHeight)
        Next
        Dim x As Integer = 0
        For i As Integer = 0 To 11
            functionButtons(i).Location = New Point(x, 0)
            x += ButtonWidth(i)
            If i = 3 Or i = 7 Then
                x += ButtonMargin
            End If
        Next

        CenterButtons()
    End Sub

    Private Sub CenterButtons()
        Dim ControlWidth As Integer = Me.Size.Width
        Dim ButtonWidth As Integer = (functionButton12.Location.X + functionButton12.Size.Width) - functionButton1.Location.X

        If ControlWidth <= ButtonWidth Then
            OffsetPositionX(-functionButton1.Location.X)
        Else
            Dim space As Integer = CInt((ControlWidth - ButtonWidth) / 2)
            Dim offset As Integer = -functionButton1.Location.X + space
            OffsetPositionX(offset)
        End If

        If Me.Size.Height > ButtonHeight Then
            Dim pos As Integer = CType(Me.Size.Height / 2 - ButtonHeight / 2, Integer)
            SetPositionY(pos)
        Else
            SetPositionY(0)
        End If
    End Sub
    Private Sub OffsetPositionX(ByVal offset As Integer)
        For i As Integer = 0 To 11
            functionButtons(i).Location = New Point(functionButtons(i).Location.X + offset, functionButtons(i).Location.Y)
        Next
    End Sub

    Private Sub SetPositionY(ByVal pos As Integer)
        For i As Integer = 0 To 11
            functionButtons(i).Location = New Point(functionButtons(i).Location.X, pos)
        Next
    End Sub

    Private ButtonWidthValue As Integer()
    Private DefaultButtonWidthValue As Integer()
    Private ButtonHeightValue As Integer
    Private ButtonMarginValue As Integer

    <DefaultValue(8)>
    Public Property ButtonMargin() As Integer
        Get
            Return ButtonMarginValue
        End Get
        Set(ByVal value As Integer)
            ButtonMarginValue = value
            LayoutButtons()
        End Set
    End Property

    Private Property ButtonWidth() As Integer()
        Get
            Return ButtonWidthValue
        End Get
        Set(ByVal value As Integer())
            ButtonWidthValue = value
            LayoutButtons()
        End Set
    End Property

    <DefaultValue(80)>
    Public Property ButtonWidth01() As Integer
        Get
            Return ButtonWidthValue(0)
        End Get
        Set(ByVal value As Integer)
            ButtonWidthValue(0) = value
            LayoutButtons()
        End Set
    End Property
    <DefaultValue(80)>
    Public Property ButtonWidth02() As Integer
        Get
            Return ButtonWidthValue(1)
        End Get
        Set(ByVal value As Integer)
            ButtonWidthValue(1) = value
            LayoutButtons()
        End Set
    End Property
    <DefaultValue(80)>
    Public Property ButtonWidth03() As Integer
        Get
            Return ButtonWidthValue(2)
        End Get
        Set(ByVal value As Integer)
            ButtonWidthValue(2) = value
            LayoutButtons()
        End Set
    End Property
    <DefaultValue(80)>
    Public Property ButtonWidth04() As Integer
        Get
            Return ButtonWidthValue(3)
        End Get
        Set(ByVal value As Integer)
            ButtonWidthValue(3) = value
            LayoutButtons()
        End Set
    End Property
    <DefaultValue(80)>
    Public Property ButtonWidth05() As Integer
        Get
            Return ButtonWidthValue(4)
        End Get
        Set(ByVal value As Integer)
            ButtonWidthValue(4) = value
            LayoutButtons()
        End Set
    End Property
    <DefaultValue(80)>
    Public Property ButtonWidth06() As Integer
        Get
            Return ButtonWidthValue(5)
        End Get
        Set(ByVal value As Integer)
            ButtonWidthValue(5) = value
            LayoutButtons()
        End Set
    End Property
    <DefaultValue(80)>
    Public Property ButtonWidth07() As Integer
        Get
            Return ButtonWidthValue(6)
        End Get
        Set(ByVal value As Integer)
            ButtonWidthValue(6) = value
            LayoutButtons()
        End Set
    End Property
    <DefaultValue(80)>
    Public Property ButtonWidth08() As Integer
        Get
            Return ButtonWidthValue(7)
        End Get
        Set(ByVal value As Integer)
            ButtonWidthValue(7) = value
            LayoutButtons()
        End Set
    End Property
    <DefaultValue(80)>
    Public Property ButtonWidth09() As Integer
        Get
            Return ButtonWidthValue(8)
        End Get
        Set(ByVal value As Integer)
            ButtonWidthValue(8) = value
            LayoutButtons()
        End Set
    End Property
    <DefaultValue(80)>
    Public Property ButtonWidth10() As Integer
        Get
            Return ButtonWidthValue(9)
        End Get
        Set(ByVal value As Integer)
            ButtonWidthValue(9) = value
            LayoutButtons()
        End Set
    End Property
    <DefaultValue(80)>
    Public Property ButtonWidth11() As Integer
        Get
            Return ButtonWidthValue(10)
        End Get
        Set(ByVal value As Integer)
            ButtonWidthValue(10) = value
            LayoutButtons()
        End Set
    End Property
    <DefaultValue(80)>
    Public Property ButtonWidth12() As Integer
        Get
            Return ButtonWidthValue(11)
        End Get
        Set(ByVal value As Integer)
            ButtonWidthValue(11) = value
            LayoutButtons()
        End Set
    End Property

    <DefaultValue(44)>
    Public Property ButtonHeight() As Integer
        Get
            Return ButtonHeightValue
        End Get
        Set(ByVal value As Integer)
            ButtonHeightValue = value
            LayoutButtons()
        End Set
    End Property

    Public Sub New()

        DefaultButtonWidthValue = New Integer() {80, 80, 80, 80, 80, 80, 80, 80, 80, 80, 80, 80}
        ButtonWidthValue = New Integer() {80, 80, 80, 80, 80, 80, 80, 80, 80, 80, 80, 80}
        ButtonHeightValue = 44
        ButtonMarginValue = 8

        If Me.FindForm IsNot Nothing Then
            Me.Font = Me.FindForm.Font
        End If

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。

    End Sub
End Class

Public Class ItemEnabledChangingEventArgs
    Inherits CancelEventArgs

    Private current As Boolean
    Public Index As Integer
    Public Name As String
    Public Text As String

    Public Property Value() As Boolean
        Get
            Return current
        End Get
        Set(ByVal value As Boolean)
            current = value
        End Set
    End Property

    Public Sub New(ByVal index As Integer, ByVal name As String, ByVal text As String, ByVal currentValue As Boolean)
        Me.Index = index
        Me.Name = name
        Me.Text = text
        current = currentValue
    End Sub
End Class

Public Class FunctionKeyEventArgs
    Inherits EventArgs

    Public Index As Integer
    Public Name As String
    Public Text As String
    Private handledValue As Boolean
    Private lastFocusdControlPtr As Control

    Public Property LastFocusdControl() As Control
        Get
            Return lastFocusdControlPtr
        End Get
        Set(ByVal value As Control)
            lastFocusdControlPtr = value
        End Set
    End Property

    Public Sub New(ByVal index As Integer, ByVal name As String, ByVal text As String, ByVal lastControl As Control)
        Me.Index = index
        Me.Name = name
        Me.Text = text
        'Handled = False
        LastFocusdControl = lastControl
    End Sub
End Class

Public Class FunctionKeyEnableWithEnterEvent
    Private Name As String
    Private FunctionControl As CommonUtility.WinFormControls.FunctionKey

    Public Sub New(ByVal funcControl As CommonUtility.WinFormControls.FunctionKey, ByVal control As Control, ByVal name As String)
        Me.Name = name
        Me.FunctionControl = funcControl

        AddHandler control.Enter, AddressOf ProcessFunctionEnter
    End Sub

    Protected Sub ProcessFunctionEnter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FunctionControl.ItemEnabled(Name) = True
    End Sub

    Protected Sub ProcessFunctionValidating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        FunctionControl.ItemEnabled(Name) = False
    End Sub

    Protected Sub ProcessFunctionLeave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim form As Control = (CType(sender, Control).FindForm.ActiveControl)
        If TypeOf form Is CommonUtility.WinFormControls.FunctionKey = False Then
            FunctionControl.ItemEnabled(Name) = False
        End If
    End Sub

End Class

Public Class FunctionKeyDisableWithEnterEvent
    Private Name As String

    Private FunctionControl As CommonUtility.WinFormControls.FunctionKey

    Public Sub New(ByVal funcControl As CommonUtility.WinFormControls.FunctionKey, ByVal control As Control, ByVal name As String)
        Me.Name = name
        Me.FunctionControl = funcControl

        AddHandler control.Enter, AddressOf ProcessFunctionEnter

    End Sub

    Protected Sub ProcessFunctionEnter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FunctionControl.ItemEnabled(Name) = False
    End Sub

End Class
