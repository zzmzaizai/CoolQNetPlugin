''' <summary>
''' 酷Q.NET测试插件。
''' </summary>
''' 类名可改变
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
    ''' 插件被开启时发生。
    ''' </summary>
    ''' <returns><see cref="Integer"/> 返回处理过程是否成功的值。</returns>
    <DllExport("_eventEnable")>
    Public Shared Function Enabled() As Integer

        MsgBox("测试插件已开启")
        Return 0
    End Function
    ''' <summary>
    ''' 插件被禁用时发生。
    ''' </summary>
    ''' <returns><see cref="Integer"/> 返回处理过程是否成功的值。</returns>
    <DllExport("_eventDisable")>
    Public Shared Function Disabled() As Integer
        MsgBox("测试插件已关闭")
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
    ''' 向酷Q提供此插件的AuthCode。
    ''' </summary>
    ''' <param name="authcode">由酷Q提供的AuthCode。</param>
    ''' <returns><see cref="Integer"/> </returns>
    <DllExport("Initialize")>
    Public Shared Function Initialize(authcode As Integer) As Integer
        '请勿更改此函数

    End Function
End Class
