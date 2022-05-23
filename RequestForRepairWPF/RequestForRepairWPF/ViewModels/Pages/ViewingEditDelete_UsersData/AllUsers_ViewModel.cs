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
                _searchAllCommand = new SearchAllCommand2(this);
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
                _updateDataAllCommand = new UpdateDataAllCommand2(this);
                return _updateDataAllCommand;
            }
        }

        #endregion

        #endregion
    }
}
