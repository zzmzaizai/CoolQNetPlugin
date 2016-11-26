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
End Class