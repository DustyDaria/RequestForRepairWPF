using RequestForRepairWPF.Data.User;
using RequestForRepairWPF.Infrastructure.Commands.Base;
using RequestForRepairWPF.Models.Pages.UserAccount;
using RequestForRepairWPF.Services;
using RequestForRepairWPF.ViewModels.DialogWindows;
using RequestForRepairWPF.ViewModels.Pages.UserAccount;
using RequestForRepairWPF.Views.DialogWindows;
using RequestForRepairWPF.Views.Pages.UserAccount;
using RequestForRepairWPF.Views.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace RequestForRepairWPF.Infrastructure.Commands.Controls.Password
{
    public class LoginCommand : Command
    {
        private readonly UsersData_ViewModel _viewModel;
        private UsersData_Model _model = new UsersData_Model();

        public LoginCommand(UsersData_ViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public override bool CanExecute(object parameter) => true;
        public override void Execute(object parameter) => LogIn();

        private void LogIn()
        {
            AuthUser_DataModel._userLogin = _viewModel.UserEmail;
            AuthUser_DataModel._userPassword = _viewModel.UserPassword_GET;

            if (AuthUser_DataModel._userLogin == string.Empty 
                || AuthUser_DataModel._userLogin == null)
            {
                OpenDialogWindow("Пожалуйста, введите Ваш логин!");
            }
            else if (AuthUser_DataModel._userPassword == string.Empty 
                || AuthUser_DataModel._userPassword == null)
            {
                OpenDialogWindow("Пожалуйста, введите Ваш пароль!");
            }
            else
            {
                if(_model.CheckUserPass == AuthUser_DataModel._userPassword 
                    && _model.CheckUserType == 1)
                {
                    AddUserDataToViewModel();
                    PageManager.MainFrame.Navigate(new UserAccountPage_View());
                }
                else if(_model.CheckUserPass == AuthUser_DataModel._userPassword 
                    && _model.CheckUserType == 2)
                {
                    AddUserDataToViewModel();
                    PageManager.MainFrame.Navigate(new CustomerUserAccountPage_View());
                }
                else if(_model.CheckUserPass == AuthUser_DataModel._userPassword 
                    && _model.CheckUserType == 3)
                {
                    AddUserDataToViewModel();
                    PageManager.MainFrame.Navigate(new UserAccountPage_View());
                }
                else
                {
                    OpenDialogWindow("Вы неправильно ввели учетные данные! Пожалуйста, попробуйте еще раз.");
                }
            }
        }

        private void OpenDialogWindow(string textMessage)
        {
            Dialog_ViewModel messageBox_ViewModel = new Dialog_ViewModel(textMessage);
            MessageBox_View messageBox_View = new MessageBox_View();
            messageBox_View.Show();
        }

        private void AddUserDataToViewModel()
        {
            _viewModel.UserEmail = AuthUser_DataModel._userLogin;
            _viewModel.UserPassword_SET = AuthUser_DataModel._userPassword;
            _viewModel.Authorization_userID = _model.ID;
            _viewModel.UserType_int = _model.TypeOfAccount_get;
            _viewModel.UserLastName = _model.LastName;
            _viewModel.UserName = _model.Name;
            _viewModel.UserMiddleName = _model.MiddleName;
            _viewModel.UserPosition = _model.Position;
            _viewModel.UserPhone = _model.Phone;
            _viewModel.ListCategoryExecutors = _model.ListCategoryExecutors;
            _viewModel.UserCategoryExecutors = _model.CategoryExecutors;
            _viewModel.ListUserRoomsNumber = _model.ListUserRoomsNumber;

            switch(AuthUser_DataModel._idType)
            {
                case 1:
                    _viewModel.UserType_string = "Администратор";
                    break;
                case 2:
                    _viewModel.UserType_string = "Заказчик";
                    break;
                case 3:
                    _viewModel.UserType_string = "Исполнитель";
                    break;
            }
            
            _viewModel.ListUsersType = _model.ListUsersType; 
        }
    }
}
