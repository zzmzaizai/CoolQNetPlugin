# CoolQNetPlugin
酷Q Air 非官方 .NET SDK，使用 VB 编写。该SDK可让插件开发人员使用托管代码库对酷Q Air 进行开发。

## SDK特性
* 允许使用.NET语言生成的插件DLL直接被酷Q读取，而不用执行其它操作。
* 简洁，容易使用

## 当前进度
- [x] 编写测试插件
- [ ] 编写完整的酷Q Air SDK

## 用法
*暂未编写*

## 测试截图
本SDK内附了一个示例插件，其名为*com.net.hotplug.test*。

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


## SDK使用的第三方DLL
* [DllExport](https://github.com/3F/DllExport)

## 其它.NET SDK
* [Flexlive](https://github.com/Flexlive/CQP)
* [C# SDK by moecraft](https://cqp.cc/t/24088)

## 版权协议
[MIT 协议](LICENSE)
