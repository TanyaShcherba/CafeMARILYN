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
using System.Windows.Shapes;

namespace WpfApp1.View.HelperWindow
{
    /// <summary>
    /// Логика взаимодействия для MessegeWindows.xaml
    /// </summary>
    public partial class MessegeWindows : Window
    {
        public MessegeWindows(string message)
        {
            InitializeComponent();
            MessageText.Text = message;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
           Close();
        }
    }
}
