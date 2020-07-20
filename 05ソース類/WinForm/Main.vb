Public Class Main
    Shared Sub Main()
        'Mainから起動するため、プロジェクトのプロパティの「アプリケーションフレームワークを有効にする」をチェックなしにすると
        '画面が崩れるため、以下のを呼び出す。
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)

        'フォームを起動する

#If DEBUG Then
        Application.Run(New frmDebugMain)
#End If
#If DEBUG = False Then
        Application.Run(New frmUSERPASS)
#End If
    End Sub
End Class
