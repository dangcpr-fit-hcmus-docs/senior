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
    /// Interaction logic for EmployeeWindow.xaml
    /// </summary>

    //Do data binding for an employee: Fullname, Email, Address, Telephone number, Avatar’s image
    public partial class EmployeeWindow : Window
    {
        public EmployeeWindow()
        {
            InitializeComponent();
        }

        Employee _employee = new Employee();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _employee = new Employee()
            {
                FullName = "Nguyễn Văn A",
                Email = "nguyenvana@gmail.com",
                Address = "238 Trần Hưng Đạo, Phường Cô Giang, Quận 1, TPHCM",
                TelephoneNumber = "0989735682",
                AvatarImage = "images/employee1.jpg"
            };

            DataContext = _employee;
        }

        private void SubmitButton_onPressed(object sender, RoutedEventArgs e)
        {
            _employee.FullName = "Nguyễn Thị B";
            _employee.Email = "nguyenthib@outlook.com";
            _employee.Address = "145 Xô Viết Nghệ Tĩnh, phường 26, Quận Bình Thạnh, TPHCM";
            _employee.TelephoneNumber = "0973266431";
            _employee.AvatarImage = "images/employee2.jpg";
        }
    }
}
