using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        ObservableCollection<Mobile> ListMobile = new ObservableCollection<Mobile>();

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

            ListMobile = new ObservableCollection<Mobile>()
            {
                new Mobile()
                {
                    PhoneName = "iPhone 14 Pro 256GB",
                    Image = "images/Mobile1.jpg",
                    Manufacturer = "Apple",
                    Price = 26590000,
                },
                new Mobile()
                {
                    PhoneName = "Samsung Galaxy A53 5G 128GB",
                    Image = "images/Mobile2.jpg",
                    Manufacturer = "Samsung",
                    Price = 6790000,
                },
                new Mobile()
                {
                    PhoneName = "Xiaomi 13 5G",
                    Image = "images/Mobile3.jpg",
                    Manufacturer = "Xiaomi",
                    Price = 16990000
                },
                new Mobile()
                {
                    PhoneName = "Samsung Galaxy S21 FE 5G (6GB/128GB)",
                    Image = "images/Mobile4.jpg",
                    Manufacturer = "Samsung",
                    Price = 9790000
                },
                new Mobile()
                {
                    PhoneName = "Vivo V25 5G",
                    Image = "images/Mobile5.jpg",
                    Manufacturer = "Vivo",
                    Price = 6990000
                },
                new Mobile()
                {
                    PhoneName = "Realme C51 64GB",
                    Image = "images/Mobile6.jpg",
                    Manufacturer = "Realme",
                    Price = 3490000
                },
                new Mobile()
                {
                    PhoneName = "Samsung Galaxy S23 Ultra 5G 256GB",
                    Image = "images/Mobile7.jpg",
                    Manufacturer = "Samsung",
                    Price = 21790000
                },
                new Mobile()
                {
                    PhoneName = "OPPO Find X5 Pro 5G",
                    Image = "images/Mobile8.jpg",
                    Manufacturer = "OPPO",
                    Price = 17990000
                },
                new Mobile()
                {
                    PhoneName = "Itel L6502",
                    Image = "images/Mobile9.jpg",
                    Manufacturer = "Itel",
                    Price = 1590000
                },
                new Mobile()
                {
                    PhoneName = "OPPO Reno8 T",
                    Image = "images/Mobile10.jpg",
                    Manufacturer = "OPPO",
                    Price = 7490000
                }
            };
            MobileComboBox.ItemsSource = ListMobile;
        }

        private void SubmitButton_onPressed(object sender, RoutedEventArgs e)
        {
            _mobile.PhoneName = "Samsung Galaxy A53 5G 128GB";
            _mobile.Image = "images/Mobile2.jpg";
            _mobile.Manufacturer = "Samsung";
            _mobile.Price = 6790000;
        }

        private void AddItem_OnPressed(object sender, RoutedEventArgs e)
        {
            ListMobile.Add(new Mobile()
            {
                PhoneName = "Samsung Galaxy M34 5G ",
                Image = "images/Mobile11.jpg",
                Manufacturer = "Samsung",
                Price = 7690000
            });
        }

        private void RemoveItem_OnPressed(object sender, RoutedEventArgs e)
        {
            int temp = MobileComboBox.SelectedIndex;
            MobileComboBox.SelectedIndex = -1;
            ListMobile.RemoveAt(temp);
        }

        private void UpdateItem_OnPressed(object sender, RoutedEventArgs e)
        {
            ListMobile[2].PhoneName = "iPhone 13 128GB";
            ListMobile[2].Image = "images/Mobile12.jpeg";
            ListMobile[2].Manufacturer = "Apple";
            ListMobile[2].Price = 16990000;
        }

        private void MobileComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                _mobile.PhoneName = ListMobile[MobileComboBox.SelectedIndex].PhoneName;
                _mobile.Image = ListMobile[MobileComboBox.SelectedIndex].Image;
                _mobile.Manufacturer = ListMobile[MobileComboBox.SelectedIndex].Manufacturer;
                _mobile.Price = ListMobile[MobileComboBox.SelectedIndex].Price;
            } catch
            {
                _mobile.PhoneName = "";
                _mobile.Image = "";
                _mobile.Manufacturer = "";
                _mobile.Price = 0;
            }
        }
    }
}
