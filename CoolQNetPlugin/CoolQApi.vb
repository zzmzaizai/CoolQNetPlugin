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
        Public Shared Function CQ_getStrangerInfo(authCode As Integer, QQid As Long, nocache As Integer) As String

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
        info.NickName = Text.Encoding.[Default].GetString(nameBytes)

        Dim cardLengthBytes As Byte() = New Byte(1) {}
        Array.Copy(memberBytes, 18 + nameLength, cardLengthBytes, 0, 2)
        Array.Reverse(cardLengthBytes)
        Dim cardLength As Short = BitConverter.ToInt16(cardLengthBytes, 0)

        Dim cardBytes As Byte() = New Byte(cardLength - 1) {}
        Array.Copy(memberBytes, 20 + nameLength, cardBytes, 0, cardLength)
        info.InGroupName = Text.Encoding.[Default].GetString(cardBytes)

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
        info.Area = Text.Encoding.[Default].GetString(areaBytes)

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
        info.Level = Text.Encoding.[Default].GetString(levelNameBytes)

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
        info.Title = Text.Encoding.[Default].GetString(titleBytes)

        Dim titleExpireBytes As Byte() = New Byte(3) {}
        Array.Copy(memberBytes, 50 + nameLength + cardLength + areaLength + levelNameLength + titleLength, titleExpireBytes, 0, 4)
        Array.Reverse(titleExpireBytes)
        info.TitleExpirationTime = BitConverter.ToInt32(titleExpireBytes, 0)

        Dim modifyCardBytes As Byte() = New Byte(3) {}
        Array.Copy(memberBytes, 54 + nameLength + cardLength + areaLength + levelNameLength + titleLength, titleExpireBytes, 0, 4)
        Array.Reverse(titleExpireBytes)
        info.CanModifyInGroupName = BitConverter.ToInt32(titleExpireBytes, 0) = 1
        Return info
errhandle:
        Log(CoolQLogLevel.Error, Err.Description, "获取群成员信息")
        Err.Clear()
    End Function
    ''' <summary>
    ''' 给指定QQ点赞。
    ''' </summary>
    ''' <param name="qq">要点赞的QQ的号码。</param>
    Public Sub SendLike(qq As Long)
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
End Class
