using RequestForRepairWPF.Services;
using RequestForRepairWPF.ViewModels.Controls.Menu;
using RequestForRepairWPF.Views.Pages.ViewingEditDelete_UsersData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestForRepairWPF.Infrastructure.Commands.LoadView
{
    internal class OpenCustomersViewCommand : MyCommand
    {
        public OpenCustomersViewCommand(Ctrl_burgerMenu_ViewModel ctrl_Menu_ViewModel) : base(ctrl_Menu_ViewModel) { }
        public override bool CanExecute(object parameter) => true;
        public override void Execute(object parameter) => PageManager.MainFrame.Navigate(new CustomersPage_View());
    }
}
