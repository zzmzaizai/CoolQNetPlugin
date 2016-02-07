Imports System.ComponentModel.Composition
Imports System.ComponentModel.Composition.Hosting
Imports System.Text

''' <summary>
''' 私聊信息处理器。
''' </summary>
Friend Class PrivateMessageHandler
    Implements IDisposable

    Private qq As Long, font As Integer ', msgdate As Date
    Private type As PrivateMessageConsoleType
    Private msg As String
    Private cmdbuilder As StringBuilder
    Private plugins As IEnumerable(Of IPrivateMessageHandler)
    Private container As CompositionContainer
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
        container = New CompositionContainer(dircatalog)
        container.ComposeParts(Me)
        plugins = container.GetExportedValues(Of IPrivateMessageHandler)
        If plugins Is Nothing Then
            cmdbuilder.AppendLine(LogInfo("CQ.NET", "没有找到可用的插件。") + Separator)
        Else
            cmdbuilder.AppendLine(LogInfo("CQ.NET", String.Format("已加载{0}个插件", plugins.Count.ToString)) + Separator)
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
                        cmdbuilder.Append(LogInfo("CQ.NET", "消息已被 " + p.Name + " 拦截。") + Separator)
                    End If
                    cmdbuilder.Append(res + Separator)
                End If
            Catch ex As Exception
                cmdbuilder.Append(ShowErrorMessage(ex.ToString))
            End Try
        Next
        container.Dispose()
    End Sub

    Friend Sub New(senderqq As Long, consoletype As PrivateMessageConsoleType, message As String, msgfont As Integer)
        Me.New
        qq = senderqq
        type = consoletype
        msg = Unturn(message)
        font = msgfont
        'msgdate = sendtime
    End Sub

#Region "IDisposable Support"
    Private disposedValue As Boolean ' 要检测冗余调用

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                ' TODO: 释放托管状态(托管对象)。
                container.Dispose()
                plugins = Nothing
            End If

            ' TODO: 释放未托管资源(未托管对象)并在以下内容中替代 Finalize()。
            ' TODO: 将大型字段设置为 null。
        End If
        disposedValue = True
    End Sub

    ' TODO: 仅当以上 Dispose(disposing As Boolean)拥有用于释放未托管资源的代码时才替代 Finalize()。
    'Protected Overrides Sub Finalize()
    '    ' 请勿更改此代码。将清理代码放入以上 Dispose(disposing As Boolean)中。
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' Visual Basic 添加此代码以正确实现可释放模式。
    Public Sub Dispose() Implements IDisposable.Dispose
        ' 请勿更改此代码。将清理代码放入以上 Dispose(disposing As Boolean)中。
        Dispose(True)
        ' TODO: 如果在以上内容中替代了 Finalize()，则取消注释以下行。
        ' GC.SuppressFinalize(Me)
    End Sub
#End Region
End Class