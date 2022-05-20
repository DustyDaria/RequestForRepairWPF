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
    /// Логика взаимодействия для UserRegistrationPage_View.xaml
    /// </summary>
    public partial class UserRegistrationPage_View : Page
    {
        UserRegistrationData_ViewModel _viewModel = new UserRegistrationData_ViewModel();

        public UserRegistrationPage_View()
        {
            InitializeComponent();
        }

        private void comboBox_type_of_account_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(_viewModel.UserType == "Заказчик")
            {
                comboBox_room_number.Visibility = Visibility.Visible;
                grid_room_number.Visibility = Visibility.Visible;
                comboBox_category_executors.Visibility = Visibility.Collapsed;

            }
            else if(_viewModel.UserType == "Исполнитель")
            {
                comboBox_room_number.Visibility = Visibility.Collapsed;
                grid_room_number.Visibility = Visibility.Collapsed;
                comboBox_category_executors.Visibility = Visibility.Visible;
            }
            else if(_viewModel.UserType == "Системный администратор")
            {
                comboBox_room_number.Visibility = Visibility.Collapsed;
                grid_room_number.Visibility = Visibility.Collapsed;
                comboBox_category_executors.Visibility = Visibility.Collapsed;
            }
        }
    }
}
