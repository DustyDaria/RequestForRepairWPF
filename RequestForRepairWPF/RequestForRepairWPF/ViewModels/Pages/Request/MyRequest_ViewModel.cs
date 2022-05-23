using Caliburn.Micro;
using RequestForRepairWPF.Data.Request;
using RequestForRepairWPF.Infrastructure.Commands.Actions;
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
}
