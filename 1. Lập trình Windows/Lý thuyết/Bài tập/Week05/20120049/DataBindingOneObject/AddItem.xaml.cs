using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for AddItem.xaml
    /// </summary>
    public partial class AddItem : Window
    {
        public AddItem()
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

                    string saveBook = "INSERT into book (id, name, coverimage, author, publishedyear) VALUES (@id, @name, @coverimage, @author, @publishedyear)";

                    using (SqlCommand querySaveBook = new SqlCommand(saveBook))
                    {
                        querySaveBook.Connection = conn;

                        querySaveBook.Parameters.Add("@id", SqlDbType.Int).Value = idTextBox.Text;
                        querySaveBook.Parameters.Add("@name", SqlDbType.NVarChar, 128).Value = nameTextBox.Text;
                        querySaveBook.Parameters.Add("@coverimage", SqlDbType.NVarChar, 128).Value = coverImageTextBox.Text;
                        querySaveBook.Parameters.Add("@author", SqlDbType.NVarChar, 128).Value = authorTextBox.Text;
                        querySaveBook.Parameters.Add("@publishedyear", SqlDbType.Int).Value = publisedYearTextBox.Text;

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
                MessageBox.Show("Insert Thành công");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SqlConnection conn = DB.Instance.Connection;

            using (SqlCommand query = new SqlCommand("SELECT MAX(id) FROM BOOK", conn))
            {
                //TODO: May be you have parameters - assign them here...
                using (var reader = query.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        idTextBox.Text =((int)reader.GetValue(0) + 1).ToString();
                    }

                }
            }
        }

    }
}
