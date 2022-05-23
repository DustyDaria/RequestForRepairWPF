using Caliburn.Micro;
using RequestForRepairWPF.Data.User;
using RequestForRepairWPF.Infrastructure.Commands.Actions;
using RequestForRepairWPF.Models.Pages.ViewingEditDelete_UsersData;
using RequestForRepairWPF.ViewModels.Base;
using RequestForRepairWPF.ViewModels.DialogWindows;
using RequestForRepairWPF.Views.DialogWindows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RequestForRepairWPF.ViewModels.Pages.ViewingEditDelete_UsersData
{
    public class Customers_ViewModel : ViewModel
    {
        private BindableCollection<User_DataModel> _allCustomers;
        public BindableCollection<User_DataModel> AllCustomers
        {
            get => _allCustomers;
            set => Set(ref _allCustomers, value);
        }

        public Customers_ViewModel()
        {
            #region Загрузка данных
            User_DataModel.AllUsersID.Clear();

            AllUsers_Model _model = new AllUsers_Model();
            AllCustomers = new BindableCollection<User_DataModel>(_model.GetPeople_Customers(_model.AllIdUsers_Customers));
            #endregion
        }

        //#region Выбранная из списка заявка
        //private string _selectedRequest;
        //public string SelectedRequest
        //{
        //    get => _selectedRequest;
        //    set => Set(ref _selectedRequest, value);
        //}
        //#endregion

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
            "Логин", "Фамилия", "Имя", 
            "Отчество", "Должность", "Телефон"};
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
        private ICommand _searchCusCommand;
        public ICommand SearchCusCommand
        {
            get
            {
                _searchCusCommand = new SearchCusCommand(this);
                return _searchCusCommand;

            }
        }
        #endregion
        #region Команда на обновление данных 
        private ICommand _updateDataCusCommand;
        public ICommand UpdateDataCusCommand
        {
            get
            {
                _updateDataCusCommand = new UpdateDataCusCommand(this);
                return _updateDataCusCommand;
            }
        }

        #endregion

        #endregion
    }
}
