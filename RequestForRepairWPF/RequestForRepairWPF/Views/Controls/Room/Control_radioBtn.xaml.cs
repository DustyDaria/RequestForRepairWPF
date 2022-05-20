using RequestForRepairWPF.Data;
using RequestForRepairWPF.Data.Room;
using RequestForRepairWPF.Models.Pages;
using RequestForRepairWPF.ViewModels.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RequestForRepairWPF.Views.Controls.Room
{
    /// <summary>
    /// Логика взаимодействия для UserControl1.xaml
    /// </summary>
    public partial class Control_radioBtn : UserControl
    {
        List<string> _typeList = new List<string>();
        DescriptionRoom_Model _model = new DescriptionRoom_Model();
        DescriptionRoom_ViewModel _viewModel = new DescriptionRoom_ViewModel();
        U_R_Room_DataModel _room = new U_R_Room_DataModel();

        public Control_radioBtn()
        {
            InitializeComponent();

            _typeList = _model.TypeRoom_List;

            

            for (int i = 0; i < _typeList.Count; i++)
            {
                RadioButton radioButton = new RadioButton();
                radioButton.Content = _typeList[i];
                radioButton.Margin = new System.Windows.Thickness(5);
                radioButton.VerticalAlignment = VerticalAlignment.Center;
                radioButton.GroupName = "TypeRoom";
                radioButton.Checked += new RoutedEventHandler(RadioButton_Checked);
                panelForRadioBtn.Children.Add(radioButton);
            }

        }
        

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton item)
            {
                _viewModel.TypeRoom = item.Content.ToString();
                _model.NameTypeRoom_TR = item.Content.ToString();
                U_R_Room_DataModel._idTypeRoom = _model.ID_TypeRoom_TR;
                _viewModel.DescriptionRoom = _model.DescriptionRoom;
                _viewModel.CommentRoom = _model.CommentRoom;
            }
        }
    }
}
