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
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RequestForRepairWPF.ViewModels.Pages.ViewingEditDelete_UsersData
{
    class Executors_ViewModel : ViewModel
    {
        #region Коллекция данных для отображения
        private BindableCollection<User_DataModel> _allExecutors;
        public BindableCollection<User_DataModel> AllExecutors
        {
            get => _allExecutors;
            set => Set(ref _allExecutors, value);
        }
        #endregion

        public Executors_ViewModel()
        {
            #region Загрузка данных
            User_DataModel.AllUsersID.Clear();

            AllUsers_Model _model = new AllUsers_Model();
            AllExecutors = new BindableCollection<User_DataModel>(_model.GetPeople_Executors(_model.AllIdUsers_Executors));
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
            "Логин", "Категория исполнителя", "Фамилия", 
            "Имя", "Отчество", "Должность", "Телефон"};
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
        private ICommand _searchExeCommand;
        public ICommand SearchExeCommand
        {
            get
            {
                _searchExeCommand = new SearchExeCommand(this);
                return _searchExeCommand;
                
            }
        }
        #endregion

        #region Команда на обновление данных 
        private ICommand _updateDataExeCommand;
        public ICommand UpdateDataExeCommand
        {
            get
            {
                _updateDataExeCommand = new UpdateDataExeCommand(this);
                return _updateDataExeCommand;
            }
        }

        #endregion

        #endregion

    }

    #region Класс-команда для обновления данных
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
    #endregion

    #region Класс-команда для поиска по полю
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

            if(errors.Length > 0)
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
                else if(_executors_ViewModel.SelectedCriteriaSearch == _executors_ViewModel.ListCriteriaSearch[5])
                {
                    _executors_ViewModel.AllExecutors = new BindableCollection<User_DataModel>
                        (_model.GetPeople_Executors(_model.AllIdUsers_SearchPosition_exe(_executors_ViewModel.DataForSearch)));
                }
                else if(_executors_ViewModel.SelectedCriteriaSearch == _executors_ViewModel.ListCriteriaSearch[6])
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
    #endregion

    #region Вспомогательный класс для команд
    abstract class MyExeCommand : ICommand
    {
        protected Executors_ViewModel _executors_ViewModel;
        public MyExeCommand(Executors_ViewModel executors_ViewModel)
        {
            _executors_ViewModel = executors_ViewModel;
        }
        public event EventHandler CanExecuteChanged;
        public abstract bool CanExecute(object parameter);
        public abstract void Execute(object parameter);
    }

    #endregion
}
