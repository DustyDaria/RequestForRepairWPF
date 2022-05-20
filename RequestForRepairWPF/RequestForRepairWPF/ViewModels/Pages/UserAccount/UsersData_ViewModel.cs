using RequestForRepairWPF.Data.User;
using RequestForRepairWPF.Entities;
using RequestForRepairWPF.Infrastructure.Commands.Controls.Password;
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
                _openDescriptionRoomView = new OpenDescriptionRoomViewCommand(this);
                return _openDescriptionRoomView;
            }
        }

        #endregion

        #endregion
    }

    #region Класс-команда отмены
    internal class CancelCommand : MyCommand
    {
        public CancelCommand(UsersData_ViewModel usersData_ViewModel) : base(usersData_ViewModel) { }
        public override bool CanExecute(object parameter) => true;
        public override void Execute(object parameter) => Cancel();

        private void Cancel()
        {
            if (User_DataModel._idType == 1)
            {
                UpdateData();

                PageManager.MainFrame.Navigate(new UserAccountPage_View());
            }
            else if (User_DataModel._idType == 2)
            {
                UpdateData();

                PageManager.MainFrame.Navigate(new CustomerUserAccountPage_View());
            }
            else if (User_DataModel._idType == 3)
            {
                UpdateData(); 

                PageManager.MainFrame.Navigate(new UserAccountPage_View());
            }
        }

        private void UpdateData()
        {
            _usersData_ViewModel.UserLastName = User_DataModel._lastName;
            _usersData_ViewModel.UserName = User_DataModel._name;
            _usersData_ViewModel.UserMiddleName = User_DataModel._middleName;
            _usersData_ViewModel.UserPosition = User_DataModel._position;
            _usersData_ViewModel.UserPhone = User_DataModel._phone;
        }
    }
    #endregion

    #region Класс-команда для сохранения данных 
    internal class SaveDataCommand : MyCommand
    {
        private Entities.DB_RequestForRepairEntities context = new Entities.DB_RequestForRepairEntities();

        public SaveDataCommand(UsersData_ViewModel usersData_ViewModel) : base(usersData_ViewModel) { }
        public override bool CanExecute(object parameter) => true;
        public override void Execute(object parameter) => SaveData();

        private void SaveData()
        {
            #region  Получение логина зарегистрированного пользователя по совпадению с введенным (для проверки)
            string userLogin = _usersData_ViewModel.UserEmail;
            string checkedUserLogin = (from u in context.User
                                       where u.user_login == userLogin
                                       select u.user_login)
                                       .FirstOrDefault();
            #endregion

            if (_usersData_ViewModel.UserLastName == null || _usersData_ViewModel.UserLastName == string.Empty)
            {
                OpenDialogWindow("Пожалуйста, введите фамилию пользователя!");
            }
            else if (_usersData_ViewModel.UserName == null || _usersData_ViewModel.UserName == string.Empty)
            {
                OpenDialogWindow("Пожалуйста, введите имя пользователя!");
            }
            else if (_usersData_ViewModel.UserPosition == null || _usersData_ViewModel.UserPosition == string.Empty)
            {
                OpenDialogWindow("Пожалуйста, введите должность пользователя!");
            }
            else if (_usersData_ViewModel.UserPhone == null || _usersData_ViewModel.UserPhone == string.Empty)
            {
                OpenDialogWindow("Пожалуйста, введите телефон пользователя!");
            }
            else if (_usersData_ViewModel.UserPassword_GET == null || _usersData_ViewModel.UserPassword_GET == string.Empty)
            {
                OpenDialogWindow("Пожалуйста, введите пароль пользователя!");
            }
            else if (_usersData_ViewModel.RepeatUserPassword_GET == null
                || _usersData_ViewModel.UserPassword_GET != _usersData_ViewModel.RepeatUserPassword_GET)
            {
                OpenDialogWindow("Введенные пароли не совпадают!");
            }
            else if(_usersData_ViewModel.UserPassword_GET != User_DataModel._userPassword 
                || _usersData_ViewModel.RepeatUserPassword_GET != User_DataModel._userPassword)
            {
                OpenDialogWindow("Пароль введен неверно!\nПожалуйста, введите пароль от Вашей учетной записи");
            }
            else
            {
                SaveUsersData(_usersData_ViewModel.UserName, _usersData_ViewModel.UserLastName, _usersData_ViewModel.UserMiddleName, 
                    _usersData_ViewModel.UserPosition, _usersData_ViewModel.UserPhone, _usersData_ViewModel.UserEmail, _usersData_ViewModel.UserPassword_GET);
                
            }
        }

        private void SaveUsersData(string _name, string _lastName, string _middleName, string _position, string _phone, string _email, string _password)
        {
            var user = context.User
                 .Where(c => c.id_user == User_DataModel._idUser)
                 .FirstOrDefault();
            user.name = _name;
            user.last_name = _lastName;
            user.middle_name = _middleName;
            user.position = _position;
            user.phone = _phone;
            user.user_login = _email;
            user.user_password = _password;

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

            OpenDialogWindow("Ваши данные были успешно изменены!");
        }


        private void OpenDialogWindow(string textMessage)
        {
            Dialog_ViewModel messageBox_ViewModel = new Dialog_ViewModel(textMessage);
            MessageBox_View messageBox_View = new MessageBox_View();
            messageBox_View.Show();
        }
    }
    #endregion

    #region Класс-команда для загрузки страницы "Описание помещения"
    internal class OpenDescriptionRoomViewCommand : MyCommand
    {
        public OpenDescriptionRoomViewCommand(UsersData_ViewModel usersData_ViewModel) : base(usersData_ViewModel) { }
        public override bool CanExecute(object parameter) => true;
        public override void Execute(object parameter) => LoadPage();

        private void LoadPage()
        {
            DescriptionRoom_ViewModel descriptionRoom_ViewModel = new DescriptionRoom_ViewModel();
            descriptionRoom_ViewModel.RoomNumber = Convert.ToString(_usersData_ViewModel.UserRoomNumber);
            PageManager.MainFrame.Navigate(new DescriptionRoomPage_View());

        }
}
    #endregion

    #region Вспомогательный класс для команд
    abstract class MyCommand : ICommand
    {
        protected UsersData_ViewModel _usersData_ViewModel;

        public MyCommand(UsersData_ViewModel usersData_ViewModel)
        {
            _usersData_ViewModel = usersData_ViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public abstract bool CanExecute(object parameter);

        public abstract void Execute(object parameter);
    }
    #endregion
}
