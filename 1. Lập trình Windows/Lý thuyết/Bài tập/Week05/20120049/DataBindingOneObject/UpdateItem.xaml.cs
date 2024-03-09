using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for UpdateItem.xaml
    /// </summary>
    public partial class UpdateItem : Window
    {
        public UpdateItem()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection conn = DB.Instance.Connection;

                using (SqlCommand query = new SqlCommand("SELECT MAX(id) FROM BOOK", conn))
                {
                    //TODO: May be you have parameters - assign them here...

                    string saveBook = "UPDATE Book SET name = @name, coverimage = @coverimage, author = @author, publishedyear = @publishedyear WHERE id = @id";

                    using (SqlCommand querySaveBook = new SqlCommand(saveBook))
                    {
                        querySaveBook.Connection = conn;

                        querySaveBook.Parameters.Add("@name", SqlDbType.NVarChar, 128).Value = nameTextBox.Text;
                        querySaveBook.Parameters.Add("@coverimage", SqlDbType.NVarChar, 128).Value = coverImageTextBox.Text;
                        querySaveBook.Parameters.Add("@author", SqlDbType.NVarChar, 128).Value = authorTextBox.Text;
                        querySaveBook.Parameters.Add("@publishedyear", SqlDbType.Int).Value = publisedYearTextBox.Text;
                        querySaveBook.Parameters.Add("@id", SqlDbType.Int).Value = idTextBox.Text;

                        querySaveBook.ExecuteNonQuery();
                    }
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
                MessageBox.Show("Update Thành công");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            idTextBox.Text = BookWindow.idSelected.ToString();
            nameTextBox.Text = BookWindow.book.Name;
            coverImageTextBox.Text = BookWindow.book.CoverImage;
            authorTextBox.Text = BookWindow.book.Author;
            publisedYearTextBox.Text = BookWindow.book.PublishedYear.ToString();
        }
    }
}
