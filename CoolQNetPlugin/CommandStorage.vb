Imports System.Text
''' <summary>
''' 返回一个存储着命令的存储器。
''' </summary>
Public Class CommandStorage
    Private sb As StringBuilder
    Private inter As Boolean
    Private tar As ICoolQPlugin
    ''' <summary>
    ''' 使用指定插件初始化 <see cref="CommandStorage "/> 的新实例。
    ''' </summary>
    ''' <param name="plugin"></param>
    Public Sub New(plugin As ICoolQPlugin)
        tar = plugin
        sb = New StringBuilder
    End Sub
    ''' <summary>
    ''' 获取该命令寄存器的储存的所有命令。
    ''' </summary>
    ''' <returns><see cref="String"/></returns>
    Public Overrides Function ToString() As String
        Return sb.ToString()
    End Function
    ''' <summary>
    ''' 追加发送私聊消息命令。
    ''' </summary>
    ''' <param name="qq">目标QQ。</param>
    ''' <param name="msg">消息内容。</param>
    Public Sub AppendSendPrivateMessageCommand(qq As Long, msg As String)
        If Not tar.Permissions.HasFlag(PluginPermissions.PrivateMessage) Then
            AppendLEC("CQ.NET", "已拒绝" + tar.Name + "发送私聊消息的请求，该插件并未请求此权限。")
            Return
        End If
        sb.Append(SendPrivateMessage(qq, Turn(msg)))
    End Sub
    ''' <summary>
    ''' 追加发送群聊消息命令。
    ''' </summary>
    ''' <param name="group">目标群号。</param>
    ''' <param name="msg">消息内容。</param>
    Public Sub AppendSendGroupMessageCommand(group As Long, msg As String)
        If Not tar.Permissions.HasFlag(PluginPermissions.GroupMessage) Then
            AppendLEC("CQ.NET", "已拒绝" + tar.Name + "发送群聊消息的请求，该插件并未请求此权限。")
            Return
        End If
        sb.Append(SendGroupMessage(group, Turn(msg)))
    End Sub
    ''' <summary>
    ''' 追加发送讨论组消息命令。
    ''' </summary>
    ''' <param name="discussgroup">目标讨论组。</param>
    ''' <param name="msg">消息内容。</param>
    Public Sub AppendSendDiscussGroupMessageCommand(discussgroup As Long, msg As String)
        If Not tar.Permissions.HasFlag(PluginPermissions.DiscussGroupMessage) Then
            AppendLEC("CQ.NET", "已拒绝" + tar.Name + "发送讨论组消息的请求，该插件并未请求此权限。")
            Return
        End If
        sb.Append(SendDiscussGroupMessage(discussgroup, msg))
    End Sub
    ''' <summary>
    ''' 追加信息日志消息的命令。
    ''' </summary>
    ''' <param name="msg">消息内容。</param>
    Public Sub AppendLogInfoCommand(msg As String)
        sb.Append(LogInfo(tar.Name, msg))
    End Sub
    ''' <summary>
    ''' 追加错误日志消息的命令。
    ''' </summary>
    ''' <param name="msg">消息内容。</param>
    Public Sub AppendLogErrorCommand(msg As String)
        sb.Append(LogError(tar.Name, msg))
    End Sub
    Private Sub AppendLEC(source As String, msg As String)
        sb.Append(LogWarn(source, msg))
    End Sub
    ''' <summary>
    ''' 追加调试日志消息的命令。
    ''' </summary>
    ''' <param name="msg">消息内容。</param>
    Public Sub AppendLogDebugCommand(msg As String)
        sb.Append(LogDebug(tar.Name, msg))
    End Sub
    ''' <summary>
    ''' 追加警告日志消息的命令。
    ''' </summary>
    ''' <param name="msg">消息内容。</param>
    Public Sub AppendLogWarningCommand(msg As String)
        sb.Append(LogWarn(tar.Name, msg))
    End Sub
    ''' <summary>
    ''' 获取/设置是否拦截消息的值。
    ''' </summary>
    ''' <returns><see cref="Boolean"/></returns>
    ''' <remarks>一旦该值设置为 True，就不能改变这个值。</remarks>
    Public Property Intercept As Boolean
        Get
            Return inter
        End Get
        Set(value As Boolean)
            If inter Then Return
            If value Then
                'sb.Append(LogInfo("CQ.NET", "消息已被" + tar.Name + "拦截。"))
                inter = value
            End If
        End Set
    End Property
    ''' <summary>
    ''' 追加接收语音的命令。
    ''' </summary>
    ''' <param name="filename">音频文件名。</param>
    ''' <param name="format">音频格式。</param>
    Public Sub AppendReceiveRecordCommand(ByVal fileName As String, ByVal format As String)
        sb.Append("接收语音|文件名=" + fileName + "|文件格式=" + format + Separator)
    End Sub
    ''' <summary>
    ''' 追加禁言的命令。
    ''' </summary>
    ''' <param name="group">目标群。</param>
    ''' <param name="qq">目标QQ。</param>
    ''' <param name="time">禁言时间（单位：秒）。</param>
    Public Sub AppendDisabledSendMsgCommand(group As Long, qq As Long, time As Integer)
        If Not tar.Permissions.HasFlag(PluginPermissions.DisabledSendMsg) Then
            AppendLEC("CQ.NET", "已拒绝" + tar.Name + "的群成员禁言请求，该插件并未请求此权限。")
            Return
        End If
        sb.Append("禁言|群号=" + group.ToString + "|QQ=" + qq.ToString + "|时长=" + time.ToString + Separator)
    End Sub
    ''' <summary>
    ''' 追加群成员移除的命令。
    ''' </summary>
    ''' <param name="group">目标群号。</param>
    ''' <param name="qq">目标QQ。</param>
    Public Sub AppendKickOutMemberCommand(group As Long, qq As Long, nolonger As Boolean)
        If Not tar.Permissions.HasFlag(PluginPermissions.KickMemberOut) Then
            AppendLEC("CQ.NET", "已拒绝" + tar.Name + "的群T人请求，该插件并未请求此权限。")
            Return
        End If
        sb.Append(If(nolonger, "永久T", "T") + "|group=" + group.ToString + "|qq=" + qq.ToString + Separator)
    End Sub
    ''' <summary>
    ''' 追加更改群成员名片的命令。
    ''' </summary>
    ''' <param name="group">目标群号。</param>
    ''' <param name="qq">目标QQ。</param>
    ''' <param name="newname">新名片内容。</param>
    Public Sub AppendChangeNameCommand(group As Long, qq As Long, newname As String)
        If Not tar.Permissions.HasFlag(PluginPermissions.GroupMemberName) Then
            AppendLEC("CQ.NET", "已拒绝" + tar.Name + "的改马甲请求，该插件并未请求此权限。")
        End If
        sb.Append("改名字|群=" + group.ToString + "|QQ=" + qq.ToString + "|新马甲=" + newname + Separator)
    End Sub
End Class
