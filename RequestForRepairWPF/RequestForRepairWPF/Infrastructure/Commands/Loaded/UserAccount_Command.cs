using RequestForRepairWPF.Infrastructure.Commands.Base;
using RequestForRepairWPF.Models.Windows.UserAccount;
using RequestForRepairWPF.ViewModels.Windows;
using RequestForRepairWPF.ViewModels.Windows.UserAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestForRepairWPF.Infrastructure.Commands.Loaded
{
    public class UserAccount_Command : Command
    {
        //UserAccount_ViewModel _viewModel;
        //Authorization_ViewModel authorization_ViewModel = new Authorization_ViewModel();
        //UserAccount_Model _model = new UserAccount_Model();

        private string _userEmail;
        private string _userPassword;
        private int _userID;

        //public UserAccount_Command(UserAccount_ViewModel viewModel)
        //{
        //    _viewModel = viewModel;
        //}

        public override bool CanExecute(object parameter) => true;
        public override void Execute(object parameter) => UserDataLoad();

        public void UserDataLoad()
        {
           // _userID = _model.UserID;
            //_userEmail = _model.UserLogin;
            //_userEmail = authorization_ViewModel.UserEmail;
            //_userPassword = _viewModel.UserPassword;
            //
            //_model = new UserAccount_Model(_userEmail, _userPassword);
            //_userID = _model.UserID;
            ////_model.UserID = _viewModel.Authorization_userID;
            //_viewModel.UserLastName = _model.UserLastName;
            //_viewModel.UserName = _model.UserName;
        }

    }
}
