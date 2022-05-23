using RequestForRepairWPF.Data.User;
using RequestForRepairWPF.Entities;
using RequestForRepairWPF.Infrastructure.Commands.Actions;
using RequestForRepairWPF.ViewModels.Base;
using RequestForRepairWPF.ViewModels.DialogWindows;
using RequestForRepairWPF.Views.DialogWindows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RequestForRepairWPF.ViewModels.Pages.UserAccount
{
    public class UserRegistrationData_ViewModel : ViewModel
    {
        public static List<int> _chooseRoomsNum = new List<int>();

        #region Логин
        private static string _userEmail;
        public string UserEmail
        {
            get => _userEmail;
            set => Set(ref _userEmail, value);
        }
        #endregion

        #region Пароль
        private static string _userPassword;
        public string UserPassword
        {
            get => _userPassword;
            set => Set(ref _userPassword, value);
        }
        #endregion

        #region Повторите пароль
        private static string _userRepeatPassword;
        public string UserRepeatPassword
        {
            get => _userRepeatPassword;
            set => Set(ref _userRepeatPassword, value);
        }
        #endregion

        #region Тип аккаунта
        private static string _userType;
        public string UserType
        {
            get => _userType;
            set => Set(ref _userType, value);
        }

        #endregion

        #region Фамилия
        private static string _userLastName;
        public string UserLastName
        {
            get => _userLastName;
            set => Set(ref _userLastName, value);
        }
        #endregion

        #region Имя
        private static string _userName;
        public string UserName
        {
            get => _userName;
            set => Set(ref _userName, value);
        }
        #endregion

        #region Отчество
        private static string _userMiddleName;
        public string UserMiddleName
        {
            get => _userMiddleName;
            set => Set(ref _userMiddleName, value);
        }
        #endregion

        #region Должность
        private static string _userPosition;
        public string UserPosition
        {
            get => _userPosition;
            set => Set(ref _userPosition, value);
        }
        #endregion

        #region Телефон
        private static string _userPhone;
        public string UserPhone
        {
            get => _userPhone;
            set => Set(ref _userPhone, value);
        }
        #endregion

        #region Номер помещения
        private static int _userRoomNumber;
        public int UserRoomNumber
        {
            get => _userRoomNumber;
            set => Set(ref _userRoomNumber, value);
        }
        #endregion

        #region Список выбранных помещений для регистрации пользователя
        private static List<int> _listChooseRooms;
        private static string _list;
        public string ListToString
        {
            get
            {
                return _list;
            }
            set
            {
                Set(ref _list, _list + ", " + value);
            }

            //foreach(var item in _listChooseRooms)
            //{
            //    list = _listChooseRooms[item] + ", ";
            //}
            //return list;
        }
        public List<int> ListChooseRooms
        {
            get => _listChooseRooms;
            //get => listToString();
            set
            {
                _listChooseRooms = value;
                OnPropertyChanged("ListChooseRooms");
            }

            
            //set => Set(ref _listChooseRooms, value);
            //set
            //{
            //    _listChooseRooms.Add(new Rooms { room_number = Convert.ToInt32(value) });
            //    OnPropertyChanged("ListChooseRooms");
            //}
        }
        #endregion

        #region Категория исполнителя
        private static string _userCategoryExecutors;
        public string UserCategoryExecutors
        {
            get => _userCategoryExecutors;
            set => Set(ref _userCategoryExecutors, value);
        }
        #endregion

        #region Список типов аккаунтов пользователей
        private List<string> _listUsersType;
        public List<string> ListUsersType
        {
            get => _listUsersType;
            set => Set(ref _listUsersType, value);
        }
        #endregion

        #region Список категорий исполнителей
        private List<string> _listExecutorsType;
        public List<string> ListExecutorsType
        {
            get => _listExecutorsType;
            set => Set(ref _listExecutorsType, value);
        }
        #endregion

        #region Список всех помещений
        private List<int> _listLibertyRoomsNumber;
        public List<int> ListLibertyRoomsNumber
        {
            get => _listLibertyRoomsNumber;
            set => Set(ref _listLibertyRoomsNumber, value);
        }
        #endregion 

        #region Команда на загрузку данных
        private ICommand _loadRegData;
        public ICommand LoadRegData
        {
            get
            {
                _loadRegData = new LoadRegDataCommand(this);
                return _loadRegData;
            }
        }
        #endregion

        #region Команда на сохранение пользовательских регистрационных данных
        private ICommand _regUserData;
        public ICommand RegUserDataCommand
        {
            get
            {
                _regUserData = new RegUserDataCommand(this);
                return _regUserData;
            }
        }
        #endregion

        #region Команда на отмену регистрации
        private ICommand _cancelUserReg;
        public ICommand CancelUserRegCommand
        {
            get
            {
                _cancelUserReg = new CancelUserRegCommand(this);
                return _cancelUserReg;
            }
        }
        #endregion

        #region Команда на добавление кабинета
        private ICommand _addRoomNumberCommand;
        public ICommand AddRoomNumberCommand
        {
            get
            {
                _addRoomNumberCommand = new AddRoomNumberCommand(this);
                return _addRoomNumberCommand;
            }
        }
        #endregion

        #region Команда на удаление выбранных кабинетов 
        private ICommand _deleteRoomsNumberCommand;
        public ICommand DeleteRoomsNumberCommand
        {
            get
            {
                _deleteRoomsNumberCommand = new DeleteRoomsNumberCommand(this);
                return _deleteRoomsNumberCommand;
            }
        }
        #endregion 
    }
}
