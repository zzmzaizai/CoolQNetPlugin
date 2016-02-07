﻿Imports System.ComponentModel.Composition
Imports System.ComponentModel.Composition.Hosting
Imports System.Text
Friend Class DiscussGroupHandler
    Private dgh As StringBuilder, qq As Long, plugins As IEnumerable(Of IDiscussGroupMessageHandler)
    Private dis As Long, msg As String, msgfont As Integer, time As Integer

    Friend Sub New(discussgroup As Long, senderqq As Long, message As String, font As Integer, sendtime As Integer)
        dis = discussgroup
        qq = senderqq
        msg = message
        msgfont = font
        time = sendtime
        dgh = New StringBuilder
    End Sub
    Public Overrides Function ToString() As String
        Return dgh.ToString
    End Function
    Public Sub Compose()
        Dim plur As New DirectoryCatalog(PluginPath)
        Using cont As New CompositionContainer(plur)
            cont.ComposeParts(Me)
            plugins = cont.GetExportedValues(Of IDiscussGroupMessageHandler)
        End Using
        If plugins Is Nothing Then
            dgh.Append(LogInfo("CQ.NET", "没有找到可用的插件。"))
        Else
            dgh.Append(LogInfo("CQ.NET", "已加载" + plugins.Count.ToString + "个插件。"))
        End If
    End Sub
    Public Sub DoWork()
        If plugins Is Nothing Then Return
        'Dim dghplugin As IDiscussGroupMessageHandler
        For Each la As IDiscussGroupMessageHandler In plugins

        Next
    End Sub
    Public ReadOnly Property Command As String
        Get
            Return dgh.ToString
        End Get
    End Property
End Class