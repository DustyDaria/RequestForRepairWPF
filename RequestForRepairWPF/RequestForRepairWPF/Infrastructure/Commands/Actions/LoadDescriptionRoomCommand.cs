using RequestForRepairWPF.Models.Pages;
using RequestForRepairWPF.ViewModels.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestForRepairWPF.Infrastructure.Commands.Actions
{
    /// <summary>
    /// Класс для выполнения команды по загрузке данных
    /// </summary>
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
}
