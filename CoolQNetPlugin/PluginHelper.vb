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
    Friend ReadOnly Property ShadowCopyPath As String
        Get
            Return Path.Combine(DataPath, "ShadowCopyCache")
        End Get
    End Property
    Friend ReadOnly Property PluginPath As String
        Get
            Return Path.Combine(DataPath, "Plugins")
        End Get
    End Property
    Private Function ContentValue(section As String, key As String) As String
        Dim inifile As String = Path.Combine(My.Application.Info.DirectoryPath, "NetConfig.ini")
        Dim sb As New StringBuilder(1024)
        NativeMethods.GetPrivateProfileString(section, key, String.Empty, sb, 1024, inifile)
        Return sb.ToString
    End Function
End Module
