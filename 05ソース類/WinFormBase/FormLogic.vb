Imports CommonUtility.WinFormControls

Public Class FormLogic




End Class

Public Class SyohinCodeValidater

    Public Shared Sub ValidateAndUpdateLinkedText(ByVal SyohinCodeComboBox As TextBoxEx)
        AddHandler SyohinCodeComboBox.LinkedTextUpdate, AddressOf SyohinCodeLinkedTextUpdate
        AddHandler SyohinCodeComboBox.MasterCheckValidate, AddressOf SyohinCodeMasterCheck
    End Sub

    Private Shared Sub SyohinCodeLinkedTextUpdate(ByVal sender As Object, ByVal e As LinkedTextUpdateEventArgs)
        Dim s As String = ""
        Dim text As String = CType(sender, TextBoxEx).Text.Replace("'", "''")
        text = CommonUtility.Utility.ZeroPadding(text, CType(sender, TextBoxEx).MaxLength)

        Dim dt As DataTable = BLL.Common.GetDbValue.Execute("M_SYOHIN", "ISNULL(SYOHINNAME,'')", "SYOHINCODE= '" & text & "'").Tables(0)
        If dt.Rows.Count > 0 Then
            s = CType(BLL.Common.GetDbValue.Execute("M_SYOHIN", "ISNULL(SYOHINNAME,'')", "SYOHINCODE= '" & text & "'").Tables(0).Rows(0).Item(0), String)
        End If
        CType(sender, TextBoxEx).LinkedTextBox.Text = s
        e.Handled = True
    End Sub

    Private Shared Sub SyohinCodeMasterCheck(ByVal sender As Object, ByVal e As MasterCheckValidatorEventArgs)
        Dim text As String = CType(sender, TextBoxEx).Text.Replace("'", "''")
        text = CommonUtility.Utility.ZeroPadding(text, CType(sender, TextBoxEx).MaxLength)
        If CType(BLL.Common.GetDbValue.Execute("M_SYOHIN", "*", "SYOHINCODE = '" & text & "'").Tables(0).Rows.Count, Integer) = 0 Then
            e.NotFound = True
        End If
        e.Handled = True
    End Sub

End Class

Public Class KobetuControl

    'Public Delegate Sub KobetuClickAction(ByVal sender As System.Object, ByVal e As System.EventArgs)
    'Private _ClickAction As KobetuClickAction
    Private _SentakuButton As CommonUtility.WinFormControls.KobetuSentakuButton     '選択ボタン

    Private _PCNAME As String
    Private _PROGRAM_ID As String
    Private _FULINO As Integer
    Private _USERCODE As String

    Private _tableName As Model.KobetuTableName
    Private _FinalizeKind As Model.FinalizeKind

    'Public Sub New(ByVal SentakuButton As CommonUtility.WinFormControls.KobetuSentakuButton, ByVal tableName As Model.KobetuTableName, ByVal PCNAME As String, ByVal PROGRAM_ID As String, ByVal FULINO As Integer, ByVal InitializeKind As Model.InitializeKind, ByVal ClickAction As KobetuClickAction)
    '    Me.New(SentakuButton, tableName, PCNAME, PROGRAM_ID, FULINO, InitializeKind)
    '    _ClickAction = ClickAction
    'End Sub

    Public Sub New(ByVal PCNAME As String, ByVal PROGRAM_ID As String)
        _PCNAME = PCNAME
        _PROGRAM_ID = PROGRAM_ID
    End Sub
    Public Sub New(ByVal SentakuButton As KobetuSentakuButton, ByVal tableName As Model.KobetuTableName, ByVal PCNAME As String, ByVal PROGRAM_ID As String, ByVal FULINO As Integer, ByVal USERCODE As String, ByVal InitializeKind As Model.InitializeKind, ByVal FinalizeKind As Model.FinalizeKind)

        _tableName = tableName

        _SentakuButton = SentakuButton

        _PROGRAM_ID = PROGRAM_ID
        _PCNAME = PCNAME
        _FULINO = FULINO
        _USERCODE = USERCODE

        '初期化
        Initialize(tableName, PCNAME, PROGRAM_ID, FULINO, InitializeKind)
        _FinalizeKind = FinalizeKind

        AddHandler _SentakuButton.Click, AddressOf SentakuClickEventHandler

    End Sub

    Private Sub Initialize(ByVal tableName As Model.KobetuTableName, ByVal PCNAME As String, ByVal PROGRAM_ID As String, ByVal FULINO As Integer, ByVal InitializeKind As Model.InitializeKind)

        Dim logic As New BLL.SEN.SENTAKU
        Dim paramlist As New List(Of Model.DTO.RequestGetKobetuSENTAKUElement)
        paramlist.Add(New Model.DTO.RequestGetKobetuSENTAKUElement(PCNAME, PROGRAM_ID, FULINO, tableName, InitializeKind))
        Dim requestParam As New Model.DTO.RequestGetKobetuSentakuContents(paramlist)
        _SentakuButton.Selected = logic.Init(requestParam)

    End Sub

    'Public Sub Unload(ByVal InitializeKind As Model.FinalizeKind)

    '    Dim logic As New BLL.SEN.SENTAKU
    '    logic.Unload(InitializeKind, _PCNAME, _PROGRAM_ID)

    'End Sub

    Private Sub SentakuClickEventHandler(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Using f As Form = GetSearchForm(_tableName)
            CType(f, Model.IKobetuSentakuKey).PGCODEKey = _PROGRAM_ID
            CType(f, Model.IKobetuSentakuKey).PCNAMEKey = _PCNAME
            CType(f, Model.IKobetuSentakuKey).FULINOKey = _FULINO
            If f.ShowDialog() = Windows.Forms.DialogResult.OK Then
                _SentakuButton.Selected = CType(f, Model.IKobetuSentakuResult).ItemSelected
            End If
        End Using

        '_ClickAction(sender, e)

    End Sub

    Private Function GetSearchForm(ByVal tableName As Model.KobetuTableName) As Form
        Select Case tableName
            Case Model.KobetuTableName.M_BUMON
                Return New SENBUM
            Case Model.KobetuTableName.M_TENPO
                Return New SENTEN
            Case Model.KobetuTableName.M_TOKUI
                Return New SENTAKU_TOKUI
            Case Model.KobetuTableName.M_SIIRE
                Return New SENTAKU_SIIRE
            Case Model.KobetuTableName.M_TANTO
                Return New SENTAKU_TANTO
            Case Else
                Throw New ApplicationException("未対応のフォーム")
        End Select

    End Function

    Protected Overrides Sub Finalize()
        MyBase.Finalize()

        Dim logic As New BLL.SEN.SENTAKU
        logic.Unload(_FinalizeKind, _tableName, _PCNAME, _PROGRAM_ID, _FULINO, _USERCODE)

    End Sub

End Class