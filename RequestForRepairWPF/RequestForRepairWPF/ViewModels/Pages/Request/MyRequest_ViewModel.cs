using Caliburn.Micro;
using RequestForRepairWPF.Data.Request;
using RequestForRepairWPF.Models.Pages.ViewingEditDelete_Request;
using RequestForRepairWPF.ViewModels.Base;
using RequestForRepairWPF.ViewModels.DialogWindows;
using RequestForRepairWPF.Views.DialogWindows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RequestForRepairWPF.ViewModels.Pages.Request
{
    public class MyRequest_ViewModel : ViewModel
    {
        private BindableCollection<Request_DataModel> _myRequest;
        public BindableCollection<Request_DataModel> MyRequest
        {
            get => _myRequest;
            set => Set(ref _myRequest, value);
        }

        public MyRequest_ViewModel()
        {
            #region Загрузка данных
            Request_DataModel.AllRequestID.Clear();

            AllRequest_Model _model = new AllRequest_Model();
            MyRequest = new BindableCollection<Request_DataModel>(_model.GetAllMyRequests(_model.AllIdRequest_my));
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
            "Дата начала", "Дата окончания", "Реальная дата окончания",
            "Статус заявки", "Номер помещения", "Название заявки",
            "Описание заявки", "Комментарий к заявке", "Категория заявки",
            "Заказчик", "Исполнитель"};
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
        private ICommand _searchMyCommand;
        public ICommand SearchMyCommand
        {
            get
            {
                _searchMyCommand = new SearchMyCommand(this);
                return _searchMyCommand;

            }
        }
        #endregion

        #region Команда на обновление данных 
        private ICommand _updateDataMyCommand;
        public ICommand UpdateDataMyCommand
        {
            get
            {
                _updateDataMyCommand = new UpdateDataMyCommand(this);
                return _updateDataMyCommand;
            }
        }

        #endregion

        #endregion

    }

    #region Класс-команда для поиска по полю
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
    #endregion


    #region Класс-команда для обновления данных
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
    #endregion

    #region Вспомогательный класс для команд
    abstract class MyRequestHelpCommand : ICommand
    {
        protected MyRequest_ViewModel _myRequest_ViewModel;
        public MyRequestHelpCommand(MyRequest_ViewModel myRequest_ViewModel)
        {
            _myRequest_ViewModel = myRequest_ViewModel;
        }
        public event EventHandler CanExecuteChanged;
        public abstract bool CanExecute(object parameter);
        public abstract void Execute(object parameter);
    }

    #endregion

}
