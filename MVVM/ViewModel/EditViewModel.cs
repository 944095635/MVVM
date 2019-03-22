using DMSkin.Core.MVVM;
using MVVM.Model;

namespace MVVM.ViewModel
{
    /// <summary>
    /// 编辑用户
    /// </summary>
    public class EditViewModel:ViewModelBase
    {
        #region 初始化
        public EditViewModel(User user)
        {
            User = user;
        }
        #endregion

        #region 属性
        private User user;
        /// <summary>
        /// 编辑用户
        /// </summary>
        public User User
        {
            get { return user; }
            set
            {
                user = value;
                OnPropertyChanged(nameof(User));
            }
        }
        #endregion
    }
}
