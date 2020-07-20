Imports BLL.Common

Public Class MitsumoriJyouken

    Private filePath As String
    Public errMessage As String

    Public Sub New()
        '見積条件の読み込み
        Dim S_SCB As New S_SCBRead("見積登録の見積条件の初期値", "")
        Dim dsS_SCB = S_SCB.GetS_SCB
        Dim mitumoriJoken = ""

        If dsS_SCB.S_SCB.Rows.Count <> 0 AndAlso dsS_SCB.S_SCB(0).DATA <> "" Then
            filePath = dsS_SCB.S_SCB(0).DATA
            If filePath.EndsWith("\") = False Then filePath += "\"
        Else
            filePath = ""
        End If
    End Sub

    Public Sub SetCmbMitsumoriJyouken(ByVal comboBox As Windows.Forms.ComboBox)

        comboBox.Items.Clear()
        comboBox.DropDownStyle = ComboBoxStyle.DropDownList

        If filePath = "" Then Return

        errMessage = ""
        If filePath <> "" Then
            If Not System.IO.Directory.Exists(filePath) Then
                errMessage = "見積条件の初期値のパスが正しくありません。" & vbCrLf & vbCrLf & filePath
                Return
            End If
        End If

        For Each file In System.IO.Directory.GetFiles(filePath, "*.txt", System.IO.SearchOption.AllDirectories)
            comboBox.Items.Add(System.IO.Path.GetFileName(file))
        Next
    End Sub

    Public Sub SetTxtMitsumoriJoken(
              ByVal textBox As CommonUtility.WinFormControls.TextBoxEx _
            , ByVal comboBox As Windows.Forms.ComboBox)

        If comboBox.SelectedItem Is Nothing Then Return

        If filePath = "" Then Return

        Dim file = filePath + comboBox.SelectedItem.ToString

        errMessage = ""
        If Not System.IO.File.Exists(file) Then
            errMessage = "ファイルが存在しません。" & vbCrLf & vbCrLf & file
            Return
        End If

        Using reader = New System.IO.StreamReader(file, System.Text.Encoding.GetEncoding("shift_jis"))
            textBox.Text = reader.ReadToEnd
        End Using
    End Sub

    Public Sub OpenMitumoriJoukenFolder()

        If filePath = "" Then Return

        errMessage = ""
        If Not System.IO.Directory.Exists(filePath) Then
            errMessage = "見積条件の初期値のパスが正しくありません。" & vbCrLf & vbCrLf & filePath
            Return
        End If

        System.Diagnostics.Process.Start(filePath)
    End Sub
End Class
