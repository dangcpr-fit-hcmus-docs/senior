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

namespace LayoutPractice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Screen1Button_onPressed(object sender, RoutedEventArgs e)
        {
            Screen1 screen1 = new Screen1();
            screen1.Show();
        }

        private void Screen2Button_onPressed(object sender, RoutedEventArgs e)
        {
            Screen2 screen2 = new Screen2();
            screen2.Show();
        }

        private void Screen3Button_onPressed(object sender, RoutedEventArgs e)
        {
            Screen3 screen3 = new Screen3();
            screen3.Show();
        }
    }
}
