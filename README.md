# CoolQNetPlugin
酷Q Air 非官方 .NET SDK，使用 VB 编写。该SDK可让插件开发人员使用托管代码库对酷Q Air 进行开发。

## SDK特性
* 生成的DLL能被酷Q直接读取
* 简洁易用

## 当前进度
- [x] 编写测试插件
- [x] 编写完整的酷Q Air SDK
- [ ] 公测

## 用法
1. 下载[DllExport](https://github.com/3F/DllExport)，并把它放到一个容易找的地方
2. 使用Visual Studio 2012或更高版本打开SDK
3. 引用下载的DllExport
4. 开始编写插件代码

## 测试截图
本SDK内附了一个示例插件，其名为*com.net.hotplug.test*。下列测试代码并不存在于此示例插件当中。 

![插件信息测试](https://github.com/135ty/CoolQNetPlugin/blob/dev/CoolQNetPlugin/docs/Plugin_Test.png)

插件开启测试<br/>
```VisualBasic
    <DllExport("_eventEnable")>
    Public Shared Function Enabled() As Integer
        MsgBox("测试插件已开启")
        Return 0
    End Function
```

![插件开启测试](https://github.com/135ty/CoolQNetPlugin/blob/dev/CoolQNetPlugin/docs/Plugin_Test_1.png)

插件停用测试<br/>
```VisualBasic
    <DllExport("_eventDisable")>
    Public Shared Function Disabled() As Integer
        MsgBox("测试插件已关闭")
        Return 0
    End Function
```
![插件停用测试](https://github.com/135ty/CoolQNetPlugin/blob/dev/CoolQNetPlugin/docs/Plugin_Test_2.png)
## API信息
此SDK所提供的Api均位于<code>CoolQApi</code>里，可以在这个类里添加用户实现的方法或者是Api。调用酷Q的相关Api在 <code>CoolQApi.NativeMethods</code>类里。
## SDK使用的第三方DLL
* [DllExport](https://github.com/3F/DllExport)

## 其它.NET SDK
* [Flexlive](https://github.com/Flexlive/CQP)
* [C# SDK by moecraft](https://cqp.cc/t/24088)

## 版权协议
[MIT 协议](LICENSE)
