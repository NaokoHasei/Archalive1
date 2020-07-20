Public Class CommonDialogEx
    Implements IValidatable

    Public Enum enumDialogKind
        Folder
        File
    End Enum

    Private DialogKind_ As enumDialogKind
    Private LinkedTextBox_ As TextBoxEx

    Private FolderDialog_ As StructureFolderDialog
    Private FileDialog_ As StructureFileDialog

    Public Structure StructureFolderDialog
        Public Description As String
        Public RootFolder As System.Environment.SpecialFolder
        Public SelectedPath As String
        Public ShowNewFolderButton As Boolean
    End Structure

    Public Structure StructureFileDialog
        Public DefaultFileName As String
        Public InitialDirectory As String
        Public Filter As String
        Public FilterIndex As Integer
        Public Title As String
        Public RestoreDirectory As Boolean
        Public CheckFileExists As Boolean
        Public CheckPathExists As Boolean
    End Structure

    Private Cancel_ As Boolean
    <Category("Custom")> _
    <Description("ダイアログ操作")> _
    <Browsable(False)> _
    Public Property Cancel() As Boolean
        Get
            Return Cancel_
        End Get
        Set(ByVal value As Boolean)
            Cancel_ = value
        End Set
    End Property


    <Category("Custom")> _
    <Description("ダイアログ選択時の文字列が格納されるテキストボックス")> _
    Public Property FolderDialog() As StructureFolderDialog
        Get
            Return FolderDialog_
        End Get
        Set(ByVal value As StructureFolderDialog)
            FolderDialog_ = value
        End Set
    End Property

    <Category("Custom")> _
    <Description("ダイアログ選択時の文字列が格納されるテキストボックス")> _
    Public Property FileDialog() As StructureFileDialog
        Get
            Return FileDialog_
        End Get
        Set(ByVal value As StructureFileDialog)
            FileDialog_ = value
        End Set
    End Property

    <Category("Custom")> _
    <Description("ダイアログ選択時の文字列が格納されるテキストボックス")> _
    Public Property LinkedTextBox() As TextBoxEx
        Get
            Return LinkedTextBox_
        End Get
        Set(ByVal value As TextBoxEx)
            LinkedTextBox_ = value
        End Set
    End Property

    <Category("Custom")> _
    <Description("ダイアログの種類")> _
    Public Property DialogKind() As enumDialogKind
        Get
            Return DialogKind_
        End Get
        Set(ByVal value As enumDialogKind)
            DialogKind_ = value
        End Set
    End Property

    Public Sub New(ByVal d As enumDialogKind)
        DialogKind_ = d
    End Sub

    Public Sub New()
    End Sub


    Protected Overrides Sub OnClick(ByVal e As System.EventArgs)
        Select Case DialogKind
            Case enumDialogKind.File
                LinkedTextBox.Text = OpenFileDialog(Me.LinkedTextBox.Text)
            Case enumDialogKind.Folder
                LinkedTextBox.Text = OpenFolderDialog(Me.LinkedTextBox.Text)
        End Select
        LinkedTextBox.Focus()
        MyBase.OnClick(e)
    End Sub

    Private Function OpenFileDialog(ByVal before As String) As String

        'OpenFileDialogクラスのインスタンスを作成
        Using ofd As New OpenFileDialog()

            ofd.FileName = FileDialog.DefaultFileName
            ofd.InitialDirectory = FileDialog.InitialDirectory
            ofd.Filter = FileDialog.Filter
            ofd.FilterIndex = FileDialog.FilterIndex
            ofd.Title = FileDialog.Title
            ofd.RestoreDirectory = FileDialog.RestoreDirectory
            ofd.CheckFileExists = FileDialog.CheckFileExists
            ofd.CheckPathExists = FileDialog.CheckPathExists

            Dim r As System.Windows.Forms.DialogResult = ofd.ShowDialog()

            Cancel_ = False
            If r = DialogResult.OK Then
                Return ofd.FileName
            ElseIf r = Windows.Forms.DialogResult.Cancel Then
                Cancel_ = True
                Return before
            End If

        End Using

        Return ""

    End Function

    Private Function OpenFolderDialog(ByVal before As String) As String

        Using fbd As New FolderBrowserDialog

            fbd.Description = FolderDialog.Description
            fbd.RootFolder = FolderDialog.RootFolder
            fbd.SelectedPath = FolderDialog.SelectedPath
            fbd.ShowNewFolderButton = FolderDialog.ShowNewFolderButton

            Dim r As System.Windows.Forms.DialogResult = fbd.ShowDialog()

            Cancel_ = False
            If r = DialogResult.OK Then
                Return fbd.SelectedPath
            ElseIf r = Windows.Forms.DialogResult.Cancel Then
                Cancel_ = True
                Return before
            End If

        End Using

        Return ""

    End Function

    Public Function ValidateMe() As Boolean Implements IValidatable.ValidateMe

        Dim e As New CancelEventArgs
        OnValidating(e)
        If e.Cancel = False Then
            OnValidated(New EventArgs())
            Return True
        End If
        Return False

    End Function

    Protected Overrides Sub OnValidated(ByVal e As System.EventArgs)
        MyBase.OnValidated(e)
    End Sub
    Protected Overrides Sub OnValidating(ByVal e As System.ComponentModel.CancelEventArgs)

        If DesignMode = False Then

            If CommonUtility.Utility.NUCheck(LinkedTextBox.Text) = True Then
                Return
            End If

            If DialogKind = enumDialogKind.File Then
                If System.IO.File.Exists(Me.LinkedTextBox.Text) = True Then

                Else
                    MessageBox.Show("ファイルが存在しません", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    LinkedTextBox.Focus()
                    e.Cancel = True
                End If
            Else
                If System.IO.Directory.Exists(Me.LinkedTextBox.Text) = True Then

                Else
                    MessageBox.Show("フォルダが存在しません", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    LinkedTextBox.Focus()
                    e.Cancel = True
                End If
            End If
        End If

        MyBase.OnValidating(e)

    End Sub

End Class
