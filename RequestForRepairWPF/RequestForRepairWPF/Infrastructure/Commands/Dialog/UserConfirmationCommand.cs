using RequestForRepairWPF.ViewModels.DialogWindows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestForRepairWPF.Infrastructure.Commands.Dialog
{
    /// <summary>
    /// Класс для команды "Подтверждение пользователя"
    /// </summary>
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
}
