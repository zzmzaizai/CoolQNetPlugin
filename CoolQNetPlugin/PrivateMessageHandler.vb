Imports System.ComponentModel.Composition
Imports System.ComponentModel.Composition.Hosting
Imports System.ComponentModel.Composition.Registration
Imports System.Text

''' <summary>
''' 私聊信息处理器。
''' </summary>
Friend Class PrivateMessageHandler
    Inherits MarshalByRefObject
    Private qq As Long, font As Integer, msgdate As Date
    Private type As PrivateMessageConsoleType
    Private msg As String
    Private cmdbuilder As StringBuilder
    Private plugins As IEnumerable(Of IPrivateMessageHandler)
    ''' <summary>
    ''' 默认构造函数。
    ''' </summary>
    Public Sub New()
        cmdbuilder = New StringBuilder
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
        cmdbuilder.AppendLine(LogInfo("插件加载", String.Format("已在{0}上加载了{1}个插件", AppDomain.CurrentDomain.FriendlyName, plugins.Count.ToString)))
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
            res = p.Result(qq, type, msg, font, msgdate).ToString
            If Not String.IsNullOrWhiteSpace(res) Then
                'cmdbuilder.AppendLine(LogInfo(p.Name, ""))
                cmdbuilder.AppendLine(res)
            End If
        Next
    End Sub
    ''' <summary>
    ''' 获取/设置已加载的插件列表。
    ''' </summary>
    ''' <returns><see cref="IEnumerable(Of IPrivateMessageHandler)"/></returns>
    <ImportMany(GetType(IPrivateMessageHandler))>
    Public Property Plugin As IEnumerable(Of IPrivateMessageHandler) = plugins
    Friend Sub CopyData(senderqq As Long, consoletype As PrivateMessageConsoleType, message As String, msgfont As Integer, sendtime As Date)
        qq = senderqq
        type = consoletype
        msg = message
        font = msgfont
        msgdate = sendtime
    End Sub
End Class