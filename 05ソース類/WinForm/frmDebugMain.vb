Public Class frmDebugMain
    Private Sub frmDebugMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'コマンドライン引数を配列で取得する
        Dim cmds As String() = System.Environment.GetCommandLineArgs()
        'コマンドライン引数を列挙する
        If cmds.Length <> 2 Then
            txtBukkenNo.Text = "0"
        Else
            txtBukkenNo.Text = cmds(1)
        End If


        AddHandler btnLogin.Click, AddressOf btn_Click
        AddHandler btnBUK0001.Click, AddressOf btn_Click
        AddHandler btnBUK0002.Click, AddressOf btn_Click
        AddHandler btnBUK0003.Click, AddressOf btn_Click
        AddHandler btnMENT0001.Click, AddressOf btn_Click
        AddHandler btnMENT0002.Click, AddressOf btn_Click
        AddHandler btnMENT0004.Click, AddressOf btn_Click
        AddHandler btnMENT0005.Click, AddressOf btn_Click
        AddHandler btnMENT0006.Click, AddressOf btn_Click
        AddHandler btnMSE0020.Click, AddressOf btn_Click
        AddHandler btnMSE0040.Click, AddressOf btn_Click
        AddHandler btnMSE0090.Click, AddressOf btn_Click

    End Sub

    Private Sub btn_Click(sender As Object, e As EventArgs)
        Dim form As WinFormBase.FormBase

        Select Case True

            Case btnLogin.Focused
                form = New frmUSERPASS

            Case btnBUK0001.Focused
                Dim frmBUK0001 = New frmBUK0001
                frmBUK0001.requestBUK0001.BUKKEN_NO = txtBukkenNo.Text

                frmBUK0001.Top = Me.Top + 30
                frmBUK0001.Left = Me.Left + 30
                frmBUK0001.StartPosition = FormStartPosition.Manual
                frmBUK0001.Show()

                Return

            Case btnBUK0002.Focused
                form = New frmBUK0002

            Case btnBUK0003.Focused
                form = New frmBUK0003

            Case btnMENT0001.Focused
                form = New frmMENT0001

            Case btnMENT0002.Focused
                form = New frmMENT0002

            Case btnMENT0004.Focused
                form = New frmMENT0004

            Case btnMENT0005.Focused
                form = New frmMENT0005

            Case btnMENT0006.Focused
                form = New frmMENT0006

            Case btnMSE0020.Focused
                form = New frmMSE0020

            Case btnMSE0040.Focused
                form = New frmMSE0040

            Case Else
                form = New frmMSE0090

        End Select

        form.Top = Me.Top + 30
        form.Left = Me.Left + 30
        form.StartPosition = FormStartPosition.Manual
        form.Show()
    End Sub
End Class