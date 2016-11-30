Imports System.ComponentModel
Imports System.Runtime.InteropServices
Imports System.Security
Imports System.Text

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
        <DllImport("CQP.dll", CallingConvention:=CallingConvention.StdCall, BestFitMapping:=False)>
        Public Shared Function CQ_sendPrivateMsg(authCode As Integer, QQid As Long, <MarshalAs(UnmanagedType.LPStr), [In]> message As String) As Integer

        End Function
        <DllImport("CQP.dll", CallingConvention:=CallingConvention.StdCall, BestFitMapping:=False)>
        Public Shared Function CQ_sendGroupMsg(authCode As Integer, groupId As Long, <MarshalAs(UnmanagedType.LPStr), [In]> message As String) As Integer

        End Function
        <DllImport("CQP.dll", CallingConvention:=CallingConvention.StdCall, BestFitMapping:=False)>
        Public Shared Function CQ_sendDiscussMsg(authCode As Integer, discussId As Long, <MarshalAs(UnmanagedType.LPStr), [In]> message As String) As Integer

        End Function
        <DllImport("CQP.dll", CallingConvention:=CallingConvention.StdCall, BestFitMapping:=False)>
        Public Shared Function CQ_sendLike(authCode As Integer, QQid As Long) As Integer

        End Function
        <DllImport("CQP.dll", CallingConvention:=CallingConvention.StdCall, BestFitMapping:=False)>
        Public Shared Function CQ_setGroupKick(authCode As Integer, groupId As Long, QQid As Long, rejectAddRequest As Integer) As Integer

        End Function
        <DllImport("CQP.dll", CallingConvention:=CallingConvention.StdCall, BestFitMapping:=False)>
        Public Shared Function CQ_setGroupBan(authCode As Integer, groupId As Long, QQid As Long, duration As Long) As Integer
            '
        End Function
        <DllImport("CQP.dll", CallingConvention:=CallingConvention.StdCall, BestFitMapping:=False)>
        Public Shared Function CQ_setGroupAdmin(authCode As Integer, groupId As Long, QQid As Long, setAdmin As Integer) As Integer

        End Function
        <DllImport("CQP.dll", CallingConvention:=CallingConvention.StdCall, BestFitMapping:=False)>
        Public Shared Function CQ_setGroupWholeBan(authCode As Integer, groupId As Long, enableban As Integer) As Integer

        End Function
        <DllImport("CQP.dll", CallingConvention:=CallingConvention.StdCall, BestFitMapping:=False)>
        Public Shared Function CQ_setGroupAnonymousBan(authCode As Integer, groupId As Long, <MarshalAs(UnmanagedType.LPStr), [In]> anonymous As String, duration As Long) As Integer

        End Function
        <DllImport("CQP.dll", CallingConvention:=CallingConvention.StdCall, BestFitMapping:=False)>
        Public Shared Function CQ_setGroupAnonymous(authCode As Integer, groupId As Long, enableAnomymous As Integer) As Integer

        End Function
        <DllImport("CQP.dll", CallingConvention:=CallingConvention.StdCall, BestFitMapping:=False)>
        Public Shared Function CQ_setGroupCard(authCode As Integer, groupId As Long, QQid As Long, <MarshalAs(UnmanagedType.LPStr), [In]> newCard As String) As Integer

        End Function
        <DllImport("CQP.dll", CallingConvention:=CallingConvention.StdCall, BestFitMapping:=False)>
        Public Shared Function CQ_setGroupLeave(authCode As Integer, groupId As Long, isdismissed As Integer) As Integer

        End Function
        <DllImport("CQP.dll", CallingConvention:=CallingConvention.StdCall, BestFitMapping:=False)>
        Public Shared Function CQ_setGroupSpecialTitle(authCode As Integer, groupId As Long, QQid As Long, <MarshalAs(UnmanagedType.LPStr), [In]> newTitle As String, duration As Long) As Integer

        End Function
        <DllImport("CQP.dll", CallingConvention:=CallingConvention.StdCall, BestFitMapping:=False)>
        Public Shared Function CQ_setDiscussLeave(authCode As Integer, discussGroupId As Long) As Integer

        End Function
        <DllImport("CQP.dll", CallingConvention:=CallingConvention.StdCall, BestFitMapping:=False)>
        Public Shared Function CQ_setFriendAddRequest(authCode As Integer, <MarshalAs(UnmanagedType.LPStr), [In]> responseFlag As String, responseOperation As Integer, <MarshalAs(UnmanagedType.LPStr), [In]> remark As String) As Integer

        End Function
        <DllImport("CQP.dll", CallingConvention:=CallingConvention.StdCall, BestFitMapping:=False)>
        Public Shared Function CQ_setGroupAddRequestV2(authCode As Integer, <MarshalAs(UnmanagedType.LPStr), [In]> responseFlag As String, requestType As Integer, responseOperation As Integer, <MarshalAs(UnmanagedType.LPStr), [In]> reason As String) As Integer

        End Function
        <DllImport("CQP.dll", CallingConvention:=CallingConvention.StdCall, BestFitMapping:=False)>
        Public Shared Function CQ_getGroupMemberInfoV2(authCode As Integer, groupId As Long, QQid As Long, nocache As Integer) As String

        End Function
        <DllImport("CQP.dll", CallingConvention:=CallingConvention.StdCall, BestFitMapping:=False)>
        Public Shared Function CQ_addLog(authCode As Integer, priority As Integer, <MarshalAs(UnmanagedType.LPStr), [In]> category As String, <MarshalAs(UnmanagedType.LPStr), [In]> content As String) As Integer

        End Function
        <DllImport("CQP.dll", CallingConvention:=CallingConvention.StdCall, BestFitMapping:=False)>
        Public Shared Function CQ_getCookies(authCode As Integer) As String

        End Function
        <DllImport("CQP.dll", CallingConvention:=CallingConvention.StdCall, BestFitMapping:=False)>
        Public Shared Function CQ_getCsrfToken(authCode As Integer) As Integer

        End Function
        <DllImport("CQP.dll", CallingConvention:=CallingConvention.StdCall, BestFitMapping:=False)>
        Public Shared Function CQ_getLoginQQ(authCode As Integer) As Long

        End Function
        <DllImport("CQP.dll", CallingConvention:=CallingConvention.StdCall, BestFitMapping:=False)>
        Public Shared Function CQ_getLoginNick(authCode As Integer) As String

        End Function
        <DllImport("CQP.dll", CallingConvention:=CallingConvention.StdCall, BestFitMapping:=False)>
        Public Shared Function CQ_getAppDirectory(authCode As Integer) As String

        End Function

    End Class
    ''' <summary>
    ''' 向指定的QQ发送私聊消息。
    ''' </summary>
    ''' <param name="qq">接收此消息的QQ。</param>
    ''' <param name="message">私聊消息内容。</param>
    Public Sub SendPrivateMessage(qq As Long, message As String)
        NativeMethods.CQ_sendPrivateMsg(cqauthcode, qq, message)
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
        NativeMethods.CQ_sendDiscussMsg(cqauthcode, dicussGroupId, message)
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
    ''' <summary>
    ''' 把日志写入到酷Q运行日志中。
    ''' </summary>
    ''' <param name="level">日志等级。</param>
    ''' <param name="message">日志内容。</param>
    Public Sub Log(level As CoolQLogLevel, message As String)
        NativeMethods.CQ_addLog(cqauthcode, level, level.ToString, message)
    End Sub
    ''' <summary>
    ''' 把日志写入到酷Q运行日志中。
    ''' </summary>
    ''' <param name="level">日志等级。</param>
    ''' <param name="message">日志内容。</param>
    ''' <param name="category">日志类别。</param>
    Public Sub Log(level As CoolQLogLevel, message As String, category As String)
        NativeMethods.CQ_addLog(cqauthcode, level, category, message)
    End Sub
    ''' <summary>
    ''' 获取酷Q当前登录账户的昵称。
    ''' </summary>
    ''' <returns><see cref="String"/> </returns>
    Public ReadOnly Property NickName As String
        Get
            Return NativeMethods.CQ_getLoginNick(cqauthcode)
        End Get
    End Property
    ''' <summary>
    ''' 获取酷Q当前登录账户的QQ号码。
    ''' </summary>
    ''' <returns><see cref="Long"/> </returns>
    Public ReadOnly Property Number As Long
        Get
            Return NativeMethods.CQ_getLoginQQ(cqauthcode)
        End Get
    End Property
    ''' <summary>
    ''' 获取缓存的群成员信息。
    ''' </summary>
    ''' <param name="groupId">要获取信息的群成员的所在群。</param>
    ''' <param name="qq">要获取信息的群成员QQ。</param>
    ''' <returns><see cref="GroupMemberInfo"/></returns>
    ''' <remarks>此函数采用Flexlive的处理方法。</remarks>
    Public Function GetGroupMemberInfo(groupId As Long, qq As Long) As GroupMemberInfo
        On Error GoTo errhandle
        Dim data As String = NativeMethods.CQ_getGroupMemberInfoV2(cqauthcode, groupId, qq, 0)
        Dim memberBytes As Byte() = Convert.FromBase64String(data)
        Dim info As New GroupMemberInfo
        Dim groupNumberBytes As Byte() = New Byte(7) {}

        Array.Copy(memberBytes, 0, groupNumberBytes, 0, 8)
        Array.Reverse(groupNumberBytes)
        info.GroupId = BitConverter.ToInt64(groupNumberBytes, 0)

        Dim qqNumberBytes As Byte() = New Byte(7) {}
        Array.Copy(memberBytes, 8, qqNumberBytes, 0, 8)
        Array.Reverse(qqNumberBytes)
        info.Number = BitConverter.ToInt64(qqNumberBytes, 0)

        Dim nameLengthBytes As Byte() = New Byte(1) {}
        Array.Copy(memberBytes, 16, nameLengthBytes, 0, 2)
        Array.Reverse(nameLengthBytes)
        Dim nameLength As Short = BitConverter.ToInt16(nameLengthBytes, 0)

        Dim nameBytes As Byte() = New Byte(nameLength - 1) {}
        Array.Copy(memberBytes, 18, nameBytes, 0, nameLength)
        info.NickName = Encoding.[Default].GetString(nameBytes)

        Dim cardLengthBytes As Byte() = New Byte(1) {}
        Array.Copy(memberBytes, 18 + nameLength, cardLengthBytes, 0, 2)
        Array.Reverse(cardLengthBytes)
        Dim cardLength As Short = BitConverter.ToInt16(cardLengthBytes, 0)

        Dim cardBytes As Byte() = New Byte(cardLength - 1) {}
        Array.Copy(memberBytes, 20 + nameLength, cardBytes, 0, cardLength)
        info.InGroupName = Encoding.[Default].GetString(cardBytes)

        Dim genderBytes As Byte() = New Byte(3) {}
        Array.Copy(memberBytes, 20 + nameLength + cardLength, genderBytes, 0, 4)
        Array.Reverse(genderBytes)
        info.Gender = If(BitConverter.ToInt32(genderBytes, 0) = 0, "男", " 女")

        Dim ageBytes As Byte() = New Byte(3) {}
        Array.Copy(memberBytes, 24 + nameLength + cardLength, ageBytes, 0, 4)
        Array.Reverse(ageBytes)
        info.Age = BitConverter.ToInt32(ageBytes, 0)

        Dim areaLengthBytes As Byte() = New Byte(1) {}
        Array.Copy(memberBytes, 28 + nameLength + cardLength, areaLengthBytes, 0, 2)
        Array.Reverse(areaLengthBytes)
        Dim areaLength As Short = BitConverter.ToInt16(areaLengthBytes, 0)

        Dim areaBytes As Byte() = New Byte(areaLength - 1) {}
        Array.Copy(memberBytes, 30 + nameLength + cardLength, areaBytes, 0, areaLength)
        info.Area = Encoding.[Default].GetString(areaBytes)

        Dim addGroupTimesBytes As Byte() = New Byte(3) {}
        Array.Copy(memberBytes, 30 + nameLength + cardLength + areaLength, addGroupTimesBytes, 0, 4)
        Array.Reverse(addGroupTimesBytes)
        info.JoinTime = New DateTime(1970, 1, 1, 0, 0, 0).ToLocalTime().AddSeconds(BitConverter.ToInt32(addGroupTimesBytes, 0))

        Dim lastSpeakTimesBytes As Byte() = New Byte(3) {}
        Array.Copy(memberBytes, 34 + nameLength + cardLength + areaLength, lastSpeakTimesBytes, 0, 4)
        Array.Reverse(lastSpeakTimesBytes)
        info.LastSpeakingTime = New DateTime(1970, 1, 1, 0, 0, 0).ToLocalTime().AddSeconds(BitConverter.ToInt32(lastSpeakTimesBytes, 0))

        Dim levelNameLengthBytes As Byte() = New Byte(1) {}
        Array.Copy(memberBytes, 38 + nameLength + cardLength + areaLength, levelNameLengthBytes, 0, 2)
        Array.Reverse(levelNameLengthBytes)
        Dim levelNameLength As Short = BitConverter.ToInt16(levelNameLengthBytes, 0)

        Dim levelNameBytes As Byte() = New Byte(levelNameLength - 1) {}
        Array.Copy(memberBytes, 40 + nameLength + cardLength + areaLength, levelNameBytes, 0, levelNameLength)
        info.Level = Encoding.[Default].GetString(levelNameBytes)

        Dim authorBytes As Byte() = New Byte(3) {}
        Array.Copy(memberBytes, 40 + nameLength + cardLength + areaLength + levelNameLength, authorBytes, 0, 4)
        Array.Reverse(authorBytes)
        Dim authority As Integer = BitConverter.ToInt32(authorBytes, 0)
        info.Authority = If(authority = 3, "群主", (If(authority = 2, "管理员", "成员")))

        Dim badBytes As Byte() = New Byte(3) {}
        Array.Copy(memberBytes, 44 + nameLength + cardLength + areaLength + levelNameLength, badBytes, 0, 4)
        Array.Reverse(badBytes)
        info.HasBadRecord = BitConverter.ToInt32(badBytes, 0) = 1

        Dim titleLengthBytes As Byte() = New Byte(1) {}
        Array.Copy(memberBytes, 48 + nameLength + cardLength + areaLength + levelNameLength, titleLengthBytes, 0, 2)
        Array.Reverse(titleLengthBytes)
        Dim titleLength As Short = BitConverter.ToInt16(titleLengthBytes, 0)

        Dim titleBytes As Byte() = New Byte(titleLength - 1) {}
        Array.Copy(memberBytes, 50 + nameLength + cardLength + areaLength + levelNameLength, titleBytes, 0, titleLength)
        info.Title = Encoding.[Default].GetString(titleBytes)

        Dim titleExpireBytes As Byte() = New Byte(3) {}
        Array.Copy(memberBytes, 50 + nameLength + cardLength + areaLength + levelNameLength + titleLength, titleExpireBytes, 0, 4)
        Array.Reverse(titleExpireBytes)
        info.TitleExpirationTime = BitConverter.ToInt32(titleExpireBytes, 0)

        Dim modifyCardBytes As Byte() = New Byte(3) {}
        Array.Copy(memberBytes, 54 + nameLength + cardLength + areaLength + levelNameLength + titleLength, titleExpireBytes, 0, 4)
        Array.Reverse(titleExpireBytes)
        info.CanModifyInGroupName = BitConverter.ToInt32(modifyCardBytes, 0) = 1
        Return info
errhandle:
        Log(CoolQLogLevel.Error, Err.Description, "获取群成员信息")
        Err.Clear()
    End Function
    ''' <summary>
    ''' 给指定QQ点赞。
    ''' </summary>
    ''' <param name="qq">要点赞的QQ的号码。</param>
    Public Sub SendGood(qq As Long)
        NativeMethods.CQ_sendLike(cqauthcode, qq)
    End Sub
    ''' <summary>
    ''' 处理好友请求。
    ''' </summary>
    ''' <param name="responseMark">用于处理此好友请求的反馈标识。</param>
    ''' <param name="result">是否通过此请求。</param>
    Public Sub ProcessAddFriendRequest(responseMark As String, result As CoolQRequestResult)
        NativeMethods.CQ_setFriendAddRequest(cqauthcode, responseMark, result, "")
    End Sub
    ''' <summary>
    ''' 处理好友请求。
    ''' </summary>
    ''' <param name="responseMark">用于处理此好友请求的反馈标识。</param>
    ''' <param name="result">是否通过此请求。</param>
    ''' <param name="remark">对此好友的备注名。</param>
    Public Sub ProcessAddFriendRequest(responseMark As String, result As CoolQRequestResult, remark As String)
        NativeMethods.CQ_setFriendAddRequest(cqauthcode, responseMark, result, remark)
    End Sub
    ''' <summary>
    ''' 把指定QQ从指定群中踢出。
    ''' </summary>
    ''' <param name="groupId">要踢出QQ的群。</param>
    ''' <param name="qq">要踢出的QQ。</param>
    ''' <param name="rejectAddGroupRequest">指示是否不再处理此人的加群申请。</param>
    Public Sub KickFromGroup(groupId As Long, qq As Long, rejectAddGroupRequest As Boolean)
        NativeMethods.CQ_setGroupKick(cqauthcode, groupId, qq, rejectAddGroupRequest)
    End Sub
    ''' <summary>
    ''' 对在指定群里的指定QQ进行禁言。
    ''' </summary>
    ''' <param name="groupId">要进行禁言操作的群。</param>
    ''' <param name="qq">要禁言的QQ。</param>
    ''' <param name="duration">禁言持续时长。</param>
    Public Sub Ban(groupId As Long, qq As Long, duration As TimeSpan)
        Dim totalsec As Long = Math.Floor(duration.TotalSeconds)
        NativeMethods.CQ_setGroupBan(cqauthcode, groupId, qq, totalsec)
    End Sub
    ''' <summary>
    ''' 对在指定群里的指定QQ进行禁言。
    ''' </summary>
    ''' <param name="groupId">要进行禁言操作的群。</param>
    ''' <param name="qq">要禁言的QQ。</param>
    ''' <param name="duration">禁言持续秒数。</param>
    Public Sub Ban(groupId As Long, qq As Long, duration As Integer)
        NativeMethods.CQ_setGroupBan(cqauthcode, groupId, qq, duration)
    End Sub
    ''' <summary>
    ''' 在指定群内对被禁言的QQ执行解除禁言操作。
    ''' </summary>
    ''' <param name="groupId">要进行解除禁言操作的群。</param>
    ''' <param name="qq">要解除禁言的QQ。</param>
    Public Sub RemoveBanned(groupId As Long, qq As Long)
        Ban(groupId, qq, 0)
    End Sub
    ''' <summary>
    ''' 把指定QQ设定为指定群的管理员。
    ''' </summary>
    ''' <param name="groupId">要进行操作的群。</param>
    ''' <param name="qq">要被提升为管理员的QQ。</param>
    Public Sub SetAsAdmin(groupId As Long, qq As Long)
        NativeMethods.CQ_setGroupAdmin(cqauthcode, groupId, qq, 1)
    End Sub
    ''' <summary>
    ''' 把指定群指定QQ的群管理员身份取消。
    ''' </summary>
    ''' <param name="groupId">要执行操作的群。</param>
    ''' <param name="qq">要取消管理员的QQ。</param>
    Public Sub RevokeAdmin(groupId As Long, qq As Long)
        NativeMethods.CQ_setGroupAdmin(cqauthcode, groupId, qq, 0)
    End Sub
    ''' <summary>
    ''' 对指定群执行全体禁言操作。
    ''' </summary>
    ''' <param name="groupId">要进行全体禁言的群。</param>
    Public Sub BanAll(groupId As Long)
        NativeMethods.CQ_setGroupWholeBan(cqauthcode, groupId, 1)
    End Sub
    ''' <summary>
    ''' 解除指定群的全体禁言状态。
    ''' </summary>
    ''' <param name="groupId">要解除全体禁言状态的群。</param>
    Public Sub RemoveBannedAll(groupId As Long)
        NativeMethods.CQ_setGroupWholeBan(cqauthcode, groupId, 0)
    End Sub
    ''' <summary>
    ''' 对在指定群里的指定匿名用户进行禁言。在对指定的匿名用户进行禁言后，不能解除匿名用户的禁言状态。
    ''' </summary>
    ''' <param name="groupId">要进行禁言操作的群。</param>
    ''' <param name="anonymous">要禁言的匿名用户。</param>
    ''' <param name="duration">禁言持续时长。</param>
    Public Sub BanAnonymous(groupId As Long, anonymous As String, duration As TimeSpan)
        NativeMethods.CQ_setGroupAnonymousBan(cqauthcode, groupId, anonymous, Math.Floor(duration.TotalSeconds))
    End Sub
    ''' <summary>
    ''' 对在指定群里的指定匿名用户进行禁言。在对指定的匿名用户进行禁言后，不能解除匿名用户的禁言状态。
    ''' </summary>
    ''' <param name="groupId">要进行禁言操作的群。</param>
    ''' <param name="anonymous">要禁言的匿名用户。</param>
    ''' <param name="duration">禁言持续秒数。</param>
    Public Sub BanAnonymous(groupId As Long, anonymous As String, duration As Long)
        NativeMethods.CQ_setGroupAnonymousBan(cqauthcode, groupId, anonymous, duration)
    End Sub
    ''' <summary>
    ''' 打开指定的群的匿名聊天。
    ''' </summary>
    ''' <param name="groupId">要打开匿名聊天的群。</param>
    Public Sub EnableAnonymousChat(groupId As Long)
        NativeMethods.CQ_setGroupAnonymous(cqauthcode, groupId, 1)
    End Sub
    ''' <summary>
    ''' 关闭指定的群的匿名聊天。
    ''' </summary>
    ''' <param name="groupId">要关闭匿名聊天的群。</param>
    Public Sub DisableAnonymousChat(groupId As Long)
        NativeMethods.CQ_setGroupAnonymous(cqauthcode, groupId, 0)
    End Sub
    ''' <summary>
    ''' 修改在指定群内指定QQ的群名片。
    ''' </summary>
    ''' <param name="groupId">要执行操作的群。</param>
    ''' <param name="qq">要修改名片的QQ。</param>
    ''' <param name="newCard">新名片内容。</param>
    Public Sub SetGroupCard(groupId As Long, qq As Long, newCard As String)
        NativeMethods.CQ_setGroupCard(cqauthcode, groupId, qq, newCard)
    End Sub
    ''' <summary>
    ''' 退出指定群。
    ''' </summary>
    ''' <param name="groupId">要退出的群的群号。</param>
    Public Sub QuitTheGroup(groupId As Long)
        NativeMethods.CQ_setGroupLeave(cqauthcode, groupId, 0)
    End Sub
    ''' <summary>
    ''' 退出并解散指定群。
    ''' </summary>
    ''' <param name="groupId">要退出并解散的群的群号。</param>
    Public Sub QuitAndDismissTheGroup(groupId As Long)
        NativeMethods.CQ_setGroupLeave(cqauthcode, groupId, 1)
    End Sub
    ''' <summary>
    ''' 赋予指定群内指定成员永久群成员专属头衔。
    ''' </summary>
    ''' <param name="groupId">要执行操作的群。</param>
    ''' <param name="qq">要赋予头衔的QQ。</param>
    ''' <param name="newTitle">头衔内容。</param>
    Public Sub SetGroupTitle(groupId As Long, qq As Long, newTitle As String)
        NativeMethods.CQ_setGroupSpecialTitle(cqauthcode, groupId, qq, newTitle, -1)
    End Sub
    ''' <summary>
    ''' 赋予指定群内指定成员会过期的群成员专属头衔。
    ''' </summary>
    ''' <param name="groupId">要执行操作的群。</param>
    ''' <param name="qq">要赋予头衔的QQ。</param>
    ''' <param name="newTitle">头衔内容。</param>
    ''' <param name="duration">头衔生效时间。（单位：秒）</param>
    Public Sub SetGroupTitle(groupId As Long, qq As Long, newTitle As Long, duration As Long)
        NativeMethods.CQ_setGroupSpecialTitle(cqauthcode, groupId, qq, newTitle, duration)
    End Sub
    ''' <summary>
    ''' 退出指定的讨论组。
    ''' </summary>
    ''' <param name="discussGroupId">要退出的讨论组的ID。</param>
    Public Sub QuitTheDiscussGroup(discussGroupId As Long)
        NativeMethods.CQ_setDiscussLeave(cqauthcode, discussGroupId)
    End Sub
    ''' <summary>
    ''' 处理加群请求。
    ''' </summary>
    ''' <param name="responseMark">用于处理请求的反馈标识。</param>
    ''' <param name="resquestType">请求类型。</param>
    ''' <param name="operation">请求处理结果。</param>
    ''' <param name="reason">附言。</param>
    Public Sub ProcessAddGroupRequest(responseMark As String, resquestType As CoolQAddGroupRequestType, operation As CoolQRequestResult, reason As String)
        NativeMethods.CQ_setGroupAddRequestV2(cqauthcode, responseMark, resquestType, operation, reason)
    End Sub
End Class