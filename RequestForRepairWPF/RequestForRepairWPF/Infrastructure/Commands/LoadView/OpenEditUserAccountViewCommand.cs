using RequestForRepairWPF.Data.User;
using RequestForRepairWPF.Services;
using RequestForRepairWPF.ViewModels.Controls.Menu;
using RequestForRepairWPF.ViewModels.Pages.UserAccount;
using RequestForRepairWPF.Views.Pages.UserAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestForRepairWPF.Infrastructure.Commands.LoadView
{
    internal class OpenEditUserAccountViewCommand : MyCommand
    {
        UsersData_ViewModel _usersData_ViewModel = new UsersData_ViewModel();
        public OpenEditUserAccountViewCommand(Ctrl_burgerMenu_ViewModel ctrl_Menu_ViewModel) : base(ctrl_Menu_ViewModel) { }
        public override bool CanExecute(object parameter) => true;
        public override void Execute(object parameter)
        {
            if (User_DataModel._idType == 1)
            {
                UpdateData();

                PageManager.MainFrame.Navigate(new UserAccountPage_View());
            }
            else if (User_DataModel._idType == 2)
            {
                UpdateData();

                PageManager.MainFrame.Navigate(new CustomerUserAccountPage_View());
            }
            else if (User_DataModel._idType == 3)
            {
                UpdateData();

                PageManager.MainFrame.Navigate(new UserAccountPage_View());
            }
        }

        private void UpdateData()
        {
            _usersData_ViewModel.UserLastName = User_DataModel._lastName;
            _usersData_ViewModel.UserName = User_DataModel._name;
            _usersData_ViewModel.UserMiddleName = User_DataModel._middleName;
            _usersData_ViewModel.UserPosition = User_DataModel._position;
            _usersData_ViewModel.UserPhone = User_DataModel._phone;
        }
    }
}
