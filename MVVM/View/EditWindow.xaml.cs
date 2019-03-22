using MVVM.Model;
using MVVM.ViewModel;

namespace MVVM.View
{
    public partial class EditWindow
    {
        /// <summary>
        /// 构造 传参
        /// </summary>
        /// <param name="user"></param>
        public EditWindow(User user)
        {
            InitializeComponent();
            DataContext = new EditViewModel(user);
        }
    }
}
