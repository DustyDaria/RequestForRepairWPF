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
        
        #region Получение данных из БД

        /// <summary> Возврат id авторизованного пользователя </summary>
        #region Возврат id авторизованного пользователя
        /// <summary> Возврат id авторизованного пользователя </summary>
        public int ID
        {
            get
            {
                AuthUser_DataModel._idUser = context.User
                    .Where(c => c.user_login == AuthUser_DataModel._userLogin 
                    && c.user_password == AuthUser_DataModel._userPassword)
                    .Select(c => c.id_user)
                    .FirstOrDefault();

                return AuthUser_DataModel._idUser;
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
                AuthUser_DataModel._name = context.User
                    .Where(c => c.id_user == AuthUser_DataModel._idUser)
                    .Select(c => c.name)
                    .FirstOrDefault();

                return AuthUser_DataModel._name;
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
                AuthUser_DataModel._lastName = context.User
                    .Where(c => c.id_user == AuthUser_DataModel._idUser)
                    .Select(c => c.last_name)
                    .FirstOrDefault();

                return AuthUser_DataModel._lastName;
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
                AuthUser_DataModel._middleName = context.User
                    .Where(c => c.id_user == AuthUser_DataModel._idUser)
                    .Select(c => c.middle_name)
                    .FirstOrDefault();

                return AuthUser_DataModel._middleName;
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
                AuthUser_DataModel._position = context.User
                    .Where(c => c.id_user == AuthUser_DataModel._idUser)
                    .Select(c => c.position)
                    .FirstOrDefault();

                return AuthUser_DataModel._position;
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
                AuthUser_DataModel._phone = context.User
                    .Where(c => c.id_user == AuthUser_DataModel._idUser)
                    .Select(c => c.phone)
                    .FirstOrDefault();

                return AuthUser_DataModel._phone;
            }
        }

        #endregion

        #endregion

        /// <summary> Возврат Типа аккаунта авторизованного пользователя </summary>
        #region Возврат Типа аккаунта авторизованного пользователя
        /// <summary> Возврат Типа аккаунта авторизованного пользователя </summary>

        public int TypeOfAccount_get
        {
            get
            {
                AuthUser_DataModel._idType = context.User
                    .Where(c => c.TypeOfAccount.id_type == c.id_type && 
                    c.id_user == AuthUser_DataModel._idUser)
                    .Select(c => c.id_type)
                    .FirstOrDefault();

                return AuthUser_DataModel._idType;
            }
        }

        #endregion

        /// <summary> Возврат списка типов аккаунтов </summary>
        #region Возврат списка типов аккаунтов
        /// <summary> Возврат списка типов аккаунтов </summary>
        
        public List<string> ListUsersType
        {
            get => context.TypeOfAccount
                    .Select(c => c.name_type)
                    .Distinct()
                    .ToList();
        }
        #endregion

        /// <summary> Возврат списка категорий исполнителя</summary>
        #region Возврат списка категорий исполнителя
        /// <summary> Возврат списка категорий исполнителя</summary>
        public List<string> ListCategoryExecutors
        {
            get => context.User
                    .Where(c => c.category_executors != String.Empty
                    && c.category_executors != null)
                    .Select(c => c.category_executors)
                    .Distinct()
                    .ToList();
        }
        #endregion

        /// <summary> Возврат списка всех помещений</summary>
        #region Возврат списка всех помещений
        /// <summary> Возврат списка всех помещений</summary>
        public List<int> ListAllRoomsNumber
        {
            get => context.Rooms
                   .Select(c => c.room_number)
                   .ToList();
        }
        #endregion

        /// <summary> Возврат списка свободных помещений</summary>
        #region Возврат списка свободных помещений
        /// <summary> Возврат списка свободных помещений</summary>
        public List<int> ListLiberyRoomsNumber
        {
            get => context.Rooms
                    .Where(c => c.room_status == false)
                    .Select(c => c.room_number)
                    .ToList(); 
        }
        #endregion

        /// <summary> Возврат списка всех помещений авторизованного пользователя</summary>
        #region Возврат списка всех помещений авторизованного пользователя
        /// <summary> Возврат списка всех помещений авторизованного пользователя</summary>
        public List<int> ListUserRoomsNumber
        {
            get
            {
                var listRoomsNumber = new List<int>();
                var queryRoomsID = context.U_R_Room
                    .Where(c => c.userID_URR == AuthUser_DataModel._idUser)
                    .Select(c => c.id_room)
                    .ToList();

                foreach (var q in queryRoomsID)
                {
                    var queryRoomNumber = context.Rooms
                        .Where(c => c.id_room == q)
                        .Select(c => c.room_number)
                        .FirstOrDefault();

                    listRoomsNumber.Add(queryRoomNumber);
                }

                return listRoomsNumber;
            }
        }
        #endregion

        #region Возврат номера помещения заказчика авторизованного пользователя
        /// <summary>
        /// что???
        /// </summary>
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
                AuthUser_DataModel._categoryExecutors = context.User
                    .Where(c => c.id_user == AuthUser_DataModel._idUser)
                    .Select(c => c.category_executors)
                    .FirstOrDefault();

                return AuthUser_DataModel._categoryExecutors;
            }
        }
        #endregion


        #region Проверка пользовательских данных

        #region Проверка пароля авторизованного пользователя
        /// <summary>
        /// Проверка пароля авторизованного пользователя
        /// </summary>
        public string CheckUserPass
        {
            get => context.User
                    .Where(c => c.user_login == AuthUser_DataModel._userLogin)
                    .Select(c => c.user_password)
                    .FirstOrDefault();
        }
        #endregion

        #region Проверка типа аккаунта авторизованного пользователя
        /// <summary>
        /// Проверка типа аккаунта авторизованного пользователя
        /// </summary>
        public int CheckUserType
        {
            get
            {
                AuthUser_DataModel._idType = context.User
                    .Where(c => c.user_login == AuthUser_DataModel._userLogin &&
                    c.user_password == AuthUser_DataModel._userPassword)
                    .Select(c => c.id_type)
                    .FirstOrDefault();
                return AuthUser_DataModel._idType;
            }
        }
        #endregion

        #endregion
    }
}
