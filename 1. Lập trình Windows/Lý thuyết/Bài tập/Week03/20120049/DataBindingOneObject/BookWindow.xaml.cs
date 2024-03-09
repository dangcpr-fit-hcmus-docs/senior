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
        }

        private void SubmitButton_onPressed(object sender, RoutedEventArgs e)
        {
            book.Name = "Hậu Cung Như Ý Truyện - Tập 1";
            book.CoverImage = "images/Book2.jpg";
            book.Author = "Lưu Liễm Tử";
            book.PublishedYear = 2022;
        }
    }
}
