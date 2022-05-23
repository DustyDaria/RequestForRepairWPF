using Caliburn.Micro;
using RequestForRepairWPF.Data.Request;
using RequestForRepairWPF.Models.Pages.ViewingEditDelete_Request;
using RequestForRepairWPF.ViewModels.DialogWindows;
using RequestForRepairWPF.ViewModels.Pages.Request;
using RequestForRepairWPF.Views.DialogWindows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestForRepairWPF.Infrastructure.Commands.Actions
{
    /// <summary>
    /// Класс-команда для поиска по полю
    /// </summary>
    internal class SearchMyCommand : MyRequestHelpCommand
    {
        AllRequest_Model _model = new AllRequest_Model();
        StringBuilder errors = new StringBuilder();

        public SearchMyCommand(MyRequest_ViewModel myRequest_ViewModel) : base(myRequest_ViewModel) { }
        public override bool CanExecute(object parameter) => true;
        public override void Execute(object parameter) => Search();

        private void Search()
        {
            if (string.IsNullOrEmpty(_myRequest_ViewModel.SelectedCriteriaSearch))
                errors.AppendLine("Для поиска необходимо выбрать критерий!");
            if (string.IsNullOrWhiteSpace(_myRequest_ViewModel.DataForSearch))
                errors.AppendLine("А по каким данным мы проводим поиск? :D");

            if (errors.Length > 0)
            {
                OpenDialogWindow(errors.ToString());
                errors.Clear();
                return;
            }
            else
            {
                Request_DataModel.AllRequestID.Clear();

                if (_myRequest_ViewModel.SelectedCriteriaSearch == _myRequest_ViewModel.ListCriteriaSearch[0])
                {
                    errors.AppendLine("К сожалению, поиск по данному критерию еще не настроен");
                }
                else if (_myRequest_ViewModel.SelectedCriteriaSearch == _myRequest_ViewModel.ListCriteriaSearch[1])
                {
                    errors.AppendLine("К сожалению, поиск по данному критерию еще не настроен");
                }
                else if (_myRequest_ViewModel.SelectedCriteriaSearch == _myRequest_ViewModel.ListCriteriaSearch[2])
                {
                    errors.AppendLine("К сожалению, поиск по данному критерию еще не настроен");
                }
                else if (_myRequest_ViewModel.SelectedCriteriaSearch == _myRequest_ViewModel.ListCriteriaSearch[3])
                {
                    _myRequest_ViewModel.MyRequest = new BindableCollection<Request_DataModel>
                        (_model.GetAllRequests(_model.AllIdRequests_SearchStatus_my(_myRequest_ViewModel.DataForSearch)));
                }
                else if (_myRequest_ViewModel.SelectedCriteriaSearch == _myRequest_ViewModel.ListCriteriaSearch[4])
                {
                    errors.AppendLine("К сожалению, поиск по данному критерию еще не настроен");
                }
                else if (_myRequest_ViewModel.SelectedCriteriaSearch == _myRequest_ViewModel.ListCriteriaSearch[5])
                {
                    _myRequest_ViewModel.MyRequest = new BindableCollection<Request_DataModel>
                        (_model.GetAllRequests(_model.AllIdRequests_SearchName_my(_myRequest_ViewModel.DataForSearch)));
                }
                else if (_myRequest_ViewModel.SelectedCriteriaSearch == _myRequest_ViewModel.ListCriteriaSearch[6])
                {
                    _myRequest_ViewModel.MyRequest = new BindableCollection<Request_DataModel>
                        (_model.GetAllRequests(_model.AllIdRequests_SearchDescription_my(_myRequest_ViewModel.DataForSearch)));
                }
                else if (_myRequest_ViewModel.SelectedCriteriaSearch == _myRequest_ViewModel.ListCriteriaSearch[7])
                {
                    _myRequest_ViewModel.MyRequest = new BindableCollection<Request_DataModel>
                        (_model.GetAllRequests(_model.AllIdRequests_SearchComment_my(_myRequest_ViewModel.DataForSearch)));
                }
                else if (_myRequest_ViewModel.SelectedCriteriaSearch == _myRequest_ViewModel.ListCriteriaSearch[8])
                {
                    _myRequest_ViewModel.MyRequest = new BindableCollection<Request_DataModel>
                        (_model.GetAllRequests(_model.AllIdRequests_SearchCategory_my(_myRequest_ViewModel.DataForSearch)));
                }
                else if (_myRequest_ViewModel.SelectedCriteriaSearch == _myRequest_ViewModel.ListCriteriaSearch[9])
                {
                    errors.AppendLine("К сожалению, поиск по данному критерию еще не настроен");
                }
                else if (_myRequest_ViewModel.SelectedCriteriaSearch == _myRequest_ViewModel.ListCriteriaSearch[10])
                {
                    errors.AppendLine("К сожалению, поиск по данному критерию еще не настроен");
                }



                if (_myRequest_ViewModel.MyRequest.Count == 0)
                    errors.AppendLine("К сожалению, совпадений не найдено :(");

                if (errors.Length > 0)
                {
                    OpenDialogWindow(errors.ToString());
                    errors.Clear();
                    return;
                }

            }
        }

        #region Открытие диалогового окна
        private void OpenDialogWindow(string textMessage)
        {
            Dialog_ViewModel messageBox_ViewModel = new Dialog_ViewModel(textMessage);
            MessageBox_View messageBox_View = new MessageBox_View();
            messageBox_View.Show();
        }
        #endregion
    }
}
