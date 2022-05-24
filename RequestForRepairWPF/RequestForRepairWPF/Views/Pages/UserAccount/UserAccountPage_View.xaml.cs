using RequestForRepairWPF.ViewModels.Pages.UserAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RequestForRepairWPF.Views.Pages.UserAccount
{
    /// <summary>
    /// Логика взаимодействия для UserAccountPage_View.xaml
    /// </summary>
    public partial class UserAccountPage_View : Page
    {
        UsersData_ViewModel _viewModel = new UsersData_ViewModel();

        public UserAccountPage_View()
        {
            InitializeComponent();

            if (_viewModel.UserType_string == "Исполнитель")
            {
                comboBox_category_executors.Visibility = Visibility.Visible;
            }
            else if (_viewModel.UserType_string == "Администратор")
            {
                comboBox_category_executors.Visibility = Visibility.Collapsed;
            }
        }

        private void btn_Edit_Click(object sender, RoutedEventArgs e)
        {
            this.btn_Edit.IsEnabled = !this.btn_Edit.IsEnabled;
        }

    }
}
