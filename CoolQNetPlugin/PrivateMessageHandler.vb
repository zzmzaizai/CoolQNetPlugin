Imports System.ComponentModel.Composition
Imports System.ComponentModel.Composition.Hosting
Imports System.Text
''' <summary>
''' 私聊信息处理器。
''' </summary>
Friend Class PrivateMessageHandler
    'Implements IDisposable
    Private qq As Long, font As Integer ', msgdate As Date
    Private type As PrivateMessageConsoleType
    Private msg As String, st As Integer
    Private cmdbuilder As StringBuilder
    Private detectedplugins As IEnumerable(Of IPrivateMessageHandler)
    ' Private container As CompositionContainer
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
            'plugins = container.GetExportedValues(Of IPrivateMessageHandler)
            detectedplugins = container.GetExportedValues(Of IPrivateMessageHandler)
        End Using
        If detectedplugins Is Nothing Then
            cmdbuilder.Append(LogInfo("CQ.NET", "没有找到可用的插件。") + Separator)
        Else
            cmdbuilder.Append(LogInfo("CQ.NET", String.Format("已加载{0}个插件", detectedplugins.Count.ToString)))
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
        If detectedplugins Is Nothing Then Return '没有可用插件，返回
        Dim res As String, resc As CommandStorage
        For Each la As IPrivateMessageHandler In detectedplugins
            Try
                'If lzytarget Is Nothing Then Continue For
                If Not HasPermission(la) Then Continue For
                resc = la.Result(qq, type, msg, font, st) '.ToString
                If resc Is Nothing Then Continue For
                res = resc.ToString
                'res 
                If Not String.IsNullOrWhiteSpace(res) Then
                    cmdbuilder.Append(res)
                End If
                If la.IsIntercept Then
                    cmdbuilder.Append(LogInfo("CQ.NET", "私聊消息已被 " + la.Name + " 拦截。"))
                    Exit For
                End If
            Catch ex As Exception
                ReportError(ex, la)
                cmdbuilder.Append(ShowErrorMessage("执行插件代码时遭遇异常，详见错误报告文件。"))
                'Exit For
            End Try
        Next
        'container.Dispose() '释放资源
    End Sub

    Friend Sub New(senderqq As Long, consoletype As PrivateMessageConsoleType, message As String, msgfont As Integer, sendtime As Integer)
        Me.New
        qq = senderqq
        type = consoletype
        msg = Unturn(message)
        font = msgfont
        st = sendtime
    End Sub
    Private Shared Function HasPermission(plu As IPrivateMessageHandler) As Boolean
        Return plu.Permissions.HasFlag(PluginPermissions.PrivateMessage)
    End Function

End Class