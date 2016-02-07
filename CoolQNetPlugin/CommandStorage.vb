Imports System.Text
''' <summary>
''' 返回命令存储器。
''' </summary>
Public Class CommandStorage
    Private sb As StringBuilder
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
        sb.Append(SendPrivateMessage(qq, Turn(msg)))
    End Sub
    ''' <summary>
    ''' 追加发送群聊消息命令。
    ''' </summary>
    ''' <param name="group">目标群号。</param>
    ''' <param name="msg">消息内容。</param>
    Public Sub AppendSendGroupMessageCommand(group As Long, msg As String)
        sb.Append(SendGroupMessage(group, Turn(msg)))
    End Sub
    ''' <summary>
    ''' 追加发送讨论组消息命令。
    ''' </summary>
    ''' <param name="discussgroup">目标讨论组。</param>
    ''' <param name="msg">消息内容。</param>
    Public Sub AppendSendDiscussGroupMessageCommand(discussgroup As Long, msg As String)
        sb.Append(SendDiscussGroupMessage(discussgroup, msg))
    End Sub
End Class
