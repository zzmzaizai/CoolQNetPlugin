Imports System.ComponentModel.Composition
Imports System.ComponentModel.Composition.Hosting
Imports System.Text

Friend Class GroupMessageHandler
    Private groupnumber As Long, senderqq As Long
    Private msg As String, msgfont As Integer, timestamp As Integer
    Private plugins As IEnumerable(Of IGroupMessageHandler)
    Private cmd As StringBuilder
    Private anno_sender As String, anno_aid As Long
    Public Sub New()
        cmd = New StringBuilder
    End Sub
    Public Sub New(group As Long, sender As Long, message As String, font As Integer, sendtime As Integer)
        Me.New
        groupnumber = group
        senderqq = sender
        msg = message
        msgfont = font
        timestamp = sendtime
    End Sub
    Public Sub Compose()
        Dim dir As New DirectoryCatalog(PluginPath)
        Using con As New CompositionContainer(dir)
            con.ComposeParts(Me)
            plugins = con.GetExportedValues(Of IGroupMessageHandler)
        End Using
        If plugins Is Nothing Then
            cmd.Append(LogInfo("CQ.NET 群聊", "没有找到可用的插件。"))
        Else
            cmd.Append(LogInfo("CQ.NET 群聊", "已加载" + plugins.Count.ToString + "个插件。"))
        End If
    End Sub
    Public Sub DoWork()
        Dim com As CommandStorage
        For Each igmh As IGroupMessageHandler In plugins
            Try
                If Not igmh.Permissions.HasFlag(PluginPermissions.GroupMessage) Then Continue For
                com = igmh.NotAnonymousResult(groupnumber, senderqq, msg, msgfont, timestamp)
                If com Is Nothing Then Continue For
                If Not String.IsNullOrWhiteSpace(com.ToString) Then
                    cmd.Append(com.ToString)
                End If
                If com.Intercept Then
                    cmd.Append(LogInfo("CQ.NET 群聊", "群聊消息已被" + igmh.Name + "拦截。"))
                    Exit For
                End If
            Catch ex As Exception
                ReportError(ex, igmh)
                cmd.Append(ShowErrorMessage("处理消息时遭遇异常，详见错误报告文件。"))
            End Try
        Next
    End Sub
    Public ReadOnly Property Command As String
        Get
            Return cmd.ToString
        End Get
    End Property ' = cmd.ToString
    Public Sub New(group As Long, sender As String, aid As Long, message As String, font As Integer, sendtime As Integer)
        Me.New
        groupnumber = group
        anno_sender = sender
        anno_aid = aid
        msg = message
        msgfont = font
        timestamp = sendtime

    End Sub
    Public Sub DoWorkforAnoymous()
        Dim com As CommandStorage
        For Each igmh As IGroupMessageHandler In plugins
            Try
                If Not igmh.Permissions.HasFlag(PluginPermissions.GroupMessage) Then Continue For
                com = igmh.AnonymousResult(groupnumber, anno_sender, anno_aid, msg, msgfont, timestamp)
                If com Is Nothing Then Continue For
                If Not String.IsNullOrWhiteSpace(com.ToString) Then
                    cmd.Append(com.ToString)
                End If
                If com.Intercept Then
                    cmd.Append(LogInfo("CQ.NET 群聊匿名", "群聊匿名消息已被" + igmh.Name + "拦截。"))
                    Exit For
                End If
            Catch ex As Exception
                ReportError(ex, igmh)
                cmd.Append(ShowErrorMessage("处理消息时遭遇异常，详见错误报告文件。"))
            End Try
        Next
    End Sub
End Class
