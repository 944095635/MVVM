using MVVM.Common;
using MVVM.View;
using System.Windows;

namespace MVVM
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //注册跳转
            WindowHelper.ShowPageHome = () => 
            {
                frame.Navigate(new PageHome());
            };

            //跳转至登录页
            frame.Navigate(new PageLogin());
        }
    }
}
