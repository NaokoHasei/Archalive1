Imports BLL.Common

Public Class Manual

    Private manualFile As String
    Public visible As Boolean

    Public Sub New(ByRef btnControl As LinkLabel, ByVal programId As String)
        Dim S_SCBRead As S_SCBRead

        visible = False

        '*** マニュアルのパスを取得 ***
        manualFile = Assembly.GetExecutingAssembly().Location
        manualFile = System.IO.Path.GetDirectoryName(manualFile) + "\Manual\"

        '*** マニュアルのファイル名を取得 ***
        S_SCBRead = New S_SCBRead("マニュアルのファイル名", programId)

        'データが存在しない場合
        Dim dt = S_SCBRead.GetS_SCB.Tables(0)
        If dt.Rows.Count = 0 Then
            btnControl.Visible = False
            Return
        End If

        manualFile += dt.Rows(0).Item("DATA").ToString()

        'ファイルが存在しない場合
        If Not System.IO.File.Exists(manualFile) Then
            btnControl.Visible = False
            Return
        End If

        visible = True
        btnControl.Visible = True
    End Sub

    Public Sub OpenManual()
        Dim p As System.Diagnostics.Process = System.Diagnostics.Process.Start(manualFile)
    End Sub
End Class
