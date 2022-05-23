using RequestForRepairWPF.ViewModels.Pages.UserAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestForRepairWPF.Infrastructure.Commands.Actions
{
    /// <summary>
    /// Класс-команда для отмены регистрации пользователя
    /// </summary>
    internal class CancelUserRegCommand : MyRegCommand
    {
        public CancelUserRegCommand(UserRegistrationData_ViewModel userRegData_ViewModel) : base(userRegData_ViewModel) { }
        public override bool CanExecute(object parameter) => true;
        public override void Execute(object parameter) => CleanUsersData();

        private void CleanUsersData()
        {
            _userRegData_ViewModel.UserEmail = null;
            _userRegData_ViewModel.UserPassword = null;
            _userRegData_ViewModel.UserRepeatPassword = null;
            _userRegData_ViewModel.UserLastName = null;
            _userRegData_ViewModel.UserName = null;
            _userRegData_ViewModel.UserMiddleName = null;
            _userRegData_ViewModel.UserPosition = null;
            _userRegData_ViewModel.UserPhone = null;
            _userRegData_ViewModel.UserType = null;
            _userRegData_ViewModel.UserCategoryExecutors = null;
            _userRegData_ViewModel.UserRoomNumber = 0;

        }
    }
}
