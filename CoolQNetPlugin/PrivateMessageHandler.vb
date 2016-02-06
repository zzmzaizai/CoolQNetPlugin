Imports System.ComponentModel.Composition
Imports System.ComponentModel.Composition.Hosting
Imports System.Text

''' <summary>
''' 私聊信息处理器。
''' </summary>
Friend Class PrivateMessageHandler
    Private qq As Long, font As Integer ', msgdate As Date
    Private type As PrivateMessageConsoleType
    Private msg As String
    Private cmdbuilder As StringBuilder
    Private plugins As IEnumerable(Of IPrivateMessageHandler)
    ''' <summary>
    ''' 默认构造函数。
    ''' </summary>
    Public Sub New()
        cmdbuilder = New StringBuilder
        'plugins = New List(Of IPrivateMessageHandler)
    End Sub
    ''' <summary>
    ''' 在独立的 <see cref="AppDomain"/> 里组合插件。
    ''' </summary>
    ''' <remarks>本部分代码参照
    ''' http://www.codeproject.com/Articles/633140/MEF-and-AppDomain-Remove-Assemblies-On-The-Fly </remarks>
    Public Sub Compose()
        Dim dircatalog As New DirectoryCatalog(PluginPath)
        Using container As New CompositionContainer(dircatalog)
            container.ComposeParts(Me)
        End Using
        If plugins Is Nothing Then
            cmdbuilder.AppendLine(LogInfo("插件加载", "没有找到可用的插件。"))
        Else
            cmdbuilder.AppendLine(LogInfo("插件加载", String.Format("已加载{0}个插件", plugins.Count.ToString)))
        End If
    End Sub
    ''' <summary>
    ''' 获取处理后的结果。
    ''' </summary>
    ''' <returns><see cref="String"/></returns>
    Public ReadOnly Property Command As String
        Get
            Return cmdbuilder.ToString
        End Get
    End Property
    ''' <summary>
    ''' 执行插件代码。
    ''' </summary>
    Public Sub DoWork()
        Dim res As String
        For Each p As IPrivateMessageHandler In plugins
            If Not p.Permissions.HasFlag(PluginPermissions.PrivateMessage) Then
                Continue For
            End If
            Try
                res = p.Result(qq, type, Unturn(msg), font).ToString
                If Not String.IsNullOrWhiteSpace(res) Then
                    'cmdbuilder.AppendLine(LogInfo(p.Name, ""))
                    If res = InterceptMessage() Then
                        Return
                    End If
                    cmdbuilder.AppendLine(res)
                End If
            Catch ex As Exception
                cmdbuilder.AppendLine(ShowErrorMessage(ex.ToString))
            End Try
        Next
    End Sub
    ''' <summary>
    ''' 获取/设置已加载的插件列表。
    ''' </summary>
    ''' <returns><see cref="IEnumerable(Of IPrivateMessageHandler)"/></returns>
    <ImportMany(GetType(IPrivateMessageHandler))>
    Public Property Plugin As IEnumerable(Of IPrivateMessageHandler) = plugins
    Friend Sub CopyData(senderqq As Long, consoletype As PrivateMessageConsoleType, message As String, msgfont As Integer)
        qq = senderqq
        type = consoletype
        msg = message
        font = msgfont
        'msgdate = sendtime
    End Sub
End Class