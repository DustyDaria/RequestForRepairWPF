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
    abstract class MyRequestCommand : ICommand
    {
        protected CreateRequest_ViewModel _createRequest_ViewModel;
        public MyRequestCommand(CreateRequest_ViewModel createRequest_ViewModel)
        {
            _createRequest_ViewModel = createRequest_ViewModel;
        }
        public event EventHandler CanExecuteChanged;
        public abstract bool CanExecute(object parameter);
        public abstract void Execute(object parameter);
    }
}
