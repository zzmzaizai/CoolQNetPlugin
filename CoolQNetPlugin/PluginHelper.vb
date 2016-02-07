Imports System.IO
Imports System.Text

''' <summary>
''' 提供插件辅助方法。
''' </summary>
Public Module PluginHelper
    ''' <summary>
    ''' 获取数据路径。
    ''' </summary>
    ''' <returns><see cref="String"/></returns>
    Public ReadOnly Property DataPath As String
        Get
            Return ContentValue("CoolQNetPluginConfig", "DataPath")
        End Get
    End Property
    Friend ReadOnly Property PluginPath As String
        Get
            Return Path.Combine(DataPath, "Plugins")
        End Get
    End Property
    Friend ReadOnly Property ErrorReportPath As String
        Get
            Return Path.Combine(DataPath, "ErrorReports")
        End Get
    End Property
    Private Function ContentValue(section As String, key As String) As String
        Dim inifile As String = Path.Combine(My.Application.Info.DirectoryPath, "NetConfig.ini")
        Dim sb As New StringBuilder(1024)
        NativeMethods.GetPrivateProfileString(section, key, String.Empty, sb, 1024, inifile)
        Return sb.ToString
    End Function
    Friend Sub ReportError(ex As Exception, plugin As ICoolQPlugin)
        If ex Is Nothing Then Return
        Dim ns As String = Now.ToString
        Dim ep As String = Path.Combine(ErrorReportPath, ns + ".txt")
        Using sw As New StreamWriter(ep)
            sw.WriteLine("错误发生时间：" + Now.ToString)
            sw.WriteLine("错误发生组件：" + plugin.Name + "（" + plugin.Id.ToString + "）")
            sw.WriteLine("错误信息：")
            sw.WriteLine(ex.ToString)
        End Using
    End Sub
End Module
