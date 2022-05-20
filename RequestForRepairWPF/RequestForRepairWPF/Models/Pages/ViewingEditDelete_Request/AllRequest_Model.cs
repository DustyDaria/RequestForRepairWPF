using RequestForRepairWPF.Data.Request;
using RequestForRepairWPF.Data.User;
using RequestForRepairWPF.Entities;
using RequestForRepairWPF.ViewModels.DialogWindows;
using RequestForRepairWPF.Views.DialogWindows;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RequestForRepairWPF.Models.Pages.ViewingEditDelete_Request
{
    public class AllRequest_Model
    {
        Entities.DB_RequestForRepairEntities context = new Entities.DB_RequestForRepairEntities();

        #region Поиск

        #region ВСЕ ЗАЯВКИ

        #region Получение id всех заявок (КРИТЕРИЙ ДАТА НАЧАЛА)

        #endregion

        #region Получение id всех заявок (КРИТЕРИЙ ДАТА ОКОНЧАНИЯ)

        #endregion

        #region Получение id всех заявок (КРИТЕРИЙ РЕАЛЬНАЯ ДАТА ОКОНЧАНИЯ)

        #endregion

        #region Получение id всех заявок (КРИТЕРИЙ СТАТУС ЗАЯВКИ)
        public List<int> AllIdRequests_SearchStatus_all(string searchData)
        {
            var query = context.Request
                .Where(b => b.status_request.Contains(searchData))
                .Select(b => b.id_request);

            try
            {
                foreach (var i in query)
                    Request_DataModel.AllRequestID.Add(i);
            }
            catch (Exception e)
            {
                OpenDialogWindow("Ошибка!!!\n" + e.ToString());
            }

            return Request_DataModel.AllRequestID;
        }
        #endregion

        #region Получение id всех заявок (КРИТЕРИЙ НОМЕР ПОМЕЩЕНИЯ)

        #endregion

        #region Получение id всех заявок (КРИТЕРИЙ НАЗВАНИЕ ЗАЯВКИ)
        public List<int> AllIdRequest_SearchName_all(string searchData)
        {
            var query = context.Request
                .Where(b => b.name_request.Contains(searchData))
                .Select(b => b.id_request);

            try
            {
                foreach (var i in query)
                    Request_DataModel.AllRequestID.Add(i);
            }
            catch (Exception e)
            {
                OpenDialogWindow("Ошибка!!!\n" + e.ToString());
            }

            return Request_DataModel.AllRequestID;
        }
        #endregion

        #region Получение id всех заявок (КРИТЕРИЙ ОПИСАНИЕ ЗАЯВКИ)
        public List<int> AllIdRequest_SearchDescription_all(string searchData)
        {
            var query = context.Request
                .Where(b => b.description_request.Contains(searchData))
                .Select(b => b.id_request);

            try
            {
                foreach (var i in query)
                    Request_DataModel.AllRequestID.Add(i);
            }
            catch (Exception e)
            {
                OpenDialogWindow("Ошибка!!!\n" + e.ToString());
            }

            return Request_DataModel.AllRequestID;
        }
        #endregion

        #region Получение id всех заявок (КРИТЕРИЙ КОММЕНТАРИЙ К ЗАЯВКЕ)
        public List<int> AllIdRequest_SearchComment_all(string searchData)
        {
            var query = context.Request
                .Where(b => b.comment_request.Contains(searchData))
                .Select(b => b.id_request);

            try
            {
                foreach (var i in query)
                    Request_DataModel.AllRequestID.Add(i);
            }
            catch (Exception e)
            {
                OpenDialogWindow("Ошибка!!!\n" + e.ToString());
            }

            return Request_DataModel.AllRequestID;
        }
        #endregion

        #region Получение id всех заявок (КРИТЕРИЙ КАТЕГОРИЯ ЗАЯВКИ)
        public List<int> AllIdRequest_SearchCategory_all(string searchData)
        {
            var query = context.Request
                .Where(b => b.category_request.Contains(searchData))
                .Select(b => b.id_request);

            try
            {
                foreach (var i in query)
                    Request_DataModel.AllRequestID.Add(i);
            }
            catch (Exception e)
            {
                OpenDialogWindow("Ошибка!!!\n" + e.ToString());
            }

            return Request_DataModel.AllRequestID;
        }
        #endregion

        #region Получение id всех заявок (КРИТЕРИЙ ЗАКАЗЧИК)
        public List<int> AllIdRequest_SearchCustomer_all(string searchData)
        {
            var _user = new User_DataModel();
            var _request = new Request_DataModel();

            _request.FullNameExecutor = searchData;



                var queryUserID = context.User.Include("Request")
                .Where(u => u.id_user == User_DataModel._idUser);

                foreach (var u in queryUserID)
                {
                    var queryRequestID = from t in u.Request
                                         select t.id_request;
                    foreach (var r in queryRequestID)
                    {
                        Request_DataModel.AllRequestID.Add(r);
                    }
                }
            

            return Request_DataModel.AllRequestID;
        }
        #endregion

        #region Получение id всех заявок (КРИТЕРИЙ ИСПОЛНИТЕЛЬ)

        #endregion

        #endregion

        #region МОИ ЗАЯВКИ

        #region Получение id всех заявок (КРИТЕРИЙ ДАТА НАЧАЛА)

        #endregion

        #region Получение id всех заявок (КРИТЕРИЙ ДАТА ОКОНЧАНИЯ)

        #endregion

        #region Получение id всех заявок (КРИТЕРИЙ РЕАЛЬНАЯ ДАТА ОКОНЧАНИЯ)

        #endregion

        #region Получение id всех заявок (КРИТЕРИЙ СТАТУС ЗАЯВКИ)
        public List<int> AllIdRequests_SearchStatus_my(string searchData)
        {
            if (User_DataModel._idType == 2)
            {
                var queryUserID = context.User.Include("Request")
                .Where(u => u.id_user == User_DataModel._idUser);
                
                foreach (var u in queryUserID)
                {
                    var queryRequestID = from t in u.Request
                                         where t.status_request.Contains(searchData)
                                         select t.id_request;
                    try
                    {
                        foreach (var r in queryRequestID)
                            Request_DataModel.AllRequestID.Add(r);
                    }
                    catch (Exception e)
                    {
                        OpenDialogWindow("Ошибка!!!\n" + e.ToString());
                    }
                }
            }
            else if (User_DataModel._idType == 3)
            {
                var queryUserID = context.User.Include("Request")
                    .Where(u => u.id_user == User_DataModel._idUser);

                foreach(var u in queryUserID)
                {
                    var queryRequestID = from t in u.Request1
                                         where t.status_request.Contains(searchData)
                                         select t.id_request;
                    try
                    {
                        foreach (var r in queryRequestID)
                        Request_DataModel.AllRequestID.Add(r);
                    }
                    catch (Exception e)
                    {
                        OpenDialogWindow("Ошибка!!!\n" + e.ToString());
                    }
                }
            }

            return Request_DataModel.AllRequestID;
        }
        #endregion

        #region Получение id всех заявок (КРИТЕРИЙ НОМЕР ПОМЕЩЕНИЯ)

        #endregion

        #region Получение id всех заявок (КРИТЕРИЙ НАЗВАНИЕ ЗАЯВКИ)
        public List<int> AllIdRequests_SearchName_my(string searchData)
        {
            if (User_DataModel._idType == 2)
            {
                var queryUserID = context.User.Include("Request")
                .Where(u => u.id_user == User_DataModel._idUser);

                foreach (var u in queryUserID)
                {
                    var queryRequestID = from t in u.Request
                                         where t.name_request.Contains(searchData)
                                         select t.id_request;
                    try
                    {
                        foreach (var r in queryRequestID)
                            Request_DataModel.AllRequestID.Add(r);
                    }
                    catch (Exception e)
                    {
                        OpenDialogWindow("Ошибка!!!\n" + e.ToString());
                    }
                }
            }
            else if (User_DataModel._idType == 3)
            {
                var queryUserID = context.User.Include("Request")
                    .Where(u => u.id_user == User_DataModel._idUser);

                foreach (var u in queryUserID)
                {
                    var queryRequestID = from t in u.Request1
                                         where t.name_request.Contains(searchData)
                                         select t.id_request;
                    try
                    {
                        foreach (var r in queryRequestID)
                            Request_DataModel.AllRequestID.Add(r);
                    }
                    catch (Exception e)
                    {
                        OpenDialogWindow("Ошибка!!!\n" + e.ToString());
                    }
                }
            }

            return Request_DataModel.AllRequestID;
        }
        #endregion

        #region Получение id всех заявок (КРИТЕРИЙ ОПИСАНИЕ ЗАЯВКИ)
        public List<int> AllIdRequests_SearchDescription_my(string searchData)
        {
            if (User_DataModel._idType == 2)
            {
                var queryUserID = context.User.Include("Request")
                .Where(u => u.id_user == User_DataModel._idUser);

                foreach (var u in queryUserID)
                {
                    var queryRequestID = from t in u.Request
                                         where t.description_request.Contains(searchData)
                                         select t.id_request;
                    try
                    {
                        foreach (var r in queryRequestID)
                            Request_DataModel.AllRequestID.Add(r);
                    }
                    catch (Exception e)
                    {
                        OpenDialogWindow("Ошибка!!!\n" + e.ToString());
                    }
                }
            }
            else if (User_DataModel._idType == 3)
            {
                var queryUserID = context.User.Include("Request")
                    .Where(u => u.id_user == User_DataModel._idUser);

                foreach (var u in queryUserID)
                {
                    var queryRequestID = from t in u.Request1
                                         where t.description_request.Contains(searchData)
                                         select t.id_request;
                    try
                    {
                        foreach (var r in queryRequestID)
                            Request_DataModel.AllRequestID.Add(r);
                    }
                    catch (Exception e)
                    {
                        OpenDialogWindow("Ошибка!!!\n" + e.ToString());
                    }
                }
            }

            return Request_DataModel.AllRequestID;
        }
        #endregion

        #region Получение id всех заявок (КРИТЕРИЙ КОММЕНТАРИЙ К ЗАЯВКЕ)
        public List<int> AllIdRequests_SearchComment_my(string searchData)
        {
            if (User_DataModel._idType == 2)
            {
                var queryUserID = context.User.Include("Request")
                .Where(u => u.id_user == User_DataModel._idUser);

                foreach (var u in queryUserID)
                {

                    var queryRequestID = from t in u.Request
                                         where t.comment_request.Contains(searchData)
                                         select t.id_request;

                    try
                    {

                        foreach (var r in queryRequestID)
                            Request_DataModel.AllRequestID.Add(r);
                    }
                    catch (Exception e)
                    {
                        OpenDialogWindow("Ошибка!!!\n" + e.ToString());
                    }
                }
            }
            else if (User_DataModel._idType == 3)
            {
                var queryUserID = context.User.Include("Request")
                    .Where(u => u.id_user == User_DataModel._idUser);

                foreach (var u in queryUserID)
                {
                    var queryRequestID = from t in u.Request1
                                         where t.comment_request.Contains(searchData)
                                         select t.id_request;
                    try
                    {
                        foreach (var r in queryRequestID)
                            Request_DataModel.AllRequestID.Add(r);
                    }
                    catch (Exception e)
                    {
                        OpenDialogWindow("Ошибка!!!\n" + e.ToString());
                    }
                }
            }

            return Request_DataModel.AllRequestID;
        }
        #endregion

        #region Получение id всех заявок (КРИТЕРИЙ КАТЕГОРИЯ ЗАЯВКИ)
        public List<int> AllIdRequests_SearchCategory_my(string searchData)
        {
            if (User_DataModel._idType == 2)
            {
                var queryUserID = context.User.Include("Request")
                .Where(u => u.id_user == User_DataModel._idUser);

                foreach (var u in queryUserID)
                {
                    var queryRequestID = from t in u.Request
                                         where t.category_request.Contains(searchData)
                                         select t.id_request;
                    try
                    {
                        foreach (var r in queryRequestID)
                            Request_DataModel.AllRequestID.Add(r);
                    }
                    catch (Exception e)
                    {
                        OpenDialogWindow("Ошибка!!!\n" + e.ToString());
                    }
                }
            }
            else if (User_DataModel._idType == 3)
            {
                var queryUserID = context.User.Include("Request")
                    .Where(u => u.id_user == User_DataModel._idUser);

                foreach (var u in queryUserID)
                {
                    var queryRequestID = from t in u.Request1
                                         where t.category_request.Contains(searchData)
                                         select t.id_request;
                    try
                    {
                        foreach (var r in queryRequestID)
                            Request_DataModel.AllRequestID.Add(r);
                    }
                    catch (Exception e)
                    {
                        OpenDialogWindow("Ошибка!!!\n" + e.ToString());
                    }
                }
            }

            return Request_DataModel.AllRequestID;
        }
        #endregion

        #region Получение id всех заявок (КРИТЕРИЙ ЗАКАЗЧИК)
        
        #endregion

        #region Получение id всех заявок (КРИТЕРИЙ ИСПОЛНИТЕЛЬ)

        #endregion

        #endregion

        #endregion

        #region Отображение данных

        #region Получение id всех заявок (ВСЕ ЗАЯВКИ)
        public List<int> AllIdRequest_all
        {
            get
            {
                if(User_DataModel._idType == 1 || User_DataModel._idType == 2)
                {
                    var query = from r in context.Request
                                select r.id_request;

                    foreach (var i in query)
                        Request_DataModel.AllRequestID.Add(i);

                }
                else if(User_DataModel._idType == 3)
                {
                    var query = from r in context.Request
                                where r.category_request == User_DataModel._categoryExecutors
                                select r.id_request;

                    foreach (var i in query)
                        Request_DataModel.AllRequestID.Add(i);

                }

                return Request_DataModel.AllRequestID;
            }
        }
        #endregion

        #region Получение id всех заявок (МОИ ЗАЯВКИ)
        public List<int> AllIdRequest_my
        {
            get
            {
                if(User_DataModel._idType == 2)
                {
                    var queryUserID = context.User.Include("Request")
                    .Where(u => u.id_user == User_DataModel._idUser);

                    foreach (var u in queryUserID)
                    {
                        var queryRequestID = from t in u.Request
                                    select t.id_request;
                        try
                        {
                            foreach (var r in queryRequestID)
                                Request_DataModel.AllRequestID.Add(r);
                        }
                        catch (Exception e)
                        {
                            OpenDialogWindow("Ошибка!!!\n" + e.ToString());
                        }
                    }
                }
                else if(User_DataModel._idType == 3)
                {
                    var queryUserID = context.User.Include("Request")
                        .Where(u => u.id_user == User_DataModel._idUser);

                    foreach(var u in queryUserID)
                    {
                        var queryRequestID = from t in u.Request1
                                             select t.id_request;
                        try
                        {
                            foreach (var r in queryRequestID)
                                Request_DataModel.AllRequestID.Add(r);
                        }
                        catch (Exception e)
                        {
                            OpenDialogWindow("Ошибка!!!\n" + e.ToString());
                        }
                    }
                }

                return Request_DataModel.AllRequestID;
            }
        }
        #endregion

        #region Получение списка всех заявок (МОИ ЗАЯВКИ)
        public List<Request_DataModel> GetAllMyRequests(List<int> AllIdRequest)
        {
            var output = new List<Request_DataModel>();

            foreach (var i in AllIdRequest)
                output.Add(GetOneMyRequest(i));

            return output;
        }
        #endregion

        #region Получение списка всех заявок (ВСЕ ЗАЯВКИ)
        public List<Request_DataModel> GetAllRequests(List<int> AllIdRequest)
        {
            var output = new List<Request_DataModel>();

            foreach (var i in AllIdRequest)
                output.Add(GetOneRequest(i));

            return output;
        }
        #endregion

        #region Получение одной заявки (МОИ ЗАЯВКИ)
        private Request_DataModel GetOneMyRequest(int id)
        {
            var output = new Request_DataModel
            {
                id_request = id,
                date_start = RequestDateStart(id),
                date_end = RequestDateEnd(id),
                actual_date_end = RequestActualDateEnd(id),
                status_request = RequestStatus(id),
                room_number = RequestRoomNumber(id),
                name_request = RequestName(id),
                description_request = RequestDescription(id),
                comment_request = RequestComment(id),
                category_request = RequestCategory(id),
                FullNameCustomer = RequestCustomer(id),
                FullNameExecutor = RequestExecutor(id)
              
            };

            return output;
        }
        #endregion

        #region Получение одной заявки (ВСЕ ЗАЯВКИ)
        private Request_DataModel GetOneRequest(int id)
        {
            var output = new Request_DataModel
            {
                id_request = id,
                date_start = RequestDateStart(id),
                date_end = RequestDateEnd(id),
                actual_date_end = RequestActualDateEnd(id),
                status_request = RequestStatus(id),
                room_number = RequestRoomNumber(id),
                name_request = RequestName(id),
                description_request = RequestDescription(id),
                comment_request = RequestComment(id),
                inventory_number = RequestInventoryNumber(id),
                category_request = RequestCategory(id),
                FullNameCustomer = RequestCustomer(id),
                FullNameExecutor = RequestExecutor(id)
            };

            return output;
        }
        #endregion

        #endregion

        #region Получение данных

        #region Дата начала 
        private DateTime RequestDateStart(int id)
        {
            DateTime _dateStart = context.Request
                .Where(c => c.id_request == id)
                .Select(c => c.date_start)
                .FirstOrDefault();

            return _dateStart;
        }
        #endregion

        #region Дата окончания
        private DateTime RequestDateEnd(int id)
        {
            DateTime _dateEnd = context.Request
                .Where(c => c.id_request == id)
                .Select(c => c.date_end)
                .FirstOrDefault();

            return _dateEnd;
        }
        #endregion

        #region Заказчик
        private string RequestCustomer(int id)
        {
            var listOutput = new List<int>();
            var _user = new User_DataModel();

            var queryRequestID = context.Request.Include("User")
                .Where(u => u.id_request == id);

            foreach (var u in queryRequestID)
            {
                _user.idUser = u.User
                    .Select(t => t.id_user)
                    .FirstOrDefault();
            }

            _user.lastName = context.User
                .Where(y => y.id_user == _user.idUser)
                .Select(y => y.last_name)
                .FirstOrDefault();

            _user.name = context.User
                .Where(y => y.id_user == _user.idUser)
                .Select(y => y.name)
                .FirstOrDefault();

            _user.middleName = context.User
                .Where(y => y.id_user == _user.idUser)
                .Select(y => y.middle_name)
                .FirstOrDefault();

            return _user.FullName;
        }
        #endregion

        #region Исполнитель
        private string RequestExecutor(int id)
        {
            var listOutput = new List<int>();
            var _user = new User_DataModel();

            var queryRequestID = context.Request.Include("User")
                .Where(u => u.id_request == id);

            foreach (var u in queryRequestID)
            {
                _user.idUser = u.User1
                    .Select(t => t.id_user)
                    .FirstOrDefault();
            }

            _user.lastName = context.User
                .Where(y => y.id_user == _user.idUser)
                .Select(y => y.last_name)
                .FirstOrDefault();

            _user.name = context.User
                .Where(y => y.id_user == _user.idUser)
                .Select(y => y.name)
                .FirstOrDefault();

            _user.middleName = context.User
                .Where(y => y.id_user == _user.idUser)
                .Select(y => y.middle_name)
                .FirstOrDefault();

            return _user.FullName;
        }
        #endregion

        #region Статус заявки
        private string RequestStatus(int id)
        {
            string _status = context.Request
                 .Where(c => c.id_request == id)
                 .Select(c => c.status_request)
                 .FirstOrDefault();

            return _status;
        }
        #endregion

        #region Номер помещения
        private int RequestRoomNumber(int id)
        {
            int _roomNumber = context.Request
                .Where(c => c.id_request == id)
                .Select(c => c.room_number)
                .FirstOrDefault();

            return _roomNumber;
        }
        #endregion

        #region название заявки
        private string RequestName(int id)
        {
            string _name = context.Request
                .Where(c => c.id_request == id)
                .Select(c => c.name_request)
                .FirstOrDefault();

            return _name;
        }
        #endregion

        #region Описание заявки 
        private string RequestDescription(int id)
        {
            string _description = context.Request
                .Where(c => c.id_request == id)
                .Select(c => c.description_request)
                .FirstOrDefault();

            return _description;
        }
        #endregion

        #region Комментарий к заявке
        private string RequestComment(int id)
        {
            string _comment = context.Request
                .Where(c => c.id_request == id)
                .Select(c => c.comment_request)
                .FirstOrDefault();

            return _comment;
        }
        #endregion

        #region Инвентарный номер 
        private string RequestInventoryNumber(int id)
        {
            string _inventoryNumber = context.Request
                .Where(c => c.id_request == id)
                .Select(c => c.inventory_number)
                .FirstOrDefault();

            return _inventoryNumber;
        }
        #endregion

        #region Реальная дата окончания заявки
        private DateTime? RequestActualDateEnd(int id)
        {
            DateTime? _actualDateEnd = context.Request
                .Where(c => c.id_request == id)
                .Select(c => c.actual_date_end)
                .FirstOrDefault();

            return _actualDateEnd;
        }
        #endregion

        #region Категория заявки
        private string RequestCategory(int id)
        {
            string _category = context.Request
                .Where(c => c.id_request == id)
                .Select(c => c.category_request)
                .FirstOrDefault();

            return _category;
        }
        #endregion

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
