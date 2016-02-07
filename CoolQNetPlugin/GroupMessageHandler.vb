Friend Class GroupMessageHandler
    Private gr As Long, sq As Long, message As String
    Private msgfont As Integer, timestamp As Integer
    Private isanonymous As Boolean
    Private plugins As IEnumerable(Of IGroupMessageHandler)
    Public Sub New(group As Long, senderqq As Long, msg As String, font As Integer, time As Integer)
        gr = group
        sq = senderqq
        message = msg
        msgfont = font
        timestamp = time
        isanonymous = False
    End Sub
    Public Sub Compose()
        If Not isanonymous Then
            Compose_Anonymous()
        End If
    End Sub
    Private Sub Compose_Anonymous()

    End Sub
End Class
