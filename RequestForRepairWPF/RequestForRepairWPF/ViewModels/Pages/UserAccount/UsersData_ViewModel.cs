using RequestForRepairWPF.Data.User;
using RequestForRepairWPF.Entities;
using RequestForRepairWPF.Infrastructure.Commands.Actions;
using RequestForRepairWPF.Infrastructure.Commands.Controls.Password;
using RequestForRepairWPF.Infrastructure.Commands.LoadView;
using RequestForRepairWPF.Services;
using RequestForRepairWPF.ViewModels.Base;
using RequestForRepairWPF.ViewModels.DialogWindows;
using RequestForRepairWPF.Views.DialogWindows;
using RequestForRepairWPF.Views.Pages;
using RequestForRepairWPF.Views.Pages.UserAccount;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RequestForRepairWPF.ViewModels.Pages.UserAccount
{
    public class UsersData_ViewModel : ViewModel
    {

        /// <summary> Получение ID авторизорованнного пользователя </summary>
        #region Получение ID авторизорованнного пользователя
        /// <summary> Получение ID авторизорованнного пользователя </summary>

        private static int _authorization_userID;
        public int Authorization_userID
        {
            get => _authorization_userID;
            set => Set(ref _authorization_userID, value);
        }
        #endregion

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
        public string UserPassword_SET
        {
            set => Set(ref _userPassword, value);
        }
        public string UserPassword_GET
        {
            get => _userPassword;
        }
        #endregion

        #region Повторите пароль
        private static string _repeatUserPassword;
        public string RepeatUserPassword_SET
        {
            set => Set(ref _repeatUserPassword, value);
        }
        public string RepeatUserPassword_GET
        {
            get => _repeatUserPassword;
        }
        #endregion

        #region ID Типа аккаунта

        private static int _userType_int;
        public int UserType_int
        {
            get => _userType_int;
            set => Set(ref _userType_int, value);
        }
        #endregion

        #region Тип аккаунта
        private static string _userType_string;
        public string UserType_string
        {
            get => _userType_string;
            set => Set(ref _userType_string, value);
        }
        #endregion

        #region Список типов аккаунтов 
        private static List<string> _listUsersType;
        public List<string> ListUsersType
        {
            get => _listUsersType;
            set => Set(ref _listUsersType, value);
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

        #region Список номеров помещений пользователя
        private static List<int> _listUserRoomsNumber;
        public List<int> ListUserRoomsNumber
        {
            get => _listUserRoomsNumber;
            set => Set(ref _listUserRoomsNumber, value);
        }
        #endregion

        #region Список категорий исполнителя
        private static List<string> _listCategoryExecutors;
        public List<string> ListCategoryExecutors
        {
            get => _listCategoryExecutors;
            set => Set(ref _listCategoryExecutors, value);
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

        #region Команды

        #region Команда на вход
        public ICommand LoginCommand { get; }
        public UsersData_ViewModel()
        {
            LoginCommand = new LoginCommand(this);

        }
        #endregion

        #region Команда на сохранение данных
        private ICommand _saveDataCommand;
        public ICommand SaveDataCommand
        {
            get
            {
                _saveDataCommand = new SaveDataCommand(this);
                return _saveDataCommand;
            }
        }
        #endregion

        #region Команда отмены
        private ICommand _cancelCommand;
        public ICommand CancelCommand
        {
            get
            {
                _cancelCommand = new CancelCommand(this);
                return _cancelCommand;
            }
        }
        #endregion

        #region Команда для загрузки страницы "Описание помещения"
        private ICommand _openDescriptionRoomView;
        public ICommand OpenDescriptionRoomView
        {
            get
            {
                _openDescriptionRoomView = new OpenDescriptionRoom2ViewCommand(this);
                return _openDescriptionRoomView;
            }
        }

        #endregion

        #endregion
    }
}
