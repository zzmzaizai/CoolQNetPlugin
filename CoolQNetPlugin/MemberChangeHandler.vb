Imports System.ComponentModel.Composition
Imports System.ComponentModel.Composition.Hosting
Imports System.Text
Friend Class MemberChangeHandler
    Private detype As GroupMemberDecreaseType
    Private targetqq As Long, targetgroup As Long
    Private isi As Boolean, timestamp As Integer
    Private mch As StringBuilder, handleadmin As Long
    Private plugins As IEnumerable(Of IGroupMemberChangeHandler)
    Private Sub New()
        mch = New StringBuilder
    End Sub
    Public Sub New(group As Long, invited As Boolean, qq As Long, hl As Long, sendtime As Integer)
        Me.New
        targetgroup = group
        isi = invited
        targetqq = qq
        handleadmin = hl
        timestamp = sendtime
    End Sub
    Public Sub Compose()
        Dim plur As New DirectoryCatalog(PluginPath)
        Using cont As New CompositionContainer(plur)
            cont.ComposeParts(Me)
            plugins = cont.GetExportedValues(Of IGroupMemberChangeHandler)
        End Using
        If plugins Is Nothing Then
            mch.Append(LogInfo("CQ.NET 群成员变动", "没有找到可用的插件。"))
        Else
            mch.Append(LogInfo("CQ.NET 群成员变动", "已加载" + plugins.Count.ToString + "个插件。"))
        End If
    End Sub
    Public Sub DoWorkforIncrease()
        If plugins Is Nothing Then Return
        'Dim dghplugin As IDiscussGroupMessageHandler
        Dim sto As CommandStorage, s As String ' s
        Dim etl As New EnabledPluginsList
        etl.ImportList()
        For Each la As IGroupMemberChangeHandler In plugins
            Try
                If Not etl.IsEnable(la.Id) Then Continue For

                sto = la.MemberIncrease(targetgroup, isi, targetqq, handleadmin, timestamp)
                If sto Is Nothing Then Continue For

                s = sto.ToString
                If Not String.IsNullOrWhiteSpace(s) Then
                    mch.Append(s)
                End If
                If sto.Intercept Then
                    mch.Append(LogInfo("CQ.NET 群成员变动", "群成员变动事件已被 " + la.Name + " 处理。"))
                    Exit Sub
                End If
            Catch ex As Exception
                ReportError(ex, la)
                mch.Append(ShowErrorMessage("执行插件代码时遭遇异常，详见错误报告文件。"))
            End Try
        Next
    End Sub
    Public Sub New(group As Long, type As GroupMemberDecreaseType, qq As Long, admin As Long, sendtime As Integer)
        Me.New
        targetgroup = group
        detype = type
        targetqq = qq
        handleadmin = admin
        timestamp = sendtime
    End Sub
    Public Sub DoWorkforDecrease()
        If plugins Is Nothing Then Return
        'Dim dghplugin As IDiscussGroupMessageHandler
        Dim sto As CommandStorage, s As String ' s
        Dim etl As New EnabledPluginsList
        etl.ImportList()
        For Each la As IGroupMemberChangeHandler In plugins
            Try
                If Not etl.IsEnable(la.Id) Then Continue For

                sto = la.MemberDecrease(targetgroup, detype, targetqq, handleadmin, timestamp)
                If sto Is Nothing Then Continue For

                s = sto.ToString
                If Not String.IsNullOrWhiteSpace(s) Then
                    mch.Append(s)
                End If
                If sto.Intercept Then
                    mch.Append(LogInfo("CQ.NET 群成员变动", "群成员变动事件已被 " + la.Name + " 处理。"))
                    Exit Sub
                End If
            Catch ex As Exception
                ReportError(ex, la)
                mch.Append(ShowErrorMessage("执行插件代码时遭遇异常，详见错误报告文件。"))
            End Try
        Next
    End Sub
    Public ReadOnly Property Command As String
        Get
            Return mch.ToString
        End Get
    End Property
End Class
