''' <summary>
''' 提供插件辅助方法。
''' </summary>
Module PluginHelper
    ''' <summary>
    ''' 表示忽略消息的值。
    ''' </summary>
    Public Const Event_Ignore As Integer = 0
    ''' <summary>
    ''' 插件权限代码。
    ''' </summary>
    Friend PluginAuthCode As Integer
    ''' <summary>
    ''' 表示拦截消息的值。
    ''' </summary>
    Public Const Event_Block As Integer = 1
    ''' <summary>
    ''' 表示通过请求的值。
    ''' </summary>
    Public Const Request_Pass As Integer = 1
    ''' <summary>
    ''' 表示拒绝请求的值。
    ''' </summary>
    Public Const Request_Deny As Integer = 2
    ''' <summary>
    ''' 表示请求类型为加群请求。
    ''' </summary>
    Public Const RequestType_GroupJoin As Integer = 1
    ''' <summary>
    ''' 表示请求类型为邀请加群请求。
    ''' </summary>
    Public Const RequestType_GroupInvtiation As Integer = 2
    ''' <summary>
    ''' 表示酷Q日志等级为调试。
    ''' </summary>
    Public Const Log_Debug As Integer = 0
    ''' <summary>
    ''' 表示酷Q日志等级为信息。
    ''' </summary>
    Public Const Log_Info As Integer = 10
    ''' <summary>
    ''' 表示酷Q日志等级为信息（成功）。
    ''' </summary>
    Public Const Log_InfoSuccess As Integer = 11
    ''' <summary>
    ''' 表示酷Q日志等级为信息（接收）。
    ''' </summary>
    Public Const Log_InfoReceive As Integer = 12
    ''' <summary>
    ''' 表示酷Q日志等级为信息（发送）。
    ''' </summary>
    Public Const Log_InfoSend As Integer = 13
    ''' <summary>
    ''' 表示酷Q日志等级为警告。
    ''' </summary>
    Public Const Log_Warning As Integer = 20
    ''' <summary>
    ''' 表示酷Q日志等级为错误。
    ''' </summary>
    Public Const Log_Error As Integer = 30
    ''' <summary>
    ''' 表示酷Q日志等级为致命错误。
    ''' </summary>
    Public Const Log_Fatal As Integer = 40
End Module
