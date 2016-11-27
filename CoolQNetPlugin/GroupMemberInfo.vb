''' <summary>
''' 表示一个群成员的信息。
''' </summary>
Public NotInheritable Class GroupMemberInfo

    ''' <summary>
    ''' 此群成员在其个人资料上所填写的年龄。
    ''' </summary>
    ''' <returns><see cref="Integer"/> </returns>
    Public Property Age As Integer
    ''' <summary>
    ''' 此群成员在其个人资料上所填写的区域。
    ''' </summary>
    ''' <returns><see cref="String"/> </returns>
    Public Property Area As String
    ''' <summary>
    ''' 此群成员的身份。
    ''' </summary>
    ''' <returns><see cref="String"/></returns>
    Public Property Authority As String
    ''' <summary>
    ''' 指示此群成员是否能够修改所有群成员名片的值。
    ''' </summary>
    ''' <returns><see cref="Boolean"/> </returns>
    Public Property CanModifyInGroupName As Boolean
    ''' <summary>
    ''' 此群成员在其个人资料上所填写的性别。
    ''' </summary>
    ''' <returns><see cref="String"/> </returns>
    Public Property Gender As String
    ''' <summary>
    ''' 此群成员的群名片。
    ''' </summary>
    ''' <returns><see cref="String"/> </returns>
    Public Property InGroupName As String
    ''' <summary>
    ''' 此群成员的头衔。
    ''' </summary>
    ''' <returns><see cref="String"/> </returns>
    Public Property Title As String
    ''' <summary>
    ''' 此群成员所在群号。
    ''' </summary>
    ''' <returns><see cref="Long"/> </returns>
    Public Property GroupId As Long
    ''' <summary>
    ''' 指示此群成员是否有不良记录的值。
    ''' </summary>
    ''' <returns><see cref="Boolean"/> </returns>
    Public Property HasBadRecord As Boolean
    ''' <summary>
    ''' 头衔过期时间。
    ''' </summary>
    ''' <returns><see cref="Integer"/> </returns>
    Public Property TitleExpirationTime As Integer
    ''' <summary>
    ''' 此群成员的入群时间。
    ''' </summary>
    ''' <returns><see cref="Date"/> </returns>
    Public Property JoinTime As Date
    ''' <summary>
    ''' 此群成员最后发言日期。
    ''' </summary>
    ''' <returns><see cref="Date"/> </returns>
    Public Property LastSpeakingTime As Date
    ''' <summary>
    ''' 此群成员的群内等级。
    ''' </summary>
    ''' <returns><see cref="String"/> </returns>
    Public Property Level As String
    ''' <summary>
    ''' 此群成员的昵称。
    ''' </summary>
    ''' <returns><see cref="String"/> </returns>
    Public Property NickName As String
    ''' <summary>
    ''' 此群成员的QQ号码。
    ''' </summary>
    ''' <returns><see cref="Long"/> </returns>
    Public Property Id As Long
End Class