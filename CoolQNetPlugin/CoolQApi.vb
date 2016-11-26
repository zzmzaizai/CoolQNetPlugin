Imports System.ComponentModel
Imports System.Runtime.InteropServices
Imports System.Security

<Assembly: CLSCompliant(True)>
''' <summary>
''' 向酷Q.NET插件提供酷Q Api
''' </summary>
Public Class CoolQApi
    Private cqauthcode As Integer
    ''' <summary>
    ''' 设置插件权限代码。
    ''' </summary>
    ''' <param name="authCode">从酷Q处获得的权限代码。</param>
    <EditorBrowsable(EditorBrowsableState.Never)>
    Public Sub SetAuthCode(authCode As Integer)
        cqauthcode = authCode
    End Sub
    Private MustInherit Class NativeMethods
        <DllImport("CQP.dll", CallingConvention:=CallingConvention.StdCall, CharSet:=CharSet.Unicode)>
        Public Shared Function CQ_sendPrivateMsg(authCode As Integer, QQid As Long, message As String) As Integer

        End Function
        <DllImport("CQP.dll", CallingConvention:=CallingConvention.StdCall, CharSet:=CharSet.Unicode)>
        Public Shared Function CQ_sendGroupMsg(authCode As Integer, groupId As Long, message As String) As Integer

        End Function
        <DllImport("CQP.dll", CallingConvention:=CallingConvention.StdCall, CharSet:=CharSet.Unicode)>
        Public Shared Function CQ_sendDiscussMsg(authCode As Integer, discussId As Long, message As String) As Integer

        End Function
        <DllImport("CQP.dll", CallingConvention:=CallingConvention.StdCall, CharSet:=CharSet.Unicode)>
        Public Shared Function CQ_sendLike(authCode As Integer, QQid As Long) As Integer

        End Function
        <DllImport("CQP.dll", CallingConvention:=CallingConvention.StdCall, CharSet:=CharSet.Unicode)>
        Public Shared Function CQ_setGroupKick(authCode As Integer, groupId As Long, QQid As Long, rejectAddRequest As Integer) As Integer

        End Function
        <DllImport("CQP.dll", CallingConvention:=CallingConvention.StdCall, CharSet:=CharSet.Unicode)>
        Public Shared Function CQ_setGroupBan(authCode As Integer, groupId As Long, QQid As Long, duration As Long) As Integer

        End Function
        <DllImport("CQP.dll", CallingConvention:=CallingConvention.StdCall, CharSet:=CharSet.Unicode)>
        Public Shared Function CQ_setGroupAdmin(authCode As Integer, groupId As Long, QQid As Long, setAdmin As Integer) As Integer

        End Function
        <DllImport("CQP.dll", CallingConvention:=CallingConvention.StdCall, CharSet:=CharSet.Unicode)>
        Public Shared Function CQ_setGroupWholeBan(authCode As Integer, groupId As Long, enableban As Integer) As Integer

        End Function
        <DllImport("CQP.dll", CallingConvention:=CallingConvention.StdCall, CharSet:=CharSet.Unicode)>
        Public Shared Function CQ_setGroupAnonymousBan(authCode As Integer, groupId As Long, anonymous As String, duration As Long) As Integer

        End Function
        <DllImport("CQP.dll", CallingConvention:=CallingConvention.StdCall, CharSet:=CharSet.Unicode)>
        Public Shared Function CQ_setGroupAnonymous(authCode As Integer, groupId As Long, enableAnomymous As Integer) As Integer

        End Function
        <DllImport("CQP.dll", CallingConvention:=CallingConvention.StdCall, CharSet:=CharSet.Unicode)>
        Public Shared Function CQ_setGroupCard(authCode As Integer, groupId As Long, QQid As Long, newCard As String) As Integer

        End Function
        <DllImport("CQP.dll", CallingConvention:=CallingConvention.StdCall, CharSet:=CharSet.Unicode)>
        Public Shared Function CQ_setGroupLeave(authCode As Integer, groupId As Long, isdismissed As Integer) As Integer

        End Function
        <DllImport("CQP.dll", CallingConvention:=CallingConvention.StdCall, CharSet:=CharSet.Unicode)>
        Public Shared Function CQ_setGroupSpecialTitle(authCode As Integer, groupId As Long, QQid As Long, newTitle As String, duration As Long) As Integer

        End Function
        <DllImport("CQP.dll", CallingConvention:=CallingConvention.StdCall, CharSet:=CharSet.Unicode)>
        Public Shared Function CQ_setDiscussLeave(authCode As Integer, discussGroupId As Long) As Integer

        End Function
        <DllImport("CQP.dll", CallingConvention:=CallingConvention.StdCall, CharSet:=CharSet.Unicode)>
        Public Shared Function CQ_setFriendAddRequest(authCode As Integer, responseFlag As String, responseOperation As Integer, remark As String) As Integer

        End Function
        <DllImport("CQP.dll", CallingConvention:=CallingConvention.StdCall, CharSet:=CharSet.Unicode)>
        Public Shared Function CQ_setGroupAddRequestV2(authCode As Integer, responseFlag As String, requestType As Integer, responseOperation As Integer, reason As String) As Integer

        End Function
        <DllImport("CQP.dll", CallingConvention:=CallingConvention.StdCall, CharSet:=CharSet.Unicode)>
        Public Shared Function CQ_getGroupMemberInfoV2(authCode As Integer, groupId As Long, QQid As Long, nocache As Integer) As String

        End Function
        <DllImport("CQP.dll", CallingConvention:=CallingConvention.StdCall, CharSet:=CharSet.Unicode)>
        Public Shared Function CQ_getStrangerInfo(authCode As Integer, QQid As Long, nocache As Integer) As String

        End Function
        <DllImport("CQP.dll", CallingConvention:=CallingConvention.StdCall, CharSet:=CharSet.Unicode)>
        Public Shared Function CQ_addLog(authCode As Integer, priority As Integer, category As String, content As String) As Integer

        End Function
        <DllImport("CQP.dll", CallingConvention:=CallingConvention.StdCall, CharSet:=CharSet.Unicode)>
        Public Shared Function CQ_getCookies(authCode As Integer) As String

        End Function
        <DllImport("CQP.dll", CallingConvention:=CallingConvention.StdCall, CharSet:=CharSet.Unicode)>
        Public Shared Function CQ_getCsrfToken(authCode As Integer) As Integer

        End Function
        <DllImport("CQP.dll", CallingConvention:=CallingConvention.StdCall, CharSet:=CharSet.Unicode)>
        Public Shared Function CQ_getLoginQQ(authCode As Integer) As Long

        End Function
        <DllImport("CQP.dll", CallingConvention:=CallingConvention.StdCall, CharSet:=CharSet.Unicode)>
        Public Shared Function CQ_getLoginNick(authCode As Integer) As String

        End Function
        <DllImport("CQP.dll", CallingConvention:=CallingConvention.StdCall, CharSet:=CharSet.Unicode)>
        Public Shared Function CQ_getAppDirectory(authCode As Integer) As String

        End Function
    End Class
    ''' <summary>
    ''' 向指定的QQ发送私聊消息。
    ''' </summary>
    ''' <param name="QQ">接收此消息的QQ。</param>
    ''' <param name="message">私聊消息内容。</param>
    <CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId:="QQ")>
    Public Sub SendPrivateMessage(QQ As Long, message As String)
        NativeMethods.CQ_sendPrivateMsg(cqauthcode, QQ, message)
    End Sub
    ''' <summary>
    ''' 向指定的群发送群消息。
    ''' </summary>
    ''' <param name="groupId">接收此消息的群号。</param>
    ''' <param name="message">消息内容。</param>
    Public Sub SendGroupMessage(groupId As Long, message As String)
        NativeMethods.CQ_sendGroupMsg(cqauthcode, groupId, message)
    End Sub
    ''' <summary>
    ''' 向指定的讨论组发送讨论组消息。
    ''' </summary>
    ''' <param name="dicussGroupId">接收此消息的讨论组号。</param>
    ''' <param name="message">消息内容。</param>
    Public Sub SendDiscussGroupMessage(dicussGroupId As Long, message As String)
        NativeMethods.CQ_sendGroupMsg(cqauthcode, dicussGroupId, message)
    End Sub
    ''' <summary>
    ''' 获取酷Q当前登录用户的Cookies。
    ''' </summary>
    ''' <returns><see cref="String"/> </returns>
    Public ReadOnly Property Cookies As String
        Get
            Return NativeMethods.CQ_getCookies(cqauthcode)
        End Get
    End Property
    ''' <summary>
    ''' 获取加密后的Cookies。
    ''' </summary>
    ''' <returns><see cref="SecureString"/> 保存了Cookies的<see cref="SecureString"/>对象。</returns>
    ''' <remarks>
    ''' 使用方法详见：
    ''' https://msdn.microsoft.com/zh-cn/library/system.security.securestring.aspx
    ''' 此Api是酷Q非官方Api。
    ''' </remarks>
    Public ReadOnly Property SafelyCookies As SecureString
        Get
            Dim sc As New SecureString
            For Each c As Char In NativeMethods.CQ_getCookies(cqauthcode)
                sc.AppendChar(c)
            Next
            sc.MakeReadOnly()
            Return sc
        End Get
    End Property
    ''' <summary>
    ''' 获取酷Q当前登录用户的CsrfToken。
    ''' </summary>
    ''' <returns><see cref="Integer"/> </returns>
    Public ReadOnly Property CsrfToken As Integer
        Get
            Return NativeMethods.CQ_getCsrfToken(cqauthcode)
        End Get
    End Property
    ''' <summary>
    ''' 获取当前插件的数据存储目录。
    ''' </summary>
    ''' <returns><See cref="String"/></returns>
    Public ReadOnly Property AppDirectory As String
        Get
            Return NativeMethods.CQ_getAppDirectory(cqauthcode)
        End Get
    End Property

End Class
