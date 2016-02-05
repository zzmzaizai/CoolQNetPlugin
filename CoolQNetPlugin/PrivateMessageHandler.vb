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
    ''' 使用接收的 <see cref="PluginRelayStation.ProcessPrivateMessage(Long, Integer, String, Integer, Date) "/>
    ''' 初始化 <see cref="PrivateMessageHandler "/> 的新实例。
    ''' </summary>
    ''' <param name="qq">消息发送者QQ</param>
    ''' <param name="type">私聊会话类型。</param>
    ''' <param name="msg">私聊信息内容。</param>
    ''' <param name="font">私聊字体类型。</param>
    ''' <param name="sendtime">消息发送时间。</param>
    Public Sub New(qq As Long, type As PrivateMessageConsoleType, msg As String, font As Integer, sendtime As Date)
        Me.qq = qq
        Me.type = type
        Me.msg = msg
        msgdate = sendtime
        'finalcmd = String.Empty
        cmdbuilder = New StringBuilder
        plugins = New List(Of IPrivateMessageHandler)
    End Sub
    ''' <summary>
    ''' 默认构造函数。
    ''' </summary>
    <Obsolete("该方法仅用于跨域进程创建，请调用另外一个有参数的构造函数。")>
    Public Sub New()
        Me.New(-1, PrivateMessageConsoleType.None, String.Empty, -1, Date.MinValue)
    End Sub
    ''' <summary>
    ''' 在独立的 <see cref="AppDomain"/> 里组合插件。
    ''' </summary>
    ''' <remarks>本部分代码参照
    ''' http://www.codeproject.com/Articles/633140/MEF-and-AppDomain-Remove-Assemblies-On-The-Fly </remarks>
    Public Sub Compose()
        Dim regbuilder As New RegistrationBuilder
        regbuilder.ForTypesDerivedFrom(Of IPrivateMessageHandler).Export(Of IPrivateMessageHandler)()
        Dim catalog As New AggregateCatalog
        Dim asscatalog As New AssemblyCatalog(GetType(PrivateMessageHandler).Assembly, regbuilder)
        Dim dircatalog As New DirectoryCatalog(PluginPath, regbuilder)
        catalog.Catalogs.Add(asscatalog)
        catalog.Catalogs.Add(dircatalog)
        Using container As New CompositionContainer(catalog)
            container.ComposeExportedValue(container)
            Try
                plugins = container.GetExportedValues(Of IPrivateMessageHandler)
            Catch ex As Exception
                container.ComposeParts(Me)
            End Try

            'container.ComposeExportedValue(Of IPrivateMessageHandler)
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
            res = p.Result(qq, type, msg, font, msgdate)
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
    <Obsolete("该方法仅供 .NET 内部调用，外部方法不要调用此方法。")>
    Public Property Plugin As IEnumerable(Of IPrivateMessageHandler) = plugins
End Class