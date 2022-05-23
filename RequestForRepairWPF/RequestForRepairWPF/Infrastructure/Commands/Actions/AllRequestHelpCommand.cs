using RequestForRepairWPF.ViewModels.Pages.Request;
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
    abstract class AllRequestHelpCommand : ICommand
    {
        protected AllRequest2_ViewModel _allRequest2_ViewModel;
        public AllRequestHelpCommand(AllRequest2_ViewModel allRequest2_ViewModel)
        {
            _allRequest2_ViewModel = allRequest2_ViewModel;
        }
        public event EventHandler CanExecuteChanged;
        public abstract bool CanExecute(object parameter);
        public abstract void Execute(object parameter);
    }
}
