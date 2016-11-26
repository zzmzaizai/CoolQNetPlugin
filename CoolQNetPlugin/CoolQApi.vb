Imports System.ComponentModel
Imports System.Runtime.InteropServices
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

End Class
