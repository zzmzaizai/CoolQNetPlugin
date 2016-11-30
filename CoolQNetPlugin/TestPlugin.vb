''' <summary>
''' 酷Q.NET测试插件。
''' </summary>
Public NotInheritable Class TestPlugin

    Private Const ApiVersion As Integer = 9 'Api版本号，若酷Q官方SDK没有更新此版本号，请勿改动此值
    'AppID 
    Private Const AppId As String = "com.net.hotplug.test"
    Private Sub New()

    End Sub
    ''' <summary>
    ''' 此函数会在插件被开启时发生。
    ''' </summary>
    ''' <returns><see cref="Integer"/> 返回处理过程是否成功的值。</returns>
    <DllExport("_eventEnable")>
    Public Shared Function Enabled() As Integer
        Return 0
    End Function
    ''' <summary>
    ''' 此函数会在插件被禁用时发生。
    ''' </summary>
    ''' <returns><see cref="Integer"/> 返回处理过程是否成功的值。</returns>
    <DllExport("_eventDisable")>
    Public Shared Function Disabled() As Integer

        Return 0
    End Function
    ''' <summary>
    ''' 向酷Q提供插件信息。
    ''' </summary>
    ''' <returns><see cref="String"/> 一个固定格式字符串。</returns>
    <DllExport("AppInfo")>
    Public Shared Function AppInfo() As String
        '请勿修改此函数
        Return (ApiVersion.ToString + "," + AppId)
    End Function
    ''' <summary>
    ''' 获取此插件的AuthCode。
    ''' </summary>
    ''' <param name="authcode">由酷Q提供的AuthCode。</param>
    ''' <returns><see cref="Integer"/> </returns>
    <DllExport("Initialize", Runtime.InteropServices.CallingConvention.StdCall)>
    Public Shared Function Initialize(authcode As Integer) As Integer
        '请勿更改此函数
        CQ.SetAuthCode(authcode)
        Return 0 '固定返回0
    End Function
    ''' <summary>
    ''' 此函数会在酷Q退出时被调用。
    ''' </summary>
    ''' <returns><see cref="Integer"/> </returns>
    <DllExport("_eventExit", Runtime.InteropServices.CallingConvention.StdCall)>
    Public Shared Function CoolQExited() As Integer

        Return 0 '固定返回0
    End Function
    ''' <summary>
    ''' 处理私聊消息。
    ''' </summary>
    ''' <param name="subType">私聊消息类型。11代表消息来自好友；1代表消息来自在线状态；2代表消息来自群；3代表消息来自讨论组。</param>
    ''' <param name="sendTime">消息发送时间的时间戳。</param>
    ''' <param name="fromQQ">发送此消息的QQ号码。</param>
    ''' <param name="msg">消息的内容。</param>
    ''' <param name="font">消息所使用的字体。</param>
    ''' <returns><see cref="Integer"/> 是否拦截消息的值，0为忽略消息，1为拦截消息。</returns>
    <DllExport("_eventPrivateMsg", Runtime.InteropServices.CallingConvention.StdCall)>
    Public Shared Function ProcessPrivateMessage(subType As Integer, sendTime As Integer, fromQQ As Long, msg As String, font As Integer) As Integer
        '0为忽略 1为拦截

        Return 0
    End Function
    ''' <summary>
    ''' 处理群聊消息。
    ''' </summary>
    ''' <param name="subType">消息类型，目前固定为1。</param>
    ''' <param name="sendTime">消息发送时间的时间戳。</param>
    ''' <param name="fromGroup">消息来源群号。</param>
    ''' <param name="fromQQ">发送此消息的QQ号码。</param>
    ''' <param name="fromAnonymous">发送此消息的匿名用户。</param>
    ''' <param name="msg">消息内容。</param>
    ''' <param name="font">消息所使用字体。</param>
    ''' <returns><see cref="Integer"/> 是否拦截消息的值，0为忽略消息，1为拦截消息。</returns>
    <DllExport("_eventGroupMsg", Runtime.InteropServices.CallingConvention.StdCall)>
    Public Shared Function ProcessGroupMessage(subType As Integer, sendTime As Integer, fromGroup As Long, fromQQ As Long, fromAnonymous As String,
                                               msg As String, font As Integer) As Integer
        '0为忽略 1为拦截

        Return 0
    End Function
    ''' <summary>
    ''' 处理讨论组消息。
    ''' </summary>
    ''' <param name="subType">消息类型，目前固定为1。</param>
    ''' <param name="sendTime">消息发送时间的时间戳。</param>
    ''' <param name="fromDiscuss">消息来源讨论组号。</param>
    ''' <param name="fromQQ">发送此消息的QQ号码。</param>
    ''' <param name="msg">消息内容。</param>
    ''' <param name="font">消息所使用字体。</param>
    ''' <returns><see cref="Integer"/> 是否拦截消息的值，0为忽略消息，1为拦截消息。</returns>
    <DllExport("_eventDiscussMsg", Runtime.InteropServices.CallingConvention.StdCall)>
    Public Shared Function ProcessDiscussGroupMessage(subType As Integer, sendTime As Integer, fromDiscuss As Long, fromQQ As Long, msg As String, font As Integer) As Integer
        '0为忽略 1为拦截

        Return 0
    End Function
    ''' <summary>
    ''' 处理群文件上传事件。
    ''' </summary>
    ''' <param name="subType">消息类型，目前固定为1。</param>
    ''' <param name="sendTime">事件发生时间的时间戳。</param>
    ''' <param name="fromGroup">事件来源群号。</param>
    ''' <param name="fromQQ">上传此文件的QQ号码。</param>
    ''' <param name="file">上传的文件的信息。</param>
    ''' <returns><see cref="Integer"/> 是否拦截消息的值，0为忽略消息，1为拦截消息。</returns>
    <DllExport("_eventGroupUpload", Runtime.InteropServices.CallingConvention.StdCall)>
    Public Shared Function ProcessGroupUpload(subType As Integer, sendTime As Integer, fromGroup As Long, fromQQ As Long, file As String) As Integer
        Return 0
    End Function
    ''' <summary>
    ''' 处理群管理员变动事件。
    ''' </summary>
    ''' <param name="subType">事件类型。1为被取消管理员，2为被设置管理员。</param>
    ''' <param name="sendTime">事件发生时间的时间戳。</param>
    ''' <param name="fromGroup">事件来源群号。</param>
    ''' <param name="target">被操作的QQ。</param>
    ''' <returns><see cref="Integer"/> 是否拦截消息的值，0为忽略消息，1为拦截消息。</returns>
    <DllExport("_eventSystem_GroupAdmin", Runtime.InteropServices.CallingConvention.StdCall)>
    Public Shared Function ProcessGroupAdminChange(subType As Integer, sendTime As Integer, fromGroup As Long, target As Long) As Integer
        Return 0
    End Function
    ''' <summary>
    ''' 处理群成员数量减少事件。
    ''' </summary>
    ''' <param name="subType">事件类型。1为群员离开；2为群员被踢为；3为自己(即登录号)被踢。</param>
    ''' <param name="sendTime">事件发生时间的时间戳。</param>
    ''' <param name="fromGroup">事件来源群号。</param>
    ''' <param name="fromQQ">事件来源QQ。</param>
    ''' <param name="target">被操作的QQ。</param>
    ''' <returns><see cref="Integer"/> 是否拦截消息的值，0为忽略消息，1为拦截消息。</returns>
    <DllExport("_eventSystem_GroupMemberDecrease", Runtime.InteropServices.CallingConvention.StdCall)>
    Public Shared Function ProcessGroupMemberDecrease(subType As Integer, sendTime As Integer, fromGroup As Long, fromQQ As Long, target As Long) As Integer
        Return 0
    End Function
    ''' <summary>
    ''' 处理群成员添加事件。
    ''' </summary>
    ''' <param name="subType">事件类型。1为管理员已同意；2为管理员邀请。</param>
    ''' <param name="sendTime">事件发生时间的时间戳。</param>
    ''' <param name="fromGroup">事件来源群号。</param>
    ''' <param name="fromQQ">事件来源QQ。</param>
    ''' <param name="target">被操作的QQ。</param>
    ''' <returns><see cref="Integer"/> 是否拦截消息的值，0为忽略消息，1为拦截消息。</returns>
    <DllExport("_eventSystem_GroupMemberIncrease", Runtime.InteropServices.CallingConvention.StdCall)>
    Public Shared Function ProcessGroupMemberIncrease(subType As Integer, sendTime As Integer, fromGroup As Long, fromQQ As Long, target As Long) As Integer
        Return 0
    End Function
    ''' <summary>
    ''' 处理好友已添加事件。
    ''' </summary>
    ''' <param name="subType">事件类型。固定为1。</param>
    ''' <param name="sendTime">事件发生时间的时间戳。</param>
    ''' <param name="fromQQ">事件来源QQ。</param>
    ''' <returns><see cref="Integer"/> 是否拦截消息的值，0为忽略消息，1为拦截消息。</returns>
    <DllExport("_eventFriend_Add", Runtime.InteropServices.CallingConvention.StdCall)>
    Public Shared Function ProcessFriendsAdded(subType As Integer, sendTime As Integer, fromQQ As Long) As Integer
        Return 0
    End Function
    ''' <summary>
    ''' 处理好友添加请求。
    ''' </summary>
    ''' <param name="subType">事件类型。固定为1。</param>
    ''' <param name="sendTime">事件发生时间的时间戳。</param>
    ''' <param name="fromQQ">事件来源QQ。</param>
    ''' <param name="msg">附言内容。</param>
    ''' <param name="font">消息所使用字体。</param>
    ''' <returns><see cref="Integer"/> 是否拦截消息的值，0为忽略消息，1为拦截消息。</returns>
    <DllExport("_eventRequest_AddFriend", Runtime.InteropServices.CallingConvention.StdCall)>
    Public Shared Function ProcessAddFriendRequest(subType As Integer, sendTime As Integer, fromQQ As Long, msg As String, font As Integer) As Integer
        Return 0
    End Function
    ''' <summary>
    ''' 处理加群请求。
    ''' </summary>
    ''' <param name="subType">请求类型。1为他人申请入群；2为自己(即登录号)受邀入群。</param>
    ''' <param name="sendTime">请求发送时间戳。</param>
    ''' <param name="fromGroup">要加入的群的群号。</param>
    ''' <param name="fromQQ">发送此请求的QQ号码。</param>
    ''' <param name="msg">附言内容。</param>
    ''' <param name="responseMark">用于处理请求的标识。</param>
    ''' <returns><see cref="Integer"/> 是否拦截消息的值，0为忽略消息，1为拦截消息。</returns>
    <DllExport("_eventRequest_AddGroup", Runtime.InteropServices.CallingConvention.StdCall)>
    Public Shared Function ProcessJoinGroupRequest(subType As Integer, sendTime As Integer, fromGroup As Long, fromQQ As Long, msg As String, responseMark As String) As Integer
        Return 0
    End Function
    '菜单示例
    '假设菜单中在json文件中的设置如下
    '{
    '        "name""设置A",			//菜单名称
    '       "function":"_menuA"		//菜单对应函数
    '}
    '则
    '<DllExport("菜单对应函数")>
    'Public Shared Function <执行过程名称>() As Integer
    '    Return 0 '固定返回0
    'End Function
End Class
