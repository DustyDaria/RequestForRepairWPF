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
    abstract class MyCusCommand : ICommand
    {
        protected Customers_ViewModel _customers_ViewModel;
        public MyCusCommand(Customers_ViewModel customers_ViewModel)
        {
            _customers_ViewModel = customers_ViewModel;
        }
        public event EventHandler CanExecuteChanged;
        public abstract bool CanExecute(object parameter);
        public abstract void Execute(object parameter);
    }
}
