
using RequestForRepairWPF.Data;
using RequestForRepairWPF.Data.Request;
using RequestForRepairWPF.Data.User;
using RequestForRepairWPF.ViewModels.DialogWindows;
using RequestForRepairWPF.Views.DialogWindows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RequestForRepairWPF.Models.Pages.ViewingEditDelete_UsersData
{
    public class AllUsers_Model 
    {
        Entities.DB_RequestForRepairEntities context = new Entities.DB_RequestForRepairEntities();

        #region Поиск

        #region ЗАКАЗЧИКИ

        #region Получение id всех заказчиков (КРИТЕРИЙ ЛОГИН)
        public List<int> AllIdUsers_SearchLogin_cus(string searchData)
        {
            var query = context.User
                .Where(b => b.user_login.Contains(searchData)
                && b.id_type == 2)
                .Select(b => b.id_user);

            try
            {
                foreach (var i in query)
                    User_DataModel.AllUsersID.Add(Convert.ToInt32(i));
            }
            catch (Exception e)
            {
                OpenDialogWindow("Ошибка!!!\n" + e.ToString());
            }


            return User_DataModel.AllUsersID;
        }
        #endregion

        #region Получение id всех заказчиков (КРИТЕРИЙ ФАМИЛИЯ)
        public List<int> AllIdUsers_SearchLastName_cus(string searchData)
        {
            var query = context.User
                .Where(b => b.last_name.Contains(searchData)
                && b.id_type == 2)
                .Select(b => b.id_user);

            try
            {
                foreach (var i in query)
                    User_DataModel.AllUsersID.Add(Convert.ToInt32(i));
            }
            catch (Exception e)
            {
                OpenDialogWindow("Ошибка!!!\n" + e.ToString());
            }


            return User_DataModel.AllUsersID;
        }
        #endregion

        #region Получение id всех заказчиков (КРИТЕРИЙ ИМЯ)
        public List<int> AllIdUsers_SearchName_cus(string searchData)
        {
            var query = context.User
                .Where(b => b.name.Contains(searchData)
                && b.id_type == 2)
                .Select(b => b.id_user);

            try
            {
                foreach (var i in query)
                    User_DataModel.AllUsersID.Add(Convert.ToInt32(i));
            }
            catch (Exception e)
            {
                OpenDialogWindow("Ошибка!!!\n" + e.ToString());
            }


            return User_DataModel.AllUsersID;
        }
        #endregion

        #region Получение id всех заказчиков (КРИТЕРИЙ ОТЧЕСТВО)
        public List<int> AllIdUsers_SearchMiddleName_cus(string searchData)
        {
            var query = context.User
                .Where(b => b.middle_name.Contains(searchData)
                && b.id_type == 2)
                .Select(b => b.id_user);

            try
            {
                foreach (var i in query)
                    User_DataModel.AllUsersID.Add(Convert.ToInt32(i));
            }
            catch (Exception e)
            {
                OpenDialogWindow("Ошибка!!!\n" + e.ToString());
            }


            return User_DataModel.AllUsersID;
        }
        #endregion

        #region Получение id всех заказчиков (КРИТЕРИЙ ДОЛЖНОСТЬ)
        public List<int> AllIdUsers_SearchPosition_cus(string searchData)
        {
            var query = context.User
                .Where(b => b.position.Contains(searchData)
                && b.id_type == 2)
                .Select(b => b.id_user);

            try
            {
                foreach (var i in query)
                    User_DataModel.AllUsersID.Add(Convert.ToInt32(i));
            }
            catch (Exception e)
            {
                OpenDialogWindow("Ошибка!!!\n" + e.ToString());
            }


            return User_DataModel.AllUsersID;
        }
        #endregion

        #region Получение id всех заказчиков (КРИТЕРИЙ ТЕЛЕФОН)
        public List<int> AllIdUsers_SearchPhone_cus(string searchData)
        {
            var query = context.User
                .Where(b => b.phone.Contains(searchData)
                && b.id_type == 2)
                .Select(b => b.id_user);

            try
            {
                foreach (var i in query)
                    User_DataModel.AllUsersID.Add(Convert.ToInt32(i));
            }
            catch (Exception e)
            {
                OpenDialogWindow("Ошибка!!!\n" + e.ToString());
            }


            return User_DataModel.AllUsersID;
        }
        #endregion

        #endregion

        #region ИСПОЛНИТЕЛИ

        #region Получение id всех исполнителей (КРИТЕРИЙ КАТЕГОРИЯ ИСПОЛНИТЕЛЯ)
        public List<int> AllIdUsers_SearchCategoryExecutors_exe(string searchData)
        {
            var query = context.User
                .Where(b => b.category_executors.Contains(searchData) 
                && b.id_type == 3)
                .Select(b => b.id_user);

            try
            {
                foreach (var i in query)
                    User_DataModel.AllUsersID.Add(Convert.ToInt32(i));
            }
            catch (Exception e)
            {
                OpenDialogWindow("Ошибка!!!\n" + e.ToString());
            }


            return User_DataModel.AllUsersID;
        }
        #endregion

        #region Получение id всех исполнителей (КРИТЕРИЙ ЛОГИН)
        public List<int> AllIdUsers_SearchLogin_exe(string searchData)
        {
            var query = context.User
                .Where(b => b.user_login.Contains(searchData)
                && b.id_type == 3)
                .Select(b => b.id_user);

            try
            {
                foreach (var i in query)
                    User_DataModel.AllUsersID.Add(Convert.ToInt32(i));
            }
            catch (Exception e)
            {
                OpenDialogWindow("Ошибка!!!\n" + e.ToString());
            }


            return User_DataModel.AllUsersID;
        }
        #endregion

        #region Получение id всех исполнителей (КРИТЕРИЙ ФАМИЛИЯ)
        public List<int> AllIdUsers_SearchLastName_exe(string searchData)
        {
            var query = context.User
                .Where(b => b.last_name.Contains(searchData)
                && b.id_type == 3)
                .Select(b => b.id_user);

            try
            {
                foreach (var i in query)
                    User_DataModel.AllUsersID.Add(Convert.ToInt32(i));
            }
            catch (Exception e)
            {
                OpenDialogWindow("Ошибка!!!\n" + e.ToString());
            }


            return User_DataModel.AllUsersID;
        }
        #endregion

        #region Получение id всех исполнителей (КРИТЕРИЙ ИМЯ)
        public List<int> AllIdUsers_SearchName_exe(string searchData)
        {
            var query = context.User
                .Where(b => b.name.Contains(searchData)
                && b.id_type == 3)
                .Select(b => b.id_user);

            try
            {
                foreach (var i in query)
                    User_DataModel.AllUsersID.Add(Convert.ToInt32(i));
            }
            catch (Exception e)
            {
                OpenDialogWindow("Ошибка!!!\n" + e.ToString());
            }


            return User_DataModel.AllUsersID;
        }
        #endregion

        #region Получение id всех исполнителей (КРИТЕРИЙ ОТЧЕСТВО)
        public List<int> AllIdUsers_SearchMiddleName_exe(string searchData)
        {
            var query = context.User
                .Where(b => b.middle_name.Contains(searchData)
                && b.id_type == 3)
                .Select(b => b.id_user);

            try
            {
                foreach (var i in query)
                    User_DataModel.AllUsersID.Add(Convert.ToInt32(i));
            }
            catch (Exception e)
            {
                OpenDialogWindow("Ошибка!!!\n" + e.ToString());
            }


            return User_DataModel.AllUsersID;
        }
        #endregion

        #region Получение id всех исполнителей (КРИТЕРИЙ ДОЛЖНОСТЬ)
        public List<int> AllIdUsers_SearchPosition_exe(string searchData)
        {
            var query = context.User
                .Where(b => b.position.Contains(searchData)
                && b.id_type == 3)
                .Select(b => b.id_user);

            try
            {
                foreach (var i in query)
                    User_DataModel.AllUsersID.Add(Convert.ToInt32(i));
            }
            catch (Exception e)
            {
                OpenDialogWindow("Ошибка!!!\n" + e.ToString());
            }


            return User_DataModel.AllUsersID;
        }
        #endregion

        #region Получение id всех исполнителей (КРИТЕРИЙ ТЕЛЕФОН)
        public List<int> AllIdUsers_SearchPhone_exe(string searchData)
        {
            var query = context.User
                .Where(b => b.phone.Contains(searchData)
                && b.id_type == 3)
                .Select(b => b.id_user);

            try
            {
                foreach (var i in query)
                    User_DataModel.AllUsersID.Add(Convert.ToInt32(i));
            }
            catch (Exception e)
            {
                OpenDialogWindow("Ошибка!!!\n" + e.ToString());
            }


            return User_DataModel.AllUsersID;
        }
        #endregion

        #endregion

        #region ВСЕ ПОЛЬЗОВАТЕЛИ

        #region Получение id всех пользователй (КРИТЕРИЙ ТИП АККАУНТА)
        public List<int> AllIdUsers_SearchTypeOfAccount_all(string searchData)
        {
            User_DataModel _user = new User_DataModel();

            _user.idType = context.TypeOfAccount
                .Where(b => b.name_type.Contains(searchData))
                .Select(b => b.id_type)
                .FirstOrDefault();

            var query = context.User
                .Where(u => u.id_type == _user.idType)
                .Select(u => u.id_user);

            try
            {
                foreach (var i in query)
                    User_DataModel.AllUsersID.Add(Convert.ToInt32(i));
            }
            catch(Exception e)
            {
                OpenDialogWindow("Ошибка!!!\n" + e.ToString());
            }
            
            return User_DataModel.AllUsersID;
        }
        #endregion

        #region Получение id всех пользователей (КРИТЕРИЙ КАТЕГОРИЯ ИСПОЛНИТЕЛЯ)
        public List<int> AllIdUsers_SearchCategoryExecutors_all(string searchData)
        {
            var query = context.User
                .Where(b => b.category_executors.Contains(searchData))
                .Select(b => b.id_user);

            try
            {
                foreach (var i in query)
                    User_DataModel.AllUsersID.Add(Convert.ToInt32(i));
            }
            catch (Exception e)
            {
                OpenDialogWindow("Ошибка!!!\n" + e.ToString());
            }


            return User_DataModel.AllUsersID;
        }
        #endregion

        #region Получение id всех пользователей (КРИТЕРИЙ ЛОГИН)
        public List<int> AllIdUsers_SearchLogin_all(string searchData)
        {
            var query = context.User
                .Where(b => b.user_login.Contains(searchData))
                .Select(b => b.id_user);

            try
            {
                foreach (var i in query)
                    User_DataModel.AllUsersID.Add(Convert.ToInt32(i));
            }
            catch (Exception e)
            {
                OpenDialogWindow("Ошибка!!!\n" + e.ToString());
            }


            return User_DataModel.AllUsersID;
        }
        #endregion

        #region Получение id всех пользователей (КРИТЕРИЙ ФАМИЛИЯ)
        public List<int> AllIdUsers_SearchLastName_all(string searchData)
        {
            var query = context.User
                .Where(b => b.last_name.Contains(searchData))
                .Select(b => b.id_user);

            try
            {
                foreach (var i in query)
                    User_DataModel.AllUsersID.Add(Convert.ToInt32(i));
            }
            catch (Exception e)
            {
                OpenDialogWindow("Ошибка!!!\n" + e.ToString());
            }


            return User_DataModel.AllUsersID;
        }
        #endregion

        #region Получение id всех пользователей (КРИТЕРИЙ ИМЯ)
        public List<int> AllIdUsers_SearchName_all(string searchData)
        {
            var query = context.User
                .Where(b => b.name.Contains(searchData))
                .Select(b => b.id_user);

            try
            {
                foreach (var i in query)
                    User_DataModel.AllUsersID.Add(Convert.ToInt32(i));
            }
            catch (Exception e)
            {
                OpenDialogWindow("Ошибка!!!\n" + e.ToString());
            }


            return User_DataModel.AllUsersID;
        }
        #endregion

        #region Получение id всех пользователей (КРИТЕРИЙ ОТЧЕСТВО)
        public List<int> AllIdUsers_SearchMiddleName_all(string searchData)
        {
            var query = context.User
                .Where(b => b.middle_name.Contains(searchData))
                .Select(b => b.id_user);

            try
            {
                foreach (var i in query)
                    User_DataModel.AllUsersID.Add(Convert.ToInt32(i));
            }
            catch (Exception e)
            {
                OpenDialogWindow("Ошибка!!!\n" + e.ToString());
            }


            return User_DataModel.AllUsersID;
        }
        #endregion

        #region Получение id всех пользователей (КРИТЕРИЙ ДОЛЖНОСТЬ)
        public List<int> AllIdUsers_SearchPosition_all(string searchData)
        {
            var query = context.User
                .Where(b => b.position.Contains(searchData))
                .Select(b => b.id_user);

            try
            {
                foreach (var i in query)
                    User_DataModel.AllUsersID.Add(Convert.ToInt32(i));
            }
            catch (Exception e)
            {
                OpenDialogWindow("Ошибка!!!\n" + e.ToString());
            }


            return User_DataModel.AllUsersID;
        }
        #endregion

        #region Получение id всех пользователей (КРИТЕРИЙ ТЕЛЕФОН)
        public List<int> AllIdUsers_SearchPhone_all(string searchData)
        {
            var query = context.User
                .Where(b => b.phone.Contains(searchData))
                .Select(b => b.id_user);

            try
            {
                foreach (var i in query)
                    User_DataModel.AllUsersID.Add(Convert.ToInt32(i));
            }
            catch (Exception e)
            {
                OpenDialogWindow("Ошибка!!!\n" + e.ToString());
            }


            return User_DataModel.AllUsersID;
        }
        #endregion

        #endregion

        #endregion

        #region Отображение данных

        #region Получение id всех пользователей (ВСЕ ПОЛЬЗОВАТЕЛИ)
        public List<int> AllIdUsers_All
        {
            get
            {
                var query = from u in context.User
                            select u.id_user;

                foreach (var i in query)
                    User_DataModel.AllUsersID.Add(i);

                return User_DataModel.AllUsersID;
            }
        }
        #endregion

        #region Получение id всех пользователей (ВСЕ ЗАКАЗЧИКИ)
        public List<int> AllIdUsers_Customers
        {
            get
            {
                var query = from u in context.User
                            where u.id_type == 2
                            select u.id_user;

                foreach (var i in query)
                    User_DataModel.AllUsersID.Add(i);

                return User_DataModel.AllUsersID;
            }
        }
        #endregion 

        #region Получение id всех пользователей (ВСЕ ИСПОЛНИТЕЛИ)
        public List<int> AllIdUsers_Executors
        {
            get
            {
                var query = from u in context.User
                            where u.id_type == 3
                            select u.id_user;
                foreach (var i in query)
                    User_DataModel.AllUsersID.Add(i);

                return User_DataModel.AllUsersID;
            }
        }
        #endregion

        #region Получение списка пользователей (ВСЕ ПОЛЬЗОВАТЕЛИ)
        public List<User_DataModel> GetPeople_All(List<int> AllIdUsers)
        {
            List<User_DataModel> output = new List<User_DataModel>();

            foreach (var i in AllIdUsers)
                output.Add(GetPerson_All(i));

            return output;
        }
        #endregion

        #region Получение списка пользователй (ВСЕ ЗАКАЗЧИКИ)
        public List<User_DataModel> GetPeople_Customers(List<int> AllIdUsers)
        {
            List<User_DataModel> output = new List<User_DataModel>();

            foreach (var i in AllIdUsers)
                output.Add(GetPerson_Customer(i));

            return output;
        }
        #endregion

        #region Получение списка пользователей (ВСЕ ИСПОЛНИТЕЛИ)
        public List<User_DataModel> GetPeople_Executors(List<int> AllIdUsers)
        {
            List<User_DataModel> output = new List<User_DataModel>();

            foreach (var i in AllIdUsers)
                output.Add(GetPerson_Executor(i));

            return output;
        }
        #endregion

        #region Получение одного пользователя (ВСЕ ПОЛЬЗОВАТЕЛИ)
        private User_DataModel GetPerson_All(int id)
        {
            User_DataModel output = new User_DataModel();

            output.idUser = id;
            output.userLogin = UserLogin(id);
            output.userPassword = UserPass(id);
            output.typeOfAccount = UserTypeOfAccount(id);
            output.lastName = UserLastName(id);
            output.name = UserName(id);
            output.middleName = UserMiddleName(id);
            output.position = UserPosition(id);
            output.categoryExecutors = UserCategoryExecutors(id);
            output.phone = UserPhone(id);
            output.ListUserActiveRequest_Name = UserListRequestName(id);

            return output;
        }
        #endregion

        #region Получение одного пользоватлея (ВСЕ ЗАКАЗЧИКИ)
        private User_DataModel GetPerson_Customer(int id)
        {
            User_DataModel output = new User_DataModel();

            output.idUser = id;
            output.userLogin = UserLogin(id);
            output.userPassword = UserPass(id);
            output.lastName = UserLastName(id);
            output.name = UserName(id);
            output.middleName = UserMiddleName(id);
            output.position = UserPosition(id);
            output.phone = UserPhone(id);
            output.ListUserRooms = ListUserRoomsNumber(id);
            output.ListUserActiveRequest_Name = UserListRequestName(id);

            return output;
        }
        #endregion

        #region Получeние одного пользователя (ВСЕ ИСПОЛНИТЕЛИ)
        private User_DataModel GetPerson_Executor(int id)
        {
            User_DataModel output = new User_DataModel();

            output.idUser = id;
            output.userLogin = UserLogin(id);
            output.userPassword = UserPass(id);
            output.categoryExecutors = UserCategoryExecutors(id);
            output.lastName = UserLastName(id);
            output.name = UserName(id);
            output.middleName = UserMiddleName(id);
            output.position = UserPosition(id);
            output.phone = UserPhone(id);
            output.ListUserActiveRequest_Name = UserListRequestName(id);

            return output;
        }
        #endregion

        #endregion

        #region Получение данных

        #region Получение списка заявок
        public List<string> UserListRequestName(int id)
        {
            var _user = new User_DataModel();
            //var _request = new Request_DataModel();

            _user.idType = context.User
                              .Where(r => r.id_user == id)
                              .Select(r => r.id_type)
                              .FirstOrDefault();

            if(_user.idType == 1)
            {
                return null;
            }
            else if(_user.idType == 2)
            {
                var queryUserID = context.User.Include("Request")
                    .Where(u => u.id_user == id);

                foreach(var u in queryUserID)
                {
                    var queryRequestID = from t in u.Request
                                         select t.id_request;

                    try
                    {
                        foreach (var r in queryRequestID)
                            _user.ListUserActiveRequest.Add(r);
                    }
                    catch(Exception e)
                    {
                        OpenDialogWindow("Ошибка!!!\n" + e.ToString());
                    }
                }
            }
            else if(_user.idType == 3)
            {
                var queryUserID = context.User.Include("Request")
                    .Where(u => u.id_user == id);

                foreach(var u in queryUserID)
                {
                    var queryRequestID = from t in u.Request1
                                         select t.id_request;

                    try
                    {
                        foreach (var r in queryRequestID)
                            _user.ListUserActiveRequest.Add(r);
                    }
                    catch(Exception e)
                    {
                        OpenDialogWindow("Ошибка!!!\n" + e.ToString());
                    }
                }
            }

            foreach(var i in _user.ListUserActiveRequest)
            {
                var queryRequestName = from t in context.Request
                                       where t.id_request == i
                                       select t.name_request;
                try
                {
                    foreach (var r in queryRequestName)
                        _user.ListUserActiveRequest_Name.Add(r);
                }
                catch(Exception e)
                {
                    OpenDialogWindow("Ошибка!!!\n" + e.ToString());
                }
            }

            return _user.ListUserActiveRequest_Name;
        }
        #endregion

        #region Получение списка помещений
        public List<int> ListUserRoomsNumber(int id)
        {
            User_DataModel output = new User_DataModel();

            var queryRoomsID = from r in context.U_R_Room
                               where r.userID_URR == id
                               select r.id_room;

            foreach (var q in queryRoomsID)
            {

                var queryRoomsNumber = context.Rooms
                    .Where(c => c.id_room == q)
                    .Select(c => c.room_number)
                    .FirstOrDefault();

                output.ListUserRooms.Add(queryRoomsNumber);
            }

            return output.ListUserRooms;
        }
        #endregion

        #region Логин пользователя
        private string UserLogin(int id)
        {
            string _login = context.User
                .Where(c => c.id_user == id)
                .Select(c => c.user_login)
                .FirstOrDefault();

            return _login;
        }
        #endregion

        #region Пароль
        private string UserPass(int id)
        {
            string _password = context.User
                .Where(c => c.id_user == id)
                .Select(c => c.user_password)
                .FirstOrDefault();

            return _password;
        }
        #endregion

        #region Тип аккаунта
        public string UserTypeOfAccount(int id)
        {
            string _typeOfAccount = null;
            int _idType = context.User
                .Where(c => c.id_user == id)
                .Select(c => c.id_type)
                .FirstOrDefault();

            if (_idType == 1)
            {
                _typeOfAccount = "Администратор";
            }
            else if (_idType == 2)
            {
                _typeOfAccount = "Заказчик";
            }
            else if (_idType == 3)
            {
                _typeOfAccount = "Исполнитель";
            }

            return _typeOfAccount;
        }
        #endregion

        #region Категория исполнителя
        private string UserCategoryExecutors(int id)
        {
            string _categoryExecutors = context.User
                .Where(c => c.id_user == id)
                .Select(c => c.category_executors)
                .FirstOrDefault();

            return _categoryExecutors;
        }
        #endregion

        #region Фамилия
        private string UserLastName(int id)
        {
            string _lastName = context.User
                .Where(c => c.id_user == id)
                .Select(c => c.last_name)
                .FirstOrDefault();

            return _lastName;
        }
        #endregion

        #region Имя
        private string UserName(int id)
        {
            string _name = context.User
                .Where(c => c.id_user == id)
                .Select(c => c.name)
                .FirstOrDefault();

            return _name;
        }
        #endregion

        #region Отчество 
        private string UserMiddleName(int id)
        {
            string _middleName = context.User
                .Where(c => c.id_user == id)
                .Select(c => c.middle_name)
                .FirstOrDefault();

            return _middleName;
        }
        #endregion

        #region Должность
        private string UserPosition(int id)
        {
            string _position = context.User
                .Where(c => c.id_user == id)
                .Select(c => c.position)
                .FirstOrDefault();

            return _position;
        }
        #endregion

        #region Телефон
        private string UserPhone(int id)
        {
            string _phone = context.User
                .Where(c => c.id_user == id)
                .Select(c => c.phone)
                .FirstOrDefault();

            return _phone;
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
