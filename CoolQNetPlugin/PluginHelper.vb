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
            PluginSetting.Default.Upgrade()
            Dim dp As String = PluginSetting.Default.DataPath
            If String.IsNullOrWhiteSpace(dp) Then
                Return Environment.CurrentDirectory
            End If
            Return PluginSetting.Default.DataPath
        End Get
    End Property
    ''' <summary>
    ''' 获取指定插件是否启用。
    ''' </summary>
    ''' <param name="id">插件ID。</param>
    ''' <returns><see cref="Boolean"/></returns>
    Public ReadOnly Property Enabled(id As Guid) As Boolean
        Get
            If id = Guid.Empty Then Return False
            If String.IsNullOrWhiteSpace(PluginSetting.Default.DisabledPlugin) Then Return False
            Dim ids As String = id.ToString
            Using sr As New StreamReader(PluginSetting.Default.DisabledPlugin)
                Do Until sr.EndOfStream
                    If sr.ReadLine = ids Then
                        Return False
                    End If
                Loop
            End Using
            Return True
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
