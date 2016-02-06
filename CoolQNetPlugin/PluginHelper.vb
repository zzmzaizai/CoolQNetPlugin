Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Text
''' <summary>
''' 提供插件辅助方法。
''' </summary>
Public Module PluginHelper
    ''' <summary>
    ''' 获取数据路径。
    ''' </summary>
    ''' <returns><see cref="String"/></returns>
    Public ReadOnly Property DataPath As String
        Get
            Return My.Settings.DataPath
        End Get
    End Property
    Friend ReadOnly Property ShadowCopyPath As String
        Get
            Return Path.Combine(DataPath, "ShadowCopyCache")
        End Get
    End Property
    Friend ReadOnly Property PluginPath As String
        Get
            Return Path.Combine(DataPath, "Plugins")
        End Get
    End Property
    ' Methods
    <DllImport("kernel32.dll", CharSet:=CharSet.Auto)>
    Private Function GetPrivateProfileSection(ByVal lpAppName As String, ByVal lpReturnedString As IntPtr, ByVal nSize As UInt32, ByVal lpFileName As String) As UInt32
    End Function

    <DllImport("kernel32.dll", CharSet:=CharSet.Auto)>
    Private Function GetPrivateProfileSectionNames(ByVal lpszReturnBuffer As IntPtr, ByVal nSize As UInt32, ByVal lpFileName As String) As UInt32
    End Function

    <DllImport("kernel32.dll", CharSet:=CharSet.Auto)>
    Private Function GetPrivateProfileString(ByVal lpAppName As String, ByVal lpKeyName As String, ByVal lpDefault As String, <[In], Out> ByVal lpReturnedString As Char(), ByVal nSize As UInt32, ByVal lpFileName As String) As UInt32
    End Function

    <DllImport("kernel32.dll", CharSet:=CharSet.Auto)>
    Private Function GetPrivateProfileString(ByVal lpAppName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As UInt32, ByVal lpFileName As String) As UInt32
    End Function

    <DllImport("kernel32.dll", CharSet:=CharSet.Auto)>
    Private Function GetPrivateProfileString(ByVal lpAppName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As StringBuilder, ByVal nSize As UInt32, ByVal lpFileName As String) As UInt32
    End Function

    Public Function INIDeleteKey(ByVal iniFile As String, ByVal section As String, ByVal key As String) As Boolean
        If String.IsNullOrEmpty(section) Then
            Throw New ArgumentException("必须指定节点名称", "section")
        End If
        If String.IsNullOrEmpty(key) Then
            Throw New ArgumentException("必须指定键名称", "key")
        End If
        Return WritePrivateProfileString(section, key, Nothing, iniFile)
    End Function

    Public Function INIDeleteSection(ByVal iniFile As String, ByVal section As String) As Boolean
        If String.IsNullOrEmpty(section) Then
            Throw New ArgumentException("必须指定节点名称", "section")
        End If
        Return WritePrivateProfileString(section, Nothing, Nothing, iniFile)
    End Function

    Public Function INIEmptySection(ByVal iniFile As String, ByVal section As String) As Boolean
        If String.IsNullOrEmpty(section) Then
            Throw New ArgumentException("必须指定节点名称", "section")
        End If
        Return WritePrivateProfileSection(section, String.Empty, iniFile)
    End Function

    Public Function INIGetAllItemKeys(ByVal iniFile As String, ByVal section As String) As String()
        Dim strArray As String() = New String(0 - 1) {}
        If String.IsNullOrEmpty(section) Then
            Throw New ArgumentException("必须指定节点名称", "section")
        End If
        Dim lpReturnedString As Char() = New Char(&H2800 - 1) {}
        If (GetPrivateProfileString(section, Nothing, Nothing, lpReturnedString, &H2800, iniFile) <> 0) Then
            strArray = New String(lpReturnedString).Split(New Char(1 - 1) {}, StringSplitOptions.RemoveEmptyEntries)
        End If
        lpReturnedString = Nothing
        Return strArray
    End Function

    Public Function INIGetAllItems(ByVal iniFile As String, ByVal section As String) As String()
        Dim nSize As UInt32 = &H7FFF
        Dim strArray As String() = New String(0 - 1) {}
        Dim lpReturnedString As IntPtr = Marshal.AllocCoTaskMem(CInt((nSize * 2)))
        Dim num2 As UInt32 = GetPrivateProfileSection(section, lpReturnedString, nSize, iniFile)
        If ((num2 <> (nSize - 2)) OrElse (num2 = 0)) Then
            strArray = Marshal.PtrToStringAuto(lpReturnedString, CInt(num2)).Split(New Char(1 - 1) {}, StringSplitOptions.RemoveEmptyEntries)
        End If
        Marshal.FreeCoTaskMem(lpReturnedString)
        Return strArray
    End Function

    Public Function INIGetAllItemsWithoutKeys(ByVal iniFile As String, ByVal section As String) As String()
        Dim strArray As String() = INIGetAllItems(iniFile, section)
        Dim i As Integer
        For i = 0 To strArray.Length - 1
            Dim separator As Char() = New Char() {"="c}
            Dim strArray2 As String() = strArray(i).Split(separator)
            If (strArray2.Length > 1) Then
                strArray(i) = strArray2(1)
            End If
        Next i
        Return strArray
    End Function

    Public Function INIGetAllSectionNames(ByVal iniFile As String) As String()
        Dim nSize As UInt32 = &H7FFF
        Dim strArray As String() = New String(0 - 1) {}
        Dim lpszReturnBuffer As IntPtr = Marshal.AllocCoTaskMem(CInt((nSize * 2)))
        Dim num2 As UInt32 = GetPrivateProfileSectionNames(lpszReturnBuffer, nSize, iniFile)
        If (num2 <> 0) Then
            strArray = Marshal.PtrToStringAuto(lpszReturnBuffer, CInt(num2)).ToString.Split(New Char(1 - 1) {}, StringSplitOptions.RemoveEmptyEntries)
        End If
        Marshal.FreeCoTaskMem(lpszReturnBuffer)
        Return strArray
    End Function

    Public Function INIGetStringValue(ByVal iniFile As String, ByVal section As String, ByVal key As String, ByVal defaultValue As String) As String
        Dim str As String = defaultValue
        If String.IsNullOrEmpty(section) Then
            Throw New ArgumentException("必须指定节点名称", "section")
        End If
        If String.IsNullOrEmpty(key) Then
            Throw New ArgumentException("必须指定键名称(key)", "key")
        End If
        Dim lpReturnedString As New StringBuilder(&H2800)
        If (GetPrivateProfileString(section, key, defaultValue, lpReturnedString, &H2800, iniFile) <> 0) Then
            str = lpReturnedString.ToString
        End If
        lpReturnedString = Nothing
        Return str
    End Function

    Public Function INIWriteItems(ByVal iniFile As String, ByVal section As String, ByVal items As String) As Boolean
        If String.IsNullOrEmpty(section) Then
            Throw New ArgumentException("必须指定节点名称", "section")
        End If
        If String.IsNullOrEmpty(items) Then
            Throw New ArgumentException("必须指定键值对", "items")
        End If
        Return WritePrivateProfileSection(section, items, iniFile)
    End Function

    Public Function INIWriteValue(ByVal iniFile As String, ByVal section As String, ByVal key As String, ByVal value As String) As Boolean
        If String.IsNullOrEmpty(section) Then
            Throw New ArgumentException("必须指定节点名称", "section")
        End If
        If String.IsNullOrEmpty(key) Then
            Throw New ArgumentException("必须指定键名称", "key")
        End If
        If (value Is Nothing) Then
            Throw New ArgumentException("值不能为null", "value")
        End If
        Return WritePrivateProfileString(section, key, value, iniFile)
    End Function

    <DllImport("kernel32.dll", CharSet:=CharSet.Auto)>
    Private Function WritePrivateProfileSection(ByVal lpAppName As String, ByVal lpString As String, ByVal lpFileName As String) As <MarshalAs(UnmanagedType.Bool)> Boolean
    End Function

    <DllImport("kernel32.dll", CharSet:=CharSet.Auto, SetLastError:=True)>
    Private Function WritePrivateProfileString(ByVal lpAppName As String, ByVal lpKeyName As String, ByVal lpString As String, ByVal lpFileName As String) As <MarshalAs(UnmanagedType.Bool)> Boolean
    End Function
End Module
