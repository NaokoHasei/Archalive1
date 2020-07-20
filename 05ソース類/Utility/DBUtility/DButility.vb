Public Class DBUtility

    Private Const ConfigName As String = "ServerSetting.xml"

    Public Shared Function GetConnectionString() As String
        Dim doc As New Xml.XmlDocument
        Dim connectionString As String = vbNullString
#If DEBUG Then
        connectionString = My.Settings.ConnectionString
#Else
        doc.Load(ConfigName)
        Dim key As Xml.XmlNode = doc.SelectSingleNode("/appSettings/add[@key='ConnectionString']")
        connectionString = Strings.Trim(key.SelectSingleNode("value").InnerText)
#End If

        Return connectionString
    End Function

    'Public Shared Function GetConnectionString() As String
    '    'Dim s As String = Utility.GetConfigValue("ServerSetting.config", "ConnectionString")
    '    'Return Utility.GetConfigValue("ServerSetting.config", "ConnectionString")
    '    Return My.Settings.ConnectionString
    'End Function

    Public Shared Function GetCommandTimeout() As Integer

        Dim doc As New Xml.XmlDocument
        Dim s As String = vbNullString
#If DEBUG Then
        s = CommonUtility.Utility.GetAppSettings("SQLCommandTimeout")
        'Dim s As String = Utility.GetConfigValue("ServerSetting.config", "SQLCommandTimeout")
#Else
        doc.Load(ConfigName)
        Dim key As Xml.XmlNode = doc.SelectSingleNode("/appSettings/add[@key='SQLCommandTimeout']")
        s = Strings.Trim(key.SelectSingleNode("value").InnerText)
#End If

        If Utility.NUCheck(s) = True Then
            Return 60 * 10 '10分
        Else
            Return Integer.Parse(s)
        End If

    End Function

    Public Shared Sub SetCommandTimeout(ByVal tableAdapter As System.ComponentModel.Component)
        Dim commandCollection As System.Data.SqlClient.SqlCommand()

        commandCollection = CType(tableAdapter.GetType().InvokeMember("CommandCollection", Reflection.BindingFlags.GetProperty Or Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance, Nothing, tableAdapter, Nothing), System.Data.SqlClient.SqlCommand())

        Dim timeout As Integer = GetCommandTimeout()

        For i As Integer = 0 To commandCollection.Length - 1
            If commandCollection(i) IsNot Nothing Then
                commandCollection(i).CommandTimeout = timeout
            End If
        Next

    End Sub


End Class
