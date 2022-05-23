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
    abstract class MyRequestHelpCommand : ICommand
    {
        protected MyRequest_ViewModel _myRequest_ViewModel;
        public MyRequestHelpCommand(MyRequest_ViewModel myRequest_ViewModel)
        {
            _myRequest_ViewModel = myRequest_ViewModel;
        }
        public event EventHandler CanExecuteChanged;
        public abstract bool CanExecute(object parameter);
        public abstract void Execute(object parameter);
    }
}
