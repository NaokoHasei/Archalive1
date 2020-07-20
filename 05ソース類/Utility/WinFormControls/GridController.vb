Imports C1.Win.C1TrueDBGrid
Imports Model

Public Enum GridColumn
    Other
    SYOHINCODE
    JANCODE
    HINBANCODE
    COLORCODE
    SIZECODE
    PTNO
End Enum

Public Enum GridColumnType
    ''' <summary>
    ''' 型指定なし
    ''' </summary>
    ''' <remarks></remarks>
    None
    ''' <summary>
    ''' マスタのコード用[0-9]+
    ''' </summary>
    ''' <remarks></remarks>
    Code
    ''' <summary>
    ''' 数値
    ''' </summary>
    ''' <remarks></remarks>
    Numeric
    ''' <summary>
    ''' 符号付整数
    ''' </summary>
    ''' <remarks></remarks>
    SignedInteger
    ''' <summary>
    ''' 正の整数
    ''' </summary>
    ''' <remarks></remarks>
    PositiveInteger
    ''' <summary>
    ''' 名称等
    ''' </summary>
    ''' <remarks></remarks>
    Kanji
End Enum

''' <summary>
''' DBGrid内のコンボボックス
''' </summary>
''' <remarks></remarks>
Public Class GridComboBox

    Private WithEvents DropdownControl As DropdownEx
    Private dropdownTableName As ComboBoxTableName
    Private valueSelected As Boolean

    Private selectedDataRow As System.Data.DataRow

    ''' <summary>
    ''' 選択した行の内容を示します。
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property SelectedValue() As System.Data.DataRow
        Get
            Return selectedDataRow
        End Get
    End Property

    ''' <summary>
    ''' 選択した項目が変更され、その変更が TypComboBox に表示されると発生します。
    ''' </summary>
    ''' <remarks></remarks>
    Public Event SelectionChangeCommitted As EventHandler(Of EventArgs)

    Private Sub Dropdown_DropDownClose(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropdownControl.DropDownClose
        If valueSelected = True Then
            RaiseEvent SelectionChangeCommitted(Me, e)
        End If
    End Sub

    Private Sub Dropdown_DropDownOpen(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropdownControl.DropDownOpen
        valueSelected = False
    End Sub

    Private Sub DropdownControl_RowChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DropdownControl.RowChange
        selectedDataRow = CType(Dropdown.DataSource, System.Data.DataTable).DefaultView.ToTable.Rows(Dropdown.Bookmark)
        valueSelected = True
    End Sub

    ''' <summary>
    ''' データソースをセットします。
    ''' </summary>
    ''' <param name="dataValueSource">GetComboBoxContentsの戻り値</param>
    ''' <remarks></remarks>
    Public Sub AttachDataSource(ByVal dataValueSource As DTO.ResponseGetComboBoxContents)

        DropdownControl.DataSource = dataValueSource.Contents(dropdownTableName).ResultDataSet.Tables(0)
        DropdownControl.DataMember = ""
        '        DropdownControl.DisplayMember = dataValueSource.Contents(tableName).DataTextFields(1)
        DropdownControl.ValueMember = dataValueSource.Contents(dropdownTableName).DataValueField

        DropdownControl.SetWidth(dropdownTableName)

        '幅の計算
        Dim x As Integer = 0
        For i As Integer = 0 To Dropdown.DisplayColumns.Count - 1
            x += Dropdown.DisplayColumns(i).Width + 1
        Next
        Dropdown.Size = New Size(x + DropdownControl.VScrollBar.Width + 2, 200) '縦幅の計算
    End Sub

    ''' <summary>
    ''' C1TrueDBDropdownへの参照。
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Dropdown() As C1.Win.C1TrueDBGrid.C1TrueDBDropdown
        Get
            Return DropdownControl
        End Get
    End Property

    Private Sub InitializeComponent(ByVal gridController As GridController, ByVal tableName As ComboBoxTableName)
        dropdownTableName = tableName

        Dim Style1 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style2 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style3 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style4 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style5 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TypComboBox))
        Dim Style6 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style7 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style8 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style

        Me.DropdownControl = New DropdownEx
        Me.DropdownControl.AllowColMove = True
        Me.DropdownControl.AllowColSelect = True
        Me.DropdownControl.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.AllRows
        Me.DropdownControl.AlternatingRows = False
        Me.DropdownControl.CaptionHeight = 16
        Me.DropdownControl.CaptionStyle = Style1
        Me.DropdownControl.ColumnCaptionHeight = 21
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
        Me.DropdownControl.RowHeight = 17
        Me.DropdownControl.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.DropdownControl.ScrollTips = False
        Me.DropdownControl.Size = New System.Drawing.Size(75, 29)
        Me.DropdownControl.Style = Style8
        Me.DropdownControl.TabIndex = 7
        Me.DropdownControl.Text = "C1TrueDBDropdown1"
        Me.DropdownControl.Visible = False
        Me.DropdownControl.PropBag = resources.GetString("DropdownControl.PropBag")
        Me.DropdownControl.AllowSort = False

        gridController.GetParentForm().Controls.Add(DropdownControl)
    End Sub


    ''' <summary>
    ''' GridComboBoxを初期化します。
    ''' </summary>
    ''' <param name="gridController">関連付けるGridController</param>
    ''' <param name="tableName">関連付けるテーブル名</param>
    ''' <param name="column">関連付けるカラム番号</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal gridController As GridController, ByVal tableName As ComboBoxTableName, ByVal column As Integer)
        InitializeComponent(gridController, tableName)

        gridController.AttachComboBox(Me, column)

        With Dropdown
            .AllowRowSizing = RowSizingEnum.None    '行サイズの変更
            .FlatStyle = FlatModeEnum.Standard
            .HeadingStyle.BackColor = Color.FromArgb(0, 0, 192)
            .HeadingStyle.ForeColor = Color.White
            .ColumnCaptionHeight = 21
            .RowHeight = 17
            .AllowSort = False
            .Font = gridController.GetParentForm.Font
            .AllowRowSizing = RowSizingEnum.None 'スプリットのサイズ変更
            .AllowColSelect = False
            .VScrollBar.Style = ScrollBarStyleEnum.Always
        End With
    End Sub

    ''' <summary>
    ''' GridComboBoxを初期化します。
    ''' gridcontrollerネイティブサポートのコンボボックス(M_COLOR,M_SIZE)用です。
    ''' </summary>
    ''' <param name="gridController">関連付けるGridController</param>
    ''' <param name="tableName">関連付けるテーブル名</param>
    ''' <param name="assigned">関連付けるカラム種別</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal gridController As GridController, ByVal tableName As ComboBoxTableName, ByVal assigned As GridColumn)

        InitializeComponent(gridController, tableName)

        If assigned <> GridColumn.Other Then
            gridController.AttachComboBox(Me, assigned)

            With Dropdown
                .AllowRowSizing = RowSizingEnum.None    '行サイズの変更
                .FlatStyle = FlatModeEnum.Standard
                .HeadingStyle.BackColor = Color.FromArgb(0, 0, 192)
                .HeadingStyle.ForeColor = Color.White
                .ColumnCaptionHeight = 21
                .RowHeight = 17
                .AllowSort = False
                .Font = gridController.GetParentForm.Font
                .AllowRowSizing = RowSizingEnum.None 'スプリットのサイズ変更
                .AllowColSelect = False
                .VScrollBar.Style = ScrollBarStyleEnum.Always
            End With
        End If

        Select Case tableName
            'Case ComboBoxTableName.M_COLOR
            'Case ComboBoxTableName.M_SIZE
            Case Else
                Throw New ApplicationException("対応していないコンボボックス種別です。")
        End Select

    End Sub

    Private Sub DropdownControl_DropDownOpen(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropdownControl.DropDownOpen
    End Sub

End Class

''' <summary>
''' JANコード確定時に発生するGridSyohinSelected用引数
''' </summary>
''' <remarks></remarks>
Public Class GridSyohinSelectedEventArgs
    Inherits System.ComponentModel.CancelEventArgs


End Class

''' <summary>
''' GridControllerのInsertメソッド呼び出し時に発生するGridInitalizeInsertRow用引数
''' </summary>
''' <remarks></remarks>
Public Class GridInitalizeInsertRowEventArgs
    Inherits EventArgs

    Private dataRowValue As System.Data.DataRow

    ''' <summary>
    ''' 挿入されたDataRowへの参照。
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property NewDataRow() As System.Data.DataRow
        Get
            Return dataRowValue
        End Get
        Set(ByVal value As System.Data.DataRow)
            dataRowValue = value
        End Set
    End Property

End Class

''' <summary>
''' GridControllerのGridMoveFocus用引数
''' </summary>
''' <remarks></remarks>
Public Class GridMoveFocusEventArgs
    Inherits EventArgs

    Private currentColumnNumberValue As Integer
    Private nextColumnNumberValue As Integer
    Private currentRowNumberValue As Integer
    Private nextRowNumberValue As Integer
    Private moveForwardValue As Boolean

    ''' <summary>
    ''' 前方移動か後方移動かを示します。前方移動の場合はTrue。後方移動の場合はFalse。
    ''' ただし現在は常にTrueを返します。
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property IsMoveForward() As Boolean
        Get
            Return moveForwardValue
        End Get
        Set(ByVal value As Boolean)
            moveForwardValue = value
        End Set
    End Property

    ''' <summary>
    ''' 現在の列番号を示します。
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property CurrentColumnNumber() As Integer
        Get
            Return currentColumnNumberValue
        End Get
    End Property

    ''' <summary>
    ''' 次に移動する列番号を示します。
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property NextColumnNumber() As Integer
        Get
            Return nextColumnNumberValue
        End Get
        Set(ByVal value As Integer)
            nextColumnNumberValue = value
        End Set
    End Property

    ''' <summary>
    ''' 現在の行番号を示します。
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property CurrentRowNumber() As Integer
        Get
            Return currentRowNumberValue
        End Get
    End Property

    ''' <summary>
    ''' 次に移動する行番号を示します。
    ''' CurrentRowNumberと同じ値か+1した値のみ受け付けます。
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property NextRowNumber() As Integer
        Get
            Return nextRowNumberValue
        End Get
        Set(ByVal value As Integer)
            nextRowNumberValue = value
        End Set
    End Property

    Public Sub New(ByVal currentColumn As Integer, ByVal currentRow As Integer, ByVal isForward As Boolean)
        currentColumnNumberValue = currentColumn
        currentRowNumberValue = currentRow
        NextColumnNumber = currentColumnNumberValue
        NextRowNumber = currentRowNumberValue
        moveForwardValue = isForward
    End Sub

End Class

Public Class GridFunctionKeyEnableWithEnterEvent
    Private Name As String
    Private Column As Integer
    'Public Caption As String
    'Public Number As Integer
    Private FunctionControl As CommonUtility.WinFormControls.FunctionKey

    Private FunctionKeyEnableList As System.Collections.Generic.Dictionary(Of String, System.Collections.Generic.List(Of Integer))

    Public Sub Add(ByVal column As Integer, ByVal name As String)
        Me.Name = name
        Me.Column = column

        If FunctionKeyEnableList.ContainsKey(name) = False Then
            FunctionKeyEnableList.Add(name, New System.Collections.Generic.List(Of Integer))
        End If

        FunctionKeyEnableList(name).Add(column)

    End Sub

    Public Sub New(ByVal funcControl As CommonUtility.WinFormControls.FunctionKey, ByVal control As C1.Win.C1TrueDBGrid.C1TrueDBGrid)
        Me.FunctionControl = funcControl
        AddHandler control.Enter, AddressOf ProcessFunctionEnter
        AddHandler control.RowColChange, AddressOf ProcessFunctionRowColChange
        AddHandler control.Leave, AddressOf ProcessFunctionLeave

        FunctionKeyEnableList = New System.Collections.Generic.Dictionary(Of String, System.Collections.Generic.List(Of Integer))
    End Sub

    Protected Sub ProcessFunctionEnter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim col As Integer = CType(sender, C1.Win.C1TrueDBGrid.C1TrueDBGrid).Col

        For Each name As String In FunctionKeyEnableList.Keys
            For Each column As Integer In FunctionKeyEnableList(name)
                If column = col Then
                    FunctionControl.ItemEnabled(name) = True
                End If
            Next
        Next
    End Sub

    Protected Sub ProcessFunctionRowColChange(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs)
        If FunctionControl.FindForm().ActiveControl Is Nothing Then
            Return
        End If
        Dim col As Integer = CType(sender, C1.Win.C1TrueDBGrid.C1TrueDBGrid).Col
        For Each name As String In FunctionKeyEnableList.Keys
            Dim b As Boolean = False
            For Each column As Integer In FunctionKeyEnableList(name)
                If column = col Then
                    b = True
                End If
            Next
            FunctionControl.ItemEnabled(name) = b
        Next
    End Sub

    Protected Sub ProcessFunctionLeave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim form As Control = (CType(sender, Control).FindForm.ActiveControl)
        If TypeOf form Is CommonUtility.WinFormControls.FunctionKey = False Then
            Dim col As Integer = CType(sender, C1.Win.C1TrueDBGrid.C1TrueDBGrid).Col

            For Each name As String In FunctionKeyEnableList.Keys
                For Each column As Integer In FunctionKeyEnableList(name)
                    If column = col Then
                        FunctionControl.ItemEnabled(name) = True
                    End If
                Next
            Next

        End If
    End Sub

End Class

'Public Class GridValidateMaxGyoEventArgs
'    Inherits System.ComponentModel.CancelEventArgs

'    Private handledValue As Boolean = False
'    private 

'    Public Property Handled() As Boolean
'        Get
'            Return handledValue
'        End Get
'        Set(ByVal value As Boolean)
'            handledValue = value
'        End Set
'    End Property

'End Class

Public Class GridController

    Public Event GridSyohinSelected As EventHandler(Of GridSyohinSelectedEventArgs)
    Public Event MoveFocus As EventHandler(Of GridMoveFocusEventArgs)
    Public Event InitalizeInsertRow As EventHandler(Of GridInitalizeInsertRowEventArgs)

    Public Event BeforeColUpdate As EventHandler(Of C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs)
    Public Event BeforeInsert As EventHandler(Of C1.Win.C1TrueDBGrid.CancelEventArgs)
    Public Event BeforeUpdate As EventHandler(Of C1.Win.C1TrueDBGrid.CancelEventArgs)

    'Private searchSiireCodeValue As M_SIIRE_PrimaryKey

    'Public Property SearchSiireCode() As M_SIIRE_PrimaryKey
    '    Get
    '        Return searchSiireCodeValue
    '    End Get
    '    Set(ByVal value As M_SIIRE_PrimaryKey)
    '        searchSiireCodeValue = value
    '    End Set
    'End Property


    Private DefaultColumnPositionValue As Integer = 0

    Private blnBeforeInsert As Boolean

    ''' <summary>
    ''' 列のデフォルト位置を示します
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DefaultColumnPosition() As Integer
        Get
            Return DefaultColumnPositionValue
        End Get
        Set(ByVal value As Integer)
            DefaultColumnPositionValue = value
        End Set
    End Property

    Private strDispSiire As String
    Private blnWarningDisp As Boolean
    Private strSelectSiire As String

    Public Property DispSiire() As String
        Get
            Return strDispSiire
        End Get
        Set(ByVal value As String)
            strDispSiire = value
        End Set
    End Property

    Public Property WarningDisp() As Boolean
        Get
            Return blnWarningDisp
        End Get
        Set(ByVal value As Boolean)
            blnWarningDisp = value
        End Set
    End Property

    Public Property SelectSiire() As String
        Get
            Return strSelectSiire
        End Get
        Set(ByVal value As String)
            strSelectSiire = value
        End Set
    End Property

    '↑2009.03.16 Ins asano V3

    Public Sub OnInitalizeInsertRow(ByVal e As GridInitalizeInsertRowEventArgs)
        RaiseEvent InitalizeInsertRow(Me, e)
    End Sub

    Public Sub OnMoveFocus(ByVal e As GridMoveFocusEventArgs)
        RaiseEvent MoveFocus(Me, e)
    End Sub

    Public Sub OnJanCodeChange(ByVal e As GridSyohinSelectedEventArgs)
        RaiseEvent GridSyohinSelected(Me, e)
    End Sub

    Protected Sub MoveFocusHelper()
        Dim eventArgs As New GridMoveFocusEventArgs(GridControl.Col, GridControl.Row, True)
        OnMoveFocus(eventArgs)

        If eventArgs.CurrentRowNumber <> eventArgs.NextRowNumber Then
            If TryUpdateRow() = True Then
                GridControl.Col = eventArgs.NextColumnNumber
                GridControl.Row += 1
            End If
        Else
            GridControl.Col = eventArgs.NextColumnNumber
        End If
    End Sub

    Private ComboBoxSelectionChangeCommitted As Boolean = False

    Private Sub SizeComboBox_SelectionChangeCommitted(ByVal sender As Object, ByVal e As EventArgs)
        GridControl.Columns(columnReleation(GridColumn.PTNO)).Value = CType(sender, GridComboBox).SelectedValue(0)
        'GridControl.EditActive = True
        'GridControl.Columns(columnReleation(GridColumn.SIZECODE)).Value = "1"
        'GridControl.Columns(columnReleation(GridColumn.SIZECODE)).Value = CType(sender, GridComboBox).SelectedValue(1)
        'If TryUpdateCell() = False Then
        '    Return
        'End If
        'MoveFocusHelper()
        ComboBoxSelectionChangeCommitted = True
        GridControl.Invalidate() 'OwnerDrawイベントを発生させる

    End Sub

    Private Sub ComboBox_SelectionChangeCommitted(ByVal sender As Object, ByVal e As EventArgs)
        'GridControl.EditActive = True
        'GridControl.Columns(GridControl.Col).Value = "1"
        'GridControl.Columns(GridControl.Col).Value = CType(sender, GridComboBox).SelectedValue(0)
        'If TryUpdateCell() = False Then
        '    Return
        'End If
        'MoveFocusHelper()
        ComboBoxSelectionChangeCommitted = True
        GridControl.Invalidate() 'OwnerDrawイベントを発生させる

    End Sub
    Private Sub Grid_OwnerDraw(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.OwnerDrawCellEventArgs)
        If ComboBoxSelectionChangeCommitted = True Then
            'コンボボックスで選択された場合次の項目に移動させる
            ComboBoxSelectionChangeCommitted = False
            If TryUpdateCell() = False Then
                Return
            End If
            MoveFocusHelper()
        End If
    End Sub

    ''' <summary>
    ''' コンボボックスの割り当て
    ''' </summary>
    ''' <param name="gridComboBox">関連付けるコンボボックス</param>
    ''' <param name="assigned">関連付けるカラム種別</param>
    ''' <remarks></remarks>
    Public Sub AttachComboBox(ByVal gridComboBox As GridComboBox, ByVal assigned As GridColumn)
        GridControl.Columns(columnReleation(assigned)).DropDown = gridComboBox.Dropdown
        comboBoxList.Add(assigned, gridComboBox)
        GridControl.Splits(0).DisplayColumns(columnReleation(assigned)).OwnerDraw = True

        If assigned = GridColumn.SIZECODE Then
            AddHandler gridComboBox.SelectionChangeCommitted, AddressOf SizeComboBox_SelectionChangeCommitted
        Else
            AddHandler gridComboBox.SelectionChangeCommitted, AddressOf ComboBox_SelectionChangeCommitted
        End If
    End Sub

    ''' <summary>
    ''' コンボボックスの割り当て
    ''' </summary>
    ''' <param name="gridComboBox">関連付けるコンボボックス</param>
    ''' <param name="column">関連付ける列番号</param>
    ''' <remarks></remarks>
    Public Sub AttachComboBox(ByVal gridComboBox As GridComboBox, ByVal column As Integer)
        GridControl.Columns(column).DropDown = gridComboBox.Dropdown
        GridControl.Splits(0).DisplayColumns(column).OwnerDraw = True

        AddHandler gridComboBox.SelectionChangeCommitted, AddressOf ComboBox_SelectionChangeCommitted
    End Sub


    'ESC押下回数
    Private EscKeyDownCount As Integer

    'キー入力時True。Grid_KeyPressでOn,Off制御
    Private InKeyPress As Boolean

    Private PreviewKeyDownOn As Boolean


    ''' <summary>
    ''' キー入力制限、ESCキー制御、Enterキー制御を行います。
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Grid_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs)
        Try
            InKeyPress = True
            PreviewKeyDownOn = False

            'Tab押下時
            If e.KeyCode = Keys.Tab Then
                '現在編集中のセルを確定される
                If TryUpdateCell() = False Then
                    'エラーで確定できない場合
                    Return
                End If

                'OnMoveFocusイベントを発生させて選択セルを移動する
                MoveFocusHelper()

                PreviewKeyDownOn = True

            End If

        Finally

            InKeyPress = False

        End Try

    End Sub

    ''' <summary>
    ''' キー入力制限、ESCキー制御、Enterキー制御を行います。
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Grid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Try
            InKeyPress = True

            If columnReleation.ContainsKey(GridColumn.SIZECODE) = True AndAlso Col = columnReleation(GridColumn.SIZECODE) AndAlso e.KeyChar >= "0"c AndAlso e.KeyChar <= "9"c Then
                'サイズが手入力された場合はPTNOをクリアする
                If columnReleation.ContainsKey(GridColumn.PTNO) = True Then
                    GridControl.Columns(columnReleation(GridColumn.PTNO)).Value = ""
                End If
            End If

            'Enter押下時
            If e.KeyChar = vbCr Or e.KeyChar = vbTab Then

                If PreviewKeyDownOn = False Then

                    '現在編集中のセルを確定される
                    If TryUpdateCell() = False Then
                        'エラーで確定できない場合
                        e.Handled = True
                        Return
                    End If

                    'OnMoveFocusイベントを発生させて選択セルを移動する
                    MoveFocusHelper()

                End If

                e.Handled = True

            End If

            '以下キー入力制限
            If GetColumnValueType(Col) = GridColumnType.Code Then
                If Char.IsDigit(e.KeyChar) OrElse Char.IsControl(e.KeyChar) Then
                Else
                    e.Handled = True
                End If
            End If
            If GetColumnValueType(Col) = GridColumnType.Numeric Then
                If Char.IsDigit(e.KeyChar) OrElse Char.IsControl(e.KeyChar) OrElse e.KeyChar = "+"c OrElse e.KeyChar = "-"c OrElse e.KeyChar = "."c Then
                Else
                    e.Handled = True
                End If
            End If

            If GetColumnValueType(Col) = GridColumnType.PositiveInteger Then
                If Char.IsDigit(e.KeyChar) OrElse Char.IsControl(e.KeyChar) OrElse e.KeyChar = "+"c Then
                Else
                    e.Handled = True
                End If
            End If

            If GetColumnValueType(Col) = GridColumnType.SignedInteger Then
                If Char.IsDigit(e.KeyChar) OrElse Char.IsControl(e.KeyChar) OrElse e.KeyChar = "+"c OrElse e.KeyChar = "-"c Then
                Else
                    e.Handled = True
                End If
            End If

            'ESCキー制御
            If e.KeyChar = ChrW(27) Then
                '                If GridControl.AddNewMode = AddNewModeEnum.AddNewPending Or CurrentRowWasAddedByInsert = True Then
                If GridControl.AddNewMode = AddNewModeEnum.AddNewPending Then
                    EscKeyDownCount += 1
                    If EscKeyDownCount > 1 Then
                        e.Handled = True
                        GridControl.EditActive = False
                        GridControl.Delete()
                        EscKeyDownCount = 0
                    End If
                End If
                If GridControl.EditActive = False Then
                    GridControl.DataChanged = False
                    e.Handled = True
                End If
            End If

        Finally

            InKeyPress = False

        End Try

        If e.KeyChar <> ChrW(27) Then
            EscKeyDownCount = 0
        End If

    End Sub

    Private functionKeyEnabler As GridFunctionKeyEnableWithEnterEvent

    ''' <summary>
    ''' ファンクションキーON,OFF機能を有効にします。
    ''' </summary>
    ''' <param name="columnNumber">列番号</param>
    ''' <param name="name">ボタン名</param>
    ''' <remarks></remarks>
    Public Sub EnableFunctionKey(ByVal columnNumber As Integer, ByVal name As String)
        functionKeyEnabler.Add(columnNumber, name)
    End Sub

    Protected Overridable Sub FunctionKeyAction(ByVal sender As System.Object, ByVal e As CommonUtility.WinFormControls.FunctionKeyEventArgs)
        'If e.Name = "検索" Then
        '    Dim parentForm As ISearchFormCreatable = CType(GetParentForm(), ISearchFormCreatable)

        '    If e.LastFocusdControl.Name = GridControl.Name Then

        '        Select Case Col
        '            Case columnReleation(GridColumn.SYOHINCODE)
        '                Using syohinSearchForm As Form = parentForm.GetSEN0060
        '                    Dim iResult As ISearchMenu(Of M_SYOHIN_PrimaryKey) = CType(syohinSearchForm, ISearchMenu(Of M_SYOHIN_PrimaryKey))

        '                    If GridControl.EditActive = True Then GridControl.EditActive = False
        '                    If syohinSearchForm.ShowDialog() = Windows.Forms.DialogResult.OK Then
        '                        If iResult.ItemSelected = True Then
        '                            GridControl.EditActive = True

        '                            If blnBeforeInsert <> True Then
        '                                GridControl.Focus()
        '                                GridControl.Col = columnReleation(GridColumn.SYOHINCODE)
        '                                Return
        '                            End If

        '                            GridControl.Columns(columnReleation(GridColumn.SYOHINCODE)).Text = iResult.SelectedItem.SYOHINCODE
        '                            If TryUpdateCell() = False Then
        '                                Return
        '                            End If

        '                            MoveFocusHelper()
        '                        Else
        '                            GridControl.Focus()
        '                            GridControl.Col = columnReleation(GridColumn.SYOHINCODE)
        '                        End If
        '                    Else
        '                        GridControl.Focus()
        '                        GridControl.Col = columnReleation(GridColumn.SYOHINCODE)
        '                    End If
        '                End Using

        '            Case columnReleation(GridColumn.JANCODE)

        '                Dim syohinkey As Model.M_SYOHIN_PrimaryKey

        '                '''If (GridControl.AddNewMode <> AddNewModeEnum.NoAddNew) Then
        '                '''    syohinkey = New Model.M_SYOHIN_PrimaryKey()
        '                '''ElseIf Utility.NUCheck(GridControl.Bookmark) = True Then
        '                '''    syohinkey = New Model.M_SYOHIN_PrimaryKey()
        '                '''ElseIf Utility.NUCheck(GridControl.Columns(columnReleation(GridColumn.SYOHINCODE)).Text) = True Then
        '                '''    syohinkey = New Model.M_SYOHIN_PrimaryKey()
        '                '''Else
        '                '''    syohinkey = New Model.M_SYOHIN_PrimaryKey(GridControl.Columns(columnReleation(GridColumn.SYOHINCODE)).Text)
        '                '''End If
        '                If Utility.NUCheck(GridControl.Bookmark) = True Then
        '                    syohinkey = New Model.M_SYOHIN_PrimaryKey()
        '                    'ElseIf Utility.NUCheck(GridControl.Columns(columnReleation(GridColumn.SYOHINCODE)).Text) = True Then
        '                ElseIf Utility.NUCheck(GridControl.Item(GridControl.Row, columnReleation(GridColumn.SYOHINCODE)).ToString) = True Then
        '                    syohinkey = New Model.M_SYOHIN_PrimaryKey()
        '                Else
        '                    'syohinkey = New Model.M_SYOHIN_PrimaryKey(GridControl.Columns(columnReleation(GridColumn.SYOHINCODE)).Text)
        '                    syohinkey = New Model.M_SYOHIN_PrimaryKey(GridControl.Item(GridControl.Row, columnReleation(GridColumn.SYOHINCODE)).ToString)
        '                End If

        '                Using janSearchForm As Form = parentForm.GetSEN0110(syohinkey)
        '                    Dim iResult As ISearchMenu(Of M_JAN_PrimaryKey) = CType(janSearchForm, ISearchMenu(Of M_JAN_PrimaryKey))

        '                    If GridControl.EditActive = True Then GridControl.EditActive = False '2009.02.13 Ins asano V1～V3対応
        '                    If janSearchForm.ShowDialog() = Windows.Forms.DialogResult.OK Then
        '                        If iResult.ItemSelected = True Then
        '                            GridControl.EditActive = True

        '                            If blnBeforeInsert <> True Then
        '                                GridControl.Focus()
        '                                GridControl.Col = columnReleation(GridColumn.JANCODE)
        '                                Return
        '                            End If

        '                            GridControl.Columns(columnReleation(GridColumn.JANCODE)).Text = iResult.SelectedItem.JANCODE
        '                            If TryUpdateCell() = False Then
        '                                Return
        '                            End If

        '                            MoveFocusHelper()
        '                        Else
        '                            GridControl.Focus()
        '                            GridControl.Col = columnReleation(GridColumn.JANCODE)
        '                        End If
        '                    Else
        '                        GridControl.Focus()
        '                        GridControl.Col = columnReleation(GridColumn.JANCODE)
        '                    End If
        '                End Using

        '        End Select

        '    End If

        'End If
    End Sub

    ''' <summary>
    ''' 現在のスプリットの現在のセルの列位置を取得または設定します。
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Col() As Integer
        Get
            Return GridControl.Col
        End Get
        Set(ByVal value As Integer)
            GridControl.Col = value
        End Set
    End Property

    ''' <summary>
    ''' 削除予約商品メッセージ表示
    ''' </summary>
    ''' <param name="syohinInfo"></param>
    ''' <remarks></remarks>
    'Private Sub ShowDeleteReserveMessage(ByVal syohinInfo As ResponseSearchSyohin)
    '    'Dim list As New List(Of GetDbValueElement)
    '    'list.Add(New GetDbValueElement("M_SYOHIN", "SYOHINNAME,HINBANCODE,COLORCODE,SIZECODE", "SYOHINCODE = '" & syohinInfo.SyohinCode.SYOHINCODE & "'"))
    '    'Dim getdbvalue As New RemoteFacade.GetDbValue
    '    'Dim dr As System.Data.DataRow = getdbvalue.Execute(New RequestGetDbValue(list), ProgramId, UserCode).Item.Tables(0).Rows(0)

    '    'Dim s As String = ""
    '    's += "商品ｺｰﾄﾞ" & vbTab & syohinInfo.SyohinCode.SYOHINCODE & vbCrLf
    '    's += "商品名" & vbTab & CType(dr("SYOHINNAME"), String) & vbCrLf
    '    's += "JANｺｰﾄﾞ" & vbTab & syohinInfo.JanMasterKey.JANCODE & vbCrLf
    '    's += "品番" & vbTab & CType(dr("HINBANCODE"), String) & vbCrLf
    '    's += "ｶﾗｰｺｰﾄﾞ" & vbTab & CType(dr("COLORCODE"), String) & vbCrLf
    '    's += "ｻｲｽﾞｺｰﾄﾞ" & vbTab & CType(dr("SIZECODE"), String) & vbCrLf

    '    'CommonUtility.WinForm.MessageBoxEx.Show(MessageCode_Arg1.M93削除予約情報です, s, GetParentForm.Text)
    'End Sub

    ''' <summary>
    ''' 商品コード欄BeforeColUpdate
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <param name="columnNumber"></param>
    ''' <remarks></remarks>
    Private Sub SyohinBeforeColUpdate(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs, ByVal columnNumber As Integer)

        'Dim searchSyohinLogic As New RemoteFacade.SearchSyohin
        'Dim requestSearchSyohin As New RequestSearchSyohin
        'Dim responseSearchSyohin As ResponseSearchSyohin

        'ExistSyohin = True

        ''未入力チェック
        'If Utility.NUCheck(ColumnSyohinCode) = False Then
        '    '0パディング
        '    ColumnSyohinCode = Utility.ZeroPadding(ColumnSyohinCode, 14)
        'Else
        '    Return
        '    'Else
        '    '    MessageBoxEx.Show(MessageCode_Arg1.M15必ず入力して下さい, GetColumnDisplayName(GridColumn.SYOHINCODE), GetParentForm.Text)
        '    '    e.Cancel = True
        '    '    Return
        'End If
        'Dim syohinCode As String = ColumnSyohinCode

        ''基準jAN取得
        'requestSearchSyohin.SearchType = SearchSyohinType.SyohinCode
        'requestSearchSyohin.SyohinMasterKey = New M_SYOHIN_PrimaryKey(syohinCode)
        'requestSearchSyohin.TenMasterKey = New M_TEN_PrimaryKey(TenCode)
        'responseSearchSyohin = searchSyohinLogic.Execute(requestSearchSyohin, ProgramId, UserCode)

        ''janコードありの場合読み込み
        'If responseSearchSyohin.HitCount = 1 Then
        '    '削除フラグがたっている場合はメッセージ表示する
        '    If responseSearchSyohin.RegiKousiFlag = RegiKousinFlag.Deleted Then
        '        ShowDeleteReserveMessage(responseSearchSyohin)
        '        e.Cancel = True
        '        Return
        '    End If
        '    Dim cancelFlag As New GridSyohinSelectedEventArgs(responseSearchSyohin.JanMasterKey)
        '    OnJanCodeChange(cancelFlag)
        '    If cancelFlag.Cancel = True Then
        '        e.Cancel = True
        '    End If
        'Else
        '    If responseSearchSyohin.HitCount = 0 Then
        '        If FailOnSyohinNotFound() Then
        '            CommonUtility.WinForm.MessageBoxEx.Show(MessageCode_Arg1.M14存在しません, GetColumnDisplayName(GridColumn.SYOHINCODE), GetParentForm.Text)
        '            e.Cancel = True
        '        End If
        '        ExistSyohin = False
        '    End If
        'End If

    End Sub

    ''' <summary>
    ''' JANCODE欄BeforeColUpdate
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <param name="columnNumber"></param>
    ''' <remarks></remarks>
    Private Sub JanBeforeColUpdate(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs, ByVal columnNumber As Integer)

        'Dim searchSyohinLogic As New RemoteFacade.SearchSyohin
        'Dim requestSearchSyohin As New RequestSearchSyohin
        'Dim responseSearchSyohin As ResponseSearchSyohin

        'ExistSyohin = True

        'If Utility.NUCheck(ColumnJanCode) = False Then
        '    'ColumnJanCode = Utility.ZeroPadding(ColumnJanCode, 14)
        '    ColumnJanCode = Utility.CDCheck(ColumnJanCode)
        'Else
        '    Return
        '    'Else
        '    '    MessageBoxEx.Show(MessageCode_Arg1.M15必ず入力して下さい, GetColumnDisplayName(GridColumn.JANCODE), GetParentForm.Text)
        '    '    e.Cancel = True
        '    '    Return
        'End If

        ''基準jAN取得
        'requestSearchSyohin.SearchType = SearchSyohinType.JanCode
        'requestSearchSyohin.JanMasterKey = New M_JAN_PrimaryKey(TenCode, ColumnJanCode)
        'requestSearchSyohin.TenMasterKey = New M_TEN_PrimaryKey(TenCode)
        'responseSearchSyohin = searchSyohinLogic.Execute(requestSearchSyohin, ProgramId, UserCode)

        ''janコードありの場合読み込み
        'If responseSearchSyohin.HitCount = 1 Then
        '    '削除フラグがたっている場合はメッセージ表示する
        '    If responseSearchSyohin.RegiKousiFlag = RegiKousinFlag.Deleted Then
        '        ShowDeleteReserveMessage(responseSearchSyohin)
        '        e.Cancel = True
        '        Return
        '    End If
        '    Dim cancelFlag As New GridSyohinSelectedEventArgs(responseSearchSyohin.JanMasterKey)
        '    OnJanCodeChange(cancelFlag)
        '    If cancelFlag.Cancel = True Then
        '        e.Cancel = True
        '    End If
        'Else
        '    If responseSearchSyohin.HitCount = 0 Then
        '        If FailOnJanNotFound() Then
        '            CommonUtility.WinForm.MessageBoxEx.Show(MessageCode_Arg1.M014が存在しません, GetColumnDisplayName(GridColumn.JANCODE), GetParentForm.Text)
        '            e.Cancel = True
        '        End If
        '        ExistSyohin = False
        '    End If
        'End If


    End Sub

    Private FailOnSyohinNotFoundValue As Boolean = True
    Private FailOnJanNotFoundValue As Boolean = True
    Private FailOnHinbanNotFoundValue As Boolean = True
    Private ExistSyohinValue As Boolean = True

    ''' <summary>
    ''' 商品コード入力時にコードなしの場合エラーにする場合はTrue、それ以外の場合はFalse。
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property FailOnSyohinNotFound() As Boolean
        Get
            Return FailOnSyohinNotFoundValue
        End Get
        Set(ByVal value As Boolean)
            FailOnSyohinNotFoundValue = value
        End Set
    End Property
    ''' <summary>
    ''' ＪＡＮコード入力時にコードなしの場合エラーにする場合はTrue、それ以外の場合はFalse。
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property FailOnJanNotFound() As Boolean
        Get
            Return FailOnJanNotFoundValue
        End Get
        Set(ByVal value As Boolean)
            FailOnJanNotFoundValue = value
        End Set
    End Property
    ''' <summary>
    ''' 品番入力時に品番なしの場合エラーにする場合はTrue、それ以外の場合はFalse。
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property FailOnHinbanNotFound() As Boolean
        Get
            Return FailOnHinbanNotFoundValue
        End Get
        Set(ByVal value As Boolean)
            FailOnHinbanNotFoundValue = value
        End Set
    End Property

    ''' <summary>
    ''' 商品が存在した場合はTrue、それ以外の場合はFalse。
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ExistSyohin() As Boolean
        Get
            Return ExistSyohinValue
        End Get
        Set(ByVal value As Boolean)
            ExistSyohinValue = value
        End Set
    End Property

    Private columnReleation As System.Collections.Generic.Dictionary(Of GridColumn, Integer)
    Private comboBoxList As System.Collections.Generic.Dictionary(Of GridColumn, GridComboBox)

    Private beforeColUpdateByEnter As Integer

    ''' <summary>
    ''' BeforeColUpdateのハンドラ。セル単位の入力チェック。商品コード入力時等のマスタ呼び出し処理。
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub Grid_BeforeColUpdate(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs)

        If cancelEditAvtive Then
            Return
        End If

        '入力タイプが数字以外なら禁止文字チェック
        If GetColumnValueType(Col) <> GridColumnType.Numeric Then
            If CommonUtility.InputCheck.KinMojiCheck(CType(GridControl.Columns(e.ColIndex).Value, String)) = False Then
                'CommonUtility.WinForm.MessageBoxEx.Show(MessageCode_Arg1.M79入力禁止文字が含まれています, GetColumnDisplayName(e.ColIndex), GetParentForm.Text)
                e.Cancel = True
                Return
            End If
        End If

        If Utility.NUCheck(GridControl.Columns(e.ColIndex).Value) = False Then

            If GetColumnValueType(Col) = GridColumnType.Code Then
                If CommonUtility.InputCheck.DigitCheck(CType(GridControl.Columns(e.ColIndex).Value, String)) = False Then
                    CommonUtility.WinForm.MessageBoxEx.Show(MessageCode_Arg1.M019には数字を入力して下さい, GetColumnDisplayName(e.ColIndex), GetParentForm.Text)
                    e.Cancel = True
                    Return
                End If
            End If

            If GetColumnValueType(Col) = GridColumnType.Numeric Then
                If CommonUtility.InputCheck.RealValueCheck(CType(GridControl.Columns(e.ColIndex).Value, String)) = False Then
                    CommonUtility.WinForm.MessageBoxEx.Show(MessageCode_Arg1.M019には数字を入力して下さい, GetColumnDisplayName(e.ColIndex), GetParentForm.Text)
                    e.Cancel = True
                    Return
                End If
            End If

            If GetColumnValueType(Col) = GridColumnType.PositiveInteger Then
                If CommonUtility.InputCheck.PositiveIntegerCheck(CType(GridControl.Columns(e.ColIndex).Text.Replace(",", ""), String)) = False Then
                    CommonUtility.WinForm.MessageBoxEx.Show(MessageCode_Arg1.M019には数字を入力して下さい, GetColumnDisplayName(e.ColIndex), GetParentForm.Text)
                    e.Cancel = True
                    Return
                End If
            End If

            If GetColumnValueType(Col) = GridColumnType.SignedInteger Then
                If CommonUtility.InputCheck.SignedIntegerCheck(CType(GridControl.Columns(e.ColIndex).Text.Replace(",", ""), String)) = False Then
                    CommonUtility.WinForm.MessageBoxEx.Show(MessageCode_Arg1.M019には数字を入力して下さい, GetColumnDisplayName(e.ColIndex), GetParentForm.Text)
                    e.Cancel = True
                    Return
                End If
            End If

            '商品BeforeColUpdate呼び出し
            If columnReleation.ContainsKey(GridColumn.SYOHINCODE) = True Then
                If e.ColIndex = columnReleation(GridColumn.SYOHINCODE) Then
                    SyohinBeforeColUpdate(sender, e, e.ColIndex)
                End If
            End If

            'JANBeforeColUpdate呼び出し
            If columnReleation.ContainsKey(GridColumn.JANCODE) = True Then
                If e.ColIndex = columnReleation(GridColumn.JANCODE) Then
                    JanBeforeColUpdate(sender, e, e.ColIndex)
                End If
            End If

        Else
            If columnReleation.ContainsKey(GridColumn.HINBANCODE) = True Then
                If e.ColIndex = columnReleation(GridColumn.HINBANCODE) Then
                    ColumnSyohinCode = ""
                    ColumnJanCode = ""
                    ColumnColorCode = ""
                    ColumnSizeCode = ""
                End If
            End If
            If columnReleation.ContainsKey(GridColumn.COLORCODE) = True Then
                If e.ColIndex = columnReleation(GridColumn.COLORCODE) Then
                    ColumnSyohinCode = ""
                    ColumnJanCode = ""
                    ColumnSizeCode = ""
                End If
            End If
            If columnReleation.ContainsKey(GridColumn.SIZECODE) = True Then
                If e.ColIndex = columnReleation(GridColumn.SIZECODE) Then
                    ColumnSyohinCode = ""
                    ColumnJanCode = ""
                End If
            End If


        End If

        If e.Cancel = False Then
            RaiseEvent BeforeColUpdate(Me, e)
        End If

    End Sub

    ''' <summary>
    ''' BeforeUpdateのハンドラ。1行全体の入力チェック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub Grid_BeforeUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.CancelEventArgs)

        'セルの更新確定
        If TryUpdateCell() = False Then
            '確定失敗した場合
            e.Cancel = True
            Return
        End If

        For Col As Integer = 0 To GridControl.Columns.Count - 1
            If GridControl.Splits(0).DisplayColumns(Col).AllowFocus = True Then

                If GetColumnValueType(Col) = GridColumnType.Code OrElse GetColumnValueType(Col) = GridColumnType.Numeric Then
                    If IsMustInput(Col) Then

                        If Utility.NUCheck(GridControl.Columns(Col).Value) = True Then
                            CommonUtility.WinForm.MessageBoxEx.Show(MessageCode_Arg1.M015は必ず入力して下さい, GetColumnDisplayName(Col), GetParentForm.Text)
                            e.Cancel = True
                            GridControl.Col = Col
                            Return
                        End If
                    End If
                End If
                If GetColumnValueType(Col) = GridColumnType.Code Then
                    If CommonUtility.InputCheck.DigitCheck(CType(GridControl.Columns(Col).Value, String)) = False Then
                        CommonUtility.WinForm.MessageBoxEx.Show(MessageCode_Arg1.M019には数字を入力して下さい, GetColumnDisplayName(Col), GetParentForm.Text)
                        e.Cancel = True
                        GridControl.Col = Col
                        Return
                    End If
                End If

                If GetColumnValueType(Col) = GridColumnType.Numeric Then
                    If CommonUtility.InputCheck.RealValueCheck(CType(GridControl.Columns(Col).Value, String)) = False Then
                        CommonUtility.WinForm.MessageBoxEx.Show(MessageCode_Arg1.M019には数字を入力して下さい, GetColumnDisplayName(Col), GetParentForm.Text)
                        e.Cancel = True
                        GridControl.Col = Col
                        Return
                    End If
                End If

                If GetColumnValueType(Col) = GridColumnType.PositiveInteger Then
                    If CommonUtility.InputCheck.PositiveIntegerCheck(CType(GridControl.Columns(Col).Text.Replace(",", ""), String)) = False Then
                        CommonUtility.WinForm.MessageBoxEx.Show(MessageCode_Arg1.M019には数字を入力して下さい, GetColumnDisplayName(Col), GetParentForm.Text)
                        e.Cancel = True
                        GridControl.Col = Col
                        Return
                    End If
                End If

                If GetColumnValueType(Col) = GridColumnType.SignedInteger Then
                    If CommonUtility.InputCheck.SignedIntegerCheck(CType(GridControl.Columns(Col).Text.Replace(",", ""), String)) = False Then
                        CommonUtility.WinForm.MessageBoxEx.Show(MessageCode_Arg1.M019には数字を入力して下さい, GetColumnDisplayName(Col), GetParentForm.Text)
                        e.Cancel = True
                        GridControl.Col = Col
                        Return
                    End If
                End If

            End If

        Next

        If e.Cancel = False Then
            RaiseEvent BeforeUpdate(Me, e)
        End If

    End Sub

    ''' <summary>
    ''' 全ての行の必須入力チェックを行います
    ''' </summary>
    ''' <returns>検証が成功した場合はtrue。それ以外の場合はfalse。</returns>
    ''' <remarks></remarks>
    Public Function AllInputValidate() As Boolean
        For Row As Integer = 0 To GridControl.RowCount - 1

            For Col As Integer = 0 To GridControl.Columns.Count - 1
                If GridControl.Splits(0).DisplayColumns(Col).AllowFocus = True Then

                    If GetColumnValueType(Col) = GridColumnType.Code OrElse GetColumnValueType(Col) = GridColumnType.Numeric OrElse GetColumnValueType(Col) = GridColumnType.SignedInteger OrElse GetColumnValueType(Col) = GridColumnType.PositiveInteger Then
                        If IsMustInput(Col) Then

                            If Utility.NUCheck(GridControl.Columns(Col).CellValue(Row)) = True Then
                                CommonUtility.WinForm.MessageBoxEx.Show(MessageCode_Arg1.M015は必ず入力して下さい, GetColumnDisplayName(Col), GetParentForm.Text)
                                GridControl.Col = Col
                                GridControl.Row = Row
                                Return False
                            End If
                        End If
                    End If
                    If GetColumnValueType(Col) = GridColumnType.Code Then
                        If CommonUtility.InputCheck.DigitCheck(CType(GridControl.Columns(Col).CellValue(Row), String)) = False Then
                            CommonUtility.WinForm.MessageBoxEx.Show(MessageCode_Arg1.M019には数字を入力して下さい, GetColumnDisplayName(Col), GetParentForm.Text)
                            GridControl.Col = Col
                            GridControl.Row = Row
                            Return False
                        End If
                    End If

                    If GetColumnValueType(Col) = GridColumnType.Numeric Then
                        If CommonUtility.InputCheck.RealValueCheck(CType(GridControl.Columns(Col).CellValue(Row), String)) = False Then
                            CommonUtility.WinForm.MessageBoxEx.Show(MessageCode_Arg1.M019には数字を入力して下さい, GetColumnDisplayName(Col), GetParentForm.Text)
                            GridControl.Col = Col
                            GridControl.Row = Row
                            Return False
                        End If
                    End If

                    If GetColumnValueType(Col) = GridColumnType.SignedInteger Then
                        If CommonUtility.InputCheck.SignedIntegerCheck(CType(GridControl.Columns(Col).CellText(Row).Replace(",", ""), String)) = False Then
                            CommonUtility.WinForm.MessageBoxEx.Show(MessageCode_Arg1.M019には数字を入力して下さい, GetColumnDisplayName(Col), GetParentForm.Text)
                            GridControl.Col = Col
                            GridControl.Row = Row
                            Return False
                        End If
                    End If

                    If GetColumnValueType(Col) = GridColumnType.PositiveInteger Then
                        If CommonUtility.InputCheck.PositiveIntegerCheck(CType(GridControl.Columns(Col).CellText(Row).Replace(",", ""), String)) = False Then
                            CommonUtility.WinForm.MessageBoxEx.Show(MessageCode_Arg1.M019には数字を入力して下さい, GetColumnDisplayName(Col), GetParentForm.Text)
                            GridControl.Col = Col
                            GridControl.Row = Row
                            Return False
                        End If
                    End If

                End If

            Next

        Next

        Return True

    End Function

    ''' <summary>
    ''' 必須入力項目かどうかを返します。
    ''' コード、数値は必須入力。カラー、サイズは特例で省略可。ただしその場合は行確定不可となる。
    ''' </summary>
    ''' <param name="col">列番号</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function IsMustInput(ByVal col As Integer) As Boolean

        If columnReleation.ContainsKey(GridColumn.COLORCODE) Then
            If col = columnReleation(GridColumn.COLORCODE) Then
                Return False
            End If
        End If

        If columnReleation.ContainsKey(GridColumn.SIZECODE) Then
            If col = columnReleation(GridColumn.SIZECODE) Then
                Return False
            End If
        End If

        If GetColumnValueType(col) = GridColumnType.Code OrElse GetColumnValueType(col) = GridColumnType.Numeric OrElse GetColumnValueType(col) = GridColumnType.PositiveInteger OrElse GetColumnValueType(col) = GridColumnType.SignedInteger Then
            Return True
        End If

    End Function


    Public Sub AssignColumn(ByVal columnNumber As Integer, ByVal assigned As GridColumn)
        columnReleation(assigned) = columnNumber
    End Sub

    Public Function GetColumnDisplayName(ByVal column As Integer) As String
        If columnDisplayNameValue.ContainsKey(column) = False Then
            If columnReleation.ContainsValue(column) = True Then
                If columnReleation(GridColumn.SYOHINCODE) = column Then
                    columnDisplayNameValue(column) = "商品コード"
                End If
                If columnReleation(GridColumn.JANCODE) = column Then
                    columnDisplayNameValue(column) = "ＪＡＮコード"
                End If
                If columnReleation(GridColumn.HINBANCODE) = column Then
                    columnDisplayNameValue(column) = "品番"
                End If
                If columnReleation(GridColumn.SIZECODE) = column Then
                    columnDisplayNameValue(column) = "サイズ"
                End If
                If columnReleation(GridColumn.COLORCODE) = column Then
                    columnDisplayNameValue(column) = "カラー"
                End If

            End If
        End If
        If columnDisplayNameValue.ContainsKey(column) = False Then
#If DEBUG Then
            Throw New ApplicationException("SetColumnDisplayName(" & column & ")を呼び出して名前を指定してください")
#End If
            Return GridControl.Columns(column).Caption
        End If
        Return columnDisplayNameValue(column)
    End Function

    Public Sub SetColumnDisplayName(ByVal column As Integer, ByVal value As String)
        columnDisplayNameValue(column) = value
    End Sub

    Public Function GetColumnDisplayName(ByVal assingedColumn As GridColumn) As String
        Return GetColumnDisplayName(columnReleation(assingedColumn))
    End Function

    Public Sub SetColumnDisplayName(ByVal assingedColumn As GridColumn, ByVal value As String)
        SetColumnDisplayName(columnReleation(assingedColumn), value)
    End Sub

    Public Function GetColumnValueType(ByVal column As Integer) As GridColumnType
        If columnValueType.ContainsKey(column) = False Then
            If columnReleation.ContainsValue(column) = True Then
                If columnReleation(GridColumn.SYOHINCODE) = column Then
                    columnValueType(column) = GridColumnType.Code
                End If
                If columnReleation(GridColumn.JANCODE) = column Then
                    columnValueType(column) = GridColumnType.Code
                End If
                If columnReleation(GridColumn.HINBANCODE) = column Then
                    columnValueType(column) = GridColumnType.None
                End If
                If columnReleation(GridColumn.SIZECODE) = column Then
                    columnValueType(column) = GridColumnType.Code
                End If
                If columnReleation(GridColumn.COLORCODE) = column Then
                    columnValueType(column) = GridColumnType.Code
                End If

            End If
        End If
        If columnValueType.ContainsKey(column) = False Then
#If DEBUG Then
            Throw New ApplicationException("SetColumnValueTypeを呼び出して型を指定してください")
#End If
            Return GridColumnType.None
        End If
        Return columnValueType(column)
    End Function

    Public Sub SetColumnValueType(ByVal column As Integer, ByVal type As GridColumnType)
        columnValueType(column) = type
    End Sub

    Public Function GetColumnValueType(ByVal assingedColumn As GridColumn) As GridColumnType
        Return GetColumnValueType(columnReleation(assingedColumn))
    End Function

    Public Sub SetColumnValueType(ByVal assingedColumn As GridColumn, ByVal type As GridColumnType)
        SetColumnValueType(columnReleation(assingedColumn), type)
    End Sub


    Private columnDisplayNameValue As System.Collections.Generic.Dictionary(Of Integer, String)
    Private columnValueType As System.Collections.Generic.Dictionary(Of Integer, GridColumnType)
    Private columnUserNullVaidator As System.Collections.Generic.Dictionary(Of Integer, Boolean)

    Private gridControlPtr As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Private programIdValue As String
    Private userCodeValue As String
    Private tenCodeValue As String

    Public Property ProgramId() As String
        Get
            Return programIdValue
        End Get
        Set(ByVal value As String)
            programIdValue = value
        End Set
    End Property

    Public Property UserCode() As String
        Get
            Return userCodeValue
        End Get
        Set(ByVal value As String)
            userCodeValue = value
        End Set
    End Property

    Public Property TenCode() As String
        Get
            Return tenCodeValue
        End Get
        Set(ByVal value As String)
            tenCodeValue = value
        End Set
    End Property

    Public Property GridControl() As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Get
            Return gridControlPtr
        End Get
        Set(ByVal value As C1.Win.C1TrueDBGrid.C1TrueDBGrid)
            gridControlPtr = value
        End Set
    End Property

    Public Property ColumnHinbanCode() As String
        Get
            If GridControl.AddNewMode = C1.Win.C1TrueDBGrid.AddNewModeEnum.AddNewCurrent Then
                Return ""
            End If
            Dim value As Object = CType(GridControl.Columns(columnReleation(GridColumn.HINBANCODE)).Value, Object)
            Return Utility.NS(value)
        End Get
        Set(ByVal value As String)
            GridControl.Columns(columnReleation(GridColumn.HINBANCODE)).Value = value
        End Set
    End Property

    Public Property ColumnSyohinCode() As String
        Get

            If InKeyPress Then
                If GridControl.AddNewMode = C1.Win.C1TrueDBGrid.AddNewModeEnum.AddNewCurrent Then
                    Return ""
                End If
            End If

            '            Dim value As Object = CType(GridControl.Columns(columnReleation(GridColumn.SYOHINCODE)).CellValue(GridControl.Row), Object)
            Dim value As Object = CType(GridControl.Columns(columnReleation(GridColumn.SYOHINCODE)).Value, Object)
            Return Utility.NS(value)
        End Get
        Set(ByVal value As String)
            GridControl.Columns(columnReleation(GridColumn.SYOHINCODE)).Value = value
        End Set
    End Property

    Public Property ColumnJanCode() As String
        Get
            If InKeyPress Then
                If GridControl.AddNewMode = C1.Win.C1TrueDBGrid.AddNewModeEnum.AddNewCurrent Then
                    Return ""
                End If
            End If

            '            Dim value As Object = CType(GridControl.Columns(columnReleation(GridColumn.JANCODE)).CellValue(GridControl.Row), Object)
            Dim value As Object = CType(GridControl.Columns(columnReleation(GridColumn.JANCODE)).Value, Object)
            Return Utility.NS(value)
        End Get
        Set(ByVal value As String)
            GridControl.Columns(columnReleation(GridColumn.JANCODE)).Value = value
        End Set
    End Property

    Public Property ColumnColorCode() As String
        Get
            If InKeyPress Then
                If GridControl.AddNewMode = C1.Win.C1TrueDBGrid.AddNewModeEnum.AddNewCurrent Then
                    Return ""
                End If
            End If

            '            Dim value As Object = CType(GridControl.Columns(columnReleation(GridColumn.COLORCODE)).CellValue(GridControl.Row), Object)
            Dim value As Object = CType(GridControl.Columns(columnReleation(GridColumn.COLORCODE)).Value, Object)
            Return Utility.NS(value)
        End Get
        Set(ByVal value As String)
            GridControl.Columns(columnReleation(GridColumn.COLORCODE)).Value = value
        End Set
    End Property

    Public Property ColumnSizeCode() As String
        Get
            If InKeyPress Then
                If GridControl.AddNewMode = C1.Win.C1TrueDBGrid.AddNewModeEnum.AddNewCurrent Then
                    Return ""
                End If
            End If

            '            Dim value As Object = CType(GridControl.Columns(columnReleation(GridColumn.SIZECODE)).CellValue(GridControl.Row), Object)
            Dim value As Object = CType(GridControl.Columns(columnReleation(GridColumn.SIZECODE)).Value, Object)
            Return Utility.NS(value)
        End Get
        Set(ByVal value As String)
            GridControl.Columns(columnReleation(GridColumn.SIZECODE)).Value = value
        End Set
    End Property

    Public Property ColumnPtno() As String
        Get
            If InKeyPress Then
                If GridControl.AddNewMode = C1.Win.C1TrueDBGrid.AddNewModeEnum.AddNewCurrent Then
                    Return ""
                End If
            End If

            '            Dim value As Object = CType(GridControl.Columns(columnReleation(GridColumn.PTNO)).CellValue(GridControl.Row), Object)
            Dim value As Object = CType(GridControl.Columns(columnReleation(GridColumn.PTNO)).Value, Object)
            Return Utility.NS(value)
        End Get
        Set(ByVal value As String)
            GridControl.Columns(columnReleation(GridColumn.PTNO)).Value = value
        End Set
    End Property

    Public Sub New(ByVal gridControl As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal functionControl As FunctionKey, ByVal programId As String, ByVal userCode As String)
        gridControlPtr = gridControl
        programIdValue = programId
        userCodeValue = userCode
        'tenCodeValue = tenCode
        AddHandler gridControlPtr.BeforeColUpdate, AddressOf Grid_BeforeColUpdate
        AddHandler gridControlPtr.KeyPress, AddressOf Grid_KeyPress
        AddHandler gridControlPtr.PreviewKeyDown, AddressOf Grid_PreviewKeyDown
        AddHandler gridControlPtr.RowColChange, AddressOf Grid_RowColChange
        AddHandler gridControl.BeforeInsert, AddressOf Grid_BeforeInsert
        AddHandler gridControlPtr.Error, AddressOf Grid_Error
        AddHandler gridControl.BeforeUpdate, AddressOf Grid_BeforeUpdate
        AddHandler gridControl.OnAddNew, AddressOf Grid_AddNew
        AddHandler gridControl.OwnerDrawCell, AddressOf Grid_OwnerDraw
        AddHandler gridControlPtr.GotFocus, AddressOf Grid_GotFocus


        functionKeyEnabler = New GridFunctionKeyEnableWithEnterEvent(functionControl, gridControl)
        columnReleation = New System.Collections.Generic.Dictionary(Of GridColumn, Integer)
        comboBoxList = New System.Collections.Generic.Dictionary(Of GridColumn, GridComboBox)

        columnDisplayNameValue = New System.Collections.Generic.Dictionary(Of Integer, String)
        columnValueType = New System.Collections.Generic.Dictionary(Of Integer, GridColumnType)

        AddHandler functionControl.Action, AddressOf FunctionKeyAction

        UseMaxGyoCheck = False
        blnWarningDisp = False
        strDispSiire = ""

        gridControl.Splits(0).DisplayColumns(0).OwnerDraw = True
    End Sub

    Protected Sub Grid_AddNew(ByVal sender As Object, ByVal e As EventArgs)
        EscKeyDownCount = 0
    End Sub

    Protected Sub Grid_Error(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ErrorEventArgs)
        e.Handled = True
        Throw e.Exception
    End Sub

    Protected Sub Grid_BeforeInsert(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.CancelEventArgs)
        'MAXGYOチェック
        If UseMaxGyoCheck = True Then

            Dim f As IGridParentForm = CType(GetParentForm(), IGridParentForm)

            If GridControl.RowCount >= f.GetMaxRow Then
                CommonUtility.WinForm.MessageBoxEx.Show(MessageCode_Arg1.M036行までしか入力できません, f.GetMaxRow.ToString, GetParentForm().Text)
                e.Cancel = True
            End If
        End If

        If e.Cancel = False Then
            blnBeforeInsert = True
            RaiseEvent BeforeInsert(Me, e)
        Else
            blnBeforeInsert = False
        End If

    End Sub

    Private Sub RowColChange()
        'IME制御
        If GetColumnValueType(GridControl.Col) = GridColumnType.Kanji Then
            With GridControl
                .ImeMode = Windows.Forms.ImeMode.Hiragana
                For Each ctrl As Control In .Controls
                    If TypeOf ctrl Is TextBox Then
                        ctrl.ImeMode = Windows.Forms.ImeMode.Hiragana
                    End If
                Next
            End With
        End If
        '↓2013.04.24 Upd yamada GridColumnType.None追加
        'If GetColumnValueType(GridControl.Col) = GridColumnType.Code OrElse GetColumnValueType(GridControl.Col) = GridColumnType.Numeric OrElse GetColumnValueType(GridControl.Col) = GridColumnType.SignedInteger OrElse GetColumnValueType(GridControl.Col) = GridColumnType.PositiveInteger Then
        If GetColumnValueType(GridControl.Col) = GridColumnType.Code OrElse GetColumnValueType(GridControl.Col) = GridColumnType.Numeric OrElse GetColumnValueType(GridControl.Col) = GridColumnType.SignedInteger OrElse GetColumnValueType(GridControl.Col) = GridColumnType.PositiveInteger OrElse GetColumnValueType(GridControl.Col) = GridColumnType.None Then
            With GridControl
                .ImeMode = Windows.Forms.ImeMode.Disable
                For Each ctrl As Control In .Controls
                    If TypeOf ctrl Is TextBox Then
                        ctrl.ImeMode = Windows.Forms.ImeMode.Disable
                    End If
                Next
            End With
        End If

    End Sub

    Private Sub Grid_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs)
        If GetParentForm().ActiveControl Is Nothing Then
            Return
        End If

        RowColChange()

    End Sub

    Private Sub Grid_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        If GetParentForm().ActiveControl Is Nothing Then
            Return
        End If

        RowColChange()

    End Sub

    ''' <summary>
    ''' カレント行を削除します。
    ''' </summary>
    ''' <returns>削除した場合はtrue。それ以外の場合はfalse。</returns>
    ''' <remarks></remarks>
    Public Function Delete() As Boolean
        If GridControl.AddNewMode = AddNewModeEnum.AddNewCurrent Then
            Return False
        End If

        GridControl.SelectedRows.Add(GridControl.Row) '2007.10.10 行ハイライト

        If MessageBox.Show("行削除します。よろしいですか？", GetParentForm.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then

            GridControl.SelectedRows.Clear()    '2007.10.10 行ハイライト取消

            Return False
        End If

        '        CancelEditCell()

        If GridControl.AddNewMode = AddNewModeEnum.AddNewPending Then
            CancelEditRow()
            GridControl.Col = DefaultColumnPositionValue
            Return True
        Else

            CancelEditRow()

            GridControl.Delete()

            CType(GridControl.DataSource, System.Data.DataTable).DataSet.AcceptChanges()

            GridControl.Col = DefaultColumnPositionValue

            GridControl.SelectedRows.Clear()
        End If

        Return True

    End Function

    Private CurrentRowWasAddedByInsert As Boolean

    ''' <summary>
    ''' デフォルトのカラム位置に移動します。
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub MoveDefaultColumnPosition()
        GridControl.Col = DefaultColumnPosition
    End Sub

    Public Function Insert(ByVal position As Integer) As Boolean
        If GridControl.AddNewMode = AddNewModeEnum.AddNewCurrent Then
            Return False
        End If

        Dim f As IGridParentForm = CType(GetParentForm(), IGridParentForm)

        '↓2009.03.04 Upd kosaka
        'If GridControl.RowCount + 1 >= f.GetMaxRow Then
        If GridControl.RowCount + 1 > f.GetMaxRow Then
            '↑2009.03.04 Upd kosaka
            CommonUtility.WinForm.MessageBoxEx.Show(MessageCode_Arg1.M036行までしか入力できません, f.GetMaxRow.ToString, GetParentForm().Text)
            Return False
        End If

        Dim dt As System.Data.DataTable = CType(GridControl.DataSource, System.Data.DataTable)
        dt.DataSet.EnforceConstraints = False

        Dim row As System.Data.DataRow = dt.NewRow
        Dim eventArgs As New GridInitalizeInsertRowEventArgs
        eventArgs.NewDataRow = row
        OnInitalizeInsertRow(eventArgs)
        dt.Rows.InsertAt(row, position)
        GridControl.Row = position
        GridControl.Col = 0
        GridControl.EditActive = True

        'CurrentRowWasAddedByInsert = True

        GridControl.Col = DefaultColumnPosition
        Return True

    End Function

    Public Function Insert() As Boolean
        Return Insert(GridControl.Row)
    End Function

    Public Function GetParentForm() As Form
        Return GridControl.FindForm()
    End Function

    Public Function TryUpdateCell() As Boolean
        If GridControl.EditActive = True Then
            GridControl.EditActive = False
            If GridControl.EditActive = True Then
                Return False
            End If
        End If
        Return True
    End Function

    Public Function TryUpdateRow() As Boolean
        If TryUpdateCell() = False Then
            Return False
        End If

        If GridControl.DataChanged = True Then
            GridControl.UpdateData()
            If GridControl.DataChanged = True Then
                Return False
            End If

        End If

        Return True
    End Function

    Private cancelEditAvtive As Boolean = False

    'Protected Sub CancelEditCell()
    '    cancelEditAvtive = True
    '    GridControl.EditActive = False
    '    cancelEditAvtive = False
    'End Sub

    Public Sub CancelEditRow()
        cancelEditAvtive = True
        GridControl.DataChanged = False
        cancelEditAvtive = False
    End Sub

    Private UseMaxGyoCheckValue As Boolean

    Public Property UseMaxGyoCheck() As Boolean
        Get
            Return UseMaxGyoCheckValue
        End Get
        Set(ByVal value As Boolean)
            UseMaxGyoCheckValue = value
        End Set
    End Property


End Class