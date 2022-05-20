using RequestForRepairWPF.Data;
using RequestForRepairWPF.Data.Room;
using RequestForRepairWPF.Data.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RequestForRepairWPF.Models.Pages.UserAccount
{
    public class UsersData_Model 
    {
        private Entities.DB_RequestForRepairEntities context = new Entities.DB_RequestForRepairEntities();

        /// <summary>
        /// Данные авторизованного пользователя
        /// </summary>
        /// <param name="_userEmail">Логин пользователя</param>
        /// <param name="_userPassword">Пароль пользователя</param>
        #region Конструктор
        public UsersData_Model(string _userEmail, string _userPassword)
        {
            //this._userEmail = _userEmail;
            //this._userPassword = _userPassword;

            User_DataModel._userLogin = _userEmail;
            User_DataModel._userPassword = _userPassword;
        }
        #endregion

        #region Получение данных из класса User
        public int User_ID
        {
            get => User_DataModel._idUser;
        }

        public int User_IDType
        {
            get => User_DataModel._idType;
        }

        public string User_Login
        {
            get => User_DataModel._userLogin;
        }

        public string User_Password
        {
            get => User_DataModel._userPassword;
        }

        public string User_LastName
        {
            get => User_DataModel._lastName;
        }

        public string User_Name
        {
            get => User_DataModel._name;
        }

        public string User_MiddleName
        {
            get => User_DataModel._middleName;
        }

        public string User_Position
        {
            get => User_DataModel._position;
        }

        public string User_CategoryExecutors
        {
            get => User_DataModel._categoryExecutors;
        }

        public string User_Phone
        {
            get => User_DataModel._phone;
        }
        #endregion

        #region Получение данных из БД

        /// <summary> Возврат id авторизованного пользователя </summary>
        #region Возврат id авторизованного пользователя
        /// <summary> Возврат id авторизованного пользователя </summary>

        public int ID
        {
            get
            {
                User_DataModel._idUser = context.User
                    .Where(c => c.user_login == User_DataModel._userLogin && c.user_password == User_DataModel._userPassword)
                    .Select(c => c.id_user)
                    .FirstOrDefault();

                return User_DataModel._idUser;
            }
        }
        #endregion

        /// <summary> Возврат имени авторизованного пользователя </summary>
        #region Возврат имени авторизованного пользователя
        /// <summary> Возврат имени авторизованного пользователя </summary>

        public string Name
        {
            get
            {
                User_DataModel._name = context.User
                    .Where(c => c.id_user == User_DataModel._idUser)
                    .Select(c => c.name)
                    .FirstOrDefault();

                return User_DataModel._name;
            }
        }

        #endregion

        /// <summary> Возврат фамилии авторизованного пользователя </summary>
        #region Возврат фамилии авторизованного пользователя
        /// <summary> Возврат фамилии авторизованного пользователя </summary>

        public string LastName
        {
            get
            {
                User_DataModel._lastName = context.User
                    .Where(c => c.id_user == User_DataModel._idUser)
                    .Select(c => c.last_name)
                    .FirstOrDefault();

                return User_DataModel._lastName;
            }
        }

        #endregion

        /// <summary> Возврат Отчества авторизованного пользователя </summary>
        #region Возврат Отчества авторизованного пользователя
        /// <summary> Возврат Отчества авторизованного пользователя </summary>

        public string MiddleName
        {
            get
            {
                User_DataModel._middleName = context.User
                    .Where(c => c.id_user == User_DataModel._idUser)
                    .Select(c => c.middle_name)
                    .FirstOrDefault();

                return User_DataModel._middleName;
            }
        }

        #endregion

        /// <summary> Возврат Должности авторизованного пользователя </summary>
        #region Возврат Должности авторизованного пользователя
        /// <summary> Возврат Должности авторизованного пользователя </summary>

        public string Position
        {
            get
            {
                User_DataModel._position = context.User
                    .Where(c => c.id_user == User_DataModel._idUser)
                    .Select(c => c.position)
                    .FirstOrDefault();

                return User_DataModel._position;
            }
        }

        #endregion

        /// <summary> Возврат Телефона авторизованного пользователя </summary>
        #region Возврат Телефона авторизованного пользователя
        /// <summary> Возврат Телефона авторизованного пользователя </summary>

        public string Phone
        {
            get
            {
                User_DataModel._phone = context.User
                    .Where(c => c.id_user == User_DataModel._idUser)
                    .Select(c => c.phone)
                    .FirstOrDefault();

                return User_DataModel._phone;

            }
        }

        #endregion

        /// <summary> Возврат Логина авторизованного пользователя </summary>
        #region Возврат Логина авторизованного пользователя
        /// <summary> Возврат Логина авторизованного пользователя </summary>

        public string Login
        {
            get
            {
                User_DataModel._userLogin = context.User
                    .Where(c => c.id_user == User_DataModel._idUser)
                    .Select(c => c.user_login)
                    .FirstOrDefault();

                return User_DataModel._userLogin;
            }
        }

        #endregion

        /// <summary> Возврат Пароля авторизованного пользователя </summary>
        #region Возврат Пароля авторизованного пользователя
        /// <summary> Возврат Пароля авторизованного пользователя </summary>

        public string Password
        {
            get
            {
                User_DataModel._userPassword = context.User
                    .Where(c => c.id_user == User_DataModel._idUser)
                    .Select(c => c.user_password)
                    .FirstOrDefault();

                return User_DataModel._userPassword;
            }
        }

        #endregion

        /// <summary> Возврат Типа аккаунта авторизованного пользователя </summary>
        #region Возврат Типа аккаунта авторизованного пользователя
        /// <summary> Возврат Типа аккаунта авторизованного пользователя </summary>

        public int TypeOfAccount_get
        {
            get
            {
                User_DataModel._idType = context.User
                    .Where(c => c.TypeOfAccount.id_type == c.id_type && 
                    c.id_user == User_DataModel._idUser)
                    .Select(c => c.id_type)
                    .FirstOrDefault();

                return User_DataModel._idType;
            }
        }

        #endregion

        /// <summary> Возврат списка типов аккаунтов </summary>
        #region Возврат списка типов аккаунтов
        /// <summary> Возврат списка типов аккаунтов </summary>
        
        public List<string> ListUsersType
        {
            get
            {
                var allTypes = from t in context.TypeOfAccount
                               select t.name_type;
                foreach (var s in allTypes)
                    TypeOfAccount_DataModel.AllType.Add(s);

                return TypeOfAccount_DataModel.AllType;
            }
        }
        #endregion

        /// <summary> Возврат списка категорий исполнителя</summary>
        #region Возврат списка категорий исполнителя
        /// <summary> Возврат списка категорий исполнителя</summary>
        public List<string> ListCategoryExecutors
        {
            get
            {
                var allCategory = (from c in context.User
                                   where c.category_executors != string.Empty && c.category_executors != null
                                   select c.category_executors)
                                  .Distinct();
                foreach (var s in allCategory)
                    User_DataModel.AllCategoryExecutors.Add(s);

                return User_DataModel.AllCategoryExecutors;
            }
        }
        #endregion

        /// <summary> Возврат списка всех помещений</summary>
        #region Возврат списка всех помещений
        /// <summary> Возврат списка всех помещений</summary>
        public List<int> ListAllRommsNumber
        {
            get
            {
                var allRooms = from r in context.Rooms
                               select r.room_number;
                foreach (var s in allRooms)
                    Rooms_DataModel.AllRoomsNumber.Add(s);

                return Rooms_DataModel.AllRoomsNumber;
            }
        }
        #endregion

        /// <summary> Возврат списка свободных помещений</summary>
        #region Возврат списка свободных помещений
        /// <summary> Возврат списка свободных помещений</summary>
        public List<int> ListLiberyRoomsNumber
        {
            get
            {
                var allLibertyRooms = from r in context.Rooms
                                      where r.room_status == false
                                      select r.room_number;
                foreach (var s in allLibertyRooms)
                    Rooms_DataModel.AllLibertyRoomsNumber.Add(s);

                return Rooms_DataModel.AllLibertyRoomsNumber;
            }
        }
        #endregion

        /// <summary> Возврат списка всех помещений авторизованного пользователя</summary>
        #region Возврат списка всех помещений авторизованного пользователя
        /// <summary> Возврат списка всех помещений авторизованного пользователя</summary>
        /// 
        //private List<int> _listUserRoomsNumber;
        public List<int> ListUserRoomsNumber
        {
            get
            {
                var queryRoomsID = from r in context.U_R_Room
                                       where r.userID_URR == User_DataModel._idUser
                                       select r.id_room;

                foreach (var q in queryRoomsID)
                {
                    U_R_Room_DataModel._listAll_idRoom.Add(q);

                    var queryRoomsNumber = context.Rooms
                        .Where(c => c.id_room == q)
                        .Select(c => c.room_number)
                        .FirstOrDefault();

                    U_R_Room_DataModel._listUserRoomsNumber.Add(queryRoomsNumber);
                }

                return U_R_Room_DataModel._listUserRoomsNumber;
            }
        }
        #endregion

        #region Возврат номера помещения заказчика авторизованного пользователя
        public int RoomNumber
        {
            get
            {
                U_R_Room_DataModel._idRoom = context.U_R_Room
                    .Where(c => c.userID_URR == User_DataModel._idUser)
                    .Select(c => c.id_room)
                    .FirstOrDefault();

                int roomNumber = context.Rooms
                    .Where(c => c.id_room == U_R_Room_DataModel._idRoom)
                    .Select(c => c.room_number)
                    .FirstOrDefault();

                return roomNumber;
            }
        }
        #endregion
        /// <summary> Возврат Категории исполнителя авторизованного пользователя </summary>
        #region Возврат Категории исполнителя авторизованного пользователя
        /// <summary> Возврат Категории исполнителя авторизованного пользователя </summary>

        public string CategoryExecutors
        {
            get
            {
                User_DataModel._categoryExecutors = context.User
                    .Where(c => c.id_user == User_DataModel._idUser)
                    .Select(c => c.category_executors)
                    .FirstOrDefault();

                return User_DataModel._categoryExecutors;
            }
        }
        #endregion


        #endregion

        #region Проверка пользовательских данных

        #region Проверка пароля пользователя
        public string CheckUserPass
        {
            get
            {
                User_DataModel._userPassword = context.User
                    .Where(c => c.user_login == User_DataModel._userLogin)
                    .Select(c => c.user_password)
                    .FirstOrDefault();

                return User_DataModel._userPassword;
            }
        }
        #endregion

        #region Проверка типа аккаунта пользователя
        public int CheckUserType
        {
            get
            {
                User_DataModel._idType = context.User
                    .Where(c => c.user_login == User_DataModel._userLogin &&
                    c.user_password == User_DataModel._userPassword)
                    .Select(c => c.id_type)
                    .FirstOrDefault();
                return User_DataModel._idType;
            }
        }
        #endregion

        #endregion

       
    }
}
