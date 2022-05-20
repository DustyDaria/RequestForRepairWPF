using RequestForRepairWPF.Models.Pages;
using RequestForRepairWPF.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RequestForRepairWPF.ViewModels.Pages
{
    public class DescriptionRoom_ViewModel : ViewModel
    {

        #region Тип помещения
        private static string _roomNumber;
        public string RoomNumber
        {
            get => _roomNumber;
            set => Set(ref _roomNumber, "Номер помещения: " + value);
        }
        #endregion

        #region Тип помещения
        private static string _typeRoom;
        public string TypeRoom
        {
            get => _typeRoom;
            set => Set(ref _typeRoom, value);
        }
        #endregion

        #region Описание помещения
        private static string _descriptionRoom;
        public string DescriptionRoom
        {
            get => _descriptionRoom;
            set => Set(ref _descriptionRoom, value);
        }
        #endregion

        #region комментарий к помещению
        private static string _commentRoom;
        public string CommentRoom
        {
            get => _commentRoom;
            set => Set(ref _commentRoom, value);
        }
        #endregion

        #region id типа помещения
        private static int _id_TypeRoom_URR;
        public int ID_TypeRoom_URR
        {
            get => _id_TypeRoom_URR;
            set => Set(ref _id_TypeRoom_URR, value);
        }
        #endregion

        #region Список с названиями всех типов помещения
        private static List<string> _typeRoomList;
        public List<string> TypeRoomList
        {
            get => _typeRoomList;
            set => Set(ref _typeRoomList, value);
        }
        #endregion

        #region Загрузка данных описания помещения
        private ICommand _loadDescriptionRoom;
        public ICommand LoadDescriptionRoom
        {
            get
            {
                _loadDescriptionRoom = new LoadDescriptionRoomCommand(this);
                return _loadDescriptionRoom;
            }
        }
        #endregion
    }

    #region Класс для выполнения команды по загрузке данных
    internal class LoadDescriptionRoomCommand : MyCommand
    {
        public LoadDescriptionRoomCommand(DescriptionRoom_ViewModel descriptionRoom_ViewModel) : base(descriptionRoom_ViewModel) { }
        public override bool CanExecute(object parameter) => true;
        public override void Execute(object parameter)
        {
            DescriptionRoom_Model _model = new DescriptionRoom_Model();
            //_descriptionRoom_ViewModel.RoomNumber = Convert.ToString(_model.RoomNumber);
            _descriptionRoom_ViewModel.ID_TypeRoom_URR = _model.ID_TypeRoom_URR;
            //_descriptionRoom_ViewModel.TypeRoom = _model.TypeRoom;
            _descriptionRoom_ViewModel.DescriptionRoom = _model.DescriptionRoom;
            _descriptionRoom_ViewModel.CommentRoom = _model.CommentRoom;

        }
    }
    #endregion

    #region Вспомогательный класс для команд
    abstract class MyCommand : ICommand
    {
        protected DescriptionRoom_ViewModel _descriptionRoom_ViewModel;

        public MyCommand(DescriptionRoom_ViewModel descriptionRoom_ViewModel)
        {
            _descriptionRoom_ViewModel = descriptionRoom_ViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public abstract bool CanExecute(object parameter);

        public abstract void Execute(object parameter);
    }
    #endregion
}
