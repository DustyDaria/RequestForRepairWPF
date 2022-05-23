using RequestForRepairWPF.ViewModels.Pages.UserAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestForRepairWPF.Infrastructure.Commands.Actions
{
    /// <summary>
    /// Класс-команда для удаления выбранных помещений
    /// </summary>
    internal class DeleteRoomsNumberCommand : MyRegCommand
    {
        public DeleteRoomsNumberCommand(UserRegistrationData_ViewModel userRegData_ViewModel) : base(userRegData_ViewModel) { }
        public override bool CanExecute(object parameter) => true;
        public override void Execute(object parameter) => _userRegData_ViewModel.ListChooseRooms.Clear();
    }
}
