Imports System.ComponentModel.Composition
Imports System.ComponentModel.Composition.Hosting
Imports System.IO

Friend Class PluginInformationProvider
    Private plugins As IEnumerable(Of ICoolQPlugin)
    Private infile As String
    Public Sub New(informationstored As String)
        infile = informationstored
    End Sub
    Public Sub Compose()
        Dim plur As New DirectoryCatalog(PluginPath)
        Using cont As New CompositionContainer(plur)
            cont.ComposeParts(Me)
            plugins = cont.GetExportedValues(Of IGroupMemberChangeHandler)
        End Using
    End Sub
    Public Sub ExportInformation()
        If plugins Is Nothing OrElse plugins.Count = 0 Then Return
        Using ei As New StreamWriter(infile)
            For Each p As ICoolQPlugin In plugins
                ei.WriteLine(p.Name + "|" + p.Id.ToString + "|" + EnumValues(p.Permissions))
            Next
        End Using
    End Sub
    Private Shared Function EnumValues(value As [Enum]) As String
        Return [Enum].Format(GetType(PluginPermissions), value, "g")
    End Function
End Class
