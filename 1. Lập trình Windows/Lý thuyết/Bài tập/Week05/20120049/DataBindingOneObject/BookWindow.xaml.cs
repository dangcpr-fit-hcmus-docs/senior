using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Reflection.PortableExecutable;
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
        public static Book book;
        
        public static ObservableCollection<Book> ListBook;
        public static int idSelected = 1;
        public void BookWindow_Loaded(object sender, RoutedEventArgs e)
        {
            book = new Book()
            {
                id = 1,
                Name = "Sotus - Tháng Ngày Ta Cùng Nhau Bước Qua - Tập 1 (Bản Thường)",
                CoverImage = "images/Book1.jpg",
                Author = "BitterSweet",
                PublishedYear = 2019
            };
            DataContext = book;

            ListBook = new ObservableCollection<Book>();

            SqlConnection conn = DB.Instance.Connection;


            SqlCommand query = new SqlCommand("SELECT * FROM BOOK", conn);
              
                    //TODO: May be you have parameters - assign them here...

            var reader = query.ExecuteReader();

            while (reader.Read())
            {
                ListBook.Add(
                    new Book
                    {
                        id = (int)reader.GetValue(0),
                        Name = (string)reader.GetValue(1),
                        CoverImage = (string)reader.GetValue(2),
                        Author = (string)reader.GetValue(3),
                        PublishedYear = (int)reader.GetValue(4)
                    }
                );
            }

            /*
            ListBook = new ObservableCollection<Book>()
            {
                new Book()
                {
                    id = 1,
                    Name = "Sotus - Tháng Ngày Ta Cùng Nhau Bước Qua - Tập 1 (Bản Thường)",
                    CoverImage = "images/Book1.jpg",
                    Author = "BitterSweet",
                    PublishedYear = 2019
                },
                new Book()
                {
                    id = 2,
                    Name = "Hậu Cung Như Ý Truyện - Tập 1",
                    CoverImage = "images/Book2.jpg",
                    Author = "Lưu Liễm Tử",
                    PublishedYear = 2022
                },
                new Book()
                {
                    id = 3,
                    Name = "Phương Pháp Giải Toán Tự Luận Và Trắc Nghiệm Hình Học Lớp 12",
                    CoverImage = "images/Book3.jpg",
                    Author = "Nguyễn Văn Nho",
                    PublishedYear = 2017
                },
                new Book()
                {
                    id = 4,
                    Name = "Thiên Quan Tứ Phúc - Tập 1 (Tái Bản)",
                    CoverImage = "images/Book4.jpg",
                    Author = "Mặc Hương Đồng Khứu",
                    PublishedYear = 2022
                },
                new Book()
                {
                    id = 5,
                    Name = "Tuổi Trẻ Đáng Giá Bao Nhiêu",
                    CoverImage = "images/Book5.jpg",
                    Author = "Rosie Nguyễn",
                    PublishedYear = 2021,
                },
                new Book()
                {
                    id = 6,
                    Name = "Dám Mơ Lớn, Đừng Hoài Phí Tuổi Trẻ",
                    CoverImage = "images/Book6.jpg",
                    Author = "Lư Tư Hạo",
                    PublishedYear = 2022
                },
                new Book()
                {
                    id = 7,
                    Name = "Hành Tinh Của Một Kẻ Nghĩ Nhiều",
                    CoverImage = "images/Book7.jpg",
                    Author = "Amateur Psychology Nguyễn Đoàn Minh Thư",
                    PublishedYear = 2023
                },
                new Book()
                {
                    id = 8,
                    Name = "Cây Cam Ngọt Của Tôi",
                    CoverImage = "images/Book8.jpg",
                    Author = "José Mauro de Vasconcelos",
                    PublishedYear = 2020
                },
                new Book()
                {
                    id = 9,
                    Name = "Nhà Giả Kim",
                    CoverImage = "images/Book9.jpg",
                    Author = "Paulo Coelho",
                    PublishedYear = 2020
                },
                new Book()
                {
                    id = 10,
                    Name = "Đắc Nhân Tâm",
                    CoverImage = "images/Book10.jpg",
                    Author = "Dale Carnegie",
                    PublishedYear = 2021
                }
            };
            */
            BookComboBox.ItemsSource = ListBook;

            /*
            using (SqlConnection openCon = DB.Instance.Connection) {
                foreach (var item in ListBook)
                {
                    {
                        string saveBook = "INSERT into book (id, name, coverimage, author, publishedyear) VALUES (@id, @name, @coverimage, @author, @publishedyear)";

                        using (SqlCommand querySaveBook = new SqlCommand(saveBook))
                        {
                            querySaveBook.Connection = openCon;
                            querySaveBook.Parameters.Add("@id", SqlDbType.Int).Value = item.id;
                            querySaveBook.Parameters.Add("@name", SqlDbType.NVarChar, 128).Value = item.Name;
                            querySaveBook.Parameters.Add("@coverimage", SqlDbType.NVarChar, 128).Value = item.CoverImage;
                            querySaveBook.Parameters.Add("@author", SqlDbType.NVarChar, 128).Value = item.Author;
                            querySaveBook.Parameters.Add("@publishedyear", SqlDbType.Int).Value = item.PublishedYear;

                            querySaveBook.ExecuteNonQuery();
                        }
                    }
                }
            }
            */
        }

        private void AddItem_OnPressed(object sender, RoutedEventArgs e)
        {
            AddItem addItem = new AddItem();
            addItem.Show();
        }

        private void RemoveItem_OnPressed(object sender, RoutedEventArgs e)
        {
            try
            {
                int temp = BookComboBox.SelectedIndex;
                SqlConnection conn = DB.Instance.Connection;


                string saveBook = "DELETE FROM BOOK WHERE id = @id";

                using (SqlCommand querySaveBook = new SqlCommand(saveBook))
                {
                    querySaveBook.Connection = conn;
                    querySaveBook.Parameters.Add("@id", SqlDbType.Int).Value = idSelected;

                    querySaveBook.ExecuteNonQuery();
                }

                BookWindow.ListBook.Clear();

                using (SqlCommand query = new SqlCommand("SELECT * FROM BOOK", conn))
                {
                    //TODO: May be you have parameters - assign them here...

                    using (var reader = query.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            BookWindow.ListBook.Add(
                                new Book
                                {
                                    id = (int)reader.GetValue(0),
                                    Name = (string)reader.GetValue(1),
                                    CoverImage = (string)reader.GetValue(2),
                                    Author = (string)reader.GetValue(3),
                                    PublishedYear = (int)reader.GetValue(4)
                                }
                            );
                        }
                    }
                }

                MessageBox.Show("Xóa thành công");
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void UpdateItem_OnPressed(object sender, RoutedEventArgs e)
        {
            UpdateItem updateItem = new UpdateItem();
            updateItem.Show();
        }

        private void BookComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                idSelected = ListBook[BookComboBox.SelectedIndex].id;
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
