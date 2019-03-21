using DMSkin.Core.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Model
{
    /// <summary>
    /// 用户类
    /// </summary>
    public class User :ViewModelBase
    {
        private string userName;
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName
        {
            get { return userName; }
            set
            {
                userName = value;
                OnPropertyChanged(nameof(UserName));
            }
        }

        private string userPwd;
        /// <summary>
        /// 密码
        /// </summary>
        public string UserPwd
        {
            get { return userPwd; }
            set
            {
                userPwd = value;
                OnPropertyChanged(nameof(UserPwd));
            }
        }

        private bool vip;
        /// <summary>
        /// 是否VIP
        /// </summary>
        public bool Vip
        {
            get { return vip; }
            set
            {
                vip = value;
                OnPropertyChanged(nameof(Vip));
            }
        }
    }
}
