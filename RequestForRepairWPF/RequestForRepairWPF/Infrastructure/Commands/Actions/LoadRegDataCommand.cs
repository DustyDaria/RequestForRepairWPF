using RequestForRepairWPF.ViewModels.Pages.UserAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestForRepairWPF.Infrastructure.Commands.Actions
{
    /// <summary>
    /// Класс-команда загрузки необходимых данных для регистрации
    /// </summary>
    internal class LoadRegDataCommand : MyRegCommand
    {
        public LoadRegDataCommand(UserRegistrationData_ViewModel userRegData_ViewModel) : base(userRegData_ViewModel) { }
        public override bool CanExecute(object parameter) => true;
        public override void Execute(object parameter) => LoadRegData();

        private void LoadRegData()
        {
            _userRegData_ViewModel.ListUsersType = Data.User.TypeOfAccount_DataModel.AllType;
            _userRegData_ViewModel.ListLibertyRoomsNumber = Data.Room.Rooms_DataModel.AllLibertyRoomsNumber;
            _userRegData_ViewModel.ListExecutorsType = Data.User.User_DataModel.AllCategoryExecutors;
        }
    }
}
