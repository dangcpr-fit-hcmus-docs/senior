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

namespace DataBindingOneObject
{
    /// <summary>
    /// Interaction logic for MobileWindow.xaml
    /// </summary>

    //Do data binding for a mobile phone: Phone’s name, Image, Manufacturer, Price
    public partial class MobileWindow : Window
    {
        public MobileWindow()
        {
            InitializeComponent();
        }

        Mobile _mobile;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _mobile = new Mobile()
            {
                PhoneName = "Điện thoại iPhone 14 Pro 256GB",
                Image = "images/Mobile1.jpg",
                Manufacturer = "Apple",
                Price = 26590000
            };
            DataContext = _mobile;
        }

        private void SubmitButton_onPressed(object sender, RoutedEventArgs e)
        {
            _mobile.PhoneName = "Điện thoại Samsung Galaxy A53 5G 128GB";
            _mobile.Image = "images/Mobile2.jpg";
            _mobile.Manufacturer = "Samsung";
            _mobile.Price = 6790000;
        }
    }
}
