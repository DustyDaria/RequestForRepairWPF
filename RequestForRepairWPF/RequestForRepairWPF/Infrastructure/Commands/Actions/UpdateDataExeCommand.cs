using Caliburn.Micro;
using RequestForRepairWPF.Data.User;
using RequestForRepairWPF.Models.Pages.ViewingEditDelete_UsersData;
using RequestForRepairWPF.ViewModels.Pages.ViewingEditDelete_UsersData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestForRepairWPF.Infrastructure.Commands.Actions
{
    /// <summary>
    /// Класс-команда для обновления данных
    /// </summary>
    internal class UpdateDataExeCommand : MyExeCommand
    {
        AllUsers_Model _model = new AllUsers_Model();

        public UpdateDataExeCommand(Executors_ViewModel executors_ViewModel) : base(executors_ViewModel) { }
        public override bool CanExecute(object parameter) => true;
        public override void Execute(object parameter) => UpdateData();

        private void UpdateData()
        {
            User_DataModel.AllUsersID.Clear();
            _executors_ViewModel.AllExecutors = new BindableCollection<User_DataModel>(_model.GetPeople_Executors(_model.AllIdUsers_Executors));

            _executors_ViewModel.SelectedCriteriaSearch = null;
            _executors_ViewModel.DataForSearch = null;

        }
    }
}
