Public Class SubForm1


    Protected Overrides Sub Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MyBase.Form_Load(sender, e)

        InitializeFunctionKeys()

        コンボボックス初期化()

        txtBUKACODE.Text = ""
        txtTANTOCODE.Text = ""

    End Sub

    Protected Overrides Sub FunctionKeyAction(ByVal sender As System.Object, ByVal e As CommonUtility.WinFormControls.FunctionKeyEventArgs)

        Select Case e.Name

            Case "戻る"

                DialogResult = System.Windows.Forms.DialogResult.OK

                Exit Sub
        End Select


    End Sub

    Private Sub InitializeFunctionKeys()

        For intIndex As Integer = 1 To 12
            FunctionKey.SetItem(intIndex, "", "", False)
        Next

        FunctionKey.SetItem(1, "戻る", "戻る", True)

    End Sub

    Private Sub コンボボックス初期化()

        Dim logic As New BLL.Common.TypComboBox

        Dim paramlist As New List(Of Model.DTO.RequestGetComboBoxContentsElement)
        paramlist.Add(New Model.DTO.RequestGetComboBoxContentsElement(Model.ComboBoxTableName.M_BUKA, Model.DTO.GetComboBoxContentsResultFieldType.MultipleField, False, Nothing))
        paramlist.Add(New Model.DTO.RequestGetComboBoxContentsElement(Model.ComboBoxTableName.M_TANTO, Model.DTO.GetComboBoxContentsResultFieldType.MultipleField, False, Nothing))
        Dim requestParam As New Model.DTO.RequestGetComboBoxContents(paramlist)
        Dim recieveParam As Model.DTO.ResponseGetComboBoxContents

        recieveParam = logic.CreateComboBox(requestParam)

        txtBUKACODE.AttachDataSource(Model.ComboBoxTableName.M_BUKA, recieveParam)
        txtTANTOCODE.AttachDataSource(Model.ComboBoxTableName.M_TANTO, recieveParam)

    End Sub

End Class