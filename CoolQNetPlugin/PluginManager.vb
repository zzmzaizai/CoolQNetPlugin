Imports System.Runtime.InteropServices
Imports System.IO

<Assembly: CLSCompliant(True)>
''' <summary>
''' CoolQ .NET 插件中继站。
''' </summary>
<ComClass(PluginRelayStation.ClassId, PluginRelayStation.InterfaceId, PluginRelayStation.EventsId)>
<ComVisible(True)>
Public Class PluginRelayStation
    'Private container As CompositionContainer 
    ' Private dircatalog As DirectoryCatalog
#Region "COM GUID"
    ' 这些 GUID 提供此类的 COM 标识 
    ' 及其 COM 接口。若更改它们，则现有的
    ' 客户端将不再能访问此类。
    Public Const ClassId As String = "9eb55baf-db14-45bb-a976-e78227b64bef"
    Public Const InterfaceId As String = "16dc83d3-21da-47d5-872a-8ea5c7e2425c"
    Public Const EventsId As String = "5bc4ce5b-f0c8-4c51-8f62-a801832ff090"
#End Region

    ' 可创建的 COM 类必须具有一个不带参数的 Public Sub New() 
    ' 否则， 将不会在 
    ' COM 注册表中注册此类，且无法通过
    ' CreateObject 创建此类。
    ''' <summary>
    ''' 默认构造函数。
    ''' </summary>
    <Obsolete("该方法是 COM 类的支持方法，.NET 类不应该使用该方法。")>
    Public Sub New()
        MyBase.New()
        'pp = AppDomain.CurrentDomain.BaseDirectory + "Extensions"
    End Sub
    ''' <summary>
    ''' 设置数据存储目录。
    ''' </summary>
    ''' <param name="path">数据存储目录路径。</param>
    Public Sub SetDataPath(path As String)
        If Not My.Computer.FileSystem.DirectoryExists(path) Then Return
        PluginSetting.Default.DataPath = path
        Dim sdd As String = My.Computer.FileSystem.CombinePath(path, "DisabledPlugin.txt")
        If Not My.Computer.FileSystem.FileExists(sdd) Then
            Using sw As New StreamWriter(sdd)
                sw.Write(String.Empty)
            End Using
        End If
        PluginSetting.Default.DisabledPlugin = sdd
        PluginSetting.Default.Save()
    End Sub
    ''' <summary>
    ''' 处理私聊消息，然后返回结果。
    ''' </summary>
    ''' <param name="qq">私聊消息发送者。</param>
    ''' <param name="type">私聊会话类型。</param>
    ''' <param name="msg">消息内容。</param>
    ''' <param name="font">消息使用字体。</param>
    ''' <param name="sendtime">消息发送时间。</param>
    ''' <returns><see cref="String"/></returns>
    <CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")>
    Public Function ProcessPrivateMessage(qq As Long, type As Integer, msg As String, font As Integer, sendtime As Date) As String
        Dim pmh As New PrivateMessageHandler(qq, type, msg, font, sendtime)
        Try
            CheckDirectory()
            Isolated(Of PrivateMessageHandler)("PrivateMessagePluginDomain")
            pmh.Compose()
            pmh.DoWork()
            Return pmh.Command
        Catch ex As Exception
            Return ShowErrorMessage(ex.ToString)
        End Try
    End Function

    Private Shared Sub CheckDirectory()
        If Not Directory.Exists(ShadowCopyPath) Then Directory.CreateDirectory(ShadowCopyPath)
        If Not Directory.Exists(PluginPath) Then Directory.CreateDirectory(PluginPath)
    End Sub
    Private Sub Isolated(Of T)(ByVal domainname As String)
        If String.IsNullOrWhiteSpace(domainname) Then domainname = Path.GetRandomFileName
        Dim setup As New AppDomainSetup With {.CachePath = ShadowCopyPath,
            .ShadowCopyDirectories = PluginPath, .ShadowCopyFiles = "true"}
        Dim domain As AppDomain = AppDomain.CreateDomain(domainname, Nothing, setup)
        Dim handler As T = domain.CreateInstanceAndUnwrap(GetType(T).Assembly.FullName, GetType(T).FullName)

    End Sub

End Class


