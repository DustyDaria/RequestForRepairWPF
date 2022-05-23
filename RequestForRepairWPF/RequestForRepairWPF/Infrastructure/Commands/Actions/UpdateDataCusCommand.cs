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
    internal class UpdateDataCusCommand : MyCusCommand
    {
        AllUsers_Model _model = new AllUsers_Model();

        public UpdateDataCusCommand(Customers_ViewModel customers_ViewModel) : base(customers_ViewModel) { }
        public override bool CanExecute(object parameter) => true;
        public override void Execute(object parameter) => UpdateData();

        private void UpdateData()
        {
            User_DataModel.AllUsersID.Clear();

            _customers_ViewModel.AllCustomers = new BindableCollection<User_DataModel>
                (_model.GetPeople_Customers(_model.AllIdUsers_Customers));

            _customers_ViewModel.SelectedCriteriaSearch = null;
            _customers_ViewModel.DataForSearch = null;

        }
    }
}
