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
        ObservableCollection<Employee> ListEmployee = new ObservableCollection<Employee>();
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

            ListEmployee = new ObservableCollection<Employee>()
            {
                new Employee()
                {
                    FullName = "Nguyễn Văn A",
                    Email = "nguyenvana@gmail.com",
                    Address = "238 Trần Hưng Đạo, Phường Cô Giang, Quận 1, TPHCM",
                    TelephoneNumber = "0989735682",
                    AvatarImage = "images/Employee1.jpg"
                },
                new Employee()
                {
                    FullName = "Nguyễn Thị B",
                    Email = "nguyenthib@outlook.com",
                    Address = "145 Xô Viết Nghệ Tĩnh, Phường 26, Quận Bình Thạnh, TPHCM",
                    TelephoneNumber = "0973266431",
                    AvatarImage = "images/Employee2.jpg"
                },
                new Employee()
                {
                    FullName = "Fourth Nattawat",
                    Email = "fourthnattawat@gmail.com",
                    Address = "212 Nguyễn Trãi, Phường 3, Quận 5, TPHCM",
                    TelephoneNumber = "0985432789",
                    AvatarImage = "images/Employee3.jpg"
                },
                new Employee()
                {
                    FullName = "Wachirawit Ruangwiwat",
                    Email = "wachirawitruangwiwat@outlook.com",
                    Address = "18 Nguyễn Đình Chiểu, Phường 1, Quận 3, TPHCM",
                    TelephoneNumber = "0369327890",
                    AvatarImage = "images/Employee4.jpg"
                },
                new Employee()
                {
                    FullName = "Tawan Vihokratana",
                    Email = "tawanvihokratana@gmmtv.com",
                    Address = "135 Hoàng Diệu, Phường Linh Chiểu, TP Thủ Đức, TPHCM",
                    TelephoneNumber = "0364783267",
                    AvatarImage = "images/Employee5.jpg"
                },
                new Employee()
                {
                    FullName = "Korapat Kirdpan",
                    Email = "korapatkirdpan@apple.com",
                    Address = "111 Hoàng Diệu, Phường 3, Quận Ba Đình, Hà Nội",
                    TelephoneNumber = "0986378102",
                    AvatarImage = "images/Employee6.jpg"
                },
                new Employee()
                {
                    FullName = "Metawin Opas-iamkajorn",
                    Email = "metawinopas-iamkajorn@google.com",
                    Address = "72 Hàng Trống, Phường Tân Định, Quận Cầu Giấy, Hà Nội",
                    TelephoneNumber = "0364836745",
                    AvatarImage = "images/Employee7.jpg"
                },
                new Employee()
                {
                    FullName = "Perawat Sangpotirat",
                    Email = "perawatsangpotirat@hcmus.edu.vn",
                    Address = "150 Hai Bà Trưng, Phường Tân Định, Quận 1, TPHCM",
                    TelephoneNumber = "0367236579",
                    AvatarImage = "images/Employee8.jpg"
                },
                new Employee()
                {
                    FullName = "Thitipoom Techaapaikhun",
                    Email = "thitipoomtechaapaikhun@gmmtv.com",
                    Address = "71 Phạm Ngọc Thạnh, Phường 3, Quận 1, TPHCM",
                    TelephoneNumber = "0367236579",
                    AvatarImage = "images/Employee9.png"
                },
                new Employee()
                {
                    FullName = "Thanat Lowkhunsombat",
                    Email = "thanatlowkhunsombat@google.com",
                    Address = "30 Phạm Văn Đồng, Phường 26, Quận Bình Thạnh, TPHCM",
                    TelephoneNumber = "01645621499",
                    AvatarImage = "images/Employee10.png"
                }
            };
            EmployeeComboBox.ItemsSource = ListEmployee;
        }

        private void SubmitButton_onPressed(object sender, RoutedEventArgs e)
        {
            _employee.FullName = "Nguyễn Thị B";
            _employee.Email = "nguyenthib@outlook.com";
            _employee.Address = "145 Xô Viết Nghệ Tĩnh, Phường 26, Quận Bình Thạnh, TPHCM";
            _employee.TelephoneNumber = "0973266431";
            _employee.AvatarImage = "images/Employee2.jpg";
        }

        private void AddItem_OnPressed(object sender, RoutedEventArgs e)
        {
            ListEmployee.Add(new Employee()
            {
                FullName = "Atthaphan Phunsawat",
                Email = "atthaphanphunsawat@gmail.com",
                Address = "150 Đinh Bộ Lĩnh, Phường 21, Quận Bình Thạnh, TPHCM",
                TelephoneNumber = "0986542167",
                AvatarImage = "images/Employee11.png"
            });
        }

        private void RemoveItem_OnPressed(object sender, RoutedEventArgs e)
        {
            int temp = EmployeeComboBox.SelectedIndex;
            EmployeeComboBox.SelectedIndex = -1;
            ListEmployee.RemoveAt(temp);
        }

        private void UpdateItem_OnPressed(object sender, RoutedEventArgs e)
        {
            ListEmployee[4].FullName = "Jumpol Adulkittiporn";
            ListEmployee[4].Email = "jumpoladulkittiporn@outlook.com";
            ListEmployee[4].Address = "178 Võ Văn Kiệt, Phường 1, Quận 1, TPHCM";
            ListEmployee[4].TelephoneNumber = "0973266431";
            ListEmployee[4].AvatarImage = "images/Employee12.png";
        }

        private void EmployeeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                _employee.FullName = ListEmployee[EmployeeComboBox.SelectedIndex].FullName;
                _employee.Email = ListEmployee[EmployeeComboBox.SelectedIndex].Email;
                _employee.Address = ListEmployee[EmployeeComboBox.SelectedIndex].Address;
                _employee.TelephoneNumber = ListEmployee[EmployeeComboBox.SelectedIndex].TelephoneNumber;
                _employee.AvatarImage = ListEmployee[EmployeeComboBox.SelectedIndex].AvatarImage;
            } catch
            {
                _employee.FullName = "";
                _employee.Email = "";
                _employee.Address = "";
                _employee.TelephoneNumber = "0000000000";
                _employee.AvatarImage = "";
            }
        }
    }
}
