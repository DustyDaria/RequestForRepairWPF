using RequestForRepairWPF.Data.User;
using RequestForRepairWPF.Entities;
using RequestForRepairWPF.Infrastructure.Commands.Actions;
using RequestForRepairWPF.ViewModels.Base;
using RequestForRepairWPF.ViewModels.DialogWindows;
using RequestForRepairWPF.Views.DialogWindows;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RequestForRepairWPF.ViewModels.Pages.Request
{
    public class CreateRequest_ViewModel : ViewModel
    {
        #region название заявки
        private static string _nameRequest;
        public string NameRequest
        {
            get => _nameRequest;
            set => Set(ref _nameRequest, value);
        }
        #endregion

        #region Описание заявки
        private static string _descriptionRequest;
        public string DescriptionRequest
        {
            get => _descriptionRequest;
            set => Set(ref _descriptionRequest, value);
        }
        #endregion

        #region Комментарий к заявке
        private static string _commentRequest;
        public string CommentRequest
        {
            get => _commentRequest;
            set => Set(ref _commentRequest, value);
        }
        #endregion

        #region Статус заявки
        private static string _statusRequest;
        public string StatusRequest
        {
            get => _statusRequest;
            set => Set(ref _statusRequest, value);
        }
        #endregion

        #region Список номеров помещений заказчика
        private static List<int> _listRoomsNumber;
        public List<int> ListRoomsNumber
        {
            get => _listRoomsNumber;
            set => Set(ref _listRoomsNumber, value);
        }
        #endregion

        #region Выбранное помещение
        private static int _roomNumberRequest;
        public int RoomNumberRequest
        {
            get => _roomNumberRequest;
            set => Set(ref _roomNumberRequest, value);
        }
        #endregion

        #region Инвентарный номер ремонтируемого объекта
        private static string _inventoryNumber;
        public string InventoryNumber
        {
            get => _inventoryNumber;
            set => Set(ref _inventoryNumber, value);
        }
        #endregion

        #region Дата начала
        private static DateTime _dateStart = DateTime.Now;
        public DateTime DateStart
        {
            get => _dateStart;
            set => Set(ref _dateStart, value);
        }
        #endregion

        #region Дата окончания
        private static DateTime _dateEnd = DateTime.Now.AddDays(14);
        public DateTime DateEnd
        {
            get => _dateEnd;
            set => Set(ref _dateEnd, value);
        }
        #endregion

        #region Список категорий работ
        private static List<string> _listCategoryRequest;
        public List<string> ListCategoryRequest
        {
            get => _listCategoryRequest;
            set => Set(ref _listCategoryRequest, value);
        }
        #endregion

        #region выбранная Категория работ
        private static string _categoryRequest;
        public string CategoryRequest
        {
            get => _categoryRequest;
            set => Set(ref _categoryRequest, value);
        }
        #endregion

        #region Команды

        #region Команда на загрузку данных 
        private ICommand _loadRequestDataCommand;
        public ICommand LoadRequestDataCommand
        {
            get
            {
                _loadRequestDataCommand = new LoadRequestDataCommand(this);
                return _loadRequestDataCommand;
            }
        }
        #endregion

        #region Команда на сохранение данных
        private ICommand _saveRequestDataCommand;
        public ICommand SaveRequestDataCommand
        {
            get
            {
                _saveRequestDataCommand = new SaveRequestDataCommand(this);
                return _saveRequestDataCommand;
            }
        }
        #endregion

        #endregion
    }
}
