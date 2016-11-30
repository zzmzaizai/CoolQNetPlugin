''' <summary>
''' 表示一个群成员的信息。
''' </summary>
Public NotInheritable Class GroupMemberInfo

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