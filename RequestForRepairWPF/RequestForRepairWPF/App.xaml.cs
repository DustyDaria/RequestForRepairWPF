using RequestForRepairWPF.Services;
using RequestForRepairWPF.ViewModels.Controls.Menu;
using RequestForRepairWPF.Views.Controls.Menu;
using RequestForRepairWPF.Views.Windows;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace RequestForRepairWPF
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public DisplayRootRegistry displayRootRegistry = new DisplayRootRegistry();
        //UsersData_ViewModel usersData_ViewModel;

        public App()
        {
            //displayRootRegistry.RegisterWindowType<UsersData_ViewModel, Authorization_View>();
            //displayRootRegistry.RegisterUserControlType<Ctrl_burgerMenu_ViewModel, Ctrl_burgerMenu_View>();
            //displayRootRegistry.RegisterWindowType<UserAccount_ViewModel, UserAccount_View>();
            //displayRootRegistry.RegisterWindowType<CustomerUserAccount_ViewModel, CustomerUserAccount_View>();
        }

        //protected override async void OnStartup(StartupEventArgs e)
        //{
        //    base.OnStartup(e);
        //
        //    //usersData_ViewModel = new UsersData_ViewModel();
        //    
        //    //await displayRootRegistry.ShowModalPresentation(usersData_ViewModel);
        //    
        //    Shutdown();
        //}
    }
}
