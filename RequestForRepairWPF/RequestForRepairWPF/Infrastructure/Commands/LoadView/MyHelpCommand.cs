using RequestForRepairWPF.ViewModels.Pages.UserAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RequestForRepairWPF.Infrastructure.Commands.LoadView
{
    /// <summary>
    /// Вспомогательный класс для команд
    /// </summary>
    abstract class MyHelpCommand : ICommand
    {
        protected UsersData_ViewModel _usersData_ViewModel;

        public MyHelpCommand(UsersData_ViewModel usersData_ViewModel)
        {
            _usersData_ViewModel = usersData_ViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public abstract bool CanExecute(object parameter);

        public abstract void Execute(object parameter);
    }
}
