using DMSkin.Core.Common;
using System.Windows;

namespace MVVM
{
    public partial class App : Application
    {
        /// <summary>
        /// 重启启动函数
        /// </summary>
        protected override void OnStartup(StartupEventArgs e)
        {
            //初始化UI调度器
            Execute.InitializeWithDispatcher();

            base.OnStartup(e);
        }
    }
}
