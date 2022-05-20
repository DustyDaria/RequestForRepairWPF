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
    /// Логика взаимодействия для Control_checkBox.xaml
    /// </summary>
    public partial class Control_checkBox : UserControl
    {
        List<string> typeList = new List<string>();

        public Control_checkBox()
        {
            InitializeComponent();

            string queryCountType_GET = string.Format("SELECT COUNT(DISTINCT id_description_TE) FROM TechnicalEquipment ORDER BY id_description_TE;");
            string queryTypeRoom_GET = string.Format("SELECT DISTINCT name_TE, value_TE, in_amount_TE FROM TechnicalEquipment ORDER BY id_description_TE;");

            //typeList = dataBase.GetResultList(queryTypeRoom_GET);
            //
            //for (int i = 0; i < dataBase.GetID(queryCountType_GET); i++)
            //{
            //    CheckBox checkBox = new CheckBox();
            //    checkBox.Content = typeList[i];
            //    checkBox.Margin = new System.Windows.Thickness(5);
            //    //radioButton.FontSize = new System.Windows.FontSizeConverter(12);
            //    checkBox.VerticalAlignment = VerticalAlignment.Center;
            //
            //    //checkBox.Checked += new RoutedEventHandler(checkBox_Checked);
            //    panelForCheckBox.Children.Add(checkBox);
            //}
        }
        
    }
}
