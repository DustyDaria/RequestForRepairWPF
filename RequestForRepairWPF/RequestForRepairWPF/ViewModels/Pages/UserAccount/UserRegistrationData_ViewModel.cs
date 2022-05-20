using RequestForRepairWPF.Data.User;
using RequestForRepairWPF.Entities;
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

    #region Класс-команда для добавления помещения при регистрации пользователя
    internal class AddRoomNumberCommand : MyRegCommand
    {
       
        public AddRoomNumberCommand(UserRegistrationData_ViewModel userRegData_ViewModel) : base(userRegData_ViewModel) { }
        public override bool CanExecute(object parameter) => true;
        public override void Execute(object parameter) => AddRoomsNumber();
        private void AddRoomsNumber()
        {
            //Rooms room = new Rooms();
            //room.room_number = _userRegData_ViewModel.UserRoomNumber;
            UserRegistrationData_ViewModel._chooseRoomsNum.Add(_userRegData_ViewModel.UserRoomNumber);
            //_chooseRoomsNum.Add(room.room_number);

            //_userRegData_ViewModel.ListChooseRooms.Add(_userRegData_ViewModel.UserRoomNumber);
            _userRegData_ViewModel.ListChooseRooms = UserRegistrationData_ViewModel._chooseRoomsNum;
            _userRegData_ViewModel.ListToString = Convert.ToString(_userRegData_ViewModel.ListChooseRooms);
        }
    }
    #endregion

    #region Класс-команда для удаления выбранных помещений
    internal class DeleteRoomsNumberCommand : MyRegCommand
    {
        public DeleteRoomsNumberCommand(UserRegistrationData_ViewModel userRegData_ViewModel) : base(userRegData_ViewModel) { }
        public override bool CanExecute(object parameter) => true;
        public override void Execute(object parameter) => _userRegData_ViewModel.ListChooseRooms.Clear();
    }
    #endregion

    #region Класс-команда для отмены регистрации пользователя
    internal class CancelUserRegCommand : MyRegCommand
    {
        public CancelUserRegCommand(UserRegistrationData_ViewModel userRegData_ViewModel) : base(userRegData_ViewModel) { }
        public override bool CanExecute(object parameter) => true;
        public override void Execute(object parameter) => CleanUsersData();

        private void CleanUsersData()
        {
            _userRegData_ViewModel.UserEmail = null;
            _userRegData_ViewModel.UserPassword = null;
            _userRegData_ViewModel.UserRepeatPassword = null;
            _userRegData_ViewModel.UserLastName = null;
            _userRegData_ViewModel.UserName = null;
            _userRegData_ViewModel.UserMiddleName = null;
            _userRegData_ViewModel.UserPosition = null;
            _userRegData_ViewModel.UserPhone = null;
            _userRegData_ViewModel.UserType = null;
            _userRegData_ViewModel.UserCategoryExecutors = null;
            _userRegData_ViewModel.UserRoomNumber = 0;

        }
    }
    #endregion

    #region Класс-команда загрузки необходимых данных для регистрации
    internal class LoadRegDataCommand : MyRegCommand
    {
        public LoadRegDataCommand(UserRegistrationData_ViewModel userRegData_ViewModel) : base(userRegData_ViewModel) { }
        public override bool CanExecute(object parameter) => true;
        public override void Execute(object parameter) => LoadRegData();

        private void LoadRegData()
        {
            _userRegData_ViewModel.ListUsersType = Data.User.TypeOfAccount_DataModel.AllType;
            _userRegData_ViewModel.ListLibertyRoomsNumber = Data.Room.Rooms_DataModel.AllLibertyRoomsNumber;
            _userRegData_ViewModel.ListExecutorsType = Data.User.User_DataModel.AllCategoryExecutors;
        }
    }
    #endregion

    #region Класс-команда для сохранения пользовательских регистрационных данных
    internal class RegUserDataCommand : MyRegCommand
    {
        private Entities.DB_RequestForRepairEntities context = new Entities.DB_RequestForRepairEntities();

        public RegUserDataCommand(UserRegistrationData_ViewModel userRegData_ViewModel) : base(userRegData_ViewModel) { }
        public override bool CanExecute(object parameter) => true;
        public override void Execute(object parameter) => SaveClick();
        private void SaveClick()
        {
            #region Получение зарегистрированных администраторов (для проверки)
            List<int> admins = new List<int>();
            var queryAdmin = from adm in context.User
                             where adm.id_type == 1
                             select adm.id_user;
            foreach (int a in queryAdmin)
                admins.Add(a);
            #endregion

            #region  Получение логина зарегистрированного пользователя по совпадению с введенным (для проверки)
            string userLogin = _userRegData_ViewModel.UserEmail;
            string checkedUserLogin = (from u in context.User
                                       where u.user_login == userLogin 
                                       select u.user_login)
                                       .FirstOrDefault();
            #endregion

            if (_userRegData_ViewModel.UserType == "Системный администратор" && admins.Count >= 3)
            {
                OpenDialogWindow("Вы не можете зарегистрировать нового пользователя с типом аккаунта \"Системный администратор\"!\nМаксимально возможное количество пользователей с типом аккаунта \"Системный администратор\" не должно превышать 3");
            }
            else if (_userRegData_ViewModel.UserType == "Системный администратор")
            {
                if (_userRegData_ViewModel.UserLastName == null || _userRegData_ViewModel.UserLastName == string.Empty)
                {
                    OpenDialogWindow("Пожалуйста, введите фамилию пользователя!");
                }
                else if (_userRegData_ViewModel.UserName == null || _userRegData_ViewModel.UserName == string.Empty)
                {
                    OpenDialogWindow("Пожалуйста, введите имя пользователя!");
                }
                else if (_userRegData_ViewModel.UserPosition == null || _userRegData_ViewModel.UserPosition == string.Empty)
                {
                    OpenDialogWindow("Пожалуйста, введите должность пользователя!");
                }
                else if (_userRegData_ViewModel.UserPhone == null || _userRegData_ViewModel.UserPhone == string.Empty)
                {
                    OpenDialogWindow("Пожалуйста, введите телефон пользователя!");
                }
                else if (_userRegData_ViewModel.UserEmail == null || _userRegData_ViewModel.UserEmail == string.Empty)
                {
                    OpenDialogWindow("Пожалуйста, введите логин пользователя!");
                }
                else if (_userRegData_ViewModel.UserEmail == checkedUserLogin)
                {
                    OpenDialogWindow("Пожалуйста, введите другой логин пользователя!\nПользователь с таким логином уже зарегистрирован!");
                }
                else if (_userRegData_ViewModel.UserPassword == null || _userRegData_ViewModel.UserPassword == string.Empty)
                {
                    OpenDialogWindow("Пожалуйста, введите пароль пользователя!");
                }
                else if (_userRegData_ViewModel.UserRepeatPassword == null
                    || _userRegData_ViewModel.UserPassword != _userRegData_ViewModel.UserRepeatPassword)
                {
                    OpenDialogWindow("Введенные пароли не совпадают!");
                }
                else
                {
                    SaveUsersData_Admin(_userRegData_ViewModel.UserName, _userRegData_ViewModel.UserLastName, _userRegData_ViewModel.UserMiddleName,
                        _userRegData_ViewModel.UserPosition, _userRegData_ViewModel.UserPhone, _userRegData_ViewModel.UserEmail,
                        _userRegData_ViewModel.UserPassword, 1);
                    CleanUsersData();
                }
            }
            else if (_userRegData_ViewModel.UserType == "Заказчик")
            {
                if (_userRegData_ViewModel.UserLastName == null || _userRegData_ViewModel.UserLastName == string.Empty)
                {
                    OpenDialogWindow("Пожалуйста, введите фамилию пользователя!");
                }
                else if (_userRegData_ViewModel.UserName == null || _userRegData_ViewModel.UserName == string.Empty)
                {
                    OpenDialogWindow("Пожалуйста, введите имя пользователя!");
                }
                else if (_userRegData_ViewModel.UserPosition == null || _userRegData_ViewModel.UserPosition == string.Empty)
                {
                    OpenDialogWindow("Пожалуйста, введите должность пользователя!");
                }
                else if (_userRegData_ViewModel.UserPhone == null || _userRegData_ViewModel.UserPhone == string.Empty)
                {
                    OpenDialogWindow("Пожалуйста, введите телефон пользователя!");
                }
                else if (_userRegData_ViewModel.UserEmail == null || _userRegData_ViewModel.UserEmail == string.Empty)
                {
                    OpenDialogWindow("Пожалуйста, введите логин пользователя!");
                }
                else if (_userRegData_ViewModel.UserEmail == checkedUserLogin)
                {
                    OpenDialogWindow("Пожалуйста, введите другой логин пользователя!\nПользователь с таким логином уже зарегистрирован!");
                }
                else if (_userRegData_ViewModel.UserPassword == null || _userRegData_ViewModel.UserPassword == string.Empty)
                {
                    OpenDialogWindow("Пожалуйста, введите пароль пользователя!");
                }
                else if (_userRegData_ViewModel.UserRepeatPassword == null
                    || _userRegData_ViewModel.UserPassword != _userRegData_ViewModel.UserRepeatPassword)
                {
                    OpenDialogWindow("Введенные пароли не совпадают!");
                }
                else if (_userRegData_ViewModel.UserRoomNumber == 0)
                {

                }
                else
                {
                    //////////////////////// СОХРАНЕНИЕ
                }
            }
            else if (_userRegData_ViewModel.UserType == "Исполнитель")
            {
                if (_userRegData_ViewModel.UserLastName == null || _userRegData_ViewModel.UserLastName == string.Empty)
                {
                    OpenDialogWindow("Пожалуйста, введите фамилию пользователя!");
                }
                else if (_userRegData_ViewModel.UserName == null || _userRegData_ViewModel.UserName == string.Empty)
                {
                    OpenDialogWindow("Пожалуйста, введите имя пользователя!");
                }
                else if (_userRegData_ViewModel.UserPosition == null || _userRegData_ViewModel.UserPosition == string.Empty)
                {
                    OpenDialogWindow("Пожалуйста, введите должность пользователя!");
                }
                else if (_userRegData_ViewModel.UserPhone == null || _userRegData_ViewModel.UserPhone == string.Empty)
                {
                    OpenDialogWindow("Пожалуйста, введите телефон пользователя!");
                }
                else if (_userRegData_ViewModel.UserEmail == null || _userRegData_ViewModel.UserEmail == string.Empty)
                {
                    OpenDialogWindow("Пожалуйста, введите логин пользователя!");
                }
                else if (_userRegData_ViewModel.UserEmail == checkedUserLogin)
                {
                    OpenDialogWindow("Пожалуйста, введите другой логин пользователя!\nПользователь с таким логином уже зарегистрирован!");
                }
                else if (_userRegData_ViewModel.UserPassword == null || _userRegData_ViewModel.UserPassword == string.Empty)
                {
                    OpenDialogWindow("Пожалуйста, введите пароль пользователя!");
                }
                else if (_userRegData_ViewModel.UserRepeatPassword == null
                    || _userRegData_ViewModel.UserPassword != _userRegData_ViewModel.UserRepeatPassword)
                {
                    OpenDialogWindow("Введенные пароли не совпадают!");
                }
                else if (_userRegData_ViewModel.UserCategoryExecutors == null)
                {
                    OpenDialogWindow("Пожалуйста, выберите категорию исполнителя!");
                }
                else
                {
                    SaveUsersData_Executor(_userRegData_ViewModel.UserName, _userRegData_ViewModel.UserLastName, _userRegData_ViewModel.UserMiddleName,
                        _userRegData_ViewModel.UserPosition, _userRegData_ViewModel.UserPhone, _userRegData_ViewModel.UserEmail,
                        _userRegData_ViewModel.UserPassword, 3, _userRegData_ViewModel.UserCategoryExecutors);
                    CleanUsersData();
                }
            }
            else
            {
                OpenDialogWindow("Вам необходимо выбрать тип аккаунта!");
            }

        }

        private void SaveUsersData_Admin(string _name, string _lastName, string _middleName, string _position, string _phone, string _email, string _password, int _typeOfAccount)
        {
            User user = new User
            {
                id_type = _typeOfAccount,
                user_login = _email,
                user_password = _password,
                last_name = _lastName,
                name = _name,
                middle_name = _middleName,
                position = _position,
                phone = _phone
            };
            context.User.Add(user);
            context.SaveChanges();

            OpenDialogWindow("Системный администратор был успешно зарегистрирован!");
        }
        private void SaveUsersData_Executor(string _name, string _lastName, string _middleName, string _position, string _phone, string _email, string _password, int _typeOfAccount, string _category_executor)
        {
            User user = new User
            {
                id_type = _typeOfAccount,
                user_login = _email,
                user_password = _password,
                last_name = _lastName,
                name = _name,
                middle_name = _middleName,
                position = _position,
                phone = _phone,
                category_executors = _category_executor
            };
            context.User.Add(user);
            context.SaveChanges();

            OpenDialogWindow("Исполнитель был успешно зарегистрирован!");
        }

        private void CleanUsersData()
        {
            _userRegData_ViewModel.UserEmail = null;
            _userRegData_ViewModel.UserPassword = null;
            _userRegData_ViewModel.UserRepeatPassword = null;
            _userRegData_ViewModel.UserLastName = null;
            _userRegData_ViewModel.UserName = null;
            _userRegData_ViewModel.UserMiddleName = null;
            _userRegData_ViewModel.UserPosition = null;
            _userRegData_ViewModel.UserPhone = null;
            _userRegData_ViewModel.UserType = null;
            _userRegData_ViewModel.UserCategoryExecutors = null;
            _userRegData_ViewModel.UserRoomNumber = 0;
            
        }

        private void OpenDialogWindow(string textMessage)
        {
            Dialog_ViewModel messageBox_ViewModel = new Dialog_ViewModel(textMessage);
            MessageBox_View messageBox_View = new MessageBox_View();
            messageBox_View.Show();
        }
    }
    #endregion

    #region Вспомогательный класс для команд
    abstract class MyRegCommand : ICommand
    {
        protected UserRegistrationData_ViewModel _userRegData_ViewModel;
        public MyRegCommand(UserRegistrationData_ViewModel userRegData_ViewModel)
        {
            _userRegData_ViewModel = userRegData_ViewModel;
        }
        public event EventHandler CanExecuteChanged;
        public abstract bool CanExecute(object parameter);
        public abstract void Execute(object parameter);
    }

    #endregion
}
