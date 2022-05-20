using Caliburn.Micro;
using RequestForRepairWPF.Data.User;
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

    #region Класс-команда для поиска по полю
    internal class SearchCusCommand : MyCusCommand
    {

        AllUsers_Model _model = new AllUsers_Model();
        StringBuilder errors = new StringBuilder();

        public SearchCusCommand(Customers_ViewModel customers_ViewModel) : base(customers_ViewModel) { }
        public override bool CanExecute(object parameter) => true;
        public override void Execute(object parameter) => Search();

        private void Search()
        {
            if (string.IsNullOrEmpty(_customers_ViewModel.SelectedCriteriaSearch))
                errors.AppendLine("Для поиска необходимо выбрать критерий!");
            if (string.IsNullOrWhiteSpace(_customers_ViewModel.DataForSearch))
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
                if (_customers_ViewModel.SelectedCriteriaSearch == _customers_ViewModel.ListCriteriaSearch[0])
                {
                    _customers_ViewModel.AllCustomers = new BindableCollection<User_DataModel>
                        (_model.GetPeople_Customers(_model.AllIdUsers_SearchLogin_cus(_customers_ViewModel.DataForSearch)));

                }
                else if (_customers_ViewModel.SelectedCriteriaSearch == _customers_ViewModel.ListCriteriaSearch[1])
                {
                    _customers_ViewModel.AllCustomers = new BindableCollection<User_DataModel>
                        (_model.GetPeople_Customers(_model.AllIdUsers_SearchLastName_cus(_customers_ViewModel.DataForSearch)));
                }
                else if (_customers_ViewModel.SelectedCriteriaSearch == _customers_ViewModel.ListCriteriaSearch[2])
                {
                    _customers_ViewModel.AllCustomers = new BindableCollection<User_DataModel>
                        (_model.GetPeople_Customers(_model.AllIdUsers_SearchName_cus(_customers_ViewModel.DataForSearch)));
                }
                else if (_customers_ViewModel.SelectedCriteriaSearch == _customers_ViewModel.ListCriteriaSearch[3])
                {
                    _customers_ViewModel.AllCustomers = new BindableCollection<User_DataModel>
                        (_model.GetPeople_Customers(_model.AllIdUsers_SearchMiddleName_cus(_customers_ViewModel.DataForSearch)));
                }
                else if (_customers_ViewModel.SelectedCriteriaSearch == _customers_ViewModel.ListCriteriaSearch[4])
                {
                    _customers_ViewModel.AllCustomers = new BindableCollection<User_DataModel>
                        (_model.GetPeople_Customers(_model.AllIdUsers_SearchPosition_cus(_customers_ViewModel.DataForSearch)));
                }
                else if (_customers_ViewModel.SelectedCriteriaSearch == _customers_ViewModel.ListCriteriaSearch[5])
                {
                    _customers_ViewModel.AllCustomers = new BindableCollection<User_DataModel>
                        (_model.GetPeople_Customers(_model.AllIdUsers_SearchPhone_cus(_customers_ViewModel.DataForSearch)));
                }

                if (_customers_ViewModel.AllCustomers.Count == 0)
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
    internal class UpdateDataCusCommand : MyCusCommand
    {
        AllUsers_Model _model = new AllUsers_Model();

        public UpdateDataCusCommand(Customers_ViewModel customers_ViewModel) : base(customers_ViewModel) { }
        public override bool CanExecute(object parameter) => true;
        public override void Execute(object parameter) => UpdateData();

        private void UpdateData()
        {
            User_DataModel.AllUsersID.Clear();
            
            _customers_ViewModel.AllCustomers = new BindableCollection<User_DataModel>
                (_model.GetPeople_Customers(_model.AllIdUsers_Customers));

            _customers_ViewModel.SelectedCriteriaSearch = null;
            _customers_ViewModel.DataForSearch = null;

        }
    }
    #endregion

    #region Вспомогательный класс для команд
    abstract class MyCusCommand : ICommand
    {
        protected Customers_ViewModel _customers_ViewModel;
        public MyCusCommand(Customers_ViewModel customers_ViewModel)
        {
            _customers_ViewModel = customers_ViewModel;
        }
        public event EventHandler CanExecuteChanged;
        public abstract bool CanExecute(object parameter);
        public abstract void Execute(object parameter);
    }

    #endregion

}
