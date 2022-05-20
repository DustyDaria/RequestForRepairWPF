using RequestForRepairWPF.Data;
using RequestForRepairWPF.Infrastructure.Commands.Base;
using RequestForRepairWPF.Services;
using RequestForRepairWPF.ViewModels.DialogWindows;
using RequestForRepairWPF.Views.DialogWindows;
using RequestForRepairWPF.Views.Pages;
using RequestForRepairWPF.Views.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RequestForRepairWPF.Infrastructure.Commands
{
    /// <summary>
    /// Команда выхода из профиля (необходима доработка подтверждения)
    /// </summary>
    public class LogOut : Command
    {
        public override bool CanExecute(object parameter) => true;
        public override void Execute(object parameter) => AppRestart();

        private void AppRestart()
        {
            Dialog_ViewModel dialog_ViewModel = new Dialog_ViewModel("Вы уверены, что хотите выйти из своего профиля?");
            DialogConfirmation_View dialogConfirmation_View = new DialogConfirmation_View();
            dialogConfirmation_View.Show();
            
            // Необходимо уведомдение от ViewModel о замене значения свойства
            //if (dialog_ViewModel.UserConfirmation == true)
            //{
            //    System.Windows.Forms.Application.Restart();
            //    System.Windows.Application.Current.Shutdown();
            //}
        }
    }
}
