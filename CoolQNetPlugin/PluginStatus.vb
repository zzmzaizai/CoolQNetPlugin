''' <summary>
''' 储存已启用插件的列表。
''' </summary>
Public Class EnabledPluginsList
    Implements IEnumerable(Of Guid)
    Private plu As List(Of Guid)
    ''' <summary>
    ''' 默认构造函数。
    ''' </summary>
    Public Sub New()
        plu = New List(Of Guid)

    End Sub
    ''' <summary>
    ''' 获取所有已启用的插件。
    ''' </summary>
    ''' <returns><see cref="IEnumerable(Of Guid) "/></returns>
    Public Function GetEnumerator() As IEnumerator(Of Guid) Implements IEnumerable(Of Guid).GetEnumerator
        Return plu.GetEnumerator
    End Function

    Private Function IEnumerable_GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
        Throw New NotImplementedException()
    End Function
    ''' <summary>
    ''' 启用一个插件。
    ''' </summary>
    ''' <param name="plugin">要启用插件的 <see cref="Guid"/>。</param>
    Public Sub Enable(plugin As Guid)
        If plugin = Guid.Empty Then Return
        If plu.Contains(plugin) Then Return
        plu.Add(plugin)
    End Sub
    ''' <summary>
    ''' 禁用一个插件。
    ''' </summary>
    ''' <param name="plugin">要禁用插件的 <see cref="Guid"/>。</param>
    Public Sub Disable(plugin As Guid)
        plu.Remove(plugin)
    End Sub
    ''' <summary>
    ''' 检测指定插件是否已启用。
    ''' </summary>
    ''' <param name="plugin">要检测的插件的 <see cref="Guid"/>。</param>
    ''' <returns><see cref="Boolean"/></returns>
    Public Function IsEnable(plugin As Guid) As Boolean
        Return plu.Contains(plugin)
    End Function
End Class
