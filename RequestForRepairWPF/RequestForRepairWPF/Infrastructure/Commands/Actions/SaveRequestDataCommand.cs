using RequestForRepairWPF.Data.User;
using RequestForRepairWPF.Entities;
using RequestForRepairWPF.ViewModels.DialogWindows;
using RequestForRepairWPF.ViewModels.Pages.Request;
using RequestForRepairWPF.Views.DialogWindows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestForRepairWPF.Infrastructure.Commands.Actions
{
    /// <summary>
    /// Класс-команда для сохранения данных заявки
    /// </summary>
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

            if (errors.Length > 0)
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
                new User
                {
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
}
