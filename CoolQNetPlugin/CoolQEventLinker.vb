Imports System.ComponentModel.Composition
Imports System.ComponentModel.Composition.Hosting

Friend Class CoolQLoadEvent 'Linker
    'Private iqe As IEnumerable(Of IUnLoadPlugin)
    Private ile As IEnumerable(Of ILoadPlugin)
    Public Sub Compose()
        Dim dir As New DirectoryCatalog(PluginPath)
        Using container As New CompositionContainer(dir)
            container.ComposeParts(Me)
            ile = container.GetExportedValues(Of ILoadPlugin)
        End Using

    End Sub
    Public Sub DoWork()
        Dim elp As New EnabledPluginsList
        elp.ImportList()

        For Each ilp As ILoadPlugin In ile
            If Not elp.IsEnable(ilp.Id) Then Continue For
            Try
                ilp.OnLoad()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Next
    End Sub
End Class
Friend Class CoolQExitingEvent
    Private ile As IEnumerable(Of IUnLoadPlugin)
    Public Sub Compose()
        Dim dir As New DirectoryCatalog(PluginPath)
        Using container As New CompositionContainer(dir)
            container.ComposeParts(Me)
            ile = container.GetExportedValues(Of IUnLoadPlugin)
        End Using

    End Sub
    Public Sub DoWork()
        Dim elp As New EnabledPluginsList
        elp.ImportList()

        For Each ilp As IUnLoadPlugin In ile
            If Not elp.IsEnable(ilp.Id) Then Continue For
            Try
                ilp.OnUnloaded()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Next
    End Sub
End Class