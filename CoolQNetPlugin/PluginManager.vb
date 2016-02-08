﻿Imports System.Runtime.InteropServices
Imports System.IO

<Assembly: CLSCompliant(True)>
''' <summary>
''' CoolQ .NET 插件中继站。
''' </summary>
<ComClass(PluginRelayStation.InterfaceId, PluginRelayStation.ClassId, PluginRelayStation.EventsId)>
<ComVisible(True)>
Public Class PluginRelayStation
#Region "COM GUID"
    ' 这些 GUID 提供此类的 COM 标识 
    ' 及其 COM 接口。若更改它们，则现有的
    ' 客户端将不再能访问此类。
    Public Const ClassId As String = "9eb55baf-db14-45bb-a976-e78227b64bef"
    Public Const InterfaceId As String = "16dc83d3-21da-47d5-872a-8ea5c7e2425c"
    Public Const EventsId As String = "5bc4ce5b-f0c8-4c51-8f62-a801832ff090"
#End Region

    ' 可创建的 COM 类必须具有一个不带参数的 Public Sub New() 
    ' 否则， 将不会在 
    ' COM 注册表中注册此类，且无法通过
    ' CreateObject 创建此类。
    ''' <summary>
    ''' 构造 <see cref="PluginRelayStation"/> 的新实例。
    ''' </summary>
    ''' <remarks>该方法仅用于 .NET 端 Debug 使用。</remarks>
    Public Sub New()
        MyBase.New()
        CheckInIFile()
        'pp = AppDomain.CurrentDomain.BaseDirectory + "Extensions"
    End Sub
    ''' <summary>
    ''' 处理私聊消息，然后返回结果。
    ''' </summary>
    ''' <param name="qq">私聊消息发送者。</param>
    ''' <param name="type">私聊会话类型。</param>
    ''' <param name="msg">消息内容。</param>
    ''' <param name="font">消息使用字体。</param>
    ''' <returns><see cref="String"/></returns>
    <CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")>
    Public Function ProcessPrivateMessage(qq As Long, type As Integer, msg As String, font As Integer, sendtime As Integer) As String
        Dim res As String = ""
        Try
            CheckDirectory()
            Dim h As New PrivateMessageHandler(qq, type, Unturn(msg), font, sendtime)
            h.Compose()
            h.DoWork()
            res = h.Command
            'End Using
        Catch ex As Exception
            Try
                ReportError(ex)
                'ReportError(ex, p)
            Catch exc As Exception
                MsgBox(exc.ToString)
            End Try
            Return ShowErrorMessage("处理消息时发生了错误，详见错误报告文件。")
        End Try
        Return res
    End Function
    ''' <summary>
    ''' 处理讨论组消息，然后返回结果。
    ''' </summary>
    ''' <param name="senderqq">消息发送者。</param>
    ''' <param name="discussgroup">讨论组号码。</param>
    ''' <param name="msg">消息内容。</param>
    ''' <param name="font">消息使用字体。</param>
    ''' <param name="sendtime">消息发送时间戳。</param>
    ''' <returns><see cref="String"/></returns>
    Public Function ProcessDiscussGroupMessage(discussgroup As Long, senderqq As Long, msg As String, font As Integer, sendtime As Integer) As String
        Try
            Dim res As String = ""
            CheckDirectory()
            Dim h As New DiscussGroupHandler(discussgroup, senderqq, Unturn(msg), font, sendtime)
            h.Compose()
            h.DoWork()
            res = h.Command
            Return res
        Catch ex As Exception
            Try
                ReportError(ex)
                'ReportError(ex, p)
            Catch exc As Exception
                MsgBox(exc.ToString)
            End Try
            Return ShowErrorMessage("处理消息时发生了错误，详见错误报告文件。")
        End Try
    End Function
    ''' <summary>
    ''' 处理群聊非匿名消息，然后返回结果。
    ''' </summary>
    ''' <param name="group">消息来源群号。</param>
    ''' <param name="qq">消息发送QQ。</param>
    ''' <param name="msg">消息内容。</param>
    ''' <param name="font">消息使用字体。</param>
    ''' <param name="sendtime">消息发送时间戳。</param>
    ''' <returns><see cref="String"/></returns>
    Public Function ProcessNotAnoymousMessage(group As Long, qq As Long, msg As String, font As Integer, sendtime As Integer) As String
        Try

        Catch ex As Exception
            Try
                ReportError(ex)
                'ReportError(ex, p)
            Catch exc As Exception
                MsgBox(exc.ToString)
            End Try
            Return ShowErrorMessage("处理消息时发生了错误，详见错误报告文件。")
        End Try

    End Function
    ''' <summary>
    ''' 处理群聊非匿名消息，然后返回结果。
    ''' </summary>
    ''' <param name="group">消息来源群号。</param>
    ''' <param name="sender">匿名消息发送者代号。</param>
    ''' <param name="aid">匿名消息发送者标识。</param>
    ''' <param name="msg">消息内容。</param>
    ''' <param name="font">消息使用字体。</param>
    ''' <param name="sendtime">消息发送时间戳。</param>
    ''' <returns><see cref="String"/></returns>
    Public Function ProcessAnoymousMessage(group As Long, sender As String, aid As Long, msg As String, font As Integer, sendtime As Integer) As String
        Try

        Catch ex As Exception
            Try
                ReportError(ex)
                'ReportError(ex, p)
            Catch exc As Exception
                MsgBox(exc.ToString)
            End Try
            Return ShowErrorMessage("处理消息时发生了错误，详见错误报告文件。")
        End Try
    End Function
    Private Shared Sub CheckDirectory()
        If Not Directory.Exists(ErrorReportPath) Then Directory.CreateDirectory(ErrorReportPath)
        If Not Directory.Exists(PluginPath) Then Directory.CreateDirectory(PluginPath)
    End Sub
    Private Shared Sub CheckInIFile()
        Dim inifile As String = Path.Combine(My.Application.Info.DirectoryPath, "NetConfig.ini")
        If My.Computer.FileSystem.FileExists(inifile) Then Return
        NativeMethods.WritePrivateProfileString("CoolQNetPluginConfig", "DataPath", My.Application.Info.DirectoryPath, inifile)
    End Sub

End Class


