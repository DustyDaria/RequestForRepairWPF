using RequestForRepairWPF.ViewModels.Pages;
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
    abstract class MyCommand : ICommand
    {
        protected DescriptionRoom_ViewModel _descriptionRoom_ViewModel;

        public MyCommand(DescriptionRoom_ViewModel descriptionRoom_ViewModel)
        {
            _descriptionRoom_ViewModel = descriptionRoom_ViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public abstract bool CanExecute(object parameter);

        public abstract void Execute(object parameter);
    }
}
