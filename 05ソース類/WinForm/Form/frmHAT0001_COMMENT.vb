Public Class frmHAT0001_COMMENT

    Public Overrides Function PROGRAM_ID() As String
        Return "HAT0001"
    End Function

    Public Overrides Function PROGRAM_NAME() As String
        Return "発注登録"
    End Function

    Private DataSetCommentValue As dsHAT0001.コメント情報DataTable
    Public Property DatasetComment() As dsHAT0001.コメント情報DataTable
        Get
            Return DataSetCommentValue
        End Get
        Set(ByVal value As dsHAT0001.コメント情報DataTable)
            DataSetCommentValue = value
        End Set
    End Property

    Public Sub New(ByVal DataSetComment As dsHAT0001.コメント情報DataTable)

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。

        DataSetCommentValue = DataSetComment

    End Sub


    Protected Overrides Sub Form_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        MyBase.Form_Load(sender, e)

        Call ファンクションキー制御()

        Call データ表示()

    End Sub

    Private Sub ファンクションキー制御()
        FunctionKey.ClearAll()

        FunctionKey.SetItem(1, "戻る", "戻る", True)
        FunctionKey.SetItem(12, "登録", "登録", True)
    End Sub

    Protected Overrides Sub FunctionKeyAction(ByVal sender As System.Object, ByVal e As CommonUtility.WinFormControls.FunctionKeyEventArgs)

        Select Case e.Name

            Case "登録"

                If CommonUtility.WinForm.MessageBoxEx.Show(CommonUtility.MessageCode_Arg0.M001登録してもよろしいですか, PROGRAM_NAME) = Windows.Forms.DialogResult.No Then Return

                登録()

        End Select

        CType(Me.Owner, frmHAT0001).DataSetCommentValue = DataSetCommentValue

        Me.Close()
    End Sub

    Private Sub データ表示()

        For Each row As dsHAT0001.コメント情報Row In DataSetCommentValue

            Select Case row.CATEGORYID
                Case "HATYU_PRI"
                    Select Case row.DATAKEY
                        Case "LABEL_02"
                            txtHATYU_PRI_LABEL_02.Text = row.DATA
                        Case "COMMENT_01"
                            txtHATYU_PRI_COMMENT_01.Text = row.DATA
                        Case "COMMENT_02"
                            txtHATYU_PRI_COMMENT_02.Text = row.DATA
                        Case "COMMENT_03"
                            txtHATYU_PRI_COMMENT_03.Text = row.DATA
                        Case "COMMENT_04"
                            txtHATYU_PRI_COMMENT_04.Text = row.DATA
                        Case "COMMENT_05"
                            txtHATYU_PRI_COMMENT_05.Text = row.DATA
                        Case "COMMENT_06"
                            txtHATYU_PRI_COMMENT_06.Text = row.DATA
                        Case "COMMENT_07"
                            txtHATYU_PRI_COMMENT_07.Text = row.DATA
                        Case "COMMENT_08"
                            txtHATYU_PRI_COMMENT_08.Text = row.DATA
                        Case "COMMENT_09"
                            txtHATYU_PRI_COMMENT_09.Text = row.DATA

                        Case "HATYU_PRI_UKE"
                    End Select

                Case "HATYU_PRI_UKE"
                    Select Case row.DATAKEY
                        Case "LABEL_02"
                            txtHATYU_PRI_UKE_LABEL_02.Text = row.DATA
                        Case "COMMENT_02"
                            txtHATYU_PRI_UKE_COMMENT_02.Text = row.DATA
                    End Select
            End Select
        Next
    End Sub

    Private Sub 登録()

        Dim writingDataSet As New dsHAT0001.コメント情報DataTable

        For Each row As dsHAT0001.コメント情報Row In DataSetCommentValue

            Select Case row.CATEGORYID

                Case "HATYU_PRI"
                    Select Case row.DATAKEY
                        Case "LABEL_02"
                            row.DATA = txtHATYU_PRI_LABEL_02.Text
                        Case "COMMENT_01"
                            row.DATA = txtHATYU_PRI_COMMENT_01.Text
                        Case "COMMENT_02"
                            row.DATA = txtHATYU_PRI_COMMENT_02.Text
                        Case "COMMENT_03"
                            row.DATA = txtHATYU_PRI_COMMENT_03.Text
                        Case "COMMENT_04"
                            row.DATA = txtHATYU_PRI_COMMENT_04.Text
                        Case "COMMENT_05"
                            row.DATA = txtHATYU_PRI_COMMENT_05.Text
                        Case "COMMENT_06"
                            row.DATA = txtHATYU_PRI_COMMENT_06.Text
                        Case "COMMENT_07"
                            row.DATA = txtHATYU_PRI_COMMENT_07.Text
                        Case "COMMENT_08"
                            row.DATA = txtHATYU_PRI_COMMENT_08.Text
                        Case "COMMENT_09"
                            row.DATA = txtHATYU_PRI_COMMENT_09.Text
                    End Select

                Case "HATYU_PRI_UKE"
                    Select Case row.DATAKEY
                        Case "LABEL_02"
                            row.DATA = txtHATYU_PRI_UKE_LABEL_02.Text
                        Case "COMMENT_02"
                            row.DATA = txtHATYU_PRI_UKE_COMMENT_02.Text
                    End Select
            End Select
        Next


    End Sub

    Private Sub EnterEventHandler(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If CType(sender, System.Windows.Forms.Control).CausesValidation = False Then
            Return
        End If
    End Sub

End Class