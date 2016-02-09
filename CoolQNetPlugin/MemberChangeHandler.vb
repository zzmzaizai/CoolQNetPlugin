Imports System.ComponentModel.Composition
Imports System.ComponentModel.Composition.Hosting
Imports System.Text
Friend Class MemberChangeHandler
    Private detype As GroupMemberDecreaseType
    Private targetqq As Long, targetgroup As Long
    Private isi As Boolean, timestamp As Integer
    Private mch As StringBuilder
    Private plugins As IEnumerable(Of IGroupMemberChangeHandler)
    Private Sub New()
        mch = New StringBuilder
    End Sub
    Public Sub New(group As Long, invited As Boolean, qq As Long, sendtime As Integer)
        Me.New
        targetgroup = group
        isi = invited
        targetqq = qq
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

    End Sub
End Class
