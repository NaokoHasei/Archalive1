Imports CommonUtility
Imports Model.DTO
Imports Model
Imports C1.Win.C1TrueDBGrid
Imports CommonUtility.WinForm

Public Class KobetuSentakuForm
    Implements Model.IKobetuSentakuKey, Model.IKobetuSentakuResult

    Private ItemSelectedValue As Boolean

    ''' <summary>
    ''' 項目が選択されたかされていないかを示します。
    ''' </summary>
    ''' <value></value>
    ''' <returns>項目が選択されている場合true。それ以外の場合false。</returns>
    ''' <remarks></remarks>
    Public Property ItemSelected() As Boolean Implements Model.IKobetuSentakuResult.ItemSelected
        Get
            Return ItemSelectedValue
        End Get
        Set(ByVal value As Boolean)
            ItemSelectedValue = value
        End Set
    End Property

    Private WorkTablePCNAMEvalue As String
    Private WorkTablePGCODEvalue As String
    Private WorkTableFULINOvalue As Integer

    ''' <summary>
    ''' 選択用ワークテーブルのキー(PCNAME)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property WorkTablePCNAME() As String Implements Model.IKobetuSentakuKey.PCNAMEKey
        Get
            Return WorkTablePCNAMEvalue
        End Get
        Set(ByVal value As String)
            WorkTablePCNAMEvalue = value
        End Set
    End Property

    ''' <summary>
    ''' 選択用ワークテーブルのキー(PGCODE)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property WorkTablePGCODE() As String Implements Model.IKobetuSentakuKey.PGCODEKey
        Get
            Return WorkTablePGCODEvalue
        End Get
        Set(ByVal value As String)
            WorkTablePGCODEvalue = value
        End Set
    End Property

    ''' <summary>
    ''' 選択用ワークテーブルのキー(FULINO)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property WorkTableFULINO() As Integer Implements Model.IKobetuSentakuKey.FULINOKey
        Get
            Return WorkTableFULINOvalue
        End Get
        Set(ByVal value As Integer)
            WorkTableFULINOvalue = value
        End Set
    End Property

    Private masterLastClickedColumnValue As Integer = 0
    Private masterSortDirectionValue As String = ""

    Private sentakuLastClickedColumnValue As Integer = 0
    Private sentakuSortDirectionValue As String = ""

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

    ''' <summary>
    ''' 左側の一覧用の最後にクリックした列番号として使ってください
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SentakuLastClickedColumn() As Integer
        Get
            Return sentakuLastClickedColumnValue
        End Get
        Set(ByVal value As Integer)
            sentakuLastClickedColumnValue = value
        End Set
    End Property

    ''' <summary>
    ''' 左の一覧のacsかdescかを保存する項目として使ってください
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SentakuSortDirection() As String
        Get
            Return sentakuSortDirectionValue
        End Get
        Set(ByVal value As String)
            sentakuSortDirectionValue = value
        End Set
    End Property

    Private SelectDataSetValue As DataTable

    ''' <summary>
    ''' 左側の内容を保存するデータセットです。
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

    ''' <summary>
    ''' グリッドの項目設定等を行ってください。
    ''' </summary>
    ''' <param name="dbGrid">初期化するグリッド</param>
    ''' <remarks></remarks>
    Protected Overridable Sub MasterGridSetup(ByVal dbGrid As C1.Win.C1TrueDBGrid.C1TrueDBGrid)
        If DesignMode = False Then
            Throw New NotImplementedException("実装してください")
        End If
    End Sub

    ''' <summary>
    ''' 選択ワークテーブルにおけるキー項目の名前を指定してください 例 WT_SENCLSならCLASSCODE
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Overridable Function CodeNameField() As String
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
    ''' 右側のリストを読み込むリモートファサードを返してください
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Overridable Function RightListLoadMethod() As BLL.Common.IBusinessLogic
        Throw New NotImplementedException("実装してください")
    End Function

    ''' <summary>
    ''' 左側のリストを読み込むリモートファサードを返してください
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Overridable Function LeftListLoadMethod() As BLL.Common.IBusinessLogic
        Throw New NotImplementedException("実装してください")
    End Function

    ''' <summary>
    ''' 左側のリストのヘッダクリック時のソートを実装してください
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Overridable Sub dbgSentaku_HeadClick(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles dbgSentaku.HeadClick
        Throw New NotImplementedException("実装してください")
    End Sub

    ''' <summary>
    ''' 右側のリストのヘッダクリック時のソートを実装してください
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Overridable Sub dbgMaster_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles dbgMaster.HeadClick
        Throw New NotImplementedException("実装してください")
    End Sub

    ''' <summary>
    ''' 右から左への項目のコピーを実装してください
    ''' </summary>
    ''' <param name="masterGrid"></param>
    ''' <param name="columnNumber"></param>
    ''' <remarks></remarks>
    Protected Overridable Sub MoveRightToLeft(ByVal masterGrid As C1TrueDBGrid, ByVal columnNumber As Integer)
        Throw New NotImplementedException("実装してください")
    End Sub

    ''' <summary>
    ''' 右側のリストを取得するためのRequestパラメータを生成してください
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Overridable Function LoadListRequestParam() As RequestParamBase
        Throw New NotImplementedException("実装してください")
    End Function

    ''' <summary>
    ''' 初期状態でのグリッドのソートを指定してください
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overridable Sub DefaultSort()
        If DesignMode = False Then
            Throw New NotImplementedException("実装してください")
        End If
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

                'ワーク更新
                UpdateWorkTable()

                SelectDataSet.AcceptChanges()

                If SelectDataSet.Rows.Count = 0 Then
                    ItemSelected = False
                Else
                    ItemSelected = True
                End If

                DialogResult = Windows.Forms.DialogResult.OK

            Case "選択"
                Dim grid As C1TrueDBGrid = CType(dbgMaster, C1.Win.C1TrueDBGrid.C1TrueDBGrid)
                If (grid.RowCount = 0) Then Exit Sub
                '店舗選択
                ItemSelect(dbgMaster, Nothing)
                ItemSelected = True

                LastFocusedControl.Focus()

            Case "全削除"

                'If CommonUtility.WinForm.MessageBoxEx.Show(MessageCode_Arg0.M1000全削除してもよろしいですか, Me.Text) = Windows.Forms.DialogResult.Yes Then
                SelectDataSet.Rows.Clear()
                'End If

                LastFocusedControl.Focus()

            Case "行削除"
                Dim grid As C1TrueDBGrid = CType(dbgSentaku, C1.Win.C1TrueDBGrid.C1TrueDBGrid)
                If (grid.RowCount = 0) Then Exit Sub

                DeleteSelectedItem()

                LastFocusedControl.Focus()

        End Select
    End Sub

    Private Sub DeleteSelectedItem()
        Dim grid As C1TrueDBGrid = CType(dbgSentaku, C1.Win.C1TrueDBGrid.C1TrueDBGrid)

        If grid.SelectedRows.Count = 0 Then
            grid.Delete()
        Else
            For i As Integer = grid.SelectedRows.Count - 1 To 0 Step -1
                grid.Bookmark = grid.SelectedRows(i)
                grid.Delete()
            Next
            grid.SelectedRows.Clear()

        End If

    End Sub

    Private Sub CountSelectedItem(Of TEventArgs)(ByVal sender As Object, ByVal e As TEventArgs)
        '選択件数に件数を表示
        lblCount.Text = CType(FormatNumber(dbgSentaku.RowCount, 0), String)
    End Sub

    '    Private Sub KobetuSentaku1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Protected Overrides Sub Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MyBase.Form_Load(sender, e)

        'ファンクションキー
        FunctionKey.ClearAll()

        FunctionKey.SetItem(1, "終了", "終了", True)
        FunctionKey.SetItem(2, "", "", False)
        FunctionKey.SetItem(3, "全削除", "全削除", True)
        FunctionKey.SetItem(4, "", "", False)
        FunctionKey.SetItem(5, "行削除", "行削除", True)
        FunctionKey.SetItem(6, "", "", False)
        FunctionKey.SetItem(7, "", "", False)
        FunctionKey.SetItem(8, "", "", False)
        FunctionKey.SetItem(9, "", "", False)
        FunctionKey.SetItem(10, "", "", False)
        FunctionKey.SetItem(11, "", "", False)
        FunctionKey.SetItem(12, "選択", "選択", True)


        If DesignMode = False Then
            'パラメータチェック
            If Utility.NUCheck(WorkTablePGCODE) = True Then
                Throw New ArgumentNullException("WorkTablePGCODE")
            End If
            If Utility.NUCheck(WorkTablePCNAME) = True Then
                Throw New ArgumentNullException("WorkTablePCNAME")
            End If

            'グリッドセットアップ
            MasterGridSetup(dbgMaster)
            MasterGridSetup(dbgSentaku)

            'SelectDataSet = New SEN1110List
            'リスト部のバインド
            dbgSentaku.SetDataBinding(SelectDataSet, "", True) 'gridにバインド

            'マスター明細セット
            LoadList()
            LoadWorkList()

            DefaultSort()


            '件数表示用のハンドラ登録
            AddHandler SelectDataSet.RowChanged, AddressOf CountSelectedItem
            AddHandler SelectDataSet.RowDeleted, AddressOf CountSelectedItem
            AddHandler SelectDataSet.TableCleared, AddressOf CountSelectedItem

            '件数初期表示
            CountSelectedItem(Me, New EventArgs)

        End If
    End Sub

    Protected Sub UpdateWorkTable()

        Dim logic As BLL.Common.IBusinessLogic = UpdateMethod()
        Dim dt As DataTable = CommonUtility.KobetuSentakuUtility.MakeSentakuUpdateDataTable(CodeNameField, SelectDataSet, False)
        Dim requestParam As New Model.DTO.RequestSentakuUpdate(WorkTablePCNAME, WorkTablePGCODE, WorkTableFULINO, dt)
        logic.Update(requestParam)

    End Sub

    Protected Overridable Sub LoadList()

        Dim logic As BLL.Common.IBusinessLogic = RightListLoadMethod()
        Dim requestParam As New BLL.Common.DTO.RequestSentakuKey(WorkTablePCNAME, WorkTablePGCODE, WorkTableFULINO)
        Dim responseParam As DataTable = logic.GetRightList(requestParam)

        SelectDataSet = responseParam
        dbgMaster.SetDataBinding(responseParam, "", True) 'gridにバインド

    End Sub

    Protected Sub LoadWorkList()

        Dim logic As BLL.Common.IBusinessLogic = LeftListLoadMethod()
        Dim requestParam As New BLL.Common.DTO.RequestSentakuKey(WorkTablePCNAME, WorkTablePGCODE, WorkTableFULINO)
        Dim responseParam As DataTable = logic.GetLeftList(requestParam)

        SelectDataSet = responseParam
        dbgSentaku.SetDataBinding(responseParam, "", True)

    End Sub

    Protected Sub dbgMaster_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dbgMaster.DoubleClick

        'クリック位置のチェック
        If CommonUtility.WinForm.WinFormUtility.GridPointAtCell(dbgMaster) = False Then
            Exit Sub
        End If

        Call ItemSelect(sender, e)

    End Sub

    Protected Sub ItemSelect(ByVal sender As Object, ByVal e As System.EventArgs)

        'Dim grid As C1TrueDBGrid = CType(sender, C1.Win.C1TrueDBGrid.C1TrueDBGrid)
        'If (grid.RowCount = 0) Then Exit Sub

        Dim SelBmks As SelectedRowCollection
        If dbgMaster.VisibleRows < 0 Then
            Exit Sub
        End If

        '選択された行をコレクションに格納
        SelBmks = dbgMaster.SelectedRows

        If (SelBmks.Count = 0) Then
            '単一行選択
            MoveRightToLeft(dbgMaster, dbgMaster.Row)
            SelectDataSet.AcceptChanges()

        Else
            '複数行選択

            '選択行数分ループ
            For intSel As Integer = 0 To SelBmks.Count - 1
                MoveRightToLeft(dbgMaster, SelBmks(intSel))
            Next
            SelectDataSet.AcceptChanges()

        End If

    End Sub

   
End Class