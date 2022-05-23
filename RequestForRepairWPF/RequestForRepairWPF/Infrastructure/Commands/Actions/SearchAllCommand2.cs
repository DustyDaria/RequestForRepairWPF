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
    internal class SearchAllCommand2 : MyAllCommand
    {

        AllUsers_Model _model = new AllUsers_Model();
        StringBuilder errors = new StringBuilder();

        public SearchAllCommand2(AllUsers_ViewModel allUsers_ViewModel) : base(allUsers_ViewModel) { }
        public override bool CanExecute(object parameter) => true;
        public override void Execute(object parameter) => Search();

        private void Search()
        {
            if (string.IsNullOrEmpty(_allUsers_ViewModel.SelectedCriteriaSearch))
                errors.AppendLine("Для поиска необходимо выбрать критерий!");
            if (string.IsNullOrWhiteSpace(_allUsers_ViewModel.DataForSearch))
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
                if (_allUsers_ViewModel.SelectedCriteriaSearch == _allUsers_ViewModel.ListCriteriaSearch[0])
                {
                    _allUsers_ViewModel.AllUsers = new BindableCollection<User_DataModel>
                        (_model.GetPeople_All(_model.AllIdUsers_SearchLogin_all(_allUsers_ViewModel.DataForSearch)));

                }
                else if (_allUsers_ViewModel.SelectedCriteriaSearch == _allUsers_ViewModel.ListCriteriaSearch[1])
                {
                    _allUsers_ViewModel.AllUsers = new BindableCollection<User_DataModel>
                        (_model.GetPeople_All(_model.AllIdUsers_SearchTypeOfAccount_all(_allUsers_ViewModel.DataForSearch)));
                }
                else if (_allUsers_ViewModel.SelectedCriteriaSearch == _allUsers_ViewModel.ListCriteriaSearch[2])
                {
                    _allUsers_ViewModel.AllUsers = new BindableCollection<User_DataModel>
                        (_model.GetPeople_All(_model.AllIdUsers_SearchLastName_all(_allUsers_ViewModel.DataForSearch)));
                }
                else if (_allUsers_ViewModel.SelectedCriteriaSearch == _allUsers_ViewModel.ListCriteriaSearch[3])
                {
                    _allUsers_ViewModel.AllUsers = new BindableCollection<User_DataModel>
                        (_model.GetPeople_All(_model.AllIdUsers_SearchName_all(_allUsers_ViewModel.DataForSearch)));
                }
                else if (_allUsers_ViewModel.SelectedCriteriaSearch == _allUsers_ViewModel.ListCriteriaSearch[4])
                {
                    _allUsers_ViewModel.AllUsers = new BindableCollection<User_DataModel>
                        (_model.GetPeople_All(_model.AllIdUsers_SearchMiddleName_all(_allUsers_ViewModel.DataForSearch)));
                }
                else if (_allUsers_ViewModel.SelectedCriteriaSearch == _allUsers_ViewModel.ListCriteriaSearch[5])
                {
                    _allUsers_ViewModel.AllUsers = new BindableCollection<User_DataModel>
                        (_model.GetPeople_All(_model.AllIdUsers_SearchPosition_all(_allUsers_ViewModel.DataForSearch)));
                }
                else if (_allUsers_ViewModel.SelectedCriteriaSearch == _allUsers_ViewModel.ListCriteriaSearch[6])
                {
                    _allUsers_ViewModel.AllUsers = new BindableCollection<User_DataModel>
                        (_model.GetPeople_All(_model.AllIdUsers_SearchCategoryExecutors_all(_allUsers_ViewModel.DataForSearch)));
                }
                else if (_allUsers_ViewModel.SelectedCriteriaSearch == _allUsers_ViewModel.ListCriteriaSearch[7])
                {
                    _allUsers_ViewModel.AllUsers = new BindableCollection<User_DataModel>
                        (_model.GetPeople_All(_model.AllIdUsers_SearchPhone_all(_allUsers_ViewModel.DataForSearch)));
                }

                if (_allUsers_ViewModel.AllUsers.Count == 0)
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
