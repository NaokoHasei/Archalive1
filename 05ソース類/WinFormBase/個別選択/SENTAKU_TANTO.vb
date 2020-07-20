Public Class SENTAKU_TANTO

    'DBGrid列番号
    Private Enum COL
        CHKARIA = 0     'チェック
        CODE = 1        'コード
        MENUKEY = 2
        NAME = 3        '名
    End Enum

    Public Overrides Function PROGRAM_ID() As String
        Return "SENTAKU_TANTO"
    End Function

    Public Overrides Function PROGRAM_NAME() As String
        Return "担当者個別選択"
    End Function

    Protected Overrides Function WorkLoadMethod() As BLL.Common.IBusinessLogic
        Return New BLL.SEN.SENTAKU(Model.KobetuTableName.M_TANTO)
    End Function

    Protected Overrides Function UpdateMethod() As BLL.Common.IBusinessLogic
        Return New BLL.SEN.SENTAKU(Model.KobetuTableName.M_TANTO)
    End Function

    Protected Overrides Function CodeNameField() As String
        Return "TANTOCODE"
    End Function

    Protected Overrides Function NameField() As String
        Return "TANTONAME"
    End Function

    Protected Overrides Function NameStr() As String
        Return "名称"
    End Function

    Protected Overrides Sub Form_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        MyBase.Form_Load(sender, e)

        SettingGridWidth()

    End Sub

    Private Sub SettingGridWidth()

        With dbgMaster
            With .Splits(0)

                .DisplayColumns(COL.CHKARIA).Width = 40
                .DisplayColumns(COL.CODE).Width = 72
                .DisplayColumns(COL.MENUKEY).Width = 160
                .DisplayColumns(COL.NAME).Width = 230

            End With
            .Width = 600

        End With

    End Sub
End Class