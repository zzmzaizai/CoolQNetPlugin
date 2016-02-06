Imports System.ComponentModel.Composition
''' <summary>
''' 提供处理群聊消息的接口。
''' </summary>
<InheritedExport(GetType(IGroupMessageHandler))>
Public Interface IGroupMessageHandler
    Inherits ICoolQPlugin
    ''' <summary>
    ''' 处理群内非匿名消息。
    ''' </summary>
    ''' <param name="group">消息来源群号。</param>
    ''' <param name="sender">消息发送者QQ。</param>
    ''' <param name="msg">消息内容。</param>
    ''' <param name="font">消息所用字体。</param>
    ''' <param name="sendtime">消息发送时间。</param>
    ''' <returns><see cref="String"/> 返回处理结果。</returns>
    Function NotAnonymous(group As Long, sender As Long, msg As Long, font As Integer, sendtime As Date) As String
    ''' <summary>
    ''' 处理群内匿名消息。
    ''' </summary>
    ''' <param name="group">匿名消息来源群号。</param>
    ''' <param name="sender">匿名消息发送者代号。</param>
    ''' <param name="aid">匿名用户标识。</param>
    ''' <returns><see cref="String"/> 返回处理结果。</returns>
    Function Anonymous(group As Long, sender As String, aid As Long)
    'Function Result(group As Long, sender As Long, msg As Long, anoymous As String)
End Interface
''' <summary>
''' 提供处理讨论组消息的接口。
''' </summary>
<InheritedExport(GetType(IDiscussGroupMessageHandler))>
Public Interface IDiscussGroupMessageHandler
    ''' <summary>
    ''' 处理讨论组消息，然后返回结果。
    ''' </summary>
    ''' <param name="discuss">消息来源讨论组。</param>
    ''' <param name="sender">消息发送者QQ。</param>
    ''' <param name="msg">消息内容。</param>
    ''' <param name="font">消息使用字体。</param>
    ''' <param name="sendtime">消息发送时间。</param>
    ''' <returns><see cref="String"/></returns>
    Function Result(discuss As Long, sender As Long, msg As String, font As Integer, sendtime As Date) As String
End Interface
''' <summary>
''' 提供处理私聊消息的接口。
''' </summary>
<InheritedExport(GetType(IPrivateMessageHandler))>
Public Interface IPrivateMessageHandler
    Inherits ICoolQPlugin
    ''' <summary>
    ''' 处理私聊消息，然后返回结果。
    ''' </summary>
    ''' <param name="sender">私聊消息发送者。</param>
    ''' <param name="consoletype">私聊会话类型。</param>
    ''' <param name="msg">消息内容。</param>
    ''' <param name="font">消息使用字体。</param>
    ''' <param name="sendtime">消息发送时间。</param>
    ''' <returns><see cref="ReturnCommand"/></returns>
    Function Result(sender As Long, consoletype As PrivateMessageConsoleType, msg As String, font As Integer, sendtime As Date) As ReturnCommand
End Interface
''' <summary>
''' 指示私聊会话形式。
''' </summary>
Public Enum PrivateMessageConsoleType
    ''' <summary>
    ''' 无形式。
    ''' </summary>
    None = 0
    ''' <summary>
    ''' 来自在线状态的临时会话。
    ''' </summary>
    OnlineStatus = 1
    ''' <summary>
    ''' 来自群的临时会话。
    ''' </summary>
    Group = 2
    ''' <summary>
    ''' 来自讨论组的临时会话。
    ''' </summary>
    DiscussGroup = 3
    ''' <summary>
    ''' 好友会话。
    ''' </summary>
    Friends = 11
End Enum
''' <summary>
''' 提供处理管理员变动事件的接口。
''' </summary>
<InheritedExport(GetType(IGroupAdminChangeHandler))>
Public Interface IGroupAdminChangeHandler
    ''' <summary>
    ''' 处理事件，然后返回结果。
    ''' </summary>
    ''' <param name="group">事件发生所在群的群号。</param>
    ''' <param name="becomeadmin">一个指示是否成为管理员的值。
    ''' 该值若为 True，则是成为管理员；若为 False，则是取消管理员。</param>
    ''' <param name="target">被操作QQ。</param>
    ''' <param name="sendtime">事件发生时间。</param>
    ''' <returns><see cref="String"/></returns>
    Function Result(group As Long, becomeadmin As Boolean, target As Long, sendtime As Date) As String
End Interface
''' <summary>
''' 提供处理群成员数量变动事件的接口。
''' </summary>
<InheritedExport(GetType(IGroupMemberChangeHandler))>
Public Interface IGroupMemberChangeHandler
    ''' <summary>
    ''' 处理群成员入群事件，后返回结果。
    ''' </summary>
    ''' <param name="group">事件发生群号。</param>
    ''' <param name="isinvite">指示该成员是否被管理员邀请的值。若为 False，则该群成员的入群申请被管理员同意。</param>
    ''' <param name="qq">新成员QQ。</param>
    ''' <param name="target">处理入群申请的管理员QQ。</param>
    ''' <param name="time">事件发生时间。</param>
    ''' <returns><see cref="String"/></returns>
    Function MemberIncrease(group As Long, isinvite As Boolean, qq As Long, target As Long, time As Date) As String
    ''' <summary>
    ''' 处理群成员减少事件，后返回结果。
    ''' </summary>
    ''' <param name="group">事件发生群号。</param>
    ''' <param name="eventtype">指示事件类型的值。</param>
    ''' <param name="qq">被操作成员QQ。</param>
    ''' <param name="target">处理的管理员QQ。</param>
    ''' <param name="time">事件发生时间。</param>
    ''' <returns><see cref="String"/></returns>
    Function MemberDecrease(group As Long, eventtype As GroupMemberDecreaseType, qq As Long, target As Long, time As Date) As String
End Interface
''' <summary>
''' 指示群成员数量减少事件类型。
''' </summary>
Public Enum GroupMemberDecreaseType
    ''' <summary>
    ''' 无。
    ''' </summary>
    None = 0
    ''' <summary>
    ''' 群成员退群。
    ''' </summary>
    Leave = 1
    ''' <summary>
    ''' 群成员被踢。
    ''' </summary>
    KickedOut = 2
    ''' <summary>
    ''' 登录号码（自己） 被踢。
    ''' </summary>
    WasKickedOut = 3
End Enum