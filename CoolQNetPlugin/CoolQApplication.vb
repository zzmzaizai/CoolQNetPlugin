''' <summary>
''' 表示酷Q应用模块提供的方法。
''' </summary>
Public Module CoolQApplication
    ''' <summary>
    ''' 获取@QQ的代码，只能在群内用。
    ''' </summary>
    ''' <param name="qq">要@的QQ。</param>
    ''' <returns><see cref="String"/></returns>
    Public Function At(qq As Integer) As String
        Return "[CQ:at,qq=" + qq.ToString + "]"
    End Function
    ''' <summary>
    ''' 获取对应 ID 的 Emoji 代码字符串。
    ''' </summary>
    ''' <param name="id">Emoji 表情 ID。</param>
    ''' <returns><see cref="String"/></returns>
    Public Function Emoji(id As Integer) As String
        Return "[CQ:emoji,id=" + id.ToString + "]"
    End Function
    ''' <summary>
    ''' 获取对应 ID 的表情代码字符串。
    ''' </summary>
    ''' <param name="id">表情 ID。</param>
    ''' <returns><see cref="String"/></returns>
    Public Function Expression(id As Integer) As String
        Return "[CQ:face,id=" + id.ToString + "]"
    End Function
    ''' <summary>
    ''' 获取匿名代码字符串。
    ''' </summary>
    ''' <returns><see cref="String"/></returns>
    Public Function Anonymous() As String
        Return "[CQ:anonymous]"
    End Function
    ''' <summary>
    ''' 获取匿名代码字符串。
    ''' </summary>
    ''' <param name="force">指定是否必须要以匿名消息发送。如需要在匿名消息发送失败后
    ''' 转为普通消息发送，请将该值置 True。</param>
    ''' <returns><see cref="String"/></returns>
    Public Function Anonymous(force As Boolean) As String
        Return "[CQ:anonymous" + If(force, ",ignore=true", "") + "]"
    End Function
    ''' <summary>
    ''' 获取发送群消息的代码字符串。
    ''' </summary>
    ''' <param name="group">要发送消息的群号。</param>
    ''' <param name="msg">消息。</param>
    ''' <returns><see cref="String"/></returns>
    Friend Function SendGroupMessage(group As Long, msg As String) As String
        Return "群|group=" + group.ToString + "|msg=" + Turn(msg) + Separator '+ vbCrLf
    End Function
    ''' <summary>
    ''' 获取发送私聊消息的代码字符串。
    ''' </summary>
    ''' <param name="qq">要发送私聊消息的QQ。</param>
    ''' <param name="msg">要发送的消息。</param>
    ''' <returns><see cref="String"/></returns>
    Friend Function SendPrivateMessage(qq As Long, msg As String) As String
        Return "私聊|qq=" + qq.ToString + "|msg=" + Turn(msg) + Separator  '+ vbCrLf
    End Function
    ''' <summary>
    ''' 获取发送讨论组消息的代码字符串。
    ''' </summary>
    ''' <param name="group">要发送消息的讨论组号码。</param>
    ''' <param name="msg">要发送的消息。</param>
    ''' <returns></returns>
    Friend Function SendDiscussGroupMessage(group As Long, msg As String) As String
        Return "讨论组|discuss=" + group.ToString + "|msg=" + Turn(msg) + Separator '+ vbCrLf
    End Function
    ''' <summary>
    ''' 对消息含有的特殊字符进行转义。
    ''' </summary>
    ''' <param name="msg">要转义的字符。</param>
    ''' <returns><see cref="String"/></returns>
    Public Function Turn(msg As String) As String
        If String.IsNullOrWhiteSpace(msg) Then Return String.Empty
        msg.Replace("&", "&amp;")
        msg.Replace("[", "&#91;")
        msg.Replace("]", "&#93;")
        msg.Replace(",", "&#44;")
        Return msg
    End Function
    ''' <summary>
    ''' 对消息含有的转义字符进行反转义。
    ''' </summary>
    ''' <param name="msg">要反转义的消息。</param>
    ''' <returns><see cref="String"/></returns>
    Public Function Unturn(msg As String) As String
        If String.IsNullOrWhiteSpace(msg) Then Return String.Empty
        msg.Replace("&amp;", "&")
        msg.Replace("&#91;", "[")
        msg.Replace("&#93;", "]")
        msg.Replace("&#44;", ",")
        Return msg
    End Function
    ''' <summary>
    ''' 获取将信息日志写入 CoolQ 日志的代码字符串。
    ''' </summary>
    ''' <param name="name">来源插件。</param>
    ''' <param name="msg">信息。</param>
    ''' <returns><see cref="String"/></returns>
    Friend Function LogInfo(name As String, msg As String) As String
        Return "信息|插件=" + name + "|内容=" + msg + Separator '+ vbCrLf
    End Function
    ''' <summary>
    ''' 获取将警告日志写入 CoolQ 日志的代码字符串。
    ''' </summary>
    ''' <param name="name">来源插件。</param>
    ''' <param name="msg">信息。</param>
    ''' <returns><see cref="String"/></returns>
    Friend Function LogWarn(name As String, msg As String) As String
        Return "警告|插件=" + name + "|内容=" + msg + Separator '+ vbCrLf
    End Function
    ''' <summary>
    ''' 获取将信息日志写入 CoolQ 日志的代码字符串。
    ''' </summary>
    ''' <param name="name">来源插件。</param>
    ''' <param name="msg">信息。</param>
    ''' <returns><see cref="String"/></returns>
    Friend Function LogError(name As String, msg As String) As String
        Return "错误|插件=" + name + "|内容=" + msg + Separator '+ vbCrLf
    End Function
    ''' <summary>
    ''' 获取将信息日志写入 CoolQ 日志的代码字符串。
    ''' </summary>
    ''' <param name="name">来源插件。</param>
    ''' <param name="msg">信息。</param>
    ''' <returns><see cref="String"/></returns>
    Friend Function LogDebug(name As String, msg As String) As String
        Return "调试|插件=" + name + "|内容=" + msg + Separator '+ vbCrLf
    End Function
    ''' <summary>
    ''' 获取显示致命错误代码字符串。
    ''' </summary>
    ''' <param name="msg">错误描述内容。</param>
    ''' <returns><see cref="String"/></returns>
    Friend Function ShowErrorMessage(msg As String) As String
        Return "显示致命错误|msg=" + msg + Separator
    End Function
    Friend Const Separator As String = "；"
    ''' <summary>
    ''' 获取发送图片代码字符串。
    ''' </summary>
    ''' <param name="filename">图片路径。</param>
    ''' <returns><see cref="String"/></returns>
    Public Function Image(fileName As String) As String
        Return "[CQ:image,file=" + fileName + "]"
    End Function
    ''' <summary>
    ''' 获取发送语音代码字符串。
    ''' </summary>
    ''' <param name="filename">音频文件路径。</param>
    ''' <returns><see cref="String"/></returns>
    Public Function Record(fileName As String) As String
        Return "[CQ:record,file=" + fileName + "]"
    End Function
    ''' <summary>
    ''' 获取抖动窗口代码字符串。
    ''' </summary>
    ''' <returns></returns>
    Public Function Shake() As String
        Return "[CQ:shake]"
    End Function
    ''' <summary>
    ''' 获取原创表情字符串。
    ''' </summary>
    ''' <param name="id">原创表情id。</param>
    ''' <returns><see cref="String"/></returns>
    Public Function OriginalExpression(id As Integer) As String
        Return "[CQ:bface,id" + id.ToString + "]"
    End Function
End Module
