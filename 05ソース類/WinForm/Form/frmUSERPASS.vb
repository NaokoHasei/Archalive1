Imports CommonUtility.WinForm

Public Class frmUSERPASS

    Private dalogic As daUSERPASS

    Public Overrides Function PROGRAM_ID() As String
        Return "USERPASS"
    End Function

    Public Overrides Function PROGRAM_NAME() As String
        Return "ログイン　　"
    End Function

    Protected Overrides Sub Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MyBase.Form_Load(sender, e)

        Dim ver As System.Diagnostics.FileVersionInfo = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location)
        lblVersion.Text = ver.FileVersion

        'データアクセスの初期化
        dalogic = New daUSERPASS

        Using wcur As New CommonUtility.WinForm.WaitCursor
            'ファンクションキーの初期化
            For intIndex As Integer = 1 To 12
                FunctionKey.SetItem(intIndex, "", "", False, New Font("メイリオ", 11))
            Next

            FunctionKey.SetItem(1, "終了", "終了", True)
            FunctionKey.SetItem(12, "確定", "確定", True)

            '画面の初期化
            txtTantoCode.Text = ""
            txtPassword.Text = ""
        End Using
    End Sub

    Protected Overrides Sub FunctionKeyAction(ByVal sender As System.Object, ByVal e As CommonUtility.WinFormControls.FunctionKeyEventArgs)

        Select Case e.Name

            Case "終了"

                Me.Close()

            Case "確定"

                '入力チェック
                If InputErrorCheck() = False Then Return

                'ログインチェック
                If Not dalogic.LoginCheck(txtTantoCode.Text, txtPassword.Text) Then
                    MessageBoxEx.Show(CommonUtility.MessageCode_Arg0.M206, PROGRAM_NAME)
                    txtTantoCode.Focus()
                    Return
                End If

                'ログインユーザーの登録
                dalogic.CreateNowUser(PCNAME, PROGRAM_ID, txtTantoCode.Text)

                Using f As New frmMENU()
                    Me.Visible = False
                    f.ShowDialog()
                End Using

                Me.Close()
        End Select

    End Sub

    Protected Function InputErrorCheck() As Boolean
        If txtTantoCode.ValidateMe = False Then
            txtTantoCode.Focus()
            Return False
        End If
        If txtPassword.ValidateMe = False Then
            txtPassword.Focus()
            Return False
        End If

        Return True

    End Function

End Class