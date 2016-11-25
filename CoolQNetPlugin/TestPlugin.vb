''' <summary>
''' 酷Q.NET测试插件。
''' </summary>
Public Class TestPlugin

    Private Const ApiVersion As Integer = 9 'Api版本号，若酷Q官方SDK没有更新此版本号，请勿改动此值
    'AppID 
    Private Const AppId As String = "com.net.hotplug.test"

    ''' <summary>
    ''' 初始化<see cref="TestPlugin"/>的新实例。 
    ''' </summary>
    Public Sub New()
        '在这里写插件的加载代码。
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
    <DllExport("Initialize")>
    Public Shared Function Initialize(authcode As Integer) As Integer
        '请勿更改此函数
        PluginAuthCode = authcode
        Return 0 '固定返回0
    End Function
    ''' <summary>
    ''' 此函数会在酷Q退出时被调用。
    ''' </summary>
    ''' <returns><see cref="Integer"/> </returns>
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
    ''' <returns><see cref="Integer"/> 是否拦截消息的值，1为拦截消息。</returns>
    <DllExport("_eventPrivateMsg")>
    Public Shared Function ProcessPrivateMessage(subType As Integer, sendTime As Integer, fromQQ As String, msg As String, font As Integer) As Integer
        '0为忽略 1为拦截

        Return 0
    End Function
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="subType"></param>
    ''' <param name="sendTime"></param>
    ''' <param name="fromGroup"></param>
    ''' <param name="fromQQ"></param>
    ''' <param name="fromAnonymous"></param>
    ''' <param name="msg"></param>
    ''' <param name="font"></param>
    ''' <returns></returns>
    <DllExport("_eventGroupMsg")>
    Public Shared Function ProcessGroupMessage(subType As Integer, sendTime As Integer, fromGroup As Integer, fromQQ As Integer, fromAnonymous As Integer,
                                               msg As String, font As Integer) As Integer
        '0为忽略 1为拦截

        Return 0
    End Function
End Class
