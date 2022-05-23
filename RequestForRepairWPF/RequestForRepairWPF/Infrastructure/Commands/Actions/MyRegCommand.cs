using RequestForRepairWPF.ViewModels.Pages.UserAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RequestForRepairWPF.Infrastructure.Commands.Actions
{
    /// <summary>
    /// Вспомогательный класс для команд
    /// </summary>
    abstract class MyRegCommand : ICommand
    {
        protected UserRegistrationData_ViewModel _userRegData_ViewModel;
        public MyRegCommand(UserRegistrationData_ViewModel userRegData_ViewModel)
        {
            _userRegData_ViewModel = userRegData_ViewModel;
        }
        public event EventHandler CanExecuteChanged;
        public abstract bool CanExecute(object parameter);
        public abstract void Execute(object parameter);
    }
}
