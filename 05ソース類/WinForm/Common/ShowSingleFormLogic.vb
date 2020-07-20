Public Class ShowSingleFormLogic
    Private form() As WinFormBase.FormBase

    Public Sub New()
        ReDim form([Enum].GetNames(GetType(enumShowDispKbn)).Length)
    End Sub

    Public Enum enumShowDispKbn As Integer
        BUK0002
        BUK0003
        MENT0001
        MENT0002
        MENT0004
        MENT0005
        MENT0006
        MSE0010
        MSE0020
        MSE0040
        MSE0090
        MENTMENU
    End Enum

    Public Sub ShowDisp(ByVal value As enumShowDispKbn, ByVal nowForm As WinFormBase.FormBase)

        'フォームが初期化済、または、表示されている場合、一番手前にフォームを表示
        If form(value) IsNot Nothing AndAlso Not form(value).IsDisposed Then
            form(value).Activate()
            Return
        End If

        Select Case value
            Case enumShowDispKbn.BUK0002
                form(value) = New frmBUK0002()

            Case enumShowDispKbn.BUK0003
                form(value) = New frmBUK0003()

            Case enumShowDispKbn.MENT0001
                form(value) = New frmMENT0001

            Case enumShowDispKbn.MENT0002
                form(value) = New frmMENT0002

            Case enumShowDispKbn.MENT0004
                form(value) = New frmMENT0004

            Case enumShowDispKbn.MENT0005
                form(value) = New frmMENT0005

            Case enumShowDispKbn.MENT0006
                form(value) = New frmMENT0006

            Case enumShowDispKbn.MSE0010
                form(value) = New frmMSE0010

            Case enumShowDispKbn.MSE0020
                form(value) = New frmMSE0020

            Case enumShowDispKbn.MSE0040
                form(value) = New frmMSE0040

            Case enumShowDispKbn.MSE0090
                form(value) = New frmMSE0090

            Case enumShowDispKbn.MENTMENU
                form(value) = New frmMENUMENT
        End Select

        form(value).ShowDisp(nowForm)
    End Sub

End Class
