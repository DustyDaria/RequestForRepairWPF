using RequestForRepairWPF.ViewModels.Pages.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestForRepairWPF.Infrastructure.Commands.Actions
{
    /// <summary>
    /// Класс-команда для загрузки данных
    /// </summary>
    internal class LoadRequestDataCommand : MyRequestCommand
    {
        public LoadRequestDataCommand(CreateRequest_ViewModel createRequest_ViewModel) : base(createRequest_ViewModel) { }
        public override bool CanExecute(object parameter) => true;
        public override void Execute(object parameter) => LoadRequestData();
        private void LoadRequestData()
        {
            _createRequest_ViewModel.ListCategoryRequest = Data.User.User_DataModel.AllCategoryExecutors;
            _createRequest_ViewModel.ListRoomsNumber = Data.Room.U_R_Room_DataModel._listUserRoomsNumber;
        }
    }
}
