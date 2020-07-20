Public Class frmMSE0010

    Public Overrides Function PROGRAM_ID() As String
        Return "MENTSYSTEM"
    End Function

    Public Overrides Function PROGRAM_NAME() As String
        Return "システム設定登録"
    End Function

    Private Function DEFAULTVALUE() As String
        Return "DEFAULT"
    End Function

    Private Enum COLPC
        PCNAME = 0
    End Enum

    Private Enum COLSYS
        SYSTEMFILE = 0
        SYSTEMFILEINFO = 1
        SECTIONNAME = 2
        SECTIONNAMEINFO = 3
        PROPERTYNAME = 4
        PROPERTYNAMEINFO = 5
        VALUE = 6
    End Enum

    Friend Enum enum更新種別
        規定値
        登録
        削除
    End Enum

    Private WithEvents GridController As CommonUtility.WinFormControls.GridController 'グリッドコントローラー

    Protected Overrides Sub Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MyBase.Form_Load(sender, e)

        Call 画面設定()

        Call グリッド初期化()

        Call イベント設定()

        Call 端末リスト取得()

        Call 設定内容取得(PCNAME)

        SelectRow(txtPCNAME.Text)

    End Sub

    Private Sub 端末リスト取得()

        dbgPc.SetDataBinding(daMSE0010.ReadPCNAMEList, "", True)

    End Sub

    Private Sub 設定内容取得(ByVal strPCNAME As String)

        With dbgSystem

            .SetDataBinding(daMSE0010.ReadS_SYSTEMList(strPCNAME), "", True)

            For i As Integer = 0 To dbgSystem.Columns.Count - 1
                .Splits(0).DisplayColumns(i).AutoSize()
                .Columns(i).FilterText = ""
            Next
        End With

    End Sub

    Protected Overrides Sub FunctionKeyAction(ByVal sender As System.Object, ByVal e As CommonUtility.WinFormControls.FunctionKeyEventArgs)

        Select Case e.Name

            Case "終了"

                Me.Close()

                Exit Sub

            Case "削除"

                If Not AllInputValidate() Then Return

                If txtPCNAME.Text.ToUpper = DEFAULTVALUE() Then
                    CommonUtility.WinForm.MessageBoxEx.Show(CommonUtility.MessageCode_Arg1.M997フリーOKONLY, "規定値情報は削除できません", PROGRAM_NAME, MessageBoxIcon.Exclamation)
                    Return
                End If

                If CommonUtility.WinForm.MessageBoxEx.Show(CommonUtility.MessageCode_Arg0.M002削除してもよろしいですか, PROGRAM_NAME) = Windows.Forms.DialogResult.No Then Return

                ExecuteMain(enum更新種別.削除)

                Call 端末リスト取得()

                Call 設定内容取得(PCNAME)

                txtPCNAME.Text = PCNAME

                SelectRow(txtPCNAME.Text)

            Case "規定値"

                If Not AllInputValidate() Then Return

                If txtPCNAME.Text.ToUpper = DEFAULTVALUE() Then
                    CommonUtility.WinForm.MessageBoxEx.Show(CommonUtility.MessageCode_Arg0.M032訂正できません, PROGRAM_NAME)
                    Return
                End If

                If CommonUtility.WinForm.MessageBoxEx.Show(CommonUtility.MessageCode_Arg0.M001登録してもよろしいですか, PROGRAM_NAME) = Windows.Forms.DialogResult.No Then Return

                ExecuteMain(enum更新種別.規定値)

                Call 端末リスト取得()

                Call 設定内容取得(txtPCNAME.Text)

                SelectRow(txtPCNAME.Text)

            Case "登録"

                If Not AllInputValidate() Then Return

                If CommonUtility.WinForm.MessageBoxEx.Show(CommonUtility.MessageCode_Arg0.M001登録してもよろしいですか, PROGRAM_NAME) = Windows.Forms.DialogResult.No Then Return

                ExecuteMain(enum更新種別.登録)

                Call 端末リスト取得()

                Call 設定内容取得(txtPCNAME.Text)

                SelectRow(txtPCNAME.Text)

        End Select

        LastFocusedControl.Focus()

    End Sub

    '更新処理メイン
    Private Sub ExecuteMain(ByVal 更新 As enum更新種別)

        Dim logic As New daMSE0010

        Select Case 更新
            Case enum更新種別.規定値
                logic.DefaultCreate(txtPCNAME.Text, BuildUpdateDataTable(DEFAULTVALUE))
            Case enum更新種別.登録
                logic.Entry(txtPCNAME.Text, BuildUpdateDataTable)
            Case enum更新種別.削除
                logic.Delete(txtPCNAME.Text)
        End Select

    End Sub

    '更新用データ作成
    Private Function BuildUpdateDataTable() As dsMSE0010.UpdateListDataTable

        Dim dt As New dsMSE0010.UpdateListDataTable
        For Each r As dsMSE0010.S_SYSTEMRow In CType(dbgSystem.DataSource, dsMSE0010.S_SYSTEMDataTable)
            BuildUpdateDataTable(dt, txtPCNAME.Text, r, PROGRAM_ID, TANTO_CODE)
        Next
        Return dt

    End Function

    '更新用データ作成
    '引数：端末名　データを取得する際は引数の端末名　レコードにセットする端末名画面．端末名
    Private Function BuildUpdateDataTable(ByVal strPCNAME As String) As dsMSE0010.UpdateListDataTable

        Dim dt As New dsMSE0010.UpdateListDataTable
        For Each r As dsMSE0010.S_SYSTEMRow In daMSE0010.ReadS_SYSTEMList(strPCNAME)
            BuildUpdateDataTable(dt, txtPCNAME.Text, r, PROGRAM_ID, TANTO_CODE)
        Next
        Return dt

    End Function

    '更新用データ作成
    Private Sub BuildUpdateDataTable(ByRef dt As dsMSE0010.UpdateListDataTable,
                                     ByVal strPCNAME As String,
                                     ByVal r As dsMSE0010.S_SYSTEMRow, ByVal strPROGRAM_ID As String, ByVal strUSER_CODE As String)
        If r.RowState = DataRowState.Deleted Then Return '削除レコードは対象外
        dt.AddUpdateListRow(txtPCNAME.Text, r.SYSTEMFILE, r.SYSTEMFILEINFO, r.SECTIONNAME, r.SECTIONNAMEINFO, r.PROPERTYNAME, r.PROPERTYNAMEINFO, r.VALUE, strPROGRAM_ID, strUSER_CODE)
    End Sub

    Private Sub 画面設定()

        txtPCNAME.Text = PCNAME

        Call ファンクションキー設定()

    End Sub

    Private Sub ファンクションキー設定()

        FunctionKey.ClearAll()

        FunctionKey.SetItem(1, "終了", "終了", True)
        FunctionKey.SetItem(3, "削除", "削除", True)
        FunctionKey.SetItem(11, "規定値", "規定値", True)
        FunctionKey.SetItem(12, "登録", "登録", True)

    End Sub

    Private Sub グリッド初期化()

        With dbgPc

            With .Columns
                .Add(New C1.Win.C1TrueDBGrid.C1DataColumn("", "PCNAME", Type.GetType("System.String")))
            End With

            With .Splits(0)
                .DisplayColumns(COLPC.PCNAME).Width = (30) * 8
            End With

            For i As Integer = 0 To .Columns.Count - 1
                .Splits(0).DisplayColumns(i).Visible = True
                .Splits(0).DisplayColumns(i).AllowFocus = True
            Next

            .Columns(COLPC.PCNAME).Caption = "端末名"

            .Columns(COLPC.PCNAME).DataWidth = 15

        End With

        GridSetup(dbgPc, GridSetupAllows.AllowReadOnly, False, False, False)

        With dbgSystem
            With .Columns
                .Add(New C1.Win.C1TrueDBGrid.C1DataColumn("", "SYSTEMFILE", Type.GetType("System.String")))
                .Add(New C1.Win.C1TrueDBGrid.C1DataColumn("", "SYSTEMFILEINFO", Type.GetType("System.String")))
                .Add(New C1.Win.C1TrueDBGrid.C1DataColumn("", "SECTIONNAME", Type.GetType("System.String")))
                .Add(New C1.Win.C1TrueDBGrid.C1DataColumn("", "SECTIONNAMEINFO", Type.GetType("System.String")))
                .Add(New C1.Win.C1TrueDBGrid.C1DataColumn("", "PROPERTYNAME", Type.GetType("System.String")))
                .Add(New C1.Win.C1TrueDBGrid.C1DataColumn("", "PROPERTYNAMEINFO", Type.GetType("System.String")))
                .Add(New C1.Win.C1TrueDBGrid.C1DataColumn("", "VALUE", Type.GetType("System.String")))
            End With

            With .Splits(0)
                .DisplayColumns(COLSYS.SYSTEMFILE).Width = (10) * 8
                .DisplayColumns(COLSYS.SYSTEMFILEINFO).Width = (0) * 8
                .DisplayColumns(COLSYS.SECTIONNAME).Width = (20) * 8
                .DisplayColumns(COLSYS.SECTIONNAMEINFO).Width = (0) * 8
                .DisplayColumns(COLSYS.PROPERTYNAME).Width = (20) * 8
                .DisplayColumns(COLSYS.PROPERTYNAMEINFO).Width = (0) * 8
                .DisplayColumns(COLSYS.VALUE).Width = (46) * 8 + 4
            End With

            For i As Integer = 0 To .Columns.Count - 1
                .Splits(0).DisplayColumns(i).Visible = True
                .Splits(0).DisplayColumns(i).AllowFocus = True
                .Columns(i).FilterDropdown = True
            Next

            .Columns(COLSYS.SYSTEMFILE).Caption = "種類"
            .Columns(COLSYS.SYSTEMFILEINFO).Caption = "種類(説明)"
            .Columns(COLSYS.SECTIONNAME).Caption = "セクション"
            .Columns(COLSYS.SECTIONNAMEINFO).Caption = "セクション(説明)"
            .Columns(COLSYS.PROPERTYNAME).Caption = "プロパティ"
            .Columns(COLSYS.PROPERTYNAMEINFO).Caption = "プロパティ(説明)"
            .Columns(COLSYS.VALUE).Caption = "値"

            .Columns(COLSYS.SYSTEMFILE).DataWidth = 20
            .Columns(COLSYS.SYSTEMFILEINFO).DataWidth = 50
            .Columns(COLSYS.SECTIONNAME).DataWidth = 20
            .Columns(COLSYS.SECTIONNAMEINFO).DataWidth = 50
            .Columns(COLSYS.PROPERTYNAME).DataWidth = 20
            .Columns(COLSYS.PROPERTYNAMEINFO).DataWidth = 50
            .Columns(COLSYS.VALUE).DataWidth = 100

            .FilterBar = True
            .FilterBarStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center

        End With

        GridSetup(dbgSystem, GridSetupAllows.AllowAll, True, True, False)

        GridController = New CommonUtility.WinFormControls.GridController(dbgSystem, FunctionKey, PROGRAM_ID, TANTO_CODE)

        With GridController
            .DefaultColumnPosition = COLSYS.SYSTEMFILE

            .SetColumnDisplayName(COLSYS.SYSTEMFILE, dbgSystem.Columns(COLSYS.SYSTEMFILE).Caption)
            .SetColumnDisplayName(COLSYS.SYSTEMFILEINFO, dbgSystem.Columns(COLSYS.SYSTEMFILEINFO).Caption)
            .SetColumnDisplayName(COLSYS.SECTIONNAME, dbgSystem.Columns(COLSYS.SECTIONNAME).Caption)
            .SetColumnDisplayName(COLSYS.SECTIONNAMEINFO, dbgSystem.Columns(COLSYS.SECTIONNAMEINFO).Caption)
            .SetColumnDisplayName(COLSYS.PROPERTYNAME, dbgSystem.Columns(COLSYS.PROPERTYNAME).Caption)
            .SetColumnDisplayName(COLSYS.PROPERTYNAMEINFO, dbgSystem.Columns(COLSYS.PROPERTYNAMEINFO).Caption)
            .SetColumnDisplayName(COLSYS.VALUE, dbgSystem.Columns(COLSYS.VALUE).Caption)

            .SetColumnValueType(COLSYS.SYSTEMFILE, CommonUtility.WinFormControls.GridColumnType.None)
            .SetColumnValueType(COLSYS.SYSTEMFILEINFO, CommonUtility.WinFormControls.GridColumnType.None)
            .SetColumnValueType(COLSYS.SECTIONNAME, CommonUtility.WinFormControls.GridColumnType.None)
            .SetColumnValueType(COLSYS.SECTIONNAMEINFO, CommonUtility.WinFormControls.GridColumnType.None)
            .SetColumnValueType(COLSYS.PROPERTYNAME, CommonUtility.WinFormControls.GridColumnType.None)
            .SetColumnValueType(COLSYS.PROPERTYNAMEINFO, CommonUtility.WinFormControls.GridColumnType.None)
            .SetColumnValueType(COLSYS.VALUE, CommonUtility.WinFormControls.GridColumnType.None)

        End With

    End Sub

    Private Sub イベント設定()

        AddHandler txtPCNAME.PressEnter, AddressOf CodeSelectByTextBox

        AddHandler dbgPc.DoubleClick, AddressOf CodeSelectByGrid

        With dbgSystem
            AddHandler .BeforeColUpdate, AddressOf dbgSystem_BeforeColUpdate
            AddHandler .BeforeUpdate, AddressOf dbgSystem_BeforeUpdate
        End With

    End Sub

    Private Sub CodeSelectByTextBox(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If txtPCNAME.ValidateMe = False Then
            txtPCNAME.Focus()
            Return
        End If

        Call 設定内容取得(txtPCNAME.Text)

        SelectRow(txtPCNAME.Text)

    End Sub

    Private Sub CodeSelectByGrid(ByVal sender As Object, ByVal e As System.EventArgs)

        'クリック位置のチェック
        If CommonUtility.WinForm.WinFormUtility.GridPointAtCell(dbgPc) = False Then Exit Sub

        txtPCNAME.Text = dbgPc.Columns(COLPC.PCNAME).Value.ToString

        txtPCNAME.Focus()

    End Sub

    Private Sub dbgPc_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dbgPc.DoubleClick, dbgPc.DoubleClick

        If CommonUtility.WinForm.WinFormUtility.GridPointAtCell(dbgPc) = False Then Exit Sub

        txtPCNAME.Text = dbgPc.Columns(COLPC.PCNAME).Value.ToString

        Call 設定内容取得(txtPCNAME.Text)

    End Sub

    Private Sub SelectRow(ByVal strPCNAME As String)

        Dim intRow As Integer = 0
        With dbgPc
            For intRow = 0 To .Splits(0).Rows.Count - 1
                Dim s As String = dbgPc(intRow, COLPC.PCNAME).ToString
                If s.ToUpper = strPCNAME.ToUpper Then
                    .Row = intRow
                    Exit For
                End If
            Next

            If intRow > (.Splits(0).Rows.Count - 1) Then .Row = 0
        End With

    End Sub

    Public Function AllInputValidate() As Boolean
        Return InputErrorCheck(Nothing, 9999999)
    End Function

    Private Sub EnterEventHandler(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If CType(sender, System.Windows.Forms.Control).CausesValidation = False Then
            Return
        End If

        If InputErrorCheck(CType(sender, System.Windows.Forms.Control), GetTabOrder(CType(sender, System.Windows.Forms.Control))) = False Then
            Return
        End If

    End Sub
    Private Function InputErrorCheck(ByVal sender As System.Windows.Forms.Control, ByVal tabOrder As Integer) As Boolean
        Dim CheckResult As Nullable(Of Boolean)

        '端末名
        CheckResult = InputErrorCheck_Control(txtPCNAME, tabOrder)
        If CheckResult.HasValue Then Return CheckResult.Value

        Return True

    End Function

    Private Sub dbgSystem_BeforeColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs)

        With dbgSystem

            Select Case e.ColIndex

                Case COLSYS.PROPERTYNAME, COLSYS.SECTIONNAME, COLSYS.SYSTEMFILE

                    If CommonUtility.Utility.NUCheck(.Columns(e.ColIndex).Value) Then

                        CommonUtility.WinForm.MessageBoxEx.Show(CommonUtility.MessageCode_Arg1.M015は必ず入力して下さい, .Columns(e.ColIndex).Caption, PROGRAM_NAME)
                        e.Cancel = True
                        Return
                    End If

            End Select


        End With

    End Sub

    Private Sub dbgSystem_BeforeUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.CancelEventArgs)

        With dbgSystem

            For intCol As Integer = 0 To dbgSystem.Columns.Count - 1

                Select Case intCol

                    Case COLSYS.PROPERTYNAME, COLSYS.SECTIONNAME, COLSYS.SYSTEMFILE

                        If CommonUtility.Utility.NUCheck(.Columns(intCol).Value) Then
                            CommonUtility.WinForm.MessageBoxEx.Show(CommonUtility.MessageCode_Arg1.M015は必ず入力して下さい, .Columns(intCol).Caption, PROGRAM_NAME)
                            e.Cancel = True
                            Return
                        End If

                End Select

            Next

        End With

    End Sub

    Private Sub GridController_MoveFocus(ByVal sender As Object, ByVal e As CommonUtility.WinFormControls.GridMoveFocusEventArgs) Handles GridController.MoveFocus

        With dbgSystem

            If e.CurrentColumnNumber = COLSYS.SYSTEMFILE Then
                e.NextColumnNumber = COLSYS.SYSTEMFILEINFO
            End If
            If e.CurrentColumnNumber = COLSYS.SYSTEMFILEINFO Then
                e.NextColumnNumber = COLSYS.SECTIONNAME
            End If
            If e.CurrentColumnNumber = COLSYS.SECTIONNAME Then
                e.NextColumnNumber = COLSYS.SECTIONNAMEINFO
            End If
            If e.CurrentColumnNumber = COLSYS.SECTIONNAMEINFO Then
                e.NextColumnNumber = COLSYS.PROPERTYNAME
            End If
            If e.CurrentColumnNumber = COLSYS.PROPERTYNAME Then
                e.NextColumnNumber = COLSYS.PROPERTYNAMEINFO
            End If
            If e.CurrentColumnNumber = COLSYS.PROPERTYNAMEINFO Then
                e.NextColumnNumber = COLSYS.VALUE
            End If
            If e.CurrentColumnNumber = COLSYS.VALUE Then
                e.NextColumnNumber = COLSYS.SYSTEMFILE
                e.NextRowNumber += 1
            End If
        End With


    End Sub

End Class
