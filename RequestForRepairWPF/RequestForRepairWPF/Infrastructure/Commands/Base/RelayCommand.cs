using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RequestForRepairWPF.ViewModels.Base
{
    public class RelayCommand : ICommand
    {
        readonly Action _execute_with_param;
        readonly Action<object> _execute;
        readonly Predicate<object> _canExecute;

        public RelayCommand(Action<object> execute) : this(execute, null) { }
        public RelayCommand(Action execute) : this(execute, null) { }
        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");
            _execute = execute;
            _execute_with_param = null;
            _canExecute = canExecute;
        }
        public RelayCommand(Action execute, Predicate<object> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");
            _execute = null;
            _execute_with_param = execute;
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        // Если данная функция возвращает ложь, то команду выполнить нельзя
        // -> элемент, к кот. привязана команда, отключается автоматически
        public bool CanExecute(object parameter) { return _canExecute == null ? true : _canExecute(parameter); }
        
        // Данный метод реализует основную логику команды
        /*public void Execute(object parameter)
        {
            this.execute(parameter);
        }*/
        public void Execute(object parameter)
        {
            if (_execute != null)
                _execute.Invoke(parameter);
            else
                if (_execute_with_param != null)
                _execute_with_param.Invoke();
        }
    }
}
