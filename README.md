# MVVM

## 如果你想使用完善的第三方mvvm库 mvvm light ，请看另外的一个库：
## https://github.com/944095635/Intro.Wpf

## 当前的库属于简化版本，适合不喜欢使用太多第三方dll的人使用或学习MVVM的基础结构


#### MVVM （Model-View-ViewModel的简写）我的理解就是对UI和代码进行弱绑定。
# Ⅰ 强烈建议使用MVVM结构来开发WPF，在单人多人开发中都是非常好的选择
#### 相对于传统的View+Click模式，MVVM优点足够多，缺点几乎没有。初期学习成本稍微高一些，熟练之后某些地方比传统winform模式开发速度更快。
#### 可以从百度搜到一大堆的解释

#### 本项目中一些类的解释

| 类名                | 描述   |重要   |
| :----:              | :---:          | :---:          |
| ViewModelBase  |  ViewModel基类,想要支持刷新通知必须实现INotifyPropertyChanged,集合和单属性都需要触发OnPropertyChanged |⭐⭐⭐⭐⭐|
| Execute  |  UI调度器,可以在多线程中访问委托UI线程执行某些操作       |⭐⭐⭐⭐|
| WindowHelper  | 窗口跳转关闭等等 |⭐⭐⭐|
| DelegateCommand  |  命令接口实现       |⭐⭐|
| Auth | 用户认证,可以在登录的时候记录认证信息    |⭐|



# Ⅱ 项目中一般会使用到VS的智能提示(双tab代码段),我在项目中提供了2个代码段（请参考）。
#### VS->工具->代码片段管理器->语言（Csharp）->Visual C#
#### 我的VS安装在C盘路径是:
````xml
C:\Program Files (x86)\Microsoft Visual Studio\2017\Professional\VC#\Snippets\2052\Visual C#
````

| 简写                | 描述   |使用率   |
| :----:              | :---:          | :---:          |
| propfull  |  刷新属性       |⭐⭐⭐|
| command   | 命令        |⭐⭐|
| propdp    | 依赖属性    |⭐|

````csharp
/// <summary>
/// 命令 command
/// </summary>    
public ICommand Command => new DelegateCommand(obj =>
{

});


private int name;
/// <summary>
/// 刷新属性 propfull
/// </summary>
public int Name
{
   get { return name; }
   set
       {
         name = value;
         OnPropertyChanged(nameof(Name));
       }
}
````


# Ⅲ MVVM的特点&优点：
### 1.分离开发?UI和业务代码分离,擅长UI的程序员可以单独编写UI,擅长业务的编写业务
####  View指的是XAML布局文件,
####  ViewModel相当于原本的xxx.cs文件
####  Binding相当于 xxx.Text = "xxx"
####  Command相当于Click
####  当你修改XAML的时候根本不会影响到ViewModel中的代码和逻辑。
####  当你修改ViewModel.cs的时候也不会因为xxx_Click 而去修改XAML中的控件而心烦
  
### 2.模块化?
#### 

### 3.后期升级维护方便?

### 4.代码可读性高?
#### 使用Command 和 Binding 之后 代码可读性高



# ⅣMVVM的缺点&不足：
## 1.事件机制不合理
#### Listbox滚动到底?拖拽文件事件?（非常不推荐使用,因为很少有项目需要用到事件。）

````xml
Nuget中 安装System.Windows.Interactivity (具体使用方式可以百度)
xmlns:i="clr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity"
 
<i:Interaction.Triggers>
    <i:EventTrigger EventName="GotFocus">
         <i:InvokeCommandAction Command="{Binding Command}" />
    </i:EventTrigger>
</i:Interaction.Triggers>
````

````xml
你还可以使用DMSkin里面的Broadcast,这是一个事件通知器，可以传递数据。
````


## 2.窗口控制不方便
#### 当你想从某个窗口跳转至某个窗口 或者 关闭当前窗口的时候,
#### 参考项目中 WindowHelper 用来执行窗口跳转。
#### 关闭窗口可以考虑在WindowHelper中注册或者使用下面的代码
````xml
Command="{Binding CloseCommand}"
CommandParameter="{Binding RelativeSource={RelativeSource Mode=FindAncestor, AncestorType=Window}}"
````
````csharp
/// <summary>
/// 关闭窗口
/// </summary>    
public ICommand CloseCommand => new DelegateCommand(obj =>
{
    if (obj is Window window)
    {
        window.Close();
     }
});
````

````xml
你还可以使用DMSkin里面的Broadcast,这是一个事件通知器，可以传递数据。
````

## 3.窗口传参
#### A方案：构造函数传参，请参考代码中的传参方式
#### B方案：参考项目中Auth类使用静态类传递参数（适合全局需要使用的参数，比如登录的用户信息）
#### C方案：DMSkin中的Storage，这是一个数据存储器，可以保存全局的数据，在任何页面都可以读取到

##
##

C# .NET (2000人) QQ交流群 76566523

DMSkin QQ交流群: 194684812

WPF 课程学习群 (收费): 611509631
