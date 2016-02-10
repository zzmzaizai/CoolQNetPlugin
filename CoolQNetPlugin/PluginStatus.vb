﻿Imports System.IO
Imports System.Text

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
    ''' <param name="plugin">要启用的插件。</param>
    Public Sub Enable(plugin As ICoolQPlugin)
        If plugin.Id = Guid.Empty Then Return
        If plu.Contains(plugin.Id) Then Return
        If plugin.Permissions.HasFlag(PluginPermissions.Cookies) Then
            Dim mb As New StringBuilder, res As MsgBoxResult
            mb.Append("插件" + plugin.Name + "（作者：" + plugin.Author + "）需要请求敏感权限。")
            mb.AppendLine("启用该插件可能会带来安全问题，是否继续启用该插件？")
            mb.AppendLine("插件请求的敏感权限：")
            mb.AppendLine("获取用户 Cookies 和 CstrfToken")
            res = MsgBox(mb.ToString, MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2 Or MsgBoxStyle.Exclamation, "警告")
            If res = MsgBoxResult.Yes Then GoTo fin
            Return
            End If
fin:        plu.Add(plugin.Id)
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
    ''' <summary>
    ''' 导入已启用插件列表。
    ''' </summary>
    Public Sub ImportList()
        Dim enalist As String = Path.Combine(DataPath, "EnablePlugin.txt")
        If Not My.Computer.FileSystem.FileExists(enalist) Then Return
        Dim targuid As Guid
        Using ea As New StreamReader(enalist)
            Do Until ea.EndOfStream
                Try
                    targuid = New Guid(ea.ReadLine)
                    plu.Add(targuid)
                Catch ex As Exception

                End Try
            Loop
        End Using
    End Sub
    ''' <summary>
    ''' 导出已启用插件列表。
    ''' </summary>
    Public Sub ExportList()
        Dim enalist As String = Path.Combine(DataPath, "EnablePlugin.txt")
        Using sn As New StreamWriter(enalist, True)
            For Each g As Guid In plu
                sn.WriteLine(g.ToString)
            Next
        End Using
    End Sub
End Class