Imports System.ComponentModel.Composition
Imports System.ComponentModel.Composition.Hosting

''' <summary>
''' 表示一个所有有效插件的集合。
''' </summary>
Public Class ValidPluginList
    Private plu As IEnumerable(Of ICoolQPlugin)
    ''' <summary>
    ''' 寻找有效插件。
    ''' </summary>
    Public Sub Compose()
        Dim dir As New DirectoryCatalog(PluginPath)
        Using cont As New CompositionContainer(dir)
            cont.ComposeParts(Me)
            plu = cont.GetExportedValues(Of ICoolQPlugin)
        End Using
    End Sub
    ''' <summary>
    ''' 获取含有效插件的只读集合。
    ''' </summary>
    ''' <returns><see cref="IReadOnlyCollection(Of ICoolQPlugin)"/></returns>
    Public ReadOnly Property Plugins As IReadOnlyCollection(Of ICoolQPlugin)
        Get
            Dim p As New List(Of ICoolQPlugin)(plu)
            Return p.AsReadOnly
        End Get
    End Property
End Class
