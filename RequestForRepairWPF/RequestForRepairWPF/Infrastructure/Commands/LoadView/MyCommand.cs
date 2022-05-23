using RequestForRepairWPF.ViewModels.Controls.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RequestForRepairWPF.Infrastructure.Commands.LoadView
{
    /// <summary>
    /// Вспомогательный класс
    /// </summary>
    abstract class MyCommand : ICommand
    {
        protected Ctrl_burgerMenu_ViewModel _ctrlMenu_ViewModel;

        public MyCommand(Ctrl_burgerMenu_ViewModel ctrlMenu_ViewModel)
        {
            _ctrlMenu_ViewModel = ctrlMenu_ViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public abstract bool CanExecute(object parameter);

        public abstract void Execute(object parameter);
    }
}
