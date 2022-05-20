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
        
        public string _email, _password;
        public string _name, _lastName, _middleName;
        public string _position, _phone, _categoryExecutors;
        public int _idUser, _roomNumber, _idType;
        public List<string> _listUsersType;
        public List<int> _listRoomsNumber;
        public List<int> _listLibertyRoomsNumber;
        public List<int> _listUserRoomsNumber;
        public List<string> _listCategoryExecutors;

        public LoginCommand(UsersData_ViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public override bool CanExecute(object parameter) => true;
        public override void Execute(object parameter) => LogIn();

        private void LogIn()
        {
            _email = _viewModel.UserEmail;
            _password = _viewModel.UserPassword_GET;

            if (_email == string.Empty || _email == null)
            {
                OpenDialogWindow("Пожалуйста, введите Ваш логин!");
            }
            else if (_password == string.Empty || _password == null)
            {
                OpenDialogWindow("Пожалуйста, введите Ваш пароль!");
            }
            else
            {
                UsersData_Model _model = new UsersData_Model(_email, _password);

                if(_model.CheckUserPass == _password && _model.CheckUserType == 1)
                {
                    AddUserDataToModel(_model);
                    AddUserDataToViewModel();
                    PageManager.MainFrame.Navigate(new UserAccountPage_View());
                }
                else if(_model.CheckUserPass == _password && _model.CheckUserType == 2)
                {
                    AddUserDataToModel(_model);
                    AddUserDataToViewModel();
                    PageManager.MainFrame.Navigate(new CustomerUserAccountPage_View());
                }
                else if(_model.CheckUserPass == _password && _model.CheckUserType == 3)
                {
                    AddUserDataToModel(_model);
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

        private void AddUserDataToModel(UsersData_Model model)
        {
            _idUser = model.ID;
            _idType = model.CheckUserType;
            _lastName = model.LastName;
            _name = model.Name;
            _middleName = model.MiddleName;
            _position = model.Position;
            _phone = model.Phone;
            _categoryExecutors = model.CategoryExecutors;
            _roomNumber = model.RoomNumber;

            _listUsersType = model.ListUsersType;
            _listRoomsNumber = model.ListAllRommsNumber;
            _listLibertyRoomsNumber = model.ListLiberyRoomsNumber;
            _listUserRoomsNumber = model.ListUserRoomsNumber;
            _listCategoryExecutors = model.ListCategoryExecutors;
        }

        private void AddUserDataToViewModel()
        {
            _viewModel.UserEmail = _email;
            _viewModel.UserPassword_SET = _password;
            _viewModel.Authorization_userID = _idUser;
            _viewModel.UserType_int = _idType;
            _viewModel.UserLastName = _lastName;
            _viewModel.UserName = _name;
            _viewModel.UserMiddleName = _middleName;
            _viewModel.UserPosition = _position;
            _viewModel.UserPhone = _phone;
            _viewModel.ListCategoryExecutors = _listCategoryExecutors;
            _viewModel.UserCategoryExecutors = _categoryExecutors;
            _viewModel.ListUserRoomsNumber = _listUserRoomsNumber;

            if(_idType == 1)
            {
                _viewModel.UserType_string = "Системный администратор";
            }
            else if(_idType == 2)
            {
                _viewModel.UserType_string = "Заказчик";
            }
            else if(_idType == 3)
            {
                _viewModel.UserType_string = "Исполнитель";
            }
            _viewModel.ListUsersType = _listUsersType;

        }
    }

   
}
