Imports System.ComponentModel.Composition
''' <summary>
''' 提供 .NET CoolQ 插件基本信息的接口。
''' </summary>
<InheritedExport(GetType(ICoolQPlugin))>
Public Interface ICoolQPlugin
    ''' <summary>
    ''' 获取该插件的 <see cref="Guid"/> 识别号。
    ''' </summary>
    ''' <returns><see cref="Guid"/></returns>
    ReadOnly Property Id As Guid
    ''' <summary>
    ''' 获取该插件的名称。
    ''' </summary>
    ''' <returns><see cref="String"/></returns>
    ReadOnly Property Name As String
    ''' <summary>
    ''' 获取插件要用到的权限。
    ''' </summary>
    ''' <returns><see cref="PluginPermissions"/></returns>
    ReadOnly Property Permissions As PluginPermissions
    ''' <summary>
    ''' 打开该插件的设置窗口。
    ''' </summary>
    Sub Setting()
    ''' <summary>
    ''' 插件被禁用时发生的事件。
    ''' </summary>
    Sub OnDisabled()
    ''' <summary>
    ''' 插件被启用后发生的事件。
    ''' </summary>
    Sub OnEnabled()
    ''' <summary>
    ''' 插件加载时事件。
    ''' </summary>
    Sub OnLoaded()
    ''' <summary>
    ''' 插件退出时的事件。
    ''' </summary>
    Sub OnExited()
    ''' <summary>
    ''' 获取该插件的描述。
    ''' </summary>
    ''' <returns></returns>
    ReadOnly Property Description As String
End Interface
''' <summary>
''' 表明插件要获取的权限。
''' </summary>
<Flags>
Public Enum PluginPermissions
    ''' <summary>
    ''' 无权限，默认为该值。
    ''' </summary>
    None = 0
    ''' <summary>
    ''' 处理私聊消息的权限。
    ''' </summary>
    PrivateMessage = 1
    ''' <summary>
    ''' 处理讨论组消息的权限。
    ''' </summary>
    DiscussGroupMessage = 2
    ''' <summary>
    ''' 处理群消息的权限。
    ''' </summary>
    GroupMessage = 4
    ''' <summary>
    ''' 处理群管理员变动事件。
    ''' </summary>
    GroupAdmin = 8
    ''' <summary>
    ''' 处理群成员变动事件。
    ''' </summary>
    GroupMember = 16
    ''' <summary>
    ''' 获取群成员信息的权限。
    ''' </summary>
    GroupMemberInfo = 32
    ''' <summary>
    ''' 获取所有权限。
    ''' </summary>
    All = PrivateMessage Or DiscussGroupMessage Or GroupAdmin Or GroupMember Or GroupMemberInfo Or GroupMessage
End Enum
