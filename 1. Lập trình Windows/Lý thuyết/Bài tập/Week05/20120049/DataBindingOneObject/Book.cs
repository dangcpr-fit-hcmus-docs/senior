using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBindingOneObject
{
    public class Book : INotifyPropertyChanged
    {
        public int id { get; set; }

        public string? Name {  get; set; }

        public string? CoverImage { get; set; }

        public string? Author { get; set; }

        public int PublishedYear { get; set; }

        public ObservableCollection<Book> ListBook()
        {
            ObservableCollection<Book> ListBook = new ObservableCollection<Book>();

            using (SqlConnection conn = DB.Instance.Connection)
            {
                using (SqlCommand query = new SqlCommand("SELECT * FROM BOOK", conn))
                {
                    //TODO: May be you have parameters - assign them here...

                    using (var reader = query.ExecuteReader())
                    {
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
                    }

                }
            }

            return ListBook;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
