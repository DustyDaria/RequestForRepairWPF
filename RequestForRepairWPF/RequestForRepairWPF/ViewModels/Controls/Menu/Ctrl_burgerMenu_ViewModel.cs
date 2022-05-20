using RequestForRepairWPF.Data;
using RequestForRepairWPF.Data.User;
using RequestForRepairWPF.Infrastructure.Commands.Controls.Menu;
using RequestForRepairWPF.Models.Controls.Menu;
using RequestForRepairWPF.Services;
using RequestForRepairWPF.ViewModels.Base;
using RequestForRepairWPF.ViewModels.Pages.UserAccount;
using RequestForRepairWPF.Views.Pages;
using RequestForRepairWPF.Views.Pages.Request;
using RequestForRepairWPF.Views.Pages.UserAccount;
using RequestForRepairWPF.Views.Pages.ViewingEditDelete_UsersData;
using RequestForRepairWPF.Views.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace RequestForRepairWPF.ViewModels.Controls.Menu
{
    public class Ctrl_burgerMenu_ViewModel : ViewModel
    {
        #region Команда на загрузкку элементов меню
        public ICommand MenuLoad_Command { get; }
        public Ctrl_burgerMenu_ViewModel()
        {
            MenuLoad_Command = new MenuLoad_Command(this);
        }
        #endregion

        /// <summary> Инициализация элементов меню </summary>
        #region Инициализация элементов меню
        /// <summary> Инициализация элементов меню </summary>

        private static bool _listVisibility_AllUsers;
        public bool listVisibility_AllUsers
        {
            get => _listVisibility_AllUsers;
            set => Set(ref _listVisibility_AllUsers, value);
        }

        private static bool _listVisibility_Customers;
        public bool listVisibility_Customers
        {
            get => _listVisibility_Customers;
            set => Set(ref _listVisibility_Customers, value);
        }

        private static bool _listVisibility_Executors;
        public bool listVisibility_Executors
        {
            get => _listVisibility_Executors;
            set => Set(ref _listVisibility_Executors, value);
        }

        private static bool _listVisibility_RegisterNewUser;
        public bool listVisibility_RegisterNewUser
        {
            get => _listVisibility_RegisterNewUser;
            set => Set(ref _listVisibility_RegisterNewUser, value);
        }

        private static bool _listVisibility_EditUserAccount;
        public bool listVisibility_EditUserAccount
        {
            get => _listVisibility_EditUserAccount;
            set => Set(ref _listVisibility_EditUserAccount, value);
        }

        private static bool _listVisibility_DescriptionRoom;
        public bool listVisibility_DescriptionRoom
        {
            get => _listVisibility_DescriptionRoom;
            set => Set(ref _listVisibility_DescriptionRoom, value);
        }

        private static bool _listVisibility_CreateRequest;
        public bool listVisibility_CreateRequest
        {
            get => _listVisibility_CreateRequest;
            set => Set(ref _listVisibility_CreateRequest, value);
        }

        private static bool _listVisibility_WatchRequest;
        public bool listVisibility_WatchRequest
        {
            get => _listVisibility_WatchRequest;
            set => Set(ref _listVisibility_WatchRequest, value);
        }

        private static bool _listVisibility_WatchArchiveRequest;
        public bool listVisibility_WatchArchiveRequest
        {
            get => _listVisibility_WatchArchiveRequest;
            set => Set(ref _listVisibility_WatchArchiveRequest, value);
        }

        private static bool _listVisibility_MyRequest;
        public bool listVisibility_MyRequest
        {
            get => _listVisibility_MyRequest;
            set => Set(ref _listVisibility_MyRequest, value);
        }

        private static bool _listVisibility_MyArchiveRequest;
        public bool listVisibility_MyArchiveRequest
        {
            get => _listVisibility_MyArchiveRequest;
            set => Set(ref _listVisibility_MyArchiveRequest, value);
        }

        private static bool _listVisibility_FileReport;
        public bool listVisibility_FileReport
        {
            get => _listVisibility_FileReport;
            set => Set(ref _listVisibility_FileReport, value);
        }

        #endregion

        /// <summary> Команды на обработку нажатия по элементам меню </summary>
        #region Команды на обработку нажатия по элементам меню
        /// <summary> Команды на обработку нажатия по элементам меню </summary>

        #region Исполнители
        private ICommand _openExecutorsView;
        public ICommand OpenExecutorsView
        {
            get
            {
                if(_openExecutorsView == null)
                {
                    _openExecutorsView = new OpenExecutorsViewCommand(this);
                }
                return _openExecutorsView;
            }
        }
        #endregion

        #region Все пользователи 
        private ICommand _openAllUsersView;
        public ICommand OpenAllUsersView
        {
            get
            {
                if (_openAllUsersView == null)
                {
                    _openAllUsersView = new OpenAllUsersViewCommand(this);
                }
                return _openAllUsersView;
            }
        }
        #endregion

        #region Заказчики
        private ICommand _openCustomersView;
        public ICommand OpenCustomersView
        {
            get
            {
                if (_openCustomersView == null)
                {
                    _openCustomersView = new OpenCustomersViewCommand(this);
                }
                return _openCustomersView;
            }
        }
        #endregion

        #region Регистрация новых пользователей    НУЖНА ДОРАБОТКА ВЬЮХИ
        private ICommand _openRegUserAccountView;
        public ICommand OpenRegUserAccountView
        {
            get
            {
                if (_openRegUserAccountView == null)
                {
                    _openRegUserAccountView = new OpenRegUserAccountViewCommand(this);
                }
                return _openRegUserAccountView;
            }
        }
        #endregion

        #region Редактирование аккаунта пользователя    НУЖНА ДОРАБОТКА ВЬЮХИ
        private ICommand _openEditUserAccountView;
        public ICommand OpenEditUserAccountView
        {
            get
            {
                if (_openEditUserAccountView == null)
                {
                    _openEditUserAccountView = new OpenEditUserAccountViewCommand(this);
                }
                return _openEditUserAccountView;
            }
        }
        #endregion

        #region Описание помещения
        private ICommand _openDescriptionRoomView;
        public ICommand OpenDescriptionRoomView
        {
            get
            {
                if (_openDescriptionRoomView == null)
                {
                    _openDescriptionRoomView = new OpenDescriptionRoomViewCommand(this);
                }
                return _openDescriptionRoomView;
            }
        }
        #endregion

        #region Создание заявки       НУЖНА ДОРАБОТКА ВЬЮХИ 
        private ICommand _openCreateRequestView;
        public ICommand OpenCreateRequestView
        {
            get
            {
                if (_openCreateRequestView == null)
                {
                    _openCreateRequestView = new OpenCreateRequestViewCommand(this);
                }
                return _openCreateRequestView;
            }
        }
        #endregion

        #region Просмотр всех заявок       НУЖНА ДОРАБОТКА ВЬЮХИ 
        private ICommand _openAllRequestView;
        public ICommand OpenAllRequestView
        {
            get
            {
                if (_openAllRequestView == null)
                {
                    _openAllRequestView = new OpenAllRequestViewCommand(this);
                }
                return _openAllRequestView;
            }
        }
        #endregion

        #region Просмотр моих заявок       НУЖНА ДОРАБОТКА ВЬЮХИ 
        private ICommand _openMyRequestView;
        public ICommand OpenMyRequestView
        {
            get
            {
                if (_openMyRequestView == null)
                {
                    _openMyRequestView = new OpenMyRequestViewCommand(this);
                }
                return _openMyRequestView;
            }
        }
        #endregion

        

        #region Создание отчета  
        private ICommand _openFileReportView;
        public ICommand OpenFileReportView
        {
            get
            {
                if (_openFileReportView == null)
                {
                    _openFileReportView = new OpenFileReportViewCommand(this);
                }
                return _openFileReportView;
            }
        }
        #endregion

        #endregion

    }

    #region Классы для загрузки новых страниц
    internal class OpenFileReportViewCommand : MyCommand
    {
        public OpenFileReportViewCommand(Ctrl_burgerMenu_ViewModel ctrl_Menu_ViewModel) : base(ctrl_Menu_ViewModel) { }
        public override bool CanExecute(object parameter) => true;
        public override void Execute(object parameter) => PageManager.MainFrame.Navigate(new FileReportPage_View());
    }

    internal class OpenMyRequestViewCommand : MyCommand
    {
        public OpenMyRequestViewCommand(Ctrl_burgerMenu_ViewModel ctrl_Menu_ViewModel) : base(ctrl_Menu_ViewModel) { }
        public override bool CanExecute(object parameter) => true;
        public override void Execute(object parameter) => PageManager.MainFrame.Navigate(new MyRequestPage_View());
    }


    internal class OpenAllRequestViewCommand : MyCommand
    {
        public OpenAllRequestViewCommand(Ctrl_burgerMenu_ViewModel ctrl_Menu_ViewModel) : base(ctrl_Menu_ViewModel) { }
        public override bool CanExecute(object parameter) => true;
        public override void Execute(object parameter) => PageManager.MainFrame.Navigate(new AllRequestsPage_View());
    }

    internal class OpenCreateRequestViewCommand : MyCommand
    {
        public OpenCreateRequestViewCommand(Ctrl_burgerMenu_ViewModel ctrl_Menu_ViewModel) : base(ctrl_Menu_ViewModel) { }
        public override bool CanExecute(object parameter) => true;
        public override void Execute(object parameter) => PageManager.MainFrame.Navigate(new CreateRequestPage_View());
    }

    internal class OpenDescriptionRoomViewCommand : MyCommand
    {
        public OpenDescriptionRoomViewCommand(Ctrl_burgerMenu_ViewModel ctrl_Menu_ViewModel) : base(ctrl_Menu_ViewModel) { }
        public override bool CanExecute(object parameter) => true;
        public override void Execute(object parameter) => PageManager.MainFrame.Navigate(new DescriptionRoomPage_View());
    }

    internal class OpenEditUserAccountViewCommand : MyCommand
    {
        UsersData_ViewModel _usersData_ViewModel = new UsersData_ViewModel();
        public OpenEditUserAccountViewCommand(Ctrl_burgerMenu_ViewModel ctrl_Menu_ViewModel) : base(ctrl_Menu_ViewModel) { }
        public override bool CanExecute(object parameter) => true;
        public override void Execute(object parameter)
        {
            if (User_DataModel._idType == 1)
            {
                UpdateData();

                PageManager.MainFrame.Navigate(new UserAccountPage_View());
            }
            else if(User_DataModel._idType == 2)
            {
                UpdateData();

                PageManager.MainFrame.Navigate(new CustomerUserAccountPage_View());
            }
            else if(User_DataModel._idType == 3)
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

    internal class OpenRegUserAccountViewCommand : MyCommand
    {
        public OpenRegUserAccountViewCommand(Ctrl_burgerMenu_ViewModel ctrl_Menu_ViewModel) : base(ctrl_Menu_ViewModel) { }
        public override bool CanExecute(object parameter) => true;
        public override void Execute(object parameter) => PageManager.MainFrame.Navigate(new UserRegistrationPage_View());
    }

    internal class OpenAllUsersViewCommand : MyCommand
    {
        public OpenAllUsersViewCommand(Ctrl_burgerMenu_ViewModel ctrl_Menu_ViewModel) : base(ctrl_Menu_ViewModel) { }
        public override bool CanExecute(object parameter) => true;
        public override void Execute(object parameter) => PageManager.MainFrame.Navigate(new AllUsersPage_View());
    }

    internal class OpenCustomersViewCommand : MyCommand
    {
        public OpenCustomersViewCommand(Ctrl_burgerMenu_ViewModel ctrl_Menu_ViewModel) : base(ctrl_Menu_ViewModel) { }
        public override bool CanExecute(object parameter) => true;
        public override void Execute(object parameter) => PageManager.MainFrame.Navigate(new CustomersPage_View());
    }

    internal class OpenExecutorsViewCommand : MyCommand
    {
        public OpenExecutorsViewCommand(Ctrl_burgerMenu_ViewModel ctrl_Menu_ViewModel) : base(ctrl_Menu_ViewModel) { }
        public override bool CanExecute(object parameter) => true;
        public override void Execute(object parameter) => PageManager.MainFrame.Navigate(new ExecutorsPage_View());
    }
    #endregion

    #region Вспомогательный класс для команд
    abstract class MyCommand : ICommand
    {
        protected Ctrl_burgerMenu_ViewModel _ctrlMenu_ViewModel;

        public MyCommand(Ctrl_burgerMenu_ViewModel ctrlMenu_ViewModel)
        {
            _ctrlMenu_ViewModel = ctrlMenu_ViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public abstract bool CanExecute(object parameter);

        public abstract void Execute(object parameter);
    }
    #endregion

}
