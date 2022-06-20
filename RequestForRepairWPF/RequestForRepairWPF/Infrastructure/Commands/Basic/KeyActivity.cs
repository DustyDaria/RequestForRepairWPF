using RequestForRepairWPF.Data.User;
using RequestForRepairWPF.Services;
using RequestForRepairWPF.ViewModels.DialogWindows;
using RequestForRepairWPF.ViewModels.Pages.UserAccount;
using RequestForRepairWPF.Views.DialogWindows;
using RequestForRepairWPF.Views.Pages.UserAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestForRepairWPF.Infrastructure.Commands.Basic
{
    /// <summary>
    /// Класс с ключевыми действиями пользователя
    /// </summary>
    /// <typeparam name="T">объект VM</typeparam>
    internal class KeyActivity<T>
    {
        public T ViewModel { get; set; }

        public KeyActivity(T viewModel)
        {
            ViewModel = viewModel;
        }

        public void CancelUserAccount()
        {
            if (AuthUser_DataModel._idType == 1)
            {
                UpdateData(ViewModel);

                PageManager.MainFrame.Navigate(new UserAccountPage_View());
            }
            else if (AuthUser_DataModel._idType == 2)
            {
                UpdateData(ViewModel);

                PageManager.MainFrame.Navigate(new CustomerUserAccountPage_View());
            }
            else if (AuthUser_DataModel._idType == 3)
            {
                UpdateData(ViewModel);

                PageManager.MainFrame.Navigate(new UserAccountPage_View());
            }
        }

        private void UpdateData(T _viewModel)
        {
            if (_viewModel is UsersData_ViewModel viewModel)
            {
                viewModel.UserLastName = AuthUser_DataModel._lastName;
                viewModel.UserName = AuthUser_DataModel._name;
                viewModel.UserMiddleName = AuthUser_DataModel._middleName;
                viewModel.UserPosition = AuthUser_DataModel._position;
                viewModel.UserPhone = AuthUser_DataModel._phone;
            }
            else
                OpenDialogWindow("Ошибка!\nНе удалось провести преобразование");
        }

        private void OpenDialogWindow(string textMessage)
        {
            Dialog_ViewModel messageBox_ViewModel = new Dialog_ViewModel(textMessage);
            MessageBox_View messageBox_View = new MessageBox_View();
            messageBox_View.Show();
        }

    }
}
