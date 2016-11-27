''' <summary>
''' 提供插件辅助方法。
''' </summary>
Module PluginHelper
    ''' <summary>
    ''' 表示忽略消息的值。
    ''' </summary>
    Public Const Event_Ignore As Integer = 0
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
    ''' 酷Q Api实例。
    ''' </summary>
    Friend CQ As New CoolQApi
End Module
