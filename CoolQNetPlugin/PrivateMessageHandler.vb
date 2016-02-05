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
    Friend Sub New(qq As Long, type As PrivateMessageConsoleType, msg As String, font As Integer, sendtime As Date)
        Me.qq = qq
        Me.type = type
        Me.msg = msg
        msgdate = sendtime
        'finalcmd = String.Empty
        cmdbuilder = New StringBuilder
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
            plugins = container.GetExportedValue(Of IPrivateMessageHandler)
            'container.ComposeExportedValue(Of IPrivateMessageHandler)
        End Using
        cmdbuilder.AppendLine(LogInfo("CQ.NET", String.Format("已在{0}上加载了{1}个插件", AppDomain.CurrentDomain.FriendlyName, plugins.Count.ToString)))
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

            res = p.Result(qq, type, msg, font, msgdate)
            If Not String.IsNullOrWhiteSpace(res) Then
                cmdbuilder.AppendLine(res)
            End If
        Next
    End Sub
End Class