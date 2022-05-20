using RequestForRepairWPF.Data.User;
using RequestForRepairWPF.Entities;
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

    #region Класс-команда для сохранения данных заявки
    internal class SaveRequestDataCommand : MyRequestCommand
    {
        private Entities.DB_RequestForRepairEntities context = new Entities.DB_RequestForRepairEntities();
        StringBuilder errors = new StringBuilder();

        public SaveRequestDataCommand(CreateRequest_ViewModel createRequest_ViewModel) : base(createRequest_ViewModel) { }
        public override bool CanExecute(object parameter) => true;
        public override void Execute(object parameter) => SaveRequestData();
        private void SaveRequestData()
        {
            if (string.IsNullOrWhiteSpace(_createRequest_ViewModel.NameRequest))
                errors.AppendLine("Вашей заявке необходимо название!");
            if (string.IsNullOrWhiteSpace(_createRequest_ViewModel.DescriptionRequest))
                errors.AppendLine("Описание - это самая важная часть заявки!");
            if (_createRequest_ViewModel.RoomNumberRequest == 0)
                errors.AppendLine("Вам необходимо выбрать помещение!");
            if (_createRequest_ViewModel.DateEnd <= _createRequest_ViewModel.DateStart)
                errors.AppendLine("Необходимая дата окончания выполнения работ по заявке не может быть меньше или равна дате начала выполнения работ.\nПожалуйста, выберите корректную дату окончания выполнения работ по заявке!");
            if (string.IsNullOrWhiteSpace(_createRequest_ViewModel.CategoryRequest))
                errors.AppendLine("Вам необходимо выбрать категорию работ для заявки!");
            
            if(errors.Length > 0)
            {
                OpenDialogWindow(errors.ToString());
                errors.Clear();
                return;
            }
            else
            {
                SaveData(_createRequest_ViewModel.DateStart, _createRequest_ViewModel.DateEnd, _createRequest_ViewModel.RoomNumberRequest,
                    _createRequest_ViewModel.NameRequest, _createRequest_ViewModel.DescriptionRequest, _createRequest_ViewModel.CommentRequest,
                    _createRequest_ViewModel.InventoryNumber, _createRequest_ViewModel.CategoryRequest);
                ClearData();
            }

        }

        #region Сохранение данных в бд 
        private void SaveData(DateTime _date_start, DateTime _date_end, int _room_number, string _name_request, string _description_request, string _comment_request, string _inventory_number, string _category_request)
        {
            User authUser = new User
            {
                id_user = User_DataModel._idUser
            };

            Entities.Request request = new Entities.Request
            {
                date_start = _date_start,
                date_end = _date_end,
                status_request = "На модерации",
                room_number = _room_number,
                name_request = _name_request,
                description_request = _description_request,
                comment_request = _comment_request,
                inventory_number = _inventory_number,
                category_request = _category_request
            };
            context.Request.Add(request);
            context.SaveChanges();
            
            request.User.Add(
                new User { 
                    id_user = User_DataModel._idUser, 
                    id_type = User_DataModel._idType, 
                    user_login = User_DataModel._userLogin,
                    user_password = User_DataModel._userPassword,
                    last_name = User_DataModel._lastName,
                    name = User_DataModel._name,
                    middle_name = User_DataModel._middleName,
                    position = User_DataModel._position,
                    category_executors = User_DataModel._categoryExecutors,
                    phone = User_DataModel._phone
            });

            //authUser.Requests.Add(request);
            try
            {
                context.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}", validationErrors.Entry.Entity.ToString(), validationError.ErrorMessage);
                        //raise a new exception inserting the current one as the InnerException
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }

            OpenDialogWindow("Заявка " + request.id_request + " была успешно создана и передана на модерацию");
        }
        #endregion






        #region Очищение полей 
        private void ClearData()
        {
            _createRequest_ViewModel.DateStart = DateTime.Now;
            _createRequest_ViewModel.DateEnd = DateTime.Now.AddDays(14);
            _createRequest_ViewModel.RoomNumberRequest = 0;
            _createRequest_ViewModel.NameRequest = null;
            _createRequest_ViewModel.DescriptionRequest = null;
            _createRequest_ViewModel.CommentRequest = null;
            _createRequest_ViewModel.InventoryNumber = null;
            _createRequest_ViewModel.CategoryRequest = null;
        }
        #endregion

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

    #region Класс-команда для загрузки данных
    internal class LoadRequestDataCommand : MyRequestCommand
    {
        public LoadRequestDataCommand(CreateRequest_ViewModel createRequest_ViewModel) : base(createRequest_ViewModel) { }
        public override bool CanExecute(object parameter) => true;
        public override void Execute(object parameter) => LoadRequestData();
        private void LoadRequestData()
        {
            _createRequest_ViewModel.ListCategoryRequest = Data.User.User_DataModel.AllCategoryExecutors;
            _createRequest_ViewModel.ListRoomsNumber = Data.Room.U_R_Room_DataModel._listUserRoomsNumber;
        }
    }
    #endregion

    #region Вспомогательный класс для команд
    abstract class MyRequestCommand : ICommand
    {
        protected CreateRequest_ViewModel _createRequest_ViewModel;
        public MyRequestCommand(CreateRequest_ViewModel createRequest_ViewModel)
        {
            _createRequest_ViewModel = createRequest_ViewModel;
        }
        public event EventHandler CanExecuteChanged;
        public abstract bool CanExecute(object parameter);
        public abstract void Execute(object parameter);
    }

    #endregion
}
