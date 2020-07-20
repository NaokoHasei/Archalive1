Imports GrapeCity.ActiveReports
Imports CommonUtility.WinForm
Imports CommonUtility.WinFormControls
Imports System.Security.Permissions
Imports System.Drawing
Imports System.Threading

Public Class FormBase

    Implements ILastFocusedControl

    Private log As OperationLog.OutPutLog

    Private Const COLOR_EVENROW As Integer = &HC0C0FF      '偶数行
    Private Const COLOR_ODD_ROW As Integer = &HFFFFFF      '奇数行

    '個別選択ボタン 表示色
    Private Const COLOR_SENCOL_ON As Integer = &HFF0000&            '赤
    Private COLOR_SENCOL_OFF As Color = SystemColors.ControlText    '黒

    Private tabOrder As FlatTabIndex
    Private UserAuthorityCodeValue As Integer
    Private GetServerDateValue As Date
    Private TantoCodeValue As String
    Private PassWordValue As String
    Private CommandLineArgsValue() As String

    Protected ReadOnly Property PCNAME() As String
        Get
            Return Environment.MachineName
        End Get
    End Property

    Protected ReadOnly Property SENCOL_ON() As Color
        Get
            Return Color.FromArgb(COLOR_SENCOL_ON)
        End Get
    End Property

    Protected ReadOnly Property SENCOL_OFF() As Color
        Get
            Return COLOR_SENCOL_OFF
        End Get
    End Property

    Protected ReadOnly Property ServerDate() As Date
        Get
            If IsDate(Format(GetServerDateValue, "yyyy/MM/dd")) Then
                Return GetServerDateValue
            Else
                GetServerDate()
                Return GetServerDateValue
            End If
        End Get
    End Property

    Private Sub GetServerDate()
        Dim logic As New BLL.Common.GetDate
        GetServerDateValue = logic.GetServerDate()
    End Sub

    Private NowUserValue As BLL.Common.dsM_NOWUSER
    Private S_SYSTEMValue As BLL.Common.dsS_SYSTEM

    Protected ReadOnly Property NowUserInfo() As BLL.Common.dsM_NOWUSER.M_NOWUSERRow
        Get
            If NowUserValue Is Nothing Then
                GetNowUser()
            End If
            Return NowUserValue.M_NOWUSER(0)
        End Get
    End Property

    Private Sub GetNowUser()
        If DesignMode = False Then
            Dim logic As New BLL.Common.GetNowUserInfo(PCNAME)
            NowUserValue = logic.GetM_NOWUSER
            If NowUserValue.HasValue Then
                TantoCodeValue = NowUserValue.M_NOWUSER(0).TANTOCODE
                PassWordValue = NowUserValue.M_NOWUSER(0).PASSWORD
            Else
                Throw New ApplicationException("ログインユーザー取得不可")
            End If
        End If
    End Sub

    Private Sub LoadMessageInfo()

        Dim mi As New MessageBase
        Dim messageInfoValue As BLL.Common.dsS_MESSAGE = mi.MessageInfo

        If messageInfoValue.HasValue = False Then
            Throw New ApplicationException("メッセージマスタが登録されていません")
        End If

        Dim ins As New MessageBoxEx

        For Each row As BLL.Common.dsS_MESSAGE.S_MESSAGEViewRow In messageInfoValue.S_MESSAGEView.Rows
            ins = New MessageBoxEx(row.MSGCODE, row.BUTTONS, row.MESSAGE)
        Next

    End Sub

    ''' <summary>
    ''' Enter押下時に次のコントロールにフォーカスを移します。
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub ProcessEnterKey(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If (e.KeyCode = Keys.Enter) Then
            ProcessTabKey(True)
        End If
    End Sub

    Public Overridable Function PROGRAM_ID() As String
        Return ""
    End Function

    Public Overridable Function PROGRAM_NAME() As String
        Return ""
    End Function

    <Browsable(False)>
    Public ReadOnly Property TANTO_CODE() As String
        Get
            Return TantoCodeValue
            'Return "1"
        End Get
    End Property

    <Browsable(False)>
    Public ReadOnly Property PASSWORD() As String
        Get
            Return PassWordValue
        End Get
    End Property

    Public Overridable Function IsChildForm() As Boolean
        Return False
    End Function

    ''' <summary>
    ''' フォームロード時の処理を記述してください
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Overridable Sub Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub FormBase_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        CommandLineArgsValue = System.Environment.GetCommandLineArgs()

        Try

            Using cur As New WaitCursor

                If DesignMode = False Then

                    System.Data.SqlClient.SqlConnection.ClearAllPools()

                    'タブオーダー取得
                    tabOrder = New FlatTabIndex(Me)

                    'ラストフォーカスコントロール設定
                    LostFocusHandler()

                    Me.TitleBar.Title = PROGRAM_NAME()
                    Me.Text = PROGRAM_NAME()

                    'システム日付取得
                    Call GetServerDate()

                    'メッセージ情報取得
                    Call LoadMessageInfo()

                    If PROGRAM_ID() <> "USERPASS" Then
                        Call GetNowUser()
                        '#If DEBUG = False Then
                        '                        Call GetJIKOUKBN
                        '#End If
                    End If

                End If

                'ファンクションキー
                AddHandler FunctionKey.Action, AddressOf FunctionKeyAction
                For i As Integer = 1 To 12
                    FunctionKey.SetItem(i, "", "", False)
                Next

                Form_Load(sender, e)

                Me.TitleBar.ReadManualData(PROGRAM_ID)

                If DesignMode = False Then
                    'log.Write(PROGRAM_NAME() + "開始", OperationLog.OutPutLog.LogKind.Info)
                End If

                ' ThreadExceptionイベント・ハンドラを登録する
                AddHandler Application.ThreadException, AddressOf Application_ThreadException

                ' UnhandledExceptionイベント・ハンドラを登録する
                AddHandler System.Threading.Thread.GetDomain().UnhandledException, AddressOf Application_UnhandledException

            End Using

        Catch ex As Exception
            MessageBox.Show(ex.Message(), PROGRAM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End Try

    End Sub

    Private Sub FormBase_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed

        System.Data.SqlClient.SqlConnection.ClearAllPools()

        If DesignMode = False Then
            If log Is Nothing Then
                log = New OperationLog.OutPutLog("c:\typ\Application\", 0, PCNAME, TANTO_CODE, PROGRAM_ID)
                log.Write(PROGRAM_NAME() + "終了", OperationLog.OutPutLog.LogKind.Err)
            Else
                log.Write(PROGRAM_NAME() + "終了", OperationLog.OutPutLog.LogKind.Info)
            End If
        End If

        If dialogFlg Then
            ownerForm.Visible = True

            ownerForm.Top = Me.Top
            ownerForm.Left = Me.Left
            ownerForm.Activate()
        End If
    End Sub

    Private dialogFlg As Boolean = False
    Public ownerForm As FormBase

    Public Sub ShowDisp(ByVal form As FormBase)
        Me.Top = form.Top + 30
        Me.Left = form.Left + 30
        Me.StartPosition = FormStartPosition.Manual
        Me.Show()
    End Sub

    Public Sub ShowDispApplicationRun(ByVal form As FormBase)
        Me.Top = form.Top
        Me.Left = form.Left
        Me.StartPosition = FormStartPosition.Manual

        Application.EnableVisualStyles()
        Application.Run(Me)
    End Sub

    Public Sub ShowDispDialog(ByVal form As FormBase)
        Me.Top = form.Top
        Me.Left = form.Left
        Me.StartPosition = FormStartPosition.Manual

        dialogFlg = True
        ownerForm = form

        Me.Show()
        form.Visible = False
    End Sub

    ''' <summary>
    ''' タブオーダーを取得します
    ''' </summary>
    ''' <param name="control">タブオーダーを取得するコントロール</param>
    ''' <returns>タブオーダー</returns>
    ''' <remarks>VB.NETの階層的なタブオーダーではなくVB6ライクな連番のタブオーダーを取得します。</remarks>
    Public Function GetTabOrder(ByVal control As Control) As Integer
        Return tabOrder.GetTabIndex(control)
    End Function

    ''' <summary>
    ''' ファンクションキー押下時の処理を記述します。
    ''' </summary>
    ''' <param name="sender">ファンクションキーコントロール</param>
    ''' <param name="e">FunctionKeyEventArgsパラメータ</param>
    ''' <remarks>FunctionKeyEventArgs.Nameプロパティを参照して処理を振り分けます。</remarks>
    Protected Overridable Sub FunctionKeyAction(ByVal sender As System.Object, ByVal e As FunctionKeyEventArgs)

    End Sub

    Enum ColumnValueType
        String_
        Decimal_
        DateTime_
    End Enum

    Function getColumnValueType(ByVal type As ColumnValueType) As Type
        Select Case type
            Case ColumnValueType.String_
                Return GetType(String)
            Case ColumnValueType.Decimal_
                Return GetType(Decimal)
            Case ColumnValueType.DateTime_
                Return GetType(Date)
        End Select
        Return Nothing
    End Function

    ''' <summary>
    ''' グリッド設定（グリッド追加編）
    ''' </summary>
    ''' <param name="grid"></param>
    ''' <param name="DataPropertyName"></param>
    ''' <param name="Name"></param>
    ''' <param name="HeaderText"></param>
    ''' <remarks></remarks>
    Protected Sub GridSetup(ByVal ColumnType As DataGridViewTextBoxColumn, ByVal grid As DataGridView, ByVal isReadOnly As Boolean, ByVal DataPropertyName As String, ByVal Name As String, ByVal HeaderText As String, ByVal ValueType As ColumnValueType)
        With grid
            With ColumnType
                .ReadOnly = isReadOnly
                .DataPropertyName = DataPropertyName
                .Name = Name
                .HeaderText = HeaderText
                .ValueType = getColumnValueType(ValueType)
            End With
            .Columns.Add(ColumnType)
        End With
    End Sub

    ''' <summary>
    ''' グリッド設定（グリッド追加編）
    ''' </summary>
    ''' <param name="grid"></param>
    ''' <param name="DataPropertyName"></param>
    ''' <param name="Name"></param>
    ''' <param name="HeaderText"></param>
    ''' <remarks></remarks>
    Protected Sub GridSetup(ByVal ColumnType As DataGridViewCheckBoxColumn, ByVal grid As DataGridView, ByVal isReadOnly As Boolean, ByVal DataPropertyName As String, ByVal Name As String, ByVal HeaderText As String)
        With grid
            With ColumnType
                .ReadOnly = isReadOnly
                .DataPropertyName = DataPropertyName
                .Name = Name
                .HeaderText = HeaderText
                .ValueType = GetType(Boolean)
            End With
            .Columns.Add(ColumnType)
        End With
    End Sub

    ''' <summary>
    ''' グリッド設定（共通編）
    ''' </summary>
    ''' <param name="grid"></param>
    ''' <param name="allows"></param>
    ''' <remarks></remarks>
    Protected Sub GridSetup(ByVal grid As DataGridView, ByVal allows As GridSetupAllows)

        Dim isReadOnly As Boolean = False

        With grid

            If allows = GridSetupAllows.AllowAll Then
                .AllowUserToAddRows = True
                .AllowUserToDeleteRows = True
                .ReadOnly = False
            ElseIf allows = GridSetupAllows.AllowReadOnly Then
                .AllowUserToAddRows = False
                .AllowUserToDeleteRows = False
                .ReadOnly = True
            Else
                If (allows And GridSetupAllows.AllowAddNew) = GridSetupAllows.AllowAddNew Then
                    .AllowUserToAddRows = True
                Else
                    .AllowUserToAddRows = False
                End If
                If (allows And GridSetupAllows.AllowDelete) = GridSetupAllows.AllowDelete Then
                    .AllowUserToDeleteRows = True
                Else
                    .AllowUserToDeleteRows = False
                End If
                If (allows And GridSetupAllows.AllowUpdate) = GridSetupAllows.AllowUpdate Then
                    .ReadOnly = False
                End If

            End If

            .AllowUserToOrderColumns = False        '列の手動再配置を有効にするかどうかを示します
            .AllowUserToResizeRows = False          'ユーザーが行のサイズを変更できるかどうかを示します
            .AllowUserToResizeColumns = True        'ユーザーが列のサイズを変更できるかどうかを示します

            .ColumnHeadersHeight = 25
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing

            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None

            For intCol As Integer = 0 To .ColumnCount - 1

                .Columns(intCol).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

                .ScrollBars = ScrollBars.Both

                .Font = New Font("ＭＳ ゴシック", 11.25!, FontStyle.Regular, GraphicsUnit.Point, CType(128, Byte))

                .SelectionMode = DataGridViewSelectionMode.FullRowSelect

                If .Columns(intCol).ValueType.Name = "String" Then
                    .Columns(intCol).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                End If
                If .Columns(intCol).ValueType.Name = "Decimal" Then
                    .Columns(intCol).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Columns(intCol).DefaultCellStyle.Format = "#,##0"
                End If
                If .Columns(intCol).ValueType.Name = "DateTime" Then
                    .Columns(intCol).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                End If
            Next

            .RowHeadersWidth = 25
            .RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
            .MultiSelect = False

            .AlternatingRowsDefaultCellStyle.BackColor = Drawing.Color.LightBlue
            .AlternatingRowsDefaultCellStyle.BackColor = Drawing.ColorTranslator.FromHtml("&HC0C0FF")

#If DEBUG Then
            'Dim x As Integer = .RowHeadersWidth
            'For intCol As Integer = 0 To .ColumnCount - 1
            '    If .Columns(intCol).Visible Then
            '        x += .Columns(intCol).Width + 1
            '    End If
            'Next
            'If x <> .Width Then
            '    MessageBox.Show("列の幅とコントロールの幅が一致していません。GridコントロールのWidthを" & x & "(現在の値は" & .Width & ")に設定してください。Dock=fillの場合は親のサイズを変更するかDock解除してください")
            'End If
#End If

        End With

    End Sub

    ''' <summary>
    ''' グリッドの初期化を行います。
    ''' </summary>
    ''' <param name="grid">初期化するグリッド</param>
    ''' <param name="allows">AllowAddNew,AllowDelete,AllowUpdateを指定します。AllowAddNew,AllowDelete,AllowUpdateをorで繋げるかAllowReadOnlyまたはAllowAllを指定して下さい。</param>
    ''' <param name="isMovable">グリッドのヘッダー可動の場合true。それ以外の場合false</param>
    ''' <param name="isMultiRowSelect">複数行選択可能の場合true。それ以外の場合false</param>
    ''' <param name="isMultiRow">2段表示の場合true。1段表示の場合false</param>
    ''' <remarks>固有の初期化の後GridSetupを呼び出します。</remarks>
    Protected Sub GridSetup(ByVal grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal allows As GridSetupAllows, ByVal isMovable As Boolean, ByVal isMultiRowSelect As Boolean, ByVal isMultiRow As Boolean)
        If isMultiRow = False Then
            GridSetup(grid, allows, isMovable, isMultiRowSelect, 1)
        Else
            GridSetup(grid, allows, isMovable, isMultiRowSelect, 2)
        End If
    End Sub

    Protected Enum GridSetupAllows
        AllowAddNew = 1
        AllowDelete = 2
        AllowUpdate = 4
        AllowReadOnly = 8
        AllowAll = 16
    End Enum

    ''' <summary>
    ''' グリッドの初期化を行います。
    ''' </summary>
    ''' <param name="grid">初期化するグリッド</param>
    ''' <param name="allows">AllowAddNew,AllowDelete,AllowUpdateを指定します。AllowAddNew,AllowDelete,AllowUpdateをorで繋げるかAllowReadOnlyまたはAllowAllを指定して下さい。</param>
    ''' <param name="isMovable">グリッドのヘッダー可動の場合true。それ以外の場合false</param>
    ''' <param name="isMultiRowSelect">複数行選択可能の場合true。それ以外の場合false</param>
    ''' <param name="LinesPerRow">1行の段数</param>
    ''' <remarks>固有の初期化の後GridSetupを呼び出します。</remarks>
    Protected Sub GridSetup(ByVal grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal allows As GridSetupAllows, ByVal isMovable As Boolean, ByVal isMultiRowSelect As Boolean, ByVal LinesPerRow As Integer)
        Dim isReadOnly As Boolean
        Dim intSplitsCount As Integer

        With grid

#If DEBUG Then

            If .DataView = C1.Win.C1TrueDBGrid.DataViewEnum.MultipleLinesFixed Then
                Throw New ApplicationException("2行表示の設定はGridSetupに移りました。DataViewの設定を削除してください")
            End If

            If .LinesPerRow = 2 Then
                Throw New ApplicationException("2行表示の設定はGridSetupに移りました。LinesPerRowの設定を削除してください")
            End If

#End If

            '線の幅だけ誤差が生じるので設定なしにしておく
            '.BorderStyle = BorderStyle.FixedSingle
            .VScrollBar.Style = C1.Win.C1TrueDBGrid.ScrollBarStyleEnum.Always
            If LinesPerRow <> 1 Then
                .DataView = C1.Win.C1TrueDBGrid.DataViewEnum.MultipleLinesFixed
                .LinesPerRow = LinesPerRow
            Else
                .DataView = C1.Win.C1TrueDBGrid.DataViewEnum.Normal
                .LinesPerRow = LinesPerRow
            End If

            '.HeadingStyle.BackColor = Color.FromArgb(&HBF&)
            '.HeadingStyle.ForeColor = Color.White
            '.RecordSelectorStyle.BackColor = SystemColors.Control
            '***** 全般 *****
            If allows = GridSetupAllows.AllowAll Then
                .AllowAddNew = True                     '新規レコード追加可能(True:可，False:不可)
                .AllowDelete = True                     'レコード削除可能　　(True:可，False:不可)
                .AllowUpdate = True                     'レコード更新可能　　(True:可，False:不可)
            ElseIf allows = GridSetupAllows.AllowReadOnly Then
                .AllowAddNew = False                     '新規レコード追加可能(True:可，False:不可)
                .AllowDelete = False                     'レコード削除可能　　(True:可，False:不可)
                .AllowUpdate = False                     'レコード更新可能　　(True:可，False:不可)
            Else
                If (allows And GridSetupAllows.AllowAddNew) = GridSetupAllows.AllowAddNew Then
                    .AllowAddNew = True
                Else
                    .AllowAddNew = False
                End If
                If (allows And GridSetupAllows.AllowDelete) = GridSetupAllows.AllowDelete Then
                    .AllowDelete = True
                Else
                    .AllowDelete = False
                End If
                If (allows And GridSetupAllows.AllowUpdate) = GridSetupAllows.AllowUpdate Then
                    .AllowUpdate = True
                Else
                    .AllowUpdate = False
                End If
            End If
            If .AllowAddNew = False AndAlso .AllowDelete = False AndAlso .AllowUpdate = False Then
                isReadOnly = True
            Else
                isReadOnly = False
            End If

            .AllowSort = False

            .AllowColMove = False                                                                           '列移動
            .AllowColSelect = False                                                                         '列選択
            .AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None                                        '行サイズの変更
            .AllowRowSelect = True                                                                          '行選択
            .EditDropDown = False                                                                           '編集にドロップダウンウインドウを使用するか？
            .Enabled = True                                                                                 'イベントの認識
            .MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None                                         '行の選択方法を設定(複数行選択設定)
            .DirectionAfterEnter = C1.Win.C1TrueDBGrid.DirectionAfterEnterEnum.MoveRight                    'ユーザーが［Enter］キーを押したときに移動する次のセルの相対的な位置を指定します

            '複数選択
            If isMultiRowSelect = True Then
                .MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.Simple
            Else
                .MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
            End If

            '***** 表示 *****
            .FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard                                          'フラットスタイル
            .BorderStyle = BorderStyle.FixedSingle                                                          'グリッドの境界線スタイル
            .RowDivider.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.None                                      '行の境界線スタイル
            .RowHeight = 30                                                                                 'グリッドの行の高さ
            .Style.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
            .AlternatingRows = True
            .EvenRowStyle.BackColor = Drawing.ColorTranslator.FromHtml("&HFFEEFF")
            .OddRowStyle.BackColor = Color.FromArgb(COLOR_ODD_ROW)
            '***** キーボード *****
            .AllowArrows = True                                                                             '矢印キーを使用可能
            .TabAcrossSplits = True                                                                         'スプリットの境界をこえてTABを有効にする
            .WrapCellPointer = True                                                                         '行の境界での移動キーの動作を設定
            .ExposeCellMode = C1.Win.C1TrueDBGrid.ExposeCellModeEnum.ScrollOnSelect                         '表示されている一番右のセルをクリックしたときの動作
            .TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.GridNavigation                                   'タブキーの動作キーの動作

            .HeadingStyle.Font = New Font("メイリオ", 9)

            For intSplitsCount = 0 To .Splits.Count - 1

                '***** Splits 単位 *****
                .Splits(intSplitsCount).VScrollBar.Style = C1.Win.C1TrueDBGrid.ScrollBarStyleEnum.Always
                .Splits(intSplitsCount).AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None             'スプリットのサイズ変更
                .Splits(intSplitsCount).AllowVerticalSizing = False
                .Splits(intSplitsCount).AllowFocus = True                                                   'スプリットのフォーカス取得
                .Splits(intSplitsCount).ColumnCaptionHeight = 30                                            'ヘッダーの高さ
                .Splits(intSplitsCount).Locked = False                                                      'スプリットのロック
                If isReadOnly = True Then
                    .Splits(intSplitsCount).MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow     'スプリットのﾏｰｷｰｽﾀｲﾙ(選択行・セルの設定)
                Else
                    .Splits(intSplitsCount).MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor   'スプリットのﾏｰｷｰｽﾀｲﾙ(選択行・セルの設定)
                End If

                .Splits(intSplitsCount).HeadingStyle.WrapText = False                                       'ヘッダー項目折り返し
                .Splits(intSplitsCount).HeadingStyle.BackColor = Color.DarkSlateBlue
                .Splits(intSplitsCount).HeadingStyle.ForeColor = Color.White

                'ｽﾌﾟﾘｯﾄのｻｲｽﾞ変更
                If isMovable = True Then
                    .Splits(intSplitsCount).HScrollBar.Style = C1.Win.C1TrueDBGrid.ScrollBarStyleEnum.Always
                Else
                    .Splits(intSplitsCount).HScrollBar.Style = C1.Win.C1TrueDBGrid.ScrollBarStyleEnum.None
                End If

            Next

        End With

        With grid

            For intSplitsCount = 0 To .Splits.Count - 1

                For i As Integer = 0 To .Columns.Count - 1
#If DEBUG Then
                    If .Splits(intSplitsCount).DisplayColumns(i).AllowSizing = False Then
                        Throw New ApplicationException(".Splits.DisplayColumns.AllowSizingはGridSetupで制御しています。個々のFrom上の指定は削除してください")
                    End If
#End If
                    .Splits(intSplitsCount).DisplayColumns(i).Style.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center

                    If .Splits(intSplitsCount).DisplayColumns(i).Visible = False Then
                        .Splits(intSplitsCount).DisplayColumns(i).AllowSizing = False       '列変更
                    Else
                        .Splits(intSplitsCount).DisplayColumns(i).AllowSizing = isMovable   '列変更
                    End If
                    If .Columns(i).DataType.FullName = "System.Decimal" Then
                        .Splits(intSplitsCount).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                        .Splits(intSplitsCount).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                    Else
                        .Splits(intSplitsCount).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
                        .Splits(intSplitsCount).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
                    End If
                    If (isMovable = False) Then '列変更できない時はﾍｯﾀﾞｰ部はｾﾝﾀｰ揃え
                        .Splits(intSplitsCount).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    End If
                    'チェックボックスの場合はセンター揃え
                    If .Columns(i).ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox Then
                        .Splits(intSplitsCount).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                        .Splits(intSplitsCount).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    End If
                Next

            Next

            For intSplitsCount = 0 To .Splits.Count - 1

                'ロックプロパティ
                For i As Integer = 0 To .Columns.Count - 1
#If DEBUG Then
                    If .Splits(intSplitsCount).DisplayColumns(i).Locked = True Then
                        Throw New ApplicationException(".Splits.DisplayColumns.LockedはGridSetupで制御しています。個々のFrom上の指定は削除してください")
                    End If
#End If
                    If .Splits(intSplitsCount).DisplayColumns(i).AllowFocus = True Then
                        .Splits(intSplitsCount).DisplayColumns(i).Locked = False
                    Else
                        .Splits(intSplitsCount).DisplayColumns(i).Locked = True
                    End If
                Next

                'チェックボックス設定
                For i As Integer = 0 To .Columns.Count - 1
                    If .Columns(i).ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox Then
                        .Columns(i).ValueItems.Values.Clear()
                        .Columns(i).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("0", False))            ' unchecked - 未チェック
                        .Columns(i).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("-1", True))             ' checked - チェック
                        .Columns(i).ValueItems.Translate = True

                    End If
                Next

            Next
        End With

    End Sub

    Dim lastFocusedControlValue As Control

    ''' <summary>
    ''' 最後にフォーカスのあったコントロールを返します。
    ''' </summary>
    ''' <value></value>
    ''' <returns>最後にフォーカスのあったコントロール</returns>
    ''' <remarks>UseSearchMenuで登録したコントロールのみ対象です。</remarks>
    <Browsable(False)>
    Public Property LastFocusedControl() As Control
        Get
            Return lastFocusedControlValue
        End Get
        Set(ByVal value As Control)
            lastFocusedControlValue = value
        End Set
    End Property

    Private Sub traceLastFocusedControl(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LastFocusedControl = CType(sender, Control)
        'Debug.Print(CType(sender, Control).Name)
    End Sub

    ''' <summary>
    ''' 検索ボタンを使用するコントロールを登録します。
    ''' </summary>
    ''' <param name="control">検索ボタンを使用するコントロール</param>
    ''' <remarks>LastFocusedControlを使用するために必要です。</remarks>
    Protected Sub UseSearchMenu(ByVal control As Control)
        AddHandler control.Enter, AddressOf traceLastFocusedControl
        '        AddHandler control.Leave, AddressOf traceLastFocusedControl

    End Sub

    Public Sub EnableFunctionKey(ByVal control As Control, ByVal name As String)
        Dim functionOperation1 As FunctionKeyEnableWithEnterEvent = New FunctionKeyEnableWithEnterEvent(FunctionKey, control, name)

    End Sub

    Public Sub EnableFunctionKey_AllFalse(ByVal name As String)
        '全コントロールのEnterイベントをハンドル
        Dim AllControls As List(Of Control) = CommonUtility.WinForm.WinFormUtility.GetAllControl(Me)

        For Each c As Control In AllControls
            Dim blnflg As Boolean = False
            If TypeOf c Is TextBoxEx Then
                If TypeOf c.Parent Is TypComboBox = False Then
                    blnflg = True
                End If
            End If
            If TypeOf c Is TypComboBox Then
                blnflg = True
            End If
            If TypeOf c Is DateTextBoxEx Then
                blnflg = True
            End If
            If TypeOf c Is NumberTextBoxEx Then
                blnflg = True
            End If
            If TypeOf c Is Windows.Forms.RadioButton Then
                blnflg = True
            End If
            If TypeOf c Is Windows.Forms.CheckBox Then
                blnflg = True
            End If
            If TypeOf c Is C1.Win.C1TrueDBGrid.C1TrueDBGrid Then
                If TypeOf c.Parent Is TypComboBox = False Then
                    blnflg = True
                End If
            End If
            'If TypeOf c Is Windows.Forms.Button Then
            '    blnflg = True
            'End If
            If blnflg = True Then
                Dim f As FunctionKeyDisableWithEnterEvent = New FunctionKeyDisableWithEnterEvent(FunctionKey, c, name)
            End If
        Next

    End Sub

    Private Sub LostFocusHandler()
        '全コントロールのEnterイベントをハンドル
        Dim AllControls As List(Of Control) = CommonUtility.WinForm.WinFormUtility.GetAllControl(Me)

        For Each c As Control In AllControls
            Dim blnflg As Boolean = False
            If TypeOf c Is TextBoxEx Then
                If TypeOf c.Parent Is TypComboBox = False Then
                    blnflg = True
                End If
            End If
            If TypeOf c Is TypComboBox Then
                blnflg = True
            End If
            If TypeOf c Is DateTextBoxEx Then
                blnflg = True
            End If
            If TypeOf c Is NumberTextBoxEx Then
                blnflg = True
            End If
            If TypeOf c Is Windows.Forms.RadioButton Then
                blnflg = True
            End If
            If TypeOf c Is Windows.Forms.CheckBox Then
                blnflg = True
            End If
            If TypeOf c Is C1.Win.C1TrueDBGrid.C1TrueDBGrid Then
                If TypeOf c.Parent Is TypComboBox = False Then
                    blnflg = True
                End If
            End If
            'If TypeOf c Is Windows.Forms.Button Then
            '    blnflg = True
            'End If
            If blnflg = True Then
                AddHandler c.Enter, AddressOf traceLastFocusedControl
            End If
        Next

    End Sub

    Public Function GetLastFocusedControl() As System.Windows.Forms.Control Implements ILastFocusedControl.GetLastFocusedControl
        Return LastFocusedControl
    End Function

    ''' <summary>
    ''' コントロールの入力チェックを行います。
    ''' 対象コントロールのタブオーダーが引数のタブオーダーより大きいときのみチェックを行います。
    ''' </summary>
    ''' <param name="control">検証するコントロール</param>
    ''' <param name="tabOrder">タブオーダー値</param>
    ''' <returns>タブオーダー範囲外のため検証しなかった場合はTrue。検証に失敗した場合はFalse。検証に成功した場合はnullを返します</returns>
    ''' <remarks></remarks>
    Protected Function InputErrorCheck_Control(ByVal control As TextBoxEx, ByVal tabOrder As Integer) As Nullable(Of Boolean)
        If GetTabOrder(control) >= tabOrder Then
            Return New Nullable(Of Boolean)(True)
        End If

        If control.ValidateMe = False Then
            control.Focus()
            Return New Nullable(Of Boolean)(False)
        End If

        Return New Nullable(Of Boolean)()

    End Function

    ''' <summary>
    ''' コントロールの入力チェックを行います。
    ''' 対象コントロールのタブオーダーが引数のタブオーダーより大きいときのみチェックを行います。
    ''' </summary>
    ''' <param name="control">検証するコントロール</param>
    ''' <param name="tabOrder">タブオーダー値</param>
    ''' <returns>タブオーダー範囲外のため検証しなかった場合はTrue。検証に失敗した場合はFalse。検証に成功した場合はnullを返します</returns>
    ''' <remarks></remarks>
    Protected Function InputErrorCheck_Control(ByVal control As TypComboBox, ByVal tabOrder As Integer) As Nullable(Of Boolean)
        If GetTabOrder(control) >= tabOrder Then
            Return New Nullable(Of Boolean)(True)
        End If

        If control.ValidateMe = False Then
            control.Focus()
            Return New Nullable(Of Boolean)(False)
        End If

        Return New Nullable(Of Boolean)()

    End Function

    ''' <summary>
    ''' コントロールの入力チェックを行います。
    ''' 対象コントロールのタブオーダーが引数のタブオーダーより大きいときのみチェックを行います。
    ''' </summary>
    ''' <param name="control">検証するコントロール</param>
    ''' <param name="tabOrder">タブオーダー値</param>
    ''' <returns>タブオーダー範囲外のため検証しなかった場合はTrue。検証に失敗した場合はFalse。検証に成功した場合はnullを返します</returns>
    ''' <remarks></remarks>
    Protected Function InputErrorCheck_Control(ByVal control As DateTextBoxEx, ByVal tabOrder As Integer) As Nullable(Of Boolean)
        If GetTabOrder(control) >= tabOrder Then
            Return New Nullable(Of Boolean)(True)
        End If

        If control.ValidateMe = False Then
            control.Focus()
            Return New Nullable(Of Boolean)(False)
        End If

        Return New Nullable(Of Boolean)()

    End Function

    Protected Enum PrintReportMode
        Preview
        Print
        PDF
    End Enum

    Protected Sub PrintReport(
              ByVal mode As PrintReportMode _
            , ByVal rpt() As GrapeCity.ActiveReports.SectionReport _
            , Optional ByVal previewMode As Boolean = False _
            , Optional ByVal LongFileNameForPDF As Boolean = True)
        'デフォルトプリンター名を設定
        Dim pd As New Printing.PrintDocument
        Dim blnDefaultPrinterFlg As Boolean = False
        If rpt(0).Document.Printer.PrinterName = "" Then blnDefaultPrinterFlg = True
        If blnDefaultPrinterFlg Then rpt(0).Document.Printer.PrinterName = pd.PrinterSettings.PrinterName

        'B4設計のレポートはデフォルトプリンタに用紙サイズがあるか判定する
        If rpt(0).PageSettings.PaperKind = Drawing.Printing.PaperKind.B4 Then
            Dim blnFlg As Boolean = False
            For i As Integer = 0 To rpt(0).Document.Printer.PaperSizes.Count - 1
                If rpt(0).Document.Printer.PaperSizes.Item(i).Kind = Printing.PaperKind.B4 Then
                    blnFlg = True
                    Exit For
                End If
            Next
            If blnFlg = False Then
                For i As Integer = 0 To rpt(0).Document.Printer.PaperSizes.Count - 1
                    'B4サイズの判定 (14.33ｲﾝﾁ × 10.12ｲﾝﾁ)
                    If rpt(0).Document.Printer.PaperSizes.Item(i).Height = 1433 And rpt(0).Document.Printer.PaperSizes.Item(i).Width = 1012 Then
                        'サイズの一致する用紙を選択する
                        rpt(0).PageSettings.PaperName = rpt(0).Document.Printer.PaperSizes.Item(i).PaperName
                        rpt(0).PageSettings.PaperKind = rpt(0).Document.Printer.PaperSizes.Item(i).Kind
                        blnFlg = True
                        Exit For
                    End If
                Next
            End If
            If blnFlg = False Then  'B4をそれでも探す
                For i As Integer = 0 To rpt(0).Document.Printer.PaperSizes.Count - 1
                    'B4サイズの判定
                    If Microsoft.VisualBasic.Left(rpt(0).Document.Printer.PaperSizes.Item(i).PaperName, 2).ToUpper = "B4" Then
                        'サイズの一致する用紙を選択する
                        rpt(0).PageSettings.PaperName = rpt(0).Document.Printer.PaperSizes.Item(i).PaperName
                        rpt(0).PageSettings.PaperKind = rpt(0).Document.Printer.PaperSizes.Item(i).Kind
                        blnFlg = True
                        Exit For
                    End If
                Next
            End If
            If blnFlg = False Then
                '用紙サイズが存在しない場合は仮想プリンタにしておく
                If blnDefaultPrinterFlg Then rpt(0).Document.Printer.PrinterName = ""
            End If
        End If

        rpt(0).Document.Name = PROGRAM_NAME()
        rpt(0).Run()

        For idx = 1 To rpt.Length - 1
            rpt(idx).Document.Name = PROGRAM_NAME()
            rpt(idx).Run()

            For idx2 As Integer = 0 To rpt(idx).Document.Pages.Count - 1
                rpt(0).Document.Pages.Add(rpt(idx).Document.Pages(idx2).Clone())
            Next
        Next

        If mode = PrintReportMode.Preview Then
            Dim f As New WinFormBase.Preview
            f.Text = rpt(0).Document.Name
            f.Viewer1.Document = rpt(0).Document
            f.PDFFolderName = ""
            f.previewMode = previewMode

            f.ShowDialog()
        ElseIf mode = PrintReportMode.Print Then
            If blnDefaultPrinterFlg Then
                rpt(0).Document.Print(True, True, False)
            Else
                rpt(0).Document.Print(False, False, False)
            End If
        ElseIf mode = PrintReportMode.PDF Then
            Using pdfExport1 As New GrapeCity.ActiveReports.Export.Pdf.Section.PdfExport

                Dim strTimeStamp As String = Format(Now(), "yyyyMMdd_HHmmss")
                Dim strFolderName As String = "" 'InitialInfo.PDF_DIR
                Dim strFileTitle As String = PROGRAM_NAME()
                Dim strFileName As String = ""

                If LongFileNameForPDF Then
                    strFileName = strFolderName & "\" & strFileTitle & "_" & strTimeStamp & ".PDF"
                Else
                    strFileName = strFolderName & "\" & strFileTitle & ".PDF"
                End If
                pdfExport1.Export(rpt(0).Document, strFileName)

            End Using
        End If

    End Sub

    ''' <summary>
    ''' プログラムを起動させる
    ''' </summary>
    ''' <param name="Form">起動元ウィンドウ</param>
    ''' <param name="PROGRAM_NAME">起動元プログラム名</param>
    ''' <param name="strPgFilePath">起動対象プログラム名（ファイル名のみの場合、ｶﾚﾝﾄﾃﾞｨﾚｸﾄﾘを対象）</param>
    ''' <param name="blnWaitFlg">True:ﾌﾟﾛｸﾞﾗﾑ終了まで待つ　False:ﾌﾟﾛｸﾞﾗﾑの終了を待たない</param>
    ''' <param name="blnHideFlg">True:起動元プログラムを隠す　False:起動元プログラムを表示したままにする</param>
    ''' <param name="strHikisu">コマンドライン引数（省略可能）</param>
    ''' <remarks></remarks>
    Protected Sub gfncShell(ByVal Form As Form, ByVal PROGRAM_NAME As String, ByVal strPgFilePath As String, ByVal blnWaitFlg As Boolean, ByVal blnHideFlg As Boolean, Optional ByVal strHikisu As String = vbNullString)
        Dim CurrentDir As String = System.IO.Directory.GetCurrentDirectory()    'ｶﾚﾝﾄﾃﾞｨﾚｸﾄﾘ

        Using wcur As New WaitCursor
            'ﾃﾞｨﾚｸﾄﾘ指定がないときは、ｶﾚﾝﾄﾃﾞｨﾚｸﾄﾘとする。
            If InStr(strPgFilePath, "\") = 0 Then strPgFilePath = CurrentDir & "\" & strPgFilePath

            'ﾌﾟﾛｸﾞﾗﾑ存在ﾁｪｯｸ
            If System.IO.File.Exists(strPgFilePath) Then
                'ﾌﾟﾛｸﾞﾗﾑ起動
                Dim p As System.Diagnostics.Process = System.Diagnostics.Process.Start(strPgFilePath, strHikisu)
                If blnWaitFlg = True Then
                    '起動元ﾌｫｰﾑをHide
                    If blnHideFlg = True Then
                        Form.Hide()
                    End If
                    'ﾌﾟﾛｸﾞﾗﾑ終了待ち
                    p.WaitForExit()
                    '起動元ﾌｫｰﾑをShow
                    Form.Show()
                End If
            Else
                MessageBox.Show("ﾌｧｲﾙが見つかりません。", PROGRAM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End Using
    End Sub

    Protected Overrides ReadOnly Property CreateParams() As _
            System.Windows.Forms.CreateParams
        <SecurityPermission(SecurityAction.Demand,
            Flags:=SecurityPermissionFlag.UnmanagedCode)>
        Get
            Const CS_NOCLOSE As Integer = &H200
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ClassStyle = cp.ClassStyle Or CS_NOCLOSE

            Return cp
        End Get
    End Property

    <STAThread()>
    Shared Sub Main()
        ' ThreadExceptionイベント・ハンドラを登録する
        AddHandler Application.ThreadException, AddressOf Application_ThreadException

        ' UnhandledExceptionイベント・ハンドラを登録する
        AddHandler Thread.GetDomain().UnhandledException, AddressOf Application_UnhandledException

        ' メイン・スレッド以外の例外はUnhandledExceptionでハンドル
        'Dim buffer As String = "1"
        'Dim [error] As Char = buffer.Chars(2)

        ' ここで実行されるメイン・アプリケーション・スレッドの例外は
        ' Application_ThreadExceptionでハンドルできる
        'Application.Run(New Form1)
    End Sub

    ' 未処理例外をキャッチするイベント・ハンドラ
    ' （Windowsアプリケーション用）
    Public Shared Sub Application_ThreadException(ByVal sender As Object, ByVal e As ThreadExceptionEventArgs)
        MessageBox.Show(e.Exception.Message(), "システムエラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    ' 未処理例外をキャッチするイベント・ハンドラ
    ' （主にコンソール・アプリケーション用）
    Private Shared Sub Application_UnhandledException(ByVal sender As Object, ByVal e As UnhandledExceptionEventArgs)
        Dim ex As Exception = CType(e.ExceptionObject, Exception)
        If Not ex Is Nothing Then
            MessageBox.Show(e.ExceptionObject.Message(), "システムエラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
End Class

Public Class EnabledFunctionKeyAll
    Private TabIndices As Dictionary(Of Control, Integer)

    Private Function MakeList(ByVal parentControl As Control, ByVal index As Integer) As Integer
        Dim controlList As List(Of Control) = New List(Of Control)

        For Each c As Control In parentControl.Controls
            controlList.Add(c)
        Next

        For Each c As Control In controlList
            TabIndices.Add(c, index)



            index = MakeList(c, index)
        Next

        Return index

    End Function

    Public Sub New(ByVal parentControl As Control)
        TabIndices = New Dictionary(Of Control, Integer)

        TabIndices.Add(parentControl, 0)
        MakeList(parentControl, 1)
    End Sub

    Public Function GetTabIndex(ByVal control As Control) As Integer
        Return TabIndices(control)
    End Function

End Class