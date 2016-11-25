Imports System.ComponentModel
Imports System.Runtime.InteropServices

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
End Class
