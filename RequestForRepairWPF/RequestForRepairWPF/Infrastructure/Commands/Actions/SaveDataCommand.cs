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
            var checkedUserLogin = context.User
                .Where(c => c.user_login == _usersData_ViewModel.UserEmail)
                .Select(c => c.user_login)
                .FirstOrDefault();
            #endregion
            
            if (String.IsNullOrEmpty(_usersData_ViewModel.UserLastName))
            {
                OpenDialogWindow("Пожалуйста, введите фамилию пользователя!");
            }
            else if (String.IsNullOrEmpty(_usersData_ViewModel.UserName))
            {
                OpenDialogWindow("Пожалуйста, введите имя пользователя!");
            }
            else if (String.IsNullOrEmpty(_usersData_ViewModel.UserPosition))
            {
                OpenDialogWindow("Пожалуйста, введите должность пользователя!");
            }
            else if (String.IsNullOrEmpty(_usersData_ViewModel.UserPhone))
            {
                OpenDialogWindow("Пожалуйста, введите телефон пользователя!");
            }
            else if (_usersData_ViewModel.UserPhone.Contains("_"))
            {
                OpenDialogWindow("Пожалуйста, заполните корректно телефон пользователя!");
            }
            else if (String.IsNullOrEmpty(_usersData_ViewModel.UserPassword_GET))
            {
                OpenDialogWindow("Пожалуйста, введите пароль пользователя!");
            }
            else if (String.IsNullOrEmpty(_usersData_ViewModel.RepeatUserPassword_GET)
                || _usersData_ViewModel.UserPassword_GET != _usersData_ViewModel.RepeatUserPassword_GET)
            {
                OpenDialogWindow("Введенные пароли не совпадают!");
            }
            else if (_usersData_ViewModel.UserPassword_GET != AuthUser_DataModel._userPassword
                || _usersData_ViewModel.RepeatUserPassword_GET != AuthUser_DataModel._userPassword)
            {
                OpenDialogWindow("Пароль введен неверно!\nПожалуйста, введите пароль от Вашей учетной записи");
            }
            else
            {
                SaveUsersData();
            }
        }

        private void SaveUsersData()
        {
            var user = context.User
                 .Where(c => c.id_user == AuthUser_DataModel._idUser)
                 .FirstOrDefault();
            user.name = _usersData_ViewModel.UserName;
            user.last_name = _usersData_ViewModel.UserLastName;
            user.middle_name = _usersData_ViewModel.UserMiddleName;
            user.position = _usersData_ViewModel.UserPosition;
            user.phone = _usersData_ViewModel.UserPhone;
            user.user_login = _usersData_ViewModel.UserEmail;
            user.user_password = _usersData_ViewModel.UserPassword_GET;

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
                        string message = string.Format("{0}:{1}", validationErrors.Entry.Entity.ToString(), 
                            validationError.ErrorMessage);
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
