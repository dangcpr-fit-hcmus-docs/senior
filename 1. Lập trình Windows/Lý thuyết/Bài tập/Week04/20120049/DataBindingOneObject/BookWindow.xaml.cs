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
    /// Interaction logic for BookWindow.xaml
    /// </summary>

    //Do data binding for a book: Book’s name, Cover’s image, Author, Published Year
    public partial class BookWindow : Window
    {
        public BookWindow()
        {
            InitializeComponent();
        }
        Book book;
        ObservableCollection<Book> ListBook;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            book = new Book()
            {
                Name = "Sotus - Tháng Ngày Ta Cùng Nhau Bước Qua - Tập 1 (Bản Thường)",
                CoverImage = "images/Book1.jpg",
                Author = "BitterSweet",
                PublishedYear = 2019
            };
            DataContext = book;

            ListBook = new ObservableCollection<Book>()
            {
                new Book()
                {
                    Name = "Sotus - Tháng Ngày Ta Cùng Nhau Bước Qua - Tập 1 (Bản Thường)",
                    CoverImage = "images/Book1.jpg",
                    Author = "BitterSweet",
                    PublishedYear = 2019
                },
                new Book()
                {
                    Name = "Hậu Cung Như Ý Truyện - Tập 1",
                    CoverImage = "images/Book2.jpg",
                    Author = "Lưu Liễm Tử",
                    PublishedYear = 2022
                },
                new Book()
                {
                    Name = "Phương Pháp Giải Toán Tự Luận Và Trắc Nghiệm Hình Học Lớp 12",
                    CoverImage = "images/Book3.jpg",
                    Author = "Nguyễn Văn Nho",
                    PublishedYear = 2017
                },
                new Book()
                {
                    Name = "Thiên Quan Tứ Phúc - Tập 1 (Tái Bản)",
                    CoverImage = "images/Book4.jpg",
                    Author = "Mặc Hương Đồng Khứu",
                    PublishedYear = 2022
                },
                new Book()
                {
                    Name = "Tuổi Trẻ Đáng Giá Bao Nhiêu",
                    CoverImage = "images/Book5.jpg",
                    Author = "Rosie Nguyễn",
                    PublishedYear = 2021,
                },
                new Book()
                {
                    Name = "Dám Mơ Lớn, Đừng Hoài Phí Tuổi Trẻ",
                    CoverImage = "images/Book6.jpg",
                    Author = "Lư Tư Hạo",
                    PublishedYear = 2022
                },
                new Book()
                {
                    Name = "Hành Tinh Của Một Kẻ Nghĩ Nhiều",
                    CoverImage = "images/Book7.jpg",
                    Author = "Amateur Psychology Nguyễn Đoàn Minh Thư",
                    PublishedYear = 2023
                },
                new Book()
                {
                    Name = "Cây Cam Ngọt Của Tôi",
                    CoverImage = "images/Book8.jpg",
                    Author = "José Mauro de Vasconcelos",
                    PublishedYear = 2020
                },
                new Book()
                {
                    Name = "Nhà Giả Kim",
                    CoverImage = "images/Book9.jpg",
                    Author = "Paulo Coelho",
                    PublishedYear = 2020
                },
                new Book()
                {
                    Name = "Đắc Nhân Tâm",
                    CoverImage = "images/Book10.jpg",
                    Author = "Dale Carnegie",
                    PublishedYear = 2021
                }
            };
            BookComboBox.ItemsSource = ListBook;
        }

        private void SubmitButton_onPressed(object sender, RoutedEventArgs e)
        {
            book.Name = "Hậu Cung Như Ý Truyện - Tập 1";
            book.CoverImage = "images/Book2.jpg";
            book.Author = "Lưu Liễm Tử";
            book.PublishedYear = 2022;
        }


        private void AddItem_OnPressed(object sender, RoutedEventArgs e)
        {
            ListBook.Add(new Book()
            {
                Name = "Trí Tuệ Do Thái",
                CoverImage = "images/Book11.jpg",
                Author = "Eran Katz",
                PublishedYear = 2022
            });
        }

        private void RemoveItem_OnPressed(object sender, RoutedEventArgs e)
        {
            int temp = BookComboBox.SelectedIndex;
            BookComboBox.SelectedIndex = -1;
            ListBook.RemoveAt(temp);
        }

        private void UpdateItem_OnPressed(object sender, RoutedEventArgs e)
        {
            ListBook[2].Name = "Hậu Cung Như Ý Truyện - Tập 1";
            ListBook[2].CoverImage = "images/Book2.jpg";
            ListBook[2].Author = "Lưu Liễm Tử";
            ListBook[2].PublishedYear = 2022;
        }

        private void BookComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                book.Name = ListBook[BookComboBox.SelectedIndex].Name;
                book.CoverImage = ListBook[BookComboBox.SelectedIndex].CoverImage;
                book.Author = ListBook[BookComboBox.SelectedIndex].Author;
                book.PublishedYear = ListBook[BookComboBox.SelectedIndex].PublishedYear;
            } catch
            {
                book.Name = "";
                book.CoverImage = "";
                book.Author = "";
                book.PublishedYear = 0;
            }
        }
    }
}
