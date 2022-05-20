using Caliburn.Micro;
using RequestForRepairWPF.Data;
using RequestForRepairWPF.Data.User;
using RequestForRepairWPF.Models;
using RequestForRepairWPF.Models.Pages;
using RequestForRepairWPF.Models.Pages.ViewingEditDelete_UsersData;
using RequestForRepairWPF.ViewModels.Base;
using RequestForRepairWPF.ViewModels.DialogWindows;
using RequestForRepairWPF.Views.DialogWindows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RequestForRepairWPF.ViewModels.Pages.ViewingEditDelete_UsersData
{
    public class AllUsers_ViewModel : ViewModel
    {
        private BindableCollection<User_DataModel> _allUsers;
        public BindableCollection<User_DataModel> AllUsers
        {
            get => _allUsers;
            set => Set(ref _allUsers, value);
        }

        public AllUsers_ViewModel()
        {
            /// <summary>Загрузка данных</summary>
            #region Загрузка данных
            /// <summary>Загрузка данных</summary>
            User_DataModel.AllUsersID.Clear();

            AllUsers_Model _model = new AllUsers_Model();
            AllUsers = new BindableCollection<User_DataModel>(_model.GetPeople_All(_model.AllIdUsers_All));
            #endregion
        }

        #region Выбранный критерий поиска
        private string _selectedCriteriaSearch;
        public string SelectedCriteriaSearch
        {
            get => _selectedCriteriaSearch;
            set => Set(ref _selectedCriteriaSearch, value);
        }
        #endregion

        #region Список ритериев поиска
        private string[] _listCriteriaSearch = new string[] {
            "Логин", "Тип аккаунта", "Фамилия",
            "Имя", "Отчество", "Должность", 
            "Категория исполнителя", "Телефон"};
        public string[] ListCriteriaSearch
        {
            get => _listCriteriaSearch;
        }
        #endregion

        #region Данные для поиска
        private string _dataForSearch;
        public string DataForSearch
        {
            get => _dataForSearch;
            set => Set(ref _dataForSearch, value);
        }
        #endregion

        #region Команды 
        #region Команда на поиск по полю
        private ICommand _searchAllCommand;
        public ICommand SearchAllCommand
        {
            get
            {
                _searchAllCommand = new SearchAllCommand(this);
                return _searchAllCommand;

            }
        }
        #endregion

        #region Команда на обновление данных 
        private ICommand _updateDataAllCommand;
        public ICommand UpdateDataAllCommand
        {
            get
            {
                _updateDataAllCommand = new UpdateDataAllCommand(this);
                return _updateDataAllCommand;
            }
        }

        #endregion

        #endregion
    }

    #region Класс-команда для поиска по полю
    internal class SearchAllCommand : MyAllCommand
    {

        AllUsers_Model _model = new AllUsers_Model();
        StringBuilder errors = new StringBuilder();

        public SearchAllCommand(AllUsers_ViewModel allUsers_ViewModel) : base(allUsers_ViewModel) { }
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
    #endregion

    #region Класс-команда для обновления данных
    internal class UpdateDataAllCommand : MyAllCommand
    {
        AllUsers_Model _model = new AllUsers_Model();

        public UpdateDataAllCommand(AllUsers_ViewModel allUsers_ViewModel) : base(allUsers_ViewModel) { }
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
    #endregion

    #region Вспомогательный класс для команд
    abstract class MyAllCommand : ICommand
    {
        protected AllUsers_ViewModel _allUsers_ViewModel;
        public MyAllCommand(AllUsers_ViewModel allUsers_ViewModel)
        {
            _allUsers_ViewModel = allUsers_ViewModel;
        }
        public event EventHandler CanExecuteChanged;
        public abstract bool CanExecute(object parameter);
        public abstract void Execute(object parameter);
    }

    #endregion
}
