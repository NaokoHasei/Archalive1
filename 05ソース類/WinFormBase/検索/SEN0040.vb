Imports CommonUtility.Utility

''' <summary>
''' 郵便番号辞書
''' </summary>
''' <remarks></remarks>
Public Class SEN0040
    Implements Model.ISearchMenu(Of SEN0040_M_KEN_Data)

    Public Overrides Function PROGRAM_ID() As String
        Return "SEN0040"
    End Function

    Public Overrides Function PROGRAM_NAME() As String
        Return "郵便番号辞書"
    End Function

    Private ItemSelectedValue As Boolean
    Private SelectedItemValue As SEN0040_M_KEN_Data

    Private loadComplete As Boolean = False

    Enum COL
        TODOUFUKEN = 0
        SIKUTYOUSON = 1
        TYOUIKI = 2
        POSTCODE = 3
    End Enum

    Public Property ItemSelected() As Boolean Implements Model.ISearchMenu(Of SEN0040_M_KEN_Data).ItemSelected
        Get
            Return ItemSelectedValue
        End Get
        Set(ByVal value As Boolean)
            ItemSelectedValue = value
        End Set
    End Property

    Public Property SelectedItem() As SEN0040_M_KEN_Data Implements Model.ISearchMenu(Of SEN0040_M_KEN_Data).SelectedItem
        Get
            Return SelectedItemValue
        End Get
        Set(ByVal value As SEN0040_M_KEN_Data)
            SelectedItemValue = value
        End Set
    End Property

    Protected Overrides Sub Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MyBase.Form_Load(sender, e)

        'ファンクションキー
        FunctionKey.ClearAll()

        FunctionKey.SetItem(1, "終了", "終了", True)
        FunctionKey.SetItem(12, "選択", "選択", True)

        txtTODOUFUKEN.Text = ""
        txtTODOUFUKEN_KANA.Text = ""
        txtTODOUFUKEN_SELECT.Text = ""
        txtSIKUTYOUSON.Text = ""
        txtSIKUTYOUSON_KANA.Text = ""
        txtSIKUTYOUSON_SELECT.Text = ""
        txtTYOUIKI.Text = ""
        txtTYOUIKI_KANA.Text = ""
        txtTYOUIKI_SELECT.Text = ""
        txtPOSTCODE.Text = ""
        txtOLDPOSTCODE.Text = ""

        txtTODOUFUKEN_SELECT.ImeMode = Windows.Forms.ImeMode.Hiragana
        txtSIKUTYOUSON_SELECT.ImeMode = Windows.Forms.ImeMode.Hiragana
        txtTYOUIKI_SELECT.ImeMode = Windows.Forms.ImeMode.Hiragana

        tabSelect.SelectedIndex = 1

        Call subLoadList()

        Call subInitCombo()

        Call subInitGrid()

        AddHandler cmdSearch1.Click, AddressOf EventSearchClick
        AddHandler cmdSearch2.Click, AddressOf EventSearchClick
        AddHandler cmdSearch3.Click, AddressOf EventSearchClick
        AddHandler cmdSearch4.Click, AddressOf EventSearchClick
        AddHandler cmdSearch5.Click, AddressOf EventSearchClick

        AddHandler txtTODOUFUKEN.TextUpdated, AddressOf EventTextUpdated
        AddHandler txtSIKUTYOUSON.TextUpdated, AddressOf EventTextUpdated
        AddHandler txtTYOUIKI.TextUpdated, AddressOf EventTextUpdated
        AddHandler txtTODOUFUKEN_SELECT.TextUpdated, AddressOf EventTextUpdated
        AddHandler txtSIKUTYOUSON_SELECT.TextUpdated, AddressOf EventTextUpdated
        AddHandler txtTYOUIKI_SELECT.TextUpdated, AddressOf EventTextUpdated
        AddHandler txtTODOUFUKEN_KANA.TextUpdated, AddressOf EventTextUpdated
        AddHandler txtSIKUTYOUSON_KANA.TextUpdated, AddressOf EventTextUpdated
        AddHandler txtTYOUIKI_KANA.TextUpdated, AddressOf EventTextUpdated

        Call subFilteringGrid()

        loadComplete = True

        If (SelectedItem IsNot Nothing) AndAlso SelectedItem.POSTCODE <> "" Then
            txtPOSTCODE.Text = SelectedItem.POSTCODE
            subFilteringGrid()
        End If

    End Sub

    ''' <summary>
    ''' グリッド初期設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub subInitGrid()

        With gridData

            For intCol As Integer = 0 To .Columns.Count - 1
                .Columns(intCol).Visible = CType(IIf(intCol <= COL.POSTCODE, True, False), Boolean)
            Next

            .Columns(COL.TODOUFUKEN).Width = (8 + 4) * 8
            .Columns(COL.SIKUTYOUSON).Width = (19 + 4) * 8
            .Columns(COL.TYOUIKI).Width = (15 + 4) * 8 + 4   '156
            .Columns(COL.POSTCODE).Width = (8 + 4) * 8

            .Columns(COL.TODOUFUKEN).HeaderText = "都道府県"
            .Columns(COL.SIKUTYOUSON).HeaderText = "市区町村"
            .Columns(COL.TYOUIKI).HeaderText = "町域"
            .Columns(COL.POSTCODE).HeaderText = "郵便番号"

        End With

        Call GridSetup(gridData, GridSetupAllows.AllowReadOnly)

    End Sub

    ''' <summary>
    ''' コンボボックス設定

    ''' </summary>
    ''' <remarks></remarks>
    Private Sub subInitCombo()

        Dim logic As New BLL.Common.TypComboBox

        'コンボボックスデータ取得

        Dim paramlist As New List(Of Model.DTO.RequestGetComboBoxContentsElement)
        paramlist.Add(New Model.DTO.RequestGetComboBoxContentsElement(Model.ComboBoxTableName.M_KEN_TODOUFUKEN, Model.DTO.GetComboBoxContentsResultFieldType.MultipleField, False, Nothing))

        Dim requestParam As New Model.DTO.RequestGetComboBoxContents(paramlist)
        Dim recieveParam As Model.DTO.ResponseGetComboBoxContents

        recieveParam = logic.CreateComboBox(requestParam)

        txtTODOUFUKEN_SELECT.AttachDataSource(Model.ComboBoxTableName.M_KEN_TODOUFUKEN, recieveParam)

        loadComplete = True

        Call ComboBoxUpdateSIKUTYOUSON()
        Call ComboBoxUpdateTYOUIKI()

        loadComplete = False

    End Sub

    Private Sub ComboBoxUpdateSIKUTYOUSON()

        If Not loadComplete Then Exit Sub

        Dim logic As New BLL.Common.TypComboBox

        'コンボボックスデータ取得

        Dim paramlist As New List(Of Model.DTO.RequestGetComboBoxContentsElement)
        paramlist.Add(New Model.DTO.RequestGetComboBoxContentsElement(Model.ComboBoxTableName.M_KEN_SIKUTYOUSON, Model.DTO.GetComboBoxContentsResultFieldType.MultipleField, False, txtTODOUFUKEN_SELECT.Text))

        Dim requestParam As New Model.DTO.RequestGetComboBoxContents(paramlist)
        Dim recieveParam As Model.DTO.ResponseGetComboBoxContents

        recieveParam = logic.CreateComboBox(requestParam)

        txtSIKUTYOUSON_SELECT.AttachDataSource(Model.ComboBoxTableName.M_KEN_SIKUTYOUSON, recieveParam)

    End Sub

    Private Sub ComboBoxUpdateTYOUIKI()

        If Not loadComplete Then Exit Sub

        Dim logic As New BLL.Common.TypComboBox

        'コンボボックスデータ取得

        Dim paramlist As New List(Of Model.DTO.RequestGetComboBoxContentsElement)
        paramlist.Add(New Model.DTO.RequestGetComboBoxContentsElement(Model.ComboBoxTableName.M_KEN_TYOUIKI, Model.DTO.GetComboBoxContentsResultFieldType.MultipleField, False, txtTODOUFUKEN_SELECT.Text + "," + txtSIKUTYOUSON_SELECT.Text))

        Dim requestParam As New Model.DTO.RequestGetComboBoxContents(paramlist)
        Dim recieveParam As Model.DTO.ResponseGetComboBoxContents

        recieveParam = logic.CreateComboBox(requestParam)

        txtTYOUIKI_SELECT.AttachDataSource(Model.ComboBoxTableName.M_KEN_TYOUIKI, recieveParam)

    End Sub

    Private Sub subLoadList()

        Dim logic As New BLL.SEN.SEN0040

        Using wcursor As New CommonUtility.WinForm.WaitCursor

            gridData.DataSource = logic.GetList

        End Using

    End Sub

    Private Sub subFilteringGrid()
        CType(gridData.DataSource, Data.DataTable).DefaultView.RowFilter = getRowFilter()
    End Sub

    ''' <summary>
    ''' 画面フィルター取得

    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function getRowFilter() As String
        Dim strFilter As String = "(1=1)"

        If tabSelect.SelectedIndex = 0 Then
            If Not NUCheck(txtTODOUFUKEN.Text) Then strFilter += " AND TODOUFUKEN LIKE '" & txtTODOUFUKEN.Text & "%'"
            If Not NUCheck(txtSIKUTYOUSON.Text) Then strFilter += " AND SIKUTYOUSON LIKE '" & txtSIKUTYOUSON.Text & "%'"
            If Not NUCheck(txtTYOUIKI.Text) Then strFilter += " AND TYOUIKI LIKE '" & txtTYOUIKI.Text & "%'"
        ElseIf tabSelect.SelectedIndex = 1 Then
            If Not NUCheck(txtTODOUFUKEN_SELECT.Text) Then strFilter += " AND TODOUFUKEN LIKE '" & txtTODOUFUKEN_SELECT.Text & "%'"
            If Not NUCheck(txtSIKUTYOUSON_SELECT.Text) Then strFilter += " AND SIKUTYOUSON LIKE '" & txtSIKUTYOUSON_SELECT.Text & "%'"
            If Not NUCheck(txtTYOUIKI_SELECT.Text) Then strFilter += " AND TYOUIKI LIKE '" & txtTYOUIKI_SELECT.Text & "%'"
        Else
            If Not NUCheck(txtTODOUFUKEN_KANA.Text) Then strFilter += " AND TODOUFUKEN_KANA LIKE '" & txtTODOUFUKEN_KANA.Text & "%'"
            If Not NUCheck(txtSIKUTYOUSON_KANA.Text) Then strFilter += " AND SIKUTYOUSON_KANA LIKE '" & txtSIKUTYOUSON_KANA.Text & "%'"
            If Not NUCheck(txtTYOUIKI_KANA.Text) Then strFilter += " AND TYOUIKI_KANA LIKE '" & txtTYOUIKI_KANA.Text & "%'"
        End If

        If Not NUCheck(txtOLDPOSTCODE.Text) Then strFilter += " AND OLDPOSTCODE LIKE '" & txtOLDPOSTCODE.Text.Replace("-", "") & "%'"
        If Not NUCheck(txtPOSTCODE.Text) Then strFilter += " AND NEWPOSTCODE LIKE '" & txtPOSTCODE.Text.Replace("-", "") & "%'"

        If strFilter = "(1=1)" Then strFilter = "(1=0)"
        Return strFilter

    End Function

    Protected Overrides Sub FunctionKeyAction(ByVal sender As Object, ByVal e As CommonUtility.WinFormControls.FunctionKeyEventArgs)
        MyBase.FunctionKeyAction(sender, e)

        Select Case e.Name

            Case "終了"
                DialogResult = Windows.Forms.DialogResult.OK
                ItemSelected = False

            Case "選択"

                Call subSelectValue()

        End Select
    End Sub

    Private Sub subSelectValue()
        If gridData.RowCount = 0 Then Return
        SelectedItem = New WinFormBase.SEN0040_M_KEN_Data(GetSelectValue(COL.TODOUFUKEN), GetSelectValue(COL.SIKUTYOUSON), GetSelectValue(COL.TYOUIKI), GetSelectValue(COL.POSTCODE))
        ItemSelected = True
        DialogResult = Windows.Forms.DialogResult.OK
    End Sub
    Private Function GetSelectValue(ByVal col As COL) As String
        Return CommonUtility.Utility.NS(gridData.CurrentRow.Cells(col).Value)
    End Function

    Private Sub EventSearchClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call subFilteringGrid()
    End Sub

    Private Sub EventTextUpdated(ByVal sender As Object, ByVal e As System.EventArgs)

        If Not loadComplete Then Exit Sub

        If CType(sender, Control).Name = txtTODOUFUKEN_SELECT.Name Then
            ComboBoxUpdateSIKUTYOUSON()
        ElseIf CType(sender, Control).Name = txtSIKUTYOUSON_SELECT.Name Then
            ComboBoxUpdateTYOUIKI()
        ElseIf CType(sender, Control).Name = txtTYOUIKI_SELECT.Name Then
            cmdSearch2.Focus()
        End If

    End Sub

    Private Sub tabSelect_Selected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TabControlEventArgs) Handles tabSelect.Selected
        Select Case e.TabPageIndex
            Case 0
                txtTODOUFUKEN_SELECT.Text = ""
                txtSIKUTYOUSON_SELECT.Text = ""
                txtTYOUIKI_SELECT.Text = ""
                txtTODOUFUKEN_KANA.Text = ""
                txtSIKUTYOUSON_KANA.Text = ""
                txtTYOUIKI_KANA.Text = ""
            Case 1
                txtTODOUFUKEN.Text = ""
                txtSIKUTYOUSON.Text = ""
                txtTYOUIKI.Text = ""
                txtTODOUFUKEN_KANA.Text = ""
                txtSIKUTYOUSON_KANA.Text = ""
                txtTYOUIKI_KANA.Text = ""
            Case 2
                txtTODOUFUKEN_SELECT.Text = ""
                txtSIKUTYOUSON_SELECT.Text = ""
                txtTYOUIKI_SELECT.Text = ""
                txtTODOUFUKEN.Text = ""
                txtSIKUTYOUSON.Text = ""
                txtTYOUIKI.Text = ""
        End Select
        tabSelect.SelectNextControl(tabSelect, True, True, True, True)
    End Sub

    Private Sub gridData_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridData.DoubleClick
        Call subSelectValue()
    End Sub
End Class

Public Class SEN0040_M_KEN_Data

    Public POSTCODE As String
    Public TODOUFUKEN As String
    Public SIKUTYOUSON As String
    Public TYOUIKI As String

    Public Sub New()

    End Sub

    Public Sub New(ByVal todoufuken As String, ByVal sikutyouson As String, ByVal tyouiki As String, ByVal postCode As String)
        Me.POSTCODE = postCode
        Me.TODOUFUKEN = todoufuken
        Me.SIKUTYOUSON = sikutyouson
        Me.TYOUIKI = tyouiki
    End Sub
End Class

Public Class daSEN0040

    Private connectionString As String

    ''' <summary>
    ''' クラス初期化

    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        connectionString = CommonUtility.DBUtility.GetConnectionString
    End Sub

    ''' <summary>
    ''' 県マスタ読込
    ''' </summary>
    ''' <param name="strTOKUICODE"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ReadM_KENbyPrimarykey(ByVal strPOSTCODE As String) As BLL.SEN.dsSEN0040.M_KENDataTable

        Dim resultDataSet As New BLL.SEN.dsSEN0040.M_KENDataTable
        Using ItemAdapter As New BLL.SEN.dsSEN0040TableAdapters.M_KENTableAdapter, _
            connection As New System.Data.SqlClient.SqlConnection(connectionString)
            ItemAdapter.Connection = connection : CommonUtility.DBUtility.SetCommandTimeout(ItemAdapter)
            ItemAdapter.FillBy(resultDataSet, strPOSTCODE)
        End Using
        Return resultDataSet

    End Function
End Class
