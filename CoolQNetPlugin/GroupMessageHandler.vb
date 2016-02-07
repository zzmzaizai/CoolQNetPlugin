Imports System.ComponentModel.Composition
Imports System.ComponentModel.Composition.Hosting
Imports System.Text
Friend Class GroupMessageHandler
    Private gr As Long, sq As Long, message As String
    Private msgfont As Integer, timestamp As Integer
    Private cmd As StringBuilder
    'Private isanonymous As Boolean
    Private plugins As IEnumerable(Of IGroupMessageHandler)
    Private Sub New()
        cmd = New StringBuilder
    End Sub
    Public Sub New(group As Long, senderqq As Long, msg As String, font As Integer, time As Integer)
        Me.New
        gr = group
        sq = senderqq
        message = msg
        msgfont = font
        timestamp = time
        'isanonymous = False
    End Sub
#Region "匿名"
    Private send As String, send_aid As Long
    Public Sub New(sender As String, aid As Long, group As Long, msg As String, font As Integer, time As Integer)
        send = sender
        send_aid = aid
        gr = group
        message = msg
        msgfont = font
        timestamp = time
    End Sub
    Public Sub DoWorkforAnoymous()
        If plugins Is Nothing Then Return
        Dim res As String, cmds As CommandStorage
        For Each gmh As IGroupMessageHandler In plugins
            Try
                If Not gmh.Permissions.HasFlag(PluginPermissions.GroupMessage) Then
                    Continue For
                End If
                cmds = gmh.Anonymous(gr, send, send_aid, message, msgfont, timestamp)
                If cmds Is Nothing Then Continue For
                res = cmds.ToString
                If Not String.IsNullOrWhiteSpace(res) Then
                    cmd.Append(res)
                    If gmh.IsIntercept Then
                        cmd.Append(LogInfo("CQ.NET 群匿名", "群聊匿名消息已被 " + gmh.Name + " 拦截。"))
                        Exit For
                    End If
                End If

            Catch ex As Exception
                ReportError(ex, gmh)
                cmd.Append(ShowErrorMessage("执行插件代码时遭遇异常，详见错误报告文件。"))
            End Try

        Next
    End Sub
#End Region
    Public Sub Compose()
        Dim dircatalog As New DirectoryCatalog(PluginPath)
        Using container As New CompositionContainer(dircatalog)
            container.ComposeParts(Me)
            'plugins = container.GetExportedValues(Of IPrivateMessageHandler)
            plugins = container.GetExportedValues(Of IGroupMessageHandler)
        End Using
        If plugins Is Nothing Then
            cmd.Append(LogInfo("CQ.NET 群聊", "没有找到可用的插件。") + Separator)
        Else
            cmd.Append(LogInfo("CQ.NET 群聊", String.Format("已加载{0}个插件", plugins.Count.ToString)))
        End If
    End Sub
    Public Sub DoWorkforNonAnoymous()
        If plugins Is Nothing Then Return
        Dim res As String, cmds As CommandStorage
        For Each gmh As IGroupMessageHandler In plugins
            Try
                If Not gmh.Permissions.HasFlag(PluginPermissions.GroupMessage) Then
                    Continue For
                End If
                cmds = gmh.NotAnonymous(gr, sq, message, msgfont, timestamp)
                If cmds Is Nothing Then Continue For
                res = cmds.ToString
                If Not String.IsNullOrWhiteSpace(res) Then
                    cmd.Append(res)
                    If gmh.IsIntercept Then
                        cmd.Append(LogInfo("CQ.NET 群聊", "群聊消息已被 " + gmh.Name + " 拦截。"))
                        Exit For
                    End If
                End If

            Catch ex As Exception
                ReportError(ex, gmh)
                cmd.Append(ShowErrorMessage("执行插件代码时遭遇异常，详见错误报告文件。"))
            End Try

        Next
    End Sub
    Public Overrides Function ToString() As String
        Return cmd.ToString()
    End Function

End Class
