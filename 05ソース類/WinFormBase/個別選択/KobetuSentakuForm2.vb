Public Class KobetuSentakuForm2
    Implements Model.IKobetuSentakuKey, Model.IKobetuSentakuResult

    Private ItemSelectedValue As Boolean
    Private intCol As Integer = 0
    Private strSort As String = ""

    'DBGrid列番号
    Private Enum COL
        CHKARIA = 0     'チェック
        CODE = 1        'コード
        MENUKEY = 2
        NAME = 3        '名
    End Enum

    Public Property ItemSelected() As Boolean Implements Model.IKobetuSentakuResult.ItemSelected
        Get
            Return ItemSelectedValue
        End Get
        Set(ByVal value As Boolean)
            ItemSelectedValue = value
        End Set
    End Property

    Private SelectDataSetValue As DataTable

    ''' <summary>
    ''' 内容を保存するデータセットです。
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SelectDataSet() As DataTable
        Get
            Return SelectDataSetValue
        End Get
        Set(ByVal value As DataTable)
            SelectDataSetValue = value
        End Set
    End Property

    Private WorkTablePCNAMEvalue As String
    Private WorkTablePGCODEvalue As String
    Private WorkTableFULINOvalue As Integer

    Public Property WorkTableFULINO() As Integer Implements Model.IKobetuSentakuKey.FULINOKey
        Get
            Return WorkTableFULINOvalue
        End Get
        Set(ByVal value As Integer)
            WorkTableFULINOvalue = value
        End Set
    End Property

    Public Property WorkTablePCNAME() As String Implements Model.IKobetuSentakuKey.PCNAMEKey
        Get
            Return WorkTablePCNAMEvalue
        End Get
        Set(ByVal value As String)
            WorkTablePCNAMEvalue = value
        End Set
    End Property

    Public Property WorkTablePGCODE() As String Implements Model.IKobetuSentakuKey.PGCODEKey
        Get
            Return WorkTablePGCODEvalue
        End Get
        Set(ByVal value As String)
            WorkTablePGCODEvalue = value
        End Set
    End Property

    Private masterLastClickedColumnValue As Integer = 0
    Private masterSortDirectionValue As String = ""

    ''' <summary>
    ''' 右側の一覧用の最後にクリックした列番号として使ってください
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property MasterLastClickedColumn() As Integer
        Get
            Return masterLastClickedColumnValue
        End Get
        Set(ByVal value As Integer)
            masterLastClickedColumnValue = value
        End Set
    End Property

    ''' <summary>
    ''' 右側の一覧のacsかdescかを保存する項目として使ってください
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property MasterSortDirection() As String
        Get
            Return masterSortDirectionValue
        End Get
        Set(ByVal value As String)
            masterSortDirectionValue = value
        End Set
    End Property

    Protected Overrides Sub Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MyBase.Form_Load(sender, e)

        'ファンクションキー
        FunctionKey.ClearAll()

        FunctionKey.SetItem(1, "終了", "終了", True)
        FunctionKey.SetItem(11, "全選択", "全選択", True)
        FunctionKey.SetItem(12, "全解除", "全解除", True)

        If DesignMode = False Then
            Using Cur As New CommonUtility.WinForm.WaitCursor
                MasterGridSetup()
                KobetuForm2GridSetup()
                LoadList()
            End Using
        End If

        Call VisibleControlChildButton(False)

        AddHandler btnア.Click, AddressOf BtnClick
        AddHandler btnカ.Click, AddressOf BtnClick
        AddHandler btnサ.Click, AddressOf BtnClick
        AddHandler btnタ.Click, AddressOf BtnClick
        AddHandler btnナ.Click, AddressOf BtnClick
        AddHandler btnハ.Click, AddressOf BtnClick
        AddHandler btnマ.Click, AddressOf BtnClick
        AddHandler btnヤ.Click, AddressOf BtnClick
        AddHandler btnラ.Click, AddressOf BtnClick
        AddHandler btnワ.Click, AddressOf BtnClick
        AddHandler btn他.Click, AddressOf BtnClick
        AddHandler btn全件.Click, AddressOf BtnClick

        AddHandler btna.Click, AddressOf aiueoClick
        AddHandler btni.Click, AddressOf aiueoClick
        AddHandler btnu.Click, AddressOf aiueoClick
        AddHandler btne.Click, AddressOf aiueoClick
        AddHandler btno.Click, AddressOf aiueoClick

        AddHandler txtMENUKEY.TextUpdated, AddressOf txtMENUKEY_TextUpdated
    End Sub

    Private Sub aiueoClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call Filtering(CType(sender, Control).Text)
        txtMENUKEY.Focus()
    End Sub

    Private Sub BtnClick(ByVal sender As System.Object, ByVal e As System.EventArgs)

        txtMENUKEY.Text = ""
        Select Case CType(sender, Control).Name
            Case btn他.Name, btn全件.Name
                VisibleControlChildButton(False)
            Case Else
                VisibleControlChildButton(True)
                Select Case CType(sender, Control).Name
                    Case btnア.Name : Call CaptionControlChildButton("ア", "イ", "ウ", "エ", "オ")
                    Case btnカ.Name : Call CaptionControlChildButton("カ", "キ", "ク", "ケ", "コ")
                    Case btnサ.Name : Call CaptionControlChildButton("サ", "シ", "ス", "セ", "ソ")
                    Case btnタ.Name : Call CaptionControlChildButton("タ", "チ", "ツ", "テ", "ト")
                    Case btnナ.Name : Call CaptionControlChildButton("ナ", "ニ", "ヌ", "ネ", "ノ")
                    Case btnハ.Name : Call CaptionControlChildButton("ハ", "ヒ", "フ", "ヘ", "ホ")
                    Case btnマ.Name : Call CaptionControlChildButton("マ", "ミ", "ム", "メ", "モ")
                    Case btnヤ.Name : Call CaptionControlChildButton("ヤ", "ユ", "ヨ")
                    Case btnラ.Name : Call CaptionControlChildButton("ラ", "リ", "ル", "レ", "ロ")
                    Case btnワ.Name : Call CaptionControlChildButton("ワ", "ヲ", "ン")
                End Select
        End Select

        'フィルタリング
        Filtering(sender)

        txtMENUKEY.Focus()
    End Sub

    Private Sub txtMENUKEY_TextUpdated(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim strFilter As String = "(1=1) "

        If CommonUtility.Utility.NUCheck(txtMENUKEY.Text) = False Then strFilter += "and (MENUKEY like '%" & CommonUtility.Utility.EscapeLikeExpressionDS(txtMENUKEY.Text) & "%') "

        CType(dbgMaster.DataSource, DataTable).DefaultView.RowFilter = strFilter
    End Sub

    Private Sub Filtering(ByVal s As String)
        Dim strFilter As String = "(1=1) "

        strFilter += "and  (MENUKEY like '" + s + "%')"

        If (CommonUtility.Utility.NUCheck(txtMENUKEY.Text) = False) Then strFilter += "and (MENUKEY like '%" & CommonUtility.Utility.EscapeLikeExpressionDS(txtMENUKEY.Text) & "%') "
        CType(dbgMaster.DataSource, DataTable).DefaultView.RowFilter = strFilter

    End Sub

    Private Sub Filtering(ByVal sender As System.Object)

        Dim strFilter As String = "(1=1) "
        Select Case CType(sender, Control).Name
            Case btnア.Name : strFilter += "and  (MENUKEY >= 'ｱ') and (MENUKEY < 'ｶ')"
            Case btnカ.Name : strFilter += "and  (MENUKEY >= 'ｶ') and (MENUKEY < 'ｻ')"
            Case btnサ.Name : strFilter += "and  (MENUKEY >= 'ｻ') and (MENUKEY < 'ﾀ')"
            Case btnタ.Name : strFilter += "and  (MENUKEY >= 'ﾀ') and (MENUKEY < 'ﾅ')"
            Case btnナ.Name : strFilter += "and  (MENUKEY >= 'ﾅ') and (MENUKEY < 'ﾊ')"
            Case btnハ.Name : strFilter += "and  (MENUKEY >= 'ﾊ') and (MENUKEY < 'ﾏ')"
            Case btnマ.Name : strFilter += "and  (MENUKEY >= 'ﾏ') and (MENUKEY < 'ﾔ')"
            Case btnヤ.Name : strFilter += "and  (MENUKEY >= 'ﾔ') and (MENUKEY < 'ﾗ')"
            Case btnラ.Name : strFilter += "and  (MENUKEY >= 'ﾗ') and (MENUKEY < 'ﾜ')"
            Case btnワ.Name : strFilter += "and  (MENUKEY >= 'ﾜ') and (MENUKEY < 'ﾝ')"
            Case btn他.Name : strFilter += "and  (MENUKEY <  'ｱ')  or (MENUKEY >='ﾝ')"
            Case btn全件.Name : strFilter += ""
        End Select

        If (CommonUtility.Utility.NUCheck(txtMENUKEY.Text) = False) Then strFilter += "and (MENUKEY like '%" & CommonUtility.Utility.EscapeLikeExpressionDS(txtMENUKEY.Text) & "%') "
        CType(dbgMaster.DataSource, DataTable).DefaultView.RowFilter = strFilter

    End Sub

    Private Sub VisibleControlChildButton(ByVal visible As Boolean)
        btna.Visible = visible
        btni.Visible = visible
        btnu.Visible = visible
        btne.Visible = visible
        btno.Visible = visible
    End Sub

    Private Sub CaptionControlChildButton(ByVal a As String, ByVal u As String, ByVal o As String)
        CaptionControlChildButton(a, "", u, "", o)
    End Sub

    Private Sub CaptionControlChildButton(ByVal a As String, ByVal i As String, ByVal u As String, ByVal e As String, ByVal o As String)
        With btna
            .Text = a
            .Visible = (CommonUtility.Utility.NUCheck(a) = False)
        End With
        With btni
            .Text = i
            .Visible = (CommonUtility.Utility.NUCheck(i) = False)
        End With
        With btnu
            .Text = u
            .Visible = (CommonUtility.Utility.NUCheck(u) = False)
        End With
        With btne
            .Text = e
            .Visible = (CommonUtility.Utility.NUCheck(e) = False)
        End With
        With btno
            .Text = o
            .Visible = (CommonUtility.Utility.NUCheck(o) = False)
        End With
    End Sub

    ''' <summary>
    ''' ファンクションキー押下時の処理を記述します。
    ''' </summary>
    ''' <param name="sender">ファンクションキーコントロール</param>
    ''' <param name="e">FunctionKeyEventArgsパラメータ</param>
    ''' <remarks>FunctionKeyEventArgs.Nameプロパティを参照して処理を振り分けます。</remarks>
    Protected Overrides Sub FunctionKeyAction(ByVal sender As Object, ByVal e As CommonUtility.WinFormControls.FunctionKeyEventArgs)

        MyBase.FunctionKeyAction(sender, e)

        Select Case e.Name
            Case "終了"
                Using Cur As New CommonUtility.WinForm.WaitCursor

                    'ワーク更新
                    UpdateWorkTable()

                    SelectDataSet.AcceptChanges()

                    If SelectDataSet.Select("CHKARIA=-1").Length = 0 Then
                        ItemSelected = False
                    Else
                        ItemSelected = True
                    End If

                End Using

                DialogResult = Windows.Forms.DialogResult.OK

            Case "全選択"
                Dim dt As DataTable = CType(dbgMaster.DataSource, DataTable)
                For Each row As DataRow In dt.Rows
                    row("CHKARIA") = -1
                Next
                'dbgMaster.Rebind(True)
                LastFocusedControl.Focus()
            Case "全解除"
                Dim dt As DataTable = CType(dbgMaster.DataSource, DataTable)
                For Each row As DataRow In dt.Rows
                    row("CHKARIA") = 0
                Next
                'dbgMaster.Rebind(True)
                LastFocusedControl.Focus()
        End Select
    End Sub

    ''' <summary>
    ''' グリッドの項目設定等を行ってください。
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overridable Sub MasterGridSetup()

        With dbgMaster

            With .Columns
                .Add(New C1.Win.C1TrueDBGrid.C1DataColumn("", "CHKARIA", Type.GetType("System.Int32")))
                .Add(New C1.Win.C1TrueDBGrid.C1DataColumn("", CodeNameField, Type.GetType("System.String")))
                .Add(New C1.Win.C1TrueDBGrid.C1DataColumn("", "MENUKEY", Type.GetType("System.String")))
                .Add(New C1.Win.C1TrueDBGrid.C1DataColumn("", NameField, Type.GetType("System.String")))
            End With

            With .Splits(0)
                .DisplayColumns(COL.CHKARIA).Width = 40
                .DisplayColumns(COL.CODE).Width = 72
                .DisplayColumns(COL.MENUKEY).Width = 80
                .DisplayColumns(COL.NAME).Width = 320
                For i As Integer = 0 To dbgMaster.Columns.Count - 1
                    .DisplayColumns(i).Visible = True
                Next
            End With

            .Columns(COL.CHKARIA).Caption = "選択"
            .Columns(COL.CODE).Caption = "コード"
            .Columns(COL.MENUKEY).Caption = "カナ"
            .Columns(COL.NAME).Caption = NameStr()


            With .Splits(0)
                .DisplayColumns(COL.CHKARIA).AllowFocus = True
                .DisplayColumns(COL.CODE).AllowFocus = False
                .DisplayColumns(COL.MENUKEY).AllowFocus = False
                .DisplayColumns(COL.NAME).AllowFocus = False

                .VScrollBar.Style = C1.Win.C1TrueDBGrid.ScrollBarStyleEnum.Always
                .HScrollBar.Style = C1.Win.C1TrueDBGrid.ScrollBarStyleEnum.Automatic
            End With

        End With

    End Sub

    Protected Overridable Sub KobetuForm2GridSetup()

        'チェックボックス
        dbgMaster.Columns(COL.CHKARIA).ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox

        '最後にGridSetupを呼び出す

        GridSetup(dbgMaster, GridSetupAllows.AllowUpdate, True, False, False)

    End Sub

    ''' <summary>
    ''' 選択ワークテーブルにおけるキー項目の名前を指定してください 例 WT_SENCLSならCLASSCODE
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Overridable Function CodeNameField() As String
        Throw New NotImplementedException("実装してください")
    End Function
    Protected Overridable Function NameField() As String
        Throw New NotImplementedException("実装してください")
    End Function
    Protected Overridable Function NameStr() As String
        Throw New NotImplementedException("実装してください")
    End Function

    ''' <summary>
    ''' ワークテーブル更新に使うリモートファサードを返してください
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Overridable Function UpdateMethod() As BLL.Common.IBusinessLogic
        Throw New NotImplementedException("実装してください")
    End Function

    ''' <summary>
    ''' リストを読み込むリモートファサードを返してください
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Overridable Function WorkLoadMethod() As BLL.Common.IBusinessLogic
        Throw New NotImplementedException("実装してください")
    End Function

    Protected Sub UpdateWorkTable()
        Dim logic As BLL.Common.IBusinessLogic = UpdateMethod()

        Dim dt As DataTable = CommonUtility.KobetuSentakuUtility.MakeSentakuUpdateDataTable(CodeNameField, SelectDataSet, False)

        Dim requestParam As New Model.DTO.RequestSentakuUpdate(WorkTablePCNAME, WorkTablePGCODE, WorkTableFULINO, dt)
        logic.Update(requestParam)

    End Sub

    Private Sub LoadList()
        Dim logic As BLL.Common.IBusinessLogic = WorkLoadMethod()

        Dim requestParam As New BLL.Common.DTO.RequestSentakuKey(WorkTablePCNAME, WorkTablePGCODE, WorkTableFULINO)
        Dim responseParam As DataTable = logic.GetList(requestParam)

        SelectDataSet = responseParam
        dbgMaster.SetDataBinding(responseParam, "", True) 'gridにバインド

    End Sub

    Private Sub txtMENUKEY_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles txtMENUKEY.PreviewKeyDown
        If e.KeyCode = Keys.Return Then
            dbgMaster.Focus()
        End If
    End Sub

End Class