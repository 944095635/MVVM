using MVVM.Model;
using MVVM.ViewModel;

namespace MVVM.View
{
    public partial class EditWindow
    {
        public EditWindow(User user)
        {
            InitializeComponent();
            DataContext = new EditViewModel(user);
        }
    }
}
