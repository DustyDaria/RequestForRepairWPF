using RequestForRepairWPF.Data.User;
using RequestForRepairWPF.Infrastructure.Commands.LoadView;
using RequestForRepairWPF.ViewModels.DialogWindows;
using RequestForRepairWPF.ViewModels.Pages.UserAccount;
using RequestForRepairWPF.Views.DialogWindows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestForRepairWPF.Infrastructure.Commands.Actions
{
    /// <summary>
    /// Класс-команда для сохранения данных 
    /// </summary>
    internal class SaveDataCommand : MyHelpCommand
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
            else if (_usersData_ViewModel.UserPassword_GET != User_DataModel._userPassword
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
}
