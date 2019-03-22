using DMSkin.Core.Common;
using DMSkin.Core.MVVM;
using MVVM.Model;
using MVVM.View;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVM.ViewModel
{
    public class HomeViewModel : ViewModelBase
    {
        #region 初始化
        private readonly CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        public HomeViewModel()
        {
            //初始化数据 - 请不要这里做太多任务，如果有需要可以使用Task
            Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    if (cancellationTokenSource.IsCancellationRequested)
                    {
                        break;
                    }

                    Thread.Sleep(1000);

                    //虽然UI绑定了这个元素 但是不需要 使用UI调度器。
                    Progress = i;

                    //并不是所有对数据操作都需要UI调度器,只有UI创建了视图对象的时候才需要
                    //这里的DataGrid 根据Users创建了视图列表，所以资源属于UI层。
                    Execute.OnUIThread(()=> 
                    {
                        Users.Add(new User() { UserName = $"用户{i}", Vip = true });
                    });
                }
            });
        }
        #endregion

        #region 属性
        private double progress;
        /// <summary>
        /// 进度
        /// </summary>
        public double Progress
        {
            get { return progress; }
            set
            {
                progress = value;
                OnPropertyChanged(nameof(Progress));
            }
        }

        private ObservableCollection<User> users;
        /// <summary>
        /// 用户列表
        /// </summary>
        public ObservableCollection<User> Users
        {
            get
            {
                if (users == null)
                {
                    users = new ObservableCollection<User>();
                }
                return users;
            }
            set
            {
                Users = value;
                OnPropertyChanged(nameof(Users));
            }
        }

        #endregion

        #region 命令

        /// <summary>
        /// 停止
        /// </summary>    
        public ICommand StopCommand => new DelegateCommand(obj =>
        {
            cancellationTokenSource.Cancel();
        });


        /// <summary>
        /// 编辑用户
        /// </summary>    
        public ICommand EditCommand => new DelegateCommand(obj =>
        {
            if (obj is User user)
            {
                EditWindow editWindow = new EditWindow(user);
                editWindow.ShowDialog();
            }
        });

        #endregion
    }
}
