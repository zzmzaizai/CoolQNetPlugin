''' <summary>
''' 私聊信息处理器。
''' </summary>
Public Class PrivateMessageHandler
    Inherits MarshalByRefObject

    Private qq As Long, font As Integer, msgdate As Date
    Private type As PrivateMessageConsoleType
    Private msg As String

    Friend Sub New(qq As Long, type As PrivateMessageConsoleType, msg As String, font As Integer, sendtime As Date)
        Me.qq = qq
        Me.type = type
        Me.msg = msg
        msgdate = sendtime
    End Sub

End Class
