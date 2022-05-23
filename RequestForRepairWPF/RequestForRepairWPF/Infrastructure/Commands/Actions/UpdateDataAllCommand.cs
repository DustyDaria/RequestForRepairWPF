using Caliburn.Micro;
using RequestForRepairWPF.Data.Request;
using RequestForRepairWPF.Models.Pages.ViewingEditDelete_Request;
using RequestForRepairWPF.ViewModels.Pages.Request;
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
    internal class UpdateDataAllCommand : AllRequestHelpCommand
    {
        AllRequest_Model _model = new AllRequest_Model();

        public UpdateDataAllCommand(AllRequest2_ViewModel allRequest2_ViewModel) : base(allRequest2_ViewModel) { }
        public override bool CanExecute(object parameter) => true;
        public override void Execute(object parameter) => UpdateData();

        private void UpdateData()
        {
            Request_DataModel.AllRequestID.Clear();

            _allRequest2_ViewModel.AllRequest = new BindableCollection<Request_DataModel>
                (_model.GetAllRequests(_model.AllIdRequest_all));

            _allRequest2_ViewModel.SelectedCriteriaSearch = null;
            _allRequest2_ViewModel.DataForSearch = null;

        }
    }
}
