''' <summary>
''' 表示一个群成员的信息。
''' </summary>
Public NotInheritable Class GroupMemberInfo
    Private info_age As Integer, info_area As String, info_authority As String
    Private p_canmodifycard As Boolean, info_gender As String, info_card As String
    Private info_title As String, info_groupnumber As Long, info_hasbadrecord As Boolean
    Private info_titleexpirationtime As Integer, info_joingroupdate As Date, info_lastspeaktime As Date
    Private info_level As String, info_nickname As String, info_qqnumber As Long
    Private Sub New()

    End Sub
    Friend Sub New(age As Integer, area As String, authority As String, canmodifycard As Boolean,
                   gender As String, card As String, title As String, groupnumber As Long, hasbardrecord As Boolean,
                   titleexpirationtime As Integer, joingroupdate As Date, lastspeaktime As Date, level As String,
                   nickname As String, qqnumber As Long)
        info_age = age
        info_area = area
        info_authority = authority
        p_canmodifycard = canmodifycard
        info_gender = gender
        info_card = card
        info_title = title
        info_groupnumber = groupnumber
        info_hasbadrecord = hasbardrecord
        info_titleexpirationtime = titleexpirationtime
        info_joingroupdate = joingroupdate
        info_level = level

    End Sub
    ''' <summary>
    ''' 获取此群成员在其个人资料上所填写的年龄。
    ''' </summary>
    ''' <returns><see cref="Integer"/> </returns>
    Public ReadOnly Property Age As Integer
        Get
            Return info_age
        End Get
    End Property
    ''' <summary>
    ''' 获取此群成员在其个人资料上所填写的区域。
    ''' </summary>
    ''' <returns><see cref="String"/> </returns>
    Public ReadOnly Property Area As String
        Get
            Return info_area
        End Get
    End Property
    ''' <summary>
    ''' 获取此群成员的身份。
    ''' </summary>
    ''' <returns><see cref="String"/></returns>
    Public ReadOnly Property Authority As String
        Get
            Return info_authority
        End Get
    End Property
    ''' <summary>
    ''' 获取指示此群成员是否能够修改所有群成员名片的值。
    ''' </summary>
    ''' <returns><see cref="Boolean"/> </returns>
    Public ReadOnly Property CanModifyInGroupName As Boolean
        Get
            Return p_canmodifycard
        End Get
    End Property
    ''' <summary>
    ''' 获取此群成员在其个人资料上所填写的性别。
    ''' </summary>
    ''' <returns><see cref="String"/> </returns>
    Public ReadOnly Property Gender As String
        Get
            Return info_gender
        End Get
    End Property
    ''' <summary>
    ''' 获取此群成员的群名片。
    ''' </summary>
    ''' <returns><see cref="String"/> </returns>
    Public ReadOnly Property InGroupName As String
        Get
            Return info_card
        End Get
    End Property
    ''' <summary>
    ''' 获取此群成员的头衔。
    ''' </summary>
    ''' <returns><see cref="String"/> </returns>
    Public ReadOnly Property Title As String
        Get
            Return info_title
        End Get
    End Property
    ''' <summary>
    ''' 获取此群成员所在群号。
    ''' </summary>
    ''' <returns><see cref="Long"/> </returns>
    Public ReadOnly Property GroupId As Long
        Get
            Return info_groupnumber
        End Get
    End Property
    ''' <summary>
    ''' 获取指示此群成员是否有不良记录的值。
    ''' </summary>
    ''' <returns><see cref="Boolean"/> </returns>
    Public ReadOnly Property HasBadRecord As Boolean
        Get
            Return info_hasbadrecord
        End Get
    End Property
    ''' <summary>
    ''' 获取头衔过期时间。
    ''' </summary>
    ''' <returns><see cref="Integer"/> </returns>
    Public ReadOnly Property TitleExpirationTime As Integer
        Get
            Return info_titleexpirationtime
        End Get
    End Property
    ''' <summary>
    ''' 获取此群成员的入群时间。
    ''' </summary>
    ''' <returns><see cref="Date"/> </returns>
    Public ReadOnly Property JoinTime As Date
        Get
            Return info_joingroupdate
        End Get
    End Property
    ''' <summary>
    ''' 获取此群成员最后发言日期。
    ''' </summary>
    ''' <returns><see cref="Date"/> </returns>
    Public ReadOnly Property LastSpeakingTime As Date
        Get
            Return info_lastspeaktime
        End Get
    End Property
    ''' <summary>
    ''' 获取此群成员的群内等级。
    ''' </summary>
    ''' <returns><see cref="String"/> </returns>
    Public ReadOnly Property Level As String
        Get
            Return info_level
        End Get
    End Property
    ''' <summary>
    ''' 获取此群成员的昵称。
    ''' </summary>
    ''' <returns><see cref="String"/> </returns>
    Public ReadOnly Property NickName As String
        Get
            Return info_nickname
        End Get
    End Property
    ''' <summary>
    ''' 获取此群成员的QQ号码。
    ''' </summary>
    ''' <returns><see cref="Long"/> </returns>
    Public ReadOnly Property Number As Long
        Get
            Return info_qqnumber
        End Get
    End Property
End Class