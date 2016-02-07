Imports System.ComponentModel.Composition
Imports System.ComponentModel.Composition.Hosting
Imports System.Text

''' <summary>
''' 私聊信息处理器。
''' </summary>
Friend Class PrivateMessageHandler
    Inherits MarshalByRefObject
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
    ''' 组合插件。
    ''' </summary>
    Public Sub Compose()
        Dim dircatalog As New DirectoryCatalog(PluginPath)
        Using container As New CompositionContainer(dircatalog)
            container.ComposeParts(Me)
        End Using
        If plugins Is Nothing Then
            cmdbuilder.AppendLine(LogInfo("CQ.NET", "没有找到可用的插件。"))
        Else
            cmdbuilder.AppendLine(LogInfo("CQ.NET", String.Format("已加载{0}个插件", plugins.Count.ToString)))
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
        If plugins Is Nothing Then
            Return
        End If
        For Each p As IPrivateMessageHandler In plugins
            If Not p.Permissions.HasFlag(PluginPermissions.PrivateMessage) Then
                Continue For
            End If
            Try
                res = p.Result(qq, type, Turn(msg), font).ToString
                If Not String.IsNullOrWhiteSpace(res) Then
                    If res.Contains(Separator) Then Continue For '如包含分隔符无条件跳过
                    If p.IsIntercept Then
                        cmdbuilder.Append(LogInfo("CQ.NET", "消息已被" + p.Name + "拦截。"))
                    End If
                    cmdbuilder.Append(res + Separator)
                End If
            Catch ex As Exception
                cmdbuilder.Append(ShowErrorMessage(ex.ToString))
            End Try
        Next
    End Sub
    ''' <summary>
    ''' 获取/设置已加载的插件列表。
    ''' </summary>
    ''' <returns><see cref="IEnumerable(Of IPrivateMessageHandler)"/></returns>
    <ImportMany(GetType(IPrivateMessageHandler))>
    Public Property Plugin As IEnumerable(Of IPrivateMessageHandler) = plugins
    Friend Sub New(senderqq As Long, consoletype As PrivateMessageConsoleType, message As String, msgfont As Integer)
        Me.New
        qq = senderqq
        type = consoletype
        msg = Unturn(message)
        font = msgfont
        'msgdate = sendtime
    End Sub
End Class