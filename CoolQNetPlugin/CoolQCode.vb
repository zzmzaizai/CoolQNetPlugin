''' <summary>
''' 表示酷Q代码合集。
''' </summary>
Public MustInherit Class CoolQCode
    'CQCode_Anonymous(Boolean) : String
    ''' <summary>
    ''' 获取酷Q匿名代码。
    ''' </summary>
    ''' <param name="ignore">是否要强制匿名。</param>
    ''' <returns><see cref="String"/> </returns>
    Public Shared Function Anonymous(ignore As Boolean) As String
        Return "[CQ:anonymous" + If(ignore, "ignore=true", "") + "]"
    End Function
    ''' <summary>
    ''' 获取用于@指定QQ的代码。
    ''' </summary>
    ''' <param name="number">要被@的QQ的号码。如果为@全体成员，则为-1。</param>
    ''' <returns><see cref="String"/> </returns>
    Public Shared Function At(number As Long) As String
        Return "[CQ:at,qq=" + If(number = -1, "all", number.ToString) + "]"
    End Function
    ''' <summary>
    ''' 获取用于发送特定Emoji表情的代码。
    ''' </summary>
    ''' <param name="id">Emoji表情ID。 </param>
    ''' <returns><see cref="String"/> </returns>
    Public Shared Function Emoji(id As Integer) As String
        Return "[CQ:emoji,id=" + id.ToString + "]"
    End Function
    ''' <summary>
    ''' 获取用于发送表情的代码。
    ''' </summary>
    ''' <param name="id">表情ID。 </param>
    ''' <returns><see cref="String"/> </returns>
    Public Shared Function Expression(id As Integer) As String
        Return "[CQ:face,id=" + id.ToString + "]"
    End Function
    ''' <summary>
    ''' 获取用于发送自定义图片的代码。
    ''' </summary>
    ''' <param name="imagePath">自定义图片路径。</param>
    ''' <returns><see cref="String"/> </returns>
    Public Shared Function Image(imagePath As String) As String
        Return "[CQ:image,file=" + imagePath + "]"
    End Function
    ''' <summary>
    ''' 获取用于分享音乐的代码。
    ''' </summary>
    ''' <param name="id">音乐索引。</param>
    ''' <returns><see cref="String"/> </returns>
    Public Shared Function ShareMusic(id As Integer) As String
        Return "[CQ:music,id" + id.ToString + "]"
    End Function
    '''' <summary>
    '''' 获取用于分享自定义音乐的代码。
    '''' </summary>
    '''' <param name="descriptionUrl">描述自定义音乐的Url。</param>
    '''' <param name="audioUrl">音乐文件的Url</param>
    '''' <param name="title">分享标题，建议12字以内。</param>
    '''' <param name="content">分享内容，建议30字以内。</param>
    '''' <param name="imageUrl">分享链接的图片的Url。</param>
    '''' <returns><see cref="String"/> </returns>
    'Public Shared Function ShareMusic(descriptionUrl As String, audioUrl As String, title As String, content As String, imageUrl As String) As String
    '    Return "[CQ:music,type=custom,url=" + descriptionUrl + ",audio=" + audioUrl + ",title=" + title + ",content=" + content + ",image=" + imageUrl + "]"
    'End Function
    ''' <summary>
    ''' 获取用于分享自定义音乐的代码。
    ''' </summary>
    ''' <param name="descriptionUri">描述自定义音乐的Url。</param>
    ''' <param name="audioUri">音乐文件的Url</param>
    ''' <param name="title">分享标题，建议12字以内。</param>
    ''' <param name="content">分享内容，建议30字以内。</param>
    ''' <param name="imageUri">分享链接的图片的Url。</param>
    ''' <returns><see cref="String"/> </returns>
    Public Shared Function ShareMusic(descriptionUri As Uri, audioUri As Uri, title As String, content As String, imageUri As Uri) As String
        If descriptionUri Is Nothing OrElse audioUri Is Nothing OrElse imageUri Is Nothing Then
            Return ""
        End If
        Return "[CQ:music,type=custom,url=" + descriptionUri.ToString + ",audio=" + audioUri.ToString + ",title=" + title + ",content=" + content + ",image=" + imageUri.ToString + "]"
    End Function
    ''' <summary>
    ''' 获取用于分享本地音频文件的代码。
    ''' </summary>
    ''' <param name="recordFileName">音频文件的完整路径。</param>
    ''' <returns><see cref="String"/> </returns>
    Public Shared Function ShareRecord(recordFileName As String) As String
        Return "[CQ:record,file=" + recordFileName + "]"
    End Function
    ''' <summary>
    ''' 获取戳了一下（即窗口抖动）的代码。
    ''' </summary>
    ''' <returns><see cref="String"/> </returns>
    Public Shared Function Shake() As String
        Return "[CQ:shake]"
    End Function
    '''' <summary>
    '''' 获取分享自定义链接的代码。
    '''' </summary>
    '''' <param name="url">自定义链接的Url。</param>
    '''' <param name="title">分享内容标题，建议12字以内。</param>
    '''' <param name="content">分享内容，建议30字以内。</param>
    '''' <param name="imageUrl">分享内容的附带图片。</param>
    '''' <returns><see cref="String"/> </returns>
    'Public Shared Function ShareLink(url As String, title As String, content As String, imageUrl As String) As String
    '    Return "[CQ:share,url=" + url + ",title=" + title + ",content=" + content + ",image=" + imageUrl + "]"
    'End Function
    ''' <summary>
    ''' 获取分享自定义链接的代码。
    ''' </summary>
    ''' <param name="uri">自定义链接的Url。</param>
    ''' <param name="title">分享内容标题，建议12字以内。</param>
    ''' <param name="content">分享内容，建议30字以内。</param>
    ''' <param name="imageUri">分享内容的附带图片。</param>
    ''' <returns><see cref="String"/> </returns>
    Public Shared Function ShareLink(uri As Uri, title As String, content As String, imageUri As Uri) As String
        If uri Is Nothing OrElse imageUri Is Nothing Then
            Return ""
        End If
        Return "[CQ:share,url=" + uri.ToString + ",title=" + title + ",content=" + content + ",image=" + imageUri.ToString + "]"
    End Function

End Class
