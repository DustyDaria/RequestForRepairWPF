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
    internal class UpdateDataAllCommand2 : MyAllCommand
    {
        AllUsers_Model _model = new AllUsers_Model();

        public UpdateDataAllCommand2(AllUsers_ViewModel allUsers_ViewModel) : base(allUsers_ViewModel) { }
        public override bool CanExecute(object parameter) => true;
        public override void Execute(object parameter) => UpdateData();

        private void UpdateData()
        {
            User_DataModel.AllUsersID.Clear();
            _allUsers_ViewModel.AllUsers = new BindableCollection<User_DataModel>
                (_model.GetPeople_All(_model.AllIdUsers_All));

            _allUsers_ViewModel.SelectedCriteriaSearch = null;
            _allUsers_ViewModel.DataForSearch = null;

        }
    }
}
