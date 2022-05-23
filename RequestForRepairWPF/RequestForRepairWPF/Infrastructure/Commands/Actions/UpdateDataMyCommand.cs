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
    internal class UpdateDataMyCommand : MyRequestHelpCommand
    {
        AllRequest_Model _model = new AllRequest_Model();

        public UpdateDataMyCommand(MyRequest_ViewModel myRequest_ViewModel) : base(myRequest_ViewModel) { }
        public override bool CanExecute(object parameter) => true;
        public override void Execute(object parameter) => UpdateData();

        private void UpdateData()
        {
            Request_DataModel.AllRequestID.Clear();

            _myRequest_ViewModel.MyRequest = new BindableCollection<Request_DataModel>
                (_model.GetAllMyRequests(_model.AllIdRequest_my));

            _myRequest_ViewModel.SelectedCriteriaSearch = null;
            _myRequest_ViewModel.DataForSearch = null;

        }
    }
}
