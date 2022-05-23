using Caliburn.Micro;
using RequestForRepairWPF.Data.User;
using RequestForRepairWPF.Models.Pages.ViewingEditDelete_UsersData;
using RequestForRepairWPF.ViewModels.DialogWindows;
using RequestForRepairWPF.ViewModels.Pages.ViewingEditDelete_UsersData;
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
    internal class SearchExeCommand : MyExeCommand
    {

        AllUsers_Model _model = new AllUsers_Model();
        StringBuilder errors = new StringBuilder();

        public SearchExeCommand(Executors_ViewModel executors_ViewModel) : base(executors_ViewModel) { }
        public override bool CanExecute(object parameter) => true;
        public override void Execute(object parameter) => Search();

        private void Search()
        {
            if (string.IsNullOrEmpty(_executors_ViewModel.SelectedCriteriaSearch))
                errors.AppendLine("Для поиска необходимо выбрать критерий!");
            if (string.IsNullOrWhiteSpace(_executors_ViewModel.DataForSearch))
                errors.AppendLine("А по каким данным мы проводим поиск? :D");

            if (errors.Length > 0)
            {
                OpenDialogWindow(errors.ToString());
                errors.Clear();
                return;
            }
            else
            {
                User_DataModel.AllUsersID.Clear();
                if (_executors_ViewModel.SelectedCriteriaSearch == _executors_ViewModel.ListCriteriaSearch[0])
                {
                    _executors_ViewModel.AllExecutors = new BindableCollection<User_DataModel>
                        (_model.GetPeople_Executors(_model.AllIdUsers_SearchLogin_exe(_executors_ViewModel.DataForSearch)));

                }
                else if (_executors_ViewModel.SelectedCriteriaSearch == _executors_ViewModel.ListCriteriaSearch[1])
                {
                    _executors_ViewModel.AllExecutors = new BindableCollection<User_DataModel>
                        (_model.GetPeople_Executors(_model.AllIdUsers_SearchCategoryExecutors_exe(_executors_ViewModel.DataForSearch)));
                }
                else if (_executors_ViewModel.SelectedCriteriaSearch == _executors_ViewModel.ListCriteriaSearch[2])
                {
                    _executors_ViewModel.AllExecutors = new BindableCollection<User_DataModel>
                        (_model.GetPeople_Executors(_model.AllIdUsers_SearchLastName_exe(_executors_ViewModel.DataForSearch)));
                }
                else if (_executors_ViewModel.SelectedCriteriaSearch == _executors_ViewModel.ListCriteriaSearch[3])
                {
                    _executors_ViewModel.AllExecutors = new BindableCollection<User_DataModel>
                        (_model.GetPeople_Executors(_model.AllIdUsers_SearchName_exe(_executors_ViewModel.DataForSearch)));
                }
                else if (_executors_ViewModel.SelectedCriteriaSearch == _executors_ViewModel.ListCriteriaSearch[4])
                {
                    _executors_ViewModel.AllExecutors = new BindableCollection<User_DataModel>
                        (_model.GetPeople_Executors(_model.AllIdUsers_SearchMiddleName_exe(_executors_ViewModel.DataForSearch)));
                }
                else if (_executors_ViewModel.SelectedCriteriaSearch == _executors_ViewModel.ListCriteriaSearch[5])
                {
                    _executors_ViewModel.AllExecutors = new BindableCollection<User_DataModel>
                        (_model.GetPeople_Executors(_model.AllIdUsers_SearchPosition_exe(_executors_ViewModel.DataForSearch)));
                }
                else if (_executors_ViewModel.SelectedCriteriaSearch == _executors_ViewModel.ListCriteriaSearch[6])
                {
                    _executors_ViewModel.AllExecutors = new BindableCollection<User_DataModel>
                        (_model.GetPeople_Executors(_model.AllIdUsers_SearchPhone_exe(_executors_ViewModel.DataForSearch)));
                }

                if (_executors_ViewModel.AllExecutors.Count == 0)
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
