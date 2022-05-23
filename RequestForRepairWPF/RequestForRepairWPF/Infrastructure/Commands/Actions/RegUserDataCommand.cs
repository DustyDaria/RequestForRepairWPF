using RequestForRepairWPF.Entities;
using RequestForRepairWPF.ViewModels.Pages.UserAccount;
using RequestForRepairWPF.ViewModels.DialogWindows;
using RequestForRepairWPF.Views.DialogWindows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestForRepairWPF.Infrastructure.Commands.Actions
{
    /// <summary>
    /// Класс-команда для сохранения пользовательских регистрационных данных
    /// </summary>
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

            if (_userRegData_ViewModel.UserType == "Администратор" && admins.Count >= 3)
            {
                OpenDialogWindow("Вы не можете зарегистрировать нового пользователя с типом аккаунта \"Администратор\"!\nМаксимально возможное количество пользователей с типом аккаунта \"Администратор\" не должно превышать 3");
            }
            else if (_userRegData_ViewModel.UserType == "Администратор")
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

            OpenDialogWindow("Администратор был успешно зарегистрирован!");
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
}
