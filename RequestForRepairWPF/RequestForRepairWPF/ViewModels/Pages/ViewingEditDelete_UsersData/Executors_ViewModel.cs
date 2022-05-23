using Caliburn.Micro;
using RequestForRepairWPF.Data;
using RequestForRepairWPF.Data.User;
using RequestForRepairWPF.Infrastructure.Commands.Actions;
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
}
