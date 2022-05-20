using RequestForRepairWPF.Infrastructure.Commands.Base;
using RequestForRepairWPF.ViewModels.Base;
using RequestForRepairWPF.Views.DialogWindows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace RequestForRepairWPF.ViewModels.DialogWindows
{
    public class Dialog_ViewModel : ViewModel
    {
        #region Конструкторы
        public Dialog_ViewModel(string text)
        {
            TextMessage = text;
        }

        public Dialog_ViewModel()
        {
        }
        #endregion

        #region Подтверждение пользователя
        private static bool _userConfirmation;
        public bool UserConfirmation
        {
            get => _userConfirmation;
            set => Set(ref _userConfirmation, value);
        }
        #endregion

        #region Сообщение для пользователя
        private static string _textMessage;
        public string TextMessage
        {
            get => _textMessage;
            set => Set(ref _textMessage, value);
        }
        #endregion

        #region Команды

        #region Команда подтверждения пользователя
        private ICommand _userConfirmation_Command;
        public ICommand UserConfirmation_Command
        {
            get
            {
                if(_userConfirmation_Command == null)
                {
                    _userConfirmation_Command = new UserConfirmationCommand(this);
                }
                return _userConfirmation_Command;
            }
        }
        #endregion

        #region Закрыть окно (при биндинге кнопка отключается)
        //public ICommand CloseApplicationCommand { get; }
        //
        //private bool CanCloseApplicationCommandExecute(object p) => true;
        //private void OnCloseApplicationCommandExecuted(object p)
        //{
        //    MessageBox_View messageBox_View = new MessageBox_View();
        //    messageBox_View.Close();
        //    this.Close();
        //}

        public bool CanClose { get; set; }

        private RelayCommand closeCommand;
        public ICommand CloseCommand
        {
            get
            {
                if (closeCommand == null)
                {
                    closeCommand = new RelayCommand(param => Close(), param => CanClose);
                }
                return closeCommand;
            }
        }

        public void Close()
        {
            this.Close();
        }

        #endregion

        #endregion
    }

    #region Класс для команды "Подтверждение пользователя
    internal class UserConfirmationCommand : MyCommand
    {
        public UserConfirmationCommand(Dialog_ViewModel dialog_ViewModel) : base(dialog_ViewModel) { }
        public override bool CanExecute(object parameter) => true;
        public override void Execute(object parameter) => UserConfirm();

        private void UserConfirm()
        {
            _dialog_ViewModel.UserConfirmation = true;

            System.Windows.Forms.Application.Restart();
            System.Windows.Application.Current.Shutdown();
        }
    }
    #endregion

    #region Вспомогательный класс для команд
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
    #endregion
}
