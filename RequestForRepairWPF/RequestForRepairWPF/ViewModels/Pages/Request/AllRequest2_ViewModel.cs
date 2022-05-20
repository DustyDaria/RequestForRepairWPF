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
    public class AllRequest2_ViewModel : ViewModel
    {
        private BindableCollection<Request_DataModel> _allRequest;
        public BindableCollection<Request_DataModel> AllRequest
        {
            get => _allRequest;
            set => Set(ref _allRequest, value);
        }

        public AllRequest2_ViewModel()
        {
            #region Загрузка данных
            Request_DataModel.AllRequestID.Clear();

            AllRequest_Model _model = new AllRequest_Model();
            AllRequest = new BindableCollection<Request_DataModel>(_model.GetAllRequests(_model.AllIdRequest_all));
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
    internal class SearchAllCommand : AllRequestHelpCommand
    {

        AllRequest_Model _model = new AllRequest_Model();
        StringBuilder errors = new StringBuilder();

        public SearchAllCommand(AllRequest2_ViewModel allRequest2_ViewModel) : base(allRequest2_ViewModel) { }
        public override bool CanExecute(object parameter) => true;
        public override void Execute(object parameter) => Search();

        private void Search()
        {
            if (string.IsNullOrEmpty(_allRequest2_ViewModel.SelectedCriteriaSearch))
                errors.AppendLine("Для поиска необходимо выбрать критерий!");
            if (string.IsNullOrWhiteSpace(_allRequest2_ViewModel.DataForSearch))
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

                if(_allRequest2_ViewModel.SelectedCriteriaSearch == _allRequest2_ViewModel.ListCriteriaSearch[0])
                {
                    errors.AppendLine("К сожалению, поиск по данному критерию еще не настроен");
                }
                else if(_allRequest2_ViewModel.SelectedCriteriaSearch == _allRequest2_ViewModel.ListCriteriaSearch[1])
                {
                    errors.AppendLine("К сожалению, поиск по данному критерию еще не настроен");
                }
                else if (_allRequest2_ViewModel.SelectedCriteriaSearch == _allRequest2_ViewModel.ListCriteriaSearch[2])
                {
                    errors.AppendLine("К сожалению, поиск по данному критерию еще не настроен");
                }
                else if (_allRequest2_ViewModel.SelectedCriteriaSearch == _allRequest2_ViewModel.ListCriteriaSearch[3])
                {
                    _allRequest2_ViewModel.AllRequest = new BindableCollection<Request_DataModel>
                        (_model.GetAllRequests(_model.AllIdRequests_SearchStatus_all(_allRequest2_ViewModel.DataForSearch)));
                }
                else if (_allRequest2_ViewModel.SelectedCriteriaSearch == _allRequest2_ViewModel.ListCriteriaSearch[4])
                {
                    errors.AppendLine("К сожалению, поиск по данному критерию еще не настроен");
                }
                else if (_allRequest2_ViewModel.SelectedCriteriaSearch == _allRequest2_ViewModel.ListCriteriaSearch[5])
                {
                    _allRequest2_ViewModel.AllRequest = new BindableCollection<Request_DataModel>
                        (_model.GetAllRequests(_model.AllIdRequest_SearchName_all(_allRequest2_ViewModel.DataForSearch)));
                }
                else if (_allRequest2_ViewModel.SelectedCriteriaSearch == _allRequest2_ViewModel.ListCriteriaSearch[6])
                {
                    _allRequest2_ViewModel.AllRequest = new BindableCollection<Request_DataModel>
                        (_model.GetAllRequests(_model.AllIdRequest_SearchDescription_all(_allRequest2_ViewModel.DataForSearch)));
                }
                else if (_allRequest2_ViewModel.SelectedCriteriaSearch == _allRequest2_ViewModel.ListCriteriaSearch[7])
                {
                    _allRequest2_ViewModel.AllRequest = new BindableCollection<Request_DataModel>
                        (_model.GetAllRequests(_model.AllIdRequest_SearchComment_all(_allRequest2_ViewModel.DataForSearch)));
                }
                else if (_allRequest2_ViewModel.SelectedCriteriaSearch == _allRequest2_ViewModel.ListCriteriaSearch[8])
                {
                    _allRequest2_ViewModel.AllRequest = new BindableCollection<Request_DataModel>
                        (_model.GetAllRequests(_model.AllIdRequest_SearchCategory_all(_allRequest2_ViewModel.DataForSearch)));
                }
                else if (_allRequest2_ViewModel.SelectedCriteriaSearch == _allRequest2_ViewModel.ListCriteriaSearch[9])
                {
                    errors.AppendLine("К сожалению, поиск по данному критерию еще не настроен");
                }
                else if (_allRequest2_ViewModel.SelectedCriteriaSearch == _allRequest2_ViewModel.ListCriteriaSearch[10])
                {
                    errors.AppendLine("К сожалению, поиск по данному критерию еще не настроен");
                }



                if (_allRequest2_ViewModel.AllRequest.Count == 0)
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
    internal class UpdateDataAllCommand : AllRequestHelpCommand
    {
        AllRequest_Model _model = new AllRequest_Model();

        public UpdateDataAllCommand(AllRequest2_ViewModel allRequest2_ViewModel) : base(allRequest2_ViewModel) { }
        public override bool CanExecute(object parameter) => true;
        public override void Execute(object parameter) => UpdateData();

        private void UpdateData()
        {
            Request_DataModel.AllRequestID.Clear();

            _allRequest2_ViewModel.AllRequest = new BindableCollection<Request_DataModel>
                (_model.GetAllRequests(_model.AllIdRequest_all));

            _allRequest2_ViewModel.SelectedCriteriaSearch = null;
            _allRequest2_ViewModel.DataForSearch = null;

        }
    }
    #endregion

    #region Вспомогательный класс для команд
    abstract class AllRequestHelpCommand : ICommand
    {
        protected AllRequest2_ViewModel _allRequest2_ViewModel;
        public AllRequestHelpCommand(AllRequest2_ViewModel allRequest2_ViewModel)
        {
            _allRequest2_ViewModel = allRequest2_ViewModel;
        }
        public event EventHandler CanExecuteChanged;
        public abstract bool CanExecute(object parameter);
        public abstract void Execute(object parameter);
    }

    #endregion
}
