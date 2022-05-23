using RequestForRepairWPF.ViewModels.Pages.ViewingEditDelete_UsersData;
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
    abstract class MyAllCommand : ICommand
    {
        protected AllUsers_ViewModel _allUsers_ViewModel;
        public MyAllCommand(AllUsers_ViewModel allUsers_ViewModel)
        {
            _allUsers_ViewModel = allUsers_ViewModel;
        }
        public event EventHandler CanExecuteChanged;
        public abstract bool CanExecute(object parameter);
        public abstract void Execute(object parameter);
    }
}
