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
    ''' 获取该插件的描述。
    ''' </summary>
    ''' <returns><see cref="String"/></returns>
    ReadOnly Property Description As String
End Interface
''' <summary>
''' 代表插件请求的权限。
''' </summary>
<Flags>
Public Enum PluginPermissions
    ''' <summary>
    ''' 无权限，默认为该值。
    ''' </summary>
    None = 0
    ''' <summary>
    ''' 插件需要获取处理私聊消息的权限。
    ''' </summary>
    PrivateMessage = 1
    ''' <summary>
    ''' 插件需要获取处理讨论组消息的权限。
    ''' </summary>
    DiscussGroupMessage = 2
    ''' <summary>
    ''' 插件需要获取处理群消息的权限。
    ''' </summary>
    GroupMessage = 4
    ''' <summary>
    ''' 插件需要获取处理群管理员变动事件的权限。
    ''' </summary>
    GroupAdmin = 8
    ''' <summary>
    ''' 插件需要获取处理群成员变动事件的权限。
    ''' </summary>
    GroupMemberChange = 16
    ''' <summary>
    ''' 插件需要获取更改群成员名片的权限。
    ''' </summary>
    GroupMemberName = 32
    ''' <summary>
    ''' 插件需要获取账号 Cookies 和 CrfsToken 的权限。
    ''' </summary>
    Cookies = 64
    ''' <summary>
    ''' 插件需要获取群成员信息的权限。
    ''' </summary>
    GroupMemberInfo = 128
    ''' <summary>
    ''' 插件需要获取禁言群成员的权限。
    ''' </summary>
    DisabledSendMsg = 256
    ''' <summary>
    ''' 插件需要获取踢出群成员的权限。
    ''' </summary>
    KickMemberOut = 512
    ''' <summary>
    ''' 插件需要获取发送赞的权限。
    ''' </summary>
    SendGood = 1024
    ''' <summary>
    ''' 插件需要获取授予群成员专属头衔的权限。
    ''' </summary>
    GiveMemberName = 2048
    ''' <summary>
    ''' 插件需要获取所有可以获取的权限。
    ''' </summary>
    All = PrivateMessage Or DiscussGroupMessage Or
        GroupAdmin Or GroupMemberChange Or
        GroupMemberName Or GroupMessage Or Cookies Or
        DisabledSendMsg Or GroupMemberInfo Or
        KickMemberOut Or SendGood Or GiveMemberName
End Enum
''' <summary>
''' 提供处理加载插件时的事件。
''' </summary>
<InheritedExport(GetType(ILoadPlugin))>
Public Interface ILoadPlugin
    Inherits ICoolQPlugin
    ''' <summary>
    ''' 处理加载插件事件。
    ''' </summary>
    Sub OnLoad()
End Interface
''' <summary>
''' 提供处理退出 CoolQ 时的事件。
''' </summary>
<InheritedExport(GetType(ICoolQExiting))>
Public Interface ICoolQExiting
    Inherits ICoolQPlugin
    ''' <summary>
    ''' 处理 CoolQ 退出事件。
    ''' </summary>
    Sub OnExiting()
End Interface
''' <summary>
''' 提供获取QQ Cookies 的接口。
''' </summary>
<InheritedExport(GetType(IGetCookies))>
Public Interface IGetCookies
    Inherits ICoolQPlugin
    ''' <summary>
    ''' 获取用户 Cookies。
    ''' </summary>
    Sub GetCookies()
    ''' <summary>
    ''' 获取用户 CstrfToken。
    ''' </summary>
    Sub GetCstrfToken()
End Interface