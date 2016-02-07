Imports System.Text

''' <summary>
''' 标准返回命令存储器。
''' </summary>
Public Class ReturnCommand
    Private sb As StringBuilder ', nolo As Boolean
    ''' <summary>
    ''' 构造<see cref="ReturnCommand"/>的新实例。
    ''' </summary>
    Public Sub New()
        sb = New StringBuilder
    End Sub
    ''' <summary>
    ''' 追加私聊发送命令。
    ''' </summary>
    ''' <param name="qq">私聊消息发送目标QQ。</param>
    ''' <param name="msg">消息内容。</param>
    Public Sub AppendSendMessageCmd(qq As Long, msg As String)
        ' If nolo Then Return
        sb.AppendLine(SendPrivateMessage(qq, msg))
    End Sub

    ''' <summary>
    ''' 返回此存储器的存储结果。
    ''' </summary>
    ''' <returns><see cref="String"/></returns>
    Public Overrides Function ToString() As String
        Return sb.ToString()
    End Function

End Class
