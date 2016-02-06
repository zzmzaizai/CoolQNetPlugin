Imports System.Runtime.InteropServices
Imports System.Text
Friend MustInherit Class NativeMethods
    <DllImport("kernel32", CharSet:=CharSet.Unicode)>
    Public Shared Function WritePrivateProfileString(section As String, key As String, val As String, filepath As String) As UInteger
    End Function
    <DllImport("kernel32", CharSet:=CharSet.Unicode)>
    Public Shared Function GetPrivateProfileString(section As String, key As String, def As String, retval As StringBuilder, size As Integer, filePath As String) As UInteger
    End Function
End Class
