Imports System.IO

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
            Return My.Settings.DataPath
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
End Module
