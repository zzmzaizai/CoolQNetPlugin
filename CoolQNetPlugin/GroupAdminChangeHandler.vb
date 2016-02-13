Imports System.ComponentModel.Composition
Imports System.ComponentModel.Composition.Hosting
Imports System.Text

Friend Class GroupAdminChangeHandler
    Private gach As IEnumerable(Of IGroupAdminChangeHandler)
    Private groupnumber As Long, bc As Boolean
    Private targetqq As Long, eventime As Integer
    Private dgh As StringBuilder
    Public Sub New(group As Long, becomeadmin As Boolean, target As Long, sendtime As Integer)
        groupnumber = group
        bc = becomeadmin
        targetqq = target
        eventime = sendtime
        dgh = New StringBuilder
    End Sub
    Public Sub Compose()
        Dim plur As New DirectoryCatalog(PluginPath)
        Using cont As New CompositionContainer(plur)
            cont.ComposeParts(Me)
            gach = cont.GetExportedValues(Of IGroupAdminChangeHandler)
        End Using
        If gach Is Nothing Then
            dgh.Append(LogInfo("CQ.NET 群管理变动", "没有找到可用的插件。"))
        Else
            dgh.Append(LogInfo("CQ.NET 群管理变动", "已加载" + gach.Count.ToString + "个插件。"))
        End If
    End Sub
    Public Sub DoWork()
        If gach Is Nothing Then Return
        'Dim dghplugin As IDiscussGroupMessageHandler
        Dim sto As CommandStorage, s As String ' s
        Dim etl As New EnabledPluginsList
        etl.ImportList()
        For Each la As IGroupAdminChangeHandler In gach
            Try
                If Not etl.IsEnable(la.Id) Then Continue For

                sto = la.Result(groupnumber, bc, targetqq, eventime)
                If sto Is Nothing Then Continue For

                s = sto.ToString
                If Not String.IsNullOrWhiteSpace(s) Then
                    dgh.Append(s)
                End If
                If sto.Intercept Then
                    dgh.Append(LogInfo("CQ.NET 群", "群管理变动事件已被 " + la.Name + " 处理。"))
                    Exit Sub
                End If
            Catch ex As Exception
                ReportError(ex, la)
                dgh.Append(ShowErrorMessage("执行插件代码时遭遇异常，详见错误报告文件。"))
            End Try
        Next
    End Sub
    Public ReadOnly Property Command As String
        Get
            Return dgh.ToString
        End Get
    End Property
End Class
