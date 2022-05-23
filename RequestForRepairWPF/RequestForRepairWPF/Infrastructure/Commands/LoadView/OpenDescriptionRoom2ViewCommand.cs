using RequestForRepairWPF.Services;
using RequestForRepairWPF.ViewModels.Pages;
using RequestForRepairWPF.ViewModels.Pages.UserAccount;
using RequestForRepairWPF.Views.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestForRepairWPF.Infrastructure.Commands.LoadView
{
    /// <summary>
    /// Класс-команда для загрузки страницы "Описание помещения"
    /// </summary>
    internal class OpenDescriptionRoom2ViewCommand : MyHelpCommand
    {
        public OpenDescriptionRoom2ViewCommand(UsersData_ViewModel usersData_ViewModel) : base(usersData_ViewModel) { }
        public override bool CanExecute(object parameter) => true;
        public override void Execute(object parameter) => LoadPage();

        private void LoadPage()
        {
            DescriptionRoom_ViewModel descriptionRoom_ViewModel = new DescriptionRoom_ViewModel();
            descriptionRoom_ViewModel.RoomNumber = Convert.ToString(_usersData_ViewModel.UserRoomNumber);
            PageManager.MainFrame.Navigate(new DescriptionRoomPage_View());

        }
    }
}
