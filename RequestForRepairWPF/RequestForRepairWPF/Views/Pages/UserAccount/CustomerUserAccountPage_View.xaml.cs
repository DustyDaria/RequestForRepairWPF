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
    /// Логика взаимодействия для CustomerUserAccountPage_View.xaml
    /// </summary>
    public partial class CustomerUserAccountPage_View : Page
    {
        public CustomerUserAccountPage_View()
        {
            InitializeComponent();
        }

        private void btn_Edit_Click(object sender, RoutedEventArgs e)
        {
            this.btn_Edit.IsEnabled = !this.btn_Edit.IsEnabled;
        }
    }
}
