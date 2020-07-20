Public Class ChildFormBase

    Private log As OperationLog.OutPutLog

    'Public Overloads Function IsChildForm() As Boolean
    '    Return True
    'End Function

    Public Overrides Function IsChildForm() As Boolean
        Return True
    End Function

    Private Sub ChildFormBase_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        DialogResult = DialogResult
    End Sub

    Public Overloads Sub Application_ThreadException(ByVal sender As Object, ByVal e As System.Threading.ThreadExceptionEventArgs)
        Try
        Catch ex As Exception
            log.Write(ex.Message, OperationLog.OutPutLog.LogKind.Info)
            MessageBox.Show("ChildFormBaseCatch", PROGRAM_NAME)
            MessageBox.Show(ex.Message, PROGRAM_NAME)
        Finally
            MessageBox.Show("ChildFormBaseFinally", PROGRAM_NAME)
            'アプリケーションを終了する
            Application.Exit()
        End Try
    End Sub

    Public Sub New()

        System.Data.SqlClient.SqlConnection.ClearAllPools()

        'log = New OperationLog.OutPutLog(InitialInfo, PCNAME, USER_CODE, PROGRAM_ID)

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。

    End Sub

    Private Sub ChildFormBase_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
End Class