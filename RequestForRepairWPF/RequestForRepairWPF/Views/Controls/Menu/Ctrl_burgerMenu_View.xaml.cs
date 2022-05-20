using RequestForRepairWPF.ViewModels.Controls.Menu;
using RequestForRepairWPF.Views.Windows;
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

namespace RequestForRepairWPF.Views.Controls.Menu
{
    /// <summary>
    /// Логика взаимодействия для Ctrl_burgerMenu.xaml
    /// </summary>
    /// 

    public partial class Ctrl_burgerMenu_View : UserControl
    {

        public Visibility MyVisibility
       {
           get { return (Visibility)GetValue(MyVisibilityProperty); }
           set { SetValue(MyVisibilityProperty, value); }
       }
       
       public static readonly DependencyProperty MyVisibilityProperty =
           DependencyProperty.Register("MyVisibility", typeof(Visibility),
               typeof(Ctrl_burgerMenu_View), new UIPropertyMetadata(Visibility.Collapsed));

        private static void MyPropertyVisibleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
        
        }

        //public object MyPropertyVisible
        //{
        //    get => (object)GetValue(MyPropertyVisibleProperty); 
        //    set => SetValue(MyPropertyVisibleProperty, value); 
        //}
        //
        //// Using a DependencyProperty as the backing store for MyPropertyVisible.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty MyPropertyVisibleProperty =
        //    DependencyProperty.Register("MyPropertyVisible", typeof(object), typeof(Ctrl_burgerMenu_View),
        //        new PropertyMetadata(default(object)));
        //
        //private static void MyPropertyVisibleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        //{
        //
        //}

        public Ctrl_burgerMenu_View()
        {
            InitializeComponent();
        }

        private void btn_CloseMenu_Click(object sender, RoutedEventArgs e)
        {
            btn_OpenMenu.Visibility = Visibility.Visible;
            btn_CloseMenu.Visibility = Visibility.Collapsed;
        }

        private void btn_OpenMenu_Click(object sender, RoutedEventArgs e)
        {
            btn_OpenMenu.Visibility = Visibility.Collapsed;
            btn_CloseMenu.Visibility = Visibility.Visible;
        }
    }
}
