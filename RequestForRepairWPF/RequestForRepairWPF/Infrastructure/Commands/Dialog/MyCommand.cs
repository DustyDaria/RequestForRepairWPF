using RequestForRepairWPF.ViewModels.DialogWindows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RequestForRepairWPF.Infrastructure.Commands.Dialog
{
    /// <summary>
    /// Вспомогательный класс для команд
    /// </summary>
    abstract class MyCommand : ICommand
    {
        protected Dialog_ViewModel _dialog_ViewModel;

        public MyCommand(Dialog_ViewModel dialog_ViewModel)
        {
            _dialog_ViewModel = dialog_ViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public abstract bool CanExecute(object parameter);

        public abstract void Execute(object parameter);
    }
}
