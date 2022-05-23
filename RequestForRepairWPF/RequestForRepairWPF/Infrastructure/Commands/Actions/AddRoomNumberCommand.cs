using RequestForRepairWPF.ViewModels.Pages.UserAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestForRepairWPF.Infrastructure.Commands.Actions
{
    /// <summary>
    /// Класс-команда для добавления помещения при регистрации пользователя
    /// </summary>
    internal class AddRoomNumberCommand : MyRegCommand
    {

        public AddRoomNumberCommand(UserRegistrationData_ViewModel userRegData_ViewModel) : base(userRegData_ViewModel) { }
        public override bool CanExecute(object parameter) => true;
        public override void Execute(object parameter) => AddRoomsNumber();
        private void AddRoomsNumber()
        {
            //Rooms room = new Rooms();
            //room.room_number = _userRegData_ViewModel.UserRoomNumber;
            UserRegistrationData_ViewModel._chooseRoomsNum.Add(_userRegData_ViewModel.UserRoomNumber);
            //_chooseRoomsNum.Add(room.room_number);

            //_userRegData_ViewModel.ListChooseRooms.Add(_userRegData_ViewModel.UserRoomNumber);
            _userRegData_ViewModel.ListChooseRooms = UserRegistrationData_ViewModel._chooseRoomsNum;
            _userRegData_ViewModel.ListToString = Convert.ToString(_userRegData_ViewModel.ListChooseRooms);
        }
    }
}
