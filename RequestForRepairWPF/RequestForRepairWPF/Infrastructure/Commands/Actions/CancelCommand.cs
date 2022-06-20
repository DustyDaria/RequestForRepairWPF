using RequestForRepairWPF.Data.User;
using RequestForRepairWPF.Infrastructure.Commands.Basic;
using RequestForRepairWPF.Infrastructure.Commands.LoadView;
using RequestForRepairWPF.Services;
using RequestForRepairWPF.ViewModels.Pages.UserAccount;
using RequestForRepairWPF.Views.Pages.UserAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestForRepairWPF.Infrastructure.Commands.Actions
{
    /// <summary>
    /// Класс-команда отмены
    /// </summary>
    internal class CancelCommand : MyHelpCommand
    {
        public CancelCommand(UsersData_ViewModel usersData_ViewModel) : base(usersData_ViewModel) { }
        public override bool CanExecute(object parameter) => true;
        public override void Execute(object parameter) => Activity();

        private void Activity()
        {
            KeyActivity<UsersData_ViewModel> keyActivity = new KeyActivity<UsersData_ViewModel>(_usersData_ViewModel);
            keyActivity.CancelUserAccount();
        }
    }
}
