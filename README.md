# MVVM


#### MVVM （Model-View-ViewModel的简写）我的理解就是对UI和代码进行弱绑定。
## 强烈建议使用MVVM结构来开发WPF，在单人多人开发中都是非常好的选择
#### 相对于传统的View+Click模式，MVVM优点足够多，缺点几乎没有。初期学习成本稍微高一些，熟练之后某些地方比传统winform模式开发速度更快。
#### 可以从百度搜到一大堆的解释

#### 本项目中一些类的解释

| 类名                | 描述   |重要   |
| :----:              | :---:          | :---:          |
| Execute  |  UI调度器,可以在多线程中访问委托UI线程执行某些操作       |⭐⭐⭐⭐⭐|
| ViewModelBase  |  ViewModel基类,想要支持刷新通知必须实现INotifyPropertyChanged,集合和单属性都需要触发OnPropertyChanged |⭐⭐⭐⭐|
| WindowHelper  | 窗口跳转关闭等等 |⭐⭐⭐|
| DelegateCommand  |  命令接口实现       |⭐⭐|
| Auth | 用户认证,可以在登录的时候记录认证信息    |⭐|

## 项目中一般会使用到VS的智能提示(双tab代码段),我在项目中提供了2个代码段（请参考）。
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



# MVVM的特点&优点：
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

#### 



# MVVM的缺点&不足：
## 1.事件机制不合理
#### Listbox滚动到底?拖拽文件事件?（非常不推荐使用,因为很少有项目需要用到事件。）

````xml
Nuget中 安装System.Windows.Interactivity
xmlns:i="clr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity"

/// <summary>
/// 关闭窗口
/// </summary>    
 <i:Interaction.Triggers>
        <i:EventTrigger EventName="GotFocus">
            <i:InvokeCommandAction Command="{Binding Command}" />
        </i:EventTrigger>
    </i:Interaction.Triggers>
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
